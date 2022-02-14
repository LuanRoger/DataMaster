using System;
using System.Data;
using DataMaster.Types;
using System.Windows.Forms;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using DataMaster.Util;
using GlobalStrings.EventArguments;

namespace DataMaster.UI
{
    public partial class ConnectDb : Form
    {
        public ConnectDb()
        {
            InitializeComponent();
        }
        
        private void ConnectDb_Load(object sender, EventArgs e)
        {
            cmbServerType.SelectedIndex = 0;
            foreach (string connection in AppConfigurationManager.configuration.connectionsHistory.historyConnections)
                cmbServerName.Items.Add(connection);
            
            LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
        }
        
        private void cmbServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gpbInfoUser.Enabled = cmbServerType.SelectedIndex == 1;
        }
        
        private void btnConnectDb_Click(object sender, EventArgs e)
        {
            AuthTypes authType = cmbServerType.SelectedIndex switch
            {
                0 => AuthTypes.WinAuth,
                1 => AuthTypes.SqlSAuth,
                _ => throw new ArgumentOutOfRangeException()
            };

            ConnStringBuilder.connectionServer = cmbServerName.Text;
            if(!string.IsNullOrEmpty(txtNameDb.Text)) ConnStringBuilder.connectionDatabase = txtNameDb.Text;
            
            if(authType == AuthTypes.SqlSAuth)
            {
                if(string.IsNullOrEmpty(txtNameDb.Text) && 
                   string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Este tipo de autenticação requer que informe um usuario e senha", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ConnStringBuilder.userId = txtNameDb.Text;
                ConnStringBuilder.password = txtPassword.Text;
            }
            else ConnStringBuilder.trustedConnection = true;

            DbConnectionManager.authenticationType = authType;
            if(!AppConfigurationManager.configuration.connectionsHistory.historyConnections
                .Exists(server => server == cmbServerName.Text))
                AppConfigurationManager.configuration.connectionsHistory.historyConnections.Add(cmbServerName.Text);
            
            DbConnectionManager.SaveConnStringByConnStringBuilder();
            
            Close();
        }
        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            if(Verifiers.VerifyConnectionString() == ConnectionState.Open)
            {
                MessageBox.Show("Conexão bem sucedida", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possivel estabelecer uma conexão com o banco", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            btnTestConnection.Size = updatemodeeventargs.lang switch
            {
                  LanguageCode.PT_BR => new(109, 23),
                  LanguageCode.EN_US => new(115, 23)
            };
            
            Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "WindowTile");
            label1.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelServerName");
            
            label5.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelDatabaseName");
            
            label2.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelAuth");
            
            gpbInfoUser.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "GroupboxAuthInfo");
            label3.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelAuthUsername");
            label4.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelAuthPassword");
            
            btnConnectDb.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "ButtonSave");
            btnTestConnection.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "ButtonConnectionTest");
        }
    }
}
