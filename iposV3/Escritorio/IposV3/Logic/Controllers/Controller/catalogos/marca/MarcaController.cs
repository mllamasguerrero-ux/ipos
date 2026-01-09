using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;

namespace Controllers.Controller
{

    public class MarcaController : BaseController<MarcaBindingModel>
    {


        private OperationsContextFactory _operationsContextFactory;

        public MarcaController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }



        public override MarcaBindingModel? GetById(MarcaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            MarcaBindingModel item = new MarcaBindingModel();
            var entityItem = applicationDbContext.Marca.Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id).FirstOrDefault();
            if(entityItem != null)
                item.FillFromEntity(entityItem);
            return item;
        }

        public override List<MarcaBindingModel> GetAll()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return applicationDbContext.Marca.Select(x => new MarcaBindingModel(x)).ToList();

        }


        public override List<MarcaBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            if (param == null) throw new Exception("El campo de parametros es null y debe tener valor");

            using var applicationDbContext = this._operationsContextFactory.Create();

            MarcaParam marcaParam = (MarcaParam)param;

            List<MarcaBindingModel> listToReturn = new List<MarcaBindingModel>();
            

            if (kendoParams != null && kendoParams!.GeneralFilter != null && 
                (kendoParams?.GeneralFilter?.Fields?.Count ?? 0) == 0)
            {
                kendoParams!.GeneralFilter!.Fields = MarcaBindingModel.GetFieldsForGeneralSearch().Split('|').ToList();
            }

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>
                {
                    new NpgsqlParameter($"@1", marcaParam.P_empresaid),
                    new NpgsqlParameter($"@2", marcaParam.P_sucursalid)
                };

                string commandText = MarcaBindingModel.GetBaseQuery();

                if (kendoParams != null)
                {
                    commandText = KendoParamDao.PrepareFilteringAndPagination<Marca>(kendoParams, parameterList, commandText);
                }

                listToReturn = applicationDbContext.Marca
                        .FromSqlRaw(commandText, parameterList.ToArray())
                        .Select(x => new MarcaBindingModel(x)).ToList()
                        .ToList();

                return listToReturn;
            }
            catch
            {
                throw ;
                //return null;
            }

           
        }






        public override bool Insert(MarcaBindingModel item)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            Marca entityItem = new Marca();
            item.FillEntityValues(ref entityItem);
            entityItem.Creado = DateTimeOffset.UtcNow;
            entityItem.Modificado = DateTimeOffset.UtcNow;
            applicationDbContext.Marca.Add(entityItem);
            applicationDbContext.SaveChanges();
            return true;
        }


        public override List<MarcaBindingModel> Select(object param, string search, string fieldsSearching)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            MarcaParam marcaParam = (MarcaParam)param;

            KendoParams kendoParams = new KendoParams();
            kendoParams.GeneralFilter = new KendoGeneralFilter(search, MarcaBindingModel.GetFieldsForGeneralSearch());

            List<MarcaBindingModel> listToReturn = new List<MarcaBindingModel>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>
                {
                    new NpgsqlParameter($"@1", marcaParam.P_empresaid),
                    new NpgsqlParameter($"@2", marcaParam.P_sucursalid)
                };

                string commandText = MarcaBindingModel.GetBaseQuery();

                if (kendoParams != null)
                {
                    commandText = KendoParamDao.PrepareFilteringAndPagination<Marca>(kendoParams, parameterList, commandText);
                }

                listToReturn = applicationDbContext.Marca
                        .FromSqlRaw(commandText, parameterList.ToArray())
                        .Select(x => new MarcaBindingModel(x)).ToList()
                        .ToList();

                return listToReturn;
            }
            catch
            {
                throw ;
                //return null;
            }

        }



        public override List<MarcaBindingModel> SelectById(MarcaBindingModel itemSelect)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            MarcaBindingModel item = new MarcaBindingModel();
            var listItems =  applicationDbContext.Marca.Where(x => x.EmpresaId == itemSelect.EmpresaId && x.SucursalId == itemSelect.SucursalId && x.Id == itemSelect.Id)
                .Select(x => new MarcaBindingModel(x)).ToList();


            return listItems;
        }
        public override bool Update(MarcaBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Marca?.Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Marca?.Update(entityItem);
                applicationDbContext.SaveChanges();
            }

            return true;

        }
        public override bool Delete(MarcaBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var entityItem = applicationDbContext.Marca?.Single(m => m.EmpresaId == item.EmpresaId && m.SucursalId == item.SucursalId && m.Id == item.Id);

            if (entityItem != null)
            {
                applicationDbContext.Marca?.Remove(entityItem);
                applicationDbContext.SaveChanges();
            }
            return true;
        }



    }
}
