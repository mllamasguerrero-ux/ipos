
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
    public class WFEnvioMovilProcess_3WFBindingModel : Validatable
    {

        public WFEnvioMovilProcess_3WFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cborigenfiscal;
        [XmlAttribute]
        public long? Cborigenfiscal { get => _Cborigenfiscal; set { if (RaiseAcceptPendingChange(value, _Cborigenfiscal)) { _Cborigenfiscal = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbplazos;
        [XmlAttribute]
        public BoolCN? Cbplazos { get => _Cbplazos; set { if (RaiseAcceptPendingChange(value, _Cbplazos)) { _Cbplazos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcontrato;
        [XmlAttribute]
        public BoolCN? Cbcontrato { get => _Cbcontrato; set { if (RaiseAcceptPendingChange(value, _Cbcontrato)) { _Cbcontrato = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb0;
        [XmlAttribute]
        public BoolCN? Cb0 { get => _Cb0; set { if (RaiseAcceptPendingChange(value, _Cb0)) { _Cb0 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb1;
        [XmlAttribute]
        public BoolCN? Cb1 { get => _Cb1; set { if (RaiseAcceptPendingChange(value, _Cb1)) { _Cb1 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb2;
        [XmlAttribute]
        public BoolCN? Cb2 { get => _Cb2; set { if (RaiseAcceptPendingChange(value, _Cb2)) { _Cb2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb3;
        [XmlAttribute]
        public BoolCN? Cb3 { get => _Cb3; set { if (RaiseAcceptPendingChange(value, _Cb3)) { _Cb3 = value; OnPropertyChanged(); } } }

        private string? _Tbnota1;
        [XmlAttribute]
        public string? Tbnota1 { get => _Tbnota1; set { if (RaiseAcceptPendingChange(value, _Tbnota1)) { _Tbnota1 = value; OnPropertyChanged(); } } }

        private string? _Tbnota2;
        [XmlAttribute]
        public string? Tbnota2 { get => _Tbnota2; set { if (RaiseAcceptPendingChange(value, _Tbnota2)) { _Tbnota2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbverificarprocesamiento;
        [XmlAttribute]
        public BoolCN? Cbverificarprocesamiento { get => _Cbverificarprocesamiento; set { if (RaiseAcceptPendingChange(value, _Cbverificarprocesamiento)) { _Cbverificarprocesamiento = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalClave;
        [XmlAttribute]
        public string? CborigenfiscalClave { get => _CborigenfiscalClave; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalClave)) { _CborigenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalNombre;
        [XmlAttribute]
        public string? CborigenfiscalNombre { get => _CborigenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalNombre)) { _CborigenfiscalNombre = value; OnPropertyChanged(); } } }

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

