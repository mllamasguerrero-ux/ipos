using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace IposV3.Model
{
    public class KendoParamDao
    {

        public static string BuildWhereClause<T>(KendoParams kParams, int index, KendoFilter filter, List<DbParameter> parameters)
        {
            if( filter.Field == null || filter.Value == null)
                throw new ArgumentException(
                    "This operator/value is not yet supported for this Grid",
                    filter.Operator);

            var entityType = typeof(T);
            var property = entityType.GetProperty(filter.Field);

            

            switch (filter.Operator?.ToLower())
            {
                case "eq":
                case "neq":
                case "gte":
                case "gt":
                case "lte":
                case "lt":
                    if (typeof(DateTime?).IsAssignableFrom(property!.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", DateTime.Parse(filter.Value)));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }
                    if (typeof(int).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", int.Parse(filter.Value)));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }
                    //--
                    if (typeof(long).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", long.Parse(filter.Value)));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }
                    //--
                    if (typeof(decimal?).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", decimal.Parse(filter.Value)));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }
                    //--
                    if (typeof(int?).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", int.Parse(filter.Value) ));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }
                    //--
                    if (typeof(long?).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", long.Parse(filter.Value)));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }
                    //--
                    if (typeof(Boolean).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(new NpgsqlParameter($"@{index}", Boolean.Parse(filter.Value)));
                        return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                    }

                    parameters.Add(new NpgsqlParameter($"@{index}", filter.Value));
                    return @$"""{filter.Field}""{ToSqlOperator(filter.Operator)}@{index}";
                case "startswith":
                    parameters.Add(new NpgsqlParameter($"@{index}", filter.Value));
                    return @$"""{filter.Field}"" like " + $" @{index} || '%'";
                case "endswith":
                    parameters.Add(new NpgsqlParameter($"@{index}", filter.Value));
                    return @$"""{filter.Field}"" like " + $"'%' || @{index}";
                case "contains":
                    parameters.Add(new NpgsqlParameter($"@{index}", filter.Value));
                    return @$"""{filter.Field}"" like " + $"'%' || @{index} || '%'";
                default:
                    throw new ArgumentException(
                        "This operator is not yet supported for this Grid",
                        filter.Operator);
            }
        }




        public static string BuildGeneralFilterWhereClause<T>(KendoParams kParams, int index, KendoGeneralFilter filter, List<DbParameter> parameters)
        {

            if (filter.Fields == null || filter.Value == null)
                throw new ArgumentException(
                    "The fields or value are empty");

            string strGeneralFieldsConcatenation =
                  " lower( coalesce(" + string.Join(", '') || ' ' || coalesce(", filter.Fields) + " , '')) ";

            parameters.Add(new NpgsqlParameter($"@{index}", filter.Value.ToLower()));
            return $"{strGeneralFieldsConcatenation}{" LIKE '%' || "}@{index} || '%'";


        }

        public static string? BuildPaginationClause(KendoParams kParams, int index, List<DbParameter> parameters)
        {

            string? paginationClause = null;
            if (kParams.PageSize > 0)
            {
                parameters.Add(new NpgsqlParameter($"@{index}", kParams.PageSize));
                parameters.Add(new NpgsqlParameter($"@{index}", kParams.Page));
                paginationClause = $"OFFSET @{index} *(@{index + 1} - 1) FETCH NEXT @{index} ROWS ONLY";
            }

            return paginationClause;
        }



        public static string? ToSqlOperator(string? @operator)
        {
            switch (@operator?.ToLower())
            {
                case "eq": return " = ";
                case "neq": return " <> ";
                case "gte": return " >= ";
                case "gt": return " > ";
                case "lte": return " <= ";
                case "lt": return " < ";
                case "or": return " or ";
                case "and": return " and ";
                default: return null;
            }
        }


        public static string PrepareFilteringAndPagination<T>(KendoParams kParams,  List<DbParameter> parameters, string originalQuery)
        {

            //filtering


            //var orderFields = param.GetSortFields("CreatedAt desc");

            int indexParameter = parameters.Count;

            string queryPrepared = originalQuery;

            string? whereClause = null;
            var countFilterWhere = 0;


            if (kParams.Filter != null && (kParams.Filter.Filters?.Any() ?? false))
            {
                var filters = kParams.Filter.Filters;
                for (var i = 0; i < filters.Count; i++)
                {
                    indexParameter++;
                    var strWherePart = $"{BuildWhereClause<T>(kParams,indexParameter, filters[i], parameters)}";
                    if (countFilterWhere == 0)
                        whereClause = strWherePart;
                    else
                        whereClause +=
                            $" {ToSqlOperator(kParams.Filter.Logic)} " +
                            strWherePart;

                    countFilterWhere++;
                }

                //if (whereClause != null)
            }


            if(kParams.GeneralFilter != null && 
                    kParams.GeneralFilter.Value != null && kParams.GeneralFilter.Value.Trim().Length > 0 &&
                    kParams.GeneralFilter.Fields != null && kParams.GeneralFilter.Fields.Any())
            {
                indexParameter++;
                var strWherePart = $"{BuildGeneralFilterWhereClause<T>(kParams, indexParameter, kParams.GeneralFilter, parameters)}";
                if (countFilterWhere == 0)
                    whereClause = strWherePart;
                else
                    whereClause +=
                        $" {ToSqlOperator("and")} " +
                        strWherePart;

                countFilterWhere++;
            }


            //sorting
            string? sortClause = null;
            if (kParams.Sort != null && kParams.Sort.Any())
            {
                var sorts = kParams.Sort;
                var countSort = 0;

                foreach (var sort in sorts)
                {

                    var strSortPart = $"{sort.Field} {sort.Dir}";
                    if (countSort == 0)
                        sortClause = strSortPart;
                    else
                        sortClause +=
                            $" , " +
                            strSortPart;

                    countSort++;
                }

                //if (whereClause != null)
            }

            //pagination
            string? paginationClause = null;
            if (kParams.PageSize > 0)
            {
                paginationClause = BuildPaginationClause(kParams, indexParameter, parameters);
                indexParameter += 2;
            }



            if (whereClause != null || sortClause != null || paginationClause != null)
            {
                queryPrepared = $"Select * from ( {originalQuery} ) originalQ ";
                if (whereClause != null)
                    queryPrepared = $"{queryPrepared} where {whereClause}";
                if (sortClause != null)
                    queryPrepared = $"{queryPrepared} order by {sortClause}";
                if (paginationClause != null)
                    queryPrepared = $"{queryPrepared}  {paginationClause}";
            }

            return queryPrepared;
        }

        

    }
}
