
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
    public class Sat_usocfdiBindingModel: Sat_usocfdiBindingModelGenerated
    {


        public Sat_usocfdiBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_usocfdiBindingModel(Sat_usocfdi item):base(item)
        {
        }
        #endif


       

    }
}

