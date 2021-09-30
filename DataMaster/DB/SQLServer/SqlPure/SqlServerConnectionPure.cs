#nullable enable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMaster.Managers;
using DataMaster.Types;
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

        private static void OpenTempConnection()
        {
            try { tempSqlConnection.Open(); }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possivel conectar-se ao banco de dados: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CloseTempConnection()
        {
            try { tempSqlConnection.Close(); }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possivel fechar a conexão: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if(!string.IsNullOrEmpty(DbConnectionManager.GetConnectedDatabase()))
                throw new DatabaseConnectedException();
            
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

        #region DatabaseLoader
        public static async Task<List<TreeNodeTable>> GetAllTables()
        {
            tempSqlConnection = new() {ConnectionString = DbConnectionManager.sqlServerConnection.ConnectionString};
            System.Data.DataTable databaseTables = new();

            OpenTempConnection();
            try
            {
                await Task.Run(() =>
                {
                    SqlDataAdapter sqlCommand = 
                        new($"SELECT * FROM [{DbConnectionManager.GetConnectedDatabase()}].INFORMATION_SCHEMA.TABLES", tempSqlConnection);
                    sqlCommand.Fill(databaseTables);
                });
            }
            catch (Exception e)
            {
                throw new($"Ocurrs a error: {e.Message}");
            }
            finally { CloseTempConnection(); }
            
            List<TreeNodeTable> database = new();
            foreach (DataRow databaseTable in databaseTables.Rows)
            {
                TreeNodeTable table = new(databaseTable[2].ToString(), await GetColumn(databaseTable[2].ToString()!));

                database.Add(table);
            }
            
            tempSqlConnection.Dispose();
            
            return database;
        }
        
        private static async Task<List<TreeNodeColumn>> GetColumn(string tableName)
        {
            System.Data.DataTable tableColumns = new();
            
            OpenTempConnection();
            try
            {
                await Task.Run(() =>
                {
                    SqlDataAdapter sqlCommand = 
                        new("SELECT * FROM " +
                            $"[{DbConnectionManager.GetConnectedDatabase()}].INFORMATION_SCHEMA.COLUMNS " +
                            $"WHERE TABLE_NAME = '{tableName}'", tempSqlConnection);
                    sqlCommand.Fill(tableColumns);
                });
            }
            catch(SqlException e)
            {
                throw new($"Ocurrs a error: {e.Message}");
            }
            finally{CloseTempConnection();}
            
            
            TreeNodeColumn column;
            List<TreeNodeColumn> columns = new();
            foreach (DataRow tableColumn in tableColumns.Rows)
            {
                column = new(tableColumn[3].ToString(),
                    tableColumn[8].ToString() == "NULL" ? tableColumn[7].ToString() : 
                        $"{tableColumn[7]}({tableColumn[8]})",
                    tableColumn[3].ToString() == "ID",
                    tableColumn[6].ToString() == "YES");
                columns.Add(column);
            }
            
            return columns;
        }
        #endregion
    }
}