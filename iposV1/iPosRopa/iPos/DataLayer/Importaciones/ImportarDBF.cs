using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using System.IO;
using System.Data.Common;

namespace DataLayer.Importaciones
{


    public class ImportarDBF
    {
        public enum DBOperations { OperAgregar, OperCambiar };
        private string iComentario;
        public const string PRODUCT_DBF_FILENAME = "PROD.dbf";
        public const string KITSUC_DBF_FILENAME = "M_KITSUC.dbf";
        public const string MARCA_DBF_FILENAME = "M_MARC.dbf";
        public const string LINEA_DBF_FILENAME = "M_LINE.dbf";
        public const string AREA_DBF_FILENAME = "M_AREA.dbf";
        public const string ARDR_DBF_FILENAME = "M_ARDR.dbf";
        public const string PROMOCION_DBF_FILENAME = "M_PROM.dbf";
        public const string PRM_DBF_FILENAME = "M_PRM.dbf";
        public const string PROVEEDOR_DBF_FILENAME = "M_PROV.dbf";
        public const string ENCARGADOCORTE_DBF_FILENAME = "M_ENCC.dbf";
        public const string SUCURSAL_DBF_FILENAME = "M_CATS.dbf";
        public const string PRODUCTPRECIOS_DBF_FILENAME = "F_PRO2.dbf";

        public const string KITS_DBF_FILENAME = "M_KITS.dbf";
        public const string PRODUCTPRECIOS_DBF_FILENAME_M = "M_PRO2.dbf";
        public const string TERM_DBF_FILENAME = "M_TERM.dbf";

        public const string PRODSUCURSAL_DBF_FILENAME = "M_PRSC.dbf";

        public const string LISTAPRECIOS_DBF_FILENAME = "M_LSPR.dbf";
        public const string LISTAPRECIODETALLE_DBF_FILENAME = "M_LPDT.dbf";
        public const string MAXFACT_DBF_FILENAME = "M_MXFT.dbf";


        public const string MERCH_DBF_FILENAME = "M_MERCH.dbf";
        public const string CLERK_DBF_FILENAME = "M_CLERK.dbf";

        public const string TASAIVA_DBF_FILENAME = "M_TASA.dbf";
        public const string GRUPOSUCURSAL_DBF_FILENAME = "M_GSUC.dbf";
        public const string DEFCARACTPROD_DBF_FILENAME = "M_DEFC.dbf";
        public const string EDOS_DBF_FILENAME = "M_EDOS.dbf";
        public const string BANK_DBF_FILENAME = "M_BANK.dbf";
        public const string UNIDAD_DBF_FILENAME = "M_UNI.dbf";


        public const string CONTENIDO_DBF_FILENAME = "M_IEPR.dbf";
        public const string CLASIFICA_DBF_FILENAME = "M_IECT.dbf";

        public const string GASTO_DBF_FILENAME = "M_GASTO.dbf";
        


        public const string MOTIVOSDEVOLUCION_DBF_FILENAME = "M_MOTD.dbf";

        public const string PRECTEMP_DBF_FILENAME = "PRECTEMP.dbf";

        public const string PLAZO_DBF_FILENAME = "M_PLAZO.dbf";

        public const string TRCL_DBF_FILENAME = "M_TRCL.dbf";


        public const string CLIENTEMOVIL_DBF_FILENAME = "M_CLIP.dbf";
        public const string CXCMOVIL_DBF_FILENAME = "M_CREP.dbf";

        public const string HISTORIAL_DBF_FILENAME = "M_PEDS.dbf";

        public const string CTRL_DBF_FILENAME = "M_CTRL.dbf";

        public const string TIPO_DBF_FILENAME = "M_TIPO.dbf";


        public const string DERECHO_DBF_FILENAME = "M_DER.dbf";
        public const string DERECHOUSUARIO_DBF_FILENAME = "M_DER_U.dbf";
        public const string USUARIO_DBF_FILENAME = "M_USER.dbf";
        public const string PARAMETRO_DBF_FILENAME = "M_PARM.dbf";

        public const string FileLocalLocation_RecCompras = "\\sampdata\\pedidos\\";
        public const string FileLocalLocation_Productos = "\\sampdata\\precios\\";
        public const string FileLocalLocation_Traslados = "\\sampdata\\TRASLA\\";
        public const string FileLocalLocation_ExistenciasGenerales = "\\sampdata\\ExistenciasGenerales\\";
        public const string FileLocalLocation_RecComprasAux = "\\sampdata\\pedidos_aux\\";
        public const string FileLocalLocation_TrasladosAux = "\\sampdata\\TRASLA_aux\\";
        public const string FileLocalLocation_PreciosTemp = "\\sampdata\\preciostemp\\";
        public const string FileLocalLocation_TrasladosDevo = "\\sampdata\\TRASLADEVO\\";
        public const string FileLocalLocation_PedidosDevo = "\\sampdata\\matriz\\devolucionessucursales";


        public const string FileLocalLocation_SolicitudMercaRecepcion = "\\sampdata\\solicitudMercaRecepcion\\";

        public const string FileLocalLocation_MatrizPedidosSucursales = "\\sampdata\\matriz\\pedidossucursales\\";


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
        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }
        string m_strDbfCadenaConexion;
        private string sCadenaConexion;

        public ImportarDBF()
        {
            m_strDbfCadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Documents and Settings\\manuel\\Mis documentos\\dbf\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            sCadenaConexion = ConexionBD.ConexionString();
        }


        public static string GetLocalLocation(short iTipo)
        {
            switch (iTipo)
            {
                case CIMP_FILESD.FileType_Producto:
                    if (ConexionBD.CurrentParameters.IRUTACATALOGOSUPD == null || ConexionBD.CurrentParameters.IRUTACATALOGOSUPD.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Productos;
                    else
                        return ConexionBD.CurrentParameters.IRUTACATALOGOSUPD + FileLocalLocation_Productos.Replace("\\sampdata", ""); ;

                case CIMP_FILESD.FileType_RecCompras:
                    if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_RecCompras;
                    else
                        return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_RecCompras.Replace("\\sampdata", "");

                case CIMP_FILESD.FileType_Traslados:
                    if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Traslados;
                    else
                        return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_Traslados.Replace("\\sampdata", "");

                case CIMP_FILESD.FileType_ExistenciasGen: return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_ExistenciasGenerales;
                case CIMP_FILESD.FileType_RecComprasAux:
                    if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_RecComprasAux;
                    else
                        return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_RecComprasAux.Replace("\\sampdata", "");

                case CIMP_FILESD.FileType_TrasladosAux:
                    if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosAux;
                    else
                        return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_TrasladosAux.Replace("\\sampdata", "");

                case CIMP_FILESD.FileType_PreciosTemp:
                    return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_PreciosTemp;


                    if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_PreciosTemp;
                    else
                        return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_PreciosTemp.Replace("\\sampdata", "");


                case CIMP_FILESD.FileType_TrasladosDevo: return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosDevo;
                case CIMP_FILESD.FileType_PedidosDevo: return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_PedidosDevo;


                case CIMP_FILESD.FileType_SolicitudMercancia:
                    if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                        return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_SolicitudMercaRecepcion;
                    else
                        return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_SolicitudMercaRecepcion.Replace("\\sampdata", "");


                default: return "";
            }

        }



        public static string GetLocalLocationMatriz(short iTipo, string sucursalClave, CPARAMETROBE parametroBE)
        {
            switch (iTipo)
            {
                case CIMP_FILESD.FileType_MatrizPedidos:
                    {

                        return parametroBE.IPEDIDOS_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\" + sucursalClave + "\\";
                        //return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPedidosSucursales + sucursalClave + "\\";
                    }
                case CIMP_FILESD.FileType_SolicitudMercancia:
                    {
                        if (ConexionBD.CurrentParameters.IRUTAIMPORTADATOS == null || ConexionBD.CurrentParameters.IRUTAIMPORTADATOS.Trim().Length == 0)
                            return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_SolicitudMercaRecepcion;
                        else
                            return ConexionBD.CurrentParameters.IRUTAIMPORTADATOS + FileLocalLocation_SolicitudMercaRecepcion.Replace("\\sampdata", "");

                    }
                default: return "";
            }

        }



        public long GetSucursalID_DelArchivo(string nombreArchivo)
        {
            char[] char_Punto = { '.' };
            char[] char_Guion = { '_' };

            string[] buffSplit_Punto = nombreArchivo.Split(char_Punto);
            string[] buffSplit_GuionBajo = buffSplit_Punto[0].Split(char_Guion);
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            CSUCURSALD sucursalD = new CSUCURSALD();

            if (buffSplit_GuionBajo.Count() < 1)
                return 0;

            sucursalBE.ICLAVE = buffSplit_GuionBajo[1];
            sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, null);
            if (sucursalBE == null)
                return 0;
            else
                return sucursalBE.IID;

        }


        public string GetSucursalClave_DelArchivo(string nombreArchivo, long lGrupoSucursal)
        {
            char[] char_Punto = { '.' };
            char[] char_Guion = { '_' };

            string[] buffSplit_Punto = nombreArchivo.Split(char_Punto);
            string[] buffSplit_GuionBajo = buffSplit_Punto[0].Split(char_Guion);
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            CSUCURSALD sucursalD = new CSUCURSALD();

            if (buffSplit_GuionBajo.Count() < 1)
                return "";


            sucursalBE.ICLAVE = buffSplit_GuionBajo[1];
            sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, null);
            if (sucursalBE == null)
                return "";

            if (sucursalBE.IGRUPOSUCURSALID != lGrupoSucursal)
                return "";

