
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
    public class V_inventario_doctoWFBindingModel : Validatable
    {

        public V_inventario_doctoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Empresaid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Empresaid { get => _Empresaid?? 0; set { if (RaiseAcceptPendingChange(value, _Empresaid)) { _Empresaid = value?? 0; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Sucursalid { get => _Sucursalid?? 0; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value?? 0; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private string? _Sucursalnombre;
        [XmlAttribute]
        public string? Sucursalnombre { get => _Sucursalnombre; set { if (RaiseAcceptPendingChange(value, _Sucursalnombre)) { _Sucursalnombre = value; OnPropertyChanged(); } } }


        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private string? _Cajaclave;
        [XmlAttribute]
        public string? Cajaclave { get => _Cajaclave; set { if (RaiseAcceptPendingChange(value, _Cajaclave)) { _Cajaclave = value; OnPropertyChanged(); } } }

        private string? _Cajanombre;
        [XmlAttribute]
        public string? Cajanombre { get => _Cajanombre; set { if (RaiseAcceptPendingChange(value, _Cajanombre)) { _Cajanombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private long? _Consecutivo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Consecutivo { get => _Consecutivo?? 0; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Total { get => _Total?? 0; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value?? 0; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctoclave;
        [XmlAttribute]
        public string? Estatusdoctoclave { get => _Estatusdoctoclave; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoclave)) { _Estatusdoctoclave = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctonombre;
        [XmlAttribute]
        public string? Estatusdoctonombre { get => _Estatusdoctonombre; set { if (RaiseAcceptPendingChange(value, _Estatusdoctonombre)) { _Estatusdoctonombre = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Tipodoctoclave;
        [XmlAttribute]
        public string? Tipodoctoclave { get => _Tipodoctoclave; set { if (RaiseAcceptPendingChange(value, _Tipodoctoclave)) { _Tipodoctoclave = value; OnPropertyChanged(); } } }

        private string? _Tipodoctonombre;
        [XmlAttribute]
        public string? Tipodoctonombre { get => _Tipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Tipodoctonombre)) { _Tipodoctonombre = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private string? _Usuarioclave;
        [XmlAttribute]
        public string? Usuarioclave { get => _Usuarioclave; set { if (RaiseAcceptPendingChange(value, _Usuarioclave)) { _Usuarioclave = value; OnPropertyChanged(); } } }

        private string? _Usuarionombre;
        [XmlAttribute]
        public string? Usuarionombre { get => _Usuarionombre; set { if (RaiseAcceptPendingChange(value, _Usuarionombre)) { _Usuarionombre = value; OnPropertyChanged(); } } }

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


        public static V_inventario_doctoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_doctoWFBindingModel = new V_inventario_doctoWFBindingModel();

        	buffer_V_inventario_doctoWFBindingModel._Empresaid = obj.Empresaid;

        	buffer_V_inventario_doctoWFBindingModel._Sucursalid = obj.Sucursalid;

        	buffer_V_inventario_doctoWFBindingModel._Sucursalclave = obj.Sucursalclave;

        	buffer_V_inventario_doctoWFBindingModel._Sucursalnombre = obj.Sucursalnombre;

            buffer_V_inventario_doctoWFBindingModel._Cajaid = obj.Cajaid;

        	buffer_V_inventario_doctoWFBindingModel._Cajaclave = obj.Cajaclave;

        	buffer_V_inventario_doctoWFBindingModel._Cajanombre = obj.Cajanombre;

        	buffer_V_inventario_doctoWFBindingModel._Fecha = obj.Fecha;

        	buffer_V_inventario_doctoWFBindingModel._Serie = obj.Serie;

        	buffer_V_inventario_doctoWFBindingModel._Consecutivo = obj.Consecutivo;

        	buffer_V_inventario_doctoWFBindingModel._Total = obj.Total;

        	buffer_V_inventario_doctoWFBindingModel._Estatusdoctoid = obj.Estatusdoctoid;

        	buffer_V_inventario_doctoWFBindingModel._Estatusdoctoclave = obj.Estatusdoctoclave;

        	buffer_V_inventario_doctoWFBindingModel._Estatusdoctonombre = obj.Estatusdoctonombre;

        	buffer_V_inventario_doctoWFBindingModel._Tipodoctoid = obj.Tipodoctoid;

        	buffer_V_inventario_doctoWFBindingModel._Tipodoctoclave = obj.Tipodoctoclave;

        	buffer_V_inventario_doctoWFBindingModel._Tipodoctonombre = obj.Tipodoctonombre;

        	buffer_V_inventario_doctoWFBindingModel._Referencia = obj.Referencia;

        	buffer_V_inventario_doctoWFBindingModel._Folio = obj.Folio;

        	buffer_V_inventario_doctoWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_V_inventario_doctoWFBindingModel._Usuarioclave = obj.Usuarioclave;

        	buffer_V_inventario_doctoWFBindingModel._Usuarionombre = obj.Usuarionombre;

            return buffer_V_inventario_doctoWFBindingModel;
        }


    }


    public class V_inventario_doctoParamBindingModel : Validatable
    {

        public V_inventario_doctoParamBindingModel()
        {
        }




        private long? _Empresaid;
        public long? Empresaid { get => _Empresaid ?? 0; set { if (RaiseAcceptPendingChange(value, _Empresaid)) { _Empresaid = value ?? 0; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        public long? Sucursalid { get => _Sucursalid ?? 0; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value ?? 0; OnPropertyChanged(); } } }




        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctoclave;
        [XmlAttribute]
        public string? Estatusdoctoclave { get => _Estatusdoctoclave; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoclave)) { _Estatusdoctoclave = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctonombre;
        [XmlAttribute]
        public string? Estatusdoctonombre { get => _Estatusdoctonombre; set { if (RaiseAcceptPendingChange(value, _Estatusdoctonombre)) { _Estatusdoctonombre = value; OnPropertyChanged(); } } }


        private bool? _Activos;
        public bool? Activos { get => _Activos ?? true; set { if (RaiseAcceptPendingChange(value, _Activos)) { _Activos = value ?? true; OnPropertyChanged(); } } }


        private DateTimeOffset? _Desde;
        public DateTimeOffset? Desde { get => _Desde; set { if (RaiseAcceptPendingChange(value, _Desde)) { _Desde = value; OnPropertyChanged(); } } }



    }

}

