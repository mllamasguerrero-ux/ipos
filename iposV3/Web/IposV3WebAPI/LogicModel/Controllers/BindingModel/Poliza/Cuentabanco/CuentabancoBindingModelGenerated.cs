
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
    
    public class CuentabancoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CuentabancoBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public CuentabancoBindingModelGenerated(Cuentabanco item)
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

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Nocuenta;
        [XmlAttribute]
        public string? Nocuenta { get => _Nocuenta; set { if (RaiseAcceptPendingChange(value, _Nocuenta)) { _Nocuenta = value; OnPropertyChanged(); } } }

        private string? _Rfc;
        [XmlAttribute]
        public string? Rfc { get => _Rfc; set { if (RaiseAcceptPendingChange(value, _Rfc)) { _Rfc = value; OnPropertyChanged(); } } }

        private BoolCN? _Predeterminada;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Predeterminada { get => _Predeterminada?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Predeterminada)) { _Predeterminada = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Bancoid;
        [XmlAttribute]
        public long? Bancoid { get => _Bancoid; set { if (RaiseAcceptPendingChange(value, _Bancoid)) { _Bancoid = value; OnPropertyChanged(); } } }

        private string? _BancoClave;
        [XmlAttribute]
        public string? BancoClave { get => _BancoClave; set { if (RaiseAcceptPendingChange(value, _BancoClave)) { _BancoClave = value; OnPropertyChanged(); } } }

        private string? _BancoNombre;
        [XmlAttribute]
        public string? BancoNombre { get => _BancoNombre; set { if (RaiseAcceptPendingChange(value, _BancoNombre)) { _BancoNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Cuentabanco"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Nocuenta|Rfc|Banco.Clave|Banco.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Cuentabanco item)
        {

             this._BancoClave = item.Banco?.Clave;

             this._BancoNombre = item.Banco?.Nombre;


        }


        public void FillEntityValues(ref Cuentabanco item)
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


            item.Nombre = Nombre ;


            item.Nocuenta = Nocuenta ;


            item.Rfc = Rfc ;


            item.Predeterminada = Predeterminada ?? BoolCN.N;


            item.Bancoid = Bancoid ;



        }

        public void FillFromEntity(Cuentabanco item)
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

            Nombre = item.Nombre;

            Nocuenta = item.Nocuenta;

            Rfc = item.Rfc;

            Predeterminada = item.Predeterminada;

            Bancoid = item.Bancoid;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

