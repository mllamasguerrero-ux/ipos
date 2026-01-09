
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
    public class WFImprimirEtiquetasWFBindingModel : Validatable
    {

        public WFImprimirEtiquetasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Textosuperior;
        [XmlAttribute]
        public string? Textosuperior { get => _Textosuperior; set { if (RaiseAcceptPendingChange(value, _Textosuperior)) { _Textosuperior = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private int? _Tbcantidad;
        [XmlAttribute]
        public int? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private long? _Camposuperior;
        [XmlAttribute]
        public long? Camposuperior { get => _Camposuperior; set { if (RaiseAcceptPendingChange(value, _Camposuperior)) { _Camposuperior = value; OnPropertyChanged(); } } }

        private string? _Tbpeso;
        [XmlAttribute]
        public string? Tbpeso { get => _Tbpeso; set { if (RaiseAcceptPendingChange(value, _Tbpeso)) { _Tbpeso = value; OnPropertyChanged(); } } }

        private BoolCN? _Fmtimpresoradoble;
        [XmlAttribute]
        public BoolCN? Fmtimpresoradoble { get => _Fmtimpresoradoble; set { if (RaiseAcceptPendingChange(value, _Fmtimpresoradoble)) { _Fmtimpresoradoble = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbanaquel;
        [XmlAttribute]
        public BoolCN? Cbanaquel { get => _Cbanaquel; set { if (RaiseAcceptPendingChange(value, _Cbanaquel)) { _Cbanaquel = value; OnPropertyChanged(); } } }

        private string? _Tbimpresora;
        [XmlAttribute]
        public string? Tbimpresora { get => _Tbimpresora; set { if (RaiseAcceptPendingChange(value, _Tbimpresora)) { _Tbimpresora = value; OnPropertyChanged(); } } }

        private long? _Cmbprintermodel;
        [XmlAttribute]
        public long? Cmbprintermodel { get => _Cmbprintermodel; set { if (RaiseAcceptPendingChange(value, _Cmbprintermodel)) { _Cmbprintermodel = value; OnPropertyChanged(); } } }

        private string? _A3_rotation;
        [XmlAttribute]
        public string? A3_rotation { get => _A3_rotation; set { if (RaiseAcceptPendingChange(value, _A3_rotation)) { _A3_rotation = value; OnPropertyChanged(); } } }

        private string? _B4_barcode_selection;
        [XmlAttribute]
        public string? B4_barcode_selection { get => _B4_barcode_selection; set { if (RaiseAcceptPendingChange(value, _B4_barcode_selection)) { _B4_barcode_selection = value; OnPropertyChanged(); } } }

        private string? _A4_font_selection;
        [XmlAttribute]
        public string? A4_font_selection { get => _A4_font_selection; set { if (RaiseAcceptPendingChange(value, _A4_font_selection)) { _A4_font_selection = value; OnPropertyChanged(); } } }

        private string? _B5_narrowbarwidth;
        [XmlAttribute]
        public string? B5_narrowbarwidth { get => _B5_narrowbarwidth; set { if (RaiseAcceptPendingChange(value, _B5_narrowbarwidth)) { _B5_narrowbarwidth = value; OnPropertyChanged(); } } }

        private string? _A5_x_multiplier;
        [XmlAttribute]
        public string? A5_x_multiplier { get => _A5_x_multiplier; set { if (RaiseAcceptPendingChange(value, _A5_x_multiplier)) { _A5_x_multiplier = value; OnPropertyChanged(); } } }

        private string? _B6_widebarwidth;
        [XmlAttribute]
        public string? B6_widebarwidth { get => _B6_widebarwidth; set { if (RaiseAcceptPendingChange(value, _B6_widebarwidth)) { _B6_widebarwidth = value; OnPropertyChanged(); } } }

        private string? _A6_y_multiplier;
        [XmlAttribute]
        public string? A6_y_multiplier { get => _A6_y_multiplier; set { if (RaiseAcceptPendingChange(value, _A6_y_multiplier)) { _A6_y_multiplier = value; OnPropertyChanged(); } } }

        private string? _B7_barcodeheight;
        [XmlAttribute]
        public string? B7_barcodeheight { get => _B7_barcodeheight; set { if (RaiseAcceptPendingChange(value, _B7_barcodeheight)) { _B7_barcodeheight = value; OnPropertyChanged(); } } }

        private string? _A7_reverseimage;
        [XmlAttribute]
        public string? A7_reverseimage { get => _A7_reverseimage; set { if (RaiseAcceptPendingChange(value, _A7_reverseimage)) { _A7_reverseimage = value; OnPropertyChanged(); } } }

        private string? _B8_printhumanreadable;
        [XmlAttribute]
        public string? B8_printhumanreadable { get => _B8_printhumanreadable; set { if (RaiseAcceptPendingChange(value, _B8_printhumanreadable)) { _B8_printhumanreadable = value; OnPropertyChanged(); } } }

        private string? _Q_width;
        [XmlAttribute]
        public string? Q_width { get => _Q_width; set { if (RaiseAcceptPendingChange(value, _Q_width)) { _Q_width = value; OnPropertyChanged(); } } }

        private string? _Q_formlength_1;
        [XmlAttribute]
        public string? Q_formlength_1 { get => _Q_formlength_1; set { if (RaiseAcceptPendingChange(value, _Q_formlength_1)) { _Q_formlength_1 = value; OnPropertyChanged(); } } }

        private string? _Q_formlength_2;
        [XmlAttribute]
        public string? Q_formlength_2 { get => _Q_formlength_2; set { if (RaiseAcceptPendingChange(value, _Q_formlength_2)) { _Q_formlength_2 = value; OnPropertyChanged(); } } }

        private string? _B1_x_position;
        [XmlAttribute]
        public string? B1_x_position { get => _B1_x_position; set { if (RaiseAcceptPendingChange(value, _B1_x_position)) { _B1_x_position = value; OnPropertyChanged(); } } }

        private string? _A1_x_position;
        [XmlAttribute]
        public string? A1_x_position { get => _A1_x_position; set { if (RaiseAcceptPendingChange(value, _A1_x_position)) { _A1_x_position = value; OnPropertyChanged(); } } }

        private string? _B2_y_position;
        [XmlAttribute]
        public string? B2_y_position { get => _B2_y_position; set { if (RaiseAcceptPendingChange(value, _B2_y_position)) { _B2_y_position = value; OnPropertyChanged(); } } }

        private string? _A2_y_position;
        [XmlAttribute]
        public string? A2_y_position { get => _A2_y_position; set { if (RaiseAcceptPendingChange(value, _A2_y_position)) { _A2_y_position = value; OnPropertyChanged(); } } }

        private string? _B3_rotation;
        [XmlAttribute]
        public string? B3_rotation { get => _B3_rotation; set { if (RaiseAcceptPendingChange(value, _B3_rotation)) { _B3_rotation = value; OnPropertyChanged(); } } }

        private string? _Tboutput;
        [XmlAttribute]
        public string? Tboutput { get => _Tboutput; set { if (RaiseAcceptPendingChange(value, _Tboutput)) { _Tboutput = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private string? _Tbimpresora2;
        [XmlAttribute]
        public string? Tbimpresora2 { get => _Tbimpresora2; set { if (RaiseAcceptPendingChange(value, _Tbimpresora2)) { _Tbimpresora2 = value; OnPropertyChanged(); } } }

        private string? _CamposuperiorClave;
        [XmlAttribute]
        public string? CamposuperiorClave { get => _CamposuperiorClave; set { if (RaiseAcceptPendingChange(value, _CamposuperiorClave)) { _CamposuperiorClave = value; OnPropertyChanged(); } } }

        private string? _CamposuperiorNombre;
        [XmlAttribute]
        public string? CamposuperiorNombre { get => _CamposuperiorNombre; set { if (RaiseAcceptPendingChange(value, _CamposuperiorNombre)) { _CamposuperiorNombre = value; OnPropertyChanged(); } } }

        private string? _CmbprintermodelClave;
        [XmlAttribute]
        public string? CmbprintermodelClave { get => _CmbprintermodelClave; set { if (RaiseAcceptPendingChange(value, _CmbprintermodelClave)) { _CmbprintermodelClave = value; OnPropertyChanged(); } } }

        private string? _CmbprintermodelNombre;
        [XmlAttribute]
        public string? CmbprintermodelNombre { get => _CmbprintermodelNombre; set { if (RaiseAcceptPendingChange(value, _CmbprintermodelNombre)) { _CmbprintermodelNombre = value; OnPropertyChanged(); } } }

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
    public class WFImprimirEtiquetasWF_ProductoaetiquetarBindingModel : Validatable
    {

        public WFImprimirEtiquetasWF_ProductoaetiquetarBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

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

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private int? _Cantidad;
        [XmlAttribute]
        public int? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Textopersonalizado;
        [XmlAttribute]
        public string? Textopersonalizado { get => _Textopersonalizado; set { if (RaiseAcceptPendingChange(value, _Textopersonalizado)) { _Textopersonalizado = value; OnPropertyChanged(); } } }

        private string? _Campoimpresion;
        [XmlAttribute]
        public string? Campoimpresion { get => _Campoimpresion; set { if (RaiseAcceptPendingChange(value, _Campoimpresion)) { _Campoimpresion = value; OnPropertyChanged(); } } }

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

        private string? _Plug;
        [XmlAttribute]
        public string? Plug { get => _Plug; set { if (RaiseAcceptPendingChange(value, _Plug)) { _Plug = value; OnPropertyChanged(); } } }

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
    public class WFImprimirEtiquetasWF_PersonagaffeteBindingModel : Validatable
    {

        public WFImprimirEtiquetasWF_PersonagaffeteBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Gaffete;
        [XmlAttribute]
        public string? Gaffete { get => _Gaffete; set { if (RaiseAcceptPendingChange(value, _Gaffete)) { _Gaffete = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private string? _Apellidos;
        [XmlAttribute]
        public string? Apellidos { get => _Apellidos; set { if (RaiseAcceptPendingChange(value, _Apellidos)) { _Apellidos = value; OnPropertyChanged(); } } }

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

