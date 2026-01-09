using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Security.Permissions;

using iPosData;

namespace iPos
{
    public class HiloTest
    {
        Thread p1;
        private static long _IFLAGENVIARCONSUMIDOS = 0;

        public static long _IFLAGENVIAREXISTENCIASEVENTOS = 0;
        public static int _IFLAGENVIARINICIO = 1;

        public static int _IFLAGENVIARINVENTARIO = 0;

        public static long _IFLAGENVIARREGISTROTRASLAEVENTOS = 0;
        public static long _IFLAGENVIARREGISTROTRASLACONSUMIDOS = 0;
        public static int _IFLAGENVIARREGISTROTRASLAINICIO = 1;


        public static long _IFLAGRECEPCIONREGISTROTRASLAEVENTOS = 0;
        public static long _IFLAGRECEPCIONREGISTROTRASLACONSUMIDOS = 0;
        public static int _IFLAGRECEPCIONREGISTROTRASLAINICIO = 1;

        public static int _IFLAGENVIAREXISTENCIASMANUAL = 0;
        bool m_bSolicitudDeAbortar = false;

        public HiloTest()
        {
            p1 = new Thread(new ThreadStart(EnviaExistencias));
        }

        ~HiloTest()  // destructor
        {
            // cleanup statements...

        }

        public void IniciarHiloExistencias()
        {
            p1.Start();
        }

        //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerHiloExistencias()
        {
            m_bSolicitudDeAbortar = true;

            //p1.Interrupt();
            if (!p1.Join(1000))
            { // or an agreed resonable time
                p1.Abort();
            }
        }
        public void EnviaExistencias()
        {

            WebServiceIpos ws = new WebServiceIpos();
            bool bError = false;


            while (!m_bSolicitudDeAbortar)
            {

                try
                {
                    ws.EnviarInventarioTest(null);

                    

                }
                catch
                {

                }



                Thread.Sleep(500);
            }

        }
    }
}
