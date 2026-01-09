
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

    public class DoctoController : BaseController<DoctoBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;
        private DoctoService _doctoService;

        public DoctoController(
            DoctoService doctoService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._doctoService = doctoService;
        }


        public override DoctoBindingModel? GetById(DoctoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Docto.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);
            var queryWithIncludesSecondaryInfo = QueryableWithIncludesSecondaryInfo(basicQuery);

            var itemPrimaryInfo =
                  queryWithIncludes
                            .FirstOrDefault();

            var itemSecondaryInfo =
                  queryWithIncludesSecondaryInfo
                            .FirstOrDefault();

            DoctoBindingModel? item = null;

            if (itemPrimaryInfo != null && itemSecondaryInfo != null)
                item = new DoctoBindingModel(itemPrimaryInfo!, itemSecondaryInfo!);
            

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<DoctoBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Docto.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new DoctoBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<DoctoBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            DoctoParam itemParam = (DoctoParam)param;

            List<DoctoBindingModel> listToReturn = new List<DoctoBindingModel>();

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
                var basicQuery = applicationDbContext.Docto.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Docto>()
                      .Select(x => new DoctoBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(DoctoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Docto entityItem = new Docto();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Docto.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<DoctoBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<DoctoBindingModel> SelectById(DoctoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var listItems = new List<DoctoBindingModel>();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Docto.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);


            var queryWithIncludes = QueryableWithIncludes(basicQuery);
            var queryWithIncludesSecondaryInfo = QueryableWithIncludesSecondaryInfo(basicQuery);

            var itemPrimaryInfo =
                  queryWithIncludes
                            .FirstOrDefault();

            var itemSecondaryInfo =
                  queryWithIncludesSecondaryInfo
                            .FirstOrDefault();


            if (itemPrimaryInfo != null && itemSecondaryInfo != null)
                listItems.Add(new DoctoBindingModel(itemPrimaryInfo!, itemSecondaryInfo!));


            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(DoctoBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var basicQuery = applicationDbContext.Docto
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludesFull(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Docto?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(DoctoBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Docto?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Docto?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Docto> QueryableWithIncludes(IQueryable<Docto> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Estatusdocto)
              .Include(c => c.Usuario)
              .Include(c => c.Corte)
              .Include(c => c.Caja)
              .Include(c => c.Almacen)
              .Include(c => c.Origenfiscal)
              .Include(c => c.Doctoparent)
              .Include(c => c.Cliente)
              .Include(c => c.Tipodocto)
              .Include(c => c.Proveedor)
              .Include(c => c.Sucursal_info)
              .Include(c => c.Subtipodocto)
              .Include(c => c.Tipodiferenciainventario)
              .Include(c => c.Docto_alerta).ThenInclude(d => d.Autorizoalerta)
              .Include(c => c.Docto_apartado).ThenInclude(d => d.Personaapartado)
              .Include(c => c.Docto_bancomer)
              .Include(c => c.Docto_cobranza).ThenInclude(d => d.Personaaprobacioncxc)
              .Include(c => c.Docto_comision).ThenInclude(d => d.Vendedorfinal_)
              .Include(c => c.Docto_comision).ThenInclude(d => d.Vendedorejecutivo)
              .Include(c => c.Docto_compra)
              .Include(c => c.Docto_contrarecibo).ThenInclude(d => d.Contrarecibo)
              .Include(c => c.Docto_cancelacion).ThenInclude(d => d.Doctoref)
              .Include(c => c.Docto_devolucion).ThenInclude(d => d.Doctoref)
              .Include(c => c.Docto_loteimportado).ThenInclude(d => d.Loteimportadodocto)
              .Include(c => c.Docto_corte).ThenInclude(d => d.Montobilletes)
              .Include(c => c.Docto_fact_elect).ThenInclude(d => d.Sat_usocfdi)
              .Include(c => c.Docto_fact_elect).ThenInclude(d => d.Cfdi)
              //.Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Factcons)
              //.Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Devcons)
              //.Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Doctoref2)
              //.Include(c => c.Docto_fact_elect_pagos).ThenInclude(d => d.Doctopagosat_)
              //.Include(c => c.Docto_fact_elect_pagos).ThenInclude(d => d.Pagosat_)
              //.Include(c => c.Docto_fact_elect_sustitucion).ThenInclude(d => d.Doctosustituto)
              //.Include(c => c.Docto_fact_elect_sustitucion).ThenInclude(d => d.Doctoasustituir)
              .Include(c => c.Docto_farmacia)
              //.Include(c => c.Docto_guia).ThenInclude(d => d.Estadoguia)
              //.Include(c => c.Docto_guia).ThenInclude(d => d.Guia)
              //.Include(c => c.Docto_guia).ThenInclude(d => d.Personaguiarecibio)
              //.Include(c => c.Docto_kit).ThenInclude(d => d.Doctokitref)
              //.Include(c => c.Docto_kit).ThenInclude(d => d.Prekitestatus_)
              //.Include(c => c.Docto_kit).ThenInclude(d => d.Postkitestatus_)
              .Include(c => c.Docto_monedero).ThenInclude(d => d.Monedero_)
              .Include(c => c.Docto_ordencompra).ThenInclude(d => d.Doctoref)
              .Include(c => c.Docto_origenfiscal)
              //.Include(c => c.Docto_info_pago).ThenInclude(d => d.Pagodev)
              //.Include(c => c.Docto_info_pago).ThenInclude(d => d.Estatusanticipo)
              //.Include(c => c.Docto_poliza).ThenInclude(d => d.Doctoplazoorigen)
              //.Include(c => c.Docto_poliza).ThenInclude(d => d.Plazo)
              .Include(c => c.Docto_precio).ThenInclude(d => d.Tipomayoreo)
              .Include(c => c.Docto_precio).ThenInclude(d => d.Tipodescuentovale_)
              .Include(c => c.Docto_promocion)
              .Include(c => c.Docto_rebajaespecial).ThenInclude(d => d.Estadorebaja_)
              .Include(c => c.Docto_revision).ThenInclude(d => d.Estadorevisado)
              .Include(c => c.Docto_rutaembarque).ThenInclude(d => d.Rutaembarque)
              .Include(c => c.Docto_serviciodomicilio)
              .Include(c => c.Docto_surtido).ThenInclude(d => d.Estadosurtido)
              .Include(c => c.Docto_surtido).ThenInclude(d => d.Estatusdoctopedido)
              .Include(c => c.Docto_surtido).ThenInclude(d => d.Personasurtido)
              .Include(c => c.Docto_traslado).ThenInclude(d => d.Sucursalt)
              .Include(c => c.Docto_traslado).ThenInclude(d => d.Almacen)
              .Include(c => c.Docto_traslado).ThenInclude(d => d.Doctoimportado)
              .Include(c => c.Docto_utilidad).ThenInclude(d => d.Vendedorutilidad)
              //.Include(c => c.Docto_ventafuturo).ThenInclude(d => d.Ventafutu)
              ;

        }

        public IQueryable<Docto> QueryableWithIncludesSecondaryInfo(IQueryable<Docto> itemBasicQuery)
        {
            return itemBasicQuery
              .Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Factcons)
              .Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Devcons)
              .Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Doctoref2)
              .Include(c => c.Docto_fact_elect_pagos).ThenInclude(d => d.Doctopagosat_)
              .Include(c => c.Docto_fact_elect_pagos).ThenInclude(d => d.Pagosat_)
              .Include(c => c.Docto_fact_elect_sustitucion).ThenInclude(d => d.Doctosustituto)
              .Include(c => c.Docto_fact_elect_sustitucion).ThenInclude(d => d.Doctoasustituir)
              .Include(c => c.Docto_guia).ThenInclude(d => d.Estadoguia)
              .Include(c => c.Docto_guia).ThenInclude(d => d.Guia)
              .Include(c => c.Docto_guia).ThenInclude(d => d.Personaguiarecibio)
              .Include(c => c.Docto_kit).ThenInclude(d => d.Doctokitref)
              .Include(c => c.Docto_kit).ThenInclude(d => d.Prekitestatus_)
              .Include(c => c.Docto_kit).ThenInclude(d => d.Postkitestatus_)
              .Include(c => c.Docto_info_pago).ThenInclude(d => d.Pagodev)
              .Include(c => c.Docto_info_pago).ThenInclude(d => d.Estatusanticipo)
              .Include(c => c.Docto_poliza).ThenInclude(d => d.Doctoplazoorigen)
              .Include(c => c.Docto_poliza).ThenInclude(d => d.Plazo)
              .Include(c => c.Docto_ventafuturo).ThenInclude(d => d.Ventafutu)
              ;

        }

        public IQueryable<Docto> QueryableWithIncludesFull(IQueryable<Docto> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Estatusdocto)
              .Include(c => c.Usuario)
              .Include(c => c.Corte)
              .Include(c => c.Caja)
              .Include(c => c.Almacen)
              .Include(c => c.Origenfiscal)
              .Include(c => c.Doctoparent)
              .Include(c => c.Cliente)
              .Include(c => c.Tipodocto)
              .Include(c => c.Proveedor)
              .Include(c => c.Sucursal_info)
              .Include(c => c.Subtipodocto)
              .Include(c => c.Tipodiferenciainventario)
              .Include(c => c.Docto_alerta).ThenInclude(d => d.Autorizoalerta)
              .Include(c => c.Docto_apartado).ThenInclude(d => d.Personaapartado)
              .Include(c => c.Docto_bancomer)
              .Include(c => c.Docto_cobranza).ThenInclude(d => d.Personaaprobacioncxc)
              .Include(c => c.Docto_comision).ThenInclude(d => d.Vendedorfinal_)
              .Include(c => c.Docto_comision).ThenInclude(d => d.Vendedorejecutivo)
              .Include(c => c.Docto_compra)
              .Include(c => c.Docto_contrarecibo).ThenInclude(d => d.Contrarecibo)
              .Include(c => c.Docto_cancelacion).ThenInclude(d => d.Doctoref)
              .Include(c => c.Docto_devolucion).ThenInclude(d => d.Doctoref)
              .Include(c => c.Docto_loteimportado).ThenInclude(d => d.Loteimportadodocto)
              .Include(c => c.Docto_corte).ThenInclude(d => d.Montobilletes)
              .Include(c => c.Docto_fact_elect).ThenInclude(d => d.Sat_usocfdi)
              .Include(c => c.Docto_fact_elect).ThenInclude(d => d.Cfdi)
              .Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Factcons)
              .Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Devcons)
              .Include(c => c.Docto_fact_elect_consolidacion).ThenInclude(d => d.Doctoref2)
              .Include(c => c.Docto_fact_elect_pagos).ThenInclude(d => d.Doctopagosat_)
              .Include(c => c.Docto_fact_elect_pagos).ThenInclude(d => d.Pagosat_)
              .Include(c => c.Docto_fact_elect_sustitucion).ThenInclude(d => d.Doctosustituto)
              .Include(c => c.Docto_fact_elect_sustitucion).ThenInclude(d => d.Doctoasustituir)
              .Include(c => c.Docto_farmacia)
              .Include(c => c.Docto_guia).ThenInclude(d => d.Estadoguia)
              .Include(c => c.Docto_guia).ThenInclude(d => d.Guia)
              .Include(c => c.Docto_guia).ThenInclude(d => d.Personaguiarecibio)
              .Include(c => c.Docto_kit).ThenInclude(d => d.Doctokitref)
              .Include(c => c.Docto_kit).ThenInclude(d => d.Prekitestatus_)
              .Include(c => c.Docto_kit).ThenInclude(d => d.Postkitestatus_)
              .Include(c => c.Docto_monedero).ThenInclude(d => d.Monedero_)
              .Include(c => c.Docto_ordencompra).ThenInclude(d => d.Doctoref)
              .Include(c => c.Docto_origenfiscal)
              .Include(c => c.Docto_info_pago).ThenInclude(d => d.Pagodev)
              .Include(c => c.Docto_info_pago).ThenInclude(d => d.Estatusanticipo)
              .Include(c => c.Docto_poliza).ThenInclude(d => d.Doctoplazoorigen)
              .Include(c => c.Docto_poliza).ThenInclude(d => d.Plazo)
              .Include(c => c.Docto_precio).ThenInclude(d => d.Tipomayoreo)
              .Include(c => c.Docto_precio).ThenInclude(d => d.Tipodescuentovale_)
              .Include(c => c.Docto_promocion)
              .Include(c => c.Docto_rebajaespecial).ThenInclude(d => d.Estadorebaja_)
              .Include(c => c.Docto_revision).ThenInclude(d => d.Estadorevisado)
              .Include(c => c.Docto_rutaembarque).ThenInclude(d => d.Rutaembarque)
              .Include(c => c.Docto_serviciodomicilio)
              .Include(c => c.Docto_surtido).ThenInclude(d => d.Estadosurtido)
              .Include(c => c.Docto_surtido).ThenInclude(d => d.Estatusdoctopedido)
              .Include(c => c.Docto_surtido).ThenInclude(d => d.Personasurtido)
              .Include(c => c.Docto_traslado).ThenInclude(d => d.Sucursalt)
              .Include(c => c.Docto_traslado).ThenInclude(d => d.Almacen)
              .Include(c => c.Docto_traslado).ThenInclude(d => d.Doctoimportado)
              .Include(c => c.Docto_utilidad).ThenInclude(d => d.Vendedorutilidad)
              .Include(c => c.Docto_ventafuturo).ThenInclude(d => d.Ventafutu)
              ;

        }

