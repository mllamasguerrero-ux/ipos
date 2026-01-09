
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
    public class WFReciboGastosAdicEditWFBindingModel : Validatable
    {

        public WFReciboGastosAdicEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Tbmonto;
        [XmlAttribute]
        public decimal? Tbmonto { get => _Tbmonto; set { if (RaiseAcceptPendingChange(value, _Tbmonto)) { _Tbmonto = value; OnPropertyChanged(); } } }

        private long? _Gastoid;
        [XmlAttribute]
        public long? Gastoid { get => _Gastoid; set { if (RaiseAcceptPendingChange(value, _Gastoid)) { _Gastoid = value; OnPropertyChanged(); } } }

        private string? _GastoidClave;
        [XmlAttribute]
        public string? GastoidClave { get => _GastoidClave; set { if (RaiseAcceptPendingChange(value, _GastoidClave)) { _GastoidClave = value; OnPropertyChanged(); } } }

        private string? _GastoidNombre;
        [XmlAttribute]
        public string? GastoidNombre { get => _GastoidNombre; set { if (RaiseAcceptPendingChange(value, _GastoidNombre)) { _GastoidNombre = value; OnPropertyChanged(); } } }

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
    public class WFReciboGastosAdicEditWF_GridpvgastoBindingModel : Validatable
    {

        public WFReciboGastosAdicEditWF_GridpvgastoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Partida;
        [XmlAttribute]
        public int? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        private long? _Gastoid;
        [XmlAttribute]
        public long? Gastoid { get => _Gastoid; set { if (RaiseAcceptPendingChange(value, _Gastoid)) { _Gastoid = value; OnPropertyChanged(); } } }

        private string? _Gastoclave;
        [XmlAttribute]
        public string? Gastoclave { get => _Gastoclave; set { if (RaiseAcceptPendingChange(value, _Gastoclave)) { _Gastoclave = value; OnPropertyChanged(); } } }

        private string? _Gastonombre;
        [XmlAttribute]
        public string? Gastonombre { get => _Gastonombre; set { if (RaiseAcceptPendingChange(value, _Gastonombre)) { _Gastonombre = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

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

