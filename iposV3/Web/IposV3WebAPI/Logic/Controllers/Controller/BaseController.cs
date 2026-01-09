using IposV3.Model;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controller
{
    public class BaseController<T> : IControllerProvider<T> where T : class 
    {

        public virtual T? GetById(T itemSelect)
        {
            throw new Exception("not implemented");
        }
        public virtual List<T> GetAll()
        {
            throw new Exception("not implemented");
        }

        public virtual List<T> SelectList(object? param, KendoParams? kendoParams)
        {
            throw new Exception("not implemented");
        }

        public virtual bool Insert(T item)
        {
            throw new Exception("not implemented");
        }
        public virtual List<T> Select(object param, string search, string fieldsSearching)
        {
            throw new Exception("not implemented");
        }
        public virtual List<T> SelectById(T itemSelect)
        {
            throw new Exception("not implemented");
        }
        public virtual bool Update(T item)
        {
            throw new Exception("not implemented");
        }
        public virtual bool Delete(T item)
        {
            throw new Exception("not implemented");
        }


        public virtual List<T> Select(string search)
        {

            throw new Exception("not implemented");
        }

        public virtual List<KendoSort> FillDefaultSort()
        {
            return new List<KendoSort>(){ new KendoSort() {
                Field = "Creado",
                Dir = "asc"
            } };
        }



    }
}
