
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
    public class CorteBilletesRazonCambioWFBindingModel : Validatable
    {

        public CorteBilletesRazonCambioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Textarearazon;
        [XmlAttribute]
        public string? Textarearazon { get => _Textarearazon; set { if (RaiseAcceptPendingChange(value, _Textarearazon)) { _Textarearazon = value; OnPropertyChanged(); } } }

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

