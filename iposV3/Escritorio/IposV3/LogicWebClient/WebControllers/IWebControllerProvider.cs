using IposV3.Model;
using System.Collections.Generic;

namespace Controllers
{
    public interface IWebControllerProvider<T> where T : class 
    {
        Task<T?> GetById(T itemSelect);
        Task<List<T>> GetAll();

        Task<List<T>> SelectList(object? param, KendoParams? kendoParams);

        Task<bool> Insert(T item);
        Task<List<T>> Select(object param, string search, string fieldsSearching);
        Task<List<T>> SelectById(T itemSelect);
        Task<bool> Update(T item);
        Task<bool> Delete(T item);
        
    }
}