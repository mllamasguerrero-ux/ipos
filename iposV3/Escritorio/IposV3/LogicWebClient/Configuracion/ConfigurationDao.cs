using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.DataAccess
{
    public class ConfiguracionDao: BaseSerializationDao<Configuracion,ConfiguracionParam>
    {

        protected override void PutDataLocation()
        {

            this.FileName = Environment.CurrentDirectory + "\\systemdata\\configuracion.xml"  ;
        }


        public override List<Configuracion> SelectList(SerializationTransaction? st, ConfiguracionParam? param, Model.KendoParams? kendoParams)
        {

            return base.SelectList(null, null, null).OrderBy(y => y.Id).ToList();
        }

        public override bool Insert(Configuracion item, SerializationTransaction? transaction)
        {
            bool result = base.Insert(item, transaction);

            removeDefaultInOthers(item, transaction);

            return result;

        }


        private void removeDefaultInOthers(Configuracion item, SerializationTransaction? transaction)
        {

            if (item.Esdefault == "S")
            {
                var lista = this.SelectList(transaction, null, null);
                foreach (var conf in lista)
                {
                    if (item.Nombre != null && !item.Nombre.Equals(conf.Nombre) &&
                        conf.Esdefault == "S")
                    {
                        conf.Esdefault = "N";
                        this.Update(conf, null);
                    }
                }
            }
        }

        public override bool Delete(Configuracion item, SerializationTransaction? transaction)
        {

            bool result = base.Delete(item, transaction);
            removeDefaultInOthers(item, transaction);
            return result;
        }
        public override bool Update(Configuracion item, SerializationTransaction? transaction)
        {

            bool result = base.Update(item, transaction);
            removeDefaultInOthers(item, transaction);
            return result;
        }
    }
}
