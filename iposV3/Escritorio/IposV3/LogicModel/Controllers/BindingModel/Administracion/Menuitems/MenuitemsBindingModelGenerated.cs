
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
    
    public class MenuitemsBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public MenuitemsBindingModelGenerated()
        {
        }

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

        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private string? _Etiqueta;
        [XmlAttribute]
        public string? Etiqueta { get => _Etiqueta; set { if (RaiseAcceptPendingChange(value, _Etiqueta)) { _Etiqueta = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private long? _Parentid;
        [XmlAttribute]
        public long? Parentid { get => _Parentid; set { if (RaiseAcceptPendingChange(value, _Parentid)) { _Parentid = value; OnPropertyChanged(); } } }

        private string? _ParentClave;
        [XmlAttribute]
        public string? ParentClave { get => _ParentClave; set { if (RaiseAcceptPendingChange(value, _ParentClave)) { _ParentClave = value; OnPropertyChanged(); } } }

        private string? _ParentNombre;
        [XmlAttribute]
        public string? ParentNombre { get => _ParentNombre; set { if (RaiseAcceptPendingChange(value, _ParentNombre)) { _ParentNombre = value; OnPropertyChanged(); } } }

        private long? _Derechoid;
        [XmlAttribute]
        public long? Derechoid { get => _Derechoid; set { if (RaiseAcceptPendingChange(value, _Derechoid)) { _Derechoid = value; OnPropertyChanged(); } } }

        private string? _DerechoClave;
        [XmlAttribute]
        public string? DerechoClave { get => _DerechoClave; set { if (RaiseAcceptPendingChange(value, _DerechoClave)) { _DerechoClave = value; OnPropertyChanged(); } } }

        private string? _DerechoNombre;
        [XmlAttribute]
        public string? DerechoNombre { get => _DerechoNombre; set { if (RaiseAcceptPendingChange(value, _DerechoNombre)) { _DerechoNombre = value; OnPropertyChanged(); } } }

        private short? _Nivel;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public short? Nivel { get => _Nivel?? 0; set { if (RaiseAcceptPendingChange(value, _Nivel)) { _Nivel = value?? 0; OnPropertyChanged(); } } }

        private int? _Orden;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Orden { get => _Orden?? 0; set { if (RaiseAcceptPendingChange(value, _Orden)) { _Orden = value?? 0; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Menuitems"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Etiqueta|Descripcion|Parent.Clave|Parent.Nombre|Derecho.Clave|Derecho.Nombre";
        }



    }
}

