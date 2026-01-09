
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    [XmlRoot]
    
    public class V_DoctosConSaldo_SelectorBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public V_DoctosConSaldo_SelectorBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public V_DoctosConSaldo_SelectorBindingModelGenerated(TmpDoctosConSaldo_Selector item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }
        #endif
        


        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _TipodoctoId;
        [XmlAttribute]
        public long? TipodoctoId { get => _TipodoctoId; set { if (RaiseAcceptPendingChange(value, _TipodoctoId)) { _TipodoctoId = value; OnPropertyChanged(); } } }

        private string? _TipodoctoClave;
        [XmlAttribute]
        public string? TipodoctoClave { get => _TipodoctoClave; set { if (RaiseAcceptPendingChange(value, _TipodoctoClave)) { _TipodoctoClave = value; OnPropertyChanged(); } } }

        private string? _TipodoctoNombre;
        [XmlAttribute]
        public string? TipodoctoNombre { get => _TipodoctoNombre; set { if (RaiseAcceptPendingChange(value, _TipodoctoNombre)) { _TipodoctoNombre = value; OnPropertyChanged(); } } }

        private long? _EstatusDoctoId;
        [XmlAttribute]
        public long? EstatusDoctoId { get => _EstatusDoctoId; set { if (RaiseAcceptPendingChange(value, _EstatusDoctoId)) { _EstatusDoctoId = value; OnPropertyChanged(); } } }

        private string? _EstatusDoctoClave;
        [XmlAttribute]
        public string? EstatusDoctoClave { get => _EstatusDoctoClave; set { if (RaiseAcceptPendingChange(value, _EstatusDoctoClave)) { _EstatusDoctoClave = value; OnPropertyChanged(); } } }

        private string? _EstatusDoctoNombre;
        [XmlAttribute]
        public string? EstatusDoctoNombre { get => _EstatusDoctoNombre; set { if (RaiseAcceptPendingChange(value, _EstatusDoctoNombre)) { _EstatusDoctoNombre = value; OnPropertyChanged(); } } }

        private long? _ClienteId;
        [XmlAttribute]
        public long? ClienteId { get => _ClienteId; set { if (RaiseAcceptPendingChange(value, _ClienteId)) { _ClienteId = value; OnPropertyChanged(); } } }

        private string? _ClienteClave;
        [XmlAttribute]
        public string? ClienteClave { get => _ClienteClave; set { if (RaiseAcceptPendingChange(value, _ClienteClave)) { _ClienteClave = value; OnPropertyChanged(); } } }

        private string? _ClienteNombre;
        [XmlAttribute]
        public string? ClienteNombre { get => _ClienteNombre; set { if (RaiseAcceptPendingChange(value, _ClienteNombre)) { _ClienteNombre = value; OnPropertyChanged(); } } }

        private long? _ProveedorId;
        [XmlAttribute]
        public long? ProveedorId { get => _ProveedorId; set { if (RaiseAcceptPendingChange(value, _ProveedorId)) { _ProveedorId = value; OnPropertyChanged(); } } }

        private string? _ProveedorClave;
        [XmlAttribute]
        public string? ProveedorClave { get => _ProveedorClave; set { if (RaiseAcceptPendingChange(value, _ProveedorClave)) { _ProveedorClave = value; OnPropertyChanged(); } } }

        private string? _ProveedorNombre;
        [XmlAttribute]
        public string? ProveedorNombre { get => _ProveedorNombre; set { if (RaiseAcceptPendingChange(value, _ProveedorNombre)) { _ProveedorNombre = value; OnPropertyChanged(); } } }

        private bool? _SoloTimbrados;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool? SoloTimbrados { get => _SoloTimbrados?? false; set { if (RaiseAcceptPendingChange(value, _SoloTimbrados)) { _SoloTimbrados = value?? false; OnPropertyChanged(); } } }

        private long? _UsuarioId;
        [XmlAttribute]
        public long? UsuarioId { get => _UsuarioId; set { if (RaiseAcceptPendingChange(value, _UsuarioId)) { _UsuarioId = value; OnPropertyChanged(); } } }

        private string? _UsuarioClave;
        [XmlAttribute]
        public string? UsuarioClave { get => _UsuarioClave; set { if (RaiseAcceptPendingChange(value, _UsuarioClave)) { _UsuarioClave = value; OnPropertyChanged(); } } }

        private string? _UsuarioNombre;
        [XmlAttribute]
        public string? UsuarioNombre { get => _UsuarioNombre; set { if (RaiseAcceptPendingChange(value, _UsuarioNombre)) { _UsuarioNombre = value; OnPropertyChanged(); } } }

        private bool? _CorteActivo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool? CorteActivo { get => _CorteActivo?? false; set { if (RaiseAcceptPendingChange(value, _CorteActivo)) { _CorteActivo = value?? false; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _FechaInicial;
        [XmlAttribute]
        public DateTimeOffset? FechaInicial { get => _FechaInicial; set { if (RaiseAcceptPendingChange(value, _FechaInicial)) { _FechaInicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _FechaFinal;
        [XmlAttribute]
        public DateTimeOffset? FechaFinal { get => _FechaFinal; set { if (RaiseAcceptPendingChange(value, _FechaFinal)) { _FechaFinal = value; OnPropertyChanged(); } } }


        private DateTimeOffset? _Creado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id ?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value ?? 0; OnPropertyChanged(); } } }


        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""TmpDoctosConSaldo_Selector"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"TipodoctoClave|TipodoctoNombre|EstatusDoctoClave|EstatusDoctoNombre|ClienteClave|ClienteNombre|ProveedorClave|ProveedorNombre|SoloTimbrados|UsuarioClave|UsuarioNombre|CorteActivo|Referencia|ProveeclienteClave|ProveeclienteNombre|VendedorClave|VendedorNombre";
        }


        #if PROYECTO_WEB
        public virtual void FillCatalogRelatedFields(TmpDoctosConSaldo_Selector item)
        {


        }


        public virtual void FillEntityValues(ref TmpDoctosConSaldo_Selector item)
        {


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.TipodoctoId = TipodoctoId ;


            item.TipodoctoClave = TipodoctoClave ;


            item.TipodoctoNombre = TipodoctoNombre ;


            item.EstatusDoctoId = EstatusDoctoId ;


            item.EstatusDoctoClave = EstatusDoctoClave ;


            item.EstatusDoctoNombre = EstatusDoctoNombre ;


            item.ClienteId = ClienteId ;


            item.ClienteClave = ClienteClave ;


            item.ClienteNombre = ClienteNombre ;


            item.ProveedorId = ProveedorId ;


            item.ProveedorClave = ProveedorClave ;


            item.ProveedorNombre = ProveedorNombre ;


            item.SoloTimbrados = SoloTimbrados ?? false;


            item.UsuarioId = UsuarioId ;


            item.UsuarioClave = UsuarioClave ;


            item.UsuarioNombre = UsuarioNombre ;


            item.CorteActivo = CorteActivo ?? false;


            item.Referencia = Referencia ;


            item.FechaInicial = FechaInicial ;


            item.FechaFinal = FechaFinal ;



        }

        public virtual void FillFromEntity(TmpDoctosConSaldo_Selector item)
        {

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            TipodoctoId = item.TipodoctoId;

            TipodoctoClave = item.TipodoctoClave;

            TipodoctoNombre = item.TipodoctoNombre;

            EstatusDoctoId = item.EstatusDoctoId;

            EstatusDoctoClave = item.EstatusDoctoClave;

            EstatusDoctoNombre = item.EstatusDoctoNombre;

            ClienteId = item.ClienteId;

            ClienteClave = item.ClienteClave;

            ClienteNombre = item.ClienteNombre;

            ProveedorId = item.ProveedorId;

            ProveedorClave = item.ProveedorClave;

            ProveedorNombre = item.ProveedorNombre;

            SoloTimbrados = item.SoloTimbrados;

            UsuarioId = item.UsuarioId;

            UsuarioClave = item.UsuarioClave;

            UsuarioNombre = item.UsuarioNombre;

            CorteActivo = item.CorteActivo;

            Referencia = item.Referencia;

            FechaInicial = item.FechaInicial;

            FechaFinal = item.FechaFinal;



             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

