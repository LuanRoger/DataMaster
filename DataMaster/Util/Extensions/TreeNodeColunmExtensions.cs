using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMaster.Types.Components.TreeNode;

namespace DataMaster.Util.Extensions
{
    public static class TreeNodeColunmExtensions
    {
        public static DataTableColumns ToDataTableColumns(this TreeNodeColumn treeNodeColumn) =>
            new(treeNodeColumn.text, treeNodeColumn.hasKey, treeNodeColumn.allowNull, treeNodeColumn.dataType);
        
        public static TreeNodeColumn ToTreeNodeColumn(this TreeNode table)
        {
            TreeNodeColumn treeNodeColumn = new(table.Text,
                table.Nodes[0].Text,
                bool.Parse(table.Nodes[1].Text.Split(':')[1].Trim()),
                bool.Parse(table.Nodes[2].Text.Split(':')[1].Trim()));
            return treeNodeColumn;
        }
    }
}