            return buffSplit_GuionBajo[1];

        }


        public bool ImportarDatos(CIMP_FILESBE fileItem, string path, CPARAMETROBE parametros, CPERSONABE usuario, short fileType)
        {
            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  '" + fileItem.IIF_FILE + "'";
            OleDbDataReader dr;
            dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            FbConnection fConn = new FbConnection(ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //int iConsecutivo = 0;

            CIMPORTAR_DBF_LINE_SPBE importCompras;

            string strVentaAnterior = "";
            string strVentaActual = "";

            long doctoIDAnterior = 0;
            long sucursalTid = 0;
            DateTime fechaDBF = new DateTime();

            bool bChecarYaImportado = true;
            string yaImportado = "N";

            bool bObtenerSucursalFuenteDelSigRegistro = false;

            if (fileType == CIMP_FILESD.FileType_Traslados || fileType == CIMP_FILESD.FileType_TrasladosDevo)
                sucursalTid = GetSucursalID_DelArchivo(fileItem.IIF_FILE);
            else if (fileType == CIMP_FILESD.FileType_RecCompras || fileType == CIMP_FILESD.FileType_PedidosDevo)
            {
                bObtenerSucursalFuenteDelSigRegistro = true;
            }

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    importCompras = new CIMPORTAR_DBF_LINE_SPBE();
                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        strVentaActual = ((string)(dr["VENTA"])).Trim();
                        importCompras.IREFERENCIA = strVentaActual;

                        if (strVentaActual != strVentaAnterior && doctoIDAnterior != 0)
                            importCompras.IDOCTOACTUALID = doctoIDAnterior;
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        importCompras.IPRODUCTO = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        importCompras.ILOTE = ((string)(dr["LOTE"])).Trim();
                    }
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        importCompras.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                    }


                    try
                    {
                        if (dr["CANT_FAC"] != System.DBNull.Value)
                        {
                            importCompras.ICANTIDADDEFACTURA = decimal.Parse(dr["CANT_FAC"].ToString());
                        }

                        if (dr["CANT_REM"] != System.DBNull.Value)
                        {
                            importCompras.ICANTIDADDEREMISION = decimal.Parse(dr["CANT_REM"].ToString());
                        }

                        if (dr["CANT_IND"] != System.DBNull.Value)
                        {
                            importCompras.ICANTIDADDEINDEFINIDO = decimal.Parse(dr["CANT_IND"].ToString());
                        }
                    }
                    catch
                    {
                        importCompras.ICANTIDADDEFACTURA = 0;
                        importCompras.ICANTIDADDEREMISION = importCompras.ICANTIDAD;
                        importCompras.ICANTIDADDEINDEFINIDO = 0;

                    }

                    if (dr["F_CADUCA"] != System.DBNull.Value)
                    {
                        try
                        {
                            importCompras.IFECHAVENCE = DateTime.Parse(dr["F_CADUCA"].ToString());
                        }
                        catch
                        {
                        }
                    }

                    importCompras.ISUCURSALID = parametros.ISUCURSALID;


                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        importCompras.ICOSTO = decimal.Parse(dr["COSTO"].ToString());
                    }
                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        importCompras.IIMPORTE = decimal.Parse(dr["IMPORTE"].ToString());
                    }



                    if (dr["CARGOS_U"] != System.DBNull.Value)
                    {
                        importCompras.ICARGOS_U = decimal.Parse(dr["CARGOS_U"].ToString());
                    }

                    if (dr["FALTANTE"] != System.DBNull.Value)
                    {
                        importCompras.IFALTANTE = decimal.Parse(dr["FALTANTE"].ToString());
                    }

                    if (dr["IMPORTNETO"] != System.DBNull.Value)
                    {
                        importCompras.IIMPORTENETO = decimal.Parse(dr["IMPORTNETO"].ToString());
                    }

                    importCompras.IUSERID = usuario.IID;


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        importCompras.ILINEA = ((string)(dr["LINEA"])).Trim();
                    }



                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        importCompras.IMARCA = ((string)(dr["MARCA"])).Trim();
                    }


                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        importCompras.IPROVEEDOR = ((string)(dr["PROVEEDOR"])).Trim();
                    }

                    try
                    {
                        if (dr["PRECREC"] != System.DBNull.Value)
                        {
                            importCompras.IPRECIOVISIBLETRASLADO = decimal.Parse(dr["PRECREC"].ToString());
                        }
                        else
                        {
                            importCompras.IPRECIOVISIBLETRASLADO = importCompras.ICOSTO;
                        }
                    }
                    catch
                    {
                        importCompras.IPRECIOVISIBLETRASLADO = importCompras.ICOSTO;
                    }


                    try
                    {
                        if (HasColumn(dr, "CVEUSER") && dr["CVEUSER"] != System.DBNull.Value)
                        {
                            importCompras.IOBSERVACION = (string)(dr["CVEUSER"]);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["ID_FECHA"] != System.DBNull.Value)
                        {
                            try
                            {
                                fechaDBF = DateTime.Parse(dr["ID_FECHA"].ToString());
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["ID"] != System.DBNull.Value)
                        {
                            string strId = ((string)(dr["ID"])).Trim();
                            long lDoctoImportadoId = 0;
                            if (long.TryParse(strId, out lDoctoImportadoId))
                            {
                                importCompras.IDOCTOIMPORTADOID = lDoctoImportadoId;
                            }
                            else
                            {

                                importCompras.IDOCTOIMPORTADOID = 0;
                            }

                        }
                    }
                    catch
                    {

                        importCompras.IDOCTOIMPORTADOID = 0;
                    }

                    //if (dr["IVA"] != System.DBNull.Value)
                    //{
                    //    importCompras= (string)(dr["IVA"]);
                    //}


                    importCompras.IREFERENCIAS = fileItem.IIF_FILE;

                    //importCompras.ITIPODOCTOID = (fileType == CIMP_FILESD.FileType_Traslados) ? DBValues._DOCTO_TIPO_TRASPASO_REC : DBValues._DOCTO_TIPO_COMPRA;
                    switch (fileType)
                    {
                        case CIMP_FILESD.FileType_Traslados: importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_REC; break;
                        case CIMP_FILESD.FileType_TrasladosDevo: importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO; break;
                        case CIMP_FILESD.FileType_PedidosDevo: importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO; break;
                        default: importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA; break;

                    }

                    importCompras.IALMACENTID = parametros.IMANEJAALMACEN == "S" && parametros.IALMACENRECEPCIONID > 0 ? parametros.IALMACENRECEPCIONID : DBValues._DOCTO_ALMACEN_DEFAULT;



                    if (bObtenerSucursalFuenteDelSigRegistro)
                    {
                        bObtenerSucursalFuenteDelSigRegistro = false;
                        try
                        {

                            if (dr["SUCURSAL"] != System.DBNull.Value)
                            {
                                string claveSucursal = ((string)(dr["SUCURSAL"])).Trim();
                                sucursalTid = getSucursalIdXClave(claveSucursal);
                            }

                        }
                        catch
                        {

                        }
                    }

                    importCompras.ISUCURSALTID = sucursalTid;

                    try
                    {
                        if (dr["IMP_PED"] != System.DBNull.Value)
                        {
                            importCompras.IPEDIMENTO = dr["IMP_PED"].ToString().Trim();
                        }
                        else
                        {
                            importCompras.IPEDIMENTO = "";
                        }
                    }
                    catch
                    {
                        importCompras.IPEDIMENTO = "";
                    }



                    try
                    {
                        if (dr["IMP_FEC"] != System.DBNull.Value)
                        {
                            try
                            {
                                importCompras.IFECHAIMPORTACION = DateTime.Parse(dr["IMP_FEC"].ToString());
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["IMP_ADU"] != System.DBNull.Value)
                        {
                            importCompras.IADUANA = dr["IMP_ADU"].ToString().Trim();
                        }
                        else
                        {
                            importCompras.IADUANA = "";
                        }
                    }
                    catch
                    {
                        importCompras.IADUANA = "";
                    }


                    try
                    {
                        if (dr["IMP_TC"] != System.DBNull.Value)
                        {
                            importCompras.ITIPOCAMBIOIMPO = decimal.Parse(dr["IMP_TC"].ToString());
                        }
                        else
                        {
                            importCompras.ITIPOCAMBIOIMPO = importCompras.ICOSTO;
                        }
                    }
                    catch
                    {
                        importCompras.ITIPOCAMBIOIMPO = 1;
                    }



                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        try
                        {
                            importCompras.IFECHA = DateTime.Parse(dr["FECHA"].ToString());
                        }
                        catch
                        {
                        }
                    }





                    //Checar si ya se habia importado este registro ( solo en la primera linea)
                    if (bChecarYaImportado)
                    {
                        bChecarYaImportado = false;

                        if (IMPORTAR_DBF_CHECAYAIMPORTADO(importCompras, fTrans, fechaDBF, ref yaImportado))
                        {
                            if (yaImportado.Equals("S"))
                            {
                                this.IComentario = "El registro ya esta importado y activo o listo para activarse";
                                fTrans.Rollback();
                                fConn.Close();
                                return true;
                            }
                        }

                    }


                    //proceder a importar
                    if (IMPORTAR_DBF_LINE_SPD(importCompras, fTrans, ref doctoIDAnterior) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        private long getSucursalIdXClave(string claveSucursal)
        {
            CSUCURSALD sucursalD = new CSUCURSALD();

            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.ICLAVE = claveSucursal;

            sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, null);

            if (sucursalBE == null)
                return 0;
            else
                return sucursalBE.IID;

        }

        public bool ImportarDatosPedidoMatriz(CIMP_FILESBE fileItem, string path, CPARAMETROBE parametros, CPERSONABE usuario)
        {
            //short fileType = CIMP_FILESD.FileType_MatrizPedidos;
            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  '" + fileItem.IIF_FILE + "'";
            OleDbDataReader dr = null;
            try
            {
                dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            }
            catch(Exception ex)
            {

                this.iComentario = "Error con el archivo " + fileItem.IIF_FILE + "  no se pudo importar " +  ex.Message;
                return false;
            }

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //int iConsecutivo = 0;

            CIMPORTAR_DBF_LINE_SPBE importCompras;

            string strVentaAnterior = "";
            string strVentaActual = "";

            long doctoIDAnterior = 0;
            long sucursalTid = 0;

            sucursalTid = fileItem.IIF_SUCURSALID;



            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    importCompras = new CIMPORTAR_DBF_LINE_SPBE();
                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        strVentaActual = (string)(dr["VENTA"]);
                        importCompras.IREFERENCIA = strVentaActual;

                        if (strVentaActual != strVentaAnterior && doctoIDAnterior != 0)
                            importCompras.IDOCTOACTUALID = doctoIDAnterior;

                    }


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        importCompras.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        importCompras.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                    }


                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        try
                        {
                            importCompras.IFECHAVENCE = DateTime.Parse(dr["ID_FECHA"].ToString());
                        }
                        catch
                        {
                        }
                    }


                    if (dr["DESC2"] != System.DBNull.Value)
                    {
                        importCompras.IDESCRIPCION = (string)(dr["DESC2"]);
                    }


                    try
                    {
                        if (HasColumn(dr, "CVEUSER") && dr["CVEUSER"] != System.DBNull.Value)
                        {
                            importCompras.IOBSERVACION = (string)(dr["CVEUSER"]);
                        }
                    }
                    catch
                    {

                    }

                    importCompras.IUSERID = usuario.IID;
                    importCompras.ISUCURSALID = parametros.ISUCURSALID;



                    importCompras.IREFERENCIAS = fileItem.IIF_FILE;

                    importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA;
                    importCompras.IALMACENTID = DBValues._DOCTO_ALMACEN_DEFAULT;
                    importCompras.ISUCURSALTID = sucursalTid;
                    


                    if (importCompras.ICANTIDAD <= 0)
                        continue;

                    if (IMPORTAR_DBF_LINE_PEDIDOSUCURSAL(importCompras, fTrans, ref doctoIDAnterior) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosPedidoMovilMatriz(FM_VENPBE ventaMovil, CPARAMETROBE parametros, CPERSONABE usuario)
        {


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //int iConsecutivo = 0;

            CIMPORTAR_DBF_LINE_SPBE importCompras;

            string strVentaAnterior = "";
            string strVentaActual = "";

            long doctoIDAnterior = 0;
            long sucursalTid = 0;




            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                int iCount = 0;

                foreach (FM_VEDPBE detalle in ventaMovil.Detalles)
                {


                    string esFacturaElectronica = ventaMovil.IESTATUS == null || !ventaMovil.IESTATUS.Equals("F") ? "N" : "S";

                    //verifica que no se haya importado en otro hilo de la misma maquina
                    if (iCount == 0)
                    {
                        int cuentaExistente = 0;
                        if (EXISTE_PEDIDO_MOVIL(detalle, ventaMovil.IVENDCLAVE, esFacturaElectronica, ventaMovil.INOTA1, fTrans, ref cuentaExistente) == false)
                        {
                            //this.IComentario = impRecD.IComentario;
                            fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }

                        if (cuentaExistente > 0)
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            return true;
                        }
                    }

                    iCount++;


                  

                    if (IMPORTAR_PEDIDO_MOVIL(detalle, ventaMovil.IVENDCLAVE, esFacturaElectronica, ventaMovil.INOTA1, ventaMovil.INOTA2, ventaMovil.ICONTADO, ventaMovil.IPLAZOS, ventaMovil.IAUTOCRED, fTrans, ref doctoIDAnterior) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool ImportarDatosCompraMovilMatriz(FM_CMNPBE ventaMovil, CPARAMETROBE parametros, CPERSONABE usuario)
        {


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //int iConsecutivo = 0;

            CIMPORTAR_DBF_LINE_SPBE importCompras;

            string strVentaAnterior = "";
            string strVentaActual = "";

            long doctoIDAnterior = 0;
            long sucursalTid = 0;




            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                int iCount = 0;

                foreach (FM_CMDPBE detalle in ventaMovil.Detalles)
                {


                    string esFacturaElectronica = ventaMovil.IESTATUS == null || !ventaMovil.IESTATUS.Equals("F") ? "N" : "S";

                    //verifica que no se haya importado en otro hilo de la misma maquina
                    if (iCount == 0)
                    {
                        int cuentaExistente = 0;
                        if (EXISTE_COMPRA_MOVIL(detalle, ventaMovil.IVENDCLAVE, esFacturaElectronica, ventaMovil.INOTA1, fTrans, ref cuentaExistente) == false)
                        {
                            //this.IComentario = impRecD.IComentario;
                            fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }

                        if (cuentaExistente > 0)
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            return true;
                        }
                    }

                    iCount++;




                    if (IMPORTAR_COMPRA_MOVIL(detalle, ventaMovil.IVENDCLAVE, esFacturaElectronica, ventaMovil.INOTA1, ventaMovil.INOTA2, ventaMovil.ICONTADO, ventaMovil.IPLAZOS,ventaMovil.IFECHAFACTURA, ventaMovil.IFACTURA, fTrans, ref doctoIDAnterior) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool PEDIDO_MOVIL_COMPLETAR(long lDoctoId, ref long lDoctoVentaId, ref long lDoctoPago, FbTransaction st)
        {

            try
            {


                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOVENTAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PEDIDO_MOVIL_COMPLETAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoVentaId = (long)arParms[arParms.Length - 2].Value;
                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    lDoctoPago = (long)arParms[arParms.Length - 3].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool COMPRA_MOVIL_COMPLETAR(long lDoctoId, long lTipoDoctoId, ref long lDoctoVentaId, ref long lDoctoPago, FbTransaction st)
        {

            try
            {


                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEWTIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = lTipoDoctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOVENTAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"COMPRA_MOVIL_COMPLETAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoVentaId = (long)arParms[arParms.Length - 2].Value;
                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    lDoctoPago = (long)arParms[arParms.Length - 3].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool PEDIDO_MOVIL_ENSAMBLE(long lDoctoId, long lVendedorId, FbTransaction st)
        {

            try
            {


                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = lVendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PEDIDO_MOVIL_ENSAMBLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }
                
                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        /*public bool ImportarDatosPedidoMatrizGrid(CIMPORTAR_DBF_LINE_SPBE importCompras/*CIMP_FILESBE fileItem, string path, CPARAMETROBE parametros, CPERSONABE usuario*///)
                                                                                                                                                                            /*{
                                                                                                                                                                              string strVentaAnterior = "";
                                                                                                                                                                              string strVentaActual = "";

                                                                                                                                                                              long doctoIDAnterior = 0;
                                                                                                                                                                              long sucursalTid = 0;

                                                                                                                                                                              sucursalTid = fileItem.IIF_SUCURSALID;



                                                                                                                                                                              try
                                                                                                                                                                              {
                                                                                                                                                                                 /* while (dr.Read())
                                                                                                                                                                                  {*/
                                                                                                                                                                            /* importCompras = new CIMPORTAR_DBF_LINE_SPBE();
                                                                                                                                                                             if (dr["VENTA"] != System.DBNull.Value)
                                                                                                                                                                             {
                                                                                                                                                                                 strVentaActual = (string)(dr["VENTA"]);
                                                                                                                                                                                 importCompras.IREFERENCIA = strVentaActual;

                                                                                                                                                                                 if (strVentaActual != strVentaAnterior && doctoIDAnterior != 0)
                                                                                                                                                                                     importCompras.IDOCTOACTUALID = doctoIDAnterior;

                                                                                                                                                                             }


                                                                                                                                                                             if (dr["PRODUCTO"] != System.DBNull.Value)
                                                                                                                                                                             {
                                                                                                                                                                                 importCompras.IPRODUCTO = (string)(dr["PRODUCTO"]);
                                                                                                                                                                             }
                                                                                                                                                                             if (dr["CANTIDAD"] != System.DBNull.Value)
                                                                                                                                                                             {
                                                                                                                                                                                 importCompras.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                                                                                                                                                                             }


                                                                                                                                                                             if (dr["ID_FECHA"] != System.DBNull.Value)
                                                                                                                                                                             {
                                                                                                                                                                                 try
                                                                                                                                                                                 {
                                                                                                                                                                                     importCompras.IFECHAVENCE = DateTime.Parse(dr["ID_FECHA"].ToString());
                                                                                                                                                                                 }
                                                                                                                                                                                 catch
                                                                                                                                                                                 {
                                                                                                                                                                                 }
                                                                                                                                                                             }


                                                                                                                                                                             if (dr["DESC2"] != System.DBNull.Value)
                                                                                                                                                                             {
                                                                                                                                                                                 importCompras.IDESCRIPCION = (string)(dr["DESC2"]);
                                                                                                                                                                             }


                                                                                                                                                                             try
                                                                                                                                                                             {
                                                                                                                                                                                 if (HasColumn(dr, "CVEUSER") && dr["CVEUSER"] != System.DBNull.Value)
                                                                                                                                                                                 {
                                                                                                                                                                                     importCompras.IOBSERVACION = (string)(dr["CVEUSER"]);
                                                                                                                                                                                 }
                                                                                                                                                                             }
                                                                                                                                                                             catch
                                                                                                                                                                             {

                                                                                                                                                                             }

                                                                                                                                                                             importCompras.IUSERID = usuario.IID;
                                                                                                                                                                             importCompras.ISUCURSALID = parametros.ISUCURSALID;



                                                                                                                                                                             importCompras.IREFERENCIAS = fileItem.IIF_FILE;

                                                                                                                                                                             importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA;
                                                                                                                                                                             importCompras.IALMACENTID = DBValues._DOCTO_ALMACEN_DEFAULT;
                                                                                                                                                                             importCompras.ISUCURSALTID = sucursalTid;


                                                                                                                                                                             if (IMPORTAR_DBF_LINE_PEDIDOSUCURSAL(importCompras, fTrans, ref doctoIDAnterior) == false)
                                                                                                                                                                             {
                                                                                                                                                                                 //this.IComentario = impRecD.IComentario;
                                                                                                                                                                                 fTrans.Rollback();
                                                                                                                                                                                 fConn.Close();
                                                                                                                                                                                 return false;
                                                                                                                                                                             }

                                                                                                                                                                         }

                                                                                                                                                                         fTrans.Commit();
                                                                                                                                                                     }
                                                                                                                                                                     catch (Exception ex)
                                                                                                                                                                     {
                                                                                                                                                                         fTrans.Rollback();
                                                                                                                                                                         fConn.Close();
                                                                                                                                                                         this.iComentario = ex.Message + ex.StackTrace;
                                                                                                                                                                         return false;
                                                                                                                                                                     }
                                                                                                                                                                     finally
                                                                                                                                                                     {
                                                                                                                                                                         fConn.Close();
                                                                                                                                                                     }
                                                                                                                                                                     return true;

                                                                                                                                                                 }*/


        public bool EliminarImportados(CIMP_FILESBE fileItem, CPARAMETROBE parametros, CPERSONABE usuario, short fileType)
        {

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (ELIMINAR_COMPRA_PORREFERENCIA(fileItem.IIF_FILE.Substring(1).ToUpper().Replace(".DBF", ""), fTrans) == false)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }




        public bool ImportarExistenciasBD(CIMP_FILESBE fileItem, string path, CPARAMETROBE parametros, CPERSONABE usuario, string sucursalOrigen)
        {
            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  '" + fileItem.IIF_FILE + "'";
            OleDbDataReader dr;
            dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CINVENTARIOSUCURSALD importExistD = new CINVENTARIOSUCURSALD();
            CINVENTARIOSUCURSALBE importExistBE;

            //long doctoIDAnterior = 0;
            long sucursalTid = GetSucursalID_DelArchivo(fileItem.IIF_FILE);

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    importExistBE = new CINVENTARIOSUCURSALBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        importExistBE.IPRODUCTOCLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["HORA"] != System.DBNull.Value)
                    {
                        importExistBE.IHORA = TimeSpan.Parse(dr["HORA"].ToString());
                    }
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        importExistBE.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        try
                        {
                            importExistBE.IFECHA = DateTime.Parse(dr["FECHA"].ToString());
                        }
                        catch
                        {
                        }
                    }

                    importExistBE.ISUCURSALCLAVE = sucursalOrigen;

                   

                    if (dr["GRUPOCLAVE"] != System.DBNull.Value)
                    {
                        importExistBE.IALMACENCLAVE = (string)(dr["GRUPOCLAVE"]);
                    }
                    else
                    {
                        importExistBE.IALMACENCLAVE = DBValues._DOCTO_ALMACEN_CLAVE_DEFAULT;
                    }


                    if (importExistD.AgregarINVENTARIOSUCURSAL(importExistBE, fTrans) == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                fTrans.Commit();

            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
                dr.Close();
            }
            return true;

        }






        public bool IMPORTAR_DBF_LINE_SPD(CIMPORTAR_DBF_LINE_SPBE oCIMPORTAR_DBF_LINE_SP, FbTransaction st, ref long lDoctoId)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOACTUALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDOCTOACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IUSERID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ILINEA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ILINEA;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARCA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IMARCA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IMARCA;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FALTANTE", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICOSTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOS_U", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTENETO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IIMPORTENETO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IIMPORTENETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ILOTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IALMACENTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.IALMACENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFECHA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEFACTURA", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDADDEFACTURA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDADDEFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEREMISION", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDADDEREMISION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDADDEREMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEINDEFINIDO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDADDEINDEFINIDO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDADDEINDEFINIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOVISIBLETRASLADO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRECIOVISIBLETRASLADO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRECIOVISIBLETRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PEDIMENTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPEDIMENTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPEDIMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAIMPORTACION", FbDbType.Date);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFECHAIMPORTACION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFECHAIMPORTACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IADUANA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOCAMBIOIMPO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPOCAMBIOIMPO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPOCAMBIOIMPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOIMPORTADOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOIMPORTADOID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.IDOCTOIMPORTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_DBFLINE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);

                        if ((long)((int)arParms[arParms.Length - 1].Value) == DBValues._ERRORCODE_PRODUCTO_NOEXISTE)
                        {
                            this.iComentario = "ATENCION: \n" +
"Alguno de los pedidos o traslados que intentas importar contiene un producto que no esta registrado en tu catalogo de PRODUCTOS es necesario que sigas los siguientes pasos \n" +
"\n" +
"1.- Intenta actualizar catálogos antes de importar compras o traslados \n" +
"2.- si no esta disponible la actualización de catálogos solicita a la distribuidora que actualize catalogos y repite el paso 1\n" +
"3.- Reintenta importar traslado o compra\n" +
"\n" +
"Si el error persiste después de repetir estos pasos es necesario que reportes el problema al area de sistema de tu empresa.\n";
                        }
                        else
                        {

                            this.iComentario = "Hubo un error : " + strMensajeErr;
                        }

                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool IMPORTAR_DBF_CHECAYAIMPORTADO(CIMPORTAR_DBF_LINE_SPBE oCIMPORTAR_DBF_LINE_SP, FbTransaction st, DateTime fechaDbf, ref string yaimportado)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fechaDbf;
                parts.Add(auxPar);


                auxPar = new FbParameter("@YAIMPORTADO", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_DBF_CHECAYAIMPORTADO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    yaimportado = (string)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public bool IMPORTAR_DBF_LINE_PEDIDOSUCURSAL(CIMPORTAR_DBF_LINE_SPBE oCIMPORTAR_DBF_LINE_SP, FbTransaction st, ref long lDoctoId)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOACTUALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDOCTOACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IUSERID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IALMACENTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.IALMACENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_DBFLINE_PEDIDOSUCURSAL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool IMPORTAR_DBF_LINE_PEDIDOMOVIL(CIMPORTAR_DBF_LINE_SPBE oCIMPORTAR_DBF_LINE_SP, FbTransaction st, ref long lDoctoId)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOACTUALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDOCTOACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IUSERID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IALMACENTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.IALMACENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLAVECLIENTE", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBRECLIENTE", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICLIENTENOMBRE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICLIENTENOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESFACTURA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IESFACTURA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IESFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICOSTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_DBFLINE_PEDIDOMOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool IMPORTAR_PEDIDO_MOVIL(FM_VEDPBE oCIMPORTAR_DBF_LINE_SP, string vendedor, string esFactElect, string observaciones, string descripcion, string movilContado, string movilPlazos, string esAcumulativo, FbTransaction st, ref long lDoctoId)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IVENTA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CLAVEVENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                auxPar.Value = descripcion;
                parts.Add(auxPar);
                //if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                //{
                //    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}




                auxPar = new FbParameter("@PRECIO", FbDbType.Decimal);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRECIO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVECLIENTE", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                auxPar.Value = observaciones;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESFACTURAELECTRONICA", FbDbType.VarChar);
                auxPar.Value = esFactElect;
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOVILCONTADO", FbDbType.VarChar);
                auxPar.Value = movilContado;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVILPLAZOS", FbDbType.VarChar);
                auxPar.Value = movilPlazos;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESACUMULATIVO", FbDbType.VarChar);
                auxPar.Value = (esAcumulativo ?? "N") != "S" ? "N" : "S";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_PEDIDO_MOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool IMPORTAR_COMPRA_MOVIL(FM_CMDPBE oCIMPORTAR_DBF_LINE_SP, string vendedor, string esFactElect, string observaciones, string descripcion, string movilContado, string movilPlazos,DateTime fechaFactura, string factura,FbTransaction st, ref long lDoctoId)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (factura != null)
                {
                    auxPar.Value = factura;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CLAVEVENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                auxPar.Value = descripcion;
                parts.Add(auxPar);
                //if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                //{
                //    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}




                auxPar = new FbParameter("@PRECIO", FbDbType.Decimal);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRECIO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVEPROVEEDOR", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                auxPar.Value = observaciones;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESFACTURAELECTRONICA", FbDbType.VarChar);
                auxPar.Value = esFactElect;
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOVILCONTADO", FbDbType.VarChar);
                auxPar.Value = movilContado;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVILPLAZOS", FbDbType.VarChar);
                auxPar.Value = movilPlazos;
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAFACTURA", FbDbType.Date);
                if(fechaFactura != null)
                {

                    auxPar.Value = fechaFactura;
                }
                else
                {

                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_COMPRA_MOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool EXISTE_PEDIDO_MOVIL(FM_VEDPBE oCIMPORTAR_DBF_LINE_SP, string vendedor, string esFactElect, string observaciones, FbTransaction st, ref int cuentaExistentes)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IVENTA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CLAVEVENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@CUENTASIMILARES", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"EXISTE_PEDIDO_MOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    cuentaExistentes = (int)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool EXISTE_COMPRA_MOVIL(FM_CMDPBE oCIMPORTAR_DBF_LINE_SP, string vendedor, string esFactElect, string observaciones, FbTransaction st, ref int cuentaExistentes)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CLAVEVENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);





                auxPar = new FbParameter("@CUENTASIMILARES", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"EXISTE_COMPRA_MOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    cuentaExistentes = (int)arParms[arParms.Length - 2].Value;
                }

                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool ELIMINAR_COMPRA_PORREFERENCIA(string referencia, FbTransaction st)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = referencia;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"ELIMINAR_COMPRA_PORREFERENCIA";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }


                return true;



            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool ImportarDatosProv(string fileName, string path)
        {

            return true;

        }


        /*
                public bool ImportarDatosPromocion(string fileName, string path)
                {
                    m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
                    string CmdTxt = "SELECT * FROM " + fileName;

                    OdbcDataReader dr;
                    dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
                    CPROMOCIOND promocionD = new CPROMOCIOND();
                    CPROMOCIONBE retorno = new CPROMOCIONBE();
                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.);
                    FbTransaction fTrans = null;

                    CPROMOCIONBE promocionBuffer = new CPROMOCIONBE();

                    string strProductoClave = "";

                    CPRODUCTOBE prodBE = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();

                    CSUCURSALBE sucursalBE = new CSUCURSALBE();
                    CSUCURSALD  sucursalD = new CSUCURSALD();


                    int iOperation = (int)DBOperations.OperAgregar;
                    bool bResult;
                    try
                    {
                        fConn.Open();
                        fTrans = fConn.BeginTransaction();
                        while (dr.Read())
                        {
                            retorno = new CPROMOCIONBE();
                            iOperation = (int)DBOperations.OperAgregar;

                            if (dr["TIENDA"] != System.DBNull.Value)
                            {
                                retorno.ICLAVE = ((string)(dr["TIENDA"])).Trim();
                                if (dr["PRODUCTO"] != System.DBNull.Value)
                                {
                                    strProductoClave = ((string)(dr["TIENDA"])).Trim();
                                    if (strProductoClave == "")
                                        retorno.ICLAVE += "--";
                                    else
                                        retorno.ICLAVE += "-" + strProductoClave; 
                                }

                            }

                            promocionBuffer = promocionD.seleccionarPROMOCIONxCLAVE(retorno, fTrans);
                            if (promocionBuffer != null)
                            {
                                retorno = promocionBuffer;
                                iOperation = (int)DBOperations.OperCambiar;
                            }



                            retorno.INOMBRE = retorno.ICLAVE;
                            retorno.IDESCRIPCION = retorno.ICLAVE;


                            if (dr["PROMOCION"] != System.DBNull.Value)
                            {
                                retorno.IPROMOCION = ((string)(dr["PROMOCION"])).Trim();
                            }


                            if (dr["MONTO"] != System.DBNull.Value)
                            {
                                retorno.ICANTIDAD = (decimal)((dr["MONTO"]));
                            }


                            if (dr["UTILIDAD"] != System.DBNull.Value)
                            {
                                retorno.IUTILIDAD = (decimal)((dr["UTILIDAD"]));
                            }

                            if (dr["PRODUCTO"] != System.DBNull.Value)
                            {
                                prodBE = new CPRODUCTOBE();
                                prodBE.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                                prodBE = prodD.seleccionarPRODUCTOxCLAVE(prodBE, fTrans);
                                if (prodBE != null)
                                    retorno.IPRODUCTOID = prodBE.IID;
                                else
                                    continue;
                        
                            }



                            if (dr["TIENDA"] != System.DBNull.Value)
                            {
                                sucursalBE = new CSUCURSALBE();
                                sucursalBE.ICLAVE = ((string)(dr["TIENDA"])).Trim();
                                sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, fTrans);
                                if (sucursalBE != null)
                                    retorno.ISUCURSALID = sucursalBE.IID;
                                else
                                {

                                    sucursalBE = new CSUCURSALBE();
                                    sucursalBE.ICLAVE = ((string)(dr["TIENDA"])).Trim();
                                    sucursalBE.INOMBRE = ((string)(dr["TIENDA"])).Trim();
                                    sucursalBE = sucursalD.AgregarSUCURSALD(sucursalBE, fTrans);
                                    if (sucursalBE == null)
                                        continue;
                                    else
                                    {
                                        sucursalBE = new CSUCURSALBE();
                                        sucursalBE.ICLAVE = ((string)(dr["TIENDA"])).Trim();
                                        sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, fTrans);
                                        if (sucursalBE != null)
                                            retorno.ISUCURSALID = sucursalBE.IID;
                                        else
                                            continue;
                                    }

                                }
                            

                            }


                            if (iOperation == (int)DBOperations.OperCambiar)
                                bResult = promocionD.CambiarPROMOCIOND(retorno, retorno, fTrans);
                            else
                                bResult = (promocionD.AgregarPROMOCIOND(retorno, fTrans) != null);

                            if (bResult == false)
                            {
                                this.IComentario = promocionD.IComentario;
                                fTrans.Rollback();
                                fConn.Close();
                                return false;
                            }


                        }
                        fTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        this.iComentario = ex.Message + ex.StackTrace;
                        return false;
                    }
                    finally
                    {
                        fConn.Close();
                    }
                    return true;

                }
                */

        public bool ImportarDatosLinea(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CLINEAD lineaD = new CLINEAD();
            CLINEABE retorno = new CLINEABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CLINEABE lineaBuffer = new CLINEABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CLINEABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["LINEA"])).Trim();
                    }

                    lineaBuffer = lineaD.seleccionarLINEAxCLAVE(retorno, fTrans);
                    if (lineaBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = lineaBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }

                    if (dr["TRECARGA"] != System.DBNull.Value)
                    {
                        retorno.ITIPORECARGA = ((string)(dr["TRECARGA"])).Trim();
                    }



                    try
                    {
                        if (dr["APLIMAYO"] != System.DBNull.Value)
                        {
                            retorno.IAPLICAMAYOREOXLINEA = ((string)(dr["APLIMAYO"])).Trim();
                        }
                        else
                        {
                            retorno.IAPLICAMAYOREOXLINEA = "S";
                        }

                    }
                    catch
                    {
                        retorno.IAPLICAMAYOREOXLINEA = "N";
                    }

                    if (retorno.IAPLICAMAYOREOXLINEA == null || retorno.IAPLICAMAYOREOXLINEA.Trim().Length == 0)
                    {
                        retorno.IAPLICAMAYOREOXLINEA = "N";
                    }

                    try
                    {

                        if (dr["GPOIMP"] != System.DBNull.Value)
                        {
                            retorno.IGPOIMP = ((string)(dr["GPOIMP"])).Trim();
                        }
                    }
                    catch
                    {

                    }

                    /*
                    if (dr["PROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IACUMULAPROMOCION = (string)(dr["PROMOCION"]);
                        if (retorno.IACUMULAPROMOCION != "S" && retorno.IACUMULAPROMOCION != "N")
                            retorno.IACUMULAPROMOCION = "N";
                    }
                    else
                    {*/
                    retorno.IACUMULAPROMOCION = "N";
                    //}


                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = lineaD.CambiarLINEAD(retorno, retorno, fTrans);
                    else
                        bResult = (lineaD.AgregarLINEAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = lineaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosArea(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CAREAD areaD = new CAREAD();
            CAREABE retorno = new CAREABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CAREABE areaBuffer = new CAREABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CAREABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["AREA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["AREA"])).Trim();
                    }

                    areaBuffer = areaD.seleccionarAREAXCLAVE(retorno, fTrans);
                    if (areaBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = areaBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBREAREA = ((string)(dr["NOMBRE"])).Trim();
                    }




                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = areaD.CambiarAREAD(retorno, retorno, fTrans);
                    else
                        bResult = (areaD.AgregarAREAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = areaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosAreaDerecho(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CAREADERECHOSD areaD = new CAREADERECHOSD();
            CAREADERECHOSBE retorno = new CAREADERECHOSBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            CAREAD areaMainD = new CAREAD();

            CAREADERECHOSBE areaBuffer = new CAREADERECHOSBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!areaD.BorrarAllDerechosDeArea(fTrans))
                {

                    this.IComentario = areaD.IComentario;
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                while (dr.Read())
                {
                    retorno = new CAREADERECHOSBE();
                    iOperation = (int)DBOperations.OperAgregar;


                    CAREABE area = new CAREABE();

                    if (dr["AREA"] != System.DBNull.Value)
                    {
                        area.ICLAVE = (string)dr["AREA"];
                        area = areaMainD.seleccionarAREAXCLAVE(area, fTrans);
                        if (area == null)
                        {
                            continue;

                        }
                        else
                        {
                            retorno.IIDAREA = area.IID;
                        }
                    }
                    else
                    {
                        continue;
                    }



                    if (dr["DERECHO"] != System.DBNull.Value)
                    {
                        retorno.IIDDERECHO = long.Parse(dr["DERECHO"].ToString());
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = areaD.CambiarAREADERECHOSD(retorno, retorno, fTrans);
                    else
                        bResult = (areaD.AgregarAREADERECHOSD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = areaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosTasaIva(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CTASAIVAD itemD = new CTASAIVAD();
            CTASAIVABE retorno = new CTASAIVABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CTASAIVABE itemBuffer = new CTASAIVABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CTASAIVABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarTASAIVAxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }


                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        retorno.ITASA = (decimal)(dr["TASA"]);
                    }


                    if (dr["FECHAINI"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIA = (DateTime)(dr["FECHAINI"]);
                    }


                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarTASAIVAD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarTASAIVAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarDatosEstado(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CESTADOD itemD = new CESTADOD();
            CESTADOBE retorno = new CESTADOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CESTADOBE itemBuffer = new CESTADOBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CESTADOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarESTADOxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarESTADOD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarESTADOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }





        public bool ImportarDatosUnidad(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CUNIDADD itemD = new CUNIDADD();
            CUNIDADBE retorno = new CUNIDADBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CUNIDADBE itemBuffer = new CUNIDADBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CUNIDADBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarUNIDADxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }

                    try
                    {
                        if (dr["CANTDEC"] != System.DBNull.Value)
                        {
                            retorno.ICANTIDADDECIMALES = short.Parse(((decimal)dr["CANTDEC"]).ToString());
                        }
                    }
                    catch
                    {
                        if (itemBuffer != null)
                        {
                            retorno.ICANTIDADDECIMALES = itemBuffer.ICANTIDADDECIMALES;

                        }

                    }


                    if (dr["CLAVESAT"] != System.DBNull.Value)
                    {
                        CSAT_UNIDADMEDIDABE auxUnd = new CSAT_UNIDADMEDIDABE();
                        CSAT_UNIDADMEDIDAD daoAuxUnd = new CSAT_UNIDADMEDIDAD();
                        auxUnd.ISAT_CLAVE = ((string)(dr["CLAVESAT"])).Trim();
                        auxUnd = daoAuxUnd.seleccionarSAT_UNIDADMEDIDA_X_SAT_CLAVE(auxUnd, null);
                        if (auxUnd != null)
                        {
                            retorno.ISAT_UNIDADMEDIDAID = auxUnd.IID;
                        }

                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarUNIDADD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarUNIDADD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosBancos(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CBANCOSD itemD = new CBANCOSD();
            CBANCOSBE retorno = new CBANCOSBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CBANCOSBE itemBuffer = new CBANCOSBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CBANCOSBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarBANCOSxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarBANCOSD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarBANCOSD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool ImportarDatosGastos(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CGASTOD itemD = new CGASTOD();
            CGASTOBE retorno = new CGASTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CGASTOBE itemBuffer = new CGASTOBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CGASTOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarGASTOxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarGASTOD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarGASTOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }

        public bool ImportarDatosTipos(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CSUBTIPOCLIENTED itemD = new CSUBTIPOCLIENTED();
            CSUBTIPOCLIENTEBE retorno = new CSUBTIPOCLIENTEBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CSUBTIPOCLIENTEBE itemBuffer = new CSUBTIPOCLIENTEBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CSUBTIPOCLIENTEBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["TIPO"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarSUBTIPOCLIENTEXCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarSUBTIPOCLIENTED(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarSUBTIPOCLIENTED(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool ImportarControlPrecios(string fileName, string path, CPERSONABE usuario)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CCONTROLPRECIOSD itemD = new CCONTROLPRECIOSD();
            CCONTROLPRECIOSBE retorno = new CCONTROLPRECIOSBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CCONTROLPRECIOSBE itemBuffer = new CCONTROLPRECIOSBE();

            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (dr.Read())
                {
                    retorno.IFECHA = DateTime.Today;
                    retorno.ITIPO = 1;
                    retorno.IUSUARIOID = usuario.IID;

                    if (dr["ID_CTRL"] != System.DBNull.Value)
                    {
                        retorno.IIDACTUALIZACION = int.Parse((dr["ID_CTRL"]).ToString().Trim());
                    }


                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarCONTROLPRECIOSD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarCONTROLPRECIOSD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }
                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public Dictionary<string, decimal> ImportarExistenciaProductosXSucursal(string fileName, string path, string sucursal)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName + " WHERE SUCURSAL = '" + sucursal + "'";

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            Dictionary<string, decimal> retorno = new Dictionary<string, decimal>();

            try
            {
                string clave;
                decimal cantidad;

                while (dr.Read())
                {
                    clave = "";
                    cantidad = 0;

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        clave = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        cantidad = decimal.Parse(dr["CANTIDAD"].ToString());
                    }
                    retorno.Add(clave, cantidad);
                }


            }
            catch (Exception ex)
            {
                return null;
            }

            return retorno;
        }





        public List<CEXIST_SUCURSALBE> ExistenciaXProveedor(string fileName, string path, string sucursal, string proveedor, bool soloConExistencia)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT PRODUCTO, SUM(CANTIDAD) CANTIDAD, PROVEE, SUCURSAL, FECHA FROM " + fileName;

            if ((sucursal != null && sucursal.Trim().Length > 0) ||
                (proveedor != null && proveedor.Trim().Length > 0))
            {
                CmdTxt += " WHERE ";

                bool bPrimerCondicionPuesta = false;

                if (sucursal != null && sucursal.Trim().Length > 0)
                {
                    if (bPrimerCondicionPuesta == false)
                        bPrimerCondicionPuesta = true;
                    else
                    {
                        CmdTxt += " AND ";
                    }

                    CmdTxt += " SUCURSAL = '" + sucursal + "'";
                }


                if (proveedor != null && proveedor.Trim().Length > 0)
                {
                    if (bPrimerCondicionPuesta == false)
                        bPrimerCondicionPuesta = true;
                    else
                    {
                        CmdTxt += " AND ";
                    }
                    CmdTxt += " PROVEE = '" + proveedor + "'";
                }



            }

            CmdTxt += " GROUP BY PRODUCTO, PROVEE, SUCURSAL";

            if (soloConExistencia)
            {
                CmdTxt += " HAVING SUM(CANTIDAD) > 0 ";
            }

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            List<CEXIST_SUCURSALBE> retorno = new List<CEXIST_SUCURSALBE>();

            try
            {
                //string clave;
                //decimal cantidad;



                while (dr.Read())
                {
                    //clave = "";
                    //cantidad = 0;

                    CEXIST_SUCURSALBE existObject = new CEXIST_SUCURSALBE();
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        existObject.IPRODUCTOCLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        existObject.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                    }

                    if (dr["PROVEE"] != System.DBNull.Value)
                    {
                        existObject.IPROVEE = ((string)(dr["PROVEE"])).Trim();
                    }

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        existObject.ISUCURSALCLAVE = ((string)(dr["SUCURSAL"])).Trim();
                    }
                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        existObject.IFECHA = (DateTime)dr["FECHA"];
                    }


                    retorno.Add(existObject);
                }


            }
            catch (Exception ex)
            {
                return null;
            }

            return retorno;
        }




        public bool ImportarPlazos(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPLAZOD itemD = new CPLAZOD();
            CPLAZOBE retorno = new CPLAZOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPLAZOBE itemBuffer = new CPLAZOBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPLAZOBE();
                    iOperation = (int)DBOperations.OperAgregar;


                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }


                    itemBuffer = itemD.seleccionarPlazoXCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }

                    if (dr["COMISIONST"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONISTA = (string)(dr["COMISIONST"]);
                    }


                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        retorno.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = int.Parse(dr["DIAS"].ToString());
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarPLAZOD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarPLAZOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool ImportarProductosPromocion(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD itemD = new CPRODUCTOD();
            CPRODUCTOBE productoPromocion = new CPRODUCTOBE();
            CPRODUCTOBE productoBase = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            DateTime fechaVigencia = DateTime.MinValue;
            DateTime currentDateTime = new DateTime();


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    productoBase = new CPRODUCTOBE();
                    productoPromocion = new CPRODUCTOBE();

                    fechaVigencia = DateTime.MinValue;

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        productoBase.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    if (dr["PROD2"] != System.DBNull.Value)
                    {
                        productoPromocion.ICLAVE = ((string)(dr["PROD2"])).Trim();
                    }


                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        fechaVigencia = ((DateTime)(dr["FECHA"]));
                    }
                    else
                    {
                        continue;
                    }

                    //if(fechaVigencia.CompareTo(currentDateTime) < 0)
                    //{
                    //    continue;
                    //}

                    productoPromocion = itemD.seleccionarPRODUCTOxCLAVE(productoPromocion, fTrans);
                    productoBase = itemD.seleccionarPRODUCTOPorClave(productoBase, fTrans);

                    if (productoPromocion == null || productoBase == null || fechaVigencia.CompareTo(DateTime.Today) < 0)
                        continue;


                    productoPromocion.IVIGENCIAPRODPROMO = fechaVigencia;
                    productoPromocion.IESPRODPROMO = "S";
                    productoPromocion.IBASEPRODPROMOID = productoBase.IID;


                    if (!itemD.CambiarDatosPromocionPRODUCTO(productoPromocion, fTrans))
                    {

                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }



                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarDatosPrm(string fileName, string path, string sucursalClave)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName + " where SUCURSAL = '" + sucursalClave + "'";

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPROMOCIOND itemD = new CPROMOCIOND();
            CPROMOCIONBE retorno = new CPROMOCIONBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPROMOCIONBE itemBuffer = new CPROMOCIONBE();



            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPROMOCIONBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }


                    if (dr["DESCRIP"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(dr["DESCRIP"])).Trim();
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = ((decimal)(dr["CANTIDAD"]));
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUTILIDAD = ((decimal)(dr["UTILIDAD"]));
                    }

                    if (dr["CANTLLEV"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADLLEVATE = ((decimal)(dr["CANTLLEV"]));
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = ((decimal)(dr["IMPORTE"]));
                    }

                    if (dr["PORCDESC"] != System.DBNull.Value)
                    {
                        retorno.IPORCENTAJEDESCUENTO = ((decimal)(dr["PORCDESC"]));
                    }

                    if (dr["FECHAINI"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = ((DateTime)(dr["FECHAINI"]));
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = ((DateTime)(dr["FECHAFIN"]));
                    }

                    if (dr["LUNES"] != System.DBNull.Value)
                    {
                        retorno.ILUNES = ((string)(dr["LUNES"]));
                    }

                    if (dr["MARTES"] != System.DBNull.Value)
                    {
                        retorno.IMARTES = ((string)(dr["MARTES"]));
                    }

                    if (dr["MIERCOLES"] != System.DBNull.Value)
                    {
                        retorno.IMIERCOLES = ((string)(dr["MIERCOLES"]));
                    }

                    if (dr["JUEVES"] != System.DBNull.Value)
                    {
                        retorno.IJUEVES = ((string)(dr["JUEVES"]));
                    }

                    if (dr["VIERNES"] != System.DBNull.Value)
                    {
                        retorno.IVIERNES = ((string)(dr["VIERNES"]));
                    }

                    if (dr["SABADO"] != System.DBNull.Value)
                    {
                        retorno.ISABADO = ((string)(dr["SABADO"]));
                    }

                    if (dr["DOMINGO"] != System.DBNull.Value)
                    {
                        retorno.IDOMINGO = ((string)(dr["DOMINGO"]));
                    }

                    if (dr["PORIMPO"] != System.DBNull.Value)
                    {
                        retorno.IPORIMPORTE = ((decimal)(dr["PORIMPO"]));
                    }

                    if (dr["MONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IENMONEDERO = ((string)(dr["MONEDERO"]));
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = ((string)(dr["ACTIVO"]));
                    }

                    if (dr["MULTDET"] != System.DBNull.Value)
                    {
                        retorno.IESMULTIDETALLE = ((string)(dr["MULTDET"]));
                    }


                    if (dr["DESCMTD"] != System.DBNull.Value)
                    {
                        retorno.IDESCMULTIDETALLE = ((string)(dr["DESCMTD"]));
                    }


                    string productoClave, tipoPromocionClave, rangoPromocionClave, lineaClave;

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        productoClave = (string)(dr["PRODUCTO"]);
                    }
                    else
                    {
                        productoClave = "";
                    }

                    if (dr["TIPOPROM"] != System.DBNull.Value)
                    {
                        tipoPromocionClave = (string)(dr["TIPOPROM"]);
                    }
                    else
                    {
                        tipoPromocionClave = "";
                    }

                    if (dr["RANGPROM"] != System.DBNull.Value)
                    {
                        rangoPromocionClave = (string)(dr["RANGPROM"]);
                    }
                    else
                    {
                        rangoPromocionClave = "";
                    }

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        lineaClave = (string)(dr["LINEA"]);
                    }
                    else
                    {
                        lineaClave = "";
                    }

                    bResult = itemD.IMPORTARPROMOCIOND(retorno, sucursalClave,
                                                           productoClave, tipoPromocionClave,
                                                           rangoPromocionClave, lineaClave, fTrans);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosContenido(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CCONTENIDOD itemD = new CCONTENIDOD();
            CCONTENIDOBE retorno = new CCONTENIDOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CCONTENIDOBE itemBuffer = new CCONTENIDOBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CCONTENIDOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarCONTENIDOxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarCONTENIDOD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarCONTENIDOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarDatosClasifica(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CCLASIFICAD itemD = new CCLASIFICAD();
            CCLASIFICABE retorno = new CCLASIFICABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CCLASIFICABE itemBuffer = new CCLASIFICABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CCLASIFICABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarCLASIFICAxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarCLASIFICAD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarCLASIFICAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarDatosMotivosDevolucion(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CTIPODIFERENCIAINVENTARIOD itemD = new CTIPODIFERENCIAINVENTARIOD();
            CTIPODIFERENCIAINVENTARIOBE retorno = new CTIPODIFERENCIAINVENTARIOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CTIPODIFERENCIAINVENTARIOBE itemBuffer = new CTIPODIFERENCIAINVENTARIOBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CTIPODIFERENCIAINVENTARIOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarTIPODIFERENCIAINVENTARIOXCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }

                    if (dr["DESC"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(dr["DESC"])).Trim();
                    }


                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarTIPODIFERENCIAINVENTARIOD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarTIPODIFERENCIAINVENTARIOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosGrupoSucursal(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CGRUPOSUCURSALD itemD = new CGRUPOSUCURSALD();
            CGRUPOSUCURSALBE retorno = new CGRUPOSUCURSALBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CGRUPOSUCURSALBE itemBuffer = new CGRUPOSUCURSALBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CGRUPOSUCURSALBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarGRUPOSUCURSALPorClave(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }


                    if (dr["DESC"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(dr["DESC"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarGRUPOSUCURSALD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarGRUPOSUCURSALD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarDatosCaracteristicasProducto(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPROD_DEF_CARACTERISTICASD itemD = new CPROD_DEF_CARACTERISTICASD();
            CPROD_DEF_CARACTERISTICASBE retorno = new CPROD_DEF_CARACTERISTICASBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CTASAIVABE itemBuffer = new CTASAIVABE();

            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPROD_DEF_CARACTERISTICASBE();


                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = ((string)(dr["TEXTO1"])).Trim();
                    }


                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = ((string)(dr["TEXTO2"])).Trim();
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = ((string)(dr["TEXTO3"])).Trim();
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = ((string)(dr["TEXTO4"])).Trim();
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = ((string)(dr["TEXTO5"])).Trim();
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = ((string)(dr["TEXTO6"])).Trim();
                    }


                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        retorno.INUMERO1 = ((string)(dr["NUMERO1"])).Trim();
                    }
                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        retorno.INUMERO2 = ((string)(dr["NUMERO2"])).Trim();
                    }
                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        retorno.INUMERO3 = ((string)(dr["NUMERO3"])).Trim();
                    }
                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        retorno.INUMERO4 = ((string)(dr["NUMERO4"])).Trim();
                    }


                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        retorno.IFECHA1 = ((string)(dr["FECHA1"])).Trim();
                    }
                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = ((string)(dr["FECHA2"])).Trim();
                    }


                    bResult = itemD.CambiarPROD_DEF_CARACTERISTICASD(retorno, retorno, fTrans);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }





        public bool ImportarDatosMarca(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            CMARCAD marcaD = new CMARCAD();
            CMARCABE retorno = new CMARCABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CMARCABE marcaBuffer = new CMARCABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();
                dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
                while (dr.Read())
                {
                    retorno = new CMARCABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["MARCA"])).Trim();
                    }

                    marcaBuffer = marcaD.seleccionarMARCAXCLAVE(retorno, fTrans);
                    if (marcaBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = marcaBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }

                    if (dr["DESCONTI"] != System.DBNull.Value)
                    {
                        retorno.IDESCONTINUADO = ((string)(dr["DESCONTI"])).Trim();
                    }
                    else
                    {
                        retorno.IDESCONTINUADO = "N";
                    }

                    if (retorno.IDESCONTINUADO == "" || (bool)retorno.isnull["IDESCONTINUADO"])
                        retorno.IDESCONTINUADO = "N";

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = marcaD.CambiarMARCAD(retorno, retorno, fTrans);
                    else
                        bResult = (marcaD.AgregarMARCAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = marcaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();

                dr.Close();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }






        public bool ImportarDatosProveedor(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPROVEEDORD personaD = new CPROVEEDORD();
            CPERSONABE retorno = new CPERSONABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPERSONABE personaBuffer = new CPERSONABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPERSONABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PROVEEDOR"])).Trim();
                    }

                    retorno.ITIPOPERSONAID = DBValues._TIPOPERSONA_PROVEEDOR;
                    personaBuffer = personaD.seleccionarPERSONAxCLAVEyTIPO(retorno, fTrans);
                    if (personaBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = personaBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }
                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = ((string)(dr["CALLE"])).Trim();
                    }
                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = ((string)(dr["COLONIA"])).Trim();
                    }
                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = ((string)(dr["CIUDAD"])).Trim();
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = ((string)(dr["ESTADO"])).Trim();
                    }
                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = ((string)(dr["CP"])).Trim();
                    }

                    if (dr["TEL1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = ((string)(dr["TEL1"])).Trim();
                    }
                    if (dr["TEL2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = ((string)(dr["TEL2"])).Trim();
                    }

                    if (dr["CONTACTO"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = ((string)(dr["CONTACTO"])).Trim();
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = ((string)(dr["CONTACTO2"])).Trim();
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = ((string)(dr["RFC"])).Trim();
                    }

                    try
                    {
                        if (dr["ADESCPES"] != System.DBNull.Value)
                        {
                            retorno.IADESCPES = (decimal)((dr["ADESCPES"]));
                        }
                    }
                    catch {
                        retorno.IADESCPES = 1;
                    }



                    retorno.IACTIVO = "S";

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = personaD.CambiarPERSONAD(retorno, retorno, fTrans);
                    else
                        bResult = (personaD.AgregarPERSONAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = personaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosEncargadoCorte(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPROVEEDORD personaD = new CPROVEEDORD();
            CPERSONABE retorno = new CPERSONABE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPERSONABE personaBuffer = new CPERSONABE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPERSONABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PROVEEDOR"])).Trim();
                    }

                    retorno.ITIPOPERSONAID = DBValues._TIPOPERSONA_ENCARGADOCORTE;
                    personaBuffer = personaD.seleccionarPERSONAxCLAVEyTIPO(retorno, fTrans);
                    if (personaBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = personaBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }
                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = ((string)(dr["CALLE"])).Trim();
                    }
                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = ((string)(dr["COLONIA"])).Trim();
                    }
                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = ((string)(dr["CIUDAD"])).Trim();
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = ((string)(dr["ESTADO"])).Trim();
                    }
                    if (dr["CP"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = ((string)(dr["CP"])).Trim();
                    }

                    if (dr["TEL1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = ((string)(dr["TEL1"])).Trim();
                    }
                    if (dr["TEL2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = ((string)(dr["TEL2"])).Trim();
                    }

                    if (dr["CONTACTO"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = ((string)(dr["CONTACTO"])).Trim();
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = ((string)(dr["CONTACTO2"])).Trim();
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = ((string)(dr["RFC"])).Trim();
                    }

                    try
                    {
                        if (dr["ADESCPES"] != System.DBNull.Value)
                        {
                            retorno.IADESCPES = (decimal)((dr["ADESCPES"]));
                        }
                    }
                    catch
                    {
                        retorno.IADESCPES = 1;
                    }



                    retorno.IACTIVO = "S";

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = personaD.CambiarPERSONAD(retorno, retorno, fTrans);
                    else
                        bResult = (personaD.AgregarPERSONAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = personaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool ImportarDatosSucursal(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE retorno = new CSUCURSALBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CSUCURSALBE sucursalBuffer = new CSUCURSALBE();
            CGRUPOSUCURSALBE grupoSucursalBE;
            CGRUPOSUCURSALD grupoSucursalD = new CGRUPOSUCURSALD();


            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CSUCURSALBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLIENTE"])).Trim();
                    }

                    sucursalBuffer = sucursalD.seleccionarSUCURSALPorClave(retorno, fTrans);
                    if (sucursalBuffer != null)
                    {
                        retorno = sucursalBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["GRUPO"] != System.DBNull.Value)
                    {
                        grupoSucursalBE = new CGRUPOSUCURSALBE();
                        grupoSucursalBE.ICLAVE = ((string)(dr["GRUPO"])).Trim();
                        grupoSucursalBE = grupoSucursalD.seleccionarGRUPOSUCURSALPorClave(grupoSucursalBE, fTrans);
                        if (grupoSucursalBE == null)
                        {
                            grupoSucursalBE = new CGRUPOSUCURSALBE();
                            grupoSucursalBE.ICLAVE = ((string)(dr["GRUPO"])).Trim();
                            grupoSucursalBE.IDESCRIPCION = grupoSucursalBE.ICLAVE;
                            grupoSucursalBE.INOMBRE = grupoSucursalBE.ICLAVE;
                            grupoSucursalBE = grupoSucursalD.AgregarGRUPOSUCURSALD(grupoSucursalBE, fTrans);
                            if (grupoSucursalBE != null)
                            {
                                grupoSucursalBE = grupoSucursalD.seleccionarGRUPOSUCURSALPorClave(grupoSucursalBE, fTrans);
                                retorno.IGRUPOSUCURSALID = grupoSucursalBE.IID;
                            }

                        }
                        else
                        {
                            retorno.IGRUPOSUCURSALID = grupoSucursalBE.IID;
                        }

                    }



                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }

                    if (dr["NOMBRE2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = ((string)(dr["NOMBRE2"])).Trim();
                    }


                    if (dr["PRECIOT"] != System.DBNull.Value)
                    {
                        var valPrecioT = (decimal)(dr["PRECIOT"]);
                        switch(valPrecioT)
                        {
                            case -1: retorno.ILISTA_PRECIO_TRASPASO = "R"; break;
                            case -2: retorno.ILISTA_PRECIO_TRASPASO = "U"; break;
                            case -3: retorno.ILISTA_PRECIO_TRASPASO = "P"; break;
                            default: retorno.ILISTA_PRECIO_TRASPASO = ((decimal)(dr["PRECIOT"])).ToString(); break;
                        }


                        
                    }

                    try
                    {
                        if (dr["MAXDOCP"] != System.DBNull.Value)
                        {
                            retorno.IMAXDOCTOSPENDIENTES = int.Parse(((decimal)(dr["MAXDOCP"])).ToString());
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (dr["ESMATRIZ"] != System.DBNull.Value)
                        {
                            retorno.IESMATRIZ = ((string)(dr["ESMATRIZ"])).Trim();
                        }
                    }
                    catch
                    {
                        retorno.IESMATRIZ = "N";
                    }


                    try
                    {
                        if (dr["COSTOREC"] != System.DBNull.Value)
                        {
                            retorno.IPRECIORECEPCIONTRASLADO = long.Parse(((decimal)(dr["COSTOREC"])).ToString());
                        }
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (dr["PRECENV"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOENVIOTRASLADO = long.Parse(((decimal)(dr["PRECENV"])).ToString());
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (dr["SHOWREAL"] != System.DBNull.Value)
                        {
                            retorno.IMOSTRARPRECIOREAL = ((string)(dr["SHOWREAL"])).Trim();
                        }
                    }
                    catch
                    {
                        retorno.IMOSTRARPRECIOREAL = "N";
                    }


                    try
                    {
                        if (dr["PROVEE"] != System.DBNull.Value)
                        {
                            retorno.IPROVEEDORCLAVE = ((string)(dr["PROVEE"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["SURTIDOR"] != System.DBNull.Value)
                        {
                            retorno.ISURTIDOR = ((string)(dr["SURTIDOR"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        retorno.IPORC_AUMENTO_PRECIO = 0;

                        if (dr["PORCPREC"] != System.DBNull.Value)
                        {
                            retorno.IPORC_AUMENTO_PRECIO = decimal.Parse(dr["PORCPREC"].ToString());
                        }
                    }
                    catch
                    {

                    }




                    try
                    {
                        if (dr["PRECXDES"] != System.DBNull.Value)
                        {
                            retorno.IMANEJAPRECIOXDESCUENTO = ((string)(dr["PRECXDES"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["PREFXDES"] != System.DBNull.Value)
                        {
                            retorno.IPREFIJOPRECIOXDESCUENTO = ((string)(dr["PREFXDES"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["RESPBD"] != System.DBNull.Value)
                        {
                            retorno.INOMBRERESPALDOBD = ((string)(dr["RESPBD"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["ESFRANQ"] != System.DBNull.Value)
                        {
                            retorno.IESFRANQUICIA = ((string)(dr["ESFRANQ"])).Trim();
                        }
                    }
                    catch
                    {
                        retorno.IESFRANQUICIA = "N";

                    }


                    try
                    {
                        if (dr["BANCO"] != System.DBNull.Value)
                        {
                            retorno.IBANCOCLAVE = ((string)(dr["BANCO"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["CUENTA"] != System.DBNull.Value)
                        {
                            retorno.ICUENTAREFERENCIA = ((string)(dr["CUENTA"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["CTAPOLI"] != System.DBNull.Value)
                        {
                            retorno.ICUENTAPOLIZA = ((string)(dr["CTAPOLI"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["LSTPREC"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECIOCLAVE = ((string)(dr["LSTPREC"])).Trim();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                        if (dr["EMPPROV"] != System.DBNull.Value)
                        {
                            retorno.IEMPPROV = ((string)(dr["EMPPROV"])).Trim();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                        if (dr["IMNUPROD"] != System.DBNull.Value)
                        {
                            retorno.IIMNUPROD = ((string)(dr["IMNUPROD"])).Trim();
                        }
                    }
                    catch
                    {

                    }

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = sucursalD.CambiarSUCURSALD(retorno, retorno, fTrans);
                    else
                        bResult = (sucursalD.AgregarSUCURSALD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = sucursalD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }





        public bool ImportarDatoskits(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CKITDEFTEMPD kittempD = new CKITDEFTEMPD();
            CKITDEFTEMPBE retorno = new CKITDEFTEMPBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CKITDEFTEMPBE kittempBuffer = new CKITDEFTEMPBE();


            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!kittempD.KIT_PREPARETEMPTABLE(fTrans))
                {

                    this.IComentario = kittempD.IComentario;
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                while (dr.Read())
                {
                    retorno = new CKITDEFTEMPBE();

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOKITCLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }


                    if (dr["PARTE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOPARTECLAVE = ((string)(dr["PARTE"])).Trim();
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADPARTE = ((decimal)(dr["CANTIDAD"]));
                    }



                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPARTE = ((decimal)(dr["COSTO"]));
                    }


                    bResult = (kittempD.AgregarKITDEFTEMPD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = kittempD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }

                if (!kittempD.KIT_APPLYTEMPTABLE(fTrans))
                {

                    this.IComentario = kittempD.IComentario;
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        //public bool ImportarDatosLinea(string fileName, string path)
        //{
        //    m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
        //    string CmdTxt = "SELECT * FROM " + fileName;

        //    OdbcDataReader dr;
        //    dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
        //    CLINEAD lineaD = new CLINEAD();
        //    CLINEABE retorno = new CLINEABE();
        //    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
        //    FbTransaction fTrans = null;

        //    CLINEABE lineaBuffer = new CLINEABE();


        //    CLINEABE sustitutoBE;
        //    CLINEAD sustitutoD = new CLINEAD();

        //    int iOperation = (int)DBOperations.OperAgregar;
        //    bool bResult;
        //    try
        //    {
        //        fConn.Open();
        //        fTrans = fConn.BeginTransaction();
        //        while (dr.Read())
        //        {
        //            retorno = new CLINEABE();
        //            iOperation = (int)DBOperations.OperAgregar;

        //            if (dr["LINEA"] != System.DBNull.Value)
        //            {
        //                retorno.ICLAVE = (string)(dr["LINEA"]);
        //            }

        //            lineaBuffer = lineaD.seleccionarLINEAxCLAVE(retorno, fTrans);
        //            if (lineaBuffer != null)
        //            {
        //                retorno = lineaBuffer;
        //                iOperation = (int)DBOperations.OperCambiar;
        //            }


        //            if (dr["NOMBRE"] != System.DBNull.Value)
        //            {
        //                retorno.INOMBRE = (string)(dr["NOMBRE"]);
        //            }


        //            if (iOperation == (int)DBOperations.OperCambiar)
        //                bResult = lineaD.CambiarLINEAD(retorno, retorno, fTrans);
        //            else
        //                bResult = (lineaD.AgregarLINEAD(retorno, fTrans) != null);

        //            if (bResult == false)
        //            {
        //                this.IComentario = lineaD.IComentario;
        //                fTrans.Rollback();
        //                fConn.Close();
        //                return false;
        //            }


        //        }
        //        fTrans.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        fTrans.Rollback();
        //        fConn.Close();
        //        this.iComentario = ex.Message + ex.StackTrace;
        //        return false;
        //    }
        //    finally
        //    {
        //        fConn.Close();
        //    }
        //    return true;

        //}

            


        public bool ImportarDatosProd(string fileName, string path, bool bSoloNuevos)
        {
            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }

            decimal porcAumentoPrecio = 0;



            bool importarProductosNuevos = true;
            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.ICLAVE = parametroBE.ISUCURSALNUMERO;

            sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, null);
            if (sucursalBE != null && sucursalBE.IPORC_AUMENTO_PRECIO != null)
            {
                porcAumentoPrecio = sucursalBE.IPORC_AUMENTO_PRECIO;

                if (sucursalBE.IIMNUPROD != null && sucursalBE.IIMNUPROD.Trim().Equals("N"))
                    importarProductosNuevos = false;
            }







            string formatedLastDate = "2013,1,1";
            DateTime newUltDate = DateTime.Parse("01/01/2013");
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            if (!(bool)parametroBE.isnull["IIMP_PROD_TOTAL"])
            {
                if (parametroBE.IIMP_PROD_TOTAL == DBValues._DB_BOOLVALUE_NO)
                {
                    if (!(bool)parametroBE.isnull["IULT_FECHA_IMP_PROD"])
                    {
                        formatedLastDate = parametroBE.IULT_FECHA_IMP_PROD.Year.ToString() + "," + parametroBE.IULT_FECHA_IMP_PROD.Month.ToString("N0") + "," + parametroBE.IULT_FECHA_IMP_PROD.Day.ToString("N0");

                        newUltDate = parametroBE.IULT_FECHA_IMP_PROD;
                    }

                    CmdTxt = "SELECT * FROM " + fileName + " where fcambio >= date( " + formatedLastDate + ")";
                }
            }



            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString() + ";Connect Timeout=200000");
            FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();

            string[] nombreColumnas = { "CAMBIARPRE", "CBARRAS", "CEMPAQUE", "CODIGO", "COMIPADRE", "COMISION", "COSTO_REPO", "CVETASAIVA", "DESC", "DESC1", "DESC2", "DESC3", "ESFINAL", "ESPADRE", "ESSUBPROD", "FECHA1", "FECHA2", "IMPRIMIR", "IMPUESTO", "INIMAYO", "INVENTARIO", "KIT", "LIMITE2", "LINEA", "LOTE", "MARCA", "MAYOXKG", "MINUTIL", "MONEDA", "NEGATIVOS", "NOMBRE", "NUMERO1", "NUMERO2", "NUMERO3", "NUMERO4", "OFEPADRE", "OFERTA", "PLUG", "PRECIO1", "PRECIO2", "PRECIO3", "PRECIO4", "PRECIO5", "PRECIO6", "PRECIOMAT", "PRECPADRE", "PRECTOPE", "PRODPADRE", "PRODUCTO", "PROVEEDOR", "PROVEEDOR2", "PZACAJA", "RRECETA", "SPRECIO1", "SPRECIO2", "SPRECIO3", "SPRECIO4", "SPRECIO5", "SUSTITUTO", "TASAIEPS", "TEXTO1", "TEXTO2", "TEXTO3", "TEXTO4", "TEXTO5", "TEXTO6", "TIPOABC", "U_EMPAQUE", "UNIDAD", "LIMITE2", "RRECETA", "PRECTOPE", "MENUDEO", "CLAVE_CONT", "CONTENIDO", "UNIDAD2", "CANTXPIEZA", "LOTEIMPO", "COSTOUSD", "PLAZO", "PRODSAT", "CLAVESAT", "BASEPROM", "ESPRODPROM", "VIGPROM", "VIGKIT", "KITCVIG", "VALXSUC", "DESCTOPE", "MARGEN", "DESCPES", "DESGKIT", "PUPRECIO1", "PUPRECIO2", "PUPRECIO3", "PUPRECIO4", "PUPRECIO5" };
            Dictionary<string, bool> dictColumna = null;

            int iCount = 0;


            bool bAddPrecioSugerido = false;
            try
            {
                if (HasColumn(dr, "PRECIO6"))
                {
                    bAddPrecioSugerido = true;
                }
            }
            catch
            {

            }


            bool bAddPrecioTope = false;
            try
            {
                if (HasColumn(dr, "PRECTOPE"))
                {
                    bAddPrecioTope = true;
                }
            }
            catch
            {

            }


            bool bAddOferta = true;

            string claveLinea = "", claveMarca = "", claveMoneda = "", claveSustituto = "", claveTasaIva = "", claveProductoPadre = "", claveContenido = "", claveClasifica = "", clavePlazo = "";
            string claveProveedor1 = "", claveProveedor2 = "";
            string sat_tipoembalaje_clave = "", sat_claveunidadpeso_clave = "";
            string sat_matpeligroso_clave = "";
            DateTime fcambio;
            //int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();



                while (dr.Read())
                {
                    if (dictColumna == null)
                        dictColumna = obtenerExistenciaColumnas(nombreColumnas, dr);

                    claveLinea = ""; claveMarca = ""; claveMoneda = ""; claveSustituto = ""; claveTasaIva = ""; claveProductoPadre = ""; claveContenido = ""; claveClasifica = "";
                    claveProveedor1 = ""; claveProveedor2 = "";
                    retorno = new CPRODUCTOBE();
                    //iOperation = (int)DBOperations.OperAgregar;


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    try
                    {

                        if (HasColumnByDict(dictColumna, "NOMBRE") && dr["NOMBRE"] != System.DBNull.Value)
                        {
                            retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                        }
                        else
                        {
                            retorno.INOMBRE = retorno.ICLAVE;
                        }
                    }
                    catch
                    {
                        retorno.INOMBRE = retorno.ICLAVE;
                    }



                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        continue;

                    if (dr["FCAMBIO"] != System.DBNull.Value)
                    {
                        fcambio = fcambio = (DateTime)dr["FCAMBIO"];
                        if (newUltDate < fcambio)
                        {
                            newUltDate = fcambio;
                        }
                    }

                    
                    


                    // solo se hace esto cuando solo se quieran agregar los nuevos productos
                    if (bSoloNuevos || !importarProductosNuevos)
                    {
                        prodBuffer = productoD.seleccionarPRODUCTOPorClave(retorno, fTrans);
                        if (prodBuffer != null)
                        {

                            if(bSoloNuevos)
                                continue;
                        }
                        else
                        {
                            if (!importarProductosNuevos)
                                continue;
                        }
                    }


                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = ((string)(dr["DESC1"])).Trim();
                    }

                    try
                    {

                        if (HasColumnByDict(dictColumna, "DESC") && dr["DESC"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION = ((string)(dr["DESC"])).Trim();
                        }
                        else
                        {
                            retorno.IDESCRIPCION = retorno.IDESCRIPCION1;
                        }

                    }
                    catch
                    {
                        retorno.IDESCRIPCION = retorno.IDESCRIPCION1;
                    }

                    try
                    {
                        if (HasColumnByDict(dictColumna, "DESC2") && dr["DESC2"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION2 = ((string)(dr["DESC2"])).Trim();
                        }
                        else
                        {
                            retorno.IDESCRIPCION2 = retorno.IDESCRIPCION1;
                        }

                        if (HasColumnByDict(dictColumna, "DESC3") && dr["DESC3"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION3 = ((string)(dr["DESC3"])).Trim();
                        }
                        else
                        {
                            retorno.IDESCRIPCION3 = retorno.IDESCRIPCION1;
                        }
                    }
                    catch
                    {
                        retorno.IDESCRIPCION2 = retorno.IDESCRIPCION1;
                        retorno.IDESCRIPCION3 = retorno.IDESCRIPCION1;
                    }



                    if (dr["LINEA"] != System.DBNull.Value)
                    {

                        claveLinea = ((string)(dr["LINEA"])).Trim();
                    }
                    if (dr["MARCA"] != System.DBNull.Value)
                    {

                        claveMarca = ((string)(dr["MARCA"])).Trim();
                    }

                    try
                    {

                        if (HasColumnByDict(dictColumna, "PRECIOMAT") && dr["PRECIOMAT"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOMAT = ((string)(dr["PRECIOMAT"])).Trim();
                        }
                        else
                        {
                            retorno.IPRECIOMAT = "N";
                        }
                    }
                    catch
                    {
                        retorno.IPRECIOMAT = "N";
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        if (retorno.IPRECIOMAT.Equals("S"))
                        {
                            retorno.IPRECIO1 = (decimal)((dr["PRECIO1"]));
                        }
                        else
                        {
                            retorno.IPRECIO1 = (decimal)((dr["PRECIO1"])) * (1 + (porcAumentoPrecio / 100));
                        }
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)((dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)((dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)((dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)((dr["PRECIO5"]));
                    }

                    try
                    {

                        retorno.IPRECIOSUGERIDO = retorno.IPRECIO1;
                        if (HasColumnByDict(dictColumna, "PRECIO6") && dr["PRECIO6"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOSUGERIDO = (decimal)((dr["PRECIO6"]));
                            retorno.IPRECIO6 = (decimal)((dr["PRECIO6"]));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("5");
                    }


                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        /*monedaBE = new CMONEDABE();
                        monedaBE.ICLAVE = (string)(dr["MONEDA"]);
                        monedaBE = monedaD.seleccionarMONEDAxCLAVE(monedaBE, fTrans);
                        if (monedaBE != null)
                            retorno.IMONEDAID = monedaBE.IID;*/
                        claveMoneda = ((string)(dr["MONEDA"])).Trim();
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = (decimal)((dr["IMPUESTO"]));
                    }



                    if (dr["COSTO_REPO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)((dr["COSTO_REPO"]));
                    }
                    //if (dr["COSTOULTUS"] != System.DBNull.Value)
                    //{
                    //    retorno.ICOSTOULTIMO = (decimal)((dr["COSTOULTUS"]));
                    //}
                    /*if (dr["COSTOREPUS"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)((dr["COSTOREPUS"]));
                    }*/
                    if (dr["CODIGO"] != System.DBNull.Value)
                    {
                        retorno.IEAN = ((string)(dr["CODIGO"])).Trim();
                    }

                    if (dr["SUSTITUTO"] != System.DBNull.Value)
                    {
                        /*sustitutoBE = new CPRODUCTOBE();
                        sustitutoBE.ICLAVE = (string)(dr["SUSTITUTO"]);
                        if (sustitutoBE.ICLAVE.Trim() != "")
                        {
                            sustitutoBE = sustitutoD.seleccionarPRODUCTOxCLAVE(sustitutoBE, fTrans);
                            if (sustitutoBE != null)
                                retorno.IPRODUCTOSUSTITUTOID = sustitutoBE.IID;
                        }
                        else
                        {
                            retorno.isnull["IPRODUCTOSUSTITUTOID"] = true;
                        }*/
                        claveSustituto = ((string)(dr["SUSTITUTO"])).Trim();
                        claveSustituto = claveSustituto.Trim();
                    }


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = ((string)(dr["LOTE"])).Trim();
                    }
                    if (dr["KIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = ((string)(dr["KIT"])).Trim();
                    }
                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        if ((string)dr["IMPRIMIR"] != "S")
                            retorno.IIMPRIMIR = "N";
                        else
                            retorno.IIMPRIMIR = "S";
                    }
                    if (dr["INVENTARIO"] != System.DBNull.Value)
                    {
                        if ((string)(dr["INVENTARIO"]) != "S")
                            retorno.IINVENTARIABLE = "N";
                        else
                            retorno.IINVENTARIABLE = "S";

                    }
                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        if ((string)dr["NEGATIVOS"] != "S")
                            retorno.INEGATIVOS = "N";
                        else
                            retorno.INEGATIVOS = "S";
                    }


                    if (dr["SUSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUBSTITUTO = ((string)(dr["SUSTITUTO"])).Trim();
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = ((string)(dr["CBARRAS"])).Trim();
                    }


                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = ((string)(dr["CEMPAQUE"])).Trim();
                    }


                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }


                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.IU_EMPAQUE = (decimal)(dr["U_EMPAQUE"]);
                    }


                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD = ((string)(dr["UNIDAD"])).Trim();
                    }


                    if (dr["INIMAYO"] != System.DBNull.Value)
                    {
                        retorno.IINI_MAYO = (decimal)(dr["INIMAYO"]);
                    }

                    if (dr["MAYOXKG"] != System.DBNull.Value)
                    {
                        retorno.IMAYOKGS = ((string)(dr["MAYOXKG"])).Trim();

                        if (retorno.IMAYOKGS.Trim() == "")
                            retorno.IMAYOKGS = "N";
                    }
                    else
                    {
                        retorno.IMAYOKGS = "N";
                    }


                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = ((string)(dr["TIPOABC"])).Trim();

                        if (retorno.ITIPOABC.Trim() != "N")
                            retorno.ITIPOABC = "S";
                    }
                    else
                    {
                        retorno.ITIPOABC = "S";
                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "CVETASAIVA") && dr["CVETASAIVA"] != System.DBNull.Value)
                        {
                            claveTasaIva = ((string)(dr["CVETASAIVA"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {

                        if (HasColumnByDict(dictColumna, "TEXTO1") && dr["TEXTO1"] != System.DBNull.Value)
                        {
                            retorno.ITEXTO1 = ((string)(dr["TEXTO1"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "TEXTO2") && dr["TEXTO2"] != System.DBNull.Value)
                        {
                            retorno.ITEXTO2 = ((string)(dr["TEXTO2"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "TEXTO3") && dr["TEXTO3"] != System.DBNull.Value)
                        {
                            retorno.ITEXTO3 = ((string)(dr["TEXTO3"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "TEXTO4") && dr["TEXTO4"] != System.DBNull.Value)
                        {
                            retorno.ITEXTO4 = ((string)(dr["TEXTO4"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "TEXTO5") && dr["TEXTO5"] != System.DBNull.Value)
                        {
                            retorno.ITEXTO5 = ((string)(dr["TEXTO5"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "TEXTO6") && dr["TEXTO6"] != System.DBNull.Value)
                        {
                            retorno.ITEXTO6 = ((string)(dr["TEXTO6"])).Trim();
                        }


                        if (HasColumnByDict(dictColumna, "NUMERO1") && dr["NUMERO1"] != System.DBNull.Value)
                        {
                            retorno.INUMERO1 = (decimal)(dr["NUMERO1"]);
                        }
                        if (HasColumnByDict(dictColumna, "NUMERO2") && dr["NUMERO2"] != System.DBNull.Value)
                        {
                            retorno.INUMERO2 = (decimal)(dr["NUMERO2"]);
                        }
                        if (HasColumnByDict(dictColumna, "NUMERO3") && dr["NUMERO3"] != System.DBNull.Value)
                        {
                            retorno.INUMERO3 = (decimal)(dr["NUMERO3"]);
                        }
                        if (HasColumnByDict(dictColumna, "NUMERO4") && dr["NUMERO4"] != System.DBNull.Value)
                        {
                            retorno.INUMERO4 = (decimal)(dr["NUMERO4"]);
                        }

                        if (HasColumnByDict(dictColumna, "FECHA1") && dr["FECHA1"] != System.DBNull.Value)
                        {
                            try
                            {
                                retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
                            }
                            catch
                            {
                                retorno.IFECHA1 = DateTime.MinValue;
                            }
                        }
                        if (HasColumnByDict(dictColumna, "FECHA2") && dr["FECHA2"] != System.DBNull.Value)
                        {
                            try
                            {
                                if (((string)dr["FECHA2"]).Trim().Length > 5)
                                    retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                                else
                                    retorno.IFECHA2 = DateTime.MinValue;
                            }
                            catch (Exception ex)
                            {
                                retorno.IFECHA2 = DateTime.MinValue;
                            }
                        }


                    }
                    catch
                    {
                    }


                    try
                    {

                        if (HasColumnByDict(dictColumna, "PRODPADRE") && dr["PRODPADRE"] != System.DBNull.Value)
                        {
                            claveProductoPadre = ((string)(dr["PRODPADRE"])).Trim();
                        }


                        if (HasColumnByDict(dictColumna, "ESPADRE") && dr["ESPADRE"] != System.DBNull.Value)
                        {
                            retorno.IESPRODUCTOPADRE = ((string)(dr["ESPADRE"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "ESFINAL") && dr["ESFINAL"] != System.DBNull.Value)
                        {
                            retorno.IESPRODUCTOFINAL = ((string)(dr["ESFINAL"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "ESSUBPROD") && dr["ESSUBPROD"] != System.DBNull.Value)
                        {
                            retorno.IESSUBPRODUCTO = ((string)(dr["ESSUBPROD"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "PRECPADRE") && dr["PRECPADRE"] != System.DBNull.Value)
                        {
                            retorno.ITOMARPRECIOPADRE = ((string)(dr["PRECPADRE"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "COMIPADRE") && dr["COMIPADRE"] != System.DBNull.Value)
                        {
                            retorno.ITOMARCOMISIONPADRE = ((string)(dr["COMIPADRE"])).Trim();
                        }
                        if (HasColumnByDict(dictColumna, "OFEPADRE") && dr["OFEPADRE"] != System.DBNull.Value)
                        {
                            retorno.ITOMAROFERTAPADRE = ((string)(dr["OFEPADRE"])).Trim();

                        }


                        if (HasColumnByDict(dictColumna, "COMISION") && dr["COMISION"] != System.DBNull.Value)
                        {
                            retorno.ICOMISION = (decimal)(dr["COMISION"]);
                        }

                    }
                    catch
                    {
                    }


                    try
                    {

                        if (HasColumnByDict(dictColumna, "PROVEEDOR") && dr["PROVEEDOR"] != System.DBNull.Value)
                        {
                            claveProveedor1 = ((string)(dr["PROVEEDOR"])).Trim();
                        }

                        if (HasColumnByDict(dictColumna, "PROVEEDOR2") && dr["PROVEEDOR2"] != System.DBNull.Value)
                        {
                            claveProveedor2 = ((string)(dr["PROVEEDOR2"])).Trim();
                        }

                        if (bAddOferta  && HasColumnByDict(dictColumna, "OFERTA") && dr["OFERTA"] != System.DBNull.Value)
                        {
                            try
                            {
                                retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                            }
                            catch (Exception ex)
                            {
                                bAddOferta = false;
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                        }

                        if (HasColumnByDict(dictColumna, "CAMBIARPRE") && dr["CAMBIARPRE"] != System.DBNull.Value)
                        {
                            retorno.ICAMBIARPRECIO = ((string)(dr["CAMBIARPRE"])).Trim();
                        }
                    }
                    catch (Exception ex)
                    {

                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "PLUG") && dr["PLUG"] != System.DBNull.Value)
                        {
                            retorno.IPLUG = ((string)(dr["PLUG"])).Trim();
                        }
                        /*else if (dr["SUSTITUTO"] != System.DBNull.Value)
                        {
                            retorno.IPLUG = ((string)(dr["SUSTITUTO"])).Trim();
                        }*/
                    }
                    catch
                    {
                    }



                    try
                    {
                        if (HasColumnByDict(dictColumna, "TASAIEPS") && dr["TASAIEPS"] != System.DBNull.Value)
                        {
                            retorno.ITASAIEPS = (decimal)((dr["TASAIEPS"]));
                        }
                    }
                    catch
                    {
                    }



                    try
                    {
                        if (HasColumnByDict(dictColumna, "MINUTIL") && dr["MINUTIL"] != System.DBNull.Value)
                        {
                            retorno.IMINUTILIDAD = (decimal)((dr["MINUTIL"]));
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (HasColumnByDict(dictColumna, "SPRECIO1") && dr["SPRECIO1"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO1 = (decimal)((dr["SPRECIO1"]));
                        }
                        if (HasColumnByDict(dictColumna, "SPRECIO2") && dr["SPRECIO2"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO2 = (decimal)((dr["SPRECIO2"]));
                        }
                        if (HasColumnByDict(dictColumna, "SPRECIO3") && dr["SPRECIO3"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO3 = (decimal)((dr["SPRECIO3"]));
                        }
                        if (HasColumnByDict(dictColumna, "SPRECIO4") && dr["SPRECIO4"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO4 = (decimal)((dr["SPRECIO4"]));
                        }
                        if (HasColumnByDict(dictColumna, "SPRECIO5") && dr["SPRECIO5"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO5 = (decimal)((dr["SPRECIO5"]));
                        }
                    }
                    catch
                    {
                    }



                    if (HasColumnByDict(dictColumna, "LIMITE2") && dr["LIMITE2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITE2"]);
                    }


                    retorno.IREQUIERERECETA = @"N";
                    try
                    {
                        retorno.IREQUIERERECETA = @"N";
                        if (HasColumnByDict(dictColumna, "RRECETA") && dr["RRECETA"] != System.DBNull.Value)
                        {
                            retorno.IREQUIERERECETA = ((string)(dr["RRECETA"])).Trim();
                        }
                        else
                        {

                            retorno.IREQUIERERECETA = @"N";
                        }
                    }
                    catch
                    {
                        retorno.IREQUIERERECETA = @"N";
                    }


                    /*

                    try
                    {
                        retorno.IPRECIOSUGERIDO = retorno.IPRECIO1;

                        
                        if (bAddPrecioSugerido)
                        {
                            
                            if (dr["PRECIO6"] != System.DBNull.Value)
                            {
                                retorno.IPRECIOSUGERIDO = (decimal)((dr["PRECIO6"]));

                                

                            }
                        }

                    }
                    catch
                    {
                    }*/

                    if ((!((bool)parametroBE.isnull["ICAMPOIMPOCOSTOREPO"])) && parametroBE.ICAMPOIMPOCOSTOREPO != 0)
                    {
                        switch (parametroBE.ICAMPOIMPOCOSTOREPO)
                        {
                            case 1: retorno.ICOSTOREPOSICION = retorno.IPRECIO1 > 0.1m ? retorno.IPRECIO1 - 0.1m : 0; break;
                            case 2: retorno.ICOSTOREPOSICION = retorno.IPRECIO2 > 0.1m ? retorno.IPRECIO2 - 0.1m : 0; break;
                            case 3: retorno.ICOSTOREPOSICION = retorno.IPRECIO3 > 0.1m ? retorno.IPRECIO3 - 0.1m : 0; break;
                            case 4: retorno.ICOSTOREPOSICION = retorno.IPRECIO4 > 0.1m ? retorno.IPRECIO4 - 0.1m : 0; break;
                            case 5: retorno.ICOSTOREPOSICION = retorno.IPRECIO5 > 0.1m ? retorno.IPRECIO5 - 0.1m : 0; break;
                        }
                    }

                    try
                    {
                        retorno.IPRECIOTOPE = 0;
                        if (bAddPrecioTope)
                        {
                            if (dr["PRECTOPE"] != System.DBNull.Value)
                            {
                                retorno.IPRECIOTOPE = (decimal)((dr["PRECTOPE"])); // (decimal)((dr["PRECTOPE"])) * (1 + (porcAumentoPrecio / 100)); ;
                            }
                        }

                    }
                    catch
                    {
                    }




                    try
                    {
                        retorno.IMENUDEO = 0;
                        if (HasColumnByDict(dictColumna, "MENUDEO") && dr["MENUDEO"] != System.DBNull.Value)
                        {
                            retorno.IMENUDEO = decimal.Parse(((decimal)(dr["MENUDEO"])).ToString());
                        }
                        else
                        {

                            retorno.IMENUDEO = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        retorno.IMENUDEO = 0;
                    }



                    if (dr["CLAVE_CONT"] != System.DBNull.Value)
                    {

                        claveContenido = ((string)(dr["CLAVE_CONT"])).Trim();
                    }

                    try
                    {
                        retorno.ICONTENIDOVALOR = 0;
                        if (HasColumnByDict(dictColumna, "CONTENIDO") && dr["CONTENIDO"] != System.DBNull.Value)
                        {
                            retorno.ICONTENIDOVALOR = (decimal)(dr["CONTENIDO"]);
                        }
                        else
                        {

                            retorno.ICONTENIDOVALOR = 0;
                        }
                    }
                    catch
                    {
                        retorno.ICONTENIDOVALOR = 0; ;
                    }



                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {

                        claveClasifica = ((string)(dr["CLASIFICA"])).Trim();
                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "UNIDAD2") && dr["UNIDAD2"] != System.DBNull.Value)
                        {
                            retorno.IUNIDAD2 = ((string)(dr["UNIDAD2"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "CANTXPIEZA") && dr["CANTXPIEZA"] != System.DBNull.Value)
                        {
                            retorno.ICANTXPIEZA = decimal.Parse(dr["CANTXPIEZA"].ToString());
                        }
                    }
                    catch
                    {
                    }




                    try
                    {
                        if (HasColumnByDict(dictColumna, "LOTEIMPO") && dr["LOTEIMPO"] != System.DBNull.Value)
                        {
                            retorno.IMANEJALOTEIMPORTADO = ((string)(dr["LOTEIMPO"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "COSTOUSD") && dr["COSTOUSD"] != System.DBNull.Value)
                        {
                            retorno.ICOSTOENDOLAR = decimal.Parse(dr["COSTOUSD"].ToString());
                        }
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "PLAZO") && dr["PLAZO"] != System.DBNull.Value)
                        {
                            clavePlazo = dr["PLAZO"].ToString();
                        }
                    }
                    catch
                    {
                    }


                    string claveSat = String.Empty;

                    try
                    {
                        if (HasColumnByDict(dictColumna, "PRODSAT") && dr["PRODSAT"] != System.DBNull.Value)
                        {
                            claveSat = dr["PRODSAT"].ToString().Trim();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                        if (HasColumnByDict(dictColumna, "CLAVESAT") && dr["CLAVESAT"] != System.DBNull.Value)
                        {
                            claveSat = dr["CLAVESAT"].ToString().Trim();
                        }
                    }
                    catch
                    {

                    }


                    string claveProdProm = String.Empty;

                    try
                    {
                        if (HasColumnByDict(dictColumna, "BASEPROM") && dr["BASEPROM"] != System.DBNull.Value)
                        {
                            claveProdProm = dr["BASEPROM"].ToString();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "ESPRODPROM") && dr["ESPRODPROM"] != System.DBNull.Value)
                        {
                            retorno.IESPRODPROMO = dr["ESPRODPROM"].ToString();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {

                        if (HasColumnByDict(dictColumna, "VIGPROM") && dr["VIGPROM"] != System.DBNull.Value)
                        {
                            try
                            {
                                if (((string)dr["VIGPROM"]).Trim().Length > 5)
                                    retorno.IVIGENCIAPRODPROMO = (DateTime)(dr["VIGPROM"]);
                                else
                                    retorno.isnull["IVIGENCIAPRODPROMO"] = true;
                            }
                            catch (Exception ex)
                            {
                                retorno.isnull["IVIGENCIAPRODPROMO"] = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        retorno.isnull["IVIGENCIAPRODPROMO"] = true;
                    }

                    try
                    {

                        if (HasColumnByDict(dictColumna, "VIGKIT") && dr["VIGKIT"] != System.DBNull.Value)
                        {
                            try
                            {
                                retorno.IVIGENCIAPRODKIT = (DateTime)(dr["VIGKIT"]);
                            }
                            catch (Exception ex)
                            {
                                retorno.isnull["IVIGENCIAPRODKIT"] = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        retorno.isnull["IVIGENCIAPRODKIT"] = true;
                    }


                    try
                    {

                        if (HasColumnByDict(dictColumna, "KITCVIG") && dr["KITCVIG"] != System.DBNull.Value)
                        {
                            try
                            {
                                retorno.IKITTIENEVIG = (string)(dr["KITCVIG"]);
                            }
                            catch (Exception ex)
                            {
                                retorno.isnull["IKITTIENEVIG"] = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        retorno.isnull["IKITTIENEVIG"] = true;
                    }


                    try
                    {

                        if (HasColumnByDict(dictColumna, "VALXSUC") && dr["VALXSUC"] != System.DBNull.Value)
                        {
                            try
                            {
                                retorno.IVALXSUC = (string)(dr["VALXSUC"]);
                            }
                            catch (Exception ex)
                            {
                                retorno.isnull["IVALXSUC"] = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        retorno.isnull["IVALXSUC"] = true;
                    }

                    try
                    {
                        if (HasColumnByDict(dictColumna, "DESCTOPE") && dr["DESCTOPE"] != System.DBNull.Value)
                        {
                            retorno.IDESCTOPE = (decimal)dr["DESCTOPE"];
                        }
                    }
                    catch { }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "MARGEN") && dr["MARGEN"] != System.DBNull.Value)
                        {
                            retorno.IMARGEN = (decimal)dr["MARGEN"];
                        }
                    }
                    catch { }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "DESCPES") && dr["DESCPES"] != System.DBNull.Value)
                        {
                            retorno.IDESCPES = (decimal)dr["DESCPES"];
                        }
                    }
                    catch { }


                    if (!(bool)parametroBE.isnull["IVERSIONTOPEID"] && parametroBE.IVERSIONTOPEID == 2)
                    {
                            try
                            {
                                decimal multDesc = 1m;
                                string prefijo = sucursalBE.IPREFIJOPRECIOXDESCUENTO != null ? sucursalBE.IPREFIJOPRECIOXDESCUENTO : "-";
                                try
                                {
                                    if (HasColumnByDict(dictColumna, prefijo + "PRECIO7") && dr[prefijo + "PRECIO7"] != System.DBNull.Value)
                                    {
                                        retorno.IDESCTOPE = (decimal)((dr[prefijo + "PRECIO7"]));
                                        multDesc = (100.00m - ((decimal)((dr[prefijo + "PRECIO7"])))) / 100.00m;
                                        retorno.IPRECIOTOPE = retorno.IPRECIO1 * multDesc;
                                    }
                                }
                                catch{}
                            }
                            catch{ }
                    }

                    try
                    {

                        if (HasColumnByDict(dictColumna, "DESGKIT") && dr["DESGKIT"] != System.DBNull.Value)
                        {
                            if (dr["DESGKIT"] != System.DBNull.Value)
                            {
                                bool bDESGKIT = (bool)(dr["DESGKIT"]);
                                retorno.IKITIMPFIJO = bDESGKIT ? "N" : "S";
                            }
                        }

                    }
                    catch{ }


                    try
                    {
                        if (HasColumnByDict(dictColumna, "PUPRECIO1") && dr["PUPRECIO1"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO1 = (decimal)((dr["PUPRECIO1"]));
                        }
                        if (HasColumnByDict(dictColumna, "PUPRECIO2") && dr["PUPRECIO2"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO2 = (decimal)((dr["PUPRECIO2"]));
                        }
                        if (HasColumnByDict(dictColumna, "PUPRECIO3") && dr["PUPRECIO3"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO3 = (decimal)((dr["PUPRECIO3"]));
                        }
                        if (HasColumnByDict(dictColumna, "PUPRECIO4") && dr["PUPRECIO4"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO4 = (decimal)((dr["PUPRECIO4"]));
                        }
                        if (HasColumnByDict(dictColumna, "PUPRECIO5") && dr["PUPRECIO5"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO5 = (decimal)((dr["PUPRECIO5"]));
                        }
                    }
                    catch
                    {
                    }

                    try
                    {

                        if (dr["IMPCOM"] != System.DBNull.Value)
                        {
                            if ((string)dr["IMPCOM"] != "S")
                                retorno.IIMPRIMIRCOMANDA = "N";
                            else
                                retorno.IIMPRIMIRCOMANDA = "S";
                        }
                    }
                    catch {

                        retorno.IIMPRIMIRCOMANDA = "N";
                    }

                    try
                    {
                        if (HasColumnByDict(dictColumna, "LMEDMAY") && dr["LMEDMAY"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECMEDIOMAYID = long.Parse(dr["LMEDMAY"].ToString()) ;
                        }
                        if (HasColumnByDict(dictColumna, "LMAYO") && dr["LMAYO"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECMAYOREOID= long.Parse(dr["LMAYO"].ToString());
                        }
                        if (HasColumnByDict(dictColumna, "CMEDMAY") && dr["CMEDMAY"] != System.DBNull.Value)
                        {
                            retorno.ICANTMEDIOMAY = (decimal)((dr["CMEDMAY"]));
                        }
                        if (HasColumnByDict(dictColumna, "CMAYO") && dr["CMAYO"] != System.DBNull.Value)
                        {
                            retorno.ICANTMAYOREO = (decimal)((dr["CMAYO"]));
                        }
                    }
                    catch(Exception ex)
                    { }



                    try
                    {
                        

                        if (HasColumnByDict(dictColumna, "TIPOEMB") && dr["TIPOEMB"] != System.DBNull.Value)
                        {
                            sat_tipoembalaje_clave = dr["TIPOEMB"].ToString();
                        }


                        if (HasColumnByDict(dictColumna, "CVEUPESO") && dr["CVEUPESO"] != System.DBNull.Value)
                        {
                            sat_claveunidadpeso_clave = dr["CVEUPESO"].ToString();
                        }


                        if (HasColumnByDict(dictColumna, "PESO") && dr["PESO"] != System.DBNull.Value)
                        {
                            retorno.IPESO = (decimal)((dr["PESO"]));
                        }

                        if (dr["ESPELIG"] != System.DBNull.Value)
                        {
                            if ((string)dr["ESPELIG"] != "S")
                                retorno.IESPELIGROSO = "N";
                            else
                                retorno.IESPELIGROSO = "S";
                        }

                        if (HasColumnByDict(dictColumna, "MATPELI") && dr["MATPELI"] != System.DBNull.Value)
                        {
                            sat_matpeligroso_clave = dr["MATPELI"].ToString();
                        }


                        if (dr["ESOFERTA"] != System.DBNull.Value)
                        {
                            if ((string)dr["ESOFERTA"] != "S")
                                retorno.IESOFERTA = "N";
                            else
                                retorno.IESOFERTA = "S";
                        }

                    }
                    catch (Exception ex)
                    { }

                    //retorno.IACTIVO = "S";

                    /*if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = productoD.CambiarPRODUCTOD(retorno, retorno, fTrans);
                    else
                        bResult = (productoD.AgregarPRODUCTOD(retorno, fTrans) != null);
                    */
                    bResult = productoD.importarPRODUCTOD(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, claveContenido, claveClasifica, clavePlazo, claveSat, claveProdProm, sat_tipoembalaje_clave, sat_claveunidadpeso_clave, sat_matpeligroso_clave, fTrans);
                    if (bResult == false)
                    {
                        this.IComentario = productoD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }
                    iCount++;

                    if (iCount % 1000 == 0)
                    {
                        fTrans.Commit();
                        fConn.Close();
                        fConn.Open();
                        fTrans = fConn.BeginTransaction();
                    }


                }

                if (!productoD.PRODUCTOPRECIO(fTrans))
                    fTrans.Rollback();



                parametroBE.IULT_FECHA_IMP_PROD = newUltDate;
                if (!parametroD.CambiarUltimaFechaCambioProdPARAMETROD(parametroBE, parametroBE, fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                parametroBE.ILASTCHANGEPRECIOPROD = newUltDate;
                if (!parametroD.CambiarLASTCHANGEPRECIOPROD(parametroBE, parametroBE, fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }


                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool ImportarDatosTerminal(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CTERMINALPAGOSERVICIOD terminalD = new CTERMINALPAGOSERVICIOD();
            CTERMINALPAGOSERVICIOBE retorno = new CTERMINALPAGOSERVICIOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CTERMINALPAGOSERVICIOBE terminalBuffer = new CTERMINALPAGOSERVICIOBE();



            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);

            if (parametroBE == null)
                return false;

            sucBE.IID = parametroBE.ISUCURSALID;
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE == null)
                return false;



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CTERMINALPAGOSERVICIOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        retorno.ITERMINAL = ((string)(dr["TERMINAL"])).Trim();
                    }

                    if (dr["ESSERV"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = ((string)(dr["ESSERV"])).Trim();
                    }


                    terminalBuffer = terminalD.seleccionarTERMINALPAGOSERVICIOXTERMINAL(retorno, fTrans);
                    if (terminalBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = terminalBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["SUCCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = ((string)(dr["SUCCLAVE"])).Trim();
                        if (!retorno.ISUCURSALCLAVE.Equals(sucBE.ICLAVE))
                        {
                            continue;
                        }
                        else
                        {
                            retorno.ISUCURSALID = sucBE.IID;
                        }
                    }
                    else
                    {
                        continue;
                    }



                    if (dr["ESSERV"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = ((string)(dr["ESSERV"])).Trim();

                        if (retorno.IESSERVICIO != "S")
                            retorno.IESSERVICIO = "N";
                    }
                    else
                    {
                        retorno.IESSERVICIO = "N";
                    }






                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = terminalD.CambiarTERMINALPAGOSERVICIOD(retorno, retorno, fTrans);
                    else
                        bResult = (terminalD.AgregarTERMINALPAGOSERVICIOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = terminalD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }






        public bool ImportarDatosProdSuc(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPRODUCTOBE bufferProd = new CPRODUCTOBE();

            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);

            if (parametroBE == null)
                return false;

            sucBE.IID = parametroBE.ISUCURSALID;
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE == null)
                return false;



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                if(!prodD.InactivarProductosKitValidosXSuc(fTrans))
                {

                    this.IComentario = prodD.IComentario;
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                while (dr.Read())
                {
                    retorno = new CPRODUCTOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }


                    retorno  = prodD.seleccionarPRODUCTOPorClave(retorno, fTrans);
                    if (retorno == null)
                    {
                        continue;
                    }


                    if (dr["SUCCLAVE"] != System.DBNull.Value)
                    {
                        string sucursalClave = ((string)(dr["SUCCLAVE"])).Trim();
                        if (!sucursalClave.Equals(sucBE.ICLAVE))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }


                    retorno.IACTIVO = "S";
                    bResult = prodD.CambiarActivoPRODUCTO(retorno, fTrans);



                    if (bResult == false)
                    {
                        this.IComentario = prodD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }







        public bool ImportarDatosListaPrecio(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CLISTAPRECIOD itemD = new CLISTAPRECIOD();
            CLISTAPRECIOBE retorno = new CLISTAPRECIOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CLISTAPRECIOBE itemBuffer = new CLISTAPRECIOBE();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CLISTAPRECIOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLAVE"])).Trim();
                    }

                    itemBuffer = itemD.seleccionarLISTAPRECIOxCLAVE(retorno, fTrans);
                    if (itemBuffer != null)
                    {
                        retorno = itemBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarLISTAPRECIOD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarLISTAPRECIOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarDatosMerchant(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CMERCHANTPAGOSERVICIOD merchantD = new CMERCHANTPAGOSERVICIOD();
            CMERCHANTPAGOSERVICIOBE retorno = new CMERCHANTPAGOSERVICIOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CMERCHANTPAGOSERVICIOBE merchantBuffer = new CMERCHANTPAGOSERVICIOBE();



            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);

            if (parametroBE == null)
                return false;

            sucBE.IID = parametroBE.ISUCURSALID;
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE == null)
                return false;



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CMERCHANTPAGOSERVICIOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["MERCHANT"] != System.DBNull.Value)
                    {
                        retorno.IMERCHANTID = ((string)(dr["MERCHANT"])).Trim();
                    }


                    if (dr["ESSERV"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = ((string)(dr["ESSERV"])).Trim();
                    }


                    merchantBuffer = merchantD.seleccionarMERCHANTPAGOSERVICIOxMERCHANTID(retorno, fTrans);
                    if (merchantBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = merchantBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["SUCCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = ((string)(dr["SUCCLAVE"])).Trim();
                        if (!retorno.ISUCURSALCLAVE.Equals(sucBE.ICLAVE))
                        {
                            continue;
                        }
                        else
                        {
                            retorno.ISUCURSALID = sucBE.IID;
                        }
                    }
                    else
                    {
                        continue;
                    }


                    if (dr["ESSERV"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = ((string)(dr["ESSERV"])).Trim();

                        if (retorno.IESSERVICIO != "S")
                            retorno.IESSERVICIO = "N";
                    }
                    else
                    {
                        retorno.IESSERVICIO = "N";
                    }



                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = merchantD.CambiarMERCHANTPAGOSERVICIOD(retorno, retorno, fTrans);
                    else
                        bResult = (merchantD.AgregarMERCHANTPAGOSERVICIOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = merchantD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }





        public bool ImportarDatosClerk(string fileName, string path, bool bSoloNuevos)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CCLERKPAGOSERVICIOD clerkD = new CCLERKPAGOSERVICIOD();
            CCLERKPAGOSERVICIOBE retorno = new CCLERKPAGOSERVICIOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CCLERKPAGOSERVICIOBE clerkBuffer = new CCLERKPAGOSERVICIOBE();



            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);

            if (parametroBE == null)
                return false;

            sucBE.IID = parametroBE.ISUCURSALID;
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE == null)
                return false;



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CCLERKPAGOSERVICIOBE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr["CLERK"] != System.DBNull.Value)
                    {
                        retorno.ICLERKID = ((string)(dr["CLERK"])).Trim();
                    }

                    if (dr["ESSERV"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = ((string)(dr["ESSERV"])).Trim();
                    }

                    clerkBuffer = clerkD.seleccionarCLERKPAGOSERVICIOxCLERKID(retorno, fTrans);
                    if (clerkBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = clerkBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr["SUCCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = ((string)(dr["SUCCLAVE"])).Trim();
                        if (!retorno.ISUCURSALCLAVE.Equals(sucBE.ICLAVE))
                        {
                            continue;
                        }
                        else
                        {
                            retorno.ISUCURSALID = sucBE.IID;
                        }
                    }
                    else
                    {
                        continue;
                    }


                    if (dr["ESSERV"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = ((string)(dr["ESSERV"])).Trim();

                        if (retorno.IESSERVICIO != "S")
                            retorno.IESSERVICIO = "N";
                    }
                    else
                    {
                        retorno.IESSERVICIO = "N";
                    }


                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = clerkD.CambiarCLERKPAGOSERVICIOD(retorno, retorno, fTrans);
                    else
                        bResult = (clerkD.AgregarCLERKPAGOSERVICIOD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        this.IComentario = clerkD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }


        public bool HasColumnByDict(Dictionary<string, bool> dictColumna, string columna)
        {
            if (dictColumna.ContainsKey(columna))
            {
                return dictColumna[columna];
            }

            return true;
        }


        public Dictionary<string, bool> obtenerExistenciaColumnas(string[] columnas, DbDataReader reader)
        {
            Dictionary<string, bool> existenciaColumna = new Dictionary<string, bool>();
            foreach (string columna in columnas)
            {
                try
                {
                    existenciaColumna.Add(columna, /*HasColumn(reader, columna)*/ColumnExists(reader, columna));
                }
                catch (Exception ex)
                {
                    int i = 0;
                }
            }


            return existenciaColumna;
        }


        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string str = reader.GetName(i);
                if (str.ToLower() == columnName.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        



        private CPRODUCTOBE cambiarPrecioTopeVersion2SiAplica(CPARAMETROBE parametroBE, Dictionary<string, bool> dictColumna, CPRODUCTOBE retorno, CSUCURSALBE sucursalBE, OdbcDataReader dr)
        {
            if (parametroBE.IVERSIONTOPEID == 2)
            {
                try
                {
                    decimal multDesc = 1m;
                    string prefijo = sucursalBE.IPREFIJOPRECIOXDESCUENTO != null ? sucursalBE.IPREFIJOPRECIOXDESCUENTO : "-";


                     try
                    {

                        if (HasColumnByDict(dictColumna, prefijo + "PRECIO7") && dr[prefijo + "PRECIO7"] != System.DBNull.Value)
                        {

                            multDesc = (100.00m - ((decimal)((dr[prefijo + "PRECIO7"])))) / 100.00m;
                            retorno.IPRECIOTOPE = retorno.IPRECIO1 * multDesc;
                        }
                    }
                    catch
                    {
                    }

                    
                   
                }
                catch
                {
                }

            }

            return retorno;
        }


        public static bool HasColumn(DbDataReader Reader, string ColumnName)
        {
            foreach (DataRow row in Reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString().ToLower() == ColumnName.ToLower())
                    return true;
            } //Still here? Column not found. 
            return false;
        }




        public bool ImportarDatosProd_Precios(string fileName, string path, bool bSoloNuevos, string sucursalClave)
        {



            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;

            if (!File.Exists(path + "\\" + fileName))
            {
                return true;
            }


            string CmdTxt = "SELECT * FROM " + fileName;



            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();



            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPRODUCTOBE();


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    try
                    {
                        if (dr["NOMBRE"] != System.DBNull.Value)
                        {
                            retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                        }
                    }
                    catch
                    {
                        retorno.INOMBRE = retorno.ICLAVE;
                    }



                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        continue;


                    try
                    {
                        if (dr["SUCURSAL"] == System.DBNull.Value)
                            continue;


                        string strSucursal = (string)dr["SUCURSAL"];
                        if (!strSucursal.Trim().Equals(sucursalClave.Trim()))
                            continue;


                    }
                    catch
                    {
                        continue;
                    }




                    // solo se hace esto cuando solo se quieran agregar los nuevos productos
                    if (bSoloNuevos)
                    {
                        prodBuffer = productoD.seleccionarPRODUCTOPorClave(retorno, fTrans);
                        if (prodBuffer != null)
                        {
                            continue;
                        }
                    }



                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)((dr["PRECIO1"]));
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)((dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)((dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)((dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)((dr["PRECIO5"]));
                    }

                    bResult = productoD.importarPRODUCTOPRECIOD(retorno, fTrans);
                    if (bResult == false)
                    {
                        this.IComentario = productoD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }

                if (!productoD.PRODUCTOPRECIO(fTrans))
                    fTrans.Rollback();





                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }






        public bool ImportarDatosProd_PrecTemp(string fileName, string path)
        {



            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;

            if (!File.Exists(path + "\\" + fileName))
            {
                return true;
            }


            string CmdTxt = "SELECT * FROM " + fileName;



            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRECIOSTEMPD preciosTempD = new CPRECIOSTEMPD();
            CPRECIOSTEMPBE retorno = new CPRECIOSTEMPBE();
            CPRODUCTOBE productoBE = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();



            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    productoBE = new CPRODUCTOBE();


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        productoBE.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }




                    if ((bool)productoBE.isnull["ICLAVE"] || productoBE.ICLAVE.Trim() == "")
                        continue;





                    prodBuffer = productoD.seleccionarPRODUCTOPorClave(productoBE, fTrans);
                    if (prodBuffer == null)
                    {
                        continue;
                    }


                    retorno.IPRODUCTOID = prodBuffer.IID;



                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)((dr["PRECIO1"]));
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)((dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)((dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)((dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)((dr["PRECIO5"]));
                    }


                    if (dr["SUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDO = (decimal)((dr["SUGERIDO"]));
                    }


                    bResult = preciosTempD.importarPrecioTempD(retorno, fTrans);
                    if (bResult == false)
                    {
                        this.IComentario = productoD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }






                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ImportarDatosProd_Precios_PorLista(string fileName, string path)
        {



            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.IID = parametroBE.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            if(sucursalBE == null)
            {
                return false;
            }

            if(sucursalBE.ILISTAPRECIOCLAVE == null || sucursalBE.ILISTAPRECIOCLAVE.Trim().Length == 0)
            {
                return true;
            }

            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;

            if (!File.Exists(path + "\\" + fileName))
            {
                return true;
            }


            string CmdTxt = "SELECT * FROM " + fileName + "  where LISTA = '" + sucursalBE.ILISTAPRECIOCLAVE +  "'";



            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();



            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    retorno = new CPRODUCTOBE();


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                        retorno.INOMBRE = ((string)(dr["PRODUCTO"])).Trim();
                    }


                    

                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        continue;

                    

                    


                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)((dr["PRECIO1"]));
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)((dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)((dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)((dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)((dr["PRECIO5"]));
                    }

                    try
                    {
                        if (dr["COSTOREP"] != System.DBNull.Value)
                        {
                            retorno.ICOSTOREPOSICION = (decimal)((dr["COSTOREP"]));
                        }

                        string tieneVig = "N";
                        if (dr["TIENEVIG"] != System.DBNull.Value)
                        {
                            tieneVig = dr["TIENEVIG"].ToString(); 

                            if(tieneVig == "S")
                            {
                                DateTime fechavig = (DateTime)dr["FECHAVIG"];
                                if(fechavig != null && fechavig < DateTime.Today)
                                {
                                    continue;
                                }
                            }
                        }

                    }
                    catch
                    {
                    }


                    bResult = productoD.importarPRODUCTOPRECIOLISTAD(retorno, fTrans);
                    if (bResult == false)
                    {
                        this.IComentario = productoD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }





                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }






        public bool ImportarDatosMaxFacturacion(string fileName, string path)
        {



            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.IID = parametroBE.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            if (sucursalBE == null)
            {
                return false;
            }
            

            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;

            if (!File.Exists(path + "\\" + fileName))
            {
                return true;
            }


            string CmdTxt = "SELECT * FROM " + fileName + "  where SUCURSAL = '" + sucursalBE.ICLAVE + "'";



            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CMAXFACTD maxFactD = new CMAXFACTD();
            CMAXFACTBE retorno = new CMAXFACTBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CMAXFACTBE maxFactBuffer = new CMAXFACTBE();



            bool bResult;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if(!maxFactD.DesactivarTodosMAXFACTD(fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    this.iComentario = maxFactD.IComentario;
                    return false;
                }

                while (dr.Read())
                {
                    retorno = new CMAXFACTBE();



                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = ((string)(dr["SUCURSAL"])).Trim();
                    }



                    if ((bool)retorno.isnull["ISUCURSALCLAVE"] || retorno.ISUCURSALCLAVE.Trim() == "")
                        continue;


                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = int.Parse(dr["ANIO"].ToString());
                    }

                    if (dr["MES"] != System.DBNull.Value)
                    {
                        retorno.IMES = int.Parse(dr["MES"].ToString());
                    }

                    retorno.IACTIVO = "S";



                    if (dr["LUN_HAY"] != System.DBNull.Value)
                    {
                        retorno.ILUN_HAY = (string)((dr["LUN_HAY"]));
                    }
                    if (dr["LUN_MAX"] != System.DBNull.Value)
                    {
                        retorno.ILUN_MAX = (decimal)((dr["LUN_MAX"]));
                    }
                    
                    if (dr["MAR_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMAR_HAY = (string)((dr["MAR_HAY"]));
                    }
                    if (dr["MAR_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMAR_MAX = (decimal)((dr["MAR_MAX"]));
                    }

                    if (dr["MIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IMIE_HAY = (string)((dr["MIE_HAY"]));
                    }
                    if (dr["MIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IMIE_MAX = (decimal)((dr["MIE_MAX"]));
                    }

                    if (dr["JUE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IJUE_HAY = (string)((dr["JUE_HAY"]));
                    }
                    if (dr["JUE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IJUE_MAX = (decimal)((dr["JUE_MAX"]));
                    }

                    if (dr["VIE_HAY"] != System.DBNull.Value)
                    {
                        retorno.IVIE_HAY = (string)((dr["VIE_HAY"]));
                    }
                    if (dr["VIE_MAX"] != System.DBNull.Value)
                    {
                        retorno.IVIE_MAX = (decimal)((dr["VIE_MAX"]));
                    }

                    if (dr["SAB_HAY"] != System.DBNull.Value)
                    {
                        retorno.ISAB_HAY = (string)((dr["SAB_HAY"]));
                    }
                    if (dr["SAB_MAX"] != System.DBNull.Value)
                    {
                        retorno.ISAB_MAX = (decimal)((dr["SAB_MAX"]));
                    }

                    if (dr["DOM_HAY"] != System.DBNull.Value)
                    {
                        retorno.IDOM_HAY = (string)((dr["DOM_HAY"]));
                    }
                    if (dr["DOM_MAX"] != System.DBNull.Value)
                    {
                        retorno.IDOM_MAX = (decimal)((dr["DOM_MAX"]));
                    }



                    bResult = maxFactD.AgregarOModificarMAXFACTD(retorno, fTrans);
                    if (bResult == false)
                    {
                        this.IComentario = maxFactD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }





                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public bool ImportarCatalogo(CIMP_FILESBE fileItem, ref ArrayList strErrores, CPARAMETROBE parametro, CPERSONABE usuario)
        {
            string strUnZippedFolder = GetLocalLocation(CIMP_FILESD.FileType_Producto) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileItem.IIF_FILE);
            bool retorno = true;

            try
            {
                if (!ImportarDatosBancos(ImportarDBF.BANK_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los bancos " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los bancos " + ex.Message);
            }


            try
            {
                if (!ImportarDatosTipos(ImportarDBF.TIPO_DBF_FILENAME, strUnZippedFolder))
                {
                    //retorno = false;
                    strErrores.Add("Error al importar los tipos de cliente" + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                //retorno = false;
                strErrores.Add("Error al importar los tipos de cliente " + ex.Message);
            }


            try
            {
                if (!ImportarControlPrecios(ImportarDBF.CTRL_DBF_FILENAME, strUnZippedFolder, usuario))
                {
                    //retorno = false;
                    strErrores.Add("Error al importar los datos de control de precios " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                //retorno = false;
                strErrores.Add("Error al importar control de precios " + ex.Message);
            }



            try
            {

                if (!ImportarDatosListaPrecio(PRODSUCURSAL_DBF_FILENAME, strUnZippedFolder))
                {
                    strErrores.Add("Error al importar Producto Sucursal" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
            }


            if (!ImportarDatosSucursal(SUCURSAL_DBF_FILENAME, strUnZippedFolder))
            {
                retorno = false;
                strErrores.Add("Error al importar sucursales " + this.iComentario);
            }
            /*

          if (!ImportarDatosPromocion(PROMOCION_DBF_FILENAME, strUnZippedFolder))
          {
              return false;
          }
          */
            try
            {

                if (!ImportarDatosTerminal(TERM_DBF_FILENAME, strUnZippedFolder, false))
                {
                    //retorno = false;
                    strErrores.Add("Error al importar terminales" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
                //retorno = false;
                //strErrores.Add("Error al importar terminales " + ex.Message);
            }



            try
            {

                if (!ImportarDatosMerchant(MERCH_DBF_FILENAME, strUnZippedFolder, false))
                {
                    //retorno = false;
                    strErrores.Add("Error al importar terminales" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
            }


            try
            {

                if (!ImportarDatosClerk(CLERK_DBF_FILENAME, strUnZippedFolder, false))
                {
                    //retorno = false;
                    strErrores.Add("Error al importar terminales" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
            }


            try
            {
                if (!ImportarDatosEstado(ImportarDBF.EDOS_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los estados " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los estados " + ex.Message);
            }



            try
            {
                if (!ImportarDatosUnidad(ImportarDBF.UNIDAD_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar las unidades " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar las unidades " + ex.Message);
            }


            try
            {
                if (!ImportarDatosContenido(ImportarDBF.CONTENIDO_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los contenidos de producto " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los contenidos de producto " + ex.Message);
            }



            try
            {
                if (!ImportarDatosClasifica(ImportarDBF.CLASIFICA_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar las clasificaciones adicionales de producto " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar las clasificaciones adicionales de producto " + ex.Message);
            }


            try
            {
                if (!ImportarDatosMotivosDevolucion(ImportarDBF.MOTIVOSDEVOLUCION_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los motivos devolucion " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los motivos devolucion " + ex.Message);
            }



            if (!ImportarDatosMarca(MARCA_DBF_FILENAME, strUnZippedFolder, false))
            {
                retorno = false;
                strErrores.Add("Error al importar marcas " + this.iComentario);
            }


            if (!ImportarDatosLinea(LINEA_DBF_FILENAME, strUnZippedFolder, false))
            {
                retorno = false;
                strErrores.Add("Error al importar lineas " + this.iComentario);
            }

            try
            {
                if (!ImportarDatosArea(ImportarDBF.AREA_DBF_FILENAME, strUnZippedFolder, false))
                {
                    retorno = false;
                    strErrores.Add("Error al importar area " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar area " + ex.Message);
            }

            try
            {
                if (!ImportarDatosAreaDerecho(ImportarDBF.ARDR_DBF_FILENAME, strUnZippedFolder, false))
                {
                    retorno = false;
                    strErrores.Add("Error al importar area derecho " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar area derecho" + ex.Message);
            }


            try
            {
                if (!ImportarDatosTasaIva(ImportarDBF.TASAIVA_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar tasaiva " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar tasaiva " + ex.Message);
            }


            try
            {
                if (!ImportarDatosGrupoSucursal(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar grupo de sucursales " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar grupo de sucursales " + ex.Message);
            }

            try
            {
                if (!ImportarDatosCaracteristicasProducto(ImportarDBF.DEFCARACTPROD_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar caracteristicas de producto " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar caracteristicas de producto " + ex.Message);
            }


            try
            {

                if (!ImportarDatosProveedor(PROVEEDOR_DBF_FILENAME, strUnZippedFolder, false))
                {
                    retorno = false;
                    strErrores.Add("Error al importar proveedores" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar proveedores " + ex.Message);
            }


            try
            {
                if (!ImportarPlazos(ImportarDBF.PLAZO_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los plazos " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los plazos " + ex.Message);
            }


            if (!ImportarDatosProd(PRODUCT_DBF_FILENAME, strUnZippedFolder, false))
            {
                strErrores.Add("Error al importar datos de producto" + this.iComentario);
                return false;
            }

            if (!ImportarDatosProd_Precios(PRODUCTPRECIOS_DBF_FILENAME, strUnZippedFolder, false, parametro.ISUCURSALNUMERO))
            {
                strErrores.Add("Error al importar datos de producto 2da pasada " + this.iComentario);
                return false;
            }
            if (!ImportarDatosProd_Precios(PRODUCTPRECIOS_DBF_FILENAME_M, strUnZippedFolder, false, parametro.ISUCURSALNUMERO))
            {
                strErrores.Add("Error al importar datos de producto 2da pasada " + this.iComentario);
                return false;
            }



            try
            {
                if (!ImportarProductosPromocion(ImportarDBF.TRCL_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    //strErrores.Add("Error al importar los productos de promocion" + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                //retorno = false;
                //strErrores.Add("Error al importar los productos de promocion " + ex.Message);
            }



            try
            {

                if (!ImportarDatosPrm(PRM_DBF_FILENAME, strUnZippedFolder, parametro.ISUCURSALNUMERO))
                {
                    retorno = false;
                    strErrores.Add("Error al importar promociones" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar promociones " + ex.Message);
            }




            



            if (parametro.IMANEJAKITS != null && parametro.IMANEJAKITS.Equals("S"))
            {
                if (!this.ImportarDatoskits(KITS_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar kits " + this.iComentario);
                }
            }


            try
            {
                if (!this.ImportarDatosProd_Precios_PorLista(ImportarDBF.LISTAPRECIODETALLE_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los productos precios por lista " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los productos precios por lista " + ex.Message);
            }


            try
            {
                if (!this.ImportarDatosMaxFacturacion(ImportarDBF.MAXFACT_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar el maximo facturacion " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar el maximo facturacion " + ex.Message);
            }

            





            if (retorno)
            {
                CIMP_FILESD impFileD = new CIMP_FILESD();
                fileItem.IIF_STATUS = CIMP_FILESD.Status_Completo;
                if (!impFileD.CambiarESTATUSIMP_FILESD_X_TIPOYNOMBRE(fileItem, null))
                {
                    strErrores.Add("Error al cambiar la lista de archivos importados" + impFileD.IComentario);
                    return false;
                }
            }



            try
            {

                if (!ImportarDatosProdSuc(PRODSUCURSAL_DBF_FILENAME, strUnZippedFolder))
                {
                    strErrores.Add("Error al importar Producto Sucursal" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
            }


            try
            {
                if (!ImportarDatosGastos(ImportarDBF.GASTO_DBF_FILENAME, strUnZippedFolder))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los bancos " + this.iComentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los bancos " + ex.Message);
            }




            try
            {

                if (!ImportarDatosEncargadoCorte(ENCARGADOCORTE_DBF_FILENAME, strUnZippedFolder, false))
                {
                    retorno = false;
                    strErrores.Add("Error al importar encargados" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar encargados " + ex.Message);
            }


            return retorno;
        }





        public bool ImportarPreciosTemp(CIMP_FILESBE fileItem, ref ArrayList strErrores, CPARAMETROBE parametro)
        {
            string strUnZippedFolder = GetLocalLocation(CIMP_FILESD.FileType_PreciosTemp) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileItem.IIF_FILE);
            bool retorno = true;


            if (!ImportarDatosProd_PrecTemp(PRECTEMP_DBF_FILENAME, strUnZippedFolder))
            {
                strErrores.Add("Error al importar precios temporales " + this.iComentario);
                return false;
            }

            CIMP_FILESD impFileD = new CIMP_FILESD();
            fileItem.IIF_STATUS = CIMP_FILESD.Status_Completo;
            if (!impFileD.CambiarIMP_FILES(fileItem, fileItem, null))
            {
                strErrores.Add("Error al cambiar la lista de archivos importados" + impFileD.IComentario);
                return false;
            }

            return retorno;
        }





        public bool ImportarCatalogoParcial(CIMP_FILESBE fileItem, ref ArrayList strErrores, CPARAMETROBE parametro)
        {
            string strUnZippedFolder = GetLocalLocation(fileItem.IIF_TIPO) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileItem.IIF_FILE);
            bool retorno = true;


            if (!ImportarDatosMarca(MARCA_DBF_FILENAME, strUnZippedFolder, true))
            {
                retorno = false;
                strErrores.Add("Error al importar marcas " + this.iComentario);
            }


            if (!ImportarDatosLinea(LINEA_DBF_FILENAME, strUnZippedFolder, true))
            {
                retorno = false;
                strErrores.Add("Error al importar lineas " + this.iComentario);
            }


            try
            {

                if (!ImportarDatosProveedor(PROVEEDOR_DBF_FILENAME, strUnZippedFolder, true))
                {
                    retorno = false;
                    strErrores.Add("Error al importar proveedores" + this.iComentario);
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar proveedores " + ex.Message);
            }


            if (!ImportarDatosProd(PRODUCT_DBF_FILENAME, strUnZippedFolder, true))
            {
                strErrores.Add("Error al importar datos de producto" + this.iComentario);
                return false;
            }


            if (!ImportarDatosProd_Precios(PRODUCTPRECIOS_DBF_FILENAME, strUnZippedFolder, false, parametro.ISUCURSALNUMERO))
            {
                strErrores.Add("Error al importar datos de producto 2da pasada " + this.iComentario);
                return false;
            }

            if (!ImportarDatosProd_Precios(PRODUCTPRECIOS_DBF_FILENAME_M, strUnZippedFolder, false, parametro.ISUCURSALNUMERO))
            {
                strErrores.Add("Error al importar datos de producto 2da pasada " + this.iComentario);
                return false;
            }



            CIMP_FILESD impFileD = new CIMP_FILESD();
            fileItem.IIF_STATUS = CIMP_FILESD.Status_Completo;
            if (!impFileD.CambiarIMP_FILES(fileItem, fileItem, null))
            {
                strErrores.Add("Error al cambiar la lista de archivos importados" + impFileD.IComentario);
                return false;
            }

            //if (System.IO.Directory.Exists(strUnZippedFolder))
            //    System.IO.Directory.Delete(strUnZippedFolder, true);

            return retorno;
        }



        public bool ImportarCompras(CIMP_FILESBE fileItem, CPARAMETROBE parametros, CPERSONABE usuario, short fileType)
        {
            string strCarpetaDeArchivosDeCompras = GetLocalLocation(fileType);
            try
            {
                if (!ImportarDatos(fileItem, strCarpetaDeArchivosDeCompras, parametros, usuario, fileType))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
                return false;
            }

            CIMP_FILESD impFileD = new CIMP_FILESD();
            fileItem.IIF_STATUS = CIMP_FILESD.Status_Ingresado;
            if (!impFileD.CambiarIMP_FILES(fileItem, fileItem, null))
                return false;

            return true;
        }


        public bool ChecarPedidoMatrizAImportar(CIMP_FILESBE fileItem, CPARAMETROBE parametros)
        {
            

            string strCarpetaDeArchivosDeCompras = GetLocalLocationMatriz(fileItem.IIF_TIPO, fileItem.IIF_SUCURSALCLAVE.Trim(), parametros);
            string strFileCompras = strCarpetaDeArchivosDeCompras + fileItem.IIF_FILE;
            bool bArchivoCorrecto = true;
            if (!System.IO.File.Exists(strFileCompras))
            {
                bArchivoCorrecto = false;
            }
            else
            {
                FileInfo fileInf = new FileInfo(strFileCompras);
                if (fileInf.Length == 0)
                {
                    bArchivoCorrecto = false;
                }
            }




            return bArchivoCorrecto;
        }


        public bool ImportarPedidosMatriz(CIMP_FILESBE fileItem, CPARAMETROBE parametros, CPERSONABE usuario)
        {
            string strCarpetaDeArchivosDeCompras = GetLocalLocationMatriz(fileItem.IIF_TIPO, fileItem.IIF_SUCURSALCLAVE.Trim(), parametros);
            string strFileCompras = strCarpetaDeArchivosDeCompras + fileItem.IIF_FILE;
            if (!System.IO.File.Exists(strFileCompras))
            {
                this.iComentario = " archivo no existe : " + fileItem.IIF_REMOTE_FILE;
                return false;
            }

            this.iComentario = "";
            //ignora los que son de vendedor movil que empiezan con M_ y los que no sean dbf
            if (fileItem.IIF_FILE != null && !fileItem.IIF_FILE.ToUpper().StartsWith("M_") && fileItem.IIF_FILE.ToUpper().Contains(".DBF"))
            {
                if (!ImportarDatosPedidoMatriz(fileItem, strCarpetaDeArchivosDeCompras, parametros, usuario))
                {
                    this.iComentario += " error importando archivo " + fileItem.IIF_REMOTE_FILE;
                    return false;
                }
            }

            CIMP_FILESD impFileD = new CIMP_FILESD();
            fileItem.IIF_STATUS = CIMP_FILESD.Status_Ingresado;
            if (!impFileD.CambiarIMP_FILES(fileItem, fileItem, null))
                return false;

            return true;
        }


        public bool DeleteCompras(CIMP_FILESBE fileItem, CPARAMETROBE parametros, CPERSONABE usuario, short fileType)
        {
            if (!EliminarImportados(fileItem, parametros, usuario, fileType))
            {
                return false;
            }

            CIMP_FILESD impFileD = new CIMP_FILESD();
            fileItem.IIF_STATUS = CIMP_FILESD.Status_Ingresado;
            if (!impFileD.CambiarIMP_FILES(fileItem, fileItem, null))
                return false;

            return true;
        }


        public bool ImportarExistencias(CIMP_FILESBE fileItem, CPARAMETROBE parametros, CPERSONABE usuario, long lGrupoSucursal)
        {
            string strCarpetaDeArchivosDeExistencias = GetLocalLocation(CIMP_FILESD.FileType_ExistenciasGen);
            string strSucursalClave = GetSucursalClave_DelArchivo(fileItem.IIF_FILE, lGrupoSucursal);
            if (strSucursalClave == "")
            {
                //this.IComentario = "La sucursal origen del archivo " + strCarpetaDeArchivosDeExistencias + " no parece valida";
                return true;
            }

            if (!ImportarExistenciasBD(fileItem, strCarpetaDeArchivosDeExistencias, parametros, usuario, strSucursalClave))
            {
                return false;
            }


            return true;
        }



        public bool ImportarArchivosCatalogos(short TIPO, CPARAMETROBE parametros, CPERSONABE usuario, ref ArrayList strErrores)
        {
            CIMP_FILESD imp_filesd = new CIMP_FILESD();
            ArrayList ArchivosAImportar = imp_filesd.ObtenerArchivosListosAImportar(null);

            foreach (CIMP_FILESBE itemFile in ArchivosAImportar)
            {
                if (itemFile.IIF_TIPO == TIPO)
                {
                    if (!ImportarCatalogo(itemFile, ref strErrores, parametros, usuario))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        public bool ImportarArchivosPreciosTemp(short TIPO, CPARAMETROBE parametros, CPERSONABE usuario, ref ArrayList strErrores)
        {
            CIMP_FILESD imp_filesd = new CIMP_FILESD();
            ArrayList ArchivosAImportar = imp_filesd.ObtenerArchivosListosAImportar(null);

            foreach (CIMP_FILESBE itemFile in ArchivosAImportar)
            {
                if (itemFile.IIF_TIPO == TIPO)
                {
                    if (!ImportarPreciosTemp(itemFile, ref strErrores, parametros))
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        public bool ImportarArchivosComprasTraslados(short TIPO, CPARAMETROBE parametros, CPERSONABE usuario, ref ArrayList strErrores)
        {
            CIMP_FILESD imp_filesd = new CIMP_FILESD();
            ArrayList ArchivosAImportar = imp_filesd.ObtenerArchivosListosAImportar(null);
            bool retorno = true;
            foreach (CIMP_FILESBE itemFile in ArchivosAImportar)
            {
                this.IComentario = ""; ;
                if (itemFile.IIF_TIPO == TIPO)
                {
                    if (itemFile.IIF_FILE.StartsWith("E"))
                    {
                        if (!DeleteCompras(itemFile, parametros, usuario, TIPO))
                        {
                            strErrores.Add("Sucedio un error con : " + itemFile.IIF_FILE + " " + this.IComentario);
                            retorno = false;
                        }
                        continue;
                    }

                    CIMP_FILESBE impfileAux = imp_filesd.seleccionar_auxiliarIMP_FILES(itemFile, null);
                    if (impfileAux != null)
                    {
                        ImportarCatalogoParcial(impfileAux, ref strErrores, parametros);
                    }

                    if (!ImportarCompras(itemFile, parametros, usuario, TIPO))
                    {
                        strErrores.Add("Sucedio un error con : " + itemFile.IIF_FILE + " " + this.IComentario);
                        retorno = false;
                    }
                }
            }
            return retorno;
        }


        public bool ImportarArchivosExistencias(short TIPO, CPARAMETROBE parametros, CPERSONABE usuario)
        {
            CIMP_FILESD imp_filesd = new CIMP_FILESD();
            ArrayList ArchivosAImportar = imp_filesd.ObtenerArchivosListosAImportar(null);


            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            CSUCURSALD sucursalD = new CSUCURSALD();

            sucursalBE.IID = parametros.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE == null)
            {
                this.IComentario = "La sucursal actual no esta definida";
                return false;
            }


            CINVENTARIOSUCURSALD invSucursalD = new CINVENTARIOSUCURSALD();
            if (!invSucursalD.BorrarTodosINVENTARIOSUCURSALD(null))
            {
                return false;
            }

            foreach (CIMP_FILESBE itemFile in ArchivosAImportar)
            {
                if (itemFile.IIF_TIPO == TIPO)
                {
                    if (!ImportarExistencias(itemFile, parametros, usuario, sucursalBE.IGRUPOSUCURSALID))
                    {
                        return false;
                    }
                }
            }
            return true;
        }




        public bool Pre_ImportacionInventarioInicial(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PRE_INVENTARIO_INICIAL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool Post_ImportacionInventarioInicial(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"POST_INVENTARIO_INICIAL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool AgregarInventarioInicialProd(string productoClave, decimal cantidad, string lote, DateTime? fechavence, string pedimento, string aduana, DateTime? fechaImpo, decimal? tipoCambioImpo, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ALMACEN_DEFAULT;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOCLAVE", FbDbType.VarChar);
                auxPar.Value = productoClave;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (lote == null || lote.Equals(""))
                    auxPar.Value = DBNull.Value;
                else
                    auxPar.Value = lote;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (fechavence == DateTime.MinValue || fechavence == null)
                {
                    auxPar.Value = DBNull.Value;
                }
                else
                {
                    auxPar.Value = fechavence.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = cantidad;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = 0;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = 0;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PEDIMENTO", FbDbType.VarChar);
                if (pedimento == null || pedimento.Equals(""))
                    auxPar.Value = DBNull.Value;
                else
                    auxPar.Value = pedimento;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                if (aduana == null || aduana.Equals(""))
                    auxPar.Value = DBNull.Value;
                else
                    auxPar.Value = aduana;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAIMPO", FbDbType.Date);
                if (fechaImpo == DateTime.MinValue || fechaImpo == null)
                {
                    auxPar.Value = DBNull.Value;
                }
                else
                {
                    auxPar.Value = fechaImpo.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCAMBIOIMPO", FbDbType.Numeric);
                if (tipoCambioImpo == null)
                {
                    auxPar.Value = DBNull.Value;
                }
                else
                {
                    auxPar.Value = tipoCambioImpo.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"INVENTARIO_INICIAL_AGREGAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        int iErrorCode = (int)arParms[arParms.Length - 1].Value;
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)iErrorCode, this.sCadenaConexion, st);
                        this.iComentario += "ERROR : " + strMensajeErr;
                        if (iErrorCode == 1069)
                            this.iComentario += " " + productoClave;
                        else
                            return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool ImportarInventarioIncial(string fileName, string path)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            string claveProducto;
            decimal cantidad;
            string lote = null;

            string pedimento = null;
            string aduana = null;
            DateTime? fechaImportacion = null;
            decimal? tipoCambio = null;

            DateTime? fechavence = null;

            bool bResult;
            string strCommentario = "";
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                if (!Pre_ImportacionInventarioInicial(fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                while (dr.Read())
                {
                    this.IComentario = "";
                    claveProducto = "";
                    cantidad = 0;
                    lote = null;
                    fechavence = DateTime.MinValue;


                    pedimento = null;
                    aduana = null;
                    fechaImportacion = null;
                    tipoCambio = null;

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        claveProducto = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    if (claveProducto.Trim() == "")
                        continue;


                    try
                    {
                        if (dr["CANTIDAD"] != System.DBNull.Value)
                        {
                            cantidad = (decimal)(dr["CANTIDAD"]);
                        }
                    }
                    catch
                    {

                        if (dr["EXIS"] != System.DBNull.Value)
                        {
                            cantidad = (decimal)(dr["EXIS"]);
                        }
                    }


                    try
                    {

                        if (dr["LOTE"] != System.DBNull.Value)
                        {
                            lote = ((string)(dr["LOTE"])).Trim();
                        }

                    }
                    catch
                    {
                    }


                    try
                    {

                        if (dr["CADUCIDAD"] != System.DBNull.Value)
                        {
                            fechavence = (DateTime)dr["CADUCIDAD"];
                        }

                    }
                    catch
                    {
                    }



                    try
                    {

                        if (dr["PEDIMENTO"] != System.DBNull.Value)
                        {
                            pedimento = ((string)(dr["PEDIMENTO"])).Trim();
                        }

                    }
                    catch
                    {
                    }


                    try
                    {

                        if (dr["ADUANA"] != System.DBNull.Value)
                        {
                            aduana = ((string)(dr["ADUANA"])).Trim();
                        }

                    }
                    catch
                    {
                    }


                    try
                    {

                        if (dr["FECHA"] != System.DBNull.Value)
                        {
                            fechaImportacion = (DateTime)dr["FECHA"];
                        }

                    }
                    catch
                    {
                    }



                    try
                    {
                        if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                        {
                            tipoCambio = (decimal)(dr["TIPOCAMBIO"]);
                        }
                    }
                    catch
                    {
                    }



                    bResult = AgregarInventarioInicialProd(claveProducto, cantidad, lote, fechavence, pedimento, aduana, fechaImportacion, tipoCambio, fTrans);
                    if (this.IComentario.Trim() != "")
                        strCommentario += this.IComentario + "\n";
                    if (bResult == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }



                }

                if (!Post_ImportacionInventarioInicial(fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }
                this.IComentario = strCommentario;
                fTrans.Commit();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public bool ChecarArchivosAImportarPedidosDeSucursales(CPARAMETROBE parametros, ref ArrayList archivosARecargar)
        {
            CIMP_FILESD imp_filesd = new CIMP_FILESD();
            ArrayList ArchivosAImportar = imp_filesd.ObtenerPedidosDeSucursalesListosAImportar(null);
            archivosARecargar = new ArrayList();

            bool retorno = true;
            foreach (CIMP_FILESBE itemFile in ArchivosAImportar)
            {
                this.IComentario = ""; ;


                //if (itemFile.IIF_FILE.StartsWith("veds"))
                //{ 
                if (!ChecarPedidoMatrizAImportar(itemFile, parametros))
                {
                    archivosARecargar.Add(itemFile);
                    //strErrores.Add("Sucedio un error con : " + itemFile.IIF_FILE + " de sucursal " + itemFile.IIF_SUCURSALCLAVE.Trim() + " " + this.IComentario);
                    retorno = false;
                }
                //}

            }
            return retorno;
        }


        public bool ImportarPedidosDeSucursales(CPARAMETROBE parametros, CPERSONABE usuario, ref ArrayList strErrores)
        {
            CIMP_FILESD imp_filesd = new CIMP_FILESD();
            ArrayList ArchivosAImportar = imp_filesd.ObtenerPedidosDeSucursalesListosAImportar(null);
            bool retorno = true;
            foreach (CIMP_FILESBE itemFile in ArchivosAImportar)
            {
                this.IComentario = ""; ;

                if (!ChecarPedidoMatrizAImportar(itemFile, parametros))
                {
                    continue;
                }
                //if (itemFile.IIF_FILE.StartsWith("veds"))
                //{ 
                if (!ImportarPedidosMatriz(itemFile, parametros, usuario))
                {
                    strErrores.Add("Sucedio un error con : " + itemFile.IIF_FILE + " de sucursal " + itemFile.IIF_SUCURSALCLAVE.Trim() + " " + this.IComentario);
                    //retorno = false;
                }
                //}

            }
            return retorno;
        }

        public bool ImportarHeaderVentasGiralda(string fileName, string path, string fileNameDetalle, string pathDetalle, CPARAMETROBE parametros, CPERSONABE usuario, ref bool bHuboClientesNoEncontrados)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName + " where ESTATUS <> 'C' and TOTAL > 0 ";

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            //CPLAZOD itemD = new CPLAZOD();
            CIMPORTAR_DBF_LINE_SP_VENTABE retorno = new CIMPORTAR_DBF_LINE_SP_VENTABE();
            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fTrans = null;

            CPLAZOBE itemBuffer = new CPLAZOBE();

            CDOCTOD doctoD = new CDOCTOD();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;


            int iTestLimit = 20;
            int iCountLimit = 0;

            


            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {


                    long doctoID = 0;
                    retorno = new CIMPORTAR_DBF_LINE_SP_VENTABE();


                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA = (string)(dr["VENTA"]);
                    }
                    

                    if (dr["F_FACTURA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = ((DateTime)(dr["F_FACTURA"]));
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["FEUUID"] != System.DBNull.Value)
                    {
                        retorno.IFEUUID = (string)(dr["FEUUID"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["PLAZO"] != System.DBNull.Value)
                    {
                        retorno.IPLAZO = ((string)(dr["PLAZO"])).Trim();
                    }

                    if (dr["TRASLA"] != System.DBNull.Value)
                    {
                        bool bTrasla = (bool)(dr["TRASLA"]);
                        retorno.ITRASLA = bTrasla ? "S" : "N";
                    }

                    retorno.ITARJETA = "N";
                    try
                    {

                        if (dr["TARJETA"] != System.DBNull.Value)
                        {

                            retorno.ITARJETA = (string)(dr["TARJETA"]);
                            decimal montoTarjeta = 0;

                            if (dr["PTARJETA"] != System.DBNull.Value)
                            {
                                montoTarjeta = (decimal)(dr["PTARJETA"]);
                            }

                            if (retorno.ITARJETA.Equals("S") || (retorno.ITARJETA.Equals("M")))
                            {
                                if (montoTarjeta > 0)
                                {
                                    retorno.IPTARJETA = montoTarjeta;
                                }
                                else
                                {
                                    if (dr["TOTAL"] != System.DBNull.Value)
                                    {
                                        retorno.IPTARJETA = (decimal)(dr["TOTAL"]);
                                    }
                                }
                            }



                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                        retorno.ISALDO = 0;
                        if (dr["SALDO"] != System.DBNull.Value)
                        {
                            retorno.ISALDO = (decimal)(dr["SALDO"]);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        retorno.ITOTAL = 0;
                        if (dr["TOTAL"] != System.DBNull.Value)
                        {
                            retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                        }
                    }
                    catch
                    {

                    }

                    retorno.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;

                    bResult = this.ImportarDetalleVentaGiralda_2(fileNameDetalle, pathDetalle, retorno, parametros, usuario, ref doctoID, /*fTrans*/null);

                    if (bResult == false)
                    {
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    if (doctoID == 0)
                        continue;

                    CPERSONAD daoPersona = new CPERSONAD();
                    CPERSONABE personaAux = new CPERSONABE();


                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = doctoID;

                    if (retorno.IESTATUS.ToUpper().Equals("F") || retorno.IESTATUS.ToUpper().Equals("M"))
                    {
                        doctoBE.IESFACTURAELECTRONICA = "S";

                        if (retorno.IFEUUID != null && retorno.IFEUUID.Trim().Length > 0)
                            doctoBE.ITIMBRADOUUID = retorno.IFEUUID;
                    }
                    else
                    {
                        doctoBE.IESFACTURAELECTRONICA = "N";
                    }


                    personaAux.ITIPOPERSONAID = 50;
                    /*if (retorno.ICLIENTE.Equals("000000"))
                    {
                        personaAux.ICLAVE = "mostrador";
                        personaAux = daoPersona.seleccionarPERSONAxCLAVE(personaAux, null);
                        if (personaAux == null)
                        {
                            this.IComentario = "no se encontro a la persona con clave " ;
                            //fTrans.Rollback();
                            //fConn.Close();
                            return false;
                        }
                        doctoBE.IPERSONAID = personaAux.IID;
                    }
                    else
                    {*/
                        
                        personaAux.ICLAVE = retorno.ICLIENTE;//"OB000001";
                        personaAux = daoPersona.seleccionarPERSONAxCLAVE(personaAux, /*fTrans*/null);
                        if (personaAux == null)
                        {
                            bHuboClientesNoEncontrados = true;

                            personaAux = new CPERSONABE();
                            personaAux.ICLAVE = "mostrador"; //"OB000001";
                            personaAux.ITIPOPERSONAID = 50;
                            personaAux = daoPersona.seleccionarPERSONAxCLAVE(personaAux, /*fTrans*/null);
                            if (personaAux == null)
                            {
                                this.IComentario = "no se encontro a la persona con clave ";
                                //fTrans.Rollback();
                                //fConn.Close();
                                return false;
                            }
                        }
                        doctoBE.IPERSONAID = personaAux.IID;
                    //}


                    if (!doctoD.ACTUALIZARPERSONAID(doctoBE, /*fTrans*/null))
                    {
                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    if (!doctoD.ACTUALIZARESFACTURAELECTRONICAANDUUID(doctoBE, /*fTrans*/null))
                    {
                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    if (retorno.ITRASLA != null && retorno.ITRASLA.Equals("S"))
                    {
                        doctoBE.ISUBTIPODOCTOID = DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA;

                        if (!doctoD.CambiarSubtipoDoctoD(doctoBE, /*fTrans*/null))
                        {
                            this.IComentario = doctoD.IComentario;
                            //fTrans.Rollback();
                            //fConn.Close();
                            return false;
                        }


                        doctoBE.ISUCURSALTID = ObtenerSucursalIdPorClienteClave(retorno.ICLIENTE, null);
                        if (!doctoD.CambiarSucdestinoD(doctoBE, /*fTrans*/null))
                        {
                            this.IComentario = doctoD.IComentario;
                            //fTrans.Rollback();
                            //fConn.Close();
                            return false;
                        }




                    }

                    
                    if (!doctoD.IMPORTAR_DBFLINE_PAGO(doctoBE.IID, retorno.IPTARJETA, retorno.ISALDO,/*fTrans*/null))
                    {
                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    if (!doctoD.CerrarDOCTOD(doctoBE, /*fTrans*/null))
                    {

                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                    //doctoBE.ISUBTIPODOCTOID = 0;
                    //if (!doctoD.CambiarSubTipoDOCTOD(doctoBE, /*fTrans*/null))
                    //{

                    //    this.IComentario = doctoD.IComentario;
                    //    //fTrans.Rollback();
                    //    //fConn.Close();
                    //    return false;
                    //}

                    

                }
                //fTrans.Commit();
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;

        }


        private long ObtenerSucursalIdPorClienteClave(string clienteClave, FbTransaction st)
        {
            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucBE = new CSUCURSALBE();
            sucBE.ICLIENTECLAVE = clienteClave;
            sucBE = sucD.seleccionarSUCURSALPorClaveCliente(sucBE, st);
            return sucBE != null ? sucBE.IID : 0;

        }

        public bool ImportarHeaderDevolucionesGiralda(string fileName, string path, string fileNameDetalle, string pathDetalle, CPARAMETROBE parametros, CPERSONABE usuario, ref bool bHuboClientesNoEncontrados)
        {
            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName + " ";

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            //CPLAZOD itemD = new CPLAZOD();
            CIMPORTAR_DBF_LINE_SP_VENTABE retorno = new CIMPORTAR_DBF_LINE_SP_VENTABE();
            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fTrans = null;

            CPLAZOBE itemBuffer = new CPLAZOBE();

            CDOCTOD doctoD = new CDOCTOD();



            int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;


            int iTestLimit = 20;
            int iCountLimit = 0;


            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    

                    long doctoID = 0;
                    retorno = new CIMPORTAR_DBF_LINE_SP_VENTABE();

                    if (dr["DEVOLUCION"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA = dr["DEVOLUCION"].ToString();
                        retorno.IDEVOLUCION = dr["DEVOLUCION"].ToString();
                    }


                    if (dr["FEUUID"] != System.DBNull.Value)
                    {
                        retorno.IFEUUID = (string)(dr["FEUUID"]);
                    }


                    if (retorno.IREFERENCIA.Length <= 6)
                    {
                        retorno.IREFERENCIA = "D" + retorno.IREFERENCIA.PadLeft(5);
                    }
                    

                    if (dr["FECHA_2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = ((DateTime)(dr["FECHA_2"]));
                    }
                    
                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }


                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOREFIMP = (string)(dr["VENTA"]);
                    }
                    try
                    {
                        retorno.ISALDO = 0;
                        if (dr["SALDO"] != System.DBNull.Value)
                        {
                            retorno.ISALDO = (decimal)(dr["SALDO"]);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        retorno.ITOTAL = 0;
                        if (dr["TOTAL"] != System.DBNull.Value)
                        {
                            retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                        }
                    }
                    catch
                    {

                    }


                    retorno.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                    

                    bResult = this.ImportarDetalleVentaGiralda_2(fileNameDetalle, pathDetalle, retorno, parametros, usuario, ref doctoID, /*fTrans*/null);

                    if (bResult == false)
                    {
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                    if (doctoID <= 0)
                        continue;


                    CPERSONAD daoPersona = new CPERSONAD();
                    CPERSONABE personaAux = new CPERSONABE();


                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = doctoID;

                    if (retorno.IFEUUID != null && retorno.IFEUUID.Trim().Length > 0)
                    {
                        doctoBE.IESFACTURAELECTRONICA = "S";
                        doctoBE.ITIMBRADOUUID = retorno.IFEUUID;
                    }
                    else
                    {
                        doctoBE.IESFACTURAELECTRONICA = "N";
                    }



                    personaAux.ITIPOPERSONAID = 50;
                    /*if (retorno.ICLIENTE.Equals("000000"))
                    {
                        personaAux.ICLAVE = "mostrador";
                        personaAux = daoPersona.seleccionarPERSONAxCLAVE(personaAux, null);
                        if (personaAux == null)
                        {
                            this.IComentario = "no se encontro a la persona con clave ";
                            //fTrans.Rollback();
                            //fConn.Close();
                            return false;
                        }
                        doctoBE.IPERSONAID = personaAux.IID;
                    }
                    else
                    {*/
                        
                        personaAux.ICLAVE = retorno.ICLIENTE;//"OB000001";
                        personaAux = daoPersona.seleccionarPERSONAxCLAVE(personaAux, /*fTrans*/null);
                        if (personaAux == null)
                        {
                            bHuboClientesNoEncontrados = true;

                            personaAux = new CPERSONABE();
                            personaAux.ICLAVE = "000000";//"mostrador"; //"OB000001";
                            personaAux.ITIPOPERSONAID = 50;
                            personaAux = daoPersona.seleccionarPERSONAxCLAVE(personaAux, /*fTrans*/null);
                            if (personaAux == null)
                            {
                                this.IComentario = "no se encontro a la persona con clave ";
                                //fTrans.Rollback();
                                //fConn.Close();
                                return false;
                            }
                        }
                        doctoBE.IPERSONAID = personaAux.IID;


                    //}


                    if (!doctoD.ACTUALIZARPERSONAID(doctoBE, /*fTrans*/null))
                    {
                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                    if (!doctoD.ACTUALIZARESFACTURAELECTRONICAANDUUID(doctoBE, /*fTrans*/null))
                    {
                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                    if (!doctoD.IMPORTAR_DBFLINE_PAGO(doctoBE.IID, 0, retorno.ITOTAL - retorno.ISALDO, /*fTrans*/null))
                    {
                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    if (!doctoD.CerrarDOCTOD(doctoBE, /*fTrans*/null))
                    {

                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                    doctoBE.ISUBTIPODOCTOID = 0;
                    if (!doctoD.CambiarSubTipoDOCTOD(doctoBE, /*fTrans*/null))
                    {

                        this.IComentario = doctoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }


                }
                //fTrans.Commit();
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;

        }




        public bool ImportarDetalleVentaGiralda_2(string nombreArchivo, string path, CIMPORTAR_DBF_LINE_SP_VENTABE ventaBE, CPARAMETROBE parametros, CPERSONABE usuario, ref long doctoID, FbTransaction fTrans)
        {
            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  " + nombreArchivo + " WHERE VENTA = '" + ventaBE.IREFERENCIA + "' ";
            OleDbDataReader dr;
            dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            //int iConsecutivo = 0;

            CIMPORTAR_DBF_LINE_SP_VENTABE importCompras;


            string strVentaAnterior = "";
            string strVentaActual = "";

            long sucursalTid = 0;
            DateTime fechaDBF = new DateTime();

            bool bChecarYaImportado = true;
            string yaImportado = "N";


            try
            {


                while (dr.Read())
                {



                    importCompras = new CIMPORTAR_DBF_LINE_SP_VENTABE();
                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        strVentaActual = ((string)(dr["VENTA"])).Trim();
                        importCompras.IREFERENCIA = strVentaActual;

                        if (strVentaActual != strVentaAnterior && doctoID != 0)
                        {
                            importCompras.IDOCTOACTUALID = doctoID;

                        }

                    }


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        importCompras.IPRODUCTO = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        importCompras.ICANTIDAD = Math.Abs(decimal.Parse(dr["CANTIDAD"].ToString()));
                    }

                    importCompras.ICANTIDADDEFACTURA = 0;
                    importCompras.ICANTIDADDEREMISION = Math.Abs(importCompras.ICANTIDAD);
                    importCompras.ICANTIDADDEINDEFINIDO = 0;




                    importCompras.ISUCURSALID = parametros.ISUCURSALID;


                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        importCompras.ICOSTO = Math.Abs(decimal.Parse(dr["PRECIO"].ToString()));
                    }
                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        importCompras.IIMPORTE = Math.Abs(decimal.Parse(dr["IMPORTE"].ToString()));
                    }



                    if (dr["CARGOS_U"] != System.DBNull.Value)
                    {
                        importCompras.ICARGOS_U = Math.Abs(decimal.Parse(dr["CARGOS_U"].ToString()));
                    }
                    

                    if (dr["IMPORTNETO"] != System.DBNull.Value)
                    {
                        importCompras.IIMPORTENETO = Math.Abs(decimal.Parse(dr["IMPORTNETO"].ToString()));
                    }

                    importCompras.IUSERID = usuario.IID;


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        importCompras.ILINEA = ((string)(dr["LINEA"])).Trim();
                    }



                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        importCompras.IMARCA = ((string)(dr["MARCA"])).Trim();
                    }


                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        importCompras.ICLIENTE = ((string)(dr["CLIENTE"])).Trim();
                    }

                   

                    importCompras.IFECHA = ventaBE.IFECHA;

                    importCompras.IPLAZO = ventaBE.IPLAZO;
                    


                    importCompras.IREFERENCIAS = nombreArchivo;

                    importCompras.ITIPODOCTOID = ventaBE.ITIPODOCTOID; //; ventaBE.IESTATUS == "D" ? DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO : DBValues._DOCTO_TIPO_VENTA;

                    importCompras.IDOCTOREFIMP = ventaBE.IDOCTOREFIMP;

                   

                    //proceder a importar
                    if (IMPORTAR_DBF_LINE_SP_VENTAD(importCompras, fTrans, ref doctoID) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
            }
            return true;

        }











        public bool IMPORTAR_DBF_LINE_SP_VENTAD(CIMPORTAR_DBF_LINE_SP_VENTABE oCIMPORTAR_DBF_LINE_SP, FbTransaction st, ref long lDoctoId)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOACTUALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDOCTOACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IUSERID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IUSERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ILINEA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ILINEA;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARCA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IMARCA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IMARCA;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FALTANTE", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICOSTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOS_U", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTENETO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IIMPORTENETO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IIMPORTENETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ILOTE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IALMACENTID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.IALMACENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFECHA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEFACTURA", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDADDEFACTURA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDADDEFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEREMISION", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDADDEREMISION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDADDEREMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEINDEFINIDO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ICANTIDADDEINDEFINIDO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ICANTIDADDEINDEFINIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOVISIBLETRASLADO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRECIOVISIBLETRASLADO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRECIOVISIBLETRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PEDIMENTO", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPEDIMENTO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPEDIMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAIMPORTACION", FbDbType.Date);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IFECHAIMPORTACION"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IFECHAIMPORTACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IADUANA"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOCAMBIOIMPO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ITIPOCAMBIOIMPO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ITIPOCAMBIOIMPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOIMPORTADOID", FbDbType.BigInt);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOIMPORTADOID"])
                {
                    auxPar.Value = (long)oCIMPORTAR_DBF_LINE_SP.IDOCTOIMPORTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOREFIMP", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDOCTOREFIMP"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDOCTOREFIMP;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZOCHAR", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPLAZO"])
                {
                    auxPar.Value = (string)oCIMPORTAR_DBF_LINE_SP.IPLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_DBFLINE_VENTAS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);

                        if ((long)((int)arParms[arParms.Length - 1].Value) == DBValues._ERRORCODE_PRODUCTO_NOEXISTE)
                        {
                            this.iComentario = "ATENCION: \n" +
"Alguno de los pedidos o traslados que intentas importar contiene un producto que no esta registrado en tu catalogo de PRODUCTOS es necesario que sigas los siguientes pasos \n" +
"\n" +
"1.- Intenta actualizar catálogos antes de importar compras o traslados \n" +
"2.- si no esta disponible la actualización de catálogos solicita a la distribuidora que actualize catalogos y repite el paso 1\n" +
"3.- Reintenta importar traslado o compra\n" +
"\n" +
"Si el error persiste después de repetir estos pasos es necesario que reportes el problema al area de sistema de tu empresa.\n";
                        }
                        else
                        {

                            this.iComentario = "Hubo un error : " + strMensajeErr;
                        }

                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoId = (long)arParms[arParms.Length - 2].Value;
                }

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
