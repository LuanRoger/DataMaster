using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using DataMaster.Managers;
using GlobalStrings.EventArguments;

namespace DataMaster.UI
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
        }
        private void Sobre_Load(object sender, System.EventArgs e)
        {
            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
            label1.Font = new(privateFont.Families[0], 20, FontStyle.Bold);

            lblProgramVersion.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version}";
            
            LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
        }
        
        private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
        {
            Text = LanguageManager.ReturnGlobalizationText("About", "WindowTile");
            
            label4.Text = LanguageManager.ReturnGlobalizationText("About", "LabelWallpaper");
        }
    }
}
