

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;

namespace iPosData
{



    public class CKITDEFINICIOND
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


        public CKITDEFINICIONBE AgregarKITDEFINICIOND(CKITDEFINICIONBE oCKITDEFINICION, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCKITDEFINICION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCKITDEFINICION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRODUCTOKITID", FbDbType.BigInt);
                if (!(bool)oCKITDEFINICION.isnull["IPRODUCTOKITID"])
                {
                    auxPar.Value = oCKITDEFINICION.IPRODUCTOKITID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOPARTEID", FbDbType.BigInt);
                if (!(bool)oCKITDEFINICION.isnull["IPRODUCTOPARTEID"])
                {
                    auxPar.Value = oCKITDEFINICION.IPRODUCTOPARTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFINICION.isnull["ICANTIDADPARTE"])
                {
                    auxPar.Value = oCKITDEFINICION.ICANTIDADPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOKITCLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFINICION.isnull["IPRODUCTOKITCLAVE"])
                {
                    auxPar.Value = oCKITDEFINICION.IPRODUCTOKITCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOPARTECLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFINICION.isnull["IPRODUCTOPARTECLAVE"])
                {
                    auxPar.Value = oCKITDEFINICION.IPRODUCTOPARTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COSTOPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFINICION.isnull["ICOSTOPARTE"])
                {
                    auxPar.Value = oCKITDEFINICION.ICOSTOPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                /*string commandText = @"
        INSERT INTO KITDEFINICION
      (
    

ACTIVO,

PRODUCTOKITID,

PRODUCTOPARTEID,

CANTIDADPARTE,

PRODUCTOKITCLAVE,

PRODUCTOPARTECLAVE,

COSTOPARTE
         )

Values (

@ACTIVO,

@PRODUCTOKITID,

@PRODUCTOPARTEID,

@CANTIDADPARTE,

@PRODUCTOKITCLAVE,

@PRODUCTOPARTECLAVE,

@COSTOPARTE
); ";*/

                string commandText = "KIT_DEFINICIONINSERT";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);






                return oCKITDEFINICION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarKITDEFINICIOND(CKITDEFINICIONBE oCKITDEFINICION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCKITDEFINICION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from KITDEFINICION
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


        [AutoComplete]
        public bool CambiarKITDEFINICIOND(CKITDEFINICIONBE oCKITDEFINICIONNuevo, CKITDEFINICIONBE oCKITDEFINICIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOKITID", FbDbType.BigInt);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["IPRODUCTOKITID"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.IPRODUCTOKITID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOPARTEID", FbDbType.BigInt);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["IPRODUCTOPARTEID"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.IPRODUCTOPARTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["ICANTIDADPARTE"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.ICANTIDADPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOKITCLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["IPRODUCTOKITCLAVE"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.IPRODUCTOKITCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOPARTECLAVE", FbDbType.VarChar);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["IPRODUCTOPARTECLAVE"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.IPRODUCTOPARTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COSTOPARTE", FbDbType.Numeric);
                if (!(bool)oCKITDEFINICIONNuevo.isnull["ICOSTOPARTE"])
                {
                    auxPar.Value = oCKITDEFINICIONNuevo.ICOSTOPARTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCKITDEFINICIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCKITDEFINICIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  KITDEFINICION
  set


ACTIVO=@ACTIVO,

PRODUCTOKITID=@PRODUCTOKITID,

PRODUCTOPARTEID=@PRODUCTOPARTEID,

CANTIDADPARTE=@CANTIDADPARTE,

PRODUCTOKITCLAVE=@PRODUCTOKITCLAVE,

PRODUCTOPARTECLAVE=@PRODUCTOPARTECLAVE,

COSTOPARTE=@COSTOPARTE
  where 

ID=@IDAnt
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


        [AutoComplete]
        public CKITDEFINICIONBE seleccionarKITDEFINICION(CKITDEFINICIONBE oCKITDEFINICION, FbTransaction st)
        {




            CKITDEFINICIONBE retorno = new CKITDEFINICIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from KITDEFINICION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCKITDEFINICION.IID;
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
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["PRODUCTOKITID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOKITID = (long)(dr["PRODUCTOKITID"]);
                    }

                    if (dr["PRODUCTOPARTEID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOPARTEID = (long)(dr["PRODUCTOPARTEID"]);
                    }

                    if (dr["CANTIDADPARTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADPARTE = (decimal)(dr["CANTIDADPARTE"]);
                    }

                    if (dr["PRODUCTOKITCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOKITCLAVE = (string)(dr["PRODUCTOKITCLAVE"]);
                    }

                    if (dr["PRODUCTOPARTECLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOPARTECLAVE = (string)(dr["PRODUCTOPARTECLAVE"]);
                    }
                    if (dr["COSTOPARTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPARTE = (decimal)(dr["COSTOPARTE"]);
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
        public DataSet enlistarKITDEFINICION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_KITDEFINICION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoKITDEFINICION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_KITDEFINICION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteKITDEFINICION(CKITDEFINICIONBE oCKITDEFINICION, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCKITDEFINICION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from KITDEFINICION where

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


        public decimal getSumaCostosPartes(long productoKitId, FbTransaction st)
        {
            decimal dRetorno = 0;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select sum (ROUND(KITDEFINICION.COSTOPARTE * KITDEFINICION.CANTIDADPARTE, 2) 
                         + ROUND(KITDEFINICION.COSTOPARTE * KITDEFINICION.CANTIDADPARTE * (CASE WHEN PARAMETRO.DESGLOSEIEPS = 'S' THEN PRODUCTO.TASAIEPS / 100 ELSE
                          0 END), 2) 
                         + ROUND((KITDEFINICION.COSTOPARTE * KITDEFINICION.CANTIDADPARTE * (CASE WHEN PARAMETRO.DESGLOSEIEPS = 'S' THEN 1 + (PRODUCTO.TASAIEPS / 100)
                          ELSE 1 END)) * (PRODUCTO.TASAIVA / 100), 2)) AS COSTOPARTES
                                      from KITDEFINICION INNER JOIN PRODUCTO ON KITDEFINICION.PRODUCTOPARTEID = PRODUCTO.ID
                                        INNER JOIN PARAMETRO ON 1 = 1
                                        where KITDEFINICION.PRODUCTOKITID = @PRODUCTOKITID  ";


                auxPar = new FbParameter("@PRODUCTOKITID", FbDbType.BigInt);
                auxPar.Value = productoKitId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["COSTOPARTES"] != System.DBNull.Value)
                    {
                        dRetorno = (decimal)(dr["COSTOPARTES"]);
                    }

                }
                else
                {
                    dRetorno = 0;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);




                return dRetorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }

        }





        public bool KIT_TOTALIZARIMPUESTOS(long productoId, ref long tasaivaid, ref decimal tasaiva, ref decimal tasaieps, ref decimal tasaimpuesto, ref decimal sumasinimpuesto, ref decimal sumaconimpuesto, ref decimal sumaivaparte, ref decimal sumaiepsparte, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOKITID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUMAIVAPARTE", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUMAIEPSPARTE", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@PORCENTAJEIEPS", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCENTAJEIVA", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PORCENTAJEIMPUESTO", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@TASAIVAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUMACOSTOTOTALSINIMPUESTO", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUMACOSTOTOTALCONIMPUESTO", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"KIT_TOTALIZARIMPUESTOS";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    sumaconimpuesto = (decimal)arParms[arParms.Length - 2].Value;

                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    sumasinimpuesto = (decimal)arParms[arParms.Length - 3].Value;

                }


                if (!(arParms[arParms.Length - 4].Value == System.DBNull.Value))
                {
                    tasaivaid = (long)arParms[arParms.Length - 4].Value;

                }

                if (!(arParms[arParms.Length - 5].Value == System.DBNull.Value))
                {
                    tasaimpuesto = (decimal)arParms[arParms.Length - 5].Value;

                }

                if (!(arParms[arParms.Length - 6].Value == System.DBNull.Value))
                {
                    tasaiva = (decimal)arParms[arParms.Length - 6].Value;

                }

                if (!(arParms[arParms.Length - 7].Value == System.DBNull.Value))
                {
                    tasaieps = (decimal)arParms[arParms.Length - 7].Value;

                }


                if (!(arParms[arParms.Length - 8].Value == System.DBNull.Value))
                {
                    sumaiepsparte = (decimal)arParms[arParms.Length - 8].Value;

                }


                if (!(arParms[arParms.Length - 9].Value == System.DBNull.Value))
                {
                    sumaivaparte = (decimal)arParms[arParms.Length - 9].Value;

                }



                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public CKITDEFINICIONBE AgregarKITDEFINICION(CKITDEFINICIONBE oCKITDEFINICION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteKITDEFINICION(oCKITDEFINICION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El KITDEFINICION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarKITDEFINICIOND(oCKITDEFINICION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarKITDEFINICION(CKITDEFINICIONBE oCKITDEFINICION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteKITDEFINICION(oCKITDEFINICION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El KITDEFINICION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarKITDEFINICIOND(oCKITDEFINICION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarKITDEFINICION(CKITDEFINICIONBE oCKITDEFINICIONNuevo, CKITDEFINICIONBE oCKITDEFINICIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteKITDEFINICION(oCKITDEFINICIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El KITDEFINICION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarKITDEFINICIOND(oCKITDEFINICIONNuevo, oCKITDEFINICIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool KIT_DESAMBLARNOVIGENTES(long lVendedorId, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = lVendedorId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"KIT_DESAMBLARNOVIGENTES";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), null);
                       this.iComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = "e.Message + e.StackTrace";
                return false;
            }

        }

        public CKITDEFINICIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
