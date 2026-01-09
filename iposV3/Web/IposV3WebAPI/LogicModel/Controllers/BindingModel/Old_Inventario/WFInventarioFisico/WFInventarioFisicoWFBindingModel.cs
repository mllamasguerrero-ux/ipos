
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
    public class WFInventarioFisicoWFBindingModel : Validatable
    {

        public WFInventarioFisicoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Combolote;
        [XmlAttribute]
        public long? Combolote { get => _Combolote; set { if (RaiseAcceptPendingChange(value, _Combolote)) { _Combolote = value; OnPropertyChanged(); } } }

        private BoolCN? _Cblotesconexistenciacombo;
        [XmlAttribute]
        public BoolCN? Cblotesconexistenciacombo { get => _Cblotesconexistenciacombo; set { if (RaiseAcceptPendingChange(value, _Cblotesconexistenciacombo)) { _Cblotesconexistenciacombo = value; OnPropertyChanged(); } } }

        private string? _Texto2;
        [XmlAttribute]
        public string? Texto2 { get => _Texto2; set { if (RaiseAcceptPendingChange(value, _Texto2)) { _Texto2 = value; OnPropertyChanged(); } } }

        private string? _Texto3;
        [XmlAttribute]
        public string? Texto3 { get => _Texto3; set { if (RaiseAcceptPendingChange(value, _Texto3)) { _Texto3 = value; OnPropertyChanged(); } } }

        private string? _Texto1;
        [XmlAttribute]
        public string? Texto1 { get => _Texto1; set { if (RaiseAcceptPendingChange(value, _Texto1)) { _Texto1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechavence;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechavence { get => _Dtpfechavence; set { if (RaiseAcceptPendingChange(value, _Dtpfechavence)) { _Dtpfechavence = value; OnPropertyChanged(); } } }

        private string? _Tblote;
        [XmlAttribute]
        public string? Tblote { get => _Tblote; set { if (RaiseAcceptPendingChange(value, _Tblote)) { _Tblote = value; OnPropertyChanged(); } } }

        private string? _Texto4;
        [XmlAttribute]
        public string? Texto4 { get => _Texto4; set { if (RaiseAcceptPendingChange(value, _Texto4)) { _Texto4 = value; OnPropertyChanged(); } } }

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

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private int? _Tbcantidadmaxima;
        [XmlAttribute]
        public int? Tbcantidadmaxima { get => _Tbcantidadmaxima; set { if (RaiseAcceptPendingChange(value, _Tbcantidadmaxima)) { _Tbcantidadmaxima = value; OnPropertyChanged(); } } }

        private string? _Cantidaddiferencia;
        [XmlAttribute]
        public string? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private string? _Apartados;
        [XmlAttribute]
        public string? Apartados { get => _Apartados; set { if (RaiseAcceptPendingChange(value, _Apartados)) { _Apartados = value; OnPropertyChanged(); } } }

        private string? _Cantidadteorica;
        [XmlAttribute]
        public string? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private string? _Cantidadfisica;
        [XmlAttribute]
        public string? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolodiferencias;
        [XmlAttribute]
        public BoolCN? Cbsolodiferencias { get => _Cbsolodiferencias; set { if (RaiseAcceptPendingChange(value, _Cbsolodiferencias)) { _Cbsolodiferencias = value; OnPropertyChanged(); } } }

        private BoolCN? _Kitdesglosado;
        [XmlAttribute]
        public BoolCN? Kitdesglosado { get => _Kitdesglosado; set { if (RaiseAcceptPendingChange(value, _Kitdesglosado)) { _Kitdesglosado = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloingresados;
        [XmlAttribute]
        public BoolCN? Cbsoloingresados { get => _Cbsoloingresados; set { if (RaiseAcceptPendingChange(value, _Cbsoloingresados)) { _Cbsoloingresados = value; OnPropertyChanged(); } } }

        private string? _Tbposicionar;
        [XmlAttribute]
        public string? Tbposicionar { get => _Tbposicionar; set { if (RaiseAcceptPendingChange(value, _Tbposicionar)) { _Tbposicionar = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private int? _Tbcajas;
        [XmlAttribute]
        public int? Tbcajas { get => _Tbcajas; set { if (RaiseAcceptPendingChange(value, _Tbcajas)) { _Tbcajas = value; OnPropertyChanged(); } } }

        private int? _Tbcantidad;
        [XmlAttribute]
        public int? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajasbotellas;
        [XmlAttribute]
        public BoolCN? Cbcajasbotellas { get => _Cbcajasbotellas; set { if (RaiseAcceptPendingChange(value, _Cbcajasbotellas)) { _Cbcajasbotellas = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _ComboloteClave;
        [XmlAttribute]
        public string? ComboloteClave { get => _ComboloteClave; set { if (RaiseAcceptPendingChange(value, _ComboloteClave)) { _ComboloteClave = value; OnPropertyChanged(); } } }

        private string? _ComboloteNombre;
        [XmlAttribute]
        public string? ComboloteNombre { get => _ComboloteNombre; set { if (RaiseAcceptPendingChange(value, _ComboloteNombre)) { _ComboloteNombre = value; OnPropertyChanged(); } } }

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
    public class WFInventarioFisicoWF_Get_invfis_listadetalles_pBindingModel : Validatable
    {

        public WFInventarioFisicoWF_Get_invfis_listadetalles_pBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadteorica;
        [XmlAttribute]
        public decimal? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisica;
        [XmlAttribute]
        public decimal? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidaddiferencia;
        [XmlAttribute]
        public decimal? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

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


     
}

