using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseEngine;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using GlobalStrings.EventArguments;

namespace DataMaster.UI;

public partial class SplashScreen : Form
{
    public SplashScreen()
    {
        InitializeComponent();
    }

    private async void SplashScreen_Load(object sender, System.EventArgs e)
    {
        List<Task> initialTasks = new()
        {
            AppConfigurationManager.LoadConfig(),
            AppManager.DownloadFonts(),
            AppManager.DownloadLanguage(),
        };
        await Task.WhenAll(initialTasks);
        
        LanguageManager.InitLanguages(AppConfigurationManager.configuration.languageConfigModel.langCodeNow);
        LanguageManager.SetGlobalizationObserver(GlobalizationOnLangTextObserver);
        
        PrivateFontCollection privateFont = new();
        privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
        privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRALIGHT);
        label1.Font = new(privateFont.Families[0], 20, FontStyle.Bold);
        lblCreator.Font = new(privateFont.Families[1], 7, FontStyle.Regular);
        
        LoadCurrentProvider();
        
        List<Task> asyncTasks = new()
        {
            Task.Delay(Consts.SPLASH_SCREEN_TIME)
        };
        await Task.WhenAll(asyncTasks);

        Close();
    }
    private static void LoadCurrentProvider()
    {
        if (string.IsNullOrEmpty(AppConfigurationManager.configuration.database.connectionString))
            return;

        DbConnectionManager.databaseProviderConnection = new()
        {
            connectionString = AppConfigurationManager.configuration.database.connectionString,
            databaseProvider = AppConfigurationManager.configuration.database.databaseProvider
        };
    }

    private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
    {
        LanguageManager.RemoveGlobalizationObserver(GlobalizationOnLangTextObserver);
    }
    private void GlobalizationOnLangTextObserver(object sender, UpdateModeEventArgs updatemodeeventargs)
    {
        lblStatusCarregamento.Text = LanguageManager.ReturnGlobalizationText("SplashScreen", "LoadingLabel");
        lblCreator.Text = LanguageManager.ReturnGlobalizationText("About", "Creator");
    }
}