using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using IposV3.Services.Extensions;
using System.Reflection.Metadata.Ecma335;

namespace IposV3.Services
{
    public class ProveeduriaService
    {

        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private DoctoMovtoService _doctoMovtoService;
        private PagoService _pagoService;

        public ProveeduriaService(
            DoctoService doctoService,
            MovtoService movtoService,
            DoctoMovtoService doctoMovtoService,
            PagoService pagoService)
        {
            _doctoService = doctoService;
            _movtoService = movtoService;
            _doctoMovtoService = doctoMovtoService;
            _pagoService = pagoService;
        }




        public void Docto_prov_insert(DoctoProvTrans doctoProvTrans, ref long? doctoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoTrans = new DoctoTransaction()
                {
                    Empresaid = doctoProvTrans.Empresaid,
                    Sucursalid = doctoProvTrans.Sucursalid,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = doctoProvTrans.Creadopor_userid,
                    Estatusdoctoid = doctoProvTrans.Estatusdoctoid,
                    Usuarioid = doctoProvTrans.Usuarioid,
                    Corteid = null,
                    Fecha = doctoProvTrans.Fecha,
                    Fechahora = DateTimeOffset.UtcNow,
                    Serie = null,
                    Folio = 0,
                    Importe = 0m,
                    Descuento = 0m,
                    Subtotal = 0m,
                    Iva = 0m,
                    Ieps = 0m,
                    Total = 0m,
                    Cargo = 0m,
                    Abono = 0m,
                    Saldo = 0m,
                    Cajaid = doctoProvTrans.Cajaid,
                    Almacenid = doctoProvTrans.Almacenid,
                    Origenfiscalid = doctoProvTrans.Origenfiscalid,
                    Esapartado = BoolCN.N,
                    Doctoparentid = doctoProvTrans.Doctoparentid,
                    Clienteid = null,
                    Tipodoctoid = doctoProvTrans.Tipodoctoid,
                    Proveedorid = doctoProvTrans.Proveedorid != 0 ? doctoProvTrans.Proveedorid : null,
                    Sucursal_id = doctoProvTrans.Sucursal_id,
                    Referencia = doctoProvTrans.Referencia,
                    Referencias = doctoProvTrans.Referencias,
                    Fechavence = doctoProvTrans.Fechavence_c

                };

                _doctoService.DoctoInsert(doctoTrans, ref doctoId, localContext);

                var docto_traslado = new Docto_traslado()
                {
                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = doctoProvTrans.Usuarioid,
                    EmpresaId = doctoProvTrans.Empresaid,
                    SucursalId = doctoProvTrans.Sucursalid,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = doctoProvTrans.Usuarioid,
                    Sucursaltid = doctoProvTrans.Sucursaltid,
                    Almacentid = doctoProvTrans.Almacentid,
                    Doctoid = doctoId

                };
                localContext.Add(docto_traslado);


                var docto_compra = new Docto_compra()
                {

                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = doctoProvTrans.Usuarioid,
                    EmpresaId = doctoProvTrans.Empresaid,
                    SucursalId = doctoProvTrans.Sucursalid,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = doctoProvTrans.Usuarioid,
                    Doctoid = doctoId,
                    Folio = doctoProvTrans.Folio_c,
                    Factura = doctoProvTrans.Factura_c,
                    Fechafactura = doctoProvTrans.Fechafactura_c
                };
                localContext.Add(docto_compra);

                localContext.SaveChanges();



            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }



        public void Docto_prov_update_estatus(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                _doctoMovtoService.Docto_update_status(empresaId, sucursalId, id, estatusDoctoId, localContext);

                var movtoInfo_list = localContext.Movto.AsNoTracking()
                                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id)
                                                    .Select(m => new { m.Id })
                                                    .ToList();
                foreach(var movtoInfo in movtoInfo_list)
                {
                    Movto_prov_update_status(empresaId, sucursalId, movtoInfo.Id, estatusDoctoId, localContext);
                }

                localContext.SaveChanges();


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }



        public void Docto_prov_and_payments_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            List<DoctoPagoDirect> listPagos,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                long? bufferPagoId = null;
                foreach (var pagoDirect in listPagos)
                {
                    bufferPagoId = null;
                    _pagoService.Docto_pago_directo(pagoDirect, ref bufferPagoId, localContext);

                    if ((bufferPagoId ?? 0) == 0)
                        throw new Exception("EL pago no se inserto");
                }


