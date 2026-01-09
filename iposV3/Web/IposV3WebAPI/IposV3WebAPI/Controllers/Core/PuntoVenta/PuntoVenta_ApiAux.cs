
using BindingModels;
using IposV3.Model;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using Castle.Core.Internal;
using IposV3.Services;

namespace Controllers.Controller
{
    public class PuntoVenta_ApiAux
    {


        ProductoController productoController;
        InventarioController inventarioController;
        DoctoController doctoController;
        MovtoController movtoController;
        PuntoVentaController puntoVentaController;
        ClienteController clienteController;

        public PuntoVenta_ApiAux(
            PuntoVentaController puntoVentaController,
            ClienteController clienteController,
            ProductoController productoController,
            InventarioController inventarioController,
            DoctoController doctoController,
            MovtoController movtoController) 
        {
            this.puntoVentaController = puntoVentaController;
            this.productoController = productoController;
            this.inventarioController = inventarioController;
            this.doctoController = doctoController;
            this.movtoController = movtoController;
            this.clienteController = clienteController;
        }


        //Aux methods

        public MovtoVendTrans FillAddMovtoParameters(MovtoBindingModel movto, DoctoBindingModel docto, bool? precionetoenpv,
                                           decimal? precio, decimal? cantidad, string? lote, DateTimeOffset? fechavence, 
                                           long? loteImportado, long usuarioId)
        {

            var Fnc_movto_vendeduria_insertParam = new MovtoVendTrans();


            Fnc_movto_vendeduria_insertParam.Loteimportado = loteImportado ?? movto.Loteimportado;
            Fnc_movto_vendeduria_insertParam.Movtoparentid = null;
            Fnc_movto_vendeduria_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Usuarioid = usuarioId;

            Fnc_movto_vendeduria_insertParam.Lote = lote ?? movto.Lote;
            Fnc_movto_vendeduria_insertParam.Fechavence = fechavence ?? movto.Fechavence;
            Fnc_movto_vendeduria_insertParam.Localidad = movto.Movto_inventario_Localidad;
            Fnc_movto_vendeduria_insertParam.Descripcion1 = movto.Movto_comodin_Descripcion1;
            Fnc_movto_vendeduria_insertParam.Descripcion2 = movto.Movto_comodin_Descripcion2;
            Fnc_movto_vendeduria_insertParam.Descripcion3 = movto.Movto_comodin_Descripcion3;
            Fnc_movto_vendeduria_insertParam.Empresaid = movto!.EmpresaId!.Value;
            Fnc_movto_vendeduria_insertParam.Sucursalid = movto!.SucursalId!.Value;
            Fnc_movto_vendeduria_insertParam.Id = movto.Id != null ? movto!.Id : 0;
            Fnc_movto_vendeduria_insertParam.Doctoid = docto!.Id!.Value;
            Fnc_movto_vendeduria_insertParam.Partida = movto.Partida;
            Fnc_movto_vendeduria_insertParam.Estatusmovtoid = movto!.Estatusmovtoid!.Value;
            Fnc_movto_vendeduria_insertParam.Productoid = movto!.Productoid!.Value;

            Fnc_movto_vendeduria_insertParam.Cantidad = cantidad!.Value;
            Fnc_movto_vendeduria_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_vendeduria_insertParam.Precio = precio;

            if (!(precionetoenpv ?? false))
            {
                Fnc_movto_vendeduria_insertParam.Precioconimp = movto!.Precio;
            }

            Fnc_movto_vendeduria_insertParam.Preciomanual = movto!.Preciomanual;


            return Fnc_movto_vendeduria_insertParam;
        }


        public void AssignProducto(long productoId, ref PuntoVentaBindingModel pvBindingModel)
        {

            pvBindingModel.CurrentMovto!.Productoid = productoId;


            var currentProducto = new ProductoBindingModel();
            currentProducto.EmpresaId = pvBindingModel.CurrentDocto.EmpresaId;
            currentProducto.SucursalId = pvBindingModel.CurrentDocto.SucursalId;
            currentProducto.Id = productoId;

            pvBindingModel.CurrentProducto = productoController.GetById(currentProducto);


            if (pvBindingModel.CurrentProducto == null)
            {
                pvBindingModel.CurrentProducto = new ProductoBindingModel();
                pvBindingModel.CurrentMovto.DescripcionProductoMovto = "";
            }
            else
            {
                pvBindingModel.CurrentMovto.DescripcionProductoMovto = currentProducto!.Nombre + " // " +
                                                        currentProducto!.Descripcion + " // " +
                                                        currentProducto!.Descripcion1 + " // " +
                                                        currentProducto!.Producto_existencia_Existencia;


            }


        }



