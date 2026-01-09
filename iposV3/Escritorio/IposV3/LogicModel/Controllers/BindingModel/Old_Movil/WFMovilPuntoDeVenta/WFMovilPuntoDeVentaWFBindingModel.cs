
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
    public class WFMovilPuntoDeVentaWFBindingModel : Validatable
    {

        public WFMovilPuntoDeVentaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Lstproductocomplete;
        [XmlAttribute]
        public long? Lstproductocomplete { get => _Lstproductocomplete; set { if (RaiseAcceptPendingChange(value, _Lstproductocomplete)) { _Lstproductocomplete = value; OnPropertyChanged(); } } }

        private decimal? _Tbprecio;
        [XmlAttribute]
        public decimal? Tbprecio { get => _Tbprecio; set { if (RaiseAcceptPendingChange(value, _Tbprecio)) { _Tbprecio = value; OnPropertyChanged(); } } }

        private decimal? _Tbdescuento;
        [XmlAttribute]
        public decimal? Tbdescuento { get => _Tbdescuento; set { if (RaiseAcceptPendingChange(value, _Tbdescuento)) { _Tbdescuento = value; OnPropertyChanged(); } } }

        private decimal? _Tbpreciocaja;
        [XmlAttribute]
        public decimal? Tbpreciocaja { get => _Tbpreciocaja; set { if (RaiseAcceptPendingChange(value, _Tbpreciocaja)) { _Tbpreciocaja = value; OnPropertyChanged(); } } }

        private decimal? _Tbcajas;
        [XmlAttribute]
        public decimal? Tbcajas { get => _Tbcajas; set { if (RaiseAcceptPendingChange(value, _Tbcajas)) { _Tbcajas = value; OnPropertyChanged(); } } }

        private decimal? _Tbcantidad;
        [XmlAttribute]
        public decimal? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private long? _Listaprecios;
        [XmlAttribute]
        public long? Listaprecios { get => _Listaprecios; set { if (RaiseAcceptPendingChange(value, _Listaprecios)) { _Listaprecios = value; OnPropertyChanged(); } } }

        private string? _Tbcurrentitem;
        [XmlAttribute]
        public string? Tbcurrentitem { get => _Tbcurrentitem; set { if (RaiseAcceptPendingChange(value, _Tbcurrentitem)) { _Tbcurrentitem = value; OnPropertyChanged(); } } }

        private string? _Tbsumatotal;
        [XmlAttribute]
        public string? Tbsumatotal { get => _Tbsumatotal; set { if (RaiseAcceptPendingChange(value, _Tbsumatotal)) { _Tbsumatotal = value; OnPropertyChanged(); } } }

        private string? _Tbiva;
        [XmlAttribute]
        public string? Tbiva { get => _Tbiva; set { if (RaiseAcceptPendingChange(value, _Tbiva)) { _Tbiva = value; OnPropertyChanged(); } } }

        private string? _Tbtotal;
        [XmlAttribute]
        public string? Tbtotal { get => _Tbtotal; set { if (RaiseAcceptPendingChange(value, _Tbtotal)) { _Tbtotal = value; OnPropertyChanged(); } } }

        private string? _Tbcommandline;
        [XmlAttribute]
        public string? Tbcommandline { get => _Tbcommandline; set { if (RaiseAcceptPendingChange(value, _Tbcommandline)) { _Tbcommandline = value; OnPropertyChanged(); } } }

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
    public class WFMovilPuntoDeVentaWF_GridpvBindingModel : Validatable
    {

        public WFMovilPuntoDeVentaWF_GridpvBindingModel()
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

        private decimal? _Tasaieps;
        [XmlAttribute]
        public decimal? Tasaieps { get => _Tasaieps; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value; OnPropertyChanged(); } } }

        private decimal? _Descuentoporcentaje;
        [XmlAttribute]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value; OnPropertyChanged(); } } }

        private decimal? _Porcentajedescuentomanual;
        [XmlAttribute]
        public decimal? Porcentajedescuentomanual { get => _Porcentajedescuentomanual; set { if (RaiseAcceptPendingChange(value, _Porcentajedescuentomanual)) { _Porcentajedescuentomanual = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Tasaimpuesto;
        [XmlAttribute]
        public decimal? Tasaimpuesto { get => _Tasaimpuesto; set { if (RaiseAcceptPendingChange(value, _Tasaimpuesto)) { _Tasaimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private string? _Claveproducto;
        [XmlAttribute]
        public string? Claveproducto { get => _Claveproducto; set { if (RaiseAcceptPendingChange(value, _Claveproducto)) { _Claveproducto = value; OnPropertyChanged(); } } }

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

        private decimal? _Utilidadmovil;
        [XmlAttribute]
        public decimal? Utilidadmovil { get => _Utilidadmovil; set { if (RaiseAcceptPendingChange(value, _Utilidadmovil)) { _Utilidadmovil = value; OnPropertyChanged(); } } }

        private string? _Dgheight;
        [XmlAttribute]
        public string? Dgheight { get => _Dgheight; set { if (RaiseAcceptPendingChange(value, _Dgheight)) { _Dgheight = value; OnPropertyChanged(); } } }

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

