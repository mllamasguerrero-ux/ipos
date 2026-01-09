
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
using System.Data;
using FastReport.Data;
using FastReport;

namespace Controllers.Controller
{

    public class ReportesController : BaseController<ReportesBindingModel>
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;

        public ReportesController(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public override ReportesBindingModel? GetById(ReportesBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Reportes.AsNoTracking()
                           .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var item =
                  queryWithIncludes.Select(x => new ReportesBindingModel(x))
                            .FirstOrDefault();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return item;
        }

        public override List<ReportesBindingModel> GetAll()
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Reportes.AsNoTracking();

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var lst =
                  queryWithIncludes.Select(x => new ReportesBindingModel(x))
                            .ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

            return lst;

        }



        public override List<ReportesBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            ReportesParam itemParam = (ReportesParam)param;

            List<ReportesBindingModel> listToReturn = new List<ReportesBindingModel>();

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
                var basicQuery = applicationDbContext.Reportes.AsNoTracking()
                                .Where(x => x.EmpresaId == itemParam.P_empresaid && x.SucursalId == itemParam.P_sucursalid);


                var queryWithIncludes = QueryableWithIncludes(basicQuery);

                var lstQuery = queryWithIncludes
                      .ToDataSourceResult(kendoParams?.Take ?? 0, kendoParams?.Skip ?? 0, kendoParams?.Sort?.Select(y => y.ToKendoNetEquivalent()), kendoParams!.Filter?.ToKendoNetEquivalent())
                      .Data.ToList<Reportes>()
                      .Select(x => new ReportesBindingModel(x));

                listToReturn.AddRange(lstQuery);

                applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;

                return listToReturn;

            }
            catch
            {
                throw;
            }
        }


        public override bool Insert(ReportesBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Reportes entityItem = new Reportes();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Reportes.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<ReportesBindingModel> Select(object param, string search, string fieldsSearching)
        {
            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter("search", fieldsSearching);
            return SelectList(param, kendoParams);
        }

        public override List<ReportesBindingModel> SelectById(ReportesBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            ReportesBindingModel item = new ReportesBindingModel();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var basicQuery = applicationDbContext.Reportes.AsNoTracking()
                .Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var listItems = queryWithIncludes.Select(x => new ReportesBindingModel(x)).ToList();

            applicationDbContext.ChangeTracker.LazyLoadingEnabled = true;


            return listItems;
        }
        public override bool Update(ReportesBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var basicQuery = applicationDbContext.Reportes
                           .Where(x => x.EmpresaId == item.EmpresaId && x.SucursalId == item.SucursalId && x.Id == item.Id);

            var queryWithIncludes = QueryableWithIncludes(basicQuery);

            var entityItem = queryWithIncludes.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Reportes?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(ReportesBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            var entityItem = applicationDbContext.Reportes?
            .Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Reportes?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;
        }



        public Dictionary<string, DataTable>? GetDataForReport(Report fastReport,FastReportInfo info)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            Dictionary<string, DataTable> dictTables = new Dictionary<string, DataTable>();

            try
            {


                applicationDbContext.Database.OpenConnection();
                using (var connection = applicationDbContext.Database.GetDbConnection())
                {


                    foreach (TableDataSource table in fastReport.Dictionary.Connections[0].Tables)
                    {

                        using var command = new NpgsqlCommand(table.SelectCommand, (NpgsqlConnection)connection);

                        foreach(CommandParameter parametro in table.Parameters)
                        {
                            command.Parameters.Add(CreateParameter(parametro, info));
                        }

                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dictTables.Add(table.Name, dataTable);
                        }





                    }
                }

            }
            catch(Exception ex)
            {
                return null;
            }

            return dictTables;
            


           
        }

        public NpgsqlParameter CreateParameter(CommandParameter parametro, FastReportInfo info)
        {
            object? valueParameter = null;
            if (parametro.Expression != null && parametro.Expression.Contains("["))
            {
                var parametroInfo = parametro.Expression.Replace("[", "").Replace("]", "");
                valueParameter = info.DictionaryReporte[parametroInfo];
            }
            else
            {
                valueParameter = parametro.DefaultValue;
            }

            if (valueParameter == null)
                return new NpgsqlParameter(parametro.Name, DBNull.Value);


            switch (parametro.DataType)
            {
                case 1: return new NpgsqlParameter(parametro.Name, Int64.Parse(valueParameter!.ToString())); // DbType.Int64;
                case 2: return new NpgsqlParameter(parametro.Name, Boolean.Parse(valueParameter!.ToString())); //DbType.Boolean;
                case 6: return new NpgsqlParameter(parametro.Name, valueParameter!.ToString()); //DbType.AnsiStringFixedLength;
                case 7: return new NpgsqlParameter(parametro.Name, DateTime.Parse(valueParameter!.ToString())); //DbType.Date;
                case 8: return new NpgsqlParameter(parametro.Name, Double.Parse(valueParameter!.ToString())); //DbType.Double;
                case 9: return new NpgsqlParameter(parametro.Name, Int32.Parse(valueParameter!.ToString())); //DbType.Int32;
                case 12: return new NpgsqlParameter(parametro.Name, decimal.Parse(valueParameter!.ToString())); //DbType.Currency;
                case 13: return new NpgsqlParameter(parametro.Name, decimal.Parse(valueParameter!.ToString())); //DbType.Decimal;
                case 17: return new NpgsqlParameter(parametro.Name, decimal.Parse(valueParameter!.ToString())); //DbType.Decimal;
                case 18: return new NpgsqlParameter(parametro.Name, Int16.Parse(valueParameter!.ToString())); //DbType.Int16;
                case 19: return new NpgsqlParameter(parametro.Name, valueParameter!.ToString()); //DbType.String;
                case 20: return new NpgsqlParameter(parametro.Name, DateTime.Parse(valueParameter!.ToString())); //DbType.Time;
                case 21: return new NpgsqlParameter(parametro.Name, DateTime.Parse(valueParameter!.ToString())); //DbType.Time;
                case 22: return new NpgsqlParameter(parametro.Name, valueParameter!.ToString()); //DbType.String;
                default: return new NpgsqlParameter(parametro.Name, valueParameter!.ToString()); //DbType.String;

            }
        }

#pragma warning disable CS8602
        public IQueryable<Reportes> QueryableWithIncludes(IQueryable<Reportes> itemBasicQuery)
        {
            return itemBasicQuery;

        }  
#pragma warning restore CS8602

    }

}



