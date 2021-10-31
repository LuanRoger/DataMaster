using DataMaster.Types;
using GlobalStrings;

namespace DataMaster.Strings
{
    public class Pt_Br : ILanguage
    {
        public LanguageInfo<LanguageCode, string, string> language { get; private set;}
        
        public void InitLanguage()
        {
            language = new(LanguageCode.PT_BR, new()
            {
                {"Home", new()
                {
                    {"MenubarConnect", "Conectar"},
                    {"MenubarDatabase", "Banco de dados"},
                    {"MenubarScript", "Script"},
                    {"MenubarConfig", "Configurações"},
                    {"MenubarAbout", "Sobre"},
                    {"LabelConnectionStatus", "Nenhuma string de conexão definida"}
                }},
                {"ConnectDb", new()
                {
                    {"WindowTile", "Conectar"},
                    {"LabelServerName", "Nome do servidor"},
                    {"LabelDatabaseName", "Nome do banco de dados"},
                    {"LabelAuth", "Autenticação"},
                    {"GroupboxAuthInfo", "Informações de autenticação"},
                    {"LabelAuthUsername", "Nome de usuário"},
                    {"LabelAuthPassword", "Senha"},
                    {"ButtonConnectionTest", "Testar conexão"},
                    {"ButtonSave", "Salvar"}
                }},
                {"CreateDb", new()
                {
                    {"WindowTile", "Criar banco de dados"},
                    {"ButtonAddDb", "Adicionar banco"},
                    {"ButtonAddTable", "Adicionar tabela"},
                    {"ButtonDeleteElement", "Excluir elemento"},
                    {"GroupboxInfo", "Informações"},
                    {"LabelAmountDb", "Quantidade de bancos:"},
                    {"LabelAmuntTable", "Quantidade de tabelas:"},
                    {"ButtonSaveModel", "Salvar modelo"},
                    {"ButtonCreateDb", "Criar banco"}
                }},
                {"CreateTable", new()
                {
                    {"WindowTile", "Criar tabela"},
                    {"LabelColumnName", "Nome da coluna:"},
                    {"LabelDataType", "Tipo de dado:"},
                    {"CheckboxAllowNull", "Permitir NULL"},
                    {"CheckboxHasKey", "Chave"},
                    {"ButtonAddTable", "Adicionar"},
                    {"ButtonRemoveTable", "Remover"},
                    {"ButtonCancel", "Cancelar"},
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
                    {"WindowTile", "Configurações"},
                    {"GroupboxConnection", "Conexão"},
                    {"LabelConnString", "String de conexão"},
                    {"ButtonClearConnString", "Limpar string de conexão"},
                    {"ButtonDeleteConnectionHistoric", "Excluir hsitórico de conexão"},
                    {"GroupboxPersonalization", "Personalização"},
                    {"LabelHighlightColor", "Cor de destaque do editor"},
                    {"LabelLanguage", "Idioma"}
                }},
                {"About", new()
                {
                    {"WindowTile", "Sobre"},
                    {"LabelWallpaper", "Papel de parede: pikisuperstar e Freepik"}
                }}
            });
        }
    }
}