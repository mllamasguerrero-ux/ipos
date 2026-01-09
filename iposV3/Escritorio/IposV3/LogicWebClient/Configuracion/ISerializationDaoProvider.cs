using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.DataAccess
{

    public class SerializationTransaction
    {
        public SerializationTransaction()
        {

        }
    }

    public interface ISerializationDaoProvider<T, P> where T : BaseSerializationObj where P : class
    {




        bool Insert(T item, SerializationTransaction? transaction);
        bool Delete(T item, SerializationTransaction? transaction);

        bool Update(T item, SerializationTransaction? transaction);


        List<T> SelectList(SerializationTransaction? st, P? param, Model.KendoParams? kendoParams);






        
        //T GetById(T itemSelect, SerializationTransaction? st);
        T Get_ById(T itemSelect, SerializationTransaction? st);
        //List<T> GetAll(SerializationTransaction? st);
        List<T> GetAll_(SerializationTransaction? st);

        List<T> Select(SerializationTransaction? st, string search);
        //List<T> SelectById(T itemSelect, SerializationTransaction? st);
        List<T> Select_ById(T itemSelect, SerializationTransaction? st);

        //T InsertT(T item, SerializationTransaction? transaction, out int result);


    }
}
