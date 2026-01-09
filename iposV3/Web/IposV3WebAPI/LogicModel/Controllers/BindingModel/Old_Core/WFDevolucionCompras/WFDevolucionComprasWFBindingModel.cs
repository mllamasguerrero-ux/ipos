
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
    public class WFDevolucionComprasWFBindingModel : Validatable
    {

        public WFDevolucionComprasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbcurrentitem;
        [XmlAttribute]
        public string? Tbcurrentitem { get => _Tbcurrentitem; set { if (RaiseAcceptPendingChange(value, _Tbcurrentitem)) { _Tbcurrentitem = value; OnPropertyChanged(); } } }

        private long? _Tipodiferenciainventarioidcombobox;
        [XmlAttribute]
        public long? Tipodiferenciainventarioidcombobox { get => _Tipodiferenciainventarioidcombobox; set { if (RaiseAcceptPendingChange(value, _Tipodiferenciainventarioidcombobox)) { _Tipodiferenciainventarioidcombobox = value; OnPropertyChanged(); } } }

        private long? _Cborigenfiscal;
        [XmlAttribute]
        public long? Cborigenfiscal { get => _Cborigenfiscal; set { if (RaiseAcceptPendingChange(value, _Cborigenfiscal)) { _Cborigenfiscal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechavence;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechavence { get => _Dtpfechavence; set { if (RaiseAcceptPendingChange(value, _Dtpfechavence)) { _Dtpfechavence = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private string? _Tbreferencias;
        [XmlAttribute]
        public string? Tbreferencias { get => _Tbreferencias; set { if (RaiseAcceptPendingChange(value, _Tbreferencias)) { _Tbreferencias = value; OnPropertyChanged(); } } }

        private string? _Tbsumatotal;
        [XmlAttribute]
        public string? Tbsumatotal { get => _Tbsumatotal; set { if (RaiseAcceptPendingChange(value, _Tbsumatotal)) { _Tbsumatotal = value; OnPropertyChanged(); } } }

        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private string? _Tbobservaciones;
        [XmlAttribute]
        public string? Tbobservaciones { get => _Tbobservaciones; set { if (RaiseAcceptPendingChange(value, _Tbobservaciones)) { _Tbobservaciones = value; OnPropertyChanged(); } } }

        private decimal? _Tbcantidad;
        [XmlAttribute]
        public decimal? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private decimal? _Tbcosto;
        [XmlAttribute]
        public decimal? Tbcosto { get => _Tbcosto; set { if (RaiseAcceptPendingChange(value, _Tbcosto)) { _Tbcosto = value; OnPropertyChanged(); } } }

        private decimal? _Tbdescuento;
        [XmlAttribute]
        public decimal? Tbdescuento { get => _Tbdescuento; set { if (RaiseAcceptPendingChange(value, _Tbdescuento)) { _Tbdescuento = value; OnPropertyChanged(); } } }

        private string? _Tbcommandline;
        [XmlAttribute]
        public string? Tbcommandline { get => _Tbcommandline; set { if (RaiseAcceptPendingChange(value, _Tbcommandline)) { _Tbcommandline = value; OnPropertyChanged(); } } }

        private string? _Tbpagostotaltransaccionbig;
        [XmlAttribute]
        public string? Tbpagostotaltransaccionbig { get => _Tbpagostotaltransaccionbig; set { if (RaiseAcceptPendingChange(value, _Tbpagostotaltransaccionbig)) { _Tbpagostotaltransaccionbig = value; OnPropertyChanged(); } } }

        private string? _Tbiva;
        [XmlAttribute]
        public string? Tbiva { get => _Tbiva; set { if (RaiseAcceptPendingChange(value, _Tbiva)) { _Tbiva = value; OnPropertyChanged(); } } }

        private string? _Tbstatus;
        [XmlAttribute]
        public string? Tbstatus { get => _Tbstatus; set { if (RaiseAcceptPendingChange(value, _Tbstatus)) { _Tbstatus = value; OnPropertyChanged(); } } }

        private string? _Tbtotal;
        [XmlAttribute]
        public string? Tbtotal { get => _Tbtotal; set { if (RaiseAcceptPendingChange(value, _Tbtotal)) { _Tbtotal = value; OnPropertyChanged(); } } }

        private string? _TipodiferenciainventarioidcomboboxClave;
        [XmlAttribute]
        public string? TipodiferenciainventarioidcomboboxClave { get => _TipodiferenciainventarioidcomboboxClave; set { if (RaiseAcceptPendingChange(value, _TipodiferenciainventarioidcomboboxClave)) { _TipodiferenciainventarioidcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _TipodiferenciainventarioidcomboboxNombre;
        [XmlAttribute]
        public string? TipodiferenciainventarioidcomboboxNombre { get => _TipodiferenciainventarioidcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _TipodiferenciainventarioidcomboboxNombre)) { _TipodiferenciainventarioidcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalClave;
        [XmlAttribute]
        public string? CborigenfiscalClave { get => _CborigenfiscalClave; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalClave)) { _CborigenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalNombre;
        [XmlAttribute]
        public string? CborigenfiscalNombre { get => _CborigenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalNombre)) { _CborigenfiscalNombre = value; OnPropertyChanged(); } } }

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
    public class WFDevolucionComprasWF_Get_venta_devolucion_refBindingModel : Validatable
    {

        public WFDevolucionComprasWF_Get_venta_devolucion_refBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctorefid;
        [XmlAttribute]
        public long? Doctorefid { get => _Doctorefid; set { if (RaiseAcceptPendingChange(value, _Doctorefid)) { _Doctorefid = value; OnPropertyChanged(); } } }

        private long? _Movtorefid;
        [XmlAttribute]
        public long? Movtorefid { get => _Movtorefid; set { if (RaiseAcceptPendingChange(value, _Movtorefid)) { _Movtorefid = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private string? _Claveproducto;
        [XmlAttribute]
        public string? Claveproducto { get => _Claveproducto; set { if (RaiseAcceptPendingChange(value, _Claveproducto)) { _Claveproducto = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadref;
        [XmlAttribute]
        public decimal? Cantidadref { get => _Cantidadref; set { if (RaiseAcceptPendingChange(value, _Cantidadref)) { _Cantidadref = value; OnPropertyChanged(); } } }

        private decimal? _Cantdisp;
        [XmlAttribute]
        public decimal? Cantdisp { get => _Cantdisp; set { if (RaiseAcceptPendingChange(value, _Cantdisp)) { _Cantdisp = value; OnPropertyChanged(); } } }

        private decimal? _Preciounidadref;
        [XmlAttribute]
        public decimal? Preciounidadref { get => _Preciounidadref; set { if (RaiseAcceptPendingChange(value, _Preciounidadref)) { _Preciounidadref = value; OnPropertyChanged(); } } }

        private decimal? _Importeref;
        [XmlAttribute]
        public decimal? Importeref { get => _Importeref; set { if (RaiseAcceptPendingChange(value, _Importeref)) { _Importeref = value; OnPropertyChanged(); } } }

        private decimal? _Descuentoref;
        [XmlAttribute]
        public decimal? Descuentoref { get => _Descuentoref; set { if (RaiseAcceptPendingChange(value, _Descuentoref)) { _Descuentoref = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private decimal? _Preciounidad;
        [XmlAttribute]
        public decimal? Preciounidad { get => _Preciounidad; set { if (RaiseAcceptPendingChange(value, _Preciounidad)) { _Preciounidad = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Cantidaddevuelta;
        [XmlAttribute]
        public decimal? Cantidaddevuelta { get => _Cantidaddevuelta; set { if (RaiseAcceptPendingChange(value, _Cantidaddevuelta)) { _Cantidaddevuelta = value; OnPropertyChanged(); } } }

        private decimal? _Cantdispdespues;
        [XmlAttribute]
        public decimal? Cantdispdespues { get => _Cantdispdespues; set { if (RaiseAcceptPendingChange(value, _Cantdispdespues)) { _Cantdispdespues = value; OnPropertyChanged(); } } }

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
    public class WFDevolucionComprasWF_GridpvBindingModel : Validatable
    {

        public WFDevolucionComprasWF_GridpvBindingModel()
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

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

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

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

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

