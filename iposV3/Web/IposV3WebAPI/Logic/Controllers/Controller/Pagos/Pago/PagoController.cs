
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

    public class PagoController : BaseController<PagoBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private PagoService _pagoService;
        private PagosFacturaElectronicaService _pagosFacturaElectronicaService;

        public PagoController(
            IDbContextFactory<ApplicationDbContext> operationsContextFactory,
            PagoService pagoService,
            PagosFacturaElectronicaService pagosFacturaElectronicaService)
        {
            this._operationsContextFactory = operationsContextFactory;
            _pagoService = pagoService;
            _pagosFacturaElectronicaService = pagosFacturaElectronicaService;
        }


        public override PagoBindingModel? GetById(PagoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Pago.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new PagoBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<PagoBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Pago.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new PagoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<PagoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            PagoParam itemParam = (PagoParam)param;

            List<PagoBindingModel> listToReturn = new List<PagoBindingModel>();

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
                var basicQuery = applicationDbContext.Pago.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Pago>()
                      .Select(x => new PagoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(PagoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Pago entityItem = new Pago();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Pago.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<PagoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<PagoBindingModel> SelectById(PagoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            PagoBindingModel item = new PagoBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Pago.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new PagoBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(PagoBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Pago
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Pago?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(PagoBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Pago?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Pago?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


        public List<V_pago_compuestoWFBindingModel> PagoCompuestoList(V_pagos_compuestos_list_selWFBindingModel itemParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_pago_compuestoWFBindingModel> listToReturn = new List<V_pago_compuestoWFBindingModel>();

            try
            {
                listToReturn = _pagoService.PagosList(itemParam.EmpresaId!.Value, itemParam.SucursalId!.Value, 
                                        itemParam.Tipodoctoid,
                                        itemParam.Formapagoid,
                                       itemParam.Clienteid, itemParam.Proveedorid,
                                       itemParam.Fechainicial!.Value, itemParam.Fechafinal!.Value,
                                       (itemParam.Solofiscales ?? false), (itemParam.Incluircancelaciones ?? false),
                                       (itemParam.Aplicados == null || itemParam.Aplicados == "Todos" || itemParam.Aplicados == "" ? null : (itemParam.Aplicados == "Aplicados" ? BoolCN.S : BoolCN.N)),
                                       (itemParam.Aplicados == null || itemParam.Aplicados == "Todos" || itemParam.Aplicados == ""),
                                       (itemParam.Timbrados == null || itemParam.Timbrados == "Todos" || itemParam.Timbrados == "" ? false : (itemParam.Timbrados == "Timbrados" ? true : false)),
                                       (itemParam.Timbrados == null || itemParam.Timbrados == "Todos" || itemParam.Timbrados == ""),
                                       applicationDbContext
                                       )
                                       .OrderByDescending(y => y.Fechahora)
                                       .Select(V_pago_compuestoWFBindingModel.CreateFromAnonymous)
                                       .ToList();


                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public List<V_docto_con_saldoWFBindingModel> DoctosConSaldoList(long empresaId, long sucursalId,
                                        long? tipodoctoid,
                                        long? clienteId, long? proveedorId,
                                        bool soloTimbrados, long? usuarioId, 
                                        bool corteActivo, string? referencia,
                                        DateTimeOffset? fechaInicial, DateTimeOffset? fechaFinal,
                                        long? estatusDoctoId)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_docto_con_saldoWFBindingModel> listToReturn = new List<V_docto_con_saldoWFBindingModel>();

            try
            {
                listToReturn = _pagoService.DoctosConSaldoList(empresaId, sucursalId, tipodoctoid, 
                                                               clienteId, proveedorId,soloTimbrados,
                                                               usuarioId, corteActivo, referencia, 
                                                               fechaInicial, fechaFinal,
                                                               estatusDoctoId,
                                                               applicationDbContext
                                       ).Select(V_docto_con_saldoWFBindingModel.CreateFromAnonymous).ToList();

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public List<V_doctopago_aplicadoWFBindingModel> DoctoPagosAplicadosList(long empresaId, long sucursalId,
                                        long pagoId)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_doctopago_aplicadoWFBindingModel> listToReturn = new List<V_doctopago_aplicadoWFBindingModel>();

            try
            {
                listToReturn = _pagoService.DoctoPagosAplicadosList(empresaId, sucursalId, pagoId,
                                                               applicationDbContext
                                       ).Select(V_doctopago_aplicadoWFBindingModel.CreateFromAnonymous).ToList();

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }

        public List<V_DoctoPagoItemBindingModel> DoctoPagosList(long empresaId, long sucursalId,
                                        long doctoId)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<V_DoctoPagoItemBindingModel> listToReturn = new List<V_DoctoPagoItemBindingModel>();

            try
            {
                listToReturn = _pagoService.DoctoPagosList(empresaId, sucursalId, doctoId,
                                                               applicationDbContext
                                       ).Select(f => new V_DoctoPagoItemBindingModel(f)).ToList();

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }




        public void PagoCompuestoInsert(Pago_transaccion pagoTransaccion, List<DoctoPago_transaccion> doctoPagoTransacciones,
                                        ref long? pagoId)
        {
            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {
                        _pagoService.PagoCompuestoInsert(pagoTransaccion, doctoPagoTransacciones,
                                                ref pagoId, operationsDbContext);
                        transaction.Commit();


                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public void PagoCompuestoRevertir(long empresaId, long sucursalId, long pagoARevertirId, 
                                           long usuarioId, long corteId, string? notas,
                                          ref long? pagoId)
        {
            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {
                        _pagoService.PagoCompuestoRevertir(
                                 empresaId, sucursalId, pagoARevertirId, 
                                 usuarioId, corteId, notas,
                                 ref pagoId, operationsDbContext);
                        transaction.Commit();


                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }



        public void GenerarReciboElectronico(long empresaId, long sucursalId, long pagoId,
                                             long vendedorId,
                                             ref long? reciboElectronicoId)
        {
            reciboElectronicoId = null;

            using (var operationsDbContext = this._operationsContextFactory.CreateDbContext())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {

                    try
                    {
                        this._pagosFacturaElectronicaService.GenerarReciboElectronico(empresaId,  sucursalId,  pagoId,
                                              vendedorId, ref  reciboElectronicoId, operationsDbContext);
                        transaction.Commit();


                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


#pragma warning disable CS8602
            public IQueryable<Pago> QueryableWithIncludes(IQueryable<Pago> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Formapago)
              .Include(c => c.Corte)
              .Include(c => c.Tipopago)
              .Include(c => c.Estatuspago)
              .Include(c => c.Banco)
              .Include(c => c.Pagoparent)
              .Include(c => c.Formapagosat)
              .Include(c => c.Cliente)
              .Include(c => c.Proveedor)
              .Include(c => c.Cuentabancoempresa)
              .Include(c => c.Reciboelectronico)
              .Include(c => c.Pago_bancomer).ThenInclude(d => d.Bancomerparam)
              ;

        }  
#pragma warning restore CS8602

    }

}



