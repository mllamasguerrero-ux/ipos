
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
    
    public class ParametroBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ParametroBindingModelGenerated()
        {
        }
        

        #if PROYECTO_WEB
        public ParametroBindingModelGenerated(Parametro item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }
        #endif
        


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

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _Lista_precio_defid;
        [XmlAttribute]
        public long? Lista_precio_defid { get => _Lista_precio_defid; set { if (RaiseAcceptPendingChange(value, _Lista_precio_defid)) { _Lista_precio_defid = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_defClave;
        [XmlAttribute]
        public string? Lista_precio_defClave { get => _Lista_precio_defClave; set { if (RaiseAcceptPendingChange(value, _Lista_precio_defClave)) { _Lista_precio_defClave = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_defNombre;
        [XmlAttribute]
        public string? Lista_precio_defNombre { get => _Lista_precio_defNombre; set { if (RaiseAcceptPendingChange(value, _Lista_precio_defNombre)) { _Lista_precio_defNombre = value; OnPropertyChanged(); } } }

        private decimal? _Imp_prod_def;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Imp_prod_def { get => _Imp_prod_def?? 0; set { if (RaiseAcceptPendingChange(value, _Imp_prod_def)) { _Imp_prod_def = value?? 0; OnPropertyChanged(); } } }

        private string? _Estado_def;
        [XmlAttribute]
        public string? Estado_def { get => _Estado_def; set { if (RaiseAcceptPendingChange(value, _Estado_def)) { _Estado_def = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_traspaso;
        [XmlAttribute]
        public string? Lista_precio_traspaso { get => _Lista_precio_traspaso; set { if (RaiseAcceptPendingChange(value, _Lista_precio_traspaso)) { _Lista_precio_traspaso = value; OnPropertyChanged(); } } }

        private BoolCN? _Promocion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Promocion { get => _Promocion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Promocion)) { _Promocion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Utilidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Utilidad { get => _Utilidad?? 0; set { if (RaiseAcceptPendingChange(value, _Utilidad)) { _Utilidad = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaanterior;
        [XmlAttribute]
        public DateTimeOffset? Fechaanterior { get => _Fechaanterior; set { if (RaiseAcceptPendingChange(value, _Fechaanterior)) { _Fechaanterior = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaactual;
        [XmlAttribute]
        public DateTimeOffset? Fechaactual { get => _Fechaactual; set { if (RaiseAcceptPendingChange(value, _Fechaactual)) { _Fechaactual = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaultima;
        [XmlAttribute]
        public DateTimeOffset? Fechaultima { get => _Fechaultima; set { if (RaiseAcceptPendingChange(value, _Fechaultima)) { _Fechaultima = value; OnPropertyChanged(); } } }

        private decimal? _Max_inv_fis_cant;
        [XmlAttribute]
        public decimal? Max_inv_fis_cant { get => _Max_inv_fis_cant; set { if (RaiseAcceptPendingChange(value, _Max_inv_fis_cant)) { _Max_inv_fis_cant = value; OnPropertyChanged(); } } }

        private string? _Inventory_email;
        [XmlAttribute]
        public string? Inventory_email { get => _Inventory_email; set { if (RaiseAcceptPendingChange(value, _Inventory_email)) { _Inventory_email = value; OnPropertyChanged(); } } }

        private string? _Id_dosletras;
        [XmlAttribute]
        public string? Id_dosletras { get => _Id_dosletras; set { if (RaiseAcceptPendingChange(value, _Id_dosletras)) { _Id_dosletras = value; OnPropertyChanged(); } } }

        private BoolCN? _Habilitar_impexp_aut;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habilitar_impexp_aut { get => _Habilitar_impexp_aut?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habilitar_impexp_aut)) { _Habilitar_impexp_aut = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Comisionmedico;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comisionmedico { get => _Comisionmedico?? 0; set { if (RaiseAcceptPendingChange(value, _Comisionmedico)) { _Comisionmedico = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Comisiondependiente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comisiondependiente { get => _Comisiondependiente?? 0; set { if (RaiseAcceptPendingChange(value, _Comisiondependiente)) { _Comisiondependiente = value?? 0; OnPropertyChanged(); } } }

        private string? _Ftphost;
        [XmlAttribute]
        public string? Ftphost { get => _Ftphost; set { if (RaiseAcceptPendingChange(value, _Ftphost)) { _Ftphost = value; OnPropertyChanged(); } } }

        private string? _Ftpusuario;
        [XmlAttribute]
        public string? Ftpusuario { get => _Ftpusuario; set { if (RaiseAcceptPendingChange(value, _Ftpusuario)) { _Ftpusuario = value; OnPropertyChanged(); } } }

        private string? _Ftppassword;
        [XmlAttribute]
        public string? Ftppassword { get => _Ftppassword; set { if (RaiseAcceptPendingChange(value, _Ftppassword)) { _Ftppassword = value; OnPropertyChanged(); } } }

        private string? _Smtphost;
        [XmlAttribute]
        public string? Smtphost { get => _Smtphost; set { if (RaiseAcceptPendingChange(value, _Smtphost)) { _Smtphost = value; OnPropertyChanged(); } } }

        private string? _Smtpusuario;
        [XmlAttribute]
        public string? Smtpusuario { get => _Smtpusuario; set { if (RaiseAcceptPendingChange(value, _Smtpusuario)) { _Smtpusuario = value; OnPropertyChanged(); } } }

        private string? _Smtppassword;
        [XmlAttribute]
        public string? Smtppassword { get => _Smtppassword; set { if (RaiseAcceptPendingChange(value, _Smtppassword)) { _Smtppassword = value; OnPropertyChanged(); } } }

        private int? _Smtpport;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Smtpport { get => _Smtpport?? 0; set { if (RaiseAcceptPendingChange(value, _Smtpport)) { _Smtpport = value?? 0; OnPropertyChanged(); } } }

        private string? _Smtpmailfrom;
        [XmlAttribute]
        public string? Smtpmailfrom { get => _Smtpmailfrom; set { if (RaiseAcceptPendingChange(value, _Smtpmailfrom)) { _Smtpmailfrom = value; OnPropertyChanged(); } } }

        private string? _Smtpmailto;
        [XmlAttribute]
        public string? Smtpmailto { get => _Smtpmailto; set { if (RaiseAcceptPendingChange(value, _Smtpmailto)) { _Smtpmailto = value; OnPropertyChanged(); } } }

        private BoolCN? _Cambiarprecio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cambiarprecio { get => _Cambiarprecio?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cambiarprecio)) { _Cambiarprecio = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Listapreciominimo;
        [XmlAttribute]
        public long? Listapreciominimo { get => _Listapreciominimo; set { if (RaiseAcceptPendingChange(value, _Listapreciominimo)) { _Listapreciominimo = value; OnPropertyChanged(); } } }

        private string? _Listapreciominimo_Clave;
        [XmlAttribute]
        public string? Listapreciominimo_Clave { get => _Listapreciominimo_Clave; set { if (RaiseAcceptPendingChange(value, _Listapreciominimo_Clave)) { _Listapreciominimo_Clave = value; OnPropertyChanged(); } } }

        private string? _Listapreciominimo_Nombre;
        [XmlAttribute]
        public string? Listapreciominimo_Nombre { get => _Listapreciominimo_Nombre; set { if (RaiseAcceptPendingChange(value, _Listapreciominimo_Nombre)) { _Listapreciominimo_Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Compraentienda;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Compraentienda { get => _Compraentienda?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Compraentienda)) { _Compraentienda = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Header;
        [XmlAttribute]
        public string? Header { get => _Header; set { if (RaiseAcceptPendingChange(value, _Header)) { _Header = value; OnPropertyChanged(); } } }

        private string? _Footer;
        [XmlAttribute]
        public string? Footer { get => _Footer; set { if (RaiseAcceptPendingChange(value, _Footer)) { _Footer = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_sel_cliente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_sel_cliente { get => _Hab_sel_cliente?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_sel_cliente)) { _Hab_sel_cliente = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Hab_impr_cotizacion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_impr_cotizacion { get => _Hab_impr_cotizacion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_impr_cotizacion)) { _Hab_impr_cotizacion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Mostrar_exis_suc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrar_exis_suc { get => _Mostrar_exis_suc?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrar_exis_suc)) { _Mostrar_exis_suc = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Req_aprobacion_inv;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Req_aprobacion_inv { get => _Req_aprobacion_inv?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Req_aprobacion_inv)) { _Req_aprobacion_inv = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Reabrircortes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Reabrircortes { get => _Reabrircortes?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Reabrircortes)) { _Reabrircortes = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Descuentovale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentovale { get => _Descuentovale?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentovale)) { _Descuentovale = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Ult_fecha_imp_prod;
        [XmlAttribute]
        public DateTimeOffset? Ult_fecha_imp_prod { get => _Ult_fecha_imp_prod; set { if (RaiseAcceptPendingChange(value, _Ult_fecha_imp_prod)) { _Ult_fecha_imp_prod = value; OnPropertyChanged(); } } }

        private BoolCN? _Imp_prod_total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Imp_prod_total { get => _Imp_prod_total?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Imp_prod_total)) { _Imp_prod_total = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Calle;
        [XmlAttribute]
        public string? Calle { get => _Calle; set { if (RaiseAcceptPendingChange(value, _Calle)) { _Calle = value; OnPropertyChanged(); } } }

        private string? _Numeroexterior;
        [XmlAttribute]
        public string? Numeroexterior { get => _Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Numeroexterior)) { _Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Numerointerior;
        [XmlAttribute]
        public string? Numerointerior { get => _Numerointerior; set { if (RaiseAcceptPendingChange(value, _Numerointerior)) { _Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Colonia;
        [XmlAttribute]
        public string? Colonia { get => _Colonia; set { if (RaiseAcceptPendingChange(value, _Colonia)) { _Colonia = value; OnPropertyChanged(); } } }

        private string? _Municipio;
        [XmlAttribute]
        public string? Municipio { get => _Municipio; set { if (RaiseAcceptPendingChange(value, _Municipio)) { _Municipio = value; OnPropertyChanged(); } } }

        private string? _Estado;
        [XmlAttribute]
        public string? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private string? _Codigopostal;
        [XmlAttribute]
        public string? Codigopostal { get => _Codigopostal; set { if (RaiseAcceptPendingChange(value, _Codigopostal)) { _Codigopostal = value; OnPropertyChanged(); } } }

        private string? _Fiscalcalle;
        [XmlAttribute]
        public string? Fiscalcalle { get => _Fiscalcalle; set { if (RaiseAcceptPendingChange(value, _Fiscalcalle)) { _Fiscalcalle = value; OnPropertyChanged(); } } }

        private string? _Fiscalnumerointerior;
        [XmlAttribute]
        public string? Fiscalnumerointerior { get => _Fiscalnumerointerior; set { if (RaiseAcceptPendingChange(value, _Fiscalnumerointerior)) { _Fiscalnumerointerior = value; OnPropertyChanged(); } } }

        private string? _Fiscalnumeroexterior;
        [XmlAttribute]
        public string? Fiscalnumeroexterior { get => _Fiscalnumeroexterior; set { if (RaiseAcceptPendingChange(value, _Fiscalnumeroexterior)) { _Fiscalnumeroexterior = value; OnPropertyChanged(); } } }

        private string? _Fiscalcolonia;
        [XmlAttribute]
        public string? Fiscalcolonia { get => _Fiscalcolonia; set { if (RaiseAcceptPendingChange(value, _Fiscalcolonia)) { _Fiscalcolonia = value; OnPropertyChanged(); } } }

        private string? _Fiscalmunicipio;
        [XmlAttribute]
        public string? Fiscalmunicipio { get => _Fiscalmunicipio; set { if (RaiseAcceptPendingChange(value, _Fiscalmunicipio)) { _Fiscalmunicipio = value; OnPropertyChanged(); } } }

        private string? _Fiscalestado;
        [XmlAttribute]
        public string? Fiscalestado { get => _Fiscalestado; set { if (RaiseAcceptPendingChange(value, _Fiscalestado)) { _Fiscalestado = value; OnPropertyChanged(); } } }

        private string? _Fiscalcodigopostal;
        [XmlAttribute]
        public string? Fiscalcodigopostal { get => _Fiscalcodigopostal; set { if (RaiseAcceptPendingChange(value, _Fiscalcodigopostal)) { _Fiscalcodigopostal = value; OnPropertyChanged(); } } }

        private string? _Certificadocsd;
        [XmlAttribute]
        public string? Certificadocsd { get => _Certificadocsd; set { if (RaiseAcceptPendingChange(value, _Certificadocsd)) { _Certificadocsd = value; OnPropertyChanged(); } } }

        private string? _Timbradouser;
        [XmlAttribute]
        public string? Timbradouser { get => _Timbradouser; set { if (RaiseAcceptPendingChange(value, _Timbradouser)) { _Timbradouser = value; OnPropertyChanged(); } } }

        private string? _Timbradopassword;
        [XmlAttribute]
        public string? Timbradopassword { get => _Timbradopassword; set { if (RaiseAcceptPendingChange(value, _Timbradopassword)) { _Timbradopassword = value; OnPropertyChanged(); } } }

        private string? _Timbradoarchivocertificado;
        [XmlAttribute]
        public string? Timbradoarchivocertificado { get => _Timbradoarchivocertificado; set { if (RaiseAcceptPendingChange(value, _Timbradoarchivocertificado)) { _Timbradoarchivocertificado = value; OnPropertyChanged(); } } }

        private string? _Timbradoarchivokey;
        [XmlAttribute]
        public string? Timbradoarchivokey { get => _Timbradoarchivokey; set { if (RaiseAcceptPendingChange(value, _Timbradoarchivokey)) { _Timbradoarchivokey = value; OnPropertyChanged(); } } }

        private string? _Timbradokey;
        [XmlAttribute]
        public string? Timbradokey { get => _Timbradokey; set { if (RaiseAcceptPendingChange(value, _Timbradokey)) { _Timbradokey = value; OnPropertyChanged(); } } }

        private string? _Fiscalnombre;
        [XmlAttribute]
        public string? Fiscalnombre { get => _Fiscalnombre; set { if (RaiseAcceptPendingChange(value, _Fiscalnombre)) { _Fiscalnombre = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private BoolCN? _Usarfiscalesenexpedicion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Usarfiscalesenexpedicion { get => _Usarfiscalesenexpedicion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Usarfiscalesenexpedicion)) { _Usarfiscalesenexpedicion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Hab_facturaelectronica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_facturaelectronica { get => _Hab_facturaelectronica?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_facturaelectronica)) { _Hab_facturaelectronica = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Footerventaapartado;
        [XmlAttribute]
        public string? Footerventaapartado { get => _Footerventaapartado; set { if (RaiseAcceptPendingChange(value, _Footerventaapartado)) { _Footerventaapartado = value; OnPropertyChanged(); } } }

        private long? _Encargadoid;
        [XmlAttribute]
        public long? Encargadoid { get => _Encargadoid; set { if (RaiseAcceptPendingChange(value, _Encargadoid)) { _Encargadoid = value; OnPropertyChanged(); } } }

        private string? _EncargadoClave;
        [XmlAttribute]
        public string? EncargadoClave { get => _EncargadoClave; set { if (RaiseAcceptPendingChange(value, _EncargadoClave)) { _EncargadoClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoNombre;
        [XmlAttribute]
        public string? EncargadoNombre { get => _EncargadoNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoNombre)) { _EncargadoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Porc_comisionencargado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Porc_comisionencargado { get => _Porc_comisionencargado?? 0; set { if (RaiseAcceptPendingChange(value, _Porc_comisionencargado)) { _Porc_comisionencargado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Porc_comisionvendedor;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Porc_comisionvendedor { get => _Porc_comisionvendedor?? 0; set { if (RaiseAcceptPendingChange(value, _Porc_comisionvendedor)) { _Porc_comisionvendedor = value?? 0; OnPropertyChanged(); } } }

        private string? _Ftpfolder;
        [XmlAttribute]
        public string? Ftpfolder { get => _Ftpfolder; set { if (RaiseAcceptPendingChange(value, _Ftpfolder)) { _Ftpfolder = value; OnPropertyChanged(); } } }

        private string? _Ftpfolderpass;
        [XmlAttribute]
        public string? Ftpfolderpass { get => _Ftpfolderpass; set { if (RaiseAcceptPendingChange(value, _Ftpfolderpass)) { _Ftpfolderpass = value; OnPropertyChanged(); } } }

        private string? _Seriesatdevolucion;
        [XmlAttribute]
        public string? Seriesatdevolucion { get => _Seriesatdevolucion; set { if (RaiseAcceptPendingChange(value, _Seriesatdevolucion)) { _Seriesatdevolucion = value; OnPropertyChanged(); } } }

        private BoolCN? _Cambiarprecioxuempaque;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cambiarprecioxuempaque { get => _Cambiarprecioxuempaque?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cambiarprecioxuempaque)) { _Cambiarprecioxuempaque = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cambiarprecioxpzacaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cambiarprecioxpzacaja { get => _Cambiarprecioxpzacaja?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cambiarprecioxpzacaja)) { _Cambiarprecioxpzacaja = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Prefijobascula;
        [XmlAttribute]
        public string? Prefijobascula { get => _Prefijobascula; set { if (RaiseAcceptPendingChange(value, _Prefijobascula)) { _Prefijobascula = value; OnPropertyChanged(); } } }

        private short? _Longprodbascula;
        [XmlAttribute]
        public short? Longprodbascula { get => _Longprodbascula; set { if (RaiseAcceptPendingChange(value, _Longprodbascula)) { _Longprodbascula = value; OnPropertyChanged(); } } }

        private short? _Longpesobascula;
        [XmlAttribute]
        public short? Longpesobascula { get => _Longpesobascula; set { if (RaiseAcceptPendingChange(value, _Longpesobascula)) { _Longpesobascula = value; OnPropertyChanged(); } } }

        private long? _Listaprecioxuempaque;
        [XmlAttribute]
        public long? Listaprecioxuempaque { get => _Listaprecioxuempaque; set { if (RaiseAcceptPendingChange(value, _Listaprecioxuempaque)) { _Listaprecioxuempaque = value; OnPropertyChanged(); } } }

        private string? _Listaprecioxuempaque_Clave;
        [XmlAttribute]
        public string? Listaprecioxuempaque_Clave { get => _Listaprecioxuempaque_Clave; set { if (RaiseAcceptPendingChange(value, _Listaprecioxuempaque_Clave)) { _Listaprecioxuempaque_Clave = value; OnPropertyChanged(); } } }

        private string? _Listaprecioxuempaque_Nombre;
        [XmlAttribute]
        public string? Listaprecioxuempaque_Nombre { get => _Listaprecioxuempaque_Nombre; set { if (RaiseAcceptPendingChange(value, _Listaprecioxuempaque_Nombre)) { _Listaprecioxuempaque_Nombre = value; OnPropertyChanged(); } } }

        private long? _Listaprecioxpzacaja;
        [XmlAttribute]
        public long? Listaprecioxpzacaja { get => _Listaprecioxpzacaja; set { if (RaiseAcceptPendingChange(value, _Listaprecioxpzacaja)) { _Listaprecioxpzacaja = value; OnPropertyChanged(); } } }

        private string? _Listaprecioxpzacaja_Clave;
        [XmlAttribute]
        public string? Listaprecioxpzacaja_Clave { get => _Listaprecioxpzacaja_Clave; set { if (RaiseAcceptPendingChange(value, _Listaprecioxpzacaja_Clave)) { _Listaprecioxpzacaja_Clave = value; OnPropertyChanged(); } } }

        private string? _Listaprecioxpzacaja_Nombre;
        [XmlAttribute]
        public string? Listaprecioxpzacaja_Nombre { get => _Listaprecioxpzacaja_Nombre; set { if (RaiseAcceptPendingChange(value, _Listaprecioxpzacaja_Nombre)) { _Listaprecioxpzacaja_Nombre = value; OnPropertyChanged(); } } }

        private long? _Listaprecioinimayo;
        [XmlAttribute]
        public long? Listaprecioinimayo { get => _Listaprecioinimayo; set { if (RaiseAcceptPendingChange(value, _Listaprecioinimayo)) { _Listaprecioinimayo = value; OnPropertyChanged(); } } }

        private string? _Listaprecioinimayo_Clave;
        [XmlAttribute]
        public string? Listaprecioinimayo_Clave { get => _Listaprecioinimayo_Clave; set { if (RaiseAcceptPendingChange(value, _Listaprecioinimayo_Clave)) { _Listaprecioinimayo_Clave = value; OnPropertyChanged(); } } }

        private string? _Listaprecioinimayo_Nombre;
        [XmlAttribute]
        public string? Listaprecioinimayo_Nombre { get => _Listaprecioinimayo_Nombre; set { if (RaiseAcceptPendingChange(value, _Listaprecioinimayo_Nombre)) { _Listaprecioinimayo_Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Hayvendedorpiso;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hayvendedorpiso { get => _Hayvendedorpiso?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hayvendedorpiso)) { _Hayvendedorpiso = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Envioautomaticoexistencias;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Envioautomaticoexistencias { get => _Envioautomaticoexistencias?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Envioautomaticoexistencias)) { _Envioautomaticoexistencias = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Monederomontominimo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Monederomontominimo { get => _Monederomontominimo?? 0; set { if (RaiseAcceptPendingChange(value, _Monederomontominimo)) { _Monederomontominimo = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Monederoaplicar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Monederoaplicar { get => _Monederoaplicar?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Monederoaplicar)) { _Monederoaplicar = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Monederocaducidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Monederocaducidad { get => _Monederocaducidad?? 0; set { if (RaiseAcceptPendingChange(value, _Monederocaducidad)) { _Monederocaducidad = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Imprimirnumeropiezas;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Imprimirnumeropiezas { get => _Imprimirnumeropiezas?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Imprimirnumeropiezas)) { _Imprimirnumeropiezas = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Pacnombre;
        [XmlAttribute]
        public string? Pacnombre { get => _Pacnombre; set { if (RaiseAcceptPendingChange(value, _Pacnombre)) { _Pacnombre = value; OnPropertyChanged(); } } }

        private string? _Pacusuario;
        [XmlAttribute]
        public string? Pacusuario { get => _Pacusuario; set { if (RaiseAcceptPendingChange(value, _Pacusuario)) { _Pacusuario = value; OnPropertyChanged(); } } }

        private BoolCN? _Cortepormail;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cortepormail { get => _Cortepormail?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cortepormail)) { _Cortepormail = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutareportes;
        [XmlAttribute]
        public string? Rutareportes { get => _Rutareportes; set { if (RaiseAcceptPendingChange(value, _Rutareportes)) { _Rutareportes = value; OnPropertyChanged(); } } }

        private int? _Doblecopiacredito;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Doblecopiacredito { get => _Doblecopiacredito?? 0; set { if (RaiseAcceptPendingChange(value, _Doblecopiacredito)) { _Doblecopiacredito = value?? 0; OnPropertyChanged(); } } }

        private int? _Doblecopiatraslado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Doblecopiatraslado { get => _Doblecopiatraslado?? 0; set { if (RaiseAcceptPendingChange(value, _Doblecopiatraslado)) { _Doblecopiatraslado = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Camposcustomalimportar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Camposcustomalimportar { get => _Camposcustomalimportar?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Camposcustomalimportar)) { _Camposcustomalimportar = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Recibolargoconfactura;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Recibolargoconfactura { get => _Recibolargoconfactura?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Recibolargoconfactura)) { _Recibolargoconfactura = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Recibolargoprinter;
        [XmlAttribute]
        public string? Recibolargoprinter { get => _Recibolargoprinter; set { if (RaiseAcceptPendingChange(value, _Recibolargoprinter)) { _Recibolargoprinter = value; OnPropertyChanged(); } } }

        private BoolCN? _Recibolargopreview;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Recibolargopreview { get => _Recibolargopreview?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Recibolargopreview)) { _Recibolargopreview = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarrazonpreciomenor;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preguntarrazonpreciomenor { get => _Preguntarrazonpreciomenor?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preguntarrazonpreciomenor)) { _Preguntarrazonpreciomenor = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Preguntardatosentrega;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preguntardatosentrega { get => _Preguntardatosentrega?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preguntardatosentrega)) { _Preguntardatosentrega = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Fiscalregimen;
        [XmlAttribute]
        public string? Fiscalregimen { get => _Fiscalregimen; set { if (RaiseAcceptPendingChange(value, _Fiscalregimen)) { _Fiscalregimen = value; OnPropertyChanged(); } } }

        private int? _Cortacaducidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cortacaducidad { get => _Cortacaducidad?? 0; set { if (RaiseAcceptPendingChange(value, _Cortacaducidad)) { _Cortacaducidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Retencioniva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Retencioniva { get => _Retencioniva?? 0; set { if (RaiseAcceptPendingChange(value, _Retencioniva)) { _Retencioniva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Retencionisr;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Retencionisr { get => _Retencionisr?? 0; set { if (RaiseAcceptPendingChange(value, _Retencionisr)) { _Retencionisr = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Arrendatario;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Arrendatario { get => _Arrendatario?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Arrendatario)) { _Arrendatario = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutaimagenesproducto;
        [XmlAttribute]
        public string? Rutaimagenesproducto { get => _Rutaimagenesproducto; set { if (RaiseAcceptPendingChange(value, _Rutaimagenesproducto)) { _Rutaimagenesproducto = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarimagenenventa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrarimagenenventa { get => _Mostrarimagenenventa?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrarimagenenventa)) { _Mostrarimagenenventa = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarmontoahorro;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrarmontoahorro { get => _Mostrarmontoahorro?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrarmontoahorro)) { _Mostrarmontoahorro = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Smtpssl;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Smtpssl { get => _Smtpssl?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Smtpssl)) { _Smtpssl = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Mostrardescuentofactura;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrardescuentofactura { get => _Mostrardescuentofactura?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrardescuentofactura)) { _Mostrardescuentofactura = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Exportcatalogoaux;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Exportcatalogoaux { get => _Exportcatalogoaux?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Exportcatalogoaux)) { _Exportcatalogoaux = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Uiventaconcantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Uiventaconcantidad { get => _Uiventaconcantidad?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Uiventaconcantidad)) { _Uiventaconcantidad = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Fact_elect_folder;
        [XmlAttribute]
        public string? Fact_elect_folder { get => _Fact_elect_folder; set { if (RaiseAcceptPendingChange(value, _Fact_elect_folder)) { _Fact_elect_folder = value; OnPropertyChanged(); } } }

        private string? _Pedidos_folder;
        [XmlAttribute]
        public string? Pedidos_folder { get => _Pedidos_folder; set { if (RaiseAcceptPendingChange(value, _Pedidos_folder)) { _Pedidos_folder = value; OnPropertyChanged(); } } }

        private string? _Prefijocliente;
        [XmlAttribute]
        public string? Prefijocliente { get => _Prefijocliente; set { if (RaiseAcceptPendingChange(value, _Prefijocliente)) { _Prefijocliente = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechainiciopedido;
        [XmlAttribute]
        public DateTimeOffset? Fechainiciopedido { get => _Fechainiciopedido; set { if (RaiseAcceptPendingChange(value, _Fechainiciopedido)) { _Fechainiciopedido = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarpzacajaenfactura;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrarpzacajaenfactura { get => _Mostrarpzacajaenfactura?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrarpzacajaenfactura)) { _Mostrarpzacajaenfactura = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Desgloseieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Desgloseieps { get => _Desgloseieps?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Desgloseieps)) { _Desgloseieps = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Cuentaieps;
        [XmlAttribute]
        public string? Cuentaieps { get => _Cuentaieps; set { if (RaiseAcceptPendingChange(value, _Cuentaieps)) { _Cuentaieps = value; OnPropertyChanged(); } } }

        private BoolCN? _Dividir_rem_fact;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Dividir_rem_fact { get => _Dividir_rem_fact?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Dividir_rem_fact)) { _Dividir_rem_fact = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Webservice;
        [XmlAttribute]
        public string? Webservice { get => _Webservice; set { if (RaiseAcceptPendingChange(value, _Webservice)) { _Webservice = value; OnPropertyChanged(); } } }

        private decimal? _Minutilidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Minutilidad { get => _Minutilidad?? 0; set { if (RaiseAcceptPendingChange(value, _Minutilidad)) { _Minutilidad = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Manejasuperlistaprecio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejasuperlistaprecio { get => _Manejasuperlistaprecio?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejasuperlistaprecio)) { _Manejasuperlistaprecio = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Manejaalmacen;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejaalmacen { get => _Manejaalmacen?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejaalmacen)) { _Manejaalmacen = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Tipodescuentoprodid;
        [XmlAttribute]
        public long? Tipodescuentoprodid { get => _Tipodescuentoprodid; set { if (RaiseAcceptPendingChange(value, _Tipodescuentoprodid)) { _Tipodescuentoprodid = value; OnPropertyChanged(); } } }

        private string? _TipodescuentoprodClave;
        [XmlAttribute]
        public string? TipodescuentoprodClave { get => _TipodescuentoprodClave; set { if (RaiseAcceptPendingChange(value, _TipodescuentoprodClave)) { _TipodescuentoprodClave = value; OnPropertyChanged(); } } }

        private string? _TipodescuentoprodNombre;
        [XmlAttribute]
        public string? TipodescuentoprodNombre { get => _TipodescuentoprodNombre; set { if (RaiseAcceptPendingChange(value, _TipodescuentoprodNombre)) { _TipodescuentoprodNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejareceta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejareceta { get => _Manejareceta?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejareceta)) { _Manejareceta = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Autocompprod;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Autocompprod { get => _Autocompprod?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Autocompprod)) { _Autocompprod = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Lastchangeproddesc;
        [XmlAttribute]
        public DateTimeOffset? Lastchangeproddesc { get => _Lastchangeproddesc; set { if (RaiseAcceptPendingChange(value, _Lastchangeproddesc)) { _Lastchangeproddesc = value; OnPropertyChanged(); } } }

        private long? _Tipoutilidadid;
        [XmlAttribute]
        public long? Tipoutilidadid { get => _Tipoutilidadid; set { if (RaiseAcceptPendingChange(value, _Tipoutilidadid)) { _Tipoutilidadid = value; OnPropertyChanged(); } } }

        private string? _TipoutilidadClave;
        [XmlAttribute]
        public string? TipoutilidadClave { get => _TipoutilidadClave; set { if (RaiseAcceptPendingChange(value, _TipoutilidadClave)) { _TipoutilidadClave = value; OnPropertyChanged(); } } }

        private string? _TipoutilidadNombre;
        [XmlAttribute]
        public string? TipoutilidadNombre { get => _TipoutilidadNombre; set { if (RaiseAcceptPendingChange(value, _TipoutilidadNombre)) { _TipoutilidadNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejaquota;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejaquota { get => _Manejaquota?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejaquota)) { _Manejaquota = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Touch;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Touch { get => _Touch?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Touch)) { _Touch = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Esvendedormovil;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esvendedormovil { get => _Esvendedormovil?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esvendedormovil)) { _Esvendedormovil = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cajasbotellas;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cajasbotellas { get => _Cajasbotellas?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cajasbotellas)) { _Cajasbotellas = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Precionetoenpv;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Precionetoenpv { get => _Precionetoenpv?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Precionetoenpv)) { _Precionetoenpv = value?? BoolCN.N; OnPropertyChanged(); } } }

        private TipoSyncMovil? _Tiposyncmovil;
        [XmlAttribute]
        public TipoSyncMovil? Tiposyncmovil { get => _Tiposyncmovil; set { if (RaiseAcceptPendingChange(value, _Tiposyncmovil)) { _Tiposyncmovil = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarflash;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrarflash { get => _Mostrarflash?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrarflash)) { _Mostrarflash = value?? BoolCN.N; OnPropertyChanged(); } } }

        private OrdenImpresion ? _Ordenimpresion;
        [XmlAttribute]
        public OrdenImpresion ? Ordenimpresion { get => _Ordenimpresion; set { if (RaiseAcceptPendingChange(value, _Ordenimpresion)) { _Ordenimpresion = value; OnPropertyChanged(); } } }

        private BoolCN? _Autocompcliente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Autocompcliente { get => _Autocompcliente?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Autocompcliente)) { _Autocompcliente = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Lastchangeclientenombre;
        [XmlAttribute]
        public DateTimeOffset? Lastchangeclientenombre { get => _Lastchangeclientenombre; set { if (RaiseAcceptPendingChange(value, _Lastchangeclientenombre)) { _Lastchangeclientenombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Precioxcajaenpv;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Precioxcajaenpv { get => _Precioxcajaenpv?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Precioxcajaenpv)) { _Precioxcajaenpv = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Localftphost;
        [XmlAttribute]
        public string? Localftphost { get => _Localftphost; set { if (RaiseAcceptPendingChange(value, _Localftphost)) { _Localftphost = value; OnPropertyChanged(); } } }

        private string? _Localwebservice;
        [XmlAttribute]
        public string? Localwebservice { get => _Localwebservice; set { if (RaiseAcceptPendingChange(value, _Localwebservice)) { _Localwebservice = value; OnPropertyChanged(); } } }

        private BoolCN? _Usarconexionlocal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Usarconexionlocal { get => _Usarconexionlocal?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Usarconexionlocal)) { _Usarconexionlocal = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Movillastpreciodate;
        [XmlAttribute]
        public DateTimeOffset? Movillastpreciodate { get => _Movillastpreciodate; set { if (RaiseAcceptPendingChange(value, _Movillastpreciodate)) { _Movillastpreciodate = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Lastchangeprecioprod;
        [XmlAttribute]
        public DateTimeOffset? Lastchangeprecioprod { get => _Lastchangeprecioprod; set { if (RaiseAcceptPendingChange(value, _Lastchangeprecioprod)) { _Lastchangeprecioprod = value; OnPropertyChanged(); } } }

        private int? _Movilcierrecobranza;
        [XmlAttribute]
        public int? Movilcierrecobranza { get => _Movilcierrecobranza; set { if (RaiseAcceptPendingChange(value, _Movilcierrecobranza)) { _Movilcierrecobranza = value; OnPropertyChanged(); } } }

        private int? _Movilcierreventa;
        [XmlAttribute]
        public int? Movilcierreventa { get => _Movilcierreventa; set { if (RaiseAcceptPendingChange(value, _Movilcierreventa)) { _Movilcierreventa = value; OnPropertyChanged(); } } }

        private string? _Mailtoinventario;
        [XmlAttribute]
        public string? Mailtoinventario { get => _Mailtoinventario; set { if (RaiseAcceptPendingChange(value, _Mailtoinventario)) { _Mailtoinventario = value; OnPropertyChanged(); } } }

        private string? _Rutarespaldoszip;
        [XmlAttribute]
        public string? Rutarespaldoszip { get => _Rutarespaldoszip; set { if (RaiseAcceptPendingChange(value, _Rutarespaldoszip)) { _Rutarespaldoszip = value; OnPropertyChanged(); } } }

        private ConfigPantalla? _Screenconfig;
        [XmlAttribute]
        public ConfigPantalla? Screenconfig { get => _Screenconfig; set { if (RaiseAcceptPendingChange(value, _Screenconfig)) { _Screenconfig = value; OnPropertyChanged(); } } }

        private BoolCN? _Promoenticket;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Promoenticket { get => _Promoenticket?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Promoenticket)) { _Promoenticket = value?? BoolCN.N; OnPropertyChanged(); } } }

        private LetraEnTicket? _Tamanoletraticket;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public LetraEnTicket? Tamanoletraticket { get => _Tamanoletraticket?? LetraEnTicket.Normal; set { if (RaiseAcceptPendingChange(value, _Tamanoletraticket)) { _Tamanoletraticket = value?? LetraEnTicket.Normal; OnPropertyChanged(); } } }

        private BoolCN? _Manejakits;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejakits { get => _Manejakits?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejakits)) { _Manejakits = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Campoimpocostorepoid;
        [XmlAttribute]
        public long? Campoimpocostorepoid { get => _Campoimpocostorepoid; set { if (RaiseAcceptPendingChange(value, _Campoimpocostorepoid)) { _Campoimpocostorepoid = value; OnPropertyChanged(); } } }

        private string? _CampoimpocostorepoClave;
        [XmlAttribute]
        public string? CampoimpocostorepoClave { get => _CampoimpocostorepoClave; set { if (RaiseAcceptPendingChange(value, _CampoimpocostorepoClave)) { _CampoimpocostorepoClave = value; OnPropertyChanged(); } } }

        private string? _CampoimpocostorepoNombre;
        [XmlAttribute]
        public string? CampoimpocostorepoNombre { get => _CampoimpocostorepoNombre; set { if (RaiseAcceptPendingChange(value, _CampoimpocostorepoNombre)) { _CampoimpocostorepoNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Rebajaespecial;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Rebajaespecial { get => _Rebajaespecial?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Rebajaespecial)) { _Rebajaespecial = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habilitarrepl;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habilitarrepl { get => _Habilitarrepl?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habilitarrepl)) { _Habilitarrepl = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Bdlocalrepl;
        [XmlAttribute]
        public string? Bdlocalrepl { get => _Bdlocalrepl; set { if (RaiseAcceptPendingChange(value, _Bdlocalrepl)) { _Bdlocalrepl = value; OnPropertyChanged(); } } }

        private BoolCN? _Pendmovilantesventa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Pendmovilantesventa { get => _Pendmovilantesventa?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Pendmovilantesventa)) { _Pendmovilantesventa = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Preciosmovilantesventa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preciosmovilantesventa { get => _Preciosmovilantesventa?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preciosmovilantesventa)) { _Preciosmovilantesventa = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Recalcularcambiocliente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Recalcularcambiocliente { get => _Recalcularcambiocliente?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Recalcularcambiocliente)) { _Recalcularcambiocliente = value?? BoolCN.N; OnPropertyChanged(); } } }

        private TipoConexionMovil? _Tipovendedormovil;
        [XmlAttribute]
        public TipoConexionMovil? Tipovendedormovil { get => _Tipovendedormovil; set { if (RaiseAcceptPendingChange(value, _Tipovendedormovil)) { _Tipovendedormovil = value; OnPropertyChanged(); } } }

        private long? _Vendedormovilid;
        [XmlAttribute]
        public long? Vendedormovilid { get => _Vendedormovilid; set { if (RaiseAcceptPendingChange(value, _Vendedormovilid)) { _Vendedormovilid = value; OnPropertyChanged(); } } }

        private string? _VendedormovilClave;
        [XmlAttribute]
        public string? VendedormovilClave { get => _VendedormovilClave; set { if (RaiseAcceptPendingChange(value, _VendedormovilClave)) { _VendedormovilClave = value; OnPropertyChanged(); } } }

        private string? _VendedormovilNombre;
        [XmlAttribute]
        public string? VendedormovilNombre { get => _VendedormovilNombre; set { if (RaiseAcceptPendingChange(value, _VendedormovilNombre)) { _VendedormovilNombre = value; OnPropertyChanged(); } } }

        private string? _Bdserverws;
        [XmlAttribute]
        public string? Bdserverws { get => _Bdserverws; set { if (RaiseAcceptPendingChange(value, _Bdserverws)) { _Bdserverws = value; OnPropertyChanged(); } } }

        private string? _Bdmatrizmovil;
        [XmlAttribute]
        public string? Bdmatrizmovil { get => _Bdmatrizmovil; set { if (RaiseAcceptPendingChange(value, _Bdmatrizmovil)) { _Bdmatrizmovil = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Prodcambioparamovil;
        [XmlAttribute]
        public DateTimeOffset? Prodcambioparamovil { get => _Prodcambioparamovil; set { if (RaiseAcceptPendingChange(value, _Prodcambioparamovil)) { _Prodcambioparamovil = value; OnPropertyChanged(); } } }

        private BoolCN? _Movilprocesosurtido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movilprocesosurtido { get => _Movilprocesosurtido?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movilprocesosurtido)) { _Movilprocesosurtido = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Movilverificarventa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movilverificarventa { get => _Movilverificarventa?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movilverificarventa)) { _Movilverificarventa = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Pendmaxdias;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Pendmaxdias { get => _Pendmaxdias?? 0; set { if (RaiseAcceptPendingChange(value, _Pendmaxdias)) { _Pendmaxdias = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Reqautcancelarcoti;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Reqautcancelarcoti { get => _Reqautcancelarcoti?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Reqautcancelarcoti)) { _Reqautcancelarcoti = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Reqautelimdetallecoti;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Reqautelimdetallecoti { get => _Reqautelimdetallecoti?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Reqautelimdetallecoti)) { _Reqautelimdetallecoti = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Abrircajonalfincorte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Abrircajonalfincorte { get => _Abrircajonalfincorte?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Abrircajonalfincorte)) { _Abrircajonalfincorte = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habsurtidopostpuesto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habsurtidopostpuesto { get => _Habsurtidopostpuesto?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habsurtidopostpuesto)) { _Habsurtidopostpuesto = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Clienteconsolidadoid;
        [XmlAttribute]
        public long? Clienteconsolidadoid { get => _Clienteconsolidadoid; set { if (RaiseAcceptPendingChange(value, _Clienteconsolidadoid)) { _Clienteconsolidadoid = value; OnPropertyChanged(); } } }

        private string? _ClienteconsolidadoClave;
        [XmlAttribute]
        public string? ClienteconsolidadoClave { get => _ClienteconsolidadoClave; set { if (RaiseAcceptPendingChange(value, _ClienteconsolidadoClave)) { _ClienteconsolidadoClave = value; OnPropertyChanged(); } } }

        private string? _ClienteconsolidadoNombre;
        [XmlAttribute]
        public string? ClienteconsolidadoNombre { get => _ClienteconsolidadoNombre; set { if (RaiseAcceptPendingChange(value, _ClienteconsolidadoNombre)) { _ClienteconsolidadoNombre = value; OnPropertyChanged(); } } }

        private string? _Rutareportessistema;
        [XmlAttribute]
        public string? Rutareportessistema { get => _Rutareportessistema; set { if (RaiseAcceptPendingChange(value, _Rutareportessistema)) { _Rutareportessistema = value; OnPropertyChanged(); } } }

        private BoolCN? _Doblecopiaremision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Doblecopiaremision { get => _Doblecopiaremision?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Doblecopiaremision)) { _Doblecopiaremision = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Reimpresionesconmarca;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Reimpresionesconmarca { get => _Reimpresionesconmarca?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Reimpresionesconmarca)) { _Reimpresionesconmarca = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habtotalizados;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habtotalizados { get => _Habtotalizados?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habtotalizados)) { _Habtotalizados = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Multipletipovale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Multipletipovale { get => _Multipletipovale?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Multipletipovale)) { _Multipletipovale = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Descuentotipo1texto;
        [XmlAttribute]
        public string? Descuentotipo1texto { get => _Descuentotipo1texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo1texto)) { _Descuentotipo1texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo1porc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentotipo1porc { get => _Descuentotipo1porc?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentotipo1porc)) { _Descuentotipo1porc = value?? 0; OnPropertyChanged(); } } }

        private string? _Descuentotipo2texto;
        [XmlAttribute]
        public string? Descuentotipo2texto { get => _Descuentotipo2texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo2texto)) { _Descuentotipo2texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo2porc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentotipo2porc { get => _Descuentotipo2porc?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentotipo2porc)) { _Descuentotipo2porc = value?? 0; OnPropertyChanged(); } } }

        private string? _Descuentotipo3texto;
        [XmlAttribute]
        public string? Descuentotipo3texto { get => _Descuentotipo3texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo3texto)) { _Descuentotipo3texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo3porc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentotipo3porc { get => _Descuentotipo3porc?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentotipo3porc)) { _Descuentotipo3porc = value?? 0; OnPropertyChanged(); } } }

        private string? _Descuentotipo4texto;
        [XmlAttribute]
        public string? Descuentotipo4texto { get => _Descuentotipo4texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo4texto)) { _Descuentotipo4texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo4porc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentotipo4porc { get => _Descuentotipo4porc?? 0; set { if (RaiseAcceptPendingChange(value, _Descuentotipo4porc)) { _Descuentotipo4porc = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Habilitarlog;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habilitarlog { get => _Habilitarlog?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habilitarlog)) { _Habilitarlog = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutarespaldo;
        [XmlAttribute]
        public string? Rutarespaldo { get => _Rutarespaldo; set { if (RaiseAcceptPendingChange(value, _Rutarespaldo)) { _Rutarespaldo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharespaldo;
        [XmlAttribute]
        public DateTimeOffset? Fecharespaldo { get => _Fecharespaldo; set { if (RaiseAcceptPendingChange(value, _Fecharespaldo)) { _Fecharespaldo = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejarretirodecaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejarretirodecaja { get => _Manejarretirodecaja?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejarretirodecaja)) { _Manejarretirodecaja = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Montoretirocaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Montoretirocaja { get => _Montoretirocaja?? 0; set { if (RaiseAcceptPendingChange(value, _Montoretirocaja)) { _Montoretirocaja = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Aplicarmayoreoporlinea;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Aplicarmayoreoporlinea { get => _Aplicarmayoreoporlinea?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Aplicarmayoreoporlinea)) { _Aplicarmayoreoporlinea = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Comisionportarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comisionportarjeta { get => _Comisionportarjeta?? 0; set { if (RaiseAcceptPendingChange(value, _Comisionportarjeta)) { _Comisionportarjeta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Piezasigualesmediomayoreo;
        [XmlAttribute]
        public decimal? Piezasigualesmediomayoreo { get => _Piezasigualesmediomayoreo; set { if (RaiseAcceptPendingChange(value, _Piezasigualesmediomayoreo)) { _Piezasigualesmediomayoreo = value; OnPropertyChanged(); } } }

        private decimal? _Piezasdifmediomayoreo;
        [XmlAttribute]
        public decimal? Piezasdifmediomayoreo { get => _Piezasdifmediomayoreo; set { if (RaiseAcceptPendingChange(value, _Piezasdifmediomayoreo)) { _Piezasdifmediomayoreo = value; OnPropertyChanged(); } } }

        private decimal? _Piezasigualesmayoreo;
        [XmlAttribute]
        public decimal? Piezasigualesmayoreo { get => _Piezasigualesmayoreo; set { if (RaiseAcceptPendingChange(value, _Piezasigualesmayoreo)) { _Piezasigualesmayoreo = value; OnPropertyChanged(); } } }

        private decimal? _Piezasdifmayoreo;
        [XmlAttribute]
        public decimal? Piezasdifmayoreo { get => _Piezasdifmayoreo; set { if (RaiseAcceptPendingChange(value, _Piezasdifmayoreo)) { _Piezasdifmayoreo = value; OnPropertyChanged(); } } }

        private decimal? _Comisiontarjetaempresa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comisiontarjetaempresa { get => _Comisiontarjetaempresa?? 0; set { if (RaiseAcceptPendingChange(value, _Comisiontarjetaempresa)) { _Comisiontarjetaempresa = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ivacomisiontarjetaempresa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ivacomisiontarjetaempresa { get => _Ivacomisiontarjetaempresa?? 0; set { if (RaiseAcceptPendingChange(value, _Ivacomisiontarjetaempresa)) { _Ivacomisiontarjetaempresa = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Preguntacancelacotizacion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preguntacancelacotizacion { get => _Preguntacancelacotizacion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preguntacancelacotizacion)) { _Preguntacancelacotizacion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habverificacioncxc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habverificacioncxc { get => _Habverificacioncxc?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habverificacioncxc)) { _Habverificacioncxc = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Mailejecutivo;
        [XmlAttribute]
        public string? Mailejecutivo { get => _Mailejecutivo; set { if (RaiseAcceptPendingChange(value, _Mailejecutivo)) { _Mailejecutivo = value; OnPropertyChanged(); } } }

        private BoolCN? _Ventasxcorteemail;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ventasxcorteemail { get => _Ventasxcorteemail?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ventasxcorteemail)) { _Ventasxcorteemail = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habventasafuturo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habventasafuturo { get => _Habventasafuturo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habventasafuturo)) { _Habventasafuturo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Serviciosemida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Serviciosemida { get => _Serviciosemida?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Serviciosemida)) { _Serviciosemida = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaactualizacionemida;
        [XmlAttribute]
        public DateTimeOffset? Fechaactualizacionemida { get => _Fechaactualizacionemida; set { if (RaiseAcceptPendingChange(value, _Fechaactualizacionemida)) { _Fechaactualizacionemida = value; OnPropertyChanged(); } } }

        private FormatTicketCorto? _Formatoticketcortoid;
        [XmlAttribute]
        public FormatTicketCorto? Formatoticketcortoid { get => _Formatoticketcortoid; set { if (RaiseAcceptPendingChange(value, _Formatoticketcortoid)) { _Formatoticketcortoid = value; OnPropertyChanged(); } } }

        private string? _Seriesatabono;
        [XmlAttribute]
        public string? Seriesatabono { get => _Seriesatabono; set { if (RaiseAcceptPendingChange(value, _Seriesatabono)) { _Seriesatabono = value; OnPropertyChanged(); } } }

        private BoolCN? _Habimpresioncortecajero;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habimpresioncortecajero { get => _Habimpresioncortecajero?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habimpresioncortecajero)) { _Habimpresioncortecajero = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habtrasladoporautorizacion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habtrasladoporautorizacion { get => _Habtrasladoporautorizacion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habtrasladoporautorizacion)) { _Habtrasladoporautorizacion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habventasmostrador;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habventasmostrador { get => _Habventasmostrador?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habventasmostrador)) { _Habventasmostrador = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Timeoutpindistsale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Timeoutpindistsale { get => _Timeoutpindistsale?? 0; set { if (RaiseAcceptPendingChange(value, _Timeoutpindistsale)) { _Timeoutpindistsale = value?? 0; OnPropertyChanged(); } } }

        private int? _Timeoutlookup;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Timeoutlookup { get => _Timeoutlookup?? 0; set { if (RaiseAcceptPendingChange(value, _Timeoutlookup)) { _Timeoutlookup = value?? 0; OnPropertyChanged(); } } }

        private string? _Rutaarchivosadjuntos;
        [XmlAttribute]
        public string? Rutaarchivosadjuntos { get => _Rutaarchivosadjuntos; set { if (RaiseAcceptPendingChange(value, _Rutaarchivosadjuntos)) { _Rutaarchivosadjuntos = value; OnPropertyChanged(); } } }

        private int? _Timeoutpindistsaleserv;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Timeoutpindistsaleserv { get => _Timeoutpindistsaleserv?? 0; set { if (RaiseAcceptPendingChange(value, _Timeoutpindistsaleserv)) { _Timeoutpindistsaleserv = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Habpagoservemida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habpagoservemida { get => _Habpagoservemida?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habpagoservemida)) { _Habpagoservemida = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaactualizacionemidaserv;
        [XmlAttribute]
        public DateTimeOffset? Fechaactualizacionemidaserv { get => _Fechaactualizacionemidaserv; set { if (RaiseAcceptPendingChange(value, _Fechaactualizacionemidaserv)) { _Fechaactualizacionemidaserv = value; OnPropertyChanged(); } } }

        private BoolCN? _Habpromoxmontomin;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habpromoxmontomin { get => _Habpromoxmontomin?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habpromoxmontomin)) { _Habpromoxmontomin = value?? BoolCN.N; OnPropertyChanged(); } } }

        private FormatoFactura? _Formatofactelect;
        [XmlAttribute]
        public FormatoFactura? Formatofactelect { get => _Formatofactelect; set { if (RaiseAcceptPendingChange(value, _Formatofactelect)) { _Formatofactelect = value; OnPropertyChanged(); } } }

        private decimal? _Montomaxsaldomenor;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Montomaxsaldomenor { get => _Montomaxsaldomenor?? 0; set { if (RaiseAcceptPendingChange(value, _Montomaxsaldomenor)) { _Montomaxsaldomenor = value?? 0; OnPropertyChanged(); } } }

        private long? _Emidarecargalineaid;
        [XmlAttribute]
        public long? Emidarecargalineaid { get => _Emidarecargalineaid; set { if (RaiseAcceptPendingChange(value, _Emidarecargalineaid)) { _Emidarecargalineaid = value; OnPropertyChanged(); } } }

        private string? _EmidarecargalineaClave;
        [XmlAttribute]
        public string? EmidarecargalineaClave { get => _EmidarecargalineaClave; set { if (RaiseAcceptPendingChange(value, _EmidarecargalineaClave)) { _EmidarecargalineaClave = value; OnPropertyChanged(); } } }

        private string? _EmidarecargalineaNombre;
        [XmlAttribute]
        public string? EmidarecargalineaNombre { get => _EmidarecargalineaNombre; set { if (RaiseAcceptPendingChange(value, _EmidarecargalineaNombre)) { _EmidarecargalineaNombre = value; OnPropertyChanged(); } } }

        private long? _Emidarecargamarcaid;
        [XmlAttribute]
        public long? Emidarecargamarcaid { get => _Emidarecargamarcaid; set { if (RaiseAcceptPendingChange(value, _Emidarecargamarcaid)) { _Emidarecargamarcaid = value; OnPropertyChanged(); } } }

        private string? _EmidarecargamarcaClave;
        [XmlAttribute]
        public string? EmidarecargamarcaClave { get => _EmidarecargamarcaClave; set { if (RaiseAcceptPendingChange(value, _EmidarecargamarcaClave)) { _EmidarecargamarcaClave = value; OnPropertyChanged(); } } }

        private string? _EmidarecargamarcaNombre;
        [XmlAttribute]
        public string? EmidarecargamarcaNombre { get => _EmidarecargamarcaNombre; set { if (RaiseAcceptPendingChange(value, _EmidarecargamarcaNombre)) { _EmidarecargamarcaNombre = value; OnPropertyChanged(); } } }

        private long? _Emidarecargaproveedorid;
        [XmlAttribute]
        public long? Emidarecargaproveedorid { get => _Emidarecargaproveedorid; set { if (RaiseAcceptPendingChange(value, _Emidarecargaproveedorid)) { _Emidarecargaproveedorid = value; OnPropertyChanged(); } } }

        private string? _EmidarecargaproveedorClave;
        [XmlAttribute]
        public string? EmidarecargaproveedorClave { get => _EmidarecargaproveedorClave; set { if (RaiseAcceptPendingChange(value, _EmidarecargaproveedorClave)) { _EmidarecargaproveedorClave = value; OnPropertyChanged(); } } }

        private string? _EmidarecargaproveedorNombre;
        [XmlAttribute]
        public string? EmidarecargaproveedorNombre { get => _EmidarecargaproveedorNombre; set { if (RaiseAcceptPendingChange(value, _EmidarecargaproveedorNombre)) { _EmidarecargaproveedorNombre = value; OnPropertyChanged(); } } }

        private long? _Emidaserviciolineaid;
        [XmlAttribute]
        public long? Emidaserviciolineaid { get => _Emidaserviciolineaid; set { if (RaiseAcceptPendingChange(value, _Emidaserviciolineaid)) { _Emidaserviciolineaid = value; OnPropertyChanged(); } } }

        private string? _EmidaserviciolineaClave;
        [XmlAttribute]
        public string? EmidaserviciolineaClave { get => _EmidaserviciolineaClave; set { if (RaiseAcceptPendingChange(value, _EmidaserviciolineaClave)) { _EmidaserviciolineaClave = value; OnPropertyChanged(); } } }

        private string? _EmidaserviciolineaNombre;
        [XmlAttribute]
        public string? EmidaserviciolineaNombre { get => _EmidaserviciolineaNombre; set { if (RaiseAcceptPendingChange(value, _EmidaserviciolineaNombre)) { _EmidaserviciolineaNombre = value; OnPropertyChanged(); } } }

        private long? _Emidaserviciomarcaid;
        [XmlAttribute]
        public long? Emidaserviciomarcaid { get => _Emidaserviciomarcaid; set { if (RaiseAcceptPendingChange(value, _Emidaserviciomarcaid)) { _Emidaserviciomarcaid = value; OnPropertyChanged(); } } }

        private string? _EmidaserviciomarcaClave;
        [XmlAttribute]
        public string? EmidaserviciomarcaClave { get => _EmidaserviciomarcaClave; set { if (RaiseAcceptPendingChange(value, _EmidaserviciomarcaClave)) { _EmidaserviciomarcaClave = value; OnPropertyChanged(); } } }

        private string? _EmidaserviciomarcaNombre;
        [XmlAttribute]
        public string? EmidaserviciomarcaNombre { get => _EmidaserviciomarcaNombre; set { if (RaiseAcceptPendingChange(value, _EmidaserviciomarcaNombre)) { _EmidaserviciomarcaNombre = value; OnPropertyChanged(); } } }

        private long? _Emidaservicioproveedorid;
        [XmlAttribute]
        public long? Emidaservicioproveedorid { get => _Emidaservicioproveedorid; set { if (RaiseAcceptPendingChange(value, _Emidaservicioproveedorid)) { _Emidaservicioproveedorid = value; OnPropertyChanged(); } } }

        private string? _EmidaservicioproveedorClave;
        [XmlAttribute]
        public string? EmidaservicioproveedorClave { get => _EmidaservicioproveedorClave; set { if (RaiseAcceptPendingChange(value, _EmidaservicioproveedorClave)) { _EmidaservicioproveedorClave = value; OnPropertyChanged(); } } }

        private string? _EmidaservicioproveedorNombre;
        [XmlAttribute]
        public string? EmidaservicioproveedorNombre { get => _EmidaservicioproveedorNombre; set { if (RaiseAcceptPendingChange(value, _EmidaservicioproveedorNombre)) { _EmidaservicioproveedorNombre = value; OnPropertyChanged(); } } }

        private decimal? _Emidaporcutilidadrecargas;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Emidaporcutilidadrecargas { get => _Emidaporcutilidadrecargas?? 0; set { if (RaiseAcceptPendingChange(value, _Emidaporcutilidadrecargas)) { _Emidaporcutilidadrecargas = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Emidautilidadpagoservicios;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Emidautilidadpagoservicios { get => _Emidautilidadpagoservicios?? 0; set { if (RaiseAcceptPendingChange(value, _Emidautilidadpagoservicios)) { _Emidautilidadpagoservicios = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Preciosordenados;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preciosordenados { get => _Preciosordenados?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preciosordenados)) { _Preciosordenados = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Decimalesencantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Decimalesencantidad { get => _Decimalesencantidad?? 0; set { if (RaiseAcceptPendingChange(value, _Decimalesencantidad)) { _Decimalesencantidad = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Eanpuederepetirse;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Eanpuederepetirse { get => _Eanpuederepetirse?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Eanpuederepetirse)) { _Eanpuederepetirse = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Bancomerhabpinpad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Bancomerhabpinpad { get => _Bancomerhabpinpad?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Bancomerhabpinpad)) { _Bancomerhabpinpad = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Hab_precioscliente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_precioscliente { get => _Hab_precioscliente?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_precioscliente)) { _Hab_precioscliente = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Cxcvalidartraslados;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Cxcvalidartraslados { get => _Cxcvalidartraslados?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Cxcvalidartraslados)) { _Cxcvalidartraslados = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarsiesacredito;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preguntarsiesacredito { get => _Preguntarsiesacredito?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preguntarsiesacredito)) { _Preguntarsiesacredito = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habmensajeria;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habmensajeria { get => _Habmensajeria?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habmensajeria)) { _Habmensajeria = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Wsmensajeria;
        [XmlAttribute]
        public string? Wsmensajeria { get => _Wsmensajeria; set { if (RaiseAcceptPendingChange(value, _Wsmensajeria)) { _Wsmensajeria = value; OnPropertyChanged(); } } }

        private long? _Ultmensajeid;
        [XmlAttribute]
        public long? Ultmensajeid { get => _Ultmensajeid; set { if (RaiseAcceptPendingChange(value, _Ultmensajeid)) { _Ultmensajeid = value; OnPropertyChanged(); } } }

        private string? _UltmensajeClave;
        [XmlAttribute]
        public string? UltmensajeClave { get => _UltmensajeClave; set { if (RaiseAcceptPendingChange(value, _UltmensajeClave)) { _UltmensajeClave = value; OnPropertyChanged(); } } }

        private string? _UltmensajeNombre;
        [XmlAttribute]
        public string? UltmensajeNombre { get => _UltmensajeNombre; set { if (RaiseAcceptPendingChange(value, _UltmensajeNombre)) { _UltmensajeNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Habdesclineapersona;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habdesclineapersona { get => _Habdesclineapersona?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habdesclineapersona)) { _Habdesclineapersona = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Manejarloteimportacion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejarloteimportacion { get => _Manejarloteimportacion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejarloteimportacion)) { _Manejarloteimportacion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Manejagastosadic;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejagastosadic { get => _Manejagastosadic?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejagastosadic)) { _Manejagastosadic = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Caducidadminima;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Caducidadminima { get => _Caducidadminima?? 0; set { if (RaiseAcceptPendingChange(value, _Caducidadminima)) { _Caducidadminima = value?? 0; OnPropertyChanged(); } } }

        private long? _Precioajustedifinvid;
        [XmlAttribute]
        public long? Precioajustedifinvid { get => _Precioajustedifinvid; set { if (RaiseAcceptPendingChange(value, _Precioajustedifinvid)) { _Precioajustedifinvid = value; OnPropertyChanged(); } } }

        private string? _PrecioajustedifinvClave;
        [XmlAttribute]
        public string? PrecioajustedifinvClave { get => _PrecioajustedifinvClave; set { if (RaiseAcceptPendingChange(value, _PrecioajustedifinvClave)) { _PrecioajustedifinvClave = value; OnPropertyChanged(); } } }

        private string? _PrecioajustedifinvNombre;
        [XmlAttribute]
        public string? PrecioajustedifinvNombre { get => _PrecioajustedifinvNombre; set { if (RaiseAcceptPendingChange(value, _PrecioajustedifinvNombre)) { _PrecioajustedifinvNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Habbotonpagovale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habbotonpagovale { get => _Habbotonpagovale?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habbotonpagovale)) { _Habbotonpagovale = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Unicavisitapordocto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Unicavisitapordocto { get => _Unicavisitapordocto?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Unicavisitapordocto)) { _Unicavisitapordocto = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Plazoxproducto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Plazoxproducto { get => _Plazoxproducto?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Plazoxproducto)) { _Plazoxproducto = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Autocompleteconexisenventa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Autocompleteconexisenventa { get => _Autocompleteconexisenventa?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Autocompleteconexisenventa)) { _Autocompleteconexisenventa = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Ipwebserviceappinv;
        [XmlAttribute]
        public string? Ipwebserviceappinv { get => _Ipwebserviceappinv; set { if (RaiseAcceptPendingChange(value, _Ipwebserviceappinv)) { _Ipwebserviceappinv = value; OnPropertyChanged(); } } }

        private string? _Rutabdappinventaro;
        [XmlAttribute]
        public string? Rutabdappinventaro { get => _Rutabdappinventaro; set { if (RaiseAcceptPendingChange(value, _Rutabdappinventaro)) { _Rutabdappinventaro = value; OnPropertyChanged(); } } }

        private string? _Rutadbfexistenciasuc;
        [XmlAttribute]
        public string? Rutadbfexistenciasuc { get => _Rutadbfexistenciasuc; set { if (RaiseAcceptPendingChange(value, _Rutadbfexistenciasuc)) { _Rutadbfexistenciasuc = value; OnPropertyChanged(); } } }

        private long? _Almacenrecepcionid;
        [XmlAttribute]
        public long? Almacenrecepcionid { get => _Almacenrecepcionid; set { if (RaiseAcceptPendingChange(value, _Almacenrecepcionid)) { _Almacenrecepcionid = value; OnPropertyChanged(); } } }

        private string? _AlmacenrecepcionClave;
        [XmlAttribute]
        public string? AlmacenrecepcionClave { get => _AlmacenrecepcionClave; set { if (RaiseAcceptPendingChange(value, _AlmacenrecepcionClave)) { _AlmacenrecepcionClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenrecepcionNombre;
        [XmlAttribute]
        public string? AlmacenrecepcionNombre { get => _AlmacenrecepcionNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenrecepcionNombre)) { _AlmacenrecepcionNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicarcambiosprecauto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Aplicarcambiosprecauto { get => _Aplicarcambiosprecauto?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Aplicarcambiosprecauto)) { _Aplicarcambiosprecauto = value?? BoolCN.N; OnPropertyChanged(); } } }

        private short? _Numcancelactauto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public short? Numcancelactauto { get => _Numcancelactauto?? 0; set { if (RaiseAcceptPendingChange(value, _Numcancelactauto)) { _Numcancelactauto = value?? 0; OnPropertyChanged(); } } }

        private short? _Numcancelactautousuario;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public short? Numcancelactautousuario { get => _Numcancelactautousuario?? 0; set { if (RaiseAcceptPendingChange(value, _Numcancelactautousuario)) { _Numcancelactautousuario = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Manejacupones;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejacupones { get => _Manejacupones?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejacupones)) { _Manejacupones = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Hab_devoluciontraslado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_devoluciontraslado { get => _Hab_devoluciontraslado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_devoluciontraslado)) { _Hab_devoluciontraslado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Hab_devolucionsurtidosuc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_devolucionsurtidosuc { get => _Hab_devolucionsurtidosuc?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_devolucionsurtidosuc)) { _Hab_devolucionsurtidosuc = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Versionwsexistencias;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Versionwsexistencias { get => _Versionwsexistencias?? 0; set { if (RaiseAcceptPendingChange(value, _Versionwsexistencias)) { _Versionwsexistencias = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Manejaproductospromocion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejaproductospromocion { get => _Manejaproductospromocion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejaproductospromocion)) { _Manejaproductospromocion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Sat_metodopagoid;
        [XmlAttribute]
        public long? Sat_metodopagoid { get => _Sat_metodopagoid; set { if (RaiseAcceptPendingChange(value, _Sat_metodopagoid)) { _Sat_metodopagoid = value; OnPropertyChanged(); } } }

        private string? _Sat_metodopagoClave;
        [XmlAttribute]
        public string? Sat_metodopagoClave { get => _Sat_metodopagoClave; set { if (RaiseAcceptPendingChange(value, _Sat_metodopagoClave)) { _Sat_metodopagoClave = value; OnPropertyChanged(); } } }

        private string? _Sat_metodopagoNombre;
        [XmlAttribute]
        public string? Sat_metodopagoNombre { get => _Sat_metodopagoNombre; set { if (RaiseAcceptPendingChange(value, _Sat_metodopagoNombre)) { _Sat_metodopagoNombre = value; OnPropertyChanged(); } } }

        private long? _Sat_regimenfiscalid;
        [XmlAttribute]
        public long? Sat_regimenfiscalid { get => _Sat_regimenfiscalid; set { if (RaiseAcceptPendingChange(value, _Sat_regimenfiscalid)) { _Sat_regimenfiscalid = value; OnPropertyChanged(); } } }

        private string? _Sat_regimenfiscalClave;
        [XmlAttribute]
        public string? Sat_regimenfiscalClave { get => _Sat_regimenfiscalClave; set { if (RaiseAcceptPendingChange(value, _Sat_regimenfiscalClave)) { _Sat_regimenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _Sat_regimenfiscalNombre;
        [XmlAttribute]
        public string? Sat_regimenfiscalNombre { get => _Sat_regimenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _Sat_regimenfiscalNombre)) { _Sat_regimenfiscalNombre = value; OnPropertyChanged(); } } }

        private FiltroProductoSat? _Tiposeleccioncatalogosat;
        [XmlAttribute]
        public FiltroProductoSat? Tiposeleccioncatalogosat { get => _Tiposeleccioncatalogosat; set { if (RaiseAcceptPendingChange(value, _Tiposeleccioncatalogosat)) { _Tiposeleccioncatalogosat = value; OnPropertyChanged(); } } }

        private BoolCN? _Precionetoengrids;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Precionetoengrids { get => _Precionetoengrids?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Precionetoengrids)) { _Precionetoengrids = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Versioncfdi;
        [XmlAttribute]
        public string? Versioncfdi { get => _Versioncfdi; set { if (RaiseAcceptPendingChange(value, _Versioncfdi)) { _Versioncfdi = value; OnPropertyChanged(); } } }

        private BoolCN? _Pagoservconsolidado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Pagoservconsolidado { get => _Pagoservconsolidado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Pagoservconsolidado)) { _Pagoservconsolidado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarinvinfoadicprod;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrarinvinfoadicprod { get => _Mostrarinvinfoadicprod?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrarinvinfoadicprod)) { _Mostrarinvinfoadicprod = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Wsespecialexistmatriz;
        [XmlAttribute]
        public string? Wsespecialexistmatriz { get => _Wsespecialexistmatriz; set { if (RaiseAcceptPendingChange(value, _Wsespecialexistmatriz)) { _Wsespecialexistmatriz = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_consolidadoautomatico;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Hab_consolidadoautomatico { get => _Hab_consolidadoautomatico?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Hab_consolidadoautomatico)) { _Hab_consolidadoautomatico = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutareplicadorexe;
        [XmlAttribute]
        public string? Rutareplicadorexe { get => _Rutareplicadorexe; set { if (RaiseAcceptPendingChange(value, _Rutareplicadorexe)) { _Rutareplicadorexe = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Ult_consolidadoautomatico;
        [XmlAttribute]
        public DateTimeOffset? Ult_consolidadoautomatico { get => _Ult_consolidadoautomatico; set { if (RaiseAcceptPendingChange(value, _Ult_consolidadoautomatico)) { _Ult_consolidadoautomatico = value; OnPropertyChanged(); } } }

        private string? _Ticketespecial;
        [XmlAttribute]
        public string? Ticketespecial { get => _Ticketespecial; set { if (RaiseAcceptPendingChange(value, _Ticketespecial)) { _Ticketespecial = value; OnPropertyChanged(); } } }

        private string? _Ticketdefaultprinter;
        [XmlAttribute]
        public string? Ticketdefaultprinter { get => _Ticketdefaultprinter; set { if (RaiseAcceptPendingChange(value, _Ticketdefaultprinter)) { _Ticketdefaultprinter = value; OnPropertyChanged(); } } }

        private string? _Recargasdefaultprinter;
        [XmlAttribute]
        public string? Recargasdefaultprinter { get => _Recargasdefaultprinter; set { if (RaiseAcceptPendingChange(value, _Recargasdefaultprinter)) { _Recargasdefaultprinter = value; OnPropertyChanged(); } } }

        private BoolCN? _Piezacajaenticket;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Piezacajaenticket { get => _Piezacajaenticket?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Piezacajaenticket)) { _Piezacajaenticket = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Numticketsabono;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Numticketsabono { get => _Numticketsabono?? 0; set { if (RaiseAcceptPendingChange(value, _Numticketsabono)) { _Numticketsabono = value?? 0; OnPropertyChanged(); } } }

        private ModoAlertaPV ? _Pvcolorear;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public ModoAlertaPV ? Pvcolorear { get => _Pvcolorear?? ModoAlertaPV.Ninguno_Especial; set { if (RaiseAcceptPendingChange(value, _Pvcolorear)) { _Pvcolorear = value?? ModoAlertaPV.Ninguno_Especial; OnPropertyChanged(); } } }

        private BoolCN? _Generarfe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Generarfe { get => _Generarfe?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Generarfe)) { _Generarfe = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Intentosretirocaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Intentosretirocaja { get => _Intentosretirocaja?? 0; set { if (RaiseAcceptPendingChange(value, _Intentosretirocaja)) { _Intentosretirocaja = value?? 0; OnPropertyChanged(); } } }

        //private string? _Vendedormovilclave;
        //[XmlAttribute]
        //public string? Vendedormovilclave { get => _Vendedormovilclave; set { if (RaiseAcceptPendingChange(value, _Vendedormovilclave)) { _Vendedormovilclave = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Movil_ultcam_sesion;
        [XmlAttribute]
        public DateTimeOffset? Movil_ultcam_sesion { get => _Movil_ultcam_sesion; set { if (RaiseAcceptPendingChange(value, _Movil_ultcam_sesion)) { _Movil_ultcam_sesion = value; OnPropertyChanged(); } } }

        private BoolCN? _Movil_tienevendedores;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movil_tienevendedores { get => _Movil_tienevendedores?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movil_tienevendedores)) { _Movil_tienevendedores = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutacatalogosupd;
        [XmlAttribute]
        public string? Rutacatalogosupd { get => _Rutacatalogosupd; set { if (RaiseAcceptPendingChange(value, _Rutacatalogosupd)) { _Rutacatalogosupd = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimircopiaalmacen;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Imprimircopiaalmacen { get => _Imprimircopiaalmacen?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Imprimircopiaalmacen)) { _Imprimircopiaalmacen = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Movil3_preimportar;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Movil3_preimportar { get => _Movil3_preimportar?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Movil3_preimportar)) { _Movil3_preimportar = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutaimportadatos;
        [XmlAttribute]
        public string? Rutaimportadatos { get => _Rutaimportadatos; set { if (RaiseAcceptPendingChange(value, _Rutaimportadatos)) { _Rutaimportadatos = value; OnPropertyChanged(); } } }

        private BoolCN? _Busquedatipo2;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Busquedatipo2 { get => _Busquedatipo2?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Busquedatipo2)) { _Busquedatipo2 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Agrupacionventaid;
        [XmlAttribute]
        public long? Agrupacionventaid { get => _Agrupacionventaid; set { if (RaiseAcceptPendingChange(value, _Agrupacionventaid)) { _Agrupacionventaid = value; OnPropertyChanged(); } } }

        private string? _AgrupacionventaClave;
        [XmlAttribute]
        public string? AgrupacionventaClave { get => _AgrupacionventaClave; set { if (RaiseAcceptPendingChange(value, _AgrupacionventaClave)) { _AgrupacionventaClave = value; OnPropertyChanged(); } } }

        private string? _AgrupacionventaNombre;
        [XmlAttribute]
        public string? AgrupacionventaNombre { get => _AgrupacionventaNombre; set { if (RaiseAcceptPendingChange(value, _AgrupacionventaNombre)) { _AgrupacionventaNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Consfactomitirvales;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Consfactomitirvales { get => _Consfactomitirvales?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Consfactomitirvales)) { _Consfactomitirvales = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Destinobdvenmov;
        [XmlAttribute]
        public string? Destinobdvenmov { get => _Destinobdvenmov; set { if (RaiseAcceptPendingChange(value, _Destinobdvenmov)) { _Destinobdvenmov = value; OnPropertyChanged(); } } }

        private int? _Doblecopiacontado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Doblecopiacontado { get => _Doblecopiacontado?? 0; set { if (RaiseAcceptPendingChange(value, _Doblecopiacontado)) { _Doblecopiacontado = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Desgloseiepsfactura;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Desgloseiepsfactura { get => _Desgloseiepsfactura?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Desgloseiepsfactura)) { _Desgloseiepsfactura = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Rutapolizapdf;
        [XmlAttribute]
        public string? Rutapolizapdf { get => _Rutapolizapdf; set { if (RaiseAcceptPendingChange(value, _Rutapolizapdf)) { _Rutapolizapdf = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimirbancoscorte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Imprimirbancoscorte { get => _Imprimirbancoscorte?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Imprimirbancoscorte)) { _Imprimirbancoscorte = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Pago_tarjmenorpreciolista;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Pago_tarjmenorpreciolista { get => _Pago_tarjmenorpreciolista?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Pago_tarjmenorpreciolista)) { _Pago_tarjmenorpreciolista = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Impr_canc_venta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Impr_canc_venta { get => _Impr_canc_venta?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Impr_canc_venta)) { _Impr_canc_venta = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Retirocajaalcerrarcorte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Retirocajaalcerrarcorte { get => _Retirocajaalcerrarcorte?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Retirocajaalcerrarcorte)) { _Retirocajaalcerrarcorte = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Pagotarjmenorpreciolistaall;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Pagotarjmenorpreciolistaall { get => _Pagotarjmenorpreciolistaall?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Pagotarjmenorpreciolistaall)) { _Pagotarjmenorpreciolistaall = value?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Kitsdef_ultact;
        [XmlAttribute]
        public DateTimeOffset? Kitsdef_ultact { get => _Kitsdef_ultact; set { if (RaiseAcceptPendingChange(value, _Kitsdef_ultact)) { _Kitsdef_ultact = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Kitsdef_unniv_ultact;
        [XmlAttribute]
        public DateTimeOffset? Kitsdef_unniv_ultact { get => _Kitsdef_unniv_ultact; set { if (RaiseAcceptPendingChange(value, _Kitsdef_unniv_ultact)) { _Kitsdef_unniv_ultact = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarservdom;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Preguntarservdom { get => _Preguntarservdom?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Preguntarservdom)) { _Preguntarservdom = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habppc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habppc { get => _Habppc?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habppc)) { _Habppc = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Soloabonoaplicado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Soloabonoaplicado { get => _Soloabonoaplicado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Soloabonoaplicado)) { _Soloabonoaplicado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Versiontopeid;
        [XmlAttribute]
        public long? Versiontopeid { get => _Versiontopeid; set { if (RaiseAcceptPendingChange(value, _Versiontopeid)) { _Versiontopeid = value; OnPropertyChanged(); } } }

        private long? _Versioncomisionid;
        [XmlAttribute]
        public long? Versioncomisionid { get => _Versioncomisionid; set { if (RaiseAcceptPendingChange(value, _Versioncomisionid)) { _Versioncomisionid = value; OnPropertyChanged(); } } }

        private decimal? _Maxcomisionxcliente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Maxcomisionxcliente { get => _Maxcomisionxcliente?? 0; set { if (RaiseAcceptPendingChange(value, _Maxcomisionxcliente)) { _Maxcomisionxcliente = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Imprformaventatrasl;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Imprformaventatrasl { get => _Imprformaventatrasl?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Imprformaventatrasl)) { _Imprformaventatrasl = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habrevisionfinal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habrevisionfinal { get => _Habrevisionfinal?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habrevisionfinal)) { _Habrevisionfinal = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Recibolargocotiprinter;
        [XmlAttribute]
        public string? Recibolargocotiprinter { get => _Recibolargocotiprinter; set { if (RaiseAcceptPendingChange(value, _Recibolargocotiprinter)) { _Recibolargocotiprinter = value; OnPropertyChanged(); } } }

        private BoolCN? _Habfondodinamico;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habfondodinamico { get => _Habfondodinamico?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habfondodinamico)) { _Habfondodinamico = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habventaclisuc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habventaclisuc { get => _Habventaclisuc?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habventaclisuc)) { _Habventaclisuc = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Segundoscicloftp;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Segundoscicloftp { get => _Segundoscicloftp?? 0; set { if (RaiseAcceptPendingChange(value, _Segundoscicloftp)) { _Segundoscicloftp = value?? 0; OnPropertyChanged(); } } }

        private int? _Diasmaxexpftp;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Diasmaxexpftp { get => _Diasmaxexpftp?? 0; set { if (RaiseAcceptPendingChange(value, _Diasmaxexpftp)) { _Diasmaxexpftp = value?? 0; OnPropertyChanged(); } } }

        private int? _Diasmaximpftp;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Diasmaximpftp { get => _Diasmaximpftp?? 0; set { if (RaiseAcceptPendingChange(value, _Diasmaximpftp)) { _Diasmaximpftp = value?? 0; OnPropertyChanged(); } } }

        private string? _Wsdbf;
        [XmlAttribute]
        public string? Wsdbf { get => _Wsdbf; set { if (RaiseAcceptPendingChange(value, _Wsdbf)) { _Wsdbf = value; OnPropertyChanged(); } } }

        private BoolCN? _Habwsdbf;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habwsdbf { get => _Habwsdbf?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habwsdbf)) { _Habwsdbf = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Comisiondebtarjetaempresa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comisiondebtarjetaempresa { get => _Comisiondebtarjetaempresa?? 0; set { if (RaiseAcceptPendingChange(value, _Comisiondebtarjetaempresa)) { _Comisiondebtarjetaempresa = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Comisiondebportarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Comisiondebportarjeta { get => _Comisiondebportarjeta?? 0; set { if (RaiseAcceptPendingChange(value, _Comisiondebportarjeta)) { _Comisiondebportarjeta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Factconsmaxpor;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Factconsmaxpor { get => _Factconsmaxpor?? 0; set { if (RaiseAcceptPendingChange(value, _Factconsmaxpor)) { _Factconsmaxpor = value?? 0; OnPropertyChanged(); } } }

        private int? _Doblecopiatarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Doblecopiatarjeta { get => _Doblecopiatarjeta?? 0; set { if (RaiseAcceptPendingChange(value, _Doblecopiatarjeta)) { _Doblecopiatarjeta = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fiscalfechacancelacion2;
        [XmlAttribute]
        public DateTimeOffset? Fiscalfechacancelacion2 { get => _Fiscalfechacancelacion2; set { if (RaiseAcceptPendingChange(value, _Fiscalfechacancelacion2)) { _Fiscalfechacancelacion2 = value; OnPropertyChanged(); } } }

        private int? _Cantticketretiro;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketretiro { get => _Cantticketretiro?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketretiro)) { _Cantticketretiro = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketabrircorte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketabrircorte { get => _Cantticketabrircorte?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketabrircorte)) { _Cantticketabrircorte = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketcompras;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketcompras { get => _Cantticketcompras?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketcompras)) { _Cantticketcompras = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketfondocaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketfondocaja { get => _Cantticketfondocaja?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketfondocaja)) { _Cantticketfondocaja = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketgastos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketgastos { get => _Cantticketgastos?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketgastos)) { _Cantticketgastos = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketdepositos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketdepositos { get => _Cantticketdepositos?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketdepositos)) { _Cantticketdepositos = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketcierrecorte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketcierrecorte { get => _Cantticketcierrecorte?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketcierrecorte)) { _Cantticketcierrecorte = value?? 0; OnPropertyChanged(); } } }

        private int? _Cantticketcierrebilletes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cantticketcierrebilletes { get => _Cantticketcierrebilletes?? 0; set { if (RaiseAcceptPendingChange(value, _Cantticketcierrebilletes)) { _Cantticketcierrebilletes = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Manejautilidadprecios;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejautilidadprecios { get => _Manejautilidadprecios?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejautilidadprecios)) { _Manejautilidadprecios = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Habmultplazocompra;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habmultplazocompra { get => _Habmultplazocompra?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habmultplazocompra)) { _Habmultplazocompra = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Costorepoigualcostoult;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Costorepoigualcostoult { get => _Costorepoigualcostoult?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Costorepoigualcostoult)) { _Costorepoigualcostoult = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Ticket_desc_vale_al_final;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ticket_desc_vale_al_final { get => _Ticket_desc_vale_al_final?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ticket_desc_vale_al_final)) { _Ticket_desc_vale_al_final = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Monederolistaprecioid;
        [XmlAttribute]
        public long? Monederolistaprecioid { get => _Monederolistaprecioid; set { if (RaiseAcceptPendingChange(value, _Monederolistaprecioid)) { _Monederolistaprecioid = value; OnPropertyChanged(); } } }

        private string? _MonederolistaprecioClave;
        [XmlAttribute]
        public string? MonederolistaprecioClave { get => _MonederolistaprecioClave; set { if (RaiseAcceptPendingChange(value, _MonederolistaprecioClave)) { _MonederolistaprecioClave = value; OnPropertyChanged(); } } }

        private string? _MonederolistaprecioNombre;
        [XmlAttribute]
        public string? MonederolistaprecioNombre { get => _MonederolistaprecioNombre; set { if (RaiseAcceptPendingChange(value, _MonederolistaprecioNombre)) { _MonederolistaprecioNombre = value; OnPropertyChanged(); } } }

        private string? _Monederocamporef;
        [XmlAttribute]
        public string? Monederocamporef { get => _Monederocamporef; set { if (RaiseAcceptPendingChange(value, _Monederocamporef)) { _Monederocamporef = value; OnPropertyChanged(); } } }

        private BoolCN? _Habsurtidoprevio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habsurtidoprevio { get => _Habsurtidoprevio?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habsurtidoprevio)) { _Habsurtidoprevio = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Numticketscomanda;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Numticketscomanda { get => _Numticketscomanda?? 0; set { if (RaiseAcceptPendingChange(value, _Numticketscomanda)) { _Numticketscomanda = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Recibopreviewcomanda;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Recibopreviewcomanda { get => _Recibopreviewcomanda?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Recibopreviewcomanda)) { _Recibopreviewcomanda = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Impresoracomanda;
        [XmlAttribute]
        public string? Impresoracomanda { get => _Impresoracomanda; set { if (RaiseAcceptPendingChange(value, _Impresoracomanda)) { _Impresoracomanda = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticket_impr_desc2;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Ticket_impr_desc2 { get => _Ticket_impr_desc2?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Ticket_impr_desc2)) { _Ticket_impr_desc2 = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Seriecomprtraslsat;
        [XmlAttribute]
        public string? Seriecomprtraslsat { get => _Seriecomprtraslsat; set { if (RaiseAcceptPendingChange(value, _Seriecomprtraslsat)) { _Seriecomprtraslsat = value; OnPropertyChanged(); } } }

        private BoolCN? _Habsurtidopostmovil;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Habsurtidopostmovil { get => _Habsurtidopostmovil?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Habsurtidopostmovil)) { _Habsurtidopostmovil = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Porcutilidadlistado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Porcutilidadlistado { get => _Porcutilidadlistado?? 0; set { if (RaiseAcceptPendingChange(value, _Porcutilidadlistado)) { _Porcutilidadlistado = value?? 0; OnPropertyChanged(); } } }

        private string? _FormatoticketcortoClave;
        [XmlAttribute]
        public string? FormatoticketcortoClave { get => _FormatoticketcortoClave; set { if (RaiseAcceptPendingChange(value, _FormatoticketcortoClave)) { _FormatoticketcortoClave = value; OnPropertyChanged(); } } }

        private string? _FormatoticketcortoNombre;
        [XmlAttribute]
        public string? FormatoticketcortoNombre { get => _FormatoticketcortoNombre; set { if (RaiseAcceptPendingChange(value, _FormatoticketcortoNombre)) { _FormatoticketcortoNombre = value; OnPropertyChanged(); } } }

        private string? _TiposeleccioncatalogosatClave;
        [XmlAttribute]
        public string? TiposeleccioncatalogosatClave { get => _TiposeleccioncatalogosatClave; set { if (RaiseAcceptPendingChange(value, _TiposeleccioncatalogosatClave)) { _TiposeleccioncatalogosatClave = value; OnPropertyChanged(); } } }

        private string? _TiposeleccioncatalogosatNombre;
        [XmlAttribute]
        public string? TiposeleccioncatalogosatNombre { get => _TiposeleccioncatalogosatNombre; set { if (RaiseAcceptPendingChange(value, _TiposeleccioncatalogosatNombre)) { _TiposeleccioncatalogosatNombre = value; OnPropertyChanged(); } } }

        private string? _PvcolorearClave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? PvcolorearClave { get => _PvcolorearClave?? ""; set { if (RaiseAcceptPendingChange(value, _PvcolorearClave)) { _PvcolorearClave = value?? ""; OnPropertyChanged(); } } }

        private string? _PvcolorearNombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? PvcolorearNombre { get => _PvcolorearNombre?? ""; set { if (RaiseAcceptPendingChange(value, _PvcolorearNombre)) { _PvcolorearNombre = value?? ""; OnPropertyChanged(); } } }

        private string? _ScreenconfigClave;
        [XmlAttribute]
        public string? ScreenconfigClave { get => _ScreenconfigClave; set { if (RaiseAcceptPendingChange(value, _ScreenconfigClave)) { _ScreenconfigClave = value; OnPropertyChanged(); } } }

        private string? _ScreenconfigNombre;
        [XmlAttribute]
        public string? ScreenconfigNombre { get => _ScreenconfigNombre; set { if (RaiseAcceptPendingChange(value, _ScreenconfigNombre)) { _ScreenconfigNombre = value; OnPropertyChanged(); } } }

        private string? _TipovendedormovilClave;
        [XmlAttribute]
        public string? TipovendedormovilClave { get => _TipovendedormovilClave; set { if (RaiseAcceptPendingChange(value, _TipovendedormovilClave)) { _TipovendedormovilClave = value; OnPropertyChanged(); } } }

        private string? _TipovendedormovilNombre;
        [XmlAttribute]
        public string? TipovendedormovilNombre { get => _TipovendedormovilNombre; set { if (RaiseAcceptPendingChange(value, _TipovendedormovilNombre)) { _TipovendedormovilNombre = value; OnPropertyChanged(); } } }

        private string? _TiposyncmovilClave;
        [XmlAttribute]
        public string? TiposyncmovilClave { get => _TiposyncmovilClave; set { if (RaiseAcceptPendingChange(value, _TiposyncmovilClave)) { _TiposyncmovilClave = value; OnPropertyChanged(); } } }

        private string? _TiposyncmovilNombre;
        [XmlAttribute]
        public string? TiposyncmovilNombre { get => _TiposyncmovilNombre; set { if (RaiseAcceptPendingChange(value, _TiposyncmovilNombre)) { _TiposyncmovilNombre = value; OnPropertyChanged(); } } }

        private string? _FormatofactelectClave;
        [XmlAttribute]
        public string? FormatofactelectClave { get => _FormatofactelectClave; set { if (RaiseAcceptPendingChange(value, _FormatofactelectClave)) { _FormatofactelectClave = value; OnPropertyChanged(); } } }

        private string? _FormatofactelectNombre;
        [XmlAttribute]
        public string? FormatofactelectNombre { get => _FormatofactelectNombre; set { if (RaiseAcceptPendingChange(value, _FormatofactelectNombre)) { _FormatofactelectNombre = value; OnPropertyChanged(); } } }

        private string? _Rutafirmaimagenes;
        [XmlAttribute]
        public string? Rutafirmaimagenes { get => _Rutafirmaimagenes; set { if (RaiseAcceptPendingChange(value, _Rutafirmaimagenes)) { _Rutafirmaimagenes = value; OnPropertyChanged(); } } }

        private BoolCN? _Autpreciolistabajo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Autpreciolistabajo { get => _Autpreciolistabajo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Autpreciolistabajo)) { _Autpreciolistabajo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Listapreciomaylinea;
        [XmlAttribute]
        public long? Listapreciomaylinea { get => _Listapreciomaylinea; set { if (RaiseAcceptPendingChange(value, _Listapreciomaylinea)) { _Listapreciomaylinea = value; OnPropertyChanged(); } } }

        private string? _Listapreciomaylinea_Clave;
        [XmlAttribute]
        public string? Listapreciomaylinea_Clave { get => _Listapreciomaylinea_Clave; set { if (RaiseAcceptPendingChange(value, _Listapreciomaylinea_Clave)) { _Listapreciomaylinea_Clave = value; OnPropertyChanged(); } } }

        private string? _Listapreciomaylinea_Nombre;
        [XmlAttribute]
        public string? Listapreciomaylinea_Nombre { get => _Listapreciomaylinea_Nombre; set { if (RaiseAcceptPendingChange(value, _Listapreciomaylinea_Nombre)) { _Listapreciomaylinea_Nombre = value; OnPropertyChanged(); } } }

        private long? _Listaprecmedmaylinea;
        [XmlAttribute]
        public long? Listaprecmedmaylinea { get => _Listaprecmedmaylinea; set { if (RaiseAcceptPendingChange(value, _Listaprecmedmaylinea)) { _Listaprecmedmaylinea = value; OnPropertyChanged(); } } }

        private string? _Listapremedmaylinea_Clave;
        [XmlAttribute]
        public string? Listapremedmaylinea_Clave { get => _Listapremedmaylinea_Clave; set { if (RaiseAcceptPendingChange(value, _Listapremedmaylinea_Clave)) { _Listapremedmaylinea_Clave = value; OnPropertyChanged(); } } }

        private string? _Listapremedmaylinea_Nombre;
        [XmlAttribute]
        public string? Listapremedmaylinea_Nombre { get => _Listapremedmaylinea_Nombre; set { if (RaiseAcceptPendingChange(value, _Listapremedmaylinea_Nombre)) { _Listapremedmaylinea_Nombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Parametro"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Lista_precio_def.Clave|Lista_precio_def.Nombre|Estado_def|Lista_precio_traspaso|Inventory_email|Id_dosletras|Ftphost|Ftpusuario|Ftppassword|Smtphost|Smtpusuario|Smtppassword|Smtpmailfrom|Smtpmailto|Listapreciominimo_.Clave|Listapreciominimo_.Nombre|Header|Footer|Nombre|Calle|Numeroexterior|Numerointerior|Colonia|Municipio|Estado|Codigopostal|Fiscalcalle|Fiscalnumerointerior|Fiscalnumeroexterior|Fiscalcolonia|Fiscalmunicipio|Fiscalestado|Fiscalcodigopostal|Certificadocsd|Timbradouser|Timbradopassword|Timbradoarchivocertificado|Timbradoarchivokey|Timbradokey|Fiscalnombre|Seriesat|Footerventaapartado|Encargado.Clave|Encargado.Nombre|Ftpfolder|Ftpfolderpass|Seriesatdevolucion|Prefijobascula|Listaprecioxuempaque_.Clave|Listaprecioxuempaque_.Nombre|Listaprecioxpzacaja_.Clave|Listaprecioxpzacaja_.Nombre|Listaprecioinimayo_.Clave|Listaprecioinimayo_.Nombre|Pacnombre|Pacusuario|Rutareportes|Recibolargoprinter|Fiscalregimen|Rutaimagenesproducto|Fact_elect_folder|Pedidos_folder|Prefijocliente|Cuentaieps|Webservice|Tipodescuentoprod.Clave|Tipodescuentoprod.Nombre|Tipoutilidad.Clave|Tipoutilidad.Nombre|Tiposyncmovil|Ordenimpresion|Localftphost|Localwebservice|Mailtoinventario|Rutarespaldoszip|Screenconfig|Tamanoletraticket|Campoimpocostorepo.Clave|Campoimpocostorepo.Nombre|Bdlocalrepl|Tipovendedormovil|Vendedormovil.Clave|Vendedormovil.Nombre|Bdserverws|Bdmatrizmovil|Clienteconsolidado.Clave|Clienteconsolidado.Nombre|Rutareportessistema|Descuentotipo1texto|Descuentotipo2texto|Descuentotipo3texto|Descuentotipo4texto|Rutarespaldo|Mailejecutivo|Formatoticketcortoid|Seriesatabono|Rutaarchivosadjuntos|Formatofactelect|Emidarecargalinea.Clave|Emidarecargalinea.Nombre|Emidarecargamarca.Clave|Emidarecargamarca.Nombre|Emidarecargaproveedor.Clave|Emidarecargaproveedor.Nombre|Emidaserviciolinea.Clave|Emidaserviciolinea.Nombre|Emidaserviciomarca.Clave|Emidaserviciomarca.Nombre|Emidaservicioproveedor.Clave|Emidaservicioproveedor.Nombre|Wsmensajeria|Ultmensaje.Clave|Ultmensaje.Nombre|Precioajustedifinv.Clave|Precioajustedifinv.Nombre|Ipwebserviceappinv|Rutabdappinventaro|Rutadbfexistenciasuc|Almacenrecepcion.Clave|Almacenrecepcion.Nombre|Sat_metodopago.Clave|Sat_metodopago.Nombre|Sat_regimenfiscal.Clave|Sat_regimenfiscal.Nombre|Tiposeleccioncatalogosat|Versioncfdi|Wsespecialexistmatriz|Rutareplicadorexe|Ticketespecial|Ticketdefaultprinter|Recargasdefaultprinter|Pvcolorear|Vendedormovilclave|Rutacatalogosupd|Rutaimportadatos|Agrupacionventa.Clave|Agrupacionventa.Nombre|Destinobdvenmov|Rutapolizapdf|Recibolargocotiprinter|Wsdbf|Monederolistaprecio.Clave|Monederolistaprecio.Nombre|Monederocamporef|Impresoracomanda|Seriecomprtraslsat|FormatoticketcortoClave|FormatoticketcortoNombre|TiposeleccioncatalogosatClave|TiposeleccioncatalogosatNombre|PvcolorearClave|PvcolorearNombre|ScreenconfigClave|ScreenconfigNombre|TipovendedormovilClave|TipovendedormovilNombre|TiposyncmovilClave|TiposyncmovilNombre|FormatofactelectClave|FormatofactelectNombre|Rutafirmaimagenes|Listapreciomaylinea_.Clave|Listapreciomaylinea_.Nombre|Listapremedmaylinea_.Clave|Listapremedmaylinea_.Nombre";
        }


        #if PROYECTO_WEB
        
        public virtual void FillCatalogRelatedFields(Parametro item)
        {

             this._Lista_precio_defClave = item.Lista_precio_def?.Clave;

             this._Lista_precio_defNombre = item.Lista_precio_def?.Nombre;

             this._Listapreciominimo_Clave = item.Listapreciominimo_?.Clave;

             this._Listapreciominimo_Nombre = item.Listapreciominimo_?.Nombre;

             this._EncargadoClave = item.Encargado?.Clave;

             this._EncargadoNombre = item.Encargado?.Nombre;

             this._Listaprecioxuempaque_Clave = item.Listaprecioxuempaque_?.Clave;

             this._Listaprecioxuempaque_Nombre = item.Listaprecioxuempaque_?.Nombre;

             this._Listaprecioxpzacaja_Clave = item.Listaprecioxpzacaja_?.Clave;

             this._Listaprecioxpzacaja_Nombre = item.Listaprecioxpzacaja_?.Nombre;

             this._Listaprecioinimayo_Clave = item.Listaprecioinimayo_?.Clave;

             this._Listaprecioinimayo_Nombre = item.Listaprecioinimayo_?.Nombre;

             this._TipodescuentoprodClave = item.Tipodescuentoprod?.Clave;

             this._TipodescuentoprodNombre = item.Tipodescuentoprod?.Nombre;

             this._TipoutilidadClave = item.Tipoutilidad?.Clave;

             this._TipoutilidadNombre = item.Tipoutilidad?.Nombre;

             this._CampoimpocostorepoClave = item.Campoimpocostorepo?.Clave;

             this._CampoimpocostorepoNombre = item.Campoimpocostorepo?.Nombre;

             this._VendedormovilClave = item.Vendedormovil?.Clave;

             this._VendedormovilNombre = item.Vendedormovil?.Nombre;

             this._ClienteconsolidadoClave = item.Clienteconsolidado?.Clave;

             this._ClienteconsolidadoNombre = item.Clienteconsolidado?.Nombre;

             this._EmidarecargalineaClave = item.Emidarecargalinea?.Clave;

             this._EmidarecargalineaNombre = item.Emidarecargalinea?.Nombre;

             this._EmidarecargamarcaClave = item.Emidarecargamarca?.Clave;

             this._EmidarecargamarcaNombre = item.Emidarecargamarca?.Nombre;

             this._EmidarecargaproveedorClave = item.Emidarecargaproveedor?.Clave;

             this._EmidarecargaproveedorNombre = item.Emidarecargaproveedor?.Nombre;

             this._EmidaserviciolineaClave = item.Emidaserviciolinea?.Clave;

             this._EmidaserviciolineaNombre = item.Emidaserviciolinea?.Nombre;

             this._EmidaserviciomarcaClave = item.Emidaserviciomarca?.Clave;

             this._EmidaserviciomarcaNombre = item.Emidaserviciomarca?.Nombre;

             this._EmidaservicioproveedorClave = item.Emidaservicioproveedor?.Clave;

             this._EmidaservicioproveedorNombre = item.Emidaservicioproveedor?.Nombre;

             this._UltmensajeClave = item.Ultmensaje?.Clave;

             this._UltmensajeNombre = item.Ultmensaje?.Nombre;

             this._PrecioajustedifinvClave = item.Precioajustedifinv?.Clave;

             this._PrecioajustedifinvNombre = item.Precioajustedifinv?.Nombre;

             this._AlmacenrecepcionClave = item.Almacenrecepcion?.Clave;

             this._AlmacenrecepcionNombre = item.Almacenrecepcion?.Nombre;

             this._Sat_metodopagoClave = item.Sat_metodopago?.Clave;

             this._Sat_metodopagoNombre = item.Sat_metodopago?.Nombre;

             this._Sat_regimenfiscalClave = item.Sat_regimenfiscal?.Clave;

             this._Sat_regimenfiscalNombre = item.Sat_regimenfiscal?.Nombre;

             this._AgrupacionventaClave = item.Agrupacionventa?.Clave;

             this._AgrupacionventaNombre = item.Agrupacionventa?.Nombre;

             this._MonederolistaprecioClave = item.Monederolistaprecio?.Clave;

             this._MonederolistaprecioNombre = item.Monederolistaprecio?.Nombre;

             this._Listapreciomaylinea_Clave = item.Listapreciomaylinea_?.Clave;

             this._Listapreciomaylinea_Nombre = item.Listapreciomaylinea_?.Nombre;

             this._Listapremedmaylinea_Clave = item.Listapremedmaylinea_?.Clave;

             this._Listapremedmaylinea_Nombre = item.Listapremedmaylinea_?.Nombre;


        }


        public virtual void FillEntityValues(ref Parametro item)
        {


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.Lista_precio_defid = Lista_precio_defid ;


            item.Imp_prod_def = Imp_prod_def ?? 0;


            item.Estado_def = Estado_def ;


            item.Lista_precio_traspaso = Lista_precio_traspaso ;


            item.Promocion = Promocion ?? BoolCN.N;


            item.Cantidad = Cantidad ;


            item.Utilidad = Utilidad ?? 0;


            item.Fechaanterior = Fechaanterior ;


            item.Fechaactual = Fechaactual ;


            item.Fechaultima = Fechaultima ;


            item.Max_inv_fis_cant = Max_inv_fis_cant ;


            item.Inventory_email = Inventory_email ;


            item.Id_dosletras = Id_dosletras ;


            item.Habilitar_impexp_aut = Habilitar_impexp_aut ?? BoolCN.N;


            item.Comisionmedico = Comisionmedico ?? 0;


            item.Comisiondependiente = Comisiondependiente ?? 0;


            item.Ftphost = Ftphost ;


            item.Ftpusuario = Ftpusuario ;


            item.Ftppassword = Ftppassword ;


            item.Smtphost = Smtphost ;


            item.Smtpusuario = Smtpusuario ;


            item.Smtppassword = Smtppassword ;


            item.Smtpport = Smtpport ?? 0;


            item.Smtpmailfrom = Smtpmailfrom ;


            item.Smtpmailto = Smtpmailto ;


            item.Cambiarprecio = Cambiarprecio ?? BoolCN.N;


            item.Listapreciominimo = Listapreciominimo ;


            item.Compraentienda = Compraentienda ?? BoolCN.N;


            item.Header = Header ;


            item.Footer = Footer ;


            item.Hab_sel_cliente = Hab_sel_cliente ?? BoolCN.N;


            item.Hab_impr_cotizacion = Hab_impr_cotizacion ?? BoolCN.N;


            item.Mostrar_exis_suc = Mostrar_exis_suc ?? BoolCN.N;


            item.Req_aprobacion_inv = Req_aprobacion_inv ?? BoolCN.N;


            item.Reabrircortes = Reabrircortes ?? BoolCN.N;


            item.Descuentovale = Descuentovale ?? 0;


            item.Ult_fecha_imp_prod = Ult_fecha_imp_prod ;


            item.Imp_prod_total = Imp_prod_total ?? BoolCN.N;


            item.Nombre = Nombre ;


            item.Calle = Calle ;


            item.Numeroexterior = Numeroexterior ;


            item.Numerointerior = Numerointerior ;


            item.Colonia = Colonia ;


            item.Municipio = Municipio ;


            item.Estado = Estado ;


            item.Codigopostal = Codigopostal ;


            item.Fiscalcalle = Fiscalcalle ;


            item.Fiscalnumerointerior = Fiscalnumerointerior ;


            item.Fiscalnumeroexterior = Fiscalnumeroexterior ;


            item.Fiscalcolonia = Fiscalcolonia ;


            item.Fiscalmunicipio = Fiscalmunicipio ;


            item.Fiscalestado = Fiscalestado ;


            item.Fiscalcodigopostal = Fiscalcodigopostal ;


            item.Certificadocsd = Certificadocsd ;


            item.Timbradouser = Timbradouser ;


            item.Timbradopassword = Timbradopassword ;


            item.Timbradoarchivocertificado = Timbradoarchivocertificado ;


            item.Timbradoarchivokey = Timbradoarchivokey ;


            item.Timbradokey = Timbradokey ;


            item.Fiscalnombre = Fiscalnombre ;


            item.Seriesat = Seriesat ;


            item.Usarfiscalesenexpedicion = Usarfiscalesenexpedicion ?? BoolCN.N;


            item.Hab_facturaelectronica = Hab_facturaelectronica ?? BoolCN.N;


            item.Footerventaapartado = Footerventaapartado ;


            item.Encargadoid = Encargadoid ;


            item.Porc_comisionencargado = Porc_comisionencargado ?? 0;


            item.Porc_comisionvendedor = Porc_comisionvendedor ?? 0;


            item.Ftpfolder = Ftpfolder ;


            item.Ftpfolderpass = Ftpfolderpass ;


            item.Seriesatdevolucion = Seriesatdevolucion ;


            item.Cambiarprecioxuempaque = Cambiarprecioxuempaque ?? BoolCN.N;


            item.Cambiarprecioxpzacaja = Cambiarprecioxpzacaja ?? BoolCN.N;


            item.Prefijobascula = Prefijobascula ;


            item.Longprodbascula = Longprodbascula ;


            item.Longpesobascula = Longpesobascula ;


            item.Listaprecioxuempaque = Listaprecioxuempaque ;


            item.Listaprecioxpzacaja = Listaprecioxpzacaja ;


            item.Listaprecioinimayo = Listaprecioinimayo ;


            item.Hayvendedorpiso = Hayvendedorpiso ?? BoolCN.N;


            item.Envioautomaticoexistencias = Envioautomaticoexistencias ?? BoolCN.N;


            item.Monederomontominimo = Monederomontominimo ?? 0;


            item.Monederoaplicar = Monederoaplicar ?? BoolCN.N;


            item.Monederocaducidad = Monederocaducidad ?? 0;


            item.Imprimirnumeropiezas = Imprimirnumeropiezas ?? BoolCN.N;


            item.Pacnombre = Pacnombre ;


            item.Pacusuario = Pacusuario ;


            item.Cortepormail = Cortepormail ?? BoolCN.N;


            item.Rutareportes = Rutareportes ;


            item.Doblecopiacredito = Doblecopiacredito ?? 0;


            item.Doblecopiatraslado = Doblecopiatraslado ?? 0;


            item.Camposcustomalimportar = Camposcustomalimportar ?? BoolCN.N;


            item.Recibolargoconfactura = Recibolargoconfactura ?? BoolCN.N;


            item.Recibolargoprinter = Recibolargoprinter ;


            item.Recibolargopreview = Recibolargopreview ?? BoolCN.N;


            item.Preguntarrazonpreciomenor = Preguntarrazonpreciomenor ?? BoolCN.N;


            item.Preguntardatosentrega = Preguntardatosentrega ?? BoolCN.N;


            item.Fiscalregimen = Fiscalregimen ;


            item.Cortacaducidad = Cortacaducidad ?? 0;


            item.Retencioniva = Retencioniva ?? 0;


            item.Retencionisr = Retencionisr ?? 0;


            item.Arrendatario = Arrendatario ?? BoolCN.N;


            item.Rutaimagenesproducto = Rutaimagenesproducto ;


            item.Mostrarimagenenventa = Mostrarimagenenventa ?? BoolCN.N;


            item.Mostrarmontoahorro = Mostrarmontoahorro ?? BoolCN.N;


            item.Smtpssl = Smtpssl ?? BoolCN.N;


            item.Mostrardescuentofactura = Mostrardescuentofactura ?? BoolCN.N;


            item.Exportcatalogoaux = Exportcatalogoaux ?? BoolCN.N;


            item.Uiventaconcantidad = Uiventaconcantidad ?? BoolCN.N;


            item.Fact_elect_folder = Fact_elect_folder ;


            item.Pedidos_folder = Pedidos_folder ;


            item.Prefijocliente = Prefijocliente ;


            item.Fechainiciopedido = Fechainiciopedido ;


            item.Mostrarpzacajaenfactura = Mostrarpzacajaenfactura ?? BoolCN.N;


            item.Desgloseieps = Desgloseieps ?? BoolCN.N;


            item.Cuentaieps = Cuentaieps ;


            item.Dividir_rem_fact = Dividir_rem_fact ?? BoolCN.N;


            item.Webservice = Webservice ;


            item.Minutilidad = Minutilidad ?? 0;


            item.Manejasuperlistaprecio = Manejasuperlistaprecio ?? BoolCN.N;


            item.Manejaalmacen = Manejaalmacen ?? BoolCN.N;


            item.Tipodescuentoprodid = Tipodescuentoprodid ;


            item.Manejareceta = Manejareceta ?? BoolCN.N;


            item.Autocompprod = Autocompprod ?? BoolCN.N;


            item.Lastchangeproddesc = Lastchangeproddesc ;


            item.Tipoutilidadid = Tipoutilidadid ;


            item.Manejaquota = Manejaquota ?? BoolCN.N;


            item.Touch = Touch ?? BoolCN.N;


            item.Esvendedormovil = Esvendedormovil ?? BoolCN.N;


            item.Cajasbotellas = Cajasbotellas ?? BoolCN.N;


            item.Precionetoenpv = Precionetoenpv ?? BoolCN.N;


            item.Tiposyncmovil = Tiposyncmovil ;


            item.Mostrarflash = Mostrarflash ?? BoolCN.N;


            item.Ordenimpresion = Ordenimpresion ;


            item.Autocompcliente = Autocompcliente ?? BoolCN.N;


            item.Lastchangeclientenombre = Lastchangeclientenombre ;


            item.Precioxcajaenpv = Precioxcajaenpv ?? BoolCN.N;


            item.Localftphost = Localftphost ;


            item.Localwebservice = Localwebservice ;


            item.Usarconexionlocal = Usarconexionlocal ?? BoolCN.N;


            item.Movillastpreciodate = Movillastpreciodate ;


            item.Lastchangeprecioprod = Lastchangeprecioprod ;


            item.Movilcierrecobranza = Movilcierrecobranza ;


            item.Movilcierreventa = Movilcierreventa ;


            item.Mailtoinventario = Mailtoinventario ;


            item.Rutarespaldoszip = Rutarespaldoszip ;


            item.Screenconfig = Screenconfig ;


            item.Promoenticket = Promoenticket ?? BoolCN.N;


            item.Tamanoletraticket = Tamanoletraticket ?? LetraEnTicket.Normal;


            item.Manejakits = Manejakits ?? BoolCN.N;


            item.Campoimpocostorepoid = Campoimpocostorepoid ;


            item.Rebajaespecial = Rebajaespecial ?? BoolCN.N;


            item.Habilitarrepl = Habilitarrepl ?? BoolCN.N;


            item.Bdlocalrepl = Bdlocalrepl ;


            item.Pendmovilantesventa = Pendmovilantesventa ?? BoolCN.N;


            item.Preciosmovilantesventa = Preciosmovilantesventa ?? BoolCN.N;


            item.Recalcularcambiocliente = Recalcularcambiocliente ?? BoolCN.N;


            item.Tipovendedormovil = Tipovendedormovil ;


            item.Vendedormovilid = Vendedormovilid ;


            item.Bdserverws = Bdserverws ;


            item.Bdmatrizmovil = Bdmatrizmovil ;


            item.Prodcambioparamovil = Prodcambioparamovil ;


            item.Movilprocesosurtido = Movilprocesosurtido ?? BoolCN.N;


            item.Movilverificarventa = Movilverificarventa ?? BoolCN.N;


            item.Pendmaxdias = Pendmaxdias ?? 0;


            item.Reqautcancelarcoti = Reqautcancelarcoti ?? BoolCN.N;


            item.Reqautelimdetallecoti = Reqautelimdetallecoti ?? BoolCN.N;


            item.Abrircajonalfincorte = Abrircajonalfincorte ?? BoolCN.N;


            item.Habsurtidopostpuesto = Habsurtidopostpuesto ?? BoolCN.N;


            item.Clienteconsolidadoid = Clienteconsolidadoid ;


            item.Rutareportessistema = Rutareportessistema ;


            item.Doblecopiaremision = Doblecopiaremision ?? BoolCN.N;


            item.Reimpresionesconmarca = Reimpresionesconmarca ?? BoolCN.N;


            item.Habtotalizados = Habtotalizados ?? BoolCN.N;


            item.Multipletipovale = Multipletipovale ?? BoolCN.N;


            item.Descuentotipo1texto = Descuentotipo1texto ;


            item.Descuentotipo1porc = Descuentotipo1porc ?? 0;


            item.Descuentotipo2texto = Descuentotipo2texto ;


            item.Descuentotipo2porc = Descuentotipo2porc ?? 0;


            item.Descuentotipo3texto = Descuentotipo3texto ;


            item.Descuentotipo3porc = Descuentotipo3porc ?? 0;


            item.Descuentotipo4texto = Descuentotipo4texto ;


            item.Descuentotipo4porc = Descuentotipo4porc ?? 0;


            item.Habilitarlog = Habilitarlog ?? BoolCN.N;


            item.Rutarespaldo = Rutarespaldo ;


            item.Fecharespaldo = Fecharespaldo ;


            item.Manejarretirodecaja = Manejarretirodecaja ?? BoolCN.N;


            item.Montoretirocaja = Montoretirocaja ?? 0;


            item.Aplicarmayoreoporlinea = Aplicarmayoreoporlinea ?? BoolCN.N;


            item.Comisionportarjeta = Comisionportarjeta ?? 0;


            item.Piezasigualesmediomayoreo = Piezasigualesmediomayoreo ;


            item.Piezasdifmediomayoreo = Piezasdifmediomayoreo ;


            item.Piezasigualesmayoreo = Piezasigualesmayoreo ;


            item.Piezasdifmayoreo = Piezasdifmayoreo ;


            item.Comisiontarjetaempresa = Comisiontarjetaempresa ?? 0;


            item.Ivacomisiontarjetaempresa = Ivacomisiontarjetaempresa ?? 0;


            item.Preguntacancelacotizacion = Preguntacancelacotizacion ?? BoolCN.N;


            item.Habverificacioncxc = Habverificacioncxc ?? BoolCN.N;


            item.Mailejecutivo = Mailejecutivo ;


            item.Ventasxcorteemail = Ventasxcorteemail ?? BoolCN.N;


            item.Habventasafuturo = Habventasafuturo ?? BoolCN.N;


            item.Serviciosemida = Serviciosemida ?? BoolCN.N;


            item.Fechaactualizacionemida = Fechaactualizacionemida ;


            item.Formatoticketcortoid = Formatoticketcortoid ;


            item.Seriesatabono = Seriesatabono ;


            item.Habimpresioncortecajero = Habimpresioncortecajero ?? BoolCN.N;


            item.Habtrasladoporautorizacion = Habtrasladoporautorizacion ?? BoolCN.N;


            item.Habventasmostrador = Habventasmostrador ?? BoolCN.N;


            item.Timeoutpindistsale = Timeoutpindistsale ?? 0;


            item.Timeoutlookup = Timeoutlookup ?? 0;


            item.Rutaarchivosadjuntos = Rutaarchivosadjuntos ;


            item.Timeoutpindistsaleserv = Timeoutpindistsaleserv ?? 0;


            item.Habpagoservemida = Habpagoservemida ?? BoolCN.N;


            item.Fechaactualizacionemidaserv = Fechaactualizacionemidaserv ;


            item.Habpromoxmontomin = Habpromoxmontomin ?? BoolCN.N;


            item.Formatofactelect = Formatofactelect ;


            item.Montomaxsaldomenor = Montomaxsaldomenor ?? 0;


            item.Emidarecargalineaid = Emidarecargalineaid ;


            item.Emidarecargamarcaid = Emidarecargamarcaid ;


            item.Emidarecargaproveedorid = Emidarecargaproveedorid ;


            item.Emidaserviciolineaid = Emidaserviciolineaid ;


            item.Emidaserviciomarcaid = Emidaserviciomarcaid ;


            item.Emidaservicioproveedorid = Emidaservicioproveedorid ;


            item.Emidaporcutilidadrecargas = Emidaporcutilidadrecargas ?? 0;


            item.Emidautilidadpagoservicios = Emidautilidadpagoservicios ?? 0;


            item.Preciosordenados = Preciosordenados ?? BoolCN.N;


            item.Decimalesencantidad = Decimalesencantidad ?? 0;


            item.Eanpuederepetirse = Eanpuederepetirse ?? BoolCN.N;


            item.Bancomerhabpinpad = Bancomerhabpinpad ?? BoolCN.N;


            item.Hab_precioscliente = Hab_precioscliente ?? BoolCN.N;


            item.Cxcvalidartraslados = Cxcvalidartraslados ?? BoolCN.N;


            item.Preguntarsiesacredito = Preguntarsiesacredito ?? BoolCN.N;


            item.Habmensajeria = Habmensajeria ?? BoolCN.N;


            item.Wsmensajeria = Wsmensajeria ;


            item.Ultmensajeid = Ultmensajeid ;


            item.Habdesclineapersona = Habdesclineapersona ?? BoolCN.N;


            item.Manejarloteimportacion = Manejarloteimportacion ?? BoolCN.N;


            item.Manejagastosadic = Manejagastosadic ?? BoolCN.N;


            item.Caducidadminima = Caducidadminima ?? 0;


            item.Precioajustedifinvid = Precioajustedifinvid ;


            item.Habbotonpagovale = Habbotonpagovale ?? BoolCN.N;


            item.Unicavisitapordocto = Unicavisitapordocto ?? BoolCN.N;


            item.Plazoxproducto = Plazoxproducto ?? BoolCN.N;


            item.Autocompleteconexisenventa = Autocompleteconexisenventa ?? BoolCN.N;


            item.Ipwebserviceappinv = Ipwebserviceappinv ;


            item.Rutabdappinventaro = Rutabdappinventaro ;


            item.Rutadbfexistenciasuc = Rutadbfexistenciasuc ;


            item.Almacenrecepcionid = Almacenrecepcionid ;


            item.Aplicarcambiosprecauto = Aplicarcambiosprecauto ?? BoolCN.N;


            item.Numcancelactauto = Numcancelactauto ?? 0;


            item.Numcancelactautousuario = Numcancelactautousuario ?? 0;


            item.Manejacupones = Manejacupones ?? BoolCN.N;


            item.Hab_devoluciontraslado = Hab_devoluciontraslado ?? BoolCN.N;


            item.Hab_devolucionsurtidosuc = Hab_devolucionsurtidosuc ?? BoolCN.N;


            item.Versionwsexistencias = Versionwsexistencias ?? 0;


            item.Manejaproductospromocion = Manejaproductospromocion ?? BoolCN.N;


            item.Sat_metodopagoid = Sat_metodopagoid ;


            item.Sat_regimenfiscalid = Sat_regimenfiscalid ;


            item.Tiposeleccioncatalogosat = Tiposeleccioncatalogosat ;


            item.Precionetoengrids = Precionetoengrids ?? BoolCN.N;


            item.Versioncfdi = Versioncfdi ;


            item.Pagoservconsolidado = Pagoservconsolidado ?? BoolCN.N;


            item.Mostrarinvinfoadicprod = Mostrarinvinfoadicprod ?? BoolCN.N;


            item.Wsespecialexistmatriz = Wsespecialexistmatriz ;


            item.Hab_consolidadoautomatico = Hab_consolidadoautomatico ?? BoolCN.N;


            item.Rutareplicadorexe = Rutareplicadorexe ;


            item.Ult_consolidadoautomatico = Ult_consolidadoautomatico ;


            item.Ticketespecial = Ticketespecial ;


            item.Ticketdefaultprinter = Ticketdefaultprinter ;


            item.Recargasdefaultprinter = Recargasdefaultprinter ;


            item.Piezacajaenticket = Piezacajaenticket ?? BoolCN.N;


            item.Numticketsabono = Numticketsabono ?? 0;


            item.Pvcolorear = Pvcolorear ?? ModoAlertaPV.Ninguno_Especial;


            item.Generarfe = Generarfe ?? BoolCN.N;


            item.Intentosretirocaja = Intentosretirocaja ?? 0;


            item.Vendedormovilclave = VendedormovilClave ;


            item.Movil_ultcam_sesion = Movil_ultcam_sesion ;


            item.Movil_tienevendedores = Movil_tienevendedores ?? BoolCN.N;


            item.Rutacatalogosupd = Rutacatalogosupd ;


            item.Imprimircopiaalmacen = Imprimircopiaalmacen ?? BoolCN.N;


            item.Movil3_preimportar = Movil3_preimportar ?? BoolCN.N;


            item.Rutaimportadatos = Rutaimportadatos ;


            item.Busquedatipo2 = Busquedatipo2 ?? BoolCN.N;


            item.Agrupacionventaid = Agrupacionventaid ;


            item.Consfactomitirvales = Consfactomitirvales ?? BoolCN.N;


            item.Destinobdvenmov = Destinobdvenmov ;


            item.Doblecopiacontado = Doblecopiacontado ?? 0;


            item.Desgloseiepsfactura = Desgloseiepsfactura ?? BoolCN.N;


            item.Rutapolizapdf = Rutapolizapdf ;


            item.Imprimirbancoscorte = Imprimirbancoscorte ?? BoolCN.N;


            item.Pago_tarjmenorpreciolista = Pago_tarjmenorpreciolista ?? BoolCN.N;


            item.Impr_canc_venta = Impr_canc_venta ?? BoolCN.N;


            item.Retirocajaalcerrarcorte = Retirocajaalcerrarcorte ?? BoolCN.N;


            item.Pagotarjmenorpreciolistaall = Pagotarjmenorpreciolistaall ?? BoolCN.N;


            item.Kitsdef_ultact = Kitsdef_ultact ;


            item.Kitsdef_unniv_ultact = Kitsdef_unniv_ultact ;


            item.Preguntarservdom = Preguntarservdom ?? BoolCN.N;


            item.Habppc = Habppc ?? BoolCN.N;


            item.Soloabonoaplicado = Soloabonoaplicado ?? BoolCN.N;


            item.Versiontopeid = Versiontopeid ;


            item.Versioncomisionid = Versioncomisionid ;


            item.Maxcomisionxcliente = Maxcomisionxcliente ?? 0;


            item.Imprformaventatrasl = Imprformaventatrasl ?? BoolCN.N;


            item.Habrevisionfinal = Habrevisionfinal ?? BoolCN.N;


            item.Recibolargocotiprinter = Recibolargocotiprinter ;


            item.Habfondodinamico = Habfondodinamico ?? BoolCN.N;


            item.Habventaclisuc = Habventaclisuc ?? BoolCN.N;


            item.Segundoscicloftp = Segundoscicloftp ?? 0;


            item.Diasmaxexpftp = Diasmaxexpftp ?? 0;


            item.Diasmaximpftp = Diasmaximpftp ?? 0;


            item.Wsdbf = Wsdbf ;


            item.Habwsdbf = Habwsdbf ?? BoolCN.N;


            item.Comisiondebtarjetaempresa = Comisiondebtarjetaempresa ?? 0;


            item.Comisiondebportarjeta = Comisiondebportarjeta ?? 0;


            item.Factconsmaxpor = Factconsmaxpor ?? 0;


            item.Doblecopiatarjeta = Doblecopiatarjeta ?? 0;


            item.Fiscalfechacancelacion2 = Fiscalfechacancelacion2 ;


            item.Cantticketretiro = Cantticketretiro ?? 0;


            item.Cantticketabrircorte = Cantticketabrircorte ?? 0;


            item.Cantticketcompras = Cantticketcompras ?? 0;


            item.Cantticketfondocaja = Cantticketfondocaja ?? 0;


            item.Cantticketgastos = Cantticketgastos ?? 0;


            item.Cantticketdepositos = Cantticketdepositos ?? 0;


            item.Cantticketcierrecorte = Cantticketcierrecorte ?? 0;


            item.Cantticketcierrebilletes = Cantticketcierrebilletes ?? 0;


            item.Manejautilidadprecios = Manejautilidadprecios ?? BoolCN.N;


            item.Habmultplazocompra = Habmultplazocompra ?? BoolCN.N;


            item.Costorepoigualcostoult = Costorepoigualcostoult ?? BoolCN.N;


            item.Ticket_desc_vale_al_final = Ticket_desc_vale_al_final ?? BoolCN.N;


            item.Monederolistaprecioid = Monederolistaprecioid ;


            item.Monederocamporef = Monederocamporef ;


            item.Habsurtidoprevio = Habsurtidoprevio ?? BoolCN.N;


            item.Numticketscomanda = Numticketscomanda ?? 0;


            item.Recibopreviewcomanda = Recibopreviewcomanda ?? BoolCN.N;


            item.Impresoracomanda = Impresoracomanda ;


            item.Ticket_impr_desc2 = Ticket_impr_desc2 ?? BoolCN.N;


            item.Seriecomprtraslsat = Seriecomprtraslsat ;


            item.Habsurtidopostmovil = Habsurtidopostmovil ?? BoolCN.N;


            item.Porcutilidadlistado = Porcutilidadlistado ?? 0;


            item.FormatoticketcortoClave = FormatoticketcortoClave ;


            item.FormatoticketcortoNombre = FormatoticketcortoNombre ;


            item.TiposeleccioncatalogosatClave = TiposeleccioncatalogosatClave ;


            item.TiposeleccioncatalogosatNombre = TiposeleccioncatalogosatNombre ;


            item.PvcolorearClave = PvcolorearClave ?? "";


            item.PvcolorearNombre = PvcolorearNombre ?? "";


            item.ScreenconfigClave = ScreenconfigClave ;


            item.ScreenconfigNombre = ScreenconfigNombre ;


            item.TipovendedormovilClave = TipovendedormovilClave ;


            item.TipovendedormovilNombre = TipovendedormovilNombre ;


            item.TiposyncmovilClave = TiposyncmovilClave ;


            item.TiposyncmovilNombre = TiposyncmovilNombre ;


            item.FormatofactelectClave = FormatofactelectClave ;


            item.FormatofactelectNombre = FormatofactelectNombre ;


            item.Rutafirmaimagenes = Rutafirmaimagenes ;


            item.Autpreciolistabajo = Autpreciolistabajo ?? BoolCN.N;


            item.Listapreciomaylinea = Listapreciomaylinea ;


            item.Listaprecmedmaylinea = Listaprecmedmaylinea ;



        }

        public virtual void FillFromEntity(Parametro item)
        {

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            Lista_precio_defid = item.Lista_precio_defid;

            Imp_prod_def = item.Imp_prod_def;

            Estado_def = item.Estado_def;

            Lista_precio_traspaso = item.Lista_precio_traspaso;

            Promocion = item.Promocion;

            Cantidad = item.Cantidad;

            Utilidad = item.Utilidad;

            Fechaanterior = item.Fechaanterior;

            Fechaactual = item.Fechaactual;

            Fechaultima = item.Fechaultima;

            Max_inv_fis_cant = item.Max_inv_fis_cant;

            Inventory_email = item.Inventory_email;

            Id_dosletras = item.Id_dosletras;

            Habilitar_impexp_aut = item.Habilitar_impexp_aut;

            Comisionmedico = item.Comisionmedico;

            Comisiondependiente = item.Comisiondependiente;

            Ftphost = item.Ftphost;

            Ftpusuario = item.Ftpusuario;

            Ftppassword = item.Ftppassword;

            Smtphost = item.Smtphost;

            Smtpusuario = item.Smtpusuario;

            Smtppassword = item.Smtppassword;

            Smtpport = item.Smtpport;

            Smtpmailfrom = item.Smtpmailfrom;

            Smtpmailto = item.Smtpmailto;

            Cambiarprecio = item.Cambiarprecio;

            Listapreciominimo = item.Listapreciominimo;

            Compraentienda = item.Compraentienda;

            Header = item.Header;

            Footer = item.Footer;

            Hab_sel_cliente = item.Hab_sel_cliente;

            Hab_impr_cotizacion = item.Hab_impr_cotizacion;

            Mostrar_exis_suc = item.Mostrar_exis_suc;

            Req_aprobacion_inv = item.Req_aprobacion_inv;

            Reabrircortes = item.Reabrircortes;

            Descuentovale = item.Descuentovale;

            Ult_fecha_imp_prod = item.Ult_fecha_imp_prod;

            Imp_prod_total = item.Imp_prod_total;

            Nombre = item.Nombre;

            Calle = item.Calle;

            Numeroexterior = item.Numeroexterior;

            Numerointerior = item.Numerointerior;

            Colonia = item.Colonia;

            Municipio = item.Municipio;

            Estado = item.Estado;

            Codigopostal = item.Codigopostal;

            Fiscalcalle = item.Fiscalcalle;

            Fiscalnumerointerior = item.Fiscalnumerointerior;

            Fiscalnumeroexterior = item.Fiscalnumeroexterior;

            Fiscalcolonia = item.Fiscalcolonia;

            Fiscalmunicipio = item.Fiscalmunicipio;

            Fiscalestado = item.Fiscalestado;

            Fiscalcodigopostal = item.Fiscalcodigopostal;

            Certificadocsd = item.Certificadocsd;

            Timbradouser = item.Timbradouser;

            Timbradopassword = item.Timbradopassword;

            Timbradoarchivocertificado = item.Timbradoarchivocertificado;

            Timbradoarchivokey = item.Timbradoarchivokey;

            Timbradokey = item.Timbradokey;

            Fiscalnombre = item.Fiscalnombre;

            Seriesat = item.Seriesat;

            Usarfiscalesenexpedicion = item.Usarfiscalesenexpedicion;

            Hab_facturaelectronica = item.Hab_facturaelectronica;

            Footerventaapartado = item.Footerventaapartado;

            Encargadoid = item.Encargadoid;

            Porc_comisionencargado = item.Porc_comisionencargado;

            Porc_comisionvendedor = item.Porc_comisionvendedor;

            Ftpfolder = item.Ftpfolder;

            Ftpfolderpass = item.Ftpfolderpass;

            Seriesatdevolucion = item.Seriesatdevolucion;

            Cambiarprecioxuempaque = item.Cambiarprecioxuempaque;

            Cambiarprecioxpzacaja = item.Cambiarprecioxpzacaja;

            Prefijobascula = item.Prefijobascula;

            Longprodbascula = item.Longprodbascula;

            Longpesobascula = item.Longpesobascula;

            Listaprecioxuempaque = item.Listaprecioxuempaque;

            Listaprecioxpzacaja = item.Listaprecioxpzacaja;

            Listaprecioinimayo = item.Listaprecioinimayo;

            Hayvendedorpiso = item.Hayvendedorpiso;

            Envioautomaticoexistencias = item.Envioautomaticoexistencias;

            Monederomontominimo = item.Monederomontominimo;

            Monederoaplicar = item.Monederoaplicar;

            Monederocaducidad = item.Monederocaducidad;

            Imprimirnumeropiezas = item.Imprimirnumeropiezas;

            Pacnombre = item.Pacnombre;

            Pacusuario = item.Pacusuario;

            Cortepormail = item.Cortepormail;

            Rutareportes = item.Rutareportes;

            Doblecopiacredito = item.Doblecopiacredito;

            Doblecopiatraslado = item.Doblecopiatraslado;

            Camposcustomalimportar = item.Camposcustomalimportar;

            Recibolargoconfactura = item.Recibolargoconfactura;

            Recibolargoprinter = item.Recibolargoprinter;

            Recibolargopreview = item.Recibolargopreview;

            Preguntarrazonpreciomenor = item.Preguntarrazonpreciomenor;

            Preguntardatosentrega = item.Preguntardatosentrega;

            Fiscalregimen = item.Fiscalregimen;

            Cortacaducidad = item.Cortacaducidad;

            Retencioniva = item.Retencioniva;

            Retencionisr = item.Retencionisr;

            Arrendatario = item.Arrendatario;

            Rutaimagenesproducto = item.Rutaimagenesproducto;

            Mostrarimagenenventa = item.Mostrarimagenenventa;

            Mostrarmontoahorro = item.Mostrarmontoahorro;

            Smtpssl = item.Smtpssl;

            Mostrardescuentofactura = item.Mostrardescuentofactura;

            Exportcatalogoaux = item.Exportcatalogoaux;

            Uiventaconcantidad = item.Uiventaconcantidad;

            Fact_elect_folder = item.Fact_elect_folder;

            Pedidos_folder = item.Pedidos_folder;

            Prefijocliente = item.Prefijocliente;

            Fechainiciopedido = item.Fechainiciopedido;

            Mostrarpzacajaenfactura = item.Mostrarpzacajaenfactura;

            Desgloseieps = item.Desgloseieps;

            Cuentaieps = item.Cuentaieps;

            Dividir_rem_fact = item.Dividir_rem_fact;

            Webservice = item.Webservice;

            Minutilidad = item.Minutilidad;

            Manejasuperlistaprecio = item.Manejasuperlistaprecio;

            Manejaalmacen = item.Manejaalmacen;

            Tipodescuentoprodid = item.Tipodescuentoprodid;

            Manejareceta = item.Manejareceta;

            Autocompprod = item.Autocompprod;

            Lastchangeproddesc = item.Lastchangeproddesc;

            Tipoutilidadid = item.Tipoutilidadid;

            Manejaquota = item.Manejaquota;

            Touch = item.Touch;

            Esvendedormovil = item.Esvendedormovil;

            Cajasbotellas = item.Cajasbotellas;

            Precionetoenpv = item.Precionetoenpv;

            Tiposyncmovil = item.Tiposyncmovil;

            Mostrarflash = item.Mostrarflash;

            Ordenimpresion = item.Ordenimpresion;

            Autocompcliente = item.Autocompcliente;

            Lastchangeclientenombre = item.Lastchangeclientenombre;

            Precioxcajaenpv = item.Precioxcajaenpv;

            Localftphost = item.Localftphost;

            Localwebservice = item.Localwebservice;

            Usarconexionlocal = item.Usarconexionlocal;

            Movillastpreciodate = item.Movillastpreciodate;

            Lastchangeprecioprod = item.Lastchangeprecioprod;

            Movilcierrecobranza = item.Movilcierrecobranza;

            Movilcierreventa = item.Movilcierreventa;

            Mailtoinventario = item.Mailtoinventario;

            Rutarespaldoszip = item.Rutarespaldoszip;

            Screenconfig = item.Screenconfig;

            Promoenticket = item.Promoenticket;

            Tamanoletraticket = item.Tamanoletraticket;

            Manejakits = item.Manejakits;

            Campoimpocostorepoid = item.Campoimpocostorepoid;

            Rebajaespecial = item.Rebajaespecial;

            Habilitarrepl = item.Habilitarrepl;

            Bdlocalrepl = item.Bdlocalrepl;

            Pendmovilantesventa = item.Pendmovilantesventa;

            Preciosmovilantesventa = item.Preciosmovilantesventa;

            Recalcularcambiocliente = item.Recalcularcambiocliente;

            Tipovendedormovil = item.Tipovendedormovil;

            Vendedormovilid = item.Vendedormovilid;

            Bdserverws = item.Bdserverws;

            Bdmatrizmovil = item.Bdmatrizmovil;

            Prodcambioparamovil = item.Prodcambioparamovil;

            Movilprocesosurtido = item.Movilprocesosurtido;

            Movilverificarventa = item.Movilverificarventa;

            Pendmaxdias = item.Pendmaxdias;

            Reqautcancelarcoti = item.Reqautcancelarcoti;

            Reqautelimdetallecoti = item.Reqautelimdetallecoti;

            Abrircajonalfincorte = item.Abrircajonalfincorte;

            Habsurtidopostpuesto = item.Habsurtidopostpuesto;

            Clienteconsolidadoid = item.Clienteconsolidadoid;

            Rutareportessistema = item.Rutareportessistema;

            Doblecopiaremision = item.Doblecopiaremision;

            Reimpresionesconmarca = item.Reimpresionesconmarca;

            Habtotalizados = item.Habtotalizados;

            Multipletipovale = item.Multipletipovale;

            Descuentotipo1texto = item.Descuentotipo1texto;

            Descuentotipo1porc = item.Descuentotipo1porc;

            Descuentotipo2texto = item.Descuentotipo2texto;

            Descuentotipo2porc = item.Descuentotipo2porc;

            Descuentotipo3texto = item.Descuentotipo3texto;

            Descuentotipo3porc = item.Descuentotipo3porc;

            Descuentotipo4texto = item.Descuentotipo4texto;

            Descuentotipo4porc = item.Descuentotipo4porc;

            Habilitarlog = item.Habilitarlog;

            Rutarespaldo = item.Rutarespaldo;

            Fecharespaldo = item.Fecharespaldo;

            Manejarretirodecaja = item.Manejarretirodecaja;

            Montoretirocaja = item.Montoretirocaja;

            Aplicarmayoreoporlinea = item.Aplicarmayoreoporlinea;

            Comisionportarjeta = item.Comisionportarjeta;

            Piezasigualesmediomayoreo = item.Piezasigualesmediomayoreo;

            Piezasdifmediomayoreo = item.Piezasdifmediomayoreo;

            Piezasigualesmayoreo = item.Piezasigualesmayoreo;

            Piezasdifmayoreo = item.Piezasdifmayoreo;

            Comisiontarjetaempresa = item.Comisiontarjetaempresa;

            Ivacomisiontarjetaempresa = item.Ivacomisiontarjetaempresa;

            Preguntacancelacotizacion = item.Preguntacancelacotizacion;

            Habverificacioncxc = item.Habverificacioncxc;

            Mailejecutivo = item.Mailejecutivo;

            Ventasxcorteemail = item.Ventasxcorteemail;

            Habventasafuturo = item.Habventasafuturo;

            Serviciosemida = item.Serviciosemida;

            Fechaactualizacionemida = item.Fechaactualizacionemida;

            Formatoticketcortoid = item.Formatoticketcortoid;

            Seriesatabono = item.Seriesatabono;

            Habimpresioncortecajero = item.Habimpresioncortecajero;

            Habtrasladoporautorizacion = item.Habtrasladoporautorizacion;

            Habventasmostrador = item.Habventasmostrador;

            Timeoutpindistsale = item.Timeoutpindistsale;

            Timeoutlookup = item.Timeoutlookup;

            Rutaarchivosadjuntos = item.Rutaarchivosadjuntos;

            Timeoutpindistsaleserv = item.Timeoutpindistsaleserv;

            Habpagoservemida = item.Habpagoservemida;

            Fechaactualizacionemidaserv = item.Fechaactualizacionemidaserv;

            Habpromoxmontomin = item.Habpromoxmontomin;

            Formatofactelect = item.Formatofactelect;

            Montomaxsaldomenor = item.Montomaxsaldomenor;

            Emidarecargalineaid = item.Emidarecargalineaid;

            Emidarecargamarcaid = item.Emidarecargamarcaid;

            Emidarecargaproveedorid = item.Emidarecargaproveedorid;

            Emidaserviciolineaid = item.Emidaserviciolineaid;

            Emidaserviciomarcaid = item.Emidaserviciomarcaid;

            Emidaservicioproveedorid = item.Emidaservicioproveedorid;

            Emidaporcutilidadrecargas = item.Emidaporcutilidadrecargas;

            Emidautilidadpagoservicios = item.Emidautilidadpagoservicios;

            Preciosordenados = item.Preciosordenados;

            Decimalesencantidad = item.Decimalesencantidad;

            Eanpuederepetirse = item.Eanpuederepetirse;

            Bancomerhabpinpad = item.Bancomerhabpinpad;

            Hab_precioscliente = item.Hab_precioscliente;

            Cxcvalidartraslados = item.Cxcvalidartraslados;

            Preguntarsiesacredito = item.Preguntarsiesacredito;

            Habmensajeria = item.Habmensajeria;

            Wsmensajeria = item.Wsmensajeria;

            Ultmensajeid = item.Ultmensajeid;

            Habdesclineapersona = item.Habdesclineapersona;

            Manejarloteimportacion = item.Manejarloteimportacion;

            Manejagastosadic = item.Manejagastosadic;

            Caducidadminima = item.Caducidadminima;

            Precioajustedifinvid = item.Precioajustedifinvid;

            Habbotonpagovale = item.Habbotonpagovale;

            Unicavisitapordocto = item.Unicavisitapordocto;

            Plazoxproducto = item.Plazoxproducto;

            Autocompleteconexisenventa = item.Autocompleteconexisenventa;

            Ipwebserviceappinv = item.Ipwebserviceappinv;

            Rutabdappinventaro = item.Rutabdappinventaro;

            Rutadbfexistenciasuc = item.Rutadbfexistenciasuc;

            Almacenrecepcionid = item.Almacenrecepcionid;

            Aplicarcambiosprecauto = item.Aplicarcambiosprecauto;

            Numcancelactauto = item.Numcancelactauto;

            Numcancelactautousuario = item.Numcancelactautousuario;

            Manejacupones = item.Manejacupones;

            Hab_devoluciontraslado = item.Hab_devoluciontraslado;

            Hab_devolucionsurtidosuc = item.Hab_devolucionsurtidosuc;

            Versionwsexistencias = item.Versionwsexistencias;

            Manejaproductospromocion = item.Manejaproductospromocion;

            Sat_metodopagoid = item.Sat_metodopagoid;

            Sat_regimenfiscalid = item.Sat_regimenfiscalid;

            Tiposeleccioncatalogosat = item.Tiposeleccioncatalogosat;

            Precionetoengrids = item.Precionetoengrids;

            Versioncfdi = item.Versioncfdi;

            Pagoservconsolidado = item.Pagoservconsolidado;

            Mostrarinvinfoadicprod = item.Mostrarinvinfoadicprod;

            Wsespecialexistmatriz = item.Wsespecialexistmatriz;

            Hab_consolidadoautomatico = item.Hab_consolidadoautomatico;

            Rutareplicadorexe = item.Rutareplicadorexe;

            Ult_consolidadoautomatico = item.Ult_consolidadoautomatico;

            Ticketespecial = item.Ticketespecial;

            Ticketdefaultprinter = item.Ticketdefaultprinter;

            Recargasdefaultprinter = item.Recargasdefaultprinter;

            Piezacajaenticket = item.Piezacajaenticket;

            Numticketsabono = item.Numticketsabono;

            Pvcolorear = item.Pvcolorear;

            Generarfe = item.Generarfe;

            Intentosretirocaja = item.Intentosretirocaja;

            VendedormovilClave = item.Vendedormovilclave;

            Movil_ultcam_sesion = item.Movil_ultcam_sesion;

            Movil_tienevendedores = item.Movil_tienevendedores;

            Rutacatalogosupd = item.Rutacatalogosupd;

            Imprimircopiaalmacen = item.Imprimircopiaalmacen;

            Movil3_preimportar = item.Movil3_preimportar;

            Rutaimportadatos = item.Rutaimportadatos;

            Busquedatipo2 = item.Busquedatipo2;

            Agrupacionventaid = item.Agrupacionventaid;

            Consfactomitirvales = item.Consfactomitirvales;

            Destinobdvenmov = item.Destinobdvenmov;

            Doblecopiacontado = item.Doblecopiacontado;

            Desgloseiepsfactura = item.Desgloseiepsfactura;

            Rutapolizapdf = item.Rutapolizapdf;

            Imprimirbancoscorte = item.Imprimirbancoscorte;

            Pago_tarjmenorpreciolista = item.Pago_tarjmenorpreciolista;

            Impr_canc_venta = item.Impr_canc_venta;

            Retirocajaalcerrarcorte = item.Retirocajaalcerrarcorte;

            Pagotarjmenorpreciolistaall = item.Pagotarjmenorpreciolistaall;

            Kitsdef_ultact = item.Kitsdef_ultact;

            Kitsdef_unniv_ultact = item.Kitsdef_unniv_ultact;

            Preguntarservdom = item.Preguntarservdom;

            Habppc = item.Habppc;

            Soloabonoaplicado = item.Soloabonoaplicado;

            Versiontopeid = item.Versiontopeid;

            Versioncomisionid = item.Versioncomisionid;

            Maxcomisionxcliente = item.Maxcomisionxcliente;

            Imprformaventatrasl = item.Imprformaventatrasl;

            Habrevisionfinal = item.Habrevisionfinal;

            Recibolargocotiprinter = item.Recibolargocotiprinter;

            Habfondodinamico = item.Habfondodinamico;

            Habventaclisuc = item.Habventaclisuc;

            Segundoscicloftp = item.Segundoscicloftp;

            Diasmaxexpftp = item.Diasmaxexpftp;

            Diasmaximpftp = item.Diasmaximpftp;

            Wsdbf = item.Wsdbf;

            Habwsdbf = item.Habwsdbf;

            Comisiondebtarjetaempresa = item.Comisiondebtarjetaempresa;

            Comisiondebportarjeta = item.Comisiondebportarjeta;

            Factconsmaxpor = item.Factconsmaxpor;

            Doblecopiatarjeta = item.Doblecopiatarjeta;

            Fiscalfechacancelacion2 = item.Fiscalfechacancelacion2;

            Cantticketretiro = item.Cantticketretiro;

            Cantticketabrircorte = item.Cantticketabrircorte;

            Cantticketcompras = item.Cantticketcompras;

            Cantticketfondocaja = item.Cantticketfondocaja;

            Cantticketgastos = item.Cantticketgastos;

            Cantticketdepositos = item.Cantticketdepositos;

            Cantticketcierrecorte = item.Cantticketcierrecorte;

            Cantticketcierrebilletes = item.Cantticketcierrebilletes;

            Manejautilidadprecios = item.Manejautilidadprecios;

            Habmultplazocompra = item.Habmultplazocompra;

            Costorepoigualcostoult = item.Costorepoigualcostoult;

            Ticket_desc_vale_al_final = item.Ticket_desc_vale_al_final;

            Monederolistaprecioid = item.Monederolistaprecioid;

            Monederocamporef = item.Monederocamporef;

            Habsurtidoprevio = item.Habsurtidoprevio;

            Numticketscomanda = item.Numticketscomanda;

            Recibopreviewcomanda = item.Recibopreviewcomanda;

            Impresoracomanda = item.Impresoracomanda;

            Ticket_impr_desc2 = item.Ticket_impr_desc2;

            Seriecomprtraslsat = item.Seriecomprtraslsat;

            Habsurtidopostmovil = item.Habsurtidopostmovil;

            Porcutilidadlistado = item.Porcutilidadlistado;

            FormatoticketcortoClave = item.FormatoticketcortoClave;

            FormatoticketcortoNombre = item.FormatoticketcortoNombre;

            TiposeleccioncatalogosatClave = item.TiposeleccioncatalogosatClave;

            TiposeleccioncatalogosatNombre = item.TiposeleccioncatalogosatNombre;

            PvcolorearClave = item.PvcolorearClave;

            PvcolorearNombre = item.PvcolorearNombre;

            ScreenconfigClave = item.ScreenconfigClave;

            ScreenconfigNombre = item.ScreenconfigNombre;

            TipovendedormovilClave = item.TipovendedormovilClave;

            TipovendedormovilNombre = item.TipovendedormovilNombre;

            TiposyncmovilClave = item.TiposyncmovilClave;

            TiposyncmovilNombre = item.TiposyncmovilNombre;

            FormatofactelectClave = item.FormatofactelectClave;

            FormatofactelectNombre = item.FormatofactelectNombre;

            Rutafirmaimagenes = item.Rutafirmaimagenes;

            Autpreciolistabajo = item.Autpreciolistabajo;

            Listapreciomaylinea = item.Listapreciomaylinea;

            Listaprecmedmaylinea = item.Listaprecmedmaylinea;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

