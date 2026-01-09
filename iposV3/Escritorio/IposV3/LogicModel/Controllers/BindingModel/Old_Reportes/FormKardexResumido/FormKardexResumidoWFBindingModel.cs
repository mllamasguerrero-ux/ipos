
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
    public class FormKardexResumidoWFBindingModel : Validatable
    {

        public FormKardexResumidoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private string? _Tbproductoinicial;
        [XmlAttribute]
        public string? Tbproductoinicial { get => _Tbproductoinicial; set { if (RaiseAcceptPendingChange(value, _Tbproductoinicial)) { _Tbproductoinicial = value; OnPropertyChanged(); } } }

        private string? _Tbproductofinal;
        [XmlAttribute]
        public string? Tbproductofinal { get => _Tbproductofinal; set { if (RaiseAcceptPendingChange(value, _Tbproductofinal)) { _Tbproductofinal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

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
    public class FormKardexResumidoWF_Get_kardex_report_summaryBindingModel : Validatable
    {

        public FormKardexResumidoWF_Get_kardex_report_summaryBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadini;
        [XmlAttribute]
        public decimal? Cantidadini { get => _Cantidadini; set { if (RaiseAcceptPendingChange(value, _Cantidadini)) { _Cantidadini = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadentradas;
        [XmlAttribute]
        public decimal? Cantidadentradas { get => _Cantidadentradas; set { if (RaiseAcceptPendingChange(value, _Cantidadentradas)) { _Cantidadentradas = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadsalidas;
        [XmlAttribute]
        public decimal? Cantidadsalidas { get => _Cantidadsalidas; set { if (RaiseAcceptPendingChange(value, _Cantidadsalidas)) { _Cantidadsalidas = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfin;
        [XmlAttribute]
        public decimal? Cantidadfin { get => _Cantidadfin; set { if (RaiseAcceptPendingChange(value, _Cantidadfin)) { _Cantidadfin = value; OnPropertyChanged(); } } }

        private decimal? _Productoprecio;
        [XmlAttribute]
        public decimal? Productoprecio { get => _Productoprecio; set { if (RaiseAcceptPendingChange(value, _Productoprecio)) { _Productoprecio = value; OnPropertyChanged(); } } }

        private decimal? _Productocostorepo;
        [XmlAttribute]
        public decimal? Productocostorepo { get => _Productocostorepo; set { if (RaiseAcceptPendingChange(value, _Productocostorepo)) { _Productocostorepo = value; OnPropertyChanged(); } } }

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

