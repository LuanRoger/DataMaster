using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMaster.Managers;

public static class AppManager
{
    private static readonly HttpClient httpClient = new();
    
    public static void RestarApp()
    {
        Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
        Process.GetCurrentProcess().Kill();
    }

    public static async Task DownloadFonts()
    {
        if (File.Exists(Consts.FONT_MONTSERRAT_EXTRABOLD) && 
            File.Exists(Consts.FONT_MONTSERRAT_EXTRALIGHT) &&
            File.Exists(Consts.FONT_LATO_BOLD)) return;

        Directory.CreateDirectory(Consts.FONTS_FOLDER);
        
        foreach (string font in Consts.FONTS_DOWNLAOD)
        {
            Uri requestUri = new(Consts.FONT_DOWNLOAD_SERVER + font);
            string output = @$"{Consts.FONTS_FOLDER}\{font}";

            await using FileStream fileStream = File.Create(output);
            await fileStream.WriteAsync(await httpClient.GetByteArrayAsync(requestUri));
        }
    }
}