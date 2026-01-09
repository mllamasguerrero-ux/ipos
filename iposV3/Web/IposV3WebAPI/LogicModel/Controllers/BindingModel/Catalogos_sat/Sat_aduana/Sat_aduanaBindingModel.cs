
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
    public class Sat_aduanaBindingModel: Sat_aduanaBindingModelGenerated
    {


        public Sat_aduanaBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_aduanaBindingModel(Sat_aduana item):base(item)
        {
        }
        #endif


       

    }
}

