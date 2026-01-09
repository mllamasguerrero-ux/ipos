
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
    public class V_movto_lote_seleccionWFBindingModel : Validatable
    {

        public V_movto_lote_seleccionWFBindingModel()
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

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private string? _Almacennombre;
        [XmlAttribute]
        public string? Almacennombre { get => _Almacennombre; set { if (RaiseAcceptPendingChange(value, _Almacennombre)) { _Almacennombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidad { get => _Cantidad?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value?? 0; OnPropertyChanged(); } } }

        private bool? _Caducado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool? Caducado { get => _Caducado ?? false; set { if (RaiseAcceptPendingChange(value, _Caducado)) { _Caducado = value ?? false; OnPropertyChanged(); } } }

        private bool? _Porcaducar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool? Porcaducar { get => _Porcaducar ?? false; set { if (RaiseAcceptPendingChange(value, _Porcaducar)) { _Porcaducar = value ?? false; OnPropertyChanged(); } } }

        private decimal? _Cantidadendocto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidadendocto { get => _Cantidadendocto?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidadendocto)) { _Cantidadendocto = value?? 0; OnPropertyChanged(); } } }


        private decimal _CantidadATomar = 0;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal CantidadATomar { get => _CantidadATomar ; set { if (RaiseAcceptPendingChange(value, _CantidadATomar)) { _CantidadATomar = value ; OnPropertyChanged(); } } }


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


        public static V_movto_lote_seleccionWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_movto_lote_seleccionWFBindingModel = new V_movto_lote_seleccionWFBindingModel();

        	buffer_V_movto_lote_seleccionWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_movto_lote_seleccionWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_movto_lote_seleccionWFBindingModel._Productoid = obj.Productoid;

        	buffer_V_movto_lote_seleccionWFBindingModel._Productoclave = obj.Productoclave;

        	buffer_V_movto_lote_seleccionWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_V_movto_lote_seleccionWFBindingModel._Lote = obj.Lote;

        	buffer_V_movto_lote_seleccionWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_V_movto_lote_seleccionWFBindingModel._Almacenid = obj.Almacenid;

        	buffer_V_movto_lote_seleccionWFBindingModel._Almacenclave = obj.Almacenclave;

        	buffer_V_movto_lote_seleccionWFBindingModel._Almacennombre = obj.Almacennombre;

        	buffer_V_movto_lote_seleccionWFBindingModel._Cantidad = obj.Cantidad;

        	buffer_V_movto_lote_seleccionWFBindingModel._Caducado = obj.Caducado;

        	buffer_V_movto_lote_seleccionWFBindingModel._Porcaducar = obj.Porcaducar;

        	buffer_V_movto_lote_seleccionWFBindingModel._Cantidadendocto = obj.Cantidadendocto;

            return buffer_V_movto_lote_seleccionWFBindingModel;
        }


    }

    
     
}

