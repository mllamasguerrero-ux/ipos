
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
    
    public class PuntoVentaDevo_Select_V_docto_vend_to_devo_List_ApiParam
    
    {
        
        #pragma warning disable 8618
        public PuntoVentaDevo_Select_V_docto_vend_to_devo_List_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private Int64? _UsuarioId;
        [XmlAttribute]
        public Int64? UsuarioId { get => _UsuarioId; set { _UsuarioId = value;  } } 

        private Int64? _TipoDoctoId;
        [XmlAttribute]
        public Int64? TipoDoctoId { get => _TipoDoctoId; set { _TipoDoctoId = value;  } } 

        private Int64? _EstatusDoctoId;
        [XmlAttribute]
        public Int64? EstatusDoctoId { get => _EstatusDoctoId; set { _EstatusDoctoId = value;  } } 

        private DateTimeOffset? _FechaIni;
        [XmlAttribute]
        public DateTimeOffset? FechaIni { get => _FechaIni; set { _FechaIni = value;  } } 

        private DateTimeOffset? _FechaFin;
        [XmlAttribute]
        public DateTimeOffset? FechaFin { get => _FechaFin; set { _FechaFin = value;  } } 





    }
}

