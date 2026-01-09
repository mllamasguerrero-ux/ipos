

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

    [Transaction(TransactionOption.Supported)]


    public class CRECETAD
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


        [AutoComplete]
        public CRECETABE AgregarRECETAD(CRECETABE oCRECETA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCRECETA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCRECETA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CEDULA", FbDbType.VarChar);
                if (!(bool)oCRECETA.isnull["ICEDULA"])
                {
                    auxPar.Value = oCRECETA.ICEDULA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RECETANUMERO", FbDbType.VarChar);
                if (!(bool)oCRECETA.isnull["IRECETANUMERO"])
                {
                    auxPar.Value = oCRECETA.IRECETANUMERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MEDICOID", FbDbType.BigInt);
                if (!(bool)oCRECETA.isnull["IMEDICOID"])
                {
                    auxPar.Value = oCRECETA.IMEDICOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENTAID", FbDbType.BigInt);
                if (!(bool)oCRECETA.isnull["IVENTAID"])
                {
                    auxPar.Value = oCRECETA.IVENTAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCRECETA.isnull["IFOLIO"])
                {
                    auxPar.Value = oCRECETA.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RETENIDA", FbDbType.VarChar);
                if (!(bool)oCRECETA.isnull["IRETENIDA"])
                {
                    auxPar.Value = oCRECETA.IRETENIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO RECETA
      (

NOMBRE,

CEDULA,

RECETANUMERO,

MEDICOID,

VENTAID,

FOLIO,

RETENIDA
         )

Values (

@NOMBRE,

@CEDULA,

@RECETANUMERO,

@MEDICOID,

@VENTAID,

@FOLIO,

@RETENIDA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCRECETA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarRECETAD(CRECETABE oCRECETA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRECETA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from RECETA
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
        public bool CambiarRECETAD(CRECETABE oCRECETANuevo, CRECETABE oCRECETAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCRECETANuevo.isnull["IID"])
                {
                    auxPar.Value = oCRECETANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCRECETANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCRECETANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRECETANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCRECETANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRECETANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCRECETANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCRECETANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCRECETANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CEDULA", FbDbType.VarChar);
                if (!(bool)oCRECETANuevo.isnull["ICEDULA"])
                {
                    auxPar.Value = oCRECETANuevo.ICEDULA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RECETANUMERO", FbDbType.VarChar);
                if (!(bool)oCRECETANuevo.isnull["IRECETANUMERO"])
                {
                    auxPar.Value = oCRECETANuevo.IRECETANUMERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MEDICOID", FbDbType.BigInt);
                if (!(bool)oCRECETANuevo.isnull["IMEDICOID"])
                {
                    auxPar.Value = oCRECETANuevo.IMEDICOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENTAID", FbDbType.BigInt);
                if (!(bool)oCRECETANuevo.isnull["IVENTAID"])
                {
                    auxPar.Value = oCRECETANuevo.IVENTAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCRECETANuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCRECETANuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RETENIDA", FbDbType.VarChar);
                if (!(bool)oCRECETANuevo.isnull["IRETENIDA"])
                {
                    auxPar.Value = oCRECETANuevo.IRETENIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCRECETAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCRECETAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  RECETA
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

NOMBRE=@NOMBRE,

CEDULA=@CEDULA,

RECETANUMERO=@RECETANUMERO,

MEDICOID=@MEDICOID,

VENTAID=@VENTAID,

FOLIO = @FOLIO,

RETENIDA = @RETENIDA
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
        public CRECETABE seleccionarRECETA(CRECETABE oCRECETA, FbTransaction st)
        {




            CRECETABE retorno = new CRECETABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from RECETA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRECETA.IID;
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

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["CEDULA"] != System.DBNull.Value)
                    {
                        retorno.ICEDULA = (string)(dr["CEDULA"]);
                    }

                    if (dr["RECETANUMERO"] != System.DBNull.Value)
                    {
                        retorno.IRECETANUMERO = (string)(dr["RECETANUMERO"]);
                    }

                    if (dr["MEDICOID"] != System.DBNull.Value)
                    {
                        retorno.IMEDICOID = (long)(dr["MEDICOID"]);
                    }

                    if (dr["VENTAID"] != System.DBNull.Value)
                    {
                        retorno.IVENTAID = (long)(dr["VENTAID"]);
                    }



                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = (int)(dr["FOLIO"]);
                    }

                    if (dr["RETENIDA"] != System.DBNull.Value)
                    {
                        retorno.IRETENIDA = (string)(dr["RETENIDA"]);
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
        public DataSet enlistarRECETA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RECETA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoRECETA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RECETA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteRECETA(CRECETABE oCRECETA, FbTransaction st)
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
                auxPar.Value = oCRECETA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from RECETA where

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




        public CRECETABE AgregarRECETA(CRECETABE oCRECETA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRECETA(oCRECETA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El RECETA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarRECETAD(oCRECETA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarRECETA(CRECETABE oCRECETA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRECETA(oCRECETA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RECETA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarRECETAD(oCRECETA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarRECETA(CRECETABE oCRECETANuevo, CRECETABE oCRECETAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRECETA(oCRECETAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RECETA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarRECETAD(oCRECETANuevo, oCRECETAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CRECETAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
