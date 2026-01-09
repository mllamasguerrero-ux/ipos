
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
    public class WFPreguntaPrecioWFBindingModel : Validatable
    {

        public WFPreguntaPrecioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Ntprecio;
        [XmlAttribute]
        public decimal? Ntprecio { get => _Ntprecio; set { if (RaiseAcceptPendingChange(value, _Ntprecio)) { _Ntprecio = value; OnPropertyChanged(); } } }

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

