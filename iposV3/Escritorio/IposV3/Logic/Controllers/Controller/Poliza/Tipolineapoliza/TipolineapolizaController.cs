
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

    public class TipolineapolizaController : BaseController<TipolineapolizaBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public TipolineapolizaController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override TipolineapolizaBindingModel? GetById(TipolineapolizaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Tipolineapoliza.AsNoTracking()
                           .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new TipolineapolizaBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<TipolineapolizaBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Tipolineapoliza.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new TipolineapolizaBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<TipolineapolizaBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            TipolineapolizaParam itemParam = (TipolineapolizaParam)param;

            List<TipolineapolizaBindingModel> listToReturn = new List<TipolineapolizaBindingModel>();

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
                var basicQuery = applicationDbContext.Tipolineapoliza.AsNoTracking();


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Tipolineapoliza>()
                      .Select(x => new TipolineapolizaBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(TipolineapolizaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Tipolineapoliza entityItem = new Tipolineapoliza();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Tipolineapoliza.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<TipolineapolizaBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<TipolineapolizaBindingModel> SelectById(TipolineapolizaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            TipolineapolizaBindingModel item = new TipolineapolizaBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Tipolineapoliza.AsNoTracking()
                .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new TipolineapolizaBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(TipolineapolizaBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Tipolineapoliza
                           .Where(x => x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Tipolineapoliza?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(TipolineapolizaBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Tipolineapoliza?
            .Single(m => m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Tipolineapoliza?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Tipolineapoliza> QueryableWithIncludes(IQueryable<Tipolineapoliza> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



