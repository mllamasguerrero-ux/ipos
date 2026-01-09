
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
//using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CM_TIPOD
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
        public bool AgregarM_TIPOD(CM_TIPOBE oCM_TIPO, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_TIPO.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_TIPO.ITIPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_TIPO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_TIPO.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TIPO.isnull["IID"])
                {
                    auxPar.Value = oCM_TIPO.IID;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_TIPO.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TIPO.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TIPO.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TIPO.IID_HORA;
                }
                else
                {
                    auxPar.Value = DateTime.Now.ToString("HH:mm:ss");
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO  " + strFileName + @" 
      (
    
TIPO,

NOMBRE,

ID,

ID_FECHA,

ID_HORA
         )

Values (

?,

?,

?,

?,

?
); ";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                else
                    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool BorrarM_TIPOD(CM_TIPOBE oCM_TIPO, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID_HORA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_TIPO
  where

  TIPO=@TIPO and 

  NOMBRE=@NOMBRE and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA
  ;";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OleDbHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool CambiarM_TIPOD(CM_TIPOBE oCM_TIPONuevo, CM_TIPOBE oCM_TIPOAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCM_TIPONuevo.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_TIPONuevo.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_TIPONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_TIPONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TIPONuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_TIPONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                if (!(bool)oCM_TIPONuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TIPONuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TIPONuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TIPONuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPOAnt", OleDbType.VarChar);
                if (!(bool)oCM_TIPOAnterior.isnull["ITIPO"])
                {
                    auxPar.Value = oCM_TIPOAnterior.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBREAnt", OleDbType.VarChar);
                if (!(bool)oCM_TIPOAnterior.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_TIPOAnterior.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_TIPOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_TIPOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TIPOAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TIPOAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TIPOAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TIPOAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_TIPO
  set

TIPO=@TIPO,

NOMBRE=@NOMBRE,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

TIPO=@TIPOAnt and

NOMBRE=@NOMBREAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt
  ;";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    OleDbHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public CM_TIPOBE seleccionarM_TIPO(CM_TIPOBE oCM_TIPO, OleDbTransaction st)
        {




            CM_TIPOBE retorno = new CM_TIPOBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_TIPO where
 TIPO=@TIPO    and
 NOMBRE=@NOMBRE    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA  ";


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.ITIPO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.INOMBRE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID_HORA;
                parts.Add(auxPar);




                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        retorno.ITIPO = (string)(dr["TIPO"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (string)(dr["ID"]);
                    }

                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IID_FECHA = (DateTime)(dr["ID_FECHA"]);
                    }

                    if (dr["ID_HORA"] != System.DBNull.Value)
                    {
                        retorno.IID_HORA = (string)(dr["ID_HORA"]);
                    }

                }
                else
                {
                    retorno = null;
                }




                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }









        [AutoComplete]
        public DataSet enlistarM_TIPO()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_TIPO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_TIPO()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_TIPO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_TIPO(CM_TIPOBE oCM_TIPO, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TIPO.IID_HORA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_TIPO where

  TIPO=@TIPO    and

  NOMBRE=@NOMBRE    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA  
  );";






                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public bool AgregarM_TIPO(CM_TIPOBE oCM_TIPO, string strFileName, OleDbTransaction st, string strOleDbConn)
        {
            try
            {
                int iRes = ExisteM_TIPO(oCM_TIPO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_TIPO ya existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return AgregarM_TIPOD(oCM_TIPO, strFileName, st, strOleDbConn);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool BorrarM_TIPO(CM_TIPOBE oCM_TIPO, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TIPO(oCM_TIPO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_TIPO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_TIPOD(oCM_TIPO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_TIPO(CM_TIPOBE oCM_TIPONuevo, CM_TIPOBE oCM_TIPOAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TIPO(oCM_TIPOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_TIPO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_TIPOD(oCM_TIPONuevo, oCM_TIPOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_TIPOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
