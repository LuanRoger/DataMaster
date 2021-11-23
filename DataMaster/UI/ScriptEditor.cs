using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMaster.DB.SQLServer.SqlPure;
using DataMaster.Managers;
using GlobalStrings.EventArguments;

namespace DataMaster.UI
{
    public partial class ScriptEditor : Form
    {
        private string? filePath { get; }
        private string? fileExtension { get; set; }

        public ScriptEditor(string filePath = null)
        {
            InitializeComponent();
            
            this.filePath = filePath;
        }
        private void ScriptEditor_Load(object sender, System.EventArgs e)
        {
            #region mnuClick
                btnExecuteCommand.Click += async (_, _) =>
                {
                    ShowPgb();
                    await ExecuteScript();
                    HidePgb();
                };
                btnSaveScript.Click += async (_, _) =>
                {
                    ShowPgb();
                    await SaveSqlFile();
                    HidePgb();
                };
            #endregion
            
            if(!string.IsNullOrEmpty(filePath)) LoadFileText();
            
            lblScriptLang.Text = txtScriptCommand.languageSyntax;

            LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
        }
        
        private void LoadFileText()
        {
            txtScriptCommand.Text = File.ReadAllText(filePath!);
            fileExtension = Path.GetExtension(filePath);
            txtScriptCommand.SetSyntax(fileExtension);
        }
        
        private void ShowCommandResult(System.Data.DataTable scriptResult)
        {
            dgvQuery.DataSource = scriptResult;
            
            if(Verifiers.VerifyDataTable(scriptResult)) tabControl1.SelectedTab = tbpQuery;
        }
        private async Task SaveSqlFile()
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = Consts.FILTER_SQL_FILE;
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            
            if(dialogResult != DialogResult.OK) return;
            
            await File.WriteAllTextAsync(saveFileDialog.FileName, txtScriptCommand.Text);
        }
        private async Task ExecuteScript()
        {
            if(Verifiers.VerifyConnectionString() != ConnectionState.Open)
            {
                MessageBox.Show("Não há uma string de conexão criada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowCommandResult(await SqlServerConnectionPure.ExecuteSqlCommand(txtScriptCommand.Text));
        }
        
        private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            Text = LanguageManager.ReturnGlobalizationText("ScriptEditor", "WindowTile");
            
            tabControl1.TabPages[0].Text = LanguageManager.ReturnGlobalizationText("ScriptEditor", "TabLabel0");
            tabControl1.TabPages[1].Text = LanguageManager.ReturnGlobalizationText("ScriptEditor", "TabLabel1");
        }
        
        #region ProgressBar
            private void ShowPgb() => pgbAsyncTask.Visible = true;
            private void HidePgb() => pgbAsyncTask.Visible = false;
        #endregion
    }
}
