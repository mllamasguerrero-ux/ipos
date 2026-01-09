
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
    public class Motivo_devolucionBindingModel: Motivo_devolucionBindingModelGenerated
    {


        public Motivo_devolucionBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public Motivo_devolucionBindingModel(Motivo_devolucion item):base(item)
        {
        }
        #endif

       

    }
}

