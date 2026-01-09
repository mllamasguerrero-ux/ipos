
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
    public class WFExportarDatosParaInventarioWFBindingModel : Validatable
    {

        public WFExportarDatosParaInventarioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbcarpetaarchivos;
        [XmlAttribute]
        public string? Tbcarpetaarchivos { get => _Tbcarpetaarchivos; set { if (RaiseAcceptPendingChange(value, _Tbcarpetaarchivos)) { _Tbcarpetaarchivos = value; OnPropertyChanged(); } } }

        private string? _Tbprefijo;
        [XmlAttribute]
        public string? Tbprefijo { get => _Tbprefijo; set { if (RaiseAcceptPendingChange(value, _Tbprefijo)) { _Tbprefijo = value; OnPropertyChanged(); } } }

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

