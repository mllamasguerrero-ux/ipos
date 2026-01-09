
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
    public class WFReporteDeVentasXRutaWFBindingModel : Validatable
    {

        public WFReporteDeVentasXRutaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbrutastodas;
        [XmlAttribute]
        public BoolCN? Cbrutastodas { get => _Cbrutastodas; set { if (RaiseAcceptPendingChange(value, _Cbrutastodas)) { _Cbrutastodas = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private long? _Cbtipoventa;
        [XmlAttribute]
        public long? Cbtipoventa { get => _Cbtipoventa; set { if (RaiseAcceptPendingChange(value, _Cbtipoventa)) { _Cbtipoventa = value; OnPropertyChanged(); } } }

        private long? _Cbesfactura;
        [XmlAttribute]
        public long? Cbesfactura { get => _Cbesfactura; set { if (RaiseAcceptPendingChange(value, _Cbesfactura)) { _Cbesfactura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private long? _Cbestatusventa;
        [XmlAttribute]
        public long? Cbestatusventa { get => _Cbestatusventa; set { if (RaiseAcceptPendingChange(value, _Cbestatusventa)) { _Cbestatusventa = value; OnPropertyChanged(); } } }

        private string? _CbtipoventaClave;
        [XmlAttribute]
        public string? CbtipoventaClave { get => _CbtipoventaClave; set { if (RaiseAcceptPendingChange(value, _CbtipoventaClave)) { _CbtipoventaClave = value; OnPropertyChanged(); } } }

        private string? _CbtipoventaNombre;
        [XmlAttribute]
        public string? CbtipoventaNombre { get => _CbtipoventaNombre; set { if (RaiseAcceptPendingChange(value, _CbtipoventaNombre)) { _CbtipoventaNombre = value; OnPropertyChanged(); } } }

        private string? _CbesfacturaClave;
        [XmlAttribute]
        public string? CbesfacturaClave { get => _CbesfacturaClave; set { if (RaiseAcceptPendingChange(value, _CbesfacturaClave)) { _CbesfacturaClave = value; OnPropertyChanged(); } } }

        private string? _CbesfacturaNombre;
        [XmlAttribute]
        public string? CbesfacturaNombre { get => _CbesfacturaNombre; set { if (RaiseAcceptPendingChange(value, _CbesfacturaNombre)) { _CbesfacturaNombre = value; OnPropertyChanged(); } } }

        private string? _CbestatusventaClave;
        [XmlAttribute]
        public string? CbestatusventaClave { get => _CbestatusventaClave; set { if (RaiseAcceptPendingChange(value, _CbestatusventaClave)) { _CbestatusventaClave = value; OnPropertyChanged(); } } }

        private string? _CbestatusventaNombre;
        [XmlAttribute]
        public string? CbestatusventaNombre { get => _CbestatusventaNombre; set { if (RaiseAcceptPendingChange(value, _CbestatusventaNombre)) { _CbestatusventaNombre = value; OnPropertyChanged(); } } }

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

