
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
    public class WFInventarioFisicoXLocWFBindingModel : Validatable
    {

        public WFInventarioFisicoXLocWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Localidadcombobox;
        [XmlAttribute]
        public long? Localidadcombobox { get => _Localidadcombobox; set { if (RaiseAcceptPendingChange(value, _Localidadcombobox)) { _Localidadcombobox = value; OnPropertyChanged(); } } }

        private int? _Tbcajas;
        [XmlAttribute]
        public int? Tbcajas { get => _Tbcajas; set { if (RaiseAcceptPendingChange(value, _Tbcajas)) { _Tbcajas = value; OnPropertyChanged(); } } }

        private int? _Tbpiezas;
        [XmlAttribute]
        public int? Tbpiezas { get => _Tbpiezas; set { if (RaiseAcceptPendingChange(value, _Tbpiezas)) { _Tbpiezas = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Cantidadfisica;
        [XmlAttribute]
        public string? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private string? _Cantidadteorica;
        [XmlAttribute]
        public string? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private string? _Cantidaddiferencia;
        [XmlAttribute]
        public string? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private string? _Apartados;
        [XmlAttribute]
        public string? Apartados { get => _Apartados; set { if (RaiseAcceptPendingChange(value, _Apartados)) { _Apartados = value; OnPropertyChanged(); } } }

        private string? _Pzacaja;
        [XmlAttribute]
        public string? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloingresados;
        [XmlAttribute]
        public BoolCN? Cbsoloingresados { get => _Cbsoloingresados; set { if (RaiseAcceptPendingChange(value, _Cbsoloingresados)) { _Cbsoloingresados = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolodiferencias;
        [XmlAttribute]
        public BoolCN? Cbsolodiferencias { get => _Cbsolodiferencias; set { if (RaiseAcceptPendingChange(value, _Cbsolodiferencias)) { _Cbsolodiferencias = value; OnPropertyChanged(); } } }

        private BoolCN? _Kitdesglosado;
        [XmlAttribute]
        public BoolCN? Kitdesglosado { get => _Kitdesglosado; set { if (RaiseAcceptPendingChange(value, _Kitdesglosado)) { _Kitdesglosado = value; OnPropertyChanged(); } } }

        private int? _Tbcantidadmaxima;
        [XmlAttribute]
        public int? Tbcantidadmaxima { get => _Tbcantidadmaxima; set { if (RaiseAcceptPendingChange(value, _Tbcantidadmaxima)) { _Tbcantidadmaxima = value; OnPropertyChanged(); } } }

        private long? _Anaquelcombobox;
        [XmlAttribute]
        public long? Anaquelcombobox { get => _Anaquelcombobox; set { if (RaiseAcceptPendingChange(value, _Anaquelcombobox)) { _Anaquelcombobox = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajas;
        [XmlAttribute]
        public BoolCN? Cbcajas { get => _Cbcajas; set { if (RaiseAcceptPendingChange(value, _Cbcajas)) { _Cbcajas = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbpiezas;
        [XmlAttribute]
        public BoolCN? Cbpiezas { get => _Cbpiezas; set { if (RaiseAcceptPendingChange(value, _Cbpiezas)) { _Cbpiezas = value; OnPropertyChanged(); } } }

        private string? _LocalidadcomboboxClave;
        [XmlAttribute]
        public string? LocalidadcomboboxClave { get => _LocalidadcomboboxClave; set { if (RaiseAcceptPendingChange(value, _LocalidadcomboboxClave)) { _LocalidadcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _LocalidadcomboboxNombre;
        [XmlAttribute]
        public string? LocalidadcomboboxNombre { get => _LocalidadcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _LocalidadcomboboxNombre)) { _LocalidadcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _AnaquelcomboboxClave;
        [XmlAttribute]
        public string? AnaquelcomboboxClave { get => _AnaquelcomboboxClave; set { if (RaiseAcceptPendingChange(value, _AnaquelcomboboxClave)) { _AnaquelcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AnaquelcomboboxNombre;
        [XmlAttribute]
        public string? AnaquelcomboboxNombre { get => _AnaquelcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AnaquelcomboboxNombre)) { _AnaquelcomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFInventarioFisicoXLocWF_Get_invfis_listadetalles_pBindingModel : Validatable
    {

        public WFInventarioFisicoXLocWF_Get_invfis_listadetalles_pBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Anaquelres;
        [XmlAttribute]
        public string? Anaquelres { get => _Anaquelres; set { if (RaiseAcceptPendingChange(value, _Anaquelres)) { _Anaquelres = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadteorica;
        [XmlAttribute]
        public decimal? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private decimal? _Acumuladocantidadfisica;
        [XmlAttribute]
        public decimal? Acumuladocantidadfisica { get => _Acumuladocantidadfisica; set { if (RaiseAcceptPendingChange(value, _Acumuladocantidadfisica)) { _Acumuladocantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Acumcantfisicatemp;
        [XmlAttribute]
        public decimal? Acumcantfisicatemp { get => _Acumcantfisicatemp; set { if (RaiseAcceptPendingChange(value, _Acumcantfisicatemp)) { _Acumcantfisicatemp = value; OnPropertyChanged(); } } }

        private decimal? _Cantidaddiferencia;
        [XmlAttribute]
        public decimal? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisica;
        [XmlAttribute]
        public decimal? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisicatemp;
        [XmlAttribute]
        public decimal? Cantidadfisicatemp { get => _Cantidadfisicatemp; set { if (RaiseAcceptPendingChange(value, _Cantidadfisicatemp)) { _Cantidadfisicatemp = value; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute]
        public decimal? Cajas { get => _Cajas; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value; OnPropertyChanged(); } } }

        private decimal? _Cajastemp;
        [XmlAttribute]
        public decimal? Cajastemp { get => _Cajastemp; set { if (RaiseAcceptPendingChange(value, _Cajastemp)) { _Cajastemp = value; OnPropertyChanged(); } } }

        private decimal? _Piezas;
        [XmlAttribute]
        public decimal? Piezas { get => _Piezas; set { if (RaiseAcceptPendingChange(value, _Piezas)) { _Piezas = value; OnPropertyChanged(); } } }

        private decimal? _Piezastemp;
        [XmlAttribute]
        public decimal? Piezastemp { get => _Piezastemp; set { if (RaiseAcceptPendingChange(value, _Piezastemp)) { _Piezastemp = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private long? _Anaquelidres;
        [XmlAttribute]
        public long? Anaquelidres { get => _Anaquelidres; set { if (RaiseAcceptPendingChange(value, _Anaquelidres)) { _Anaquelidres = value; OnPropertyChanged(); } } }

        private int? _Estado;
        [XmlAttribute]
        public int? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

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

