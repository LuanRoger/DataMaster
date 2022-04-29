using DatabaseEngine.Enums;

#pragma warning disable CS8618

namespace DatabaseEngine.Types;

public class DatabaseProviderConnection
{
    public string connectionString { get; init; }
    public DatabaseProvider databaseProvider { get; init; }
}