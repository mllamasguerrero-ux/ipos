
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
    public class WFPagosReferenciasWFBindingModel : Validatable
    {

        public WFPagosReferenciasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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

    
    [XmlRoot]
    public class WFPagosReferenciasWF_PagosporreferenciaBindingModel : Validatable
    {

        public WFPagosReferenciasWF_PagosporreferenciaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Pagoid;
        [XmlAttribute]
        public long? Pagoid { get => _Pagoid; set { if (RaiseAcceptPendingChange(value, _Pagoid)) { _Pagoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechapago;
        [XmlAttribute]
        public DateTimeOffset? Fechapago { get => _Fechapago; set { if (RaiseAcceptPendingChange(value, _Fechapago)) { _Fechapago = value; OnPropertyChanged(); } } }

        private decimal? _Importerecibidopago;
        [XmlAttribute]
        public decimal? Importerecibidopago { get => _Importerecibidopago; set { if (RaiseAcceptPendingChange(value, _Importerecibidopago)) { _Importerecibidopago = value; OnPropertyChanged(); } } }

        private string? _Formapagonombre;
        [XmlAttribute]
        public string? Formapagonombre { get => _Formapagonombre; set { if (RaiseAcceptPendingChange(value, _Formapagonombre)) { _Formapagonombre = value; OnPropertyChanged(); } } }

        private string? _Revertido;
        [XmlAttribute]
        public string? Revertido { get => _Revertido; set { if (RaiseAcceptPendingChange(value, _Revertido)) { _Revertido = value; OnPropertyChanged(); } } }

        private string? _Referenciabancariapago;
        [XmlAttribute]
        public string? Referenciabancariapago { get => _Referenciabancariapago; set { if (RaiseAcceptPendingChange(value, _Referenciabancariapago)) { _Referenciabancariapago = value; OnPropertyChanged(); } } }

        private string? _Cajeronombrepago;
        [XmlAttribute]
        public string? Cajeronombrepago { get => _Cajeronombrepago; set { if (RaiseAcceptPendingChange(value, _Cajeronombrepago)) { _Cajeronombrepago = value; OnPropertyChanged(); } } }

        private string? _Tipodoctonombre;
        [XmlAttribute]
        public string? Tipodoctonombre { get => _Tipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Tipodoctonombre)) { _Tipodoctonombre = value; OnPropertyChanged(); } } }

        private string? _Personanombre;
        [XmlAttribute]
        public string? Personanombre { get => _Personanombre; set { if (RaiseAcceptPendingChange(value, _Personanombre)) { _Personanombre = value; OnPropertyChanged(); } } }

        private int? _Doctofolio;
        [XmlAttribute]
        public int? Doctofolio { get => _Doctofolio; set { if (RaiseAcceptPendingChange(value, _Doctofolio)) { _Doctofolio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Doctofecha;
        [XmlAttribute]
        public DateTimeOffset? Doctofecha { get => _Doctofecha; set { if (RaiseAcceptPendingChange(value, _Doctofecha)) { _Doctofecha = value; OnPropertyChanged(); } } }

        private decimal? _Doctototal;
        [XmlAttribute]
        public decimal? Doctototal { get => _Doctototal; set { if (RaiseAcceptPendingChange(value, _Doctototal)) { _Doctototal = value; OnPropertyChanged(); } } }

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

