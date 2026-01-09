
using BindingModels;
using IposV3.Model;
using System.Xml.Serialization;

namespace IposV3.Services.FacturaElectronica
{
    public class VirtualXmlHelperModel
    {
        




        private string? mensaje;


        public string? Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        private VirtualPACInfo? virtualPacInfo;

        public VirtualPACInfo? VirtualPacInfo
        {
            get { return virtualPacInfo; }
            set { virtualPacInfo = value; }
        }

        private CiberSATInfo? ciberSatInfo;

        public CiberSATInfo? CiberSatInfo
        {
            get { return ciberSatInfo; }
            set { ciberSatInfo = value; }
        }


        public CartaporteBindingModel? iCARTAPORTE;
        public CartaporteBindingModel? ICARTAPORTE
        {
            get
            {
                return this.iCARTAPORTE;
            }
            set
            {
                this.iCARTAPORTE = value;
            }
        }


        private ComprobanteInfo? comprobanteInfo;

        public ComprobanteInfo? ComprobanteInfo
        {
            get { return comprobanteInfo; }
            set { comprobanteInfo = value; }
        }

        private ComprobanteInfoEx? comprobanteInfoEx;

        public ComprobanteInfoEx? ComprobanteInfoEx
        {
            get { return comprobanteInfoEx; }
            set { comprobanteInfoEx = value; }
        }

        private ComprobanteCFDInfo? comprobanteCfdInfo;

        public ComprobanteCFDInfo? ComprobanteCfdInfo
        {
            get { return comprobanteCfdInfo; }
            set { comprobanteCfdInfo = value; }
        }

        private EmisorInfo? emisorInfo;

        public EmisorInfo? EmisorInfo
        {
            get { return emisorInfo; }
            set { emisorInfo = value; }
        }

        private ReceptorInfo? receptorInfo;

        public ReceptorInfo? ReceptorInfo
        {
            get { return receptorInfo; }
            set { receptorInfo = value; }
        }

        private InformacionGlobal? informacionGlobal;

        public InformacionGlobal? InformacionGlobal
        {
            get { return informacionGlobal; }
            set { informacionGlobal = value; }
        }

        private List<Concepto>? conceptos;

        public List<Concepto>? Conceptos
        {
            get { return conceptos; }
            set { conceptos = value; }
        }


        private List<PagoSAT>? pagosSat;

        public List<PagoSAT>? PagosSat
        {
            get { return pagosSat; }
            set { pagosSat = value; }
        }


        private List<Traslado>? impuestosTrasladados;

        public List<Traslado>? ImpuestosTrasladados
        {
            get { return impuestosTrasladados; }
            set { impuestosTrasladados = value; }
        }

        private List<Retencion>? impuestosRetenidos;

        public List<Retencion>? ImpuestosRetenidos
        {
            get { return impuestosRetenidos; }
            set { impuestosRetenidos = value; }
        }

        private ImpuestosInfo? impuestosInfo;

        public ImpuestosInfo? ImpuestosInfo
        {
            get { return impuestosInfo; }
            set { impuestosInfo = value; }
        }

        private ImpuestosLocalesInfo? impuestosLocalesInfo;

        public ImpuestosLocalesInfo? ImpuestosLocalesInfo
        {
            get { return impuestosLocalesInfo; }
            set { impuestosLocalesInfo = value; }
        }

        private List<ImpuestoLocalTrasladado>? localesTrasladados;

        public List<ImpuestoLocalTrasladado>? LocalesTrasladados
        {
            get { return localesTrasladados; }
            set { localesTrasladados = value; }
        }

        private List<ImpuestoLocalRetenido>? localesRetenidos;

        public List<ImpuestoLocalRetenido>? LocalesRetenidos
        {
            get { return localesRetenidos; }
            set { localesRetenidos = value; }
        }

        private Addenda? addendas;

        public Addenda? Addendas
        {
            get { return addendas; }
            set { addendas = value; }
        }

        private EmisorExpedidoEn? emisorExpedidoEn;