        //calculation prices
        public void AssignPrecioDescuentos(decimal? precio, decimal? descuento, ref PuntoVentaBindingModel pvBindingModel)
        {
            var precionetoenpv = pvBindingModel.Precionetoenpv;

            decimal? precio_final = precio;
            decimal? descuento_final = descuento;


            AssignPrecioDescuentosOut(pvBindingModel.CurrentDocto.EmpresaId,
                                              pvBindingModel.CurrentDocto.SucursalId,
                                              precio, descuento,
                                              pvBindingModel.CurrentProducto?.Id, pvBindingModel.CurrentDocto.Clienteid!.Value,
                                              pvBindingModel.CurrentMovto!.Cantidad!.Value, precionetoenpv == BoolCN.S, pvBindingModel.CurrentProducto!,
                                              pvBindingModel,
                                              out precio_final, out descuento_final);


            pvBindingModel.CurrentMovto._Precio = precio_final;
            pvBindingModel.CurrentMovto._Descuentoporcentaje = descuento_final;




        }

        private void AssignPrecioDescuentosOut(long? empresaId, long? sucursalId, decimal? precio, decimal? descuento, long? productoId, long clienteId, decimal cantidad, bool precionetoenpv, ProductoBindingModel producto,
                                            PuntoVentaBindingModel pvBindingModel,
                                            out decimal? precio_final, out decimal? descuento_final)
        {

            precio_final = precio;
            descuento_final = descuento;

            decimal precioCalculado = 0;
            decimal dPrecioBaseSinImpuestos = 0;
            bool precioEnBaseADescuento = precio == null && descuento != null;
            bool precioPorCalcular = precio == null && descuento == null;

            decimal precioAMostrar = 0m;
            decimal descuentoAMostrar = 0m;
            V_preciosProd_RefBindingModel precio_info_de_calculo = null;



            precioCalculado = PrecioCalculado(pvBindingModel.CurrentDocto.EmpresaId,
                                              pvBindingModel.CurrentDocto.SucursalId,
                                              productoId, clienteId,
                                              cantidad, 0, out precio_info_de_calculo);

            dPrecioBaseSinImpuestos = PrecioBaseSinImpuestos(empresaId,
                                              sucursalId,
                                              productoId, clienteId,
                                              cantidad, precioCalculado, 0, producto, pvBindingModel);


            if (precioEnBaseADescuento)
            {
                precioAMostrar = (precioCalculado * ((100 - descuento!.Value) / 100));
                descuentoAMostrar = descuento!.Value;
            }
            else
            {
                if (precioPorCalcular)
                    precioAMostrar = precioCalculado;
                else
                {
                    if (!precionetoenpv)
                        precioAMostrar = producto.calculaPrecioSinImpuestos(precio!.Value);
                    else
                        precioAMostrar = precio!.Value;

                }


                descuentoAMostrar = 100.00m - ((100.00m * precioAMostrar) / dPrecioBaseSinImpuestos);
            }

            if (!precionetoenpv)
                precioAMostrar = producto.calculaPrecioConImpuestos(precioAMostrar);

            if (precioEnBaseADescuento || precioPorCalcular)
                precio_final = precioAMostrar;

            if (!precioEnBaseADescuento)
                descuento_final = descuentoAMostrar;


        }


        private decimal PrecioCalculado(long? empresaId, long? sucursalId, long? productoId, long clienteId, decimal cantidad, long sucursalTid,
                                        out V_preciosProd_RefBindingModel precio_info_de_calculo)
        {

            decimal precioCalculado = 0;
            //fnc_preciosprod_ref_provParam.P_sucursaltid = sucursalTid;
            V_preciosProd_RefBindingModel buffer = null;


            buffer = puntoVentaController.Precioprod_ref_vend(empresaId!.Value, sucursalId!.Value, productoId!.Value, clienteId, cantidad);


            precio_info_de_calculo = buffer;

            if (precio_info_de_calculo != null && precio_info_de_calculo.Preciolista != null)
                precioCalculado = precio_info_de_calculo.Preciolista.Value;
            else
                precioCalculado = 0;

            return precioCalculado;

        }

