using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMasterComponents.TreeNode;

namespace DataMaster.Util.Extensions;

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
    public static SqlTable ToDataTable(this TreeNodeTable table)
    {
        SqlTable sqlTable = new(table.text, new());
        foreach (TreeNodeColumn treeNodeColumn in table.columns)
        {
            sqlTable.colunms.Add(treeNodeColumn.ToDataTableColumns());
        }
        return sqlTable;
    }
}