
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
    public class WFPreguntarClaveConfWFBindingModel : Validatable
    {

        public WFPreguntarClaveConfWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbclave;
        [XmlAttribute]
        public string? Tbclave { get => _Tbclave; set { if (RaiseAcceptPendingChange(value, _Tbclave)) { _Tbclave = value; OnPropertyChanged(); } } }

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

