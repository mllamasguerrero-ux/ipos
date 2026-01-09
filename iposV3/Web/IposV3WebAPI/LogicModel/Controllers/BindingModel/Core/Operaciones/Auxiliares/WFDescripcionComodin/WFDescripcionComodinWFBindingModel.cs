
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
    public class WFDescripcionComodinWFBindingModel : Validatable
    {

        public WFDescripcionComodinWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbdesc1;
        [XmlAttribute]
        public string? Tbdesc1 { get => _Tbdesc1; set { if (RaiseAcceptPendingChange(value, _Tbdesc1)) { _Tbdesc1 = value; OnPropertyChanged(); } } }

        private string? _Tbdesc2;
        [XmlAttribute]
        public string? Tbdesc2 { get => _Tbdesc2; set { if (RaiseAcceptPendingChange(value, _Tbdesc2)) { _Tbdesc2 = value; OnPropertyChanged(); } } }

        private string? _Tbdesc3;
        [XmlAttribute]
        public string? Tbdesc3 { get => _Tbdesc3; set { if (RaiseAcceptPendingChange(value, _Tbdesc3)) { _Tbdesc3 = value; OnPropertyChanged(); } } }

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

