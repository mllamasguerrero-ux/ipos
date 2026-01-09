using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
namespace iPos
{
    static class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            // Set WebBrowser control to use IE11 document mode for this process (per-user).
            // This avoids old IE7/IE8 behavior which causes modern JS to fail.
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
                {
                    var exeName = Process.GetCurrentProcess().ProcessName + ".exe";
                    // 11000 (decimal) = IE11 mode. (Some use 11001; 11000 is widely used.)
                    key.SetValue(exeName, 11000, RegistryValueKind.DWord);
                }
            }
            catch
            {
                // ignore or log if you want — failure to set registry should not crash the app
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length > 0 )
            {
                Application.Run(new FLogin(args[0], args[1]));
            }
            else
            {
                Application.Run(new FLogin());
            }

            //Application.Run(new Convertidor.WinFormToWPF());
        }
    }
}