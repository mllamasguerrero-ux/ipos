using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Text.RegularExpressions;

namespace iPosData
{
    public class CPuntoDeVentaD
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
        public CPRODUCTOBE buscarPRODUCTOSPV(string producto, ref decimal cantidadAux, ref bool bPreguntaCantidad,CPARAMETROBE parametro, FbTransaction st)
        {

            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();

            bool esEmpaque = false;
            bool esCaja = false;
            bool tienePrefijoBascula = false;

            retorno = productoD.buscarPRODUCTOSLineaComando(producto, ref cantidadAux, ref  bPreguntaCantidad, parametro, ref  esEmpaque, ref  esCaja, ref tienePrefijoBascula, st);
            this.IComentario = productoD.IComentario;
            return retorno;

        }



        public CPRODUCTOBE buscarPRODUCTOSPV(string producto, ref decimal cantidadAux, ref bool bPreguntaCantidad, CPARAMETROBE parametro, ref bool esEmpaque, ref bool esCaja, ref bool tienePrefijoBascula, FbTransaction st)
        {

            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();

            retorno = productoD.buscarPRODUCTOSLineaComando(producto, ref cantidadAux, ref  bPreguntaCantidad, parametro, ref  esEmpaque, ref  esCaja, ref tienePrefijoBascula, st);
            this.IComentario = productoD.IComentario;
            return retorno;

        }



