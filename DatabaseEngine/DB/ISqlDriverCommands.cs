using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataTable = System.Data.DataTable;

namespace DatabaseEngine.DB;

public interface ISqlDriverCommands
{
    public Task<bool> TryOpenConnection();
    public Task<bool> TryCloseConnection();

    //Async
    public Task CreateDb(SqlInfo sqlInfo);

    public Task<int> ExecuteSqlCommand(string command);
    public Task<DataTable> ExecuteQueryCommand(string command);
}