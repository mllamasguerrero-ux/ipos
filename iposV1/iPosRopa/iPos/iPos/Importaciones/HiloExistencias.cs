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
    public class HiloExistencias
    {
        Thread p1;
        private static long _IFLAGENVIARCONSUMIDOS = 0;

        public static long _IFLAGENVIAREXISTENCIASEVENTOS = 0;
        public static int _IFLAGENVIARINICIO = 1;

        public static int _IFLAGENVIARINVENTARIO= 0;

        public static long _IFLAGENVIARREGISTROTRASLAEVENTOS  = 0;
        public static long _IFLAGENVIARREGISTROTRASLACONSUMIDOS = 0;
        public static int _IFLAGENVIARREGISTROTRASLAINICIO = 1;


        public static long _IFLAGRECEPCIONREGISTROTRASLAEVENTOS = 0;
        public static long _IFLAGRECEPCIONREGISTROTRASLACONSUMIDOS = 0;
        public static int _IFLAGRECEPCIONREGISTROTRASLAINICIO = 1;

        public static int _IFLAGENVIAREXISTENCIASMANUAL = 0;
        bool m_bSolicitudDeAbortar = false;

        public HiloExistencias()
        {
            p1 = new Thread(new ThreadStart(EnviaExistencias));
        }

        ~HiloExistencias()  // destructor
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

            int iExtraWaitingRecTraslados = 0;
            int iExtraWaitingEnvioTraslados = 0;


            int iExtraWaitingProdPromoCaducados = 0;

            CDOCTOD doctoD = new CDOCTOD();

            while (!m_bSolicitudDeAbortar)
            {

                try
                {


                    //ajusta los productos de promocion que ya esten caducados
                    if (CurrentUserID.CurrentParameters.IMANEJAPRODUCTOSPROMOCION != null &&
                        CurrentUserID.CurrentParameters.IMANEJAPRODUCTOSPROMOCION.Equals("S"))
                    {
                        if (iExtraWaitingProdPromoCaducados <= 0)
                        {
                            doctoD.TRASLADOPROMOCION_AJUSTXFINVIG();
                            iExtraWaitingProdPromoCaducados = 600000;
                        }
                        else
                        {

                            iExtraWaitingEnvioTraslados -= 500;
                        }
                    }



                    if ((_IFLAGENVIARINICIO > 0 || (_IFLAGENVIAREXISTENCIASEVENTOS - _IFLAGENVIARCONSUMIDOS) > 0)
                        && iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S") && iPos.CurrentUserID.CurrentParameters.IENVIOAUTOMATICOEXISTENCIAS.Equals("S"))
                    {

                        lock (iPos.CurrentUserID.thisLock)
                        {
                            if (ws.EnviarExistencias(null))
                            {

                                if (_IFLAGENVIARINICIO > 0)
                                    _IFLAGENVIARINICIO = 0;

                                if ((_IFLAGENVIAREXISTENCIASEVENTOS - _IFLAGENVIARCONSUMIDOS) > 0)
                                    _IFLAGENVIARCONSUMIDOS++;
                            }
                            else
                            {
                                Thread.Sleep(300000);
                            }
                        }

                    }



                    if (_IFLAGENVIAREXISTENCIASMANUAL > 0 /*&& iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S")*/)
                    {
                        bError = false;
                        lock (iPos.CurrentUserID.thisLock)
                        {
                            if (ws.EnviarExistencias(null))
                            {
                                _IFLAGENVIAREXISTENCIASMANUAL--;
                                MessageBox.Show("todas la existencia de productos con movimientos fue exportado al sitio web");

                            }
                            else
                            {
                                bError = true;
                            }
                        }

                        if (bError)
                        {
                            MessageBox.Show("Ocurrio un error al intentar exportar las existencias " + ws.IComentario);
                            Thread.Sleep(300000);
                        }
                    }


                    if (_IFLAGENVIARINVENTARIO > 0 /*&& iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S")*/)
                    {
                        bError = false;
                        lock (iPos.CurrentUserID.thisLock)
                        {
                            if (ws.EnviarInventarioExist(null))
                            {
                                _IFLAGENVIARINVENTARIO--;
                                MessageBox.Show("todo el inventario fue exportado al sitio web");

                            }
                            else
                            {
                                bError = true;
                            }
                        }

                        if (bError)
                        {
                            MessageBox.Show("Ocurrio un error al intentar exportar las existencias " + ws.IComentario);
                            Thread.Sleep(300000);
                        }
                    }




                    //registrar traslados ENVIO


                    if (iExtraWaitingEnvioTraslados > 0)
                        iExtraWaitingEnvioTraslados -= 500;
                    else if (iExtraWaitingEnvioTraslados < 0)
                        iExtraWaitingEnvioTraslados = 0;

                    if ((_IFLAGENVIARREGISTROTRASLAINICIO > 0 || ((_IFLAGENVIARREGISTROTRASLAEVENTOS - _IFLAGENVIARREGISTROTRASLACONSUMIDOS) > 0))
                        && iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S")
                        && iExtraWaitingEnvioTraslados <= 0)
                    {
                        bError = false;
                        iExtraWaitingEnvioTraslados = 0;

                        lock (iPos.CurrentUserID.thisLock)
                        {
                            if (ws.RegistrarTralsados(null))
                            {


                                if (_IFLAGENVIARREGISTROTRASLAINICIO > 0)
                                    _IFLAGENVIARREGISTROTRASLAINICIO = 0;

                                if ((_IFLAGENVIARREGISTROTRASLAEVENTOS - _IFLAGENVIARREGISTROTRASLACONSUMIDOS) > 0)
                                    _IFLAGENVIARREGISTROTRASLACONSUMIDOS++;

                            }
                            else
                            {
                                bError = true;
                                iExtraWaitingEnvioTraslados = 600000;
                            }
                            //
                            iExtraWaitingEnvioTraslados += 60000;
                        }


                    }


                    //registrar traslados RECEPCION

                    if (iExtraWaitingRecTraslados > 0)
                        iExtraWaitingRecTraslados -= 500;
                    else if (iExtraWaitingRecTraslados < 0)
                        iExtraWaitingRecTraslados = 0;


                    if ((_IFLAGRECEPCIONREGISTROTRASLAINICIO > 0 || ((_IFLAGRECEPCIONREGISTROTRASLAEVENTOS - _IFLAGRECEPCIONREGISTROTRASLACONSUMIDOS) > 0))
                        && iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S")
                        && iExtraWaitingRecTraslados <= 0)
                    {
                        bError = false;
                        iExtraWaitingRecTraslados = 0;
                        lock (iPos.CurrentUserID.thisLock)
                        {
                            if (ws.RegistrarRecepcionTralsados(null))
                            {
                                if (ws.RegistrarIgnoramientoTralsados(null))
                                {

                                    if (_IFLAGRECEPCIONREGISTROTRASLAINICIO > 0)
                                        _IFLAGRECEPCIONREGISTROTRASLAINICIO = 0;

                                    if ((_IFLAGRECEPCIONREGISTROTRASLAEVENTOS - _IFLAGRECEPCIONREGISTROTRASLACONSUMIDOS) > 0)
                                        _IFLAGRECEPCIONREGISTROTRASLACONSUMIDOS++;
                                }
                                else
                                {
                                    bError = true;
                                    iExtraWaitingRecTraslados = 420000;
                                }

                            }
                            else
                            {
                                bError = true;
                                iExtraWaitingRecTraslados = 420000;
                            }

                            iExtraWaitingRecTraslados += 180000;
                        }

                    }

                }
                catch
                {

                }



                Thread.Sleep(500);
            }

        }
    }
}
