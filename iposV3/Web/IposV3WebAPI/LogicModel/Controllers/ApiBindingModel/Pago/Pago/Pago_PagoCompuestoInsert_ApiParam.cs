
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace ApiParam
{
    [XmlRoot]
    
    public class Pago_PagoCompuestoInsert_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Pago_PagoCompuestoInsert_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Pago_transaccion? _PagoTransaccion;
        [XmlAttribute]
        public Pago_transaccion? PagoTransaccion { get => _PagoTransaccion; set { _PagoTransaccion = value;  } } 

        private List<DoctoPago_transaccion>? _DoctoPagoTransacciones;
        [XmlAttribute]
        public List<DoctoPago_transaccion>? DoctoPagoTransacciones { get => _DoctoPagoTransacciones; set { _DoctoPagoTransacciones = value;  } } 

        //private out Int64? _PagoId;
        //[XmlAttribute]
        //public out Int64? PagoId { get => _PagoId; set { _PagoId = value;  } } 





    }
}

