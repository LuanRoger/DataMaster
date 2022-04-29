using System;
using System.Windows.Forms;
using DatabaseEngine;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

public partial class Home : Form
{
    public Home()
    {
        InitializeComponent();
    }

    #region ToolbarClickEvents
    private void SetMenuClick()
    {
        mnuConexao.Click += (_, _) =>
        {
            ConnectDb connectDb = new();
            connectDb.Show();
        };

        mnuCreateDb.Click += (_, _) =>
        {
            CreateDb createDb = new();
            createDb.Show();
        };
        mnuLaodModel.Click += (_, _) => 
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = Consts.FILTER_DSM,
                Multiselect = false
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if(dialogResult != DialogResult.OK) return;

            CreateDb createDb = new(openFileDialog.FileName);
            createDb.Show();
        };
            
        mnuCreateScript.Click += (_, _) =>
        {
            ScriptEditor scriptEditor = new();
            scriptEditor.Show();
        };
        mnuLoadScript.Click += (_, _) =>
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = Consts.FILTER_SQL_FILE,
                Multiselect = false
            };
                
            DialogResult dialogResult = openFileDialog.ShowDialog();
                
            if(dialogResult != DialogResult.OK) return;
                
            ScriptEditor scriptEditor = new(openFileDialog.FileName);
            scriptEditor.Show();
        };
            
        mnuConfiguration.Click += (_, _) =>
        {
            Configurations configurations = new();
            configurations.Show();
        };

        mnuAbout.Click += (_, _) =>
        {
            About about = new();
            about.Show();
        };
    }
    private void SetClickShortcuts()
    {
        ACriarScript.Click += (_, _) => mnuCreateScript.PerformClick();
        ACreateDb.Click += (_, _) => mnuCreateDb.PerformClick();
    }
    #endregion

    private void Home_Load(object sender, EventArgs e)
    {
        ShowInTaskbar = false;
        Opacity = 0;

        SplashScreen splashScreen = new();
        splashScreen.Show();
        splashScreen.FormClosed += SplashScreenOnFormClosed;
    }
    /// <summary>
    /// Init the Home window when the SplashScreen has finish.
    /// </summary>
    private void SplashScreenOnFormClosed(object? sender, FormClosedEventArgs e)
    {
        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
        SetMenuClick();
        SetClickShortcuts();
            
        ShowInTaskbar = true;
        Opacity = 100;
        BringToFront();
        ((Form)sender!).FormClosed -= SplashScreenOnFormClosed;
    }

    private void timer1_Tick(object sender, EventArgs e) => lblTempo.Text = DateTime.Now.ToString();

    private void Home_Activated(object sender, EventArgs e)
    {
        lblConnString.Text = string.IsNullOrEmpty(AppConfigurationManager.configuration.database.connectionString) ? 
            LanguageManager.ReturnGlobalizationText("Home", "LabelConnectionStatus") :
            AppConfigurationManager.configuration.database.connectionString;
    }
    
    private async void btnTestConn_Click(object sender, EventArgs e)
    {
        ShowPgb();
        try
        {
            if(await DbConnectionManager.TestConnection())
                MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ConncetionEstablished"),
                    LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxSuccessTitle"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "UnableToConnectDatabase"), 
                LanguageManager.ReturnGlobalizationText("MessageBox", "UnableToConnectDatabase"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);   
        }
        catch(Exception exception)
        {
            MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ErrorOccurs") + exception.Message,
                LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        HidePgb();
    }

    #region ProgressBar
    private void ShowPgb() => pgbAsyncTask.Visible = true;
    private void HidePgb() => pgbAsyncTask.Visible = false;
    #endregion

    private void Home_FormClosed(object sender, FormClosedEventArgs e)
    {
        LanguageManager.RemoveGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
    private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
    {
        mnuConexao.Text = LanguageManager.ReturnGlobalizationText("Home", "MenubarConnect");
            
        mnuDatabase.Text = LanguageManager.ReturnGlobalizationText("Home", "MenubarDatabase");
        mnuCreateDb.Text = LanguageManager.ReturnGlobalizationText("Home", "SmuCreateDb");
        mnuLaodModel.Text = LanguageManager.ReturnGlobalizationText("Home", "SmuLoadModel");
            
        mnuScript.Text = LanguageManager.ReturnGlobalizationText("Home", "MenubarScript");
        mnuCreateScript.Text = LanguageManager.ReturnGlobalizationText("Home", "SmuCreateScript");
        mnuLoadScript.Text = LanguageManager.ReturnGlobalizationText("Home", "SmuLoadScript");
            
        mnuConfiguration.Text = LanguageManager.ReturnGlobalizationText("Home", "MenubarConfig");
        mnuAbout.Text = LanguageManager.ReturnGlobalizationText("Home", "MenubarAbout");
    }
}