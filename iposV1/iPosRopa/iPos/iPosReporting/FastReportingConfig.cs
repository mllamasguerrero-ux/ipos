using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iPosData;
using iPosBusinessEntity;


namespace iPosReporting
{
    public enum FastReportingTipoFile { deusuario, desistema };
    public class FastReportingConfig
    {
        public static string getPathForFile(string strFile, FastReportingTipoFile tipo)
        {
            CPARAMETROD parametro = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametro.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return "";
            }


            if (parametroBE.IRUTAREPORTESSISTEMA != null && parametroBE.IRUTAREPORTESSISTEMA.Trim().Length > 0)
            {
                switch (tipo)
                {
                    case FastReportingTipoFile.desistema:
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreportssistema//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreportssistema//" + strFile;
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//fastreportssistema//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//fastreportssistema//" + strFile;
                        break;

                    case FastReportingTipoFile.deusuario:
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreports//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreports//" + strFile;
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//fastreports//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//fastreports//" + strFile;
                        break;
                }
            }

            switch (tipo)
            {
                case FastReportingTipoFile.desistema:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreportssistema//" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreportssistema//" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//fastreportssistema//" + strFile;

                case FastReportingTipoFile.deusuario:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreports//" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreports//" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//fastreports//" + strFile;
            }

            return "";

        }


    }
}
