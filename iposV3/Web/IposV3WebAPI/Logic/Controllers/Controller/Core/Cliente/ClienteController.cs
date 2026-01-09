
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

    public class ClienteController : BaseController<ClienteBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;

        public ClienteController(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override ClienteBindingModel? GetById(ClienteBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Cliente.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new ClienteBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<ClienteBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Cliente.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new ClienteBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<ClienteBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            ClienteParam itemParam = (ClienteParam)param;

            List<ClienteBindingModel> listToReturn = new List<ClienteBindingModel>();

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
                var basicQuery = applicationDbContext.Cliente.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var sql = queryWithIncludes.ToQueryString();

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Cliente>()
                      .Select(x => new ClienteBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(ClienteBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Cliente entityItem = new Cliente();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;

            if(entityItem.Cliente_fact_elect != null)
                entityItem.Cliente_fact_elect.Sat_id_pais = null;

            applicationDbContext.Cliente.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<ClienteBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<ClienteBindingModel> SelectById(ClienteBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            ClienteBindingModel item = new ClienteBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Cliente.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new ClienteBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(ClienteBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Cliente
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludesWithEdit(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValuesForUpdate(ref entityItem);

                applicationDbContext.Cliente?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(ClienteBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Cliente?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Cliente?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Cliente> QueryableWithIncludes(IQueryable<Cliente> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Subtipocliente)
              .Include(c => c.Proveecliente)
              .Include(c => c.Domicilio)
              .Include(c => c.Contacto1)
              .Include(c => c.Contacto1).ThenInclude(s => s.Domicilio)
              .Include(c => c.Contacto2)
              .Include(c => c.Contacto2).ThenInclude(s => s.Domicilio)
              .Include(c => c.Domicilioentrega)
              .Include(c => c.Cliente_bancomer).ThenInclude(d => d.Bancomerdoctopend)
              .Include(c => c.Cliente_comision).ThenInclude(d => d.Vendedor)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Creditoformapagosatabonos_)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_usocfdi)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_pais)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Colonia)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Localidad)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Municipio)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Entrega_Sat_Colonia)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Entrega_Sat_Localidad)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Entrega_Sat_Municipio)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Regimenfiscal)
              .Include(c => c.Cliente_ordencompra)
              .Include(c => c.Cliente_pago)
              .Include(c => c.Cliente_pago_parametros).ThenInclude(d => d.Creditoformapagoabonos_)
              .Include(c => c.Cliente_pago_parametros).ThenInclude(d => d.Moneda)
              .Include(c => c.Cliente_poliza)
              .Include(c => c.Cliente_precio).ThenInclude(d => d.Listaprecio)
              .Include(c => c.Cliente_precio).ThenInclude(d => d.Superlistaprecio)
              .Include(c => c.Cliente_rutaembarque).ThenInclude(d => d.Rutaembarque)
              ;

        }

        public IQueryable<Cliente> QueryableWithIncludesWithEdit(IQueryable<Cliente> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Subtipocliente)
              .Include(c => c.Proveecliente)
              .Include(c => c.Domicilio)
              .Include(c => c.Contacto1)
              .Include(c => c.Contacto1).ThenInclude(s => s.Domicilio)
              .Include(c => c.Contacto2)
              .Include(c => c.Contacto2).ThenInclude(s => s.Domicilio)
              .Include(c => c.Domicilioentrega)
              .Include(c => c.Cliente_bancomer).ThenInclude(d => d.Bancomerdoctopend)
              .Include(c => c.Cliente_comision).ThenInclude(d => d.Vendedor)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Creditoformapagosatabonos_)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_usocfdi)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_pais)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Colonia)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Localidad)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Municipio)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Entrega_Sat_Colonia)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Entrega_Sat_Localidad)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Entrega_Sat_Municipio)
              .Include(c => c.Cliente_fact_elect).ThenInclude(d => d.Sat_Regimenfiscal)
              //.Include(c => c.Cliente_ordencompra)
              //.Include(c => c.Cliente_pago)
              .Include(c => c.Cliente_pago_parametros).ThenInclude(d => d.Creditoformapagoabonos_)
              .Include(c => c.Cliente_pago_parametros).ThenInclude(d => d.Moneda)
              .Include(c => c.Cliente_poliza)
              .Include(c => c.Cliente_precio).ThenInclude(d => d.Listaprecio)
              .Include(c => c.Cliente_precio).ThenInclude(d => d.Superlistaprecio)
              .Include(c => c.Cliente_rutaembarque).ThenInclude(d => d.Rutaembarque)
              ;

        }
#pragma warning restore CS8602

    }

}



