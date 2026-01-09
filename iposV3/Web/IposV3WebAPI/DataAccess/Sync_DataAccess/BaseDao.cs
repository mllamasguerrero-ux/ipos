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
    public class BaseDao<T,P> : BaseListDao<T,P>, IDaoProvider<T,P>, IDaoSelectorProvider<T, P> where T : class where P : class
    {
        

        protected string insertQuery = "";
        protected string updateQuery = "";
        protected string deleteQuery = "";
        protected string selectQuery = "";
        protected string select_Query = "";
        protected string selectByIdQuery = "";
        protected string select_ByIdQuery = "";




        public BaseDao(string connectionString) : base(connectionString)
        {
            putQueryStrings();
        }




        public BaseDao(NpgsqlConnection sqlConnection) : base(sqlConnection)
        {
            putQueryStrings();
        }

        public BaseDao(Func<string> connectionMethod) : base(connectionMethod)
        {
            putQueryStrings();
        }

        protected virtual void putQueryStrings()
        {

            throw new Exception("Falta definir los strings de los queries");
        }
        



        protected virtual NpgsqlDbType sqlDbTypeByField(string field)
        {

            throw new Exception("Field not in list");
        }



        protected virtual Object? objByField(string field, T item)
        {
            throw new Exception("Field not in list");
        }


        //protected virtual void putValueFromReader(string field, DbDataReader dataReader, string prefix, ref T item)
        //{

        //    throw new Exception("Field not in list");
        //}




        /*General*/
        protected virtual DbParameter? fillStandardParameter(string fieldName, T item, ParameterDirection parameterDirection = ParameterDirection.Input, string prefix = "p_")
        {
            try
            {
                return GetParameter(prefix + fieldName.ToLower(), sqlDbTypeByField(fieldName), objByField(fieldName, item), parameterDirection);
            }
            catch
            {
                return null;
            }

        }

        protected virtual List<DbParameter> fillStandardParameters(List<string> fieldNames, T item, ParameterDirection parameterDirection = ParameterDirection.Input, string prefix = "p_")
        {
            List<DbParameter> list = new List<DbParameter>();
            foreach (string fieldName in fieldNames)
            {
                var bufferParameter = this.fillStandardParameter(fieldName, item, parameterDirection, prefix);
                if(bufferParameter != null)
                    list.Add(bufferParameter);
            }
            return list;
        }


        //protected virtual void fillEntityFromReader(List<string> fieldNames, DbDataReader dataReader, ref T item, string prefix = "")
        //{

        //    foreach (string fieldName in fieldNames)
        //    {
        //        this.putValueFromReader(fieldName, dataReader, prefix, ref item);
        //    }
        //}



        /*Insert*/

        protected virtual List<DbParameter> fillStandardParametersForInsert(T item)
        {
            //List<string> fieldNames = new List<string>();
            //return this.fillStandardParameters(fieldNames, item);
            throw new Exception("Este metodo debe implementarse en la clase ");
        }

        protected virtual T fillEntityFromParametersForInsert(List<DbParameter> parameters, T item, int id)
        {

            if(item.GetType().GetProperty("Id") != null)
            {
                item.GetType().GetProperty("Id")?.SetValue(item, (long?)id);
            }

            return item;
        }



        /*Update*/
        protected virtual List<DbParameter> fillStandardParametersForUpdate(T item)
        {
            throw new Exception("Este metodo debe implementarse en la clase ");
        }


        /*Delete*/
        protected virtual List<DbParameter> fillStandardParametersForDelete(T item)
        {
            throw new Exception("Este metodo debe implementarse en la clase ");
        }



        /*Selects*/
        protected virtual List<DbParameter> fillStandardParametersForSelect(string? search)
        {
            return new List<DbParameter>();
        }


        protected virtual List<DbParameter> fillStandardParametersForSelectByKey(T item)
        {
            throw new Exception("Este metodo debe implementarse en la clase ");
        }


        protected virtual List<DbParameter> fillStandardParametersForSelectByOnlyKey(T item)
        {
            throw new Exception("Este metodo debe implementarse en la clase ");
        }


        //protected virtual T fillEntityFromReader(DbDataReader dr)
        //{
        //    //List<string> fieldNames = new List<string>();
        //    //return this.fillStandardParameters(fieldNames, item);
        //    throw new Exception("Este metodo debe implementarse en la clase ");

        //    //return item;
        //}




        public T InsertT(T item, NpgsqlTransaction transaction, out int result)
        {

            result = -1;
            Comment = "";
            DevComment = "";
            T? returningItem = default(T);
            try
            {
                string commandText = this.insertQuery;

                List<DbParameter> parametersList = new List<DbParameter>();
                parametersList.AddRange(fillStandardParametersForInsert(item));

                //parametersList.Add(GetParameterOut("p_Res", NpgsqlDbType.Integer, result, ParameterDirection.Output));
                //ExecuteNonQuery(commandText, parametersList, CommandType.StoredProcedure, transaction);


                using (DbDataReader dataReader = GetDataReader(transaction, commandText, parametersList, CommandType.StoredProcedure))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            result = dataReader["result"] != System.DBNull.Value ? (int)(long)dataReader["result"] : 0;
                            Comment = dataReader["userMessage"] != System.DBNull.Value ? (string)dataReader["userMessage"] : "";
                            DevComment = dataReader["devMessage"] != System.DBNull.Value ? (string)dataReader["devMessage"] : "";
                        }
                    }
                }

                
                //result = 1;// (int)parametersList[parametersList.Count - 1].Value;
               
                returningItem = fillEntityFromParametersForInsert(parametersList, item, result);

                if (result <= 0)
                    throw new InvalidOperationException("No se pudo realizar la insercion . Error para el usuario " + Comment + ". Error para sistemas " + DevComment);

                return returningItem;
            }
            catch (Exception e)
            {
                Comment = e.Message + " " + e.StackTrace;
                throw;
                //return default(T);
            }
        }

        public bool Insert(T item, NpgsqlTransaction transaction)
        {
            int result;
            try
            {
                InsertT(item, transaction, out result);

                if (result <= 0)
                    throw new InvalidOperationException("No se pudo realizar la insercion . Error para el usuario " + Comment + ". Error para sistemas " + DevComment);
                
                return true;
            }
            catch (Exception e)
            {
                Comment = e.Message + " " + e.StackTrace;
                throw ;
                //return null;
            }
        }


        public List<T> Select(NpgsqlTransaction? st, string? search)
        {
            List<T> listToReturn = new List<T>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelect(search));

                string commandText = selectQuery;

                using (DbDataReader dataReader = GetDataReader(st,commandText, parameterList, CommandType.StoredProcedure))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            T item = fillEntityFromReader(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }


        public List<T> Select_(NpgsqlTransaction? st, string? search)
        {
            List<T> listToReturn = new List<T>();

            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.AddRange(fillStandardParametersForSelect(search));

                string commandText = select_Query;

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, CommandType.Text))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            T item = fillEntityFromReader(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }


        public List<T> SelectById(T itemSelect, NpgsqlTransaction st)
        {
            List<T> listToReturn = new List<T>();

            try
            {
                List<DbParameter> parameterList = fillStandardParametersForSelectByKey(itemSelect);

                string commandText = this.selectByIdQuery;

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, CommandType.StoredProcedure))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            T item = fillEntityFromReader(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al obtener los registros, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }


        public List<T> Select_ById(T itemSelect, NpgsqlTransaction st)
        {
            List<T> listToReturn = new List<T>();

            try
            {
                List<DbParameter> parameterList = fillStandardParametersForSelectByKey(itemSelect);

                string commandText = this.select_ByIdQuery;

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, CommandType.Text))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            T item = fillEntityFromReader(dataReader);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }


        public List<T> Custom_Select_ById(T itemSelect, NpgsqlTransaction st, string query, List<string> fields)
        {
            List<T> listToReturn = new List<T>();

            try
            {
                List<DbParameter> parameterList = fillStandardParametersForSelectByKey(itemSelect);

                string commandText = query;

                using (DbDataReader dataReader = GetDataReader(st, commandText, parameterList, CommandType.Text))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            T item = fillEntityFromReaderAndFields(dataReader, fields, itemSelect);
                            listToReturn.Add(item);
                        }
                    }
                }

                return listToReturn;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }



        public T? GetById(T itemSelect, NpgsqlTransaction st)
        {
            try
            {

                List<T> lst = this.SelectById(itemSelect, st);
                if (lst == null || lst.Count == 0)
                    return default(T);
                return lst[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            //return default(T);
        }


        public T? Get_ById(T itemSelect, NpgsqlTransaction st)
        {
            try
            {

                List<T> lst = this.Select_ById(itemSelect, st);
                if (lst == null || lst.Count == 0)
                    return default(T);
                return lst[0];
            }
            catch
            {
            }
            return default(T);
        }

        public List<T> GetAll(NpgsqlTransaction? st)
        {
            try
            {

                return this.Select(st, null);
            }
            catch
            {
            }
            return new List<T>();
        }

        public List<T> GetAll_(NpgsqlTransaction st)
        {
            try
            {

                return this.Select_(st, null);
            }
            catch
            {
            }
            return new List<T>();
        }

        public bool UpdateT(T item, NpgsqlTransaction transaction, out int result)
        {
            result = -1;
            Comment = "";
            DevComment = "";

            try
            {
                string commandText = this.updateQuery;

                List<DbParameter> parametersList = this.fillStandardParametersForUpdate(item);
                //parametersList.Add(GetParameterOut("p_Res", NpgsqlDbType.Integer, result, ParameterDirection.Output));
                //ExecuteNonQuery(commandText, parametersList, CommandType.StoredProcedure, transaction);


                using (DbDataReader dataReader = GetDataReader(transaction, commandText, parametersList, CommandType.StoredProcedure))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            result = dataReader["result"] != System.DBNull.Value ? (int)(long)dataReader["result"] : 0;
                            Comment = dataReader["userMessage"] != System.DBNull.Value ? (string)dataReader["userMessage"] : "";
                            DevComment = dataReader["devMessage"] != System.DBNull.Value ? (string)dataReader["devMessage"] : "";
                        }
                    }
                }


                if (result <= 0)
                    throw new InvalidOperationException("No se pudo realizar la actualizacion . Error para el usuario " + Comment + ". Error para sistemas " + DevComment);
                return true ;
            }
            catch (Exception e)
            {
                DevComment = e.Message + " " + e.StackTrace;
                Comment = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return false;
            }
        }

        public bool Update(T item, NpgsqlTransaction transaction)
        {
            int result;
            return UpdateT(item, transaction, out result);
        }



        public bool DeleteT(T item, NpgsqlTransaction transaction, out int result)
        {
            result = -1;
            Comment = "";
            DevComment = "";
            try
            {
                string commandText = this.deleteQuery;
                List<DbParameter> parametersList = this.fillStandardParametersForDelete(item);

                //ExecuteNonQuery(commandText, parametersList, CommandType.StoredProcedure, transaction);


                using (DbDataReader dataReader = GetDataReader(transaction, commandText, parametersList, CommandType.StoredProcedure))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            result = dataReader["result"] != System.DBNull.Value ? (int)(long)dataReader["result"] : 0;
                            Comment = dataReader["userMessage"] != System.DBNull.Value ? (string)dataReader["userMessage"] : "";
                            DevComment = dataReader["devMessage"] != System.DBNull.Value ? (string)dataReader["devMessage"] : "";
                        }
                    }
                }

                if (result <= 0)
                    throw new InvalidOperationException("No se pudo realizar la actualizacion . Error para el usuario " + Comment + ". Error para sistemas " + DevComment);
                return true;
            }
            catch (Exception e)
            {
                Comment = e.Message + " " + e.StackTrace;
                throw ;
                //return false;
            }
        }


        public bool Delete(T item, NpgsqlTransaction transaction)
        {
            int result;
            return DeleteT(item, transaction, out result);
        }

    }
}
