using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace iPos
{
    public class ErrorLog
    {
        public static void addLog(String logMessage)
        {
            try
            {
                string directorioBase = System.AppDomain.CurrentDomain.BaseDirectory + "//SystemData//";

                DirectoryInfo di = new DirectoryInfo(directorioBase);
                FileSystemInfo[] files = di.GetFileSystemInfos(DateTime.Now.ToString("yyyy-MM-dd")+ "_*");
                IOrderedEnumerable<FileSystemInfo> logFiles = files != null ? files.OrderByDescending(f => f.CreationTime) : null;

                string lastFilePath = logFiles != null && logFiles.Count() > 0 ? logFiles.First().FullName : null;

                if(lastFilePath != null )
                {

                    FileInfo lastFile = new FileInfo(lastFilePath);
                    if (lastFile.Length > 1000000)
                        lastFilePath = null;
                }

                if (lastFilePath == null || lastFilePath.Length == 0)
                    lastFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "//SystemData//" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + files.Length.ToString() + "_err.log";

                //if (System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "//SystemData//" + DateTime.Now.ToString("yyyy-MM-dd") + "err.log"))
                if (System.IO.File.Exists(lastFilePath))
                {
                    //using (FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "//SystemData//" + DateTime.Now.ToString("yyyy-MM-dd") + "err.log", FileMode.Append))
                    using (FileStream fs = new FileStream(lastFilePath, FileMode.Append))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(logMessage);
                        sw.Close();
                    }
                }
                else
                {
                    //elimina los archivos de mas de 7 dias
                    try
                    {
                        Directory.GetFiles(directorioBase)
                            .Select(f => new FileInfo(f))
                            .Where(f => f.LastWriteTime < DateTime.Now.AddDays(-7) && f.Name.Contains("err.log"))
                            .ToList()
                            .ForEach(f => f.Delete());

                    }
                    catch
                    {
                    }

                    //si para el dia de  hoy ya se ha superado 100 archivos, elimina el ultimo
                    if(logFiles != null && logFiles.Count() >= 100)
                    {
                        try
                        {

                            File.Delete(logFiles.Last().FullName);
                        }
                        catch
                        {

                        }
                    }
                    

                    //using (FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "//SystemData//" + DateTime.Now.ToString("yyyy-MM-dd") + "err.log", FileMode.OpenOrCreate))
                    using (FileStream fs = new FileStream(lastFilePath, FileMode.OpenOrCreate))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(logMessage);
                        sw.Close();
                    }
                }
            }
            catch
            {

            }

        }
    }
}
