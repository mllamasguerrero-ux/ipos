
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

namespace Controllers.Controller
{

    public class ContenidoController : BaseController<ContenidoBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public ContenidoController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override ContenidoBindingModel? GetById(ContenidoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Contenido.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new ContenidoBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<ContenidoBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Contenido.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new ContenidoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<ContenidoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            ContenidoParam itemParam = (ContenidoParam)param;

            List<ContenidoBindingModel> listToReturn = new List<ContenidoBindingModel>();

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
                var basicQuery = applicationDbContext.Contenido.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Contenido>()
                      .Select(x => new ContenidoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(ContenidoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Contenido entityItem = new Contenido();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Contenido.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<ContenidoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<ContenidoBindingModel> SelectById(ContenidoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            ContenidoBindingModel item = new ContenidoBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Contenido.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new ContenidoBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(ContenidoBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Contenido
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Contenido?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(ContenidoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Contenido?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Contenido?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Contenido> QueryableWithIncludes(IQueryable<Contenido> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



