
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
    public class ContenidoBindingModel: ContenidoBindingModelGenerated
    {


        public ContenidoBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public ContenidoBindingModel(Contenido item):base(item)
        {
        }

        #endif
        
       

    }
}

