
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
    public class Sat_regimenfiscalBindingModel: Sat_regimenfiscalBindingModelGenerated
    {


        public Sat_regimenfiscalBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_regimenfiscalBindingModel(Sat_regimenfiscal item):base(item)
        {
        }
        #endif


       

    }
}

