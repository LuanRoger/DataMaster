﻿using DataMaster;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baser.GUI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

            AppManager.DownloadFonts();
            AppConfigurationManager.LoadConfig();

            try
            {
                PrivateFontCollection privateFont = new();
                privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
                privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRALIGHT);
                label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
                label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Está faltando arquivos essenciais para inicialização do programa, tente reinstalá-lo novamente.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private async void SplashScreen_Load(object sender, System.EventArgs e)
        {
            lblStatusCarregamento.Text = "Carregando...";

            List<Task> startTasks = new();
            startTasks.Add(Task.Delay(Consts.SPLASH_SCREEN_TIME));
            await Task.WhenAll(startTasks);

            Close();
        }
    }
}
