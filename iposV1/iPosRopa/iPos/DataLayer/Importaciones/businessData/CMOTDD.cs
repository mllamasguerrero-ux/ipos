
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{



    public class CM_MOTDD
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

        public bool AgregarM_MOTDD(CM_MOTDBE oCM_MOTD, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_MOTD.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_MOTD.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_MOTD.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_MOTD.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESC", OleDbType.VarChar);
                if (!(bool)oCM_MOTD.isnull["IDESC"])
                {
                    auxPar.Value = oCM_MOTD.IDESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_MOTD.isnull["IID"])
                {
                    auxPar.Value = oCM_MOTD.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_MOTD.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_MOTD.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_MOTD.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_MOTD.IID_HORA;
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

DESC,

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
        public bool BorrarM_MOTDD(CM_MOTDBE oCM_MOTD, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.ICLAVE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.INOMBRE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_MOTD.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.IID_HORA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_MOTD
  where

  CLAVE=@CLAVE and 

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
        public bool CambiarM_MOTDD(CM_MOTDBE oCM_MOTDNuevo, CM_MOTDBE oCM_MOTDAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_MOTDNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_MOTDNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_MOTDNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_MOTDNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_MOTDNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_MOTDNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_MOTDNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_MOTDNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_MOTDNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_MOTDNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVEAnt", OleDbType.VarChar);
                if (!(bool)oCM_MOTDAnterior.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_MOTDAnterior.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBREAnt", OleDbType.VarChar);
                if (!(bool)oCM_MOTDAnterior.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_MOTDAnterior.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_MOTDAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_MOTDAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_MOTDAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_MOTDAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_MOTDAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_MOTDAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_MOTD
  set

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

CLAVE=@CLAVEAnt and

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
        public CM_MOTDBE seleccionarM_MOTD(CM_MOTDBE oCM_MOTD, OleDbTransaction st)
        {




            CM_MOTDBE retorno = new CM_MOTDBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_MOTD where
 CLAVE=@CLAVE    and
 NOMBRE=@NOMBRE    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA  ";


                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.ICLAVE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.INOMBRE;
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_MOTD.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.IID_HORA;
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
        public DataSet enlistarM_MOTD()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_MOTD_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_MOTD()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_MOTD_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_MOTD(CM_MOTDBE oCM_MOTD, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.ICLAVE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.INOMBRE;
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_MOTD.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_MOTD.IID_HORA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_MOTD where

  CLAVE=@CLAVE    and

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




        public CM_MOTDBE AgregarM_MOTD(CM_MOTDBE oCM_MOTD, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_MOTD(oCM_MOTD, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_MOTD ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;//AgregarM_MOTDD(oCM_MOTD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_MOTD(CM_MOTDBE oCM_MOTD, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_MOTD(oCM_MOTD, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_MOTD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_MOTDD(oCM_MOTD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_MOTD(CM_MOTDBE oCM_MOTDNuevo, CM_MOTDBE oCM_MOTDAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_MOTD(oCM_MOTDAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_MOTD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_MOTDD(oCM_MOTDNuevo, oCM_MOTDAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_MOTDD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
