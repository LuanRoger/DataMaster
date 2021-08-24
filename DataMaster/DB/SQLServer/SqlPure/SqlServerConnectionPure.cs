using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMaster.Managers;
using DataMaster.Util;
using DataTable = DatabaseEngineInterpreter.SqlSyntaxInfo.DataTable;

namespace DataMaster.DB.SQLServer.SqlPure
{
    public static class SqlServerConnectionPure
    {
        private static SqlConnection tempSqlConnection {get; set;}
        
        public static ConnectionState GetConnectionStatus() => DbConnectionManager.sqlServerConnection.State;

        #region OpenCloseConnections
        public static void OpenConnection()
        {
            try { DbConnectionManager.sqlServerConnection.Open(); }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possivel conectar-se ao banco de dados: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CloseConnection()
        {
            try { DbConnectionManager.sqlServerConnection.Close(); }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possivel fechar a conexão: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void OpenTempConnection()
        {
            try { tempSqlConnection.Open(); }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possivel conectar-se ao banco de dados: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CloseTempConnection()
        {
            try { tempSqlConnection.Close(); }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possivel fechar a conexão: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        
        public static ConnectionState TestPseudoConnection(string server) //TODO - Debug this/Inspecionar
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
                OpenTempConnection();
                connectionState = tempSqlConnection.State;
                CloseTempConnection();
            }
            catch { connectionState = tempSqlConnection.State; }
            
            tempSqlConnection.Dispose();
            
            return connectionState;
        }

        #region DatabaseCriation
        public static async Task CreateDb(SqlInfo sqlInfo)
        {
            tempSqlConnection = new() {ConnectionString = DbConnectionManager.sqlServerConnection.ConnectionString};
            
            SqlCommand command = new()
            {
                Connection = tempSqlConnection,
                CommandText = $"CREATE DATABASE {sqlInfo.databaseName};"
            };
            
            OpenTempConnection();
            try { await command.ExecuteNonQueryAsync(); }
            catch (Exception e)
            {
                throw new($"Has not possible create {sqlInfo.databaseName}: {e.Message}");
            }
            finally { CloseTempConnection(); }

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
                        {
                            commandBuilder.Append("IDENTITY (1, 1)   PRIMARY KEY    ");
                        }
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
            
            OpenTempConnection();
            try { await command.ExecuteNonQueryAsync(); }
            catch (Exception e)
            {
                throw new($"Has not possible create {sqlInfo.databaseName}: {e.Message}");
            }
            finally { CloseTempConnection(); }
            
            commandBuilder.Clear();
            command.Dispose();
            tempSqlConnection.Dispose();
        }
        #endregion
    }
}