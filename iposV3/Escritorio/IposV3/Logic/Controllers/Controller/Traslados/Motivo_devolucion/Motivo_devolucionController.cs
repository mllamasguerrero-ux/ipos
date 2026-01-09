
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

    public class Motivo_devolucionController : BaseController<Motivo_devolucionBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public Motivo_devolucionController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override Motivo_devolucionBindingModel? GetById(Motivo_devolucionBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Motivo_devolucion.AsNoTracking()
                           .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new Motivo_devolucionBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<Motivo_devolucionBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Motivo_devolucion.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new Motivo_devolucionBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<Motivo_devolucionBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            Motivo_devolucionParam itemParam = (Motivo_devolucionParam)param;

            List<Motivo_devolucionBindingModel> listToReturn = new List<Motivo_devolucionBindingModel>();

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
                var basicQuery = applicationDbContext.Motivo_devolucion.AsNoTracking();


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Motivo_devolucion>()
                      .Select(x => new Motivo_devolucionBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(Motivo_devolucionBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Motivo_devolucion entityItem = new Motivo_devolucion();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Motivo_devolucion.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<Motivo_devolucionBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<Motivo_devolucionBindingModel> SelectById(Motivo_devolucionBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Motivo_devolucionBindingModel item = new Motivo_devolucionBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Motivo_devolucion.AsNoTracking()
                .Where(x => x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new Motivo_devolucionBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(Motivo_devolucionBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Motivo_devolucion
                           .Where(x => x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Motivo_devolucion?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(Motivo_devolucionBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Motivo_devolucion?
            .Single(m => m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Motivo_devolucion?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Motivo_devolucion> QueryableWithIncludes(IQueryable<Motivo_devolucion> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



