using System.Drawing;
using DataMaster.Types;
using SerializedConfig;
using SerializedConfig.Types.Serialization;

namespace DataMaster.Managers.Configuration;

public static class AppConfigurationManager
{
    private static ConfigurationModel defaultConfig { get; } = new()
    {
        database = new()
        {
            connectionString = string.Empty,
        },
        connectionsHistory = new()
        {
            historyConnections = new()
        },
        customizationConfigModel = new()
        {
            highlightColor = Color.CornflowerBlue.ToArgb()
        },
        languageConfigModel = new()
        {
            langCodeNow = LanguageCode.PT_BR //Default language
        }
    };
        
    private static ConfigManager<ConfigurationModel> configManager { get; } = new(Consts.CONFIGURATION_FILE,
        SerializationFormat.Json, defaultConfig);
    public static ConfigurationModel configuration
    {
        get => configManager.configuration;
    }

    public static void LoadConfig()
    {
        if(!Verifiers.VerifyConfigurationFile(Consts.CONFIGURATION_FILE)) configManager.Save();
            
        configManager.Load();
    }

    public static void SaveConfig() =>
        configManager.Save();
}