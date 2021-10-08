namespace DataMaster.Types.Components.TreeNode
{
    public class TreeNodeColumn : System.Windows.Forms.TreeNode
    {
        internal string text {get; private set;}
        internal bool hasKey { get; private set; }
        internal bool allowNull { get; private set; }
        internal string dataType { get; private set; }

        internal TreeNodeColumn(string text, string dataType, bool hasKey, bool allowNull) : base(text)
        {
            this.text = text;
            this.dataType = dataType;
            this.hasKey = hasKey;
            this.allowNull = allowNull;
        }
    }
}
