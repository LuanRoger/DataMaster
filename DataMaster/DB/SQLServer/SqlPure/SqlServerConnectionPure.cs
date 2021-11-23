#nullable enable
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMaster.Managers;
using DataMaster.Util;
using DataMaster.Util.Exceptions;
using DataTable = DatabaseEngineInterpreter.SqlSyntaxInfo.DataTable;

namespace DataMaster.DB.SQLServer.SqlPure
{
    public static class SqlServerConnectionPure
    {
        private static SqlConnection tempSqlConnection {get; set;}
        
        public static ConnectionState GetConnectionStatus() => DbConnectionManager.sqlServerConnection.State;

        #region OpenCloseConnections
        public static bool TryOpenConnection()
        {
            try { DbConnectionManager.sqlServerConnection.Open(); }
            catch { return false; }
            return true;
        }
        public static bool TryCloseConnection()
        {
            try { DbConnectionManager.sqlServerConnection.Close(); }
            catch { return false; }
            return true;
        }

        private static bool TryOpenTempConnection()
        {
            try { tempSqlConnection.Open(); }
            catch { return false; }
            return true;
        }

        private static bool TryCloseTempConnection()
        {
            try { tempSqlConnection.Close(); }
            catch { return false; }
            return true;
        }
        #endregion
        
        public static ConnectionState TestPseudoConnection(string server)
        {
            ConnStringBuilder.ClearConnectionStringBuilder();
            ConnStringBuilder.connectionServer = server;
            ConnStringBuilder.trustedConnection = true;
            
            tempSqlConnection = new() 
                { ConnectionString = ConnStringBuilder.connectionString };
            
            return TryConnect();
        }
        public static ConnectionState TestPseudoConnection(string server, string dbName)
        {
            ConnStringBuilder.ClearConnectionStringBuilder();
            ConnStringBuilder.connectionServer = server;
            ConnStringBuilder.connectionDatabase = dbName;
            ConnStringBuilder.trustedConnection = true;
            
            tempSqlConnection = new() 
                { ConnectionString = ConnStringBuilder.connectionString };
            
            return TryConnect();
        }

        private static ConnectionState TryConnect()
        {
            ConnectionState connectionState;
            try
            {
                TryOpenTempConnection();
                connectionState = tempSqlConnection.State;
                TryCloseTempConnection();
            }
            catch { connectionState = tempSqlConnection.State; }
            
            tempSqlConnection.Dispose();
            
            return connectionState;
        }
        
        #region DatabaseCriation
        public static async Task CreateDb(SqlInfo sqlInfo)
        {
            if(!string.IsNullOrEmpty(DbConnectionManager.GetConnectedDatabase()))
                throw new DatabaseConnectedException();
            
            tempSqlConnection = new() {ConnectionString = DbConnectionManager.sqlServerConnection.ConnectionString};
            
            SqlCommand command = new()
            {
                Connection = tempSqlConnection,
                CommandText = $"CREATE DATABASE {sqlInfo.databaseName};"
            };
            
            TryOpenTempConnection();
            await command.ExecuteNonQueryAsync();
            TryCloseTempConnection();

            command.Dispose();
            await InsertTablesColunms(sqlInfo);
        }
        private static async Task InsertTablesColunms(SqlInfo sqlInfo)
        {
            ConnStringBuilder.ClearConnectionStringBuilder();
            ConnStringBuilder.connectionServer = DbConnectionManager.GetConnectedServer();
            ConnStringBuilder.connectionDatabase = sqlInfo.databaseName;
            ConnStringBuilder.trustedConnection = true;
            
            tempSqlConnection = new() {ConnectionString = ConnStringBuilder.connectionString};
            
            StringBuilder commandBuilder = new();
            await Task.Run(() =>
            {
                foreach (DataTable tables in sqlInfo.tables)
                {
                    commandBuilder.AppendLine($"CREATE TABLE {tables.name} (");
                    foreach (DataTableColumns columns in tables.colunms)
                    {
                        commandBuilder.Append($"[{columns.name}]    {columns.dataType}  ");
                        if(columns.hasKey)
                            commandBuilder.Append("IDENTITY (1, 1)   PRIMARY KEY    ");
                        
                        commandBuilder.AppendLine(columns.allowNull ? "NULL," : "NOT NULL,");
                    }
                    commandBuilder.AppendLine(");");
                } 
            });

            SqlCommand command = new()
            {
                Connection = tempSqlConnection,
                CommandText = commandBuilder.ToString()
            };
            
            TryOpenTempConnection();
            await command.ExecuteNonQueryAsync();
            TryCloseTempConnection();
            
            commandBuilder.Clear();
            command.Dispose();
            tempSqlConnection.Dispose();
        }
        #endregion
        
        public static async Task<System.Data.DataTable> ExecuteSqlCommand(string command)
        {
            tempSqlConnection = new() {ConnectionString = DbConnectionManager.sqlServerConnection.ConnectionString};
            System.Data.DataTable dataTable = new();

            TryOpenTempConnection();
            await Task.Run(() =>
            {
                SqlDataAdapter dataAdapter = new(command, tempSqlConnection);
                dataAdapter.Fill(dataTable);
            }) ;
            TryCloseTempConnection();

            return dataTable;
        }
    }
}