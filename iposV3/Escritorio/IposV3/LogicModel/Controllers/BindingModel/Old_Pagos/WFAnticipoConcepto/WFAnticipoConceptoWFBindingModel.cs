
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
    public class WFAnticipoConceptoWFBindingModel : Validatable
    {

        public WFAnticipoConceptoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Textbox1;
        [XmlAttribute]
        public string? Textbox1 { get => _Textbox1; set { if (RaiseAcceptPendingChange(value, _Textbox1)) { _Textbox1 = value; OnPropertyChanged(); } } }

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

