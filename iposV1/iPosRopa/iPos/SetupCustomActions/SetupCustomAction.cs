using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.Linq;
using System.Diagnostics;
using System.IO;



namespace SetupCustomActions
{
    [RunInstaller(true)]
    public partial class SetupCustomAction : Installer
    {
        public SetupCustomAction()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);


            // create a new process...
            Process process = new Process();
            

            // get the assembly (exe) path and filename.
            string assemblyPath = Context.Parameters["assemblypath"];
            if (assemblyPath.EndsWith("\\"))
                assemblyPath = assemblyPath.Substring(0, assemblyPath.Length - 1);
            assemblyPath = System.IO.Path.GetDirectoryName(assemblyPath);
            //assemblyPath = System.IO.Path.GetDirectoryName(assemblyPath);
            process.StartInfo.FileName = assemblyPath + "\\Firebird-2.5.0.26074_1_Win32.exe";
            //System.Windows.Forms.MessageBox.Show(assemblyPath + " " + process.StartInfo.FileName);
            // add the argument to the filename as the assembly path.
            // Use quotes--important if there are spaces in the name.
            // Use the "install" verb and ngen.exe will compile all deps.
            process.StartInfo.Arguments = "Install /SILENT"; ;
   
            // start ngen. it will do its magic.
            process.Start();
            process.WaitForExit();



            // create a new process...
            Process process2 = new Process();
            process2.StartInfo.FileName = assemblyPath + "\\AccessDatabaseEngine.exe";
            process2.StartInfo.Arguments = "/quiet"; 
            process2.Start();
            process2.WaitForExit();




        }

    }
}
