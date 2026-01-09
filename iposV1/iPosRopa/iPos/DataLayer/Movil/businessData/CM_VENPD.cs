


using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using iPosBusinessEntity;
using DataLayer;


namespace iPosData
{



    public class CM_VENPD
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

        public CM_VENPBE AgregarM_VENPD(CM_VENPBE oCM_VENP,  string strTableName, OleDbTransaction st,string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENP.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENP.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS2", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENP.IESTATUS2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOTA1", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENP.INOTA1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOTA2", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENP.INOTA2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZOS", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENP.IPLAZOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUGERIDOS", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENP.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TOTAL", OleDbType.Decimal);
                if (!(bool)oCM_VENP.isnull["ITOTAL"])
                {
                    auxPar.Value = oCM_VENP.ITOTAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTOCRED", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VENP.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTADO", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["ICONTADO"])
                {
                    auxPar.Value = oCM_VENP.ICONTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROCESADO", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCM_VENP.IPROCESADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IID"])
                {
                    auxPar.Value = "";
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_VENP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_VENP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENP.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO '"  + strTableName + @"' 
      (
    
VENTA,

CLIENTE,

ESTATUS,

ESTATUS2,

NOTA1,

NOTA2,

PLAZOS,

SUGERIDOS,

TOTAL,

AUTOCRED,

CONTADO,

PROCESADO,

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






                return oCM_VENP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public CM_VENPBE seleccionarM_VENP_XVENTA(string venta, OleDbTransaction st)
        {




            CM_VENPBE retorno = new CM_VENPBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_VENP where
 VENTA = ?    ";


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = venta;
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

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["ESTATUS2"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS2 = (string)(dr["ESTATUS2"]);
                    }

                    if (dr["NOTA1"] != System.DBNull.Value)
                    {
                        retorno.INOTA1 = (string)(dr["NOTA1"]);
                    }

                    if (dr["NOTA2"] != System.DBNull.Value)
                    {
                        retorno.INOTA2 = (string)(dr["NOTA2"]);
                    }

                    if (dr["PLAZOS"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOS = (string)(dr["PLAZOS"]);
                    }

                    if (dr["SUGERIDOS"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDOS = (string)(dr["SUGERIDOS"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (Decimal)(dr["TOTAL"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
                    }

                    if (dr["CONTADO"] != System.DBNull.Value)
                    {
                        retorno.ICONTADO = (string)(dr["CONTADO"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
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






        public bool BorrarM_VENPD_XVENTA(string venta, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = venta;
                parts.Add(auxPar);




                string commandText = @"Delete from M_VENP
  where
  VENTA = ? 
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




        public bool BorrarM_VENPD(CM_VENPBE oCM_VENP, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IVENTA;
                parts.Add(auxPar);




                string commandText = @"Delete from M_VENP
  where
  VENTA = ? 
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

        public bool CambiarM_VENPD(CM_VENPBE oCM_VENPNuevo, CM_VENPBE oCM_VENPAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;




                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENPNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENPNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUS2", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENPNuevo.IESTATUS2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOTA1", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENPNuevo.INOTA1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NOTA2", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENPNuevo.INOTA2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PLAZOS", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENPNuevo.IPLAZOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SUGERIDOS", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENPNuevo.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TOTAL", OleDbType.Decimal);
                if (!(bool)oCM_VENPNuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCM_VENPNuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@AUTOCRED", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IAUTOCRED"])
                {
                    auxPar.Value = oCM_VENPNuevo.IAUTOCRED;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CONTADO", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["ICONTADO"])
                {
                    auxPar.Value = oCM_VENPNuevo.ICONTADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_VENPNuevo.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_VENPNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENPNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENPNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROCESADO", OleDbType.VarChar);
                if (!(bool)oCM_VENPNuevo.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCM_VENPNuevo.IPROCESADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_VENPAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENPAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
  update  M_VENP
  set


CLIENTE=?,

ESTATUS=?,

ESTATUS2=?,

NOTA1=?,

NOTA2=?,

PLAZOS=?,

SUGERIDOS=?,

TOTAL=?,

AUTOCRED=?,

CONTADO=?,

ID=?,

ID_FECHA=?,

ID_HORA=?,

PROCESADO = ?
  where 

VENTA=?
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



        public CM_VENPBE seleccionarM_VENP(CM_VENPBE oCM_VENP, OleDbTransaction st)
        {




            CM_VENPBE retorno = new CM_VENPBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_VENP where
 VENTA = ?    ";


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IVENTA;
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

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["ESTATUS2"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS2 = (string)(dr["ESTATUS2"]);
                    }

                    if (dr["NOTA1"] != System.DBNull.Value)
                    {
                        retorno.INOTA1 = (string)(dr["NOTA1"]);
                    }

                    if (dr["NOTA2"] != System.DBNull.Value)
                    {
                        retorno.INOTA2 = (string)(dr["NOTA2"]);
                    }

                    if (dr["PLAZOS"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOS = (string)(dr["PLAZOS"]);
                    }

                    if (dr["SUGERIDOS"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDOS = (string)(dr["SUGERIDOS"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (Decimal)(dr["TOTAL"]);
                    }

                    if (dr["AUTOCRED"] != System.DBNull.Value)
                    {
                        retorno.IAUTOCRED = (string)(dr["AUTOCRED"]);
                    }

                    if (dr["CONTADO"] != System.DBNull.Value)
                    {
                        retorno.ICONTADO = (string)(dr["CONTADO"]);
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









        public DataSet enlistarM_VENP()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_VENP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoM_VENP()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_VENP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteM_VENP(CM_VENPBE oCM_VENP, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS2", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IESTATUS2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOTA1", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.INOTA1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOTA2", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.INOTA2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZOS", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IPLAZOS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUGERIDOS", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.ISUGERIDOS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TOTAL", OleDbType.Decimal);
                auxPar.Value = oCM_VENP.ITOTAL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTOCRED", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IAUTOCRED;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTADO", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.ICONTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_VENP.IID_HORA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_VENP where

  VENTA=@VENTA    and

  CLIENTE=@CLIENTE    and

  ESTATUS=@ESTATUS    and

  ESTATUS2=@ESTATUS2    and

  NOTA1=@NOTA1    and

  NOTA2=@NOTA2    and

  PLAZOS=@PLAZOS    and

  SUGERIDOS=@SUGERIDOS    and

  TOTAL=@TOTAL    and

  AUTOCRED=@AUTOCRED    and

  CONTADO=@CONTADO    and

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



        /*
        public CM_VENPBE AgregarM_VENP(CM_VENPBE oCM_VENP, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENP(oCM_VENP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_VENP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarM_VENPD(oCM_VENP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }*/


        public bool BorrarM_VENP(CM_VENPBE oCM_VENP, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENP(oCM_VENP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VENP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_VENPD(oCM_VENP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_VENP(CM_VENPBE oCM_VENPNuevo, CM_VENPBE oCM_VENPAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENP(oCM_VENPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VENP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_VENPD(oCM_VENPNuevo, oCM_VENPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        
        public CM_VENPD()
        {
            this.sCadenaConexion = "";
        }

    }
}
