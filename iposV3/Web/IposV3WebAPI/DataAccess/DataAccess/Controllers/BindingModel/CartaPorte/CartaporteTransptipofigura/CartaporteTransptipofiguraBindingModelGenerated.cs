
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
    
    public class CartaporteTransptipofiguraBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CartaporteTransptipofiguraBindingModelGenerated()
        {
        }
        public CartaporteTransptipofiguraBindingModelGenerated(CartaporteTransptipofigura item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
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

        private string? _Tipofigura;
        [XmlAttribute]
        public string? Tipofigura { get => _Tipofigura; set { if (RaiseAcceptPendingChange(value, _Tipofigura)) { _Tipofigura = value; OnPropertyChanged(); } } }

        private string? _Rfcfigura;
        [XmlAttribute]
        public string? Rfcfigura { get => _Rfcfigura; set { if (RaiseAcceptPendingChange(value, _Rfcfigura)) { _Rfcfigura = value; OnPropertyChanged(); } } }

        private string? _Numlicencia;
        [XmlAttribute]
        public string? Numlicencia { get => _Numlicencia; set { if (RaiseAcceptPendingChange(value, _Numlicencia)) { _Numlicencia = value; OnPropertyChanged(); } } }

        private string? _Nombrefigura;
        [XmlAttribute]
        public string? Nombrefigura { get => _Nombrefigura; set { if (RaiseAcceptPendingChange(value, _Nombrefigura)) { _Nombrefigura = value; OnPropertyChanged(); } } }

        private string? _Numregidtribfigura;
        [XmlAttribute]
        public string? Numregidtribfigura { get => _Numregidtribfigura; set { if (RaiseAcceptPendingChange(value, _Numregidtribfigura)) { _Numregidtribfigura = value; OnPropertyChanged(); } } }

        private string? _Residenciafiscalfigura;
        [XmlAttribute]
        public string? Residenciafiscalfigura { get => _Residenciafiscalfigura; set { if (RaiseAcceptPendingChange(value, _Residenciafiscalfigura)) { _Residenciafiscalfigura = value; OnPropertyChanged(); } } }

        private string? _Partetransporte;
        [XmlAttribute]
        public string? Partetransporte { get => _Partetransporte; set { if (RaiseAcceptPendingChange(value, _Partetransporte)) { _Partetransporte = value; OnPropertyChanged(); } } }

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

            return $@"SELECT * FROM ""CartaporteTransptipofigura"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Cartaporte.Clave|Cartaporte.Nombre|Tipofigura|Rfcfigura|Numlicencia|Nombrefigura|Numregidtribfigura|Residenciafiscalfigura|Partetransporte|Calle|Numeroexterior|Numerointerior|Colonia|Localidad|Referencia|Municipio|Estado|Pais|Codigopostal";
        }


        public void FillCatalogRelatedFields(CartaporteTransptipofigura item)
        {

             this._CartaporteClave = item.Cartaporte?.Clave;

             this._CartaporteNombre = item.Cartaporte?.Nombre;


        }


        public void FillEntityValues(ref CartaporteTransptipofigura item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Cartaporteid = Cartaporteid ;


            item.Tipofigura = Tipofigura ;


            item.Rfcfigura = Rfcfigura ;


            item.Numlicencia = Numlicencia ;


            item.Nombrefigura = Nombrefigura ;


            item.Numregidtribfigura = Numregidtribfigura ;


            item.Residenciafiscalfigura = Residenciafiscalfigura ;


            item.Partetransporte = Partetransporte ;


            item.Calle = Calle ;


            item.Numeroexterior = Numeroexterior ;


            item.Numerointerior = Numerointerior ;


            item.Colonia = Colonia ;


            item.Localidad = Localidad ;


            item.Referencia = Referencia ;


            item.Municipio = Municipio ;


            item.Estado = Estado ;


            item.Pais = Pais ;


            item.Codigopostal = Codigopostal ;



        }

        public void FillFromEntity(CartaporteTransptipofigura item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Cartaporteid = item.Cartaporteid;

            Tipofigura = item.Tipofigura;

            Rfcfigura = item.Rfcfigura;

            Numlicencia = item.Numlicencia;

            Nombrefigura = item.Nombrefigura;

            Numregidtribfigura = item.Numregidtribfigura;

            Residenciafiscalfigura = item.Residenciafiscalfigura;

            Partetransporte = item.Partetransporte;

            Calle = item.Calle;

            Numeroexterior = item.Numeroexterior;

            Numerointerior = item.Numerointerior;

            Colonia = item.Colonia;

            Localidad = item.Localidad;

            Referencia = item.Referencia;

            Municipio = item.Municipio;

            Estado = item.Estado;

            Pais = item.Pais;

            Codigopostal = item.Codigopostal;


             FillCatalogRelatedFields(item);


        }



    }
}

