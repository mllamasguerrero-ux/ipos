
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
    public class WFCancelacionDocumentosWFBindingModel : Validatable
    {

        public WFCancelacionDocumentosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbfoliosat;
        [XmlAttribute]
        public string? Tbfoliosat { get => _Tbfoliosat; set { if (RaiseAcceptPendingChange(value, _Tbfoliosat)) { _Tbfoliosat = value; OnPropertyChanged(); } } }

        private string? _Tbseriesat;
        [XmlAttribute]
        public string? Tbseriesat { get => _Tbseriesat; set { if (RaiseAcceptPendingChange(value, _Tbseriesat)) { _Tbseriesat = value; OnPropertyChanged(); } } }

        private long? _Cbtipodocumento;
        [XmlAttribute]
        public long? Cbtipodocumento { get => _Cbtipodocumento; set { if (RaiseAcceptPendingChange(value, _Cbtipodocumento)) { _Cbtipodocumento = value; OnPropertyChanged(); } } }

        private string? _Tbfoliodocumento;
        [XmlAttribute]
        public string? Tbfoliodocumento { get => _Tbfoliodocumento; set { if (RaiseAcceptPendingChange(value, _Tbfoliodocumento)) { _Tbfoliodocumento = value; OnPropertyChanged(); } } }

        private string? _CbtipodocumentoClave;
        [XmlAttribute]
        public string? CbtipodocumentoClave { get => _CbtipodocumentoClave; set { if (RaiseAcceptPendingChange(value, _CbtipodocumentoClave)) { _CbtipodocumentoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipodocumentoNombre;
        [XmlAttribute]
        public string? CbtipodocumentoNombre { get => _CbtipodocumentoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipodocumentoNombre)) { _CbtipodocumentoNombre = value; OnPropertyChanged(); } } }

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

