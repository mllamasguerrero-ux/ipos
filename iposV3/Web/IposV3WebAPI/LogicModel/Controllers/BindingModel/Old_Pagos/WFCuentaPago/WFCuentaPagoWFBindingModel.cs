
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
    public class WFCuentaPagoWFBindingModel : Validatable
    {

        public WFCuentaPagoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbcuentapago;
        [XmlAttribute]
        public string? Tbcuentapago { get => _Tbcuentapago; set { if (RaiseAcceptPendingChange(value, _Tbcuentapago)) { _Tbcuentapago = value; OnPropertyChanged(); } } }

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

