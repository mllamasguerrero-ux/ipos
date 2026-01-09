
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
    public class WFReimprimirFacturaElectronicaWFBindingModel : Validatable
    {

        public WFReimprimirFacturaElectronicaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

        private long? _Cbtipotran;
        [XmlAttribute]
        public long? Cbtipotran { get => _Cbtipotran; set { if (RaiseAcceptPendingChange(value, _Cbtipotran)) { _Cbtipotran = value; OnPropertyChanged(); } } }

        private string? _Tbfoliosat;
        [XmlAttribute]
        public string? Tbfoliosat { get => _Tbfoliosat; set { if (RaiseAcceptPendingChange(value, _Tbfoliosat)) { _Tbfoliosat = value; OnPropertyChanged(); } } }

        private string? _Tbseriesat;
        [XmlAttribute]
        public string? Tbseriesat { get => _Tbseriesat; set { if (RaiseAcceptPendingChange(value, _Tbseriesat)) { _Tbseriesat = value; OnPropertyChanged(); } } }

        private string? _CbtipotranClave;
        [XmlAttribute]
        public string? CbtipotranClave { get => _CbtipotranClave; set { if (RaiseAcceptPendingChange(value, _CbtipotranClave)) { _CbtipotranClave = value; OnPropertyChanged(); } } }

        private string? _CbtipotranNombre;
        [XmlAttribute]
        public string? CbtipotranNombre { get => _CbtipotranNombre; set { if (RaiseAcceptPendingChange(value, _CbtipotranNombre)) { _CbtipotranNombre = value; OnPropertyChanged(); } } }

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

