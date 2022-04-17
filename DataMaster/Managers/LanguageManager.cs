using DataMaster.Types;
using GlobalStrings.Globalization;

namespace DataMaster.Managers;

public static class LanguageManager
{
    private static Globalization<LanguageCode, string, string> globalization { get; set; } = null!;

    public static void InitLanguages(LanguageCode initialLang = LanguageCode.PT_BR)
    {
        if(!Verifiers.CheckFile(Consts.LANG_STRINGS_FILE))
            throw new($"There is no language file in {Consts.LANG_STRINGS_FILE}");
        
        globalization = new(Consts.LANG_STRINGS_FILE, initialLang);
        globalization.StartGlobalization();
    }

    public static void SetGlobalizationObserver(Globalization<LanguageCode, string, string>.LangTextObserverEventHandler
        langTextObserverEventHandler)
    {
        globalization.LangTextObserver += langTextObserverEventHandler;
        globalization.SyncStrings();
    }
    public static void RemoveGlobalizationObserver(Globalization<LanguageCode, string, string>.LangTextObserverEventHandler
        langTextObserverEventHandler)
    {
        globalization.LangTextObserver -= langTextObserverEventHandler;
    }
        
    public static string ReturnGlobalizationText(string collectionCode, string key) => 
        globalization.SetText(collectionCode, key);

    public static void UpdateLanguage(LanguageCode langCode) => globalization.UpdateLang(langCode);
}