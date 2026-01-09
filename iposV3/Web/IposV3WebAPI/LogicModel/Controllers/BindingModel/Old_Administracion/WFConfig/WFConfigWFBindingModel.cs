
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
    public class WFConfigWFBindingModel : Validatable
    {

        public WFConfigWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbpassword;
        [XmlAttribute]
        public string? Tbpassword { get => _Tbpassword; set { if (RaiseAcceptPendingChange(value, _Tbpassword)) { _Tbpassword = value; OnPropertyChanged(); } } }

        private string? _Tbservidor;
        [XmlAttribute]
        public string? Tbservidor { get => _Tbservidor; set { if (RaiseAcceptPendingChange(value, _Tbservidor)) { _Tbservidor = value; OnPropertyChanged(); } } }

        private string? _Tbbasedatos;
        [XmlAttribute]
        public string? Tbbasedatos { get => _Tbbasedatos; set { if (RaiseAcceptPendingChange(value, _Tbbasedatos)) { _Tbbasedatos = value; OnPropertyChanged(); } } }

        private string? _Tbusuario;
        [XmlAttribute]
        public string? Tbusuario { get => _Tbusuario; set { if (RaiseAcceptPendingChange(value, _Tbusuario)) { _Tbusuario = value; OnPropertyChanged(); } } }

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

