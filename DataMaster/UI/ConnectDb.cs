using System;
using DataMaster.Types;
using System.Windows.Forms;
using DatabaseEngine;
using DatabaseEngine.Enums;
using DataMaster.Exceptions;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using DataMaster.Util;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

public partial class ConnectDb : Form
{
    public ConnectDb()
    {
        InitializeComponent();
    }

    private ConnStringBuilder? buildedConnString
    {
        get
        {
            ConnStringBuilder connStringBuilder;
            try
            {
                connStringBuilder = BuildConnectionString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
            return connStringBuilder;
        }
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
        if(buildedConnString == null)
            return;
        
        if(!AppConfigurationManager.configuration.connectionsHistory.historyConnections
               .Exists(server => server == cmbServerName.Text))
            AppConfigurationManager.configuration.connectionsHistory.historyConnections.Add(cmbServerName.Text);
            
        DbConnectionManager.databaseProviderConnection = new()
        {
            connectionString = buildedConnString.connectionString,
            databaseProvider = DatabaseProvider.SqlServer
        };
        AppConfigurationManager.configuration.database = new()
        {
            connectionString = buildedConnString.connectionString,
            databaseProvider =  DatabaseProvider.SqlServer
        };
        AppConfigurationManager.SaveConfig();
            
        Close();
    }
    private async void btnTestarConexao_Click(object sender, EventArgs e)
    {
        if(buildedConnString == null)
            return;
        DbConnectionManager.databaseProviderConnection = new()
        {
            connectionString = buildedConnString.connectionString,
            databaseProvider = DatabaseProvider.SqlServer
        };
        
        if(await DbConnectionManager.TestConnection())
            MessageBox.Show("Conexão estabelecida com sucesso", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        else MessageBox.Show("Não foi possivel estabelecer uma conexão com o banco de dados informado", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    private ConnStringBuilder BuildConnectionString()
    {
        AuthTypes authType = cmbServerType.SelectedIndex switch
        {
            0 => AuthTypes.WinAuth,
            1 => AuthTypes.SqlSAuth,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        ConnStringBuilder connStringBuilder = new();
        connStringBuilder.connectionServer = cmbServerName.Text;
            
        if(!string.IsNullOrEmpty(txtNameDb.Text)) connStringBuilder.connectionDatabase = txtNameDb.Text;
            
        if(authType == AuthTypes.SqlSAuth)
        {
            if(string.IsNullOrEmpty(txtUserName.Text) && 
               string.IsNullOrEmpty(txtPassword.Text))
                throw new AuthenticationInformationException("SQL", "username","password");
            
            connStringBuilder.userId = txtUserName.Text;
            connStringBuilder.password = txtPassword.Text;
        }
        else connStringBuilder.trustedConnection = true;
        
        return connStringBuilder;
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