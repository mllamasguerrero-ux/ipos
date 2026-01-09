
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    [XmlRoot]
    public class Sucursal_infoBindingModel: Sucursal_infoBindingModelGenerated
    {


        public Sucursal_infoBindingModel():base()
        {
        }
        
        
        #if PROYECTO_WEB
        public Sucursal_infoBindingModel(Sucursal_info item)//:base(item)
        {
            this.FillFromEntity(item);
        }



        public new void FillFromEntity(Sucursal_info item)
        {
            if (item.Sucursal_info_opciones == null)
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();

            base.FillFromEntity(item);
        }


        public new void FillCatalogRelatedFields(Sucursal_info item)
        {
            base.FillCatalogRelatedFields(item);


        }


        public new void FillEntityValues(ref Sucursal_info item)
        {
            if (item.Sucursal_info_opciones == null)
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();

            base.FillEntityValues(ref item);

        }
        #endif


    }
}

