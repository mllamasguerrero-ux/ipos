
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
    
    public class Usuario_Obtain_usuarios_derechos_List_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Usuario_Obtain_usuarios_derechos_List_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _Empresaid;
        [XmlAttribute]
        public Int64? Empresaid { get => _Empresaid; set { _Empresaid = value;  } } 

        private Int64? _Sucursalid;
        [XmlAttribute]
        public Int64? Sucursalid { get => _Sucursalid; set { _Sucursalid = value;  } } 

        private List<Int64>? _Derechos;
        [XmlAttribute]
        public List<Int64>? Derechos { get => _Derechos; set { _Derechos = value;  } } 

        private Int64? _UsuarioId;
        [XmlAttribute]
        public Int64? UsuarioId { get => _UsuarioId; set { _UsuarioId = value;  } } 





    }
}

