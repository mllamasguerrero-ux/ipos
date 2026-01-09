
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
    public class WFPedidosXProductosWFBindingModel : Validatable
    {

        public WFPedidosXProductosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sucursalcombobox;
        [XmlAttribute]
        public long? Sucursalcombobox { get => _Sucursalcombobox; set { if (RaiseAcceptPendingChange(value, _Sucursalcombobox)) { _Sucursalcombobox = value; OnPropertyChanged(); } } }

        private long? _Combotiporeporte;
        [XmlAttribute]
        public long? Combotiporeporte { get => _Combotiporeporte; set { if (RaiseAcceptPendingChange(value, _Combotiporeporte)) { _Combotiporeporte = value; OnPropertyChanged(); } } }

        private string? _SucursalcomboboxClave;
        [XmlAttribute]
        public string? SucursalcomboboxClave { get => _SucursalcomboboxClave; set { if (RaiseAcceptPendingChange(value, _SucursalcomboboxClave)) { _SucursalcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _SucursalcomboboxNombre;
        [XmlAttribute]
        public string? SucursalcomboboxNombre { get => _SucursalcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _SucursalcomboboxNombre)) { _SucursalcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CombotiporeporteClave;
        [XmlAttribute]
        public string? CombotiporeporteClave { get => _CombotiporeporteClave; set { if (RaiseAcceptPendingChange(value, _CombotiporeporteClave)) { _CombotiporeporteClave = value; OnPropertyChanged(); } } }

        private string? _CombotiporeporteNombre;
        [XmlAttribute]
        public string? CombotiporeporteNombre { get => _CombotiporeporteNombre; set { if (RaiseAcceptPendingChange(value, _CombotiporeporteNombre)) { _CombotiporeporteNombre = value; OnPropertyChanged(); } } }

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
    public class WFPedidosXProductosWF_ExistenciapedidoBindingModel : Validatable
    {

        public WFPedidosXProductosWF_ExistenciapedidoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

        private string? _Existenciasucursal;
        [XmlAttribute]
        public string? Existenciasucursal { get => _Existenciasucursal; set { if (RaiseAcceptPendingChange(value, _Existenciasucursal)) { _Existenciasucursal = value; OnPropertyChanged(); } } }

        private string? _Cantidadpedido;
        [XmlAttribute]
        public string? Cantidadpedido { get => _Cantidadpedido; set { if (RaiseAcceptPendingChange(value, _Cantidadpedido)) { _Cantidadpedido = value; OnPropertyChanged(); } } }

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

