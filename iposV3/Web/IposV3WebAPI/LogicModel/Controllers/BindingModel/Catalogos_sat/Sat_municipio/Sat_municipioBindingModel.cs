
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
    public class Sat_municipioBindingModel: Sat_municipioBindingModelGenerated
    {


        public Sat_municipioBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_municipioBindingModel(Sat_municipio item):base(item)
        {
        }
        #endif


       

    }
}

