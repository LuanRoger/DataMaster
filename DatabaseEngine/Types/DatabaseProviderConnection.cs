using DatabaseEngine.Enums;

namespace DatabaseEngine.Types;

public class DatabaseProviderConnection
{
    public string connectionString { get; init; }
    public DatabaseProvider databaseProvider { get; init; }
}