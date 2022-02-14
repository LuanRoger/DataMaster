using DataMaster.Types;
using GlobalStrings.Types;

namespace DataMaster.Strings
{
    public class EnUs : ILanguage
    {
        public LanguageInfo<LanguageCode, string, string> language { get; private set; }

        public void InitLanguage()
        {
            language = new(LanguageCode.EN_US, new()
            {
                {"Home", new()
                {
                    {"MenubarConnect", "Connect"},
                    {"MenubarDatabase", "Database"},
                    {"SmuCreateDb", "Create database"},
                    {"SmuLoadModel", "Load model..."},
                    {"MenubarScript", "Script"},
                    {"SmuCreateScript", "Create new script"},
                    {"SmuLoadScript", "Load script..."},
                    {"MenubarConfig", "Configurations"},
                    {"MenubarAbout", "About"},
                    {"LabelConnectionStatus", "No connection string"}
                }},
                {"ConnectDb", new()
                {
                    {"WindowTile", "Connect"},
                    {"LabelServerName", "Server name:"},
                    {"LabelDatabaseName", "Database name:"},
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
                    {"ButtonAddDb", "Add database"},
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
                    {"ButtonAddColumn", "Add"},
                    {"ButtonRemoveColumn", "Remove"},
                    {"ButtonOk", "OK"},
                    {"ButtonCancel", "Cancel"}
                }},
                {"ScriptEditor", new()
                {
                    {"WindowTile", "Script editor"},
                    {"TabLabel0", "Script"},
                    {"TabLabel1", "Query"},
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
                    {"LabelLanguage", "Language:"},
                    {"ButtonSave", "Save"}
                }},
                {"About", new()
                {
                    {"WindowTile", "About"},
                    {"LabelWallpaper", "Wallpaper: pikisuperstar e Freepik"},
                    { "Creator", "Luan Roger© 2022" },
                    { "License", "GNU General Public License v3.0" }
                }
                }
            });
        }
    }
}