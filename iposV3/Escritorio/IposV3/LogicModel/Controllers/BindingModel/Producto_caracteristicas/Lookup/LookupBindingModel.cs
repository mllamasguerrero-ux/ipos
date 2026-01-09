
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
    public class LookupBindingModel: LookupBindingModelGenerated
    {


        public LookupBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public LookupBindingModel(Lookup item):base(item)
        {
        }
        #endif

       

    }
}

