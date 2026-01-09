
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
    
    public class Perfiles_UpdatePerfilesDerechos_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Perfiles_UpdatePerfilesDerechos_ApiParam()
        {
        }
        #pragma warning restore 8618


        private PerfilesBindingModel? _ItemSelect;
        [XmlAttribute]
        public PerfilesBindingModel? ItemSelect { get => _ItemSelect; set { _ItemSelect = value;  } } 

        private List<PerfilDerechoItemBindingModel>? _Perfiles_derechos;
        [XmlAttribute]
        public List<PerfilDerechoItemBindingModel>? Perfiles_derechos { get => _Perfiles_derechos; set { _Perfiles_derechos = value;  } } 





    }
}

