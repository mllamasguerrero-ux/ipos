
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using BindingModels;

namespace ApiParam
{
    [XmlRoot]
    
    public class Kitdefinicion_InsertYModificarImpuestosSiAplica_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Kitdefinicion_InsertYModificarImpuestosSiAplica_ApiParam()
        {
        }
        #pragma warning restore 8618


        private KitdefinicionBindingModel? _Item;
        [XmlAttribute]
        public KitdefinicionBindingModel? Item { get => _Item; set { _Item = value;  } } 

        //private out ImpuestoKitDefinicion? _ImpuestoKitDefinicion;
        //[XmlAttribute]
        //public out ImpuestoKitDefinicion? ImpuestoKitDefinicion { get => _ImpuestoKitDefinicion; set { _ImpuestoKitDefinicion = value;  } } 





    }
}

