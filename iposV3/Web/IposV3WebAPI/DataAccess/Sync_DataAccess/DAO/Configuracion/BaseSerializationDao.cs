using IposV3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BIPOS.Database.DAO
{
    public class BaseSerializationDao<T,P> where T : BaseSerializationObj where P : class
    {
        protected string FileName { get; set; }
        public string Comentario { get; set; }

        public  BaseSerializationDao()
        {
            this.FileName = "";
            this.PutDataLocation();
            this.Comentario = "";
        }

        protected virtual void PutDataLocation()
        {

            this.FileName = "";
        }

        public virtual List<T> SelectList(SerializationTransaction? st, P? param, KendoParams? kendoParams) 
        {
            List<T> listToReturn = new List<T>();
            Comentario = "";
            try
            {
                listToReturn = DeSerializeObject<List<T>>() ?? new List<T>();

                if (listToReturn == null)
                    listToReturn = new List<T>();

                return listToReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Comentario =  "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
            }
        }



        public virtual bool Insert(T item, SerializationTransaction? transaction)
        {
            Comentario = "";
                List<T> listSaved = DeSerializeObject<List<T>>() ?? new List<T>();
                if (listSaved == null)
                    listSaved = new List<T>();

                var lastId = listSaved.Max(y => y.Id);

                if (lastId == null)
                    lastId = 0;


                lastId++;
                item.Id = lastId;

                listSaved.Add(item);

                bool result = SerializeObject<List<T>>(listSaved);

                if (!result )
                    throw new InvalidOperationException("No se pudo realizar la insercion . Error para el usuario " + Comentario );

                return true;
        }


        public virtual bool Delete(T item, SerializationTransaction? transaction) 
        {
            Comentario = "";
                List<T> listSaved = DeSerializeObject<List<T>>() ?? new List<T>() ?? new List<T>();
                var itemToDelete = listSaved.Find(y => y.Id == item.Id);
                if(itemToDelete != null)
                 listSaved.Remove(itemToDelete);

                bool result = SerializeObject<List<T>>(listSaved);

                if (!result)
                    throw new InvalidOperationException("No se pudo realizar la insercion . Error para el usuario " + Comentario);

                return true;
        }


        public virtual bool Update(T item, SerializationTransaction? transaction) 
        {
            Comentario = "";
                List<T> listSaved = DeSerializeObject<List<T>>() ?? new List<T>();
                var itemToDelete = listSaved.Find(y => y.Id == item.Id);

                if(itemToDelete!= null)
                    listSaved.Remove(itemToDelete);

                listSaved.Add(item);

                bool result = SerializeObject<List<T>>(listSaved);

                if (!result)
                    throw new InvalidOperationException("No se pudo realizar la insercion . Error para el usuario " + Comentario);

                return true;
        }



        public List<T> Select(SerializationTransaction? st, string search)
        {
            return SelectList(st, null, null);
        }


        public List<T> GetAll_(SerializationTransaction? st)
        {
            return SelectList(st, null, null);
        }


        public T? Get_ById(T itemSelect, SerializationTransaction? st)
        {
            List<T> listToReturn = new List<T>();
            Comentario = "";
            try
            {
                listToReturn = DeSerializeObject<List<T>>() ?? new List<T>();
                if (listToReturn != null)
                    return listToReturn.Where(y => y.Id == itemSelect.Id).FirstOrDefault();
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Comentario = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw;
                //return null;
            }
        }


        public List<T> Select_ById(T itemSelect, SerializationTransaction? st)
        {

            List<T> listToReturn = new List<T>();
            Comentario = "";
            try
            {
                listToReturn = DeSerializeObject<List<T>>() ?? new List<T>();
                if (listToReturn != null)
                    return listToReturn.Where(y => y.Id == itemSelect.Id).ToList();
                else
                    return new List<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Comentario = "Ocurrio un error al actualizar el registro, vea la consola del explorador para mas detalles";
                throw ;
                //return null;
            }
        }


        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public bool SerializeObject<Y>(Y serializableObject)
        {
            Comentario = "";
            if (serializableObject == null) { Comentario = "El objeto es nulo"; return false; }


            var folderDestino = System.IO.Path.GetDirectoryName(FileName);
            if (folderDestino != null && !Directory.Exists(folderDestino))
                System.IO.Directory.CreateDirectory(folderDestino);

            XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(FileName);
                    stream.Close();
                }
                return true;
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Y? DeSerializeObject<Y>()
        {
            Comentario = "";
            try
            {
                if (string.IsNullOrEmpty(FileName)) { return default(Y); }

                Y? objectOut = default(Y);

                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(Y);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (Y?)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }

                return objectOut;
            }
            catch{

                return default(Y);
            }
        }
    }
}
