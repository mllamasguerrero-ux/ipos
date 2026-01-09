
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
    public class Sat_coloniaBindingModel: Sat_coloniaBindingModelGenerated
    {


        public Sat_coloniaBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_coloniaBindingModel(Sat_colonia item):base(item)
        {
        }

        #endif

       

    }
}

