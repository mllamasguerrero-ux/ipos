
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
    public class WFReferenciaPagoWFBindingModel : Validatable
    {

        public WFReferenciaPagoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

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

