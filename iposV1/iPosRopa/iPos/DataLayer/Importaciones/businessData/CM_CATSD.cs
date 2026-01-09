
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
    public class CM_CATSD
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
        public bool AgregarM_CATSD(CM_CATSBE oCM_CATS, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CATS.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_CATS.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCM_CATS.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTAR", OleDbType.Boolean);
                if (!(bool)oCM_CATS.isnull["IIMPORTAR"])
                {
                    auxPar.Value = oCM_CATS.IIMPORTAR;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACTIVA", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IACTIVA"])
                {
                    auxPar.Value = oCM_CATS.IACTIVA;
                }
                else
                {
                    auxPar.Value = ""; 
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BWCOLOR", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IBWCOLOR"])
                {
                    auxPar.Value = oCM_CATS.IBWCOLOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FINSEMANA", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IFINSEMANA"])
                {
                    auxPar.Value = oCM_CATS.IFINSEMANA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IID"])
                {
                    auxPar.Value = oCM_CATS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_CATS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CATS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_CATS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCU", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ISUCU"])
                {
                    auxPar.Value = oCM_CATS.ISUCU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCM_CATS.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_CATS.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GRUPO", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IGRUPO"])
                {
                    auxPar.Value = oCM_CATS.IGRUPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMER", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ICOMER"])
                {
                    auxPar.Value = oCM_CATS.ICOMER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIOT", OleDbType.Double);
                if (!(bool)oCM_CATS.isnull["IPRECIOT"])
                {
                    auxPar.Value = oCM_CATS.IPRECIOT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAXDOCP", OleDbType.Double);
                if (!(bool)oCM_CATS.isnull["IMAXDOCP"])
                {
                    auxPar.Value = oCM_CATS.IMAXDOCP;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESMATRIZ", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IESMATRIZ"])
                {
                    auxPar.Value = oCM_CATS.IESMATRIZ;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOREC", OleDbType.Double);
                if (!(bool)oCM_CATS.isnull["ICOSTOREC"])
                {
                    auxPar.Value = oCM_CATS.ICOSTOREC;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECENV", OleDbType.Double);
                if (!(bool)oCM_CATS.isnull["IPRECENV"])
                {
                    auxPar.Value = oCM_CATS.IPRECENV;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SHOWREAL", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ISHOWREAL"])
                {
                    auxPar.Value = oCM_CATS.ISHOWREAL;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEE", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IPROVEE"])
                {
                    auxPar.Value = oCM_CATS.IPROVEE;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIDOR", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ISURTIDOR"])
                {
                    auxPar.Value = oCM_CATS.ISURTIDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PORCPREC", OleDbType.Double);
                if (!(bool)oCM_CATS.isnull["IPORCPREC"])
                {
                    auxPar.Value = oCM_CATS.IPORCPREC;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECXDES", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IPRECXDES"])
                {
                    auxPar.Value = oCM_CATS.IPRECXDES;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREFXDES", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IPREFXDES"])
                {
                    auxPar.Value = oCM_CATS.IPREFXDES;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RESPBD", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IRESPBD"])
                {
                    auxPar.Value = oCM_CATS.IRESPBD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ESFRANQ", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IESFRANQ"])
                {
                    auxPar.Value = oCM_CATS.IESFRANQ;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@BANCO", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IBANCO"])
                {
                    auxPar.Value = oCM_CATS.IBANCO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CUENTA", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ICUENTA"])
                {
                    auxPar.Value = oCM_CATS.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CTAPOLI", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ICTAPOLI"])
                {
                    auxPar.Value = oCM_CATS.ICTAPOLI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);
                

                auxPar = new OleDbParameter("@LSTPREC", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["ILSTPREC"])
                {
                    auxPar.Value = oCM_CATS.ILSTPREC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EMPPROV", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IEMPPROV"])
                {
                    auxPar.Value = oCM_CATS.IEMPPROV;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMNUPROD", OleDbType.VarChar);
                if (!(bool)oCM_CATS.isnull["IIMNUPROD"])
                {
                    auxPar.Value = oCM_CATS.IIMNUPROD;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO M_CATS
      (
    
CLIENTE,

NOMBRE,

SUCURSAL,

IMPORTAR,

ACTIVA,

BWCOLOR,

FINSEMANA,

ID,

ID_FECHA,

ID_HORA,

SUCU,

ESTRATEGIC,

NOMBRE2,

GRUPO,

COMER,

PRECIOT,

MAXDOCP,

ESMATRIZ,

COSTOREC,

PRECENV,

SHOWREAL,

PROVEE,

SURTIDOR,

PORCPREC,

PRECXDES,

PREFXDES,

RESPBD,

ESFRANQ,

BANCO,

CUENTA,

CTAPOLI,

LSTPREC,

EMPPROV,

IMNUPROD

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
        public bool BorrarM_CATSD(CM_CATSBE oCM_CATS, OleDbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_CATS.ICLIENTE;
                parts.Add(auxPar);

                string commandText = @"  Delete from M_CATS
  where

  CLIENTE=@CLIENTE
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
        public bool CambiarM_CATSD(CM_CATSBE oCM_CATSNuevo, CM_CATSBE oCM_CATSAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CATSNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_CATSNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCM_CATSNuevo.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTAR", OleDbType.Boolean);
                if (!(bool)oCM_CATSNuevo.isnull["IIMPORTAR"])
                {
                    auxPar.Value = oCM_CATSNuevo.IIMPORTAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ACTIVA", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IACTIVA"])
                {
                    auxPar.Value = oCM_CATSNuevo.IACTIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@BWCOLOR", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IBWCOLOR"])
                {
                    auxPar.Value = oCM_CATSNuevo.IBWCOLOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FINSEMANA", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IFINSEMANA"])
                {
                    auxPar.Value = oCM_CATSNuevo.IFINSEMANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_CATSNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_CATSNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CATSNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_CATSNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SUCU", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["ISUCU"])
                {
                    auxPar.Value = oCM_CATSNuevo.ISUCU;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCM_CATSNuevo.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCM_CATSNuevo.INOMBRE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@GRUPO", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["IGRUPO"])
                {
                    auxPar.Value = oCM_CATSNuevo.IGRUPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMER", OleDbType.VarChar);
                if (!(bool)oCM_CATSNuevo.isnull["ICOMER"])
                {
                    auxPar.Value = oCM_CATSNuevo.ICOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIOT", OleDbType.Double);
                if (!(bool)oCM_CATSNuevo.isnull["IPRECIOT"])
                {
                    auxPar.Value = oCM_CATSNuevo.IPRECIOT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MAXDOCP", OleDbType.Double);
                if (!(bool)oCM_CATSNuevo.isnull["IMAXDOCP"])
                {
                    auxPar.Value = oCM_CATSNuevo.IMAXDOCP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTEAnt", OleDbType.VarChar);
                if (!(bool)oCM_CATSAnterior.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CATSAnterior.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                string commandText = @"
  update  M_CATS
  set

CLIENTE=@CLIENTE,

NOMBRE=@NOMBRE,

SUCURSAL=@SUCURSAL,

IMPORTAR=@IMPORTAR,

ACTIVA=@ACTIVA,

BWCOLOR=@BWCOLOR,

FINSEMANA=@FINSEMANA,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

SUCU=@SUCU,

ESTRATEGIC=@ESTRATEGIC,

NOMBRE2=@NOMBRE2,

GRUPO=@GRUPO,

COMER=@COMER,

PRECIOT=@PRECIOT,

MAXDOCP=@MAXDOCP

  where 

CLIENTE=@CLIENTEAnt
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
        public CM_CATSBE seleccionarM_CATS(CM_CATSBE oCM_CATS, OleDbTransaction st)
        {




            CM_CATSBE retorno = new CM_CATSBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_CATS where CLIENTE=@CLIENTE";


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_CATS.ICLIENTE;
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

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSAL = (string)(dr["SUCURSAL"]);
                    }

                    if (dr["IMPORTAR"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTAR = (bool)(dr["IMPORTAR"]);
                    }

                    if (dr["ACTIVA"] != System.DBNull.Value)
                    {
                        retorno.IACTIVA = (string)(dr["ACTIVA"]);
                    }

                    if (dr["BWCOLOR"] != System.DBNull.Value)
                    {
                        retorno.IBWCOLOR = (string)(dr["BWCOLOR"]);
                    }

                    if (dr["FINSEMANA"] != System.DBNull.Value)
                    {
                        retorno.IFINSEMANA = (string)(dr["FINSEMANA"]);
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

                    if (dr["SUCU"] != System.DBNull.Value)
                    {
                        retorno.ISUCU = (string)(dr["SUCU"]);
                    }

                    if (dr["ESTRATEGIC"] != System.DBNull.Value)
                    {
                        retorno.IESTRATEGIC = (string)(dr["ESTRATEGIC"]);
                    }

                    if (dr["NOMBRE2"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE2 = (string)(dr["NOMBRE2"]);
                    }

                    if (dr["GRUPO"] != System.DBNull.Value)
                    {
                        retorno.IGRUPO = (string)(dr["GRUPO"]);
                    }

                    if (dr["COMER"] != System.DBNull.Value)
                    {
                        retorno.ICOMER = (string)(dr["COMER"]);
                    }

                    if (dr["PRECIOT"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOT = (double)(dr["PRECIOT"]);
                    }

                    if (dr["MAXDOCP"] != System.DBNull.Value)
                    {
                        retorno.IMAXDOCP = (double)(dr["MAXDOCP"]);
                    }

                    if (dr["PROVEE"] != System.DBNull.Value)
                    {
                        retorno.IPROVEE = (string)(dr["PROVEE"]);
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
        public DataSet enlistarM_CATS()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_CATS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_CATS()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_CATS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_CATS(CM_CATSBE oCM_CATS, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_CATS.ICLIENTE;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_CATS where

  CLIENTE=@CLIENTE  
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




        public CM_CATSBE AgregarM_CATS(CM_CATSBE oCM_CATS, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_CATS(oCM_CATS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_CATS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;// AgregarM_CATSD(oCM_CATS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_CATS(CM_CATSBE oCM_CATS, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_CATS(oCM_CATS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_CATS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_CATSD(oCM_CATS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_CATS(CM_CATSBE oCM_CATSNuevo, CM_CATSBE oCM_CATSAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_CATS(oCM_CATSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_CATS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_CATSD(oCM_CATSNuevo, oCM_CATSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_CATSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
