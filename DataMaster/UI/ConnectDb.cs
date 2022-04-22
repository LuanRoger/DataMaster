using System;
using DataMaster.Types;
using System.Windows.Forms;
using DatabaseEngine;
using DatabaseEngine.Enums;
using DataMaster.Exceptions;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using DataMaster.Util.ConnStringBuilder;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

#pragma warning disable CS8509

public partial class ConnectDb : Form
{
    private DatabaseProvider providerByIndex =>
        tbcProviderConnection.SelectedIndex switch
        {
            0 => DatabaseProvider.SqlServer,
            1 => DatabaseProvider.Sqlite
        };

    private IConnStringBuilder? buildedConnString
    {
        get
        {
            IConnStringBuilder connStringBuilderSqlServer;
            try
            {
                connStringBuilderSqlServer = BuildConnectionString();
            }
            catch(Exception exception)
            {
                MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ErrorOccurs") + exception.Message, 
                    LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
            return connStringBuilderSqlServer;
        }
    }
    
    public ConnectDb()
    {
        InitializeComponent();
    }

    private void ConnectDb_Load(object sender, EventArgs e)
    {
        foreach (string connection in AppConfigurationManager.configuration.connectionsHistory.historyConnections)
            cmbServerNameSqlServer.Items.Add(connection);
            
        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
        
        cmbAuthTypeSqlServer.Items.AddRange(new object[]
        {
            LanguageManager.ReturnGlobalizationText("ConnectDb", "CmbItemWinAuth"),
            LanguageManager.ReturnGlobalizationText("ConnectDb", "CmbItemSqlServerAuth")
        });
        cmbAuthTypeSqlServer.SelectedIndex = 0;
    }

    private void btnConnectDb_Click(object sender, EventArgs e)
    {
        if(buildedConnString is null) return;
        
        if(!AppConfigurationManager.configuration.connectionsHistory.historyConnections
               .Exists(server => server == cmbServerNameSqlServer.Text))
            AppConfigurationManager.configuration.connectionsHistory.historyConnections.Add(cmbServerNameSqlServer.Text);
            
        DbConnectionManager.databaseProviderConnection = new()
        {
            connectionString = buildedConnString.connectionString,
            databaseProvider = providerByIndex
        };
        AppConfigurationManager.configuration.database = new()
        {
            connectionString = buildedConnString.connectionString,
            databaseProvider =  providerByIndex
        };
        AppConfigurationManager.SaveConfig();
            
        Close();
    }
    private async void btnTestConnection_Click(object sender, EventArgs e)
    {
        if(buildedConnString == null)
            return;
        DbConnectionManager.databaseProviderConnection = new()
        {
            connectionString = buildedConnString.connectionString,
            databaseProvider = DatabaseProvider.SqlServer
        };
        
        if(await DbConnectionManager.TestConnection())
            MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ConncetionEstablished"),
                LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxSuccessTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        else MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "UnableToConnectDatabase"), 
            LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    private void cmbServerType_SelectedIndexChanged(object sender, EventArgs e)
    {
        gpbInfoUser.Enabled = cmbAuthTypeSqlServer.SelectedIndex == 1;
    }

    private IConnStringBuilder BuildConnectionString()
    {
        return providerByIndex switch
        {
            DatabaseProvider.SqlServer => BuildSqlServerString(),
            DatabaseProvider.Sqlite => BuildSqliteString(),
            _ => throw new NonExistProvider((int)providerByIndex)
        };
    }
    private ConnStringBuilderSqlServer BuildSqlServerString()
    {
        ConnStringBuilderSqlServer connStringBuilderSqlServer = new();
        connStringBuilderSqlServer.connectionServer = cmbServerNameSqlServer.Text;
        
        AuthTypes authType = cmbAuthTypeSqlServer.SelectedIndex switch
        {
            0 => AuthTypes.WinAuth,
            1 => AuthTypes.SqlSAuth,
            _ => throw new ArgumentOutOfRangeException()
        };
        if(authType == AuthTypes.SqlSAuth)
        {
            if(string.IsNullOrEmpty(txtUsernameSqlServer.Text) && 
               string.IsNullOrEmpty(txtPasswordSqlServer.Text))
                throw new AuthenticationInformationException("SQL", "username","password");
            
            connStringBuilderSqlServer.userId = txtUsernameSqlServer.Text;
            connStringBuilderSqlServer.password = txtPasswordSqlServer.Text;
        }
        else connStringBuilderSqlServer.trustedConnection = true;
        
        connStringBuilderSqlServer.connectionDatabase = txtDbNameSqlServer.Text;

        return connStringBuilderSqlServer;
    }
    private ConnStringBuilderSqlite BuildSqliteString()
    {
        return new()
        {
            dataSource = txtDataSourceSqlite.Text,
            password = txtPasswordSqlite.Text,
            version = cmbVersionSqlite.Text,
            isReadOnly = chbReadOnlySqlite.Checked
        };
    }

    private void ConnectDb_FormClosed(object sender, FormClosedEventArgs e)
    {
        LanguageManager.RemoveGlobalizationObserver(GlobalizationOnLangTextObserver);
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
        
        label6.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelDataSource");
        label8.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelPasswordOptional");
        label7.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "LabelVersion");
        chbReadOnlySqlite.Text = LanguageManager.ReturnGlobalizationText("ConnectDb", "CheckBoxReadOnly");
    }
}