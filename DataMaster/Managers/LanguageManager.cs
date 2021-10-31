using System.Collections.Generic;
using DataMaster.Strings;
using DataMaster.Types;
using GlobalStrings;
using GlobalStrings.Globalization;

namespace DataMaster.Managers
{
    public static class LanguageManager
    {
        private static Globalization<LanguageCode, string, string> globalization { get; set; }
        private static List<LanguageInfo<LanguageCode, string, string>> languageInfos { get; set; } = new();

        public static void InitLanguages(LanguageCode initialLang = LanguageCode.PT_BR)
        {
            Pt_Br ptBr = new();
            En_Us enUs = new();
            
            ptBr.InitLanguage();
            enUs.InitLanguage();
            
            languageInfos.Add(ptBr.language);
            languageInfos.Add(enUs.language);
            
            globalization = new(languageInfos, initialLang);
        }
        
        public static void SetGlobalizationObserver(Globalization<LanguageCode, string, string>.LangTextObserverEventHandler
            langTextObserverEventHandler) => globalization.LangTextObserver += langTextObserverEventHandler;
        
        public static void UpdateLanguage(LanguageCode langCode) => globalization.UpdateLang(langCode);
        public static void StartGlobalization() => globalization.StartGlobalization();
    }
}