using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DatabaseEngineInterpreter.Serialization.DsmFile;
using DataMaster.Types;
using System.Threading.Tasks;
using DataMaster.DB.SQLServer.SqlPure;
using DataMaster.Managers;
using DataMaster.Util.Extensions;

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
        }
        private void CreateDb_Activated(object sender, EventArgs e) => UpdateInfo();

        private void btnAdicionarDb_Click(object sender, EventArgs e) =>
            tevDataVisualization.Nodes.Add(new TreeNode($"Database{tevDataVisualization.Nodes.Count}") { ImageIndex = 0 });

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tevDataVisualization.SelectedNode == null) return;

            DialogResult dialogResult = MessageBox.Show($"Deseja realmente excluir {tevDataVisualization.SelectedNode.Name}?", "Pergunta", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(dialogResult == DialogResult.Yes) tevDataVisualization.SelectedNode.Remove();
        }

        private void btnAdicionarTabela_Click(object sender, EventArgs e)
        {
            if (tevDataVisualization.SelectedNode == null)
            {
                MessageBox.Show("Selecione um banco de dados para inserir a tabela", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CreateTableInfo createTableInfo = new();
            createTableInfo.ShowDialog();

            if (createTableInfo.DialogResult != DialogResult.OK) return;

            tevDataVisualization.SelectedNode.Nodes.Add(createTableInfo.table);
        }

        private async void btnCriarDb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConnectionManager.sqlServerConnection.ConnectionString))//TODO - Move to verifiers
            {
                MessageBox.Show("Não há uma String de conexão criada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            ShowProgressBarForAsyncTask();
            var sqlInfos = tevDataVisualization.RecognazeTreeView();
            foreach (SqlInfo sqlInfo in sqlInfos)
            {
                try { await SqlServerConnectionPure.CreateDb(sqlInfo); }
                catch(Exception exception)
                {
                    MessageBox.Show($"Ocorreu um error: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            HideProgressBarForAsyncTask();
            MessageBox.Show("Criado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSalvarModelo_Click(object sender, EventArgs e)
        {
            if(tevDataVisualization.Nodes.Count == 0) //TODO - Move to verifiers
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
        private async Task LoadModel() //TODO - Made this a method than return a TreeNodeCollection
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
    }
}