        public bool CancelarVenta(CDOCTOBE cDocto, CPERSONABE userBE, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;
                bool bCommitRollBack = st == null;

                FbConnection fConn = null;
                FbTransaction fTrans = st;

                if (st == null)
                {
                    fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                }
                fConn.Close();


                try
                {
                    if (st == null)
                    {
                        fConn.Open();
                        fTrans = fConn.BeginTransaction();
                    }



                    doctoBE.IID = cDocto.IID;
                    ObtenerVenta(doctoBE,st);

                    if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                        iResult = doctoD.BorrarDOCTOD(doctoBE, fTrans);
                    else
                        iResult = doctoD.CancelarVentaD(doctoBE,userBE, fTrans);
                    
                    if (!iResult)
                    {
                        if (bCommitRollBack)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                        }

                        this.IComentario = doctoD.IComentario;
                        return false;
                    }


                    if (bCommitRollBack)
                    {
                        fTrans.Commit();
                        fConn.Close();
                    }
                    return true;


                }
                catch (Exception e)
                {


                    if (bCommitRollBack)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                    }
                    this.iComentario = e.Message + e.StackTrace;
                    return false;
                }
                finally
                {
                    if (fConn != null && bCommitRollBack)
                    {
                        fConn.Close();
                    }
                }

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CancelarDevolucion(CDOCTOBE cDocto, CPERSONABE userBE, ref long doctoIDCancelacion, FbTransaction st)
        {
            this.IComentario = "";
            bool retorno = false;

            FbConnection fConn = null;
            FbTransaction fTrans = st;


            if (st == null)
            {
                fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            }


            fConn.Close();

            try
            {
                if (st == null)
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();
                }

                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerVenta(doctoBE, st);

                if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                else
                    iResult = doctoD.CancelarDevolucionD(doctoBE, userBE, ref doctoIDCancelacion, fTrans);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    fTrans.Rollback();
                    retorno = false;
                }
                else
                {
                    fTrans.Commit();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                retorno = false;


                fTrans.Rollback();
            }
            finally
            {
                if (fConn != null)
                {
                    fConn.Close();
                }
            }
            return retorno;
        }



        public bool EditarDevolucion(CDOCTOBE cDocto, CPERSONABE userBE, ref long doctoIDEdicion, long vendedorId, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerVenta(doctoBE, st);

                iResult = doctoD.EditarDevolucionD(doctoBE, userBE, ref doctoIDEdicion, vendedorId, st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CancelarApartado(CDOCTOBE cDocto, CPERSONABE userBE, ref long doctoIDCancelacion, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerVenta(doctoBE, st);

                if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                else
                    iResult = doctoD.CancelarApartadoD(doctoBE, userBE,ref doctoIDCancelacion, st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




            
        public bool CancelarTraspasoAlmacenD(CDOCTOBE cDocto,  FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerVenta(doctoBE, st);

                if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                else
                    iResult = doctoD.CancelarTraspasoAlmacenD(doctoBE,  st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool EditarApartado(CDOCTOBE cDocto, CPERSONABE userBE, ref long doctoIDEdicion, long vendedorId, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerVenta(doctoBE, st);

                iResult = doctoD.EditarApartadoD(doctoBE, userBE, ref doctoIDEdicion, vendedorId, st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool VentaConvierteApartado(CDOCTOBE cDocto, long personaApartadoId, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerVenta(doctoBE, st);

                if (cDocto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    this.IComentario = "No se puede convertir a venta de apartado una venta que ya se completo";
                    return false;
                }

                iResult = doctoD.ConvierteApartadoD(doctoBE, personaApartadoId, st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CancelarPartida(
           int P_DE_VENTA,
            int P_PARTIDA,
             FbTransaction st)
        {
            //this.IComentario = "";
            //try
            //{
            //    this.IComentario = "";
            //    CDETALLE_DE_VENTASD detallesVentaD = new CDETALLE_DE_VENTASD();
            //    CDETALLE_DE_VENTASBE detallesVentaBE = new CDETALLE_DE_VENTASBE();
            //    detallesVentaBE.IDE_VENTA = P_DE_VENTA;
            //    detallesVentaBE.IDE_PARTIDA = P_PARTIDA;
            //    if (!detallesVentaD.CancelarDETALLE_DE_VENTAS(detallesVentaBE, st))
            //    {
            //        this.IComentario = detallesVentaD.IComentario;
            //        return false;
            //    }
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    this.iComentario = e.Message + e.StackTrace;
            //    return false;
            //}
            return true;
        }
        public bool EjecutarItemCommandT(
            ref int? P_DE_VENTA,
            decimal? P_CANTIDAD,
            string P_PD_PRODUCTO,
            int? P_DESCUENTO,
            string P_CLIENTE,
            string P_VD_VENDEDOR,
             FbTransaction st)
        {
            FbParameter[] arParms;
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FirebirdSql.Data.FirebirdClient.FbParameter("@RETURN_VALUE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 4, System.Data.ParameterDirection.Output, true, 10, 0, null, System.Data.DataRowVersion.Current, null);
                parts.Add(auxPar);
                auxPar = new FbParameter("@DE_VENTA", FbDbType.Integer);
                if (P_DE_VENTA.HasValue)
                {
                    auxPar.Value = (int)P_DE_VENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CANTIDAD", FbDbType.Decimal);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (Decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_PRODUCTO", FbDbType.Char, 15);
                auxPar.Value = P_PD_PRODUCTO;
                parts.Add(auxPar);
                auxPar = new FbParameter("@DESCUENTO", FbDbType.Integer);
                if (P_DESCUENTO.HasValue)
                {
                    auxPar.Value = (int)P_DESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CLIENTE", FbDbType.Char, 6);
                auxPar.Value = P_CLIENTE;
                parts.Add(auxPar);
                auxPar = new FbParameter("@VD_VENDEDOR", FbDbType.Char, 3);
                auxPar.Value = P_VD_VENDEDOR;
                parts.Add(auxPar);
                auxPar = new FirebirdSql.Data.FirebirdClient.FbParameter("@R_DE_VENTA", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 4, System.Data.ParameterDirection.Output, true, 10, 0, null, System.Data.DataRowVersion.Current, null);
                parts.Add(auxPar);
                auxPar = new FirebirdSql.Data.FirebirdClient.FbParameter("@comentario", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 255, System.Data.ParameterDirection.Output, false, 0, 0, null, System.Data.DataRowVersion.Current, null);
                parts.Add(auxPar);
                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, "SISGEN_PV_COMMANDITEMS", arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, "SISGEN_PV_COMMANDITEMS", arParms);
                if (arParms[0].Value.ToString() == "1")
                {
                    this.iComentarioAdicional = arParms[parts.Count - 1].Value.ToString();
                    P_DE_VENTA = int.Parse(arParms[parts.Count - 2].Value.ToString());
                    return true;
                }
                else
                {
                    this.iComentario = arParms[parts.Count - 1].Value.ToString();
                    return false;
                }
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
    //    public bool EjecutarItemCommand(
    //ref int? P_DE_VENTA,
    //decimal? P_CANTIDAD,
    //string P_PD_PRODUCTO,
    //int? P_DESCUENTO,
    //string P_CLIENTE,
    //string P_VD_VENDEDOR,
    //CUSUARIOSBE P_USUARIO,
    //string P_LOTE,
    //CUSUARIOSBE P_SUPERVISOR,
    // FbTransaction st)
    //    {
    //        this.IComentario = "";
    //        CVENTASD ventasD = new CVENTASD();
    //        CVENTASBE ventasBE = new CVENTASBE();
    //        CPRODUCTOSBE productosBE = new CPRODUCTOSBE();
    //        CPRODUCTOSD productosD = new CPRODUCTOSD();
    //        CDETALLE_DE_VENTASBE detalleVentaBE = new CDETALLE_DE_VENTASBE();
    //        CDETALLE_DE_VENTASD detalleVentaD = new CDETALLE_DE_VENTASD();
    //        Int64 iGroupId = -1;
    //        CKARDEXBE movKardexBE = new CKARDEXBE();
    //        CKARDEXD movKardexD = new CKARDEXD();
    //        CCLIENTESBE clientesBE = new CCLIENTESBE();
    //        CCLIENTESD clientesD = new CCLIENTESD();
    //        //decimal descuentoCliente = 0;
    //        decimal factorImpuestoProd = 0;
    //        //decimal descuentoProducto = 0;
    //        decimal precioParaCliente = 0;
    //        decimal cantidadAApartar = 0;
    //        decimal cantidadADesApartar = 0;
    //        try
    //        {
    //            this.IComentario = "";
    //            if (P_CLIENTE != null && P_CLIENTE != "")
    //            {
    //                clientesBE.ICL_CLIENTE = P_CLIENTE;
    //                clientesBE = clientesD.seleccionarCLIENTES(clientesBE, st);
    //            }
    //            else
    //            {
    //                clientesBE = null;
    //            }
    //            productosBE.IPD_PRODUCTO = P_PD_PRODUCTO;
    //            productosBE = productosD.seleccionarPRODUCTOS(productosBE, st);
    //            // si el producto no existe lanza un error
    //            if (productosBE == null)
    //            {
    //                this.IComentario = "El producto no existe";
    //                return false;
    //            }
    //            //si el cliente no es de mostrador
    //            if (clientesBE != null)
    //            {
    //                int buffLista;
    //                if (int.TryParse(clientesBE.ICL_LISTA_DE_PRECIOS, out buffLista))
    //                {
    //                    switch (buffLista)
    //                    {
    //                        case 1:
    //                            {
    //                                precioParaCliente = productosBE.IPD_PRECIO1;
    //                                break;
    //                            }
    //                        case 2:
    //                            {
    //                                precioParaCliente = productosBE.IPD_PRECIO2;
    //                                break;
    //                            }
    //                        case 3:
    //                            {
    //                                precioParaCliente = productosBE.IPD_PRECIO3;
    //                                break;
    //                            }
    //                        case 4:
    //                            {
    //                                precioParaCliente = productosBE.IPD_PRECIO4;
    //                                break;
    //                            }
    //                        case 5:
    //                            {
    //                                precioParaCliente = productosBE.IPD_PRECIO5;
    //                                break;
    //                            }
    //                        default:
    //                            {
    //                                precioParaCliente = productosBE.IPD_PRECIO1;
    //                                break;
    //                            }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                precioParaCliente = productosBE.IPD_PRECIO1;
    //            }
    //            factorImpuestoProd = (100 + productosBE.IPD_IMPUESTO) / 100;
    //            // Si la venta no existe hay que agregarla
    //            if (!P_DE_VENTA.HasValue)
    //            {
    //                ventasBE.IGV_SUMA = 0;
    //                ventasBE.IGV_IMPUESTO = 0;
    //                ventasBE.IGV_TOTAL = 0;
    //                ventasBE.IVD_VENDEDOR = P_VD_VENDEDOR;
    //                ventasBE.IGV_ESTATUS = CVENTASD.strStatusAbierta;
    //                ventasBE.ICL_CLIENTE = P_CLIENTE;
    //                ventasBE.IUS_USERID = P_USUARIO.IUS_USERID;
    //                ventasBE = ventasD.AgregarVENTAS(ventasBE, st);
    //                if (ventasBE == null)
    //                {
    //                    this.IComentario = ventasD.IComentario;
    //                    return false;
    //                }
    //            }
    //            else // si la venta existe hay que traer sus datos
    //            {
    //                ventasBE.IGV_VENTA = (int)P_DE_VENTA;
    //                ventasBE = ventasD.seleccionarVENTAS(ventasBE, st);
    //                if (ventasBE == null)
    //                {
    //                    this.IComentario = "la venta no existe";
    //                    return false;
    //                }
    //            }
    //            //Vamos a buscar un detalle con la misma venta, producto , numero de lote y falta el almacen
    //            detalleVentaBE.IDE_VENTA = ventasBE.IGV_VENTA;
    //            detalleVentaBE.IPD_PRODUCTO = productosBE.IPD_PRODUCTO;
    //            detalleVentaBE.IDE_LOTE = P_LOTE;
    //            detalleVentaBE = detalleVentaD.seleccionarDETALLEPorVentaYProdYLote(detalleVentaBE, st);
    //            // si la venta no existe hay que agregarla
    //            if (detalleVentaBE == null)
    //            {
    //                detalleVentaBE = new CDETALLE_DE_VENTASBE();
    //                detalleVentaBE.IDE_VENTA = ventasBE.IGV_VENTA;
    //                detalleVentaBE.IPD_PRODUCTO = productosBE.IPD_PRODUCTO;
    //                if (P_CANTIDAD <= 0)
    //                {
    //                    /*detalleVentaBE.IDE_CANTIDAD = 0;
    //                    detalleVentaBE.IDE_DEVUELTAS = (decimal)P_CANTIDAD * -1;*/
    //                    this.IComentario = "No hay producto a devolver";
    //                    return false;
    //                }
    //                else
    //                {
    //                    detalleVentaBE.IDE_CANTIDAD = (decimal)P_CANTIDAD;
    //                    detalleVentaBE.IDE_DEVUELTAS = 0;
    //                }
    //                if (P_DESCUENTO.HasValue)
    //                {
    //                    detalleVentaBE.IDE_DESCUENTO = (int)P_DESCUENTO;
    //                }
    //                else
    //                {
    //                    detalleVentaBE.IDE_DESCUENTO = 0;
    //                }
    //                if (P_CLIENTE == "")
    //                {
    //                    detalleVentaBE.ICL_CLIENTE = P_CLIENTE;
    //                }
    //                else
    //                {
    //                    detalleVentaBE.ICL_CLIENTE = "0";
    //                }
    //                detalleVentaBE.IDE_COSTO_POR_UNIDAD = precioParaCliente;
    //                detalleVentaBE.IDE_COSTO_TOTAL = (detalleVentaBE.IDE_COSTO_POR_UNIDAD * (detalleVentaBE.IDE_CANTIDAD - detalleVentaBE.IDE_DEVUELTAS)) * factorImpuestoProd * ((100 - (decimal)detalleVentaBE.IDE_DESCUENTO) / 100);
    //                detalleVentaBE.IVD_VENDEDOR = P_VD_VENDEDOR;
    //                detalleVentaBE.IDE_LOTE = P_LOTE;
    //                detalleVentaBE = detalleVentaD.AgregarDETALLE_DE_VENTAS(detalleVentaBE, st);
    //                if (detalleVentaBE == null)
    //                {
    //                    this.IComentario = detalleVentaD.IComentario;
    //                    return false;
    //                }
    //                P_DE_VENTA = detalleVentaBE.IDE_VENTA;
    //                cantidadAApartar = (decimal)P_CANTIDAD;
    //            }
    //            else // si el detalle ya existe
    //            {
    //                if (P_CANTIDAD <= 0)
    //                {
    //                    if((detalleVentaBE.IDE_DEVUELTAS + ((decimal)P_CANTIDAD * -1)) < 0)
    //                    {
    //                        this.IComentario = "No hay producto a devolver";
    //                        return false;
    //                    }
    //                    detalleVentaBE.IDE_DEVUELTAS = detalleVentaBE.IDE_DEVUELTAS + ((decimal)P_CANTIDAD * -1);
    //                    cantidadAApartar = detalleVentaBE.IDE_CANTIDAD - detalleVentaBE.IDE_DEVUELTAS;
    //                    cantidadADesApartar = ((decimal)P_CANTIDAD * -1);
    //                }
    //                else
    //                {
    //                    detalleVentaBE.IDE_CANTIDAD = detalleVentaBE.IDE_CANTIDAD + (decimal)P_CANTIDAD;
    //                    cantidadAApartar = (decimal)P_CANTIDAD;
    //                }
    //                if (P_DESCUENTO.HasValue)
    //                {
    //                    detalleVentaBE.IDE_DESCUENTO = (int)P_DESCUENTO;
    //                }
    //                else
    //                {
    //                    detalleVentaBE.IDE_DESCUENTO = 0;
    //                }
    //                //detalleVentaBE.IDE_COSTO_POR_UNIDAD = precioParaCliente;
    //                detalleVentaBE.IDE_COSTO_TOTAL = (detalleVentaBE.IDE_COSTO_POR_UNIDAD * (detalleVentaBE.IDE_CANTIDAD - detalleVentaBE.IDE_DEVUELTAS)) * factorImpuestoProd;// *((100 - detalleVentaBE.IDE_DESCUENTO) / 100);
    //                //detalleVentaBE.IDE_COSTO_TOTAL = (detalleVentaBE.IDE_COSTO_POR_UNIDAD * (detalleVentaBE.IDE_CANTIDAD - detalleVentaBE.IDE_DEVUELTAS)) * ((100 - detalleVentaBE.IDE_DESCUENTO) / 100);
    //                detalleVentaBE.IDE_LOTE = P_LOTE;
    //                if (!detalleVentaD.CambiarDETALLE_DE_VENTAS(detalleVentaBE, detalleVentaBE, st))
    //                {
    //                    this.IComentario = detalleVentaD.IComentario;
    //                    return false;
    //                }
    //                iGroupId = detalleVentaBE.IDE_TRANSA;
                    
                    
    //            }
    //            if (clientesBE != null)
    //            {
    //                if ((bool)clientesBE.isnull["ICL_DESCUENTO"] == false)
    //                {
    //                    ventasBE.IGV_DESCUENTO = clientesBE.ICL_DESCUENTO;
    //                }
    //            }
               
    //            ventasBE = ventasD.ActualizarTotalesVENTAS(ventasBE, st);
    //            if (ventasBE == null)
    //            {
    //                this.IComentario = ventasD.IComentario;
    //                return false;
    //            }
    //            //movKardexBE.IDESC = ventasBE.IGV_VENTA.ToString();
    //            if (cantidadADesApartar > 0)
    //            {
    //                if (iGroupId != -1)
    //                {
    //                    if (!movKardexD.DesapartarPorDetalleVenta(detalleVentaBE, st, P_USUARIO.IUS_USERID))
    //                    {
    //                        this.IComentario = "No se pudieron desapartar los items";
    //                        return false;
    //                    }
    //                    iGroupId = -1;
    //                }
    //                else
    //                {
    //                    this.IComentario = "Error, no se encontro el numero de transaccion del detalle de venta";
    //                    return false;
    //                }
    //            }
    //            if (cantidadAApartar > 0)
    //            {
    //                movKardexBE.IDESCR = CKARDEXD._PREFIJO_APARTAR + ventasBE.IGV_VENTA.ToString();
    //                movKardexBE.IPRODUCTO = productosBE.IPD_PRODUCTO;
    //                movKardexBE.IAPARTA = cantidadAApartar;
    //                movKardexBE.ILOTE = P_LOTE;
    //                movKardexBE.IID_FECHA = DateTime.Today;
    //                movKardexBE.IID_HORA = DateTime.Now.TimeOfDay;
    //                movKardexBE.IUSER_ID = P_USUARIO.IUS_USERID;
    //                movKardexBE.ILOCAL = P_USUARIO.IUS_ALMACENID;
    //                movKardexBE.IENTRADA = 0;
    //                movKardexBE.ISALIDA = 0;
    //                movKardexBE.IFECHA = DateTime.Today;
    //                movKardexBE.IPRECIO = detalleVentaBE.IDE_COSTO_POR_UNIDAD;
    //                movKardexBE.ICOSTO = detalleVentaBE.IDE_COSTO_POR_UNIDAD;
    //                if (movKardexD.AgregarApartadosKARDEX(movKardexBE, st, ref iGroupId) == false)
    //                {
    //                    this.IComentario = movKardexD.IComentario;
    //                    return false;
    //                }
    //            }
               
    //            if (iGroupId != detalleVentaBE.IDE_TRANSA)
    //            {
    //                detalleVentaBE.IDE_TRANSA = iGroupId;
    //                if (detalleVentaD.CambiarTransDETALLE_DE_VENTASD(detalleVentaBE, st) == false)
    //                {
    //                    this.IComentario = detalleVentaD.IComentario;
    //                    return false;
    //                }
    //            }
                
    //            return true;
    //        }
    //        catch (Exception e)
    //        {
    //            this.iComentario = e.Message + e.StackTrace;
    //            return false;
    //        }
    //    }
//        public bool CerrarVenta(
//int P_DE_VENTA,
//FbTransaction st,
//    CUSUARIOSBE P_USUARIO)
//        {
//            CDETALLE_DE_VENTASD detallesVentaD = new CDETALLE_DE_VENTASD();
//            CKARDEXD kardexD = new CKARDEXD();
//            this.IComentario = "";
//            try
//            {
//                this.IComentario = "";
//                CVENTASD ventasD = new CVENTASD();
//                CVENTASBE ventasBE = new CVENTASBE();
//                ventasBE.IGV_VENTA = P_DE_VENTA;
//                if (!ventasD.CerrarVENTAS(ventasBE, st))
//                {
//                    this.IComentario = ventasD.IComentario;
//                    return false;
//                }
//                CDETALLE_DE_VENTASBE[] iDetallesVenta = detallesVentaD.seleccionarKeysDetallesPorVenta(ventasBE.IGV_VENTA, st);
//                if (iDetallesVenta == null)
//                {
//                    this.IComentario = detallesVentaD.IComentario;
//                    return false;
//                }
//                foreach (CDETALLE_DE_VENTASBE iDetallesVentaItem in iDetallesVenta)
//                {
//                    long lNewGroupId = 0;
//                    if (kardexD.SalidaPorGroupId(iDetallesVentaItem, st, ref lNewGroupId, P_USUARIO.IUS_USERID))
//                    {
//                        iDetallesVentaItem.IDE_TRANSA = lNewGroupId;
//                        if (detallesVentaD.CambiarTransDETALLE_DE_VENTASD(iDetallesVentaItem, st) == false)
//                        {
//                            this.IComentario = detallesVentaD.IComentario;
//                            return false;
//                        }
//                    }
//                    else
//                    {
//                        this.IComentario = kardexD.IComentario;
//                        return false;
//                    }
//                }
//                return true;
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }
//        }

        public bool CompletarTraspasoAlmacen(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CompletarTraspasoAlmacenDOCTOD(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CerrarVenta(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CerrarDOCTOD(docto,st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TRASPASOSALIDA_CERRARDOCTO(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.TRASPASOSALIDA_CERRARDOCTOD(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool TRASPASOSALIDA_PRECIERRE(CDOCTOBE docto, ref bool bPrepagoHecho, ref bool bDefaultFactura, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            bool bCommitRollBack = st == null;
            string prepagoHecho = "N";
            string defaultFactura = "N";



            FbConnection fConn = null;
            FbTransaction fTrans = st;

            if (st == null)
            {
                fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            }


            try
            {
                if (st == null)
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();
                }


                if (!doctoD.TRASPASOSALIDA_PRECIERRE(docto, ref prepagoHecho, ref defaultFactura, fTrans))
                {
                    this.IComentario = doctoD.IComentario;
                    if (bCommitRollBack)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                    }
                    return false;
                }
                else
                {
                    if (bCommitRollBack)
                    {
                        bPrepagoHecho = prepagoHecho != null && prepagoHecho.Equals("S");
                        bDefaultFactura = defaultFactura != null && defaultFactura.Equals("S");

                        fTrans.Commit();
                        fConn.Close();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {

                if (bCommitRollBack)
                {
                    fTrans.Rollback();
                    fConn.Close();
                }

                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
            finally
            {
                if (fConn != null && bCommitRollBack)
                {
                    fConn.Close();
                }
            }
        }



            public bool EjecutarAddMOVTO(       ref long?         P_IDDOCTO,
                                                decimal?      P_CANTIDAD,
                                                long?         P_IDPRODUCTO,
                                                long?         P_PERSONAID,
                                                long?          P_USERID,
                                                string        P_LOTE,
                                                int?          US_SUPERVISOR,
                                                int?          ALMACENID,
                                                long?         SUCURSALID,
                                                DateTime      P_FECHAVENCE,
                                                long          P_TIPO_DOCTO,
                                                long?         P_SUCURSALTID,
                                                long?         P_ALMACENTID,
                                                string        P_PROMOCION,
                                                long?         P_TIPODIFERENCIAINVENTARIOID,
                                                decimal?      P_PRECIO,
                                                decimal?      P_DESCUENTO,
                                                long          P_CAJAID,
                                                long? P_DOCTOREFID,
                                           ref  long? P_MOVTOID,
                                                long? P_MOVTOREFID,
                                                string        P_DESCRIPCION1,
                                                string        P_DESCRIPCION2,
                                                string P_DESCRIPCION3,
                                                long? P_LOTEIMPORTADO,
                                                FbTransaction st)
        {
            return EjecutarAddMOVTO(  ref P_IDDOCTO,
                                                P_CANTIDAD,
                                                P_IDPRODUCTO,
                                                P_PERSONAID,
                                                P_USERID,
                                                P_LOTE,
                                                US_SUPERVISOR,
                                                ALMACENID,
                                                SUCURSALID,
                                                P_FECHAVENCE,
                                                P_TIPO_DOCTO,
                                                P_SUCURSALTID,
                                                P_ALMACENTID,
                                                P_PROMOCION,
                                                 P_TIPODIFERENCIAINVENTARIOID,
                                                P_PRECIO,
                                                P_DESCUENTO,
                                                P_CAJAID,
                                                P_DOCTOREFID,
                                           ref  P_MOVTOID,
                                                P_MOVTOREFID,
                                                P_DESCRIPCION1,
                                                P_DESCRIPCION2,
                                                P_DESCRIPCION3,
                                                null,
                                                P_LOTEIMPORTADO,
                                                null,
                                                null,
                                                st);
        }



        public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                                decimal? P_CANTIDAD,
                                                long? P_IDPRODUCTO,
                                                long? P_PERSONAID,
                                                long? P_USERID,
                                                string P_LOTE,
                                                int? US_SUPERVISOR,
                                                int? ALMACENID,
                                                long? SUCURSALID,
                                                DateTime P_FECHAVENCE,
                                                long P_TIPO_DOCTO,
                                                long? P_SUCURSALTID,
                                                long? P_ALMACENTID,
                                                string P_PROMOCION,
                                                long? P_TIPODIFERENCIAINVENTARIOID,
                                                decimal? P_PRECIO,
                                                decimal? P_DESCUENTO,
                                                long P_CAJAID,
                                                long? P_DOCTOREFID,
                                           ref long? P_MOVTOID,
                                                long? P_MOVTOREFID,
                                                string P_DESCRIPCION1,
                                                string P_DESCRIPCION2,
                                                string P_DESCRIPCION3,
                                                string P_REFERENCIA,
                                                long? P_LOTEIMPORTADO,
                                                string P_CARGOTARJPRECIOMANUAL,
                                                string P_AGRUPAPORPARAMETRO,
                                                FbTransaction st)
        {


            return EjecutarAddMOVTO(ref  P_IDDOCTO,
                                                P_CANTIDAD,
                                                P_IDPRODUCTO,
                                                P_PERSONAID,
                                                P_USERID,
                                                P_LOTE,
                                                US_SUPERVISOR,
                                                ALMACENID,
                                                SUCURSALID,
                                                P_FECHAVENCE,
                                                P_TIPO_DOCTO,
                                                P_SUCURSALTID,
                                                P_ALMACENTID,
                                                P_PROMOCION,
                                                P_TIPODIFERENCIAINVENTARIOID,
                                                P_PRECIO,
                                                P_DESCUENTO,
                                                P_CAJAID,
                                                P_DOCTOREFID,
                                                ref P_MOVTOID,
                                                P_MOVTOREFID,
                                                P_DESCRIPCION1,
                                                P_DESCRIPCION2,
                                                P_DESCRIPCION3,
                                                P_REFERENCIA,
                                                P_LOTEIMPORTADO,
                                                P_CARGOTARJPRECIOMANUAL,
                                                P_AGRUPAPORPARAMETRO,
                                                null,
                                                st);
        }

            public bool EjecutarAddMOVTO(       ref long?         P_IDDOCTO,
                                                decimal?      P_CANTIDAD,
                                                long?         P_IDPRODUCTO,
                                                long?         P_PERSONAID,
                                                long?          P_USERID,
                                                string        P_LOTE,
                                                int?          US_SUPERVISOR,
                                                int?          ALMACENID,
                                                long?         SUCURSALID,
                                                DateTime      P_FECHAVENCE,
                                                long          P_TIPO_DOCTO,
                                                long?         P_SUCURSALTID,
                                                long?         P_ALMACENTID,
                                                string        P_PROMOCION,
                                                long?         P_TIPODIFERENCIAINVENTARIOID,
                                                decimal?      P_PRECIO,
                                                decimal?      P_DESCUENTO,
                                                long          P_CAJAID,
                                                long? P_DOCTOREFID,
                                           ref  long? P_MOVTOID,
                                                long? P_MOVTOREFID,
                                                string        P_DESCRIPCION1,
                                                string        P_DESCRIPCION2,
                                                string        P_DESCRIPCION3,
                                                string P_REFERENCIA,
                                                long? P_LOTEIMPORTADO,
                                                string P_CARGOTARJPRECIOMANUAL ,
                                                string P_AGRUPAPORPARAMETRO,
                                                string P_REFERENCIAS,
                                                FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_PERSONAID.HasValue)
                {
                    auxPar.Value = P_PERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = P_CAJAID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE.Trim();
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if(P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                if (P_PRECIO.HasValue)
                {
                    auxPar.Value = (decimal)P_PRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (P_REFERENCIA != null && P_REFERENCIA != "")
                {
                    auxPar.Value = P_REFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (P_REFERENCIAS != null && P_REFERENCIAS != "")
                {
                    auxPar.Value = P_REFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                if (P_DESCUENTO.HasValue)
                {
                    auxPar.Value = (decimal)P_DESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                if (P_DOCTOREFID.HasValue)
                {
                    auxPar.Value = P_DOCTOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                if (P_MOVTOID.HasValue)
                {
                    auxPar.Value = P_MOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                if (P_MOVTOREFID.HasValue)
                {
                    auxPar.Value = P_MOVTOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (P_DESCRIPCION1 != null && P_DESCRIPCION1 != "")
                {
                    auxPar.Value = P_DESCRIPCION1.Trim();
                }
                else
                {
                    auxPar.Value = ""; ;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (P_DESCRIPCION2 != null && P_DESCRIPCION2 != "")
                {
                    auxPar.Value = P_DESCRIPCION2.Trim();
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (P_DESCRIPCION3 != null && P_DESCRIPCION3 != "")
                {
                    auxPar.Value = P_DESCRIPCION3.Trim();
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                if(P_CARGOTARJPRECIOMANUAL != null)
                    auxPar.Value = P_CARGOTARJPRECIOMANUAL;
                else
                    auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                if (P_AGRUPAPORPARAMETRO != null)
                    auxPar.Value = P_AGRUPAPORPARAMETRO;
                else
                    auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                
                
                
                
                string commandText = @"MOVTO_INSERT";
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
                        string strMensajeErr = "";
                        long longMensajeErr = (long)((int)arParms[arParms.Length - 1].Value);

                        // si se trata de existenlcia insuficiente entonces hay que poner la cantidad insuficiente
                        if (longMensajeErr == DBValues._ERRORCODE_EXISTENCIAINSUFICIENTE)
                        {
                            CPRODUCTOD prodD = new CPRODUCTOD();
                            CPRODUCTOBE prodBE = new CPRODUCTOBE();
                            prodBE.IID = P_IDPRODUCTO.Value;
                            prodBE = prodD.seleccionarPRODUCTO(prodBE, st);

                            decimal existenciaByAlmacen = prodD.GetExistenciaByAlmacen((long)P_IDPRODUCTO.Value, (long)ALMACENID.Value, st);

                            strMensajeErr += "\n";
                            strMensajeErr = "Existencia insuficiente: Maxima cantidad = " ;
                            decimal dExistencia;

                            dExistencia = existenciaByAlmacen;// (bool)prodBE.isnull["IEXISTENCIA"] ? 0 : prodBE.IEXISTENCIA;
                            
                            //decimal dEnProcesodeSalida = (bool)prodBE.isnull["IENPROCESODESALIDA"] ? 0 : prodBE.IENPROCESODESALIDA;
                            decimal dEnProcesodeSalida = prodD.GetProcesoSalidaByAlmacen((long)P_IDPRODUCTO.Value, (long)ALMACENID.Value, st);
                            decimal dExistenciaAUsar = dExistencia - dEnProcesodeSalida;

                            strMensajeErr += dExistenciaAUsar.ToString("N2");
                            strMensajeErr += "\n";
                            strMensajeErr += " + Existencia : " + dExistencia.ToString("N2");
                            strMensajeErr += "\n";
                            strMensajeErr += " - En proceso de salida : " + dEnProcesodeSalida.ToString("N2");
                            


                        }
                        else
                        {
                            strMensajeErr = CERRORCODED.ObtenerMensajeError(longMensajeErr, this.sCadenaConexion, st);
                        }
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                P_MOVTOID = (long)arParms[arParms.Length - 2].Value;
                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




public bool EjecutarAddDETALLE_DE_VENTAS(  ref int? P_DE_VENTA,
                                        decimal? P_CANTIDAD,
                                        string P_PD_PRODUCTO,
                                        int? P_DESCUENTO,
                                        string P_CLIENTE,
                                        string P_VD_VENDEDOR,
                                        int?    US_USERID,
                                        string P_LOTE,
                                        int?    US_SUPERVISOR, FbTransaction st)
{
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                auxPar = new FbParameter("@DE_VENTA", FbDbType.Integer);
                if (P_DE_VENTA.HasValue)
                {
                    auxPar.Value = (int)P_DE_VENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@CL_CLIENTE", FbDbType.Char);
                if (P_CLIENTE != "")
                {
                    auxPar.Value = P_CLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@DE_CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@PD_PRODUCTO", FbDbType.Char);
                if (P_PD_PRODUCTO != "")
                {
                    auxPar.Value = P_PD_PRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@VD_VENDEDOR", FbDbType.Char);
                if (P_VD_VENDEDOR != "")
                {
                    auxPar.Value = P_VD_VENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DE_LOTE", FbDbType.VarChar);
                if (P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@us_userid", FbDbType.Integer);
                if (US_USERID.HasValue)
                {
                    auxPar.Value = (int)US_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@us_supervisor", FbDbType.Integer);
                if (US_SUPERVISOR.HasValue)
                {
                    auxPar.Value = (int)US_SUPERVISOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@return_value", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@comentario", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DETALLE_VENTAS_AGREGAR";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if ((int)arParms[arParms.Length - 2].Value == 0)
                {
                    this.iComentario = arParms[arParms.Length - 2].Value.ToString();
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public CDOCTOBE ObtenerVenta(CDOCTOBE doctoBE,FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoRetorno = new CDOCTOBE();
            doctoRetorno = doctoD.seleccionarDOCTO(doctoBE, st);
            if (doctoRetorno == null)
                this.IComentario = doctoD.IComentario;

            return doctoRetorno;

        }

        public bool HayCorteActivo(ref DateTime fechaCorte, long cajeroId)
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            return corteD.HayCorteActivo(cajeroId, null,ref fechaCorte);
        }



        public CCAJABE ObtenerDatosCaja(long cajaId)
        {
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            cajaBE.IID = cajaId;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
                this.IComentario = cajaD.IComentario;

            return cajaBE;
        }




        public bool GetExistencia(CPRODUCTOBE productBE, ref int reg_count, ref decimal cantidad, ref string lote, ref DateTime fechaVence, long? almacenId, FbTransaction st)
        {

            CPRODUCTOD productoD = new CPRODUCTOD();
            bool retorno;
            retorno = productoD.GetExistencia(productBE, ref  reg_count, ref  cantidad, ref  lote, ref fechaVence, almacenId, st);
            return retorno;

//            System.Collections.ArrayList parts = new ArrayList();
//            FbParameter auxPar;

//            reg_count = 0;
//            cantidad = 0;

//            try
//            {


//                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
//                if (!(bool)productBE.isnull["IID"])
//                {
//                    auxPar.Value = productBE.IID;
//                }
//                else
//                {
//                    return false;

//                }
//                parts.Add(auxPar);


//                string commandText = @"select count(*) NUM_REGISTROS, sum(cantidad) CANTIDAD, MAX(lote) LOTE, MAX(FECHAVENCE) FECHAVENCE
//                                       from inventario
//                                       where productoid = @PRODUCTOID";
//                /**/FbDataReader dr = null;
            FbConnection pcn = null;
//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);
//                if (st == null)
//                   dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
//                else
//                  dr=  SqlHelper.ExecuteReader(st, CommandType.StoredProcedure, commandText, arParms);

//                if (dr.Read())
//                {
//                    if (dr["NUM_REGISTROS"] != System.DBNull.Value)
//                    {
//                        reg_count = (int)(dr["NUM_REGISTROS"]);
//                    }
//                    if (dr["CANTIDAD"] != System.DBNull.Value)
//                    {
//                        cantidad = (decimal)(dr["CANTIDAD"]);
//                    }

//                    if (dr["LOTE"] != System.DBNull.Value)
//                    {
//                        lote = dr["LOTE"].ToString();
//                    }

//                    if (dr["FECHAVENCE"] != System.DBNull.Value)
//                    {
//                        fechaVence = (DateTime)dr["FECHAVENCE"];
//                    }
//                }
                
//                return true;
//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }

        }




        public bool BorrarMOVTOVENTAS(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPROMOCION", FbDbType.Char);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_DELETE";

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




        public bool AdjuntarMovtos(long movtoPadreId, long movtoHijoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOPADREID", FbDbType.BigInt);
                auxPar.Value = movtoPadreId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOADJUNTARID", FbDbType.Char);
                auxPar.Value = movtoHijoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_ADJUNTARMOVIL";

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
                        this.iComentario = "Hubo un error " ;
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



        public bool AdjuntarMovtosEliminar(long movtoPadreId,  FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOPADREID", FbDbType.BigInt);
                auxPar.Value = movtoPadreId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_ADJUNTOELIMINARMOVIL";

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
                        this.iComentario = "Hubo un error ";
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




        public bool MOVTO_HAYPENDIENTES_EXPORT(FbTransaction st, ref bool bHayCambios)
        {
            bHayCambios = true;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@HAYCAMBIOS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_HAYPENDIENTES_EXPORT";

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
                        this.iComentario = "Hubo un error ";
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if (arParms[arParms.Length - 2].Value.ToString().Equals("N"))
                    {
                        bHayCambios = false;
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



        public bool MOVIL_ESTA_FINALIZADO(FbTransaction st, ref bool bHayCambios)
        {
            bHayCambios = true;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ESTAFINALIZADO", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVIL_ESTA_FINALIZADO";

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
                        this.iComentario = "Hubo un error ";
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if (arParms[arParms.Length - 2].Value.ToString().Equals("N"))
                    {
                        bHayCambios = false;
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




        public bool MOVIL_GETNEXTCOBRANZAFOLIO(FbTransaction st, ref long folio)
        {
            folio = 0;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@FOLIO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVIL_GETNEXTCOBRANZAFOLIO";

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
                        this.iComentario = "Hubo un error ";
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    folio = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool MOVIL_GETNEXTVENTAFOLIO(FbTransaction st, ref long folio)
        {
            folio = 0;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@FOLIO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVIL_GETNEXTVENTAFOLIO";

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
                        this.iComentario = "Hubo un error ";
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    folio = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        
        public bool ValidarFechaSistema(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VALIDAR_FECHASISTEMA";

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

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
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





        public bool GET_PRODUCTO_PRECIO_DOCTO(int? productoId, int? personaId, decimal? cantidad,int? tipoDoctoId, int? sucursalId, int? sucursalTId , decimal? costoProd, ref decimal? precioNuevo , FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (productoId.HasValue)
                    auxPar.Value = productoId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (personaId.HasValue)
                    auxPar.Value = personaId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (cantidad.HasValue)
                    auxPar.Value = cantidad;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (tipoDoctoId.HasValue)
                    auxPar.Value = tipoDoctoId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (sucursalId.HasValue)
                    auxPar.Value = sucursalId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (sucursalTId.HasValue)
                    auxPar.Value = sucursalTId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@COSTOPROD", FbDbType.Numeric);
                if (costoProd.HasValue)
                    auxPar.Value = costoProd;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"GET_PRODUCTO_PRECIO_DOCTO";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    precioNuevo = (decimal)arParms[arParms.Length - 2].Value;
                   
                }
                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool GET_PRECIOS_PRODUCTO_LISTA(int? productoId, int? personaId, decimal? cantidad,  int? sucursalTId, ref decimal? precioLista, ref decimal? precioTraspaso, ref decimal? precioMinimo, ref decimal? costo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (productoId.HasValue)
                    auxPar.Value = productoId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (personaId.HasValue)
                    auxPar.Value = personaId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (cantidad.HasValue)
                    auxPar.Value = cantidad;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (sucursalTId.HasValue)
                    auxPar.Value = sucursalTId;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@PRECIOLISTA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOTRASPASO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOMINIMO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"GET_PRECIOS_PRODUCTO_LISTA";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    costo = (decimal)arParms[arParms.Length - 2].Value;

                }

                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    precioMinimo = (decimal)arParms[arParms.Length - 3].Value;

                }

                if (!(arParms[arParms.Length - 4].Value == System.DBNull.Value))
                {
                    precioTraspaso = (decimal)arParms[arParms.Length - 4].Value;

                }


                if (!(arParms[arParms.Length - 5].Value == System.DBNull.Value))
                {
                    precioLista = (decimal)arParms[arParms.Length - 5].Value;

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool APLICAR_DESCUENTO_VALEVenta(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.APLICAR_DESCUENTO_VALEDoctoD(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool ContieneRecargas(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.ContieneRecargas(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool ActualizarClienteDOCTO(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.ActualizarClienteDOCTOD(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool CambiarPrecioMOVTOVENTAS(CMOVTOBE oCMOVTO, long supervisorId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOCONIVA", FbDbType.Decimal);
                auxPar.Value = oCMOVTO.IPRECIO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUPERVISORID", FbDbType.BigInt);
                auxPar.Value = supervisorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_CAMBIAR_PRECIOCONIVA";

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




        public bool VENTA_PRECIERRE(CDOCTOBE doctoBE, FbTransaction st, ref int errorCode)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORFINAL", FbDbType.BigInt);
                auxPar.Value = doctoBE.IVENDEDORFINAL;
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENDEDOREJECUTIVOID", FbDbType.BigInt);
                if (!(bool)doctoBE.isnull["IVENDEDOREJECUTIVOID"])
                {
                    auxPar.Value = doctoBE.IVENDEDOREJECUTIVOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTA_PRECIERRE";

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
                        errorCode = (int)arParms[arParms.Length - 1].Value;

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)errorCode, this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
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


        public bool VENTA_POSTINICIO(CDOCTOBE doctoBE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTA_POSTINICIO";

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



        public bool VENTA_ENTREGARMERCANCIA(CDOCTOBE doctoBE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_ENTREGARMERCANCIA";

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





        public bool VENTA_RETORNARMERCANCIA(CDOCTOBE doctoBE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_RETORNARMERCANCIA";

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




        public bool VALIDAR_PARAFACTURAELECTRONICA(CDOCTOBE doctoBE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);
                auxPar = new FbParameter("@PERSONARFC", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@STRINGERRORES", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VALIDEZ", FbDbType.Char);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VALIDAR_PARAFACTURAELECTRONICA";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                string VALIDEZ = "S";
                string RFC = "", PERSONARFC = "";

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    VALIDEZ = (string)arParms[arParms.Length - 1].Value;
                    if (VALIDEZ.Equals("N"))
                    {
                        if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                        {
                            this.iComentario = (string)arParms[arParms.Length - 2].Value;
                        }
                        else
                        {
                            this.iComentario = "parece haber un error de validacion de datos, porfavor cheque los datos de la empresa y el cliente o proveedor";
                        }

                        return false;

                    }
                }



                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    RFC = (string)arParms[arParms.Length - 3].Value;           
                }
                if (!(arParms[arParms.Length - 4].Value == System.DBNull.Value))
                {
                    PERSONARFC = (string)arParms[arParms.Length - 4].Value;
                }


                if (!CPuntoDeVentaD.isRFC(RFC))
                {
                    this.iComentario = "El rfc de la empresa no tiene el formato correcto";
                    return false; 
                }

                if (!CPuntoDeVentaD.isRFC(PERSONARFC))
                {
                    this.iComentario = "El rfc del cliente o proveedor no tiene el formato correcto";
                    return false;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public static bool isRFC(string tsInputRFC)
        {
            string lsPatron = @"^[A-ZÑ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9][A-Z,0-9][0-9A]$";
            Regex loRE = new Regex(lsPatron);
            if (loRE.IsMatch(tsInputRFC))
                return true;
            else
                return false;
        }

        public bool AsignarRazonDescuentoCajero(string strRazonDescuento, int movtoId, FbTransaction st)
        {
            CMOVTOBE movto = new CMOVTOBE();
            CMOVTOD movtoD = new CMOVTOD();
            movto.IID = movtoId;
            movto.IRAZONDESCUENTOCAJERO = strRazonDescuento;
            return movtoD.AsignarRazonDescuentoCajero(movto, st);

        }



        public bool CambiarDescripcionesComodin(long movtoId, string desc1, string desc2, string desc3, FbTransaction st)
        {
            CMOVTOBE movto = new CMOVTOBE();
            CMOVTOD movtoD = new CMOVTOD();
            movto.IID = movtoId;
            movto.IDESCRIPCION1 = desc1;
            movto.IDESCRIPCION2 = desc2;
            movto.IDESCRIPCION3 = desc3;
            return movtoD.CambiarDescripcionesComodin(movto, st);

        }





        public bool REQUIERERECETA(CDOCTOBE doctoBE, FbTransaction st)
        {
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                int cantidadCuenta = 0;


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);


                string commandText = @"SELECT COUNT(*) AS CUENTA FROM MOVTO INNER JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID 
                                       WHERE MOVTO.DOCTOID = @DOCTOID AND PRODUCTO.REQUIERERECETA = 'S'";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);

                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        cantidadCuenta = (int)(dr["CUENTA"]);
                    }
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                
                return (cantidadCuenta > 0);

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool KIT_HAYEXISALVUELOPARAENSAMBLE(long lDoctoID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@HAYEXISTENCIA", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"KIT_HAYEXISALVUELOPARAENSAMBLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), null);
                        return false;
                    }
                }
                else
                {
                    if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                    {
                        if ((string)arParms[arParms.Length - 2].Value == "S")
                        {
                            return true;
                        }
                    }
                }

                return false;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool KIT_CREARALVUELOFALTANTE(long lDoctoID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOIDPARALLENAR", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"KIT_CREARALVUELOFALTANTE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), null);
                        this.iComentario = "Hubo un error : " + strMensajeErr;
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







        public bool VALIDAR_PRECIOS_DOCTO(long lDoctoID, long vendedorId, FbTransaction st, ref string movtosIdInvalidos, ref string valido)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOVTOIDSNOVALIDOS", FbDbType.Text);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VALIDO", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"VALIDAR_PRECIOS_DOCTO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), null);
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    valido = ((string)arParms[arParms.Length - 2].Value);
                }

                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value || arParms[arParms.Length - 3].Value.ToString().Length == 0))
                {
                   // byte[] byteArr = (byte[])arParms[arParms.Length - 3].Value;
                    movtosIdInvalidos = ((string)arParms[arParms.Length - 3].Value);  //System.Text.Encoding.UTF8.GetString(byteArr);
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public bool DEVOLUCIONVENTA_POSTINICIO(CDOCTOBE doctoBE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DEVOLUCIONVENTA_POSTINICIO";

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


        public bool SETESTADOREBAJA_COTIENRUTADA(long doctoId, long movtoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = movtoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"SETESTADOREBAJA_COTIENRUTADA";

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


        public CPuntoDeVentaD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }







    }
}
