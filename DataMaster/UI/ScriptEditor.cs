using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseEngine;
using DataMaster.Managers;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

public partial class ScriptEditor : Form
{
    private string? filePath { get; }
    private string? fileExtension { get; set; }

    public ScriptEditor(string? filePath = null)
    {
        InitializeComponent();
            
        this.filePath = filePath;
    }
    private void ScriptEditor_Load(object sender, EventArgs e)
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
            
        lblScriptLang.Text = txtScriptCommand.languageHighlight.ToString();

        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
        
    private void LoadFileText()
    {
        txtScriptCommand.Text = File.ReadAllText(filePath!);
        fileExtension = Path.GetExtension(filePath);
        txtScriptCommand.SetSyntaxByExtension(fileExtension);
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
        try
        {
            if(!await DbConnectionManager.TestConnection(false))
            {
                MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "NoConnectionString"),
                    LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   
        }
        catch(Exception exception)
        {
            MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ErrorOccurs") + exception.Message,
                LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        ShowCommandResult(await DbConnectionManager.currentProvider!.ExecuteQueryCommand(txtScriptCommand.Text));
    }
    private void ShowCommandResult(DataTable scriptResult)
    {
        dgvQuery.DataSource = scriptResult;
            
        if(Verifiers.VerifyDataTable(scriptResult)) tabControl1.SelectedTab = tbpQuery;
    }
    
    #region ProgressBar
    private void ShowPgb()
    {
        pgbAsyncTask.Visible = true;
        txtScriptCommand.Enabled = false;
    }
    private void HidePgb()
    {
        pgbAsyncTask.Visible = false;
        txtScriptCommand.Enabled = true;
    }
    #endregion

    private void ScriptEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
        LanguageManager.RemoveGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
    private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
    {
        Text = LanguageManager.ReturnGlobalizationText("ScriptEditor", "WindowTile");
            
        tabControl1.TabPages[0].Text = LanguageManager.ReturnGlobalizationText("ScriptEditor", "TabLabel0");
        tabControl1.TabPages[1].Text = LanguageManager.ReturnGlobalizationText("ScriptEditor", "TabLabel1");
    }
}