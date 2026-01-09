
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
    public class CorteAbrirWFBindingModel : Validatable
    {

        public CorteAbrirWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Ntsaldoinicial;
        [XmlAttribute]
        public decimal? Ntsaldoinicial { get => _Ntsaldoinicial; set { if (RaiseAcceptPendingChange(value, _Ntsaldoinicial)) { _Ntsaldoinicial = value; OnPropertyChanged(); } } }

        private decimal? _Ntbfondoinicial;
        [XmlAttribute]
        public decimal? Ntbfondoinicial { get => _Ntbfondoinicial; set { if (RaiseAcceptPendingChange(value, _Ntbfondoinicial)) { _Ntbfondoinicial = value; OnPropertyChanged(); } } }

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

