
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
    public class WFConsultaDetalleConsolidadoWFBindingModel : Validatable
    {

        public WFConsultaDetalleConsolidadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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
    public class WFConsultaDetalleConsolidadoWF_DetallesventasdentroconsolidadoBindingModel : Validatable
    {

        public WFConsultaDetalleConsolidadoWF_DetallesventasdentroconsolidadoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute]
        public decimal? Precio { get => _Precio; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value; OnPropertyChanged(); } } }

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

        private string? _Sucursalt;
        [XmlAttribute]
        public string? Sucursalt { get => _Sucursalt; set { if (RaiseAcceptPendingChange(value, _Sucursalt)) { _Sucursalt = value; OnPropertyChanged(); } } }

        private string? _Tipodoc;
        [XmlAttribute]
        public string? Tipodoc { get => _Tipodoc; set { if (RaiseAcceptPendingChange(value, _Tipodoc)) { _Tipodoc = value; OnPropertyChanged(); } } }

        private string? _Persona;
        [XmlAttribute]
        public string? Persona { get => _Persona; set { if (RaiseAcceptPendingChange(value, _Persona)) { _Persona = value; OnPropertyChanged(); } } }

        private string? _Preciomanualmasbajo;
        [XmlAttribute]
        public string? Preciomanualmasbajo { get => _Preciomanualmasbajo; set { if (RaiseAcceptPendingChange(value, _Preciomanualmasbajo)) { _Preciomanualmasbajo = value; OnPropertyChanged(); } } }

        private string? _Razondescuentocajero;
        [XmlAttribute]
        public string? Razondescuentocajero { get => _Razondescuentocajero; set { if (RaiseAcceptPendingChange(value, _Razondescuentocajero)) { _Razondescuentocajero = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

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
    public class WFConsultaDetalleConsolidadoWF_VentasdentrodeconsolidadoBindingModel : Validatable
    {

        public WFConsultaDetalleConsolidadoWF_VentasdentrodeconsolidadoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Nombretipoaplicacion;
        [XmlAttribute]
        public string? Nombretipoaplicacion { get => _Nombretipoaplicacion; set { if (RaiseAcceptPendingChange(value, _Nombretipoaplicacion)) { _Nombretipoaplicacion = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

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

        private string? _Tipodoctonombre;
        [XmlAttribute]
        public string? Tipodoctonombre { get => _Tipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Tipodoctonombre)) { _Tipodoctonombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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

