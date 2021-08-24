using System;
using System.Data;
using DataMaster.Types;
using System.Windows.Forms;
using DataMaster.DB.SQLServer.SqlPure;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using DataMaster.Util;

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
            AppConfigurationManager.configuration.connectionsHistory.historyConnections.Add(cmbServerName.Text);
            DbConnectionManager.SaveConnString();
            
            Close();
        }
        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            ConnectionState connectionState;
            if(!string.IsNullOrEmpty(cmbServerName.Text) && string.IsNullOrEmpty(txtNameDb.Text)) 
                connectionState = SqlServerConnectionPure.TestPseudoConnection(cmbServerName.Text);
            else connectionState = SqlServerConnectionPure.TestPseudoConnection(cmbServerName.Text, txtNameDb.Text);
            
            if(connectionState == ConnectionState.Open)
            {
                MessageBox.Show("Conexão bem sucedida", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
