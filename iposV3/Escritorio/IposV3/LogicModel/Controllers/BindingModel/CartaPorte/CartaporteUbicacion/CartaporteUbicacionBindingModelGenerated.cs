
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
    
    public class CartaporteUbicacionBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CartaporteUbicacionBindingModelGenerated()
        {
        }



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

        private long? _Cartaporteid;
        [XmlAttribute]
        public long? Cartaporteid { get => _Cartaporteid; set { if (RaiseAcceptPendingChange(value, _Cartaporteid)) { _Cartaporteid = value; OnPropertyChanged(); } } }

        private string? _CartaporteClave;
        [XmlAttribute]
        public string? CartaporteClave { get => _CartaporteClave; set { if (RaiseAcceptPendingChange(value, _CartaporteClave)) { _CartaporteClave = value; OnPropertyChanged(); } } }

        private string? _CartaporteNombre;
        [XmlAttribute]
        public string? CartaporteNombre { get => _CartaporteNombre; set { if (RaiseAcceptPendingChange(value, _CartaporteNombre)) { _CartaporteNombre = value; OnPropertyChanged(); } } }

        private string? _Tipoubicacion;
        [XmlAttribute]
        public string? Tipoubicacion { get => _Tipoubicacion; set { if (RaiseAcceptPendingChange(value, _Tipoubicacion)) { _Tipoubicacion = value; OnPropertyChanged(); } } }

        private string? _Idubicacion;
        [XmlAttribute]
        public string? Idubicacion { get => _Idubicacion; set { if (RaiseAcceptPendingChange(value, _Idubicacion)) { _Idubicacion = value; OnPropertyChanged(); } } }

        private string? _Rfcremitentedestinatario;
        [XmlAttribute]
        public string? Rfcremitentedestinatario { get => _Rfcremitentedestinatario; set { if (RaiseAcceptPendingChange(value, _Rfcremitentedestinatario)) { _Rfcremitentedestinatario = value; OnPropertyChanged(); } } }

        private string? _Nombreremitentedestinatario;
        [XmlAttribute]
        public string? Nombreremitentedestinatario { get => _Nombreremitentedestinatario; set { if (RaiseAcceptPendingChange(value, _Nombreremitentedestinatario)) { _Nombreremitentedestinatario = value; OnPropertyChanged(); } } }

        private string? _Numregidtrib;
        [XmlAttribute]
        public string? Numregidtrib { get => _Numregidtrib; set { if (RaiseAcceptPendingChange(value, _Numregidtrib)) { _Numregidtrib = value; OnPropertyChanged(); } } }

        private string? _Residenciafiscal;
        [XmlAttribute]
        public string? Residenciafiscal { get => _Residenciafiscal; set { if (RaiseAcceptPendingChange(value, _Residenciafiscal)) { _Residenciafiscal = value; OnPropertyChanged(); } } }

        private string? _Numestacion;
        [XmlAttribute]
        public string? Numestacion { get => _Numestacion; set { if (RaiseAcceptPendingChange(value, _Numestacion)) { _Numestacion = value; OnPropertyChanged(); } } }

        private string? _Nombreestacion;
        [XmlAttribute]
        public string? Nombreestacion { get => _Nombreestacion; set { if (RaiseAcceptPendingChange(value, _Nombreestacion)) { _Nombreestacion = value; OnPropertyChanged(); } } }

        private string? _Navegaciontrafico;
        [XmlAttribute]
        public string? Navegaciontrafico { get => _Navegaciontrafico; set { if (RaiseAcceptPendingChange(value, _Navegaciontrafico)) { _Navegaciontrafico = value; OnPropertyChanged(); } } }

        private string? _Fechahorasalidallegada;
        [XmlAttribute]
        public string? Fechahorasalidallegada { get => _Fechahorasalidallegada; set { if (RaiseAcceptPendingChange(value, _Fechahorasalidallegada)) { _Fechahorasalidallegada = value; OnPropertyChanged(); } } }

        private string? _Tipoestacion;
        [XmlAttribute]
        public string? Tipoestacion { get => _Tipoestacion; set { if (RaiseAcceptPendingChange(value, _Tipoestacion)) { _Tipoestacion = value; OnPropertyChanged(); } } }

        private string? _Distanciarecorrida;
        [XmlAttribute]
        public string? Distanciarecorrida { get => _Distanciarecorrida; set { if (RaiseAcceptPendingChange(value, _Distanciarecorrida)) { _Distanciarecorrida = value; OnPropertyChanged(); } } }

        private string? _Calle;
        [XmlAttribute]
        public string? Calle { get => _Calle; set { if (RaiseAcceptPendingChange(value, _Calle)) { _Calle = value; OnPropertyChanged(); } } }

        private string? _Numeroexterior;
        [XmlAttribute]
        public string? Numeroexterior { get => _Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Numeroexterior)) { _Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Numerointerior;
        [XmlAttribute]
        public string? Numerointerior { get => _Numerointerior; set { if (RaiseAcceptPendingChange(value, _Numerointerior)) { _Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Colonia;
        [XmlAttribute]
        public string? Colonia { get => _Colonia; set { if (RaiseAcceptPendingChange(value, _Colonia)) { _Colonia = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private string? _Municipio;
        [XmlAttribute]
        public string? Municipio { get => _Municipio; set { if (RaiseAcceptPendingChange(value, _Municipio)) { _Municipio = value; OnPropertyChanged(); } } }

        private string? _Estado;
        [XmlAttribute]
        public string? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private string? _Pais;
        [XmlAttribute]
        public string? Pais { get => _Pais; set { if (RaiseAcceptPendingChange(value, _Pais)) { _Pais = value; OnPropertyChanged(); } } }

        private string? _Codigopostal;
        [XmlAttribute]
        public string? Codigopostal { get => _Codigopostal; set { if (RaiseAcceptPendingChange(value, _Codigopostal)) { _Codigopostal = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""CartaporteUbicacion"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Cartaporte.Clave|Cartaporte.Nombre|Tipoubicacion|Idubicacion|Rfcremitentedestinatario|Nombreremitentedestinatario|Numregidtrib|Residenciafiscal|Numestacion|Nombreestacion|Navegaciontrafico|Fechahorasalidallegada|Tipoestacion|Distanciarecorrida|Calle|Numeroexterior|Numerointerior|Colonia|Localidad|Referencia|Municipio|Estado|Pais|Codigopostal";
        }




    }
}

