
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
    public class WFSucursalEditWFBindingModel : Validatable
    {

        public WFSucursalEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private long? _Listaprecioclave;
        [XmlAttribute]
        public long? Listaprecioclave { get => _Listaprecioclave; set { if (RaiseAcceptPendingChange(value, _Listaprecioclave)) { _Listaprecioclave = value; OnPropertyChanged(); } } }

        private long? _Lista_precio_traspaso;
        [XmlAttribute]
        public long? Lista_precio_traspaso { get => _Lista_precio_traspaso; set { if (RaiseAcceptPendingChange(value, _Lista_precio_traspaso)) { _Lista_precio_traspaso = value; OnPropertyChanged(); } } }

        private int? _Maxdoctospendientes;
        [XmlAttribute]
        public int? Maxdoctospendientes { get => _Maxdoctospendientes; set { if (RaiseAcceptPendingChange(value, _Maxdoctospendientes)) { _Maxdoctospendientes = value; OnPropertyChanged(); } } }

        private long? _Precioenviotraslado;
        [XmlAttribute]
        public long? Precioenviotraslado { get => _Precioenviotraslado; set { if (RaiseAcceptPendingChange(value, _Precioenviotraslado)) { _Precioenviotraslado = value; OnPropertyChanged(); } } }

        private BoolCN? _Esmatriz;
        [XmlAttribute]
        public BoolCN? Esmatriz { get => _Esmatriz; set { if (RaiseAcceptPendingChange(value, _Esmatriz)) { _Esmatriz = value; OnPropertyChanged(); } } }

        private long? _Preciorecepciontraslado;
        [XmlAttribute]
        public long? Preciorecepciontraslado { get => _Preciorecepciontraslado; set { if (RaiseAcceptPendingChange(value, _Preciorecepciontraslado)) { _Preciorecepciontraslado = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarprecioreal;
        [XmlAttribute]
        public BoolCN? Mostrarprecioreal { get => _Mostrarprecioreal; set { if (RaiseAcceptPendingChange(value, _Mostrarprecioreal)) { _Mostrarprecioreal = value; OnPropertyChanged(); } } }

        private BoolCN? _Imnuprod;
        [XmlAttribute]
        public BoolCN? Imnuprod { get => _Imnuprod; set { if (RaiseAcceptPendingChange(value, _Imnuprod)) { _Imnuprod = value; OnPropertyChanged(); } } }

        private long? _Clienteclave;
        [XmlAttribute]
        public long? Clienteclave { get => _Clienteclave; set { if (RaiseAcceptPendingChange(value, _Clienteclave)) { _Clienteclave = value; OnPropertyChanged(); } } }

        private string? _ClienteclaveClave;
        [XmlAttribute]
        public string? ClienteclaveClave { get => _ClienteclaveClave; set { if (RaiseAcceptPendingChange(value, _ClienteclaveClave)) { _ClienteclaveClave = value; OnPropertyChanged(); } } }

        private string? _ClienteclaveNombre;
        [XmlAttribute]
        public string? ClienteclaveNombre { get => _ClienteclaveNombre; set { if (RaiseAcceptPendingChange(value, _ClienteclaveNombre)) { _ClienteclaveNombre = value; OnPropertyChanged(); } } }

        private long? _Proveedorclave;
        [XmlAttribute]
        public long? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _ProveedorclaveClave;
        [XmlAttribute]
        public string? ProveedorclaveClave { get => _ProveedorclaveClave; set { if (RaiseAcceptPendingChange(value, _ProveedorclaveClave)) { _ProveedorclaveClave = value; OnPropertyChanged(); } } }

        private string? _ProveedorclaveNombre;
        [XmlAttribute]
        public string? ProveedorclaveNombre { get => _ProveedorclaveNombre; set { if (RaiseAcceptPendingChange(value, _ProveedorclaveNombre)) { _ProveedorclaveNombre = value; OnPropertyChanged(); } } }

        private long? _Empprov;
        [XmlAttribute]
        public long? Empprov { get => _Empprov; set { if (RaiseAcceptPendingChange(value, _Empprov)) { _Empprov = value; OnPropertyChanged(); } } }

        private string? _EmpprovClave;
        [XmlAttribute]
        public string? EmpprovClave { get => _EmpprovClave; set { if (RaiseAcceptPendingChange(value, _EmpprovClave)) { _EmpprovClave = value; OnPropertyChanged(); } } }

        private string? _EmpprovNombre;
        [XmlAttribute]
        public string? EmpprovNombre { get => _EmpprovNombre; set { if (RaiseAcceptPendingChange(value, _EmpprovNombre)) { _EmpprovNombre = value; OnPropertyChanged(); } } }

        private decimal? _Porc_aumento_precio;
        [XmlAttribute]
        public decimal? Porc_aumento_precio { get => _Porc_aumento_precio; set { if (RaiseAcceptPendingChange(value, _Porc_aumento_precio)) { _Porc_aumento_precio = value; OnPropertyChanged(); } } }

        private BoolCN? _Esfranquicia;
        [XmlAttribute]
        public BoolCN? Esfranquicia { get => _Esfranquicia; set { if (RaiseAcceptPendingChange(value, _Esfranquicia)) { _Esfranquicia = value; OnPropertyChanged(); } } }

        private BoolCN? _Por_fact_elect;
        [XmlAttribute]
        public BoolCN? Por_fact_elect { get => _Por_fact_elect; set { if (RaiseAcceptPendingChange(value, _Por_fact_elect)) { _Por_fact_elect = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private long? _Surtidor;
        [XmlAttribute]
        public long? Surtidor { get => _Surtidor; set { if (RaiseAcceptPendingChange(value, _Surtidor)) { _Surtidor = value; OnPropertyChanged(); } } }

        private string? _SurtidorClave;
        [XmlAttribute]
        public string? SurtidorClave { get => _SurtidorClave; set { if (RaiseAcceptPendingChange(value, _SurtidorClave)) { _SurtidorClave = value; OnPropertyChanged(); } } }

        private string? _SurtidorNombre;
        [XmlAttribute]
        public string? SurtidorNombre { get => _SurtidorNombre; set { if (RaiseAcceptPendingChange(value, _SurtidorNombre)) { _SurtidorNombre = value; OnPropertyChanged(); } } }

        private long? _Bancoclave;
        [XmlAttribute]
        public long? Bancoclave { get => _Bancoclave; set { if (RaiseAcceptPendingChange(value, _Bancoclave)) { _Bancoclave = value; OnPropertyChanged(); } } }

        private string? _Txtnombrerespaldobd;
        [XmlAttribute]
        public string? Txtnombrerespaldobd { get => _Txtnombrerespaldobd; set { if (RaiseAcceptPendingChange(value, _Txtnombrerespaldobd)) { _Txtnombrerespaldobd = value; OnPropertyChanged(); } } }

        private string? _Cuentareferencia;
        [XmlAttribute]
        public string? Cuentareferencia { get => _Cuentareferencia; set { if (RaiseAcceptPendingChange(value, _Cuentareferencia)) { _Cuentareferencia = value; OnPropertyChanged(); } } }

        private string? _Txtrutarespaldoorigen;
        [XmlAttribute]
        public string? Txtrutarespaldoorigen { get => _Txtrutarespaldoorigen; set { if (RaiseAcceptPendingChange(value, _Txtrutarespaldoorigen)) { _Txtrutarespaldoorigen = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejaprecioxdescuento;
        [XmlAttribute]
        public BoolCN? Manejaprecioxdescuento { get => _Manejaprecioxdescuento; set { if (RaiseAcceptPendingChange(value, _Manejaprecioxdescuento)) { _Manejaprecioxdescuento = value; OnPropertyChanged(); } } }

        private string? _Prefijoprecioxdescuento;
        [XmlAttribute]
        public string? Prefijoprecioxdescuento { get => _Prefijoprecioxdescuento; set { if (RaiseAcceptPendingChange(value, _Prefijoprecioxdescuento)) { _Prefijoprecioxdescuento = value; OnPropertyChanged(); } } }

        private string? _Txtrutarespaldodestino;
        [XmlAttribute]
        public string? Txtrutarespaldodestino { get => _Txtrutarespaldodestino; set { if (RaiseAcceptPendingChange(value, _Txtrutarespaldodestino)) { _Txtrutarespaldodestino = value; OnPropertyChanged(); } } }

        private string? _Txtrutarespaldored;
        [XmlAttribute]
        public string? Txtrutarespaldored { get => _Txtrutarespaldored; set { if (RaiseAcceptPendingChange(value, _Txtrutarespaldored)) { _Txtrutarespaldored = value; OnPropertyChanged(); } } }

        private string? _Cuentapoliza;
        [XmlAttribute]
        public string? Cuentapoliza { get => _Cuentapoliza; set { if (RaiseAcceptPendingChange(value, _Cuentapoliza)) { _Cuentapoliza = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private long? _Gruposucursalid;
        [XmlAttribute]
        public long? Gruposucursalid { get => _Gruposucursalid; set { if (RaiseAcceptPendingChange(value, _Gruposucursalid)) { _Gruposucursalid = value; OnPropertyChanged(); } } }

        private string? _GruposucursalidClave;
        [XmlAttribute]
        public string? GruposucursalidClave { get => _GruposucursalidClave; set { if (RaiseAcceptPendingChange(value, _GruposucursalidClave)) { _GruposucursalidClave = value; OnPropertyChanged(); } } }

        private string? _GruposucursalidNombre;
        [XmlAttribute]
        public string? GruposucursalidNombre { get => _GruposucursalidNombre; set { if (RaiseAcceptPendingChange(value, _GruposucursalidNombre)) { _GruposucursalidNombre = value; OnPropertyChanged(); } } }

        private long? _Entrega_sat_municipioid;
        [XmlAttribute]
        public long? Entrega_sat_municipioid { get => _Entrega_sat_municipioid; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_municipioid)) { _Entrega_sat_municipioid = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_municipioidClave;
        [XmlAttribute]
        public string? Entrega_sat_municipioidClave { get => _Entrega_sat_municipioidClave; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_municipioidClave)) { _Entrega_sat_municipioidClave = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_municipioidNombre;
        [XmlAttribute]
        public string? Entrega_sat_municipioidNombre { get => _Entrega_sat_municipioidNombre; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_municipioidNombre)) { _Entrega_sat_municipioidNombre = value; OnPropertyChanged(); } } }

        private long? _Entrega_sat_coloniaid;
        [XmlAttribute]
        public long? Entrega_sat_coloniaid { get => _Entrega_sat_coloniaid; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_coloniaid)) { _Entrega_sat_coloniaid = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_coloniaidClave;
        [XmlAttribute]
        public string? Entrega_sat_coloniaidClave { get => _Entrega_sat_coloniaidClave; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_coloniaidClave)) { _Entrega_sat_coloniaidClave = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_coloniaidNombre;
        [XmlAttribute]
        public string? Entrega_sat_coloniaidNombre { get => _Entrega_sat_coloniaidNombre; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_coloniaidNombre)) { _Entrega_sat_coloniaidNombre = value; OnPropertyChanged(); } } }

        private string? _Entregacalle;
        [XmlAttribute]
        public string? Entregacalle { get => _Entregacalle; set { if (RaiseAcceptPendingChange(value, _Entregacalle)) { _Entregacalle = value; OnPropertyChanged(); } } }

        private string? _Entreganumeroexterior;
        [XmlAttribute]
        public string? Entreganumeroexterior { get => _Entreganumeroexterior; set { if (RaiseAcceptPendingChange(value, _Entreganumeroexterior)) { _Entreganumeroexterior = value; OnPropertyChanged(); } } }

        private string? _Entreganumerointerior;
        [XmlAttribute]
        public string? Entreganumerointerior { get => _Entreganumerointerior; set { if (RaiseAcceptPendingChange(value, _Entreganumerointerior)) { _Entreganumerointerior = value; OnPropertyChanged(); } } }

        private string? _Entregareferenciadom;
        [XmlAttribute]
        public string? Entregareferenciadom { get => _Entregareferenciadom; set { if (RaiseAcceptPendingChange(value, _Entregareferenciadom)) { _Entregareferenciadom = value; OnPropertyChanged(); } } }

        private decimal? _Entrega_distancia;
        [XmlAttribute]
        public decimal? Entrega_distancia { get => _Entrega_distancia; set { if (RaiseAcceptPendingChange(value, _Entrega_distancia)) { _Entrega_distancia = value; OnPropertyChanged(); } } }

        private long? _Entregaestado;
        [XmlAttribute]
        public long? Entregaestado { get => _Entregaestado; set { if (RaiseAcceptPendingChange(value, _Entregaestado)) { _Entregaestado = value; OnPropertyChanged(); } } }

        private string? _Entregacodigopostal;
        [XmlAttribute]
        public string? Entregacodigopostal { get => _Entregacodigopostal; set { if (RaiseAcceptPendingChange(value, _Entregacodigopostal)) { _Entregacodigopostal = value; OnPropertyChanged(); } } }

        private long? _Entrega_sat_localidadid;
        [XmlAttribute]
        public long? Entrega_sat_localidadid { get => _Entrega_sat_localidadid; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_localidadid)) { _Entrega_sat_localidadid = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_localidadidClave;
        [XmlAttribute]
        public string? Entrega_sat_localidadidClave { get => _Entrega_sat_localidadidClave; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_localidadidClave)) { _Entrega_sat_localidadidClave = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_localidadidNombre;
        [XmlAttribute]
        public string? Entrega_sat_localidadidNombre { get => _Entrega_sat_localidadidNombre; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_localidadidNombre)) { _Entrega_sat_localidadidNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecioclaveClave;
        [XmlAttribute]
        public string? ListaprecioclaveClave { get => _ListaprecioclaveClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioclaveClave)) { _ListaprecioclaveClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioclaveNombre;
        [XmlAttribute]
        public string? ListaprecioclaveNombre { get => _ListaprecioclaveNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioclaveNombre)) { _ListaprecioclaveNombre = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_traspasoClave;
        [XmlAttribute]
        public string? Lista_precio_traspasoClave { get => _Lista_precio_traspasoClave; set { if (RaiseAcceptPendingChange(value, _Lista_precio_traspasoClave)) { _Lista_precio_traspasoClave = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_traspasoNombre;
        [XmlAttribute]
        public string? Lista_precio_traspasoNombre { get => _Lista_precio_traspasoNombre; set { if (RaiseAcceptPendingChange(value, _Lista_precio_traspasoNombre)) { _Lista_precio_traspasoNombre = value; OnPropertyChanged(); } } }

        private string? _PrecioenviotrasladoClave;
        [XmlAttribute]
        public string? PrecioenviotrasladoClave { get => _PrecioenviotrasladoClave; set { if (RaiseAcceptPendingChange(value, _PrecioenviotrasladoClave)) { _PrecioenviotrasladoClave = value; OnPropertyChanged(); } } }

        private string? _PrecioenviotrasladoNombre;
        [XmlAttribute]
        public string? PrecioenviotrasladoNombre { get => _PrecioenviotrasladoNombre; set { if (RaiseAcceptPendingChange(value, _PrecioenviotrasladoNombre)) { _PrecioenviotrasladoNombre = value; OnPropertyChanged(); } } }

        private string? _PreciorecepciontrasladoClave;
        [XmlAttribute]
        public string? PreciorecepciontrasladoClave { get => _PreciorecepciontrasladoClave; set { if (RaiseAcceptPendingChange(value, _PreciorecepciontrasladoClave)) { _PreciorecepciontrasladoClave = value; OnPropertyChanged(); } } }

        private string? _PreciorecepciontrasladoNombre;
        [XmlAttribute]
        public string? PreciorecepciontrasladoNombre { get => _PreciorecepciontrasladoNombre; set { if (RaiseAcceptPendingChange(value, _PreciorecepciontrasladoNombre)) { _PreciorecepciontrasladoNombre = value; OnPropertyChanged(); } } }

        private string? _BancoclaveClave;
        [XmlAttribute]
        public string? BancoclaveClave { get => _BancoclaveClave; set { if (RaiseAcceptPendingChange(value, _BancoclaveClave)) { _BancoclaveClave = value; OnPropertyChanged(); } } }

        private string? _BancoclaveNombre;
        [XmlAttribute]
        public string? BancoclaveNombre { get => _BancoclaveNombre; set { if (RaiseAcceptPendingChange(value, _BancoclaveNombre)) { _BancoclaveNombre = value; OnPropertyChanged(); } } }

        private string? _EntregaestadoClave;
        [XmlAttribute]
        public string? EntregaestadoClave { get => _EntregaestadoClave; set { if (RaiseAcceptPendingChange(value, _EntregaestadoClave)) { _EntregaestadoClave = value; OnPropertyChanged(); } } }

        private string? _EntregaestadoNombre;
        [XmlAttribute]
        public string? EntregaestadoNombre { get => _EntregaestadoNombre; set { if (RaiseAcceptPendingChange(value, _EntregaestadoNombre)) { _EntregaestadoNombre = value; OnPropertyChanged(); } } }

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

