
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
    
    public class PuntoVentaDevo_Movto_venddevo_delete_ApiParam
    
    {
        
        #pragma warning disable 8618
        public PuntoVentaDevo_Movto_venddevo_delete_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } }


        private List<Int64>? _ListIds;
        [XmlAttribute]
        public List<Int64>? ListIds { get => _ListIds; set { _ListIds = value; } }


        private Int64? _DoctoId;
        [XmlAttribute]
        public Int64? DoctoId { get => _DoctoId; set { _DoctoId = value; } }





    }
}

