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

namespace DataLayer.Importaciones
{
    public class ExportarCuboDBF
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
        

        public const string FileLocalLocation_CuboEnvios = "\\sampdata\\exportaciones\\cubos\\cubos";
        public const string FileLocalLocation_Cubo_Molde = "\\sampdata\\exportaciones\\cubos\\molde";


        public const string CLIE_DBF_FILENAME = "Q_CLIE.dbf";
        public const string VEND_DBF_FILENAME = "Q_VEND.dbf";
        public const string LINEA_DBF_FILENAME = "Q_LINE.dbf";
        public const string MARCA_DBF_FILENAME = "Q_MARC.dbf";
        public const string PROVEEDOR_DBF_FILENAME = "Q_PROV.dbf";
        public const string PRODUCT_DBF_FILENAME = "Q_PROD.dbf";
        public const string SUCURSAL_DBF_FILENAME = "Q_CATS.dbf";
        public const string KITS_DBF_FILENAME = "Q_KITS.dbf";
        public const string TRANS_DBF_FILENAME = "Q_VEDM.dbf";


        public const string FileLocalLocation_CuboZipTemporal = "\\sampdata\\exportaciones\\cubos\\cubos\\CUBO.zip";
        public const string FileLocalLocation_CuboZipFinal = "\\sampdata\\exportaciones\\cubos\\CUBO.ZIP";
        public const string FileLocalLocation_CuboZipLocalPath = "\\sampdata\\exportaciones\\cubos\\";
        public const string FileLocalLocation_CuboZipFtpPath = "/tiendas";
        public const string FileLocalLocation_CuboZipName = "CUBO.zip";




        string m_strDbfCadenaConexion;


        public ExportarCuboDBF()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();

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

        public Boolean CopyEmtpyTables(string tempDBFPath, bool bCatalogos, bool bPersonas, bool bTransacciones)
        {
            string pathMolde = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_Cubo_Molde;
            string path = tempDBFPath;


            if (bPersonas)
            {
                CopyFormatedDBF(ExportarCuboDBF.CLIE_DBF_FILENAME, pathMolde, path, true);
                CopyFormatedDBF(ExportarCuboDBF.VEND_DBF_FILENAME, pathMolde, path, true);
            }

            if (bCatalogos)
            {
                CopyFormatedDBF(ExportarCuboDBF.LINEA_DBF_FILENAME, pathMolde, path, true);
                CopyFormatedDBF(ExportarCuboDBF.MARCA_DBF_FILENAME, pathMolde, path, true);
                CopyFormatedDBF(ExportarCuboDBF.PROVEEDOR_DBF_FILENAME, pathMolde, path, true);
                CopyFormatedDBF(ExportarCuboDBF.PRODUCT_DBF_FILENAME, pathMolde, path, true);
                CopyFormatedDBF(ExportarCuboDBF.SUCURSAL_DBF_FILENAME, pathMolde, path, true);
                CopyFormatedDBF(ExportarCuboDBF.KITS_DBF_FILENAME, pathMolde, path, true);
            }

            if (bTransacciones)
            {
                CopyFormatedDBF(ExportarCuboDBF.TRANS_DBF_FILENAME, pathMolde, path, true);
            }


            return true;
        }






        public Boolean ExportCuboInfo(CPARAMETROBE parametroBE, 
                                            CPERSONABE currentUser, 
                                            DateTime fecha,
                                            bool bCatalogos, 
                                            bool bPersonas, 
                                            bool bTransacciones,
                                            DataTable dtVedme,
                                            ref ArrayList strErrores)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboEnvios;
            CopyEmtpyTables(path, bCatalogos, bPersonas, bTransacciones);

            string strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            ExportarDBF generalExportDBF = new ExportarDBF();

