
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
    public class Sat_matpeligrosoBindingModel: Sat_matpeligrosoBindingModelGenerated
    {


        public Sat_matpeligrosoBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_matpeligrosoBindingModel(Sat_matpeligroso item):base(item)
        {
        }
        #endif


       

    }
}

