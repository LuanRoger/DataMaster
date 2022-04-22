using System.Data;
using System.Text;
using DatabaseEngine.Exceptions;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using System.Data.SQLite;

namespace DatabaseEngine.DB.SQLite;

public class SqliteDomain : DbProvider<SQLiteConnection>, ISqlDriverCommands, IDisposable
{
    public SqliteDomain(string connectionString) : base(connectionString)
    {
        connection = new(connectionString);
    }

    #region OpenCloseConnection
    public async Task<bool> TryOpenConnection()
    {
        if(connection is null)
            throw new ArgumentException($"{nameof(connection)} is null");

        await connection.OpenAsync();
        
        return connection.State == ConnectionState.Open;
    }
    public async Task<bool> TryCloseConnection()
    {
        if(connection is null)
            throw new ArgumentException($"{nameof(connection)} is null");
        
        await connection.OpenAsync();
        
        return connection.State == ConnectionState.Closed;
    }
    #endregion

    #region CreateDatabase
    public async Task CreateDb(SqlInfo sqlInfo)
    {
        if(connection is null)
            throw new ArgumentException($"{nameof(connection)} is null");
        
        SQLiteCommand createDbCommand = connection.CreateCommand();
        createDbCommand.CommandText = "CREATE DATABASE $dbName";
        
        if(!sqlInfo.databaseName.Contains(".db"))
            throw new InvalidDatabaseName(sqlInfo.databaseName, "Sqlite");
        createDbCommand.Parameters.AddWithValue("$dbName", sqlInfo.databaseName);
        
        await TryOpenConnection();
        _ = await createDbCommand.ExecuteNonQueryAsync();
        await TryCloseConnection();
        
        await createDbCommand.DisposeAsync();
        InsertTablesColunms(sqlInfo);
    }
    private void InsertTablesColunms(SqlInfo sqlInfo)
    {
        StringBuilder commandBuilder = new();
        foreach (SqlTable table in sqlInfo.tables)
        {
            commandBuilder.Append("CREATE TABLE {table.name} (");
            foreach (SqlColumns columns in table.colunms)
            {
                commandBuilder.Append($"{columns.name}    {columns.dataType}    ");
                if(columns.hasKey)
                    commandBuilder.Append("IDENTITY (1, 1)    PRIMARY KEY    ");
                
                commandBuilder.AppendLine(columns.allowNull ? "NULL," : "NOT NULL,");
            }
            commandBuilder.AppendLine(");");
        }
    }
    #endregion

    public async Task<int> ExecuteSqlCommand(string command)
    {
        if(connection is null)
            throw new ArgumentException($"{nameof(connection)} is null");
        
        SQLiteCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = command;
        
        await TryOpenConnection();
        int rowsAffected = sqlCommand.ExecuteNonQuery();
        await TryCloseConnection();
        
        return rowsAffected;
    }

    public async Task<DataTable> ExecuteQueryCommand(string command)
    {
        if(connection is null)
            throw new ArgumentException($"{nameof(connection)} is null");
        DataTable dataTable = new();
        
        await TryOpenConnection();
        SQLiteDataAdapter dataAdapter = new(command, connection);
        dataAdapter.Fill(dataTable);
        await TryCloseConnection();
        
        return dataTable;
    }

    public void Dispose()
    {
        connection?.Dispose();
        
        GC.SuppressFinalize(this);
    }
}