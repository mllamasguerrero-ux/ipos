using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using IposV3.Services.Extensions;
using NpgsqlTypes;

namespace IposV3.Services
{
    public class TrasladoRecepcionService
    {

        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private DoctoMovtoService _doctoMovtoService;
        private PagoService _pagoService;
        private ProveeduriaService _proveeduriaService;
        private ProvDevoService _provdevoService;
        private CorteService _corteService;

        public TrasladoRecepcionService(
            DoctoService doctoService,
            MovtoService movtoService,
            DoctoMovtoService doctoMovtoService,
            PagoService pagoService,
            ProveeduriaService proveeduriaService,
            ProvDevoService provdevoService,
            CorteService corteService)
        {
            _doctoService = doctoService;
            _movtoService = movtoService;
            _doctoMovtoService = doctoMovtoService;
            _pagoService = pagoService;
            _proveeduriaService = proveeduriaService;
            _provdevoService = provdevoService;
            _corteService = corteService;
        }


        public List<Tmp_docto_traslado_recepcion> Docto_traslados_recibidos(long empresaId, long sucursalId,
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

                var usuarioId_ = usuarioId ?? 0;

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
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                            (usuarioId_ == 0 || d.Usuarioid == usuarioId_) &&
                                                            (d.Tipodoctoid == tipoDoctoId) &&
                                                            (d.Tipodoctoid != DBValues._DOCTO_TIPO_COMPRA || d.Subtipodoctoid == 6 || d.Subtipodoctoid == 16 || d.Subtipodoctoid == 23 ) &&
                                                            (d.Estatusdoctoid == estatusDoctoId) &&
                                                            (d.Fecha == null || (d.Fecha >= fechaIni && d.Fecha <= fechaFin))
                                                      )
                                                      .Select(d => new Tmp_docto_traslado_recepcion(
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
                                                          d.Docto_compra == null ? null : d.Fechavence,
                                                          d.Origenfiscalid,
                                                          d.Origenfiscal == null ? null : d.Origenfiscal.Clave,
                                                          d.Origenfiscal == null ? null : d.Origenfiscal.Nombre,


                                                         //BoolCN ? estraslado, BoolCN ? esdevolucion, string ? foliodevolucion, BoolCN ? essurtimientomerca, string ? foliosolicitudmercancia, string ? foliotrasladooriginal, long ? idsolicitudmercancia, long ? idtrasladooriginal, long ? iddevolucion
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Estraslado, //BoolCN? Estraslado
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Esdevolucion, //BoolCN? Estraslado
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Foliodevolucion, //string? Foliodevolucion
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Essurtimientomerca, //BoolCN? Estraslado
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Foliosolicitudmercancia,//string? Foliosolicitudmercancia
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Foliotrasladooriginal,//string? Foliotrasladooriginal
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Idsolicitudmercancia,//long? Idsolicitudmercancia
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Idtrasladooriginal,//long? Idtrasladooriginal
                                                         d.Docto_traslado == null ? null : d.Docto_traslado.Iddevolucion//long? Iddevolucion



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



        public List<Tmp_movto_traslado_recepcion> Movto_traslados_recibidos(long empresaId, long sucursalId, long doctoId, ApplicationDbContext localContext)
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
                                                          Cantidadsaldo = m.Movto_devolucion == null ? 0m : m.Movto_devolucion.Cantidadsaldo,
                                                          Razondiferenciaid = m.Movto_devolucion == null ? 0 : m.Movto_devolucion.Razondiferenciaid,
                                                          Razondiferenciaclave = m.Movto_devolucion == null || m.Movto_devolucion.Razondiferencia == null ? null : m.Movto_devolucion.Razondiferencia!.Clave,
                                                          Razondiferencianombre = m.Movto_devolucion == null ? null : (m.Movto_devolucion.Razondiferencia!.Clave == "OTROMOT" ? m.Movto_devolucion.Otrarazondiferencia : m.Movto_devolucion.Razondiferencia!.Nombre),
                                                          Motivodevolucionid = m.Movto_traslado == null ? null : m.Movto_traslado.Motivodevolucionid,
                                                          Motivodevolucionclave = m.Movto_traslado == null || m.Movto_traslado.Motivodevolucion == null ? null : m.Movto_traslado.Motivodevolucion!.Clave,
                                                          Motivodevolucionnombre = m.Movto_traslado == null || m.Movto_traslado.Motivodevolucion == null ? null : m.Movto_traslado.Motivodevolucion!.Nombre,
                                                          Motivodevoluciondescripcion = m.Movto_traslado == null || m.Movto_traslado.Motivodevolucion == null ? null : m.Movto_traslado.Motivodevolucion!.Descripcion,
                                                          Otromotivodevolucion = m.Movto_traslado == null ? null : m.Movto_traslado.Otromotivodevolucion


                                                      }).ToList()
                                                      .Select(m => new Tmp_movto_traslado_recepcion(

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
                                                          m.Cantidadsaldo, //decimal
                                                          m.Razondiferenciaid, //long?
                                                          m.Razondiferenciaclave, //string?
                                                          m.Razondiferencianombre, //string?
                                                          m.Motivodevolucionid, //long?
                                                          m.Motivodevolucionclave, //string?
                                                          m.Motivodevolucionnombre, //string?
                                                          m.Motivodevoluciondescripcion, //string?
                                                          m.Otromotivodevolucion //string?



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



        public void Movto_recibir_traslado(Recepcion_movto_traslado_impo movto_traslado_impo, long? usuarioId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            movto_traslado_impo.Cantidadfaltante = movto_traslado_impo.Cantidad - movto_traslado_impo.Cantidadsurtida;

            try
            {

                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Producto).ThenInclude(m => m!.Producto_inventario)
                                            .Include(m => m.Producto).ThenInclude(m => m!.Producto_loteimportado)
                                            .Where(m => m.EmpresaId == movto_traslado_impo.EmpresaId && m.SucursalId == movto_traslado_impo.SucursalId && m.Id == movto_traslado_impo.Id)
                                            .Select(m => new {
                                                m.Lote, m.Fechavence, m.Loteimportado, m.Precio,
                                                ManejaLote = (m.Producto != null && m.Producto.Producto_inventario != null ? m.Producto.Producto_inventario.Manejalote : BoolCN.N),
                                                Manejaloteimportado = (m.Producto != null && m.Producto.Producto_loteimportado != null ? m.Producto.Producto_loteimportado.Manejaloteimportado : BoolCN.N),
                                            })
                                            .FirstOrDefault();

                if (movtoInfo == null)
                    throw new Exception("Movto no encontrado");

                var movto = localContext.Movto
                                        .First(m => m.EmpresaId == movto_traslado_impo.EmpresaId && m.SucursalId == movto_traslado_impo.SucursalId && m.Id == movto_traslado_impo.Id);

                if (movtoInfo.ManejaLote == BoolCN.S )
                {
                    movto.Lote = movto_traslado_impo.Lote;
                    movto.Fechavence = movto_traslado_impo.Fechavence;
                }

                if (movtoInfo.Manejaloteimportado == BoolCN.S)
                {
                    movto.Loteimportado = movto_traslado_impo.Loteimportado;
                }
                localContext.Update(movto);
                localContext.SaveChanges();


                if(movto_traslado_impo.Cantidadfaltante > 0 )
                {
                    var movtoDevolucion = localContext.Movto_devolucion
                                        .FirstOrDefault(m => m.EmpresaId == movto_traslado_impo.EmpresaId && m.SucursalId == movto_traslado_impo.SucursalId && m.Movtoid == movto_traslado_impo.Id);

                    if(movtoDevolucion == null )
                    {

                        movtoDevolucion = new Movto_devolucion()
                        {

                            EmpresaId = movto_traslado_impo.EmpresaId,
                            SucursalId = movto_traslado_impo.SucursalId,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = usuarioId,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = usuarioId,
                            Movtoid = movto_traslado_impo.Id,
                            Movtorefid = null,
                            Cantidadsurtida = movto_traslado_impo.Cantidadsurtida,
                            Cantidadfaltante = movto_traslado_impo.Cantidadfaltante,
                            Cantidaddevuelta = movto_traslado_impo.Cantidadfaltante,
                            Cantidadsaldo = movto_traslado_impo.Cantidadfaltante,
                            Razondiferenciaid = null,
                            Otrarazondiferencia = null

                        };
                        localContext.Add(movtoDevolucion);
                    }
                    else
                    {

                        movtoDevolucion!.Cantidadsurtida = movto_traslado_impo.Cantidadsurtida;
                        movtoDevolucion!.Cantidadfaltante = movto_traslado_impo.Cantidadfaltante;
                        movtoDevolucion!.Cantidaddevuelta = movto_traslado_impo.Cantidadfaltante;
                        movtoDevolucion!.Cantidadsaldo = movto_traslado_impo.Cantidadfaltante;
                        localContext.Update(movtoDevolucion);

                    }


                    var movtoTraslado = localContext.Movto_traslado
                                        .FirstOrDefault(m => m.EmpresaId == movto_traslado_impo.EmpresaId && m.SucursalId == movto_traslado_impo.SucursalId && m.Movtoid == movto_traslado_impo.Id);

                    if (movtoTraslado == null)
                    {

                        movtoTraslado = new Movto_traslado()
                        {

                            EmpresaId = movto_traslado_impo.EmpresaId,
                            SucursalId = movto_traslado_impo.SucursalId,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = usuarioId,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = usuarioId,
                            Movtoid = movto_traslado_impo.Id,
                            Motivodevolucionid = movto_traslado_impo.Motivodevolucionid,
                            Otromotivodevolucion = movto_traslado_impo.Otromotivodevolucion,
                            Preciovisibletraslado = movtoInfo.Precio 

                        };
                        localContext.Add(movtoTraslado);
                    }
                    else
                    {

                        movtoTraslado!.Motivodevolucionid = movto_traslado_impo.Motivodevolucionid;
                        movtoTraslado!.Otromotivodevolucion = movto_traslado_impo.Otromotivodevolucion;
                        movtoTraslado!.Preciovisibletraslado = movtoInfo.Precio;
                        localContext.Update(movtoTraslado);

                    }

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


        public void Movto_devolver_traslado(long empresaId, long sucursalId, long movtoADevolverId, ref long? movtoDevolucionId, long? usuarioId, 
                                            long doctoDevolucionId,  ApplicationDbContext localContext)
        {
            movtoDevolucionId = null;

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var movtoItem = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Movto_devolucion)
                                            .Include(m => m.Movto_comodin)
                                            .Include(m => m.Docto)
                                            .Include(m => m.Movto_traslado)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == movtoADevolverId)
                                            .FirstOrDefault();

                if (movtoItem == null)
                    throw new Exception("Movto no encontrado");

                var usuarioId_ = usuarioId ?? (movtoItem.Docto!.Usuarioid ?? 0);

                var paramDevo = new MovtoProvDevoTrans();

                paramDevo.Fechavence = movtoItem.Fechavence;
                paramDevo.Loteimportado = movtoItem.Loteimportado;
                paramDevo.Movtoparentid = null;
                paramDevo.Agrupaporparametro = BoolCN.N;
                paramDevo.Cargartarjetapreciomanual = BoolCN.N;
                paramDevo.Precioyavalidado = BoolCN.S;
                paramDevo.Usuarioid = usuarioId_;

                paramDevo.Lote = movtoItem.Lote;
                paramDevo.Localidad = null;//movtoItem.Localidad;
                paramDevo.Descripcion1 = movtoItem.Movto_comodin?.Descripcion1;
                paramDevo.Descripcion2 = movtoItem.Movto_comodin?.Descripcion2;
                paramDevo.Descripcion3 = movtoItem.Movto_comodin?.Descripcion3;
                paramDevo.Empresaid = movtoItem.EmpresaId;
                paramDevo.Sucursalid = movtoItem.SucursalId;
                paramDevo.Movtoadevolverid = movtoItem.Id;
                //paramDevo.Id = movtoItem.Movtoid;
                paramDevo.Doctoid = doctoDevolucionId;
                paramDevo.Partida = movtoItem.Partida;
                paramDevo.Estatusmovtoid = Model.DBValues._MOVTO_ESTATUS_BORRADOR;
                paramDevo.Productoid = movtoItem.Productoid!.Value;

                paramDevo.Precio = movtoItem.Precio;
                paramDevo.Cantidad = movtoItem.Movto_devolucion?.Cantidadfaltante ?? 0m;




                movtoDevolucionId = null;
                _provdevoService.Movto_provdevo_insert(paramDevo, ref movtoDevolucionId, localContext);

                localContext.SaveChanges();

                long? movtoDevolucionId_ = movtoDevolucionId;

                var movtoTraslado = localContext.Movto_traslado
                                    .FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && 
                                                         m.Movtoid == movtoDevolucionId_);

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
                        Movtoid = movtoDevolucionId,
                        Preciovisibletraslado = movtoItem.Movto_traslado?.Preciovisibletraslado ?? 0m,
                        Motivodevolucionid = movtoItem.Movto_traslado?.Motivodevolucionid,
                        Otromotivodevolucion = movtoItem.Movto_traslado?.Otromotivodevolucion

                    };
                    localContext.Add(movtoTraslado);
                }
                else
                {

                    movtoTraslado.Preciovisibletraslado = movtoItem.Movto_traslado?.Preciovisibletraslado ?? 0m;
                    movtoTraslado.Motivodevolucionid = movtoItem.Movto_traslado?.Motivodevolucionid;
                    movtoTraslado.Otromotivodevolucion = movtoItem.Movto_traslado?.Otromotivodevolucion;
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


        public void Docto_devolver_traslado(long empresaId, long sucursalId, long doctoADevolverId, long? usuarioId, ref long? doctoDevolucionId,
                                             ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoADevolver = localContext.Docto.AsNoTracking()
                                            .Include(m => m.Docto_devolucion)
                                            .Include(m => m.Docto_traslado)
                                            .Include(m => m.Docto_compra)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == doctoADevolverId)
                                            .FirstOrDefault();

                if (doctoADevolver == null)
                    throw new Exception("Docto no encontrado");

                var usuarioId_ = usuarioId ?? (doctoADevolver!.Usuarioid ?? 0);


                var doctoDevoParam = new DoctoProvDevoTrans();

                doctoDevoParam.Referencia = doctoADevolver.Referencia;
                doctoDevoParam.Referencias = doctoADevolver.Referencias;
                doctoDevoParam.Empresaid = doctoADevolver.EmpresaId;
                doctoDevoParam.Sucursalid = doctoADevolver.SucursalId;
                doctoDevoParam.Estatusdoctoid = doctoADevolver.Estatusdoctoid!.Value;
                doctoDevoParam.Usuarioid = doctoADevolver.Usuarioid!.Value;


                doctoDevoParam.Creadopor_userid = doctoADevolver.Usuarioid!.Value;
                doctoDevoParam.Fecha = doctoADevolver.Fecha!.Value;
                doctoDevoParam.Cajaid = doctoADevolver.Cajaid!.Value;
                doctoDevoParam.Almacenid = doctoADevolver.Almacenid!.Value;
                doctoDevoParam.Origenfiscalid = doctoADevolver.Origenfiscalid!.Value;
                doctoDevoParam.Doctoparentid = doctoADevolver.Doctoparentid;
                doctoDevoParam.Proveedorid = doctoADevolver.Proveedorid;
                doctoDevoParam.Tipodoctoid = DBValues._DOCTO_TIPO_COMPRA_DEVO;
                doctoDevoParam.Sucursal_id = doctoADevolver.Sucursal_id!.Value;
                doctoDevoParam.Sucursaltid = doctoADevolver.Docto_traslado?.Sucursaltid;
                doctoDevoParam.Almacentid = doctoADevolver.Docto_traslado?.Almacentid;
                doctoDevoParam.Doctoadevolverid = doctoADevolverId;
                doctoDevoParam.Folio_c = doctoADevolver.Docto_compra?.Folio;
                doctoDevoParam.Factura_c = doctoADevolver.Docto_compra?.Factura;
                doctoDevoParam.Fechafactura_c = doctoADevolver.Docto_compra?.Fechafactura;
                doctoDevoParam.Fechavence_c = doctoADevolver.Fechavence;


                doctoDevolucionId = null;
                _provdevoService.Docto_provdevo_insert(doctoDevoParam, ref doctoDevolucionId, localContext);

                localContext.SaveChanges();


                long? doctoDevolucionId_ = doctoDevolucionId;
                var doctoTraslado = localContext.Docto_traslado
                                    .FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoDevolucionId_);

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
                        Doctoid = doctoDevolucionId,


