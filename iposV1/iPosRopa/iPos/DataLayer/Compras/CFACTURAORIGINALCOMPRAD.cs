

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;

namespace iPosData
{



    public class CFACTURAORIGINALCOMPRAD
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


        public CFACTURAORIGINALCOMPRABE AgregarFACTURAORIGINALCOMPRAD(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMPRA", FbDbType.VarChar);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORDENCOMPRA", FbDbType.VarChar);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IORDENCOMPRA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IORDENCOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORDENCOMPRAID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IORDENCOMPRAID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IORDENCOMPRAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTURA", FbDbType.VarChar);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IFACTURA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTURAESTATUS", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IFACTURAESTATUS"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IFACTURAESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFACTURA", FbDbType.Date);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IFECHAFACTURA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IFECHAFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IPROVEEDORID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IPROVEEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUMA", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["ISUMA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.ISUMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IVA", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIVA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["ITOTAL"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVISIONADA", FbDbType.Char);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IPROVISIONADA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IPROVISIONADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IEPS8", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIEPS8"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIEPS8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IEPS25", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIEPS25"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIEPS25;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IEPS26", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIEPS26"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIEPS26;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IEPS26C", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIEPS26C"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIEPS26C;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IEPS30", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIEPS30"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIEPS30;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IEPS53", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["IIEPS53"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.IIEPS53;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@COMPRAFOLIO", FbDbType.Integer);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["ICOMPRAFOLIO"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.ICOMPRAFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.Integer);
                if (!(bool)oCFACTURAORIGINALCOMPRA.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRA.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                string commandText = @"
        INSERT INTO FACTURAORIGINALCOMPRA
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

COMPRA,

ORDENCOMPRA,

ORDENCOMPRAID,

FACTURA,

FACTURAESTATUS,

FECHARECEPCION,

FECHAFACTURA,

PROVEEDORID,

SUMA,

IVA,

TOTAL,

PROVISIONADA,

IEPS8,

IEPS25,

IEPS26,

IEPS26C,

IEPS30,

IEPS53,

COMPRAFOLIO,

SUCURSALID

         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@COMPRA,

@ORDENCOMPRA,

@ORDENCOMPRAID,

@FACTURA,

@FACTURAESTATUS,

@FECHARECEPCION,

@FECHAFACTURA,

@PROVEEDORID,

@SUMA,

@IVA,

@TOTAL,

@PROVISIONADA,

@IEPS8,

@IEPS25,

@IEPS26,

@IEPS26C,

@IEPS30,

@IEPS53,

@COMPRAFOLIO,

@SUCURSALID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCFACTURAORIGINALCOMPRA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarFACTURAORIGINALCOMPRAD(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCFACTURAORIGINALCOMPRA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from FACTURAORIGINALCOMPRA
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


        public bool CambiarFACTURAORIGINALCOMPRAD(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRANuevo, CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMPRA", FbDbType.VarChar);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ORDENCOMPRA", FbDbType.VarChar);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IORDENCOMPRA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IORDENCOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ORDENCOMPRAID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IORDENCOMPRAID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IORDENCOMPRAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTURA", FbDbType.VarChar);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IFACTURA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTURAESTATUS", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IFACTURAESTATUS"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IFACTURAESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFACTURA", FbDbType.Date);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IFECHAFACTURA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IFECHAFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IPROVEEDORID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IPROVEEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUMA", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["ISUMA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.ISUMA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IVA", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIVA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVISIONADA", FbDbType.Char);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IPROVISIONADA"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IPROVISIONADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IEPS8", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIEPS8"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIEPS8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IEPS25", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIEPS25"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIEPS25;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IEPS26", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIEPS26"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIEPS26;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IEPS26C", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIEPS26C"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIEPS26C;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IEPS30", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIEPS30"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIEPS30;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IEPS53", FbDbType.Numeric);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["IIEPS53"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.IIEPS53;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMPRAFOLIO", FbDbType.Integer);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["ICOMPRAFOLIO"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.ICOMPRAFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRANuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRANuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCFACTURAORIGINALCOMPRAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCFACTURAORIGINALCOMPRAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  FACTURAORIGINALCOMPRA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

COMPRA=@COMPRA,

ORDENCOMPRA=@ORDENCOMPRA,

ORDENCOMPRAID=@ORDENCOMPRAID,

FACTURA=@FACTURA,

FACTURAESTATUS=@FACTURAESTATUS,

FECHARECEPCION=@FECHARECEPCION,

FECHAFACTURA=@FECHAFACTURA,

PROVEEDORID=@PROVEEDORID,

SUMA=@SUMA,

IVA=@IVA,

TOTAL=@TOTAL,

PROVISIONADA=@PROVISIONADA,

IEPS8=@IEPS8,

IEPS25=@IEPS25,

IEPS26=@IEPS26,

IEPS26C=@IEPS26C,

IEPS30=@IEPS30,

IEPS53=@IEPS53,

COMPRAFOLIO = @COMPRAFOLIO,

SUCURSALID = @SUCURSALID
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


        public CFACTURAORIGINALCOMPRABE seleccionarFACTURAORIGINALCOMPRA(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {




            CFACTURAORIGINALCOMPRABE retorno = new CFACTURAORIGINALCOMPRABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FACTURAORIGINALCOMPRA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCFACTURAORIGINALCOMPRA.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    retorno = getFromReader(dr);
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


        public CFACTURAORIGINALCOMPRABE getFromReader(FbDataReader dr)
        {

            CFACTURAORIGINALCOMPRABE retorno = new CFACTURAORIGINALCOMPRABE();

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

            if (dr["COMPRA"] != System.DBNull.Value)
            {
                retorno.ICOMPRA = (string)(dr["COMPRA"]);
            }

            if (dr["ORDENCOMPRA"] != System.DBNull.Value)
            {
                retorno.IORDENCOMPRA = (string)(dr["ORDENCOMPRA"]);
            }

            if (dr["ORDENCOMPRAID"] != System.DBNull.Value)
            {
                retorno.IORDENCOMPRAID = (long)(dr["ORDENCOMPRAID"]);
            }

            if (dr["FACTURA"] != System.DBNull.Value)
            {
                retorno.IFACTURA = (string)(dr["FACTURA"]);
            }

            if (dr["FACTURAESTATUS"] != System.DBNull.Value)
            {
                retorno.IFACTURAESTATUS = (long)(dr["FACTURAESTATUS"]);
            }

            if (dr["FECHARECEPCION"] != System.DBNull.Value)
            {
                retorno.IFECHARECEPCION = (DateTime)(dr["FECHARECEPCION"]);
            }

            if (dr["FECHAFACTURA"] != System.DBNull.Value)
            {
                retorno.IFECHAFACTURA = (DateTime)(dr["FECHAFACTURA"]);
            }

            if (dr["PROVEEDORID"] != System.DBNull.Value)
            {
                retorno.IPROVEEDORID = (long)(dr["PROVEEDORID"]);
            }

            if (dr["SUMA"] != System.DBNull.Value)
            {
                retorno.ISUMA = (decimal)(dr["SUMA"]);
            }

            if (dr["IVA"] != System.DBNull.Value)
            {
                retorno.IIVA = (decimal)(dr["IVA"]);
            }

            if (dr["TOTAL"] != System.DBNull.Value)
            {
                retorno.ITOTAL = (decimal)(dr["TOTAL"]);
            }

            if (dr["PROVISIONADA"] != System.DBNull.Value)
            {
                retorno.IPROVISIONADA = (string)(dr["PROVISIONADA"]);
            }

            if (dr["IEPS8"] != System.DBNull.Value)
            {
                retorno.IIEPS8 = (decimal)(dr["IEPS8"]);
            }

            if (dr["IEPS25"] != System.DBNull.Value)
            {
                retorno.IIEPS25 = (decimal)(dr["IEPS25"]);
            }

            if (dr["IEPS26"] != System.DBNull.Value)
            {
                retorno.IIEPS26 = (decimal)(dr["IEPS26"]);
            }

            if (dr["IEPS26C"] != System.DBNull.Value)
            {
                retorno.IIEPS26C = (decimal)(dr["IEPS26C"]);
            }

            if (dr["IEPS30"] != System.DBNull.Value)
            {
                retorno.IIEPS30 = (decimal)(dr["IEPS30"]);
            }

            if (dr["IEPS53"] != System.DBNull.Value)
            {
                retorno.IIEPS53 = (decimal)(dr["IEPS53"]);
            }

            if (dr["COMPRAFOLIO"] != System.DBNull.Value)
            {
                retorno.ICOMPRAFOLIO = (int)(dr["COMPRAFOLIO"]);
            }

            if (dr["SUCURSALID"] != System.DBNull.Value)
            {
                retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
            }

            return retorno;

        }

        public CFACTURAORIGINALCOMPRABE seleccionarFACTURAORIGINALCOMPRA_XFACT(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {




            CFACTURAORIGINALCOMPRABE retorno = new CFACTURAORIGINALCOMPRABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FACTURAORIGINALCOMPRA where FACTURA = @FACTURA  ";


                auxPar = new FbParameter("@FACTURA", FbDbType.VarChar);
                auxPar.Value = oCFACTURAORIGINALCOMPRA.IFACTURA;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    retorno =  getFromReader(dr);
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







        public DataSet enlistarFACTURAORIGINALCOMPRA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_FACTURAORIGINALCOMPRA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoFACTURAORIGINALCOMPRA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_FACTURAORIGINALCOMPRA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteFACTURAORIGINALCOMPRA(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCFACTURAORIGINALCOMPRA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from FACTURAORIGINALCOMPRA where

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




        public CFACTURAORIGINALCOMPRABE AgregarFACTURAORIGINALCOMPRA(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteFACTURAORIGINALCOMPRA(oCFACTURAORIGINALCOMPRA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El FACTURAORIGINALCOMPRA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarFACTURAORIGINALCOMPRAD(oCFACTURAORIGINALCOMPRA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarFACTURAORIGINALCOMPRA(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteFACTURAORIGINALCOMPRA(oCFACTURAORIGINALCOMPRA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El FACTURAORIGINALCOMPRA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarFACTURAORIGINALCOMPRAD(oCFACTURAORIGINALCOMPRA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarFACTURAORIGINALCOMPRA(CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRANuevo, CFACTURAORIGINALCOMPRABE oCFACTURAORIGINALCOMPRAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteFACTURAORIGINALCOMPRA(oCFACTURAORIGINALCOMPRAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El FACTURAORIGINALCOMPRA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarFACTURAORIGINALCOMPRAD(oCFACTURAORIGINALCOMPRANuevo, oCFACTURAORIGINALCOMPRAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CFACTURAORIGINALCOMPRAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
