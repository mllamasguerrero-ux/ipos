using IposV3.Model;
using Npgsql;
using System.Collections.Generic;

namespace Controllers
{
    public interface IControllerProvider<T> where T : class 
    {
        T? GetById(T itemSelect);
        List<T> GetAll();

        List<T> SelectList(object? param, KendoParams? kendoParams);

        bool Insert(T item);
        List<T> Select(object param, string search, string fieldsSearching);
        List<T> SelectById(T itemSelect);
        bool Update(T item);
        bool Delete(T item);
        
    }
}