                        Doctoimportadoid = null,
                        Foliosolicitudmercancia = doctoADevolver.Docto_traslado?.Foliosolicitudmercancia,
                        Foliotrasladooriginal = doctoADevolver.Docto_traslado?.Foliotrasladooriginal,
                        Estraslado = BoolCN.S,
                        Esdevolucion = BoolCN.S,
                        Foliodevolucion = null,
                        Essurtimientomerca = "N",
                        Idsolicitudmercancia = doctoADevolver.Docto_traslado?.Idsolicitudmercancia,
                        Idtrasladooriginal = doctoADevolver.Docto_traslado?.Idtrasladooriginal,
                        Iddevolucion = doctoADevolver.Docto_traslado?.Iddevolucion

                    };
                    localContext.Add(doctoTraslado);
                }
                else
                {


                    doctoTraslado.Doctoimportadoid = null;
                    doctoTraslado.Foliosolicitudmercancia = doctoADevolver.Docto_traslado?.Foliosolicitudmercancia;
                    doctoTraslado.Foliotrasladooriginal = doctoADevolver.Docto_traslado?.Foliotrasladooriginal;
                    doctoTraslado.Estraslado = BoolCN.S;
                    doctoTraslado.Esdevolucion = BoolCN.S;
                    doctoTraslado.Foliodevolucion = null;
                    doctoTraslado.Essurtimientomerca = "N";
                    doctoTraslado.Idsolicitudmercancia = doctoADevolver.Docto_traslado?.Idsolicitudmercancia;
                    doctoTraslado.Idtrasladooriginal = doctoADevolver.Docto_traslado?.Idtrasladooriginal;
                    doctoTraslado.Iddevolucion = doctoADevolver.Docto_traslado?.Iddevolucion;


                    localContext.Update(doctoTraslado);

                }

                localContext.SaveChanges();


                var movtosADevolver = localContext.Movto.AsNoTracking()
                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoADevolverId &&
                                                         m.Movto_devolucion!.Cantidadfaltante > 0)
                                    .Select(m => m.Id)
                                    .ToList();

                foreach( var movtoADevolver in movtosADevolver)
                {
                    long? movtoDevolucionId = null;
                    Movto_devolver_traslado(empresaId, sucursalId, movtoADevolver, ref movtoDevolucionId, usuarioId_,
                                                doctoDevolucionId!.Value, localContext);

                }


                localContext.SaveChanges();

                _provdevoService.Docto_provdevo_save(empresaId, sucursalId, doctoDevolucionId!.Value, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);


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


        public void Docto_recibir_traslado(long empresaId, long sucursalId, long doctoARecibirId, long? usuarioId,
                                            long? almacenId, string? referencias, ref long? doctoDevolucionId,
                                             ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var doctoARecibirInfo = localContext.Docto.AsNoTracking()
                                            .Include(m => m.Docto_devolucion)
                                            .Include(m => m.Docto_traslado)
                                            .Include(m => m.Docto_compra)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == doctoARecibirId)
                                            .FirstOrDefault();

                if (doctoARecibirInfo == null)
                    throw new Exception("Docto no encontrado");

                if(doctoARecibirInfo.Tipodoctoid != DBValues._DOCTO_TIPO_TRASPASO_REC)
                    throw new Exception("Docto no es del tipo adecuado");

                if (doctoARecibirInfo.Estatusdoctoid != DBValues._DOCTO_ESTATUS_BORRADOR)
                    throw new Exception("Docto no es borrador");


                var usuarioId_ = usuarioId ?? (doctoARecibirInfo!.Usuarioid ?? 0);

                var docto = localContext.Docto
                                            .FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == doctoARecibirId);

                if(docto == null)
                    throw new Exception("Docto no existe");

                var sucursalInfoOrigenId = doctoARecibirInfo.Docto_traslado?.Sucursaltid;
                var sucursalInfoId = doctoARecibirInfo.Sucursal_id;

                var sucursalOrigen = localContext.Sucursal_info.AsNoTracking()
                                                .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == sucursalInfoOrigenId )
                                                .Select(p => new { Empprovid = (p.Sucursal_info_opciones != null ? p.Sucursal_info_opciones.Empprovid : null)})
                                                .FirstOrDefault();

                var sucursalInfo = localContext.Sucursal_info.AsNoTracking()
                                                .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == sucursalInfoId)
                                                .Select(p => new { Empprovid = (p.Sucursal_info_opciones != null ? p.Sucursal_info_opciones.Empprovid : null) })
                                                .FirstOrDefault();

                if(sucursalOrigen?.Empprovid != sucursalInfo?.Empprovid && 
                    sucursalOrigen?.Empprovid != null && sucursalInfo?.Empprovid != null)
                {
                    docto.Origenfiscalid = DBValues._ORIGENFISCAL_FACTURADO;
                }
                else
                {
                    docto.Origenfiscalid = DBValues._ORIGENFISCAL_REMISIONADO;
                }

                docto.Tipodoctoid = DBValues._DOCTO_TIPO_COMPRA;
                docto.Subtipodoctoid = DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA;
                docto.Almacenid = almacenId;
                docto.Referencias = referencias;

                localContext.Update(docto);
                localContext.SaveChanges();



                var doctoCompra = localContext.Docto_compra
                                    .FirstOrDefault(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoARecibirId);

                if (doctoCompra == null)
                {

                    doctoCompra = new Docto_compra()
                    {

                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = usuarioId_,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = usuarioId_,
                        Doctoid = doctoARecibirId,
                        Fechafactura = docto.Fecha


                    };
                    localContext.Add(doctoCompra);
                }
                else
                {
                    doctoCompra.Fechafactura = docto.Fecha;
                    localContext.Update(doctoCompra);

                }


                localContext.SaveChanges();



                _proveeduriaService.Docto_prov_save(empresaId, sucursalId, doctoARecibirId, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);


                var cuentaMovtosConFaltantes = localContext.Movto.AsNoTracking()
                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                         m.Doctoid == doctoARecibirId &&
                                                         m.Movto_devolucion != null && m.Movto_devolucion.Cantidadfaltante > 0)
                                    .Count();

                if(cuentaMovtosConFaltantes > 0)
                {
                    Docto_devolver_traslado(empresaId, sucursalId, doctoARecibirId, usuarioId_,  ref  doctoDevolucionId,
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


        public void Recibir_traslado(long empresaId, long sucursalId, long doctoARecibirId, long usuarioId,
                                            long? almacenId, string? referencias,
                                            List<Recepcion_movto_traslado_impo> movtosARecibir, ref long? doctoDevolucionId,
                                             ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? corteid;
            BoolCS? corte_activo;
            DateTimeOffset? fechacorte;
            DateTimeOffset? corte_inicia;
            DateTimeOffset? corte_termina;


            try
            {
                _corteService.HayCorteActivo(empresaId, sucursalId, usuarioId,
                                               out corteid, out corte_activo, out fechacorte, out corte_inicia, out corte_termina, localContext);

                if (corteid == null || corteid == 0)
                {
                    throw new Exception("No hay corte activo");
                }

                var cuentaManejanLoteOLoteImportacionYNoTienen = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Producto).ThenInclude(m => m!.Producto_inventario)
                                            .Include(m => m.Producto).ThenInclude(m => m!.Producto_loteimportado)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && 
                                                        m.Doctoid == doctoARecibirId)
                                            .GroupBy(m => m.Id)
                                            .Select(g => new {
                                                LotesFaltantes = g.Count(m => (m.Producto != null && m.Producto.Producto_inventario != null &&  
                                                                               m.Producto.Producto_inventario.Manejalote == BoolCN.S && (m.Lote == null || m.Lote.Trim().Length == 0) )),
                                                LotesImportadoFaltantes = g.Count(m => (m.Producto != null && m.Producto.Producto_loteimportado != null &&
                                                                               m.Producto.Producto_loteimportado.Manejaloteimportado == BoolCN.S && m.Loteimportado == null ))
                                            })
                                            .FirstOrDefault();

                if(cuentaManejanLoteOLoteImportacionYNoTienen != null &&
                    (cuentaManejanLoteOLoteImportacionYNoTienen.LotesFaltantes > 0 ||
                     cuentaManejanLoteOLoteImportacionYNoTienen.LotesImportadoFaltantes > 0)
                    )
                {
                    throw new Exception("Hay lotes o lotes importados faltantes");

                }
                    

                foreach (var movto in movtosARecibir)
                {
                    Movto_recibir_traslado(movto, usuarioId, localContext);
                }

                Docto_recibir_traslado(empresaId, sucursalId, doctoARecibirId, usuarioId,
                                            almacenId, referencias, ref doctoDevolucionId, localContext);



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





    public class Tmp_movto_traslado_recepcion : TransitionClass
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
        public long? Razondiferenciaid { get; }
        public string? Razondiferenciaclave { get; }
        public string? Razondiferencianombre { get; }
        public long? Motivodevolucionid { get; }
        public string? Motivodevolucionclave { get; }
        public string? Motivodevolucionnombre { get; }
        public string? Motivodevoluciondescripcion { get; }
        public string? Otromotivodevolucion { get; }

        public Tmp_movto_traslado_recepcion()
        {

        }
        public Tmp_movto_traslado_recepcion(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar,
                                        decimal cantidadfaltante, decimal cantidaddevuelta, decimal cantidadsaldo, long? razondiferenciaid, string? razondiferenciaclave, string? razondiferencianombre, long? motivodevolucionid, string? motivodevolucionclave, string? motivodevolucionnombre, string? motivodevoluciondescripcion, string? otromotivodevolucion)
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
            Razondiferenciaid = razondiferenciaid;
            Razondiferenciaclave = razondiferenciaclave;
            Razondiferencianombre = razondiferencianombre;
            Motivodevolucionid = motivodevolucionid;
            Motivodevolucionclave = motivodevolucionclave;
            Motivodevolucionnombre = motivodevolucionnombre;
            Motivodevoluciondescripcion = motivodevoluciondescripcion;
            Otromotivodevolucion = otromotivodevolucion;

        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_movto_traslado_recepcion other &&
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