            try
            {

                if (bCatalogos)
                {

                    if (!exportarAFTP_MatrizLINE(ExportarCuboDBF.LINEA_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    if (!exportarAFTP_MatrizMARC(ExportarCuboDBF.MARCA_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    
                    if (!exportarAFTP_MatrizPROV(ExportarCuboDBF.PROVEEDOR_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                    
                    if (!exportarAFTP_MatrizPROD(ExportarCuboDBF.PRODUCT_DBF_FILENAME,  null, null, strOleDbConn))
                    {
                        return false;
                    }
                    
                    if (!exportarAFTP_MatrizCATS(ExportarCuboDBF.SUCURSAL_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }




                    if (parametroBE.IMANEJAKITS != null && parametroBE.IMANEJAKITS.Equals("S"))
                    {
                        if (!exportarAFTP_MatrizKITS(ExportarCuboDBF.KITS_DBF_FILENAME, null, null, strOleDbConn))
                        {
                            return false;
                        }
                    }
                }

                if(bPersonas)
                {

                    if (!this.exportarAFTP_MatrizVEND(ExportarCuboDBF.VEND_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }

                    if (!this.exportarAFTP_MatrizCLIE(ExportarCuboDBF.CLIE_DBF_FILENAME, null, null, strOleDbConn))
                    {
                        return false;
                    }
                }

                if(bTransacciones)
                {
                    if (!this.exportarAFTP_VEDM(ExportarCuboDBF.TRANS_DBF_FILENAME, dtVedme, null, strOleDbConn))
                    {
                        return false;
                    }
                }
                



                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipTemporal))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipTemporal);

                ZipUtil.ZipFiles(path, FileLocalLocation_CuboZipName, "");


                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipFinal))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipFinal);

                File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipTemporal, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipFinal);

                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipTemporal);


                if (!iPos.ImportaDesdeFtp.UploadFile(FileLocalLocation_CuboZipName, System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_CuboZipLocalPath, FileLocalLocation_CuboZipFtpPath, false, true, ref strErrores))
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





        public bool exportarAFTP_MatrizPROD(string strTableExpNameDet,  FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CPRODUCTOBE fbItem = new CPRODUCTOBE();

            CQ_PRODD m_dbfD = new CQ_PRODD();
            CQ_PRODBE m_dbfBE = new CQ_PRODBE();


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
                         PRODUCTO.KITIMPFIJO
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
                         PRODUCTO BASEPRODPROMO ON BASEPRODPROMO.ID = PRODUCTO.BASEPRODPROMOID
          ";

                
                    CmdTxt += " WHERE PRODUCTO.CLAVE NOT LIKE 'EMIDA-%' AND (PRODUCTO.EMIDAPRODUCTOID IS NULL OR PRODUCTO.EMIDAPRODUCTOID = 0) ";
              


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_PRODBE();

                    /*if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICOMPRA = (int)dr["FOLIO"];
                    }*/



                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPRODUCTO = (string)(dr["CLAVE"]);

                    }


                    //if (dr["NOMBRE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    //}


                    if ((bool)m_dbfBE.isnull["IPRODUCTO"] || m_dbfBE.IPRODUCTO.Trim() == "")
                        continue;


                    



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
                        m_dbfBE.IDESC1 = (string)(dr["DESCRIPCION"]);
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


                    if (dr["CLAVEMONEDA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMONEDA = (string)(dr["CLAVEMONEDA"]);
                    }



                    //if (dr["CLAVETASAIVA"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICVETASAIVA = (string)(dr["CLAVETASAIVA"]);
                    //}

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIVA = Decimal.ToDouble((decimal)(dr["TASAIVA"]));
                    }
                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        //m_dbfBE.ICOSTOREPUS = Decimal.ToDouble((decimal)(dr["COSTOREPOSICION"]));
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




                    //if (dr["CLAVEPRODUCTOSUBSTITUTO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ISUSTITUTO = (string)(dr["CLAVEPRODUCTOSUBSTITUTO"]);
                    //}

                    //if (dr["CBARRAS"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICBARRAS = (string)(dr["CBARRAS"]);
                    //}


                    //if (dr["CEMPAQUE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
                    //}


                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        m_dbfBE.IBOTCAJA = Decimal.ToDouble((decimal)(dr["PZACAJA"]));
                    }


                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IU_EMPAQUE = Decimal.ToDouble((decimal)(dr["U_EMPAQUE"]));
                    }


                    //if (dr["UNIDAD"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IUNIDAD = (string)(dr["UNIDAD"]);
                    //}


                    //if (dr["INI_MAYO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IINIMAYO = Decimal.ToDouble((decimal)(dr["INI_MAYO"]));
                    //}


                    //if (dr["MAYOKGS"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IMAYOXKG = (string)(dr["MAYOKGS"]);
                    //}
                    //else
                    //{
                    //    m_dbfBE.IMAYOXKG = "N";
                    //}



                    //if (dr["TIPOABC"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITIPOABC = (string)(dr["TIPOABC"]);
                    //}
                    //else
                    //{
                    //    m_dbfBE.ITIPOABC = "N";
                    //}




                    if (dr["CLAVEPROVEEDOR1"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR = (string)(dr["CLAVEPROVEEDOR1"]);
                    }


                    if (dr["CLAVEPROVEEDOR2"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPROVEEDOR2 = (string)(dr["CLAVEPROVEEDOR2"]);
                    }


                    //if (dr["CLAVEPRODUCTOPADRE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IPRODPADRE = (string)(dr["CLAVEPRODUCTOPADRE"]);
                    //}



                    //if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ILIMITE2 = Decimal.ToDouble((decimal)(dr["LIMITEPRECIO2"]));
                    //}


                    //if (dr["TEXTO1"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITEXTO1 = (string)(dr["TEXTO1"]);
                    //}
                    //if (dr["TEXTO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITEXTO2 = (string)(dr["TEXTO2"]);
                    //}
                    //if (dr["TEXTO3"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITEXTO3 = (string)(dr["TEXTO3"]);
                    //}
                    //if (dr["TEXTO4"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITEXTO4 = (string)(dr["TEXTO4"]);
                    //}
                    //if (dr["TEXTO5"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITEXTO5 = (string)(dr["TEXTO5"]);
                    //}
                    //if (dr["TEXTO6"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ITEXTO6 = (string)(dr["TEXTO6"]);
                    //}



                    //if (dr["NUMERO1"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.INUMERO1 = Decimal.ToDouble((decimal)(dr["NUMERO1"]));
                    //}
                    //if (dr["NUMERO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.INUMERO2 = Decimal.ToDouble((decimal)(dr["NUMERO2"]));
                    //}
                    //if (dr["NUMERO3"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.INUMERO3 = Decimal.ToDouble((decimal)(dr["NUMERO3"]));
                    //}
                    //if (dr["NUMERO4"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.INUMERO4 = Decimal.ToDouble((decimal)(dr["NUMERO4"]));
                    //}



                    //if (dr["FECHA1"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    //}
                    //if (dr["FECHA2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    //}




                    //if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IESPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    //}


                    //if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IESFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    //}


                    //if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IESSUBPROD = (string)(dr["ESSUBPRODUCTO"]);
                    //}


                    //if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IPRECPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    //}



                    //if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICOMIPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    //}


                    //if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IOFEPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    //}


                    //if (dr["COMISION"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICOMISION = Decimal.ToDouble((decimal)(dr["COMISION"]));
                    //}

                    //if (dr["OFERTA"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IOFERTA = Decimal.ToDouble((decimal)(dr["OFERTA"]));
                    //}



                    //if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICAMBIARPRE = (string)(dr["CAMBIARPRECIO"]);
                    //}

                    //if (dr["PLUG"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IPLUG = (string)(dr["PLUG"]);
                    //}

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        m_dbfBE.IIEPS = Decimal.ToDouble((decimal)(dr["TASAIEPS"]));
                    }


                    //if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IMINUTIL = Decimal.ToDouble((decimal)(dr["MINUTILIDAD"]));
                    //}

                    //if (dr["SPRECIO1"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ISPRECIO1 = Decimal.ToDouble((decimal)(dr["SPRECIO1"]));
                    //}
                    //if (dr["SPRECIO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ISPRECIO2 = Decimal.ToDouble((decimal)(dr["SPRECIO2"]));
                    //}
                    //if (dr["SPRECIO3"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ISPRECIO3 = Decimal.ToDouble((decimal)(dr["SPRECIO3"]));
                    //}
                    //if (dr["SPRECIO4"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ISPRECIO4 = Decimal.ToDouble((decimal)(dr["SPRECIO4"]));
                    //}
                    //if (dr["SPRECIO5"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ISPRECIO5 = Decimal.ToDouble((decimal)(dr["SPRECIO5"]));
                    //}


                    //if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IRRECETA = (string)(dr["REQUIERERECETA"]);
                    //}



                    //if (dr["PRECIOMAT"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    //}




                    //if (dr["MENUDEO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IMENUDEO = Decimal.ToInt32((decimal)(dr["MENUDEO"]));
                    //}


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


                    //if (dr["UNIDAD2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    //}


                    //if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICANTXPIEZA = Decimal.ToDouble((decimal)(dr["CANTXPIEZA"]));
                    //}




                    //if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ILOTEIMPO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    //}

                    //if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICOSTOUSD = Decimal.ToDouble((decimal)(dr["COSTOENDOLAR"]));
                    //}



                    if (dr["PLAZOCLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IPLAZO = (string)(dr["PLAZOCLAVE"]);
                    }

                    //if (dr["SAT_CLAVEPRODSERV"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICLAVESAT = dr["SAT_CLAVEPRODSERV"].ToString();
                    //}



                    //if (dr["CLAVEBASEPRODPROMO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IBASEPROM = dr["CLAVEBASEPRODPROMO"].ToString();
                    //}


                    //if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IESPRODPROM = dr["ESPRODPROMO"].ToString();
                    //}


                    //if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IVIGPROM = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    //}

                    //if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IVIGKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    //}

                    //if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IKITCVIG = (string)(dr["KITTIENEVIG"]);
                    //}

                    //if (dr["VALXSUC"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.IVALXSUC = (string)(dr["VALXSUC"]);
                    //}


                    if (dr["KITIMPFIJO"] != System.DBNull.Value)
                    {
                        string strKitImpFijo = (string)dr["KITIMPFIJO"];
                        m_dbfBE.IDESGKIT = strKitImpFijo != null && strKitImpFijo.Equals("S") ? false : true;
                    }

                    if ((!m_dbfD.AgregarQ_PRODD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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
            CQ_CATSBE fbItem = new CQ_CATSBE();

            CQ_CATSD m_dbfD = new CQ_CATSD();
            CQ_CATSBE m_dbfBE = new CQ_CATSBE();

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

                CmdTxt = @"SELECT SUCURSAL.*, GRUPOSUCURSAL.CLAVE CLAVEGRUPO from SUCURSAL left join GRUPOSUCURSAL ON GRUPOSUCURSAL.ID = SUCURSAL.GRUPOSUCURSALID";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_CATSBE();

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

                    


                    if ((!m_dbfD.AgregarQ_CATSD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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



        public bool exportarAFTP_MatrizKITS(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_KITSBE fbItem = new CQ_KITSBE();

            CQ_KITSD m_dbfD = new CQ_KITSD();
            CQ_KITSBE m_dbfBE = new CQ_KITSBE();


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

                CmdTxt = @"SELECT * FROM KITDEFINICION";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_KITSBE();

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


                    if ((!m_dbfD.AgregarQ_KITSD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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




        public bool exportarAFTP_MatrizLINE(string strTableExpNameDet,  FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_LINEBE fbItem = new CQ_LINEBE();

            CQ_LINED m_dbfD = new CQ_LINED();
            CQ_LINEBE m_dbfBE = new CQ_LINEBE();


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
                
                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_LINEBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ILINEA = (string)(dr["CLAVE"]);
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                   
                    if ((!m_dbfD.AgregarQ_LINED(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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



        public bool exportarAFTP_MatrizMARC(string strTableExpNameDet,  FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_MARCBE fbItem = new CQ_MARCBE();

            CQ_MARCD m_dbfD = new CQ_MARCD();
            CQ_MARCBE m_dbfBE = new CQ_MARCBE();


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

                


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_MARCBE();


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IMARCA = (string)(dr["CLAVE"]);
                    }



                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        m_dbfBE.INOMBRE = (string)(dr["NOMBRE"]);
                    }
                    



                    if ((!m_dbfD.AgregarQ_MARCD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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




        public bool exportarAFTP_MatrizPROV(string strTableExpNameDet,  FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_PROVBE fbItem = new CQ_PROVBE();

            CQ_PROVD m_dbfD = new CQ_PROVD();
            CQ_PROVBE m_dbfBE = new CQ_PROVBE();


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

                CmdTxt = @"SELECT * from PERSONA WHERE TIPOPERSONAID = " + DBValues._TIPOPERSONA_PROVEEDOR.ToString("N0");


                

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_PROVBE();

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
                    





                    if ((!m_dbfD.AgregarQ_PROVD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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




        public bool exportarAFTP_MatrizVEND(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_VENDBE fbItem = new CQ_VENDBE();

            CQ_VENDD m_dbfD = new CQ_VENDD();
            CQ_VENDBE m_dbfBE = new CQ_VENDBE();


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

                CSUCURSALBE sucBE = new CSUCURSALBE();
                CSUCURSALD sucD = new CSUCURSALD();
                sucBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

                sucBE = sucD.seleccionarSUCURSAL(sucBE, null);


                parts = new ArrayList();

                CmdTxt = @"SELECT * from PERSONA WHERE TIPOPERSONAID IN ( " + DBValues._TIPOPERSONA_VENDEDOR.ToString("N0") + ","  + DBValues._TIPOPERSONA_USUARIO.ToString("N0") +  " )";




                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_VENDBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.IVENDEDOR = (string)(dr["CLAVE"]);
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
                        m_dbfBE.ITELEFONO = (string)(dr["TELEFONO1"]);
                    }
                    //if (dr["TELEFONO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.I = (string)(dr["TELEFONO2"]);
                    //}

                    //if (dr["CONTACTO1"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICONTACTO = (string)(dr["CONTACTO1"]);
                    //}

                    //if (dr["CONTACTO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    //}

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRFC = (string)(dr["RFC"]);
                    }


                    m_dbfBE.ISUCU = sucBE.INOMBRE.Replace(" ","");



                    if ((!m_dbfD.AgregarQ_VENDD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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






        public bool exportarAFTP_MatrizCLIE(string strTableExpNameDet, FbTransaction st, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_CLIEBE fbItem = new CQ_CLIEBE();

            CQ_CLIED m_dbfD = new CQ_CLIED();
            CQ_CLIEBE m_dbfBE = new CQ_CLIEBE();


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

                CSUCURSALBE sucBE = new CSUCURSALBE();
                CSUCURSALD sucD = new CSUCURSALD();
                sucBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

                sucBE = sucD.seleccionarSUCURSAL(sucBE, null);


                parts = new ArrayList();

                CmdTxt = @"SELECT * from PERSONA WHERE TIPOPERSONAID IN ( " + DBValues._TIPOPERSONA_CLIENTE.ToString("N0") + " )";




                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    m_dbfBE = new CQ_CLIEBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        m_dbfBE.ICLIENTE = (string)(dr["CLAVE"]);
                        m_dbfBE.ICLIENTE = new String(m_dbfBE.ICLIENTE.Where(Char.IsDigit).ToArray());
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
                        m_dbfBE.ITELEFONO = (string)(dr["TELEFONO1"]);
                    }
                    //if (dr["TELEFONO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.I = (string)(dr["TELEFONO2"]);
                    //}

                    //if (dr["CONTACTO1"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICONTACTO = (string)(dr["CONTACTO1"]);
                    //}

                    //if (dr["CONTACTO2"] != System.DBNull.Value)
                    //{
                    //    m_dbfBE.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    //}

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        m_dbfBE.IRFC = (string)(dr["RFC"]);
                    }


                    m_dbfBE.ISUCU = sucBE.INOMBRE.Replace(" ", "");



                    if ((!m_dbfD.AgregarQ_CLIED(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
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





        public bool exportarAFTP_VEDM(string strTableExpNameDet, DataTable dt, OleDbTransaction odt, string strOleDbConn)
        {
            CQ_VEDMBE fbItem = new CQ_VEDMBE();

            CQ_VEDMD m_dbfD = new CQ_VEDMD();
            CQ_VEDMBE m_dbfBE = new CQ_VEDMBE();


            //bool retorno = true;
            this.iComentario = "";

            try
            {

                CSUCURSALBE sucBE = new CSUCURSALBE();
                CSUCURSALD sucD = new CSUCURSALD();
                sucBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

                sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

                
               
                foreach (iPos.Exportaciones.DSCubo.CUBOINFOVEDMERow dr in dt.Rows)
                {
                    m_dbfBE = new CQ_VEDMBE();
                    

                    if (!dr.IsVENTANull())
                    {
                        m_dbfBE.IVENTA = dr.VENTA.ToString();
                    }
                    if (!dr.IsCLIENTENull())
                    {
                        m_dbfBE.ICLIENTE = dr.CLIENTE;
                    }
                    if (!dr.IsCANTIDADNull())
                    {
                        m_dbfBE.ICANTIDAD = System.Convert.ToDouble(dr.CANTIDAD);
                    }
                    if (!dr.IsPRODUCTONull())
                    {
                        m_dbfBE.IPRODUCTO = dr.PRODUCTO;
                    }
                    if (!dr.IsPROVEEDORNull())
                    {
                        m_dbfBE.IPROVEEDOR = dr.PROVEEDOR;
                    }
                    if (!dr.IsLINEANull())
                    {
                        m_dbfBE.ILINEA = dr.LINEA;
                    }
                    if (!dr.IsMARCANull())
                    {
                        m_dbfBE.IMARCA = dr.MARCA;
                    }
                    if (!dr.IsVENDEDORNull())
                    {
                        m_dbfBE.IVENDEDOR = dr.VENDEDOR;
                    }
                    if (!dr.IsTIPONull())
                    {
                        m_dbfBE.ITIPO = dr.TIPO;
                    }
                    if (!dr.IsCLASIFICANull())
                    {
                        m_dbfBE.ICLASIFICA = dr.CLASIFICA;
                    }
                    if (!dr.IsPRECIONull())
                    {
                        m_dbfBE.IPRECIO = System.Convert.ToDouble(dr.PRECIO);
                    }
                    if (!dr.IsPREC_LISTANull())
                    {
                        m_dbfBE.IPREC_LISTA = System.Convert.ToDouble(dr.PREC_LISTA);
                    }
                    if (!dr.IsFECHANull())
                    {
                        m_dbfBE.IFECHA = dr.FECHA;
                    }
                    if (!dr.IsESTATUSNull())
                    {
                        m_dbfBE.IESTATUS = dr.ESTATUS;
                    }
                    if (!dr.IsIMPORTENull())
                    {
                        m_dbfBE.IIMPORTE = System.Convert.ToDouble(dr.IMPORTE);
                    }
                    if (!dr.IsIMPORTNETONull())
                    {
                        m_dbfBE.IIMPORTNETO = System.Convert.ToDouble(dr.IMPORTNETO);
                    }
                    if (!dr.IsIMPORTOPENull())
                    {
                        m_dbfBE.IIMPORTOPE = System.Convert.ToDouble(dr.IMPORTOPE);
                    }
                    if (!dr.IsTOTALNull())
                    {
                        m_dbfBE.ITOTAL = System.Convert.ToDouble(dr.TOTAL);
                    }
                    if (!dr.IsUTILIDADNull())
                    {
                        m_dbfBE.IUTILIDAD = System.Convert.ToDouble(dr.UTILIDAD);
                    }
                    if (!dr.IsCOSTO_PUNull())
                    {
                        m_dbfBE.ICOSTO_PU = System.Convert.ToDouble(dr.COSTO_PU);
                    }
                    //if (!dr.IsTIENDANull())
                    //{
                    //    m_dbfBE.ITIENDA = System.Convert.ToDouble(dr.TIENDA);
                    //}
                    if (!dr.IsCOSTOTALNull())
                    {
                        m_dbfBE.ICOSTOTAL = System.Convert.ToDouble(dr.COSTOTAL);
                    }
                    if (!dr.IsDESCUENTONull())
                    {
                        m_dbfBE.IDESCUENTO = System.Convert.ToDouble(dr.DESCUENTO);
                    }
                    if (!dr.IsCOMISIONNull())
                    {
                        m_dbfBE.ICOMISION = System.Convert.ToDouble(dr.COMISION);
                    }
                    if (!dr.IsIDNull())
                    {
                        m_dbfBE.IID = dr.ID;
                    }
                    if (!dr.IsID_FECHANull())
                    {
                        m_dbfBE.IID_FECHA = dr.ID_FECHA;
                    }
                    if (!dr.IsID_HORANull())
                    {
                        m_dbfBE.IID_HORA = dr.ID_HORA;
                    }
                    if (!dr.IsIVANull())
                    {
                        m_dbfBE.IIVA = System.Convert.ToDouble(dr.IVA);
                    }
                    if (!dr.IsIEPS19Null())
                    {
                        m_dbfBE.IIEPS19 = System.Convert.ToDouble(dr.IEPS19);
                    }
                    if (!dr.IsIEPS20Null())
                    {
                        m_dbfBE.IIEPS20 = System.Convert.ToDouble(dr.IEPS20);
                    }
                    if (!dr.IsIEPS25Null())
                    {
                        m_dbfBE.IIEPS25 = System.Convert.ToDouble(dr.IEPS25);
                    }
                    if (!dr.IsIEPS30Null())
                    {
                        m_dbfBE.IIEPS30 = System.Convert.ToDouble(dr.IEPS30);
                    }
                    if (!dr.IsIEPS60Null())
                    {
                        m_dbfBE.IIEPS60 = System.Convert.ToDouble(dr.IEPS60);
                    }
                    //if (!dr.IsEXPORTADOCNull())
                    //{
                    //    m_dbfBE.IEXPORTADOC = dr.EXPORTADOC;
                    //}
                    if (!dr.IsCGO_EXCNull())
                    {
                        m_dbfBE.ICGO_EXC = System.Convert.ToDouble(dr.CGO_EXC);
                    }
                    if (!dr.IsOLLANull())
                    {
                        m_dbfBE.IOLLA = System.Convert.ToDouble(dr.OLLA);
                    }
                    if (!dr.IsDESCTOPENull())
                    {
                        m_dbfBE.IDESCTOPE = System.Convert.ToDouble(dr.DESCTOPE);
                    }
                    if (!dr.IsPROMOCIONNull())
                    {
                        m_dbfBE.IPROMOCION = dr.PROMOCION;
                    }
                    if (!dr.IsSUCUNull())
                    {
                        m_dbfBE.ISUCU = dr.SUCU;
                    }
                    if (!dr.IsTIPO_VEDENull())
                    {
                        m_dbfBE.ITIPO_VEDE = dr.TIPO_VEDE;
                    }
                    if (!dr.IsIEPS53Null())
                    {
                        m_dbfBE.IIEPS53 = System.Convert.ToDouble(dr.IEPS53);
                    }
                    if (!dr.IsIEPS26Null())
                    {
                        m_dbfBE.IIEPS26 = System.Convert.ToDouble(dr.IEPS26);
                    }
                    if (!dr.IsUTL_VENTNull())
                    {
                        m_dbfBE.IUTL_VENT = System.Convert.ToDouble(dr.UTL_VENT);
                    }
                    if (!dr.IsIEPS8Null())
                    {
                        m_dbfBE.IIEPS8 = System.Convert.ToDouble(dr.IEPS8);
                    }
                    if (!dr.IsCOSTO_REPONull())
                    {
                        m_dbfBE.ICOSTO_REPO = System.Convert.ToDouble(dr.COSTO_REPO);
                    }
                    //if (!dr.IsESKITNull())
                    //{
                    //    m_dbfBE.IESKIT = dr.ESKIT;
                    //}
                    //if (!dr.IsDOCTOIDNull())
                    //{
                    //    m_dbfBE.IDOCTOID = dr.DOCTOID;
                    //}
                    //if (!dr.IsMOVTOIDNull())
                    //{
                    //    m_dbfBE.IMOVTOID = dr.MOVTOID;
                    //}
                    //if (!dr.IsKITIMPFIJONull())
                    //{
                    //    m_dbfBE.IKITIMPFIJO = dr.KITIMPFIJO;
                    //}
                    //if (!dr.IsTIPODOCTOIDNull())
                    //{
                    //    m_dbfBE.ITIPODOCTOID = dr.TIPODOCTOID;
                    //}
                    //if (!dr.IsCONSECUTIVONull())
                    //{
                    //    m_dbfBE.ICONSECUTIVO = dr.CONSECUTIVO;
                    //}




                    m_dbfBE.ISUCU = sucBE.INOMBRE.Replace(" ", "");



                    if ((!m_dbfD.AgregarQ_VEDMD(m_dbfBE, strTableExpNameDet, odt, strOleDbConn)))
                    {
                        this.iComentario += m_dbfD.IComentario + "\n";
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


    }
}
