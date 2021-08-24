using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DatabaseEngineInterpreter.Serialization.DduFile;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMaster.Types;
using DataMaster.Util.Extensions;

namespace DataMaster.UI
{
    public partial class UpdateDb : Form
    {
        private string? filePath { get; set; }
        private string oldNodeText { get; set; }
        private SqlUpdateInfo updateInfo { get; set; } = new()
        {
            forAddTable = new(),
            forDeleteTable = new(),
            forModifyTable = new(),
        };
        
        public UpdateDb(string? filePath = null)
        {
            InitializeComponent();

            this.filePath = filePath;
            if(this.filePath != null) LaodUpdate();
        }

        private void UpdateDb_Load(object sender, EventArgs e)
        {
            #region TreeView Configuration
            tevDataVisualization.ImageList = new();
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.database);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.table);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.table_key);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.table_propertie);
            tevDataVisualization.ImageList.Images.Add(Properties.Resources.cog);
            #endregion

            tevDataVisualization.AfterLabelEdit += (_, _) => 
                oldNodeText = tevDataVisualization.SelectedNode.Text;
            tevDataVisualization.BeforeLabelEdit += (_, _) =>
            {
                if(tevDataVisualization.SelectedNode.Text.Equals(oldNodeText)) return;

                TreeNode table = tevDataVisualization.SelectedNode;
                Colorfy(ref table, UpdateMode.Update);
                
                tevDataVisualization.SelectedNode.ForeColor = table.ForeColor;
            };
        }
        
        private void btnCriarTabela_Click(object sender, EventArgs e)
        {
            CreateTableInfo createTableInfo = new();
            createTableInfo.ShowDialog();

            if (createTableInfo.DialogResult != DialogResult.OK) return;
            
            TreeNode table = createTableInfo.table;
            Colorfy(ref table, UpdateMode.Add);
            
            tevDataVisualization.Nodes.Add(table);
            updateInfo.forAddTable.Add(table.ToTreeNodeTable().ToDataTable());
        }
        private void btnEditarTabela_Click(object sender, EventArgs e)
        {
            if(tevDataVisualization.SelectedNode.Level >= 1) return;
            
            CreateTableInfo createTableInfo = new(tevDataVisualization.SelectedNode.ToTreeNodeTable());
            createTableInfo.ShowDialog();
            
            if (createTableInfo.DialogResult != DialogResult.OK) return;
            
            TreeNode table = createTableInfo.table;
            Colorfy(ref table, UpdateMode.Update);
            
            tevDataVisualization.SelectedNode.Nodes.Add(createTableInfo.table);
            tevDataVisualization.SelectedNode.ForeColor = table.ForeColor;
        }
        private void btnExcluirTabela_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = 
                MessageBox.Show($"Desseja realmente apagar a tabela {tevDataVisualization.SelectedNode.Text}?",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult != DialogResult.Yes) return;
            
            TreeNode table =  tevDataVisualization.SelectedNode;
            Colorfy(ref table, UpdateMode.Delete);
            
            if(updateInfo.forDeleteTable.Contains(tevDataVisualization.SelectedNode.Text)) return;
                
            updateInfo.forDeleteTable.Add(table.Text);
            tevDataVisualization.SelectedNode.ForeColor = table.ForeColor;
        }
        private void btnSalvarArquivo_Click(object sender, EventArgs e)
        {
            if(tevDataVisualization.Nodes.Count == 0) //TODO - Move to verifiers
            {
                MessageBox.Show("Não há o que salvar", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new() { Filter = Consts.FILTER_DDU };
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK) return;
            updateInfo.Serialize(saveFileDialog.FileName);
            
            MessageBox.Show("Modelo salvo com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            saveFileDialog.Dispose();
        }
        
        private void LaodUpdate()
        {
            updateInfo = DduFileSerializer.Deserializate(filePath);
        }
        private void Colorfy(ref TreeNode table, UpdateMode updateMode)
        {
            table.ForeColor = updateMode switch
            {
                UpdateMode.Add => Color.Green,
                UpdateMode.Delete => Color.Red,
                UpdateMode.Update => Color.Blue,
                _ => table.ForeColor
            };
        }
        //TODO - Made in realtime
    }
}
