
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
    public class WFPreguntaAutorizacionWFBindingModel : Validatable
    {

        public WFPreguntaAutorizacionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbnameuser;
        [XmlAttribute]
        public string? Tbnameuser { get => _Tbnameuser; set { if (RaiseAcceptPendingChange(value, _Tbnameuser)) { _Tbnameuser = value; OnPropertyChanged(); } } }

        private string? _Tbpassuser;
        [XmlAttribute]
        public string? Tbpassuser { get => _Tbpassuser; set { if (RaiseAcceptPendingChange(value, _Tbpassuser)) { _Tbpassuser = value; OnPropertyChanged(); } } }

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

