using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace iPos
{
    public enum FastReportsTipoFile { deusuario, desistema };
    public class FastReportsConfig
    {
        public static string getPathForFile(string strFile, FastReportsTipoFile tipo)
        {
            if (ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA != null && ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA.Trim().Length > 0 )
            {
                switch (tipo)
                {
                    case FastReportsTipoFile.desistema:
                        if (File.Exists(ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\repocustomized\\fastreportssistema\\" + strFile))
                            return ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\repocustomized\\fastreportssistema\\" + strFile;
                        if (File.Exists(ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\fastreportssistema\\" + strFile))
                            return ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\fastreportssistema\\" + strFile;
                        break;

                    case FastReportsTipoFile.deusuario:
                        if (File.Exists(ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\repocustomized\\fastreports\\" + strFile))
                            return ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\repocustomized\\fastreports\\" + strFile;
                        if (File.Exists(ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\fastreports\\" + strFile))
                            return ConexionesBD.ConexionBD.CurrentParameters.IRUTAREPORTESSISTEMA + "\\fastreports\\" + strFile;
                        break;
                }
            }

            switch(tipo)
            {
                case FastReportsTipoFile.desistema:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\sampdata\\repocustomized\\fastreportssistema\\" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\sampdata\\repocustomized\\fastreportssistema\\" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\sampdata\\fastreportssistema\\" + strFile;

                case FastReportsTipoFile.deusuario:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\sampdata\\repocustomized\\fastreports\\" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\sampdata\\repocustomized\\fastreports\\" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\sampdata\\fastreports\\" + strFile;
            }

            return "";

        }

    }
}
