

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.Odbc;
using DataLayer;

namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CMOVTOD
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
        public CMOVTOBE AgregarMOVTOD(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["IID"])
                {
                    auxPar.Value = oCMOVTO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVTO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVTO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMOVTO.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                if (!(bool)oCMOVTO.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCMOVTO.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["IESTATUSMOVTOID"])
                {
                    auxPar.Value = oCMOVTO.IESTATUSMOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCMOVTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCMOVTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCMOVTO.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCMOVTO.isnull["ILOTE"])
                {
                    auxPar.Value = oCMOVTO.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCMOVTO.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCMOVTO.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADSURTIDA"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADSURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADFALTANTE"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADDEVUELTA"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADDEVUELTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADSALDO"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADSALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOLISTA", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IPRECIOLISTA"])
                {
                    auxPar.Value = oCMOVTO.IPRECIOLISTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTOPORCENTAJE", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IDESCUENTOPORCENTAJE"])
                {
                    auxPar.Value = oCMOVTO.IDESCUENTOPORCENTAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCMOVTO.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IPRECIO"])
                {
                    auxPar.Value = oCMOVTO.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCMOVTO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBTOTAL", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ISUBTOTAL"])
                {
                    auxPar.Value = oCMOVTO.ISUBTOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IVA", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IIVA"])
                {
                    auxPar.Value = oCMOVTO.IIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ITOTAL"])
                {
                    auxPar.Value = oCMOVTO.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICOSTO"])
                {
                    auxPar.Value = oCMOVTO.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTOIMPORTE", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICOSTOIMPORTE"])
                {
                    auxPar.Value = oCMOVTO.ICOSTOIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICARGO"])
                {
                    auxPar.Value = oCMOVTO.ICARGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IABONO"])
                {
                    auxPar.Value = oCMOVTO.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ISALDO"])
                {
                    auxPar.Value = oCMOVTO.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MOVTO
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

DOCTOID,

PARTIDA,

ESTATUSMOVTOID,

FECHA,

FECHAHORA,

PRODUCTOID,

LOTE,

FECHAVENCE,

CANTIDAD,

CANTIDADSURTIDA,

CANTIDADFALTANTE,

CANTIDADDEVUELTA,

CANTIDADSALDO,

PRECIOLISTA,

DESCUENTOPORCENTAJE,

DESCUENTO,

PRECIO,

IMPORTE,

SUBTOTAL,

IVA,

TOTAL,

COSTO,

COSTOIMPORTE,

CARGO,

ABONO,

SALDO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOID,

@PARTIDA,

@ESTATUSMOVTOID,

@FECHA,

@PRODUCTOID,

@LOTE,

@FECHAVENCE,

@CANTIDAD,

@CANTIDADSURTIDA,

@CANTIDADFALTANTE,

@CANTIDADDEVUELTA,

@CANTIDADSALDO,

@PRECIOLISTA,

@DESCUENTOPORCENTAJE,

@DESCUENTO,

@PRECIO,

@IMPORTE,

@SUBTOTAL,

@IVA,

@TOTAL,

@COSTO,

@COSTOIMPORTE,

@CARGO,

@ABONO,

@SALDO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMOVTO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarMOVTOD(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MOVTO
  where

  ID=@ID
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool CambiarMOVTOD(CMOVTOBE oCMOVTONuevo, CMOVTOBE oCMOVTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCMOVTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMOVTONuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                if (!(bool)oCMOVTONuevo.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCMOVTONuevo.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IESTATUSMOVTOID"])
                {
                    auxPar.Value = oCMOVTONuevo.IESTATUSMOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCMOVTONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCMOVTONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCMOVTONuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCMOVTONuevo.isnull["ILOTE"])
                {
                    auxPar.Value = oCMOVTONuevo.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCMOVTONuevo.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCMOVTONuevo.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCMOVTONuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICANTIDADSURTIDA"])
                {
                    auxPar.Value = oCMOVTONuevo.ICANTIDADSURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICANTIDADFALTANTE"])
                {
                    auxPar.Value = oCMOVTONuevo.ICANTIDADFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICANTIDADDEVUELTA"])
                {
                    auxPar.Value = oCMOVTONuevo.ICANTIDADDEVUELTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICANTIDADSALDO"])
                {
                    auxPar.Value = oCMOVTONuevo.ICANTIDADSALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIOLISTA", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IPRECIOLISTA"])
                {
                    auxPar.Value = oCMOVTONuevo.IPRECIOLISTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCUENTOPORCENTAJE", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IDESCUENTOPORCENTAJE"])
                {
                    auxPar.Value = oCMOVTONuevo.IDESCUENTOPORCENTAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCMOVTONuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IPRECIO"])
                {
                    auxPar.Value = oCMOVTONuevo.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCMOVTONuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUBTOTAL", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ISUBTOTAL"])
                {
                    auxPar.Value = oCMOVTONuevo.ISUBTOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IVA", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IIVA"])
                {
                    auxPar.Value = oCMOVTONuevo.IIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCMOVTONuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICOSTO"])
                {
                    auxPar.Value = oCMOVTONuevo.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTOIMPORTE", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICOSTOIMPORTE"])
                {
                    auxPar.Value = oCMOVTONuevo.ICOSTOIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARGO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICARGO"])
                {
                    auxPar.Value = oCMOVTONuevo.ICARGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IABONO"])
                {
                    auxPar.Value = oCMOVTONuevo.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCMOVTONuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMOVTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMOVTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MOVTO
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOID=@DOCTOID,

PARTIDA=@PARTIDA,

ESTATUSMOVTOID=@ESTATUSMOVTOID,

FECHA=@FECHA,

PRODUCTOID=@PRODUCTOID,

LOTE=@LOTE,

FECHAVENCE=@FECHAVENCE,

CANTIDAD=@CANTIDAD,

CANTIDADSURTIDA=@CANTIDADSURTIDA,

CANTIDADFALTANTE=@CANTIDADFALTANTE,

CANTIDADDEVUELTA=@CANTIDADDEVUELTA,

CANTIDADSALDO=@CANTIDADSALDO,

PRECIOLISTA=@PRECIOLISTA,

DESCUENTOPORCENTAJE=@DESCUENTOPORCENTAJE,

DESCUENTO=@DESCUENTO,

PRECIO=@PRECIO,

IMPORTE=@IMPORTE,

SUBTOTAL=@SUBTOTAL,

IVA=@IVA,

TOTAL=@TOTAL,

COSTO=@COSTO,

COSTOIMPORTE=@COSTOIMPORTE,

CARGO=@CARGO,

ABONO=@ABONO,

SALDO=@SALDO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarCAJASPIEZASMOVTOD(CMOVTOBE oCMOVTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CAJAS", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["ICAJAS"])
                {
                    auxPar.Value = oCMOVTONuevo.ICAJAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PIEZAS", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCMOVTONuevo.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PZACAJA", FbDbType.Numeric);
                if (!(bool)oCMOVTONuevo.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCMOVTONuevo.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCMOVTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MOVTO
  set
    CAJAS = @CAJAS,
    PIEZAS =@PIEZAS,
    PZACAJA = @PZACAJA
  where ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        [AutoComplete]
        public CMOVTOBE seleccionarMOVTO(CMOVTOBE oCMOVTO, FbTransaction st)
        {




            CMOVTOBE retorno = new CMOVTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVTO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["ESTATUSMOVTOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSMOVTOID = (long)(dr["ESTATUSMOVTOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSURTIDA = (decimal)(dr["CANTIDADSURTIDA"]);
                    }

                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADFALTANTE = (decimal)(dr["CANTIDADFALTANTE"]);
                    }

                    if (dr["CANTIDADDEVUELTA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDEVUELTA = (decimal)(dr["CANTIDADDEVUELTA"]);
                    }

                    if (dr["CANTIDADSALDO"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSALDO = (decimal)(dr["CANTIDADSALDO"]);
                    }

                    if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOLISTA = (decimal)(dr["PRECIOLISTA"]);
                    }

                    if (dr["DESCUENTOPORCENTAJE"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTOPORCENTAJE = (decimal)(dr["DESCUENTOPORCENTAJE"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        retorno.IIVA = (decimal)(dr["IVA"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (decimal)(dr["COSTO"]);
                    }

                    if (dr["COSTOIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOIMPORTE = (decimal)(dr["COSTOIMPORTE"]);
                    }

                    if (dr["CARGO"] != System.DBNull.Value)
                    {
                        retorno.ICARGO = (decimal)(dr["CARGO"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = short.Parse(dr["PARTIDA"].ToString());
                    }


                    if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
                    }



                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }
                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }
                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }
                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["IEPS"] != System.DBNull.Value)
                    {
                        retorno.IIEPS = (decimal)(dr["IEPS"]);
                    }


                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
                    }

                    if (dr["CLAVEPROD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPROD = (string)(dr["CLAVEPROD"]);
                    }

                    if (dr["MOVTOADJUNTOAID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOADJUNTOAID = (long)(dr["MOVTOADJUNTOAID"]);
                    }

                    if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                    }
                    if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
                    }

                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }
                    if (dr["COMISIONPORC"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONPORC = (decimal)(dr["COMISIONPORC"]);
                    }


                    if (dr["CANTIDADREVISADA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADREVISADA = (decimal)(dr["CANTIDADREVISADA"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }


                    if (dr["TIPOMAYOREOLINEAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMAYOREOLINEAID = (long)(dr["TIPOMAYOREOLINEAID"]);
                    }

                }
                else
                {
                    retorno = null;
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }









        [AutoComplete]
        public DataSet enlistarMOVTO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MOVTO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMOVTO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MOVTO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMOVTO(CMOVTOBE oCMOVTO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MOVTO where

  ID=@ID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public CMOVTOBE AgregarMOVTO(CMOVTOBE oCMOVTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVTO(oCMOVTO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MOVTO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMOVTOD(oCMOVTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMOVTO(CMOVTOBE oCMOVTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVTO(oCMOVTO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOVTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMOVTOD(oCMOVTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMOVTO(CMOVTOBE oCMOVTONuevo, CMOVTOBE oCMOVTOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVTO(oCMOVTOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOVTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMOVTOD(oCMOVTONuevo, oCMOVTOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool RECIBIRMOVTOD(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADSURTIDA"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADSURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["ITIPODIFERENCIAINVENTARIOID"])
                {
                    auxPar.Value = oCMOVTO.ITIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)oCMOVTO.isnull["ILOTE"])
                    auxPar.Value = oCMOVTO.ILOTE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCMOVTO.isnull["IFECHAVENCE"])
                    auxPar.Value = oCMOVTO.IFECHAVENCE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["ILOTEIMPORTADO"])
                {
                    auxPar.Value = oCMOVTO.ILOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["IPRECIO"])
                {
                    auxPar.Value = oCMOVTO.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Update movto set 
                                         PRECIO = @PRECIO,
                                         CANTIDADSURTIDA = @CANTIDADSURTIDA, cantidadfaltante = (@CANTIDAD - @CANTIDADSURTIDA),
                                         TIPODIFERENCIAINVENTARIOID = @TIPODIFERENCIAINVENTARIOID , LOTE = @LOTE, FECHAVENCE = @FECHAVENCE, LOTEIMPORTADO = @LOTEIMPORTADO where ID=@ID  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool PEDIRMOVTOD(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADFALTANTE"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["ITIPODIFERENCIAINVENTARIOID"])
                {
                    auxPar.Value = oCMOVTO.ITIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORDEN", FbDbType.BigInt);
                if (!(bool)oCMOVTO.isnull["IORDEN"])
                {
                    auxPar.Value = oCMOVTO.IORDEN;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Update movto set CANTIDADFALTANTE = @CANTIDADFALTANTE, CANTIDAD = @CANTIDAD,
                                         TIPODIFERENCIAINVENTARIOID = @TIPODIFERENCIAINVENTARIOID, ORDEN = @ORDEN where ID=@ID  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool REVISARMOVTOD(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                auxPar = new FbParameter("@CANTIDADREVISADA", FbDbType.Numeric);
                if (!(bool)oCMOVTO.isnull["ICANTIDADREVISADA"])
                {
                    auxPar.Value = oCMOVTO.ICANTIDADREVISADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Update movto set CANTIDADREVISADA = @CANTIDADREVISADA
                                        where ID=@ID  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarExistenciasExport(CMOVTOBE oCMOVTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@EXISTENCIASEXPORTADAS", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IEXISTENCIASEXPORTADAS"])
                {
                    auxPar.Value = oCMOVTONuevo.IEXISTENCIASEXPORTADAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCMOVTONuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                /*   string commandText = @"
     update  MOVTO
     set
        EXISTENCIASEXPORTADAS = @EXISTENCIASEXPORTADAS
     where 
          ID=@IDAnt
     ;";*/

                string commandText = @"
  update  PRODUCTO
  set
     EXISTENCIASEXPORTADAS = @EXISTENCIASEXPORTADAS
  where 
       ID=@PRODUCTOID AND EXISTENCIASEXPORTADAS = 'N'
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool AsignarRazonDescuentoCajero(CMOVTOBE oCMOVTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                auxPar = new FbParameter("@RAZONDESCUENTOCAJERO", FbDbType.VarChar);
                auxPar.Value = oCMOVTONuevo.IRAZONDESCUENTOCAJERO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTONuevo.IID;
                parts.Add(auxPar);



                string commandText = @"  Update movto set RAZONDESCUENTOCAJERO = @RAZONDESCUENTOCAJERO, PRECIOMANUALMASBAJO = 'S'
                                         where ID=@ID  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }








        public bool CambiarDescripcionesComodin(CMOVTOBE oCMOVTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (!(bool)oCMOVTONuevo.isnull["IDESCRIPCION1"])
                {
                    auxPar.Value = oCMOVTONuevo.IDESCRIPCION1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (!(bool)oCMOVTONuevo.isnull["IDESCRIPCION2"])
                {
                    auxPar.Value = oCMOVTONuevo.IDESCRIPCION2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (!(bool)oCMOVTONuevo.isnull["IDESCRIPCION3"])
                {
                    auxPar.Value = oCMOVTONuevo.IDESCRIPCION3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMOVTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCMOVTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MOVTO
  set
     DESCRIPCION1 = @DESCRIPCION1,
     DESCRIPCION2 = @DESCRIPCION2,
     DESCRIPCION3 = @DESCRIPCION3
  where 
       ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarTASAIVA(long MOVTOID, decimal TASAIVA, long PERSONAID, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = MOVTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = PERSONAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TASAIVA", FbDbType.Decimal);
                auxPar.Value = TASAIVA;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_CAMBIARTASAIVA";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }

                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarCOSTOENDOLAR(long MOVTOID, decimal COSTOENDOLAR, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = MOVTOID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@COSTOENDOLAR", FbDbType.Decimal);
                auxPar.Value = COSTOENDOLAR;
                parts.Add(auxPar);


                string commandText = @"UPDATE MOVTO SET COSTOENDOLAR = @COSTOENDOLAR, IMPORTEENDOLAR = COALESCE(@COSTOENDOLAR,0.00) * CANTIDAD WHERE ID = @MOVTOID";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarCantidadSurtida(long doctoId, decimal cantidadAEnviar, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Decimal);
                auxPar.Value = cantidadAEnviar;
                parts.Add(auxPar);


                string commandText = @"Update movto set CANTIDADSURTIDA = @CANTIDADSURTIDA, cantidadfaltante = (CANTIDAD - @CANTIDADSURTIDA)
 where ID=@ID   
";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarCantidadRevisada(long doctoId, decimal cantidadAEnviar, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CANTIDADREVISADA", FbDbType.Decimal);
                auxPar.Value = cantidadAEnviar;
                parts.Add(auxPar);


                string commandText = @"Update movto set CANTIDADREVISADA = @CANTIDADREVISADA
 where ID=@ID   
";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public ArrayList DOCTOIEPSVIEW(long DOCTOID, FbTransaction st)
        {


            ArrayList listaIEPS = new ArrayList();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = DOCTOID;
                parts.Add(auxPar);

                string commandText = @"SELECT * FROM DOCTOIEPSVIEW WHERE DOCTOID = @DOCTOID";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);


                while (dr.Read())
                {
                    Hashtable ht = new Hashtable();

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        ht.Add("DOCTOID", (long)(dr["DOCTOID"]));
                    }

                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        ht.Add("TASAIEPS", (decimal)(dr["TASAIEPS"]));
                    }

                    if (dr["SUMAIEPS"] != System.DBNull.Value)
                    {
                        ht.Add("SUMAIEPS", (decimal)(dr["SUMAIEPS"]));
                    }

                    listaIEPS.Add(ht);

                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return listaIEPS;


            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return listaIEPS;
            }
        }





        public CMOVTOBE[] seleccionarMOVTOSDEDOCTO(long doctoId, FbTransaction st)
        {


            ArrayList retArray = new ArrayList();

            CMOVTOBE retorno = new CMOVTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVTO where
 DOCTOID=@DOCTOID  ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CMOVTOBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["ESTATUSMOVTOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSMOVTOID = (long)(dr["ESTATUSMOVTOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSURTIDA = (decimal)(dr["CANTIDADSURTIDA"]);
                    }

                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADFALTANTE = (decimal)(dr["CANTIDADFALTANTE"]);
                    }

                    if (dr["CANTIDADDEVUELTA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDEVUELTA = (decimal)(dr["CANTIDADDEVUELTA"]);
                    }

                    if (dr["CANTIDADSALDO"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSALDO = (decimal)(dr["CANTIDADSALDO"]);
                    }

                    if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOLISTA = (decimal)(dr["PRECIOLISTA"]);
                    }

                    if (dr["DESCUENTOPORCENTAJE"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTOPORCENTAJE = (decimal)(dr["DESCUENTOPORCENTAJE"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        retorno.IIVA = (decimal)(dr["IVA"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (decimal)(dr["COSTO"]);
                    }

                    if (dr["COSTOIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOIMPORTE = (decimal)(dr["COSTOIMPORTE"]);
                    }

                    if (dr["CARGO"] != System.DBNull.Value)
                    {
                        retorno.ICARGO = (decimal)(dr["CARGO"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = short.Parse(dr["PARTIDA"].ToString());
                    }


                    if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
                    }



                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }
                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }
                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }
                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["IEPS"] != System.DBNull.Value)
                    {
                        retorno.IIEPS = (decimal)(dr["IEPS"]);
                    }


                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
                    }

                    if (dr["CLAVEPROD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPROD = (string)(dr["CLAVEPROD"]);
                    }
                    if (dr["MOVTOADJUNTOAID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOADJUNTOAID = (long)(dr["MOVTOADJUNTOAID"]);
                    }

                    if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                    }

                    retArray.Add(retorno);
                }



                CMOVTOBE[] ret = new CMOVTOBE[retArray.Count];
                retArray.CopyTo(ret, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return ret;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }







        public CMOVTOBE[] seleccionarMOVTOSPORDOCTOPRODUCTOPRECIO(long doctoId, long productoId, decimal precio, FbTransaction st)
        {


            ArrayList retArray = new ArrayList();

            CMOVTOBE retorno = new CMOVTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVTO where
                                    DOCTOID=@DOCTOID  and PRODUCTOID = @PRODUCTOID AND PRECIO = @PRECIO";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Decimal);
                auxPar.Value = precio;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CMOVTOBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["ESTATUSMOVTOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSMOVTOID = (long)(dr["ESTATUSMOVTOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSURTIDA = (decimal)(dr["CANTIDADSURTIDA"]);
                    }

                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADFALTANTE = (decimal)(dr["CANTIDADFALTANTE"]);
                    }

                    if (dr["CANTIDADDEVUELTA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDEVUELTA = (decimal)(dr["CANTIDADDEVUELTA"]);
                    }

                    if (dr["CANTIDADSALDO"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSALDO = (decimal)(dr["CANTIDADSALDO"]);
                    }

                    if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOLISTA = (decimal)(dr["PRECIOLISTA"]);
                    }

                    if (dr["DESCUENTOPORCENTAJE"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTOPORCENTAJE = (decimal)(dr["DESCUENTOPORCENTAJE"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        retorno.IIVA = (decimal)(dr["IVA"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (decimal)(dr["COSTO"]);
                    }

                    if (dr["COSTOIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOIMPORTE = (decimal)(dr["COSTOIMPORTE"]);
                    }

                    if (dr["CARGO"] != System.DBNull.Value)
                    {
                        retorno.ICARGO = (decimal)(dr["CARGO"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = short.Parse(dr["PARTIDA"].ToString());
                    }


                    if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
                    }



                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }
                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }
                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }
                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["IEPS"] != System.DBNull.Value)
                    {
                        retorno.IIEPS = (decimal)(dr["IEPS"]);
                    }


                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
                    }

                    if (dr["CLAVEPROD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPROD = (string)(dr["CLAVEPROD"]);
                    }
                    if (dr["MOVTOADJUNTOAID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOADJUNTOAID = (long)(dr["MOVTOADJUNTOAID"]);
                    }

                    if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                    }

                    retArray.Add(retorno);
                }




                CMOVTOBE[] ret = new CMOVTOBE[retArray.Count];
                retArray.CopyTo(ret, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return ret;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public CMOVTOBE seleccionarMOVTOADJUNTO(CMOVTOBE oCMOVTO, FbTransaction st)
        {




            CMOVTOBE retorno = new CMOVTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVTO where
 MOVTOADJUNTOAID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["ESTATUSMOVTOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSMOVTOID = (long)(dr["ESTATUSMOVTOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSURTIDA = (decimal)(dr["CANTIDADSURTIDA"]);
                    }

                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADFALTANTE = (decimal)(dr["CANTIDADFALTANTE"]);
                    }

                    if (dr["CANTIDADDEVUELTA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDEVUELTA = (decimal)(dr["CANTIDADDEVUELTA"]);
                    }

                    if (dr["CANTIDADSALDO"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSALDO = (decimal)(dr["CANTIDADSALDO"]);
                    }

                    if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOLISTA = (decimal)(dr["PRECIOLISTA"]);
                    }

                    if (dr["DESCUENTOPORCENTAJE"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTOPORCENTAJE = (decimal)(dr["DESCUENTOPORCENTAJE"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        retorno.IIVA = (decimal)(dr["IVA"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (decimal)(dr["COSTO"]);
                    }

                    if (dr["COSTOIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOIMPORTE = (decimal)(dr["COSTOIMPORTE"]);
                    }

                    if (dr["CARGO"] != System.DBNull.Value)
                    {
                        retorno.ICARGO = (decimal)(dr["CARGO"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = short.Parse(dr["PARTIDA"].ToString());
                    }


                    if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
                    }



                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }
                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }
                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }
                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["IEPS"] != System.DBNull.Value)
                    {
                        retorno.IIEPS = (decimal)(dr["IEPS"]);
                    }


                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
                    }

                    if (dr["CLAVEPROD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPROD = (string)(dr["CLAVEPROD"]);
                    }

                    if (dr["MOVTOADJUNTOAID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOADJUNTOAID = (long)(dr["MOVTOADJUNTOAID"]);
                    }

                    if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                    }
                }
                else
                {
                    retorno = null;
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public CMOVTOBE[] seleccionarMOVTOSADJUNTO(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            ArrayList retArray = new ArrayList();

            CMOVTOBE retorno = new CMOVTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVTO where
 MOVTOADJUNTOAID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CMOVTOBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["ESTATUSMOVTOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSMOVTOID = (long)(dr["ESTATUSMOVTOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSURTIDA = (decimal)(dr["CANTIDADSURTIDA"]);
                    }

                    if (dr["CANTIDADFALTANTE"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADFALTANTE = (decimal)(dr["CANTIDADFALTANTE"]);
                    }

                    if (dr["CANTIDADDEVUELTA"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADDEVUELTA = (decimal)(dr["CANTIDADDEVUELTA"]);
                    }

                    if (dr["CANTIDADSALDO"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDADSALDO = (decimal)(dr["CANTIDADSALDO"]);
                    }

                    if (dr["PRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOLISTA = (decimal)(dr["PRECIOLISTA"]);
                    }

                    if (dr["DESCUENTOPORCENTAJE"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTOPORCENTAJE = (decimal)(dr["DESCUENTOPORCENTAJE"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        retorno.IIVA = (decimal)(dr["IVA"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (decimal)(dr["COSTO"]);
                    }

                    if (dr["COSTOIMPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOIMPORTE = (decimal)(dr["COSTOIMPORTE"]);
                    }

                    if (dr["CARGO"] != System.DBNull.Value)
                    {
                        retorno.ICARGO = (decimal)(dr["CARGO"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = short.Parse(dr["PARTIDA"].ToString());
                    }


                    if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
                    }



                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }
                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }
                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }


                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }
                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }
                    if (dr["DESCRIPCION3"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                    }


                    if (dr["TASAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                    }

                    if (dr["IEPS"] != System.DBNull.Value)
                    {
                        retorno.IIEPS = (decimal)(dr["IEPS"]);
                    }


                    if (dr["TASAIMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ITASAIMPUESTO = (decimal)(dr["TASAIMPUESTO"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
                    }

                    if (dr["CLAVEPROD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPROD = (string)(dr["CLAVEPROD"]);
                    }

                    if (dr["MOVTOADJUNTOAID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOADJUNTOAID = (long)(dr["MOVTOADJUNTOAID"]);
                    }

                    if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                    }
                    retArray.Add(retorno);
                }



                CMOVTOBE[] ret = new CMOVTOBE[retArray.Count];
                retArray.CopyTo(ret, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return ret;


            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }






        public CMOVTOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
