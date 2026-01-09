
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
    public class FRptVentasXCorteWFBindingModel : Validatable
    {

        public FRptVentasXCorteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbtipo;
        [XmlAttribute]
        public long? Cbtipo { get => _Cbtipo; set { if (RaiseAcceptPendingChange(value, _Cbtipo)) { _Cbtipo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private long? _Comboboxalmacen;
        [XmlAttribute]
        public long? Comboboxalmacen { get => _Comboboxalmacen; set { if (RaiseAcceptPendingChange(value, _Comboboxalmacen)) { _Comboboxalmacen = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloalmacen;
        [XmlAttribute]
        public BoolCN? Cbsoloalmacen { get => _Cbsoloalmacen; set { if (RaiseAcceptPendingChange(value, _Cbsoloalmacen)) { _Cbsoloalmacen = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private string? _CbtipoClave;
        [XmlAttribute]
        public string? CbtipoClave { get => _CbtipoClave; set { if (RaiseAcceptPendingChange(value, _CbtipoClave)) { _CbtipoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipoNombre;
        [XmlAttribute]
        public string? CbtipoNombre { get => _CbtipoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipoNombre)) { _CbtipoNombre = value; OnPropertyChanged(); } } }

        private string? _ComboboxalmacenClave;
        [XmlAttribute]
        public string? ComboboxalmacenClave { get => _ComboboxalmacenClave; set { if (RaiseAcceptPendingChange(value, _ComboboxalmacenClave)) { _ComboboxalmacenClave = value; OnPropertyChanged(); } } }

        private string? _ComboboxalmacenNombre;
        [XmlAttribute]
        public string? ComboboxalmacenNombre { get => _ComboboxalmacenNombre; set { if (RaiseAcceptPendingChange(value, _ComboboxalmacenNombre)) { _ComboboxalmacenNombre = value; OnPropertyChanged(); } } }

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

