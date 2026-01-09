
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
    public class Sat_paisBindingModel: Sat_paisBindingModelGenerated
    {


        public Sat_paisBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_paisBindingModel(Sat_pais item):base(item)
        {
        }
        #endif


       

    }
}

