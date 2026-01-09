

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CRECEPCIOND
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
        public bool AgregarRECEPCIOND(CRECEPCIONBE oCRECEPCION, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IVENTA"])
                {
                    auxPar.Value = oCRECEPCION.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCRECEPCION.ICOMPRA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCRECEPCION.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IDESC1"])
                {
                    auxPar.Value = oCRECEPCION.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["ILINEA"])
                {
                    auxPar.Value = oCRECEPCION.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IMARCA"])
                {
                    auxPar.Value = oCRECEPCION.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCRECEPCION.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCRECEPCION.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCRECEPCION.ISURTIDA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCRECEPCION.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ICOSTO"])
                {
                    auxPar.Value = oCRECEPCION.ICOSTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCRECEPCION.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCRECEPCION.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCRECEPCION.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCRECEPCION.isnull["IFECHA"])
                {
                    auxPar.Value = oCRECEPCION.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IESTATUS"])
                {
                    auxPar.Value = oCRECEPCION.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCRECEPCION.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCRECEPCION.IPARTIDA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ITRANSA"])
                {
                    auxPar.Value = oCRECEPCION.ITRANSA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCRECEPCION.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IMONEDA"])
                {
                    auxPar.Value = oCRECEPCION.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                if (!(bool)oCRECEPCION.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCRECEPCION.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IID"])
                {
                    auxPar.Value = oCRECEPCION.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCRECEPCION.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCRECEPCION.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["IID_HORA"])
                {
                    auxPar.Value = oCRECEPCION.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCRECEPCION.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCRECEPCION.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCRECEPCION.isnull["ILOTE"])
                {
                    auxPar.Value = oCRECEPCION.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                if (!(bool)oCRECEPCION.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCRECEPCION.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @" 
      (
    
VENTA,

COMPRA,

PRODUCTO,

DESC1,

LINEA,

MARCA,

PROVEEDOR,

CANTIDAD,

SURTIDA,

FALTANTE,

COSTO,

CARGOS_U,

IMPORTE,

IMPORTNETO,

FECHA,

ESTATUS,

PIEZAS,

PARTIDA,

TRANSA,

DESCUENTO,

MONEDA,

COSTO_INI,

ID,

ID_FECHA,

ID_HORA,

TRANS_LOTE,

CLIENTE,

LOTE,

F_CADUCA
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

?
); ";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (strOleDbConn != "")
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
        public bool BorrarRECEPCIOND(CRECEPCIONBE oCRECEPCION, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IDESC1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ILINEA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IMARCA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ISURTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOSTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICARGOS_U;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IIMPORTNETO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IPIEZAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IPARTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ITRANSA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IMONEDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOSTO_INI;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ITRANS_LOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ILOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IF_CADUCA;
                parts.Add(auxPar);



                string commandText = @"  Delete from RECEPCION
  where

  VENTA=@VENTA and 

  COMPRA=@COMPRA and 

  PRODUCTO=@PRODUCTO and 

  DESC1=@DESC1 and 

  LINEA=@LINEA and 

  MARCA=@MARCA and 

  PROVEEDOR=@PROVEEDOR and 

  CANTIDAD=@CANTIDAD and 

  SURTIDA=@SURTIDA and 

  FALTANTE=@FALTANTE and 

  COSTO=@COSTO and 

  CARGOS_U=@CARGOS_U and 

  IMPORTE=@IMPORTE and 

  IMPORTNETO=@IMPORTNETO and 

  FECHA=@FECHA and 

  ESTATUS=@ESTATUS and 

  PIEZAS=@PIEZAS and 

  PARTIDA=@PARTIDA and 

  TRANSA=@TRANSA and 

  DESCUENTO=@DESCUENTO and 

  MONEDA=@MONEDA and 

  COSTO_INI=@COSTO_INI and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA and 

  TRANS_LOTE=@TRANS_LOTE and 

  CLIENTE=@CLIENTE and 

  LOTE=@LOTE and 

  F_CADUCA=@F_CADUCA
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
        public bool CambiarRECEPCIOND(CRECEPCIONBE oCRECEPCIONNuevo, CRECEPCIONBE oCRECEPCIONAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IDESC1"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["ILINEA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IMARCA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ISURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ICOSTO"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCRECEPCIONNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ITRANSA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IMONEDA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                if (!(bool)oCRECEPCIONNuevo.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IID"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCRECEPCIONNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONNuevo.isnull["ILOTE"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                if (!(bool)oCRECEPCIONNuevo.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCRECEPCIONNuevo.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENTAAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRAAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTOAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC1Ant", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IDESC1"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEAAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["ILINEA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCAAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IMARCA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDORAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDADAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDAAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ISURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTEAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ICOSTO"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_UAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETOAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAAnt", OleDbType.Date);
                if (!(bool)oCRECEPCIONAnterior.isnull["IFECHA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUSAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IESTATUS"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZASAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDAAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSAAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ITRANSA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTOAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDAAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IMONEDA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_INIAnt", OleDbType.Double);
                if (!(bool)oCRECEPCIONAnterior.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCRECEPCIONAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTEAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTEAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOTEAnt", OleDbType.VarChar);
                if (!(bool)oCRECEPCIONAnterior.isnull["ILOTE"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@F_CADUCAAnt", OleDbType.Date);
                if (!(bool)oCRECEPCIONAnterior.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCRECEPCIONAnterior.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  RECEPCION
  set

VENTA=@VENTA,

COMPRA=@COMPRA,

PRODUCTO=@PRODUCTO,

DESC1=@DESC1,

LINEA=@LINEA,

MARCA=@MARCA,

PROVEEDOR=@PROVEEDOR,

CANTIDAD=@CANTIDAD,

SURTIDA=@SURTIDA,

FALTANTE=@FALTANTE,

COSTO=@COSTO,

CARGOS_U=@CARGOS_U,

IMPORTE=@IMPORTE,

IMPORTNETO=@IMPORTNETO,

FECHA=@FECHA,

ESTATUS=@ESTATUS,

PIEZAS=@PIEZAS,

PARTIDA=@PARTIDA,

TRANSA=@TRANSA,

DESCUENTO=@DESCUENTO,

MONEDA=@MONEDA,

COSTO_INI=@COSTO_INI,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

TRANS_LOTE=@TRANS_LOTE,

CLIENTE=@CLIENTE,

LOTE=@LOTE,

F_CADUCA=@F_CADUCA
  where 

VENTA=@VENTAAnt and

COMPRA=@COMPRAAnt and

PRODUCTO=@PRODUCTOAnt and

DESC1=@DESC1Ant and

LINEA=@LINEAAnt and

MARCA=@MARCAAnt and

PROVEEDOR=@PROVEEDORAnt and

CANTIDAD=@CANTIDADAnt and

SURTIDA=@SURTIDAAnt and

FALTANTE=@FALTANTEAnt and

COSTO=@COSTOAnt and

CARGOS_U=@CARGOS_UAnt and

IMPORTE=@IMPORTEAnt and

IMPORTNETO=@IMPORTNETOAnt and

FECHA=@FECHAAnt and

ESTATUS=@ESTATUSAnt and

PIEZAS=@PIEZASAnt and

PARTIDA=@PARTIDAAnt and

TRANSA=@TRANSAAnt and

DESCUENTO=@DESCUENTOAnt and

MONEDA=@MONEDAAnt and

COSTO_INI=@COSTO_INIAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt and

TRANS_LOTE=@TRANS_LOTEAnt and

CLIENTE=@CLIENTEAnt and

LOTE=@LOTEAnt and

F_CADUCA=@F_CADUCAAnt
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
        public CRECEPCIONBE seleccionarRECEPCION(CRECEPCIONBE oCRECEPCION, OleDbTransaction st)
        {




            CRECEPCIONBE retorno = new CRECEPCIONBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from RECEPCION where
 VENTA=@VENTA    and
 COMPRA=@COMPRA    and
 PRODUCTO=@PRODUCTO    and
 DESC1=@DESC1    and
 LINEA=@LINEA    and
 MARCA=@MARCA    and
 PROVEEDOR=@PROVEEDOR    and
 CANTIDAD=@CANTIDAD    and
 SURTIDA=@SURTIDA    and
 FALTANTE=@FALTANTE    and
 COSTO=@COSTO    and
 CARGOS_U=@CARGOS_U    and
 IMPORTE=@IMPORTE    and
 IMPORTNETO=@IMPORTNETO    and
 FECHA=@FECHA    and
 ESTATUS=@ESTATUS    and
 PIEZAS=@PIEZAS    and
 PARTIDA=@PARTIDA    and
 TRANSA=@TRANSA    and
 DESCUENTO=@DESCUENTO    and
 MONEDA=@MONEDA    and
 COSTO_INI=@COSTO_INI    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA    and
 TRANS_LOTE=@TRANS_LOTE    and
 CLIENTE=@CLIENTE    and
 LOTE=@LOTE    and
 F_CADUCA=@F_CADUCA  ";


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IVENTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOMPRA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IPRODUCTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IDESC1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ILINEA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IMARCA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IPROVEEDOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICANTIDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ISURTIDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IFALTANTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOSTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICARGOS_U;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IIMPORTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IIMPORTNETO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IFECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IESTATUS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IPIEZAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IPARTIDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ITRANSA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IDESCUENTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IMONEDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOSTO_INI;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IID_HORA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ITRANS_LOTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ICLIENTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ILOTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IF_CADUCA;
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

                    if (dr["COMPRA"] != System.DBNull.Value)
                    {
                        retorno.ICOMPRA = (double)(dr["COMPRA"]);
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESC1 = (string)(dr["DESC1"]);
                    }

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        retorno.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        retorno.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR = (string)(dr["PROVEEDOR"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (double)(dr["CANTIDAD"]);
                    }

                    if (dr["SURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDA = (double)(dr["SURTIDA"]);
                    }

                    if (dr["FALTANTE"] != System.DBNull.Value)
                    {
                        retorno.IFALTANTE = (double)(dr["FALTANTE"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (double)(dr["COSTO"]);
                    }

                    if (dr["CARGOS_U"] != System.DBNull.Value)
                    {
                        retorno.ICARGOS_U = (double)(dr["CARGOS_U"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (double)(dr["IMPORTE"]);
                    }

                    if (dr["IMPORTNETO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTNETO = (double)(dr["IMPORTNETO"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (double)(dr["PIEZAS"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = (double)(dr["PARTIDA"]);
                    }

                    if (dr["TRANSA"] != System.DBNull.Value)
                    {
                        retorno.ITRANSA = (double)(dr["TRANSA"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (double)(dr["DESCUENTO"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        retorno.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    if (dr["COSTO_INI"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO_INI = (double)(dr["COSTO_INI"]);
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

                    if (dr["TRANS_LOTE"] != System.DBNull.Value)
                    {
                        retorno.ITRANS_LOTE = (string)(dr["TRANS_LOTE"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["F_CADUCA"] != System.DBNull.Value)
                    {
                        retorno.IF_CADUCA = (DateTime)(dr["F_CADUCA"]);
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
        public DataSet enlistarRECEPCION()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RECEPCION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoRECEPCION()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RECEPCION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteRECEPCION(CRECEPCIONBE oCRECEPCION, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IDESC1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ILINEA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IMARCA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ISURTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOSTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICARGOS_U;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IIMPORTNETO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IPIEZAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IPARTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ITRANSA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                auxPar.Value = oCRECEPCION.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IMONEDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                auxPar.Value = oCRECEPCION.ICOSTO_INI;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ITRANS_LOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                auxPar.Value = oCRECEPCION.ILOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                auxPar.Value = oCRECEPCION.IF_CADUCA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from RECEPCION where

  VENTA=@VENTA    and

  COMPRA=@COMPRA    and

  PRODUCTO=@PRODUCTO    and

  DESC1=@DESC1    and

  LINEA=@LINEA    and

  MARCA=@MARCA    and

  PROVEEDOR=@PROVEEDOR    and

  CANTIDAD=@CANTIDAD    and

  SURTIDA=@SURTIDA    and

  FALTANTE=@FALTANTE    and

  COSTO=@COSTO    and

  CARGOS_U=@CARGOS_U    and

  IMPORTE=@IMPORTE    and

  IMPORTNETO=@IMPORTNETO    and

  FECHA=@FECHA    and

  ESTATUS=@ESTATUS    and

  PIEZAS=@PIEZAS    and

  PARTIDA=@PARTIDA    and

  TRANSA=@TRANSA    and

  DESCUENTO=@DESCUENTO    and

  MONEDA=@MONEDA    and

  COSTO_INI=@COSTO_INI    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA    and

  TRANS_LOTE=@TRANS_LOTE    and

  CLIENTE=@CLIENTE    and

  LOTE=@LOTE    and

  F_CADUCA=@F_CADUCA  
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




        //public CRECEPCIONBE AgregarRECEPCION(CRECEPCIONBE oCRECEPCION, OleDbTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteRECEPCION(oCRECEPCION, st);
        //        if (iRes == 1)
        //        {
        //            this.IComentario = "El RECEPCION ya existe";
        //            return null;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return null;
        //        }
        //        return AgregarRECEPCIOND(oCRECEPCION, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }
        //}


        public bool BorrarRECEPCION(CRECEPCIONBE oCRECEPCION, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteRECEPCION(oCRECEPCION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RECEPCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarRECEPCIOND(oCRECEPCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarRECEPCION(CRECEPCIONBE oCRECEPCIONNuevo, CRECEPCIONBE oCRECEPCIONAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteRECEPCION(oCRECEPCIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RECEPCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarRECEPCIOND(oCRECEPCIONNuevo, oCRECEPCIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CRECEPCIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
