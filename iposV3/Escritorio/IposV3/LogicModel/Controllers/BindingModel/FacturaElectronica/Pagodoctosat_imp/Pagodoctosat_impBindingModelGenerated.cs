
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
    
    public class Pagodoctosat_impBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public Pagodoctosat_impBindingModelGenerated()
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

        private long? _Pagodoctosatid;
        [XmlAttribute]
        public long? Pagodoctosatid { get => _Pagodoctosatid; set { if (RaiseAcceptPendingChange(value, _Pagodoctosatid)) { _Pagodoctosatid = value; OnPropertyChanged(); } } }

        private string? _PagodoctosatClave;
        [XmlAttribute]
        public string? PagodoctosatClave { get => _PagodoctosatClave; set { if (RaiseAcceptPendingChange(value, _PagodoctosatClave)) { _PagodoctosatClave = value; OnPropertyChanged(); } } }

        private string? _PagodoctosatNombre;
        [XmlAttribute]
        public string? PagodoctosatNombre { get => _PagodoctosatNombre; set { if (RaiseAcceptPendingChange(value, _PagodoctosatNombre)) { _PagodoctosatNombre = value; OnPropertyChanged(); } } }

        private decimal? _Baseimp;
        [XmlAttribute]
        public decimal? Baseimp { get => _Baseimp; set { if (RaiseAcceptPendingChange(value, _Baseimp)) { _Baseimp = value; OnPropertyChanged(); } } }

        private string? _Tipofactor;
        [XmlAttribute]
        public string? Tipofactor { get => _Tipofactor; set { if (RaiseAcceptPendingChange(value, _Tipofactor)) { _Tipofactor = value; OnPropertyChanged(); } } }

        private string? _Tasacuota;
        [XmlAttribute]
        public string? Tasacuota { get => _Tasacuota; set { if (RaiseAcceptPendingChange(value, _Tasacuota)) { _Tasacuota = value; OnPropertyChanged(); } } }

        private decimal? _Tasa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasa { get => _Tasa?? 0; set { if (RaiseAcceptPendingChange(value, _Tasa)) { _Tasa = value?? 0; OnPropertyChanged(); } } }

        private string? _Impuesto;
        [XmlAttribute]
        public string? Impuesto { get => _Impuesto; set { if (RaiseAcceptPendingChange(value, _Impuesto)) { _Impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private string? _Tipoimpuesto;
        [XmlAttribute]
        public string? Tipoimpuesto { get => _Tipoimpuesto; set { if (RaiseAcceptPendingChange(value, _Tipoimpuesto)) { _Tipoimpuesto = value; OnPropertyChanged(); } } }

        private string? _Iddocumento;
        [XmlAttribute]
        public string? Iddocumento { get => _Iddocumento; set { if (RaiseAcceptPendingChange(value, _Iddocumento)) { _Iddocumento = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Pagodoctosat_imp"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Pagodoctosat.Clave|Pagodoctosat.Nombre|Tipofactor|Tasacuota|Impuesto|Tipoimpuesto|Iddocumento";
        }






    }
}

