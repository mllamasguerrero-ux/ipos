using ConexionesBD;
using DataLayer.Movil.businessEntity.MOVILANDROID;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessData.MOVILANDROID
{
    public class CPRODDROIDD
    {
        private string iComentario;
        private string sCadenaConexion;
        private List<CPRODDROIDBE> productos;
        private const string conexion = @"User = SYSDBA; 
                                Password = masterkey; 
                                Database = C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\VENMOVDROID.fdb; 
                                DataSource = localhost;";

        public CPRODDROIDD()
        {
            sCadenaConexion = ConexionBD.ConexionString();
            productos = new List<CPRODDROIDBE>();
        }

        public CPRODDROIDD(string conexion)
        {
            sCadenaConexion = conexion;
            productos = new List<CPRODDROIDBE>();
        }

        public string IComentario { get => iComentario; set => iComentario = value; }

        public bool ObtenerRegistros(long doctoId, FbTransaction st)
        {
            FbParameter auxPar;
            ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                sCadenaConexion = ConexionBD.ConexionString();
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
                         BASEPRODPROMO.CLAVE CLAVEBASEPRODPROMO, PRODUCTO.ESPRODPROMO, PRODUCTO.VIGENCIAPRODPROMO, PRODUCTO.VIGENCIAPRODKIT, PRODUCTO.KITTIENEVIG
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


                if (doctoId != 0)
                {
                    string strJoinAdicional = @"WHERE PRODUCTO.ID IN  ( SELECT PRODUCTOFINAL.ID AS PRODUCTOID FROM PRODUCTO PRODUCTOFINAL 
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

                sCadenaConexion = ConexionBD.ConexionString();

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    CPRODDROIDBE prod = new CPRODDROIDBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        prod.Clave = (string)(dr["CLAVE"]);
                    }

                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        prod.Descripcion1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        prod.Descripcion2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        prod.Descripcion3 = dr["DESCRIPCION3"].ToString();
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        prod.Precio1 = float.Parse(dr["PRECIO1"].ToString());
                    }

                    if (dr["EAN"] != System.DBNull.Value)
                    {
                        prod.Ean = dr["EAN"].ToString();
                    }

                    if (dr["ESKIT"] != System.DBNull.Value)
                    {
                        prod.EsKit = dr["ESKIT"].ToString();
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        prod.CBarras = dr["CBARRAS"].ToString();
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        prod.CEmpaque = dr["CEMPAQUE"].ToString();
                    }

                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        prod.PzaCaja = float.Parse(dr["PZACAJA"].ToString());
                    }

                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        prod.UEmpaque = float.Parse(dr["U_EMPAQUE"].ToString());
                    }

                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        prod.Unidad = dr["UNIDAD"].ToString();
                    }               

                    if (dr["EXISTENCIA"] != System.DBNull.Value)
                    {
                        prod.Existencia = float.Parse(dr["EXISTENCIA"].ToString());
                    }

                    productos.Add(prod);
                }

                SqlHelper.CloseReader(dr, pcn);

                return true;
            }
            catch (Exception e)
            {
                SqlHelper.CloseReader(dr, pcn);
                IComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool LimpiarTabla(FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;

                ArrayList parts = new ArrayList();

                string commandText = @"DELETE FROM MPRODDROID;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
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

        public bool InsertarProducto(CPRODDROIDBE producto, FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;

                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = producto.Clave;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = producto.Descripcion1;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = producto.Descripcion2;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = producto.Descripcion3;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO1", FbDbType.VarChar);
                auxPar.Value = producto.Precio1;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_BARRAS", FbDbType.VarChar);
                auxPar.Value = producto.CBarras;
                parts.Add(auxPar);

                auxPar = new FbParameter("@C_EMPAQUE", FbDbType.VarChar);
                auxPar.Value = producto.CEmpaque;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EAN", FbDbType.VarChar);
                auxPar.Value = producto.Ean;
                parts.Add(auxPar);

                auxPar = new FbParameter("@UNIDAD", FbDbType.VarChar);
                auxPar.Value = producto.Unidad;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PZA_CAJA", FbDbType.VarChar);
                auxPar.Value = producto.PzaCaja;
                parts.Add(auxPar);

                auxPar = new FbParameter("@U_EMPAQUE", FbDbType.VarChar);
                auxPar.Value = producto.UEmpaque;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EXISTENCIA", FbDbType.VarChar);
                auxPar.Value = producto.Existencia;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ES_KIT", FbDbType.VarChar);
                auxPar.Value = producto.EsKit;
                parts.Add(auxPar);

                string commandText = @"INSERT INTO MPRODDROID(
                                            CLAVE,
                                            DESCRIPCION1,
                                            DESCRIPCION2,
                                            DESCRIPCION3,
                                            PRECIO1,
                                            C_BARRAS,
                                            C_EMPAQUE,
                                            EAN,
                                            UNIDAD,
                                            PZA_CAJA,
                                            U_EMPAQUE,
                                            EXISTENCIA,
                                            ES_KIT
                                       )
                                       Values(
                                            @CLAVE,
                                            @DESCRIPCION1,
                                            @DESCRIPCION2,
                                            @DESCRIPCION3,
                                            @PRECIO1,
                                            @C_BARRAS,
                                            @C_EMPAQUE,
                                            @EAN,
                                            @UNIDAD,
                                            @PZA_CAJA,
                                            @U_EMPAQUE,
                                            @EXISTENCIA,
                                            @ES_KIT
                                        ); ";

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
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool LlenarTabla(long doctoId)
        {
            FbConnection fbConnection = new FbConnection(conexion);
            FbTransaction fbTransaction = null;
            bool retorno;

            try
            {
                fbConnection.Open();
                fbTransaction = fbConnection.BeginTransaction();

                if (!LimpiarTabla(null))
                    throw new Exception(iComentario);

                ObtenerRegistros(doctoId, null);

                foreach(CPRODDROIDBE prod in productos)
                {
                    if (!InsertarProducto(prod, fbTransaction))
                        throw new Exception(iComentario);
                }

                fbTransaction.Commit();

                retorno = true;
            }
            catch(Exception e)
            {
                fbTransaction.Rollback();
                iComentario = e.Message;
                retorno = false;
            }
            finally
            {
                fbConnection.Close();
            }

            return retorno;
        }
    }
}
