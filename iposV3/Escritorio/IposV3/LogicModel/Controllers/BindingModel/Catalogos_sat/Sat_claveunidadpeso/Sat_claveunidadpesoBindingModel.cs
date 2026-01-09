
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
    public class Sat_claveunidadpesoBindingModel: Sat_claveunidadpesoBindingModelGenerated
    {


        public Sat_claveunidadpesoBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_claveunidadpesoBindingModel(Sat_claveunidadpeso item):base(item)
        {
        }
        #endif


       

    }
}

