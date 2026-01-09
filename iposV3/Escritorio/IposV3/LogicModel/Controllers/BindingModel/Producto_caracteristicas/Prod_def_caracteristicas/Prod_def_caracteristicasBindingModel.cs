
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
    public class Prod_def_caracteristicasBindingModel: Prod_def_caracteristicasBindingModelGenerated
    {


        public Prod_def_caracteristicasBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public Prod_def_caracteristicasBindingModel(Prod_def_caracteristicas item):base(item)
        {
        }
        #endif

       

    }
}

