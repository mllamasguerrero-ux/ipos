
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
    
    public class CartaporteAutotranspBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CartaporteAutotranspBindingModelGenerated()
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

        private string? _TranspInternac;
        [XmlAttribute]
        public string? TranspInternac { get => _TranspInternac; set { if (RaiseAcceptPendingChange(value, _TranspInternac)) { _TranspInternac = value; OnPropertyChanged(); } } }

        private string? _Permsct;
        [XmlAttribute]
        public string? Permsct { get => _Permsct; set { if (RaiseAcceptPendingChange(value, _Permsct)) { _Permsct = value; OnPropertyChanged(); } } }

        private string? _Numpermisosct;
        [XmlAttribute]
        public string? Numpermisosct { get => _Numpermisosct; set { if (RaiseAcceptPendingChange(value, _Numpermisosct)) { _Numpermisosct = value; OnPropertyChanged(); } } }

        private string? _Configvehicular;
        [XmlAttribute]
        public string? Configvehicular { get => _Configvehicular; set { if (RaiseAcceptPendingChange(value, _Configvehicular)) { _Configvehicular = value; OnPropertyChanged(); } } }

        private string? _Placavm;
        [XmlAttribute]
        public string? Placavm { get => _Placavm; set { if (RaiseAcceptPendingChange(value, _Placavm)) { _Placavm = value; OnPropertyChanged(); } } }

        private string? _Aniomodelovm;
        [XmlAttribute]
        public string? Aniomodelovm { get => _Aniomodelovm; set { if (RaiseAcceptPendingChange(value, _Aniomodelovm)) { _Aniomodelovm = value; OnPropertyChanged(); } } }

        private string? _Asegurarespcivil;
        [XmlAttribute]
        public string? Asegurarespcivil { get => _Asegurarespcivil; set { if (RaiseAcceptPendingChange(value, _Asegurarespcivil)) { _Asegurarespcivil = value; OnPropertyChanged(); } } }

        private string? _Polizarespcivil;
        [XmlAttribute]
        public string? Polizarespcivil { get => _Polizarespcivil; set { if (RaiseAcceptPendingChange(value, _Polizarespcivil)) { _Polizarespcivil = value; OnPropertyChanged(); } } }

        private string? _Aseguramedambiente;
        [XmlAttribute]
        public string? Aseguramedambiente { get => _Aseguramedambiente; set { if (RaiseAcceptPendingChange(value, _Aseguramedambiente)) { _Aseguramedambiente = value; OnPropertyChanged(); } } }

        private string? _Polizamedambiente;
        [XmlAttribute]
        public string? Polizamedambiente { get => _Polizamedambiente; set { if (RaiseAcceptPendingChange(value, _Polizamedambiente)) { _Polizamedambiente = value; OnPropertyChanged(); } } }

        private string? _Aseguracarga;
        [XmlAttribute]
        public string? Aseguracarga { get => _Aseguracarga; set { if (RaiseAcceptPendingChange(value, _Aseguracarga)) { _Aseguracarga = value; OnPropertyChanged(); } } }

        private string? _Polizacarga;
        [XmlAttribute]
        public string? Polizacarga { get => _Polizacarga; set { if (RaiseAcceptPendingChange(value, _Polizacarga)) { _Polizacarga = value; OnPropertyChanged(); } } }

        private string? _Primaseguro;
        [XmlAttribute]
        public string? Primaseguro { get => _Primaseguro; set { if (RaiseAcceptPendingChange(value, _Primaseguro)) { _Primaseguro = value; OnPropertyChanged(); } } }

        private string? _Subtiporem1;
        [XmlAttribute]
        public string? Subtiporem1 { get => _Subtiporem1; set { if (RaiseAcceptPendingChange(value, _Subtiporem1)) { _Subtiporem1 = value; OnPropertyChanged(); } } }

        private string? _Placa1;
        [XmlAttribute]
        public string? Placa1 { get => _Placa1; set { if (RaiseAcceptPendingChange(value, _Placa1)) { _Placa1 = value; OnPropertyChanged(); } } }

        private string? _Subtiporem2;
        [XmlAttribute]
        public string? Subtiporem2 { get => _Subtiporem2; set { if (RaiseAcceptPendingChange(value, _Subtiporem2)) { _Subtiporem2 = value; OnPropertyChanged(); } } }

        private string? _Placa2;
        [XmlAttribute]
        public string? Placa2 { get => _Placa2; set { if (RaiseAcceptPendingChange(value, _Placa2)) { _Placa2 = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""CartaporteAutotransp"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Cartaporte.Clave|Cartaporte.Nombre|TranspInternac|Permsct|Numpermisosct|Configvehicular|Placavm|Aniomodelovm|Asegurarespcivil|Polizarespcivil|Aseguramedambiente|Polizamedambiente|Aseguracarga|Polizacarga|Primaseguro|Subtiporem1|Placa1|Subtiporem2|Placa2";
        }





    }
}

