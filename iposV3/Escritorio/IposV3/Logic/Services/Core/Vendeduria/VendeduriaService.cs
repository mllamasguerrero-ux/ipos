using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class VendeduriaService
    {

        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private DoctoMovtoService _doctoMovtoService;
        private PagoService _pagoService;

        public VendeduriaService(
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




        public void Docto_vend_insert(DoctoVendTrans doctoVendTrans, ref long? doctoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoTrans = new DoctoTransaction()
                {
                    Empresaid = doctoVendTrans.Empresaid,
                    Sucursalid = doctoVendTrans.Sucursalid,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = doctoVendTrans.Creadopor_userid,
                    Estatusdoctoid = doctoVendTrans.Estatusdoctoid,
                    Usuarioid = doctoVendTrans.Usuarioid,
                    Corteid = null,
                    Fecha = doctoVendTrans.Fecha,
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
                    Cajaid = doctoVendTrans.Cajaid,
                    Almacenid = doctoVendTrans.Almacenid,
                    Origenfiscalid = doctoVendTrans.Origenfiscalid,
                    Esapartado = BoolCN.N,
                    Doctoparentid = doctoVendTrans.Doctoparentid,
                    Clienteid = doctoVendTrans.Clienteid,
                    Tipodoctoid = doctoVendTrans.Tipodoctoid,
                    Proveedorid = null,
                    Sucursal_id = doctoVendTrans.Sucursal_id,
                    Referencia = doctoVendTrans.Referencia,
                    Referencias = doctoVendTrans.Referencias,
                    Fechavence = doctoVendTrans.Fechavence

                };

                _doctoService.DoctoInsert(doctoTrans, ref doctoId, localContext);

                var docto_traslado = new Docto_traslado()
                {
                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = doctoVendTrans.Usuarioid,
                    EmpresaId = doctoVendTrans.Empresaid,
                    SucursalId = doctoVendTrans.Sucursalid,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = doctoVendTrans.Usuarioid,
                    Sucursaltid = doctoVendTrans.Sucursaltid,
                    Almacentid = doctoVendTrans.Almacentid,
                    Doctoid = doctoId

                };
                localContext.Add(docto_traslado);
                localContext.SaveChanges();

                if (doctoVendTrans.Mercanciaentregada == BoolCN.N)
                {

                    var docto_apartado = new Docto_apartado()
                    {

                        Modificado = DateTimeOffset.UtcNow,
                        ModificadoPorId = doctoVendTrans.Usuarioid,
                        EmpresaId = doctoVendTrans.Empresaid,
                        SucursalId = doctoVendTrans.Sucursalid,
                        Activo = doctoTrans.Activo,
                        Creado = DateTimeOffset.UtcNow,
                        CreadoPorId = doctoVendTrans.Usuarioid,
                        Doctoid = doctoId,
                        Mercanciaentregada = doctoVendTrans.Mercanciaentregada ?? BoolCN.S

                    };
                    localContext.Add(docto_apartado);
                    localContext.SaveChanges();
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }



        public void Docto_vend_update_estatus(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                _doctoMovtoService.Docto_update_status(empresaId, sucursalId, id, estatusDoctoId, localContext);

                localContext.SaveChanges();

                var movtoInfo_list = localContext.Movto.AsNoTracking()
                                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id)
                                                    .Select(m => new { m.Id })
                                                    .ToList();
                foreach (var movtoInfo in movtoInfo_list)
                {
                    Movto_vend_update_status(empresaId, sucursalId, movtoInfo.Id, estatusDoctoId, localContext);

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




        public void Docto_vend_and_payments_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
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


                Docto_vend_save(empresaId, sucursalId, id, estatusDoctoId, localContext);

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


        public void Docto_vend_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                Docto_vend_update_estatus(empresaId, sucursalId, id, estatusDoctoId, localContext);

                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Include(d => d.Docto_traslado)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id && d.Docto_traslado != null)
                                            .Select(d => new { d.Estatusdoctoid, d.Docto_traslado!.Sucursaltid, d.Folio, d.Sucursal_id })
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


        public void Docto_vend_delete(long empresaId, long sucursalId, long id,
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




        public void Docto_vend_cancel(long empresaId, long sucursalId,
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



        public void Docto_vend_checaryaplicar_tipomayoreo(long empresaId, long sucursalId, long id, 
            long? productoId,
            out bool recalcularDetalles,  out long tipoMayoreoId, ApplicationDbContext localContext)
        {
            recalcularDetalles = false;
            tipoMayoreoId = 1;

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;



            try
            {
                var doctoInfo = localContext.Docto
                                    .Include(d => d.Docto_precio).AsNoTracking()
                                    .Where(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Id == id)
                                    .Select(d => new { d.Docto_precio!.Tipomayoreoid })
                                    .FirstOrDefault();

                if (doctoInfo == null)
                    return;

                tipoMayoreoId = doctoInfo?.Tipomayoreoid ?? tipoMayoreoId;


                if (productoId != null)
                {
                    var productoInfo = localContext.Producto
                            .Include(p => p.Linea).AsNoTracking()
                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId)
                            .Select(p => new { p.Linea!.Aplicamayoreoxlinea })
                            .FirstOrDefault();

                    if (productoInfo?.Aplicamayoreoxlinea != BoolCS.S)
                    {
                        return;
                    }
                }

                Docto_vend_calcularTipoMayoreo(empresaId, sucursalId, id, out tipoMayoreoId, localContext);

                if (tipoMayoreoId != (doctoInfo!.Tipomayoreoid ?? 1))
                {
                    recalcularDetalles = (doctoInfo!.Tipomayoreoid ?? 1) != tipoMayoreoId;
                    if (recalcularDetalles)
                    {
                        //actualiza el tipomayoreoid en docto
                        var docto_precio = localContext.Docto_precio.FirstOrDefault(d => d.EmpresaId == empresaId &&
                                                                                  d.SucursalId == sucursalId &&
                                                                                  d.Doctoid == id);
                        if(docto_precio != null)
                        {
                            docto_precio.Tipomayoreoid = tipoMayoreoId;
                            localContext.Docto_precio.Update(docto_precio);
                        }
                        else
                        {
                            docto_precio = new Docto_precio()
                            {
                                EmpresaId = empresaId,
                                SucursalId = sucursalId,
                                Doctoid = id,
                                Tipomayoreoid = tipoMayoreoId,
                                Tipodescuentovale = null
                            };
                            localContext.Docto_precio.Add(docto_precio);
                        }
                        localContext.SaveChanges();
                    }
                    return;
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


        public void Docto_vend_calcularTipoMayoreo(long empresaId, long sucursalId, long id,
             out long tipoMayoreoId, ApplicationDbContext localContext)
        {
            tipoMayoreoId = 1;

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;



            try
            {


                var parametroInfo = localContext.Parametro.AsNoTracking()
                                                .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                                .Select(p => new { p.Aplicarmayoreoporlinea, p.Piezasigualesmediomayoreo, p.Piezasdifmediomayoreo, p.Piezasigualesmayoreo, p.Piezasdifmayoreo })
                                                .FirstOrDefault();

                if (parametroInfo == null)
                {
                    return;
                }

                if (parametroInfo!.Aplicarmayoreoporlinea == BoolCN.N)
                {
                    tipoMayoreoId = 1;
                    return;
                }


                var totalCantidad = localContext.Movto.AsNoTracking()
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Linea)
                                                .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                            m.Doctoid == id && m.Producto != null && m.Producto.Linea != null && m.Producto.Linea.Aplicamayoreoxlinea == BoolCS.S)
                                                .Sum(m => (m.Cantidad *
                                                            (m.Producto!.Producto_inventario != null && m.Producto!.Producto_inventario!.Cantxpieza > 0 ?
                                                                m.Producto!.Producto_inventario!.Cantxpieza :
                                                                1
                                                             )
                                                           )
                                                     );

                var maxCantidadXProd = localContext.Movto.AsNoTracking()
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Linea)
                                                .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                            m.Doctoid == id && m.Producto != null && m.Producto.Linea != null && m.Producto.Linea.Aplicamayoreoxlinea == BoolCS.S)
                                                .GroupBy(m => m.Productoid)
                                                .Select(g => new
                                                {
                                                    ProductoId = g.Key,
                                                    Cantidad = g.Sum(m =>
                                                                           (m.Cantidad *
                                                                            (m.Producto!.Producto_inventario != null && m.Producto!.Producto_inventario!.Cantxpieza > 0 ?
                                                                                m.Producto!.Producto_inventario!.Cantxpieza :
                                                                                1
                                                                             )
                                                                           )
                                                                      )
                                                })
                                                .Max(m => m.Cantidad);
                tipoMayoreoId = 1;

                if ((totalCantidad >= (parametroInfo!.Piezasdifmayoreo ?? 0) && (parametroInfo!.Piezasdifmayoreo ?? 0) > 0) ||
                     (maxCantidadXProd >= (parametroInfo!.Piezasigualesmayoreo ?? 0) && (parametroInfo!.Piezasigualesmayoreo ?? 0) > 0)
                   )
                {
                    tipoMayoreoId = 3;
                }

                if ((totalCantidad >= (parametroInfo!.Piezasdifmediomayoreo ?? 0) && (parametroInfo!.Piezasdifmediomayoreo ?? 0) > 0) ||
                   (maxCantidadXProd >= (parametroInfo!.Piezasigualesmediomayoreo ?? 0) && (parametroInfo!.Piezasigualesmediomayoreo ?? 0) > 0))
                {
                    tipoMayoreoId = 2;
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


        public void Docto_vend_recalcularDetalles(long empresaId, long sucursalId, long id, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var movtosACambiar = localContext.Movto.AsNoTracking()
                                        .Include(m => m.Movto_promocion)
                                        .Include(m => m.Movto_inventario)
                                        .Include(m => m.Movto_comodin)
                                        .Include(m => m.Docto)
                                        .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                        .Include(m => m.Producto).ThenInclude(p => p!.Linea)
                                        .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id &&
                                                    m.Producto!.Linea != null && m.Producto!.Linea!.Aplicamayoreoxlinea == BoolCS.S
                                               )
                                        .ToList();
                foreach (var movtoACambiar in movtosACambiar)
                {
                    var movtoTrans = MovtoVendTransFromMovto(movtoACambiar);

                    movtoTrans.Precio = null;
                    movtoTrans.Precioyavalidado = BoolCN.N;
                    movtoTrans.Cantidad = 0m;

                    long? movtoIdDummy = movtoACambiar.Id;
                    this.Movto_vend_insert(movtoTrans, ref movtoIdDummy, localContext, true);

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



        public void Docto_vend_aplicar_promociones_multidetalle(long empresaId, long sucursalId, long id,
                                                                long? productoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var fechaActual = DateTimeOffset.Now.Date;
                int diaActual = (int)DateTime.Now.DayOfWeek;

                var lineaId = productoId != null ? localContext.Producto.AsNoTracking()
                                               .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId)
                                               .Select(p => p.Lineaid)
                                               .FirstOrDefault() : null;



                var promocionesAAplicar = localContext.Movto.AsNoTracking()
                                                        .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                                        .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id &&
                                                                    (lineaId == null || m.Producto!.Lineaid == lineaId))
                                                        .GroupBy(m => new { m.Producto!.EmpresaId, m.Producto!.SucursalId, m.Producto!.Lineaid, m.Producto!.Producto_precios!.Precio1,
                                                                            m.Producto!.Ivaimpuesto, m.Producto!.Iepsimpuesto})
                                                        .Select(m => new { m.Key.EmpresaId, m.Key.SucursalId, m.Key.Lineaid, m.Key.Precio1, m.Key.Ivaimpuesto , m.Key.Iepsimpuesto })
                                                        .Join(
                                                             localContext.Promocion.AsNoTracking()
                                                                .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                 (p.Rangopromocionid == 2) &&
                                                                 (p.Tipopromocionid == 1 || p.Tipopromocionid == 2) &&
                                                                 p.Fechainicio <= fechaActual && p.Fechafin >= fechaActual &&
                                                                 p.Activo == BoolCS.S && p.Esmultidetalle == BoolCN.S &&
                                                                 (p.Lineaid == lineaId || lineaId == null) &&
                                                                 ((p.Lunes == BoolCS.S && diaActual == 1) ||
                                                                  (p.Martes == BoolCS.S && diaActual == 2) ||
                                                                  (p.Miercoles == BoolCS.S && diaActual == 3) ||
                                                                  (p.Jueves == BoolCS.S && diaActual == 4) ||
                                                                  (p.Viernes == BoolCS.S && diaActual == 5) ||
                                                                  (p.Sabado == BoolCS.S && diaActual == 6) ||
                                                                  (p.Domingo == BoolCS.S && diaActual == 0))

                                                              ),
                                                              m => new
                                                              {
                                                                  m.EmpresaId,
                                                                  m.SucursalId,
                                                                  m.Lineaid
                                                              },
                                                              p => new
                                                              {
                                                                  p.EmpresaId,
                                                                  p.SucursalId,
                                                                  p.Lineaid
                                                              },
                                                              (m, p) => new
                                                              {

                                                                  p.EmpresaId,
                                                                  p.SucursalId,
                                                                  p.Id,
                                                                  p.Cantidadllevate,
                                                                  p.Cantidad,
                                                                  p.Tipopromocionid,
                                                                  p.Importe,
                                                                  p.Porcentajedescuento,
                                                                  p.Enmonedero,
                                                                  p.Lineaid,
                                                                  p.Descmultidetalle,
                                                                  m.Precio1,
                                                                  m.Ivaimpuesto,
                                                                  m.Iepsimpuesto
                                                              }).ToList();

                


                foreach (var promocion in promocionesAAplicar)
                {
                    bool aplicarPromocionMovtos = false;

                    decimal precioActual = promocion.Precio1;
                    bool espromocion = false;
                    long? promocionId = null;
                    string? promocionDesglose = null;

                    var productoImpuestoCalculado = Math.Round(
                                                                                    (
                                                                                        ((100m + promocion.Iepsimpuesto) / 100m) *
                                                                                        ((100m + promocion.Ivaimpuesto) / 100m)
                                                                                    ) * 100m, 2
                                                                                  ) - 100m;




                    var movtoInfo = localContext.Movto.AsNoTracking()
                                                .Include(m => m.Movto_promocion)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                                .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id &&
                                                            m.Producto!.Lineaid == promocion.Lineaid &&
                                                            m.Producto!.Ivaimpuesto == promocion.Ivaimpuesto &&
                                                            m.Producto!.Iepsimpuesto == promocion.Iepsimpuesto &&
                                                            m.Producto!.Producto_precios!.Precio1 == promocion.Precio1 &&
                                                            (promocion.Descmultidetalle == null || promocion.Descmultidetalle == "" ||
                                                                m.Producto!.Productocaracteristicas!.Texto6 == promocion.Descmultidetalle)
                                                            )
                                                .GroupBy(m => m.Doctoid)
                                                .Select(m => new { CantidadMultiDetalle = m.Sum(s => s.Cantidad),
                                                    PrecioActualMultiDetalle =
                                                                        Math.Round(
                                                                            Math.Round(m.Sum(s => (s.Movto_promocion!.Promocion == BoolCN.S && s.Movto_promocion!.Promocionid == promocion.Id ? s.Preciolista : s.Precio) *
                                                                                        s.Cantidad), 4) /
                                                                            m.Sum(s => s.Cantidad)
                                                                             , 4)

                                                })
                                                .FirstOrDefault();

                    if (movtoInfo == null)
                        return;


                    if(promocion.Tipopromocionid == 1)
                    {
                        if(movtoInfo.CantidadMultiDetalle >= promocion.Cantidadllevate)
                        {

                            decimal cantidadPromoPorAplicacion = promocion.Cantidadllevate!.Value - promocion.Cantidad!.Value;
                            decimal numAplicaciones = Math.Floor(movtoInfo.CantidadMultiDetalle / promocion.Cantidadllevate!.Value);
                            decimal aplicadosresiduales = movtoInfo.CantidadMultiDetalle - (promocion.Cantidadllevate!.Value * numAplicaciones) - promocion.Cantidad!.Value;
                            if (aplicadosresiduales < 0m)
                                aplicadosresiduales = 0m;
                            decimal cantidadConPromo = (numAplicaciones * cantidadPromoPorAplicacion) + aplicadosresiduales;
                            decimal cantidadSinPromo = movtoInfo.CantidadMultiDetalle - cantidadConPromo;
                            decimal precioBuffer = (cantidadSinPromo * promocion.Precio1) / movtoInfo.CantidadMultiDetalle;

                            if (precioBuffer < movtoInfo.PrecioActualMultiDetalle)
                            {
                                precioActual = precioBuffer;
                                espromocion = true;
                                promocionId = promocion.Id;
                                promocionDesglose = "GRATIS " + cantidadConPromo.ToString() +
                                                    " Y CON PRECIO " + promocion.Precio1.ToString() + " " +
                                                    cantidadSinPromo.ToString();
                                aplicarPromocionMovtos = true;
                            }
                        }
                    }
                    else if( promocion.Tipopromocionid == 2)
                    {
                        if (movtoInfo.CantidadMultiDetalle >= promocion.Cantidad &&
                            (promocion.Importe != null))
                        {
                            decimal precioBufferPromo = (promocion.Importe!.Value / ((100m + productoImpuestoCalculado) / 100m)) / promocion.Cantidad!.Value;

                            decimal numAplicaciones = Math.Floor(movtoInfo.CantidadMultiDetalle / promocion.Cantidad!.Value);
                            decimal cantidadConPromo = numAplicaciones * promocion.Cantidad!.Value;
                            decimal cantidadSinPromo = movtoInfo.CantidadMultiDetalle - cantidadConPromo;
                            decimal precioBuffer = ((precioBufferPromo * cantidadConPromo) + (promocion.Precio1 * cantidadSinPromo)) / movtoInfo.CantidadMultiDetalle;

                            if (precioBuffer < precioActual)
                            {
                                precioActual = precioBuffer;
                                espromocion = true;
                                promocionId = promocion.Id;
                                promocionDesglose = "CON PRECIO " + precioBufferPromo.ToString() +
                                                    " " + cantidadConPromo.ToString() +
                                                    " Y CON PRECIO " + promocion.Precio1.ToString() +
                                                    " " + cantidadSinPromo.ToString();
                                aplicarPromocionMovtos = true;
                            }


                        }


                    }

                    //if(actualizarMovtos)
                    //{
                        var movtosACambiar = localContext.Movto.AsNoTracking()
                                                .Include(m => m.Movto_promocion)
                                                .Include(m => m.Movto_inventario)
                                                .Include(m => m.Movto_comodin)
                                                .Include(m => m.Docto)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                                .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == id &&
                                                            m.Producto!.Lineaid == promocion.Lineaid &&
                                                            m.Producto!.Ivaimpuesto == promocion.Ivaimpuesto &&
                                                            m.Producto!.Iepsimpuesto == promocion.Iepsimpuesto &&
                                                            m.Producto!.Producto_precios!.Precio1 == promocion.Precio1 &&
                                                            (promocion.Descmultidetalle == null || promocion.Descmultidetalle == "" ||
                                                                m.Producto!.Productocaracteristicas!.Texto6 == promocion.Descmultidetalle) &&
                                                             (aplicarPromocionMovtos || m.Movto_promocion!.Promocionid == promocion.Id)
                                                       ) 
                                                .ToList();
                        foreach(var movtoACambiar in movtosACambiar)
                        {
                            var movtoTrans = MovtoVendTransFromMovto(movtoACambiar);

                            if(aplicarPromocionMovtos)
                            {
                                movtoTrans.Precio = precioActual;
                                movtoTrans.Precioyavalidado = BoolCN.S;
                                movtoTrans.Cantidad = 0m;
                            }
                            else
                            {
                                movtoTrans.Precio = null;
                                movtoTrans.Precioyavalidado = BoolCN.N;
                                movtoTrans.Cantidad = 0m;

                            }
                            long? movtoIdDummy = movtoACambiar.Id;
                            this.Movto_vend_insert(movtoTrans, ref movtoIdDummy, localContext, true);




                            var movto_promocion_guardado = localContext.Movto_promocion.FirstOrDefault(
                                                                            m => m.EmpresaId == movtoACambiar.EmpresaId &&
                                                                                 m.SucursalId == movtoACambiar.SucursalId &&
                                                                                 m.Movtoid == movtoACambiar.Id);
                            if (movto_promocion_guardado == null)
                            {
                                var movto_promocion = new Movto_promocion()
                                {

                                    EmpresaId = movtoACambiar.EmpresaId,
                                    SucursalId = movtoACambiar.SucursalId,
                                    Activo = BoolCS.S,
                                    Creado = DateTimeOffset.Now,
                                    CreadoPorId = movtoACambiar.Docto!.Usuarioid,
                                    Modificado = DateTimeOffset.Now,
                                    ModificadoPorId = movtoACambiar.Docto!.Usuarioid,

                                    Movtoid = movtoACambiar.Id,

                                    Promocion = espromocion ? BoolCN.S : BoolCN.N,
                                    Promociondesglose = promocionDesglose,
                                    Aplicopromoxmontomin = null,
                                    Promocionid = promocionId,
                                    Promocionmultidetalleid = null

                                };
                                localContext.Add(movto_promocion);
                            }
                            else 
                            {

                                if (aplicarPromocionMovtos || movto_promocion_guardado.Promocionid == promocion.Id)
                                {


                                    movto_promocion_guardado.Promocion = espromocion ? BoolCN.S : BoolCN.N;
                                    movto_promocion_guardado.Promociondesglose = promocionDesglose;
                                    movto_promocion_guardado.Aplicopromoxmontomin = null;
                                    movto_promocion_guardado.Promocionid = promocionId;
                                    movto_promocion_guardado.Promocionmultidetalleid = null;

                                    localContext.Update(movto_promocion_guardado);
                                }

                            }


                        }
                    //}



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




        public MovtoVendTrans MovtoVendTransFromMovto(Movto movto)
        {


            var Fnc_movto_vendeduria_insertParam = new MovtoVendTrans();
            Fnc_movto_vendeduria_insertParam.Loteimportado = movto.Loteimportado;
            Fnc_movto_vendeduria_insertParam.Movtoparentid = movto.Movtoparentid;
            Fnc_movto_vendeduria_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_vendeduria_insertParam.Precioyavalidado = BoolCN.S;
            Fnc_movto_vendeduria_insertParam.Usuarioid = movto.Docto?.Usuarioid ?? 0;

            Fnc_movto_vendeduria_insertParam.Lote = movto.Lote;
            Fnc_movto_vendeduria_insertParam.Fechavence = movto.Fechavence;
            Fnc_movto_vendeduria_insertParam.Localidad = movto.Movto_inventario?.Localidad;
            Fnc_movto_vendeduria_insertParam.Descripcion1 = movto.Movto_comodin?.Descripcion1;
            Fnc_movto_vendeduria_insertParam.Descripcion2 = movto.Movto_comodin?.Descripcion2;
            Fnc_movto_vendeduria_insertParam.Descripcion3 = movto.Movto_comodin?.Descripcion3;
            Fnc_movto_vendeduria_insertParam.Empresaid = movto.EmpresaId;
            Fnc_movto_vendeduria_insertParam.Sucursalid = movto.SucursalId;
            Fnc_movto_vendeduria_insertParam.Id = movto.Id;
            Fnc_movto_vendeduria_insertParam.Doctoid = movto.Doctoid!.Value;
            Fnc_movto_vendeduria_insertParam.Partida = movto.Partida;
            Fnc_movto_vendeduria_insertParam.Estatusmovtoid = movto!.Estatusmovtoid!.Value;
            Fnc_movto_vendeduria_insertParam.Productoid = movto!.Productoid!.Value;

            Fnc_movto_vendeduria_insertParam.Cantidad = movto.Cantidad;
            Fnc_movto_vendeduria_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_vendeduria_insertParam.Precio = movto.Precio;


            Fnc_movto_vendeduria_insertParam.Precioconimp = null;
            Fnc_movto_vendeduria_insertParam.Preciomanual = null;


            return Fnc_movto_vendeduria_insertParam;
        }



        public void Movto_vendeduria_group(long empresaId, long sucursalId, long doctoId,
                                            long productoId, decimal? descuentoPorcentaje, decimal? precio,
                                            string? lote, DateTimeOffset? fechaVence, long? loteImportado,
                                            //long? movtoParentid, string? localidad, long? anaquelId, 
                                            decimal? precioConImp, decimal precioManual,
                                            string? descripcion1, string? descripcion2, string? descripcion3,
                                            out long? movtoActualId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            movtoActualId = null;

            try
            {

                //var bufferMovtoActualId = localContext.Movto.AsNoTracking()
                //                                      .Include(m => m.Movto_precio)
                //                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                //                                                  m.Doctoid == doctoId && m.Productoid == productoId &&
                //                                                  (m.Lote ?? "") == (lote ?? "") &&
                //                                                  ((m.Fechavence == null && fechaVence == null) || m.Fechavence == fechaVence) &&
                //                                                  (m.Loteimportado ?? 0) == (loteImportado ?? 0) &&
                //                                                  m.Movto_precio != null &&
                //                                                  (
                //                                                    ((m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.N && (precio == null || (m.Precio == (precio ?? 0m)))) ||
                //                                                    ((m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.S && (precioConImp == null || (m.Movto_precio.Precioconimp == (precioConImp ?? 0m))))
                //                                                  ) &&
                //                                                  (descuentoPorcentaje == null || (m.Descuentoporcentaje == (descuentoPorcentaje ?? 0m)))
                //                                              )
                //                                      .Select(m => (long?)m.Id)
                //                                      .FirstOrDefault();

                var bufferMovtoActualId = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_comodin)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                  m.Doctoid == doctoId && m.Productoid == productoId &&
                                                                  (m.Lote ?? "") == (lote ?? "") &&
                                                                  ((m.Fechavence == null && fechaVence == null) || m.Fechavence == fechaVence) &&
                                                                  (m.Loteimportado ?? 0) == (loteImportado ?? 0) &&
                                                                  (
                                                                      (
                                                                        m.Preciomanual == precioManual 
                                                                      ) ||
                                                                      (
                                                                        ((m.Movto_precio == null || (m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.N) && (precio == null || (m.Precio == (precio ?? 0m)))) ||
                                                                        (m.Movto_precio != null && (m.Movto_precio.Calc_imp_de_total ?? BoolCN.N) == BoolCN.S && (precioConImp == null || (m.Movto_precio.Precioconimp == (precioConImp ?? 0m))))
                                                                      )
                                                                  
                                                                  ) &&
                                                                  (descuentoPorcentaje == null || (m.Descuentoporcentaje == Decimal.Round((descuentoPorcentaje ?? 0m), 4))) &&
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


        public void Movto_vend_insert(MovtoVendTrans movtoVendTrans, ref long? movtoId,
            ApplicationDbContext localContext, bool saltarRecalculo = false)
        {
            

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? movtoexistenteid = null;

            movtoId = null;

            var calc_imp_de_total = BoolCN.N;

            decimal? precio = movtoVendTrans.Precio;
            decimal? precioconimp = movtoVendTrans.Precioconimp;
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

            bool espromocion = false;
            long? promocionid = null;
            string? promociondesglose = null;
            decimal monederoabono = 0m;
            long? tipoMayoreoLineaIdAplicado = null;

            List<MovtoKitdefinicionBuffer> movto_kit_def_arr = new List<MovtoKitdefinicionBuffer>();


            try
            {

                var producto_info = localContext.Producto.AsNoTracking()
                                                .Include(p => p.Producto_precios)
                                                .Include(p => p.Producto_kit)
                                                .Where(p => p.EmpresaId == movtoVendTrans.Empresaid && p.SucursalId == movtoVendTrans.Sucursalid && p.Id == movtoVendTrans.Productoid)
                                                .Select(p => new {
                                                    p.Ivaimpuesto,
                                                    p.Iepsimpuesto,
                                                    Preciolista = (p.Producto_precios != null ? p.Producto_precios.Precio1 : 0m),
                                                    Eskit = (p.Producto_kit != null ? p.Producto_kit.Eskit : BoolCN.N),
                                                    Kitimpfijo = (p.Producto_kit != null ? p.Producto_kit.Kitimpfijo : BoolCN.N)
                                                })
                                                .FirstOrDefault();

                if (producto_info == null)
                    throw new Exception("Producto no encontrado");


                var doctoInfo = localContext.Docto.AsNoTracking()
                                            .Include(d => d.Docto_info_pago)
                                            .Include(d => d.Docto_precio)
                                                    .Where(m => m.EmpresaId == movtoVendTrans.Empresaid && m.SucursalId == movtoVendTrans.Sucursalid &&
                                                                 m.Id == movtoVendTrans.Doctoid)
                                                     .Select(m => new { m.Tipodoctoid, m.Clienteid,
                                                                        Pagoacredito = (m.Docto_info_pago != null ? m.Docto_info_pago!.Pagoacredito : BoolCN.N) , 
                                                                        Pagocontarjeta = (m.Docto_info_pago != null ? m.Docto_info_pago!.Pagocontarjeta : TipoPagoConTarjeta.N),
                                                                        Tipomayoreoid = (m.Docto_precio != null ? m.Docto_precio!.Tipomayoreoid : 1)
                                                            })
                                                     .FirstOrDefault();


                if (movtoVendTrans.Id != 0)
                {
                    movtoexistenteid = movtoVendTrans.Id;
                }
                else
                {


                    this.Movto_vendeduria_group(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid, movtoVendTrans.Doctoid,
                                                 movtoVendTrans.Productoid, movtoVendTrans.Descuentoporcentaje, movtoVendTrans.Precio,
                                                 movtoVendTrans.Lote, movtoVendTrans.Fechavence, movtoVendTrans.Loteimportado, 
                                                 //movtoVendTrans.Movtoparentid, movtoVendTrans.Localidad, movtoVendTrans.Anaquelid, 
                                                 movtoVendTrans.Precioconimp, (movtoVendTrans.Preciomanual ?? 0m),
                                                 movtoVendTrans.Descripcion1, movtoVendTrans.Descripcion2, movtoVendTrans.Descripcion3,
                                                 out movtoexistenteid, localContext);


                }

                //re-calculo de precio
                if ((movtoVendTrans.Preciomanual ?? 0m) == 0 && movtoVendTrans.Precioyavalidado != BoolCN.S)
                {

                    decimal precioCalculado = 0m;

                    decimal cantidad = movtoVendTrans.Cantidad;
                    if ((movtoexistenteid ?? 0) != 0)
                    {
                        var cantidadActual = localContext.Movto.AsNoTracking()
                                                         .Where(m => m.EmpresaId == movtoVendTrans.Empresaid && m.SucursalId == movtoVendTrans.Sucursalid &&
                                                                     m.Id == movtoexistenteid!.Value)
                                                         .Select(m => m.Cantidad)
                                                         .FirstOrDefault();
                        cantidad += cantidadActual;

                    }


                    Precioprod_vendeduria(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid,
                                                                movtoVendTrans.Productoid, (doctoInfo?.Clienteid ?? 0),
                                                                cantidad,
                                                                doctoInfo?.Tipodoctoid ?? 21, null, null,
                                                                null, doctoInfo?.Pagocontarjeta, doctoInfo?.Tipomayoreoid, 
                                                                doctoInfo?.Pagoacredito == BoolCN.S,
                                                                out precioCalculado, out espromocion, out promocionid,
                                                                out promociondesglose, out monederoabono, out tipoMayoreoLineaIdAplicado,
                                                                localContext);

                    precio = precioCalculado ;

                }



                if ((movtoexistenteid ?? 0) == 0)
                {


                    if ((movtoVendTrans.Precioconimp ?? 0) != 0)
                    {



                        calc_imp_de_total = BoolCN.S;


                        precio = movtoVendTrans.Precio;
                        precioconimp = movtoVendTrans.Precioconimp;
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

                        _movtoService.CalcularImpuestosTotalesMovto(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid,
                                                    movtoVendTrans.Productoid, movtoVendTrans.Cantidad, producto_info!.Preciolista,
                                                    producto_info.Ivaimpuesto, producto_info.Iepsimpuesto,
                                                    producto_info.Eskit, producto_info.Kitimpfijo, calc_imp_de_total, movtoVendTrans.Movtoparentid,
                                                    null, ref precio, ref precioconimp, ref total, out importe, out subtotal,
                                                    out iva, out ieps, out impuesto, out descuento, out ivaRetenido, out isrRetenido, out tasaIvaRetenido, out tasaIsrRetenido,
                                                    out movto_kit_def_arr, localContext);





                    }


                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoVendTrans.Empresaid,
                        Sucursalid = movtoVendTrans.Sucursalid,
                        Id = 0,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = movtoVendTrans.Usuarioid,
                        Partida = movtoVendTrans.Partida,
                        Estatusmovtoid = movtoVendTrans.Estatusmovtoid,
                        Fecha = DateTimeOffset.Now.Date,
                        Fechahora = DateTimeOffset.Now,
                        Productoid = movtoVendTrans.Productoid,
                        Cantidad = movtoVendTrans.Cantidad,
                        Preciolista = producto_info!.Preciolista,
                        Descuentoporcentaje = movtoVendTrans.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = producto_info!.Ivaimpuesto,
                        Tasaieps = producto_info!.Iepsimpuesto,
                        Total = total,
                        Lote = movtoVendTrans.Lote,
                        Fechavence = movtoVendTrans.Fechavence,
                        Loteimportado = movtoVendTrans.Loteimportado,
                        Movtoparentid = movtoVendTrans.Movtoparentid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = producto_info!.Eskit,
                        Kitimpfijo = producto_info!.Kitimpfijo,
                        Doctoid = movtoVendTrans.Doctoid,
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
                        Localidad = movtoVendTrans.Localidad,
                        Descripcion1 = movtoVendTrans.Descripcion1,
                        Descripcion2 = movtoVendTrans.Descripcion2,
                        Descripcion3 = movtoVendTrans.Descripcion3,
                        Agrupaporparametro = movtoVendTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = movtoVendTrans.Cargartarjetapreciomanual,
                        Precioyavalidado = movtoVendTrans.Precioyavalidado,
                        Usuarioid = movtoVendTrans.Usuarioid,
                        Precioconimp = movtoVendTrans.Precioconimp,
                        Anaquelid = movtoVendTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoInsert(movtoTransaction, ref movtoId, localContext);

                    var movto_precio = new Movto_precio()
                    {

                        EmpresaId = movtoVendTrans.Empresaid,
                        SucursalId = movtoVendTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = movtoVendTrans.Usuarioid,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = movtoVendTrans.Usuarioid,
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

                    var movto_promocion = new Movto_promocion()
                    {

                        EmpresaId = movtoVendTrans.Empresaid,
                        SucursalId = movtoVendTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = movtoVendTrans.Usuarioid,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = movtoVendTrans.Usuarioid,

                        Movtoid = movtoId!.Value,

                        Promocion = espromocion ? BoolCN.S : BoolCN.N,
                        Promociondesglose = promociondesglose,
                        Aplicopromoxmontomin = null,
                        Promocionid = promocionid,
                        Promocionmultidetalleid = null,
                        Tipomayoreolineaid = tipoMayoreoLineaIdAplicado

                    };
                    localContext.Add(movto_promocion );


                    var movto_monedero = new Movto_monedero()
                    {

                        EmpresaId = movtoVendTrans.Empresaid,
                        SucursalId = movtoVendTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = movtoVendTrans.Usuarioid,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = movtoVendTrans.Usuarioid,

                        Movtoid = movtoId!.Value,
                        Monederoabono = monederoabono
                    };
                    localContext.Add(movto_monedero);



                    if ((movtoVendTrans.Anaquelid ?? 0) != 0 || (movtoVendTrans.Localidad ?? "") != "")
                    {

                        var movto_inventario = new Movto_inventario()
                        {

                            EmpresaId = movtoVendTrans.Empresaid,
                            SucursalId = movtoVendTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoVendTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoVendTrans.Usuarioid,
                            Tipodiferenciainventarioid = null,
                            Localidad = movtoVendTrans.Localidad,
                            Anaquelid = movtoVendTrans.Anaquelid,
                            Registroprocesosalida = BoolCN.N,
                            Movtoid = movtoId,
                            Cantidad_real = 0m,
                            Cantidad_teorica = 0m,
                            Cantidad_diferencia = 0m
                        };

                        localContext.Add(movto_inventario);

                    }

                    if (!string.IsNullOrEmpty(movtoVendTrans.Descripcion1))
                    {
                        var movto_comodin = new Movto_comodin()
                        {

                            EmpresaId = movtoVendTrans.Empresaid,
                            SucursalId = movtoVendTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.UtcNow,
                            CreadoPorId = movtoVendTrans.Usuarioid,
                            Modificado = DateTimeOffset.UtcNow,
                            ModificadoPorId = movtoVendTrans.Usuarioid,
                            Movtoid = movtoId,
                            Descripcion1 = movtoVendTrans.Descripcion1,
                            Descripcion2 = movtoVendTrans.Descripcion2,
                            Descripcion3 = movtoVendTrans.Descripcion3
                        };
                        localContext.Add(movto_comodin);
                    }

                    localContext.SaveChanges();




                }
                else
                {
                    movtoId = movtoexistenteid;
                    var movto_a_cambiar = localContext.Movto.AsNoTracking()
                                                      .Where(m => m.EmpresaId == movtoVendTrans.Empresaid && m.SucursalId == movtoVendTrans.Sucursalid &&
                                                                  m.Id == movtoexistenteid)
                                                      .Select(m => new
                                                      {
                                                          Precio = (movtoVendTrans.Precio ?? m.Precio),
                                                          Descuentoporcentaje = (movtoVendTrans.Descuentoporcentaje ?? m.Descuentoporcentaje),
                                                          Preciolista = m.Preciolista,
                                                          Lote = m.Lote,
                                                          Fechavence = m.Fechavence,
                                                          Loteimportado = m.Loteimportado,
                                                          Partida = m.Partida,
                                                          Movtoparentid = m.Movtoparentid,
                                                          Cantidad = m.Cantidad + movtoVendTrans.Cantidad,
                                                          TasaIvaRetenido = m.Tasaivaretenido,
                                                          TasaIsrRetenido = m.Tasaisrretenido


                                                      })
                                                      .FirstOrDefault();

                    if (movto_a_cambiar == null)
                        throw new Exception("El registro se borro inesperadamente");


                    //movtoVendTrans.Precio = movto_existente.Precio;
                    //movtoVendTrans.Descuentoporcentaje = movto_existente.Descuentoporcentaje;
                    //movtoVendTrans.Lote = movto_existente.Lote;
                    //movtoVendTrans.Fechavence = movto_existente.Fechavence;
                    //movtoVendTrans.Loteimportado = movto_existente.Loteimportado;
                    //movtoVendTrans.Partida = movto_existente.Partida;
                    //movtoVendTrans.Movtoparentid = movto_existente.Movtoparentid;
                    //movtoVendTrans.Cantidad = movto_existente.Cantidad;


                    if (movto_a_cambiar.Cantidad <= 0)
                    {
                        throw new Exception("La cantidad no puede ser cero");
                    }

                    if ((movtoVendTrans.Precioconimp ?? 0) != 0)
                    {



                        calc_imp_de_total = BoolCN.S;


                        precio = movto_a_cambiar.Precio;
                        precioconimp = movtoVendTrans.Precioconimp;
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

                        _movtoService.CalcularImpuestosTotalesMovto(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid,
                                                    movtoVendTrans.Productoid, movto_a_cambiar.Cantidad, movto_a_cambiar!.Preciolista,
                                                    producto_info!.Ivaimpuesto, producto_info!.Iepsimpuesto,
                                                    producto_info!.Eskit, producto_info!.Kitimpfijo, calc_imp_de_total, movtoexistenteid!.Value,
                                                    null, ref precio, ref precioconimp, ref total, out importe, out subtotal,
                                                    out iva, out ieps, out impuesto, out descuento, out ivaRetenido, out isrRetenido, out tasaIvaRetenido, out tasaIsrRetenido,
                                                    out movto_kit_def_arr, localContext);





                    }



                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoVendTrans.Empresaid,
                        Sucursalid = movtoVendTrans.Sucursalid,
                        Id = movtoexistenteid!.Value,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = movtoVendTrans.Usuarioid,
                        Partida = movto_a_cambiar.Partida,
                        Estatusmovtoid = movtoVendTrans.Estatusmovtoid,
                        Fecha = DateTimeOffset.Now.Date,
                        Fechahora = DateTimeOffset.Now,
                        Productoid = movtoVendTrans.Productoid,
                        Cantidad = movto_a_cambiar.Cantidad,
                        Preciolista = movto_a_cambiar.Preciolista,
                        Descuentoporcentaje = movtoVendTrans.Descuentoporcentaje,
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
                        Doctoid = movtoVendTrans.Doctoid,
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
                        Localidad = movtoVendTrans.Localidad,
                        Descripcion1 = movtoVendTrans.Descripcion1,
                        Descripcion2 = movtoVendTrans.Descripcion2,
                        Descripcion3 = movtoVendTrans.Descripcion3,
                        Agrupaporparametro = movtoVendTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = movtoVendTrans.Cargartarjetapreciomanual,
                        Precioyavalidado = movtoVendTrans.Precioyavalidado,
                        Usuarioid = movtoVendTrans.Usuarioid,
                        Precioconimp = movtoVendTrans.Precioconimp,
                        Anaquelid = movtoVendTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoUpdate(movtoTransaction, localContext);



                    var movto_promocion_guardado = localContext.Movto_promocion.FirstOrDefault(
                                                                    m => m.EmpresaId == movtoVendTrans.Empresaid &&
                                                                         m.SucursalId == movtoVendTrans.Sucursalid &&
                                                                         m.Movtoid == movtoexistenteid!.Value);
                    if (movto_promocion_guardado == null)
                    {
                        var movto_promocion = new Movto_promocion()
                        {

                            EmpresaId = movtoVendTrans.Empresaid,
                            SucursalId = movtoVendTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoVendTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoVendTrans.Usuarioid,

                            Movtoid = movtoId!.Value,

                            Promocion = espromocion ? BoolCN.S : BoolCN.N,
                            Promociondesglose = promociondesglose,
                            Aplicopromoxmontomin = null,
                            Promocionid = promocionid,
                            Promocionmultidetalleid = null,
                            Tipomayoreolineaid = tipoMayoreoLineaIdAplicado

                        };
                        localContext.Add(movto_promocion);
                    }
                    else
                    {

                        movto_promocion_guardado.Promocion = espromocion ? BoolCN.S : BoolCN.N;
                        movto_promocion_guardado.Promociondesglose = promociondesglose;
                        movto_promocion_guardado.Aplicopromoxmontomin = null;
                        movto_promocion_guardado.Promocionid = promocionid;
                        movto_promocion_guardado.Promocionmultidetalleid = null;
                        movto_promocion_guardado.Tipomayoreolineaid = tipoMayoreoLineaIdAplicado;

                        localContext.Update(movto_promocion_guardado);

                    }




                    var movto_monedero_guardado = localContext.Movto_monedero.FirstOrDefault(
                                                                    m => m.EmpresaId == movtoVendTrans.Empresaid &&
                                                                         m.SucursalId == movtoVendTrans.Sucursalid &&
                                                                         m.Movtoid == movtoexistenteid!.Value);
                    if (movto_monedero_guardado == null)
                    {
                        var movto_monedero = new Movto_monedero()
                        {

                            EmpresaId = movtoVendTrans.Empresaid,
                            SucursalId = movtoVendTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoVendTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoVendTrans.Usuarioid,

                            Movtoid = movtoId!.Value,
                            Monederoabono = monederoabono
                        };
                        localContext.Add(movto_monedero);
                    }
                    else
                    {
                        movto_monedero_guardado.Monederoabono = monederoabono;
                        localContext.Update(movto_monedero_guardado);
                    }


                    localContext.SaveChanges();


                }

                if (!saltarRecalculo && movtoVendTrans.Precioyavalidado != BoolCN.S && doctoInfo?.Tipodoctoid == 21 && 
                    ((movtoVendTrans.Preciomanual ?? 0m) == 0m))
                {
                    Docto_vend_aplicar_promociones_multidetalle(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid, movtoVendTrans.Doctoid,
                                                                movtoVendTrans.Productoid, localContext);
                }

                if (!saltarRecalculo && movtoVendTrans.Precioyavalidado != BoolCN.S && doctoInfo?.Tipodoctoid == 21 &&
                    ((movtoVendTrans.Preciomanual ?? 0m) == 0m))
                {
                    bool recalcularDetalles = false;
                    long tipoMayoreoId = 1;
                    this.Docto_vend_checaryaplicar_tipomayoreo(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid, movtoVendTrans.Doctoid, movtoVendTrans.Productoid, out recalcularDetalles, out tipoMayoreoId, localContext);
                    if (recalcularDetalles)
                    {
                        Docto_vend_recalcularDetalles(movtoVendTrans.Empresaid, movtoVendTrans.Sucursalid, movtoVendTrans.Doctoid, localContext);
                    }

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


        public void Movto_vend_update_status(long empresaId, long sucursalId, long id, long estatusMovtoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                _movtoService.MovtoUpdateStatus(empresaId, sucursalId, id, estatusMovtoId, localContext);
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

        public void Movto_vend_delete(long empresaId, long sucursalId, long id,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto).ThenInclude(d => d.Docto_precio)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                  m.Id == id)
                                            .Select(m => new { m.Estatusmovtoid, m.Docto!.Tipodoctoid, m.Doctoid,
                                                                m.EmpresaId, m.SucursalId, m.Productoid,
                                                                Tipomayoreoid = m.Docto != null && m.Docto!.Docto_precio != null ?
                                                                                (m.Docto!.Docto_precio!.Tipomayoreoid) : 1
                                                            })
                                            .FirstOrDefault();
                if (movtoInfo == null)
                    throw new Exception("No se encontro el movto");




                if (movtoInfo.Estatusmovtoid != 0)
                    throw new Exception("El registro no esta en  estatus de borrador");

                _doctoMovtoService.Movto_delete(empresaId, sucursalId, id, localContext);


                if (movtoInfo.Tipodoctoid == 21 )
                {
                    Docto_vend_aplicar_promociones_multidetalle(movtoInfo.EmpresaId, movtoInfo.SucursalId, movtoInfo.Doctoid!.Value,
                                                                movtoInfo.Productoid, localContext);
                }


                if (movtoInfo.Tipodoctoid == 21 && (movtoInfo.Tipomayoreoid ?? 1) > 1)
                {
                    bool recalcularDetalles = false;
                    long tipoMayoreoId = 1;
                    this.Docto_vend_checaryaplicar_tipomayoreo(movtoInfo.EmpresaId, movtoInfo.SucursalId, movtoInfo.Doctoid!.Value,
                                                                movtoInfo.Productoid, out recalcularDetalles, out tipoMayoreoId, localContext);
                    if (recalcularDetalles)
                    {
                        Docto_vend_recalcularDetalles(movtoInfo.EmpresaId, movtoInfo.SucursalId, movtoInfo.Doctoid!.Value, localContext);
                    }

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






        public List<Tmp_Movto_vendeduria> Movto_vendeduria(long empresaId, long sucursalId, long doctoId, ApplicationDbContext localContext)
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
                                                          m.Preciomanual,
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
                                                          Descripcion1 = (m.Movto_comodin != null && m.Movto_comodin.Descripcion1 != null ? m.Movto_comodin.Descripcion1 : (m.Producto == null ? null : m.Producto.Descripcion1)),
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
                                                      .Select(m => new Tmp_Movto_vendeduria(

                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Partida,
                                                          m.Productoid,
                                                          m.ProductoClave,
                                                          m.ProductoNombre,
                                                          m.Cantidad,
                                                          m.Preciolista,
                                                          m.Preciomanual,
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
                                                                                    m.Precio < (parametro.Listapreciominimo == 4 ? m.Precio1 :
                                                                                                (parametro.Listapreciominimo == 5 ? m.Precio2 :
                                                                                                  (parametro.Listapreciominimo == 6 ? m.Precio3 :
                                                                                                   (parametro.Listapreciominimo == 7 ? m.Precio4 :
                                                                                                    (parametro.Listapreciominimo == 8 ? m.Precio5 :
                                                                                                     (parametro.Listapreciominimo == 9 ? m.Precio6 : m.Precio1
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




        public List<Tmp_Docto_vendeduria> Docto_vendeduria(long empresaId, long sucursalId,
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

                var lstDocto = localContext.Docto.AsNoTracking()
                                                      .Include(d => d.Estatusdocto)
                                                      .Include(d => d.Usuario)
                                                      .Include(d => d.Caja)
                                                      .Include(d => d.Cliente)
                                                      .Include(d => d.Tipodocto)
                                                      .Include(d => d.Docto_fact_elect)
                                                      .Include(d => d.Docto_traslado).ThenInclude(dt => dt!.Sucursalt)
                                                      .Include(d => d.Docto_traslado).ThenInclude(dt => dt!.Almacen)
                                                      .Include(d => d.Origenfiscal)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                            (todosUsuarios == BoolCS.S || (usuarioId ?? 0) == 0 || d.Usuarioid == usuarioId) &&
                                                            (d.Tipodoctoid == tipoDoctoId) &&
                                                            (d.Estatusdoctoid == estatusDoctoId) &&
                                                            (porFecha != BoolCS.S || (d.Fecha >= fechaIni && d.Fecha <= fechaFin)) &&
                                                            (corteActual != BoolCS.S || d.Corte!.Activo == BoolCS.S) &&
                                                            (todosAlmacenes == BoolCS.S || (almacenId ?? 0) == 0 || d.Almacenid == almacenId)
                                                      )
                                                      .Select(d => new Tmp_Docto_vendeduria(
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
                                                          d.Clienteid,
d.Cliente == null ? null : d.Cliente.Clave,
d.Cliente == null ? null : d.Cliente.Nombre,
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
                                                          d.Fechahora,
                                                          d.Origenfiscalid,
d.Origenfiscal == null ? null : d.Origenfiscal.Clave,
d.Origenfiscal == null ? null : d.Origenfiscal.Nombre

                                                      )).ToList();

                return lstDocto;


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




        public List<Tmp_Precioprod_ref_vend> Precioprod_ref_vend(long empresaId, long sucursalId,
                                                long productoId, long clienteId, decimal cantidad,
                                                 ApplicationDbContext localContext)
        {
            

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                decimal precio = 0m;
                bool espromocion = false;
                long? promocionid = null;
                string? promociondesglose = null;
                decimal monederoabono = 0m;
                long? tipoMayoreoLineaIdAplicado = null;

                Precioprod_vendeduria(empresaId, sucursalId,
                                                productoId, clienteId, cantidad,
                                                21, null, null,
                                                null, null, null, 
                                                null,
                                                out precio, out espromocion, out promocionid,
                                                out promociondesglose, out monederoabono, out tipoMayoreoLineaIdAplicado,
                                                localContext);


                var lstPrecioVendeduria = localContext.Producto.AsNoTracking()
                                                      .Include(p => p.Producto_precios)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                  d.Id == productoId
                                                      )
                                                      .Select(p => new Tmp_Precioprod_ref_vend(
                                                          p.EmpresaId,
                                                          p.SucursalId,
                                                          precio,
                                                          precio,
                                                          precio,
                                                          p.Producto_precios != null ? p.Producto_precios.Costopromedio : 0m,
                                                          precio,
                                                          espromocion,
                                                          promocionid,
                                                          promociondesglose,
                                                          monederoabono,
                                                          tipoMayoreoLineaIdAplicado

                                                      )).ToList();

                return lstPrecioVendeduria;


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




        public void Precioprod_vendeduria(long empresaId, long sucursalId,
                                                long productoId, long clienteId, decimal cantidad,
                                                long tipodoctoid , long? sucursal_info_id , long? sucursaltid ,
                                                decimal? costoprod , TipoPagoConTarjeta? tipoPagoConTarjeta,
                                                long? tipomayoreoid , 
                                                bool? pagoacredito ,
                                                out decimal precio , out bool espromocion , out long? promocionid ,
                                                out string? promociondesglose ,out decimal monederoabono, out long? tipoMayoreoLineaIdAplicado,
                                                 ApplicationDbContext localContext)
        {
           

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            bool forzarListaPrecio = false;
            string listaPrecio = "PRECIO 1";
            bool aplicarPrecioCaja = false;
            string listaPrecioXMayoreo = "";
            decimal precioListaCliente = 0m;
            bool habilitarPromocionBodegazo = false;


            precio = 0m;
            espromocion = false;
            promocionid = null;
            promociondesglose = null;
            monederoabono = 0m;
            tipoMayoreoLineaIdAplicado = null;


            try
            {

                var clienteInfo = localContext.Cliente.AsNoTracking()
                                                       .Include(c => c.Cliente_precio).ThenInclude(p => p!.Listaprecio)
                                                       .Include(c => c.Cliente_precio).ThenInclude(p => p!.Superlistaprecio)
                                                       .Where(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == clienteId)
                                                       .Select(c => new
                                                       {
                                                           Listaprecioid = c.Cliente_precio != null && c.Cliente_precio.Listaprecioid != null ? c.Cliente_precio.Listaprecioid : (long)1,
                                                           ListaPrecioClave = c.Cliente_precio != null && c.Cliente_precio.Listaprecio != null && c.Cliente_precio.Listaprecio.Clave != null ? c.Cliente_precio.Listaprecio.Clave : "",
                                                           Superlistaprecioid = c.Cliente_precio != null && c.Cliente_precio.Superlistaprecioid != null ? c.Cliente_precio.Superlistaprecioid : (long)1,
                                                           SuperlistaPrecioClave = c.Cliente_precio != null && c.Cliente_precio.Superlistaprecio != null && c.Cliente_precio.Superlistaprecio.Clave != null ? c.Cliente_precio.Superlistaprecio.Clave : "",
                                                           c.Cliente_precio!.Mayoreoxproducto
                                                       })
                                                       .FirstOrDefault();

                if (clienteInfo == null)
                    throw new Exception("El cliente no existe");

                var productoInfo = localContext.Producto.AsNoTracking()
                                                   .Include(p => p.Producto_precios)
                                                   .Include(p => p.Unidad)
                                                   .Include(p => p.Linea)
                                                   .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId)
                                                   .Select(p => new
                                                   {
                                                       Precio1 = p.Producto_precios == null ? 0m : p.Producto_precios.Precio1,
                                                       Precio2 = p.Producto_precios == null ? 0m : p.Producto_precios.Precio2,
                                                       Precio3 = p.Producto_precios == null ? 0m : p.Producto_precios.Precio3,
                                                       Precio4 = p.Producto_precios == null ? 0m : p.Producto_precios.Precio4,
                                                       Precio5 = p.Producto_precios == null ? 0m : p.Producto_precios.Precio5,
                                                       Precio6 = p.Producto_precios == null ? 0m : p.Producto_precios.Precio6,
                                                       Superprecio1 = p.Producto_precios == null ? 0m : p.Producto_precios.Superprecio1,
                                                       Superprecio2 = p.Producto_precios == null ? 0m : p.Producto_precios.Superprecio2,
                                                       Superprecio3 = p.Producto_precios == null ? 0m : p.Producto_precios.Superprecio3,
                                                       Superprecio4 = p.Producto_precios == null ? 0m : p.Producto_precios.Superprecio4,
                                                       Superprecio5 = p.Producto_precios == null ? 0m : p.Producto_precios.Superprecio5,
                                                       Costorepo = p.Producto_precios == null ? 0m : p.Producto_precios.Costorepo,
                                                       Costoultimo = p.Producto_precios == null ? 0m : p.Producto_precios.Costoultimo,
                                                       Costopromedio = p.Producto_precios == null ? 0m : p.Producto_precios.Costopromedio,
                                                       p.Producto_precios!.Limiteprecio2,
                                                       p.Producto_inventario!.Pzacaja,
                                                       p.Producto_inventario!.U_empaque,
                                                       p.Unidadid,
                                                       Unidad_clave = p.Unidad!.Clave,
                                                       p.Producto_precios!.Ini_mayo,
                                                       p.Producto_precios!.Mayokgs,
                                                       p.Lineaid,
                                                       Linea_clave = p.Linea!.Clave,
                                                       Linea_aplicamayoreoxlinea = p.Linea!.Aplicamayoreoxlinea,
                                                       p.Producto_precios!.Descuento,
                                                       p.Producto_precios!.Listaprecmayoreoid,
                                                       Listaprecmayoreo_clave = p.Producto_precios!.Listaprecmayoreo!.Clave,
                                                       p.Producto_precios!.Listaprecmediomayid,
                                                       Listaprecmediomay_clave = p.Producto_precios!.Listaprecmediomay!.Clave,
                                                       p.Producto_precios!.Cantmayoreo,
                                                       p.Producto_precios!.Cantmediomay


                                                   })
                                                   .FirstOrDefault();
                if (productoInfo == null)
                    throw new Exception("El producto no esta registrado");

                var descLineaPersonaInfo = localContext.Desclineapers.AsNoTracking()
                                                   .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                               p.Lineaid == productoInfo.Lineaid && p.Personaid == clienteId && p.Activo == BoolCS.S)
                                                .FirstOrDefault();


                var parametroInfo = localContext.Parametro.AsNoTracking()
                                                    .Include(p => p.Tipodescuentoprod)
                                                    .Include(p => p.Lista_precio_def)
                                                    .Include(p => p.Listaprecioxpzacaja_)
                                                    .Include(p => p.Listaprecioxuempaque_)
                                                    .Include(p => p.Listaprecioinimayo_)
                                                    .Include(p => p.Listapreciomaylinea_)
                                                   .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                                   .Select(s => new
                                                   {
                                                       s.Manejasuperlistaprecio,
                                                       s.Tipodescuentoprodid,
                                                       Tipodescuentoprod_clave = s.Tipodescuentoprod!.Clave,
                                                       s.Lista_precio_defid,
                                                       Lista_precio_def_clave = (s.Lista_precio_def!.Clave == null ? "PRECIO 1" : s.Lista_precio_def!.Clave),
                                                       s.Cambiarprecioxpzacaja,
                                                       s.Cambiarprecioxuempaque,
                                                       s.Listaprecioxpzacaja,
                                                       Listaprecioxpzacaja_clave = s.Listaprecioxpzacaja_!.Clave,
                                                       s.Listaprecioxuempaque,
                                                       Listaprecioxuempaque_clave = s.Listaprecioxuempaque_!.Clave,
                                                       s.Listaprecioinimayo,
                                                       Listaprecioinimayo_clave = s.Listaprecioinimayo_!.Clave,
                                                       s.Aplicarmayoreoporlinea,
                                                       s.Preciosordenados,
                                                       s.Habdesclineapersona,
                                                       s.Pagotarjmenorpreciolistaall,
                                                       s.Listapreciomaylinea,
                                                       Listapreciomaylinea_clave = (s.Listapreciomaylinea_!.Clave == null ? "PRECIO 4" : s.Listapreciomaylinea_!.Clave),
                                                       s.Listaprecmedmaylinea,
                                                       Listapremedmaylinea_clave = (s.Listapremedmaylinea_!.Clave == null ? "PRECIO 3" : s.Listapremedmaylinea_!.Clave),
                                                       s.Comisiondebportarjeta,
                                                       s.Comisionportarjeta

                                                   }
                                                   )
                                                   .FirstOrDefault();

                decimal? precio1, precio2, precio3, precio4, precio5;

                if (parametroInfo!.Manejasuperlistaprecio == BoolCN.S)
                {
                    precio1 = productoInfo.Superprecio1;
                    precio2 = productoInfo.Superprecio2;
                    precio3 = productoInfo.Superprecio3;
                    precio4 = productoInfo.Superprecio4;
                    precio5 = productoInfo.Superprecio5;
                }
                else
                {
                    precio1 = productoInfo.Precio1;
                    precio2 = productoInfo.Precio2;
                    precio3 = productoInfo.Precio3;
                    precio4 = productoInfo.Precio4;
                    precio5 = productoInfo.Precio5;
                }

                listaPrecio = parametroInfo!.Manejasuperlistaprecio == BoolCN.S ?
                    clienteInfo.SuperlistaPrecioClave.ToUpper() :
                    clienteInfo.ListaPrecioClave.ToUpper();

                precio = seleccionarPrecioXLista(listaPrecio,
                                               precio1, precio2, precio3, precio4, precio5,
                                                productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                productoInfo.Costopromedio, precio1);


                if (parametroInfo.Preciosordenados == BoolCN.S)
                {
                    forzarListaPrecio = true;
                }


                if (cantidad >= productoInfo.Limiteprecio2 && productoInfo.Limiteprecio2 > 1 &&
                    precio2 < precio && precio2 > 0)
                {
                    precio = precio2 ?? 0m;
                }

                if (productoInfo.Pzacaja > 1 && listaPrecio == "PRECIO 1" &&
                    cantidad >= productoInfo.U_empaque && productoInfo.U_empaque > 1 && parametroInfo.Cambiarprecioxuempaque == BoolCN.S)
                {


                    precio = seleccionarPrecioXLista((parametroInfo.Listaprecioxuempaque_clave ?? "PRECIO 2"),
                                                   precio1, precio2, precio3, precio4, precio5,
                                                    productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                    productoInfo.Costopromedio, precio2);

                    forzarListaPrecio = false;
                }

                if (productoInfo.Pzacaja > 1 && listaPrecio == "PRECIO 1" &&
                    cantidad >= productoInfo.Pzacaja && parametroInfo.Cambiarprecioxpzacaja == BoolCN.S)
                {
                    aplicarPrecioCaja = true;

                    precio = seleccionarPrecioXLista((parametroInfo.Listaprecioxpzacaja_clave ?? "PRECIO 3"),
                                                   precio1, precio2, precio3, precio4, precio5,
                                                    productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                    productoInfo.Costopromedio, precio3);

                    forzarListaPrecio = false;

                }

                if ((productoInfo.Unidad_clave ?? "").Trim() == "KG" &&
                    cantidad >= productoInfo.Ini_mayo && productoInfo.Mayokgs == BoolCN.S)
                {
                    aplicarPrecioCaja = true;

                    precio = seleccionarPrecioXLista((parametroInfo.Listaprecioinimayo_clave ?? "PRECIO 1"),
                                                   precio1, precio2, precio3, precio4, precio5,
                                                    productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                    productoInfo.Costopromedio, precio1);

                    forzarListaPrecio = false;

                }

                if (clienteInfo.Mayoreoxproducto == BoolCN.S)
                {
                    if (productoInfo.Cantmediomay > 0 && (productoInfo.Listaprecmediomayid ?? 0) > 0 &&
                       cantidad >= productoInfo.Cantmediomay && (productoInfo.Cantmayoreo == 0 || cantidad < productoInfo.Cantmayoreo))
                    {
                        listaPrecioXMayoreo = productoInfo.Listaprecmediomay_clave;
                    }
                    else if (productoInfo.Cantmayoreo > 0 && (productoInfo.Listaprecmayoreoid ?? 0) > 0 &&
                       cantidad >= productoInfo.Cantmayoreo)
                    {
                        listaPrecioXMayoreo = productoInfo.Listaprecmayoreo_clave;
                    }
                    else if ((productoInfo.Listaprecmayoreoid ?? 0) > 0 || (productoInfo.Listaprecmediomayid ?? 0) > 0 ||
                             productoInfo.Cantmediomay > 0 || productoInfo.Cantmayoreo > 0)
                    {
                        listaPrecioXMayoreo = "PRECIO 1";
                    }
                }

                precioListaCliente = seleccionarPrecioXLista((listaPrecioXMayoreo != "" ? listaPrecioXMayoreo : clienteInfo.ListaPrecioClave),
                                                   precio1, precio2, precio3, precio4, precio5,
                                                    productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                    productoInfo.Costopromedio, precio1);

                if (forzarListaPrecio && precio > precioListaCliente && precioListaCliente > 0)
                {
                    precio = precioListaCliente;
                }



                if (parametroInfo.Habdesclineapersona == BoolCN.S && descLineaPersonaInfo != null)
                {
                    decimal precioXLineaPersona = Math.Round(precio1!.Value * (100m - (descLineaPersonaInfo.Descuento / 100m)) / 100m, 2);
                    if (precioXLineaPersona < precio)
                        precio = precioXLineaPersona;
                }


                if(productoInfo.Linea_aplicamayoreoxlinea == BoolCS.S && (tipomayoreoid ?? 0) > 1)
                {
                    decimal precioMayLinea = seleccionarPrecioXLista(parametroInfo.Listapreciomaylinea_clave ?? "PRECIO 4",
                                                   precio1, precio2, precio3, precio4, precio5,
                                                    productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                    productoInfo.Costopromedio, precio4);

                    decimal precioMedMayLinea = seleccionarPrecioXLista(parametroInfo.Listapremedmaylinea_clave ?? "PRECIO 3",
                                                   precio1, precio2, precio3, precio4, precio5,
                                                    productoInfo.Precio6, productoInfo.Costorepo, productoInfo.Costoultimo,
                                                    productoInfo.Costopromedio, precio3);
                    if(tipomayoreoid == 2)
                    {
                        tipoMayoreoLineaIdAplicado = 2;
                        precio = precioMayLinea;
                    }
                    else if(tipomayoreoid == 3)
                    {
                        tipoMayoreoLineaIdAplicado = 3;
                        precio = precioMedMayLinea;
                    }

                }

                //pago con tarjeta
                var tiposPagosConTarjeta = new List<TipoPagoConTarjeta>() { TipoPagoConTarjeta.S, TipoPagoConTarjeta.D, TipoPagoConTarjeta.C };
                decimal comisionXTarjeta = 0m;
                bool pagocontarjeta = !(tipoPagoConTarjeta == null || tipoPagoConTarjeta.Value == TipoPagoConTarjeta.I || tipoPagoConTarjeta.Value == TipoPagoConTarjeta.N);
                if (pagocontarjeta == true && tipoPagoConTarjeta != null && tiposPagosConTarjeta.Contains(tipoPagoConTarjeta!.Value) )
                {
                    comisionXTarjeta = tipoPagoConTarjeta == TipoPagoConTarjeta.D ? parametroInfo.Comisiondebportarjeta : parametroInfo.Comisionportarjeta;
                    if(comisionXTarjeta > 0)
                    {

                        precio =  precio * ((100m + comisionXTarjeta) / 100m);

                        if ((tipoMayoreoLineaIdAplicado ?? 0) < 1)
                        {
                            if (parametroInfo.Pagotarjmenorpreciolistaall == BoolCN.S && precio > precioListaCliente)
                            {
                                precio = precioListaCliente;
                            }

                            if (aplicarPrecioCaja && productoInfo.Precio6 > 0)
                            {
                                precio = productoInfo.Precio6;
                            }
                        }
                    }
                }

                if(parametroInfo.Tipodescuentoprodid == 2 && productoInfo.Descuento > 0)
                {
                    precio = Math.Round(precio * (100m - (productoInfo.Descuento / 100m)) / 100m, 2);
                }



                habilitarPromocionBodegazo = productoInfo.Linea_aplicamayoreoxlinea == BoolCS.S && 
                                             pagocontarjeta != true && pagoacredito != true;

                decimal precioPromo = precio;

                GetPrecioPromo(
                             empresaId, sucursalId, 
                             productoId, clienteId, cantidad, precio1 ?? precio, precio,
                             habilitarPromocionBodegazo, comisionXTarjeta,
                             out precioPromo, out espromocion, out promocionid, out promociondesglose,
                             out decimal monederoAbono, localContext);

                if(precioPromo > 0m && precioPromo < precio && espromocion)
                    precio = precioPromo;



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


       private void GetPrecioPromo(
                              long empresaId, long sucursalId,
                              long productoId, long clienteId, decimal cantidad, decimal precio1, decimal precioPrevio, 
                              bool habilitarPromocionBodegazo, decimal comisionXTarjeta,
                              out decimal precioPromo, out bool espromocion, out long? promocionId, out string? promocionDesglose, 
                              out decimal monederoAbono, ApplicationDbContext localContext)
        {

            

            decimal precioActual = precioPrevio;

            precioPromo = precioPrevio;
            espromocion = false;
            promocionId = null;
            promocionDesglose = null;
            monederoAbono = 0;


            var productoInfo = localContext.Producto.AsNoTracking()
                                               .Include(p => p.Producto_precios)
                                               .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId)
                                               .Select(p => new
                                               {
                                                   Costorepo = p.Producto_precios == null ? 0m : p.Producto_precios.Costorepo,
                                                   p.Lineaid,
                                                   p.Ivaimpuesto,
                                                   p.Iepsimpuesto,
                                                   p.Impuesto


                                               })
                                               .FirstOrDefault();
            if (productoInfo == null)
                throw new Exception("El producto no esta registrado");



            var parametroInfo = localContext.Parametro.AsNoTracking()
                                                .Include(p => p.Monederolistaprecio)
                                               .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                               .Select(s => new
                                                           {
                                                               s.Monederolistaprecioid,
                                                               s.Monederocamporef

                                                           }
                                                   )
                                                   .FirstOrDefault();

            if (parametroInfo == null)
                throw new Exception("El parametro no esta registrado");



            var clienteInfo = localContext.Cliente.AsNoTracking()
                                                   .Include(c => c.Cliente_precio).ThenInclude(p => p!.Listaprecio)
                                                   .Where(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == clienteId)
                                                   .Select(c => new
                                                   {
                                                       Listaprecioid = c.Cliente_precio != null && c.Cliente_precio.Listaprecioid != null ? c.Cliente_precio.Listaprecioid : (long)1,
                                                       ListaPrecioClave = c.Cliente_precio != null && c.Cliente_precio.Listaprecio != null && c.Cliente_precio.Listaprecio.Clave != null ? c.Cliente_precio.Listaprecio.Clave : ""
                                                   })
                                                   .FirstOrDefault();

            if (clienteInfo == null)
                throw new Exception("El cliente no existe");


            var fechaActual = DateTimeOffset.Now.Date;
            int diaActual = (int)DateTime.Now.DayOfWeek;

            var promocionesAAplicar = localContext.Promocion.AsNoTracking()
                                                  .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                             (
                                                                (p.Rangopromocionid == 1 && p.Productoid == productoId) ||
                                                                (p.Rangopromocionid == 2 && p.Lineaid == productoInfo!.Lineaid) ||
                                                                (p.Tipopromocionid == 7 )
                                                             ) &&
                                                             (p.Tipopromocionid != 7 || habilitarPromocionBodegazo) &&
                                                             p.Fechainicio <= fechaActual && p.Fechafin >= fechaActual &&
                                                             p.Activo == BoolCS.S && p.Esmultidetalle != BoolCN.S &&
                                                             ((p.Lunes == BoolCS.S && diaActual == 1) ||
                                                              (p.Martes == BoolCS.S && diaActual == 2) ||
                                                              (p.Miercoles == BoolCS.S && diaActual == 3) ||
                                                              (p.Jueves == BoolCS.S && diaActual == 4) ||
                                                              (p.Viernes == BoolCS.S && diaActual == 5) ||
                                                              (p.Sabado == BoolCS.S && diaActual == 6) ||
                                                              (p.Domingo == BoolCS.S && diaActual == 0)) 

                                                          )
                                                  .Select(p => new {
                                                        p.EmpresaId,
                                                        p.SucursalId,
                                                        p.Id,
                                                        p.Cantidadllevate,
                                                        p.Cantidad,
                                                        p.Tipopromocionid,
                                                        p.Importe,
                                                        p.Porcentajedescuento,
                                                        p.Enmonedero
                                                  }).ToList();

            var productoImpuestoCalculado = Math.Round(
                                                                            (
                                                                                ((100m + productoInfo.Iepsimpuesto) / 100m) *
                                                                                ((100m + productoInfo.Ivaimpuesto) / 100m)
                                                                            ) * 100m, 2
                                                                          ) - 100m;

            foreach (var promocion in promocionesAAplicar)
            {
                if (promocion.Enmonedero == BoolCN.S && (parametroInfo.Monederolistaprecioid ?? 1) < (clienteInfo.Listaprecioid ?? 1))
                    continue;

                switch(promocion.Tipopromocionid)
                {
                    case 1:
                        {
                            if (    promocion.Cantidad != null && promocion.Cantidadllevate != null &&
                                    cantidad >= promocion.Cantidad && promocion.Cantidadllevate > 0)
                            {
                                decimal cantidadPromoPorAplicacion = promocion.Cantidadllevate!.Value - promocion.Cantidad!.Value;
                                decimal numAplicaciones = Math.Floor( cantidad / promocion.Cantidadllevate!.Value);
                                decimal aplicadosresiduales = cantidad - (promocion.Cantidadllevate!.Value * numAplicaciones) - promocion.Cantidad!.Value;
                                if (aplicadosresiduales < 0m)
                                    aplicadosresiduales = 0m;
                                decimal cantidadConPromo = (numAplicaciones * cantidadPromoPorAplicacion) + aplicadosresiduales;
                                decimal cantidadSinPromo = cantidad - cantidadConPromo;
                                decimal precioBuffer = (cantidadSinPromo * precio1) / cantidad;

                                precioBuffer = precioBuffer * ((100m + comisionXTarjeta) / 100m);
                                if(precioBuffer < precioActual)
                                {
                                    precioActual = precioBuffer;
                                    espromocion = true;
                                    promocionId= promocion.Id;
                                    monederoAbono = 0;
                                    promocionDesglose = "GRATIS " + cantidadConPromo.ToString() +
                                                        " Y CON PRECIO " + precio1.ToString() + " " +
                                                        cantidadSinPromo.ToString();
                                }

                            }

                        }
                        break;

                    case 2:
                        {
                            if( cantidad >= promocion.Cantidad &&
                                (promocion.Importe != null))
                            {
                                decimal precioBufferPromo = (promocion.Importe!.Value / ((100m + productoImpuestoCalculado) / 100m)) / promocion.Cantidad!.Value;

                                decimal numAplicaciones = Math.Floor(cantidad / promocion.Cantidad!.Value);
                                decimal cantidadConPromo = numAplicaciones * promocion.Cantidad!.Value;
                                decimal cantidadSinPromo = cantidad -  cantidadConPromo;
                                decimal precioBuffer = ((precioBufferPromo * cantidadConPromo) + (precio1 * cantidadSinPromo)) / cantidad;

                                precioBuffer = precioBuffer * ((100m + comisionXTarjeta) / 100m);
                                if (precioBuffer < precioActual)
                                {
                                    precioActual = precioBuffer;
                                    espromocion = true;
                                    promocionId = promocion.Id;
                                    monederoAbono = 0;
                                    promocionDesglose = "CON PRECIO " + precioBufferPromo.ToString() +
                                                        " " + cantidadConPromo.ToString() + 
                                                        " Y CON PRECIO " + precio1.ToString() +
                                                        " " + cantidadSinPromo.ToString();
                                }


                            }



                        }
                        break;

                    case 3:
                        {
                            decimal precioBuffer = (precio1 * cantidad * (1m - (promocion.Porcentajedescuento ?? 0m) / 100m)) / cantidad;
                            
                            precioBuffer = precioBuffer * ((100m + comisionXTarjeta ) / 100m);

                            if(precioBuffer < precioActual)
                            {
                                if(promocion.Enmonedero != BoolCN.S)
                                {

                                    precioActual = precioBuffer;
                                    espromocion = true;
                                    promocionId = promocion.Id;
                                    monederoAbono = 0;
                                    promocionDesglose = "CON DESCUENTO DE " + promocion.Porcentajedescuento.ToString() + "%";

                                }
                                else
                                {
                                    monederoAbono = (precio1 - precioBuffer) * cantidad;
                                    if((parametroInfo.Monederocamporef ?? "") == "TOTAL")
                                    {
                                        monederoAbono = Math.Round(monederoAbono * (1 + (productoInfo.Iepsimpuesto / 100m)) * (1 + (productoInfo.Ivaimpuesto / 100m)), 2);
                                    }
                                    espromocion = true;
                                    promocionId= promocion.Id;
                                    promocionDesglose = "APLICADO A MONEDERO : " + monederoAbono.ToString();

                                }
                            }

                        }
                        break;
                    case 6:
                        {
                            if(cantidad >= promocion.Cantidad && promocion.Importe != null)
                            {
                                decimal precioBufferPromo = (promocion.Importe!.Value / ((100m + productoImpuestoCalculado) / 100m)) / promocion.Cantidad!.Value;
                                decimal precioBuffer = precioBufferPromo;


                                precioBuffer = precioBuffer * ((100m + comisionXTarjeta) / 100m);
                                if (precioBuffer < precioActual)
                                {
                                    precioActual = precioBuffer;
                                    espromocion = true;
                                    promocionId = promocion.Id;
                                    monederoAbono = 0;
                                    promocionDesglose = "CON PRECIO " + precioBufferPromo.ToString() +
                                                        " " + promocion.Cantidad!.Value.ToString();
                                }

                            }

                        }
                        break;

                    case 7:
                        {
                            if (promocion.Porcentajedescuento == null)
                                continue;

                            decimal precioBuffer = precioActual;
                            if((1m - (promocion.Porcentajedescuento/100m)) > 0)
                            {
                                precioBuffer = productoInfo.Costorepo / (1m - (promocion.Porcentajedescuento!.Value / 100m));
                            }


                            precioBuffer = precioBuffer * ((100m + comisionXTarjeta) / 100m);
                            if (precioBuffer < precioActual)
                            {

                                if (promocion.Enmonedero != BoolCN.S)
                                {

                                    precioActual = precioBuffer;
                                    espromocion = true;
                                    promocionId = promocion.Id;
                                    monederoAbono = 0;
                                    promocionDesglose = "CON PRECIO " + precioBuffer.ToString();

                                }
                                else
                                {
                                    monederoAbono = (precio1 - precioBuffer) * cantidad;
                                    if ((parametroInfo.Monederocamporef ?? "") == "TOTAL")
                                    {
                                        monederoAbono = Math.Round(monederoAbono * (1 + (productoInfo.Iepsimpuesto / 100m)) * (1 + (productoInfo.Ivaimpuesto / 100m)), 2);
                                    }
                                    espromocion = true;
                                    promocionId = promocion.Id;
                                    promocionDesglose = "APLICADO A MONEDERO : " + monederoAbono.ToString();

                                }
                            }

                        }
                        break;

                    default:
                        break;
                }
            }

            precioPromo = precioActual;

            return ;
        }


        private decimal seleccionarPrecioXLista(string listaPrecio,
                                               decimal? precio1, decimal? precio2, decimal? precio3, decimal? precio4, decimal? precio5,
                                               decimal? precio6, decimal? costoRepo, decimal? costoUltimo, decimal? costoPromedio, decimal? precioDefault)
        {
            decimal precio = 0m;
            switch (listaPrecio)
            {
                case "PRECIO 1": precio = precio1 ?? (precioDefault ?? 0m); break;
                case "PRECIO 2": precio = precio2 ?? (precioDefault ?? 0m); break;
                case "PRECIO 3": precio = precio3 ?? (precioDefault ?? 0m); break;
                case "PRECIO 4": precio = precio4 ?? (precioDefault ?? 0m); break;
                case "PRECIO 5": precio = precio5 ?? (precioDefault ?? 0m); break;
                case "PRECIO 6": precio = precio6 ?? (precioDefault ?? 0m); break;
                case "COSTO REPOSICION": precio = costoRepo ?? (precioDefault ?? 0m); break;
                case "COSTO ULTIMO": precio = costoUltimo ?? (precioDefault ?? 0m); break;
                case "COSTO PROMEDIO": precio = costoPromedio ?? (precioDefault ?? 0m); break;
                default: precio =   (precioDefault ?? 0m); break;
            }
            return precio;
        }

    }


    public class Tmp_Movto_vendeduria
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
        public decimal Preciomanual { get; }
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

        public Tmp_Movto_vendeduria(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal preciomanual, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar)
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
            Preciomanual = preciomanual;
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
            return obj is Tmp_Movto_vendeduria other &&
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

    public class Tmp_Docto_vendeduria
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
        public long? Clienteid { get; }
        public string? Clienteclave { get; }
        public string? Clientenombre { get; }
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
        public DateTimeOffset? Fechahora { get; }
        public long? Origenfiscalid { get; }
        public string? Origenfiscalclave { get; }
        public string? Origenfiscalnombre { get; }

        public Tmp_Docto_vendeduria(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? clienteid, string? clienteclave, string? clientenombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, DateTimeOffset? fechahora, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre)
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
            Clienteid = clienteid;
            Clienteclave = clienteclave;
            Clientenombre = clientenombre;
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
            Fechahora = fechahora;
            Origenfiscalid = origenfiscalid;
            Origenfiscalclave = origenfiscalclave;
            Origenfiscalnombre = origenfiscalnombre;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_Docto_vendeduria other &&
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
                   Clienteid == other.Clienteid &&
                   Clienteclave == other.Clienteclave &&
                   Clientenombre == other.Clientenombre &&
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
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechahora, other.Fechahora) &&
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
            hash.Add(Clienteid);
            hash.Add(Clienteclave);
            hash.Add(Clientenombre);
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
            hash.Add(Fechahora);
            hash.Add(Origenfiscalid);
            hash.Add(Origenfiscalclave);
            hash.Add(Origenfiscalnombre);
            return hash.ToHashCode();
        }
    }

    public class Tmp_Precioprod_ref_vend
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public decimal PrecioLista { get; }
        public decimal PrecioTraspaso { get; }
        public decimal PrecioMinimo { get; }
        public decimal Costo { get; }




        public decimal Precio { get; }
        public bool Espromocion { get; }
        public long? Promocionid { get; }
        public string? Promociondesglose { get; }
        public decimal Monederoabono { get; }
        public long? TipoMayoreoLineaIdAplicado { get; }


        public Tmp_Precioprod_ref_vend(long empresaId, long sucursalId, decimal precioLista, decimal precioTraspaso, decimal precioMinimo, decimal costo,
                                        decimal precio, bool espromocion , long? promocionid, string? promociondesglose, 
                                        decimal monederoabono, long? tipoMayoreoLineaIdAplicado)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            PrecioLista = precioLista;
            PrecioTraspaso = precioTraspaso;
            PrecioMinimo = precioMinimo;
            Costo = costo;

            Precio = precio;
            Espromocion = espromocion;
            Promocionid = promocionid;
            Promociondesglose = promociondesglose;
            Monederoabono = monederoabono;
            TipoMayoreoLineaIdAplicado = tipoMayoreoLineaIdAplicado;
    }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_Precioprod_ref_vend other &&
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