#pragma warning restore CS8602



        public DoctoBindingModel? Get_BasicDocto(DoctoBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _doctoService.Docto_basico(itemSelect.EmpresaId!.Value, itemSelect.SucursalId!.Value, itemSelect.Id!.Value, applicationDbContext)
                .Select(d => new DoctoBindingModel()
                {
                    EmpresaId = d.EmpresaId,
                    SucursalId = d.SucursalId,
                    Id = d.Id,
                    Activo = d.Activo,
                    Estatusdoctoid = d.Estatusdoctoid,
                    Usuarioid = d.Usuarioid,
                    Fecha = d.Fecha,
                    Serie = d.Serie,
                    Folio = d.Folio,
                    Importe = d.Importe,
                    Descuento = d.Descuento,
                    Subtotal = d.Subtotal,
                    Iva = d.Iva,
                    Ieps = d.Ieps,
                    Total = d.Total,
                    Cajaid = d.Cajaid,
                    Proveedorid = d.Proveedorid,
                    ProveedorClave = d.ProveedorClave,
                    ProveedorNombre = d.ProveedorNombre,
                    Clienteid = d.Clienteid,
                    ClienteClave = d.ClienteClave,
                    ClienteNombre = d.ClienteNombre,
                    Tipodoctoid = d.Tipodoctoid,
                    TipodoctoClave = d.TipodoctoClave,
                    TipodoctoNombre = d.TipodoctoNombre,
                    Referencia = d.Referencia,
                    Origenfiscalid = d.Origenfiscalid,
                    OrigenfiscalClave = d.OrigenfiscalClave,
                    OrigenfiscalNombre = d.OrigenfiscalNombre,
                    Docto_compra_Factura = d.Docto_compra_Factura,
                    Docto_compra_Fechafactura = d.Docto_compra_Fechafactura,
                    Fechavence = d.Docto_compra_Fechavence,
                    Docto_compra_Folio = d.Docto_compra_Folio,
                    Almacenid = d.Almacenid,
                    Docto_traslado_Sucursaltid = d.Docto_traslado_Sucursaltid,
                    Docto_traslado_SucursaltClave = d.Docto_traslado_SucursaltClave,
                    Docto_traslado_SucursaltNombre = d.Docto_traslado_SucursaltNombre

                })
                .FirstOrDefault();
        }

    }

}



