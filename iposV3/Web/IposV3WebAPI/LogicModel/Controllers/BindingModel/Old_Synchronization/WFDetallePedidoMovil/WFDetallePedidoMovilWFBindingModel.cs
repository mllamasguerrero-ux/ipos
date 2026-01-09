
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
    public class WFDetallePedidoMovilWFBindingModel : Validatable
    {

        public WFDetallePedidoMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

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
    public class WFDetallePedidoMovilWF_Detalle_pedido_movilBindingModel : Validatable
    {

        public WFDetallePedidoMovilWF_Detalle_pedido_movilBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute]
        public decimal? Precio { get => _Precio; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Cantidadaenviar;
        [XmlAttribute]
        public string? Cantidadaenviar { get => _Cantidadaenviar; set { if (RaiseAcceptPendingChange(value, _Cantidadaenviar)) { _Cantidadaenviar = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

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

