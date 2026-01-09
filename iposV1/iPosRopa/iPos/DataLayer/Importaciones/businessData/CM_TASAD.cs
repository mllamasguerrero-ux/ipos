
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


    public class CM_TASAD
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
        public bool AgregarM_TASAD(CM_TASABE oCM_TASA, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_TASA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_TASA.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_TASA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_TASA.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TASA", OleDbType.Double);
                if (!(bool)oCM_TASA.isnull["ITASA"])
                {
                    auxPar.Value = oCM_TASA.ITASA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHAINI", OleDbType.Date);
                if (!(bool)oCM_TASA.isnull["IFECHAINI"])
                {
                    auxPar.Value = oCM_TASA.IFECHAINI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TASA.isnull["IID"])
                {
                    auxPar.Value = oCM_TASA.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_TASA.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TASA.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TASA.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TASA.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
CLAVE,

NOMBRE,

TASA,

FECHAINI,

ID,

ID_FECHA,

ID_HORA
         )

Values (

?,

?,

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
        public bool BorrarM_TASAD(CM_TASABE oCM_TASA, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.ICLAVE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TASA", OleDbType.Double);
                auxPar.Value = oCM_TASA.ITASA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHAINI", OleDbType.Date);
                auxPar.Value = oCM_TASA.IFECHAINI;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_TASA.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.IID_HORA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_TASA
  where

  CLAVE=@CLAVE and 

  NOMBRE=@NOMBRE and 

  TASA=@TASA and 

  FECHAINI=@FECHAINI and 

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
        public bool CambiarM_TASAD(CM_TASABE oCM_TASANuevo, CM_TASABE oCM_TASAAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_TASANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_TASANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_TASANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_TASANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TASA", OleDbType.Double);
                if (!(bool)oCM_TASANuevo.isnull["ITASA"])
                {
                    auxPar.Value = oCM_TASANuevo.ITASA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAINI", OleDbType.Date);
                if (!(bool)oCM_TASANuevo.isnull["IFECHAINI"])
                {
                    auxPar.Value = oCM_TASANuevo.IFECHAINI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TASANuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_TASANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_TASANuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TASANuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TASANuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TASANuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVEAnt", OleDbType.VarChar);
                if (!(bool)oCM_TASAAnterior.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_TASAAnterior.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBREAnt", OleDbType.VarChar);
                if (!(bool)oCM_TASAAnterior.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_TASAAnterior.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TASAAnt", OleDbType.Double);
                if (!(bool)oCM_TASAAnterior.isnull["ITASA"])
                {
                    auxPar.Value = oCM_TASAAnterior.ITASA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAINIAnt", OleDbType.Date);
                if (!(bool)oCM_TASAAnterior.isnull["IFECHAINI"])
                {
                    auxPar.Value = oCM_TASAAnterior.IFECHAINI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_TASAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_TASAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_TASAAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TASAAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TASAAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TASAAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_TASA
  set

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

TASA=@TASA,

FECHAINI=@FECHAINI,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

CLAVE=@CLAVEAnt and

NOMBRE=@NOMBREAnt and

TASA=@TASAAnt and

FECHAINI=@FECHAINIAnt and

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
        public CM_TASABE seleccionarM_TASA(CM_TASABE oCM_TASA, OleDbTransaction st)
        {




            CM_TASABE retorno = new CM_TASABE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_TASA where
 CLAVE=@CLAVE    and
 NOMBRE=@NOMBRE    and
 TASA=@TASA    and
 FECHAINI=@FECHAINI    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA  ";


                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.ICLAVE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.INOMBRE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TASA", OleDbType.Double);
                auxPar.Value = oCM_TASA.ITASA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHAINI", OleDbType.Date);
                auxPar.Value = oCM_TASA.IFECHAINI;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_TASA.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.IID_HORA;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        retorno.ITASA = (double)(dr["TASA"]);
                    }

                    if (dr["FECHAINI"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINI = (DateTime)(dr["FECHAINI"]);
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
        public DataSet enlistarM_TASA()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_TASA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_TASA()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_TASA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_TASA(CM_TASABE oCM_TASA, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.ICLAVE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.INOMBRE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TASA", OleDbType.Double);
                auxPar.Value = oCM_TASA.ITASA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHAINI", OleDbType.Date);
                auxPar.Value = oCM_TASA.IFECHAINI;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_TASA.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TASA.IID_HORA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_TASA where

  CLAVE=@CLAVE    and

  NOMBRE=@NOMBRE    and

  TASA=@TASA    and

  FECHAINI=@FECHAINI    and

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




        public CM_TASABE AgregarM_TASA(CM_TASABE oCM_TASA, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TASA(oCM_TASA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_TASA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;//AgregarM_TASAD(oCM_TASA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_TASA(CM_TASABE oCM_TASA, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TASA(oCM_TASA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_TASA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_TASAD(oCM_TASA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_TASA(CM_TASABE oCM_TASANuevo, CM_TASABE oCM_TASAAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TASA(oCM_TASAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_TASA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_TASAD(oCM_TASANuevo, oCM_TASAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_TASAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
