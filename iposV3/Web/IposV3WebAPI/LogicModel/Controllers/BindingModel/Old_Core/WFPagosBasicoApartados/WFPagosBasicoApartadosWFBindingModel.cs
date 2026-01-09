
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
    public class WFPagosBasicoApartadosWFBindingModel : Validatable
    {

        public WFPagosBasicoApartadosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Ciudad;
        [XmlAttribute]
        public string? Ciudad { get => _Ciudad; set { if (RaiseAcceptPendingChange(value, _Ciudad)) { _Ciudad = value; OnPropertyChanged(); } } }

        private decimal? _Tbmontocheque;
        [XmlAttribute]
        public decimal? Tbmontocheque { get => _Tbmontocheque; set { if (RaiseAcceptPendingChange(value, _Tbmontocheque)) { _Tbmontocheque = value; OnPropertyChanged(); } } }

        private decimal? _Tbmontovale;
        [XmlAttribute]
        public decimal? Tbmontovale { get => _Tbmontovale; set { if (RaiseAcceptPendingChange(value, _Tbmontovale)) { _Tbmontovale = value; OnPropertyChanged(); } } }

        private string? _Celular;
        [XmlAttribute]
        public string? Celular { get => _Celular; set { if (RaiseAcceptPendingChange(value, _Celular)) { _Celular = value; OnPropertyChanged(); } } }

        private string? _Telefono1;
        [XmlAttribute]
        public string? Telefono1 { get => _Telefono1; set { if (RaiseAcceptPendingChange(value, _Telefono1)) { _Telefono1 = value; OnPropertyChanged(); } } }

        private string? _Tbcambio;
        [XmlAttribute]
        public string? Tbcambio { get => _Tbcambio; set { if (RaiseAcceptPendingChange(value, _Tbcambio)) { _Tbcambio = value; OnPropertyChanged(); } } }

        private string? _Email1;
        [XmlAttribute]
        public string? Email1 { get => _Email1; set { if (RaiseAcceptPendingChange(value, _Email1)) { _Email1 = value; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private string? _Tbpagostotalventa;
        [XmlAttribute]
        public string? Tbpagostotalventa { get => _Tbpagostotalventa; set { if (RaiseAcceptPendingChange(value, _Tbpagostotalventa)) { _Tbpagostotalventa = value; OnPropertyChanged(); } } }

        private string? _Domicilio;
        [XmlAttribute]
        public string? Domicilio { get => _Domicilio; set { if (RaiseAcceptPendingChange(value, _Domicilio)) { _Domicilio = value; OnPropertyChanged(); } } }

        private long? _Cbtipotarjeta;
        [XmlAttribute]
        public long? Cbtipotarjeta { get => _Cbtipotarjeta; set { if (RaiseAcceptPendingChange(value, _Cbtipotarjeta)) { _Cbtipotarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Tbmontotarjeta;
        [XmlAttribute]
        public decimal? Tbmontotarjeta { get => _Tbmontotarjeta; set { if (RaiseAcceptPendingChange(value, _Tbmontotarjeta)) { _Tbmontotarjeta = value; OnPropertyChanged(); } } }

        private string? _CbtipotarjetaClave;
        [XmlAttribute]
        public string? CbtipotarjetaClave { get => _CbtipotarjetaClave; set { if (RaiseAcceptPendingChange(value, _CbtipotarjetaClave)) { _CbtipotarjetaClave = value; OnPropertyChanged(); } } }

        private string? _CbtipotarjetaNombre;
        [XmlAttribute]
        public string? CbtipotarjetaNombre { get => _CbtipotarjetaNombre; set { if (RaiseAcceptPendingChange(value, _CbtipotarjetaNombre)) { _CbtipotarjetaNombre = value; OnPropertyChanged(); } } }

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

