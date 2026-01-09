using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPos.Tools
{
    public class CmdHelper
    {
        private static string enviroment = String.Empty;

        public static string Enviroment { get => enviroment; set => enviroment = value; }

        public static string ExecuteCommand(string cmdText)
        {
            List<string> results = new List<string>();

            ProcessStartInfo cmdInfo = new ProcessStartInfo("cmd.exe", cmdText);

            cmdInfo.CreateNoWindow = true;
            cmdInfo.RedirectStandardOutput = true;
            cmdInfo.RedirectStandardError = true;
            cmdInfo.UseShellExecute = false;

            var output = new StringBuilder();
            var error = new StringBuilder();

            Process cmd = new Process();

            cmd.OutputDataReceived += (o, eventArgs) => output.Append(eventArgs.Data + "\n");
            cmd.ErrorDataReceived += (o, eventArgs) => error.Append(eventArgs.Data + "\n");

            cmd.StartInfo = cmdInfo;
            cmd.Start();

            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();
            cmd.WaitForExit();
            cmd.Close();

            return error.ToString() + output.ToString();
        }

    }
}
