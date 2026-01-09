
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

namespace Controllers.Controller
{

    public class GuiaController : BaseController<GuiaBindingModel>
    {

        private OperationsContextFactory _operationsContextFactory;

        public GuiaController(
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override GuiaBindingModel? GetById(GuiaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Guia.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new GuiaBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<GuiaBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Guia.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new GuiaBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<GuiaBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            GuiaParam itemParam = (GuiaParam)param;

            List<GuiaBindingModel> listToReturn = new List<GuiaBindingModel>();

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
                var basicQuery = applicationDbContext.Guia.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Guia>()
                      .Select(x => new GuiaBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(GuiaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Guia entityItem = new Guia();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Guia.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public BaseResultBindingModel InsertHeaderAndDetail(GuiaBindingModel item, GuiadetalleBindingModel guiaDetalle, DoctoBindingModel docto)
        {

            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            using (var operationsDbContext = this._operationsContextFactory.Create())
            {
                using (var transaction = operationsDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Guia entityItem = new Guia();
                        item.FillEntityValues(ref entityItem);
                        entityItem.Creado = DateTimeOffset.UtcNow;
                        entityItem.Modificado = DateTimeOffset.UtcNow;

                        operationsDbContext.Guia.Add(entityItem);
                        operationsDbContext.SaveChanges();


                        Guiadetalle detalleItem = new Guiadetalle();
                        guiaDetalle.FillEntityValues(ref detalleItem);
                        detalleItem.Creado = DateTimeOffset.UtcNow;
                        detalleItem.Modificado = DateTimeOffset.UtcNow;
                        detalleItem.Guiaid = entityItem.Id;

                        operationsDbContext.Guiadetalle.Add(detalleItem);
                        operationsDbContext.SaveChanges();



                        Docto_guia docto_Guia = new Docto_guia();
                        docto_Guia.EmpresaId = item.EmpresaId!.Value;
                        docto_Guia.SucursalId = item.SucursalId!.Value;
                        docto_Guia.Estadoguiaid = DBValues._ESTADO_GUIA_ENVIADA;
                        docto_Guia.Fechaguiaenviado = item.Fecha;
                        docto_Guia.Fechaguiarecibido = item.Fechaestimadarec;
                        docto_Guia.Personaidguiarecibio = item.Encargadoguiaid;
                        docto_Guia.Doctoid = docto.Id;
                        docto_Guia.Guiaid = entityItem.Id;

                        operationsDbContext.Docto_guia.Add(docto_Guia);
                        operationsDbContext.SaveChanges();

                        transaction.Commit();
                        return resultBM;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultBM.Usermessage = ex.Message;
                        resultBM.Devmessage = ex.Message;
                        resultBM.Result = -1L;
                        return resultBM;

                    }
                }
            }



        }


        public override List<GuiaBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<GuiaBindingModel> SelectById(GuiaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            GuiaBindingModel item = new GuiaBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Guia.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new GuiaBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(GuiaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            var basicQuery = applicationDbContext.Guia
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Guia?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(GuiaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Guia?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Guia?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }


#pragma warning disable CS8602
    public IQueryable<Guia> QueryableWithIncludes(IQueryable<Guia> itemBasicQuery)
        {
            return itemBasicQuery.Include(c => c.Encargadoguia)
              .Include(c => c.Estadoguia)
              .Include(c => c.Cajero)
              .Include(c => c.Corte)
              .Include(c => c.Tipoentrega)
              .Include(c => c.Vehiculo)
              ;

        }  
#pragma warning restore CS8602

    }

}



