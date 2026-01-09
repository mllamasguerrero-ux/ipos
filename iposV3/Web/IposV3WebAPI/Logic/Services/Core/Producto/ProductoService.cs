using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using BindingModels;

namespace IposV3.Services
{
    public class ProductoService
    {

        public ProductoService()
        {
        }





        public List<Tmp_ProductoAutocomplete> ProductoAutocomplete(long empresaId, long sucursalId, bool conExistencia, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var lstProductoAutocomplete = localContext.Producto.AsNoTracking()
                                                      .Include(p => p.Producto_existencia)
                                                      .Include(p => p.Producto_inventario)
                                                      .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && 
                                                               (!conExistencia  || 
                                                               (p.Producto_existencia != null && p.Producto_existencia.Existencia > 0) ||
                                                               (p.Producto_inventario != null && p.Producto_inventario.Inventariable != BoolCS.S) ||
                                                               (p.Producto_inventario != null && p.Producto_inventario.Negativos == BoolCN.S)
                                                               )
                                                      )
                                                      .Select(d => new Tmp_ProductoAutocomplete(
                                                          d.Id,
                                                          d.Clave,
                                                          d.Descripcion1,
d.Producto_existencia == null ? 0m : d.Producto_existencia.Existencia

                                                      )).ToList();

                return lstProductoAutocomplete;


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





