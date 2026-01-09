
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
    public class WFDesEnsambleKitWFBindingModel : Validatable
    {

        public WFDesEnsambleKitWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private int? _Tbcantidad;
        [XmlAttribute]
        public int? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Cantidadteorica;
        [XmlAttribute]
        public string? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private long? _Almacenfuentecombobox;
        [XmlAttribute]
        public long? Almacenfuentecombobox { get => _Almacenfuentecombobox; set { if (RaiseAcceptPendingChange(value, _Almacenfuentecombobox)) { _Almacenfuentecombobox = value; OnPropertyChanged(); } } }

        private long? _Almacendestinocombobox;
        [XmlAttribute]
        public long? Almacendestinocombobox { get => _Almacendestinocombobox; set { if (RaiseAcceptPendingChange(value, _Almacendestinocombobox)) { _Almacendestinocombobox = value; OnPropertyChanged(); } } }

        private string? _AlmacenfuentecomboboxClave;
        [XmlAttribute]
        public string? AlmacenfuentecomboboxClave { get => _AlmacenfuentecomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacenfuentecomboboxClave)) { _AlmacenfuentecomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenfuentecomboboxNombre;
        [XmlAttribute]
        public string? AlmacenfuentecomboboxNombre { get => _AlmacenfuentecomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenfuentecomboboxNombre)) { _AlmacenfuentecomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _AlmacendestinocomboboxClave;
        [XmlAttribute]
        public string? AlmacendestinocomboboxClave { get => _AlmacendestinocomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacendestinocomboboxClave)) { _AlmacendestinocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacendestinocomboboxNombre;
        [XmlAttribute]
        public string? AlmacendestinocomboboxNombre { get => _AlmacendestinocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacendestinocomboboxNombre)) { _AlmacendestinocomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFDesEnsambleKitWF_KitdetalleBindingModel : Validatable
    {

        public WFDesEnsambleKitWF_KitdetalleBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Bteliminar;
        [XmlAttribute]
        public string? Bteliminar { get => _Bteliminar; set { if (RaiseAcceptPendingChange(value, _Bteliminar)) { _Bteliminar = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Costo;
        [XmlAttribute]
        public decimal? Costo { get => _Costo; set { if (RaiseAcceptPendingChange(value, _Costo)) { _Costo = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private short? _Partida;
        [XmlAttribute]
        public short? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

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

