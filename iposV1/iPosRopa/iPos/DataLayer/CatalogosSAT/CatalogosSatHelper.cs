using iPosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;

namespace iPosData
{
    public class CatalogosSatHelper
    {
        public CatalogosSatHelper()
        {

        }

        private string conexion;

        public string Conexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        private CSAT_ADUANAD satAduanaDao;
        private CSAT_CODIGOPOSTALD satCodigoPostalDao;
        //private CSAT_FORMAPAGOD satFormaPagoDao;
        private CSAT_IMPUESTOD satImpuestoDao;
        private CSAT_METODOPAGOD satMetodoPagoDao;
        private CSAT_MONEDAD satMonedaDao;
        private CSAT_PAISD satPaisDao;
        private CSAT_PATENTEADUANALD satPatenteAduanalDao;
        private CSAT_PEDIMENTOSD satPedimientosDao;
        private CSAT_PRODUCTOSERVICIOD satProductoServicioDao;
        private CSAT_REGIMENFISCALD satRegimenFiscalDao;
        private CSAT_TASACUOTAD satTasaCuotaDao;
        private CSAT_TIPOCOMPROBANTED satTipoComprobanteDao;
        private CSAT_TIPOFACTORD satTipoFactorDao;
        private CSAT_TIPORELACIOND satTipoRelacionDao;
        private CSAT_UNIDADMEDIDAD satUnidadMedidaDao;
        private CSAT_USOCFDID satUsoCfdidDao;
        private CFORMAPAGOSATD satFormaPagoSatDao;

        private CSAT_CLAVETRANSPORTED satSAT_CLAVETRANSPORTEDao;
        private CSAT_TIPOESTACIOND satSAT_TIPOESTACIONDao;
        private CSAT_CLAVEUNIDADPESOD satSAT_CLAVEUNIDADPESODao;
        private CSAT_TIPOEMBALAJED satSAT_TIPOEMBALAJEDao;
        private CSAT_TIPOPERMISOD satSAT_TIPOPERMISODao;
        private CSAT_COLONIAD satSAT_COLONIADao;
        private CSAT_LOCALIDADD satSAT_LOCALIDADDao;
        private CSAT_MUNICIPIOD satSAT_MUNICIPIODao;
        private CSAT_PARTETRANSPORTED satSAT_PARTETRANSPORTEDao;
        private CSAT_FIGURATRANSPORTED satSAT_FIGURATRANSPORTEDao;
        private CSAT_CONFIGAUTOTRANSPORTED satSAT_CONFIGAUTOTRANSPORTEDao;
        private CSAT_SUBTIPOREMD satSAT_SUBTIPOREMDao;
        private CSAT_MATPELIGROSOD satSAT_MATPELIGROSODao;






        private bool m_bEsImportacionInicial = false;
        

        public bool ImportarCatalogos_2022(ref ArrayList strErrores, bool bEsImportacionInicial)
        {

            bool bSinErrores = true;
            //vamos a considerar todas las importaciones como si no fueran inciales para no eliminar datos ya existentes
            m_bEsImportacionInicial = false;//bEsImportacionInicial;



            //////SAT_CLAVETRANSPORTE
            satSAT_CLAVETRANSPORTEDao = new CSAT_CLAVETRANSPORTED(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_CLAVETRANSPORTE())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_CLAVETRANSPORTE " + this.iComentario);
            }

            //////SAT_TIPOESTACION
            satSAT_TIPOESTACIONDao = new CSAT_TIPOESTACIOND(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_TIPOESTACION())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TIPOESTACION " + this.iComentario);
            }

