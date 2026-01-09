
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
    public class WFObtenerPuntosBancomerWFBindingModel : Validatable
    {

        public WFObtenerPuntosBancomerWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Txtpuntospesos;
        [XmlAttribute]
        public string? Txtpuntospesos { get => _Txtpuntospesos; set { if (RaiseAcceptPendingChange(value, _Txtpuntospesos)) { _Txtpuntospesos = value; OnPropertyChanged(); } } }

        private string? _Txtpuntosdisponibles;
        [XmlAttribute]
        public string? Txtpuntosdisponibles { get => _Txtpuntosdisponibles; set { if (RaiseAcceptPendingChange(value, _Txtpuntosdisponibles)) { _Txtpuntosdisponibles = value; OnPropertyChanged(); } } }

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

