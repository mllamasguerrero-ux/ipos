
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
    
    public class PuntoTrasladoRecepcion_Recibir_traslado_ApiParam
    
    {
        
        #pragma warning disable 8618
        public PuntoTrasladoRecepcion_Recibir_traslado_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Recibir_traslado_ParamWFBindingModel? _Param;
        [XmlAttribute]
        public Recibir_traslado_ParamWFBindingModel? Param { get => _Param; set { _Param = value;  } } 

        private List<Recepcion_movto_traslado_impo>? _MovtosARecibir;
        [XmlAttribute]
        public List<Recepcion_movto_traslado_impo>? MovtosARecibir { get => _MovtosARecibir; set { _MovtosARecibir = value;  } }


        //NOTNEEDED MLG 2025 Migracion web out
        //private out Int64? _DoctoDevolucionId;
        //[XmlAttribute]
        //public out Int64? DoctoDevolucionId { get => _DoctoDevolucionId; set { _DoctoDevolucionId = value;  } } 





    }
}

