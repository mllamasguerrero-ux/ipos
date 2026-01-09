
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
    
    public class UsuarioBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public UsuarioBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public UsuarioBindingModelGenerated(Usuario item)
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
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private string? _UsuarioNombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? UsuarioNombre { get => _UsuarioNombre?? ""; set { if (RaiseAcceptPendingChange(value, _UsuarioNombre)) { _UsuarioNombre = value?? ""; OnPropertyChanged(); } } }

        private string? _Contrasena;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Contrasena { get => _Contrasena?? ""; set { if (RaiseAcceptPendingChange(value, _Contrasena)) { _Contrasena = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private string? _Apellidos;
        [XmlAttribute]
        public string? Apellidos { get => _Apellidos; set { if (RaiseAcceptPendingChange(value, _Apellidos)) { _Apellidos = value; OnPropertyChanged(); } } }

        private string? _Razonsocial;
        [XmlAttribute]
        public string? Razonsocial { get => _Razonsocial; set { if (RaiseAcceptPendingChange(value, _Razonsocial)) { _Razonsocial = value; OnPropertyChanged(); } } }

        private string? _Rfc;
        [XmlAttribute]
        public string? Rfc { get => _Rfc; set { if (RaiseAcceptPendingChange(value, _Rfc)) { _Rfc = value; OnPropertyChanged(); } } }

        private long? _Domicilioid;
        [XmlAttribute]
        public long? Domicilioid { get => _Domicilioid; set { if (RaiseAcceptPendingChange(value, _Domicilioid)) { _Domicilioid = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Calle;
        [XmlAttribute]
        public string? Domicilio_Calle { get => _Domicilio_Calle; set { if (RaiseAcceptPendingChange(value, _Domicilio_Calle)) { _Domicilio_Calle = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Numeroexterior;
        [XmlAttribute]
        public string? Domicilio_Numeroexterior { get => _Domicilio_Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Domicilio_Numeroexterior)) { _Domicilio_Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Numerointerior;
        [XmlAttribute]
        public string? Domicilio_Numerointerior { get => _Domicilio_Numerointerior; set { if (RaiseAcceptPendingChange(value, _Domicilio_Numerointerior)) { _Domicilio_Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Colonia;
        [XmlAttribute]
        public string? Domicilio_Colonia { get => _Domicilio_Colonia; set { if (RaiseAcceptPendingChange(value, _Domicilio_Colonia)) { _Domicilio_Colonia = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Ciudad;
        [XmlAttribute]
        public string? Domicilio_Ciudad { get => _Domicilio_Ciudad; set { if (RaiseAcceptPendingChange(value, _Domicilio_Ciudad)) { _Domicilio_Ciudad = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Municipio;
        [XmlAttribute]
        public string? Domicilio_Municipio { get => _Domicilio_Municipio; set { if (RaiseAcceptPendingChange(value, _Domicilio_Municipio)) { _Domicilio_Municipio = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Estado;
        [XmlAttribute]
        public string? Domicilio_Estado { get => _Domicilio_Estado; set { if (RaiseAcceptPendingChange(value, _Domicilio_Estado)) { _Domicilio_Estado = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Pais;
        [XmlAttribute]
        public string? Domicilio_Pais { get => _Domicilio_Pais; set { if (RaiseAcceptPendingChange(value, _Domicilio_Pais)) { _Domicilio_Pais = value; OnPropertyChanged(); } } }

        private string? _Domicilio_Codigopostal;
        [XmlAttribute]
        public string? Domicilio_Codigopostal { get => _Domicilio_Codigopostal; set { if (RaiseAcceptPendingChange(value, _Domicilio_Codigopostal)) { _Domicilio_Codigopostal = value; OnPropertyChanged(); } } }

        private long? _Contacto1id;
        [XmlAttribute]
        public long? Contacto1id { get => _Contacto1id; set { if (RaiseAcceptPendingChange(value, _Contacto1id)) { _Contacto1id = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Nombre;
        [XmlAttribute]
        public string? Contacto1_Nombre { get => _Contacto1_Nombre; set { if (RaiseAcceptPendingChange(value, _Contacto1_Nombre)) { _Contacto1_Nombre = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Email;
        [XmlAttribute]
        public string? Contacto1_Email { get => _Contacto1_Email; set { if (RaiseAcceptPendingChange(value, _Contacto1_Email)) { _Contacto1_Email = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Telefono1;
        [XmlAttribute]
        public string? Contacto1_Telefono1 { get => _Contacto1_Telefono1; set { if (RaiseAcceptPendingChange(value, _Contacto1_Telefono1)) { _Contacto1_Telefono1 = value; OnPropertyChanged(); } } }

        private long? _Contacto1_Domicilioid;
        [XmlAttribute]
        public long? Contacto1_Domicilioid { get => _Contacto1_Domicilioid; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilioid)) { _Contacto1_Domicilioid = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Calle;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Calle { get => _Contacto1_Domicilio_Calle; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Calle)) { _Contacto1_Domicilio_Calle = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Numeroexterior;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Numeroexterior { get => _Contacto1_Domicilio_Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Numeroexterior)) { _Contacto1_Domicilio_Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Numerointerior;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Numerointerior { get => _Contacto1_Domicilio_Numerointerior; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Numerointerior)) { _Contacto1_Domicilio_Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Colonia;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Colonia { get => _Contacto1_Domicilio_Colonia; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Colonia)) { _Contacto1_Domicilio_Colonia = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Ciudad;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Ciudad { get => _Contacto1_Domicilio_Ciudad; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Ciudad)) { _Contacto1_Domicilio_Ciudad = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Municipio;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Municipio { get => _Contacto1_Domicilio_Municipio; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Municipio)) { _Contacto1_Domicilio_Municipio = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Estado;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Estado { get => _Contacto1_Domicilio_Estado; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Estado)) { _Contacto1_Domicilio_Estado = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Pais;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Pais { get => _Contacto1_Domicilio_Pais; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Pais)) { _Contacto1_Domicilio_Pais = value; OnPropertyChanged(); } } }

        private string? _Contacto1_Domicilio_Codigopostal;
        [XmlAttribute]
        public string? Contacto1_Domicilio_Codigopostal { get => _Contacto1_Domicilio_Codigopostal; set { if (RaiseAcceptPendingChange(value, _Contacto1_Domicilio_Codigopostal)) { _Contacto1_Domicilio_Codigopostal = value; OnPropertyChanged(); } } }

        private long? _Contacto2id;
        [XmlAttribute]
        public long? Contacto2id { get => _Contacto2id; set { if (RaiseAcceptPendingChange(value, _Contacto2id)) { _Contacto2id = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Nombre;
        [XmlAttribute]
        public string? Contacto2_Nombre { get => _Contacto2_Nombre; set { if (RaiseAcceptPendingChange(value, _Contacto2_Nombre)) { _Contacto2_Nombre = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Email;
        [XmlAttribute]
        public string? Contacto2_Email { get => _Contacto2_Email; set { if (RaiseAcceptPendingChange(value, _Contacto2_Email)) { _Contacto2_Email = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Telefono1;
        [XmlAttribute]
        public string? Contacto2_Telefono1 { get => _Contacto2_Telefono1; set { if (RaiseAcceptPendingChange(value, _Contacto2_Telefono1)) { _Contacto2_Telefono1 = value; OnPropertyChanged(); } } }

        private long? _Contacto2_Domicilioid;
        [XmlAttribute]
        public long? Contacto2_Domicilioid { get => _Contacto2_Domicilioid; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilioid)) { _Contacto2_Domicilioid = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Calle;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Calle { get => _Contacto2_Domicilio_Calle; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Calle)) { _Contacto2_Domicilio_Calle = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Numeroexterior;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Numeroexterior { get => _Contacto2_Domicilio_Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Numeroexterior)) { _Contacto2_Domicilio_Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Numerointerior;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Numerointerior { get => _Contacto2_Domicilio_Numerointerior; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Numerointerior)) { _Contacto2_Domicilio_Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Colonia;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Colonia { get => _Contacto2_Domicilio_Colonia; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Colonia)) { _Contacto2_Domicilio_Colonia = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Ciudad;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Ciudad { get => _Contacto2_Domicilio_Ciudad; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Ciudad)) { _Contacto2_Domicilio_Ciudad = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Municipio;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Municipio { get => _Contacto2_Domicilio_Municipio; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Municipio)) { _Contacto2_Domicilio_Municipio = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Estado;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Estado { get => _Contacto2_Domicilio_Estado; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Estado)) { _Contacto2_Domicilio_Estado = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Pais;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Pais { get => _Contacto2_Domicilio_Pais; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Pais)) { _Contacto2_Domicilio_Pais = value; OnPropertyChanged(); } } }

        private string? _Contacto2_Domicilio_Codigopostal;
        [XmlAttribute]
        public string? Contacto2_Domicilio_Codigopostal { get => _Contacto2_Domicilio_Codigopostal; set { if (RaiseAcceptPendingChange(value, _Contacto2_Domicilio_Codigopostal)) { _Contacto2_Domicilio_Codigopostal = value; OnPropertyChanged(); } } }

        private string? _Telefono1;
        [XmlAttribute]
        public string? Telefono1 { get => _Telefono1; set { if (RaiseAcceptPendingChange(value, _Telefono1)) { _Telefono1 = value; OnPropertyChanged(); } } }

        private string? _Telefono2;
        [XmlAttribute]
        public string? Telefono2 { get => _Telefono2; set { if (RaiseAcceptPendingChange(value, _Telefono2)) { _Telefono2 = value; OnPropertyChanged(); } } }

        private string? _Telefono3;
        [XmlAttribute]
        public string? Telefono3 { get => _Telefono3; set { if (RaiseAcceptPendingChange(value, _Telefono3)) { _Telefono3 = value; OnPropertyChanged(); } } }

        private string? _Celular;
        [XmlAttribute]
        public string? Celular { get => _Celular; set { if (RaiseAcceptPendingChange(value, _Celular)) { _Celular = value; OnPropertyChanged(); } } }

        private string? _Nextel;
        [XmlAttribute]
        public string? Nextel { get => _Nextel; set { if (RaiseAcceptPendingChange(value, _Nextel)) { _Nextel = value; OnPropertyChanged(); } } }

        private string? _Email1;
        [XmlAttribute]
        public string? Email1 { get => _Email1; set { if (RaiseAcceptPendingChange(value, _Email1)) { _Email1 = value; OnPropertyChanged(); } } }

        private string? _Email2;
        [XmlAttribute]
        public string? Email2 { get => _Email2; set { if (RaiseAcceptPendingChange(value, _Email2)) { _Email2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Reset_pass;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Reset_pass { get => _Reset_pass?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Reset_pass)) { _Reset_pass = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Gaffete;
        [XmlAttribute]
        public string? Gaffete { get => _Gaffete; set { if (RaiseAcceptPendingChange(value, _Gaffete)) { _Gaffete = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ticketlargo { get => _Ticketlargo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ticketlargo)) { _Ticketlargo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargocotizacion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ticketlargocotizacion { get => _Ticketlargocotizacion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ticketlargocotizacion)) { _Ticketlargocotizacion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargocredito;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ticketlargocredito { get => _Ticketlargocredito?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ticketlargocredito)) { _Ticketlargocredito = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarticketlargo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preguntarticketlargo { get => _Preguntarticketlargo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preguntarticketlargo)) { _Preguntarticketlargo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Codigoautorizacion;
        [XmlAttribute]
        public string? Codigoautorizacion { get => _Codigoautorizacion; set { if (RaiseAcceptPendingChange(value, _Codigoautorizacion)) { _Codigoautorizacion = value; OnPropertyChanged(); } } }

        private BoolCS? _Cajasbotellas;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Cajasbotellas { get => _Cajasbotellas?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Cajasbotellas)) { _Cajasbotellas = value?? BoolCS.S; OnPropertyChanged(); } } }

        private string? _Clieformaspagodef;
        [XmlAttribute]
        public string? Clieformaspagodef { get => _Clieformaspagodef; set { if (RaiseAcceptPendingChange(value, _Clieformaspagodef)) { _Clieformaspagodef = value; OnPropertyChanged(); } } }

        private BoolCN? _Esvendedor;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esvendedor { get => _Esvendedor?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esvendedor)) { _Esvendedor = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vigencia;
        [XmlAttribute]
        public DateTimeOffset? Vigencia { get => _Vigencia; set { if (RaiseAcceptPendingChange(value, _Vigencia)) { _Vigencia = value; OnPropertyChanged(); } } }

        private BoolCN? _Esencargadocorte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esencargadocorte { get => _Esencargadocorte?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esencargadocorte)) { _Esencargadocorte = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Esencargadoguia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esencargadoguia { get => _Esencargadoguia?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esencargadoguia)) { _Esencargadoguia = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _PendMaxDias;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? PendMaxDias { get => _PendMaxDias?? 0; set { if (RaiseAcceptPendingChange(value, _PendMaxDias)) { _PendMaxDias = value?? 0; OnPropertyChanged(); } } }

        private long? _Saludoid;
        [XmlAttribute]
        public long? Saludoid { get => _Saludoid; set { if (RaiseAcceptPendingChange(value, _Saludoid)) { _Saludoid = value; OnPropertyChanged(); } } }

        private string? _SaludoClave;
        [XmlAttribute]
        public string? SaludoClave { get => _SaludoClave; set { if (RaiseAcceptPendingChange(value, _SaludoClave)) { _SaludoClave = value; OnPropertyChanged(); } } }

        private string? _SaludoNombre;
        [XmlAttribute]
        public string? SaludoNombre { get => _SaludoNombre; set { if (RaiseAcceptPendingChange(value, _SaludoNombre)) { _SaludoNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_Preferencias_Grupousuarioid;
        [XmlAttribute]
        public long? Usuario_Preferencias_Grupousuarioid { get => _Usuario_Preferencias_Grupousuarioid; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_Grupousuarioid)) { _Usuario_Preferencias_Grupousuarioid = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_GrupousuarioClave;
        [XmlAttribute]
        public string? Usuario_Preferencias_GrupousuarioClave { get => _Usuario_Preferencias_GrupousuarioClave; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_GrupousuarioClave)) { _Usuario_Preferencias_GrupousuarioClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_GrupousuarioNombre;
        [XmlAttribute]
        public string? Usuario_Preferencias_GrupousuarioNombre { get => _Usuario_Preferencias_GrupousuarioNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_GrupousuarioNombre)) { _Usuario_Preferencias_GrupousuarioNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_Preferencias_Almacenid;
        [XmlAttribute]
        public long? Usuario_Preferencias_Almacenid { get => _Usuario_Preferencias_Almacenid; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_Almacenid)) { _Usuario_Preferencias_Almacenid = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_AlmacenClave;
        [XmlAttribute]
        public string? Usuario_Preferencias_AlmacenClave { get => _Usuario_Preferencias_AlmacenClave; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_AlmacenClave)) { _Usuario_Preferencias_AlmacenClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_AlmacenNombre;
        [XmlAttribute]
        public string? Usuario_Preferencias_AlmacenNombre { get => _Usuario_Preferencias_AlmacenNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_AlmacenNombre)) { _Usuario_Preferencias_AlmacenNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_Preferencias_Listaprecioid;
        [XmlAttribute]
        public long? Usuario_Preferencias_Listaprecioid { get => _Usuario_Preferencias_Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_Listaprecioid)) { _Usuario_Preferencias_Listaprecioid = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_ListaprecioClave;
        [XmlAttribute]
        public string? Usuario_Preferencias_ListaprecioClave { get => _Usuario_Preferencias_ListaprecioClave; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_ListaprecioClave)) { _Usuario_Preferencias_ListaprecioClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_ListaprecioNombre;
        [XmlAttribute]
        public string? Usuario_Preferencias_ListaprecioNombre { get => _Usuario_Preferencias_ListaprecioNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_ListaprecioNombre)) { _Usuario_Preferencias_ListaprecioNombre = value; OnPropertyChanged(); } } }

        private string? _Usuario_Preferencias_Nombreimpresora;
        [XmlAttribute]
        public string? Usuario_Preferencias_Nombreimpresora { get => _Usuario_Preferencias_Nombreimpresora; set { if (RaiseAcceptPendingChange(value, _Usuario_Preferencias_Nombreimpresora)) { _Usuario_Preferencias_Nombreimpresora = value; OnPropertyChanged(); } } }

        private long? _Usuario_Personafigura_Personaid;
        [XmlAttribute]
        public long? Usuario_Personafigura_Personaid { get => _Usuario_Personafigura_Personaid; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Personaid)) { _Usuario_Personafigura_Personaid = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_PersonaClave;
        [XmlAttribute]
        public string? Usuario_Personafigura_PersonaClave { get => _Usuario_Personafigura_PersonaClave; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_PersonaClave)) { _Usuario_Personafigura_PersonaClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_PersonaNombre;
        [XmlAttribute]
        public string? Usuario_Personafigura_PersonaNombre { get => _Usuario_Personafigura_PersonaNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_PersonaNombre)) { _Usuario_Personafigura_PersonaNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_Personafigura_Sat_Figuratransporteid;
        [XmlAttribute]
        public long? Usuario_Personafigura_Sat_Figuratransporteid { get => _Usuario_Personafigura_Sat_Figuratransporteid; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Sat_Figuratransporteid)) { _Usuario_Personafigura_Sat_Figuratransporteid = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Sat_FiguratransporteClave;
        [XmlAttribute]
        public string? Usuario_Personafigura_Sat_FiguratransporteClave { get => _Usuario_Personafigura_Sat_FiguratransporteClave; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Sat_FiguratransporteClave)) { _Usuario_Personafigura_Sat_FiguratransporteClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Sat_FiguratransporteNombre;
        [XmlAttribute]
        public string? Usuario_Personafigura_Sat_FiguratransporteNombre { get => _Usuario_Personafigura_Sat_FiguratransporteNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Sat_FiguratransporteNombre)) { _Usuario_Personafigura_Sat_FiguratransporteNombre = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Numlicencia;
        [XmlAttribute]
        public string? Usuario_Personafigura_Numlicencia { get => _Usuario_Personafigura_Numlicencia; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Numlicencia)) { _Usuario_Personafigura_Numlicencia = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Numregidtrib;
        [XmlAttribute]
        public string? Usuario_Personafigura_Numregidtrib { get => _Usuario_Personafigura_Numregidtrib; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Numregidtrib)) { _Usuario_Personafigura_Numregidtrib = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Residenciafiscal;
        [XmlAttribute]
        public string? Usuario_Personafigura_Residenciafiscal { get => _Usuario_Personafigura_Residenciafiscal; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Residenciafiscal)) { _Usuario_Personafigura_Residenciafiscal = value; OnPropertyChanged(); } } }

        private long? _Usuario_Personafigura_Sat_Partetransporteid;
        [XmlAttribute]
        public long? Usuario_Personafigura_Sat_Partetransporteid { get => _Usuario_Personafigura_Sat_Partetransporteid; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Sat_Partetransporteid)) { _Usuario_Personafigura_Sat_Partetransporteid = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Sat_PartetransporteClave;
        [XmlAttribute]
        public string? Usuario_Personafigura_Sat_PartetransporteClave { get => _Usuario_Personafigura_Sat_PartetransporteClave; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Sat_PartetransporteClave)) { _Usuario_Personafigura_Sat_PartetransporteClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_Personafigura_Sat_PartetransporteNombre;
        [XmlAttribute]
        public string? Usuario_Personafigura_Sat_PartetransporteNombre { get => _Usuario_Personafigura_Sat_PartetransporteNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_Personafigura_Sat_PartetransporteNombre)) { _Usuario_Personafigura_Sat_PartetransporteNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_fact_elect_Sat_id_pais;
        [XmlAttribute]
        public long? Usuario_fact_elect_Sat_id_pais { get => _Usuario_fact_elect_Sat_id_pais; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_id_pais)) { _Usuario_fact_elect_Sat_id_pais = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_paisClave;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_paisClave { get => _Usuario_fact_elect_Sat_paisClave; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_paisClave)) { _Usuario_fact_elect_Sat_paisClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_paisNombre;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_paisNombre { get => _Usuario_fact_elect_Sat_paisNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_paisNombre)) { _Usuario_fact_elect_Sat_paisNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_fact_elect_Sat_Coloniaid;
        [XmlAttribute]
        public long? Usuario_fact_elect_Sat_Coloniaid { get => _Usuario_fact_elect_Sat_Coloniaid; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_Coloniaid)) { _Usuario_fact_elect_Sat_Coloniaid = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_ColoniaClave;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_ColoniaClave { get => _Usuario_fact_elect_Sat_ColoniaClave; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_ColoniaClave)) { _Usuario_fact_elect_Sat_ColoniaClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_ColoniaNombre;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_ColoniaNombre { get => _Usuario_fact_elect_Sat_ColoniaNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_ColoniaNombre)) { _Usuario_fact_elect_Sat_ColoniaNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_fact_elect_Sat_Localidadid;
        [XmlAttribute]
        public long? Usuario_fact_elect_Sat_Localidadid { get => _Usuario_fact_elect_Sat_Localidadid; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_Localidadid)) { _Usuario_fact_elect_Sat_Localidadid = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_LocalidadClave;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_LocalidadClave { get => _Usuario_fact_elect_Sat_LocalidadClave; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_LocalidadClave)) { _Usuario_fact_elect_Sat_LocalidadClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_LocalidadNombre;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_LocalidadNombre { get => _Usuario_fact_elect_Sat_LocalidadNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_LocalidadNombre)) { _Usuario_fact_elect_Sat_LocalidadNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_fact_elect_Sat_Municipioid;
        [XmlAttribute]
        public long? Usuario_fact_elect_Sat_Municipioid { get => _Usuario_fact_elect_Sat_Municipioid; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_Municipioid)) { _Usuario_fact_elect_Sat_Municipioid = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_MunicipioClave;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_MunicipioClave { get => _Usuario_fact_elect_Sat_MunicipioClave; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_MunicipioClave)) { _Usuario_fact_elect_Sat_MunicipioClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Sat_MunicipioNombre;
        [XmlAttribute]
        public string? Usuario_fact_elect_Sat_MunicipioNombre { get => _Usuario_fact_elect_Sat_MunicipioNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Sat_MunicipioNombre)) { _Usuario_fact_elect_Sat_MunicipioNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_fact_elect_Estadoid;
        [XmlAttribute]
        public long? Usuario_fact_elect_Estadoid { get => _Usuario_fact_elect_Estadoid; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Estadoid)) { _Usuario_fact_elect_Estadoid = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_EstadoClave;
        [XmlAttribute]
        public string? Usuario_fact_elect_EstadoClave { get => _Usuario_fact_elect_EstadoClave; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_EstadoClave)) { _Usuario_fact_elect_EstadoClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_EstadoNombre;
        [XmlAttribute]
        public string? Usuario_fact_elect_EstadoNombre { get => _Usuario_fact_elect_EstadoNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_EstadoNombre)) { _Usuario_fact_elect_EstadoNombre = value; OnPropertyChanged(); } } }

        private string? _Usuario_fact_elect_Referenciadom;
        [XmlAttribute]
        public string? Usuario_fact_elect_Referenciadom { get => _Usuario_fact_elect_Referenciadom; set { if (RaiseAcceptPendingChange(value, _Usuario_fact_elect_Referenciadom)) { _Usuario_fact_elect_Referenciadom = value; OnPropertyChanged(); } } }


        private long? _Usuario_emida_Clerkpagoserviciosid;
        [XmlAttribute]
        public long? Usuario_emida_Clerkpagoserviciosid { get => _Usuario_emida_Clerkpagoserviciosid; set { if (RaiseAcceptPendingChange(value, _Usuario_emida_Clerkpagoserviciosid)) { _Usuario_emida_Clerkpagoserviciosid = value; OnPropertyChanged(); } } }

        private string? _Usuario_emida_ClerkpagoserviciosClave;
        [XmlAttribute]
        public string? Usuario_emida_ClerkpagoserviciosClave { get => _Usuario_emida_ClerkpagoserviciosClave; set { if (RaiseAcceptPendingChange(value, _Usuario_emida_ClerkpagoserviciosClave)) { _Usuario_emida_ClerkpagoserviciosClave = value; OnPropertyChanged(); } } }

        private string? _Usuario_emida_ClerkpagoserviciosNombre;
        [XmlAttribute]
        public string? Usuario_emida_ClerkpagoserviciosNombre { get => _Usuario_emida_ClerkpagoserviciosNombre; set { if (RaiseAcceptPendingChange(value, _Usuario_emida_ClerkpagoserviciosNombre)) { _Usuario_emida_ClerkpagoserviciosNombre = value; OnPropertyChanged(); } } }

        private long? _Usuario_emida_Clerkservicios;
        [XmlAttribute]
        public long? Usuario_emida_Clerkservicios { get => _Usuario_emida_Clerkservicios; set { if (RaiseAcceptPendingChange(value, _Usuario_emida_Clerkservicios)) { _Usuario_emida_Clerkservicios = value; OnPropertyChanged(); } } }

        private string? _Usuario_emida_Clerkservicios_Clave;
        [XmlAttribute]
        public string? Usuario_emida_Clerkservicios_Clave { get => _Usuario_emida_Clerkservicios_Clave; set { if (RaiseAcceptPendingChange(value, _Usuario_emida_Clerkservicios_Clave)) { _Usuario_emida_Clerkservicios_Clave = value; OnPropertyChanged(); } } }

        private string? _Usuario_emida_Clerkservicios_Nombre;
        [XmlAttribute]
        public string? Usuario_emida_Clerkservicios_Nombre { get => _Usuario_emida_Clerkservicios_Nombre; set { if (RaiseAcceptPendingChange(value, _Usuario_emida_Clerkservicios_Nombre)) { _Usuario_emida_Clerkservicios_Nombre = value; OnPropertyChanged(); } } }


        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Usuario"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Nombre|UsuarioNombre|Contrasena|Nombres|Apellidos|Razonsocial|Rfc|Domicilio.Calle|Domicilio.Numeroexterior|Domicilio.Numerointerior|Domicilio.Colonia|Domicilio.Ciudad|Domicilio.Municipio|Domicilio.Estado|Domicilio.Pais|Domicilio.Codigopostal|Contacto1.Nombre|Contacto1.Email|Contacto1.Telefono1|Contacto1.Domicilio.Calle|Contacto1.Domicilio.Numeroexterior|Contacto1.Domicilio.Numerointerior|Contacto1.Domicilio.Colonia|Contacto1.Domicilio.Ciudad|Contacto1.Domicilio.Municipio|Contacto1.Domicilio.Estado|Contacto1.Domicilio.Pais|Contacto1.Domicilio.Codigopostal|Contacto2.Nombre|Contacto2.Email|Contacto2.Telefono1|Contacto2.Domicilio.Calle|Contacto2.Domicilio.Numeroexterior|Contacto2.Domicilio.Numerointerior|Contacto2.Domicilio.Colonia|Contacto2.Domicilio.Ciudad|Contacto2.Domicilio.Municipio|Contacto2.Domicilio.Estado|Contacto2.Domicilio.Pais|Contacto2.Domicilio.Codigopostal|Telefono1|Telefono2|Telefono3|Celular|Nextel|Email1|Email2|Gaffete|Codigoautorizacion|Clieformaspagodef|Saludo.Clave|Saludo.Nombre|Usuario_Preferencias.Grupousuario.Clave|Usuario_Preferencias.Grupousuario.Nombre|Usuario_Preferencias.Almacen.Clave|Usuario_Preferencias.Almacen.Nombre|Usuario_Preferencias.Listaprecio.Clave|Usuario_Preferencias.Listaprecio.Nombre|Usuario_Preferencias.Nombreimpresora|Usuario_Personafigura.Persona.Clave|Usuario_Personafigura.Persona.Nombre|Usuario_Personafigura.Sat_Figuratransporte.Clave|Usuario_Personafigura.Sat_Figuratransporte.Nombre|Usuario_Personafigura.Numlicencia|Usuario_Personafigura.Numregidtrib|Usuario_Personafigura.Residenciafiscal|Usuario_Personafigura.Sat_Partetransporte.Clave|Usuario_Personafigura.Sat_Partetransporte.Nombre|Usuario_fact_elect.Sat_pais.Clave|Usuario_fact_elect.Sat_pais.Nombre|Usuario_fact_elect.Sat_Colonia.Clave|Usuario_fact_elect.Sat_Colonia.Nombre|Usuario_fact_elect.Sat_Localidad.Clave|Usuario_fact_elect.Sat_Localidad.Nombre|Usuario_fact_elect.Sat_Municipio.Clave|Usuario_fact_elect.Sat_Municipio.Nombre|Usuario_fact_elect.Estado.Clave|Usuario_fact_elect.Estado.Nombre|Usuario_fact_elect.Referenciadom|Clave";
        }

        #if PROYECTO_WEB

        public void FillCatalogRelatedFields(Usuario item)
        {

             this._SaludoClave = item.Saludo?.Clave;

             this._SaludoNombre = item.Saludo?.Nombre;

             this._Usuario_Preferencias_GrupousuarioClave = item.Usuario_Preferencias?.Grupousuario?.Clave;

             this._Usuario_Preferencias_GrupousuarioNombre = item.Usuario_Preferencias?.Grupousuario?.Nombre;

             this._Usuario_Preferencias_AlmacenClave = item.Usuario_Preferencias?.Almacen?.Clave;

             this._Usuario_Preferencias_AlmacenNombre = item.Usuario_Preferencias?.Almacen?.Nombre;

             this._Usuario_Preferencias_ListaprecioClave = item.Usuario_Preferencias?.Listaprecio?.Clave;

             this._Usuario_Preferencias_ListaprecioNombre = item.Usuario_Preferencias?.Listaprecio?.Nombre;

             this._Usuario_Personafigura_PersonaClave = item.Usuario_Personafigura?.Persona?.Clave;

             this._Usuario_Personafigura_PersonaNombre = item.Usuario_Personafigura?.Persona?.Nombre;

             this._Usuario_Personafigura_Sat_FiguratransporteClave = item.Usuario_Personafigura?.Sat_Figuratransporte?.Clave;

             this._Usuario_Personafigura_Sat_FiguratransporteNombre = item.Usuario_Personafigura?.Sat_Figuratransporte?.Nombre;

             this._Usuario_Personafigura_Sat_PartetransporteClave = item.Usuario_Personafigura?.Sat_Partetransporte?.Clave;

             this._Usuario_Personafigura_Sat_PartetransporteNombre = item.Usuario_Personafigura?.Sat_Partetransporte?.Nombre;

             this._Usuario_fact_elect_Sat_paisClave = item.Usuario_fact_elect?.Sat_pais?.Clave;

             this._Usuario_fact_elect_Sat_paisNombre = item.Usuario_fact_elect?.Sat_pais?.Nombre;

             this._Usuario_fact_elect_Sat_ColoniaClave = item.Usuario_fact_elect?.Sat_Colonia?.Clave;

             this._Usuario_fact_elect_Sat_ColoniaNombre = item.Usuario_fact_elect?.Sat_Colonia?.Nombre;

             this._Usuario_fact_elect_Sat_LocalidadClave = item.Usuario_fact_elect?.Sat_Localidad?.Clave;

             this._Usuario_fact_elect_Sat_LocalidadNombre = item.Usuario_fact_elect?.Sat_Localidad?.Nombre;

             this._Usuario_fact_elect_Sat_MunicipioClave = item.Usuario_fact_elect?.Sat_Municipio?.Clave;

             this._Usuario_fact_elect_Sat_MunicipioNombre = item.Usuario_fact_elect?.Sat_Municipio?.Nombre;

             this._Usuario_fact_elect_EstadoClave = item.Usuario_fact_elect?.Estado?.Clave;

             this._Usuario_fact_elect_EstadoNombre = item.Usuario_fact_elect?.Estado?.Nombre;

            this._Usuario_emida_ClerkpagoserviciosClave = item.Usuario_emida?.Clerkpagoservicios?.Clave;

            this._Usuario_emida_ClerkpagoserviciosNombre = item.Usuario_emida?.Clerkpagoservicios?.Nombre;

            this._Usuario_emida_Clerkservicios_Clave = item.Usuario_emida?.Clerkservicios_?.Clave;

            this._Usuario_emida_Clerkservicios_Nombre = item.Usuario_emida?.Clerkservicios_?.Nombre;


        }


        public void FillEntityValues(ref Usuario item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Nombre = Nombre ?? "";


            item.UsuarioNombre = UsuarioNombre ?? "";


            item.Contrasena = Contrasena ?? "";


            item.Nombres = Nombres ;


            item.Apellidos = Apellidos ;


            item.Razonsocial = Razonsocial ;


            item.Rfc = Rfc ;


            item.Domicilioid = Domicilioid ;


            item.Contacto1id = Contacto1id ;


            item.Contacto2id = Contacto2id ;


            item.Telefono1 = Telefono1 ;


            item.Telefono2 = Telefono2 ;


            item.Telefono3 = Telefono3 ;


            item.Celular = Celular ;


            item.Nextel = Nextel ;


            item.Email1 = Email1 ;


            item.Email2 = Email2 ;


            item.Reset_pass = Reset_pass ?? BoolCN.N;


            item.Gaffete = Gaffete ;


            item.Ticketlargo = Ticketlargo ?? BoolCN.N;


            item.Ticketlargocotizacion = Ticketlargocotizacion ?? BoolCN.N;


            item.Ticketlargocredito = Ticketlargocredito ?? BoolCN.N;


            item.Preguntarticketlargo = Preguntarticketlargo ?? BoolCN.N;


            item.Codigoautorizacion = Codigoautorizacion ;


            item.Cajasbotellas = Cajasbotellas ?? BoolCS.S;


            item.Clieformaspagodef = Clieformaspagodef ;


            item.Esvendedor = Esvendedor ?? BoolCN.N;


            item.Vigencia = Vigencia ;


            item.Esencargadocorte = Esencargadocorte ?? BoolCN.N;


            item.Esencargadoguia = Esencargadoguia ?? BoolCN.N;


            item.PendMaxDias = PendMaxDias ?? 0;


            item.Saludoid = Saludoid ;


            item.Clave = Clave ?? "";


            if (item.Domicilio != null)
                item.Domicilio!.Calle = Domicilio_Calle;
            else if (item.Domicilio == null && Domicilio_Calle != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Calle = Domicilio_Calle;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Numeroexterior = Domicilio_Numeroexterior;
            else if (item.Domicilio == null && Domicilio_Numeroexterior != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Numeroexterior = Domicilio_Numeroexterior;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Numerointerior = Domicilio_Numerointerior;
            else if (item.Domicilio == null && Domicilio_Numerointerior != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Numerointerior = Domicilio_Numerointerior;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Colonia = Domicilio_Colonia;
            else if (item.Domicilio == null && Domicilio_Colonia != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Colonia = Domicilio_Colonia;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Ciudad = Domicilio_Ciudad;
            else if (item.Domicilio == null && Domicilio_Ciudad != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Ciudad = Domicilio_Ciudad;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Municipio = Domicilio_Municipio;
            else if (item.Domicilio == null && Domicilio_Municipio != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Municipio = Domicilio_Municipio;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Estado = Domicilio_Estado;
            else if (item.Domicilio == null && Domicilio_Estado != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Estado = Domicilio_Estado;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Pais = Domicilio_Pais;
            else if (item.Domicilio == null && Domicilio_Pais != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Pais = Domicilio_Pais;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Codigopostal = Domicilio_Codigopostal;
            else if (item.Domicilio == null && Domicilio_Codigopostal != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Codigopostal = Domicilio_Codigopostal;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Nombre = Contacto1_Nombre;
            else if (item.Contacto1 == null && Contacto1_Nombre != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                //item.Contacto1.EmpresaId = EmpresaId!.Value;
                //item.Contacto1.SucursalId = SucursalId!.Value;
                item.Contacto1!.Nombre = Contacto1_Nombre;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Email = Contacto1_Email;
            else if (item.Contacto1 == null && Contacto1_Email != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Email = Contacto1_Email;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Telefono1 = Contacto1_Telefono1;
            else if (item.Contacto1 == null && Contacto1_Telefono1 != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Telefono1 = Contacto1_Telefono1;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Domicilioid = Contacto1_Domicilioid;
            else if (item.Contacto1 == null && Contacto1_Domicilioid != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Domicilioid = Contacto1_Domicilioid;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Calle = Contacto1_Domicilio_Calle;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Calle != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Calle = Contacto1_Domicilio_Calle;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Numeroexterior = Contacto1_Domicilio_Numeroexterior;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Numeroexterior != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Numeroexterior = Contacto1_Domicilio_Numeroexterior;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Numerointerior = Contacto1_Domicilio_Numerointerior;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Numerointerior != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Numerointerior = Contacto1_Domicilio_Numerointerior;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Colonia = Contacto1_Domicilio_Colonia;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Colonia != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Colonia = Contacto1_Domicilio_Colonia;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Ciudad = Contacto1_Domicilio_Ciudad;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Ciudad != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Ciudad = Contacto1_Domicilio_Ciudad;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Municipio = Contacto1_Domicilio_Municipio;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Municipio != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Municipio = Contacto1_Domicilio_Municipio;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Estado = Contacto1_Domicilio_Estado;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Estado != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Estado = Contacto1_Domicilio_Estado;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Pais = Contacto1_Domicilio_Pais;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Pais != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Pais = Contacto1_Domicilio_Pais;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Codigopostal = Contacto1_Domicilio_Codigopostal;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Codigopostal != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Codigopostal = Contacto1_Domicilio_Codigopostal;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Nombre = Contacto2_Nombre;
            else if (item.Contacto2 == null && Contacto2_Nombre != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Nombre = Contacto2_Nombre;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Email = Contacto2_Email;
            else if (item.Contacto2 == null && Contacto2_Email != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Email = Contacto2_Email;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Telefono1 = Contacto2_Telefono1;
            else if (item.Contacto2 == null && Contacto2_Telefono1 != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Telefono1 = Contacto2_Telefono1;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Domicilioid = Contacto2_Domicilioid;
            else if (item.Contacto2 == null && Contacto2_Domicilioid != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Domicilioid = Contacto2_Domicilioid;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Calle = Contacto2_Domicilio_Calle;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Calle != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Calle = Contacto2_Domicilio_Calle;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Numeroexterior = Contacto2_Domicilio_Numeroexterior;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Numeroexterior != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Numeroexterior = Contacto2_Domicilio_Numeroexterior;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Numerointerior = Contacto2_Domicilio_Numerointerior;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Numerointerior != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Numerointerior = Contacto2_Domicilio_Numerointerior;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Colonia = Contacto2_Domicilio_Colonia;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Colonia != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Colonia = Contacto2_Domicilio_Colonia;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Ciudad = Contacto2_Domicilio_Ciudad;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Ciudad != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Ciudad = Contacto2_Domicilio_Ciudad;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Municipio = Contacto2_Domicilio_Municipio;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Municipio != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Municipio = Contacto2_Domicilio_Municipio;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Estado = Contacto2_Domicilio_Estado;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Estado != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Estado = Contacto2_Domicilio_Estado;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Pais = Contacto2_Domicilio_Pais;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Pais != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Pais = Contacto2_Domicilio_Pais;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Codigopostal = Contacto2_Domicilio_Codigopostal;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Codigopostal != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Codigopostal = Contacto2_Domicilio_Codigopostal;
            }

            if (item.Usuario_Preferencias != null)
                item.Usuario_Preferencias!.Grupousuarioid = Usuario_Preferencias_Grupousuarioid;
            else if (item.Usuario_Preferencias == null && Usuario_Preferencias_Grupousuarioid != null)
            {
                item.Usuario_Preferencias = CreateSubEntity<Usuario_Preferencias>();
                item.Usuario_Preferencias!.Grupousuarioid = Usuario_Preferencias_Grupousuarioid;
            }

            if (item.Usuario_Preferencias != null)
                item.Usuario_Preferencias!.Almacenid = Usuario_Preferencias_Almacenid;
            else if (item.Usuario_Preferencias == null && Usuario_Preferencias_Almacenid != null)
            {
                item.Usuario_Preferencias = CreateSubEntity<Usuario_Preferencias>();
                item.Usuario_Preferencias!.Almacenid = Usuario_Preferencias_Almacenid;
            }

            if (item.Usuario_Preferencias != null)
                item.Usuario_Preferencias!.Listaprecioid = Usuario_Preferencias_Listaprecioid;
            else if (item.Usuario_Preferencias == null && Usuario_Preferencias_Listaprecioid != null)
            {
                item.Usuario_Preferencias = CreateSubEntity<Usuario_Preferencias>();
                item.Usuario_Preferencias!.Listaprecioid = Usuario_Preferencias_Listaprecioid;
            }

            if (item.Usuario_Preferencias != null)
                item.Usuario_Preferencias!.Nombreimpresora = Usuario_Preferencias_Nombreimpresora;
            else if (item.Usuario_Preferencias == null && Usuario_Preferencias_Nombreimpresora != null)
            {
                item.Usuario_Preferencias = CreateSubEntity<Usuario_Preferencias>();
                item.Usuario_Preferencias!.Nombreimpresora = Usuario_Preferencias_Nombreimpresora;
            }

            if (item.Usuario_Personafigura != null)
                item.Usuario_Personafigura!.Personaid = Usuario_Personafigura_Personaid;
            else if (item.Usuario_Personafigura == null && Usuario_Personafigura_Personaid != null)
            {
                item.Usuario_Personafigura = CreateSubEntity<Personafigura>();
                item.Usuario_Personafigura!.Personaid = Usuario_Personafigura_Personaid;
            }

            if (item.Usuario_Personafigura != null)
                item.Usuario_Personafigura!.Sat_Figuratransporteid = Usuario_Personafigura_Sat_Figuratransporteid;
            else if (item.Usuario_Personafigura == null && Usuario_Personafigura_Sat_Figuratransporteid != null)
            {
                item.Usuario_Personafigura = CreateSubEntity<Personafigura>();
                item.Usuario_Personafigura!.Sat_Figuratransporteid = Usuario_Personafigura_Sat_Figuratransporteid;
            }

            if (item.Usuario_Personafigura != null)
                item.Usuario_Personafigura!.Numlicencia = Usuario_Personafigura_Numlicencia;
            else if (item.Usuario_Personafigura == null && Usuario_Personafigura_Numlicencia != null)
            {
                item.Usuario_Personafigura = CreateSubEntity<Personafigura>();
                item.Usuario_Personafigura!.Numlicencia = Usuario_Personafigura_Numlicencia;
            }

            if (item.Usuario_Personafigura != null)
                item.Usuario_Personafigura!.Numregidtrib = Usuario_Personafigura_Numregidtrib;
            else if (item.Usuario_Personafigura == null && Usuario_Personafigura_Numregidtrib != null)
            {
                item.Usuario_Personafigura = CreateSubEntity<Personafigura>();
                item.Usuario_Personafigura!.Numregidtrib = Usuario_Personafigura_Numregidtrib;
            }

            if (item.Usuario_Personafigura != null)
                item.Usuario_Personafigura!.Residenciafiscal = Usuario_Personafigura_Residenciafiscal;
            else if (item.Usuario_Personafigura == null && Usuario_Personafigura_Residenciafiscal != null)
            {
                item.Usuario_Personafigura = CreateSubEntity<Personafigura>();
                item.Usuario_Personafigura!.Residenciafiscal = Usuario_Personafigura_Residenciafiscal;
            }

            if (item.Usuario_Personafigura != null)
                item.Usuario_Personafigura!.Sat_Partetransporteid = Usuario_Personafigura_Sat_Partetransporteid;
            else if (item.Usuario_Personafigura == null && Usuario_Personafigura_Sat_Partetransporteid != null)
            {
                item.Usuario_Personafigura = CreateSubEntity<Personafigura>();
                item.Usuario_Personafigura!.Sat_Partetransporteid = Usuario_Personafigura_Sat_Partetransporteid;
            }

            if (item.Usuario_fact_elect != null)
                item.Usuario_fact_elect!.Sat_id_pais = Usuario_fact_elect_Sat_id_pais;
            else if (item.Usuario_fact_elect == null && Usuario_fact_elect_Sat_id_pais != null)
            {
                item.Usuario_fact_elect = CreateSubEntity<Usuario_fact_elect>();
                item.Usuario_fact_elect!.Sat_id_pais = Usuario_fact_elect_Sat_id_pais;
            }

            if (item.Usuario_fact_elect != null)
                item.Usuario_fact_elect!.Sat_Coloniaid = Usuario_fact_elect_Sat_Coloniaid;
            else if (item.Usuario_fact_elect == null && Usuario_fact_elect_Sat_Coloniaid != null)
            {
                item.Usuario_fact_elect = CreateSubEntity<Usuario_fact_elect>();
                item.Usuario_fact_elect!.Sat_Coloniaid = Usuario_fact_elect_Sat_Coloniaid;
            }

            if (item.Usuario_fact_elect != null)
                item.Usuario_fact_elect!.Sat_Localidadid = Usuario_fact_elect_Sat_Localidadid;
            else if (item.Usuario_fact_elect == null && Usuario_fact_elect_Sat_Localidadid != null)
            {
                item.Usuario_fact_elect = CreateSubEntity<Usuario_fact_elect>();
                item.Usuario_fact_elect!.Sat_Localidadid = Usuario_fact_elect_Sat_Localidadid;
            }

            if (item.Usuario_fact_elect != null)
                item.Usuario_fact_elect!.Sat_Municipioid = Usuario_fact_elect_Sat_Municipioid;
            else if (item.Usuario_fact_elect == null && Usuario_fact_elect_Sat_Municipioid != null)
            {
                item.Usuario_fact_elect = CreateSubEntity<Usuario_fact_elect>();
                item.Usuario_fact_elect!.Sat_Municipioid = Usuario_fact_elect_Sat_Municipioid;
            }

            if (item.Usuario_fact_elect != null)
                item.Usuario_fact_elect!.Estadoid = Usuario_fact_elect_Estadoid;
            else if (item.Usuario_fact_elect == null && Usuario_fact_elect_Estadoid != null)
            {
                item.Usuario_fact_elect = CreateSubEntity<Usuario_fact_elect>();
                item.Usuario_fact_elect!.Estadoid = Usuario_fact_elect_Estadoid;
            }

            if (item.Usuario_fact_elect != null)
                item.Usuario_fact_elect!.Referenciadom = Usuario_fact_elect_Referenciadom;
            else if (item.Usuario_fact_elect == null && Usuario_fact_elect_Referenciadom != null)
            {
                item.Usuario_fact_elect = CreateSubEntity<Usuario_fact_elect>();
                item.Usuario_fact_elect!.Referenciadom = Usuario_fact_elect_Referenciadom;
            }


            if (item.Usuario_emida != null)
                item.Usuario_emida!.Clerkpagoserviciosid = Usuario_emida_Clerkpagoserviciosid;
            else if (item.Usuario_emida == null && Usuario_emida_Clerkpagoserviciosid != null)
            {
                item.Usuario_emida = CreateSubEntity<Usuario_emida>();
                item.Usuario_emida!.Clerkpagoserviciosid = Usuario_emida_Clerkpagoserviciosid;
            }

            if (item.Usuario_emida != null)
                item.Usuario_emida!.Clerkservicios = Usuario_emida_Clerkservicios;
            else if (item.Usuario_emida == null && Usuario_emida_Clerkservicios != null)
            {
                item.Usuario_emida = CreateSubEntity<Usuario_emida>();
                item.Usuario_emida!.Clerkservicios = Usuario_emida_Clerkservicios;
            }


        }

        public void FillFromEntity(Usuario item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Nombre = item.Nombre;

            UsuarioNombre = item.UsuarioNombre;

            Contrasena = item.Contrasena;

            Nombres = item.Nombres;

            Apellidos = item.Apellidos;

            Razonsocial = item.Razonsocial;

            Rfc = item.Rfc;

            Domicilioid = item.Domicilioid;

            Contacto1id = item.Contacto1id;

            Contacto2id = item.Contacto2id;

            Telefono1 = item.Telefono1;

            Telefono2 = item.Telefono2;

            Telefono3 = item.Telefono3;

            Celular = item.Celular;

            Nextel = item.Nextel;

            Email1 = item.Email1;

            Email2 = item.Email2;

            Reset_pass = item.Reset_pass;

            Gaffete = item.Gaffete;

            Ticketlargo = item.Ticketlargo;

            Ticketlargocotizacion = item.Ticketlargocotizacion;

            Ticketlargocredito = item.Ticketlargocredito;

            Preguntarticketlargo = item.Preguntarticketlargo;

            Codigoautorizacion = item.Codigoautorizacion;

            Cajasbotellas = item.Cajasbotellas;

            Clieformaspagodef = item.Clieformaspagodef;

            Esvendedor = item.Esvendedor;

            Vigencia = item.Vigencia;

            Esencargadocorte = item.Esencargadocorte;

            Esencargadoguia = item.Esencargadoguia;

            PendMaxDias = item.PendMaxDias;

            Saludoid = item.Saludoid;

            Clave = item.Clave;

            if (item.Domicilio != null && item.Domicilio?.Calle != null)
                    Domicilio_Calle = item.Domicilio!.Calle;

            if (item.Domicilio != null && item.Domicilio?.Numeroexterior != null)
                    Domicilio_Numeroexterior = item.Domicilio!.Numeroexterior;

            if (item.Domicilio != null && item.Domicilio?.Numerointerior != null)
                    Domicilio_Numerointerior = item.Domicilio!.Numerointerior;

            if (item.Domicilio != null && item.Domicilio?.Colonia != null)
                    Domicilio_Colonia = item.Domicilio!.Colonia;

            if (item.Domicilio != null && item.Domicilio?.Ciudad != null)
                    Domicilio_Ciudad = item.Domicilio!.Ciudad;

            if (item.Domicilio != null && item.Domicilio?.Municipio != null)
                    Domicilio_Municipio = item.Domicilio!.Municipio;

            if (item.Domicilio != null && item.Domicilio?.Estado != null)
                    Domicilio_Estado = item.Domicilio!.Estado;

            if (item.Domicilio != null && item.Domicilio?.Pais != null)
                    Domicilio_Pais = item.Domicilio!.Pais;

            if (item.Domicilio != null && item.Domicilio?.Codigopostal != null)
                    Domicilio_Codigopostal = item.Domicilio!.Codigopostal;

            if (item.Contacto1 != null && item.Contacto1?.Nombre != null)
                    Contacto1_Nombre = item.Contacto1!.Nombre;

            if (item.Contacto1 != null && item.Contacto1?.Email != null)
                    Contacto1_Email = item.Contacto1!.Email;

            if (item.Contacto1 != null && item.Contacto1?.Telefono1 != null)
                    Contacto1_Telefono1 = item.Contacto1!.Telefono1;

            if (item.Contacto1 != null && item.Contacto1?.Domicilioid != null)
                    Contacto1_Domicilioid = item.Contacto1!.Domicilioid;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Calle != null)
                    Contacto1_Domicilio_Calle = item.Contacto1!.Domicilio!.Calle;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Numeroexterior != null)
                    Contacto1_Domicilio_Numeroexterior = item.Contacto1!.Domicilio!.Numeroexterior;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Numerointerior != null)
                    Contacto1_Domicilio_Numerointerior = item.Contacto1!.Domicilio!.Numerointerior;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Colonia != null)
                    Contacto1_Domicilio_Colonia = item.Contacto1!.Domicilio!.Colonia;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Ciudad != null)
                    Contacto1_Domicilio_Ciudad = item.Contacto1!.Domicilio!.Ciudad;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Municipio != null)
                    Contacto1_Domicilio_Municipio = item.Contacto1!.Domicilio!.Municipio;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Estado != null)
                    Contacto1_Domicilio_Estado = item.Contacto1!.Domicilio!.Estado;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Pais != null)
                    Contacto1_Domicilio_Pais = item.Contacto1!.Domicilio!.Pais;

            if (item.Contacto1?.Domicilio != null && item.Contacto1?.Domicilio?.Codigopostal != null)
                    Contacto1_Domicilio_Codigopostal = item.Contacto1!.Domicilio!.Codigopostal;

            if (item.Contacto2 != null && item.Contacto2?.Nombre != null)
                    Contacto2_Nombre = item.Contacto2!.Nombre;

            if (item.Contacto2 != null && item.Contacto2?.Email != null)
                    Contacto2_Email = item.Contacto2!.Email;

            if (item.Contacto2 != null && item.Contacto2?.Telefono1 != null)
                    Contacto2_Telefono1 = item.Contacto2!.Telefono1;

            if (item.Contacto2 != null && item.Contacto2?.Domicilioid != null)
                    Contacto2_Domicilioid = item.Contacto2!.Domicilioid;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Calle != null)
                    Contacto2_Domicilio_Calle = item.Contacto2!.Domicilio!.Calle;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Numeroexterior != null)
                    Contacto2_Domicilio_Numeroexterior = item.Contacto2!.Domicilio!.Numeroexterior;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Numerointerior != null)
                    Contacto2_Domicilio_Numerointerior = item.Contacto2!.Domicilio!.Numerointerior;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Colonia != null)
                    Contacto2_Domicilio_Colonia = item.Contacto2!.Domicilio!.Colonia;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Ciudad != null)
                    Contacto2_Domicilio_Ciudad = item.Contacto2!.Domicilio!.Ciudad;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Municipio != null)
                    Contacto2_Domicilio_Municipio = item.Contacto2!.Domicilio!.Municipio;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Estado != null)
                    Contacto2_Domicilio_Estado = item.Contacto2!.Domicilio!.Estado;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Pais != null)
                    Contacto2_Domicilio_Pais = item.Contacto2!.Domicilio!.Pais;

            if (item.Contacto2?.Domicilio != null && item.Contacto2?.Domicilio?.Codigopostal != null)
                    Contacto2_Domicilio_Codigopostal = item.Contacto2!.Domicilio!.Codigopostal;

            if (item.Usuario_Preferencias != null && item.Usuario_Preferencias?.Grupousuarioid != null)
                    Usuario_Preferencias_Grupousuarioid = item.Usuario_Preferencias!.Grupousuarioid;

            if (item.Usuario_Preferencias != null && item.Usuario_Preferencias?.Almacenid != null)
                    Usuario_Preferencias_Almacenid = item.Usuario_Preferencias!.Almacenid;

            if (item.Usuario_Preferencias != null && item.Usuario_Preferencias?.Listaprecioid != null)
                    Usuario_Preferencias_Listaprecioid = item.Usuario_Preferencias!.Listaprecioid;

            if (item.Usuario_Preferencias != null && item.Usuario_Preferencias?.Nombreimpresora != null)
                    Usuario_Preferencias_Nombreimpresora = item.Usuario_Preferencias!.Nombreimpresora;

            if (item.Usuario_Personafigura != null && item.Usuario_Personafigura?.Personaid != null)
                    Usuario_Personafigura_Personaid = item.Usuario_Personafigura!.Personaid;

            if (item.Usuario_Personafigura != null && item.Usuario_Personafigura?.Sat_Figuratransporteid != null)
                    Usuario_Personafigura_Sat_Figuratransporteid = item.Usuario_Personafigura!.Sat_Figuratransporteid;

            if (item.Usuario_Personafigura != null && item.Usuario_Personafigura?.Numlicencia != null)
                    Usuario_Personafigura_Numlicencia = item.Usuario_Personafigura!.Numlicencia;

            if (item.Usuario_Personafigura != null && item.Usuario_Personafigura?.Numregidtrib != null)
                    Usuario_Personafigura_Numregidtrib = item.Usuario_Personafigura!.Numregidtrib;

            if (item.Usuario_Personafigura != null && item.Usuario_Personafigura?.Residenciafiscal != null)
                    Usuario_Personafigura_Residenciafiscal = item.Usuario_Personafigura!.Residenciafiscal;

            if (item.Usuario_Personafigura != null && item.Usuario_Personafigura?.Sat_Partetransporteid != null)
                    Usuario_Personafigura_Sat_Partetransporteid = item.Usuario_Personafigura!.Sat_Partetransporteid;

            if (item.Usuario_fact_elect != null && item.Usuario_fact_elect?.Sat_id_pais != null)
                    Usuario_fact_elect_Sat_id_pais = item.Usuario_fact_elect!.Sat_id_pais;

            if (item.Usuario_fact_elect != null && item.Usuario_fact_elect?.Sat_Coloniaid != null)
                    Usuario_fact_elect_Sat_Coloniaid = item.Usuario_fact_elect!.Sat_Coloniaid;

            if (item.Usuario_fact_elect != null && item.Usuario_fact_elect?.Sat_Localidadid != null)
                    Usuario_fact_elect_Sat_Localidadid = item.Usuario_fact_elect!.Sat_Localidadid;

            if (item.Usuario_fact_elect != null && item.Usuario_fact_elect?.Sat_Municipioid != null)
                    Usuario_fact_elect_Sat_Municipioid = item.Usuario_fact_elect!.Sat_Municipioid;

            if (item.Usuario_fact_elect != null && item.Usuario_fact_elect?.Estadoid != null)
                    Usuario_fact_elect_Estadoid = item.Usuario_fact_elect!.Estadoid;

            if (item.Usuario_fact_elect != null && item.Usuario_fact_elect?.Referenciadom != null)
                    Usuario_fact_elect_Referenciadom = item.Usuario_fact_elect!.Referenciadom;

            if (item.Usuario_emida != null && item.Usuario_emida?.Clerkpagoserviciosid != null)
                Usuario_emida_Clerkpagoserviciosid = item.Usuario_emida!.Clerkpagoserviciosid;

            if (item.Usuario_emida != null && item.Usuario_emida?.Clerkservicios != null)
                Usuario_emida_Clerkservicios = item.Usuario_emida!.Clerkservicios;


            FillCatalogRelatedFields(item);


        }
        #endif



    }
}

