using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IposV3CustomInstallerActions
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);



            bool instalarMotorBD = false;

            WFDataBaseOptions wf = new WFDataBaseOptions();
            wf.ShowDialog();
            instalarMotorBD = wf.InstalarMotorBD;
            wf.Dispose();


            // create a new process...

            string assemblyPath = Context.Parameters["assemblypath"];
            if (assemblyPath.EndsWith("\\"))
                assemblyPath = assemblyPath.Substring(0, assemblyPath.Length - 1);
            assemblyPath = System.IO.Path.GetDirectoryName(assemblyPath);


            if (instalarMotorBD)
            {
                Process process = new Process();

                // get the assembly (exe) path and filename.

                process.StartInfo.FileName = assemblyPath + "\\postgresql-10.11-3-windows.exe";

                MessageBox.Show("File name " + process.StartInfo.FileName);

                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";
                process.StartInfo.Arguments = " --mode unattended --superpassword Twincept.l --servicepassword Twincept.l";


                process.Start();
                process.WaitForExit();
            }


        }


        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            //System.Diagnostics.Process.Start("http://www.microsoft.com");
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}
