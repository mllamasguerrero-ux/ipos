using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using IposV3.Model;
using NpgsqlTypes;
using DataAccess;

namespace BIPOS.Database
{
    public class BaseListDao<R,P> : PrimaryDao where R : class where P : class
    {
        
        
        protected string selectQueryList = "";
        protected string selectQueryForSelector = "";
        protected string selectQueryCommand = "";
        protected CommandType selectCommandTypeList = CommandType.Text;
        protected CommandType executeCommandTypeList = CommandType.StoredProcedure;

        public BaseListDao(string? connectionString) : base(connectionString)
        {
            putQueryStringsList();
            putQueryStringsCommand();
        }

        public BaseListDao(Func<string> connectionMethod):base(connectionMethod)
        {
            putQueryStringsList();
            putQueryStringsCommand();
        }




        public BaseListDao(NpgsqlConnection sqlConnection) : base(sqlConnection)
        {
            putQueryStringsList();
            putQueryStringsCommand();
        }


        protected virtual void putQueryStringsList()
        {

            //throw new Exception("Falta definir los strings de los queries");
        }

        protected virtual void putQueryStringsCommand()
        {

            //throw new Exception("Falta definir los strings de los queries");
        }





        protected virtual NpgsqlDbType sqlDbTypeByFieldParam(string field)
        {

            throw new Exception("Field not in list");
        }



        protected virtual Object? objByFieldParam(string field, P item)
        {
            throw new Exception("Field not in list");
        }


        protected virtual void putValueFromReader(string field, DbDataReader dataReader, string prefix, ref R item)
        {

            throw new Exception("Field not in list");
        }


       

        /*General*/
        protected virtual DbParameter? fillStandardParameterList(string fieldName, P item, ParameterDirection parameterDirection = ParameterDirection.Input, string prefix = "")
        {
            try
            {
                return GetParameter(prefix + fieldName.ToLower(), sqlDbTypeByFieldParam(fieldName), objByFieldParam(fieldName, item), parameterDirection);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        protected virtual List<DbParameter> fillStandardParametersList(List<string> fieldNames, P? item, ParameterDirection parameterDirection = ParameterDirection.Input, string prefix = "")
        {
            if (item == null)
                throw new Exception("El item no puede ser nulo");

            List<DbParameter> list = new List<DbParameter>();
            foreach (string fieldName in fieldNames)
            {
                var bufferParameter = this.fillStandardParameterList(fieldName, item, parameterDirection, prefix);
                if(bufferParameter != null)
                    list.Add(bufferParameter);
            }
            return list;
        }


        protected virtual void fillEntityFromReader(List<string> fieldNames, DbDataReader dataReader, ref R item, string prefix = "")
        {

            foreach (string fieldName in fieldNames)
            {
                this.putValueFromReader(fieldName, dataReader, prefix, ref item);
            }
        }


        


        /*Selects*/

        protected virtual R fillEntityFromReader(DbDataReader dr)
        {
            //List<string> fieldNames = new List<string>();
            //return this.fillStandardParameters(fieldNames, item);
            throw new Exception("Este metodo debe implementarse en la clase ");

            //return item;
        }


        protected virtual R fillEntityFromReaderAndFields(DbDataReader dr, List<string> fields, R item)
        {
            //List<string> fieldNames = new List<string>();
            //return this.fillStandardParameters(fieldNames, item);
            throw new Exception("Este metodo debe implementarse en la clase ");

            //return item;
        }

        protected virtual List<DbParameter> fillStandardParametersForSelectList(P? param)
        {
            throw new Exception("Este metodo debe implementarse en la clase ");
        }


        protected virtual List<DbParameter> fillStandardParametersForCommand(P param)
        {
            throw new Exception("Este metodo debe implementarse en la clase ");
        }



        public List<R> SelectList(NpgsqlTransaction? st, P? param, KendoParams? kendoParams)
        {
            return this.SelectList(st,  param, kendoParams, selectQueryList);
        }



        public List<R> SelectList(NpgsqlTransaction? st, P? param, KendoParams? kendoParams, string strSelectQueryList)
        {
            List<R> listToReturn = new List<R>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelectList(param));

                string commandText = strSelectQueryList; // selectQueryList;

                if (kendoParams != null)
                {
                    commandText = KendoParamDao.PrepareFilteringAndPagination<R>(kendoParams, parameterList, commandText);
                }

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, selectCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            R item = fillEntityFromReader(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }



        public R? SelectFirst(NpgsqlTransaction? st, P param)
        {
            R? itemToReturn = null;

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelectList(param));

                string commandText = selectQueryList;
                

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, selectCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if(dataReader.Read())
                        {
                            itemToReturn = fillEntityFromReader(dataReader);
                        }
                    }
                }

