
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
    
    public class Perfil_derBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public Perfil_derBindingModelGenerated()
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

        private long? _Perfilid;
        [XmlAttribute]
        public long? Perfilid { get => _Perfilid; set { if (RaiseAcceptPendingChange(value, _Perfilid)) { _Perfilid = value; OnPropertyChanged(); } } }

        private string? _PerfilClave;
        [XmlAttribute]
        public string? PerfilClave { get => _PerfilClave; set { if (RaiseAcceptPendingChange(value, _PerfilClave)) { _PerfilClave = value; OnPropertyChanged(); } } }

        private string? _PerfilNombre;
        [XmlAttribute]
        public string? PerfilNombre { get => _PerfilNombre; set { if (RaiseAcceptPendingChange(value, _PerfilNombre)) { _PerfilNombre = value; OnPropertyChanged(); } } }

        private long? _Derechoid;
        [XmlAttribute]
        public long? Derechoid { get => _Derechoid; set { if (RaiseAcceptPendingChange(value, _Derechoid)) { _Derechoid = value; OnPropertyChanged(); } } }

        private string? _DerechoClave;
        [XmlAttribute]
        public string? DerechoClave { get => _DerechoClave; set { if (RaiseAcceptPendingChange(value, _DerechoClave)) { _DerechoClave = value; OnPropertyChanged(); } } }

        private string? _DerechoNombre;
        [XmlAttribute]
        public string? DerechoNombre { get => _DerechoNombre; set { if (RaiseAcceptPendingChange(value, _DerechoNombre)) { _DerechoNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Perfil_der"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Perfil.Clave|Perfil.Nombre|Derecho.Clave|Derecho.Nombre";
        }






    }
}

