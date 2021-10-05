using System;
using System.Collections.Generic;

namespace DataMaster
{
    public static class Consts
    {
        public static readonly string APPLOCAL_FOLDER = 
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\LuanRoger\DataMaster\";

        public static readonly string FILTER_DSM = 
            $"DataMaster SQL Model|*{DatabaseEngineInterpreter.Consts.DSM_FILE_EXTENSION}";
        public static readonly string FILTER_DDU = 
            $"DataMaster Database Updater File|*{DatabaseEngineInterpreter.Consts.DDU_FILE_EXTENSION}";

        public static string FONTS_FOLDER = APPLOCAL_FOLDER + @"font\";
        public static readonly string[] FONTS_DOWNLAOD = 
            { "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
        public static readonly string FONT_MONTSERRAT_EXTRABOLD = FONTS_FOLDER + FONTS_DOWNLAOD[0];
        public static readonly string FONT_MONTSERRAT_EXTRALIGHT = FONTS_FOLDER + FONTS_DOWNLAOD[1];
        public const string FONT_DOWNLOAD_SERVER = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";

        public static string CONFIGURATION_FILE = APPLOCAL_FOLDER + "appsettings.json";
        
        public const int SPLASH_SCREEN_TIME = 2000;
        
        public static readonly List<string> SQL_SINTAX_HIGHLIGHT = new() {"GO", "ADD", "DROP"};
    }
}
