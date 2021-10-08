﻿using System;
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
        
        public static readonly List<string> SQL_SINTAX_HIGHLIGHT = new() 
            {
                "ADD",
                "ADD CONSTRAINT",
                "ALTER",
                "ALTER COLUMN",
                "ALTER TABLE",
                "ALL",
                "AND",
                "ANY",
                "AS",
                "ASC",
                "BACKUP DATABASE",
                "BETWEEN",
                "CASE",
                "CHECK",
                "COLUMN",
                "CONSTRAINT",
                "CREATE",
                "CREATE DATABASE",
                "CREATE INDEX",
                "REPLACE VIEW",
                "CREATE OR REPLACE VIEW",
                "CREATE TABLE",
                "CREATE PROCEDURE",
                "CREATE UNIQUE INDEX",
                "CREATE VIEW",
                "DATABASE",
                "DEFAULT",
                "DELETE",
                "DESC",
                "DISTINCT",
                "DROP",
                "DROP COLUMN",
                "DROP CONSTRAINT",
                "DROP DATABASE",
                "DROP DEFAULT",
                "DROP INDEX",
                "DROP TABLE",
                "DROP VIEW",
                "EXEC",
                "EXISTS",
                "FOREIGN KEY",
                "FROM",
                "FULL OUTER JOIN",
                "GROUP BY",
                "GO",
                "HAVING",
                "IN",
                "INDEX",
                "INNER JOIN",
                "INSERT INTO",
                "INSERT INTO SELECT",
                "IS NULL",
                "IS NOT NULL",
                "JOIN",
                "LEFT JOIN",
                "LIKE",
                "LIMIT",
                "NOT",
                "NOT NULL",
                "OR",
                "ORDER BY",
                "OUTER JOIN",
                "PRIMARY KEY",
                "PROCEDURE",
                "RIGHT JOIN",
                "ROWNUM",
                "SELECT",
                "SELECT DISTINCT",
                "SELECT INTO",
                "SELECT TOP",
                "SET",
                "TABLE",
                "TOP",
                "TRUNCATE TABLE",
                "UNION",
                "UNION ALL",
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
}
