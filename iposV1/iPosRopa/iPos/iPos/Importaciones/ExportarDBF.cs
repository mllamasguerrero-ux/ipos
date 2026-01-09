using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.IO;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using System.Data.OleDb;
using System.ComponentModel;
using iPos.Tools;
using iPos;
using DataLayer.Importaciones.businessEntity;
using DataLayer.Importaciones.businessData;
using DataLayer.Movil.businessData.MOVILANDROID;
using DataLayer.Movil.ExpoSqlite;

namespace DataLayer.Importaciones
{
    public class ExportarDBF : IDisposable
    {
        private string sCadenaConexion;
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

        public const string FileLocalLocation_Pedidos = "\\sampdata\\in\\";
        public const string FileLocalLocation_Pedidos_Molde = "\\sampdata\\in\\Molde";

        public const string FileLocalLocation_SolicitudMercancia = "\\sampdata\\solicitudMercancia\\";



        public const string FileLocalLocation_Pedidos_Crescendo = "\\sampdata\\dbfpedid";


        public const string FileLocalLocation_Ventas = "\\sampdata\\bases\\";
        public const string FileLocalLocation_Ventas_Molde = "\\sampdata\\bases\\Molde";


        public const string FileLocalLocation_TrasladosEnvios = "\\sampdata\\trasEnv\\";
        public const string FileLocalLocation_TrasladosEnvios_Molde = "\\sampdata\\trasEnv\\Molde";
        public const string FileLocalLocation_TrasladosEnviosAux = "\\sampdata\\trasEnv_aux\\";


        public const string FileLocalLocation_TrasladosDevoEnvios = "\\sampdata\\trasDevoEnv\\";
        public const string FileLocalLocation_TrasladosDevoEnvios_Molde = "\\sampdata\\trasDevoEnv\\Molde";


        public const string FileLocalLocation_PedidosDevoEnvios = "\\sampdata\\pedidosDevo\\";
        public const string FileLocalLocation_PedidosDevoEnvios_Molde = "\\sampdata\\pedidosDevo\\Molde";


        public const string FileLocalLocation_ExistenciasLocales = "\\sampdata\\existenciasLocales\\";
        public const string FileLocalLocation_ExistenciasLocales_Molde = "\\sampdata\\existenciasLocales\\Molde";



        public const string FileLocalLocation_RecepcionCompras = "\\sampdata\\RecepcionCompras\\";
        public const string FileLocalLocation_RecepcionCompras_Molde = "\\sampdata\\RecepcionCompras\\Molde";


        public const string FileLocalLocation_Inventarios = "\\sampdata\\excel\\";

        public const string FileLocalLocation_MatrizEnviosSucursales = "\\sampdata\\matriz\\enviossucursales\\";
        public const string FileLocalLocation_MatrizEnviosSucursales_Molde = "\\sampdata\\matriz\\enviossucursales\\molde";
        public const string FileLocalLocation_MatrizEnviosSucursalesAux = "\\sampdata\\matriz\\enviossucursales_aux\\";


        public const string FileLocalLocation_MatrizPreciosExport = "\\sampdata\\matriz\\precios\\prec\\";
        public const string FileLocalLocation_MatrizPreciosExport_Molde = "\\sampdata\\matriz\\precios\\molde";
        public const string FileLocalLocation_MatrizPreciosZipTemporal = "\\sampdata\\matriz\\precios\\prec\\PREC.zip";
        public const string FileLocalLocation_MatrizPreciosZipFinal = "\\sampdata\\matriz\\precios\\PREC.ZIP";
        public const string FileLocalLocation_MatrizPreciosZipLocalPath = "\\sampdata\\matriz\\precios\\";
        public const string FileLocalLocation_MatrizPreciosZipFtpPath = "/tiendas";
        public const string FileLocalLocation_MatrizPreciosZipName = "PREC.zip";

        public const string FileLocalLocation_MovilPreciosExport = "\\sampdata\\matriz\\movil\\precios\\prec\\";
        public const string FileLocalLocation_MovilPreciosExport_Molde = "\\sampdata\\matriz\\movil\\precios\\molde";
        public const string FileLocalLocation_MovilPreciosZipTemporal = "\\sampdata\\matriz\\movil\\precios\\prec\\PREC.zip";
        public const string FileLocalLocation_MovilPreciosZipFinal = "\\sampdata\\matriz\\movil\\precios\\PREC.ZIP";
        public const string FileLocalLocation_MovilPreciosZipLocalPath = "\\sampdata\\matriz\\movil\\precios\\";
        public const string FileLocalLocation_MovilPreciosZipFtpPath = "/VendedorMovil";
        public const string FileLocalLocation_MovilPreciosZipName = "PREC.zip";
        public const string FileLocalLocation_MovilPreciosExport_Sqlite = "\\sampdata\\matriz\\movil\\precios\\prec_movil\\";
        public const string FileLocalLocation_MovilPreciosDbName_Sqlite = "PREC.db";



        public const string FileLocalLocation_MatrizPreciosTempExport = "\\sampdata\\matriz\\preciostemp\\prectemp\\";
        public const string FileLocalLocation_MatrizPreciosTemp_Molde = "\\sampdata\\matriz\\preciostemp\\molde";
        public const string FileLocalLocation_MatrizPreciosTempZipTemporal_ = "\\sampdata\\matriz\\preciostemp\\prectemp\\PRECTEMP.ZIP";
        public const string FileLocalLocation_MatrizPreciosTempZipFinal_ = "\\sampdata\\matriz\\preciostemp\\PRECTEMP.ZIP";
        public const string FileLocalLocation_MatrizPreciosTempZipLocalPath = "\\sampdata\\matriz\\preciostemp\\";
        public const string FileLocalLocation_MatrizPreciosTempZipFtpPath = "/tiendas/prectemp";
        public const string FileLocalLocation_MatrizPreciosTempZipName_ = "PRECTEMP.ZIP";





        public const string FileNamePedidosDetalleFTP = "veds";
        public const string FileNamePedidosHeaderFTP = "vens";


        public const string FileNamePedidosDetalleCrescendoFTP = "M_VEDS";
        public const string FileNamePedidosHeaderCrescendoFTP = "M_VENS";


        public const string FileNameVentasDetalleFTP = "vedm";
        public const string FileNameVentasHeaderFTP = "venm";

        public const string FileNameTrasladosEnviosDetalleFTP = "M";
        public const string FileNameTrasladosEnviosHeaderFTP = "D";



        public const string FileNameTrasladosDevoEnviosDetalleFTP = "M";
        public const string FileNameTrasladosDevoEnviosHeaderFTP = "D";


        public const string FileNamePedidosDevoEnviosDetalleFTP = "M";
        public const string FileNamePedidosDevoEnviosHeaderFTP = "D";

        public const string FileNameExistenciasFTP = "E";
        public const string FileNameRecepcionComprasFTP = "R";
        public const string FileNameMatrizEnvioPedidosASucursalFTP = "V";


        public const string FileFTPLocation_Pedidos = "/in";
        public const string FileFTPLocation_Ventas = "/bases";
        public const string FileFTPLocation_Traslados = "/TRASLA";
        public const string FileFTPLocation_TrasladosAux = "/TRASLA_aux";
        public const string FileFTPLocation_Existencias = "/ExistenciasGeneral";
        public const string FileFTPLocation_RecepcionCompras = "/RecepcionCompras";
        public const string FileFTPLocation_Inventarios = "/Inventarios";
        public const string FileFTPLocation_MatrizEnvioPedidos = "/pedidos";
        public const string FileFTPLocation_MatrizEnvioPedidosAux = "/pedidos_aux";
        public const string FileFTPLocation_SolicitudMercancia = "/solicitudMercancia";

        public const string FileFTPLocation_TrasladosDevo = "/TRASLADEVO";


        public const string FileFTPLocation_PedidosDevo = "/PEDIDODEVO";


        public const string FileFTPLocation_FacturaElectronicaPDF = "/FacturaElectronica/PDF";
        public const string FileFTPLocation_FacturaElectronicaXML = "/FacturaElectronica/XML";
        public const string FileFTPLocation_DevolucionElectronicaPDF = "/DevolucionElectronica/PDF";
        public const string FileFTPLocation_DevolucionElectronicaXML = "/DevolucionElectronica/XML";
        public const string FileFTPLocation_ComprobanteTrasladoPDF = "/ComprobanteTraslado/PDF";
        public const string FileFTPLocation_ComprobanteTrasladoXML = "/ComprobanteTraslado/XML";


        public const short FileType_MatrizEnvioPedidosASucursal = 1;
        public const short FileType_MatrizEnvioPedidosASucursalAux = 2;

        



        //public const string FileNamePrefixFTP              = "vedm";

        string m_strDbfCadenaConexion;

        public Boolean CopyEmtpyTablesComprasYDevoluciones(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha/*,long lTurnoId*/, string dbFileNameDetalle, string dbFileNameHeader, string path)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos_Molde;
            //string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;
            //string dbFileNameDetalle = FileNamePedidosDetalleFTP + detailFileName; //fecha.Day.ToString();// +lTurnoId.ToString();
            //string dbFileNameHeader = dbFileNameDetalle.Replace(FileNamePedidosDetalleFTP, FileNamePedidosHeaderFTP); // FileNamePedidosHeaderFTP + fecha.Day.ToString();// + lTurnoId.ToString();


            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            if (File.Exists(path + "\\" + dbFileNameDetalle))
                File.Delete(path + "\\" + dbFileNameDetalle);


            if (File.Exists(path + "\\" + dbFileNameHeader))
                File.Delete(path + "\\" + dbFileNameHeader);


            File.Copy(pathMolde + "\\" + FileNamePedidosDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle);
            File.Copy(pathMolde + "\\" + FileNamePedidosHeaderFTP + ".dbf", path + "\\" + dbFileNameHeader );


            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            return true;
        }



        public Boolean CopyEmtpyTablesComprasYDevolucionesV2(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, string dbFileNameDetalle, string path)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos_Molde;
            //string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            if (File.Exists(path + "\\" + dbFileNameDetalle ))
                File.Delete(path + "\\" + dbFileNameDetalle );



