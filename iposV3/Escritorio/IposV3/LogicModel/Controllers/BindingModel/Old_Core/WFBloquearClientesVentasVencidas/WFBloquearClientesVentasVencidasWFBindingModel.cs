
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
    public class WFBloquearClientesVentasVencidasWFBindingModel : Validatable
    {

        public WFBloquearClientesVentasVencidasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Diasnumeric;
        [XmlAttribute]
        public int? Diasnumeric { get => _Diasnumeric; set { if (RaiseAcceptPendingChange(value, _Diasnumeric)) { _Diasnumeric = value; OnPropertyChanged(); } } }

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