        private decimal PrecioBaseSinImpuestos(long? empresaId, long? sucursalId, long? productoId, long clienteId, decimal cantidad, decimal precioCalculado, long sucursalTid, ProductoBindingModel producto,
                                                PuntoVentaBindingModel pvBindingModel)
        {

            var tipodescuentoprodid = pvBindingModel.Tipodescuentoprodid;
            decimal dPrecioBaseSinImpuestos = 0;

            dPrecioBaseSinImpuestos = tipodescuentoprodid == 2 ? precioCalculado : (producto.Producto_precios_Precio1 ?? 0m);
            return dPrecioBaseSinImpuestos;

        }





        public void LlenarPuntoVentaInfo(ref PuntoVentaBindingModel pvBindingModel)
        {


            ReLoadbasicDocto(ref pvBindingModel);
            ReloadMovtoItems((long)pvBindingModel.CurrentDocto!.Id!, ref pvBindingModel);
        }

        public bool SaveMovtos(ref PuntoVentaBindingModel pvBindingModel)
        {
            BaseResultBindingModel bufferResult = new BaseResultBindingModel();

            foreach (var movtoItem in pvBindingModel.MovtoTransList)
            {

                if (movtoItem.Productoid == 0)
                {
                    continue;
                }

                var producto = productoController.GetById(new ProductoBindingModel() { EmpresaId = movtoItem.Empresaid, SucursalId = movtoItem.Sucursalid, Id = movtoItem.Productoid });

                if (producto == null)
                {
                    bufferResult.Result = -10004;
                    bufferResult.Usermessage = "No se encontro el producto";
                    bufferResult.Devmessage = bufferResult.Usermessage;
                    pvBindingModel.BaseResultBindingModel = bufferResult;
                    return false;
                }

                bufferResult = VerificarDescripcionComodinIfNeeded(movtoItem, producto);
                if(bufferResult.Result < 0)
                {
                    pvBindingModel.BaseResultBindingModel = bufferResult;
                    return false;
                }
                bufferResult = VerificarLoteIfNeeded(movtoItem, producto);
                if (bufferResult.Result < 0)
                {
                    pvBindingModel.BaseResultBindingModel = bufferResult;
                    return false;
                }

                bufferResult = VerificarLoteImportadoIfNeeded(movtoItem, producto);
                if (bufferResult.Result < 0)
                {
                    pvBindingModel.BaseResultBindingModel = bufferResult;
                    return false;
                }

            }


            foreach (var movtoItem in pvBindingModel.MovtoTransList)
            {
                bool result = SaveMovtoRecord(movtoItem, ref pvBindingModel);

                if (!result)
                {
                    return false;
                }
            }

            LlenarPuntoVentaInfo(ref pvBindingModel);


            return true;

       }





        //descripcion comodin movto

        private BaseResultBindingModel VerificarDescripcionComodinIfNeeded(MovtoVendTrans movtoItem, ProductoBindingModel producto)
        {
            BaseResultBindingModel result = new BaseResultBindingModel();
            result.Result = 0;


            if (producto.Producto_comodin_Descripcion_comodin == null ||
                producto.Producto_comodin_Descripcion_comodin != BoolCN.S)
                return result;

            if (movtoItem!.Id != null && movtoItem.Id > 0)
                return result;

            if (!string.IsNullOrEmpty(movtoItem!.Descripcion1) ||
                !string.IsNullOrEmpty(movtoItem!.Descripcion2) ||
                !string.IsNullOrEmpty(movtoItem!.Descripcion3))
                return result;


            result.Result = -10003;
            result.Usermessage = "Necesita ingresar la descripcion del producto comodin";
            result.Devmessage = result.Usermessage;

            return result;
        }





        //existence
        private bool ValidateExistence(long empresaid, long sucursalid
                    , bool b_ignorealmacen
                    , bool b_ignorelote
                    , bool b_ignoreenprocesosalida
                    , bool b_ignoreparaarmar
                    , bool b_onlyverify
                    , long P_productoid
                    , decimal P_cantidad
                    , long? P_tipodoctoid
                    , long? P_almacenid
                    , string P_lote
                    , DateTimeOffset? P_fechavence
                    , long? P_movtorefid
                    , out Fnc_verify_existenceResult result)
        {
            Fnc_verify_existenceParam paramExistence = new Fnc_verify_existenceParam()
            {
                P_empresaid = empresaid,
                P_sucursalid = sucursalid,
                P_lote = P_lote,
                P_ignorealmacen = b_ignorealmacen ? BoolCN.S : BoolCN.N,
                P_ignorelote = b_ignorelote ? BoolCN.S : BoolCN.N,
                P_ignoreenprocesosalida = b_ignoreenprocesosalida ? BoolCN.S : BoolCN.N,
                P_ignoreparaarmar = b_ignoreparaarmar ? BoolCN.S : BoolCN.N,
                P_onlyverify = b_onlyverify ? BoolCN.S : BoolCN.N,
                P_productoid = P_productoid,
                P_cantidad = P_cantidad,
                P_tipodoctoid = P_tipodoctoid,
                P_almacenid = P_almacenid,
                P_fechavence = P_fechavence,
                P_movtorefid = P_movtorefid


            };

            Fnc_verify_existenceResult buffer = inventarioController.Verify_existence(paramExistence);


            result = buffer ?? new Fnc_verify_existenceResult();

            if (buffer != null)
                return buffer.Hayexistencia == BoolCS.S;

            return false;
        }



