using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Security.Permissions;

using iPosData;
using iPosBusinessEntity;

namespace iPos
{
    public class HiloMovil3
    {
        Thread p1;
        bool m_bSolicitudDeAbortar = false;

        bool bHiloSistemaApartado = false;
        CHILOSISTEMABE hiloSistemaBE = new CHILOSISTEMABE();
        public HiloMovil3()
        {
            p1 = new Thread(new ThreadStart(Movil3Sincronizar));
        }

        ~HiloMovil3()  // destructor
        {
            // cleanup statements...

        }

        public void IniciarHiloMovil3()
        {
            p1.Start();
        }

        //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerHiloMovil3()
        {
            m_bSolicitudDeAbortar = true;

            CHILOSISTEMAD hiloSistemaD = new CHILOSISTEMAD();
            if (bHiloSistemaApartado)
                hiloSistemaD.DesApartarHiloSistema(hiloSistemaBE, null);

            //p1.Interrupt();
            if (!p1.Join(1000))
            { // or an agreed resonable time
                p1.Abort();
            }
        }
        public void Movil3Sincronizar()
        {

            if(CurrentUserID.CurrentParameters.IMOVIL_TIENEVENDEDORES == null || !CurrentUserID.CurrentParameters.IMOVIL_TIENEVENDEDORES.Equals("S") ||
                !iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S") || 
                (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 4) || 
                (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")))
            {
                return;
            }

            CHILOSISTEMAD hiloSistemaD = new CHILOSISTEMAD();

            hiloSistemaBE = new CHILOSISTEMABE();
            hiloSistemaBE.ICLAVE = "MOVIL3";
            hiloSistemaBE.IRANDOM = System.Guid.NewGuid().ToString();



            while (!m_bSolicitudDeAbortar)
            {

                try
                {


                    bHiloSistemaApartado = hiloSistemaD.ApartarHiloSistema(hiloSistemaBE, null);
                    if (bHiloSistemaApartado)
                    {
                        string comentario = "";
                        bool bRes = iPos.Movil.Movil3Sync.ObtenerDatosDelServer(ref comentario);

                        bRes = iPos.Movil.Movil3Sync.procesarVentasAutomaticas(ref comentario);

                        bRes = iPos.Movil.Movil3Sync.procesarComprasAutomaticas(ref comentario);
                    }



                }
                catch(Exception ex)
                {
                    Console.WriteLine("Hilo movil " + ex.Message);
                }



                Thread.Sleep(60000);
            }

        }
    }
}

