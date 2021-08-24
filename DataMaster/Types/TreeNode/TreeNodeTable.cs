using DatabaseEngineInterpreter.SqlSyntaxInfo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataMaster.Types
{
    public class TreeNodeTable : TreeNode
    {
        public string text { get; set; }
        public List<TreeNodeColumn> columns { get; set; }

        public TreeNodeTable(string text, List<TreeNodeColumn> columns) : base(text, 1, 1)
        {
            this.text = text;
            this.columns = columns;
            foreach(TreeNodeColumn column in columns)
            {
                TreeNode propertie = new(column.text);
                propertie.ImageIndex = column.hasKey ? 2 : 3;
                propertie.Nodes.Add(new TreeNode(column.dataType, 4, 4));
                propertie.Nodes.Add(new TreeNode($"Chave: {column.hasKey}", 4, 4));
                propertie.Nodes.Add(new TreeNode($"Permitir NULL: {column.allowNull}", 4, 4));

                Nodes.Add(propertie);
            }
        }
    }
}
