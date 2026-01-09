using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using IposV3.Services.Extensions;
using Microsoft.EntityFrameworkCore.Internal;

namespace IposV3.Services
{
    public class PedidoEntradaService
    {

        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private DoctoMovtoService _doctoMovtoService;
        private PagoService _pagoService;
        private ProveeduriaService _proveeduriaService;
        private VendeduriaService _vendeduriaService;
        private ProvDevoService _provdevoService;
        private CorteService _corteService;

        public PedidoEntradaService(
            DoctoService doctoService,
            MovtoService movtoService,
            DoctoMovtoService doctoMovtoService,
            PagoService pagoService,
            ProveeduriaService proveeduriaService,
            ProvDevoService provdevoService,
            VendeduriaService vendeduriaService,
            CorteService corteService)
        {
            _doctoService = doctoService;
            _movtoService = movtoService;
            _doctoMovtoService = doctoMovtoService;
            _pagoService = pagoService;
            _proveeduriaService = proveeduriaService;
            _provdevoService = provdevoService;
            _corteService = corteService;
            _vendeduriaService = vendeduriaService;
        }



        public List<Tmp_docto_pedido_entrada> Docto_pedido_entrada(long empresaId, long sucursalId,
                                                long? usuarioId, long tipoDoctoId, bool soloPendientes, long subTipoDoctoId,
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

                var usuarioId_ = usuarioId ?? 0;

                var lstDoctoProveeduria = localContext.Docto.AsNoTracking()
                                                      .Include(d => d.Estatusdocto)
                                                      .Include(d => d.Usuario)
                                                      .Include(d => d.Docto_compra)
                                                      .Include(d => d.Caja)
                                                      .Include(d => d.Proveedor)
                                                      .Include(d => d.Tipodocto)
                                                      .Include(d => d.Subtipodocto)
                                                      .Include(d => d.Docto_traslado).ThenInclude(dt => dt!.Sucursalt)
                                                      .Include(d => d.Origenfiscal)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&

                                                            (usuarioId_ == 0 || d.Usuarioid == usuarioId_) &&
                                                            (d.Tipodoctoid == tipoDoctoId) &&
                                                            (subTipoDoctoId == 0 || d.Subtipodoctoid == subTipoDoctoId) &&
                                                            (d.Estatusdoctoid == 0 || !soloPendientes) &&
                                                            (d.Fecha == null || (d.Fecha >= fechaIni && d.Fecha <= fechaFin))
                                                      )
                                                      .Select(d => new Tmp_docto_pedido_entrada(
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
                                                          d.Subtipodoctoid,
                                                          d.Subtipodocto == null ? null : d.Subtipodocto.Clave,
                                                          d.Subtipodocto == null ? null : d.Subtipodocto.Nombre,
                                                          d.Referencia,
                                                          d.Docto_traslado == null ? null : d.Docto_traslado.Sucursaltid,
                                                          d.Docto_traslado == null || d.Docto_traslado.Sucursalt == null ? null : d.Docto_traslado.Sucursalt.Clave,
                                                          d.Docto_traslado == null || d.Docto_traslado.Sucursalt == null ? null : d.Docto_traslado.Sucursalt.Nombre


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





        public List<Tmp_movto_pedido_entrada> Movto_pedido_entrada(long empresaId, long sucursalId, long doctoId, ApplicationDbContext localContext)
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
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Productocaracteristicas)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_existencia)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                      .Include(m => m.Producto).ThenInclude(p => p!.Unidad)
                                                      .Include(m => m.Movto_devolucion).ThenInclude(d => d!.Razondiferencia)
                                                      .Include(m => m.Movto_traslado).ThenInclude(d => d!.Motivodevolucion)
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


