using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;

namespace DataMaster.UI
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
            label1.Font = new(privateFont.Families[0], 20, FontStyle.Bold);

            lblProgramVersion.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version}";
        }
    }
}
