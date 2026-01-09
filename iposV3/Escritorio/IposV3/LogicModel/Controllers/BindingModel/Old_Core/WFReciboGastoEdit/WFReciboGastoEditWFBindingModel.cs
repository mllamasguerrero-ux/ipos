
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
    public class WFReciboGastoEditWFBindingModel : Validatable
    {

        public WFReciboGastoEditWFBindingModel()
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

        private long? _Cbcajero;
        [XmlAttribute]
        public long? Cbcajero { get => _Cbcajero; set { if (RaiseAcceptPendingChange(value, _Cbcajero)) { _Cbcajero = value; OnPropertyChanged(); } } }

        private string? _Tbobservaciones;
        [XmlAttribute]
        public string? Tbobservaciones { get => _Tbobservaciones; set { if (RaiseAcceptPendingChange(value, _Tbobservaciones)) { _Tbobservaciones = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private long? _Cborigenfiscal;
        [XmlAttribute]
        public long? Cborigenfiscal { get => _Cborigenfiscal; set { if (RaiseAcceptPendingChange(value, _Cborigenfiscal)) { _Cborigenfiscal = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcorteactual;
        [XmlAttribute]
        public BoolCN? Cbcorteactual { get => _Cbcorteactual; set { if (RaiseAcceptPendingChange(value, _Cbcorteactual)) { _Cbcorteactual = value; OnPropertyChanged(); } } }

        private string? _CbcajeroClave;
        [XmlAttribute]
        public string? CbcajeroClave { get => _CbcajeroClave; set { if (RaiseAcceptPendingChange(value, _CbcajeroClave)) { _CbcajeroClave = value; OnPropertyChanged(); } } }

        private string? _CbcajeroNombre;
        [XmlAttribute]
        public string? CbcajeroNombre { get => _CbcajeroNombre; set { if (RaiseAcceptPendingChange(value, _CbcajeroNombre)) { _CbcajeroNombre = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalClave;
        [XmlAttribute]
        public string? CborigenfiscalClave { get => _CborigenfiscalClave; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalClave)) { _CborigenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalNombre;
        [XmlAttribute]
        public string? CborigenfiscalNombre { get => _CborigenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalNombre)) { _CborigenfiscalNombre = value; OnPropertyChanged(); } } }

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
    public class WFReciboGastoEditWF_GridpvgastoBindingModel : Validatable
    {

        public WFReciboGastoEditWF_GridpvgastoBindingModel()
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

