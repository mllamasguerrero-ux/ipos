
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

    public class Sucursal_infoBindingModelGenerated : Validatable, IBaseBindingModel

    {

        public Sucursal_infoBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public Sucursal_infoBindingModelGenerated(Sucursal_info item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }
        #endif


        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId ?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value ?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId ?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value ?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id ?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value ?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value ?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private BoolCN? _Esmatriz;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esmatriz { get => _Esmatriz ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esmatriz)) { _Esmatriz = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Esfranquicia;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esfranquicia { get => _Esfranquicia ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esfranquicia)) { _Esfranquicia = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Cuentareferencia;
        [XmlAttribute]
        public string? Cuentareferencia { get => _Cuentareferencia; set { if (RaiseAcceptPendingChange(value, _Cuentareferencia)) { _Cuentareferencia = value; OnPropertyChanged(); } } }

        private string? _Cuentapoliza;
        [XmlAttribute]
        public string? Cuentapoliza { get => _Cuentapoliza; set { if (RaiseAcceptPendingChange(value, _Cuentapoliza)) { _Cuentapoliza = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave ?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value ?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre ?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value ?? ""; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Memo;
        [XmlAttribute]
        public string? Memo { get => _Memo; set { if (RaiseAcceptPendingChange(value, _Memo)) { _Memo = value; OnPropertyChanged(); } } }

        private int? _Maxdoctospendientes;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public int? Maxdoctospendientes { get => _Maxdoctospendientes ?? 0; set { if (RaiseAcceptPendingChange(value, _Maxdoctospendientes)) { _Maxdoctospendientes = value ?? 0; OnPropertyChanged(); } } }

        private long? _Sucursal_info_opciones_Gruposucursalid;
        [XmlAttribute]
        public long? Sucursal_info_opciones_Gruposucursalid { get => _Sucursal_info_opciones_Gruposucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_Gruposucursalid)) { _Sucursal_info_opciones_Gruposucursalid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_GruposucursalClave;
        [XmlAttribute]
        public string? Sucursal_info_opciones_GruposucursalClave { get => _Sucursal_info_opciones_GruposucursalClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_GruposucursalClave)) { _Sucursal_info_opciones_GruposucursalClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_GruposucursalNombre;
        [XmlAttribute]
        public string? Sucursal_info_opciones_GruposucursalNombre { get => _Sucursal_info_opciones_GruposucursalNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_GruposucursalNombre)) { _Sucursal_info_opciones_GruposucursalNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_info_opciones_Clienteid;
        [XmlAttribute]
        public long? Sucursal_info_opciones_Clienteid { get => _Sucursal_info_opciones_Clienteid; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_Clienteid)) { _Sucursal_info_opciones_Clienteid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_ClienteClave;
        [XmlAttribute]
        public string? Sucursal_info_opciones_ClienteClave { get => _Sucursal_info_opciones_ClienteClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_ClienteClave)) { _Sucursal_info_opciones_ClienteClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_ClienteNombre;
        [XmlAttribute]
        public string? Sucursal_info_opciones_ClienteNombre { get => _Sucursal_info_opciones_ClienteNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_ClienteNombre)) { _Sucursal_info_opciones_ClienteNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_info_opciones_Proveedorid;
        [XmlAttribute]
        public long? Sucursal_info_opciones_Proveedorid { get => _Sucursal_info_opciones_Proveedorid; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_Proveedorid)) { _Sucursal_info_opciones_Proveedorid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_ProveedorClave;
        [XmlAttribute]
        public string? Sucursal_info_opciones_ProveedorClave { get => _Sucursal_info_opciones_ProveedorClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_ProveedorClave)) { _Sucursal_info_opciones_ProveedorClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_ProveedorNombre;
        [XmlAttribute]
        public string? Sucursal_info_opciones_ProveedorNombre { get => _Sucursal_info_opciones_ProveedorNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_ProveedorNombre)) { _Sucursal_info_opciones_ProveedorNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_info_opciones_Bancoid;
        [XmlAttribute]
        public long? Sucursal_info_opciones_Bancoid { get => _Sucursal_info_opciones_Bancoid; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_Bancoid)) { _Sucursal_info_opciones_Bancoid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_BancoClave;
        [XmlAttribute]
        public string? Sucursal_info_opciones_BancoClave { get => _Sucursal_info_opciones_BancoClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_BancoClave)) { _Sucursal_info_opciones_BancoClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_BancoNombre;
        [XmlAttribute]
        public string? Sucursal_info_opciones_BancoNombre { get => _Sucursal_info_opciones_BancoNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_BancoNombre)) { _Sucursal_info_opciones_BancoNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_info_opciones_Empprovid;
        [XmlAttribute]
        public long? Sucursal_info_opciones_Empprovid { get => _Sucursal_info_opciones_Empprovid; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_Empprovid)) { _Sucursal_info_opciones_Empprovid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_EmpprovClave;
        [XmlAttribute]
        public string? Sucursal_info_opciones_EmpprovClave { get => _Sucursal_info_opciones_EmpprovClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_EmpprovClave)) { _Sucursal_info_opciones_EmpprovClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_opciones_EmpprovNombre;
        [XmlAttribute]
        public string? Sucursal_info_opciones_EmpprovNombre { get => _Sucursal_info_opciones_EmpprovNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_opciones_EmpprovNombre)) { _Sucursal_info_opciones_EmpprovNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Sucursal_fact_elect_Por_fact_elect;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Sucursal_fact_elect_Por_fact_elect { get => _Sucursal_fact_elect_Por_fact_elect ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Por_fact_elect)) { _Sucursal_fact_elect_Por_fact_elect = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entregacalle;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entregacalle { get => _Sucursal_fact_elect_Entregacalle; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entregacalle)) { _Sucursal_fact_elect_Entregacalle = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entreganumeroexterior;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entreganumeroexterior { get => _Sucursal_fact_elect_Entreganumeroexterior; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entreganumeroexterior)) { _Sucursal_fact_elect_Entreganumeroexterior = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entreganumerointerior;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entreganumerointerior { get => _Sucursal_fact_elect_Entreganumerointerior; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entreganumerointerior)) { _Sucursal_fact_elect_Entreganumerointerior = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entregacolonia;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entregacolonia { get => _Sucursal_fact_elect_Entregacolonia; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entregacolonia)) { _Sucursal_fact_elect_Entregacolonia = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entregamunicipio;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entregamunicipio { get => _Sucursal_fact_elect_Entregamunicipio; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entregamunicipio)) { _Sucursal_fact_elect_Entregamunicipio = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entregacodigopostal;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entregacodigopostal { get => _Sucursal_fact_elect_Entregacodigopostal; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entregacodigopostal)) { _Sucursal_fact_elect_Entregacodigopostal = value; OnPropertyChanged(); } } }

        private long? _Sucursal_fact_elect_Entregaestadoid;
        [XmlAttribute]
        public long? Sucursal_fact_elect_Entregaestadoid { get => _Sucursal_fact_elect_Entregaestadoid; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entregaestadoid)) { _Sucursal_fact_elect_Entregaestadoid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_EntregaestadoClave;
        [XmlAttribute]
        public string? Sucursal_fact_elect_EntregaestadoClave { get => _Sucursal_fact_elect_EntregaestadoClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_EntregaestadoClave)) { _Sucursal_fact_elect_EntregaestadoClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_EntregaestadoNombre;
        [XmlAttribute]
        public string? Sucursal_fact_elect_EntregaestadoNombre { get => _Sucursal_fact_elect_EntregaestadoNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_EntregaestadoNombre)) { _Sucursal_fact_elect_EntregaestadoNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_fact_elect_Entrega_Sat_Coloniaid;
        [XmlAttribute]
        public long? Sucursal_fact_elect_Entrega_Sat_Coloniaid { get => _Sucursal_fact_elect_Entrega_Sat_Coloniaid; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_Coloniaid)) { _Sucursal_fact_elect_Entrega_Sat_Coloniaid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entrega_Sat_ColoniaClave;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entrega_Sat_ColoniaClave { get => _Sucursal_fact_elect_Entrega_Sat_ColoniaClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_ColoniaClave)) { _Sucursal_fact_elect_Entrega_Sat_ColoniaClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entrega_Sat_ColoniaNombre;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entrega_Sat_ColoniaNombre { get => _Sucursal_fact_elect_Entrega_Sat_ColoniaNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_ColoniaNombre)) { _Sucursal_fact_elect_Entrega_Sat_ColoniaNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_fact_elect_Entrega_Sat_Localidadid;
        [XmlAttribute]
        public long? Sucursal_fact_elect_Entrega_Sat_Localidadid { get => _Sucursal_fact_elect_Entrega_Sat_Localidadid; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_Localidadid)) { _Sucursal_fact_elect_Entrega_Sat_Localidadid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entrega_Sat_LocalidadClave;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entrega_Sat_LocalidadClave { get => _Sucursal_fact_elect_Entrega_Sat_LocalidadClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_LocalidadClave)) { _Sucursal_fact_elect_Entrega_Sat_LocalidadClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entrega_Sat_LocalidadNombre;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entrega_Sat_LocalidadNombre { get => _Sucursal_fact_elect_Entrega_Sat_LocalidadNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_LocalidadNombre)) { _Sucursal_fact_elect_Entrega_Sat_LocalidadNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_fact_elect_Entrega_Sat_Municipioid;
        [XmlAttribute]
        public long? Sucursal_fact_elect_Entrega_Sat_Municipioid { get => _Sucursal_fact_elect_Entrega_Sat_Municipioid; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_Municipioid)) { _Sucursal_fact_elect_Entrega_Sat_Municipioid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entrega_Sat_MunicipioClave;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entrega_Sat_MunicipioClave { get => _Sucursal_fact_elect_Entrega_Sat_MunicipioClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_MunicipioClave)) { _Sucursal_fact_elect_Entrega_Sat_MunicipioClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entrega_Sat_MunicipioNombre;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entrega_Sat_MunicipioNombre { get => _Sucursal_fact_elect_Entrega_Sat_MunicipioNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Sat_MunicipioNombre)) { _Sucursal_fact_elect_Entrega_Sat_MunicipioNombre = value; OnPropertyChanged(); } } }

        private decimal? _Sucursal_fact_elect_Entrega_Distancia;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Sucursal_fact_elect_Entrega_Distancia { get => _Sucursal_fact_elect_Entrega_Distancia ?? 0; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entrega_Distancia)) { _Sucursal_fact_elect_Entrega_Distancia = value ?? 0; OnPropertyChanged(); } } }

        private string? _Sucursal_fact_elect_Entregareferenciadom;
        [XmlAttribute]
        public string? Sucursal_fact_elect_Entregareferenciadom { get => _Sucursal_fact_elect_Entregareferenciadom; set { if (RaiseAcceptPendingChange(value, _Sucursal_fact_elect_Entregareferenciadom)) { _Sucursal_fact_elect_Entregareferenciadom = value; OnPropertyChanged(); } } }

        private BoolCN? _Sucursal_importacion_Manejaprecioxdescuento;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Sucursal_importacion_Manejaprecioxdescuento { get => _Sucursal_importacion_Manejaprecioxdescuento ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_Manejaprecioxdescuento)) { _Sucursal_importacion_Manejaprecioxdescuento = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Sucursal_importacion_Prefijoprecioxdescuento;
        [XmlAttribute]
        public string? Sucursal_importacion_Prefijoprecioxdescuento { get => _Sucursal_importacion_Prefijoprecioxdescuento; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_Prefijoprecioxdescuento)) { _Sucursal_importacion_Prefijoprecioxdescuento = value; OnPropertyChanged(); } } }

        private decimal? _Sucursal_importacion_Porc_aumento_precio;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Sucursal_importacion_Porc_aumento_precio { get => _Sucursal_importacion_Porc_aumento_precio ?? 0; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_Porc_aumento_precio)) { _Sucursal_importacion_Porc_aumento_precio = value ?? 0; OnPropertyChanged(); } } }

        private long? _Sucursal_importacion_Listaprecioid;
        [XmlAttribute]
        public long? Sucursal_importacion_Listaprecioid { get => _Sucursal_importacion_Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_Listaprecioid)) { _Sucursal_importacion_Listaprecioid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_importacion_ListaprecioClave;
        [XmlAttribute]
        public string? Sucursal_importacion_ListaprecioClave { get => _Sucursal_importacion_ListaprecioClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_ListaprecioClave)) { _Sucursal_importacion_ListaprecioClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_importacion_ListaprecioNombre;
        [XmlAttribute]
        public string? Sucursal_importacion_ListaprecioNombre { get => _Sucursal_importacion_ListaprecioNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_ListaprecioNombre)) { _Sucursal_importacion_ListaprecioNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_importacion_Surtidorid;
        [XmlAttribute]
        public long? Sucursal_importacion_Surtidorid { get => _Sucursal_importacion_Surtidorid; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_Surtidorid)) { _Sucursal_importacion_Surtidorid = value; OnPropertyChanged(); } } }

        private string? _Sucursal_importacion_SurtidorClave;
        [XmlAttribute]
        public string? Sucursal_importacion_SurtidorClave { get => _Sucursal_importacion_SurtidorClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_SurtidorClave)) { _Sucursal_importacion_SurtidorClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_importacion_SurtidorNombre;
        [XmlAttribute]
        public string? Sucursal_importacion_SurtidorNombre { get => _Sucursal_importacion_SurtidorNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_SurtidorNombre)) { _Sucursal_importacion_SurtidorNombre = value; OnPropertyChanged(); } } }



        private BoolCS? _Sucursal_importacion_Imnuprod;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Sucursal_importacion_Imnuprod { get => _Sucursal_importacion_Imnuprod ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Sucursal_importacion_Imnuprod)) { _Sucursal_importacion_Imnuprod = value ?? BoolCS.S; OnPropertyChanged(); } } }


        private string? _Sucursal_respaldo_Rutarespaldoorigen;
        [XmlAttribute]
        public string? Sucursal_respaldo_Rutarespaldoorigen { get => _Sucursal_respaldo_Rutarespaldoorigen; set { if (RaiseAcceptPendingChange(value, _Sucursal_respaldo_Rutarespaldoorigen)) { _Sucursal_respaldo_Rutarespaldoorigen = value; OnPropertyChanged(); } } }

        private string? _Sucursal_respaldo_Rutarespaldodestino;
        [XmlAttribute]
        public string? Sucursal_respaldo_Rutarespaldodestino { get => _Sucursal_respaldo_Rutarespaldodestino; set { if (RaiseAcceptPendingChange(value, _Sucursal_respaldo_Rutarespaldodestino)) { _Sucursal_respaldo_Rutarespaldodestino = value; OnPropertyChanged(); } } }

        private string? _Sucursal_respaldo_Rutarespaldored;
        [XmlAttribute]
        public string? Sucursal_respaldo_Rutarespaldored { get => _Sucursal_respaldo_Rutarespaldored; set { if (RaiseAcceptPendingChange(value, _Sucursal_respaldo_Rutarespaldored)) { _Sucursal_respaldo_Rutarespaldored = value; OnPropertyChanged(); } } }

        private string? _Sucursal_respaldo_Nombrerespaldobd;
        [XmlAttribute]
        public string? Sucursal_respaldo_Nombrerespaldobd { get => _Sucursal_respaldo_Nombrerespaldobd; set { if (RaiseAcceptPendingChange(value, _Sucursal_respaldo_Nombrerespaldobd)) { _Sucursal_respaldo_Nombrerespaldobd = value; OnPropertyChanged(); } } }

        private BoolCN? _Sucursal_traslado_Mostrarprecioreal;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Sucursal_traslado_Mostrarprecioreal { get => _Sucursal_traslado_Mostrarprecioreal ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Mostrarprecioreal)) { _Sucursal_traslado_Mostrarprecioreal = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Sucursal_traslado_Preciorecepciontraslado;
        [XmlAttribute]
        public long? Sucursal_traslado_Preciorecepciontraslado { get => _Sucursal_traslado_Preciorecepciontraslado; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Preciorecepciontraslado)) { _Sucursal_traslado_Preciorecepciontraslado = value; OnPropertyChanged(); } } }

        private string? _Sucursal_traslado_Preciorecepciontraslado_Clave;
        [XmlAttribute]
        public string? Sucursal_traslado_Preciorecepciontraslado_Clave { get => _Sucursal_traslado_Preciorecepciontraslado_Clave; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Preciorecepciontraslado_Clave)) { _Sucursal_traslado_Preciorecepciontraslado_Clave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_traslado_Preciorecepciontraslado_Nombre;
        [XmlAttribute]
        public string? Sucursal_traslado_Preciorecepciontraslado_Nombre { get => _Sucursal_traslado_Preciorecepciontraslado_Nombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Preciorecepciontraslado_Nombre)) { _Sucursal_traslado_Preciorecepciontraslado_Nombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_traslado_Precioenviotraslado;
        [XmlAttribute]
        public long? Sucursal_traslado_Precioenviotraslado { get => _Sucursal_traslado_Precioenviotraslado; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Precioenviotraslado)) { _Sucursal_traslado_Precioenviotraslado = value; OnPropertyChanged(); } } }

        private string? _Sucursal_traslado_Precioenviotraslado_Clave;
        [XmlAttribute]
        public string? Sucursal_traslado_Precioenviotraslado_Clave { get => _Sucursal_traslado_Precioenviotraslado_Clave; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Precioenviotraslado_Clave)) { _Sucursal_traslado_Precioenviotraslado_Clave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_traslado_Precioenviotraslado_Nombre;
        [XmlAttribute]
        public string? Sucursal_traslado_Precioenviotraslado_Nombre { get => _Sucursal_traslado_Precioenviotraslado_Nombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Precioenviotraslado_Nombre)) { _Sucursal_traslado_Precioenviotraslado_Nombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_traslado_Lista_precio_traspaso;
        [XmlAttribute]
        public long? Sucursal_traslado_Lista_precio_traspaso { get => _Sucursal_traslado_Lista_precio_traspaso; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Lista_precio_traspaso)) { _Sucursal_traslado_Lista_precio_traspaso = value; OnPropertyChanged(); } } }

        private string? _Sucursal_traslado_Lista_precio_traspaso_Clave;
        [XmlAttribute]
        public string? Sucursal_traslado_Lista_precio_traspaso_Clave { get => _Sucursal_traslado_Lista_precio_traspaso_Clave; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Lista_precio_traspaso_Clave)) { _Sucursal_traslado_Lista_precio_traspaso_Clave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_traslado_Lista_precio_traspaso_Nombre;
        [XmlAttribute]
        public string? Sucursal_traslado_Lista_precio_traspaso_Nombre { get => _Sucursal_traslado_Lista_precio_traspaso_Nombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_traslado_Lista_precio_traspaso_Nombre)) { _Sucursal_traslado_Lista_precio_traspaso_Nombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Sucursal_info"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Cuentareferencia|Cuentapoliza|Clave|Nombre|Descripcion|Memo|Sucursal_info_opciones.Gruposucursal.Clave|Sucursal_info_opciones.Gruposucursal.Nombre|Sucursal_info_opciones.Cliente.Clave|Sucursal_info_opciones.Cliente.Nombre|Sucursal_info_opciones.Proveedor.Clave|Sucursal_info_opciones.Proveedor.Nombre|Sucursal_info_opciones.Banco.Clave|Sucursal_info_opciones.Banco.Nombre|Sucursal_info_opciones.Empprov.Clave|Sucursal_info_opciones.Empprov.Nombre|Sucursal_info_opciones!.Sucursal_fact_elect.Entregacalle|Sucursal_info_opciones!.Sucursal_fact_elect.Entreganumeroexterior|Sucursal_info_opciones!.Sucursal_fact_elect.Entreganumerointerior|Sucursal_info_opciones!.Sucursal_fact_elect.Entregacolonia|Sucursal_info_opciones!.Sucursal_fact_elect.Entregamunicipio|Sucursal_info_opciones!.Sucursal_fact_elect.Entregacodigopostal|Sucursal_info_opciones.Sucursal_fact_elect.Entregaestado.Clave|Sucursal_info_opciones.Sucursal_fact_elect.Entregaestado.Nombre|Sucursal_info_opciones.Sucursal_fact_elect.Entrega_Sat_Colonia.Clave|Sucursal_info_opciones.Sucursal_fact_elect.Entrega_Sat_Colonia.Nombre|Sucursal_info_opciones.Sucursal_fact_elect.Entrega_Sat_Localidad.Clave|Sucursal_info_opciones.Sucursal_fact_elect.Entrega_Sat_Localidad.Nombre|Sucursal_info_opciones.Sucursal_fact_elect.Entrega_Sat_Municipio.Clave|Sucursal_info_opciones.Sucursal_fact_elect.Entrega_Sat_Municipio.Nombre|Sucursal_info_opciones!.Sucursal_fact_elect.Entregareferenciadom|Sucursal_info_opciones!.Sucursal_importacion.Prefijoprecioxdescuento|Sucursal_info_opciones.Sucursal_importacion.Listaprecio.Clave|Sucursal_info_opciones.Sucursal_importacion.Listaprecio.Nombre|Sucursal_info_opciones.Sucursal_importacion.Surtidor.Clave|Sucursal_info_opciones.Sucursal_importacion.Surtidor.Nombre|Sucursal_info_opciones!.Sucursal_respaldo.Rutarespaldoorigen|Sucursal_info_opciones!.Sucursal_respaldo.Rutarespaldodestino|Sucursal_info_opciones!.Sucursal_respaldo.Rutarespaldored|Sucursal_info_opciones!.Sucursal_respaldo.Nombrerespaldobd|Sucursal_info_opciones.Sucursal_traslado.Preciorecepciontraslado_.Clave|Sucursal_info_opciones.Sucursal_traslado.Preciorecepciontraslado_.Nombre|Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado_.Clave|Sucursal_info_opciones.Sucursal_traslado.Precioenviotraslado_.Nombre|Sucursal_info_opciones.Sucursal_traslado.Lista_precio_traspaso_.Clave|Sucursal_info_opciones.Sucursal_traslado.Lista_precio_traspaso_.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Sucursal_info item)
        {

            this._Sucursal_info_opciones_GruposucursalClave = item.Sucursal_info_opciones?.Gruposucursal?.Clave;

            this._Sucursal_info_opciones_GruposucursalNombre = item.Sucursal_info_opciones?.Gruposucursal?.Nombre;

            this._Sucursal_info_opciones_ClienteClave = item.Sucursal_info_opciones?.Cliente?.Clave;

            this._Sucursal_info_opciones_ClienteNombre = item.Sucursal_info_opciones?.Cliente?.Nombre;

            this._Sucursal_info_opciones_ProveedorClave = item.Sucursal_info_opciones?.Proveedor?.Clave;

            this._Sucursal_info_opciones_ProveedorNombre = item.Sucursal_info_opciones?.Proveedor?.Nombre;

            this._Sucursal_info_opciones_BancoClave = item.Sucursal_info_opciones?.Banco?.Clave;

            this._Sucursal_info_opciones_BancoNombre = item.Sucursal_info_opciones?.Banco?.Nombre;

            this._Sucursal_info_opciones_EmpprovClave = item.Sucursal_info_opciones?.Empprov?.Clave;

            this._Sucursal_info_opciones_EmpprovNombre = item.Sucursal_info_opciones?.Empprov?.Nombre;

            this._Sucursal_fact_elect_EntregaestadoClave = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregaestado?.Clave;

            this._Sucursal_fact_elect_EntregaestadoNombre = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregaestado?.Nombre;

            this._Sucursal_fact_elect_Entrega_Sat_ColoniaClave = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Colonia?.Clave;

            this._Sucursal_fact_elect_Entrega_Sat_ColoniaNombre = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Colonia?.Nombre;

            this._Sucursal_fact_elect_Entrega_Sat_LocalidadClave = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Localidad?.Clave;

            this._Sucursal_fact_elect_Entrega_Sat_LocalidadNombre = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Localidad?.Nombre;

            this._Sucursal_fact_elect_Entrega_Sat_MunicipioClave = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Municipio?.Clave;

            this._Sucursal_fact_elect_Entrega_Sat_MunicipioNombre = item.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Municipio?.Nombre;

            this._Sucursal_importacion_ListaprecioClave = item.Sucursal_info_opciones?.Sucursal_importacion?.Listaprecio?.Clave;

            this._Sucursal_importacion_ListaprecioNombre = item.Sucursal_info_opciones?.Sucursal_importacion?.Listaprecio?.Nombre;

            this._Sucursal_importacion_SurtidorClave = item.Sucursal_info_opciones?.Sucursal_importacion?.Surtidor?.Clave;

            this._Sucursal_importacion_SurtidorNombre = item.Sucursal_info_opciones?.Sucursal_importacion?.Surtidor?.Nombre;

            this._Sucursal_traslado_Preciorecepciontraslado_Clave = item.Sucursal_info_opciones?.Sucursal_traslado?.Preciorecepciontraslado_?.Clave;

            this._Sucursal_traslado_Preciorecepciontraslado_Nombre = item.Sucursal_info_opciones?.Sucursal_traslado?.Preciorecepciontraslado_?.Nombre;

            this._Sucursal_traslado_Precioenviotraslado_Clave = item.Sucursal_info_opciones?.Sucursal_traslado?.Precioenviotraslado_?.Clave;

            this._Sucursal_traslado_Precioenviotraslado_Nombre = item.Sucursal_info_opciones?.Sucursal_traslado?.Precioenviotraslado_?.Nombre;

            this._Sucursal_traslado_Lista_precio_traspaso_Clave = item.Sucursal_info_opciones?.Sucursal_traslado?.Lista_precio_traspaso_?.Clave;

            this._Sucursal_traslado_Lista_precio_traspaso_Nombre = item.Sucursal_info_opciones?.Sucursal_traslado?.Lista_precio_traspaso_?.Nombre;


        }


        public void FillEntityValues(ref Sucursal_info item)
        {


            item.CreadoPorId = CreadoPorId;


            item.ModificadoPorId = ModificadoPorId;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Esmatriz = Esmatriz ?? BoolCN.N;


            item.Esfranquicia = Esfranquicia ?? BoolCN.N;


            item.Cuentareferencia = Cuentareferencia;


            item.Cuentapoliza = Cuentapoliza;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.Descripcion = Descripcion;


            item.Memo = Memo;


            item.Maxdoctospendientes = Maxdoctospendientes ?? 0;


            if (item.Sucursal_info_opciones != null)
                item.Sucursal_info_opciones!.Gruposucursalid = Sucursal_info_opciones_Gruposucursalid;
            else if (item.Sucursal_info_opciones == null && Sucursal_info_opciones_Gruposucursalid != null)
            {
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();
                item.Sucursal_info_opciones!.Gruposucursalid = Sucursal_info_opciones_Gruposucursalid;
            }

            if (item.Sucursal_info_opciones != null)
                item.Sucursal_info_opciones!.Clienteid = Sucursal_info_opciones_Clienteid;
            else if (item.Sucursal_info_opciones == null && Sucursal_info_opciones_Clienteid != null)
            {
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();
                item.Sucursal_info_opciones!.Clienteid = Sucursal_info_opciones_Clienteid;
            }

            if (item.Sucursal_info_opciones != null)
                item.Sucursal_info_opciones!.Proveedorid = Sucursal_info_opciones_Proveedorid;
            else if (item.Sucursal_info_opciones == null && Sucursal_info_opciones_Proveedorid != null)
            {
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();
                item.Sucursal_info_opciones!.Proveedorid = Sucursal_info_opciones_Proveedorid;
            }

            if (item.Sucursal_info_opciones != null)
                item.Sucursal_info_opciones!.Bancoid = Sucursal_info_opciones_Bancoid;
            else if (item.Sucursal_info_opciones == null && Sucursal_info_opciones_Bancoid != null)
            {
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();
                item.Sucursal_info_opciones!.Bancoid = Sucursal_info_opciones_Bancoid;
            }

            if (item.Sucursal_info_opciones != null)
                item.Sucursal_info_opciones!.Empprovid = Sucursal_info_opciones_Empprovid;
            else if (item.Sucursal_info_opciones == null && Sucursal_info_opciones_Empprovid != null)
            {
                item.Sucursal_info_opciones = CreateSubEntity<Sucursal_info_opciones>();
                item.Sucursal_info_opciones!.Empprovid = Sucursal_info_opciones_Empprovid;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Por_fact_elect = Sucursal_fact_elect_Por_fact_elect ?? BoolCN.N;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Por_fact_elect != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Por_fact_elect = Sucursal_fact_elect_Por_fact_elect ?? BoolCN.N;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacalle = Sucursal_fact_elect_Entregacalle;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entregacalle != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacalle = Sucursal_fact_elect_Entregacalle;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entreganumeroexterior = Sucursal_fact_elect_Entreganumeroexterior;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entreganumeroexterior != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entreganumeroexterior = Sucursal_fact_elect_Entreganumeroexterior;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entreganumerointerior = Sucursal_fact_elect_Entreganumerointerior;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entreganumerointerior != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entreganumerointerior = Sucursal_fact_elect_Entreganumerointerior;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacolonia = Sucursal_fact_elect_Entregacolonia;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entregacolonia != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacolonia = Sucursal_fact_elect_Entregacolonia;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregamunicipio = Sucursal_fact_elect_Entregamunicipio;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entregamunicipio != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregamunicipio = Sucursal_fact_elect_Entregamunicipio;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacodigopostal = Sucursal_fact_elect_Entregacodigopostal;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entregacodigopostal != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacodigopostal = Sucursal_fact_elect_Entregacodigopostal;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregaestadoid = Sucursal_fact_elect_Entregaestadoid;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entregaestadoid != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregaestadoid = Sucursal_fact_elect_Entregaestadoid;
            }


            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Coloniaid = Sucursal_fact_elect_Entrega_Sat_Coloniaid;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entrega_Sat_Coloniaid != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Coloniaid = Sucursal_fact_elect_Entrega_Sat_Coloniaid;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Localidadid = Sucursal_fact_elect_Entrega_Sat_Localidadid;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entrega_Sat_Localidadid != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Localidadid = Sucursal_fact_elect_Entrega_Sat_Localidadid;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Municipioid = Sucursal_fact_elect_Entrega_Sat_Municipioid;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entrega_Sat_Municipioid != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Municipioid = Sucursal_fact_elect_Entrega_Sat_Municipioid;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Distancia = Sucursal_fact_elect_Entrega_Distancia ?? 0;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entrega_Distancia != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Distancia = Sucursal_fact_elect_Entrega_Distancia ?? 0;
            }

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null)
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregareferenciadom = Sucursal_fact_elect_Entregareferenciadom;
            else if (item.Sucursal_info_opciones!.Sucursal_fact_elect == null && Sucursal_fact_elect_Entregareferenciadom != null)
            {
                item.Sucursal_info_opciones!.Sucursal_fact_elect = CreateSubEntity<Sucursal_fact_elect>();
                item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregareferenciadom = Sucursal_fact_elect_Entregareferenciadom;
            }

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null)
                item.Sucursal_info_opciones!.Sucursal_importacion!.Manejaprecioxdescuento = Sucursal_importacion_Manejaprecioxdescuento ?? BoolCN.N;
            else if (item.Sucursal_info_opciones!.Sucursal_importacion == null && Sucursal_importacion_Manejaprecioxdescuento != null)
            {
                item.Sucursal_info_opciones!.Sucursal_importacion = CreateSubEntity<Sucursal_importacion>();
                item.Sucursal_info_opciones!.Sucursal_importacion!.Manejaprecioxdescuento = Sucursal_importacion_Manejaprecioxdescuento ?? BoolCN.N;
            }

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null)
                item.Sucursal_info_opciones!.Sucursal_importacion!.Prefijoprecioxdescuento = Sucursal_importacion_Prefijoprecioxdescuento;
            else if (item.Sucursal_info_opciones!.Sucursal_importacion == null && Sucursal_importacion_Prefijoprecioxdescuento != null)
            {
                item.Sucursal_info_opciones!.Sucursal_importacion = CreateSubEntity<Sucursal_importacion>();
                item.Sucursal_info_opciones!.Sucursal_importacion!.Prefijoprecioxdescuento = Sucursal_importacion_Prefijoprecioxdescuento;
            }

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null)
                item.Sucursal_info_opciones!.Sucursal_importacion!.Porc_aumento_precio = Sucursal_importacion_Porc_aumento_precio ?? 0;
            else if (item.Sucursal_info_opciones!.Sucursal_importacion == null && Sucursal_importacion_Porc_aumento_precio != null)
            {
                item.Sucursal_info_opciones!.Sucursal_importacion = CreateSubEntity<Sucursal_importacion>();
                item.Sucursal_info_opciones!.Sucursal_importacion!.Porc_aumento_precio = Sucursal_importacion_Porc_aumento_precio ?? 0;
            }

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null)
                item.Sucursal_info_opciones!.Sucursal_importacion!.Listaprecioid = Sucursal_importacion_Listaprecioid;
            else if (item.Sucursal_info_opciones!.Sucursal_importacion == null && Sucursal_importacion_Listaprecioid != null)
            {
                item.Sucursal_info_opciones!.Sucursal_importacion = CreateSubEntity<Sucursal_importacion>();
                item.Sucursal_info_opciones!.Sucursal_importacion!.Listaprecioid = Sucursal_importacion_Listaprecioid;
            }

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null)
                item.Sucursal_info_opciones!.Sucursal_importacion!.Surtidorid = Sucursal_importacion_Surtidorid;
            else if (item.Sucursal_info_opciones!.Sucursal_importacion == null && Sucursal_importacion_Surtidorid != null)
            {
                item.Sucursal_info_opciones!.Sucursal_importacion = CreateSubEntity<Sucursal_importacion>();
                item.Sucursal_info_opciones!.Sucursal_importacion!.Surtidorid = Sucursal_importacion_Surtidorid;
            }


            if (item.Sucursal_info_opciones!.Sucursal_importacion != null)
                item.Sucursal_info_opciones!.Sucursal_importacion!.Imnuprod = Sucursal_importacion_Imnuprod ?? BoolCS.S;
            else if (item.Sucursal_info_opciones!.Sucursal_importacion == null && Sucursal_importacion_Imnuprod != null)
            {
                item.Sucursal_info_opciones!.Sucursal_importacion = CreateSubEntity<Sucursal_importacion>();
                item.Sucursal_info_opciones!.Sucursal_importacion!.Imnuprod = Sucursal_importacion_Imnuprod ?? BoolCS.S;
            }

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null)
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldoorigen = Sucursal_respaldo_Rutarespaldoorigen;
            else if (item.Sucursal_info_opciones!.Sucursal_respaldo == null && Sucursal_respaldo_Rutarespaldoorigen != null)
            {
                item.Sucursal_info_opciones!.Sucursal_respaldo = CreateSubEntity<Sucursal_respaldo>();
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldoorigen = Sucursal_respaldo_Rutarespaldoorigen;
            }

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null)
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldodestino = Sucursal_respaldo_Rutarespaldodestino;
            else if (item.Sucursal_info_opciones!.Sucursal_respaldo == null && Sucursal_respaldo_Rutarespaldodestino != null)
            {
                item.Sucursal_info_opciones!.Sucursal_respaldo = CreateSubEntity<Sucursal_respaldo>();
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldodestino = Sucursal_respaldo_Rutarespaldodestino;
            }

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null)
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldored = Sucursal_respaldo_Rutarespaldored;
            else if (item.Sucursal_info_opciones!.Sucursal_respaldo == null && Sucursal_respaldo_Rutarespaldored != null)
            {
                item.Sucursal_info_opciones!.Sucursal_respaldo = CreateSubEntity<Sucursal_respaldo>();
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldored = Sucursal_respaldo_Rutarespaldored;
            }

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null)
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Nombrerespaldobd = Sucursal_respaldo_Nombrerespaldobd;
            else if (item.Sucursal_info_opciones!.Sucursal_respaldo == null && Sucursal_respaldo_Nombrerespaldobd != null)
            {
                item.Sucursal_info_opciones!.Sucursal_respaldo = CreateSubEntity<Sucursal_respaldo>();
                item.Sucursal_info_opciones!.Sucursal_respaldo!.Nombrerespaldobd = Sucursal_respaldo_Nombrerespaldobd;
            }

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null)
                item.Sucursal_info_opciones!.Sucursal_traslado!.Mostrarprecioreal = Sucursal_traslado_Mostrarprecioreal ?? BoolCN.N;
            else if (item.Sucursal_info_opciones!.Sucursal_traslado == null && Sucursal_traslado_Mostrarprecioreal != null)
            {
                item.Sucursal_info_opciones!.Sucursal_traslado = CreateSubEntity<Sucursal_traslado>();
                item.Sucursal_info_opciones!.Sucursal_traslado!.Mostrarprecioreal = Sucursal_traslado_Mostrarprecioreal ?? BoolCN.N;
            }

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null)
                item.Sucursal_info_opciones!.Sucursal_traslado!.Preciorecepciontraslado = Sucursal_traslado_Preciorecepciontraslado;
            else if (item.Sucursal_info_opciones!.Sucursal_traslado == null && Sucursal_traslado_Preciorecepciontraslado != null)
            {
                item.Sucursal_info_opciones!.Sucursal_traslado = CreateSubEntity<Sucursal_traslado>();
                item.Sucursal_info_opciones!.Sucursal_traslado!.Preciorecepciontraslado = Sucursal_traslado_Preciorecepciontraslado;
            }

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null)
                item.Sucursal_info_opciones!.Sucursal_traslado!.Precioenviotraslado = Sucursal_traslado_Precioenviotraslado;
            else if (item.Sucursal_info_opciones!.Sucursal_traslado == null && Sucursal_traslado_Precioenviotraslado != null)
            {
                item.Sucursal_info_opciones!.Sucursal_traslado = CreateSubEntity<Sucursal_traslado>();
                item.Sucursal_info_opciones!.Sucursal_traslado!.Precioenviotraslado = Sucursal_traslado_Precioenviotraslado;
            }

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null)
                item.Sucursal_info_opciones!.Sucursal_traslado!.Lista_precio_traspaso = Sucursal_traslado_Lista_precio_traspaso;
            else if (item.Sucursal_info_opciones!.Sucursal_traslado == null && Sucursal_traslado_Lista_precio_traspaso != null)
            {
                item.Sucursal_info_opciones!.Sucursal_traslado = CreateSubEntity<Sucursal_traslado>();
                item.Sucursal_info_opciones!.Sucursal_traslado!.Lista_precio_traspaso = Sucursal_traslado_Lista_precio_traspaso;
            }


        }

        public void FillFromEntity(Sucursal_info item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Esmatriz = item.Esmatriz;

            Esfranquicia = item.Esfranquicia;

            Cuentareferencia = item.Cuentareferencia;

            Cuentapoliza = item.Cuentapoliza;

            Clave = item.Clave;

            Nombre = item.Nombre;

            Descripcion = item.Descripcion;

            Memo = item.Memo;

            Maxdoctospendientes = item.Maxdoctospendientes;

            if (item.Sucursal_info_opciones != null && item.Sucursal_info_opciones?.Gruposucursalid != null)
                Sucursal_info_opciones_Gruposucursalid = item.Sucursal_info_opciones!.Gruposucursalid;

            if (item.Sucursal_info_opciones != null && item.Sucursal_info_opciones?.Clienteid != null)
                Sucursal_info_opciones_Clienteid = item.Sucursal_info_opciones!.Clienteid;

            if (item.Sucursal_info_opciones != null && item.Sucursal_info_opciones?.Proveedorid != null)
                Sucursal_info_opciones_Proveedorid = item.Sucursal_info_opciones!.Proveedorid;

            if (item.Sucursal_info_opciones != null && item.Sucursal_info_opciones?.Bancoid != null)
                Sucursal_info_opciones_Bancoid = item.Sucursal_info_opciones!.Bancoid;

            if (item.Sucursal_info_opciones != null && item.Sucursal_info_opciones?.Empprovid != null)
                Sucursal_info_opciones_Empprovid = item.Sucursal_info_opciones!.Empprovid;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Por_fact_elect != null)
                Sucursal_fact_elect_Por_fact_elect = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Por_fact_elect;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entregacalle != null)
                Sucursal_fact_elect_Entregacalle = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacalle;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entreganumeroexterior != null)
                Sucursal_fact_elect_Entreganumeroexterior = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entreganumeroexterior;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entreganumerointerior != null)
                Sucursal_fact_elect_Entreganumerointerior = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entreganumerointerior;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entregacolonia != null)
                Sucursal_fact_elect_Entregacolonia = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacolonia;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entregamunicipio != null)
                Sucursal_fact_elect_Entregamunicipio = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregamunicipio;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entregacodigopostal != null)
                Sucursal_fact_elect_Entregacodigopostal = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregacodigopostal;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entregaestadoid != null)
                Sucursal_fact_elect_Entregaestadoid = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregaestadoid;


            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entrega_Sat_Coloniaid != null)
                Sucursal_fact_elect_Entrega_Sat_Coloniaid = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Coloniaid;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entrega_Sat_Localidadid != null)
                Sucursal_fact_elect_Entrega_Sat_Localidadid = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Localidadid;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entrega_Sat_Municipioid != null)
                Sucursal_fact_elect_Entrega_Sat_Municipioid = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Sat_Municipioid;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entrega_Distancia != null)
                Sucursal_fact_elect_Entrega_Distancia = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entrega_Distancia;

            if (item.Sucursal_info_opciones!.Sucursal_fact_elect != null && item.Sucursal_info_opciones!.Sucursal_fact_elect?.Entregareferenciadom != null)
                Sucursal_fact_elect_Entregareferenciadom = item.Sucursal_info_opciones!.Sucursal_fact_elect!.Entregareferenciadom;

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null && item.Sucursal_info_opciones!.Sucursal_importacion?.Manejaprecioxdescuento != null)
                Sucursal_importacion_Manejaprecioxdescuento = item.Sucursal_info_opciones!.Sucursal_importacion!.Manejaprecioxdescuento;

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null && item.Sucursal_info_opciones!.Sucursal_importacion?.Prefijoprecioxdescuento != null)
                Sucursal_importacion_Prefijoprecioxdescuento = item.Sucursal_info_opciones!.Sucursal_importacion!.Prefijoprecioxdescuento;

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null && item.Sucursal_info_opciones!.Sucursal_importacion?.Porc_aumento_precio != null)
                Sucursal_importacion_Porc_aumento_precio = item.Sucursal_info_opciones!.Sucursal_importacion!.Porc_aumento_precio;

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null && item.Sucursal_info_opciones!.Sucursal_importacion?.Listaprecioid != null)
                Sucursal_importacion_Listaprecioid = item.Sucursal_info_opciones!.Sucursal_importacion!.Listaprecioid;

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null && item.Sucursal_info_opciones!.Sucursal_importacion?.Surtidorid != null)
                Sucursal_importacion_Surtidorid = item.Sucursal_info_opciones!.Sucursal_importacion!.Surtidorid;

            if (item.Sucursal_info_opciones!.Sucursal_importacion != null && item.Sucursal_info_opciones!.Sucursal_importacion?.Imnuprod != null)
                Sucursal_importacion_Imnuprod = item.Sucursal_info_opciones!.Sucursal_importacion!.Imnuprod;

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null && item.Sucursal_info_opciones!.Sucursal_respaldo?.Rutarespaldoorigen != null)
                Sucursal_respaldo_Rutarespaldoorigen = item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldoorigen;

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null && item.Sucursal_info_opciones!.Sucursal_respaldo?.Rutarespaldodestino != null)
                Sucursal_respaldo_Rutarespaldodestino = item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldodestino;

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null && item.Sucursal_info_opciones!.Sucursal_respaldo?.Rutarespaldored != null)
                Sucursal_respaldo_Rutarespaldored = item.Sucursal_info_opciones!.Sucursal_respaldo!.Rutarespaldored;

            if (item.Sucursal_info_opciones!.Sucursal_respaldo != null && item.Sucursal_info_opciones!.Sucursal_respaldo?.Nombrerespaldobd != null)
                Sucursal_respaldo_Nombrerespaldobd = item.Sucursal_info_opciones!.Sucursal_respaldo!.Nombrerespaldobd;

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null && item.Sucursal_info_opciones!.Sucursal_traslado?.Mostrarprecioreal != null)
                Sucursal_traslado_Mostrarprecioreal = item.Sucursal_info_opciones!.Sucursal_traslado!.Mostrarprecioreal;

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null && item.Sucursal_info_opciones!.Sucursal_traslado?.Preciorecepciontraslado != null)
                Sucursal_traslado_Preciorecepciontraslado = item.Sucursal_info_opciones!.Sucursal_traslado!.Preciorecepciontraslado;

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null && item.Sucursal_info_opciones!.Sucursal_traslado?.Precioenviotraslado != null)
                Sucursal_traslado_Precioenviotraslado = item.Sucursal_info_opciones!.Sucursal_traslado!.Precioenviotraslado;

            if (item.Sucursal_info_opciones!.Sucursal_traslado != null && item.Sucursal_info_opciones!.Sucursal_traslado?.Lista_precio_traspaso != null)
                Sucursal_traslado_Lista_precio_traspaso = item.Sucursal_info_opciones!.Sucursal_traslado!.Lista_precio_traspaso;


            FillCatalogRelatedFields(item);


        }
        #endif



    }
}

