using DataMaster.Types;
using SerializedConfig.SectionsAttribute;

namespace DataMaster.Managers.Configuration.Sections;

[ConfigSection]
public class LanguageConfigModel
{
    public LanguageCode langCodeNow { get; set; }
}