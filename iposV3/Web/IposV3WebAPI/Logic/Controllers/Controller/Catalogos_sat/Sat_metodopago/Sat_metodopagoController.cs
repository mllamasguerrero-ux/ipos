
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

    public class Sat_metodopagoController : BaseController<Sat_metodopagoBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;

        public Sat_metodopagoController(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override Sat_metodopagoBindingModel? GetById(Sat_metodopagoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_metodopago.AsNoTracking()
                           .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new Sat_metodopagoBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<Sat_metodopagoBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_metodopago.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new Sat_metodopagoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<Sat_metodopagoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Sat_metodopagoParam itemParam = (Sat_metodopagoParam)param;

            List<Sat_metodopagoBindingModel> listToReturn = new List<Sat_metodopagoBindingModel>();

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
                var basicQuery = applicationDbContext.Sat_metodopago.AsNoTracking();


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Sat_metodopago>()
                      .Select(x => new Sat_metodopagoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(Sat_metodopagoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Sat_metodopago entityItem = new Sat_metodopago();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Sat_metodopago.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<Sat_metodopagoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<Sat_metodopagoBindingModel> SelectById(Sat_metodopagoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Sat_metodopagoBindingModel item = new Sat_metodopagoBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_metodopago.AsNoTracking()
                .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new Sat_metodopagoBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(Sat_metodopagoBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Sat_metodopago
                           .Where(x => x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Sat_metodopago?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(Sat_metodopagoBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Sat_metodopago?
            .Single(m => m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Sat_metodopago?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Sat_metodopago> QueryableWithIncludes(IQueryable<Sat_metodopago> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



