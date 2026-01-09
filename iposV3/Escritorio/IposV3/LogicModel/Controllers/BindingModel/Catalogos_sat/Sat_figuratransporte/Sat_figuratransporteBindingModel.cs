
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
    public class Sat_figuratransporteBindingModel: Sat_figuratransporteBindingModelGenerated
    {


        public Sat_figuratransporteBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_figuratransporteBindingModel(Sat_figuratransporte item):base(item)
        {
        }
        #endif


       

    }
}

