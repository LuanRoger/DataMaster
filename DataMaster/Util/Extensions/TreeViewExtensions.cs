using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DataMasterComponents.TreeNode;

namespace DataMaster.Util.Extensions;

public static class TreeViewExtensions
{
    internal static List<SqlInfo> RecognazeTreeView(this TreeView treeView)
    {
        List<SqlInfo> sqlInfos = new();
        foreach(TreeNode db in treeView.Nodes)
        {
            string dbName = db.Text;
            List<SqlTable> dataTables = new();

            foreach(TreeNode tables in db.Nodes)
            {
                TreeNodeTable treeNodeTable = tables.ToTreeNodeTable();
                List<SqlColumns> tableColumns = new();
                foreach(TreeNodeColumn column in treeNodeTable.columns)
                    tableColumns.Add(new(column.text, column.hasKey, column.allowNull, column.dataType));

                dataTables.Add(new(treeNodeTable.text, tableColumns));
            }

            sqlInfos.Add(new(dbName, dataTables));
        }
        return sqlInfos;
    }
}