                return itemToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }





        public List<R> ExecuteCommandList(NpgsqlTransaction st, P param)
        {
            List<R> listToReturn = new List<R>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForCommand(param));

                string commandText = selectQueryCommand;
                
                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, executeCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            R item = fillEntityFromReader(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }




        public R? ExecuteCommandFirst(NpgsqlTransaction st, P param)
        {
            R? itemToReturn = null;

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForCommand(param));

                string commandText = selectQueryCommand;


                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, executeCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            itemToReturn = fillEntityFromReader(dataReader);
                        }
                    }
                }

                return itemToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }




        protected virtual BaseSelector fillEntityFromReaderForSelector(DbDataReader dr)
        {
            BaseSelector item = new BaseSelector();
            item.Empresaid = dr["empresaid"] != System.DBNull.Value ? (long)dr["empresaid"] : 0; 
            item.Sucursalid = dr["sucursalid"] != System.DBNull.Value ? (long)dr["sucursalid"] : 0;
            item.Id = dr["id"] != System.DBNull.Value ? (long)dr["id"] : 0;
            item.Clave = dr["clave"] != System.DBNull.Value ? (string)dr["clave"] : null;
            item.Nombre = dr["nombre"] != System.DBNull.Value ? (string)dr["nombre"] : null;

            return item;

        }

        public List<BaseSelector>? SelectForSelector(NpgsqlTransaction st, P param, KendoParams kendoParams)
        {
            return this.SelectForSelector(st, param, kendoParams, this.selectQueryForSelector);
        }



        public  List<BaseSelector>? SelectForSelector(NpgsqlTransaction st, P param, KendoParams kendoParams, string queryForSelector)
        {
            List<BaseSelector> listToReturn = new List<BaseSelector>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelectList(param));

                string commandText = queryForSelector;

                if (kendoParams != null)
                {
                    commandText = KendoParamDao.PrepareFilteringAndPagination<R>(kendoParams, parameterList, commandText);
                }

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, selectCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var item = fillEntityFromReaderForSelector(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                return null;
            }
        }


        public virtual BaseSelector? SelectForSelectorItemById(NpgsqlTransaction st, long id, P param, KendoParams kendoParams)
        {
            return SelectForSelectorItemById(st, id, param, kendoParams, selectQueryForSelector);
        }

        public virtual BaseSelector? SelectForSelectorItemById(NpgsqlTransaction st, long id, P param, KendoParams kendoParams, string queryForSelector)
        {
            BaseSelector? objToReturn = null;

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelectList(param));

                string commandText = queryForSelector;//selectQueryForSelector;

                if (kendoParams == null)
                    kendoParams = new KendoParams();

                kendoParams.Filter = new KendoFilters();
                kendoParams.Filter.Filters = new List<KendoFilter>();
                kendoParams.Filter.Filters.Add(new KendoFilter(id.ToString(), "eq", "Id", ""));
                commandText = KendoParamDao.PrepareFilteringAndPagination<BaseSelector>(kendoParams, parameterList, commandText);

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, selectCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            var item = fillEntityFromReaderForSelector(dataReader);
                            objToReturn = item;
                        }
                    }
                }

                return objToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                return null;
            }
        }

        public virtual BaseSelector? SelectForSelectorItem(NpgsqlTransaction st, string claveValue, P param, KendoParams kendoParams)
        {
            return SelectForSelectorItem(st, claveValue, param, kendoParams, selectQueryForSelector);
        }

        public virtual BaseSelector? SelectForSelectorItem(NpgsqlTransaction st, string claveValue, P param, KendoParams kendoParams, string queryForSelector)
        {

            BaseSelector? objToReturn = null;

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelectList(param));

                string commandText = queryForSelector;//selectQueryForSelector;

                if (kendoParams == null)
                    kendoParams = new KendoParams();

                kendoParams.Filter = new KendoFilters();
                kendoParams.Filter.Filters = new List<KendoFilter>();
                kendoParams.Filter.Filters.Add(new KendoFilter(claveValue, "eq", "Clave", ""));
                commandText = KendoParamDao.PrepareFilteringAndPagination<BaseSelector>(kendoParams, parameterList, commandText);

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, selectCommandTypeList))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            var item = fillEntityFromReaderForSelector(dataReader);
                            objToReturn = item;
                        }
                    }
                }

                return objToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                return null;
            }
        }


        public string? StringValueForDomain(string? val, string? domain)
        {

           switch(domain?.ToUpper())
           {
                case "D_BOOLCN":
                    return val != null && val.Trim().Length > 0 ? val : "N";
                case "D_BOOLCS":
                    return val != null && val.Trim().Length > 0 ? val : "S";
                default:
                    return val != null ? val : null;
            }

        }


    }
}
