using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class InventarioOperativoService
    {

        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private DoctoMovtoService _doctoMovtoService;
        private CorteService _corteService;
        private InventarioService _inventarioService;
        public InventarioOperativoService(
            DoctoService doctoService,
            MovtoService movtoService,
            DoctoMovtoService doctoMovtoService,
            CorteService corteService,
            InventarioService inventarioService)
        {
            _doctoService = doctoService;
            _movtoService = movtoService;
            _doctoMovtoService = doctoMovtoService;
            _corteService = corteService;
            _inventarioService = inventarioService;
        }



        public List<Tmp_InventarioHechosList> InventariosHechosList(long empresaId, long sucursalId, long? estadoDoctoId, bool? activos, DateTimeOffset desde, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var lstInventario = localContext.Docto.AsNoTracking()
                                                .Include(d => d.Estatusdocto)
                                                .Include(d => d.Caja)
                                                .Include(d => d.Tipodocto)
                                                .Include(d => d.Usuario)
                                                .Include(d => d.Sucursal)
                                                .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && (d.Tipodoctoid == 50 || d.Tipodoctoid == 53) &&
                                                                  (estadoDoctoId == 3 || estadoDoctoId == d.Estatusdoctoid || (estadoDoctoId == 1 && d.Estatusdoctoid == 2)) &&
                                                                  (d.Fecha >= desde) &&
                                                                  (activos == null || (activos.Value && d.Activo == BoolCS.S) || (!activos.Value && d.Activo == BoolCS.N))
                                                     )
                                                .Select(d => new Tmp_InventarioHechosList(
d.EmpresaId,
d.SucursalId,
d.Sucursal.Clave,
d.Sucursal.Nombre,
d.Cajaid,
d.Caja != null ? d.Caja.Clave : "",
d.Caja != null ? d.Caja.Nombre : "",
d.Fecha,
d.Serie,
d.Id,
d.Total,
d.Estatusdoctoid,
d.Estatusdocto != null ? d.Estatusdocto.Clave : "",
d.Estatusdocto != null ? d.Estatusdocto.Nombre : "",
d.Tipodoctoid,
d.Tipodocto != null ? d.Tipodocto.Clave : "",
d.Tipodocto != null ? d.Tipodocto.Nombre : "",
d.Referencia,
d.Folio,
d.Usuarioid,
d.Usuario != null ? d.Usuario.Clave : "",
d.Usuario != null ? d.Usuario.Nombre : ""
                                                )).ToList();

                return lstInventario;


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


        public IQueryable<InventarioDesglose> Inventario_Desglose(
                            long empresaId,
                            long sucursalId,
                            long? almacenId,
                            bool kitDesglosado,
                            long? doctoId, 
                            long? productoId,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                IQueryable<InventarioDesglose>? lstInventarioDirecto;

                if (doctoId == null)
                {
                    lstInventarioDirecto = localContext.Inventario.AsNoTracking()
                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_kit)
                        .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Cantidad > 0 &&
                                    (d.Producto!.Producto_inventario == null || d.Producto.Producto_inventario.Inventariable == BoolCS.S) &&
                                    (d.Producto!.Producto_kit == null || d.Producto.Producto_kit.Eskit != BoolCN.S || !kitDesglosado) &&
                                    (d.Almacenid == almacenId || almacenId == null) &&
                                    (d.Productoid == productoId || productoId == null))
                        .Select(i => new InventarioDesglose()
                        {
                            EmpresaId = i.EmpresaId,
                            SucursalId = i.SucursalId,
                            ProductoId = (i.Productoid ?? 0),
                            Almacenid = i.Almacenid,
                            Lote = Convert.ToString(i.Lote),
                            Fechavence = i.Fechavence,
                            Loteimportado = i.Loteimportado,
                            Esapartado = i.Esapartado,
                            Movtoid = 0L,
                            CantidadTeorica = Convert.ToDecimal(i.Cantidad),
                            CantidadSurtida = Convert.ToDecimal(0m)

                        });
                }
                else
                {

                    lstInventarioDirecto = localContext.Movto.AsNoTracking()
                     .Include(m => m.Producto).ThenInclude(p => p!.Inventarios)
                     .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                     .Include(i => i.Producto).ThenInclude(p => p!.Producto_kit)
                     .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && 
                                 d.Doctoid == doctoId && //d.Cantidad > 0 &&
                                 (d.Producto!.Producto_inventario == null || d.Producto.Producto_inventario.Inventariable == BoolCS.S) &&
                                 (d.Producto!.Producto_kit == null || d.Producto.Producto_kit.Eskit != BoolCN.S || !kitDesglosado) &&
                                 (d.Productoid == productoId || productoId == null)
                                 )
                     .SelectMany(l => l.Producto!.Inventarios!).Distinct()
                     .Where(d => (d.Almacenid == almacenId || almacenId == null))
                     .Select(i => new InventarioDesglose()
                     {
                         EmpresaId = i.EmpresaId,
                         SucursalId = i.SucursalId,
                         ProductoId = (i.Productoid ?? 0),
                         Almacenid = i.Almacenid,
                         Lote = Convert.ToString(i.Lote),
                         Fechavence = i.Fechavence,
                         Loteimportado = i.Loteimportado,
                         Esapartado = i.Esapartado,
                         Movtoid = 0L,
                         CantidadTeorica = Convert.ToDecimal(i.Cantidad),
                         CantidadSurtida = Convert.ToDecimal(0m)

                     });
                }

                IQueryable<InventarioDesglose>? lstInventarioIndirecto;

                if(doctoId == null)
                {

                    lstInventarioIndirecto = localContext.Inventario.AsNoTracking()
                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_kit)
                        .Include(i => i.Producto).ThenInclude(p => p!.KitDefinicionSet)!.ThenInclude(k => k!.Productoparte)!.ThenInclude(p => p!.Producto_inventario)
                        .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Cantidad > 0 &&
                                    d.Producto != null && d.Producto.Producto_inventario != null && d.Producto.Producto_kit != null &&
                                    d.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                    d.Producto.Producto_kit.Eskit == BoolCN.S && d.Producto.KitDefinicionSet != null &&
                                    (d.Almacenid == almacenId || almacenId == null) &&
                                    kitDesglosado &&
                                    (d.Productoid == productoId || productoId == null))
                        .SelectMany(i => i.Producto!.KitDefinicionSet!.Select(k => new InventarioDesglose()
                        {
                            EmpresaId = i.EmpresaId,
                            SucursalId = i.SucursalId,
                            ProductoId = (k.Productoparteid ?? 0),
                            Almacenid = i.Almacenid,
                            Lote = Convert.ToString((k.Productoparte!.Producto_inventario!.Manejalote == BoolCN.S) ? "kit" : null),
                            Fechavence = (k.Productoparte.Producto_inventario.Manejalote == BoolCN.S ? i.Fechavence : null),
                            Loteimportado = i.Loteimportado,
                            Esapartado = i.Esapartado,
                            Movtoid = 0L,
                            CantidadTeorica = Convert.ToDecimal(i.Cantidad * k.Cantidadparte),
                            CantidadSurtida = Convert.ToDecimal(0m)

                        }));
                }
                else
                {

                    lstInventarioIndirecto = localContext.Movto.AsNoTracking()
                        .Include(m => m.Producto).ThenInclude(p => p!.Inventarios)!
                        .ThenInclude(i => i!.Producto)!.ThenInclude(p => p!.KitDefinicionSet)!.ThenInclude(k => k!.Productoparte)!.ThenInclude(p => p!.Producto_inventario)
                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_kit)
                        .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && //d.Cantidad > 0 &&
                                    d.Doctoid == doctoId &&
                                    d.Producto != null && d.Producto.Producto_inventario != null && d.Producto.Producto_kit != null &&
                                    d.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                    d.Producto.Producto_kit.Eskit == BoolCN.S && d.Producto.KitDefinicionSet != null &&
                                    kitDesglosado &&
                                    (d.Productoid == productoId || productoId == null))
                        .SelectMany(l => l.Producto!.Inventarios!)
                        .Where(d => (d.Almacenid == almacenId || almacenId == null))
                        .SelectMany(i => i.Producto!.KitDefinicionSet!.Select(k => new InventarioDesglose()
                        {
                            EmpresaId = i.EmpresaId,
                            SucursalId = i.SucursalId,
                            ProductoId = (k.Productoparteid ?? 0),
                            Almacenid = i.Almacenid,
                            Lote = Convert.ToString((k.Productoparte!.Producto_inventario!.Manejalote == BoolCN.S) ? "kit" : null),
                            Fechavence = (k.Productoparte.Producto_inventario.Manejalote == BoolCN.S ? i.Fechavence : null),
                            Loteimportado = i.Loteimportado,
                            Esapartado = i.Esapartado,
                            Movtoid = 0L,
                            CantidadTeorica = Convert.ToDecimal(i.Cantidad * k.Cantidadparte),
                            CantidadSurtida = Convert.ToDecimal(0m)

                        }));
                }

                    
                return lstInventarioDirecto.Concat(lstInventarioIndirecto);
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



        public IQueryable<InventarioDesglose> Inventario_Movto_Desglose(
                            long empresaId,
                            long sucursalId,
                            long? doctoId,
                            long? almacenId,
                            bool kitDesglosado,
                            long? productoId,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                var lstInventarioRegistradoDirecto = localContext.Movto.AsNoTracking()
                                                          .Include(m => m.Movto_inventario)
                                                          .Include(m => m.Docto)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_kit)
                                                          .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                      m.Doctoid == doctoId &&
                                                                      m.Producto != null && m.Producto.Producto_inventario != null && m.Producto.Producto_kit != null &&
                                                                      m.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                                                      (m.Producto.Producto_kit.Eskit != BoolCN.S || !kitDesglosado) &&
                                                                      (productoId == null || m.Productoid == productoId)
                                                                )
                                                          .Select(m => new InventarioDesglose()
                                                          {
                                                              EmpresaId = m.EmpresaId,
                                                              SucursalId = m.SucursalId,
                                                              ProductoId = m.Productoid!.Value,
                                                              Almacenid = m.Docto!.Almacenid,
                                                              Lote = Convert.ToString(m.Lote),
                                                              Fechavence = m.Fechavence,
                                                              Loteimportado = m.Loteimportado,
                                                              Esapartado = m.Docto.Esapartado,
                                                              Movtoid = m.Id,
                                                              CantidadTeorica = Convert.ToDecimal(0m),
                                                              CantidadSurtida = Convert.ToDecimal(m.Movto_inventario != null ? m.Movto_inventario.Cantidad_real : 0m)

                                                          });

                var lstInventarioRegistradoIndirecto = localContext.Movto.AsNoTracking()
                                                          .Include(m => m.Movto_inventario)
                                                          .Include(m => m.Docto)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_kit)
                                                          .Include(i => i.Producto).ThenInclude(p => p!.KitDefinicionSet)!.ThenInclude(k => k!.Productoparte)!.ThenInclude(p => p!.Producto_inventario)
                                                          .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                      m.Doctoid == doctoId &&
                                                                      m.Producto != null && m.Producto.Producto_inventario != null && m.Producto.Producto_kit != null &&
                                                                      m.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                                                      m.Producto.Producto_kit.Eskit == BoolCN.S && m.Producto.KitDefinicionSet != null &&
                                                                      kitDesglosado &&
                                                                      (productoId == null || m.Productoid == productoId)
                                                                )
                                                          .SelectMany(m => m.Producto!.KitDefinicionSet!.Select(k => new InventarioDesglose()
                                                          {
                                                              EmpresaId = m.EmpresaId,
                                                              SucursalId = m.SucursalId,
                                                              ProductoId = (k.Productoparteid ?? 0),
                                                              Almacenid = m.Docto!.Almacenid,
                                                              Lote = Convert.ToString(m.Lote),
                                                              Fechavence = m.Fechavence,
                                                              Loteimportado = m.Loteimportado,
                                                              Esapartado = m.Docto.Esapartado,
                                                              Movtoid = m.Id,
                                                              CantidadTeorica = Convert.ToDecimal(0m), 
                                                              CantidadSurtida = Convert.ToDecimal(m.Movto_inventario != null ? (m.Movto_inventario.Cantidad_real * k.Cantidadparte) : 0m)

                                                          }));
                return lstInventarioRegistradoDirecto.Concat(lstInventarioRegistradoIndirecto);
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








        public IQueryable<InventarioDesglose_x_loc> Inventario_Movto_Desglose_X_Loc(
                            long empresaId,
                            long sucursalId,
                            long? doctoId,
                            long? almacenId,
                            bool kitDesglosado,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                var lstInventarioRegistradoDirecto = localContext.Movto.AsNoTracking()
                                                          .Include(m => m.Movto_inventario)
                                                          .Include(m => m.Docto)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_kit)
                                                          .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                      m.Doctoid == doctoId &&
                                                                      m.Producto != null && m.Producto.Producto_inventario != null && m.Producto.Producto_kit != null &&
                                                                      m.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                                                      (m.Producto.Producto_kit.Eskit != BoolCN.S || !kitDesglosado)
                                                                )
                                                          .Select(m => new InventarioDesglose_x_loc()
                                                          {
                                                              EmpresaId = m.EmpresaId,
                                                              SucursalId = m.SucursalId,
                                                              ProductoId = m.Productoid!.Value,
                                                              Almacenid = m.Docto!.Almacenid,
                                                              Lote = Convert.ToString(m.Lote),
                                                              Fechavence = m.Fechavence,
                                                              Loteimportado = m.Loteimportado,
                                                              Esapartado = m.Docto.Esapartado,
                                                              Movtoid = m.Id,
                                                              CantidadTeorica = Convert.ToDecimal(0m),//m.Movto_inventario != null ? m.Movto_inventario.Cantidad_teorica - m.Movto_inventario.Cantidad_teorica : 0m, //simulate 0
                                                              CantidadSurtida = Convert.ToDecimal(m.Movto_inventario != null ? m.Movto_inventario.Cantidad_real : 0m),
                                                              Localidad = Convert.ToString(m.Movto_inventario != null ? m.Movto_inventario.Localidad : null),
                                                              Anaquelid = m.Movto_inventario != null ? m.Movto_inventario.Anaquelid : (long?)null

                                                          });

                var lstInventarioRegistradoIndirecto = localContext.Movto.AsNoTracking()
                                                          .Include(m => m.Movto_inventario)
                                                          .Include(m => m.Docto)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_kit)
                                                          .Include(i => i.Producto).ThenInclude(p => p!.KitDefinicionSet)!.ThenInclude(k => k!.Productoparte)!.ThenInclude(p => p!.Producto_inventario)
                                                          .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                      m.Doctoid == doctoId &&
                                                                      m.Producto != null && m.Producto.Producto_inventario != null && m.Producto.Producto_kit != null &&
                                                                      m.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                                                      m.Producto.Producto_kit.Eskit == BoolCN.S && m.Producto.KitDefinicionSet != null &&
                                                                      kitDesglosado
                                                                )
                                                          .SelectMany(m => m.Producto!.KitDefinicionSet!.Select(k => new InventarioDesglose_x_loc()
                                                          {
                                                              EmpresaId = m.EmpresaId,
                                                              SucursalId = m.SucursalId,
                                                              ProductoId = (k.Productoparteid ?? 0),
                                                              Almacenid = m.Docto!.Almacenid,
                                                              Lote = Convert.ToString(m.Lote),
                                                              Fechavence = m.Fechavence,
                                                              Loteimportado = m.Loteimportado,
                                                              Esapartado = m.Docto.Esapartado,
                                                              Movtoid = m.Id,
                                                              CantidadTeorica = Convert.ToDecimal(0m),//m.Movto_inventario != null ? m.Movto_inventario.Cantidad_teorica - m.Movto_inventario.Cantidad_teorica : 0m, //simulate 0
                                                              CantidadSurtida = Convert.ToDecimal(m.Movto_inventario != null ? (m.Movto_inventario.Cantidad_real * k.Cantidadparte) : 0m),
                                                              Localidad = Convert.ToString(m.Movto_inventario != null ? m.Movto_inventario.Localidad : null),
                                                              Anaquelid = m.Movto_inventario != null ? m.Movto_inventario.Anaquelid : (long?)null

                                                          }));

                return lstInventarioRegistradoDirecto.Concat(lstInventarioRegistradoIndirecto);
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



        public IQueryable<InventarioDesglose> Inventario_Movto_Desglose_x_loc_grouped(
                            long empresaId,
                            long sucursalId,
                            long? doctoId,
                            long? almacenId,
                            bool kitDesglosado,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                var lstInventarioRegistradoDirecto = localContext.Movto.AsNoTracking()
                                                          .Include(m => m.Movto_inventario)
                                                          .Include(m => m.Docto)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_kit)
                                                          .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                      m.Doctoid == doctoId &&
                                                                      m.Producto != null && m.Producto.Producto_inventario != null && m.Producto.Producto_kit != null &&
                                                                      m.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                                                      (m.Producto.Producto_kit.Eskit != BoolCN.S || !kitDesglosado)
                                                                )
                                                          .GroupBy(m => new
                                                          {

                                                              EmpresaId = m.EmpresaId,
                                                              SucursalId = m.SucursalId,
                                                              ProductoId = m.Productoid!.Value,
                                                              Almacenid = m.Docto!.Almacenid,
                                                              Lote = Convert.ToString(m.Lote),
                                                              Fechavence = m.Fechavence,
                                                              Loteimportado = m.Loteimportado,
                                                              Esapartado = m.Docto.Esapartado,

                                                          })
                                                          .Select(m => new InventarioDesglose()
                                                          {
                                                              EmpresaId = m.Key.EmpresaId,
                                                              SucursalId = m.Key.SucursalId,
                                                              ProductoId = m.Key.ProductoId,
                                                              Almacenid = m.Key.Almacenid,
                                                              Lote = Convert.ToString(m.Key.Lote),
                                                              Fechavence = m.Key.Fechavence,
                                                              Loteimportado = m.Key.Loteimportado,
                                                              Esapartado = m.Key.Esapartado,
                                                              Movtoid = m.Max(t => t.Id),
                                                              CantidadTeorica = Convert.ToDecimal(0m), 
                                                              CantidadSurtida = Convert.ToDecimal(m.Sum(t => t.Movto_inventario != null ? t.Movto_inventario.Cantidad_real : 0m))

                                                          });

                var lstInventarioRegistradoIndirecto = localContext.Movto.AsNoTracking()
                                                          .Include(m => m.Movto_inventario)
                                                          .Include(m => m.Docto)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                          .Include(m => m.Producto).ThenInclude(p => p!.Producto_kit)
                                                          .Include(i => i.Producto).ThenInclude(p => p!.KitDefinicionSet)!.ThenInclude(k => k!.Productoparte)!.ThenInclude(p => p!.Producto_inventario)
                                                          .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                      m.Doctoid == doctoId &&
                                                                      m.Producto != null && m.Producto.Producto_inventario != null && m.Producto.Producto_kit != null &&
                                                                      m.Producto.Producto_inventario.Inventariable == BoolCS.S &&
                                                                      m.Producto.Producto_kit.Eskit == BoolCN.S && m.Producto.KitDefinicionSet != null &&
                                                                      kitDesglosado
                                                                )
                                                          .SelectMany(m => m.Producto!.KitDefinicionSet!.Select(k => new InventarioDesglose()
                                                          {
                                                              EmpresaId = m.EmpresaId,
                                                              SucursalId = m.SucursalId,
                                                              ProductoId = (k.Productoparteid ?? 0),
                                                              Almacenid = m.Docto!.Almacenid,
                                                              Lote = Convert.ToString(m.Lote),
                                                              Fechavence = m.Fechavence,
                                                              Loteimportado = m.Loteimportado,
                                                              Esapartado = m.Docto.Esapartado,
                                                              Movtoid = m.Id,
                                                              CantidadTeorica = Convert.ToDecimal(0m), 
                                                              CantidadSurtida = Convert.ToDecimal(m.Movto_inventario != null ? (m.Movto_inventario.Cantidad_real * k.Cantidadparte) : 0m)

                                                          }))
                                                          .GroupBy(m => new
                                                          {

                                                              m.EmpresaId,
                                                              m.SucursalId,
                                                              m.ProductoId,
                                                              m.Almacenid,
                                                              m.Lote,
                                                              m.Fechavence,
                                                              m.Loteimportado,
                                                              m.Esapartado
                                                          })
                                                          .Select(m => new InventarioDesglose()
                                                          {

                                                              EmpresaId = m.Key.EmpresaId,
                                                              SucursalId = m.Key.SucursalId,
                                                              ProductoId = m.Key.ProductoId,
                                                              Almacenid = m.Key.Almacenid,
                                                              Lote = Convert.ToString(m.Key.Lote),
                                                              Fechavence = m.Key.Fechavence,
                                                              Loteimportado = m.Key.Loteimportado,
                                                              Esapartado = m.Key.Esapartado,
                                                              Movtoid = m.Max(t => t.Movtoid),
                                                              CantidadTeorica = Convert.ToDecimal(m.Sum(t => t.CantidadTeorica)),
                                                              CantidadSurtida = Convert.ToDecimal(m.Sum(t => t.CantidadSurtida))
                                                          });

