
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
    public class WFRetiroCajaWFBindingModel : Validatable
    {

        public WFRetiroCajaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private decimal? _Tbchequesimporte;
        [XmlAttribute]
        public decimal? Tbchequesimporte { get => _Tbchequesimporte; set { if (RaiseAcceptPendingChange(value, _Tbchequesimporte)) { _Tbchequesimporte = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcorteactual;
        [XmlAttribute]
        public BoolCN? Cbcorteactual { get => _Cbcorteactual; set { if (RaiseAcceptPendingChange(value, _Cbcorteactual)) { _Cbcorteactual = value; OnPropertyChanged(); } } }

        private string? _Tbobservaciones;
        [XmlAttribute]
        public string? Tbobservaciones { get => _Tbobservaciones; set { if (RaiseAcceptPendingChange(value, _Tbobservaciones)) { _Tbobservaciones = value; OnPropertyChanged(); } } }

        private decimal? _Tbvalesimporte;
        [XmlAttribute]
        public decimal? Tbvalesimporte { get => _Tbvalesimporte; set { if (RaiseAcceptPendingChange(value, _Tbvalesimporte)) { _Tbvalesimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbsumaefectivo;
        [XmlAttribute]
        public decimal? Tbsumaefectivo { get => _Tbsumaefectivo; set { if (RaiseAcceptPendingChange(value, _Tbsumaefectivo)) { _Tbsumaefectivo = value; OnPropertyChanged(); } } }

        private long? _Cbcajero;
        [XmlAttribute]
        public long? Cbcajero { get => _Cbcajero; set { if (RaiseAcceptPendingChange(value, _Cbcajero)) { _Cbcajero = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar50;
        [XmlAttribute]
        public int? Tbcantdolar50 { get => _Tbcantdolar50; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar50)) { _Tbcantdolar50 = value; OnPropertyChanged(); } } }

        private int? _Tbcantpesos200;
        [XmlAttribute]
        public int? Tbcantpesos200 { get => _Tbcantpesos200; set { if (RaiseAcceptPendingChange(value, _Tbcantpesos200)) { _Tbcantpesos200 = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar20;
        [XmlAttribute]
        public int? Tbcantdolar20 { get => _Tbcantdolar20; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar20)) { _Tbcantdolar20 = value; OnPropertyChanged(); } } }

        private decimal? _Tbtipocambio;
        [XmlAttribute]
        public decimal? Tbtipocambio { get => _Tbtipocambio; set { if (RaiseAcceptPendingChange(value, _Tbtipocambio)) { _Tbtipocambio = value; OnPropertyChanged(); } } }

        private int? _Tbcantpesos100;
        [XmlAttribute]
        public int? Tbcantpesos100 { get => _Tbcantpesos100; set { if (RaiseAcceptPendingChange(value, _Tbcantpesos100)) { _Tbcantpesos100 = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar10;
        [XmlAttribute]
        public int? Tbcantdolar10 { get => _Tbcantdolar10; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar10)) { _Tbcantdolar10 = value; OnPropertyChanged(); } } }

        private int? _Tbcantpesos50;
        [XmlAttribute]
        public int? Tbcantpesos50 { get => _Tbcantpesos50; set { if (RaiseAcceptPendingChange(value, _Tbcantpesos50)) { _Tbcantpesos50 = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar5;
        [XmlAttribute]
        public int? Tbcantdolar5 { get => _Tbcantdolar5; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar5)) { _Tbcantdolar5 = value; OnPropertyChanged(); } } }

        private int? _Tbcantpesos20;
        [XmlAttribute]
        public int? Tbcantpesos20 { get => _Tbcantpesos20; set { if (RaiseAcceptPendingChange(value, _Tbcantpesos20)) { _Tbcantpesos20 = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar2;
        [XmlAttribute]
        public int? Tbcantdolar2 { get => _Tbcantdolar2; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar2)) { _Tbcantdolar2 = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar1;
        [XmlAttribute]
        public int? Tbcantdolar1 { get => _Tbcantdolar1; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar1)) { _Tbcantdolar1 = value; OnPropertyChanged(); } } }

        private decimal? _Tbimportepesosmorralla;
        [XmlAttribute]
        public decimal? Tbimportepesosmorralla { get => _Tbimportepesosmorralla; set { if (RaiseAcceptPendingChange(value, _Tbimportepesosmorralla)) { _Tbimportepesosmorralla = value; OnPropertyChanged(); } } }

        private decimal? _Tbimportedolaresmorralla;
        [XmlAttribute]
        public decimal? Tbimportedolaresmorralla { get => _Tbimportedolaresmorralla; set { if (RaiseAcceptPendingChange(value, _Tbimportedolaresmorralla)) { _Tbimportedolaresmorralla = value; OnPropertyChanged(); } } }

        private int? _Tbcantpesos1000;
        [XmlAttribute]
        public int? Tbcantpesos1000 { get => _Tbcantpesos1000; set { if (RaiseAcceptPendingChange(value, _Tbcantpesos1000)) { _Tbcantpesos1000 = value; OnPropertyChanged(); } } }

        private int? _Tbcantdolar100;
        [XmlAttribute]
        public int? Tbcantdolar100 { get => _Tbcantdolar100; set { if (RaiseAcceptPendingChange(value, _Tbcantdolar100)) { _Tbcantdolar100 = value; OnPropertyChanged(); } } }

        private int? _Tbcantpesos500;
        [XmlAttribute]
        public int? Tbcantpesos500 { get => _Tbcantpesos500; set { if (RaiseAcceptPendingChange(value, _Tbcantpesos500)) { _Tbcantpesos500 = value; OnPropertyChanged(); } } }

        private string? _CbcajeroClave;
        [XmlAttribute]
        public string? CbcajeroClave { get => _CbcajeroClave; set { if (RaiseAcceptPendingChange(value, _CbcajeroClave)) { _CbcajeroClave = value; OnPropertyChanged(); } } }

        private string? _CbcajeroNombre;
        [XmlAttribute]
        public string? CbcajeroNombre { get => _CbcajeroNombre; set { if (RaiseAcceptPendingChange(value, _CbcajeroNombre)) { _CbcajeroNombre = value; OnPropertyChanged(); } } }

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

