
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

    public class Sat_regimenfiscalController : BaseController<Sat_regimenfiscalBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public Sat_regimenfiscalController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override Sat_regimenfiscalBindingModel? GetById(Sat_regimenfiscalBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_regimenfiscal.AsNoTracking()
                           .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new Sat_regimenfiscalBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<Sat_regimenfiscalBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_regimenfiscal.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new Sat_regimenfiscalBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<Sat_regimenfiscalBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            Sat_regimenfiscalParam itemParam = (Sat_regimenfiscalParam)param;

            List<Sat_regimenfiscalBindingModel> listToReturn = new List<Sat_regimenfiscalBindingModel>();

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
                var basicQuery = applicationDbContext.Sat_regimenfiscal.AsNoTracking();


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Sat_regimenfiscal>()
                      .Select(x => new Sat_regimenfiscalBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(Sat_regimenfiscalBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Sat_regimenfiscal entityItem = new Sat_regimenfiscal();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Sat_regimenfiscal.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<Sat_regimenfiscalBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<Sat_regimenfiscalBindingModel> SelectById(Sat_regimenfiscalBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Sat_regimenfiscalBindingModel item = new Sat_regimenfiscalBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_regimenfiscal.AsNoTracking()
                .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new Sat_regimenfiscalBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(Sat_regimenfiscalBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Sat_regimenfiscal
                           .Where(x => x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Sat_regimenfiscal?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(Sat_regimenfiscalBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Sat_regimenfiscal?
            .Single(m => m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Sat_regimenfiscal?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Sat_regimenfiscal> QueryableWithIncludes(IQueryable<Sat_regimenfiscal> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



