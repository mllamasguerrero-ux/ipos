using System.Collections.Generic;

namespace DataAccess {
    public interface IDataProvider<T> where T:class {
        T? GetById(int id);

        void Change(T newEntity);

        void Add(T entity);

        void Remove(int id);

        IEnumerable<T?> GetAll();

        void SubmitChanges();
    }
}