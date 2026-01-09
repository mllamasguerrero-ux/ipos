


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


    public class CPERFIL_REPOD
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
        public CPERFIL_REPOBE AgregarPERFIL_REPOD(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERFIL", FbDbType.Integer);
                if (!(bool)oCPERFIL_REPO.isnull["IPERFIL"])
                {
                    auxPar.Value = oCPERFIL_REPO.IPERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REPORTE", FbDbType.Integer);
                if (!(bool)oCPERFIL_REPO.isnull["IREPORTE"])
                {
                    auxPar.Value = oCPERFIL_REPO.IREPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PERFIL_REPO
      (
    
PERFIL,

REPORTE
         )

Values (

@PERFIL,

@REPORTE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPERFIL_REPO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPERFIL_REPOD(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IPERFIL;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REPORTE", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IREPORTE;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERFIL_REPO
  where

  PERFIL=@PERFIL and 

  REPORTE=@REPORTE
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
        public bool CambiarPERFIL_REPOD(CPERFIL_REPOBE oCPERFIL_REPONuevo, CPERFIL_REPOBE oCPERFIL_REPOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERFIL", FbDbType.Integer);
                if (!(bool)oCPERFIL_REPONuevo.isnull["IPERFIL"])
                {
                    auxPar.Value = oCPERFIL_REPONuevo.IPERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REPORTE", FbDbType.Integer);
                if (!(bool)oCPERFIL_REPONuevo.isnull["IREPORTE"])
                {
                    auxPar.Value = oCPERFIL_REPONuevo.IREPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERFILAnt", FbDbType.Integer);
                if (!(bool)oCPERFIL_REPOAnterior.isnull["IPERFIL"])
                {
                    auxPar.Value = oCPERFIL_REPOAnterior.IPERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REPORTEAnt", FbDbType.Integer);
                if (!(bool)oCPERFIL_REPOAnterior.isnull["IREPORTE"])
                {
                    auxPar.Value = oCPERFIL_REPOAnterior.IREPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PERFIL_REPO
  set

PERFIL=@PERFIL,

REPORTE=@REPORTE
  where 

PERFIL=@PERFILAnt and

REPORTE=@REPORTEAnt
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
        public CPERFIL_REPOBE seleccionarPERFIL_REPO(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {




            CPERFIL_REPOBE retorno = new CPERFIL_REPOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERFIL_REPO where
 PERFIL=@PERFIL    and
 REPORTE=@REPORTE  ";


                auxPar = new FbParameter("@PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IPERFIL;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REPORTE", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IREPORTE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["PERFIL"] != System.DBNull.Value)
                    {
                        retorno.IPERFIL = int.Parse(dr["PERFIL"].ToString());
                    }

                    if (dr["REPORTE"] != System.DBNull.Value)
                    {
                        retorno.IREPORTE = int.Parse(dr["REPORTE"].ToString());
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
        public DataSet enlistarPERFIL_REPO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERFIL_REPO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPERFIL_REPO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERFIL_REPO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePERFIL_REPO(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERFIL", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IPERFIL;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REPORTE", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IREPORTE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERFIL_REPO where

  PERFIL=@PERFIL    and

  REPORTE=@REPORTE  
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




        public CPERFIL_REPOBE AgregarPERFIL_REPO(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFIL_REPO(oCPERFIL_REPO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERFIL_REPO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERFIL_REPOD(oCPERFIL_REPO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERFIL_REPO(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFIL_REPO(oCPERFIL_REPO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERFIL_REPO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERFIL_REPOD(oCPERFIL_REPO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPERFIL_REPO(CPERFIL_REPOBE oCPERFIL_REPONuevo, CPERFIL_REPOBE oCPERFIL_REPOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERFIL_REPO(oCPERFIL_REPOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERFIL_REPO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERFIL_REPOD(oCPERFIL_REPONuevo, oCPERFIL_REPOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool BorrarPorReportePERFIL_REPOD(CPERFIL_REPOBE oCPERFIL_REPO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@REPORTE", FbDbType.Integer);
                auxPar.Value = oCPERFIL_REPO.IREPORTE;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERFIL_REPO
  where


  REPORTE=@REPORTE
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



        public CPERFIL_REPOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
