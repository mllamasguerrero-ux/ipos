
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
    public class WFReciboDepositoEditWFBindingModel : Validatable
    {

        public WFReciboDepositoEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbcajero;
        [XmlAttribute]
        public long? Cbcajero { get => _Cbcajero; set { if (RaiseAcceptPendingChange(value, _Cbcajero)) { _Cbcajero = value; OnPropertyChanged(); } } }

        private decimal? _Tbmonto;
        [XmlAttribute]
        public decimal? Tbmonto { get => _Tbmonto; set { if (RaiseAcceptPendingChange(value, _Tbmonto)) { _Tbmonto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcorteactual;
        [XmlAttribute]
        public BoolCN? Cbcorteactual { get => _Cbcorteactual; set { if (RaiseAcceptPendingChange(value, _Cbcorteactual)) { _Cbcorteactual = value; OnPropertyChanged(); } } }

        private string? _Tbnotas;
        [XmlAttribute]
        public string? Tbnotas { get => _Tbnotas; set { if (RaiseAcceptPendingChange(value, _Tbnotas)) { _Tbnotas = value; OnPropertyChanged(); } } }

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

