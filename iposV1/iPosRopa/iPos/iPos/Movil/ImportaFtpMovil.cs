using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using iPos.Tools;
using DataLayer.Importaciones;
using System.Windows.Forms;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using DataLayer;
using ConexionesBD;
using Newtonsoft.Json;


using System.Net.NetworkInformation;
using System.Data.Common;

using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace iPos
{
    public class ImportaFtpMovil
    {

        enum DBOperations { OperAgregar, OperCambiar };

        public const string PRODUCT_DBF_FILENAME = "PROD.dbf";
        public const string MARCA_DBF_FILENAME = "M_MARC.dbf";
        public const string LINEA_DBF_FILENAME = "M_LINE.dbf";
        public const string PROMOCION_DBF_FILENAME = "M_PROM.dbf";
        public const string PROVEEDOR_DBF_FILENAME = "M_PROV.dbf";
        public const string SUCURSAL_DBF_FILENAME = "M_CATS.dbf";
        public const string PRODUCTPRECIOS_DBF_FILENAME = "F_PRO2.dbf";
        public const string PRODUCTPRECIOS_DBF_FILENAME_M = "M_PRO2.dbf";
        public const string CLIENTE_DBF_FILENAME = "M_CLIP.dbf";

        public const string HISTORIAL_DBF_FILENAME = "M_PEDS.dbf";

        public const string COBRANZA_DBF_FILENAME = "M_CREP.dbf";


        public const string TASAIVA_DBF_FILENAME = "M_TASA.dbf";
        public const string GRUPOSUCURSAL_DBF_FILENAME = "M_GSUC.dbf";
        public const string DEFCARACTPROD_DBF_FILENAME = "M_DEFC.dbf";
        public const string EDOS_DBF_FILENAME = "M_EDOS.dbf";
        public const string BANK_DBF_FILENAME = "M_BANK.dbf";
        public const string UNIDAD_DBF_FILENAME = "M_UNI.dbf";

        public const string FolderZippedRespaldos = "sampdata\\DBZippedRespaldos";

        /*
         
                if (!iPos.Tools.FTPManagement.Download(strLocalPath, fileFTPPath, filename)
                    return false;
         */



        public const string FileLocalLocation_VentasMovilFTP = "\\sampdata\\movil\\in\\";
        public const string FileLocalLocation_VentasMovilFTP_Molde = "\\sampdata\\movil\\Molde";
        public const string VENTAMOVILHDR_DBF_FILENAME = "M_VENP2";
        public const string VENTAMOVILDTL_DBF_FILENAME = "M_VEDP2";
        public const string FileNameVentaMovilDetalleFTP = "M_VEDP";
        public const string FileNameVentaMovilHeaderFTP = "M_VENP";
        public const string FileFTPLocation_VentaMovil = "/in";

        public static bool ImportarArchivos()
        {

            string strCatalogosFileName = "PREC.ZIP";

            string strMovilFileLocalPath  = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\";
            string strMovilFtpLocation = "";

            switch(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL)
            {
                case 2:
                    strMovilFtpLocation = "vendedormovil/" + CurrentUserID.CurrentUser.IUSERNAME + "/out";
                    break;
                case 3:

                    strCatalogosFileName = "PREC_" + CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE + ".ZIP";
                    strMovilFtpLocation = CurrentUserID.CurrentParameters.ISUCURSALNUMERO + ExportarDBF.FileLocalLocation_MovilPreciosZipFtpPath;// + "/" +  CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE  + "/out";
                    break;
                default: strMovilFtpLocation = CurrentUserID.CurrentParameters.ISUCURSALNUMERO + "/out"; break;
            }
            


            if (File.Exists(strMovilFileLocalPath + strCatalogosFileName))
            {
                try
                {
                    File.Delete(strMovilFileLocalPath + strCatalogosFileName);
                }
                catch
                {
                    MessageBox.Show("Parece que el archivo de catalogos quedo atorado y sera necesario cerrar y abrir de nuevo la aplicacion");
                }
            }

            
            
            if (!iPos.Tools.FTPManagement.Download(strMovilFileLocalPath, strMovilFtpLocation, strCatalogosFileName))
                    return false;



            string strMovilFileLocal = strMovilFileLocalPath + strCatalogosFileName;
            string strMovilFolderUnzipLocalPath = strMovilFileLocal.Replace(".ZIP", "\\");

            if (Directory.Exists(strMovilFolderUnzipLocalPath))
                Directory.Delete(strMovilFolderUnzipLocalPath, true);

            ZipUtil.UnZipFiles(strMovilFileLocal, strMovilFolderUnzipLocalPath, null, false);

            return true;
        }



        public static bool ImportarArchivosOnlyProd()
        {

            string strCatalogosFileName = "exis.zip";

            string strMovilFileLocalPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\";
            string strMovilFtpLocation = "/exis";


            if (File.Exists(strMovilFileLocalPath + strCatalogosFileName))
            {
                try
                {
                    File.Delete(strMovilFileLocalPath + strCatalogosFileName);
                }
                catch
                {
                    MessageBox.Show("Parece que el archivo de catalogos quedo atorado y sera necesario cerrar y abrir de nuevo la aplicacion");
                }
            }



            if (!iPos.Tools.FTPManagement.Download(strMovilFileLocalPath, strMovilFtpLocation, strCatalogosFileName))
                return false;


            string strMovilFileLocal = strMovilFileLocalPath + strCatalogosFileName;
            string strMovilFolderUnzipLocalPath = strMovilFileLocal.ToLower().Replace(".zip", "\\");

            if (Directory.Exists(strMovilFolderUnzipLocalPath))
                Directory.Delete(strMovilFolderUnzipLocalPath, true);

            ZipUtil.UnZipFiles(strMovilFileLocal, strMovilFolderUnzipLocalPath, null, false);


            return true;
        }




        public static bool ImportarDatosSucursal(string fileName, string path , ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        switch (valPrecioT)
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
                        if (dr["MOSTRARPRECIOREAL"] != System.DBNull.Value)
                        {
                            retorno.IMOSTRARPRECIOREAL = ((string)(dr["MOSTRARPRECIOREAL"])).Trim();
                        }
                    }
                    catch
                    {
                        retorno.IMOSTRARPRECIOREAL = "N";
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
                        comentario = sucursalD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public static bool ImportarDatosEstado(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        comentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }



        public static bool ImportarDatosUnidad(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = itemD.CambiarUNIDADD(retorno, retorno, fTrans);
                    else
                        bResult = (itemD.AgregarUNIDADD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        comentario = itemD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }



        public static bool ImportarDatosBancos(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        comentario = itemD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }


        public static bool ImportarDatosGrupoSucursal(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        comentario = itemD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public static bool ImportarDatosCaracteristicasProducto(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        comentario = itemD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }





        public static bool ImportarDatosMarca(string fileName, string path, bool bSoloNuevos, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
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
                        comentario = marcaD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }






        public static bool ImportarDatosProveedor(string fileName, string path, bool bSoloNuevos, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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

                    /*try
                    {
                        if (dr["ADESCPES"] != System.DBNull.Value)
                        {
                            retorno.IADESCPES = (decimal)((dr["ADESCPES"]));
                        }
                    }
                    catch { }*/



                    retorno.IACTIVO = "S";

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = personaD.CambiarPERSONAD(retorno, retorno, fTrans);
                    else
                        bResult = (personaD.AgregarPERSONAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        comentario = personaD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }

        public static List<string> columnasDataReader(DbDataReader dr)
        {
            List<string> columnas = new List<string>();
            foreach (DataRow row in dr.GetSchemaTable().Rows)
            {
                columnas.Add(row["ColumnName"].ToString());
            }
            return columnas;
        }


        public static bool HasColumn(DbDataReader Reader, string ColumnName)
        {
            foreach (DataRow row in Reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString() == ColumnName)
                    return true;
            } //Still here? Column not found. 
            return false;
        }



        public static bool ImportarDatosProd(string fileName, string path, bool bSoloNuevos, ref string comentario, bool bMovil)
        {



            DateTime newUltDate = DateTime.Parse("01/01/2013");

            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            

            string formatedLastDate = "2013,1,1";
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;

            if (bSoloNuevos)
            {
                    if (!(bool)parametroBE.isnull["ILASTCHANGEPRECIOPROD"])
                    {
                        formatedLastDate = parametroBE.ILASTCHANGEPRECIOPROD.Year.ToString() + "," + parametroBE.ILASTCHANGEPRECIOPROD.Month.ToString("N0") + "," + parametroBE.ILASTCHANGEPRECIOPROD.Day.ToString("N0");

                        newUltDate = parametroBE.ILASTCHANGEPRECIOPROD;
                    }

                    CmdTxt = "SELECT * FROM " + fileName + " where fcambio >= date( " + formatedLastDate + ")";
            }




            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();

            string claveLinea = "", claveMarca = "", claveMoneda = "", claveSustituto = "", claveTasaIva = "", claveProductoPadre = "";
            string claveProveedor1 = "", claveProveedor2 = "";
            //DateTime fcambio;
            //int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;


            decimal cantidad;
            string lote = null;
            DateTime fechavence = DateTime.MinValue;
            string refComentario = "";
            bool bAddPrecioSugerido = false;
            bool bAddPrecioTope = false;

            List<string> columnasDr = columnasDataReader(dr);


            try
            {
                if ( columnasDr.Contains("PRECIO6".ToLower()))
                {
                    bAddPrecioSugerido = true;
                }
            }
            catch
            {

            }


            try
            {
                if (columnasDr.Contains("PRECTOPE".ToLower()))
                {
                    bAddPrecioTope = true;
                }
            }
            catch
            {

            }



            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();
                int iV = 0;
                while (dr.Read())
                {
                    iV++;

                    
                    cantidad = 0;
                    lote = null;
                    fechavence = DateTime.MinValue;

                    claveLinea = ""; claveMarca = ""; claveMoneda = ""; claveSustituto = ""; claveTasaIva = ""; claveProductoPadre = "";
                    claveProveedor1 = ""; claveProveedor2 = "";
                    retorno = new CPRODUCTOBE();
                    //iOperation = (int)DBOperations.OperAgregar;
                    

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    retorno.INOMBRE = retorno.ICLAVE;
                    



                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        continue;

                    /*if (dr["FCAMBIO"] != System.DBNull.Value)
                    {
                        fcambio = (DateTime)dr["FCAMBIO"];
                        if (newUltDate < fcambio)
                        {
                            newUltDate = fcambio;
                        }
                    }*/

                    try
                    {
                        if (dr["ID_FECHA"] != System.DBNull.Value)
                        {
                            DateTime bufferFecha = (DateTime)dr["ID_FECHA"];


                            if (dr["ID_HORA"] != System.DBNull.Value)
                            {
                                string strHora = ((string)(dr["ID_HORA"])).Trim();

                                if(strHora.Length > 0)
                                    bufferFecha = bufferFecha.Add(TimeSpan.Parse(strHora));
                            }


                            if (bufferFecha > newUltDate)
                                newUltDate = bufferFecha;



                        }
                    }
                    catch(Exception ex)
                    {

                    }
                    // solo se hace esto cuando solo se quieran agregar los nuevos productos
                    


                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = ((string)(dr["DESC1"])).Trim();
                    }

                    
                    try
                    {
                        if (dr["DESC2"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION2 = ((string)(dr["DESC2"])).Trim();
                        }
                        if (dr["DESC3"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION3 = ((string)(dr["DESC3"])).Trim();
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
                        retorno.IPRECIOSUGERIDO = retorno.IPRECIO1;
                        if (dr["PRECIO6"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOSUGERIDO = (decimal)((dr["PRECIO6"]));
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        claveMoneda = ((string)(dr["MONEDA"])).Trim();
                    }


                    if (HasColumn(dr, "IVA"))
                    {
                        if (dr["IVA"] != System.DBNull.Value)
                        {
                            retorno.ITASAIVA = (decimal)((dr["IVA"]));
                        }
                    }
                    else if (columnasDr.Contains("IMPUESTO".ToLower()))
                    {
                        if (dr["IMPUESTO"] != System.DBNull.Value)
                        {
                            retorno.ITASAIVA = (decimal)((dr["IMPUESTO"]));
                        }
                    }
                    else if(columnasDr.Contains("CVETASAIVA".ToLower()))
                    {

                        try
                        {
                            if (dr["CVETASAIVA"] != System.DBNull.Value)
                            {
                                claveTasaIva = ((string)(dr["CVETASAIVA"])).Trim();
                            }
                        }
                        catch
                        {
                        }
                    }


                   


                    if (dr["COSTO_REPO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)((dr["COSTO_REPO"]));
                    }
                    
                    if (dr["CODIGO"] != System.DBNull.Value)
                    {
                        retorno.IEAN = ((string)(dr["CODIGO"])).Trim();
                    }

                    if (dr["SUSTITUTO"] != System.DBNull.Value)
                    {
                        
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

                        if (retorno.IESKIT != null && retorno.IESKIT.Equals("S") && (parametroBE.IMANEJAKITS == null || !parametroBE.IMANEJAKITS.Equals("S")) )
                            continue;

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
                    retorno.INEGATIVOS = "S";

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


                   

                    try
                    {

                        if (columnasDr.Contains("BOTCAJA".ToLower()))
                        {
                            if (dr["BOTCAJA"] != System.DBNull.Value)
                            {
                                retorno.IPZACAJA = (decimal)(dr["BOTCAJA"]);
                            }
                        }


                        if (columnasDr.Contains("PZACAJA".ToLower()))
                        {
                            if (dr["PZACAJA"] != System.DBNull.Value)
                            {
                                retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                            }
                        }

                    }
                    catch
                    {
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


                   





                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }


                    try
                    {

                        if (dr["PROVEEDOR"] != System.DBNull.Value)
                        {
                            claveProveedor1 = ((string)(dr["PROVEEDOR"])).Trim();
                        }

                        if (dr["PROVEEDOR2"] != System.DBNull.Value)
                        {
                            claveProveedor2 = ((string)(dr["PROVEEDOR2"])).Trim();
                        }

                      
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (dr["PLUG"] != System.DBNull.Value)
                        {
                            retorno.IPLUG = ((string)(dr["PLUG"])).Trim();
                        }/*
                        else if (dr["SUSTITUTO"] != System.DBNull.Value)
                        {
                            retorno.IPLUG = ((string)(dr["SUSTITUTO"])).Trim();
                        }*/
                    }
                    catch
                    {
                    }



                    try
                    {

                        if (columnasDr.Contains("IEPS".ToLower()))
                        {
                            if (dr["IEPS"] != System.DBNull.Value)
                            {
                                retorno.ITASAIEPS = (decimal)((dr["IEPS"]));
                            }
                        }
                        else if(columnasDr.Contains("TASAIEPS".ToLower()))
                        {

                            if (dr["TASAIEPS"] != System.DBNull.Value)
                            {
                                retorno.ITASAIEPS = (decimal)((dr["TASAIEPS"]));
                            }
                        }

                    }
                    catch
                    {
                    }


                    retorno.IREQUIERERECETA = @"N";
                  

                    try
                    {
                        if (dr["PLAZO"] != System.DBNull.Value)
                        {
                            retorno.ICLASIFICA = ((string)(dr["PLAZO"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {


                        if (columnasDr.Contains("EXIS1".ToLower()))
                        {
                            if (dr["EXIS1"] != System.DBNull.Value)
                            {
                                cantidad = decimal.Parse(dr["EXIS1"].ToString());
                            }
                        }
                    }
                    catch
                    {

                    }

                    retorno.IPROMOMOVIL = "N";
                    try
                    {

                        if (columnasDr.Contains("PROD_PROMO".ToLower()))
                        {
                            if (dr["PROD_PROMO"] != System.DBNull.Value)
                            {
                                retorno.IPROMOMOVIL = ((string)(dr["PROD_PROMO"])).Trim();
                                if (retorno.IPROMOMOVIL.Trim() == "")
                                    retorno.IPROMOMOVIL = "N";
                            }
                        }

                    }
                    catch
                    {
                    }
                    if(retorno.IPROMOMOVIL == null || !(retorno.IPROMOMOVIL.Equals("N") || retorno.IPROMOMOVIL.Equals("S")))
                    {
                        retorno.IPROMOMOVIL = "N";
                    }




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
                    }




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
                                retorno.IPRECIOTOPE = (decimal)((dr["PRECTOPE"]));
                            }
                        }

                    }
                    catch
                    {
                    }



                    try
                    {
                        if (dr["UNIDAD2"] != System.DBNull.Value)
                        {
                            retorno.IUNIDAD2 = ((string)(dr["UNIDAD2"])).Trim();
                        }
                    }
                    catch
                    {
                    }



                    try
                    {

                        if (columnasDr.Contains("DESGKIT".ToLower()))
                        {
                            if (dr[""] != System.DBNull.Value)
                            {
                                bool bDESGKIT = (bool)(dr["DESGKIT"]);
                                retorno.IKITIMPFIJO = bDESGKIT ? "N" : "S";
                            }
                        }

                    }
                    catch { }


                    if (bMovil)
                    {
                        try
                        {

                            if (columnasDr.Contains("MARGEN".ToLower()))
                            {
                                if (dr["MARGEN"] != System.DBNull.Value)
                                {
                                    retorno.IMARGENMOVIL = decimal.Parse(dr["MARGEN"].ToString());
                                }
                            }

                            if (columnasDr.Contains("MPRECIO4".ToLower()))
                            {
                                if (dr["MPRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.IMPRECIO4MOVIL = decimal.Parse(dr["MPRECIO4"].ToString());
                                }
                            }


                            if (columnasDr.Contains("CPRECIO4".ToLower()))
                            {
                                if (dr["CPRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.ICPRECIO4MOVIL = decimal.Parse(dr["CPRECIO4"].ToString());
                                }
                            }

                            if (columnasDr.Contains("TPRECIO4".ToLower()))
                            {
                                if (dr["TPRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.ITPRECIO4MOVIL = decimal.Parse(dr["TPRECIO4"].ToString());
                                }
                            }


                            if (columnasDr.Contains("APRECIO4".ToLower()))
                            {
                                if (dr["APRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.IAPRECIO4MOVIL = decimal.Parse(dr["APRECIO4"].ToString());
                                }
                            }


                            
                        }
                        catch
                        {

                        }

                        bResult = productoD.importarPRODUCTODMOVIL(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, null);//fTrans);
                    }
                    else
                    {
                        bResult = productoD.importarPRODUCTOD(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, "", "", "", "", "", "", "", "", null);//fTrans);
                    }
                    
                    if (bResult == false)
                    {
                        comentario = productoD.IComentario;
                        dr.Close();
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }
                    
                    if (cantidad > 0)
                    {
                        bResult = AgregarInventarioInicialProd(retorno.ICLAVE, cantidad, lote, fechavence, null, ref refComentario); //fTrans
                        if (bResult == false)
                        {
                            dr.Close();
                            comentario = refComentario + "\n";
                            //fTrans.Rollback();
                            //fConn.Close();
                            return false;
                        }
                    }
                    

                }

                if (!productoD.PRODUCTOPRECIO(null))//fTrans))
                {
                    dr.Close();
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }

                if (!Post_ImportacionInventarioInicial(null , ref refComentario)) //fTrans
                {
                    dr.Close();
                    comentario = refComentario + "\n";
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }



                parametroBE.IULT_FECHA_IMP_PROD = newUltDate;
                if (!parametroD.CambiarUltimaFechaCambioProdPARAMETROD(parametroBE, parametroBE, null))
                {
                    
                    return false;
                }

                /*if (DateTime.Now > newUltDate)
                    newUltDate = DateTime.Now;*/
                parametroBE.ILASTCHANGEPRECIOPROD = newUltDate;
                if (!parametroD.CambiarLASTCHANGEPRECIOPROD(parametroBE, parametroBE, null))//fTrans))
                {
                    dr.Close();
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }

                CurrentUserID.CurrentParameters.ILASTCHANGEPRECIOPROD = newUltDate;

                dr.Close();
                //fTrans.Commit();
                //fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                //fTrans.Rollback();
                //fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                //fConn.Close();
            }
            return true;

        }





        public static bool ImportarDatosProdCache(string fileName, string path, bool bSoloNuevos, ref string comentario, bool bMovil)
        {



            DateTime newUltDate = DateTime.Parse("01/01/2013");

            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }
            else
            {
                newUltDate = parametroBE.ILASTCHANGEPRECIOPROD;
            }
            //string formatedLastDate = "2013,1,1";
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
            string CmdTxt = "SELECT * FROM " + fileName;


            CCACHE_PRODMOVILD cacheD = new CCACHE_PRODMOVILD();

            OdbcDataReader dr;
            dr = OdbcHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();

            string claveLinea = "", claveMarca = "", claveMoneda = "", claveSustituto = "", claveTasaIva = "", claveProductoPadre = "";
            string claveProveedor1 = "", claveProveedor2 = "";
            //DateTime fcambio;
            //int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;


            decimal cantidad;
            string lote = null;
            DateTime fechavence = DateTime.MinValue;
            string refComentario = "";
            bool bAddPrecioSugerido = false;
            bool bAddPrecioTope = false;

            List<string> columnasDr = columnasDataReader(dr);


            try
            {
                if (columnasDr.Contains("PRECIO6".ToLower()))
                {
                    bAddPrecioSugerido = true;
                }
            }
            catch
            {

            }


            try
            {
                if (columnasDr.Contains("PRECTOPE".ToLower()))
                {
                    bAddPrecioTope = true;
                }
            }
            catch
            {

            }



            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();

                cacheD.BorrarTodosCACHE_PRODMOVILD(null);//fTrans);
                

                int iV = 0;
                while (dr.Read())
                {
                    iV++;


                    cantidad = 0;
                    lote = null;
                    fechavence = DateTime.MinValue;

                    claveLinea = ""; claveMarca = ""; claveMoneda = ""; claveSustituto = ""; claveTasaIva = ""; claveProductoPadre = "";
                    claveProveedor1 = ""; claveProveedor2 = "";
                    retorno = new CPRODUCTOBE();
                    //iOperation = (int)DBOperations.OperAgregar;


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["PRODUCTO"])).Trim();
                    }

                    retorno.INOMBRE = retorno.ICLAVE;




                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        continue;

                    /*if (dr["FCAMBIO"] != System.DBNull.Value)
                    {
                        fcambio = (DateTime)dr["FCAMBIO"];
                        if (newUltDate < fcambio)
                        {
                            newUltDate = fcambio;
                        }
                    }*/

                    try
                    {
                        if (dr["ID_FECHA"] != System.DBNull.Value)
                        {
                            DateTime bufferFecha = (DateTime)dr["ID_FECHA"];


                            if (dr["ID_HORA"] != System.DBNull.Value)
                            {
                                string strHora = ((string)(dr["ID_HORA"])).Trim();

                                if (strHora.Length > 0)
                                    bufferFecha = bufferFecha.Add(TimeSpan.Parse(strHora));
                            }


                            if (bufferFecha > newUltDate)
                                newUltDate = bufferFecha;



                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    // solo se hace esto cuando solo se quieran agregar los nuevos productos



                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = ((string)(dr["DESC1"])).Trim();
                    }


                    try
                    {
                        if (dr["DESC2"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION2 = ((string)(dr["DESC2"])).Trim();
                        }
                        if (dr["DESC3"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION3 = ((string)(dr["DESC3"])).Trim();
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
                        retorno.IPRECIOSUGERIDO = retorno.IPRECIO1;
                        if (dr["PRECIO6"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOSUGERIDO = (decimal)((dr["PRECIO6"]));
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        claveMoneda = ((string)(dr["MONEDA"])).Trim();
                    }


                    if (HasColumn(dr, "IVA"))
                    {
                        if (dr["IVA"] != System.DBNull.Value)
                        {
                            retorno.ITASAIVA = (decimal)((dr["IVA"]));
                        }
                    }
                    else if (columnasDr.Contains("IMPUESTO".ToLower()))
                    {
                        if (dr["IMPUESTO"] != System.DBNull.Value)
                        {
                            retorno.ITASAIVA = (decimal)((dr["IMPUESTO"]));
                        }
                    }
                    else if (columnasDr.Contains("CVETASAIVA".ToLower()))
                    {

                        try
                        {
                            if (dr["CVETASAIVA"] != System.DBNull.Value)
                            {
                                claveTasaIva = ((string)(dr["CVETASAIVA"])).Trim();
                            }
                        }
                        catch
                        {
                        }
                    }





                    if (dr["COSTO_REPO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)((dr["COSTO_REPO"]));
                    }

                    if (dr["CODIGO"] != System.DBNull.Value)
                    {
                        retorno.IEAN = ((string)(dr["CODIGO"])).Trim();
                    }

                    if (dr["SUSTITUTO"] != System.DBNull.Value)
                    {

                        claveSustituto = ((string)(dr["SUSTITUTO"])).Trim();
                        claveSustituto = claveSustituto.Trim();
                    }


                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = ((string)(dr["LOTE"])).Trim();
                    }
                    


                    //en importacion movil... por el momento se van a considerar como que no son kits
                    if (dr["KIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = ((string)(dr["KIT"])).Trim();
                    }
                    retorno.IESKIT = "N";

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
                    retorno.INEGATIVOS = "S";

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




                    try
                    {

                        if (columnasDr.Contains("BOTCAJA".ToLower()))
                        {
                            if (dr["BOTCAJA"] != System.DBNull.Value)
                            {
                                retorno.IPZACAJA = (decimal)(dr["BOTCAJA"]);
                            }
                        }


                        if (columnasDr.Contains("PZACAJA".ToLower()))
                        {
                            if (dr["PZACAJA"] != System.DBNull.Value)
                            {
                                retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                            }
                        }

                    }
                    catch
                    {
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








                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }


                    try
                    {

                        if (dr["PROVEEDOR"] != System.DBNull.Value)
                        {
                            claveProveedor1 = ((string)(dr["PROVEEDOR"])).Trim();
                        }

                        if (dr["PROVEEDOR2"] != System.DBNull.Value)
                        {
                            claveProveedor2 = ((string)(dr["PROVEEDOR2"])).Trim();
                        }


                    }
                    catch
                    {
                    }


                    try
                    {
                        if (dr["PLUG"] != System.DBNull.Value)
                        {
                            retorno.IPLUG = ((string)(dr["PLUG"])).Trim();
                        }/*
                        else if (dr["SUSTITUTO"] != System.DBNull.Value)
                        {
                            retorno.IPLUG = ((string)(dr["SUSTITUTO"])).Trim();
                        }*/
                    }
                    catch
                    {
                    }



                    try
                    {

                        if (columnasDr.Contains("IEPS".ToLower()))
                        {
                            if (dr["IEPS"] != System.DBNull.Value)
                            {
                                retorno.ITASAIEPS = (decimal)((dr["IEPS"]));
                            }
                        }
                        else if (columnasDr.Contains("TASAIEPS".ToLower()))
                        {

                            if (dr["TASAIEPS"] != System.DBNull.Value)
                            {
                                retorno.ITASAIEPS = (decimal)((dr["TASAIEPS"]));
                            }
                        }

                    }
                    catch
                    {
                    }


                    retorno.IREQUIERERECETA = @"N";


                    try
                    {
                        if (dr["PLAZO"] != System.DBNull.Value)
                        {
                            retorno.ICLASIFICA = ((string)(dr["PLAZO"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {


                        if (columnasDr.Contains("EXIS1".ToLower()))
                        {
                            if (dr["EXIS1"] != System.DBNull.Value)
                            {
                                cantidad = decimal.Parse(dr["EXIS1"].ToString());
                            }
                        }
                    }
                    catch
                    {

                    }

                    retorno.IPROMOMOVIL = "N";
                    try
                    {

                        if (columnasDr.Contains("PROD_PROMO".ToLower()))
                        {
                            if (dr["PROD_PROMO"] != System.DBNull.Value)
                            {
                                retorno.IPROMOMOVIL = ((string)(dr["PROD_PROMO"])).Trim();
                                if (retorno.IPROMOMOVIL.Trim() == "")
                                    retorno.IPROMOMOVIL = "N";
                            }
                        }

                    }
                    catch
                    {
                    }
                    if (retorno.IPROMOMOVIL == null || !(retorno.IPROMOMOVIL.Equals("N") || retorno.IPROMOMOVIL.Equals("S")))
                    {
                        retorno.IPROMOMOVIL = "N";
                    }




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
                    }




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
                                retorno.IPRECIOTOPE = (decimal)((dr["PRECTOPE"]));
                            }
                        }

                    }
                    catch
                    {
                    }



                    try
                    {
                        if (dr["UNIDAD2"] != System.DBNull.Value)
                        {
                            retorno.IUNIDAD2 = ((string)(dr["UNIDAD2"])).Trim();
                        }
                    }
                    catch
                    {
                    }



                    if (bMovil)
                    {
                        try
                        {

                            if (columnasDr.Contains("MARGEN".ToLower()))
                            {
                                if (dr["MARGEN"] != System.DBNull.Value)
                                {
                                    retorno.IMARGENMOVIL = decimal.Parse(dr["MARGEN"].ToString());
                                }
                            }

                            if (columnasDr.Contains("MPRECIO4".ToLower()))
                            {
                                if (dr["MPRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.IMPRECIO4MOVIL = decimal.Parse(dr["MPRECIO4"].ToString());
                                }
                            }


                            if (columnasDr.Contains("CPRECIO4".ToLower()))
                            {
                                if (dr["CPRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.ICPRECIO4MOVIL = decimal.Parse(dr["CPRECIO4"].ToString());
                                }
                            }

                            if (columnasDr.Contains("TPRECIO4".ToLower()))
                            {
                                if (dr["TPRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.ITPRECIO4MOVIL = decimal.Parse(dr["TPRECIO4"].ToString());
                                }
                            }


                            if (columnasDr.Contains("APRECIO4".ToLower()))
                            {
                                if (dr["APRECIO4"] != System.DBNull.Value)
                                {
                                    retorno.IAPRECIO4MOVIL = decimal.Parse(dr["APRECIO4"].ToString());
                                }
                            }



                        }
                        catch
                        {

                        }


                        //buffer.Add(new CACHEIMPOBUFFER(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, cantidad, lote, fechavence));
                        //bResult = true;
                        bResult = cacheD.importarCACHE_PRODUCTODMOVIL(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, cantidad, lote, fechavence, null);//fTrans);
                    }
                    else
                    {
                        bResult = true;
                        //bResult = productoD.importarPRODUCTOD(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, "", "", "", "", "", fTrans);
                    }

                   


                    if (bResult == false)
                    {
                        comentario = cacheD.IComentario;
                        dr.Close();
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    /*if (cantidad > 0)
                    {
                        bResult = AgregarInventarioInicialProd(retorno.ICLAVE, cantidad, lote, fechavence, fTrans, ref refComentario);
                        if (bResult == false)
                        {
                            dr.Close();
                            comentario = refComentario + "\n";
                            fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }
                    }*/


                }
                



                
                if (!cacheD.CACHEPROD_IMPORTAR_MOVIL(null))//fTrans))
                {
                    comentario = cacheD.IComentario;
                    dr.Close();
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }

                

                if (!productoD.PRODUCTOPRECIO(null))//fTrans))
                {
                    dr.Close();
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }


                if (!Post_ImportacionInventarioInicial(null, ref refComentario))// fTrans,
                {
                    dr.Close();
                    comentario = refComentario + "\n";
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }
                
                parametroBE.ILASTCHANGEPRECIOPROD = newUltDate;
                if (!parametroD.CambiarLASTCHANGEPRECIOPROD(parametroBE, parametroBE, null))//fTrans))
                {
                    dr.Close();
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }

                CurrentUserID.CurrentParameters.ILASTCHANGEPRECIOPROD = newUltDate;

                

                dr.Close();
                //fTrans.Commit();
                //fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                //fTrans.Rollback();
                //fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                //fConn.Close();
            }
            return true;

        }




        public static bool ImportarDatosProd_2(string fileName, string path, bool bSoloNuevos, ref string comentario, bool bMovil)
        {



            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }
            string formatedLastDate = "2013,1,1";
            DateTime newUltDate = DateTime.Parse("01/01/2013");
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
            //FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            //FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();

            //CLINEABE lineaBE;
            //CLINEAD lineaD = new CLINEAD();


            //CMARCABE marcaBE;
            //CMARCAD marcaD = new CMARCAD();

            //CMONEDABE monedaBE;
            //CMONEDAD monedaD = new CMONEDAD();


            //CPRODUCTOBE sustitutoBE;
            //CPRODUCTOD sustitutoD = new CPRODUCTOD();



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



            decimal cantidad;
            string lote = null;
            DateTime fechavence = DateTime.MinValue;
            string refComentario = "";
            string claveLinea = "", claveMarca = "", claveMoneda = "", claveSustituto = "", claveTasaIva = "", claveProductoPadre = "";
            string claveProveedor1 = "", claveProveedor2 = "";
            DateTime fcambio;
            //int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;
            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();

                IEnumerable<String> fieldNames = null;

                while (dr.Read())
                {

                    if(fieldNames == null)
                        fieldNames = Enumerable.Range(0, dr.FieldCount).Select(i => dr.GetName(i)).ToArray();

                    cantidad = 0;
                    lote = null;
                    fechavence = DateTime.MinValue;

                    claveLinea = ""; claveMarca = ""; claveMoneda = ""; claveSustituto = ""; claveTasaIva = ""; claveProductoPadre = "";
                    claveProveedor1 = ""; claveProveedor2 = "";
                    retorno = new CPRODUCTOBE();
                    //iOperation = (int)DBOperations.OperAgregar;


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

                    if (dr["FCAMBIO"] != System.DBNull.Value)
                    {
                        fcambio = (DateTime)dr["FCAMBIO"];
                        if (newUltDate < fcambio)
                        {
                            newUltDate = fcambio;
                        }
                    }


                    // solo se hace esto cuando solo se quieran agregar los nuevos productos
                    if (bSoloNuevos)
                    {
                        prodBuffer = productoD.seleccionarPRODUCTOPorClave(retorno, null);//fTrans);
                        if (prodBuffer != null)
                        {
                            continue;
                        }
                    }


                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = ((string)(dr["DESC1"])).Trim();
                    }

                    try
                    {

                        if (dr["DESC"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION = ((string)(dr["DESC"])).Trim();
                        }

                    }
                    catch
                    {
                        retorno.IDESCRIPCION = retorno.IDESCRIPCION1;
                    }

                    try
                    {
                        if (dr["DESC2"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION2 = ((string)(dr["DESC2"])).Trim();
                        }
                        if (dr["DESC3"] != System.DBNull.Value)
                        {
                            retorno.IDESCRIPCION3 = ((string)(dr["DESC3"])).Trim();
                        }
                    }
                    catch
                    {
                        retorno.IDESCRIPCION2 = retorno.IDESCRIPCION1;
                        retorno.IDESCRIPCION3 = retorno.IDESCRIPCION1;
                    }



                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        /*lineaBE = new CLINEABE();
                        lineaBE.ICLAVE = (string)(dr["LINEA"]);
                        lineaBE = lineaD.seleccionarLINEAxCLAVE(lineaBE, fTrans);
                        if(lineaBE != null)
                            retorno.ILINEAID = (int)lineaBE.IID;*/
                        claveLinea = ((string)(dr["LINEA"])).Trim();
                    }
                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        /* marcaBE = new CMARCABE();
                         marcaBE.ICLAVE = (string)(dr["MARCA"]);
                         marcaBE = marcaD.seleccionarMARCAXCLAVE(marcaBE, fTrans);
                         if (marcaBE != null)
                             retorno.IMARCAID= (int)marcaBE.IID;*/
                        claveMarca = ((string)(dr["MARCA"])).Trim();
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

                    try
                    {
                        retorno.IPRECIOSUGERIDO = retorno.IPRECIO1;
                        if (dr["PRECIO6"] != System.DBNull.Value)
                        {
                            retorno.IPRECIOSUGERIDO = (decimal)((dr["PRECIO6"]));
                        }
                    }
                    catch (Exception ex)
                    {

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
                        if (dr["CVETASAIVA"] != System.DBNull.Value)
                        {
                            claveTasaIva = ((string)(dr["CVETASAIVA"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {

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
                            retorno.INUMERO1 = (decimal)(dr["NUMERO1"]);
                        }
                        if (dr["NUMERO2"] != System.DBNull.Value)
                        {
                            retorno.INUMERO2 = (decimal)(dr["NUMERO2"]);
                        }
                        if (dr["NUMERO3"] != System.DBNull.Value)
                        {
                            retorno.INUMERO3 = (decimal)(dr["NUMERO3"]);
                        }
                        if (dr["NUMERO4"] != System.DBNull.Value)
                        {
                            retorno.INUMERO4 = (decimal)(dr["NUMERO4"]);
                        }

                        if (dr["FECHA1"] != System.DBNull.Value)
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
                        if (dr["FECHA2"] != System.DBNull.Value)
                        {
                            try
                            {
                                retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                            }
                            catch
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

                        if (dr["PRODPADRE"] != System.DBNull.Value)
                        {
                            claveProductoPadre = ((string)(dr["PRODPADRE"])).Trim();
                        }


                        if (dr["ESPADRE"] != System.DBNull.Value)
                        {
                            retorno.IESPRODUCTOPADRE = ((string)(dr["ESPADRE"])).Trim();
                        }
                        if (dr["ESFINAL"] != System.DBNull.Value)
                        {
                            retorno.IESPRODUCTOFINAL = ((string)(dr["ESFINAL"])).Trim();
                        }
                        if (dr["ESSUBPROD"] != System.DBNull.Value)
                        {
                            retorno.IESSUBPRODUCTO = ((string)(dr["ESSUBPROD"])).Trim();
                        }
                        if (dr["PRECPADRE"] != System.DBNull.Value)
                        {
                            retorno.ITOMARPRECIOPADRE = ((string)(dr["PRECPADRE"])).Trim();
                        }
                        if (dr["COMIPADRE"] != System.DBNull.Value)
                        {
                            retorno.ITOMARCOMISIONPADRE = ((string)(dr["COMIPADRE"])).Trim();
                        }
                        if (dr["OFEPADRE"] != System.DBNull.Value)
                        {
                            retorno.ITOMAROFERTAPADRE = ((string)(dr["OFEPADRE"])).Trim();

                        }


                        if (dr["COMISION"] != System.DBNull.Value)
                        {
                            retorno.ICOMISION = (decimal)(dr["COMISION"]);
                        }

                    }
                    catch
                    {
                    }


                    try
                    {

                        if (dr["PROVEEDOR"] != System.DBNull.Value)
                        {
                            claveProveedor1 = ((string)(dr["PROVEEDOR"])).Trim();
                        }

                        if (dr["PROVEEDOR2"] != System.DBNull.Value)
                        {
                            claveProveedor2 = ((string)(dr["PROVEEDOR2"])).Trim();
                        }

                        if (dr["OFERTA"] != System.DBNull.Value)
                        {
                            retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                        }

                        if (dr["CAMBIARPRE"] != System.DBNull.Value)
                        {
                            retorno.ICAMBIARPRECIO = ((string)(dr["CAMBIARPRE"])).Trim();
                        }
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (dr["PLUG"] != System.DBNull.Value)
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
                        if (dr["TASAIEPS"] != System.DBNull.Value)
                        {
                            retorno.ITASAIEPS = (decimal)((dr["TASAIEPS"]));
                        }
                    }
                    catch
                    {
                    }



                    try
                    {
                        if (dr["MINUTIL"] != System.DBNull.Value)
                        {
                            retorno.IMINUTILIDAD = (decimal)((dr["MINUTIL"]));
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (dr["SPRECIO1"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO1 = (decimal)((dr["SPRECIO1"]));
                        }
                        if (dr["SPRECIO2"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO2 = (decimal)((dr["SPRECIO2"]));
                        }
                        if (dr["SPRECIO3"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO3 = (decimal)((dr["SPRECIO3"]));
                        }
                        if (dr["SPRECIO4"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO4 = (decimal)((dr["SPRECIO4"]));
                        }
                        if (dr["SPRECIO5"] != System.DBNull.Value)
                        {
                            retorno.ISPRECIO5 = (decimal)((dr["SPRECIO5"]));
                        }
                    }
                    catch
                    {
                    }


                    retorno.IREQUIERERECETA = @"N";
                    if (fieldNames.Contains("RRERECETA"))
                    {
                        try
                        {
                            retorno.IREQUIERERECETA = @"N";
                            if (dr["RRERECETA"] != System.DBNull.Value)
                            {
                                retorno.IREQUIERERECETA = ((string)(dr["RRERECETA"])).Trim();
                            }
                        }
                        catch
                        {
                            retorno.IREQUIERERECETA = @"N";
                        }
                    }


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
                    }

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
                                retorno.IPRECIOTOPE = (decimal)((dr["PRECTOPE"]));
                            }
                        }

                    }
                    catch
                    {
                    }


                    try
                    {

                        if (dr["EXIS1"] != System.DBNull.Value)
                        {
                            cantidad = decimal.Parse(dr["EXIS1"].ToString());
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["PUPRECIO1"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO1 = (decimal)((dr["PUPRECIO1"]));
                        }
                        if (dr["PUPRECIO2"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO2 = (decimal)((dr["PUPRECIO2"]));
                        }
                        if (dr["PUPRECIO3"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO3 = (decimal)((dr["PUPRECIO3"]));
                        }
                        if (dr["PUPRECIO4"] != System.DBNull.Value)
                        {
                            retorno.IPORCUTILPRECIO4 = (decimal)((dr["PUPRECIO4"]));
                        }
                        if (dr["PUPRECIO5"] != System.DBNull.Value)
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
                            if ((string)dr["IIMPCOM"] != "S")
                                retorno.IIMPRIMIRCOMANDA = "N";
                            else
                                retorno.IIMPRIMIRCOMANDA = "S";
                        }
                    }
                    catch
                    {

                        retorno.IIMPRIMIRCOMANDA = "N";
                    }

                    try
                    {


                        if (dr["LMEDMAY"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECMEDIOMAYID = long.Parse(dr["LMEDMAY"].ToString());
                        }
                        if (dr["LMAYO"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECMAYOREOID = long.Parse(dr["LMAYO"].ToString());
                        }
                        if (dr["CMEDMAY"] != System.DBNull.Value)
                        {
                            retorno.ICANTMEDIOMAY = (decimal)((dr["CMEDMAY"]));
                        }
                        if (dr["CMAYO"] != System.DBNull.Value)
                        {
                            retorno.ICANTMAYOREO = (decimal)((dr["CMAYO"]));
                        }
                    }
                    catch
                    { }




                    //retorno.IACTIVO = "S";

                    /*if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = productoD.CambiarPRODUCTOD(retorno, retorno, fTrans);
                    else
                        bResult = (productoD.AgregarPRODUCTOD(retorno, fTrans) != null);
                    */
                    bResult = productoD.importarPRODUCTOMOVIL_2(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, null);// fTrans);
                    if (bResult == false)
                    {
                        comentario = productoD.IComentario;
                        //fTrans.Rollback();
                        //fConn.Close();
                        return false;
                    }

                    
                    
                    if (cantidad > 0)
                    {
                        bResult = AgregarInventarioInicialProd(retorno.ICLAVE, cantidad, lote, fechavence, null, ref refComentario); //ftrans
                        if (bResult == false)
                        {
                            comentario = refComentario + "\n";
                            //fTrans.Rollback();
                            //fConn.Close();
                            return false;
                        }
                    }


                }

                if (!productoD.PRODUCTOPRECIO(null))//fTrans))
                {
                    //fTrans.Rollback();
                    //fConn.Close();
                    comentario = "Error en producto precio";
                    return false;
                }

                if (!Post_ImportacionInventarioInicial(null, ref refComentario)) //ftrans
                {
                    comentario = refComentario + "\n";
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }

                /*if (DateTime.Now > newUltDate)
                    newUltDate = DateTime.Now;*/
                parametroBE.ILASTCHANGEPRECIOPROD = newUltDate;
                if (!parametroD.CambiarLASTCHANGEPRECIOPROD(parametroBE, parametroBE, null))//fTrans))
                {
                    //fTrans.Rollback();
                    //fConn.Close();
                    return false;
                }

                CurrentUserID.CurrentParameters.ILASTCHANGEPRECIOPROD = newUltDate;




                //fTrans.Commit();
                //fConn.Close();
            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                //fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                //fConn.Close();
            }
            return true;

        }


        public static bool ImportarDatosProdOnly(ref string comentario)
        {

            //string strCatalogosFileName = "prod.dbf";
            string strMovilFileLocalPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\exis\\";

            if (!ImportarDatosProd(PRODUCT_DBF_FILENAME, strMovilFileLocalPath, false, ref comentario, true))
            {
                return false;
            }
            return true;

        }


        public static bool ImportarDatosLinea(string fileName, string path, bool bSoloNuevos, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        comentario = lineaD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }



        public static bool ImportarDatosTasaIva(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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
                        comentario = itemD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }






        public static bool ImportarDatosCliente(string fileName, string path, bool bSoloNuevos, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = ((string)(dr["CLIENTE"])).Trim();
                    }

                    retorno.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
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
                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = ((string)(dr["NOMBRES"])).Trim();
                    }
                    if (dr["PATERNO"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = ((string)(dr["PATERNO"])).Trim();
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

                    if (dr["TELEFONO"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = ((string)(dr["TELEFONO"])).Trim();
                    }
                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = ((string)(dr["TELEFONO2"])).Trim();
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
                        if (dr["L_DESC"] != System.DBNull.Value)
                        {
                            retorno.ILISTAPRECIOID = long.Parse(((string)(dr["L_DESC"])).Trim());
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["LIMITE"] != System.DBNull.Value)
                        {
                            retorno.ILIMITECREDITO = (decimal)(dr["LIMITE"]);
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["BLOQUEADO"] != System.DBNull.Value)
                        {
                            retorno.IBLOQUEADO = ((string)(dr["BLOQUEADO"])).Trim();

                            if (!retorno.IBLOQUEADO.Equals("S"))
                                retorno.IBLOQUEADO = "N";

                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["DIAS"] != System.DBNull.Value)
                        {
                            decimal tempdias = (decimal)(dr["DIAS"]);
                            retorno.IDIAS = Decimal.ToInt32(tempdias);
                            //retorno.IDIAS = int.Parse(((string)(dr["DIAS"])).Trim());
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["EMAIL"] != System.DBNull.Value)
                        {
                            retorno.IEMAIL1 = ((string)(dr["EMAIL"])).Trim();
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (dr["PAGOS"] != System.DBNull.Value)
                        {
                            retorno.IPAGOS = ((string)(dr["PAGOS"])).Trim();
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["SALDO"] != System.DBNull.Value)
                        {
                            retorno.ISALDO = (decimal)(dr["SALDO"]);
                            retorno.ISALDOMOVIL = (decimal)(dr["SALDO"]);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["SALDO_VENC"] != System.DBNull.Value)
                        {
                            retorno.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDO_VENC"]);
                        }
                    }
                    catch
                    {

                    }


                    try
                    {

                        if (dr["BLOQUEONOT"] != System.DBNull.Value)
                        {
                            retorno.IBLOQUEONOT = ((string)(dr["BLOQUEONOT"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["CRUZACON"] != System.DBNull.Value)
                        {
                            retorno.IMEMO = ((string)(dr["CRUZACON"])).Trim();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {

                        if (dr["SIXNOMBRE"] != System.DBNull.Value)
                        {
                            retorno.IREFERENCIAMOVIL = ((string)(dr["SIXNOMBRE"])).Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr["FENUECL"] != System.DBNull.Value)
                        {
                            retorno.INUMEROEXTERIOR = ((string)(dr["FENUECL"])).Trim();
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["FENUICL"] != System.DBNull.Value)
                        {
                            retorno.INUMEROINTERIOR = ((string)(dr["FENUICL"])).Trim();
                        }
                    }
                    catch
                    {

                    }

                    retorno.IACTIVO = "S";

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = personaD.CambiarPERSONADMovil(retorno, retorno, fTrans);
                    else
                        bResult = (personaD.AgregarPERSONAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        comentario = personaD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }



        public static bool ImportarDatosCliente_FromMovil3(List<CF_CLIPBE> lista, bool bSoloNuevos, ref string comentario)
        {
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
                foreach (CF_CLIPBE dr in lista)
                {
                    retorno = new CPERSONABE();
                    iOperation = (int)DBOperations.OperAgregar;

                    if (dr.ICLIENTE != null)
                    {
                        retorno.ICLAVE = dr.ICLIENTE.Trim();
                    }

                    retorno.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
                    personaBuffer = personaD.seleccionarPERSONAxCLAVEyTIPO(retorno, fTrans);
                    if (personaBuffer != null)
                    {
                        if (bSoloNuevos)
                            continue;

                        retorno = personaBuffer;
                        iOperation = (int)DBOperations.OperCambiar;
                    }


                    if (dr.INOMBRE != null)
                    {
                        retorno.INOMBRE = dr.INOMBRE.Trim();
                    }
                    if (dr.INOMBRES != null)
                    {
                        retorno.INOMBRES = dr.INOMBRES.Trim();
                    }
                    else
                    {
                        retorno.INOMBRES = retorno.INOMBRE;
                    }
                    if (dr.IPATERNO != null)
                    {
                        retorno.IAPELLIDOS = dr.IPATERNO.Trim();
                    }
                    else
                    {
                        retorno.IAPELLIDOS = ".";
                    }



                    if (dr.ICALLE != null)
                    {
                        retorno.IDOMICILIO = dr.ICALLE.Trim();
                    }
                    if (dr.ICOLONIA != null)
                    {
                        retorno.ICOLONIA = dr.ICOLONIA.Trim();
                    }
                    if (dr.ICIUDAD != null)
                    {
                        retorno.ICIUDAD = dr.ICIUDAD.Trim();
                    }
                    if (dr.IESTADO != null)
                    {
                        retorno.IESTADO = dr.IESTADO.Trim();
                    }
                    if (dr.ICP != null)
                    {
                        retorno.ICODIGOPOSTAL = dr.ICP.Trim();
                    }

                    if (dr.ITELEFONO != null)
                    {
                        retorno.ITELEFONO1 = dr.ITELEFONO.Trim();
                    }
                    if (dr.ITELEFONO2 != null)
                    {
                        retorno.ITELEFONO2 = dr.ITELEFONO2.Trim();
                    }

                    if (dr.ICONTACTO != null)
                    {
                        retorno.ICONTACTO1 = dr.ICONTACTO.Trim();
                    }

                    if (dr.ICONTACTO2 != null)
                    {
                        retorno.ICONTACTO2 = dr.ICONTACTO2.Trim();
                    }

                    if (dr.IRFC != null)
                    {
                        retorno.IRFC = dr.IRFC.Trim();
                    }


                    try
                    {
                        if (dr.IL_DESC != null)
                        {
                            retorno.ILISTAPRECIOID = int.Parse(dr.IL_DESC);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        retorno.ILIMITECREDITO = dr.ILIMITE;
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr.IBLOQUEADO != null)
                        {
                            retorno.IBLOQUEADO = dr.IBLOQUEADO.Trim();

                            if (!retorno.IBLOQUEADO.Equals("S"))
                                retorno.IBLOQUEADO = "N";

                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        decimal tempdias = dr.IDIAS;
                        retorno.IDIAS = Decimal.ToInt32(tempdias);
                        //retorno.IDIAS = int.Parse(((string)(dr["DIAS"])).Trim());

                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr.IEMAIL != null)
                        {
                            retorno.IEMAIL1 = dr.IEMAIL.Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr.IEMAIL2 != null)
                        {
                            retorno.IEMAIL2 = dr.IEMAIL2.Trim();
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr.IPAGOS != null)
                        {
                            retorno.IPAGOS = dr.IPAGOS.Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr.IREVISION != null)
                        {
                            retorno.IREVISION = dr.IREVISION.Trim();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                            retorno.IDIAS = Decimal.ToInt32(dr.IDIAS);
                    }
                    catch
                    {

                    }


                    try
                    {

                        if (dr.IBLOQUEONOT != null)
                        {
                            retorno.IBLOQUEONOT = dr.IBLOQUEONOT.Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr.ICRUZACON != null)
                        {
                            retorno.IMEMO = dr.ICRUZACON.Trim();
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        if (dr.IFENUECL != null && dr.IFENUECL.Trim().Length > 0)
                        {
                            retorno.INUMEROEXTERIOR = dr.IFENUECL.Trim();
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr.IFENUICL != null && dr.IFENUICL.Trim().Length > 0)
                        {
                            retorno.INUMEROINTERIOR = dr.IFENUICL.Trim();
                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                        if (dr.ICOMODIN != null && dr.ICOMODIN.Trim().Length > 0)
                        {
                            if (dr.ICOMODIN.Contains("CHEQ"))
                                retorno.IHAB_PAGOCHEQUE = "S";
                            if (dr.ICOMODIN.Contains("CRED"))
                                retorno.IHAB_PAGOCREDITO = "S";
                            if (dr.ICOMODIN.Contains("TRAN"))
                                retorno.IHAB_PAGOTRANSFERENCIA = "S";
                            if (dr.ICOMODIN.Contains("TARJ"))
                                retorno.IHAB_PAGOTARJETA = "S";
                        }
                    }
                    catch
                    {

                    }



                    try
                    {
                        if(dr.IVENDEDOR != null && dr.IVENDEDOR.Trim().Length > 0)
                        {

                            CPERSONABE vendedorBE = new CPERSONABE();
                            vendedorBE.ICLAVE = dr.IVENDEDOR;
                            vendedorBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_VENDEDOR;
                            vendedorBE = personaD.seleccionarPERSONAxCLAVEyTIPO(vendedorBE, fTrans);
                            if(vendedorBE == null)
                            {
                                vendedorBE = new CPERSONABE();
                                vendedorBE.ICLAVE = dr.IVENDEDOR;
                                vendedorBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_USUARIO;
                                vendedorBE = personaD.seleccionarPERSONAxCLAVEyTIPO(vendedorBE, fTrans);
                            }

                            if(vendedorBE != null)
                            {
                                retorno.IVENDEDORID = vendedorBE.IID;
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        if (dr.IDESGIEPS != null && dr.IDESGIEPS.Equals("S"))
                        {
                            retorno.IDESGLOSEIEPS = dr.IDESGIEPS;
                        }
                        else
                        {
                            retorno.IDESGLOSEIEPS = "N";
                        }



                        if (dr.ICTA_IEPS != null && dr.ICTA_IEPS.Trim().Length > 0)
                        {
                            retorno.ICUENTAIEPS = dr.ICTA_IEPS.Trim();
                        }
                    }
                    catch { }


                    retorno.IACTIVO = "S";

                    if (iOperation == (int)DBOperations.OperCambiar)
                        bResult = personaD.CambiarPERSONADMovil(retorno, retorno, fTrans);
                    else
                        bResult = (personaD.AgregarPERSONAD(retorno, fTrans) != null);

                    if (bResult == false)
                    {
                        comentario = personaD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }


                }
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }

        public static bool ImportarCatalogo(ref ArrayList strErrores, CPARAMETROBE parametro)
        {
            return ImportarCatalogo(ref strErrores, parametro, true, false);
        }




        public static bool ImportarCatalogo(ref ArrayList strErrores, CPARAMETROBE parametro, bool bMovil, bool bSoloNuevos)
        {
            string postFix = "";
            if (parametro.ITIPOVENDEDORMOVIL == 3 || parametro.ITIPOVENDEDORMOVIL == 4)
            {
                postFix = "_" + parametro.IVENDEDORMOVILCLAVE;
            }

            string strUnZippedFolder = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\PREC" + postFix + "\\";
            bool retorno = true;

            string comentario = "";

            /*
            if (!ImportarDatosSucursal(SUCURSAL_DBF_FILENAME, strUnZippedFolder, ref comentario))
            {
                retorno = false;
                strErrores.Add("Error al importar sucursales " + comentario);
            }

            try
            {
                if (!ImportarDatosEstado(ImportarDBF.EDOS_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los estados " + comentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los estados " + ex.Message);
            }

            */

            try
            {
                if (!ImportarDatosUnidad(ImportarDBF.UNIDAD_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar las unidades " + comentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar las unidades " + ex.Message);
            }

            try
            {
                if (!ImportarDatosBancos(ImportarDBF.BANK_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar los bancos " + comentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar los bancos " + ex.Message);
            }


            if (!ImportarDatosMarca(MARCA_DBF_FILENAME, strUnZippedFolder, false, ref comentario))
            {
                retorno = false;
                strErrores.Add("Error al importar marcas " + comentario);
            }


            if (!ImportarDatosLinea(LINEA_DBF_FILENAME, strUnZippedFolder, false, ref comentario))
            {
                retorno = false;
                strErrores.Add("Error al importar lineas " + comentario);
            }

            try
            {
                if (!ImportarDatosTasaIva(ImportarDBF.TASAIVA_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar tasaiva " + comentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar tasaiva " + ex.Message);
            }

            /*
            try
            {
                if (!ImportarDatosGrupoSucursal(ImportarDBF.GRUPOSUCURSAL_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar grupo de sucursales " + comentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar grupo de sucursales " + ex.Message);
            }*/

            try
            {
                if (!ImportarDatosCaracteristicasProducto(ImportarDBF.DEFCARACTPROD_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar caracteristicas de producto " + comentario);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar caracteristicas de producto " + ex.Message);
            }


            try
            {

                if (!ImportarDatosProveedor(PROVEEDOR_DBF_FILENAME, strUnZippedFolder, false, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar proveedores" + comentario);
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar proveedores " + ex.Message);
            }


            if (bMovil && !bSoloNuevos)
            {
                try
                {

                    CPRODUCTOD prodD = new CPRODUCTOD();
                    prodD.DESACTIVARTODOSLOSPRODUCTO(null);

                }
                catch (Exception ex)
                {
                    retorno = false;
                    strErrores.Add("Error al importar proveedores " + ex.Message);
                }
            }


            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
            {

                if (!ImportarDatosProd_2(PRODUCT_DBF_FILENAME, strUnZippedFolder, false, ref comentario, bMovil))
                {
                    strErrores.Add("Error al importar datos de producto" + comentario);
                    return false;
                }
            }
            else
            {


                if (!ImportarDatosProd(PRODUCT_DBF_FILENAME, strUnZippedFolder, bSoloNuevos, ref comentario, bMovil))
                {
                    strErrores.Add("Error al importar datos de producto" + comentario);
                    return false;
                }
            }




            if (parametro.IMANEJAKITS != null && parametro.IMANEJAKITS.Equals("S"))
            {
                if (!ImportarDatoskits(ImportarDBF.KITS_DBF_FILENAME, strUnZippedFolder, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar kits " + comentario);
                }
            }




            return retorno;
        }




        public static bool ImportarDatoskits(string fileName, string path, ref string comentario)
        {
            string m_strDbfCadenaConexion = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path;
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

                try
                {
                    if (!kittempD.KIT_PREPARETEMPTABLE(null))
                    {

                        comentario = kittempD.IComentario;
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


                        bResult = (kittempD.AgregarKITDEFTEMPD(retorno, null) != null);

                        if (bResult == false)
                        {
                            comentario = kittempD.IComentario;
                            //fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }


                    }
                }
                catch(Exception ex)
                {
                    comentario = "error al cargar los kis en la tabla temporal " +  ex.Message;
                    fConn.Close();
                    return false;
                }


                fTrans = fConn.BeginTransaction();
                if (!kittempD.KIT_APPLYTEMPTABLE(fTrans))
                {

                    comentario = kittempD.IComentario;
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
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }

        public static bool ImportarProdOnly_2(ref ArrayList strErrores, CPARAMETROBE parametro, bool bMovil)
        {



            string strUnZippedFolder = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\PREC\\";
            bool retorno = true;

            string comentario = "";



            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
            {

                if (!ImportarDatosProd_2(PRODUCT_DBF_FILENAME, strUnZippedFolder, false, ref comentario, bMovil))
                {
                    strErrores.Add("Error al importar datos de producto" + comentario);
                    return false;
                }
            }






            return retorno;
        }






        public static bool ImportarClientes(ref ArrayList strErrores, CPARAMETROBE parametro)
        {



            string strUnZippedFolder = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\PREC\\";
            bool retorno = true;

            string comentario = "";


            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
            {
                strUnZippedFolder = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\" + "PREC_" + CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE + "\\";
            }



            try
            {

                if (!ImportarDatosCliente(CLIENTE_DBF_FILENAME, strUnZippedFolder, false, ref comentario))
                {
                    retorno = false;
                    strErrores.Add("Error al importar proveedores" + comentario);
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                strErrores.Add("Error al importar cliente " + ex.Message);
            }



            return retorno;
        }








        public static bool ImportarHistorial(ref string comentario)
        {
            CPARAMETROBE parametros = CurrentUserID.CurrentParameters;
            CPERSONABE usuario = CurrentUserID.CurrentUser;
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\PREC\\";

            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
            {
                strPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\" + "PREC_" + CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE + "\\";
            }

            string m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + strPath + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  " + HISTORIAL_DBF_FILENAME;
            OleDbDataReader dr;
            dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //int iConsecutivo = 0;

            CIMPORTAR_DBF_LINE_SPBE importCompras;

            string strVentaAnterior = "";
            string strVentaActual = "";

            long doctoIDAnterior = 0;


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

                        if (strVentaActual == strVentaAnterior && doctoIDAnterior != 0)
                        {
                            importCompras.IDOCTOACTUALID = doctoIDAnterior;
                        }
                        else
                        {

                            if (doctoIDAnterior != 0)
                            {
                                CDOCTOD doctoD = new CDOCTOD();
                                CDOCTOBE doctoBE = new CDOCTOBE();
                                doctoBE.IID = doctoIDAnterior;
                                if (!doctoD.CerrarDOCTOD(doctoBE, fTrans))
                                {
                                    comentario = doctoD.IComentario;
                                    fTrans.Rollback();
                                    fConn.Close();
                                    return false;
                                }
                            }
                        }

                        strVentaAnterior = strVentaActual;

                    }

                    importCompras.IUSERID = CurrentUserID.CurrentUser.IID;

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        importCompras.IPRODUCTO = ((string)(dr["PRODUCTO"])).Trim();
                    }
                    /*if (dr["LOTE"] != System.DBNull.Value)
                    {
                        importCompras.ILOTE = ((string)(dr["LOTE"])).Trim();
                    }*/
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        importCompras.ICANTIDAD = decimal.Parse(dr["CANTIDAD"].ToString());
                    }


                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        importCompras.ICLIENTE = ((string)(dr["CLIENTE"])).Trim();
                    }


                    importCompras.ICANTIDADDEFACTURA = 0;
                    importCompras.ICANTIDADDEREMISION = importCompras.ICANTIDAD;
                    importCompras.ICANTIDADDEINDEFINIDO = 0;



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

                    importCompras.ISUCURSALID = parametros.ISUCURSALID;


                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        importCompras.ICOSTO = decimal.Parse(dr["PRECIO"].ToString());
                    }
                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        importCompras.IIMPORTE = decimal.Parse(dr["IMPORTE"].ToString());
                    }




                    try
                    {
                        if (dr["PREC_LISTA"] != System.DBNull.Value)
                        {
                            importCompras.IPRECIOVISIBLETRASLADO = decimal.Parse(dr["PREC_LISTA"].ToString());
                        }
                        else
                        {
                            importCompras.IPRECIOVISIBLETRASLADO = importCompras.ICOSTO;
                        }



                        if (dr["PREC_ACT"] != System.DBNull.Value)
                        {
                            importCompras.IPRECIOACT = decimal.Parse(dr["PREC_ACT"].ToString());
                        }

                        if (dr["DESCUENTO2"] != System.DBNull.Value)
                        {
                            importCompras.IDESCUENTOOTORGADO = decimal.Parse(dr["DESCUENTO2"].ToString());
                        }


                    }
                    catch
                    {
                        importCompras.IPRECIOVISIBLETRASLADO = importCompras.ICOSTO;
                    }




                    importCompras.ITIPODOCTOID = DBValues._DOCTO_TIPO_HISTORIALMOVIL;
                    importCompras.IALMACENTID = DBValues._DOCTO_ALMACEN_DEFAULT;

                    if (IMPORTAR_HISTORIALMOVIL(importCompras, fTrans, ref doctoIDAnterior, ref comentario) == false)
                    {
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                if (doctoIDAnterior != 0)
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = doctoIDAnterior;
                    if (!doctoD.CerrarDOCTOD(doctoBE, fTrans))
                    {
                        comentario = doctoD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }
                }


                CPRODUCTOD prodD = new CPRODUCTOD();
                if (!prodD.CambiarFlagHistorialMovilPRODUCTOD(0, fTrans))
                {
                    comentario = prodD.IComentario;
                    dr.Close();
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                dr.Close();
                fTrans.Commit();
                fConn.Close();

            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();

                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }







        public static bool IMPORTAR_HISTORIALMOVIL(CIMPORTAR_DBF_LINE_SPBE oCIMPORTAR_DBF_LINE_SP, FbTransaction st, ref long lDoctoId, ref string comentario)
        {

            string sCadenaConexion = ConexionesBD.ConexionBD.ConexionString();
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


                auxPar = new FbParameter("@PRECIOACT", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IPRECIOACT"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IPRECIOACT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCUENTOOTORGADO", FbDbType.Numeric);
                if (!(bool)oCIMPORTAR_DBF_LINE_SP.isnull["IDESCUENTOOTORGADO"])
                {
                    auxPar.Value = oCIMPORTAR_DBF_LINE_SP.IDESCUENTOOTORGADO;
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


                string commandText = @"IMPORTAR_HISTORIALMOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), sCadenaConexion, st);
                        comentario = "Hubo un error : " + strMensajeErr;
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
                comentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public static bool AbrirCorte(ref string comentario)
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            DateTime fechaCorteActiva = DateTime.MinValue;
            if (corteD.HayCorteActivo(iPos.CurrentUserID.CurrentUser.IID, null, ref fechaCorteActiva))
            {
                return true;
            }
            corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            corteBE.ICAJEROID = CurrentUserID.CurrentUser.IID;
            corteBE.IFECHACORTE = DateTime.Now;
            //corteBE.ITURNOID = long.Parse(CBTurno.SelectedValue.ToString());
            corteBE.ISALDOINICIAL = (decimal)0.00;
            corteBE.ITIPOCORTEID = DBValues._TIPO_CORTENORMAL;



            corteBE = corteD.AbrirCORTED(corteBE, null);
            if (corteBE == null)
            {
                comentario = corteD.IComentario;
                return false;
            }
            else
            {
                ActualizaCurrentUser();
                return true;
            }

        }


        private static void ActualizaCurrentUser()
        {
            CPERSONAD personaD = new CPERSONAD();
            CurrentUserID.CurrentUser = personaD.seleccionarPERSONA(CurrentUserID.CurrentUser, null);
        }



        public static bool AgregarInventarioInicialProd(string productoClave, decimal cantidad, string lote, DateTime fechavence, FbTransaction st, ref string refComentario)
        {
            try
            {
                string sCadenaConexion = ConexionesBD.ConexionBD.ConexionString();

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
                if (fechavence == DateTime.MinValue)
                {
                    auxPar.Value = DBNull.Value;
                }
                else
                {
                    auxPar.Value = fechavence;
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
                auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAIMPO", FbDbType.Date);
                auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCAMBIOIMPO", FbDbType.Numeric);
                auxPar.Value = DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"INVENTARIO_INICIAL_AGREGAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        int iErrorCode = (int)arParms[arParms.Length - 1].Value;
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)iErrorCode, sCadenaConexion, st);
                        refComentario += "ERROR : " + strMensajeErr;
                        if (iErrorCode == 1069)
                            refComentario += " " + productoClave;
                        else
                            return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                refComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public static bool Post_ImportacionInventarioInicial(FbTransaction st, ref string refComentario)
        {

            string sCadenaConexion = ConexionesBD.ConexionBD.ConexionString();

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
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), sCadenaConexion, st);
                        refComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                refComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public static Boolean CopyEmtpyTablesVentaMovilDBF(string dbFileNameDetalle, string dbFileNameHeader)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_VentasMovilFTP_Molde;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_VentasMovilFTP;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            if (File.Exists(path + "\\" + dbFileNameDetalle + ".dbf"))
                File.Delete(path + "\\" + dbFileNameDetalle + ".dbf");

            if (File.Exists(path + "\\" + dbFileNameHeader + ".dbf"))
                File.Delete(path + "\\" + dbFileNameHeader + ".dbf");



            File.Copy(pathMolde + "\\" + FileNameVentaMovilDetalleFTP + ".dbf", path + "\\" + dbFileNameDetalle + ".dbf");
            File.Copy(pathMolde + "\\" + FileNameVentaMovilHeaderFTP + ".dbf", path + "\\" + dbFileNameHeader + ".dbf");



            return true;
        }


        public static bool exportarVentasMoviles(FbTransaction st, long corteId, ref string refComentario)
        {
            CMOVTOBE detalleVentas = new CMOVTOBE();

            CM_VEDPD vedsD = new CM_VEDPD();
            CM_VEDPBE vedsBE = new CM_VEDPBE();

            CM_VENPBE vensBE = new CM_VENPBE();
            CM_VENPD vensD = new CM_VENPD();

            refComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            string sCadenaConexion = ConexionesBD.ConexionBD.ConexionString();



            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_VentasMovilFTP;
            string strTableExpNameDet = VENTAMOVILDTL_DBF_FILENAME;
            string strTableExpNameHdr = VENTAMOVILHDR_DBF_FILENAME;

            CopyEmtpyTablesVentaMovilDBF(strTableExpNameDet, strTableExpNameHdr);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            string strIDDosLetras = CurrentUserID.CurrentParameters.IID_DOSLETRAS;


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
                                               PRODUCTO.CLASIFICA,
                                                MOVTO.DESCUENTOPORCENTAJE
                                                
                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid  LEFT JOIN
                                                    turno  ON TURNO.id = docto.turnoid  LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid
                                    WHERE        DOCTO.CORTEID = @CORTEID AND DOCTO.ESTATUSDOCTOID = 1 AND DOCTO.TIPODOCTOID = 321
                                    ORDER BY DOCTOID, MOVTOID";

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    vedsBE = new CM_VEDPBE();




                    if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    {
                        vedsBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    }
                    else
                        vedsBE.ICLIENTE = "";

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        vedsBE.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRECIO = (decimal)(dr["PRECIO"]);
                    }


                    if (dr["DESCUENTOPORCENTAJE"] != System.DBNull.Value)
                    {
                        vedsBE.IDESCUENTO = (decimal)(dr["DESCUENTOPORCENTAJE"]);
                    }
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        vedsBE.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vedsBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                    }
                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        vedsBE.IVENTA = dr["FOLIO"].ToString();
                    }



                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        vedsBE.IDESC1 = dr["DESCRIPCION"].ToString();
                    }


                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        vedsBE.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }
                    else
                        vedsBE.ICLASIFICA = "";



                    vedsBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();


                    vedsBE.IID = "CAJA";
                    if (null == vedsD.AgregarM_VEDPD(vedsBE, strTableExpNameDet, null, strOleDbConn))
                    {

                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        refComentario += vedsD.IComentario + "\n";
                        return false;
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                refComentario = e.Message + e.StackTrace;
                return false;
            }



            try
            {

                parts = new ArrayList();

                CmdTxt = @"                                   SELECT       DOCTO.ID AS DOCTOID,
                                                DOCTO.FECHA AS FECHA  ,
                                                PERSONA.clave CLAVECLIENTE,
                                                DOCTO.FOLIO FOLIO,
                                                DOCTO.OBSERVACION,
                                                DOCTO.DESCRIPCION,
                                                DOCTO.ORIGENFISCALID

                                   FROM         DOCTO  left OUTER JOIN
                                                PERSONA ON PERSONA.ID = DOCTO.personaid
                                    WHERE       DOCTO.CORTEID = @CORTEID AND DOCTO.ESTATUSDOCTOID = 1 AND DOCTO.TIPODOCTOID = 321
                                    ORDER BY    DOCTOID";



                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {

                    vensBE = new CM_VENPBE();

                    if (dr["CLAVECLIENTE"] != System.DBNull.Value)
                    {
                        vensBE.ICLIENTE = (string)(dr["CLAVECLIENTE"]);
                    }



                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        vensBE.IVENTA = dr["FOLIO"].ToString();
                    }


                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        vensBE.IID_FECHA = (DateTime)(dr["FECHA"]);
                        //vensBE.IF_FACTURA = (DateTime)(dr["FECHA"]);
                    }

                    vensBE.IID = "CAJA";
                    vensBE.IID_HORA = DateTime.Now.TimeOfDay.ToString();



                    if (dr["OBSERVACION"] != System.DBNull.Value)
                    {
                        vensBE.INOTA1 = (string)(dr["OBSERVACION"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        vensBE.INOTA2 = (string)(dr["DESCRIPCION"]);
                    }


                    if (dr["ORIGENFISCALID"] != System.DBNull.Value)
                    {
                        long origenFiscalId = long.Parse(dr["ORIGENFISCALID"].ToString());
                        string strEstatus = origenFiscalId == DBValues._ORIGENFISCAL_FACTURADO ? "F" : "R";
                        vensBE.IESTATUS = strEstatus;
                    }



                    if (vensD.AgregarM_VENPD(vensBE, strTableExpNameHdr, null, strOleDbConn) == null)
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                        refComentario += vensD.IComentario + "\n";
                        return false;
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                string ftpPath = FileFTPLocation_VentaMovil + "\\";

                ArrayList resultadosExportacion = new ArrayList();
                bool bArchivoSubido = false;

                if (iPos.ImportaDesdeFtp.UploadFile(strTableExpNameDet + ".dbf", path, ftpPath, true, true, ref resultadosExportacion))
                    if (iPos.ImportaDesdeFtp.UploadFile(strTableExpNameHdr + ".dbf", path, ftpPath, true, true, ref resultadosExportacion))
                        bArchivoSubido = true;

                foreach (string str in resultadosExportacion)
                {
                    refComentario += str;
                }

                return bArchivoSubido;

            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                refComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public static bool ImportarCobranza(ref string comentario)
        {
            CPARAMETROBE parametros = CurrentUserID.CurrentParameters;
            CPERSONABE usuario = CurrentUserID.CurrentUser;
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\PREC\\";

            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
            {
                strPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\" + "PREC_" + CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE + "\\";
            }

            string m_strDbfCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + strPath + "\";Extended Properties=dBASE IV;User ID=Admin;Password=";
            string CmdTxt = "SELECT * FROM  " + COBRANZA_DBF_FILENAME;
            OleDbDataReader dr;
            dr = OleDbSQLHelper.ExecuteReader(m_strDbfCadenaConexion, CommandType.Text, CmdTxt, null);

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CCOBRANZAMOVILBE cobranzaBE = new CCOBRANZAMOVILBE();
            CCOBRANZAMOVILD cobranzaD = new CCOBRANZAMOVILD();


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                while (dr.Read())
                {
                    cobranzaBE = new CCOBRANZAMOVILBE();

                    if (dr["COBRANZA"] != System.DBNull.Value) cobranzaBE.ICOBRANZA = ((string)(dr["COBRANZA"])).Trim();
                    if (dr["VENDEDOR"] != System.DBNull.Value) cobranzaBE.IVENDEDOR = ((string)(dr["VENDEDOR"])).Trim();
                    if (dr["VENTA"] != System.DBNull.Value) cobranzaBE.IVENTA = ((string)(dr["VENTA"])).Trim();
                    if (dr["EMPRESA"] != System.DBNull.Value) cobranzaBE.IEMPRESA = ((string)(dr["EMPRESA"])).Trim();
                    if (dr["CLIENTE"] != System.DBNull.Value) cobranzaBE.ICLIENTE = ((string)(dr["CLIENTE"])).Trim();
                    if (dr["NOMBRE"] != System.DBNull.Value) cobranzaBE.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    if (dr["FACTURA"] != System.DBNull.Value) cobranzaBE.IFACTURA = ((string)(dr["FACTURA"])).Trim();
                    if (dr["ESTATUS"] != System.DBNull.Value) cobranzaBE.IESTATUS = ((string)(dr["ESTATUS"])).Trim();
                    if (dr["OBS"] != System.DBNull.Value) cobranzaBE.IOBS = ((string)(dr["OBS"])).Trim();



                    if (dr["F_FACTURA"] != System.DBNull.Value) cobranzaBE.IF_FACTURA = DateTime.Parse(dr["F_FACTURA"].ToString());
                    if (dr["F_PAGO"] != System.DBNull.Value) cobranzaBE.IF_PAGO = DateTime.Parse(dr["F_PAGO"].ToString());

                    if (dr["DIAS"] != System.DBNull.Value) cobranzaBE.IDIAS = int.Parse(dr["DIAS"].ToString());

                    if (dr["TOTAL"] != System.DBNull.Value) cobranzaBE.ITOTAL = decimal.Parse(dr["TOTAL"].ToString());
                    if (dr["A_CUENTA"] != System.DBNull.Value) cobranzaBE.IA_CUENTA = decimal.Parse(dr["A_CUENTA"].ToString());
                    if (dr["SALDO"] != System.DBNull.Value) cobranzaBE.ISALDO = decimal.Parse(dr["SALDO"].ToString());
                    if (dr["INT_COB"] != System.DBNull.Value) cobranzaBE.IINT_COB = decimal.Parse(dr["INT_COB"].ToString());
                    if (dr["INTERESES"] != System.DBNull.Value) cobranzaBE.IINTERESES = decimal.Parse(dr["INTERESES"].ToString());
                    if (dr["IMPOR_NETO"] != System.DBNull.Value) cobranzaBE.IIMPOR_NETO = decimal.Parse(dr["IMPOR_NETO"].ToString());
                    if (dr["PAGO"] != System.DBNull.Value) cobranzaBE.IPAGO = decimal.Parse(dr["PAGO"].ToString());
                    if (dr["EFECTIVO"] != System.DBNull.Value) cobranzaBE.IEFECTIVO = decimal.Parse(dr["EFECTIVO"].ToString());
                    if (dr["DIFERENCIA"] != System.DBNull.Value) cobranzaBE.IDIFERENCIA = decimal.Parse(dr["DIFERENCIA"].ToString());
                    if (dr["IMP_CHEQUE"] != System.DBNull.Value) cobranzaBE.IIMP_CHEQUE = decimal.Parse(dr["IMP_CHEQUE"].ToString());

                    if (dr["BANCO"] != System.DBNull.Value) cobranzaBE.IBANCO = ((string)(dr["BANCO"])).Trim();

                    if (dr["NUM_CHEQ"] != System.DBNull.Value) cobranzaBE.INUM_CHEQ = int.Parse(dr["NUM_CHEQ"].ToString());

                    if (dr["INTERES"] != System.DBNull.Value) cobranzaBE.IINTERES = decimal.Parse(dr["INTERES"].ToString());
                    if (dr["CAPITAL"] != System.DBNull.Value) cobranzaBE.ICAPITAL = decimal.Parse(dr["CAPITAL"].ToString());


                    if (dr["OLLA"] != System.DBNull.Value) cobranzaBE.IOLLA = ((string)(dr["OLLA"])).Trim();
                    if (dr["BLOQUEADO"] != System.DBNull.Value) cobranzaBE.IBLOQUEADO = ((string)(dr["BLOQUEADO"])).Trim();


                    if (dr["FECHA"] != System.DBNull.Value) cobranzaBE.IFECHA = DateTime.Parse(dr["FECHA"].ToString());


                    if (dr["LLEVAR"] != System.DBNull.Value) cobranzaBE.ILLEVAR = ((string)(dr["LLEVAR"])).Trim();

                    if (dr["SALDO"] != System.DBNull.Value) cobranzaBE.ISALDOMOVIL = decimal.Parse(dr["SALDO"].ToString());

                    cobranzaBE.IABONOSMOVIL = 0;

                    if (cobranzaD.AgregarCOBRANZAMOVILD(cobranzaBE, fTrans) == null)
                    {

                        comentario = cobranzaD.IComentario;
                        dr.Close();
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }

                }

                if (!cobranzaD.MOVIL_COMPLETARIMPOCOBRANZA(fTrans))
                {
                    comentario = cobranzaD.IComentario;
                    dr.Close();
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }


                dr.Close();
                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                fTrans.Rollback();
                fConn.Close();

                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                dr.Close();
                fConn.Close();
            }
            return true;

        }





        public static void EnvioClientes(bool bSoloNuevos, ref bool bError, ref string strError)
        {
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }


                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = bSoloNuevos ? @"select ID from PERSONA where TIPOPERSONAID = 50 AND ESTATUSENVIOID = 3 " :
                    @"select ID from PERSONA where TIPOPERSONAID = 50 AND ESTATUSENVIOID in (2,3) ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);

                CPERSONAD personaD = new CPERSONAD();
                ArrayList clientesArray = new ArrayList();
                ArrayList personaArray = new ArrayList();

                while (dr.Read())
                {
                    CPERSONABE persona = new CPERSONABE();
                    CM_CLIPBE clip = null;

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        persona.IID = (long)(dr["ID"]);
                        persona = personaD.seleccionarPERSONA(persona, null);
                    }

                    if (persona != null)
                    {
                        clip = convertCLienteIntoCLIP(persona);
                        clientesArray.Add(clip);
                        personaArray.Add(persona);
                    }
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                if (clientesArray.Count > 0)
                {

                    CM_CLIPBE[] detailbes = new CM_CLIPBE[clientesArray.Count];
                    clientesArray.CopyTo(detailbes, 0);
                    string jsonStr = JsonConvert.SerializeObject(detailbes, Formatting.Indented);

                    string strRespuesta = "";
                    try
                    {
                        if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                        {
                            strRespuesta = service1.CambiarClienteMovil_2(jsonStr, iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }
                        else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
                        {
                            strRespuesta = service1.CambiarClienteMovil(jsonStr, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }
                        else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                        {
                            strRespuesta = service1.CambiarClienteMovil_3(jsonStr, iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                        }

                        if (!strRespuesta.Equals("exito"))
                        {

                            bError = true;
                            strError += "  No se pudo enviar la actualizacion de clientes : " + strRespuesta;
                        }
                        else
                        {
                            foreach (CPERSONABE persona in personaArray)
                            {
                                persona.IESTATUSENVIOID = DBValues._PERSONA_ESTATUSENVIO_SINCRONIZADO;
                                personaD.CambiarESTATUSENVIO(persona, persona, null);

                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        bError = true;
                        strError += " Excepcion al procesar el envio de cambios de los clientes : " + ex.Message + ex.StackTrace;
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                bError = true;
                strError += " Excepcion al procesar el envio de cambios de los clientes : " + ex.Message + ex.StackTrace;
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return;
            }


        }


        public static CM_CLIPBE convertCLienteIntoCLIP(CPERSONABE personaBE)
        {

            CM_CLIPBE item = new CM_CLIPBE();

            if (!(bool)personaBE.isnull["ICLAVE"])
            {

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 4)
                {
                    item.ICLIENTE = convertCustomerClaveToClipClave(personaBE.ICLAVE);
                }
                else
                {
                    item.ICLIENTE = personaBE.ICLAVE;
                }
            }

            if (!(bool)personaBE.isnull["INOMBRE"])
                item.INOMBRE = personaBE.INOMBRE;

            if (!(bool)personaBE.isnull["INOMBRES"])
                item.INOMBRES = personaBE.INOMBRES;

            if (!(bool)personaBE.isnull["IAPELLIDOS"])
                item.IPATERNO = personaBE.IAPELLIDOS;

            if (!(bool)personaBE.isnull["IDOMICILIO"])
                item.ICALLE = personaBE.IDOMICILIO;


            if (!(bool)personaBE.isnull["ICOLONIA"])
                item.ICOLONIA = personaBE.ICOLONIA;

            if (!(bool)personaBE.isnull["ICIUDAD"])
                item.ICIUDAD = personaBE.ICIUDAD;

            if (!(bool)personaBE.isnull["IESTADO"])
                item.IESTADO = personaBE.IESTADO;


            if (!(bool)personaBE.isnull["ICODIGOPOSTAL"])
                item.ICP = personaBE.ICODIGOPOSTAL;


            if (!(bool)personaBE.isnull["ITELEFONO1"])
                item.ITELEFONO = personaBE.ITELEFONO1;
            if (!(bool)personaBE.isnull["ITELEFONO2"])
                item.ITELEFONO2 = personaBE.ITELEFONO2;
            if (!(bool)personaBE.isnull["ICONTACTO1"])
                item.ICONTACTO = personaBE.ICONTACTO1;
            if (!(bool)personaBE.isnull["ICONTACTO2"])
                item.ICONTACTO2 = personaBE.ICONTACTO2;
            if (!(bool)personaBE.isnull["IRFC"])
                item.IRFC = personaBE.IRFC;


            if (!(bool)personaBE.isnull["ILISTAPRECIOID"])
                item.IL_DESC = personaBE.ILISTAPRECIOID.ToString();


            if (!(bool)personaBE.isnull["ILIMITECREDITO"])
                item.ILIMITE = Double.Parse(personaBE.ILIMITECREDITO.ToString());



            if (!(bool)personaBE.isnull["IBLOQUEADO"])
                item.IBLOQUEADO = personaBE.IBLOQUEADO;



            if (!(bool)personaBE.isnull["IDIAS"])
                item.IDIAS = Double.Parse(personaBE.IDIAS.ToString());



            if (!(bool)personaBE.isnull["IEMAIL1"])
                item.IEMAIL = personaBE.IEMAIL1;



            if (!(bool)personaBE.isnull["IPAGOS"])
                item.IPAGOS = personaBE.IPAGOS;

            if (!(bool)personaBE.isnull["ISALDO"])
                item.ISALDO = Double.Parse(personaBE.ISALDO.ToString());


            if (!(bool)personaBE.isnull["IBLOQUEONOT"])
                item.IBLOQUEONOT = personaBE.IBLOQUEONOT;

            if (!(bool)personaBE.isnull["IEMAIL2"])
                item.IEMAIL2 = personaBE.IEMAIL2;



            try
            {

                CPERSONAD personaD = new CPERSONAD();
                CPERSONABE vendedorBE = new CPERSONABE();
                vendedorBE.IID = personaBE.IID;
                vendedorBE = personaD.seleccionarPERSONA(vendedorBE, null);

                if(vendedorBE != null)
                {
                    item.IVENDEDOR = vendedorBE.ICLAVE;
                }
            }
            catch
            { }


            if (!(bool)personaBE.isnull["IMEMO"])
                item.ICRUZACON = personaBE.IMEMO;



            if (!(bool)personaBE.isnull["IEMAIL2"])
                item.IEMAIL2 = personaBE.IEMAIL2;


            if (!(bool)personaBE.isnull["IDESGLOSEIEPS"])
                item.IDESGIEPS = personaBE.IDESGLOSEIEPS;



            if (!(bool)personaBE.isnull["INUMEROEXTERIOR"])
                item.IFENUECL = personaBE.INUMEROEXTERIOR;



            if (!(bool)personaBE.isnull["INUMEROINTERIOR"])
                item.IFENUICL = personaBE.INUMEROINTERIOR;


            string strComodin = "";


            if (!(bool)personaBE.isnull["IHAB_PAGOTARJETA"] &&
                personaBE.IHAB_PAGOTARJETA != null && personaBE.IHAB_PAGOTARJETA == "S")
            {
                strComodin += "TARJ|";
            }

            if (!(bool)personaBE.isnull["IHAB_PAGOTRANSFERENCIA"] &&
                personaBE.IHAB_PAGOTRANSFERENCIA != null && personaBE.IHAB_PAGOTRANSFERENCIA == "S")
            {
                strComodin += "TRAN|";
            }
            if (!(bool)personaBE.isnull["IHAB_PAGOCREDITO"] &&
                personaBE.IHAB_PAGOCREDITO != null && personaBE.IHAB_PAGOCREDITO == "S")
            {
                strComodin += "CRED|";
            }
            if (!(bool)personaBE.isnull["IHAB_PAGOCHEQUE"] &&
                personaBE.IHAB_PAGOCHEQUE != null && personaBE.IHAB_PAGOCHEQUE == "S")
            {
                strComodin += "CHEQ|";
            }

            item.ICOMODIN = strComodin;

            return item;


        }



        public static string convertCustomerClaveToClipClave(string customerClave)
        {
            string clipClave = "";

            if (customerClave.Trim().Length <= 6)
                return customerClave.Trim().PadLeft(6);


            int iStartIndex = customerClave.IndexOfAny("0123456789".ToCharArray());
            if (iStartIndex > -1 && iStartIndex < 5)
            {
                string strSubString1 = customerClave.Substring(0, iStartIndex);
                string strSubString2 = customerClave.Substring(iStartIndex, customerClave.Length - iStartIndex);
                strSubString2 = strSubString2.TrimStart("0".ToCharArray()).PadLeft(6 - iStartIndex, '0');

                clipClave = strSubString1 + strSubString2;
            }
            else
            {
                clipClave = "LARGOO";
            }

            return clipClave;
        }





        public static DateTime GetUltimaModificacionPrecioMovil()
        {
            try
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                DateTime dtRespuesta = DateTime.MinValue;
                try
                {

                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                    {
                        dtRespuesta = service1.UltimaModificacionProductoMovil_2(iPos.CurrentUserID.CurrentParameters.IBDSERVERWS,
                                        iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {

                        dtRespuesta = service1.UltimaModificacionProductoMovil(iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }

                    return dtRespuesta;
                }
                catch
                {
                    return DateTime.MinValue;
                }


            }
            catch
            {
                return DateTime.MinValue;
            }


        }





        public static Boolean PrepareFileInServerForMovil(ref string strError)
        {
            try
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                string strRespuesta = "";
                try
                {
                    strRespuesta = service1.PrepareFileInServerForMovil(iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);


                    if (!strRespuesta.Equals("exito"))
                    {
                        strError = strRespuesta;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }


        }


        public static List<CMPRODBE> getUpdatedProducts(DateTime fecha)
        {

            try
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                string strRespuesta = "";
                try
                {

                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                    {
                        //strRespuesta = service1.getUpdatedProductosExis_3(fecha,"", iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                        //            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                        //            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                        strRespuesta = service1.getUpdatedProductosMovil_3(fecha, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                      iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                      iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                    {
                        strRespuesta = service1.getUpdatedProductosMovil_2(fecha, iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {

                        strRespuesta = service1.getUpdatedProductosMovil(fecha, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }

                    if (!strRespuesta.StartsWith("["))
                    {
                        return new List<CMPRODBE>();
                    }
                    else
                    {
                        List<CMPRODBE> detalles = JsonConvert.DeserializeObject<List<CMPRODBE>>(strRespuesta);
                        return detalles;
                    }
                }
                catch
                {
                    return new List<CMPRODBE>();
                }


            }
            catch
            {
                return new List<CMPRODBE>();
            }




        }




        public static bool ImportarDatosProdUpdated(ref string comentario)
        {





            //get data for the generation of the dbfs
            CPARAMETROD parametroD = new CPARAMETROD();

            DateTime newUltDate = DateTime.Parse("01/01/2013");
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }
            else
            {

                newUltDate = parametroBE.ILASTCHANGEPRECIOPROD;
            }




            List<CMPRODBE> productos = getUpdatedProducts(parametroBE.ILASTCHANGEPRECIOPROD);

            if (productos == null || productos.Count == 0)
                return true;


            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPRODUCTOBE prodBuffer = new CPRODUCTOBE();

            string claveLinea = "", claveMarca = "", claveMoneda = "", claveSustituto = "", claveTasaIva = "", claveProductoPadre = "";
            string claveProveedor1 = "", claveProveedor2 = "";
            //DateTime fcambio;
            //int iOperation = (int)DBOperations.OperAgregar;
            bool bResult;




            decimal cantidad;
            //string lote = null;
            DateTime fechavence = DateTime.MinValue;
            //string refComentario = "";

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                int iV = 0;
                foreach (CMPRODBE prod in productos)
                {
                    iV++;


                    cantidad = 0;
                    //lote = null;
                    fechavence = DateTime.MinValue;

                    claveLinea = ""; claveMarca = ""; claveMoneda = ""; claveSustituto = ""; claveTasaIva = ""; claveProductoPadre = "";
                    claveProveedor1 = ""; claveProveedor2 = "";
                    retorno = new CPRODUCTOBE();
                    //iOperation = (int)DBOperations.OperAgregar;


                    if (!(bool)prod.isnull["IPRODUCTO"])
                    {
                        retorno.ICLAVE = prod.IPRODUCTO.Trim();
                    }

                    retorno.INOMBRE = retorno.ICLAVE;


                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        continue;

                    /*if (!(bool)prod.isnull["IFCAMBIO"])
                    {
                        if(prod.IFCAMBIO > newUltDate)
                            newUltDate = prod.IFCAMBIO;
                    }*/

                    if (!(bool)prod.isnull["IID_FECHA"])
                    {
                        DateTime bufferFecha = prod.IID_FECHA;

                        if (!(bool)prod.isnull["IID_HORA"])
                        {
                            string strHora = prod.IID_HORA;
                            bufferFecha = bufferFecha.Add(TimeSpan.Parse(strHora));
                        }


                        if (bufferFecha > newUltDate)
                            newUltDate = bufferFecha;


                    }

                    // solo se hace esto cuando solo se quieran agregar los nuevos productos



                    if (!(bool)prod.isnull["IDESC1"])
                    {
                        retorno.IDESCRIPCION1 = prod.IDESC1.Trim();
                    }


                    try
                    {
                        if (!(bool)prod.isnull["IDESC2"])
                        {
                            retorno.IDESCRIPCION2 = prod.IDESC2.Trim();
                        }
                        if (!(bool)prod.isnull["IDESC3"])
                        {
                            retorno.IDESCRIPCION3 = prod.IDESC3.Trim();
                        }
                    }
                    catch
                    {
                        retorno.IDESCRIPCION2 = retorno.IDESCRIPCION1;
                        retorno.IDESCRIPCION3 = retorno.IDESCRIPCION1;
                    }



                    if (!(bool)prod.isnull["ILINEA"])
                    {
                        claveLinea = prod.ILINEA.Trim();
                    }
                    if (!(bool)prod.isnull["IMARCA"])
                    {
                        claveMarca = prod.IMARCA.Trim();
                    }
                    if (!(bool)prod.isnull["IPRECIO1"])
                    {
                        retorno.IPRECIO1 = prod.IPRECIO1;
                    }
                    if (!(bool)prod.isnull["IPRECIO2"])
                    {
                        retorno.IPRECIO2 = prod.IPRECIO2;
                    }
                    if (!(bool)prod.isnull["IPRECIO3"])
                    {
                        retorno.IPRECIO3 = prod.IPRECIO3;
                    }
                    if (!(bool)prod.isnull["IPRECIO4"])
                    {
                        retorno.IPRECIO4 = prod.IPRECIO4;
                    }
                    if (!(bool)prod.isnull["IPRECIO5"])
                    {
                        retorno.IPRECIO5 = prod.IPRECIO5;
                    }

                    if (!(bool)prod.isnull["IMONEDA"])
                    {
                        claveMoneda = prod.IMONEDA.Trim();
                    }

                    if (!(bool)prod.isnull["IIVA"])
                    {
                        retorno.ITASAIVA = prod.IIVA;
                    }

                    if (!(bool)prod.isnull["ICVETASAIVA"])
                    {
                        claveTasaIva = prod.ICVETASAIVA;
                    }


                    if (!(bool)prod.isnull["ICOSTO_REPO"])
                    {
                        retorno.ICOSTOREPOSICION = prod.ICOSTO_REPO;
                    }

                    if (!(bool)prod.isnull["ICODIGO"])
                    {
                        retorno.IEAN = prod.ICODIGO.Trim();
                    }

                    if (!(bool)prod.isnull["ISUSTITUTO"] && prod.ISUSTITUTO != null)
                    {

                        claveSustituto = prod.ISUSTITUTO.Trim();
                        claveSustituto = claveSustituto.Trim();
                    }


                    if (!(bool)prod.isnull["ILOTE"])
                    {
                        retorno.IMANEJALOTE = prod.ILOTE.Trim();
                    }
                    if (!(bool)prod.isnull["IKIT"])
                    {
                        retorno.IESKIT = prod.IKIT.Trim();
                    }
                    if (!(bool)prod.isnull["IIMPRIMIR"])
                    {
                        if (prod.IIMPRIMIR != "S")
                            retorno.IIMPRIMIR = "N";
                        else
                            retorno.IIMPRIMIR = "S";
                    }
                    if (!(bool)prod.isnull["IINVENTARIO"])
                    {
                        if (prod.IINVENTARIO != "S")
                            retorno.IINVENTARIABLE = "N";
                        else
                            retorno.IINVENTARIABLE = "S";

                    }
                    retorno.INEGATIVOS = "S";

                    if (!(bool)prod.isnull["ISUSTITUTO"] && prod.ISUSTITUTO != null)
                    {
                        retorno.ISUBSTITUTO = prod.ISUSTITUTO.Trim();
                    }

                    if (!(bool)prod.isnull["ICBARRAS"] && prod.ICBARRAS != null)
                    {
                        retorno.ICBARRAS = prod.ICBARRAS.Trim();
                    }


                    if (!(bool)prod.isnull["ICEMPAQUE"] && prod.ICEMPAQUE != null)
                    {
                        retorno.ICEMPAQUE = prod.ICEMPAQUE.Trim();
                    }




                    try
                    {
                        if (!(bool)prod.isnull["IBOTCAJA"])
                        {
                            retorno.IPZACAJA = prod.IBOTCAJA;
                        }
                    }
                    catch
                    {
                    }



                    if (!(bool)prod.isnull["IU_EMPAQUE"])
                    {
                        retorno.IU_EMPAQUE = prod.IU_EMPAQUE;
                    }


                    if (!(bool)prod.isnull["IUNIDAD"])
                    {
                        retorno.IUNIDAD = prod.IUNIDAD.Trim();
                    }


                    if (!(bool)prod.isnull["IINIMAYO"])
                    {
                        retorno.IINI_MAYO = prod.IINIMAYO;
                    }


                    if (!(bool)prod.isnull["IMAYOXKG"])
                    {
                        retorno.IMAYOKGS = prod.IMAYOXKG == null ? prod.IMAYOXKG.Trim() : "";

                        if (retorno.IMAYOKGS.Trim() == "")
                            retorno.IMAYOKGS = "N";
                    }
                    else
                    {
                        retorno.IMAYOKGS = "N";
                    }


                    if (!(bool)prod.isnull["ITIPOABC"])
                    {
                        retorno.ITIPOABC = prod.ITIPOABC != null ? prod.ITIPOABC.Trim() : "";

                        if (retorno.ITIPOABC.Trim() != "N")
                            retorno.ITIPOABC = "S";
                    }
                    else
                    {
                        retorno.ITIPOABC = "S";
                    }








                    if (!(bool)prod.isnull["ICOMISION"])
                    {
                        retorno.ICOMISION = prod.ICOMISION;
                    }


                    try
                    {

                        if (!(bool)prod.isnull["IPROVEEDOR"])
                        {
                            claveProveedor1 = prod.IPROVEEDOR != null ? prod.IPROVEEDOR.Trim() : "";
                        }

                        if (!(bool)prod.isnull["IPROVEEDOR2"])
                        {
                            claveProveedor2 = prod.IPROVEEDOR2 != null ? prod.IPROVEEDOR2.Trim() : "";
                        }


                    }
                    catch
                    {
                    }


                    try
                    {
                        if (!(bool)prod.isnull["IPLUG"])
                        {
                            retorno.IPLUG = prod.IPLUG != null ? prod.IPLUG.Trim() : "";
                        }/*
                        else if (!(bool)prod.isnull["ISUSTITUTO"])
                        {
                            retorno.IPLUG = prod.ISUSTITUTO.Trim();
                        }*/

                    }
                    catch
                    {
                    }



                    try
                    {
                        if (!(bool)prod.isnull["IIEPS"])
                        {
                            retorno.ITASAIEPS = prod.IIEPS;
                        }
                    }
                    catch
                    {
                    }


                    retorno.IREQUIERERECETA = @"N";


                    try
                    {
                        if (!(bool)prod.isnull["IPLAZO"])
                        {
                            retorno.ICLASIFICA = prod.IPLAZO != null ? prod.IPLAZO.Trim() : "";
                        }
                    }
                    catch
                    {
                    }


                    try
                    {

                        if (!(bool)prod.isnull["IEXIS1"])
                        {
                            cantidad = prod.IEXIS1;
                        }
                    }
                    catch
                    {

                    }

                    retorno.IPROMOMOVIL = "N";
                    try
                    {
                        if (!(bool)prod.isnull["IPROD_PROMO"])
                        {
                            retorno.IPROMOMOVIL = prod.IPROD_PROMO != null ? prod.IPROD_PROMO : "";
                            if (retorno.IPROMOMOVIL.Trim() == "")
                                retorno.IPROMOMOVIL = "N";
                        }
                    }
                    catch
                    {
                    }
                    if (retorno.IPROMOMOVIL == null || !(retorno.IPROMOMOVIL.Equals("N") || retorno.IPROMOMOVIL.Equals("S")))
                    {
                        retorno.IPROMOMOVIL = "N";
                    }


                    try
                    {

                        if (!(bool)prod.isnull["IMARGEN"])
                        {
                            retorno.IMARGENMOVIL = prod.IMARGEN;
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (!(bool)prod.isnull["IMPRECIO4"])
                        {
                            retorno.IMPRECIO4MOVIL = prod.IMPRECIO4;
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (!(bool)prod.isnull["ICPRECIO4"])
                        {
                            retorno.ICPRECIO4MOVIL = prod.ICPRECIO4;
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (!(bool)prod.isnull["ITPRECIO4"])
                        {
                            retorno.ITPRECIO4MOVIL = prod.ITPRECIO4;
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (!(bool)prod.isnull["IAPRECIO4"])
                        {
                            retorno.IAPRECIO4MOVIL = prod.IAPRECIO4;
                        }

                    }
                    catch
                    {

                    }





                    bResult = productoD.importarPRODUCTODMOVIL(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, claveTasaIva, claveProductoPadre, fTrans);



                    if (bResult == false)
                    {
                        comentario = productoD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        return false;
                    }



                }

                if (!productoD.PRODUCTOPRECIO(fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }



                /*if (DateTime.Now > newUltDate)
                    newUltDate = DateTime.Now;*/
                parametroBE.ILASTCHANGEPRECIOPROD = newUltDate;
                if (!parametroD.CambiarLASTCHANGEPRECIOPROD(parametroBE, parametroBE, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }


                CurrentUserID.CurrentParameters.ILASTCHANGEPRECIOPROD = newUltDate;

                fTrans.Commit();
                fConn.Close();

                if (productos != null && productos.Count > 0)
                {
                    WFMovilPreciosCambiados mp = new WFMovilPreciosCambiados(productos);
                    mp.ShowDialog();
                    mp.Dispose();
                    GC.SuppressFinalize(mp);
                }
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
                fConn.Close();
            }
            return true;

        }




        public static bool MOVIL_PRE_INVENTARIO_UPDATE(ref string comentario, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVIL_PRE_INVENTARIO_UPDATE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionesBD.ConexionBD.ConexionString(), st);
                        comentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                comentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public static bool ConexionAInternet()
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            try
            {
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        private static double GetUnixEpoch(DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return unixTime.TotalSeconds;
        }

        public static bool ZippearBackupBD()
        {

            string strCurrentVersion;
            string strOriginalDBLocation;
            string strCopyDBLocation;
            string basePath;
            string strBackupLocation;
            try
            {
                strCurrentVersion = DateTime.Now.ToString("yyyyMMddHHmmss");
                strOriginalDBLocation = iPos.CurrentUserID.DBLocation;
                strCopyDBLocation = iPos.CurrentUserID.DBLocation.ToLower().Replace(".fdb", strCurrentVersion + ".fdb"); ;

                basePath = CurrentUserID.CurrentParameters.IRUTARESPALDOSZIP == null || CurrentUserID.CurrentParameters.IRUTARESPALDOSZIP.Trim().Length == 0 ? System.AppDomain.CurrentDomain.BaseDirectory + FolderZippedRespaldos : CurrentUserID.CurrentParameters.IRUTARESPALDOSZIP.Trim();
                strBackupLocation = basePath + "\\IposDb_" + strCurrentVersion + ".zip";

                Console.WriteLine("Antes de copiar" + DateTime.Now.ToString("HH:mm:ss"));


                File.Copy(strOriginalDBLocation, strCopyDBLocation, true);

                Console.WriteLine("despues de copiar" + DateTime.Now.ToString("HH:mm:ss"));

                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);


                if (File.Exists(strBackupLocation))
                    File.Delete(strBackupLocation);

                Console.WriteLine("antes de zippear " + DateTime.Now.ToString("HH:mm:ss"));


                new Thread(() =>
                {
                    try
                    {
                        Thread.CurrentThread.IsBackground = true;
                        /* run your code here */

                        ZipUtil.ZipFile(strCopyDBLocation, strBackupLocation, "");
                        //ZipFile.CreateFromDirectory(basePath + "\\" + strCurrentVersion, strBackupLocation, CompressionLevel.Fastest, false);
                        //ZipFile.CreateFromDirectory(strCopyDBLocation, strBackupLocation, CompressionLevel.Fastest, false);
                        Console.WriteLine("despues de zippear " + DateTime.Now.ToString("HH:mm:ss"));

                        if (File.Exists(strCopyDBLocation))
                            File.Delete(strCopyDBLocation);
                    }
                    catch
                    {

                    }
                }).Start();


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }

    }
}
