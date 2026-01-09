
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    
    [XmlRoot]
    public class FRptDoctoPagosWFBindingModel : Validatable
    {

        public FRptDoctoPagosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbtipodocto;
        [XmlAttribute]
        public long? Cbtipodocto { get => _Cbtipodocto; set { if (RaiseAcceptPendingChange(value, _Cbtipodocto)) { _Cbtipodocto = value; OnPropertyChanged(); } } }

        private long? _Cbformapago;
        [XmlAttribute]
        public long? Cbformapago { get => _Cbformapago; set { if (RaiseAcceptPendingChange(value, _Cbformapago)) { _Cbformapago = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private long? _Grupousuarioid;
        [XmlAttribute]
        public long? Grupousuarioid { get => _Grupousuarioid; set { if (RaiseAcceptPendingChange(value, _Grupousuarioid)) { _Grupousuarioid = value; OnPropertyChanged(); } } }

        private string? _GrupousuarioidClave;
        [XmlAttribute]
        public string? GrupousuarioidClave { get => _GrupousuarioidClave; set { if (RaiseAcceptPendingChange(value, _GrupousuarioidClave)) { _GrupousuarioidClave = value; OnPropertyChanged(); } } }

        private string? _GrupousuarioidNombre;
        [XmlAttribute]
        public string? GrupousuarioidNombre { get => _GrupousuarioidNombre; set { if (RaiseAcceptPendingChange(value, _GrupousuarioidNombre)) { _GrupousuarioidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbgrupocajerostodos;
        [XmlAttribute]
        public BoolCN? Cbgrupocajerostodos { get => _Cbgrupocajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbgrupocajerostodos)) { _Cbgrupocajerostodos = value; OnPropertyChanged(); } } }

        private string? _CbtipodoctoClave;
        [XmlAttribute]
        public string? CbtipodoctoClave { get => _CbtipodoctoClave; set { if (RaiseAcceptPendingChange(value, _CbtipodoctoClave)) { _CbtipodoctoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipodoctoNombre;
        [XmlAttribute]
        public string? CbtipodoctoNombre { get => _CbtipodoctoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipodoctoNombre)) { _CbtipodoctoNombre = value; OnPropertyChanged(); } } }

        private string? _CbformapagoClave;
        [XmlAttribute]
        public string? CbformapagoClave { get => _CbformapagoClave; set { if (RaiseAcceptPendingChange(value, _CbformapagoClave)) { _CbformapagoClave = value; OnPropertyChanged(); } } }

        private string? _CbformapagoNombre;
        [XmlAttribute]
        public string? CbformapagoNombre { get => _CbformapagoNombre; set { if (RaiseAcceptPendingChange(value, _CbformapagoNombre)) { _CbformapagoNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }



    }

    
     
}

