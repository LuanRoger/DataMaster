using System;
using System.Collections.Generic;

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

    public static string CONFIGURATION_FILE = APPLOCAL_FOLDER + "appsettings.json";
        
    public const int SPLASH_SCREEN_TIME = 2000;

    public static readonly List<string> SQL_SINTAX_HIGHLIGHT = new() 
    {
        "ADD",
        "ALTER",
        "ALL",
        "AND",
        "ANY",
        "AS",
        "ASC",
        "BACKUP",
        "BETWEEN",
        "CASE",
        "CHECK",
        "COLUMN",
        "CONSTRAINT",
        "CREATE",
        "REPLACE",
        "DATABASE",
        "DEFAULT",
        "DELETE",
        "DESC",
        "DISTINCT",
        "DROP",
        "EXEC",
        "EXISTS",
        "FOREIGN",
        "KEY",
        "FROM",
        "OUTER",
        "FULL",
        "BY",
        "GROUP",
        "GO",
        "HAVING",
        "IN",
        "INDEX",
        "INNER",
        "INSERT",
        "INTO",
        "IS",
        "NULL",
        "JOIN",
        "LEFT",
        "LIKE",
        "LIMIT",
        "NOT",
        "OR",
        "ORDER",
        "PRIMARY",
        "PROCEDURE",
        "RIGHT",
        "ROWNUM",
        "SELECT",
        "SET",
        "TABLE",
        "TOP",
        "TRUNCATE",
        "UNION",
        "UNIQUE",
        "UPDATE",
        "VALUES",
        "VIEW",
        "WHERE"
    };
    public static readonly List<string> SQL_FILE_EXTENSIONS = new()
    {
        ".sql"
    };
}