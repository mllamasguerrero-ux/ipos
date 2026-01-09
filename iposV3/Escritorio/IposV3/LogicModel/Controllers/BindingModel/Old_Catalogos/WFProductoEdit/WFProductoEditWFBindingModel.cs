
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
    public class WFProductoEditWFBindingModel : Validatable
    {

        public WFProductoEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtplastsale;
        [XmlAttribute]
        public DateTimeOffset? Dtplastsale { get => _Dtplastsale; set { if (RaiseAcceptPendingChange(value, _Dtplastsale)) { _Dtplastsale = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtplastpurchase;
        [XmlAttribute]
        public DateTimeOffset? Dtplastpurchase { get => _Dtplastpurchase; set { if (RaiseAcceptPendingChange(value, _Dtplastpurchase)) { _Dtplastpurchase = value; OnPropertyChanged(); } } }

        private long? _Productosat;
        [XmlAttribute]
        public long? Productosat { get => _Productosat; set { if (RaiseAcceptPendingChange(value, _Productosat)) { _Productosat = value; OnPropertyChanged(); } } }

        private string? _ProductosatClave;
        [XmlAttribute]
        public string? ProductosatClave { get => _ProductosatClave; set { if (RaiseAcceptPendingChange(value, _ProductosatClave)) { _ProductosatClave = value; OnPropertyChanged(); } } }

        private string? _ProductosatNombre;
        [XmlAttribute]
        public string? ProductosatNombre { get => _ProductosatNombre; set { if (RaiseAcceptPendingChange(value, _ProductosatNombre)) { _ProductosatNombre = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Plug;
        [XmlAttribute]
        public string? Plug { get => _Plug; set { if (RaiseAcceptPendingChange(value, _Plug)) { _Plug = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private BoolCN? _Descripcion_comodin;
        [XmlAttribute]
        public BoolCN? Descripcion_comodin { get => _Descripcion_comodin; set { if (RaiseAcceptPendingChange(value, _Descripcion_comodin)) { _Descripcion_comodin = value; OnPropertyChanged(); } } }

        private long? _Proveedor2id;
        [XmlAttribute]
        public long? Proveedor2id { get => _Proveedor2id; set { if (RaiseAcceptPendingChange(value, _Proveedor2id)) { _Proveedor2id = value; OnPropertyChanged(); } } }

        private string? _Proveedor2idClave;
        [XmlAttribute]
        public string? Proveedor2idClave { get => _Proveedor2idClave; set { if (RaiseAcceptPendingChange(value, _Proveedor2idClave)) { _Proveedor2idClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor2idNombre;
        [XmlAttribute]
        public string? Proveedor2idNombre { get => _Proveedor2idNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor2idNombre)) { _Proveedor2idNombre = value; OnPropertyChanged(); } } }

        private long? _Proveedor1id;
        [XmlAttribute]
        public long? Proveedor1id { get => _Proveedor1id; set { if (RaiseAcceptPendingChange(value, _Proveedor1id)) { _Proveedor1id = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idClave;
        [XmlAttribute]
        public string? Proveedor1idClave { get => _Proveedor1idClave; set { if (RaiseAcceptPendingChange(value, _Proveedor1idClave)) { _Proveedor1idClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idNombre;
        [XmlAttribute]
        public string? Proveedor1idNombre { get => _Proveedor1idNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1idNombre)) { _Proveedor1idNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejalote;
        [XmlAttribute]
        public BoolCN? Manejalote { get => _Manejalote; set { if (RaiseAcceptPendingChange(value, _Manejalote)) { _Manejalote = value; OnPropertyChanged(); } } }

        private BoolCN? _Eskit;
        [XmlAttribute]
        public BoolCN? Eskit { get => _Eskit; set { if (RaiseAcceptPendingChange(value, _Eskit)) { _Eskit = value; OnPropertyChanged(); } } }

        private long? _Marcaid;
        [XmlAttribute]
        public long? Marcaid { get => _Marcaid; set { if (RaiseAcceptPendingChange(value, _Marcaid)) { _Marcaid = value; OnPropertyChanged(); } } }

        private string? _MarcaidClave;
        [XmlAttribute]
        public string? MarcaidClave { get => _MarcaidClave; set { if (RaiseAcceptPendingChange(value, _MarcaidClave)) { _MarcaidClave = value; OnPropertyChanged(); } } }

        private string? _MarcaidNombre;
        [XmlAttribute]
        public string? MarcaidNombre { get => _MarcaidNombre; set { if (RaiseAcceptPendingChange(value, _MarcaidNombre)) { _MarcaidNombre = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _LineaidClave;
        [XmlAttribute]
        public string? LineaidClave { get => _LineaidClave; set { if (RaiseAcceptPendingChange(value, _LineaidClave)) { _LineaidClave = value; OnPropertyChanged(); } } }

        private string? _LineaidNombre;
        [XmlAttribute]
        public string? LineaidNombre { get => _LineaidNombre; set { if (RaiseAcceptPendingChange(value, _LineaidNombre)) { _LineaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimir;
        [XmlAttribute]
        public BoolCN? Imprimir { get => _Imprimir; set { if (RaiseAcceptPendingChange(value, _Imprimir)) { _Imprimir = value; OnPropertyChanged(); } } }

        private BoolCN? _Inventariable;
        [XmlAttribute]
        public BoolCN? Inventariable { get => _Inventariable; set { if (RaiseAcceptPendingChange(value, _Inventariable)) { _Inventariable = value; OnPropertyChanged(); } } }

        private long? _Clasificaid;
        [XmlAttribute]
        public long? Clasificaid { get => _Clasificaid; set { if (RaiseAcceptPendingChange(value, _Clasificaid)) { _Clasificaid = value; OnPropertyChanged(); } } }

        private string? _ClasificaidClave;
        [XmlAttribute]
        public string? ClasificaidClave { get => _ClasificaidClave; set { if (RaiseAcceptPendingChange(value, _ClasificaidClave)) { _ClasificaidClave = value; OnPropertyChanged(); } } }

        private string? _ClasificaidNombre;
        [XmlAttribute]
        public string? ClasificaidNombre { get => _ClasificaidNombre; set { if (RaiseAcceptPendingChange(value, _ClasificaidNombre)) { _ClasificaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Negativos;
        [XmlAttribute]
        public BoolCN? Negativos { get => _Negativos; set { if (RaiseAcceptPendingChange(value, _Negativos)) { _Negativos = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejastock;
        [XmlAttribute]
        public BoolCN? Manejastock { get => _Manejastock; set { if (RaiseAcceptPendingChange(value, _Manejastock)) { _Manejastock = value; OnPropertyChanged(); } } }

        private long? _Productosustitutoid;
        [XmlAttribute]
        public long? Productosustitutoid { get => _Productosustitutoid; set { if (RaiseAcceptPendingChange(value, _Productosustitutoid)) { _Productosustitutoid = value; OnPropertyChanged(); } } }

        private string? _ProductosustitutoidClave;
        [XmlAttribute]
        public string? ProductosustitutoidClave { get => _ProductosustitutoidClave; set { if (RaiseAcceptPendingChange(value, _ProductosustitutoidClave)) { _ProductosustitutoidClave = value; OnPropertyChanged(); } } }

        private string? _ProductosustitutoidNombre;
        [XmlAttribute]
        public string? ProductosustitutoidNombre { get => _ProductosustitutoidNombre; set { if (RaiseAcceptPendingChange(value, _ProductosustitutoidNombre)) { _ProductosustitutoidNombre = value; OnPropertyChanged(); } } }

        private string? _Sub_clave;
        [XmlAttribute]
        public string? Sub_clave { get => _Sub_clave; set { if (RaiseAcceptPendingChange(value, _Sub_clave)) { _Sub_clave = value; OnPropertyChanged(); } } }

        private BoolCN? _Sub_autogenerar;
        [XmlAttribute]
        public BoolCN? Sub_autogenerar { get => _Sub_autogenerar; set { if (RaiseAcceptPendingChange(value, _Sub_autogenerar)) { _Sub_autogenerar = value; OnPropertyChanged(); } } }

        private string? _Sub_descripcion2;
        [XmlAttribute]
        public string? Sub_descripcion2 { get => _Sub_descripcion2; set { if (RaiseAcceptPendingChange(value, _Sub_descripcion2)) { _Sub_descripcion2 = value; OnPropertyChanged(); } } }

        private long? _Unidad;
        [XmlAttribute]
        public long? Unidad { get => _Unidad; set { if (RaiseAcceptPendingChange(value, _Unidad)) { _Unidad = value; OnPropertyChanged(); } } }

        private long? _Unidad2;
        [XmlAttribute]
        public long? Unidad2 { get => _Unidad2; set { if (RaiseAcceptPendingChange(value, _Unidad2)) { _Unidad2 = value; OnPropertyChanged(); } } }

        private decimal? _Contenidovalor;
        [XmlAttribute]
        public decimal? Contenidovalor { get => _Contenidovalor; set { if (RaiseAcceptPendingChange(value, _Contenidovalor)) { _Contenidovalor = value; OnPropertyChanged(); } } }

        private long? _Sat_tipoembalajeid;
        [XmlAttribute]
        public long? Sat_tipoembalajeid { get => _Sat_tipoembalajeid; set { if (RaiseAcceptPendingChange(value, _Sat_tipoembalajeid)) { _Sat_tipoembalajeid = value; OnPropertyChanged(); } } }

        private string? _Sat_tipoembalajeidClave;
        [XmlAttribute]
        public string? Sat_tipoembalajeidClave { get => _Sat_tipoembalajeidClave; set { if (RaiseAcceptPendingChange(value, _Sat_tipoembalajeidClave)) { _Sat_tipoembalajeidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_tipoembalajeidNombre;
        [XmlAttribute]
        public string? Sat_tipoembalajeidNombre { get => _Sat_tipoembalajeidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_tipoembalajeidNombre)) { _Sat_tipoembalajeidNombre = value; OnPropertyChanged(); } } }

        private long? _Contenidoid;
        [XmlAttribute]
        public long? Contenidoid { get => _Contenidoid; set { if (RaiseAcceptPendingChange(value, _Contenidoid)) { _Contenidoid = value; OnPropertyChanged(); } } }

        private string? _Sub_ean;
        [XmlAttribute]
        public string? Sub_ean { get => _Sub_ean; set { if (RaiseAcceptPendingChange(value, _Sub_ean)) { _Sub_ean = value; OnPropertyChanged(); } } }

        private decimal? _U_empaque;
        [XmlAttribute]
        public decimal? U_empaque { get => _U_empaque; set { if (RaiseAcceptPendingChange(value, _U_empaque)) { _U_empaque = value; OnPropertyChanged(); } } }

        private decimal? _Menudeo;
        [XmlAttribute]
        public decimal? Menudeo { get => _Menudeo; set { if (RaiseAcceptPendingChange(value, _Menudeo)) { _Menudeo = value; OnPropertyChanged(); } } }

        private decimal? _Ini_mayo;
        [XmlAttribute]
        public decimal? Ini_mayo { get => _Ini_mayo; set { if (RaiseAcceptPendingChange(value, _Ini_mayo)) { _Ini_mayo = value; OnPropertyChanged(); } } }

        private long? _Sat_claveunidadpesoid;
        [XmlAttribute]
        public long? Sat_claveunidadpesoid { get => _Sat_claveunidadpesoid; set { if (RaiseAcceptPendingChange(value, _Sat_claveunidadpesoid)) { _Sat_claveunidadpesoid = value; OnPropertyChanged(); } } }

        private string? _Sat_claveunidadpesoidClave;
        [XmlAttribute]
        public string? Sat_claveunidadpesoidClave { get => _Sat_claveunidadpesoidClave; set { if (RaiseAcceptPendingChange(value, _Sat_claveunidadpesoidClave)) { _Sat_claveunidadpesoidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_claveunidadpesoidNombre;
        [XmlAttribute]
        public string? Sat_claveunidadpesoidNombre { get => _Sat_claveunidadpesoidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_claveunidadpesoidNombre)) { _Sat_claveunidadpesoidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Mayokgs;
        [XmlAttribute]
        public BoolCN? Mayokgs { get => _Mayokgs; set { if (RaiseAcceptPendingChange(value, _Mayokgs)) { _Mayokgs = value; OnPropertyChanged(); } } }

        private string? _Sub_texto1;
        [XmlAttribute]
        public string? Sub_texto1 { get => _Sub_texto1; set { if (RaiseAcceptPendingChange(value, _Sub_texto1)) { _Sub_texto1 = value; OnPropertyChanged(); } } }

        private string? _Sub_texto2;
        [XmlAttribute]
        public string? Sub_texto2 { get => _Sub_texto2; set { if (RaiseAcceptPendingChange(value, _Sub_texto2)) { _Sub_texto2 = value; OnPropertyChanged(); } } }

        private decimal? _Stock;
        [XmlAttribute]
        public decimal? Stock { get => _Stock; set { if (RaiseAcceptPendingChange(value, _Stock)) { _Stock = value; OnPropertyChanged(); } } }

        private decimal? _Stockmax;
        [XmlAttribute]
        public decimal? Stockmax { get => _Stockmax; set { if (RaiseAcceptPendingChange(value, _Stockmax)) { _Stockmax = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private decimal? _Peso;
        [XmlAttribute]
        public decimal? Peso { get => _Peso; set { if (RaiseAcceptPendingChange(value, _Peso)) { _Peso = value; OnPropertyChanged(); } } }

        private BoolCN? _Surtirporcaja;
        [XmlAttribute]
        public BoolCN? Surtirporcaja { get => _Surtirporcaja; set { if (RaiseAcceptPendingChange(value, _Surtirporcaja)) { _Surtirporcaja = value; OnPropertyChanged(); } } }

        private string? _Sub_texto3;
        [XmlAttribute]
        public string? Sub_texto3 { get => _Sub_texto3; set { if (RaiseAcceptPendingChange(value, _Sub_texto3)) { _Sub_texto3 = value; OnPropertyChanged(); } } }

        private string? _Sub_texto4;
        [XmlAttribute]
        public string? Sub_texto4 { get => _Sub_texto4; set { if (RaiseAcceptPendingChange(value, _Sub_texto4)) { _Sub_texto4 = value; OnPropertyChanged(); } } }

        private decimal? _Cantxpieza;
        [XmlAttribute]
        public decimal? Cantxpieza { get => _Cantxpieza; set { if (RaiseAcceptPendingChange(value, _Cantxpieza)) { _Cantxpieza = value; OnPropertyChanged(); } } }

        private BoolCN? _Valxsuc;
        [XmlAttribute]
        public BoolCN? Valxsuc { get => _Valxsuc; set { if (RaiseAcceptPendingChange(value, _Valxsuc)) { _Valxsuc = value; OnPropertyChanged(); } } }

        private long? _Txtplazofb;
        [XmlAttribute]
        public long? Txtplazofb { get => _Txtplazofb; set { if (RaiseAcceptPendingChange(value, _Txtplazofb)) { _Txtplazofb = value; OnPropertyChanged(); } } }

        private string? _TxtplazofbClave;
        [XmlAttribute]
        public string? TxtplazofbClave { get => _TxtplazofbClave; set { if (RaiseAcceptPendingChange(value, _TxtplazofbClave)) { _TxtplazofbClave = value; OnPropertyChanged(); } } }

        private string? _TxtplazofbNombre;
        [XmlAttribute]
        public string? TxtplazofbNombre { get => _TxtplazofbNombre; set { if (RaiseAcceptPendingChange(value, _TxtplazofbNombre)) { _TxtplazofbNombre = value; OnPropertyChanged(); } } }

        private string? _Sub_texto5;
        [XmlAttribute]
        public string? Sub_texto5 { get => _Sub_texto5; set { if (RaiseAcceptPendingChange(value, _Sub_texto5)) { _Sub_texto5 = value; OnPropertyChanged(); } } }

        private string? _Sub_texto6;
        [XmlAttribute]
        public string? Sub_texto6 { get => _Sub_texto6; set { if (RaiseAcceptPendingChange(value, _Sub_texto6)) { _Sub_texto6 = value; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute]
        public decimal? Precio2 { get => _Precio2; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute]
        public decimal? Precio5 { get => _Precio5; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value; OnPropertyChanged(); } } }

        private decimal? _Precio6;
        [XmlAttribute]
        public decimal? Precio6 { get => _Precio6; set { if (RaiseAcceptPendingChange(value, _Precio6)) { _Precio6 = value; OnPropertyChanged(); } } }

        private decimal? _Limiteprecio2;
        [XmlAttribute]
        public decimal? Limiteprecio2 { get => _Limiteprecio2; set { if (RaiseAcceptPendingChange(value, _Limiteprecio2)) { _Limiteprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Preciomaximopublico;
        [XmlAttribute]
        public decimal? Preciomaximopublico { get => _Preciomaximopublico; set { if (RaiseAcceptPendingChange(value, _Preciomaximopublico)) { _Preciomaximopublico = value; OnPropertyChanged(); } } }

        private decimal? _Sub_numero2;
        [XmlAttribute]
        public decimal? Sub_numero2 { get => _Sub_numero2; set { if (RaiseAcceptPendingChange(value, _Sub_numero2)) { _Sub_numero2 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_numero3;
        [XmlAttribute]
        public decimal? Sub_numero3 { get => _Sub_numero3; set { if (RaiseAcceptPendingChange(value, _Sub_numero3)) { _Sub_numero3 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_numero4;
        [XmlAttribute]
        public decimal? Sub_numero4 { get => _Sub_numero4; set { if (RaiseAcceptPendingChange(value, _Sub_numero4)) { _Sub_numero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Sub_fecha1;
        [XmlAttribute]
        public DateTimeOffset? Sub_fecha1 { get => _Sub_fecha1; set { if (RaiseAcceptPendingChange(value, _Sub_fecha1)) { _Sub_fecha1 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_numero1;
        [XmlAttribute]
        public decimal? Sub_numero1 { get => _Sub_numero1; set { if (RaiseAcceptPendingChange(value, _Sub_numero1)) { _Sub_numero1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Sub_fecha2;
        [XmlAttribute]
        public DateTimeOffset? Sub_fecha2 { get => _Sub_fecha2; set { if (RaiseAcceptPendingChange(value, _Sub_fecha2)) { _Sub_fecha2 = value; OnPropertyChanged(); } } }

        private string? _Ean;
        [XmlAttribute]
        public string? Ean { get => _Ean; set { if (RaiseAcceptPendingChange(value, _Ean)) { _Ean = value; OnPropertyChanged(); } } }

        private string? _Cbarras;
        [XmlAttribute]
        public string? Cbarras { get => _Cbarras; set { if (RaiseAcceptPendingChange(value, _Cbarras)) { _Cbarras = value; OnPropertyChanged(); } } }

        private string? _Cempaque;
        [XmlAttribute]
        public string? Cempaque { get => _Cempaque; set { if (RaiseAcceptPendingChange(value, _Cempaque)) { _Cempaque = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private decimal? _Sub_precio1;
        [XmlAttribute]
        public decimal? Sub_precio1 { get => _Sub_precio1; set { if (RaiseAcceptPendingChange(value, _Sub_precio1)) { _Sub_precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_precio2;
        [XmlAttribute]
        public decimal? Sub_precio2 { get => _Sub_precio2; set { if (RaiseAcceptPendingChange(value, _Sub_precio2)) { _Sub_precio2 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_precio3;
        [XmlAttribute]
        public decimal? Sub_precio3 { get => _Sub_precio3; set { if (RaiseAcceptPendingChange(value, _Sub_precio3)) { _Sub_precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_precio4;
        [XmlAttribute]
        public decimal? Sub_precio4 { get => _Sub_precio4; set { if (RaiseAcceptPendingChange(value, _Sub_precio4)) { _Sub_precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_precio5;
        [XmlAttribute]
        public decimal? Sub_precio5 { get => _Sub_precio5; set { if (RaiseAcceptPendingChange(value, _Sub_precio5)) { _Sub_precio5 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_limiteprecio2;
        [XmlAttribute]
        public decimal? Sub_limiteprecio2 { get => _Sub_limiteprecio2; set { if (RaiseAcceptPendingChange(value, _Sub_limiteprecio2)) { _Sub_limiteprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Sub_preciomaximopublico;
        [XmlAttribute]
        public decimal? Sub_preciomaximopublico { get => _Sub_preciomaximopublico; set { if (RaiseAcceptPendingChange(value, _Sub_preciomaximopublico)) { _Sub_preciomaximopublico = value; OnPropertyChanged(); } } }

        private decimal? _Sprecio2;
        [XmlAttribute]
        public decimal? Sprecio2 { get => _Sprecio2; set { if (RaiseAcceptPendingChange(value, _Sprecio2)) { _Sprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Sprecio1;
        [XmlAttribute]
        public decimal? Sprecio1 { get => _Sprecio1; set { if (RaiseAcceptPendingChange(value, _Sprecio1)) { _Sprecio1 = value; OnPropertyChanged(); } } }

        private decimal? _Sprecio3;
        [XmlAttribute]
        public decimal? Sprecio3 { get => _Sprecio3; set { if (RaiseAcceptPendingChange(value, _Sprecio3)) { _Sprecio3 = value; OnPropertyChanged(); } } }

        private decimal? _Sprecio4;
        [XmlAttribute]
        public decimal? Sprecio4 { get => _Sprecio4; set { if (RaiseAcceptPendingChange(value, _Sprecio4)) { _Sprecio4 = value; OnPropertyChanged(); } } }

        private decimal? _Sprecio5;
        [XmlAttribute]
        public decimal? Sprecio5 { get => _Sprecio5; set { if (RaiseAcceptPendingChange(value, _Sprecio5)) { _Sprecio5 = value; OnPropertyChanged(); } } }

        private decimal? _Costoendolar;
        [XmlAttribute]
        public decimal? Costoendolar { get => _Costoendolar; set { if (RaiseAcceptPendingChange(value, _Costoendolar)) { _Costoendolar = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Preciosugerido;
        [XmlAttribute]
        public decimal? Preciosugerido { get => _Preciosugerido; set { if (RaiseAcceptPendingChange(value, _Preciosugerido)) { _Preciosugerido = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilprecio2;
        [XmlAttribute]
        public decimal? Porcutilprecio2 { get => _Porcutilprecio2; set { if (RaiseAcceptPendingChange(value, _Porcutilprecio2)) { _Porcutilprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilprecio1;
        [XmlAttribute]
        public decimal? Porcutilprecio1 { get => _Porcutilprecio1; set { if (RaiseAcceptPendingChange(value, _Porcutilprecio1)) { _Porcutilprecio1 = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilprecio3;
        [XmlAttribute]
        public decimal? Porcutilprecio3 { get => _Porcutilprecio3; set { if (RaiseAcceptPendingChange(value, _Porcutilprecio3)) { _Porcutilprecio3 = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilprecio4;
        [XmlAttribute]
        public decimal? Porcutilprecio4 { get => _Porcutilprecio4; set { if (RaiseAcceptPendingChange(value, _Porcutilprecio4)) { _Porcutilprecio4 = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilprecio5;
        [XmlAttribute]
        public decimal? Porcutilprecio5 { get => _Porcutilprecio5; set { if (RaiseAcceptPendingChange(value, _Porcutilprecio5)) { _Porcutilprecio5 = value; OnPropertyChanged(); } } }

        private BoolCN? _Sub_precios;
        [XmlAttribute]
        public BoolCN? Sub_precios { get => _Sub_precios; set { if (RaiseAcceptPendingChange(value, _Sub_precios)) { _Sub_precios = value; OnPropertyChanged(); } } }

        private BoolCN? _Cambiarprecio;
        [XmlAttribute]
        public BoolCN? Cambiarprecio { get => _Cambiarprecio; set { if (RaiseAcceptPendingChange(value, _Cambiarprecio)) { _Cambiarprecio = value; OnPropertyChanged(); } } }

        private BoolCN? _Requierereceta;
        [XmlAttribute]
        public BoolCN? Requierereceta { get => _Requierereceta; set { if (RaiseAcceptPendingChange(value, _Requierereceta)) { _Requierereceta = value; OnPropertyChanged(); } } }

        private decimal? _Sub_comision;
        [XmlAttribute]
        public decimal? Sub_comision { get => _Sub_comision; set { if (RaiseAcceptPendingChange(value, _Sub_comision)) { _Sub_comision = value; OnPropertyChanged(); } } }

        private decimal? _Sub_oferta;
        [XmlAttribute]
        public decimal? Sub_oferta { get => _Sub_oferta; set { if (RaiseAcceptPendingChange(value, _Sub_oferta)) { _Sub_oferta = value; OnPropertyChanged(); } } }

        private BoolCN? _Sub_oferta__1;
        [XmlAttribute]
        public BoolCN? Sub_oferta__1 { get => _Sub_oferta__1; set { if (RaiseAcceptPendingChange(value, _Sub_oferta__1)) { _Sub_oferta__1 = value; OnPropertyChanged(); } } }

        private BoolCN? _Sub_comision__1;
        [XmlAttribute]
        public BoolCN? Sub_comision__1 { get => _Sub_comision__1; set { if (RaiseAcceptPendingChange(value, _Sub_comision__1)) { _Sub_comision__1 = value; OnPropertyChanged(); } } }

        private string? _Costoreposicion;
        [XmlAttribute]
        public string? Costoreposicion { get => _Costoreposicion; set { if (RaiseAcceptPendingChange(value, _Costoreposicion)) { _Costoreposicion = value; OnPropertyChanged(); } } }

        private string? _Costoultimo;
        [XmlAttribute]
        public string? Costoultimo { get => _Costoultimo; set { if (RaiseAcceptPendingChange(value, _Costoultimo)) { _Costoultimo = value; OnPropertyChanged(); } } }

        private string? _Costopromedio;
        [XmlAttribute]
        public string? Costopromedio { get => _Costopromedio; set { if (RaiseAcceptPendingChange(value, _Costopromedio)) { _Costopromedio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechacambioprecio;
        [XmlAttribute]
        public DateTimeOffset? Fechacambioprecio { get => _Fechacambioprecio; set { if (RaiseAcceptPendingChange(value, _Fechacambioprecio)) { _Fechacambioprecio = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejaloteimportado;
        [XmlAttribute]
        public BoolCN? Manejaloteimportado { get => _Manejaloteimportado; set { if (RaiseAcceptPendingChange(value, _Manejaloteimportado)) { _Manejaloteimportado = value; OnPropertyChanged(); } } }

        private long? _Monedaid;
        [XmlAttribute]
        public long? Monedaid { get => _Monedaid; set { if (RaiseAcceptPendingChange(value, _Monedaid)) { _Monedaid = value; OnPropertyChanged(); } } }

        private string? _MonedaidClave;
        [XmlAttribute]
        public string? MonedaidClave { get => _MonedaidClave; set { if (RaiseAcceptPendingChange(value, _MonedaidClave)) { _MonedaidClave = value; OnPropertyChanged(); } } }

        private string? _MonedaidNombre;
        [XmlAttribute]
        public string? MonedaidNombre { get => _MonedaidNombre; set { if (RaiseAcceptPendingChange(value, _MonedaidNombre)) { _MonedaidNombre = value; OnPropertyChanged(); } } }

        private long? _Tasaivaid;
        [XmlAttribute]
        public long? Tasaivaid { get => _Tasaivaid; set { if (RaiseAcceptPendingChange(value, _Tasaivaid)) { _Tasaivaid = value; OnPropertyChanged(); } } }

        private string? _TasaivaidClave;
        [XmlAttribute]
        public string? TasaivaidClave { get => _TasaivaidClave; set { if (RaiseAcceptPendingChange(value, _TasaivaidClave)) { _TasaivaidClave = value; OnPropertyChanged(); } } }

        private string? _TasaivaidNombre;
        [XmlAttribute]
        public string? TasaivaidNombre { get => _TasaivaidNombre; set { if (RaiseAcceptPendingChange(value, _TasaivaidNombre)) { _TasaivaidNombre = value; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute]
        public decimal? Tasaieps { get => _Tasaieps; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value; OnPropertyChanged(); } } }

        private decimal? _Comision;
        [XmlAttribute]
        public decimal? Comision { get => _Comision; set { if (RaiseAcceptPendingChange(value, _Comision)) { _Comision = value; OnPropertyChanged(); } } }

        private decimal? _Oferta;
        [XmlAttribute]
        public decimal? Oferta { get => _Oferta; set { if (RaiseAcceptPendingChange(value, _Oferta)) { _Oferta = value; OnPropertyChanged(); } } }

        private string? _Cuentapredial;
        [XmlAttribute]
        public string? Cuentapredial { get => _Cuentapredial; set { if (RaiseAcceptPendingChange(value, _Cuentapredial)) { _Cuentapredial = value; OnPropertyChanged(); } } }

        private decimal? _Minutilidad;
        [XmlAttribute]
        public decimal? Minutilidad { get => _Minutilidad; set { if (RaiseAcceptPendingChange(value, _Minutilidad)) { _Minutilidad = value; OnPropertyChanged(); } } }

        private decimal? _Preciotope;
        [XmlAttribute]
        public decimal? Preciotope { get => _Preciotope; set { if (RaiseAcceptPendingChange(value, _Preciotope)) { _Preciotope = value; OnPropertyChanged(); } } }

        private BoolCN? _Tipoabc;
        [XmlAttribute]
        public BoolCN? Tipoabc { get => _Tipoabc; set { if (RaiseAcceptPendingChange(value, _Tipoabc)) { _Tipoabc = value; OnPropertyChanged(); } } }

        private BoolCN? _Preciomat;
        [XmlAttribute]
        public BoolCN? Preciomat { get => _Preciomat; set { if (RaiseAcceptPendingChange(value, _Preciomat)) { _Preciomat = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

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

        private DateTimeOffset? _Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Fecha1 { get => _Fecha1; set { if (RaiseAcceptPendingChange(value, _Fecha1)) { _Fecha1 = value; OnPropertyChanged(); } } }

        private BoolCN? _Espeligroso;
        [XmlAttribute]
        public BoolCN? Espeligroso { get => _Espeligroso; set { if (RaiseAcceptPendingChange(value, _Espeligroso)) { _Espeligroso = value; OnPropertyChanged(); } } }

        private decimal? _Numero4;
        [XmlAttribute]
        public decimal? Numero4 { get => _Numero4; set { if (RaiseAcceptPendingChange(value, _Numero4)) { _Numero4 = value; OnPropertyChanged(); } } }

        private decimal? _Numero3;
        [XmlAttribute]
        public decimal? Numero3 { get => _Numero3; set { if (RaiseAcceptPendingChange(value, _Numero3)) { _Numero3 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Fecha2 { get => _Fecha2; set { if (RaiseAcceptPendingChange(value, _Fecha2)) { _Fecha2 = value; OnPropertyChanged(); } } }

        private long? _Sat_matpeligrosoid;
        [XmlAttribute]
        public long? Sat_matpeligrosoid { get => _Sat_matpeligrosoid; set { if (RaiseAcceptPendingChange(value, _Sat_matpeligrosoid)) { _Sat_matpeligrosoid = value; OnPropertyChanged(); } } }

        private string? _Sat_matpeligrosoidClave;
        [XmlAttribute]
        public string? Sat_matpeligrosoidClave { get => _Sat_matpeligrosoidClave; set { if (RaiseAcceptPendingChange(value, _Sat_matpeligrosoidClave)) { _Sat_matpeligrosoidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_matpeligrosoidNombre;
        [XmlAttribute]
        public string? Sat_matpeligrosoidNombre { get => _Sat_matpeligrosoidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_matpeligrosoidNombre)) { _Sat_matpeligrosoidNombre = value; OnPropertyChanged(); } } }

        private string? _Sub_nuevaimagen;
        [XmlAttribute]
        public string? Sub_nuevaimagen { get => _Sub_nuevaimagen; set { if (RaiseAcceptPendingChange(value, _Sub_nuevaimagen)) { _Sub_nuevaimagen = value; OnPropertyChanged(); } } }

        private string? _Sub_imagen;
        [XmlAttribute]
        public string? Sub_imagen { get => _Sub_imagen; set { if (RaiseAcceptPendingChange(value, _Sub_imagen)) { _Sub_imagen = value; OnPropertyChanged(); } } }

        private string? _Nuevaimagen;
        [XmlAttribute]
        public string? Nuevaimagen { get => _Nuevaimagen; set { if (RaiseAcceptPendingChange(value, _Nuevaimagen)) { _Nuevaimagen = value; OnPropertyChanged(); } } }

        private string? _Imagen;
        [XmlAttribute]
        public string? Imagen { get => _Imagen; set { if (RaiseAcceptPendingChange(value, _Imagen)) { _Imagen = value; OnPropertyChanged(); } } }

        private decimal? _Desctope;
        [XmlAttribute]
        public decimal? Desctope { get => _Desctope; set { if (RaiseAcceptPendingChange(value, _Desctope)) { _Desctope = value; OnPropertyChanged(); } } }

        private string? _Texto1;
        [XmlAttribute]
        public string? Texto1 { get => _Texto1; set { if (RaiseAcceptPendingChange(value, _Texto1)) { _Texto1 = value; OnPropertyChanged(); } } }

        private string? _Texto2;
        [XmlAttribute]
        public string? Texto2 { get => _Texto2; set { if (RaiseAcceptPendingChange(value, _Texto2)) { _Texto2 = value; OnPropertyChanged(); } } }

        private decimal? _Margen;
        [XmlAttribute]
        public decimal? Margen { get => _Margen; set { if (RaiseAcceptPendingChange(value, _Margen)) { _Margen = value; OnPropertyChanged(); } } }

        private decimal? _Descpes;
        [XmlAttribute]
        public decimal? Descpes { get => _Descpes; set { if (RaiseAcceptPendingChange(value, _Descpes)) { _Descpes = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimircomanda;
        [XmlAttribute]
        public BoolCN? Imprimircomanda { get => _Imprimircomanda; set { if (RaiseAcceptPendingChange(value, _Imprimircomanda)) { _Imprimircomanda = value; OnPropertyChanged(); } } }

        private long? _Listaprecmediomayid;
        [XmlAttribute]
        public long? Listaprecmediomayid { get => _Listaprecmediomayid; set { if (RaiseAcceptPendingChange(value, _Listaprecmediomayid)) { _Listaprecmediomayid = value; OnPropertyChanged(); } } }

        private decimal? _Cantmediomay;
        [XmlAttribute]
        public decimal? Cantmediomay { get => _Cantmediomay; set { if (RaiseAcceptPendingChange(value, _Cantmediomay)) { _Cantmediomay = value; OnPropertyChanged(); } } }

        private long? _Listaprecmayoreoid;
        [XmlAttribute]
        public long? Listaprecmayoreoid { get => _Listaprecmayoreoid; set { if (RaiseAcceptPendingChange(value, _Listaprecmayoreoid)) { _Listaprecmayoreoid = value; OnPropertyChanged(); } } }

        private decimal? _Cantmayoreo;
        [XmlAttribute]
        public decimal? Cantmayoreo { get => _Cantmayoreo; set { if (RaiseAcceptPendingChange(value, _Cantmayoreo)) { _Cantmayoreo = value; OnPropertyChanged(); } } }

        private string? _Texto3;
        [XmlAttribute]
        public string? Texto3 { get => _Texto3; set { if (RaiseAcceptPendingChange(value, _Texto3)) { _Texto3 = value; OnPropertyChanged(); } } }

        private string? _Texto4;
        [XmlAttribute]
        public string? Texto4 { get => _Texto4; set { if (RaiseAcceptPendingChange(value, _Texto4)) { _Texto4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vigenciaprodkit;
        [XmlAttribute]
        public DateTimeOffset? Vigenciaprodkit { get => _Vigenciaprodkit; set { if (RaiseAcceptPendingChange(value, _Vigenciaprodkit)) { _Vigenciaprodkit = value; OnPropertyChanged(); } } }

        private decimal? _Kitivapromedio;
        [XmlAttribute]
        public decimal? Kitivapromedio { get => _Kitivapromedio; set { if (RaiseAcceptPendingChange(value, _Kitivapromedio)) { _Kitivapromedio = value; OnPropertyChanged(); } } }

        private decimal? _Kitiepspromedio;
        [XmlAttribute]
        public decimal? Kitiepspromedio { get => _Kitiepspromedio; set { if (RaiseAcceptPendingChange(value, _Kitiepspromedio)) { _Kitiepspromedio = value; OnPropertyChanged(); } } }

        private decimal? _Kitcostosinimp;
        [XmlAttribute]
        public decimal? Kitcostosinimp { get => _Kitcostosinimp; set { if (RaiseAcceptPendingChange(value, _Kitcostosinimp)) { _Kitcostosinimp = value; OnPropertyChanged(); } } }

        private decimal? _Kitsumaiva;
        [XmlAttribute]
        public decimal? Kitsumaiva { get => _Kitsumaiva; set { if (RaiseAcceptPendingChange(value, _Kitsumaiva)) { _Kitsumaiva = value; OnPropertyChanged(); } } }

        private decimal? _Kitsumaieps;
        [XmlAttribute]
        public decimal? Kitsumaieps { get => _Kitsumaieps; set { if (RaiseAcceptPendingChange(value, _Kitsumaieps)) { _Kitsumaieps = value; OnPropertyChanged(); } } }

        private decimal? _Kitsumacostototal;
        [XmlAttribute]
        public decimal? Kitsumacostototal { get => _Kitsumacostototal; set { if (RaiseAcceptPendingChange(value, _Kitsumacostototal)) { _Kitsumacostototal = value; OnPropertyChanged(); } } }

        private BoolCN? _Kittienevig;
        [XmlAttribute]
        public BoolCN? Kittienevig { get => _Kittienevig; set { if (RaiseAcceptPendingChange(value, _Kittienevig)) { _Kittienevig = value; OnPropertyChanged(); } } }

        private BoolCN? _Kitimpfijo;
        [XmlAttribute]
        public BoolCN? Kitimpfijo { get => _Kitimpfijo; set { if (RaiseAcceptPendingChange(value, _Kitimpfijo)) { _Kitimpfijo = value; OnPropertyChanged(); } } }

        private string? _Productopartedescripcion;
        [XmlAttribute]
        public string? Productopartedescripcion { get => _Productopartedescripcion; set { if (RaiseAcceptPendingChange(value, _Productopartedescripcion)) { _Productopartedescripcion = value; OnPropertyChanged(); } } }

        private string? _Productopartenombre;
        [XmlAttribute]
        public string? Productopartenombre { get => _Productopartenombre; set { if (RaiseAcceptPendingChange(value, _Productopartenombre)) { _Productopartenombre = value; OnPropertyChanged(); } } }

        private string? _Productopartecosto;
        [XmlAttribute]
        public string? Productopartecosto { get => _Productopartecosto; set { if (RaiseAcceptPendingChange(value, _Productopartecosto)) { _Productopartecosto = value; OnPropertyChanged(); } } }

        private string? _Tbcodigoproductoparte;
        [XmlAttribute]
        public string? Tbcodigoproductoparte { get => _Tbcodigoproductoparte; set { if (RaiseAcceptPendingChange(value, _Tbcodigoproductoparte)) { _Tbcodigoproductoparte = value; OnPropertyChanged(); } } }

        private decimal? _Costoparte;
        [XmlAttribute]
        public decimal? Costoparte { get => _Costoparte; set { if (RaiseAcceptPendingChange(value, _Costoparte)) { _Costoparte = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadparte;
        [XmlAttribute]
        public decimal? Cantidadparte { get => _Cantidadparte; set { if (RaiseAcceptPendingChange(value, _Cantidadparte)) { _Cantidadparte = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vigenciaprodpromo;
        [XmlAttribute]
        public DateTimeOffset? Vigenciaprodpromo { get => _Vigenciaprodpromo; set { if (RaiseAcceptPendingChange(value, _Vigenciaprodpromo)) { _Vigenciaprodpromo = value; OnPropertyChanged(); } } }

        private long? _Baseprodpromoid;
        [XmlAttribute]
        public long? Baseprodpromoid { get => _Baseprodpromoid; set { if (RaiseAcceptPendingChange(value, _Baseprodpromoid)) { _Baseprodpromoid = value; OnPropertyChanged(); } } }

        private string? _BaseprodpromoidClave;
        [XmlAttribute]
        public string? BaseprodpromoidClave { get => _BaseprodpromoidClave; set { if (RaiseAcceptPendingChange(value, _BaseprodpromoidClave)) { _BaseprodpromoidClave = value; OnPropertyChanged(); } } }

        private string? _BaseprodpromoidNombre;
        [XmlAttribute]
        public string? BaseprodpromoidNombre { get => _BaseprodpromoidNombre; set { if (RaiseAcceptPendingChange(value, _BaseprodpromoidNombre)) { _BaseprodpromoidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Esprodpromo;
        [XmlAttribute]
        public BoolCN? Esprodpromo { get => _Esprodpromo; set { if (RaiseAcceptPendingChange(value, _Esprodpromo)) { _Esprodpromo = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodassucursales;
        [XmlAttribute]
        public BoolCN? Cbtodassucursales { get => _Cbtodassucursales; set { if (RaiseAcceptPendingChange(value, _Cbtodassucursales)) { _Cbtodassucursales = value; OnPropertyChanged(); } } }

        private string? _UnidadClave;
        [XmlAttribute]
        public string? UnidadClave { get => _UnidadClave; set { if (RaiseAcceptPendingChange(value, _UnidadClave)) { _UnidadClave = value; OnPropertyChanged(); } } }

        private string? _UnidadNombre;
        [XmlAttribute]
        public string? UnidadNombre { get => _UnidadNombre; set { if (RaiseAcceptPendingChange(value, _UnidadNombre)) { _UnidadNombre = value; OnPropertyChanged(); } } }

        private string? _Unidad2Clave;
        [XmlAttribute]
        public string? Unidad2Clave { get => _Unidad2Clave; set { if (RaiseAcceptPendingChange(value, _Unidad2Clave)) { _Unidad2Clave = value; OnPropertyChanged(); } } }

        private string? _Unidad2Nombre;
        [XmlAttribute]
        public string? Unidad2Nombre { get => _Unidad2Nombre; set { if (RaiseAcceptPendingChange(value, _Unidad2Nombre)) { _Unidad2Nombre = value; OnPropertyChanged(); } } }

        private string? _ContenidoidClave;
        [XmlAttribute]
        public string? ContenidoidClave { get => _ContenidoidClave; set { if (RaiseAcceptPendingChange(value, _ContenidoidClave)) { _ContenidoidClave = value; OnPropertyChanged(); } } }

        private string? _ContenidoidNombre;
        [XmlAttribute]
        public string? ContenidoidNombre { get => _ContenidoidNombre; set { if (RaiseAcceptPendingChange(value, _ContenidoidNombre)) { _ContenidoidNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecmediomayidClave;
        [XmlAttribute]
        public string? ListaprecmediomayidClave { get => _ListaprecmediomayidClave; set { if (RaiseAcceptPendingChange(value, _ListaprecmediomayidClave)) { _ListaprecmediomayidClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecmediomayidNombre;
        [XmlAttribute]
        public string? ListaprecmediomayidNombre { get => _ListaprecmediomayidNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecmediomayidNombre)) { _ListaprecmediomayidNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecmayoreoidClave;
        [XmlAttribute]
        public string? ListaprecmayoreoidClave { get => _ListaprecmayoreoidClave; set { if (RaiseAcceptPendingChange(value, _ListaprecmayoreoidClave)) { _ListaprecmayoreoidClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecmayoreoidNombre;
        [XmlAttribute]
        public string? ListaprecmayoreoidNombre { get => _ListaprecmayoreoidNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecmayoreoidNombre)) { _ListaprecmayoreoidNombre = value; OnPropertyChanged(); } } }

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
    public class WFProductoEditWF_ProductoshijoBindingModel : Validatable
    {

        public WFProductoEditWF_ProductoshijoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private long? _Modificadopor_userid;
        [XmlAttribute]
        public long? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Ean;
        [XmlAttribute]
        public string? Ean { get => _Ean; set { if (RaiseAcceptPendingChange(value, _Ean)) { _Ean = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute]
        public decimal? Precio2 { get => _Precio2; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute]
        public decimal? Precio5 { get => _Precio5; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value; OnPropertyChanged(); } } }

        private long? _Tasaivaid;
        [XmlAttribute]
        public long? Tasaivaid { get => _Tasaivaid; set { if (RaiseAcceptPendingChange(value, _Tasaivaid)) { _Tasaivaid = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private long? _Monedaid;
        [XmlAttribute]
        public long? Monedaid { get => _Monedaid; set { if (RaiseAcceptPendingChange(value, _Monedaid)) { _Monedaid = value; OnPropertyChanged(); } } }

        private decimal? _Limiteprecio2;
        [XmlAttribute]
        public decimal? Limiteprecio2 { get => _Limiteprecio2; set { if (RaiseAcceptPendingChange(value, _Limiteprecio2)) { _Limiteprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Preciomaximopublico;
        [XmlAttribute]
        public decimal? Preciomaximopublico { get => _Preciomaximopublico; set { if (RaiseAcceptPendingChange(value, _Preciomaximopublico)) { _Preciomaximopublico = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private string? _Unidad;
        [XmlAttribute]
        public string? Unidad { get => _Unidad; set { if (RaiseAcceptPendingChange(value, _Unidad)) { _Unidad = value; OnPropertyChanged(); } } }

        private decimal? _Comision;
        [XmlAttribute]
        public decimal? Comision { get => _Comision; set { if (RaiseAcceptPendingChange(value, _Comision)) { _Comision = value; OnPropertyChanged(); } } }

        private decimal? _Oferta;
        [XmlAttribute]
        public decimal? Oferta { get => _Oferta; set { if (RaiseAcceptPendingChange(value, _Oferta)) { _Oferta = value; OnPropertyChanged(); } } }

        private decimal? _Existenciafacturado;
        [XmlAttribute]
        public decimal? Existenciafacturado { get => _Existenciafacturado; set { if (RaiseAcceptPendingChange(value, _Existenciafacturado)) { _Existenciafacturado = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaremisionado;
        [XmlAttribute]
        public decimal? Existenciaremisionado { get => _Existenciaremisionado; set { if (RaiseAcceptPendingChange(value, _Existenciaremisionado)) { _Existenciaremisionado = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaindefinido;
        [XmlAttribute]
        public decimal? Existenciaindefinido { get => _Existenciaindefinido; set { if (RaiseAcceptPendingChange(value, _Existenciaindefinido)) { _Existenciaindefinido = value; OnPropertyChanged(); } } }

        private string? _Esproductofinal;
        [XmlAttribute]
        public string? Esproductofinal { get => _Esproductofinal; set { if (RaiseAcceptPendingChange(value, _Esproductofinal)) { _Esproductofinal = value; OnPropertyChanged(); } } }

        private string? _Esproductopadre;
        [XmlAttribute]
        public string? Esproductopadre { get => _Esproductopadre; set { if (RaiseAcceptPendingChange(value, _Esproductopadre)) { _Esproductopadre = value; OnPropertyChanged(); } } }

        private string? _Essubproducto;
        [XmlAttribute]
        public string? Essubproducto { get => _Essubproducto; set { if (RaiseAcceptPendingChange(value, _Essubproducto)) { _Essubproducto = value; OnPropertyChanged(); } } }

        private string? _Tomarpreciopadre;
        [XmlAttribute]
        public string? Tomarpreciopadre { get => _Tomarpreciopadre; set { if (RaiseAcceptPendingChange(value, _Tomarpreciopadre)) { _Tomarpreciopadre = value; OnPropertyChanged(); } } }

        private string? _Tomarcomisionpadre;
        [XmlAttribute]
        public string? Tomarcomisionpadre { get => _Tomarcomisionpadre; set { if (RaiseAcceptPendingChange(value, _Tomarcomisionpadre)) { _Tomarcomisionpadre = value; OnPropertyChanged(); } } }

        private string? _Tomarofertapadre;
        [XmlAttribute]
        public string? Tomarofertapadre { get => _Tomarofertapadre; set { if (RaiseAcceptPendingChange(value, _Tomarofertapadre)) { _Tomarofertapadre = value; OnPropertyChanged(); } } }

        private long? _Productopadre;
        [XmlAttribute]
        public long? Productopadre { get => _Productopadre; set { if (RaiseAcceptPendingChange(value, _Productopadre)) { _Productopadre = value; OnPropertyChanged(); } } }

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
    public class WFProductoEditWF_KitdefinicionBindingModel : Validatable
    {

        public WFProductoEditWF_KitdefinicionBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Btquitarparte;
        [XmlAttribute]
        public string? Btquitarparte { get => _Btquitarparte; set { if (RaiseAcceptPendingChange(value, _Btquitarparte)) { _Btquitarparte = value; OnPropertyChanged(); } } }

        private long? _Productokitid;
        [XmlAttribute]
        public long? Productokitid { get => _Productokitid; set { if (RaiseAcceptPendingChange(value, _Productokitid)) { _Productokitid = value; OnPropertyChanged(); } } }

        private long? _Productoparteid;
        [XmlAttribute]
        public long? Productoparteid { get => _Productoparteid; set { if (RaiseAcceptPendingChange(value, _Productoparteid)) { _Productoparteid = value; OnPropertyChanged(); } } }

        private string? _Productokitclave;
        [XmlAttribute]
        public string? Productokitclave { get => _Productokitclave; set { if (RaiseAcceptPendingChange(value, _Productokitclave)) { _Productokitclave = value; OnPropertyChanged(); } } }

        private string? _Productoparteclave;
        [XmlAttribute]
        public string? Productoparteclave { get => _Productoparteclave; set { if (RaiseAcceptPendingChange(value, _Productoparteclave)) { _Productoparteclave = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadparte;
        [XmlAttribute]
        public decimal? Cantidadparte { get => _Cantidadparte; set { if (RaiseAcceptPendingChange(value, _Cantidadparte)) { _Cantidadparte = value; OnPropertyChanged(); } } }

        private decimal? _Costoparte;
        [XmlAttribute]
        public decimal? Costoparte { get => _Costoparte; set { if (RaiseAcceptPendingChange(value, _Costoparte)) { _Costoparte = value; OnPropertyChanged(); } } }

        private decimal? _Tasaivaparte;
        [XmlAttribute]
        public decimal? Tasaivaparte { get => _Tasaivaparte; set { if (RaiseAcceptPendingChange(value, _Tasaivaparte)) { _Tasaivaparte = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiepsparte;
        [XmlAttribute]
        public decimal? Tasaiepsparte { get => _Tasaiepsparte; set { if (RaiseAcceptPendingChange(value, _Tasaiepsparte)) { _Tasaiepsparte = value; OnPropertyChanged(); } } }

        private decimal? _Costototalsinimpuesto;
        [XmlAttribute]
        public decimal? Costototalsinimpuesto { get => _Costototalsinimpuesto; set { if (RaiseAcceptPendingChange(value, _Costototalsinimpuesto)) { _Costototalsinimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Ivaparte;
        [XmlAttribute]
        public decimal? Ivaparte { get => _Ivaparte; set { if (RaiseAcceptPendingChange(value, _Ivaparte)) { _Ivaparte = value; OnPropertyChanged(); } } }

        private decimal? _Iepsparte;
        [XmlAttribute]
        public decimal? Iepsparte { get => _Iepsparte; set { if (RaiseAcceptPendingChange(value, _Iepsparte)) { _Iepsparte = value; OnPropertyChanged(); } } }

        private decimal? _Costototalconimpuesto;
        [XmlAttribute]
        public decimal? Costototalconimpuesto { get => _Costototalconimpuesto; set { if (RaiseAcceptPendingChange(value, _Costototalconimpuesto)) { _Costototalconimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Prorrateo;
        [XmlAttribute]
        public decimal? Prorrateo { get => _Prorrateo; set { if (RaiseAcceptPendingChange(value, _Prorrateo)) { _Prorrateo = value; OnPropertyChanged(); } } }

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
    public class WFProductoEditWF_SucursalBindingModel : Validatable
    {

        public WFProductoEditWF_SucursalBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private long? _Modificadopor_userid;
        [XmlAttribute]
        public long? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private short? _Seleccionada;
        [XmlAttribute]
        public short? Seleccionada { get => _Seleccionada; set { if (RaiseAcceptPendingChange(value, _Seleccionada)) { _Seleccionada = value; OnPropertyChanged(); } } }

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