                                                          Cantidadfaltante = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidadfaltante,
                                                          Cantidaddevuelta = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidaddevuelta,
                                                          Cantidadsaldo = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidadsaldo


                                                      }).ToList()
                                                      .Select(m => new Tmp_movto_pedido_entrada(

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


                                                          m.Cantidadfaltante, //decimal
                                                          m.Cantidaddevuelta, //decimal
                                                          m.Cantidadsaldo



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


        public void Docto_pedido_entrada_insert(DoctoPedidoEntradaTrans doctoPedidoEntradaTrans, ref long? doctoId, ApplicationDbContext localContext)
        {
            _proveeduriaService.Docto_prov_insert(doctoPedidoEntradaTrans, ref doctoId, localContext);


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
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

        public void Movto_pedido_entrada_insert(MovtoPedidoEntradaTrans movtoPedidoEntradaTrans, ref long? movtoId,
            ApplicationDbContext localContext)
        {

            _proveeduriaService.Movto_prov_insert(movtoPedidoEntradaTrans, ref movtoId, localContext);


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .FirstOrDefault(m => m.EmpresaId == movtoPedidoEntradaTrans.Empresaid && m.SucursalId == movtoPedidoEntradaTrans.Sucursalid && m.Id == movtoPedidoEntradaTrans.Id);
                if(movtoInfo != null)
                {

                    movtoPedidoEntradaTrans.Cantidadsurtida = movtoInfo.Cantidad;

                    Movto_pedido_entrada_ponercantidadsurtida(movtoPedidoEntradaTrans, localContext);
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

        public void Movto_pedido_entrada_ponercantidadsurtida(MovtoPedidoEntradaTrans movtoPedidoEntradaTrans, 
            ApplicationDbContext localContext, bool saveChangesImmediately = true)
        {
            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var movtoDevolucion = localContext.Movto_devolucion
                                    .FirstOrDefault(m => m.EmpresaId == movtoPedidoEntradaTrans.Empresaid && m.SucursalId == movtoPedidoEntradaTrans.Sucursalid && m.Movtoid == movtoPedidoEntradaTrans.Id);

                if (movtoDevolucion == null)
                {

                    movtoDevolucion = new Movto_devolucion()
                    {

                        EmpresaId = movtoPedidoEntradaTrans.Empresaid,
                        SucursalId = movtoPedidoEntradaTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = movtoPedidoEntradaTrans.Usuarioid,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = movtoPedidoEntradaTrans.Usuarioid,
                        Movtoid = movtoPedidoEntradaTrans.Id,
                        Movtorefid = null,
                        Cantidadsurtida = movtoPedidoEntradaTrans.Cantidadsurtida,
                        Cantidadfaltante = movtoPedidoEntradaTrans.Cantidad - movtoPedidoEntradaTrans.Cantidadsurtida,
                        Cantidaddevuelta = movtoPedidoEntradaTrans.Cantidad - movtoPedidoEntradaTrans.Cantidadsurtida,
                        Cantidadsaldo = movtoPedidoEntradaTrans.Cantidad - movtoPedidoEntradaTrans.Cantidadsurtida,
                        Razondiferenciaid = null,
                        Otrarazondiferencia = null

                    };
                    localContext.Add(movtoDevolucion);
                }
                else
                {

                    movtoDevolucion!.Cantidadsurtida = movtoPedidoEntradaTrans.Cantidadsurtida;
                    movtoDevolucion!.Cantidadfaltante = movtoPedidoEntradaTrans.Cantidad - movtoPedidoEntradaTrans.Cantidadsurtida;
                    movtoDevolucion!.Cantidaddevuelta = movtoPedidoEntradaTrans.Cantidad - movtoPedidoEntradaTrans.Cantidadsurtida;
                    movtoDevolucion!.Cantidadsaldo = movtoPedidoEntradaTrans.Cantidad - movtoPedidoEntradaTrans.Cantidadsurtida;
                    localContext.Update(movtoDevolucion);

                }

                if(saveChangesImmediately)
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


        public void Movto_pedido_entrada_ajustarExistencias(long empresaId, long sucursalId, long id, long usuarioId,
            long? almacenId, 
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoInfo = localContext.Docto.AsNoTracking()
                    .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id)
                    .FirstOrDefault();


                var lstMovtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto)
                                            .Include(d => d.Producto).ThenInclude(p => p!.Producto_inventario)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == id && 
                                                        d.Producto != null && d.Producto.Producto_inventario != null && 
                                                        d.Producto.Producto_inventario.Inventariable == BoolCS.S)

                                            .Select(m => new
                                            {

                                                m.EmpresaId,
                                                m.SucursalId,
                                                m.Id,
                                                m.Productoid,
                                                m.Cantidad,
                                                Inventariable = m.Producto != null && m.Producto.Producto_inventario != null ?
                                                                m.Producto.Producto_inventario.Inventariable : BoolCS.N

                                            })
                                            .ToList();



                var lstMovtoInfoExistencias = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto)
                                            .Include(d => d.Producto).ThenInclude(p => p!.Producto_inventario)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == id )
                                            .Join(localContext.Inventario.AsNoTracking(),
    movto => new                     
    {
        movto.EmpresaId,
        movto.SucursalId,
        movto.Productoid,
        Almacenid = almacenId, //movto.Docto != null ? movto.Docto.Almacenid : 0,
        Esapartado = BoolCN.N
    },
    inv => new                 
    {
        inv.EmpresaId,
        inv.SucursalId,
        inv.Productoid,
        inv.Almacenid,
        inv.Esapartado
    },
    (movto, inv) => new {
        movto.EmpresaId,
        movto.SucursalId,
        movto.Id,
        movto.Productoid,
        movto.Cantidad,
        Almacenid = almacenId,//movto.Docto != null ? movto.Docto.Almacenid : 0,
        Inventariable = movto.Producto != null && movto.Producto.Producto_inventario != null ? movto.Producto.Producto_inventario.Inventariable : BoolCS.N,
        CantidadInventario = inv.Cantidad,
        inv.Esapartado
    })
                                            .GroupBy(mainQry => new {
                                                mainQry.EmpresaId,
                                                mainQry.SucursalId,
                                                mainQry.Id,
                                                mainQry.Productoid,
                                                mainQry.Cantidad,
                                                mainQry.Inventariable
                                            })
                                            .Select(mainQryGroup => new
                                            {

                                                mainQryGroup.Key.EmpresaId,
                                                mainQryGroup.Key.SucursalId,
                                                mainQryGroup.Key.Id,
                                                mainQryGroup.Key.Productoid,
                                                mainQryGroup.Key.Cantidad,
                                                mainQryGroup.Key.Inventariable,
                                                CantidadInventario = mainQryGroup.Sum(m => m.CantidadInventario)

                                            })
                                            .ToList();




                foreach(var movtoInfo in lstMovtoInfo)
                {
                    var movtoInfoExistencias = lstMovtoInfoExistencias.FirstOrDefault(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId &&
                                                                                             y.Id == movtoInfo.Id);                           
                    var cantidadSurtida = movtoInfo.Cantidad < (movtoInfoExistencias?.CantidadInventario ?? 0m) ||
                                          movtoInfo.Inventariable == BoolCS.N ?
                                               movtoInfo.Cantidad : (movtoInfoExistencias?.CantidadInventario ?? 0m);


                    var movtoPedidoEntradaTrans = new MovtoPedidoEntradaTrans();
                    movtoPedidoEntradaTrans.Empresaid = movtoInfo.EmpresaId;
                    movtoPedidoEntradaTrans.Sucursalid = movtoInfo.SucursalId;

                    movtoPedidoEntradaTrans.Usuarioid = usuarioId;

                    movtoPedidoEntradaTrans.Id = movtoInfo.Id;
                    movtoPedidoEntradaTrans.Productoid = movtoInfo.Productoid ?? 0;
                    movtoPedidoEntradaTrans.Cantidad = movtoInfo.Cantidad;
                    movtoPedidoEntradaTrans.Cantidadsurtida = cantidadSurtida ;

                    Movto_pedido_entrada_ponercantidadsurtida(movtoPedidoEntradaTrans, localContext, false);





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

        public void Docto_pedido_entrada_save(long empresaId, long sucursalId, long id, long estatusDoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                _proveeduriaService.Docto_prov_update_estatus(empresaId, sucursalId, id, estatusDoctoId, localContext);

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



        public void Docto_surtir_pedido(long empresaId, long sucursalId, long doctoASurtirId, long? usuarioId,
                                        long? almacenId, string? referencias,
                                        ref long? doctoSurtidoId,
                                             ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoASurtirInfo = localContext.Docto.AsNoTracking()
                                            .Include(m => m.Docto_devolucion)
                                            .Include(m => m.Docto_traslado)
                                            .Include(m => m.Docto_compra)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == doctoASurtirId)
                                            .FirstOrDefault();

                if (doctoASurtirInfo == null)
                    throw new Exception("Docto no encontrado");

                if (doctoASurtirInfo.Tipodoctoid != DBValues._DOCTO_TIPO_TRASPASO_ENVIO_BORRADOR)
                    throw new Exception("Docto no es del tipo adecuado");

                if (doctoASurtirInfo.Estatusdoctoid != DBValues._DOCTO_ESTATUS_BORRADOR)
                    throw new Exception("Docto no es borrador");


                var usuarioId_ = usuarioId ?? (doctoASurtirInfo!.Usuarioid ?? 0);

                var docto = localContext.Docto
                                            .Single(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == doctoASurtirId);
                docto.Almacenid = almacenId;
                docto.Referencias = referencias;
                localContext.Update(docto);
                localContext.SaveChanges();

                _proveeduriaService.Docto_prov_save(empresaId, sucursalId, doctoASurtirId, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);


                var cuentaMovtosConSurtidos = localContext.Movto.AsNoTracking()
                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoASurtirId &&
                                                         m.Movto_devolucion != null && m.Movto_devolucion.Cantidadsurtida > 0)
                                    .Count();

                if (cuentaMovtosConSurtidos > 0)
                {
                    Docto_generar_traslado(empresaId, sucursalId, doctoASurtirId, usuarioId_, ref doctoSurtidoId,
                                             localContext);
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

        
        public void Movto_generar_traslado(long empresaId, long sucursalId, long movtoASurtirId, ref long? movtoSurtidoId, long? usuarioId,
                                            long doctoSurtidoId, ApplicationDbContext localContext)
        {
            movtoSurtidoId = null;

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var movtoItem = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Movto_surtido)
                                            .Include(m => m.Movto_comodin)
                                            .Include(m => m.Docto)
                                            .Include(m => m.Movto_traslado)
                                            .Include(m => m.Movto_devolucion)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && 
                                                        m.Id == movtoASurtirId && m.Movto_devolucion != null &&
                                                        m.Movto_devolucion.Cantidadsurtida > 0)
                                            .FirstOrDefault();

                if (movtoItem == null)
                    throw new Exception("Movto no encontrado");

                var usuarioId_ = usuarioId ?? (movtoItem.Docto!.Usuarioid ?? 0);

                var paramTraslado = new MovtoVendTrans();

                paramTraslado.Fechavence = movtoItem.Fechavence;
                paramTraslado.Loteimportado = movtoItem.Loteimportado;
                paramTraslado.Movtoparentid = null;
                paramTraslado.Agrupaporparametro = BoolCN.N;
                paramTraslado.Cargartarjetapreciomanual = BoolCN.N;
                paramTraslado.Precioyavalidado = BoolCN.S;
                paramTraslado.Usuarioid = usuarioId_;

                paramTraslado.Lote = movtoItem.Lote;
                paramTraslado.Localidad = null;//movtoItem.Localidad;
                paramTraslado.Descripcion1 = movtoItem.Movto_comodin?.Descripcion1;
                paramTraslado.Descripcion2 = movtoItem.Movto_comodin?.Descripcion2;
                paramTraslado.Descripcion3 = movtoItem.Movto_comodin?.Descripcion3;
                paramTraslado.Empresaid = movtoItem.EmpresaId;
                paramTraslado.Sucursalid = movtoItem.SucursalId;
                //paramTraslado.m = movtoItem.Id;
                //paramTraslado.Id = movtoItem.Movtoid;
                paramTraslado.Doctoid = doctoSurtidoId;
                paramTraslado.Partida = movtoItem.Partida;
                paramTraslado.Estatusmovtoid = Model.DBValues._MOVTO_ESTATUS_BORRADOR;
                paramTraslado.Productoid = movtoItem.Productoid!.Value;

                paramTraslado.Precio = movtoItem.Precio;
                paramTraslado.Cantidad = movtoItem.Movto_devolucion?.Cantidadsurtida ?? 0m;

                paramTraslado.Preciomanual = null;




                movtoSurtidoId = null;
                _vendeduriaService.Movto_vend_insert(paramTraslado, ref movtoSurtidoId, localContext);

                localContext.SaveChanges();

                long? movtoSurtidoId_ = movtoSurtidoId;

                var movtoTraslado = localContext.Movto_traslado
                                    .FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Movtoid == movtoSurtidoId_);

                if (movtoTraslado == null)
                {

                    movtoTraslado = new Movto_traslado()
                    {

                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = usuarioId_,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = usuarioId_,
                        Movtoid = movtoSurtidoId,
                        Preciovisibletraslado = movtoItem.Movto_traslado?.Preciovisibletraslado ?? 0m,
                        Motivodevolucionid = null,
                        Otromotivodevolucion = null

                    };
                    localContext.Add(movtoTraslado);
                }
                else
                {

                    movtoTraslado.Preciovisibletraslado = movtoItem.Movto_traslado?.Preciovisibletraslado ?? 0m;
                    movtoTraslado.Motivodevolucionid = null;
                    movtoTraslado.Otromotivodevolucion = null;
                    localContext.Update(movtoTraslado);

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


        public void Docto_generar_traslado(long empresaId, long sucursalId, long doctoASurtirId, long? usuarioId, ref long? doctoSurtidoId,
                                             ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            doctoSurtidoId = null;

            try
            {

                var doctoASurtir = localContext.Docto.AsNoTracking()
                                            .Include(m => m.Docto_surtido)
                                            .Include(m => m.Docto_traslado)
                                            .Include(m => m.Docto_compra)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == doctoASurtirId)
                                            .FirstOrDefault();

                if (doctoASurtir == null)
                    throw new Exception("Docto no encontrado");

                var usuarioId_ = usuarioId ?? (doctoASurtir!.Usuarioid ?? 0);


                var doctoTrasladoParam = new DoctoVendTrans();

                doctoTrasladoParam.Referencia = doctoASurtir.Referencia;
                doctoTrasladoParam.Referencias = doctoASurtir.Referencias;
                doctoTrasladoParam.Fechavence = doctoASurtir.Fechavence;
                doctoTrasladoParam.Empresaid = doctoASurtir.EmpresaId;
                doctoTrasladoParam.Sucursalid = doctoASurtir.SucursalId;
                doctoTrasladoParam.Estatusdoctoid = doctoASurtir.Estatusdoctoid!.Value;
                doctoTrasladoParam.Usuarioid = doctoASurtir.Usuarioid!.Value;


                doctoTrasladoParam.Creadopor_userid = doctoASurtir.Usuarioid!.Value;
                doctoTrasladoParam.Fecha = doctoASurtir.Fecha!.Value;
                doctoTrasladoParam.Cajaid = doctoASurtir.Cajaid!.Value;
                doctoTrasladoParam.Almacenid = doctoASurtir.Almacenid!.Value;
                doctoTrasladoParam.Origenfiscalid = doctoASurtir.Origenfiscalid!.Value;
                doctoTrasladoParam.Doctoparentid = doctoASurtir.Doctoparentid;
                //doctoTrasladoParam.Proveedorid = doctoASurtir.Proveedorid;
                doctoTrasladoParam.Tipodoctoid = DBValues._DOCTO_TIPO_VENTA;
                doctoTrasladoParam.Sucursal_id = doctoASurtir.Sucursal_id!.Value;
                doctoTrasladoParam.Sucursaltid =  doctoASurtir.Docto_traslado?.Sucursaltid;
                doctoTrasladoParam.Almacentid = doctoASurtir.Docto_traslado?.Almacentid;
                //doctoTrasladoParam.Doctoadevolverid = doctoASurtirId;


                doctoSurtidoId = null;
                _vendeduriaService.Docto_vend_insert(doctoTrasladoParam, ref doctoSurtidoId, localContext);

                localContext.SaveChanges();

                long? doctoSurtidoId_ = doctoSurtidoId;

                var doctoTraslado = localContext.Docto_traslado
                                    .FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoSurtidoId_);

                if (doctoTraslado == null)
                {

                    doctoTraslado = new Docto_traslado()
                    {

                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = usuarioId_,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = usuarioId_,
                        Doctoid = doctoSurtidoId,


                        Doctoimportadoid = null,
                        Foliosolicitudmercancia = doctoASurtir.Docto_traslado?.Foliosolicitudmercancia,
                        Foliotrasladooriginal = doctoASurtir.Docto_traslado?.Foliotrasladooriginal,
                        Estraslado = BoolCN.S,
                        Esdevolucion = BoolCN.N,
                        Foliodevolucion = null,
                        Essurtimientomerca = "N",
                        Idsolicitudmercancia = doctoASurtir.Docto_traslado?.Idsolicitudmercancia,
                        Idtrasladooriginal = doctoASurtir.Docto_traslado?.Idtrasladooriginal,
                        Iddevolucion = null

                    };
                    localContext.Add(doctoTraslado);
                }
                else
                {


                    doctoTraslado.Doctoimportadoid = null;
                    doctoTraslado.Foliosolicitudmercancia = doctoASurtir.Docto_traslado?.Foliosolicitudmercancia;
                    doctoTraslado.Foliotrasladooriginal = doctoASurtir.Docto_traslado?.Foliotrasladooriginal;
                    doctoTraslado.Estraslado = BoolCN.S;
                    doctoTraslado.Esdevolucion = BoolCN.N;
                    doctoTraslado.Foliodevolucion = null;
                    doctoTraslado.Essurtimientomerca = "N";
                    doctoTraslado.Idsolicitudmercancia = doctoASurtir.Docto_traslado?.Idsolicitudmercancia;
                    doctoTraslado.Idtrasladooriginal = doctoASurtir.Docto_traslado?.Idtrasladooriginal;
                    doctoTraslado.Iddevolucion = null;


                    localContext.Update(doctoTraslado);

                }

                localContext.SaveChanges();


                var movtosASurtir = localContext.Movto.AsNoTracking()
                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoASurtirId &&
                                                         m.Movto_devolucion != null && m.Movto_devolucion.Cantidadsurtida > 0)
                                    .Select(m => m.Id)
                                    .ToList();

                foreach (var movtoASurtir in movtosASurtir)
                {
                    long? movtoSurtidoId = null;
                    Movto_generar_traslado(empresaId, sucursalId, movtoASurtir, ref movtoSurtidoId, usuarioId_,
                                                doctoSurtidoId!.Value, localContext);

                }


                localContext.SaveChanges();

                _vendeduriaService.Docto_vend_save(empresaId, sucursalId, doctoSurtidoId!.Value, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);


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


        public void Movto_pedido_entrada_ajustarPrecios(long empresaId, long sucursalId, long id, long usuarioId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoInfo = localContext.Docto.AsNoTracking()
                    .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id)
                    .FirstOrDefault();


                var lstMovtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto).ThenInclude(d => d!.Docto_traslado).ThenInclude(dt => dt!.Sucursalt).ThenInclude(s => s!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_traslado)
                                            .Include(m => m.Docto).ThenInclude(d => d!.Sucursal_info).ThenInclude(s => s!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_traslado)
                                            .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios)
                                            .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == id)
                                            .GroupBy(m => new
                                            {

                                                m.EmpresaId,
                                                m.SucursalId,
                                                m.Id,
                                                PrecioListaSugerido =

                                                                   (
                                                                    (m.Docto != null && m.Docto.Docto_traslado != null && m.Docto.Docto_traslado.Sucursalt != null &&
                                                                       m.Docto.Docto_traslado.Sucursalt != null && m.Docto.Docto_traslado.Sucursalt.Sucursal_info_opciones != null &&
                                                                       m.Docto.Docto_traslado.Sucursalt.Sucursal_info_opciones.Sucursal_traslado != null &&
                                                                       m.Docto.Docto_traslado.Sucursalt.Sucursal_info_opciones.Sucursal_traslado!.Precioenviotraslado != null) ?
                                                                       m.Docto.Docto_traslado.Sucursalt.Sucursal_info_opciones.Sucursal_traslado!.Precioenviotraslado!.Value :
                                                                    (
                                                                    (m.Docto != null && m.Docto.Sucursal_info != null &&
                                                                       m.Docto.Sucursal_info != null && m.Docto.Sucursal_info.Sucursal_info_opciones != null &&
                                                                       m.Docto.Sucursal_info.Sucursal_info_opciones.Sucursal_traslado != null &&
                                                                       m.Docto.Sucursal_info.Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado != null) ?
                                                                        m.Docto.Sucursal_info.Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado!.Value :
                                                                        3
                                                                    )
                                                                )

                                            })
                                            .Select(g => new
                                            {
                                                g.Key.EmpresaId,
                                                g.Key.SucursalId,
                                                g.Key.Id,
                                                g.Key.PrecioListaSugerido,
                                                PrecioSugerido = (g.Key.PrecioListaSugerido == 1 && g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio1 :
                                                                  (g.Key.PrecioListaSugerido == 2 && g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio2 :
                                                                  (g.Key.PrecioListaSugerido == 3 && g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio3 :
                                                                  (g.Key.PrecioListaSugerido == 4 && g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio4 :
                                                                  (g.Key.PrecioListaSugerido == 5 && g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio5 :
                                                                  (g.Key.PrecioListaSugerido == 6 && g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio6 :
                                                                  (g.First().Producto != null &&
                                                                  g.First().Producto!.Producto_precios != null) ? g.First().Producto!.Producto_precios!.Precio3 :
                                                                  0m
                                            })
                                            .ToList();




                foreach (var movtoInfo in lstMovtoInfo)
                {



                    var movto = localContext.Movto
                                        .FirstOrDefault(m => m.EmpresaId == movtoInfo.EmpresaId && 
                                                             m.SucursalId == movtoInfo.SucursalId && 
                                                             m.Id == movtoInfo.Id);

                    if(movto == null)
                        throw new Exception("El movto es null");

                    movto.Precio = movtoInfo.PrecioSugerido;
                    movto.Preciolista = movtoInfo.PrecioSugerido;

                    localContext.Update(movto);
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




    }



    public class Tmp_docto_pedido_entrada : TransitionClass
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

        public long? Subtipodoctoid { get; }
        public string? Subtipodoctoclave { get; }
        public string? Subtipodoctonombre { get; }

        public long? Sucursaltid { get; }
        public string? Sucursaltclave { get; }
        public string? Sucursaltnombre { get; }


        public Tmp_docto_pedido_entrada()
        {

        }
        public Tmp_docto_pedido_entrada(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre,
            long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, long? subtipodoctoid, string? subtipodoctoclave, string? subtipodoctonombre,
            string? referencia, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre
            )
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
            Subtipodoctoid = subtipodoctoid;
            Subtipodoctoclave = subtipodoctoclave;
            Subtipodoctonombre = subtipodoctonombre;
            Referencia = referencia;
            Sucursaltid = sucursaltid;
            Sucursaltclave = sucursaltclave;
            Sucursaltnombre = sucursaltnombre;


        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_docto_pedido_entrada other &&
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
                   Subtipodoctoid == other.Subtipodoctoid &&
                   Subtipodoctoclave == other.Subtipodoctoclave &&
                   Subtipodoctonombre == other.Subtipodoctonombre &&
                   Referencia == other.Referencia &&
                   Sucursaltid == other.Sucursaltid &&
                   Sucursaltclave == other.Sucursaltclave &&
                   Sucursaltnombre == other.Sucursaltnombre;
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
            hash.Add(Subtipodoctoid);
            hash.Add(Subtipodoctoclave);
            hash.Add(Subtipodoctonombre);
            hash.Add(Referencia);
            hash.Add(Sucursaltid);
            hash.Add(Sucursaltclave);
            hash.Add(Sucursaltnombre);
            return hash.ToHashCode();
        }
    }



    public class Tmp_movto_pedido_entrada : TransitionClass
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
        public string? Alerta3 { get; }
        public decimal Preciomostrar { get; }
        public decimal Descuentomostrar { get; }


        public decimal Cantidadfaltante { get; }
        public decimal Cantidaddevuelta { get; }
        public decimal Cantidadsaldo { get; }

        public Tmp_movto_pedido_entrada()
        {

        }
        public Tmp_movto_pedido_entrada(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar,
                                        decimal cantidadfaltante, decimal cantidaddevuelta, decimal cantidadsaldo)
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



            Cantidadfaltante = cantidadfaltante;
            Cantidaddevuelta = cantidaddevuelta;
            Cantidadsaldo = cantidadsaldo;

        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_movto_pedido_entrada other &&
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




}
