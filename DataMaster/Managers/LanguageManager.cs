using System.Collections.Generic;
using DataMaster.Strings;
using DataMaster.Types;
using GlobalStrings.Globalization;
using GlobalStrings.Types;

namespace DataMaster.Managers
{
    public static class LanguageManager
    {
        private static Globalization<LanguageCode, string, string> globalization { get; set; }
        private static List<LanguageInfo<LanguageCode, string, string>> languageInfos { get; } = new();

        public static void InitLanguages(LanguageCode initialLang = LanguageCode.PT_BR)
        {
            PtBr ptBr = new();
            EnUs enUs = new();
            
            ptBr.InitLanguage();
            enUs.InitLanguage();
            
            languageInfos.Add(ptBr.language);
            languageInfos.Add(enUs.language);
            
            globalization = new(languageInfos, initialLang);
            StartGlobalization();
        }
        
        public static void SetGlobalizationObserver(Globalization<LanguageCode, string, string>.LangTextObserverEventHandler
            langTextObserverEventHandler)
        {
            globalization.LangTextObserver += langTextObserverEventHandler;
            SyncLanguage();
        }
        
        public static string ReturnGlobalizationText(string collectionCode, string key) => 
            globalization.SetText(collectionCode, key);

        public static void UpdateLanguage(LanguageCode langCode) => globalization.UpdateLang(langCode);
        private static void SyncLanguage() => globalization.SyncStrings();
        private static void StartGlobalization() => globalization.StartGlobalization();
    }
}