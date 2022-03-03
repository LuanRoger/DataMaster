using System.Data;
using System.Data.SqlClient;
using System.Text;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataTable = System.Data.DataTable;

namespace DatabaseEngine.DB.SQLServer;

public class SqlServerDomain : IDbProvider<SqlConnection>, ISqlDriverCommands, IDisposable
{
    public SqlServerDomain(string connectionString) : base(connectionString)
    {
        connection = new(connectionString);
    }

    #region OpenCloseConnection

    public async Task<bool> TryOpenConnection()
    {
        await connection.OpenAsync();
        
        return connection.State == ConnectionState.Open;
    }
    public async Task<bool> TryCloseConnection()
    {
        await connection.CloseAsync();
        
        return connection.State == ConnectionState.Open;
    }
    #endregion

    public async Task CreateDb(SqlInfo sqlInfo)
    {
        SqlCommand sqlCommand = new()
        {
            Connection = connection,
            CommandText = $"CREATE DATABASE {sqlInfo.databaseName}"
        };
        
        await TryOpenConnection();
        await sqlCommand.ExecuteNonQueryAsync();
        await TryCloseConnection();
        
        sqlCommand.Dispose();
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

    public async Task<int> ExecuteSqlCommand(string command)
    {
        SqlCommand sqlCommand = new()
        {
            Connection = connection,
            CommandText = command
        };
        
        await TryOpenConnection();
        int rowsAffected = await sqlCommand.ExecuteNonQueryAsync();
        await TryCloseConnection();
        
        return rowsAffected;
    }

    public async Task<DataTable> ExecuteQueryCommand(string command)
    {
        DataTable dataTable = new();
        
        await TryOpenConnection();
        SqlDataAdapter dataAdapter = new(command, connection);
        dataAdapter.Fill(dataTable);
        await TryCloseConnection();
        
        return dataTable;
    }

    public void Dispose()
    {
        connection.Dispose();
        GC.SuppressFinalize(this);
    }
}