        public List<ProductoListBindingModel> SelectLista(ProductoParam param, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var lstProducto = new List<ProductoListBindingModel>();

                var parametro = localContext.Parametro.AsNoTracking()
                                            .Include(p => p.Listaprecioxpzacaja_)
                                            .Include(p => p.Listapremedmaylinea_)
                                            .Include(p => p.Listapreciomaylinea_)
                                            .First();




                var clienteMostrador = localContext.Cliente.AsNoTracking()
                                            .Include(c => c.Cliente_precio).ThenInclude(cp => cp!.Listaprecio)
                                            .First(c => c.EmpresaId == param.EmpresaId && c.SucursalId == param.SucursalId && c.Id == 1);

                var cadenaBusquedaLower = param.CadenaBusqueda?.ToLower();

                if (param.ClienteId != null || param.ProveedorId != null)
                {
                    lstProducto = localContext.Movto.AsNoTracking()
                                                .Include(m => m.Docto)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Proveedor1)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Proveedor2)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Linea)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Marca)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Unidad)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Producto_existencia)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Producto_inventario)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Producto_kit)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Producto_padre)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Producto_precios).ThenInclude(d => d!.Listaprecmediomay)
                                                .Include(m => m.Producto).ThenInclude(c => c!.Producto_precios).ThenInclude(d => d!.Listaprecmayoreo)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_existencia)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Inventarios)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Substituto)
                                                .Include(m => m.Producto).ThenInclude(p => p!.Producto_precios).ThenInclude(p => p!.Moneda)
                                                              .Where(p => p.EmpresaId == param.EmpresaId && p.SucursalId == param.SucursalId &&
                                                                          p.Productoid != null &&
                                                                          (
                                                                            (param.ProveedorId != null && p.Docto!.Proveedorid == param.ProveedorId) ||
                                                                            (param.ClienteId != null && p.Docto!.Clienteid == param.ClienteId)
                                                                           ) &&

                                                                  (param.MostrarDescontinuados || (p.Producto!.Marca == null || p.Producto!.Marca.Descontinuado == BoolCN.N)) &&
                                                                   (param.TipoProductoPorPadreHijo == TipoProductoPorPadreHijo.tp_todos ||
                                                                                    (param.TipoProductoPorPadreHijo == TipoProductoPorPadreHijo.tp_padres && p.Producto!.Producto_padre == null) ||
                                                                                    (param.TipoProductoPorPadreHijo == TipoProductoPorPadreHijo.tp_hijos && p.Producto!.Producto_padre != null)
                                                                   ) &&
                                                                   (!param.SoloConExistencias ||
                                                                     (
                                                                            (p.Producto!.Producto_inventario != null && p.Producto!.Producto_inventario.Inventariable != BoolCS.S) ||
                                                                            (p.Producto!.Producto_inventario != null && p.Producto!.Producto_inventario.Negativos == BoolCN.S) ||
                                                                            (
                                                                               (!param.PorExistenciaDeAlmacen && (p.Producto!.Producto_existencia != null && p.Producto!.Producto_existencia.Existencia > 0)) ||
                                                                               (param.PorExistenciaDeAlmacen &&
                                                                                (
                                                                                      param.AlmacenId == null ||
                                                                                      (
                                                                                       p.Producto!.Inventarios != null && p.Producto!.Inventarios.Where(i => i.Almacenid == param.AlmacenId && i.Esapartado != BoolCN.S).Sum(i => i.Cantidad) > 0
                                                                                      )
                                                                                )
                                                                              )
                                                                            )
                                                                     )
                                                                   ) &&
                                                                   ((cadenaBusquedaLower == null || cadenaBusquedaLower.Length == 0) || (p.Producto!.Clave.ToLower().Contains(cadenaBusquedaLower) || p.Producto!.Nombre.ToLower().Contains(cadenaBusquedaLower) || p.Producto!.Descripcion.ToLower().Contains(cadenaBusquedaLower) ||
                                                                                                                                           (p.Producto!.Descripcion1 != null && p.Producto!.Descripcion1.ToLower().Contains(cadenaBusquedaLower)) || (p.Producto!.Descripcion2 != null && p.Producto!.Descripcion2.ToLower().Contains(cadenaBusquedaLower)) || (p.Producto!.Descripcion3 != null && p.Producto!.Descripcion3.ToLower().Contains(cadenaBusquedaLower)) ||
                                                                                                                                           (p.Producto!.Ean != null && p.Producto!.Ean.ToLower().Contains(cadenaBusquedaLower)) || (p.Producto!.Cbarras != null && p.Producto!.Cbarras.ToLower().Contains(cadenaBusquedaLower)) || (p.Producto!.Cempaque != null && p.Producto!.Cempaque.ToLower().Contains(cadenaBusquedaLower))
                                                                                                                                          )
                                                                  )

                                                                      )
                                                              .GroupBy(x => x.Producto!.Id)
                                                              .Select(x => new ProductoListBindingModel(x.First().Producto!,
                                                                                                        parametro, clienteMostrador,
                                                                                                        param.AlmacenId1, param.AlmacenId2, param.AlmacenId3, param.PorcUtilidad)).ToList();
                }
                else
                {

                    lstProducto = localContext.Producto.AsNoTracking()
                                                            .Include(c => c.Proveedor1)
                                                            .Include(c => c.Proveedor2)
                                                            .Include(c => c.Linea)
                                                            .Include(c => c.Marca)
                                                            .Include(c => c.Unidad)
                                                            .Include(c => c.Producto_existencia)
                                                            .Include(c => c.Producto_inventario)
                                                            .Include(c => c.Producto_kit)
                                                            .Include(c => c.Producto_padre)
                                                            .Include(c => c.Producto_precios).ThenInclude(d => d!.Listaprecmediomay)
                                                            .Include(c => c.Producto_precios).ThenInclude(d => d!.Listaprecmayoreo)
                                                              .Include(p => p.Producto_existencia)
                                                              .Include(p => p.Producto_inventario)
                                                              .Include(p => p.Inventarios)
                                                              .Include(p => p!.Substituto)
                                                              .Include(p => p!.Producto_precios).ThenInclude(p => p!.Moneda)
                                                              .Where(p => p.EmpresaId == param.EmpresaId && p.SucursalId == param.SucursalId &&
                                                                   (param.MostrarDescontinuados || (p.Marca == null || p.Marca.Descontinuado == BoolCN.N)) &&
                                                                   (param.TipoProductoPorPadreHijo == TipoProductoPorPadreHijo.tp_todos ||
                                                                                    (param.TipoProductoPorPadreHijo == TipoProductoPorPadreHijo.tp_padres && p.Producto_padre == null) ||
                                                                                    (param.TipoProductoPorPadreHijo == TipoProductoPorPadreHijo.tp_hijos && p.Producto_padre != null)
                                                                   ) &&
                                                                   (!param.SoloConExistencias ||
                                                                     (
                                                                            (p.Producto_inventario != null && p.Producto_inventario.Inventariable != BoolCS.S) ||
                                                                            (p.Producto_inventario != null && p.Producto_inventario.Negativos == BoolCN.S) ||
                                                                            (
                                                                               (!param.PorExistenciaDeAlmacen && (p.Producto_existencia != null && p.Producto_existencia.Existencia > 0)) ||
                                                                               (param.PorExistenciaDeAlmacen &&
                                                                                (
                                                                                      param.AlmacenId == null ||
                                                                                      (
                                                                                       p.Inventarios != null && p.Inventarios.Where(i => i.Almacenid == param.AlmacenId && i.Esapartado != BoolCN.S).Sum(i => i.Cantidad) > 0
                                                                                      )
                                                                                )
                                                                              )
                                                                            )
                                                                     )
                                                                   ) &&
                                                                   ((cadenaBusquedaLower == null || cadenaBusquedaLower.Length == 0) || (p.Clave.ToLower().Contains(cadenaBusquedaLower) || p.Nombre.ToLower().Contains(cadenaBusquedaLower) || p.Descripcion.ToLower().Contains(cadenaBusquedaLower) ||
                                                                                                                                           (p.Descripcion1 != null && p.Descripcion1.ToLower().Contains(cadenaBusquedaLower)) || (p.Descripcion2 != null && p.Descripcion2.ToLower().Contains(cadenaBusquedaLower)) || (p.Descripcion3 != null && p.Descripcion3.ToLower().Contains(cadenaBusquedaLower)) ||
                                                                                                                                           (p.Ean != null && p.Ean.ToLower().Contains(cadenaBusquedaLower)) || (p.Cbarras != null && p.Cbarras.ToLower().Contains(cadenaBusquedaLower)) || (p.Cempaque != null && p.Cempaque.ToLower().Contains(cadenaBusquedaLower))
                                                                                                                                          )
                                                                  )
                                                          )
                                                          .Select(x => new ProductoListBindingModel(x,
                                                                                                        parametro, clienteMostrador, 
                                                                                                        param.AlmacenId1, param.AlmacenId2, param.AlmacenId3, param.PorcUtilidad)).ToList();
                }
                return lstProducto;


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

    public class Tmp_ProductoAutocomplete
    {
        public long Id { get; }
        public string Clave { get; }
        public string? Descripcion1 { get; }
        public decimal Existencia { get; }

        public Tmp_ProductoAutocomplete(long id, string clave, string? descripcion1, decimal existencia)
        {
            Id = id;
            Clave = clave;
            Descripcion1 = descripcion1;
            Existencia = existencia;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_ProductoAutocomplete other &&
                   Id == other.Id &&
                   Clave == other.Clave &&
                   Descripcion1 == other.Descripcion1 &&
                   Existencia == other.Existencia;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Clave, Descripcion1, Existencia);
        }
    }
}
