
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
    public class WFReporteDeFacturacionIEPSWFBindingModel : Validatable
    {

        public WFReporteDeFacturacionIEPSWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private long? _Cbtipoventa;
        [XmlAttribute]
        public long? Cbtipoventa { get => _Cbtipoventa; set { if (RaiseAcceptPendingChange(value, _Cbtipoventa)) { _Cbtipoventa = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private long? _Cbestatusventa;
        [XmlAttribute]
        public long? Cbestatusventa { get => _Cbestatusventa; set { if (RaiseAcceptPendingChange(value, _Cbestatusventa)) { _Cbestatusventa = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private string? _CbtipoventaClave;
        [XmlAttribute]
        public string? CbtipoventaClave { get => _CbtipoventaClave; set { if (RaiseAcceptPendingChange(value, _CbtipoventaClave)) { _CbtipoventaClave = value; OnPropertyChanged(); } } }

        private string? _CbtipoventaNombre;
        [XmlAttribute]
        public string? CbtipoventaNombre { get => _CbtipoventaNombre; set { if (RaiseAcceptPendingChange(value, _CbtipoventaNombre)) { _CbtipoventaNombre = value; OnPropertyChanged(); } } }

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

