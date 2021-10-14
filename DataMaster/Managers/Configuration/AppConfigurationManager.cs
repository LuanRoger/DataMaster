using System.Drawing;
using SerializedConfig;
using SerializedConfig.Types.Serialization;

namespace DataMaster.Managers.Configuration
{
    public static class AppConfigurationManager
    {
        private static ConfigurationModel defaultConfig { get; } = new()
        {
          database = new()
          {
              ConnectionString = string.Empty,
          },
          connectionsHistory = new()
          {
              historyConnections = new()
          },
          customizationConfigModel = new()
          {
              highlightColor = Color.CornflowerBlue.ToArgb()
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
}
