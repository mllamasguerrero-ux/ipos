
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace ApiParam
{
    [XmlRoot]
    
    public class Producto_SelectForSimpleList_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Producto_SelectForSimpleList_ApiParam()
        {
        }
        #pragma warning restore 8618


        private ProductoParam? _Param;
        [XmlAttribute]
        public ProductoParam? Param { get => _Param; set { _Param = value;  } } 

        private KendoParams? _KendoParams;
        [XmlAttribute]
        public KendoParams? KendoParams { get => _KendoParams; set { _KendoParams = value;  } } 





    }
}

