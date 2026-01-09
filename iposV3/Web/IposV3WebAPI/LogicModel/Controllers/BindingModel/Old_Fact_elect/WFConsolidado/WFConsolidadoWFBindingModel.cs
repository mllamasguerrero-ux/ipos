
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
    public class WFConsolidadoWFBindingModel : Validatable
    {

        public WFConsolidadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Montomaximodia;
        [XmlAttribute]
        public decimal? Montomaximodia { get => _Montomaximodia; set { if (RaiseAcceptPendingChange(value, _Montomaximodia)) { _Montomaximodia = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmontomaximodia;
        [XmlAttribute]
        public BoolCN? Cbmontomaximodia { get => _Cbmontomaximodia; set { if (RaiseAcceptPendingChange(value, _Cbmontomaximodia)) { _Cbmontomaximodia = value; OnPropertyChanged(); } } }

        private long? _Grupousuarioidcombobox;
        [XmlAttribute]
        public long? Grupousuarioidcombobox { get => _Grupousuarioidcombobox; set { if (RaiseAcceptPendingChange(value, _Grupousuarioidcombobox)) { _Grupousuarioidcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Omitirvales;
        [XmlAttribute]
        public BoolCN? Omitirvales { get => _Omitirvales; set { if (RaiseAcceptPendingChange(value, _Omitirvales)) { _Omitirvales = value; OnPropertyChanged(); } } }

        private decimal? _Montomaximo;
        [XmlAttribute]
        public decimal? Montomaximo { get => _Montomaximo; set { if (RaiseAcceptPendingChange(value, _Montomaximo)) { _Montomaximo = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmontomaximo;
        [XmlAttribute]
        public BoolCN? Cbmontomaximo { get => _Cbmontomaximo; set { if (RaiseAcceptPendingChange(value, _Cbmontomaximo)) { _Cbmontomaximo = value; OnPropertyChanged(); } } }

        private int? _Numanio;
        [XmlAttribute]
        public int? Numanio { get => _Numanio; set { if (RaiseAcceptPendingChange(value, _Numanio)) { _Numanio = value; OnPropertyChanged(); } } }

        private long? _Cbmes;
        [XmlAttribute]
        public long? Cbmes { get => _Cbmes; set { if (RaiseAcceptPendingChange(value, _Cbmes)) { _Cbmes = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbincluirgastos;
        [XmlAttribute]
        public BoolCN? Cbincluirgastos { get => _Cbincluirgastos; set { if (RaiseAcceptPendingChange(value, _Cbincluirgastos)) { _Cbincluirgastos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbomitirclientesconrfc;
        [XmlAttribute]
        public BoolCN? Cbomitirclientesconrfc { get => _Cbomitirclientesconrfc; set { if (RaiseAcceptPendingChange(value, _Cbomitirclientesconrfc)) { _Cbomitirclientesconrfc = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbomitirfranquicias;
        [XmlAttribute]
        public BoolCN? Cbomitirfranquicias { get => _Cbomitirfranquicias; set { if (RaiseAcceptPendingChange(value, _Cbomitirfranquicias)) { _Cbomitirfranquicias = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private decimal? _Montomaximoporc;
        [XmlAttribute]
        public decimal? Montomaximoporc { get => _Montomaximoporc; set { if (RaiseAcceptPendingChange(value, _Montomaximoporc)) { _Montomaximoporc = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmontomaximoporc;
        [XmlAttribute]
        public BoolCN? Cbmontomaximoporc { get => _Cbmontomaximoporc; set { if (RaiseAcceptPendingChange(value, _Cbmontomaximoporc)) { _Cbmontomaximoporc = value; OnPropertyChanged(); } } }

        private string? _GrupousuarioidcomboboxClave;
        [XmlAttribute]
        public string? GrupousuarioidcomboboxClave { get => _GrupousuarioidcomboboxClave; set { if (RaiseAcceptPendingChange(value, _GrupousuarioidcomboboxClave)) { _GrupousuarioidcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _GrupousuarioidcomboboxNombre;
        [XmlAttribute]
        public string? GrupousuarioidcomboboxNombre { get => _GrupousuarioidcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _GrupousuarioidcomboboxNombre)) { _GrupousuarioidcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CbmesClave;
        [XmlAttribute]
        public string? CbmesClave { get => _CbmesClave; set { if (RaiseAcceptPendingChange(value, _CbmesClave)) { _CbmesClave = value; OnPropertyChanged(); } } }

        private string? _CbmesNombre;
        [XmlAttribute]
        public string? CbmesNombre { get => _CbmesNombre; set { if (RaiseAcceptPendingChange(value, _CbmesNombre)) { _CbmesNombre = value; OnPropertyChanged(); } } }

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
    public class WFConsolidadoWF_PorconsolidarBindingModel : Validatable
    {

        public WFConsolidadoWF_PorconsolidarBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Tipodoctonombre;
        [XmlAttribute]
        public string? Tipodoctonombre { get => _Tipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Tipodoctonombre)) { _Tipodoctonombre = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private string? _Nombretipoaplicacion;
        [XmlAttribute]
        public string? Nombretipoaplicacion { get => _Nombretipoaplicacion; set { if (RaiseAcceptPendingChange(value, _Nombretipoaplicacion)) { _Nombretipoaplicacion = value; OnPropertyChanged(); } } }

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

        private decimal? _Ieps;
        [XmlAttribute]
        public decimal? Ieps { get => _Ieps; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value; OnPropertyChanged(); } } }

        private decimal? _Impuesto;
        [XmlAttribute]
        public decimal? Impuesto { get => _Impuesto; set { if (RaiseAcceptPendingChange(value, _Impuesto)) { _Impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private decimal? _Cargo;
        [XmlAttribute]
        public decimal? Cargo { get => _Cargo; set { if (RaiseAcceptPendingChange(value, _Cargo)) { _Cargo = value; OnPropertyChanged(); } } }

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
    public class WFConsolidadoWF_PorconsolidarsumaBindingModel : Validatable
    {

        public WFConsolidadoWF_PorconsolidarsumaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Cuentaregistros;
        [XmlAttribute]
        public int? Cuentaregistros { get => _Cuentaregistros; set { if (RaiseAcceptPendingChange(value, _Cuentaregistros)) { _Cuentaregistros = value; OnPropertyChanged(); } } }

        private decimal? _Sumaimporte;
        [XmlAttribute]
        public decimal? Sumaimporte { get => _Sumaimporte; set { if (RaiseAcceptPendingChange(value, _Sumaimporte)) { _Sumaimporte = value; OnPropertyChanged(); } } }

        private decimal? _Sumadescuento;
        [XmlAttribute]
        public decimal? Sumadescuento { get => _Sumadescuento; set { if (RaiseAcceptPendingChange(value, _Sumadescuento)) { _Sumadescuento = value; OnPropertyChanged(); } } }

        private decimal? _Sumasubtotal;
        [XmlAttribute]
        public decimal? Sumasubtotal { get => _Sumasubtotal; set { if (RaiseAcceptPendingChange(value, _Sumasubtotal)) { _Sumasubtotal = value; OnPropertyChanged(); } } }

        private decimal? _Sumaiva;
        [XmlAttribute]
        public decimal? Sumaiva { get => _Sumaiva; set { if (RaiseAcceptPendingChange(value, _Sumaiva)) { _Sumaiva = value; OnPropertyChanged(); } } }

        private decimal? _Sumaieps;
        [XmlAttribute]
        public decimal? Sumaieps { get => _Sumaieps; set { if (RaiseAcceptPendingChange(value, _Sumaieps)) { _Sumaieps = value; OnPropertyChanged(); } } }

        private decimal? _Sumaimpuesto;
        [XmlAttribute]
        public decimal? Sumaimpuesto { get => _Sumaimpuesto; set { if (RaiseAcceptPendingChange(value, _Sumaimpuesto)) { _Sumaimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Sumasaldo;
        [XmlAttribute]
        public decimal? Sumasaldo { get => _Sumasaldo; set { if (RaiseAcceptPendingChange(value, _Sumasaldo)) { _Sumasaldo = value; OnPropertyChanged(); } } }

        private decimal? _Sumaabono;
        [XmlAttribute]
        public decimal? Sumaabono { get => _Sumaabono; set { if (RaiseAcceptPendingChange(value, _Sumaabono)) { _Sumaabono = value; OnPropertyChanged(); } } }

        private decimal? _Sumatotal;
        [XmlAttribute]
        public decimal? Sumatotal { get => _Sumatotal; set { if (RaiseAcceptPendingChange(value, _Sumatotal)) { _Sumatotal = value; OnPropertyChanged(); } } }

        private decimal? _Sumacargo;
        [XmlAttribute]
        public decimal? Sumacargo { get => _Sumacargo; set { if (RaiseAcceptPendingChange(value, _Sumacargo)) { _Sumacargo = value; OnPropertyChanged(); } } }

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
    public class WFConsolidadoWF_TablefechamontoBindingModel : Validatable
    {

        public WFConsolidadoWF_TablefechamontoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicamontomaximo;
        [XmlAttribute]
        public BoolCN? Aplicamontomaximo { get => _Aplicamontomaximo; set { if (RaiseAcceptPendingChange(value, _Aplicamontomaximo)) { _Aplicamontomaximo = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

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

