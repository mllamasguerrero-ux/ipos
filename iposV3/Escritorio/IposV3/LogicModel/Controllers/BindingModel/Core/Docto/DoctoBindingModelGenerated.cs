
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
    
    public class DoctoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public DoctoBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public DoctoBindingModelGenerated(Docto item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

        #endif



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

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private BoolCN? _Esapartado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esapartado { get => _Esapartado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esapartado)) { _Esapartado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private string? _Referencias;
        [XmlAttribute]
        public string? Referencias { get => _Referencias; set { if (RaiseAcceptPendingChange(value, _Referencias)) { _Referencias = value; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _EstatusdoctoClave;
        [XmlAttribute]
        public string? EstatusdoctoClave { get => _EstatusdoctoClave; set { if (RaiseAcceptPendingChange(value, _EstatusdoctoClave)) { _EstatusdoctoClave = value; OnPropertyChanged(); } } }

        private string? _EstatusdoctoNombre;
        [XmlAttribute]
        public string? EstatusdoctoNombre { get => _EstatusdoctoNombre; set { if (RaiseAcceptPendingChange(value, _EstatusdoctoNombre)) { _EstatusdoctoNombre = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private string? _UsuarioClave;
        [XmlAttribute]
        public string? UsuarioClave { get => _UsuarioClave; set { if (RaiseAcceptPendingChange(value, _UsuarioClave)) { _UsuarioClave = value; OnPropertyChanged(); } } }

        private string? _UsuarioNombre;
        [XmlAttribute]
        public string? UsuarioNombre { get => _UsuarioNombre; set { if (RaiseAcceptPendingChange(value, _UsuarioNombre)) { _UsuarioNombre = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private string? _CorteClave;
        [XmlAttribute]
        public string? CorteClave { get => _CorteClave; set { if (RaiseAcceptPendingChange(value, _CorteClave)) { _CorteClave = value; OnPropertyChanged(); } } }

        private string? _CorteNombre;
        [XmlAttribute]
        public string? CorteNombre { get => _CorteNombre; set { if (RaiseAcceptPendingChange(value, _CorteNombre)) { _CorteNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

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

        private decimal? _Cargo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cargo { get => _Cargo?? 0; set { if (RaiseAcceptPendingChange(value, _Cargo)) { _Cargo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Abono { get => _Abono?? 0; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldo { get => _Saldo?? 0; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value?? 0; OnPropertyChanged(); } } }

        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private string? _CajaClave;
        [XmlAttribute]
        public string? CajaClave { get => _CajaClave; set { if (RaiseAcceptPendingChange(value, _CajaClave)) { _CajaClave = value; OnPropertyChanged(); } } }

        private string? _CajaNombre;
        [XmlAttribute]
        public string? CajaNombre { get => _CajaNombre; set { if (RaiseAcceptPendingChange(value, _CajaNombre)) { _CajaNombre = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _AlmacenClave;
        [XmlAttribute]
        public string? AlmacenClave { get => _AlmacenClave; set { if (RaiseAcceptPendingChange(value, _AlmacenClave)) { _AlmacenClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenNombre;
        [XmlAttribute]
        public string? AlmacenNombre { get => _AlmacenNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenNombre)) { _AlmacenNombre = value; OnPropertyChanged(); } } }

        private long? _Origenfiscalid;
        [XmlAttribute]
        public long? Origenfiscalid { get => _Origenfiscalid; set { if (RaiseAcceptPendingChange(value, _Origenfiscalid)) { _Origenfiscalid = value; OnPropertyChanged(); } } }

        private string? _OrigenfiscalClave;
        [XmlAttribute]
        public string? OrigenfiscalClave { get => _OrigenfiscalClave; set { if (RaiseAcceptPendingChange(value, _OrigenfiscalClave)) { _OrigenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _OrigenfiscalNombre;
        [XmlAttribute]
        public string? OrigenfiscalNombre { get => _OrigenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _OrigenfiscalNombre)) { _OrigenfiscalNombre = value; OnPropertyChanged(); } } }

        private long? _Doctoparentid;
        [XmlAttribute]
        public long? Doctoparentid { get => _Doctoparentid; set { if (RaiseAcceptPendingChange(value, _Doctoparentid)) { _Doctoparentid = value; OnPropertyChanged(); } } }

        private string? _DoctoparentClave;
        [XmlAttribute]
        public string? DoctoparentClave { get => _DoctoparentClave; set { if (RaiseAcceptPendingChange(value, _DoctoparentClave)) { _DoctoparentClave = value; OnPropertyChanged(); } } }

        private string? _DoctoparentNombre;
        [XmlAttribute]
        public string? DoctoparentNombre { get => _DoctoparentNombre; set { if (RaiseAcceptPendingChange(value, _DoctoparentNombre)) { _DoctoparentNombre = value; OnPropertyChanged(); } } }

        private long? _Clienteid;
        [XmlAttribute]
        public long? Clienteid { get => _Clienteid; set { if (RaiseAcceptPendingChange(value, _Clienteid)) { _Clienteid = value; OnPropertyChanged(); } } }

        private string? _ClienteClave;
        [XmlAttribute]
        public string? ClienteClave { get => _ClienteClave; set { if (RaiseAcceptPendingChange(value, _ClienteClave)) { _ClienteClave = value; OnPropertyChanged(); } } }

        private string? _ClienteNombre;
        [XmlAttribute]
        public string? ClienteNombre { get => _ClienteNombre; set { if (RaiseAcceptPendingChange(value, _ClienteNombre)) { _ClienteNombre = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { 
                if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { 
                        _Tipodoctoid = value; OnPropertyChanged(); 
                } } }

        private string? _TipodoctoClave;
        [XmlAttribute]
        public string? TipodoctoClave { get => _TipodoctoClave; set { if (RaiseAcceptPendingChange(value, _TipodoctoClave)) { _TipodoctoClave = value; OnPropertyChanged(); } } }

        private string? _TipodoctoNombre;
        [XmlAttribute]
        public string? TipodoctoNombre { get => _TipodoctoNombre; set { if (RaiseAcceptPendingChange(value, _TipodoctoNombre)) { _TipodoctoNombre = value; OnPropertyChanged(); } } }

        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }

        private string? _ProveedorClave;
        [XmlAttribute]
        public string? ProveedorClave { get => _ProveedorClave; set { if (RaiseAcceptPendingChange(value, _ProveedorClave)) { _ProveedorClave = value; OnPropertyChanged(); } } }

        private string? _ProveedorNombre;
        [XmlAttribute]
        public string? ProveedorNombre { get => _ProveedorNombre; set { if (RaiseAcceptPendingChange(value, _ProveedorNombre)) { _ProveedorNombre = value; OnPropertyChanged(); } } }

        private long? _Sucursal_id;
        [XmlAttribute]
        public long? Sucursal_id { get => _Sucursal_id; set { if (RaiseAcceptPendingChange(value, _Sucursal_id)) { _Sucursal_id = value; OnPropertyChanged(); } } }

        private string? _Sucursal_infoClave;
        [XmlAttribute]
        public string? Sucursal_infoClave { get => _Sucursal_infoClave; set { if (RaiseAcceptPendingChange(value, _Sucursal_infoClave)) { _Sucursal_infoClave = value; OnPropertyChanged(); } } }

        private string? _Sucursal_infoNombre;
        [XmlAttribute]
        public string? Sucursal_infoNombre { get => _Sucursal_infoNombre; set { if (RaiseAcceptPendingChange(value, _Sucursal_infoNombre)) { _Sucursal_infoNombre = value; OnPropertyChanged(); } } }

        private long? _Subtipodoctoid;
        [XmlAttribute]
        public long? Subtipodoctoid { get => _Subtipodoctoid; set { if (RaiseAcceptPendingChange(value, _Subtipodoctoid)) { _Subtipodoctoid = value; OnPropertyChanged(); } } }

        private string? _SubtipodoctoClave;
        [XmlAttribute]
        public string? SubtipodoctoClave { get => _SubtipodoctoClave; set { if (RaiseAcceptPendingChange(value, _SubtipodoctoClave)) { _SubtipodoctoClave = value; OnPropertyChanged(); } } }

        private string? _SubtipodoctoNombre;
        [XmlAttribute]
        public string? SubtipodoctoNombre { get => _SubtipodoctoNombre; set { if (RaiseAcceptPendingChange(value, _SubtipodoctoNombre)) { _SubtipodoctoNombre = value; OnPropertyChanged(); } } }

        private long? _Tipodiferenciainventarioid;
        [XmlAttribute]
        public long? Tipodiferenciainventarioid { get => _Tipodiferenciainventarioid; set { if (RaiseAcceptPendingChange(value, _Tipodiferenciainventarioid)) { _Tipodiferenciainventarioid = value; OnPropertyChanged(); } } }

        private string? _TipodiferenciainventarioClave;
        [XmlAttribute]
        public string? TipodiferenciainventarioClave { get => _TipodiferenciainventarioClave; set { if (RaiseAcceptPendingChange(value, _TipodiferenciainventarioClave)) { _TipodiferenciainventarioClave = value; OnPropertyChanged(); } } }

        private string? _TipodiferenciainventarioNombre;
        [XmlAttribute]
        public string? TipodiferenciainventarioNombre { get => _TipodiferenciainventarioNombre; set { if (RaiseAcceptPendingChange(value, _TipodiferenciainventarioNombre)) { _TipodiferenciainventarioNombre = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private long? _Docto_alerta_Autorizoalertaid;
        [XmlAttribute]
        public long? Docto_alerta_Autorizoalertaid { get => _Docto_alerta_Autorizoalertaid; set { if (RaiseAcceptPendingChange(value, _Docto_alerta_Autorizoalertaid)) { _Docto_alerta_Autorizoalertaid = value; OnPropertyChanged(); } } }

        private string? _Docto_alerta_AutorizoalertaClave;
        [XmlAttribute]
        public string? Docto_alerta_AutorizoalertaClave { get => _Docto_alerta_AutorizoalertaClave; set { if (RaiseAcceptPendingChange(value, _Docto_alerta_AutorizoalertaClave)) { _Docto_alerta_AutorizoalertaClave = value; OnPropertyChanged(); } } }

        private string? _Docto_alerta_AutorizoalertaNombre;
        [XmlAttribute]
        public string? Docto_alerta_AutorizoalertaNombre { get => _Docto_alerta_AutorizoalertaNombre; set { if (RaiseAcceptPendingChange(value, _Docto_alerta_AutorizoalertaNombre)) { _Docto_alerta_AutorizoalertaNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_apartado_Mercanciaentregada;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_apartado_Mercanciaentregada { get => _Docto_apartado_Mercanciaentregada?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_apartado_Mercanciaentregada)) { _Docto_apartado_Mercanciaentregada = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Docto_apartado_Personaapartadoid;
        [XmlAttribute]
        public long? Docto_apartado_Personaapartadoid { get => _Docto_apartado_Personaapartadoid; set { if (RaiseAcceptPendingChange(value, _Docto_apartado_Personaapartadoid)) { _Docto_apartado_Personaapartadoid = value; OnPropertyChanged(); } } }

        private string? _Docto_apartado_PersonaapartadoClave;
        [XmlAttribute]
        public string? Docto_apartado_PersonaapartadoClave { get => _Docto_apartado_PersonaapartadoClave; set { if (RaiseAcceptPendingChange(value, _Docto_apartado_PersonaapartadoClave)) { _Docto_apartado_PersonaapartadoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_apartado_PersonaapartadoNombre;
        [XmlAttribute]
        public string? Docto_apartado_PersonaapartadoNombre { get => _Docto_apartado_PersonaapartadoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_apartado_PersonaapartadoNombre)) { _Docto_apartado_PersonaapartadoNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_bancomer_Pagobancomeraplicado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_bancomer_Pagobancomeraplicado { get => _Docto_bancomer_Pagobancomeraplicado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_bancomer_Pagobancomeraplicado)) { _Docto_bancomer_Pagobancomeraplicado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_cobranza_Fechaaprobacioncxc;
        [XmlAttribute]
        public DateTimeOffset? Docto_cobranza_Fechaaprobacioncxc { get => _Docto_cobranza_Fechaaprobacioncxc; set { if (RaiseAcceptPendingChange(value, _Docto_cobranza_Fechaaprobacioncxc)) { _Docto_cobranza_Fechaaprobacioncxc = value; OnPropertyChanged(); } } }

        private long? _Docto_cobranza_Personaidaprobacioncxc;
        [XmlAttribute]
        public long? Docto_cobranza_Personaidaprobacioncxc { get => _Docto_cobranza_Personaidaprobacioncxc; set { if (RaiseAcceptPendingChange(value, _Docto_cobranza_Personaidaprobacioncxc)) { _Docto_cobranza_Personaidaprobacioncxc = value; OnPropertyChanged(); } } }

        private string? _Docto_cobranza_PersonaaprobacioncxcClave;
        [XmlAttribute]
        public string? Docto_cobranza_PersonaaprobacioncxcClave { get => _Docto_cobranza_PersonaaprobacioncxcClave; set { if (RaiseAcceptPendingChange(value, _Docto_cobranza_PersonaaprobacioncxcClave)) { _Docto_cobranza_PersonaaprobacioncxcClave = value; OnPropertyChanged(); } } }

        private string? _Docto_cobranza_PersonaaprobacioncxcNombre;
        [XmlAttribute]
        public string? Docto_cobranza_PersonaaprobacioncxcNombre { get => _Docto_cobranza_PersonaaprobacioncxcNombre; set { if (RaiseAcceptPendingChange(value, _Docto_cobranza_PersonaaprobacioncxcNombre)) { _Docto_cobranza_PersonaaprobacioncxcNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_comision_Vendedorfinal;
        [XmlAttribute]
        public long? Docto_comision_Vendedorfinal { get => _Docto_comision_Vendedorfinal; set { if (RaiseAcceptPendingChange(value, _Docto_comision_Vendedorfinal)) { _Docto_comision_Vendedorfinal = value; OnPropertyChanged(); } } }

        private string? _Docto_comision_Vendedorfinal_Clave;
        [XmlAttribute]
        public string? Docto_comision_Vendedorfinal_Clave { get => _Docto_comision_Vendedorfinal_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_comision_Vendedorfinal_Clave)) { _Docto_comision_Vendedorfinal_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_comision_Vendedorfinal_Nombre;
        [XmlAttribute]
        public string? Docto_comision_Vendedorfinal_Nombre { get => _Docto_comision_Vendedorfinal_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_comision_Vendedorfinal_Nombre)) { _Docto_comision_Vendedorfinal_Nombre = value; OnPropertyChanged(); } } }

        private long? _Docto_comision_Vendedorejecutivoid;
        [XmlAttribute]
        public long? Docto_comision_Vendedorejecutivoid { get => _Docto_comision_Vendedorejecutivoid; set { if (RaiseAcceptPendingChange(value, _Docto_comision_Vendedorejecutivoid)) { _Docto_comision_Vendedorejecutivoid = value; OnPropertyChanged(); } } }

        private string? _Docto_comision_VendedorejecutivoClave;
        [XmlAttribute]
        public string? Docto_comision_VendedorejecutivoClave { get => _Docto_comision_VendedorejecutivoClave; set { if (RaiseAcceptPendingChange(value, _Docto_comision_VendedorejecutivoClave)) { _Docto_comision_VendedorejecutivoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_comision_VendedorejecutivoNombre;
        [XmlAttribute]
        public string? Docto_comision_VendedorejecutivoNombre { get => _Docto_comision_VendedorejecutivoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_comision_VendedorejecutivoNombre)) { _Docto_comision_VendedorejecutivoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Docto_comision_Comision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_comision_Comision { get => _Docto_comision_Comision?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_comision_Comision)) { _Docto_comision_Comision = value?? 0; OnPropertyChanged(); } } }

        private string? _Docto_compra_Folio;
        [XmlAttribute]
        public string? Docto_compra_Folio { get => _Docto_compra_Folio; set { if (RaiseAcceptPendingChange(value, _Docto_compra_Folio)) { _Docto_compra_Folio = value; OnPropertyChanged(); } } }

        private string? _Docto_compra_Factura;
        [XmlAttribute]
        public string? Docto_compra_Factura { get => _Docto_compra_Factura; set { if (RaiseAcceptPendingChange(value, _Docto_compra_Factura)) { _Docto_compra_Factura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_compra_Fechafactura;
        [XmlAttribute]
        public DateTimeOffset? Docto_compra_Fechafactura { get => _Docto_compra_Fechafactura; set { if (RaiseAcceptPendingChange(value, _Docto_compra_Fechafactura)) { _Docto_compra_Fechafactura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Docto_contrarecibo_Contrareciboid;
        [XmlAttribute]
        public long? Docto_contrarecibo_Contrareciboid { get => _Docto_contrarecibo_Contrareciboid; set { if (RaiseAcceptPendingChange(value, _Docto_contrarecibo_Contrareciboid)) { _Docto_contrarecibo_Contrareciboid = value; OnPropertyChanged(); } } }

        private string? _Docto_contrarecibo_ContrareciboClave;
        [XmlAttribute]
        public string? Docto_contrarecibo_ContrareciboClave { get => _Docto_contrarecibo_ContrareciboClave; set { if (RaiseAcceptPendingChange(value, _Docto_contrarecibo_ContrareciboClave)) { _Docto_contrarecibo_ContrareciboClave = value; OnPropertyChanged(); } } }

        private string? _Docto_contrarecibo_ContrareciboNombre;
        [XmlAttribute]
        public string? Docto_contrarecibo_ContrareciboNombre { get => _Docto_contrarecibo_ContrareciboNombre; set { if (RaiseAcceptPendingChange(value, _Docto_contrarecibo_ContrareciboNombre)) { _Docto_contrarecibo_ContrareciboNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_cancelacion_Doctorefid;
        [XmlAttribute]
        public long? Docto_cancelacion_Doctorefid { get => _Docto_cancelacion_Doctorefid; set { if (RaiseAcceptPendingChange(value, _Docto_cancelacion_Doctorefid)) { _Docto_cancelacion_Doctorefid = value; OnPropertyChanged(); } } }

        private string? _Docto_cancelacion_DoctorefClave;
        [XmlAttribute]
        public string? Docto_cancelacion_DoctorefClave { get => _Docto_cancelacion_DoctorefClave; set { if (RaiseAcceptPendingChange(value, _Docto_cancelacion_DoctorefClave)) { _Docto_cancelacion_DoctorefClave = value; OnPropertyChanged(); } } }

        private string? _Docto_cancelacion_DoctorefNombre;
        [XmlAttribute]
        public string? Docto_cancelacion_DoctorefNombre { get => _Docto_cancelacion_DoctorefNombre; set { if (RaiseAcceptPendingChange(value, _Docto_cancelacion_DoctorefNombre)) { _Docto_cancelacion_DoctorefNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_devolucion_Doctorefid;
        [XmlAttribute]
        public long? Docto_devolucion_Doctorefid { get => _Docto_devolucion_Doctorefid; set { if (RaiseAcceptPendingChange(value, _Docto_devolucion_Doctorefid)) { _Docto_devolucion_Doctorefid = value; OnPropertyChanged(); } } }

        private string? _Docto_devolucion_DoctorefClave;
        [XmlAttribute]
        public string? Docto_devolucion_DoctorefClave { get => _Docto_devolucion_DoctorefClave; set { if (RaiseAcceptPendingChange(value, _Docto_devolucion_DoctorefClave)) { _Docto_devolucion_DoctorefClave = value; OnPropertyChanged(); } } }

        private string? _Docto_devolucion_DoctorefNombre;
        [XmlAttribute]
        public string? Docto_devolucion_DoctorefNombre { get => _Docto_devolucion_DoctorefNombre; set { if (RaiseAcceptPendingChange(value, _Docto_devolucion_DoctorefNombre)) { _Docto_devolucion_DoctorefNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_loteimportado_Loteimportadodoctoid;
        [XmlAttribute]
        public long? Docto_loteimportado_Loteimportadodoctoid { get => _Docto_loteimportado_Loteimportadodoctoid; set { if (RaiseAcceptPendingChange(value, _Docto_loteimportado_Loteimportadodoctoid)) { _Docto_loteimportado_Loteimportadodoctoid = value; OnPropertyChanged(); } } }

        private string? _Docto_loteimportado_LoteimportadodoctoClave;
        [XmlAttribute]
        public string? Docto_loteimportado_LoteimportadodoctoClave { get => _Docto_loteimportado_LoteimportadodoctoClave; set { if (RaiseAcceptPendingChange(value, _Docto_loteimportado_LoteimportadodoctoClave)) { _Docto_loteimportado_LoteimportadodoctoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_loteimportado_LoteimportadodoctoNombre;
        [XmlAttribute]
        public string? Docto_loteimportado_LoteimportadodoctoNombre { get => _Docto_loteimportado_LoteimportadodoctoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_loteimportado_LoteimportadodoctoNombre)) { _Docto_loteimportado_LoteimportadodoctoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_corte_Fechacorte;
        [XmlAttribute]
        public DateTimeOffset? Docto_corte_Fechacorte { get => _Docto_corte_Fechacorte; set { if (RaiseAcceptPendingChange(value, _Docto_corte_Fechacorte)) { _Docto_corte_Fechacorte = value; OnPropertyChanged(); } } }

        private long? _Docto_corte_Montobilletesid;
        [XmlAttribute]
        public long? Docto_corte_Montobilletesid { get => _Docto_corte_Montobilletesid; set { if (RaiseAcceptPendingChange(value, _Docto_corte_Montobilletesid)) { _Docto_corte_Montobilletesid = value; OnPropertyChanged(); } } }

        private string? _Docto_corte_MontobilletesClave;
        [XmlAttribute]
        public string? Docto_corte_MontobilletesClave { get => _Docto_corte_MontobilletesClave; set { if (RaiseAcceptPendingChange(value, _Docto_corte_MontobilletesClave)) { _Docto_corte_MontobilletesClave = value; OnPropertyChanged(); } } }

        private string? _Docto_corte_MontobilletesNombre;
        [XmlAttribute]
        public string? Docto_corte_MontobilletesNombre { get => _Docto_corte_MontobilletesNombre; set { if (RaiseAcceptPendingChange(value, _Docto_corte_MontobilletesNombre)) { _Docto_corte_MontobilletesNombre = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradouuid;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradouuid { get => _Docto_fact_elect_Timbradouuid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradouuid)) { _Docto_fact_elect_Timbradouuid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradofecha;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradofecha { get => _Docto_fact_elect_Timbradofecha; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradofecha)) { _Docto_fact_elect_Timbradofecha = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradocertsat;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradocertsat { get => _Docto_fact_elect_Timbradocertsat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradocertsat)) { _Docto_fact_elect_Timbradocertsat = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradosellosat;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradosellosat { get => _Docto_fact_elect_Timbradosellosat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradosellosat)) { _Docto_fact_elect_Timbradosellosat = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradosellocfdi;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradosellocfdi { get => _Docto_fact_elect_Timbradosellocfdi; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradosellocfdi)) { _Docto_fact_elect_Timbradosellocfdi = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_fact_elect_Timbradocancelado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_fact_elect_Timbradocancelado { get => _Docto_fact_elect_Timbradocancelado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradocancelado)) { _Docto_fact_elect_Timbradocancelado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradouuidcancelacion;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradouuidcancelacion { get => _Docto_fact_elect_Timbradouuidcancelacion; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradouuidcancelacion)) { _Docto_fact_elect_Timbradouuidcancelacion = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Timbradoformapagosat;
        [XmlAttribute]
        public string? Docto_fact_elect_Timbradoformapagosat { get => _Docto_fact_elect_Timbradoformapagosat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradoformapagosat)) { _Docto_fact_elect_Timbradoformapagosat = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Seriesat;
        [XmlAttribute]
        public string? Docto_fact_elect_Seriesat { get => _Docto_fact_elect_Seriesat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Seriesat)) { _Docto_fact_elect_Seriesat = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_fact_elect_Esfacturaelectronica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_fact_elect_Esfacturaelectronica { get => _Docto_fact_elect_Esfacturaelectronica?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Esfacturaelectronica)) { _Docto_fact_elect_Esfacturaelectronica = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_fact_elect_Timbradofechacancelacion;
        [XmlAttribute]
        public DateTimeOffset? Docto_fact_elect_Timbradofechacancelacion { get => _Docto_fact_elect_Timbradofechacancelacion; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradofechacancelacion)) { _Docto_fact_elect_Timbradofechacancelacion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_fact_elect_Timbradofechafactura;
        [XmlAttribute]
        public DateTimeOffset? Docto_fact_elect_Timbradofechafactura { get => _Docto_fact_elect_Timbradofechafactura; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Timbradofechafactura)) { _Docto_fact_elect_Timbradofechafactura = value; OnPropertyChanged(); } } }

        private int? _Docto_fact_elect_Foliosat;
        [XmlAttribute]
        public int? Docto_fact_elect_Foliosat { get => _Docto_fact_elect_Foliosat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Foliosat)) { _Docto_fact_elect_Foliosat = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_fact_elect_Fechafactura;
        [XmlAttribute]
        public DateTimeOffset? Docto_fact_elect_Fechafactura { get => _Docto_fact_elect_Fechafactura; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Fechafactura)) { _Docto_fact_elect_Fechafactura = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_Sat_usocfdiid;
        [XmlAttribute]
        public long? Docto_fact_elect_Sat_usocfdiid { get => _Docto_fact_elect_Sat_usocfdiid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Sat_usocfdiid)) { _Docto_fact_elect_Sat_usocfdiid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Sat_usocfdiClave;
        [XmlAttribute]
        public string? Docto_fact_elect_Sat_usocfdiClave { get => _Docto_fact_elect_Sat_usocfdiClave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Sat_usocfdiClave)) { _Docto_fact_elect_Sat_usocfdiClave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_Sat_usocfdiNombre;
        [XmlAttribute]
        public string? Docto_fact_elect_Sat_usocfdiNombre { get => _Docto_fact_elect_Sat_usocfdiNombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Sat_usocfdiNombre)) { _Docto_fact_elect_Sat_usocfdiNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_Cfdiid;
        [XmlAttribute]
        public long? Docto_fact_elect_Cfdiid { get => _Docto_fact_elect_Cfdiid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Cfdiid)) { _Docto_fact_elect_Cfdiid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_CfdiClave;
        [XmlAttribute]
        public string? Docto_fact_elect_CfdiClave { get => _Docto_fact_elect_CfdiClave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_CfdiClave)) { _Docto_fact_elect_CfdiClave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_CfdiNombre;
        [XmlAttribute]
        public string? Docto_fact_elect_CfdiNombre { get => _Docto_fact_elect_CfdiNombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_CfdiNombre)) { _Docto_fact_elect_CfdiNombre = value; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_Ivaretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_Ivaretenido { get => _Docto_fact_elect_Ivaretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Ivaretenido)) { _Docto_fact_elect_Ivaretenido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_Isrretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_Isrretenido { get => _Docto_fact_elect_Isrretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_Isrretenido)) { _Docto_fact_elect_Isrretenido = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Docto_fact_elect_consolidacion_Factconsaplicado;
        [XmlAttribute]
        public BoolCN? Docto_fact_elect_consolidacion_Factconsaplicado { get => _Docto_fact_elect_consolidacion_Factconsaplicado; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Factconsaplicado)) { _Docto_fact_elect_consolidacion_Factconsaplicado = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_fact_elect_consolidacion_Omitirvales;
        [XmlAttribute]
        public BoolCN? Docto_fact_elect_consolidacion_Omitirvales { get => _Docto_fact_elect_consolidacion_Omitirvales; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Omitirvales)) { _Docto_fact_elect_consolidacion_Omitirvales = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_consolidacion_Factconsid;
        [XmlAttribute]
        public long? Docto_fact_elect_consolidacion_Factconsid { get => _Docto_fact_elect_consolidacion_Factconsid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Factconsid)) { _Docto_fact_elect_consolidacion_Factconsid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_consolidacion_FactconsClave;
        [XmlAttribute]
        public string? Docto_fact_elect_consolidacion_FactconsClave { get => _Docto_fact_elect_consolidacion_FactconsClave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_FactconsClave)) { _Docto_fact_elect_consolidacion_FactconsClave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_consolidacion_FactconsNombre;
        [XmlAttribute]
        public string? Docto_fact_elect_consolidacion_FactconsNombre { get => _Docto_fact_elect_consolidacion_FactconsNombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_FactconsNombre)) { _Docto_fact_elect_consolidacion_FactconsNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_consolidacion_Devconsid;
        [XmlAttribute]
        public long? Docto_fact_elect_consolidacion_Devconsid { get => _Docto_fact_elect_consolidacion_Devconsid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Devconsid)) { _Docto_fact_elect_consolidacion_Devconsid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_consolidacion_DevconsClave;
        [XmlAttribute]
        public string? Docto_fact_elect_consolidacion_DevconsClave { get => _Docto_fact_elect_consolidacion_DevconsClave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_DevconsClave)) { _Docto_fact_elect_consolidacion_DevconsClave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_consolidacion_DevconsNombre;
        [XmlAttribute]
        public string? Docto_fact_elect_consolidacion_DevconsNombre { get => _Docto_fact_elect_consolidacion_DevconsNombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_DevconsNombre)) { _Docto_fact_elect_consolidacion_DevconsNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_consolidacion_Doctorefid2;
        [XmlAttribute]
        public long? Docto_fact_elect_consolidacion_Doctorefid2 { get => _Docto_fact_elect_consolidacion_Doctorefid2; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Doctorefid2)) { _Docto_fact_elect_consolidacion_Doctorefid2 = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_consolidacion_Doctoref2Clave;
        [XmlAttribute]
        public string? Docto_fact_elect_consolidacion_Doctoref2Clave { get => _Docto_fact_elect_consolidacion_Doctoref2Clave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Doctoref2Clave)) { _Docto_fact_elect_consolidacion_Doctoref2Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_consolidacion_Doctoref2Nombre;
        [XmlAttribute]
        public string? Docto_fact_elect_consolidacion_Doctoref2Nombre { get => _Docto_fact_elect_consolidacion_Doctoref2Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Doctoref2Nombre)) { _Docto_fact_elect_consolidacion_Doctoref2Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_consolidacion_Consolidado_subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_consolidacion_Consolidado_subtotal { get => _Docto_fact_elect_consolidacion_Consolidado_subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Consolidado_subtotal)) { _Docto_fact_elect_consolidacion_Consolidado_subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_consolidacion_Consolidado_iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_consolidacion_Consolidado_iva { get => _Docto_fact_elect_consolidacion_Consolidado_iva?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Consolidado_iva)) { _Docto_fact_elect_consolidacion_Consolidado_iva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_consolidacion_Consolidado_ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_consolidacion_Consolidado_ieps { get => _Docto_fact_elect_consolidacion_Consolidado_ieps?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Consolidado_ieps)) { _Docto_fact_elect_consolidacion_Consolidado_ieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_consolidacion_Consolidado_total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_consolidacion_Consolidado_total { get => _Docto_fact_elect_consolidacion_Consolidado_total?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Consolidado_total)) { _Docto_fact_elect_consolidacion_Consolidado_total = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_consolidacion_Consolidado_iva_ret;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_consolidacion_Consolidado_iva_ret { get => _Docto_fact_elect_consolidacion_Consolidado_iva_ret?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Consolidado_iva_ret)) { _Docto_fact_elect_consolidacion_Consolidado_iva_ret = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_fact_elect_consolidacion_Consolidado_isr_ret;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_fact_elect_consolidacion_Consolidado_isr_ret { get => _Docto_fact_elect_consolidacion_Consolidado_isr_ret?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_consolidacion_Consolidado_isr_ret)) { _Docto_fact_elect_consolidacion_Consolidado_isr_ret = value?? 0; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_pagos_Timbradoformapagosat;
        [XmlAttribute]
        public string? Docto_fact_elect_pagos_Timbradoformapagosat { get => _Docto_fact_elect_pagos_Timbradoformapagosat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Timbradoformapagosat)) { _Docto_fact_elect_pagos_Timbradoformapagosat = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_pagos_Doctopagosat;
        [XmlAttribute]
        public long? Docto_fact_elect_pagos_Doctopagosat { get => _Docto_fact_elect_pagos_Doctopagosat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Doctopagosat)) { _Docto_fact_elect_pagos_Doctopagosat = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_pagos_Doctopagosat_Clave;
        [XmlAttribute]
        public string? Docto_fact_elect_pagos_Doctopagosat_Clave { get => _Docto_fact_elect_pagos_Doctopagosat_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Doctopagosat_Clave)) { _Docto_fact_elect_pagos_Doctopagosat_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_pagos_Doctopagosat_Nombre;
        [XmlAttribute]
        public string? Docto_fact_elect_pagos_Doctopagosat_Nombre { get => _Docto_fact_elect_pagos_Doctopagosat_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Doctopagosat_Nombre)) { _Docto_fact_elect_pagos_Doctopagosat_Nombre = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_pagos_Pagosat;
        [XmlAttribute]
        public long? Docto_fact_elect_pagos_Pagosat { get => _Docto_fact_elect_pagos_Pagosat; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Pagosat)) { _Docto_fact_elect_pagos_Pagosat = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_pagos_Pagosat_Clave;
        [XmlAttribute]
        public string? Docto_fact_elect_pagos_Pagosat_Clave { get => _Docto_fact_elect_pagos_Pagosat_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Pagosat_Clave)) { _Docto_fact_elect_pagos_Pagosat_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_pagos_Pagosat_Nombre;
        [XmlAttribute]
        public string? Docto_fact_elect_pagos_Pagosat_Nombre { get => _Docto_fact_elect_pagos_Pagosat_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_pagos_Pagosat_Nombre)) { _Docto_fact_elect_pagos_Pagosat_Nombre = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_sustitucion_Doctosustitutoid;
        [XmlAttribute]
        public long? Docto_fact_elect_sustitucion_Doctosustitutoid { get => _Docto_fact_elect_sustitucion_Doctosustitutoid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_sustitucion_Doctosustitutoid)) { _Docto_fact_elect_sustitucion_Doctosustitutoid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_sustitucion_DoctosustitutoClave;
        [XmlAttribute]
        public string? Docto_fact_elect_sustitucion_DoctosustitutoClave { get => _Docto_fact_elect_sustitucion_DoctosustitutoClave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_sustitucion_DoctosustitutoClave)) { _Docto_fact_elect_sustitucion_DoctosustitutoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_sustitucion_DoctosustitutoNombre;
        [XmlAttribute]
        public string? Docto_fact_elect_sustitucion_DoctosustitutoNombre { get => _Docto_fact_elect_sustitucion_DoctosustitutoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_sustitucion_DoctosustitutoNombre)) { _Docto_fact_elect_sustitucion_DoctosustitutoNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_fact_elect_sustitucion_Doctoasustituirid;
        [XmlAttribute]
        public long? Docto_fact_elect_sustitucion_Doctoasustituirid { get => _Docto_fact_elect_sustitucion_Doctoasustituirid; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_sustitucion_Doctoasustituirid)) { _Docto_fact_elect_sustitucion_Doctoasustituirid = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_sustitucion_DoctoasustituirClave;
        [XmlAttribute]
        public string? Docto_fact_elect_sustitucion_DoctoasustituirClave { get => _Docto_fact_elect_sustitucion_DoctoasustituirClave; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_sustitucion_DoctoasustituirClave)) { _Docto_fact_elect_sustitucion_DoctoasustituirClave = value; OnPropertyChanged(); } } }

        private string? _Docto_fact_elect_sustitucion_DoctoasustituirNombre;
        [XmlAttribute]
        public string? Docto_fact_elect_sustitucion_DoctoasustituirNombre { get => _Docto_fact_elect_sustitucion_DoctoasustituirNombre; set { if (RaiseAcceptPendingChange(value, _Docto_fact_elect_sustitucion_DoctoasustituirNombre)) { _Docto_fact_elect_sustitucion_DoctoasustituirNombre = value; OnPropertyChanged(); } } }

        private BoolManejoReceta? _Docto_farmacia_Manejoreceta;
        [XmlAttribute]
        public BoolManejoReceta? Docto_farmacia_Manejoreceta { get => _Docto_farmacia_Manejoreceta; set { if (RaiseAcceptPendingChange(value, _Docto_farmacia_Manejoreceta)) { _Docto_farmacia_Manejoreceta = value; OnPropertyChanged(); } } }

        private BoolCNI? _Docto_guia_Usardatosentrega;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCNI? Docto_guia_Usardatosentrega { get => _Docto_guia_Usardatosentrega?? BoolCNI.N; set { if (RaiseAcceptPendingChange(value, _Docto_guia_Usardatosentrega)) { _Docto_guia_Usardatosentrega = value?? BoolCNI.N; OnPropertyChanged(); } } }

        private long? _Docto_guia_Estadoguiaid;
        [XmlAttribute]
        public long? Docto_guia_Estadoguiaid { get => _Docto_guia_Estadoguiaid; set { if (RaiseAcceptPendingChange(value, _Docto_guia_Estadoguiaid)) { _Docto_guia_Estadoguiaid = value; OnPropertyChanged(); } } }

        private string? _Docto_guia_EstadoguiaClave;
        [XmlAttribute]
        public string? Docto_guia_EstadoguiaClave { get => _Docto_guia_EstadoguiaClave; set { if (RaiseAcceptPendingChange(value, _Docto_guia_EstadoguiaClave)) { _Docto_guia_EstadoguiaClave = value; OnPropertyChanged(); } } }

        private string? _Docto_guia_EstadoguiaNombre;
        [XmlAttribute]
        public string? Docto_guia_EstadoguiaNombre { get => _Docto_guia_EstadoguiaNombre; set { if (RaiseAcceptPendingChange(value, _Docto_guia_EstadoguiaNombre)) { _Docto_guia_EstadoguiaNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_guia_Guiaid;
        [XmlAttribute]
        public long? Docto_guia_Guiaid { get => _Docto_guia_Guiaid; set { if (RaiseAcceptPendingChange(value, _Docto_guia_Guiaid)) { _Docto_guia_Guiaid = value; OnPropertyChanged(); } } }

        private string? _Docto_guia_GuiaClave;
        [XmlAttribute]
        public string? Docto_guia_GuiaClave { get => _Docto_guia_GuiaClave; set { if (RaiseAcceptPendingChange(value, _Docto_guia_GuiaClave)) { _Docto_guia_GuiaClave = value; OnPropertyChanged(); } } }

        private string? _Docto_guia_GuiaNombre;
        [XmlAttribute]
        public string? Docto_guia_GuiaNombre { get => _Docto_guia_GuiaNombre; set { if (RaiseAcceptPendingChange(value, _Docto_guia_GuiaNombre)) { _Docto_guia_GuiaNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_guia_Fechaguiaenviado;
        [XmlAttribute]
        public DateTimeOffset? Docto_guia_Fechaguiaenviado { get => _Docto_guia_Fechaguiaenviado; set { if (RaiseAcceptPendingChange(value, _Docto_guia_Fechaguiaenviado)) { _Docto_guia_Fechaguiaenviado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_guia_Fechaguiarecibido;
        [XmlAttribute]
        public DateTimeOffset? Docto_guia_Fechaguiarecibido { get => _Docto_guia_Fechaguiarecibido; set { if (RaiseAcceptPendingChange(value, _Docto_guia_Fechaguiarecibido)) { _Docto_guia_Fechaguiarecibido = value; OnPropertyChanged(); } } }

        private long? _Docto_guia_Personaidguiarecibio;
        [XmlAttribute]
        public long? Docto_guia_Personaidguiarecibio { get => _Docto_guia_Personaidguiarecibio; set { if (RaiseAcceptPendingChange(value, _Docto_guia_Personaidguiarecibio)) { _Docto_guia_Personaidguiarecibio = value; OnPropertyChanged(); } } }

        private string? _Docto_guia_PersonaguiarecibioClave;
        [XmlAttribute]
        public string? Docto_guia_PersonaguiarecibioClave { get => _Docto_guia_PersonaguiarecibioClave; set { if (RaiseAcceptPendingChange(value, _Docto_guia_PersonaguiarecibioClave)) { _Docto_guia_PersonaguiarecibioClave = value; OnPropertyChanged(); } } }

        private string? _Docto_guia_PersonaguiarecibioNombre;
        [XmlAttribute]
        public string? Docto_guia_PersonaguiarecibioNombre { get => _Docto_guia_PersonaguiarecibioNombre; set { if (RaiseAcceptPendingChange(value, _Docto_guia_PersonaguiarecibioNombre)) { _Docto_guia_PersonaguiarecibioNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_kit_Kitdesglosado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_kit_Kitdesglosado { get => _Docto_kit_Kitdesglosado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Kitdesglosado)) { _Docto_kit_Kitdesglosado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Docto_kit_Doctokitrefid;
        [XmlAttribute]
        public long? Docto_kit_Doctokitrefid { get => _Docto_kit_Doctokitrefid; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Doctokitrefid)) { _Docto_kit_Doctokitrefid = value; OnPropertyChanged(); } } }

        private string? _Docto_kit_DoctokitrefClave;
        [XmlAttribute]
        public string? Docto_kit_DoctokitrefClave { get => _Docto_kit_DoctokitrefClave; set { if (RaiseAcceptPendingChange(value, _Docto_kit_DoctokitrefClave)) { _Docto_kit_DoctokitrefClave = value; OnPropertyChanged(); } } }

        private string? _Docto_kit_DoctokitrefNombre;
        [XmlAttribute]
        public string? Docto_kit_DoctokitrefNombre { get => _Docto_kit_DoctokitrefNombre; set { if (RaiseAcceptPendingChange(value, _Docto_kit_DoctokitrefNombre)) { _Docto_kit_DoctokitrefNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_kit_Prekitestatus;
        [XmlAttribute]
        public long? Docto_kit_Prekitestatus { get => _Docto_kit_Prekitestatus; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Prekitestatus)) { _Docto_kit_Prekitestatus = value; OnPropertyChanged(); } } }

        private string? _Docto_kit_Prekitestatus_Clave;
        [XmlAttribute]
        public string? Docto_kit_Prekitestatus_Clave { get => _Docto_kit_Prekitestatus_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Prekitestatus_Clave)) { _Docto_kit_Prekitestatus_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_kit_Prekitestatus_Nombre;
        [XmlAttribute]
        public string? Docto_kit_Prekitestatus_Nombre { get => _Docto_kit_Prekitestatus_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Prekitestatus_Nombre)) { _Docto_kit_Prekitestatus_Nombre = value; OnPropertyChanged(); } } }

        private long? _Docto_kit_Postkitestatus;
        [XmlAttribute]
        public long? Docto_kit_Postkitestatus { get => _Docto_kit_Postkitestatus; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Postkitestatus)) { _Docto_kit_Postkitestatus = value; OnPropertyChanged(); } } }

        private string? _Docto_kit_Postkitestatus_Clave;
        [XmlAttribute]
        public string? Docto_kit_Postkitestatus_Clave { get => _Docto_kit_Postkitestatus_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Postkitestatus_Clave)) { _Docto_kit_Postkitestatus_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_kit_Postkitestatus_Nombre;
        [XmlAttribute]
        public string? Docto_kit_Postkitestatus_Nombre { get => _Docto_kit_Postkitestatus_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Postkitestatus_Nombre)) { _Docto_kit_Postkitestatus_Nombre = value; OnPropertyChanged(); } } }

        private int? _Docto_kit_Versionkit;
        [XmlAttribute]
        public int? Docto_kit_Versionkit { get => _Docto_kit_Versionkit; set { if (RaiseAcceptPendingChange(value, _Docto_kit_Versionkit)) { _Docto_kit_Versionkit = value; OnPropertyChanged(); } } }

        private long? _Docto_monedero_Monedero;
        [XmlAttribute]
        public long? Docto_monedero_Monedero { get => _Docto_monedero_Monedero; set { if (RaiseAcceptPendingChange(value, _Docto_monedero_Monedero)) { _Docto_monedero_Monedero = value; OnPropertyChanged(); } } }

        private string? _Docto_monedero_Monedero_Clave;
        [XmlAttribute]
        public string? Docto_monedero_Monedero_Clave { get => _Docto_monedero_Monedero_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_monedero_Monedero_Clave)) { _Docto_monedero_Monedero_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_monedero_Monedero_Nombre;
        [XmlAttribute]
        public string? Docto_monedero_Monedero_Nombre { get => _Docto_monedero_Monedero_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_monedero_Monedero_Nombre)) { _Docto_monedero_Monedero_Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Docto_monedero_Descmonedero;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_monedero_Descmonedero { get => _Docto_monedero_Descmonedero?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_monedero_Descmonedero)) { _Docto_monedero_Descmonedero = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_monedero_Abonomonedero;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_monedero_Abonomonedero { get => _Docto_monedero_Abonomonedero?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_monedero_Abonomonedero)) { _Docto_monedero_Abonomonedero = value?? 0; OnPropertyChanged(); } } }

        private string? _Docto_ordencompra_Ordencompra;
        [XmlAttribute]
        public string? Docto_ordencompra_Ordencompra { get => _Docto_ordencompra_Ordencompra; set { if (RaiseAcceptPendingChange(value, _Docto_ordencompra_Ordencompra)) { _Docto_ordencompra_Ordencompra = value; OnPropertyChanged(); } } }

        private long? _Docto_ordencompra_Doctorefid;
        [XmlAttribute]
        public long? Docto_ordencompra_Doctorefid { get => _Docto_ordencompra_Doctorefid; set { if (RaiseAcceptPendingChange(value, _Docto_ordencompra_Doctorefid)) { _Docto_ordencompra_Doctorefid = value; OnPropertyChanged(); } } }

        private string? _Docto_ordencompra_DoctorefClave;
        [XmlAttribute]
        public string? Docto_ordencompra_DoctorefClave { get => _Docto_ordencompra_DoctorefClave; set { if (RaiseAcceptPendingChange(value, _Docto_ordencompra_DoctorefClave)) { _Docto_ordencompra_DoctorefClave = value; OnPropertyChanged(); } } }

        private string? _Docto_ordencompra_DoctorefNombre;
        [XmlAttribute]
        public string? Docto_ordencompra_DoctorefNombre { get => _Docto_ordencompra_DoctorefNombre; set { if (RaiseAcceptPendingChange(value, _Docto_ordencompra_DoctorefNombre)) { _Docto_ordencompra_DoctorefNombre = value; OnPropertyChanged(); } } }

        private string? _Docto_origenfiscal_Serieorigenfacturado;
        [XmlAttribute]
        public string? Docto_origenfiscal_Serieorigenfacturado { get => _Docto_origenfiscal_Serieorigenfacturado; set { if (RaiseAcceptPendingChange(value, _Docto_origenfiscal_Serieorigenfacturado)) { _Docto_origenfiscal_Serieorigenfacturado = value; OnPropertyChanged(); } } }

        private int? _Docto_origenfiscal_Folioorigenfacturado;
        [XmlAttribute]
        public int? Docto_origenfiscal_Folioorigenfacturado { get => _Docto_origenfiscal_Folioorigenfacturado; set { if (RaiseAcceptPendingChange(value, _Docto_origenfiscal_Folioorigenfacturado)) { _Docto_origenfiscal_Folioorigenfacturado = value; OnPropertyChanged(); } } }

        private decimal? _Docto_origenfiscal_Montoorigenfacturado;
        [XmlAttribute]
        public decimal? Docto_origenfiscal_Montoorigenfacturado { get => _Docto_origenfiscal_Montoorigenfacturado; set { if (RaiseAcceptPendingChange(value, _Docto_origenfiscal_Montoorigenfacturado)) { _Docto_origenfiscal_Montoorigenfacturado = value; OnPropertyChanged(); } } }

        private string? _Docto_info_pago_Notapago;
        [XmlAttribute]
        public string? Docto_info_pago_Notapago { get => _Docto_info_pago_Notapago; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Notapago)) { _Docto_info_pago_Notapago = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_info_pago_Hatenidocredito;
        [XmlAttribute]
        public BoolCN? Docto_info_pago_Hatenidocredito { get => _Docto_info_pago_Hatenidocredito; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Hatenidocredito)) { _Docto_info_pago_Hatenidocredito = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_info_pago_Pagoacredito;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_info_pago_Pagoacredito { get => _Docto_info_pago_Pagoacredito?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Pagoacredito)) { _Docto_info_pago_Pagoacredito = value?? BoolCN.N; OnPropertyChanged(); } } }

        private TipoPagoConTarjeta? _Docto_info_pago_Pagocontarjeta;
        [XmlAttribute]
        public TipoPagoConTarjeta? Docto_info_pago_Pagocontarjeta { get => _Docto_info_pago_Pagocontarjeta; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Pagocontarjeta)) { _Docto_info_pago_Pagocontarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Abononoaplicado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Abononoaplicado { get => _Docto_info_pago_Abononoaplicado?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Abononoaplicado)) { _Docto_info_pago_Abononoaplicado = value?? 0; OnPropertyChanged(); } } }

        private long? _Docto_info_pago_Pagodevid;
        [XmlAttribute]
        public long? Docto_info_pago_Pagodevid { get => _Docto_info_pago_Pagodevid; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Pagodevid)) { _Docto_info_pago_Pagodevid = value; OnPropertyChanged(); } } }

        private string? _Docto_info_pago_PagodevClave;
        [XmlAttribute]
        public string? Docto_info_pago_PagodevClave { get => _Docto_info_pago_PagodevClave; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_PagodevClave)) { _Docto_info_pago_PagodevClave = value; OnPropertyChanged(); } } }

        private string? _Docto_info_pago_PagodevNombre;
        [XmlAttribute]
        public string? Docto_info_pago_PagodevNombre { get => _Docto_info_pago_PagodevNombre; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_PagodevNombre)) { _Docto_info_pago_PagodevNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_info_pago_Estatusanticipoid;
        [XmlAttribute]
        public long? Docto_info_pago_Estatusanticipoid { get => _Docto_info_pago_Estatusanticipoid; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Estatusanticipoid)) { _Docto_info_pago_Estatusanticipoid = value; OnPropertyChanged(); } } }

        private string? _Docto_info_pago_EstatusanticipoClave;
        [XmlAttribute]
        public string? Docto_info_pago_EstatusanticipoClave { get => _Docto_info_pago_EstatusanticipoClave; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_EstatusanticipoClave)) { _Docto_info_pago_EstatusanticipoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_info_pago_EstatusanticipoNombre;
        [XmlAttribute]
        public string? Docto_info_pago_EstatusanticipoNombre { get => _Docto_info_pago_EstatusanticipoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_EstatusanticipoNombre)) { _Docto_info_pago_EstatusanticipoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Totalanticipo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Totalanticipo { get => _Docto_info_pago_Totalanticipo?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Totalanticipo)) { _Docto_info_pago_Totalanticipo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Comisionpagotarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Comisionpagotarjeta { get => _Docto_info_pago_Comisionpagotarjeta?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Comisionpagotarjeta)) { _Docto_info_pago_Comisionpagotarjeta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Comisiontarjetaempresa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Comisiontarjetaempresa { get => _Docto_info_pago_Comisiontarjetaempresa?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Comisiontarjetaempresa)) { _Docto_info_pago_Comisiontarjetaempresa = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Ivacomisiontarjetaempresa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Ivacomisiontarjetaempresa { get => _Docto_info_pago_Ivacomisiontarjetaempresa?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Ivacomisiontarjetaempresa)) { _Docto_info_pago_Ivacomisiontarjetaempresa = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Abonotarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Abonotarjeta { get => _Docto_info_pago_Abonotarjeta?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Abonotarjeta)) { _Docto_info_pago_Abonotarjeta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_info_pago_Comisiondebtarjetaempresa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_info_pago_Comisiondebtarjetaempresa { get => _Docto_info_pago_Comisiondebtarjetaempresa?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_info_pago_Comisiondebtarjetaempresa)) { _Docto_info_pago_Comisiondebtarjetaempresa = value?? 0; OnPropertyChanged(); } } }

        private long? _Docto_poliza_Doctoplazoorigenid;
        [XmlAttribute]
        public long? Docto_poliza_Doctoplazoorigenid { get => _Docto_poliza_Doctoplazoorigenid; set { if (RaiseAcceptPendingChange(value, _Docto_poliza_Doctoplazoorigenid)) { _Docto_poliza_Doctoplazoorigenid = value; OnPropertyChanged(); } } }

        private string? _Docto_poliza_DoctoplazoorigenClave;
        [XmlAttribute]
        public string? Docto_poliza_DoctoplazoorigenClave { get => _Docto_poliza_DoctoplazoorigenClave; set { if (RaiseAcceptPendingChange(value, _Docto_poliza_DoctoplazoorigenClave)) { _Docto_poliza_DoctoplazoorigenClave = value; OnPropertyChanged(); } } }

        private string? _Docto_poliza_DoctoplazoorigenNombre;
        [XmlAttribute]
        public string? Docto_poliza_DoctoplazoorigenNombre { get => _Docto_poliza_DoctoplazoorigenNombre; set { if (RaiseAcceptPendingChange(value, _Docto_poliza_DoctoplazoorigenNombre)) { _Docto_poliza_DoctoplazoorigenNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_poliza_Plazoid;
        [XmlAttribute]
        public long? Docto_poliza_Plazoid { get => _Docto_poliza_Plazoid; set { if (RaiseAcceptPendingChange(value, _Docto_poliza_Plazoid)) { _Docto_poliza_Plazoid = value; OnPropertyChanged(); } } }

        private string? _Docto_poliza_PlazoClave;
        [XmlAttribute]
        public string? Docto_poliza_PlazoClave { get => _Docto_poliza_PlazoClave; set { if (RaiseAcceptPendingChange(value, _Docto_poliza_PlazoClave)) { _Docto_poliza_PlazoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_poliza_PlazoNombre;
        [XmlAttribute]
        public string? Docto_poliza_PlazoNombre { get => _Docto_poliza_PlazoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_poliza_PlazoNombre)) { _Docto_poliza_PlazoNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_precio_Tipomayoreoid;
        [XmlAttribute]
        public long? Docto_precio_Tipomayoreoid { get => _Docto_precio_Tipomayoreoid; set { if (RaiseAcceptPendingChange(value, _Docto_precio_Tipomayoreoid)) { _Docto_precio_Tipomayoreoid = value; OnPropertyChanged(); } } }

        private string? _Docto_precio_TipomayoreoClave;
        [XmlAttribute]
        public string? Docto_precio_TipomayoreoClave { get => _Docto_precio_TipomayoreoClave; set { if (RaiseAcceptPendingChange(value, _Docto_precio_TipomayoreoClave)) { _Docto_precio_TipomayoreoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_precio_TipomayoreoNombre;
        [XmlAttribute]
        public string? Docto_precio_TipomayoreoNombre { get => _Docto_precio_TipomayoreoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_precio_TipomayoreoNombre)) { _Docto_precio_TipomayoreoNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_precio_Tipodescuentovale;
        [XmlAttribute]
        public long? Docto_precio_Tipodescuentovale { get => _Docto_precio_Tipodescuentovale; set { if (RaiseAcceptPendingChange(value, _Docto_precio_Tipodescuentovale)) { _Docto_precio_Tipodescuentovale = value; OnPropertyChanged(); } } }

        private string? _Docto_precio_Tipodescuentovale_Clave;
        [XmlAttribute]
        public string? Docto_precio_Tipodescuentovale_Clave { get => _Docto_precio_Tipodescuentovale_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_precio_Tipodescuentovale_Clave)) { _Docto_precio_Tipodescuentovale_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_precio_Tipodescuentovale_Nombre;
        [XmlAttribute]
        public string? Docto_precio_Tipodescuentovale_Nombre { get => _Docto_precio_Tipodescuentovale_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_precio_Tipodescuentovale_Nombre)) { _Docto_precio_Tipodescuentovale_Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_promocion_Promocion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_promocion_Promocion { get => _Docto_promocion_Promocion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_promocion_Promocion)) { _Docto_promocion_Promocion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Docto_rebajaespecial_Estadorebaja;
        [XmlAttribute]
        public long? Docto_rebajaespecial_Estadorebaja { get => _Docto_rebajaespecial_Estadorebaja; set { if (RaiseAcceptPendingChange(value, _Docto_rebajaespecial_Estadorebaja)) { _Docto_rebajaespecial_Estadorebaja = value; OnPropertyChanged(); } } }

        private string? _Docto_rebajaespecial_Estadorebaja_Clave;
        [XmlAttribute]
        public string? Docto_rebajaespecial_Estadorebaja_Clave { get => _Docto_rebajaespecial_Estadorebaja_Clave; set { if (RaiseAcceptPendingChange(value, _Docto_rebajaespecial_Estadorebaja_Clave)) { _Docto_rebajaespecial_Estadorebaja_Clave = value; OnPropertyChanged(); } } }

        private string? _Docto_rebajaespecial_Estadorebaja_Nombre;
        [XmlAttribute]
        public string? Docto_rebajaespecial_Estadorebaja_Nombre { get => _Docto_rebajaespecial_Estadorebaja_Nombre; set { if (RaiseAcceptPendingChange(value, _Docto_rebajaespecial_Estadorebaja_Nombre)) { _Docto_rebajaespecial_Estadorebaja_Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Docto_rebajaespecial_Montorebaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_rebajaespecial_Montorebaja { get => _Docto_rebajaespecial_Montorebaja?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_rebajaespecial_Montorebaja)) { _Docto_rebajaespecial_Montorebaja = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Docto_rebajaespecial_Totalconrebaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_rebajaespecial_Totalconrebaja { get => _Docto_rebajaespecial_Totalconrebaja?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_rebajaespecial_Totalconrebaja)) { _Docto_rebajaespecial_Totalconrebaja = value?? 0; OnPropertyChanged(); } } }

        private long? _Docto_revision_Estadorevisadoid;
        [XmlAttribute]
        public long? Docto_revision_Estadorevisadoid { get => _Docto_revision_Estadorevisadoid; set { if (RaiseAcceptPendingChange(value, _Docto_revision_Estadorevisadoid)) { _Docto_revision_Estadorevisadoid = value; OnPropertyChanged(); } } }

        private string? _Docto_revision_EstadorevisadoClave;
        [XmlAttribute]
        public string? Docto_revision_EstadorevisadoClave { get => _Docto_revision_EstadorevisadoClave; set { if (RaiseAcceptPendingChange(value, _Docto_revision_EstadorevisadoClave)) { _Docto_revision_EstadorevisadoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_revision_EstadorevisadoNombre;
        [XmlAttribute]
        public string? Docto_revision_EstadorevisadoNombre { get => _Docto_revision_EstadorevisadoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_revision_EstadorevisadoNombre)) { _Docto_revision_EstadorevisadoNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_rutaembarque_Rutaembarqueid;
        [XmlAttribute]
        public long? Docto_rutaembarque_Rutaembarqueid { get => _Docto_rutaembarque_Rutaembarqueid; set { if (RaiseAcceptPendingChange(value, _Docto_rutaembarque_Rutaembarqueid)) { _Docto_rutaembarque_Rutaembarqueid = value; OnPropertyChanged(); } } }

        private string? _Docto_rutaembarque_RutaembarqueClave;
        [XmlAttribute]
        public string? Docto_rutaembarque_RutaembarqueClave { get => _Docto_rutaembarque_RutaembarqueClave; set { if (RaiseAcceptPendingChange(value, _Docto_rutaembarque_RutaembarqueClave)) { _Docto_rutaembarque_RutaembarqueClave = value; OnPropertyChanged(); } } }

        private string? _Docto_rutaembarque_RutaembarqueNombre;
        [XmlAttribute]
        public string? Docto_rutaembarque_RutaembarqueNombre { get => _Docto_rutaembarque_RutaembarqueNombre; set { if (RaiseAcceptPendingChange(value, _Docto_rutaembarque_RutaembarqueNombre)) { _Docto_rutaembarque_RutaembarqueNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_serviciodomicilio_Esservdomicilio;
        [XmlAttribute]
        public BoolCN? Docto_serviciodomicilio_Esservdomicilio { get => _Docto_serviciodomicilio_Esservdomicilio; set { if (RaiseAcceptPendingChange(value, _Docto_serviciodomicilio_Esservdomicilio)) { _Docto_serviciodomicilio_Esservdomicilio = value; OnPropertyChanged(); } } }

        private long? _Docto_serviciodomicilio_Domicilioentregaid;
        [XmlAttribute]
        public long? Docto_serviciodomicilio_Domicilioentregaid { get => _Docto_serviciodomicilio_Domicilioentregaid; set { if (RaiseAcceptPendingChange(value, _Docto_serviciodomicilio_Domicilioentregaid)) { _Docto_serviciodomicilio_Domicilioentregaid = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_surtido_Procesosurtido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Docto_surtido_Procesosurtido { get => _Docto_surtido_Procesosurtido?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Procesosurtido)) { _Docto_surtido_Procesosurtido = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Docto_surtido_Notasurtido;
        [XmlAttribute]
        public string? Docto_surtido_Notasurtido { get => _Docto_surtido_Notasurtido; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Notasurtido)) { _Docto_surtido_Notasurtido = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_surtido_Pendmaxfecha;
        [XmlAttribute]
        public DateTimeOffset? Docto_surtido_Pendmaxfecha { get => _Docto_surtido_Pendmaxfecha; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Pendmaxfecha)) { _Docto_surtido_Pendmaxfecha = value; OnPropertyChanged(); } } }

        private long? _Docto_surtido_Estadosurtidoid;
        [XmlAttribute]
        public long? Docto_surtido_Estadosurtidoid { get => _Docto_surtido_Estadosurtidoid; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Estadosurtidoid)) { _Docto_surtido_Estadosurtidoid = value; OnPropertyChanged(); } } }

        private string? _Docto_surtido_EstadosurtidoClave;
        [XmlAttribute]
        public string? Docto_surtido_EstadosurtidoClave { get => _Docto_surtido_EstadosurtidoClave; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_EstadosurtidoClave)) { _Docto_surtido_EstadosurtidoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_surtido_EstadosurtidoNombre;
        [XmlAttribute]
        public string? Docto_surtido_EstadosurtidoNombre { get => _Docto_surtido_EstadosurtidoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_EstadosurtidoNombre)) { _Docto_surtido_EstadosurtidoNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_surtido_Estatusdoctopedidoid;
        [XmlAttribute]
        public long? Docto_surtido_Estatusdoctopedidoid { get => _Docto_surtido_Estatusdoctopedidoid; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Estatusdoctopedidoid)) { _Docto_surtido_Estatusdoctopedidoid = value; OnPropertyChanged(); } } }

        private string? _Docto_surtido_EstatusdoctopedidoClave;
        [XmlAttribute]
        public string? Docto_surtido_EstatusdoctopedidoClave { get => _Docto_surtido_EstatusdoctopedidoClave; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_EstatusdoctopedidoClave)) { _Docto_surtido_EstatusdoctopedidoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_surtido_EstatusdoctopedidoNombre;
        [XmlAttribute]
        public string? Docto_surtido_EstatusdoctopedidoNombre { get => _Docto_surtido_EstatusdoctopedidoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_EstatusdoctopedidoNombre)) { _Docto_surtido_EstatusdoctopedidoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Docto_surtido_Fechasurtido;
        [XmlAttribute]
        public DateTimeOffset? Docto_surtido_Fechasurtido { get => _Docto_surtido_Fechasurtido; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Fechasurtido)) { _Docto_surtido_Fechasurtido = value; OnPropertyChanged(); } } }

        private long? _Docto_surtido_Personaidsurtido;
        [XmlAttribute]
        public long? Docto_surtido_Personaidsurtido { get => _Docto_surtido_Personaidsurtido; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_Personaidsurtido)) { _Docto_surtido_Personaidsurtido = value; OnPropertyChanged(); } } }

        private string? _Docto_surtido_PersonasurtidoClave;
        [XmlAttribute]
        public string? Docto_surtido_PersonasurtidoClave { get => _Docto_surtido_PersonasurtidoClave; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_PersonasurtidoClave)) { _Docto_surtido_PersonasurtidoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_surtido_PersonasurtidoNombre;
        [XmlAttribute]
        public string? Docto_surtido_PersonasurtidoNombre { get => _Docto_surtido_PersonasurtidoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_surtido_PersonasurtidoNombre)) { _Docto_surtido_PersonasurtidoNombre = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_Foliosolicitudmercancia;
        [XmlAttribute]
        public string? Docto_traslado_Foliosolicitudmercancia { get => _Docto_traslado_Foliosolicitudmercancia; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Foliosolicitudmercancia)) { _Docto_traslado_Foliosolicitudmercancia = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_Foliotrasladooriginal;
        [XmlAttribute]
        public string? Docto_traslado_Foliotrasladooriginal { get => _Docto_traslado_Foliotrasladooriginal; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Foliotrasladooriginal)) { _Docto_traslado_Foliotrasladooriginal = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_traslado_Estraslado;
        [XmlAttribute]
        public BoolCN? Docto_traslado_Estraslado { get => _Docto_traslado_Estraslado; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Estraslado)) { _Docto_traslado_Estraslado = value; OnPropertyChanged(); } } }

        private BoolCN? _Docto_traslado_Esdevolucion;
        [XmlAttribute]
        public BoolCN? Docto_traslado_Esdevolucion { get => _Docto_traslado_Esdevolucion; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Esdevolucion)) { _Docto_traslado_Esdevolucion = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_Foliodevolucion;
        [XmlAttribute]
        public string? Docto_traslado_Foliodevolucion { get => _Docto_traslado_Foliodevolucion; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Foliodevolucion)) { _Docto_traslado_Foliodevolucion = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_Essurtimientomerca;
        [XmlAttribute]
        public string? Docto_traslado_Essurtimientomerca { get => _Docto_traslado_Essurtimientomerca; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Essurtimientomerca)) { _Docto_traslado_Essurtimientomerca = value; OnPropertyChanged(); } } }

        private long? _Docto_traslado_Sucursaltid;
        [XmlAttribute]
        public long? Docto_traslado_Sucursaltid { get => _Docto_traslado_Sucursaltid; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Sucursaltid)) { _Docto_traslado_Sucursaltid = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_SucursaltClave;
        [XmlAttribute]
        public string? Docto_traslado_SucursaltClave { get => _Docto_traslado_SucursaltClave; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_SucursaltClave)) { _Docto_traslado_SucursaltClave = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_SucursaltNombre;
        [XmlAttribute]
        public string? Docto_traslado_SucursaltNombre { get => _Docto_traslado_SucursaltNombre; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_SucursaltNombre)) { _Docto_traslado_SucursaltNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_traslado_Almacentid;
        [XmlAttribute]
        public long? Docto_traslado_Almacentid { get => _Docto_traslado_Almacentid; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Almacentid)) { _Docto_traslado_Almacentid = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_AlmacenClave;
        [XmlAttribute]
        public string? Docto_traslado_AlmacenClave { get => _Docto_traslado_AlmacenClave; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_AlmacenClave)) { _Docto_traslado_AlmacenClave = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_AlmacenNombre;
        [XmlAttribute]
        public string? Docto_traslado_AlmacenNombre { get => _Docto_traslado_AlmacenNombre; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_AlmacenNombre)) { _Docto_traslado_AlmacenNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_traslado_Doctoimportadoid;
        [XmlAttribute]
        public long? Docto_traslado_Doctoimportadoid { get => _Docto_traslado_Doctoimportadoid; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Doctoimportadoid)) { _Docto_traslado_Doctoimportadoid = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_DoctoimportadoClave;
        [XmlAttribute]
        public string? Docto_traslado_DoctoimportadoClave { get => _Docto_traslado_DoctoimportadoClave; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_DoctoimportadoClave)) { _Docto_traslado_DoctoimportadoClave = value; OnPropertyChanged(); } } }

        private string? _Docto_traslado_DoctoimportadoNombre;
        [XmlAttribute]
        public string? Docto_traslado_DoctoimportadoNombre { get => _Docto_traslado_DoctoimportadoNombre; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_DoctoimportadoNombre)) { _Docto_traslado_DoctoimportadoNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_traslado_Idsolicitudmercancia;
        [XmlAttribute]
        public long? Docto_traslado_Idsolicitudmercancia { get => _Docto_traslado_Idsolicitudmercancia; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Idsolicitudmercancia)) { _Docto_traslado_Idsolicitudmercancia = value; OnPropertyChanged(); } } }

        private long? _Docto_traslado_Idtrasladooriginal;
        [XmlAttribute]
        public long? Docto_traslado_Idtrasladooriginal { get => _Docto_traslado_Idtrasladooriginal; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Idtrasladooriginal)) { _Docto_traslado_Idtrasladooriginal = value; OnPropertyChanged(); } } }

        private long? _Docto_traslado_Iddevolucion;
        [XmlAttribute]
        public long? Docto_traslado_Iddevolucion { get => _Docto_traslado_Iddevolucion; set { if (RaiseAcceptPendingChange(value, _Docto_traslado_Iddevolucion)) { _Docto_traslado_Iddevolucion = value; OnPropertyChanged(); } } }

        private decimal? _Docto_utilidad_Utilidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Docto_utilidad_Utilidad { get => _Docto_utilidad_Utilidad?? 0; set { if (RaiseAcceptPendingChange(value, _Docto_utilidad_Utilidad)) { _Docto_utilidad_Utilidad = value?? 0; OnPropertyChanged(); } } }

        private long? _Docto_utilidad_Vendedorutilidadid;
        [XmlAttribute]
        public long? Docto_utilidad_Vendedorutilidadid { get => _Docto_utilidad_Vendedorutilidadid; set { if (RaiseAcceptPendingChange(value, _Docto_utilidad_Vendedorutilidadid)) { _Docto_utilidad_Vendedorutilidadid = value; OnPropertyChanged(); } } }

        private string? _Docto_utilidad_VendedorutilidadClave;
        [XmlAttribute]
        public string? Docto_utilidad_VendedorutilidadClave { get => _Docto_utilidad_VendedorutilidadClave; set { if (RaiseAcceptPendingChange(value, _Docto_utilidad_VendedorutilidadClave)) { _Docto_utilidad_VendedorutilidadClave = value; OnPropertyChanged(); } } }

        private string? _Docto_utilidad_VendedorutilidadNombre;
        [XmlAttribute]
        public string? Docto_utilidad_VendedorutilidadNombre { get => _Docto_utilidad_VendedorutilidadNombre; set { if (RaiseAcceptPendingChange(value, _Docto_utilidad_VendedorutilidadNombre)) { _Docto_utilidad_VendedorutilidadNombre = value; OnPropertyChanged(); } } }

        private long? _Docto_ventafuturo_Ventafutuid;
        [XmlAttribute]
        public long? Docto_ventafuturo_Ventafutuid { get => _Docto_ventafuturo_Ventafutuid; set { if (RaiseAcceptPendingChange(value, _Docto_ventafuturo_Ventafutuid)) { _Docto_ventafuturo_Ventafutuid = value; OnPropertyChanged(); } } }

        private string? _Docto_ventafuturo_VentafutuClave;
        [XmlAttribute]
        public string? Docto_ventafuturo_VentafutuClave { get => _Docto_ventafuturo_VentafutuClave; set { if (RaiseAcceptPendingChange(value, _Docto_ventafuturo_VentafutuClave)) { _Docto_ventafuturo_VentafutuClave = value; OnPropertyChanged(); } } }

        private string? _Docto_ventafuturo_VentafutuNombre;
        [XmlAttribute]
        public string? Docto_ventafuturo_VentafutuNombre { get => _Docto_ventafuturo_VentafutuNombre; set { if (RaiseAcceptPendingChange(value, _Docto_ventafuturo_VentafutuNombre)) { _Docto_ventafuturo_VentafutuNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Docto"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Serie|Referencia|Referencias|Estatusdocto.Clave|Estatusdocto.Nombre|Usuario.Clave|Usuario.Nombre|Corte.Clave|Corte.Nombre|Caja.Clave|Caja.Nombre|Almacen.Clave|Almacen.Nombre|Origenfiscal.Clave|Origenfiscal.Nombre|Doctoparent.Clave|Doctoparent.Nombre|Cliente.Clave|Cliente.Nombre|Tipodocto.Clave|Tipodocto.Nombre|Proveedor.Clave|Proveedor.Nombre|Sucursal_info.Clave|Sucursal_info.Nombre|Subtipodocto.Clave|Subtipodocto.Nombre|Tipodiferenciainventario.Clave|Tipodiferenciainventario.Nombre|Clave|Nombre|Docto_alerta.Autorizoalerta.Clave|Docto_alerta.Autorizoalerta.Nombre|Docto_apartado.Personaapartado.Clave|Docto_apartado.Personaapartado.Nombre|Docto_cobranza.Personaaprobacioncxc.Clave|Docto_cobranza.Personaaprobacioncxc.Nombre|Docto_comision.Vendedorfinal_.Clave|Docto_comision.Vendedorfinal_.Nombre|Docto_comision.Vendedorejecutivo.Clave|Docto_comision.Vendedorejecutivo.Nombre|Docto_compra.Folio|Docto_compra.Factura|Docto_contrarecibo.Contrarecibo.Clave|Docto_contrarecibo.Contrarecibo.Nombre|Docto_cancelacion.Doctoref.Clave|Docto_cancelacion.Doctoref.Nombre|Docto_devolucion.Doctoref.Clave|Docto_devolucion.Doctoref.Nombre|Docto_loteimportado.Loteimportadodocto.Clave|Docto_loteimportado.Loteimportadodocto.Nombre|Docto_corte.Montobilletes.Clave|Docto_corte.Montobilletes.Nombre|Docto_fact_elect.Timbradouuid|Docto_fact_elect.Timbradofecha|Docto_fact_elect.Timbradocertsat|Docto_fact_elect.Timbradosellosat|Docto_fact_elect.Timbradosellocfdi|Docto_fact_elect.Timbradouuidcancelacion|Docto_fact_elect.Timbradoformapagosat|Docto_fact_elect.Seriesat|Docto_fact_elect.Sat_usocfdi.Clave|Docto_fact_elect.Sat_usocfdi.Nombre|Docto_fact_elect.Cfdi.Clave|Docto_fact_elect.Cfdi.Nombre|Docto_fact_elect_consolidacion.Factcons.Clave|Docto_fact_elect_consolidacion.Factcons.Nombre|Docto_fact_elect_consolidacion.Devcons.Clave|Docto_fact_elect_consolidacion.Devcons.Nombre|Docto_fact_elect_consolidacion.Doctoref2.Clave|Docto_fact_elect_consolidacion.Doctoref2.Nombre|Docto_fact_elect_pagos.Timbradoformapagosat|Docto_fact_elect_pagos.Doctopagosat_.Clave|Docto_fact_elect_pagos.Doctopagosat_.Nombre|Docto_fact_elect_pagos.Pagosat_.Clave|Docto_fact_elect_pagos.Pagosat_.Nombre|Docto_fact_elect_sustitucion.Doctosustituto.Clave|Docto_fact_elect_sustitucion.Doctosustituto.Nombre|Docto_fact_elect_sustitucion.Doctoasustituir.Clave|Docto_fact_elect_sustitucion.Doctoasustituir.Nombre|Docto_farmacia.Manejoreceta|Docto_guia.Estadoguia.Clave|Docto_guia.Estadoguia.Nombre|Docto_guia.Guia.Clave|Docto_guia.Guia.Nombre|Docto_guia.Personaguiarecibio.Clave|Docto_guia.Personaguiarecibio.Nombre|Docto_kit.Doctokitref.Clave|Docto_kit.Doctokitref.Nombre|Docto_kit.Prekitestatus_.Clave|Docto_kit.Prekitestatus_.Nombre|Docto_kit.Postkitestatus_.Clave|Docto_kit.Postkitestatus_.Nombre|Docto_monedero.Monedero_.Clave|Docto_monedero.Monedero_.Nombre|Docto_ordencompra.Ordencompra|Docto_ordencompra.Doctoref.Clave|Docto_ordencompra.Doctoref.Nombre|Docto_origenfiscal.Serieorigenfacturado|Docto_info_pago.Notapago|Docto_info_pago.Pagodev.Clave|Docto_info_pago.Pagodev.Nombre|Docto_info_pago.Estatusanticipo.Clave|Docto_info_pago.Estatusanticipo.Nombre|Docto_poliza.Doctoplazoorigen.Clave|Docto_poliza.Doctoplazoorigen.Nombre|Docto_poliza.Plazo.Clave|Docto_poliza.Plazo.Nombre|Docto_precio.Tipomayoreo.Clave|Docto_precio.Tipomayoreo.Nombre|Docto_precio.Tipodescuentovale_.Clave|Docto_precio.Tipodescuentovale_.Nombre|Docto_rebajaespecial.Estadorebaja_.Clave|Docto_rebajaespecial.Estadorebaja_.Nombre|Docto_revision.Estadorevisado.Clave|Docto_revision.Estadorevisado.Nombre|Docto_rutaembarque.Rutaembarque.Clave|Docto_rutaembarque.Rutaembarque.Nombre|Docto_surtido.Notasurtido|Docto_surtido.Estadosurtido.Clave|Docto_surtido.Estadosurtido.Nombre|Docto_surtido.Estatusdoctopedido.Clave|Docto_surtido.Estatusdoctopedido.Nombre|Docto_surtido.Personasurtido.Clave|Docto_surtido.Personasurtido.Nombre|Docto_traslado.Foliosolicitudmercancia|Docto_traslado.Foliotrasladooriginal|Docto_traslado.Foliodevolucion|Docto_traslado.Essurtimientomerca|Docto_traslado.Sucursalt.Clave|Docto_traslado.Sucursalt.Nombre|Docto_traslado.Almacen.Clave|Docto_traslado.Almacen.Nombre|Docto_traslado.Doctoimportado.Clave|Docto_traslado.Doctoimportado.Nombre|Docto_utilidad.Vendedorutilidad.Clave|Docto_utilidad.Vendedorutilidad.Nombre|Docto_ventafuturo.Ventafutu.Clave|Docto_ventafuturo.Ventafutu.Nombre";
        }


        #if PROYECTO_WEB

        public void FillCatalogRelatedFields(Docto item)
        {

             this._EstatusdoctoClave = item.Estatusdocto?.Clave;

             this._EstatusdoctoNombre = item.Estatusdocto?.Nombre;

             this._UsuarioClave = item.Usuario?.Clave;

             this._UsuarioNombre = item.Usuario?.Nombre;

             this._CorteClave = item.Corte?.Clave;

             this._CorteNombre = item.Corte?.Nombre;

             this._CajaClave = item.Caja?.Clave;

             this._CajaNombre = item.Caja?.Nombre;

             this._AlmacenClave = item.Almacen?.Clave;

             this._AlmacenNombre = item.Almacen?.Nombre;

             this._OrigenfiscalClave = item.Origenfiscal?.Clave;

             this._OrigenfiscalNombre = item.Origenfiscal?.Nombre;

             this._DoctoparentClave = item.Doctoparent?.Clave;

             this._DoctoparentNombre = item.Doctoparent?.Nombre;

             this._ClienteClave = item.Cliente?.Clave;

             this._ClienteNombre = item.Cliente?.Nombre;

             this._TipodoctoClave = item.Tipodocto?.Clave;

             this._TipodoctoNombre = item.Tipodocto?.Nombre;

             this._ProveedorClave = item.Proveedor?.Clave;

             this._ProveedorNombre = item.Proveedor?.Nombre;

             this._Sucursal_infoClave = item.Sucursal_info?.Clave;

             this._Sucursal_infoNombre = item.Sucursal_info?.Nombre;

             this._SubtipodoctoClave = item.Subtipodocto?.Clave;

             this._SubtipodoctoNombre = item.Subtipodocto?.Nombre;

             this._TipodiferenciainventarioClave = item.Tipodiferenciainventario?.Clave;

             this._TipodiferenciainventarioNombre = item.Tipodiferenciainventario?.Nombre;

             this._Docto_alerta_AutorizoalertaClave = item.Docto_alerta?.Autorizoalerta?.Clave;

             this._Docto_alerta_AutorizoalertaNombre = item.Docto_alerta?.Autorizoalerta?.Nombre;

             this._Docto_apartado_PersonaapartadoClave = item.Docto_apartado?.Personaapartado?.Clave;

             this._Docto_apartado_PersonaapartadoNombre = item.Docto_apartado?.Personaapartado?.Nombre;

             this._Docto_cobranza_PersonaaprobacioncxcClave = item.Docto_cobranza?.Personaaprobacioncxc?.Clave;

             this._Docto_cobranza_PersonaaprobacioncxcNombre = item.Docto_cobranza?.Personaaprobacioncxc?.Nombre;

             this._Docto_comision_Vendedorfinal_Clave = item.Docto_comision?.Vendedorfinal_?.Clave;

             this._Docto_comision_Vendedorfinal_Nombre = item.Docto_comision?.Vendedorfinal_?.Nombre;

             this._Docto_comision_VendedorejecutivoClave = item.Docto_comision?.Vendedorejecutivo?.Clave;

             this._Docto_comision_VendedorejecutivoNombre = item.Docto_comision?.Vendedorejecutivo?.Nombre;

             this._Docto_contrarecibo_ContrareciboClave = item.Docto_contrarecibo?.Contrarecibo?.Clave;

             this._Docto_contrarecibo_ContrareciboNombre = item.Docto_contrarecibo?.Contrarecibo?.Nombre;

             this._Docto_cancelacion_DoctorefClave = item.Docto_cancelacion?.Doctoref?.Clave;

             this._Docto_cancelacion_DoctorefNombre = item.Docto_cancelacion?.Doctoref?.Nombre;

             this._Docto_devolucion_DoctorefClave = item.Docto_devolucion?.Doctoref?.Clave;

             this._Docto_devolucion_DoctorefNombre = item.Docto_devolucion?.Doctoref?.Nombre;

             this._Docto_loteimportado_LoteimportadodoctoClave = item.Docto_loteimportado?.Loteimportadodocto?.Clave;

             this._Docto_loteimportado_LoteimportadodoctoNombre = item.Docto_loteimportado?.Loteimportadodocto?.Nombre;

             this._Docto_corte_MontobilletesClave = item.Docto_corte?.Montobilletes?.Clave;

             this._Docto_corte_MontobilletesNombre = item.Docto_corte?.Montobilletes?.Nombre;

             this._Docto_fact_elect_Sat_usocfdiClave = item.Docto_fact_elect?.Sat_usocfdi?.Clave;

             this._Docto_fact_elect_Sat_usocfdiNombre = item.Docto_fact_elect?.Sat_usocfdi?.Nombre;

             this._Docto_fact_elect_CfdiClave = item.Docto_fact_elect?.Cfdi?.Clave;

             this._Docto_fact_elect_CfdiNombre = item.Docto_fact_elect?.Cfdi?.Nombre;

             this._Docto_fact_elect_consolidacion_FactconsClave = item.Docto_fact_elect_consolidacion?.Factcons?.Clave;

             this._Docto_fact_elect_consolidacion_FactconsNombre = item.Docto_fact_elect_consolidacion?.Factcons?.Nombre;

             this._Docto_fact_elect_consolidacion_DevconsClave = item.Docto_fact_elect_consolidacion?.Devcons?.Clave;

             this._Docto_fact_elect_consolidacion_DevconsNombre = item.Docto_fact_elect_consolidacion?.Devcons?.Nombre;

             this._Docto_fact_elect_consolidacion_Doctoref2Clave = item.Docto_fact_elect_consolidacion?.Doctoref2?.Clave;

             this._Docto_fact_elect_consolidacion_Doctoref2Nombre = item.Docto_fact_elect_consolidacion?.Doctoref2?.Nombre;

             this._Docto_fact_elect_pagos_Doctopagosat_Clave = item.Docto_fact_elect_pagos?.Doctopagosat_?.Clave;

             this._Docto_fact_elect_pagos_Doctopagosat_Nombre = item.Docto_fact_elect_pagos?.Doctopagosat_?.Nombre;

             this._Docto_fact_elect_pagos_Pagosat_Clave = item.Docto_fact_elect_pagos?.Pagosat_?.Clave;

             this._Docto_fact_elect_pagos_Pagosat_Nombre = item.Docto_fact_elect_pagos?.Pagosat_?.Nombre;

             this._Docto_fact_elect_sustitucion_DoctosustitutoClave = item.Docto_fact_elect_sustitucion?.Doctosustituto?.Clave;

             this._Docto_fact_elect_sustitucion_DoctosustitutoNombre = item.Docto_fact_elect_sustitucion?.Doctosustituto?.Nombre;

             this._Docto_fact_elect_sustitucion_DoctoasustituirClave = item.Docto_fact_elect_sustitucion?.Doctoasustituir?.Clave;

             this._Docto_fact_elect_sustitucion_DoctoasustituirNombre = item.Docto_fact_elect_sustitucion?.Doctoasustituir?.Nombre;

             this._Docto_guia_EstadoguiaClave = item.Docto_guia?.Estadoguia?.Clave;

             this._Docto_guia_EstadoguiaNombre = item.Docto_guia?.Estadoguia?.Nombre;

             this._Docto_guia_GuiaClave = item.Docto_guia?.Guia?.Clave;

             this._Docto_guia_GuiaNombre = item.Docto_guia?.Guia?.Nombre;

             this._Docto_guia_PersonaguiarecibioClave = item.Docto_guia?.Personaguiarecibio?.Clave;

             this._Docto_guia_PersonaguiarecibioNombre = item.Docto_guia?.Personaguiarecibio?.Nombre;

             this._Docto_kit_DoctokitrefClave = item.Docto_kit?.Doctokitref?.Clave;

             this._Docto_kit_DoctokitrefNombre = item.Docto_kit?.Doctokitref?.Nombre;

             this._Docto_kit_Prekitestatus_Clave = item.Docto_kit?.Prekitestatus_?.Clave;

             this._Docto_kit_Prekitestatus_Nombre = item.Docto_kit?.Prekitestatus_?.Nombre;

             this._Docto_kit_Postkitestatus_Clave = item.Docto_kit?.Postkitestatus_?.Clave;

             this._Docto_kit_Postkitestatus_Nombre = item.Docto_kit?.Postkitestatus_?.Nombre;

             this._Docto_monedero_Monedero_Clave = item.Docto_monedero?.Monedero_?.Clave;

             this._Docto_monedero_Monedero_Nombre = item.Docto_monedero?.Monedero_?.Nombre;

             this._Docto_ordencompra_DoctorefClave = item.Docto_ordencompra?.Doctoref?.Clave;

             this._Docto_ordencompra_DoctorefNombre = item.Docto_ordencompra?.Doctoref?.Nombre;

             this._Docto_info_pago_PagodevClave = item.Docto_info_pago?.Pagodev?.Clave;

             this._Docto_info_pago_PagodevNombre = item.Docto_info_pago?.Pagodev?.Nombre;

             this._Docto_info_pago_EstatusanticipoClave = item.Docto_info_pago?.Estatusanticipo?.Clave;

             this._Docto_info_pago_EstatusanticipoNombre = item.Docto_info_pago?.Estatusanticipo?.Nombre;

             this._Docto_poliza_DoctoplazoorigenClave = item.Docto_poliza?.Doctoplazoorigen?.Clave;

             this._Docto_poliza_DoctoplazoorigenNombre = item.Docto_poliza?.Doctoplazoorigen?.Nombre;

             this._Docto_poliza_PlazoClave = item.Docto_poliza?.Plazo?.Clave;

             this._Docto_poliza_PlazoNombre = item.Docto_poliza?.Plazo?.Nombre;

             this._Docto_precio_TipomayoreoClave = item.Docto_precio?.Tipomayoreo?.Clave;

             this._Docto_precio_TipomayoreoNombre = item.Docto_precio?.Tipomayoreo?.Nombre;

             this._Docto_precio_Tipodescuentovale_Clave = item.Docto_precio?.Tipodescuentovale_?.Clave;

             this._Docto_precio_Tipodescuentovale_Nombre = item.Docto_precio?.Tipodescuentovale_?.Nombre;

             this._Docto_rebajaespecial_Estadorebaja_Clave = item.Docto_rebajaespecial?.Estadorebaja_?.Clave;

             this._Docto_rebajaespecial_Estadorebaja_Nombre = item.Docto_rebajaespecial?.Estadorebaja_?.Nombre;

             this._Docto_revision_EstadorevisadoClave = item.Docto_revision?.Estadorevisado?.Clave;

             this._Docto_revision_EstadorevisadoNombre = item.Docto_revision?.Estadorevisado?.Nombre;

             this._Docto_rutaembarque_RutaembarqueClave = item.Docto_rutaembarque?.Rutaembarque?.Clave;

             this._Docto_rutaembarque_RutaembarqueNombre = item.Docto_rutaembarque?.Rutaembarque?.Nombre;

             this._Docto_surtido_EstadosurtidoClave = item.Docto_surtido?.Estadosurtido?.Clave;

             this._Docto_surtido_EstadosurtidoNombre = item.Docto_surtido?.Estadosurtido?.Nombre;

             this._Docto_surtido_EstatusdoctopedidoClave = item.Docto_surtido?.Estatusdoctopedido?.Clave;

             this._Docto_surtido_EstatusdoctopedidoNombre = item.Docto_surtido?.Estatusdoctopedido?.Nombre;

             this._Docto_surtido_PersonasurtidoClave = item.Docto_surtido?.Personasurtido?.Clave;

             this._Docto_surtido_PersonasurtidoNombre = item.Docto_surtido?.Personasurtido?.Nombre;

             this._Docto_traslado_SucursaltClave = item.Docto_traslado?.Sucursalt?.Clave;

             this._Docto_traslado_SucursaltNombre = item.Docto_traslado?.Sucursalt?.Nombre;

             this._Docto_traslado_AlmacenClave = item.Docto_traslado?.Almacen?.Clave;

             this._Docto_traslado_AlmacenNombre = item.Docto_traslado?.Almacen?.Nombre;

             this._Docto_traslado_DoctoimportadoClave = item.Docto_traslado?.Doctoimportado?.Clave;

             this._Docto_traslado_DoctoimportadoNombre = item.Docto_traslado?.Doctoimportado?.Nombre;

             this._Docto_utilidad_VendedorutilidadClave = item.Docto_utilidad?.Vendedorutilidad?.Clave;

             this._Docto_utilidad_VendedorutilidadNombre = item.Docto_utilidad?.Vendedorutilidad?.Nombre;

             this._Docto_ventafuturo_VentafutuClave = item.Docto_ventafuturo?.Ventafutu?.Clave;

             this._Docto_ventafuturo_VentafutuNombre = item.Docto_ventafuturo?.Ventafutu?.Nombre;


        }


        public void FillEntityValues(ref Docto item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Serie = Serie ;


            item.Esapartado = Esapartado ?? BoolCN.N;


            item.Referencia = Referencia ;


            item.Referencias = Referencias ;


            item.Estatusdoctoid = Estatusdoctoid ;


            item.Usuarioid = Usuarioid ;


            item.Corteid = Corteid ;


            item.Fecha = Fecha ;


            item.Fechahora = Fechahora ;


            item.Folio = Folio ;


            item.Importe = Importe ?? 0;


            item.Descuento = Descuento ?? 0;


            item.Subtotal = Subtotal ?? 0;


            item.Iva = Iva ?? 0;


            item.Ieps = Ieps ?? 0;


            item.Total = Total ?? 0;


            item.Cargo = Cargo ?? 0;


            item.Abono = Abono ?? 0;


            item.Saldo = Saldo ?? 0;


            item.Cajaid = Cajaid ;


            item.Almacenid = Almacenid ;


            item.Origenfiscalid = Origenfiscalid ;


            item.Doctoparentid = Doctoparentid ;


            item.Clienteid = Clienteid ;


            item.Tipodoctoid = Tipodoctoid ;


            item.Proveedorid = Proveedorid ;


            item.Sucursal_id = Sucursal_id ;


            item.Subtipodoctoid = Subtipodoctoid ;


            item.Tipodiferenciainventarioid = Tipodiferenciainventarioid ;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.Fechavence = Fechavence;


            if (item.Docto_alerta != null)
                item.Docto_alerta!.Autorizoalertaid = Docto_alerta_Autorizoalertaid;
            else if (item.Docto_alerta == null && Docto_alerta_Autorizoalertaid != null)
            {
                item.Docto_alerta = CreateSubEntity<Docto_alerta>();
                item.Docto_alerta!.Autorizoalertaid = Docto_alerta_Autorizoalertaid;
            }

            if (item.Docto_apartado != null)
                item.Docto_apartado!.Mercanciaentregada = Docto_apartado_Mercanciaentregada?? BoolCN.N;
            else if (item.Docto_apartado == null && Docto_apartado_Mercanciaentregada != null)
            {
                item.Docto_apartado = CreateSubEntity<Docto_apartado>();
                item.Docto_apartado!.Mercanciaentregada = Docto_apartado_Mercanciaentregada?? BoolCN.N;
            }

            if (item.Docto_apartado != null)
                item.Docto_apartado!.Personaapartadoid = Docto_apartado_Personaapartadoid;
            else if (item.Docto_apartado == null && Docto_apartado_Personaapartadoid != null)
            {
                item.Docto_apartado = CreateSubEntity<Docto_apartado>();
                item.Docto_apartado!.Personaapartadoid = Docto_apartado_Personaapartadoid;
            }

            if (item.Docto_bancomer != null)
                item.Docto_bancomer!.Pagobancomeraplicado = Docto_bancomer_Pagobancomeraplicado?? BoolCN.N;
            else if (item.Docto_bancomer == null && Docto_bancomer_Pagobancomeraplicado != null)
            {
                item.Docto_bancomer = CreateSubEntity<Docto_bancomer>();
                item.Docto_bancomer!.Pagobancomeraplicado = Docto_bancomer_Pagobancomeraplicado?? BoolCN.N;
            }

            if (item.Docto_cobranza != null)
                item.Docto_cobranza!.Fechaaprobacioncxc = Docto_cobranza_Fechaaprobacioncxc;
            else if (item.Docto_cobranza == null && Docto_cobranza_Fechaaprobacioncxc != null)
            {
                item.Docto_cobranza = CreateSubEntity<Docto_cobranza>();
                item.Docto_cobranza!.Fechaaprobacioncxc = Docto_cobranza_Fechaaprobacioncxc;
            }

            if (item.Docto_cobranza != null)
                item.Docto_cobranza!.Personaidaprobacioncxc = Docto_cobranza_Personaidaprobacioncxc;
            else if (item.Docto_cobranza == null && Docto_cobranza_Personaidaprobacioncxc != null)
            {
                item.Docto_cobranza = CreateSubEntity<Docto_cobranza>();
                item.Docto_cobranza!.Personaidaprobacioncxc = Docto_cobranza_Personaidaprobacioncxc;
            }

            if (item.Docto_comision != null)
                item.Docto_comision!.Vendedorfinal = Docto_comision_Vendedorfinal;
            else if (item.Docto_comision == null && Docto_comision_Vendedorfinal != null)
            {
                item.Docto_comision = CreateSubEntity<Docto_comision>();
                item.Docto_comision!.Vendedorfinal = Docto_comision_Vendedorfinal;
            }

            if (item.Docto_comision != null)
                item.Docto_comision!.Vendedorejecutivoid = Docto_comision_Vendedorejecutivoid;
            else if (item.Docto_comision == null && Docto_comision_Vendedorejecutivoid != null)
            {
                item.Docto_comision = CreateSubEntity<Docto_comision>();
                item.Docto_comision!.Vendedorejecutivoid = Docto_comision_Vendedorejecutivoid;
            }

            if (item.Docto_comision != null)
                item.Docto_comision!.Comision = Docto_comision_Comision?? 0;
            else if (item.Docto_comision == null && Docto_comision_Comision != null)
            {
                item.Docto_comision = CreateSubEntity<Docto_comision>();
                item.Docto_comision!.Comision = Docto_comision_Comision?? 0;
            }

            if (item.Docto_compra != null)
                item.Docto_compra!.Folio = Docto_compra_Folio;
            else if (item.Docto_compra == null && Docto_compra_Folio != null)
            {
                item.Docto_compra = CreateSubEntity<Docto_compra>();
                item.Docto_compra!.Folio = Docto_compra_Folio;
            }

            if (item.Docto_compra != null)
                item.Docto_compra!.Factura = Docto_compra_Factura;
            else if (item.Docto_compra == null && Docto_compra_Factura != null)
            {
                item.Docto_compra = CreateSubEntity<Docto_compra>();
                item.Docto_compra!.Factura = Docto_compra_Factura;
            }

            if (item.Docto_compra != null)
                item.Docto_compra!.Fechafactura = Docto_compra_Fechafactura;
            else if (item.Docto_compra == null && Docto_compra_Fechafactura != null)
            {
                item.Docto_compra = CreateSubEntity<Docto_compra>();
                item.Docto_compra!.Fechafactura = Docto_compra_Fechafactura;
            }


            if (item.Docto_contrarecibo != null)
                item.Docto_contrarecibo!.Contrareciboid = Docto_contrarecibo_Contrareciboid;
            else if (item.Docto_contrarecibo == null && Docto_contrarecibo_Contrareciboid != null)
            {
                item.Docto_contrarecibo = CreateSubEntity<Docto_contrarecibo>();
                item.Docto_contrarecibo!.Contrareciboid = Docto_contrarecibo_Contrareciboid;
            }

            if (item.Docto_cancelacion != null)
                item.Docto_cancelacion!.Doctorefid = Docto_cancelacion_Doctorefid;
            else if (item.Docto_cancelacion == null && Docto_cancelacion_Doctorefid != null)
            {
                item.Docto_cancelacion = CreateSubEntity<Docto_cancelacion>();
                item.Docto_cancelacion!.Doctorefid = Docto_cancelacion_Doctorefid;
            }

            if (item.Docto_devolucion != null)
                item.Docto_devolucion!.Doctorefid = Docto_devolucion_Doctorefid;
            else if (item.Docto_devolucion == null && Docto_devolucion_Doctorefid != null)
            {
                item.Docto_devolucion = CreateSubEntity<Docto_devolucion>();
                item.Docto_devolucion!.Doctorefid = Docto_devolucion_Doctorefid;
            }

            if (item.Docto_loteimportado != null)
                item.Docto_loteimportado!.Loteimportadodoctoid = Docto_loteimportado_Loteimportadodoctoid;
            else if (item.Docto_loteimportado == null && Docto_loteimportado_Loteimportadodoctoid != null)
            {
                item.Docto_loteimportado = CreateSubEntity<Docto_loteimportado>();
                item.Docto_loteimportado!.Loteimportadodoctoid = Docto_loteimportado_Loteimportadodoctoid;
            }

            if (item.Docto_corte != null)
                item.Docto_corte!.Fechacorte = Docto_corte_Fechacorte;
            else if (item.Docto_corte == null && Docto_corte_Fechacorte != null)
            {
                item.Docto_corte = CreateSubEntity<Docto_corte>();
                item.Docto_corte!.Fechacorte = Docto_corte_Fechacorte;
            }

            if (item.Docto_corte != null)
                item.Docto_corte!.Montobilletesid = Docto_corte_Montobilletesid;
            else if (item.Docto_corte == null && Docto_corte_Montobilletesid != null)
            {
                item.Docto_corte = CreateSubEntity<Docto_corte>();
                item.Docto_corte!.Montobilletesid = Docto_corte_Montobilletesid;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradouuid = Docto_fact_elect_Timbradouuid;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradouuid != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradouuid = Docto_fact_elect_Timbradouuid;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradofecha = Docto_fact_elect_Timbradofecha;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradofecha != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradofecha = Docto_fact_elect_Timbradofecha;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradocertsat = Docto_fact_elect_Timbradocertsat;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradocertsat != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradocertsat = Docto_fact_elect_Timbradocertsat;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradosellosat = Docto_fact_elect_Timbradosellosat;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradosellosat != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradosellosat = Docto_fact_elect_Timbradosellosat;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradosellocfdi = Docto_fact_elect_Timbradosellocfdi;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradosellocfdi != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradosellocfdi = Docto_fact_elect_Timbradosellocfdi;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradocancelado = Docto_fact_elect_Timbradocancelado?? BoolCN.N;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradocancelado != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradocancelado = Docto_fact_elect_Timbradocancelado?? BoolCN.N;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradouuidcancelacion = Docto_fact_elect_Timbradouuidcancelacion;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradouuidcancelacion != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradouuidcancelacion = Docto_fact_elect_Timbradouuidcancelacion;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradoformapagosat = Docto_fact_elect_Timbradoformapagosat;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradoformapagosat != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradoformapagosat = Docto_fact_elect_Timbradoformapagosat;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Seriesat = Docto_fact_elect_Seriesat;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Seriesat != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Seriesat = Docto_fact_elect_Seriesat;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Esfacturaelectronica = Docto_fact_elect_Esfacturaelectronica?? BoolCN.N;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Esfacturaelectronica != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Esfacturaelectronica = Docto_fact_elect_Esfacturaelectronica?? BoolCN.N;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradofechacancelacion = Docto_fact_elect_Timbradofechacancelacion;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradofechacancelacion != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradofechacancelacion = Docto_fact_elect_Timbradofechacancelacion;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Timbradofechafactura = Docto_fact_elect_Timbradofechafactura;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Timbradofechafactura != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Timbradofechafactura = Docto_fact_elect_Timbradofechafactura;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Foliosat = Docto_fact_elect_Foliosat;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Foliosat != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Foliosat = Docto_fact_elect_Foliosat;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Fechafactura = Docto_fact_elect_Fechafactura;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Fechafactura != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Fechafactura = Docto_fact_elect_Fechafactura;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Sat_usocfdiid = Docto_fact_elect_Sat_usocfdiid;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Sat_usocfdiid != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Sat_usocfdiid = Docto_fact_elect_Sat_usocfdiid;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Cfdiid = Docto_fact_elect_Cfdiid;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Cfdiid != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Cfdiid = Docto_fact_elect_Cfdiid;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Ivaretenido = Docto_fact_elect_Ivaretenido?? 0;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Ivaretenido != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Ivaretenido = Docto_fact_elect_Ivaretenido?? 0;
            }

            if (item.Docto_fact_elect != null)
                item.Docto_fact_elect!.Isrretenido = Docto_fact_elect_Isrretenido?? 0;
            else if (item.Docto_fact_elect == null && Docto_fact_elect_Isrretenido != null)
            {
                item.Docto_fact_elect = CreateSubEntity<Docto_fact_elect>();
                item.Docto_fact_elect!.Isrretenido = Docto_fact_elect_Isrretenido?? 0;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Factconsaplicado = Docto_fact_elect_consolidacion_Factconsaplicado;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Factconsaplicado != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Factconsaplicado = Docto_fact_elect_consolidacion_Factconsaplicado;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Omitirvales = Docto_fact_elect_consolidacion_Omitirvales;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Omitirvales != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Omitirvales = Docto_fact_elect_consolidacion_Omitirvales;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Factconsid = Docto_fact_elect_consolidacion_Factconsid;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Factconsid != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Factconsid = Docto_fact_elect_consolidacion_Factconsid;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Devconsid = Docto_fact_elect_consolidacion_Devconsid;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Devconsid != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Devconsid = Docto_fact_elect_consolidacion_Devconsid;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Doctorefid2 = Docto_fact_elect_consolidacion_Doctorefid2;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Doctorefid2 != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Doctorefid2 = Docto_fact_elect_consolidacion_Doctorefid2;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Consolidado_subtotal = Docto_fact_elect_consolidacion_Consolidado_subtotal?? 0;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Consolidado_subtotal != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Consolidado_subtotal = Docto_fact_elect_consolidacion_Consolidado_subtotal?? 0;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Consolidado_iva = Docto_fact_elect_consolidacion_Consolidado_iva?? 0;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Consolidado_iva != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Consolidado_iva = Docto_fact_elect_consolidacion_Consolidado_iva?? 0;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Consolidado_ieps = Docto_fact_elect_consolidacion_Consolidado_ieps?? 0;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Consolidado_ieps != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Consolidado_ieps = Docto_fact_elect_consolidacion_Consolidado_ieps?? 0;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Consolidado_total = Docto_fact_elect_consolidacion_Consolidado_total?? 0;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Consolidado_total != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Consolidado_total = Docto_fact_elect_consolidacion_Consolidado_total?? 0;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Consolidado_iva_ret = Docto_fact_elect_consolidacion_Consolidado_iva_ret?? 0;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Consolidado_iva_ret != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Consolidado_iva_ret = Docto_fact_elect_consolidacion_Consolidado_iva_ret?? 0;
            }

            if (item.Docto_fact_elect_consolidacion != null)
                item.Docto_fact_elect_consolidacion!.Consolidado_isr_ret = Docto_fact_elect_consolidacion_Consolidado_isr_ret?? 0;
            else if (item.Docto_fact_elect_consolidacion == null && Docto_fact_elect_consolidacion_Consolidado_isr_ret != null)
            {
                item.Docto_fact_elect_consolidacion = CreateSubEntity<Docto_fact_elect_consolidacion>();
                item.Docto_fact_elect_consolidacion!.Consolidado_isr_ret = Docto_fact_elect_consolidacion_Consolidado_isr_ret?? 0;
            }

            if (item.Docto_fact_elect_pagos != null)
                item.Docto_fact_elect_pagos!.Timbradoformapagosat = Docto_fact_elect_pagos_Timbradoformapagosat;
            else if (item.Docto_fact_elect_pagos == null && Docto_fact_elect_pagos_Timbradoformapagosat != null)
            {
                item.Docto_fact_elect_pagos = CreateSubEntity<Docto_fact_elect_pagos>();
                item.Docto_fact_elect_pagos!.Timbradoformapagosat = Docto_fact_elect_pagos_Timbradoformapagosat;
            }

            if (item.Docto_fact_elect_pagos != null)
                item.Docto_fact_elect_pagos!.Doctopagosat = Docto_fact_elect_pagos_Doctopagosat;
            else if (item.Docto_fact_elect_pagos == null && Docto_fact_elect_pagos_Doctopagosat != null)
            {
                item.Docto_fact_elect_pagos = CreateSubEntity<Docto_fact_elect_pagos>();
                item.Docto_fact_elect_pagos!.Doctopagosat = Docto_fact_elect_pagos_Doctopagosat;
            }

            if (item.Docto_fact_elect_pagos != null)
                item.Docto_fact_elect_pagos!.Pagosat = Docto_fact_elect_pagos_Pagosat;
            else if (item.Docto_fact_elect_pagos == null && Docto_fact_elect_pagos_Pagosat != null)
            {
                item.Docto_fact_elect_pagos = CreateSubEntity<Docto_fact_elect_pagos>();
                item.Docto_fact_elect_pagos!.Pagosat = Docto_fact_elect_pagos_Pagosat;
            }

            if (item.Docto_fact_elect_sustitucion != null)
                item.Docto_fact_elect_sustitucion!.Doctosustitutoid = Docto_fact_elect_sustitucion_Doctosustitutoid;
            else if (item.Docto_fact_elect_sustitucion == null && Docto_fact_elect_sustitucion_Doctosustitutoid != null)
            {
                item.Docto_fact_elect_sustitucion = CreateSubEntity<Docto_fact_elect_sustitucion>();
                item.Docto_fact_elect_sustitucion!.Doctosustitutoid = Docto_fact_elect_sustitucion_Doctosustitutoid;
            }

            if (item.Docto_fact_elect_sustitucion != null)
                item.Docto_fact_elect_sustitucion!.Doctoasustituirid = Docto_fact_elect_sustitucion_Doctoasustituirid;
            else if (item.Docto_fact_elect_sustitucion == null && Docto_fact_elect_sustitucion_Doctoasustituirid != null)
            {
                item.Docto_fact_elect_sustitucion = CreateSubEntity<Docto_fact_elect_sustitucion>();
                item.Docto_fact_elect_sustitucion!.Doctoasustituirid = Docto_fact_elect_sustitucion_Doctoasustituirid;
            }

            if (item.Docto_farmacia != null)
                item.Docto_farmacia!.Manejoreceta = Docto_farmacia_Manejoreceta;
            else if (item.Docto_farmacia == null && Docto_farmacia_Manejoreceta != null)
            {
                item.Docto_farmacia = CreateSubEntity<Docto_farmacia>();
                item.Docto_farmacia!.Manejoreceta = Docto_farmacia_Manejoreceta;
            }

            if (item.Docto_guia != null)
                item.Docto_guia!.Usardatosentrega = Docto_guia_Usardatosentrega?? BoolCNI.N;
            else if (item.Docto_guia == null && Docto_guia_Usardatosentrega != null)
            {
                item.Docto_guia = CreateSubEntity<Docto_guia>();
                item.Docto_guia!.Usardatosentrega = Docto_guia_Usardatosentrega?? BoolCNI.N;
            }

            if (item.Docto_guia != null)
                item.Docto_guia!.Estadoguiaid = Docto_guia_Estadoguiaid;
            else if (item.Docto_guia == null && Docto_guia_Estadoguiaid != null)
            {
                item.Docto_guia = CreateSubEntity<Docto_guia>();
                item.Docto_guia!.Estadoguiaid = Docto_guia_Estadoguiaid;
            }

            if (item.Docto_guia != null)
                item.Docto_guia!.Guiaid = Docto_guia_Guiaid;
            else if (item.Docto_guia == null && Docto_guia_Guiaid != null)
            {
                item.Docto_guia = CreateSubEntity<Docto_guia>();
                item.Docto_guia!.Guiaid = Docto_guia_Guiaid;
            }

            if (item.Docto_guia != null)
                item.Docto_guia!.Fechaguiaenviado = Docto_guia_Fechaguiaenviado;
            else if (item.Docto_guia == null && Docto_guia_Fechaguiaenviado != null)
            {
                item.Docto_guia = CreateSubEntity<Docto_guia>();
                item.Docto_guia!.Fechaguiaenviado = Docto_guia_Fechaguiaenviado;
            }

            if (item.Docto_guia != null)
                item.Docto_guia!.Fechaguiarecibido = Docto_guia_Fechaguiarecibido;
            else if (item.Docto_guia == null && Docto_guia_Fechaguiarecibido != null)
            {
                item.Docto_guia = CreateSubEntity<Docto_guia>();
                item.Docto_guia!.Fechaguiarecibido = Docto_guia_Fechaguiarecibido;
            }

            if (item.Docto_guia != null)
                item.Docto_guia!.Personaidguiarecibio = Docto_guia_Personaidguiarecibio;
            else if (item.Docto_guia == null && Docto_guia_Personaidguiarecibio != null)
            {
                item.Docto_guia = CreateSubEntity<Docto_guia>();
                item.Docto_guia!.Personaidguiarecibio = Docto_guia_Personaidguiarecibio;
            }

            if (item.Docto_kit != null)
                item.Docto_kit!.Kitdesglosado = Docto_kit_Kitdesglosado?? BoolCN.N;
            else if (item.Docto_kit == null && Docto_kit_Kitdesglosado != null)
            {
                item.Docto_kit = CreateSubEntity<Docto_kit>();
                item.Docto_kit!.Kitdesglosado = Docto_kit_Kitdesglosado?? BoolCN.N;
            }

            if (item.Docto_kit != null)
                item.Docto_kit!.Doctokitrefid = Docto_kit_Doctokitrefid;
            else if (item.Docto_kit == null && Docto_kit_Doctokitrefid != null)
            {
                item.Docto_kit = CreateSubEntity<Docto_kit>();
                item.Docto_kit!.Doctokitrefid = Docto_kit_Doctokitrefid;
            }

            if (item.Docto_kit != null)
                item.Docto_kit!.Prekitestatus = Docto_kit_Prekitestatus;
            else if (item.Docto_kit == null && Docto_kit_Prekitestatus != null)
            {
                item.Docto_kit = CreateSubEntity<Docto_kit>();
                item.Docto_kit!.Prekitestatus = Docto_kit_Prekitestatus;
            }

            if (item.Docto_kit != null)
                item.Docto_kit!.Postkitestatus = Docto_kit_Postkitestatus;
            else if (item.Docto_kit == null && Docto_kit_Postkitestatus != null)
            {
                item.Docto_kit = CreateSubEntity<Docto_kit>();
                item.Docto_kit!.Postkitestatus = Docto_kit_Postkitestatus;
            }

            if (item.Docto_kit != null)
                item.Docto_kit!.Versionkit = Docto_kit_Versionkit;
            else if (item.Docto_kit == null && Docto_kit_Versionkit != null)
            {
                item.Docto_kit = CreateSubEntity<Docto_kit>();
                item.Docto_kit!.Versionkit = Docto_kit_Versionkit;
            }

            if (item.Docto_monedero != null)
                item.Docto_monedero!.Monedero = Docto_monedero_Monedero;
            else if (item.Docto_monedero == null && Docto_monedero_Monedero != null)
            {
                item.Docto_monedero = CreateSubEntity<Docto_monedero>();
                item.Docto_monedero!.Monedero = Docto_monedero_Monedero;
            }

            if (item.Docto_monedero != null)
                item.Docto_monedero!.Descmonedero = Docto_monedero_Descmonedero?? 0;
            else if (item.Docto_monedero == null && Docto_monedero_Descmonedero != null)
            {
                item.Docto_monedero = CreateSubEntity<Docto_monedero>();
                item.Docto_monedero!.Descmonedero = Docto_monedero_Descmonedero?? 0;
            }

            if (item.Docto_monedero != null)
                item.Docto_monedero!.Abonomonedero = Docto_monedero_Abonomonedero?? 0;
            else if (item.Docto_monedero == null && Docto_monedero_Abonomonedero != null)
            {
                item.Docto_monedero = CreateSubEntity<Docto_monedero>();
                item.Docto_monedero!.Abonomonedero = Docto_monedero_Abonomonedero?? 0;
            }

            if (item.Docto_ordencompra != null)
                item.Docto_ordencompra!.Ordencompra = Docto_ordencompra_Ordencompra;
            else if (item.Docto_ordencompra == null && Docto_ordencompra_Ordencompra != null)
            {
                item.Docto_ordencompra = CreateSubEntity<Docto_ordencompra>();
                item.Docto_ordencompra!.Ordencompra = Docto_ordencompra_Ordencompra;
            }

            if (item.Docto_ordencompra != null)
                item.Docto_ordencompra!.Doctorefid = Docto_ordencompra_Doctorefid;
            else if (item.Docto_ordencompra == null && Docto_ordencompra_Doctorefid != null)
            {
                item.Docto_ordencompra = CreateSubEntity<Docto_ordencompra>();
                item.Docto_ordencompra!.Doctorefid = Docto_ordencompra_Doctorefid;
            }

            if (item.Docto_origenfiscal != null)
                item.Docto_origenfiscal!.Serieorigenfacturado = Docto_origenfiscal_Serieorigenfacturado;
            else if (item.Docto_origenfiscal == null && Docto_origenfiscal_Serieorigenfacturado != null)
            {
                item.Docto_origenfiscal = CreateSubEntity<Docto_origenfiscal>();
                item.Docto_origenfiscal!.Serieorigenfacturado = Docto_origenfiscal_Serieorigenfacturado;
            }

            if (item.Docto_origenfiscal != null)
                item.Docto_origenfiscal!.Folioorigenfacturado = Docto_origenfiscal_Folioorigenfacturado;
            else if (item.Docto_origenfiscal == null && Docto_origenfiscal_Folioorigenfacturado != null)
            {
                item.Docto_origenfiscal = CreateSubEntity<Docto_origenfiscal>();
                item.Docto_origenfiscal!.Folioorigenfacturado = Docto_origenfiscal_Folioorigenfacturado;
            }

            if (item.Docto_origenfiscal != null)
                item.Docto_origenfiscal!.Montoorigenfacturado = Docto_origenfiscal_Montoorigenfacturado;
            else if (item.Docto_origenfiscal == null && Docto_origenfiscal_Montoorigenfacturado != null)
            {
                item.Docto_origenfiscal = CreateSubEntity<Docto_origenfiscal>();
                item.Docto_origenfiscal!.Montoorigenfacturado = Docto_origenfiscal_Montoorigenfacturado;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Notapago = Docto_info_pago_Notapago;
            else if (item.Docto_info_pago == null && Docto_info_pago_Notapago != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Notapago = Docto_info_pago_Notapago;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Hatenidocredito = Docto_info_pago_Hatenidocredito;
            else if (item.Docto_info_pago == null && Docto_info_pago_Hatenidocredito != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Hatenidocredito = Docto_info_pago_Hatenidocredito;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Pagoacredito = Docto_info_pago_Pagoacredito?? BoolCN.N;
            else if (item.Docto_info_pago == null && Docto_info_pago_Pagoacredito != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Pagoacredito = Docto_info_pago_Pagoacredito?? BoolCN.N;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Pagocontarjeta = Docto_info_pago_Pagocontarjeta;
            else if (item.Docto_info_pago == null && Docto_info_pago_Pagocontarjeta != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Pagocontarjeta = Docto_info_pago_Pagocontarjeta;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Abononoaplicado = Docto_info_pago_Abononoaplicado?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Abononoaplicado != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Abononoaplicado = Docto_info_pago_Abononoaplicado?? 0;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Pagodevid = Docto_info_pago_Pagodevid;
            else if (item.Docto_info_pago == null && Docto_info_pago_Pagodevid != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Pagodevid = Docto_info_pago_Pagodevid;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Estatusanticipoid = Docto_info_pago_Estatusanticipoid;
            else if (item.Docto_info_pago == null && Docto_info_pago_Estatusanticipoid != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Estatusanticipoid = Docto_info_pago_Estatusanticipoid;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Totalanticipo = Docto_info_pago_Totalanticipo?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Totalanticipo != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Totalanticipo = Docto_info_pago_Totalanticipo?? 0;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Comisionpagotarjeta = Docto_info_pago_Comisionpagotarjeta?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Comisionpagotarjeta != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Comisionpagotarjeta = Docto_info_pago_Comisionpagotarjeta?? 0;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Comisiontarjetaempresa = Docto_info_pago_Comisiontarjetaempresa?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Comisiontarjetaempresa != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Comisiontarjetaempresa = Docto_info_pago_Comisiontarjetaempresa?? 0;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Ivacomisiontarjetaempresa = Docto_info_pago_Ivacomisiontarjetaempresa?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Ivacomisiontarjetaempresa != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Ivacomisiontarjetaempresa = Docto_info_pago_Ivacomisiontarjetaempresa?? 0;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Abonotarjeta = Docto_info_pago_Abonotarjeta?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Abonotarjeta != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Abonotarjeta = Docto_info_pago_Abonotarjeta?? 0;
            }

            if (item.Docto_info_pago != null)
                item.Docto_info_pago!.Comisiondebtarjetaempresa = Docto_info_pago_Comisiondebtarjetaempresa?? 0;
            else if (item.Docto_info_pago == null && Docto_info_pago_Comisiondebtarjetaempresa != null)
            {
                item.Docto_info_pago = CreateSubEntity<Docto_info_pago>();
                item.Docto_info_pago!.Comisiondebtarjetaempresa = Docto_info_pago_Comisiondebtarjetaempresa?? 0;
            }

            if (item.Docto_poliza != null)
                item.Docto_poliza!.Doctoplazoorigenid = Docto_poliza_Doctoplazoorigenid;
            else if (item.Docto_poliza == null && Docto_poliza_Doctoplazoorigenid != null)
            {
                item.Docto_poliza = CreateSubEntity<Docto_poliza>();
                item.Docto_poliza!.Doctoplazoorigenid = Docto_poliza_Doctoplazoorigenid;
            }

            if (item.Docto_poliza != null)
                item.Docto_poliza!.Plazoid = Docto_poliza_Plazoid;
            else if (item.Docto_poliza == null && Docto_poliza_Plazoid != null)
            {
                item.Docto_poliza = CreateSubEntity<Docto_poliza>();
                item.Docto_poliza!.Plazoid = Docto_poliza_Plazoid;
            }

            if (item.Docto_precio != null)
                item.Docto_precio!.Tipomayoreoid = Docto_precio_Tipomayoreoid;
            else if (item.Docto_precio == null && Docto_precio_Tipomayoreoid != null)
            {
                item.Docto_precio = CreateSubEntity<Docto_precio>();
                item.Docto_precio!.Tipomayoreoid = Docto_precio_Tipomayoreoid;
            }

            if (item.Docto_precio != null)
                item.Docto_precio!.Tipodescuentovale = Docto_precio_Tipodescuentovale;
            else if (item.Docto_precio == null && Docto_precio_Tipodescuentovale != null)
            {
                item.Docto_precio = CreateSubEntity<Docto_precio>();
                item.Docto_precio!.Tipodescuentovale = Docto_precio_Tipodescuentovale;
            }

            if (item.Docto_promocion != null)
                item.Docto_promocion!.Promocion = Docto_promocion_Promocion?? BoolCN.N;
            else if (item.Docto_promocion == null && Docto_promocion_Promocion != null)
            {
                item.Docto_promocion = CreateSubEntity<Docto_promocion>();
                item.Docto_promocion!.Promocion = Docto_promocion_Promocion?? BoolCN.N;
            }

            if (item.Docto_rebajaespecial != null)
                item.Docto_rebajaespecial!.Estadorebaja = Docto_rebajaespecial_Estadorebaja;
            else if (item.Docto_rebajaespecial == null && Docto_rebajaespecial_Estadorebaja != null)
            {
                item.Docto_rebajaespecial = CreateSubEntity<Docto_rebajaespecial>();
                item.Docto_rebajaespecial!.Estadorebaja = Docto_rebajaespecial_Estadorebaja;
            }

            if (item.Docto_rebajaespecial != null)
                item.Docto_rebajaespecial!.Montorebaja = Docto_rebajaespecial_Montorebaja?? 0;
            else if (item.Docto_rebajaespecial == null && Docto_rebajaespecial_Montorebaja != null)
            {
                item.Docto_rebajaespecial = CreateSubEntity<Docto_rebajaespecial>();
                item.Docto_rebajaespecial!.Montorebaja = Docto_rebajaespecial_Montorebaja?? 0;
            }

            if (item.Docto_rebajaespecial != null)
                item.Docto_rebajaespecial!.Totalconrebaja = Docto_rebajaespecial_Totalconrebaja?? 0;
            else if (item.Docto_rebajaespecial == null && Docto_rebajaespecial_Totalconrebaja != null)
            {
                item.Docto_rebajaespecial = CreateSubEntity<Docto_rebajaespecial>();
                item.Docto_rebajaespecial!.Totalconrebaja = Docto_rebajaespecial_Totalconrebaja?? 0;
            }

            if (item.Docto_revision != null)
                item.Docto_revision!.Estadorevisadoid = Docto_revision_Estadorevisadoid;
            else if (item.Docto_revision == null && Docto_revision_Estadorevisadoid != null)
            {
                item.Docto_revision = CreateSubEntity<Docto_revision>();
                item.Docto_revision!.Estadorevisadoid = Docto_revision_Estadorevisadoid;
            }

            if (item.Docto_rutaembarque != null)
                item.Docto_rutaembarque!.Rutaembarqueid = Docto_rutaembarque_Rutaembarqueid;
            else if (item.Docto_rutaembarque == null && Docto_rutaembarque_Rutaembarqueid != null)
            {
                item.Docto_rutaembarque = CreateSubEntity<Docto_rutaembarque>();
                item.Docto_rutaembarque!.Rutaembarqueid = Docto_rutaembarque_Rutaembarqueid;
            }

            if (item.Docto_serviciodomicilio != null)
                item.Docto_serviciodomicilio!.Esservdomicilio = Docto_serviciodomicilio_Esservdomicilio;
            else if (item.Docto_serviciodomicilio == null && Docto_serviciodomicilio_Esservdomicilio != null)
            {
                item.Docto_serviciodomicilio = CreateSubEntity<Docto_serviciodomicilio>();
                item.Docto_serviciodomicilio!.Esservdomicilio = Docto_serviciodomicilio_Esservdomicilio;
            }

            if (item.Docto_serviciodomicilio != null)
                item.Docto_serviciodomicilio!.Domicilioentregaid = Docto_serviciodomicilio_Domicilioentregaid;
            else if (item.Docto_serviciodomicilio == null && Docto_serviciodomicilio_Domicilioentregaid != null)
            {
                item.Docto_serviciodomicilio = CreateSubEntity<Docto_serviciodomicilio>();
                item.Docto_serviciodomicilio!.Domicilioentregaid = Docto_serviciodomicilio_Domicilioentregaid;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Procesosurtido = Docto_surtido_Procesosurtido?? BoolCN.N;
            else if (item.Docto_surtido == null && Docto_surtido_Procesosurtido != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Procesosurtido = Docto_surtido_Procesosurtido?? BoolCN.N;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Notasurtido = Docto_surtido_Notasurtido;
            else if (item.Docto_surtido == null && Docto_surtido_Notasurtido != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Notasurtido = Docto_surtido_Notasurtido;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Pendmaxfecha = Docto_surtido_Pendmaxfecha;
            else if (item.Docto_surtido == null && Docto_surtido_Pendmaxfecha != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Pendmaxfecha = Docto_surtido_Pendmaxfecha;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Estadosurtidoid = Docto_surtido_Estadosurtidoid;
            else if (item.Docto_surtido == null && Docto_surtido_Estadosurtidoid != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Estadosurtidoid = Docto_surtido_Estadosurtidoid;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Estatusdoctopedidoid = Docto_surtido_Estatusdoctopedidoid;
            else if (item.Docto_surtido == null && Docto_surtido_Estatusdoctopedidoid != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Estatusdoctopedidoid = Docto_surtido_Estatusdoctopedidoid;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Fechasurtido = Docto_surtido_Fechasurtido;
            else if (item.Docto_surtido == null && Docto_surtido_Fechasurtido != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Fechasurtido = Docto_surtido_Fechasurtido;
            }

            if (item.Docto_surtido != null)
                item.Docto_surtido!.Personaidsurtido = Docto_surtido_Personaidsurtido;
            else if (item.Docto_surtido == null && Docto_surtido_Personaidsurtido != null)
            {
                item.Docto_surtido = CreateSubEntity<Docto_surtido>();
                item.Docto_surtido!.Personaidsurtido = Docto_surtido_Personaidsurtido;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Foliosolicitudmercancia = Docto_traslado_Foliosolicitudmercancia;
            else if (item.Docto_traslado == null && Docto_traslado_Foliosolicitudmercancia != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Foliosolicitudmercancia = Docto_traslado_Foliosolicitudmercancia;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Foliotrasladooriginal = Docto_traslado_Foliotrasladooriginal;
            else if (item.Docto_traslado == null && Docto_traslado_Foliotrasladooriginal != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Foliotrasladooriginal = Docto_traslado_Foliotrasladooriginal;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Estraslado = Docto_traslado_Estraslado;
            else if (item.Docto_traslado == null && Docto_traslado_Estraslado != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Estraslado = Docto_traslado_Estraslado;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Esdevolucion = Docto_traslado_Esdevolucion;
            else if (item.Docto_traslado == null && Docto_traslado_Esdevolucion != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Esdevolucion = Docto_traslado_Esdevolucion;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Foliodevolucion = Docto_traslado_Foliodevolucion;
            else if (item.Docto_traslado == null && Docto_traslado_Foliodevolucion != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Foliodevolucion = Docto_traslado_Foliodevolucion;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Essurtimientomerca = Docto_traslado_Essurtimientomerca;
            else if (item.Docto_traslado == null && Docto_traslado_Essurtimientomerca != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Essurtimientomerca = Docto_traslado_Essurtimientomerca;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Sucursaltid = Docto_traslado_Sucursaltid;
            else if (item.Docto_traslado == null && Docto_traslado_Sucursaltid != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Sucursaltid = Docto_traslado_Sucursaltid;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Almacentid = Docto_traslado_Almacentid;
            else if (item.Docto_traslado == null && Docto_traslado_Almacentid != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Almacentid = Docto_traslado_Almacentid;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Doctoimportadoid = Docto_traslado_Doctoimportadoid;
            else if (item.Docto_traslado == null && Docto_traslado_Doctoimportadoid != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Doctoimportadoid = Docto_traslado_Doctoimportadoid;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Idsolicitudmercancia = Docto_traslado_Idsolicitudmercancia;
            else if (item.Docto_traslado == null && Docto_traslado_Idsolicitudmercancia != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Idsolicitudmercancia = Docto_traslado_Idsolicitudmercancia;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Idtrasladooriginal = Docto_traslado_Idtrasladooriginal;
            else if (item.Docto_traslado == null && Docto_traslado_Idtrasladooriginal != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Idtrasladooriginal = Docto_traslado_Idtrasladooriginal;
            }

            if (item.Docto_traslado != null)
                item.Docto_traslado!.Iddevolucion = Docto_traslado_Iddevolucion;
            else if (item.Docto_traslado == null && Docto_traslado_Iddevolucion != null)
            {
                item.Docto_traslado = CreateSubEntity<Docto_traslado>();
                item.Docto_traslado!.Iddevolucion = Docto_traslado_Iddevolucion;
            }

            if (item.Docto_utilidad != null)
                item.Docto_utilidad!.Utilidad = Docto_utilidad_Utilidad?? 0;
            else if (item.Docto_utilidad == null && Docto_utilidad_Utilidad != null)
            {
                item.Docto_utilidad = CreateSubEntity<Docto_utilidad>();
                item.Docto_utilidad!.Utilidad = Docto_utilidad_Utilidad?? 0;
            }

            if (item.Docto_utilidad != null)
                item.Docto_utilidad!.Vendedorutilidadid = Docto_utilidad_Vendedorutilidadid;
            else if (item.Docto_utilidad == null && Docto_utilidad_Vendedorutilidadid != null)
            {
                item.Docto_utilidad = CreateSubEntity<Docto_utilidad>();
                item.Docto_utilidad!.Vendedorutilidadid = Docto_utilidad_Vendedorutilidadid;
            }

            if (item.Docto_ventafuturo != null)
                item.Docto_ventafuturo!.Ventafutuid = Docto_ventafuturo_Ventafutuid;
            else if (item.Docto_ventafuturo == null && Docto_ventafuturo_Ventafutuid != null)
            {
                item.Docto_ventafuturo = CreateSubEntity<Docto_ventafuturo>();
                item.Docto_ventafuturo!.Ventafutuid = Docto_ventafuturo_Ventafutuid;
            }


        }

        public void FillFromEntity(Docto item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Serie = item.Serie;

            Esapartado = item.Esapartado;

            Referencia = item.Referencia;

            Referencias = item.Referencias;

            Estatusdoctoid = item.Estatusdoctoid;

            Usuarioid = item.Usuarioid;

            Corteid = item.Corteid;

            Fecha = item.Fecha;

            Fechahora = item.Fechahora;

            Folio = item.Folio;

            Importe = item.Importe;

            Descuento = item.Descuento;

            Subtotal = item.Subtotal;

            Iva = item.Iva;

            Ieps = item.Ieps;

            Total = item.Total;

            Cargo = item.Cargo;

            Abono = item.Abono;

            Saldo = item.Saldo;

            Cajaid = item.Cajaid;

            Almacenid = item.Almacenid;

            Origenfiscalid = item.Origenfiscalid;

            Doctoparentid = item.Doctoparentid;

            Clienteid = item.Clienteid;

            Tipodoctoid = item.Tipodoctoid;

            Proveedorid = item.Proveedorid;

            Sucursal_id = item.Sucursal_id;

            Subtipodoctoid = item.Subtipodoctoid;

            Tipodiferenciainventarioid = item.Tipodiferenciainventarioid;

            Clave = item.Clave;

            Nombre = item.Nombre;


            if (item.Fechavence != null)
                Fechavence = item.Fechavence;


            if (item.Docto_alerta != null && item.Docto_alerta?.Autorizoalertaid != null)
                    Docto_alerta_Autorizoalertaid = item.Docto_alerta!.Autorizoalertaid;

            if (item.Docto_apartado != null && item.Docto_apartado?.Mercanciaentregada != null)
                    Docto_apartado_Mercanciaentregada = item.Docto_apartado!.Mercanciaentregada;

            if (item.Docto_apartado != null && item.Docto_apartado?.Personaapartadoid != null)
                    Docto_apartado_Personaapartadoid = item.Docto_apartado!.Personaapartadoid;

            if (item.Docto_bancomer != null && item.Docto_bancomer?.Pagobancomeraplicado != null)
                    Docto_bancomer_Pagobancomeraplicado = item.Docto_bancomer!.Pagobancomeraplicado;

            if (item.Docto_cobranza != null && item.Docto_cobranza?.Fechaaprobacioncxc != null)
                    Docto_cobranza_Fechaaprobacioncxc = item.Docto_cobranza!.Fechaaprobacioncxc;

            if (item.Docto_cobranza != null && item.Docto_cobranza?.Personaidaprobacioncxc != null)
                    Docto_cobranza_Personaidaprobacioncxc = item.Docto_cobranza!.Personaidaprobacioncxc;

            if (item.Docto_comision != null && item.Docto_comision?.Vendedorfinal != null)
                    Docto_comision_Vendedorfinal = item.Docto_comision!.Vendedorfinal;

            if (item.Docto_comision != null && item.Docto_comision?.Vendedorejecutivoid != null)
                    Docto_comision_Vendedorejecutivoid = item.Docto_comision!.Vendedorejecutivoid;

            if (item.Docto_comision != null && item.Docto_comision?.Comision != null)
                    Docto_comision_Comision = item.Docto_comision!.Comision;

            if (item.Docto_compra != null && item.Docto_compra?.Folio != null)
                    Docto_compra_Folio = item.Docto_compra!.Folio;

            if (item.Docto_compra != null && item.Docto_compra?.Factura != null)
                    Docto_compra_Factura = item.Docto_compra!.Factura;

            if (item.Docto_compra != null && item.Docto_compra?.Fechafactura != null)
                    Docto_compra_Fechafactura = item.Docto_compra!.Fechafactura;


            if (item.Docto_contrarecibo != null && item.Docto_contrarecibo?.Contrareciboid != null)
                    Docto_contrarecibo_Contrareciboid = item.Docto_contrarecibo!.Contrareciboid;

            if (item.Docto_cancelacion != null && item.Docto_cancelacion?.Doctorefid != null)
                    Docto_cancelacion_Doctorefid = item.Docto_cancelacion!.Doctorefid;

            if (item.Docto_devolucion != null && item.Docto_devolucion?.Doctorefid != null)
                    Docto_devolucion_Doctorefid = item.Docto_devolucion!.Doctorefid;

            if (item.Docto_loteimportado != null && item.Docto_loteimportado?.Loteimportadodoctoid != null)
                    Docto_loteimportado_Loteimportadodoctoid = item.Docto_loteimportado!.Loteimportadodoctoid;

            if (item.Docto_corte != null && item.Docto_corte?.Fechacorte != null)
                    Docto_corte_Fechacorte = item.Docto_corte!.Fechacorte;

            if (item.Docto_corte != null && item.Docto_corte?.Montobilletesid != null)
                    Docto_corte_Montobilletesid = item.Docto_corte!.Montobilletesid;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradouuid != null)
                    Docto_fact_elect_Timbradouuid = item.Docto_fact_elect!.Timbradouuid;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradofecha != null)
                    Docto_fact_elect_Timbradofecha = item.Docto_fact_elect!.Timbradofecha;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradocertsat != null)
                    Docto_fact_elect_Timbradocertsat = item.Docto_fact_elect!.Timbradocertsat;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradosellosat != null)
                    Docto_fact_elect_Timbradosellosat = item.Docto_fact_elect!.Timbradosellosat;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradosellocfdi != null)
                    Docto_fact_elect_Timbradosellocfdi = item.Docto_fact_elect!.Timbradosellocfdi;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradocancelado != null)
                    Docto_fact_elect_Timbradocancelado = item.Docto_fact_elect!.Timbradocancelado;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradouuidcancelacion != null)
                    Docto_fact_elect_Timbradouuidcancelacion = item.Docto_fact_elect!.Timbradouuidcancelacion;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradoformapagosat != null)
                    Docto_fact_elect_Timbradoformapagosat = item.Docto_fact_elect!.Timbradoformapagosat;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Seriesat != null)
                    Docto_fact_elect_Seriesat = item.Docto_fact_elect!.Seriesat;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Esfacturaelectronica != null)
                    Docto_fact_elect_Esfacturaelectronica = item.Docto_fact_elect!.Esfacturaelectronica;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradofechacancelacion != null)
                    Docto_fact_elect_Timbradofechacancelacion = item.Docto_fact_elect!.Timbradofechacancelacion;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Timbradofechafactura != null)
                    Docto_fact_elect_Timbradofechafactura = item.Docto_fact_elect!.Timbradofechafactura;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Foliosat != null)
                    Docto_fact_elect_Foliosat = item.Docto_fact_elect!.Foliosat;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Fechafactura != null)
                    Docto_fact_elect_Fechafactura = item.Docto_fact_elect!.Fechafactura;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Sat_usocfdiid != null)
                    Docto_fact_elect_Sat_usocfdiid = item.Docto_fact_elect!.Sat_usocfdiid;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Cfdiid != null)
                    Docto_fact_elect_Cfdiid = item.Docto_fact_elect!.Cfdiid;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Ivaretenido != null)
                    Docto_fact_elect_Ivaretenido = item.Docto_fact_elect!.Ivaretenido;

            if (item.Docto_fact_elect != null && item.Docto_fact_elect?.Isrretenido != null)
                    Docto_fact_elect_Isrretenido = item.Docto_fact_elect!.Isrretenido;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Factconsaplicado != null)
                    Docto_fact_elect_consolidacion_Factconsaplicado = item.Docto_fact_elect_consolidacion!.Factconsaplicado;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Omitirvales != null)
                    Docto_fact_elect_consolidacion_Omitirvales = item.Docto_fact_elect_consolidacion!.Omitirvales;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Factconsid != null)
                    Docto_fact_elect_consolidacion_Factconsid = item.Docto_fact_elect_consolidacion!.Factconsid;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Devconsid != null)
                    Docto_fact_elect_consolidacion_Devconsid = item.Docto_fact_elect_consolidacion!.Devconsid;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Doctorefid2 != null)
                    Docto_fact_elect_consolidacion_Doctorefid2 = item.Docto_fact_elect_consolidacion!.Doctorefid2;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Consolidado_subtotal != null)
                    Docto_fact_elect_consolidacion_Consolidado_subtotal = item.Docto_fact_elect_consolidacion!.Consolidado_subtotal;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Consolidado_iva != null)
                    Docto_fact_elect_consolidacion_Consolidado_iva = item.Docto_fact_elect_consolidacion!.Consolidado_iva;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Consolidado_ieps != null)
                    Docto_fact_elect_consolidacion_Consolidado_ieps = item.Docto_fact_elect_consolidacion!.Consolidado_ieps;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Consolidado_total != null)
                    Docto_fact_elect_consolidacion_Consolidado_total = item.Docto_fact_elect_consolidacion!.Consolidado_total;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Consolidado_iva_ret != null)
                    Docto_fact_elect_consolidacion_Consolidado_iva_ret = item.Docto_fact_elect_consolidacion!.Consolidado_iva_ret;

            if (item.Docto_fact_elect_consolidacion != null && item.Docto_fact_elect_consolidacion?.Consolidado_isr_ret != null)
                    Docto_fact_elect_consolidacion_Consolidado_isr_ret = item.Docto_fact_elect_consolidacion!.Consolidado_isr_ret;

            if (item.Docto_fact_elect_pagos != null && item.Docto_fact_elect_pagos?.Timbradoformapagosat != null)
                    Docto_fact_elect_pagos_Timbradoformapagosat = item.Docto_fact_elect_pagos!.Timbradoformapagosat;

            if (item.Docto_fact_elect_pagos != null && item.Docto_fact_elect_pagos?.Doctopagosat != null)
                    Docto_fact_elect_pagos_Doctopagosat = item.Docto_fact_elect_pagos!.Doctopagosat;

            if (item.Docto_fact_elect_pagos != null && item.Docto_fact_elect_pagos?.Pagosat != null)
                    Docto_fact_elect_pagos_Pagosat = item.Docto_fact_elect_pagos!.Pagosat;

            if (item.Docto_fact_elect_sustitucion != null && item.Docto_fact_elect_sustitucion?.Doctosustitutoid != null)
                    Docto_fact_elect_sustitucion_Doctosustitutoid = item.Docto_fact_elect_sustitucion!.Doctosustitutoid;

            if (item.Docto_fact_elect_sustitucion != null && item.Docto_fact_elect_sustitucion?.Doctoasustituirid != null)
                    Docto_fact_elect_sustitucion_Doctoasustituirid = item.Docto_fact_elect_sustitucion!.Doctoasustituirid;

            if (item.Docto_farmacia != null && item.Docto_farmacia?.Manejoreceta != null)
                    Docto_farmacia_Manejoreceta = item.Docto_farmacia!.Manejoreceta;

            if (item.Docto_guia != null && item.Docto_guia?.Usardatosentrega != null)
                    Docto_guia_Usardatosentrega = item.Docto_guia!.Usardatosentrega;

            if (item.Docto_guia != null && item.Docto_guia?.Estadoguiaid != null)
                    Docto_guia_Estadoguiaid = item.Docto_guia!.Estadoguiaid;

            if (item.Docto_guia != null && item.Docto_guia?.Guiaid != null)
                    Docto_guia_Guiaid = item.Docto_guia!.Guiaid;

            if (item.Docto_guia != null && item.Docto_guia?.Fechaguiaenviado != null)
                    Docto_guia_Fechaguiaenviado = item.Docto_guia!.Fechaguiaenviado;

            if (item.Docto_guia != null && item.Docto_guia?.Fechaguiarecibido != null)
                    Docto_guia_Fechaguiarecibido = item.Docto_guia!.Fechaguiarecibido;

            if (item.Docto_guia != null && item.Docto_guia?.Personaidguiarecibio != null)
                    Docto_guia_Personaidguiarecibio = item.Docto_guia!.Personaidguiarecibio;

            if (item.Docto_kit != null && item.Docto_kit?.Kitdesglosado != null)
                    Docto_kit_Kitdesglosado = item.Docto_kit!.Kitdesglosado;

            if (item.Docto_kit != null && item.Docto_kit?.Doctokitrefid != null)
                    Docto_kit_Doctokitrefid = item.Docto_kit!.Doctokitrefid;

            if (item.Docto_kit != null && item.Docto_kit?.Prekitestatus != null)
                    Docto_kit_Prekitestatus = item.Docto_kit!.Prekitestatus;

            if (item.Docto_kit != null && item.Docto_kit?.Postkitestatus != null)
                    Docto_kit_Postkitestatus = item.Docto_kit!.Postkitestatus;

            if (item.Docto_kit != null && item.Docto_kit?.Versionkit != null)
                    Docto_kit_Versionkit = item.Docto_kit!.Versionkit;

            if (item.Docto_monedero != null && item.Docto_monedero?.Monedero != null)
                    Docto_monedero_Monedero = item.Docto_monedero!.Monedero;

            if (item.Docto_monedero != null && item.Docto_monedero?.Descmonedero != null)
                    Docto_monedero_Descmonedero = item.Docto_monedero!.Descmonedero;

            if (item.Docto_monedero != null && item.Docto_monedero?.Abonomonedero != null)
                    Docto_monedero_Abonomonedero = item.Docto_monedero!.Abonomonedero;

            if (item.Docto_ordencompra != null && item.Docto_ordencompra?.Ordencompra != null)
                    Docto_ordencompra_Ordencompra = item.Docto_ordencompra!.Ordencompra;

            if (item.Docto_ordencompra != null && item.Docto_ordencompra?.Doctorefid != null)
                    Docto_ordencompra_Doctorefid = item.Docto_ordencompra!.Doctorefid;

            if (item.Docto_origenfiscal != null && item.Docto_origenfiscal?.Serieorigenfacturado != null)
                    Docto_origenfiscal_Serieorigenfacturado = item.Docto_origenfiscal!.Serieorigenfacturado;

            if (item.Docto_origenfiscal != null && item.Docto_origenfiscal?.Folioorigenfacturado != null)
                    Docto_origenfiscal_Folioorigenfacturado = item.Docto_origenfiscal!.Folioorigenfacturado;

            if (item.Docto_origenfiscal != null && item.Docto_origenfiscal?.Montoorigenfacturado != null)
                    Docto_origenfiscal_Montoorigenfacturado = item.Docto_origenfiscal!.Montoorigenfacturado;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Notapago != null)
                    Docto_info_pago_Notapago = item.Docto_info_pago!.Notapago;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Hatenidocredito != null)
                    Docto_info_pago_Hatenidocredito = item.Docto_info_pago!.Hatenidocredito;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Pagoacredito != null)
                    Docto_info_pago_Pagoacredito = item.Docto_info_pago!.Pagoacredito;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Pagocontarjeta != null)
                    Docto_info_pago_Pagocontarjeta = item.Docto_info_pago!.Pagocontarjeta;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Abononoaplicado != null)
                    Docto_info_pago_Abononoaplicado = item.Docto_info_pago!.Abononoaplicado;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Pagodevid != null)
                    Docto_info_pago_Pagodevid = item.Docto_info_pago!.Pagodevid;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Estatusanticipoid != null)
                    Docto_info_pago_Estatusanticipoid = item.Docto_info_pago!.Estatusanticipoid;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Totalanticipo != null)
                    Docto_info_pago_Totalanticipo = item.Docto_info_pago!.Totalanticipo;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Comisionpagotarjeta != null)
                    Docto_info_pago_Comisionpagotarjeta = item.Docto_info_pago!.Comisionpagotarjeta;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Comisiontarjetaempresa != null)
                    Docto_info_pago_Comisiontarjetaempresa = item.Docto_info_pago!.Comisiontarjetaempresa;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Ivacomisiontarjetaempresa != null)
                    Docto_info_pago_Ivacomisiontarjetaempresa = item.Docto_info_pago!.Ivacomisiontarjetaempresa;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Abonotarjeta != null)
                    Docto_info_pago_Abonotarjeta = item.Docto_info_pago!.Abonotarjeta;

            if (item.Docto_info_pago != null && item.Docto_info_pago?.Comisiondebtarjetaempresa != null)
                    Docto_info_pago_Comisiondebtarjetaempresa = item.Docto_info_pago!.Comisiondebtarjetaempresa;

            if (item.Docto_poliza != null && item.Docto_poliza?.Doctoplazoorigenid != null)
                    Docto_poliza_Doctoplazoorigenid = item.Docto_poliza!.Doctoplazoorigenid;

            if (item.Docto_poliza != null && item.Docto_poliza?.Plazoid != null)
                    Docto_poliza_Plazoid = item.Docto_poliza!.Plazoid;

            if (item.Docto_precio != null && item.Docto_precio?.Tipomayoreoid != null)
                    Docto_precio_Tipomayoreoid = item.Docto_precio!.Tipomayoreoid;

            if (item.Docto_precio != null && item.Docto_precio?.Tipodescuentovale != null)
                    Docto_precio_Tipodescuentovale = item.Docto_precio!.Tipodescuentovale;

            if (item.Docto_promocion != null && item.Docto_promocion?.Promocion != null)
                    Docto_promocion_Promocion = item.Docto_promocion!.Promocion;

            if (item.Docto_rebajaespecial != null && item.Docto_rebajaespecial?.Estadorebaja != null)
                    Docto_rebajaespecial_Estadorebaja = item.Docto_rebajaespecial!.Estadorebaja;

            if (item.Docto_rebajaespecial != null && item.Docto_rebajaespecial?.Montorebaja != null)
                    Docto_rebajaespecial_Montorebaja = item.Docto_rebajaespecial!.Montorebaja;

            if (item.Docto_rebajaespecial != null && item.Docto_rebajaespecial?.Totalconrebaja != null)
                    Docto_rebajaespecial_Totalconrebaja = item.Docto_rebajaespecial!.Totalconrebaja;

            if (item.Docto_revision != null && item.Docto_revision?.Estadorevisadoid != null)
                    Docto_revision_Estadorevisadoid = item.Docto_revision!.Estadorevisadoid;

            if (item.Docto_rutaembarque != null && item.Docto_rutaembarque?.Rutaembarqueid != null)
                    Docto_rutaembarque_Rutaembarqueid = item.Docto_rutaembarque!.Rutaembarqueid;

            if (item.Docto_serviciodomicilio != null && item.Docto_serviciodomicilio?.Esservdomicilio != null)
                    Docto_serviciodomicilio_Esservdomicilio = item.Docto_serviciodomicilio!.Esservdomicilio;

            if (item.Docto_serviciodomicilio != null && item.Docto_serviciodomicilio?.Domicilioentregaid != null)
                    Docto_serviciodomicilio_Domicilioentregaid = item.Docto_serviciodomicilio!.Domicilioentregaid;

            if (item.Docto_surtido != null && item.Docto_surtido?.Procesosurtido != null)
                    Docto_surtido_Procesosurtido = item.Docto_surtido!.Procesosurtido;

            if (item.Docto_surtido != null && item.Docto_surtido?.Notasurtido != null)
                    Docto_surtido_Notasurtido = item.Docto_surtido!.Notasurtido;

            if (item.Docto_surtido != null && item.Docto_surtido?.Pendmaxfecha != null)
                    Docto_surtido_Pendmaxfecha = item.Docto_surtido!.Pendmaxfecha;

            if (item.Docto_surtido != null && item.Docto_surtido?.Estadosurtidoid != null)
                    Docto_surtido_Estadosurtidoid = item.Docto_surtido!.Estadosurtidoid;

            if (item.Docto_surtido != null && item.Docto_surtido?.Estatusdoctopedidoid != null)
                    Docto_surtido_Estatusdoctopedidoid = item.Docto_surtido!.Estatusdoctopedidoid;

            if (item.Docto_surtido != null && item.Docto_surtido?.Fechasurtido != null)
                    Docto_surtido_Fechasurtido = item.Docto_surtido!.Fechasurtido;

            if (item.Docto_surtido != null && item.Docto_surtido?.Personaidsurtido != null)
                    Docto_surtido_Personaidsurtido = item.Docto_surtido!.Personaidsurtido;

            if (item.Docto_traslado != null && item.Docto_traslado?.Foliosolicitudmercancia != null)
                    Docto_traslado_Foliosolicitudmercancia = item.Docto_traslado!.Foliosolicitudmercancia;

            if (item.Docto_traslado != null && item.Docto_traslado?.Foliotrasladooriginal != null)
                    Docto_traslado_Foliotrasladooriginal = item.Docto_traslado!.Foliotrasladooriginal;

            if (item.Docto_traslado != null && item.Docto_traslado?.Estraslado != null)
                    Docto_traslado_Estraslado = item.Docto_traslado!.Estraslado;

            if (item.Docto_traslado != null && item.Docto_traslado?.Esdevolucion != null)
                    Docto_traslado_Esdevolucion = item.Docto_traslado!.Esdevolucion;

            if (item.Docto_traslado != null && item.Docto_traslado?.Foliodevolucion != null)
                    Docto_traslado_Foliodevolucion = item.Docto_traslado!.Foliodevolucion;

            if (item.Docto_traslado != null && item.Docto_traslado?.Essurtimientomerca != null)
                    Docto_traslado_Essurtimientomerca = item.Docto_traslado!.Essurtimientomerca;

            if (item.Docto_traslado != null && item.Docto_traslado?.Sucursaltid != null)
                    Docto_traslado_Sucursaltid = item.Docto_traslado!.Sucursaltid;

            if (item.Docto_traslado != null && item.Docto_traslado?.Almacentid != null)
                    Docto_traslado_Almacentid = item.Docto_traslado!.Almacentid;

            if (item.Docto_traslado != null && item.Docto_traslado?.Doctoimportadoid != null)
                    Docto_traslado_Doctoimportadoid = item.Docto_traslado!.Doctoimportadoid;

            if (item.Docto_traslado != null && item.Docto_traslado?.Idsolicitudmercancia != null)
                    Docto_traslado_Idsolicitudmercancia = item.Docto_traslado!.Idsolicitudmercancia;

            if (item.Docto_traslado != null && item.Docto_traslado?.Idtrasladooriginal != null)
                    Docto_traslado_Idtrasladooriginal = item.Docto_traslado!.Idtrasladooriginal;

            if (item.Docto_traslado != null && item.Docto_traslado?.Iddevolucion != null)
                    Docto_traslado_Iddevolucion = item.Docto_traslado!.Iddevolucion;

            if (item.Docto_utilidad != null && item.Docto_utilidad?.Utilidad != null)
                    Docto_utilidad_Utilidad = item.Docto_utilidad!.Utilidad;

            if (item.Docto_utilidad != null && item.Docto_utilidad?.Vendedorutilidadid != null)
                    Docto_utilidad_Vendedorutilidadid = item.Docto_utilidad!.Vendedorutilidadid;

            if (item.Docto_ventafuturo != null && item.Docto_ventafuturo?.Ventafutuid != null)
                    Docto_ventafuturo_Ventafutuid = item.Docto_ventafuturo!.Ventafutuid;


             FillCatalogRelatedFields(item);


        }
        #endif





    }
}

