
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
    public class WFNotaPagoWFBindingModel : Validatable
    {

        public WFNotaPagoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbnotapago;
        [XmlAttribute]
        public string? Tbnotapago { get => _Tbnotapago; set { if (RaiseAcceptPendingChange(value, _Tbnotapago)) { _Tbnotapago = value; OnPropertyChanged(); } } }

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

