
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
    
    public class Kitdefinicion_CurrentInfoImpuestosKit_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Kitdefinicion_CurrentInfoImpuestosKit_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private Int64? _ProductoKitId;
        [XmlAttribute]
        public Int64? ProductoKitId { get => _ProductoKitId; set { _ProductoKitId = value;  } } 





    }
}

