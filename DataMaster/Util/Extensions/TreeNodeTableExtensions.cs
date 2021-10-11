using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMaster.Types.Components.TreeNode;

namespace DataMaster.Util.Extensions
{
    public static class TreeNodeTableExtensions
    {
        public static TreeNodeTable ToTreeNodeTable(this TreeNode table)
        {
            TreeNodeTable treeNodeTable;
            List<TreeNodeColumn> treeNodeColumns = new();

            foreach(TreeNode column in table.Nodes)
            {
                treeNodeColumns.Add(column.ToTreeNodeColumn());
            }
            treeNodeTable = new(table.Text, treeNodeColumns);
            return treeNodeTable;
        }
        public static DataTable ToDataTable(this TreeNodeTable table)
        {
            DataTable dataTable = new(table.text, new());
            foreach (TreeNodeColumn treeNodeColumn in table.columns)
            {
                dataTable.colunms.Add(treeNodeColumn.ToDataTableColumns());
            }
            return dataTable;
        }
    }
}