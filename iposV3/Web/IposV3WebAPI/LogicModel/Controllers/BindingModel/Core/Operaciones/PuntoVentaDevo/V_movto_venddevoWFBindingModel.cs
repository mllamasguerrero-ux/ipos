
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
    public class V_movto_venddevoWFBindingModel : Validatable
    {

        public V_movto_venddevoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private int? _Partida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Partida { get => _Partida?? 0; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value?? 0; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _ProductoClave;
        [XmlAttribute]
        public string? ProductoClave { get => _ProductoClave; set { if (RaiseAcceptPendingChange(value, _ProductoClave)) { _ProductoClave = value; OnPropertyChanged(); } } }

        private string? _ProductoNombre;
        [XmlAttribute]
        public string? ProductoNombre { get => _ProductoNombre; set { if (RaiseAcceptPendingChange(value, _ProductoNombre)) { _ProductoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidad { get => _Cantidad?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Preciolista;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciolista { get => _Preciolista?? 0; set { if (RaiseAcceptPendingChange(value, _Preciolista)) { _Preciolista = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuentoporcentaje;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuento { get => _Descuento?? 0; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio { get => _Precio?? 0; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotal { get => _Subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Iva { get => _Iva?? 0; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ieps { get => _Ieps?? 0; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaiva { get => _Tasaiva?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaieps { get => _Tasaieps?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Total { get => _Total?? 0; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value?? 0; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Loteimportado;
        [XmlAttribute]
        public long? Loteimportado { get => _Loteimportado; set { if (RaiseAcceptPendingChange(value, _Loteimportado)) { _Loteimportado = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private int? _Orden;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Orden { get => _Orden?? 0; set { if (RaiseAcceptPendingChange(value, _Orden)) { _Orden = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuentovale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentovale { get => _Descuentovale?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentovale)) { _Descuentovale = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuentovaleporcentaje;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentovaleporcentaje { get => _Descuentovaleporcentaje?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentovaleporcentaje)) { _Descuentovaleporcentaje = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Ingresopreciomanual;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ingresopreciomanual { get => _Ingresopreciomanual?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ingresopreciomanual)) { _Ingresopreciomanual = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Porcentajedescuentomanual;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Porcentajedescuentomanual { get => _Porcentajedescuentomanual?? 0; set { if (RaiseAcceptPendingChange(value, _Porcentajedescuentomanual)) { _Porcentajedescuentomanual = value?? 0; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadsurtida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidadsurtida { get => _Cantidadsurtida?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidadsurtida)) { _Cantidadsurtida = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio1 { get => _Precio1?? 0; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Existencia { get => _Existencia?? 0; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Pzacaja { get => _Pzacaja?? 0; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value?? 0; OnPropertyChanged(); } } }

        private string? _Texto1;
        [XmlAttribute]
        public string? Texto1 { get => _Texto1; set { if (RaiseAcceptPendingChange(value, _Texto1)) { _Texto1 = value; OnPropertyChanged(); } } }

        private string? _Texto2;
        [XmlAttribute]
        public string? Texto2 { get => _Texto2; set { if (RaiseAcceptPendingChange(value, _Texto2)) { _Texto2 = value; OnPropertyChanged(); } } }

        private string? _Texto3;
        [XmlAttribute]
        public string? Texto3 { get => _Texto3; set { if (RaiseAcceptPendingChange(value, _Texto3)) { _Texto3 = value; OnPropertyChanged(); } } }

        private string? _Texto4;
        [XmlAttribute]
        public string? Texto4 { get => _Texto4; set { if (RaiseAcceptPendingChange(value, _Texto4)) { _Texto4 = value; OnPropertyChanged(); } } }

        private string? _Texto5;
        [XmlAttribute]
        public string? Texto5 { get => _Texto5; set { if (RaiseAcceptPendingChange(value, _Texto5)) { _Texto5 = value; OnPropertyChanged(); } } }

        private string? _Texto6;
        [XmlAttribute]
        public string? Texto6 { get => _Texto6; set { if (RaiseAcceptPendingChange(value, _Texto6)) { _Texto6 = value; OnPropertyChanged(); } } }

        private decimal? _Numero1;
        [XmlAttribute]
        public decimal? Numero1 { get => _Numero1; set { if (RaiseAcceptPendingChange(value, _Numero1)) { _Numero1 = value; OnPropertyChanged(); } } }

        private decimal? _Numero2;
        [XmlAttribute]
        public decimal? Numero2 { get => _Numero2; set { if (RaiseAcceptPendingChange(value, _Numero2)) { _Numero2 = value; OnPropertyChanged(); } } }

        private decimal? _Numero3;
        [XmlAttribute]
        public decimal? Numero3 { get => _Numero3; set { if (RaiseAcceptPendingChange(value, _Numero3)) { _Numero3 = value; OnPropertyChanged(); } } }

        private decimal? _Numero4;
        [XmlAttribute]
        public decimal? Numero4 { get => _Numero4; set { if (RaiseAcceptPendingChange(value, _Numero4)) { _Numero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Fecha1 { get => _Fecha1; set { if (RaiseAcceptPendingChange(value, _Fecha1)) { _Fecha1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Fecha2 { get => _Fecha2; set { if (RaiseAcceptPendingChange(value, _Fecha2)) { _Fecha2 = value; OnPropertyChanged(); } } }

        private long? _Unidadid;
        [XmlAttribute]
        public long? Unidadid { get => _Unidadid; set { if (RaiseAcceptPendingChange(value, _Unidadid)) { _Unidadid = value; OnPropertyChanged(); } } }

        private string? _UnidadClave;
        [XmlAttribute]
        public string? UnidadClave { get => _UnidadClave; set { if (RaiseAcceptPendingChange(value, _UnidadClave)) { _UnidadClave = value; OnPropertyChanged(); } } }

        private string? _UnidadNombre;
        [XmlAttribute]
        public string? UnidadNombre { get => _UnidadNombre; set { if (RaiseAcceptPendingChange(value, _UnidadNombre)) { _UnidadNombre = value; OnPropertyChanged(); } } }

        private string? _Alerta3;
        [XmlAttribute]
        public string? Alerta3 { get => _Alerta3; set { if (RaiseAcceptPendingChange(value, _Alerta3)) { _Alerta3 = value; OnPropertyChanged(); } } }

        private decimal? _Preciomostrar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciomostrar { get => _Preciomostrar?? 0; set { if (RaiseAcceptPendingChange(value, _Preciomostrar)) { _Preciomostrar = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuentomostrar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentomostrar { get => _Descuentomostrar?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentomostrar)) { _Descuentomostrar = value?? 0; OnPropertyChanged(); } } }

        private long? _Devolucionmovtorefid;
        [XmlAttribute]
        public long? Devolucionmovtorefid { get => _Devolucionmovtorefid; set { if (RaiseAcceptPendingChange(value, _Devolucionmovtorefid)) { _Devolucionmovtorefid = value; OnPropertyChanged(); } } }

        private decimal? _Devolucionmovtorefcantidad;
        [XmlAttribute]
        public decimal? Devolucionmovtorefcantidad { get => _Devolucionmovtorefcantidad; set { if (RaiseAcceptPendingChange(value, _Devolucionmovtorefcantidad)) { _Devolucionmovtorefcantidad = value; OnPropertyChanged(); } } }

        private decimal? _Devolucionmovtorefprecio;
        [XmlAttribute]
        public decimal? Devolucionmovtorefprecio { get => _Devolucionmovtorefprecio; set { if (RaiseAcceptPendingChange(value, _Devolucionmovtorefprecio)) { _Devolucionmovtorefprecio = value; OnPropertyChanged(); } } }

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


        public static V_movto_venddevoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_movto_venddevoWFBindingModel = new V_movto_venddevoWFBindingModel();

        	buffer_V_movto_venddevoWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_movto_venddevoWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_movto_venddevoWFBindingModel._Id = obj.Id;

        	buffer_V_movto_venddevoWFBindingModel._Partida = obj.Partida;

        	buffer_V_movto_venddevoWFBindingModel._Productoid = obj.Productoid;

        	buffer_V_movto_venddevoWFBindingModel._ProductoClave = obj.ProductoClave;

        	buffer_V_movto_venddevoWFBindingModel._ProductoNombre = obj.ProductoNombre;

        	buffer_V_movto_venddevoWFBindingModel._Cantidad = obj.Cantidad;

        	buffer_V_movto_venddevoWFBindingModel._Preciolista = obj.Preciolista;

        	buffer_V_movto_venddevoWFBindingModel._Descuentoporcentaje = obj.Descuentoporcentaje;

        	buffer_V_movto_venddevoWFBindingModel._Descuento = obj.Descuento;

        	buffer_V_movto_venddevoWFBindingModel._Precio = obj.Precio;

        	buffer_V_movto_venddevoWFBindingModel._Importe = obj.Importe;

        	buffer_V_movto_venddevoWFBindingModel._Subtotal = obj.Subtotal;

        	buffer_V_movto_venddevoWFBindingModel._Iva = obj.Iva;

        	buffer_V_movto_venddevoWFBindingModel._Ieps = obj.Ieps;

        	buffer_V_movto_venddevoWFBindingModel._Tasaiva = obj.Tasaiva;

        	buffer_V_movto_venddevoWFBindingModel._Tasaieps = obj.Tasaieps;

        	buffer_V_movto_venddevoWFBindingModel._Total = obj.Total;

        	buffer_V_movto_venddevoWFBindingModel._Lote = obj.Lote;

        	buffer_V_movto_venddevoWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_V_movto_venddevoWFBindingModel._Loteimportado = obj.Loteimportado;

        	buffer_V_movto_venddevoWFBindingModel._Doctoid = obj.Doctoid;

        	buffer_V_movto_venddevoWFBindingModel._Orden = obj.Orden;

        	buffer_V_movto_venddevoWFBindingModel._Descuentovale = obj.Descuentovale;

        	buffer_V_movto_venddevoWFBindingModel._Descuentovaleporcentaje = obj.Descuentovaleporcentaje;

        	buffer_V_movto_venddevoWFBindingModel._Ingresopreciomanual = obj.Ingresopreciomanual;

        	buffer_V_movto_venddevoWFBindingModel._Porcentajedescuentomanual = obj.Porcentajedescuentomanual;

        	buffer_V_movto_venddevoWFBindingModel._Descripcion1 = obj.Descripcion1;

        	buffer_V_movto_venddevoWFBindingModel._Descripcion2 = obj.Descripcion2;

        	buffer_V_movto_venddevoWFBindingModel._Descripcion3 = obj.Descripcion3;

        	buffer_V_movto_venddevoWFBindingModel._Cantidadsurtida = obj.Cantidadsurtida;

        	buffer_V_movto_venddevoWFBindingModel._Precio1 = obj.Precio1;

        	buffer_V_movto_venddevoWFBindingModel._Existencia = obj.Existencia;

        	buffer_V_movto_venddevoWFBindingModel._Pzacaja = obj.Pzacaja;

        	buffer_V_movto_venddevoWFBindingModel._Texto1 = obj.Texto1;

        	buffer_V_movto_venddevoWFBindingModel._Texto2 = obj.Texto2;

        	buffer_V_movto_venddevoWFBindingModel._Texto3 = obj.Texto3;

        	buffer_V_movto_venddevoWFBindingModel._Texto4 = obj.Texto4;

        	buffer_V_movto_venddevoWFBindingModel._Texto5 = obj.Texto5;

        	buffer_V_movto_venddevoWFBindingModel._Texto6 = obj.Texto6;

        	buffer_V_movto_venddevoWFBindingModel._Numero1 = obj.Numero1;

        	buffer_V_movto_venddevoWFBindingModel._Numero2 = obj.Numero2;

        	buffer_V_movto_venddevoWFBindingModel._Numero3 = obj.Numero3;

        	buffer_V_movto_venddevoWFBindingModel._Numero4 = obj.Numero4;

        	buffer_V_movto_venddevoWFBindingModel._Fecha1 = obj.Fecha1;

        	buffer_V_movto_venddevoWFBindingModel._Fecha2 = obj.Fecha2;

        	buffer_V_movto_venddevoWFBindingModel._Unidadid = obj.Unidadid;

        	buffer_V_movto_venddevoWFBindingModel._UnidadClave = obj.UnidadClave;

        	buffer_V_movto_venddevoWFBindingModel._UnidadNombre = obj.UnidadNombre;

        	buffer_V_movto_venddevoWFBindingModel._Alerta3 = obj.Alerta3;

        	buffer_V_movto_venddevoWFBindingModel._Preciomostrar = obj.Preciomostrar;

        	buffer_V_movto_venddevoWFBindingModel._Descuentomostrar = obj.Descuentomostrar;

        	buffer_V_movto_venddevoWFBindingModel._Devolucionmovtorefid = obj.Devolucionmovtorefid;

        	buffer_V_movto_venddevoWFBindingModel._Devolucionmovtorefcantidad = obj.Devolucionmovtorefcantidad;

        	buffer_V_movto_venddevoWFBindingModel._Devolucionmovtorefprecio = obj.Devolucionmovtorefprecio;

            return buffer_V_movto_venddevoWFBindingModel;
        }


    }

    
     
}

