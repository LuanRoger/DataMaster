namespace DataMasterComponents.TreeNode;

public class TreeNodeTable : System.Windows.Forms.TreeNode
{
    public string text { get; set; }
    public List<TreeNodeColumn> columns { get; set; }

    public TreeNodeTable(string text, List<TreeNodeColumn> columns) : base(text, 1, 1)
    {
        this.text = text;
        this.columns = columns;
        foreach(TreeNodeColumn column in columns)
        {
            System.Windows.Forms.TreeNode propertie = new(column.text)
            {
                ImageIndex = column.hasKey ? 2 : 3
            };
            propertie.Nodes.Add(new System.Windows.Forms.TreeNode(column.dataType, 4, 4));
            propertie.Nodes.Add(new System.Windows.Forms.TreeNode($"Chave: {column.hasKey}", 4, 4));
            propertie.Nodes.Add(new System.Windows.Forms.TreeNode($"Permitir NULL: {column.allowNull}", 4, 4));

            Nodes.Add(propertie);
        }
    }
}