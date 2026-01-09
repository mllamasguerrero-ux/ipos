
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using BindingModels;

namespace ApiParam
{
    [XmlRoot]
    
    public class Selector_obtainItemByClave_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Selector_obtainItemByClave_ApiParam()
        {
        }
        #pragma warning restore 8618


        private String? _StrCatalogo;
        [XmlAttribute]
        public String? StrCatalogo { get => _StrCatalogo; set { _StrCatalogo = value;  } } 

        private String? _StrClave;
        [XmlAttribute]
        public String? StrClave { get => _StrClave; set { _StrClave = value;  } } 

        private BaseParam? _BaseParam;
        [XmlAttribute]
        public BaseParam? BaseParam { get => _BaseParam; set { _BaseParam = value;  } } 





    }
}

