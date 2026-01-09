

using BindingModels;
using IposV3.Model;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using Castle.Core.Internal;
using IposV3.Services;


namespace Controllers.Controller
{
    public class PuntoVentaDevo_ApiAux
    {
        ProductoController productoController;
        //InventarioController inventarioController;
        DoctoController doctoController;
        MovtoController movtoController;
        PuntoVentaDevoController puntoVentaDevoController;
        PuntoVentaController puntoVentaController;
        ClienteController clienteController;

        public PuntoVentaDevo_ApiAux(
            PuntoVentaDevoController puntoVentaDevoController,
            PuntoVentaController puntoVentaController,
            ClienteController clienteController,
            ProductoController productoController,
            //InventarioController inventarioController,
            DoctoController doctoController,
            MovtoController movtoController)
        {
            this.puntoVentaDevoController = puntoVentaDevoController;
            this.puntoVentaController = puntoVentaController;
            this.productoController = productoController;
            //this.inventarioController = inventarioController;
            this.doctoController = doctoController;
            this.movtoController = movtoController;
            this.clienteController = clienteController;
        }

        //Aux methods

        public MovtoVenddevoTrans FillAddMovtoParameters(MovtoBindingModel movto, DoctoBindingModel docto, bool? precionetoenpv,
                                           decimal? precio, decimal? cantidad, string lote, DateTimeOffset? fechavence,
                                           long? loteImportado, long usuarioId)
        {




            var Fnc_movto_venddevo_insertParam = new MovtoVenddevoTrans();


            Fnc_movto_venddevo_insertParam.Loteimportado = loteImportado ?? movto.Loteimportado;
            Fnc_movto_venddevo_insertParam.Movtoparentid = null;
            Fnc_movto_venddevo_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Usuarioid = usuarioId;

            Fnc_movto_venddevo_insertParam.Lote = lote ?? movto.Lote;
            Fnc_movto_venddevo_insertParam.Fechavence = fechavence ?? movto.Fechavence;
            Fnc_movto_venddevo_insertParam.Localidad = movto.Movto_inventario_Localidad;
            Fnc_movto_venddevo_insertParam.Descripcion1 = movto.Movto_comodin_Descripcion1;
            Fnc_movto_venddevo_insertParam.Descripcion2 = movto.Movto_comodin_Descripcion2;
            Fnc_movto_venddevo_insertParam.Descripcion3 = movto.Movto_comodin_Descripcion3;
            Fnc_movto_venddevo_insertParam.Empresaid = movto!.EmpresaId!.Value;
            Fnc_movto_venddevo_insertParam.Sucursalid = movto!.SucursalId!.Value;
            Fnc_movto_venddevo_insertParam.Id = movto.Id != null ? movto!.Id : 0;
            Fnc_movto_venddevo_insertParam.Doctoid = docto!.Id!.Value;
            Fnc_movto_venddevo_insertParam.Partida = movto.Partida;
            Fnc_movto_venddevo_insertParam.Estatusmovtoid = movto!.Estatusmovtoid!.Value;
            Fnc_movto_venddevo_insertParam.Productoid = movto!.Productoid!.Value;

            Fnc_movto_venddevo_insertParam.Cantidad = cantidad!.Value;
            Fnc_movto_venddevo_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_venddevo_insertParam.Precio = precio;

            if (!(precionetoenpv ?? false))
            {
                Fnc_movto_venddevo_insertParam.Precioconimp = movto!.Precio;
            }

            return Fnc_movto_venddevo_insertParam;
        }



        //calculation prices

        public void AssignPrecioDescuentos(decimal? precio, decimal? descuento, ref PuntoVentaDevoBindingModel pvBindingModel)
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
                                            PuntoVentaDevoBindingModel pvBindingModel,
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
                                                PuntoVentaDevoBindingModel pvBindingModel)
        {

            var tipodescuentoprodid = pvBindingModel.Tipodescuentoprodid;
            decimal dPrecioBaseSinImpuestos = 0;

            dPrecioBaseSinImpuestos = tipodescuentoprodid == 2 ? precioCalculado : (producto.Producto_precios_Precio1 ?? 0m);
            return dPrecioBaseSinImpuestos;

        }



        //lotes

        //lote movto
        private BaseResultBindingModel VerificarLoteIfNeeded(MovtoVenddevoTrans movtoItem, ProductoBindingModel producto)
        {

            BaseResultBindingModel result = new BaseResultBindingModel();
            result.Result = 0;

            if (producto.Producto_inventario_Manejalote == null || producto.Producto_inventario_Manejalote != BoolCN.S)
            {
                return result;
            }

            if (movtoItem.Lote.IsNullOrEmpty())
            {
                result.Result = -10001;
                result.Usermessage = "Se necesita informacion de lote";
                result.Devmessage = result.Usermessage;
                return result;
            }

            return result;

        }




        //lote movto
        private BaseResultBindingModel VerificarLoteImportadoIfNeeded(MovtoVenddevoTrans movtoItem, ProductoBindingModel producto)
        {

            BaseResultBindingModel result = new BaseResultBindingModel();
            result.Result = 0;

            if (producto.Producto_loteimportado_Manejaloteimportado == null || producto.Producto_loteimportado_Manejaloteimportado != BoolCN.S)
            {
                return result;
            }

            if (movtoItem.Loteimportado == null)
            {
                result.Result = -10002;
                result.Usermessage = "Se necesita informacion de lote importado";
                result.Devmessage = result.Usermessage;
                return result;
            }

            return result;

        }



