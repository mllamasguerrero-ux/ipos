
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
    public class WFNotaIncidenciaWFBindingModel : Validatable
    {

        public WFNotaIncidenciaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Nota;
        [XmlAttribute]
        public string? Nota { get => _Nota; set { if (RaiseAcceptPendingChange(value, _Nota)) { _Nota = value; OnPropertyChanged(); } } }

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

