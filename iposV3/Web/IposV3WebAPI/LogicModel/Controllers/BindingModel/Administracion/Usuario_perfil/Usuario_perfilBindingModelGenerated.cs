
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
    
    public class Usuario_perfilBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public Usuario_perfilBindingModelGenerated()
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

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private string? _UsuarioClave;
        [XmlAttribute]
        public string? UsuarioClave { get => _UsuarioClave; set { if (RaiseAcceptPendingChange(value, _UsuarioClave)) { _UsuarioClave = value; OnPropertyChanged(); } } }

        private string? _UsuarioNombre;
        [XmlAttribute]
        public string? UsuarioNombre { get => _UsuarioNombre; set { if (RaiseAcceptPendingChange(value, _UsuarioNombre)) { _UsuarioNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Usuario_perfil"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Perfil.Clave|Perfil.Nombre|Usuario.Clave|Usuario.Nombre";
        }




    }
}

