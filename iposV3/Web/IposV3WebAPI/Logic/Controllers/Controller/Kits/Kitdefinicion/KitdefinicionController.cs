
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

    public class KitdefinicionController : BaseController<KitdefinicionBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private KitdefinicionService _kitdefinicionService;

        public KitdefinicionController(IDbContextFactory<ApplicationDbContext> operationsContextFactory, 
                                       KitdefinicionService kitdefinicionService)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._kitdefinicionService = kitdefinicionService;
        }


        public override KitdefinicionBindingModel? GetById(KitdefinicionBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Kitdefinicion.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new KitdefinicionBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<KitdefinicionBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Kitdefinicion.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new KitdefinicionBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<KitdefinicionBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            KitdefinicionParam itemParam = (KitdefinicionParam)param;

            List<KitdefinicionBindingModel> listToReturn = new List<KitdefinicionBindingModel>();

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
                var basicQuery = applicationDbContext.Kitdefinicion.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Kitdefinicion>()
                      .Select(x => new KitdefinicionBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }



        public  bool InsertYModificarImpuestosSiAplica(KitdefinicionBindingModel item, out ImpuestoKitDefinicion? impuestoKitDefinicion)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Kitdefinicion entityItem = new Kitdefinicion();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Kitdefinicion.Add(entityItem);
            applicationDbContext.SaveChanges();


            impuestoKitDefinicion = CurrentInfoImpuestosKit(item.EmpresaId!.Value, item.SucursalId!.Value, item.Productokitid!.Value);

            _kitdefinicionService.ActualizaCalculoDeImpuestos(entityItem.EmpresaId, entityItem.SucursalId, entityItem.Productokitid!.Value, applicationDbContext, out impuestoKitDefinicion);
            return true;
        }

        public override bool Insert(KitdefinicionBindingModel item)
        {
            throw new Exception("Llama al otro metodo de insert");
        }


        public override List<KitdefinicionBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<KitdefinicionBindingModel> SelectById(KitdefinicionBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            KitdefinicionBindingModel item = new KitdefinicionBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Kitdefinicion.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new KitdefinicionBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public  bool UpdateYModificarImpuestosSiAplica(KitdefinicionBindingModel item, out ImpuestoKitDefinicion? impuestoKitDefinicion)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Kitdefinicion
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            impuestoKitDefinicion = CurrentInfoImpuestosKit(item.EmpresaId!.Value, item.SucursalId!.Value, item.Productokitid!.Value);

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Kitdefinicion?.Update(entityItem);
                applicationDbContext.SaveChanges();

                _kitdefinicionService.ActualizaCalculoDeImpuestos(entityItem.EmpresaId, entityItem.SucursalId, entityItem.Productokitid!.Value, applicationDbContext, out impuestoKitDefinicion);
                
            }

            return true;

        }


        public override bool Update(KitdefinicionBindingModel item)
        {
            throw new Exception("Llama al otro metodo de update");
        }

        public ImpuestoKitDefinicion? CurrentInfoImpuestosKit(long empresaId , long sucursalId , long productoKitId)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var producto = applicationDbContext.Producto.AsNoTracking()
                                              .FirstOrDefault(j => j.EmpresaId == empresaId && j.SucursalId == sucursalId && j.Id == productoKitId);
            if (producto == null)
                return null;

            return new ImpuestoKitDefinicion() { Ieps = producto.Iepsimpuesto, Iva = producto.Ivaimpuesto, Isr = 0m };
        }



        public bool DeleteYModificarImpuestosSiAplica(KitdefinicionBindingModel item, out ImpuestoKitDefinicion? impuestoKitDefinicion)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Kitdefinicion?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            impuestoKitDefinicion = CurrentInfoImpuestosKit(item.EmpresaId!.Value, item.SucursalId!.Value, item.Productokitid!.Value);

            if (entityItem != null)
            {
                applicationDbContext.Kitdefinicion?.Remove(entityItem);
                applicationDbContext.SaveChanges();

                _kitdefinicionService.ActualizaCalculoDeImpuestos(entityItem.EmpresaId, entityItem.SucursalId, entityItem.Productokitid!.Value, applicationDbContext, out impuestoKitDefinicion);

            }

            return true;
        }

        public override bool Delete(KitdefinicionBindingModel item)
        {


            throw new Exception("Llama al otro metodo de update");
        }


#pragma warning disable CS8602
    public IQueryable<Kitdefinicion> QueryableWithIncludes(IQueryable<Kitdefinicion> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Productokit)
              .Include(c => c.Productoparte)
              ;

        }  
#pragma warning restore CS8602





    }

    

}



