﻿using DatabaseEngine.Enums;

namespace DataMaster.Managers.Configuration.Sections;

public record DatabaseConfigModel
{
    public string connectionString { get; set; }
    public DatabaseProvider databaseProvider { get; set; }
}