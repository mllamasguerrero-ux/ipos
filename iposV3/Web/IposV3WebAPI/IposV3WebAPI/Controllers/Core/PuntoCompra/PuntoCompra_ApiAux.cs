
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
//--using Syncfusion.Data.Extensions;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;
using KendoNET.DynamicLinq;
//--using Syncfusion.Windows.Shared;
using Castle.Core.Internal;
using IposV3.Services;
using Castle.Core.Logging;

namespace Controllers.Controller
{
    public class PuntoCompra_ApiAux
    {


        ProductoController productoController;
        DoctoController doctoController;
        MovtoController movtoController;
        PuntoCompraController puntoCompraController;
        ProveedorController proveedorController;

        public PuntoCompra_ApiAux(
            PuntoCompraController puntoCompraController,
            ProveedorController proveedorController,
            ProductoController productoController,
            DoctoController doctoController,
            MovtoController movtoController) 
        {
            this.puntoCompraController = puntoCompraController;
            this.proveedorController = proveedorController;
            this.productoController = productoController;
            this.doctoController = doctoController;
            this.movtoController = movtoController;
        }


        //Aux methods

        public void AssignProducto(long productoId, ref PuntoCompraBindingModel pvBindingModel)
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
        public void AssignPrecioDescuentos(decimal? precio, decimal? descuento, ref PuntoCompraBindingModel pvBindingModel)
        {
            var precionetoenpv = pvBindingModel.Precionetoenpv;

            decimal? precio_final = precio;
            decimal? descuento_final = descuento;


            AssignPrecioDescuentosOut(pvBindingModel.CurrentDocto.EmpresaId,
                                              pvBindingModel.CurrentDocto.SucursalId,
                                              precio, descuento,
                                              pvBindingModel.CurrentProducto?.Id, pvBindingModel.CurrentDocto.Proveedorid!.Value,
                                              pvBindingModel.CurrentMovto!.Cantidad!.Value, precionetoenpv == BoolCN.S, pvBindingModel.CurrentProducto!,
                                              pvBindingModel,
                                              out precio_final, out descuento_final);


            pvBindingModel.CurrentMovto._Precio = precio_final;
            pvBindingModel.CurrentMovto._Descuentoporcentaje = descuento_final;




        }

        private void AssignPrecioDescuentosOut(long? empresaId, long? sucursalId, decimal? precio, decimal? descuento, long? productoId, long proveedorId, decimal cantidad, bool precionetoenpv, ProductoBindingModel producto,
                                            PuntoCompraBindingModel pvBindingModel,
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
                                              productoId, proveedorId,
                                              cantidad, 0, out precio_info_de_calculo);

            dPrecioBaseSinImpuestos = PrecioBaseSinImpuestos(empresaId,
                                              sucursalId,
                                              productoId, proveedorId,
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


        private decimal PrecioCalculado(long? empresaId, long? sucursalId, long? productoId, long proveedorId, decimal cantidad, long sucursalTid,
                                        out V_preciosProd_RefBindingModel precio_info_de_calculo)
        {

            decimal precioCalculado = 0;
            //fnc_preciosprod_ref_provParam.P_sucursaltid = sucursalTid;
            V_preciosProd_RefBindingModel buffer = null;


            buffer = puntoCompraController.Precioprod_ref_prov(empresaId!.Value, sucursalId!.Value, productoId!.Value, proveedorId, cantidad);


            precio_info_de_calculo = buffer;

            if (precio_info_de_calculo != null && precio_info_de_calculo.Preciolista != null)
                precioCalculado = precio_info_de_calculo.Preciolista.Value;
            else
                precioCalculado = 0;

            return precioCalculado;

        }

        private decimal PrecioBaseSinImpuestos(long? empresaId, long? sucursalId, long? productoId, long proveedorId, decimal cantidad, decimal precioCalculado, long sucursalTid, ProductoBindingModel producto,
                                                PuntoCompraBindingModel pvBindingModel)
        {

            var tipodescuentoprodid = pvBindingModel.Tipodescuentoprodid;
            decimal dPrecioBaseSinImpuestos = 0;

            dPrecioBaseSinImpuestos = tipodescuentoprodid == 2 ? precioCalculado : (producto.Producto_precios_Precio1 ?? 0m);
            return dPrecioBaseSinImpuestos;

        }




        public void LlenarPuntoCompraInfo(ref PuntoCompraBindingModel pvBindingModel)
        {


            ReLoadbasicDocto(ref pvBindingModel);
            ReloadMovtoItems((long)pvBindingModel.CurrentDocto!.Id!, ref pvBindingModel);
        }



        public bool SaveMovtos(ref PuntoCompraBindingModel pvBindingModel)
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
                bool result = SaveMovto_(movtoItem, ref pvBindingModel);

                if (!result)
                {
                    return false;
                }
            }

