
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
    public class WFPreguntaValeWFBindingModel : Validatable
    {

        public WFPreguntaValeWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _NumeroVale;
        [XmlAttribute]
        public string? NumeroVale { get => _NumeroVale; set { if (RaiseAcceptPendingChange(value, _NumeroVale)) { _NumeroVale = value; OnPropertyChanged(); } } }

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

