using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

using iPosData;
using System.Security.Permissions;
using System.Windows.Forms;
using iPos.Importaciones;
using System.Windows.Threading;
using iPosBusinessEntity;

namespace iPos
{
    class HiloDeImportaciones
    {
        Thread p1;
        bool m_bSolicitudDeAbortar = false;
        Dispatcher dispatcher;
        DateTime fechaPreguntarAplicarImportaciones;

        bool bHiloSistemaApartado = false;
        CHILOSISTEMABE hiloSistemaBE = new CHILOSISTEMABE();

        public HiloDeImportaciones()
        {
            this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            fechaPreguntarAplicarImportaciones = DateTime.MinValue;
            p1 = new Thread(new ThreadStart(ChecarArchivosAImportar));
        }

        ~HiloDeImportaciones()  // destructor
        {
            // cleanup statements...

        }

        public void IniciarImportacionDeArchivos()
        {
            p1.Start();
        }

        //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerImportacionDeArchivos()
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
        public void ChecarArchivosAImportar()
        {

            ImportaDesdeFtp ftpImporting = new ImportaDesdeFtp();
            ArrayList resultadosExportacion = new ArrayList();

            CDOCTOD doctoD = new CDOCTOD();

            CHILOSISTEMAD hiloSistemaD = new CHILOSISTEMAD();

            hiloSistemaBE = new CHILOSISTEMABE();
            hiloSistemaBE.ICLAVE = "IMPORTACIONES";
            hiloSistemaBE.IRANDOM = System.Guid.NewGuid().ToString();


            bool bProcesandoCampoPrecAuto = false;

            while (!m_bSolicitudDeAbortar)
            {

                //if (iPos.CurrentUserID.CurrentParameters.IHABILITAR_IMPEXP_AUT.Equals("S"))
                try
                {
                    
                    if (iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S"))
                    {
                        bHiloSistemaApartado = hiloSistemaD.ApartarHiloSistema(hiloSistemaBE, null);
                        if (bHiloSistemaApartado)
                        {

                            lock (iPos.CurrentUserID.thisLockImportaciones)
                            {
                                ftpImporting.DescargarArchivosDeFtp();

                                hiloSistemaD.ApartarHiloSistema(hiloSistemaBE, null);

                                if (CurrentUserID.CurrentCompania.IESMATRIZ == "S")
                                {
                                    //ErrorLog.addLog(Environment.NewLine + DateTime.Now.ToString() + " Proceso de importacion de archivos desde matriz ");
                                    ftpImporting.DescargarArchivosDeFtpDeMatriz();
                                }

                                hiloSistemaD.ApartarHiloSistema(hiloSistemaBE, null);

                                ftpImporting.EnvirArchivosYaGeneradosAFtp(ref resultadosExportacion);

                                hiloSistemaD.ApartarHiloSistema(hiloSistemaBE, null);


                                // si al variable de importacion automatica esta activa y hay catalogos a importar entonces importalos
                                if (CurrentUserID.CurrentParameters.IAPLICARCAMBIOSPRECAUTO.Equals("S")  && !bProcesandoCampoPrecAuto)
                                {
                                    CIMP_FILESD importacionesDao = new CIMP_FILESD();

                                    if (importacionesDao.HayImportacionesPendientes(CIMP_FILESD.FileType_Producto))
                                    {
                                        if (DateTime.Now >= fechaPreguntarAplicarImportaciones)
                                        {

                                            dispatcher.Invoke(new Action(() =>
                                            {

                                                bProcesandoCampoPrecAuto = true;
                                                

                                                WFConfirmarImportacion alerta_ = new WFConfirmarImportacion();
                                                alerta_.ShowDialog();
                                                bool processCompleted = alerta_.ProcessCompleted;
                                                bool importacionExitosa = alerta_.M_importacionExitosa;
                                                alerta_.Dispose();
                                                GC.SuppressFinalize(alerta_);


                                                if (!processCompleted)
                                                {
                                                    fechaPreguntarAplicarImportaciones = DateTime.Now.AddMinutes(1);
                                                }
                                                else if(!importacionExitosa)
                                                {

                                                    fechaPreguntarAplicarImportaciones = DateTime.Now.AddMinutes(20);
                                                }


                                                bProcesandoCampoPrecAuto = false;

                                            }));
                                        }
                                    }
                                }
                            }
                        }

                    }

                    //doctoD.ELIMINAR_BORRADORES_VIEJOS(DateTime.Today, null);
                }
                catch(Exception ex)
                {

                }

                int iSegundos = CurrentUserID.CurrentParameters.ISEGUNDOSCICLOFTP > 0 ? CurrentUserID.CurrentParameters.ISEGUNDOSCICLOFTP : 180;
                Thread.Sleep(/*60000*/ 1000 * iSegundos);
            }



        }
    }
}
