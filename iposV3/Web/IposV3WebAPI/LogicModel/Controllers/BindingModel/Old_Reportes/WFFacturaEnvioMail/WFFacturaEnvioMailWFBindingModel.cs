
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
    public class WFFacturaEnvioMailWFBindingModel : Validatable
    {

        public WFFacturaEnvioMailWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbbody;
        [XmlAttribute]
        public string? Tbbody { get => _Tbbody; set { if (RaiseAcceptPendingChange(value, _Tbbody)) { _Tbbody = value; OnPropertyChanged(); } } }

        private string? _Tbmail;
        [XmlAttribute]
        public string? Tbmail { get => _Tbmail; set { if (RaiseAcceptPendingChange(value, _Tbmail)) { _Tbmail = value; OnPropertyChanged(); } } }

        private long? _Cbmailto;
        [XmlAttribute]
        public long? Cbmailto { get => _Cbmailto; set { if (RaiseAcceptPendingChange(value, _Cbmailto)) { _Cbmailto = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodalistacombo;
        [XmlAttribute]
        public BoolCN? Cbtodalistacombo { get => _Cbtodalistacombo; set { if (RaiseAcceptPendingChange(value, _Cbtodalistacombo)) { _Cbtodalistacombo = value; OnPropertyChanged(); } } }

        private string? _CbmailtoClave;
        [XmlAttribute]
        public string? CbmailtoClave { get => _CbmailtoClave; set { if (RaiseAcceptPendingChange(value, _CbmailtoClave)) { _CbmailtoClave = value; OnPropertyChanged(); } } }

        private string? _CbmailtoNombre;
        [XmlAttribute]
        public string? CbmailtoNombre { get => _CbmailtoNombre; set { if (RaiseAcceptPendingChange(value, _CbmailtoNombre)) { _CbmailtoNombre = value; OnPropertyChanged(); } } }

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

