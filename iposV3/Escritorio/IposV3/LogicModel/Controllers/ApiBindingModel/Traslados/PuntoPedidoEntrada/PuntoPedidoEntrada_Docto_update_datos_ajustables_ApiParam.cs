
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
    
    public class PuntoPedidoEntrada_Docto_update_datos_ajustables_ApiParam
    
    {
        
        #pragma warning disable 8618
        public PuntoPedidoEntrada_Docto_update_datos_ajustables_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private Int64? _Id;
        [XmlAttribute]
        public Int64? Id { get => _Id; set { _Id = value;  } } 

        private Int64? _UsuarioId;
        [XmlAttribute]
        public Int64? UsuarioId { get => _UsuarioId; set { _UsuarioId = value;  } } 

        private Int64? _AlmacenId;
        [XmlAttribute]
        public Int64? AlmacenId { get => _AlmacenId; set { _AlmacenId = value;  } } 

        private String? _Referencias;
        [XmlAttribute]
        public String? Referencias { get => _Referencias; set { _Referencias = value;  } } 





    }
}

