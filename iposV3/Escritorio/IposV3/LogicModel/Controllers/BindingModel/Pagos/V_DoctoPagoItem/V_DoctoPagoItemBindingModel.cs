
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    [XmlRoot]
    public class V_DoctoPagoItemBindingModel: V_DoctoPagoItemBindingModelGenerated
    {


        public V_DoctoPagoItemBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public V_DoctoPagoItemBindingModel(TmpDoctoPagoItem item):base(item)
        {
        }
        #endif
        

       

    }
}

