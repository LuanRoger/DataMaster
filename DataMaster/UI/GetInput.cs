using System.Windows.Forms;

namespace DataMaster.UI
{
    public partial class GetInput : Form
    {
        public string input;

        private bool allowEmpty;
        public GetInput(string message, string windowTitle, bool notEmpty = false)
        {
            InitializeComponent();

            this.allowEmpty = notEmpty;

            lblMessage.Text = message;
            Text = windowTitle;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if(!allowEmpty && string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Não pode ser vazio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            input = txtInput.Text;
            Close();
        }
    }
}
