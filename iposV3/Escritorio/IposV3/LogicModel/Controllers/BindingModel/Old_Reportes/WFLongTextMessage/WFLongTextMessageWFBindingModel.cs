
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
    public class WFLongTextMessageWFBindingModel : Validatable
    {

        public WFLongTextMessageWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Text1;
        [XmlAttribute]
        public string? Text1 { get => _Text1; set { if (RaiseAcceptPendingChange(value, _Text1)) { _Text1 = value; OnPropertyChanged(); } } }

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

