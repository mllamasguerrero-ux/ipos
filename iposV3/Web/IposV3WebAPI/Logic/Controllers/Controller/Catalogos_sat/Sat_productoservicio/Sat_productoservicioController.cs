
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

    public class Sat_productoservicioController : BaseController<Sat_productoservicioBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;

        public Sat_productoservicioController(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override Sat_productoservicioBindingModel? GetById(Sat_productoservicioBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_productoservicio.AsNoTracking()
                           .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new Sat_productoservicioBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<Sat_productoservicioBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_productoservicio.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new Sat_productoservicioBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<Sat_productoservicioBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Sat_productoservicioParam itemParam = (Sat_productoservicioParam)param;

            List<Sat_productoservicioBindingModel> listToReturn = new List<Sat_productoservicioBindingModel>();

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
                var basicQuery = applicationDbContext.Sat_productoservicio.AsNoTracking();


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Sat_productoservicio>()
                      .Select(x => new Sat_productoservicioBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(Sat_productoservicioBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Sat_productoservicio entityItem = new Sat_productoservicio();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Sat_productoservicio.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<Sat_productoservicioBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<Sat_productoservicioBindingModel> SelectById(Sat_productoservicioBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Sat_productoservicioBindingModel item = new Sat_productoservicioBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sat_productoservicio.AsNoTracking()
                .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new Sat_productoservicioBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(Sat_productoservicioBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");


            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            var basicQuery = applicationDbContext.Sat_productoservicio
                           .Where(x => x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Sat_productoservicio?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(Sat_productoservicioBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Sat_productoservicio?
            .Single(m => m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Sat_productoservicio?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Sat_productoservicio> QueryableWithIncludes(IQueryable<Sat_productoservicio> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



