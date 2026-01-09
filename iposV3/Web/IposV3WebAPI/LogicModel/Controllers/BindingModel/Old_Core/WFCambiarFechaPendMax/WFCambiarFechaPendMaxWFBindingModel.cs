
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
    public class WFCambiarFechaPendMaxWFBindingModel : Validatable
    {

        public WFCambiarFechaPendMaxWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechapendmax;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechapendmax { get => _Dtpfechapendmax; set { if (RaiseAcceptPendingChange(value, _Dtpfechapendmax)) { _Dtpfechapendmax = value; OnPropertyChanged(); } } }

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

