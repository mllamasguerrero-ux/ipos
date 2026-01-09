using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace iPosReporting
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormProductoFicha(8033));
						Application.Run(new FormProductoFicha());
        }
    }
}