using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;
using System.Linq;

namespace iPosData
{
    public class CPRODUCTOD
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

        public bool ActualizarClaveSAT(DataSet registros)
        {
            FbConnection connection = new FbConnection(sCadenaConexion);
            FbTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                foreach(DataRow registro in registros.Tables[0].Rows)
                {
                    ArrayList parts = new ArrayList();
                    FbParameter auxPar;

                    auxPar = new FbParameter("@CLAVESAT", FbDbType.VarChar);
                    if(registro["CLAVESAT"] != null)
                    {
                        auxPar.Value = registro["CLAVESAT"].ToString();
                    }
                    else
                    {
                        auxPar.Value = DBNull.Value;
                    }
                    parts.Add(auxPar);

                    auxPar = new FbParameter("@PRODUCTOCLAVE", FbDbType.VarChar);
                    if (registro["PRODUCTOCLAVE"] != null)
                    {
                        auxPar.Value = registro["PRODUCTOCLAVE"].ToString();
                    }
                    else
                    {
                        auxPar.Value = DBNull.Value;
                    }
                    parts.Add(auxPar);

                    string commandText = @"UPDATE producto
                                           SET PRODUCTO.sat_productoservicioid =
                                                (SELECT FIRST 1 ID FROM sat_productoservicio 
                                                 WHERE SAT_PRODUCTOSERVICIO.sat_claveprodserv = @CLAVESAT)
                                           WHERE PRODUCTO.CLAVE = @PRODUCTOCLAVE";

                    FbParameter[] arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (transaction == null)
                        SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                    else
                        SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, commandText, arParms);
                }

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                
                iComentario = e.Message;
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Dictionary<string, string>> SeleccionarProductosParaEdicionSAT(FbTransaction st)
        {
            List<Dictionary<string, string>> retorno = new List<Dictionary<string, string>>();
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                ArrayList parts = new ArrayList();

                String CmdTxt = @"select linea.clave lineaclave,
                               linea.nombre lineanombre,
                               marca.clave marcaclave,
                               marca.nombre marcanombre,
                               producto.clave productoclave,
                               producto.nombre productonombre,
                               producto.descripcion productodescripcion,
                               producto.descripcion1 productodescripcion1,
                               sat_productoservicio.sat_claveprodserv clavesat
                               from producto
                               left join linea on linea.id = producto.lineaid
                               left join marca on marca.id = producto.marcaid
                               left join sat_productoservicio on sat_productoservicio.id = producto.sat_productoservicioid";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while(dr.Read())
                {
                    Dictionary<string, string> registro = new Dictionary<string, string>();

                    if (dr["LINEACLAVE"] != DBNull.Value)
                    {
                        registro.Add("LINEACLAVE", dr["LINEACLAVE"].ToString());
                    }
                    else
                    {
                        registro.Add("LINEACLAVE", String.Empty);
                    }

                    if (dr["LINEANOMBRE"] != DBNull.Value)
                    {
                        registro.Add("LINEANOMBRE", dr["LINEANOMBRE"].ToString());
                    }
                    else
                    {
                        registro.Add("LINEANOMBRE", String.Empty);
                    }

                    if (dr["MARCACLAVE"] != DBNull.Value)
                    {
                        registro.Add("MARCACLAVE", dr["MARCACLAVE"].ToString());
                    }
                    else
                    {
                        registro.Add("MARCACLAVE", String.Empty);
                    }

                    if (dr["MARCANOMBRE"] != DBNull.Value)
                    {
                        registro.Add("MARCANOMBRE", dr["MARCANOMBRE"].ToString());
                    }
                    else
                    {
                        registro.Add("MARCANOMBRE", String.Empty);
                    }

                    if (dr["PRODUCTOCLAVE"] != DBNull.Value)
                    {
                        registro.Add("PRODUCTOCLAVE", dr["PRODUCTOCLAVE"].ToString());
                    }
                    else
                    {
                        registro.Add("PRODUCTOCLAVE", String.Empty);
                    }

                    if (dr["PRODUCTONOMBRE"] != DBNull.Value)
                    {
                        registro.Add("PRODUCTONOMBRE", dr["PRODUCTONOMBRE"].ToString());
                    }
                    else
                    {
                        registro.Add("PRODUCTONOMBRE", String.Empty);
                    }

                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                    {
                        registro.Add("PRODUCTODESCRIPCION", dr["PRODUCTODESCRIPCION"].ToString());
                    }
                    else
                    {
                        registro.Add("PRODUCTODESCRIPCION", String.Empty);
                    }

                    if (dr["PRODUCTODESCRIPCION1"] != DBNull.Value)
                    {
                        registro.Add("PRODUCTODESCRIPCION1", dr["PRODUCTODESCRIPCION1"].ToString());
                    }
                    else
                    {
                        registro.Add("PRODUCTODESCRIPCION1", String.Empty);
                    }

                    if (dr["CLAVESAT"] != DBNull.Value)
                    {
                        registro.Add("CLAVESAT", dr["CLAVESAT"].ToString());
                    }
                    else
                    {
                        registro.Add("CLAVESAT", String.Empty);
                    }

                    retorno.Add(registro);
                }

                SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                SqlHelper.CloseReader(dr, pcn);
                iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public CPRODUCTOBE AgregarPRODUCTOD(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRODUCTO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IEAN"])
                {
                    auxPar.Value = oCPRODUCTO.IEAN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEAID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["ILINEAID"])
                {
                    auxPar.Value = oCPRODUCTO.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARCAID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IMARCAID"])
                {
                    auxPar.Value = oCPRODUCTO.IMARCAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["IMONEDAID"])
                {
                    auxPar.Value = oCPRODUCTO.IMONEDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOSUSTITUTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["IPRODUCTOSUSTITUTOID"])
                {
                    auxPar.Value = oCPRODUCTO.IPRODUCTOSUSTITUTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTE"] && oCPRODUCTO.IMANEJALOTE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESKIT"] && oCPRODUCTO.IESKIT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESKIT;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIR"] && oCPRODUCTO.IIMPRIMIR.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IINVENTARIABLE"] && oCPRODUCTO.IINVENTARIABLE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["INEGATIVOS"] && oCPRODUCTO.INEGATIVOS.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHACAMBIOPRECIO", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHACAMBIOPRECIO"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHACAMBIOPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJASTOCK", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJASTOCK"])
                {
                    auxPar.Value = oCPRODUCTO.IMANEJASTOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCK", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISTOCK"])
                {
                    auxPar.Value = oCPRODUCTO.ISTOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICAMBIARPRECIO"])
                {
                    auxPar.Value = oCPRODUCTO.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARCOMISIONPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMARCOMISIONPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOPADRE", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["IPRODUCTOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.IPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODUCTO.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD;
                }
                else
                {
                    auxPar.Value = "PZA";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODUCTO.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IPLUG"])
                {
                    auxPar.Value = oCPRODUCTO.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCPRODUCTO.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCPRODUCTO.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION_COMODIN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION_COMODIN"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION_COMODIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAPREDIAL", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICUENTAPREDIAL"])
                {
                    auxPar.Value = oCPRODUCTO.ICUENTAPREDIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMAGEN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IIMAGEN"])
                {
                    auxPar.Value = oCPRODUCTO.IIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TASAIMPUESTO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIMPUESTO"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IREQUIERERECETA"] && oCPRODUCTO.IREQUIERERECETA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PRECIOSUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOSUGERIDO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOSUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOTOPE"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMAX", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISTOCKMAX"])
                {
                    auxPar.Value = oCPRODUCTO.ISTOCKMAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SURTIRPORCAJA", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ISURTIRPORCAJA"] && oCPRODUCTO.ISURTIRPORCAJA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.ISURTIRPORCAJA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAT", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAT"] && oCPRODUCTO.IPRECIOMAT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITIPOABC"] && oCPRODUCTO.ITIPOABC.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.ITIPOABC;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIO6", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENUDEO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMENUDEO"])
                {
                    auxPar.Value = oCPRODUCTO.IMENUDEO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTENIDOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ICONTENIDOID"])
                {
                    auxPar.Value = oCPRODUCTO.ICONTENIDOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTENIDOVALOR", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICONTENIDOVALOR"])
                {
                    auxPar.Value = oCPRODUCTO.ICONTENIDOVALOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ICLASIFICAID"])
                {
                    auxPar.Value = oCPRODUCTO.ICLASIFICAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@UNIDAD2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = "CAJA";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTXPIEZA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICANTXPIEZA"])
                {
                    auxPar.Value = oCPRODUCTO.ICANTXPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTEIMPORTADO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTEIMPORTADO"] && oCPRODUCTO.IMANEJALOTEIMPORTADO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOENDOLAR", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOENDOLAR"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOENDOLAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PLAZOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["IPLAZOID"])
                {
                    auxPar.Value = oCPRODUCTO.IPLAZOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODPROMO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IESPRODPROMO"] && oCPRODUCTO.IESPRODPROMO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESPRODPROMO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BASEPRODPROMOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["IBASEPRODPROMOID"])
                {
                    auxPar.Value = oCPRODUCTO.IBASEPRODPROMOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPRODPROMO", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IVIGENCIAPRODPROMO"])
                {
                    auxPar.Value = oCPRODUCTO.IVIGENCIAPRODPROMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPRODKIT", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IVIGENCIAPRODKIT"])
                {
                    auxPar.Value = oCPRODUCTO.IVIGENCIAPRODKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@KITTIENEVIG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IKITTIENEVIG"] && oCPRODUCTO.IKITTIENEVIG.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IKITTIENEVIG;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VALXSUC", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IVALXSUC"] && oCPRODUCTO.IVALXSUC.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IVALXSUC;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DESCTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IDESCTOPE"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARGEN", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMARGEN"])
                {
                    auxPar.Value = oCPRODUCTO.IMARGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCPES", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IDESCPES"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCPES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@KITIMPFIJO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IKITIMPFIJO"] && oCPRODUCTO.IKITIMPFIJO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IKITIMPFIJO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMPRIMIRCOMANDA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIRCOMANDA"] && oCPRODUCTO.IIMPRIMIRCOMANDA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIRCOMANDA;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECMEDIOMAYID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ILISTAPRECMEDIOMAYID"])
                {
                    auxPar.Value = oCPRODUCTO.ILISTAPRECMEDIOMAYID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECMAYOREOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ILISTAPRECMAYOREOID"])
                {
                    auxPar.Value = oCPRODUCTO.ILISTAPRECMAYOREOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTMEDIOMAY", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICANTMEDIOMAY"])
                {
                    auxPar.Value = oCPRODUCTO.ICANTMEDIOMAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICANTMAYOREO"])
                {
                    auxPar.Value = oCPRODUCTO.ICANTMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_TIPOEMBALAJEID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_TIPOEMBALAJEID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_TIPOEMBALAJEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVEUNIDADPESOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_CLAVEUNIDADPESOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_CLAVEUNIDADPESOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PESO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPESO"])
                {
                    auxPar.Value = oCPRODUCTO.IPESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPELIGROSO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPELIGROSO"])
                {
                    auxPar.Value = oCPRODUCTO.IESPELIGROSO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_MATPELIGROSOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_MATPELIGROSOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_MATPELIGROSOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESOFERTA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IESOFERTA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PRODUCTO_INSERT";

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
                        return null;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    oCPRODUCTO.IID = (long)arParms[arParms.Length - 2].Value;
                }



                return oCPRODUCTO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPRODUCTOD(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRODUCTO
  where

  ID=@ID
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool CambiarPRODUCTOD(CPRODUCTOBE oCPRODUCTONuevo, CPRODUCTOBE oCPRODUCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                //auxPar = new FbParameter("@ID", FbDbType.BigInt);
                //if (!(bool)oCPRODUCTONuevo.isnull["IID"])
                //{
                //    auxPar.Value = oCPRODUCTONuevo.IID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                //auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                //if (!(bool)oCPRODUCTONuevo.isnull["ICREADOPOR_USERID"])
                //{
                //    auxPar.Value = oCPRODUCTONuevo.ICREADOPOR_USERID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                /*
                auxPar = new FbParameter("@MODIFICADO", FbDbType.TimeStamp);
                if (!(bool)oCPRODUCTONuevo.isnull["IMODIFICADO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMODIFICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IEAN"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IEAN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTONuevo.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTONuevo.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LINEAID", FbDbType.Integer);
                if (!(bool)oCPRODUCTONuevo.isnull["ILINEAID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MARCAID", FbDbType.Integer);
                if (!(bool)oCPRODUCTONuevo.isnull["IMARCAID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMARCAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IMONEDAID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMONEDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOSUSTITUTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRODUCTOSUSTITUTOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRODUCTOSUSTITUTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IMANEJALOTE"] && oCPRODUCTONuevo.IMANEJALOTE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IESKIT"] && oCPRODUCTONuevo.IESKIT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IESKIT;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IIMPRIMIR"] && oCPRODUCTONuevo.IIMPRIMIR.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IINVENTARIABLE"] && oCPRODUCTONuevo.IINVENTARIABLE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["INEGATIVOS"] && oCPRODUCTONuevo.INEGATIVOS.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHACAMBIOPRECIO", FbDbType.Date);
                if (!(bool)oCPRODUCTONuevo.isnull["IFECHACAMBIOPRECIO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IFECHACAMBIOPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@MANEJASTOCK", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IMANEJASTOCK"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMANEJASTOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@STOCK", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCK"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["ICAMBIARPRECIO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["ITOMARCOMISIONPADRE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITOMARCOMISIONPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPRODUCTONuevo.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPRODUCTONuevo.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCPRODUCTONuevo.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCPRODUCTONuevo.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IUNIDAD;
                }
                else
                {
                    auxPar.Value = "PZA";
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IPLUG"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION_COMODIN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCRIPCION_COMODIN"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCRIPCION_COMODIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAPREDIAL", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ICUENTAPREDIAL"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICUENTAPREDIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMAGEN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IIMAGEN"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TASAIMPUESTO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ITASAIMPUESTO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ITASAIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IREQUIERERECETA"] && oCPRODUCTONuevo.IREQUIERERECETA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOSUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIOSUGERIDO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIOSUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIOTOPE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIOTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMAX", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCKMAX"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCKMAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SURTIRPORCAJA", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ISURTIRPORCAJA"] && oCPRODUCTONuevo.ISURTIRPORCAJA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.ISURTIRPORCAJA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABC", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["ITIPOABC"] && oCPRODUCTONuevo.ITIPOABC.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.ITIPOABC;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOMAT", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIOMAT"] && oCPRODUCTONuevo.IPRECIOMAT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO6", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MENUDEO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IMENUDEO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMENUDEO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTENIDOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ICONTENIDOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICONTENIDOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTENIDOVALOR", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICONTENIDOVALOR"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICONTENIDOVALOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ICLASIFICAID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICLASIFICAID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@UNIDAD2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = "CAJA";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTXPIEZA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICANTXPIEZA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICANTXPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTEIMPORTADO", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IMANEJALOTEIMPORTADO"] && oCPRODUCTONuevo.IMANEJALOTEIMPORTADO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IMANEJALOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOENDOLAR", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICOSTOENDOLAR"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICOSTOENDOLAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IPLAZOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPLAZOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPRODPROMO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IESPRODPROMO"] && oCPRODUCTONuevo.IESPRODPROMO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IESPRODPROMO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BASEPRODPROMOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IBASEPRODPROMOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IBASEPRODPROMOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPRODPROMO", FbDbType.Date);
                if (!(bool)oCPRODUCTONuevo.isnull["IVIGENCIAPRODPROMO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IVIGENCIAPRODPROMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPRODKIT", FbDbType.Date);
                if (!(bool)oCPRODUCTONuevo.isnull["IVIGENCIAPRODKIT"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IVIGENCIAPRODKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@KITTIENEVIG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IKITTIENEVIG"] && oCPRODUCTONuevo.IKITTIENEVIG.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IKITTIENEVIG;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VALXSUC", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IVALXSUC"] && oCPRODUCTONuevo.IVALXSUC.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IVALXSUC;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DESCTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCTOPE"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARGEN", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IMARGEN"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMARGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCPES", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IDESCPES"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IDESCPES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@KITIMPFIJO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTONuevo.isnull["IKITIMPFIJO"] && oCPRODUCTONuevo.IKITIMPFIJO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IKITIMPFIJO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPORCUTILPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPORCUTILPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCUTILPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPORCUTILPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPORCUTILPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCUTILPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPORCUTILPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPORCUTILPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCUTILPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPORCUTILPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPORCUTILPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCUTILPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPORCUTILPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPORCUTILPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIRCOMANDA", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IIMPRIMIRCOMANDA"] && oCPRODUCTONuevo.IIMPRIMIRCOMANDA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTONuevo.IIMPRIMIRCOMANDA;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);






                auxPar = new FbParameter("@LISTAPRECMEDIOMAYID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ILISTAPRECMEDIOMAYID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ILISTAPRECMEDIOMAYID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECMAYOREOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ILISTAPRECMAYOREOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ILISTAPRECMAYOREOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTMEDIOMAY", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICANTMEDIOMAY"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICANTMEDIOMAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ICANTMAYOREO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ICANTMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_TIPOEMBALAJEID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ISAT_TIPOEMBALAJEID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISAT_TIPOEMBALAJEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVEUNIDADPESOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ISAT_CLAVEUNIDADPESOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISAT_CLAVEUNIDADPESOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PESO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IPESO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPELIGROSO", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IESPELIGROSO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IESPELIGROSO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_MATPELIGROSOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["ISAT_MATPELIGROSOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISAT_MATPELIGROSOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESOFERTA", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IESOFERTA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IESOFERTA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"PRODUCTO_UPDATE";

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

        public CPRODUCTOBE seleccionarPRODUCTO(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            CPRODUCTOBE retorno = new CPRODUCTOBE();

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid  where
 p.ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTO.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = dr.GetDateTime(2);//(object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = dr.GetDateTime(4);//(object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        retorno.IEAN = (string)(dr["EAN"]);
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }

                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["TASAIVAID"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = (decimal)(dr["TASAIVA"]);
                    }

                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
                    }

                    if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
                    }

                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = (string)(dr["MANEJALOTE"]);
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = (string)(dr["ESKIT"]);
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIABLE = (string)(dr["INVENTARIABLE"]);
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
                    }

                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITEPRECIO2"]);
                    }

                    if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAXIMOPUBLICO = (decimal)(dr["PRECIOMAXIMOPUBLICO"]);
                    }

                    if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHACAMBIOPRECIO = (DateTime)(dr["FECHACAMBIOPRECIO"]);
                    }

                    if (dr["MANEJASTOCK"] != System.DBNull.Value)
                    {
                        retorno.IMANEJASTOCK = (string)(dr["MANEJASTOCK"]);
                    }

                    if (dr["STOCK"] != System.DBNull.Value)
                    {
                        retorno.ISTOCK = (decimal)(dr["STOCK"]);
                    }

                    if (dr["PROVEEDOR1ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR1ID = int.Parse(dr["PROVEEDOR1ID"].ToString());
                    }

                    if (dr["PROVEEDOR2ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR2ID = int.Parse(dr["PROVEEDOR2ID"].ToString());
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = int.Parse(dr["LINEAID"].ToString());
                    }

                    if (dr["MARCAID"] != System.DBNull.Value)
                    {
                        retorno.IMARCAID = int.Parse(dr["MARCAID"].ToString());
                    }


                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = dr["CAMBIARPRECIO"].ToString();
                    }



                    if (dr["SUBSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUBSTITUTO = (string)(dr["SUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = (string)(dr["CBARRAS"]);
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
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
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        retorno.IINI_MAYO = (decimal)(dr["INI_MAYO"]);
                    }

                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        retorno.IMAYOKGS = (string)(dr["MAYOKGS"]);
                    }

                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = (string)(dr["TIPOABC"]);
                    }


                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                    }

                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
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
                        retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }



                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }

                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IESSUBPRODUCTO = (string)(dr["ESSUBPRODUCTO"]);
                    }

                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }


                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARCOMISIONPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }


                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMAROFERTAPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }



                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARPRECIOPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }

                    if (dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEXISTENCIA = (decimal)(dr["EXISTENCIA"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        retorno.IPLUG = (string)(dr["PLUG"]);
                    }

                    if (dr["ENPROCESODESALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESODESALIDA = (decimal)(dr["ENPROCESODESALIDA"]);
                    }


                    if (dr["DESCRIPCION_COMODIN"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION_COMODIN = (string)(dr["DESCRIPCION_COMODIN"]);
                    }


                    if (dr["CUENTAPREDIAL"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPREDIAL = (string)(dr["CUENTAPREDIAL"]);
                    }

                    if (dr["IMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IIMAGEN = (string)(dr["IMAGEN"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }

                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO1 = (decimal)(dr["SPRECIO1"]);
                    }

                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO2 = (decimal)(dr["SPRECIO2"]);
                    }

                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO3 = (decimal)(dr["SPRECIO3"]);
                    }

                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO4 = (decimal)(dr["SPRECIO4"]);
                    }

                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO5 = (decimal)(dr["SPRECIO5"]);
                    }


                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        retorno.IREQUIERERECETA = (string)(dr["REQUIERERECETA"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }


                    if (dr["PROMOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IPROMOMOVIL = (string)(dr["PROMOMOVIL"]);
                    }

                    if (dr["HISTORIALMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IHISTORIALMOVIL = (string)(dr["HISTORIALMOVIL"]);
                    }


                    if (dr["MARGENMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IMARGENMOVIL = (decimal)(dr["MARGENMOVIL"]);
                    }
                    if (dr["MPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.IMPRECIO4MOVIL = (decimal)(dr["MPRECIO4MOVIL"]);
                    }
                    if (dr["CPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.ICPRECIO4MOVIL = (decimal)(dr["CPRECIO4MOVIL"]);
                    }
                    if (dr["TPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.ITPRECIO4MOVIL = (decimal)(dr["TPRECIO4MOVIL"]);
                    }
                    if (dr["APRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.IAPRECIO4MOVIL = (decimal)(dr["APRECIO4MOVIL"]);
                    }

                    if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOSUGERIDO = (decimal)(dr["PRECIOSUGERIDO"]);
                    }


                    if (dr["ENPROCESOPARTESSALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESOPARTESSALIDA = (decimal)(dr["ENPROCESOPARTESSALIDA"]);
                    }

                    if (dr["PRECIOTOPE"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOTOPE = (decimal)(dr["PRECIOTOPE"]);
                    }
                    if (dr["STOCKMAX"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
                    }

                    if (dr["SURTIRPORCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISURTIRPORCAJA = (string)(dr["SURTIRPORCAJA"]);
                    }

                    if (dr["PRECIOMAT"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    }

                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["ULTIMACOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMACOMPRA = (DateTime)(dr["ULTIMACOMPRA"]);
                    }

                    if (dr["EMIDAPRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAPRODUCTOID = (long)(dr["EMIDAPRODUCTOID"]);
                    }

                    if (dr["EMIDAID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAID = (string)(dr["EMIDAID"]);
                    }



                    if (dr["MENUDEO"] != System.DBNull.Value)
                    {
                        retorno.IMENUDEO = (decimal)(dr["MENUDEO"]);
                    }

                    if (dr["CONTENIDOID"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOID = (long)(dr["CONTENIDOID"]);
                    }

                    if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOVALOR = (decimal)(dr["CONTENIDOVALOR"]);
                    }

                    if (dr["CLASIFICAID"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICAID = (long)(dr["CLASIFICAID"]);
                    }

                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }


                    if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ICANTXPIEZA = (decimal)(dr["CANTXPIEZA"]);
                    }


                    if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTEIMPORTADO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    }


                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
                    }


                    if (dr["LOTEIMPORTADOAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADOAPLICADO = (string)(dr["LOTEIMPORTADOAPLICADO"]);
                    }

                    if (dr["PLAZOID"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOID = (long)(dr["PLAZOID"]);
                    }

                    if(dr["SAT_PRODUCTOSERVICIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PRODUCTOSERVICIOID = (long)(dr["SAT_PRODUCTOSERVICIOID"]);
                    }


                    if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IESPRODPROMO = (string)(dr["ESPRODPROMO"]);
                    }

                    if (dr["BASEPRODPROMOID"] != System.DBNull.Value)
                    {
                        retorno.IBASEPRODPROMOID = (long)(dr["BASEPRODPROMOID"]);
                    }

                    if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODPROMO = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    }

                    if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    }

                    if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.IKITTIENEVIG = (string)(dr["KITTIENEVIG"]);
                    }
                    

                    if (dr["TASAIVAEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAEXT = (decimal)(dr["TASAIVAEXT"]);
                    }
                    if (dr["TASAIEPSEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPSEXT = (decimal)(dr["TASAIEPSEXT"]);
                    }
                    if (dr["TASAIMPEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPEXT = (decimal)(dr["TASAIMPEXT"]);
                    }


                    if (dr["VALXSUC"] != System.DBNull.Value)
                    {
                        retorno.IVALXSUC = (string)(dr["VALXSUC"]);
                    }



                    if (dr["STOCKMINCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINCAJA = (decimal)(dr["STOCKMINCAJA"]);
                    }

                    if (dr["STOCKMAXCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXCAJA = (decimal)(dr["STOCKMAXCAJA"]);
                    }


                    if (dr["STOCKMINPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINPIEZA = (decimal)(dr["STOCKMINPIEZA"]);
                    }

                    if (dr["STOCKMAXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXPIEZA = (decimal)(dr["STOCKMAXPIEZA"]);
                    }



                    if (dr["DESCTOPE"] != System.DBNull.Value)
                    {
                        retorno.IDESCTOPE = (decimal)(dr["DESCTOPE"]);
                    }
                    if (dr["MARGEN"] != System.DBNull.Value)
                    {
                        retorno.IMARGEN = (decimal)(dr["MARGEN"]);
                    }

                    if (dr["DESCPES"] != System.DBNull.Value)
                    {
                        retorno.IDESCPES = (decimal)(dr["DESCPES"]);
                    }

                    if (dr["KITIMPFIJO"] != System.DBNull.Value)
                    {
                        retorno.IKITIMPFIJO = (string)(dr["KITIMPFIJO"]);
                    }


                    if (dr["PORCUTILPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO1 = (decimal)(dr["PORCUTILPRECIO1"]);
                    }

                    if (dr["PORCUTILPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO2 = (decimal)(dr["PORCUTILPRECIO2"]);
                    }

                    if (dr["PORCUTILPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO3 = (decimal)(dr["PORCUTILPRECIO3"]);
                    }

                    if (dr["PORCUTILPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO4 = (decimal)(dr["PORCUTILPRECIO4"]);
                    }

                    if (dr["PORCUTILPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO5 = (decimal)(dr["PORCUTILPRECIO5"]);
                    }

                    if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRCOMANDA = (string)(dr["IMPRIMIRCOMANDA"]);
                    }

                    if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMEDIOMAYID = (long)(dr["LISTAPRECMEDIOMAYID"]);
                    }

                    if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMAYOREOID = (long)(dr["LISTAPRECMAYOREOID"]);
                    }

                    if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
                    {
                        retorno.ICANTMEDIOMAY = (decimal)(dr["CANTMEDIOMAY"]);
                    }

                    if (dr["CANTMAYOREO"] != System.DBNull.Value)
                    {
                        retorno.ICANTMAYOREO = (decimal)(dr["CANTMAYOREO"]);
                    }

                    if (dr["SAT_TIPOEMBALAJEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOEMBALAJEID = (long)(dr["SAT_TIPOEMBALAJEID"]);
                    }

                    if (dr["SAT_CLAVEUNIDADPESOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEUNIDADPESOID = (long)(dr["SAT_CLAVEUNIDADPESOID"]);
                    }

                    if (dr["PESO"] != System.DBNull.Value)
                    {
                        retorno.IPESO = (decimal)(dr["PESO"]);
                    }

                    if (dr["ESPELIGROSO"] != System.DBNull.Value)
                    {
                        retorno.IESPELIGROSO = (string)(dr["ESPELIGROSO"]);
                    }


                    if (dr["SAT_MATPELIGROSOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MATPELIGROSOID = (long)(dr["SAT_MATPELIGROSOID"]);
                    }

                    if (dr["ESOFERTA"] != System.DBNull.Value)
                    {
                        retorno.IESOFERTA = (string)(dr["ESOFERTA"]);
                    }
                }
                else
                {
                    retorno = null;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);



                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public CPRODUCTOBE ParseDataFromDb(ref FbDataReader dr)
        {
            CPRODUCTOBE retorno = new CPRODUCTOBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = dr.GetDateTime(2);//(object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = dr.GetDateTime(4);//(object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        retorno.IEAN = (string)(dr["EAN"]);
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }

                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["TASAIVAID"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = (decimal)(dr["TASAIVA"]);
                    }

                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
                    }

                    if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
                    }

                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = (string)(dr["MANEJALOTE"]);
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = (string)(dr["ESKIT"]);
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIABLE = (string)(dr["INVENTARIABLE"]);
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
                    }

                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITEPRECIO2"]);
                    }

                    if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAXIMOPUBLICO = (decimal)(dr["PRECIOMAXIMOPUBLICO"]);
                    }

                    if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHACAMBIOPRECIO = (DateTime)(dr["FECHACAMBIOPRECIO"]);
                    }

                    if (dr["MANEJASTOCK"] != System.DBNull.Value)
                    {
                        retorno.IMANEJASTOCK = (string)(dr["MANEJASTOCK"]);
                    }

                    if (dr["STOCK"] != System.DBNull.Value)
                    {
                        retorno.ISTOCK = (decimal)(dr["STOCK"]);
                    }

                    if (dr["PROVEEDOR1ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR1ID = int.Parse(dr["PROVEEDOR1ID"].ToString());
                    }

                    if (dr["PROVEEDOR2ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR2ID = int.Parse(dr["PROVEEDOR2ID"].ToString());
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = int.Parse(dr["LINEAID"].ToString());
                    }

                    if (dr["MARCAID"] != System.DBNull.Value)
                    {
                        retorno.IMARCAID = int.Parse(dr["MARCAID"].ToString());
                    }


                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = dr["CAMBIARPRECIO"].ToString();
                    }



                    if (dr["SUBSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUBSTITUTO = (string)(dr["SUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = (string)(dr["CBARRAS"]);
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
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
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        retorno.IINI_MAYO = (decimal)(dr["INI_MAYO"]);
                    }

                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        retorno.IMAYOKGS = (string)(dr["MAYOKGS"]);
                    }

                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = (string)(dr["TIPOABC"]);
                    }


                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                    }

                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
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
                        retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }



                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }

                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IESSUBPRODUCTO = (string)(dr["ESSUBPRODUCTO"]);
                    }

                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }


                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARCOMISIONPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }


                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMAROFERTAPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }



                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARPRECIOPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }

                    if (dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEXISTENCIA = (decimal)(dr["EXISTENCIA"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        retorno.IPLUG = (string)(dr["PLUG"]);
                    }

                    if (dr["ENPROCESODESALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESODESALIDA = (decimal)(dr["ENPROCESODESALIDA"]);
                    }


                    if (dr["DESCRIPCION_COMODIN"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION_COMODIN = (string)(dr["DESCRIPCION_COMODIN"]);
                    }


                    if (dr["CUENTAPREDIAL"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPREDIAL = (string)(dr["CUENTAPREDIAL"]);
                    }

                    if (dr["IMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IIMAGEN = (string)(dr["IMAGEN"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }

                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO1 = (decimal)(dr["SPRECIO1"]);
                    }

                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO2 = (decimal)(dr["SPRECIO2"]);
                    }

                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO3 = (decimal)(dr["SPRECIO3"]);
                    }

                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO4 = (decimal)(dr["SPRECIO4"]);
                    }

                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO5 = (decimal)(dr["SPRECIO5"]);
                    }


                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        retorno.IREQUIERERECETA = (string)(dr["REQUIERERECETA"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }


                    if (dr["PROMOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IPROMOMOVIL = (string)(dr["PROMOMOVIL"]);
                    }

                    if (dr["HISTORIALMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IHISTORIALMOVIL = (string)(dr["HISTORIALMOVIL"]);
                    }


                    if (dr["MARGENMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IMARGENMOVIL = (decimal)(dr["MARGENMOVIL"]);
                    }
                    if (dr["MPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.IMPRECIO4MOVIL = (decimal)(dr["MPRECIO4MOVIL"]);
                    }
                    if (dr["CPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.ICPRECIO4MOVIL = (decimal)(dr["CPRECIO4MOVIL"]);
                    }
                    if (dr["TPRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.ITPRECIO4MOVIL = (decimal)(dr["TPRECIO4MOVIL"]);
                    }
                    if (dr["APRECIO4MOVIL"] != System.DBNull.Value)
                    {
                        retorno.IAPRECIO4MOVIL = (decimal)(dr["APRECIO4MOVIL"]);
                    }

                    if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOSUGERIDO = (decimal)(dr["PRECIOSUGERIDO"]);
                    }


                    if (dr["ENPROCESOPARTESSALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESOPARTESSALIDA = (decimal)(dr["ENPROCESOPARTESSALIDA"]);
                    }

                    if (dr["PRECIOTOPE"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOTOPE = (decimal)(dr["PRECIOTOPE"]);
                    }
                    if (dr["STOCKMAX"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
                    }

                    if (dr["SURTIRPORCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISURTIRPORCAJA = (string)(dr["SURTIRPORCAJA"]);
                    }

                    if (dr["PRECIOMAT"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    }

                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["ULTIMACOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMACOMPRA = (DateTime)(dr["ULTIMACOMPRA"]);
                    }

                    if (dr["EMIDAPRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAPRODUCTOID = (long)(dr["EMIDAPRODUCTOID"]);
                    }

                    if (dr["EMIDAID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAID = (string)(dr["EMIDAID"]);
                    }



                    if (dr["MENUDEO"] != System.DBNull.Value)
                    {
                        retorno.IMENUDEO = (decimal)(dr["MENUDEO"]);
                    }

                    if (dr["CONTENIDOID"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOID = (long)(dr["CONTENIDOID"]);
                    }

                    if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOVALOR = (decimal)(dr["CONTENIDOVALOR"]);
                    }

                    if (dr["CLASIFICAID"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICAID = (long)(dr["CLASIFICAID"]);
                    }

                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }


                    if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ICANTXPIEZA = (decimal)(dr["CANTXPIEZA"]);
                    }


                    if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTEIMPORTADO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    }


                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
                    }


                    if (dr["LOTEIMPORTADOAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADOAPLICADO = (string)(dr["LOTEIMPORTADOAPLICADO"]);
                    }

                    if (dr["PLAZOID"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOID = (long)(dr["PLAZOID"]);
                    }

                    if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IESPRODPROMO = (string)(dr["ESPRODPROMO"]);
                    }

                    if (dr["BASEPRODPROMOID"] != System.DBNull.Value)
                    {
                        retorno.IBASEPRODPROMOID = (long)(dr["BASEPRODPROMOID"]);
                    }

                    if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODPROMO = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    }
                    if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    }

                    if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.IKITTIENEVIG = (string)(dr["KITTIENEVIG"]);
                    }

                    if (dr["TASAIVAEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAEXT = (decimal)(dr["TASAIVAEXT"]);
                    }
                    if (dr["TASAIEPSEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPSEXT = (decimal)(dr["TASAIEPSEXT"]);
                    }
                    if (dr["TASAIMPEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPEXT = (decimal)(dr["TASAIMPEXT"]);
                    }

                    if (dr["VALXSUC"] != System.DBNull.Value)
                    {
                        retorno.IVALXSUC = (string)(dr["VALXSUC"]);
                    }


                    if (dr["STOCKMINCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINCAJA = (decimal)(dr["STOCKMINCAJA"]);
                    }

                    if (dr["STOCKMAXCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXCAJA = (decimal)(dr["STOCKMAXCAJA"]);
                    }


                    if (dr["STOCKMINPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINPIEZA = (decimal)(dr["STOCKMINPIEZA"]);
                    }

                    if (dr["STOCKMAXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXPIEZA = (decimal)(dr["STOCKMAXPIEZA"]);
                    }


                if (dr["DESCTOPE"] != System.DBNull.Value)
                {
                    retorno.IDESCTOPE = (decimal)(dr["DESCTOPE"]);
                }
                if (dr["MARGEN"] != System.DBNull.Value)
                {
                    retorno.IMARGEN = (decimal)(dr["MARGEN"]);
                }

                if (dr["DESCPES"] != System.DBNull.Value)
                {
                    retorno.IDESCPES = (decimal)(dr["DESCPES"]);
                }

                if (dr["KITIMPFIJO"] != System.DBNull.Value)
                {
                    retorno.IKITIMPFIJO = (string)(dr["KITIMPFIJO"]);
                }


            if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
            {
                retorno.IIMPRIMIRCOMANDA = (string)(dr["IMPRIMIRCOMANDA"]);
            }


            if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
            {
                retorno.ILISTAPRECMEDIOMAYID = (long)(dr["LISTAPRECMEDIOMAYID"]);
            }

            if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
            {
                retorno.ILISTAPRECMAYOREOID = (long)(dr["LISTAPRECMAYOREOID"]);
            }

            if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
            {
                retorno.ICANTMEDIOMAY = (decimal)(dr["CANTMEDIOMAY"]);
            }

            if (dr["CANTMAYOREO"] != System.DBNull.Value)
            {
                retorno.ICANTMAYOREO = (decimal)(dr["CANTMAYOREO"]);
            }

            if (dr["SAT_TIPOEMBALAJEID"] != System.DBNull.Value)
            {
                retorno.ISAT_TIPOEMBALAJEID = (long)(dr["SAT_TIPOEMBALAJEID"]);
            }

            if (dr["SAT_CLAVEUNIDADPESOID"] != System.DBNull.Value)
            {
                retorno.ISAT_CLAVEUNIDADPESOID = (long)(dr["SAT_CLAVEUNIDADPESOID"]);
            }

            if (dr["PESO"] != System.DBNull.Value)
            {
                retorno.IPESO = (decimal)(dr["PESO"]);
            }

            if (dr["ESPELIGROSO"] != System.DBNull.Value)
            {
                retorno.IESPELIGROSO = (string)(dr["ESPELIGROSO"]);
            }

            if (dr["SAT_MATPELIGROSOID"] != System.DBNull.Value)
            {
                retorno.ISAT_MATPELIGROSOID = (long)(dr["SAT_MATPELIGROSOID"]);
            }


            if (dr["ESOFERTA"] != System.DBNull.Value)
            {
                retorno.IESOFERTA = (string)(dr["ESOFERTA"]);
            }

            return retorno;
        }


        public DateTime SeleccionarUltimoCambioExistencia(FbTransaction st)
        {
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                string query = "select max(ultimocambioexistencia) ULTIMOCAMBIOEXISTENCIA from producto";

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, query, out pcn);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, query);

                DateTime lastChangeDateTime = new DateTime();

                if (dr.Read())
                {
                    if (dr["ULTIMOCAMBIOEXISTENCIA"] != System.DBNull.Value)
                    {
                        lastChangeDateTime = (DateTime)dr["ULTIMOCAMBIOEXISTENCIA"];

                    }
                }
                else
                {
                    lastChangeDateTime = DateTime.MinValue;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return lastChangeDateTime;
            }
            catch(Exception ex)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                DateTime lastChangeDateTime = DateTime.MinValue;

                this.iComentario = ex.Message + ex.StackTrace;

                return lastChangeDateTime;
            }
        }


        public CPRODUCTOBE seleccionarPRODUCTOxCLAVE(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2 , c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCPRODUCTO.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = dr.GetDateTime(2); //(object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = dr.GetDateTime(4); //(object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        retorno.IEAN = (string)(dr["EAN"]);
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }

                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["TASAIVAID"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = (decimal)(dr["TASAIVA"]);
                    }

                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
                    }

                    if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
                    }

                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = (string)(dr["MANEJALOTE"]);
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = (string)(dr["ESKIT"]);
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIABLE = (string)(dr["INVENTARIABLE"]);
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
                    }

                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITEPRECIO2"]);
                    }

                    if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAXIMOPUBLICO = (decimal)(dr["PRECIOMAXIMOPUBLICO"]);
                    }

                    if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHACAMBIOPRECIO = (DateTime)(dr["FECHACAMBIOPRECIO"]);
                    }

                    if (dr["MANEJASTOCK"] != System.DBNull.Value)
                    {
                        retorno.IMANEJASTOCK = (string)(dr["MANEJASTOCK"]);
                    }

                    if (dr["STOCK"] != System.DBNull.Value)
                    {
                        retorno.ISTOCK = (decimal)(dr["STOCK"]);
                    }

                    if (dr["PROVEEDOR1ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR1ID = int.Parse(dr["PROVEEDOR1ID"].ToString());
                    }

                    if (dr["PROVEEDOR2ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR2ID = int.Parse(dr["PROVEEDOR2ID"].ToString());
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = int.Parse(dr["LINEAID"].ToString());
                    }

                    if (dr["MARCAID"] != System.DBNull.Value)
                    {
                        retorno.IMARCAID = int.Parse(dr["MARCAID"].ToString());
                    }

                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = dr["CAMBIARPRECIO"].ToString();
                    }





                    if (dr["SUBSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUBSTITUTO = (string)(dr["SUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = (string)(dr["CBARRAS"]);
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
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
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        retorno.IINI_MAYO = (decimal)(dr["INI_MAYO"]);
                    }

                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        retorno.IMAYOKGS = (string)(dr["MAYOKGS"]);
                    }

                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = (string)(dr["TIPOABC"]);
                    }


                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                    }


                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
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
                        retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }



                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }

                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IESSUBPRODUCTO = (string)(dr["ESSUBPRODUCTO"]);
                    }

                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }


                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARCOMISIONPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }


                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMAROFERTAPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }



                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARPRECIOPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }

                    if (dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEXISTENCIA = (decimal)(dr["EXISTENCIA"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        retorno.IPLUG = (string)(dr["PLUG"]);
                    }
                    if (dr["ENPROCESODESALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESODESALIDA = (decimal)(dr["ENPROCESODESALIDA"]);
                    }

                    if (dr["DESCRIPCION_COMODIN"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION_COMODIN = (string)(dr["DESCRIPCION_COMODIN"]);
                    }

                    if (dr["CUENTAPREDIAL"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPREDIAL = (string)(dr["CUENTAPREDIAL"]);
                    }
                    if (dr["IMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IIMAGEN = (string)(dr["IMAGEN"]);
                    }

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }
                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO1 = (decimal)(dr["SPRECIO1"]);
                    }

                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO2 = (decimal)(dr["SPRECIO2"]);
                    }

                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO3 = (decimal)(dr["SPRECIO3"]);
                    }

                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO4 = (decimal)(dr["SPRECIO4"]);
                    }

                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO5 = (decimal)(dr["SPRECIO5"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        retorno.IREQUIERERECETA = (string)(dr["REQUIERERECETA"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["PROMOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IPROMOMOVIL = (string)(dr["PROMOMOVIL"]);
                    }

                    if (dr["HISTORIALMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IHISTORIALMOVIL = (string)(dr["HISTORIALMOVIL"]);
                    }

                    if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOSUGERIDO = (decimal)(dr["PRECIOSUGERIDO"]);
                    }
                    if (dr["ENPROCESOPARTESSALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESOPARTESSALIDA = (decimal)(dr["ENPROCESOPARTESSALIDA"]);
                    }

                    if (dr["PRECIOTOPE"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOTOPE = (decimal)(dr["PRECIOTOPE"]);
                    }
                    if (dr["STOCKMAX"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
                    }

                    if (dr["SURTIRPORCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISURTIRPORCAJA = (string)(dr["SURTIRPORCAJA"]);
                    }

                    if (dr["PRECIOMAT"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    }
                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }


                    if (dr["ULTIMACOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMACOMPRA = (DateTime)(dr["ULTIMACOMPRA"]);
                    }

                    if (dr["EMIDAPRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAPRODUCTOID = (long)(dr["EMIDAPRODUCTOID"]);
                    }

                    if (dr["EMIDAID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAID = (string)(dr["EMIDAID"]);
                    }

                    if (dr["MENUDEO"] != System.DBNull.Value)
                    {
                        retorno.IMENUDEO = (decimal)(dr["MENUDEO"]);
                    }

                    if (dr["CONTENIDOID"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOID = (long)(dr["CONTENIDOID"]);
                    }

                    if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOVALOR = (decimal)(dr["CONTENIDOVALOR"]);
                    }

                    if (dr["CLASIFICAID"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICAID = (long)(dr["CLASIFICAID"]);
                    }

                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }

                    if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ICANTXPIEZA = (decimal)(dr["CANTXPIEZA"]);
                    }

                    if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTEIMPORTADO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    }

                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
                    }

                    if (dr["LOTEIMPORTADOAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADOAPLICADO = (string)(dr["LOTEIMPORTADOAPLICADO"]);
                    }

                    if (dr["PLAZOID"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOID = (long)(dr["PLAZOID"]);
                    }

                    if(dr["SAT_PRODUCTOSERVICIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PRODUCTOSERVICIOID = (long)(dr["SAT_PRODUCTOSERVICIOID"]);
                    }

                    if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IESPRODPROMO = (string)(dr["ESPRODPROMO"]);
                    }

                    if (dr["BASEPRODPROMOID"] != System.DBNull.Value)
                    {
                        retorno.IBASEPRODPROMOID = (long)(dr["BASEPRODPROMOID"]);
                    }

                    if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODPROMO = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    }
                    if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    }
                    if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.IKITTIENEVIG = (string)(dr["KITTIENEVIG"]);
                    }


                    if (dr["TASAIVAEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAEXT = (decimal)(dr["TASAIVAEXT"]);
                    }
                    if (dr["TASAIEPSEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPSEXT = (decimal)(dr["TASAIEPSEXT"]);
                    }
                    if (dr["TASAIMPEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPEXT = (decimal)(dr["TASAIMPEXT"]);
                    }

                    if (dr["VALXSUC"] != System.DBNull.Value)
                    {
                        retorno.IVALXSUC = (string)(dr["VALXSUC"]);
                    }


                    if (dr["STOCKMINCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINCAJA = (decimal)(dr["STOCKMINCAJA"]);
                    }

                    if (dr["STOCKMAXCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXCAJA = (decimal)(dr["STOCKMAXCAJA"]);
                    }


                    if (dr["STOCKMINPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINPIEZA = (decimal)(dr["STOCKMINPIEZA"]);
                    }

                    if (dr["STOCKMAXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXPIEZA = (decimal)(dr["STOCKMAXPIEZA"]);
                    }

                    if (dr["DESCTOPE"] != System.DBNull.Value)
                    {
                        retorno.IDESCTOPE = (decimal)(dr["DESCTOPE"]);
                    }
                    if (dr["MARGEN"] != System.DBNull.Value)
                    {
                        retorno.IMARGEN = (decimal)(dr["MARGEN"]);
                    }

                    if (dr["DESCPES"] != System.DBNull.Value)
                    {
                        retorno.IDESCPES = (decimal)(dr["DESCPES"]);
                    }


                    if (dr["KITIMPFIJO"] != System.DBNull.Value)
                    {
                        retorno.IKITIMPFIJO = (string)(dr["KITIMPFIJO"]);
                    }


                    if (dr["PORCUTILPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO1 = (decimal)(dr["PORCUTILPRECIO1"]);
                    }

                    if (dr["PORCUTILPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO2 = (decimal)(dr["PORCUTILPRECIO2"]);
                    }

                    if (dr["PORCUTILPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO3 = (decimal)(dr["PORCUTILPRECIO3"]);
                    }

                    if (dr["PORCUTILPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO4 = (decimal)(dr["PORCUTILPRECIO4"]);
                    }

                    if (dr["PORCUTILPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO5 = (decimal)(dr["PORCUTILPRECIO5"]);
                    }

                    if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRCOMANDA = (string)(dr["IMPRIMIRCOMANDA"]);
                    }


                    if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMEDIOMAYID = (long)(dr["LISTAPRECMEDIOMAYID"]);
                    }

                    if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMAYOREOID = (long)(dr["LISTAPRECMAYOREOID"]);
                    }

                    if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
                    {
                        retorno.ICANTMEDIOMAY = (decimal)(dr["CANTMEDIOMAY"]);
                    }

                    if (dr["CANTMAYOREO"] != System.DBNull.Value)
                    {
                        retorno.ICANTMAYOREO = (decimal)(dr["CANTMAYOREO"]);
                    }

                    if (dr["SAT_TIPOEMBALAJEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOEMBALAJEID = (long)(dr["SAT_TIPOEMBALAJEID"]);
                    }

                    if (dr["SAT_CLAVEUNIDADPESOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEUNIDADPESOID = (long)(dr["SAT_CLAVEUNIDADPESOID"]);
                    }

                    if (dr["PESO"] != System.DBNull.Value)
                    {
                        retorno.IPESO = (decimal)(dr["PESO"]);
                    }

                    if (dr["ESPELIGROSO"] != System.DBNull.Value)
                    {
                        retorno.IESPELIGROSO = (string)(dr["ESPELIGROSO"]);
                    }


                    if (dr["SAT_MATPELIGROSOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MATPELIGROSOID = (long)(dr["SAT_MATPELIGROSOID"]);
                    }


                    if (dr["ESOFERTA"] != System.DBNull.Value)
                    {
                        retorno.IESOFERTA = (string)(dr["ESOFERTA"]);
                    }
                }
                else
                {
                    retorno = null;
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }






        [AutoComplete]
        public DataSet enlistarPRODUCTO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPRODUCTO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePRODUCTO(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRODUCTO where

  ID=@ID  
  );";


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public bool PRODUCTOPRECIO(FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            //int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"PRODUCTO_PRECIOS";
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



        public bool PRODUCTOPRECIOSMATRIZ(FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            //int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"PRODUCTO_PRECIOS_MATRIZ";
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

        public CPRODUCTOBE AgregarPRODUCTO(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTO(oCPRODUCTO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRODUCTO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPRODUCTOD(oCPRODUCTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPRODUCTO(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTO(oCPRODUCTO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRODUCTOD(oCPRODUCTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRODUCTO(CPRODUCTOBE oCPRODUCTONuevo, CPRODUCTOBE oCPRODUCTOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTO(oCPRODUCTOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRODUCTOD(oCPRODUCTONuevo, oCPRODUCTOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CPRODUCTOBE seleccionarPRODUCTOPorClave(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {




            CPRODUCTOBE retorno = new CPRODUCTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.clave=@CLAVE ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCPRODUCTO.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = dr.GetDateTime(2); //(object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = dr.GetDateTime(4); //(object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        retorno.IEAN = (string)(dr["EAN"]);
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }

                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["TASAIVAID"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
                    }

                    if (dr["TASAIVA"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVA = (decimal)(dr["TASAIVA"]);
                    }

                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
                    }

                    if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
                    }

                    if (dr["MANEJALOTE"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTE = (string)(dr["MANEJALOTE"]);
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        retorno.IESKIT = (string)(dr["ESKIT"]);
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }

                    if (dr["INVENTARIABLE"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIABLE = (string)(dr["INVENTARIABLE"]);
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
                    }

                    if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITEPRECIO2"]);
                    }

                    if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAXIMOPUBLICO = (decimal)(dr["PRECIOMAXIMOPUBLICO"]);
                    }

                    if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHACAMBIOPRECIO = (DateTime)(dr["FECHACAMBIOPRECIO"]);
                    }

                    if (dr["MANEJASTOCK"] != System.DBNull.Value)
                    {
                        retorno.IMANEJASTOCK = (string)(dr["MANEJASTOCK"]);
                    }

                    if (dr["STOCK"] != System.DBNull.Value)
                    {
                        retorno.ISTOCK = (decimal)(dr["STOCK"]);
                    }

                    if (dr["PROVEEDOR1ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR1ID = int.Parse(dr["PROVEEDOR1ID"].ToString());
                    }

                    if (dr["PROVEEDOR2ID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR2ID = int.Parse(dr["PROVEEDOR2ID"].ToString());
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = int.Parse(dr["LINEAID"].ToString());
                    }

                    if (dr["MARCAID"] != System.DBNull.Value)
                    {
                        retorno.IMARCAID = int.Parse(dr["MARCAID"].ToString());
                    }

                    if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIARPRECIO = dr["CAMBIARPRECIO"].ToString();
                    }



                    if (dr["SUBSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUBSTITUTO = (string)(dr["SUBSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = (string)(dr["CBARRAS"]);
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
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
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["INI_MAYO"] != System.DBNull.Value)
                    {
                        retorno.IINI_MAYO = (decimal)(dr["INI_MAYO"]);
                    }

                    if (dr["MAYOKGS"] != System.DBNull.Value)
                    {
                        retorno.IMAYOKGS = (string)(dr["MAYOKGS"]);
                    }

                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = (string)(dr["TIPOABC"]);
                    }


                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["OFERTA"] != System.DBNull.Value)
                    {
                        retorno.IOFERTA = (decimal)(dr["OFERTA"]);
                    }

                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
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
                        retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
                    }



                    if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOPADRE = (string)(dr["ESPRODUCTOPADRE"]);
                    }

                    if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IESSUBPRODUCTO = (string)(dr["ESSUBPRODUCTO"]);
                    }

                    if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IESPRODUCTOFINAL = (string)(dr["ESPRODUCTOFINAL"]);
                    }


                    if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARCOMISIONPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
                    }


                    if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMAROFERTAPADRE = (string)(dr["TOMAROFERTAPADRE"]);
                    }



                    if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
                    {
                        retorno.ITOMARPRECIOPADRE = (string)(dr["TOMARPRECIOPADRE"]);
                    }

                    if (dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEXISTENCIA = (decimal)(dr["EXISTENCIA"]);
                    }

                    if (dr["PLUG"] != System.DBNull.Value)
                    {
                        retorno.IPLUG = (string)(dr["PLUG"]);
                    }
                    if (dr["ENPROCESODESALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESODESALIDA = (decimal)(dr["ENPROCESODESALIDA"]);
                    }


                    if (dr["DESCRIPCION_COMODIN"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION_COMODIN = (string)(dr["DESCRIPCION_COMODIN"]);
                    }

                    if (dr["CUENTAPREDIAL"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPREDIAL = (string)(dr["CUENTAPREDIAL"]);
                    }
                    if (dr["IMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IIMAGEN = (string)(dr["IMAGEN"]);
                    }

                    if (dr["MINUTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
                    }
                    if (dr["SPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO1 = (decimal)(dr["SPRECIO1"]);
                    }

                    if (dr["SPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO2 = (decimal)(dr["SPRECIO2"]);
                    }

                    if (dr["SPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO3 = (decimal)(dr["SPRECIO3"]);
                    }

                    if (dr["SPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO4 = (decimal)(dr["SPRECIO4"]);
                    }

                    if (dr["SPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.ISPRECIO5 = (decimal)(dr["SPRECIO5"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["REQUIERERECETA"] != System.DBNull.Value)
                    {
                        retorno.IREQUIERERECETA = (string)(dr["REQUIERERECETA"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["PROMOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IPROMOMOVIL = (string)(dr["PROMOMOVIL"]);
                    }

                    if (dr["HISTORIALMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IHISTORIALMOVIL = (string)(dr["HISTORIALMOVIL"]);
                    }

                    if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOSUGERIDO = (decimal)(dr["PRECIOSUGERIDO"]);
                    }

                    if (dr["ENPROCESOPARTESSALIDA"] != System.DBNull.Value)
                    {
                        retorno.IENPROCESOPARTESSALIDA = (decimal)(dr["ENPROCESOPARTESSALIDA"]);
                    }

                    if (dr["PRECIOTOPE"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOTOPE = (decimal)(dr["PRECIOTOPE"]);
                    }


                    if (dr["STOCKMAX"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
                    }

                    if (dr["SURTIRPORCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISURTIRPORCAJA = (string)(dr["SURTIRPORCAJA"]);
                    }

                    if (dr["PRECIOMAT"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
                    }
                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (decimal)(dr["PRECIO6"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["ULTIMACOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMACOMPRA = (DateTime)(dr["ULTIMACOMPRA"]);

                        //
                    }

                    if (dr["EMIDAPRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAPRODUCTOID = (long)(dr["EMIDAPRODUCTOID"]);
                    }

                    if (dr["EMIDAID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAID = (string)(dr["EMIDAID"]);
                    }

                    if (dr["MENUDEO"] != System.DBNull.Value)
                    {
                        retorno.IMENUDEO = (decimal)(dr["MENUDEO"]);
                    }

                    if (dr["CONTENIDOID"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOID = (long)(dr["CONTENIDOID"]);
                    }

                    if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
                    {
                        retorno.ICONTENIDOVALOR = (decimal)(dr["CONTENIDOVALOR"]);
                    }

                    if (dr["CLASIFICAID"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICAID = (long)(dr["CLASIFICAID"]);
                    }

                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }

                    if (dr["CANTXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ICANTXPIEZA = (decimal)(dr["CANTXPIEZA"]);
                    }

                    if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.IMANEJALOTEIMPORTADO = (string)(dr["MANEJALOTEIMPORTADO"]);
                    }

                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
                    }

                    if (dr["LOTEIMPORTADOAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADOAPLICADO = (string)(dr["LOTEIMPORTADOAPLICADO"]);
                    }

                    if (dr["PLAZOID"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOID = (long)(dr["PLAZOID"]);
                    }

                    if (dr["ESPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IESPRODPROMO = (string)(dr["ESPRODPROMO"]);
                    }

                    if (dr["BASEPRODPROMOID"] != System.DBNull.Value)
                    {
                        retorno.IBASEPRODPROMOID = (long)(dr["BASEPRODPROMOID"]);
                    }

                    if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODPROMO = (DateTime)(dr["VIGENCIAPRODPROMO"]);
                    }

                    if (dr["SAT_PRODUCTOSERVICIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PRODUCTOSERVICIOID = (long)(dr["SAT_PRODUCTOSERVICIOID"]);
                    }
                    if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAPRODKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
                    }
                    if (dr["KITTIENEVIG"] != System.DBNull.Value)
                    {
                        retorno.IKITTIENEVIG = (string)(dr["KITTIENEVIG"]);
                    }


                    if (dr["TASAIVAEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIVAEXT = (decimal)(dr["TASAIVAEXT"]);
                    }
                    if (dr["TASAIEPSEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPSEXT = (decimal)(dr["TASAIEPSEXT"]);
                    }
                    if (dr["TASAIMPEXT"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPEXT = (decimal)(dr["TASAIMPEXT"]);
                    }

                    if (dr["VALXSUC"] != System.DBNull.Value)
                    {
                        retorno.IVALXSUC = (string)(dr["VALXSUC"]);
                    }


                    if (dr["STOCKMINCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINCAJA = (decimal)(dr["STOCKMINCAJA"]);
                    }

                    if (dr["STOCKMAXCAJA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXCAJA = (decimal)(dr["STOCKMAXCAJA"]);
                    }


                    if (dr["STOCKMINPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMINPIEZA = (decimal)(dr["STOCKMINPIEZA"]);
                    }

                    if (dr["STOCKMAXPIEZA"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAXPIEZA = (decimal)(dr["STOCKMAXPIEZA"]);
                    }

                    if (dr["DESCTOPE"] != System.DBNull.Value)
                    {
                        retorno.IDESCTOPE = (decimal)(dr["DESCTOPE"]);
                    }
                    if (dr["MARGEN"] != System.DBNull.Value)
                    {
                        retorno.IMARGEN = (decimal)(dr["MARGEN"]);
                    }

                    if (dr["DESCPES"] != System.DBNull.Value)
                    {
                        retorno.IDESCPES = (decimal)(dr["DESCPES"]);
                    }
                    if (dr["KITIMPFIJO"] != System.DBNull.Value)
                    {
                        retorno.IKITIMPFIJO = (string)(dr["KITIMPFIJO"]);
                    }



                    if (dr["PORCUTILPRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO1 = (decimal)(dr["PORCUTILPRECIO1"]);
                    }

                    if (dr["PORCUTILPRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO2 = (decimal)(dr["PORCUTILPRECIO2"]);
                    }

                    if (dr["PORCUTILPRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO3 = (decimal)(dr["PORCUTILPRECIO3"]);
                    }

                    if (dr["PORCUTILPRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO4 = (decimal)(dr["PORCUTILPRECIO4"]);
                    }

                    if (dr["PORCUTILPRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPORCUTILPRECIO5 = (decimal)(dr["PORCUTILPRECIO5"]);
                    }

                    if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRCOMANDA = (string)(dr["IMPRIMIRCOMANDA"]);
                    }


                    if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMEDIOMAYID = (long)(dr["LISTAPRECMEDIOMAYID"]);
                    }

                    if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECMAYOREOID = (long)(dr["LISTAPRECMAYOREOID"]);
                    }

                    if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
                    {
                        retorno.ICANTMEDIOMAY = (decimal)(dr["CANTMEDIOMAY"]);
                    }

                    if (dr["CANTMAYOREO"] != System.DBNull.Value)
                    {
                        retorno.ICANTMAYOREO = (decimal)(dr["CANTMAYOREO"]);
                    }


                    if (dr["SAT_TIPOEMBALAJEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TIPOEMBALAJEID = (long)(dr["SAT_TIPOEMBALAJEID"]);
                    }

                    if (dr["SAT_CLAVEUNIDADPESOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEUNIDADPESOID = (long)(dr["SAT_CLAVEUNIDADPESOID"]);
                    }

                    if (dr["PESO"] != System.DBNull.Value)
                    {
                        retorno.IPESO = (decimal)(dr["PESO"]);
                    }

                    if (dr["ESPELIGROSO"] != System.DBNull.Value)
                    {
                        retorno.IESPELIGROSO = (string)(dr["ESPELIGROSO"]);
                    }

                    if (dr["SAT_MATPELIGROSOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MATPELIGROSOID = (long)(dr["SAT_MATPELIGROSOID"]);
                    }


                    if (dr["ESOFERTA"] != System.DBNull.Value)
                    {
                        retorno.IESOFERTA = (string)(dr["ESOFERTA"]);
                    }
                }
                else
                {
                    retorno = null;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);




                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }








        public bool importarPRODUCTOD(CPRODUCTOBE oCPRODUCTO, string p_claveLinea, string p_claveMarca, string p_claveMoneda, string p_claveSustituto, string p_proveedor1, string p_proveedor2, string p_claveTasaIva, string p_claveProductoPadre, string p_clave_contenido, string p_clave_clasifica, string p_clavePlazo, string p_clave_sat, string p_claveProdProm, 
                                    string p_sat_tipoembalaje_clave, string p_sat_claveunidadpeso_clave, string p_sat_matpeligroso_clave,  FbTransaction st)
        {

            

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IEAN"])
                {
                    auxPar.Value = oCPRODUCTO.IEAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_LINEA", FbDbType.VarChar);
                auxPar.Value = p_claveLinea;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MARCA", FbDbType.VarChar);
                auxPar.Value = p_claveMarca;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDAID", FbDbType.VarChar);
                auxPar.Value = p_claveMoneda;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_SUSTITUTO", FbDbType.VarChar);
                auxPar.Value = p_claveSustituto;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTE"] && oCPRODUCTO.IMANEJALOTE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESKIT"] && oCPRODUCTO.IESKIT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESKIT;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIR"] && oCPRODUCTO.IIMPRIMIR.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IINVENTARIABLE"] && oCPRODUCTO.IINVENTARIABLE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["INEGATIVOS"] && oCPRODUCTO.INEGATIVOS.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR1", FbDbType.VarChar);
                auxPar.Value = p_proveedor1;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR2", FbDbType.VarChar);
                auxPar.Value = p_proveedor2;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICAMBIARPRECIO"] && oCPRODUCTO.ICAMBIARPRECIO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBSTITUTO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ISUBSTITUTO"])
                {
                    auxPar.Value = oCPRODUCTO.ISUBSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODUCTO.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODUCTO.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCPRODUCTO.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCPRODUCTO.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPRODUCTO.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_TASAIVA", FbDbType.VarChar);
                auxPar.Value = p_claveTasaIva;
                parts.Add(auxPar);





                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE", FbDbType.VarChar);
                auxPar.Value = p_claveProductoPadre;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESPRODUCTOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODUCTOFINAL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOFINAL"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOFINAL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSUBPRODUCTO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESSUBPRODUCTO"])
                {
                    auxPar.Value = oCPRODUCTO.IESSUBPRODUCTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARCOMISIONPADRE"])
                {
                    if (oCPRODUCTO.ITOMARCOMISIONPADRE.Trim().Length > 0)
                        auxPar.Value = oCPRODUCTO.ITOMARCOMISIONPADRE;
                    else
                        auxPar.Value = "N";

                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IPLUG"])
                {
                    auxPar.Value = oCPRODUCTO.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTO_INSERT_FK", FbDbType.Char);
                auxPar.Value = DBValues._DB_BOOLVALUE_SI;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IREQUIERERECETA"])
                {
                    auxPar.Value = oCPRODUCTO.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPRODUCTO.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOMOVIL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IPROMOMOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IPROMOMOVIL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOSUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOSUGERIDO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOSUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOTOPE"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PRECIOMAT", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAT"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO6", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@MENUDEO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMENUDEO"])
                {
                    auxPar.Value = oCPRODUCTO.IMENUDEO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLAVE_CONTENIDO", FbDbType.VarChar);
                auxPar.Value = p_clave_contenido;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTENIDOVALOR", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICONTENIDOVALOR"])
                {
                    auxPar.Value = oCPRODUCTO.ICONTENIDOVALOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLAVE_CLASIFICA", FbDbType.VarChar);
                auxPar.Value = p_clave_clasifica;
                parts.Add(auxPar);



                auxPar = new FbParameter("@UNIDAD2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CANTXPIEZA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICANTXPIEZA"])
                {
                    auxPar.Value = oCPRODUCTO.ICANTXPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@MANEJALOTEIMPORTADO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTEIMPORTADO"])
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@COSTOENDOLAR", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOENDOLAR"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOENDOLAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZOCLAVE", FbDbType.VarChar);
                if (p_clavePlazo != null)
                {
                    auxPar.Value = p_clavePlazo;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVESAT", FbDbType.VarChar);
                if (p_clavePlazo != null)
                {
                    auxPar.Value = p_clave_sat;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPRODPROM", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IESPRODPROMO"] && oCPRODUCTO.IESPRODPROMO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESPRODPROMO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BASEPROM", FbDbType.VarChar);
                if (p_claveProdProm != null)
                {
                    auxPar.Value = p_claveProdProm;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGPROM", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IVIGENCIAPRODPROMO"])
                {
                    auxPar.Value = oCPRODUCTO.IVIGENCIAPRODPROMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VIGKIT", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IVIGENCIAPRODKIT"])
                {
                    auxPar.Value = oCPRODUCTO.IVIGENCIAPRODKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@KITCVIG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IKITTIENEVIG"])
                {
                    auxPar.Value = oCPRODUCTO.IKITTIENEVIG;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VALXSUC", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IVALXSUC"])
                {
                    auxPar.Value = oCPRODUCTO.IVALXSUC;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DESCTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IDESCTOPE"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARGEN", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMARGEN"])
                {
                    auxPar.Value = oCPRODUCTO.IMARGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCPES", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IDESCPES"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCPES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@KITIMPFIJO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IKITIMPFIJO"])
                {
                    auxPar.Value = oCPRODUCTO.IKITIMPFIJO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIRCOMANDA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIRCOMANDA"] && oCPRODUCTO.IIMPRIMIRCOMANDA.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIRCOMANDA;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECMEDIOMAYID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ILISTAPRECMEDIOMAYID"])
                {
                    auxPar.Value = oCPRODUCTO.ILISTAPRECMEDIOMAYID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECMAYOREOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ILISTAPRECMAYOREOID"])
                {
                    auxPar.Value = oCPRODUCTO.ILISTAPRECMAYOREOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTMEDIOMAY", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICANTMEDIOMAY"])
                {
                    auxPar.Value = oCPRODUCTO.ICANTMEDIOMAY;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTMAYOREO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICANTMAYOREO"])
                {
                    auxPar.Value = oCPRODUCTO.ICANTMAYOREO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@SAT_TIPOEMBALAJE_CLAVE", FbDbType.VarChar);
                if (p_sat_tipoembalaje_clave != null)
                {
                    auxPar.Value = p_sat_tipoembalaje_clave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVEUNIDADPESO_CLAVE", FbDbType.VarChar);
                if (p_sat_claveunidadpeso_clave != null)
                {
                    auxPar.Value = p_sat_claveunidadpeso_clave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                



                auxPar = new FbParameter("@PESO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPESO"])
                {
                    auxPar.Value = oCPRODUCTO.IPESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPELIGROSO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPELIGROSO"])
                {
                    auxPar.Value = oCPRODUCTO.IESPELIGROSO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_MATPELIGROSO_CLAVE", FbDbType.VarChar);
                if (p_sat_matpeligroso_clave != null)
                {
                    auxPar.Value = p_sat_matpeligroso_clave;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESOFERTA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IESOFERTA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"productos_importar";

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
                        this.iComentario = "Hubo un error";
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






        public bool importarPRODUCTODMOVIL(CPRODUCTOBE oCPRODUCTO, string p_claveLinea, string p_claveMarca, string p_claveMoneda, string p_claveSustituto, string p_proveedor1, string p_proveedor2, string p_claveTasaIva, string p_claveProductoPadre, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IEAN"])
                {
                    auxPar.Value = oCPRODUCTO.IEAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_LINEA", FbDbType.VarChar);
                auxPar.Value = p_claveLinea;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MARCA", FbDbType.VarChar);
                auxPar.Value = p_claveMarca;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDAID", FbDbType.VarChar);
                auxPar.Value = p_claveMoneda;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_SUSTITUTO", FbDbType.VarChar);
                auxPar.Value = p_claveSustituto;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTE"] && oCPRODUCTO.IMANEJALOTE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESKIT"] && oCPRODUCTO.IESKIT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESKIT;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIR"] && oCPRODUCTO.IIMPRIMIR.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IINVENTARIABLE"] && oCPRODUCTO.IINVENTARIABLE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["INEGATIVOS"] && oCPRODUCTO.INEGATIVOS.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR1", FbDbType.VarChar);
                auxPar.Value = p_proveedor1;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR2", FbDbType.VarChar);
                auxPar.Value = p_proveedor2;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICAMBIARPRECIO"] && oCPRODUCTO.ICAMBIARPRECIO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBSTITUTO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ISUBSTITUTO"])
                {
                    auxPar.Value = oCPRODUCTO.ISUBSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODUCTO.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODUCTO.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCPRODUCTO.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCPRODUCTO.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPRODUCTO.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_TASAIVA", FbDbType.VarChar);
                auxPar.Value = p_claveTasaIva;
                parts.Add(auxPar);





                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE", FbDbType.VarChar);
                auxPar.Value = p_claveProductoPadre;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESPRODUCTOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODUCTOFINAL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOFINAL"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOFINAL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSUBPRODUCTO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESSUBPRODUCTO"])
                {
                    auxPar.Value = oCPRODUCTO.IESSUBPRODUCTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARCOMISIONPADRE"])
                {
                    if (oCPRODUCTO.ITOMARCOMISIONPADRE.Trim().Length > 0)
                        auxPar.Value = oCPRODUCTO.ITOMARCOMISIONPADRE;
                    else
                        auxPar.Value = "N";

                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IPLUG"])
                {
                    auxPar.Value = oCPRODUCTO.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTO_INSERT_FK", FbDbType.Char);
                auxPar.Value = DBValues._DB_BOOLVALUE_SI;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IREQUIERERECETA"])
                {
                    auxPar.Value = oCPRODUCTO.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPRODUCTO.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOMOVIL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IPROMOMOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IPROMOMOVIL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MARGENMOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMARGENMOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IMARGENMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IMPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.ICPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TPRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.ITPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APRECIO4MOVIL", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IAPRECIO4MOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IAPRECIO4MOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                /*auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/

                /*
                auxPar = new FbParameter("@PORCUTILPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PRODUCTOS_IMPORTAR_MOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                Console.WriteLine("In" + DateTime.Now.ToString("HH:mm:ss.fff"));
               
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                Console.WriteLine("Fn" + DateTime.Now.ToString("HH:mm:ss.fff"));

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
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




        public bool importarPRODUCTOMOVIL_2(CPRODUCTOBE oCPRODUCTO, string p_claveLinea, string p_claveMarca, string p_claveMoneda, string p_claveSustituto, string p_proveedor1, string p_proveedor2, string p_claveTasaIva, string p_claveProductoPadre, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IEAN"])
                {
                    auxPar.Value = oCPRODUCTO.IEAN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCPRODUCTO.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR1ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR1ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR1ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDOR2ID", FbDbType.Integer);
                if (!(bool)oCPRODUCTO.isnull["IPROVEEDOR2ID"])
                {
                    auxPar.Value = oCPRODUCTO.IPROVEEDOR2ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_LINEA", FbDbType.VarChar);
                auxPar.Value = p_claveLinea;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MARCA", FbDbType.VarChar);
                auxPar.Value = p_claveMarca;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVAID"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TASAIVA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIVA"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDAID", FbDbType.VarChar);
                auxPar.Value = p_claveMoneda;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOULTIMO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOULTIMO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOULTIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOPROMEDIO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOPROMEDIO"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOPROMEDIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_SUSTITUTO", FbDbType.VarChar);
                auxPar.Value = p_claveSustituto;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MANEJALOTE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMANEJALOTE"] && oCPRODUCTO.IMANEJALOTE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IMANEJALOTE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESKIT", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESKIT"] && oCPRODUCTO.IESKIT.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IESKIT;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRIMIR", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IIMPRIMIR"] && oCPRODUCTO.IIMPRIMIR.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVENTARIABLE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IINVENTARIABLE"] && oCPRODUCTO.IINVENTARIABLE.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.IINVENTARIABLE;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEGATIVOS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["INEGATIVOS"] && oCPRODUCTO.INEGATIVOS.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LIMITEPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ILIMITEPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ILIMITEPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAXIMOPUBLICO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOMAXIMOPUBLICO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOMAXIMOPUBLICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR1", FbDbType.VarChar);
                auxPar.Value = p_proveedor1;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_PROVEEDOR2", FbDbType.VarChar);
                auxPar.Value = p_proveedor2;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAMBIARPRECIO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICAMBIARPRECIO"] && oCPRODUCTO.ICAMBIARPRECIO.Trim() != "")
                {
                    auxPar.Value = oCPRODUCTO.ICAMBIARPRECIO;
                }
                else
                {
                    auxPar.Value = DBValues._DB_BOOLVALUE_NO;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBSTITUTO", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ISUBSTITUTO"])
                {
                    auxPar.Value = oCPRODUCTO.ISUBSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CBARRAS", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODUCTO.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEMPAQUE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODUCTO.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODUCTO.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INI_MAYO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IINI_MAYO"])
                {
                    auxPar.Value = oCPRODUCTO.IINI_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAYOKGS", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IMAYOKGS"])
                {
                    auxPar.Value = oCPRODUCTO.IMAYOKGS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABC", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPRODUCTO.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_TASAIVA", FbDbType.VarChar);
                auxPar.Value = p_claveTasaIva;
                parts.Add(auxPar);





                auxPar = new FbParameter("@TEXTO1", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO2", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TEXTO3", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO4", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO5", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TEXTO6", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPRODUCTO.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMERO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPRODUCTO.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA1", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA2", FbDbType.Date);
                if (!(bool)oCPRODUCTO.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPRODUCTO.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVE_PRODUCTOPADRE", FbDbType.VarChar);
                auxPar.Value = p_claveProductoPadre;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESPRODUCTOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPRODUCTOFINAL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESPRODUCTOFINAL"])
                {
                    auxPar.Value = oCPRODUCTO.IESPRODUCTOFINAL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSUBPRODUCTO", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IESSUBPRODUCTO"])
                {
                    auxPar.Value = oCPRODUCTO.IESSUBPRODUCTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TOMARPRECIOPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARPRECIOPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMARPRECIOPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMARCOMISIONPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMARCOMISIONPADRE"])
                {
                    if (oCPRODUCTO.ITOMARCOMISIONPADRE.Trim().Length > 0)
                        auxPar.Value = oCPRODUCTO.ITOMARCOMISIONPADRE;
                    else
                        auxPar.Value = "N";

                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOMAROFERTAPADRE", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ITOMAROFERTAPADRE"])
                {
                    auxPar.Value = oCPRODUCTO.ITOMAROFERTAPADRE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OFERTA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPRODUCTO.IOFERTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PLUG", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["IPLUG"])
                {
                    auxPar.Value = oCPRODUCTO.IPLUG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TASAIEPS", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPRODUCTO.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MINUTILIDAD", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCPRODUCTO.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTO_INSERT_FK", FbDbType.Char);
                auxPar.Value = DBValues._DB_BOOLVALUE_SI;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUIERERECETA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IREQUIERERECETA"])
                {
                    auxPar.Value = oCPRODUCTO.IREQUIERERECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASIFICA", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPRODUCTO.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOMOVIL", FbDbType.Char);
                if (!(bool)oCPRODUCTO.isnull["IPROMOMOVIL"])
                {
                    auxPar.Value = oCPRODUCTO.IPROMOMOVIL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOSUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOSUGERIDO"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOSUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIOTOPE", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIOTOPE"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIOTOPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                /*auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTO.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCPRODUCTO.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/


                auxPar = new FbParameter("@PORCUTILPRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCUTILPRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPORCUTILPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPORCUTILPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"productos_importar_movil_2";

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
                        this.iComentario = "Hubo un error";
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







        public bool importarPRODUCTOPRECIOD(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PRODUCTOS_IMPORTAR_PRECIOS";

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
                        this.iComentario = "Hubo un error";
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



        public bool importarPRODUCTOPRECIOLISTAD(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPRODUCTO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPRODUCTO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPRODUCTO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODUCTO.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOREPOSICION", FbDbType.Numeric);
                if (!(bool)oCPRODUCTO.isnull["ICOSTOREPOSICION"])
                {
                    auxPar.Value = oCPRODUCTO.ICOSTOREPOSICION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PRODUCTOS_IMPORTAR_PREC_LISTA";

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
                        this.iComentario = "Hubo un error";
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


        public CPRODUCTOBE buscarPRODUCTOSLineaComando(string producto, ref decimal cantidadAux, ref bool bPreguntaCantidad, CPARAMETROBE parametro, ref bool esEmpaque, ref bool esCaja, ref bool tienePrefijoBascula, FbTransaction st)
        {
            CPRODUCTOBE retorno = null;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            bPreguntaCantidad = false;

            esEmpaque = false;
            esCaja = false;

            FbParameter[] arParms;

            if (producto == String.Empty || producto == "")
            {
                return null;
            }


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "";

                Boolean encontrado = false;



                //if ((!prefijoBascula.Equals("")) && producto.StartsWith(prefijoBascula) /*&& (producto.Trim() != "9002490100070") && (producto.Trim() != "9002490207717")*/)
                //else
                //

                CmdTxt = @"select p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.EAN=@VALOR ";

                parts.Clear();

                auxPar = new FbParameter("@VALOR", FbDbType.VarChar);
                auxPar.Value = producto;
                parts.Add(auxPar);


                FbParameter[] arParms2 = new FbParameter[parts.Count];
                parts.CopyTo(arParms2, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms2);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms2);

                int iCuentaXEANConExistencia = 0;
                int iCuentaXEAN = 0;
                CPRODUCTOBE prodConExis = null;


                if (dr.Read())
                {
                    do
                    {
                        if (parametro.IESVENDEDORMOVIL.Equals("S") && dr["ACTIVO"] != null && dr["ACTIVO"].Equals("N"))
                            continue;






                        cantidadAux = 1;
                        retorno = getProductoDeReader(dr);
                        if (retorno.IUNIDAD != null /*dr["UNIDAD"] != System.DBNull.Value*/)
                        {
                            if (/*dr["UNIDAD"]*/retorno.IUNIDAD.ToString().Trim().ToUpper() == "KG")
                                bPreguntaCantidad = true;
                        }



                        encontrado = true;
                        //break;

                        iCuentaXEAN++;
                        if (retorno.IEXISTENCIA > 0)
                        {
                            prodConExis = retorno;
                            iCuentaXEANConExistencia++;
                        }

                    } while (dr.Read());
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                //si hay mas de uno que coincide
                if (iCuentaXEAN > 1)
                {
                    //si solo hay uno con existencia poner ese
                    if (iCuentaXEANConExistencia == 1)
                    {

                        retorno = prodConExis;
                    }
                    //si no hay existencia de ninguno o hay varios con existencia entonces retorno null
                    else
                    {
                        return null;
                    }

                }


                if (!encontrado)
                {

                    CmdTxt = @"select first 1  p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.CBARRAS=@VALOR ";
                    if (st == null)
                        dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms2);
                    else
                        dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms2);
                    if (dr.Read())
                    {
                        do
                        {
                            if (parametro.IESVENDEDORMOVIL.Equals("S") && dr["ACTIVO"] != null && dr["ACTIVO"].Equals("N"))
                                continue;

                            if (dr["PZACAJA"] != System.DBNull.Value)
                            {
                                cantidadAux = (decimal)dr["PZACAJA"];
                            }
                            else
                            {
                                cantidadAux = 1;
                            }

                            retorno = getProductoDeReader(dr);


                            encontrado = true;
                            esCaja = true;
                            break;
                        } while (dr.Read());
                    }

                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                    if (!encontrado)
                    {

                        CmdTxt = @"select first 1  p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.CEMPAQUE=@VALOR ";
                        if (st == null)
                            dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms2);
                        else
                            dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms2);
                        if (dr.Read())
                        {
                            do
                            {
                                if (parametro.IESVENDEDORMOVIL.Equals("S") && dr["ACTIVO"] != null && dr["ACTIVO"].Equals("N"))
                                    continue;


                                if (dr["U_EMPAQUE"] != System.DBNull.Value)
                                {
                                    cantidadAux = (decimal)dr["U_EMPAQUE"];
                                }
                                else
                                {
                                    cantidadAux = 1;
                                }
                                retorno = getProductoDeReader(dr);

                                encontrado = true;
                                esEmpaque = true;

                                break;
                            } while (dr.Read());
                        }

                        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                        if (!encontrado)
                        {

                            CmdTxt = @"select first 1  p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.CLAVE=@VALOR ";
                            if (st == null)
                                dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms2);
                            else
                                dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms2);
                            if (dr.Read())
                            {
                                do
                                {
                                    if (parametro.IESVENDEDORMOVIL.Equals("S") && dr["ACTIVO"] != null && dr["ACTIVO"].Equals("N"))
                                        continue;

                                    cantidadAux = 1;

                                    if (dr["UNIDAD"] != System.DBNull.Value)
                                    {
                                        if (dr["UNIDAD"].ToString().Trim().ToUpper() == "KG")
                                            bPreguntaCantidad = true;
                                    }

                                    retorno = getProductoDeReader(dr);

                                    encontrado = true;
                                    break;
                                } while (dr.Read());
                            }

                            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                        }






                    }

                }
                //}

                string prefijoBascula = (parametro.IPREFIJOBASCULA == null) ? "" : parametro.IPREFIJOBASCULA;
                if (retorno == null && ((!prefijoBascula.Equals("")) && producto.StartsWith(prefijoBascula)))
                {
                    parts.Clear();
                    Int16 longprod = ((bool)parametro.isnull["ILONGPRODBASCULA"]) ? (Int16)0 : parametro.ILONGPRODBASCULA;
                    Int16 longpeso = ((bool)parametro.isnull["ILONGPESOBASCULA"]) ? (Int16)0 : parametro.ILONGPESOBASCULA;

                    CmdTxt = @"select first 1  p.*,c.texto1,c.texto2 ,c.texto3 , c.texto4, c.texto5, c.texto6,
                                             c.numero1, c.numero2, c.numero3, c.numero4,
                                             c.fecha1, c.fecha2 from PRODUCTO p left join PRODUCTOCARACTERISTICAS c on p.id = c.productoid where p.PLUG=@VALOR ";

                    auxPar = new FbParameter("@VALOR", FbDbType.VarChar);
                    auxPar.Value = producto.Substring(0, Math.Min(longprod, producto.Length));
                    parts.Add(auxPar);

                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);
                    //FbDataReader dr = null;
                    if (st == null)
                        dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                    else
                        dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                    if (dr.Read())
                    {
                        try
                        {
                            cantidadAux = decimal.Parse(producto.Substring(longprod, longpeso)) / 1000;
                        }
                        catch
                        {
                            cantidadAux = 0;
                        }

                        tienePrefijoBascula = true;
                        retorno = getProductoDeReader(dr);
                    }

                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                }




                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
            finally
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
            }
        }



        public bool GetExistencia(CPRODUCTOBE productBE, ref int reg_count, ref decimal cantidad, ref string lote, ref DateTime fechaVence, long? almacenId, FbTransaction st)
        {


            System.Collections.ArrayList parts = new ArrayList();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            FbParameter auxPar;

            reg_count = 0;
            cantidad = 0;

            try
            {


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)productBE.isnull["IID"])
                {
                    auxPar.Value = productBE.IID;
                }
                else
                {
                    return false;

                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (almacenId.HasValue)
                {
                    auxPar.Value = almacenId.Value;
                }
                else
                {
                    auxPar.Value = 0;

                }
                parts.Add(auxPar);


                string commandText = @"select count(*) NUM_REGISTROS, sum(cantidad) CANTIDAD, MAX(lote) LOTE, MAX(FECHAVENCE) FECHAVENCE
                                       from inventario
                                       where productoid = @PRODUCTOID AND (@ALMACENID = 0 OR ALMACENID = @ALMACENID)";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.StoredProcedure, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.StoredProcedure, commandText, arParms);

                if (dr.Read())
                {
                    if (dr["NUM_REGISTROS"] != System.DBNull.Value)
                    {
                        reg_count = (int)(dr["NUM_REGISTROS"]);
                    }
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        cantidad = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        lote = dr["LOTE"].ToString();
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        fechaVence = (DateTime)dr["FECHAVENCE"];
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




        public decimal GetExistenciaPorLote(long lProductoId, string lote, DateTime fechaVence, FbTransaction st)
        {


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            decimal cantidad = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = lProductoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                auxPar.Value = lote;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                auxPar.Value = fechaVence;
                parts.Add(auxPar);


                string commandText = @"select  sum(cantidad) CANTIDAD
                                       from inventario
                                       where productoid = @PRODUCTOID AND lote = @LOTE and fechavence = @FECHAVENCE";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.StoredProcedure, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.StoredProcedure, commandText, arParms);

                if (dr.Read())
                {
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        cantidad = (decimal)(dr["CANTIDAD"]);
                    }


                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return cantidad;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }

        }



        public bool GetNumTransacciones(CPRODUCTOBE productBE, ref int reg_count, FbTransaction st)
        {


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            reg_count = 0;

            try
            {


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)productBE.isnull["IID"])
                {
                    auxPar.Value = productBE.IID;
                }
                else
                {
                    return false;

                }
                parts.Add(auxPar);


                string commandText = @"select count(*) NUM_REGISTROS
                                       from movto
                                       where productoid = @PRODUCTOID";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.StoredProcedure, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.StoredProcedure, commandText, arParms);

                if (dr.Read())
                {
                    if (dr["NUM_REGISTROS"] != System.DBNull.Value)
                    {
                        reg_count = (int)(dr["NUM_REGISTROS"]);
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




        public CPRODUCTOBE getProductoDeReader(FbDataReader dr)
        {

            CPRODUCTOBE retorno = new CPRODUCTOBE();

            if (dr["ID"] != System.DBNull.Value)
            {
                retorno.IID = (long)(dr["ID"]);
            }

            if (dr["ACTIVO"] != System.DBNull.Value)
            {
                retorno.IACTIVO = (string)(dr["ACTIVO"]);
            }

            if (dr["CREADO"] != System.DBNull.Value)
            {
                retorno.ICREADO = dr.GetDateTime(2); //(object)(dr["CREADO"]);
            }

            if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
            {
                retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
            }

            if (dr["MODIFICADO"] != System.DBNull.Value)
            {
                retorno.IMODIFICADO = dr.GetDateTime(4); //(object)(dr["MODIFICADO"]);
            }

            if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
            {
                retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
            }

            if (dr["CLAVE"] != System.DBNull.Value)
            {
                retorno.ICLAVE = (string)(dr["CLAVE"]);
            }

            if (dr["NOMBRE"] != System.DBNull.Value)
            {
                retorno.INOMBRE = (string)(dr["NOMBRE"]);
            }

            if (dr["DESCRIPCION"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
            }

            if (dr["EAN"] != System.DBNull.Value)
            {
                retorno.IEAN = (string)(dr["EAN"]);
            }

            if (dr["DESCRIPCION1"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
            }

            if (dr["DESCRIPCION2"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
            }

            if (dr["DESCRIPCION3"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
            }

            if (dr["PRECIO1"] != System.DBNull.Value)
            {
                retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
            }

            if (dr["PRECIO2"] != System.DBNull.Value)
            {
                retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
            }

            if (dr["PRECIO3"] != System.DBNull.Value)
            {
                retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
            }

            if (dr["PRECIO4"] != System.DBNull.Value)
            {
                retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
            }

            if (dr["PRECIO5"] != System.DBNull.Value)
            {
                retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
            }

            if (dr["TASAIVAID"] != System.DBNull.Value)
            {
                retorno.ITASAIVAID = (long)(dr["TASAIVAID"]);
            }

            if (dr["TASAIVA"] != System.DBNull.Value)
            {
                retorno.ITASAIVA = (decimal)(dr["TASAIVA"]);
            }

            if (dr["MONEDAID"] != System.DBNull.Value)
            {
                retorno.IMONEDAID = (long)(dr["MONEDAID"]);
            }

            if (dr["COSTOREPOSICION"] != System.DBNull.Value)
            {
                retorno.ICOSTOREPOSICION = (decimal)(dr["COSTOREPOSICION"]);
            }

            if (dr["COSTOULTIMO"] != System.DBNull.Value)
            {
                retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
            }

            if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
            {
                retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
            }

            if (dr["PRODUCTOSUSTITUTOID"] != System.DBNull.Value)
            {
                retorno.IPRODUCTOSUSTITUTOID = (long)(dr["PRODUCTOSUSTITUTOID"]);
            }

            if (dr["MANEJALOTE"] != System.DBNull.Value)
            {
                retorno.IMANEJALOTE = (string)(dr["MANEJALOTE"]);
            }

            if (dr["ESKIT"] != System.DBNull.Value)
            {
                retorno.IESKIT = (string)(dr["ESKIT"]);
            }

            if (dr["IMPRIMIR"] != System.DBNull.Value)
            {
                retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
            }

            if (dr["INVENTARIABLE"] != System.DBNull.Value)
            {
                retorno.IINVENTARIABLE = (string)(dr["INVENTARIABLE"]);
            }

            if (dr["NEGATIVOS"] != System.DBNull.Value)
            {
                retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
            }

            if (dr["LIMITEPRECIO2"] != System.DBNull.Value)
            {
                retorno.ILIMITEPRECIO2 = (decimal)(dr["LIMITEPRECIO2"]);
            }

            if (dr["PRECIOMAXIMOPUBLICO"] != System.DBNull.Value)
            {
                retorno.IPRECIOMAXIMOPUBLICO = (decimal)(dr["PRECIOMAXIMOPUBLICO"]);
            }

            if (dr["FECHACAMBIOPRECIO"] != System.DBNull.Value)
            {
                retorno.IFECHACAMBIOPRECIO = (DateTime)(dr["FECHACAMBIOPRECIO"]);
            }

            if (dr["MANEJASTOCK"] != System.DBNull.Value)
            {
                retorno.IMANEJASTOCK = (string)(dr["MANEJASTOCK"]);
            }

            if (dr["STOCK"] != System.DBNull.Value)
            {
                retorno.ISTOCK = (decimal)(dr["STOCK"]);
            }

            if (dr["PROVEEDOR1ID"] != System.DBNull.Value)
            {
                retorno.IPROVEEDOR1ID = int.Parse(dr["PROVEEDOR1ID"].ToString());
            }

            if (dr["PROVEEDOR2ID"] != System.DBNull.Value)
            {
                retorno.IPROVEEDOR2ID = int.Parse(dr["PROVEEDOR2ID"].ToString());
            }

            if (dr["LINEAID"] != System.DBNull.Value)
            {
                retorno.ILINEAID = int.Parse(dr["LINEAID"].ToString());
            }

            if (dr["MARCAID"] != System.DBNull.Value)
            {
                retorno.IMARCAID = int.Parse(dr["MARCAID"].ToString());
            }

            if (dr["CAMBIARPRECIO"] != System.DBNull.Value)
            {
                retorno.ICAMBIARPRECIO = dr["CAMBIARPRECIO"].ToString();
            }



            if (dr["SUBSTITUTO"] != System.DBNull.Value)
            {
                retorno.ISUBSTITUTO = (string)(dr["SUBSTITUTO"]);
            }

            if (dr["CBARRAS"] != System.DBNull.Value)
            {
                retorno.ICBARRAS = (string)(dr["CBARRAS"]);
            }

            if (dr["CEMPAQUE"] != System.DBNull.Value)
            {
                retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
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
                retorno.IUNIDAD = (string)(dr["UNIDAD"]);
            }

            if (dr["INI_MAYO"] != System.DBNull.Value)
            {
                retorno.IINI_MAYO = (decimal)(dr["INI_MAYO"]);
            }

            if (dr["MAYOKGS"] != System.DBNull.Value)
            {
                retorno.IMAYOKGS = (string)(dr["MAYOKGS"]);
            }

            if (dr["TIPOABC"] != System.DBNull.Value)
            {
                retorno.ITIPOABC = (string)(dr["TIPOABC"]);
            }

            if (dr["COMISION"] != System.DBNull.Value)
            {
                retorno.ICOMISION = (decimal)(dr["COMISION"]);
            }

            if (dr["OFERTA"] != System.DBNull.Value)
            {
                retorno.IOFERTA = (decimal)(dr["OFERTA"]);
            }


            if (dr["EXISTENCIA"] != System.DBNull.Value)
            {
                retorno.IEXISTENCIA = (decimal)(dr["EXISTENCIA"]);
            }


            if (dr["TEXTO1"] != System.DBNull.Value)
            {
                retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
            }

            if (dr["TEXTO2"] != System.DBNull.Value)
            {
                retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
            }

            if (dr["TEXTO3"] != System.DBNull.Value)
            {
                retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
            }

            if (dr["TEXTO4"] != System.DBNull.Value)
            {
                retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
            }

            if (dr["TEXTO5"] != System.DBNull.Value)
            {
                retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
            }

            if (dr["TEXTO6"] != System.DBNull.Value)
            {
                retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
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
                retorno.IFECHA1 = (DateTime)(dr["FECHA1"]);
            }

            if (dr["FECHA2"] != System.DBNull.Value)
            {
                retorno.IFECHA2 = (DateTime)(dr["FECHA2"]);
            }



            if (dr["ESPRODUCTOPADRE"] != System.DBNull.Value)
            {
                retorno.IESPRODUCTOPADRE = (string)(dr["ESPRODUCTOPADRE"]);
            }

            if (dr["ESSUBPRODUCTO"] != System.DBNull.Value)
            {
                retorno.IESSUBPRODUCTO = (string)(dr["ESSUBPRODUCTO"]);
            }

            if (dr["ESPRODUCTOFINAL"] != System.DBNull.Value)
            {
                retorno.IESPRODUCTOFINAL = (string)(dr["ESPRODUCTOFINAL"]);
            }


            if (dr["TOMARCOMISIONPADRE"] != System.DBNull.Value)
            {
                retorno.ITOMARCOMISIONPADRE = (string)(dr["TOMARCOMISIONPADRE"]);
            }


            if (dr["TOMAROFERTAPADRE"] != System.DBNull.Value)
            {
                retorno.ITOMAROFERTAPADRE = (string)(dr["TOMAROFERTAPADRE"]);
            }



            if (dr["TOMARPRECIOPADRE"] != System.DBNull.Value)
            {
                retorno.ITOMARPRECIOPADRE = (string)(dr["TOMARPRECIOPADRE"]);
            }


            if (dr["DESCRIPCION_COMODIN"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION_COMODIN = (string)(dr["DESCRIPCION_COMODIN"]);
            }

            if (dr["CUENTAPREDIAL"] != System.DBNull.Value)
            {
                retorno.ICUENTAPREDIAL = (string)(dr["CUENTAPREDIAL"]);
            }
            if (dr["IMAGEN"] != System.DBNull.Value)
            {
                retorno.IIMAGEN = (string)(dr["IMAGEN"]);
            }


            if (dr["TASAIEPS"] != System.DBNull.Value)
            {
                retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
            }

            if (dr["TASAIMPUESTO"] != System.DBNull.Value)
            {
                retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
            }

            if (dr["MINUTILIDAD"] != System.DBNull.Value)
            {
                retorno.IMINUTILIDAD = (decimal)(dr["MINUTILIDAD"]);
            }

            if (dr["SPRECIO1"] != System.DBNull.Value)
            {
                retorno.ISPRECIO1 = (decimal)(dr["SPRECIO1"]);
            }

            if (dr["SPRECIO2"] != System.DBNull.Value)
            {
                retorno.ISPRECIO2 = (decimal)(dr["SPRECIO2"]);
            }

            if (dr["SPRECIO3"] != System.DBNull.Value)
            {
                retorno.ISPRECIO3 = (decimal)(dr["SPRECIO3"]);
            }

            if (dr["SPRECIO4"] != System.DBNull.Value)
            {
                retorno.ISPRECIO4 = (decimal)(dr["SPRECIO4"]);
            }

            if (dr["SPRECIO5"] != System.DBNull.Value)
            {
                retorno.ISPRECIO5 = (decimal)(dr["SPRECIO5"]);
            }


            if (dr["DESCUENTO"] != System.DBNull.Value)
            {
                retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
            }


            if (dr["REQUIERERECETA"] != System.DBNull.Value)
            {
                retorno.IESKIT = (string)(dr["ESKIT"]);
            }


            if (dr["PRECIOSUGERIDO"] != System.DBNull.Value)
            {
                retorno.IPRECIOSUGERIDO = (decimal)(dr["PRECIOSUGERIDO"]);
            }



            if (dr["ENPROCESOPARTESSALIDA"] != System.DBNull.Value)
            {
                retorno.IENPROCESOPARTESSALIDA = (decimal)(dr["ENPROCESOPARTESSALIDA"]);
            }

            if (dr["PRECIOTOPE"] != System.DBNull.Value)
            {
                retorno.IPRECIOTOPE = (decimal)(dr["PRECIOTOPE"]);
            }
            if (dr["STOCKMAX"] != System.DBNull.Value)
            {
                retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
            }

            if (dr["SURTIRPORCAJA"] != System.DBNull.Value)
            {
                retorno.ISURTIRPORCAJA = (string)(dr["SURTIRPORCAJA"]);
            }
            if (dr["PRECIOMAT"] != System.DBNull.Value)
            {
                retorno.IPRECIOMAT = (string)(dr["PRECIOMAT"]);
            }
            if (dr["PLUG"] != System.DBNull.Value)
            {
                retorno.IPLUG = (string)(dr["PLUG"]);
            }


            if (dr["EMIDAPRODUCTOID"] != System.DBNull.Value)
            {
                retorno.IEMIDAPRODUCTOID = (long)(dr["EMIDAPRODUCTOID"]);
            }

            if (dr["EMIDAID"] != System.DBNull.Value)
            {
                retorno.IEMIDAID = (string)(dr["EMIDAID"]);
            }

            if (dr["MENUDEO"] != System.DBNull.Value)
            {
                retorno.IMENUDEO = (decimal)(dr["MENUDEO"]);
            }

            if (dr["CONTENIDOID"] != System.DBNull.Value)
            {
                retorno.ICONTENIDOID = (long)(dr["CONTENIDOID"]);
            }

            if (dr["CONTENIDOVALOR"] != System.DBNull.Value)
            {
                retorno.ICONTENIDOVALOR = (decimal)(dr["CONTENIDOVALOR"]);
            }

            if (dr["CLASIFICAID"] != System.DBNull.Value)
            {
                retorno.ICLASIFICAID = (long)(dr["CLASIFICAID"]);
            }

            if (dr["UNIDAD2"] != System.DBNull.Value)
            {
                retorno.IUNIDAD2 = (string)(dr["UNIDAD2"]);
            }

            if (dr["CANTXPIEZA"] != System.DBNull.Value)
            {
                retorno.ICANTXPIEZA = (decimal)(dr["CANTXPIEZA"]);
            }


            if (dr["MANEJALOTEIMPORTADO"] != System.DBNull.Value)
            {
                retorno.IMANEJALOTEIMPORTADO = (string)(dr["MANEJALOTEIMPORTADO"]);
            }

            if (dr["COSTOENDOLAR"] != System.DBNull.Value)
            {
                retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
            }

            if (dr["LOTEIMPORTADOAPLICADO"] != System.DBNull.Value)
            {
                retorno.ILOTEIMPORTADOAPLICADO = (string)(dr["LOTEIMPORTADOAPLICADO"]);
            }

            if (dr["PLAZOID"] != System.DBNull.Value)
            {
                retorno.IPLAZOID = (long)(dr["PLAZOID"]);
            }

            if (dr["ESPRODPROMO"] != System.DBNull.Value)
            {
                retorno.IESPRODPROMO = (string)(dr["ESPRODPROMO"]);
            }

            if (dr["BASEPRODPROMOID"] != System.DBNull.Value)
            {
                retorno.IBASEPRODPROMOID = (long)(dr["BASEPRODPROMOID"]);
            }

            if (dr["VIGENCIAPRODPROMO"] != System.DBNull.Value)
            {
                retorno.IVIGENCIAPRODPROMO = (DateTime)(dr["VIGENCIAPRODPROMO"]);
            }

            if (dr["SAT_PRODUCTOSERVICIOID"] != System.DBNull.Value)
            {
                retorno.ISAT_PRODUCTOSERVICIOID = (long)(dr["SAT_PRODUCTOSERVICIOID"]);
            }

            if (dr["VIGENCIAPRODKIT"] != System.DBNull.Value)
            {
                retorno.IVIGENCIAPRODKIT = (DateTime)(dr["VIGENCIAPRODKIT"]);
            }
            if (dr["KITTIENEVIG"] != System.DBNull.Value)
            {
                retorno.IKITTIENEVIG = (string)(dr["KITTIENEVIG"]);
            }


            if (dr["TASAIVAEXT"] != System.DBNull.Value)
            {
                retorno.ITASAIVAEXT = (decimal)(dr["TASAIVAEXT"]);
            }
            if (dr["TASAIEPSEXT"] != System.DBNull.Value)
            {
                retorno.ITASAIEPSEXT = (decimal)(dr["TASAIEPSEXT"]);
            }
            if (dr["TASAIMPEXT"] != System.DBNull.Value)
            {
                retorno.ITASAIMPEXT = (decimal)(dr["TASAIMPEXT"]);
            }

            if (dr["VALXSUC"] != System.DBNull.Value)
            {
                retorno.IVALXSUC = (string)(dr["VALXSUC"]);
            }


            if (dr["STOCKMINCAJA"] != System.DBNull.Value)
            {
                retorno.ISTOCKMINCAJA = (decimal)(dr["STOCKMINCAJA"]);
            }

            if (dr["STOCKMAXCAJA"] != System.DBNull.Value)
            {
                retorno.ISTOCKMAXCAJA = (decimal)(dr["STOCKMAXCAJA"]);
            }


            if (dr["STOCKMINPIEZA"] != System.DBNull.Value)
            {
                retorno.ISTOCKMINPIEZA = (decimal)(dr["STOCKMINPIEZA"]);
            }

            if (dr["STOCKMAXPIEZA"] != System.DBNull.Value)
            {
                retorno.ISTOCKMAXPIEZA = (decimal)(dr["STOCKMAXPIEZA"]);
            }


            if (dr["DESCTOPE"] != System.DBNull.Value)
            {
                retorno.IDESCTOPE = (decimal)(dr["DESCTOPE"]);
            }
            if (dr["MARGEN"] != System.DBNull.Value)
            {
                retorno.IMARGEN = (decimal)(dr["MARGEN"]);
            }

            if (dr["DESCPES"] != System.DBNull.Value)
            {
                retorno.IDESCPES = (decimal)(dr["DESCPES"]);
            }

            if (dr["KITIMPFIJO"] != System.DBNull.Value)
            {
                retorno.IKITIMPFIJO = (string)(dr["KITIMPFIJO"]);
            }


            if (dr["PORCUTILPRECIO1"] != System.DBNull.Value)
            {
                retorno.IPORCUTILPRECIO1 = (decimal)(dr["PORCUTILPRECIO1"]);
            }

            if (dr["PORCUTILPRECIO2"] != System.DBNull.Value)
            {
                retorno.IPORCUTILPRECIO2 = (decimal)(dr["PORCUTILPRECIO2"]);
            }

            if (dr["PORCUTILPRECIO3"] != System.DBNull.Value)
            {
                retorno.IPORCUTILPRECIO3 = (decimal)(dr["PORCUTILPRECIO3"]);
            }

            if (dr["PORCUTILPRECIO4"] != System.DBNull.Value)
            {
                retorno.IPORCUTILPRECIO4 = (decimal)(dr["PORCUTILPRECIO4"]);
            }

            if (dr["PORCUTILPRECIO5"] != System.DBNull.Value)
            {
                retorno.IPORCUTILPRECIO5 = (decimal)(dr["PORCUTILPRECIO5"]);
            }


            if (dr["IMPRIMIRCOMANDA"] != System.DBNull.Value)
            {
                retorno.IIMPRIMIRCOMANDA = (string)(dr["IMPRIMIRCOMANDA"]);
            }


            if (dr["LISTAPRECMEDIOMAYID"] != System.DBNull.Value)
            {
                retorno.ILISTAPRECMEDIOMAYID = (long)(dr["LISTAPRECMEDIOMAYID"]);
            }

            if (dr["LISTAPRECMAYOREOID"] != System.DBNull.Value)
            {
                retorno.ILISTAPRECMAYOREOID = (long)(dr["LISTAPRECMAYOREOID"]);
            }

            if (dr["CANTMEDIOMAY"] != System.DBNull.Value)
            {
                retorno.ICANTMEDIOMAY = (decimal)(dr["CANTMEDIOMAY"]);
            }

            if (dr["CANTMAYOREO"] != System.DBNull.Value)
            {
                retorno.ICANTMAYOREO = (decimal)(dr["CANTMAYOREO"]);
            }



            if (dr["SAT_TIPOEMBALAJEID"] != System.DBNull.Value)
            {
                retorno.ISAT_TIPOEMBALAJEID = (long)(dr["SAT_TIPOEMBALAJEID"]);
            }

            if (dr["SAT_CLAVEUNIDADPESOID"] != System.DBNull.Value)
            {
                retorno.ISAT_CLAVEUNIDADPESOID = (long)(dr["SAT_CLAVEUNIDADPESOID"]);
            }

            if (dr["PESO"] != System.DBNull.Value)
            {
                retorno.IPESO = (decimal)(dr["PESO"]);
            }

            if (dr["ESPELIGROSO"] != System.DBNull.Value)
            {
                retorno.IESPELIGROSO = (string)(dr["ESPELIGROSO"]);
            }

            if (dr["SAT_MATPELIGROSOID"] != System.DBNull.Value)
            {
                retorno.ISAT_MATPELIGROSOID = (long)(dr["SAT_MATPELIGROSOID"]);
            }

            if (dr["ESOFERTA"] != System.DBNull.Value)
            {
                retorno.IESOFERTA = (string)(dr["ESOFERTA"]);
            }
            return retorno;
        }






        public bool BorrarDesactivarPRODUCTOD(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"PRODUCTO_DELETE";

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
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
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

        public bool CambiarClaveSAT(long claveSAT, long productoId, FbTransaction st)
        {
            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;
            auxPar = new FbParameter("@CLAVE_SAT", FbDbType.Char);
            auxPar.Value = claveSAT;
            parts.Add(auxPar);
            auxPar = new FbParameter("@PRODUCTO_ID", FbDbType.Char);
            auxPar.Value = productoId;
            parts.Add(auxPar);
            try
            {               
                string commandText = @"
                UPDATE PRODUCTO SET SAT_PRODUCTOSERVICIOID = @CLAVE_SAT WHERE ID = @PRODUCTO_ID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CambiarStockPRODUCTO(CPRODUCTOBE oCPRODUCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@MANEJASTOCK", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IMANEJASTOCK"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IMANEJASTOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SURTIRPORCAJA", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["ISURTIRPORCAJA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISURTIRPORCAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMAT", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IPRECIOMAT"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@STOCK", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCK"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCK;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMAX", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCKMAX"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCKMAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMINCAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCKMINCAJA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCKMINCAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMAXCAJA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCKMAXCAJA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCKMAXCAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMINPIEZA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCKMINPIEZA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCKMINPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMAXPIEZA", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["ISTOCKMAXPIEZA"])
                {
                    auxPar.Value = oCPRODUCTONuevo.ISTOCKMAXPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                update  PRODUCTO
                set
                MANEJASTOCK = @MANEJASTOCK,
                STOCK = @STOCK,
                STOCKMAX = @STOCKMAX,
                SURTIRPORCAJA = @SURTIRPORCAJA,
                STOCKMINCAJA = @STOCKMINCAJA,
                STOCKMAXCAJA = @STOCKMAXCAJA,
                STOCKMINPIEZA = @STOCKMINPIEZA,
                STOCKMAXPIEZA = @STOCKMAXPIEZA
                where 
                ID=@ID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarActivoPRODUCTO(CPRODUCTOBE oCPRODUCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                update  PRODUCTO
                set
                ACTIVO = @ACTIVO
                where 
                ID=@ID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool InactivarProductosKitValidosXSuc( FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                



                string commandText = @"
                update  PRODUCTO
                set
                ACTIVO = 'N'
                where COALESCE(VALXSUC,'N') = 'S' AND COALESCE(ESKIT, 'S')  = 'S';";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarDatosPromocionPRODUCTO(CPRODUCTOBE oCPRODUCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ESPRODPROMO", FbDbType.Char);
                if (!(bool)oCPRODUCTONuevo.isnull["IESPRODPROMO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IESPRODPROMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BASEPRODPROMOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IBASEPRODPROMOID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IBASEPRODPROMOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAPRODPROMO", FbDbType.Date);
                if (!(bool)oCPRODUCTONuevo.isnull["IVIGENCIAPRODPROMO"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IVIGENCIAPRODPROMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                update  PRODUCTO
                set
                ESPRODPROMO = @ESPRODPROMO,
                BASEPRODPROMOID = @BASEPRODPROMOID,
                VIGENCIAPRODPROMO = @VIGENCIAPRODPROMO
                where 
                ID=@ID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarImagenPRODUCTO(CPRODUCTOBE oCPRODUCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IMAGEN", FbDbType.Numeric);
                if (!(bool)oCPRODUCTONuevo.isnull["IIMAGEN"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                update  PRODUCTO
                set
                IMAGEN = @IMAGEN
                where 
                ID=@ID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public decimal GetExistenciaByAlmacen(long productoId, long almacenId, FbTransaction st)
        {


            decimal retorno = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select sum(cantidad) cantidad from INVENTARIO where productoid = @PRODUCTOID AND ALMACENID = @ALMACENID ";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = almacenId;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["CANTIDAD"]);
                    }


                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);



                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }



        }



        public decimal GetProcesoSalidaByAlmacen(long productoId, long almacenId, FbTransaction st)
        {


            decimal retorno = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select sum(ENPROCESODESALIDA) cantidad from PRODUCTOALMACEN where productoid = @PRODUCTOID AND ALMACENID = @ALMACENID ";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = almacenId;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["CANTIDAD"]);
                    }


                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }



        }

        public DataTable getProductoNombresConExis(bool bMovil)
        {
            DataSet retorno;
            try
            {

                string strText = "";
                if (bMovil)
                {
                    strText = @"select descripcion1, clave,  '' as adicional, '' existenciastr 
                          from producto 
                          order by descripcion1";

                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text,
                        strText);
                }
                else
                {
                    strText = @"select descripcion1, clave, '' as adicional,
                        case
                        when p.inventariable<> 'S' then
                                  cast(     P.EXISTENCIA  as varchar(20))
                        when  P.unidad = 'KG' then
                                cast(     P.EXISTENCIA as varchar(20) ) || (case when P.EXISTENCIA  >= 1 then ' KG' else ' GM' end)
                        when  ( coalesce(P.pzacaja,0) = 0  ) then
                                cast(     P.EXISTENCIA  as varchar(20)) || ' PZAS'
                        when P.EXISTENCIA > 1000000.00 then
                                 'Mas de 1 millon'
                        else
                                cast(trunc(coalesce(     P.EXISTENCIA   ,0)/coalesce(P.pzacaja,1)) as varchar(20)) || ' cajas ' ||  cast(mod(coalesce(    P.EXISTENCIA   ,0),coalesce(P.pzacaja,1)) as varchar(10)) || ' piezas '
                        end
                        existenciastr
                        from producto p
                        where p.inventariable<> 'S' or p.existencia> 0 or p.negativos = 'S' or p.eskit = 'S' 
                        order by descripcion1";
                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text,
                     strText);
                }

                return retorno.Tables[0];
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;

            }
        }



        public DataTable getProductoNombresConExisChanged(bool bMovil, DateTime fechaLastLlenadoAutocompleteProdConExis)
        {
            DataSet retorno;
            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@fechaLastLlenadoAutocompleteProdConExis", FbDbType.TimeStamp);
                auxPar.Value = fechaLastLlenadoAutocompleteProdConExis;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (bMovil)
                {
                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text,
                        @"select descripcion1, clave,  adicional, '' existenciastr, p.inventariable, p.negativos, p.existencia 
                          from producto p
                          where p.ultimocambioexistencia > @fechaLastLlenadoAutocompleteProdConExis
                          order by descripcion1", arParms);
                }
                else
                {
                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text,
                      @"select descripcion1, clave, '' as adicional, 
                        case
                        when p.inventariable<> 'S' then
                               cast(     P.EXISTENCIA  as varchar(20)) 
                        when  P.unidad = 'KG' then
                        cast(     P.EXISTENCIA as varchar(20) ) || (case when P.EXISTENCIA  >= 1 then ' KG' else ' GM' end)
                        when  ( coalesce(P.pzacaja,0) = 0 ) then
                        cast(     P.EXISTENCIA  as varchar(20)) || ' PZAS'
                        else
                        cast(trunc(coalesce(     P.EXISTENCIA   ,0)/coalesce(P.pzacaja,1)) as varchar(20)) || ' cajas ' ||  cast(mod(coalesce(    P.EXISTENCIA   ,0),coalesce(P.pzacaja,1)) as varchar(10)) || ' piezas '
                        end
                        existenciastr, p.inventariable, p.negativos, p.existencia
                        from producto p
                        where p.ultimocambioexistencia > @fechaLastLlenadoAutocompleteProdConExis  
                        order by descripcion1", arParms);
                }

                return retorno.Tables[0];
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;

            }
        }


        

        public DataTable getProductosTipoBusqueda2(string entradaBusqueda, bool soloConExistencia)
        {
            DataSet retorno;
            try
            {
                string bufferBusquedaText = entradaBusqueda;
                if (bufferBusquedaText.Contains(" <(("))
                {
                    string[] strSeparators = new string[] { " <((" };

                    string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (strBuffert.Count() > 0)
                        entradaBusqueda = strBuffert[0];
                }


                string[] strSeparatorsEntrada = new string[] { " ", "'"};
                string[] splitIn = entradaBusqueda.Split(strSeparatorsEntrada, StringSplitOptions.RemoveEmptyEntries);
                string subquery = "";

                if(splitIn.Length <= 0)
                {
                    return null;
                }
                else
                {
                    int countSplit = 0;

                    if(soloConExistencia)
                    {

                        subquery += " ( (COALESCE(EXISTENCIA, 0) > 0 ) or (COALESCE(NEGATIVOS,'N') = 'S') or (COALESCE(ESKIT,'N') = 'S' AND (COALESCE(KITTIENEVIG,'N') = 'N' OR COALESCE(VIGENCIAPRODKIT, CURRENT_DATE) >= CURRENT_DATE ) )  ) ";
                        countSplit++;
                    }


                    foreach(string itemKey in splitIn)
                    {
                        if(countSplit == 0)
                        {
                            subquery += "upper(DESCRIPCION1) like '%" + itemKey + "%' ";
                        }
                        else if(countSplit == splitIn.Length-1 && itemKey.Contains("$"))
                        {
                            break;
                        }
                        else
                        {
                            if(itemKey.Length > 2 || itemKey.Any(char.IsDigit))
                                subquery += "AND upper(DESCRIPCION1) like '%" + itemKey + "%' ";
                        }
                        countSplit++;
                    }
                }

                

                //subquery = "DESCRIPCION1 like '%Recarga%' AND DESCRIPCION1 like '%Movistar%'";

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

               /* auxPar = new FbParameter("@fechaLastLlenadoAutocompleteProdConExis", FbDbType.TimeStamp);
                auxPar.Value = fechaLastLlenadoAutocompleteProdConExis;
                parts.Add(auxPar);*/


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string strQuery = @"SELECT ID, CLAVE, DESCRIPCION1, DESCRIPCION2, PRECIO1, LIMITEPRECIO2, PRECIO2, 
EAN, EXISTENCIA, PROVEEDOR, TASAIVA, PRECIO_MAS_IVA, DESCONTINUADO, EXISTENCIAAPARTADO, TEXTO1, TEXTO2, TEXTO3,
TEXTO4, TEXTO5, TEXTO6, NUMERO1, NUMERO2, NUMERO3, NUMERO4, FECHA1, FECHA2, ENPROCESODESALIDA, PRECIO_MAS_IMPUESTO, 
TASAIEPS, 0.00 AS EXISTENCIAALMACEN1, 0.00 AS EXISTENCIAALMACEN2, 0.00 AS EXISTENCIAALMACEN3, PRECIO3, PRECIO4, 
PRECIO5, PRECIO2_MAS_IMPUESTO, PRECIO3_MAS_IMPUESTO, PRECIO4_MAS_IMPUESTO, PRECIO5_MAS_IMPUESTO, PRECIOCAJA_MAS_IMPUESTO, 	                        
PRECIOMEDIOMAYOREOCONTARJETA, PRECIOMAYOREOCONTARJETA, U_EMPAQUE, PZACAJA, CAJAS, PIEZAS FROM  PRODUCTOS
where " + subquery + "";

                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text,
                     strQuery, arParms);
                

                return retorno.Tables[0];
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;

            }
        }

        public DataTable getProductoNombres(bool bMovil)
        {
            DataSet retorno;
            try
            {
                if (bMovil)
                {
                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, "select descripcion1, clave,  adicional from productoautocomplete order by descripcion1");
                }
                else
                {
                    retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, "select descripcion1, clave, '' as adicional from producto order by descripcion1");
                }
                return retorno.Tables[0];
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




        public bool CambiarExistenciaMovilPRODUCTOD(long productoId, decimal cantidad, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = cantidad;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"MOVIL_SETEXISTENCIA";

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
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
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





        public bool CambiarFlagHistorialMovilPRODUCTOD(long doctoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"MOVIL_UPDATEPRODHISTFLAG";

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
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
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





        public decimal GetCountEnProcesoPartesSalida(FbTransaction st)
        {


            decimal retorno = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select sum(ENPROCESOPARTESSALIDA) cantidad from PRODUCTO where ESKIT = 'S' ";



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["CANTIDAD"]);
                    }


                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);



                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }



        }



        public bool DESACTIVARTODOSLOSPRODUCTO(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;






                string commandText = @"  UPDATE PRODUCTO SET ACTIVO = 'N'";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public decimal GET_PRECIOMINIMO(long productoId, long personaId, FbTransaction st)
        {


            decimal retorno = 0;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"GET_PRECIOMINIMO";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = personaId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMINIMO", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);






                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, CmdTxt, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, CmdTxt, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    retorno = (decimal)arParms[arParms.Length - 1].Value;
                }




                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }



        }




        public List<CPRODUCTOSUCURSALBE> seleccionarSUCURSALESxPRODUCTO(CPRODUCTOBE oCPRODUCTO, FbTransaction st)
        {
            List<CPRODUCTOSUCURSALBE> productoSucursales = new List<CPRODUCTOSUCURSALBE>();

            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT * FROM  PRODUCTOSUCURSAL where PRODUCTOID = @PRODUCTOID;";

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);


                while (dr.Read())
                {
                    CPRODUCTOSUCURSALBE promSuc = new CPRODUCTOSUCURSALBE();

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        promSuc.IPRODUCTOID = (long)dr["PRODUCTOID"];
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        promSuc.ISUCURSALID = (long)dr["SUCURSALID"];
                    }

                    productoSucursales.Add(promSuc);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return productoSucursales;

            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                this.iComentario = ex.Message + ex.StackTrace;

                return null;
            }

        }



        public CPRODUCTOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
