
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
    public class FPasswordInicialWFBindingModel : Validatable
    {

        public FPasswordInicialWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Us_passwordconf;
        [XmlAttribute]
        public string? Us_passwordconf { get => _Us_passwordconf; set { if (RaiseAcceptPendingChange(value, _Us_passwordconf)) { _Us_passwordconf = value; OnPropertyChanged(); } } }

        private string? _Us_passwordant;
        [XmlAttribute]
        public string? Us_passwordant { get => _Us_passwordant; set { if (RaiseAcceptPendingChange(value, _Us_passwordant)) { _Us_passwordant = value; OnPropertyChanged(); } } }

        private string? _Us_password;
        [XmlAttribute]
        public string? Us_password { get => _Us_password; set { if (RaiseAcceptPendingChange(value, _Us_password)) { _Us_password = value; OnPropertyChanged(); } } }

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

