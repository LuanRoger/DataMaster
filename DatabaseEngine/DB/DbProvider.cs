using System.Data.Common;

namespace DatabaseEngine.DB;

/// <summary>
/// Represents a database provider.
/// </summary>
/// <typeparam name="T">Driver connection</typeparam>
public abstract class DbProvider<T> where T : DbConnection
{
    protected string connectionString { get; }
    protected T? connection { get; set; }
    
    protected DbProvider(string connectionString)
    {
        this.connectionString = connectionString;
    }
}