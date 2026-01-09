
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
    public class Sat_subtiporemBindingModel: Sat_subtiporemBindingModelGenerated
    {


        public Sat_subtiporemBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_subtiporemBindingModel(Sat_subtiporem item):base(item)
        {
        }
        #endif


       

    }
}

