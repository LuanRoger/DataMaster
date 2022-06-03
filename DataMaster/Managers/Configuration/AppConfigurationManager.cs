using System.Drawing;
using System.Threading.Tasks;
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
        
    private static ConfigManager<ConfigurationModel> configManager { get; } = new(Consts.CONFIGURATION_FILE_PATH,
        SerializationFormat.Json, defaultConfig);
    public static ConfigurationModel configuration => configManager.configuration;

    public static async Task LoadConfig()
    {
        if(!Verifiers.CheckFile(Consts.CONFIGURATION_FILE_PATH)) await configManager.SaveAsync();
            
        await configManager.LoadAsync();
    }

    public static void SaveConfig() =>
        configManager.Save();
}