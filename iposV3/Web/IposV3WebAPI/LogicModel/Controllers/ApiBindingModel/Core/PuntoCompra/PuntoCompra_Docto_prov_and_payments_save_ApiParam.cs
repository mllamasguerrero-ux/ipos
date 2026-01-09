
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
using IposV3.Services;

namespace ApiParam
{
    [XmlRoot]
    
    public class PuntoCompra_Docto_prov_and_payments_save_ApiParam
    
    {
        
        #pragma warning disable 8618
        public PuntoCompra_Docto_prov_and_payments_save_ApiParam()
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

        private List<DoctoPagoDirect>? _ListPagos;
        [XmlAttribute]
        public List<DoctoPagoDirect>? ListPagos { get => _ListPagos; set { _ListPagos = value;  } } 





    }
}

