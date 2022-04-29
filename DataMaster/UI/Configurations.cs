using System;
using System.Drawing;
using System.Windows.Forms;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using DataMaster.Types;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

public partial class Configurations : Form
{
    public Configurations()
    {
        InitializeComponent();
        cmbLanguages.Items.AddRange(
            new object[]
            {
                "Portugues (Brasil)",
                "English"
            });
    }

    private void Configurations_Load(object sender, EventArgs e)
    {
        txtConnectionString.Text = AppConfigurationManager.configuration.database.connectionString;
            
        txtHighlightColor.Text = AppConfigurationManager.configuration.customizationConfigModel.highlightColor.ToString();
        txtHighlightColor.BackColor = Color.FromArgb(AppConfigurationManager.configuration.customizationConfigModel.highlightColor);
            
        cmbLanguages.SelectedIndex = (int)AppConfigurationManager.configuration.languageConfigModel.langCodeNow;
            
        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
    }

    private void btnClearConnectionString_Click(object sender, EventArgs e) => txtConnectionString.Text = string.Empty;

    private void btnDeleteConnectionHistoric_Click(object sender, EventArgs e) =>
        AppConfigurationManager.configuration.connectionsHistory.historyConnections.Clear();

    private void btnSave_Click(object sender, EventArgs e)
    {
        AppConfigurationManager.configuration.database.connectionString = txtConnectionString.Text;
        AppConfigurationManager.configuration.customizationConfigModel.highlightColor = txtHighlightColor.BackColor.ToArgb();
        AppConfigurationManager.configuration.languageConfigModel.langCodeNow = (LanguageCode)cmbLanguages.SelectedIndex;
            
        AppConfigurationManager.SaveConfig();
        LanguageManager.UpdateLanguage(AppConfigurationManager.configuration.languageConfigModel.langCodeNow);
            
        MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ConfigurationSaved"),
            LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxSuccessTitle"),
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    private void btnChangeHighlight_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new(); 
        DialogResult dialogResult = colorDialog.ShowDialog();
            
        if(dialogResult != DialogResult.OK) return;
            
        txtHighlightColor.Text = colorDialog.Color.ToArgb().ToString();
        txtHighlightColor.BackColor = colorDialog.Color;
    }

    private void Configurations_FormClosed(object sender, FormClosedEventArgs e)
    {
        LanguageManager.RemoveGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
    private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
    {
        Text = LanguageManager.ReturnGlobalizationText("Configuration", "WindowTile");
            
        groupBox1.Text = LanguageManager.ReturnGlobalizationText("Configuration", "GroupboxConnection");
        label1.Text = LanguageManager.ReturnGlobalizationText("Configuration", "LabelConnString");
        btnClearConnectionString.Text = LanguageManager.ReturnGlobalizationText("Configuration",
            "ButtonClearConnString");
        btnDeleteConnectionHistoric.Text = LanguageManager.ReturnGlobalizationText("Configuration",
            "ButtonDeleteConnectionHistoric");
            
        groupBox2.Text = LanguageManager.ReturnGlobalizationText("Configuration", "GroupboxPersonalization");
        label2.Text = LanguageManager.ReturnGlobalizationText("Configuration", "LabelHighlightColor");
            
        label3.Text = LanguageManager.ReturnGlobalizationText("Configuration", "LabelLanguage");
            
        btnSave.Text = LanguageManager.ReturnGlobalizationText("Configuration", "ButtonSave");
    }
}