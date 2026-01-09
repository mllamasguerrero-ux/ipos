
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
    public class WFEmpresaEditWFBindingModel : Validatable
    {

        public WFEmpresaEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private long? _Estado;
        [XmlAttribute]
        public long? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private string? _Cp;
        [XmlAttribute]
        public string? Cp { get => _Cp; set { if (RaiseAcceptPendingChange(value, _Cp)) { _Cp = value; OnPropertyChanged(); } } }

        private string? _Telefono;
        [XmlAttribute]
        public string? Telefono { get => _Telefono; set { if (RaiseAcceptPendingChange(value, _Telefono)) { _Telefono = value; OnPropertyChanged(); } } }

        private string? _Fax;
        [XmlAttribute]
        public string? Fax { get => _Fax; set { if (RaiseAcceptPendingChange(value, _Fax)) { _Fax = value; OnPropertyChanged(); } } }

        private string? _Correoe;
        [XmlAttribute]
        public string? Correoe { get => _Correoe; set { if (RaiseAcceptPendingChange(value, _Correoe)) { _Correoe = value; OnPropertyChanged(); } } }

        private string? _Paginaweb;
        [XmlAttribute]
        public string? Paginaweb { get => _Paginaweb; set { if (RaiseAcceptPendingChange(value, _Paginaweb)) { _Paginaweb = value; OnPropertyChanged(); } } }

        private string? _Rfc;
        [XmlAttribute]
        public string? Rfc { get => _Rfc; set { if (RaiseAcceptPendingChange(value, _Rfc)) { _Rfc = value; OnPropertyChanged(); } } }

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

        private BoolCN? _Req_aprobacion_invcombobox;
        [XmlAttribute]
        public BoolCN? Req_aprobacion_invcombobox { get => _Req_aprobacion_invcombobox; set { if (RaiseAcceptPendingChange(value, _Req_aprobacion_invcombobox)) { _Req_aprobacion_invcombobox = value; OnPropertyChanged(); } } }

        private string? _Id_dosletras;
        [XmlAttribute]
        public string? Id_dosletras { get => _Id_dosletras; set { if (RaiseAcceptPendingChange(value, _Id_dosletras)) { _Id_dosletras = value; OnPropertyChanged(); } } }

        private BoolCN? _Reabrircortescombobox;
        [XmlAttribute]
        public BoolCN? Reabrircortescombobox { get => _Reabrircortescombobox; set { if (RaiseAcceptPendingChange(value, _Reabrircortescombobox)) { _Reabrircortescombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Habilitar_impexp_autcombobox;
        [XmlAttribute]
        public BoolCN? Habilitar_impexp_autcombobox { get => _Habilitar_impexp_autcombobox; set { if (RaiseAcceptPendingChange(value, _Habilitar_impexp_autcombobox)) { _Habilitar_impexp_autcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cortepormail;
        [XmlAttribute]
        public BoolCN? Cortepormail { get => _Cortepormail; set { if (RaiseAcceptPendingChange(value, _Cortepormail)) { _Cortepormail = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcambiarprecio;
        [XmlAttribute]
        public BoolCN? Cbcambiarprecio { get => _Cbcambiarprecio; set { if (RaiseAcceptPendingChange(value, _Cbcambiarprecio)) { _Cbcambiarprecio = value; OnPropertyChanged(); } } }

        private BoolCN? _Ventasxcorteemail;
        [XmlAttribute]
        public BoolCN? Ventasxcorteemail { get => _Ventasxcorteemail; set { if (RaiseAcceptPendingChange(value, _Ventasxcorteemail)) { _Ventasxcorteemail = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_sel_clientecombobox;
        [XmlAttribute]
        public BoolCN? Hab_sel_clientecombobox { get => _Hab_sel_clientecombobox; set { if (RaiseAcceptPendingChange(value, _Hab_sel_clientecombobox)) { _Hab_sel_clientecombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Imp_prod_totalcombobox;
        [XmlAttribute]
        public BoolCN? Imp_prod_totalcombobox { get => _Imp_prod_totalcombobox; set { if (RaiseAcceptPendingChange(value, _Imp_prod_totalcombobox)) { _Imp_prod_totalcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_impr_cotizacioncombobox;
        [XmlAttribute]
        public BoolCN? Hab_impr_cotizacioncombobox { get => _Hab_impr_cotizacioncombobox; set { if (RaiseAcceptPendingChange(value, _Hab_impr_cotizacioncombobox)) { _Hab_impr_cotizacioncombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_facturaelectronicacombobox;
        [XmlAttribute]
        public BoolCN? Hab_facturaelectronicacombobox { get => _Hab_facturaelectronicacombobox; set { if (RaiseAcceptPendingChange(value, _Hab_facturaelectronicacombobox)) { _Hab_facturaelectronicacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrar_exis_succombobox;
        [XmlAttribute]
        public BoolCN? Mostrar_exis_succombobox { get => _Mostrar_exis_succombobox; set { if (RaiseAcceptPendingChange(value, _Mostrar_exis_succombobox)) { _Mostrar_exis_succombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Habventaclisuc;
        [XmlAttribute]
        public BoolCN? Habventaclisuc { get => _Habventaclisuc; set { if (RaiseAcceptPendingChange(value, _Habventaclisuc)) { _Habventaclisuc = value; OnPropertyChanged(); } } }

        private string? _Prefijobascula;
        [XmlAttribute]
        public string? Prefijobascula { get => _Prefijobascula; set { if (RaiseAcceptPendingChange(value, _Prefijobascula)) { _Prefijobascula = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntacancelacotizacion;
        [XmlAttribute]
        public BoolCN? Preguntacancelacotizacion { get => _Preguntacancelacotizacion; set { if (RaiseAcceptPendingChange(value, _Preguntacancelacotizacion)) { _Preguntacancelacotizacion = value; OnPropertyChanged(); } } }

        private int? _Longpesobascula;
        [XmlAttribute]
        public int? Longpesobascula { get => _Longpesobascula; set { if (RaiseAcceptPendingChange(value, _Longpesobascula)) { _Longpesobascula = value; OnPropertyChanged(); } } }

        private BoolCN? _Habfondodinamico;
        [XmlAttribute]
        public BoolCN? Habfondodinamico { get => _Habfondodinamico; set { if (RaiseAcceptPendingChange(value, _Habfondodinamico)) { _Habfondodinamico = value; OnPropertyChanged(); } } }

        private int? _Longprodbascula;
        [XmlAttribute]
        public int? Longprodbascula { get => _Longprodbascula; set { if (RaiseAcceptPendingChange(value, _Longprodbascula)) { _Longprodbascula = value; OnPropertyChanged(); } } }

        private long? _Lista_precio_def;
        [XmlAttribute]
        public long? Lista_precio_def { get => _Lista_precio_def; set { if (RaiseAcceptPendingChange(value, _Lista_precio_def)) { _Lista_precio_def = value; OnPropertyChanged(); } } }

        private decimal? _Imp_prod_def;
        [XmlAttribute]
        public decimal? Imp_prod_def { get => _Imp_prod_def; set { if (RaiseAcceptPendingChange(value, _Imp_prod_def)) { _Imp_prod_def = value; OnPropertyChanged(); } } }

        private BoolCN? _Habilitarlogcombobox;
        [XmlAttribute]
        public BoolCN? Habilitarlogcombobox { get => _Habilitarlogcombobox; set { if (RaiseAcceptPendingChange(value, _Habilitarlogcombobox)) { _Habilitarlogcombobox = value; OnPropertyChanged(); } } }

        private long? _Listaprecioinimayocombobox;
        [XmlAttribute]
        public long? Listaprecioinimayocombobox { get => _Listaprecioinimayocombobox; set { if (RaiseAcceptPendingChange(value, _Listaprecioinimayocombobox)) { _Listaprecioinimayocombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejareceta;
        [XmlAttribute]
        public BoolCN? Manejareceta { get => _Manejareceta; set { if (RaiseAcceptPendingChange(value, _Manejareceta)) { _Manejareceta = value; OnPropertyChanged(); } } }

        private BoolCN? _Hayvendedorpisocombobox;
        [XmlAttribute]
        public BoolCN? Hayvendedorpisocombobox { get => _Hayvendedorpisocombobox; set { if (RaiseAcceptPendingChange(value, _Hayvendedorpisocombobox)) { _Hayvendedorpisocombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Envioautomaticoexistenciascombobox;
        [XmlAttribute]
        public BoolCN? Envioautomaticoexistenciascombobox { get => _Envioautomaticoexistenciascombobox; set { if (RaiseAcceptPendingChange(value, _Envioautomaticoexistenciascombobox)) { _Envioautomaticoexistenciascombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarimagenenventa;
        [XmlAttribute]
        public BoolCN? Mostrarimagenenventa { get => _Mostrarimagenenventa; set { if (RaiseAcceptPendingChange(value, _Mostrarimagenenventa)) { _Mostrarimagenenventa = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarrazonpreciomenorcombobox;
        [XmlAttribute]
        public BoolCN? Preguntarrazonpreciomenorcombobox { get => _Preguntarrazonpreciomenorcombobox; set { if (RaiseAcceptPendingChange(value, _Preguntarrazonpreciomenorcombobox)) { _Preguntarrazonpreciomenorcombobox = value; OnPropertyChanged(); } } }

        private long? _Tipodescuentoprodid;
        [XmlAttribute]
        public long? Tipodescuentoprodid { get => _Tipodescuentoprodid; set { if (RaiseAcceptPendingChange(value, _Tipodescuentoprodid)) { _Tipodescuentoprodid = value; OnPropertyChanged(); } } }

        private BoolCN? _Dividir_rem_fact;
        [XmlAttribute]
        public BoolCN? Dividir_rem_fact { get => _Dividir_rem_fact; set { if (RaiseAcceptPendingChange(value, _Dividir_rem_fact)) { _Dividir_rem_fact = value; OnPropertyChanged(); } } }

        private string? _Rutaimagenesproducto;
        [XmlAttribute]
        public string? Rutaimagenesproducto { get => _Rutaimagenesproducto; set { if (RaiseAcceptPendingChange(value, _Rutaimagenesproducto)) { _Rutaimagenesproducto = value; OnPropertyChanged(); } } }

        private decimal? _Minutilidad;
        [XmlAttribute]
        public decimal? Minutilidad { get => _Minutilidad; set { if (RaiseAcceptPendingChange(value, _Minutilidad)) { _Minutilidad = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejaalmacen;
        [XmlAttribute]
        public BoolCN? Manejaalmacen { get => _Manejaalmacen; set { if (RaiseAcceptPendingChange(value, _Manejaalmacen)) { _Manejaalmacen = value; OnPropertyChanged(); } } }

        private string? _Prefijocliente;
        [XmlAttribute]
        public string? Prefijocliente { get => _Prefijocliente; set { if (RaiseAcceptPendingChange(value, _Prefijocliente)) { _Prefijocliente = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejasuperlistaprecio;
        [XmlAttribute]
        public BoolCN? Manejasuperlistaprecio { get => _Manejasuperlistaprecio; set { if (RaiseAcceptPendingChange(value, _Manejasuperlistaprecio)) { _Manejasuperlistaprecio = value; OnPropertyChanged(); } } }

        private BoolCN? _Soloabonoaplicado;
        [XmlAttribute]
        public BoolCN? Soloabonoaplicado { get => _Soloabonoaplicado; set { if (RaiseAcceptPendingChange(value, _Soloabonoaplicado)) { _Soloabonoaplicado = value; OnPropertyChanged(); } } }

        private long? _Agrupacionventaid;
        [XmlAttribute]
        public long? Agrupacionventaid { get => _Agrupacionventaid; set { if (RaiseAcceptPendingChange(value, _Agrupacionventaid)) { _Agrupacionventaid = value; OnPropertyChanged(); } } }

        private string? _AgrupacionventaidClave;
        [XmlAttribute]
        public string? AgrupacionventaidClave { get => _AgrupacionventaidClave; set { if (RaiseAcceptPendingChange(value, _AgrupacionventaidClave)) { _AgrupacionventaidClave = value; OnPropertyChanged(); } } }

        private string? _AgrupacionventaidNombre;
        [XmlAttribute]
        public string? AgrupacionventaidNombre { get => _AgrupacionventaidNombre; set { if (RaiseAcceptPendingChange(value, _AgrupacionventaidNombre)) { _AgrupacionventaidNombre = value; OnPropertyChanged(); } } }

        private long? _Estado_def;
        [XmlAttribute]
        public long? Estado_def { get => _Estado_def; set { if (RaiseAcceptPendingChange(value, _Estado_def)) { _Estado_def = value; OnPropertyChanged(); } } }

        private long? _Sucursalcombobox;
        [XmlAttribute]
        public long? Sucursalcombobox { get => _Sucursalcombobox; set { if (RaiseAcceptPendingChange(value, _Sucursalcombobox)) { _Sucursalcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Habventasafuturocombobox;
        [XmlAttribute]
        public BoolCN? Habventasafuturocombobox { get => _Habventasafuturocombobox; set { if (RaiseAcceptPendingChange(value, _Habventasafuturocombobox)) { _Habventasafuturocombobox = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Ultimafecha;
        [XmlAttribute]
        public DateTimeOffset? Ultimafecha { get => _Ultimafecha; set { if (RaiseAcceptPendingChange(value, _Ultimafecha)) { _Ultimafecha = value; OnPropertyChanged(); } } }

        private string? _Smtphost;
        [XmlAttribute]
        public string? Smtphost { get => _Smtphost; set { if (RaiseAcceptPendingChange(value, _Smtphost)) { _Smtphost = value; OnPropertyChanged(); } } }

        private string? _Wsmensajeria;
        [XmlAttribute]
        public string? Wsmensajeria { get => _Wsmensajeria; set { if (RaiseAcceptPendingChange(value, _Wsmensajeria)) { _Wsmensajeria = value; OnPropertyChanged(); } } }

        private string? _Smtpusuario;
        [XmlAttribute]
        public string? Smtpusuario { get => _Smtpusuario; set { if (RaiseAcceptPendingChange(value, _Smtpusuario)) { _Smtpusuario = value; OnPropertyChanged(); } } }

        private string? _Mailtoinventario;
        [XmlAttribute]
        public string? Mailtoinventario { get => _Mailtoinventario; set { if (RaiseAcceptPendingChange(value, _Mailtoinventario)) { _Mailtoinventario = value; OnPropertyChanged(); } } }

        private string? _Smtppassword;
        [XmlAttribute]
        public string? Smtppassword { get => _Smtppassword; set { if (RaiseAcceptPendingChange(value, _Smtppassword)) { _Smtppassword = value; OnPropertyChanged(); } } }

        private string? _Mailejecutivo;
        [XmlAttribute]
        public string? Mailejecutivo { get => _Mailejecutivo; set { if (RaiseAcceptPendingChange(value, _Mailejecutivo)) { _Mailejecutivo = value; OnPropertyChanged(); } } }

        private int? _Smtpport;
        [XmlAttribute]
        public int? Smtpport { get => _Smtpport; set { if (RaiseAcceptPendingChange(value, _Smtpport)) { _Smtpport = value; OnPropertyChanged(); } } }

        private string? _Rutarespaldoszip;
        [XmlAttribute]
        public string? Rutarespaldoszip { get => _Rutarespaldoszip; set { if (RaiseAcceptPendingChange(value, _Rutarespaldoszip)) { _Rutarespaldoszip = value; OnPropertyChanged(); } } }

        private BoolCN? _Smtpsslcombobox;
        [XmlAttribute]
        public BoolCN? Smtpsslcombobox { get => _Smtpsslcombobox; set { if (RaiseAcceptPendingChange(value, _Smtpsslcombobox)) { _Smtpsslcombobox = value; OnPropertyChanged(); } } }

        private string? _Rutareportessistema;
        [XmlAttribute]
        public string? Rutareportessistema { get => _Rutareportessistema; set { if (RaiseAcceptPendingChange(value, _Rutareportessistema)) { _Rutareportessistema = value; OnPropertyChanged(); } } }

        private string? _Smtpmailfrom;
        [XmlAttribute]
        public string? Smtpmailfrom { get => _Smtpmailfrom; set { if (RaiseAcceptPendingChange(value, _Smtpmailfrom)) { _Smtpmailfrom = value; OnPropertyChanged(); } } }

        private string? _Txtrutarespaldo;
        [XmlAttribute]
        public string? Txtrutarespaldo { get => _Txtrutarespaldo; set { if (RaiseAcceptPendingChange(value, _Txtrutarespaldo)) { _Txtrutarespaldo = value; OnPropertyChanged(); } } }

        private string? _Smtpmailto;
        [XmlAttribute]
        public string? Smtpmailto { get => _Smtpmailto; set { if (RaiseAcceptPendingChange(value, _Smtpmailto)) { _Smtpmailto = value; OnPropertyChanged(); } } }

        private string? _Ftpfolder;
        [XmlAttribute]
        public string? Ftpfolder { get => _Ftpfolder; set { if (RaiseAcceptPendingChange(value, _Ftpfolder)) { _Ftpfolder = value; OnPropertyChanged(); } } }

        private string? _Localwebservice;
        [XmlAttribute]
        public string? Localwebservice { get => _Localwebservice; set { if (RaiseAcceptPendingChange(value, _Localwebservice)) { _Localwebservice = value; OnPropertyChanged(); } } }

        private string? _Ftpfolderpass;
        [XmlAttribute]
        public string? Ftpfolderpass { get => _Ftpfolderpass; set { if (RaiseAcceptPendingChange(value, _Ftpfolderpass)) { _Ftpfolderpass = value; OnPropertyChanged(); } } }

        private string? _Txtrutaadjuntararchivo;
        [XmlAttribute]
        public string? Txtrutaadjuntararchivo { get => _Txtrutaadjuntararchivo; set { if (RaiseAcceptPendingChange(value, _Txtrutaadjuntararchivo)) { _Txtrutaadjuntararchivo = value; OnPropertyChanged(); } } }

        private string? _Rutareportes;
        [XmlAttribute]
        public string? Rutareportes { get => _Rutareportes; set { if (RaiseAcceptPendingChange(value, _Rutareportes)) { _Rutareportes = value; OnPropertyChanged(); } } }

        private int? _Versionwsexistencias;
        [XmlAttribute]
        public int? Versionwsexistencias { get => _Versionwsexistencias; set { if (RaiseAcceptPendingChange(value, _Versionwsexistencias)) { _Versionwsexistencias = value; OnPropertyChanged(); } } }

        private string? _Pedidos_folder;
        [XmlAttribute]
        public string? Pedidos_folder { get => _Pedidos_folder; set { if (RaiseAcceptPendingChange(value, _Pedidos_folder)) { _Pedidos_folder = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_devoluciontrasladocombobox;
        [XmlAttribute]
        public BoolCN? Hab_devoluciontrasladocombobox { get => _Hab_devoluciontrasladocombobox; set { if (RaiseAcceptPendingChange(value, _Hab_devoluciontrasladocombobox)) { _Hab_devoluciontrasladocombobox = value; OnPropertyChanged(); } } }

        private string? _Ftphost;
        [XmlAttribute]
        public string? Ftphost { get => _Ftphost; set { if (RaiseAcceptPendingChange(value, _Ftphost)) { _Ftphost = value; OnPropertyChanged(); } } }

        private string? _Fact_elect_folder;
        [XmlAttribute]
        public string? Fact_elect_folder { get => _Fact_elect_folder; set { if (RaiseAcceptPendingChange(value, _Fact_elect_folder)) { _Fact_elect_folder = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_devolucionsurtidosuccombobox;
        [XmlAttribute]
        public BoolCN? Hab_devolucionsurtidosuccombobox { get => _Hab_devolucionsurtidosuccombobox; set { if (RaiseAcceptPendingChange(value, _Hab_devolucionsurtidosuccombobox)) { _Hab_devolucionsurtidosuccombobox = value; OnPropertyChanged(); } } }

        private string? _Localftphost;
        [XmlAttribute]
        public string? Localftphost { get => _Localftphost; set { if (RaiseAcceptPendingChange(value, _Localftphost)) { _Localftphost = value; OnPropertyChanged(); } } }

        private string? _Webservice;
        [XmlAttribute]
        public string? Webservice { get => _Webservice; set { if (RaiseAcceptPendingChange(value, _Webservice)) { _Webservice = value; OnPropertyChanged(); } } }

        private BoolCN? _Habilitarrepl;
        [XmlAttribute]
        public BoolCN? Habilitarrepl { get => _Habilitarrepl; set { if (RaiseAcceptPendingChange(value, _Habilitarrepl)) { _Habilitarrepl = value; OnPropertyChanged(); } } }

        private string? _Txtrutadbfexistenciasuc;
        [XmlAttribute]
        public string? Txtrutadbfexistenciasuc { get => _Txtrutadbfexistenciasuc; set { if (RaiseAcceptPendingChange(value, _Txtrutadbfexistenciasuc)) { _Txtrutadbfexistenciasuc = value; OnPropertyChanged(); } } }

        private string? _Wsespecialexistmatriz;
        [XmlAttribute]
        public string? Wsespecialexistmatriz { get => _Wsespecialexistmatriz; set { if (RaiseAcceptPendingChange(value, _Wsespecialexistmatriz)) { _Wsespecialexistmatriz = value; OnPropertyChanged(); } } }

        private string? _Bdlocalrepl;
        [XmlAttribute]
        public string? Bdlocalrepl { get => _Bdlocalrepl; set { if (RaiseAcceptPendingChange(value, _Bdlocalrepl)) { _Bdlocalrepl = value; OnPropertyChanged(); } } }

        private string? _Rutacatalogosupd;
        [XmlAttribute]
        public string? Rutacatalogosupd { get => _Rutacatalogosupd; set { if (RaiseAcceptPendingChange(value, _Rutacatalogosupd)) { _Rutacatalogosupd = value; OnPropertyChanged(); } } }

        private string? _Txtrutareplicadorexe;
        [XmlAttribute]
        public string? Txtrutareplicadorexe { get => _Txtrutareplicadorexe; set { if (RaiseAcceptPendingChange(value, _Txtrutareplicadorexe)) { _Txtrutareplicadorexe = value; OnPropertyChanged(); } } }

        private string? _Rutaimportadatos;
        [XmlAttribute]
        public string? Rutaimportadatos { get => _Rutaimportadatos; set { if (RaiseAcceptPendingChange(value, _Rutaimportadatos)) { _Rutaimportadatos = value; OnPropertyChanged(); } } }

        private BoolCN? _Unicavisitapordocto;
        [XmlAttribute]
        public BoolCN? Unicavisitapordocto { get => _Unicavisitapordocto; set { if (RaiseAcceptPendingChange(value, _Unicavisitapordocto)) { _Unicavisitapordocto = value; OnPropertyChanged(); } } }

        private string? _Ftpusuario;
        [XmlAttribute]
        public string? Ftpusuario { get => _Ftpusuario; set { if (RaiseAcceptPendingChange(value, _Ftpusuario)) { _Ftpusuario = value; OnPropertyChanged(); } } }

        private BoolCN? _Usarconexionlocal;
        [XmlAttribute]
        public BoolCN? Usarconexionlocal { get => _Usarconexionlocal; set { if (RaiseAcceptPendingChange(value, _Usarconexionlocal)) { _Usarconexionlocal = value; OnPropertyChanged(); } } }

        private string? _Ftppassword;
        [XmlAttribute]
        public string? Ftppassword { get => _Ftppassword; set { if (RaiseAcceptPendingChange(value, _Ftppassword)) { _Ftppassword = value; OnPropertyChanged(); } } }

        private BoolCN? _Habmensajeriacombobox;
        [XmlAttribute]
        public BoolCN? Habmensajeriacombobox { get => _Habmensajeriacombobox; set { if (RaiseAcceptPendingChange(value, _Habmensajeriacombobox)) { _Habmensajeriacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Habtrasladoporautorizacioncombobox;
        [XmlAttribute]
        public BoolCN? Habtrasladoporautorizacioncombobox { get => _Habtrasladoporautorizacioncombobox; set { if (RaiseAcceptPendingChange(value, _Habtrasladoporautorizacioncombobox)) { _Habtrasladoporautorizacioncombobox = value; OnPropertyChanged(); } } }

        private string? _Footer;
        [XmlAttribute]
        public string? Footer { get => _Footer; set { if (RaiseAcceptPendingChange(value, _Footer)) { _Footer = value; OnPropertyChanged(); } } }

        private BoolCN? _Reqautelimdetallecoticombobox;
        [XmlAttribute]
        public BoolCN? Reqautelimdetallecoticombobox { get => _Reqautelimdetallecoticombobox; set { if (RaiseAcceptPendingChange(value, _Reqautelimdetallecoticombobox)) { _Reqautelimdetallecoticombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbhabventasmostrador;
        [XmlAttribute]
        public BoolCN? Cbhabventasmostrador { get => _Cbhabventasmostrador; set { if (RaiseAcceptPendingChange(value, _Cbhabventasmostrador)) { _Cbhabventasmostrador = value; OnPropertyChanged(); } } }

        private string? _Footerventaapartado;
        [XmlAttribute]
        public string? Footerventaapartado { get => _Footerventaapartado; set { if (RaiseAcceptPendingChange(value, _Footerventaapartado)) { _Footerventaapartado = value; OnPropertyChanged(); } } }

        private int? _Pendmaxdias;
        [XmlAttribute]
        public int? Pendmaxdias { get => _Pendmaxdias; set { if (RaiseAcceptPendingChange(value, _Pendmaxdias)) { _Pendmaxdias = value; OnPropertyChanged(); } } }

        private long? _Tamanoletraticket;
        [XmlAttribute]
        public long? Tamanoletraticket { get => _Tamanoletraticket; set { if (RaiseAcceptPendingChange(value, _Tamanoletraticket)) { _Tamanoletraticket = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimirbancoscortecombobox;
        [XmlAttribute]
        public BoolCN? Imprimirbancoscortecombobox { get => _Imprimirbancoscortecombobox; set { if (RaiseAcceptPendingChange(value, _Imprimirbancoscortecombobox)) { _Imprimirbancoscortecombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Promoenticketcombobox;
        [XmlAttribute]
        public BoolCN? Promoenticketcombobox { get => _Promoenticketcombobox; set { if (RaiseAcceptPendingChange(value, _Promoenticketcombobox)) { _Promoenticketcombobox = value; OnPropertyChanged(); } } }

        private int? _Cantticketretiro;
        [XmlAttribute]
        public int? Cantticketretiro { get => _Cantticketretiro; set { if (RaiseAcceptPendingChange(value, _Cantticketretiro)) { _Cantticketretiro = value; OnPropertyChanged(); } } }

        private int? _Cantticketgastos;
        [XmlAttribute]
        public int? Cantticketgastos { get => _Cantticketgastos; set { if (RaiseAcceptPendingChange(value, _Cantticketgastos)) { _Cantticketgastos = value; OnPropertyChanged(); } } }

        private int? _Cantticketcompras;
        [XmlAttribute]
        public int? Cantticketcompras { get => _Cantticketcompras; set { if (RaiseAcceptPendingChange(value, _Cantticketcompras)) { _Cantticketcompras = value; OnPropertyChanged(); } } }

        private int? _Cantticketabrircorte;
        [XmlAttribute]
        public int? Cantticketabrircorte { get => _Cantticketabrircorte; set { if (RaiseAcceptPendingChange(value, _Cantticketabrircorte)) { _Cantticketabrircorte = value; OnPropertyChanged(); } } }

        private int? _Cantticketcierrecorte;
        [XmlAttribute]
        public int? Cantticketcierrecorte { get => _Cantticketcierrecorte; set { if (RaiseAcceptPendingChange(value, _Cantticketcierrecorte)) { _Cantticketcierrecorte = value; OnPropertyChanged(); } } }

        private int? _Cantticketcierrebilletes;
        [XmlAttribute]
        public int? Cantticketcierrebilletes { get => _Cantticketcierrebilletes; set { if (RaiseAcceptPendingChange(value, _Cantticketcierrebilletes)) { _Cantticketcierrebilletes = value; OnPropertyChanged(); } } }

        private int? _Cantticketdepositos;
        [XmlAttribute]
        public int? Cantticketdepositos { get => _Cantticketdepositos; set { if (RaiseAcceptPendingChange(value, _Cantticketdepositos)) { _Cantticketdepositos = value; OnPropertyChanged(); } } }

        private int? _Cantticketfondocaja;
        [XmlAttribute]
        public int? Cantticketfondocaja { get => _Cantticketfondocaja; set { if (RaiseAcceptPendingChange(value, _Cantticketfondocaja)) { _Cantticketfondocaja = value; OnPropertyChanged(); } } }

        private string? _Recibolargocotiprinter;
        [XmlAttribute]
        public string? Recibolargocotiprinter { get => _Recibolargocotiprinter; set { if (RaiseAcceptPendingChange(value, _Recibolargocotiprinter)) { _Recibolargocotiprinter = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprformaventatrasl;
        [XmlAttribute]
        public BoolCN? Imprformaventatrasl { get => _Imprformaventatrasl; set { if (RaiseAcceptPendingChange(value, _Imprformaventatrasl)) { _Imprformaventatrasl = value; OnPropertyChanged(); } } }

        private long? _Cmbpreciodifinv;
        [XmlAttribute]
        public long? Cmbpreciodifinv { get => _Cmbpreciodifinv; set { if (RaiseAcceptPendingChange(value, _Cmbpreciodifinv)) { _Cmbpreciodifinv = value; OnPropertyChanged(); } } }

        private string? _Ticketdefaultprinter;
        [XmlAttribute]
        public string? Ticketdefaultprinter { get => _Ticketdefaultprinter; set { if (RaiseAcceptPendingChange(value, _Ticketdefaultprinter)) { _Ticketdefaultprinter = value; OnPropertyChanged(); } } }

        private string? _Recargasdefaultprinter;
        [XmlAttribute]
        public string? Recargasdefaultprinter { get => _Recargasdefaultprinter; set { if (RaiseAcceptPendingChange(value, _Recargasdefaultprinter)) { _Recargasdefaultprinter = value; OnPropertyChanged(); } } }

        private BoolCN? _Impr_canc_ventacombobox;
        [XmlAttribute]
        public BoolCN? Impr_canc_ventacombobox { get => _Impr_canc_ventacombobox; set { if (RaiseAcceptPendingChange(value, _Impr_canc_ventacombobox)) { _Impr_canc_ventacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Doblecopiaremisioncombobox;
        [XmlAttribute]
        public BoolCN? Doblecopiaremisioncombobox { get => _Doblecopiaremisioncombobox; set { if (RaiseAcceptPendingChange(value, _Doblecopiaremisioncombobox)) { _Doblecopiaremisioncombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Reimpresionesconmarcacombobox;
        [XmlAttribute]
        public BoolCN? Reimpresionesconmarcacombobox { get => _Reimpresionesconmarcacombobox; set { if (RaiseAcceptPendingChange(value, _Reimpresionesconmarcacombobox)) { _Reimpresionesconmarcacombobox = value; OnPropertyChanged(); } } }

        private long? _Formatoticketcortoidcombobox;
        [XmlAttribute]
        public long? Formatoticketcortoidcombobox { get => _Formatoticketcortoidcombobox; set { if (RaiseAcceptPendingChange(value, _Formatoticketcortoidcombobox)) { _Formatoticketcortoidcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntardatosentregacombobox;
        [XmlAttribute]
        public BoolCN? Preguntardatosentregacombobox { get => _Preguntardatosentregacombobox; set { if (RaiseAcceptPendingChange(value, _Preguntardatosentregacombobox)) { _Preguntardatosentregacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimirnumeropiezascombobox;
        [XmlAttribute]
        public BoolCN? Imprimirnumeropiezascombobox { get => _Imprimirnumeropiezascombobox; set { if (RaiseAcceptPendingChange(value, _Imprimirnumeropiezascombobox)) { _Imprimirnumeropiezascombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticket_desc_vale_al_finalcombobox;
        [XmlAttribute]
        public BoolCN? Ticket_desc_vale_al_finalcombobox { get => _Ticket_desc_vale_al_finalcombobox; set { if (RaiseAcceptPendingChange(value, _Ticket_desc_vale_al_finalcombobox)) { _Ticket_desc_vale_al_finalcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticket_impr_desc2combobox;
        [XmlAttribute]
        public BoolCN? Ticket_impr_desc2combobox { get => _Ticket_impr_desc2combobox; set { if (RaiseAcceptPendingChange(value, _Ticket_impr_desc2combobox)) { _Ticket_impr_desc2combobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarpzacajaenfacturacombobox;
        [XmlAttribute]
        public BoolCN? Mostrarpzacajaenfacturacombobox { get => _Mostrarpzacajaenfacturacombobox; set { if (RaiseAcceptPendingChange(value, _Mostrarpzacajaenfacturacombobox)) { _Mostrarpzacajaenfacturacombobox = value; OnPropertyChanged(); } } }

        private int? _Doblecopiacredito;
        [XmlAttribute]
        public int? Doblecopiacredito { get => _Doblecopiacredito; set { if (RaiseAcceptPendingChange(value, _Doblecopiacredito)) { _Doblecopiacredito = value; OnPropertyChanged(); } } }

        private int? _Doblecopiatarjeta;
        [XmlAttribute]
        public int? Doblecopiatarjeta { get => _Doblecopiatarjeta; set { if (RaiseAcceptPendingChange(value, _Doblecopiatarjeta)) { _Doblecopiatarjeta = value; OnPropertyChanged(); } } }

        private int? _Doblecopiatraslado;
        [XmlAttribute]
        public int? Doblecopiatraslado { get => _Doblecopiatraslado; set { if (RaiseAcceptPendingChange(value, _Doblecopiatraslado)) { _Doblecopiatraslado = value; OnPropertyChanged(); } } }

        private string? _Recibolargoprinter;
        [XmlAttribute]
        public string? Recibolargoprinter { get => _Recibolargoprinter; set { if (RaiseAcceptPendingChange(value, _Recibolargoprinter)) { _Recibolargoprinter = value; OnPropertyChanged(); } } }

        private BoolCN? _Recibolargopreviewcombobox;
        [XmlAttribute]
        public BoolCN? Recibolargopreviewcombobox { get => _Recibolargopreviewcombobox; set { if (RaiseAcceptPendingChange(value, _Recibolargopreviewcombobox)) { _Recibolargopreviewcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Recibolargoconfacturacombobox;
        [XmlAttribute]
        public BoolCN? Recibolargoconfacturacombobox { get => _Recibolargoconfacturacombobox; set { if (RaiseAcceptPendingChange(value, _Recibolargoconfacturacombobox)) { _Recibolargoconfacturacombobox = value; OnPropertyChanged(); } } }

        private long? _Ordenimpresioncombobox;
        [XmlAttribute]
        public long? Ordenimpresioncombobox { get => _Ordenimpresioncombobox; set { if (RaiseAcceptPendingChange(value, _Ordenimpresioncombobox)) { _Ordenimpresioncombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarmontoahorrocombobox;
        [XmlAttribute]
        public BoolCN? Mostrarmontoahorrocombobox { get => _Mostrarmontoahorrocombobox; set { if (RaiseAcceptPendingChange(value, _Mostrarmontoahorrocombobox)) { _Mostrarmontoahorrocombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrardescuentofacturacombobox;
        [XmlAttribute]
        public BoolCN? Mostrardescuentofacturacombobox { get => _Mostrardescuentofacturacombobox; set { if (RaiseAcceptPendingChange(value, _Mostrardescuentofacturacombobox)) { _Mostrardescuentofacturacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Uiventaconcantidadcombobox;
        [XmlAttribute]
        public BoolCN? Uiventaconcantidadcombobox { get => _Uiventaconcantidadcombobox; set { if (RaiseAcceptPendingChange(value, _Uiventaconcantidadcombobox)) { _Uiventaconcantidadcombobox = value; OnPropertyChanged(); } } }

        private string? _Ticketespecial;
        [XmlAttribute]
        public string? Ticketespecial { get => _Ticketespecial; set { if (RaiseAcceptPendingChange(value, _Ticketespecial)) { _Ticketespecial = value; OnPropertyChanged(); } } }

        private BoolCN? _Abrircajonalfincortecombobox;
        [XmlAttribute]
        public BoolCN? Abrircajonalfincortecombobox { get => _Abrircajonalfincortecombobox; set { if (RaiseAcceptPendingChange(value, _Abrircajonalfincortecombobox)) { _Abrircajonalfincortecombobox = value; OnPropertyChanged(); } } }

        private string? _Header;
        [XmlAttribute]
        public string? Header { get => _Header; set { if (RaiseAcceptPendingChange(value, _Header)) { _Header = value; OnPropertyChanged(); } } }

        private BoolCN? _Imprimircopiaalmacencombobox;
        [XmlAttribute]
        public BoolCN? Imprimircopiaalmacencombobox { get => _Imprimircopiaalmacencombobox; set { if (RaiseAcceptPendingChange(value, _Imprimircopiaalmacencombobox)) { _Imprimircopiaalmacencombobox = value; OnPropertyChanged(); } } }

        private int? _Numticketsabono;
        [XmlAttribute]
        public int? Numticketsabono { get => _Numticketsabono; set { if (RaiseAcceptPendingChange(value, _Numticketsabono)) { _Numticketsabono = value; OnPropertyChanged(); } } }

        private BoolCN? _Piezacajaenticketcombobox;
        [XmlAttribute]
        public BoolCN? Piezacajaenticketcombobox { get => _Piezacajaenticketcombobox; set { if (RaiseAcceptPendingChange(value, _Piezacajaenticketcombobox)) { _Piezacajaenticketcombobox = value; OnPropertyChanged(); } } }

        private int? _Doblecopiacontado;
        [XmlAttribute]
        public int? Doblecopiacontado { get => _Doblecopiacontado; set { if (RaiseAcceptPendingChange(value, _Doblecopiacontado)) { _Doblecopiacontado = value; OnPropertyChanged(); } } }

        private BoolCN? _Habimpresioncortecajerocombobox;
        [XmlAttribute]
        public BoolCN? Habimpresioncortecajerocombobox { get => _Habimpresioncortecajerocombobox; set { if (RaiseAcceptPendingChange(value, _Habimpresioncortecajerocombobox)) { _Habimpresioncortecajerocombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Reqautcancelarcoticombobox;
        [XmlAttribute]
        public BoolCN? Reqautcancelarcoticombobox { get => _Reqautcancelarcoticombobox; set { if (RaiseAcceptPendingChange(value, _Reqautcancelarcoticombobox)) { _Reqautcancelarcoticombobox = value; OnPropertyChanged(); } } }

        private decimal? _Maxcomisionxcliente;
        [XmlAttribute]
        public decimal? Maxcomisionxcliente { get => _Maxcomisionxcliente; set { if (RaiseAcceptPendingChange(value, _Maxcomisionxcliente)) { _Maxcomisionxcliente = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejaquota;
        [XmlAttribute]
        public BoolCN? Manejaquota { get => _Manejaquota; set { if (RaiseAcceptPendingChange(value, _Manejaquota)) { _Manejaquota = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejarretirodecaja;
        [XmlAttribute]
        public BoolCN? Manejarretirodecaja { get => _Manejarretirodecaja; set { if (RaiseAcceptPendingChange(value, _Manejarretirodecaja)) { _Manejarretirodecaja = value; OnPropertyChanged(); } } }

        private decimal? _Montoretirocaja;
        [XmlAttribute]
        public decimal? Montoretirocaja { get => _Montoretirocaja; set { if (RaiseAcceptPendingChange(value, _Montoretirocaja)) { _Montoretirocaja = value; OnPropertyChanged(); } } }

        private long? _Tipoutilidadid;
        [XmlAttribute]
        public long? Tipoutilidadid { get => _Tipoutilidadid; set { if (RaiseAcceptPendingChange(value, _Tipoutilidadid)) { _Tipoutilidadid = value; OnPropertyChanged(); } } }

        private int? _Intentosretirocaja;
        [XmlAttribute]
        public int? Intentosretirocaja { get => _Intentosretirocaja; set { if (RaiseAcceptPendingChange(value, _Intentosretirocaja)) { _Intentosretirocaja = value; OnPropertyChanged(); } } }

        private decimal? _Factconsmaxpor;
        [XmlAttribute]
        public decimal? Factconsmaxpor { get => _Factconsmaxpor; set { if (RaiseAcceptPendingChange(value, _Factconsmaxpor)) { _Factconsmaxpor = value; OnPropertyChanged(); } } }

        private decimal? _Comisiondebportarjeta;
        [XmlAttribute]
        public decimal? Comisiondebportarjeta { get => _Comisiondebportarjeta; set { if (RaiseAcceptPendingChange(value, _Comisiondebportarjeta)) { _Comisiondebportarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Comisionportarjeta;
        [XmlAttribute]
        public decimal? Comisionportarjeta { get => _Comisionportarjeta; set { if (RaiseAcceptPendingChange(value, _Comisionportarjeta)) { _Comisionportarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Comisiondebtarjetaempresa;
        [XmlAttribute]
        public decimal? Comisiondebtarjetaempresa { get => _Comisiondebtarjetaempresa; set { if (RaiseAcceptPendingChange(value, _Comisiondebtarjetaempresa)) { _Comisiondebtarjetaempresa = value; OnPropertyChanged(); } } }

        private decimal? _Comisiontarjetaempresa;
        [XmlAttribute]
        public decimal? Comisiontarjetaempresa { get => _Comisiontarjetaempresa; set { if (RaiseAcceptPendingChange(value, _Comisiontarjetaempresa)) { _Comisiontarjetaempresa = value; OnPropertyChanged(); } } }

        private decimal? _Ivacomisiontarjetaempresa;
        [XmlAttribute]
        public decimal? Ivacomisiontarjetaempresa { get => _Ivacomisiontarjetaempresa; set { if (RaiseAcceptPendingChange(value, _Ivacomisiontarjetaempresa)) { _Ivacomisiontarjetaempresa = value; OnPropertyChanged(); } } }

        private decimal? _Porc_comisionencargado;
        [XmlAttribute]
        public decimal? Porc_comisionencargado { get => _Porc_comisionencargado; set { if (RaiseAcceptPendingChange(value, _Porc_comisionencargado)) { _Porc_comisionencargado = value; OnPropertyChanged(); } } }

        private decimal? _Comisionmedico;
        [XmlAttribute]
        public decimal? Comisionmedico { get => _Comisionmedico; set { if (RaiseAcceptPendingChange(value, _Comisionmedico)) { _Comisionmedico = value; OnPropertyChanged(); } } }

        private BoolCN? _Pagotarjmenorpreciolistaall;
        [XmlAttribute]
        public BoolCN? Pagotarjmenorpreciolistaall { get => _Pagotarjmenorpreciolistaall; set { if (RaiseAcceptPendingChange(value, _Pagotarjmenorpreciolistaall)) { _Pagotarjmenorpreciolistaall = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicarmayoreoporlinea;
        [XmlAttribute]
        public BoolCN? Aplicarmayoreoporlinea { get => _Aplicarmayoreoporlinea; set { if (RaiseAcceptPendingChange(value, _Aplicarmayoreoporlinea)) { _Aplicarmayoreoporlinea = value; OnPropertyChanged(); } } }

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

        private BoolCN? _Cambiarprecioxpzacajacombobox;
        [XmlAttribute]
        public BoolCN? Cambiarprecioxpzacajacombobox { get => _Cambiarprecioxpzacajacombobox; set { if (RaiseAcceptPendingChange(value, _Cambiarprecioxpzacajacombobox)) { _Cambiarprecioxpzacajacombobox = value; OnPropertyChanged(); } } }

        private long? _Listaprecioxpzacajacombobox;
        [XmlAttribute]
        public long? Listaprecioxpzacajacombobox { get => _Listaprecioxpzacajacombobox; set { if (RaiseAcceptPendingChange(value, _Listaprecioxpzacajacombobox)) { _Listaprecioxpzacajacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cambiarprecioxuempaquecombobox;
        [XmlAttribute]
        public BoolCN? Cambiarprecioxuempaquecombobox { get => _Cambiarprecioxuempaquecombobox; set { if (RaiseAcceptPendingChange(value, _Cambiarprecioxuempaquecombobox)) { _Cambiarprecioxuempaquecombobox = value; OnPropertyChanged(); } } }

        private long? _Listaprecioxuempaquecombobox;
        [XmlAttribute]
        public long? Listaprecioxuempaquecombobox { get => _Listaprecioxuempaquecombobox; set { if (RaiseAcceptPendingChange(value, _Listaprecioxuempaquecombobox)) { _Listaprecioxuempaquecombobox = value; OnPropertyChanged(); } } }

        private decimal? _Montomaxsaldomenornumeric;
        [XmlAttribute]
        public decimal? Montomaxsaldomenornumeric { get => _Montomaxsaldomenornumeric; set { if (RaiseAcceptPendingChange(value, _Montomaxsaldomenornumeric)) { _Montomaxsaldomenornumeric = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarsiesacredito;
        [XmlAttribute]
        public BoolCN? Preguntarsiesacredito { get => _Preguntarsiesacredito; set { if (RaiseAcceptPendingChange(value, _Preguntarsiesacredito)) { _Preguntarsiesacredito = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarservdom;
        [XmlAttribute]
        public BoolCN? Preguntarservdom { get => _Preguntarservdom; set { if (RaiseAcceptPendingChange(value, _Preguntarservdom)) { _Preguntarservdom = value; OnPropertyChanged(); } } }

        private BoolCN? _Retirocajaalcerrarcorte;
        [XmlAttribute]
        public BoolCN? Retirocajaalcerrarcorte { get => _Retirocajaalcerrarcorte; set { if (RaiseAcceptPendingChange(value, _Retirocajaalcerrarcorte)) { _Retirocajaalcerrarcorte = value; OnPropertyChanged(); } } }

        private decimal? _Porc_comisionvendedor;
        [XmlAttribute]
        public decimal? Porc_comisionvendedor { get => _Porc_comisionvendedor; set { if (RaiseAcceptPendingChange(value, _Porc_comisionvendedor)) { _Porc_comisionvendedor = value; OnPropertyChanged(); } } }

        private decimal? _Comisiondependiente;
        [XmlAttribute]
        public decimal? Comisiondependiente { get => _Comisiondependiente; set { if (RaiseAcceptPendingChange(value, _Comisiondependiente)) { _Comisiondependiente = value; OnPropertyChanged(); } } }

        private long? _Encargadoid;
        [XmlAttribute]
        public long? Encargadoid { get => _Encargadoid; set { if (RaiseAcceptPendingChange(value, _Encargadoid)) { _Encargadoid = value; OnPropertyChanged(); } } }

        private string? _EncargadoidClave;
        [XmlAttribute]
        public string? EncargadoidClave { get => _EncargadoidClave; set { if (RaiseAcceptPendingChange(value, _EncargadoidClave)) { _EncargadoidClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoidNombre;
        [XmlAttribute]
        public string? EncargadoidNombre { get => _EncargadoidNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoidNombre)) { _EncargadoidNombre = value; OnPropertyChanged(); } } }

        private int? _Versioncomisionid;
        [XmlAttribute]
        public int? Versioncomisionid { get => _Versioncomisionid; set { if (RaiseAcceptPendingChange(value, _Versioncomisionid)) { _Versioncomisionid = value; OnPropertyChanged(); } } }

        private string? _Texto5;
        [XmlAttribute]
        public string? Texto5 { get => _Texto5; set { if (RaiseAcceptPendingChange(value, _Texto5)) { _Texto5 = value; OnPropertyChanged(); } } }

        private string? _Texto6;
        [XmlAttribute]
        public string? Texto6 { get => _Texto6; set { if (RaiseAcceptPendingChange(value, _Texto6)) { _Texto6 = value; OnPropertyChanged(); } } }

        private BoolCN? _Rebajaespecial;
        [XmlAttribute]
        public BoolCN? Rebajaespecial { get => _Rebajaespecial; set { if (RaiseAcceptPendingChange(value, _Rebajaespecial)) { _Rebajaespecial = value; OnPropertyChanged(); } } }

        private string? _Numero1;
        [XmlAttribute]
        public string? Numero1 { get => _Numero1; set { if (RaiseAcceptPendingChange(value, _Numero1)) { _Numero1 = value; OnPropertyChanged(); } } }

        private string? _Numero2;
        [XmlAttribute]
        public string? Numero2 { get => _Numero2; set { if (RaiseAcceptPendingChange(value, _Numero2)) { _Numero2 = value; OnPropertyChanged(); } } }

        private int? _Versiontopeid;
        [XmlAttribute]
        public int? Versiontopeid { get => _Versiontopeid; set { if (RaiseAcceptPendingChange(value, _Versiontopeid)) { _Versiontopeid = value; OnPropertyChanged(); } } }

        private string? _Numero3;
        [XmlAttribute]
        public string? Numero3 { get => _Numero3; set { if (RaiseAcceptPendingChange(value, _Numero3)) { _Numero3 = value; OnPropertyChanged(); } } }

        private string? _Numero4;
        [XmlAttribute]
        public string? Numero4 { get => _Numero4; set { if (RaiseAcceptPendingChange(value, _Numero4)) { _Numero4 = value; OnPropertyChanged(); } } }

        private long? _Listapreciominimocombobox;
        [XmlAttribute]
        public long? Listapreciominimocombobox { get => _Listapreciominimocombobox; set { if (RaiseAcceptPendingChange(value, _Listapreciominimocombobox)) { _Listapreciominimocombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Costorepoigualcostoultcombobox;
        [XmlAttribute]
        public BoolCN? Costorepoigualcostoultcombobox { get => _Costorepoigualcostoultcombobox; set { if (RaiseAcceptPendingChange(value, _Costorepoigualcostoultcombobox)) { _Costorepoigualcostoultcombobox = value; OnPropertyChanged(); } } }

        private string? _Fecha1;
        [XmlAttribute]
        public string? Fecha1 { get => _Fecha1; set { if (RaiseAcceptPendingChange(value, _Fecha1)) { _Fecha1 = value; OnPropertyChanged(); } } }

        private string? _Fecha2;
        [XmlAttribute]
        public string? Fecha2 { get => _Fecha2; set { if (RaiseAcceptPendingChange(value, _Fecha2)) { _Fecha2 = value; OnPropertyChanged(); } } }

        private long? _Campoimpocostorepo;
        [XmlAttribute]
        public long? Campoimpocostorepo { get => _Campoimpocostorepo; set { if (RaiseAcceptPendingChange(value, _Campoimpocostorepo)) { _Campoimpocostorepo = value; OnPropertyChanged(); } } }

        private int? _Cortacaducidad;
        [XmlAttribute]
        public int? Cortacaducidad { get => _Cortacaducidad; set { if (RaiseAcceptPendingChange(value, _Cortacaducidad)) { _Cortacaducidad = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarflashcombobox;
        [XmlAttribute]
        public BoolCN? Mostrarflashcombobox { get => _Mostrarflashcombobox; set { if (RaiseAcceptPendingChange(value, _Mostrarflashcombobox)) { _Mostrarflashcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cajasbotellas;
        [XmlAttribute]
        public BoolCN? Cajasbotellas { get => _Cajasbotellas; set { if (RaiseAcceptPendingChange(value, _Cajasbotellas)) { _Cajasbotellas = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejakits;
        [XmlAttribute]
        public BoolCN? Manejakits { get => _Manejakits; set { if (RaiseAcceptPendingChange(value, _Manejakits)) { _Manejakits = value; OnPropertyChanged(); } } }

        private BoolCN? _Habrevisionfinal;
        [XmlAttribute]
        public BoolCN? Habrevisionfinal { get => _Habrevisionfinal; set { if (RaiseAcceptPendingChange(value, _Habrevisionfinal)) { _Habrevisionfinal = value; OnPropertyChanged(); } } }

        private int? _Caducidadminima;
        [XmlAttribute]
        public int? Caducidadminima { get => _Caducidadminima; set { if (RaiseAcceptPendingChange(value, _Caducidadminima)) { _Caducidadminima = value; OnPropertyChanged(); } } }

        private BoolCN? _Habverificacioncxc;
        [XmlAttribute]
        public BoolCN? Habverificacioncxc { get => _Habverificacioncxc; set { if (RaiseAcceptPendingChange(value, _Habverificacioncxc)) { _Habverificacioncxc = value; OnPropertyChanged(); } } }

        private BoolCN? _Precionetoenpv;
        [XmlAttribute]
        public BoolCN? Precionetoenpv { get => _Precionetoenpv; set { if (RaiseAcceptPendingChange(value, _Precionetoenpv)) { _Precionetoenpv = value; OnPropertyChanged(); } } }

        private BoolCN? _Precioxcajaenpv;
        [XmlAttribute]
        public BoolCN? Precioxcajaenpv { get => _Precioxcajaenpv; set { if (RaiseAcceptPendingChange(value, _Precioxcajaenpv)) { _Precioxcajaenpv = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejautilidadprecios;
        [XmlAttribute]
        public BoolCN? Manejautilidadprecios { get => _Manejautilidadprecios; set { if (RaiseAcceptPendingChange(value, _Manejautilidadprecios)) { _Manejautilidadprecios = value; OnPropertyChanged(); } } }

        private BoolCN? _Habsurtidopostpuesto;
        [XmlAttribute]
        public BoolCN? Habsurtidopostpuesto { get => _Habsurtidopostpuesto; set { if (RaiseAcceptPendingChange(value, _Habsurtidopostpuesto)) { _Habsurtidopostpuesto = value; OnPropertyChanged(); } } }

        private int? _Decimalesencantidad;
        [XmlAttribute]
        public int? Decimalesencantidad { get => _Decimalesencantidad; set { if (RaiseAcceptPendingChange(value, _Decimalesencantidad)) { _Decimalesencantidad = value; OnPropertyChanged(); } } }

        private BoolCN? _Eanpuederepetirse;
        [XmlAttribute]
        public BoolCN? Eanpuederepetirse { get => _Eanpuederepetirse; set { if (RaiseAcceptPendingChange(value, _Eanpuederepetirse)) { _Eanpuederepetirse = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_precioscliente;
        [XmlAttribute]
        public BoolCN? Hab_precioscliente { get => _Hab_precioscliente; set { if (RaiseAcceptPendingChange(value, _Hab_precioscliente)) { _Hab_precioscliente = value; OnPropertyChanged(); } } }

        private BoolCN? _Habmultplazocompra;
        [XmlAttribute]
        public BoolCN? Habmultplazocompra { get => _Habmultplazocompra; set { if (RaiseAcceptPendingChange(value, _Habmultplazocompra)) { _Habmultplazocompra = value; OnPropertyChanged(); } } }

        private BoolCN? _Preciosordenados;
        [XmlAttribute]
        public BoolCN? Preciosordenados { get => _Preciosordenados; set { if (RaiseAcceptPendingChange(value, _Preciosordenados)) { _Preciosordenados = value; OnPropertyChanged(); } } }

        private BoolCN? _Autocompprod;
        [XmlAttribute]
        public BoolCN? Autocompprod { get => _Autocompprod; set { if (RaiseAcceptPendingChange(value, _Autocompprod)) { _Autocompprod = value; OnPropertyChanged(); } } }

        private BoolCN? _Cxcvalidartraslados;
        [XmlAttribute]
        public BoolCN? Cxcvalidartraslados { get => _Cxcvalidartraslados; set { if (RaiseAcceptPendingChange(value, _Cxcvalidartraslados)) { _Cxcvalidartraslados = value; OnPropertyChanged(); } } }

        private BoolCN? _Habpromoxmontomin;
        [XmlAttribute]
        public BoolCN? Habpromoxmontomin { get => _Habpromoxmontomin; set { if (RaiseAcceptPendingChange(value, _Habpromoxmontomin)) { _Habpromoxmontomin = value; OnPropertyChanged(); } } }

        private BoolCN? _Habsurtidoprevio;
        [XmlAttribute]
        public BoolCN? Habsurtidoprevio { get => _Habsurtidoprevio; set { if (RaiseAcceptPendingChange(value, _Habsurtidoprevio)) { _Habsurtidoprevio = value; OnPropertyChanged(); } } }

        private BoolCN? _Autocompleteconexistenciacb;
        [XmlAttribute]
        public BoolCN? Autocompleteconexistenciacb { get => _Autocompleteconexistenciacb; set { if (RaiseAcceptPendingChange(value, _Autocompleteconexistenciacb)) { _Autocompleteconexistenciacb = value; OnPropertyChanged(); } } }

        private BoolCN? _Actprecautocb;
        [XmlAttribute]
        public BoolCN? Actprecautocb { get => _Actprecautocb; set { if (RaiseAcceptPendingChange(value, _Actprecautocb)) { _Actprecautocb = value; OnPropertyChanged(); } } }

        private long? _Almacenrecepcionid;
        [XmlAttribute]
        public long? Almacenrecepcionid { get => _Almacenrecepcionid; set { if (RaiseAcceptPendingChange(value, _Almacenrecepcionid)) { _Almacenrecepcionid = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbbusquedatipo2;
        [XmlAttribute]
        public BoolCN? Cbbusquedatipo2 { get => _Cbbusquedatipo2; set { if (RaiseAcceptPendingChange(value, _Cbbusquedatipo2)) { _Cbbusquedatipo2 = value; OnPropertyChanged(); } } }

        private int? _Cancelxactnumeric;
        [XmlAttribute]
        public int? Cancelxactnumeric { get => _Cancelxactnumeric; set { if (RaiseAcceptPendingChange(value, _Cancelxactnumeric)) { _Cancelxactnumeric = value; OnPropertyChanged(); } } }

        private BoolCN? _Autocompcliente;
        [XmlAttribute]
        public BoolCN? Autocompcliente { get => _Autocompcliente; set { if (RaiseAcceptPendingChange(value, _Autocompcliente)) { _Autocompcliente = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbplazosxproducto;
        [XmlAttribute]
        public BoolCN? Cbplazosxproducto { get => _Cbplazosxproducto; set { if (RaiseAcceptPendingChange(value, _Cbplazosxproducto)) { _Cbplazosxproducto = value; OnPropertyChanged(); } } }

        private BoolCN? _Precionetoengrids;
        [XmlAttribute]
        public BoolCN? Precionetoengrids { get => _Precionetoengrids; set { if (RaiseAcceptPendingChange(value, _Precionetoengrids)) { _Precionetoengrids = value; OnPropertyChanged(); } } }

        private string? _Texto1;
        [XmlAttribute]
        public string? Texto1 { get => _Texto1; set { if (RaiseAcceptPendingChange(value, _Texto1)) { _Texto1 = value; OnPropertyChanged(); } } }

        private string? _Texto2;
        [XmlAttribute]
        public string? Texto2 { get => _Texto2; set { if (RaiseAcceptPendingChange(value, _Texto2)) { _Texto2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Recalcularcambiocliente;
        [XmlAttribute]
        public BoolCN? Recalcularcambiocliente { get => _Recalcularcambiocliente; set { if (RaiseAcceptPendingChange(value, _Recalcularcambiocliente)) { _Recalcularcambiocliente = value; OnPropertyChanged(); } } }

        private string? _Texto3;
        [XmlAttribute]
        public string? Texto3 { get => _Texto3; set { if (RaiseAcceptPendingChange(value, _Texto3)) { _Texto3 = value; OnPropertyChanged(); } } }

        private string? _Texto4;
        [XmlAttribute]
        public string? Texto4 { get => _Texto4; set { if (RaiseAcceptPendingChange(value, _Texto4)) { _Texto4 = value; OnPropertyChanged(); } } }

        private string? _Fiscalmunicipio;
        [XmlAttribute]
        public string? Fiscalmunicipio { get => _Fiscalmunicipio; set { if (RaiseAcceptPendingChange(value, _Fiscalmunicipio)) { _Fiscalmunicipio = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private string? _Seriecomprtraslsat;
        [XmlAttribute]
        public string? Seriecomprtraslsat { get => _Seriecomprtraslsat; set { if (RaiseAcceptPendingChange(value, _Seriecomprtraslsat)) { _Seriecomprtraslsat = value; OnPropertyChanged(); } } }

        private long? _Fiscalestado;
        [XmlAttribute]
        public long? Fiscalestado { get => _Fiscalestado; set { if (RaiseAcceptPendingChange(value, _Fiscalestado)) { _Fiscalestado = value; OnPropertyChanged(); } } }

        private string? _Seriesatdevolucion;
        [XmlAttribute]
        public string? Seriesatdevolucion { get => _Seriesatdevolucion; set { if (RaiseAcceptPendingChange(value, _Seriesatdevolucion)) { _Seriesatdevolucion = value; OnPropertyChanged(); } } }

        private string? _Fiscalcodigopostal;
        [XmlAttribute]
        public string? Fiscalcodigopostal { get => _Fiscalcodigopostal; set { if (RaiseAcceptPendingChange(value, _Fiscalcodigopostal)) { _Fiscalcodigopostal = value; OnPropertyChanged(); } } }

        private string? _Seriesatabono;
        [XmlAttribute]
        public string? Seriesatabono { get => _Seriesatabono; set { if (RaiseAcceptPendingChange(value, _Seriesatabono)) { _Seriesatabono = value; OnPropertyChanged(); } } }

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

        private DateTimeOffset? _Fiscalfechacancelacion2;
        [XmlAttribute]
        public DateTimeOffset? Fiscalfechacancelacion2 { get => _Fiscalfechacancelacion2; set { if (RaiseAcceptPendingChange(value, _Fiscalfechacancelacion2)) { _Fiscalfechacancelacion2 = value; OnPropertyChanged(); } } }

        private string? _Timbradoarchivokey;
        [XmlAttribute]
        public string? Timbradoarchivokey { get => _Timbradoarchivokey; set { if (RaiseAcceptPendingChange(value, _Timbradoarchivokey)) { _Timbradoarchivokey = value; OnPropertyChanged(); } } }

        private string? _Timbradokey;
        [XmlAttribute]
        public string? Timbradokey { get => _Timbradokey; set { if (RaiseAcceptPendingChange(value, _Timbradokey)) { _Timbradokey = value; OnPropertyChanged(); } } }

        private string? _Fiscalnombre;
        [XmlAttribute]
        public string? Fiscalnombre { get => _Fiscalnombre; set { if (RaiseAcceptPendingChange(value, _Fiscalnombre)) { _Fiscalnombre = value; OnPropertyChanged(); } } }

        private string? _Pacnombre;
        [XmlAttribute]
        public string? Pacnombre { get => _Pacnombre; set { if (RaiseAcceptPendingChange(value, _Pacnombre)) { _Pacnombre = value; OnPropertyChanged(); } } }

        private long? _Formatofacturacombobox;
        [XmlAttribute]
        public long? Formatofacturacombobox { get => _Formatofacturacombobox; set { if (RaiseAcceptPendingChange(value, _Formatofacturacombobox)) { _Formatofacturacombobox = value; OnPropertyChanged(); } } }

        private string? _Pacusuario;
        [XmlAttribute]
        public string? Pacusuario { get => _Pacusuario; set { if (RaiseAcceptPendingChange(value, _Pacusuario)) { _Pacusuario = value; OnPropertyChanged(); } } }

        private long? _Clienteconsolidadoid;
        [XmlAttribute]
        public long? Clienteconsolidadoid { get => _Clienteconsolidadoid; set { if (RaiseAcceptPendingChange(value, _Clienteconsolidadoid)) { _Clienteconsolidadoid = value; OnPropertyChanged(); } } }

        private string? _ClienteconsolidadoidClave;
        [XmlAttribute]
        public string? ClienteconsolidadoidClave { get => _ClienteconsolidadoidClave; set { if (RaiseAcceptPendingChange(value, _ClienteconsolidadoidClave)) { _ClienteconsolidadoidClave = value; OnPropertyChanged(); } } }

        private string? _ClienteconsolidadoidNombre;
        [XmlAttribute]
        public string? ClienteconsolidadoidNombre { get => _ClienteconsolidadoidNombre; set { if (RaiseAcceptPendingChange(value, _ClienteconsolidadoidNombre)) { _ClienteconsolidadoidNombre = value; OnPropertyChanged(); } } }

        private long? _Regimensatfb;
        [XmlAttribute]
        public long? Regimensatfb { get => _Regimensatfb; set { if (RaiseAcceptPendingChange(value, _Regimensatfb)) { _Regimensatfb = value; OnPropertyChanged(); } } }

        private string? _RegimensatfbClave;
        [XmlAttribute]
        public string? RegimensatfbClave { get => _RegimensatfbClave; set { if (RaiseAcceptPendingChange(value, _RegimensatfbClave)) { _RegimensatfbClave = value; OnPropertyChanged(); } } }

        private string? _RegimensatfbNombre;
        [XmlAttribute]
        public string? RegimensatfbNombre { get => _RegimensatfbNombre; set { if (RaiseAcceptPendingChange(value, _RegimensatfbNombre)) { _RegimensatfbNombre = value; OnPropertyChanged(); } } }

        private string? _Fiscalregimen;
        [XmlAttribute]
        public string? Fiscalregimen { get => _Fiscalregimen; set { if (RaiseAcceptPendingChange(value, _Fiscalregimen)) { _Fiscalregimen = value; OnPropertyChanged(); } } }

        private BoolCN? _Usarfiscalesenexpedicion;
        [XmlAttribute]
        public BoolCN? Usarfiscalesenexpedicion { get => _Usarfiscalesenexpedicion; set { if (RaiseAcceptPendingChange(value, _Usarfiscalesenexpedicion)) { _Usarfiscalesenexpedicion = value; OnPropertyChanged(); } } }

        private decimal? _Retencioniva;
        [XmlAttribute]
        public decimal? Retencioniva { get => _Retencioniva; set { if (RaiseAcceptPendingChange(value, _Retencioniva)) { _Retencioniva = value; OnPropertyChanged(); } } }

        private BoolCN? _Arrendatario;
        [XmlAttribute]
        public BoolCN? Arrendatario { get => _Arrendatario; set { if (RaiseAcceptPendingChange(value, _Arrendatario)) { _Arrendatario = value; OnPropertyChanged(); } } }

        private BoolCN? _Desgloseieps;
        [XmlAttribute]
        public BoolCN? Desgloseieps { get => _Desgloseieps; set { if (RaiseAcceptPendingChange(value, _Desgloseieps)) { _Desgloseieps = value; OnPropertyChanged(); } } }

        private BoolCN? _Desgloseiepsfactura;
        [XmlAttribute]
        public BoolCN? Desgloseiepsfactura { get => _Desgloseiepsfactura; set { if (RaiseAcceptPendingChange(value, _Desgloseiepsfactura)) { _Desgloseiepsfactura = value; OnPropertyChanged(); } } }

        private string? _Cuentaieps;
        [XmlAttribute]
        public string? Cuentaieps { get => _Cuentaieps; set { if (RaiseAcceptPendingChange(value, _Cuentaieps)) { _Cuentaieps = value; OnPropertyChanged(); } } }

        private decimal? _Retencionisr;
        [XmlAttribute]
        public decimal? Retencionisr { get => _Retencionisr; set { if (RaiseAcceptPendingChange(value, _Retencionisr)) { _Retencionisr = value; OnPropertyChanged(); } } }

        private long? _Metpagosatid;
        [XmlAttribute]
        public long? Metpagosatid { get => _Metpagosatid; set { if (RaiseAcceptPendingChange(value, _Metpagosatid)) { _Metpagosatid = value; OnPropertyChanged(); } } }

        private string? _MetpagosatidClave;
        [XmlAttribute]
        public string? MetpagosatidClave { get => _MetpagosatidClave; set { if (RaiseAcceptPendingChange(value, _MetpagosatidClave)) { _MetpagosatidClave = value; OnPropertyChanged(); } } }

        private string? _MetpagosatidNombre;
        [XmlAttribute]
        public string? MetpagosatidNombre { get => _MetpagosatidNombre; set { if (RaiseAcceptPendingChange(value, _MetpagosatidNombre)) { _MetpagosatidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Pagoservconsolidado;
        [XmlAttribute]
        public BoolCN? Pagoservconsolidado { get => _Pagoservconsolidado; set { if (RaiseAcceptPendingChange(value, _Pagoservconsolidado)) { _Pagoservconsolidado = value; OnPropertyChanged(); } } }

        private BoolCN? _Generarfe;
        [XmlAttribute]
        public BoolCN? Generarfe { get => _Generarfe; set { if (RaiseAcceptPendingChange(value, _Generarfe)) { _Generarfe = value; OnPropertyChanged(); } } }

        private string? _Versioncfdi;
        [XmlAttribute]
        public string? Versioncfdi { get => _Versioncfdi; set { if (RaiseAcceptPendingChange(value, _Versioncfdi)) { _Versioncfdi = value; OnPropertyChanged(); } } }

        private string? _Fiscalnumerointerior;
        [XmlAttribute]
        public string? Fiscalnumerointerior { get => _Fiscalnumerointerior; set { if (RaiseAcceptPendingChange(value, _Fiscalnumerointerior)) { _Fiscalnumerointerior = value; OnPropertyChanged(); } } }

        private string? _Fiscalnumeroexterior;
        [XmlAttribute]
        public string? Fiscalnumeroexterior { get => _Fiscalnumeroexterior; set { if (RaiseAcceptPendingChange(value, _Fiscalnumeroexterior)) { _Fiscalnumeroexterior = value; OnPropertyChanged(); } } }

        private string? _Fiscalcalle;
        [XmlAttribute]
        public string? Fiscalcalle { get => _Fiscalcalle; set { if (RaiseAcceptPendingChange(value, _Fiscalcalle)) { _Fiscalcalle = value; OnPropertyChanged(); } } }

        private string? _Fiscalcolonia;
        [XmlAttribute]
        public string? Fiscalcolonia { get => _Fiscalcolonia; set { if (RaiseAcceptPendingChange(value, _Fiscalcolonia)) { _Fiscalcolonia = value; OnPropertyChanged(); } } }

        private string? _Monederocamporef;
        [XmlAttribute]
        public string? Monederocamporef { get => _Monederocamporef; set { if (RaiseAcceptPendingChange(value, _Monederocamporef)) { _Monederocamporef = value; OnPropertyChanged(); } } }

        private BoolCN? _Monederoaplicarcombobox;
        [XmlAttribute]
        public BoolCN? Monederoaplicarcombobox { get => _Monederoaplicarcombobox; set { if (RaiseAcceptPendingChange(value, _Monederoaplicarcombobox)) { _Monederoaplicarcombobox = value; OnPropertyChanged(); } } }

        private decimal? _Descuentovale;
        [XmlAttribute]
        public decimal? Descuentovale { get => _Descuentovale; set { if (RaiseAcceptPendingChange(value, _Descuentovale)) { _Descuentovale = value; OnPropertyChanged(); } } }

        private BoolCN? _Multipletipovale;
        [XmlAttribute]
        public BoolCN? Multipletipovale { get => _Multipletipovale; set { if (RaiseAcceptPendingChange(value, _Multipletipovale)) { _Multipletipovale = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo1porc;
        [XmlAttribute]
        public decimal? Descuentotipo1porc { get => _Descuentotipo1porc; set { if (RaiseAcceptPendingChange(value, _Descuentotipo1porc)) { _Descuentotipo1porc = value; OnPropertyChanged(); } } }

        private string? _Descuentotipo1texto;
        [XmlAttribute]
        public string? Descuentotipo1texto { get => _Descuentotipo1texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo1texto)) { _Descuentotipo1texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo2porc;
        [XmlAttribute]
        public decimal? Descuentotipo2porc { get => _Descuentotipo2porc; set { if (RaiseAcceptPendingChange(value, _Descuentotipo2porc)) { _Descuentotipo2porc = value; OnPropertyChanged(); } } }

        private string? _Descuentotipo2texto;
        [XmlAttribute]
        public string? Descuentotipo2texto { get => _Descuentotipo2texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo2texto)) { _Descuentotipo2texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo3porc;
        [XmlAttribute]
        public decimal? Descuentotipo3porc { get => _Descuentotipo3porc; set { if (RaiseAcceptPendingChange(value, _Descuentotipo3porc)) { _Descuentotipo3porc = value; OnPropertyChanged(); } } }

        private string? _Descuentotipo3texto;
        [XmlAttribute]
        public string? Descuentotipo3texto { get => _Descuentotipo3texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo3texto)) { _Descuentotipo3texto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentotipo4porc;
        [XmlAttribute]
        public decimal? Descuentotipo4porc { get => _Descuentotipo4porc; set { if (RaiseAcceptPendingChange(value, _Descuentotipo4porc)) { _Descuentotipo4porc = value; OnPropertyChanged(); } } }

        private string? _Descuentotipo4texto;
        [XmlAttribute]
        public string? Descuentotipo4texto { get => _Descuentotipo4texto; set { if (RaiseAcceptPendingChange(value, _Descuentotipo4texto)) { _Descuentotipo4texto = value; OnPropertyChanged(); } } }

        private string? _Rutapolizapdf;
        [XmlAttribute]
        public string? Rutapolizapdf { get => _Rutapolizapdf; set { if (RaiseAcceptPendingChange(value, _Rutapolizapdf)) { _Rutapolizapdf = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejacupones;
        [XmlAttribute]
        public BoolCN? Manejacupones { get => _Manejacupones; set { if (RaiseAcceptPendingChange(value, _Manejacupones)) { _Manejacupones = value; OnPropertyChanged(); } } }

        private BoolCN? _Bancomerhabpinpad;
        [XmlAttribute]
        public BoolCN? Bancomerhabpinpad { get => _Bancomerhabpinpad; set { if (RaiseAcceptPendingChange(value, _Bancomerhabpinpad)) { _Bancomerhabpinpad = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbhabbtnpagovale;
        [XmlAttribute]
        public BoolCN? Cbhabbtnpagovale { get => _Cbhabbtnpagovale; set { if (RaiseAcceptPendingChange(value, _Cbhabbtnpagovale)) { _Cbhabbtnpagovale = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejagastosadic;
        [XmlAttribute]
        public BoolCN? Manejagastosadic { get => _Manejagastosadic; set { if (RaiseAcceptPendingChange(value, _Manejagastosadic)) { _Manejagastosadic = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejarloteimportacion;
        [XmlAttribute]
        public BoolCN? Manejarloteimportacion { get => _Manejarloteimportacion; set { if (RaiseAcceptPendingChange(value, _Manejarloteimportacion)) { _Manejarloteimportacion = value; OnPropertyChanged(); } } }

        private BoolCN? _Descuentolineapersona;
        [XmlAttribute]
        public BoolCN? Descuentolineapersona { get => _Descuentolineapersona; set { if (RaiseAcceptPendingChange(value, _Descuentolineapersona)) { _Descuentolineapersona = value; OnPropertyChanged(); } } }

        private long? _Filtroprodsatcombobox;
        [XmlAttribute]
        public long? Filtroprodsatcombobox { get => _Filtroprodsatcombobox; set { if (RaiseAcceptPendingChange(value, _Filtroprodsatcombobox)) { _Filtroprodsatcombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejaproductospromocion;
        [XmlAttribute]
        public BoolCN? Manejaproductospromocion { get => _Manejaproductospromocion; set { if (RaiseAcceptPendingChange(value, _Manejaproductospromocion)) { _Manejaproductospromocion = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_consolidadoautomatico;
        [XmlAttribute]
        public BoolCN? Hab_consolidadoautomatico { get => _Hab_consolidadoautomatico; set { if (RaiseAcceptPendingChange(value, _Hab_consolidadoautomatico)) { _Hab_consolidadoautomatico = value; OnPropertyChanged(); } } }

        private BoolCN? _Consfactomitirvales;
        [XmlAttribute]
        public BoolCN? Consfactomitirvales { get => _Consfactomitirvales; set { if (RaiseAcceptPendingChange(value, _Consfactomitirvales)) { _Consfactomitirvales = value; OnPropertyChanged(); } } }

        private long? _Monederolistaprecioidcombobox;
        [XmlAttribute]
        public long? Monederolistaprecioidcombobox { get => _Monederolistaprecioidcombobox; set { if (RaiseAcceptPendingChange(value, _Monederolistaprecioidcombobox)) { _Monederolistaprecioidcombobox = value; OnPropertyChanged(); } } }

        private decimal? _Monederomontominimo;
        [XmlAttribute]
        public decimal? Monederomontominimo { get => _Monederomontominimo; set { if (RaiseAcceptPendingChange(value, _Monederomontominimo)) { _Monederomontominimo = value; OnPropertyChanged(); } } }

        private int? _Monederocaducidad;
        [XmlAttribute]
        public int? Monederocaducidad { get => _Monederocaducidad; set { if (RaiseAcceptPendingChange(value, _Monederocaducidad)) { _Monederocaducidad = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo3;
        [XmlAttribute]
        public BoolCN? L1campo3 { get => _L1campo3; set { if (RaiseAcceptPendingChange(value, _L1campo3)) { _L1campo3 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo2;
        [XmlAttribute]
        public BoolCN? L1campo2 { get => _L1campo2; set { if (RaiseAcceptPendingChange(value, _L1campo2)) { _L1campo2 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo4;
        [XmlAttribute]
        public BoolCN? L1campo4 { get => _L1campo4; set { if (RaiseAcceptPendingChange(value, _L1campo4)) { _L1campo4 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo5;
        [XmlAttribute]
        public BoolCN? L1campo5 { get => _L1campo5; set { if (RaiseAcceptPendingChange(value, _L1campo5)) { _L1campo5 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo6;
        [XmlAttribute]
        public BoolCN? L1campo6 { get => _L1campo6; set { if (RaiseAcceptPendingChange(value, _L1campo6)) { _L1campo6 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo7;
        [XmlAttribute]
        public BoolCN? L1campo7 { get => _L1campo7; set { if (RaiseAcceptPendingChange(value, _L1campo7)) { _L1campo7 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo3;
        [XmlAttribute]
        public string? L1lbl_campo3 { get => _L1lbl_campo3; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo3)) { _L1lbl_campo3 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo2;
        [XmlAttribute]
        public string? L1lbl_campo2 { get => _L1lbl_campo2; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo2)) { _L1lbl_campo2 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo4;
        [XmlAttribute]
        public string? L1lbl_campo4 { get => _L1lbl_campo4; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo4)) { _L1lbl_campo4 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo5;
        [XmlAttribute]
        public string? L1lbl_campo5 { get => _L1lbl_campo5; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo5)) { _L1lbl_campo5 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo6;
        [XmlAttribute]
        public string? L1lbl_campo6 { get => _L1lbl_campo6; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo6)) { _L1lbl_campo6 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo7;
        [XmlAttribute]
        public string? L1lbl_campo7 { get => _L1lbl_campo7; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo7)) { _L1lbl_campo7 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo9;
        [XmlAttribute]
        public BoolCN? L1campo9 { get => _L1campo9; set { if (RaiseAcceptPendingChange(value, _L1campo9)) { _L1campo9 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo8;
        [XmlAttribute]
        public BoolCN? L1campo8 { get => _L1campo8; set { if (RaiseAcceptPendingChange(value, _L1campo8)) { _L1campo8 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo10;
        [XmlAttribute]
        public BoolCN? L1campo10 { get => _L1campo10; set { if (RaiseAcceptPendingChange(value, _L1campo10)) { _L1campo10 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo11;
        [XmlAttribute]
        public BoolCN? L1campo11 { get => _L1campo11; set { if (RaiseAcceptPendingChange(value, _L1campo11)) { _L1campo11 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo12;
        [XmlAttribute]
        public BoolCN? L1campo12 { get => _L1campo12; set { if (RaiseAcceptPendingChange(value, _L1campo12)) { _L1campo12 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo13;
        [XmlAttribute]
        public BoolCN? L1campo13 { get => _L1campo13; set { if (RaiseAcceptPendingChange(value, _L1campo13)) { _L1campo13 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo9;
        [XmlAttribute]
        public string? L1lbl_campo9 { get => _L1lbl_campo9; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo9)) { _L1lbl_campo9 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo8;
        [XmlAttribute]
        public string? L1lbl_campo8 { get => _L1lbl_campo8; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo8)) { _L1lbl_campo8 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo10;
        [XmlAttribute]
        public string? L1lbl_campo10 { get => _L1lbl_campo10; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo10)) { _L1lbl_campo10 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo11;
        [XmlAttribute]
        public string? L1lbl_campo11 { get => _L1lbl_campo11; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo11)) { _L1lbl_campo11 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo12;
        [XmlAttribute]
        public string? L1lbl_campo12 { get => _L1lbl_campo12; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo12)) { _L1lbl_campo12 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo13;
        [XmlAttribute]
        public string? L1lbl_campo13 { get => _L1lbl_campo13; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo13)) { _L1lbl_campo13 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo17;
        [XmlAttribute]
        public BoolCN? L1campo17 { get => _L1campo17; set { if (RaiseAcceptPendingChange(value, _L1campo17)) { _L1campo17 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo14;
        [XmlAttribute]
        public BoolCN? L1campo14 { get => _L1campo14; set { if (RaiseAcceptPendingChange(value, _L1campo14)) { _L1campo14 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo24;
        [XmlAttribute]
        public BoolCN? L1campo24 { get => _L1campo24; set { if (RaiseAcceptPendingChange(value, _L1campo24)) { _L1campo24 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo25;
        [XmlAttribute]
        public BoolCN? L1campo25 { get => _L1campo25; set { if (RaiseAcceptPendingChange(value, _L1campo25)) { _L1campo25 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo26;
        [XmlAttribute]
        public BoolCN? L1campo26 { get => _L1campo26; set { if (RaiseAcceptPendingChange(value, _L1campo26)) { _L1campo26 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo24;
        [XmlAttribute]
        public string? L1lbl_campo24 { get => _L1lbl_campo24; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo24)) { _L1lbl_campo24 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo25;
        [XmlAttribute]
        public string? L1lbl_campo25 { get => _L1lbl_campo25; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo25)) { _L1lbl_campo25 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo26;
        [XmlAttribute]
        public string? L1lbl_campo26 { get => _L1lbl_campo26; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo26)) { _L1lbl_campo26 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo17;
        [XmlAttribute]
        public string? L1lbl_campo17 { get => _L1lbl_campo17; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo17)) { _L1lbl_campo17 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo14;
        [XmlAttribute]
        public string? L1lbl_campo14 { get => _L1lbl_campo14; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo14)) { _L1lbl_campo14 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campoobligado3;
        [XmlAttribute]
        public BoolCN? L1campoobligado3 { get => _L1campoobligado3; set { if (RaiseAcceptPendingChange(value, _L1campoobligado3)) { _L1campoobligado3 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo31;
        [XmlAttribute]
        public BoolCN? L1campo31 { get => _L1campo31; set { if (RaiseAcceptPendingChange(value, _L1campo31)) { _L1campo31 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo27;
        [XmlAttribute]
        public BoolCN? L1campo27 { get => _L1campo27; set { if (RaiseAcceptPendingChange(value, _L1campo27)) { _L1campo27 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo30;
        [XmlAttribute]
        public BoolCN? L1campo30 { get => _L1campo30; set { if (RaiseAcceptPendingChange(value, _L1campo30)) { _L1campo30 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo28;
        [XmlAttribute]
        public BoolCN? L1campo28 { get => _L1campo28; set { if (RaiseAcceptPendingChange(value, _L1campo28)) { _L1campo28 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo29;
        [XmlAttribute]
        public BoolCN? L1campo29 { get => _L1campo29; set { if (RaiseAcceptPendingChange(value, _L1campo29)) { _L1campo29 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo27;
        [XmlAttribute]
        public string? L1lbl_campo27 { get => _L1lbl_campo27; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo27)) { _L1lbl_campo27 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo28;
        [XmlAttribute]
        public string? L1lbl_campo28 { get => _L1lbl_campo28; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo28)) { _L1lbl_campo28 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo29;
        [XmlAttribute]
        public string? L1lbl_campo29 { get => _L1lbl_campo29; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo29)) { _L1lbl_campo29 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo31;
        [XmlAttribute]
        public string? L1lbl_campo31 { get => _L1lbl_campo31; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo31)) { _L1lbl_campo31 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo30;
        [XmlAttribute]
        public string? L1lbl_campo30 { get => _L1lbl_campo30; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo30)) { _L1lbl_campo30 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo16;
        [XmlAttribute]
        public BoolCN? L1campo16 { get => _L1campo16; set { if (RaiseAcceptPendingChange(value, _L1campo16)) { _L1campo16 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo15;
        [XmlAttribute]
        public BoolCN? L1campo15 { get => _L1campo15; set { if (RaiseAcceptPendingChange(value, _L1campo15)) { _L1campo15 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo18;
        [XmlAttribute]
        public BoolCN? L1campo18 { get => _L1campo18; set { if (RaiseAcceptPendingChange(value, _L1campo18)) { _L1campo18 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo16;
        [XmlAttribute]
        public string? L1lbl_campo16 { get => _L1lbl_campo16; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo16)) { _L1lbl_campo16 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo18;
        [XmlAttribute]
        public string? L1lbl_campo18 { get => _L1lbl_campo18; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo18)) { _L1lbl_campo18 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo15;
        [XmlAttribute]
        public string? L1lbl_campo15 { get => _L1lbl_campo15; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo15)) { _L1lbl_campo15 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo19;
        [XmlAttribute]
        public BoolCN? L1campo19 { get => _L1campo19; set { if (RaiseAcceptPendingChange(value, _L1campo19)) { _L1campo19 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo20;
        [XmlAttribute]
        public BoolCN? L1campo20 { get => _L1campo20; set { if (RaiseAcceptPendingChange(value, _L1campo20)) { _L1campo20 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo22;
        [XmlAttribute]
        public BoolCN? L1campo22 { get => _L1campo22; set { if (RaiseAcceptPendingChange(value, _L1campo22)) { _L1campo22 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo21;
        [XmlAttribute]
        public BoolCN? L1campo21 { get => _L1campo21; set { if (RaiseAcceptPendingChange(value, _L1campo21)) { _L1campo21 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo23;
        [XmlAttribute]
        public BoolCN? L1campo23 { get => _L1campo23; set { if (RaiseAcceptPendingChange(value, _L1campo23)) { _L1campo23 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo20;
        [XmlAttribute]
        public string? L1lbl_campo20 { get => _L1lbl_campo20; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo20)) { _L1lbl_campo20 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo19;
        [XmlAttribute]
        public string? L1lbl_campo19 { get => _L1lbl_campo19; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo19)) { _L1lbl_campo19 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo21;
        [XmlAttribute]
        public string? L1lbl_campo21 { get => _L1lbl_campo21; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo21)) { _L1lbl_campo21 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo22;
        [XmlAttribute]
        public string? L1lbl_campo22 { get => _L1lbl_campo22; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo22)) { _L1lbl_campo22 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo23;
        [XmlAttribute]
        public string? L1lbl_campo23 { get => _L1lbl_campo23; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo23)) { _L1lbl_campo23 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo32;
        [XmlAttribute]
        public BoolCN? L1campo32 { get => _L1campo32; set { if (RaiseAcceptPendingChange(value, _L1campo32)) { _L1campo32 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo33;
        [XmlAttribute]
        public BoolCN? L1campo33 { get => _L1campo33; set { if (RaiseAcceptPendingChange(value, _L1campo33)) { _L1campo33 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo32;
        [XmlAttribute]
        public string? L1lbl_campo32 { get => _L1lbl_campo32; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo32)) { _L1lbl_campo32 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo33;
        [XmlAttribute]
        public string? L1lbl_campo33 { get => _L1lbl_campo33; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo33)) { _L1lbl_campo33 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo34;
        [XmlAttribute]
        public BoolCN? L1campo34 { get => _L1campo34; set { if (RaiseAcceptPendingChange(value, _L1campo34)) { _L1campo34 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo35;
        [XmlAttribute]
        public BoolCN? L1campo35 { get => _L1campo35; set { if (RaiseAcceptPendingChange(value, _L1campo35)) { _L1campo35 = value; OnPropertyChanged(); } } }

        private long? _Pvcolorear;
        [XmlAttribute]
        public long? Pvcolorear { get => _Pvcolorear; set { if (RaiseAcceptPendingChange(value, _Pvcolorear)) { _Pvcolorear = value; OnPropertyChanged(); } } }

        private decimal? _Porcutilidadlistado;
        [XmlAttribute]
        public decimal? Porcutilidadlistado { get => _Porcutilidadlistado; set { if (RaiseAcceptPendingChange(value, _Porcutilidadlistado)) { _Porcutilidadlistado = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo34;
        [XmlAttribute]
        public string? L1lbl_campo34 { get => _L1lbl_campo34; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo34)) { _L1lbl_campo34 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo35;
        [XmlAttribute]
        public string? L1lbl_campo35 { get => _L1lbl_campo35; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo35)) { _L1lbl_campo35 = value; OnPropertyChanged(); } } }

        private BoolCN? _Camposcustomalimportar;
        [XmlAttribute]
        public BoolCN? Camposcustomalimportar { get => _Camposcustomalimportar; set { if (RaiseAcceptPendingChange(value, _Camposcustomalimportar)) { _Camposcustomalimportar = value; OnPropertyChanged(); } } }

        private BoolCN? _Exportcatalogoaux;
        [XmlAttribute]
        public BoolCN? Exportcatalogoaux { get => _Exportcatalogoaux; set { if (RaiseAcceptPendingChange(value, _Exportcatalogoaux)) { _Exportcatalogoaux = value; OnPropertyChanged(); } } }

        private BoolCN? _Habtotalizados;
        [XmlAttribute]
        public BoolCN? Habtotalizados { get => _Habtotalizados; set { if (RaiseAcceptPendingChange(value, _Habtotalizados)) { _Habtotalizados = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrarinvinfoadicprod;
        [XmlAttribute]
        public BoolCN? Mostrarinvinfoadicprod { get => _Mostrarinvinfoadicprod; set { if (RaiseAcceptPendingChange(value, _Mostrarinvinfoadicprod)) { _Mostrarinvinfoadicprod = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campoobligado2;
        [XmlAttribute]
        public BoolCN? L1campoobligado2 { get => _L1campoobligado2; set { if (RaiseAcceptPendingChange(value, _L1campoobligado2)) { _L1campoobligado2 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campoobligado1;
        [XmlAttribute]
        public BoolCN? L1campoobligado1 { get => _L1campoobligado1; set { if (RaiseAcceptPendingChange(value, _L1campoobligado1)) { _L1campoobligado1 = value; OnPropertyChanged(); } } }

        private BoolCN? _L1campo1;
        [XmlAttribute]
        public BoolCN? L1campo1 { get => _L1campo1; set { if (RaiseAcceptPendingChange(value, _L1campo1)) { _L1campo1 = value; OnPropertyChanged(); } } }

        private string? _L1lbl_campo1;
        [XmlAttribute]
        public string? L1lbl_campo1 { get => _L1lbl_campo1; set { if (RaiseAcceptPendingChange(value, _L1lbl_campo1)) { _L1lbl_campo1 = value; OnPropertyChanged(); } } }

        private long? _Tipovendedormovil;
        [XmlAttribute]
        public long? Tipovendedormovil { get => _Tipovendedormovil; set { if (RaiseAcceptPendingChange(value, _Tipovendedormovil)) { _Tipovendedormovil = value; OnPropertyChanged(); } } }

        private long? _Vendedormovilclave;
        [XmlAttribute]
        public long? Vendedormovilclave { get => _Vendedormovilclave; set { if (RaiseAcceptPendingChange(value, _Vendedormovilclave)) { _Vendedormovilclave = value; OnPropertyChanged(); } } }

        private string? _VendedormovilclaveClave;
        [XmlAttribute]
        public string? VendedormovilclaveClave { get => _VendedormovilclaveClave; set { if (RaiseAcceptPendingChange(value, _VendedormovilclaveClave)) { _VendedormovilclaveClave = value; OnPropertyChanged(); } } }

        private string? _VendedormovilclaveNombre;
        [XmlAttribute]
        public string? VendedormovilclaveNombre { get => _VendedormovilclaveNombre; set { if (RaiseAcceptPendingChange(value, _VendedormovilclaveNombre)) { _VendedormovilclaveNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Pendmovilantesventa;
        [XmlAttribute]
        public BoolCN? Pendmovilantesventa { get => _Pendmovilantesventa; set { if (RaiseAcceptPendingChange(value, _Pendmovilantesventa)) { _Pendmovilantesventa = value; OnPropertyChanged(); } } }

        private string? _Bdserverws;
        [XmlAttribute]
        public string? Bdserverws { get => _Bdserverws; set { if (RaiseAcceptPendingChange(value, _Bdserverws)) { _Bdserverws = value; OnPropertyChanged(); } } }

        private BoolCN? _Preciosmovilantesventa;
        [XmlAttribute]
        public BoolCN? Preciosmovilantesventa { get => _Preciosmovilantesventa; set { if (RaiseAcceptPendingChange(value, _Preciosmovilantesventa)) { _Preciosmovilantesventa = value; OnPropertyChanged(); } } }

        private string? _Bdmatrizmovil;
        [XmlAttribute]
        public string? Bdmatrizmovil { get => _Bdmatrizmovil; set { if (RaiseAcceptPendingChange(value, _Bdmatrizmovil)) { _Bdmatrizmovil = value; OnPropertyChanged(); } } }

        private BoolCN? _Movil_tienevendedorescombobox;
        [XmlAttribute]
        public BoolCN? Movil_tienevendedorescombobox { get => _Movil_tienevendedorescombobox; set { if (RaiseAcceptPendingChange(value, _Movil_tienevendedorescombobox)) { _Movil_tienevendedorescombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Movilverificarventacombobox;
        [XmlAttribute]
        public BoolCN? Movilverificarventacombobox { get => _Movilverificarventacombobox; set { if (RaiseAcceptPendingChange(value, _Movilverificarventacombobox)) { _Movilverificarventacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Movil3_preimportar;
        [XmlAttribute]
        public BoolCN? Movil3_preimportar { get => _Movil3_preimportar; set { if (RaiseAcceptPendingChange(value, _Movil3_preimportar)) { _Movil3_preimportar = value; OnPropertyChanged(); } } }

        private string? _Rutabdvenmov;
        [XmlAttribute]
        public string? Rutabdvenmov { get => _Rutabdvenmov; set { if (RaiseAcceptPendingChange(value, _Rutabdvenmov)) { _Rutabdvenmov = value; OnPropertyChanged(); } } }

        private BoolCN? _Habsurtidopostmovil;
        [XmlAttribute]
        public BoolCN? Habsurtidopostmovil { get => _Habsurtidopostmovil; set { if (RaiseAcceptPendingChange(value, _Habsurtidopostmovil)) { _Habsurtidopostmovil = value; OnPropertyChanged(); } } }

        private long? _Screenconfig;
        [XmlAttribute]
        public long? Screenconfig { get => _Screenconfig; set { if (RaiseAcceptPendingChange(value, _Screenconfig)) { _Screenconfig = value; OnPropertyChanged(); } } }

        private BoolCN? _Esvendedormovil;
        [XmlAttribute]
        public BoolCN? Esvendedormovil { get => _Esvendedormovil; set { if (RaiseAcceptPendingChange(value, _Esvendedormovil)) { _Esvendedormovil = value; OnPropertyChanged(); } } }

        private long? _Tiposyncmovil;
        [XmlAttribute]
        public long? Tiposyncmovil { get => _Tiposyncmovil; set { if (RaiseAcceptPendingChange(value, _Tiposyncmovil)) { _Tiposyncmovil = value; OnPropertyChanged(); } } }

        private BoolCN? _Touch;
        [XmlAttribute]
        public BoolCN? Touch { get => _Touch; set { if (RaiseAcceptPendingChange(value, _Touch)) { _Touch = value; OnPropertyChanged(); } } }

        private long? _Marcaidrec;
        [XmlAttribute]
        public long? Marcaidrec { get => _Marcaidrec; set { if (RaiseAcceptPendingChange(value, _Marcaidrec)) { _Marcaidrec = value; OnPropertyChanged(); } } }

        private string? _MarcaidrecClave;
        [XmlAttribute]
        public string? MarcaidrecClave { get => _MarcaidrecClave; set { if (RaiseAcceptPendingChange(value, _MarcaidrecClave)) { _MarcaidrecClave = value; OnPropertyChanged(); } } }

        private string? _MarcaidrecNombre;
        [XmlAttribute]
        public string? MarcaidrecNombre { get => _MarcaidrecNombre; set { if (RaiseAcceptPendingChange(value, _MarcaidrecNombre)) { _MarcaidrecNombre = value; OnPropertyChanged(); } } }

        private long? _Proveedor1idrec;
        [XmlAttribute]
        public long? Proveedor1idrec { get => _Proveedor1idrec; set { if (RaiseAcceptPendingChange(value, _Proveedor1idrec)) { _Proveedor1idrec = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idrecClave;
        [XmlAttribute]
        public string? Proveedor1idrecClave { get => _Proveedor1idrecClave; set { if (RaiseAcceptPendingChange(value, _Proveedor1idrecClave)) { _Proveedor1idrecClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idrecNombre;
        [XmlAttribute]
        public string? Proveedor1idrecNombre { get => _Proveedor1idrecNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1idrecNombre)) { _Proveedor1idrecNombre = value; OnPropertyChanged(); } } }

        private long? _Lineaidserv;
        [XmlAttribute]
        public long? Lineaidserv { get => _Lineaidserv; set { if (RaiseAcceptPendingChange(value, _Lineaidserv)) { _Lineaidserv = value; OnPropertyChanged(); } } }

        private string? _LineaidservClave;
        [XmlAttribute]
        public string? LineaidservClave { get => _LineaidservClave; set { if (RaiseAcceptPendingChange(value, _LineaidservClave)) { _LineaidservClave = value; OnPropertyChanged(); } } }

        private string? _LineaidservNombre;
        [XmlAttribute]
        public string? LineaidservNombre { get => _LineaidservNombre; set { if (RaiseAcceptPendingChange(value, _LineaidservNombre)) { _LineaidservNombre = value; OnPropertyChanged(); } } }

        private long? _Marcaidserv;
        [XmlAttribute]
        public long? Marcaidserv { get => _Marcaidserv; set { if (RaiseAcceptPendingChange(value, _Marcaidserv)) { _Marcaidserv = value; OnPropertyChanged(); } } }

        private string? _MarcaidservClave;
        [XmlAttribute]
        public string? MarcaidservClave { get => _MarcaidservClave; set { if (RaiseAcceptPendingChange(value, _MarcaidservClave)) { _MarcaidservClave = value; OnPropertyChanged(); } } }

        private string? _MarcaidservNombre;
        [XmlAttribute]
        public string? MarcaidservNombre { get => _MarcaidservNombre; set { if (RaiseAcceptPendingChange(value, _MarcaidservNombre)) { _MarcaidservNombre = value; OnPropertyChanged(); } } }

        private long? _Proveedor1idserv;
        [XmlAttribute]
        public long? Proveedor1idserv { get => _Proveedor1idserv; set { if (RaiseAcceptPendingChange(value, _Proveedor1idserv)) { _Proveedor1idserv = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idservClave;
        [XmlAttribute]
        public string? Proveedor1idservClave { get => _Proveedor1idservClave; set { if (RaiseAcceptPendingChange(value, _Proveedor1idservClave)) { _Proveedor1idservClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idservNombre;
        [XmlAttribute]
        public string? Proveedor1idservNombre { get => _Proveedor1idservNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1idservNombre)) { _Proveedor1idservNombre = value; OnPropertyChanged(); } } }

        private decimal? _Txtporcutilidadrecargas;
        [XmlAttribute]
        public decimal? Txtporcutilidadrecargas { get => _Txtporcutilidadrecargas; set { if (RaiseAcceptPendingChange(value, _Txtporcutilidadrecargas)) { _Txtporcutilidadrecargas = value; OnPropertyChanged(); } } }

        private decimal? _Txtutilidadpagoservicio;
        [XmlAttribute]
        public decimal? Txtutilidadpagoservicio { get => _Txtutilidadpagoservicio; set { if (RaiseAcceptPendingChange(value, _Txtutilidadpagoservicio)) { _Txtutilidadpagoservicio = value; OnPropertyChanged(); } } }

        private int? _Nudtimeoutpin;
        [XmlAttribute]
        public int? Nudtimeoutpin { get => _Nudtimeoutpin; set { if (RaiseAcceptPendingChange(value, _Nudtimeoutpin)) { _Nudtimeoutpin = value; OnPropertyChanged(); } } }

        private int? _Nudtimeoutlookup;
        [XmlAttribute]
        public int? Nudtimeoutlookup { get => _Nudtimeoutlookup; set { if (RaiseAcceptPendingChange(value, _Nudtimeoutlookup)) { _Nudtimeoutlookup = value; OnPropertyChanged(); } } }

        private int? _Timeoutpintdistsaleserv;
        [XmlAttribute]
        public int? Timeoutpintdistsaleserv { get => _Timeoutpintdistsaleserv; set { if (RaiseAcceptPendingChange(value, _Timeoutpintdistsaleserv)) { _Timeoutpintdistsaleserv = value; OnPropertyChanged(); } } }

        private BoolCN? _Rdbtnemidaservices;
        [XmlAttribute]
        public BoolCN? Rdbtnemidaservices { get => _Rdbtnemidaservices; set { if (RaiseAcceptPendingChange(value, _Rdbtnemidaservices)) { _Rdbtnemidaservices = value; OnPropertyChanged(); } } }

        private BoolCN? _Habpagoservemida;
        [XmlAttribute]
        public BoolCN? Habpagoservemida { get => _Habpagoservemida; set { if (RaiseAcceptPendingChange(value, _Habpagoservemida)) { _Habpagoservemida = value; OnPropertyChanged(); } } }

        private long? _Lineaidrec;
        [XmlAttribute]
        public long? Lineaidrec { get => _Lineaidrec; set { if (RaiseAcceptPendingChange(value, _Lineaidrec)) { _Lineaidrec = value; OnPropertyChanged(); } } }

        private string? _LineaidrecClave;
        [XmlAttribute]
        public string? LineaidrecClave { get => _LineaidrecClave; set { if (RaiseAcceptPendingChange(value, _LineaidrecClave)) { _LineaidrecClave = value; OnPropertyChanged(); } } }

        private string? _LineaidrecNombre;
        [XmlAttribute]
        public string? LineaidrecNombre { get => _LineaidrecNombre; set { if (RaiseAcceptPendingChange(value, _LineaidrecNombre)) { _LineaidrecNombre = value; OnPropertyChanged(); } } }

        private string? _Txtrutabdappinventario;
        [XmlAttribute]
        public string? Txtrutabdappinventario { get => _Txtrutabdappinventario; set { if (RaiseAcceptPendingChange(value, _Txtrutabdappinventario)) { _Txtrutabdappinventario = value; OnPropertyChanged(); } } }

        private string? _Txtipwsappinventario;
        [XmlAttribute]
        public string? Txtipwsappinventario { get => _Txtipwsappinventario; set { if (RaiseAcceptPendingChange(value, _Txtipwsappinventario)) { _Txtipwsappinventario = value; OnPropertyChanged(); } } }

        private BoolCN? _Habppc;
        [XmlAttribute]
        public BoolCN? Habppc { get => _Habppc; set { if (RaiseAcceptPendingChange(value, _Habppc)) { _Habppc = value; OnPropertyChanged(); } } }

        private string? _Wsdbf;
        [XmlAttribute]
        public string? Wsdbf { get => _Wsdbf; set { if (RaiseAcceptPendingChange(value, _Wsdbf)) { _Wsdbf = value; OnPropertyChanged(); } } }

        private BoolCN? _Habwsdbf;
        [XmlAttribute]
        public BoolCN? Habwsdbf { get => _Habwsdbf; set { if (RaiseAcceptPendingChange(value, _Habwsdbf)) { _Habwsdbf = value; OnPropertyChanged(); } } }

        private int? _Diasmaxexpftp;
        [XmlAttribute]
        public int? Diasmaxexpftp { get => _Diasmaxexpftp; set { if (RaiseAcceptPendingChange(value, _Diasmaxexpftp)) { _Diasmaxexpftp = value; OnPropertyChanged(); } } }

        private int? _Segundoscicloftp;
        [XmlAttribute]
        public int? Segundoscicloftp { get => _Segundoscicloftp; set { if (RaiseAcceptPendingChange(value, _Segundoscicloftp)) { _Segundoscicloftp = value; OnPropertyChanged(); } } }

        private int? _Diasmaximpftp;
        [XmlAttribute]
        public int? Diasmaximpftp { get => _Diasmaximpftp; set { if (RaiseAcceptPendingChange(value, _Diasmaximpftp)) { _Diasmaximpftp = value; OnPropertyChanged(); } } }

        private decimal? _Comisionprecio2;
        [XmlAttribute]
        public decimal? Comisionprecio2 { get => _Comisionprecio2; set { if (RaiseAcceptPendingChange(value, _Comisionprecio2)) { _Comisionprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Comisionprecio3;
        [XmlAttribute]
        public decimal? Comisionprecio3 { get => _Comisionprecio3; set { if (RaiseAcceptPendingChange(value, _Comisionprecio3)) { _Comisionprecio3 = value; OnPropertyChanged(); } } }

        private decimal? _Comisionprecio4;
        [XmlAttribute]
        public decimal? Comisionprecio4 { get => _Comisionprecio4; set { if (RaiseAcceptPendingChange(value, _Comisionprecio4)) { _Comisionprecio4 = value; OnPropertyChanged(); } } }

        private decimal? _Comisionprecio5;
        [XmlAttribute]
        public decimal? Comisionprecio5 { get => _Comisionprecio5; set { if (RaiseAcceptPendingChange(value, _Comisionprecio5)) { _Comisionprecio5 = value; OnPropertyChanged(); } } }

        private decimal? _Comisionpreciootro;
        [XmlAttribute]
        public decimal? Comisionpreciootro { get => _Comisionpreciootro; set { if (RaiseAcceptPendingChange(value, _Comisionpreciootro)) { _Comisionpreciootro = value; OnPropertyChanged(); } } }

        private decimal? _Comisionprecio1;
        [XmlAttribute]
        public decimal? Comisionprecio1 { get => _Comisionprecio1; set { if (RaiseAcceptPendingChange(value, _Comisionprecio1)) { _Comisionprecio1 = value; OnPropertyChanged(); } } }

        private string? _Impresoracomanda;
        [XmlAttribute]
        public string? Impresoracomanda { get => _Impresoracomanda; set { if (RaiseAcceptPendingChange(value, _Impresoracomanda)) { _Impresoracomanda = value; OnPropertyChanged(); } } }

        private BoolCN? _Recibopreviewcomanda;
        [XmlAttribute]
        public BoolCN? Recibopreviewcomanda { get => _Recibopreviewcomanda; set { if (RaiseAcceptPendingChange(value, _Recibopreviewcomanda)) { _Recibopreviewcomanda = value; OnPropertyChanged(); } } }

        private int? _Numticketscomanda;
        [XmlAttribute]
        public int? Numticketscomanda { get => _Numticketscomanda; set { if (RaiseAcceptPendingChange(value, _Numticketscomanda)) { _Numticketscomanda = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo2;
        [XmlAttribute]
        public BoolCN? L2campo2 { get => _L2campo2; set { if (RaiseAcceptPendingChange(value, _L2campo2)) { _L2campo2 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo3;
        [XmlAttribute]
        public BoolCN? L2campo3 { get => _L2campo3; set { if (RaiseAcceptPendingChange(value, _L2campo3)) { _L2campo3 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo4;
        [XmlAttribute]
        public BoolCN? L2campo4 { get => _L2campo4; set { if (RaiseAcceptPendingChange(value, _L2campo4)) { _L2campo4 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo1;
        [XmlAttribute]
        public BoolCN? L2campo1 { get => _L2campo1; set { if (RaiseAcceptPendingChange(value, _L2campo1)) { _L2campo1 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo5;
        [XmlAttribute]
        public BoolCN? L2campo5 { get => _L2campo5; set { if (RaiseAcceptPendingChange(value, _L2campo5)) { _L2campo5 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo3;
        [XmlAttribute]
        public string? L2lbl_campo3 { get => _L2lbl_campo3; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo3)) { _L2lbl_campo3 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo4;
        [XmlAttribute]
        public string? L2lbl_campo4 { get => _L2lbl_campo4; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo4)) { _L2lbl_campo4 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo5;
        [XmlAttribute]
        public string? L2lbl_campo5 { get => _L2lbl_campo5; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo5)) { _L2lbl_campo5 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo2;
        [XmlAttribute]
        public string? L2lbl_campo2 { get => _L2lbl_campo2; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo2)) { _L2lbl_campo2 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo1;
        [XmlAttribute]
        public string? L2lbl_campo1 { get => _L2lbl_campo1; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo1)) { _L2lbl_campo1 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo6;
        [XmlAttribute]
        public BoolCN? L2campo6 { get => _L2campo6; set { if (RaiseAcceptPendingChange(value, _L2campo6)) { _L2campo6 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo7;
        [XmlAttribute]
        public BoolCN? L2campo7 { get => _L2campo7; set { if (RaiseAcceptPendingChange(value, _L2campo7)) { _L2campo7 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo10;
        [XmlAttribute]
        public BoolCN? L2campo10 { get => _L2campo10; set { if (RaiseAcceptPendingChange(value, _L2campo10)) { _L2campo10 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo8;
        [XmlAttribute]
        public BoolCN? L2campo8 { get => _L2campo8; set { if (RaiseAcceptPendingChange(value, _L2campo8)) { _L2campo8 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo9;
        [XmlAttribute]
        public BoolCN? L2campo9 { get => _L2campo9; set { if (RaiseAcceptPendingChange(value, _L2campo9)) { _L2campo9 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo7;
        [XmlAttribute]
        public string? L2lbl_campo7 { get => _L2lbl_campo7; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo7)) { _L2lbl_campo7 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo8;
        [XmlAttribute]
        public string? L2lbl_campo8 { get => _L2lbl_campo8; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo8)) { _L2lbl_campo8 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo9;
        [XmlAttribute]
        public string? L2lbl_campo9 { get => _L2lbl_campo9; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo9)) { _L2lbl_campo9 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo6;
        [XmlAttribute]
        public string? L2lbl_campo6 { get => _L2lbl_campo6; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo6)) { _L2lbl_campo6 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo10;
        [XmlAttribute]
        public string? L2lbl_campo10 { get => _L2lbl_campo10; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo10)) { _L2lbl_campo10 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo12;
        [XmlAttribute]
        public BoolCN? L2campo12 { get => _L2campo12; set { if (RaiseAcceptPendingChange(value, _L2campo12)) { _L2campo12 = value; OnPropertyChanged(); } } }

        private BoolCN? _L2campo11;
        [XmlAttribute]
        public BoolCN? L2campo11 { get => _L2campo11; set { if (RaiseAcceptPendingChange(value, _L2campo11)) { _L2campo11 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo12;
        [XmlAttribute]
        public string? L2lbl_campo12 { get => _L2lbl_campo12; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo12)) { _L2lbl_campo12 = value; OnPropertyChanged(); } } }

        private string? _L2lbl_campo11;
        [XmlAttribute]
        public string? L2lbl_campo11 { get => _L2lbl_campo11; set { if (RaiseAcceptPendingChange(value, _L2lbl_campo11)) { _L2lbl_campo11 = value; OnPropertyChanged(); } } }

        private string? _EstadoClave;
        [XmlAttribute]
        public string? EstadoClave { get => _EstadoClave; set { if (RaiseAcceptPendingChange(value, _EstadoClave)) { _EstadoClave = value; OnPropertyChanged(); } } }

        private string? _EstadoNombre;
        [XmlAttribute]
        public string? EstadoNombre { get => _EstadoNombre; set { if (RaiseAcceptPendingChange(value, _EstadoNombre)) { _EstadoNombre = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_defClave;
        [XmlAttribute]
        public string? Lista_precio_defClave { get => _Lista_precio_defClave; set { if (RaiseAcceptPendingChange(value, _Lista_precio_defClave)) { _Lista_precio_defClave = value; OnPropertyChanged(); } } }

        private string? _Lista_precio_defNombre;
        [XmlAttribute]
        public string? Lista_precio_defNombre { get => _Lista_precio_defNombre; set { if (RaiseAcceptPendingChange(value, _Lista_precio_defNombre)) { _Lista_precio_defNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecioinimayocomboboxClave;
        [XmlAttribute]
        public string? ListaprecioinimayocomboboxClave { get => _ListaprecioinimayocomboboxClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioinimayocomboboxClave)) { _ListaprecioinimayocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioinimayocomboboxNombre;
        [XmlAttribute]
        public string? ListaprecioinimayocomboboxNombre { get => _ListaprecioinimayocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioinimayocomboboxNombre)) { _ListaprecioinimayocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _TipodescuentoprodidClave;
        [XmlAttribute]
        public string? TipodescuentoprodidClave { get => _TipodescuentoprodidClave; set { if (RaiseAcceptPendingChange(value, _TipodescuentoprodidClave)) { _TipodescuentoprodidClave = value; OnPropertyChanged(); } } }

        private string? _TipodescuentoprodidNombre;
        [XmlAttribute]
        public string? TipodescuentoprodidNombre { get => _TipodescuentoprodidNombre; set { if (RaiseAcceptPendingChange(value, _TipodescuentoprodidNombre)) { _TipodescuentoprodidNombre = value; OnPropertyChanged(); } } }

        private string? _Estado_defClave;
        [XmlAttribute]
        public string? Estado_defClave { get => _Estado_defClave; set { if (RaiseAcceptPendingChange(value, _Estado_defClave)) { _Estado_defClave = value; OnPropertyChanged(); } } }

        private string? _Estado_defNombre;
        [XmlAttribute]
        public string? Estado_defNombre { get => _Estado_defNombre; set { if (RaiseAcceptPendingChange(value, _Estado_defNombre)) { _Estado_defNombre = value; OnPropertyChanged(); } } }

        private string? _SucursalcomboboxClave;
        [XmlAttribute]
        public string? SucursalcomboboxClave { get => _SucursalcomboboxClave; set { if (RaiseAcceptPendingChange(value, _SucursalcomboboxClave)) { _SucursalcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _SucursalcomboboxNombre;
        [XmlAttribute]
        public string? SucursalcomboboxNombre { get => _SucursalcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _SucursalcomboboxNombre)) { _SucursalcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _TamanoletraticketClave;
        [XmlAttribute]
        public string? TamanoletraticketClave { get => _TamanoletraticketClave; set { if (RaiseAcceptPendingChange(value, _TamanoletraticketClave)) { _TamanoletraticketClave = value; OnPropertyChanged(); } } }

        private string? _TamanoletraticketNombre;
        [XmlAttribute]
        public string? TamanoletraticketNombre { get => _TamanoletraticketNombre; set { if (RaiseAcceptPendingChange(value, _TamanoletraticketNombre)) { _TamanoletraticketNombre = value; OnPropertyChanged(); } } }

        private string? _CmbpreciodifinvClave;
        [XmlAttribute]
        public string? CmbpreciodifinvClave { get => _CmbpreciodifinvClave; set { if (RaiseAcceptPendingChange(value, _CmbpreciodifinvClave)) { _CmbpreciodifinvClave = value; OnPropertyChanged(); } } }

        private string? _CmbpreciodifinvNombre;
        [XmlAttribute]
        public string? CmbpreciodifinvNombre { get => _CmbpreciodifinvNombre; set { if (RaiseAcceptPendingChange(value, _CmbpreciodifinvNombre)) { _CmbpreciodifinvNombre = value; OnPropertyChanged(); } } }

        private string? _FormatoticketcortoidcomboboxClave;
        [XmlAttribute]
        public string? FormatoticketcortoidcomboboxClave { get => _FormatoticketcortoidcomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormatoticketcortoidcomboboxClave)) { _FormatoticketcortoidcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormatoticketcortoidcomboboxNombre;
        [XmlAttribute]
        public string? FormatoticketcortoidcomboboxNombre { get => _FormatoticketcortoidcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormatoticketcortoidcomboboxNombre)) { _FormatoticketcortoidcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _OrdenimpresioncomboboxClave;
        [XmlAttribute]
        public string? OrdenimpresioncomboboxClave { get => _OrdenimpresioncomboboxClave; set { if (RaiseAcceptPendingChange(value, _OrdenimpresioncomboboxClave)) { _OrdenimpresioncomboboxClave = value; OnPropertyChanged(); } } }

        private string? _OrdenimpresioncomboboxNombre;
        [XmlAttribute]
        public string? OrdenimpresioncomboboxNombre { get => _OrdenimpresioncomboboxNombre; set { if (RaiseAcceptPendingChange(value, _OrdenimpresioncomboboxNombre)) { _OrdenimpresioncomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _TipoutilidadidClave;
        [XmlAttribute]
        public string? TipoutilidadidClave { get => _TipoutilidadidClave; set { if (RaiseAcceptPendingChange(value, _TipoutilidadidClave)) { _TipoutilidadidClave = value; OnPropertyChanged(); } } }

        private string? _TipoutilidadidNombre;
        [XmlAttribute]
        public string? TipoutilidadidNombre { get => _TipoutilidadidNombre; set { if (RaiseAcceptPendingChange(value, _TipoutilidadidNombre)) { _TipoutilidadidNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecioxpzacajacomboboxClave;
        [XmlAttribute]
        public string? ListaprecioxpzacajacomboboxClave { get => _ListaprecioxpzacajacomboboxClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioxpzacajacomboboxClave)) { _ListaprecioxpzacajacomboboxClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioxpzacajacomboboxNombre;
        [XmlAttribute]
        public string? ListaprecioxpzacajacomboboxNombre { get => _ListaprecioxpzacajacomboboxNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioxpzacajacomboboxNombre)) { _ListaprecioxpzacajacomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecioxuempaquecomboboxClave;
        [XmlAttribute]
        public string? ListaprecioxuempaquecomboboxClave { get => _ListaprecioxuempaquecomboboxClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioxuempaquecomboboxClave)) { _ListaprecioxuempaquecomboboxClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioxuempaquecomboboxNombre;
        [XmlAttribute]
        public string? ListaprecioxuempaquecomboboxNombre { get => _ListaprecioxuempaquecomboboxNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioxuempaquecomboboxNombre)) { _ListaprecioxuempaquecomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _ListapreciominimocomboboxClave;
        [XmlAttribute]
        public string? ListapreciominimocomboboxClave { get => _ListapreciominimocomboboxClave; set { if (RaiseAcceptPendingChange(value, _ListapreciominimocomboboxClave)) { _ListapreciominimocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _ListapreciominimocomboboxNombre;
        [XmlAttribute]
        public string? ListapreciominimocomboboxNombre { get => _ListapreciominimocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _ListapreciominimocomboboxNombre)) { _ListapreciominimocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CampoimpocostorepoClave;
        [XmlAttribute]
        public string? CampoimpocostorepoClave { get => _CampoimpocostorepoClave; set { if (RaiseAcceptPendingChange(value, _CampoimpocostorepoClave)) { _CampoimpocostorepoClave = value; OnPropertyChanged(); } } }

        private string? _CampoimpocostorepoNombre;
        [XmlAttribute]
        public string? CampoimpocostorepoNombre { get => _CampoimpocostorepoNombre; set { if (RaiseAcceptPendingChange(value, _CampoimpocostorepoNombre)) { _CampoimpocostorepoNombre = value; OnPropertyChanged(); } } }

        private string? _AlmacenrecepcionidClave;
        [XmlAttribute]
        public string? AlmacenrecepcionidClave { get => _AlmacenrecepcionidClave; set { if (RaiseAcceptPendingChange(value, _AlmacenrecepcionidClave)) { _AlmacenrecepcionidClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenrecepcionidNombre;
        [XmlAttribute]
        public string? AlmacenrecepcionidNombre { get => _AlmacenrecepcionidNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenrecepcionidNombre)) { _AlmacenrecepcionidNombre = value; OnPropertyChanged(); } } }

        private string? _FiscalestadoClave;
        [XmlAttribute]
        public string? FiscalestadoClave { get => _FiscalestadoClave; set { if (RaiseAcceptPendingChange(value, _FiscalestadoClave)) { _FiscalestadoClave = value; OnPropertyChanged(); } } }

        private string? _FiscalestadoNombre;
        [XmlAttribute]
        public string? FiscalestadoNombre { get => _FiscalestadoNombre; set { if (RaiseAcceptPendingChange(value, _FiscalestadoNombre)) { _FiscalestadoNombre = value; OnPropertyChanged(); } } }

        private string? _FormatofacturacomboboxClave;
        [XmlAttribute]
        public string? FormatofacturacomboboxClave { get => _FormatofacturacomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormatofacturacomboboxClave)) { _FormatofacturacomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormatofacturacomboboxNombre;
        [XmlAttribute]
        public string? FormatofacturacomboboxNombre { get => _FormatofacturacomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormatofacturacomboboxNombre)) { _FormatofacturacomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _FiltroprodsatcomboboxClave;
        [XmlAttribute]
        public string? FiltroprodsatcomboboxClave { get => _FiltroprodsatcomboboxClave; set { if (RaiseAcceptPendingChange(value, _FiltroprodsatcomboboxClave)) { _FiltroprodsatcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FiltroprodsatcomboboxNombre;
        [XmlAttribute]
        public string? FiltroprodsatcomboboxNombre { get => _FiltroprodsatcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FiltroprodsatcomboboxNombre)) { _FiltroprodsatcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _MonederolistaprecioidcomboboxClave;
        [XmlAttribute]
        public string? MonederolistaprecioidcomboboxClave { get => _MonederolistaprecioidcomboboxClave; set { if (RaiseAcceptPendingChange(value, _MonederolistaprecioidcomboboxClave)) { _MonederolistaprecioidcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _MonederolistaprecioidcomboboxNombre;
        [XmlAttribute]
        public string? MonederolistaprecioidcomboboxNombre { get => _MonederolistaprecioidcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _MonederolistaprecioidcomboboxNombre)) { _MonederolistaprecioidcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _PvcolorearClave;
        [XmlAttribute]
        public string? PvcolorearClave { get => _PvcolorearClave; set { if (RaiseAcceptPendingChange(value, _PvcolorearClave)) { _PvcolorearClave = value; OnPropertyChanged(); } } }

        private string? _PvcolorearNombre;
        [XmlAttribute]
        public string? PvcolorearNombre { get => _PvcolorearNombre; set { if (RaiseAcceptPendingChange(value, _PvcolorearNombre)) { _PvcolorearNombre = value; OnPropertyChanged(); } } }

        private string? _TipovendedormovilClave;
        [XmlAttribute]
        public string? TipovendedormovilClave { get => _TipovendedormovilClave; set { if (RaiseAcceptPendingChange(value, _TipovendedormovilClave)) { _TipovendedormovilClave = value; OnPropertyChanged(); } } }

        private string? _TipovendedormovilNombre;
        [XmlAttribute]
        public string? TipovendedormovilNombre { get => _TipovendedormovilNombre; set { if (RaiseAcceptPendingChange(value, _TipovendedormovilNombre)) { _TipovendedormovilNombre = value; OnPropertyChanged(); } } }

        private string? _ScreenconfigClave;
        [XmlAttribute]
        public string? ScreenconfigClave { get => _ScreenconfigClave; set { if (RaiseAcceptPendingChange(value, _ScreenconfigClave)) { _ScreenconfigClave = value; OnPropertyChanged(); } } }

        private string? _ScreenconfigNombre;
        [XmlAttribute]
        public string? ScreenconfigNombre { get => _ScreenconfigNombre; set { if (RaiseAcceptPendingChange(value, _ScreenconfigNombre)) { _ScreenconfigNombre = value; OnPropertyChanged(); } } }

        private string? _TiposyncmovilClave;
        [XmlAttribute]
        public string? TiposyncmovilClave { get => _TiposyncmovilClave; set { if (RaiseAcceptPendingChange(value, _TiposyncmovilClave)) { _TiposyncmovilClave = value; OnPropertyChanged(); } } }

        private string? _TiposyncmovilNombre;
        [XmlAttribute]
        public string? TiposyncmovilNombre { get => _TiposyncmovilNombre; set { if (RaiseAcceptPendingChange(value, _TiposyncmovilNombre)) { _TiposyncmovilNombre = value; OnPropertyChanged(); } } }

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



    }

    
     
}

