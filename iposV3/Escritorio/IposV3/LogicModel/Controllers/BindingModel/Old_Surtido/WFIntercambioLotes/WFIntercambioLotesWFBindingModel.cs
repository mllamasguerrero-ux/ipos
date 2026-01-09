
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
    public class WFIntercambioLotesWFBindingModel : Validatable
    {

        public WFIntercambioLotesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Combolote;
        [XmlAttribute]
        public long? Combolote { get => _Combolote; set { if (RaiseAcceptPendingChange(value, _Combolote)) { _Combolote = value; OnPropertyChanged(); } } }

        private int? _Tbcantidad;
        [XmlAttribute]
        public int? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private string? _Cantidadteorica;
        [XmlAttribute]
        public string? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private long? _Combolotedestino;
        [XmlAttribute]
        public long? Combolotedestino { get => _Combolotedestino; set { if (RaiseAcceptPendingChange(value, _Combolotedestino)) { _Combolotedestino = value; OnPropertyChanged(); } } }

        private string? _Tblote;
        [XmlAttribute]
        public string? Tblote { get => _Tblote; set { if (RaiseAcceptPendingChange(value, _Tblote)) { _Tblote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechavence;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechavence { get => _Dtpfechavence; set { if (RaiseAcceptPendingChange(value, _Dtpfechavence)) { _Dtpfechavence = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

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

        private string? _CombolotedestinoClave;
        [XmlAttribute]
        public string? CombolotedestinoClave { get => _CombolotedestinoClave; set { if (RaiseAcceptPendingChange(value, _CombolotedestinoClave)) { _CombolotedestinoClave = value; OnPropertyChanged(); } } }

        private string? _CombolotedestinoNombre;
        [XmlAttribute]
        public string? CombolotedestinoNombre { get => _CombolotedestinoNombre; set { if (RaiseAcceptPendingChange(value, _CombolotedestinoNombre)) { _CombolotedestinoNombre = value; OnPropertyChanged(); } } }

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
    public class WFIntercambioLotesWF_TempintercambioBindingModel : Validatable
    {

        public WFIntercambioLotesWF_TempintercambioBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Id;
        [XmlAttribute]
        public int? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Bteliminar;
        [XmlAttribute]
        public string? Bteliminar { get => _Bteliminar; set { if (RaiseAcceptPendingChange(value, _Bteliminar)) { _Bteliminar = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Lotedestino;
        [XmlAttribute]
        public string? Lotedestino { get => _Lotedestino; set { if (RaiseAcceptPendingChange(value, _Lotedestino)) { _Lotedestino = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavencedestino;
        [XmlAttribute]
        public DateTimeOffset? Fechavencedestino { get => _Fechavencedestino; set { if (RaiseAcceptPendingChange(value, _Fechavencedestino)) { _Fechavencedestino = value; OnPropertyChanged(); } } }

        private long? _Almaceniddestino;
        [XmlAttribute]
        public long? Almaceniddestino { get => _Almaceniddestino; set { if (RaiseAcceptPendingChange(value, _Almaceniddestino)) { _Almaceniddestino = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

        private string? _Existinsuf;
        [XmlAttribute]
        public string? Existinsuf { get => _Existinsuf; set { if (RaiseAcceptPendingChange(value, _Existinsuf)) { _Existinsuf = value; OnPropertyChanged(); } } }

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

