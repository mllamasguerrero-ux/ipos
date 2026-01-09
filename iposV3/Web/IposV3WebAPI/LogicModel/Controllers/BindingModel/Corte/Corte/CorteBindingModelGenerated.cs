
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
    
    public class CorteBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CorteBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public CorteBindingModelGenerated(Corte item)
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

        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private string? _CajaClave;
        [XmlAttribute]
        public string? CajaClave { get => _CajaClave; set { if (RaiseAcceptPendingChange(value, _CajaClave)) { _CajaClave = value; OnPropertyChanged(); } } }

        private string? _CajaNombre;
        [XmlAttribute]
        public string? CajaNombre { get => _CajaNombre; set { if (RaiseAcceptPendingChange(value, _CajaNombre)) { _CajaNombre = value; OnPropertyChanged(); } } }

        private long? _Cajeroid;
        [XmlAttribute]
        public long? Cajeroid { get => _Cajeroid; set { if (RaiseAcceptPendingChange(value, _Cajeroid)) { _Cajeroid = value; OnPropertyChanged(); } } }

        private string? _CajeroClave;
        [XmlAttribute]
        public string? CajeroClave { get => _CajeroClave; set { if (RaiseAcceptPendingChange(value, _CajeroClave)) { _CajeroClave = value; OnPropertyChanged(); } } }

        private string? _CajeroNombre;
        [XmlAttribute]
        public string? CajeroNombre { get => _CajeroNombre; set { if (RaiseAcceptPendingChange(value, _CajeroNombre)) { _CajeroNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechacorte;
        [XmlAttribute]
        public DateTimeOffset? Fechacorte { get => _Fechacorte; set { if (RaiseAcceptPendingChange(value, _Fechacorte)) { _Fechacorte = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Inicia;
        [XmlAttribute]
        public DateTimeOffset? Inicia { get => _Inicia; set { if (RaiseAcceptPendingChange(value, _Inicia)) { _Inicia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Termina;
        [XmlAttribute]
        public DateTimeOffset? Termina { get => _Termina; set { if (RaiseAcceptPendingChange(value, _Termina)) { _Termina = value; OnPropertyChanged(); } } }

        private decimal? _Saldoinicial;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldoinicial { get => _Saldoinicial?? 0; set { if (RaiseAcceptPendingChange(value, _Saldoinicial)) { _Saldoinicial = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ingreso;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ingreso { get => _Ingreso?? 0; set { if (RaiseAcceptPendingChange(value, _Ingreso)) { _Ingreso = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Egreso;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Egreso { get => _Egreso?? 0; set { if (RaiseAcceptPendingChange(value, _Egreso)) { _Egreso = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Saldofinal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldofinal { get => _Saldofinal?? 0; set { if (RaiseAcceptPendingChange(value, _Saldofinal)) { _Saldofinal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Saldoreal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldoreal { get => _Saldoreal?? 0; set { if (RaiseAcceptPendingChange(value, _Saldoreal)) { _Saldoreal = value?? 0; OnPropertyChanged(); } } }

        private long? _Tipocorteid;
        [XmlAttribute]
        public long? Tipocorteid { get => _Tipocorteid; set { if (RaiseAcceptPendingChange(value, _Tipocorteid)) { _Tipocorteid = value; OnPropertyChanged(); } } }

        private string? _TipocorteClave;
        [XmlAttribute]
        public string? TipocorteClave { get => _TipocorteClave; set { if (RaiseAcceptPendingChange(value, _TipocorteClave)) { _TipocorteClave = value; OnPropertyChanged(); } } }

        private string? _TipocorteNombre;
        [XmlAttribute]
        public string? TipocorteNombre { get => _TipocorteNombre; set { if (RaiseAcceptPendingChange(value, _TipocorteNombre)) { _TipocorteNombre = value; OnPropertyChanged(); } } }

        private long? _Corterecoleccionid;
        [XmlAttribute]
        public long? Corterecoleccionid { get => _Corterecoleccionid; set { if (RaiseAcceptPendingChange(value, _Corterecoleccionid)) { _Corterecoleccionid = value; OnPropertyChanged(); } } }

        private string? _CorterecoleccionClave;
        [XmlAttribute]
        public string? CorterecoleccionClave { get => _CorterecoleccionClave; set { if (RaiseAcceptPendingChange(value, _CorterecoleccionClave)) { _CorterecoleccionClave = value; OnPropertyChanged(); } } }

        private string? _CorterecoleccionNombre;
        [XmlAttribute]
        public string? CorterecoleccionNombre { get => _CorterecoleccionNombre; set { if (RaiseAcceptPendingChange(value, _CorterecoleccionNombre)) { _CorterecoleccionNombre = value; OnPropertyChanged(); } } }

        private decimal? _Fondodinamico;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Fondodinamico { get => _Fondodinamico?? 0; set { if (RaiseAcceptPendingChange(value, _Fondodinamico)) { _Fondodinamico = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Fondodinamicofinal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Fondodinamicofinal { get => _Fondodinamicofinal?? 0; set { if (RaiseAcceptPendingChange(value, _Fondodinamicofinal)) { _Fondodinamicofinal = value?? 0; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Corte"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Caja.Clave|Caja.Nombre|Cajero.Clave|Cajero.Nombre|Tipocorte.Clave|Tipocorte.Nombre|Corterecoleccion.Clave|Corterecoleccion.Nombre";
        }


        #if PROYECTO_WEB
        

        public void FillCatalogRelatedFields(Corte item)
        {

             this._CajaClave = item.Caja?.Clave;

             this._CajaNombre = item.Caja?.Nombre;

             this._CajeroClave = item.Cajero?.Clave;

             this._CajeroNombre = item.Cajero?.Nombre;

             this._TipocorteClave = item.Tipocorte?.Clave;

             this._TipocorteNombre = item.Tipocorte?.Nombre;

             this._CorterecoleccionClave = item.Corterecoleccion?.Clave;

             this._CorterecoleccionNombre = item.Corterecoleccion?.Nombre;


        }


        public void FillEntityValues(ref Corte item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Cajaid = Cajaid ;


            item.Cajeroid = Cajeroid ;


            item.Fechacorte = Fechacorte ;


            item.Inicia = Inicia ;


            item.Termina = Termina ;


            item.Saldoinicial = Saldoinicial ?? 0;


            item.Ingreso = Ingreso ?? 0;


            item.Egreso = Egreso ?? 0;


            item.Saldofinal = Saldofinal ?? 0;


            item.Saldoreal = Saldoreal ?? 0;


            item.Tipocorteid = Tipocorteid ;


            item.Corterecoleccionid = Corterecoleccionid ;


            item.Fondodinamico = Fondodinamico ?? 0;


            item.Fondodinamicofinal = Fondodinamicofinal ?? 0;



        }

        public void FillFromEntity(Corte item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Cajaid = item.Cajaid;

            Cajeroid = item.Cajeroid;

            Fechacorte = item.Fechacorte;

            Inicia = item.Inicia;

            Termina = item.Termina;

            Saldoinicial = item.Saldoinicial;

            Ingreso = item.Ingreso;

            Egreso = item.Egreso;

            Saldofinal = item.Saldofinal;

            Saldoreal = item.Saldoreal;

            Tipocorteid = item.Tipocorteid;

            Corterecoleccionid = item.Corterecoleccionid;

            Fondodinamico = item.Fondodinamico;

            Fondodinamicofinal = item.Fondodinamicofinal;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

