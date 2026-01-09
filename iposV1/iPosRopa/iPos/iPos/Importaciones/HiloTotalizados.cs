using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Security.Permissions;
using iPosData;
using System.Security.Permissions;

namespace iPos
{
    public class HiloTotalizados
    {

        bool m_bSolicitudDeAbortar = false;

        Thread p1;

        public HiloTotalizados()
        {
            p1 = new Thread(new ThreadStart(ProcesaTotalizados));
        }

        ~HiloTotalizados()  // destructor
        {
            // cleanup statements...

        }

        public void IniciarHiloTotalizados()
        {
            p1.Start();
        }

       //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerHiloTotalizados()
        {
            m_bSolicitudDeAbortar = true;

            //p1.Interrupt();
            if (!p1.Join(1000))
            { // or an agreed resonable time
                p1.Abort();
            }
        }


        public void ProcesaTotalizados()
        {

            CTTLCONTROLD control = new CTTLCONTROLD();
            while (!m_bSolicitudDeAbortar)
            {

                try
                {
                    

                        if (CurrentUserID.CurrentParameters.IHABTOTALIZADOS != null && CurrentUserID.CurrentParameters.IHABTOTALIZADOS.Equals("S") && iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S"))
                        {

                            control.TTL_ACTUALIZAR(null);
                        }

                    Thread.Sleep(10800000);
                }
                catch
                {

                }
            }

        }
    }
}
