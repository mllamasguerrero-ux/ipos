
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
    
    public class Guia_InsertHeaderAndDetail_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Guia_InsertHeaderAndDetail_ApiParam()
        {
        }
        #pragma warning restore 8618


        private GuiaBindingModel? _Item;
        [XmlAttribute]
        public GuiaBindingModel? Item { get => _Item; set { _Item = value;  } } 

        private GuiadetalleBindingModel? _GuiaDetalle;
        [XmlAttribute]
        public GuiadetalleBindingModel? GuiaDetalle { get => _GuiaDetalle; set { _GuiaDetalle = value;  } } 

        private DoctoBindingModel? _Docto;
        [XmlAttribute]
        public DoctoBindingModel? Docto { get => _Docto; set { _Docto = value;  } } 





    }
}

