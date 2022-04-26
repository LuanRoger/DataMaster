namespace DataMasterComponents.TreeNode;

public class TreeNodeColumn : System.Windows.Forms.TreeNode
{
    public string text {get; }
    public bool hasKey { get; }
    public bool allowNull { get; }
    public string dataType { get; }

    public TreeNodeColumn(string text, string dataType, bool hasKey, bool allowNull) : base(text)
    {
        this.text = text;
        this.dataType = dataType;
        this.hasKey = hasKey;
        this.allowNull = allowNull;
    }
}