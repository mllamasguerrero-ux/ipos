
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

    public class Sucursal_infoController : BaseController<Sucursal_infoBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public Sucursal_infoController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override Sucursal_infoBindingModel? GetById(Sucursal_infoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sucursal_info.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new Sucursal_infoBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<Sucursal_infoBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sucursal_info.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new Sucursal_infoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<Sucursal_infoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {

            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            Sucursal_infoParam itemParam = (Sucursal_infoParam)param;

            List<Sucursal_infoBindingModel> listToReturn = new List<Sucursal_infoBindingModel>();

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
                var basicQuery = applicationDbContext.Sucursal_info.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Sucursal_info>()
                      .Select(x => new Sucursal_infoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(Sucursal_infoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Sucursal_info entityItem = new Sucursal_info();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Sucursal_info.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<Sucursal_infoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<Sucursal_infoBindingModel> SelectById(Sucursal_infoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Sucursal_infoBindingModel item = new Sucursal_infoBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Sucursal_info.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new Sucursal_infoBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(Sucursal_infoBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Sucursal_info
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Sucursal_info?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(Sucursal_infoBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Sucursal_info?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Sucursal_info?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Sucursal_info> QueryableWithIncludes(IQueryable<Sucursal_info> itemBasicQuery)
        {


            return itemBasicQuery.Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Gruposucursal)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Cliente)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Proveedor)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Banco)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Empprov)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entregaestado)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Colonia)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Localidad)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Municipio)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Listaprecio)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Surtidor)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_respaldo)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Preciorecepciontraslado_)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Precioenviotraslado_)
              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Lista_precio_traspaso_);

        }  
#pragma warning restore CS8602

    }

}



