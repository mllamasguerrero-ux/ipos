
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
    public class WFCambioVenceTransWFBindingModel : Validatable
    {

        public WFCambioVenceTransWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private int? _Diasplazo;
        [XmlAttribute]
        public int? Diasplazo { get => _Diasplazo; set { if (RaiseAcceptPendingChange(value, _Diasplazo)) { _Diasplazo = value; OnPropertyChanged(); } } }

        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechavence;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechavence { get => _Dtpfechavence; set { if (RaiseAcceptPendingChange(value, _Dtpfechavence)) { _Dtpfechavence = value; OnPropertyChanged(); } } }

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

