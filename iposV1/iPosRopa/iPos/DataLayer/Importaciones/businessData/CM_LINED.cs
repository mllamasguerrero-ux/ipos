
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


    public class CM_LINED
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
        public bool AgregarM_LINED(CM_LINEBE oCM_LINE, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_LINE.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_LINE.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_LINE.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_LINE.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_LINE.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_LINE.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["IID"])
                {
                    auxPar.Value = oCM_LINE.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_LINE.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_LINE.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_LINE.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRECARGA", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["ITRECARGA"])
                {
                    auxPar.Value = oCM_LINE.ITRECARGA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RECETA", OleDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@APLIMAYO", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["IAPLIMAYO"])
                {
                    auxPar.Value = oCM_LINE.IAPLIMAYO;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@GPOIMP", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["IGPOIMP"])
                {
                    auxPar.Value = oCM_LINE.IGPOIMP;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                string commandText = @"
        INSERT INTO M_LINE
      (
    
LINEA,

NOMBRE,

CANTIDAD,

IMPORTE,

ID,

ID_FECHA,

ID_HORA,

TRECARGA,

PROMOCION,

RECETA,

APLIMAYO,

GPOIMP
         )

Values (

?,

?,

?,

?,

?,

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



        public bool AgregarQ_LINE(CM_LINEBE oCM_LINE, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_LINE.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_LINE.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_LINE.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_LINE.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_LINE.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_LINE.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PLAZO", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["IID"])
                {
                    auxPar.Value = oCM_LINE.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_LINE.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_LINE.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_LINE.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_LINE.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PCLIENTE", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PPRODUCTO", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PVENDEDOR", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PMARCA", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PPROVEEDOR", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PCIUDAD", OleDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
LINEA,

NOMBRE,

CANTIDAD,

IMPORTE,

PLAZO,

ID,

ID_FECHA,

ID_HORA,

ESTRATEGIC,

PCLIENTE,

PPRODUCTO,

PVENDEDOR,

PMARCA,

PPROVEEDOR,

PCIUDAD
         )

Values (

?,
?,
?,
?,
?,
?,
?,
?,
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
        public bool BorrarM_LINED(CM_LINEBE oCM_LINE, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCM_LINE.ILINEA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_LINE
  where

  LINEA=@LINEA
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
        public bool CambiarM_LINED(CM_LINEBE oCM_LINENuevo, CM_LINEBE oCM_LINEAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCM_LINENuevo.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_LINENuevo.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_LINENuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_LINENuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_LINENuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_LINENuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_LINENuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_LINENuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_LINENuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_LINENuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_LINENuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_LINENuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_LINENuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_LINENuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEAAnt", OleDbType.VarChar);
                if (!(bool)oCM_LINEAnterior.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_LINEAnterior.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_LINE
  set

LINEA=@LINEA,

NOMBRE=@NOMBRE,

CANTIDAD=@CANTIDAD,

IMPORTE=@IMPORTE,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

LINEA=@LINEAAnt
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
        public CM_LINEBE seleccionarM_LINE(CM_LINEBE oCM_LINE, OleDbTransaction st)
        {




            CM_LINEBE retorno = new CM_LINEBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_LINE where
 LINEA=@LINEA  ";


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCM_LINE.ILINEA;
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

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        retorno.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (double)(dr["CANTIDAD"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (double)(dr["IMPORTE"]);
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
        public DataSet enlistarM_LINE()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_LINE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_LINE()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_LINE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_LINE(CM_LINEBE oCM_LINE, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCM_LINE.ILINEA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_LINE where

  LINEA=@LINEA  
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




        public CM_LINEBE AgregarM_LINE(CM_LINEBE oCM_LINE, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_LINE(oCM_LINE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_LINE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;// AgregarM_LINED(oCM_LINE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_LINE(CM_LINEBE oCM_LINE, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_LINE(oCM_LINE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_LINE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_LINED(oCM_LINE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_LINE(CM_LINEBE oCM_LINENuevo, CM_LINEBE oCM_LINEAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_LINE(oCM_LINEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_LINE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_LINED(oCM_LINENuevo, oCM_LINEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_LINED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
