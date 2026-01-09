
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
    public class WFPreguntaCorreoWFBindingModel : Validatable
    {

        public WFPreguntaCorreoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbmail;
        [XmlAttribute]
        public string? Tbmail { get => _Tbmail; set { if (RaiseAcceptPendingChange(value, _Tbmail)) { _Tbmail = value; OnPropertyChanged(); } } }

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

