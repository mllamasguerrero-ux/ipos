
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
    
    public class Usuario_UpdateUsuariosPerfiles_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Usuario_UpdateUsuariosPerfiles_ApiParam()
        {
        }
        #pragma warning restore 8618


        private UsuarioBindingModel? _ItemSelect;
        [XmlAttribute]
        public UsuarioBindingModel? ItemSelect { get => _ItemSelect; set { _ItemSelect = value;  } } 

        private List<UsuarioPerfilItemBindingModel>? _Usuarios_perfiles;
        [XmlAttribute]
        public List<UsuarioPerfilItemBindingModel>? Usuarios_perfiles { get => _Usuarios_perfiles; set { _Usuarios_perfiles = value;  } } 





    }
}

