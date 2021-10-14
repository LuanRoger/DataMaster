using System;
using System.Drawing;
using System.Windows.Forms;
using DataMaster.Managers.Configuration;

namespace DataMaster.UI
{
    public partial class Configurations : Form
    {
        public Configurations()
        {
            InitializeComponent();
        }

        private void Configurations_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = AppConfigurationManager.configuration.database.ConnectionString;
            
            txtHighlightColor.Text = AppConfigurationManager.configuration.customizationConfigModel.highlightColor.ToString();
            txtHighlightColor.BackColor = Color.FromArgb(AppConfigurationManager.configuration.customizationConfigModel.highlightColor);
        }

        private void btnClearConnectionString_Click(object sender, EventArgs e) => txtConnectionString.Text = string.Empty;

        private void btnDeleteConnectionHistoric_Click(object sender, EventArgs e) =>
            AppConfigurationManager.configuration.connectionsHistory.historyConnections.Clear();

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
            {
                ConnectionString = txtConnectionString.Text
            };
            AppConfigurationManager.configuration.customizationConfigModel = AppConfigurationManager.configuration.customizationConfigModel with
            {
                highlightColor = txtHighlightColor.BackColor.ToArgb()
            };
            
            AppConfigurationManager.SaveConfig();
            
            MessageBox.Show("Configurações salvas", "Sucesso",
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
    }
}
