using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class ProvDevoService
    {

        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private DoctoMovtoService _doctoMovtoService;
        private PagoService _pagoService;
        public ProvDevoService(
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




        public void Docto_provdevo_insert(DoctoProvDevoTrans doctoProvDevoTrans, ref long? doctoId, 
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoTrans = new DoctoTransaction()
                {
                    Empresaid = doctoProvDevoTrans.Empresaid,
                    Sucursalid = doctoProvDevoTrans.Sucursalid,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = doctoProvDevoTrans.Creadopor_userid,
                    Estatusdoctoid = doctoProvDevoTrans.Estatusdoctoid,
                    Usuarioid = doctoProvDevoTrans.Usuarioid,
                    Corteid = null,
                    Fecha = doctoProvDevoTrans.Fecha,
                    Fechahora = DateTimeOffset.Now,
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
                    Cajaid = doctoProvDevoTrans.Cajaid,
                    Almacenid = doctoProvDevoTrans.Almacenid,
                    Origenfiscalid = doctoProvDevoTrans.Origenfiscalid,
                    Esapartado = BoolCN.N,
                    Doctoparentid = doctoProvDevoTrans.Doctoparentid,
                    Clienteid = null,
                    Tipodoctoid = doctoProvDevoTrans.Tipodoctoid,
                    Proveedorid = doctoProvDevoTrans.Proveedorid,
                    Sucursal_id = doctoProvDevoTrans.Sucursal_id,
                    Referencia = doctoProvDevoTrans.Referencia,
                    Referencias = doctoProvDevoTrans.Referencias,
                    Fechavence = doctoProvDevoTrans.Fechavence_c

                };

                _doctoService.DoctoInsert(doctoTrans, ref doctoId, localContext);


                if ((doctoId ?? 0) == 0)
                    throw new Exception("No se pudo insertar el documento");


                if ((doctoProvDevoTrans.Doctoadevolverid ?? 0) != 0 && doctoProvDevoTrans.Tipodoctoid == 12)
                {
                    var docto_devolucion = new Docto_devolucion()
                    {

                        Modificado = DateTimeOffset.UtcNow,
                        ModificadoPorId = doctoProvDevoTrans.Usuarioid,
                        EmpresaId = doctoProvDevoTrans.Empresaid,
                        SucursalId = doctoProvDevoTrans.Sucursalid,
                        Activo = doctoTrans.Activo,
                        Creado = DateTimeOffset.UtcNow,
                        CreadoPorId = doctoProvDevoTrans.Usuarioid,
                        Doctoid = doctoId,
                        Doctorefid = doctoProvDevoTrans.Doctoadevolverid
                    };
                    localContext.Add(docto_devolucion);
                }


                var docto_traslado = new Docto_traslado()
                {
                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = doctoProvDevoTrans.Usuarioid,
                    EmpresaId = doctoProvDevoTrans.Empresaid,
                    SucursalId = doctoProvDevoTrans.Sucursalid,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = doctoProvDevoTrans.Usuarioid,
                    Sucursaltid = doctoProvDevoTrans.Sucursaltid,
                    Almacentid = doctoProvDevoTrans.Almacentid,
                    Doctoid = doctoId

                };
                localContext.Add(docto_traslado);


                var docto_compra = new Docto_compra()
                {

                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = doctoProvDevoTrans.Usuarioid,
                    EmpresaId = doctoProvDevoTrans.Empresaid,
                    SucursalId = doctoProvDevoTrans.Sucursalid,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = doctoProvDevoTrans.Usuarioid,
                    Doctoid = doctoId,
                    Folio = doctoProvDevoTrans.Folio_c,
                    Factura = doctoProvDevoTrans.Factura_c,
                    Fechafactura = doctoProvDevoTrans.Fechafactura_c
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



        public void Docto_provdevo_update_estatus(long empresaId, long sucursalId, long id, long estatusDoctoId,
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
                foreach (var movtoInfo in movtoInfo_list)
                {
                    Movto_provdevo_update_status(empresaId, sucursalId, movtoInfo.Id, estatusDoctoId, localContext);
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



        public void Docto_provdevo_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                Docto_provdevo_update_estatus(empresaId, sucursalId, id, estatusDoctoId, localContext);

                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Include(d => d.Docto_traslado)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id && d.Docto_traslado != null)
                                            .Select(d => new { Sucursaltid = (d.Docto_traslado != null ? d.Docto_traslado.Sucursaltid : null), d.Folio, d.Sucursal_id })
                                            .FirstOrDefault();

                if (doctoInfo != null && (doctoInfo.Sucursaltid ?? 0) > 0 && (doctoInfo.Sucursaltid ?? 0) != (doctoInfo.Sucursal_id ?? 0))
                {
                    var docto_traslado = localContext.Docto_traslado
                                                     .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == id)
                                                     .Update(x => new Docto_traslado()
                                                     {
                                                         Essurtimientomerca = "S",
                                                         Foliosolicitudmercancia = doctoInfo.Folio != null ? doctoInfo.Folio.ToString() : "",
                                                         Idsolicitudmercancia = id
                                                     });
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


        public void Docto_provdevo_and_payments_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            List<DoctoPagoDirect> listPagos,
            ApplicationDbContext? localContext)
        {
            if (localContext == null) throw new Exception("El contexto de la bd no puede ser nulo");

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


                Docto_provdevo_save(empresaId, sucursalId, id, estatusDoctoId, localContext);

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


        public void Docto_provdevo_delete(long empresaId, long sucursalId, long id,
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

        public void Docto_provdevo_cancel(long empresaId, long sucursalId,
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





        public void Movto_provdevo_group(long empresaId, long sucursalId, long doctoId,
                                            long productoId, decimal? descuentoPorcentaje, decimal? precio,
                                            string? lote, DateTimeOffset? fechaVence, long? loteImportado,
                                            //long? movtoParentid, string? localidad, long? anaquelId, 
                                            decimal? precioConImp, long? movtoadevolverid,
                                            out long? movtoActualId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            movtoActualId = null;

            try
            {

                var bufferMovtoActualId = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_devolucion)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                  m.Doctoid == doctoId && m.Productoid == productoId &&
                                                                  (m.Lote ?? "") == (lote ?? "") &&
                                                                  ((m.Fechavence == null && fechaVence == null) || m.Fechavence == fechaVence) &&
                                                                  (m.Loteimportado ?? 0) == (loteImportado ?? 0) &&
                                                                  (
                                                                    (m.Movto_precio == null || (m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.N && (precio == null || (m.Precio == (precio ?? 0m)))) ||
                                                                    (m.Movto_precio != null && (m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.S && (precioConImp == null || (m.Movto_precio.Precioconimp == (precioConImp ?? 0m))))
                                                                  ) &&
                                                                  (descuentoPorcentaje == null || (m.Descuentoporcentaje == (descuentoPorcentaje ?? 0m))) &&
                                                                  (m.Movto_devolucion == null  ? 0 : (m.Movto_devolucion.Movtorefid ?? 0)) == (movtoadevolverid ?? 0)
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


        public void Movto_provdevo_insert(MovtoProvDevoTrans movtoProvDevoTrans, ref long? movtoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? movtoexistenteid = null;

            //long?
            movtoId = null;

            var calc_imp_de_total = BoolCN.N;

            decimal? precio = movtoProvDevoTrans.Precio;
            decimal? precioconimp = movtoProvDevoTrans.Precioconimp;
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
                                                .Where(p => p.EmpresaId == movtoProvDevoTrans.Empresaid && p.SucursalId == movtoProvDevoTrans.Sucursalid && p.Id == movtoProvDevoTrans.Productoid)
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


                if ((movtoProvDevoTrans.Id ?? 0) != 0)
                {
                    movtoexistenteid = movtoProvDevoTrans.Id;
                }
                else
                {


                    this.Movto_provdevo_group(movtoProvDevoTrans.Empresaid, movtoProvDevoTrans.Sucursalid, movtoProvDevoTrans.Doctoid,
                                                 movtoProvDevoTrans.Productoid, movtoProvDevoTrans.Descuentoporcentaje, movtoProvDevoTrans.Precio,
                                                 movtoProvDevoTrans.Lote, movtoProvDevoTrans.Fechavence, movtoProvDevoTrans.Loteimportado,
                                                 //movtoProvDevoTrans.Movtoparentid,movtoProvDevoTrans.Localidad, movtoProvDevoTrans.Anaquelid, 
                                                 movtoProvDevoTrans.Precioconimp, movtoProvDevoTrans.Movtoadevolverid, 
                                                 out movtoexistenteid, localContext);


                }

                if ((movtoexistenteid ?? 0) == 0)
                {


                    if ((movtoProvDevoTrans.Precioconimp ?? 0) != 0)
                    {



                        calc_imp_de_total = BoolCN.S;


                        precio = movtoProvDevoTrans.Precio;
                        precioconimp = movtoProvDevoTrans.Precioconimp;
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

                        _movtoService.CalcularImpuestosTotalesMovto(movtoProvDevoTrans.Empresaid, movtoProvDevoTrans.Sucursalid,
                                                    movtoProvDevoTrans.Productoid, movtoProvDevoTrans.Cantidad, producto_info!.Preciolista,
                                                    producto_info.Ivaimpuesto, producto_info.Iepsimpuesto,
                                                    producto_info.Eskit, producto_info.Kitimpfijo, calc_imp_de_total, movtoProvDevoTrans.Movtoparentid,
                                                    null, ref precio, ref precioconimp, ref total, out importe, out subtotal,
                                                    out iva, out ieps, out impuesto, out descuento, out ivaRetenido, out isrRetenido, out tasaIvaRetenido, out tasaIsrRetenido,
                                                    out movto_kit_def_arr, localContext);





                    }


                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoProvDevoTrans.Empresaid,
                        Sucursalid = movtoProvDevoTrans.Sucursalid,
                        Id = 0,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = movtoProvDevoTrans.Usuarioid,
                        Partida = movtoProvDevoTrans.Partida,
                        Estatusmovtoid = movtoProvDevoTrans.Estatusmovtoid,
                        Fecha = DateTimeOffset.Now.Date,
                        Fechahora = DateTimeOffset.Now,
                        Productoid = movtoProvDevoTrans.Productoid,
                        Cantidad = movtoProvDevoTrans.Cantidad,
                        Preciolista = producto_info!.Preciolista,
                        Descuentoporcentaje = movtoProvDevoTrans.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = producto_info!.Ivaimpuesto,
                        Tasaieps = producto_info!.Iepsimpuesto,
                        Total = total,
                        Lote = movtoProvDevoTrans.Lote,
                        Fechavence = movtoProvDevoTrans.Fechavence,
                        Loteimportado = movtoProvDevoTrans.Loteimportado,
                        Movtoparentid = (movtoProvDevoTrans.Movtoadevolverid ?? movtoProvDevoTrans.Movtoparentid),
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = producto_info!.Eskit,
                        Kitimpfijo = producto_info!.Kitimpfijo,
                        Doctoid = movtoProvDevoTrans.Doctoid,
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
                        Localidad = movtoProvDevoTrans.Localidad,
                        Descripcion1 = movtoProvDevoTrans.Descripcion1,
                        Descripcion2 = movtoProvDevoTrans.Descripcion2,
                        Descripcion3 = movtoProvDevoTrans.Descripcion3,
                        Agrupaporparametro = movtoProvDevoTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = movtoProvDevoTrans.Cargartarjetapreciomanual,
                        Precioyavalidado = movtoProvDevoTrans.Precioyavalidado,
                        Usuarioid = movtoProvDevoTrans.Usuarioid,
                        Precioconimp = movtoProvDevoTrans.Precioconimp,
                        Anaquelid = movtoProvDevoTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoInsert(movtoTransaction, ref movtoId, localContext);


                    if ((movtoProvDevoTrans.Movtoadevolverid ?? 0) != 0)
                    {
                        var movto_devolucion = new Movto_devolucion()
                        {

                            EmpresaId = movtoProvDevoTrans.Empresaid,
                            SucursalId = movtoProvDevoTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoProvDevoTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoProvDevoTrans.Usuarioid,
                            Movtoid = movtoId,
                            Movtorefid = movtoProvDevoTrans.Movtoadevolverid,
                            Cantidadsurtida = 0m,
                            Cantidadfaltante = 0m,
                            Cantidaddevuelta = 0m,
                            Cantidadsaldo = 0m,
                            Razondiferenciaid = null,
                            Otrarazondiferencia = null

                        };
                        localContext.Add(movto_devolucion);
                    }


                    var movto_precio = new Movto_precio()
                    {

                        EmpresaId = movtoProvDevoTrans.Empresaid,
                        SucursalId = movtoProvDevoTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = movtoProvDevoTrans.Usuarioid,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = movtoProvDevoTrans.Usuarioid,
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



                    if ((movtoProvDevoTrans.Anaquelid ?? 0) != 0 || (movtoProvDevoTrans.Localidad ?? "") != "")
                    {

                        var movto_inventario = new Movto_inventario()
                        {

                            EmpresaId = movtoProvDevoTrans.Empresaid,
                            SucursalId = movtoProvDevoTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoProvDevoTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoProvDevoTrans.Usuarioid,
                            Tipodiferenciainventarioid = null,
                            Localidad = movtoProvDevoTrans.Localidad,
                            Anaquelid = movtoProvDevoTrans.Anaquelid,
                            Registroprocesosalida = BoolCN.N,
                            Movtoid = movtoId,
                            Cantidad_real = 0m,
                            Cantidad_teorica = 0m,
                            Cantidad_diferencia = 0m
                        };

                        localContext.Add(movto_inventario);

                    }

                    localContext.SaveChanges();

                }
                else
                {
                    var movto_a_cambiar = localContext.Movto.AsNoTracking()
                                                      .Where(m => m.EmpresaId == movtoProvDevoTrans.Empresaid && m.SucursalId == movtoProvDevoTrans.Sucursalid &&
                                                                  m.Id == movtoexistenteid)
                                                      .Select(m => new
                                                      {
                                                          Precio = (movtoProvDevoTrans.Precio ?? m.Precio),
                                                          Descuentoporcentaje = (movtoProvDevoTrans.Descuentoporcentaje ?? m.Descuentoporcentaje),
                                                          Preciolista = m.Preciolista,
                                                          Lote = m.Lote,
                                                          Fechavence = m.Fechavence,
                                                          Loteimportado = m.Loteimportado,
                                                          Partida = m.Partida,
                                                          Movtoparentid = m.Movtoparentid,
                                                          Cantidad = m.Cantidad + movtoProvDevoTrans.Cantidad,
                                                          TasaIvaRetenido = m.Tasaivaretenido,
                                                          TasaIsrRetenido = m.Tasaisrretenido


                                                      })
                                                      .FirstOrDefault();

                    if (movto_a_cambiar == null)
                        throw new Exception("El registro se borro inesperadamente");


                    //movtoProvDevoTrans.Precio = movto_existente.Precio;
                    //movtoProvDevoTrans.Descuentoporcentaje = movto_existente.Descuentoporcentaje;
                    //movtoProvDevoTrans.Lote = movto_existente.Lote;
                    //movtoProvDevoTrans.Fechavence = movto_existente.Fechavence;
                    //movtoProvDevoTrans.Loteimportado = movto_existente.Loteimportado;
                    //movtoProvDevoTrans.Partida = movto_existente.Partida;
                    //movtoProvDevoTrans.Movtoparentid = movto_existente.Movtoparentid;
                    //movtoProvDevoTrans.Cantidad = movto_existente.Cantidad;


                    if (movto_a_cambiar.Cantidad <= 0)
                    {
                        throw new Exception("La cantidad no puede ser cero");
                    }

                    if ((movtoProvDevoTrans.Precioconimp ?? 0) != 0)
                    {



                        calc_imp_de_total = BoolCN.S;


                        precio = movto_a_cambiar.Precio;
                        precioconimp = movtoProvDevoTrans.Precioconimp;
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

                        _movtoService.CalcularImpuestosTotalesMovto(movtoProvDevoTrans.Empresaid, movtoProvDevoTrans.Sucursalid,
                                                    movtoProvDevoTrans.Productoid, movto_a_cambiar.Cantidad, movto_a_cambiar!.Preciolista,
                                                    producto_info!.Ivaimpuesto, producto_info!.Iepsimpuesto,
                                                    producto_info!.Eskit, producto_info!.Kitimpfijo, calc_imp_de_total, movtoProvDevoTrans.Movtoparentid,
                                                    null, ref precio, ref precioconimp, ref total, out importe, out subtotal,
                                                    out iva, out ieps, out impuesto, out descuento, out ivaRetenido, out isrRetenido, out tasaIvaRetenido, out tasaIsrRetenido,
                                                    out movto_kit_def_arr, localContext);





                    }



                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoProvDevoTrans.Empresaid,
                        Sucursalid = movtoProvDevoTrans.Sucursalid,
                        Id = movtoexistenteid!.Value,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = movtoProvDevoTrans.Usuarioid,
                        Partida = movto_a_cambiar.Partida,
                        Estatusmovtoid = movtoProvDevoTrans.Estatusmovtoid,
                        Fecha = DateTimeOffset.Now.Date,
                        Fechahora = DateTimeOffset.Now,
                        Productoid = movtoProvDevoTrans.Productoid,
                        Cantidad = movto_a_cambiar.Cantidad,
                        Preciolista = movto_a_cambiar.Preciolista,
                        Descuentoporcentaje = movtoProvDevoTrans.Descuentoporcentaje,
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
                        Doctoid = movtoProvDevoTrans.Doctoid,
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
                        Localidad = movtoProvDevoTrans.Localidad,
                        Descripcion1 = movtoProvDevoTrans.Descripcion1,
                        Descripcion2 = movtoProvDevoTrans.Descripcion2,
                        Descripcion3 = movtoProvDevoTrans.Descripcion3,
                        Agrupaporparametro = movtoProvDevoTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = movtoProvDevoTrans.Cargartarjetapreciomanual,
                        Precioyavalidado = movtoProvDevoTrans.Precioyavalidado,
                        Usuarioid = movtoProvDevoTrans.Usuarioid,
                        Precioconimp = movtoProvDevoTrans.Precioconimp,
                        Anaquelid = movtoProvDevoTrans.Anaquelid,
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


        public void Movto_provdevo_update_status(long empresaId, long sucursalId, long id, long estatusMovtoId,
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

        public void Movto_provdevo_delete(long empresaId, long sucursalId, long id,
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

                if (movtoInfo.Estatusmovtoid != 0)
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




        public List<Tmp_movto_provdevo> Movto_provdevo(long empresaId, long sucursalId, long doctoId, ApplicationDbContext? localContext)
        {

            if (localContext == null)
                throw new Exception("El localcontext no puede ser nulo");

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
                                                      .Include(m => m.Movto_devolucion).ThenInclude(m => m!.Movtoref)
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
                                                          Descripcion1 = m.Producto == null ? null : m.Producto.Descripcion1,
                                                          Descripcion2 = m.Producto == null ? null : m.Producto.Descripcion2,
                                                          Descripcion3 = m.Producto == null ? null : m.Producto.Descripcion3,
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
                                                          Precio6 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio6,


                                                          Devolucionmovtorefid = m.Movto_devolucion == null ? null : m.Movto_devolucion.Movtorefid ,
                                                          Devolucionmovtorefcantidad = m.Movto_devolucion == null || m.Movto_devolucion.Movtoref == null ? null : (decimal?)m.Movto_devolucion.Movtoref.Cantidad,
                                                          Devolucionmovtorefprecio = m.Movto_devolucion == null || m.Movto_devolucion.Movtoref == null ? null : (decimal?)m.Movto_devolucion.Movtoref.Precio



                                                      }).ToList()
                                                      .Select(m => new Tmp_movto_provdevo(

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
(m.Precio > m.Precio1 && m.Precio1 > m.Preciolista) ?
                                                                    "PRECIO MAYOR A PRECIO1 Y PRECIO LISTA" :
                                                                    (m.Precio < (parametro.Tipoutilidadid == 2 ? (m.Costopromedio != 0 ? m.Costopromedio : m.Costorepo) :
                                                                                  (parametro.Tipoutilidadid == 3 ? (m.Costoultimo != 0 ? m.Costoultimo : m.Costorepo) : m.Costorepo)) ?
                                                                                  "PRECIO MENOR AL COSTO" :

                                                                                  (
                                                                                    m.Precio < (parametro.Listapreciominimo == 1 ? m.Precio1 :
                                                                                                (parametro.Listapreciominimo == 2 ? m.Precio2 :
                                                                                                  (parametro.Listapreciominimo == 3 ? m.Precio3 :
                                                                                                   (parametro.Listapreciominimo == 4 ? m.Precio3 :
                                                                                                    (parametro.Listapreciominimo == 5 ? m.Precio3 :
                                                                                                     (parametro.Listapreciominimo == 6 ? m.Precio6 : m.Precio1
                                                                                                     )))))) ?
                                                                                            "PRECIO MENOR A PRECIO MINIMO" : ""
                                                                                  )
                                                                    ),
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
                                                                             ),


                                                          m.Devolucionmovtorefid,
                                                          m.Devolucionmovtorefcantidad,
                                                          m.Devolucionmovtorefprecio


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





        public List<Tmp_movto_prov_to_devo> Movto_prov_to_devo(long empresaId, long sucursalId, long? doctoId, long? doctoRefId, ApplicationDbContext localContext)
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

                //var doctoRefId = localContext.Docto.AsNoTracking()
                //                             .Include(y => y.Docto_devolucion)
                //                             .Where(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Id == doctoId &&
                //                                         y.Docto_devolucion != null)
                //                             .Select(y => y.Docto_devolucion.Doctorefid)
                //                             .FirstOrDefault();

                //if(doctoRefId == null)
                //    throw new Exception("no hay docto de devolucion");



                var lstMovtoCompraOriginal = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_devolucion).ThenInclude(m => m!.Movtoref)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Productocaracteristicas)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_existencia)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Unidad)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoRefId!.Value)
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
                                                          Descripcion1 = m.Producto == null ? null : m.Producto.Descripcion1,
                                                          Descripcion2 = m.Producto == null ? null : m.Producto.Descripcion2,
                                                          Descripcion3 = m.Producto == null ? null : m.Producto.Descripcion3,
                                                          Cantidadsurtida = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidadsurtida,
                                                          Cantidaddevuelta = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidaddevuelta,
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
                                                          Precio6 = m.Producto == null || m.Producto.Producto_precios == null ? 0m : m.Producto.Producto_precios.Precio6//,


                                                          //Devolucionmovtorefid = m.Movto_devolucion == null ? null : m.Movto_devolucion.Movtorefid,
                                                          //Devolucionmovtorefcantidad = m.Movto_devolucion == null || m.Movto_devolucion.Movtoref == null ? null : (decimal?)m.Movto_devolucion.Movtoref.Cantidad,
                                                          //Devolucionmovtorefprecio = m.Movto_devolucion == null || m.Movto_devolucion.Movtoref == null ? null : (decimal?)m.Movto_devolucion.Movtoref.Precio



                                                      }).ToList()
                                                      .Select(m => new
                                                      {

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
                                                          m.Cantidaddevuelta,
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

                                                          Preciomostrar = (parametro.Precionetoengrids == BoolCN.S ? m.Precio :
                                                                               (m.Precio +
                                                                                        decimal.Round(m.Precio * (m.Tasaieps / 100m), 2) +
                                                                                        decimal.Round((m.Precio + decimal.Round(m.Precio * (m.Tasaieps / 100m), 2)) * (m.Tasaiva / 100m), 2)
                                                                               )
                                                                             ),
                                                          Descuentomostrar = (parametro.Precionetoengrids == BoolCN.S ? m.Descuento :
                                                                               (m.Descuento +
                                                                                        decimal.Round(m.Descuento * (m.Tasaieps / 100m), 2) +
                                                                                        decimal.Round((m.Descuento + decimal.Round(m.Descuento * (m.Tasaieps / 100m), 2)) * (m.Tasaiva / 100m), 2)
                                                                               )
                                                                             )//,


                                                          //m.Devolucionmovtorefid,
                                                          //m.Devolucionmovtorefcantidad,
                                                          //m.Devolucionmovtorefprecio


                                                      });

                var listMovtoDevolucion = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_devolucion).ThenInclude(m => m!.Movtoref)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId && m.Movto_devolucion != null)
                                                      .GroupBy(y => new
                                                      {
                                                          y.EmpresaId,
                                                          y.SucursalId,
                                                          y.Productoid,
                                                          y.Estatusmovtoid,
                                                          Movtorefid = y.Movto_devolucion!.Movtorefid
                                                      })
                                                      .Select(g => new
                                                      {
                                                          g.Key.EmpresaId,
                                                          g.Key.SucursalId,
                                                          g.Key.Estatusmovtoid,
                                                          g.Key.Productoid,
                                                          g.Key.Movtorefid,
                                                          MovtoId = g.Min(d => d.Id),
                                                          Cantidad = g.Sum(d => d.Cantidad),
                                                          Subtotal = g.Sum(d => d.Subtotal),
                                                          Precio = g.Sum(d => d.Cantidad ) > 0 ? g.Sum(d => d.Subtotal) / g.Sum(d => d.Cantidad) : 0,
                                                          Importe = g.Sum(d => d.Importe),
                                                          Partida = g.Min( d => d.Partida)

                                                      }).ToList();

                var lstMovtoProv = (from movtoCompra in lstMovtoCompraOriginal
                                    from movtoDevolucion in listMovtoDevolucion.Where(d => d.EmpresaId == movtoCompra.EmpresaId &&
                                                                                           d.SucursalId == movtoCompra.SucursalId &&
                                                                                           d.Movtorefid == movtoCompra.Id).DefaultIfEmpty()
                                    select new Tmp_movto_prov_to_devo(
doctoRefId,
movtoCompra.Id,
movtoCompra.Partida,
movtoCompra.Cantidad,
movtoCompra.Descripcion1,
movtoCompra.Precio,
movtoCompra.Total,
movtoCompra.Descuento,
movtoCompra.Descripcion2,
movtoCompra.Lote,
movtoCompra.ProductoClave,
movtoCompra.Subtotal,
movtoCompra.Iva,
movtoDevolucion?.Cantidad,
movtoDevolucion?.MovtoId,
movtoDevolucion?.Precio,
                                        movtoDevolucion?.Subtotal,
                                        movtoDevolucion?.Importe,
                                        movtoDevolucion?.Partida,
                                        movtoCompra.Cantidaddevuelta,
(movtoCompra.Cantidad - movtoCompra.Cantidaddevuelta - (movtoDevolucion?.Estatusmovtoid == 1 ? 0m : (movtoDevolucion?.Cantidad ?? 0m))),
(movtoCompra.Cantidad - movtoCompra.Cantidaddevuelta - (movtoDevolucion?.Cantidad ?? 0m)),
                                        movtoCompra.Tasaiva,
                                        movtoCompra.Tasaieps,
                                        movtoCompra.EmpresaId,
                                        movtoCompra.SucursalId,
                                        movtoCompra.Productoid,
                                        movtoCompra.Descripcion1,
                                        movtoCompra.Descripcion3,
                                        movtoCompra.Fechavence,
                                        movtoCompra.Loteimportado
                                    )).ToList();

                return lstMovtoProv;



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



        public List<Tmp_docto_provdevo> Docto_provdevo(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin, 
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
                                                      .Include(d => d.Docto_devolucion).ThenInclude(d => d!.Doctoref)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                            ((usuarioId ?? 0) == 0 || d.Usuarioid == usuarioId) &&
                                                            (d.Tipodoctoid == tipoDoctoId) &&
                                                            (d.Estatusdoctoid == estatusDoctoId) &&
                                                            d.Fecha >= fechaIni && d.Fecha <= fechaFin
                                                      )
                                                      .Select(d => new Tmp_docto_provdevo(
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
d.Docto_compra == null ? null : d.Docto_compra.Folio,
d.Docto_compra == null ? null : d.Docto_compra.Factura,
d.Docto_compra == null ? null : d.Docto_compra.Fechafactura,
d.Fechavence,
                                                          d.Origenfiscalid,
d.Origenfiscal == null ? null : d.Origenfiscal.Clave,
d.Origenfiscal == null ? null : d.Origenfiscal.Nombre,
d.Docto_devolucion == null ? null : d.Docto_devolucion.Doctorefid,
d.Docto_devolucion == null || d.Docto_devolucion.Doctoref == null ? null : d.Docto_devolucion.Doctoref.Folio,
d.Docto_devolucion == null || d.Docto_devolucion.Doctoref == null ? null : d.Docto_devolucion.Doctoref.Fechahora


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





        public List<Tmp_Docto_prov_to_devo> Docto_prov_to_devo(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, long estatusDoctoId,
                                                DateTimeOffset fechaIni, DateTimeOffset fechaFin, 
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
                                                      .Include(d => d.Docto_devolucion).ThenInclude(d => d!.Doctoref)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                            ((usuarioId ?? 0) == 0 || d.Usuarioid == usuarioId) &&
                                                            (d.Tipodoctoid == tipoDoctoId) &&
                                                            (d.Estatusdoctoid == estatusDoctoId) &&
                                                            d.Fecha >= fechaIni && d.Fecha <= fechaFin
                                                      )
                                                      .Select(d => new Tmp_Docto_prov_to_devo(
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
d.Docto_compra == null ? null : d.Docto_compra.Folio,
d.Docto_compra == null ? null : d.Docto_compra.Factura,
d.Docto_compra == null ? null : d.Docto_compra.Fechafactura,
d.Fechavence,
                                                          d.Origenfiscalid,
d.Origenfiscal == null ? null : d.Origenfiscal.Clave,
d.Origenfiscal == null ? null : d.Origenfiscal.Nombre,
d.Docto_devolucion == null ? null : d.Docto_devolucion.Doctorefid,
d.Docto_devolucion == null || d.Docto_devolucion.Doctoref == null ? null : d.Docto_devolucion.Doctoref.Folio,
d.Docto_devolucion == null || d.Docto_devolucion.Doctoref == null ? null : d.Docto_devolucion.Doctoref.Fechahora


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




    }


    public class Tmp_movto_provdevo
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
        public long? Devolucionmovtorefid { get; }
        public decimal? Devolucionmovtorefcantidad { get; }
        public decimal? Devolucionmovtorefprecio { get; }

        public Tmp_movto_provdevo(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar, long? devolucionmovtorefid, decimal? devolucionmovtorefcantidad, decimal? devolucionmovtorefprecio)
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
            Devolucionmovtorefid = devolucionmovtorefid;
            Devolucionmovtorefcantidad = devolucionmovtorefcantidad;
            Devolucionmovtorefprecio = devolucionmovtorefprecio;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_movto_provdevo other &&
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
                   Descuentomostrar == other.Descuentomostrar &&
                   Devolucionmovtorefid == other.Devolucionmovtorefid &&
                   Devolucionmovtorefcantidad == other.Devolucionmovtorefcantidad &&
                   Devolucionmovtorefprecio == other.Devolucionmovtorefprecio;
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
            hash.Add(Devolucionmovtorefid);
            hash.Add(Devolucionmovtorefcantidad);
            hash.Add(Devolucionmovtorefprecio);
            return hash.ToHashCode();
        }
    }

    public class Tmp_movto_prov_to_devo
    {
        public long? DoctoRefId { get; }
        public long Movtorefid { get; }
        public int Partidaref { get; }
        public decimal Cantidadref { get; }
        public string Descripcion { get; }
        public decimal Preciounidadref { get; }
        public decimal Importeref { get; }
        public decimal Descuentoref { get; }
        public string Descripcion2 { get; }
        public string Lote { get; }
        public string Claveproducto { get; }
        public decimal Subtotalref { get; }
        public decimal Ivaref { get; }
        public decimal? Cantidad { get; }
        public long? Movtoid { get; }
        public decimal? Preciounidad { get; }
        public decimal? Subtotal { get; }
        public decimal? Importe { get; }
        public int? Partida { get; }
        public decimal Cantidaddevuelta { get; }
        public decimal Cantdisp { get; }
        public decimal Cantdispdespues { get; }
        public decimal Tasaiva { get; }
        public decimal Tasaieps { get; }
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long? Productoid { get; }
        public string Descripcion1 { get; }
        public string Descripcion3 { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Loteimportado { get; }

        public Tmp_movto_prov_to_devo(long? doctoRefId, long movtorefid, int partidaref, decimal cantidadref, string descripcion, decimal preciounidadref, decimal importeref, decimal descuentoref, string descripcion2, string lote, string claveproducto, decimal subtotalref, decimal ivaref, decimal? cantidad, long? movtoid, decimal? preciounidad, decimal? subtotal, decimal? importe, int? partida, decimal cantidaddevuelta, decimal cantdisp, decimal cantdispdespues, decimal tasaiva, decimal tasaieps, long empresaId, long sucursalId, long? productoid, string descripcion1, string descripcion3, DateTimeOffset? fechavence, long? loteimportado)
        {
            DoctoRefId = doctoRefId;
            Movtorefid = movtorefid;
            Partidaref = partidaref;
            Cantidadref = cantidadref;
            Descripcion = descripcion;
            Preciounidadref = preciounidadref;
            Importeref = importeref;
            Descuentoref = descuentoref;
            Descripcion2 = descripcion2;
            Lote = lote;
            Claveproducto = claveproducto;
            Subtotalref = subtotalref;
            Ivaref = ivaref;
            Cantidad = cantidad;
            Movtoid = movtoid;
            Preciounidad = preciounidad;
            Subtotal = subtotal;
            Importe = importe;
            Partida = partida;
            Cantidaddevuelta = cantidaddevuelta;
            Cantdisp = cantdisp;
            Cantdispdespues = cantdispdespues;
            Tasaiva = tasaiva;
            Tasaieps = tasaieps;
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Productoid = productoid;
            Descripcion1 = descripcion1;
            Descripcion3 = descripcion3;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_movto_prov_to_devo other &&
                   DoctoRefId == other.DoctoRefId &&
                   Movtorefid == other.Movtorefid &&
                   Partidaref == other.Partidaref &&
                   Cantidadref == other.Cantidadref &&
                   Descripcion == other.Descripcion &&
                   Preciounidadref == other.Preciounidadref &&
                   Importeref == other.Importeref &&
                   Descuentoref == other.Descuentoref &&
                   Descripcion2 == other.Descripcion2 &&
                   Lote == other.Lote &&
                   Claveproducto == other.Claveproducto &&
                   Subtotalref == other.Subtotalref &&
                   Ivaref == other.Ivaref &&
                   Cantidad == other.Cantidad &&
                   Movtoid == other.Movtoid &&
                   Preciounidad == other.Preciounidad &&
                   Subtotal == other.Subtotal &&
                   Importe == other.Importe &&
                   Partida == other.Partida &&
                   Cantidaddevuelta == other.Cantidaddevuelta &&
                   Cantdisp == other.Cantdisp &&
                   Cantdispdespues == other.Cantdispdespues &&
                   Tasaiva == other.Tasaiva &&
                   Tasaieps == other.Tasaieps &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Productoid == other.Productoid &&
                   Descripcion1 == other.Descripcion1 &&
                   Descripcion3 == other.Descripcion3 &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(DoctoRefId);
            hash.Add(Movtorefid);
            hash.Add(Partidaref);
            hash.Add(Cantidadref);
            hash.Add(Descripcion);
            hash.Add(Preciounidadref);
            hash.Add(Importeref);
            hash.Add(Descuentoref);
            hash.Add(Descripcion2);
            hash.Add(Lote);
            hash.Add(Claveproducto);
            hash.Add(Subtotalref);
            hash.Add(Ivaref);
            hash.Add(Cantidad);
            hash.Add(Movtoid);
            hash.Add(Preciounidad);
            hash.Add(Subtotal);
            hash.Add(Importe);
            hash.Add(Partida);
            hash.Add(Cantidaddevuelta);
            hash.Add(Cantdisp);
            hash.Add(Cantdispdespues);
            hash.Add(Tasaiva);
            hash.Add(Tasaieps);
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Productoid);
            hash.Add(Descripcion1);
            hash.Add(Descripcion3);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            return hash.ToHashCode();
        }
    }

    public class Tmp_docto_provdevo
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
        public string? Folio_c { get; }
        public string? Factura_c { get; }
        public DateTimeOffset? Fechafactura_c { get; }
        public DateTimeOffset? Fechavence_c { get; }
        public long? Origenfiscalid { get; }
        public string? Origenfiscalclave { get; }
        public string? Origenfiscalnombre { get; }
        public long? Devolucionrefid { get; }
        public int? Devolucionreffolio { get; }
        public DateTimeOffset? Devolucionreffechahora { get; }

        public Tmp_docto_provdevo(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, string? folio_c, string? factura_c, DateTimeOffset? fechafactura_c, DateTimeOffset? fechavence_c, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre, long? devolucionrefid, int? devolucionreffolio, DateTimeOffset? devolucionreffechahora)
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
            Folio_c = folio_c;
            Factura_c = factura_c;
            Fechafactura_c = fechafactura_c;
            Fechavence_c = fechavence_c;
            Origenfiscalid = origenfiscalid;
            Origenfiscalclave = origenfiscalclave;
            Origenfiscalnombre = origenfiscalnombre;
            Devolucionrefid = devolucionrefid;
            Devolucionreffolio = devolucionreffolio;
            Devolucionreffechahora = devolucionreffechahora;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_docto_provdevo other &&
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
                   Origenfiscalnombre == other.Origenfiscalnombre &&
                   Devolucionrefid == other.Devolucionrefid &&
                   Devolucionreffolio == other.Devolucionreffolio &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Devolucionreffechahora, other.Devolucionreffechahora);
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
            hash.Add(Devolucionrefid);
            hash.Add(Devolucionreffolio);
            hash.Add(Devolucionreffechahora);
            return hash.ToHashCode();
        }
    }

    public class Tmp_Docto_prov_to_devo
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
        public string? Folio_c { get; }
        public string? Factura_c { get; }
        public DateTimeOffset? Fechafactura_c { get; }
        public DateTimeOffset? Fechavence_c { get; }
        public long? Origenfiscalid { get; }
        public string? Origenfiscalclave { get; }
        public string? Origenfiscalnombre { get; }
        public long? Devolucionrefid { get; }
        public int? Devolucionreffolio { get; }
        public DateTimeOffset? Devolucionreffechahora { get; }

        public Tmp_Docto_prov_to_devo(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, string? folio_c, string? factura_c, DateTimeOffset? fechafactura_c, DateTimeOffset? fechavence_c, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre, long? devolucionrefid, int? devolucionreffolio, DateTimeOffset? devolucionreffechahora)
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
            Folio_c = folio_c;
            Factura_c = factura_c;
            Fechafactura_c = fechafactura_c;
            Fechavence_c = fechavence_c;
            Origenfiscalid = origenfiscalid;
            Origenfiscalclave = origenfiscalclave;
            Origenfiscalnombre = origenfiscalnombre;
            Devolucionrefid = devolucionrefid;
            Devolucionreffolio = devolucionreffolio;
            Devolucionreffechahora = devolucionreffechahora;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_Docto_prov_to_devo other &&
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
                   Origenfiscalnombre == other.Origenfiscalnombre &&
                   Devolucionrefid == other.Devolucionrefid &&
                   Devolucionreffolio == other.Devolucionreffolio &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Devolucionreffechahora, other.Devolucionreffechahora);
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
            hash.Add(Devolucionrefid);
            hash.Add(Devolucionreffolio);
            hash.Add(Devolucionreffechahora);
            return hash.ToHashCode();
        }
    }
}
