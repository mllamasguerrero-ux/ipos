
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
    public class WFCambiarTASAIVAWFBindingModel : Validatable
    {

        public WFCambiarTASAIVAWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Tbtasaiva;
        [XmlAttribute]
        public decimal? Tbtasaiva { get => _Tbtasaiva; set { if (RaiseAcceptPendingChange(value, _Tbtasaiva)) { _Tbtasaiva = value; OnPropertyChanged(); } } }

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

