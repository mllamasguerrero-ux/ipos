
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
    public class Sat_tipopermisoBindingModel: Sat_tipopermisoBindingModelGenerated
    {


        public Sat_tipopermisoBindingModel():base()
        {
        }

        #if PROYECTO_WEB
        public Sat_tipopermisoBindingModel(Sat_tipopermiso item):base(item)
        {
        }
        #endif


       

    }
}

