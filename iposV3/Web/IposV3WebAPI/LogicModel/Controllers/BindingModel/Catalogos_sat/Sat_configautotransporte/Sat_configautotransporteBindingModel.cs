
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
    public class Sat_configautotransporteBindingModel: Sat_configautotransporteBindingModelGenerated
    {


        public Sat_configautotransporteBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_configautotransporteBindingModel(Sat_configautotransporte item):base(item)
        {
        }
        #endif


       

    }
}

