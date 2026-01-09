
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
    public class WFUsuarioEditWFBindingModel : Validatable
    {

        public WFUsuarioEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Us_username;
        [XmlAttribute]
        public string? Us_username { get => _Us_username; set { if (RaiseAcceptPendingChange(value, _Us_username)) { _Us_username = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

        private int? _Pendmaxdias;
        [XmlAttribute]
        public int? Pendmaxdias { get => _Pendmaxdias; set { if (RaiseAcceptPendingChange(value, _Pendmaxdias)) { _Pendmaxdias = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargo;
        [XmlAttribute]
        public BoolCN? Ticketlargo { get => _Ticketlargo; set { if (RaiseAcceptPendingChange(value, _Ticketlargo)) { _Ticketlargo = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargocredito;
        [XmlAttribute]
        public BoolCN? Ticketlargocredito { get => _Ticketlargocredito; set { if (RaiseAcceptPendingChange(value, _Ticketlargocredito)) { _Ticketlargocredito = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargocotizacion;
        [XmlAttribute]
        public BoolCN? Ticketlargocotizacion { get => _Ticketlargocotizacion; set { if (RaiseAcceptPendingChange(value, _Ticketlargocotizacion)) { _Ticketlargocotizacion = value; OnPropertyChanged(); } } }

        private long? _Cbformaspago;
        [XmlAttribute]
        public long? Cbformaspago { get => _Cbformaspago; set { if (RaiseAcceptPendingChange(value, _Cbformaspago)) { _Cbformaspago = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cajasbotellas;
        [XmlAttribute]
        public BoolCN? Cajasbotellas { get => _Cajasbotellas; set { if (RaiseAcceptPendingChange(value, _Cajasbotellas)) { _Cajasbotellas = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private long? _Grupousuarioid;
        [XmlAttribute]
        public long? Grupousuarioid { get => _Grupousuarioid; set { if (RaiseAcceptPendingChange(value, _Grupousuarioid)) { _Grupousuarioid = value; OnPropertyChanged(); } } }

        private string? _GrupousuarioidClave;
        [XmlAttribute]
        public string? GrupousuarioidClave { get => _GrupousuarioidClave; set { if (RaiseAcceptPendingChange(value, _GrupousuarioidClave)) { _GrupousuarioidClave = value; OnPropertyChanged(); } } }

        private string? _GrupousuarioidNombre;
        [XmlAttribute]
        public string? GrupousuarioidNombre { get => _GrupousuarioidNombre; set { if (RaiseAcceptPendingChange(value, _GrupousuarioidNombre)) { _GrupousuarioidNombre = value; OnPropertyChanged(); } } }

        private string? _Nombreimpresora;
        [XmlAttribute]
        public string? Nombreimpresora { get => _Nombreimpresora; set { if (RaiseAcceptPendingChange(value, _Nombreimpresora)) { _Nombreimpresora = value; OnPropertyChanged(); } } }

        private string? _Email1;
        [XmlAttribute]
        public string? Email1 { get => _Email1; set { if (RaiseAcceptPendingChange(value, _Email1)) { _Email1 = value; OnPropertyChanged(); } } }

        private long? _Clerkid;
        [XmlAttribute]
        public long? Clerkid { get => _Clerkid; set { if (RaiseAcceptPendingChange(value, _Clerkid)) { _Clerkid = value; OnPropertyChanged(); } } }

        private string? _ClerkidClave;
        [XmlAttribute]
        public string? ClerkidClave { get => _ClerkidClave; set { if (RaiseAcceptPendingChange(value, _ClerkidClave)) { _ClerkidClave = value; OnPropertyChanged(); } } }

        private string? _ClerkidNombre;
        [XmlAttribute]
        public string? ClerkidNombre { get => _ClerkidNombre; set { if (RaiseAcceptPendingChange(value, _ClerkidNombre)) { _ClerkidNombre = value; OnPropertyChanged(); } } }

        private long? _Clerkservicios;
        [XmlAttribute]
        public long? Clerkservicios { get => _Clerkservicios; set { if (RaiseAcceptPendingChange(value, _Clerkservicios)) { _Clerkservicios = value; OnPropertyChanged(); } } }

        private string? _ClerkserviciosClave;
        [XmlAttribute]
        public string? ClerkserviciosClave { get => _ClerkserviciosClave; set { if (RaiseAcceptPendingChange(value, _ClerkserviciosClave)) { _ClerkserviciosClave = value; OnPropertyChanged(); } } }

        private string? _ClerkserviciosNombre;
        [XmlAttribute]
        public string? ClerkserviciosNombre { get => _ClerkserviciosNombre; set { if (RaiseAcceptPendingChange(value, _ClerkserviciosNombre)) { _ClerkserviciosNombre = value; OnPropertyChanged(); } } }

        private string? _Us_nombre;
        [XmlAttribute]
        public string? Us_nombre { get => _Us_nombre; set { if (RaiseAcceptPendingChange(value, _Us_nombre)) { _Us_nombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Us_vigencia;
        [XmlAttribute]
        public DateTimeOffset? Us_vigencia { get => _Us_vigencia; set { if (RaiseAcceptPendingChange(value, _Us_vigencia)) { _Us_vigencia = value; OnPropertyChanged(); } } }

        private string? _Codigoautorizacion;
        [XmlAttribute]
        public string? Codigoautorizacion { get => _Codigoautorizacion; set { if (RaiseAcceptPendingChange(value, _Codigoautorizacion)) { _Codigoautorizacion = value; OnPropertyChanged(); } } }

        private string? _Us_gaffete;
        [XmlAttribute]
        public string? Us_gaffete { get => _Us_gaffete; set { if (RaiseAcceptPendingChange(value, _Us_gaffete)) { _Us_gaffete = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidClave;
        [XmlAttribute]
        public string? ListaprecioidClave { get => _ListaprecioidClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioidClave)) { _ListaprecioidClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidNombre;
        [XmlAttribute]
        public string? ListaprecioidNombre { get => _ListaprecioidNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioidNombre)) { _ListaprecioidNombre = value; OnPropertyChanged(); } } }

        private string? _CbformaspagoClave;
        [XmlAttribute]
        public string? CbformaspagoClave { get => _CbformaspagoClave; set { if (RaiseAcceptPendingChange(value, _CbformaspagoClave)) { _CbformaspagoClave = value; OnPropertyChanged(); } } }

        private string? _CbformaspagoNombre;
        [XmlAttribute]
        public string? CbformaspagoNombre { get => _CbformaspagoNombre; set { if (RaiseAcceptPendingChange(value, _CbformaspagoNombre)) { _CbformaspagoNombre = value; OnPropertyChanged(); } } }

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
    public class WFUsuarioEditWF_Perfiles_asignadosBindingModel : Validatable
    {

        public WFUsuarioEditWF_Perfiles_asignadosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Permitido;
        [XmlAttribute]
        public int? Permitido { get => _Permitido; set { if (RaiseAcceptPendingChange(value, _Permitido)) { _Permitido = value; OnPropertyChanged(); } } }

        private string? _Pf_descripcion;
        [XmlAttribute]
        public string? Pf_descripcion { get => _Pf_descripcion; set { if (RaiseAcceptPendingChange(value, _Pf_descripcion)) { _Pf_descripcion = value; OnPropertyChanged(); } } }

        private int? _Pf_perfil;
        [XmlAttribute]
        public int? Pf_perfil { get => _Pf_perfil; set { if (RaiseAcceptPendingChange(value, _Pf_perfil)) { _Pf_perfil = value; OnPropertyChanged(); } } }

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

