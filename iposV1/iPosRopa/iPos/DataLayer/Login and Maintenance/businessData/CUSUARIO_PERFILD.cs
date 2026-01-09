

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


    public class CUSUARIO_PERFILD
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
        public CUSUARIO_PERFILBE AgregarUSUARIO_PERFILD(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@UP_PERFIL", FbDbType.Integer);
                if (!(bool)oCUSUARIO_PERFIL.isnull["IUP_PERFIL"])
                {
                    auxPar.Value = oCUSUARIO_PERFIL.IUP_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                if (!(bool)oCUSUARIO_PERFIL.isnull["IUP_PERSONAID"])
                {
                    auxPar.Value = oCUSUARIO_PERFIL.IUP_PERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO USUARIO_PERFIL
      (
    
UP_PERFIL,

UP_PERSONAID
         )

Values (

@UP_PERFIL,

@UP_PERSONAID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCUSUARIO_PERFIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarUSUARIO_PERFILD(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@UP_PERFIL", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERFIL;
                parts.Add(auxPar);


                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERSONAID;
                parts.Add(auxPar);



                string commandText = @"  Delete from USUARIO_PERFIL
  where

  UP_PERFIL=@UP_PERFIL and 

  UP_PERSONAID=@UP_PERSONAID
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
        public bool CambiarUSUARIO_PERFILD(CUSUARIO_PERFILBE oCUSUARIO_PERFILNuevo, CUSUARIO_PERFILBE oCUSUARIO_PERFILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@UP_PERFIL", FbDbType.Integer);
                if (!(bool)oCUSUARIO_PERFILNuevo.isnull["IUP_PERFIL"])
                {
                    auxPar.Value = oCUSUARIO_PERFILNuevo.IUP_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                if (!(bool)oCUSUARIO_PERFILNuevo.isnull["IUP_PERSONAID"])
                {
                    auxPar.Value = oCUSUARIO_PERFILNuevo.IUP_PERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UP_PERFILAnt", FbDbType.Integer);
                if (!(bool)oCUSUARIO_PERFILAnterior.isnull["IUP_PERFIL"])
                {
                    auxPar.Value = oCUSUARIO_PERFILAnterior.IUP_PERFIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UP_PERSONAIDAnt", FbDbType.BigInt);
                if (!(bool)oCUSUARIO_PERFILAnterior.isnull["IUP_PERSONAID"])
                {
                    auxPar.Value = oCUSUARIO_PERFILAnterior.IUP_PERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  USUARIO_PERFIL
  set

UP_PERFIL=@UP_PERFIL,

UP_PERSONAID=@UP_PERSONAID
  where 

UP_PERFIL=@UP_PERFILAnt and

UP_PERSONAID=@UP_PERSONAIDAnt
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
        public CUSUARIO_PERFILBE seleccionarUSUARIO_PERFIL(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {




            CUSUARIO_PERFILBE retorno = new CUSUARIO_PERFILBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from USUARIO_PERFIL where
 UP_PERFIL=@UP_PERFIL    and
 UP_PERSONAID=@UP_PERSONAID  ";


                auxPar = new FbParameter("@UP_PERFIL", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERFIL;
                parts.Add(auxPar);



                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERSONAID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["UP_PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IUP_PERSONAID = (long)(dr["UP_PERSONAID"]);
                    }

                    if (dr["UP_PERFIL"] != System.DBNull.Value)
                    {
                        retorno.IUP_PERFIL = int.Parse(dr["UP_PERFIL"].ToString());
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
        public DataSet enlistarUSUARIO_PERFIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_USUARIO_PERFIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoUSUARIO_PERFIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_USUARIO_PERFIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteUSUARIO_PERFIL(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@UP_PERFIL", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERFIL;
                parts.Add(auxPar);


                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERSONAID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from USUARIO_PERFIL where

  UP_PERFIL=@UP_PERFIL    and

  UP_PERSONAID=@UP_PERSONAID  
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




        public CUSUARIO_PERFILBE AgregarUSUARIO_PERFIL(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIO_PERFIL(oCUSUARIO_PERFIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El USUARIO_PERFIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarUSUARIO_PERFILD(oCUSUARIO_PERFIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarUSUARIO_PERFIL(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIO_PERFIL(oCUSUARIO_PERFIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIO_PERFIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarUSUARIO_PERFILD(oCUSUARIO_PERFIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarUSUARIO_PERFIL(CUSUARIO_PERFILBE oCUSUARIO_PERFILNuevo, CUSUARIO_PERFILBE oCUSUARIO_PERFILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteUSUARIO_PERFIL(oCUSUARIO_PERFILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El USUARIO_PERFIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarUSUARIO_PERFILD(oCUSUARIO_PERFILNuevo, oCUSUARIO_PERFILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool BorrarPerfilesDeUsuario(CUSUARIO_PERFILBE oCUSUARIO_PERFIL, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UP_USERID", FbDbType.Integer);
                auxPar.Value = oCUSUARIO_PERFIL.IUP_PERSONAID;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"  Delete from USUARIO_PERFIL
  where UP_PERSONAID=@UP_USERID ;";
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
        public int ExisteUSUARIO_PERFIL(string pf_descripcion, long personaId, FbTransaction st)
        {

            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.Integer);
                auxPar.Value = personaId;
                parts.Add(auxPar);
                auxPar = new FbParameter("@PF_DESCRIPCION", FbDbType.VarChar);
                auxPar.Value = pf_descripcion;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select USUARIO_PERFIL.* from USUARIO_PERFIL
  inner join   PERFILES ON UP_PERFIL=PF_PERFIL 
 where
 UP_PERSONAID=@UP_PERSONAID    and
 PF_DESCRIPCION =@PF_DESCRIPCION
   
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







        public CUSUARIO_PERFILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
