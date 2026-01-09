
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
    
    public class Cfdi_Facturacion_FileLocalLocation_XML_Timbrados_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Cfdi_Facturacion_FileLocalLocation_XML_Timbrados_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _TipoDoctoId;
        [XmlAttribute]
        public Int64? TipoDoctoId { get => _TipoDoctoId; set { _TipoDoctoId = value;  } }


#if PROYECTO_WEB
        private Parametro? _Parametro;
        [XmlAttribute]
        public Parametro? Parametro { get => _Parametro; set { _Parametro = value; } }
#endif


#if PROYECTO_ESCRITORIO
        private ParametroBindingModel? _Parametro;
        [XmlAttribute]
        public ParametroBindingModel? Parametro { get => _Parametro; set { _Parametro = value;  } } 
#endif



        private String? _Tipocomprobanteespecial;
        [XmlAttribute]
        public String? Tipocomprobanteespecial { get => _Tipocomprobanteespecial; set { _Tipocomprobanteespecial = value;  } } 





    }
}

