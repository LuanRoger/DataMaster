using DataMaster.Managers.Configuration.Sections;
using SerializedConfig.SectionsAttribute;
using SerializedConfig.Types.Model;

#pragma warning disable CS8618

namespace DataMaster.Managers.Configuration;

[ConfigSection]
public class ConfigurationModel : IConfigurationModel
{
    public DatabaseConfigModel database { get; set; }
    public DatabaseConnectionsHistory connectionsHistory { get; set; }
    public CustomizationConfigModel customizationConfigModel { get; set; }
    public LanguageConfigModel languageConfigModel { get; set; }
}