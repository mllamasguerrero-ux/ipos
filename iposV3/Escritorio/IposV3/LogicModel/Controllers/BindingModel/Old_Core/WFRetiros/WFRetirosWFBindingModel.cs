
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
    public class WFRetirosWFBindingModel : Validatable
    {

        public WFRetirosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtfecha { get => _Dtfecha; set { if (RaiseAcceptPendingChange(value, _Dtfecha)) { _Dtfecha = value; OnPropertyChanged(); } } }

        private long? _Combosupervisor;
        [XmlAttribute]
        public long? Combosupervisor { get => _Combosupervisor; set { if (RaiseAcceptPendingChange(value, _Combosupervisor)) { _Combosupervisor = value; OnPropertyChanged(); } } }

        private string? _Tbnotas;
        [XmlAttribute]
        public string? Tbnotas { get => _Tbnotas; set { if (RaiseAcceptPendingChange(value, _Tbnotas)) { _Tbnotas = value; OnPropertyChanged(); } } }

        private decimal? _Tbimporte;
        [XmlAttribute]
        public decimal? Tbimporte { get => _Tbimporte; set { if (RaiseAcceptPendingChange(value, _Tbimporte)) { _Tbimporte = value; OnPropertyChanged(); } } }

        private long? _Comboproveedor;
        [XmlAttribute]
        public long? Comboproveedor { get => _Comboproveedor; set { if (RaiseAcceptPendingChange(value, _Comboproveedor)) { _Comboproveedor = value; OnPropertyChanged(); } } }

        private string? _Tbfactura;
        [XmlAttribute]
        public string? Tbfactura { get => _Tbfactura; set { if (RaiseAcceptPendingChange(value, _Tbfactura)) { _Tbfactura = value; OnPropertyChanged(); } } }

        private string? _CombosupervisorClave;
        [XmlAttribute]
        public string? CombosupervisorClave { get => _CombosupervisorClave; set { if (RaiseAcceptPendingChange(value, _CombosupervisorClave)) { _CombosupervisorClave = value; OnPropertyChanged(); } } }

        private string? _CombosupervisorNombre;
        [XmlAttribute]
        public string? CombosupervisorNombre { get => _CombosupervisorNombre; set { if (RaiseAcceptPendingChange(value, _CombosupervisorNombre)) { _CombosupervisorNombre = value; OnPropertyChanged(); } } }

        private string? _ComboproveedorClave;
        [XmlAttribute]
        public string? ComboproveedorClave { get => _ComboproveedorClave; set { if (RaiseAcceptPendingChange(value, _ComboproveedorClave)) { _ComboproveedorClave = value; OnPropertyChanged(); } } }

        private string? _ComboproveedorNombre;
        [XmlAttribute]
        public string? ComboproveedorNombre { get => _ComboproveedorNombre; set { if (RaiseAcceptPendingChange(value, _ComboproveedorNombre)) { _ComboproveedorNombre = value; OnPropertyChanged(); } } }

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

