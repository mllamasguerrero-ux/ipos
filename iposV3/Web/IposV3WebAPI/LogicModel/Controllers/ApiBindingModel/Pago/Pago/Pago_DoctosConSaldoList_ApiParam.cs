
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
    
    public class Pago_DoctosConSaldoList_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Pago_DoctosConSaldoList_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private Int64? _Tipodoctoid;
        [XmlAttribute]
        public Int64? Tipodoctoid { get => _Tipodoctoid; set { _Tipodoctoid = value;  } } 

        private Int64? _ClienteId;
        [XmlAttribute]
        public Int64? ClienteId { get => _ClienteId; set { _ClienteId = value;  } } 

        private Int64? _ProveedorId;
        [XmlAttribute]
        public Int64? ProveedorId { get => _ProveedorId; set { _ProveedorId = value;  } } 

        private Boolean? _SoloTimbrados;
        [XmlAttribute]
        public Boolean? SoloTimbrados { get => _SoloTimbrados; set { _SoloTimbrados = value;  } } 

        private Int64? _UsuarioId;
        [XmlAttribute]
        public Int64? UsuarioId { get => _UsuarioId; set { _UsuarioId = value;  } } 

        private Boolean? _CorteActivo;
        [XmlAttribute]
        public Boolean? CorteActivo { get => _CorteActivo; set { _CorteActivo = value;  } } 

        private String? _Referencia;
        [XmlAttribute]
        public String? Referencia { get => _Referencia; set { _Referencia = value;  } } 

        private DateTimeOffset? _FechaInicial;
        [XmlAttribute]
        public DateTimeOffset? FechaInicial { get => _FechaInicial; set { _FechaInicial = value;  } } 

        private DateTimeOffset? _FechaFinal;
        [XmlAttribute]
        public DateTimeOffset? FechaFinal { get => _FechaFinal; set { _FechaFinal = value;  } } 

        private Int64? _EstatusDoctoId;
        [XmlAttribute]
        public Int64? EstatusDoctoId { get => _EstatusDoctoId; set { _EstatusDoctoId = value;  } } 





    }
}

