
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
    public class Motivo_camfecBindingModel: Motivo_camfecBindingModelGenerated
    {


        public Motivo_camfecBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public Motivo_camfecBindingModel(Motivo_camfec item):base(item)
        {
        }

        #endif
       

    }
}

