
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
    public class CambiocontrasenaWFBindingModel : Validatable
    {

        public CambiocontrasenaWFBindingModel()
        {
            FillCatalogRelatedFields();
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

        private string? _UsuarioNombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? UsuarioNombre { get => _UsuarioNombre?? ""; set { if (RaiseAcceptPendingChange(value, _UsuarioNombre)) { _UsuarioNombre = value?? ""; OnPropertyChanged(); } } }

        private string? _Contrasena;
        [XmlAttribute]
        public string? Contrasena { get => _Contrasena ?? ""; set { if (RaiseAcceptPendingChange(value, _Contrasena)) { _Contrasena = value ?? ""; OnPropertyChanged(); } } }



        private string? _ContrasenaAnterior;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? ContrasenaAnterior { get => _ContrasenaAnterior?? ""; set { if (RaiseAcceptPendingChange(value, _ContrasenaAnterior)) { _ContrasenaAnterior = value?? ""; OnPropertyChanged(); } } }

        private string? _ContrasenaNueva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? ContrasenaNueva { get => _ContrasenaNueva?? ""; set { if (RaiseAcceptPendingChange(value, _ContrasenaNueva)) { _ContrasenaNueva = value?? ""; OnPropertyChanged(); } } }

        private string? _ContrasenaConfirmacion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? ContrasenaConfirmacion { get => _ContrasenaConfirmacion?? ""; set { if (RaiseAcceptPendingChange(value, _ContrasenaConfirmacion)) { _ContrasenaConfirmacion = value?? ""; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }


        public static CambiocontrasenaWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_CambiocontrasenaWFBindingModel = new CambiocontrasenaWFBindingModel();

        	buffer_CambiocontrasenaWFBindingModel._CreadoPorId = obj.CreadoPorId;

        	buffer_CambiocontrasenaWFBindingModel._ModificadoPorId = obj.ModificadoPorId;

        	buffer_CambiocontrasenaWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_CambiocontrasenaWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_CambiocontrasenaWFBindingModel._Id = obj.Id;

        	buffer_CambiocontrasenaWFBindingModel._UsuarioNombre = obj.UsuarioNombre;

        	buffer_CambiocontrasenaWFBindingModel._ContrasenaAnterior = obj.ContrasenaAnterior;

        	buffer_CambiocontrasenaWFBindingModel._ContrasenaNueva = obj.ContrasenaNueva;

        	buffer_CambiocontrasenaWFBindingModel._ContrasenaConfirmacion = obj.ContrasenaConfirmacion;

        	buffer_CambiocontrasenaWFBindingModel._Clave = obj.Clave;

            return buffer_CambiocontrasenaWFBindingModel;
        }


    }

    
     
}

