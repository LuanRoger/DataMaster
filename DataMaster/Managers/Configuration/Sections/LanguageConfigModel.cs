using DataMaster.Types;
using SerializedConfig.SectionsAtribute;

namespace DataMaster.Managers.Configuration.Sections;

[SectionClass]
public record LanguageConfigModel
{
    public LanguageCode langCodeNow { get; set; }
}