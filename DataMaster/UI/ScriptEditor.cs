using System.Windows.Forms;

namespace DataMaster.UI
{
    public partial class ScriptEditor : Form
    {
        private string? sqlFilePaht { get; }
        
        public ScriptEditor(string sqlFilePaht = null)
        {
            InitializeComponent();
            
            this.sqlFilePaht = sqlFilePaht;
        }
    }
}
