
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
    public class WFExportarListaPrecioDesdeExcelWFBindingModel : Validatable
    {

        public WFExportarListaPrecioDesdeExcelWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbprecioconimpuesto;
        [XmlAttribute]
        public BoolCN? Cbprecioconimpuesto { get => _Cbprecioconimpuesto; set { if (RaiseAcceptPendingChange(value, _Cbprecioconimpuesto)) { _Cbprecioconimpuesto = value; OnPropertyChanged(); } } }

        private string? _Tbimpcatalogos;
        [XmlAttribute]
        public string? Tbimpcatalogos { get => _Tbimpcatalogos; set { if (RaiseAcceptPendingChange(value, _Tbimpcatalogos)) { _Tbimpcatalogos = value; OnPropertyChanged(); } } }

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

