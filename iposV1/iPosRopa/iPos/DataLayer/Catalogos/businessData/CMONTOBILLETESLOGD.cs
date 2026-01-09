

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
    public class CMONTOBILLETESLOGD
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

        public CMONTOBILLETESLOGBE AgregarMONTOBILLETESLOGD(CMONTOBILLETESLOGBE oCMONTOBILLETESLOG, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONTOBILLETESLOG.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOG.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOG.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTOBILLETESID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOG.isnull["IMONTOBILLETESID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.IMONTOBILLETESID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCMONTOBILLETESLOG.isnull["INOTA"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOFINALANTERIOR", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESLOG.isnull["ISALDOFINALANTERIOR"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.ISALDOFINALANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOFINALNUEVO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESLOG.isnull["ISALDOFINALNUEVO"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.ISALDOFINALNUEVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHACAMBIO", FbDbType.Date);
                if (!(bool)oCMONTOBILLETESLOG.isnull["IFECHACAMBIO"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.IFECHACAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOG.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOG.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MONTOBILLETESLOG
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

MONTOBILLETESID,

NOTA,

SALDOFINALANTERIOR,

SALDOFINALNUEVO,

FECHACAMBIO,

USUARIOID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@MONTOBILLETESID,

@NOTA,

@SALDOFINALANTERIOR,

@SALDOFINALNUEVO,

@FECHACAMBIO,

@USUARIOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMONTOBILLETESLOG;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMONTOBILLETESLOGD(CMONTOBILLETESLOGBE oCMONTOBILLETESLOG, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONTOBILLETESLOG.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MONTOBILLETESLOG
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


        public bool CambiarMONTOBILLETESLOGD(CMONTOBILLETESLOGBE oCMONTOBILLETESLOGNuevo, CMONTOBILLETESLOGBE oCMONTOBILLETESLOGAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOBILLETESID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["IMONTOBILLETESID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.IMONTOBILLETESID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["INOTA"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOFINALANTERIOR", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["ISALDOFINALANTERIOR"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.ISALDOFINALANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOFINALNUEVO", FbDbType.Numeric);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["ISALDOFINALNUEVO"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.ISALDOFINALNUEVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHACAMBIO", FbDbType.Date);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["IFECHACAMBIO"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.IFECHACAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOGNuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGNuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMONTOBILLETESLOGAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMONTOBILLETESLOGAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MONTOBILLETESLOG
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

MONTOBILLETESID=@MONTOBILLETESID,

NOTA=@NOTA,

SALDOFINALANTERIOR=@SALDOFINALANTERIOR,

SALDOFINALNUEVO=@SALDOFINALNUEVO,

FECHACAMBIO=@FECHACAMBIO,

USUARIOID=@USUARIOID
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
        public CMONTOBILLETESLOGBE seleccionarMONTOBILLETESLOG(CMONTOBILLETESLOGBE oCMONTOBILLETESLOG, FbTransaction st)
        {




            CMONTOBILLETESLOGBE retorno = new CMONTOBILLETESLOGBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONTOBILLETESLOG where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONTOBILLETESLOG.IID;
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

                    if (dr["MONTOBILLETESID"] != System.DBNull.Value)
                    {
                        retorno.IMONTOBILLETESID = (long)(dr["MONTOBILLETESID"]);
                    }

                    if (dr["NOTA"] != System.DBNull.Value)
                    {
                        retorno.INOTA = (string)(dr["NOTA"]);
                    }

                    if (dr["SALDOFINALANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINALANTERIOR = (decimal)(dr["SALDOFINALANTERIOR"]);
                    }

                    if (dr["SALDOFINALNUEVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINALNUEVO = (decimal)(dr["SALDOFINALNUEVO"]);
                    }

                    if (dr["FECHACAMBIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHACAMBIO = (DateTime)(dr["FECHACAMBIO"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
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
        public DataSet enlistarMONTOBILLETESLOG()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONTOBILLETESLOG_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMONTOBILLETESLOG()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONTOBILLETESLOG_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMONTOBILLETESLOG(CMONTOBILLETESLOGBE oCMONTOBILLETESLOG, FbTransaction st)
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
                auxPar.Value = oCMONTOBILLETESLOG.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MONTOBILLETESLOG where

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




        public CMONTOBILLETESLOGBE AgregarMONTOBILLETESLOG(CMONTOBILLETESLOGBE oCMONTOBILLETESLOG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONTOBILLETESLOG(oCMONTOBILLETESLOG, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MONTOBILLETESLOG ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMONTOBILLETESLOGD(oCMONTOBILLETESLOG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMONTOBILLETESLOG(CMONTOBILLETESLOGBE oCMONTOBILLETESLOG, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONTOBILLETESLOG(oCMONTOBILLETESLOG, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONTOBILLETESLOG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMONTOBILLETESLOGD(oCMONTOBILLETESLOG, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMONTOBILLETESLOG(CMONTOBILLETESLOGBE oCMONTOBILLETESLOGNuevo, CMONTOBILLETESLOGBE oCMONTOBILLETESLOGAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONTOBILLETESLOG(oCMONTOBILLETESLOGAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONTOBILLETESLOG no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMONTOBILLETESLOGD(oCMONTOBILLETESLOGNuevo, oCMONTOBILLETESLOGAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMONTOBILLETESLOGD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
