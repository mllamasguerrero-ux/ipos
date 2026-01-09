
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
    
    public class MovtogastosadicBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public MovtogastosadicBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public MovtogastosadicBindingModelGenerated(Movtogastosadic item)
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

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private string? _DoctoClave;
        [XmlAttribute]
        public string? DoctoClave { get => _DoctoClave; set { if (RaiseAcceptPendingChange(value, _DoctoClave)) { _DoctoClave = value; OnPropertyChanged(); } } }

        private string? _DoctoNombre;
        [XmlAttribute]
        public string? DoctoNombre { get => _DoctoNombre; set { if (RaiseAcceptPendingChange(value, _DoctoNombre)) { _DoctoNombre = value; OnPropertyChanged(); } } }

        private long? _Movtogastosadicid;
        [XmlAttribute]
        public long? Movtogastosadicid { get => _Movtogastosadicid; set { if (RaiseAcceptPendingChange(value, _Movtogastosadicid)) { _Movtogastosadicid = value; OnPropertyChanged(); } } }

        private string? _GastoadicionalClave;
        [XmlAttribute]
        public string? GastoadicionalClave { get => _GastoadicionalClave; set { if (RaiseAcceptPendingChange(value, _GastoadicionalClave)) { _GastoadicionalClave = value; OnPropertyChanged(); } } }

        private string? _GastoadicionalNombre;
        [XmlAttribute]
        public string? GastoadicionalNombre { get => _GastoadicionalNombre; set { if (RaiseAcceptPendingChange(value, _GastoadicionalNombre)) { _GastoadicionalNombre = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private int? _Partida;
        [XmlAttribute]
        public int? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Movtogastosadic"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Docto.Clave|Docto.Nombre|Gastoadicional.Clave|Gastoadicional.Nombre";
        }


        #if PROYECTO_WEB
        public virtual void FillCatalogRelatedFields(Movtogastosadic item)
        {

             this._DoctoClave = item.Docto?.Clave;

             this._DoctoNombre = item.Docto?.Nombre;

             this._GastoadicionalClave = item.Gastoadicional?.Clave;

             this._GastoadicionalNombre = item.Gastoadicional?.Nombre;


        }


        public virtual void FillEntityValues(ref Movtogastosadic item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Doctoid = Doctoid ;


            item.Movtogastosadicid = Movtogastosadicid ;


            item.Monto = Monto ;


            item.Partida = Partida ;



        }

        public virtual void FillFromEntity(Movtogastosadic item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Doctoid = item.Doctoid;

            Movtogastosadicid = item.Movtogastosadicid;

            Monto = item.Monto;

            Partida = item.Partida;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

