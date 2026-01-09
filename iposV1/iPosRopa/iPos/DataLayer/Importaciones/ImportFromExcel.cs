using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConexionesBD;
using System.Data.OleDb;
using System.Data;
using iPosBusinessEntity;
using Microsoft.ApplicationBlocks.Data;
using DataLayer;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;
using System.Data.Common;
using DataLayer.Utilerias.bussinesData;

namespace iPosData
{
    public class ImportFromExcel
    {

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


        private string sCadenaConexion;

        public ImportFromExcel()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
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

        public bool ImportarProductosFromExcel(string archivoExcel)
        {
            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
            System.Collections.ArrayList parts = new ArrayList();
            //OleDbParameter auxPar;
            String CmdTxt = @"select * from [productos$] ";
            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            OleDbDataReader dr;
            dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);



            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }

            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            bool bAddPrecioSugerido = false;
            bool bAddPrecioTope = false;
            string claveLinea = "", claveMarca = "", claveMoneda = "", claveSustituto = "", claveProveedor1 = "", claveProveedor2 = "";
            bool bResult;


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

            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                while (dr.Read())
                {

                    claveLinea = ""; claveMarca = ""; claveMoneda = ""; claveSustituto = "";
                    claveProveedor1 = ""; claveProveedor2 = "";
                    retorno = new CPRODUCTOBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = dr["CLAVE"].ToString();
                    }

