
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
    public class WFMensajesNotificacionWFBindingModel : Validatable
    {

        public WFMensajesNotificacionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Txtmensjadminsinleer;
        [XmlAttribute]
        public string? Txtmensjadminsinleer { get => _Txtmensjadminsinleer; set { if (RaiseAcceptPendingChange(value, _Txtmensjadminsinleer)) { _Txtmensjadminsinleer = value; OnPropertyChanged(); } } }

        private string? _Txtmensjadminrestsinleer;
        [XmlAttribute]
        public string? Txtmensjadminrestsinleer { get => _Txtmensjadminrestsinleer; set { if (RaiseAcceptPendingChange(value, _Txtmensjadminrestsinleer)) { _Txtmensjadminrestsinleer = value; OnPropertyChanged(); } } }

        private string? _Txtmensjsinleer;
        [XmlAttribute]
        public string? Txtmensjsinleer { get => _Txtmensjsinleer; set { if (RaiseAcceptPendingChange(value, _Txtmensjsinleer)) { _Txtmensjsinleer = value; OnPropertyChanged(); } } }

        private string? _Txtmensjrestsinleer;
        [XmlAttribute]
        public string? Txtmensjrestsinleer { get => _Txtmensjrestsinleer; set { if (RaiseAcceptPendingChange(value, _Txtmensjrestsinleer)) { _Txtmensjrestsinleer = value; OnPropertyChanged(); } } }

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

