
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
    public class WFReporteInventarioXLoteWFBindingModel : Validatable
    {

        public WFReporteInventarioXLoteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cmborden;
        [XmlAttribute]
        public long? Cmborden { get => _Cmborden; set { if (RaiseAcceptPendingChange(value, _Cmborden)) { _Cmborden = value; OnPropertyChanged(); } } }

        private string? _CmbordenClave;
        [XmlAttribute]
        public string? CmbordenClave { get => _CmbordenClave; set { if (RaiseAcceptPendingChange(value, _CmbordenClave)) { _CmbordenClave = value; OnPropertyChanged(); } } }

        private string? _CmbordenNombre;
        [XmlAttribute]
        public string? CmbordenNombre { get => _CmbordenNombre; set { if (RaiseAcceptPendingChange(value, _CmbordenNombre)) { _CmbordenNombre = value; OnPropertyChanged(); } } }

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

