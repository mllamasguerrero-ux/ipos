
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
    public class WFReasignarTotalesSinValeWFBindingModel : Validatable
    {

        public WFReasignarTotalesSinValeWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Datetimepicker2;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker2 { get => _Datetimepicker2; set { if (RaiseAcceptPendingChange(value, _Datetimepicker2)) { _Datetimepicker2 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

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

