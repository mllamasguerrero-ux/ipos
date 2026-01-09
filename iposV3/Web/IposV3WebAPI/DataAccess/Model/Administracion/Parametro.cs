using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{

    public enum LetraEnTicket: short
    { Normal, Pequenia }

    public enum FormatTicketCorto : short
    { Normal, Por_linea }

    public enum OrdenImpresion : short
    { Normal, Descripcion, Descripcion1, Descripcion2 }


    public enum FormatoFactura : short
    { Normal, FastReport }


    public enum FiltroProductoSat : short
    { Todos, Parcial, Linea }

    public enum ModoAlertaPV : short
    { Ninguno_Especial, Precio_minimo_costo }

    public enum ConfigPantalla : short
    { Normal, Movil_mediano, Movil_10 }

    public enum TipoSyncMovil : short
    { WS, FTP }

    public enum TipoConexionMovil : short
    { Ninguno, Tipo1, Tipo2, Tipo3, Tipo4 }




    public class Parametro: EntityBase
    {

        public Parametro() : base()
        {
        }

        public Parametro(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }



        public long? Lista_precio_defid { get; set; }

        [ForeignKey("Lista_precio_defid")]
        public virtual Tipoprecio? Lista_precio_def { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Imp_prod_def { get; set; } = 0m;
        [StringLength(40)]
        public string? Estado_def { get; set; }
        [StringLength(1)]
        public string? Lista_precio_traspaso { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Promocion { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Cantidad { get; set; } = 0m;


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Utilidad { get; set; } = 0m;
        public DateTimeOffset? Fechaanterior { get; set; }
        public DateTimeOffset? Fechaactual { get; set; }
        public DateTimeOffset? Fechaultima { get; set; }
        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Max_inv_fis_cant { get; set; } = 0m;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Inventory_email { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Id_dosletras { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habilitar_impexp_aut { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comisionmedico { get; set; } = 0m;
        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comisiondependiente { get; set; } = 0m;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Ftphost { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Ftpusuario { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Ftppassword { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Smtphost { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Smtpusuario { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Smtppassword { get; set; }
        public int Smtpport { get; set; } = 0;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Smtpmailfrom { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Smtpmailto { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Cambiarprecio { get; set; } = BoolCN.N;
        public long? Listapreciominimo { get; set; }

        [ForeignKey("Listapreciominimo")]
        public virtual Tipoprecio? Listapreciominimo_ { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Compraentienda { get; set; } = BoolCN.N;


        [StringLength(Domains.Stdtext_verylargeLength)]
        public string? Header { get; set; }
        [StringLength(Domains.Stdtext_verylargeLength)]
        public string? Footer { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_sel_cliente { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_impr_cotizacion { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Mostrar_exis_suc { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Req_aprobacion_inv { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Reabrircortes { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentovale { get; set; } = 0m;
        public DateTimeOffset? Ult_fecha_imp_prod { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Imp_prod_total { get; set; } = BoolCN.N;


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombre { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Calle { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Numeroexterior { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Numerointerior { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Colonia { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Municipio { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Estado { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Codigopostal { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Fiscalcalle { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Fiscalnumerointerior { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Fiscalnumeroexterior { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Fiscalcolonia { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Fiscalmunicipio { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Fiscalestado { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Fiscalcodigopostal { get; set; }
        [StringLength(Domains.Stdtext_64Length)]
        public string? Certificadocsd { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Timbradouser { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Timbradopassword { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Timbradoarchivocertificado { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Timbradoarchivokey { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Timbradokey { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Fiscalnombre { get; set; }
        [StringLength(Domains.ClaveLength)]
        public string? Seriesat { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Usarfiscalesenexpedicion { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_facturaelectronica { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_verylargeLength)]
        public string? Footerventaapartado { get; set; }
        public long? Encargadoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Encargadoid")]
        public virtual Usuario? Encargado { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porc_comisionencargado { get; set; } = 0m;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porc_comisionvendedor { get; set; } = 0m;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Ftpfolder { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Ftpfolderpass { get; set; }
        [StringLength(Domains.ClaveLength)]
        public string? Seriesatdevolucion { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Cambiarprecioxuempaque { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Cambiarprecioxpzacaja { get; set; } = BoolCN.N;
        [StringLength(Domains.DoctoserieLength)]
        public string? Prefijobascula { get; set; }
        public short? Longprodbascula { get; set; }
        public short? Longpesobascula { get; set; }
        public long? Listaprecioxuempaque { get; set; }

        [ForeignKey("Listaprecioxuempaque")]
        public virtual Tipoprecio? Listaprecioxuempaque_ { get; set; }
        public long? Listaprecioxpzacaja { get; set; }

        [ForeignKey("Listaprecioxpzacaja")]
        public virtual Tipoprecio? Listaprecioxpzacaja_ { get; set; }
        public long? Listaprecioinimayo { get; set; }

        [ForeignKey("Listaprecioinimayo")]
        public virtual Tipoprecio? Listaprecioinimayo_ { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Hayvendedorpiso { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Envioautomaticoexistencias { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monederomontominimo { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Monederoaplicar { get; set; } = BoolCN.N;
        public int Monederocaducidad { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Imprimirnumeropiezas { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pacnombre { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pacusuario { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Cortepormail { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutareportes { get; set; }
        public int Doblecopiacredito { get; set; } = 0;
        public int Doblecopiatraslado { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Camposcustomalimportar { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Recibolargoconfactura { get; set; } = BoolCN.N;
        [StringLength(Domains.ClaveLength)]
        public string? Recibolargoprinter { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Recibolargopreview { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Preguntarrazonpreciomenor { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Preguntardatosentrega { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Fiscalregimen { get; set; }
        public int Cortacaducidad { get; set; } = 0;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Retencioniva { get; set; } = 0m;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Retencionisr { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Arrendatario { get; set; } = BoolCN.N;
        [StringLength(Domains.ClaveLength)]
        public string? Rutaimagenesproducto { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Mostrarimagenenventa { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Mostrarmontoahorro { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Smtpssl { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Mostrardescuentofactura { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Exportcatalogoaux { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Uiventaconcantidad { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Fact_elect_folder { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pedidos_folder { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Prefijocliente { get; set; }
        public DateTimeOffset? Fechainiciopedido { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Mostrarpzacajaenfactura { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Desgloseieps { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Cuentaieps { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Dividir_rem_fact { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Webservice { get; set; }
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Minutilidad { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejasuperlistaprecio { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejaalmacen { get; set; } = BoolCN.N;
        public long? Tipodescuentoprodid { get; set; }

        [ForeignKey("Tipodescuentoprodid")]
        public virtual Tipodescuentoprod? Tipodescuentoprod { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Manejareceta { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Autocompprod { get; set; } = BoolCN.N;
        public DateTimeOffset? Lastchangeproddesc { get; set; }
        public long? Tipoutilidadid { get; set; }

        [ForeignKey("Tipoutilidadid")]
        public virtual Tipoutilidad? Tipoutilidad { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Manejaquota { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Touch { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Esvendedormovil { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Cajasbotellas { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Precionetoenpv { get; set; } = BoolCN.N;

        public TipoSyncMovil? Tiposyncmovil { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Mostrarflash { get; set; } = BoolCN.N;


        public OrdenImpresion? Ordenimpresion { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Autocompcliente { get; set; } = BoolCN.N;
        public DateTimeOffset? Lastchangeclientenombre { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Precioxcajaenpv { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Localftphost { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Localwebservice { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Usarconexionlocal { get; set; } = BoolCN.N;
        public DateTimeOffset? Movillastpreciodate { get; set; }  
        public DateTimeOffset? Lastchangeprecioprod { get; set; }
        public int? Movilcierrecobranza { get; set; }
        public int? Movilcierreventa { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Mailtoinventario { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutarespaldoszip { get; set; }


        public ConfigPantalla? Screenconfig { get; set; }




        [Column(TypeName = "char(1)")]
        public BoolCN Promoenticket { get; set; } = BoolCN.N;



        public LetraEnTicket Tamanoletraticket { get; set; } = LetraEnTicket.Normal;


        [Column(TypeName = "char(1)")]
        public BoolCN Manejakits { get; set; } = BoolCN.N;


        public long? Campoimpocostorepoid { get; set; }

        [ForeignKey("Campoimpocostorepoid")]
        public virtual Tipoprecio? Campoimpocostorepo { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Rebajaespecial { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habilitarrepl { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Bdlocalrepl { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Pendmovilantesventa { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Preciosmovilantesventa { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Recalcularcambiocliente { get; set; } = BoolCN.N;


        public TipoConexionMovil? Tipovendedormovil { get; set; }


        public long? Vendedormovilid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Vendedormovilid")]
        public virtual Usuario? Vendedormovil { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Bdserverws { get; set; }
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Bdmatrizmovil { get; set; }
        public DateTimeOffset? Prodcambioparamovil { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Movilprocesosurtido { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Movilverificarventa { get; set; } = BoolCN.N;
        public int Pendmaxdias { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Reqautcancelarcoti { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Reqautelimdetallecoti { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Abrircajonalfincorte { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habsurtidopostpuesto { get; set; } = BoolCN.N;
        public long? Clienteconsolidadoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteconsolidadoid")]
        public virtual Cliente? Clienteconsolidado { get; set; }


        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutareportessistema { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Doblecopiaremision { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Reimpresionesconmarca { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habtotalizados { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Multipletipovale { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descuentotipo1texto { get; set; }
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentotipo1porc { get; set; } = 0m;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descuentotipo2texto { get; set; }
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentotipo2porc { get; set; } = 0m;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descuentotipo3texto { get; set; }
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentotipo3porc { get; set; } = 0m;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descuentotipo4texto { get; set; }
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentotipo4porc { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Habilitarlog { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutarespaldo { get; set; }
        public DateTimeOffset? Fecharespaldo { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Manejarretirodecaja { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montoretirocaja { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Aplicarmayoreoporlinea { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Comisionportarjeta { get; set; } = 0m;
        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Piezasigualesmediomayoreo { get; set; } = 0m;
        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Piezasdifmediomayoreo { get; set; } = 0m;
        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Piezasigualesmayoreo { get; set; } = 0m;
        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Piezasdifmayoreo { get; set; } = 0m;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Comisiontarjetaempresa { get; set; } = 0m;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Ivacomisiontarjetaempresa { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Preguntacancelacotizacion { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habverificacioncxc { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Mailejecutivo { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Ventasxcorteemail { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habventasafuturo { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Serviciosemida { get; set; } = BoolCN.N;
        public DateTimeOffset? Fechaactualizacionemida { get; set; }


        public FormatTicketCorto? Formatoticketcortoid { get; set; }



        [StringLength(Domains.ClaveLength)]
        public string? Seriesatabono { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habimpresioncortecajero { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habtrasladoporautorizacion { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habventasmostrador { get; set; } = BoolCN.N;
        public int Timeoutpindistsale { get; set; } = 0;
        public int Timeoutlookup { get; set; } = 0;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutaarchivosadjuntos { get; set; }
        public int Timeoutpindistsaleserv { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Habpagoservemida { get; set; } = BoolCN.N;
        public DateTimeOffset? Fechaactualizacionemidaserv { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habpromoxmontomin { get; set; } = BoolCN.N;


        public FormatoFactura? Formatofactelect { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montomaxsaldomenor { get; set; } = 0m;
        public long? Emidarecargalineaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Emidarecargalineaid")]
        public virtual Linea? Emidarecargalinea { get; set; }
        public long? Emidarecargamarcaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Emidarecargamarcaid")]
        public virtual Marca? Emidarecargamarca { get; set; }
        public long? Emidarecargaproveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Emidarecargaproveedorid")]
        public virtual Proveedor? Emidarecargaproveedor { get; set; }
        public long? Emidaserviciolineaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Emidaserviciolineaid")]
        public virtual Linea? Emidaserviciolinea { get; set; }
        public long? Emidaserviciomarcaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Emidaserviciomarcaid")]
        public virtual Marca? Emidaserviciomarca { get; set; }
        public long? Emidaservicioproveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Emidaservicioproveedorid")]
        public virtual Proveedor? Emidaservicioproveedor { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Emidaporcutilidadrecargas { get; set; } = 0m;
        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Emidautilidadpagoservicios { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Preciosordenados { get; set; } = BoolCN.N;
        public int Decimalesencantidad { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Eanpuederepetirse { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Bancomerhabpinpad { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_precioscliente { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Cxcvalidartraslados { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Preguntarsiesacredito { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habmensajeria { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Wsmensajeria { get; set; }
        public long? Ultmensajeid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Ultmensajeid")]
        public virtual Mensaje? Ultmensaje { get; set; }



        [Column(TypeName = "char(1)")]
        public BoolCN Habdesclineapersona { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejarloteimportacion { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejagastosadic { get; set; } = BoolCN.N;
        public int Caducidadminima { get; set; } = 0;



        public long? Precioajustedifinvid { get; set; }

        [ForeignKey("Precioajustedifinvid")]
        public virtual Tipoprecio? Precioajustedifinv { get; set; }




        [Column(TypeName = "char(1)")]
        public BoolCN Habbotonpagovale { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Unicavisitapordocto { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Plazoxproducto { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Autocompleteconexisenventa { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Ipwebserviceappinv { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutabdappinventaro { get; set; }
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutadbfexistenciasuc { get; set; }
        public long? Almacenrecepcionid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Almacenrecepcionid")]
        public virtual Almacen? Almacenrecepcion { get; set; }



        [Column(TypeName = "char(1)")]
        public BoolCN Aplicarcambiosprecauto { get; set; } = BoolCN.N;
        public short Numcancelactauto { get; set; } = 0;
        public short Numcancelactautousuario { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejacupones { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_devoluciontraslado { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_devolucionsurtidosuc { get; set; } = BoolCN.N;
        public int Versionwsexistencias { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejaproductospromocion { get; set; } = BoolCN.N;
        public long? Sat_metodopagoid { get; set; }

        [ForeignKey("Sat_metodopagoid")]
        public virtual Sat_metodopago? Sat_metodopago { get; set; }

        public long? Sat_regimenfiscalid { get; set; }

        [ForeignKey("Sat_regimenfiscalid")]
        public virtual Sat_regimenfiscal? Sat_regimenfiscal { get; set; }


        public FiltroProductoSat? Tiposeleccioncatalogosat { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Precionetoengrids { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Versioncfdi { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Pagoservconsolidado { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Mostrarinvinfoadicprod { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Wsespecialexistmatriz { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Hab_consolidadoautomatico { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutareplicadorexe { get; set; }
        public DateTimeOffset? Ult_consolidadoautomatico { get; set; }
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Ticketespecial { get; set; }
        [StringLength(Domains.ClaveLength)]
        public string? Ticketdefaultprinter { get; set; }
        [StringLength(Domains.ClaveLength)]
        public string? Recargasdefaultprinter { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Piezacajaenticket { get; set; } = BoolCN.N;
        public int Numticketsabono { get; set; } = 0;
        public ModoAlertaPV Pvcolorear { get; set; } = ModoAlertaPV.Ninguno_Especial;

        [Column(TypeName = "char(1)")]
        public BoolCN Generarfe { get; set; } = BoolCN.N;
        public int Intentosretirocaja { get; set; } = 0;

        [StringLength(Domains.DoctoserieLength)]
        public string? Vendedormovilclave { get; set; }
        public DateTimeOffset? Movil_ultcam_sesion { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Movil_tienevendedores { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutacatalogosupd { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Imprimircopiaalmacen { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Movil3_preimportar { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutaimportadatos { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Busquedatipo2 { get; set; } = BoolCN.N;
        public long? Agrupacionventaid { get; set; }
        [ForeignKey("Agrupacionventaid")]
        public virtual Agrupacionventa? Agrupacionventa { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Consfactomitirvales { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Destinobdvenmov { get; set; }
        public int Doblecopiacontado { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Desgloseiepsfactura { get; set; } = BoolCN.N;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutapolizapdf { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Imprimirbancoscorte { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Pago_tarjmenorpreciolista { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Impr_canc_venta { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Retirocajaalcerrarcorte { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Pagotarjmenorpreciolistaall { get; set; } = BoolCN.N;
        public DateTimeOffset? Kitsdef_ultact { get; set; }
        public DateTimeOffset? Kitsdef_unniv_ultact { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Preguntarservdom { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habppc { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Soloabonoaplicado { get; set; } = BoolCN.N;
        public long? Versiontopeid { get; set; }
        public long? Versioncomisionid { get; set; }
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Maxcomisionxcliente { get; set; } = 0m;
        [Column(TypeName = "char(1)")]
        public BoolCN Imprformaventatrasl { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habrevisionfinal { get; set; } = BoolCN.N;
        [StringLength(Domains.ClaveLength)]
        public string? Recibolargocotiprinter { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habfondodinamico { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habventaclisuc { get; set; } = BoolCN.N;
        public int Segundoscicloftp { get; set; } = 0;
        public int Diasmaxexpftp { get; set; } = 0;
        public int Diasmaximpftp { get; set; } = 0;
        [StringLength(Domains.Stdtext_largeLength)]
        public string? Wsdbf { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habwsdbf { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Comisiondebtarjetaempresa { get; set; } = 0m;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Comisiondebportarjeta { get; set; } = 0m;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Factconsmaxpor { get; set; } = 0m;
        public int Doblecopiatarjeta { get; set; } = 0;
        public DateTimeOffset? Fiscalfechacancelacion2 { get; set; }
        public int Cantticketretiro { get; set; } = 0;
        public int Cantticketabrircorte { get; set; } = 0;
        public int Cantticketcompras { get; set; } = 0;
        public int Cantticketfondocaja { get; set; } = 0;
        public int Cantticketgastos { get; set; } = 0;
        public int Cantticketdepositos { get; set; } = 0;
        public int Cantticketcierrecorte { get; set; } = 0;
        public int Cantticketcierrebilletes { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Manejautilidadprecios { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Habmultplazocompra { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Costorepoigualcostoult { get; set; } = BoolCN.N;
        [Column(TypeName = "char(1)")]
        public BoolCN Ticket_desc_vale_al_final { get; set; } = BoolCN.N;
        public long? Monederolistaprecioid { get; set; }

        [ForeignKey("Monederolistaprecioid")]
        public virtual Tipoprecio? Monederolistaprecio { get; set; }


        [StringLength(Domains.DoctoserieLength)]
        public string? Monederocamporef { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habsurtidoprevio { get; set; } = BoolCN.N;
        public int Numticketscomanda { get; set; } = 0;
        [Column(TypeName = "char(1)")]
        public BoolCN Recibopreviewcomanda { get; set; } = BoolCN.N;
        [StringLength(Domains.ClaveLength)]
        public string? Impresoracomanda { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Ticket_impr_desc2 { get; set; } = BoolCN.N;
        [StringLength(Domains.ClaveLength)]
        public string? Seriecomprtraslsat { get; set; }
        [Column(TypeName = "char(1)")]
        public BoolCN Habsurtidopostmovil { get; set; } = BoolCN.N;
        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcutilidadlistado { get; set; } = 0m;


        //public long? Sucursal_infoid { get; set; }

        //[ForeignKey("EmpresaId, SucursalId, Sucursal_infoid")]
        //public virtual Sucursal_info? Sucursal_info { get; set; }


        [NotMapped]
        public string? FormatoticketcortoClave { get => Formatoticketcortoid?.ToString(); set { } }

        [NotMapped]
        public string? FormatoticketcortoNombre { get => Formatoticketcortoid?.ToString(); set { } }

        [NotMapped]
        public string? TiposeleccioncatalogosatClave { get => Tiposeleccioncatalogosat?.ToString(); set { } }

        [NotMapped]
        public string? TiposeleccioncatalogosatNombre { get => Tiposeleccioncatalogosat?.ToString(); set { } }

        [NotMapped]
        public string? PvcolorearClave { get => Pvcolorear.ToString(); set { } }

        [NotMapped]
        public string? PvcolorearNombre { get => Pvcolorear.ToString(); set { } }

        [NotMapped]
        public string? ScreenconfigClave { get => Screenconfig?.ToString(); set { } }

        [NotMapped]
        public string? ScreenconfigNombre { get => Screenconfig?.ToString(); set { } }

        [NotMapped]
        public string? TipovendedormovilClave { get => Tipovendedormovil?.ToString(); set { } }

        [NotMapped]
        public string? TipovendedormovilNombre { get => Tipovendedormovil?.ToString(); set { } }

        [NotMapped]
        public string? TiposyncmovilClave { get => Tiposyncmovil?.ToString(); set { } }

        [NotMapped]
        public string? TiposyncmovilNombre { get => Tiposyncmovil?.ToString(); set { } }

        [NotMapped]
        public string? FormatofactelectClave { get => Formatofactelect?.ToString(); set { } }

        [NotMapped]
        public string? FormatofactelectNombre { get => Formatofactelect?.ToString(); set { } }



        [StringLength(Domains.Stdtext_largeLength)]
        public string? Rutafirmaimagenes { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Autpreciolistabajo { get; set; } = BoolCN.N;


        public long? Listapreciomaylinea { get; set; }

        [ForeignKey("Listapreciomaylinea")]
        public virtual Tipoprecio? Listapreciomaylinea_ { get; set; }


        public long? Listaprecmedmaylinea { get; set; }

        [ForeignKey("Listaprecmedmaylinea")]
        public virtual Tipoprecio? Listapremedmaylinea_ { get; set; }



    }
}
