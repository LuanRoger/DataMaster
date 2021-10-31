using DataMaster.Types;
using GlobalStrings;

namespace DataMaster.Strings
{
    public interface ILanguage
    {
        LanguageInfo<LanguageCode, string, string> language { get; }

        void InitLanguage();
    }
}