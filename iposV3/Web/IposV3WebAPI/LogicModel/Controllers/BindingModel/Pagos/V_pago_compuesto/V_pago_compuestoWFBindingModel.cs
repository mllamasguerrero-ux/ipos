
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
    public class V_pago_compuestoWFBindingModel : Validatable
    {

        public V_pago_compuestoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private string? _Formapagoclave;
        [XmlAttribute]
        public string? Formapagoclave { get => _Formapagoclave; set { if (RaiseAcceptPendingChange(value, _Formapagoclave)) { _Formapagoclave = value; OnPropertyChanged(); } } }

        private string? _Formapagonombre;
        [XmlAttribute]
        public string? Formapagonombre { get => _Formapagonombre; set { if (RaiseAcceptPendingChange(value, _Formapagonombre)) { _Formapagonombre = value; OnPropertyChanged(); } } }

        private string? _Formapagosatclave;
        [XmlAttribute]
        public string? Formapagosatclave { get => _Formapagosatclave; set { if (RaiseAcceptPendingChange(value, _Formapagosatclave)) { _Formapagosatclave = value; OnPropertyChanged(); } } }

        private string? _Formapagosatnombre;
        [XmlAttribute]
        public string? Formapagosatnombre { get => _Formapagosatnombre; set { if (RaiseAcceptPendingChange(value, _Formapagosatnombre)) { _Formapagosatnombre = value; OnPropertyChanged(); } } }

        private string? _Bancoclave;
        [XmlAttribute]
        public string? Bancoclave { get => _Bancoclave; set { if (RaiseAcceptPendingChange(value, _Bancoclave)) { _Bancoclave = value; OnPropertyChanged(); } } }

        private string? _Banconombre;
        [XmlAttribute]
        public string? Banconombre { get => _Banconombre; set { if (RaiseAcceptPendingChange(value, _Banconombre)) { _Banconombre = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Tipopagoclave;
        [XmlAttribute]
        public string? Tipopagoclave { get => _Tipopagoclave; set { if (RaiseAcceptPendingChange(value, _Tipopagoclave)) { _Tipopagoclave = value; OnPropertyChanged(); } } }

        private string? _Tipopagonombre;
        [XmlAttribute]
        public string? Tipopagonombre { get => _Tipopagonombre; set { if (RaiseAcceptPendingChange(value, _Tipopagonombre)) { _Tipopagonombre = value; OnPropertyChanged(); } } }

        private string? _Timbrado;
        [XmlAttribute]
        public string? Timbrado { get => _Timbrado; set { if (RaiseAcceptPendingChange(value, _Timbrado)) { _Timbrado = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicado;
        [XmlAttribute]
        public BoolCN? Aplicado { get => (_Aplicado ?? BoolCN.S); set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private string? _ClienteClave;
        [XmlAttribute]
        public string? ClienteClave { get => _ClienteClave; set { if (RaiseAcceptPendingChange(value, _ClienteClave)) { _ClienteClave = value; OnPropertyChanged(); } } }

        private string? _ClienteNombre;
        [XmlAttribute]
        public string? ClienteNombre { get => _ClienteNombre; set { if (RaiseAcceptPendingChange(value, _ClienteNombre)) { _ClienteNombre = value; OnPropertyChanged(); } } }

        private string? _ProveedorClave;
        [XmlAttribute]
        public string? ProveedorClave { get => _ProveedorClave; set { if (RaiseAcceptPendingChange(value, _ProveedorClave)) { _ProveedorClave = value; OnPropertyChanged(); } } }

        private string? _ProveedorNombre;
        [XmlAttribute]
        public string? ProveedorNombre { get => _ProveedorNombre; set { if (RaiseAcceptPendingChange(value, _ProveedorNombre)) { _ProveedorNombre = value; OnPropertyChanged(); } } }

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


        public static V_pago_compuestoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_pago_compuestoWFBindingModel = new V_pago_compuestoWFBindingModel();

        	buffer_V_pago_compuestoWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_pago_compuestoWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_pago_compuestoWFBindingModel._Id = obj.Id;

        	buffer_V_pago_compuestoWFBindingModel._Fecha = obj.Fecha;

        	buffer_V_pago_compuestoWFBindingModel._Fechahora = obj.Fechahora;

        	buffer_V_pago_compuestoWFBindingModel._Importe = obj.Importe;

        	buffer_V_pago_compuestoWFBindingModel._Formapagoclave = obj.Formapagoclave;

        	buffer_V_pago_compuestoWFBindingModel._Formapagonombre = obj.Formapagonombre;

        	buffer_V_pago_compuestoWFBindingModel._Formapagosatclave = obj.Formapagosatclave;

        	buffer_V_pago_compuestoWFBindingModel._Formapagosatnombre = obj.Formapagosatnombre;

        	buffer_V_pago_compuestoWFBindingModel._Bancoclave = obj.Bancoclave;

        	buffer_V_pago_compuestoWFBindingModel._Banconombre = obj.Banconombre;

        	buffer_V_pago_compuestoWFBindingModel._Referenciabancaria = obj.Referenciabancaria;

        	buffer_V_pago_compuestoWFBindingModel._Tipopagoclave = obj.Tipopagoclave;

        	buffer_V_pago_compuestoWFBindingModel._Tipopagonombre = obj.Tipopagonombre;

        	buffer_V_pago_compuestoWFBindingModel._Timbrado = obj.Timbrado;

        	buffer_V_pago_compuestoWFBindingModel._Aplicado = obj.Aplicado;

        	buffer_V_pago_compuestoWFBindingModel._ClienteClave = obj.ClienteClave;

        	buffer_V_pago_compuestoWFBindingModel._ClienteNombre = obj.ClienteNombre;

        	buffer_V_pago_compuestoWFBindingModel._ProveedorClave = obj.ProveedorClave;

        	buffer_V_pago_compuestoWFBindingModel._ProveedorNombre = obj.ProveedorNombre;

            return buffer_V_pago_compuestoWFBindingModel;
        }


    }

    
     
}

