
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
    public class WFMovimientosProveedorWFBindingModel : Validatable
    {

        public WFMovimientosProveedorWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private string? _PersonaidClave;
        [XmlAttribute]
        public string? PersonaidClave { get => _PersonaidClave; set { if (RaiseAcceptPendingChange(value, _PersonaidClave)) { _PersonaidClave = value; OnPropertyChanged(); } } }

        private string? _PersonaidNombre;
        [XmlAttribute]
        public string? PersonaidNombre { get => _PersonaidNombre; set { if (RaiseAcceptPendingChange(value, _PersonaidNombre)) { _PersonaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbconsaldo;
        [XmlAttribute]
        public BoolCN? Cbconsaldo { get => _Cbconsaldo; set { if (RaiseAcceptPendingChange(value, _Cbconsaldo)) { _Cbconsaldo = value; OnPropertyChanged(); } } }

        private string? _Tbnota;
        [XmlAttribute]
        public string? Tbnota { get => _Tbnota; set { if (RaiseAcceptPendingChange(value, _Tbnota)) { _Tbnota = value; OnPropertyChanged(); } } }

        private long? _Cbtipo;
        [XmlAttribute]
        public long? Cbtipo { get => _Cbtipo; set { if (RaiseAcceptPendingChange(value, _Cbtipo)) { _Cbtipo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private string? _CbtipoClave;
        [XmlAttribute]
        public string? CbtipoClave { get => _CbtipoClave; set { if (RaiseAcceptPendingChange(value, _CbtipoClave)) { _CbtipoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipoNombre;
        [XmlAttribute]
        public string? CbtipoNombre { get => _CbtipoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipoNombre)) { _CbtipoNombre = value; OnPropertyChanged(); } } }

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
    public class WFMovimientosProveedorWF_Get_lista_abonos_doctoBindingModel : Validatable
    {

        public WFMovimientosProveedorWF_Get_lista_abonos_doctoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Formadepago;
        [XmlAttribute]
        public string? Formadepago { get => _Formadepago; set { if (RaiseAcceptPendingChange(value, _Formadepago)) { _Formadepago = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private string? _Banco;
        [XmlAttribute]
        public string? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private string? _Tipoabonodescripcion;
        [XmlAttribute]
        public string? Tipoabonodescripcion { get => _Tipoabonodescripcion; set { if (RaiseAcceptPendingChange(value, _Tipoabonodescripcion)) { _Tipoabonodescripcion = value; OnPropertyChanged(); } } }

        private long? _Tipoabonoid;
        [XmlAttribute]
        public long? Tipoabonoid { get => _Tipoabonoid; set { if (RaiseAcceptPendingChange(value, _Tipoabonoid)) { _Tipoabonoid = value; OnPropertyChanged(); } } }

        private string? _Revertido;
        [XmlAttribute]
        public string? Revertido { get => _Revertido; set { if (RaiseAcceptPendingChange(value, _Revertido)) { _Revertido = value; OnPropertyChanged(); } } }

        private long? _Pagoid;
        [XmlAttribute]
        public long? Pagoid { get => _Pagoid; set { if (RaiseAcceptPendingChange(value, _Pagoid)) { _Pagoid = value; OnPropertyChanged(); } } }

        private decimal? _Montopagocompuesto;
        [XmlAttribute]
        public decimal? Montopagocompuesto { get => _Montopagocompuesto; set { if (RaiseAcceptPendingChange(value, _Montopagocompuesto)) { _Montopagocompuesto = value; OnPropertyChanged(); } } }

        private int? _Folioref;
        [XmlAttribute]
        public int? Folioref { get => _Folioref; set { if (RaiseAcceptPendingChange(value, _Folioref)) { _Folioref = value; OnPropertyChanged(); } } }

        private string? _Notas;
        [XmlAttribute]
        public string? Notas { get => _Notas; set { if (RaiseAcceptPendingChange(value, _Notas)) { _Notas = value; OnPropertyChanged(); } } }

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
    public class WFMovimientosProveedorWF_MovimientosBindingModel : Validatable
    {

        public WFMovimientosProveedorWF_MovimientosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vence;
        [XmlAttribute]
        public DateTimeOffset? Vence { get => _Vence; set { if (RaiseAcceptPendingChange(value, _Vence)) { _Vence = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Tipodoc;
        [XmlAttribute]
        public string? Tipodoc { get => _Tipodoc; set { if (RaiseAcceptPendingChange(value, _Tipodoc)) { _Tipodoc = value; OnPropertyChanged(); } } }

        private string? _Subtipo;
        [XmlAttribute]
        public string? Subtipo { get => _Subtipo; set { if (RaiseAcceptPendingChange(value, _Subtipo)) { _Subtipo = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

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

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private string? _Sucursalt;
        [XmlAttribute]
        public string? Sucursalt { get => _Sucursalt; set { if (RaiseAcceptPendingChange(value, _Sucursalt)) { _Sucursalt = value; OnPropertyChanged(); } } }

        private string? _Persona;
        [XmlAttribute]
        public string? Persona { get => _Persona; set { if (RaiseAcceptPendingChange(value, _Persona)) { _Persona = value; OnPropertyChanged(); } } }

        private string? _Notapago;
        [XmlAttribute]
        public string? Notapago { get => _Notapago; set { if (RaiseAcceptPendingChange(value, _Notapago)) { _Notapago = value; OnPropertyChanged(); } } }

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
    public class WFMovimientosProveedorWF_MovimientosdetalleBindingModel : Validatable
    {

        public WFMovimientosProveedorWF_MovimientosdetalleBindingModel()
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

        private decimal? _Cantidadsurtida;
        [XmlAttribute]
        public decimal? Cantidadsurtida { get => _Cantidadsurtida; set { if (RaiseAcceptPendingChange(value, _Cantidadsurtida)) { _Cantidadsurtida = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfaltante;
        [XmlAttribute]
        public decimal? Cantidadfaltante { get => _Cantidadfaltante; set { if (RaiseAcceptPendingChange(value, _Cantidadfaltante)) { _Cantidadfaltante = value; OnPropertyChanged(); } } }

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

