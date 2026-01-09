
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
    public class Sat_unidadmedidaBindingModel: Sat_unidadmedidaBindingModelGenerated
    {


        public Sat_unidadmedidaBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_unidadmedidaBindingModel(Sat_unidadmedida item):base(item)
        {
        }
        #endif


       

    }
}

