
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

    public class CorteController : BaseController<CorteBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private CorteService _corteService;

        public CorteController(
            CorteService corteService,    
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._corteService = corteService;
        }


        public override CorteBindingModel? GetById(CorteBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Corte.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new CorteBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<CorteBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Corte.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new CorteBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<CorteBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            CorteParam itemParam = (CorteParam)param;

            List<CorteBindingModel> listToReturn = new List<CorteBindingModel>();

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
                var basicQuery = applicationDbContext.Corte.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Corte>()
                      .Select(x => new CorteBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(CorteBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Corte entityItem = new Corte();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Corte.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<CorteBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<CorteBindingModel> SelectById(CorteBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            CorteBindingModel item = new CorteBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Corte.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new CorteBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(CorteBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Corte
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Corte?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(CorteBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Corte?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Corte?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


        public CorteBindingModel? CorteActivoUsuario(long? empresaId, long? sucursalId, long? usuarioId)
        {
            if (empresaId == null || sucursalId == null || usuarioId == null)
                return null;

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            long? corteId = applicationDbContext.Corte
                .OrderBy(p => p.Activo == BoolCS.S ? 0 : 1).ThenByDescending(p => p.Fechacorte)
                .FirstOrDefault(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Cajeroid == usuarioId  )?.Id;

            if (corteId == null)
                return null;

            CorteBindingModel corteBindingModel = new CorteBindingModel();
            corteBindingModel.EmpresaId = empresaId;
            corteBindingModel.SucursalId = sucursalId;
            corteBindingModel.Id = corteId;

            return GetById(corteBindingModel);
        }

        public CorteBindingModel? CorteUsuarioFecha(long? empresaId, long? sucursalId, long? usuarioId, DateTimeOffset fecha)
        {
            if (empresaId == null || sucursalId == null || usuarioId == null)
                return null;

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            //var corte = applicationDbContext.Corte.FirstOrDefault(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Cajeroid == usuarioId );

            var dateCorte = fecha.DateTime.Date;

            long? corteId = _corteService.CorteUsuarioFecha(empresaId!.Value, sucursalId!.Value, usuarioId!.Value, fecha, applicationDbContext)?.Id; //applicationDbContext.Corte.FirstOrDefault(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Cajeroid == usuarioId && y.Fechacorte!.Value.DateTime.Date == dateCorte )?.Id;

            if (corteId == null)
                return null;

            CorteBindingModel corteBindingModel = new CorteBindingModel();
            corteBindingModel.EmpresaId = empresaId;
            corteBindingModel.SucursalId = sucursalId;
            corteBindingModel.Id = corteId;

            return GetById(corteBindingModel);
        }


        public bool AbrirCorte(CorteBindingModel? item)
        {
            if (item == null)
                return false;

            if (item.Id == null || item.Id == 0)
                return AbrirNuevoCorte(item!);
            else
                return ReabrirCorte(item!);
        }

        public bool ReabrirCorte(CorteBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Corte
                          .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                entityItem.Activo = BoolCS.S;

                applicationDbContext.Corte?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


        public bool AbrirNuevoCorte(CorteBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Corte entityItem = new Corte();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            entityItem.Activo = BoolCS.S;
            applicationDbContext.Corte.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public bool CerrarCorte(CorteBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Corte
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                entityItem.Activo = BoolCS.N;
                entityItem.Termina = DateTimeOffset.Now;

                applicationDbContext.Corte?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
        public IQueryable<Corte> QueryableWithIncludes(IQueryable<Corte> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Caja)
              .Include(c => c.Cajero)
              .Include(c => c.Tipocorte)
              .Include(c => c.Corterecoleccion)
              ;

        }  
#pragma warning restore CS8602

    }

}



