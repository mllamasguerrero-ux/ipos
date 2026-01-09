
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
    public class WFReimpresionTicketsWFBindingModel : Validatable
    {

        public WFReimpresionTicketsWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbtipocorte;
        [XmlAttribute]
        public long? Cbtipocorte { get => _Cbtipocorte; set { if (RaiseAcceptPendingChange(value, _Cbtipocorte)) { _Cbtipocorte = value; OnPropertyChanged(); } } }

        private long? _Cbcajero;
        [XmlAttribute]
        public long? Cbcajero { get => _Cbcajero; set { if (RaiseAcceptPendingChange(value, _Cbcajero)) { _Cbcajero = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpcorte;
        [XmlAttribute]
        public DateTimeOffset? Dtpcorte { get => _Dtpcorte; set { if (RaiseAcceptPendingChange(value, _Dtpcorte)) { _Dtpcorte = value; OnPropertyChanged(); } } }

        private long? _Cbtipotran;
        [XmlAttribute]
        public long? Cbtipotran { get => _Cbtipotran; set { if (RaiseAcceptPendingChange(value, _Cbtipotran)) { _Cbtipotran = value; OnPropertyChanged(); } } }

        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

        private string? _CbtipocorteClave;
        [XmlAttribute]
        public string? CbtipocorteClave { get => _CbtipocorteClave; set { if (RaiseAcceptPendingChange(value, _CbtipocorteClave)) { _CbtipocorteClave = value; OnPropertyChanged(); } } }

        private string? _CbtipocorteNombre;
        [XmlAttribute]
        public string? CbtipocorteNombre { get => _CbtipocorteNombre; set { if (RaiseAcceptPendingChange(value, _CbtipocorteNombre)) { _CbtipocorteNombre = value; OnPropertyChanged(); } } }

        private string? _CbcajeroClave;
        [XmlAttribute]
        public string? CbcajeroClave { get => _CbcajeroClave; set { if (RaiseAcceptPendingChange(value, _CbcajeroClave)) { _CbcajeroClave = value; OnPropertyChanged(); } } }

        private string? _CbcajeroNombre;
        [XmlAttribute]
        public string? CbcajeroNombre { get => _CbcajeroNombre; set { if (RaiseAcceptPendingChange(value, _CbcajeroNombre)) { _CbcajeroNombre = value; OnPropertyChanged(); } } }

        private string? _CbtipotranClave;
        [XmlAttribute]
        public string? CbtipotranClave { get => _CbtipotranClave; set { if (RaiseAcceptPendingChange(value, _CbtipotranClave)) { _CbtipotranClave = value; OnPropertyChanged(); } } }

        private string? _CbtipotranNombre;
        [XmlAttribute]
        public string? CbtipotranNombre { get => _CbtipotranNombre; set { if (RaiseAcceptPendingChange(value, _CbtipotranNombre)) { _CbtipotranNombre = value; OnPropertyChanged(); } } }

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

