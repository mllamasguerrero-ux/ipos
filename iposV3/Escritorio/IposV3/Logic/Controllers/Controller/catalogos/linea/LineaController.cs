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
using IposV3.Services;
using KendoNET.DynamicLinq;

namespace Controllers.Controller
{

    public class LineaController : BaseController<LineaBindingModel>
    {


        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private VendeduriaService _vendeduriaService;
        private ProveeduriaService _proveeduriaService;
        private FacturaElectronicaService _facturaElectronicaService;
        private InventarioOperativoService _inventarioOperativeService;

        private ConsolidacionService _consolidacionService;

        public LineaController(
            ProveeduriaService proveeduriaService,
            VendeduriaService vendeduriaService,
            FacturaElectronicaService facturaElectronicaService,
            InventarioOperativoService inventarioOperativeService,
            ConsolidacionService consolidacionService,
            IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            _vendeduriaService = vendeduriaService;
            _proveeduriaService = proveeduriaService;
            _facturaElectronicaService = facturaElectronicaService;

            _inventarioOperativeService = inventarioOperativeService;
            _consolidacionService = consolidacionService;
        }



        public override LineaBindingModel? GetById(LineaBindingModel itemSelect)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Linea.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new LineaBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<LineaBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();
            return applicationDbContext.Linea.Select(x => new LineaBindingModel(x)).ToList();

        }


        //public override List<LineaBindingModel> SelectList(object? param, KendoParams? kendoParams)
        //{
        //    using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

        //    //var test = _facturaElectronicaService.Factura_Electronica_Core(5, 4, 229, true, false, this._applicationDbContext);
        //    //var test = _facturaElectronicaService.Factura_Electronica_Generar(5, 4, 229, "C:\\temp\\test.xml", this._applicationDbContext);

        //    if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

        //    LineaParam itemParam = (LineaParam)param;

        //    List<LineaBindingModel> listToReturn = new List<LineaBindingModel>();


        //    if (kendoParams != null && kendoParams!.GeneralFilter != null &&
        //        (kendoParams?.GeneralFilter?.Fields?.Count ?? 0) == 0)
        //    {
        //        kendoParams!.GeneralFilter!.Fields = LineaBindingModel.GetFieldsForGeneralSearch().Split('|').ToList();
        //    }

        //    try
        //    {
        //        List<DbParameter> parameterList = new List<DbParameter>
        //        {
        //            new NpgsqlParameter($"@1", itemParam.P_empresaid),
        //            new NpgsqlParameter($"@2", itemParam.P_sucursalid)
        //        };

        //        string commandText = LineaBindingModel.GetBaseQuery();

        //        if (kendoParams != null)
        //        {
        //            commandText = KendoParamDao.PrepareFilteringAndPagination<Linea>(kendoParams, parameterList, commandText);
        //        }

        //        listToReturn = applicationDbContext.Linea
        //                .FromSqlRaw(commandText, parameterList.ToArray())
        //                .OrderBy(l => l.Clave)
        //                .Select(x => new LineaBindingModel(x))
        //                .ToList();

        //        return listToReturn;
        //    }
        //    catch
        //    {
        //        throw;
        //        //return null;
        //    }


        //}


        public override List<LineaBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            LineaParam itemParam = (LineaParam)param;

            List<LineaBindingModel> listToReturn = new List<LineaBindingModel>();

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
                var basicQuery = applicationDbContext.Linea.AsNoTracking()
                                  .Include(l => l.CreadoPor)
                                  .Include(l => l.ModificadoPor)
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Linea>()
                      .Select(x => new LineaBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }





        public override bool Insert(LineaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Linea entityItem = new Linea();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Linea.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }

        public override List<LineaBindingModel> Select(object param, string search, string fieldsSearching)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            LineaParam itemParam = (LineaParam)param;

            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter(search, LineaBindingModel.GetFieldsForGeneralSearch());

            List<LineaBindingModel> listToReturn = new List<LineaBindingModel>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>
                {
                    new NpgsqlParameter($"@1", itemParam.P_empresaid),
                    new NpgsqlParameter($"@2", itemParam.P_sucursalid)
                };

