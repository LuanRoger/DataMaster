namespace DatabaseEngine.DB;

/// <summary>
/// Represents a database provider.
/// </summary>
/// <typeparam name="T">Driver connection</typeparam>
public abstract class IDbProvider<T>
{
    protected IDbProvider(string connectionString)
    {
        this.connectionString = connectionString;
    }
    
    protected internal string connectionString { get; set; }
    protected T connection { get; set; }
}