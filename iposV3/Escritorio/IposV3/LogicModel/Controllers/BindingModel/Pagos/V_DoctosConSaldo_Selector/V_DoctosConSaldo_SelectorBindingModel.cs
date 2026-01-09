
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
    public class V_DoctosConSaldo_SelectorBindingModel: V_DoctosConSaldo_SelectorBindingModelGenerated
    {


        public V_DoctosConSaldo_SelectorBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public V_DoctosConSaldo_SelectorBindingModel(TmpDoctosConSaldo_Selector item):base(item)
        {
        }
        #endif
        

       

    }
}