                string commandText = LineaBindingModel.GetBaseQuery();

                if (kendoParams != null)
                {
                    commandText = KendoParamDao.PrepareFilteringAndPagination<Linea>(kendoParams, parameterList, commandText);
                }

                listToReturn = applicationDbContext.Linea
                        .FromSqlRaw(commandText, parameterList.ToArray())
                        .Select(x => new LineaBindingModel(x)).ToList()
                        .ToList();

                return listToReturn;
            }
            catch
            {
                throw;
                //return null;
            }

        }



        public override List<LineaBindingModel> SelectById(LineaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();
            LineaBindingModel item = new LineaBindingModel();
            var listItems = applicationDbContext.Linea.Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id)
                .Select(x => new LineaBindingModel(x)).ToList();


            return listItems;
        }

        public override bool Update(LineaBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");


            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Linea
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Linea?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }


        public override bool Delete(LineaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Linea?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Linea?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }



#pragma warning disable CS8602
        public IQueryable<Linea> QueryableWithIncludes(IQueryable<Linea> itemBasicQuery)
        {
            return itemBasicQuery;

        }
#pragma warning restore CS8602
        public void TestGeneral()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var testList = this._inventarioOperativeService.Inventario_movto_detalles(5, 4, 1, 0, false, true, true, applicationDbContext);

            Console.WriteLine(testList.Count().ToString());
            //TestDocto();
            //TestMovto();
            //TestDoctosave();
        }

        public void TestDocto()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            var doctoTrans = new DoctoProvTrans()
            {

                Empresaid = 5,
                Sucursalid = 4,
                Creadopor_userid = 1,
                Estatusdoctoid = 0,
                Usuarioid = 1,
                Fecha = DateTimeOffset.UtcNow.Date,
                Cajaid = 1,
                Almacenid = 1,
                Origenfiscalid = 2,
                Doctoparentid = null,
                Tipodoctoid = 11,
                Proveedorid = 1,
                Sucursal_id = 1,
                Referencia = "",
                Referencias = "",
                Promocion = BoolCN.N,
                Sucursaltid = null,
                Almacentid = null,
                Folio_c = null,
                Factura_c = "-",
                Fechafactura_c = DateTimeOffset.UtcNow.Date,
                Fechavence_c = DateTimeOffset.UtcNow.Date



            };

            long? doctoId = null;

            using var transaction = applicationDbContext.Database.BeginTransaction();

            try
            {
                _proveeduriaService.Docto_prov_insert(doctoTrans, ref doctoId, applicationDbContext);
                if (doctoId != null)
                    transaction.Commit();
                else
                    transaction.Rollback();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void TestMovto()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            var movtoTrans = new MovtoProvTrans()
            {

                Empresaid = 5,
                Sucursalid = 4,
                Doctoid = 10,
                Partida = 1,
                Estatusmovtoid = 0,
                Productoid = 4,
                Cantidad = 1,
                Descuentoporcentaje = null,
                Precio = 48,
                Lote = null,
                Fechavence = null,
                Loteimportado = null,
                Movtoparentid = null,
                Localidad = null,
                Descripcion1 = null,
                Descripcion2 = null,
                Descripcion3 = null,
                Agrupaporparametro = null,
                Cargartarjetapreciomanual = null,
                Precioyavalidado = BoolCN.N,
                Usuarioid = 1,
                Precioconimp = null,
                Anaquelid = null



            };

            long? movtoId = null;

            using var transaction = applicationDbContext.Database.BeginTransaction();

            try
            {
                _proveeduriaService.Movto_prov_insert(movtoTrans, ref movtoId, applicationDbContext);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void TestDoctosave()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            using var transaction = applicationDbContext.Database.BeginTransaction();

            try
            {
                _proveeduriaService.Docto_prov_save(5, 4, 9, 1, applicationDbContext);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }



        public void TestDoctodelete()
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            using var transaction = applicationDbContext.Database.BeginTransaction();

            try
            {
                _proveeduriaService.Docto_prov_delete(5, 4, 8, applicationDbContext);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }



        public void TestGeneral2(long usuarioId)
        {



        }


    }
}
