
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


    public class CM_DEFCD
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
        public bool AgregarM_DEFCD(CM_DEFCBE oCM_DEFC, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCM_DEFC.ITEXTO1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCM_DEFC.ITEXTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCM_DEFC.ITEXTO3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCM_DEFC.ITEXTO4;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCM_DEFC.ITEXTO5;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCM_DEFC.ITEXTO6;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO1", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["INUMERO1"])
                {
                    auxPar.Value = oCM_DEFC.INUMERO1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO2", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["INUMERO2"])
                {
                    auxPar.Value = oCM_DEFC.INUMERO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO3", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["INUMERO3"])
                {
                    auxPar.Value = oCM_DEFC.INUMERO3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO4", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["INUMERO4"])
                {
                    auxPar.Value = oCM_DEFC.INUMERO4;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA1", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["IFECHA1"])
                {
                    auxPar.Value = oCM_DEFC.IFECHA1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA2", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["IFECHA2"])
                {
                    auxPar.Value = oCM_DEFC.IFECHA2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["IID"])
                {
                    auxPar.Value = oCM_DEFC.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_DEFC.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_DEFC.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_DEFC.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_DEFC.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
TEXTO1,

TEXTO2,

TEXTO3,

TEXTO4,

TEXTO5,

TEXTO6,

NUMERO1,

NUMERO2,

NUMERO3,

NUMERO4,

FECHA1,

FECHA2,

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
        public bool BorrarM_DEFCD(CM_DEFCBE oCM_DEFC, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO3;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO4;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO5;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO6;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO3", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO3;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO4", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO4;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IFECHA1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IFECHA2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_DEFC.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IID_HORA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_DEFC
  where

  TEXTO1=@TEXTO1 and 

  TEXTO2=@TEXTO2 and 

  TEXTO3=@TEXTO3 and 

  TEXTO4=@TEXTO4 and 

  TEXTO5=@TEXTO5 and 

  TEXTO6=@TEXTO6 and 

  NUMERO1=@NUMERO1 and 

  NUMERO2=@NUMERO2 and 

  NUMERO3=@NUMERO3 and 

  NUMERO4=@NUMERO4 and 

  FECHA1=@FECHA1 and 

  FECHA2=@FECHA2 and 

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
        public bool CambiarM_DEFCD(CM_DEFCBE oCM_DEFCNuevo, CM_DEFCBE oCM_DEFCAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCM_DEFCNuevo.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCM_DEFCNuevo.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCM_DEFCNuevo.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCM_DEFCNuevo.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCM_DEFCNuevo.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCM_DEFCNuevo.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO1", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["INUMERO1"])
                {
                    auxPar.Value = oCM_DEFCNuevo.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO2", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["INUMERO2"])
                {
                    auxPar.Value = oCM_DEFCNuevo.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO3", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["INUMERO3"])
                {
                    auxPar.Value = oCM_DEFCNuevo.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO4", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["INUMERO4"])
                {
                    auxPar.Value = oCM_DEFCNuevo.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA1", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["IFECHA1"])
                {
                    auxPar.Value = oCM_DEFCNuevo.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA2", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["IFECHA2"])
                {
                    auxPar.Value = oCM_DEFCNuevo.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_DEFCNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_DEFCNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_DEFCNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_DEFCNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_DEFCNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO1Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCM_DEFCAnterior.ITEXTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO2Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCM_DEFCAnterior.ITEXTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO3Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCM_DEFCAnterior.ITEXTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO4Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCM_DEFCAnterior.ITEXTO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO5Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCM_DEFCAnterior.ITEXTO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO6Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCM_DEFCAnterior.ITEXTO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO1Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["INUMERO1"])
                {
                    auxPar.Value = oCM_DEFCAnterior.INUMERO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO2Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["INUMERO2"])
                {
                    auxPar.Value = oCM_DEFCAnterior.INUMERO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO3Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["INUMERO3"])
                {
                    auxPar.Value = oCM_DEFCAnterior.INUMERO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NUMERO4Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["INUMERO4"])
                {
                    auxPar.Value = oCM_DEFCAnterior.INUMERO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA1Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["IFECHA1"])
                {
                    auxPar.Value = oCM_DEFCAnterior.IFECHA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA2Ant", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["IFECHA2"])
                {
                    auxPar.Value = oCM_DEFCAnterior.IFECHA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_DEFCAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_DEFCAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_DEFCAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_DEFCAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_DEFCAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_DEFC
  set

TEXTO1=@TEXTO1,

TEXTO2=@TEXTO2,

TEXTO3=@TEXTO3,

TEXTO4=@TEXTO4,

TEXTO5=@TEXTO5,

TEXTO6=@TEXTO6,

NUMERO1=@NUMERO1,

NUMERO2=@NUMERO2,

NUMERO3=@NUMERO3,

NUMERO4=@NUMERO4,

FECHA1=@FECHA1,

FECHA2=@FECHA2,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

TEXTO1=@TEXTO1Ant and

TEXTO2=@TEXTO2Ant and

TEXTO3=@TEXTO3Ant and

TEXTO4=@TEXTO4Ant and

TEXTO5=@TEXTO5Ant and

TEXTO6=@TEXTO6Ant and

NUMERO1=@NUMERO1Ant and

NUMERO2=@NUMERO2Ant and

NUMERO3=@NUMERO3Ant and

NUMERO4=@NUMERO4Ant and

FECHA1=@FECHA1Ant and

FECHA2=@FECHA2Ant and

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
        public CM_DEFCBE seleccionarM_DEFC(CM_DEFCBE oCM_DEFC, OleDbTransaction st)
        {




            CM_DEFCBE retorno = new CM_DEFCBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_DEFC where
 TEXTO1=@TEXTO1    and
 TEXTO2=@TEXTO2    and
 TEXTO3=@TEXTO3    and
 TEXTO4=@TEXTO4    and
 TEXTO5=@TEXTO5    and
 TEXTO6=@TEXTO6    and
 NUMERO1=@NUMERO1    and
 NUMERO2=@NUMERO2    and
 NUMERO3=@NUMERO3    and
 NUMERO4=@NUMERO4    and
 FECHA1=@FECHA1    and
 FECHA2=@FECHA2    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA  ";


                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO3;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO4;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO5;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO6;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO3", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO3;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO4", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO4;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHA1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IFECHA1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHA2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IFECHA2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_DEFC.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IID_HORA;
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

                    if (dr["TEXTO1"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO1 = (string)(dr["TEXTO1"]);
                    }

                    if (dr["TEXTO2"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO2 = (string)(dr["TEXTO2"]);
                    }

                    if (dr["TEXTO3"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO3 = (string)(dr["TEXTO3"]);
                    }

                    if (dr["TEXTO4"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO4 = (string)(dr["TEXTO4"]);
                    }

                    if (dr["TEXTO5"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO5 = (string)(dr["TEXTO5"]);
                    }

                    if (dr["TEXTO6"] != System.DBNull.Value)
                    {
                        retorno.ITEXTO6 = (string)(dr["TEXTO6"]);
                    }

                    if (dr["NUMERO1"] != System.DBNull.Value)
                    {
                        retorno.INUMERO1 = (string)(dr["NUMERO1"]);
                    }

                    if (dr["NUMERO2"] != System.DBNull.Value)
                    {
                        retorno.INUMERO2 = (string)(dr["NUMERO2"]);
                    }

                    if (dr["NUMERO3"] != System.DBNull.Value)
                    {
                        retorno.INUMERO3 = (string)(dr["NUMERO3"]);
                    }

                    if (dr["NUMERO4"] != System.DBNull.Value)
                    {
                        retorno.INUMERO4 = (string)(dr["NUMERO4"]);
                    }

                    if (dr["FECHA1"] != System.DBNull.Value)
                    {
                        retorno.IFECHA1 = (string)(dr["FECHA1"]);
                    }

                    if (dr["FECHA2"] != System.DBNull.Value)
                    {
                        retorno.IFECHA2 = (string)(dr["FECHA2"]);
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
        public DataSet enlistarM_DEFC()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_DEFC_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_DEFC()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_DEFC_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_DEFC(CM_DEFCBE oCM_DEFC, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO3;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO4;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO5;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.ITEXTO6;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO3", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO3;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUMERO4", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.INUMERO4;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA1", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IFECHA1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA2", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IFECHA2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_DEFC.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_DEFC.IID_HORA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_DEFC where

  TEXTO1=@TEXTO1    and

  TEXTO2=@TEXTO2    and

  TEXTO3=@TEXTO3    and

  TEXTO4=@TEXTO4    and

  TEXTO5=@TEXTO5    and

  TEXTO6=@TEXTO6    and

  NUMERO1=@NUMERO1    and

  NUMERO2=@NUMERO2    and

  NUMERO3=@NUMERO3    and

  NUMERO4=@NUMERO4    and

  FECHA1=@FECHA1    and

  FECHA2=@FECHA2    and

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




        public CM_DEFCBE AgregarM_DEFC(CM_DEFCBE oCM_DEFC, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_DEFC(oCM_DEFC, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_DEFC ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;// AgregarM_DEFCD(oCM_DEFC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_DEFC(CM_DEFCBE oCM_DEFC, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_DEFC(oCM_DEFC, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_DEFC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_DEFCD(oCM_DEFC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_DEFC(CM_DEFCBE oCM_DEFCNuevo, CM_DEFCBE oCM_DEFCAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_DEFC(oCM_DEFCAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_DEFC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_DEFCD(oCM_DEFCNuevo, oCM_DEFCAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_DEFCD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
