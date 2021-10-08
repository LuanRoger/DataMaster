using System.IO;
using System.Windows.Forms;

namespace DataMaster.UI
{
    public partial class ScriptEditor : Form
    {
        private string? filePath { get; }
        private string? fileExtension { get; set; }
        
        public ScriptEditor(string filePath = null)
        {
            InitializeComponent();
            
            this.filePath = filePath;
        }
        private void ScriptEditor_Load(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(filePath)) LoadFileText();
            
            lblScriptLang.Text = txtScriptCommand.languageSyntax;
        }
        
        private void LoadFileText()
        {
            Text = File.ReadAllText(filePath);
            fileExtension = Path.GetExtension(filePath);
            txtScriptCommand.SetSyntax(fileExtension);
        }
    }
}
