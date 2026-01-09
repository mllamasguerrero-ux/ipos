
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
    public class WFPreguntaConfirmacionWFBindingModel : Validatable
    {

        public WFPreguntaConfirmacionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Confirmacion;
        [XmlAttribute]
        public string? Confirmacion { get => _Confirmacion; set { if (RaiseAcceptPendingChange(value, _Confirmacion)) { _Confirmacion = value; OnPropertyChanged(); } } }

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

