

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using ConexionesBD;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using DataLayer;

namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CM_VENSD
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
        public CM_VENSBE AgregarM_VENSD(CM_VENSBE oCM_VENS, string strTableName, OleDbTransaction st,string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENS.IVENTA;
                }
                else
                {
                    auxPar.Value = "";// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENS.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENS.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS2", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENS.IESTATUS2;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOTA1", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENS.INOTA1;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOTA2", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENS.INOTA2;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZOS", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENS.IPLAZOS;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUGERIDOS", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENS.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["IID"])
                {
                    auxPar.Value = oCM_VENS.IID;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_VENS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_VENS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_FACTURA", OleDbType.Date);
                if (!(bool)oCM_VENS.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCM_VENS.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO '" + strTableName + @"' 
      (
    
VENTA,

CLIENTE,

ESTATUS,

ESTATUS2,

NOTA1,

NOTA2,

PLAZOS,

SUGERIDOS,

ID,

ID_FECHA,

ID_HORA,

F_FACTURA
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

                if (strOleDbConn != null)
                    OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                else
                    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return oCM_VENS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarM_VENSD(CM_VENSBE oCM_VENS, OdbcTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;



                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IVENTA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ESTATUS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ESTATUS2", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IESTATUS2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@NOTA1", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.INOTA1;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@NOTA2", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.INOTA2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@PLAZOS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IPLAZOS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@SUGERIDOS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.ISUGERIDOS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IID;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                auxPar.Value = oCM_VENS.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@F_FACTURA", OdbcType.Date);
                auxPar.Value = oCM_VENS.IF_FACTURA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_VENS
  where

  VENTA=@VENTA and 

  CLIENTE=@CLIENTE and 

  ESTATUS=@ESTATUS and 

  ESTATUS2=@ESTATUS2 and 

  NOTA1=@NOTA1 and 

  NOTA2=@NOTA2 and 

  PLAZOS=@PLAZOS and 

  SUGERIDOS=@SUGERIDOS and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA and 

  F_FACTURA=@F_FACTURA
  ;";

                OdbcParameter[] arParms = new OdbcParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OdbcHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    OdbcHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool CambiarM_VENSD(CM_VENSBE oCM_VENSNuevo, CM_VENSBE oCM_VENSAnterior, OdbcTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;



                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENSNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENSNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ESTATUS", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENSNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ESTATUS2", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENSNuevo.IESTATUS2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@NOTA1", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENSNuevo.INOTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@NOTA2", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENSNuevo.INOTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@PLAZOS", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENSNuevo.IPLAZOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@SUGERIDOS", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENSNuevo.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_VENSNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                if (!(bool)oCM_VENSNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENSNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                if (!(bool)oCM_VENSNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENSNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@F_FACTURA", OdbcType.Date);
                if (!(bool)oCM_VENSNuevo.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCM_VENSNuevo.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@VENTAAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VENSAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CLIENTEAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VENSAnterior.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ESTATUSAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_VENSAnterior.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ESTATUS2Ant", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["IESTATUS2"])
                {
                    auxPar.Value = oCM_VENSAnterior.IESTATUS2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@NOTA1Ant", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["INOTA1"])
                {
                    auxPar.Value = oCM_VENSAnterior.INOTA1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@NOTA2Ant", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["INOTA2"])
                {
                    auxPar.Value = oCM_VENSAnterior.INOTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@PLAZOSAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["IPLAZOS"])
                {
                    auxPar.Value = oCM_VENSAnterior.IPLAZOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@SUGERIDOSAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["ISUGERIDOS"])
                {
                    auxPar.Value = oCM_VENSAnterior.ISUGERIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@IDAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_VENSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_FECHAAnt", OdbcType.Date);
                if (!(bool)oCM_VENSAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VENSAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_HORAAnt", OdbcType.VarChar);
                if (!(bool)oCM_VENSAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VENSAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@F_FACTURAAnt", OdbcType.Date);
                if (!(bool)oCM_VENSAnterior.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCM_VENSAnterior.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_VENS
  set

VENTA=@VENTA,

CLIENTE=@CLIENTE,

ESTATUS=@ESTATUS,

ESTATUS2=@ESTATUS2,

NOTA1=@NOTA1,

NOTA2=@NOTA2,

PLAZOS=@PLAZOS,

SUGERIDOS=@SUGERIDOS,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

F_FACTURA=@F_FACTURA
  where 

VENTA=@VENTAAnt and

CLIENTE=@CLIENTEAnt and

ESTATUS=@ESTATUSAnt and

ESTATUS2=@ESTATUS2Ant and

NOTA1=@NOTA1Ant and

NOTA2=@NOTA2Ant and

PLAZOS=@PLAZOSAnt and

SUGERIDOS=@SUGERIDOSAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt and

F_FACTURA=@F_FACTURAAnt
  ;";

                OdbcParameter[] arParms = new OdbcParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    OdbcHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    OdbcHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public CM_VENSBE seleccionarM_VENS(CM_VENSBE oCM_VENS, OdbcTransaction st)
        {




            CM_VENSBE retorno = new CM_VENSBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;

                String CmdTxt = @"select * from M_VENS where
 VENTA=@VENTA    and
 CLIENTE=@CLIENTE    and
 ESTATUS=@ESTATUS    and
 ESTATUS2=@ESTATUS2    and
 NOTA1=@NOTA1    and
 NOTA2=@NOTA2    and
 PLAZOS=@PLAZOS    and
 SUGERIDOS=@SUGERIDOS    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA    and
 F_FACTURA=@F_FACTURA  ";


                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IVENTA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.ICLIENTE;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ESTATUS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IESTATUS;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ESTATUS2", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IESTATUS2;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@NOTA1", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.INOTA1;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@NOTA2", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.INOTA2;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@PLAZOS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IPLAZOS;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@SUGERIDOS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.ISUGERIDOS;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IID;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                auxPar.Value = oCM_VENS.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IID_HORA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@F_FACTURA", OdbcType.Date);
                auxPar.Value = oCM_VENS.IF_FACTURA;
                parts.Add(auxPar);




                OdbcParameter[] arParms = new OdbcParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OdbcDataReader dr;
                //if (st == null)
                    dr = OdbcHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                //else
                //    dr = OdbcHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


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

                    if (dr["F_FACTURA"] != System.DBNull.Value)
                    {
                        retorno.IF_FACTURA = (DateTime)(dr["F_FACTURA"]);
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









        //[AutoComplete]
        //public DataSet enlistarM_VENS()
        //{

        //    DataSet retorno;
        //    try
        //    {
        //        retorno = OdbcHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_VENS_enlistar");

        //        return retorno;
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }



        //}




        //[AutoComplete]
        //public DataSet enlistarCortoM_VENS()
        //{
        //    DataSet retorno;
        //    try
        //    {

        //        retorno = OdbcHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_VENS_enlistarCorto");

        //        return retorno;
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }



        //}



        [AutoComplete]
        public int ExisteM_VENS(CM_VENSBE oCM_VENS, OdbcTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;



                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IVENTA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ESTATUS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ESTATUS2", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IESTATUS2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@NOTA1", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.INOTA1;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@NOTA2", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.INOTA2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@PLAZOS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IPLAZOS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@SUGERIDOS", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.ISUGERIDOS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IID;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                auxPar.Value = oCM_VENS.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                auxPar.Value = oCM_VENS.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@F_FACTURA", OdbcType.Date);
                auxPar.Value = oCM_VENS.IF_FACTURA;
                parts.Add(auxPar);

                OdbcParameter[] arParms = new OdbcParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_VENS where

  VENTA=@VENTA    and

  CLIENTE=@CLIENTE    and

  ESTATUS=@ESTATUS    and

  ESTATUS2=@ESTATUS2    and

  NOTA1=@NOTA1    and

  NOTA2=@NOTA2    and

  PLAZOS=@PLAZOS    and

  SUGERIDOS=@SUGERIDOS    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA    and

  F_FACTURA=@F_FACTURA  
  );";






                OdbcDataReader dr;
                //if (st == null)
                    dr = OdbcHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                //else
                //    dr = OdbcHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



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




        //public CM_VENSBE AgregarM_VENS(CM_VENSBE oCM_VENS, OdbcTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteM_VENS(oCM_VENS, st);
        //        if (iRes == 1)
        //        {
        //            this.IComentario = "El M_VENS ya existe";
        //            return null;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return null;
        //        }
        //        return AgregarM_VENSD(oCM_VENS, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }
        //}


        public bool BorrarM_VENS(CM_VENSBE oCM_VENS, OdbcTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENS(oCM_VENS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VENS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_VENSD(oCM_VENS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_VENS(CM_VENSBE oCM_VENSNuevo, CM_VENSBE oCM_VENSAnterior, OdbcTransaction st)
        {
            try
            {
                int iRes = ExisteM_VENS(oCM_VENSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VENS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_VENSD(oCM_VENSNuevo, oCM_VENSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_VENSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public CM_VENSD(string connection)
        {
            this.sCadenaConexion = connection;
        }
    }
}
