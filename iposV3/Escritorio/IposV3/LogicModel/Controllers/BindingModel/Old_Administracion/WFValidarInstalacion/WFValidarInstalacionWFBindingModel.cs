
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
    public class WFValidarInstalacionWFBindingModel : Validatable
    {

        public WFValidarInstalacionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbpass;
        [XmlAttribute]
        public string? Tbpass { get => _Tbpass; set { if (RaiseAcceptPendingChange(value, _Tbpass)) { _Tbpass = value; OnPropertyChanged(); } } }

        private string? _Tbclavemaquina;
        [XmlAttribute]
        public string? Tbclavemaquina { get => _Tbclavemaquina; set { if (RaiseAcceptPendingChange(value, _Tbclavemaquina)) { _Tbclavemaquina = value; OnPropertyChanged(); } } }

        private string? _Tbclaveacceso;
        [XmlAttribute]
        public string? Tbclaveacceso { get => _Tbclaveacceso; set { if (RaiseAcceptPendingChange(value, _Tbclaveacceso)) { _Tbclaveacceso = value; OnPropertyChanged(); } } }

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

