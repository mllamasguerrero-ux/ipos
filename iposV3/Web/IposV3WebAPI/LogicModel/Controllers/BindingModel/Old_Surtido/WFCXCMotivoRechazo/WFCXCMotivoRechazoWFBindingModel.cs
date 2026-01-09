
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
    public class WFCXCMotivoRechazoWFBindingModel : Validatable
    {

        public WFCXCMotivoRechazoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Motivo;
        [XmlAttribute]
        public string? Motivo { get => _Motivo; set { if (RaiseAcceptPendingChange(value, _Motivo)) { _Motivo = value; OnPropertyChanged(); } } }

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

