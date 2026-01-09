
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
    public class V_docto_con_saldoWFBindingModel : Validatable
    {

        public V_docto_con_saldoWFBindingModel()
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

        private long? _Sucursal_info_id;
        [XmlAttribute]
        public long? Sucursal_info_id { get => _Sucursal_info_id; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_id)) { _Sucursal_info_id = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_clave;
        [XmlAttribute]
        public string? Sucursal_info_clave { get => _Sucursal_info_clave; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_clave)) { _Sucursal_info_clave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_info_nombre;
        [XmlAttribute]
        public string? Sucursal_info_nombre { get => _Sucursal_info_nombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_info_nombre)) { _Sucursal_info_nombre = value; OnPropertyChanged(); } } }

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

        private long? _SucursalDestinoid;
        [XmlAttribute]
        public long? SucursalDestinoid { get => _SucursalDestinoid; set { if (RaiseAcceptPendingChange(value, _SucursalDestinoid)) { _SucursalDestinoid = value; OnPropertyChanged(); } } }

        private string? _SucursalDestinoclave;
        [XmlAttribute]
        public string? SucursalDestinoclave { get => _SucursalDestinoclave; set { if (RaiseAcceptPendingChange(value, _SucursalDestinoclave)) { _SucursalDestinoclave = value; OnPropertyChanged(); } } }

        private string? _SucursalDestinonombre;
        [XmlAttribute]
        public string? SucursalDestinonombre { get => _SucursalDestinonombre; set { if (RaiseAcceptPendingChange(value, _SucursalDestinonombre)) { _SucursalDestinonombre = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

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

        private string? _UsuarioClave;
        [XmlAttribute]
        public string? UsuarioClave { get => _UsuarioClave; set { if (RaiseAcceptPendingChange(value, _UsuarioClave)) { _UsuarioClave = value; OnPropertyChanged(); } } }

        private string? _UsuarioNombre;
        [XmlAttribute]
        public string? UsuarioNombre { get => _UsuarioNombre; set { if (RaiseAcceptPendingChange(value, _UsuarioNombre)) { _UsuarioNombre = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldo { get => _Saldo?? 0; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _MontoAplicar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? MontoAplicar { get => _MontoAplicar?? 0; set { if (RaiseAcceptPendingChange(value, _MontoAplicar)) { _MontoAplicar = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _EsFacturaEletronica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? EsFacturaEletronica { get => _EsFacturaEletronica?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _EsFacturaEletronica)) { _EsFacturaEletronica = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _EstaTimbrado;
        [XmlAttribute]
        public string? EstaTimbrado { get => _EstaTimbrado; set { if (RaiseAcceptPendingChange(value, _EstaTimbrado)) { _EstaTimbrado = value; OnPropertyChanged(); } } }

        private string? _SerieFolioSat;
        [XmlAttribute]
        public string? SerieFolioSat { get => _SerieFolioSat; set { if (RaiseAcceptPendingChange(value, _SerieFolioSat)) { _SerieFolioSat = value; OnPropertyChanged(); } } }

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


        public static V_docto_con_saldoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_docto_con_saldoWFBindingModel = new V_docto_con_saldoWFBindingModel();

        	buffer_V_docto_con_saldoWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_docto_con_saldoWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_docto_con_saldoWFBindingModel._Id = obj.Id;

        	buffer_V_docto_con_saldoWFBindingModel._Sucursal_info_id = obj.Sucursal_info_id;

        	buffer_V_docto_con_saldoWFBindingModel._Sucursal_info_clave = obj.Sucursal_info_clave;

        	buffer_V_docto_con_saldoWFBindingModel._Sucursal_info_nombre = obj.Sucursal_info_nombre;

        	buffer_V_docto_con_saldoWFBindingModel._Cajaid = obj.Cajaid;

        	buffer_V_docto_con_saldoWFBindingModel._Cajaclave = obj.Cajaclave;

        	buffer_V_docto_con_saldoWFBindingModel._Cajanombre = obj.Cajanombre;

        	buffer_V_docto_con_saldoWFBindingModel._Fecha = obj.Fecha;

        	buffer_V_docto_con_saldoWFBindingModel._Serie = obj.Serie;

        	buffer_V_docto_con_saldoWFBindingModel._Total = obj.Total;

        	buffer_V_docto_con_saldoWFBindingModel._Estatusdoctoid = obj.Estatusdoctoid;

        	buffer_V_docto_con_saldoWFBindingModel._Estatusdoctoclave = obj.Estatusdoctoclave;

        	buffer_V_docto_con_saldoWFBindingModel._Estatusdoctonombre = obj.Estatusdoctonombre;

        	buffer_V_docto_con_saldoWFBindingModel._Tipodoctoid = obj.Tipodoctoid;

        	buffer_V_docto_con_saldoWFBindingModel._Tipodoctoclave = obj.Tipodoctoclave;

        	buffer_V_docto_con_saldoWFBindingModel._Tipodoctonombre = obj.Tipodoctonombre;

        	buffer_V_docto_con_saldoWFBindingModel._Referencia = obj.Referencia;

        	buffer_V_docto_con_saldoWFBindingModel._SucursalDestinoid = obj.SucursalDestinoid;

        	buffer_V_docto_con_saldoWFBindingModel._SucursalDestinoclave = obj.SucursalDestinoclave;

        	buffer_V_docto_con_saldoWFBindingModel._SucursalDestinonombre = obj.SucursalDestinonombre;

        	buffer_V_docto_con_saldoWFBindingModel._Folio = obj.Folio;

        	buffer_V_docto_con_saldoWFBindingModel._ClienteClave = obj.ClienteClave;

        	buffer_V_docto_con_saldoWFBindingModel._ClienteNombre = obj.ClienteNombre;

        	buffer_V_docto_con_saldoWFBindingModel._ProveedorClave = obj.ProveedorClave;

        	buffer_V_docto_con_saldoWFBindingModel._ProveedorNombre = obj.ProveedorNombre;

        	buffer_V_docto_con_saldoWFBindingModel._UsuarioClave = obj.UsuarioClave;

        	buffer_V_docto_con_saldoWFBindingModel._UsuarioNombre = obj.UsuarioNombre;

        	buffer_V_docto_con_saldoWFBindingModel._Saldo = obj.Saldo;

        	buffer_V_docto_con_saldoWFBindingModel._MontoAplicar = obj.MontoAplicar;

        	buffer_V_docto_con_saldoWFBindingModel._EsFacturaEletronica = obj.EsFacturaEletronica;

        	buffer_V_docto_con_saldoWFBindingModel._EstaTimbrado = obj.EstaTimbrado;

        	buffer_V_docto_con_saldoWFBindingModel._SerieFolioSat = obj.SerieFolioSat;

            return buffer_V_docto_con_saldoWFBindingModel;
        }


    }

    
     
}

