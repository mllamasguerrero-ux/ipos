
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
    
    public class Usuario_GetUsuariosPerfiles_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Usuario_GetUsuariosPerfiles_ApiParam()
        {
        }
        #pragma warning restore 8618


        private UsuarioBindingModel? _ItemSelect;
        [XmlAttribute]
        public UsuarioBindingModel? ItemSelect { get => _ItemSelect; set { _ItemSelect = value;  } } 

        private KendoParams? _KendoParams;
        [XmlAttribute]
        public KendoParams? KendoParams { get => _KendoParams; set { _KendoParams = value;  } } 





    }
}

