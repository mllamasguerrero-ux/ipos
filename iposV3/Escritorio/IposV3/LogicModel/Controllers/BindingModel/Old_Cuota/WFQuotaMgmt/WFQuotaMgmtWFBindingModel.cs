
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
    public class WFQuotaMgmtWFBindingModel : Validatable
    {

        public WFQuotaMgmtWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Quotames1;
        [XmlAttribute]
        public decimal? Quotames1 { get => _Quotames1; set { if (RaiseAcceptPendingChange(value, _Quotames1)) { _Quotames1 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames2;
        [XmlAttribute]
        public decimal? Quotames2 { get => _Quotames2; set { if (RaiseAcceptPendingChange(value, _Quotames2)) { _Quotames2 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames3;
        [XmlAttribute]
        public decimal? Quotames3 { get => _Quotames3; set { if (RaiseAcceptPendingChange(value, _Quotames3)) { _Quotames3 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames4;
        [XmlAttribute]
        public decimal? Quotames4 { get => _Quotames4; set { if (RaiseAcceptPendingChange(value, _Quotames4)) { _Quotames4 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames5;
        [XmlAttribute]
        public decimal? Quotames5 { get => _Quotames5; set { if (RaiseAcceptPendingChange(value, _Quotames5)) { _Quotames5 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames6;
        [XmlAttribute]
        public decimal? Quotames6 { get => _Quotames6; set { if (RaiseAcceptPendingChange(value, _Quotames6)) { _Quotames6 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames7;
        [XmlAttribute]
        public decimal? Quotames7 { get => _Quotames7; set { if (RaiseAcceptPendingChange(value, _Quotames7)) { _Quotames7 = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private decimal? _Quotames8;
        [XmlAttribute]
        public decimal? Quotames8 { get => _Quotames8; set { if (RaiseAcceptPendingChange(value, _Quotames8)) { _Quotames8 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames9;
        [XmlAttribute]
        public decimal? Quotames9 { get => _Quotames9; set { if (RaiseAcceptPendingChange(value, _Quotames9)) { _Quotames9 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames10;
        [XmlAttribute]
        public decimal? Quotames10 { get => _Quotames10; set { if (RaiseAcceptPendingChange(value, _Quotames10)) { _Quotames10 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames11;
        [XmlAttribute]
        public decimal? Quotames11 { get => _Quotames11; set { if (RaiseAcceptPendingChange(value, _Quotames11)) { _Quotames11 = value; OnPropertyChanged(); } } }

        private decimal? _Quotames12;
        [XmlAttribute]
        public decimal? Quotames12 { get => _Quotames12; set { if (RaiseAcceptPendingChange(value, _Quotames12)) { _Quotames12 = value; OnPropertyChanged(); } } }

        private int? _Anio;
        [XmlAttribute]
        public int? Anio { get => _Anio; set { if (RaiseAcceptPendingChange(value, _Anio)) { _Anio = value; OnPropertyChanged(); } } }

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

