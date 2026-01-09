
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
    public class V_docto_vend_to_devoWFBindingModel : Validatable
    {

        public V_docto_vend_to_devoWFBindingModel()
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

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctoclave;
        [XmlAttribute]
        public string? Estatusdoctoclave { get => _Estatusdoctoclave; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoclave)) { _Estatusdoctoclave = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctonombre;
        [XmlAttribute]
        public string? Estatusdoctonombre { get => _Estatusdoctonombre; set { if (RaiseAcceptPendingChange(value, _Estatusdoctonombre)) { _Estatusdoctonombre = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private string? _Usuarionombre;
        [XmlAttribute]
        public string? Usuarionombre { get => _Usuarionombre; set { if (RaiseAcceptPendingChange(value, _Usuarionombre)) { _Usuarionombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuento { get => _Descuento?? 0; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotal { get => _Subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Iva { get => _Iva?? 0; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ieps { get => _Ieps?? 0; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Total { get => _Total?? 0; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value?? 0; OnPropertyChanged(); } } }

        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private string? _Cajaclave;
        [XmlAttribute]
        public string? Cajaclave { get => _Cajaclave; set { if (RaiseAcceptPendingChange(value, _Cajaclave)) { _Cajaclave = value; OnPropertyChanged(); } } }

        private string? _Cajanombre;
        [XmlAttribute]
        public string? Cajanombre { get => _Cajanombre; set { if (RaiseAcceptPendingChange(value, _Cajanombre)) { _Cajanombre = value; OnPropertyChanged(); } } }

        private long? _Clienteid;
        [XmlAttribute]
        public long? Clienteid { get => _Clienteid; set { if (RaiseAcceptPendingChange(value, _Clienteid)) { _Clienteid = value; OnPropertyChanged(); } } }

        private string? _Clienteclave;
        [XmlAttribute]
        public string? Clienteclave { get => _Clienteclave; set { if (RaiseAcceptPendingChange(value, _Clienteclave)) { _Clienteclave = value; OnPropertyChanged(); } } }

        private string? _Clientenombre;
        [XmlAttribute]
        public string? Clientenombre { get => _Clientenombre; set { if (RaiseAcceptPendingChange(value, _Clientenombre)) { _Clientenombre = value; OnPropertyChanged(); } } }

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

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private long? _Sucursaltid;
        [XmlAttribute]
        public long? Sucursaltid { get => _Sucursaltid; set { if (RaiseAcceptPendingChange(value, _Sucursaltid)) { _Sucursaltid = value; OnPropertyChanged(); } } }

        private string? _Sucursaltclave;
        [XmlAttribute]
        public string? Sucursaltclave { get => _Sucursaltclave; set { if (RaiseAcceptPendingChange(value, _Sucursaltclave)) { _Sucursaltclave = value; OnPropertyChanged(); } } }

        private string? _Sucursaltnombre;
        [XmlAttribute]
        public string? Sucursaltnombre { get => _Sucursaltnombre; set { if (RaiseAcceptPendingChange(value, _Sucursaltnombre)) { _Sucursaltnombre = value; OnPropertyChanged(); } } }

        private long? _Almacentid;
        [XmlAttribute]
        public long? Almacentid { get => _Almacentid; set { if (RaiseAcceptPendingChange(value, _Almacentid)) { _Almacentid = value; OnPropertyChanged(); } } }

        private string? _Almacentclave;
        [XmlAttribute]
        public string? Almacentclave { get => _Almacentclave; set { if (RaiseAcceptPendingChange(value, _Almacentclave)) { _Almacentclave = value; OnPropertyChanged(); } } }

        private string? _Almacentnombre;
        [XmlAttribute]
        public string? Almacentnombre { get => _Almacentnombre; set { if (RaiseAcceptPendingChange(value, _Almacentnombre)) { _Almacentnombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Origenfiscalid;
        [XmlAttribute]
        public long? Origenfiscalid { get => _Origenfiscalid; set { if (RaiseAcceptPendingChange(value, _Origenfiscalid)) { _Origenfiscalid = value; OnPropertyChanged(); } } }

        private string? _Origenfiscalclave;
        [XmlAttribute]
        public string? Origenfiscalclave { get => _Origenfiscalclave; set { if (RaiseAcceptPendingChange(value, _Origenfiscalclave)) { _Origenfiscalclave = value; OnPropertyChanged(); } } }

        private string? _Origenfiscalnombre;
        [XmlAttribute]
        public string? Origenfiscalnombre { get => _Origenfiscalnombre; set { if (RaiseAcceptPendingChange(value, _Origenfiscalnombre)) { _Origenfiscalnombre = value; OnPropertyChanged(); } } }

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


        public static V_docto_vend_to_devoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_docto_vendeduriaWFBindingModel = new V_docto_vend_to_devoWFBindingModel();

        	buffer_V_docto_vendeduriaWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_docto_vendeduriaWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_docto_vendeduriaWFBindingModel._Id = obj.Id;

        	buffer_V_docto_vendeduriaWFBindingModel._Activo = obj.Activo;

        	buffer_V_docto_vendeduriaWFBindingModel._Estatusdoctoid = obj.Estatusdoctoid;

        	buffer_V_docto_vendeduriaWFBindingModel._Estatusdoctoclave = obj.Estatusdoctoclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Estatusdoctonombre = obj.Estatusdoctonombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_V_docto_vendeduriaWFBindingModel._Usuarionombre = obj.Usuarionombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Fecha = obj.Fecha;

        	buffer_V_docto_vendeduriaWFBindingModel._Serie = obj.Serie;

        	buffer_V_docto_vendeduriaWFBindingModel._Folio = obj.Folio;

        	buffer_V_docto_vendeduriaWFBindingModel._Importe = obj.Importe;

        	buffer_V_docto_vendeduriaWFBindingModel._Descuento = obj.Descuento;

        	buffer_V_docto_vendeduriaWFBindingModel._Subtotal = obj.Subtotal;

        	buffer_V_docto_vendeduriaWFBindingModel._Iva = obj.Iva;

        	buffer_V_docto_vendeduriaWFBindingModel._Ieps = obj.Ieps;

        	buffer_V_docto_vendeduriaWFBindingModel._Total = obj.Total;

        	buffer_V_docto_vendeduriaWFBindingModel._Cajaid = obj.Cajaid;

        	buffer_V_docto_vendeduriaWFBindingModel._Cajaclave = obj.Cajaclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Cajanombre = obj.Cajanombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Clienteid = obj.Clienteid;

        	buffer_V_docto_vendeduriaWFBindingModel._Clienteclave = obj.Clienteclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Clientenombre = obj.Clientenombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Tipodoctoid = obj.Tipodoctoid;

        	buffer_V_docto_vendeduriaWFBindingModel._Tipodoctoclave = obj.Tipodoctoclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Tipodoctonombre = obj.Tipodoctonombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Referencia = obj.Referencia;

        	buffer_V_docto_vendeduriaWFBindingModel._Foliosat = obj.Foliosat;

        	buffer_V_docto_vendeduriaWFBindingModel._Seriesat = obj.Seriesat;

        	buffer_V_docto_vendeduriaWFBindingModel._Sucursaltid = obj.Sucursaltid;

        	buffer_V_docto_vendeduriaWFBindingModel._Sucursaltclave = obj.Sucursaltclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Sucursaltnombre = obj.Sucursaltnombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Almacentid = obj.Almacentid;

        	buffer_V_docto_vendeduriaWFBindingModel._Almacentclave = obj.Almacentclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Almacentnombre = obj.Almacentnombre;

        	buffer_V_docto_vendeduriaWFBindingModel._Fechahora = obj.Fechahora;

        	buffer_V_docto_vendeduriaWFBindingModel._Origenfiscalid = obj.Origenfiscalid;

        	buffer_V_docto_vendeduriaWFBindingModel._Origenfiscalclave = obj.Origenfiscalclave;

        	buffer_V_docto_vendeduriaWFBindingModel._Origenfiscalnombre = obj.Origenfiscalnombre;

            return buffer_V_docto_vendeduriaWFBindingModel;
        }


    }


    [XmlRoot]
    public class V_docto_vend_to_devoParamWFBindingModel : Validatable
    {

        public V_docto_vend_to_devoParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }

        public void FillCatalogRelatedFields()
        {

        }

        public string? _usuarioclave;
        public string? P_usuarioclave { get => _usuarioclave; set { if (RaiseAcceptPendingChange(value, _usuarioclave)) { _usuarioclave = value; OnPropertyChanged(); } } }


        public string? _usuarionombre;
        public string? P_usuarionombre { get => _usuarionombre; set { if (RaiseAcceptPendingChange(value, _usuarionombre)) { _usuarionombre = value; OnPropertyChanged(); } } }


        public string? _tipodoctoclave;
        public string? P_tipodoctoclave { get => _tipodoctoclave; set { if (RaiseAcceptPendingChange(value, _tipodoctoclave)) { _tipodoctoclave = value; OnPropertyChanged(); } } }


        public string? _tipodoctonombre;
        public string? P_tipodoctonombre { get => _tipodoctonombre; set { if (RaiseAcceptPendingChange(value, _tipodoctonombre)) { _tipodoctonombre = value; OnPropertyChanged(); } } }


        public string? _estatusdoctoclave;
        public string? P_estatusdoctoclave { get => _estatusdoctoclave; set { if (RaiseAcceptPendingChange(value, _estatusdoctoclave)) { _estatusdoctoclave = value; OnPropertyChanged(); } } }

        public string? _estatusdoctonombre;
        public string? P_estatusdoctonombre { get => _estatusdoctonombre; set { if (RaiseAcceptPendingChange(value, _estatusdoctonombre)) { _estatusdoctonombre = value; OnPropertyChanged(); } } }


        public long? _empresaid;
        public long? P_empresaid { get => _empresaid; set { if (RaiseAcceptPendingChange(value, _empresaid)) { _empresaid = value; OnPropertyChanged(); } } }


        public long? _sucursalid;
        public long? P_sucursalid { get => _sucursalid; set { if (RaiseAcceptPendingChange(value, _sucursalid)) { _sucursalid = value; OnPropertyChanged(); } } }


        public long? _usuarioid;
        public long? P_usuarioid { get => _usuarioid; set { if (RaiseAcceptPendingChange(value, _usuarioid)) { _usuarioid = value; OnPropertyChanged(); } } }


        public long? _tipodoctoid;
        public long? P_tipodoctoid { get => _tipodoctoid; set { if (RaiseAcceptPendingChange(value, _tipodoctoid)) { _tipodoctoid = value; OnPropertyChanged(); } } }

        public DateTimeOffset? _fechaini;
        public DateTimeOffset? P_fechaini
        {
            get => _fechaini;
            set
            {
                if (RaiseAcceptPendingChange(value, _fechaini))
                {
                    _fechaini = value; OnPropertyChanged();
                }
            }
        }



        public DateTimeOffset? _fechafin;
        public DateTimeOffset? P_fechafin { get => _fechafin; set { if (RaiseAcceptPendingChange(value, _fechafin)) { _fechafin = value; OnPropertyChanged(); } } }


        public long? _estatusdoctoid;
        public long? P_estatusdoctoid { get => _estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _estatusdoctoid)) { _estatusdoctoid = value; OnPropertyChanged(); } } }


    }



}