        //lote movto
        private BaseResultBindingModel VerificarLoteIfNeeded(MovtoVendTrans movtoItem, ProductoBindingModel producto)
        {

            BaseResultBindingModel result = new BaseResultBindingModel();
            result.Result = 0;

            if (producto.Producto_inventario_Manejalote == null || producto.Producto_inventario_Manejalote != BoolCN.S)
            {
                return result;
            }

            if(movtoItem.Lote.IsNullOrEmpty() )
            {
                result.Result = -10001;
                result.Usermessage = "Se necesita informacion de lote";
                result.Devmessage = result.Usermessage;
                return result;
            }

            return result;

        }




        //lote movto
        private BaseResultBindingModel VerificarLoteImportadoIfNeeded(MovtoVendTrans movtoItem, ProductoBindingModel producto)
        {

            BaseResultBindingModel result = new BaseResultBindingModel();
            result.Result = 0;

            if (producto.Producto_loteimportado_Manejaloteimportado == null || producto.Producto_loteimportado_Manejaloteimportado != BoolCN.S)
            {
                return result;
            }

            if (movtoItem.Loteimportado == null )
            {
                result.Result = -10002;
                result.Usermessage = "Se necesita informacion de lote importado";
                result.Devmessage = result.Usermessage;
                return result;
            }

            return result;

        }


        //Save movto

        public bool SaveMovtoRecord(MovtoVendTrans movto, ref PuntoVentaBindingModel pvBindingModel)
        {

            var precionetoenpv = pvBindingModel.Precionetoenpv;

            if (pvBindingModel.CurrentDocto == null)
            {
                //MessageBox.Show("Debe primero agregar el docto");
                return false;
            }
            if (pvBindingModel.CurrentDocto.Id <= 0 || pvBindingModel.CurrentDocto.Id == null)
            {
                if (!SaveDoctoRecord(ref pvBindingModel))
                {
                    //throw new Exception("Error al insertar el documento ");
                    return false;
                }
            }


            //string seManejaAlmacen = IposV3.Model.Parametros.GetStringFromClaveAndList(GlobalVariable.CurrentSession.CurrentParametros, "manejaalmacen");
            Fnc_verify_existenceResult existenceResult = new Fnc_verify_existenceResult();
            var existenceValid = ValidateExistence(movto.Empresaid,
                                                    movto.Sucursalid,
                                                    !pvBindingModel.ManejaAlmacen,//seManejaAlmacen == null || !seManejaAlmacen.Equals("S"), //ignore almacen
                                                    true, //b_ignorelote
                                                    false, //b_ignoreenprocesosalida
                                                    false, //b_ignoreparaarmar
                                                    true, //b_onlyverify
                                                    movto.Productoid,
                                                     movto.Cantidad,
                                                     pvBindingModel.CurrentDocto!.Tipodoctoid,
                                                     pvBindingModel.CurrentDocto.Almacenid,
                                                     movto.Lote,
                                                     movto.Fechavence,
                                                     null,//P_movtorefid
                                                     out existenceResult);



            if (!existenceValid)
            {
                //throw new Exception("Error al agregar movimiento " + " No hay existencia suficiente");
                return false;
            }



            movto.Doctoid = pvBindingModel.CurrentDocto!.Id!.Value;


            pvBindingModel.Fnc_movto_vendeduria_insertResult = this.puntoVentaController.Movto_vend_insert(movto);

            if (pvBindingModel.Fnc_movto_vendeduria_insertResult?.Result == null || pvBindingModel.Fnc_movto_vendeduria_insertResult.Result.Value <= 0)
            {

                pvBindingModel.BaseResultBindingModel = pvBindingModel.Fnc_movto_vendeduria_insertResult;
                return false;
            }

            ReLoadbasicDocto(ref pvBindingModel);

            return true;

        }