                Docto_prov_save(empresaId, sucursalId, id, estatusDoctoId, localContext);

            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void Docto_prov_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                Docto_prov_update_estatus(empresaId, sucursalId, id, estatusDoctoId, localContext);

                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Include(d => d.Docto_traslado)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id && d.Docto_traslado != null)
                                            .Select(d => new { Sucursaltid = (d.Docto_traslado != null ? d.Docto_traslado.Sucursaltid : null), d.Folio, d.Sucursal_id })
                                            .FirstOrDefault();

                if(doctoInfo != null && (doctoInfo.Sucursaltid ?? 0) > 0 && (doctoInfo.Sucursaltid ?? 0) != (doctoInfo.Sucursal_id ?? 0))
                {
                    var docto_traslado = localContext.Docto_traslado
                                                     .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == id)
                                                     .Update(x => new Docto_traslado() { Essurtimientomerca = "S", 
                                                                                         Foliosolicitudmercancia = doctoInfo.Folio != null ? doctoInfo.Folio.ToString() : "" ,
                                                                                         Idsolicitudmercancia = id});
                }



            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void Docto_prov_delete(long empresaId, long sucursalId, long id,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoInfo = localContext.Docto.AsNoTracking()
                                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                                  m.Id == id)
                                                            .Select(m => new { m.Estatusdoctoid })
                                                            .FirstOrDefault();
                if (doctoInfo == null)
                    throw new Exception("No se encontro el docto");

                if (doctoInfo.Estatusdoctoid != 0)
                    throw new Exception("El registro no esta en  estatus de borrador");

                _doctoMovtoService.Docto_delete(empresaId, sucursalId, id, localContext);


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }

        public void Docto_prov_cancel(long empresaId, long sucursalId,
            long doctoId, long creadoPorId, ref long? doctoCancelacionId, 
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                            .Select(d => new { d.Estatusdoctoid, })
                                            .FirstOrDefault();

                if (doctoInfo == null)
                    throw new Exception("No hay docto");

                if ((doctoInfo.Estatusdoctoid ?? 0) != 1)
                    throw new Exception("Solo se pueden cancelar documentos que esten en estado activo");

                _doctoMovtoService.Docto_cancel(empresaId, sucursalId, doctoId, creadoPorId, ref doctoCancelacionId, localContext);

                if (doctoCancelacionId == null)
                    throw new Exception("El documento no se pudo cancelar");

            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }





        public void Movto_proveeduria_group(long empresaId, long sucursalId, long doctoId,
                                            long productoId, decimal? descuentoPorcentaje, decimal? precio,
                                            string? lote, DateTimeOffset? fechaVence, long? loteImportado,
                                            //long? movtoParentid, string? localidad, long? anaquelId, 
                                            decimal? precioConImp, 
                                            string? descripcion1, string? descripcion2, string? descripcion3,
                                            out long? movtoActualId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            movtoActualId = null;

            try
            {

                var bufferMovtoActualId = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_comodin)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                  m.Doctoid == doctoId && m.Productoid == productoId &&
                                                                  (m.Lote ?? "") == (lote ?? "") &&
                                                                  ((m.Fechavence == null && fechaVence == null) || m.Fechavence == fechaVence) &&
                                                                  (m.Loteimportado ?? 0) == (loteImportado ?? 0) &&
                                                                  (
                                                                    ((m.Movto_precio == null || (m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.N) && (precio == null || (m.Precio == (precio ?? 0m)))) ||
                                                                    (m.Movto_precio != null && (m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.S && (precioConImp == null || (m.Movto_precio.Precioconimp == (precioConImp ?? 0m))))
                                                                  ) &&
                                                                  (descuentoPorcentaje == null || (m.Descuentoporcentaje == Decimal.Round((descuentoPorcentaje ?? 0m),4))) &&
                                                                  ((string.IsNullOrEmpty(descripcion1)) || (m.Movto_comodin == null) ||  
                                                                            ((descripcion1 ?? "") == (m.Movto_comodin.Descripcion1 ?? "") && (descripcion2 ?? "") == (m.Movto_comodin.Descripcion2 ?? "") && (descripcion3 ?? "") == (m.Movto_comodin.Descripcion3 ?? "")))
                                                              )
                                                      .Select(m => (long?)m.Id)
                                                      .FirstOrDefault();

                if (bufferMovtoActualId != null)
                    movtoActualId = bufferMovtoActualId;



            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void Movto_prov_insert(MovtoProvTrans movtoProvTrans, ref long? movtoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? movtoexistenteid = null;

            //long? movtoId = null;

            var calc_imp_de_total = BoolCN.N;

            decimal? precio = movtoProvTrans.Precio;
            decimal? precioconimp = movtoProvTrans.Precioconimp;
            decimal? total = 0m;
            decimal? importe = 0m;
            decimal? subtotal = 0m;
            decimal? iva = 0m;
            decimal? ieps = 0m;
            decimal? impuesto = 0m;
            decimal? descuento = 0m;
            decimal? ivaRetenido = 0m;
            decimal? isrRetenido = 0m;
            decimal? tasaIvaRetenido = 0m;
            decimal? tasaIsrRetenido = 0m;

            List<MovtoKitdefinicionBuffer> movto_kit_def_arr = new List<MovtoKitdefinicionBuffer>();


            try
            {

                var producto_info = localContext.Producto.AsNoTracking()
                                                .Include(p => p.Producto_precios)
                                                .Include(p => p.Producto_kit)
                                                .Where(p => p.EmpresaId == movtoProvTrans.Empresaid && p.SucursalId == movtoProvTrans.Sucursalid && p.Id == movtoProvTrans.Productoid)
                                                .Select(p => new {
                                                    p.Ivaimpuesto,
                                                    p.Iepsimpuesto,
                                                    Preciolista = (p.Producto_precios != null ? p.Producto_precios.Costorepo : 0m),
                                                    Eskit = (p.Producto_kit != null ? p.Producto_kit.Eskit : BoolCN.N),
                                                    Kitimpfijo = (p.Producto_kit != null ? p.Producto_kit.Kitimpfijo : BoolCN.N)
                                                })
                                                .FirstOrDefault();

                if (producto_info == null)
                    throw new Exception("Producto no encontrado");


                if ((movtoProvTrans.Id ?? 0) != 0)
                {
                    movtoexistenteid = movtoProvTrans.Id;
                }
                else
                {


                    this.Movto_proveeduria_group(movtoProvTrans.Empresaid, movtoProvTrans.Sucursalid, movtoProvTrans.Doctoid,
                                                 movtoProvTrans.Productoid, movtoProvTrans.Descuentoporcentaje, movtoProvTrans.Precio,
                                                 movtoProvTrans.Lote, movtoProvTrans.Fechavence, movtoProvTrans.Loteimportado, 
                                                 //movtoProvTrans.Movtoparentid,movtoProvTrans.Localidad, movtoProvTrans.Anaquelid, 
                                                 movtoProvTrans.Precioconimp,
                                                 movtoProvTrans.Descripcion1, movtoProvTrans.Descripcion2, movtoProvTrans.Descripcion3,
                                                 out movtoexistenteid, localContext);


                }

                if ((movtoexistenteid ?? 0) == 0)
                {


                    if ((movtoProvTrans.Precioconimp ?? 0) != 0)
                    {



                        calc_imp_de_total = BoolCN.S;


                        precio = movtoProvTrans.Precio;
                        precioconimp = movtoProvTrans.Precioconimp;
                        total = 0m;
                        importe = 0m;
                        subtotal = 0m;
                        iva = 0m;
                        ieps = 0m;
                        impuesto = 0m;
                        descuento = 0m;
                        ivaRetenido = 0m;
                        isrRetenido = 0m;
                        tasaIvaRetenido = 0m;
                        tasaIsrRetenido = 0m;

                        _movtoService.CalcularImpuestosTotalesMovto(movtoProvTrans.Empresaid, movtoProvTrans.Sucursalid,
                                                    movtoProvTrans.Productoid, movtoProvTrans.Cantidad, producto_info!.Preciolista,
                                                    producto_info.Ivaimpuesto, producto_info.Iepsimpuesto,
                                                    producto_info.Eskit, producto_info.Kitimpfijo, calc_imp_de_total, movtoProvTrans.Movtoparentid,
                                                    null, ref precio, ref precioconimp, ref total, out importe, out subtotal,
                                                    out iva, out ieps, out impuesto, out descuento, out ivaRetenido, out isrRetenido, out tasaIvaRetenido, out tasaIsrRetenido,
                                                    out movto_kit_def_arr, localContext);





                    }


                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoProvTrans.Empresaid,
                        Sucursalid = movtoProvTrans.Sucursalid,
                        Id = 0,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.UtcNow,
                        Creadopor_userid = movtoProvTrans.Usuarioid,
                        Partida = movtoProvTrans.Partida,
                        Estatusmovtoid = movtoProvTrans.Estatusmovtoid,
                        Fecha = new DateTimeOffset(DateTime.Today).ToUniversalTime(),
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movtoProvTrans.Productoid,
                        Cantidad = movtoProvTrans.Cantidad,
                        Preciolista = producto_info!.Preciolista,
                        Descuentoporcentaje = movtoProvTrans.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = producto_info!.Ivaimpuesto,
                        Tasaieps = producto_info!.Iepsimpuesto,
                        Total = total,
                        Lote = movtoProvTrans.Lote,
                        Fechavence = movtoProvTrans.Fechavence,
                        Loteimportado = movtoProvTrans.Loteimportado,
                        Movtoparentid = movtoProvTrans.Movtoparentid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = producto_info!.Eskit,
                        Kitimpfijo = producto_info!.Kitimpfijo,
                        Doctoid = movtoProvTrans.Doctoid,
                        Cargo = 0m,
                        Abono = 0m,
                        Saldo = 0m,
                        Preciomanual = 0m,
                        Preciomaximopublico = 0m,
                        Isrretenido = 0m,
                        Ivaretenido = 0m,
                        Orden = 0,
                        Tasaisrretenido = 0m,
                        Tasaivaretenido = 0m,
                        Calc_imp_de_total = calc_imp_de_total,
                        Localidad = movtoProvTrans.Localidad,
                        Descripcion1 = movtoProvTrans.Descripcion1,
                        Descripcion2 = movtoProvTrans.Descripcion2,
                        Descripcion3 = movtoProvTrans.Descripcion3,
                        Agrupaporparametro = movtoProvTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = movtoProvTrans.Cargartarjetapreciomanual,
                        Precioyavalidado = movtoProvTrans.Precioyavalidado,
                        Usuarioid = movtoProvTrans.Usuarioid,
                        Precioconimp = movtoProvTrans.Precioconimp,
                        Anaquelid = movtoProvTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoInsert(movtoTransaction, ref movtoId, localContext);

                    var movto_precio = new Movto_precio()
                    {

                        EmpresaId = movtoProvTrans.Empresaid,
                        SucursalId = movtoProvTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.UtcNow,
                        CreadoPorId = movtoProvTrans.Usuarioid,
                        Modificado = DateTimeOffset.UtcNow,
                        ModificadoPorId = movtoProvTrans.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoId!.Value,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Listaprecioid = null,
                        Precioclasificacion = 0,
                        Precioconimp = precioconimp ?? 0m,
                        Calc_imp_de_total = calc_imp_de_total




                    };

                    localContext.Add(movto_precio);



                    if ((movtoProvTrans.Anaquelid ?? 0) != 0 || (movtoProvTrans.Localidad ?? "") != "")
                    {

                        var movto_inventario = new Movto_inventario()
                        {

                            EmpresaId = movtoProvTrans.Empresaid,
                            SucursalId = movtoProvTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.UtcNow,
                            CreadoPorId = movtoProvTrans.Usuarioid,
                            Modificado = DateTimeOffset.UtcNow,
                            ModificadoPorId = movtoProvTrans.Usuarioid,
                            Tipodiferenciainventarioid = null,
                            Localidad = movtoProvTrans.Localidad,
                            Anaquelid = movtoProvTrans.Anaquelid,
                            Registroprocesosalida = BoolCN.N,
                            Movtoid = movtoId,
                            Cantidad_real = 0m,
                            Cantidad_teorica = 0m,
                            Cantidad_diferencia = 0m
                        };

                        localContext.Add(movto_inventario);

                    }

                    if(!string.IsNullOrEmpty(movtoProvTrans.Descripcion1))
                    {
                        var movto_comodin = new Movto_comodin()
                        {

                            EmpresaId = movtoProvTrans.Empresaid,
                            SucursalId = movtoProvTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.UtcNow,
                            CreadoPorId = movtoProvTrans.Usuarioid,
                            Modificado = DateTimeOffset.UtcNow,
                            ModificadoPorId = movtoProvTrans.Usuarioid,
                            Movtoid = movtoId,
                            Descripcion1 = movtoProvTrans.Descripcion1,
                            Descripcion2 = movtoProvTrans.Descripcion2,
                            Descripcion3 = movtoProvTrans.Descripcion3
                        };
                        localContext.Add(movto_comodin);
                    }

                    localContext.SaveChanges();

                }
                else
                {

                    movtoId = movtoexistenteid;
                    var movto_a_cambiar = localContext.Movto.AsNoTracking()
                                                      .Where(m => m.EmpresaId == movtoProvTrans.Empresaid && m.SucursalId == movtoProvTrans.Sucursalid &&
                                                                  m.Id == movtoexistenteid)
                                                      .Select(m => new
                                                      {
                                                        Precio = (movtoProvTrans.Precio ?? m.Precio) ,
                                                        Descuentoporcentaje = (movtoProvTrans.Descuentoporcentaje ?? m.Descuentoporcentaje),
                                                        Preciolista = m.Preciolista,
                                                        Lote = m.Lote,
                                                        Fechavence = m.Fechavence,
                                                        Loteimportado = m.Loteimportado,
                                                        Partida = m.Partida,
                                                        Movtoparentid = m.Movtoparentid,
                                                        Cantidad = m.Cantidad + movtoProvTrans.Cantidad,
                                                        TasaIvaRetenido = m.Tasaivaretenido,
                                                        TasaIsrRetenido = m.Tasaisrretenido


                                                       })
                                                      .FirstOrDefault();

                    if (movto_a_cambiar == null)
                        throw new Exception("El registro se borro inesperadamente");


                    //movtoProvTrans.Precio = movto_existente.Precio;
                    //movtoProvTrans.Descuentoporcentaje = movto_existente.Descuentoporcentaje;
                    //movtoProvTrans.Lote = movto_existente.Lote;
                    //movtoProvTrans.Fechavence = movto_existente.Fechavence;
                    //movtoProvTrans.Loteimportado = movto_existente.Loteimportado;
                    //movtoProvTrans.Partida = movto_existente.Partida;
                    //movtoProvTrans.Movtoparentid = movto_existente.Movtoparentid;
                    //movtoProvTrans.Cantidad = movto_existente.Cantidad;


                    if (movto_a_cambiar.Cantidad <= 0)
                    {
                        throw new Exception("La cantidad no puede ser cero");
                    }

                    if ((movtoProvTrans.Precioconimp ?? 0) != 0)
                    {



                        calc_imp_de_total = BoolCN.S;


                        precio = movto_a_cambiar.Precio;
                        precioconimp = movtoProvTrans.Precioconimp;
                        total = 0m;
                        importe = 0m;
                        subtotal = 0m;
                        iva = 0m;
                        ieps = 0m;
                        impuesto = 0m;
                        descuento = 0m;
                        ivaRetenido = 0m;
                        isrRetenido = 0m;
                        tasaIvaRetenido = 0m;
                        tasaIsrRetenido = 0m;

                        _movtoService.CalcularImpuestosTotalesMovto(movtoProvTrans.Empresaid, movtoProvTrans.Sucursalid,
                                                    movtoProvTrans.Productoid, movto_a_cambiar.Cantidad, movto_a_cambiar!.Preciolista,
                                                    producto_info!.Ivaimpuesto, producto_info!.Iepsimpuesto,
                                                    producto_info!.Eskit, producto_info!.Kitimpfijo, calc_imp_de_total, movtoProvTrans.Movtoparentid,
                                                    null, ref precio, ref precioconimp, ref total, out importe, out subtotal,
                                                    out iva, out ieps, out impuesto, out descuento, out ivaRetenido, out isrRetenido, out tasaIvaRetenido, out tasaIsrRetenido,
                                                    out movto_kit_def_arr, localContext);





                    }



                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoProvTrans.Empresaid,
                        Sucursalid = movtoProvTrans.Sucursalid,
                        Id = movtoexistenteid!.Value,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = movtoProvTrans.Usuarioid,
                        Partida = movto_a_cambiar.Partida,
                        Estatusmovtoid = movtoProvTrans.Estatusmovtoid,
                        Fecha = DateTimeOffset.Now.Date,
                        Fechahora = DateTimeOffset.Now,
                        Productoid = movtoProvTrans.Productoid,
                        Cantidad = movto_a_cambiar.Cantidad,
                        Preciolista = movto_a_cambiar.Preciolista,
                        Descuentoporcentaje = movtoProvTrans.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = producto_info!.Ivaimpuesto,
                        Tasaieps = producto_info!.Iepsimpuesto,
                        Total = total,
                        Lote = movto_a_cambiar.Lote,
                        Fechavence = movto_a_cambiar.Fechavence,
                        Loteimportado = movto_a_cambiar.Loteimportado,
                        Movtoparentid = movto_a_cambiar.Movtoparentid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = producto_info!.Eskit,
                        Kitimpfijo = producto_info!.Kitimpfijo,
                        Doctoid = movtoProvTrans.Doctoid,
                        Cargo = 0m,
                        Abono = 0m,
                        Saldo = 0m,
                        Preciomanual = 0m,
                        Preciomaximopublico = 0m,
                        Isrretenido = 0m,
                        Ivaretenido = 0m,
                        Orden = 0,
                        Tasaisrretenido = 0m,
                        Tasaivaretenido = 0m,
                        Calc_imp_de_total = calc_imp_de_total,
                        Localidad = movtoProvTrans.Localidad,
                        Descripcion1 = movtoProvTrans.Descripcion1,
                        Descripcion2 = movtoProvTrans.Descripcion2,
                        Descripcion3 = movtoProvTrans.Descripcion3,
                        Agrupaporparametro = movtoProvTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = movtoProvTrans.Cargartarjetapreciomanual,
                        Precioyavalidado = movtoProvTrans.Precioyavalidado,
                        Usuarioid = movtoProvTrans.Usuarioid,
                        Precioconimp = movtoProvTrans.Precioconimp,
                        Anaquelid = movtoProvTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoUpdate(movtoTransaction, localContext);


                    localContext.SaveChanges();

                }


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void Movto_prov_update_status(long empresaId, long sucursalId, long id, long estatusMovtoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                _movtoService.MovtoUpdateStatus(empresaId, sucursalId, id, estatusMovtoId, localContext);

            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }

        public void Movto_prov_delete(long empresaId, long sucursalId, long id,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                  m.Id == id)
                                            .Select(m => new { m.Estatusmovtoid })
                                            .FirstOrDefault();
                if (movtoInfo == null)
                    throw new Exception("No se encontro el movto");

                if(movtoInfo.Estatusmovtoid != 0)
                    throw new Exception("El registro no esta en  estatus de borrador");

                _doctoMovtoService.Movto_delete(empresaId, sucursalId, id, localContext);



            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }





        public List<Tmp_movto_proveeduria> Movto_proveeduria(long empresaId, long sucursalId, long doctoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Listapreciominimo, p.Tipoutilidadid, p.Precionetoengrids })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("no hay parametro");

                var lstMovtoProveeduria = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_devolucion)
                                                      .Include(m => m.Movto_comodin)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Productocaracteristicas)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_existencia)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Unidad)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                                      .Select(m => new
                                                      {
                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Partida,
                                                          m.Productoid,
                                                          ProductoClave = m.Producto == null ? null : m.Producto.Clave,
                                                          ProductoNombre = m.Producto == null ? null : m.Producto.Nombre,
                                                          m.Cantidad,
                                                          m.Preciolista,
                                                          m.Descuentoporcentaje,
                                                          m.Descuento,
                                                          m.Precio,
                                                          m.Importe,
                                                          m.Subtotal,
                                                          m.Iva,
                                                          m.Ieps,
                                                          m.Tasaiva,
                                                          m.Tasaieps,
                                                          m.Total,
                                                          m.Lote,
                                                          m.Fechavence,
                                                          m.Loteimportado,
                                                          m.Doctoid,
                                                          m.Orden,
                                                          Descuentovale = m.Movto_precio == null ? 0m : m.Movto_precio.Descuentovale,
                                                          Descuentovaleporcentaje = m.Movto_precio == null ? 0m : m.Movto_precio.Descuentovaleporcentaje,
                                                          Ingresopreciomanual = m.Movto_precio == null ? 0m : m.Movto_precio.Ingresopreciomanual,
                                                          Porcentajedescuentomanual = m.Movto_precio == null ? 0m : m.Movto_precio.Porcentajedescuentomanual,
                                                          Descripcion1 = (m.Movto_comodin != null && m.Movto_comodin.Descripcion1 != null ? m.Movto_comodin.Descripcion1 :  (m.Producto == null ? null : m.Producto.Descripcion1)),
                                                          Descripcion2 = (m.Movto_comodin != null && m.Movto_comodin.Descripcion1 != null ? m.Movto_comodin.Descripcion2 : (m.Producto == null ? null : m.Producto.Descripcion2)),
                                                          Descripcion3 = (m.Movto_comodin != null && m.Movto_comodin.Descripcion1 != null ? m.Movto_comodin.Descripcion3 : (m.Producto == null ? null : m.Producto.Descripcion3)),
                                                          Cantidadsurtida = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidadsurtida,
                                                          Precio1 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio1,
                                                          Existencia = m.Producto == null || m.Producto.Producto_existencia == null ? 0m : m.Producto.Producto_existencia.Existencia,
                                                          Pzacaja = m.Producto == null || m.Producto.Producto_inventario == null ? 0m : m.Producto.Producto_inventario.Pzacaja,
                                                          Texto1 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Texto1,
                                                          Texto2 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Texto2,
                                                          Texto3 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Texto3,
                                                          Texto4 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Texto4,
                                                          Texto5 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Texto5,
                                                          Texto6 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Texto6,
                                                          Numero1 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Numero1,
                                                          Numero2 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Numero2,
                                                          Numero3 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Numero3,
                                                          Numero4 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Numero4,
                                                          Fecha1 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Fecha1,
                                                          Fecha2 = m.Producto == null || m.Producto.Productocaracteristicas == null ? null : m.Producto.Productocaracteristicas.Fecha2,
                                                          Unidadid = m.Producto == null ? null : m.Producto.Unidadid,
                                                          UnidadClave = m.Producto == null || m.Producto.Unidad == null ? null : m.Producto.Unidad.Clave,
                                                          UnidadNombre = m.Producto == null || m.Producto.Unidad == null ? null : m.Producto.Unidad.Nombre,


                                                          Costopromedio = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Costopromedio,
                                                          Costorepo = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Costorepo,
                                                          Costoultimo = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Costoultimo,
                                                          Precio2 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio2,
                                                          Precio3 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio3,
                                                          Precio4 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio4,
                                                          Precio5 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio5,
                                                          Precio6 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio6



                                                      }).ToList()
                                                      .Select(m => new Tmp_movto_proveeduria(

                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Partida,
                                                          m.Productoid,
                                                          m.ProductoClave,
                                                          m.ProductoNombre,
                                                          m.Cantidad,
                                                          m.Preciolista,
                                                          m.Descuentoporcentaje,
                                                          m.Descuento,
                                                          m.Precio,
                                                          m.Importe,
                                                          m.Subtotal,
                                                          m.Iva,
                                                          m.Ieps,
                                                          m.Tasaiva,
                                                          m.Tasaieps,
                                                          m.Total,
                                                          m.Lote,
                                                          m.Fechavence,
                                                          m.Loteimportado,
                                                          m.Doctoid,
                                                          m.Orden,
                                                          m.Descuentovale,
                                                          m.Descuentovaleporcentaje,
                                                          m.Ingresopreciomanual,
                                                          m.Porcentajedescuentomanual,
                                                          m.Descripcion1,
                                                          m.Descripcion2,
                                                          m.Descripcion3,
                                                          m.Cantidadsurtida,
                                                          m.Precio1,
                                                          m.Existencia,
                                                          m.Pzacaja,
                                                          m.Texto1,
                                                          m.Texto2,
                                                          m.Texto3,
                                                          m.Texto4,
                                                          m.Texto5,
                                                          m.Texto6,
                                                          m.Numero1,
                                                          m.Numero2,
                                                          m.Numero3,
                                                          m.Numero4,
                                                          m.Fecha1,
                                                          m.Fecha2,
                                                          m.Unidadid,
                                                          m.UnidadClave,
                                                          m.UnidadNombre,
                                                          "",
(parametro.Precionetoengrids == BoolCN.S ? m.Precio :
                                                                               (m.Precio +
                                                                                        decimal.Round(m.Precio * (m.Tasaieps / 100m), 2) +
                                                                                        decimal.Round((m.Precio + decimal.Round(m.Precio * (m.Tasaieps / 100m), 2)) * (m.Tasaiva / 100m), 2)
                                                                               )
                                                                             ),
(parametro.Precionetoengrids == BoolCN.S ? m.Descuento :
                                                                               (m.Descuento +
                                                                                        decimal.Round(m.Descuento * (m.Tasaieps / 100m), 2) +
                                                                                        decimal.Round((m.Descuento + decimal.Round(m.Descuento * (m.Tasaieps / 100m), 2)) * (m.Tasaiva / 100m), 2)
                                                                               )
                                                                             )


                                                      )).ToList();

                return lstMovtoProveeduria;


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }




        public List<Tmp_docto_proveeduria> Docto_proveeduria(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin, BoolCS corteActual,
                                                long? almacenId, BoolCS todosAlmacenes, BoolCS porFecha, BoolCS todosUsuarios,
                                                ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Listapreciominimo, p.Tipoutilidadid, p.Precionetoengrids })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("no hay parametro");


                var lstDoctoProveeduria = localContext.Docto.AsNoTracking()
                                                      .Include(d => d.Estatusdocto)
                                                      .Include(d => d.Usuario)
                                                      .Include(d => d.Docto_compra)
                                                      .Include(d => d.Caja)
                                                      .Include(d => d.Proveedor)
                                                      .Include(d => d.Tipodocto)
                                                      .Include(d => d.Docto_fact_elect)
                                                      .Include(d => d.Docto_traslado).ThenInclude(dt => dt!.Sucursalt)
                                                      .Include(d => d.Docto_traslado).ThenInclude(dt => dt!.Almacen)
                                                      .Include(d => d.Origenfiscal)
                                                      .Include(d => d.Corte)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                            (todosUsuarios == BoolCS.S ||  (usuarioId ?? 0) == 0 || d.Usuarioid == usuarioId) &&
                                                            (d.Tipodoctoid == tipoDoctoId) &&
                                                            (d.Estatusdoctoid == estatusDoctoId) &&
                                                            (porFecha != BoolCS.S || (d.Fecha >= fechaIni && d.Fecha <= fechaFin)) &&
                                                            (corteActual != BoolCS.S || d.Corte!.Activo == BoolCS.S) &&
                                                            (todosAlmacenes == BoolCS.S || (almacenId ?? 0) == 0 || d.Almacenid == almacenId)
                                                      )
                                                      .Select(d => new Tmp_docto_proveeduria(
                                                          d.EmpresaId,
                                                          d.SucursalId,
                                                          d.Id,
                                                          d.Activo,
                                                          d.Estatusdoctoid,
d.Estatusdocto == null ? null : d.Estatusdocto.Clave,
d.Estatusdocto == null ? null : d.Estatusdocto.Nombre,
                                                          d.Usuarioid,
d.Usuario == null ? null : d.Usuario.UsuarioNombre,
                                                          d.Fecha,
                                                          d.Serie,
                                                          d.Folio,
                                                          d.Importe,
                                                          d.Descuento,
                                                          d.Subtotal,
                                                          d.Iva,
                                                          d.Ieps,
                                                          d.Total,
                                                          d.Cajaid,
d.Caja == null ? null : d.Caja.Clave,
d.Caja == null ? null : d.Caja.Nombre,
                                                          d.Proveedorid,
d.Proveedor == null ? null : d.Proveedor.Clave,
d.Proveedor == null ? null : d.Proveedor.Nombre,
                                                          d.Tipodoctoid,
d.Tipodocto == null ? null : d.Tipodocto.Clave,
d.Tipodocto == null ? null : d.Tipodocto.Nombre,
                                                          d.Referencia,
d.Docto_fact_elect == null ? null : d.Docto_fact_elect.Foliosat,
d.Docto_fact_elect == null ? null : d.Docto_fact_elect.Seriesat,
d.Docto_traslado == null ? null : d.Docto_traslado.Sucursaltid,
d.Docto_traslado == null || d.Docto_traslado.Sucursalt == null ? null : d.Docto_traslado.Sucursalt.Clave,
d.Docto_traslado == null || d.Docto_traslado.Sucursalt == null ? null : d.Docto_traslado.Sucursalt.Nombre,
d.Docto_traslado == null ? null : d.Docto_traslado.Almacentid,
d.Docto_traslado == null || d.Docto_traslado.Almacen == null ? null : d.Docto_traslado.Almacen.Clave,
d.Docto_traslado == null || d.Docto_traslado.Almacen == null ? null : d.Docto_traslado.Almacen.Nombre,
d.Docto_traslado == null ? null : d.Almacenid,
d.Docto_traslado == null || d.Almacen == null ? null : d.Almacen.Clave,
d.Docto_traslado == null || d.Almacen == null ? null : d.Almacen.Nombre,
d.Docto_compra == null ? null : d.Docto_compra.Folio,
d.Docto_compra == null ? null : d.Docto_compra.Factura,
d.Docto_compra == null ? null : d.Docto_compra.Fechafactura,
d.Fechavence,
                                                          d.Origenfiscalid,
d.Origenfiscal == null ? null : d.Origenfiscal.Clave,
d.Origenfiscal == null ? null : d.Origenfiscal.Nombre

                                                      )).ToList();

                return lstDoctoProveeduria;


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }




        public List<Tmp_precioprod_ref_prov> Precioprod_ref_prov(long empresaId, long sucursalId,
                                                long productoId, long proveedorId, decimal cantidad,
                                                 ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var lstPreciosProveeduria = localContext.Producto.AsNoTracking()
                                                      .Include(p => p.Producto_precios)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                  d.Id == productoId
                                                      )
                                                      .Select(p => new Tmp_precioprod_ref_prov(
                                                          p.EmpresaId,
                                                          p.SucursalId,
p.Producto_precios != null ? p.Producto_precios.Costorepo : 0m,
p.Producto_precios != null ? p.Producto_precios.Costorepo : 0m,
p.Producto_precios != null ? p.Producto_precios.Costorepo : 0m,
p.Producto_precios != null ? p.Producto_precios.Costopromedio : 0m

                                                      )).ToList();

                return lstPreciosProveeduria;


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }






    }


    public class Tmp_movto_proveeduria
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public int Partida { get; }
        public long? Productoid { get; }
        public string? ProductoClave { get; }
        public string? ProductoNombre { get; }
        public decimal Cantidad { get; }
        public decimal Preciolista { get; }
        public decimal Descuentoporcentaje { get; }
        public decimal Descuento { get; }
        public decimal Precio { get; }
        public decimal Importe { get; }
        public decimal Subtotal { get; }
        public decimal Iva { get; }
        public decimal Ieps { get; }
        public decimal Tasaiva { get; }
        public decimal Tasaieps { get; }
        public decimal Total { get; }
        public string? Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Loteimportado { get; }
        public long? Doctoid { get; }
        public int Orden { get; }
        public decimal Descuentovale { get; }
        public decimal Descuentovaleporcentaje { get; }
        public BoolCN Ingresopreciomanual { get; }
        public decimal Porcentajedescuentomanual { get; }
        public string? Descripcion1 { get; }
        public string? Descripcion2 { get; }
        public string? Descripcion3 { get; }
        public decimal Cantidadsurtida { get; }
        public decimal Precio1 { get; }
        public decimal Existencia { get; }
        public decimal Pzacaja { get; }
        public string? Texto1 { get; }
        public string? Texto2 { get; }
        public string? Texto3 { get; }
        public string? Texto4 { get; }
        public string? Texto5 { get; }
        public string? Texto6 { get; }
        public decimal? Numero1 { get; }
        public decimal? Numero2 { get; }
        public decimal? Numero3 { get; }
        public decimal? Numero4 { get; }
        public DateTimeOffset? Fecha1 { get; }
        public DateTimeOffset? Fecha2 { get; }
        public long? Unidadid { get; }
        public string? UnidadClave { get; }
        public string? UnidadNombre { get; }
        public string Alerta3 { get; }
        public decimal Preciomostrar { get; }
        public decimal Descuentomostrar { get; }

        public Tmp_movto_proveeduria(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Partida = partida;
            Productoid = productoid;
            ProductoClave = productoClave;
            ProductoNombre = productoNombre;
            Cantidad = cantidad;
            Preciolista = preciolista;
            Descuentoporcentaje = descuentoporcentaje;
            Descuento = descuento;
            Precio = precio;
            Importe = importe;
            Subtotal = subtotal;
            Iva = iva;
            Ieps = ieps;
            Tasaiva = tasaiva;
            Tasaieps = tasaieps;
            Total = total;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
            Doctoid = doctoid;
            Orden = orden;
            Descuentovale = descuentovale;
            Descuentovaleporcentaje = descuentovaleporcentaje;
            Ingresopreciomanual = ingresopreciomanual;
            Porcentajedescuentomanual = porcentajedescuentomanual;
            Descripcion1 = descripcion1;
            Descripcion2 = descripcion2;
            Descripcion3 = descripcion3;
            Cantidadsurtida = cantidadsurtida;
            Precio1 = precio1;
            Existencia = existencia;
            Pzacaja = pzacaja;
            Texto1 = texto1;
            Texto2 = texto2;
            Texto3 = texto3;
            Texto4 = texto4;
            Texto5 = texto5;
            Texto6 = texto6;
            Numero1 = numero1;
            Numero2 = numero2;
            Numero3 = numero3;
            Numero4 = numero4;
            Fecha1 = fecha1;
            Fecha2 = fecha2;
            Unidadid = unidadid;
            UnidadClave = unidadClave;
            UnidadNombre = unidadNombre;
            Alerta3 = alerta3;
            Preciomostrar = preciomostrar;
            Descuentomostrar = descuentomostrar;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_movto_proveeduria other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Partida == other.Partida &&
                   Productoid == other.Productoid &&
                   ProductoClave == other.ProductoClave &&
                   ProductoNombre == other.ProductoNombre &&
                   Cantidad == other.Cantidad &&
                   Preciolista == other.Preciolista &&
                   Descuentoporcentaje == other.Descuentoporcentaje &&
                   Descuento == other.Descuento &&
                   Precio == other.Precio &&
                   Importe == other.Importe &&
                   Subtotal == other.Subtotal &&
                   Iva == other.Iva &&
                   Ieps == other.Ieps &&
                   Tasaiva == other.Tasaiva &&
                   Tasaieps == other.Tasaieps &&
                   Total == other.Total &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado &&
                   Doctoid == other.Doctoid &&
                   Orden == other.Orden &&
                   Descuentovale == other.Descuentovale &&
                   Descuentovaleporcentaje == other.Descuentovaleporcentaje &&
                   Ingresopreciomanual == other.Ingresopreciomanual &&
                   Porcentajedescuentomanual == other.Porcentajedescuentomanual &&
                   Descripcion1 == other.Descripcion1 &&
                   Descripcion2 == other.Descripcion2 &&
                   Descripcion3 == other.Descripcion3 &&
                   Cantidadsurtida == other.Cantidadsurtida &&
                   Precio1 == other.Precio1 &&
                   Existencia == other.Existencia &&
                   Pzacaja == other.Pzacaja &&
                   Texto1 == other.Texto1 &&
                   Texto2 == other.Texto2 &&
                   Texto3 == other.Texto3 &&
                   Texto4 == other.Texto4 &&
                   Texto5 == other.Texto5 &&
                   Texto6 == other.Texto6 &&
                   Numero1 == other.Numero1 &&
                   Numero2 == other.Numero2 &&
                   Numero3 == other.Numero3 &&
                   Numero4 == other.Numero4 &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
                   Unidadid == other.Unidadid &&
                   UnidadClave == other.UnidadClave &&
                   UnidadNombre == other.UnidadNombre &&
                   Alerta3 == other.Alerta3 &&
                   Preciomostrar == other.Preciomostrar &&
                   Descuentomostrar == other.Descuentomostrar;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Partida);
            hash.Add(Productoid);
            hash.Add(ProductoClave);
            hash.Add(ProductoNombre);
            hash.Add(Cantidad);
            hash.Add(Preciolista);
            hash.Add(Descuentoporcentaje);
            hash.Add(Descuento);
            hash.Add(Precio);
            hash.Add(Importe);
            hash.Add(Subtotal);
            hash.Add(Iva);
            hash.Add(Ieps);
            hash.Add(Tasaiva);
            hash.Add(Tasaieps);
            hash.Add(Total);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            hash.Add(Doctoid);
            hash.Add(Orden);
            hash.Add(Descuentovale);
            hash.Add(Descuentovaleporcentaje);
            hash.Add(Ingresopreciomanual);
            hash.Add(Porcentajedescuentomanual);
            hash.Add(Descripcion1);
            hash.Add(Descripcion2);
            hash.Add(Descripcion3);
            hash.Add(Cantidadsurtida);
            hash.Add(Precio1);
            hash.Add(Existencia);
            hash.Add(Pzacaja);
            hash.Add(Texto1);
            hash.Add(Texto2);
            hash.Add(Texto3);
            hash.Add(Texto4);
            hash.Add(Texto5);
            hash.Add(Texto6);
            hash.Add(Numero1);
            hash.Add(Numero2);
            hash.Add(Numero3);
            hash.Add(Numero4);
            hash.Add(Fecha1);
            hash.Add(Fecha2);
            hash.Add(Unidadid);
            hash.Add(UnidadClave);
            hash.Add(UnidadNombre);
            hash.Add(Alerta3);
            hash.Add(Preciomostrar);
            hash.Add(Descuentomostrar);
            return hash.ToHashCode();
        }
    }

    public class Tmp_docto_proveeduria
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public BoolCS Activo { get; }
        public long? Estatusdoctoid { get; }
        public string? Estatusdoctoclave { get; }
        public string? Estatusdoctonombre { get; }
        public long? Usuarioid { get; }
        public string? Usuarionombre { get; }
        public DateTimeOffset? Fecha { get; }
        public string? Serie { get; }
        public int? Folio { get; }
        public decimal Importe { get; }
        public decimal Descuento { get; }
        public decimal Subtotal { get; }
        public decimal Iva { get; }
        public decimal Ieps { get; }
        public decimal Total { get; }
        public long? Cajaid { get; }
        public string? Cajaclave { get; }
        public string? Cajanombre { get; }
        public long? Proveedorid { get; }
        public string? Proveedorclave { get; }
        public string? Proveedornombre { get; }
        public long? Tipodoctoid { get; }
        public string? Tipodoctoclave { get; }
        public string? Tipodoctonombre { get; }
        public string? Referencia { get; }
        public int? Foliosat { get; }
        public string? Seriesat { get; }
        public long? Sucursaltid { get; }
        public string? Sucursaltclave { get; }
        public string? Sucursaltnombre { get; }
        public long? Almacentid { get; }
        public string? Almacentclave { get; }
        public string? Almacentnombre { get; }
        public long? Almacenid { get; }
        public string? Almacenclave { get; }
        public string? Almacennombre { get; }
        public string? Folio_c { get; }
        public string? Factura_c { get; }
        public DateTimeOffset? Fechafactura_c { get; }
        public DateTimeOffset? Fechavence_c { get; }
        public long? Origenfiscalid { get; }
        public string? Origenfiscalclave { get; }
        public string? Origenfiscalnombre { get; }

        public Tmp_docto_proveeduria(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, 
            long? almacentid, string? almacentclave, string? almacentnombre, long? almacenid, string? almacenclave, string? almacennombre, string? folio_c, string? factura_c, DateTimeOffset? fechafactura_c, DateTimeOffset? fechavence_c, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Activo = activo;
            Estatusdoctoid = estatusdoctoid;
            Estatusdoctoclave = estatusdoctoclave;
            Estatusdoctonombre = estatusdoctonombre;
            Usuarioid = usuarioid;
            Usuarionombre = usuarionombre;
            Fecha = fecha;
            Serie = serie;
            Folio = folio;
            Importe = importe;
            Descuento = descuento;
            Subtotal = subtotal;
            Iva = iva;
            Ieps = ieps;
            Total = total;
            Cajaid = cajaid;
            Cajaclave = cajaclave;
            Cajanombre = cajanombre;
            Proveedorid = proveedorid;
            Proveedorclave = proveedorclave;
            Proveedornombre = proveedornombre;
            Tipodoctoid = tipodoctoid;
            Tipodoctoclave = tipodoctoclave;
            Tipodoctonombre = tipodoctonombre;
            Referencia = referencia;
            Foliosat = foliosat;
            Seriesat = seriesat;
            Sucursaltid = sucursaltid;
            Sucursaltclave = sucursaltclave;
            Sucursaltnombre = sucursaltnombre;
            Almacentid = almacentid;
            Almacentclave = almacentclave;
            Almacentnombre = almacentnombre;
            Almacenid = almacenid;
            Almacenclave = almacenclave;
            Almacennombre = almacennombre;
            Folio_c = folio_c;
            Factura_c = factura_c;
            Fechafactura_c = fechafactura_c;
            Fechavence_c = fechavence_c;
            Origenfiscalid = origenfiscalid;
            Origenfiscalclave = origenfiscalclave;
            Origenfiscalnombre = origenfiscalnombre;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_docto_proveeduria other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Activo == other.Activo &&
                   Estatusdoctoid == other.Estatusdoctoid &&
                   Estatusdoctoclave == other.Estatusdoctoclave &&
                   Estatusdoctonombre == other.Estatusdoctonombre &&
                   Usuarioid == other.Usuarioid &&
                   Usuarionombre == other.Usuarionombre &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   Serie == other.Serie &&
                   Folio == other.Folio &&
                   Importe == other.Importe &&
                   Descuento == other.Descuento &&
                   Subtotal == other.Subtotal &&
                   Iva == other.Iva &&
                   Ieps == other.Ieps &&
                   Total == other.Total &&
                   Cajaid == other.Cajaid &&
                   Cajaclave == other.Cajaclave &&
                   Cajanombre == other.Cajanombre &&
                   Proveedorid == other.Proveedorid &&
                   Proveedorclave == other.Proveedorclave &&
                   Proveedornombre == other.Proveedornombre &&
                   Tipodoctoid == other.Tipodoctoid &&
                   Tipodoctoclave == other.Tipodoctoclave &&
                   Tipodoctonombre == other.Tipodoctonombre &&
                   Referencia == other.Referencia &&
                   Foliosat == other.Foliosat &&
                   Seriesat == other.Seriesat &&
                   Sucursaltid == other.Sucursaltid &&
                   Sucursaltclave == other.Sucursaltclave &&
                   Sucursaltnombre == other.Sucursaltnombre &&
                   Almacentid == other.Almacentid &&
                   Almacentclave == other.Almacentclave &&
                   Almacentnombre == other.Almacentnombre &&
                   Folio_c == other.Folio_c &&
                   Factura_c == other.Factura_c &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechafactura_c, other.Fechafactura_c) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence_c, other.Fechavence_c) &&
                   Origenfiscalid == other.Origenfiscalid &&
                   Origenfiscalclave == other.Origenfiscalclave &&
                   Origenfiscalnombre == other.Origenfiscalnombre;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Activo);
            hash.Add(Estatusdoctoid);
            hash.Add(Estatusdoctoclave);
            hash.Add(Estatusdoctonombre);
            hash.Add(Usuarioid);
            hash.Add(Usuarionombre);
            hash.Add(Fecha);
            hash.Add(Serie);
            hash.Add(Folio);
            hash.Add(Importe);
            hash.Add(Descuento);
            hash.Add(Subtotal);
            hash.Add(Iva);
            hash.Add(Ieps);
            hash.Add(Total);
            hash.Add(Cajaid);
            hash.Add(Cajaclave);
            hash.Add(Cajanombre);
            hash.Add(Proveedorid);
            hash.Add(Proveedorclave);
            hash.Add(Proveedornombre);
            hash.Add(Tipodoctoid);
            hash.Add(Tipodoctoclave);
            hash.Add(Tipodoctonombre);
            hash.Add(Referencia);
            hash.Add(Foliosat);
            hash.Add(Seriesat);
            hash.Add(Sucursaltid);
            hash.Add(Sucursaltclave);
            hash.Add(Sucursaltnombre);
            hash.Add(Almacentid);
            hash.Add(Almacentclave);
            hash.Add(Almacentnombre);
            hash.Add(Folio_c);
            hash.Add(Factura_c);
            hash.Add(Fechafactura_c);
            hash.Add(Fechavence_c);
            hash.Add(Origenfiscalid);
            hash.Add(Origenfiscalclave);
            hash.Add(Origenfiscalnombre);
            return hash.ToHashCode();
        }
    }



    public class Tmp_precioprod_ref_prov
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public decimal PrecioLista { get; }
        public decimal PrecioTraspaso { get; }
        public decimal PrecioMinimo { get; }
        public decimal Costo { get; }

        public Tmp_precioprod_ref_prov(long empresaId, long sucursalId, decimal precioLista, decimal precioTraspaso, decimal precioMinimo, decimal costo)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            PrecioLista = precioLista;
            PrecioTraspaso = precioTraspaso;
            PrecioMinimo = precioMinimo;
            Costo = costo;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_precioprod_ref_prov other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   PrecioLista == other.PrecioLista &&
                   PrecioTraspaso == other.PrecioTraspaso &&
                   PrecioMinimo == other.PrecioMinimo &&
                   Costo == other.Costo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmpresaId, SucursalId, PrecioLista, PrecioTraspaso, PrecioMinimo, Costo);
        }
    }
}
