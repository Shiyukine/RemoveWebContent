using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveWebContent
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var settings = new CefSettings();
            settings.PersistSessionCookies = true;
            settings.PersistUserPreferences = true;
            settings.LogSeverity = LogSeverity.Warning;
            //settings.SetOffScreenRenderingBestPerformanceArgs();
            settings.CefCommandLineArgs.Add("autoplay-policy", "no-user-gesture-required");
            settings.CefCommandLineArgs.Add("enable-media-stream");
            //settings.CefCommandLineArgs.Add("disable-direct-composition");
            settings.CefCommandLineArgs.Add("disable-plugins-discovery");
            settings.CefCommandLineArgs.Add("disable-pdf-extension");
            settings.CefCommandLineArgs.Add("disable-extensions");
            settings.CefCommandLineArgs.Add("disable-features", "OutOfBlinkCors");
            settings.CefCommandLineArgs.Add("disable-web-security", "true");
            //if (!AppInfo.sf.settingExists("Use_Proxy_Server")) settings.CefCommandLineArgs.Add("no-proxy-server");
            //settings.CefCommandLineArgs.Add("disable-gpu-vsync");
            CefSharpSettings.ConcurrentTaskExecution = true;
            //settings.CefCommandLineArgs.Add("disable-renderer-accessibility");
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            Application.Run(new Form1());
        }
    }
}
