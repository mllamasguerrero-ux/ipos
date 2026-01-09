
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
    
    public class Selector_ObtainCatalogs_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Selector_ObtainCatalogs_ApiParam()
        {
        }
        #pragma warning restore 8618


        private List<Models.CatalogSelector.CatalogDef>? _LstCatalogDef;
        [XmlAttribute]
        public List<Models.CatalogSelector.CatalogDef>? LstCatalogDef { get => _LstCatalogDef; set { _LstCatalogDef = value;  } } 

        private BaseParam? _BaseParam;
        [XmlAttribute]
        public BaseParam? BaseParam { get => _BaseParam; set { _BaseParam = value;  } } 





    }
}