        public MovtoVendTrans FillAddMovtoParameters(MovtoBindingModel movto, DoctoBindingModel docto, bool? precionetoenpv,
                                           decimal? precio, decimal? cantidad, string lote, DateTimeOffset? fechavence, long? loteImportado,
                                           ref PuntoVentaBindingModel pvBindingModel)
        {

            var Fnc_movto_vendeduria_insertParam = new MovtoVendTrans();


            Fnc_movto_vendeduria_insertParam.Loteimportado = loteImportado ?? movto.Loteimportado;
            Fnc_movto_vendeduria_insertParam.Movtoparentid = null;
            Fnc_movto_vendeduria_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Usuarioid = pvBindingModel.CurrentDocto.Usuarioid.Value;

            Fnc_movto_vendeduria_insertParam.Lote = lote ?? movto.Lote;
            Fnc_movto_vendeduria_insertParam.Fechavence = fechavence ?? movto.Fechavence;
            Fnc_movto_vendeduria_insertParam.Localidad = movto.Movto_inventario_Localidad;
            Fnc_movto_vendeduria_insertParam.Descripcion1 = movto.Movto_comodin_Descripcion1;
            Fnc_movto_vendeduria_insertParam.Descripcion2 = movto.Movto_comodin_Descripcion2;
            Fnc_movto_vendeduria_insertParam.Descripcion3 = movto.Movto_comodin_Descripcion3;
            Fnc_movto_vendeduria_insertParam.Empresaid = movto!.EmpresaId!.Value;
            Fnc_movto_vendeduria_insertParam.Sucursalid = movto!.SucursalId!.Value;
            Fnc_movto_vendeduria_insertParam.Id = movto.Id != null ? pvBindingModel.CurrentMovto!.Id : 0;
            Fnc_movto_vendeduria_insertParam.Doctoid = docto!.Id!.Value;
            Fnc_movto_vendeduria_insertParam.Partida = movto.Partida;
            Fnc_movto_vendeduria_insertParam.Estatusmovtoid = movto!.Estatusmovtoid ?? DBValues._DOCTO_ESTATUS_BORRADOR;
            Fnc_movto_vendeduria_insertParam.Productoid = movto!.Productoid!.Value;

            Fnc_movto_vendeduria_insertParam.Cantidad = cantidad!.Value;
            Fnc_movto_vendeduria_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_vendeduria_insertParam.Precio = precio;

            if (!(precionetoenpv ?? false))
            {
                Fnc_movto_vendeduria_insertParam.Precioconimp = movto!.Precio;
            }

            Fnc_movto_vendeduria_insertParam.Preciomanual = movto!.Preciomanual;


            return Fnc_movto_vendeduria_insertParam;
        }


