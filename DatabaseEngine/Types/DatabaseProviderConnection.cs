using DatabaseEngine.Enums;

namespace DatabaseEngine.Types;

public class DatabaseProviderConnection
{
    public string connectionString { get; set; }
    public DatabaseProvider databaseProvider { get; set; }
}