
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
    public class WFInventarioInicialWFBindingModel : Validatable
    {

        public WFInventarioInicialWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbinvinicial;
        [XmlAttribute]
        public string? Tbinvinicial { get => _Tbinvinicial; set { if (RaiseAcceptPendingChange(value, _Tbinvinicial)) { _Tbinvinicial = value; OnPropertyChanged(); } } }

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