;

                return lstInventarioRegistradoDirecto.Concat(lstInventarioRegistradoIndirecto);
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

        public List<Tmp_Inventario_movto_detalles> Inventario_movto_detalles(
                            long empresaId,
                            long sucursalId,
                            long? almacenId,
                            long? doctoId,
                            bool solodiferencias,
                            bool todoslosproductos,
                            bool kitDesglosado,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {



                var lstInventarioDesglose = Inventario_Desglose(empresaId, sucursalId,
                                                                almacenId, kitDesglosado,
                                                                todoslosproductos ? null : doctoId, 
                                                                null, 
                                                                localContext);

                var lstInventarioMovtoDesglose = Inventario_Movto_Desglose(empresaId, sucursalId,
                                                                            doctoId, almacenId,
                                                                            kitDesglosado,
                                                                            null, 
                                                                            localContext);


                var lstInventarioConcatenated = lstInventarioDesglose.Concat(lstInventarioMovtoDesglose);



                var lstInventario = lstInventarioConcatenated.GroupBy(l => 
                                                                new { 
                                                                    l.EmpresaId, l.SucursalId, l.ProductoId, l.Almacenid, l.Lote, l.Fechavence, l.Loteimportado
                                                                })
                                                                .Select(l => new {
                                                                    l.Key.EmpresaId,
                                                                    l.Key.SucursalId,
                                                                    l.Key.ProductoId,
                                                                    l.Key.Almacenid,
                                                                    l.Key.Lote,
                                                                    l.Key.Fechavence,
                                                                    l.Key.Loteimportado,
                                                                    Movtoid = l.Sum(r => r.Movtoid),
                                                                    CantidadTeorica = l.Sum( r => r.CantidadTeorica),
                                                                    CantidadSurtida = l.Sum( r => r.CantidadSurtida)
                                                                });



                var lstProductoInfo = localContext.Producto.AsNoTracking()
                                                          .Include(p => p.Sucursal)
                                                          .Include(p => p.Producto_inventario)
                                                          .Include(p => p.Producto_kit)
                                                          .Include(p => p.Producto_precios)
                                                          .Include(p => p.Unidad)
                                                          .Include(p => p.Producto_existencia)
                                                          .Include(p => p.Productocaracteristicas)
                                                          .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                      d.Producto_inventario!.Inventariable == BoolCS.S)
                                                          .Select(p => new
                                                          {                
                                                              EmpresaId = p.EmpresaId,
                                                              SucursalId = p.SucursalId,
                                                              Sucursalclave = p.Sucursal.Clave,
                                                              Sucursalnombre = p.Sucursal.Nombre,
                                                              ProductoId = p.Id,
                                                              Productoclave = p.Clave,
                                                              Productonombre = p.Nombre,
                                                              Productodescripcion = p.Descripcion1,
                                                              Productotexto1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto1,
                                                              Productotexto2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto2,
                                                              Productotexto3 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto3,
                                                              Productotexto4 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto4,
                                                              Productotexto5 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto5,
                                                              Productotexto6 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto6,
                                                              Productonumero1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero1,
                                                              Productonumero2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero2,
                                                              Productonumero3 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero3,
                                                              Productonumero4 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero4,
                                                              Fecha1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Fecha1,
                                                              Fecha2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Fecha2,

                                                              Pzacaja = p.Producto_inventario != null && p.Producto_inventario.Pzacaja != 0 ? p.Producto_inventario.Pzacaja : 1m
                                                          });

                var buffer_result =
                                           from productoInfo in lstProductoInfo
                                           join inventarioDirecto in lstInventario
                                                on new
                                                {
                                                    productoInfo.EmpresaId,
                                                    productoInfo.SucursalId,
                                                    productoInfo.ProductoId
                                                } equals new
                                                {
                                                    inventarioDirecto.EmpresaId,
                                                    inventarioDirecto.SucursalId,
                                                    inventarioDirecto.ProductoId
                                                } into joinedInventarioDirecto
                                           from inventarioDirecto in joinedInventarioDirecto.DefaultIfEmpty()
                                           join almacen in localContext.Almacen.AsNoTracking().Where(a => a.EmpresaId == empresaId && a.SucursalId == sucursalId)
                                           on inventarioDirecto.Almacenid equals almacen.Id into joinedAlmacen
                                           from almacen in joinedAlmacen.DefaultIfEmpty()
                                           select new
                                           {
                                               productoInfo.EmpresaId,
                                               productoInfo.SucursalId,
                                               productoInfo.Sucursalclave,
                                               productoInfo.Sucursalnombre,
                                               productoInfo.ProductoId,
                                               productoInfo.Productoclave,
                                               productoInfo.Productonombre,
                                               productoInfo.Productodescripcion,
                                               productoInfo.Productotexto1,
                                               productoInfo.Productotexto2,
                                               productoInfo.Productotexto3,
                                               productoInfo.Productotexto4,
                                               productoInfo.Productotexto5,
                                               productoInfo.Productotexto6,
                                               productoInfo.Productonumero1,
                                               productoInfo.Productonumero2,
                                               productoInfo.Productonumero3,
                                               productoInfo.Productonumero4,
                                               productoInfo.Fecha1,
                                               productoInfo.Fecha2,
                                               productoInfo.Pzacaja,

                                               inventarioDirecto.Almacenid,
                                               Almacenclave = almacen.Clave,
                                               Almacennombre = almacen.Nombre,
                                               inventarioDirecto.Lote,
                                               inventarioDirecto.Fechavence,
                                               inventarioDirecto.Loteimportado,

                                               inventarioDirecto.CantidadTeorica,
                                               inventarioDirecto.CantidadSurtida,
                                               inventarioDirecto.Movtoid



                                           } into mainQry
                                           group mainQry by new
                                           {
                                               mainQry.EmpresaId,
                                               mainQry.SucursalId,
                                               mainQry.Sucursalclave,
                                               mainQry.Sucursalnombre,
                                               mainQry.ProductoId,
                                               mainQry.Productoclave,
                                               mainQry.Productonombre,
                                               mainQry.Productodescripcion,
                                               mainQry.Productotexto1,
                                               mainQry.Productotexto2,
                                               mainQry.Productotexto3,
                                               mainQry.Productotexto4,
                                               mainQry.Productotexto5,
                                               mainQry.Productotexto6,
                                               mainQry.Productonumero1,
                                               mainQry.Productonumero2,
                                               mainQry.Productonumero3,
                                               mainQry.Productonumero4,
                                               mainQry.Fecha1,
                                               mainQry.Fecha2,
                                               mainQry.Pzacaja,
                                               mainQry.Almacenid,
                                               mainQry.Almacenclave ,
                                               mainQry.Almacennombre,
                                               mainQry.Lote,
                                               mainQry.Fechavence,
                                               mainQry.Loteimportado
                                           } into mainQryGroup
                                           select new
                                           {
                                               mainQryGroup.Key.EmpresaId,
                                               mainQryGroup.Key.SucursalId,
                                               mainQryGroup.Key.Sucursalclave,
                                               mainQryGroup.Key.Sucursalnombre,
                                               mainQryGroup.Key.ProductoId,
                                               mainQryGroup.Key.Productoclave,
                                               mainQryGroup.Key.Productonombre,
                                               mainQryGroup.Key.Productodescripcion,
                                               mainQryGroup.Key.Productotexto1,
                                               mainQryGroup.Key.Productotexto2,
                                               mainQryGroup.Key.Productotexto3,
                                               mainQryGroup.Key.Productotexto4,
                                               mainQryGroup.Key.Productotexto5,
                                               mainQryGroup.Key.Productotexto6,
                                               mainQryGroup.Key.Productonumero1,
                                               mainQryGroup.Key.Productonumero2,
                                               mainQryGroup.Key.Productonumero3,
                                               mainQryGroup.Key.Productonumero4,
                                               mainQryGroup.Key.Fecha1,
                                               mainQryGroup.Key.Fecha2,
                                               mainQryGroup.Key.Pzacaja,
                                               mainQryGroup.Key.Almacenid,
                                               mainQryGroup.Key.Almacenclave,
                                               mainQryGroup.Key.Almacennombre,
                                               mainQryGroup.Key.Lote,
                                               mainQryGroup.Key.Fechavence,
                                               mainQryGroup.Key.Loteimportado,
                                               CantidadTeorica = mainQryGroup.Sum(m => m.CantidadTeorica),
                                               CantidadSurtida = mainQryGroup.Sum(m => m.CantidadSurtida),
                                               Movtoid = mainQryGroup.Sum(m => m.Movtoid)

                                           };

                

                return  buffer_result.Where(r => (r.Movtoid > 0 || todoslosproductos) &&
                                    (r.CantidadTeorica != r.CantidadSurtida || !solodiferencias)
                              ).ToList()
                              .Select(m => new Tmp_Inventario_movto_detalles(

                                  m.EmpresaId,
                                  m.SucursalId,
                                  m.Sucursalclave,
                                  m.Sucursalnombre,
                                  m.ProductoId,
                                  m.Productoclave,
                                  m.Productonombre,
                                  m.Productodescripcion,
                                  m.Productotexto1,
                                  m.Productotexto2,
                                  m.Productotexto3,
                                  m.Productotexto4,
                                  m.Productotexto5,
                                  m.Productotexto6,
                                  m.Productonumero1,
                                  m.Productonumero2,
                                  m.Productonumero3,
                                  m.Productonumero4,
                                  m.Fecha1,
                                  m.Fecha2,
                                  m.Pzacaja,
                                  m.Almacenid,
                                  m.Almacenclave,
                                  m.Almacennombre,
                                  m.Lote,
                                  m.Fechavence,
                                  m.Loteimportado,
                                  m.CantidadTeorica,
                                  m.CantidadSurtida,
                                  m.Movtoid,
Math.Truncate(m.CantidadSurtida / m.Pzacaja),
m.CantidadSurtida - (Math.Truncate(m.CantidadSurtida / m.Pzacaja) * m.Pzacaja),
Math.Truncate(m.CantidadTeorica / m.Pzacaja),
m.CantidadTeorica - (Math.Truncate(m.CantidadTeorica / m.Pzacaja) * m.Pzacaja),
m.CantidadSurtida - m.CantidadTeorica,
                                   null,
                                   null,
                                   null,
                                   null,
                                   m.CantidadSurtida



                              )).ToList()
                              ;






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



        public List<Inventario_movto_detalles_xloc> Inventario_movto_detalles_xloc(
                            long empresaId,
                            long sucursalId,
                            long? almacenId,
                            long? doctoId,
                            bool solodiferencias,
                            bool todoslosproductos,
                            bool kitDesglosado,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                

                var lstInventarioDesglose_buffer = Inventario_Desglose(empresaId, sucursalId,
                                                                almacenId, kitDesglosado,
                                                                todoslosproductos ? null : doctoId, 
                                                                null, 
                                                                localContext);
                var locationsProducto = localContext.Productolocations.AsNoTracking()
                                                    .Include(p => p.Producto)
                                                    .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                                    .Select(p => new Inv_Localidad()
                                                    { 
                                                       EmpresaId = p.EmpresaId,
                                                       SucursalId = p.SucursalId,
                                                       Productoid = p.Productoid ?? 0L,
                                                       Localidad = Convert.ToString(p.Localidad ?? ""),
                                                       Anaquelid = (long?)p.Anaquelid
                                                    });

                var locationsProductoLibre = localContext.Producto.AsNoTracking()
                                                    .Include(p => p.Producto_inventario)
                                                    .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Producto_inventario!.Inventariable == BoolCS.S)
                                                    .Select(p => new Inv_Localidad()
                                                    {

                                                        EmpresaId = p.EmpresaId,
                                                        SucursalId = p.SucursalId,
                                                        Productoid = p.Id,
                                                        Localidad = Convert.ToString("Libre"),
                                                        Anaquelid = (long?)null
                                                    });



                locationsProducto = locationsProducto!.Concat(locationsProductoLibre);


                var lstInventarioDesglose = from inventario in lstInventarioDesglose_buffer
                                            join locations in locationsProducto
                                                on new
                                                {
                                                    inventario.EmpresaId,
                                                    inventario.SucursalId,
                                                    inventario.ProductoId
                                                } equals new
                                                {
                                                    locations.EmpresaId,
                                                    locations.SucursalId,
                                                    ProductoId = locations.Productoid 
                                                } into joinedLocations
                                            from locations in joinedLocations.DefaultIfEmpty()
                                            select new InventarioDesglose_x_loc()
                                            {

                                                EmpresaId = inventario.EmpresaId,
                                                SucursalId = inventario.SucursalId,
                                                ProductoId = inventario.ProductoId,
                                                Almacenid = inventario.Almacenid,
                                                Lote = inventario.Lote,
                                                Fechavence = inventario.Fechavence,
                                                Loteimportado = inventario.Loteimportado,
                                                Esapartado = inventario.Esapartado,
                                                Movtoid = inventario.Movtoid,
                                                CantidadTeorica = Convert.ToDecimal(inventario.CantidadTeorica),
                                                CantidadSurtida = Convert.ToDecimal(inventario.CantidadSurtida),
                                                Localidad = Convert.ToString(locations.Localidad),
                                                Anaquelid = locations.Anaquelid

                                            };



                var lstInventarioMovtoDesglose = Inventario_Movto_Desglose_X_Loc(empresaId, sucursalId,
                                                                            doctoId, almacenId,
                                                                            kitDesglosado, localContext);



                var lstInventarioConcatenated = lstInventarioDesglose.Concat(lstInventarioMovtoDesglose);


                var lstInventario = lstInventarioConcatenated.GroupBy(l =>
                                                                new {
                                                                    l.EmpresaId,
                                                                    l.SucursalId,
                                                                    l.ProductoId,
                                                                    l.Almacenid,
                                                                    l.Lote,
                                                                    l.Fechavence,
                                                                    l.Loteimportado,
                                                                    l.Localidad,
                                                                    l.Anaquelid
                                                                })
                                                                .Select(l => new {
                                                                    l.Key.EmpresaId,
                                                                    l.Key.SucursalId,
                                                                    l.Key.ProductoId,
                                                                    l.Key.Almacenid,
                                                                    l.Key.Lote,
                                                                    l.Key.Fechavence,
                                                                    l.Key.Loteimportado,
                                                                    l.Key.Localidad,
                                                                    l.Key.Anaquelid,
                                                                    Movtoid = l.Sum(r => r.Movtoid),
                                                                    CantidadTeorica = l.Sum(r => r.CantidadTeorica),
                                                                    CantidadSurtida = l.Sum(r => r.CantidadSurtida)
                                                                });





                var lstProductoInfo = localContext.Producto.AsNoTracking()
                                                          .Include(p => p.Sucursal)
                                                          .Include(p => p.Producto_inventario)
                                                          .Include(p => p.Producto_kit)
                                                          .Include(p => p.Producto_precios)
                                                          .Include(p => p.Unidad)
                                                          .Include(p => p.Producto_existencia)
                                                          .Include(p => p.Productocaracteristicas)
                                                          .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                      d.Producto_inventario!.Inventariable == BoolCS.S)
                                                          .Select(p => new
                                                          {
                                                              EmpresaId = p.EmpresaId,
                                                              SucursalId = p.SucursalId,
                                                              Sucursalclave = p.Sucursal.Clave,
                                                              Sucursalnombre = p.Sucursal.Nombre,
                                                              ProductoId = p.Id,
                                                              Productoclave = p.Clave,
                                                              Productonombre = p.Nombre,
                                                              Productodescripcion = p.Descripcion1,
                                                              Productotexto1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto1,
                                                              Productotexto2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto2,
                                                              Productotexto3 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto3,
                                                              Productotexto4 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto4,
                                                              Productotexto5 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto5,
                                                              Productotexto6 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto6,
                                                              Productonumero1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero1,
                                                              Productonumero2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero2,
                                                              Productonumero3 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero3,
                                                              Productonumero4 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero4,
                                                              Fecha1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Fecha1,
                                                              Fecha2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Fecha2,

                                                              Pzacaja = p.Producto_inventario != null && p.Producto_inventario.Pzacaja != 0 ? p.Producto_inventario.Pzacaja : 1m
                                                          });

                var buffer_result =
                                           from productoInfo in lstProductoInfo
                                           join inventarioDirecto in lstInventario
                                                on new
                                                {
                                                    productoInfo.EmpresaId,
                                                    productoInfo.SucursalId,
                                                    productoInfo.ProductoId
                                                } equals new
                                                {
                                                    inventarioDirecto.EmpresaId,
                                                    inventarioDirecto.SucursalId,
                                                    inventarioDirecto.ProductoId
                                                } into joinedInventarioDirecto
                                           from inventarioDirecto in joinedInventarioDirecto
                                           join almacen in localContext.Almacen.AsNoTracking().Where(a => a.EmpresaId == empresaId && a.SucursalId == sucursalId)
                                           on inventarioDirecto.Almacenid equals almacen.Id into joinedAlmacen
                                           from almacen in joinedAlmacen.DefaultIfEmpty()
                                           join anaquel in localContext.Anaquel.AsNoTracking().Where(a => a.EmpresaId == empresaId && a.SucursalId == sucursalId)
                                           on inventarioDirecto.Anaquelid equals anaquel.Id into joinedAnaquel
                                           from anaquel in joinedAnaquel.DefaultIfEmpty()
                                           select new
                                           {
                                               productoInfo.EmpresaId,
                                               productoInfo.SucursalId,
                                               productoInfo.Sucursalclave,
                                               productoInfo.Sucursalnombre,
                                               productoInfo.ProductoId,
                                               productoInfo.Productoclave,
                                               productoInfo.Productonombre,
                                               productoInfo.Productodescripcion,
                                               productoInfo.Productotexto1,
                                               productoInfo.Productotexto2,
                                               productoInfo.Productotexto3,
                                               productoInfo.Productotexto4,
                                               productoInfo.Productotexto5,
                                               productoInfo.Productotexto6,
                                               productoInfo.Productonumero1,
                                               productoInfo.Productonumero2,
                                               productoInfo.Productonumero3,
                                               productoInfo.Productonumero4,
                                               productoInfo.Fecha1,
                                               productoInfo.Fecha2,
                                               productoInfo.Pzacaja,

                                               inventarioDirecto.Almacenid,
                                               Almacenclave = almacen.Clave,
                                               Almacennombre = almacen.Nombre,
                                               inventarioDirecto.Lote,
                                               inventarioDirecto.Fechavence,
                                               inventarioDirecto.Loteimportado,

                                               inventarioDirecto.Localidad,
                                               inventarioDirecto.Anaquelid,
                                               Anaquelclave = anaquel.Clave,
                                               Anaquelnombre = anaquel.Nombre,

                                               inventarioDirecto.CantidadTeorica,
                                               inventarioDirecto.CantidadSurtida,
                                               inventarioDirecto.Movtoid



                                           } into mainQry
                                           group mainQry by new
                                           {
                                               mainQry.EmpresaId,
                                               mainQry.SucursalId,
                                               mainQry.Sucursalclave,
                                               mainQry.Sucursalnombre,
                                               mainQry.ProductoId,
                                               mainQry.Productoclave,
                                               mainQry.Productonombre,
                                               mainQry.Productodescripcion,
                                               mainQry.Productotexto1,
                                               mainQry.Productotexto2,
                                               mainQry.Productotexto3,
                                               mainQry.Productotexto4,
                                               mainQry.Productotexto5,
                                               mainQry.Productotexto6,
                                               mainQry.Productonumero1,
                                               mainQry.Productonumero2,
                                               mainQry.Productonumero3,
                                               mainQry.Productonumero4,
                                               mainQry.Fecha1,
                                               mainQry.Fecha2,
                                               mainQry.Pzacaja,
                                               mainQry.Almacenid,
                                               mainQry.Almacenclave,
                                               mainQry.Almacennombre,
                                               mainQry.Lote,
                                               mainQry.Fechavence,
                                               mainQry.Loteimportado,
                                               mainQry.Localidad,
                                               mainQry.Anaquelid,
                                               mainQry.Anaquelclave,
                                               mainQry.Anaquelnombre
                                           } into mainQryGroup
                                           select new
                                           {
                                               mainQryGroup.Key.EmpresaId,
                                               mainQryGroup.Key.SucursalId,
                                               mainQryGroup.Key.Sucursalclave,
                                               mainQryGroup.Key.Sucursalnombre,
                                               mainQryGroup.Key.ProductoId,
                                               mainQryGroup.Key.Productoclave,
                                               mainQryGroup.Key.Productonombre,
                                               mainQryGroup.Key.Productodescripcion,
                                               mainQryGroup.Key.Productotexto1,
                                               mainQryGroup.Key.Productotexto2,
                                               mainQryGroup.Key.Productotexto3,
                                               mainQryGroup.Key.Productotexto4,
                                               mainQryGroup.Key.Productotexto5,
                                               mainQryGroup.Key.Productotexto6,
                                               mainQryGroup.Key.Productonumero1,
                                               mainQryGroup.Key.Productonumero2,
                                               mainQryGroup.Key.Productonumero3,
                                               mainQryGroup.Key.Productonumero4,
                                               mainQryGroup.Key.Fecha1,
                                               mainQryGroup.Key.Fecha2,
                                               mainQryGroup.Key.Pzacaja,
                                               mainQryGroup.Key.Almacenid,
                                               mainQryGroup.Key.Almacenclave,
                                               mainQryGroup.Key.Almacennombre,
                                               mainQryGroup.Key.Lote,
                                               mainQryGroup.Key.Fechavence,
                                               mainQryGroup.Key.Loteimportado,
                                               mainQryGroup.Key.Localidad,
                                               mainQryGroup.Key.Anaquelid,
                                               mainQryGroup.Key.Anaquelclave,
                                               mainQryGroup.Key.Anaquelnombre,
                                               CantidadTeorica = mainQryGroup.Sum(m => m.CantidadTeorica),
                                               CantidadSurtida = mainQryGroup.Sum(m => m.CantidadSurtida),
                                               Movtoid = mainQryGroup.Sum(m => m.Movtoid)

                                           };

                var buffer_main = buffer_result.ToList();
                var buffer_aux = buffer_main.GroupBy(b => new
                {
                    b.EmpresaId,
                    b.SucursalId,
                    b.ProductoId,
                    b.Almacenid,
                    b.Lote,
                    b.Fechavence,
                    b.Loteimportado

                }).Select(g => new
                {
                    g.Key.EmpresaId,
                    g.Key.SucursalId,
                    g.Key.ProductoId,
                    g.Key.Almacenid,
                    g.Key.Lote,
                    g.Key.Fechavence,
                    g.Key.Loteimportado,
                    CantidadTeorica = g.Sum(l => l.CantidadTeorica ),
                    CantidadDiferencia = g.Sum(l => l.CantidadSurtida) - g.Sum(l => l.CantidadTeorica)
                });

                var buffer_final =
                                           from mainInfo in buffer_main
                                           join auxInfo in buffer_aux
                                                on new
                                                {
                                                    mainInfo.EmpresaId,
                                                    mainInfo.SucursalId,
                                                    mainInfo.ProductoId,
                                                    mainInfo.Almacenid,
                                                    mainInfo.Lote,
                                                    mainInfo.Fechavence,
                                                    mainInfo.Loteimportado
                                                } equals new
                                                {
                                                    auxInfo.EmpresaId,
                                                    auxInfo.SucursalId,
                                                    auxInfo.ProductoId,
                                                    auxInfo.Almacenid,
                                                    auxInfo.Lote,
                                                    auxInfo.Fechavence,
                                                    auxInfo.Loteimportado
                                                } into joinedMainAux
                                           from auxInfo in joinedMainAux.DefaultIfEmpty()
                                           select new
                                           {
                                               mainInfo.EmpresaId,
                                               mainInfo.SucursalId,
                                               mainInfo.Sucursalclave,
                                               mainInfo.Sucursalnombre,
                                               mainInfo.ProductoId,
                                               mainInfo.Productoclave,
                                               mainInfo.Productonombre,
                                               mainInfo.Productodescripcion,
                                               mainInfo.Productotexto1,
                                               mainInfo.Productotexto2,
                                               mainInfo.Productotexto3,
                                               mainInfo.Productotexto4,
                                               mainInfo.Productotexto5,
                                               mainInfo.Productotexto6,
                                               mainInfo.Productonumero1,
                                               mainInfo.Productonumero2,
                                               mainInfo.Productonumero3,
                                               mainInfo.Productonumero4,
                                               mainInfo.Fecha1,
                                               mainInfo.Fecha2,
                                               mainInfo.Pzacaja,
                                               mainInfo.Almacenid,
                                               mainInfo.Almacenclave,
                                               mainInfo.Almacennombre,
                                               mainInfo.Lote,
                                               mainInfo.Fechavence,
                                               mainInfo.Loteimportado,
                                               mainInfo.Localidad,
                                               mainInfo.Anaquelid,
                                               mainInfo.Anaquelclave,
                                               mainInfo.Anaquelnombre,
                                               auxInfo.CantidadTeorica,
                                               mainInfo.CantidadSurtida,
                                               mainInfo.Movtoid ,
                                               auxInfo.CantidadDiferencia

                                           };
               
                var retorno = buffer_final.Where(r => (r.Movtoid > 0 || todoslosproductos) &&
                                    (r.CantidadTeorica != r.CantidadSurtida || !solodiferencias)
                              ).ToList()
                              .Select(m => new Inventario_movto_detalles_xloc(

                                  m.EmpresaId,
                                  m.SucursalId,
                                  m.Sucursalclave,
                                  m.Sucursalnombre,
                                  m.ProductoId,
                                  m.Productoclave,
                                  m.Productonombre,
                                  m.Productodescripcion,
                                  m.Productotexto1,
                                  m.Productotexto2,
                                  m.Productotexto3,
                                  m.Productotexto4,
                                  m.Productotexto5,
                                  m.Productotexto6,
                                  m.Productonumero1,
                                  m.Productonumero2,
                                  m.Productonumero3,
                                  m.Productonumero4,
                                  m.Fecha1,
                                  m.Fecha2,
                                  m.Pzacaja,
                                  m.Almacenid,
                                  m.Almacenclave,
                                  m.Almacennombre,
                                  m.Lote,
                                  m.Fechavence,
                                  m.Loteimportado,
                                  m.CantidadTeorica,
                                  m.CantidadSurtida,
                                  m.Movtoid,
Math.Truncate(m.CantidadSurtida / m.Pzacaja),
m.CantidadSurtida - (Math.Truncate(m.CantidadSurtida / m.Pzacaja) * m.Pzacaja),
Math.Truncate(m.CantidadTeorica / m.Pzacaja),
m.CantidadTeorica - (Math.Truncate(m.CantidadTeorica / m.Pzacaja) * m.Pzacaja),
m.CantidadDiferencia,
                                   m.Localidad,
                                   m.Anaquelid,
                                   m.Anaquelclave,
                                   m.Anaquelnombre,
                                   m.CantidadSurtida


                              )).ToList()
                              ;

                return retorno;




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




        public List<Tmp_Inventario_movto_detalles_x_loc_grouped> Inventario_movto_detalles_x_loc_grouped(
                            long empresaId,
                            long sucursalId,
                            long? almacenId,
                            long? doctoId,
                            bool solodiferencias,
                            bool todoslosproductos,
                            bool kitDesglosado,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {



                var lstInventarioDesglose = Inventario_Desglose(empresaId, sucursalId,
                                                                almacenId, kitDesglosado,
                                                                todoslosproductos ? null : doctoId,  
                                                                null,
                                                                localContext);

                var lstInventarioMovtoDesglose = Inventario_Movto_Desglose_x_loc_grouped(empresaId, sucursalId,
                                                                            doctoId, almacenId,
                                                                            kitDesglosado, localContext);

                var lstInventarioConcatenated = lstInventarioDesglose.Concat(lstInventarioMovtoDesglose);



                var lstInventario = lstInventarioConcatenated.GroupBy(l =>
                                                                new {
                                                                    l.EmpresaId,
                                                                    l.SucursalId,
                                                                    l.ProductoId,
                                                                    l.Almacenid,
                                                                    l.Lote,
                                                                    l.Fechavence,
                                                                    l.Loteimportado
                                                                })
                                                                .Select(l => new {
                                                                    l.Key.EmpresaId,
                                                                    l.Key.SucursalId,
                                                                    l.Key.ProductoId,
                                                                    l.Key.Almacenid,
                                                                    l.Key.Lote,
                                                                    l.Key.Fechavence,
                                                                    l.Key.Loteimportado,
                                                                    Movtoid = l.Sum(r => r.Movtoid),
                                                                    CantidadTeorica = l.Sum(r => r.CantidadTeorica),
                                                                    CantidadSurtida = l.Sum(r => r.CantidadSurtida)
                                                                });



                var lstProductoInfo = localContext.Producto.AsNoTracking()
                                                          .Include(p => p.Sucursal)
                                                          .Include(p => p.Producto_inventario)
                                                          .Include(p => p.Producto_kit)
                                                          .Include(p => p.Producto_precios)
                                                          .Include(p => p.Unidad)
                                                          .Include(p => p.Producto_existencia)
                                                          .Include(p => p.Productocaracteristicas)
                                                          .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                      d.Producto_inventario!.Inventariable == BoolCS.S)
                                                          .Select(p => new
                                                          {
                                                              EmpresaId = p.EmpresaId,
                                                              SucursalId = p.SucursalId,
                                                              Sucursalclave = p.Sucursal.Clave,
                                                              Sucursalnombre = p.Sucursal.Nombre,
                                                              ProductoId = p.Id,
                                                              Productoclave = p.Clave,
                                                              Productonombre = p.Nombre,
                                                              Productodescripcion = p.Descripcion1,
                                                              Productotexto1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto1,
                                                              Productotexto2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto2,
                                                              Productotexto3 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto3,
                                                              Productotexto4 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto4,
                                                              Productotexto5 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto5,
                                                              Productotexto6 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Texto6,
                                                              Productonumero1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero1,
                                                              Productonumero2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero2,
                                                              Productonumero3 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero3,
                                                              Productonumero4 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Numero4,
                                                              Fecha1 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Fecha1,
                                                              Fecha2 = p.Productocaracteristicas == null ? null : p.Productocaracteristicas.Fecha2,

                                                              Pzacaja = p.Producto_inventario != null && p.Producto_inventario.Pzacaja != 0 ? p.Producto_inventario.Pzacaja : 1m
                                                          });

                var buffer_result =
                                           from productoInfo in lstProductoInfo
                                           join inventarioDirecto in lstInventario
                                                on new
                                                {
                                                    productoInfo.EmpresaId,
                                                    productoInfo.SucursalId,
                                                    productoInfo.ProductoId
                                                } equals new
                                                {
                                                    inventarioDirecto.EmpresaId,
                                                    inventarioDirecto.SucursalId,
                                                    inventarioDirecto.ProductoId
                                                } into joinedInventarioDirecto
                                           from inventarioDirecto in joinedInventarioDirecto
                                           join almacen in localContext.Almacen.AsNoTracking().Where(a => a.EmpresaId == empresaId && a.SucursalId == sucursalId)
                                           on inventarioDirecto.Almacenid equals almacen.Id into joinedAlmacen
                                           from almacen in joinedAlmacen.DefaultIfEmpty()
                                           select new
                                           {
                                               productoInfo.EmpresaId,
                                               productoInfo.SucursalId,
                                               productoInfo.Sucursalclave,
                                               productoInfo.Sucursalnombre,
                                               productoInfo.ProductoId,
                                               productoInfo.Productoclave,
                                               productoInfo.Productonombre,
                                               productoInfo.Productodescripcion,
                                               productoInfo.Productotexto1,
                                               productoInfo.Productotexto2,
                                               productoInfo.Productotexto3,
                                               productoInfo.Productotexto4,
                                               productoInfo.Productotexto5,
                                               productoInfo.Productotexto6,
                                               productoInfo.Productonumero1,
                                               productoInfo.Productonumero2,
                                               productoInfo.Productonumero3,
                                               productoInfo.Productonumero4,
                                               productoInfo.Fecha1,
                                               productoInfo.Fecha2,
                                               productoInfo.Pzacaja,

                                               inventarioDirecto.Almacenid,
                                               Almacenclave = almacen.Clave,
                                               Almacennombre = almacen.Nombre,
                                               inventarioDirecto.Lote,
                                               inventarioDirecto.Fechavence,
                                               inventarioDirecto.Loteimportado,

                                               inventarioDirecto.CantidadTeorica,
                                               inventarioDirecto.CantidadSurtida,
                                               inventarioDirecto.Movtoid



                                           } into mainQry
                                           group mainQry by new
                                           {
                                               mainQry.EmpresaId,
                                               mainQry.SucursalId,
                                               mainQry.Sucursalclave,
                                               mainQry.Sucursalnombre,
                                               mainQry.ProductoId,
                                               mainQry.Productoclave,
                                               mainQry.Productonombre,
                                               mainQry.Productodescripcion,
                                               mainQry.Productotexto1,
                                               mainQry.Productotexto2,
                                               mainQry.Productotexto3,
                                               mainQry.Productotexto4,
                                               mainQry.Productotexto5,
                                               mainQry.Productotexto6,
                                               mainQry.Productonumero1,
                                               mainQry.Productonumero2,
                                               mainQry.Productonumero3,
                                               mainQry.Productonumero4,
                                               mainQry.Fecha1,
                                               mainQry.Fecha2,
                                               mainQry.Pzacaja,
                                               mainQry.Almacenid,
                                               mainQry.Almacenclave,
                                               mainQry.Almacennombre,
                                               mainQry.Lote,
                                               mainQry.Fechavence,
                                               mainQry.Loteimportado
                                           } into mainQryGroup
                                           select new
                                           {
                                               mainQryGroup.Key.EmpresaId,
                                               mainQryGroup.Key.SucursalId,
                                               mainQryGroup.Key.Sucursalclave,
                                               mainQryGroup.Key.Sucursalnombre,
                                               mainQryGroup.Key.ProductoId,
                                               mainQryGroup.Key.Productoclave,
                                               mainQryGroup.Key.Productonombre,
                                               mainQryGroup.Key.Productodescripcion,
                                               mainQryGroup.Key.Productotexto1,
                                               mainQryGroup.Key.Productotexto2,
                                               mainQryGroup.Key.Productotexto3,
                                               mainQryGroup.Key.Productotexto4,
                                               mainQryGroup.Key.Productotexto5,
                                               mainQryGroup.Key.Productotexto6,
                                               mainQryGroup.Key.Productonumero1,
                                               mainQryGroup.Key.Productonumero2,
                                               mainQryGroup.Key.Productonumero3,
                                               mainQryGroup.Key.Productonumero4,
                                               mainQryGroup.Key.Fecha1,
                                               mainQryGroup.Key.Fecha2,
                                               mainQryGroup.Key.Pzacaja,
                                               mainQryGroup.Key.Almacenid,
                                               mainQryGroup.Key.Almacenclave,
                                               mainQryGroup.Key.Almacennombre,
                                               mainQryGroup.Key.Lote,
                                               mainQryGroup.Key.Fechavence,
                                               mainQryGroup.Key.Loteimportado,
                                               CantidadTeorica = mainQryGroup.Sum(m => m.CantidadTeorica),
                                               CantidadSurtida = mainQryGroup.Sum(m => m.CantidadSurtida),
                                               Movtoid = mainQryGroup.Sum(m => m.Movtoid)

                                           };



                var buffer_main = buffer_result.ToList();
                var buffer_aux = buffer_main.GroupBy(b => new
                {
                    b.EmpresaId,
                    b.SucursalId,
                    b.ProductoId,
                    b.Almacenid,
                    b.Lote,
                    b.Fechavence,
                    b.Loteimportado

                }).Select(g => new
                {
                    g.Key.EmpresaId,
                    g.Key.SucursalId,
                    g.Key.ProductoId,
                    g.Key.Almacenid,
                    g.Key.Lote,
                    g.Key.Fechavence,
                    g.Key.Loteimportado,
                    CantidadTeorica = g.Sum(l => l.CantidadTeorica),
                    CantidadDiferencia = g.Sum(l => l.CantidadSurtida) - g.Sum(l => l.CantidadTeorica)
                });

                var buffer_final =
                                           from mainInfo in buffer_main
                                           join auxInfo in buffer_aux
                                                on new
                                                {
                                                    mainInfo.EmpresaId,
                                                    mainInfo.SucursalId,
                                                    mainInfo.ProductoId,
                                                    mainInfo.Almacenid,
                                                    mainInfo.Lote,
                                                    mainInfo.Fechavence,
                                                    mainInfo.Loteimportado
                                                } equals new
                                                {
                                                    auxInfo.EmpresaId,
                                                    auxInfo.SucursalId,
                                                    auxInfo.ProductoId,
                                                    auxInfo.Almacenid,
                                                    auxInfo.Lote,
                                                    auxInfo.Fechavence,
                                                    auxInfo.Loteimportado
                                                } into joinedMainAux
                                           from auxInfo in joinedMainAux.DefaultIfEmpty()
                                           select new
                                           {
                                               mainInfo.EmpresaId,
                                               mainInfo.SucursalId,
                                               mainInfo.Sucursalclave,
                                               mainInfo.Sucursalnombre,
                                               mainInfo.ProductoId,
                                               mainInfo.Productoclave,
                                               mainInfo.Productonombre,
                                               mainInfo.Productodescripcion,
                                               mainInfo.Productotexto1,
                                               mainInfo.Productotexto2,
                                               mainInfo.Productotexto3,
                                               mainInfo.Productotexto4,
                                               mainInfo.Productotexto5,
                                               mainInfo.Productotexto6,
                                               mainInfo.Productonumero1,
                                               mainInfo.Productonumero2,
                                               mainInfo.Productonumero3,
                                               mainInfo.Productonumero4,
                                               mainInfo.Fecha1,
                                               mainInfo.Fecha2,
                                               mainInfo.Pzacaja,
                                               mainInfo.Almacenid,
                                               mainInfo.Almacenclave,
                                               mainInfo.Almacennombre,
                                               mainInfo.Lote,
                                               mainInfo.Fechavence,
                                               mainInfo.Loteimportado,
                                               auxInfo.CantidadTeorica,
                                               mainInfo.CantidadSurtida,
                                               mainInfo.Movtoid,
                                               auxInfo.CantidadDiferencia

                                           };

                var retorno = buffer_final.Where(r => (r.Movtoid > 0 || todoslosproductos) &&
                                    (r.CantidadTeorica != r.CantidadSurtida || !solodiferencias)
                              ).ToList()
                              .Select(m => new Tmp_Inventario_movto_detalles_x_loc_grouped(

                                  m.EmpresaId,
                                  m.SucursalId,
                                  m.Sucursalclave,
                                  m.Sucursalnombre,
                                  m.ProductoId,
                                  m.Productoclave,
                                  m.Productonombre,
                                  m.Productodescripcion,
                                  m.Productotexto1,
                                  m.Productotexto2,
                                  m.Productotexto3,
                                  m.Productotexto4,
                                  m.Productotexto5,
                                  m.Productotexto6,
                                  m.Productonumero1,
                                  m.Productonumero2,
                                  m.Productonumero3,
                                  m.Productonumero4,
                                  m.Fecha1,
                                  m.Fecha2,
                                  m.Pzacaja,
                                  m.Almacenid,
                                  m.Almacenclave,
                                  m.Almacennombre,
                                  m.Lote,
                                  m.Fechavence,
                                  m.Loteimportado,
                                  m.CantidadTeorica,
                                  m.CantidadSurtida,
                                  m.Movtoid,
Math.Truncate(m.CantidadSurtida / m.Pzacaja),
m.CantidadSurtida - (Math.Truncate(m.CantidadSurtida / m.Pzacaja) * m.Pzacaja),
Math.Truncate(m.CantidadTeorica / m.Pzacaja),
m.CantidadTeorica - (Math.Truncate(m.CantidadTeorica / m.Pzacaja) * m.Pzacaja),
m.CantidadDiferencia


                              )).ToList()
                              ;



                return retorno;


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

        public void Inventario_movto_getInfo(
                            long empresaId,
                            long sucursalId,
                            long productoId,
                            string? lote,
                            DateTimeOffset? fechavence,
                            long? doctoId,
                            long? almacenId,
                            bool kitDesglosado,
                            bool mododetalle,
                            out string? v_productonombre ,
                            out string? v_productodescripcion ,
                            out string? v_productolote ,
                            out decimal? v_cantidadteorica ,
                            out decimal? v_cantidadfisica ,
                            out decimal? v_cantidaddiferencia ,
                            out decimal? v_apartados ,
                            out decimal? v_pzacaja ,

                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            v_productonombre = "";
            v_productodescripcion = "";
            v_productolote = lote;
            v_cantidadteorica = 0;
            v_cantidadfisica = 0;
            v_cantidaddiferencia = 0;
            v_apartados = 0;
            v_pzacaja = 0;

            try
            {

                var productoInfo = localContext.Producto.AsNoTracking()
                                               .Include(p => p.Producto_inventario)
                                               .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId);

                if (productoInfo == null)
                    throw new Exception("El producto no se encontro");

                v_productonombre = productoInfo.Nombre;
                v_productodescripcion = productoInfo.Descripcion1;
                v_pzacaja = productoInfo.Producto_inventario?.Pzacaja;

                if(doctoId != null)
                {

                    v_cantidadfisica = localContext.Movto.AsNoTracking()
                                .Include(m => m.Movto_inventario)
                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId &&
                                            m.Productoid == productoId &&
                                            (m.Producto!.Producto_inventario!.Manejalote != BoolCN.S ||
                                              (
                                                m.Lote == lote && m.Fechavence == fechavence
                                              ))
                                       )
                                .Select(m => m.Movto_inventario!.Cantidad_real)
                                .Sum();



                }

                if(mododetalle)
                {

                    var lstInventarioDesglose = Inventario_Desglose(empresaId, sucursalId,
                                                                    almacenId, kitDesglosado,
                                                                    null, 
                                                                    productoId,
                                                                    localContext);
                    var sumasApartadosTeoricos =  lstInventarioDesglose.Where(p => p.ProductoId == productoId)
                                         .GroupBy(p => p.ProductoId)
                                         .Select(p => new
                                         {
                                             CantidadTeorica = p.Sum(s => s.CantidadTeorica),
                                             Apartados = (p.Sum(s => s.Esapartado == BoolCN.S ? s.CantidadTeorica : 0m))
                                         }).FirstOrDefault();

                    v_cantidadteorica = sumasApartadosTeoricos?.CantidadTeorica ?? 0m;
                    v_apartados = sumasApartadosTeoricos?.Apartados ?? 0m;



                }


                v_cantidaddiferencia = v_cantidadfisica - v_cantidadteorica;







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



        public List<Tmp_Inventario_movto_loteInfo> Inventario_movto_loteInfo(
                            long empresaId,
                            long sucursalId,
                            long productoId,
                            long? doctoId,
                            bool soloconexistencias,
                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                var lstInventarioDesglose = Inventario_Desglose(empresaId, sucursalId,
                                                                null, false,
                                                                null,
                                                                productoId, 
                                                                localContext)
                                            .Where(p => p.ProductoId == productoId && (!soloconexistencias || p.CantidadTeorica > 0));

                var lstInventarioMovtoDesglose = Inventario_Movto_Desglose(empresaId, sucursalId,
                                                                            doctoId, null,
                                                                            false,
                                                                            productoId, 
                                                                            localContext)
                                            .Where(p => p.ProductoId == productoId && (!soloconexistencias || p.CantidadSurtida > 0)); 

                var lstLotesConcatenated = lstInventarioDesglose.Concat(lstInventarioMovtoDesglose)
                                                                     .GroupBy(l => new
                                                                     {
                                                                         l.EmpresaId,
                                                                         l.SucursalId,
                                                                         l.ProductoId,
                                                                         l.Lote,
                                                                         l.Fechavence
                                                                     })
                                                                     .Select( l => new Tmp_Inventario_movto_loteInfo(
                                                                         l.Key.EmpresaId,
                                                                         l.Key.SucursalId,
                                                                         l.Key.ProductoId,
                                                                         l.Key.Lote,
                                                                         l.Key.Fechavence,
(l.Key.Lote != null ? l.Key.Lote : "") + (l.Key.Fechavence != null ? l.Key.Fechavence.Value.ToString("dd_MM_yyyy", System.Globalization.CultureInfo.InvariantCulture) : "")

                                                                     ))
                                                                     ;




                return lstLotesConcatenated.ToList()
                              ;






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

        public void Inventario_docto_insert(
            long empresaId, 
            long sucursalId,
            long creadopor_userid,
            long estatusDoctoId,
            long usuarioId ,
            DateTimeOffset fecha ,
            long cajaid ,
            long almacenid ,
            long tipodoctoid ,
            bool kitdesglosado,
            ref long? doctoId,
            ApplicationDbContext localContext
            )
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var sucursalInfo = localContext.Sucursal_info.AsNoTracking()
                                                .Include(s => s.Sucursal)
                                                .FirstOrDefault(s => s.EmpresaId == empresaId && s.SucursalId == sucursalId && s.Clave == s.Sucursal.Clave);

                if (sucursalInfo == null)
                    throw new Exception("No existe sucursal");

                var doctoTrans = new DoctoTransaction()
                {
                    Empresaid = empresaId,
                    Sucursalid = sucursalId,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = creadopor_userid,
                    Estatusdoctoid = estatusDoctoId,
                    Usuarioid = usuarioId,
                    Corteid = null,
                    Fecha = fecha,
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
                    Cajaid = cajaid,
                    Almacenid = almacenid,
                    Origenfiscalid = DBValues._ORIGENFISCAL_REMISIONADO,
                    Esapartado = BoolCN.N,
                    Doctoparentid = null,
                    Clienteid = null,
                    Tipodoctoid = tipodoctoid,
                    Proveedorid = null,
                    Sucursal_id = sucursalInfo.Id,
                    Referencia = null,
                    Referencias = null,
                    Fechavence = null

                };

                _doctoService.DoctoInsert(doctoTrans, ref doctoId, localContext);


                if ((doctoId ?? 0) == 0)
                    throw new Exception("No se pudo insertar el documento");



                var docto_kit = new Docto_kit()
                {
                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = creadopor_userid,
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = creadopor_userid,
                    Doctoid = doctoId,
                    Kitdesglosado = kitdesglosado? BoolCN.S : BoolCN.N

                };
                localContext.Add(docto_kit);



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





        public void Movto_inventario_group(long empresaId, long sucursalId, long doctoId,
                                            long productoId, 
                                            string? lote, DateTimeOffset? fechaVence, long? loteImportado,
                                            long? anaquelId, string? localidad,
                                            out long? movtoActualId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            movtoActualId = null;

            try
            {

                var bufferMovtoActualId = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_precio)
                                                      .Include(m => m.Movto_inventario)
                                                      .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                  m.Doctoid == doctoId && m.Productoid == productoId &&
                                                                  (m.Lote ?? "") == (lote ?? "") &&
                                                                  ((m.Fechavence == null && fechaVence == null) || m.Fechavence == fechaVence) &&
                                                                  (m.Loteimportado ?? 0) == (loteImportado ?? 0) &&
                                                                  (m.Movto_inventario == null || ((m.Movto_inventario.Anaquelid ?? 0) == (anaquelId ?? 0 ))) &&
                                                                  (m.Movto_inventario == null || ((m.Movto_inventario.Localidad ?? "") == (localidad ?? "")))
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






        public void Movto_inventario_insert(MovtoInventarioTrans movtoProvTrans, ref long? movtoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? movtoexistenteid = null;


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


                    this.Movto_inventario_group(movtoProvTrans.Empresaid, movtoProvTrans.Sucursalid, movtoProvTrans.Doctoid,
                                                 movtoProvTrans.Productoid, 
                                                 movtoProvTrans.Lote, movtoProvTrans.Fechavence, movtoProvTrans.Loteimportado,
                                                 movtoProvTrans.Anaquelid, movtoProvTrans.Localidad,
                                                  out movtoexistenteid, localContext);


                }

                if ((movtoexistenteid ?? 0) == 0)
                {



                    var movtoTransaction = new MovtoTransaccion()
                    {
                        Empresaid = movtoProvTrans.Empresaid,
                        Sucursalid = movtoProvTrans.Sucursalid,
                        Id = 0,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = movtoProvTrans.Usuarioid,
                        Partida = movtoProvTrans.Partida,
                        Estatusmovtoid = movtoProvTrans.Estatusmovtoid,
                        Fecha = DateTimeOffset.Now.Date,
                        Fechahora = DateTimeOffset.Now,
                        Productoid = movtoProvTrans.Productoid,
                        Cantidad = movtoProvTrans.Cantidad,
                        Preciolista = producto_info!.Preciolista,
                        Descuentoporcentaje = movtoProvTrans.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = producto_info!.Preciolista, //precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = producto_info!.Ivaimpuesto,
                        Tasaieps = producto_info!.Iepsimpuesto,
                        Total = 0m,//total,
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
                        Calc_imp_de_total = null,
                        Localidad = movtoProvTrans.Localidad,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = movtoProvTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = movtoProvTrans.Usuarioid,
                        Precioconimp = null,
                        Anaquelid = movtoProvTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoInsert(movtoTransaction, ref movtoId, localContext);

                    var movto_precio = new Movto_precio()
                    {

                        EmpresaId = movtoProvTrans.Empresaid,
                        SucursalId = movtoProvTrans.Sucursalid,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = movtoProvTrans.Usuarioid,
                        Modificado = DateTimeOffset.Now,
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
                        Precioconimp = 0m,//precioconimp ?? 0m,
                        Calc_imp_de_total = null //calc_imp_de_total




                    };

                    localContext.Add(movto_precio);



                        var movto_inventario = new Movto_inventario()
                        {

                            EmpresaId = movtoProvTrans.Empresaid,
                            SucursalId = movtoProvTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoProvTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoProvTrans.Usuarioid,
                            Tipodiferenciainventarioid = null,
                            Localidad = movtoProvTrans.Localidad,
                            Anaquelid = movtoProvTrans.Anaquelid,
                            Registroprocesosalida = BoolCN.N,
                            Movtoid = movtoId,
                            Cantidad_real = movtoProvTrans.Cantidad_real,
                            Cantidad_teorica = 0m,
                            Cantidad_diferencia = 0m
                        };

                        localContext.Add(movto_inventario);

                    localContext.SaveChanges();

                }
                else
                {

                    movtoId = movtoexistenteid;
                    var movto_a_cambiar = localContext.Movto.AsNoTracking()
                                                      .Include(m => m.Movto_inventario)
                                                      .Where(m => m.EmpresaId == movtoProvTrans.Empresaid && m.SucursalId == movtoProvTrans.Sucursalid &&
                                                                  m.Id == movtoexistenteid)
                                                      .Select(m => new
                                                      {
                                                          Precio = (movtoProvTrans.Precio ?? m.Precio),
                                                          Descuentoporcentaje = (movtoProvTrans.Descuentoporcentaje ?? m.Descuentoporcentaje),
                                                          Preciolista = m.Preciolista,
                                                          Lote = m.Lote,
                                                          Fechavence = m.Fechavence,
                                                          Loteimportado = m.Loteimportado,
                                                          Partida = m.Partida,
                                                          Movtoparentid = m.Movtoparentid,
                                                          Cantidad_real = m.Movto_inventario!.Cantidad_real + movtoProvTrans.Cantidad_real,
                                                          TasaIvaRetenido = m.Tasaivaretenido,
                                                          TasaIsrRetenido = m.Tasaisrretenido,
                                                          MovtoInventarioId = m.Movto_inventario.Id


                                                      })
                                                      .FirstOrDefault();

                    if (movto_a_cambiar == null)
                        throw new Exception("El registro se borro inesperadamente");


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
                        Cantidad = movto_a_cambiar.Cantidad_real,
                        Preciolista = movto_a_cambiar.Preciolista,
                        Descuentoporcentaje = movtoProvTrans.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = producto_info!.Preciolista,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = producto_info!.Ivaimpuesto,
                        Tasaieps = producto_info!.Iepsimpuesto,
                        Total = 0m,
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
                        Calc_imp_de_total = null,
                        Localidad = movtoProvTrans.Localidad,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = movtoProvTrans.Agrupaporparametro,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = movtoProvTrans.Usuarioid,
                        Precioconimp = null,
                        Anaquelid = movtoProvTrans.Anaquelid,
                        Movtoadevolverid = null
                    };

                    _doctoMovtoService.MovtoUpdate(movtoTransaction, localContext);



                    if (movto_a_cambiar.Cantidad_real <= 0)
                    {
                        throw new Exception("La cantidad no puede ser cero");
                    }


                    var movto_inv = localContext.Movto_inventario.
                                                FirstOrDefault(m => m.EmpresaId == movtoProvTrans.Empresaid &&
                                                                    m.SucursalId == movtoProvTrans.Sucursalid &&
                                                                    m.Id == movto_a_cambiar.MovtoInventarioId);
                    if(movto_inv == null)
                    {

                        var movto_inventario = new Movto_inventario()
                        {

                            EmpresaId = movtoProvTrans.Empresaid,
                            SucursalId = movtoProvTrans.Sucursalid,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            CreadoPorId = movtoProvTrans.Usuarioid,
                            Modificado = DateTimeOffset.Now,
                            ModificadoPorId = movtoProvTrans.Usuarioid,
                            Tipodiferenciainventarioid = null,
                            Localidad = movtoProvTrans.Localidad,
                            Anaquelid = movtoProvTrans.Anaquelid,
                            Registroprocesosalida = BoolCN.N,
                            Movtoid = movtoId,
                            Cantidad_real = movtoProvTrans.Cantidad_real,
                            Cantidad_teorica = 0m,
                            Cantidad_diferencia = 0m
                        };

                        localContext.Add(movto_inventario);
                    }
                    else
                    {
                        movto_inv.Cantidad_real = movto_a_cambiar.Cantidad_real;
                        movto_inv.Modificado = DateTimeOffset.Now;
                        localContext.Update(movto_inv);
                    }

                    localContext.SaveChanges();

                    //var movtoTransaction = new MovtoTransaccion()
                    //{
                    //    Empresaid = movtoProvTrans.Empresaid,
                    //    Sucursalid = movtoProvTrans.Sucursalid,
                    //    Id = movtoexistenteid!.Value,
                    //    Activo = BoolCS.S,
                    //    Creado = DateTimeOffset.Now,
                    //    Creadopor_userid = movtoProvTrans.Usuarioid,
                    //    Partida = movto_a_cambiar.Partida,
                    //    Estatusmovtoid = movtoProvTrans.Estatusmovtoid,
                    //    Fecha = DateTimeOffset.Now.Date,
                    //    Fechahora = DateTimeOffset.Now,
                    //    Productoid = movtoProvTrans.Productoid,
                    //    Cantidad = 0m,//movto_a_cambiar.Cantidad,
                    //    Preciolista = movto_a_cambiar.Preciolista,
                    //    Descuentoporcentaje = movtoProvTrans.Descuentoporcentaje,
                    //    Descuento = 0m,
                    //    Precio = movto_a_cambiar.Preciolista, //precio,
                    //    Importe = 0m,
                    //    Subtotal = 0m,
                    //    Iva = 0m,
                    //    Ieps = 0m,
                    //    Tasaiva = producto_info!.Ivaimpuesto,
                    //    Tasaieps = producto_info!.Iepsimpuesto,
                    //    Total = 0m,// total,
                    //    Lote = movto_a_cambiar.Lote,
                    //    Fechavence = movto_a_cambiar.Fechavence,
                    //    Loteimportado = movto_a_cambiar.Loteimportado,
                    //    Movtoparentid = movto_a_cambiar.Movtoparentid,
                    //    Movtonivel = 0,
                    //    Afectainventario = BoolCS.S,
                    //    Afectatotales = BoolCS.S,
                    //    Eskit = producto_info!.Eskit,
                    //    Kitimpfijo = producto_info!.Kitimpfijo,
                    //    Doctoid = movtoProvTrans.Doctoid,
                    //    Cargo = 0m,
                    //    Abono = 0m,
                    //    Saldo = 0m,
                    //    Preciomanual = 0m,
                    //    Preciomaximopublico = 0m,
                    //    Isrretenido = 0m,
                    //    Ivaretenido = 0m,
                    //    Orden = 0,
                    //    Tasaisrretenido = 0m,
                    //    Tasaivaretenido = 0m,
                    //    Calc_imp_de_total = null,
                    //    Localidad = movtoProvTrans.Localidad,
                    //    Descripcion1 = null,
                    //    Descripcion2 = null,
                    //    Descripcion3 = null,
                    //    Agrupaporparametro = movtoProvTrans.Agrupaporparametro,
                    //    Cargartarjetapreciomanual = null,
                    //    Precioyavalidado = null,
                    //    Usuarioid = movtoProvTrans.Usuarioid,
                    //    Precioconimp = null,
                    //    Anaquelid = movtoProvTrans.Anaquelid,
                    //    Movtoadevolverid = null
                    //};

                    //_doctoMovtoService.MovtoUpdate(movtoTransaction, localContext);


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



        public void Docto_inventario_insert(DoctoInventarioTrans doctoProvTrans, ref long? doctoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                if (doctoProvTrans.Sucursal_id == 0)
                {
                    var sucursalInfo = localContext.Sucursal_info.AsNoTracking()
                                                    .Include(s => s.Sucursal)
                                                    .FirstOrDefault(s => s.EmpresaId == doctoProvTrans.Empresaid && s.SucursalId == doctoProvTrans.Sucursalid && s.Clave == s.Sucursal.Clave);

                    if (sucursalInfo == null)
                        throw new Exception("No existe sucursal");

                    doctoProvTrans.Sucursal_id = sucursalInfo.Id;
                }



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
                    Cajaid = doctoProvTrans.Cajaid,
                    Almacenid = doctoProvTrans.Almacenid,
                    Origenfiscalid = DBValues._ORIGENFISCAL_REMISIONADO, //doctoProvTrans.Origenfiscalid,
                    Esapartado = BoolCN.N,
                    Doctoparentid = null, //doctoProvTrans.Doctoparentid,
                    Clienteid = null,
                    Tipodoctoid = doctoProvTrans.Tipodoctoid,
                    Proveedorid = null,
                    Sucursal_id = doctoProvTrans.Sucursal_id,
                    Referencia = doctoProvTrans.Referencia,
                    Referencias = doctoProvTrans.Referencias,
                    Fechavence = doctoProvTrans.Fechavence

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


                var docto_kit = new Docto_kit()
                {
                    Modificado = DateTimeOffset.UtcNow,
                    ModificadoPorId = doctoProvTrans.Usuarioid,
                    EmpresaId = doctoProvTrans.Empresaid,
                    SucursalId = doctoProvTrans.Sucursalid,
                    Activo = doctoTrans.Activo,
                    Creado = DateTimeOffset.UtcNow,
                    CreadoPorId = doctoProvTrans.Usuarioid,
                    Doctoid = doctoId,
                    Kitdesglosado = doctoProvTrans.Kitdesglosado

                };
                localContext.Add(docto_kit);



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


        public void Docto_inventario_delete(long empresaId, long sucursalId, long id,
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


        public void Docto_inventario_gencompleto(long empresaId, long sucursalId,
                                                long doctoId, long? almacenId, 
                                                long usuarioId, long subtipodoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var productosEnInventario = localContext.Movto.AsNoTracking()
                                                                                    .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                                                                    .Select(m => new BasicInventario(m.Productoid, m.Lote, m.Fechavence, m.Loteimportado))
                                                                                    .ToList();

                var inventarioOtrosProductos = localContext.Inventario.AsNoTracking()
                                                           .Include(i => i.Producto)
                                                           .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                        (almacenId == null || i.Almacenid == almacenId) &&
                                                                        (i.Cantidad > 0) &&
                                                                        !productosEnInventario.Select(p => p.Productoid).Contains(i.Productoid)
                                                                 )
                                                           .Select(i => new MovtoInventarioTrans()
                                                           {
                                                               Empresaid = i.EmpresaId,
                                                               Sucursalid = i.SucursalId,
                                                               Id = null,
                                                               Doctoid = doctoId,
                                                               Partida = null,
                                                               Estatusmovtoid = DBValues._MOVTO_ESTATUS_BORRADOR,
                                                               Productoid = i.Productoid != null ? i.Productoid.Value: 0,
                                                               Cantidad_real = 0m,
                                                               Descuentoporcentaje = 0m,
                                                               Precio = 0m,
                                                               Lote = i.Lote,
                                                               Fechavence = i.Fechavence,
                                                               Loteimportado = i.Loteimportado,
                                                               Movtoparentid = null,
                                                               Localidad = null,
                                                               Agrupaporparametro = null, 
                                                               Usuarioid = usuarioId,
                                                               Anaquelid  = null

                                                                                }).ToList();


                var inventarioMismosProductos_buffer = localContext.Inventario.AsNoTracking()
                                                           .Include(i => i.Producto)
                                                           .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                        (almacenId == null || i.Almacenid == almacenId) &&
                                                                        (i.Cantidad > 0) &&
                                                                        productosEnInventario.Select(p => p.Productoid).Contains(i.Productoid)
                                                                 )
                                                           .Select(i => new MovtoInventarioTrans()
                                                           {
                                                               Empresaid = i.EmpresaId,
                                                               Sucursalid = i.SucursalId,
                                                               Id = null,
                                                               Doctoid = doctoId,
                                                               Partida = null,
                                                               Estatusmovtoid = DBValues._MOVTO_ESTATUS_BORRADOR,
                                                               Productoid = i.Productoid != null ? i.Productoid.Value : 0,
                                                               Cantidad_real = 0m,
                                                               Descuentoporcentaje = 0m,
                                                               Precio = 0m,
                                                               Lote = i.Lote,
                                                               Fechavence = i.Fechavence,
                                                               Loteimportado = i.Loteimportado,
                                                               Movtoparentid = null,
                                                               Localidad = null,
                                                               Agrupaporparametro = null,
                                                               Usuarioid = usuarioId,
                                                               Anaquelid = null

                                                           }).ToList();

                 var inventarioMismosProductos =     inventarioMismosProductos_buffer.Where( i => !productosEnInventario.Contains(new BasicInventario(i.Productoid, i.Lote, i.Fechavence, i.Loteimportado)))
                                                           .ToList();

                long? movtoId = null;

                if(subtipodoctoId == DBValues._DOCTO_SUBTIPO_INVENTARIOCOMPLETO)
                {
                    foreach(var movtoTrans in inventarioOtrosProductos)
                    {
                        Movto_inventario_insert(movtoTrans, ref movtoId, localContext);
                    }
                }

                if (subtipodoctoId == DBValues._DOCTO_SUBTIPO_INVENTARIOCOMPLETO || subtipodoctoId == DBValues._DOCTO_SUBTIPO_INVENTARIOPARCIALXPRODUCTO)
                {
                    foreach (var movtoTrans in inventarioMismosProductos)
                    {
                        Movto_inventario_insert(movtoTrans, ref movtoId, localContext);
                    }
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


        public void Docto_inventario_precierre(long empresaId, long sucursalId, 
            long doctoId, long? almacenId, 
            long usuarioId, long subtipodoctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var inventarioIdsToUpdate = localContext.Inventario.AsNoTracking()
                                                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                                                        .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                     (almacenId == null || i.Almacenid == almacenId) &&
                                                                   ( i.Lote == null || i.Fechavence == null) && 
                                                                   i.Producto!.Producto_inventario!.Manejalote == BoolCN.S)
                                                        .Select(i => i.Id).ToList();
            
                var movtosToUpdate = localContext.Movto.AsNoTracking()
                                                        .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                                                        .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                   (i.Lote == null || i.Fechavence == null) &&
                                                                   i.Producto!.Producto_inventario!.Manejalote == BoolCN.S)
                                                        .Select(i => i.Id).ToList(); 

                if (inventarioIdsToUpdate != null && inventarioIdsToUpdate.Count() > 0)
                {

                    foreach (var inventarioId in inventarioIdsToUpdate)
                    {
                        var inventarioToUpdate = localContext.Inventario.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                                    inventarioId == i.Id);
                        if (inventarioToUpdate != null)
                        {
                            inventarioToUpdate.Lote = "XXX";
                            inventarioToUpdate.Fechavence = DateTimeOffset.UtcNow.Date;
                            localContext.Update(inventarioToUpdate);
                        }

                    }
                }

                localContext.SaveChanges();


                if (movtosToUpdate != null && movtosToUpdate.Count() > 0)
                {

                    foreach (var movtoId in movtosToUpdate)
                    {
                        var movtoToUpdate = localContext.Movto.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                                    movtoId == i.Id);
                        if (movtoToUpdate != null)
                        {
                            movtoToUpdate.Lote = "XXX";
                            movtoToUpdate.Fechavence = DateTimeOffset.UtcNow.Date;
                            localContext.Update(movtoToUpdate);
                        }

                    }
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



        public void Docto_inventario_setExistencia(long empresaId, long sucursalId, long doctoId, 
            long usuarioId, long? almacenId, 
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var inventarioSumarizado = localContext.Inventario.AsNoTracking()
                    .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                            .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                            (almacenId == null || i.Almacenid == almacenId) &&
                                            i.Esapartado != BoolCN.S)
                            .GroupBy(i => new { i.Productoid, i.Lote, i.Fechavence, i.Loteimportado, i.Producto!.Producto_inventario!.Manejalote })
                            .Select(i => new
                            {
                                i.Key.Productoid,
                                i.Key.Manejalote,
                                i.Key.Lote,
                                i.Key.Fechavence,
                                i.Key.Loteimportado,
                                Cantidad = i.Sum(t => t.Cantidad)


                            });

                var movtos = localContext.Movto.Include(m => m.Movto_inventario).Where(m => m.EmpresaId == empresaId &&
                                                           m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                                .ToList();
                foreach(var movto in movtos)
                {
                    var cantidadInventario = inventarioSumarizado
                                                                .FirstOrDefault(i => i.Productoid == movto.Productoid &&
                                                                            (i.Manejalote != BoolCN.S || (i.Lote == movto.Lote && i.Fechavence == movto.Fechavence)) &&
                                                                            i.Loteimportado == movto.Loteimportado
                                                                        ) ;

                    movto.Cantidad = cantidadInventario?.Cantidad ?? 0m;
                    localContext.Update(movto);

                    if(movto.Movto_inventario != null)
                    {

                        movto.Movto_inventario.Cantidad_teorica = cantidadInventario?.Cantidad ?? 0m;
                        movto.Movto_inventario.Cantidad_diferencia = movto.Movto_inventario.Cantidad_real - movto.Movto_inventario.Cantidad_teorica;
                        localContext.Update(movto.Movto_inventario);

                    }
                    //else
                    //{
                    //    var movto_inventario = new Movto_inventario()
                    //    {

                    //        EmpresaId = empresaId,
                    //        SucursalId = sucursalId,
                    //        Activo = BoolCS.S,
                    //        Creado = DateTimeOffset.Now,
                    //        CreadoPorId = usuarioId,
                    //        Modificado = DateTimeOffset.Now,
                    //        ModificadoPorId = usuarioId,
                    //        Tipodiferenciainventarioid = null,
                    //        Localidad = movtoVenddevoTrans.Localidad,
                    //        Anaquelid = movtoVenddevoTrans.Anaquelid,
                    //        Registroprocesosalida = BoolCN.N,
                    //        Movtoid = movto.Id,
                    //        Cantidad_real = 0m,
                    //        Cantidad_teorica = 0m,
                    //        Cantidad_diferencia = 0m
                    //    };


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





        public void Docto_inventario_dif_generar(long empresaId, long sucursalId, long doctoId, long tipodoctoagenerarid,
            ref long? doctoIdGenerado,
            ApplicationDbContext localContext)
        {





            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            long? movtoIdGenerado = null;

            try
            {
                var docto = localContext.Docto.AsNoTracking()
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("Docto no encontrado");

                if ( !(docto.Tipodoctoid is 50 or 53))
                    throw new Exception("este tipo de documento no puede generar diferencia de inventario");

                if (docto.Estatusdoctoid != 0 && docto.Estatusdoctoid != 3)
                    throw new Exception("este estatus de documento no puede generar diferencia de inventario");



                var movtosAGenerar = localContext.Movto.AsNoTracking()
                                                    .Include(m => m.Movto_inventario)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId &&
                                                       
                                                    (
                                                        (tipodoctoagenerarid == 52 && m.Cantidad > m.Movto_inventario!.Cantidad_real) ||
                                                        (tipodoctoagenerarid == 51 && m.Cantidad < m.Movto_inventario!.Cantidad_real)
                                                       )
                                                    ).ToList();

                foreach (var movtoAGenerar in movtosAGenerar)
                {
                    

                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdGenerado == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Estatusdoctoid = 0,
                            Usuarioid = docto.Usuarioid,
                            Corteid = docto.Corteid,
                            Fecha = docto.Fecha ?? DateTimeOffset.Now,
                            Fechahora = docto.Fechahora ?? DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = docto.Cajaid,
                            Almacenid = docto.Almacenid,
                            Origenfiscalid = docto.Origenfiscalid,
                            Esapartado = docto.Esapartado,
                            Doctoparentid = doctoId,
                            Clienteid = docto.Clienteid,
                            Tipodoctoid = tipodoctoagenerarid,
                            Proveedorid = docto.Proveedorid,
                            Sucursal_id = docto.Sucursal_id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdGenerado, localContext);
                        localContext.SaveChanges();
                    }

                    movtoIdGenerado = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = docto.Usuarioid,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movtoAGenerar.Productoid,
                        Cantidad = tipodoctoagenerarid == 52 ? movtoAGenerar.Cantidad - movtoAGenerar.Movto_inventario?.Cantidad_real : movtoAGenerar.Movto_inventario?.Cantidad_real - movtoAGenerar.Cantidad,
                        Preciolista = movtoAGenerar.Precio,
                        Descuentoporcentaje = 0m,
                        Descuento = 0m,
                        Precio = movtoAGenerar.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movtoAGenerar.Tasaiva,
                        Tasaieps = movtoAGenerar.Tasaieps,
                        Total = 0m,
                        Lote = movtoAGenerar.Lote,
                        Fechavence = movtoAGenerar.Fechavence,
                        Loteimportado = movtoAGenerar.Loteimportado,
                        Movtoparentid = movtoAGenerar.Id,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = BoolCN.N,
                        Kitimpfijo = BoolCN.N,
                        Doctoid = doctoIdGenerado,
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
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    _doctoMovtoService.MovtoInsert(movtoTrans, ref movtoIdGenerado, localContext); 
                    localContext.SaveChanges();

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = docto.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdGenerado,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio); 
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



        public void Docto_inventario_dif_generar_x_loc(long empresaId, long sucursalId, long doctoId, long tipodoctoagenerarid,
            ref long? doctoIdGenerado,
            ApplicationDbContext localContext)
        {





            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            long? movtoIdGenerado = null;

            try
            {
                var docto = localContext.Docto.AsNoTracking()
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("Docto no encontrado");

                if (!(docto.Tipodoctoid is 50 or 53))
                    throw new Exception("este tipo de documento no puede generar diferencia de inventario");

                if (docto.Estatusdoctoid != 0 && docto.Estatusdoctoid != 3)
                    throw new Exception("este estatus de documento no puede generar diferencia de inventario");



                var movtosAGenerar = localContext.Movto.AsNoTracking()
                                                    .Include(m => m.Movto_inventario)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                            .GroupBy(m => new { m.Productoid, m.Lote, m.Fechavence, m.Loteimportado, m.Cantidad,
                                                                m.Tasaieps, m.Tasaiva, m.Precio})
                                            .Select(m => new { 
                                                            m.Key.Productoid,
                                                            m.Key.Lote,
                                                            m.Key.Fechavence,
                                                            m.Key.Loteimportado,
                                                            m.Key.Cantidad ,
                                                            m.Key.Tasaieps,
                                                            m.Key.Tasaiva,
                                                            m.Key.Precio,
                                                            Id = m.Max(f => f.Id),

                                                            Cantidad_real = m.Sum(t => t.Movto_inventario!.Cantidad_real)

                                            }).
                                            Where(m => (
                                                        (tipodoctoagenerarid == 52 && m.Cantidad > m.Cantidad_real) ||
                                                        (tipodoctoagenerarid == 51 && m.Cantidad < m.Cantidad_real)
                                                       )).ToList();


                foreach (var movtoAGenerar in movtosAGenerar)
                {


                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdGenerado == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Estatusdoctoid = 0,
                            Usuarioid = docto.Usuarioid,
                            Corteid = docto.Corteid,
                            Fecha = docto.Fecha ?? DateTimeOffset.Now,
                            Fechahora = docto.Fechahora ?? DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = docto.Cajaid,
                            Almacenid = docto.Almacenid,
                            Origenfiscalid = docto.Origenfiscalid,
                            Esapartado = docto.Esapartado,
                            Doctoparentid = doctoId,
                            Clienteid = docto.Clienteid,
                            Tipodoctoid = tipodoctoagenerarid,
                            Proveedorid = docto.Proveedorid,
                            Sucursal_id = docto.Sucursal_id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdGenerado, localContext);
                        localContext.SaveChanges();
                    }

                    movtoIdGenerado = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = docto.Usuarioid,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movtoAGenerar.Productoid,
                        Cantidad = tipodoctoagenerarid == 52 ? movtoAGenerar.Cantidad - movtoAGenerar.Cantidad_real : movtoAGenerar.Cantidad_real - movtoAGenerar.Cantidad,
                        Preciolista = movtoAGenerar.Precio,
                        Descuentoporcentaje = 0m,
                        Descuento = 0m,
                        Precio = movtoAGenerar.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movtoAGenerar.Tasaiva,
                        Tasaieps = movtoAGenerar.Tasaieps,
                        Total = 0m,
                        Lote = null,
                        Fechavence = null,
                        Loteimportado = null,
                        Movtoparentid = movtoAGenerar.Id,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = BoolCN.N,
                        Kitimpfijo = BoolCN.N,
                        Doctoid = doctoIdGenerado,
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
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    _doctoMovtoService.MovtoInsert(movtoTrans, ref movtoIdGenerado, localContext);
                    localContext.SaveChanges();

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = docto.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdGenerado,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio);
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


        public void Docto_inventario_finedicion(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var docto = localContext.Docto
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("no existe el docto");

                docto.Estatusdoctoid = DBValues._DOCTO_ESTATUS_INVENTARIOFIN;

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



        public void Docto_inventario_cambiarkitdesglosado(long empresaId, long sucursalId, long doctoId, BoolCN kitDesglosado,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var docto = localContext.Docto.Include(d => d.Docto_kit)
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("no existe el docto");

                if(docto.Docto_kit == null)
                {
                    var docto_kit = new Docto_kit();
                    docto_kit.EmpresaId = empresaId;
                    docto_kit.SucursalId = sucursalId;
                    docto_kit.Doctoid = doctoId;
                    docto_kit.Kitdesglosado = kitDesglosado;

                    docto.Docto_kit = docto_kit;
                    localContext.Docto_kit.Add(docto_kit);
                    localContext.SaveChanges();
                }
                else
                {
                    docto.Docto_kit.Kitdesglosado = kitDesglosado;
                    localContext.Docto_kit.Update(docto.Docto_kit);
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



        public void DesensamblarKitsInventario(long empresaId, long sucursalId, long usuarioId, long almacenId, ref long? doctoIdKitDesglose,
            ApplicationDbContext localContext)
        {



            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? movtoIdKitDesglose = null;

            decimal cantidadADesArmar = 0;



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

                var corteInfo = localContext.Corte.AsNoTracking()
                                            .FirstOrDefault(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == corteid);


                if (corteInfo == null)
                    throw new Exception("No existe la sucursal");

                var sucursalInfo = localContext.Sucursal_info.AsNoTracking()
                                                .Include(s => s.Sucursal)
                                               .FirstOrDefault(s => s.EmpresaId == empresaId && s.SucursalId == sucursalId && s.Clave == s.Sucursal.Clave);


                if (sucursalInfo == null)
                    throw new Exception("No existe la sucursal");

                var movtosConKits = localContext.Inventario.AsNoTracking()
                                                .Include(i => i.Producto).ThenInclude(p => p!.Producto_inventario)
                                                .Include(i => i.Producto).ThenInclude(p => p!.Producto_kit)
                                                .Include(i => i.Producto).ThenInclude(p => p!.Producto_precios)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && 
                                                        m.Almacenid == almacenId && 
                                                            m.Producto!.Producto_kit!.Eskit == BoolCN.S && m.Cantidad > 0)
                                            .Select(i => new {
                                                Productoid = i.Productoid,
                                                Cantidad = i.Cantidad,
                                                Preciolista = i.Producto!.Producto_precios!.Precio1,
                                                Descuentoporcentaje = 0m,
                                                Precio = i.Producto.Producto_precios.Precio1,
                                                Tasaieps = i.Producto.Iepsimpuesto,
                                                Tasaiva = i.Producto.Ivaimpuesto,
                                                Lote = i.Lote,
                                                i.Fechavence,
                                                i.Loteimportado,
                                                Eskit = BoolCN.S,
                                                Kitimpfijo = BoolCN.N

                                            })
                                            .ToList();

                foreach (var movKitDef in movtosConKits)
                {

                    cantidadADesArmar = movKitDef.Cantidad ;

                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdKitDesglose == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = usuarioId,
                            Estatusdoctoid = 0,
                            Usuarioid = usuarioId,
                            Corteid = corteid,
                            Fecha =  DateTimeOffset.Now,
                            Fechahora =  DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = corteInfo.Cajaid,
                            Almacenid = almacenId,
                            Origenfiscalid = DBValues._ORIGENFISCAL_REMISIONADO,
                            Esapartado = BoolCN.N,
                            Doctoparentid = null,
                            Clienteid = null,
                            Tipodoctoid = 502,
                            Proveedorid = null,
                            Sucursal_id = sucursalInfo.Id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdKitDesglose, localContext);
                    }

                    movtoIdKitDesglose = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = usuarioId,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movKitDef.Productoid,
                        Cantidad = cantidadADesArmar,
                        Preciolista = movKitDef.Preciolista,
                        Descuentoporcentaje = movKitDef.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = movKitDef.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movKitDef.Tasaiva,
                        Tasaieps = movKitDef.Tasaieps,
                        Total = 0m,
                        Lote = movKitDef.Lote,
                        Fechavence = movKitDef.Fechavence,
                        Loteimportado = movKitDef.Loteimportado,
                        Movtoparentid = null,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = movKitDef.Eskit,
                        Kitimpfijo = movKitDef.Kitimpfijo,
                        Doctoid = doctoIdKitDesglose,
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
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    _doctoMovtoService.MovtoInsert(movtoTrans, ref movtoIdKitDesglose, localContext);

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = usuarioId,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdKitDesglose,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio);


                }


                if (doctoIdKitDesglose != null)
                {
                    _doctoMovtoService.DesEnsamble_kit_completar(empresaId, sucursalId, doctoIdKitDesglose!.Value, localContext);

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



        public void EnsamblarKitsInventario(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {

            BoolCS hayExistencia = BoolCS.S;
            decimal existencia = 0m;
            decimal existenciaParaArmarKit = 0m;
            decimal existenciaTotal = 0m;
            decimal enProcesoDeSalida = 0m;


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? doctoIdKitDesglose = null;
            long? movtoIdKitDesglose = null;

            decimal cantidadAArmar = 0;




            try
            {
                var docto = localContext.Docto.AsNoTracking()
                                              .Include(d => d.Tipodocto)
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("Docto no encontrado");

                if (docto.Tipodocto == null)
                    return;


                var movtosConKits = localContext.Movto.AsNoTracking()
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId && m.Eskit == BoolCN.S)
                                            .Select(movto => new {
                                                Movtoid = movto.Id,
                                                Productoid = movto.Productoid,
                                                Cantidad = movto.Cantidad,
                                                movto.Preciolista,
                                                movto.Descuentoporcentaje,
                                                Precio = movto.Precio,
                                                movto.Tasaieps,
                                                movto.Tasaiva,
                                                movto.Lote,
                                                movto.Fechavence,
                                                movto.Loteimportado,
                                                movto.Eskit,
                                                movto.Kitimpfijo

                                            })
                                            .ToList();

                foreach (var movKitDef in movtosConKits)
                {
                    hayExistencia = BoolCS.N;
                    existencia = 0m;
                    existenciaParaArmarKit = 0m;
                    existenciaTotal = 0m;
                    enProcesoDeSalida = 0m;

                    cantidadAArmar = 0;

                    _inventarioService.VerificarExistencia(empresaId, sucursalId,
                                                        movKitDef!.Productoid!.Value, movKitDef.Cantidad,
                                                        docto!.Tipodoctoid!.Value, docto!.Almacenid!.Value,
                                                        null, null, BoolCN.N, BoolCN.S, BoolCN.S, BoolCN.N,
                                                        BoolCN.N, movKitDef.Movtoid,
                                                        out hayExistencia, out existencia, out existenciaParaArmarKit,
                                                        out existenciaTotal, out enProcesoDeSalida, localContext);


                    decimal bufferCantidad = movKitDef.Cantidad;

                    if (existencia + existenciaParaArmarKit < bufferCantidad)
                        bufferCantidad = existencia + existenciaParaArmarKit;

                    if (existencia >= bufferCantidad)
                        continue;

                    cantidadAArmar = bufferCantidad - existencia;

                    //MLG TODO revisar lo de la generacion de ids
                    if (doctoIdKitDesglose == null)
                    {
                        var doctoTrans = new DoctoTransaction()
                        {
                            Empresaid = empresaId,
                            Sucursalid = sucursalId,
                            //Id = null,
                            Activo = docto.Activo,
                            Creado = DateTimeOffset.Now,
                            Creadopor_userid = docto.Usuarioid,
                            Estatusdoctoid = 0,
                            Usuarioid = docto.Usuarioid,
                            Corteid = docto.Corteid,
                            Fecha = docto.Fecha ?? DateTimeOffset.Now,
                            Fechahora = docto.Fechahora ?? DateTimeOffset.Now,
                            Serie = null,
                            Folio = null,
                            Importe = 0m,
                            Descuento = 0m,
                            Subtotal = 0m,
                            Iva = 0m,
                            Ieps = 0m,
                            Total = 0m,
                            Cargo = 0m,
                            Abono = 0m,
                            Saldo = 0m,
                            Cajaid = docto.Cajaid,
                            Almacenid = docto.Almacenid,
                            Origenfiscalid = docto.Origenfiscalid,
                            Esapartado = docto.Esapartado,
                            Doctoparentid = doctoId,
                            Clienteid = docto.Clienteid,
                            Tipodoctoid = 501,
                            Proveedorid = docto.Proveedorid,
                            Sucursal_id = docto.Sucursal_id,
                            Referencia = null,
                            Referencias = null,
                            Fechavence = null

                        };
                        _doctoService.DoctoInsert(doctoTrans, ref doctoIdKitDesglose, localContext);
                    }

                    movtoIdKitDesglose = null;

                    var movtoTrans = new MovtoTransaccion()
                    {

                        Empresaid = empresaId,
                        Sucursalid = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Creadopor_userid = docto.Usuarioid,
                        Partida = null,
                        Estatusmovtoid = 0,
                        Fecha = DateTimeOffset.UtcNow.Date,
                        Fechahora = DateTimeOffset.UtcNow,
                        Productoid = movKitDef.Productoid,
                        Cantidad = cantidadAArmar,
                        Preciolista = movKitDef.Preciolista,
                        Descuentoporcentaje = movKitDef.Descuentoporcentaje,
                        Descuento = 0m,
                        Precio = movKitDef.Precio,
                        Importe = 0m,
                        Subtotal = 0m,
                        Iva = 0m,
                        Ieps = 0m,
                        Tasaiva = movKitDef.Tasaiva,
                        Tasaieps = movKitDef.Tasaieps,
                        Total = 0m,
                        Lote = movKitDef.Lote,
                        Fechavence = movKitDef.Fechavence,
                        Loteimportado = movKitDef.Loteimportado,
                        Movtoparentid = movKitDef.Movtoid,
                        Movtonivel = 0,
                        Afectainventario = BoolCS.S,
                        Afectatotales = BoolCS.S,
                        Eskit = movKitDef.Eskit,
                        Kitimpfijo = movKitDef.Kitimpfijo,
                        Doctoid = doctoIdKitDesglose,
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
                        Calc_imp_de_total = BoolCN.N,
                        Localidad = null,
                        Descripcion1 = null,
                        Descripcion2 = null,
                        Descripcion3 = null,
                        Agrupaporparametro = null,
                        Cargartarjetapreciomanual = null,
                        Precioyavalidado = null,
                        Usuarioid = null,
                        Precioconimp = null,
                        Anaquelid = null,
                        Movtoadevolverid = null

                    };
                    _doctoMovtoService.MovtoInsert(movtoTrans, ref movtoIdKitDesglose, localContext);

                    var movto_precio = new Movto_precio()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        //Id = null,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = docto.Usuarioid,
                        Razondescuentocajero = "",
                        Preciomanualmasbajo = BoolCN.N,
                        Descuentovale = 0m,
                        Descuentovaleporcentaje = 0m,
                        Movtoid = movtoIdKitDesglose,
                        Ingresopreciomanual = BoolCN.N,
                        Porcentajedescuentomanual = 0m,
                        Precioclasificacion = null,
                        Precioconimp = 0m,
                        Calc_imp_de_total = BoolCN.N
                    };
                    localContext.Add(movto_precio);


                }


                if (doctoIdKitDesglose != null)
                {
                    _doctoMovtoService.Ensamble_kit_completar(empresaId, sucursalId, doctoIdKitDesglose!.Value, localContext);

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



        public void Docto_inventario_aplicar(long empresaId, long sucursalId, long doctoId, long usuarioId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                long? doctoKitIdDesglose = null;
                long? doctoIdSobrante = null;
                long? doctoIdRestante = null;


                var docto = localContext.Docto
                                              .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                              .FirstOrDefault();

                if (docto == null)
                    throw new Exception("no existe el docto");

                this.Docto_inventario_precierre(empresaId, sucursalId, doctoId, docto.Almacenid, usuarioId, 
                                                            docto.Subtipodoctoid != null ? docto.Subtipodoctoid.Value : DBValues._DOCTO_SUBTIPO_INVENTARIOPARCIALXPRODUCTO , 
                                                            localContext);

                this.DesensamblarKitsInventario(empresaId, sucursalId, usuarioId, docto.Almacenid!.Value, ref doctoKitIdDesglose, localContext);

                localContext.SaveChanges();

                Docto_inventario_setExistencia(empresaId, sucursalId, doctoId, usuarioId, docto.Almacenid, localContext);

                if(docto.Tipodoctoid == DBValues._DOCTO_TIPO_INVENTARIO_FISICO)
                {

                    Docto_inventario_dif_generar(empresaId, sucursalId, doctoId, DBValues._DOCTO_TIPO_INVENTARIO_AJUSTEENTRADA, ref doctoIdSobrante,  localContext);

                    Docto_inventario_dif_generar(empresaId, sucursalId, doctoId, DBValues._DOCTO_TIPO_INVENTARIO_AJUSTESALIDA, ref doctoIdRestante,  localContext);

                    localContext.SaveChanges();

                }
                else if(docto.Tipodoctoid == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
                {

                    Docto_inventario_dif_generar_x_loc(empresaId, sucursalId, doctoId, DBValues._DOCTO_TIPO_INVENTARIO_AJUSTEENTRADA, ref doctoIdSobrante, localContext);

                    Docto_inventario_dif_generar_x_loc(empresaId, sucursalId, doctoId, DBValues._DOCTO_TIPO_INVENTARIO_AJUSTESALIDA, ref doctoIdRestante, localContext);


                    localContext.SaveChanges();
                }

                if(doctoIdRestante != null)
                {
                    this._doctoMovtoService.Docto_generic_save(empresaId, sucursalId, doctoIdRestante.Value, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);
                    localContext.SaveChanges();
                }


                if (doctoIdSobrante != null)
                {
                    this._doctoMovtoService.Docto_generic_save(empresaId, sucursalId, doctoIdSobrante.Value, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);
                    localContext.SaveChanges();
                }

                if (doctoKitIdDesglose != null)
                {
                    this.EnsamblarKitsInventario(empresaId, sucursalId, doctoKitIdDesglose.Value, localContext);
                }


                this._doctoMovtoService.Docto_generic_save(empresaId, sucursalId, doctoId, DBValues._DOCTO_ESTATUS_COMPLETO, localContext);
                localContext.SaveChanges();


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




    }

    public class InventarioDesglose
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long ProductoId { get; set; }
        public long? Almacenid { get; set; }
        public string? Lote { get; set; }
        public DateTimeOffset? Fechavence { get; set; }
        public long? Loteimportado { get; set; }
        public BoolCN Esapartado { get; set; }
        public long Movtoid { get; set; }
        public decimal CantidadTeorica { get; set; }
        public decimal CantidadSurtida { get; set; }

        public InventarioDesglose()
        {

        }

        public InventarioDesglose(long empresaId, long sucursalId, long productoId, long? almacenid, string? lote, DateTimeOffset? fechavence, long? loteimportado, BoolCN esapartado, long movtoid, decimal cantidadTeorica, decimal cantidadSurtida)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            ProductoId = productoId;
            Almacenid = almacenid;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
            Esapartado = esapartado;
            Movtoid = movtoid;
            CantidadTeorica = cantidadTeorica;
            CantidadSurtida = cantidadSurtida;
        }

        public override bool Equals(object? obj)
        {
            return obj is InventarioDesglose other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   ProductoId == other.ProductoId &&
                   Almacenid == other.Almacenid &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado &&
                   Esapartado == other.Esapartado &&
                   Movtoid == other.Movtoid &&
                   CantidadTeorica == other.CantidadTeorica &&
                   CantidadSurtida == other.CantidadSurtida;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(ProductoId);
            hash.Add(Almacenid);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            hash.Add(Esapartado);
            hash.Add(Movtoid);
            hash.Add(CantidadTeorica);
            hash.Add(CantidadSurtida);
            return hash.ToHashCode();
        }
    }


    public class InventarioDesglose_x_loc
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long ProductoId { get; set; }
        public long? Almacenid { get; set; }
        public string? Lote { get; set; }
        public DateTimeOffset? Fechavence { get; set; }
        public long? Loteimportado { get; set; }
        public BoolCN Esapartado { get; set; }
        public long Movtoid { get; set; }
        public decimal CantidadTeorica { get; set; }
        public decimal CantidadSurtida { get; set; }

        public string? Localidad { get; set; }
        public long? Anaquelid { get; set; }

        public InventarioDesglose_x_loc()
        {

        }

        public InventarioDesglose_x_loc(long empresaId, long sucursalId, long productoId, long? almacenid, string? lote, DateTimeOffset? fechavence, long? loteimportado, BoolCN esapartado, long movtoid, decimal cantidadTeorica, decimal cantidadSurtida)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            ProductoId = productoId;
            Almacenid = almacenid;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
            Esapartado = esapartado;
            Movtoid = movtoid;
            CantidadTeorica = cantidadTeorica;
            CantidadSurtida = cantidadSurtida;
        }

        public override bool Equals(object? obj)
        {
            return obj is InventarioDesglose other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   ProductoId == other.ProductoId &&
                   Almacenid == other.Almacenid &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado &&
                   Esapartado == other.Esapartado &&
                   Movtoid == other.Movtoid &&
                   CantidadTeorica == other.CantidadTeorica &&
                   CantidadSurtida == other.CantidadSurtida;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(ProductoId);
            hash.Add(Almacenid);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            hash.Add(Esapartado);
            hash.Add(Movtoid);
            hash.Add(CantidadTeorica);
            hash.Add(CantidadSurtida);
            return hash.ToHashCode();
        }
    }




    public class Inv_Localidad
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long Productoid { get; set; }
        public string? Localidad { get; set; }
        public long? Anaquelid { get; set; }

        public Inv_Localidad()
        {

        }

        public Inv_Localidad(long empresaId, long sucursalId, long productoid, string? localidad, long? anaquelid)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Productoid = productoid;
            Localidad = localidad;
            Anaquelid = anaquelid;
        }

        public override bool Equals(object? obj)
        {
            return obj is Inv_Localidad other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Productoid == other.Productoid &&
                   Localidad == other.Localidad &&
                   Anaquelid == other.Anaquelid;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmpresaId, SucursalId, Productoid, Localidad, Anaquelid);
        }
    }


    public class BasicInventario
    {
        public long? Productoid { get; }
        public string? Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Loteimportado { get; }
        public BasicInventario()
        {

        }


        public BasicInventario(long? productoid, string? lote, DateTimeOffset? fechavence, long? loteimportado)
        {
            Productoid = productoid;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
        }

        public override bool Equals(object? obj)
        {
            return obj is BasicInventario other &&
                   Productoid == other.Productoid &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Productoid, Lote, Fechavence, Loteimportado);
        }
    }

    public class Tmp_InventarioHechosList
    {
        public long Empresaid { get; }
        public long Sucursalid { get; }
        public string Sucursalclave { get; }
        public string Sucursalnombre { get; }
        public long? Cajaid { get; }
        public string Cajaclave { get; }
        public string Cajanombre { get; }
        public DateTimeOffset? Fecha { get; }
        public string? Serie { get; }
        public long Consecutivo { get; }
        public decimal Total { get; }
        public long? Estatusdoctoid { get; }
        public string Estatusdoctoclave { get; }
        public string Estatusdoctonombre { get; }
        public long? Tipodoctoid { get; }
        public string Tipodoctoclave { get; }
        public string Tipodoctonombre { get; }
        public string? Referencia { get; }
        public int? Folio { get; }
        public long? Usuarioid { get; }
        public string? Usuarioclave { get; }
        public string Usuarionombre { get; }

        public Tmp_InventarioHechosList(long empresaid, long sucursalid, string sucursalclave, string sucursalnombre, long? cajaid, string cajaclave, string cajanombre, DateTimeOffset? fecha, string? serie, long consecutivo, decimal total, long? estatusdoctoid, string estatusdoctoclave, string estatusdoctonombre, long? tipodoctoid, string tipodoctoclave, string tipodoctonombre, string? referencia, int? folio, long? usuarioid, string? usuarioclave, string usuarionombre)
        {
            Empresaid = empresaid;
            Sucursalid = sucursalid;
            Sucursalclave = sucursalclave;
            Sucursalnombre = sucursalnombre;
            Cajaid = cajaid;
            Cajaclave = cajaclave;
            Cajanombre = cajanombre;
            Fecha = fecha;
            Serie = serie;
            Consecutivo = consecutivo;
            Total = total;
            Estatusdoctoid = estatusdoctoid;
            Estatusdoctoclave = estatusdoctoclave;
            Estatusdoctonombre = estatusdoctonombre;
            Tipodoctoid = tipodoctoid;
            Tipodoctoclave = tipodoctoclave;
            Tipodoctonombre = tipodoctonombre;
            Referencia = referencia;
            Folio = folio;
            Usuarioid = usuarioid;
            Usuarioclave = usuarioclave;
            Usuarionombre = usuarionombre;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_InventarioHechosList other &&
                   Empresaid == other.Empresaid &&
                   Sucursalid == other.Sucursalid &&
                   Sucursalclave == other.Sucursalclave &&
                   Sucursalnombre == other.Sucursalnombre &&
                   Cajaid == other.Cajaid &&
                   Cajaclave == other.Cajaclave &&
                   Cajanombre == other.Cajanombre &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   Serie == other.Serie &&
                   Consecutivo == other.Consecutivo &&
                   Total == other.Total &&
                   Estatusdoctoid == other.Estatusdoctoid &&
                   Estatusdoctoclave == other.Estatusdoctoclave &&
                   Estatusdoctonombre == other.Estatusdoctonombre &&
                   Tipodoctoid == other.Tipodoctoid &&
                   Tipodoctoclave == other.Tipodoctoclave &&
                   Tipodoctonombre == other.Tipodoctonombre &&
                   Referencia == other.Referencia &&
                   Folio == other.Folio &&
                   Usuarioid == other.Usuarioid &&
                   Usuarioclave == other.Usuarioclave &&
                   Usuarionombre == other.Usuarionombre;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Empresaid);
            hash.Add(Sucursalid);
            hash.Add(Sucursalclave);
            hash.Add(Sucursalnombre);
            hash.Add(Cajaid);
            hash.Add(Cajaclave);
            hash.Add(Cajanombre);
            hash.Add(Fecha);
            hash.Add(Serie);
            hash.Add(Consecutivo);
            hash.Add(Total);
            hash.Add(Estatusdoctoid);
            hash.Add(Estatusdoctoclave);
            hash.Add(Estatusdoctonombre);
            hash.Add(Tipodoctoid);
            hash.Add(Tipodoctoclave);
            hash.Add(Tipodoctonombre);
            hash.Add(Referencia);
            hash.Add(Folio);
            hash.Add(Usuarioid);
            hash.Add(Usuarioclave);
            hash.Add(Usuarionombre);
            return hash.ToHashCode();
        }
    }

    public class Tmp_Inventario_movto_detalles
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public string Sucursalclave { get; }
        public string Sucursalnombre { get; }
        public long ProductoId { get; }
        public string Productoclave { get; }
        public string Productonombre { get; }
        public string Productodescripcion { get; }
        public string Productotexto1 { get; }
        public string Productotexto2 { get; }
        public string Productotexto3 { get; }
        public string Productotexto4 { get; }
        public string Productotexto5 { get; }
        public string Productotexto6 { get; }
        public decimal? Productonumero1 { get; }
        public decimal? Productonumero2 { get; }
        public decimal? Productonumero3 { get; }
        public decimal? Productonumero4 { get; }
        public DateTimeOffset? Fecha1 { get; }
        public DateTimeOffset? Fecha2 { get; }
        public decimal Pzacaja { get; }
        public long? Almacenid { get; }
        public string Almacenclave { get; }
        public string Almacennombre { get; }
        public string Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Loteimportado { get; }
        public decimal CantidadTeorica { get; }
        public decimal CantidadSurtida { get; }
        public long Movtoid { get; }
        public decimal Cajas { get; }
        public decimal Piezas { get; }
        public decimal CajasTeorica { get; }
        public decimal PiezasTeorica { get; }
        public decimal CantidadDiferencia { get; }

        public string? Localidad { get; }
        public long? Anaquelid { get; }
        public string? Anaquelclave { get; }
        public string? Anaquelnombre { get; }
        public decimal AcumuladoCantidadSurtida { get; }

        public Tmp_Inventario_movto_detalles(long empresaId, long sucursalId, string sucursalclave, string sucursalnombre, long productoId, string productoclave, string productonombre, string productodescripcion, string productotexto1, string productotexto2, string productotexto3, string productotexto4, string productotexto5, string productotexto6, decimal? productonumero1, decimal? productonumero2, decimal? productonumero3, decimal? productonumero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, decimal pzacaja, long? almacenid, string almacenclave, string almacennombre, string lote, DateTimeOffset? fechavence, long? loteimportado, decimal cantidadTeorica, decimal cantidadSurtida, long movtoid, decimal cajas, decimal piezas, decimal cajasTeorica, decimal piezasTeorica, decimal cantidadDiferencia, string? localidad,
                                             long? anaquelid, string? anaquelclave, string? anaquelnombre, decimal acumuladoCantidadSurtida)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Sucursalclave = sucursalclave;
            Sucursalnombre = sucursalnombre;
            ProductoId = productoId;
            Productoclave = productoclave;
            Productonombre = productonombre;
            Productodescripcion = productodescripcion;
            Productotexto1 = productotexto1;
            Productotexto2 = productotexto2;
            Productotexto3 = productotexto3;
            Productotexto4 = productotexto4;
            Productotexto5 = productotexto5;
            Productotexto6 = productotexto6;
            Productonumero1 = productonumero1;
            Productonumero2 = productonumero2;
            Productonumero3 = productonumero3;
            Productonumero4 = productonumero4;
            Fecha1 = fecha1;
            Fecha2 = fecha2;
            Pzacaja = pzacaja;
            Almacenid = almacenid;
            Almacenclave = almacenclave;
            Almacennombre = almacennombre;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
            CantidadTeorica = cantidadTeorica;
            CantidadSurtida = cantidadSurtida;
            Movtoid = movtoid;
            Cajas = cajas;
            Piezas = piezas;
            CajasTeorica = cajasTeorica;
            PiezasTeorica = piezasTeorica;
            CantidadDiferencia = cantidadDiferencia;
            Localidad = localidad;
            Anaquelid = anaquelid;
            Anaquelclave = anaquelclave;
            Anaquelnombre = anaquelnombre;
            AcumuladoCantidadSurtida = acumuladoCantidadSurtida;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_Inventario_movto_detalles other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Sucursalclave == other.Sucursalclave &&
                   Sucursalnombre == other.Sucursalnombre &&
                   ProductoId == other.ProductoId &&
                   Productoclave == other.Productoclave &&
                   Productonombre == other.Productonombre &&
                   Productodescripcion == other.Productodescripcion &&
                   Productotexto1 == other.Productotexto1 &&
                   Productotexto2 == other.Productotexto2 &&
                   Productotexto3 == other.Productotexto3 &&
                   Productotexto4 == other.Productotexto4 &&
                   Productotexto5 == other.Productotexto5 &&
                   Productotexto6 == other.Productotexto6 &&
                   Productonumero1 == other.Productonumero1 &&
                   Productonumero2 == other.Productonumero2 &&
                   Productonumero3 == other.Productonumero3 &&
                   Productonumero4 == other.Productonumero4 &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
                   Pzacaja == other.Pzacaja &&
                   Almacenid == other.Almacenid &&
                   Almacenclave == other.Almacenclave &&
                   Almacennombre == other.Almacennombre &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado &&
                   CantidadTeorica == other.CantidadTeorica &&
                   CantidadSurtida == other.CantidadSurtida &&
                   Movtoid == other.Movtoid &&
                   Cajas == other.Cajas &&
                   Piezas == other.Piezas &&
                   CajasTeorica == other.CajasTeorica &&
                   PiezasTeorica == other.PiezasTeorica &&
                   CantidadDiferencia == other.CantidadDiferencia;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Sucursalclave);
            hash.Add(Sucursalnombre);
            hash.Add(ProductoId);
            hash.Add(Productoclave);
            hash.Add(Productonombre);
            hash.Add(Productodescripcion);
            hash.Add(Productotexto1);
            hash.Add(Productotexto2);
            hash.Add(Productotexto3);
            hash.Add(Productotexto4);
            hash.Add(Productotexto5);
            hash.Add(Productotexto6);
            hash.Add(Productonumero1);
            hash.Add(Productonumero2);
            hash.Add(Productonumero3);
            hash.Add(Productonumero4);
            hash.Add(Fecha1);
            hash.Add(Fecha2);
            hash.Add(Pzacaja);
            hash.Add(Almacenid);
            hash.Add(Almacenclave);
            hash.Add(Almacennombre);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            hash.Add(CantidadTeorica);
            hash.Add(CantidadSurtida);
            hash.Add(Movtoid);
            hash.Add(Cajas);
            hash.Add(Piezas);
            hash.Add(CajasTeorica);
            hash.Add(PiezasTeorica);
            hash.Add(CantidadDiferencia);
            return hash.ToHashCode();
        }
    }

    public class Inventario_movto_detalles_xloc
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public string Sucursalclave { get; }
        public string Sucursalnombre { get; }
        public long ProductoId { get; }
        public string Productoclave { get; }
        public string Productonombre { get; }
        public string Productodescripcion { get; }
        public string Productotexto1 { get; }
        public string Productotexto2 { get; }
        public string Productotexto3 { get; }
        public string Productotexto4 { get; }
        public string Productotexto5 { get; }
        public string Productotexto6 { get; }
        public decimal? Productonumero1 { get; }
        public decimal? Productonumero2 { get; }
        public decimal? Productonumero3 { get; }
        public decimal? Productonumero4 { get; }
        public DateTimeOffset? Fecha1 { get; }
        public DateTimeOffset? Fecha2 { get; }
        public decimal Pzacaja { get; }
        public long? Almacenid { get; }
        public string Almacenclave { get; }
        public string Almacennombre { get; }
        public string Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Loteimportado { get; }
        public decimal CantidadTeorica { get; }
        public decimal CantidadSurtida { get; }
        public long Movtoid { get; }
        public decimal Cajas { get; }
        public decimal Piezas { get; }
        public decimal CajasTeorica { get; }
        public decimal PiezasTeorica { get; }
        public decimal CantidadDiferencia { get; }
        public string? Localidad { get; }
        public long? Anaquelid { get; }
        public string? Anaquelclave { get; }
        public string? Anaquelnombre { get; }
        public decimal AcumuladoCantidadSurtida { get; }


        public Inventario_movto_detalles_xloc(
            long empresaId, long sucursalId, string sucursalclave, string sucursalnombre, long productoId, 
            string productoclave, string productonombre, string productodescripcion, string productotexto1, 
            string productotexto2, string productotexto3, string productotexto4, string productotexto5, 
            string productotexto6, decimal? productonumero1, decimal? productonumero2, decimal? productonumero3, 
            decimal? productonumero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, decimal pzacaja, 
            long? almacenid, string almacenclave, string almacennombre, string lote, DateTimeOffset? fechavence, 
            long? loteimportado, decimal cantidadTeorica, decimal cantidadSurtida, long movtoid, decimal cajas, 
            decimal piezas, decimal cajasTeorica, decimal piezasTeorica, decimal cantidadDiferencia, string? localidad,
            long? anaquelid, string? anaquelclave, string? anaquelnombre, decimal acumuladoCantidadSurtida)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Sucursalclave = sucursalclave;
            Sucursalnombre = sucursalnombre;
            ProductoId = productoId;
            Productoclave = productoclave;
            Productonombre = productonombre;
            Productodescripcion = productodescripcion;
            Productotexto1 = productotexto1;
            Productotexto2 = productotexto2;
            Productotexto3 = productotexto3;
            Productotexto4 = productotexto4;
            Productotexto5 = productotexto5;
            Productotexto6 = productotexto6;
            Productonumero1 = productonumero1;
            Productonumero2 = productonumero2;
            Productonumero3 = productonumero3;
            Productonumero4 = productonumero4;
            Fecha1 = fecha1;
            Fecha2 = fecha2;
            Pzacaja = pzacaja;
            Almacenid = almacenid;
            Almacenclave = almacenclave;
            Almacennombre = almacennombre;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
            CantidadTeorica = cantidadTeorica;
            CantidadSurtida = cantidadSurtida;
            Movtoid = movtoid;
            Cajas = cajas;
            Piezas = piezas;
            CajasTeorica = cajasTeorica;
            PiezasTeorica = piezasTeorica;
            CantidadDiferencia = cantidadDiferencia;
            Localidad = localidad;
            Anaquelid = anaquelid;
            Anaquelclave = anaquelclave;
            Anaquelnombre = anaquelnombre;
            AcumuladoCantidadSurtida = acumuladoCantidadSurtida;
        }

        public override bool Equals(object? obj)
        {
            return obj is Inventario_movto_detalles_xloc other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Sucursalclave == other.Sucursalclave &&
                   Sucursalnombre == other.Sucursalnombre &&
                   ProductoId == other.ProductoId &&
                   Productoclave == other.Productoclave &&
                   Productonombre == other.Productonombre &&
                   Productodescripcion == other.Productodescripcion &&
                   Productotexto1 == other.Productotexto1 &&
                   Productotexto2 == other.Productotexto2 &&
                   Productotexto3 == other.Productotexto3 &&
                   Productotexto4 == other.Productotexto4 &&
                   Productotexto5 == other.Productotexto5 &&
                   Productotexto6 == other.Productotexto6 &&
                   Productonumero1 == other.Productonumero1 &&
                   Productonumero2 == other.Productonumero2 &&
                   Productonumero3 == other.Productonumero3 &&
                   Productonumero4 == other.Productonumero4 &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
                   Pzacaja == other.Pzacaja &&
                   Almacenid == other.Almacenid &&
                   Almacenclave == other.Almacenclave &&
                   Almacennombre == other.Almacennombre &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado &&
                   CantidadTeorica == other.CantidadTeorica &&
                   CantidadSurtida == other.CantidadSurtida &&
                   Movtoid == other.Movtoid &&
                   Cajas == other.Cajas &&
                   Piezas == other.Piezas &&
                   CajasTeorica == other.CajasTeorica &&
                   PiezasTeorica == other.PiezasTeorica;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Sucursalclave);
            hash.Add(Sucursalnombre);
            hash.Add(ProductoId);
            hash.Add(Productoclave);
            hash.Add(Productonombre);
            hash.Add(Productodescripcion);
            hash.Add(Productotexto1);
            hash.Add(Productotexto2);
            hash.Add(Productotexto3);
            hash.Add(Productotexto4);
            hash.Add(Productotexto5);
            hash.Add(Productotexto6);
            hash.Add(Productonumero1);
            hash.Add(Productonumero2);
            hash.Add(Productonumero3);
            hash.Add(Productonumero4);
            hash.Add(Fecha1);
            hash.Add(Fecha2);
            hash.Add(Pzacaja);
            hash.Add(Almacenid);
            hash.Add(Almacenclave);
            hash.Add(Almacennombre);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            hash.Add(CantidadTeorica);
            hash.Add(CantidadSurtida);
            hash.Add(Movtoid);
            hash.Add(Cajas);
            hash.Add(Piezas);
            hash.Add(CajasTeorica);
            hash.Add(PiezasTeorica);
            return hash.ToHashCode();
        }
    }

    public class Tmp_Inventario_movto_detalles_x_loc_grouped
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public string Sucursalclave { get; }
        public string Sucursalnombre { get; }
        public long ProductoId { get; }
        public string Productoclave { get; }
        public string Productonombre { get; }
        public string Productodescripcion { get; }
        public string Productotexto1 { get; }
        public string Productotexto2 { get; }
        public string Productotexto3 { get; }
        public string Productotexto4 { get; }
        public string Productotexto5 { get; }
        public string Productotexto6 { get; }
        public decimal? Productonumero1 { get; }
        public decimal? Productonumero2 { get; }
        public decimal? Productonumero3 { get; }
        public decimal? Productonumero4 { get; }
        public DateTimeOffset? Fecha1 { get; }
        public DateTimeOffset? Fecha2 { get; }
        public decimal Pzacaja { get; }
        public long? Almacenid { get; }
        public string Almacenclave { get; }
        public string Almacennombre { get; }
        public string Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Loteimportado { get; }
        public decimal CantidadTeorica { get; }
        public decimal CantidadSurtida { get; }
        public long Movtoid { get; }
        public decimal Cajas { get; }
        public decimal Piezas { get; }
        public decimal CajasTeorica { get; }
        public decimal PiezasTeorica { get; }

        public decimal CantidadDiferencia { get; }


        public string? Localidad { get; }
        public long? Anaquelid { get; }
        public string? Anaquelclave { get; }
        public string? Anaquelnombre { get; }
        public decimal AcumuladoCantidadSurtida { get; }

        public Tmp_Inventario_movto_detalles_x_loc_grouped(long empresaId, long sucursalId, string sucursalclave, string sucursalnombre, long productoId, string productoclave, string productonombre, string productodescripcion, string productotexto1, string productotexto2, string productotexto3, string productotexto4, string productotexto5, string productotexto6, decimal? productonumero1, decimal? productonumero2, decimal? productonumero3, decimal? productonumero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, decimal pzacaja, long? almacenid, string almacenclave, string almacennombre, string lote, DateTimeOffset? fechavence, long? loteimportado, decimal cantidadTeorica, decimal cantidadSurtida, long movtoid, decimal cajas, decimal piezas, decimal cajasTeorica, decimal piezasTeorica, decimal cantidadDiferencia)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Sucursalclave = sucursalclave;
            Sucursalnombre = sucursalnombre;
            ProductoId = productoId;
            Productoclave = productoclave;
            Productonombre = productonombre;
            Productodescripcion = productodescripcion;
            Productotexto1 = productotexto1;
            Productotexto2 = productotexto2;
            Productotexto3 = productotexto3;
            Productotexto4 = productotexto4;
            Productotexto5 = productotexto5;
            Productotexto6 = productotexto6;
            Productonumero1 = productonumero1;
            Productonumero2 = productonumero2;
            Productonumero3 = productonumero3;
            Productonumero4 = productonumero4;
            Fecha1 = fecha1;
            Fecha2 = fecha2;
            Pzacaja = pzacaja;
            Almacenid = almacenid;
            Almacenclave = almacenclave;
            Almacennombre = almacennombre;
            Lote = lote;
            Fechavence = fechavence;
            Loteimportado = loteimportado;
            CantidadTeorica = cantidadTeorica;
            CantidadSurtida = cantidadSurtida;
            Movtoid = movtoid;
            Cajas = cajas;
            Piezas = piezas;
            CajasTeorica = cajasTeorica;
            PiezasTeorica = piezasTeorica;
            CantidadDiferencia = cantidadDiferencia;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_Inventario_movto_detalles_x_loc_grouped other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Sucursalclave == other.Sucursalclave &&
                   Sucursalnombre == other.Sucursalnombre &&
                   ProductoId == other.ProductoId &&
                   Productoclave == other.Productoclave &&
                   Productonombre == other.Productonombre &&
                   Productodescripcion == other.Productodescripcion &&
                   Productotexto1 == other.Productotexto1 &&
                   Productotexto2 == other.Productotexto2 &&
                   Productotexto3 == other.Productotexto3 &&
                   Productotexto4 == other.Productotexto4 &&
                   Productotexto5 == other.Productotexto5 &&
                   Productotexto6 == other.Productotexto6 &&
                   Productonumero1 == other.Productonumero1 &&
                   Productonumero2 == other.Productonumero2 &&
                   Productonumero3 == other.Productonumero3 &&
                   Productonumero4 == other.Productonumero4 &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
                   Pzacaja == other.Pzacaja &&
                   Almacenid == other.Almacenid &&
                   Almacenclave == other.Almacenclave &&
                   Almacennombre == other.Almacennombre &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Loteimportado == other.Loteimportado &&
                   CantidadTeorica == other.CantidadTeorica &&
                   CantidadSurtida == other.CantidadSurtida &&
                   Movtoid == other.Movtoid &&
                   Cajas == other.Cajas &&
                   Piezas == other.Piezas &&
                   CajasTeorica == other.CajasTeorica &&
                   PiezasTeorica == other.PiezasTeorica;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Sucursalclave);
            hash.Add(Sucursalnombre);
            hash.Add(ProductoId);
            hash.Add(Productoclave);
            hash.Add(Productonombre);
            hash.Add(Productodescripcion);
            hash.Add(Productotexto1);
            hash.Add(Productotexto2);
            hash.Add(Productotexto3);
            hash.Add(Productotexto4);
            hash.Add(Productotexto5);
            hash.Add(Productotexto6);
            hash.Add(Productonumero1);
            hash.Add(Productonumero2);
            hash.Add(Productonumero3);
            hash.Add(Productonumero4);
            hash.Add(Fecha1);
            hash.Add(Fecha2);
            hash.Add(Pzacaja);
            hash.Add(Almacenid);
            hash.Add(Almacenclave);
            hash.Add(Almacennombre);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Loteimportado);
            hash.Add(CantidadTeorica);
            hash.Add(CantidadSurtida);
            hash.Add(Movtoid);
            hash.Add(Cajas);
            hash.Add(Piezas);
            hash.Add(CajasTeorica);
            hash.Add(PiezasTeorica);
            return hash.ToHashCode();
        }
    }

}
