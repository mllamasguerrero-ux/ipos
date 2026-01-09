
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
    public class WFRecargaWFBindingModel : Validatable
    {

        public WFRecargaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Telefono;
        [XmlAttribute]
        public string? Telefono { get => _Telefono; set { if (RaiseAcceptPendingChange(value, _Telefono)) { _Telefono = value; OnPropertyChanged(); } } }

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

