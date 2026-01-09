
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

    public class EmidaproductController : BaseController<EmidaproductBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public EmidaproductController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override EmidaproductBindingModel? GetById(EmidaproductBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Emidaproduct.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new EmidaproductBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<EmidaproductBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Emidaproduct.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new EmidaproductBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<EmidaproductBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            EmidaproductParam itemParam = (EmidaproductParam)param;

            List<EmidaproductBindingModel> listToReturn = new List<EmidaproductBindingModel>();

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
                var basicQuery = applicationDbContext.Emidaproduct.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Emidaproduct>()
                      .Select(x => new EmidaproductBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(EmidaproductBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Emidaproduct entityItem = new Emidaproduct();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Emidaproduct.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<EmidaproductBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<EmidaproductBindingModel> SelectById(EmidaproductBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            EmidaproductBindingModel item = new EmidaproductBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Emidaproduct.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new EmidaproductBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(EmidaproductBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Emidaproduct
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Emidaproduct?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(EmidaproductBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Emidaproduct?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Emidaproduct?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Emidaproduct> QueryableWithIncludes(IQueryable<Emidaproduct> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



