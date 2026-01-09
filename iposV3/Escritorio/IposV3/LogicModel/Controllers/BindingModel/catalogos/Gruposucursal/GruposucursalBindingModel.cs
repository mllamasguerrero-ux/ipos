
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
    public class GruposucursalBindingModel: GruposucursalBindingModelGenerated
    {


        public GruposucursalBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public GruposucursalBindingModel(Gruposucursal item):base(item)
        {
        }
        #endif

       

    }
}

