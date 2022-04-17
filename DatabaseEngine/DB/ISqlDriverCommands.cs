using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataTable = System.Data.DataTable;

namespace DatabaseEngine.DB;

public interface ISqlDriverCommands
{
    /// <summary>
    /// Try to open the connection.
    /// </summary>
    /// <returns>Return <c>true</c> if the open's successfully or <c>false</c> if's not.</returns>
    public Task<bool> TryOpenConnection();
    /// <summary>
    /// Try to close the connection.
    /// </summary>
    /// <returns>Return <c>true</c> if the open's successfully or <c>false</c> if's not.</returns>
    public Task<bool> TryCloseConnection();

    /// <summary>
    /// Create a new database based on the <c>SqlInfo</c>.
    /// ATTENTION: Is recommended made this method async.
    /// </summary>
    /// <param name="sqlInfo">Database info.</param>
    /// <returns>Return the async task.</returns>
    public Task CreateDb(SqlInfo sqlInfo);
    
    /// <summary>
    /// Execute a Sql command.
    /// </summary>
    /// <param name="command">Command to execute.</param>
    /// <returns>Return the task than will return the ammount of rows affected.</returns>
    public Task<int> ExecuteSqlCommand(string command);
    /// <summary>
    /// Execute a Sql command to query the result.
    /// </summary>
    /// <param name="command">Command to execute.</param>
    /// <returns>Return the <c>Task</c> than will return the <c>DataTable to query on.</c></returns>
    public Task<DataTable> ExecuteQueryCommand(string command);
}