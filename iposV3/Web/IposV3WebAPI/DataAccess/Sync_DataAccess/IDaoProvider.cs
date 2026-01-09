using IposV3.Model;
using Npgsql;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IDaoProvider<T,P> where T : class where P : class
    {
        T? GetById(T itemSelect, NpgsqlTransaction st);
        T? Get_ById(T itemSelect, NpgsqlTransaction st);
        List<T>? GetAll(NpgsqlTransaction st);
        List<T>? GetAll_(NpgsqlTransaction st);

        bool Insert(T item, NpgsqlTransaction transaction);
        List<T> Select(NpgsqlTransaction st, string search);
        List<T> SelectById(T itemSelect, NpgsqlTransaction st);
        List<T> Select_ById(T itemSelect, NpgsqlTransaction st);
        bool Update(T item, NpgsqlTransaction transaction);
        bool Delete(T item, NpgsqlTransaction transaction);

        T InsertT(T item, NpgsqlTransaction transaction, out int result);

        List<T> SelectList(NpgsqlTransaction st, P param, KendoParams kendoParams);

        List<T> SelectList(NpgsqlTransaction st, P param, KendoParams kendoParams, string strSelectQueryList);

        NpgsqlConnection? GetConnection();
    }
}