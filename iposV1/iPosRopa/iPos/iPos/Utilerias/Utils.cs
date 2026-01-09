using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPos.Utilerias
{
    public class Utils
    {
        public static bool EjecutarReplicadorSiEstaInstalado( ref string mensaje)
        {
            mensaje = "";
                string replicadorExePath = !String.IsNullOrEmpty(CurrentUserID.CurrentParameters.IRUTAREPLICADOREXE) ? CurrentUserID.CurrentParameters.IRUTAREPLICADOREXE : @"C:\Replicador Ipos\ReplicadorIpos.exe";

                if (Process.GetProcessesByName("ReplicadorIpos").Length <= 0)
                {
                    if (File.Exists(replicadorExePath))
                    {
                        Process.Start(replicadorExePath);
                    }
                    else if (File.Exists(@"C:\Replicador Ipos\ReplicadorIpos.exe"))
                    {
                        Process.Start(@"C:\Replicador Ipos\ReplicadorIpos.exe");
                    }
                    else
                    {
                        mensaje = "No se encontro el ejecutable del Replicador, llame a Soporte!";
                        return false;
                    }

                }

            return true;
        }



        public static bool DetenerReplicadorSiEstaEjecutandose(ref string mensaje, ref bool estabaEjecutandose)
        {
            mensaje = "";
            estabaEjecutandose = false;

            if (Process.GetProcessesByName("ReplicadorIpos").Length <= 0)
            {
                return true;

            }


            estabaEjecutandose = true;
            try
            {
                foreach (Process proc in Process.GetProcessesByName("ReplicadorIpos"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }


            return true;
        }
    }
}
