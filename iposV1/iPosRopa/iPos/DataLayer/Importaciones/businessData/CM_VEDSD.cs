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
using DataLayer;
using System.Data.OleDb;

namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CM_VEDSD
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
        public bool AgregarM_VEDSD(CM_VEDSBE oCM_VEDS, string strTableName, OleDbTransaction st,string strOleDbConn)
        {
            int iRowsInserted;

            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VEDS.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VEDS.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_VEDS.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IDESC1"])
                {
                    auxPar.Value = oCM_VEDS.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OdbcType.Decimal);
                if (!(bool)oCM_VEDS.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_VEDS.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IDESC2"])
                {
                    auxPar.Value = oCM_VEDS.IDESC2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new OleDbParameter("@MAXIMO", OdbcType.Decimal);
                if (!(bool)oCM_VEDS.isnull["IMAXIMO"])
                {
                    auxPar.Value = oCM_VEDS.IMAXIMO;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OdbcType.Decimal);
                if (!(bool)oCM_VEDS.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_VEDS.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_VEDS.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@AUTORIZA", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_VEDS.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDAS", OdbcType.Decimal);
                if (!(bool)oCM_VEDS.isnull["ISURTIDAS"])
                {
                    auxPar.Value = oCM_VEDS.ISURTIDAS;
                }
                else
                {
                    auxPar.Value = 0;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROD2", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_VEDS.IPROD2;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REQUERIDAS", OdbcType.Decimal);
                if (!(bool)oCM_VEDS.isnull["IREQUERIDAS"])
                {
                    auxPar.Value = oCM_VEDS.IREQUERIDAS;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ID", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IID"])
                {
                    auxPar.Value = oCM_VEDS.IID;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OdbcType.Date);
                if (!(bool)oCM_VEDS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VEDS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VEDS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CVEUSER", OdbcType.VarChar);
                if (!(bool)oCM_VEDS.isnull["ICVEUSER"])
                {
                    auxPar.Value = oCM_VEDS.ICVEUSER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO '" + strTableName + @"'
      (
    
VENTA,

CLIENTE,

PRODUCTO,

DESC1,

CANTIDAD,

DESC2,

MAXIMO,

DESCUENTO,

CLASIFICA,

AUTORIZA,

SURTIDAS,

PROD2,

REQUERIDAS,

ID,

ID_FECHA,

ID_HORA,

CVEUSER
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

?
); ";


                /*
                 * ,


MAXIMO,

DESCUENTO,

CLASIFICA,

AUTORIZA,

SURTIDAS,

PROD2,

REQUERIDAS,

ID,

ID_FECHA,

ID_HORA
                 * 
                 * 
                 * 
                 * 
                 * 
                   ,

               @DESC2,

               @MAXIMO,

               @DESCUENTO,

               @CLASIFICA,

               @AUTORIZA,

               @SURTIDAS,

               @PROD2,

               @REQUERIDAS,

               @ID,

               @ID_FECHA,

               @ID_HORA             
               */





                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (strOleDbConn != "")
                    iRowsInserted = OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                else
                    iRowsInserted = OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return (iRowsInserted > 0);

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool BorrarM_VEDSD(CM_VEDSBE oCM_VEDS, OdbcTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;



                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IVENTA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@PRODUCTO", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@DESC1", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IDESC1;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CANTIDAD", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@DESC2", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IDESC2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@MAXIMO", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IMAXIMO;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@DESCUENTO", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CLASIFICA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.ICLASIFICA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@AUTORIZA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IAUTORIZA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@SURTIDAS", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.ISURTIDAS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@PROD2", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IPROD2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@REQUERIDAS", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IREQUERIDAS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IID;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                auxPar.Value = oCM_VEDS.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IID_HORA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_VEDS
  where

  VENTA=@VENTA and 

  CLIENTE=@CLIENTE and 

  PRODUCTO=@PRODUCTO and 

  DESC1=@DESC1 and 

  CANTIDAD=@CANTIDAD and 

  DESC2=@DESC2 and 

  MAXIMO=@MAXIMO and 

  DESCUENTO=@DESCUENTO and 

  CLASIFICA=@CLASIFICA and 

  AUTORIZA=@AUTORIZA and 

  SURTIDAS=@SURTIDAS and 

  PROD2=@PROD2 and 

  REQUERIDAS=@REQUERIDAS and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA
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
        public bool CambiarM_VEDSD(CM_VEDSBE oCM_VEDSNuevo, CM_VEDSBE oCM_VEDSAnterior, OdbcTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;



                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VEDSNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@PRODUCTO", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@DESC1", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IDESC1"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CANTIDAD", OdbcType.Decimal);
                if (!(bool)oCM_VEDSNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_VEDSNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@DESC2", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IDESC2"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IDESC2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@MAXIMO", OdbcType.Decimal);
                if (!(bool)oCM_VEDSNuevo.isnull["IMAXIMO"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IMAXIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@DESCUENTO", OdbcType.Decimal);
                if (!(bool)oCM_VEDSNuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CLASIFICA", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_VEDSNuevo.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@AUTORIZA", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@SURTIDAS", OdbcType.Decimal);
                if (!(bool)oCM_VEDSNuevo.isnull["ISURTIDAS"])
                {
                    auxPar.Value = oCM_VEDSNuevo.ISURTIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@PROD2", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IPROD2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@REQUERIDAS", OdbcType.Decimal);
                if (!(bool)oCM_VEDSNuevo.isnull["IREQUERIDAS"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IREQUERIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                if (!(bool)oCM_VEDSNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                if (!(bool)oCM_VEDSNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VEDSNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@VENTAAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CLIENTEAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_VEDSAnterior.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@PRODUCTOAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@DESC1Ant", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IDESC1"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CANTIDADAnt", OdbcType.Decimal);
                if (!(bool)oCM_VEDSAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_VEDSAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@DESC2Ant", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IDESC2"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IDESC2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@MAXIMOAnt", OdbcType.Decimal);
                if (!(bool)oCM_VEDSAnterior.isnull["IMAXIMO"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IMAXIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@DESCUENTOAnt", OdbcType.Decimal);
                if (!(bool)oCM_VEDSAnterior.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@CLASIFICAAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCM_VEDSAnterior.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@AUTORIZAAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IAUTORIZA"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IAUTORIZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@SURTIDASAnt", OdbcType.Decimal);
                if (!(bool)oCM_VEDSAnterior.isnull["ISURTIDAS"])
                {
                    auxPar.Value = oCM_VEDSAnterior.ISURTIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@PROD2Ant", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IPROD2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@REQUERIDASAnt", OdbcType.Decimal);
                if (!(bool)oCM_VEDSAnterior.isnull["IREQUERIDAS"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IREQUERIDAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@IDAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_FECHAAnt", OdbcType.Date);
                if (!(bool)oCM_VEDSAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OdbcParameter("@ID_HORAAnt", OdbcType.VarChar);
                if (!(bool)oCM_VEDSAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_VEDSAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_VEDS
  set

VENTA=@VENTA,

CLIENTE=@CLIENTE,

PRODUCTO=@PRODUCTO,

DESC1=@DESC1,

CANTIDAD=@CANTIDAD,

DESC2=@DESC2,

MAXIMO=@MAXIMO,

DESCUENTO=@DESCUENTO,

CLASIFICA=@CLASIFICA,

AUTORIZA=@AUTORIZA,

SURTIDAS=@SURTIDAS,

PROD2=@PROD2,

REQUERIDAS=@REQUERIDAS,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA
  where 

VENTA=@VENTAAnt and

CLIENTE=@CLIENTEAnt and

PRODUCTO=@PRODUCTOAnt and

DESC1=@DESC1Ant and

CANTIDAD=@CANTIDADAnt and

DESC2=@DESC2Ant and

MAXIMO=@MAXIMOAnt and

DESCUENTO=@DESCUENTOAnt and

CLASIFICA=@CLASIFICAAnt and

AUTORIZA=@AUTORIZAAnt and

SURTIDAS=@SURTIDASAnt and

PROD2=@PROD2Ant and

REQUERIDAS=@REQUERIDASAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt
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
        public CM_VEDSBE seleccionarM_VEDS(CM_VEDSBE oCM_VEDS, OdbcTransaction st)
        {




            CM_VEDSBE retorno = new CM_VEDSBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;

                String CmdTxt = @"select * from M_VEDS where
 VENTA=@VENTA    and
 CLIENTE=@CLIENTE    and
 PRODUCTO=@PRODUCTO    and
 DESC1=@DESC1    and
 CANTIDAD=@CANTIDAD    and
 DESC2=@DESC2    and
 MAXIMO=@MAXIMO    and
 DESCUENTO=@DESCUENTO    and
 CLASIFICA=@CLASIFICA    and
 AUTORIZA=@AUTORIZA    and
 SURTIDAS=@SURTIDAS    and
 PROD2=@PROD2    and
 REQUERIDAS=@REQUERIDAS    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA  ";


                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IVENTA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.ICLIENTE;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@PRODUCTO", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IPRODUCTO;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@DESC1", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IDESC1;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@CANTIDAD", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.ICANTIDAD;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@DESC2", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IDESC2;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@MAXIMO", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IMAXIMO;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@DESCUENTO", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IDESCUENTO;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@CLASIFICA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.ICLASIFICA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@AUTORIZA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IAUTORIZA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@SURTIDAS", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.ISURTIDAS;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@PROD2", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IPROD2;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@REQUERIDAS", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IREQUERIDAS;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IID;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                auxPar.Value = oCM_VEDS.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IID_HORA;
                parts.Add(auxPar);




                OdbcParameter[] arParms = new OdbcParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OdbcDataReader dr;
                //if(st==null)
                dr = OdbcHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                //else
                //dr = OdbcHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


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

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESC1 = (string)(dr["DESC1"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["DESC2"] != System.DBNull.Value)
                    {
                        retorno.IDESC2 = (string)(dr["DESC2"]);
                    }

                    if (dr["MAXIMO"] != System.DBNull.Value)
                    {
                        retorno.IMAXIMO = (decimal)(dr["MAXIMO"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["AUTORIZA"] != System.DBNull.Value)
                    {
                        retorno.IAUTORIZA = (string)(dr["AUTORIZA"]);
                    }

                    if (dr["SURTIDAS"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDAS = (decimal)(dr["SURTIDAS"]);
                    }

                    if (dr["PROD2"] != System.DBNull.Value)
                    {
                        retorno.IPROD2 = (string)(dr["PROD2"]);
                    }

                    if (dr["REQUERIDAS"] != System.DBNull.Value)
                    {
                        retorno.IREQUERIDAS = (decimal)(dr["REQUERIDAS"]);
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









        //[AutoComplete]
        //        public DataSet enlistarM_VEDS()
        //        {

        //    DataSet retorno;
        //        try
        //            {
        //            retorno = OdbcHelper.ExecuteDataset(this.sCadenaConexion,CommandType.StoredProcedure, "SisGen_M_VEDS_enlistar");

        //    return retorno;
        //            }
        //            catch (Exception e)
        //            {
        //                this.iComentario=e.Message + e.StackTrace;
        //                return null;
        //            }



        //        }




        //        [AutoComplete]
        //        public DataSet enlistarCortoM_VEDS()
        //        {
        //            DataSet retorno;
        //            try
        //            {

        //                retorno = OdbcHelper.ExecuteDataset(this.sCadenaConexion,CommandType.StoredProcedure, "SisGen_M_VEDS_enlistarCorto");

        //                return retorno;
        //            }
        //            catch (Exception e)
        //            {
        //                this.iComentario=e.Message + e.StackTrace;
        //                return null;
        //            }



        //        }



        [AutoComplete]
        public int ExisteM_VEDS(CM_VEDSBE oCM_VEDS, OdbcTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OdbcParameter auxPar;



                auxPar = new OdbcParameter("@VENTA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IVENTA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CLIENTE", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@PRODUCTO", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@DESC1", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IDESC1;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CANTIDAD", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@DESC2", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IDESC2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@MAXIMO", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IMAXIMO;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@DESCUENTO", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@CLASIFICA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.ICLASIFICA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@AUTORIZA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IAUTORIZA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@SURTIDAS", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.ISURTIDAS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@PROD2", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IPROD2;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@REQUERIDAS", OdbcType.Decimal);
                auxPar.Value = oCM_VEDS.IREQUERIDAS;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IID;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_FECHA", OdbcType.Date);
                auxPar.Value = oCM_VEDS.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OdbcParameter("@ID_HORA", OdbcType.VarChar);
                auxPar.Value = oCM_VEDS.IID_HORA;
                parts.Add(auxPar);

                OdbcParameter[] arParms = new OdbcParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_VEDS where

  VENTA=@VENTA    and

  CLIENTE=@CLIENTE    and

  PRODUCTO=@PRODUCTO    and

  DESC1=@DESC1    and

  CANTIDAD=@CANTIDAD    and

  DESC2=@DESC2    and

  MAXIMO=@MAXIMO    and

  DESCUENTO=@DESCUENTO    and

  CLASIFICA=@CLASIFICA    and

  AUTORIZA=@AUTORIZA    and

  SURTIDAS=@SURTIDAS    and

  PROD2=@PROD2    and

  REQUERIDAS=@REQUERIDAS    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA  
  );";






                OdbcDataReader dr;
                //if(st==null)
                dr = OdbcHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                //else
                //dr = OdbcHelper.ExecuteReader(st,CommandType.Text, commandText,arParms);



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




        //public bool AgregarM_VEDS(CM_VEDSBE oCM_VEDS, OdbcTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteM_VEDS(oCM_VEDS, st);
        //        if (iRes == 1)
        //        {
        //            this.IComentario = "El M_VEDS ya existe";
        //            return false;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return false;
        //        }
        //        return AgregarM_VEDSD(oCM_VEDS, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return false;
        //    }
        //}


        public bool BorrarM_VEDS(CM_VEDSBE oCM_VEDS, OdbcTransaction st)
        {
            try
            {
                int iRes = ExisteM_VEDS(oCM_VEDS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VEDS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_VEDSD(oCM_VEDS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_VEDS(CM_VEDSBE oCM_VEDSNuevo, CM_VEDSBE oCM_VEDSAnterior, OdbcTransaction st)
        {
            try
            {
                int iRes = ExisteM_VEDS(oCM_VEDSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_VEDS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_VEDSD(oCM_VEDSNuevo, oCM_VEDSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_VEDSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