        public EmisorExpedidoEn? EmisorExpedidoEn
        {
            get { return emisorExpedidoEn; }
            set { emisorExpedidoEn = value; }
        }

        private string? rutaCsd;

        public string? RutaCsd
        {
            get { return rutaCsd; }
            set { rutaCsd = value; }
        }

        private string? llave;

        public string? Llave
        {
            get { return llave; }
            set { llave = value; }
        }

        private string? claveLlave;

        public string? ClaveLlave
        {
            get { return claveLlave; }
            set { claveLlave = value; }
        }

        private string? rutaXml;

        public string? RutaXml
        {
            get { return rutaXml; }
            set { rutaXml = value; }
        }

        private string? rutaPdf;

        public string? RutaPdf
        {
            get { return rutaPdf; }
            set { rutaPdf = value; }
        }

        private string? version;

        public string? Version
        {
            get { return version; }
            set { version = value; }
        }



        //Flags
        private bool manejaAddenda;

        public bool ManejaAddenda
        {
            get { return manejaAddenda; }
            set { manejaAddenda = value; }
        }

        private bool manejaImpuestosLocales;

        public bool ManejaImpuestosLocales
        {
            get { return manejaImpuestosLocales; }
            set { manejaImpuestosLocales = value; }
        }

        private bool manejaTrasladados;

        public bool ManejaTrasladados
        {
            get { return manejaTrasladados; }
            set { manejaTrasladados = value; }
        }

        private bool manejaRetenidos;

        public bool ManejaRetenidos
        {
            get { return manejaRetenidos; }
            set { manejaRetenidos = value; }
        }


        private Dictionary<String, List<String>>? cfdiRelacionados;
        public Dictionary<String, List<String>>? CfdiRelacionados
        {
            get { return cfdiRelacionados; }
            set { cfdiRelacionados = value; }
        }



        public VirtualXmlHelperModel()
        {

            mensaje = String.Empty;
            version = DBValues._VERSION_FACTURACION;
        }





    }

    public class TimbradoInfo
    {
        private Int64 _EmpresaId;
        [XmlAttribute]
        public Int64 EmpresaId { get => _EmpresaId; set { _EmpresaId = value; } }

        private Int64 _SucursalId;
        [XmlAttribute]
        public Int64 SucursalId { get => _SucursalId; set { _SucursalId = value; } }

        private Int64 _DoctoId;
        [XmlAttribute]
        public Int64 DoctoId { get => _DoctoId; set { _DoctoId = value; } }

        private String? _Tipocomprobanteespecial ;
        [XmlAttribute]
        public String? Tipocomprobanteespecial { get => _Tipocomprobanteespecial; set { _Tipocomprobanteespecial = value; } }

        private Boolean _Generarcartaporte;
        [XmlAttribute]
        public Boolean Generarcartaporte { get => _Generarcartaporte; set { _Generarcartaporte = value; } }

        [XmlAttribute]
        private string? _Timbradouuid;
        public string? Timbradouuid { get => _Timbradouuid; set { _Timbradouuid = value; } }

        [XmlAttribute]
        private string? _Timbradofecha;

        public string? Timbradofecha { get => _Timbradofecha; set { _Timbradofecha = value; } }


        [XmlAttribute]
        private string? _Timbradocertsat;
        public string? Timbradocertsat { get => _Timbradocertsat; set { _Timbradocertsat = value; } }


        [XmlAttribute]
        private string? _Timbradosellosat;
        public string? Timbradosellosat { get => _Timbradosellosat; set { _Timbradosellosat = value; } }


        [XmlAttribute]
        private string? _Timbradosellocfdi;
        public string? Timbradosellocfdi { get => _Timbradosellocfdi; set { _Timbradosellocfdi = value; } }


        [XmlAttribute]
        private string? _Timbradoformapagosat;
        public string? Timbradoformapagosat { get => _Timbradoformapagosat; set { _Timbradoformapagosat = value; } }

    }
}
