
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
    public class WFPuntoDeVentaWFBindingModel : Validatable
    {

        public WFPuntoDeVentaWFBindingModel()
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

        private long? _Lstproductocomplete;
        [XmlAttribute]
        public long? Lstproductocomplete { get => _Lstproductocomplete; set { if (RaiseAcceptPendingChange(value, _Lstproductocomplete)) { _Lstproductocomplete = value; OnPropertyChanged(); } } }

        private string? _Tbcliente;
        [XmlAttribute]
        public string? Tbcliente { get => _Tbcliente; set { if (RaiseAcceptPendingChange(value, _Tbcliente)) { _Tbcliente = value; OnPropertyChanged(); } } }

        private string? _Tbvale;
        [XmlAttribute]
        public string? Tbvale { get => _Tbvale; set { if (RaiseAcceptPendingChange(value, _Tbvale)) { _Tbvale = value; OnPropertyChanged(); } } }

        private string? _Observaciones;
        [XmlAttribute]
        public string? Observaciones { get => _Observaciones; set { if (RaiseAcceptPendingChange(value, _Observaciones)) { _Observaciones = value; OnPropertyChanged(); } } }

        private string? _Tbpagostotalventabig;
        [XmlAttribute]
        public string? Tbpagostotalventabig { get => _Tbpagostotalventabig; set { if (RaiseAcceptPendingChange(value, _Tbpagostotalventabig)) { _Tbpagostotalventabig = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcontado;
        [XmlAttribute]
        public BoolCN? Cbcontado { get => _Cbcontado; set { if (RaiseAcceptPendingChange(value, _Cbcontado)) { _Cbcontado = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfactura;
        [XmlAttribute]
        public BoolCN? Cbfactura { get => _Cbfactura; set { if (RaiseAcceptPendingChange(value, _Cbfactura)) { _Cbfactura = value; OnPropertyChanged(); } } }

        private string? _Tbcurrentitem;
        [XmlAttribute]
        public string? Tbcurrentitem { get => _Tbcurrentitem; set { if (RaiseAcceptPendingChange(value, _Tbcurrentitem)) { _Tbcurrentitem = value; OnPropertyChanged(); } } }

        private string? _Notapago;
        [XmlAttribute]
        public string? Notapago { get => _Notapago; set { if (RaiseAcceptPendingChange(value, _Notapago)) { _Notapago = value; OnPropertyChanged(); } } }

        private decimal? _Tbdescuento;
        [XmlAttribute]
        public decimal? Tbdescuento { get => _Tbdescuento; set { if (RaiseAcceptPendingChange(value, _Tbdescuento)) { _Tbdescuento = value; OnPropertyChanged(); } } }

        private decimal? _Tbprecio;
        [XmlAttribute]
        public decimal? Tbprecio { get => _Tbprecio; set { if (RaiseAcceptPendingChange(value, _Tbprecio)) { _Tbprecio = value; OnPropertyChanged(); } } }

        private string? _Tbcommandline;
        [XmlAttribute]
        public string? Tbcommandline { get => _Tbcommandline; set { if (RaiseAcceptPendingChange(value, _Tbcommandline)) { _Tbcommandline = value; OnPropertyChanged(); } } }

        private decimal? _Tbcajas;
        [XmlAttribute]
        public decimal? Tbcajas { get => _Tbcajas; set { if (RaiseAcceptPendingChange(value, _Tbcajas)) { _Tbcajas = value; OnPropertyChanged(); } } }

        private decimal? _Tbcantidad;
        [XmlAttribute]
        public decimal? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private string? _Lbltextoauxiliar;
        [XmlAttribute]
        public string? Lbltextoauxiliar { get => _Lbltextoauxiliar; set { if (RaiseAcceptPendingChange(value, _Lbltextoauxiliar)) { _Lbltextoauxiliar = value; OnPropertyChanged(); } } }

        private long? _Listaprecios;
        [XmlAttribute]
        public long? Listaprecios { get => _Listaprecios; set { if (RaiseAcceptPendingChange(value, _Listaprecios)) { _Listaprecios = value; OnPropertyChanged(); } } }

        private long? _Cbxpagocontarjeta;
        [XmlAttribute]
        public long? Cbxpagocontarjeta { get => _Cbxpagocontarjeta; set { if (RaiseAcceptPendingChange(value, _Cbxpagocontarjeta)) { _Cbxpagocontarjeta = value; OnPropertyChanged(); } } }

        private string? _Tbstatus;
        [XmlAttribute]
        public string? Tbstatus { get => _Tbstatus; set { if (RaiseAcceptPendingChange(value, _Tbstatus)) { _Tbstatus = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbacredito;
        [XmlAttribute]
        public BoolCN? Cbacredito { get => _Cbacredito; set { if (RaiseAcceptPendingChange(value, _Cbacredito)) { _Cbacredito = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private string? _Tbsumatotal;
        [XmlAttribute]
        public string? Tbsumatotal { get => _Tbsumatotal; set { if (RaiseAcceptPendingChange(value, _Tbsumatotal)) { _Tbsumatotal = value; OnPropertyChanged(); } } }

        private string? _Tbiva;
        [XmlAttribute]
        public string? Tbiva { get => _Tbiva; set { if (RaiseAcceptPendingChange(value, _Tbiva)) { _Tbiva = value; OnPropertyChanged(); } } }

        private string? _Tbtotal;
        [XmlAttribute]
        public string? Tbtotal { get => _Tbtotal; set { if (RaiseAcceptPendingChange(value, _Tbtotal)) { _Tbtotal = value; OnPropertyChanged(); } } }

        private decimal? _Tbpreciocaja;
        [XmlAttribute]
        public decimal? Tbpreciocaja { get => _Tbpreciocaja; set { if (RaiseAcceptPendingChange(value, _Tbpreciocaja)) { _Tbpreciocaja = value; OnPropertyChanged(); } } }

        private string? _LstproductocompleteClave;
        [XmlAttribute]
        public string? LstproductocompleteClave { get => _LstproductocompleteClave; set { if (RaiseAcceptPendingChange(value, _LstproductocompleteClave)) { _LstproductocompleteClave = value; OnPropertyChanged(); } } }

        private string? _LstproductocompleteNombre;
        [XmlAttribute]
        public string? LstproductocompleteNombre { get => _LstproductocompleteNombre; set { if (RaiseAcceptPendingChange(value, _LstproductocompleteNombre)) { _LstproductocompleteNombre = value; OnPropertyChanged(); } } }

        private string? _ListapreciosClave;
        [XmlAttribute]
        public string? ListapreciosClave { get => _ListapreciosClave; set { if (RaiseAcceptPendingChange(value, _ListapreciosClave)) { _ListapreciosClave = value; OnPropertyChanged(); } } }

        private string? _ListapreciosNombre;
        [XmlAttribute]
        public string? ListapreciosNombre { get => _ListapreciosNombre; set { if (RaiseAcceptPendingChange(value, _ListapreciosNombre)) { _ListapreciosNombre = value; OnPropertyChanged(); } } }

        private string? _CbxpagocontarjetaClave;
        [XmlAttribute]
        public string? CbxpagocontarjetaClave { get => _CbxpagocontarjetaClave; set { if (RaiseAcceptPendingChange(value, _CbxpagocontarjetaClave)) { _CbxpagocontarjetaClave = value; OnPropertyChanged(); } } }

        private string? _CbxpagocontarjetaNombre;
        [XmlAttribute]
        public string? CbxpagocontarjetaNombre { get => _CbxpagocontarjetaNombre; set { if (RaiseAcceptPendingChange(value, _CbxpagocontarjetaNombre)) { _CbxpagocontarjetaNombre = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxClave;
        [XmlAttribute]
        public string? AlmacencomboboxClave { get => _AlmacencomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxClave)) { _AlmacencomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxNombre;
        [XmlAttribute]
        public string? AlmacencomboboxNombre { get => _AlmacencomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxNombre)) { _AlmacencomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFPuntoDeVentaWF_GridpvBindingModel : Validatable
    {

        public WFPuntoDeVentaWF_GridpvBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private short? _Partida;
        [XmlAttribute]
        public short? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        private int? _Gridline;
        [XmlAttribute]
        public int? Gridline { get => _Gridline; set { if (RaiseAcceptPendingChange(value, _Gridline)) { _Gridline = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private decimal? _Preciounidad;
        [XmlAttribute]
        public decimal? Preciounidad { get => _Preciounidad; set { if (RaiseAcceptPendingChange(value, _Preciounidad)) { _Preciounidad = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private decimal? _Tasaimpuesto;
        [XmlAttribute]
        public decimal? Tasaimpuesto { get => _Tasaimpuesto; set { if (RaiseAcceptPendingChange(value, _Tasaimpuesto)) { _Tasaimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute]
        public decimal? Tasaieps { get => _Tasaieps; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value; OnPropertyChanged(); } } }

        private decimal? _Descuentoporcentaje;
        [XmlAttribute]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Porcentajedescuentomanual;
        [XmlAttribute]
        public decimal? Porcentajedescuentomanual { get => _Porcentajedescuentomanual; set { if (RaiseAcceptPendingChange(value, _Porcentajedescuentomanual)) { _Porcentajedescuentomanual = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private string? _Claveproducto;
        [XmlAttribute]
        public string? Claveproducto { get => _Claveproducto; set { if (RaiseAcceptPendingChange(value, _Claveproducto)) { _Claveproducto = value; OnPropertyChanged(); } } }

        private string? _Autorizaciondescnota;
        [XmlAttribute]
        public string? Autorizaciondescnota { get => _Autorizaciondescnota; set { if (RaiseAcceptPendingChange(value, _Autorizaciondescnota)) { _Autorizaciondescnota = value; OnPropertyChanged(); } } }

        private decimal? _Totalvale;
        [XmlAttribute]
        public decimal? Totalvale { get => _Totalvale; set { if (RaiseAcceptPendingChange(value, _Totalvale)) { _Totalvale = value; OnPropertyChanged(); } } }

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

        private string? _Imagen;
        [XmlAttribute]
        public string? Imagen { get => _Imagen; set { if (RaiseAcceptPendingChange(value, _Imagen)) { _Imagen = value; OnPropertyChanged(); } } }

        private string? _Alerta;
        [XmlAttribute]
        public string? Alerta { get => _Alerta; set { if (RaiseAcceptPendingChange(value, _Alerta)) { _Alerta = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private string? _Unidad;
        [XmlAttribute]
        public string? Unidad { get => _Unidad; set { if (RaiseAcceptPendingChange(value, _Unidad)) { _Unidad = value; OnPropertyChanged(); } } }

        private decimal? _Totalvaledesc1;
        [XmlAttribute]
        public decimal? Totalvaledesc1 { get => _Totalvaledesc1; set { if (RaiseAcceptPendingChange(value, _Totalvaledesc1)) { _Totalvaledesc1 = value; OnPropertyChanged(); } } }

        private string? _Alerta2;
        [XmlAttribute]
        public string? Alerta2 { get => _Alerta2; set { if (RaiseAcceptPendingChange(value, _Alerta2)) { _Alerta2 = value; OnPropertyChanged(); } } }

        private decimal? _Totalvaledesc2;
        [XmlAttribute]
        public decimal? Totalvaledesc2 { get => _Totalvaledesc2; set { if (RaiseAcceptPendingChange(value, _Totalvaledesc2)) { _Totalvaledesc2 = value; OnPropertyChanged(); } } }

        private decimal? _Totalvaledesc3;
        [XmlAttribute]
        public decimal? Totalvaledesc3 { get => _Totalvaledesc3; set { if (RaiseAcceptPendingChange(value, _Totalvaledesc3)) { _Totalvaledesc3 = value; OnPropertyChanged(); } } }

        private decimal? _Totalvaledesc4;
        [XmlAttribute]
        public decimal? Totalvaledesc4 { get => _Totalvaledesc4; set { if (RaiseAcceptPendingChange(value, _Totalvaledesc4)) { _Totalvaledesc4 = value; OnPropertyChanged(); } } }

        private string? _Ingresopreciomanual;
        [XmlAttribute]
        public string? Ingresopreciomanual { get => _Ingresopreciomanual; set { if (RaiseAcceptPendingChange(value, _Ingresopreciomanual)) { _Ingresopreciomanual = value; OnPropertyChanged(); } } }

        private decimal? _Porcdescmanual;
        [XmlAttribute]
        public decimal? Porcdescmanual { get => _Porcdescmanual; set { if (RaiseAcceptPendingChange(value, _Porcdescmanual)) { _Porcdescmanual = value; OnPropertyChanged(); } } }

        private string? _Alerta3;
        [XmlAttribute]
        public string? Alerta3 { get => _Alerta3; set { if (RaiseAcceptPendingChange(value, _Alerta3)) { _Alerta3 = value; OnPropertyChanged(); } } }

        private string? _Alerta3color;
        [XmlAttribute]
        public string? Alerta3color { get => _Alerta3color; set { if (RaiseAcceptPendingChange(value, _Alerta3color)) { _Alerta3color = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

        private string? _Alertaexistenciacolor;
        [XmlAttribute]
        public string? Alertaexistenciacolor { get => _Alertaexistenciacolor; set { if (RaiseAcceptPendingChange(value, _Alertaexistenciacolor)) { _Alertaexistenciacolor = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadsurtida;
        [XmlAttribute]
        public decimal? Cantidadsurtida { get => _Cantidadsurtida; set { if (RaiseAcceptPendingChange(value, _Cantidadsurtida)) { _Cantidadsurtida = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Rebajacolor;
        [XmlAttribute]
        public string? Rebajacolor { get => _Rebajacolor; set { if (RaiseAcceptPendingChange(value, _Rebajacolor)) { _Rebajacolor = value; OnPropertyChanged(); } } }

        private decimal? _Importecontopesinimp;
        [XmlAttribute]
        public decimal? Importecontopesinimp { get => _Importecontopesinimp; set { if (RaiseAcceptPendingChange(value, _Importecontopesinimp)) { _Importecontopesinimp = value; OnPropertyChanged(); } } }

        private decimal? _Ivacontope;
        [XmlAttribute]
        public decimal? Ivacontope { get => _Ivacontope; set { if (RaiseAcceptPendingChange(value, _Ivacontope)) { _Ivacontope = value; OnPropertyChanged(); } } }

        private decimal? _Totalcontope;
        [XmlAttribute]
        public decimal? Totalcontope { get => _Totalcontope; set { if (RaiseAcceptPendingChange(value, _Totalcontope)) { _Totalcontope = value; OnPropertyChanged(); } } }

        private decimal? _Descuentocontope;
        [XmlAttribute]
        public decimal? Descuentocontope { get => _Descuentocontope; set { if (RaiseAcceptPendingChange(value, _Descuentocontope)) { _Descuentocontope = value; OnPropertyChanged(); } } }

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

