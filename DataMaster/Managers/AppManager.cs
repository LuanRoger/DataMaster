using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace DataMaster.Managers
{
    public static class AppManager
    {
        public static void RestarApp()
        {
            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void DownloadFonts()
        {
            if (File.Exists(Consts.FONT_MONTSERRAT_EXTRABOLD) && 
                File.Exists(Consts.FONT_MONTSERRAT_EXTRALIGHT)) return;

            Directory.CreateDirectory(Consts.FONTS_FOLDER);

            using WebClient webClient = new();
            foreach (string font in Consts.FONTS_DOWNLAOD)
            {
                webClient.DownloadFile(new Uri(Consts.FONT_DOWNLOAD_SERVER + font),
                @$"{Consts.FONTS_FOLDER}\{font}");
            }
        }
    }
}
