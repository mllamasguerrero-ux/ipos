
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
    
    public class CuentaBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CuentaBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public CuentaBindingModelGenerated(Cuenta item)
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
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Numucuenta;
        [XmlAttribute]
        public string? Numucuenta { get => _Numucuenta; set { if (RaiseAcceptPendingChange(value, _Numucuenta)) { _Numucuenta = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private BoolCNI? _Esfact;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCNI? Esfact { get => _Esfact?? BoolCNI.N; set { if (RaiseAcceptPendingChange(value, _Esfact)) { _Esfact = value?? BoolCNI.N; OnPropertyChanged(); } } }

        private string? _Leyenda;
        [XmlAttribute]
        public string? Leyenda { get => _Leyenda; set { if (RaiseAcceptPendingChange(value, _Leyenda)) { _Leyenda = value; OnPropertyChanged(); } } }

        private long? _Tipolineapolizaid;
        [XmlAttribute]
        public long? Tipolineapolizaid { get => _Tipolineapolizaid; set { if (RaiseAcceptPendingChange(value, _Tipolineapolizaid)) { _Tipolineapolizaid = value; OnPropertyChanged(); } } }

        private string? _TipolineapolizaClave;
        [XmlAttribute]
        public string? TipolineapolizaClave { get => _TipolineapolizaClave; set { if (RaiseAcceptPendingChange(value, _TipolineapolizaClave)) { _TipolineapolizaClave = value; OnPropertyChanged(); } } }

        private string? _TipolineapolizaNombre;
        [XmlAttribute]
        public string? TipolineapolizaNombre { get => _TipolineapolizaNombre; set { if (RaiseAcceptPendingChange(value, _TipolineapolizaNombre)) { _TipolineapolizaNombre = value; OnPropertyChanged(); } } }

        private long? _Formapagosatid;
        [XmlAttribute]
        public long? Formapagosatid { get => _Formapagosatid; set { if (RaiseAcceptPendingChange(value, _Formapagosatid)) { _Formapagosatid = value; OnPropertyChanged(); } } }

        private string? _FormapagosatClave;
        [XmlAttribute]
        public string? FormapagosatClave { get => _FormapagosatClave; set { if (RaiseAcceptPendingChange(value, _FormapagosatClave)) { _FormapagosatClave = value; OnPropertyChanged(); } } }

        private string? _FormapagosatNombre;
        [XmlAttribute]
        public string? FormapagosatNombre { get => _FormapagosatNombre; set { if (RaiseAcceptPendingChange(value, _FormapagosatNombre)) { _FormapagosatNombre = value; OnPropertyChanged(); } } }

        private decimal? _Tasa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasa { get => _Tasa?? 0; set { if (RaiseAcceptPendingChange(value, _Tasa)) { _Tasa = value?? 0; OnPropertyChanged(); } } }

        private long? _Tipolineapolizaespecialid;
        [XmlAttribute]
        public long? Tipolineapolizaespecialid { get => _Tipolineapolizaespecialid; set { if (RaiseAcceptPendingChange(value, _Tipolineapolizaespecialid)) { _Tipolineapolizaespecialid = value; OnPropertyChanged(); } } }

        private string? _TipolineapolizaespecialClave;
        [XmlAttribute]
        public string? TipolineapolizaespecialClave { get => _TipolineapolizaespecialClave; set { if (RaiseAcceptPendingChange(value, _TipolineapolizaespecialClave)) { _TipolineapolizaespecialClave = value; OnPropertyChanged(); } } }

        private string? _TipolineapolizaespecialNombre;
        [XmlAttribute]
        public string? TipolineapolizaespecialNombre { get => _TipolineapolizaespecialNombre; set { if (RaiseAcceptPendingChange(value, _TipolineapolizaespecialNombre)) { _TipolineapolizaespecialNombre = value; OnPropertyChanged(); } } }

        private int? _Orden;
        [XmlAttribute]
        public int? Orden { get => _Orden; set { if (RaiseAcceptPendingChange(value, _Orden)) { _Orden = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Cuenta"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Numucuenta|Descripcion|Leyenda|Tipolineapoliza.Clave|Tipolineapoliza.Nombre|Formapagosat.Clave|Formapagosat.Nombre|Tipolineapolizaespecial.Clave|Tipolineapolizaespecial.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Cuenta item)
        {

             this._TipolineapolizaClave = item.Tipolineapoliza?.Clave;

             this._TipolineapolizaNombre = item.Tipolineapoliza?.Nombre;

             this._FormapagosatClave = item.Formapagosat?.Clave;

             this._FormapagosatNombre = item.Formapagosat?.Nombre;

             this._TipolineapolizaespecialClave = item.Tipolineapolizaespecial?.Clave;

             this._TipolineapolizaespecialNombre = item.Tipolineapolizaespecial?.Nombre;


        }


        public void FillEntityValues(ref Cuenta item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ;


            item.Numucuenta = Numucuenta ;


            item.Descripcion = Descripcion ;


            item.Esfact = Esfact ?? BoolCNI.N;


            item.Leyenda = Leyenda ;


            item.Tipolineapolizaid = Tipolineapolizaid ;


            item.Formapagosatid = Formapagosatid ;


            item.Tasa = Tasa ?? 0;


            item.Tipolineapolizaespecialid = Tipolineapolizaespecialid ;


            item.Orden = Orden ;



        }

        public void FillFromEntity(Cuenta item)
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

            Numucuenta = item.Numucuenta;

            Descripcion = item.Descripcion;

            Esfact = item.Esfact;

            Leyenda = item.Leyenda;

            Tipolineapolizaid = item.Tipolineapolizaid;

            Formapagosatid = item.Formapagosatid;

            Tasa = item.Tasa;

            Tipolineapolizaespecialid = item.Tipolineapolizaespecialid;

            Orden = item.Orden;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

