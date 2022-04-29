using System;

namespace DataMaster;

public static class Consts
{
    public static readonly string APPLOCAL_FOLDER = 
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\LuanRoger\DataMaster\";

    public static readonly string FILTER_DSM = 
        $"DataMaster SQL Model|*{DatabaseEngineInterpreter.Consts.DSM_FILE_EXTENSION}";
    public const string FILTER_SQL_FILE = "SQL File|*.sql";

    public static string FONTS_FOLDER = APPLOCAL_FOLDER + @"fonts\";
    public static readonly string[] FONTS_DOWNLAOD = 
        { "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf", "Lato-Bold.ttf" };
    public static readonly string FONT_MONTSERRAT_EXTRABOLD = FONTS_FOLDER + FONTS_DOWNLAOD[0];
    public static readonly string FONT_MONTSERRAT_EXTRALIGHT = FONTS_FOLDER + FONTS_DOWNLAOD[1];
    public static readonly string FONT_LATO_BOLD = FONTS_FOLDER + FONTS_DOWNLAOD[2];
    public const string FONT_DOWNLOAD_SERVER = "https://github.com/LuanRoger/DataMaster/raw/main/DataMaster/assets/fonts/";
    
    public const string CONFIG_FILE_NAME = "appsettings.json";
    public static string CONFIGURATION_FILE_PATH = APPLOCAL_FOLDER + CONFIG_FILE_NAME;
    
    public const string LANG_FILE_NAME = "languages.json";
    public static readonly string LANG_STRINGS_FILE = APPLOCAL_FOLDER + LANG_FILE_NAME;
    public const string LANG_FILE_DOWNLOAD_SERVER =
        "https://raw.githubusercontent.com/LuanRoger/DataMaster/main/languages/languages.json";

    public const int SPLASH_SCREEN_TIME = 2000;
}