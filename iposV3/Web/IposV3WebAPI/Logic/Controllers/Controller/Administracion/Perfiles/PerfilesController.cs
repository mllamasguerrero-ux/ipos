
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
using KendoNET.DynamicLinq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;

//--using Syncfusion.Windows.Shared;
using Castle.Core.Internal;

namespace Controllers.Controller
{

    public class PerfilesController : BaseController<PerfilesBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;

        public PerfilesController(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override PerfilesBindingModel? GetById(PerfilesBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Perfiles.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new PerfilesBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return item;
        }

        public override List<PerfilesBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Perfiles.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new PerfilesBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<PerfilesBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            PerfilesParam itemParam = (PerfilesParam)param;

            List<PerfilesBindingModel> listToReturn = new List<PerfilesBindingModel>();

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
                var basicQuery = applicationDbContext.Perfiles.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                IEnumerable<int> enumerable = Enumerable.Range(1, 300);
                List<int> asList = enumerable.ToList();

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Perfiles>()
                      .Select(x => new PerfilesBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(PerfilesBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Perfiles entityItem = new Perfiles();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Perfiles.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<PerfilesBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<PerfilesBindingModel> SelectById(PerfilesBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            PerfilesBindingModel item = new PerfilesBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Perfiles.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new PerfilesBindingModel(x)).ToList();



            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(PerfilesBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");


            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            var basicQuery = applicationDbContext.Perfiles
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Perfiles?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(PerfilesBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Perfiles?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Perfiles?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Perfiles> QueryableWithIncludes(IQueryable<Perfiles> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602


        public List<PerfilDerechoItemBindingModel> GetPerfilesDerechos(
                PerfilesBindingModel itemSelect,  KendoParams? kendoParams)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var perfiles_derechos = new List<PerfilDerechoItemBindingModel>();

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
                var perfilDerList = applicationDbContext.Perfil_der.AsNoTracking()
                                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Perfilid == itemSelect.Id!).ToList();


                var derechosList = applicationDbContext.Derechos.ToList();


                perfiles_derechos = PerfilDerechoItemBindingModel.GetPerfilesDerechosList(derechosList, perfilDerList);


                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return perfiles_derechos;

            }
            catch
            {
                throw;
            }


        }


        public bool UpdatePerfilesDerechos(
                PerfilesBindingModel itemSelect, List<PerfilDerechoItemBindingModel> perfiles_derechos)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var perfilDerList = applicationDbContext.Perfil_der
                            .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Perfilid == itemSelect.Id!).ToList();
            
            // primero eliminar los que estan en perfilderlist y no en la
            var perfilDerListAEliminar = perfilDerList.Where(y => !perfiles_derechos.Any(x => (x.Permitido ?? false) && x.Dr_derecho == y.Derechoid)).ToList();
            perfilDerList = perfilDerList.Where(y => perfiles_derechos.Any(x => (x.Permitido ?? false) && x.Dr_derecho == y.Derechoid)).ToList();

            // agregar los que no estan
            var perfilDerListAAgregar = perfiles_derechos.Where( pd => (pd.Permitido ?? false) && !perfilDerList.Any( y => y.Derechoid == pd.Dr_derecho) )
                .Select( pd => new Perfil_der() { EmpresaId = itemSelect.EmpresaId!.Value, SucursalId = itemSelect.SucursalId!.Value, Perfilid = itemSelect.Id!.Value, Derechoid = pd.Dr_derecho})
                .ToList();

            foreach(var perfilderAEliminar in perfilDerListAEliminar)
            {
                applicationDbContext.Perfil_der.Remove(perfilderAEliminar);
            }

            foreach (var perfilDerAAgregar in perfilDerListAAgregar)
            {
                applicationDbContext.Perfil_der.Add(perfilDerAAgregar);
            }

            applicationDbContext.SaveChanges();


            return true;
        }

    }

}