                    if ((bool)retorno.isnull["ICLAVE"] || retorno.ICLAVE.Trim() == "")
                        break;


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = dr["NOMBRE"].ToString();
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        retorno.IEAN = (dr["EAN"].ToString());
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (dr["DESCRIPCION2"].ToString());
                    }

                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (dr["DESCRIPCION3"].ToString());
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = decimal.Parse(dr["PRECIO1"].ToString());
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = decimal.Parse(dr["PRECIO2"].ToString());
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = decimal.Parse(dr["PRECIO3"].ToString());
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = decimal.Parse(dr["PRECIO4"].ToString());
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = decimal.Parse(dr["PRECIO5"].ToString());
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = decimal.Parse(dr["TASAIVA"].ToString());
                    }


                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = decimal.Parse(dr["COSTOREPOSICION"].ToString());
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = decimal.Parse(dr["COSTOULTIMO"].ToString());
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = decimal.Parse(dr["COSTOPROMEDIO"].ToString());
                    }

                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = (dr["MANEJALOTE"].ToString());
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = (dr["ESKIT"].ToString());
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (dr["IMPRIMIR"].ToString());
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIABLE = (dr["INVENTARIABLE"].ToString());
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (dr["NEGATIVOS"].ToString());
                    }

                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = decimal.Parse(dr["LIMITEPRECIO2"].ToString());
                    }

                    if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAXIMOPUBLICO = decimal.Parse(dr["PRECIOMAXIMOPUBLICO"].ToString());
                    }

                    //if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                    //{
                    //    retorno.IFECHACAMBIOPRECIO = (DateTime)(dr["FECHACAMBIOPRECIO"]);
                    //}

                    if (dr["MANEJASTOCK"] != System.DBNull.Value)
                    {
                        retorno.IMANEJASTOCK = (dr["MANEJASTOCK"].ToString());
                    }

                    if (dr["STOCK"] != System.DBNull.Value)
                    {
                        retorno.ISTOCK = decimal.Parse(dr["STOCK"].ToString());
                    }



                    if (dr["PROVEEDOR1"] != System.DBNull.Value)
                    {
                        claveProveedor1 = (dr["PROVEEDOR1"].ToString());
                    }

                    if (dr["PROVEEDOR2"] != System.DBNull.Value)
                    {
                        claveProveedor2 = (dr["PROVEEDOR2"].ToString());
                    }


                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        claveLinea = (dr["LINEA"].ToString());
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        claveMarca = (dr["MARCA"].ToString());
                    }


                    if (dr["PRODUCTOSUSTITUTO"] != System.DBNull.Value)
                    {
                        claveSustituto = (dr["PRODUCTOSUSTITUTO"].ToString());
                    }


                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = (dr["CAMBIARPRECIO"].ToString());
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


                    //if (dr["MONEDA"] != System.DBNull.Value)
                    //{
                    //    claveMoneda = (string)(dr["MONEDA"]);
                    //}


                    //if (dr["TASAIVAID"] != System.DBNull.Value)
                    //{
                    //    retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
                    //}


                    //if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
                    //{
                    //    retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
                    //}



                    //if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
                    //{
                    //    retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
                    //}


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



                    bResult = productoD.importarPRODUCTOD(retorno, claveLinea, claveMarca, claveMoneda, claveSustituto, claveProveedor1, claveProveedor2, "", "","","", "", "", "", "", "", "", fTrans);
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




        enum DBOperationsImportFromExcel { OperAgregar, OperCambiar };


        public bool ImportarClientesFromExcel(string archivoExcel)
        {
            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
            System.Collections.ArrayList parts = new ArrayList();
            //OleDbParameter auxPar;
            String CmdTxt = @"select * from [clientes$] ";
            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            OleDbDataReader dr;
            dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);



            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE retorno = new CPERSONABE();

            CPERSONABE personaBuffer = new CPERSONABE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


             bool bResult;


            int iOperation = (int)DBOperationsImportFromExcel.OperAgregar;

            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();
                int auxCountError = 0;
                while (dr.Read())
                {
                    retorno = new CPERSONABE();
                    iOperation = (int)DBOperationsImportFromExcel.OperAgregar;

                    if(auxCountError == 1902)
                    {
                        auxCountError--;
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (dr["CLAVE"]).ToString().Trim();
                    }
                    else
                    {
                        break;   
                    }

                    retorno.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
                    personaBuffer = personaD.seleccionarPERSONAxCLAVEyTIPO(retorno, fTrans);
                    if (personaBuffer != null)
                    {

                        retorno = personaBuffer;
                        iOperation = (int)DBOperationsImportFromExcel.OperCambiar;
                    }


                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = ((string)(dr["NOMBRE"])).Trim();
                    }
                    else
                    {
                        retorno.INOMBRE = "*";
                    }
                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = ((string)(dr["NOMBRES"])).Trim();
                    }
                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = ((string)(dr["APELLIDOS"])).Trim();
                    }

                    if (dr["RAZON_SOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZONSOCIAL = ((string)(dr["RAZON_SOCIAL"])).Trim();
                    }


                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = ((string)(dr["DOMICILIO"])).Trim();
                    }


                    if (dr["NUM_EXT"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (dr["NUM_EXT"]).ToString();
                    }

                    if (dr["NUM_INT"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (dr["NUM_INT"]).ToString().Trim();
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = ((string)(dr["COLONIA"])).Trim();
                    }
                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = ((string)(dr["LOCALIDAD"])).Trim();
                    }
                    if (dr["REFERENCIA_DOMICILIARIA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIADOM = ((string)(dr["REFERENCIA_DOMICILIARIA"])).Trim();
                    }
                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = ((string)(dr["CIUDAD"])).Trim();
                    }
                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = ((string)(dr["ESTADO"])).Trim();
                    }
                    if (dr["CODIGO_POSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (dr["CODIGO_POSTAL"]).ToString().Trim();
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (dr["RFC"]).ToString().Trim();
                    }
                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL1 = ((string)(dr["EMAIL1"])).Trim();
                    }
                    if (dr["EMAIL2"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL2 = ((string)(dr["EMAIL2"])).Trim();
                    }
                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = (dr["TELEFONO1"]).ToString().Trim();
                    }
                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = (dr["TELEFONO2"]).ToString().Trim();
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = (dr["CONTACTO1"]).ToString().Trim();
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = (dr["CONTACTO2"]).ToString().Trim();
                    }

                    if (dr["DESGLOSAIEPS"] != System.DBNull.Value)
                    {
                        retorno.IDESGLOSEIEPS = ((string)(dr["DESGLOSAIEPS"])).Trim();
                    }
                    if (dr["CUENTAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAIEPS = (dr["CUENTAIEPS"]).ToString().Trim();
                    }

                    if (dr["SERVICIO_DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.ISERVICIOADOMICILIO = ((string)(dr["SERVICIO_DOMICILIO"])).Trim();
                    }

                    if (dr["SOLICITA_ORDEN_COMPRA"] != System.DBNull.Value)
                    {
                        retorno.ISOLICITAORDENCOMPRA = ((string)(dr["SOLICITA_ORDEN_COMPRA"])).Trim();
                    }

                    if (dr["CUENTA_CONTPAQ"] != System.DBNull.Value)
                    {
                        retorno.ICUENTACONTPAQ = (dr["CUENTA_CONTPAQ"]).ToString().Trim();
                    }

                    if (dr["PAGO_TARJETA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTARJETA = ((string)(dr["PAGO_TARJETA"])).Trim();
                    }

                    if (dr["PAGO_CREDITO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCREDITO = ((string)(dr["PAGO_CREDITO"])).Trim();
                    }

                    if (dr["PAGO_CHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCHEQUE = ((string)(dr["PAGO_CHEQUE"])).Trim();
                    }
                    if (dr["PAGO_TRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTRANSFERENCIA = ((string)(dr["PAGO_TRANSFERENCIA"])).Trim();
                    }
                    if (dr["PAGO_EFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOEFECTIVO = ((string)(dr["PAGO_EFECTIVO"])).Trim();
                    }
                    if (dr["LIMITE"] != System.DBNull.Value)
                    {
                        retorno.ILIMITECREDITO = decimal.Parse((dr["LIMITE"]).ToString().Trim());
                    }
                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = int.Parse((dr["DIAS"]).ToString().Trim());
                    }
                    if (dr["REVISION"] != System.DBNull.Value)
                    {
                        string auxRevision = (dr["REVISION"]).ToString().Trim();
                        auxRevision = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(auxRevision.ToLower());
                        retorno.IREVISION = auxRevision;
                    }
                    if (dr["PAGOS"] != System.DBNull.Value)
                    {
                        string auxPagos = (dr["PAGOS"]).ToString().Trim();
                        auxPagos = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(auxPagos.ToLower());
                        retorno.IPAGOS = auxPagos;
                    }
                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEADO = ((string)(dr["BLOQUEADO"])).Trim();
                    }
                    if (dr["LISTA_PRECIO"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = int.Parse((dr["LISTA_PRECIO"]).ToString().Trim());
                    }
                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {
                        string auxVendedorClave = ((string)(dr["VENDEDOR"])).Trim();
                        CPERSONABE auxVendedor = new CPERSONABE();
                        CPERSONAD daoAuxVendedor = new CPERSONAD();
                        auxVendedor.ICLAVE = auxVendedorClave;
                        auxVendedor.ITIPOPERSONAID = 22;
                        auxVendedor = daoAuxVendedor.seleccionarPERSONAxCLAVEyTIPO(auxVendedor, null);
                        if(auxVendedor == null)
                        {
                            System.Windows.Forms.MessageBox.Show("No se pudieron agregar algunos registros porque falta agregar el siguiente vendedor(Clave):" + auxVendedorClave);
                            this.IComentario = personaD.IComentario;
                            fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }
                        else
                        {

                            retorno.IVENDEDORID = auxVendedor.IID;
                        }
                    }
                    if (dr["FORMA_PAGO"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOSATABONOS = int.Parse((dr["FORMA_PAGO"]).ToString().Trim());
                    }
                    if (dr["REFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOREFERENCIAABONOS = (dr["REFERENCIA"]).ToString().Trim();
                    }
                    if (dr["PRODUCTO_X_PLAZO"] != System.DBNull.Value)
                    {
                        retorno.ISEPARARPRODXPLAZO = ((string)(dr["PRODUCTO_X_PLAZO"])).Trim();
                    }

                    try
                    {
                        if (dr["TIPO_CLIENTE"] != System.DBNull.Value)
                        {
                            retorno.ISUBTIPOCLIENTE = ((string)(dr["TIPO_CLIENTE"])).Trim();
                        }
                    }
                    catch
                    {

                    }

                    /*try
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

                    }*/

                    retorno.IACTIVO = "S";
                    retorno.ISAT_CLAVE_PAIS = "MEX";

                    auxCountError++;

                    if (iOperation == (int)DBOperationsImportFromExcel.OperCambiar)
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



        public bool ImportarSaldosClientesFromExcel(string archivoExcel, long vendedorIdP, ref List<string> mensajesError)
        {
            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
            System.Collections.ArrayList parts = new ArrayList();
            //OleDbParameter auxPar;
            String CmdTxt = @"select * from [saldos$] ";
            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            OleDbDataReader dr;
            dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);



            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }

            CDOCTOD doctoD = new CDOCTOD();
            List<CSALDOCLIENTEBE> saldosClientes = new List<CSALDOCLIENTEBE>();
            CSALDOCLIENTEBE retorno = new CSALDOCLIENTEBE();

            long vendedorId = vendedorIdP;
            long doctoId = -1, errorCodeS = -1;


            CPERSONABE personaBuffer = new CPERSONABE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            bool bResult;
            string strRepetidos = "";

            while (dr.Read())
            {
                retorno = new CSALDOCLIENTEBE();

                if (dr["CLIENTE"] != System.DBNull.Value)
                {
                    retorno.ICLIENTECLAVE = (dr["CLIENTE"]).ToString().Trim();
                }

                if (dr["CLAVE"] != System.DBNull.Value)
                {
                    retorno.IPRODUCTOCLAVE = ((string)(dr["CLAVE"])).Trim();
                }
                if (dr["CANTIDAD"] != System.DBNull.Value)
                {
                    retorno.ICANTIDAD = long.Parse(((dr["CANTIDAD"])).ToString());
                }
                if (dr["IMPORTE"] != System.DBNull.Value)
                {
                    retorno.IIMPORTE = decimal.Parse(((dr["IMPORTE"])).ToString());
                }

                if (dr["REFERENCIA_SISTEMA_ANTERIOR"] != System.DBNull.Value)
                {
                    retorno.IREFERENCIASISTEMAANT = ((dr["REFERENCIA_SISTEMA_ANTERIOR"])).ToString().Trim();
                }


                if (dr["DESCRIPCION"] != System.DBNull.Value)
                {
                    retorno.IDESCRIPCION = ((dr["DESCRIPCION"])).ToString().Trim();
                }


                if (dr["FECHAVENCE"] != System.DBNull.Value)
                {
                    retorno.IFECHAVENCE = DateTime.Parse((dr["FECHAVENCE"]).ToString());
                }

                saldosClientes.Add(retorno);
            }

            bool huboErrorProd = false, huboErroClient = false, huboErrorVenta = false, huboErrorCantidadIncorrecta = false, huboErrorProdNoAptos  = false;
            string prodInexist = "Los siguientes Productos no existen en la bd, darlos de alta:\n";
            string clientInexist = "Los siguientes Clientes no existen en la bd, darlos de alta:\n";
            string ventasExist = "Los siguientes saldos ya estan en el sistema: \n";
            string cantidadesIncorrect = "Las cantidades de los siguientes saldos no pueden ser menores o iguales a cero: \n";
            string prodNoAptos = "Los siguientes productos no son aptos para la importacion, deben ser comodin, tasaiva 0 e inventariables: \n";
            foreach(CSALDOCLIENTEBE saldoC in saldosClientes)
            {
                if (!doctoD.IMPORTAR_SALDOS_CLIENTES(vendedorId, saldoC, ref errorCodeS, ref doctoId, "S", null))
                {

                    if (errorCodeS == 5014)
                    {
                        prodInexist += saldoC.IPRODUCTOCLAVE + "\n";
                        huboErrorProd = true;
                    }
                    else if (errorCodeS == 5015)
                    {
                        clientInexist += saldoC.ICLIENTECLAVE + "\n";
                        huboErroClient = true;
                    }
                    else if (errorCodeS == 5016)
                    {
                        ventasExist += saldoC.IREFERENCIASISTEMAANT + "\n";
                        //huboErrorVenta = true;
                    }
                    else if (errorCodeS == 5017)
                    {
                        cantidadesIncorrect += saldoC.IREFERENCIASISTEMAANT + "\n";
                        huboErrorCantidadIncorrecta = true;
                    }
                    else if(errorCodeS == 5018)
                    {
                        prodNoAptos += saldoC.IPRODUCTOCLAVE + "\n";
                        huboErrorProdNoAptos = true;
                    }
                    else
                    {
                        mensajesError.Add(doctoD.IComentario + "\n");
                    }
                }
            }

            if(huboErrorProd)
            {
                mensajesError.Add(prodInexist);
            }
            if(huboErroClient)
            {
                mensajesError.Add(clientInexist);
            }
            if(huboErrorVenta)
            {
                mensajesError.Add(ventasExist);
            }
            if(huboErrorCantidadIncorrecta)
            {
                mensajesError.Add(cantidadesIncorrect);
            }
            if(huboErrorProdNoAptos)
            {
                mensajesError.Add(prodNoAptos);
            }

            //if(huboErrorProd || huboErroClient || huboErrorVenta || huboErrorCantidadIncorrecta)
            if(mensajesError.Count > 0)
            {
                return false;
            }



            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                foreach (CSALDOCLIENTEBE saldoC in saldosClientes)
                {
                    bResult = doctoD.IMPORTAR_SALDOS_CLIENTES(vendedorId, saldoC, ref errorCodeS, ref doctoId, "N", fTrans);

                    if (bResult == false)
                    {

                        if(errorCodeS == 5016)
                        {
                            strRepetidos += saldoC.IREFERENCIASISTEMAANT + ",";
                        }
                        else
                        {

                            this.IComentario = doctoD.IComentario;
                            mensajesError.Add(doctoD.IComentario);
                            fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }
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

            if(!strRepetidos.Equals(""))
            {
                mensajesError.Add("Advertencia: se ignoraron los siguientes registros pues estaban repetidos en la referencia " + strRepetidos);
            }
            return true;

        }


        public bool ImportarSaldosProveedoresFromExcel(string archivoExcel, long vendedorIdP, ref List<string> mensajesError)
        {
            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
            System.Collections.ArrayList parts = new ArrayList();
            //OleDbParameter auxPar;
            String CmdTxt = @"select * from [saldos$] ";
            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            OleDbDataReader dr;
            dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);



            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return false;
            }

            CDOCTOD doctoD = new CDOCTOD();
            List<CSALDOPROVEEDORBE> saldosProveedores = new List<CSALDOPROVEEDORBE>();
            CSALDOPROVEEDORBE retorno = new CSALDOPROVEEDORBE();

            long vendedorId = vendedorIdP;
            long doctoId = -1, errorCodeS = -1;


            CPERSONABE personaBuffer = new CPERSONABE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            bool bResult;
            string strRepetidos = "";

            while (dr.Read())
            {
                retorno = new CSALDOPROVEEDORBE();

                if (dr["PROVEEDOR"] != System.DBNull.Value)
                {
                    retorno.IPROVEEDORCLAVE = (dr["PROVEEDOR"]).ToString().Trim();
                }

                if (dr["CLAVE"] != System.DBNull.Value)
                {
                    retorno.IPRODUCTOCLAVE = ((string)(dr["CLAVE"])).Trim();
                }
                if (dr["CANTIDAD"] != System.DBNull.Value)
                {
                    retorno.ICANTIDAD = long.Parse(((dr["CANTIDAD"])).ToString());
                }
                if (dr["IMPORTE"] != System.DBNull.Value)
                {
                    retorno.IIMPORTE = decimal.Parse(((dr["IMPORTE"])).ToString());
                }

                if (dr["REFERENCIA_SISTEMA_ANTERIOR"] != System.DBNull.Value)
                {
                    retorno.IREFERENCIASISTEMAANT = ((dr["REFERENCIA_SISTEMA_ANTERIOR"])).ToString().Trim();
                }


                if (dr["DESCRIPCION"] != System.DBNull.Value)
                {
                    retorno.IDESCRIPCION = ((dr["DESCRIPCION"])).ToString().Trim();
                }


                if (dr["FECHAVENCE"] != System.DBNull.Value)
                {
                    retorno.IFECHAVENCE = DateTime.Parse((dr["FECHAVENCE"]).ToString());
                }

                saldosProveedores.Add(retorno);
            }

            bool huboErrorProd = false, huboErroClient = false, huboErrorVenta = false, huboErrorCantidadIncorrecta = false, huboErrorProdNoAptos = false;
            string prodInexist = "Los siguientes Productos no existen en la bd, darlos de alta:\n";
            string clientInexist = "Los siguientes Proveedores no existen en la bd, darlos de alta:\n";
            string ventasExist = "Los siguientes saldos ya estan en el sistema: \n";
            string cantidadesIncorrect = "Las cantidades de los siguientes saldos no pueden ser menores o iguales a cero: \n";
            string prodNoAptos = "Los siguientes productos no son aptos para la importacion, deben ser comodin, tasaiva 0 e inventariables: \n";
            foreach (CSALDOPROVEEDORBE saldoC in saldosProveedores)
            {
                if (!doctoD.IMPORTAR_SALDOS_PROVEEDORES(vendedorId, saldoC, ref errorCodeS, ref doctoId, "S", null))
                {

                    if (errorCodeS == 5014)
                    {
                        prodInexist += saldoC.IPRODUCTOCLAVE + "\n";
                        huboErrorProd = true;
                    }
                    else if (errorCodeS == 5015)
                    {
                        clientInexist += saldoC.IPROVEEDORCLAVE + "\n";
                        huboErroClient = true;
                    }
                    else if (errorCodeS == 5016)
                    {
                        ventasExist += saldoC.IREFERENCIASISTEMAANT + "\n";
                        //huboErrorVenta = true;
                    }
                    else if (errorCodeS == 5017)
                    {
                        cantidadesIncorrect += saldoC.IREFERENCIASISTEMAANT + "\n";
                        huboErrorCantidadIncorrecta = true;
                    }
                    else if (errorCodeS == 5018)
                    {
                        prodNoAptos += saldoC.IPRODUCTOCLAVE + "\n";
                        huboErrorProdNoAptos = true;
                    }
                    else
                    {
                        mensajesError.Add(doctoD.IComentario + "\n");
                    }
                }
            }

            if (huboErrorProd)
            {
                mensajesError.Add(prodInexist);
            }
            if (huboErroClient)
            {
                mensajesError.Add(clientInexist);
            }
            if (huboErrorVenta)
            {
                mensajesError.Add(ventasExist);
            }
            if (huboErrorCantidadIncorrecta)
            {
                mensajesError.Add(cantidadesIncorrect);
            }
            if (huboErrorProdNoAptos)
            {
                mensajesError.Add(prodNoAptos);
            }

            //if(huboErrorProd || huboErroClient || huboErrorVenta || huboErrorCantidadIncorrecta)
            if (mensajesError.Count > 0)
            {
                return false;
            }



            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                foreach (CSALDOPROVEEDORBE saldoC in saldosProveedores)
                {
                    bResult = doctoD.IMPORTAR_SALDOS_PROVEEDORES(vendedorId, saldoC, ref errorCodeS, ref doctoId, "N", fTrans);

                    if (bResult == false)
                    {

                        if (errorCodeS == 5016)
                        {
                            strRepetidos += saldoC.IREFERENCIASISTEMAANT + ",";
                        }
                        else
                        {

                            this.IComentario = doctoD.IComentario;
                            mensajesError.Add(doctoD.IComentario);
                            fTrans.Rollback();
                            fConn.Close();
                            return false;
                        }
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

            if (!strRepetidos.Equals(""))
            {
                mensajesError.Add("Advertencia: se ignoraron los siguientes registros pues estaban repetidos en la referencia " + strRepetidos);
            }
            return true;

        }

    }
}
