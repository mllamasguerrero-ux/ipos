
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
    public class Sat_partetransporteBindingModel: Sat_partetransporteBindingModelGenerated
    {


        public Sat_partetransporteBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_partetransporteBindingModel(Sat_partetransporte item):base(item)
        {
        }

        #endif

       

    }
}

