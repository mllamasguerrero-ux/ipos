
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
    public class Recibir_traslado_ParamWFBindingModel : Validatable
    {

        public Recibir_traslado_ParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _DoctoARecibirId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? DoctoARecibirId { get => _DoctoARecibirId?? 0; set { if (RaiseAcceptPendingChange(value, _DoctoARecibirId)) { _DoctoARecibirId = value?? 0; OnPropertyChanged(); } } }

        private long? _UsuarioId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? UsuarioId { get => _UsuarioId?? 0; set { if (RaiseAcceptPendingChange(value, _UsuarioId)) { _UsuarioId = value?? 0; OnPropertyChanged(); } } }

        private long? _AlmacenId;
        [XmlAttribute]
        public long? AlmacenId { get => _AlmacenId; set { if (RaiseAcceptPendingChange(value, _AlmacenId)) { _AlmacenId = value; OnPropertyChanged(); } } }

        private string? _AlmacenClave;
        [XmlAttribute]
        public string? AlmacenClave { get => _AlmacenClave; set { if (RaiseAcceptPendingChange(value, _AlmacenClave)) { _AlmacenClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenNombre;
        [XmlAttribute]
        public string? AlmacenNombre { get => _AlmacenNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenNombre)) { _AlmacenNombre = value; OnPropertyChanged(); } } }

        private string? _Referencias;
        [XmlAttribute]
        public string? Referencias { get => _Referencias; set { if (RaiseAcceptPendingChange(value, _Referencias)) { _Referencias = value; OnPropertyChanged(); } } }

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


        public static Recibir_traslado_ParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_Recibir_traslado_ParamWFBindingModel = new Recibir_traslado_ParamWFBindingModel();

        	buffer_Recibir_traslado_ParamWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Recibir_traslado_ParamWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Recibir_traslado_ParamWFBindingModel._DoctoARecibirId = obj.DoctoARecibirId;

        	buffer_Recibir_traslado_ParamWFBindingModel._UsuarioId = obj.UsuarioId;

        	buffer_Recibir_traslado_ParamWFBindingModel._AlmacenId = obj.AlmacenId;

        	buffer_Recibir_traslado_ParamWFBindingModel._AlmacenClave = obj.AlmacenClave;

        	buffer_Recibir_traslado_ParamWFBindingModel._AlmacenNombre = obj.AlmacenNombre;

        	buffer_Recibir_traslado_ParamWFBindingModel._Referencias = obj.Referencias;

            return buffer_Recibir_traslado_ParamWFBindingModel;
        }


    }

    
     
}

