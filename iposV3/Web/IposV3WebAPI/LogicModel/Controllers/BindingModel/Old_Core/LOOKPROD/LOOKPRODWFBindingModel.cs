
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
    public class LOOKPRODWFBindingModel : Validatable
    {

        public LOOKPRODWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Busquedatoolstrip;
        [XmlAttribute]
        public string? Busquedatoolstrip { get => _Busquedatoolstrip; set { if (RaiseAcceptPendingChange(value, _Busquedatoolstrip)) { _Busquedatoolstrip = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolohistorial;
        [XmlAttribute]
        public BoolCN? Cbsolohistorial { get => _Cbsolohistorial; set { if (RaiseAcceptPendingChange(value, _Cbsolohistorial)) { _Cbsolohistorial = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloprom;
        [XmlAttribute]
        public BoolCN? Cbsoloprom { get => _Cbsoloprom; set { if (RaiseAcceptPendingChange(value, _Cbsoloprom)) { _Cbsoloprom = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmostrarexistencias;
        [XmlAttribute]
        public BoolCN? Cbmostrarexistencias { get => _Cbmostrarexistencias; set { if (RaiseAcceptPendingChange(value, _Cbmostrarexistencias)) { _Cbmostrarexistencias = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloalmacen;
        [XmlAttribute]
        public BoolCN? Cbsoloalmacen { get => _Cbsoloalmacen; set { if (RaiseAcceptPendingChange(value, _Cbsoloalmacen)) { _Cbsoloalmacen = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilidadlistado;
        [XmlAttribute]
        public decimal? Porcutilidadlistado { get => _Porcutilidadlistado; set { if (RaiseAcceptPendingChange(value, _Porcutilidadlistado)) { _Porcutilidadlistado = value; OnPropertyChanged(); } } }

        private long? _Lstproductocomplete;
        [XmlAttribute]
        public long? Lstproductocomplete { get => _Lstproductocomplete; set { if (RaiseAcceptPendingChange(value, _Lstproductocomplete)) { _Lstproductocomplete = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxClave;
        [XmlAttribute]
        public string? AlmacencomboboxClave { get => _AlmacencomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxClave)) { _AlmacencomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxNombre;
        [XmlAttribute]
        public string? AlmacencomboboxNombre { get => _AlmacencomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxNombre)) { _AlmacencomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _LstproductocompleteClave;
        [XmlAttribute]
        public string? LstproductocompleteClave { get => _LstproductocompleteClave; set { if (RaiseAcceptPendingChange(value, _LstproductocompleteClave)) { _LstproductocompleteClave = value; OnPropertyChanged(); } } }

        private string? _LstproductocompleteNombre;
        [XmlAttribute]
        public string? LstproductocompleteNombre { get => _LstproductocompleteNombre; set { if (RaiseAcceptPendingChange(value, _LstproductocompleteNombre)) { _LstproductocompleteNombre = value; OnPropertyChanged(); } } }

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
    public class LOOKPRODWF_ProductosBindingModel : Validatable
    {

        public LOOKPRODWF_ProductosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Bteditar;
        [XmlAttribute]
        public string? Bteditar { get => _Bteditar; set { if (RaiseAcceptPendingChange(value, _Bteditar)) { _Bteditar = value; OnPropertyChanged(); } } }

        private string? _Btverproducto;
        [XmlAttribute]
        public string? Btverproducto { get => _Btverproducto; set { if (RaiseAcceptPendingChange(value, _Btverproducto)) { _Btverproducto = value; OnPropertyChanged(); } } }

        private string? _Bthistorialproducto;
        [XmlAttribute]
        public string? Bthistorialproducto { get => _Bthistorialproducto; set { if (RaiseAcceptPendingChange(value, _Bthistorialproducto)) { _Bthistorialproducto = value; OnPropertyChanged(); } } }

        private string? _Btexistencia;
        [XmlAttribute]
        public string? Btexistencia { get => _Btexistencia; set { if (RaiseAcceptPendingChange(value, _Btexistencia)) { _Btexistencia = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio_mas_iva;
        [XmlAttribute]
        public decimal? Precio_mas_iva { get => _Precio_mas_iva; set { if (RaiseAcceptPendingChange(value, _Precio_mas_iva)) { _Precio_mas_iva = value; OnPropertyChanged(); } } }

        private decimal? _Precio_mas_impuesto;
        [XmlAttribute]
        public decimal? Precio_mas_impuesto { get => _Precio_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Precio_mas_impuesto)) { _Precio_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute]
        public decimal? Precio2 { get => _Precio2; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value; OnPropertyChanged(); } } }

        private decimal? _Precio2_mas_impuesto;
        [XmlAttribute]
        public decimal? Precio2_mas_impuesto { get => _Precio2_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Precio2_mas_impuesto)) { _Precio2_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio3_mas_impuesto;
        [XmlAttribute]
        public decimal? Precio3_mas_impuesto { get => _Precio3_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Precio3_mas_impuesto)) { _Precio3_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4_mas_impuesto;
        [XmlAttribute]
        public decimal? Precio4_mas_impuesto { get => _Precio4_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Precio4_mas_impuesto)) { _Precio4_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute]
        public decimal? Precio5 { get => _Precio5; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value; OnPropertyChanged(); } } }

        private decimal? _Precio5_mas_impuesto;
        [XmlAttribute]
        public decimal? Precio5_mas_impuesto { get => _Precio5_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Precio5_mas_impuesto)) { _Precio5_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Costorepoconutilimp;
        [XmlAttribute]
        public decimal? Costorepoconutilimp { get => _Costorepoconutilimp; set { if (RaiseAcceptPendingChange(value, _Costorepoconutilimp)) { _Costorepoconutilimp = value; OnPropertyChanged(); } } }

        private decimal? _Preciomediomayoreocontarjeta;
        [XmlAttribute]
        public decimal? Preciomediomayoreocontarjeta { get => _Preciomediomayoreocontarjeta; set { if (RaiseAcceptPendingChange(value, _Preciomediomayoreocontarjeta)) { _Preciomediomayoreocontarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Preciomayoreocontarjeta;
        [XmlAttribute]
        public decimal? Preciomayoreocontarjeta { get => _Preciomayoreocontarjeta; set { if (RaiseAcceptPendingChange(value, _Preciomayoreocontarjeta)) { _Preciomayoreocontarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Preciocaja_mas_impuesto;
        [XmlAttribute]
        public decimal? Preciocaja_mas_impuesto { get => _Preciocaja_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Preciocaja_mas_impuesto)) { _Preciocaja_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute]
        public decimal? Tasaieps { get => _Tasaieps; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private decimal? _Limiteprecio2;
        [XmlAttribute]
        public decimal? Limiteprecio2 { get => _Limiteprecio2; set { if (RaiseAcceptPendingChange(value, _Limiteprecio2)) { _Limiteprecio2 = value; OnPropertyChanged(); } } }

        private string? _Ean;
        [XmlAttribute]
        public string? Ean { get => _Ean; set { if (RaiseAcceptPendingChange(value, _Ean)) { _Ean = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute]
        public decimal? Cajas { get => _Cajas; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value; OnPropertyChanged(); } } }

        private decimal? _Piezas;
        [XmlAttribute]
        public decimal? Piezas { get => _Piezas; set { if (RaiseAcceptPendingChange(value, _Piezas)) { _Piezas = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaalmacen1;
        [XmlAttribute]
        public decimal? Existenciaalmacen1 { get => _Existenciaalmacen1; set { if (RaiseAcceptPendingChange(value, _Existenciaalmacen1)) { _Existenciaalmacen1 = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaalmacen2;
        [XmlAttribute]
        public decimal? Existenciaalmacen2 { get => _Existenciaalmacen2; set { if (RaiseAcceptPendingChange(value, _Existenciaalmacen2)) { _Existenciaalmacen2 = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaalmacen3;
        [XmlAttribute]
        public decimal? Existenciaalmacen3 { get => _Existenciaalmacen3; set { if (RaiseAcceptPendingChange(value, _Existenciaalmacen3)) { _Existenciaalmacen3 = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaapartado;
        [XmlAttribute]
        public decimal? Existenciaapartado { get => _Existenciaapartado; set { if (RaiseAcceptPendingChange(value, _Existenciaapartado)) { _Existenciaapartado = value; OnPropertyChanged(); } } }

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

        private string? _Proveedor;
        [XmlAttribute]
        public string? Proveedor { get => _Proveedor; set { if (RaiseAcceptPendingChange(value, _Proveedor)) { _Proveedor = value; OnPropertyChanged(); } } }

        private decimal? _Enprocesodesalida;
        [XmlAttribute]
        public decimal? Enprocesodesalida { get => _Enprocesodesalida; set { if (RaiseAcceptPendingChange(value, _Enprocesodesalida)) { _Enprocesodesalida = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private decimal? _U_empaque;
        [XmlAttribute]
        public decimal? U_empaque { get => _U_empaque; set { if (RaiseAcceptPendingChange(value, _U_empaque)) { _U_empaque = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

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

