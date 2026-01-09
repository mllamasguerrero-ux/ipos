
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
    public class WFExistenciaSucursalProveedorWFBindingModel : Validatable
    {

        public WFExistenciaSucursalProveedorWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbsoloconexistencia;
        [XmlAttribute]
        public BoolCN? Cbsoloconexistencia { get => _Cbsoloconexistencia; set { if (RaiseAcceptPendingChange(value, _Cbsoloconexistencia)) { _Cbsoloconexistencia = value; OnPropertyChanged(); } } }

        private long? _Sucursal;
        [XmlAttribute]
        public long? Sucursal { get => _Sucursal; set { if (RaiseAcceptPendingChange(value, _Sucursal)) { _Sucursal = value; OnPropertyChanged(); } } }

        private string? _SucursalClave;
        [XmlAttribute]
        public string? SucursalClave { get => _SucursalClave; set { if (RaiseAcceptPendingChange(value, _SucursalClave)) { _SucursalClave = value; OnPropertyChanged(); } } }

        private string? _SucursalNombre;
        [XmlAttribute]
        public string? SucursalNombre { get => _SucursalNombre; set { if (RaiseAcceptPendingChange(value, _SucursalNombre)) { _SucursalNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodossucursales;
        [XmlAttribute]
        public BoolCN? Cbtodossucursales { get => _Cbtodossucursales; set { if (RaiseAcceptPendingChange(value, _Cbtodossucursales)) { _Cbtodossucursales = value; OnPropertyChanged(); } } }

        private long? _Proveedor1id;
        [XmlAttribute]
        public long? Proveedor1id { get => _Proveedor1id; set { if (RaiseAcceptPendingChange(value, _Proveedor1id)) { _Proveedor1id = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idClave;
        [XmlAttribute]
        public string? Proveedor1idClave { get => _Proveedor1idClave; set { if (RaiseAcceptPendingChange(value, _Proveedor1idClave)) { _Proveedor1idClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idNombre;
        [XmlAttribute]
        public string? Proveedor1idNombre { get => _Proveedor1idNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1idNombre)) { _Proveedor1idNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosproveedores;
        [XmlAttribute]
        public BoolCN? Cbtodosproveedores { get => _Cbtodosproveedores; set { if (RaiseAcceptPendingChange(value, _Cbtodosproveedores)) { _Cbtodosproveedores = value; OnPropertyChanged(); } } }

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
    public class WFExistenciaSucursalProveedorWF_ExistenciaprovesucBindingModel : Validatable
    {

        public WFExistenciaSucursalProveedorWF_ExistenciaprovesucBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _Proveedornombre;
        [XmlAttribute]
        public string? Proveedornombre { get => _Proveedornombre; set { if (RaiseAcceptPendingChange(value, _Proveedornombre)) { _Proveedornombre = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private string? _Sucursalnombre;
        [XmlAttribute]
        public string? Sucursalnombre { get => _Sucursalnombre; set { if (RaiseAcceptPendingChange(value, _Sucursalnombre)) { _Sucursalnombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

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

