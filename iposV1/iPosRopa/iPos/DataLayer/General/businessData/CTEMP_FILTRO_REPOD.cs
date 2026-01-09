


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


    public class CTEMP_FILTRO_REPOD
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
        public CTEMP_FILTRO_REPOBE AgregarTEMP_FILTRO_REPOD(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE_REPORTE", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["INOMBRE_REPORTE"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.INOMBRE_REPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GRUPO_REPORTE", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IGRUPO_REPORTE"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IGRUPO_REPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FILTRO_TEXTO", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IFILTRO_TEXTO"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IFILTRO_TEXTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FILTRO_ID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IFILTRO_ID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IFILTRO_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FILTRO_INTEGER", FbDbType.Integer);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IFILTRO_INTEGER"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IFILTRO_INTEGER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO TEMP_FILTRO_REPO
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

NOMBRE_REPORTE,

GRUPO_REPORTE,

FILTRO_TEXTO,

FILTRO_ID,

FILTRO_INTEGER
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@NOMBRE_REPORTE,

@GRUPO_REPORTE,

@FILTRO_TEXTO,

@FILTRO_ID,

@FILTRO_INTEGER
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCTEMP_FILTRO_REPO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarTEMP_FILTRO_REPOD(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTEMP_FILTRO_REPO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from TEMP_FILTRO_REPO
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


        public bool BorrarPorNombreYGrupo(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                


                auxPar = new FbParameter("@NOMBRE_REPORTE", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["INOMBRE_REPORTE"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.INOMBRE_REPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GRUPO_REPORTE", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPO.isnull["IGRUPO_REPORTE"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPO.IGRUPO_REPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"  Delete from TEMP_FILTRO_REPO where 
                                         NOMBRE_REPORTE = @NOMBRE_REPORTE and
                                         GRUPO_REPORTE = @GRUPO_REPORTE
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
        public bool CambiarTEMP_FILTRO_REPOD(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPONuevo, CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE_REPORTE", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["INOMBRE_REPORTE"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.INOMBRE_REPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GRUPO_REPORTE", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IGRUPO_REPORTE"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IGRUPO_REPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FILTRO_TEXTO", FbDbType.VarChar);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IFILTRO_TEXTO"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IFILTRO_TEXTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FILTRO_ID", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IFILTRO_ID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IFILTRO_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FILTRO_INTEGER", FbDbType.Integer);
                if (!(bool)oCTEMP_FILTRO_REPONuevo.isnull["IFILTRO_INTEGER"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPONuevo.IFILTRO_INTEGER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCTEMP_FILTRO_REPOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCTEMP_FILTRO_REPOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  TEMP_FILTRO_REPO
  set

ID=@ID,

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

NOMBRE_REPORTE=@NOMBRE_REPORTE,

GRUPO_REPORTE=@GRUPO_REPORTE,

FILTRO_TEXTO=@FILTRO_TEXTO,

FILTRO_ID=@FILTRO_ID,

FILTRO_INTEGER=@FILTRO_INTEGER
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
        public CTEMP_FILTRO_REPOBE seleccionarTEMP_FILTRO_REPO(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
        {




            CTEMP_FILTRO_REPOBE retorno = new CTEMP_FILTRO_REPOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TEMP_FILTRO_REPO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTEMP_FILTRO_REPO.IID;
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

                    if (dr["NOMBRE_REPORTE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE_REPORTE = (string)(dr["NOMBRE_REPORTE"]);
                    }

                    if (dr["GRUPO_REPORTE"] != System.DBNull.Value)
                    {
                        retorno.IGRUPO_REPORTE = (string)(dr["GRUPO_REPORTE"]);
                    }

                    if (dr["FILTRO_TEXTO"] != System.DBNull.Value)
                    {
                        retorno.IFILTRO_TEXTO = (string)(dr["FILTRO_TEXTO"]);
                    }

                    if (dr["FILTRO_ID"] != System.DBNull.Value)
                    {
                        retorno.IFILTRO_ID = (long)(dr["FILTRO_ID"]);
                    }

                    if (dr["FILTRO_INTEGER"] != System.DBNull.Value)
                    {
                        retorno.IFILTRO_INTEGER = int.Parse(dr["FILTRO_INTEGER"].ToString());
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
        public DataSet enlistarTEMP_FILTRO_REPO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TEMP_FILTRO_REPO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoTEMP_FILTRO_REPO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TEMP_FILTRO_REPO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteTEMP_FILTRO_REPO(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
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
                auxPar.Value = oCTEMP_FILTRO_REPO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from TEMP_FILTRO_REPO where

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




        public CTEMP_FILTRO_REPOBE AgregarTEMP_FILTRO_REPO(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTEMP_FILTRO_REPO(oCTEMP_FILTRO_REPO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El TEMP_FILTRO_REPO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarTEMP_FILTRO_REPOD(oCTEMP_FILTRO_REPO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarTEMP_FILTRO_REPO(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTEMP_FILTRO_REPO(oCTEMP_FILTRO_REPO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TEMP_FILTRO_REPO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarTEMP_FILTRO_REPOD(oCTEMP_FILTRO_REPO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarTEMP_FILTRO_REPO(CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPONuevo, CTEMP_FILTRO_REPOBE oCTEMP_FILTRO_REPOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTEMP_FILTRO_REPO(oCTEMP_FILTRO_REPOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TEMP_FILTRO_REPO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarTEMP_FILTRO_REPOD(oCTEMP_FILTRO_REPONuevo, oCTEMP_FILTRO_REPOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CTEMP_FILTRO_REPOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
