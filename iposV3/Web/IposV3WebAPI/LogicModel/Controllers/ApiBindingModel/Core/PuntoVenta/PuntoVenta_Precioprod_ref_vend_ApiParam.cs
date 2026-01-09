
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
    
    public class PuntoVenta_Precioprod_ref_vend_ApiParam
    
    {
        
        #pragma warning disable 8618
        public PuntoVenta_Precioprod_ref_vend_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private Int64? _ProductoId;
        [XmlAttribute]
        public Int64? ProductoId { get => _ProductoId; set { _ProductoId = value;  } } 

        private Int64? _ClienteId;
        [XmlAttribute]
        public Int64? ClienteId { get => _ClienteId; set { _ClienteId = value;  } } 

        private Decimal? _Cantidad;
        [XmlAttribute]
        public Decimal? Cantidad { get => _Cantidad; set { _Cantidad = value;  } } 





    }
}

