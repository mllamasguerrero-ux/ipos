using ConexionesBD;
using DataLayer.CatalogosSAT.businessEntity;
using DataLayer.Utilerias.bussinesData;
using DataLayer.Utilerias.Respuestas.CatalogoSat;
using FirebirdSql.Data.FirebirdClient;
using iPos.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace iPos.Threads
{
    public class CatalogoSatThread
    {
        private bool abort = false;
        private Thread proceso;
        private Dispatcher dispatcher;

        public CatalogoSatThread()
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            proceso = new Thread(new ThreadStart(ChecarNuevaVersion));
        }

        private CSAT_VERSIONCATALOGOBE ConvertirSatCatalogueInfo(SatCatalogueInfo catalogueInfo)
        {
           

            CSAT_VERSIONCATALOGOBE retorno = new CSAT_VERSIONCATALOGOBE();

            retorno.Date = catalogueInfo.Date;
            retorno.Status = catalogueInfo.Status;
            retorno.Version = catalogueInfo.Version;

            return retorno;
        }

        public void ChecarNuevaVersion()
        {
            while (!abort)
            {
                try
                {

                    if (iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S"))
                    {
                        WSCatalogoSat wsCatalogoSat = new WSCatalogoSat();

                        CSAT_VERSIONCATALOGOD versionCatalogoDao = new CSAT_VERSIONCATALOGOD(ConexionBD.ConexionStringPoolingForced());

                        CSAT_VERSIONCATALOGOBE versionCatalogoLocal = versionCatalogoDao.SeleccionarVersionInfo();

                        var ultimaVersonCatalogoSat = wsCatalogoSat.ObtenerUltimaVersion();

                        if (ultimaVersonCatalogoSat != null)
                        {

                            CSAT_VERSIONCATALOGOBE versionCatalogoWs = ConvertirSatCatalogueInfo(wsCatalogoSat.ObtenerUltimaVersion());

                            if (versionCatalogoLocal.Version < versionCatalogoWs.Version && (versionCatalogoWs.Status.Equals("F") || (versionCatalogoWs.Status.Equals("ERROR") && versionCatalogoWs.Version == 8)))
                            {
                                //FbConnection fbConnection = new FbConnection(ConexionBD.ConexionStringPoolingForced());
                                //FbTransaction fbTransaction = null;

                                try
                                {

                                    wsCatalogoSat = new WSCatalogoSat();
                                    List<TableData> cambios = wsCatalogoSat.ObtenerCambios(versionCatalogoLocal.Version, 1);

                                    DAOGenerico catalogoDAO = new DAOGenerico(ConexionBD.ConexionStringPoolingForced());
                                    //fbConnection.Open();
                                    //fbTransaction = fbConnection.BeginTransaction();
                                    foreach (TableData cambio in cambios)
                                    {
                                        if (cambio.Records.Count > 0)
                                        {
                                            if (!catalogoDAO.AgregarCambios(cambio, null/*fbTransaction*/))
                                            {
                                                throw new Exception(catalogoDAO.IComentario);
                                            }
                                        }

                                        long siguientePagina = cambio.NextPage;
                                        while (siguientePagina != 0)
                                        {
                                            TableData data = (TableData)wsCatalogoSat.ObtenerCambiosDeTabla(
                                                cambio.Name,
                                                siguientePagina,
                                                cambio.Version);

                                            if (!catalogoDAO.AgregarCambios(data, null/*fbTransaction*/))
                                            {
                                                throw new Exception(catalogoDAO.IComentario);
                                            }

                                            siguientePagina = data.NextPage;
                                        }
                                    }

                                    if (!versionCatalogoDao.ActualizarVersion(versionCatalogoWs, null/*fbTransaction*/))
                                    {
                                        throw new Exception(catalogoDAO.IComentario);
                                    }

                                    //fbTransaction.Commit();
                                }
                                catch (Exception e)
                                {
                                    //fbTransaction.Rollback();
                                    MessageBox.Show("Problema al actualizar catálogos del SAT", e.Message);
                                }
                                finally
                                {
                                    //fbConnection.Close();
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {

                    
                }


                Thread.Sleep(1 * 60 * 60 * 1000);
            }
        }

        public void IniciarProceso()
        {
            proceso.Start();
        }

        public void PararProceso()
        {
            abort = true;

            if (!proceso.Join(1000))
            {
                proceso.Abort();
            }
        }

        public bool IsAlive()
        {
            return proceso.IsAlive;
        }
    }
}