            File.Copy(pathMolde + "\\" + FileNamePedidosDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle);


            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle ;
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle ;
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);


            return true;
        }




        public Boolean CopyEmtpyTablesPedidoDBF(string dbFileNameDetalle, string path)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos_Molde;
            //string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            if (File.Exists(path + "\\" + dbFileNameDetalle))
                File.Delete(path + "\\" + dbFileNameDetalle);



            File.Copy(pathMolde + "\\" + FileNamePedidosDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle );


            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            return true;
        }



        public Boolean CopyEmtpyTablesVentas(DateTime fecha)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Ventas_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Ventas + "\\" + fecha.Month.ToString();

            string dbFileNameDetalle = FileNameVentasDetalleFTP + fecha.Day.ToString();
            string dbFileNameHeader = FileNameVentasHeaderFTP + fecha.Day.ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + ".dbf"))
                File.Delete(path + "\\" + dbFileNameDetalle + ".dbf");


            if (File.Exists(path + "\\" + dbFileNameHeader + ".dbf"))
                File.Delete(path + "\\" + dbFileNameHeader + ".dbf");

            File.Copy(pathMolde + "\\" + FileNameVentasDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle + ".dbf");
            File.Copy(pathMolde + "\\" + FileNameVentasHeaderFTP + ".dbf", path + "\\" + dbFileNameHeader + ".dbf");


            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);


            CmdTxt = "Delete FROM '" + dbFileNameHeader + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);


            CmdTxt = "PACK '" + dbFileNameHeader + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);


            return true;
        }





        public Boolean CopyEmtpyTablesTrasladosEnvios(DateTime fecha, int folio, string sucursalOrig, string sucursalDest)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosEnvios_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosEnvios + sucursalDest + "\\";

            string dbFileNameDetalle = FileNameTrasladosEnviosDetalleFTP + folio.ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + "." + sucursalOrig))
                File.Delete(path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            File.Copy(pathMolde + "\\" + FileNameTrasladosEnviosDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            return true;
        }




        public Boolean CopyEmtpyTablesTrasladosDevoEnvios(DateTime fecha, int folio, string sucursalOrig, string sucursalDest)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosDevoEnvios_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosDevoEnvios + sucursalDest + "\\";

            string dbFileNameDetalle = FileNameTrasladosDevoEnviosDetalleFTP + folio.ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + "." + sucursalOrig))
                File.Delete(path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            File.Copy(pathMolde + "\\" + FileNameTrasladosDevoEnviosDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            return true;
        }



        public Boolean CopyEmtpyTablesPedidosDevoEnvios(DateTime fecha, int folio, string sucursalOrig, string sucursalDest)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_PedidosDevoEnvios_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_PedidosDevoEnvios + sucursalDest + "\\";

            string dbFileNameDetalle = FileNamePedidosDevoEnviosDetalleFTP + folio.ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + "." + sucursalOrig))
                File.Delete(path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            File.Copy(pathMolde + "\\" + FileNamePedidosDevoEnviosDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            return true;
        }


        public Boolean CopyEmtpyTablesExistencias(string sucursalOrig)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_ExistenciasLocales_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_ExistenciasLocales + "\\";

            string dbFileNameDetalle = FileNameExistenciasFTP;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + "." + sucursalOrig))
                File.Delete(path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            File.Copy(pathMolde + "\\" + FileNameExistenciasFTP + ".dbf", path + "\\" + dbFileNameDetalle + "." + sucursalOrig);

            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + "." + sucursalOrig + "'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);


            return true;
        }




        public Boolean CopyEmtpyTablesRecepcionCompras(long doctoId)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_RecepcionCompras_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_RecepcionCompras + "\\";

            string dbFileNameDetalle = FileNameRecepcionComprasFTP + doctoId.ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + ".dbf"))
                File.Delete(path + "\\" + dbFileNameDetalle + ".dbf");

            File.Copy(pathMolde + "\\" + FileNameRecepcionComprasFTP + ".dbf", path + "\\" + dbFileNameDetalle + ".dbf");

            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + ".dbf'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + ".dbf'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            return true;
        }



        public Boolean CopyEmtpyTablesMatrizEnvioPedidosASucursal(long doctoId, string path, string dbFileNameDetalle)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizEnviosSucursales_Molde;



            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle + ".dbf"))
                File.Delete(path + "\\" + dbFileNameDetalle + ".dbf");

            File.Copy(pathMolde + "\\" + FileNameMatrizEnvioPedidosASucursalFTP + ".dbf", path + "\\" + dbFileNameDetalle + ".dbf");

            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string CmdTxt = "Delete FROM '" + dbFileNameDetalle + ".dbf'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            CmdTxt = "PACK '" + dbFileNameDetalle + ".dbf'";
            OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            return true;
        }




        public Boolean ExportPedidos(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, DateTime fechaTo, bool bAutomatico, ref long lReenviarPedidoExistente, ref string fileNameDetalle, ref CEXP_FILESBE filesExpBE)
        {



            try
            {

                if (!exportarAFTP_PEDIDOS(parametroBE, cajaBE, parametroBE.ISUCURSALID, fecha, fechaTo, true, parametroBE.IID_DOSLETRAS, null, bAutomatico, ref lReenviarPedidoExistente, ref fileNameDetalle, ref filesExpBE))
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }

            return true;
        }


        public Boolean ExportVentas(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha)
        {
            CopyEmtpyTablesVentas(fecha);
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Ventas + fecha.Month.ToString();


            string dbFileNameDetalle = FileNameVentasDetalleFTP + fecha.Day.ToString();
            string dbFileNameHeader = FileNameVentasHeaderFTP + fecha.Day.ToString();

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
            try
            {

                if (!exportarAFTP_VENTAS(parametroBE.ISUCURSALID, fecha/*, cajaBE.ITURNOID*/, false, dbFileNameDetalle, dbFileNameHeader, null, null, strOleDbConn))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }


            return true;
        }



        public string ObtenerClaveSucursalDestino(int folio, long lTipoDoctoId)
        {

            CDOCTOBE doctoBE = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            doctoBE.ITIPODOCTOID = lTipoDoctoId; ;
            doctoBE.IFOLIO = folio;
            return doctoD.ObtenerClaveSucDestXTIPOYFOLIO(doctoBE, null);

        }


        public string ObtenerClaveSucursalDestinoXId(long sucursalId)
        {

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();
            sucBE.IID = sucursalId;
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if (sucBE != null)
                return sucBE.ICLAVE;

            return "";


        }

        public Boolean ExportTrasladosEnvios(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, int folio, string sucursalOrig)
        {

            string sucursalDest = ObtenerClaveSucursalDestino(folio, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
            if (sucursalDest == "")
            {
                this.IComentario = "Sucursal inexistente";
                return false;
            }

            CopyEmtpyTablesTrasladosEnvios(fecha, folio, sucursalOrig, sucursalDest);
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosEnvios + sucursalDest + "\\";
            string dbFileNameDetalle = FileNameTrasladosEnviosDetalleFTP + folio.ToString() + "." + sucursalOrig;

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            try
            {

                if (!exportarAFTP_TRASLADOSENVIOS(parametroBE.ISUCURSALID, fecha/*, cajaBE.ITURNOID*/, folio, false, dbFileNameDetalle /*, dbFileNameHeader*/, null, null, strOleDbConn))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }


            return true;
        }




        public Boolean ExportTrasladosEnviosAux(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, int folio, string sucursalOrig, long doctoId, CPERSONABE currentUser, FbTransaction ft)
        {
            string sucursalDest = ObtenerClaveSucursalDestino(folio, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
            if (sucursalDest == "")
            {
                this.IComentario = "Sucursal inexistente";
                return false;
            }

            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosEnviosAux + sucursalDest + "\\";
            string dbFileNameDetalle = FileNameTrasladosEnviosDetalleFTP + folio.ToString() + "." + sucursalOrig;

            string tempDBFPath = path + dbFileNameDetalle + "\\";
            string zipName = dbFileNameDetalle + ".zip";
            ArrayList strErrores = new ArrayList();
            ExportCatalogosEnvioMercancia(parametroBE, currentUser, fecha, doctoId, path, zipName, tempDBFPath, ref strErrores, ft);

            if (strErrores.Count > 0)
            {
                return false;
            }
            return true;
        }




        public Boolean ExportTrasladosDevoEnvios(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, int folio, string sucursalOrig)
        {

            string sucursalDest = ObtenerClaveSucursalDestino(folio, DBValues._DOCTO_TIPO_TRASPASO_REC);
            if (sucursalDest == "")
            {
                this.IComentario = "Sucursal inexistente";
                return false;
            }

            CopyEmtpyTablesTrasladosDevoEnvios(fecha, folio, sucursalOrig, sucursalDest);
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_TrasladosDevoEnvios + sucursalDest + "\\";
            string dbFileNameDetalle = FileNameTrasladosDevoEnviosDetalleFTP + folio.ToString() + "." + sucursalOrig;

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            try
            {

                if (!exportarAFTP_TRASLADOSDEVOENVIOS(parametroBE.ISUCURSALID, fecha/*, cajaBE.ITURNOID*/, folio, false, dbFileNameDetalle /*, dbFileNameHeader*/, null, null, strOleDbConn))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }


            return true;
        }


        public Boolean ExportPedidosDevoEnvios(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, int folio, string sucursalOrig)
        {

            string sucursalDest = ObtenerClaveSucursalDestino(folio, DBValues._DOCTO_TIPO_COMPRA);
            if (sucursalDest == "")
            {
                this.IComentario = "Sucursal inexistente";
                return false;
            }

            CopyEmtpyTablesPedidosDevoEnvios(fecha, folio, sucursalOrig, sucursalDest);
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_PedidosDevoEnvios + sucursalDest + "\\";
            string dbFileNameDetalle = FileNamePedidosDevoEnviosDetalleFTP + folio.ToString() + "." + sucursalOrig;

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            try
            {

                if (!exportarAFTP_PEDIDOSDEVOENVIOS(parametroBE.ISUCURSALID, fecha/*, cajaBE.ITURNOID*/, folio, false, dbFileNameDetalle /*, dbFileNameHeader*/, null, null, strOleDbConn))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }


            return true;
        }





        public Boolean ExportRecepcionCompras(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, long doctoId)
        {
            CopyEmtpyTablesRecepcionCompras(doctoId);
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_RecepcionCompras;
            string dbFileNameDetalle = FileNameRecepcionComprasFTP + doctoId.ToString() + ".dbf";

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
            //OleDbConnection oleDbConn = new OleDbConnection();
            //oleDbConn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
            //OleDbTransaction oleDbTrans = null;


            //FbConnection fbConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fbTrans = null;

            try
            {
                //fbConn.Open();
                //oleDbConn.Open();

                //fbTrans = fbConn.BeginTransaction();
                //oleDbTrans = oleDbConn.BeginTransaction();

                if (!exportarAFTP_RECEPCIONCOMPRAS(parametroBE.ISUCURSALID, doctoId, dbFileNameDetalle, null, null, strOleDbConn))
                {
                    //fbTrans.Rollback();
                    //oleDbTrans.Rollback();
                    return false;
                }

                //fbTrans.Commit();
                //oleDbTrans.Commit();
            }
            catch (Exception ex)
            {
                //fbTrans.Rollback();
                //oleDbTrans.Rollback();
                this.iComentario = ex.Message;
            }

            //oleDbConn.Close();

            return true;
        }





        public Boolean ExportMatrizCatalogos(CPARAMETROBE parametroBE, CPERSONABE currentUser, DateTime fecha, ref ArrayList strErrores)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosExport;
            CopyEmtpyTablesMatrizCatalogos(path);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            try
            {
                if (!exportarAFTP_MatrizPROD(ImportarDBF.PRODUCT_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizMARC(ImportarDBF.MARCA_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizLINE(ImportarDBF.LINEA_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizAREA(ImportarDBF.AREA_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizARDR(ImportarDBF.ARDR_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizCATS(ImportarDBF.SUCURSAL_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizPROV(ImportarDBF.PROVEEDOR_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizENCC(ImportarDBF.ENCARGADOCORTE_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizTASA(ImportarDBF.TASAIVA_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizESTADO(ImportarDBF.EDOS_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizUNIDAD(ImportarDBF.UNIDAD_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizBANCO(ImportarDBF.BANK_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizTIPO(ImportarDBF.TIPO_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizCTRL(ImportarDBF.CTRL_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizCONTENIDO(ImportarDBF.CONTENIDO_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizCLASIFICA(ImportarDBF.CLASIFICA_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizMOTIVOSDEVOLUCION(ImportarDBF.MOTIVOSDEVOLUCION_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizCaracteristicasProducto(ImportarDBF.DEFCARACTPROD_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizGruposSucursal(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizPLAZO(ImportarDBF.PLAZO_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }



                if (parametroBE.IMANEJAKITS != null && parametroBE.IMANEJAKITS.Equals("S"))
                {
                    if (!exportarAFTP_MatrizKITS(ImportarDBF.KITS_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                }

                if (!exportarAFTP_PRM(ImportarDBF.PRM_DBF_FILENAME, null, null, strOleDbConn))
                {
                    return false;
                }




                exportarAFTP_MatrizTERM(ImportarDBF.TERM_DBF_FILENAME, null, null, strOleDbConn);
                exportarAFTP_MatrizMERCH(ImportarDBF.MERCH_DBF_FILENAME, null, null, strOleDbConn);
                exportarAFTP_MatrizCLERK(ImportarDBF.CLERK_DBF_FILENAME, null, null, strOleDbConn);

                exportarAFTP_MatrizProductosPromocion(ImportarDBF.TRCL_DBF_FILENAME, null, null, strOleDbConn);

                exportarAFTP_MatrizPRSC(ImportarDBF.PRODSUCURSAL_DBF_FILENAME, null, null, strOleDbConn);

                exportarAFTP_MatrizLSPR(ImportarDBF.LISTAPRECIOS_DBF_FILENAME, null, null, strOleDbConn);
                exportarAFTP_MatrizLPDT(ImportarDBF.LISTAPRECIODETALLE_DBF_FILENAME, null, null, strOleDbConn);

                exportarAFTP_MatrizMXFT(ImportarDBF.MAXFACT_DBF_FILENAME, null, null, strOleDbConn);


                exportarAFTP_MatrizGASTO(ImportarDBF.GASTO_DBF_FILENAME, null, null, strOleDbConn);


                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipTemporal))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipTemporal);

                ZipUtil.ZipFiles(path, FileLocalLocation_MatrizPreciosZipName, "");


                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipFinal))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipFinal);

                File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipTemporal, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipFinal);

                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipTemporal);


                if (!iPos.ImportaDesdeFtp.UploadFile(FileLocalLocation_MatrizPreciosZipName, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosZipLocalPath, FileLocalLocation_MatrizPreciosZipFtpPath, false, true, ref strErrores))
                {
                    strErrores.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                    this.iComentario = "El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet";
                    return false;
                }
                else
                {

                    if (CurrentUserID.CurrentParameters.IMOVIL_TIENEVENDEDORES != null && CurrentUserID.CurrentParameters.IMOVIL_TIENEVENDEDORES.Equals("S") &&
                        (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4) &&
                        (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")))
                    {

                        iPos.com.server.ipos.Service1 service1 = new iPos.com.server.ipos.Service1();
                        string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                        if (strWebService.Trim().Length > 0)
                        {
                            service1.Url = strWebService.Trim();
                        }


                        //ventas

                        string strRespuesta = service1.UnzipPRODFromPrecZIP(
                                           iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                           iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }

                }



            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
                strErrores.Add("ex.Message");
                return false;
            }

            //oleDbConn.Close();

            return true;
        }






        public Boolean ExportMatrizPreciosTemp(CPARAMETROBE parametroBE, CPERSONABE currentUser, DateTime fecha, ref ArrayList strErrores)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosTempExport;
            CopyEmtpyTablesMatrizPreciosTemp(path);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string strKey = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFileLocalLocation_MatrizPreciosTempZipName = FileLocalLocation_MatrizPreciosTempZipName_.Replace("PRECTEMP.ZIP", strKey + "PRECTEMP.ZIP");
            string strFileLocalLocation_MatrizPreciosTempZipTemporal = FileLocalLocation_MatrizPreciosTempZipTemporal_.Replace("PRECTEMP.ZIP", strKey + "PRECTEMP.ZIP");
            string strFileLocalLocation_MatrizPreciosTempZipFinal = FileLocalLocation_MatrizPreciosTempZipFinal_.Replace("PRECTEMP.ZIP", strKey + "PRECTEMP.ZIP");


            try
            {

                if (!exportarAFTP_MatrizPRECTEMP(ImportarDBF.PRECTEMP_DBF_FILENAME, 0, null, null, strOleDbConn))
                {
                    return false;
                }


                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipTemporal))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipTemporal);

                ZipUtil.ZipFiles(path, strFileLocalLocation_MatrizPreciosTempZipName, "");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipFinal))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipFinal);

                File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipTemporal, System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipFinal);

                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + strFileLocalLocation_MatrizPreciosTempZipTemporal);


                if (!iPos.ImportaDesdeFtp.UploadFile(strFileLocalLocation_MatrizPreciosTempZipName, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosTempZipLocalPath, FileLocalLocation_MatrizPreciosTempZipFtpPath, false, true, ref strErrores))
                {
                    strErrores.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                    this.iComentario = "El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet";
                    return false;
                }



            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
                strErrores.Add("ex.Message");
                return false;
            }

            //oleDbConn.Close();

            return true;
        }





        public Boolean ExportParaMovil(CPARAMETROBE parametroBE, CPERSONABE currentUser, DateTime fecha, CPERSONABE vendedor, CPERSONABE usuarioRelacionadAVendedor, CBITACOBRANZABE cobranzaALlevar, bool exportProductInactive, ref ArrayList strErrores, string version = "DBF")
        {


            //public const string FileLocalLocation_MovilPreciosExport_Sqlite = "\\sampdata\\matriz\\movil\\precios\\prec_movil\\";
            //public const string FileLocalLocation_MovilPreciosZipName_Sqlite = "PREC.db";

            string path = "";
            string strOleDbConn = "";



            try
            {
                //checar almacen cuando se tenga que obtener existencia por almacen
                long almacenId = 0;
                if (parametroBE.IMANEJAALMACEN == "S" && usuarioRelacionadAVendedor != null)
                    almacenId = usuarioRelacionadAVendedor.IALMACENID;

                if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport_Sqlite;
                    ExportacionMovilSqlite.CreateMovilDB(path, FileLocalLocation_MovilPreciosDbName_Sqlite);
                    strOleDbConn = "Data Source=\"" + path + FileLocalLocation_MovilPreciosDbName_Sqlite + "\";Version=3;";
                }
                else
                {
                    path = version = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport;
                    CopyEmtpyTablesMovilCatalogos(path);
                    strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
                }


                if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
                {



                    if (!exportarAFTP_MovilM_DER(ImportarDBF.DERECHO_DBF_FILENAME, null, strOleDbConn, version))
                    {
                        return false;
                    }

                    if (!exportarAFTP_MovilM_DER_U(ImportarDBF.DERECHOUSUARIO_DBF_FILENAME, null, strOleDbConn, version))
                    {
                        return false;
                    }

        
                    if (!exportarAFTP_MovilM_PARM(ImportarDBF.USUARIO_DBF_FILENAME, null, strOleDbConn, version))
                    {
                        return false;
                    }

        
                    if (!exportarAFTP_MovilM_USER(ImportarDBF.PARAMETRO_DBF_FILENAME, null, strOleDbConn, version))
                    {
                        return false;
                    }
                }


                if (!exportarAFTP_MatrizPROV(ImportarDBF.PROVEEDOR_DBF_FILENAME, 0, null, null, strOleDbConn, version))
                {
                    return false;
                }


                if (!exportarAFTP_MovilPROD(ImportarDBF.PRODUCT_DBF_FILENAME, 0, null, null, strOleDbConn, exportProductInactive, almacenId, version))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizBANCO(ImportarDBF.BANK_DBF_FILENAME, null, null, strOleDbConn, version))
                {
                    return false;
                }


                
                if (!exportarAFTP_MatrizESTADO(ImportarDBF.EDOS_DBF_FILENAME, null, null, strOleDbConn, version))
                {
                    return false;
                }

                if (parametroBE.IMANEJAKITS != null && parametroBE.IMANEJAKITS.Equals("S"))
                {
                    if (!exportarAFTP_MatrizKITS(ImportarDBF.KITS_DBF_FILENAME, null, null, strOleDbConn, version))
                    {
                        return false;
                    }
                }


                if (vendedor != null)
                {

                    if (cobranzaALlevar != null)
                    {
                        if (!exportarAFTP_MovilCobranza(ImportarDBF.CXCMOVIL_DBF_FILENAME, cobranzaALlevar, vendedor, null, null, strOleDbConn, version))
                        {
                            return false;
                        }
                    }

                    if (!exportarAFTP_MovilCliente(ImportarDBF.CLIENTEMOVIL_DBF_FILENAME, vendedor, null, null, strOleDbConn, version))
                    {
                        return false;
                    }
                }

               if (!version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
                {


                    if (!exportarAFTP_MatrizMARC(ImportarDBF.MARCA_DBF_FILENAME, 0, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizLINE(ImportarDBF.LINEA_DBF_FILENAME, 0, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizAREA(ImportarDBF.AREA_DBF_FILENAME, 0, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizARDR(ImportarDBF.ARDR_DBF_FILENAME, 0, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizCATS(ImportarDBF.SUCURSAL_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }


                    if (!exportarAFTP_MatrizTASA(ImportarDBF.TASAIVA_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }


                    if (!exportarAFTP_MatrizUNIDAD(ImportarDBF.UNIDAD_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }

                    if (!exportarAFTP_MatrizCONTENIDO(ImportarDBF.CONTENIDO_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizCLASIFICA(ImportarDBF.CLASIFICA_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizMOTIVOSDEVOLUCION(ImportarDBF.MOTIVOSDEVOLUCION_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }

                    if (!exportarAFTP_MatrizCaracteristicasProducto(ImportarDBF.DEFCARACTPROD_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }

                    if (!exportarAFTP_MatrizGruposSucursal(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }

                    if (!exportarAFTP_MatrizPLAZO(ImportarDBF.PLAZO_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }




                    if (!exportarAFTP_PRM(ImportarDBF.PRM_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }



                    exportarAFTP_MatrizTERM(ImportarDBF.TERM_DBF_FILENAME, null, null, strOleDbConn);
                    exportarAFTP_MatrizMERCH(ImportarDBF.MERCH_DBF_FILENAME, null, null, strOleDbConn);
                    exportarAFTP_MatrizCLERK(ImportarDBF.CLERK_DBF_FILENAME, null, null, strOleDbConn);

                    exportarAFTP_MatrizProductosPromocion(ImportarDBF.TRCL_DBF_FILENAME, null, null, strOleDbConn);

                    exportarAFTP_MatrizPRSC(ImportarDBF.PRODSUCURSAL_DBF_FILENAME, null, null, strOleDbConn);

                    exportarAFTP_MatrizLSPR(ImportarDBF.LISTAPRECIOS_DBF_FILENAME, null, null, strOleDbConn);
                    exportarAFTP_MatrizLPDT(ImportarDBF.LISTAPRECIODETALLE_DBF_FILENAME, null, null, strOleDbConn);

                    //exportarAFTP_MatrizMXFT(ImportarDBF.MAXFACT_DBF_FILENAME, null, null, strOleDbConn);

                    //if (vendedor != null)
                    //{

                    //    if (cobranzaALlevar != null)
                    //    {
                    //        if (!exportarAFTP_MovilCobranza(ImportarDBF.CXCMOVIL_DBF_FILENAME, cobranzaALlevar, vendedor, null, null, strOleDbConn))
                    //        {
                    //            return false;
                    //        }
                    //    }

                    //    if (!exportarAFTP_MovilCliente(ImportarDBF.CLIENTEMOVIL_DBF_FILENAME, vendedor, null, null, strOleDbConn, version))
                    //    {
                    //        return false;
                    //    }
                    //}
                }


                string zipFileName = "";
                string zipPostFix = (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite)) ? "_ANDROID" : "";

                if (vendedor != null)
                {

                    zipFileName = "PREC_" + vendedor.ICLAVE + zipPostFix + ".zip";
                }
                else
                {
                    zipFileName = "PREC_" + zipPostFix + ".zip";
                } 

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport + zipFileName))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport + zipFileName);

                if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
                {

                    ExportacionMovilSqlite.FreeAllConnections();
                    ZipUtil.ZipFile(path + FileLocalLocation_MovilPreciosDbName_Sqlite, path + zipFileName, "");
                }
                else
                {
                    ZipUtil.ZipFiles(path, zipFileName, "");
                }


                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosZipLocalPath + zipFileName))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosZipLocalPath + zipFileName);




                //File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport + zipFileName, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosZipLocalPath + zipFileName);
                //File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport + zipFileName);

                File.Copy(path + zipFileName, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosZipLocalPath + zipFileName);
                File.Delete(path + zipFileName);


                if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
                {
                    ExportacionMovilSqlite.DeleteMovilDB(path, FileLocalLocation_MovilPreciosDbName_Sqlite);
                }



                //string remotePath = "/" + parametroBE.ISUCURSALNUMERO + "/" + FileLocalLocation_MovilPreciosZipFtpPath;// + "/" + vendedor.ICLAVE + "/out";

                //if (!iPos.ImportaDesdeFtp.UploadFile(zipFileName, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosZipLocalPath, remotePath, false, true, ref strErrores))
                //{
                //    strErrores.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                //    this.iComentario = "El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet";
                //    return false;
                //}

            }
            catch (Exception ex)
            {
                this.iComentario = "This " + ex.Message + ex.StackTrace;
                strErrores.Add("ex.Message");
                return false;
            }

            //oleDbConn.Close();

            return true;
        }


        
        public Boolean ExportCatalogosEnvioMercancia(CPARAMETROBE parametroBE, CPERSONABE currentUser, DateTime fecha, long doctoId, string rutaLocal, /*string rutaRemota,*/ string zipName, string tempDBFPath, ref ArrayList strErrores, FbTransaction st)
        {
            string path = tempDBFPath;
            CopyEmtpyTablesMatrizCatalogos(tempDBFPath);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            try
            {

                if (!exportarAFTP_MatrizPROD(ImportarDBF.PRODUCT_DBF_FILENAME, doctoId, st, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizMARC(ImportarDBF.MARCA_DBF_FILENAME, doctoId, st, null, strOleDbConn))
                {
                    return false;
                }
                if (!exportarAFTP_MatrizLINE(ImportarDBF.LINEA_DBF_FILENAME, doctoId, st, null, strOleDbConn))
                {
                    return false;
                }

                if (!exportarAFTP_MatrizPROV(ImportarDBF.PROVEEDOR_DBF_FILENAME, doctoId, st, null, strOleDbConn))
                {
                    return false;
                }



                if (File.Exists(path + "\\" + zipName))
                    File.Delete(path + "\\" + zipName);

                ZipUtil.ZipFiles(path, zipName, "");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (File.Exists(rutaLocal + "\\" + zipName))
                    File.Delete(rutaLocal + "\\" + zipName);

                File.Copy(path + "\\" + zipName, rutaLocal + "\\" + zipName);


                File.Delete(path + "\\" + zipName);

                /*
                if (!iPos.ImportaDesdeFtp.UploadFile(zipName, rutaLocal, rutaRemota, false, true, ref strErrores))
                {
                    strErrores.Add("El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet");
                    this.iComentario = "El archivo no pudo ser enviado a internet, se intentara enviar automaticamente cuando se reestablezca el internet";
                    return false;
                }*/



            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
                strErrores.Add("ex.Message");
                return false;
            }

            //oleDbConn.Close();

            return true;
        }





        public bool CopyFormatedDBF(string dbFileNameDetalle, string pathMolde, string path, bool cleanDB)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (File.Exists(path + "\\" + dbFileNameDetalle))
                File.Delete(path + "\\" + dbFileNameDetalle);

            File.Copy(pathMolde + "\\" + dbFileNameDetalle, path + "\\" + dbFileNameDetalle);

            if (cleanDB)
            {
                m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

                string CmdTxt = "Delete FROM '" + dbFileNameDetalle + "'";
                OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

                CmdTxt = "PACK '" + dbFileNameDetalle + "'";
                OleDbHelper.ExecuteNonQuery(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            }
            return true;
        }




        public Boolean CopyEmtpyTablesMatrizCatalogos(string tempDBFPath)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosExport_Molde;
            string path = tempDBFPath;

            CopyFormatedDBF(ImportarDBF.PRODUCT_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.MARCA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.LINEA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.AREA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.ARDR_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.PROVEEDOR_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.ENCARGADOCORTE_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.SUCURSAL_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.KITS_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.TASAIVA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.DEFCARACTPROD_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.EDOS_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.BANK_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.UNIDAD_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.TIPO_DBF_FILENAME, pathMolde, path, true);


            CopyFormatedDBF(ImportarDBF.PROMOCION_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.TERM_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.MERCH_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.CLERK_DBF_FILENAME, pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.CONTENIDO_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.CLASIFICA_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.MOTIVOSDEVOLUCION_DBF_FILENAME, pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.PLAZO_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.PRM_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.TRCL_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.CTRL_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.PRODSUCURSAL_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.LISTAPRECIOS_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.LISTAPRECIODETALLE_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.MAXFACT_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.GASTO_DBF_FILENAME, pathMolde, path, true);

            //CopyFormatedDBF(ImportarDBF.PRODUCT_DBF_FILENAME.ToUpper().Replace(".DBF", ".FPT"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.MARCA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.LINEA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.ENCARGADOCORTE_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.PROVEEDOR_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.SUCURSAL_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.KITS_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.TASAIVA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.DEFCARACTPROD_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.EDOS_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.BANK_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.TIPO_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.UNIDAD_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.AREA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.ARDR_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.PROMOCION_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.GASTO_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            return true;
        }




        public Boolean CopyEmtpyTablesMatrizPreciosTemp(string tempDBFPath)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizPreciosTemp_Molde;
            string path = tempDBFPath;

            CopyFormatedDBF(ImportarDBF.PRECTEMP_DBF_FILENAME, pathMolde, path, true);




            return true;
        }



        public Boolean CopyEmtpyTablesMovilCatalogos(string tempDBFPath)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MovilPreciosExport_Molde;
            string path = tempDBFPath;

            CopyFormatedDBF(ImportarDBF.PRODUCT_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.MARCA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.LINEA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.AREA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.ARDR_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.PROVEEDOR_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.ENCARGADOCORTE_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.SUCURSAL_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.KITS_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.TASAIVA_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.DEFCARACTPROD_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.EDOS_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.BANK_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.UNIDAD_DBF_FILENAME, pathMolde, path, true);


            CopyFormatedDBF(ImportarDBF.PROMOCION_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.TERM_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.MERCH_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.CLERK_DBF_FILENAME, pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.CONTENIDO_DBF_FILENAME, pathMolde, path, true);
            CopyFormatedDBF(ImportarDBF.CLASIFICA_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.MOTIVOSDEVOLUCION_DBF_FILENAME, pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.PLAZO_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.PRM_DBF_FILENAME, pathMolde, path, true);

            CopyFormatedDBF(ImportarDBF.TRCL_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.CLIENTEMOVIL_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.CXCMOVIL_DBF_FILENAME, pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.HISTORIAL_DBF_FILENAME, pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.PRODSUCURSAL_DBF_FILENAME, pathMolde, path, false);

            //CopyFormatedDBF(ImportarDBF.PRODUCT_DBF_FILENAME.ToUpper().Replace(".DBF", ".FPT"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.MARCA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.LINEA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.PROVEEDOR_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.ENCARGADOCORTE_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.SUCURSAL_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.KITS_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.TASAIVA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.DEFCARACTPROD_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);

            CopyFormatedDBF(ImportarDBF.EDOS_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.BANK_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.UNIDAD_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.AREA_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);
            CopyFormatedDBF(ImportarDBF.ARDR_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);


            CopyFormatedDBF(ImportarDBF.PROMOCION_DBF_FILENAME.ToUpper().Replace(".DBF", ".CDX"), pathMolde, path, false);



            return true;
        }



        public static string GetLocalLocationMatriz(short iTipo, long sucursalId)
        {
            string sucursalClave;
            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.IID = sucursalId;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            sucursalClave = sucursalBE.ICLAVE;


            switch (iTipo)
            {
                case FileType_MatrizEnvioPedidosASucursal: return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizEnviosSucursales + sucursalClave + "\\";
                case FileType_MatrizEnvioPedidosASucursalAux: return System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_MatrizEnviosSucursalesAux + sucursalClave + "\\";
                default: return "";
            }

        }



        public Boolean ExportEnvioMatrizPedidoAux(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, CDOCTOBE docto, CPERSONABE currentUser, FbTransaction ft)
        {
            string path = GetLocalLocationMatriz(FileType_MatrizEnvioPedidosASucursalAux, docto.ISUCURSALTID);
            string dbFileNameDetalle = FileNameMatrizEnvioPedidosASucursalFTP + docto.IFOLIO.ToString().PadLeft(7, '0');

            string tempDBFPath = path + dbFileNameDetalle + "\\";
            string zipName = dbFileNameDetalle + ".zip";
            ArrayList strErrores = new ArrayList();
            ExportCatalogosEnvioMercancia(parametroBE, currentUser, fecha, docto.IID, path, zipName, tempDBFPath, ref strErrores, ft);

            if (strErrores.Count > 0)
            {
                return false;
            }
            return true;
        }



        public string PostFijoMatrizPedido(CDOCTOBE docto)
        {
            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucFuente = new CSUCURSALBE();
            CSUCURSALBE sucDest = new CSUCURSALBE();

            sucFuente.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
            sucDest.IID = docto.ISUCURSALTID;

            sucFuente = sucD.seleccionarSUCURSAL(sucFuente, null);
            sucDest = sucD.seleccionarSUCURSAL(sucDest, null);

            if (sucFuente == null || sucDest == null)
                return "";

            if(sucFuente.IESMATRIZ == null || !sucFuente.IESMATRIZ.Equals("S") ||
                 (sucDest.ISURTIDOR != null && sucDest.ISURTIDOR.Length > 0 && !sucDest.ISURTIDOR.Equals(sucFuente.ICLAVE)))
            {
                return "_" + sucFuente.ICLAVE;
            }

            return "";
        }

        public Boolean ExportEnvioMatrizPedido(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha, CDOCTOBE docto, FbTransaction ft)
        {
            string path = GetLocalLocationMatriz(FileType_MatrizEnvioPedidosASucursal, docto.ISUCURSALTID);//System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_RecepcionCompras;

            string postFijo = PostFijoMatrizPedido( docto);

            string dbFileNameDetalle = FileNameMatrizEnvioPedidosASucursalFTP + docto.IFOLIO.ToString().PadLeft(7, '0') + postFijo;// +".dbf";
            CopyEmtpyTablesMatrizEnvioPedidosASucursal(docto.IID, path, dbFileNameDetalle);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
            strOleDbConn = strOleDbConn.Replace("\\\\", "\\");

            try
            {




                if (!exportarAFTP_ENVIOMATRIZPEDIDO(parametroBE.ISUCURSALID, docto.IID, dbFileNameDetalle, ft, null, strOleDbConn))
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }


            return true;
        }



        public Boolean ExportExistencias(CPARAMETROBE parametroBE, string sucursalOrig)
        {
            CopyEmtpyTablesExistencias(sucursalOrig);
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_ExistenciasLocales;
            string dbFileNameDetalle = FileNameExistenciasFTP + "." + sucursalOrig;

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            try
            {
                if (!exportarAFTP_EXISTENCIAS(parametroBE.ISUCURSALID, dbFileNameDetalle, null, null, strOleDbConn))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }


            return true;
        }



        public bool exportarAFTP_VENTAS(long lSucursalId, DateTime Fecha/*, long lTurnoId*/, bool bForzado, string strTableExpNameDet, string strTableExpNameHdr, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CVEDMD vedmD = new CVEDMD();
            CVEDMBE vedmBE = new CVEDMBE();

            CVENMBE venmBE = new CVENMBE();
            CVENMD venmD = new CVENMD();

            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {
                parts = new ArrayList();

                //String CmdTxt = @"select d.*,p.pd_descripcion1 from DETALLE_DE_VENTAS d inner join productos p on d.pd_producto == p.pd_producto where DE_FECHA = @DE_FECHA and DE_EXPROTADO <> 'S'";
                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                'MN'  as MONEDA,
                                                DOCTO.VENDEDORID  VENDEDORID


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid 
                                    WHERE        DOCTO.FECHA = @FECHA and DOCTO.TIPODOCTOID = 21 AND DOCTO.ESTATUSDOCTOID = 1
                                    ORDER BY DOCTOID, MOVTOID";



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = Fecha;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    vedmBE = new CVEDMBE();



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {

                        vedmBE.IVENTA = dr["DOCTOID"].ToString();
                        vedmBE.IORIGEN = dr["DOCTOID"].ToString();
                    }



                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        vedmBE.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        vedmBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        vedmBE.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        vedmBE.IMARCA = (string)(dr["MARCA"]);
                    }


                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        vedmBE.IPRECIO = (decimal)(dr["PRECIO"]);
                    }


                    if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    {
                        vedmBE.IPREC_LISTA = (decimal)(dr["PRECIOLISTA"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vedmBE.IFECHA = (DateTime)(dr["FECHA"]);
                        vedmBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }


                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        vedmBE.IDESC2 = dr["DESCRIPCION"].ToString();
                    }


                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        vedmBE.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["IMPORTENETO"] != System.DBNull.Value)
                    {
                        vedmBE.IIMPORTNETO = (decimal)(dr["IMPORTENETO"]);
                    }


                    if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    {
                        vedmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        vedmBE.IMONEDA = (string)(dr["MONEDA"]);
                    }


                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        vedmBE.IVENDEDOR = dr["VENDEDORID"].ToString();
                    }


                    vedmBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    vedmBE.IID = "CAJA";
                    if (!vedmD.AgregarVEDMD(vedmBE, strTableExpNameDet, odt, strOleDbConn))
                    {
                        this.iComentario += vedmD.IComentario + "\n";
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                //return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }



            try
            {

                parts = new ArrayList();

                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID,
                                         SUCURSAL.CLAVE AS  SUCURSAL,
                                         DOCTO.FECHA AS FECHA,
                                         DOCTO.FOLIO AS FOLIO,
                                         DOCTO.IVA AS   IVA,
                                         DOCTO.TOTAL AS TOTAL,
                                                TURNO.nombre NOMBRETURNO,
                                                PERSONA.clave CLAVECLIENTE

                                   FROM            DOCTO  left OUTER JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT JOIN
                                                turno  ON TURNO.id = docto.turnoid   LEFT JOIN
                                                PERSONA ON PERSONA.ID = DOCTO.personaid 
                                    WHERE   DOCTO.FECHA = @FECHA and DOCTO.TIPODOCTOID = 21 AND DOCTO.ESTATUSDOCTOID = 1
                                    ORDER BY DOCTOID";



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = Fecha;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    {
                        venmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    }


                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        venmBE.IVENTA = dr["DOCTOID"].ToString();
                        venmBE.IORIGEN = dr["DOCTOID"].ToString();
                    }


                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        venmBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                        venmBE.IF_FACTURA = (DateTime)(dr["FECHA"]);
                        venmBE.IPEDIDO = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        venmBE.IFACTURA = dr["FOLIO"].ToString();
                    }


                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        venmBE.ITOTAL = decimal.Parse(dr["TOTAL"].ToString());
                        venmBE.ISUMA = decimal.Parse(dr["TOTAL"].ToString());
                        venmBE.IEFECTIVO = decimal.Parse(dr["TOTAL"].ToString());
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        venmBE.IIMPUESTO = decimal.Parse(dr["IVA"].ToString());
                    }


                    venmBE.IID = "CAJA";
                    if (venmD.AgregarVENMD(venmBE, strTableExpNameHdr, odt, strOleDbConn) == null)
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += venmD.IComentario + "\n";
                        return false;
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public bool exportarAFTP_TRASLADOSENVIOS(long lSucursalId, DateTime Fecha/*, long lTurnoId*/, int folio, bool bForzado, string strTableExpNameDet/*, string strTableExpNameHdr*/, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_TRASD m_trasD = new CM_TRASD();
            CM_TRASBE m_trasBE = new CM_TRASBE();

            CDOCTOD doctoD = new CDOCTOD();
            long doctoIdFinalAEnviar = 0; //en algunos casos se tiene que enviar los datos de la venta producida por el traslado en vez del traslado


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                doctoIdFinalAEnviar = doctoD.seleccionarDOCTOFINALAEnviarXFolio(folio, DBValues._DOCTO_TIPO_TRASPASO_ENVIO, null);
                if (doctoIdFinalAEnviar <= 0)
                {
                    this.iComentario = "No se encontro el traslado";
                    return false;
                }


                parts = new ArrayList();

                //String CmdTxt = @"select d.*,p.pd_descripcion1 from DETALLE_DE_VENTAS d inner join productos p on d.pd_producto == p.pd_producto where DE_FECHA = @DE_FECHA and DE_EXPROTADO <> 'S'";
                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                'MN'  as MONEDA,
                                                DOCTO.VENDEDORID  VENDEDORID,
                                                MOVTO.FECHAVENCE,
                                                MOVTO.CANTIDADDEFACTURA,
                                                MOVTO.CANTIDADDEREMISION,
                                                MOVTO.CANTIDADDEINDEFINIDO,
                                                MOVTO.PRECIOVISIBLETRASLADO,
                                                SUCURSAL.PROVEEDORCLAVE,
                                                VENDEDOR.USERNAME CVEUSER,
                                                LOTESIMPORTADOS.PEDIMENTO IMP_PEDIMENTO,
                                                LOTESIMPORTADOS.FECHAIMPORTACION IMP_FECHAIMPORTACION,
                                                coalesce(sat_aduana.sat_claveaduana || ' ' || sat_aduana.sat_descripcion, coalesce( lotesimportados.aduana, '')) IMP_ADUANA,
                                                LOTESIMPORTADOS.TIPOCAMBIO IMP_TIPOCAMBIO,
                                                case when docto.tipodoctoid = 21 then docto.folio else null end  FOLIOVENTA
                    


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID LEFT JOIN
                                                    LOTESIMPORTADOS ON LOTESIMPORTADOS.ID = MOVTO.LOTEIMPORTADO
                                                    Left join sat_aduana on lotesimportados.sataduanaid = sat_aduana.id
                                    WHERE DOCTO.ID = @DOCTOID
                                    ORDER BY DOCTOID, MOVTOID";

                // WHERE        DOCTO.FOLIO = @FOLIO and DOCTO.TIPODOCTOID = 31 AND DOCTO.ESTATUSDOCTOID = 1



                /* auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                 auxPar.Value = folio;
                 parts.Add(auxPar);*/

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoIdFinalAEnviar;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_trasBE = new CM_TRASBE();



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {

                        m_trasBE.IVENTA = dr["DOCTOID"].ToString();
                        m_trasBE.IID = dr["DOCTOID"].ToString();
                    }

                    if (dr["FOLIOVENTA"] != System.DBNull.Value)
                    {
                        m_trasBE.IVENTA = "V" + dr["FOLIOVENTA"].ToString();
                    }


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        m_trasBE.ICANTIDAD = Decimal.ToDouble((decimal)(dr["CANTIDAD"]));
                        m_trasBE.IFALTANTE = Decimal.ToDouble((decimal)(dr["CANTIDAD"]));
                    }



                    if (dr["CANTIDADDEFACTURA"] != System.DBNull.Value)
                    {
                        m_trasBE.ICANT_FAC = Decimal.ToDouble((decimal)(dr["CANTIDADDEFACTURA"]));
                    }

                    if (dr["CANTIDADDEREMISION"] != System.DBNull.Value)
                    {
                        m_trasBE.ICANT_REM = Decimal.ToDouble((decimal)(dr["CANTIDADDEREMISION"]));
                    }

                    if (dr["CANTIDADDEINDEFINIDO"] != System.DBNull.Value)
                    {
                        m_trasBE.ICANT_IND = Decimal.ToDouble((decimal)(dr["CANTIDADDEINDEFINIDO"]));
                    }


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_trasBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        m_trasBE.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        m_trasBE.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        m_trasBE.IPROVEEDOR = (string)(dr["PROVEEDORCLAVE"]);
                    }



                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        m_trasBE.ICOSTO = Decimal.ToDouble((decimal)(dr["PRECIO"]));
                    }


                    //if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IPREC_LISTA = (decimal)(dr["PRECIOLISTA"]);
                    //}

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        m_trasBE.IFECHA = (DateTime)(dr["FECHA"]);
                        m_trasBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }


                    //if (dr["DESCRIPCION"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IDESC2 = dr["DESCRIPCION"].ToString();
                    //}


                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMPORTE = Decimal.ToDouble((decimal)(dr["IMPORTE"]));
                    }

                    if (dr["IMPORTENETO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMPORTNETO = Decimal.ToDouble((decimal)(dr["IMPORTENETO"]));
                    }


                    //if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    //}

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        m_trasBE.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    m_trasBE.IESTATUS = "P";


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        m_trasBE.ILOTE = (string)(dr["LOTE"]);
                    }


                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        m_trasBE.IF_CADUCA = (DateTime)(dr["FECHAVENCE"]);
                    }


                    if (dr["PRECIOVISIBLETRASLADO"] != System.DBNull.Value)
                    {
                        m_trasBE.IPRECREC = Decimal.ToDouble((decimal)(dr["PRECIOVISIBLETRASLADO"]));
                    }


                    if (dr["CVEUSER"] != System.DBNull.Value)
                    {
                        m_trasBE.ICVEUSER = dr["CVEUSER"].ToString();
                    }
                    else
                    {
                        m_trasBE.ICVEUSER = "";
                    }



                    if (dr["IMP_PEDIMENTO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_PED = dr["IMP_PEDIMENTO"].ToString();
                    }
                    else
                    {
                        m_trasBE.IIMP_PED = "";
                    }


                    if (dr["IMP_FECHAIMPORTACION"] != System.DBNull.Value)
                    {

                        m_trasBE.IIMP_FEC = (DateTime)(dr["IMP_FECHAIMPORTACION"]);
                    }



                    if (dr["IMP_ADUANA"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_ADU = dr["IMP_ADUANA"].ToString();
                    }
                    else
                    {
                        m_trasBE.IIMP_ADU = "";
                    }


                    if (dr["IMP_TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_TC = Decimal.ToDouble((decimal)(dr["IMP_TIPOCAMBIO"]));
                    }


                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        m_trasBE.ISUCURSAL = (string)(dr["SUCURSAL"]);
                    }


                    //if (dr["VENDEDORID"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IVENDEDOR = dr["VENDEDORID"].ToString();
                    //}

                    m_trasBE.ICOMPRA = 0;

                    m_trasBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                                                                          //m_trasBE.IID = "CAJA";


                    if ((m_trasD.AgregarM_TRASD(m_trasBE, strTableExpNameDet, odt, strOleDbConn) == null))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_trasD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }






        public bool exportarAFTP_TRASLADOSDEVOENVIOS(long lSucursalId, DateTime Fecha/*, long lTurnoId*/, int folio, bool bForzado, string strTableExpNameDet/*, string strTableExpNameHdr*/, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_TRASD m_trasD = new CM_TRASD();
            CM_TRASBE m_trasBE = new CM_TRASBE();

            CDOCTOD doctoD = new CDOCTOD();
            long doctoIdFinalAEnviar = 0; //en algunos casos se tiene que enviar los datos de la venta producida por el traslado en vez del traslado


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                doctoIdFinalAEnviar = doctoD.seleccionarDOCTOFINALAEnviarXFolio(folio, DBValues._DOCTO_TIPO_TRASPASO_REC, null);
                if (doctoIdFinalAEnviar <= 0)
                {
                    this.iComentario = "No se encontro el traslado";
                    return false;
                }


                parts = new ArrayList();

                //String CmdTxt = @"select d.*,p.pd_descripcion1 from DETALLE_DE_VENTAS d inner join productos p on d.pd_producto == p.pd_producto where DE_FECHA = @DE_FECHA and DE_EXPROTADO <> 'S'";
                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                'MN'  as MONEDA,
                                                DOCTO.VENDEDORID  VENDEDORID,
                                                MOVTO.FECHAVENCE,
                                                MOVTO.CANTIDADDEFACTURA,
                                                MOVTO.CANTIDADDEREMISION,
                                                MOVTO.CANTIDADDEINDEFINIDO,
                                                MOVTO.PRECIOVISIBLETRASLADO,
                                                SUCURSAL.PROVEEDORCLAVE,
                                                VENDEDOR.USERNAME CVEUSER,
                                                LOTESIMPORTADOS.PEDIMENTO IMP_PEDIMENTO,
                                                LOTESIMPORTADOS.FECHAIMPORTACION IMP_FECHAIMPORTACION,
                                                LOTESIMPORTADOS.ADUANA IMP_ADUANA,
                                                LOTESIMPORTADOS.TIPOCAMBIO IMP_TIPOCAMBIO,
                                                DOCTO.DOCTOIMPORTADOID
                    


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID LEFT JOIN
                                                    LOTESIMPORTADOS ON LOTESIMPORTADOS.ID = MOVTO.LOTEIMPORTADO
                                    WHERE DOCTO.ID = @DOCTOID AND COALESCE(CANTIDADFALTANTE,0) > 0
                                    ORDER BY DOCTOID, MOVTOID";

                // WHERE        DOCTO.FOLIO = @FOLIO and DOCTO.TIPODOCTOID = 31 AND DOCTO.ESTATUSDOCTOID = 1



                /* auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                 auxPar.Value = folio;
                 parts.Add(auxPar);*/

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoIdFinalAEnviar;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_trasBE = new CM_TRASBE();



                    if (dr["REFERENCIA"] != System.DBNull.Value)
                    {

                        m_trasBE.IVENTA = dr["REFERENCIA"].ToString();
                        m_trasBE.IID = dr["REFERENCIA"].ToString();
                    }

                    if (dr["DOCTOIMPORTADOID"] != System.DBNull.Value)
                    {

                        m_trasBE.IID = ((long)dr["DOCTOIMPORTADOID"]).ToString();
                    }



                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        m_trasBE.ICANTIDAD = Decimal.ToDouble((decimal)(dr["CANTIDADFALTANTE"]));
                        m_trasBE.IFALTANTE = Decimal.ToDouble((decimal)(dr["CANTIDADFALTANTE"]));
                    }



                    //if (dr["CANTIDADDEFACTURA"] != System.DBNull.Value)
                    //{
                    //    m_trasBE.ICANT_FAC = Decimal.ToDouble((decimal)(dr["CANTIDADDEFACTURA"]));
                    //}

                    //if (dr["CANTIDADDEREMISION"] != System.DBNull.Value)
                    //{
                    //    m_trasBE.ICANT_REM = Decimal.ToDouble((decimal)(dr["CANTIDADDEREMISION"]));
                    //}

                    //if (dr["CANTIDADDEINDEFINIDO"] != System.DBNull.Value)
                    //{
                    //    m_trasBE.ICANT_IND = Decimal.ToDouble((decimal)(dr["CANTIDADDEINDEFINIDO"]));
                    //}


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_trasBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        m_trasBE.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        m_trasBE.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        m_trasBE.IPROVEEDOR = (string)(dr["PROVEEDORCLAVE"]);
                    }



                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        m_trasBE.ICOSTO = Decimal.ToDouble((decimal)(dr["PRECIO"]));
                    }


                    //if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IPREC_LISTA = (decimal)(dr["PRECIOLISTA"]);
                    //}

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        m_trasBE.IFECHA = (DateTime)(dr["FECHA"]);
                        m_trasBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }


                    //if (dr["DESCRIPCION"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IDESC2 = dr["DESCRIPCION"].ToString();
                    //}


                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMPORTE = Decimal.ToDouble((decimal)(dr["IMPORTE"]));
                    }

                    if (dr["IMPORTENETO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMPORTNETO = Decimal.ToDouble((decimal)(dr["IMPORTENETO"]));
                    }


                    //if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    //}

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        m_trasBE.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    m_trasBE.IESTATUS = "P";


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        m_trasBE.ILOTE = (string)(dr["LOTE"]);
                    }


                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        m_trasBE.IF_CADUCA = (DateTime)(dr["FECHAVENCE"]);
                    }


                    if (dr["PRECIOVISIBLETRASLADO"] != System.DBNull.Value)
                    {
                        m_trasBE.IPRECREC = Decimal.ToDouble((decimal)(dr["PRECIOVISIBLETRASLADO"]));
                    }


                    if (dr["CVEUSER"] != System.DBNull.Value)
                    {
                        m_trasBE.ICVEUSER = dr["CVEUSER"].ToString();
                    }
                    else
                    {
                        m_trasBE.ICVEUSER = "";
                    }



                    if (dr["IMP_PEDIMENTO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_PED = dr["IMP_PEDIMENTO"].ToString();
                    }
                    else
                    {
                        m_trasBE.IIMP_PED = "";
                    }


                    if (dr["IMP_FECHAIMPORTACION"] != System.DBNull.Value)
                    {

                        m_trasBE.IIMP_FEC = (DateTime)(dr["IMP_FECHAIMPORTACION"]);
                    }



                    if (dr["IMP_ADUANA"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_ADU = dr["IMP_ADUANA"].ToString();
                    }
                    else
                    {
                        m_trasBE.IIMP_ADU = "";
                    }


                    if (dr["IMP_TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_TC = Decimal.ToDouble((decimal)(dr["IMP_TIPOCAMBIO"]));
                    }

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        m_trasBE.ISUCURSAL = (string)(dr["SUCURSAL"]);
                    }


                    //if (dr["VENDEDORID"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IVENDEDOR = dr["VENDEDORID"].ToString();
                    //}

                    m_trasBE.ICOMPRA = 0;

                    m_trasBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    //m_trasBE.IID = "CAJA";
                    if ((m_trasD.AgregarM_TRASD(m_trasBE, strTableExpNameDet, odt, strOleDbConn) == null))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_trasD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }







        public bool exportarAFTP_PEDIDOSDEVOENVIOS(long lSucursalId, DateTime Fecha/*, long lTurnoId*/, int folio, bool bForzado, string strTableExpNameDet/*, string strTableExpNameHdr*/, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_TRASD m_trasD = new CM_TRASD();
            CM_TRASBE m_trasBE = new CM_TRASBE();

            CDOCTOD doctoD = new CDOCTOD();
            long doctoIdFinalAEnviar = 0; //en algunos casos se tiene que enviar los datos de la venta producida por el traslado en vez del traslado


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                doctoIdFinalAEnviar = doctoD.seleccionarDOCTOFINALAEnviarXFolio(folio, DBValues._DOCTO_TIPO_COMPRA, null);
                if (doctoIdFinalAEnviar <= 0)
                {
                    this.iComentario = "No se encontro el traslado";
                    return false;
                }


                parts = new ArrayList();

                //String CmdTxt = @"select d.*,p.pd_descripcion1 from DETALLE_DE_VENTAS d inner join productos p on d.pd_producto == p.pd_producto where DE_FECHA = @DE_FECHA and DE_EXPROTADO <> 'S'";
                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                'MN'  as MONEDA,
                                                DOCTO.VENDEDORID  VENDEDORID,
                                                MOVTO.FECHAVENCE,
                                                MOVTO.CANTIDADDEFACTURA,
                                                MOVTO.CANTIDADDEREMISION,
                                                MOVTO.CANTIDADDEINDEFINIDO,
                                                MOVTO.PRECIOVISIBLETRASLADO,
                                                SUCURSAL.PROVEEDORCLAVE,
                                                VENDEDOR.USERNAME CVEUSER,
                                                LOTESIMPORTADOS.PEDIMENTO IMP_PEDIMENTO,
                                                LOTESIMPORTADOS.FECHAIMPORTACION IMP_FECHAIMPORTACION,
                                                coalesce(sat_aduana.sat_claveaduana || ' ' || sat_aduana.sat_descripcion, coalesce( lotesimportados.aduana, '')) IMP_ADUANA,
                                                LOTESIMPORTADOS.TIPOCAMBIO IMP_TIPOCAMBIO,
                                                DOCTO.DOCTOIMPORTADOID
                    


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID LEFT JOIN
                                                    LOTESIMPORTADOS ON LOTESIMPORTADOS.ID = MOVTO.LOTEIMPORTADO
                                                    Left join sat_aduana on lotesimportados.sataduanaid = sat_aduana.id
                                    WHERE DOCTO.ID = @DOCTOID AND COALESCE(CANTIDADFALTANTE,0) > 0
                                    ORDER BY DOCTOID, MOVTOID";

                // WHERE        DOCTO.FOLIO = @FOLIO and DOCTO.TIPODOCTOID = 31 AND DOCTO.ESTATUSDOCTOID = 1



                /* auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                 auxPar.Value = folio;
                 parts.Add(auxPar);*/

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoIdFinalAEnviar;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_trasBE = new CM_TRASBE();



                    if (dr["REFERENCIA"] != System.DBNull.Value)
                    {

                        m_trasBE.IVENTA = dr["REFERENCIA"].ToString();
                    }


                    if (dr["DOCTOIMPORTADOID"] != System.DBNull.Value)
                    {

                        m_trasBE.IID = ((long)dr["DOCTOIMPORTADOID"]).ToString();
                    }

                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        m_trasBE.ICANTIDAD = Decimal.ToDouble((decimal)(dr["CANTIDADFALTANTE"]));
                        m_trasBE.IFALTANTE = Decimal.ToDouble((decimal)(dr["CANTIDADFALTANTE"]));
                    }



                    //if (dr["CANTIDADDEFACTURA"] != System.DBNull.Value)
                    //{
                    //    m_trasBE.ICANT_FAC = Decimal.ToDouble((decimal)(dr["CANTIDADDEFACTURA"]));
                    //}

                    //if (dr["CANTIDADDEREMISION"] != System.DBNull.Value)
                    //{
                    //    m_trasBE.ICANT_REM = Decimal.ToDouble((decimal)(dr["CANTIDADDEREMISION"]));
                    //}

                    //if (dr["CANTIDADDEINDEFINIDO"] != System.DBNull.Value)
                    //{
                    //    m_trasBE.ICANT_IND = Decimal.ToDouble((decimal)(dr["CANTIDADDEINDEFINIDO"]));
                    //}


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_trasBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        m_trasBE.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        m_trasBE.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        m_trasBE.IPROVEEDOR = (string)(dr["PROVEEDORCLAVE"]);
                    }



                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        m_trasBE.ICOSTO = Decimal.ToDouble((decimal)(dr["PRECIO"]));
                    }


                    //if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IPREC_LISTA = (decimal)(dr["PRECIOLISTA"]);
                    //}

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        m_trasBE.IFECHA = (DateTime)(dr["FECHA"]);
                        m_trasBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }


                    //if (dr["DESCRIPCION"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IDESC2 = dr["DESCRIPCION"].ToString();
                    //}


                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMPORTE = Decimal.ToDouble((decimal)(dr["IMPORTE"]));
                    }

                    if (dr["IMPORTENETO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMPORTNETO = Decimal.ToDouble((decimal)(dr["IMPORTENETO"]));
                    }


                    //if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    //}

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        m_trasBE.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    m_trasBE.IESTATUS = "P";


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        m_trasBE.ILOTE = (string)(dr["LOTE"]);
                    }


                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        m_trasBE.IF_CADUCA = (DateTime)(dr["FECHAVENCE"]);
                    }


                    if (dr["PRECIOVISIBLETRASLADO"] != System.DBNull.Value)
                    {
                        m_trasBE.IPRECREC = Decimal.ToDouble((decimal)(dr["PRECIOVISIBLETRASLADO"]));
                    }


                    if (dr["CVEUSER"] != System.DBNull.Value)
                    {
                        m_trasBE.ICVEUSER = dr["CVEUSER"].ToString();
                    }
                    else
                    {
                        m_trasBE.ICVEUSER = "";
                    }



                    if (dr["IMP_PEDIMENTO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_PED = dr["IMP_PEDIMENTO"].ToString();
                    }
                    else
                    {
                        m_trasBE.IIMP_PED = "";
                    }


                    if (dr["IMP_FECHAIMPORTACION"] != System.DBNull.Value)
                    {

                        m_trasBE.IIMP_FEC = (DateTime)(dr["IMP_FECHAIMPORTACION"]);
                    }



                    if (dr["IMP_ADUANA"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_ADU = dr["IMP_ADUANA"].ToString();
                    }
                    else
                    {
                        m_trasBE.IIMP_ADU = "";
                    }


                    if (dr["IMP_TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        m_trasBE.IIMP_TC = Decimal.ToDouble((decimal)(dr["IMP_TIPOCAMBIO"]));
                    }


                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        m_trasBE.ISUCURSAL = (string)(dr["SUCURSAL"]);
                    }


                    //if (dr["VENDEDORID"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IVENDEDOR = dr["VENDEDORID"].ToString();
                    //}

                    m_trasBE.ICOMPRA = 0;

                    m_trasBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    //m_trasBE.IID = "CAJA";


                    if ((m_trasD.AgregarM_TRASD(m_trasBE, strTableExpNameDet, odt, strOleDbConn) == null))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_trasD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_EXISTENCIAS(long lSucursalId, string strTableExpName, FbTransaction st, OleDbTransaction odt, string strOleConn)
        {

            CEXP_EXISTD exp_existD = new CEXP_EXISTD();
            CEXP_EXISTBE exp_existBE = new CEXP_EXISTBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {
                parts = new ArrayList();

                CmdTxt = @"select inventario.productoid productoId,
                                  producto.clave CLAVE,
                                  sum(inventario.cantidad) CANTIDAD
                           from inventario
                            inner join producto on producto.id = inventario.productoid
                            group by inventario.productoid, producto.clave 
                            order by producto.clave";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    exp_existBE = new CEXP_EXISTBE();


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {

                        if (dr["CLAVE"].ToString() == "")
                            continue;

                        exp_existBE.ICLAVE = dr["CLAVE"].ToString();
                    }
                    else
                        continue;

                    exp_existBE.IFECHA = DateTime.Today;


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        exp_existBE.ICANTIDAD = Decimal.ToDouble((decimal)(dr["CANTIDAD"]));
                    }

                    exp_existBE.IHORA = DateTime.Now.ToString("HH:mm");

                    if (!(exp_existD.AgregarEXP_EXISTD(exp_existBE, strTableExpName, odt, strOleConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += exp_existD.IComentario + "\n";

                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }






        public bool exportarAFTP_RECEPCIONCOMPRAS(long lSucursalId, long doctoId, string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CRECEPCIOND m_recD = new CRECEPCIOND();
            CRECEPCIONBE m_recBE = new CRECEPCIONBE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADDEVUELTA,
                                                (MOVTO.CANTIDAD - MOVTO.CANTIDADSURTIDA) DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                'MN'  as MONEDA,
                                                DOCTO.VENDEDORID  VENDEDORID,
                                                MOVTO.FECHAVENCE, 
                                                DOCTO.REFERENCIAS REFERENCIAS, 
                                                DOCTO.FOLIO FOLIO


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid 
                                    WHERE        DOCTO.ID = @DOCTOID and DOCTO.TIPODOCTOID = 11 AND DOCTO.ESTATUSDOCTOID = 1
                                    ORDER BY DOCTOID, MOVTOID";



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_recBE = new CRECEPCIONBE();



                    if (dr["REFERENCIAS"] != System.DBNull.Value)
                    {
                        if (dr["REFERENCIAS"].ToString().Length > 1)
                            m_recBE.IVENTA = dr["REFERENCIAS"].ToString().Substring(1);
                        else
                            m_recBE.IVENTA = dr["REFERENCIAS"].ToString();
                    }


                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        m_recBE.ICOMPRA = (int)dr["FOLIO"];
                    }


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        m_recBE.ICANTIDAD = Decimal.ToDouble((decimal)(dr["CANTIDAD"]));
                    }


                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        m_recBE.ISURTIDA = Decimal.ToDouble((decimal)(dr["CANTIDADSURTIDA"]));
                    }

                    if (dr["DEVUELTAS"] != System.DBNull.Value)
                    {
                        m_recBE.IFALTANTE = Decimal.ToDouble((decimal)(dr["DEVUELTAS"]));
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_recBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        m_recBE.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        m_recBE.IMARCA = (string)(dr["MARCA"]);
                    }


                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        m_recBE.ICOSTO = Decimal.ToDouble((decimal)(dr["COSTO"]));
                    }


                    //if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IPREC_LISTA = (decimal)(dr["PRECIOLISTA"]);
                    //}

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        m_recBE.IFECHA = (DateTime)(dr["FECHA"]);
                        m_recBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }


                    //if (dr["DESCRIPCION"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IDESC2 = dr["DESCRIPCION"].ToString();
                    //}


                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        m_recBE.IIMPORTE = Decimal.ToDouble((decimal)(dr["IMPORTE"]));
                    }

                    if (dr["IMPORTENETO"] != System.DBNull.Value)
                    {
                        m_recBE.IIMPORTNETO = Decimal.ToDouble((decimal)(dr["IMPORTENETO"]));
                    }


                    //if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    //}

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        m_recBE.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    m_recBE.IESTATUS = "P";


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        m_recBE.ILOTE = (string)(dr["LOTE"]);
                    }


                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        m_recBE.IF_CADUCA = (DateTime)(dr["FECHAVENCE"]);
                    }


                    //if (dr["VENDEDORID"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IVENDEDOR = dr["VENDEDORID"].ToString();
                    //}


                    m_recBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    m_recBE.IID = "CAJA";
                    if ((!m_recD.AgregarRECEPCIOND(m_recBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_recD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }





        public bool exportarAFTP_ENVIOMATRIZPEDIDO(long lSucursalId, long doctoId, string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CPEDIDOENVIOD m_recD = new CPEDIDOENVIOD();
            CPEDIDOENVIOBE m_recBE = new CPEDIDOENVIOBE();


            CDOCTOD doctoD = new CDOCTOD();
            long doctoIdFinalAEnviar = 0; //en algunos casos se tiene que enviar los datos de la venta producida por el traslado en vez del traslado

            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                doctoIdFinalAEnviar = doctoD.seleccionarDOCTOFINALAEnviarXId(doctoId, DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA, st);
                if (doctoIdFinalAEnviar <= 0)
                {
                    this.iComentario = "No se encontro el surtimiento de pedido";
                    return false;
                }

                parts = new ArrayList();

                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADDEVUELTA,
                                                (MOVTO.CANTIDAD - MOVTO.CANTIDADSURTIDA) DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                'MN'  as MONEDA,
                                                DOCTO.VENDEDORID  VENDEDORID,
                                                MOVTO.FECHAVENCE, 
                                                DOCTO.REFERENCIAS REFERENCIAS, 
                                                DOCTO.FOLIO FOLIO,
                                                MOVTO.CANTIDADDEFACTURA,
                                                MOVTO.CANTIDADDEREMISION,
                                                MOVTO.CANTIDADDEINDEFINIDO,
                                                MOVTO.PRECIOVISIBLETRASLADO,
                                                SUCURSAL.PROVEEDORCLAVE,
                                                LOTESIMPORTADOS.PEDIMENTO IMP_PEDIMENTO,
                                                LOTESIMPORTADOS.FECHAIMPORTACION IMP_FECHAIMPORTACION,
                                                coalesce(sat_aduana.sat_claveaduana || ' ' || sat_aduana.sat_descripcion, coalesce( lotesimportados.aduana, '')) IMP_ADUANA,
                                                LOTESIMPORTADOS.TIPOCAMBIO IMP_TIPOCAMBIO


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    LOTESIMPORTADOS ON LOTESIMPORTADOS.ID = MOVTO.LOTEIMPORTADO
                                                    Left join sat_aduana on lotesimportados.sataduanaid = sat_aduana.id
                                    WHERE        DOCTO.ID = @DOCTOID 
                                    ORDER BY DOCTOID, MOVTOID";

                //and DOCTO.TIPODOCTOID = 81 AND DOCTO.ESTATUSDOCTOID = 1

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoIdFinalAEnviar; //doctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_recBE = new CPEDIDOENVIOBE();



                    /*if (dr["REFERENCIAS"] != System.DBNull.Value)
                    {
                        if (dr["REFERENCIAS"].ToString().Length > 1)
                            m_recBE.IVENTA = dr["REFERENCIAS"].ToString().Substring(1);
                        else
                            m_recBE.IVENTA = dr["REFERENCIAS"].ToString();
                    }*/


                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        m_recBE.IVENTA = "V" + ((int)dr["FOLIO"]).ToString("N0").PadLeft(7, '0');

                    }


                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {

                        m_recBE.IID = dr["DOCTOID"].ToString();
                    }



                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        m_recBE.ICANTIDAD = Decimal.ToDouble((decimal)(dr["CANTIDAD"]));
                    }


                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        m_recBE.ISURTIDA = Decimal.ToDouble((decimal)(dr["CANTIDADSURTIDA"]));
                    }

                    if (dr["DEVUELTAS"] != System.DBNull.Value)
                    {
                        m_recBE.IFALTANTE = Decimal.ToDouble((decimal)(dr["DEVUELTAS"]));
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_recBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        m_recBE.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        m_recBE.IMARCA = (string)(dr["MARCA"]);
                    }


                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        m_recBE.IPROVEEDOR = (string)(dr["PROVEEDORCLAVE"]);
                    }


                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        m_recBE.ICOSTO = Decimal.ToDouble((decimal)(dr["COSTO"]));
                    }


                    //if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IPREC_LISTA = (decimal)(dr["PRECIOLISTA"]);
                    //}

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        m_recBE.IFECHA = (DateTime)(dr["FECHA"]);
                        m_recBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }


                    //if (dr["DESCRIPCION"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IDESC2 = dr["DESCRIPCION"].ToString();
                    //}


                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        m_recBE.IIMPORTE = Decimal.ToDouble((decimal)(dr["IMPORTE"]));
                    }

                    if (dr["IMPORTENETO"] != System.DBNull.Value)
                    {
                        m_recBE.IIMPORTNETO = Decimal.ToDouble((decimal)(dr["IMPORTENETO"]));
                    }


                    //if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    //}

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        m_recBE.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    m_recBE.IESTATUS = "P";


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        m_recBE.ILOTE = (string)(dr["LOTE"]);
                    }


                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        m_recBE.IF_CADUCA = (DateTime)(dr["FECHAVENCE"]);
                    }


                    //if (dr["VENDEDORID"] != System.DBNull.Value)
                    //{
                    //    vedmBE.IVENDEDOR = dr["VENDEDORID"].ToString();
                    //}



                    if (dr["CANTIDADDEFACTURA"] != System.DBNull.Value)
                    {
                        m_recBE.ICANT_FAC = Decimal.ToDouble((decimal)(dr["CANTIDADDEFACTURA"]));
                    }

                    if (dr["CANTIDADDEREMISION"] != System.DBNull.Value)
                    {
                        m_recBE.ICANT_REM = Decimal.ToDouble((decimal)(dr["CANTIDADDEREMISION"]));
                    }
                    if (dr["CANTIDADDEINDEFINIDO"] != System.DBNull.Value)
                    {
                        m_recBE.ICANT_IND = Decimal.ToDouble((decimal)(dr["CANTIDADDEINDEFINIDO"]));
                    }


                    if (dr["PRECIOVISIBLETRASLADO"] != System.DBNull.Value)
                    {
                        m_recBE.IPRECREC = Decimal.ToDouble((decimal)(dr["PRECIOVISIBLETRASLADO"]));
                    }



                    if (dr["IMP_PEDIMENTO"] != System.DBNull.Value)
                    {
                        m_recBE.IIMP_PED = dr["IMP_PEDIMENTO"].ToString();
                    }
                    else
                    {
                        m_recBE.IIMP_PED = "";
                    }


                    if (dr["IMP_FECHAIMPORTACION"] != System.DBNull.Value)
                    {

                        m_recBE.IIMP_FEC = (DateTime)(dr["IMP_FECHAIMPORTACION"]);
                    }



                    if (dr["IMP_ADUANA"] != System.DBNull.Value)
                    {
                        m_recBE.IIMP_ADU = dr["IMP_ADUANA"].ToString();
                    }
                    else
                    {
                        m_recBE.IIMP_ADU = "";
                    }


                    if (dr["IMP_TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        m_recBE.IIMP_TC = Decimal.ToDouble((decimal)(dr["IMP_TIPOCAMBIO"]));
                    }

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        m_recBE.ISUCURSAL = (string)(dr["SUCURSAL"]);
                    }


                    m_recBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    //m_recBE.IID = "CAJA";




                    if ((!m_recD.AgregarPEDIDOENVIOD(m_recBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_recD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        //        public bool exportarAFTP_MatrizProducto(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        //        {

        //            CPRODUCTOBE fbItem = new CPRODUCTOBE();
        //            bool retorno = true;
        //            this.iComentario = "";
        //            FbParameter auxPar;
        //            System.Collections.ArrayList parts;
        //            String CmdTxt;
        //            FbParameter[] arParms;
        //            /**/FbDataReader dr = null;
        //            FbConnection pcn = null;

        //            DataSet ds;

        //            try
        //            {
        //                parts = new ArrayList();

        //                CmdTxt = @"SELECT PRODUCTO.*, LINEA.CLAVE AS CLAVELINEA, MARCA.CLAVE AS CLAVEMARCA, MONEDA.CLAVE AS CLAVEMONEDA,
        //                                  PROV1.CLAVE CLAVEPROVEEDOR1, PROV2.CLAVE CLAVEPROVEEDOR2,
        //                                  TASAIVA.CLAVE CLAVETASAIVA, TASAIVA.TASA TASAIVA
        //                                
        //                           from PRODUCTO left join LINEA ON PRODUCTO.LINEAID = LINEA.ID 
        //                                         LEFT JOIN MARCA ON PRODUCTO.MARCAID = MARCA.ID 
        //                                         LEFT JOIN MONEDA ON PRODUCTO.MONEDAID = MONEDA.ID
        //                                         LEFT JOIN PERSONA PROV1 ON PRODUCTO.PROVEEDOR1ID = PROV1.ID
        //                                         LEFT JOIN PERSONA PROV2 ON PRODUCTO.PROVEEDOR2ID = PROV2.ID
        //                                         LEFT JOIN TASAIVA ON TASAIVA.ID = PRODUCTO.TASAIVAID";

        //                arParms = new FbParameter[parts.Count];
        //                parts.CopyTo(arParms, 0);

        //                if (st == null)
        //                    ds = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
        //                else
        //                    ds = SqlHelper.ExecuteDataset(st, CommandType.Text, CmdTxt, arParms);

        //                return true;
        //            }
        //            catch (Exception e)
        //            {
        //                this.iComentario = e.Message + e.StackTrace;
        //                return false;
        //            }
        //        }



        public bool exportarAFTP_MatrizPROD(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CPRODUCTOBE fbItem = new CPRODUCTOBE();

            CPRODD m_dbfD = new CPRODD();
            CPRODBE m_dbfBE = new CPRODBE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT  PRODUCTO.ID,
                         PRODUCTO.CLAVE, PRODUCTO.NOMBRE, PRODUCTO.DESCRIPCION, PRODUCTO.EAN, PRODUCTO.DESCRIPCION1, PRODUCTO.DESCRIPCION2, 
                         PRODUCTO.DESCRIPCION3, PRODUCTO.PRECIO1, 
                         PRODUCTO.PRECIO2, PRODUCTO.PRECIO3, PRODUCTO.PRECIO4, PRODUCTO.PRECIO5, 
                         COALESCE(PRODUCTO.SPRECIO1,0) SPRECIO1, COALESCE(PRODUCTO.SPRECIO2,0) SPRECIO2, COALESCE(PRODUCTO.SPRECIO3,0) SPRECIO3, COALESCE(PRODUCTO.SPRECIO4,0) SPRECIO4, COALESCE(PRODUCTO.SPRECIO5,0) SPRECIO5, 
                         COALESCE(PRODUCTO.PORCUTILPRECIO1,0) PORCUTILPRECIO1, COALESCE(PRODUCTO.PORCUTILPRECIO2,0) PORCUTILPRECIO2, COALESCE(PRODUCTO.PORCUTILPRECIO3,0) PORCUTILPRECIO3, COALESCE(PRODUCTO.PORCUTILPRECIO4,0) PORCUTILPRECIO4, COALESCE(PRODUCTO.PORCUTILPRECIO5,0) PORCUTILPRECIO5, 
                         PRODUCTO.COSTOREPOSICION, PRODUCTO.COSTOULTIMO, PRODUCTO.COSTOPROMEDIO, PRODUCTO.PRODUCTOSUSTITUTOID, PRODUCTO.MANEJALOTE, 
                         PRODUCTO.ESKIT, PRODUCTO.IMPRIMIR, PRODUCTO.INVENTARIABLE, PRODUCTO.NEGATIVOS, PRODUCTO.LIMITEPRECIO2, 
                         PRODUCTO.PRECIOMAXIMOPUBLICO, PRODUCTO.FECHACAMBIOPRECIO, PRODUCTO.MANEJASTOCK, PRODUCTO.STOCK, PRODUCTO.CAMBIARPRECIO, 
                         PRODUCTO.COMPRAENTIENDA, PRODUCTO.EXISTENCIA, PRODUCTO.SUBSTITUTO, PRODUCTO.CBARRAS, PRODUCTO.CEMPAQUE, PRODUCTO.PZACAJA, 
                         PRODUCTO.U_EMPAQUE, PRODUCTO.UNIDAD, PRODUCTO.INI_MAYO, PRODUCTO.MAYOKGS, PRODUCTO.TIPOABC, PRODUCTO.COMISION, PRODUCTO.OFERTA, 
                         PRODUCTO.EXISTENCIAFACTURADO, PRODUCTO.EXISTENCIAREMISIONADO, PRODUCTO.EXISTENCIAINDEFINIDO, PRODUCTO.ESPRODUCTOFINAL, 
                         PRODUCTO.ESPRODUCTOPADRE, PRODUCTO.ESSUBPRODUCTO, PRODUCTO.TOMARPRECIOPADRE, PRODUCTO.TOMARCOMISIONPADRE, 
                         PRODUCTO.TOMAROFERTAPADRE, PRODUCTO.PRODUCTOPADRE, PRODUCTO.EXISTENCIAFACTURADOAPARTADO, 
                         PRODUCTO.EXISTENCIAREMISIONADOAPARTADO, PRODUCTO.EXISTENCIAINDEFINIDOAPARTADO, PRODUCTO.EXISTENCIAAPARTADO, 
                         PRODUCTO.ULTIMOORIGENFISCALVENTA, PRODUCTO.EXIST_FAC_INTERCAMBIO, PRODUCTO.EXIST_REM_INTERCAMBIO, LINEA.CLAVE AS CLAVELINEA, 
                         MARCA.CLAVE AS CLAVEMARCA, MONEDA.CLAVE AS CLAVEMONEDA, PROV1.CLAVE AS CLAVEPROVEEDOR1, PROV2.CLAVE AS CLAVEPROVEEDOR2, 
                         TASAIVA.CLAVE AS CLAVETASAIVA, TASAIVA.TASA AS TASAIVA, PRODUCTOPADRE.CLAVE AS CLAVEPRODUCTOPADRE,
                         CR.TEXTO1,CR.TEXTO2,CR.TEXTO3,CR.TEXTO4,CR.TEXTO5,CR.TEXTO6,
                         CR.FECHA1,CR.FECHA2,
                         CR.NUMERO1,CR.NUMERO2,CR.NUMERO3,CR.NUMERO4,
                         PRODUCTOSUBSTITUTO.CLAVE AS CLAVEPRODUCTOSUBSTITUTO,PRODUCTO.PLUG, PRODUCTO.TASAIEPS, PRODUCTO.MINUTILIDAD
                         , PRODUCTO.REQUIERERECETA, PRODUCTO.PRECIOTOPE,
                         PRODUCTO.PRECIOSUGERIDO, PRODUCTO.PRECIOMAT, CONTENIDO.CLAVE CLAVE_CONTENIDO, CLASIFICA.CLAVE CLAVE_CLASIFICA, PRODUCTO.MENUDEO, PRODUCTO.CONTENIDOVALOR, PRODUCTO.UNIDAD2, PRODUCTO.CANTXPIEZA,
                         PRODUCTO.MANEJALOTEIMPORTADO, PRODUCTO.COSTOENDOLAR, PLAZO.CLAVE PLAZOCLAVE,
                         SAT_PRODUCTOSERVICIO.SAT_CLAVEPRODSERV,
                         BASEPRODPROMO.CLAVE CLAVEBASEPRODPROMO, PRODUCTO.ESPRODPROMO, PRODUCTO.VIGENCIAPRODPROMO, PRODUCTO.CAMBIOPARAMOVIL, PRODUCTO.VIGENCIAPRODPROMO, PRODUCTO.VIGENCIAPRODKIT, PRODUCTO.KITTIENEVIG, PRODUCTO.VALXSUC,
                         PRODUCTO.KITIMPFIJO, PRODUCTO.IMPRIMIRCOMANDA,
                         PRODUCTO.LISTAPRECMEDIOMAYID, PRODUCTO.LISTAPRECMAYOREOID, PRODUCTO.CANTMEDIOMAY , PRODUCTO.CANTMAYOREO,
                         PRODUCTO.SAT_TIPOEMBALAJEID, SAT_TIPOEMBALAJE.CLAVE SAT_TIPOEMBALAJE_CLAVE, PRODUCTO.SAT_CLAVEUNIDADPESOID, SAT_CLAVEUNIDADPESO.CLAVE SAT_CLAVEUNIDADPESO_CLAVE,
                         PRODUCTO.PESO, PRODUCTO.ESPELIGROSO, PRODUCTO.SAT_MATPELIGROSOID, SAT_MATPELIGROSO.CLAVE SAT_MATPELIGROSO_CLAVE, PRODUCTO.ESOFERTA

                FROM            PRODUCTO LEFT OUTER JOIN
                         LINEA ON PRODUCTO.LINEAID = LINEA.ID LEFT OUTER JOIN
                         MARCA ON PRODUCTO.MARCAID = MARCA.ID LEFT OUTER JOIN
                         MONEDA ON PRODUCTO.MONEDAID = MONEDA.ID LEFT OUTER JOIN
                         PERSONA PROV1 ON PRODUCTO.PROVEEDOR1ID = PROV1.ID LEFT OUTER JOIN
                         PERSONA PROV2 ON PRODUCTO.PROVEEDOR2ID = PROV2.ID LEFT OUTER JOIN
                         TASAIVA ON TASAIVA.ID = PRODUCTO.TASAIVAID LEFT OUTER JOIN
                         PRODUCTO PRODUCTOPADRE ON PRODUCTO.PRODUCTOPADRE = PRODUCTOPADRE.ID LEFT OUTER JOIN
                         PRODUCTOCARACTERISTICAS CR ON PRODUCTO.ID = CR.PRODUCTOID LEFT OUTER JOIN
                         PRODUCTO PRODUCTOSUBSTITUTO ON PRODUCTO.PRODUCTOSUSTITUTOID = PRODUCTOSUBSTITUTO.ID LEFT OUTER JOIN
                         CONTENIDO ON PRODUCTO.CONTENIDOID = CONTENIDO.ID LEFT OUTER JOIN
                         CLASIFICA ON PRODUCTO.CLASIFICAID = CLASIFICA.ID LEFT OUTER JOIN
                         PLAZO ON PLAZO.ID = PRODUCTO.PLAZOID LEFT OUTER JOIN
                         SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.ID = PRODUCTO.SAT_PRODUCTOSERVICIOID LEFT OUTER JOIN 
                         PRODUCTO BASEPRODPROMO ON BASEPRODPROMO.ID = PRODUCTO.BASEPRODPROMOID LEFT OUTER JOIN 
                         SAT_TIPOEMBALAJE  ON SAT_TIPOEMBALAJE.ID = PRODUCTO.SAT_TIPOEMBALAJEID LEFT OUTER JOIN 
                         SAT_CLAVEUNIDADPESO  ON SAT_CLAVEUNIDADPESO.ID = PRODUCTO.SAT_CLAVEUNIDADPESOID LEFT OUTER JOIN 
                         SAT_MATPELIGROSO  ON SAT_MATPELIGROSO.ID = PRODUCTO.SAT_MATPELIGROSOID
          ";


                if (doctoId != 0)
                {
                    string strJoinAdicional = @" WHERE PRODUCTO.ID IN  ( SELECT PRODUCTOFINAL.ID AS PRODUCTOID FROM PRODUCTO PRODUCTOFINAL 
                                         INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                         WHERE MOVTOFINAL.DOCTOID = @DOCTOID AND PRODUCTO.CLAVE NOT LIKE 'EMIDA-%' AND (PRODUCTO.EMIDAPRODUCTOID IS NULL OR PRODUCTO.EMIDAPRODUCTOID = 0)
                           UNION
                           SELECT PRODUCTOPADRE.PRODUCTOPADRE AS PRODUCTOID FROM PRODUCTO PRODUCTOPADRE 
                                         INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                         WHERE MOVTOPADRE.DOCTOID = @DOCTOID
                         )
                        order by PRODUCTO.ID";
                    CmdTxt += strJoinAdicional;
                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Value = doctoId;
                    parts.Add(auxPar);
                }
                else
                {

                    CmdTxt += " WHERE PRODUCTO.CLAVE NOT LIKE 'EMIDA-%' AND (PRODUCTO.EMIDAPRODUCTOID IS NULL OR PRODUCTO.EMIDAPRODUCTOID = 0) ";
                }


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CPRODBE();

                    /*if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMPRA = (int)dr["FOLIO"];
                    }*/



                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["CLAVE"]);

                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((bool)m_dbfBE.isnull["IPRODUCTO"] || m_dbfBE.IPRODUCTO.Trim() == "")
                        continue;


                    try
                    {
                        if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                        {
                            m_dbfBE.IFCAMBIO = (DateTime)dr["FECHACAMBIOPRECIO"];
                        }
                        else
                        {
                            m_dbfBE.IFCAMBIO = DateTime.Now;
                        }
                    }
                    catch
                    {
                        m_dbfBE.IFCAMBIO = DateTime.Now;
                    }



                    try
                    {
                        DateTime fechaCambioMovil = DateTime.Parse("01.01.2000");
                        if (dr["CAMBIOPARAMOVIL"] != System.DBNull.Value)
                        {
                            fechaCambioMovil = (DateTime)dr["CAMBIOPARAMOVIL"];
                        }


                        m_dbfBE.IID_HORA = String.Format("{0:HH:mm:ss}", fechaCambioMovil);
                        m_dbfBE.IID_FECHA = fechaCambioMovil.Date;
                    }
                    catch
                    {
                        m_dbfBE.IID_HORA = String.Format("{0:HH:mm:ss}", DateTime.MinValue);
                        m_dbfBE.IID_FECHA = DateTime.Parse("01.01.2000");
                    }



                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC = (string)(dr["DESCRIPCION"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC3 = (string)(dr["DESCRIPCION3"]);
                    }
                    if (dr["CLAVELINEA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILINEA = (string)(dr["CLAVELINEA"]);
                    }
                    if (dr["CLAVEMARCA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMARCA = (string)(dr["CLAVEMARCA"]);
                    }



                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO1 = Decimal.ToDouble((decimal)(dr["PRECIO1"]));
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO2 = Decimal.ToDouble((decimal)(dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO3 = Decimal.ToDouble((decimal)(dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO4 = Decimal.ToDouble((decimal)(dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO5 = Decimal.ToDouble((decimal)(dr["PRECIO5"]));
                    }
                    if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO6 = Decimal.ToDouble((decimal)(dr["PRECIOSUGERIDO"]));
                    }

                    if (dr["PRECIOTOPE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECTOPE = Decimal.ToDouble((decimal)(dr["PRECIOTOPE"]));
                    }



                    if (dr["CLAVEMONEDA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMONEDA = (string)(dr["CLAVEMONEDA"]);
                    }



                    if (dr["CLAVETASAIVA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICVETASAIVA = (string)(dr["CLAVETASAIVA"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPUESTO = Decimal.ToDouble((decimal)(dr["TASAIVA"]));
                    }
                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOSTOREPUS = Decimal.ToDouble((decimal)(dr["COSTOREPOSICION"]));
                        m_dbfBE.ICOSTO_REPO = Decimal.ToDouble((decimal)(dr["COSTOREPOSICION"]));
                    }
                    //if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICOSTOULTUS = Decimal.ToDouble((decimal)(dr["COSTOULTIMO"]));
                    //}



                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICODIGO = (string)(dr["EAN"]);
                    }


                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILOTE = (string)(dr["MANEJALOTE"]);
                    }
                    else
                    {
                        m_dbfBE.ILOTE = "N";
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        m_dbfBE.IKIT = (string)(dr["ESKIT"]);
                    }


                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }
                    else
                    {
                        m_dbfBE.IIMPRIMIR = "N";
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IINVENTARIO = (string)(dr["INVENTARIABLE"]);

                    }
                    else
                    {
                        m_dbfBE.IINVENTARIO = "N";
                    }


                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        m_dbfBE.INEGATIVOS = (string)dr["NEGATIVOS"];
                    }
                    else
                    {
                        m_dbfBE.INEGATIVOS = "N";
                    }
                    //m_dbfBE.INEGATIVOS = "S";




                    if (dr["CLAVEPRODUCTOSUBSTITUTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUSTITUTO = (string)(dr["CLAVEPRODUCTOSUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICBARRAS = (string)(dr["CBARRAS"]);
                    }


                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
                    }


                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPZACAJA = Decimal.ToDouble((decimal)(dr["PZACAJA"]));
                    }


                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IU_EMPAQUE = Decimal.ToDouble((decimal)(dr["U_EMPAQUE"]));
                    }


                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IUNIDAD = (string)(dr["UNIDAD"]);
                    }


                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IINIMAYO = Decimal.ToDouble((decimal)(dr["INI_MAYO"]));
                    }


                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMAYOXKG = (string)(dr["MAYOKGS"]);
                    }
                    else
                    {
                        m_dbfBE.IMAYOXKG = "N";
                    }



                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITIPOABC = (string)(dr["TIPOABC"]);
                    }
                    else
                    {
                        m_dbfBE.ITIPOABC = "N";
                    }




                    if (dr["CLAVEPROVEEDOR1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR = (string)(dr["CLAVEPROVEEDOR1"]);
                    }


                    if (dr["CLAVEPROVEEDOR2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR2 = (string)(dr["CLAVEPROVEEDOR2"]);
                    }


                    if (dr["CLAVEPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODPADRE = (string)(dr["CLAVEPRODUCTOPADRE"]);
                    }



                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILIMITE2 = Decimal.ToDouble((decimal)(dr["LIMITEPRECIO2"]));
                    }


                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }
                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }
                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }
                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }
                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }
                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO6 = (string)(dr["TEXTO6"]);
                    }



                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO1 = Decimal.ToDouble((decimal)(dr["NUMERO1"]));
                    }
                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO2 = Decimal.ToDouble((decimal)(dr["NUMERO2"]));
                    }
                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO3 = Decimal.ToDouble((decimal)(dr["NUMERO3"]));
                    }
                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO4 = Decimal.ToDouble((decimal)(dr["NUMERO4"]));
                    }



                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }
                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }




                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }


                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }


                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESSUBPROD = (string)(dr["ESSUBPRODUCTO"]);
                    }


                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }



                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMIPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }


                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IOFEPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }


                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMISION = Decimal.ToDouble((decimal)(dr["COMISION"]));
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IOFERTA = Decimal.ToDouble((decimal)(dr["OFERTA"]));
                    }



                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICAMBIARPRE = (string)(dr["CAMBIARPRECIO"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPLUG = (string)(dr["PLUG"]);
                    }

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITASAIEPS = Decimal.ToDouble((decimal)(dr["TASAIEPS"]));
                    }


                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMINUTIL = Decimal.ToDouble((decimal)(dr["MINUTILIDAD"]));
                    }

                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO1 = Decimal.ToDouble((decimal)(dr["SPRECIO1"]));
                    }
                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO2 = Decimal.ToDouble((decimal)(dr["SPRECIO2"]));
                    }
                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO3 = Decimal.ToDouble((decimal)(dr["SPRECIO3"]));
                    }
                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO4 = Decimal.ToDouble((decimal)(dr["SPRECIO4"]));
                    }
                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO5 = Decimal.ToDouble((decimal)(dr["SPRECIO5"]));
                    }


                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRRECETA = (string)(dr["REQUIERERECETA"]);
                    }



                    if (dr["PRECIOMAT"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    }




                    if (dr["MENUDEO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMENUDEO = Decimal.ToInt32((decimal)(dr["MENUDEO"]));
                    }


                    if (dr["CLAVE_CONTENIDO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE_CONT = (string)(dr["CLAVE_CONTENIDO"]);
                    }


                    if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICONTENIDO = Decimal.ToDouble((decimal)(dr["CONTENIDOVALOR"]));
                    }


                    if (dr["CLAVE_CLASIFICA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLASIFICA = (string)(dr["CLAVE_CLASIFICA"]);
                    }


                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }


                    if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICANTXPIEZA = Decimal.ToDouble((decimal)(dr["CANTXPIEZA"]));
                    }




                    if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILOTEIMPO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    }

                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOSTOUSD = Decimal.ToDouble((decimal)(dr["COSTOENDOLAR"]));
                    }



                    if (dr["PLAZOCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPLAZO = (string)(dr["PLAZOCLAVE"]);
                    }

                    if (dr["SAT_CLAVEPRODSERV"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVESAT = dr["SAT_CLAVEPRODSERV"].ToString();
                    }



                    if (dr["CLAVEBASEPRODPROMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IBASEPROM = dr["CLAVEBASEPRODPROMO"].ToString();
                    }


                    if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESPRODPROM = dr["ESPRODPROMO"].ToString();
                    }


                    if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIGPROM = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    }

                    if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIGKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    }

                    if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    {
                        m_dbfBE.IKITCVIG = (string)(dr["KITTIENEVIG"]);
                    }

                    if (dr["VALXSUC"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVALXSUC = (string)(dr["VALXSUC"]);
                    }


                    if (dr["KITIMPFIJO"] != System.DBNull.Value)
                    {
                        string strKitImpFijo = (string)dr["KITIMPFIJO"];
                        m_dbfBE.IDESGKIT = strKitImpFijo != null && strKitImpFijo.Equals("S") ? false : true;
                    }



                    if (dr["PORCUTILPRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO1 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO1"]));
                    }
                    if (dr["PORCUTILPRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO2 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO2"]));
                    }
                    if (dr["PORCUTILPRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO3 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO3"]));
                    }
                    if (dr["PORCUTILPRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO4 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO4"]));
                    }
                    if (dr["PORCUTILPRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO5 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO5"]));
                    }


                    if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPCOM = (string)(dr["IMPRIMIRCOMANDA"]);
                    }

                    if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILMEDMAY = int.Parse(dr["LISTAPRECMEDIOMAYID"].ToString());
                    }

                    if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILMAYO = int.Parse(dr["LISTAPRECMAYOREOID"].ToString());
                    }

                    if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICMEDMAY = Decimal.ToDouble((decimal)(dr["CANTMEDIOMAY"]));
                    }

                    if (dr["CANTMAYOREO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICMAYO = Decimal.ToDouble((decimal)(dr["CANTMAYOREO"]));
                    }


                    if (dr["SAT_TIPOEMBALAJE_CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITIPOEMB = (string)(dr["SAT_TIPOEMBALAJE_CLAVE"]);
                    }

                    if (dr["SAT_CLAVEUNIDADPESO_CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICVEUPESO = (string)(dr["SAT_CLAVEUNIDADPESO_CLAVE"]);
                    }

                    if (dr["ESPELIGROSO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESPELIG = (string)(dr["ESPELIGROSO"]);
                    }

                    if (dr["PESO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPESO = Decimal.ToDouble((decimal)(dr["PESO"]));
                    }

                    if (dr["SAT_MATPELIGROSO_CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMATPELI = (string)(dr["SAT_MATPELIGROSO_CLAVE"]);
                    }

                    if (dr["ESOFERTA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESOFERTA = (string)(dr["ESOFERTA"]);
                    }

                    if ((!m_dbfD.AgregarPRODD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                CPRODUCTOD prodD = new CPRODUCTOD();
                prodD.PRODUCTOPRECIOSMATRIZ(st);

                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

        public bool exportarAFTP_MatrizMARC(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CMARCABE fbItem = new CMARCABE();

            CM_MARCD m_dbfD = new CM_MARCD();
            CM_MARCBE m_dbfBE = new CM_MARCBE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from MARCA";


                if (doctoId != 0)
                {

                    CmdTxt = @"SELECT MARCA.* from MARCA WHERE MARCA.ID IN
                                         (  SELECT MARCA.ID FROM PRODUCTO PRODUCTOFINAL
                                            INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                            INNER JOIN MARCA ON MARCA.ID = PRODUCTOFINAL.MARCAID
                                            WHERE MOVTOFINAL.DOCTOID = @DOCTOID
                                            UNION
                                            SELECT MARCA.ID FROM PRODUCTO PRODUCTOPADRE
                                            INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID 
                                            INNER JOIN MARCA ON MARCA.ID = PRODUCTOPADRE.MARCAID
                                            WHERE MOVTOPADRE.DOCTOID = @DOCTOID
                                        )  ";

                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Value = doctoId;
                    parts.Add(auxPar);
                }


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_MARCBE();


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMARCA = (string)(dr["CLAVE"]);
                    }



                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCONTINUADO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESCONTI = (string)(dr["DESCONTINUADO"]);
                    }
                    else
                    {
                        m_dbfBE.IDESCONTI = "N";
                    }



                    if ((!m_dbfD.AgregarM_MARCD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizLINE(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_LINEBE fbItem = new CM_LINEBE();

            CM_LINED m_dbfD = new CM_LINED();
            CM_LINEBE m_dbfBE = new CM_LINEBE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from LINEA";


                if (doctoId != 0)
                {

                    CmdTxt = @"SELECT LINEA.* from LINEA WHERE LINEA.ID IN  (  SELECT LINEA.ID FROM PRODUCTO PRODUCTOFINAL
                                            INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                            INNER JOIN LINEA ON LINEA.ID = PRODUCTOFINAL.LINEAID
                                            WHERE MOVTOFINAL.DOCTOID = @DOCTOID
                                            UNION
                                            SELECT LINEA.ID FROM PRODUCTO PRODUCTOPADRE
                                            INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                            INNER JOIN LINEA ON LINEA.ID = PRODUCTOPADRE.LINEAID
                                            WHERE MOVTOPADRE.DOCTOID = @DOCTOID
                                        )  ";

                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Value = doctoId;
                    parts.Add(auxPar);
                }

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_LINEBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILINEA = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["TIPORECARGA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITRECARGA = (string)(dr["TIPORECARGA"]);
                    }

                    if (dr["APLICAMAYOREOXLINEA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IAPLIMAYO = (string)(dr["APLICAMAYOREOXLINEA"]);
                    }


                    if (dr["GPOIMP"] != System.DBNull.Value)
                    {
                        m_dbfBE.IGPOIMP = (string)(dr["GPOIMP"]);
                    }

                    if ((!m_dbfD.AgregarM_LINED(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

        public bool exportarAFTP_MatrizAREA(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_AREABE fbItem = new CM_AREABE();

            CM_AREAD m_dbfD = new CM_AREAD();
            CM_AREABE m_dbfBE = new CM_AREABE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from AREA";



                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_AREABE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IAREA = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBREAREA"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBREAREA"]);
                    }



                    if ((!m_dbfD.AgregarM_AREAD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }







        public bool exportarAFTP_MatrizARDR(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_ARDRBE fbItem = new CM_ARDRBE();

            CM_ARDRD m_dbfD = new CM_ARDRD();
            CM_ARDRBE m_dbfBE = new CM_ARDRBE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT AREA.CLAVE, AREADERECHOS.IDDERECHO from AREADERECHOS INNER JOIN AREA ON AREADERECHOS.IDAREA = AREA.ID";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_ARDRBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IAREA = (string)(dr["CLAVE"]);
                    }


                    if (dr["IDDERECHO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDERECHO = long.Parse(dr["IDDERECHO"].ToString());
                    }



                    if ((!m_dbfD.AgregarM_ARDRD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizTASA(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_TASABE fbItem = new CM_TASABE();

            CM_TASAD m_dbfD = new CM_TASAD();
            CM_TASABE m_dbfBE = new CM_TASABE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from TASAIVA";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_TASABE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITASA = Decimal.ToDouble((decimal)(dr["TASA"]));
                    }

                    if (dr["FECHAINICIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHAINI = (DateTime)(dr["FECHAINICIA"]);
                    }

                    if ((!m_dbfD.AgregarM_TASAD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarAFTP_MatrizESTADO(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn, string version = "DBF")
        {
            CM_EDOSBE fbItem = new CM_EDOSBE();

            //CM_EDOSD m_dbfD = new CM_EDOSD();
            IMEDOSD m_dbfD = null;
            CM_EDOSBE m_dbfBE = new CM_EDOSBE();

            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMEDOS_SQLITE_D();
                ((CMEDOS_SQLITE_D)m_dbfD).CreateTableMEDOS_MOVIL(strOleDbConn);

            }
            else
                m_dbfD = new CM_EDOSD();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from ESTADO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_EDOSBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((!m_dbfD.AgregarM_EDOSD(m_dbfBE, strTableExpNameDet, 
                        //odt, 
                        strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }





        public bool exportarAFTP_MatrizUNIDAD(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_UNIBE fbItem = new CM_UNIBE();

            CM_UNID m_dbfD = new CM_UNID();
            CM_UNIBE m_dbfBE = new CM_UNIBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from UNIDAD";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_UNIBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if (dr["CANTIDADDECIMALES"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICANTDEC = decimal.Parse(((short)(dr["CANTIDADDECIMALES"])).ToString());
                    }

                    if (dr["SAT_UNIDADMEDIDAID"] != System.DBNull.Value)
                    {
                        CSAT_UNIDADMEDIDABE auxUnd = new CSAT_UNIDADMEDIDABE();
                        CSAT_UNIDADMEDIDAD daoAuxUnd = new CSAT_UNIDADMEDIDAD();
                        auxUnd.IID = (long)(dr["SAT_UNIDADMEDIDAID"]);
                        auxUnd = daoAuxUnd.seleccionarSAT_UNIDADMEDIDA(auxUnd, null);
                        if (auxUnd != null)
                        {
                            m_dbfBE.ICLAVESAT = auxUnd.ISAT_CLAVE;
                        }
                    }

                    if ((!m_dbfD.AgregarM_UNID(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarAFTP_MatrizBANCO(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn, string version = "DBF")
        {
            CM_BANKBE fbItem = new CM_BANKBE();

            //CM_BANKD m_dbfD = new CM_BANKD();
            IMBANKD m_dbfD = null;
            CM_BANKBE m_dbfBE = new CM_BANKBE();

            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMBANK_SQLITE_D();
                ((CMBANK_SQLITE_D)m_dbfD).CreateTableMBANK_MOVIL(strOleDbConn);
                

            }
            else
                m_dbfD = new CM_BANKD();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from BANCOS";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_BANKBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((!m_dbfD.AgregarM_BANKD(m_dbfBE, strTableExpNameDet, 
                                                //odt, 
                                                strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MatrizGASTO(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_GASTOBE fbItem = new CM_GASTOBE();

            CM_GASTOD m_dbfD = new CM_GASTOD();
            CM_GASTOBE m_dbfBE = new CM_GASTOBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from GASTO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_GASTOBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((!m_dbfD.AgregarM_GASTOD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarAFTP_MatrizTIPO(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_TIPOBE fbItem = new CM_TIPOBE();

            CM_TIPOD m_dbfD = new CM_TIPOD();
            CM_TIPOBE m_dbfBE = new CM_TIPOBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from SUBTIPOCLIENTE";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_TIPOBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITIPO = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((!m_dbfD.AgregarM_TIPOD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }
        
        public bool exportarAFTP_MatrizCTRL(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {

            CM_CTRLD m_dbfD = new CM_CTRLD();
            CCONTROLPRECIOSBE controlPreciosAux = new CCONTROLPRECIOSBE();
            CCONTROLPRECIOSD daoControlPrec = new CCONTROLPRECIOSD();
            controlPreciosAux.IFECHA = DateTime.Today;
            controlPreciosAux.ITIPO = 0;
            controlPreciosAux.IUSUARIOID = CurrentUserID.CurrentUser.IID;

            if (daoControlPrec.AgregarCONTROLPRECIOSD(controlPreciosAux, null) == null)
            {
                return false;
            }

            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT FIRST 1 ID from CONTROLPRECIOS ORDER BY ID DESC";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
               if (dr.Read())
                {
                    int newId = 0;

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        newId = int.Parse((dr["ID"]).ToString());
                    }

                    if ((!m_dbfD.CambiarM_CTRL(newId, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MatrizPLAZO(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_PLAZOBE fbItem = new CM_PLAZOBE();

            CM_PLAZOD m_dbfD = new CM_PLAZOD();
            CM_PLAZOBE m_dbfBE = new CM_PLAZOBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from PLAZO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_PLAZOBE();

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IACTIVO = (string)(dr["ACTIVO"]);
                    }


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if (dr["COMISIONISTA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMISIONST = (string)(dr["COMISIONISTA"]);
                    }


                    if (dr["LEYENDA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILEYENDA = (string)(dr["LEYENDA"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDIAS = (int)(dr["DIAS"]);
                    }

                    if ((!m_dbfD.AgregarM_PLAZOD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_PRM(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_PRMBE fbItem = new CM_PRMBE();

            CM_PRMD m_dbfD = new CM_PRMD();
            CM_PRMBE m_dbfBE = new CM_PRMBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @" SELECT PROMOCION.* , PRODUCTO.CLAVE PRODUCTOCLAVE,
                            LINEA.CLAVE LINEACLAVE ,
                            TIPOPROMOCION.CLAVE TIPOPROMOCIONCLAVE,
                            RANGOPROMOCION.CLAVE RANGOPROMOCIONCLAVE,
                            SUCURSAL.CLAVE SUCURSALCLAVE
                            FROM PROMOCION
                            INNER JOIN PROMOCIONSUCURSAL PS ON PS.PROMOCIONID = PROMOCION.ID
                            LEFT JOIN SUCURSAL ON SUCURSAL.ID = PS.SUCURSALID
                            LEFT JOIN  LINEA ON PROMOCION.LINEAID = LINEA.ID
                            LEFT JOIN PRODUCTO ON PROMOCION.PRODUCTOID = PRODUCTO.ID
                            LEFT JOIN TIPOPROMOCION ON PROMOCION.TIPOPROMOCIONID = TIPOPROMOCION.ID
                            LEFT JOIN RANGOPROMOCION ON PROMOCION.RANGOPROMOCIONID = RANGOPROMOCION.ID";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    m_dbfBE = new CM_PRMBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.ICLAVE = "";
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }
                    else
                    {
                        m_dbfBE.INOMBRE = "";
                    }

                    //if (dr["ID"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IID = (long)(dr["ID"]);
                    //}
                    //else
                    //{
                    //    m_dbfBE.IID = 0;
                    //}

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESCRIP = (string)(dr["DESCRIPCION"]);
                    }
                    else
                    {
                        m_dbfBE.IDESCRIP = "";
                    }

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUCURSAL = (string)(dr["SUCURSALCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.ISUCURSAL = "";
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }
                    else
                    {
                        m_dbfBE.ICANTIDAD = 0;
                    }

                    if (dr["PRODUCTOCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["PRODUCTOCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.IPRODUCTO = "";
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
                    }
                    else
                    {
                        m_dbfBE.IUTILIDAD = 0;
                    }

                    if (dr["CANTIDADLLEVATE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICANTLLEV = (decimal)(dr["CANTIDADLLEVATE"]);
                    }
                    else
                    {
                        m_dbfBE.ICANTLLEV = 0;
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }
                    else
                    {
                        m_dbfBE.IIMPORTE = 0;
                    }

                    if (dr["PORCENTAJEDESCUENTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPORCDESC = (decimal)(dr["PORCENTAJEDESCUENTO"]);
                    }
                    else
                    {
                        m_dbfBE.IPORCDESC = 0;
                    }

                    if (dr["TIPOPROMOCIONCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITIPOPROM = (string)(dr["TIPOPROMOCIONCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.ITIPOPROM = "";
                    }

                    if (dr["RANGOPROMOCIONCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRANGPROM = (string)(dr["RANGOPROMOCIONCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.IRANGPROM = "";
                    }

                    if (dr["LINEACLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILINEA = (string)(dr["LINEACLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.ILINEA = "";
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHAINI = (DateTime)(dr["FECHAINICIO"]);
                    }
                    else
                    {
                        m_dbfBE.IFECHAINI = DateTime.MinValue;
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
                    }
                    else
                    {
                        m_dbfBE.IFECHAFIN = DateTime.MinValue;
                    }

                    if (dr["LUNES"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILUNES = (string)(dr["LUNES"]);
                    }
                    else
                    {
                        m_dbfBE.ILUNES = "N";
                    }

                    if (dr["MARTES"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMARTES = (string)(dr["MARTES"]);
                    }
                    else
                    {
                        m_dbfBE.IMARTES = "N";
                    }

                    if (dr["MIERCOLES"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMIERCOLES = (string)(dr["MIERCOLES"]);
                    }
                    else
                    {
                        m_dbfBE.IMIERCOLES = "N";
                    }

                    if (dr["JUEVES"] != System.DBNull.Value)
                    {
                        m_dbfBE.IJUEVES = (string)(dr["JUEVES"]);
                    }
                    else
                    {
                        m_dbfBE.ILUNES = "N";
                    }

                    if (dr["VIERNES"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIERNES = (string)(dr["VIERNES"]);
                    }
                    else
                    {
                        m_dbfBE.IVIERNES = "N";
                    }

                    if (dr["SABADO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISABADO = (string)(dr["SABADO"]);
                    }
                    else
                    {
                        m_dbfBE.ISABADO = "N";
                    }


                    if (dr["DOMINGO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDOMINGO = (string)(dr["DOMINGO"]);
                    }
                    else
                    {
                        m_dbfBE.IDOMINGO = "N";
                    }

                    if (dr["PORIMPORTE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPORIMPO = (decimal)(dr["PORIMPORTE"]);
                    }
                    else
                    {
                        m_dbfBE.IPORIMPO = 0;
                    }

                    if (dr["ENMONEDERO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMONEDERO = (string)(dr["ENMONEDERO"]);
                    }
                    else
                    {
                        m_dbfBE.IMONEDERO = "N";
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IACTIVO = (string)(dr["ACTIVO"]);
                    }
                    else
                    {
                        m_dbfBE.IACTIVO = "N";
                    }


                    if (dr["ESMULTIDETALLE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMULTDET = (string)(dr["ESMULTIDETALLE"]);
                    }
                    else
                    {
                        m_dbfBE.IMULTDET = "N";
                    }


                    if (dr["DESCMULTIDETALLE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESCMTD = (string)(dr["DESCMULTIDETALLE"]);
                    }
                    else
                    {
                        m_dbfBE.IDESCMTD = "";
                    }

                    if ((!m_dbfD.AgregarM_PRMD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool exportarAFTP_MatrizCONTENIDO(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_IEPRBE fbItem = new CM_IEPRBE();

            CM_IEPRD m_dbfD = new CM_IEPRD();
            CM_IEPRBE m_dbfBE = new CM_IEPRBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from CONTENIDO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_IEPRBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((!m_dbfD.AgregarM_IEPRD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MatrizCLASIFICA(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_IECTBE fbItem = new CM_IECTBE();

            CM_IECTD m_dbfD = new CM_IECTD();
            CM_IECTBE m_dbfBE = new CM_IECTBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from CLASIFICA";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_IECTBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((!m_dbfD.AgregarM_IECTD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarAFTP_MatrizMOTIVOSDEVOLUCION(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_MOTDBE fbItem = new CM_MOTDBE();

            CM_MOTDD m_dbfD = new CM_MOTDD();
            CM_MOTDBE m_dbfBE = new CM_MOTDBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from TIPODIFERENCIAINVENTARIO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_MOTDBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC = (string)(dr["DESCRIPCION"]);
                    }



                    if ((!m_dbfD.AgregarM_MOTDD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizProductosPromocion(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_TRCLBE fbItem = new CM_TRCLBE();

            CM_TRCLD m_dbfD = new CM_TRCLD();
            CM_TRCLBE m_dbfBE = new CM_TRCLBE();


            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT PRODUCTO.CLAVE PRODUCTO, PRODBASE.CLAVE PROD2, COALESCE(PRODUCTO.vigenciaprodpromo, CURRENT_DATE) FECHA from PRODUCTO
                          LEFT JOIN PRODUCTO PRODBASE ON PRODBASE.ID = PRODUCTO.BASEPRODPROMOID 
                         WHERE PRODUCTO.esprodpromo = 'S' AND COALESCE(PRODUCTO.BASEPRODPROMOID,0) > 0";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_TRCLBE();

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }


                    if (dr["PROD2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROD2 = (string)(dr["PROD2"]);
                    }




                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA = (DateTime)(dr["FECHA"]);
                    }


                    if ((!m_dbfD.AgregarM_TRCLD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MatrizPRECTEMP(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {

            CPRECTEMPD m_dbfD = new CPRECTEMPD();
            CPRECTEMPBE m_dbfBE = new CPRECTEMPBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT PRODUCTO.CLAVE, PRECIOSTEMP.PRECIO1, PRECIOSTEMP.PRECIO2, PRECIOSTEMP.PRECIO3, PRECIOSTEMP.PRECIO4, PRECIOSTEMP.PRECIO5 , PRECIOSTEMP.SUGERIDO
                             FROM PRECIOSTEMP INNER JOIN PRODUCTO ON PRECIOSTEMP.PRODUCTOID = PRODUCTO.ID

          ";




                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CPRECTEMPBE();



                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["CLAVE"]);

                    }



                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO1 = Decimal.ToDouble((decimal)(dr["PRECIO1"]));
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO2 = Decimal.ToDouble((decimal)(dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO3 = Decimal.ToDouble((decimal)(dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO4 = Decimal.ToDouble((decimal)(dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO5 = Decimal.ToDouble((decimal)(dr["PRECIO5"]));
                    }

                    if (dr["SUGERIDO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUGERIDO = Decimal.ToDouble((decimal)(dr["SUGERIDO"]));
                    }


                    if ((!m_dbfD.AgregarPRECTEMPD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }







        public bool exportarAFTP_MatrizGruposSucursal(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_GSUCBE fbItem = new CM_GSUCBE();

            CM_GSUCD m_dbfD = new CM_GSUCD();
            CM_GSUCBE m_dbfBE = new CM_GSUCBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from GRUPOSUCURSAL";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_GSUCBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC = (string)(dr["DESCRIPCION"]);
                    }

                    if ((!m_dbfD.AgregarM_GSUCD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizCaracteristicasProducto(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_DEFCBE fbItem = new CM_DEFCBE();

            CM_DEFCD m_dbfD = new CM_DEFCD();
            CM_DEFCBE m_dbfBE = new CM_DEFCBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from PROD_DEF_CARACTERISTICAS";



                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_DEFCBE();

                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }


                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO6 = (string)(dr["TEXTO6"]);
                    }


                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO1 = (string)(dr["NUMERO1"]);
                    }
                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO2 = (string)(dr["NUMERO2"]);
                    }
                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO3 = (string)(dr["NUMERO3"]);
                    }
                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO4 = (string)(dr["NUMERO4"]);
                    }


                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA1 = (string)(dr["FECHA1"]);
                    }
                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA2 = (string)(dr["FECHA2"]);
                    }





                    if ((!m_dbfD.AgregarM_DEFCD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarAFTP_MatrizCATS(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_CATSBE fbItem = new CM_CATSBE();

            CM_CATSD m_dbfD = new CM_CATSD();
            CM_CATSBE m_dbfBE = new CM_CATSBE();

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT SUCURSAL.*, GRUPOSUCURSAL.CLAVE CLAVEGRUPO from SUCURSAL left join GRUPOSUCURSAL ON GRUPOSUCURSAL.ID = SUCURSAL.GRUPOSUCURSALID";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_CATSBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLIENTE = (string)(dr["CLAVE"]);
                    }

                    if (dr["CLAVEGRUPO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IGRUPO = (string)(dr["CLAVEGRUPO"]);

                    }



                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE2 = (string)(dr["DESCRIPCION"]);
                    }


                    if (dr["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value)
                    {
                        try
                        {

                            var listaPrecioTraspaso = dr["LISTA_PRECIO_TRASPASO"].ToString();
                            
                            switch(listaPrecioTraspaso)
                            {

                                case "R": m_dbfBE.IPRECIOT = -1; break;
                                case "U": m_dbfBE.IPRECIOT = -2; break;
                                case "P": m_dbfBE.IPRECIOT = -3; break;
                                default: m_dbfBE.IPRECIOT = double.Parse(dr["LISTA_PRECIO_TRASPASO"].ToString()); break;
                            }


                            
                        }
                        catch
                        {
                            m_dbfBE.IPRECIOT = 0.00;
                        }
                    }


                    if (dr["MAXDOCTOSPENDIENTES"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMAXDOCP = Convert.ToDouble((int)(dr["MAXDOCTOSPENDIENTES"]));
                    }


                    if (dr["ESMATRIZ"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESMATRIZ = (string)(dr["ESMATRIZ"]);
                    }



                    if (dr["PRECIORECEPCIONTRASLADO"] != System.DBNull.Value)
                    {
                        try
                        {
                            m_dbfBE.ICOSTOREC = double.Parse(dr["PRECIORECEPCIONTRASLADO"].ToString());
                        }
                        catch
                        {
                            m_dbfBE.ICOSTOREC = 1.00;
                        }
                    }

                    if (dr["PRECIOENVIOTRASLADO"] != System.DBNull.Value)
                    {
                        try
                        {
                            m_dbfBE.IPRECENV = double.Parse(dr["PRECIOENVIOTRASLADO"].ToString());
                        }
                        catch
                        {
                            m_dbfBE.IPRECENV = 4.00;
                        }
                    }


                    if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISHOWREAL = (string)(dr["MOSTRARPRECIOREAL"]);
                    }


                    if (dr["PROVEEDORCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEE = (string)(dr["PROVEEDORCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.IPROVEE = "";
                    }


                    if (dr["SURTIDOR"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISURTIDOR = (string)(dr["SURTIDOR"]);
                    }
                    else
                    {
                        m_dbfBE.ISURTIDOR = "";
                    }


                    if (dr["PORC_AUMENTO_PRECIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPORCPREC = double.Parse(dr["PORC_AUMENTO_PRECIO"].ToString());
                    }
                    else
                    {
                        m_dbfBE.IPORCPREC = 0;
                    }


                    if (dr["MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECXDES = (string)(dr["MANEJAPRECIOXDESCUENTO"]);
                    }
                    else
                    {
                        m_dbfBE.IPRECXDES = "N";
                    }

                    if (dr["PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPREFXDES = (string)(dr["PREFIJOPRECIOXDESCUENTO"]);
                    }
                    else
                    {
                        m_dbfBE.IPREFXDES = "";
                    }


                    if (dr["NOMBRERESPALDOBD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRESPBD = (string)(dr["NOMBRERESPALDOBD"]);
                    }
                    else
                    {
                        m_dbfBE.IRESPBD = "";
                    }



                    if (dr["ESFRANQUICIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESFRANQ = (string)(dr["ESFRANQUICIA"]);
                    }
                    else
                    {
                        m_dbfBE.IESFRANQ = "N";
                    }




                    if (dr["BANCOCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IBANCO = (string)(dr["BANCOCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.IBANCO = "";
                    }


                    if (dr["CUENTAREFERENCIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICUENTA = (string)(dr["CUENTAREFERENCIA"]);
                    }
                    else
                    {
                        m_dbfBE.ICUENTA = "";
                    }



                    if (dr["CUENTAPOLIZA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICTAPOLI = (string)(dr["CUENTAPOLIZA"]);
                    }
                    else
                    {
                        m_dbfBE.ICTAPOLI = "";
                    }
                    

                    if (dr["LISTAPRECIOCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILSTPREC = (string)(dr["LISTAPRECIOCLAVE"]);
                    }
                    else
                    {
                        m_dbfBE.ILSTPREC = "";
                    }


                    if (dr["EMPPROV"] != System.DBNull.Value)
                    {
                        m_dbfBE.IEMPPROV = (string)(dr["EMPPROV"]);
                    }
                    else
                    {
                        m_dbfBE.IEMPPROV = "";
                    }


                    if (dr["IMNUPROD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMNUPROD = (string)(dr["IMNUPROD"]);
                    }
                    else
                    {
                        m_dbfBE.IIMNUPROD = "";
                    }



                    if ((!m_dbfD.AgregarM_CATSD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

        public bool exportarAFTP_MatrizPROV(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn, string version = "DBF")
        {
            CM_PROVBE fbItem = new CM_PROVBE();

            //CM_PROVD m_dbfD = new CM_PROVD();
            IMPROVD m_dbfD = null;
            CM_PROVBE m_dbfBE = new CM_PROVBE();

            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMPROV_SQLITE_D();
                ((CMPROV_SQLITE_D)m_dbfD).CreateTableMPROV_MOVIL(strOleDbConn);

            }
            else
                m_dbfD = new CM_PROVD();




            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from PERSONA WHERE TIPOPERSONAID = " + DBValues._TIPOPERSONA_PROVEEDOR.ToString("N0");



                if (doctoId != 0)
                {
                    CmdTxt = @"SELECT PERSONA.* from PERSONA WHERE PERSONA.ID IN
                        (
                                            SELECT PRODUCTOFINAL.PROVEEDOR1ID FROM PRODUCTO PRODUCTOFINAL
                                            INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                            WHERE MOVTOFINAL.DOCTOID = @DOCTOID
                                            UNION
                                            SELECT PRODUCTOPADRE.PROVEEDOR1ID FROM PRODUCTO PRODUCTOPADRE
                                            INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                            WHERE MOVTOPADRE.DOCTOID = @DOCTOID 

                            )  
                            or PERSONA.ID IN (
                                              SELECT PRODUCTOFINAL.PROVEEDOR2ID  FROM PRODUCTO PRODUCTOFINAL
                                            INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                            WHERE MOVTOFINAL.DOCTOID = @DOCTOID
                                            UNION
                                            SELECT PRODUCTOPADRE.PROVEEDOR2ID FROM PRODUCTO PRODUCTOPADRE
                                            INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                            WHERE MOVTOPADRE.DOCTOID = @DOCTOID
                                        )  ";
                    
                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Value = doctoId;
                    parts.Add(auxPar);
                }

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_PROVBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }
                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICALLE = (string)(dr["DOMICILIO"]);
                    }
                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOLONIA = (string)(dr["COLONIA"]);
                    }
                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICIUDAD = (string)(dr["CIUDAD"]);
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESTADO = (string)(dr["ESTADO"]);
                    }
                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICP = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEL1 = (string)(dr["TELEFONO1"]);
                    }
                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEL2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICONTACTO = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["ADESCPES"] != System.DBNull.Value)
                    {
                        try
                        {
                            m_dbfBE.IADESCPES = double.Parse(dr["ADESCPES"].ToString());
                        }
                        catch
                        {
                            m_dbfBE.IADESCPES = 0.00;
                        }
                    }
                    




                    if ((!m_dbfD.AgregarM_PROVD(m_dbfBE, strTableExpNameDet, /*odt,*/ strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizENCC(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_ENCCBE fbItem = new CM_ENCCBE();

            CM_ENCCD m_dbfD = new CM_ENCCD();
            CM_ENCCBE m_dbfBE = new CM_ENCCBE();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from PERSONA WHERE TIPOPERSONAID = " + DBValues._TIPOPERSONA_ENCARGADOCORTE.ToString("N0");



                if (doctoId != 0)
                {
                    CmdTxt = @"SELECT PERSONA.* from PERSONA WHERE PERSONA.ID IN
                        (
                                            SELECT PRODUCTOFINAL.PROVEEDOR1ID FROM PRODUCTO PRODUCTOFINAL
                                            INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                            WHERE MOVTOFINAL.DOCTOID = @DOCTOID
                                            UNION
                                            SELECT PRODUCTOPADRE.PROVEEDOR1ID FROM PRODUCTO PRODUCTOPADRE
                                            INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                            WHERE MOVTOPADRE.DOCTOID = @DOCTOID 

                            )  
                            or PERSONA.ID IN (
                                              SELECT PRODUCTOFINAL.PROVEEDOR2ID  FROM PRODUCTO PRODUCTOFINAL
                                            INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                            WHERE MOVTOFINAL.DOCTOID = @DOCTOID
                                            UNION
                                            SELECT PRODUCTOPADRE.PROVEEDOR2ID FROM PRODUCTO PRODUCTOPADRE
                                            INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                            WHERE MOVTOPADRE.DOCTOID = @DOCTOID
                                        )  ";

                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Value = doctoId;
                    parts.Add(auxPar);
                }

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_ENCCBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }
                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICALLE = (string)(dr["DOMICILIO"]);
                    }
                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOLONIA = (string)(dr["COLONIA"]);
                    }
                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICIUDAD = (string)(dr["CIUDAD"]);
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESTADO = (string)(dr["ESTADO"]);
                    }
                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICP = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEL1 = (string)(dr["TELEFONO1"]);
                    }
                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEL2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICONTACTO = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["ADESCPES"] != System.DBNull.Value)
                    {
                        try
                        {
                            m_dbfBE.IADESCPES = double.Parse(dr["ADESCPES"].ToString());
                        }
                        catch
                        {
                            m_dbfBE.IADESCPES = 0.00;
                        }
                    }





                    if ((!m_dbfD.AgregarM_ENCCD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizKITS(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn, string version = "DBF")
        {
            CM_KITSBE fbItem = new CM_KITSBE();

            //CM_KITSD m_dbfD = new CM_KITSD();
            IMKITSD m_dbfD = null;
            CM_KITSBE m_dbfBE = new CM_KITSBE();

            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMKIT_SQLITE_D();
                ((CMKIT_SQLITE_D)m_dbfD).CreateTableMKITS_MOVIL(strOleDbConn);

            }
            else
                m_dbfD = new CM_KITSD();

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();


                if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
                {
                    CmdTxt = @"
                                SELECT 
                                    PE.CLAVE PRODUCTOKITCLAVE ,
                                    PP.CLAVE PRODUCTOPARTECLAVE ,
                                    KU.CANTIDADPARTE CANTIDADPARTE ,
                                    0.0 COSTOPARTE
                                FROM KITSUNNIVEL KU
                                LEFT JOIN PRODUCTO PE  ON KU.productokitid = pe.id      
                                LEFT JOIN PRODUCTO PP  ON KU.productoparteid = pp.id ";
                }
                else
                {
                    CmdTxt = @"SELECT * FROM KITDEFINICION ";
                }

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_KITSBE();

                    if (dr["PRODUCTOKITCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["PRODUCTOKITCLAVE"]);
                    }

                    if (dr["PRODUCTOPARTECLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPARTE = (string)(dr["PRODUCTOPARTECLAVE"]);

                    }




                    if (dr["CANTIDADPARTE"] != System.DBNull.Value)
                    {
                        try
                        {
                            m_dbfBE.ICANTIDAD = double.Parse(dr["CANTIDADPARTE"].ToString());
                        }
                        catch
                        {
                            m_dbfBE.ICANTIDAD = 0.00;
                        }
                    }


                    if (dr["COSTOPARTE"] != System.DBNull.Value)
                    {
                        try
                        {
                            m_dbfBE.ICOSTO = double.Parse(dr["COSTOPARTE"].ToString());
                        }
                        catch
                        {
                            m_dbfBE.ICOSTO = 0.00;
                        }
                    }


                    if ((!m_dbfD.AgregarM_KITSD(m_dbfBE, strTableExpNameDet, 
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }






        public bool exportarAFTP_MatrizTERM(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_TERMBE fbItem = new CM_TERMBE();

            CM_TERMD m_dbfD = new CM_TERMD();
            CM_TERMBE m_dbfBE = new CM_TERMBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from TERMINALPAGOSERVICIO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_TERMBE();

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUCCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }



                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESSERV = (string)(dr["ESSERVICIO"]);
                    }


                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITERMINAL = (string)(dr["TERMINAL"]);
                    }



                    if ((!m_dbfD.AgregarM_TERMD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }





        public bool exportarAFTP_MatrizPRSC(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_PRSCBE fbItem = new CM_PRSCBE();

            CM_PRSCD m_dbfD = new CM_PRSCD();
            CM_PRSCBE m_dbfBE = new CM_PRSCBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT PRODUCTO.CLAVE PROD, SUCURSAL.CLAVE SUCCLAVE from PRODUCTOSUCURSAL INNER JOIN PRODUCTO ON PRODUCTO.ID = PRODUCTOSUCURSAL.PRODUCTOID 
                                                                                         INNER JOIN SUCURSAL ON SUCURSAL.ID = PRODUCTOSUCURSAL.SUCURSALID";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_PRSCBE();

                    if (dr["SUCCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUCCLAVE = (string)(dr["SUCCLAVE"]);
                    }

                    

                    if (dr["PROD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["PROD"]);
                    }



                    if ((!m_dbfD.AgregarM_PRSCD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizLSPR(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_LSPRBE fbItem = new CM_LSPRBE();

            CM_LSPRD m_dbfD = new CM_LSPRD();
            CM_LSPRBE m_dbfBE = new CM_LSPRBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT LISTAPRECIO.CLAVE, LISTAPRECIO.NOMBRE from LISTAPRECIO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_LSPRBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE = (string)(dr["CLAVE"]);
                    }



                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }



                    if ((!m_dbfD.AgregarM_LSPRD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizLPDT(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_LPDTBE fbItem = new CM_LPDTBE();

            CM_LPDTD m_dbfD = new CM_LPDTD();
            CM_LPDTBE m_dbfBE = new CM_LPDTBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT LISTAPRECIO.CLAVE LISTA, PRODUCTO.CLAVE PRODUCTO, LISTAPRECIODETALLE.PRECIO1, 
                        LISTAPRECIODETALLE.PRECIO2,  LISTAPRECIODETALLE.PRECIO3, LISTAPRECIODETALLE.PRECIO4,  LISTAPRECIODETALLE.PRECIO5,
                        LISTAPRECIODETALLE.COSTOREPOSICION, LISTAPRECIODETALLE.TIENEVIG, LISTAPRECIODETALLE.FECHAVIG
                        from LISTAPRECIODETALLE LEFT JOIN PRODUCTO ON PRODUCTO.ID = LISTAPRECIODETALLE.PRODUCTOID
                        LEFT JOIN LISTAPRECIO ON LISTAPRECIO.ID = LISTAPRECIODETALLE.LISTAPRECIOID
                        WHERE LISTAPRECIO.ACTIVO = 'S'";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_LPDTBE();

                    if (dr["LISTA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILISTA = (string)(dr["LISTA"]);
                    }



                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                        m_dbfBE.IPRODUCTO = m_dbfBE.IPRODUCTO.Trim();
                    }


                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }


                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOSTOREP = (decimal)(dr["COSTOREPOSICION"]);
                    }


                    if (dr["TIENEVIG"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITIENEVIG = dr["TIENEVIG"].ToString();
                    }



                    if (dr["FECHAVIG"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHAVIG = (DateTime)dr["FECHAVIG"];
                    }


                    if ((!m_dbfD.AgregarM_LPDTD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizMXFT(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_MXFTBE fbItem = new CM_MXFTBE();

            CM_MXFTD m_dbfD = new CM_MXFTD();
            CM_MXFTBE m_dbfBE = new CM_MXFTBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT MAXFACT.SUCURSALCLAVE SUCURSAL,
                              MAXFACT.ANIO, MAXFACT.MES, 
                              MAXFACT.LUN_HAY, MAXFACT.LUN_MAX,
                              MAXFACT.MAR_HAY, MAXFACT.MAR_MAX,
                              MAXFACT.MIE_HAY, MAXFACT.MIE_MAX,
                              MAXFACT.JUE_HAY, MAXFACT.JUE_MAX,
                              MAXFACT.VIE_HAY, MAXFACT.VIE_MAX,
                              MAXFACT.SAB_HAY, MAXFACT.SAB_MAX,
                              MAXFACT.DOM_HAY, MAXFACT.DOM_MAX
                        from MAXFACT 
                        WHERE MAXFACT.ACTIVO = 'S'";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_MXFTBE();

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUCURSAL = (string)(dr["SUCURSAL"]);
                    }


                    if (dr["MES"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMES = (int)(dr["MES"]);
                    }

                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IANIO = (int)(dr["ANIO"]);
                    }



                    if (dr["LUN_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILUN_HAY = (string)(dr["LUN_HAY"]);
                    }

                    if (dr["LUN_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILUN_MAX = (decimal)(dr["LUN_MAX"]);
                    }


                    if (dr["MAR_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMAR_HAY = (string)(dr["MAR_HAY"]);
                    }

                    if (dr["MAR_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMAR_MAX = (decimal)(dr["MAR_MAX"]);
                    }

                    if (dr["MIE_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMIE_HAY = (string)(dr["MIE_HAY"]);
                    }

                    if (dr["MIE_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMIE_MAX = (decimal)(dr["MIE_MAX"]);
                    }

                    if (dr["JUE_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.IJUE_HAY = (string)(dr["JUE_HAY"]);
                    }

                    if (dr["JUE_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.IJUE_MAX = (decimal)(dr["JUE_MAX"]);
                    }

                    if (dr["VIE_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIE_HAY = (string)(dr["VIE_HAY"]);
                    }

                    if (dr["VIE_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIE_MAX = (decimal)(dr["VIE_MAX"]);
                    }

                    if (dr["SAB_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISAB_HAY = (string)(dr["SAB_HAY"]);
                    }

                    if (dr["SAB_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISAB_MAX = (decimal)(dr["SAB_MAX"]);
                    }

                    if (dr["DOM_HAY"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDOM_HAY = (string)(dr["DOM_HAY"]);
                    }

                    if (dr["DOM_MAX"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDOM_MAX = (decimal)(dr["DOM_MAX"]);
                    }





                    if ((!m_dbfD.AgregarM_MXFTD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

        public bool exportarAFTP_MatrizMERCH(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_MERCHBE fbItem = new CM_MERCHBE();

            CM_MERCHD m_dbfD = new CM_MERCHD();
            CM_MERCHBE m_dbfBE = new CM_MERCHBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from MERCHANTPAGOSERVICIO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_MERCHBE();

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUCCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }



                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESSERV = (string)(dr["ESSERVICIO"]);
                    }


                    if (dr["MERCHANTID"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMERCHANT = (string)(dr["MERCHANTID"]);
                    }



                    if ((!m_dbfD.AgregarM_MERCHD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }




        public bool exportarAFTP_MatrizCLERK(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CM_CLERKBE fbItem = new CM_CLERKBE();

            CM_CLERKD m_dbfD = new CM_CLERKD();
            CM_CLERKBE m_dbfBE = new CM_CLERKBE();


            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT * from CLERKPAGOSERVICIO";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_CLERKBE();

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUCCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }


                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESSERV = (string)(dr["ESSERVICIO"]);
                    }




                    if (dr["CLERKID"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLERK = (string)(dr["CLERKID"]);
                    }



                    if ((!m_dbfD.AgregarM_CLERKD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }





        public bool exportarAFTP_MovilM_USER(string strTableExpNameDet,  FbTransaction st, string strOleDbConn, string version = "DBF")
        {
            CM_USERBE fbItem = new CM_USERBE();
            
            IMUSERD m_dbfD = null;
            CM_USERBE m_dbfBE = new CM_USERBE();



            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMUSER_SQLITE_D();
                ((CMUSER_SQLITE_D)m_dbfD).CreateTableMUSER_MOVIL(strOleDbConn);

            }
            else
                throw new Exception("no implementado");
            
            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT   U.clave CLAVE ,
                                    U.nombre NOMBRE,
                                    '' EXPORTAUT,
                                    coalesce(v.email2,'') IMPRESORA  ,
                                    coalesce(v.clave,'') VENDEDOR ,
                                    u.claveacceso PASSWOR,
                                    u.cajasbotellas CAJASBOTELLAS
                            FROM PERSONA  U
                            LEFT JOIN  PERSONA V on  U.vendedorid = v.id
                            WHERE u.tipopersonaid = 20
";


                FbParameter auxPar;

                //auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                //auxPar.Value = cobranzaHdr.IID;
                //parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_USERBE();
                    
                    


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {

                        m_dbfBE.ICLAVE = (string)dr["CLAVE"];
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {

                        m_dbfBE.INOMBRE = (string)dr["NOMBRE"];
                    }


                    if (dr["EXPORTAUT"] != System.DBNull.Value)
                    {

                        m_dbfBE.IEXPORTAUT = (string)dr["EXPORTAUT"];
                    }

                    if (dr["IMPRESORA"] != System.DBNull.Value)
                    {

                        m_dbfBE.IIMPRESORA = (string)dr["IMPRESORA"];
                    }

                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {

                        m_dbfBE.IVENDEDOR = (string)dr["VENDEDOR"];
                    }

                    if (dr["PASSWOR"] != System.DBNull.Value)
                    {

                        m_dbfBE.IPASSWORD = (string)dr["PASSWOR"];
                    }


                    if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
                    {

                        m_dbfBE.ICAJASBOTELLAS = (string)dr["CAJASBOTELLAS"];
                    }





                    if ((!m_dbfD.AgregarM_USERD(m_dbfBE, strTableExpNameDet,
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MovilM_PARM(string strTableExpNameDet, FbTransaction st, string strOleDbConn, string version = "DBF")
        {
            CM_PARMBE fbItem = new CM_PARMBE();

            IMPARMD m_dbfD = null;
            CM_PARMBE m_dbfBE = new CM_PARMBE();



            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMPARM_SQLITE_D();
                ((CMPARM_SQLITE_D)m_dbfD).CreateTableMPARM_MOVIL(strOleDbConn);

            }
            else
                throw new Exception("no implementado");

            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT   minutilidad as MINUTILIDAD   ,
                                    desgloseieps  as DESGLOSEIEPS,
                                    LISTAPRECIOMINIMO as LISTAPRECIOMINIMO
                            FROM PARAMETRO
";


                FbParameter auxPar;

                //auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                //auxPar.Value = cobranzaHdr.IID;
                //parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_PARMBE();





                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {

                        m_dbfBE.IMINUTILIDAD = Decimal.ToSingle((decimal)dr["MINUTILIDAD"]);
                    }



                    if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                    {

                        m_dbfBE.IDESGLOSEIEPS = (string)dr["DESGLOSEIEPS"];
                    }



                    if (dr["LISTAPRECIOMINIMO"] != System.DBNull.Value)
                    {

                        m_dbfBE.ILISTAPRECIOMINIMO = (int)((long)dr["LISTAPRECIOMINIMO"]);
                    }








                    if ((!m_dbfD.AgregarM_PARMD(m_dbfBE, strTableExpNameDet,
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarAFTP_MovilM_DER(string strTableExpNameDet, FbTransaction st, string strOleDbConn, string version = "DBF")
        {
            CM_DERBE fbItem = new CM_DERBE();

            IMDERD m_dbfD = null;
            CM_DERBE m_dbfBE = new CM_DERBE();



            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMDER_SQLITE_D();
                ((CMDER_SQLITE_D)m_dbfD).CreateTableMDER_MOVIL(strOleDbConn);

            }
            else
                throw new Exception("no implementado");

            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT   DR_DERECHO CLAVE ,
                                    DR_DESCRIPCION NOMBRE
                            FROM DERECHOS
                            where DR_DERECHO >= 10000
";


                FbParameter auxPar;

                //auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                //auxPar.Value = cobranzaHdr.IID;
                //parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_DERBE();





                    if (dr["CLAVE"] != System.DBNull.Value)
                    {

                        m_dbfBE.ICLAVE = ((int)dr["CLAVE"]).ToString();
                    }



                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {

                        m_dbfBE.INOMBRE = (string)dr["NOMBRE"];
                    }

                    

                    if ((!m_dbfD.AgregarM_DERD(m_dbfBE, strTableExpNameDet,
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MovilM_DER_U(string strTableExpNameDet, FbTransaction st, string strOleDbConn, string version = "DBF")
        {
            CM_DER_UBE fbItem = new CM_DER_UBE();

            IMDERUD m_dbfD = null;
            CM_DER_UBE m_dbfBE = new CM_DER_UBE();



            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMDERU_SQLITE_D();
                ((CMDERU_SQLITE_D)m_dbfD).CreateTableMDERU_MOVIL(strOleDbConn);

            }
            else
                throw new Exception("no implementado");

            this.iComentario = "";
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"  SELECT U.clave CLAVEUSUARIO,
                             PD.pd_derecho CLAVEDERECHO
                            FROM PERSONA U
                       LEFT JOIN USUARIO_PERFIL UP ON UP.up_personaid = U.ID
                       LEFT JOIN PERFIL_DER PD ON PD.pd_perfil = UP.up_perfil
                       WHERE u.tipopersonaid = 20
                       AND       COALESCE(PD.pd_derecho ,0 ) >= 10000  
                       GROUP BY U.CLAVE, PD.PD_DERECHO
                           ";


                FbParameter auxPar;

                //auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                //auxPar.Value = cobranzaHdr.IID;
                //parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_DER_UBE();





                    if (dr["CLAVEDERECHO"] != System.DBNull.Value)
                    {

                        m_dbfBE.ICLAVEDERECHO = ((int)dr["CLAVEDERECHO"]).ToString();
                    }



                    if (dr["CLAVEUSUARIO"] != System.DBNull.Value)
                    {

                        m_dbfBE.ICLAVEUSUARIO = (string)dr["CLAVEUSUARIO"];
                    }






                    if ((!m_dbfD.AgregarM_DER_UD(m_dbfBE, strTableExpNameDet,
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarAFTP_MovilCobranza(string strTableExpNameDet, CBITACOBRANZABE cobranzaHdr, CPERSONABE vendedor, FbTransaction st, OleDbTransaction odt, string strOleDbConn, string version = "DBF")
        {
            CM_CREPBE fbItem = new CM_CREPBE();

            //CM_CREPD m_dbfD = new CM_CREPD();
            IMCREPD m_dbfD = null;
            CM_CREPBE m_dbfBE = new CM_CREPBE();



            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMCREP_SQLITE_D();
                ((CMCREP_SQLITE_D)m_dbfD).CreateTableMCREP_MOVIL(strOleDbConn);

            }
            else
                m_dbfD = new CM_CREPD();

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT BITACOBRANZADET.*, DOCTO.FOLIO DOCTOFOLIO , CLIENTE.CLAVE CLIENTECLAVE, CLIENTE.NOMBRE CLIENTENOMBRE,
                              DOCTO.ESFACTURAELECTRONICA, DOCTO.FOLIOSAT, DOCTO.TOTAL DOCTOTOTAL, DOCTO.FECHAFACTURA, CLIENTE.BLOQUEADO, DOCTO.ABONO DOCTOABONO, DOCTO.SALDO DOCTOSALDO
                            from BITACOBRANZADET LEFT JOIN DOCTO ON DOCTO.ID = BITACOBRANZADET.DOCTOID 
                                LEFT JOIN PERSONA CLIENTE ON CLIENTE.ID = BITACOBRANZADET.PERSONAID where BITCOBRANZAID = @BITCOBRANZAID";


                FbParameter auxPar;
                auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                auxPar.Value = cobranzaHdr.IID;
                parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CM_CREPBE();


                    if (dr["BITCOBRANZAID"] != System.DBNull.Value)
                    {
                        long bitCobranzaId = (long)(dr["BITCOBRANZAID"]);
                        m_dbfBE.ICOBRANZA = bitCobranzaId.ToString();
                    }

                    m_dbfBE.IVENDEDOR = vendedor.ICLAVE;


                    if (dr["DOCTOFOLIO"] != System.DBNull.Value)
                    {
                        int folio = (int)(dr["DOCTOFOLIO"]);
                        m_dbfBE.IVENTA = folio.ToString();
                    }



                    if (dr["BITCOBRANZAID"] != System.DBNull.Value)
                    {
                        long bitCobranzaId = (long)(dr["BITCOBRANZAID"]);
                        m_dbfBE.ICOBRANZA = bitCobranzaId.ToString();
                    }



                    if (dr["CLIENTECLAVE"] != System.DBNull.Value)
                    {

                        m_dbfBE.ICLIENTE = (string)dr["CLIENTECLAVE"];
                    }

                    if (dr["CLIENTENOMBRE"] != System.DBNull.Value)
                    {

                        m_dbfBE.INOMBRE = (string)dr["CLIENTENOMBRE"];
                    }


                    if (dr["FOLIOSAT"] != System.DBNull.Value)
                    {

                        int folioSat = (int)(dr["FOLIOSAT"]);
                        m_dbfBE.IFACTURA = folioSat.ToString();
                    }


                    if (dr["ESFACTURAELECTRONICA"] != System.DBNull.Value)
                    {

                        string sEsFacturaElectronica = (string)dr["ESFACTURAELECTRONICA"];
                        if (sEsFacturaElectronica != null && sEsFacturaElectronica.Equals("S"))
                        {
                            m_dbfBE.IESTATUS = "F";
                        }
                        else
                        {
                            m_dbfBE.IESTATUS = "R";
                        }
                    }

                    //isnull.Add("IEMPRESA", true);



                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        m_dbfBE.IFECHA = (DateTime)dr["FECHA"];
                    }

                    if (dr["FECHAFACTURA"] != System.DBNull.Value)
                    {

                        m_dbfBE.IF_FACTURA = (DateTime)dr["FECHAFACTURA"];
                    }



                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        m_dbfBE.IF_PAGO = (DateTime)dr["FECHAVENCE"];
                    }



                    if (dr["DOCTOTOTAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITOTAL = (decimal)(dr["DOCTOTOTAL"]);
                    }

                    if (dr["DOCTOSALDO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISALDO = (decimal)(dr["DOCTOSALDO"]);

                        m_dbfBE.IIMPOR_NETO = (decimal)(dr["DOCTOSALDO"]);
                    }

                    if (dr["DOCTOABONO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IA_CUENTA = (decimal)(dr["DOCTOABONO"]);
                    }



                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {

                        m_dbfBE.IBLOQUEADO = (string)dr["BLOQUEADO"];
                    }


                    //isnull.Add("IOBS", true);
                    //isnull.Add("IDIAS", true);
                    //isnull.Add("IINT_COB", true);
                    //isnull.Add("IINTERESES", true);
                    //isnull.Add("IPAGO", true);
                    //isnull.Add("IEFECTIVO", true);
                    //isnull.Add("IDIFERENCIA", true);
                    //isnull.Add("IIMP_CHEQUE", true);
                    //isnull.Add("IBANCO", true);
                    //isnull.Add("INUM_CHEQ", true);
                    //isnull.Add("IINTERES", true);
                    //isnull.Add("ICAPITAL", true);
                    //isnull.Add("IOLLA", true);
                    //isnull.Add("ILLEVAR", true);
                    //isnull.Add("IID", true);
                    //isnull.Add("IID_FECHA", true);
                    //isnull.Add("IID_HORA", true);
                    
                    

                    if ((!m_dbfD.AgregarM_CREPD(m_dbfBE, strTableExpNameDet, 
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        


        public bool exportarAFTP_MovilPROD(string strTableExpNameDet, long doctoId, FbTransaction st, OleDbTransaction odt, string strOleDbConn, bool exportProductInactive, long almacenId, string version = "DBF")
        {
            CPRODUCTOBE fbItem = new CPRODUCTOBE();

            IPRODD m_dbfD = null;
            CPRODBE m_dbfBE = new CPRODBE();


            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CPROD_SQLITE_D();
                ((CPROD_SQLITE_D)m_dbfD).CreateTablePROD_MOVIL(strOleDbConn);
                
            }
            else
                m_dbfD = new CPRODD();


            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT  PRODUCTO.ID,
                         PRODUCTO.CLAVE, PRODUCTO.NOMBRE, PRODUCTO.DESCRIPCION, PRODUCTO.EAN, PRODUCTO.DESCRIPCION1, PRODUCTO.DESCRIPCION2, 
                         PRODUCTO.DESCRIPCION3, PRODUCTO.PRECIO1, 
                         PRODUCTO.PRECIO2, PRODUCTO.PRECIO3, PRODUCTO.PRECIO4, PRODUCTO.PRECIO5, 
                         COALESCE(PRODUCTO.SPRECIO1,0) SPRECIO1, COALESCE(PRODUCTO.SPRECIO2,0) SPRECIO2, COALESCE(PRODUCTO.SPRECIO3,0) SPRECIO3, COALESCE(PRODUCTO.SPRECIO4,0) SPRECIO4, COALESCE(PRODUCTO.SPRECIO5,0) SPRECIO5, 
                         COALESCE(PRODUCTO.PORCUTILPRECIO1,0) PORCUTILPRECIO1, COALESCE(PRODUCTO.PORCUTILPRECIO2,0) PORCUTILPRECIO2, COALESCE(PRODUCTO.PORCUTILPRECIO3,0) PORCUTILPRECIO3, COALESCE(PRODUCTO.PORCUTILPRECIO4,0) PORCUTILPRECIO4, COALESCE(PRODUCTO.PORCUTILPRECIO5,0) PORCUTILPRECIO5, 
                         PRODUCTO.COSTOREPOSICION, PRODUCTO.COSTOULTIMO, PRODUCTO.COSTOPROMEDIO, PRODUCTO.PRODUCTOSUSTITUTOID, PRODUCTO.MANEJALOTE, 
                         PRODUCTO.ESKIT, PRODUCTO.IMPRIMIR, PRODUCTO.INVENTARIABLE, PRODUCTO.NEGATIVOS, PRODUCTO.LIMITEPRECIO2, 
                         PRODUCTO.PRECIOMAXIMOPUBLICO, PRODUCTO.FECHACAMBIOPRECIO, PRODUCTO.MANEJASTOCK, PRODUCTO.STOCK, PRODUCTO.CAMBIARPRECIO, 
                         PRODUCTO.COMPRAENTIENDA, PRODUCTO.EXISTENCIA, PRODUCTO.SUBSTITUTO, PRODUCTO.CBARRAS, PRODUCTO.CEMPAQUE, PRODUCTO.PZACAJA, 
                         PRODUCTO.U_EMPAQUE, PRODUCTO.UNIDAD, PRODUCTO.INI_MAYO, PRODUCTO.MAYOKGS, PRODUCTO.TIPOABC, PRODUCTO.COMISION, PRODUCTO.OFERTA, 
                         PRODUCTO.EXISTENCIAFACTURADO, PRODUCTO.EXISTENCIAREMISIONADO, PRODUCTO.EXISTENCIAINDEFINIDO, PRODUCTO.ESPRODUCTOFINAL, 
                         PRODUCTO.ESPRODUCTOPADRE, PRODUCTO.ESSUBPRODUCTO, PRODUCTO.TOMARPRECIOPADRE, PRODUCTO.TOMARCOMISIONPADRE, 
                         PRODUCTO.TOMAROFERTAPADRE, PRODUCTO.PRODUCTOPADRE, PRODUCTO.EXISTENCIAFACTURADOAPARTADO, 
                         PRODUCTO.EXISTENCIAREMISIONADOAPARTADO, PRODUCTO.EXISTENCIAINDEFINIDOAPARTADO, PRODUCTO.EXISTENCIAAPARTADO, 
                         PRODUCTO.ULTIMOORIGENFISCALVENTA, PRODUCTO.EXIST_FAC_INTERCAMBIO, PRODUCTO.EXIST_REM_INTERCAMBIO, LINEA.CLAVE AS CLAVELINEA, LINEA.NOMBRE NOMBRELINEA,
                         MARCA.CLAVE AS CLAVEMARCA, MARCA.NOMBRE NOMBREMARCA, MONEDA.CLAVE AS CLAVEMONEDA, PROV1.CLAVE AS CLAVEPROVEEDOR1, PROV1.NOMBRE AS NOMBREPROVEEDOR1, PROV2.CLAVE AS CLAVEPROVEEDOR2, 
                         TASAIVA.CLAVE AS CLAVETASAIVA, 

                         CASE WHEN COALESCE(PRODUCTO.eskit, 'N') = 'S'  AND  COALESCE(PRODUCTO.TASAIVAEXT,0) > 0   THEN
                                COALESCE(PRODUCTO.TASAIVAEXT,0)
                              ELSE
                                PRODUCTO.TASAIVA
                         END TASAIVA, 

                         PRODUCTOPADRE.CLAVE AS CLAVEPRODUCTOPADRE,
                         CR.TEXTO1,CR.TEXTO2,CR.TEXTO3,CR.TEXTO4,CR.TEXTO5,CR.TEXTO6,
                         CR.FECHA1,CR.FECHA2,
                         CR.NUMERO1,CR.NUMERO2,CR.NUMERO3,CR.NUMERO4,
                         PRODUCTOSUBSTITUTO.CLAVE AS CLAVEPRODUCTOSUBSTITUTO,PRODUCTO.PLUG, 

                         CASE WHEN COALESCE(PRODUCTO.eskit, 'N') = 'S'  AND COALESCE(PRODUCTO.TASAIEPSEXT,0) > 0     THEN
                                COALESCE(PRODUCTO.TASAIEPSEXT,0)
                              ELSE
                                PRODUCTO.TASAIEPS
                         END TASAIEPS, 

                         PRODUCTO.MINUTILIDAD
                         , PRODUCTO.REQUIERERECETA, PRODUCTO.PRECIOTOPE,
                         PRODUCTO.PRECIOSUGERIDO, PRODUCTO.PRECIOMAT, CONTENIDO.CLAVE CLAVE_CONTENIDO, CLASIFICA.CLAVE CLAVE_CLASIFICA, PRODUCTO.MENUDEO, PRODUCTO.CONTENIDOVALOR, PRODUCTO.UNIDAD2, PRODUCTO.CANTXPIEZA,
                         PRODUCTO.MANEJALOTEIMPORTADO, PRODUCTO.COSTOENDOLAR, PLAZO.CLAVE PLAZOCLAVE,
                         SAT_PRODUCTOSERVICIO.SAT_CLAVEPRODSERV,
                         BASEPRODPROMO.CLAVE CLAVEBASEPRODPROMO, PRODUCTO.ESPRODPROMO, PRODUCTO.VIGENCIAPRODPROMO, PRODUCTO.VIGENCIAPRODKIT, PRODUCTO.KITTIENEVIG, PRODUCTO.VALXSUC,
                         PRODUCTO.KITIMPFIJO, PRODUCTO.IMPRIMIRCOMANDA, PRODUCTO.ULTIMACOMPRA, PRODUCTO.ULTIMAVENTA,
                         round((PRODUCTO.COSTOREPOSICION  * cast( (1.0000 + ( (CASE WHEN COALESCE(PARAMETRO.desgloseieps,'N') = 'S' THEN PRODUCTO.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (PRODUCTO.TASAIVA/100.00)) as numeric(18,4))),2) COSTOREPOSICION_CONIMP,
                         round((PRODUCTO.COSTOULTIMO  * cast( (1.0000 + ( (CASE WHEN COALESCE(PARAMETRO.desgloseieps,'N') = 'S' THEN PRODUCTO.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (PRODUCTO.TASAIVA/100.00)) as numeric(18,4))),2) COSTOULTIMO_CONIMP,
                         round((PRODUCTO.COSTOPROMEDIO  * cast( (1.0000 + ( (CASE WHEN COALESCE(PARAMETRO.desgloseieps,'N') = 'S' THEN PRODUCTO.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (PRODUCTO.TASAIVA/100.00)) as numeric(18,4))),2) COSTOPROMEDIO_CONIMP,
                         INVENTARIO.CANTIDAD INVENTARIOEXISTENCIA
FROM            PRODUCTO LEFT OUTER JOIN
                         LINEA ON PRODUCTO.LINEAID = LINEA.ID LEFT OUTER JOIN
                         MARCA ON PRODUCTO.MARCAID = MARCA.ID LEFT OUTER JOIN
                         MONEDA ON PRODUCTO.MONEDAID = MONEDA.ID LEFT OUTER JOIN
                         PERSONA PROV1 ON PRODUCTO.PROVEEDOR1ID = PROV1.ID LEFT OUTER JOIN
                         PERSONA PROV2 ON PRODUCTO.PROVEEDOR2ID = PROV2.ID LEFT OUTER JOIN
                         TASAIVA ON TASAIVA.ID = PRODUCTO.TASAIVAID LEFT OUTER JOIN
                         PRODUCTO PRODUCTOPADRE ON PRODUCTO.PRODUCTOPADRE = PRODUCTOPADRE.ID LEFT OUTER JOIN
                         PRODUCTOCARACTERISTICAS CR ON PRODUCTO.ID = CR.PRODUCTOID LEFT OUTER JOIN
                         PRODUCTO PRODUCTOSUBSTITUTO ON PRODUCTO.PRODUCTOSUSTITUTOID = PRODUCTOSUBSTITUTO.ID LEFT OUTER JOIN
                         CONTENIDO ON PRODUCTO.CONTENIDOID = CONTENIDO.ID LEFT OUTER JOIN
                         CLASIFICA ON PRODUCTO.CLASIFICAID = CLASIFICA.ID LEFT OUTER JOIN
                         PLAZO ON PLAZO.ID = PRODUCTO.PLAZOID LEFT OUTER JOIN
                         SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.ID = PRODUCTO.SAT_PRODUCTOSERVICIOID LEFT OUTER JOIN 
                         PRODUCTO BASEPRODPROMO ON BASEPRODPROMO.ID = PRODUCTO.BASEPRODPROMOID LEFT OUTER JOIN  
                         PARAMETRO on 1 = 1  LEFT OUTER JOIN 
                         (
                            SELECT PRODUCTOID, SUM(CASE WHEN INVENTARIO.CANTIDAD IS NULL THEN 0 ELSE INVENTARIO.CANTIDAD END ) CANTIDAD FROM INVENTARIO 
                            WHERE @ALMACENID = 0 OR @ALMACENID  = (CASE WHEN INVENTARIO.ALMACENID IS NULL THEN 1 ELSE INVENTARIO.ALMACENID END) 
                            GROUP BY PRODUCTOID
                         ) INVENTARIO ON INVENTARIO.PRODUCTOID = PRODUCTO.ID
          ";

                //WHERE @ALMACENID = 0 OR(CASE WHEN @ALMACENID IS NULL THEN 1 ELSE @ALMACENID END) = (CASE WHEN INVENTARIO.ALMACENID IS NULL THEN 1 ELSE INVENTARIO.ALMACENID END)
                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = almacenId;
                parts.Add(auxPar);


                if (doctoId != 0)
                {
                    string strJoinAdicional = @" WHERE PRODUCTO.ID IN  ( SELECT PRODUCTOFINAL.ID AS PRODUCTOID FROM PRODUCTO PRODUCTOFINAL 
                                         INNER JOIN MOVTO MOVTOFINAL ON MOVTOFINAL.PRODUCTOID = PRODUCTOFINAL.ID
                                         WHERE MOVTOFINAL.DOCTOID = @DOCTOID AND PRODUCTO.CLAVE NOT LIKE 'EMIDA-%' AND (PRODUCTO.EMIDAPRODUCTOID IS NULL OR PRODUCTO.EMIDAPRODUCTOID = 0)
                           UNION
                           SELECT PRODUCTOPADRE.PRODUCTOPADRE AS PRODUCTOID FROM PRODUCTO PRODUCTOPADRE 
                                         INNER JOIN MOVTO MOVTOPADRE ON MOVTOPADRE.PRODUCTOID = PRODUCTOPADRE.ID
                                         WHERE MOVTOPADRE.DOCTOID = @DOCTOID
                         )
                        order by PRODUCTO.ID";
                    CmdTxt += strJoinAdicional;
                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Value = doctoId;
                    parts.Add(auxPar);
                }
                else
                {
                    CmdTxt += " WHERE ";
                    if (exportProductInactive)
                        CmdTxt += " (COALESCE(PRODUCTO.ACTIVO, 'S') = 'S'  or COALESCE(PRODUCTO.EXISTENCIA, 0) > 0) ";
                    else
                        CmdTxt += " COALESCE(PRODUCTO.ACTIVO, 'S') = 'S' ";


                    CmdTxt += "  AND PRODUCTO.CLAVE NOT LIKE 'EMIDA-%' AND (PRODUCTO.EMIDAPRODUCTOID IS NULL OR PRODUCTO.EMIDAPRODUCTOID = 0) " +
                        " ";
                }


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CPRODBE();

                    /*if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMPRA = (int)dr["FOLIO"];
                    }*/



                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["CLAVE"]);

                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }


                    if ((bool)m_dbfBE.isnull["IPRODUCTO"] || m_dbfBE.IPRODUCTO.Trim() == "")
                        continue;


                    try
                    {
                        if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                        {
                            m_dbfBE.IFCAMBIO = (DateTime)dr["FECHACAMBIOPRECIO"];
                        }
                        else
                        {
                            m_dbfBE.IFCAMBIO = DateTime.Now;
                        }
                    }
                    catch
                    {
                        m_dbfBE.IFCAMBIO = DateTime.Now;
                    }



                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC = (string)(dr["DESCRIPCION"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IDESC3 = (string)(dr["DESCRIPCION3"]);
                    }
                    if (dr["CLAVELINEA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILINEA = (string)(dr["CLAVELINEA"]);
                    }
                    if (dr["NOMBRELINEA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILINEANOMBRE = (string)(dr["NOMBRELINEA"]);
                    }
                    if (dr["CLAVEMARCA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMARCA = (string)(dr["CLAVEMARCA"]);
                    }
                    if (dr["NOMBREMARCA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMARCANOMBRE = (string)(dr["NOMBREMARCA"]);
                    }



                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO1 = Decimal.ToDouble((decimal)(dr["PRECIO1"]));
                    }
                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO2 = Decimal.ToDouble((decimal)(dr["PRECIO2"]));
                    }
                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO3 = Decimal.ToDouble((decimal)(dr["PRECIO3"]));
                    }
                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO4 = Decimal.ToDouble((decimal)(dr["PRECIO4"]));
                    }
                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO5 = Decimal.ToDouble((decimal)(dr["PRECIO5"]));
                    }
                    if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIO6 = Decimal.ToDouble((decimal)(dr["PRECIOSUGERIDO"]));
                    }

                    if (dr["PRECIOTOPE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECTOPE = Decimal.ToDouble((decimal)(dr["PRECIOTOPE"]));
                    }

                    if (dr["CLAVEMONEDA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMONEDA = (string)(dr["CLAVEMONEDA"]);
                    }



                    if (dr["CLAVETASAIVA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICVETASAIVA = (string)(dr["CLAVETASAIVA"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPUESTO = Decimal.ToDouble((decimal)(dr["TASAIVA"]));
                    }
                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOSTOREPUS = Decimal.ToDouble((decimal)(dr["COSTOREPOSICION"]));
                        m_dbfBE.ICOSTO_REPO = Decimal.ToDouble((decimal)(dr["COSTOREPOSICION"]));
                    }
                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOSTO_ULTI = Decimal.ToDouble((decimal)(dr["COSTOULTIMO"]));
                    }
                    //if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICOSTOULTUS = Decimal.ToDouble((decimal)(dr["COSTOULTIMO"]));
                    //}



                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICODIGO = (string)(dr["EAN"]);
                    }


                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILOTE = (string)(dr["MANEJALOTE"]);
                    }
                    else
                    {
                        m_dbfBE.ILOTE = "N";
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        m_dbfBE.IKIT = (string)(dr["ESKIT"]);
                    }


                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }
                    else
                    {
                        m_dbfBE.IIMPRIMIR = "N";
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IINVENTARIO = (string)(dr["INVENTARIABLE"]);

                    }
                    else
                    {
                        m_dbfBE.IINVENTARIO = "N";
                    }


                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        m_dbfBE.INEGATIVOS = (string)dr["NEGATIVOS"];
                    }
                    else
                    {
                        m_dbfBE.INEGATIVOS = "N";
                    }
                    //m_dbfBE.INEGATIVOS = "S";




                    if (dr["CLAVEPRODUCTOSUBSTITUTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISUSTITUTO = (string)(dr["CLAVEPRODUCTOSUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICBARRAS = (string)(dr["CBARRAS"]);
                    }


                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
                    }


                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPZACAJA = Decimal.ToDouble((decimal)(dr["PZACAJA"]));
                    }


                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IU_EMPAQUE = Decimal.ToDouble((decimal)(dr["U_EMPAQUE"]));
                    }


                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IUNIDAD = (string)(dr["UNIDAD"]);
                    }


                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IINIMAYO = Decimal.ToDouble((decimal)(dr["INI_MAYO"]));
                    }


                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMAYOXKG = (string)(dr["MAYOKGS"]);
                    }
                    else
                    {
                        m_dbfBE.IMAYOXKG = "N";
                    }



                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITIPOABC = (string)(dr["TIPOABC"]);
                    }
                    else
                    {
                        m_dbfBE.ITIPOABC = "N";
                    }




                    if (dr["CLAVEPROVEEDOR1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR = (string)(dr["CLAVEPROVEEDOR1"]);
                    }




                    if (dr["NOMBREPROVEEDOR1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDORNOMBRE = (string)(dr["NOMBREPROVEEDOR1"]);
                    }

                    if (dr["CLAVEPROVEEDOR2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR2 = (string)(dr["CLAVEPROVEEDOR2"]);
                    }


                    if (dr["CLAVEPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODPADRE = (string)(dr["CLAVEPRODUCTOPADRE"]);
                    }



                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILIMITE2 = Decimal.ToDouble((decimal)(dr["LIMITEPRECIO2"]));
                    }


                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }
                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }
                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }
                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }
                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }
                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITEXTO6 = (string)(dr["TEXTO6"]);
                    }



                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO1 = Decimal.ToDouble((decimal)(dr["NUMERO1"]));
                    }
                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO2 = Decimal.ToDouble((decimal)(dr["NUMERO2"]));
                    }
                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO3 = Decimal.ToDouble((decimal)(dr["NUMERO3"]));
                    }
                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.INUMERO4 = Decimal.ToDouble((decimal)(dr["NUMERO4"]));
                    }



                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }
                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }




                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }


                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }


                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESSUBPROD = (string)(dr["ESSUBPRODUCTO"]);
                    }


                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }



                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMIPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }


                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IOFEPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }


                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMISION = Decimal.ToDouble((decimal)(dr["COMISION"]));
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IOFERTA = Decimal.ToDouble((decimal)(dr["OFERTA"]));
                    }



                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICAMBIARPRE = (string)(dr["CAMBIARPRECIO"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPLUG = (string)(dr["PLUG"]);
                    }

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        m_dbfBE.ITASAIEPS = Decimal.ToDouble((decimal)(dr["TASAIEPS"]));
                    }


                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMINUTIL = Decimal.ToDouble((decimal)(dr["MINUTILIDAD"]));
                    }

                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO1 = Decimal.ToDouble((decimal)(dr["SPRECIO1"]));
                    }
                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO2 = Decimal.ToDouble((decimal)(dr["SPRECIO2"]));
                    }
                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO3 = Decimal.ToDouble((decimal)(dr["SPRECIO3"]));
                    }
                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO4 = Decimal.ToDouble((decimal)(dr["SPRECIO4"]));
                    }
                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.ISPRECIO5 = Decimal.ToDouble((decimal)(dr["SPRECIO5"]));
                    }


                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRRECETA = (string)(dr["REQUIERERECETA"]);
                    }



                    if (dr["PRECIOMAT"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    }




                    if (dr["MENUDEO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMENUDEO = Decimal.ToInt32((decimal)(dr["MENUDEO"]));
                    }


                    if (dr["CLAVE_CONTENIDO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVE_CONT = (string)(dr["CLAVE_CONTENIDO"]);
                    }


                    if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICONTENIDO = Decimal.ToDouble((decimal)(dr["CONTENIDOVALOR"]));
                    }


                    if (dr["CLAVE_CLASIFICA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLASIFICA = (string)(dr["CLAVE_CLASIFICA"]);
                    }


                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }


                    if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICANTXPIEZA = Decimal.ToDouble((decimal)(dr["CANTXPIEZA"]));
                    }




                    if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILOTEIMPO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    }

                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOSTOUSD = Decimal.ToDouble((decimal)(dr["COSTOENDOLAR"]));
                    }



                    if (dr["PLAZOCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPLAZO = (string)(dr["PLAZOCLAVE"]);
                    }

                    if (dr["SAT_CLAVEPRODSERV"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLAVESAT = dr["SAT_CLAVEPRODSERV"].ToString();
                    }



                    if (dr["CLAVEBASEPRODPROMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IBASEPROM = dr["CLAVEBASEPRODPROMO"].ToString();
                    }


                    if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IESPRODPROM = dr["ESPRODPROMO"].ToString();
                    }


                    if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIGPROM = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    }



                    if ( almacenId == 0 && dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IEXIS1 = Decimal.ToDouble((decimal)(dr["EXISTENCIA"]));
                    }
                    else if(almacenId != 0 && dr["INVENTARIOEXISTENCIA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IEXIS1 = Decimal.ToDouble((decimal)(dr["INVENTARIOEXISTENCIA"]));
                    }


                    if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVIGKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    }


                    if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    {
                        m_dbfBE.IKITCVIG = dr["KITTIENEVIG"].ToString();
                    }

                    if (dr["VALXSUC"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVALXSUC = dr["VALXSUC"].ToString();
                    }

                    if (dr["KITIMPFIJO"] != System.DBNull.Value)
                    {
                        string strKitImpFijo = (string)dr["KITIMPFIJO"];
                        m_dbfBE.IDESGKIT = strKitImpFijo != null && strKitImpFijo.Equals("S") ? false : true;
                    }


                    if (dr["PORCUTILPRECIO1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO1 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO1"]));
                    }
                    if (dr["PORCUTILPRECIO2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO2 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO2"]));
                    }
                    if (dr["PORCUTILPRECIO3"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO3 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO3"]));
                    }
                    if (dr["PORCUTILPRECIO4"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO4 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO4"]));
                    }
                    if (dr["PORCUTILPRECIO5"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPUPRECIO5 = Decimal.ToDouble((decimal)(dr["PORCUTILPRECIO5"]));
                    }
                    if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIMPCOM = (string)(dr["IMPRIMIRCOMANDA"]);
                    }


                    if (dr["COSTOREPOSICION_CONIMP"] != System.DBNull.Value)
                    {
                        m_dbfBE.IC_R_I = Decimal.ToDouble((decimal)(dr["COSTOREPOSICION_CONIMP"]));
                    }

                    if (dr["COSTOULTIMO_CONIMP"] != System.DBNull.Value)
                    {
                        m_dbfBE.IC_U_I = Decimal.ToDouble((decimal)(dr["COSTOULTIMO_CONIMP"]));
                    }

                    if (dr["COSTOPROMEDIO_CONIMP"] != System.DBNull.Value)
                    {
                        m_dbfBE.IC_P_I = Decimal.ToDouble((decimal)(dr["COSTOPROMEDIO_CONIMP"]));
                    }



                    try
                    {
                        if (dr["ULTIMACOMPRA"] != System.DBNull.Value)
                        {
                            m_dbfBE.IULTIMACOMPRA = (DateTime)dr["ULTIMACOMPRA"];
                        }
                    }
                    catch{}


                    try
                    {
                        if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                        {
                            m_dbfBE.IULTIMAVENTA = (DateTime)dr["ULTIMAVENTA"];
                        }
                    }
                    catch { }

                    try
                    {

                        if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
                        {
                            m_dbfBE.ILMEDMAY = int.Parse(dr["LISTAPRECMEDIOMAYID"].ToString());
                        }

                        if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
                        {
                            m_dbfBE.ILMAYO = int.Parse(dr["LISTAPRECMAYOREOID"].ToString());
                        }

                        if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
                        {
                            m_dbfBE.ICMEDMAY = Decimal.ToDouble((decimal)(dr["CANTMEDIOMAY"]));
                        }

                        if (dr["CANTMAYOREO"] != System.DBNull.Value)
                        {
                            m_dbfBE.ICMAYO = Decimal.ToDouble((decimal)(dr["CANTMAYOREO"]));
                        }
                    }
                    catch { }

                    

                    //if ((!m_dbfD.AgregarPROD_MOVIL(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    if ((!m_dbfD.AgregarPROD_MOVIL(m_dbfBE, strTableExpNameDet,  strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }



                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool exportarAFTP_MovilCliente(string strTableExpNameDet, CPERSONABE vendedor, FbTransaction st, OleDbTransaction odt, string strOleDbConn, string version = "DBF")
        {
            CM_CLIPBE fbItem = new CM_CLIPBE();

            //CM_CLIPD m_dbfD = new CM_CLIPD();
            IMCLIPD m_dbfD = null;
            CM_CLIPBE m_dbfBE = new CM_CLIPBE();
            
            if (version != null && version.Equals(ExportacionesConstants.m_versionExportacionSQLite))
            {
                m_dbfD = new CMCLIP_SQLITE_D();
                ((CMCLIP_SQLITE_D)m_dbfD).CreateTableMCLIP_MOVIL(strOleDbConn);
                
            }
            else
                m_dbfD = new CM_CLIPD();

            //bool retorno = true;
            this.iComentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                CPERSONAD personaD = new CPERSONAD();
                CPERSONABE personaBE = new CPERSONABE();
                personaBE.IVENDEDORID = vendedor.IID;
                personaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
                List<CPERSONABE> listPersona = personaD.seleccionarPERSONASxVENDEDOR(personaBE, null);

                if(listPersona == null)
                {
                    this.iComentario += "No se pudo leer la lista de clientes " + personaD.iComentario + "\n";
                    return false;
                }


                foreach(CPERSONABE cliente in listPersona)
                {
                    m_dbfBE = iPos.ImportaFtpMovil.convertCLienteIntoCLIP(cliente);

                    if ((!m_dbfD.AgregarM_CLIPD(m_dbfBE, strTableExpNameDet, 
                                                    //odt, 
                                                    strOleDbConn)))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += m_dbfD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool ELIMINARPEDIDO(long doctoId, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;







                auxPar = new FbParameter("@DOCTOID", FbDbType.Decimal);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                string commandText = @"DELETE_PEDIDO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public bool exportarAFTP_PEDIDOS(CPARAMETROBE parametroBE, CCAJABE cajaBE, long lSucursalId, DateTime Fecha, DateTime FechaTo, bool bForzado, string strIDDosLetras, FbTransaction st, bool bAutomatico, ref long lPedidoDoctoId, ref string dbFileNameDetalle, ref CEXP_FILESBE filesExpBE)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_VEDSD vedsD = new CM_VEDSD();
            CM_VEDSBE vedsBE = new CM_VEDSBE();

            CM_VENSBE vensBE = new CM_VENSBE();
            CM_VENSD vensD = new CM_VENSD();

            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            //long lPedidoDoctoId = 0;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;


            if (lPedidoDoctoId == 0)
            {
                //
                try
                {
                    parts = new ArrayList();

                    auxPar = new FbParameter("@sucursalid", FbDbType.BigInt);
                    auxPar.Value = lSucursalId;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@fecha", FbDbType.Date);
                    auxPar.Value = Fecha;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@cajeroid", FbDbType.BigInt);
                    auxPar.Value = iPos.CurrentUserID.CurrentUser.IID;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@forzado", FbDbType.Char);
                    auxPar.Value = (bForzado) ? 'S' : 'N';
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@fechato", FbDbType.Date);
                    auxPar.Value = FechaTo;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@EXP_FILESID", FbDbType.BigInt);
                    auxPar.Value = DBNull.Value;
                    if (filesExpBE != null)
                    {
                        if (!(bool)filesExpBE.isnull["IID"])
                        {
                            auxPar.Value = filesExpBE.IID;
                        }
                    }
                    parts.Add(auxPar);




                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Direction = ParameterDirection.Output;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                    auxPar.Direction = ParameterDirection.Output;
                    parts.Add(auxPar);

                    string commandText = @"GENERAR_PEDIDO";

                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (st == null)
                        SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                    else
                        SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                    if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                    {
                        if ((int)arParms[arParms.Length - 1].Value != 0)
                        {
                            if ((int)arParms[arParms.Length - 1].Value == 1058)
                            {
                                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                                this.iComentario = "Observacion: No hay registros a procesar para el dia " + Fecha.ToString("dd/MM/yyyy");// +" turno  " + lTurnoId.ToString("N0");
                                return false;
                            }
                            else
                            {
                                string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                                this.iComentario = "Hubo un error " + strMensajeErr;
                            }
                            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                            return false;
                        }
                    }

                    if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                    {
                        lPedidoDoctoId = (long)arParms[arParms.Length - 2].Value;
                        filesExpBE.IDOCTOID = lPedidoDoctoId;
                        //lReenviarPedidoExistente = lPedidoDoctoId;

                    }
                    else
                    {
                        this.IComentario = "no hay registros a procesar";
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        return true;
                    }




                }
                catch (Exception e)
                {
                    this.iComentario = e.Message + e.StackTrace;
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                    return false;
                }
            }
            else
            {
                //lPedidoDoctoId = lReenviarPedidoExistente;
            }


            if (!bAutomatico)
            {
                iPos.WFExportarPedidosDet ep = new iPos.WFExportarPedidosDet(lPedidoDoctoId, 0);
                ep.ShowDialog();
                bool bCancelar = ep.m_bCancelar;
                ep.Dispose();
                GC.SuppressFinalize(ep);

                if (bCancelar)
                {
                    this.IComentario = "el usuario cancelo la operacion";
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                    return false;
                }
            }


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE pedidoBE = new CDOCTOBE();
            pedidoBE.IID = lPedidoDoctoId;
            pedidoBE = doctoD.seleccionarDOCTO(pedidoBE,null);
                if (pedidoBE == null)
                {
                    this.IComentario = "parece que el pedido no existe";
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                    return false;
                }

            string path = "";
            string dbFileNameHeader = "";

            if (pedidoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
            {

                string claveSucDest = "";
                claveSucDest = ObtenerClaveSucursalDestinoXId(pedidoBE.ISUCURSALTID);
                path = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';
                dbFileNameDetalle = pedidoBE.ISERIE + pedidoBE.IFOLIO.ToString("0").PadLeft(7, '0') + "." + CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
                dbFileNameHeader = dbFileNameDetalle.Replace(FileNamePedidosDetalleFTP, FileNamePedidosHeaderFTP);
            }
            else
            {

                path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;
                dbFileNameDetalle = pedidoBE.ISERIE + pedidoBE.IFOLIO.ToString("0").PadLeft(7, '0') + ".dbf";
                dbFileNameHeader = dbFileNameDetalle.Replace(FileNamePedidosDetalleFTP, FileNamePedidosHeaderFTP);
            }
            

            CopyEmtpyTablesComprasYDevolucionesV2(parametroBE, cajaBE, FechaTo, dbFileNameDetalle, path);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
            string strDbFileName = pedidoBE.ISERIE + pedidoBE.IFOLIO.ToString("0").PadLeft(7, '0');






            try
            {
                parts = new ArrayList();
                
                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                DOCTO.FOLIO FOLIO,
                                                VENDEDOR.USERNAME CVEUSER
                                                
                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid  LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID
                                    WHERE        DOCTO.ID = @DOCTOID
                                    ORDER BY DOCTOID, MOVTOID";

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lPedidoDoctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    vedsBE = new CM_VEDSBE();

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vedsBE.ICLIENTE = ((string)(dr["SUCURSAL"])).PadLeft(6, '0');
                    }
                    else
                        vedsBE.ICLIENTE = "";
                    
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        vedsBE.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRODUCTO = (string)(dr["PRODUCTO"]);

                        if (vedsBE.IPRODUCTO == "")
                            continue;
                    }
                    else
                    {
                        continue;
                    }
                    /*if (dr["DE_REQUERIDO"] != System.DBNull.Value)
                    {
                        vedmBE.IREQUERIDO = (decimal)(dr["DE_REQUERIDO"]);
                    }*/
                    /*if (dr["PV_PROVEEDOR"] != System.DBNull.Value)
                    {
                        vedsBE.IPROVEEDOR = (string)(dr["PV_PROVEEDOR"]);
                    }
                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        vedsBE.ILINEA = (string)(dr["LINEA"]);
                    }
                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        vedsBE.IMARCA = (string)(dr["MARCA"]);
                    }*/
                    /*if (dr["VD_VENDEDOR"] != System.DBNull.Value)
                    {
                        vedmBE.IVENDEDOR = (string)(dr["VD_VENDEDOR"]);
                    }
                    if (dr["DE_TIPO"] != System.DBNull.Value)
                    {
                        vedmBE.ITIPO = (string)(dr["DE_TIPO"]);
                    }
                    if (dr["DE_CLASIFICA"] != System.DBNull.Value)
                    {
                        vedmBE.ICLASIFICA = (string)(dr["DE_CLASIFICA"]);
                    }*/
                    /*if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRECIO = (decimal)(dr["PRECIO"]);
                    }
                    if (dr["PRECIO_LISTA"] != System.DBNull.Value)
                    {
                        vedsBE.IPREC_LISTA = (decimal)(dr["PRECIO_LISTA"]);
                    }*/
                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        
                        vedsBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }/*
                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        vedsBE.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }
                    if (dr["IMPORTE_NETO"] != System.DBNull.Value)
                    {
                        vedsBE.IIMPORTNETO = (decimal)(dr["IMPORTE_NETO"]);
                    }
                    if (dr["COSTO_PU"] != System.DBNull.Value)
                    {
                        vedsBE.ICOSTO_PU = (decimal)(dr["COSTO_PU"]);
                    }
                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vedsBE.ITIENDA = (decimal)(dr["SUCURSAL"]);
                    }
                    if (dr["COSTO_TOTAL"] != System.DBNull.Value)
                    {
                        vedsBE.ICOSTOTAL = (decimal)(dr["COSTO_TOTAL"]);
                    }
                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        vedsBE.ICOMISION = (decimal)(dr["COMISION"]);
                    }
                    if (dr["DEVUELTAS"] != System.DBNull.Value)
                    {
                        vedsBE.IDEVUELTAS = (decimal)(dr["DEVUELTAS"]);
                    }*/
                    /*if (dr["DE_TRANSA"] != System.DBNull.Value)
                    {
                        vedmBE.ITRANSA = Int64.Parse(dr["DE_TRANSA"].ToString());
                    }*/
                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        vedsBE.IVENTA = strIDDosLetras.Trim().PadLeft(2,'-') + dr["FOLIO"].ToString().PadLeft(4, '0');
                    }
                    
                    vedsBE.IDESCUENTO = 0;
                  
                    /*if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        vedsBE.IPARTIDA = int.Parse(dr["PARTIDA"].ToString());
                    }*/
                    //if (dr["DE_LOTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ilote = (string)(dr["DE_LOTE"]);
                    //}
                    //if (dr["DE_DEVUELTO_NC"] != System.DBNull.Value)
                    //{
                    //    vedmBE. = (decimal)(dr["DE_DEVUELTO_NC"]);
                    //}

                    //if (dr["DE_EXPORTADO"] != System.DBNull.Value)
                    //{
                    //    retorno.IDE_EXPORTADO = (string)(dr["DE_EXPORTADO"]);
                    //}
                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        vedsBE.IDESC1 = dr["DESCRIPCION"].ToString();
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        vedsBE.IDESC2 = dr["DESCRIPCION2"].ToString();
                    }
                    else
                    {
                        vedsBE.IDESC2 = "";
                    }


                    if (dr["CVEUSER"] != System.DBNull.Value)
                    {
                        vedsBE.ICVEUSER = dr["CVEUSER"].ToString();
                    }
                    else
                    {
                        vedsBE.ICVEUSER = "";
                    }

                    //if (dr["DE_HORA"] != System.DBNull.Value)
                    //{
                    vedsBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    //}

                    vedsBE.IID = "CAJA";
                    if (!vedsD.AgregarM_VEDSD(vedsBE, strDbFileName, null, strOleDbConn))
                    {

                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += vedsD.IComentario + "\n";
                        return false;
                    }

                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = lPedidoDoctoId;
                    doctoBE.ITRASLADOAFTP = DBValues._DB_VALUE_FTPGENERADO;
                    if (!doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += doctoD.IComentario + "\n";
                        return false;
                    }
                }




                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                

                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


            /*
            try
            {

                parts = new ArrayList();
                
                //String CmdTxt = @"select d.*,p.pd_descripcion1 from DETALLE_DE_VENTAS d inner join productos p on d.pd_producto == p.pd_producto where DE_FECHA = @DE_FECHA and DE_EXPROTADO <> 'S'";
                CmdTxt = @"                                   SELECT       DOCTO.ID AS DOCTOID,
                                                SUCURSAL.CLAVE AS  SUCURSAL,
                                                DOCTO.FECHA AS FECHA  ,
                                                TURNO.nombre NOMBRETURNO,
                                                PERSONA.clave CLAVECLIENTE,
                                                DOCTO.FOLIO FOLIO

                                   FROM         DOCTO  left OUTER JOIN
                                                SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid  LEFT JOIN
                                                turno  ON TURNO.id = docto.turnoid   LEFT JOIN
                                                PERSONA ON PERSONA.ID = DOCTO.personaid
                                    WHERE       DOCTO.ID = @DOCTOID
                                    ORDER BY    DOCTOID";
                
                

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lPedidoDoctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vensBE.ICLIENTE = ((string)(dr["SUCURSAL"])).PadLeft(6, '0');
                    }


                    if (dr["NOMBRETURNO"] != System.DBNull.Value)
                    {
                        vensBE.INOTA1 = (string)(dr["NOMBRETURNO"]);
                    }



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        vensBE.IVENTA = strIDDosLetras.Trim().PadLeft(2, '-') + dr["FOLIO"].ToString().PadLeft(4, '0');
                    }


                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vensBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                        vensBE.IF_FACTURA = (DateTime)(dr["FECHA"]);
                    }

                    vensBE.IID = "CAJA";
                    vensBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();

                    vensBE.IESTATUS = "R";

                    if (vensD.AgregarM_VENSD(vensBE, strTableExpNameHdr, odt, strOleDbConn) == null)
                    {
                        this.iComentario += vensD.IComentario + "\n";
                        return false;
                    }

                }
                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }*/

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
                    parts.Add(auxPar);
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


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.ILOCALIDAD;
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







                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_DBFLINE_PARAEXPORTAR";

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




        public long ImportarPedidosFromDBF(string fileDBF, string path, CPARAMETROBE parametros, CPERSONABE usuario)
        {
            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  " + fileDBF;
            OleDbDataReader dr;
            dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CIMPORTAR_DBF_LINE_SPBE importCompras;

            string strVentaAnterior = "";
            string strVentaActual = "";

            long doctoIDAnterior = 0;


            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
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
                    /*if (dr["LOTE"] != System.DBNull.Value)
                    {
                        importCompras.ILOTE = (string)(dr["LOTE"]);
                    }*/
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        importCompras.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                    }
                    /*if (dr["FECHA"] != System.DBNull.Value)
                    {
                        try
                        {
                            importCompras.IFECHAVENCE = DateTime.Parse(dr["F_CADUCA"].ToString());
                        }
                        catch
                        {
                        }
                    }*/

                    importCompras.ISUCURSALID = parametros.ISUCURSALID;

                    
                    /*if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        importCompras.IPROVEEDOR = (string)(dr["CLIENTE"]);
                    }*/


                    //if (dr["IVA"] != System.DBNull.Value)
                    //{
                    //    importCompras= (string)(dr["IVA"]);
                    //}


                    //importCompras.IREFERENCIAS = fileItem.IIF_FILE;


                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        importCompras.ILOCALIDAD = dr["LOCALIDAD"].ToString();
                    }

                    importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_COMPRA;
                    importCompras.IALMACENTID = DBValues._DOCTO_ALMACEN_DEFAULT;
                    importCompras.IUSERID = iPos.CurrentUserID.CurrentUser.IID;
                    importCompras.IPROVEEDOR = iPos.CurrentUserID.CurrentUser.ICLAVE;

                    if (IMPORTAR_DBF_LINE_SPD(importCompras, fTrans, ref doctoIDAnterior) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return 0;
                    }

                }

                /*CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoIDAnterior;
                doctoD.CerrarDOCTOD(doctoBE, fTrans);*/

                //fTrans.Commit();
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();
                this.iComentario = ex.Message + ex.StackTrace;
                return 0;
            }
            finally
            {
                //fConn.Close();
            }
            return doctoIDAnterior;

        }

        public bool exportarAFTP_PEDIDOS_FROM_DBF(long lSucursalId, DateTime Fecha/*, long lTurnoId*/, bool bForzado, string strTableExpNameDet, string strTableExpNameHdr, string strIDDosLetras, FbTransaction st, OleDbTransaction odt, string strOleDbConn, bool bAutomatico, long lReenviarPedidoExistente)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_VEDSD vedsD = new CM_VEDSD();
            CM_VEDSBE vedsBE = new CM_VEDSBE();

            CM_VENSBE vensBE = new CM_VENSBE();
            CM_VENSD vensD = new CM_VENSD();

            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            long lPedidoDoctoId = 0;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            string pathData = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos_Crescendo;
            string dbFileNameData = FileNamePedidosDetalleCrescendoFTP ;/*FileNamePedidosDetalleFTP + DateTime.Today.ToString("ddMM");//*/ 


            if (lReenviarPedidoExistente == 0)
            {
                //
                try
                {
                    lPedidoDoctoId = ImportarPedidosFromDBF(dbFileNameData + ".dbf", pathData, iPos.CurrentUserID.CurrentParameters, iPos.CurrentUserID.CurrentUser);

                }
                catch (Exception e)
                {
                    this.iComentario = e.Message + e.StackTrace;
                    return false;
                }
            }
            else
            {
                lPedidoDoctoId = lReenviarPedidoExistente;
            }


            if (!bAutomatico)
            {
                iPos.WFExportarPedidosDet ep = new iPos.WFExportarPedidosDet(lPedidoDoctoId, 0);
                ep.ShowDialog();
                ep.Focus();
                bool bCancelar = ep.m_bCancelar;
                ep.Dispose();
                GC.SuppressFinalize(ep);

                if (bCancelar)
                {
                    this.IComentario = "el usuario cancelo la operacion";
                    return false;
                }
            }


            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                DOCTO.FOLIO FOLIO,
                                                VENDEDOR.USERNAME CVEUSER
                                                
                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid  LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID
                                    WHERE        DOCTO.ID = @DOCTOID
                                    ORDER BY DOCTOID, MOVTOID";

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lPedidoDoctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    vedsBE = new CM_VEDSBE();

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vedsBE.ICLIENTE = ((string)(dr["SUCURSAL"])).PadLeft(6, '0');
                    }
                    else
                        vedsBE.ICLIENTE = "";

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        vedsBE.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }
                    /*if (dr["DE_REQUERIDO"] != System.DBNull.Value)
                    {
                        vedmBE.IREQUERIDO = (decimal)(dr["DE_REQUERIDO"]);
                    }*/
                    /*if (dr["PV_PROVEEDOR"] != System.DBNull.Value)
                    {
                        vedsBE.IPROVEEDOR = (string)(dr["PV_PROVEEDOR"]);
                    }
                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        vedsBE.ILINEA = (string)(dr["LINEA"]);
                    }
                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        vedsBE.IMARCA = (string)(dr["MARCA"]);
                    }*/
                    /*if (dr["VD_VENDEDOR"] != System.DBNull.Value)
                    {
                        vedmBE.IVENDEDOR = (string)(dr["VD_VENDEDOR"]);
                    }
                    if (dr["DE_TIPO"] != System.DBNull.Value)
                    {
                        vedmBE.ITIPO = (string)(dr["DE_TIPO"]);
                    }
                    if (dr["DE_CLASIFICA"] != System.DBNull.Value)
                    {
                        vedmBE.ICLASIFICA = (string)(dr["DE_CLASIFICA"]);
                    }*/
                    /*if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRECIO = (decimal)(dr["PRECIO"]);
                    }
                    if (dr["PRECIO_LISTA"] != System.DBNull.Value)
                    {
                        vedsBE.IPREC_LISTA = (decimal)(dr["PRECIO_LISTA"]);
                    }*/
                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vedsBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }/*
                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        vedsBE.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }
                    if (dr["IMPORTE_NETO"] != System.DBNull.Value)
                    {
                        vedsBE.IIMPORTNETO = (decimal)(dr["IMPORTE_NETO"]);
                    }
                    if (dr["COSTO_PU"] != System.DBNull.Value)
                    {
                        vedsBE.ICOSTO_PU = (decimal)(dr["COSTO_PU"]);
                    }
                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vedsBE.ITIENDA = (decimal)(dr["SUCURSAL"]);
                    }
                    if (dr["COSTO_TOTAL"] != System.DBNull.Value)
                    {
                        vedsBE.ICOSTOTAL = (decimal)(dr["COSTO_TOTAL"]);
                    }
                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        vedsBE.ICOMISION = (decimal)(dr["COMISION"]);
                    }
                    if (dr["DEVUELTAS"] != System.DBNull.Value)
                    {
                        vedsBE.IDEVUELTAS = (decimal)(dr["DEVUELTAS"]);
                    }*/
                    /*if (dr["DE_TRANSA"] != System.DBNull.Value)
                    {
                        vedmBE.ITRANSA = Int64.Parse(dr["DE_TRANSA"].ToString());
                    }*/
                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        vedsBE.IVENTA = strIDDosLetras.Trim().PadLeft(2, '-') + dr["FOLIO"].ToString().PadLeft(4, '0');
                    }

                    vedsBE.IDESCUENTO = 0;

                    /*if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        vedsBE.IPARTIDA = int.Parse(dr["PARTIDA"].ToString());
                    }*/
                    //if (dr["DE_LOTE"] != System.DBNull.Value)
                    //{
                    //    vedmBE.ilote = (string)(dr["DE_LOTE"]);
                    //}
                    //if (dr["DE_DEVUELTO_NC"] != System.DBNull.Value)
                    //{
                    //    vedmBE. = (decimal)(dr["DE_DEVUELTO_NC"]);
                    //}

                    //if (dr["DE_EXPORTADO"] != System.DBNull.Value)
                    //{
                    //    retorno.IDE_EXPORTADO = (string)(dr["DE_EXPORTADO"]);
                    //}
                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        vedsBE.IDESC1 = dr["DESCRIPCION"].ToString();
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        vedsBE.IDESC2 = dr["DESCRIPCION2"].ToString();
                    }
                    else
                    {
                        vedsBE.IDESC2 = "";
                    }

                    if (dr["CVEUSER"] != System.DBNull.Value)
                    {
                        vedsBE.ICVEUSER = dr["CVEUSER"].ToString();
                    }
                    else
                    {
                        vedsBE.ICVEUSER = "";
                    }

                    //if (dr["DE_HORA"] != System.DBNull.Value)
                    //{
                    vedsBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    //}

                    vedsBE.IID = "CAJA";
                    if (!vedsD.AgregarM_VEDSD(vedsBE, strTableExpNameDet, odt, strOleDbConn))
                    {

                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += vedsD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                //return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }



            try
            {

                parts = new ArrayList();

                //String CmdTxt = @"select d.*,p.pd_descripcion1 from DETALLE_DE_VENTAS d inner join productos p on d.pd_producto == p.pd_producto where DE_FECHA = @DE_FECHA and DE_EXPROTADO <> 'S'";
                CmdTxt = @"                                   SELECT       DOCTO.ID AS DOCTOID,
                                                SUCURSAL.CLAVE AS  SUCURSAL,
                                                DOCTO.FECHA AS FECHA  ,
                                                TURNO.nombre NOMBRETURNO,
                                                PERSONA.clave CLAVECLIENTE,
                                                DOCTO.FOLIO FOLIO

                                   FROM         DOCTO  left OUTER JOIN
                                                SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid  LEFT JOIN
                                                turno  ON TURNO.id = docto.turnoid   LEFT JOIN
                                                PERSONA ON PERSONA.ID = DOCTO.personaid
                                    WHERE       DOCTO.ID = @DOCTOID
                                    ORDER BY    DOCTOID";



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lPedidoDoctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vensBE.ICLIENTE = ((string)(dr["SUCURSAL"])).PadLeft(6, '0');
                    }


                    if (dr["NOMBRETURNO"] != System.DBNull.Value)
                    {
                        vensBE.INOTA1 = (string)(dr["NOMBRETURNO"]);
                    }



                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        vensBE.IVENTA = strIDDosLetras.Trim().PadLeft(2, '-') + dr["FOLIO"].ToString().PadLeft(4, '0');
                    }


                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vensBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                        vensBE.IF_FACTURA = (DateTime)(dr["FECHA"]);
                    }



                    vensBE.IID = "CAJA";
                    vensBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();

                    vensBE.IESTATUS = "R";

                    if (vensD.AgregarM_VENSD(vensBE, strTableExpNameHdr, odt, strOleDbConn) == null)
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += vensD.IComentario + "\n";
                        return false;
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public Boolean ExportPedidosDesdeDBF(CPARAMETROBE parametroBE, CCAJABE cajaBE, DateTime fecha/*, long lTurnoId*/, bool bAutomatico, long lReenviarPedidoExistente)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;
            string dbFileNameDetalle = FileNamePedidosDetalleFTP + fecha.Day.ToString() + ".dbf";//+ lTurnoId.ToString();
            string dbFileNameHeader = FileNamePedidosHeaderFTP + fecha.Day.ToString() + ".dbf";//+ lTurnoId.ToString();

            CopyEmtpyTablesComprasYDevoluciones(parametroBE, cajaBE, fecha/*,lTurnoId*/, dbFileNameDetalle, dbFileNameHeader, path);


            m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;


            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";



            try
            {
                if (!exportarAFTP_PEDIDOS_FROM_DBF(parametroBE.ISUCURSALID, fecha, true, dbFileNameDetalle, dbFileNameHeader, parametroBE.IID_DOSLETRAS, null, null, strOleDbConn, bAutomatico, lReenviarPedidoExistente))
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
            }

            return true;
        }

        public Boolean CopyFromDBFCrescendoTablesComprasYDevoluciones( DateTime fecha)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos_Crescendo;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;
            string dbFileNameDetalle = FileNamePedidosDetalleFTP + fecha.Day.ToString();// +lTurnoId.ToString();
            string dbFileNameHeader = FileNamePedidosHeaderFTP + fecha.Day.ToString();// + lTurnoId.ToString();


            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            if (File.Exists(path + "\\" + dbFileNameDetalle + ".dbf"))
                File.Delete(path + "\\" + dbFileNameDetalle + ".dbf");


            if (File.Exists(path + "\\" + dbFileNameHeader + ".dbf"))
                File.Delete(path + "\\" + dbFileNameHeader + ".dbf");


            if (!File.Exists(pathMolde + "\\" + FileNamePedidosDetalleCrescendoFTP + ".dbf"))
            {
                this.IComentario = "El archivo dbf no existe:" + pathMolde + "\\" + FileNamePedidosDetalleCrescendoFTP + ".dbf";
                return false;
            }

            if (!File.Exists(pathMolde + "\\" + FileNamePedidosHeaderCrescendoFTP + ".dbf"))
            {
                this.IComentario = "El archivo dbf no existe:" + pathMolde + "\\" + FileNamePedidosHeaderCrescendoFTP + ".dbf";
                return false;
            }


            File.Copy(pathMolde + "\\" + FileNamePedidosDetalleCrescendoFTP + ".dbf", path + "\\" + dbFileNameDetalle + ".dbf");
            File.Copy(pathMolde + "\\" + FileNamePedidosHeaderCrescendoFTP + ".dbf", path + "\\" + dbFileNameHeader + ".dbf");


            m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            return true;
        }








        public bool PedidoGenerar(long lSucursalId, long lCajeroId, DateTime Fecha, DateTime FechaTo, bool bForzado, FbTransaction st, ref long lPedidoDoctoId, bool bIncluirApartado, long lSubTipoDoctoId, bool bForzarPedido, long lSucursalTId)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_VEDSD vedsD = new CM_VEDSD();
            CM_VEDSBE vedsBE = new CM_VEDSBE();

            CM_VENSBE vensBE = new CM_VENSBE();
            CM_VENSD vensD = new CM_VENSD();
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            FbParameter[] arParms;


            if (lPedidoDoctoId == 0)
            {
                //
                try
                {
                    parts = new ArrayList();

                    auxPar = new FbParameter("@sucursalid", FbDbType.BigInt);
                    auxPar.Value = lSucursalId;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@fecha", FbDbType.Date);
                    auxPar.Value = Fecha;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@cajeroid", FbDbType.BigInt);
                    auxPar.Value = lCajeroId;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@forzado", FbDbType.Char);
                    auxPar.Value = (bForzado) ? 'S' : 'N';
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@fechato", FbDbType.Date);
                    auxPar.Value = FechaTo;
                    parts.Add(auxPar);



                    auxPar = new FbParameter("@INCLUIRAPARTADO", FbDbType.Char);
                    auxPar.Value = (bIncluirApartado) ? 'S' : 'N';
                    parts.Add(auxPar);






                    auxPar = new FbParameter("@SUBTIPODOCTOID", FbDbType.BigInt);
                    auxPar.Value = lSubTipoDoctoId;
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@FORZARPEDIDO", FbDbType.Char);
                    auxPar.Value = (bForzarPedido) ? 'S' : 'N';
                    parts.Add(auxPar);


                    auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                    auxPar.Value = lSucursalTId;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                    auxPar.Direction = ParameterDirection.Output;
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                    auxPar.Direction = ParameterDirection.Output;
                    parts.Add(auxPar);

                    string commandText = @"GENERAR_PEDIDO";

                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (st == null)
                        SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                    else
                        SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                    if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                    {
                        if ((int)arParms[arParms.Length - 1].Value != 0)
                        {
                            if ((int)arParms[arParms.Length - 1].Value == 1058)
                            {
                                this.iComentario = "Observacion: No hay registros a procesar para el dia " + Fecha.ToString("dd/MM/yyyy");// +" turno  " + lTurnoId.ToString("N0");
                                return false;
                            }
                            else
                            {
                                string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                                this.iComentario = "Hubo un error " + strMensajeErr;
                            }
                            return false;
                        }
                    }

                    if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                    {
                        lPedidoDoctoId = (long)arParms[arParms.Length - 2].Value;

                    }
                    else
                    {
                        this.IComentario = "no hay registros a procesar";
                        return true;
                    }



                }
                catch (Exception e)
                {
                    this.iComentario = e.Message + e.StackTrace;
                    return false;
                }
            }

            return true;
            


        }


        public bool PedidoAgregarEnListaExpo(string dbFileNameDetalle, long lPedidoDoctoId, ref CEXP_FILESBE expFile, DateTime fechaFrom, DateTime fechaTo, long exp_fileid)
        {
            CEXP_FILESD expFileD = new CEXP_FILESD();
            expFile = new CEXP_FILESBE();

            if (exp_fileid == 0)
            {
                expFile.ITIPO = DBValues._EXP_FILES_TIPO_PEDIDO;
                expFile.INOMBRE = dbFileNameDetalle ;
                expFile.IARCHIVOFTP = dbFileNameDetalle ;
                expFile.IFECHA = fechaFrom;
                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                expFile.IDOCTOID = lPedidoDoctoId;
                expFile.IFECHATO = fechaTo;

                expFile = expFileD.AgregarEXP_FILESD(expFile, null);
                if (expFile == null)
                {
                    this.iComentario = expFileD.IComentario;
                    return false;
                }
            }
            else
            {
                expFile.IID = exp_fileid;
                expFile = expFileD.seleccionarEXP_FILES(expFile, null);
                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                if (!expFileD.CambiarEXP_FILESD(expFile, expFile, null))
                {
                    this.iComentario = expFileD.IComentario;
                    return false;
                }

                
            }

            return true;
        }


        public bool PedidoEnviarAFtp(CEXP_FILESBE filesExpBE, ref  ArrayList resultadosExportacion)
        {
            bool bArchivoSubido = false;


            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();

            doctoBE.IID = filesExpBE.IDOCTOID;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

            if (doctoBE == null)
            {
                resultadosExportacion.Add("Error no se encontro del registro");
                return false;
            }

            
            string localPath ="";
            string ftpPath = "";

            bool bEnFolderSucursal = true;


            if (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
            {

                string claveSucDest = "";
                claveSucDest = ObtenerClaveSucursalDestinoXId(doctoBE.ISUCURSALTID);
                localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';
                
                ftpPath = "/" + claveSucDest + ExportarDBF.FileFTPLocation_SolicitudMercancia + "/";
                bEnFolderSucursal = false;
            }
            else
            {

                localPath = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_Pedidos;
                ftpPath = ExportarDBF.FileFTPLocation_Pedidos + "\\";
                bEnFolderSucursal = true;
            }



            CEXP_FILESD filesExpD = new CEXP_FILESD();

            if (iPos.ImportaDesdeFtp.UploadFile(filesExpBE.INOMBRE, localPath, ftpPath, bEnFolderSucursal, true, ref resultadosExportacion))
                bArchivoSubido = true;

            if (bArchivoSubido)
            {
                filesExpBE.IESTATUS = DBValues._EXP_FILES_ESTADOS_ENVIADO;
                if (!filesExpD.CambiarEXP_FILESD(filesExpBE, filesExpBE, null))
                {
                    resultadosExportacion.Add("Error " + filesExpD.IComentario);
                    return false;
                }
                resultadosExportacion.Add("Archivo " + filesExpBE.IARCHIVOFTP + " enviado");

                if (filesExpBE.ITIPO == DBValues._EXP_FILES_TIPO_PEDIDO)
                {
                    doctoBE.IID = filesExpBE.IDOCTOID;
                    doctoBE.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                    doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null);
                }


            }


            return true;
        }


        public bool PedidoEditarPorUsuario(long lPedidoDoctoId )
        {

            iPos.WFExportarPedidosDet ep = new iPos.WFExportarPedidosDet(lPedidoDoctoId, 0);
            ep.ShowDialog();
            bool bCancelar = ep.m_bCancelar;
            ep.Dispose();
            GC.SuppressFinalize(ep);

            if (bCancelar)
            {
                this.IComentario = "el usuario cancelo la operacion";
                return false;
            }
            return true;
        }


        public bool PedidoCrearDBF(string strIDDosLetras, FbTransaction st,  long lPedidoDoctoId,  ref string dbFileNameDetalle)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_VEDSD vedsD = new CM_VEDSD();
            CM_VEDSBE vedsBE = new CM_VEDSBE();

            CM_VENSBE vensBE = new CM_VENSBE();
            CM_VENSD vensD = new CM_VENSD();

            //bool retorno = true;
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            //long lPedidoDoctoId = 0;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;



            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE pedidoBE = new CDOCTOBE();
            pedidoBE.IID = lPedidoDoctoId;
            pedidoBE = doctoD.seleccionarDOCTO(pedidoBE, null);
            if (pedidoBE == null)
            {
                this.IComentario = "parece que el pedido no existe";
                return false;
            }


            string path = "";
            dbFileNameDetalle = "";
            string dbFileNameHeader = "";


            if(pedidoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
            {

                string claveSucDest = "";
                claveSucDest = ObtenerClaveSucursalDestinoXId(pedidoBE.ISUCURSALTID);
                path = System.AppDomain.CurrentDomain.BaseDirectory + ExportarDBF.FileLocalLocation_SolicitudMercancia + '/' + claveSucDest + '/';
                dbFileNameDetalle = pedidoBE.ISERIE + pedidoBE.IFOLIO.ToString("0").PadLeft(7, '0') + "." + CurrentUserID.CurrentParameters.ISUCURSALNUMERO;
                dbFileNameHeader = dbFileNameDetalle.Replace(FileNamePedidosDetalleFTP, FileNamePedidosHeaderFTP);
            }
            else
            {

                path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Pedidos;
                dbFileNameDetalle = pedidoBE.ISERIE + pedidoBE.IFOLIO.ToString("0").PadLeft(7, '0') + ".dbf";
                dbFileNameHeader = dbFileNameDetalle.Replace(FileNamePedidosDetalleFTP, FileNamePedidosHeaderFTP);
            }

            CopyEmtpyTablesPedidoDBF(dbFileNameDetalle, path);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";
            string strDbFileName = dbFileNameDetalle;//pedidoBE.ISERIE + pedidoBE.IFOLIO.ToString("0").PadLeft(7, '0');






            try
            {
                parts = new ArrayList();

                CmdTxt = @"SELECT        DOCTO.ID AS DOCTOID, 
                                                MOVTO.ID AS MOVTOID, 
                                                DOCTO.REFERENCIA REFERENCIA,
                                                MOVTO.PARTIDA, 
                                                PRODUCTO.CLAVE AS PRODUCTO, 
                                                PRODUCTO.DESCRIPCION1 AS DESCRIPCION,
                                                MARCA.clave   MARCA,
                                                LINEA.clave   LINEA,
                                                MOVTO.CANTIDAD, 
                                                MOVTO.LOTE, 
                                                MOVTO.CANTIDADSURTIDA, 
                                                MOVTO.CANTIDADFALTANTE,
                                                MOVTO.cantidaddevuelta DEVUELTAS,
                                                MOVTO.precio PRECIO,
                                                MOVTO.preciolista PRECIOLISTA,
                                                DOCTO.fecha   FECHA,
                                                MOVTO.importe     IMPORTE,
                                                MOVTO.importe     IMPORTENETO,
                                                MOVTO.costo       COSTO_PU ,
                                                SUCURSAL.clave    SUCURSAL,
                                                MOVTO.costoimporte COSTOTOTAL,
                                                0 COMISION,
                                                MOVTO.descuento   DESCUENTO,
                                                PRODUCTO.descripcion2 DESCRIPCION2,
                                                PERSONA.clave CLAVECLIENTE,
                                                DOCTO.FOLIO FOLIO,
                                                DOCTO.SUBTIPODOCTOID ,
                                                DOCTO.FECHAINI ,
                                                DOCTO.FECHAFIN,
                                                VENDEDOR.USERNAME CVEUSER
                                                
                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid  LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID
                                    WHERE        DOCTO.ID = @DOCTOID
                                    ORDER BY DOCTOID, MOVTOID";

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lPedidoDoctoId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    vedsBE = new CM_VEDSBE();

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        vedsBE.ICLIENTE = ((string)(dr["SUCURSAL"])).PadLeft(6, '0');
                    }
                    else
                        vedsBE.ICLIENTE = "";

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        vedsBE.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRODUCTO = (string)(dr["PRODUCTO"]);

                        if (vedsBE.IPRODUCTO == "")
                            continue;
                    }
                    else
                    {
                        continue;
                    }
                   
                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vedsBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }
                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        vedsBE.IVENTA = strIDDosLetras.Trim().PadLeft(2, '-') + dr["FOLIO"].ToString().PadLeft(4, '0');
                    }

                    vedsBE.IDESCUENTO = 0;

                    
                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        vedsBE.IDESC1 = dr["DESCRIPCION"].ToString();
                    }

                    if (dr["SUBTIPODOCTOID"] != System.DBNull.Value)
                    {
                        long lSubTipoDocto = (long)dr["SUBTIPODOCTOID"];
                        DateTime fechaini = DateTime.MinValue, fechafin = DateTime.MinValue;
                        if (dr["FECHAINI"] != null)
                            fechaini = (DateTime)dr["FECHAINI"];
                        if (dr["FECHAFIN"] != null)
                            fechafin = (DateTime)dr["FECHAFIN"];

                        string strDesc2 = "";
                        switch (lSubTipoDocto)
                        {
                            case DBValues. _DOCTO_SUBTIPO_PEDIDOXFECHA :
                                strDesc2 = "Por fechas: " + fechaini.ToString("dd/MM/yyyy") + " a " + fechafin.ToString("dd/MM/yyyy");
                                break;
                            case DBValues._DOCTO_SUBTIPO_PEDIDOXSTOCK:
                                strDesc2 = "Por stock: " + fechaini.ToString("dd/MM/yyyy");
                                break;
                                  
                        }

                        vedsBE.IDESC2 = strDesc2;
                    }
                    else
                    {
                        vedsBE.IDESC2 = "";
                    }


                    if (dr["CVEUSER"] != System.DBNull.Value)
                    {
                        vedsBE.ICVEUSER = dr["CVEUSER"].ToString();
                    }
                    else
                    {
                        vedsBE.ICVEUSER = "";
                    }


                    
                    vedsBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();//((TimeSpan)(dr["DE_HORA"])).ToString();
                    

                    vedsBE.IID = "CAJA";
                    if (!vedsD.AgregarM_VEDSD(vedsBE, strDbFileName, null, strOleDbConn))
                    {

                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += vedsD.IComentario + "\n";
                        return false;
                    }

                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = lPedidoDoctoId;
                    doctoBE.ITRASLADOAFTP = DBValues._DB_VALUE_FTPGENERADO;
                    if (!doctoD.CambiarEnviadoFTPDOCTOD(doctoBE, null))
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        this.iComentario += doctoD.IComentario + "\n";
                        return false;
                    }
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return false;
            }


        }




        public bool ExportarEnvioPedido(long m_doctoId, CPERSONABE userbe, FbTransaction ft)
        {
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            CSUCURSALBE sucursalDestinoBE = new CSUCURSALBE();

            parametroBE = parametroD.seleccionarPARAMETROActual(ft);
            if (parametroBE == null)
            {
                System.Windows.Forms.MessageBox.Show(parametroD.IComentario);
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {

                System.Windows.Forms.MessageBox.Show("Define la sucursal en la pantalla de empresa");
                return false;
            }


            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, ft);

            if (cajaBE == null)
            {
                System.Windows.Forms.MessageBox.Show(cajaD.IComentario);
                return false;
            }

            objDoctoBE.IID = m_doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, ft);

            if (objDoctoBE == null)
            {
                System.Windows.Forms.MessageBox.Show(objDoctoD.IComentario);
                return false;
            }

            ExportarDBF exportDbf = new ExportarDBF();

            if (parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
            {
                if (!exportDbf.ExportEnvioMatrizPedidoAux(parametroBE, cajaBE, DateTime.Now, objDoctoBE, userbe, ft))
                {
                    System.Windows.Forms.MessageBox.Show(exportDbf.IComentario);
                    return false;
                }
            }


            if (!exportDbf.ExportEnvioMatrizPedido(parametroBE, cajaBE, DateTime.Now, objDoctoBE, ft))
            {
                System.Windows.Forms.MessageBox.Show(exportDbf.IComentario);
                return false;
            }
            return true;
        }








        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            
        }


        public ExportarDBF()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
        }

       
    }
}