        public void LlenarPuntoVentaDevoInfo(ref PuntoVentaDevoBindingModel pvBindingModel)
        {


            ReLoadbasicDocto(ref pvBindingModel);
            ReloadMovtoItems((long)pvBindingModel.CurrentDocto!.Id!, ref pvBindingModel);

            if(pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                ReloadMovtoToDevoItems((long)pvBindingModel.CurrentDocto!.Id!, pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);
        }


        public void AssignProducto(long productoId, ref PuntoVentaDevoBindingModel pvBindingModel)
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



        public bool SaveMovtos(ref PuntoVentaDevoBindingModel pvBindingModel)
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

            LlenarPuntoVentaDevoInfo(ref pvBindingModel);


            return true;

        }



        //Save movto
        public bool SaveMovtoRecord(MovtoVenddevoTrans movto, ref PuntoVentaDevoBindingModel pvBindingModel)
        {

            var precionetoenpv = pvBindingModel.Precionetoenpv;

            if (pvBindingModel.CurrentDocto == null)
            {
                //MessageBox.Show("Debe primero agregar el docto");
                pvBindingModel.BaseResultBindingModel = pvBindingModel.Fnc_docto_venddevo_insertResult;
                return false;
            }
            if (pvBindingModel.CurrentDocto.Id <= 0 || pvBindingModel.CurrentDocto.Id == null)
            {
                if (!SaveDoctoRecord(ref pvBindingModel))
                {
                    //throw new Exception("Error al insertar el documento ");
                    pvBindingModel.BaseResultBindingModel = pvBindingModel.Fnc_docto_venddevo_insertResult;
                    return false;
                }
            }




            movto.Doctoid = pvBindingModel.CurrentDocto!.Id!.Value;


            pvBindingModel.Fnc_movto_venddevo_insertResult = this.puntoVentaDevoController.Movto_venddevo_insert(movto);

            if (pvBindingModel.Fnc_movto_venddevo_insertResult?.Result == null && pvBindingModel.Fnc_movto_venddevo_insertResult.Result.Value <= 0)
            {
                pvBindingModel.BaseResultBindingModel = pvBindingModel.Fnc_docto_venddevo_insertResult;
                return false;
            }

            ReLoadbasicDocto(ref pvBindingModel);

            return true;

        }

        //save docto
        public bool SaveDoctoRecord(ref PuntoVentaDevoBindingModel pvBindingModel)
        {

            var Fnc_docto_vendeduria_insertParam = new DoctoVenddevoTrans();


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


            Fnc_docto_vendeduria_insertParam.Doctoadevolverid = pvBindingModel.CurrentDocto.Docto_devolucion_Doctorefid;

            pvBindingModel.Fnc_docto_venddevo_insertResult = puntoVentaDevoController.Docto_venddevo_insert(Fnc_docto_vendeduria_insertParam);


            pvBindingModel.CurrentDocto.Id = pvBindingModel.Fnc_docto_venddevo_insertResult?.Result;

            return pvBindingModel.Fnc_docto_venddevo_insertResult.Result != null && pvBindingModel.Fnc_docto_venddevo_insertResult.Result.Value > 0;
        }

        public void ReLoadbasicDocto(ref PuntoVentaDevoBindingModel pvBindingModel)
        {
            DoctoBindingModel itemBuffer = doctoController.Get_BasicDocto(pvBindingModel.CurrentDocto!);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDocto = itemBuffer;
            }
        }

        public void ReLoadFullRefDocto(long doctoRefId, ref PuntoVentaDevoBindingModel pvBindingModel)
        {
            DoctoBindingModel itemBuffer = new DoctoBindingModel();
            itemBuffer.EmpresaId = pvBindingModel.CurrentDocto!.EmpresaId;
            itemBuffer.SucursalId = pvBindingModel.CurrentDocto!.SucursalId;
            itemBuffer.Id = doctoRefId;

            itemBuffer = doctoController.GetById(itemBuffer);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDoctoRef = itemBuffer;
            }

        }

        public void ReLoadFullDocto(ref PuntoVentaDevoBindingModel pvBindingModel)
        {
            DoctoBindingModel itemBuffer = doctoController.GetById(pvBindingModel.CurrentDocto!);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDocto = itemBuffer;
                AssignClientInfo(ref pvBindingModel);
            }


        }


        public void AssignClientInfo(ref PuntoVentaDevoBindingModel pvBindingModel)
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

            if (pvBindingModel.CurrentDocto != null && buffer != null)
            {
                pvBindingModel.CurrentDocto.ClienteClave = buffer.Clave;
                pvBindingModel.CurrentDocto.ClienteNombre = buffer.Nombre;
            }
        }


        public void ReloadMovtoItems(long doctoId, ref PuntoVentaDevoBindingModel pvBindingModel)
        {
            pvBindingModel.MovtoItems = new List<V_movto_venddevoWFBindingModel>();
            try
            {
                System.Collections.Generic.List<V_movto_vendeduriaWFBindingModel> items = new System.Collections.Generic.List<V_movto_vendeduriaWFBindingModel>();



                pvBindingModel.MovtoItems = puntoVentaDevoController.Select_V_movto_venddevo_List(
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


        public void ReloadMovtoToDevoItems(long doctoId, long doctoRefId, ref PuntoVentaDevoBindingModel pvBindingModel)
        {
            pvBindingModel.MovtoToDevoItems = new List<V_movto_vend_to_devoWFBindingModel>();
            try
            {


                pvBindingModel.MovtoToDevoItems = puntoVentaDevoController.Select_V_movto_vend_to_devo_List(
                                        pvBindingModel.CurrentDocto.EmpresaId.Value,
                                        pvBindingModel.CurrentDocto.SucursalId.Value,
                                        doctoId,
                                        doctoRefId
                                        );

            }
            catch //(Exception ex)
            {
                //ErrorEditActions("Ocurrio un error " + ex.Message);
            }
        }


    }
}
