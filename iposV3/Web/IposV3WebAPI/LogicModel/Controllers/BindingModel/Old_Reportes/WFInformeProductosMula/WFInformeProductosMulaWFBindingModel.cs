
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
    public class WFInformeProductosMulaWFBindingModel : Validatable
    {

        public WFInformeProductosMulaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Numericupdown1;
        [XmlAttribute]
        public int? Numericupdown1 { get => _Numericupdown1; set { if (RaiseAcceptPendingChange(value, _Numericupdown1)) { _Numericupdown1 = value; OnPropertyChanged(); } } }

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