            ReLoadbasicDocto(ref pvBindingModel);
            ReloadMovtoItems((long)pvBindingModel.CurrentDocto!.Id!, ref pvBindingModel);

            return true;

        }




        public bool SaveMovto_(MovtoProvTrans movto, ref PuntoCompraBindingModel pvBindingModel)
        {

            try
            {

                if (movto?.Productoid == null || movto.Productoid == 0)
                {
                    return false;
                }

                SaveMovtoRecord(movto, ref pvBindingModel);
                return true;

            }
            catch //(Exception ex)
            {
                //showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
                return false;
            }

        }



        //lote movto
        private BaseResultBindingModel VerificarLoteIfNeeded(MovtoProvTrans movtoItem, ProductoBindingModel producto)
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
        private BaseResultBindingModel VerificarLoteImportadoIfNeeded(MovtoProvTrans movtoItem, ProductoBindingModel producto)
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



        //Save movto
        public bool SaveMovtoRecord(MovtoProvTrans movto, ref PuntoCompraBindingModel pvBindingModel)
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

            movto.Doctoid = pvBindingModel.CurrentDocto!.Id!.Value;


            pvBindingModel.Fnc_movto_proveeduria_insertResult = this.puntoCompraController.Movto_prov_insert(movto);

            if (pvBindingModel.Fnc_movto_proveeduria_insertResult?.Result == null || pvBindingModel.Fnc_movto_proveeduria_insertResult.Result.Value <= 0)
            {

                //throw new Exception("Error al insertar el movimiento " +
                //(Fnc_movto_vendeduria_insertResult?.Result == null ? "" : Fnc_movto_proveeduria_insertResult.Usermessage));
                return false;
            }

            ReLoadbasicDocto(ref pvBindingModel);

