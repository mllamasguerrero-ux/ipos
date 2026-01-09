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


    public class CSTOCKALMACEND
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

        public CSTOCKALMACENBE AgregarSTOCKALMACEND(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSTOCKALMACEN.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSTOCKALMACEN.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACEN.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSTOCKALMACEN.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACEN.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSTOCKALMACEN.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACEN.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCSTOCKALMACEN.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACEN.isnull["IALMACENID"])
                {
                    auxPar.Value = oCSTOCKALMACEN.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMIN", FbDbType.Numeric);
                if (!(bool)oCSTOCKALMACEN.isnull["ISTOCKMIN"])
                {
                    auxPar.Value = oCSTOCKALMACEN.ISTOCKMIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STOCKMAX", FbDbType.Numeric);
                if (!(bool)oCSTOCKALMACEN.isnull["ISTOCKMAX"])
                {
                    auxPar.Value = oCSTOCKALMACEN.ISTOCKMAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO STOCKALMACEN
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PRODUCTOID,

ALMACENID,

STOCKMIN,

STOCKMAX
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PRODUCTOID,

@ALMACENID,

@STOCKMIN,

@STOCKMAX
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSTOCKALMACEN;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarSTOCKALMACEND(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from STOCKALMACEN
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
        public bool CambiarSTOCKALMACEND(CSTOCKALMACENBE oCSTOCKALMACENNuevo, CSTOCKALMACENBE oCSTOCKALMACENAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSTOCKALMACENNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSTOCKALMACENNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACENNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSTOCKALMACENNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACENNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCSTOCKALMACENNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACENNuevo.isnull["IALMACENID"])
                {
                    auxPar.Value = oCSTOCKALMACENNuevo.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@STOCKMIN", FbDbType.Numeric);
                if (!(bool)oCSTOCKALMACENNuevo.isnull["ISTOCKMIN"])
                {
                    auxPar.Value = oCSTOCKALMACENNuevo.ISTOCKMIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@STOCKMAX", FbDbType.Numeric);
                if (!(bool)oCSTOCKALMACENNuevo.isnull["ISTOCKMAX"])
                {
                    auxPar.Value = oCSTOCKALMACENNuevo.ISTOCKMAX;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSTOCKALMACENAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSTOCKALMACENAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  STOCKALMACEN
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PRODUCTOID=@PRODUCTOID,

ALMACENID=@ALMACENID,

STOCKMIN=@STOCKMIN,

STOCKMAX=@STOCKMAX
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

        public CSTOCKALMACENBE seleccionarSTOCKALMACEN(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {




            CSTOCKALMACENBE retorno = new CSTOCKALMACENBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from STOCKALMACEN where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IID;
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

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }

                    if (dr["STOCKMIN"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMIN = (decimal)(dr["STOCKMIN"]);
                    }

                    if (dr["STOCKMAX"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
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



        public CSTOCKALMACENBE seleccionarSTOCKALMACENByAlmacenIdProductoId(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {




            CSTOCKALMACENBE retorno = new CSTOCKALMACENBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from STOCKALMACEN where
 PRODUCTOID=@PRODUCTOID  AND ALMACENID=@ALMACENID";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IPRODUCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IALMACENID;
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

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }

                    if (dr["STOCKMIN"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMIN = (decimal)(dr["STOCKMIN"]);
                    }

                    if (dr["STOCKMAX"] != System.DBNull.Value)
                    {
                        retorno.ISTOCKMAX = (decimal)(dr["STOCKMAX"]);
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
        public DataSet enlistarSTOCKALMACEN()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_STOCKALMACEN_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoSTOCKALMACEN()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_STOCKALMACEN_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteSTOCKALMACEN(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from STOCKALMACEN where

  ID=@ID  
  );";






                //FbDataReader dr;
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


        public int ExisteSTOCKALMACENXPRODUCTOYALMACEN(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IPRODUCTOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCSTOCKALMACEN.IALMACENID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from STOCKALMACEN where

  PRODUCTOID=@PRODUCTOID AND ALMACENID = @ALMACENID
  );";






                //FbDataReader dr;
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




        public CSTOCKALMACENBE AgregarSTOCKALMACEN(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTOCKALMACEN(oCSTOCKALMACEN, st);
                if (iRes == 1)
                {
                    this.IComentario = "El STOCKALMACEN ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSTOCKALMACEND(oCSTOCKALMACEN, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSTOCKALMACEN(CSTOCKALMACENBE oCSTOCKALMACEN, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTOCKALMACEN(oCSTOCKALMACEN, st);
                if (iRes == 0)
                {
                    this.IComentario = "El STOCKALMACEN no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSTOCKALMACEND(oCSTOCKALMACEN, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSTOCKALMACEN(CSTOCKALMACENBE oCSTOCKALMACENNuevo, CSTOCKALMACENBE oCSTOCKALMACENAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSTOCKALMACEN(oCSTOCKALMACENAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El STOCKALMACEN no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSTOCKALMACEND(oCSTOCKALMACENNuevo, oCSTOCKALMACENAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CSTOCKALMACEND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
