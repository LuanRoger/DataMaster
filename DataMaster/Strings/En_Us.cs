using DataMaster.Types;
using GlobalStrings;

namespace DataMaster.Strings
{
    public class En_Us : ILanguage
    {
        public LanguageInfo<LanguageCode, string, string> language { get; private set; }

        public void InitLanguage()
        {
            language = new(LanguageCode.PT_BR, new()
            {
                {"Home", new()
                {
                    {"MenubarConnect", "Connect"},
                    {"MenubarDatabase", "Database"},
                    {"MenubarScript", "Script"},
                    {"MenubarConfig", "Configurations"},
                    {"MenubarAbout", "About"},
                    {"LabelConnectionStatus", "No connection string"}
                }},
                {"ConnectDb", new()
                {
                    {"WindowTile", "Connect"},
                    {"LabelServerName", "Server name"},
                    {"LabelDatabaseName", "Database name"},
                    {"LabelAuth", "Auth"},
                    {"GroupboxAuthInfo", "Auth info"},
                    {"LabelAuthUsername", "Username"},
                    {"LabelAuthPassword", "Password"},
                    {"ButtonConnectionTest", "Test connection"},
                    {"ButtonSave", "Save"}
                }},
                {"CreateDb", new()
                {
                    {"WindowTile", "Create database"},
                    {"ButtonAddDb", "Add DB"},
                    {"ButtonAddTable", "Add table"},
                    {"ButtonDeleteElement", "Delete element"},
                    {"GroupboxInfo", "Informations"},
                    {"LabelAmountDb", "Database amount:"},
                    {"LabelAmuntTable", "Table amount:"},
                    {"ButtonSaveModel", "Save model"},
                    {"ButtonCreateDb", "Create DB"}
                }},
                {"CreateTable", new()
                {
                    {"WindowTile", "Create table"},
                    {"LabelColumnName", "Column name:"},
                    {"LabelDataType", "Data type:"},
                    {"CheckboxAllowNull", "Allow NULL"},
                    {"CheckboxHasKey", "Key"},
                    {"ButtonAddTable", "Add"},
                    {"ButtonRemoveTable", "Remove"},
                    {"ButtonCancel", "Cancel"},
                    {"ButtonOk", "OK"}
                }},
                {"ScriptEditor", new()
                {
                    {"WindowTile", "Script editor"},
                    {"TabLabel1", "Script"},
                    {"TabLabel2", "Query"},
                }},
                {"Configuration", new()
                {
                    {"WindowTile", "Configuration"},
                    {"GroupboxConnection", "Connection"},
                    {"LabelConnString", "Connection string"},
                    {"ButtonClearConnString", "Clear connection string"},
                    {"ButtonDeleteConnectionHistoric", "Delete connection historic"},
                    {"GroupboxPersonalization", "Personalization"},
                    {"LabelHighlightColor", "Highlight color"},
                    {"LabelLanguage", "Language"}
                }},
                {"About", new()
                {
                    {"WindowTile", "About"},
                    {"LabelWallpaper", "Wallpaper: pikisuperstar e Freepik"}
                }}
            });
        }
    }
}