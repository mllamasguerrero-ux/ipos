
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

namespace Controllers.Controller
{

    public class ProductoController : BaseController<ProductoBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;
        private ProductoService _productoService;

        public ProductoController(OperationsContextFactory operationsContextFactory,
                                  ProductoService productoService)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._productoService = productoService;
        }


        public override ProductoBindingModel? GetById(ProductoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Producto.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new ProductoBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<ProductoBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Producto.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new ProductoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<ProductoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            ProductoParam itemParam = (ProductoParam)param;

            List<ProductoBindingModel> listToReturn = new List<ProductoBindingModel>();

            try
            {

                if (kendoParams != null)
                {
                    kendoParams!.RemoveAllGeneralFilterFromFilters();

                    if (kendoParams!.GeneralFilter != null && kendoParams!.GeneralFilter!.Value != null && !kendoParams!.GeneralFilter!.Value.IsNullOrEmpty())
                        kendoParams!.AddGeneralFilterToFilters();

                    if (kendoParams!.Sort == null)
                        kendoParams!.Sort = FillDefaultSort();
                }

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var basicQuery = applicationDbContext.Producto.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Producto>()
                      .Select(x => new ProductoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }



        public List<ProductoListBindingModel> SelectForSimpleList(object param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            ProductoParam itemParam = (ProductoParam)param;

            List<ProductoListBindingModel> listToReturn = new List<ProductoListBindingModel>();

            try
            {
                itemParam.CadenaBusqueda = kendoParams?.GeneralFilter?.Value;
                listToReturn = this._productoService.SelectLista(itemParam, applicationDbContext);

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }

        
        public Prod_def_caracteristicasBindingModel? ObtenerProd_def_Caracterisiticas(Prod_def_caracteristicasBindingModel obj)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();
            var prod_def = applicationDbContext.Prod_def_caracteristicas.AsNoTracking()
                                               .FirstOrDefault(x => x.EmpresaId == obj.EmpresaId && x.SucursalId == obj.SucursalId);
            if (prod_def != null)
                return new Prod_def_caracteristicasBindingModel(prod_def);
                                               

            return null;
        }

        public bool GuardarProd_def_caracteristicas(Prod_def_caracteristicasBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();


            var basicQuery = applicationDbContext.Prod_def_caracteristicas
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId );


            var entityItem = basicQuery.FirstOrDefault();


            if (entityItem == null)
            {
                Prod_def_caracteristicas entityItemToAdd = new Prod_def_caracteristicas();
                item.FillEntityValues(ref entityItemToAdd);
                applicationDbContext.Prod_def_caracteristicas?.Add(entityItemToAdd);
                applicationDbContext.SaveChanges();
                return true;

            }


            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Prod_def_caracteristicas?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }




        //public  List<ProductoListBindingModel> SelectForSimpleList(object param, KendoParams? kendoParams)
        //{
        //    if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

        //    using var applicationDbContext = this._operationsContextFactory.Create();

        //    ProductoParam itemParam = (ProductoParam)param;

        //    List<ProductoListBindingModel> listToReturn = new List<ProductoListBindingModel>();

        //    try
        //    {

        //        if (kendoParams != null)
        //        {
        //            kendoParams!.RemoveAllGeneralFilterFromFilters();

        //            if (kendoParams!.GeneralFilter != null && kendoParams!.GeneralFilter!.Value != null && !kendoParams!.GeneralFilter!.Value.IsNullOrEmpty())
        //                kendoParams!.AddGeneralFilterToFilters();

        //            if (kendoParams!.Sort == null)
        //                kendoParams!.Sort = FillDefaultSort();
        //        }

        //        applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;
        //        var basicQuery = applicationDbContext.Producto.AsNoTracking()
        //                        .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


        //        var queryWithIncludes = QueryableWithIncludesBasic(basicQuery);

        //        var lstQuery = queryWithIncludes
        //              .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
        //              .Data.ToList<Producto>()
        //              .Select(x => new ProductoListBindingModel(x));

        //        listToReturn.AddRange(lstQuery);

        //        applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

        //        return listToReturn;

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public override bool Insert(ProductoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Producto entityItem = new Producto();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Producto.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<ProductoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<ProductoBindingModel> SelectById(ProductoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            ProductoBindingModel item = new ProductoBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Producto.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new ProductoBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(ProductoBindingModel item)
        {
            //if (item.HasErrors)
            //   throw new InvalidOperationException("Hay datos no validos en este registro");


            using var applicationDbContext = this._operationsContextFactory.Create();


            var basicQuery = applicationDbContext.Producto
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Producto?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(ProductoBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Producto?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Producto?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }




#pragma warning disable CS8602
    public IQueryable<Producto> QueryableWithIncludes(IQueryable<Producto> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Proveedor1)
              .Include(c => c.Proveedor2)
              .Include(c => c.Linea)
              .Include(c => c.Marca)
              .Include(c => c.Unidad)
              .Include(c => c.Producto_apartado)
              .Include(c => c.Producto_comision)
              .Include(c => c.Producto_comodin)
              .Include(c => c.Producto_loteimportado)
              .Include(c => c.Producto_emida).ThenInclude(d => d.Emidaproducto)
              .Include(c => c.Producto_fact_elect).ThenInclude(d => d.Sat_productoservicio)
              .Include(c => c.Producto_fact_elect).ThenInclude(d => d.Sat_Tipoembalaje)
              .Include(c => c.Producto_fact_elect).ThenInclude(d => d.Sat_Claveunidadpeso)
              .Include(c => c.Producto_fact_elect).ThenInclude(d => d.Sat_Matpeligroso)
              .Include(c => c.Producto_farmacia)
              .Include(c => c.Producto_existencia)
              .Include(c => c.Producto_inventario)
              .Include(c => c.Producto_kit)
              .Include(c => c.Producto_origenfiscal).ThenInclude(d => d.Ultimoorigenfiscalventa_)
              .Include(c => c.Producto_poliza).ThenInclude(d => d.Plazo)
              .Include(c => c.Producto_precios).ThenInclude(d => d.Listaprecmediomay)
              .Include(c => c.Producto_precios).ThenInclude(d => d.Listaprecmayoreo)
              .Include(p => p.Producto_precios).ThenInclude(p => p!.Moneda)
              .Include(c => c.Producto_promocion).ThenInclude(d => d.Baseprodpromo)
              .Include(c => c.Producto_miscelanea).ThenInclude(d => d.Clasifica)
              .Include(c => c.Producto_miscelanea).ThenInclude(d => d.Contenido)
              .Include(c => c.Producto_padre).ThenInclude(d => d.Productopadre)
              .Include(c => c.Producto_utilidad)
              .Include(c => c.Productocaracteristicas)
              .Include(p => p.Substituto)
              ;

        }

        public IQueryable<Producto> QueryableWithIncludesBasic(IQueryable<Producto> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Proveedor1)
              .Include(c => c.Proveedor2)
              .Include(c => c.Linea)
              .Include(c => c.Marca)
              .Include(c => c.Unidad)
              .Include(c => c.Producto_existencia)
              .Include(c => c.Producto_inventario)
              .Include(c => c.Producto_kit)
              .Include(c => c.Producto_precios).ThenInclude(d => d.Listaprecmediomay)
              .Include(c => c.Producto_precios).ThenInclude(d => d.Listaprecmayoreo)
              ;

        }

#pragma warning restore CS8602

    }

}



