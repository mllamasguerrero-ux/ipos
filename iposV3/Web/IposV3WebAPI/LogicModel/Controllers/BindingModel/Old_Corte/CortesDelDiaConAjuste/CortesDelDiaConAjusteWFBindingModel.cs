
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
    public class CortesDelDiaConAjusteWFBindingModel : Validatable
    {

        public CortesDelDiaConAjusteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Impuestoconiva;
        [XmlAttribute]
        public decimal? Impuestoconiva { get => _Impuestoconiva; set { if (RaiseAcceptPendingChange(value, _Impuestoconiva)) { _Impuestoconiva = value; OnPropertyChanged(); } } }

        private decimal? _Impuestototales;
        [XmlAttribute]
        public decimal? Impuestototales { get => _Impuestototales; set { if (RaiseAcceptPendingChange(value, _Impuestototales)) { _Impuestototales = value; OnPropertyChanged(); } } }

        private decimal? _Totalconiva;
        [XmlAttribute]
        public decimal? Totalconiva { get => _Totalconiva; set { if (RaiseAcceptPendingChange(value, _Totalconiva)) { _Totalconiva = value; OnPropertyChanged(); } } }

        private decimal? _Totalsiniva;
        [XmlAttribute]
        public decimal? Totalsiniva { get => _Totalsiniva; set { if (RaiseAcceptPendingChange(value, _Totalsiniva)) { _Totalsiniva = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Porc_a_iva;
        [XmlAttribute]
        public decimal? Porc_a_iva { get => _Porc_a_iva; set { if (RaiseAcceptPendingChange(value, _Porc_a_iva)) { _Porc_a_iva = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private decimal? _Subtotalconivaajustado;
        [XmlAttribute]
        public decimal? Subtotalconivaajustado { get => _Subtotalconivaajustado; set { if (RaiseAcceptPendingChange(value, _Subtotalconivaajustado)) { _Subtotalconivaajustado = value; OnPropertyChanged(); } } }

        private decimal? _Subtotalsinivaajustado;
        [XmlAttribute]
        public decimal? Subtotalsinivaajustado { get => _Subtotalsinivaajustado; set { if (RaiseAcceptPendingChange(value, _Subtotalsinivaajustado)) { _Subtotalsinivaajustado = value; OnPropertyChanged(); } } }

        private decimal? _Subtotalesajustado;
        [XmlAttribute]
        public decimal? Subtotalesajustado { get => _Subtotalesajustado; set { if (RaiseAcceptPendingChange(value, _Subtotalesajustado)) { _Subtotalesajustado = value; OnPropertyChanged(); } } }

        private decimal? _Impuestoconivaajustado;
        [XmlAttribute]
        public decimal? Impuestoconivaajustado { get => _Impuestoconivaajustado; set { if (RaiseAcceptPendingChange(value, _Impuestoconivaajustado)) { _Impuestoconivaajustado = value; OnPropertyChanged(); } } }

        private decimal? _Impuestototalesajustado;
        [XmlAttribute]
        public decimal? Impuestototalesajustado { get => _Impuestototalesajustado; set { if (RaiseAcceptPendingChange(value, _Impuestototalesajustado)) { _Impuestototalesajustado = value; OnPropertyChanged(); } } }

        private decimal? _Totalconivaajustado;
        [XmlAttribute]
        public decimal? Totalconivaajustado { get => _Totalconivaajustado; set { if (RaiseAcceptPendingChange(value, _Totalconivaajustado)) { _Totalconivaajustado = value; OnPropertyChanged(); } } }

        private decimal? _Totalsinivaajustado;
        [XmlAttribute]
        public decimal? Totalsinivaajustado { get => _Totalsinivaajustado; set { if (RaiseAcceptPendingChange(value, _Totalsinivaajustado)) { _Totalsinivaajustado = value; OnPropertyChanged(); } } }

        private decimal? _Totalajustado;
        [XmlAttribute]
        public decimal? Totalajustado { get => _Totalajustado; set { if (RaiseAcceptPendingChange(value, _Totalajustado)) { _Totalajustado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtfecha { get => _Dtfecha; set { if (RaiseAcceptPendingChange(value, _Dtfecha)) { _Dtfecha = value; OnPropertyChanged(); } } }

        private decimal? _Subtotalconiva;
        [XmlAttribute]
        public decimal? Subtotalconiva { get => _Subtotalconiva; set { if (RaiseAcceptPendingChange(value, _Subtotalconiva)) { _Subtotalconiva = value; OnPropertyChanged(); } } }

        private decimal? _Subtotalsiniva;
        [XmlAttribute]
        public decimal? Subtotalsiniva { get => _Subtotalsiniva; set { if (RaiseAcceptPendingChange(value, _Subtotalsiniva)) { _Subtotalsiniva = value; OnPropertyChanged(); } } }

        private decimal? _Subtotales;
        [XmlAttribute]
        public decimal? Subtotales { get => _Subtotales; set { if (RaiseAcceptPendingChange(value, _Subtotales)) { _Subtotales = value; OnPropertyChanged(); } } }

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

