
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
    public class CorteBilletesWFBindingModel : Validatable
    {

        public CorteBilletesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Tbchequesimporte;
        [XmlAttribute]
        public decimal? Tbchequesimporte { get => _Tbchequesimporte; set { if (RaiseAcceptPendingChange(value, _Tbchequesimporte)) { _Tbchequesimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbdepositoimporte;
        [XmlAttribute]
        public decimal? Tbdepositoimporte { get => _Tbdepositoimporte; set { if (RaiseAcceptPendingChange(value, _Tbdepositoimporte)) { _Tbdepositoimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbvalesimporte;
        [XmlAttribute]
        public decimal? Tbvalesimporte { get => _Tbvalesimporte; set { if (RaiseAcceptPendingChange(value, _Tbvalesimporte)) { _Tbvalesimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbdepterimporte;
        [XmlAttribute]
        public decimal? Tbdepterimporte { get => _Tbdepterimporte; set { if (RaiseAcceptPendingChange(value, _Tbdepterimporte)) { _Tbdepterimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbtarjetaimporte;
        [XmlAttribute]
        public decimal? Tbtarjetaimporte { get => _Tbtarjetaimporte; set { if (RaiseAcceptPendingChange(value, _Tbtarjetaimporte)) { _Tbtarjetaimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbindefinidoimporte;
        [XmlAttribute]
        public decimal? Tbindefinidoimporte { get => _Tbindefinidoimporte; set { if (RaiseAcceptPendingChange(value, _Tbindefinidoimporte)) { _Tbindefinidoimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbcreditoimporte;
        [XmlAttribute]
        public decimal? Tbcreditoimporte { get => _Tbcreditoimporte; set { if (RaiseAcceptPendingChange(value, _Tbcreditoimporte)) { _Tbcreditoimporte = value; OnPropertyChanged(); } } }

        private decimal? _Ntbfondofinal;
        [XmlAttribute]
        public decimal? Ntbfondofinal { get => _Ntbfondofinal; set { if (RaiseAcceptPendingChange(value, _Ntbfondofinal)) { _Ntbfondofinal = value; OnPropertyChanged(); } } }

        private decimal? _Tbmonederoimporte;
        [XmlAttribute]
        public decimal? Tbmonederoimporte { get => _Tbmonederoimporte; set { if (RaiseAcceptPendingChange(value, _Tbmonederoimporte)) { _Tbmonederoimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbtransferenciaimporte;
        [XmlAttribute]
        public decimal? Tbtransferenciaimporte { get => _Tbtransferenciaimporte; set { if (RaiseAcceptPendingChange(value, _Tbtransferenciaimporte)) { _Tbtransferenciaimporte = value; OnPropertyChanged(); } } }

        private decimal? _Tbretirosdecaja;
        [XmlAttribute]
        public decimal? Tbretirosdecaja { get => _Tbretirosdecaja; set { if (RaiseAcceptPendingChange(value, _Tbretirosdecaja)) { _Tbretirosdecaja = value; OnPropertyChanged(); } } }

        private decimal? _Tbtrasladosefectivo;
        [XmlAttribute]
        public decimal? Tbtrasladosefectivo { get => _Tbtrasladosefectivo; set { if (RaiseAcceptPendingChange(value, _Tbtrasladosefectivo)) { _Tbtrasladosefectivo = value; OnPropertyChanged(); } } }

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

