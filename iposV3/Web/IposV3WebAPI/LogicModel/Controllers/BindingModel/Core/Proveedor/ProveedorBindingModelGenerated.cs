
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
    
    public class ProveedorBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ProveedorBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public ProveedorBindingModelGenerated(Proveedor item)
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



        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedorClave;
        [XmlAttribute]
        public string? VendedorClave { get => _VendedorClave; set { if (RaiseAcceptPendingChange(value, _VendedorClave)) { _VendedorClave = value; OnPropertyChanged(); } } }

        private string? _VendedorNombre;
        [XmlAttribute]
        public string? VendedorNombre { get => _VendedorNombre; set { if (RaiseAcceptPendingChange(value, _VendedorNombre)) { _VendedorNombre = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

        private string? _ListaprecioClave;
        [XmlAttribute]
        public string? ListaprecioClave { get => _ListaprecioClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioClave)) { _ListaprecioClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioNombre;
        [XmlAttribute]
        public string? ListaprecioNombre { get => _ListaprecioNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioNombre)) { _ListaprecioNombre = value; OnPropertyChanged(); } } }

        private long? _Saludoid;
        [XmlAttribute]
        public long? Saludoid { get => _Saludoid; set { if (RaiseAcceptPendingChange(value, _Saludoid)) { _Saludoid = value; OnPropertyChanged(); } } }

        private string? _SaludoClave;
        [XmlAttribute]
        public string? SaludoClave { get => _SaludoClave; set { if (RaiseAcceptPendingChange(value, _SaludoClave)) { _SaludoClave = value; OnPropertyChanged(); } } }

        private string? _SaludoNombre;
        [XmlAttribute]
        public string? SaludoNombre { get => _SaludoNombre; set { if (RaiseAcceptPendingChange(value, _SaludoNombre)) { _SaludoNombre = value; OnPropertyChanged(); } } }


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

        private long? _Proveeclienteid;
        [XmlAttribute]
        public long? Proveeclienteid { get => _Proveeclienteid; set { if (RaiseAcceptPendingChange(value, _Proveeclienteid)) { _Proveeclienteid = value; OnPropertyChanged(); } } }

        private string? _ProveeclienteClave;
        [XmlAttribute]
        public string? ProveeclienteClave { get => _ProveeclienteClave; set { if (RaiseAcceptPendingChange(value, _ProveeclienteClave)) { _ProveeclienteClave = value; OnPropertyChanged(); } } }

        private string? _ProveeclienteNombre;
        [XmlAttribute]
        public string? ProveeclienteNombre { get => _ProveeclienteNombre; set { if (RaiseAcceptPendingChange(value, _ProveeclienteNombre)) { _ProveeclienteNombre = value; OnPropertyChanged(); } } }

        private decimal? _Proveedor_pago_Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Proveedor_pago_Saldo { get => _Proveedor_pago_Saldo?? 0; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_Saldo)) { _Proveedor_pago_Saldo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Proveedor_pago_Saldospositivos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Proveedor_pago_Saldospositivos { get => _Proveedor_pago_Saldospositivos?? 0; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_Saldospositivos)) { _Proveedor_pago_Saldospositivos = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Proveedor_pago_Saldosnegativos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Proveedor_pago_Saldosnegativos { get => _Proveedor_pago_Saldosnegativos?? 0; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_Saldosnegativos)) { _Proveedor_pago_Saldosnegativos = value?? 0; OnPropertyChanged(); } } }

        private string? _Proveedor_pago_parametros_Revision;
        [XmlAttribute]
        public string? Proveedor_pago_parametros_Revision { get => _Proveedor_pago_parametros_Revision; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_parametros_Revision)) { _Proveedor_pago_parametros_Revision = value; OnPropertyChanged(); } } }

        private string? _Proveedor_pago_parametros_Pagos;
        [XmlAttribute]
        public string? Proveedor_pago_parametros_Pagos { get => _Proveedor_pago_parametros_Pagos; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_parametros_Pagos)) { _Proveedor_pago_parametros_Pagos = value; OnPropertyChanged(); } } }

        private int? _Proveedor_pago_parametros_Dias;
        [XmlAttribute]
        public int? Proveedor_pago_parametros_Dias { get => _Proveedor_pago_parametros_Dias; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_parametros_Dias)) { _Proveedor_pago_parametros_Dias = value; OnPropertyChanged(); } } }

        private decimal? _Proveedor_pago_parametros_Adescpes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Proveedor_pago_parametros_Adescpes { get => _Proveedor_pago_parametros_Adescpes?? 0; set { if (RaiseAcceptPendingChange(value, _Proveedor_pago_parametros_Adescpes)) { _Proveedor_pago_parametros_Adescpes = value?? 0; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private BoolCN? _Esimportador;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esimportador { get => _Esimportador?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esimportador)) { _Esimportador = value?? BoolCN.N; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Proveedor"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombres|Apellidos|Razonsocial|Rfc|Telefono1|Telefono2|Telefono3|Celular|Nextel|Email1|Email2|Contacto1.Nombre|Contacto1.Email|Contacto1.Telefono1|Contacto1.Domicilio.Calle|Contacto1.Domicilio.Numeroexterior|Contacto1.Domicilio.Numerointerior|Contacto1.Domicilio.Colonia|Contacto1.Domicilio.Ciudad|Contacto1.Domicilio.Municipio|Contacto1.Domicilio.Estado|Contacto1.Domicilio.Pais|Contacto1.Domicilio.Codigopostal|Contacto2.Nombre|Contacto2.Email|Contacto2.Telefono1|Contacto2.Domicilio.Calle|Contacto2.Domicilio.Numeroexterior|Contacto2.Domicilio.Numerointerior|Contacto2.Domicilio.Colonia|Contacto2.Domicilio.Ciudad|Contacto2.Domicilio.Municipio|Contacto2.Domicilio.Estado|Contacto2.Domicilio.Pais|Contacto2.Domicilio.Codigopostal|Domicilio.Calle|Domicilio.Numeroexterior|Domicilio.Numerointerior|Domicilio.Colonia|Domicilio.Ciudad|Domicilio.Municipio|Domicilio.Estado|Domicilio.Pais|Domicilio.Codigopostal|Proveecliente.Clave|Proveecliente.Nombre|Proveedor_pago_parametros.Revision|Proveedor_pago_parametros.Pagos|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Proveedor item)
        {

             this._ProveeclienteClave = item.Proveecliente?.Clave;

             this._ProveeclienteNombre = item.Proveecliente?.Nombre;


            this._VendedorClave = item.Vendedor?.Clave;

            this._VendedorNombre = item.Vendedor?.Nombre;

            this._ListaprecioClave = item.Listaprecio?.Clave;

            this._ListaprecioNombre = item.Listaprecio?.Nombre;

            this._SaludoClave = item.Saludo?.Clave;

            this._SaludoNombre = item.Saludo?.Nombre;


        }


        public void FillEntityValues(ref Proveedor item)
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



            item.Vendedorid = Vendedorid;


            item.Listaprecioid = Listaprecioid;


            item.Saludoid = Saludoid;


            item.Contacto1id = Contacto1id ;


            item.Contacto2id = Contacto2id ;


            item.Domicilioid = Domicilioid ;


            item.Proveeclienteid = Proveeclienteid ;


            item.Nombre = Nombre ?? "";


            item.Esimportador = Esimportador ?? BoolCN.N;


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

            if (item.Proveedor_pago != null)
                item.Proveedor_pago!.Saldo = Proveedor_pago_Saldo?? 0;
            else if (item.Proveedor_pago == null && Proveedor_pago_Saldo != null)
            {
                item.Proveedor_pago = CreateSubEntity<Proveedor_pago>();
                item.Proveedor_pago!.Saldo = Proveedor_pago_Saldo?? 0;
            }

            if (item.Proveedor_pago != null)
                item.Proveedor_pago!.Saldospositivos = Proveedor_pago_Saldospositivos?? 0;
            else if (item.Proveedor_pago == null && Proveedor_pago_Saldospositivos != null)
            {
                item.Proveedor_pago = CreateSubEntity<Proveedor_pago>();
                item.Proveedor_pago!.Saldospositivos = Proveedor_pago_Saldospositivos?? 0;
            }

            if (item.Proveedor_pago != null)
                item.Proveedor_pago!.Saldosnegativos = Proveedor_pago_Saldosnegativos?? 0;
            else if (item.Proveedor_pago == null && Proveedor_pago_Saldosnegativos != null)
            {
                item.Proveedor_pago = CreateSubEntity<Proveedor_pago>();
                item.Proveedor_pago!.Saldosnegativos = Proveedor_pago_Saldosnegativos?? 0;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Revision = Proveedor_pago_parametros_Revision;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Revision != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Revision = Proveedor_pago_parametros_Revision;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Pagos = Proveedor_pago_parametros_Pagos;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Pagos != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Pagos = Proveedor_pago_parametros_Pagos;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Dias = Proveedor_pago_parametros_Dias;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Dias != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Dias = Proveedor_pago_parametros_Dias;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Adescpes = Proveedor_pago_parametros_Adescpes?? 0;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Adescpes != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Adescpes = Proveedor_pago_parametros_Adescpes?? 0;
            }


        }

        public void FillFromEntity(Proveedor item)
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

            Contacto1id = item.Contacto1id;

            Contacto2id = item.Contacto2id;

            Domicilioid = item.Domicilioid;

            Proveeclienteid = item.Proveeclienteid;

            Vendedorid = item.Vendedorid;

            Listaprecioid = item.Listaprecioid;

            Saludoid = item.Saludoid;

            Nombre = item.Nombre;

            Esimportador = item.Esimportador;

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

            if (item.Proveedor_pago != null && item.Proveedor_pago?.Saldo != null)
                    Proveedor_pago_Saldo = item.Proveedor_pago!.Saldo;

            if (item.Proveedor_pago != null && item.Proveedor_pago?.Saldospositivos != null)
                    Proveedor_pago_Saldospositivos = item.Proveedor_pago!.Saldospositivos;

            if (item.Proveedor_pago != null && item.Proveedor_pago?.Saldosnegativos != null)
                    Proveedor_pago_Saldosnegativos = item.Proveedor_pago!.Saldosnegativos;

            if (item.Proveedor_pago_parametros != null && item.Proveedor_pago_parametros?.Revision != null)
                    Proveedor_pago_parametros_Revision = item.Proveedor_pago_parametros!.Revision;

            if (item.Proveedor_pago_parametros != null && item.Proveedor_pago_parametros?.Pagos != null)
                    Proveedor_pago_parametros_Pagos = item.Proveedor_pago_parametros!.Pagos;

            if (item.Proveedor_pago_parametros != null && item.Proveedor_pago_parametros?.Dias != null)
                    Proveedor_pago_parametros_Dias = item.Proveedor_pago_parametros!.Dias;

            if (item.Proveedor_pago_parametros != null && item.Proveedor_pago_parametros?.Adescpes != null)
                    Proveedor_pago_parametros_Adescpes = item.Proveedor_pago_parametros!.Adescpes;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

