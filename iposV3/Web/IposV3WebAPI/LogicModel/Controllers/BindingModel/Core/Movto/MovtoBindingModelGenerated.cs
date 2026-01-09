
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
    
    public class MovtoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public MovtoBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB

        public MovtoBindingModelGenerated(Movto item)
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

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private BoolCS? _Afectainventario;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Afectainventario { get => _Afectainventario?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Afectainventario)) { _Afectainventario = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Afectatotales;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Afectatotales { get => _Afectatotales?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Afectatotales)) { _Afectatotales = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCN? _Eskit;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Eskit { get => _Eskit?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Eskit)) { _Eskit = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Kitimpfijo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Kitimpfijo { get => _Kitimpfijo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Kitimpfijo)) { _Kitimpfijo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Partida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Partida { get => _Partida?? 0; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value?? 0; OnPropertyChanged(); } } }

        private long? _Estatusmovtoid;
        [XmlAttribute]
        public long? Estatusmovtoid { get => _Estatusmovtoid; set { if (RaiseAcceptPendingChange(value, _Estatusmovtoid)) { _Estatusmovtoid = value; OnPropertyChanged(); } } }

        private string? _EstatusmovtoClave;
        [XmlAttribute]
        public string? EstatusmovtoClave { get => _EstatusmovtoClave; set { if (RaiseAcceptPendingChange(value, _EstatusmovtoClave)) { _EstatusmovtoClave = value; OnPropertyChanged(); } } }

        private string? _EstatusmovtoNombre;
        [XmlAttribute]
        public string? EstatusmovtoNombre { get => _EstatusmovtoNombre; set { if (RaiseAcceptPendingChange(value, _EstatusmovtoNombre)) { _EstatusmovtoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _ProductoClave;
        [XmlAttribute]
        public string? ProductoClave { get => _ProductoClave; set { if (RaiseAcceptPendingChange(value, _ProductoClave)) { _ProductoClave = value; OnPropertyChanged(); } } }

        private string? _ProductoNombre;
        [XmlAttribute]
        public string? ProductoNombre { get => _ProductoNombre; set { if (RaiseAcceptPendingChange(value, _ProductoNombre)) { _ProductoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidad { get => _Cantidad?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Preciolista;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciolista { get => _Preciolista?? 0; set { if (RaiseAcceptPendingChange(value, _Preciolista)) { _Preciolista = value?? 0; OnPropertyChanged(); } } }

        public decimal? _Descuentoporcentaje;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuento { get => _Descuento?? 0; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value?? 0; OnPropertyChanged(); } } }

        public decimal? _Precio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio { get => _Precio?? 0; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotal { get => _Subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Iva { get => _Iva?? 0; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ieps { get => _Ieps?? 0; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaiva { get => _Tasaiva?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaieps { get => _Tasaieps?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Total { get => _Total?? 0; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Loteimportado;
        [XmlAttribute]
        public long? Loteimportado { get => _Loteimportado; set { if (RaiseAcceptPendingChange(value, _Loteimportado)) { _Loteimportado = value; OnPropertyChanged(); } } }

        private string? _Loteimportado_Clave;
        [XmlAttribute]
        public string? Loteimportado_Clave { get => _Loteimportado_Clave; set { if (RaiseAcceptPendingChange(value, _Loteimportado_Clave)) { _Loteimportado_Clave = value; OnPropertyChanged(); } } }

        private string? _Loteimportado_Nombre;
        [XmlAttribute]
        public string? Loteimportado_Nombre { get => _Loteimportado_Nombre; set { if (RaiseAcceptPendingChange(value, _Loteimportado_Nombre)) { _Loteimportado_Nombre = value; OnPropertyChanged(); } } }

        private long? _Movtoparentid;
        [XmlAttribute]
        public long? Movtoparentid { get => _Movtoparentid; set { if (RaiseAcceptPendingChange(value, _Movtoparentid)) { _Movtoparentid = value; OnPropertyChanged(); } } }

        private string? _MovtoparentClave;
        [XmlAttribute]
        public string? MovtoparentClave { get => _MovtoparentClave; set { if (RaiseAcceptPendingChange(value, _MovtoparentClave)) { _MovtoparentClave = value; OnPropertyChanged(); } } }

        private string? _MovtoparentNombre;
        [XmlAttribute]
        public string? MovtoparentNombre { get => _MovtoparentNombre; set { if (RaiseAcceptPendingChange(value, _MovtoparentNombre)) { _MovtoparentNombre = value; OnPropertyChanged(); } } }

        private int? _Movtonivel;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Movtonivel { get => _Movtonivel?? 0; set { if (RaiseAcceptPendingChange(value, _Movtonivel)) { _Movtonivel = value?? 0; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private string? _DoctoClave;
        [XmlAttribute]
        public string? DoctoClave { get => _DoctoClave; set { if (RaiseAcceptPendingChange(value, _DoctoClave)) { _DoctoClave = value; OnPropertyChanged(); } } }

        private string? _DoctoNombre;
        [XmlAttribute]
        public string? DoctoNombre { get => _DoctoNombre; set { if (RaiseAcceptPendingChange(value, _DoctoNombre)) { _DoctoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Cargo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cargo { get => _Cargo?? 0; set { if (RaiseAcceptPendingChange(value, _Cargo)) { _Cargo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Abono { get => _Abono?? 0; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldo { get => _Saldo?? 0; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Preciomanual;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciomanual { get => _Preciomanual?? 0; set { if (RaiseAcceptPendingChange(value, _Preciomanual)) { _Preciomanual = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Preciomaximopublico;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciomaximopublico { get => _Preciomaximopublico?? 0; set { if (RaiseAcceptPendingChange(value, _Preciomaximopublico)) { _Preciomaximopublico = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Isrretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Isrretenido { get => _Isrretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Isrretenido)) { _Isrretenido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ivaretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ivaretenido { get => _Ivaretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Ivaretenido)) { _Ivaretenido = value?? 0; OnPropertyChanged(); } } }

        private int? _Orden;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Orden { get => _Orden?? 0; set { if (RaiseAcceptPendingChange(value, _Orden)) { _Orden = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaisrretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaisrretenido { get => _Tasaisrretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaisrretenido)) { _Tasaisrretenido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Tasaivaretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Tasaivaretenido { get => _Tasaivaretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Tasaivaretenido)) { _Tasaivaretenido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_comision_Comisionxunidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_comision_Comisionxunidad { get => _Movto_comision_Comisionxunidad?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_comision_Comisionxunidad)) { _Movto_comision_Comisionxunidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_comision_Comision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_comision_Comision { get => _Movto_comision_Comision?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_comision_Comision)) { _Movto_comision_Comision = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_comision_Comisionporc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_comision_Comisionporc { get => _Movto_comision_Comisionporc?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_comision_Comisionporc)) { _Movto_comision_Comisionporc = value?? 0; OnPropertyChanged(); } } }

        private string? _Movto_comodin_Descripcion1;
        [XmlAttribute]
        public string? Movto_comodin_Descripcion1 { get => _Movto_comodin_Descripcion1; set { if (RaiseAcceptPendingChange(value, _Movto_comodin_Descripcion1)) { _Movto_comodin_Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Movto_comodin_Descripcion2;
        [XmlAttribute]
        public string? Movto_comodin_Descripcion2 { get => _Movto_comodin_Descripcion2; set { if (RaiseAcceptPendingChange(value, _Movto_comodin_Descripcion2)) { _Movto_comodin_Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Movto_comodin_Descripcion3;
        [XmlAttribute]
        public string? Movto_comodin_Descripcion3 { get => _Movto_comodin_Descripcion3; set { if (RaiseAcceptPendingChange(value, _Movto_comodin_Descripcion3)) { _Movto_comodin_Descripcion3 = value; OnPropertyChanged(); } } }

        private string? _Movto_comodin_Claveprod;
        [XmlAttribute]
        public string? Movto_comodin_Claveprod { get => _Movto_comodin_Claveprod; set { if (RaiseAcceptPendingChange(value, _Movto_comodin_Claveprod)) { _Movto_comodin_Claveprod = value; OnPropertyChanged(); } } }

        private long? _Movto_cancelacion_Movtorefid;
        [XmlAttribute]
        public long? Movto_cancelacion_Movtorefid { get => _Movto_cancelacion_Movtorefid; set { if (RaiseAcceptPendingChange(value, _Movto_cancelacion_Movtorefid)) { _Movto_cancelacion_Movtorefid = value; OnPropertyChanged(); } } }

        private string? _Movto_cancelacion_MovtorefClave;
        [XmlAttribute]
        public string? Movto_cancelacion_MovtorefClave { get => _Movto_cancelacion_MovtorefClave; set { if (RaiseAcceptPendingChange(value, _Movto_cancelacion_MovtorefClave)) { _Movto_cancelacion_MovtorefClave = value; OnPropertyChanged(); } } }

        private string? _Movto_cancelacion_MovtorefNombre;
        [XmlAttribute]
        public string? Movto_cancelacion_MovtorefNombre { get => _Movto_cancelacion_MovtorefNombre; set { if (RaiseAcceptPendingChange(value, _Movto_cancelacion_MovtorefNombre)) { _Movto_cancelacion_MovtorefNombre = value; OnPropertyChanged(); } } }

        private long? _Movto_devolucion_Movtorefid;
        [XmlAttribute]
        public long? Movto_devolucion_Movtorefid { get => _Movto_devolucion_Movtorefid; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Movtorefid)) { _Movto_devolucion_Movtorefid = value; OnPropertyChanged(); } } }

        private string? _Movto_devolucion_MovtorefClave;
        [XmlAttribute]
        public string? Movto_devolucion_MovtorefClave { get => _Movto_devolucion_MovtorefClave; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_MovtorefClave)) { _Movto_devolucion_MovtorefClave = value; OnPropertyChanged(); } } }

        private string? _Movto_devolucion_MovtorefNombre;
        [XmlAttribute]
        public string? Movto_devolucion_MovtorefNombre { get => _Movto_devolucion_MovtorefNombre; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_MovtorefNombre)) { _Movto_devolucion_MovtorefNombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_devolucion_Cantidadsurtida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_devolucion_Cantidadsurtida { get => _Movto_devolucion_Cantidadsurtida?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Cantidadsurtida)) { _Movto_devolucion_Cantidadsurtida = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_devolucion_Cantidadfaltante;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_devolucion_Cantidadfaltante { get => _Movto_devolucion_Cantidadfaltante?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Cantidadfaltante)) { _Movto_devolucion_Cantidadfaltante = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_devolucion_Cantidaddevuelta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_devolucion_Cantidaddevuelta { get => _Movto_devolucion_Cantidaddevuelta?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Cantidaddevuelta)) { _Movto_devolucion_Cantidaddevuelta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_devolucion_Cantidadsaldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_devolucion_Cantidadsaldo { get => _Movto_devolucion_Cantidadsaldo?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Cantidadsaldo)) { _Movto_devolucion_Cantidadsaldo = value?? 0; OnPropertyChanged(); } } }

        private long? _Movto_devolucion_Razondiferenciaid;
        [XmlAttribute]
        public long? Movto_devolucion_Razondiferenciaid { get => _Movto_devolucion_Razondiferenciaid; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Razondiferenciaid)) { _Movto_devolucion_Razondiferenciaid = value; OnPropertyChanged(); } } }

        private string? _Movto_devolucion_RazondiferenciaClave;
        [XmlAttribute]
        public string? Movto_devolucion_RazondiferenciaClave { get => _Movto_devolucion_RazondiferenciaClave; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_RazondiferenciaClave)) { _Movto_devolucion_RazondiferenciaClave = value; OnPropertyChanged(); } } }

        private string? _Movto_devolucion_RazondiferenciaNombre;
        [XmlAttribute]
        public string? Movto_devolucion_RazondiferenciaNombre { get => _Movto_devolucion_RazondiferenciaNombre; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_RazondiferenciaNombre)) { _Movto_devolucion_RazondiferenciaNombre = value; OnPropertyChanged(); } } }

        private string? _Movto_devolucion_Otrarazondiferencia;
        [XmlAttribute]
        public string? Movto_devolucion_Otrarazondiferencia { get => _Movto_devolucion_Otrarazondiferencia; set { if (RaiseAcceptPendingChange(value, _Movto_devolucion_Otrarazondiferencia)) { _Movto_devolucion_Otrarazondiferencia = value; OnPropertyChanged(); } } }

        private long? _Movto_loteimportado_Movtoloteimportadorefid;
        [XmlAttribute]
        public long? Movto_loteimportado_Movtoloteimportadorefid { get => _Movto_loteimportado_Movtoloteimportadorefid; set { if (RaiseAcceptPendingChange(value, _Movto_loteimportado_Movtoloteimportadorefid)) { _Movto_loteimportado_Movtoloteimportadorefid = value; OnPropertyChanged(); } } }

        private string? _Movto_loteimportado_MovtoloteimportadorefClave;
        [XmlAttribute]
        public string? Movto_loteimportado_MovtoloteimportadorefClave { get => _Movto_loteimportado_MovtoloteimportadorefClave; set { if (RaiseAcceptPendingChange(value, _Movto_loteimportado_MovtoloteimportadorefClave)) { _Movto_loteimportado_MovtoloteimportadorefClave = value; OnPropertyChanged(); } } }

        private string? _Movto_loteimportado_MovtoloteimportadorefNombre;
        [XmlAttribute]
        public string? Movto_loteimportado_MovtoloteimportadorefNombre { get => _Movto_loteimportado_MovtoloteimportadorefNombre; set { if (RaiseAcceptPendingChange(value, _Movto_loteimportado_MovtoloteimportadorefNombre)) { _Movto_loteimportado_MovtoloteimportadorefNombre = value; OnPropertyChanged(); } } }

        private string? _Movto_emida_Emidainvoiceno;
        [XmlAttribute]
        public string? Movto_emida_Emidainvoiceno { get => _Movto_emida_Emidainvoiceno; set { if (RaiseAcceptPendingChange(value, _Movto_emida_Emidainvoiceno)) { _Movto_emida_Emidainvoiceno = value; OnPropertyChanged(); } } }

        private long? _Movto_emida_Emidarequestid;
        [XmlAttribute]
        public long? Movto_emida_Emidarequestid { get => _Movto_emida_Emidarequestid; set { if (RaiseAcceptPendingChange(value, _Movto_emida_Emidarequestid)) { _Movto_emida_Emidarequestid = value; OnPropertyChanged(); } } }

        private string? _Movto_emida_EmidarequestClave;
        [XmlAttribute]
        public string? Movto_emida_EmidarequestClave { get => _Movto_emida_EmidarequestClave; set { if (RaiseAcceptPendingChange(value, _Movto_emida_EmidarequestClave)) { _Movto_emida_EmidarequestClave = value; OnPropertyChanged(); } } }

        private string? _Movto_emida_EmidarequestNombre;
        [XmlAttribute]
        public string? Movto_emida_EmidarequestNombre { get => _Movto_emida_EmidarequestNombre; set { if (RaiseAcceptPendingChange(value, _Movto_emida_EmidarequestNombre)) { _Movto_emida_EmidarequestNombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_emida_Emidacomision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_emida_Emidacomision { get => _Movto_emida_Emidacomision?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_emida_Emidacomision)) { _Movto_emida_Emidacomision = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_fact_elect_consolidacion_Consolidado_subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_fact_elect_consolidacion_Consolidado_subtotal { get => _Movto_fact_elect_consolidacion_Consolidado_subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_fact_elect_consolidacion_Consolidado_subtotal)) { _Movto_fact_elect_consolidacion_Consolidado_subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_fact_elect_consolidacion_Consolidado_iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_fact_elect_consolidacion_Consolidado_iva { get => _Movto_fact_elect_consolidacion_Consolidado_iva?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_fact_elect_consolidacion_Consolidado_iva)) { _Movto_fact_elect_consolidacion_Consolidado_iva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_fact_elect_consolidacion_Consolidado_ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_fact_elect_consolidacion_Consolidado_ieps { get => _Movto_fact_elect_consolidacion_Consolidado_ieps?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_fact_elect_consolidacion_Consolidado_ieps)) { _Movto_fact_elect_consolidacion_Consolidado_ieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_fact_elect_consolidacion_Consolidado_total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_fact_elect_consolidacion_Consolidado_total { get => _Movto_fact_elect_consolidacion_Consolidado_total?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_fact_elect_consolidacion_Consolidado_total)) { _Movto_fact_elect_consolidacion_Consolidado_total = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_fact_elect_consolidacion_Consolidado_iva_ret;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_fact_elect_consolidacion_Consolidado_iva_ret { get => _Movto_fact_elect_consolidacion_Consolidado_iva_ret?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_fact_elect_consolidacion_Consolidado_iva_ret)) { _Movto_fact_elect_consolidacion_Consolidado_iva_ret = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_fact_elect_consolidacion_Consolidado_isr_ret;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_fact_elect_consolidacion_Consolidado_isr_ret { get => _Movto_fact_elect_consolidacion_Consolidado_isr_ret?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_fact_elect_consolidacion_Consolidado_isr_ret)) { _Movto_fact_elect_consolidacion_Consolidado_isr_ret = value?? 0; OnPropertyChanged(); } } }

        private string? _Movto_inventario_Localidad;
        [XmlAttribute]
        public string? Movto_inventario_Localidad { get => _Movto_inventario_Localidad; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Localidad)) { _Movto_inventario_Localidad = value; OnPropertyChanged(); } } }

        private BoolCN? _Movto_inventario_Registroprocesosalida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movto_inventario_Registroprocesosalida { get => _Movto_inventario_Registroprocesosalida?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Registroprocesosalida)) { _Movto_inventario_Registroprocesosalida = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Movto_inventario_Tipodiferenciainventarioid;
        [XmlAttribute]
        public long? Movto_inventario_Tipodiferenciainventarioid { get => _Movto_inventario_Tipodiferenciainventarioid; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Tipodiferenciainventarioid)) { _Movto_inventario_Tipodiferenciainventarioid = value; OnPropertyChanged(); } } }

        private string? _Movto_inventario_TipodiferenciainventarioClave;
        [XmlAttribute]
        public string? Movto_inventario_TipodiferenciainventarioClave { get => _Movto_inventario_TipodiferenciainventarioClave; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_TipodiferenciainventarioClave)) { _Movto_inventario_TipodiferenciainventarioClave = value; OnPropertyChanged(); } } }

        private string? _Movto_inventario_TipodiferenciainventarioNombre;
        [XmlAttribute]
        public string? Movto_inventario_TipodiferenciainventarioNombre { get => _Movto_inventario_TipodiferenciainventarioNombre; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_TipodiferenciainventarioNombre)) { _Movto_inventario_TipodiferenciainventarioNombre = value; OnPropertyChanged(); } } }

        private long? _Movto_inventario_Anaquelid;
        [XmlAttribute]
        public long? Movto_inventario_Anaquelid { get => _Movto_inventario_Anaquelid; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Anaquelid)) { _Movto_inventario_Anaquelid = value; OnPropertyChanged(); } } }

        private string? _Movto_inventario_AnaquelClave;
        [XmlAttribute]
        public string? Movto_inventario_AnaquelClave { get => _Movto_inventario_AnaquelClave; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_AnaquelClave)) { _Movto_inventario_AnaquelClave = value; OnPropertyChanged(); } } }

        private string? _Movto_inventario_AnaquelNombre;
        [XmlAttribute]
        public string? Movto_inventario_AnaquelNombre { get => _Movto_inventario_AnaquelNombre; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_AnaquelNombre)) { _Movto_inventario_AnaquelNombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_inventario_Cantidad_real;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_inventario_Cantidad_real { get => _Movto_inventario_Cantidad_real?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Cantidad_real)) { _Movto_inventario_Cantidad_real = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_inventario_Cantidad_teorica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_inventario_Cantidad_teorica { get => _Movto_inventario_Cantidad_teorica?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Cantidad_teorica)) { _Movto_inventario_Cantidad_teorica = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_inventario_Cantidad_diferencia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_inventario_Cantidad_diferencia { get => _Movto_inventario_Cantidad_diferencia?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_inventario_Cantidad_diferencia)) { _Movto_inventario_Cantidad_diferencia = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Movto_kit_Eskit;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movto_kit_Eskit { get => _Movto_kit_Eskit?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movto_kit_Eskit)) { _Movto_kit_Eskit = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Movto_kit_Kitimpfijo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movto_kit_Kitimpfijo { get => _Movto_kit_Kitimpfijo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movto_kit_Kitimpfijo)) { _Movto_kit_Kitimpfijo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_Enprocesopartes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_Enprocesopartes { get => _Movto_kit_Enprocesopartes?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_Enprocesopartes)) { _Movto_kit_Enprocesopartes = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_Tasaiepsparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_Tasaiepsparte { get => _Movto_kit_Tasaiepsparte?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_Tasaiepsparte)) { _Movto_kit_Tasaiepsparte = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_Tasasubtotalparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_Tasasubtotalparte { get => _Movto_kit_Tasasubtotalparte?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_Tasasubtotalparte)) { _Movto_kit_Tasasubtotalparte = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_Tasaivaparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_Tasaivaparte { get => _Movto_kit_Tasaivaparte?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_Tasaivaparte)) { _Movto_kit_Tasaivaparte = value?? 0; OnPropertyChanged(); } } }

        private long? _Movto_kit_def_Productokitid;
        [XmlAttribute]
        public long? Movto_kit_def_Productokitid { get => _Movto_kit_def_Productokitid; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Productokitid)) { _Movto_kit_def_Productokitid = value; OnPropertyChanged(); } } }

        private string? _Movto_kit_def_ProductokitClave;
        [XmlAttribute]
        public string? Movto_kit_def_ProductokitClave { get => _Movto_kit_def_ProductokitClave; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_ProductokitClave)) { _Movto_kit_def_ProductokitClave = value; OnPropertyChanged(); } } }

        private string? _Movto_kit_def_ProductokitNombre;
        [XmlAttribute]
        public string? Movto_kit_def_ProductokitNombre { get => _Movto_kit_def_ProductokitNombre; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_ProductokitNombre)) { _Movto_kit_def_ProductokitNombre = value; OnPropertyChanged(); } } }

        private long? _Movto_kit_def_Productoparteid;
        [XmlAttribute]
        public long? Movto_kit_def_Productoparteid { get => _Movto_kit_def_Productoparteid; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Productoparteid)) { _Movto_kit_def_Productoparteid = value; OnPropertyChanged(); } } }

        private string? _Movto_kit_def_ProductoparteClave;
        [XmlAttribute]
        public string? Movto_kit_def_ProductoparteClave { get => _Movto_kit_def_ProductoparteClave; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_ProductoparteClave)) { _Movto_kit_def_ProductoparteClave = value; OnPropertyChanged(); } } }

        private string? _Movto_kit_def_ProductoparteNombre;
        [XmlAttribute]
        public string? Movto_kit_def_ProductoparteNombre { get => _Movto_kit_def_ProductoparteNombre; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_ProductoparteNombre)) { _Movto_kit_def_ProductoparteNombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Cantidadparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Cantidadparte { get => _Movto_kit_def_Cantidadparte?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Cantidadparte)) { _Movto_kit_def_Cantidadparte = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Costoparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Costoparte { get => _Movto_kit_def_Costoparte?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Costoparte)) { _Movto_kit_def_Costoparte = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Cantidadpartetotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Cantidadpartetotal { get => _Movto_kit_def_Cantidadpartetotal?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Cantidadpartetotal)) { _Movto_kit_def_Cantidadpartetotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Precioporunidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Precioporunidad { get => _Movto_kit_def_Precioporunidad?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Precioporunidad)) { _Movto_kit_def_Precioporunidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Tasaiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Tasaiva { get => _Movto_kit_def_Tasaiva?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Tasaiva)) { _Movto_kit_def_Tasaiva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Tasaieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Tasaieps { get => _Movto_kit_def_Tasaieps?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Tasaieps)) { _Movto_kit_def_Tasaieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Montosubtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Montosubtotal { get => _Movto_kit_def_Montosubtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Montosubtotal)) { _Movto_kit_def_Montosubtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Montoiva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Montoiva { get => _Movto_kit_def_Montoiva?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Montoiva)) { _Movto_kit_def_Montoiva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Montoieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Montoieps { get => _Movto_kit_def_Montoieps?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Montoieps)) { _Movto_kit_def_Montoieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_kit_def_Montototal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_kit_def_Montototal { get => _Movto_kit_def_Montototal?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_kit_def_Montototal)) { _Movto_kit_def_Montototal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_monedero_Monederoabono;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_monedero_Monederoabono { get => _Movto_monedero_Monederoabono?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_monedero_Monederoabono)) { _Movto_monedero_Monederoabono = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_ordencompra_Cantidadsurtida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_ordencompra_Cantidadsurtida { get => _Movto_ordencompra_Cantidadsurtida?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_Cantidadsurtida)) { _Movto_ordencompra_Cantidadsurtida = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_ordencompra_Cantidadfaltante;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_ordencompra_Cantidadfaltante { get => _Movto_ordencompra_Cantidadfaltante?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_Cantidadfaltante)) { _Movto_ordencompra_Cantidadfaltante = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_ordencompra_Cantidaddevuelta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_ordencompra_Cantidaddevuelta { get => _Movto_ordencompra_Cantidaddevuelta?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_Cantidaddevuelta)) { _Movto_ordencompra_Cantidaddevuelta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_ordencompra_Cantidadsaldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_ordencompra_Cantidadsaldo { get => _Movto_ordencompra_Cantidadsaldo?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_Cantidadsaldo)) { _Movto_ordencompra_Cantidadsaldo = value?? 0; OnPropertyChanged(); } } }

        private long? _Movto_ordencompra_Movtorefid;
        [XmlAttribute]
        public long? Movto_ordencompra_Movtorefid { get => _Movto_ordencompra_Movtorefid; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_Movtorefid)) { _Movto_ordencompra_Movtorefid = value; OnPropertyChanged(); } } }

        private string? _Movto_ordencompra_MovtorefClave;
        [XmlAttribute]
        public string? Movto_ordencompra_MovtorefClave { get => _Movto_ordencompra_MovtorefClave; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_MovtorefClave)) { _Movto_ordencompra_MovtorefClave = value; OnPropertyChanged(); } } }

        private string? _Movto_ordencompra_MovtorefNombre;
        [XmlAttribute]
        public string? Movto_ordencompra_MovtorefNombre { get => _Movto_ordencompra_MovtorefNombre; set { if (RaiseAcceptPendingChange(value, _Movto_ordencompra_MovtorefNombre)) { _Movto_ordencompra_MovtorefNombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_origenfiscal_Cantidaddefactura;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_origenfiscal_Cantidaddefactura { get => _Movto_origenfiscal_Cantidaddefactura?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_origenfiscal_Cantidaddefactura)) { _Movto_origenfiscal_Cantidaddefactura = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_origenfiscal_Cantidadderemision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_origenfiscal_Cantidadderemision { get => _Movto_origenfiscal_Cantidadderemision?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_origenfiscal_Cantidadderemision)) { _Movto_origenfiscal_Cantidadderemision = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_origenfiscal_Cantidaddeindefinido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_origenfiscal_Cantidaddeindefinido { get => _Movto_origenfiscal_Cantidaddeindefinido?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_origenfiscal_Cantidaddeindefinido)) { _Movto_origenfiscal_Cantidaddeindefinido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_origenfiscal_Cantdevueltadefactura;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_origenfiscal_Cantdevueltadefactura { get => _Movto_origenfiscal_Cantdevueltadefactura?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_origenfiscal_Cantdevueltadefactura)) { _Movto_origenfiscal_Cantdevueltadefactura = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_origenfiscal_Cantdevueltaderemision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_origenfiscal_Cantdevueltaderemision { get => _Movto_origenfiscal_Cantdevueltaderemision?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_origenfiscal_Cantdevueltaderemision)) { _Movto_origenfiscal_Cantdevueltaderemision = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_origenfiscal_Cantdevueltadeindefinido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_origenfiscal_Cantdevueltadeindefinido { get => _Movto_origenfiscal_Cantdevueltadeindefinido?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_origenfiscal_Cantdevueltadeindefinido)) { _Movto_origenfiscal_Cantdevueltadeindefinido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_poliza_Nutil;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_poliza_Nutil { get => _Movto_poliza_Nutil?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_poliza_Nutil)) { _Movto_poliza_Nutil = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_poliza_Nprec;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_poliza_Nprec { get => _Movto_poliza_Nprec?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_poliza_Nprec)) { _Movto_poliza_Nprec = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_poliza_Cdescr;
        [XmlAttribute]
        public decimal? Movto_poliza_Cdescr { get => _Movto_poliza_Cdescr; set { if (RaiseAcceptPendingChange(value, _Movto_poliza_Cdescr)) { _Movto_poliza_Cdescr = value; OnPropertyChanged(); } } }

        private string? _Movto_precio_Razondescuentocajero;
        [XmlAttribute]
        public string? Movto_precio_Razondescuentocajero { get => _Movto_precio_Razondescuentocajero; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Razondescuentocajero)) { _Movto_precio_Razondescuentocajero = value; OnPropertyChanged(); } } }

        private BoolCN? _Movto_precio_Preciomanualmasbajo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movto_precio_Preciomanualmasbajo { get => _Movto_precio_Preciomanualmasbajo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Preciomanualmasbajo)) { _Movto_precio_Preciomanualmasbajo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Movto_precio_Ingresopreciomanual;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movto_precio_Ingresopreciomanual { get => _Movto_precio_Ingresopreciomanual?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Ingresopreciomanual)) { _Movto_precio_Ingresopreciomanual = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Movto_precio_Calc_imp_de_total;
        [XmlAttribute]
        public BoolCN? Movto_precio_Calc_imp_de_total { get => _Movto_precio_Calc_imp_de_total; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Calc_imp_de_total)) { _Movto_precio_Calc_imp_de_total = value; OnPropertyChanged(); } } }

        private decimal? _Movto_precio_Descuentovale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_precio_Descuentovale { get => _Movto_precio_Descuentovale?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Descuentovale)) { _Movto_precio_Descuentovale = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_precio_Descuentovaleporcentaje;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_precio_Descuentovaleporcentaje { get => _Movto_precio_Descuentovaleporcentaje?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Descuentovaleporcentaje)) { _Movto_precio_Descuentovaleporcentaje = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_precio_Porcentajedescuentomanual;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_precio_Porcentajedescuentomanual { get => _Movto_precio_Porcentajedescuentomanual?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Porcentajedescuentomanual)) { _Movto_precio_Porcentajedescuentomanual = value?? 0; OnPropertyChanged(); } } }

        private long? _Movto_precio_Listaprecioid;
        [XmlAttribute]
        public long? Movto_precio_Listaprecioid { get => _Movto_precio_Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Listaprecioid)) { _Movto_precio_Listaprecioid = value; OnPropertyChanged(); } } }

        private string? _Movto_precio_ListaprecioClave;
        [XmlAttribute]
        public string? Movto_precio_ListaprecioClave { get => _Movto_precio_ListaprecioClave; set { if (RaiseAcceptPendingChange(value, _Movto_precio_ListaprecioClave)) { _Movto_precio_ListaprecioClave = value; OnPropertyChanged(); } } }

        private string? _Movto_precio_ListaprecioNombre;
        [XmlAttribute]
        public string? Movto_precio_ListaprecioNombre { get => _Movto_precio_ListaprecioNombre; set { if (RaiseAcceptPendingChange(value, _Movto_precio_ListaprecioNombre)) { _Movto_precio_ListaprecioNombre = value; OnPropertyChanged(); } } }

        private int? _Movto_precio_Precioclasificacion;
        [XmlAttribute]
        public int? Movto_precio_Precioclasificacion { get => _Movto_precio_Precioclasificacion; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Precioclasificacion)) { _Movto_precio_Precioclasificacion = value; OnPropertyChanged(); } } }

        private decimal? _Movto_precio_Precioconimp;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_precio_Precioconimp { get => _Movto_precio_Precioconimp?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_precio_Precioconimp)) { _Movto_precio_Precioconimp = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Movto_promocion_Promocion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movto_promocion_Promocion { get => _Movto_promocion_Promocion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Promocion)) { _Movto_promocion_Promocion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Movto_promocion_Promociondesglose;
        [XmlAttribute]
        public string? Movto_promocion_Promociondesglose { get => _Movto_promocion_Promociondesglose; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Promociondesglose)) { _Movto_promocion_Promociondesglose = value; OnPropertyChanged(); } } }



        private long? _Movto_promocion_Tipomayoreolineaid;
        [XmlAttribute]
        public long? Movto_promocion_Tipomayoreolineaid { get => _Movto_promocion_Tipomayoreolineaid; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Tipomayoreolineaid)) { _Movto_promocion_Tipomayoreolineaid = value; OnPropertyChanged(); } } }


        private BoolCN? _Movto_promocion_Aplicopromoxmontomin;
        [XmlAttribute]
        public BoolCN? Movto_promocion_Aplicopromoxmontomin { get => _Movto_promocion_Aplicopromoxmontomin; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Aplicopromoxmontomin)) { _Movto_promocion_Aplicopromoxmontomin = value; OnPropertyChanged(); } } }

        private long? _Movto_promocion_Promocionid;
        [XmlAttribute]
        public long? Movto_promocion_Promocionid { get => _Movto_promocion_Promocionid; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Promocionid)) { _Movto_promocion_Promocionid = value; OnPropertyChanged(); } } }

        private string? _Movto_promocion_Promocion_Clave;
        [XmlAttribute]
        public string? Movto_promocion_Promocion_Clave { get => _Movto_promocion_Promocion_Clave; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Promocion_Clave)) { _Movto_promocion_Promocion_Clave = value; OnPropertyChanged(); } } }

        private string? _Movto_promocion_Promocion_Nombre;
        [XmlAttribute]
        public string? Movto_promocion_Promocion_Nombre { get => _Movto_promocion_Promocion_Nombre; set { if (RaiseAcceptPendingChange(value, _Movto_promocion_Promocion_Nombre)) { _Movto_promocion_Promocion_Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_rebajaespecial_Precioconrebaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_rebajaespecial_Precioconrebaja { get => _Movto_rebajaespecial_Precioconrebaja?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Precioconrebaja)) { _Movto_rebajaespecial_Precioconrebaja = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_rebajaespecial_Totalconrebaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_rebajaespecial_Totalconrebaja { get => _Movto_rebajaespecial_Totalconrebaja?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Totalconrebaja)) { _Movto_rebajaespecial_Totalconrebaja = value?? 0; OnPropertyChanged(); } } }

        private long? _Movto_rebajaespecial_Estadorebaja;
        [XmlAttribute]
        public long? Movto_rebajaespecial_Estadorebaja { get => _Movto_rebajaespecial_Estadorebaja; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Estadorebaja)) { _Movto_rebajaespecial_Estadorebaja = value; OnPropertyChanged(); } } }

        private string? _Movto_rebajaespecial_Estadorebaja_Clave;
        [XmlAttribute]
        public string? Movto_rebajaespecial_Estadorebaja_Clave { get => _Movto_rebajaespecial_Estadorebaja_Clave; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Estadorebaja_Clave)) { _Movto_rebajaespecial_Estadorebaja_Clave = value; OnPropertyChanged(); } } }

        private string? _Movto_rebajaespecial_Estadorebaja_Nombre;
        [XmlAttribute]
        public string? Movto_rebajaespecial_Estadorebaja_Nombre { get => _Movto_rebajaespecial_Estadorebaja_Nombre; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Estadorebaja_Nombre)) { _Movto_rebajaespecial_Estadorebaja_Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Movto_rebajaespecial_Cantautrebaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_rebajaespecial_Cantautrebaja { get => _Movto_rebajaespecial_Cantautrebaja?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Cantautrebaja)) { _Movto_rebajaespecial_Cantautrebaja = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_rebajaespecial_Montorebaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_rebajaespecial_Montorebaja { get => _Movto_rebajaespecial_Montorebaja?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_rebajaespecial_Montorebaja)) { _Movto_rebajaespecial_Montorebaja = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Movto_revision_Cantidadrevisada;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_revision_Cantidadrevisada { get => _Movto_revision_Cantidadrevisada?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_revision_Cantidadrevisada)) { _Movto_revision_Cantidadrevisada = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Movto_surtido_Surtible;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Movto_surtido_Surtible { get => _Movto_surtido_Surtible?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Movto_surtido_Surtible)) { _Movto_surtido_Surtible = value?? BoolCS.S; OnPropertyChanged(); } } }

        private decimal? _Movto_surtido_Maxsurtible;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_surtido_Maxsurtible { get => _Movto_surtido_Maxsurtible?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_surtido_Maxsurtible)) { _Movto_surtido_Maxsurtible = value?? 0; OnPropertyChanged(); } } }

        private string? _Movto_traslado_Otromotivodevolucion;
        [XmlAttribute]
        public string? Movto_traslado_Otromotivodevolucion { get => _Movto_traslado_Otromotivodevolucion; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_Otromotivodevolucion)) { _Movto_traslado_Otromotivodevolucion = value; OnPropertyChanged(); } } }

        private decimal? _Movto_traslado_Preciovisibletraslado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Movto_traslado_Preciovisibletraslado { get => _Movto_traslado_Preciovisibletraslado?? 0; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_Preciovisibletraslado)) { _Movto_traslado_Preciovisibletraslado = value?? 0; OnPropertyChanged(); } } }

        private long? _Movto_traslado_Movtoimportadoid;
        [XmlAttribute]
        public long? Movto_traslado_Movtoimportadoid { get => _Movto_traslado_Movtoimportadoid; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_Movtoimportadoid)) { _Movto_traslado_Movtoimportadoid = value; OnPropertyChanged(); } } }

        private string? _Movto_traslado_MovtoimportadoClave;
        [XmlAttribute]
        public string? Movto_traslado_MovtoimportadoClave { get => _Movto_traslado_MovtoimportadoClave; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_MovtoimportadoClave)) { _Movto_traslado_MovtoimportadoClave = value; OnPropertyChanged(); } } }

        private string? _Movto_traslado_MovtoimportadoNombre;
        [XmlAttribute]
        public string? Movto_traslado_MovtoimportadoNombre { get => _Movto_traslado_MovtoimportadoNombre; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_MovtoimportadoNombre)) { _Movto_traslado_MovtoimportadoNombre = value; OnPropertyChanged(); } } }

        private long? _Movto_traslado_Motivodevolucionid;
        [XmlAttribute]
        public long? Movto_traslado_Motivodevolucionid { get => _Movto_traslado_Motivodevolucionid; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_Motivodevolucionid)) { _Movto_traslado_Motivodevolucionid = value; OnPropertyChanged(); } } }

        private string? _Movto_traslado_MotivodevolucionClave;
        [XmlAttribute]
        public string? Movto_traslado_MotivodevolucionClave { get => _Movto_traslado_MotivodevolucionClave; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_MotivodevolucionClave)) { _Movto_traslado_MotivodevolucionClave = value; OnPropertyChanged(); } } }

        private string? _Movto_traslado_MotivodevolucionNombre;
        [XmlAttribute]
        public string? Movto_traslado_MotivodevolucionNombre { get => _Movto_traslado_MotivodevolucionNombre; set { if (RaiseAcceptPendingChange(value, _Movto_traslado_MotivodevolucionNombre)) { _Movto_traslado_MotivodevolucionNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Movto"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Lote|Estatusmovto.Clave|Estatusmovto.Nombre|Producto.Clave|Producto.Nombre|Loteimportado_.Clave|Loteimportado_.Nombre|Movtoparent.Clave|Movtoparent.Nombre|Docto.Clave|Docto.Nombre|Movto_comodin.Descripcion1|Movto_comodin.Descripcion2|Movto_comodin.Descripcion3|Movto_comodin.Claveprod|Movto_cancelacion.Movtoref.Clave|Movto_cancelacion.Movtoref.Nombre|Movto_devolucion.Movtoref.Clave|Movto_devolucion.Movtoref.Nombre|Movto_devolucion.Razondiferencia.Clave|Movto_devolucion.Razondiferencia.Nombre|Movto_devolucion.Otrarazondiferencia|Movto_loteimportado.Movtoloteimportadoref.Clave|Movto_loteimportado.Movtoloteimportadoref.Nombre|Movto_emida.Emidainvoiceno|Movto_emida.Emidarequest.Clave|Movto_emida.Emidarequest.Nombre|Movto_inventario.Localidad|Movto_inventario.Tipodiferenciainventario.Clave|Movto_inventario.Tipodiferenciainventario.Nombre|Movto_inventario.Anaquel.Clave|Movto_inventario.Anaquel.Nombre|Movto_kit_def.Productokit.Clave|Movto_kit_def.Productokit.Nombre|Movto_kit_def.Productoparte.Clave|Movto_kit_def.Productoparte.Nombre|Movto_ordencompra.Movtoref.Clave|Movto_ordencompra.Movtoref.Nombre|Movto_precio.Razondescuentocajero|Movto_precio.Listaprecio.Clave|Movto_precio.Listaprecio.Nombre|Movto_promocion.Promociondesglose|Movto_promocion.Promocion_.Clave|Movto_promocion.Promocion_.Nombre|Movto_rebajaespecial.Estadorebaja_.Clave|Movto_rebajaespecial.Estadorebaja_.Nombre|Movto_traslado.Otromotivodevolucion|Movto_traslado.Movtoimportado.Clave|Movto_traslado.Movtoimportado.Nombre|Movto_traslado.Motivodevolucion.Clave|Movto_traslado_MotivodevolucionNombre";
        }


        #if PROYECTO_WEB

        public void FillCatalogRelatedFields(Movto item)
        {

             this._EstatusmovtoClave = item.Estatusmovto?.Clave;

             this._EstatusmovtoNombre = item.Estatusmovto?.Nombre;

             this._ProductoClave = item.Producto?.Clave;

             this._ProductoNombre = item.Producto?.Nombre;

             this._Loteimportado_Clave = item.Loteimportado_?.Clave;

             this._Loteimportado_Nombre = item.Loteimportado_?.Nombre;

             this._MovtoparentClave = item.Movtoparent?.Clave;

             this._MovtoparentNombre = item.Movtoparent?.Nombre;

             this._DoctoClave = item.Docto?.Clave;

             this._DoctoNombre = item.Docto?.Nombre;

             this._Movto_cancelacion_MovtorefClave = item.Movto_cancelacion?.Movtoref?.Clave;

             this._Movto_cancelacion_MovtorefNombre = item.Movto_cancelacion?.Movtoref?.Nombre;

             this._Movto_devolucion_MovtorefClave = item.Movto_devolucion?.Movtoref?.Clave;

             this._Movto_devolucion_MovtorefNombre = item.Movto_devolucion?.Movtoref?.Nombre;

             this._Movto_devolucion_RazondiferenciaClave = item.Movto_devolucion?.Razondiferencia?.Clave;

             this._Movto_devolucion_RazondiferenciaNombre = item.Movto_devolucion?.Razondiferencia?.Nombre;

             this._Movto_loteimportado_MovtoloteimportadorefClave = item.Movto_loteimportado?.Movtoloteimportadoref?.Clave;

             this._Movto_loteimportado_MovtoloteimportadorefNombre = item.Movto_loteimportado?.Movtoloteimportadoref?.Nombre;

             this._Movto_emida_EmidarequestClave = item.Movto_emida?.Emidarequest?.Clave;

             this._Movto_emida_EmidarequestNombre = item.Movto_emida?.Emidarequest?.Nombre;

             this._Movto_inventario_TipodiferenciainventarioClave = item.Movto_inventario?.Tipodiferenciainventario?.Clave;

             this._Movto_inventario_TipodiferenciainventarioNombre = item.Movto_inventario?.Tipodiferenciainventario?.Nombre;

             this._Movto_inventario_AnaquelClave = item.Movto_inventario?.Anaquel?.Clave;

             this._Movto_inventario_AnaquelNombre = item.Movto_inventario?.Anaquel?.Nombre;

             //this._Movto_kit_def_ProductokitClave = item.Movto_kit_def?.Productokit?.Clave;

             //this._Movto_kit_def_ProductokitNombre = item.Movto_kit_def?.Productokit?.Nombre;

             //this._Movto_kit_def_ProductoparteClave = item.Movto_kit_def?.Productoparte?.Clave;

             //this._Movto_kit_def_ProductoparteNombre = item.Movto_kit_def?.Productoparte?.Nombre;

             this._Movto_ordencompra_MovtorefClave = item.Movto_ordencompra?.Movtoref?.Clave;

             this._Movto_ordencompra_MovtorefNombre = item.Movto_ordencompra?.Movtoref?.Nombre;

             this._Movto_precio_ListaprecioClave = item.Movto_precio?.Listaprecio?.Clave;

             this._Movto_precio_ListaprecioNombre = item.Movto_precio?.Listaprecio?.Nombre;

             this._Movto_promocion_Promocion_Clave = item.Movto_promocion?.Promocion_?.Clave;

             this._Movto_promocion_Promocion_Nombre = item.Movto_promocion?.Promocion_?.Nombre;

             this._Movto_rebajaespecial_Estadorebaja_Clave = item.Movto_rebajaespecial?.Estadorebaja_?.Clave;

             this._Movto_rebajaespecial_Estadorebaja_Nombre = item.Movto_rebajaespecial?.Estadorebaja_?.Nombre;

             this._Movto_traslado_MovtoimportadoClave = item.Movto_traslado?.Movtoimportado?.Clave;

             this._Movto_traslado_MovtoimportadoNombre = item.Movto_traslado?.Movtoimportado?.Nombre;

             this._Movto_traslado_MotivodevolucionClave = item.Movto_traslado?.Motivodevolucion?.Clave;


        }


        public void FillEntityValues(ref Movto item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Lote = Lote ;


            item.Afectainventario = Afectainventario ?? BoolCS.S;


            item.Afectatotales = Afectatotales ?? BoolCS.S;


            item.Eskit = Eskit ?? BoolCN.N;


            item.Kitimpfijo = Kitimpfijo ?? BoolCN.N;


            item.Partida = Partida ?? 0;


            item.Estatusmovtoid = Estatusmovtoid ;


            item.Fecha = Fecha ;


            item.Fechahora = Fechahora ;


            item.Productoid = Productoid ;


            item.Cantidad = Cantidad ?? 0;


            item.Preciolista = Preciolista ?? 0;


            item.Descuentoporcentaje = Descuentoporcentaje ?? 0;


            item.Descuento = Descuento ?? 0;


            item.Precio = Precio ?? 0;


            item.Importe = Importe ?? 0;


            item.Subtotal = Subtotal ?? 0;


            item.Iva = Iva ?? 0;


            item.Ieps = Ieps ?? 0;


            item.Tasaiva = Tasaiva ?? 0;


            item.Tasaieps = Tasaieps ?? 0;


            item.Total = Total ?? 0;


            item.Fechavence = Fechavence ;


            item.Loteimportado = Loteimportado ;


            item.Movtoparentid = Movtoparentid ;


            item.Movtonivel = Movtonivel ?? 0;


            item.Doctoid = Doctoid ;


            item.Cargo = Cargo ?? 0;


            item.Abono = Abono ?? 0;


            item.Saldo = Saldo ?? 0;


            item.Preciomanual = Preciomanual ?? 0;


            item.Preciomaximopublico = Preciomaximopublico ?? 0;


            item.Isrretenido = Isrretenido ?? 0;


            item.Ivaretenido = Ivaretenido ?? 0;


            item.Orden = Orden ?? 0;


            item.Tasaisrretenido = Tasaisrretenido ?? 0;


            item.Tasaivaretenido = Tasaivaretenido ?? 0;




            if (item.Movto_comision != null)
                item.Movto_comision!.Comisionxunidad = Movto_comision_Comisionxunidad?? 0;
            else if (item.Movto_comision == null && Movto_comision_Comisionxunidad != null)
            {
                item.Movto_comision = CreateSubEntity<Movto_comision>();
                item.Movto_comision!.Comisionxunidad = Movto_comision_Comisionxunidad?? 0;
            }

            if (item.Movto_comision != null)
                item.Movto_comision!.Comision = Movto_comision_Comision?? 0;
            else if (item.Movto_comision == null && Movto_comision_Comision != null)
            {
                item.Movto_comision = CreateSubEntity<Movto_comision>();
                item.Movto_comision!.Comision = Movto_comision_Comision?? 0;
            }

            if (item.Movto_comision != null)
                item.Movto_comision!.Comisionporc = Movto_comision_Comisionporc?? 0;
            else if (item.Movto_comision == null && Movto_comision_Comisionporc != null)
            {
                item.Movto_comision = CreateSubEntity<Movto_comision>();
                item.Movto_comision!.Comisionporc = Movto_comision_Comisionporc?? 0;
            }

            if (item.Movto_comodin != null)
                item.Movto_comodin!.Descripcion1 = Movto_comodin_Descripcion1;
            else if (item.Movto_comodin == null && Movto_comodin_Descripcion1 != null)
            {
                item.Movto_comodin = CreateSubEntity<Movto_comodin>();
                item.Movto_comodin!.Descripcion1 = Movto_comodin_Descripcion1;
            }

            if (item.Movto_comodin != null)
                item.Movto_comodin!.Descripcion2 = Movto_comodin_Descripcion2;
            else if (item.Movto_comodin == null && Movto_comodin_Descripcion2 != null)
            {
                item.Movto_comodin = CreateSubEntity<Movto_comodin>();
                item.Movto_comodin!.Descripcion2 = Movto_comodin_Descripcion2;
            }

            if (item.Movto_comodin != null)
                item.Movto_comodin!.Descripcion3 = Movto_comodin_Descripcion3;
            else if (item.Movto_comodin == null && Movto_comodin_Descripcion3 != null)
            {
                item.Movto_comodin = CreateSubEntity<Movto_comodin>();
                item.Movto_comodin!.Descripcion3 = Movto_comodin_Descripcion3;
            }

            if (item.Movto_comodin != null)
                item.Movto_comodin!.Claveprod = Movto_comodin_Claveprod;
            else if (item.Movto_comodin == null && Movto_comodin_Claveprod != null)
            {
                item.Movto_comodin = CreateSubEntity<Movto_comodin>();
                item.Movto_comodin!.Claveprod = Movto_comodin_Claveprod;
            }

            if (item.Movto_cancelacion != null)
                item.Movto_cancelacion!.Movtorefid = Movto_cancelacion_Movtorefid;
            else if (item.Movto_cancelacion == null && Movto_cancelacion_Movtorefid != null)
            {
                item.Movto_cancelacion = CreateSubEntity<Movto_cancelacion>();
                item.Movto_cancelacion!.Movtorefid = Movto_cancelacion_Movtorefid;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Movtorefid = Movto_devolucion_Movtorefid;
            else if (item.Movto_devolucion == null && Movto_devolucion_Movtorefid != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Movtorefid = Movto_devolucion_Movtorefid;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Cantidadsurtida = Movto_devolucion_Cantidadsurtida?? 0;
            else if (item.Movto_devolucion == null && Movto_devolucion_Cantidadsurtida != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Cantidadsurtida = Movto_devolucion_Cantidadsurtida?? 0;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Cantidadfaltante = Movto_devolucion_Cantidadfaltante?? 0;
            else if (item.Movto_devolucion == null && Movto_devolucion_Cantidadfaltante != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Cantidadfaltante = Movto_devolucion_Cantidadfaltante?? 0;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Cantidaddevuelta = Movto_devolucion_Cantidaddevuelta?? 0;
            else if (item.Movto_devolucion == null && Movto_devolucion_Cantidaddevuelta != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Cantidaddevuelta = Movto_devolucion_Cantidaddevuelta?? 0;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Cantidadsaldo = Movto_devolucion_Cantidadsaldo?? 0;
            else if (item.Movto_devolucion == null && Movto_devolucion_Cantidadsaldo != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Cantidadsaldo = Movto_devolucion_Cantidadsaldo?? 0;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Razondiferenciaid = Movto_devolucion_Razondiferenciaid;
            else if (item.Movto_devolucion == null && Movto_devolucion_Razondiferenciaid != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Razondiferenciaid = Movto_devolucion_Razondiferenciaid;
            }

            if (item.Movto_devolucion != null)
                item.Movto_devolucion!.Otrarazondiferencia = Movto_devolucion_Otrarazondiferencia;
            else if (item.Movto_devolucion == null && Movto_devolucion_Otrarazondiferencia != null)
            {
                item.Movto_devolucion = CreateSubEntity<Movto_devolucion>();
                item.Movto_devolucion!.Otrarazondiferencia = Movto_devolucion_Otrarazondiferencia;
            }

            if (item.Movto_loteimportado != null)
                item.Movto_loteimportado!.Movtoloteimportadorefid = Movto_loteimportado_Movtoloteimportadorefid;
            else if (item.Movto_loteimportado == null && Movto_loteimportado_Movtoloteimportadorefid != null)
            {
                item.Movto_loteimportado = CreateSubEntity<Movto_loteimportado>();
                item.Movto_loteimportado!.Movtoloteimportadorefid = Movto_loteimportado_Movtoloteimportadorefid;
            }

            if (item.Movto_emida != null)
                item.Movto_emida!.Emidainvoiceno = Movto_emida_Emidainvoiceno;
            else if (item.Movto_emida == null && Movto_emida_Emidainvoiceno != null)
            {
                item.Movto_emida = CreateSubEntity<Movto_emida>();
                item.Movto_emida!.Emidainvoiceno = Movto_emida_Emidainvoiceno;
            }

            if (item.Movto_emida != null)
                item.Movto_emida!.Emidarequestid = Movto_emida_Emidarequestid;
            else if (item.Movto_emida == null && Movto_emida_Emidarequestid != null)
            {
                item.Movto_emida = CreateSubEntity<Movto_emida>();
                item.Movto_emida!.Emidarequestid = Movto_emida_Emidarequestid;
            }

            if (item.Movto_emida != null)
                item.Movto_emida!.Emidacomision = Movto_emida_Emidacomision?? 0;
            else if (item.Movto_emida == null && Movto_emida_Emidacomision != null)
            {
                item.Movto_emida = CreateSubEntity<Movto_emida>();
                item.Movto_emida!.Emidacomision = Movto_emida_Emidacomision?? 0;
            }

            if (item.Movto_fact_elect_consolidacion != null)
                item.Movto_fact_elect_consolidacion!.Consolidado_subtotal = Movto_fact_elect_consolidacion_Consolidado_subtotal?? 0;
            else if (item.Movto_fact_elect_consolidacion == null && Movto_fact_elect_consolidacion_Consolidado_subtotal != null)
            {
                item.Movto_fact_elect_consolidacion = CreateSubEntity<Movto_fact_elect_consolidacion>();
                item.Movto_fact_elect_consolidacion!.Consolidado_subtotal = Movto_fact_elect_consolidacion_Consolidado_subtotal?? 0;
            }

            if (item.Movto_fact_elect_consolidacion != null)
                item.Movto_fact_elect_consolidacion!.Consolidado_iva = Movto_fact_elect_consolidacion_Consolidado_iva?? 0;
            else if (item.Movto_fact_elect_consolidacion == null && Movto_fact_elect_consolidacion_Consolidado_iva != null)
            {
                item.Movto_fact_elect_consolidacion = CreateSubEntity<Movto_fact_elect_consolidacion>();
                item.Movto_fact_elect_consolidacion!.Consolidado_iva = Movto_fact_elect_consolidacion_Consolidado_iva?? 0;
            }

            if (item.Movto_fact_elect_consolidacion != null)
                item.Movto_fact_elect_consolidacion!.Consolidado_ieps = Movto_fact_elect_consolidacion_Consolidado_ieps?? 0;
            else if (item.Movto_fact_elect_consolidacion == null && Movto_fact_elect_consolidacion_Consolidado_ieps != null)
            {
                item.Movto_fact_elect_consolidacion = CreateSubEntity<Movto_fact_elect_consolidacion>();
                item.Movto_fact_elect_consolidacion!.Consolidado_ieps = Movto_fact_elect_consolidacion_Consolidado_ieps?? 0;
            }

            if (item.Movto_fact_elect_consolidacion != null)
                item.Movto_fact_elect_consolidacion!.Consolidado_total = Movto_fact_elect_consolidacion_Consolidado_total?? 0;
            else if (item.Movto_fact_elect_consolidacion == null && Movto_fact_elect_consolidacion_Consolidado_total != null)
            {
                item.Movto_fact_elect_consolidacion = CreateSubEntity<Movto_fact_elect_consolidacion>();
                item.Movto_fact_elect_consolidacion!.Consolidado_total = Movto_fact_elect_consolidacion_Consolidado_total?? 0;
            }

            if (item.Movto_fact_elect_consolidacion != null)
                item.Movto_fact_elect_consolidacion!.Consolidado_iva_ret = Movto_fact_elect_consolidacion_Consolidado_iva_ret?? 0;
            else if (item.Movto_fact_elect_consolidacion == null && Movto_fact_elect_consolidacion_Consolidado_iva_ret != null)
            {
                item.Movto_fact_elect_consolidacion = CreateSubEntity<Movto_fact_elect_consolidacion>();
                item.Movto_fact_elect_consolidacion!.Consolidado_iva_ret = Movto_fact_elect_consolidacion_Consolidado_iva_ret?? 0;
            }

            if (item.Movto_fact_elect_consolidacion != null)
                item.Movto_fact_elect_consolidacion!.Consolidado_isr_ret = Movto_fact_elect_consolidacion_Consolidado_isr_ret?? 0;
            else if (item.Movto_fact_elect_consolidacion == null && Movto_fact_elect_consolidacion_Consolidado_isr_ret != null)
            {
                item.Movto_fact_elect_consolidacion = CreateSubEntity<Movto_fact_elect_consolidacion>();
                item.Movto_fact_elect_consolidacion!.Consolidado_isr_ret = Movto_fact_elect_consolidacion_Consolidado_isr_ret?? 0;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Localidad = Movto_inventario_Localidad;
            else if (item.Movto_inventario == null && Movto_inventario_Localidad != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Localidad = Movto_inventario_Localidad;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Registroprocesosalida = Movto_inventario_Registroprocesosalida?? BoolCN.N;
            else if (item.Movto_inventario == null && Movto_inventario_Registroprocesosalida != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Registroprocesosalida = Movto_inventario_Registroprocesosalida?? BoolCN.N;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Tipodiferenciainventarioid = Movto_inventario_Tipodiferenciainventarioid;
            else if (item.Movto_inventario == null && Movto_inventario_Tipodiferenciainventarioid != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Tipodiferenciainventarioid = Movto_inventario_Tipodiferenciainventarioid;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Anaquelid = Movto_inventario_Anaquelid;
            else if (item.Movto_inventario == null && Movto_inventario_Anaquelid != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Anaquelid = Movto_inventario_Anaquelid;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Cantidad_real = Movto_inventario_Cantidad_real?? 0;
            else if (item.Movto_inventario == null && Movto_inventario_Cantidad_real != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Cantidad_real = Movto_inventario_Cantidad_real?? 0;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Cantidad_teorica = Movto_inventario_Cantidad_teorica?? 0;
            else if (item.Movto_inventario == null && Movto_inventario_Cantidad_teorica != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Cantidad_teorica = Movto_inventario_Cantidad_teorica?? 0;
            }

            if (item.Movto_inventario != null)
                item.Movto_inventario!.Cantidad_diferencia = Movto_inventario_Cantidad_diferencia?? 0;
            else if (item.Movto_inventario == null && Movto_inventario_Cantidad_diferencia != null)
            {
                item.Movto_inventario = CreateSubEntity<Movto_inventario>();
                item.Movto_inventario!.Cantidad_diferencia = Movto_inventario_Cantidad_diferencia?? 0;
            }

            if (item.Movto_kit != null)
                item.Movto_kit!.Eskit = Movto_kit_Eskit?? BoolCN.N;
            else if (item.Movto_kit == null && Movto_kit_Eskit != null)
            {
                item.Movto_kit = CreateSubEntity<Movto_kit>();
                item.Movto_kit!.Eskit = Movto_kit_Eskit?? BoolCN.N;
            }

            if (item.Movto_kit != null)
                item.Movto_kit!.Kitimpfijo = Movto_kit_Kitimpfijo?? BoolCN.N;
            else if (item.Movto_kit == null && Movto_kit_Kitimpfijo != null)
            {
                item.Movto_kit = CreateSubEntity<Movto_kit>();
                item.Movto_kit!.Kitimpfijo = Movto_kit_Kitimpfijo?? BoolCN.N;
            }

            if (item.Movto_kit != null)
                item.Movto_kit!.Enprocesopartes = Movto_kit_Enprocesopartes?? 0;
            else if (item.Movto_kit == null && Movto_kit_Enprocesopartes != null)
            {
                item.Movto_kit = CreateSubEntity<Movto_kit>();
                item.Movto_kit!.Enprocesopartes = Movto_kit_Enprocesopartes?? 0;
            }

            if (item.Movto_kit != null)
                item.Movto_kit!.Tasaiepsparte = Movto_kit_Tasaiepsparte?? 0;
            else if (item.Movto_kit == null && Movto_kit_Tasaiepsparte != null)
            {
                item.Movto_kit = CreateSubEntity<Movto_kit>();
                item.Movto_kit!.Tasaiepsparte = Movto_kit_Tasaiepsparte?? 0;
            }

            if (item.Movto_kit != null)
                item.Movto_kit!.Tasasubtotalparte = Movto_kit_Tasasubtotalparte?? 0;
            else if (item.Movto_kit == null && Movto_kit_Tasasubtotalparte != null)
            {
                item.Movto_kit = CreateSubEntity<Movto_kit>();
                item.Movto_kit!.Tasasubtotalparte = Movto_kit_Tasasubtotalparte?? 0;
            }

            if (item.Movto_kit != null)
                item.Movto_kit!.Tasaivaparte = Movto_kit_Tasaivaparte?? 0;
            else if (item.Movto_kit == null && Movto_kit_Tasaivaparte != null)
            {
                item.Movto_kit = CreateSubEntity<Movto_kit>();
                item.Movto_kit!.Tasaivaparte = Movto_kit_Tasaivaparte?? 0;
            }

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Productokitid = Movto_kit_def_Productokitid;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Productokitid != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Productokitid = Movto_kit_def_Productokitid;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Productoparteid = Movto_kit_def_Productoparteid;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Productoparteid != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Productoparteid = Movto_kit_def_Productoparteid;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Cantidadparte = Movto_kit_def_Cantidadparte?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Cantidadparte != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Cantidadparte = Movto_kit_def_Cantidadparte?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Costoparte = Movto_kit_def_Costoparte?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Costoparte != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Costoparte = Movto_kit_def_Costoparte?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Cantidadpartetotal = Movto_kit_def_Cantidadpartetotal?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Cantidadpartetotal != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Cantidadpartetotal = Movto_kit_def_Cantidadpartetotal?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Precioporunidad = Movto_kit_def_Precioporunidad?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Precioporunidad != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Precioporunidad = Movto_kit_def_Precioporunidad?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Tasaiva = Movto_kit_def_Tasaiva?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Tasaiva != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Tasaiva = Movto_kit_def_Tasaiva?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Tasaieps = Movto_kit_def_Tasaieps?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Tasaieps != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Tasaieps = Movto_kit_def_Tasaieps?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Montosubtotal = Movto_kit_def_Montosubtotal?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Montosubtotal != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Montosubtotal = Movto_kit_def_Montosubtotal?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Montoiva = Movto_kit_def_Montoiva?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Montoiva != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Montoiva = Movto_kit_def_Montoiva?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Montoieps = Movto_kit_def_Montoieps?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Montoieps != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Montoieps = Movto_kit_def_Montoieps?? 0;
            //}

            //if (item.Movto_kit_def != null)
            //    item.Movto_kit_def!.Montototal = Movto_kit_def_Montototal?? 0;
            //else if (item.Movto_kit_def == null && Movto_kit_def_Montototal != null)
            //{
            //    item.Movto_kit_def = CreateSubEntity<Movto_kit_def>();
            //    item.Movto_kit_def!.Montototal = Movto_kit_def_Montototal?? 0;
            //}

            if (item.Movto_monedero != null)
                item.Movto_monedero!.Monederoabono = Movto_monedero_Monederoabono?? 0;
            else if (item.Movto_monedero == null && Movto_monedero_Monederoabono != null)
            {
                item.Movto_monedero = CreateSubEntity<Movto_monedero>();
                item.Movto_monedero!.Monederoabono = Movto_monedero_Monederoabono?? 0;
            }

            if (item.Movto_ordencompra != null)
                item.Movto_ordencompra!.Cantidadsurtida = Movto_ordencompra_Cantidadsurtida?? 0;
            else if (item.Movto_ordencompra == null && Movto_ordencompra_Cantidadsurtida != null)
            {
                item.Movto_ordencompra = CreateSubEntity<Movto_ordencompra>();
                item.Movto_ordencompra!.Cantidadsurtida = Movto_ordencompra_Cantidadsurtida?? 0;
            }

            if (item.Movto_ordencompra != null)
                item.Movto_ordencompra!.Cantidadfaltante = Movto_ordencompra_Cantidadfaltante?? 0;
            else if (item.Movto_ordencompra == null && Movto_ordencompra_Cantidadfaltante != null)
            {
                item.Movto_ordencompra = CreateSubEntity<Movto_ordencompra>();
                item.Movto_ordencompra!.Cantidadfaltante = Movto_ordencompra_Cantidadfaltante?? 0;
            }

            if (item.Movto_ordencompra != null)
                item.Movto_ordencompra!.Cantidaddevuelta = Movto_ordencompra_Cantidaddevuelta?? 0;
            else if (item.Movto_ordencompra == null && Movto_ordencompra_Cantidaddevuelta != null)
            {
                item.Movto_ordencompra = CreateSubEntity<Movto_ordencompra>();
                item.Movto_ordencompra!.Cantidaddevuelta = Movto_ordencompra_Cantidaddevuelta?? 0;
            }

            if (item.Movto_ordencompra != null)
                item.Movto_ordencompra!.Cantidadsaldo = Movto_ordencompra_Cantidadsaldo?? 0;
            else if (item.Movto_ordencompra == null && Movto_ordencompra_Cantidadsaldo != null)
            {
                item.Movto_ordencompra = CreateSubEntity<Movto_ordencompra>();
                item.Movto_ordencompra!.Cantidadsaldo = Movto_ordencompra_Cantidadsaldo?? 0;
            }

            if (item.Movto_ordencompra != null)
                item.Movto_ordencompra!.Movtorefid = Movto_ordencompra_Movtorefid;
            else if (item.Movto_ordencompra == null && Movto_ordencompra_Movtorefid != null)
            {
                item.Movto_ordencompra = CreateSubEntity<Movto_ordencompra>();
                item.Movto_ordencompra!.Movtorefid = Movto_ordencompra_Movtorefid;
            }

            if (item.Movto_origenfiscal != null)
                item.Movto_origenfiscal!.Cantidaddefactura = Movto_origenfiscal_Cantidaddefactura?? 0;
            else if (item.Movto_origenfiscal == null && Movto_origenfiscal_Cantidaddefactura != null)
            {
                item.Movto_origenfiscal = CreateSubEntity<Movto_origenfiscal>();
                item.Movto_origenfiscal!.Cantidaddefactura = Movto_origenfiscal_Cantidaddefactura?? 0;
            }

            if (item.Movto_origenfiscal != null)
                item.Movto_origenfiscal!.Cantidadderemision = Movto_origenfiscal_Cantidadderemision?? 0;
            else if (item.Movto_origenfiscal == null && Movto_origenfiscal_Cantidadderemision != null)
            {
                item.Movto_origenfiscal = CreateSubEntity<Movto_origenfiscal>();
                item.Movto_origenfiscal!.Cantidadderemision = Movto_origenfiscal_Cantidadderemision?? 0;
            }

            if (item.Movto_origenfiscal != null)
                item.Movto_origenfiscal!.Cantidaddeindefinido = Movto_origenfiscal_Cantidaddeindefinido?? 0;
            else if (item.Movto_origenfiscal == null && Movto_origenfiscal_Cantidaddeindefinido != null)
            {
                item.Movto_origenfiscal = CreateSubEntity<Movto_origenfiscal>();
                item.Movto_origenfiscal!.Cantidaddeindefinido = Movto_origenfiscal_Cantidaddeindefinido?? 0;
            }

            if (item.Movto_origenfiscal != null)
                item.Movto_origenfiscal!.Cantdevueltadefactura = Movto_origenfiscal_Cantdevueltadefactura?? 0;
            else if (item.Movto_origenfiscal == null && Movto_origenfiscal_Cantdevueltadefactura != null)
            {
                item.Movto_origenfiscal = CreateSubEntity<Movto_origenfiscal>();
                item.Movto_origenfiscal!.Cantdevueltadefactura = Movto_origenfiscal_Cantdevueltadefactura?? 0;
            }

            if (item.Movto_origenfiscal != null)
                item.Movto_origenfiscal!.Cantdevueltaderemision = Movto_origenfiscal_Cantdevueltaderemision?? 0;
            else if (item.Movto_origenfiscal == null && Movto_origenfiscal_Cantdevueltaderemision != null)
            {
                item.Movto_origenfiscal = CreateSubEntity<Movto_origenfiscal>();
                item.Movto_origenfiscal!.Cantdevueltaderemision = Movto_origenfiscal_Cantdevueltaderemision?? 0;
            }

            if (item.Movto_origenfiscal != null)
                item.Movto_origenfiscal!.Cantdevueltadeindefinido = Movto_origenfiscal_Cantdevueltadeindefinido?? 0;
            else if (item.Movto_origenfiscal == null && Movto_origenfiscal_Cantdevueltadeindefinido != null)
            {
                item.Movto_origenfiscal = CreateSubEntity<Movto_origenfiscal>();
                item.Movto_origenfiscal!.Cantdevueltadeindefinido = Movto_origenfiscal_Cantdevueltadeindefinido?? 0;
            }

            if (item.Movto_poliza != null)
                item.Movto_poliza!.Nutil = Movto_poliza_Nutil?? 0;
            else if (item.Movto_poliza == null && Movto_poliza_Nutil != null)
            {
                item.Movto_poliza = CreateSubEntity<Movto_poliza>();
                item.Movto_poliza!.Nutil = Movto_poliza_Nutil?? 0;
            }

            if (item.Movto_poliza != null)
                item.Movto_poliza!.Nprec = Movto_poliza_Nprec?? 0;
            else if (item.Movto_poliza == null && Movto_poliza_Nprec != null)
            {
                item.Movto_poliza = CreateSubEntity<Movto_poliza>();
                item.Movto_poliza!.Nprec = Movto_poliza_Nprec?? 0;
            }

            if (item.Movto_poliza != null)
                item.Movto_poliza!.Cdescr = Movto_poliza_Cdescr;
            else if (item.Movto_poliza == null && Movto_poliza_Cdescr != null)
            {
                item.Movto_poliza = CreateSubEntity<Movto_poliza>();
                item.Movto_poliza!.Cdescr = Movto_poliza_Cdescr;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Razondescuentocajero = Movto_precio_Razondescuentocajero;
            else if (item.Movto_precio == null && Movto_precio_Razondescuentocajero != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Razondescuentocajero = Movto_precio_Razondescuentocajero;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Preciomanualmasbajo = Movto_precio_Preciomanualmasbajo?? BoolCN.N;
            else if (item.Movto_precio == null && Movto_precio_Preciomanualmasbajo != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Preciomanualmasbajo = Movto_precio_Preciomanualmasbajo?? BoolCN.N;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Ingresopreciomanual = Movto_precio_Ingresopreciomanual?? BoolCN.N;
            else if (item.Movto_precio == null && Movto_precio_Ingresopreciomanual != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Ingresopreciomanual = Movto_precio_Ingresopreciomanual?? BoolCN.N;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Calc_imp_de_total = Movto_precio_Calc_imp_de_total;
            else if (item.Movto_precio == null && Movto_precio_Calc_imp_de_total != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Calc_imp_de_total = Movto_precio_Calc_imp_de_total;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Descuentovale = Movto_precio_Descuentovale?? 0;
            else if (item.Movto_precio == null && Movto_precio_Descuentovale != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Descuentovale = Movto_precio_Descuentovale?? 0;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Descuentovaleporcentaje = Movto_precio_Descuentovaleporcentaje?? 0;
            else if (item.Movto_precio == null && Movto_precio_Descuentovaleporcentaje != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Descuentovaleporcentaje = Movto_precio_Descuentovaleporcentaje?? 0;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Porcentajedescuentomanual = Movto_precio_Porcentajedescuentomanual?? 0;
            else if (item.Movto_precio == null && Movto_precio_Porcentajedescuentomanual != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Porcentajedescuentomanual = Movto_precio_Porcentajedescuentomanual?? 0;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Listaprecioid = Movto_precio_Listaprecioid;
            else if (item.Movto_precio == null && Movto_precio_Listaprecioid != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Listaprecioid = Movto_precio_Listaprecioid;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Precioclasificacion = Movto_precio_Precioclasificacion;
            else if (item.Movto_precio == null && Movto_precio_Precioclasificacion != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Precioclasificacion = Movto_precio_Precioclasificacion;
            }

            if (item.Movto_precio != null)
                item.Movto_precio!.Precioconimp = Movto_precio_Precioconimp?? 0;
            else if (item.Movto_precio == null && Movto_precio_Precioconimp != null)
            {
                item.Movto_precio = CreateSubEntity<Movto_precio>();
                item.Movto_precio!.Precioconimp = Movto_precio_Precioconimp?? 0;
            }

            if (item.Movto_promocion != null)
                item.Movto_promocion!.Promocion = Movto_promocion_Promocion?? BoolCN.N;
            else if (item.Movto_promocion == null && Movto_promocion_Promocion != null)
            {
                item.Movto_promocion = CreateSubEntity<Movto_promocion>();
                item.Movto_promocion!.Promocion = Movto_promocion_Promocion?? BoolCN.N;
            }

            if (item.Movto_promocion != null)
                item.Movto_promocion!.Promociondesglose = Movto_promocion_Promociondesglose;
            else if (item.Movto_promocion == null && Movto_promocion_Promociondesglose != null)
            {
                item.Movto_promocion = CreateSubEntity<Movto_promocion>();
                item.Movto_promocion!.Promociondesglose = Movto_promocion_Promociondesglose;
            }

            if (item.Movto_promocion != null)
                item.Movto_promocion!.Tipomayoreolineaid = Movto_promocion_Tipomayoreolineaid;
            else if (item.Movto_promocion == null && Movto_promocion_Tipomayoreolineaid != null)
            {
                item.Movto_promocion = CreateSubEntity<Movto_promocion>();
                item.Movto_promocion!.Tipomayoreolineaid = Movto_promocion_Tipomayoreolineaid;
            }

            if (item.Movto_promocion != null)
                item.Movto_promocion!.Aplicopromoxmontomin = Movto_promocion_Aplicopromoxmontomin;
            else if (item.Movto_promocion == null && Movto_promocion_Aplicopromoxmontomin != null)
            {
                item.Movto_promocion = CreateSubEntity<Movto_promocion>();
                item.Movto_promocion!.Aplicopromoxmontomin = Movto_promocion_Aplicopromoxmontomin;
            }

            if (item.Movto_promocion != null)
                item.Movto_promocion!.Promocionid = Movto_promocion_Promocionid;
            else if (item.Movto_promocion == null && Movto_promocion_Promocionid != null)
            {
                item.Movto_promocion = CreateSubEntity<Movto_promocion>();
                item.Movto_promocion!.Promocionid = Movto_promocion_Promocionid;
            }

            if (item.Movto_rebajaespecial != null)
                item.Movto_rebajaespecial!.Precioconrebaja = Movto_rebajaespecial_Precioconrebaja?? 0;
            else if (item.Movto_rebajaespecial == null && Movto_rebajaespecial_Precioconrebaja != null)
            {
                item.Movto_rebajaespecial = CreateSubEntity<Movto_rebajaespecial>();
                item.Movto_rebajaespecial!.Precioconrebaja = Movto_rebajaespecial_Precioconrebaja?? 0;
            }

            if (item.Movto_rebajaespecial != null)
                item.Movto_rebajaespecial!.Totalconrebaja = Movto_rebajaespecial_Totalconrebaja?? 0;
            else if (item.Movto_rebajaespecial == null && Movto_rebajaespecial_Totalconrebaja != null)
            {
                item.Movto_rebajaespecial = CreateSubEntity<Movto_rebajaespecial>();
                item.Movto_rebajaespecial!.Totalconrebaja = Movto_rebajaespecial_Totalconrebaja?? 0;
            }

            if (item.Movto_rebajaespecial != null)
                item.Movto_rebajaespecial!.Estadorebaja = Movto_rebajaespecial_Estadorebaja;
            else if (item.Movto_rebajaespecial == null && Movto_rebajaespecial_Estadorebaja != null)
            {
                item.Movto_rebajaespecial = CreateSubEntity<Movto_rebajaespecial>();
                item.Movto_rebajaespecial!.Estadorebaja = Movto_rebajaespecial_Estadorebaja;
            }

            if (item.Movto_rebajaespecial != null)
                item.Movto_rebajaespecial!.Cantautrebaja = Movto_rebajaespecial_Cantautrebaja?? 0;
            else if (item.Movto_rebajaespecial == null && Movto_rebajaespecial_Cantautrebaja != null)
            {
                item.Movto_rebajaespecial = CreateSubEntity<Movto_rebajaespecial>();
                item.Movto_rebajaespecial!.Cantautrebaja = Movto_rebajaespecial_Cantautrebaja?? 0;
            }

            if (item.Movto_rebajaespecial != null)
                item.Movto_rebajaespecial!.Montorebaja = Movto_rebajaespecial_Montorebaja?? 0;
            else if (item.Movto_rebajaespecial == null && Movto_rebajaespecial_Montorebaja != null)
            {
                item.Movto_rebajaespecial = CreateSubEntity<Movto_rebajaespecial>();
                item.Movto_rebajaespecial!.Montorebaja = Movto_rebajaespecial_Montorebaja?? 0;
            }

            if (item.Movto_revision != null)
                item.Movto_revision!.Cantidadrevisada = Movto_revision_Cantidadrevisada?? 0;
            else if (item.Movto_revision == null && Movto_revision_Cantidadrevisada != null)
            {
                item.Movto_revision = CreateSubEntity<Movto_revision>();
                item.Movto_revision!.Cantidadrevisada = Movto_revision_Cantidadrevisada?? 0;
            }

            if (item.Movto_surtido != null)
                item.Movto_surtido!.Surtible = Movto_surtido_Surtible?? BoolCS.S;
            else if (item.Movto_surtido == null && Movto_surtido_Surtible != null)
            {
                item.Movto_surtido = CreateSubEntity<Movto_surtido>();
                item.Movto_surtido!.Surtible = Movto_surtido_Surtible?? BoolCS.S;
            }

            if (item.Movto_surtido != null)
                item.Movto_surtido!.Maxsurtible = Movto_surtido_Maxsurtible?? 0;
            else if (item.Movto_surtido == null && Movto_surtido_Maxsurtible != null)
            {
                item.Movto_surtido = CreateSubEntity<Movto_surtido>();
                item.Movto_surtido!.Maxsurtible = Movto_surtido_Maxsurtible?? 0;
            }

            if (item.Movto_traslado != null)
                item.Movto_traslado!.Otromotivodevolucion = Movto_traslado_Otromotivodevolucion;
            else if (item.Movto_traslado == null && Movto_traslado_Otromotivodevolucion != null)
            {
                item.Movto_traslado = CreateSubEntity<Movto_traslado>();
                item.Movto_traslado!.Otromotivodevolucion = Movto_traslado_Otromotivodevolucion;
            }

            if (item.Movto_traslado != null)
                item.Movto_traslado!.Preciovisibletraslado = Movto_traslado_Preciovisibletraslado?? 0;
            else if (item.Movto_traslado == null && Movto_traslado_Preciovisibletraslado != null)
            {
                item.Movto_traslado = CreateSubEntity<Movto_traslado>();
                item.Movto_traslado!.Preciovisibletraslado = Movto_traslado_Preciovisibletraslado?? 0;
            }

            if (item.Movto_traslado != null)
                item.Movto_traslado!.Movtoimportadoid = Movto_traslado_Movtoimportadoid;
            else if (item.Movto_traslado == null && Movto_traslado_Movtoimportadoid != null)
            {
                item.Movto_traslado = CreateSubEntity<Movto_traslado>();
                item.Movto_traslado!.Movtoimportadoid = Movto_traslado_Movtoimportadoid;
            }

            if (item.Movto_traslado != null)
                item.Movto_traslado!.Motivodevolucionid = Movto_traslado_Motivodevolucionid;
            else if (item.Movto_traslado == null && Movto_traslado_Motivodevolucionid != null)
            {
                item.Movto_traslado = CreateSubEntity<Movto_traslado>();
                item.Movto_traslado!.Motivodevolucionid = Movto_traslado_Motivodevolucionid;
            }


        }

        public void FillFromEntity(Movto item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Lote = item.Lote;

            Afectainventario = item.Afectainventario;

            Afectatotales = item.Afectatotales;

            Eskit = item.Eskit;

            Kitimpfijo = item.Kitimpfijo;

            Partida = item.Partida;

            Estatusmovtoid = item.Estatusmovtoid;

            Fecha = item.Fecha;

            Fechahora = item.Fechahora;

            Productoid = item.Productoid;

            Cantidad = item.Cantidad;

            Preciolista = item.Preciolista;

            Descuentoporcentaje = item.Descuentoporcentaje;

            Descuento = item.Descuento;

            Precio = item.Precio;

            Importe = item.Importe;

            Subtotal = item.Subtotal;

            Iva = item.Iva;

            Ieps = item.Ieps;

            Tasaiva = item.Tasaiva;

            Tasaieps = item.Tasaieps;

            Total = item.Total;

            Fechavence = item.Fechavence;

            Loteimportado = item.Loteimportado;

            Movtoparentid = item.Movtoparentid;

            Movtonivel = item.Movtonivel;

            Doctoid = item.Doctoid;

            Cargo = item.Cargo;

            Abono = item.Abono;

            Saldo = item.Saldo;

            Preciomanual = item.Preciomanual;

            Preciomaximopublico = item.Preciomaximopublico;

            Isrretenido = item.Isrretenido;

            Ivaretenido = item.Ivaretenido;

            Orden = item.Orden;

            Tasaisrretenido = item.Tasaisrretenido;

            Tasaivaretenido = item.Tasaivaretenido;


            if (item.Movto_comision != null && item.Movto_comision?.Comisionxunidad != null)
                    Movto_comision_Comisionxunidad = item.Movto_comision!.Comisionxunidad;

            if (item.Movto_comision != null && item.Movto_comision?.Comision != null)
                    Movto_comision_Comision = item.Movto_comision!.Comision;

            if (item.Movto_comision != null && item.Movto_comision?.Comisionporc != null)
                    Movto_comision_Comisionporc = item.Movto_comision!.Comisionporc;

            if (item.Movto_comodin != null && item.Movto_comodin?.Descripcion1 != null)
                    Movto_comodin_Descripcion1 = item.Movto_comodin!.Descripcion1;

            if (item.Movto_comodin != null && item.Movto_comodin?.Descripcion2 != null)
                    Movto_comodin_Descripcion2 = item.Movto_comodin!.Descripcion2;

            if (item.Movto_comodin != null && item.Movto_comodin?.Descripcion3 != null)
                    Movto_comodin_Descripcion3 = item.Movto_comodin!.Descripcion3;

            if (item.Movto_comodin != null && item.Movto_comodin?.Claveprod != null)
                    Movto_comodin_Claveprod = item.Movto_comodin!.Claveprod;

            if (item.Movto_cancelacion != null && item.Movto_cancelacion?.Movtorefid != null)
                    Movto_cancelacion_Movtorefid = item.Movto_cancelacion!.Movtorefid;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Movtorefid != null)
                    Movto_devolucion_Movtorefid = item.Movto_devolucion!.Movtorefid;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Cantidadsurtida != null)
                    Movto_devolucion_Cantidadsurtida = item.Movto_devolucion!.Cantidadsurtida;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Cantidadfaltante != null)
                    Movto_devolucion_Cantidadfaltante = item.Movto_devolucion!.Cantidadfaltante;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Cantidaddevuelta != null)
                    Movto_devolucion_Cantidaddevuelta = item.Movto_devolucion!.Cantidaddevuelta;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Cantidadsaldo != null)
                    Movto_devolucion_Cantidadsaldo = item.Movto_devolucion!.Cantidadsaldo;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Razondiferenciaid != null)
                    Movto_devolucion_Razondiferenciaid = item.Movto_devolucion!.Razondiferenciaid;

            if (item.Movto_devolucion != null && item.Movto_devolucion?.Otrarazondiferencia != null)
                    Movto_devolucion_Otrarazondiferencia = item.Movto_devolucion!.Otrarazondiferencia;

            if (item.Movto_loteimportado != null && item.Movto_loteimportado?.Movtoloteimportadorefid != null)
                    Movto_loteimportado_Movtoloteimportadorefid = item.Movto_loteimportado!.Movtoloteimportadorefid;

            if (item.Movto_emida != null && item.Movto_emida?.Emidainvoiceno != null)
                    Movto_emida_Emidainvoiceno = item.Movto_emida!.Emidainvoiceno;

            if (item.Movto_emida != null && item.Movto_emida?.Emidarequestid != null)
                    Movto_emida_Emidarequestid = item.Movto_emida!.Emidarequestid;

            if (item.Movto_emida != null && item.Movto_emida?.Emidacomision != null)
                    Movto_emida_Emidacomision = item.Movto_emida!.Emidacomision;

            if (item.Movto_fact_elect_consolidacion != null && item.Movto_fact_elect_consolidacion?.Consolidado_subtotal != null)
                    Movto_fact_elect_consolidacion_Consolidado_subtotal = item.Movto_fact_elect_consolidacion!.Consolidado_subtotal;

            if (item.Movto_fact_elect_consolidacion != null && item.Movto_fact_elect_consolidacion?.Consolidado_iva != null)
                    Movto_fact_elect_consolidacion_Consolidado_iva = item.Movto_fact_elect_consolidacion!.Consolidado_iva;

            if (item.Movto_fact_elect_consolidacion != null && item.Movto_fact_elect_consolidacion?.Consolidado_ieps != null)
                    Movto_fact_elect_consolidacion_Consolidado_ieps = item.Movto_fact_elect_consolidacion!.Consolidado_ieps;

            if (item.Movto_fact_elect_consolidacion != null && item.Movto_fact_elect_consolidacion?.Consolidado_total != null)
                    Movto_fact_elect_consolidacion_Consolidado_total = item.Movto_fact_elect_consolidacion!.Consolidado_total;

            if (item.Movto_fact_elect_consolidacion != null && item.Movto_fact_elect_consolidacion?.Consolidado_iva_ret != null)
                    Movto_fact_elect_consolidacion_Consolidado_iva_ret = item.Movto_fact_elect_consolidacion!.Consolidado_iva_ret;

            if (item.Movto_fact_elect_consolidacion != null && item.Movto_fact_elect_consolidacion?.Consolidado_isr_ret != null)
                    Movto_fact_elect_consolidacion_Consolidado_isr_ret = item.Movto_fact_elect_consolidacion!.Consolidado_isr_ret;

            if (item.Movto_inventario != null && item.Movto_inventario?.Localidad != null)
                    Movto_inventario_Localidad = item.Movto_inventario!.Localidad;

            if (item.Movto_inventario != null && item.Movto_inventario?.Registroprocesosalida != null)
                    Movto_inventario_Registroprocesosalida = item.Movto_inventario!.Registroprocesosalida;

            if (item.Movto_inventario != null && item.Movto_inventario?.Tipodiferenciainventarioid != null)
                    Movto_inventario_Tipodiferenciainventarioid = item.Movto_inventario!.Tipodiferenciainventarioid;

            if (item.Movto_inventario != null && item.Movto_inventario?.Anaquelid != null)
                    Movto_inventario_Anaquelid = item.Movto_inventario!.Anaquelid;

            if (item.Movto_inventario != null && item.Movto_inventario?.Cantidad_real != null)
                    Movto_inventario_Cantidad_real = item.Movto_inventario!.Cantidad_real;

            if (item.Movto_inventario != null && item.Movto_inventario?.Cantidad_teorica != null)
                    Movto_inventario_Cantidad_teorica = item.Movto_inventario!.Cantidad_teorica;

            if (item.Movto_inventario != null && item.Movto_inventario?.Cantidad_diferencia != null)
                    Movto_inventario_Cantidad_diferencia = item.Movto_inventario!.Cantidad_diferencia;

            if (item.Movto_kit != null && item.Movto_kit?.Eskit != null)
                    Movto_kit_Eskit = item.Movto_kit!.Eskit;

            if (item.Movto_kit != null && item.Movto_kit?.Kitimpfijo != null)
                    Movto_kit_Kitimpfijo = item.Movto_kit!.Kitimpfijo;

            if (item.Movto_kit != null && item.Movto_kit?.Enprocesopartes != null)
                    Movto_kit_Enprocesopartes = item.Movto_kit!.Enprocesopartes;

            if (item.Movto_kit != null && item.Movto_kit?.Tasaiepsparte != null)
                    Movto_kit_Tasaiepsparte = item.Movto_kit!.Tasaiepsparte;

            if (item.Movto_kit != null && item.Movto_kit?.Tasasubtotalparte != null)
                    Movto_kit_Tasasubtotalparte = item.Movto_kit!.Tasasubtotalparte;

            if (item.Movto_kit != null && item.Movto_kit?.Tasaivaparte != null)
                    Movto_kit_Tasaivaparte = item.Movto_kit!.Tasaivaparte;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Productokitid != null)
            //        Movto_kit_def_Productokitid = item.Movto_kit_def!.Productokitid;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Productoparteid != null)
            //        Movto_kit_def_Productoparteid = item.Movto_kit_def!.Productoparteid;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Cantidadparte != null)
            //        Movto_kit_def_Cantidadparte = item.Movto_kit_def!.Cantidadparte;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Costoparte != null)
            //        Movto_kit_def_Costoparte = item.Movto_kit_def!.Costoparte;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Cantidadpartetotal != null)
            //        Movto_kit_def_Cantidadpartetotal = item.Movto_kit_def!.Cantidadpartetotal;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Precioporunidad != null)
            //        Movto_kit_def_Precioporunidad = item.Movto_kit_def!.Precioporunidad;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Tasaiva != null)
            //        Movto_kit_def_Tasaiva = item.Movto_kit_def!.Tasaiva;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Tasaieps != null)
            //        Movto_kit_def_Tasaieps = item.Movto_kit_def!.Tasaieps;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Montosubtotal != null)
            //        Movto_kit_def_Montosubtotal = item.Movto_kit_def!.Montosubtotal;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Montoiva != null)
            //        Movto_kit_def_Montoiva = item.Movto_kit_def!.Montoiva;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Montoieps != null)
            //        Movto_kit_def_Montoieps = item.Movto_kit_def!.Montoieps;

            //if (item.Movto_kit_def != null && item.Movto_kit_def?.Montototal != null)
            //        Movto_kit_def_Montototal = item.Movto_kit_def!.Montototal;

            if (item.Movto_monedero != null && item.Movto_monedero?.Monederoabono != null)
                    Movto_monedero_Monederoabono = item.Movto_monedero!.Monederoabono;

            if (item.Movto_ordencompra != null && item.Movto_ordencompra?.Cantidadsurtida != null)
                    Movto_ordencompra_Cantidadsurtida = item.Movto_ordencompra!.Cantidadsurtida;

            if (item.Movto_ordencompra != null && item.Movto_ordencompra?.Cantidadfaltante != null)
                    Movto_ordencompra_Cantidadfaltante = item.Movto_ordencompra!.Cantidadfaltante;

            if (item.Movto_ordencompra != null && item.Movto_ordencompra?.Cantidaddevuelta != null)
                    Movto_ordencompra_Cantidaddevuelta = item.Movto_ordencompra!.Cantidaddevuelta;

            if (item.Movto_ordencompra != null && item.Movto_ordencompra?.Cantidadsaldo != null)
                    Movto_ordencompra_Cantidadsaldo = item.Movto_ordencompra!.Cantidadsaldo;

            if (item.Movto_ordencompra != null && item.Movto_ordencompra?.Movtorefid != null)
                    Movto_ordencompra_Movtorefid = item.Movto_ordencompra!.Movtorefid;

            if (item.Movto_origenfiscal != null && item.Movto_origenfiscal?.Cantidaddefactura != null)
                    Movto_origenfiscal_Cantidaddefactura = item.Movto_origenfiscal!.Cantidaddefactura;

            if (item.Movto_origenfiscal != null && item.Movto_origenfiscal?.Cantidadderemision != null)
                    Movto_origenfiscal_Cantidadderemision = item.Movto_origenfiscal!.Cantidadderemision;

            if (item.Movto_origenfiscal != null && item.Movto_origenfiscal?.Cantidaddeindefinido != null)
                    Movto_origenfiscal_Cantidaddeindefinido = item.Movto_origenfiscal!.Cantidaddeindefinido;

            if (item.Movto_origenfiscal != null && item.Movto_origenfiscal?.Cantdevueltadefactura != null)
                    Movto_origenfiscal_Cantdevueltadefactura = item.Movto_origenfiscal!.Cantdevueltadefactura;

            if (item.Movto_origenfiscal != null && item.Movto_origenfiscal?.Cantdevueltaderemision != null)
                    Movto_origenfiscal_Cantdevueltaderemision = item.Movto_origenfiscal!.Cantdevueltaderemision;

            if (item.Movto_origenfiscal != null && item.Movto_origenfiscal?.Cantdevueltadeindefinido != null)
                    Movto_origenfiscal_Cantdevueltadeindefinido = item.Movto_origenfiscal!.Cantdevueltadeindefinido;

            if (item.Movto_poliza != null && item.Movto_poliza?.Nutil != null)
                    Movto_poliza_Nutil = item.Movto_poliza!.Nutil;

            if (item.Movto_poliza != null && item.Movto_poliza?.Nprec != null)
                    Movto_poliza_Nprec = item.Movto_poliza!.Nprec;

            if (item.Movto_poliza != null && item.Movto_poliza?.Cdescr != null)
                    Movto_poliza_Cdescr = item.Movto_poliza!.Cdescr;

            if (item.Movto_precio != null && item.Movto_precio?.Razondescuentocajero != null)
                    Movto_precio_Razondescuentocajero = item.Movto_precio!.Razondescuentocajero;

            if (item.Movto_precio != null && item.Movto_precio?.Preciomanualmasbajo != null)
                    Movto_precio_Preciomanualmasbajo = item.Movto_precio!.Preciomanualmasbajo;

            if (item.Movto_precio != null && item.Movto_precio?.Ingresopreciomanual != null)
                    Movto_precio_Ingresopreciomanual = item.Movto_precio!.Ingresopreciomanual;

            if (item.Movto_precio != null && item.Movto_precio?.Calc_imp_de_total != null)
                    Movto_precio_Calc_imp_de_total = item.Movto_precio!.Calc_imp_de_total;

            if (item.Movto_precio != null && item.Movto_precio?.Descuentovale != null)
                    Movto_precio_Descuentovale = item.Movto_precio!.Descuentovale;

            if (item.Movto_precio != null && item.Movto_precio?.Descuentovaleporcentaje != null)
                    Movto_precio_Descuentovaleporcentaje = item.Movto_precio!.Descuentovaleporcentaje;

            if (item.Movto_precio != null && item.Movto_precio?.Porcentajedescuentomanual != null)
                    Movto_precio_Porcentajedescuentomanual = item.Movto_precio!.Porcentajedescuentomanual;

            if (item.Movto_precio != null && item.Movto_precio?.Listaprecioid != null)
                    Movto_precio_Listaprecioid = item.Movto_precio!.Listaprecioid;

            if (item.Movto_precio != null && item.Movto_precio?.Precioclasificacion != null)
                    Movto_precio_Precioclasificacion = item.Movto_precio!.Precioclasificacion;

            if (item.Movto_precio != null && item.Movto_precio?.Precioconimp != null)
                    Movto_precio_Precioconimp = item.Movto_precio!.Precioconimp;

            if (item.Movto_promocion != null && item.Movto_promocion?.Promocion != null)
                    Movto_promocion_Promocion = item.Movto_promocion!.Promocion;

            if (item.Movto_promocion != null && item.Movto_promocion?.Promociondesglose != null)
                    Movto_promocion_Promociondesglose = item.Movto_promocion!.Promociondesglose;

            if (item.Movto_promocion != null && item.Movto_promocion.Tipomayoreolineaid != null)
                Movto_promocion_Tipomayoreolineaid = item.Movto_promocion!.Tipomayoreolineaid;




            if (item.Movto_promocion != null && item.Movto_promocion?.Aplicopromoxmontomin != null)
                    Movto_promocion_Aplicopromoxmontomin = item.Movto_promocion!.Aplicopromoxmontomin;

            if (item.Movto_promocion != null && item.Movto_promocion?.Promocionid != null)
                    Movto_promocion_Promocionid = item.Movto_promocion!.Promocionid;

            if (item.Movto_rebajaespecial != null && item.Movto_rebajaespecial?.Precioconrebaja != null)
                    Movto_rebajaespecial_Precioconrebaja = item.Movto_rebajaespecial!.Precioconrebaja;

            if (item.Movto_rebajaespecial != null && item.Movto_rebajaespecial?.Totalconrebaja != null)
                    Movto_rebajaespecial_Totalconrebaja = item.Movto_rebajaespecial!.Totalconrebaja;

            if (item.Movto_rebajaespecial != null && item.Movto_rebajaespecial?.Estadorebaja != null)
                    Movto_rebajaespecial_Estadorebaja = item.Movto_rebajaespecial!.Estadorebaja;

            if (item.Movto_rebajaespecial != null && item.Movto_rebajaespecial?.Cantautrebaja != null)
                    Movto_rebajaespecial_Cantautrebaja = item.Movto_rebajaespecial!.Cantautrebaja;

            if (item.Movto_rebajaespecial != null && item.Movto_rebajaespecial?.Montorebaja != null)
                    Movto_rebajaespecial_Montorebaja = item.Movto_rebajaespecial!.Montorebaja;

            if (item.Movto_revision != null && item.Movto_revision?.Cantidadrevisada != null)
                    Movto_revision_Cantidadrevisada = item.Movto_revision!.Cantidadrevisada;

            if (item.Movto_surtido != null && item.Movto_surtido?.Surtible != null)
                    Movto_surtido_Surtible = item.Movto_surtido!.Surtible;

            if (item.Movto_surtido != null && item.Movto_surtido?.Maxsurtible != null)
                    Movto_surtido_Maxsurtible = item.Movto_surtido!.Maxsurtible;

            if (item.Movto_traslado != null && item.Movto_traslado?.Otromotivodevolucion != null)
                    Movto_traslado_Otromotivodevolucion = item.Movto_traslado!.Otromotivodevolucion;

            if (item.Movto_traslado != null && item.Movto_traslado?.Preciovisibletraslado != null)
                    Movto_traslado_Preciovisibletraslado = item.Movto_traslado!.Preciovisibletraslado;

            if (item.Movto_traslado != null && item.Movto_traslado?.Movtoimportadoid != null)
                    Movto_traslado_Movtoimportadoid = item.Movto_traslado!.Movtoimportadoid;

            if (item.Movto_traslado != null && item.Movto_traslado?.Motivodevolucionid != null)
                    Movto_traslado_Motivodevolucionid = item.Movto_traslado!.Motivodevolucionid;


             FillCatalogRelatedFields(item);


        }
        #endif





    }
}

