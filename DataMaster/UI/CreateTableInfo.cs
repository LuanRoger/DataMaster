using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataMaster.Managers;
using DataMaster.Types.Components.TreeNode;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

public partial class CreateTableInfo : Form
{
    internal TreeNodeTable table { get; private set; }
    private bool inspect { get; }
    private StringBuilder sqlChanges { get; set;}

    public CreateTableInfo(TreeNodeTable table = null, bool inspect = false)
    {
        InitializeComponent();
        #region TreeViewConfiguration
        tevTableDesing.ImageList = new();
        tevTableDesing.ImageList.Images.Add(Properties.Resources.table);
        tevTableDesing.ImageList.Images.Add(Properties.Resources.table_key);
        tevTableDesing.ImageList.Images.Add(Properties.Resources.table_propertie);
        tevTableDesing.ImageList.Images.Add(Properties.Resources.cog);
        #endregion

        this.table = table;
        this.inspect = inspect;
            
        if(table != null) LoadTable();
        else tevTableDesing.Nodes.Add("Table");
    }
    private void CreateTableInfo_Load(object sender, EventArgs e)
    {
        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
    }

    private void LoadTable()
    {
        table.ImageIndex = 0;
        foreach (TreeNodeColumn tableColumn in table.columns)
        {
            tableColumn.ImageIndex = tableColumn.hasKey ? tableColumn.ImageIndex = 1 : tableColumn.ImageIndex = 2;
            foreach (TreeNode columnProperties in tableColumn.Nodes) columnProperties.ImageIndex = 3;
        }
            
        tevTableDesing.Nodes.Add(table);
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

        TreeNodeColumn treeNodeColumn = new(txtNomeColuna.Text, txtTiposDados.Text, chbHasKey.Checked, chbAllowNull.Checked)
        {
            ImageIndex = chbHasKey.Checked ? 1 : 2
        };
        treeNodeColumn.Nodes.Add("type", treeNodeColumn.dataType, 3);
        treeNodeColumn.Nodes.Add("key", $"Cheve: {treeNodeColumn.hasKey}", 3);
        treeNodeColumn.Nodes.Add("null", $"Permitir NULL: {treeNodeColumn.allowNull}", 3);

        if(inspect) AppendAddChange(treeNodeColumn);
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
            
        if(inspect) AppendDropChange(tevTableDesing.SelectedNode.Text);
        tevTableDesing.SelectedNode.Remove();
    }
    private void txtTiposDados_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Enter) btnAddColumn.PerformClick();
    }
    #endregion

    private void btnOK_Click(object sender, EventArgs e)
    {
        TreeNodeTable tempTable;
        List<TreeNodeColumn> columns = new();

        foreach(TreeNodeColumn colunm in tevTableDesing.Nodes[0].Nodes)
        {
            TreeNodeColumn tempNode = new(colunm.Text, colunm.dataType, colunm.hasKey, colunm.allowNull);
            tempNode.ImageIndex = tempNode.hasKey ? 2 : 3;

            columns.Add(tempNode);
        }
        tempTable = new(tevTableDesing.Nodes[0].Text, columns)
        {
            ImageIndex = 1
        };
        table = tempTable;

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

        TreeNode nodeToUp = tevTableDesing.SelectedNode;

        if(nodeToUp.Index == 0) return;

        tevTableDesing.Nodes[0].Nodes[nodeToUp.Index].Remove();
        tevTableDesing.Nodes[0].Nodes.Insert(nodeToUp.Index - 1, nodeToUp);
    }
    private void btnDescerColuna_Click(object sender, EventArgs e)
    {
        if(tevTableDesing.SelectedNode == null) return;

        TreeNode nodeToDown = tevTableDesing.SelectedNode;

        if(nodeToDown.Index + 1 == tevTableDesing.Nodes[0].Nodes.Count) return;

        tevTableDesing.Nodes[0].Nodes[nodeToDown.Index].Remove();
        tevTableDesing.Nodes[0].Nodes.Insert(nodeToDown.Index + 1, nodeToDown);
    }
    #endregion

    #region SqlChangeloger
    private void AppendAddChange(TreeNodeColumn column)
    {
        sqlChanges.AppendLine($"ALTER TABLE {0} ADD {column.text} {column.dataType}");
    }
    private void AppendDropChange(string columnName)
    {
        sqlChanges.AppendLine($"ALTER TABLE {0} DROP COLUMN {columnName}");
    }
    private void AppendModifyTable(string colunmName, string dataType)
    {
        sqlChanges.AppendLine($"ALTER TABLE {0} ALTER COLUMN {colunmName} {dataType};");
    }
    private void tevTableDesing_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        if(!inspect) return;
            
        if(tevTableDesing.SelectedNode.Level == 2) 
            AppendModifyTable(tevTableDesing.SelectedNode.Parent.Text,
                tevTableDesing.SelectedNode.Text);
    }
    #endregion
    
    private void ClearFields()
    {
        txtNomeColuna.Clear();
        txtTiposDados.Text = "";
        chbHasKey.Checked = false;
        chbAllowNull.Checked = false;
    }
    private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
    {
        Text = LanguageManager.ReturnGlobalizationText("CreateTable", "WindowTile");
            
        label1.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "LabelColumnName");
        label2.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "LabelDataType");
            
        chbAllowNull.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "CheckboxAllowNull");
        chbHasKey.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "CheckboxHasKey");

        btnAddColumn.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "ButtonAddColumn");
        btnRemoveColumn.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "ButtonRemoveColumn");
            
        btnOK.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "ButtonOk");
        btnCancelar.Text = LanguageManager.ReturnGlobalizationText("CreateTable", "ButtonCancel");
    }
}