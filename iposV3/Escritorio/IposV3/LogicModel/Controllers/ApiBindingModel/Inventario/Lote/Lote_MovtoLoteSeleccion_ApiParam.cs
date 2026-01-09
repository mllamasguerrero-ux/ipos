
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
    
    public class Lote_MovtoLoteSeleccion_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Lote_MovtoLoteSeleccion_ApiParam()
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

        private Int64? _AlmacenId;
        [XmlAttribute]
        public Int64? AlmacenId { get => _AlmacenId; set { _AlmacenId = value;  } } 

        private Int64? _DoctoId;
        [XmlAttribute]
        public Int64? DoctoId { get => _DoctoId; set { _DoctoId = value;  } } 





    }
}

