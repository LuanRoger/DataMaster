using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DatabaseEngineInterpreter.Serialization.DsmFile;
using System.Threading.Tasks;
using DataMaster.DB.SQLServer.SqlPure;
using DataMaster.Managers;
using DataMaster.Types;
using DataMaster.Types.Components.TreeNode;
using DataMaster.Util.Extensions;
using GlobalStrings.EventArguments;
using DataTable = DatabaseEngineInterpreter.SqlSyntaxInfo.DataTable;

namespace DataMaster.UI
{
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
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.database);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.table);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.table_key);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.table_propertie);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.cog);
            #endregion
            
            ShowProgressBarForAsyncTask();
            if (modelPath != null) await LoadModel();
            HideProgressBarForAsyncTask();
            
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

            DialogResult dialogResult = MessageBox.Show($"Deseja realmente excluir {tevDataVisualization.SelectedNode.Text}?", "Pergunta", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes) return;
            
            tevDataVisualization.SelectedNode.Remove(); 
            UpdateInfo();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (tevDataVisualization.SelectedNode is not { Level: 0 })
            {
                MessageBox.Show("Selecione um banco de dados para inserir a tabela", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CreateTableInfo createTableInfo = new();
            createTableInfo.ShowDialog();

            if (createTableInfo.DialogResult != DialogResult.OK) return;

            tevDataVisualization.SelectedNode.Nodes.Add(createTableInfo.table);
            
            UpdateInfo();
        }

        private async void btnCreateDb_Click(object sender, EventArgs e)
        {
            if (Verifiers.VerifyConnectionString() != ConnectionState.Open)
            {
                MessageBox.Show("Não há uma string de conexão criada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Verifiers.VerifyTreeViewCount(tevDataVisualization))
            {
                MessageBox.Show("Não há banco de dados para salvar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowProgressBarForAsyncTask();
            List<SqlInfo> sqlInfos = tevDataVisualization.RecognazeTreeView();
            foreach (SqlInfo sqlInfo in sqlInfos)
            {
                try { await SqlServerConnectionPure.CreateDb(sqlInfo); }
                catch(Exception exception)
                {
                    MessageBox.Show($"Ocorreu um error: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally { HideProgressBarForAsyncTask(); UpdateInfo(); }
            }
            MessageBox.Show("Criado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if(Verifiers.VerifyTreeViewCount(tevDataVisualization))
            {
                MessageBox.Show("Não há o que salvar", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new() { Filter = Consts.FILTER_DSM };

            foreach (SqlInfo sqlInfo in tevDataVisualization.RecognazeTreeView())
            {
                saveFileDialog.Title = $"Salvar {sqlInfo.databaseName}";
                DialogResult dialogResult = saveFileDialog.ShowDialog();

                if (dialogResult != DialogResult.OK) return;

                sqlInfo.Serialize(saveFileDialog.FileName);
            }

            MessageBox.Show("Modelo salvo com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                foreach (DataTable sqlTable in sqlInfo.tables)
                {
                    List<TreeNodeColumn> treeNodeColumns = new();
                    foreach (DataTableColumns tableColumns in sqlTable.colunms)
                        treeNodeColumns.Add(new(tableColumns.name, tableColumns.dataType,
                            tableColumns.hasKey, tableColumns.allowNull));

                    TreeNodeTable treeNodeTable = new(sqlTable.name, treeNodeColumns);
                    
                    tevDataVisualization.Invoke((MethodInvoker)(() => 
                        tevDataVisualization.Nodes[0].Nodes.Add(treeNodeTable)));
                }
            });
            UpdateInfo();
        }
        
        #region ProgressBar
        private void ShowProgressBarForAsyncTask() => pgbAsyncTasks.Visible = true;
        private void HideProgressBarForAsyncTask() => pgbAsyncTasks.Visible = false;
        #endregion
        
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
}
