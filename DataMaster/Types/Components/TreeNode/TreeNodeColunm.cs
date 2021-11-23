namespace DataMaster.Types.Components.TreeNode
{
    public class TreeNodeColumn : System.Windows.Forms.TreeNode
    {
        internal string text {get; }
        internal bool hasKey { get; }
        internal bool allowNull { get; }
        internal string dataType { get; }

        internal TreeNodeColumn(string text, string dataType, bool hasKey, bool allowNull) : base(text)
        {
            this.text = text;
            this.dataType = dataType;
            this.hasKey = hasKey;
            this.allowNull = allowNull;
        }
    }
}
