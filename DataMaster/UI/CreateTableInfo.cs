using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataMaster.Types;

namespace DataMaster.UI
{
    public partial class CreateTableInfo : Form
    {
        internal TreeNodeTable table { get; private set; }

        public CreateTableInfo(TreeNodeTable table = null)
        {
            InitializeComponent();
            tevTableDesing.ImageList = new();
            tevTableDesing.ImageList.Images.Add(Properties.Resources.table);
            tevTableDesing.ImageList.Images.Add(Properties.Resources.table_key);
            tevTableDesing.ImageList.Images.Add(Properties.Resources.table_propertie);
            
            this.table = table;
            if(table != null) LoadTable();
        }

        #region Add/Remove Propertie
        private void btnAcionarColuna_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNomeColuna.Text) || string.IsNullOrEmpty(txtTiposDados.Text))
            {
                MessageBox.Show("A coluna deve ter um nome e um tipo de dado.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TreeNodeColumn treeNodeColumn = new(txtNomeColuna.Text, txtTiposDados.Text, chbHasKey.Checked, chbPermitirNull.Checked)
            {
                ImageIndex = chbHasKey.Checked ? 1 : 2
            };
            treeNodeColumn.Nodes.Add(treeNodeColumn.dataType);
            treeNodeColumn.Nodes.Add($"Cheve: {treeNodeColumn.hasKey}");
            treeNodeColumn.Nodes.Add($"Permitir NULL: {treeNodeColumn.allowNull}");

            tevTableDesing.Nodes[0].Nodes.Add(treeNodeColumn);

            ClearFields();
        }
        private void btnRemoverColuna_Click(object sender, EventArgs e)
        {
            if(tevTableDesing.SelectedNode == null)
            {
                MessageBox.Show("Selecione uma coluna para excluir", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tevTableDesing.SelectedNode.Remove();
        }
        private void txtTiposDados_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) btnAcionarColuna.PerformClick();
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNodeTable table;
            List<TreeNodeColumn> columns = new();

            foreach(TreeNodeColumn colunm in tevTableDesing.Nodes[0].Nodes)
            {
                var tempNode = new TreeNodeColumn(colunm.Text, colunm.dataType, colunm.hasKey, colunm.allowNull);
                tempNode.ImageIndex = tempNode.hasKey ? 2 : 3;

                columns.Add(tempNode);
            }
            table = new(tevTableDesing.Nodes[0].Text, columns)
            {
                ImageIndex = 1
            };
            this.table = table;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region UpDown Nodes
        private void btnSubirColuna_Click(object sender, EventArgs e)
        {
            if(tevTableDesing.SelectedNode == null) return;

            var nodeToUp = tevTableDesing.SelectedNode;

            if(nodeToUp.Index == 0) return;

            tevTableDesing.Nodes[0].Nodes[nodeToUp.Index].Remove();
            tevTableDesing.Nodes[0].Nodes.Insert(nodeToUp.Index - 1, nodeToUp);
        }
        private void btnDescerColuna_Click(object sender, EventArgs e)
        {
            if(tevTableDesing.SelectedNode == null) return;

            var nodeToDown = tevTableDesing.SelectedNode;

            if(nodeToDown.Index + 1 == tevTableDesing.Nodes[0].Nodes.Count) return;

            tevTableDesing.Nodes[0].Nodes[nodeToDown.Index].Remove();
            tevTableDesing.Nodes[0].Nodes.Insert(nodeToDown.Index + 1, nodeToDown);
        }
        #endregion
        
        private void LoadTable()
        {
            tevTableDesing.Nodes.Add(table.text);
            foreach (TreeNodeColumn column in table.columns)
                tevTableDesing.Nodes[0].Nodes.Add(column);
        }
        
        private void ClearFields()
        {
            txtNomeColuna.Clear();
            txtTiposDados.Text = "";
            chbHasKey.Checked = false;
            chbPermitirNull.Checked = false;
        }
    }
}
