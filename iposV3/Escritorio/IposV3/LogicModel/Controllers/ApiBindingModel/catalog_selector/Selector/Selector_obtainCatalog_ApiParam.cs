
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
    
    public class Selector_obtainCatalog_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Selector_obtainCatalog_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Models.CatalogSelector.CatalogDef? _CatalogDef;
        [XmlAttribute]
        public Models.CatalogSelector.CatalogDef? CatalogDef { get => _CatalogDef; set { _CatalogDef = value;  } } 

        private BaseParam? _BaseParam;
        [XmlAttribute]
        public BaseParam? BaseParam { get => _BaseParam; set { _BaseParam = value;  } } 





    }
}