            return true;

        }

        public MovtoProvTrans FillAddMovtoParameters(MovtoBindingModel movto, DoctoBindingModel docto, bool? precionetoenpv,
                                           decimal? precio, decimal? cantidad, string lote, DateTimeOffset? fechavence, long? loteImportado,
                                           long usuarioId)
        {

            var Fnc_movto_prov_insertParam = new MovtoProvTrans();

            Fnc_movto_prov_insertParam.Loteimportado = movto!.Loteimportado;
            Fnc_movto_prov_insertParam.Movtoparentid = null;
            Fnc_movto_prov_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_prov_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_prov_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_prov_insertParam.Usuarioid = usuarioId;

            Fnc_movto_prov_insertParam.Lote = movto.Lote;
            Fnc_movto_prov_insertParam.Fechavence = movto.Fechavence;
            Fnc_movto_prov_insertParam.Localidad = movto.Movto_inventario_Localidad;
            Fnc_movto_prov_insertParam.Descripcion1 = movto.Movto_comodin_Descripcion1;
            Fnc_movto_prov_insertParam.Descripcion2 = movto.Movto_comodin_Descripcion2;
            Fnc_movto_prov_insertParam.Descripcion3 = movto.Movto_comodin_Descripcion3;
            Fnc_movto_prov_insertParam.Empresaid = movto!.EmpresaId!.Value;
            Fnc_movto_prov_insertParam.Sucursalid = movto!.SucursalId!.Value;
            Fnc_movto_prov_insertParam.Id = movto.Id != null ? movto.Id : 0;
            Fnc_movto_prov_insertParam.Doctoid = docto!.Id!.Value;
            Fnc_movto_prov_insertParam.Partida = movto.Partida;
            Fnc_movto_prov_insertParam.Estatusmovtoid = movto!.Estatusmovtoid!.Value;
            Fnc_movto_prov_insertParam.Productoid = movto!.Productoid!.Value;
            Fnc_movto_prov_insertParam.Cantidad = cantidad!.Value;

            Fnc_movto_prov_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_prov_insertParam.Precio = precio;

            if (!(precionetoenpv ?? false))
            {
                Fnc_movto_prov_insertParam.Precioconimp = movto!.Precio;
            }

            return Fnc_movto_prov_insertParam;


        }


        //save docto
        public bool SaveDoctoRecord(ref PuntoCompraBindingModel pcBindingModel)
        {


            var Fnc_docto_prov_insertParam = new DoctoProvTrans();

            Fnc_docto_prov_insertParam.Referencia = pcBindingModel.CurrentDocto.Referencia;
            Fnc_docto_prov_insertParam.Referencias = pcBindingModel.CurrentDocto.Referencias;
            Fnc_docto_prov_insertParam.Promocion = pcBindingModel.CurrentDocto.Docto_promocion_Promocion ?? BoolCN.N;
            Fnc_docto_prov_insertParam.Empresaid = pcBindingModel.CurrentDocto.EmpresaId!.Value;
            Fnc_docto_prov_insertParam.Sucursalid = pcBindingModel.CurrentDocto.SucursalId!.Value;
            Fnc_docto_prov_insertParam.Estatusdoctoid = pcBindingModel.CurrentDocto.Estatusdoctoid!.Value;
            Fnc_docto_prov_insertParam.Usuarioid = pcBindingModel.CurrentDocto.Usuarioid!.Value;
            Fnc_docto_prov_insertParam.Creadopor_userid = pcBindingModel.CurrentDocto.Usuarioid!.Value;
            Fnc_docto_prov_insertParam.Fecha = pcBindingModel.CurrentDocto.Fecha!.Value;
            Fnc_docto_prov_insertParam.Cajaid = pcBindingModel.CurrentDocto.Cajaid!.Value;
            Fnc_docto_prov_insertParam.Almacenid = pcBindingModel.CurrentDocto.Almacenid!.Value;
            Fnc_docto_prov_insertParam.Origenfiscalid = pcBindingModel.CurrentDocto.Origenfiscalid!.Value;
            Fnc_docto_prov_insertParam.Folio_c = pcBindingModel.CurrentDocto.Docto_compra_Folio;
            Fnc_docto_prov_insertParam.Factura_c = pcBindingModel.CurrentDocto.Docto_compra_Factura;
            Fnc_docto_prov_insertParam.Fechafactura_c = pcBindingModel.CurrentDocto.Docto_compra_Fechafactura;
            Fnc_docto_prov_insertParam.Fechavence_c = pcBindingModel.CurrentDocto.Fechavence;
            Fnc_docto_prov_insertParam.Doctoparentid = pcBindingModel.CurrentDocto.Doctoparentid;
            Fnc_docto_prov_insertParam.Proveedorid = pcBindingModel.CurrentDocto.Proveedorid!.Value;
            Fnc_docto_prov_insertParam.Tipodoctoid = pcBindingModel.CurrentDocto.Tipodoctoid!.Value;
            Fnc_docto_prov_insertParam.Sucursal_id = pcBindingModel.CurrentDocto.Sucursal_id!.Value;
            Fnc_docto_prov_insertParam.Sucursaltid = pcBindingModel.CurrentDocto.Docto_traslado_Sucursaltid;
            Fnc_docto_prov_insertParam.Almacentid = pcBindingModel.CurrentDocto.Docto_traslado_Almacentid;



            pcBindingModel.Fnc_docto_proveeduria_insertResult = puntoCompraController.Docto_prov_insert(Fnc_docto_prov_insertParam);


            pcBindingModel.CurrentDocto.Id = pcBindingModel.Fnc_docto_proveeduria_insertResult?.Result;

            return pcBindingModel.Fnc_docto_proveeduria_insertResult.Result != null && pcBindingModel.Fnc_docto_proveeduria_insertResult.Result.Value > 0;
        }


        public void ReLoadbasicDocto(ref PuntoCompraBindingModel pvBindingModel)
        {
            DoctoBindingModel itemBuffer = doctoController.Get_BasicDocto(pvBindingModel.CurrentDocto!);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDocto = itemBuffer;
            }
        }

        public void ReLoadFullDocto(ref PuntoCompraBindingModel pvBindingModel)
        {
            DoctoBindingModel? itemBuffer = doctoController.GetById(pvBindingModel.CurrentDocto!);


            if (itemBuffer != null)
            {
                pvBindingModel.CurrentDocto = itemBuffer;
                AssignProveedorInfo(ref pvBindingModel);
            }
        }


        public void AssignProveedorInfo(ref PuntoCompraBindingModel pvBindingModel)
        {
            if (pvBindingModel.CurrentDocto?.Proveedorid.HasValue != true || pvBindingModel.CurrentDocto!.Proveedorid!.Value == 0)
            {
                pvBindingModel.CurrentProveedor = new ProveedorBindingModel();
                return;
            }


            ProveedorBindingModel buffer = null;


            buffer = proveedorController.GetById(new ProveedorBindingModel()
            {
                Id = pvBindingModel.CurrentDocto.Proveedorid.Value,
                EmpresaId = pvBindingModel.CurrentDocto.EmpresaId,
                SucursalId = pvBindingModel.CurrentDocto.SucursalId

            });

            pvBindingModel.CurrentProveedor = buffer;

            if (pvBindingModel.CurrentDocto != null && buffer != null)
            {
                pvBindingModel.CurrentDocto.ProveedorClave = buffer.Clave;
                pvBindingModel.CurrentDocto.ProveedorNombre = buffer.Nombre;
            }
        }



        public void ReloadMovtoItems(long doctoId, ref PuntoCompraBindingModel pvBindingModel)
        {
            pvBindingModel.MovtoItems = new List<V_movto_proveeduriaWFBindingModel>();
            try
            {
                System.Collections.Generic.List<V_movto_vendeduriaWFBindingModel> items = new System.Collections.Generic.List<V_movto_vendeduriaWFBindingModel>();



                pvBindingModel.MovtoItems = puntoCompraController.Select_V_movto_proveeduria_List(
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
