
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
    
    public class LotesimportadosBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public LotesimportadosBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public LotesimportadosBindingModelGenerated(Lotesimportados item)
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

        private string? _Pedimento;
        [XmlAttribute]
        public string? Pedimento { get => _Pedimento; set { if (RaiseAcceptPendingChange(value, _Pedimento)) { _Pedimento = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaimportacion;
        [XmlAttribute]
        public DateTimeOffset? Fechaimportacion { get => _Fechaimportacion; set { if (RaiseAcceptPendingChange(value, _Fechaimportacion)) { _Fechaimportacion = value; OnPropertyChanged(); } } }

        private decimal? _Tipocambio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tipocambio { get => _Tipocambio?? 0; set { if (RaiseAcceptPendingChange(value, _Tipocambio)) { _Tipocambio = value?? 0; OnPropertyChanged(); } } }

        private long? _Sataduanaid;
        [XmlAttribute]
        public long? Sataduanaid { get => _Sataduanaid; set { if (RaiseAcceptPendingChange(value, _Sataduanaid)) { _Sataduanaid = value; OnPropertyChanged(); } } }

        private string? _SataduanaClave;
        [XmlAttribute]
        public string? SataduanaClave { get => _SataduanaClave; set { if (RaiseAcceptPendingChange(value, _SataduanaClave)) { _SataduanaClave = value; OnPropertyChanged(); } } }

        private string? _SataduanaNombre;
        [XmlAttribute]
        public string? SataduanaNombre { get => _SataduanaNombre; set { if (RaiseAcceptPendingChange(value, _SataduanaNombre)) { _SataduanaNombre = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Lotesimportados"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Pedimento|Sataduana.Clave|Sataduana.Nombre|Clave|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Lotesimportados item)
        {

             this._SataduanaClave = item.Sataduana?.Clave;

             this._SataduanaNombre = item.Sataduana?.Nombre;


        }


        public void FillEntityValues(ref Lotesimportados item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Pedimento = Pedimento ;


            item.Fechaimportacion = Fechaimportacion ;


            item.Tipocambio = Tipocambio ?? 0;


            item.Sataduanaid = Sataduanaid ;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";



        }

        public void FillFromEntity(Lotesimportados item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Pedimento = item.Pedimento;

            Fechaimportacion = item.Fechaimportacion;

            Tipocambio = item.Tipocambio;

            Sataduanaid = item.Sataduanaid;

            Clave = item.Clave;

            Nombre = item.Nombre;


             FillCatalogRelatedFields(item);


        }

        #endif
        


    }
}

