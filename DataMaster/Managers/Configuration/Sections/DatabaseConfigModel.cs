using DatabaseEngine.Enums;

#pragma warning disable CS8618

namespace DataMaster.Managers.Configuration.Sections;

public class DatabaseConfigModel
{
    public string connectionString { get; set; }
    public DatabaseProvider databaseProvider { get; set; }
}