            //////SAT_CLAVEUNIDADPESO
            satSAT_CLAVEUNIDADPESODao = new CSAT_CLAVEUNIDADPESOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_CLAVEUNIDADPESO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_CLAVEUNIDADPESO " + this.iComentario);
            }

            //////SAT_TIPOEMBALAJE
            satSAT_TIPOEMBALAJEDao = new CSAT_TIPOEMBALAJED(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_TIPOEMBALAJE())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TIPOEMBALAJE " + this.iComentario);
            }

            //////SAT_TIPOPERMISO
            satSAT_TIPOPERMISODao = new CSAT_TIPOPERMISOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_TIPOPERMISO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TIPOPERMISO " + this.iComentario);
            }

            //////SAT_COLONIA
            satSAT_COLONIADao = new CSAT_COLONIAD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_COLONIA())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_COLONIA " + this.iComentario);
            }

            //////SAT_LOCALIDAD
            satSAT_LOCALIDADDao = new CSAT_LOCALIDADD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_LOCALIDAD())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_LOCALIDAD " + this.iComentario);
            }

            //////SAT_MUNICIPIO
            satSAT_MUNICIPIODao = new CSAT_MUNICIPIOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_MUNICIPIO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_MUNICIPIO " + this.iComentario);
            }

            //////SAT_PARTETRANSPORTE
            satSAT_PARTETRANSPORTEDao = new CSAT_PARTETRANSPORTED(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_PARTETRANSPORTE())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_PARTETRANSPORTE " + this.iComentario);
            }

            //////SAT_FIGURATRANSPORTE
            satSAT_FIGURATRANSPORTEDao = new CSAT_FIGURATRANSPORTED(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_FIGURATRANSPORTE())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_FIGURATRANSPORTE " + this.iComentario);
            }

            //////SAT_CONFIGAUTOTRANSPORTE
            satSAT_CONFIGAUTOTRANSPORTEDao = new CSAT_CONFIGAUTOTRANSPORTED(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_CONFIGAUTOTRANSPORTE())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_CONFIGAUTOTRANSPORT " + this.iComentario);
            }

            //////SAT_SUBTIPOREM
            satSAT_SUBTIPOREMDao = new CSAT_SUBTIPOREMD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_SUBTIPOREM())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_SUBTIPOREM " + this.iComentario);
            }
            

            return bSinErrores;
        }


        public bool ImportarCatalogos_2022_A(ref ArrayList strErrores, bool bEsImportacionInicial)
        {

            bool bSinErrores = true;
            //vamos a considerar todas las importaciones como si no fueran inciales para no eliminar datos ya existentes
            m_bEsImportacionInicial = false;// bEsImportacionInicial;

            //////SAT_MATPELIGROSO
            satSAT_MATPELIGROSODao = new CSAT_MATPELIGROSOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarSAT_MATPELIGROSO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_MATPELIGROSO " + this.iComentario);
            }

            return bSinErrores;
        }

            public bool ImportarCatalogos(ref ArrayList strErrores, bool bEsImportacionInicial)
        {

            bool bSinErrores = true;


            //vamos a considerar todas las importaciones como si no fueran inciales para no eliminar datos ya existentes
            m_bEsImportacionInicial = false;//bEsImportacionInicial;
            

            //////aduana
            satAduanaDao = new CSAT_ADUANAD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_ADUANA())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los bancos " + this.iComentario);
            }

            ////codigo postal
            satCodigoPostalDao = new CSAT_CODIGOPOSTALD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_CODIGOPOSTAL())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los bancos " + this.iComentario);
            }


            //////FORMAPAGOSAT
            satFormaPagoSatDao = new CFORMAPAGOSATD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!this.importarFORMAPAGOSAT())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_FORMAPAGO " + this.iComentario);
            }


            //////SAT_IMPUESTO
            satImpuestoDao = new CSAT_IMPUESTOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_IMPUESTO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_IMPUESTO " + this.iComentario);
            }

            //////SAT_METODOPAGO
            satMetodoPagoDao = new CSAT_METODOPAGOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_METODOPAGO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_METODOPAGO " + this.iComentario);
            }

            //////SAT_MONEDA
            satMonedaDao = new CSAT_MONEDAD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_MONEDA())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_MONEDA " + this.iComentario);
            }

            //////SAT_PAIS
            satPaisDao = new CSAT_PAISD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_PAIS())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_PAIS " + this.iComentario);
            }

            //////SAT_PATENTEADUANAL
            satPatenteAduanalDao = new CSAT_PATENTEADUANALD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_PATENTEADUANAL())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_PATENTEADUANAL " + this.iComentario);
            }

            ////SAT_PEDIMENTOS
            satPedimientosDao = new CSAT_PEDIMENTOSD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_PEDIMENTOS())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_PEDIMENTOS " + this.iComentario);
            }

            ////SAT_PRODUCTOSERVICIO
            satProductoServicioDao = new CSAT_PRODUCTOSERVICIOD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_PRODUCTOSERVICIO())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_PRODUCTOSERVICIOS " + this.iComentario);
            }

            ////SAT_REGIMENFISCAL
            satRegimenFiscalDao = new CSAT_REGIMENFISCALD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_REGIMENFISCAL())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_REGIMENFISCAL " + this.iComentario);
            }

            ////SAT_TASACUOTA
            satTasaCuotaDao = new CSAT_TASACUOTAD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_TASACUOTA())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TASACUOTA " + this.iComentario);
            }

            ////SAT_TIPOCOMPROBANTE
            satTipoComprobanteDao = new CSAT_TIPOCOMPROBANTED(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_TIPOCOMPROBANTE())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TIPOCOMPROBANTE " + this.iComentario);
            }

            ////SAT_FACTOR
            satTipoFactorDao = new CSAT_TIPOFACTORD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_TIPOFACTOR())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TIPOFACTOR " + this.iComentario);
            }

            ////SAT_TIPORELACION
            satTipoRelacionDao = new CSAT_TIPORELACIOND(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_TIPORELACION())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_TIPORELACION " + this.iComentario);
            }


            ////SAT_UNIDADMEDIDA
            satUnidadMedidaDao = new CSAT_UNIDADMEDIDAD(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_UNIDADMEDIDA())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_UNIDADMEDIDA" + this.iComentario);
            }


            //SAT_USOCFDI
            satUsoCfdidDao = new CSAT_USOCFDID(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            if (!importarSAT_USOCFDI())
            {
                bSinErrores = false;
                strErrores.Add("Error al importar los SAT_USOCFDI " + this.iComentario);
            }



            return bSinErrores;
        }

        /** Posible seccion MLG*/
        // Ya es decision de ustedes ver si aqui se hace la lectura de la bd de los catalogos de sat.. por mientras la hare aqui


        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }


        /**
         * En esta primera importacion, todo va a ser agregar en teoria pero lo dejaremos preparado por si despues hay otra importacion
         * Por ello consideraremos el caso de que el registro ya exista en nuestra base de datos
         * */
        public bool importarSAT_ADUANA()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_ADUANA";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_ADUANABE retorno = new CSAT_ADUANABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_ADUANABE itemBuffer = new CSAT_ADUANABE();

            CSAT_ADUANAD itemD = satAduanaDao; 



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_ADUANA");
                }
               
                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_ADUANABE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["SAT_CLAVEADUANA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEADUANA = ((string)(drSat["SAT_CLAVEADUANA"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_ADUANA_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }
                    if (drSat["SAT_CLAVEADUANA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEADUANA = ((string)(drSat["SAT_CLAVEADUANA"])).Trim();
                    }
                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = ((string)(drSat["SAT_DESCRIPCION"])).Trim();
                    }               




                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_ADUANAD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_ADUANAD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }



        public bool importarSAT_CODIGOPOSTAL()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_CODIGOPOSTAL";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_CODIGOPOSTALBE retorno = new CSAT_CODIGOPOSTALBE();
            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fTrans = null;
            CSAT_CODIGOPOSTALBE itemBuffer = new CSAT_CODIGOPOSTALBE();

            CSAT_CODIGOPOSTALD itemD = satCodigoPostalDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_CODIGOPOSTAL");
                }


                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_CODIGOPOSTALBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }


                    if (drSat["SAT_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_ESTADO = ((string)(drSat["SAT_ESTADO"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_CODIGOPOSTAL_X_CLAVE_X_ESTADO(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["SAT_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIO = ((string)(drSat["SAT_MUNICIPIO"])).Trim();
                    }
                    if (drSat["SAT_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDAD = ((string)(drSat["SAT_LOCALIDAD"])).Trim();
                    }               




                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_CODIGOPOSTALD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_CODIGOPOSTALD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }








        public bool importarFORMAPAGOSAT()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_FORMAPAGO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CFORMAPAGOSATBE retorno = new CFORMAPAGOSATBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CFORMAPAGOSATBE itemBuffer = new CFORMAPAGOSATBE();

            CFORMAPAGOSATD itemD = satFormaPagoSatDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {



                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CFORMAPAGOSATBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["SAT_CLAVE"])).Trim().PadLeft(2,'0');

                        retorno.IID = long.Parse(retorno.ICLAVE);
                    }


                    itemBuffer = itemD.seleccionarFORMAPAGOSATXClave(retorno, null);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                    }

                    retorno.IACTIVO = "S";


                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(drSat["SAT_DESCRIPCION"])).Trim();
                    }
                    if (drSat["SAT_BANCARIZADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_BANCARIZADO = ((string)(drSat["SAT_BANCARIZADO"])).Trim();
                    }
                    if (drSat["SAT_NUMOPERACION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NUMOPERACION = ((string)(drSat["SAT_NUMOPERACION"])).Trim();
                    }
                    if (drSat["SAT_RFCEMISORORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RFCEMISORORDENANTE = ((string)(drSat["SAT_RFCEMISORORDENANTE"])).Trim();
                    }
                    if (drSat["SAT_CUENTAORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CUENTAORDENANTE = ((string)(drSat["SAT_CUENTAORDENANTE"])).Trim();
                    }
                    if (drSat["SAT_PATRONORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATRONORDENANTE = ((string)(drSat["SAT_PATRONORDENANTE"])).Trim();
                    }
                    if (drSat["SAT_RFCEMISORBENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RFCEMISORBENEFICIARIO = ((string)(drSat["SAT_RFCEMISORBENEFICIARIO"])).Trim();
                    }
                    if (drSat["SAT_CUENTABENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CUENTABENEFICIARIO = ((string)(drSat["SAT_CUENTABENEFICIARIO"])).Trim();
                    }
                    if (drSat["SAT_PATRONBENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATRONBENEFICIARIO = ((string)(drSat["SAT_PATRONBENEFICIARIO"])).Trim();
                    }
                    if (drSat["SAT_TIPOCADENAPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOCADENAPAGO = ((string)(drSat["SAT_TIPOCADENAPAGO"])).Trim();
                    }
                    if (drSat["SAT_BANCOEMISOR"] != System.DBNull.Value)
                    {
                        retorno.ISAT_BANCOEMISOR = ((string)(drSat["SAT_BANCOEMISOR"])).Trim();
                    }



                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarFORMAPAGOSATD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarFORMAPAGOSATD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {

                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }



        public bool importarSAT_IMPUESTO()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_IMPUESTO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_IMPUESTOBE retorno = new CSAT_IMPUESTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_IMPUESTOBE itemBuffer = new CSAT_IMPUESTOBE();

            CSAT_IMPUESTOD itemD = satImpuestoDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_IMPUESTO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();

                while (drSat.Read())
                {
                    retorno = new CSAT_IMPUESTOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }


                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_IMPUESTO_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }



                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }
                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = ((string)(drSat["SAT_DESCRIPCION"])).Trim();
                    }
                    if (drSat["SAT_RETENCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RETENCION = ((string)(drSat["SAT_RETENCION"])).Trim();
                    }
                    if (drSat["SAT_TRASLADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TRASLADO = ((string)(drSat["SAT_TRASLADO"])).Trim();
                    }
                    if (drSat["SAT_LOCALFEDERAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALFEDERAL = ((string)(drSat["SAT_LOCALFEDERAL"])).Trim();
                    }
                    if (drSat["SAT_ENTIDADAPLICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_ENTIDADAPLICA = ((string)(drSat["SAT_ENTIDADAPLICA"])).Trim();
                    }               



                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_IMPUESTOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_IMPUESTOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;

                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }

        public bool importarSAT_METODOPAGO()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_METODOPAGO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_METODOPAGOBE retorno = new CSAT_METODOPAGOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_METODOPAGOBE itemBuffer = new CSAT_METODOPAGOBE();

            CSAT_METODOPAGOD itemD = satMetodoPagoDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_METODOPAGO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_METODOPAGOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_METODOPAGO_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }
                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = ((string)(drSat["SAT_DESCRIPCION"])).Trim();
                    }               



                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_METODOPAGOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_METODOPAGOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }

        public bool importarSAT_MONEDA()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_MONEDA";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_MONEDABE retorno = new CSAT_MONEDABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_MONEDABE itemBuffer = new CSAT_MONEDABE();

            CSAT_MONEDAD itemD = satMonedaDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_MONEDA");
                }


                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_MONEDABE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }


                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_MONEDA_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    
                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = ((string)(drSat["SAT_DESCRIPCION"])).Trim();
                    }
                    if (drSat["SAT_DECIMALES"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DECIMALES = ((int)(drSat["SAT_DECIMALES"]));
                    }
                    if (drSat["SAT_VARIACION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VARIACION = ((string)(drSat["SAT_VARIACION"])).Trim();
                    }               




                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_MONEDAD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_MONEDAD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {

                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }

        public bool importarSAT_PAIS()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_PAIS";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_PAISBE retorno = new CSAT_PAISBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_PAISBE itemBuffer = new CSAT_PAISBE();

            CSAT_PAISD itemD = satPaisDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_PAIS");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_PAISBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((string)(drSat["SAT_CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_PAIS_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }



                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = ((string)(drSat["SAT_DESCRIPCION"])).Trim();
                    }
                    if (drSat["SAT_FORMATOCP"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FORMATOCP = ((string)(drSat["SAT_FORMATOCP"])).Trim();
                    }
                    if (drSat["SAT_FORMATORIT"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FORMATORIT = ((string)(drSat["SAT_FORMATORIT"])).Trim();
                    }
                    if (drSat["SAT_VALIDACIONRIT"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALIDACIONRIT = ((string)(drSat["SAT_VALIDACIONRIT"])).Trim();
                    }
                    if (drSat["SAT_AGRUPACIONES"] != System.DBNull.Value)
                    {
                        retorno.ISAT_AGRUPACIONES = ((string)(drSat["SAT_AGRUPACIONES"])).Trim();
                    }               



                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_PAISD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_PAISD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }

        public bool importarSAT_PATENTEADUANAL()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_PATENTEADUANAL";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_PATENTEADUANALBE retorno = new CSAT_PATENTEADUANALBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_PATENTEADUANALBE itemBuffer = new CSAT_PATENTEADUANALBE();

            CSAT_PATENTEADUANALD itemD = satPatenteAduanalDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {


                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_PATENTEADUANAL");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_PATENTEADUANALBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = ((int)(drSat["SAT_CLAVE"]));
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_PATENTEADUANAL_X_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }



                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = ((DateTime)(drSat["SAT_FECHAINICIO"]));
                    }
                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = ((DateTime)(drSat["SAT_FECHAFIN"]));
                    }               


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_PATENTEADUANALD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_PATENTEADUANALD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_PEDIMENTOS()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_PEDIMENTOS";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_PEDIMENTOSBE retorno = new CSAT_PEDIMENTOSBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_PEDIMENTOSBE itemBuffer = new CSAT_PEDIMENTOSBE();

            CSAT_PEDIMENTOSD itemD = satPedimientosDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {


                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_PEDIMENTOS");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_PEDIMENTOSBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVEADUANA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEADUANA = ((int)(drSat["SAT_CLAVEADUANA"]));
                    }

                    if (drSat["SAT_PATENTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATENTE = ((int)(drSat["SAT_PATENTE"]));
                    }


                    if (drSat["SAT_EJERCICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_EJERCICIO = ((int)(drSat["SAT_EJERCICIO"]));
                    }

                    if (drSat["SAT_CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CANTIDAD = ((string)(drSat["SAT_CANTIDAD"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_PEDIMENTOS_X_CLAVE_X_PATENTE_X_EJERCICIO_X_CANT(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = ((DateTime)(drSat["SAT_FECHAINICIO"]));
                    }
                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = ((DateTime)(drSat["SAT_FECHAFIN"]));
                    }               



                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_PEDIMENTOSD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_PEDIMENTOSD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_PRODUCTOSERVICIO()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_PRODUCTOSERVICIO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_PRODUCTOSERVICIOBE retorno = new CSAT_PRODUCTOSERVICIOBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_PRODUCTOSERVICIOBE itemBuffer = new CSAT_PRODUCTOSERVICIOBE();

            CSAT_PRODUCTOSERVICIOD itemD = satProductoServicioDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_PRODUCTOSERVICIO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_PRODUCTOSERVICIOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVEPRODSERV"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEPRODSERV = drSat["SAT_CLAVEPRODSERV"].ToString();
                    }


                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_PRODUCTOSERVICIO_X_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = drSat["SAT_DESCRIPCION"].ToString();
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)drSat["SAT_FECHAINICIO"];
                    }

                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)drSat["SAT_FECHAFIN"];
                    }

                    if (drSat["SAT_IVATRASLADADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IVATRASLADADO = drSat["SAT_IVATRASLADADO"].ToString();
                    }

                    if (drSat["SAT_IEPSTRASLADADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IEPSTRASLADADO = drSat["SAT_IEPSTRASLADADO"].ToString();
                    }

                    if (drSat["SAT_COMPLEMENTO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COMPLEMENTO = drSat["SAT_COMPLEMENTO"].ToString();
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_PRODUCTOSERVICIOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_PRODUCTOSERVICIOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_REGIMENFISCAL()
        {


            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_REGIMENFISCAL";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_REGIMENFISCALBE retorno = new CSAT_REGIMENFISCALBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_REGIMENFISCALBE itemBuffer = new CSAT_REGIMENFISCALBE();

            CSAT_REGIMENFISCALD itemD = satRegimenFiscalDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {


                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_REGIMENFISCAL");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_REGIMENFISCALBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = drSat["SAT_CLAVE"].ToString();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_REGIMENFISCAL_X_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }


                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = drSat["SAT_DESCRIPCION"].ToString();
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)drSat["SAT_FECHAINICIO"];
                    }

                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)drSat["SAT_FECHAFIN"];
                    }

                    if (drSat["SAT_PERSONAFISICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAFISICA = drSat["SAT_PERSONAFISICA"].ToString();
                    }

                    if (drSat["SAT_PERSONAMORAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAMORAL = drSat["SAT_PERSONAMORAL"].ToString();
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_REGIMENFISCALD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_REGIMENFISCALD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_TASACUOTA()
        {

            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_TASACUOTA";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TASACUOTABE retorno = new CSAT_TASACUOTABE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_TASACUOTABE itemBuffer = new CSAT_TASACUOTABE();

            CSAT_TASACUOTAD itemD = satTasaCuotaDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TASACUOTA");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_TASACUOTABE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_RANGOFIJO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RANGOFIJO = drSat["SAT_RANGOFIJO"].ToString();
                    }

                    if (drSat["SAT_VALORMINIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMINIMO = (decimal)drSat["SAT_VALORMINIMO"];
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)drSat["SAT_FECHAINICIO"];
                    }

                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)drSat["SAT_FECHAFIN"];
                    }

                    if (drSat["SAT_VALORMAXIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMAXIMO = (decimal)drSat["SAT_VALORMAXIMO"];
                    }

                    if (drSat["SAT_IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IMPUESTO = drSat["SAT_IMPUESTO"].ToString();
                    }

                    if (drSat["SAT_FACTOR"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FACTOR = drSat["SAT_FACTOR"].ToString();
                    }

                    if (drSat["SAT_TRASLADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TRASLADO = drSat["SAT_TRASLADO"].ToString();
                    }

                    if (drSat["SAT_RETENCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RETENCION = drSat["SAT_RETENCION"].ToString();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TASACUOTA_X_SAT_RANGOFIJO_SAT_VALORMAXIMO_SAT_IMPUESTO_SAT_FACTOR(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TASACUOTAD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TASACUOTAD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_TIPOCOMPROBANTE()
        {

            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_TIPOCOMPROBANTE";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TIPOCOMPROBANTEBE retorno = new CSAT_TIPOCOMPROBANTEBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_TIPOCOMPROBANTEBE itemBuffer = new CSAT_TIPOCOMPROBANTEBE();

            CSAT_TIPOCOMPROBANTED itemD = satTipoComprobanteDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {


                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TIPOCOMPROBANTE");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_TIPOCOMPROBANTEBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = drSat["SAT_CLAVE"].ToString();
                    }


                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TIPOCOMPROBANTE_X_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }

                    }

                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = drSat["SAT_DESCRIPCION"].ToString();
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)drSat["SAT_FECHAINICIO"];
                    }

                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)drSat["SAT_FECHAFIN"];
                    }

                    if (drSat["SAT_NS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NS = drSat["SAT_NS"].ToString();
                    }

                    if (drSat["SAT_NDS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NDS = drSat["SAT_NDS"].ToString();
                    }

                    if (drSat["SAT_VALORMAXIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMAXIMO = (int)drSat["SAT_VALORMAXIMO"];
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TIPOCOMPROBANTED(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TIPOCOMPROBANTED(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_TIPOFACTOR()
        {

            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_TIPOFACTOR";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TIPOFACTORBE retorno = new CSAT_TIPOFACTORBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_TIPOFACTORBE itemBuffer = new CSAT_TIPOFACTORBE();

            CSAT_TIPOFACTORD itemD = satTipoFactorDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TIPOFACTOR");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_TIPOFACTORBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = drSat["SAT_CLAVE"].ToString();
                    }


                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TIPOFACTOR_X_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TIPOFACTORD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TIPOFACTORD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_TIPORELACION()
        {

            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_TIPORELACION";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TIPORELACIONBE retorno = new CSAT_TIPORELACIONBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_TIPORELACIONBE itemBuffer = new CSAT_TIPORELACIONBE();

            CSAT_TIPORELACIOND itemD = satTipoRelacionDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {


                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TIPORELACION");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_TIPORELACIONBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = drSat["SAT_CLAVE"].ToString();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TIPORELACION_X_SAT_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }


                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = drSat["SAT_DESCRIPCION"].ToString();
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TIPORELACIOND(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TIPORELACIOND(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_UNIDADMEDIDA()
        {

            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_UNIDADMEDIDA";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_UNIDADMEDIDABE retorno = new CSAT_UNIDADMEDIDABE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_UNIDADMEDIDABE itemBuffer = new CSAT_UNIDADMEDIDABE();

            CSAT_UNIDADMEDIDAD itemD = satUnidadMedidaDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if(m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_UNIDADMEDIDA");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_UNIDADMEDIDABE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVEUNIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = drSat["SAT_CLAVEUNIDAD"].ToString();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_UNIDADMEDIDA_X_SAT_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["SAT_NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NOMBRE = drSat["SAT_NOMBRE"].ToString();
                    }

                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = drSat["SAT_DESCRIPCION"].ToString();
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)drSat["SAT_FECHAINICIO"];
                    }

                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)drSat["SAT_FECHAFIN"];
                    }

                    if (drSat["SAT_SIMBOLO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_SIMBOLO = drSat["SAT_SIMBOLO"].ToString();
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_UNIDADMEDIDAD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_UNIDADMEDIDAD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        public bool importarSAT_USOCFDI()
        {

            string strConexionSat = ConexionesBD.ConexionCatSat.ConexionString();

            string CmdTxt = "SELECT * FROM SAT_USOCFDI";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_USOCFDIBE retorno = new CSAT_USOCFDIBE();
            //FbConnection fConn = new FbConnection();
            //FbTransaction fTrans = null;
            CSAT_USOCFDIBE itemBuffer = new CSAT_USOCFDIBE();

            CSAT_USOCFDID itemD = satUsoCfdidDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {

                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_USOCFDI");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (drSat.Read())
                {
                    retorno = new CSAT_USOCFDIBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;


                    if (drSat["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = drSat["SAT_CLAVE"].ToString();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_USOCFDI_X_CLAVE(retorno, null);


                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = drSat["SAT_DESCRIPCION"].ToString();
                    }


                    if (drSat["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)drSat["SAT_FECHAINICIO"];
                    }

                    if (drSat["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)drSat["SAT_FECHAFIN"];
                    }

                    if (drSat["SAT_PERSONAFISICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAFISICA= drSat["SAT_PERSONAFISICA"].ToString();
                    }

                    if (drSat["SAT_PERSONAMORAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAMORAL = drSat["SAT_PERSONAMORAL"].ToString();
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_USOCFDID(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_USOCFDID(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;
        }

        /** Fin posible seccion MLG*/



        /** seccion importacion 2022*/

        public bool importarSAT_CLAVETRANSPORTE()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_CLAVETRANSPORTE";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_CLAVETRANSPORTEBE retorno = new CSAT_CLAVETRANSPORTEBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_CLAVETRANSPORTEBE itemBuffer = new CSAT_CLAVETRANSPORTEBE();

            CSAT_CLAVETRANSPORTED itemD = satSAT_CLAVETRANSPORTEDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_CLAVETRANSPORTE");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_CLAVETRANSPORTEBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_CLAVETRANSPORTE_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_CLAVETRANSPORTED(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_CLAVETRANSPORTED(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_TIPOESTACION()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_TIPOESTACION";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TIPOESTACIONBE retorno = new CSAT_TIPOESTACIONBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_TIPOESTACIONBE itemBuffer = new CSAT_TIPOESTACIONBE();

            CSAT_TIPOESTACIOND itemD = satSAT_TIPOESTACIONDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TIPOESTACION");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_TIPOESTACIONBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TIPOESTACION_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["CLAVESTRANSPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESTRANSPORTE = ((string)(drSat["CLAVESTRANSPORTE"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TIPOESTACIOND(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TIPOESTACIOND(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_CLAVEUNIDADPESO()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_CLAVEUNIDADPESO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_CLAVEUNIDADPESOBE retorno = new CSAT_CLAVEUNIDADPESOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_CLAVEUNIDADPESOBE itemBuffer = new CSAT_CLAVEUNIDADPESOBE();

            CSAT_CLAVEUNIDADPESOD itemD = satSAT_CLAVEUNIDADPESODao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_CLAVEUNIDADPESO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_CLAVEUNIDADPESOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_CLAVEUNIDADPESO_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(drSat["NOMBRE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["NOTA"] != System.DBNull.Value)
                    {
                        retorno.INOTA = ((string)(drSat["NOTA"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }

                    if (drSat["SIMBOLO"] != System.DBNull.Value)
                    {
                        retorno.ISIMBOLO = ((string)(drSat["SIMBOLO"])).Trim();
                    }

                    if (drSat["BANDERA"] != System.DBNull.Value)
                    {
                        retorno.IBANDERA = ((string)(drSat["BANDERA"])).Trim();
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_CLAVEUNIDADPESOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_CLAVEUNIDADPESOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_TIPOEMBALAJE()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_TIPOEMBALAJE";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TIPOEMBALAJEBE retorno = new CSAT_TIPOEMBALAJEBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_TIPOEMBALAJEBE itemBuffer = new CSAT_TIPOEMBALAJEBE();

            CSAT_TIPOEMBALAJED itemD = satSAT_TIPOEMBALAJEDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TIPOEMBALAJE");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_TIPOEMBALAJEBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TIPOEMBALAJE_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TIPOEMBALAJED(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TIPOEMBALAJED(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_TIPOPERMISO()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_TIPOPERMISO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_TIPOPERMISOBE retorno = new CSAT_TIPOPERMISOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_TIPOPERMISOBE itemBuffer = new CSAT_TIPOPERMISOBE();

            CSAT_TIPOPERMISOD itemD = satSAT_TIPOPERMISODao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_TIPOPERMISO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_TIPOPERMISOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_TIPOPERMISO_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["CLAVETRANSPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVETRANSPORTE = ((string)(drSat["CLAVETRANSPORTE"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_TIPOPERMISOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_TIPOPERMISOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_COLONIA()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_COLONIA";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_COLONIABE retorno = new CSAT_COLONIABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_COLONIABE itemBuffer = new CSAT_COLONIABE();

            CSAT_COLONIAD itemD = satSAT_COLONIADao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_COLONIA");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_COLONIABE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = ((string)(drSat["COLONIA"])).Trim();
                    }

                    if (drSat["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = ((string)(drSat["CODIGOPOSTAL"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_COLONIA_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = ((string)(drSat["COLONIA"])).Trim();
                    }

                    if (drSat["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = ((string)(drSat["CODIGOPOSTAL"])).Trim();
                    }

                    if (drSat["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(drSat["NOMBRE"])).Trim();
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_COLONIAD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_COLONIAD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_LOCALIDAD()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_LOCALIDAD";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_LOCALIDADBE retorno = new CSAT_LOCALIDADBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_LOCALIDADBE itemBuffer = new CSAT_LOCALIDADBE();

            CSAT_LOCALIDADD itemD = satSAT_LOCALIDADDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_LOCALIDAD");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_LOCALIDADBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_LOCALIDAD = ((string)(drSat["CLAVE_LOCALIDAD"])).Trim();
                    }

                    if (drSat["CLAVE_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_ESTADO = ((string)(drSat["CLAVE_ESTADO"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_LOCALIDAD_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_LOCALIDAD = ((string)(drSat["CLAVE_LOCALIDAD"])).Trim();
                    }

                    if (drSat["CLAVE_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_ESTADO = ((string)(drSat["CLAVE_ESTADO"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_LOCALIDADD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_LOCALIDADD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_MUNICIPIO()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_MUNICIPIO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_MUNICIPIOBE retorno = new CSAT_MUNICIPIOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_MUNICIPIOBE itemBuffer = new CSAT_MUNICIPIOBE();

            CSAT_MUNICIPIOD itemD = satSAT_MUNICIPIODao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_MUNICIPIO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_MUNICIPIOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_MUNICIPIO = ((string)(drSat["CLAVE_MUNICIPIO"])).Trim();
                    }

                    if (drSat["CLAVE_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_ESTADO = ((string)(drSat["CLAVE_ESTADO"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_MUNICIPIO_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_MUNICIPIO = ((string)(drSat["CLAVE_MUNICIPIO"])).Trim();
                    }

                    if (drSat["CLAVE_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_ESTADO = ((string)(drSat["CLAVE_ESTADO"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_MUNICIPIOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_MUNICIPIOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_PARTETRANSPORTE()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_PARTETRANSPORTE";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_PARTETRANSPORTEBE retorno = new CSAT_PARTETRANSPORTEBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_PARTETRANSPORTEBE itemBuffer = new CSAT_PARTETRANSPORTEBE();

            CSAT_PARTETRANSPORTED itemD = satSAT_PARTETRANSPORTEDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_PARTETRANSPORTE");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_PARTETRANSPORTEBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_PARTETRANSPORTE_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_PARTETRANSPORTED(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_PARTETRANSPORTED(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_FIGURATRANSPORTE()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_FIGURATRANSPORTE";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_FIGURATRANSPORTEBE retorno = new CSAT_FIGURATRANSPORTEBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_FIGURATRANSPORTEBE itemBuffer = new CSAT_FIGURATRANSPORTEBE();

            CSAT_FIGURATRANSPORTED itemD = satSAT_FIGURATRANSPORTEDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_FIGURATRANSPORTE");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_FIGURATRANSPORTEBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_FIGURATRANSPORTE_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_FIGURATRANSPORTED(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_FIGURATRANSPORTED(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_CONFIGAUTOTRANSPORTE()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_CONFIGAUTOTRANSPORTE";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_CONFIGAUTOTRANSPORTEBE retorno = new CSAT_CONFIGAUTOTRANSPORTEBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_CONFIGAUTOTRANSPORTEBE itemBuffer = new CSAT_CONFIGAUTOTRANSPORTEBE();

            CSAT_CONFIGAUTOTRANSPORTED itemD = satSAT_CONFIGAUTOTRANSPORTEDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_CONFIGAUTOTRANSPORTE");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_CONFIGAUTOTRANSPORTEBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_CONFIGAUTOTRANSPORTE_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["NUMEROEJES"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEJES = ((string)(drSat["NUMEROEJES"])).Trim();
                    }

                    if (drSat["NUMEROLLANTAS"] != System.DBNull.Value)
                    {
                        retorno.INUMEROLLANTAS = ((string)(drSat["NUMEROLLANTAS"])).Trim();
                    }

                    if (drSat["REMOLQUE"] != System.DBNull.Value)
                    {
                        retorno.IREMOLQUE = ((string)(drSat["REMOLQUE"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_CONFIGAUTOTRANSPORTED(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_CONFIGAUTOTRANSPORTED(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_SUBTIPOREM()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_SUBTIPOREM";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_SUBTIPOREMBE retorno = new CSAT_SUBTIPOREMBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_SUBTIPOREMBE itemBuffer = new CSAT_SUBTIPOREMBE();

            CSAT_SUBTIPOREMD itemD = satSAT_SUBTIPOREMDao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_SUBTIPOREM");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_SUBTIPOREMBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_SUBTIPOREM_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }


                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_SUBTIPOREMD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_SUBTIPOREMD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        public bool importarSAT_MATPELIGROSO()
        {
            string strConexionSat = ConexionesBD.ConexionCatSat.Conexion_2022_String();

            string CmdTxt = "SELECT * FROM SAT_MATPELIGROSO";

            FbDataReader drSat = null;
            FbConnection pcnSat = null;

            CSAT_MATPELIGROSOBE retorno = new CSAT_MATPELIGROSOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            CSAT_MATPELIGROSOBE itemBuffer = new CSAT_MATPELIGROSOBE();

            CSAT_MATPELIGROSOD itemD = satSAT_MATPELIGROSODao;



            int iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;
            bool bResult;


            try
            {
                if (m_bEsImportacionInicial)
                {
                    this.deleteAllFromTabla("SAT_MATPELIGROSO");
                }

                drSat = SqlHelper.ExecuteReader(strConexionSat, CommandType.Text, CmdTxt, out pcnSat, null);


                fConn.Open();
                while (drSat.Read())
                {
                    retorno = new CSAT_MATPELIGROSOBE();
                    iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperAgregar;

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (!m_bEsImportacionInicial)
                    {
                        itemBuffer = itemD.seleccionarSAT_MATPELIGROSO_X_CLAVE(retorno, null);
                        if (itemBuffer != null)
                        {
                            retorno = itemBuffer;
                            iOperation = (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar;
                        }
                    }

                    if (drSat["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(drSat["CLAVE"])).Trim();
                    }

                    if (drSat["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(drSat["DESCRIPCION"])).Trim();
                    }

                    if (drSat["CLASE"] != System.DBNull.Value)
                    {
                        retorno.ICLASE = ((string)(drSat["CLASE"])).Trim();
                    }

                    if (drSat["PELIGRO_SECUNDARIO"] != System.DBNull.Value)
                    {
                        retorno.IPELIGRO_SECUNDARIO = ((string)(drSat["PELIGRO_SECUNDARIO"])).Trim();
                    }

                    if (drSat["NOMBRE_TECNICO"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE_TECNICO = ((string)(drSat["NOMBRE_TECNICO"])).Trim();
                    }

                    if (drSat["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(drSat["FECHAINICIO"]));
                    }

                    if (drSat["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(drSat["FECHAFIN"]));
                    }

                    if (iOperation == (int)DataLayer.Importaciones.ImportarDBF.DBOperations.OperCambiar)
                        bResult = itemD.CambiarSAT_MATPELIGROSOD(retorno, retorno, null);
                    else
                        bResult = (itemD.AgregarSAT_MATPELIGROSOD(retorno, null) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fConn.Close();
                        return false;
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);
            }
            catch (Exception ex)
            {
                fConn.Close();

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(drSat, pcnSat);

                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        /**  fin seccion importacion 2022 */


        public bool deleteAllFromTabla(string tableName)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();


                string commandText = @"  Delete from  " + tableName;

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionStringPoolingForced(), CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



    }
}
