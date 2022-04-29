using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DatabaseEngineInterpreter.Serialization.DsmFile;
using System.Threading.Tasks;
using DatabaseEngine;
using DataMaster.Managers;
using DataMaster.Types;
using DataMaster.Util.Extensions;
using DataMasterComponents.TreeNode;
using GlobalStrings.EventArguments;

#pragma warning disable CS8509

namespace DataMaster.UI;

public partial class CreateDb : Form
{
    private string? modelPath { get; }

    public CreateDb(string? modelPath = null)
    {
        InitializeComponent();

        this.modelPath = modelPath;
    }

    private async void CreateDb_Load(object sender, EventArgs e)
    {
        #region TreeView Configuration
        tevDataVisualization.ImageList = new();
        tevDataVisualization.AfterSelect += (_, _) => 
            tevDataVisualization.SelectedImageIndex = tevDataVisualization.SelectedNode.ImageIndex;
        tevDataVisualization.ImageList.Images.Add(Properties.Resources.database);
        tevDataVisualization.ImageList.Images.Add(Properties.Resources.table);
        tevDataVisualization.ImageList.Images.Add(Properties.Resources.table_key);
        tevDataVisualization.ImageList.Images.Add(Properties.Resources.table_propertie);
        tevDataVisualization.ImageList.Images.Add(Properties.Resources.cog);
        #endregion

        SwitchProgressBarVisibility();
        if (modelPath != null) await LoadModel();
        SwitchProgressBarVisibility();
            
        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
    private void CreateDb_Activated(object sender, EventArgs e) => UpdateInfo();

    private void btnAddDb_Click(object sender, EventArgs e)
    {
        tevDataVisualization.Nodes.Add(new TreeNode($"Database{tevDataVisualization.Nodes.Count}") { ImageIndex = 0 });
        UpdateInfo();
    }
            

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (tevDataVisualization.SelectedNode == null) return;

        DialogResult dialogResult = MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox",
                                                        "DeleteConfirmation")
                                                    + tevDataVisualization.SelectedNode.Text + "?", 
            LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxQuestionTitle"), 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes) return;
            
        tevDataVisualization.SelectedNode.Remove(); 
        UpdateInfo();
    }

    private void btnAddTable_Click(object sender, EventArgs e)
    {
        if (tevDataVisualization.SelectedNode is not { Level: 0 })
        {
            MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "SelectTableToInsert"),
                LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxInformationTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        CreateTable createTable = new();
        createTable.ShowDialog();

        if (createTable.DialogResult != DialogResult.OK || createTable.table is null) return;

        tevDataVisualization.SelectedNode.Nodes.Add(createTable.table);
            
        UpdateInfo();
    }

    private async void btnCreateDb_Click(object sender, EventArgs e)
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

        if(Verifiers.VerifyTreeViewCount(tevDataVisualization))
        {
            MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "NoDatabaseToSave"), 
                LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        SwitchProgressBarVisibility();
        List<SqlInfo> sqlInfos = tevDataVisualization.RecognazeTreeView();
        foreach (SqlInfo sqlInfo in sqlInfos)
        {
            try { await DbConnectionManager.currentProvider!.CreateDb(sqlInfo); }
            catch(Exception exception)
            {
                MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "ErrorOccurs") + exception.Message,
                    LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally { SwitchProgressBarVisibility(); UpdateInfo(); }
        }
        MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "Created"),
            LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxSuccessTitle"),
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    private void btnSaveModel_Click(object sender, EventArgs e)
    {
        if(Verifiers.VerifyTreeViewCount(tevDataVisualization))
        {
            MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "NothingToSave"),
                LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxErrorTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        SaveFileDialog saveFileDialog = new() { Filter = Consts.FILTER_DSM };

        foreach (SqlInfo sqlInfo in tevDataVisualization.RecognazeTreeView())
        {
            saveFileDialog.Title = LanguageManager.ReturnGlobalizationText("Dialogs", "SaveFileDialogTitle") + sqlInfo.databaseName;
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            sqlInfo.Serialize(saveFileDialog.FileName);
        }

        MessageBox.Show(LanguageManager.ReturnGlobalizationText("MessageBox", "TemplateSaved"), 
            LanguageManager.ReturnGlobalizationText("MessageBox", "MessageBoxSuccessTitle"), 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        saveFileDialog.Dispose();
    }

    private void UpdateInfo()
    {
        lblQuantDb.Text = tevDataVisualization.Nodes.Count.ToString();

        int tableCount = 0;
        foreach (TreeNode tables in tevDataVisualization.Nodes)
            tableCount += tables.Nodes.Count;
            
        lblQuantTabela.Text = tableCount.ToString();
    }
        
    private async Task LoadModel()
    {
        await Task.Run(() =>
        {
            SqlInfo sqlInfo = DsmFileSerializer.Deserializate(modelPath);

            tevDataVisualization.Invoke((MethodInvoker)(() => 
                tevDataVisualization.Nodes.Add(sqlInfo.databaseName)));

            foreach (SqlTable sqlTable in sqlInfo.tables)
            {
                List<TreeNodeColumn> treeNodeColumns = new();
                foreach (SqlColumns tableColumns in sqlTable.colunms)
                    treeNodeColumns.Add(new(tableColumns.name, tableColumns.dataType,
                        tableColumns.hasKey, tableColumns.allowNull));

                TreeNodeTable treeNodeTable = new(sqlTable.name, treeNodeColumns);
                    
                tevDataVisualization.Invoke((MethodInvoker)(() => 
                    tevDataVisualization.Nodes[0].Nodes.Add(treeNodeTable)));
            }
        });
        UpdateInfo();
    }
        
    private void SwitchProgressBarVisibility() => pgbAsyncTasks.Visible = !pgbAsyncTasks.Visible;

    private void CreateDb_FormClosed(object sender, FormClosedEventArgs e)
    {
        LanguageManager.RemoveGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
    private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
    {
        btnAdicionarDb.Size = updatemodeeventargs.lang switch
        {
            LanguageCode.PT_BR => new(119, 23),
            LanguageCode.EN_US => new(110, 23)
        };
        btnAddTable.Size = updatemodeeventargs.lang switch
        {
            LanguageCode.PT_BR => new(119, 23),
            LanguageCode.EN_US => new(110, 23)
        };
        btnDelete.Size = updatemodeeventargs.lang switch
        {
            LanguageCode.PT_BR => new(119, 23),
            LanguageCode.EN_US => new(110, 23)
        };
            
        btnSaveModel.Size = updatemodeeventargs.lang switch
        {
            LanguageCode.PT_BR => new(106, 23),
            LanguageCode.EN_US => new(95, 23),
        };
        btnCreateDb.Size = updatemodeeventargs.lang switch
        {
            LanguageCode.PT_BR => new(89, 23),
            LanguageCode.EN_US => new(80, 23)
        };
            
        Text = LanguageManager.ReturnGlobalizationText("CreateDb", "WindowTile");
            
        btnAdicionarDb.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "ButtonAddDb");
        btnAddTable.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "ButtonAddTable");
        btnDelete.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "ButtonDeleteElement");
            
        groupBox1.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "GroupboxInfo");
        label1.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "LabelAmountDb");
        label2.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "LabelAmuntTable");
            
        btnCreateDb.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "ButtonCreateDb");
        btnSaveModel.Text = LanguageManager.ReturnGlobalizationText("CreateDb", "ButtonSaveModel");
    }
}