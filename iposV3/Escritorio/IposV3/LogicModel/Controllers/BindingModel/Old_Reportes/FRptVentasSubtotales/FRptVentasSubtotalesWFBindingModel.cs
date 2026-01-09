
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
    public class FRptVentasSubtotalesWFBindingModel : Validatable
    {

        public FRptVentasSubtotalesWFBindingModel()
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

        private long? _Cbfactrem;
        [XmlAttribute]
        public long? Cbfactrem { get => _Cbfactrem; set { if (RaiseAcceptPendingChange(value, _Cbfactrem)) { _Cbfactrem = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloalmacen;
        [XmlAttribute]
        public BoolCN? Cbsoloalmacen { get => _Cbsoloalmacen; set { if (RaiseAcceptPendingChange(value, _Cbsoloalmacen)) { _Cbsoloalmacen = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbreportetabular;
        [XmlAttribute]
        public BoolCN? Cbreportetabular { get => _Cbreportetabular; set { if (RaiseAcceptPendingChange(value, _Cbreportetabular)) { _Cbreportetabular = value; OnPropertyChanged(); } } }

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

        private string? _CbfactremClave;
        [XmlAttribute]
        public string? CbfactremClave { get => _CbfactremClave; set { if (RaiseAcceptPendingChange(value, _CbfactremClave)) { _CbfactremClave = value; OnPropertyChanged(); } } }

        private string? _CbfactremNombre;
        [XmlAttribute]
        public string? CbfactremNombre { get => _CbfactremNombre; set { if (RaiseAcceptPendingChange(value, _CbfactremNombre)) { _CbfactremNombre = value; OnPropertyChanged(); } } }

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
    public class FRptVentasSubtotalesWF_Rep_ventaBindingModel : Validatable
    {

        public FRptVentasSubtotalesWF_Rep_ventaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tipodoc;
        [XmlAttribute]
        public string? Tipodoc { get => _Tipodoc; set { if (RaiseAcceptPendingChange(value, _Tipodoc)) { _Tipodoc = value; OnPropertyChanged(); } } }

        private string? _Vendedor;
        [XmlAttribute]
        public string? Vendedor { get => _Vendedor; set { if (RaiseAcceptPendingChange(value, _Vendedor)) { _Vendedor = value; OnPropertyChanged(); } } }

        private string? _Esfacturaelectronica;
        [XmlAttribute]
        public string? Esfacturaelectronica { get => _Esfacturaelectronica; set { if (RaiseAcceptPendingChange(value, _Esfacturaelectronica)) { _Esfacturaelectronica = value; OnPropertyChanged(); } } }

        private string? _Seriefoliosat;
        [XmlAttribute]
        public string? Seriefoliosat { get => _Seriefoliosat; set { if (RaiseAcceptPendingChange(value, _Seriefoliosat)) { _Seriefoliosat = value; OnPropertyChanged(); } } }

        private string? _Sucursalt;
        [XmlAttribute]
        public string? Sucursalt { get => _Sucursalt; set { if (RaiseAcceptPendingChange(value, _Sucursalt)) { _Sucursalt = value; OnPropertyChanged(); } } }

        private string? _Saldo;
        [XmlAttribute]
        public string? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctonombre;
        [XmlAttribute]
        public string? Estatusdoctonombre { get => _Estatusdoctonombre; set { if (RaiseAcceptPendingChange(value, _Estatusdoctonombre)) { _Estatusdoctonombre = value; OnPropertyChanged(); } } }

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