        //save docto
        public bool SaveDoctoRecord(ref PuntoVentaBindingModel pvBindingModel)
        {

            var Fnc_docto_vendeduria_insertParam = new DoctoVendTrans();


            Fnc_docto_vendeduria_insertParam.Referencia = pvBindingModel.CurrentDocto!.Referencia;
            Fnc_docto_vendeduria_insertParam.Referencias = pvBindingModel.CurrentDocto.Referencias;
            Fnc_docto_vendeduria_insertParam.Fechavence = pvBindingModel.CurrentDocto.Fechavence;

            Fnc_docto_vendeduria_insertParam.Mercanciaentregada = pvBindingModel.CurrentDocto.Docto_apartado_Mercanciaentregada;
            Fnc_docto_vendeduria_insertParam.Pagocontarjeta = pvBindingModel.CurrentDocto.Docto_info_pago_Pagocontarjeta;
            Fnc_docto_vendeduria_insertParam.Pagoacredito = pvBindingModel.CurrentDocto.Docto_info_pago_Pagoacredito;

            Fnc_docto_vendeduria_insertParam.Promocion = pvBindingModel.CurrentDocto.Docto_promocion_Promocion ?? BoolCN.N;
            Fnc_docto_vendeduria_insertParam.Empresaid = pvBindingModel.CurrentDocto.EmpresaId!.Value;
            Fnc_docto_vendeduria_insertParam.Sucursalid = pvBindingModel.CurrentDocto.SucursalId!.Value;
            Fnc_docto_vendeduria_insertParam.Estatusdoctoid = pvBindingModel.CurrentDocto.Estatusdoctoid!.Value;
            Fnc_docto_vendeduria_insertParam.Usuarioid = pvBindingModel.CurrentDocto.Usuarioid!.Value;
            Fnc_docto_vendeduria_insertParam.Creadopor_userid = pvBindingModel.CurrentDocto.Usuarioid!.Value;
            Fnc_docto_vendeduria_insertParam.Fecha = pvBindingModel.CurrentDocto.Fecha!.Value;
            Fnc_docto_vendeduria_insertParam.Cajaid = pvBindingModel.CurrentDocto.Cajaid!.Value;
            Fnc_docto_vendeduria_insertParam.Almacenid = pvBindingModel.CurrentDocto.Almacenid!.Value;
            Fnc_docto_vendeduria_insertParam.Origenfiscalid = pvBindingModel.CurrentDocto.Origenfiscalid!.Value;
            Fnc_docto_vendeduria_insertParam.Doctoparentid = pvBindingModel.CurrentDocto.Doctoparentid;
            Fnc_docto_vendeduria_insertParam.Clienteid = pvBindingModel.CurrentDocto.Clienteid!.Value;
            Fnc_docto_vendeduria_insertParam.Tipodoctoid = pvBindingModel.CurrentDocto.Tipodoctoid!.Value;
            Fnc_docto_vendeduria_insertParam.Sucursal_id = pvBindingModel.CurrentDocto.Sucursal_id!.Value;
            Fnc_docto_vendeduria_insertParam.Sucursaltid = pvBindingModel.CurrentDocto.Docto_traslado_Sucursaltid;
            Fnc_docto_vendeduria_insertParam.Almacentid = pvBindingModel.CurrentDocto.Docto_traslado_Almacentid;



            pvBindingModel.Fnc_docto_vendeduria_insertResult = puntoVentaController.Docto_vend_insert(Fnc_docto_vendeduria_insertParam);


            pvBindingModel.CurrentDocto.Id = pvBindingModel.Fnc_docto_vendeduria_insertResult?.Result;

            return pvBindingModel.Fnc_docto_vendeduria_insertResult.Result != null && pvBindingModel.Fnc_docto_vendeduria_insertResult.Result.Value > 0;
        }


        public void ReLoadbasicDocto(ref PuntoVentaBindingModel pvBindingModel)
        {
            DoctoBindingModel? itemBuffer = doctoController.Get_BasicDocto(pvBindingModel.CurrentDocto!);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDocto = itemBuffer;
            }
        }


        public void ReLoadFullDocto(ref PuntoVentaBindingModel pvBindingModel)
        {
            DoctoBindingModel? itemBuffer = doctoController.GetById(pvBindingModel.CurrentDocto!);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDocto = itemBuffer;
                AssignClientInfo(ref pvBindingModel);
            }

        }


        public void AssignClientInfo(ref PuntoVentaBindingModel pvBindingModel)
        {
            if (pvBindingModel.CurrentDocto?.Clienteid.HasValue != true || pvBindingModel.CurrentDocto!.Clienteid!.Value == 0)
            {
                pvBindingModel.CurrentCliente = new ClienteBindingModel();
                return;
            }


            ClienteBindingModel buffer = null;


            buffer = clienteController.GetById(new ClienteBindingModel()
                {
                    Id = pvBindingModel.CurrentDocto.Clienteid.Value,
                    EmpresaId = pvBindingModel.CurrentDocto.EmpresaId,
                    SucursalId = pvBindingModel.CurrentDocto.SucursalId

                });

            pvBindingModel.CurrentCliente = buffer;

            if (pvBindingModel.CurrentDocto != null && buffer != null )
            {
                pvBindingModel.CurrentDocto.ClienteClave = buffer.Clave;
                pvBindingModel.CurrentDocto.ClienteNombre = buffer.Nombre;
            }
        }

        public void ReloadMovtoItems(long doctoId, ref PuntoVentaBindingModel pvBindingModel)
        {
            pvBindingModel.MovtoItems = new List<V_movto_vendeduriaWFBindingModel>();
            try
            {
                System.Collections.Generic.List<V_movto_vendeduriaWFBindingModel> items = new System.Collections.Generic.List<V_movto_vendeduriaWFBindingModel>();



                pvBindingModel.MovtoItems = puntoVentaController.Select_V_movto_vendeduria_List(
                                        pvBindingModel.CurrentDocto.EmpresaId.Value,
                                        pvBindingModel.CurrentDocto.SucursalId.Value,
                                        doctoId
                                        );

            }
            catch //(Exception ex)
            {
                //ErrorEditActions("Ocurrio un error " + ex.Message);
            }
        }

    }
}
