using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPos.Verifone
{
    public class VerifoneLogControl
    {
        private static string _Path = "VerifoneLogs";//string.Empty;
        private static bool DEBUG = true;

        private static DateTime? LastLogCleaning = null;

        

        public static void Write(string msg)
        {
            var currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            try
            {
                string folderPath = Path.Combine(currentDirectory, _Path);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                CleanOldLogsIfNeedd();


                string filePath = Path.Combine(folderPath, "log_" + DateTime.Now.ToString("yyyy_MM_dd")) +  ".txt";


                if (!File.Exists(filePath))
                    File.CreateText(filePath).Dispose();

                using (StreamWriter w = File.AppendText(filePath))
                {
                    Log(msg, w);
                }
                if (DEBUG)
                    Console.WriteLine(msg);
            }
            catch (Exception e)
            {
                //Handle
            }
        }

        static private void Log(string msg, TextWriter w)
        {
            try
            {
                w.Write(Environment.NewLine);
                w.Write("[{0} {1}]", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.Write("\t");
                w.WriteLine(" {0}", msg);
                w.WriteLine("-----------------------");
            }
            catch (Exception e)
            {
                //Handle
            }
        }

        static private void CleanOldLogsIfNeedd()
        {
            if(LastLogCleaning == null || DateTime.Compare( LastLogCleaning.Value.AddDays(2), DateTime.Today) <= 0)
            {

                string folderPath = Path.Combine(_Path);

                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastWriteTime < DateTime.Now.AddDays(-7))
                        fi.Delete();
                }

                LastLogCleaning = DateTime.Now;
            }
        }
    }
}
