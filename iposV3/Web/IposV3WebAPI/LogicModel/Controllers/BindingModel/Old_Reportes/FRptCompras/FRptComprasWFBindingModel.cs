
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
    public class FRptComprasWFBindingModel : Validatable
    {

        public FRptComprasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private long? _Cbfactrem;
        [XmlAttribute]
        public long? Cbfactrem { get => _Cbfactrem; set { if (RaiseAcceptPendingChange(value, _Cbfactrem)) { _Cbfactrem = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

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

        private BoolCN? _Cbreportetabular;
        [XmlAttribute]
        public BoolCN? Cbreportetabular { get => _Cbreportetabular; set { if (RaiseAcceptPendingChange(value, _Cbreportetabular)) { _Cbreportetabular = value; OnPropertyChanged(); } } }

        private string? _CbfactremClave;
        [XmlAttribute]
        public string? CbfactremClave { get => _CbfactremClave; set { if (RaiseAcceptPendingChange(value, _CbfactremClave)) { _CbfactremClave = value; OnPropertyChanged(); } } }

        private string? _CbfactremNombre;
        [XmlAttribute]
        public string? CbfactremNombre { get => _CbfactremNombre; set { if (RaiseAcceptPendingChange(value, _CbfactremNombre)) { _CbfactremNombre = value; OnPropertyChanged(); } } }

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

    
    [XmlRoot]
    public class FRptComprasWF_Rep_compraBindingModel : Validatable
    {

        public FRptComprasWF_Rep_compraBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Proveedor;
        [XmlAttribute]
        public string? Proveedor { get => _Proveedor; set { if (RaiseAcceptPendingChange(value, _Proveedor)) { _Proveedor = value; OnPropertyChanged(); } } }

        private int? _Doctofolio;
        [XmlAttribute]
        public int? Doctofolio { get => _Doctofolio; set { if (RaiseAcceptPendingChange(value, _Doctofolio)) { _Doctofolio = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute]
        public decimal? Subtotal { get => _Subtotal; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

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

