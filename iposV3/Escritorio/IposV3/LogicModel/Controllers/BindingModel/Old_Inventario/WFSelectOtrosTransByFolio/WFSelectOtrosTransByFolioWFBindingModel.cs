
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
    public class WFSelectOtrosTransByFolioWFBindingModel : Validatable
    {

        public WFSelectOtrosTransByFolioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

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

