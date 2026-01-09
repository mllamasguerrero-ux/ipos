
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
    public class WFPasswordSupervisorWFBindingModel : Validatable
    {

        public WFPasswordSupervisorWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbpassword;
        [XmlAttribute]
        public string? Tbpassword { get => _Tbpassword; set { if (RaiseAcceptPendingChange(value, _Tbpassword)) { _Tbpassword = value; OnPropertyChanged(); } } }

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

