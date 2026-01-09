
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
    
    public class ClienteBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ClienteBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public ClienteBindingModelGenerated(Cliente item)
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
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

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


        private string? _Domicilio_Referencia;
        [XmlAttribute]
        public string? Domicilio_Referencia { get => _Domicilio_Referencia; set { if (RaiseAcceptPendingChange(value, _Domicilio_Referencia)) { _Domicilio_Referencia = value; OnPropertyChanged(); } } }


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

        private long? _Domicilioentregaid;
        [XmlAttribute]
        public long? Domicilioentregaid { get => _Domicilioentregaid; set { if (RaiseAcceptPendingChange(value, _Domicilioentregaid)) { _Domicilioentregaid = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Calle;
        [XmlAttribute]
        public string? Domicilioentrega_Calle { get => _Domicilioentrega_Calle; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Calle)) { _Domicilioentrega_Calle = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Numeroexterior;
        [XmlAttribute]
        public string? Domicilioentrega_Numeroexterior { get => _Domicilioentrega_Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Numeroexterior)) { _Domicilioentrega_Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Numerointerior;
        [XmlAttribute]
        public string? Domicilioentrega_Numerointerior { get => _Domicilioentrega_Numerointerior; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Numerointerior)) { _Domicilioentrega_Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Colonia;
        [XmlAttribute]
        public string? Domicilioentrega_Colonia { get => _Domicilioentrega_Colonia; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Colonia)) { _Domicilioentrega_Colonia = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Ciudad;
        [XmlAttribute]
        public string? Domicilioentrega_Ciudad { get => _Domicilioentrega_Ciudad; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Ciudad)) { _Domicilioentrega_Ciudad = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Municipio;
        [XmlAttribute]
        public string? Domicilioentrega_Municipio { get => _Domicilioentrega_Municipio; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Municipio)) { _Domicilioentrega_Municipio = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Estado;
        [XmlAttribute]
        public string? Domicilioentrega_Estado { get => _Domicilioentrega_Estado; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Estado)) { _Domicilioentrega_Estado = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Pais;
        [XmlAttribute]
        public string? Domicilioentrega_Pais { get => _Domicilioentrega_Pais; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Pais)) { _Domicilioentrega_Pais = value; OnPropertyChanged(); } } }

        private string? _Domicilioentrega_Codigopostal;
        [XmlAttribute]
        public string? Domicilioentrega_Codigopostal { get => _Domicilioentrega_Codigopostal; set { if (RaiseAcceptPendingChange(value, _Domicilioentrega_Codigopostal)) { _Domicilioentrega_Codigopostal = value; OnPropertyChanged(); } } }

        private long? _Subtipoclienteid;
        [XmlAttribute]
        public long? Subtipoclienteid { get => _Subtipoclienteid; set { if (RaiseAcceptPendingChange(value, _Subtipoclienteid)) { _Subtipoclienteid = value; OnPropertyChanged(); } } }

        private string? _SubtipoclienteClave;
        [XmlAttribute]
        public string? SubtipoclienteClave { get => _SubtipoclienteClave; set { if (RaiseAcceptPendingChange(value, _SubtipoclienteClave)) { _SubtipoclienteClave = value; OnPropertyChanged(); } } }

        private string? _SubtipoclienteNombre;
        [XmlAttribute]
        public string? SubtipoclienteNombre { get => _SubtipoclienteNombre; set { if (RaiseAcceptPendingChange(value, _SubtipoclienteNombre)) { _SubtipoclienteNombre = value; OnPropertyChanged(); } } }

        private long? _Proveeclienteid;
        [XmlAttribute]
        public long? Proveeclienteid { get => _Proveeclienteid; set { if (RaiseAcceptPendingChange(value, _Proveeclienteid)) { _Proveeclienteid = value; OnPropertyChanged(); } } }

        private string? _ProveeclienteClave;
        [XmlAttribute]
        public string? ProveeclienteClave { get => _ProveeclienteClave; set { if (RaiseAcceptPendingChange(value, _ProveeclienteClave)) { _ProveeclienteClave = value; OnPropertyChanged(); } } }

        private string? _ProveeclienteNombre;
        [XmlAttribute]
        public string? ProveeclienteNombre { get => _ProveeclienteNombre; set { if (RaiseAcceptPendingChange(value, _ProveeclienteNombre)) { _ProveeclienteNombre = value; OnPropertyChanged(); } } }


        private DateTimeOffset? _Vigencia;
        [XmlAttribute]
        public DateTimeOffset? Vigencia { get => _Vigencia; set { if (RaiseAcceptPendingChange(value, _Vigencia)) { _Vigencia = value; OnPropertyChanged(); } } }

        private string? _Firma;
        [XmlAttribute]
        public string? Firma { get => _Firma; set { if (RaiseAcceptPendingChange(value, _Firma)) { _Firma = value; OnPropertyChanged(); } } }

        private string? _Email3;
        [XmlAttribute]
        public string? Email3 { get => _Email3; set { if (RaiseAcceptPendingChange(value, _Email3)) { _Email3 = value; OnPropertyChanged(); } } }

        private string? _Email4;
        [XmlAttribute]
        public string? Email4 { get => _Email4; set { if (RaiseAcceptPendingChange(value, _Email4)) { _Email4 = value; OnPropertyChanged(); } } }

        private long? _Cliente_bancomer_Bancomerdoctopendid;
        [XmlAttribute]
        public long? Cliente_bancomer_Bancomerdoctopendid { get => _Cliente_bancomer_Bancomerdoctopendid; set { if (RaiseAcceptPendingChange(value, _Cliente_bancomer_Bancomerdoctopendid)) { _Cliente_bancomer_Bancomerdoctopendid = value; OnPropertyChanged(); } } }

        private string? _Cliente_bancomer_BancomerdoctopendClave;
        [XmlAttribute]
        public string? Cliente_bancomer_BancomerdoctopendClave { get => _Cliente_bancomer_BancomerdoctopendClave; set { if (RaiseAcceptPendingChange(value, _Cliente_bancomer_BancomerdoctopendClave)) { _Cliente_bancomer_BancomerdoctopendClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_bancomer_BancomerdoctopendNombre;
        [XmlAttribute]
        public string? Cliente_bancomer_BancomerdoctopendNombre { get => _Cliente_bancomer_BancomerdoctopendNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_bancomer_BancomerdoctopendNombre)) { _Cliente_bancomer_BancomerdoctopendNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_comision_Vendedorid;
        [XmlAttribute]
        public long? Cliente_comision_Vendedorid { get => _Cliente_comision_Vendedorid; set { if (RaiseAcceptPendingChange(value, _Cliente_comision_Vendedorid)) { _Cliente_comision_Vendedorid = value; OnPropertyChanged(); } } }

        private string? _Cliente_comision_VendedorClave;
        [XmlAttribute]
        public string? Cliente_comision_VendedorClave { get => _Cliente_comision_VendedorClave; set { if (RaiseAcceptPendingChange(value, _Cliente_comision_VendedorClave)) { _Cliente_comision_VendedorClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_comision_VendedorNombre;
        [XmlAttribute]
        public string? Cliente_comision_VendedorNombre { get => _Cliente_comision_VendedorNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_comision_VendedorNombre)) { _Cliente_comision_VendedorNombre = value; OnPropertyChanged(); } } }


        private decimal? _Cliente_comision_Por_come;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_comision_Por_come { get => _Cliente_comision_Por_come ?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_comision_Por_come)) { _Cliente_comision_Por_come = value ?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_comision_Servicioadomicilio;
        [XmlAttribute]
        public BoolCN? Cliente_comision_Servicioadomicilio { get => _Cliente_comision_Servicioadomicilio; set { if (RaiseAcceptPendingChange(value, _Cliente_comision_Servicioadomicilio)) { _Cliente_comision_Servicioadomicilio = value; OnPropertyChanged(); } } }


        private BoolCN? _Cliente_fact_elect_Generarreciboelectronico;
        [XmlAttribute]
        public BoolCN? Cliente_fact_elect_Generarreciboelectronico { get => _Cliente_fact_elect_Generarreciboelectronico; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Generarreciboelectronico)) { _Cliente_fact_elect_Generarreciboelectronico = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_fact_elect_Retieneisr;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_fact_elect_Retieneisr { get => _Cliente_fact_elect_Retieneisr?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Retieneisr)) { _Cliente_fact_elect_Retieneisr = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_fact_elect_Retieneiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_fact_elect_Retieneiva { get => _Cliente_fact_elect_Retieneiva?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Retieneiva)) { _Cliente_fact_elect_Retieneiva = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Creditoformapagosatabonos;
        [XmlAttribute]
        public long? Cliente_fact_elect_Creditoformapagosatabonos { get => _Cliente_fact_elect_Creditoformapagosatabonos; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Creditoformapagosatabonos)) { _Cliente_fact_elect_Creditoformapagosatabonos = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Creditoformapagosatabonos_Clave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Creditoformapagosatabonos_Clave { get => _Cliente_fact_elect_Creditoformapagosatabonos_Clave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Creditoformapagosatabonos_Clave)) { _Cliente_fact_elect_Creditoformapagosatabonos_Clave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Creditoformapagosatabonos_Nombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Creditoformapagosatabonos_Nombre { get => _Cliente_fact_elect_Creditoformapagosatabonos_Nombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Creditoformapagosatabonos_Nombre)) { _Cliente_fact_elect_Creditoformapagosatabonos_Nombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Sat_usocfdiid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Sat_usocfdiid { get => _Cliente_fact_elect_Sat_usocfdiid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_usocfdiid)) { _Cliente_fact_elect_Sat_usocfdiid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_usocfdiClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_usocfdiClave { get => _Cliente_fact_elect_Sat_usocfdiClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_usocfdiClave)) { _Cliente_fact_elect_Sat_usocfdiClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_usocfdiNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_usocfdiNombre { get => _Cliente_fact_elect_Sat_usocfdiNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_usocfdiNombre)) { _Cliente_fact_elect_Sat_usocfdiNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Sat_id_pais;
        [XmlAttribute]
        public long? Cliente_fact_elect_Sat_id_pais { get => _Cliente_fact_elect_Sat_id_pais; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_id_pais)) { _Cliente_fact_elect_Sat_id_pais = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_paisClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_paisClave { get => _Cliente_fact_elect_Sat_paisClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_paisClave)) { _Cliente_fact_elect_Sat_paisClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_paisNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_paisNombre { get => _Cliente_fact_elect_Sat_paisNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_paisNombre)) { _Cliente_fact_elect_Sat_paisNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Sat_Coloniaid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Sat_Coloniaid { get => _Cliente_fact_elect_Sat_Coloniaid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_Coloniaid)) { _Cliente_fact_elect_Sat_Coloniaid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_ColoniaClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_ColoniaClave { get => _Cliente_fact_elect_Sat_ColoniaClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_ColoniaClave)) { _Cliente_fact_elect_Sat_ColoniaClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_ColoniaNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_ColoniaNombre { get => _Cliente_fact_elect_Sat_ColoniaNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_ColoniaNombre)) { _Cliente_fact_elect_Sat_ColoniaNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Sat_Localidadid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Sat_Localidadid { get => _Cliente_fact_elect_Sat_Localidadid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_Localidadid)) { _Cliente_fact_elect_Sat_Localidadid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_LocalidadClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_LocalidadClave { get => _Cliente_fact_elect_Sat_LocalidadClave; set { 
                if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_LocalidadClave)) {
                    _Cliente_fact_elect_Sat_LocalidadClave = value; OnPropertyChanged(); 
                } } }

        private string? _Cliente_fact_elect_Sat_LocalidadNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_LocalidadNombre { get => _Cliente_fact_elect_Sat_LocalidadNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_LocalidadNombre)) { _Cliente_fact_elect_Sat_LocalidadNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Sat_Municipioid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Sat_Municipioid { get => _Cliente_fact_elect_Sat_Municipioid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_Municipioid)) { _Cliente_fact_elect_Sat_Municipioid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_MunicipioClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_MunicipioClave { get => _Cliente_fact_elect_Sat_MunicipioClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_MunicipioClave)) { _Cliente_fact_elect_Sat_MunicipioClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_MunicipioNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_MunicipioNombre { get => _Cliente_fact_elect_Sat_MunicipioNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_MunicipioNombre)) { _Cliente_fact_elect_Sat_MunicipioNombre = value; OnPropertyChanged(); } } }

        private decimal? _Cliente_fact_elect_Distancia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_fact_elect_Distancia { get => _Cliente_fact_elect_Distancia?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Distancia)) { _Cliente_fact_elect_Distancia = value?? 0; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Entrega_Sat_Coloniaid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Entrega_Sat_Coloniaid { get => _Cliente_fact_elect_Entrega_Sat_Coloniaid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_Coloniaid)) { _Cliente_fact_elect_Entrega_Sat_Coloniaid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entrega_Sat_ColoniaClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entrega_Sat_ColoniaClave { get => _Cliente_fact_elect_Entrega_Sat_ColoniaClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_ColoniaClave)) { _Cliente_fact_elect_Entrega_Sat_ColoniaClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entrega_Sat_ColoniaNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entrega_Sat_ColoniaNombre { get => _Cliente_fact_elect_Entrega_Sat_ColoniaNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_ColoniaNombre)) { _Cliente_fact_elect_Entrega_Sat_ColoniaNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Entrega_Sat_Localidadid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Entrega_Sat_Localidadid { get => _Cliente_fact_elect_Entrega_Sat_Localidadid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_Localidadid)) { _Cliente_fact_elect_Entrega_Sat_Localidadid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entrega_Sat_LocalidadClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entrega_Sat_LocalidadClave { get => _Cliente_fact_elect_Entrega_Sat_LocalidadClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_LocalidadClave)) { _Cliente_fact_elect_Entrega_Sat_LocalidadClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entrega_Sat_LocalidadNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entrega_Sat_LocalidadNombre { get => _Cliente_fact_elect_Entrega_Sat_LocalidadNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_LocalidadNombre)) { _Cliente_fact_elect_Entrega_Sat_LocalidadNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Entrega_Sat_Municipioid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Entrega_Sat_Municipioid { get => _Cliente_fact_elect_Entrega_Sat_Municipioid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_Municipioid)) { _Cliente_fact_elect_Entrega_Sat_Municipioid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entrega_Sat_MunicipioClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entrega_Sat_MunicipioClave { get => _Cliente_fact_elect_Entrega_Sat_MunicipioClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_MunicipioClave)) { _Cliente_fact_elect_Entrega_Sat_MunicipioClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entrega_Sat_MunicipioNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entrega_Sat_MunicipioNombre { get => _Cliente_fact_elect_Entrega_Sat_MunicipioNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Sat_MunicipioNombre)) { _Cliente_fact_elect_Entrega_Sat_MunicipioNombre = value; OnPropertyChanged(); } } }

        private decimal? _Cliente_fact_elect_Entrega_Distancia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_fact_elect_Entrega_Distancia { get => _Cliente_fact_elect_Entrega_Distancia?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entrega_Distancia)) { _Cliente_fact_elect_Entrega_Distancia = value?? 0; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Entregareferenciadom;
        [XmlAttribute]
        public string? Cliente_fact_elect_Entregareferenciadom { get => _Cliente_fact_elect_Entregareferenciadom; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Entregareferenciadom)) { _Cliente_fact_elect_Entregareferenciadom = value; OnPropertyChanged(); } } }

        private long? _Cliente_fact_elect_Sat_Regimenfiscalid;
        [XmlAttribute]
        public long? Cliente_fact_elect_Sat_Regimenfiscalid { get => _Cliente_fact_elect_Sat_Regimenfiscalid; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_Regimenfiscalid)) { _Cliente_fact_elect_Sat_Regimenfiscalid = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_RegimenfiscalClave;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_RegimenfiscalClave { get => _Cliente_fact_elect_Sat_RegimenfiscalClave; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_RegimenfiscalClave)) { _Cliente_fact_elect_Sat_RegimenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_fact_elect_Sat_RegimenfiscalNombre;
        [XmlAttribute]
        public string? Cliente_fact_elect_Sat_RegimenfiscalNombre { get => _Cliente_fact_elect_Sat_RegimenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Sat_RegimenfiscalNombre)) { _Cliente_fact_elect_Sat_RegimenfiscalNombre = value; OnPropertyChanged(); } } }


        private BoolCN? _Cliente_fact_elect_Generacomprobtrasl;
        [XmlAttribute]
        public BoolCN? Cliente_fact_elect_Generacomprobtrasl { get => _Cliente_fact_elect_Generacomprobtrasl; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Generacomprobtrasl)) { _Cliente_fact_elect_Generacomprobtrasl = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_fact_elect_Generacartaporte;
        [XmlAttribute]
        public BoolCN? Cliente_fact_elect_Generacartaporte { get => _Cliente_fact_elect_Generacartaporte; set { if (RaiseAcceptPendingChange(value, _Cliente_fact_elect_Generacartaporte)) { _Cliente_fact_elect_Generacartaporte = value; OnPropertyChanged(); } } }


        private BoolCN? _Cliente_ordencompra_Solicitaordencompra;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_ordencompra_Solicitaordencompra { get => _Cliente_ordencompra_Solicitaordencompra?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_ordencompra_Solicitaordencompra)) { _Cliente_ordencompra_Solicitaordencompra = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Cliente_pago_Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_pago_Saldo { get => _Cliente_pago_Saldo?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_Saldo)) { _Cliente_pago_Saldo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cliente_pago_Saldoapartadonegativo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_pago_Saldoapartadonegativo { get => _Cliente_pago_Saldoapartadonegativo?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_Saldoapartadonegativo)) { _Cliente_pago_Saldoapartadonegativo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cliente_pago_Saldoapartadopositivo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_pago_Saldoapartadopositivo { get => _Cliente_pago_Saldoapartadopositivo?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_Saldoapartadopositivo)) { _Cliente_pago_Saldoapartadopositivo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cliente_pago_Saldospositivos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_pago_Saldospositivos { get => _Cliente_pago_Saldospositivos?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_Saldospositivos)) { _Cliente_pago_Saldospositivos = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cliente_pago_Saldosnegativos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_pago_Saldosnegativos { get => _Cliente_pago_Saldosnegativos?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_Saldosnegativos)) { _Cliente_pago_Saldosnegativos = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Cliente_pago_Ultimaventa;
        [XmlAttribute]
        public DateTimeOffset? Cliente_pago_Ultimaventa { get => _Cliente_pago_Ultimaventa; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_Ultimaventa)) { _Cliente_pago_Ultimaventa = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Hab_pagotarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Hab_pagotarjeta { get => _Cliente_pago_parametros_Hab_pagotarjeta?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Hab_pagotarjeta)) { _Cliente_pago_parametros_Hab_pagotarjeta = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Hab_pagocredito;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Hab_pagocredito { get => _Cliente_pago_parametros_Hab_pagocredito?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Hab_pagocredito)) { _Cliente_pago_parametros_Hab_pagocredito = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Hab_pagocheque;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Hab_pagocheque { get => _Cliente_pago_parametros_Hab_pagocheque?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Hab_pagocheque)) { _Cliente_pago_parametros_Hab_pagocheque = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_Revision;
        [XmlAttribute]
        public string? Cliente_pago_parametros_Revision { get => _Cliente_pago_parametros_Revision; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Revision)) { _Cliente_pago_parametros_Revision = value; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_Pagos;
        [XmlAttribute]
        public string? Cliente_pago_parametros_Pagos { get => _Cliente_pago_parametros_Pagos; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Pagos)) { _Cliente_pago_parametros_Pagos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Bloqueado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Bloqueado { get => _Cliente_pago_parametros_Bloqueado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Bloqueado)) { _Cliente_pago_parametros_Bloqueado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Hab_pagotransferencia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Hab_pagotransferencia { get => _Cliente_pago_parametros_Hab_pagotransferencia?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Hab_pagotransferencia)) { _Cliente_pago_parametros_Hab_pagotransferencia = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCS? _Cliente_pago_parametros_Hab_pagoefectivo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Cliente_pago_parametros_Hab_pagoefectivo { get => _Cliente_pago_parametros_Hab_pagoefectivo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Hab_pagoefectivo)) { _Cliente_pago_parametros_Hab_pagoefectivo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Pagoparcialidades;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Pagoparcialidades { get => _Cliente_pago_parametros_Pagoparcialidades?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Pagoparcialidades)) { _Cliente_pago_parametros_Pagoparcialidades = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_Creditoreferenciaabonos;
        [XmlAttribute]
        public string? Cliente_pago_parametros_Creditoreferenciaabonos { get => _Cliente_pago_parametros_Creditoreferenciaabonos; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Creditoreferenciaabonos)) { _Cliente_pago_parametros_Creditoreferenciaabonos = value; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_Bloqueonot;
        [XmlAttribute]
        public string? Cliente_pago_parametros_Bloqueonot { get => _Cliente_pago_parametros_Bloqueonot; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Bloqueonot)) { _Cliente_pago_parametros_Bloqueonot = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Exentoiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Exentoiva { get => _Cliente_pago_parametros_Exentoiva?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Exentoiva)) { _Cliente_pago_parametros_Exentoiva = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Cargoxventacontarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Cargoxventacontarjeta { get => _Cliente_pago_parametros_Cargoxventacontarjeta?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Cargoxventacontarjeta)) { _Cliente_pago_parametros_Cargoxventacontarjeta = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_pago_parametros_Pagotarjmenorpreciolista;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_pago_parametros_Pagotarjmenorpreciolista { get => _Cliente_pago_parametros_Pagotarjmenorpreciolista?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Pagotarjmenorpreciolista)) { _Cliente_pago_parametros_Pagotarjmenorpreciolista = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Cliente_pago_parametros_Limitecredito;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cliente_pago_parametros_Limitecredito { get => _Cliente_pago_parametros_Limitecredito?? 0; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Limitecredito)) { _Cliente_pago_parametros_Limitecredito = value?? 0; OnPropertyChanged(); } } }

        private int? _Cliente_pago_parametros_Dias;
        [XmlAttribute]
        public int? Cliente_pago_parametros_Dias { get => _Cliente_pago_parametros_Dias; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Dias)) { _Cliente_pago_parametros_Dias = value; OnPropertyChanged(); } } }

        private long? _Cliente_pago_parametros_Creditoformapagoabonos;
        [XmlAttribute]
        public long? Cliente_pago_parametros_Creditoformapagoabonos { get => _Cliente_pago_parametros_Creditoformapagoabonos; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Creditoformapagoabonos)) { _Cliente_pago_parametros_Creditoformapagoabonos = value; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_Creditoformapagoabonos_Clave;
        [XmlAttribute]
        public string? Cliente_pago_parametros_Creditoformapagoabonos_Clave { get => _Cliente_pago_parametros_Creditoformapagoabonos_Clave; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Creditoformapagoabonos_Clave)) { _Cliente_pago_parametros_Creditoformapagoabonos_Clave = value; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_Creditoformapagoabonos_Nombre;
        [XmlAttribute]
        public string? Cliente_pago_parametros_Creditoformapagoabonos_Nombre { get => _Cliente_pago_parametros_Creditoformapagoabonos_Nombre; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Creditoformapagoabonos_Nombre)) { _Cliente_pago_parametros_Creditoformapagoabonos_Nombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_pago_parametros_Monedaid;
        [XmlAttribute]
        public long? Cliente_pago_parametros_Monedaid { get => _Cliente_pago_parametros_Monedaid; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Monedaid)) { _Cliente_pago_parametros_Monedaid = value; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_MonedaClave;
        [XmlAttribute]
        public string? Cliente_pago_parametros_MonedaClave { get => _Cliente_pago_parametros_MonedaClave; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_MonedaClave)) { _Cliente_pago_parametros_MonedaClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_pago_parametros_MonedaNombre;
        [XmlAttribute]
        public string? Cliente_pago_parametros_MonedaNombre { get => _Cliente_pago_parametros_MonedaNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_MonedaNombre)) { _Cliente_pago_parametros_MonedaNombre = value; OnPropertyChanged(); } } }


        private int? _Cliente_pago_parametros_Dias_extr;
        [XmlAttribute]
        public int? Cliente_pago_parametros_Dias_extr { get => _Cliente_pago_parametros_Dias_extr; set { if (RaiseAcceptPendingChange(value, _Cliente_pago_parametros_Dias_extr)) { _Cliente_pago_parametros_Dias_extr = value; OnPropertyChanged(); } } }


        private BoolCN? _Cliente_poliza_Desgloseieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_poliza_Desgloseieps { get => _Cliente_poliza_Desgloseieps?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_poliza_Desgloseieps)) { _Cliente_poliza_Desgloseieps = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Cliente_poliza_Cuentaieps;
        [XmlAttribute]
        public string? Cliente_poliza_Cuentaieps { get => _Cliente_poliza_Cuentaieps; set { if (RaiseAcceptPendingChange(value, _Cliente_poliza_Cuentaieps)) { _Cliente_poliza_Cuentaieps = value; OnPropertyChanged(); } } }

        private string? _Cliente_poliza_Cuentacontpaq;
        [XmlAttribute]
        public string? Cliente_poliza_Cuentacontpaq { get => _Cliente_poliza_Cuentacontpaq; set { if (RaiseAcceptPendingChange(value, _Cliente_poliza_Cuentacontpaq)) { _Cliente_poliza_Cuentacontpaq = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_poliza_Separarprodxplazo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_poliza_Separarprodxplazo { get => _Cliente_poliza_Separarprodxplazo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_poliza_Separarprodxplazo)) { _Cliente_poliza_Separarprodxplazo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Cliente_precio_Listaprecioid;
        [XmlAttribute]
        public long? Cliente_precio_Listaprecioid { get => _Cliente_precio_Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_Listaprecioid)) { _Cliente_precio_Listaprecioid = value; OnPropertyChanged(); } } }

        private string? _Cliente_precio_ListaprecioClave;
        [XmlAttribute]
        public string? Cliente_precio_ListaprecioClave { get => _Cliente_precio_ListaprecioClave; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_ListaprecioClave)) { _Cliente_precio_ListaprecioClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_precio_ListaprecioNombre;
        [XmlAttribute]
        public string? Cliente_precio_ListaprecioNombre { get => _Cliente_precio_ListaprecioNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_ListaprecioNombre)) { _Cliente_precio_ListaprecioNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente_precio_Superlistaprecioid;
        [XmlAttribute]
        public long? Cliente_precio_Superlistaprecioid { get => _Cliente_precio_Superlistaprecioid; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_Superlistaprecioid)) { _Cliente_precio_Superlistaprecioid = value; OnPropertyChanged(); } } }

        private string? _Cliente_precio_SuperlistaprecioClave;
        [XmlAttribute]
        public string? Cliente_precio_SuperlistaprecioClave { get => _Cliente_precio_SuperlistaprecioClave; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_SuperlistaprecioClave)) { _Cliente_precio_SuperlistaprecioClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_precio_SuperlistaprecioNombre;
        [XmlAttribute]
        public string? Cliente_precio_SuperlistaprecioNombre { get => _Cliente_precio_SuperlistaprecioNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_SuperlistaprecioNombre)) { _Cliente_precio_SuperlistaprecioNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cliente_precio_Mayoreoxproducto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cliente_precio_Mayoreoxproducto { get => _Cliente_precio_Mayoreoxproducto?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cliente_precio_Mayoreoxproducto)) { _Cliente_precio_Mayoreoxproducto = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Cliente_rutaembarque_Rutaembarqueid;
        [XmlAttribute]
        public long? Cliente_rutaembarque_Rutaembarqueid { get => _Cliente_rutaembarque_Rutaembarqueid; set { if (RaiseAcceptPendingChange(value, _Cliente_rutaembarque_Rutaembarqueid)) { _Cliente_rutaembarque_Rutaembarqueid = value; OnPropertyChanged(); } } }

        private string? _Cliente_rutaembarque_RutaembarqueClave;
        [XmlAttribute]
        public string? Cliente_rutaembarque_RutaembarqueClave { get => _Cliente_rutaembarque_RutaembarqueClave; set { if (RaiseAcceptPendingChange(value, _Cliente_rutaembarque_RutaembarqueClave)) { _Cliente_rutaembarque_RutaembarqueClave = value; OnPropertyChanged(); } } }

        private string? _Cliente_rutaembarque_RutaembarqueNombre;
        [XmlAttribute]
        public string? Cliente_rutaembarque_RutaembarqueNombre { get => _Cliente_rutaembarque_RutaembarqueNombre; set { if (RaiseAcceptPendingChange(value, _Cliente_rutaembarque_RutaembarqueNombre)) { _Cliente_rutaembarque_RutaembarqueNombre = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Cliente"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombres|Apellidos|Razonsocial|Rfc|Telefono1|Telefono2|Telefono3|Celular|Nextel|Email1|Email2|Domicilio.Calle|Domicilio.Numeroexterior|Domicilio.Numerointerior|Domicilio.Colonia|Domicilio.Ciudad|Domicilio.Municipio|Domicilio.Estado|Domicilio.Pais|Domicilio.Codigopostal|Contacto1.Nombre|Contacto1.Email|Contacto1.Telefono1|Contacto1.Domicilio.Calle|Contacto1.Domicilio.Numeroexterior|Contacto1.Domicilio.Numerointerior|Contacto1.Domicilio.Colonia|Contacto1.Domicilio.Ciudad|Contacto1.Domicilio.Municipio|Contacto1.Domicilio.Estado|Contacto1.Domicilio.Pais|Contacto1.Domicilio.Codigopostal|Contacto2.Nombre|Contacto2.Email|Contacto2.Telefono1|Contacto2.Domicilio.Calle|Contacto2.Domicilio.Numeroexterior|Contacto2.Domicilio.Numerointerior|Contacto2.Domicilio.Colonia|Contacto2.Domicilio.Ciudad|Contacto2.Domicilio.Municipio|Contacto2.Domicilio.Estado|Contacto2.Domicilio.Pais|Contacto2.Domicilio.Codigopostal|Domicilioentrega.Calle|Domicilioentrega.Numeroexterior|Domicilioentrega.Numerointerior|Domicilioentrega.Colonia|Domicilioentrega.Ciudad|Domicilioentrega.Municipio|Domicilioentrega.Estado|Domicilioentrega.Pais|Domicilioentrega.Codigopostal|Subtipocliente.Clave|Subtipocliente.Nombre|Proveecliente.Clave|Proveecliente.Nombre|Cliente_bancomer.Bancomerdoctopend.Clave|Cliente_bancomer.Bancomerdoctopend.Nombre|Cliente_comision.Vendedor.Clave|Cliente_comision.Vendedor.Nombre|Cliente_fact_elect.Creditoformapagosatabonos_.Clave|Cliente_fact_elect.Creditoformapagosatabonos_.Nombre|Cliente_fact_elect.Sat_usocfdi.Clave|Cliente_fact_elect.Sat_usocfdi.Nombre|Cliente_fact_elect.Sat_pais.Clave|Cliente_fact_elect.Sat_pais.Nombre|Cliente_fact_elect.Sat_Colonia.Clave|Cliente_fact_elect.Sat_Colonia.Nombre|Cliente_fact_elect.Sat_Localidad.Clave|Cliente_fact_elect.Sat_Localidad.Nombre|Cliente_fact_elect.Sat_Municipio.Clave|Cliente_fact_elect.Sat_Municipio.Nombre|Cliente_fact_elect.Entrega_Sat_Colonia.Clave|Cliente_fact_elect.Entrega_Sat_Colonia.Nombre|Cliente_fact_elect.Entrega_Sat_Localidad.Clave|Cliente_fact_elect.Entrega_Sat_Localidad.Nombre|Cliente_fact_elect.Entrega_Sat_Municipio.Clave|Cliente_fact_elect.Entrega_Sat_Municipio.Nombre|Cliente_fact_elect.Entregareferenciadom|Cliente_fact_elect.Sat_Regimenfiscal.Clave|Cliente_fact_elect.Sat_Regimenfiscal.Nombre|Cliente_pago_parametros.Revision|Cliente_pago_parametros.Pagos|Cliente_pago_parametros.Creditoreferenciaabonos|Cliente_pago_parametros.Bloqueonot|Cliente_pago_parametros.Creditoformapagoabonos_.Clave|Cliente_pago_parametros.Creditoformapagoabonos_.Nombre|Cliente_pago_parametros.Moneda.Clave|Cliente_pago_parametros.Moneda.Nombre|Cliente_poliza.Cuentaieps|Cliente_poliza.Cuentacontpaq|Cliente_precio.Listaprecio.Clave|Cliente_precio.Listaprecio.Nombre|Cliente_precio.Superlistaprecio.Clave|Cliente_precio.Superlistaprecio.Nombre|Cliente_rutaembarque.Rutaembarque.Clave|Cliente_rutaembarque.Rutaembarque.Nombre|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Cliente item)
        {

             this._SubtipoclienteClave = item.Subtipocliente?.Clave;

             this._SubtipoclienteNombre = item.Subtipocliente?.Nombre;

             this._ProveeclienteClave = item.Proveecliente?.Clave;

             this._ProveeclienteNombre = item.Proveecliente?.Nombre;

             this._Cliente_bancomer_BancomerdoctopendClave = item.Cliente_bancomer?.Bancomerdoctopend?.Clave;

             this._Cliente_bancomer_BancomerdoctopendNombre = item.Cliente_bancomer?.Bancomerdoctopend?.Nombre;

             this._Cliente_comision_VendedorClave = item.Cliente_comision?.Vendedor?.Clave;

             this._Cliente_comision_VendedorNombre = item.Cliente_comision?.Vendedor?.Nombre;

             this._Cliente_fact_elect_Creditoformapagosatabonos_Clave = item.Cliente_fact_elect?.Creditoformapagosatabonos_?.Clave;

             this._Cliente_fact_elect_Creditoformapagosatabonos_Nombre = item.Cliente_fact_elect?.Creditoformapagosatabonos_?.Nombre;

             this._Cliente_fact_elect_Sat_usocfdiClave = item.Cliente_fact_elect?.Sat_usocfdi?.Clave;

             this._Cliente_fact_elect_Sat_usocfdiNombre = item.Cliente_fact_elect?.Sat_usocfdi?.Nombre;

             this._Cliente_fact_elect_Sat_paisClave = item.Cliente_fact_elect?.Sat_pais?.Clave;

             this._Cliente_fact_elect_Sat_paisNombre = item.Cliente_fact_elect?.Sat_pais?.Nombre;

             this._Cliente_fact_elect_Sat_ColoniaClave = item.Cliente_fact_elect?.Sat_Colonia?.Clave;

             this._Cliente_fact_elect_Sat_ColoniaNombre = item.Cliente_fact_elect?.Sat_Colonia?.Nombre;

             this._Cliente_fact_elect_Sat_LocalidadClave = item.Cliente_fact_elect?.Sat_Localidad?.Clave;

             this._Cliente_fact_elect_Sat_LocalidadNombre = item.Cliente_fact_elect?.Sat_Localidad?.Nombre;

             this._Cliente_fact_elect_Sat_MunicipioClave = item.Cliente_fact_elect?.Sat_Municipio?.Clave;

             this._Cliente_fact_elect_Sat_MunicipioNombre = item.Cliente_fact_elect?.Sat_Municipio?.Nombre;

             this._Cliente_fact_elect_Entrega_Sat_ColoniaClave = item.Cliente_fact_elect?.Entrega_Sat_Colonia?.Clave;

             this._Cliente_fact_elect_Entrega_Sat_ColoniaNombre = item.Cliente_fact_elect?.Entrega_Sat_Colonia?.Nombre;

             this._Cliente_fact_elect_Entrega_Sat_LocalidadClave = item.Cliente_fact_elect?.Entrega_Sat_Localidad?.Clave;

             this._Cliente_fact_elect_Entrega_Sat_LocalidadNombre = item.Cliente_fact_elect?.Entrega_Sat_Localidad?.Nombre;

             this._Cliente_fact_elect_Entrega_Sat_MunicipioClave = item.Cliente_fact_elect?.Entrega_Sat_Municipio?.Clave;

             this._Cliente_fact_elect_Entrega_Sat_MunicipioNombre = item.Cliente_fact_elect?.Entrega_Sat_Municipio?.Nombre;

             this._Cliente_fact_elect_Sat_RegimenfiscalClave = item.Cliente_fact_elect?.Sat_Regimenfiscal?.Clave;

             this._Cliente_fact_elect_Sat_RegimenfiscalNombre = item.Cliente_fact_elect?.Sat_Regimenfiscal?.Nombre;

             this._Cliente_pago_parametros_Creditoformapagoabonos_Clave = item.Cliente_pago_parametros?.Creditoformapagoabonos_?.Clave;

             this._Cliente_pago_parametros_Creditoformapagoabonos_Nombre = item.Cliente_pago_parametros?.Creditoformapagoabonos_?.Nombre;

             this._Cliente_pago_parametros_MonedaClave = item.Cliente_pago_parametros?.Moneda?.Clave;

             this._Cliente_pago_parametros_MonedaNombre = item.Cliente_pago_parametros?.Moneda?.Nombre;

             this._Cliente_precio_ListaprecioClave = item.Cliente_precio?.Listaprecio?.Clave;

             this._Cliente_precio_ListaprecioNombre = item.Cliente_precio?.Listaprecio?.Nombre;

             this._Cliente_precio_SuperlistaprecioClave = item.Cliente_precio?.Superlistaprecio?.Clave;

             this._Cliente_precio_SuperlistaprecioNombre = item.Cliente_precio?.Superlistaprecio?.Nombre;

             this._Cliente_rutaembarque_RutaembarqueClave = item.Cliente_rutaembarque?.Rutaembarque?.Clave;

             this._Cliente_rutaembarque_RutaembarqueNombre = item.Cliente_rutaembarque?.Rutaembarque?.Nombre;


        }


        public void FillEntityValues(ref Cliente item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombres = Nombres ;


            item.Apellidos = Apellidos ;


            item.Razonsocial = Razonsocial ;


            item.Rfc = Rfc ;


            item.Telefono1 = Telefono1 ;


            item.Telefono2 = Telefono2 ;


            item.Telefono3 = Telefono3 ;


            item.Celular = Celular ;


            item.Nextel = Nextel ;


            item.Email1 = Email1 ;


            item.Email2 = Email2 ;


            item.Domicilioid = Domicilioid ;


            item.Contacto1id = Contacto1id ;


            item.Contacto2id = Contacto2id ;


            item.Domicilioentregaid = Domicilioentregaid ;


            item.Subtipoclienteid = Subtipoclienteid ;


            item.Proveeclienteid = Proveeclienteid ;


            item.Vigencia = Vigencia;


            item.Firma = Firma;


            item.Email3 = Email3;


            item.Email4 = Email4;



            item.Nombre = Nombre ?? "";


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


            if (item.Domicilio != null)
                item.Domicilio!.Referencia = Domicilio_Referencia;
            else if (item.Domicilio == null && Domicilio_Referencia != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Referencia = Domicilio_Referencia;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Nombre = Contacto1_Nombre;
            else if (item.Contacto1 == null && Contacto1_Nombre != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
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

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Calle = Domicilioentrega_Calle;
            else if (item.Domicilioentrega == null && Domicilioentrega_Calle != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Calle = Domicilioentrega_Calle;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Numeroexterior = Domicilioentrega_Numeroexterior;
            else if (item.Domicilioentrega == null && Domicilioentrega_Numeroexterior != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Numeroexterior = Domicilioentrega_Numeroexterior;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Numerointerior = Domicilioentrega_Numerointerior;
            else if (item.Domicilioentrega == null && Domicilioentrega_Numerointerior != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Numerointerior = Domicilioentrega_Numerointerior;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Colonia = Domicilioentrega_Colonia;
            else if (item.Domicilioentrega == null && Domicilioentrega_Colonia != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Colonia = Domicilioentrega_Colonia;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Ciudad = Domicilioentrega_Ciudad;
            else if (item.Domicilioentrega == null && Domicilioentrega_Ciudad != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Ciudad = Domicilioentrega_Ciudad;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Municipio = Domicilioentrega_Municipio;
            else if (item.Domicilioentrega == null && Domicilioentrega_Municipio != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Municipio = Domicilioentrega_Municipio;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Estado = Domicilioentrega_Estado;
            else if (item.Domicilioentrega == null && Domicilioentrega_Estado != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Estado = Domicilioentrega_Estado;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Pais = Domicilioentrega_Pais;
            else if (item.Domicilioentrega == null && Domicilioentrega_Pais != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Pais = Domicilioentrega_Pais;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Codigopostal = Domicilioentrega_Codigopostal;
            else if (item.Domicilioentrega == null && Domicilioentrega_Codigopostal != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Codigopostal = Domicilioentrega_Codigopostal;
            }

            if (item.Cliente_bancomer != null)
                item.Cliente_bancomer!.Bancomerdoctopendid = Cliente_bancomer_Bancomerdoctopendid;
            else if (item.Cliente_bancomer == null && Cliente_bancomer_Bancomerdoctopendid != null)
            {
                item.Cliente_bancomer = CreateSubEntity<Cliente_bancomer>();
                item.Cliente_bancomer!.Bancomerdoctopendid = Cliente_bancomer_Bancomerdoctopendid;
            }

            if (item.Cliente_comision != null)
                item.Cliente_comision!.Vendedorid = Cliente_comision_Vendedorid;
            else if (item.Cliente_comision == null && Cliente_comision_Vendedorid != null)
            {
                item.Cliente_comision = CreateSubEntity<Cliente_comision>();
                item.Cliente_comision!.Vendedorid = Cliente_comision_Vendedorid;
            }


            if (item.Cliente_comision != null)
                item.Cliente_comision!.Por_come = Cliente_comision_Por_come ?? 0;
            else if (item.Cliente_comision == null && Cliente_comision_Por_come != null)
            {
                item.Cliente_comision = CreateSubEntity<Cliente_comision>();
                item.Cliente_comision!.Por_come = Cliente_comision_Por_come ?? 0;
            }

            if (item.Cliente_comision != null)
                item.Cliente_comision!.Servicioadomicilio = Cliente_comision_Servicioadomicilio;
            else if (item.Cliente_comision == null && Cliente_comision_Servicioadomicilio != null)
            {
                item.Cliente_comision = CreateSubEntity<Cliente_comision>();
                item.Cliente_comision!.Servicioadomicilio = Cliente_comision_Servicioadomicilio;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Generarreciboelectronico = Cliente_fact_elect_Generarreciboelectronico;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Generarreciboelectronico != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Generarreciboelectronico = Cliente_fact_elect_Generarreciboelectronico;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Retieneisr = Cliente_fact_elect_Retieneisr?? BoolCN.N;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Retieneisr != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Retieneisr = Cliente_fact_elect_Retieneisr?? BoolCN.N;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Retieneiva = Cliente_fact_elect_Retieneiva?? BoolCN.N;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Retieneiva != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Retieneiva = Cliente_fact_elect_Retieneiva?? BoolCN.N;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Creditoformapagosatabonos = Cliente_fact_elect_Creditoformapagosatabonos;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Creditoformapagosatabonos != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Creditoformapagosatabonos = Cliente_fact_elect_Creditoformapagosatabonos;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_usocfdiid = Cliente_fact_elect_Sat_usocfdiid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_usocfdiid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_usocfdiid = Cliente_fact_elect_Sat_usocfdiid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_id_pais = Cliente_fact_elect_Sat_id_pais;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_id_pais != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_id_pais = Cliente_fact_elect_Sat_id_pais;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Coloniaid = Cliente_fact_elect_Sat_Coloniaid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Coloniaid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Coloniaid = Cliente_fact_elect_Sat_Coloniaid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Localidadid = Cliente_fact_elect_Sat_Localidadid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Localidadid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Localidadid = Cliente_fact_elect_Sat_Localidadid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Municipioid = Cliente_fact_elect_Sat_Municipioid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Municipioid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Municipioid = Cliente_fact_elect_Sat_Municipioid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Distancia = Cliente_fact_elect_Distancia?? 0;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Distancia != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Distancia = Cliente_fact_elect_Distancia?? 0;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Sat_Coloniaid = Cliente_fact_elect_Entrega_Sat_Coloniaid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Sat_Coloniaid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Sat_Coloniaid = Cliente_fact_elect_Entrega_Sat_Coloniaid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Sat_Localidadid = Cliente_fact_elect_Entrega_Sat_Localidadid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Sat_Localidadid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Sat_Localidadid = Cliente_fact_elect_Entrega_Sat_Localidadid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Sat_Municipioid = Cliente_fact_elect_Entrega_Sat_Municipioid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Sat_Municipioid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Sat_Municipioid = Cliente_fact_elect_Entrega_Sat_Municipioid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Distancia = Cliente_fact_elect_Entrega_Distancia?? 0;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Distancia != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Distancia = Cliente_fact_elect_Entrega_Distancia?? 0;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entregareferenciadom = Cliente_fact_elect_Entregareferenciadom;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entregareferenciadom != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entregareferenciadom = Cliente_fact_elect_Entregareferenciadom;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Regimenfiscalid = Cliente_fact_elect_Sat_Regimenfiscalid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Regimenfiscalid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Regimenfiscalid = Cliente_fact_elect_Sat_Regimenfiscalid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Generacomprobtrasl = Cliente_fact_elect_Generacomprobtrasl;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Generacomprobtrasl != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Generacomprobtrasl = Cliente_fact_elect_Generacomprobtrasl;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Generacartaporte = Cliente_fact_elect_Generacartaporte;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Generacartaporte != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Generacartaporte = Cliente_fact_elect_Generacartaporte;
            }

            if (item.Cliente_ordencompra != null)
                item.Cliente_ordencompra!.Solicitaordencompra = Cliente_ordencompra_Solicitaordencompra?? BoolCN.N;
            else if (item.Cliente_ordencompra == null && Cliente_ordencompra_Solicitaordencompra != null)
            {
                item.Cliente_ordencompra = CreateSubEntity<Cliente_ordencompra>();
                item.Cliente_ordencompra!.Solicitaordencompra = Cliente_ordencompra_Solicitaordencompra?? BoolCN.N;
            }

            if (item.Cliente_pago != null)
                item.Cliente_pago!.Saldo = Cliente_pago_Saldo?? 0;
            else if (item.Cliente_pago == null && Cliente_pago_Saldo != null)
            {
                item.Cliente_pago = CreateSubEntity<Cliente_pago>();
                item.Cliente_pago!.Saldo = Cliente_pago_Saldo?? 0;
            }

            if (item.Cliente_pago != null)
                item.Cliente_pago!.Saldoapartadonegativo = Cliente_pago_Saldoapartadonegativo?? 0;
            else if (item.Cliente_pago == null && Cliente_pago_Saldoapartadonegativo != null)
            {
                item.Cliente_pago = CreateSubEntity<Cliente_pago>();
                item.Cliente_pago!.Saldoapartadonegativo = Cliente_pago_Saldoapartadonegativo?? 0;
            }

            if (item.Cliente_pago != null)
                item.Cliente_pago!.Saldoapartadopositivo = Cliente_pago_Saldoapartadopositivo?? 0;
            else if (item.Cliente_pago == null && Cliente_pago_Saldoapartadopositivo != null)
            {
                item.Cliente_pago = CreateSubEntity<Cliente_pago>();
                item.Cliente_pago!.Saldoapartadopositivo = Cliente_pago_Saldoapartadopositivo?? 0;
            }

            if (item.Cliente_pago != null)
                item.Cliente_pago!.Saldospositivos = Cliente_pago_Saldospositivos?? 0;
            else if (item.Cliente_pago == null && Cliente_pago_Saldospositivos != null)
            {
                item.Cliente_pago = CreateSubEntity<Cliente_pago>();
                item.Cliente_pago!.Saldospositivos = Cliente_pago_Saldospositivos?? 0;
            }

            if (item.Cliente_pago != null)
                item.Cliente_pago!.Saldosnegativos = Cliente_pago_Saldosnegativos?? 0;
            else if (item.Cliente_pago == null && Cliente_pago_Saldosnegativos != null)
            {
                item.Cliente_pago = CreateSubEntity<Cliente_pago>();
                item.Cliente_pago!.Saldosnegativos = Cliente_pago_Saldosnegativos?? 0;
            }

            if (item.Cliente_pago != null)
                item.Cliente_pago!.Ultimaventa = Cliente_pago_Ultimaventa;
            else if (item.Cliente_pago == null && Cliente_pago_Ultimaventa != null)
            {
                item.Cliente_pago = CreateSubEntity<Cliente_pago>();
                item.Cliente_pago!.Ultimaventa = Cliente_pago_Ultimaventa;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagotarjeta = Cliente_pago_parametros_Hab_pagotarjeta?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagotarjeta != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagotarjeta = Cliente_pago_parametros_Hab_pagotarjeta?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagocredito = Cliente_pago_parametros_Hab_pagocredito?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagocredito != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagocredito = Cliente_pago_parametros_Hab_pagocredito?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagocheque = Cliente_pago_parametros_Hab_pagocheque?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagocheque != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagocheque = Cliente_pago_parametros_Hab_pagocheque?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Revision = Cliente_pago_parametros_Revision;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Revision != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Revision = Cliente_pago_parametros_Revision;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Pagos = Cliente_pago_parametros_Pagos;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Pagos != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Pagos = Cliente_pago_parametros_Pagos;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Bloqueado = Cliente_pago_parametros_Bloqueado?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Bloqueado != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Bloqueado = Cliente_pago_parametros_Bloqueado?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagotransferencia = Cliente_pago_parametros_Hab_pagotransferencia?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagotransferencia != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagotransferencia = Cliente_pago_parametros_Hab_pagotransferencia?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagoefectivo = Cliente_pago_parametros_Hab_pagoefectivo?? BoolCS.S;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagoefectivo != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagoefectivo = Cliente_pago_parametros_Hab_pagoefectivo?? BoolCS.S;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Pagoparcialidades = Cliente_pago_parametros_Pagoparcialidades?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Pagoparcialidades != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Pagoparcialidades = Cliente_pago_parametros_Pagoparcialidades?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Creditoreferenciaabonos = Cliente_pago_parametros_Creditoreferenciaabonos;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Creditoreferenciaabonos != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Creditoreferenciaabonos = Cliente_pago_parametros_Creditoreferenciaabonos;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Bloqueonot = Cliente_pago_parametros_Bloqueonot;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Bloqueonot != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Bloqueonot = Cliente_pago_parametros_Bloqueonot;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Exentoiva = Cliente_pago_parametros_Exentoiva?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Exentoiva != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Exentoiva = Cliente_pago_parametros_Exentoiva?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Cargoxventacontarjeta = Cliente_pago_parametros_Cargoxventacontarjeta?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Cargoxventacontarjeta != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Cargoxventacontarjeta = Cliente_pago_parametros_Cargoxventacontarjeta?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Pagotarjmenorpreciolista = Cliente_pago_parametros_Pagotarjmenorpreciolista?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Pagotarjmenorpreciolista != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Pagotarjmenorpreciolista = Cliente_pago_parametros_Pagotarjmenorpreciolista?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Limitecredito = Cliente_pago_parametros_Limitecredito?? 0;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Limitecredito != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Limitecredito = Cliente_pago_parametros_Limitecredito?? 0;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Dias = Cliente_pago_parametros_Dias;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Dias != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Dias = Cliente_pago_parametros_Dias;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Creditoformapagoabonos = Cliente_pago_parametros_Creditoformapagoabonos;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Creditoformapagoabonos != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Creditoformapagoabonos = Cliente_pago_parametros_Creditoformapagoabonos;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Monedaid = Cliente_pago_parametros_Monedaid;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Monedaid != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Monedaid = Cliente_pago_parametros_Monedaid;
            }


            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Dias_extr = Cliente_pago_parametros_Dias_extr;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Dias_extr != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Dias_extr = Cliente_pago_parametros_Dias_extr;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Desgloseieps = Cliente_poliza_Desgloseieps?? BoolCN.N;
            else if (item.Cliente_poliza == null && Cliente_poliza_Desgloseieps != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Desgloseieps = Cliente_poliza_Desgloseieps?? BoolCN.N;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Cuentaieps = Cliente_poliza_Cuentaieps;
            else if (item.Cliente_poliza == null && Cliente_poliza_Cuentaieps != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Cuentaieps = Cliente_poliza_Cuentaieps;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Cuentacontpaq = Cliente_poliza_Cuentacontpaq;
            else if (item.Cliente_poliza == null && Cliente_poliza_Cuentacontpaq != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Cuentacontpaq = Cliente_poliza_Cuentacontpaq;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Separarprodxplazo = Cliente_poliza_Separarprodxplazo?? BoolCN.N;
            else if (item.Cliente_poliza == null && Cliente_poliza_Separarprodxplazo != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Separarprodxplazo = Cliente_poliza_Separarprodxplazo?? BoolCN.N;
            }

            if (item.Cliente_precio != null)
                item.Cliente_precio!.Listaprecioid = Cliente_precio_Listaprecioid;
            else if (item.Cliente_precio == null && Cliente_precio_Listaprecioid != null)
            {
                item.Cliente_precio = CreateSubEntity<Cliente_precio>();
                item.Cliente_precio!.Listaprecioid = Cliente_precio_Listaprecioid;
            }

            if (item.Cliente_precio != null)
                item.Cliente_precio!.Superlistaprecioid = Cliente_precio_Superlistaprecioid;
            else if (item.Cliente_precio == null && Cliente_precio_Superlistaprecioid != null)
            {
                item.Cliente_precio = CreateSubEntity<Cliente_precio>();
                item.Cliente_precio!.Superlistaprecioid = Cliente_precio_Superlistaprecioid;
            }

            if (item.Cliente_precio != null)
                item.Cliente_precio!.Mayoreoxproducto = Cliente_precio_Mayoreoxproducto?? BoolCN.N;
            else if (item.Cliente_precio == null && Cliente_precio_Mayoreoxproducto != null)
            {
                item.Cliente_precio = CreateSubEntity<Cliente_precio>();
                item.Cliente_precio!.Mayoreoxproducto = Cliente_precio_Mayoreoxproducto?? BoolCN.N;
            }

            if (item.Cliente_rutaembarque != null)
                item.Cliente_rutaembarque!.Rutaembarqueid = Cliente_rutaembarque_Rutaembarqueid;
            else if (item.Cliente_rutaembarque == null && Cliente_rutaembarque_Rutaembarqueid != null)
            {
                item.Cliente_rutaembarque = CreateSubEntity<Cliente_rutaembarque>();
                item.Cliente_rutaembarque!.Rutaembarqueid = Cliente_rutaembarque_Rutaembarqueid;
            }


        }

        public void FillFromEntity(Cliente item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombres = item.Nombres;

            Apellidos = item.Apellidos;

            Razonsocial = item.Razonsocial;

            Rfc = item.Rfc;

            Telefono1 = item.Telefono1;

            Telefono2 = item.Telefono2;

            Telefono3 = item.Telefono3;

            Celular = item.Celular;

            Nextel = item.Nextel;

            Email1 = item.Email1;

            Email2 = item.Email2;

            Domicilioid = item.Domicilioid;

            Contacto1id = item.Contacto1id;

            Contacto2id = item.Contacto2id;

            Domicilioentregaid = item.Domicilioentregaid;

            Subtipoclienteid = item.Subtipoclienteid;

            Proveeclienteid = item.Proveeclienteid;

            Vigencia = item.Vigencia;

            Firma = item.Firma;

            Email3 = item.Email3;

            Email4 = item.Email4;

            Nombre = item.Nombre;

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

            if (item.Domicilio != null && item.Domicilio?.Referencia != null)
                Domicilio_Referencia = item.Domicilio!.Referencia;


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

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Calle != null)
                    Domicilioentrega_Calle = item.Domicilioentrega!.Calle;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Numeroexterior != null)
                    Domicilioentrega_Numeroexterior = item.Domicilioentrega!.Numeroexterior;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Numerointerior != null)
                    Domicilioentrega_Numerointerior = item.Domicilioentrega!.Numerointerior;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Colonia != null)
                    Domicilioentrega_Colonia = item.Domicilioentrega!.Colonia;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Ciudad != null)
                    Domicilioentrega_Ciudad = item.Domicilioentrega!.Ciudad;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Municipio != null)
                    Domicilioentrega_Municipio = item.Domicilioentrega!.Municipio;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Estado != null)
                    Domicilioentrega_Estado = item.Domicilioentrega!.Estado;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Pais != null)
                    Domicilioentrega_Pais = item.Domicilioentrega!.Pais;

            if (item.Domicilioentrega != null && item.Domicilioentrega?.Codigopostal != null)
                    Domicilioentrega_Codigopostal = item.Domicilioentrega!.Codigopostal;

            if (item.Cliente_bancomer != null && item.Cliente_bancomer?.Bancomerdoctopendid != null)
                    Cliente_bancomer_Bancomerdoctopendid = item.Cliente_bancomer!.Bancomerdoctopendid;

            if (item.Cliente_comision != null && item.Cliente_comision?.Vendedorid != null)
                    Cliente_comision_Vendedorid = item.Cliente_comision!.Vendedorid;


            if (item.Cliente_comision != null && item.Cliente_comision?.Por_come != null)
                Cliente_comision_Por_come = item.Cliente_comision!.Por_come;

            if (item.Cliente_comision != null && item.Cliente_comision?.Servicioadomicilio != null)
                Cliente_comision_Servicioadomicilio = item.Cliente_comision!.Servicioadomicilio;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Generarreciboelectronico != null)
                    Cliente_fact_elect_Generarreciboelectronico = item.Cliente_fact_elect!.Generarreciboelectronico;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Retieneisr != null)
                    Cliente_fact_elect_Retieneisr = item.Cliente_fact_elect!.Retieneisr;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Retieneiva != null)
                    Cliente_fact_elect_Retieneiva = item.Cliente_fact_elect!.Retieneiva;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Creditoformapagosatabonos != null)
                    Cliente_fact_elect_Creditoformapagosatabonos = item.Cliente_fact_elect!.Creditoformapagosatabonos;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Sat_usocfdiid != null)
                    Cliente_fact_elect_Sat_usocfdiid = item.Cliente_fact_elect!.Sat_usocfdiid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Sat_id_pais != null)
                    Cliente_fact_elect_Sat_id_pais = item.Cliente_fact_elect!.Sat_id_pais;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Sat_Coloniaid != null)
                    Cliente_fact_elect_Sat_Coloniaid = item.Cliente_fact_elect!.Sat_Coloniaid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Sat_Localidadid != null)
                    Cliente_fact_elect_Sat_Localidadid = item.Cliente_fact_elect!.Sat_Localidadid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Sat_Municipioid != null)
                    Cliente_fact_elect_Sat_Municipioid = item.Cliente_fact_elect!.Sat_Municipioid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Distancia != null)
                    Cliente_fact_elect_Distancia = item.Cliente_fact_elect!.Distancia;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Entrega_Sat_Coloniaid != null)
                    Cliente_fact_elect_Entrega_Sat_Coloniaid = item.Cliente_fact_elect!.Entrega_Sat_Coloniaid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Entrega_Sat_Localidadid != null)
                    Cliente_fact_elect_Entrega_Sat_Localidadid = item.Cliente_fact_elect!.Entrega_Sat_Localidadid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Entrega_Sat_Municipioid != null)
                    Cliente_fact_elect_Entrega_Sat_Municipioid = item.Cliente_fact_elect!.Entrega_Sat_Municipioid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Entrega_Distancia != null)
                    Cliente_fact_elect_Entrega_Distancia = item.Cliente_fact_elect!.Entrega_Distancia;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Entregareferenciadom != null)
                    Cliente_fact_elect_Entregareferenciadom = item.Cliente_fact_elect!.Entregareferenciadom;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Sat_Regimenfiscalid != null)
                    Cliente_fact_elect_Sat_Regimenfiscalid = item.Cliente_fact_elect!.Sat_Regimenfiscalid;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Generacomprobtrasl != null)
                Cliente_fact_elect_Generacomprobtrasl = item.Cliente_fact_elect!.Generacomprobtrasl;

            if (item.Cliente_fact_elect != null && item.Cliente_fact_elect?.Generacartaporte != null)
                Cliente_fact_elect_Generacartaporte = item.Cliente_fact_elect!.Generacartaporte;

            if (item.Cliente_ordencompra != null && item.Cliente_ordencompra?.Solicitaordencompra != null)
                    Cliente_ordencompra_Solicitaordencompra = item.Cliente_ordencompra!.Solicitaordencompra;

            if (item.Cliente_pago != null && item.Cliente_pago?.Saldo != null)
                    Cliente_pago_Saldo = item.Cliente_pago!.Saldo;

            if (item.Cliente_pago != null && item.Cliente_pago?.Saldoapartadonegativo != null)
                    Cliente_pago_Saldoapartadonegativo = item.Cliente_pago!.Saldoapartadonegativo;

            if (item.Cliente_pago != null && item.Cliente_pago?.Saldoapartadopositivo != null)
                    Cliente_pago_Saldoapartadopositivo = item.Cliente_pago!.Saldoapartadopositivo;

            if (item.Cliente_pago != null && item.Cliente_pago?.Saldospositivos != null)
                    Cliente_pago_Saldospositivos = item.Cliente_pago!.Saldospositivos;

            if (item.Cliente_pago != null && item.Cliente_pago?.Saldosnegativos != null)
                    Cliente_pago_Saldosnegativos = item.Cliente_pago!.Saldosnegativos;

            if (item.Cliente_pago != null && item.Cliente_pago?.Ultimaventa != null)
                    Cliente_pago_Ultimaventa = item.Cliente_pago!.Ultimaventa;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Hab_pagotarjeta != null)
                    Cliente_pago_parametros_Hab_pagotarjeta = item.Cliente_pago_parametros!.Hab_pagotarjeta;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Hab_pagocredito != null)
                    Cliente_pago_parametros_Hab_pagocredito = item.Cliente_pago_parametros!.Hab_pagocredito;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Hab_pagocheque != null)
                    Cliente_pago_parametros_Hab_pagocheque = item.Cliente_pago_parametros!.Hab_pagocheque;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Revision != null)
                    Cliente_pago_parametros_Revision = item.Cliente_pago_parametros!.Revision;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Pagos != null)
                    Cliente_pago_parametros_Pagos = item.Cliente_pago_parametros!.Pagos;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Bloqueado != null)
                    Cliente_pago_parametros_Bloqueado = item.Cliente_pago_parametros!.Bloqueado;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Hab_pagotransferencia != null)
                    Cliente_pago_parametros_Hab_pagotransferencia = item.Cliente_pago_parametros!.Hab_pagotransferencia;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Hab_pagoefectivo != null)
                    Cliente_pago_parametros_Hab_pagoefectivo = item.Cliente_pago_parametros!.Hab_pagoefectivo;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Pagoparcialidades != null)
                    Cliente_pago_parametros_Pagoparcialidades = item.Cliente_pago_parametros!.Pagoparcialidades;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Creditoreferenciaabonos != null)
                    Cliente_pago_parametros_Creditoreferenciaabonos = item.Cliente_pago_parametros!.Creditoreferenciaabonos;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Bloqueonot != null)
                    Cliente_pago_parametros_Bloqueonot = item.Cliente_pago_parametros!.Bloqueonot;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Exentoiva != null)
                    Cliente_pago_parametros_Exentoiva = item.Cliente_pago_parametros!.Exentoiva;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Cargoxventacontarjeta != null)
                    Cliente_pago_parametros_Cargoxventacontarjeta = item.Cliente_pago_parametros!.Cargoxventacontarjeta;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Pagotarjmenorpreciolista != null)
                    Cliente_pago_parametros_Pagotarjmenorpreciolista = item.Cliente_pago_parametros!.Pagotarjmenorpreciolista;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Limitecredito != null)
                    Cliente_pago_parametros_Limitecredito = item.Cliente_pago_parametros!.Limitecredito;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Dias != null)
                    Cliente_pago_parametros_Dias = item.Cliente_pago_parametros!.Dias;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Creditoformapagoabonos != null)
                    Cliente_pago_parametros_Creditoformapagoabonos = item.Cliente_pago_parametros!.Creditoformapagoabonos;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Monedaid != null)
                    Cliente_pago_parametros_Monedaid = item.Cliente_pago_parametros!.Monedaid;

            if (item.Cliente_pago_parametros != null && item.Cliente_pago_parametros?.Dias_extr != null)
                Cliente_pago_parametros_Dias_extr = item.Cliente_pago_parametros!.Dias_extr;

            if (item.Cliente_poliza != null && item.Cliente_poliza?.Desgloseieps != null)
                    Cliente_poliza_Desgloseieps = item.Cliente_poliza!.Desgloseieps;

            if (item.Cliente_poliza != null && item.Cliente_poliza?.Cuentaieps != null)
                    Cliente_poliza_Cuentaieps = item.Cliente_poliza!.Cuentaieps;

            if (item.Cliente_poliza != null && item.Cliente_poliza?.Cuentacontpaq != null)
                    Cliente_poliza_Cuentacontpaq = item.Cliente_poliza!.Cuentacontpaq;

            if (item.Cliente_poliza != null && item.Cliente_poliza?.Separarprodxplazo != null)
                    Cliente_poliza_Separarprodxplazo = item.Cliente_poliza!.Separarprodxplazo;

            if (item.Cliente_precio != null && item.Cliente_precio?.Listaprecioid != null)
                    Cliente_precio_Listaprecioid = item.Cliente_precio!.Listaprecioid;

            if (item.Cliente_precio != null && item.Cliente_precio?.Superlistaprecioid != null)
                    Cliente_precio_Superlistaprecioid = item.Cliente_precio!.Superlistaprecioid;

            if (item.Cliente_precio != null && item.Cliente_precio?.Mayoreoxproducto != null)
                    Cliente_precio_Mayoreoxproducto = item.Cliente_precio!.Mayoreoxproducto;

            if (item.Cliente_rutaembarque != null && item.Cliente_rutaembarque?.Rutaembarqueid != null)
                    Cliente_rutaembarque_Rutaembarqueid = item.Cliente_rutaembarque!.Rutaembarqueid;


             FillCatalogRelatedFields(item);


        }
        #endif






    }
}

