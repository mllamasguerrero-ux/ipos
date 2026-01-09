
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    
    [XmlRoot]
    public class Docto_traslado_recWFBindingModel : Validatable
    {

        public Docto_traslado_recWFBindingModel()
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

        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }

        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _Proveedornombre;
        [XmlAttribute]
        public string? Proveedornombre { get => _Proveedornombre; set { if (RaiseAcceptPendingChange(value, _Proveedornombre)) { _Proveedornombre = value; OnPropertyChanged(); } } }

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

        private string? _Folio_c;
        [XmlAttribute]
        public string? Folio_c { get => _Folio_c; set { if (RaiseAcceptPendingChange(value, _Folio_c)) { _Folio_c = value; OnPropertyChanged(); } } }

        private string? _Factura_c;
        [XmlAttribute]
        public string? Factura_c { get => _Factura_c; set { if (RaiseAcceptPendingChange(value, _Factura_c)) { _Factura_c = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafactura_c;
        [XmlAttribute]
        public DateTimeOffset? Fechafactura_c { get => _Fechafactura_c; set { if (RaiseAcceptPendingChange(value, _Fechafactura_c)) { _Fechafactura_c = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence_c;
        [XmlAttribute]
        public DateTimeOffset? Fechavence_c { get => _Fechavence_c; set { if (RaiseAcceptPendingChange(value, _Fechavence_c)) { _Fechavence_c = value; OnPropertyChanged(); } } }

        private long? _Origenfiscalid;
        [XmlAttribute]
        public long? Origenfiscalid { get => _Origenfiscalid; set { if (RaiseAcceptPendingChange(value, _Origenfiscalid)) { _Origenfiscalid = value; OnPropertyChanged(); } } }

        private string? _Origenfiscalclave;
        [XmlAttribute]
        public string? Origenfiscalclave { get => _Origenfiscalclave; set { if (RaiseAcceptPendingChange(value, _Origenfiscalclave)) { _Origenfiscalclave = value; OnPropertyChanged(); } } }

        private string? _Origenfiscalnombre;
        [XmlAttribute]
        public string? Origenfiscalnombre { get => _Origenfiscalnombre; set { if (RaiseAcceptPendingChange(value, _Origenfiscalnombre)) { _Origenfiscalnombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Estraslado;
        [XmlAttribute]
        public BoolCN? Estraslado { get => _Estraslado; set { if (RaiseAcceptPendingChange(value, _Estraslado)) { _Estraslado = value; OnPropertyChanged(); } } }

        private BoolCN? _Esdevolucion;
        [XmlAttribute]
        public BoolCN? Esdevolucion { get => _Esdevolucion; set { if (RaiseAcceptPendingChange(value, _Esdevolucion)) { _Esdevolucion = value; OnPropertyChanged(); } } }

        private string? _Foliodevolucion;
        [XmlAttribute]
        public string? Foliodevolucion { get => _Foliodevolucion; set { if (RaiseAcceptPendingChange(value, _Foliodevolucion)) { _Foliodevolucion = value; OnPropertyChanged(); } } }

        private string? _Essurtimientomerca;
        [XmlAttribute]
        public string? Essurtimientomerca { get => _Essurtimientomerca; set { if (RaiseAcceptPendingChange(value, _Essurtimientomerca)) { _Essurtimientomerca = value; OnPropertyChanged(); } } }

        private string? _Foliosolicitudmercancia;
        [XmlAttribute]
        public string? Foliosolicitudmercancia { get => _Foliosolicitudmercancia; set { if (RaiseAcceptPendingChange(value, _Foliosolicitudmercancia)) { _Foliosolicitudmercancia = value; OnPropertyChanged(); } } }

        private string? _Foliotrasladooriginal;
        [XmlAttribute]
        public string? Foliotrasladooriginal { get => _Foliotrasladooriginal; set { if (RaiseAcceptPendingChange(value, _Foliotrasladooriginal)) { _Foliotrasladooriginal = value; OnPropertyChanged(); } } }

        private long? _Idsolicitudmercancia;
        [XmlAttribute]
        public long? Idsolicitudmercancia { get => _Idsolicitudmercancia; set { if (RaiseAcceptPendingChange(value, _Idsolicitudmercancia)) { _Idsolicitudmercancia = value; OnPropertyChanged(); } } }

        private long? _Idtrasladooriginal;
        [XmlAttribute]
        public long? Idtrasladooriginal { get => _Idtrasladooriginal; set { if (RaiseAcceptPendingChange(value, _Idtrasladooriginal)) { _Idtrasladooriginal = value; OnPropertyChanged(); } } }

        private long? _Iddevolucion;
        [XmlAttribute]
        public long? Iddevolucion { get => _Iddevolucion; set { if (RaiseAcceptPendingChange(value, _Iddevolucion)) { _Iddevolucion = value; OnPropertyChanged(); } } }



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


        public static Docto_traslado_recWFBindingModel CreateFromAnonymous( Tmp_docto_traslado_recepcion obj)
        {
            var buffer_Tmp_docto_traslado_recWFBindingModel = new Docto_traslado_recWFBindingModel();

        	buffer_Tmp_docto_traslado_recWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Tmp_docto_traslado_recWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Id = obj.Id;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Activo = obj.Activo;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Estatusdoctoid = obj.Estatusdoctoid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Estatusdoctoclave = obj.Estatusdoctoclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Estatusdoctonombre = obj.Estatusdoctonombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Usuarionombre = obj.Usuarionombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Fecha = obj.Fecha;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Serie = obj.Serie;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Folio = obj.Folio;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Importe = obj.Importe;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Descuento = obj.Descuento;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Subtotal = obj.Subtotal;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Iva = obj.Iva;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Ieps = obj.Ieps;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Total = obj.Total;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Cajaid = obj.Cajaid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Cajaclave = obj.Cajaclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Cajanombre = obj.Cajanombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Proveedorid = obj.Proveedorid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Proveedorclave = obj.Proveedorclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Proveedornombre = obj.Proveedornombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Tipodoctoid = obj.Tipodoctoid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Tipodoctoclave = obj.Tipodoctoclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Tipodoctonombre = obj.Tipodoctonombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Referencia = obj.Referencia;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Foliosat = obj.Foliosat;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Seriesat = obj.Seriesat;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Sucursaltid = obj.Sucursaltid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Sucursaltclave = obj.Sucursaltclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Sucursaltnombre = obj.Sucursaltnombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Almacentid = obj.Almacentid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Almacentclave = obj.Almacentclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Almacentnombre = obj.Almacentnombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Folio_c = obj.Folio_c;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Factura_c = obj.Factura_c;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Fechafactura_c = obj.Fechafactura_c;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Fechavence_c = obj.Fechavence_c;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Origenfiscalid = obj.Origenfiscalid;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Origenfiscalclave = obj.Origenfiscalclave;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Origenfiscalnombre = obj.Origenfiscalnombre;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Estraslado = obj.Estraslado;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Esdevolucion = obj.Esdevolucion;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Foliodevolucion = obj.Foliodevolucion;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Essurtimientomerca = obj.Essurtimientomerca;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Foliosolicitudmercancia = obj.Foliosolicitudmercancia;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Foliotrasladooriginal = obj.Foliotrasladooriginal;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Idsolicitudmercancia = obj.Idsolicitudmercancia;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Idtrasladooriginal = obj.Idtrasladooriginal;

        	buffer_Tmp_docto_traslado_recWFBindingModel._Iddevolucion = obj.Iddevolucion;

            return buffer_Tmp_docto_traslado_recWFBindingModel;
        }


    }


    public class Docto_traslado_recWFParam : BaseParam
    {

        public Docto_traslado_recWFParam() : base()
        {

        }

        public Docto_traslado_recWFParam(BaseParam baseParam) : this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {

        }
        public Docto_traslado_recWFParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

            this.Id = 0;

            this.EmpresaId = 0;

            this.SucursalId = 0;


        }



        public Docto_traslado_recWFParam(long? empresaid, long? sucursalid
                    , long? Id
                    , long? EmpresaId
                    , long? SucursalId
                  ) : base(empresaid, sucursalid)
        {

            this.Id = Id;

            this.EmpresaId = EmpresaId;

            this.SucursalId = SucursalId;

        }



        public long? Id { get; set; }

        public long? EmpresaId { get; set; }

        public long? SucursalId { get; set; }




    }


}

