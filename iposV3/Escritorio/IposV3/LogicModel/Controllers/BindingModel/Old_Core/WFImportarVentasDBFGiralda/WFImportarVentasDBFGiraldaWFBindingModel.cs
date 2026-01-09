
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
    public class WFImportarVentasDBFGiraldaWFBindingModel : Validatable
    {

        public WFImportarVentasDBFGiraldaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbimpventasdetalle;
        [XmlAttribute]
        public string? Tbimpventasdetalle { get => _Tbimpventasdetalle; set { if (RaiseAcceptPendingChange(value, _Tbimpventasdetalle)) { _Tbimpventasdetalle = value; OnPropertyChanged(); } } }

        private string? _Tbimpdevolucionesheader;
        [XmlAttribute]
        public string? Tbimpdevolucionesheader { get => _Tbimpdevolucionesheader; set { if (RaiseAcceptPendingChange(value, _Tbimpdevolucionesheader)) { _Tbimpdevolucionesheader = value; OnPropertyChanged(); } } }

        private string? _Tbimpventasheader;
        [XmlAttribute]
        public string? Tbimpventasheader { get => _Tbimpventasheader; set { if (RaiseAcceptPendingChange(value, _Tbimpventasheader)) { _Tbimpventasheader = value; OnPropertyChanged(); } } }

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

