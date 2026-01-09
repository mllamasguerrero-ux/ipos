
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
    
    public class Pago_PagoCompuestoRevertir_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Pago_PagoCompuestoRevertir_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private Int64? _PagoARevertirId;
        [XmlAttribute]
        public Int64? PagoARevertirId { get => _PagoARevertirId; set { _PagoARevertirId = value;  } } 

        private Int64? _UsuarioId;
        [XmlAttribute]
        public Int64? UsuarioId { get => _UsuarioId; set { _UsuarioId = value;  } } 

        private Int64? _CorteId;
        [XmlAttribute]
        public Int64? CorteId { get => _CorteId; set { _CorteId = value;  } } 

        private String? _Notas;
        [XmlAttribute]
        public String? Notas { get => _Notas; set { _Notas = value;  } } 

        //private out Int64? _PagoId;
        //[XmlAttribute]
        //public out Int64? PagoId { get => _PagoId; set { _PagoId = value;  } } 





    }
}

