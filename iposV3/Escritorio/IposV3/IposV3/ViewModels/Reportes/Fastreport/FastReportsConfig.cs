using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{
    public enum FastReportsTipoFile { deusuario, desistema };
    public class FastReportsConfig
    {
        public static string getPathForFile(string strFile, FastReportsTipoFile tipo)
        {
            

            //switch (tipo)
            //{
            //    case FastReportsTipoFile.desistema:
            //        if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreportssistema\\" + strFile))
            //            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreportssistema\\" + strFile;
            //        else
            //            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\fastreportssistema\\" + strFile;

            //    case FastReportsTipoFile.deusuario:
            //        if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreports\\" + strFile))
            //            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreports\\" + strFile;
            //        else
            //            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\fastreports\\" + strFile;
            //}

            switch (tipo)
            {
                case FastReportsTipoFile.desistema:
                    return "fastreportssistema/" + strFile;

                case FastReportsTipoFile.deusuario:
                    return "fastreports/" + strFile;
            }


            return "";

        }


        public static string getPathFrxForFile(string strFile, FastReportsTipoFile tipo)
        {

            switch (tipo)
            {
                case FastReportsTipoFile.desistema:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreportssistema\\" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreportssistema\\" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\fastreportssistema\\" + strFile;

                case FastReportsTipoFile.deusuario:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreports\\" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\repocustomized\\fastreports\\" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\assets\\fastreports\\" + strFile;
            }

            return "";

        }

    }
}
