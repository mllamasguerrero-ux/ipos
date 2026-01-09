
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
//--using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;
using KendoNET.DynamicLinq;
//--using Syncfusion.Windows.Shared;
using IposV3.Extensions;
using Castle.Core.Internal;
using IposV3.Services;

namespace Controllers.Controller
{

    public class MovtoController : BaseController<MovtoBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;
        private MovtoService _movtoService;

        public MovtoController(
            MovtoService movtoService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._movtoService = movtoService;
        }


        public override MovtoBindingModel? GetById(MovtoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Movto.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new MovtoBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<MovtoBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Movto.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new MovtoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<MovtoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            MovtoParam itemParam = (MovtoParam)param;

            List<MovtoBindingModel> listToReturn = new List<MovtoBindingModel>();

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
                var basicQuery = applicationDbContext.Movto.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Movto>()
                      .Select(x => new MovtoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(MovtoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Movto entityItem = new Movto();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Movto.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<MovtoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<MovtoBindingModel> SelectById(MovtoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            MovtoBindingModel item = new MovtoBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Movto.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new MovtoBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(MovtoBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Movto
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Movto?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(MovtoBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Movto?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Movto?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
        public IQueryable<Movto> QueryableWithIncludes(IQueryable<Movto> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Estatusmovto)
              .Include(c => c.Producto)
              .Include(c => c.Loteimportado_)
              .Include(c => c.Movtoparent)
              .Include(c => c.Docto)
              .Include(c => c.Movto_comision)
              .Include(c => c.Movto_comodin)
              .Include(c => c.Movto_cancelacion).ThenInclude(d => d!.Movtoref)
              .Include(c => c.Movto_devolucion).ThenInclude(d => d!.Movtoref)
              .Include(c => c.Movto_devolucion).ThenInclude(d => d!.Razondiferencia)
              .Include(c => c.Movto_loteimportado).ThenInclude(d => d!.Movtoloteimportadoref)
              .Include(c => c.Movto_emida).ThenInclude(d => d!.Emidarequest)
              .Include(c => c.Movto_fact_elect_consolidacion)
              .Include(c => c.Movto_inventario).ThenInclude(d => d!.Tipodiferenciainventario)
              .Include(c => c.Movto_inventario).ThenInclude(d => d!.Anaquel)
              .Include(c => c.Movto_kit)
              .Include(c => c.Movto_kit_defs)!.ThenInclude(d => d!.Productokit)
              .Include(c => c.Movto_kit_defs)!.ThenInclude(d => d!.Productoparte)
              .Include(c => c.Movto_monedero)
              .Include(c => c.Movto_ordencompra).ThenInclude(d => d!.Movtoref)
              .Include(c => c.Movto_origenfiscal)
              .Include(c => c.Movto_poliza)
              .Include(c => c.Movto_precio).ThenInclude(d => d.Listaprecio)
              .Include(c => c.Movto_promocion).ThenInclude(d => d.Promocion_)
              .Include(c => c.Movto_rebajaespecial).ThenInclude(d => d.Estadorebaja_)
              .Include(c => c.Movto_revision)
              .Include(c => c.Movto_surtido)
              .Include(c => c.Movto_traslado).ThenInclude(d => d.Movtoimportado)
              .Include(c => c.Movto_traslado).ThenInclude(d => d.Motivodevolucion)
              ;

        }
#pragma warning restore CS8602



        public Movto_command_deciphered? DecipherCommand(long empresaId, long sucursalId, string commandText)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _movtoService.DecipherCommand(empresaId, sucursalId, commandText, applicationDbContext);
        }



    }

}



