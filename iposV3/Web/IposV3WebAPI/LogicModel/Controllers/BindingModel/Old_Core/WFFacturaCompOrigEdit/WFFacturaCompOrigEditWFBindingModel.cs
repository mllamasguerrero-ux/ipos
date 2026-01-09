
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
    public class WFFacturaCompOrigEditWFBindingModel : Validatable
    {

        public WFFacturaCompOrigEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private BoolCN? _Provisionada;
        [XmlAttribute]
        public BoolCN? Provisionada { get => _Provisionada; set { if (RaiseAcceptPendingChange(value, _Provisionada)) { _Provisionada = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafactura;
        [XmlAttribute]
        public DateTimeOffset? Fechafactura { get => _Fechafactura; set { if (RaiseAcceptPendingChange(value, _Fechafactura)) { _Fechafactura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }

        private string? _ProveedoridClave;
        [XmlAttribute]
        public string? ProveedoridClave { get => _ProveedoridClave; set { if (RaiseAcceptPendingChange(value, _ProveedoridClave)) { _ProveedoridClave = value; OnPropertyChanged(); } } }

        private string? _ProveedoridNombre;
        [XmlAttribute]
        public string? ProveedoridNombre { get => _ProveedoridNombre; set { if (RaiseAcceptPendingChange(value, _ProveedoridNombre)) { _ProveedoridNombre = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Suma;
        [XmlAttribute]
        public decimal? Suma { get => _Suma; set { if (RaiseAcceptPendingChange(value, _Suma)) { _Suma = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Ieps30;
        [XmlAttribute]
        public decimal? Ieps30 { get => _Ieps30; set { if (RaiseAcceptPendingChange(value, _Ieps30)) { _Ieps30 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps8;
        [XmlAttribute]
        public decimal? Ieps8 { get => _Ieps8; set { if (RaiseAcceptPendingChange(value, _Ieps8)) { _Ieps8 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps26;
        [XmlAttribute]
        public decimal? Ieps26 { get => _Ieps26; set { if (RaiseAcceptPendingChange(value, _Ieps26)) { _Ieps26 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps53;
        [XmlAttribute]
        public decimal? Ieps53 { get => _Ieps53; set { if (RaiseAcceptPendingChange(value, _Ieps53)) { _Ieps53 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps25;
        [XmlAttribute]
        public decimal? Ieps25 { get => _Ieps25; set { if (RaiseAcceptPendingChange(value, _Ieps25)) { _Ieps25 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps26c;
        [XmlAttribute]
        public decimal? Ieps26c { get => _Ieps26c; set { if (RaiseAcceptPendingChange(value, _Ieps26c)) { _Ieps26c = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _SucursalidClave;
        [XmlAttribute]
        public string? SucursalidClave { get => _SucursalidClave; set { if (RaiseAcceptPendingChange(value, _SucursalidClave)) { _SucursalidClave = value; OnPropertyChanged(); } } }

        private string? _SucursalidNombre;
        [XmlAttribute]
        public string? SucursalidNombre { get => _SucursalidNombre; set { if (RaiseAcceptPendingChange(value, _SucursalidNombre)) { _SucursalidNombre = value; OnPropertyChanged(); } } }

        private string? _Factura;
        [XmlAttribute]
        public string? Factura { get => _Factura; set { if (RaiseAcceptPendingChange(value, _Factura)) { _Factura = value; OnPropertyChanged(); } } }

        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

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

