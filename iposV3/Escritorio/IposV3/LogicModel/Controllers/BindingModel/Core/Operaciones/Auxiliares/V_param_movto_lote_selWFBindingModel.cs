
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
    public class V_param_movto_lote_selWFBindingModel : Validatable
    {

        public V_param_movto_lote_selWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private string? _Almacennombre;
        [XmlAttribute]
        public string? Almacennombre { get => _Almacennombre; set { if (RaiseAcceptPendingChange(value, _Almacennombre)) { _Almacennombre = value; OnPropertyChanged(); } } }

        private string? _Busqueda;
        [XmlAttribute]
        public string? Busqueda { get => _Busqueda; set { if (RaiseAcceptPendingChange(value, _Busqueda)) { _Busqueda = value; OnPropertyChanged(); } } }


        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }


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


        public static V_param_movto_lote_selWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_param_movto_lote_selWFBindingModel = new V_param_movto_lote_selWFBindingModel();

        	buffer_V_param_movto_lote_selWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_param_movto_lote_selWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_param_movto_lote_selWFBindingModel._Productoid = obj.Productoid;

        	buffer_V_param_movto_lote_selWFBindingModel._Productoclave = obj.Productoclave;

        	buffer_V_param_movto_lote_selWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_V_param_movto_lote_selWFBindingModel._Almacenid = obj.Almacenid;

        	buffer_V_param_movto_lote_selWFBindingModel._Almacenclave = obj.Almacenclave;

        	buffer_V_param_movto_lote_selWFBindingModel._Almacennombre = obj.Almacennombre;

        	buffer_V_param_movto_lote_selWFBindingModel._Busqueda = obj.Busqueda;

            buffer_V_param_movto_lote_selWFBindingModel._Doctoid = obj.Doctoid;

            return buffer_V_param_movto_lote_selWFBindingModel;
        }


    }

    
     
}

