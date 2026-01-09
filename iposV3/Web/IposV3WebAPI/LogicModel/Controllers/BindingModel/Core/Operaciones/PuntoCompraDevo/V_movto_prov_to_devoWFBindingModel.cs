
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
    public class V_movto_prov_to_devoWFBindingModel : Validatable
    {

        public V_movto_prov_to_devoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _DoctoRefId;
        [XmlAttribute]
        public long? DoctoRefId { get => _DoctoRefId; set { if (RaiseAcceptPendingChange(value, _DoctoRefId)) { _DoctoRefId = value; OnPropertyChanged(); } } }

        private long? _Movtorefid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Movtorefid { get => _Movtorefid?? 0; set { if (RaiseAcceptPendingChange(value, _Movtorefid)) { _Movtorefid = value?? 0; OnPropertyChanged(); } } }

        private int? _Partidaref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Partidaref { get => _Partidaref?? 0; set { if (RaiseAcceptPendingChange(value, _Partidaref)) { _Partidaref = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantidadref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidadref { get => _Cantidadref?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidadref)) { _Cantidadref = value?? 0; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private decimal? _Preciounidadref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciounidadref { get => _Preciounidadref?? 0; set { if (RaiseAcceptPendingChange(value, _Preciounidadref)) { _Preciounidadref = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importeref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importeref { get => _Importeref?? 0; set { if (RaiseAcceptPendingChange(value, _Importeref)) { _Importeref = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuentoref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentoref { get => _Descuentoref?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentoref)) { _Descuentoref = value?? 0; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private string? _Claveproducto;
        [XmlAttribute]
        public string? Claveproducto { get => _Claveproducto; set { if (RaiseAcceptPendingChange(value, _Claveproducto)) { _Claveproducto = value; OnPropertyChanged(); } } }

        private decimal? _Subtotalref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotalref { get => _Subtotalref?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotalref)) { _Subtotalref = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ivaref;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ivaref { get => _Ivaref?? 0; set { if (RaiseAcceptPendingChange(value, _Ivaref)) { _Ivaref = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidad { get => _Cantidad?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value?? 0; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Movtoid { get => _Movtoid?? 0; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Preciounidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciounidad { get => _Preciounidad?? 0; set { if (RaiseAcceptPendingChange(value, _Preciounidad)) { _Preciounidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotal { get => _Subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private int? _Partida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Partida { get => _Partida?? 0; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantidaddevuelta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidaddevuelta { get => _Cantidaddevuelta?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidaddevuelta)) { _Cantidaddevuelta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantdisp;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantdisp { get => _Cantdisp?? 0; set { if (RaiseAcceptPendingChange(value, _Cantdisp)) { _Cantdisp = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantdispdespues;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantdispdespues { get => _Cantdispdespues?? 0; set { if (RaiseAcceptPendingChange(value, _Cantdispdespues)) { _Cantdispdespues = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaiva { get => _Tasaiva?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaieps { get => _Tasaieps?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value?? 0; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Loteimportado;
        [XmlAttribute]
        public long? Loteimportado { get => _Loteimportado; set { if (RaiseAcceptPendingChange(value, _Loteimportado)) { _Loteimportado = value; OnPropertyChanged(); } } }

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


        public static V_movto_prov_to_devoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_movto_prov_to_devoWFBindingModel = new V_movto_prov_to_devoWFBindingModel();

        	buffer_V_movto_prov_to_devoWFBindingModel._DoctoRefId = obj.DoctoRefId;

        	buffer_V_movto_prov_to_devoWFBindingModel._Movtorefid = obj.Movtorefid;

        	buffer_V_movto_prov_to_devoWFBindingModel._Partidaref = obj.Partidaref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Cantidadref = obj.Cantidadref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Descripcion = obj.Descripcion;

        	buffer_V_movto_prov_to_devoWFBindingModel._Preciounidadref = obj.Preciounidadref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Importeref = obj.Importeref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Descuentoref = obj.Descuentoref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Descripcion2 = obj.Descripcion2;

        	buffer_V_movto_prov_to_devoWFBindingModel._Lote = obj.Lote;

        	buffer_V_movto_prov_to_devoWFBindingModel._Claveproducto = obj.Claveproducto;

        	buffer_V_movto_prov_to_devoWFBindingModel._Subtotalref = obj.Subtotalref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Ivaref = obj.Ivaref;

        	buffer_V_movto_prov_to_devoWFBindingModel._Cantidad = obj.Cantidad;

        	buffer_V_movto_prov_to_devoWFBindingModel._Movtoid = obj.Movtoid;

        	buffer_V_movto_prov_to_devoWFBindingModel._Preciounidad = obj.Preciounidad;

        	buffer_V_movto_prov_to_devoWFBindingModel._Subtotal = obj.Subtotal;

        	buffer_V_movto_prov_to_devoWFBindingModel._Importe = obj.Importe;

        	buffer_V_movto_prov_to_devoWFBindingModel._Partida = obj.Partida;

        	buffer_V_movto_prov_to_devoWFBindingModel._Cantidaddevuelta = obj.Cantidaddevuelta;

        	buffer_V_movto_prov_to_devoWFBindingModel._Cantdisp = obj.Cantdisp;

        	buffer_V_movto_prov_to_devoWFBindingModel._Cantdispdespues = obj.Cantdispdespues;

        	buffer_V_movto_prov_to_devoWFBindingModel._Tasaiva = obj.Tasaiva;

        	buffer_V_movto_prov_to_devoWFBindingModel._Tasaieps = obj.Tasaieps;

        	buffer_V_movto_prov_to_devoWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_movto_prov_to_devoWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_movto_prov_to_devoWFBindingModel._Productoid = obj.Productoid;

        	buffer_V_movto_prov_to_devoWFBindingModel._Descripcion1 = obj.Descripcion1;

        	buffer_V_movto_prov_to_devoWFBindingModel._Descripcion3 = obj.Descripcion3;

        	buffer_V_movto_prov_to_devoWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_V_movto_prov_to_devoWFBindingModel._Loteimportado = obj.Loteimportado;

            return buffer_V_movto_prov_to_devoWFBindingModel;
        }


    }

    
     
}

