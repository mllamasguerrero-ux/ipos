
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
    public class WFImpresionInventarioWFBindingModel : Validatable
    {

        public WFImpresionInventarioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbletrafinal;
        [XmlAttribute]
        public long? Cbletrafinal { get => _Cbletrafinal; set { if (RaiseAcceptPendingChange(value, _Cbletrafinal)) { _Cbletrafinal = value; OnPropertyChanged(); } } }

        private long? _Cbletrainicial;
        [XmlAttribute]
        public long? Cbletrainicial { get => _Cbletrainicial; set { if (RaiseAcceptPendingChange(value, _Cbletrainicial)) { _Cbletrainicial = value; OnPropertyChanged(); } } }

        private long? _Cboption;
        [XmlAttribute]
        public long? Cboption { get => _Cboption; set { if (RaiseAcceptPendingChange(value, _Cboption)) { _Cboption = value; OnPropertyChanged(); } } }

        private string? _CbletrafinalClave;
        [XmlAttribute]
        public string? CbletrafinalClave { get => _CbletrafinalClave; set { if (RaiseAcceptPendingChange(value, _CbletrafinalClave)) { _CbletrafinalClave = value; OnPropertyChanged(); } } }

        private string? _CbletrafinalNombre;
        [XmlAttribute]
        public string? CbletrafinalNombre { get => _CbletrafinalNombre; set { if (RaiseAcceptPendingChange(value, _CbletrafinalNombre)) { _CbletrafinalNombre = value; OnPropertyChanged(); } } }

        private string? _CbletrainicialClave;
        [XmlAttribute]
        public string? CbletrainicialClave { get => _CbletrainicialClave; set { if (RaiseAcceptPendingChange(value, _CbletrainicialClave)) { _CbletrainicialClave = value; OnPropertyChanged(); } } }

        private string? _CbletrainicialNombre;
        [XmlAttribute]
        public string? CbletrainicialNombre { get => _CbletrainicialNombre; set { if (RaiseAcceptPendingChange(value, _CbletrainicialNombre)) { _CbletrainicialNombre = value; OnPropertyChanged(); } } }

        private string? _CboptionClave;
        [XmlAttribute]
        public string? CboptionClave { get => _CboptionClave; set { if (RaiseAcceptPendingChange(value, _CboptionClave)) { _CboptionClave = value; OnPropertyChanged(); } } }

        private string? _CboptionNombre;
        [XmlAttribute]
        public string? CboptionNombre { get => _CboptionNombre; set { if (RaiseAcceptPendingChange(value, _CboptionNombre)) { _CboptionNombre = value; OnPropertyChanged(); } } }

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

