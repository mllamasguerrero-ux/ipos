
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
    public class WFPagoCompProveeEditWFBindingModel : Validatable
    {

        public WFPagoCompProveeEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecharecepcion { get => _Dtpfecharecepcion; set { if (RaiseAcceptPendingChange(value, _Dtpfecharecepcion)) { _Dtpfecharecepcion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaelaboracion { get => _Dtpfechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Dtpfechaelaboracion)) { _Dtpfechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaaplicado { get => _Dtpfechaaplicado; set { if (RaiseAcceptPendingChange(value, _Dtpfechaaplicado)) { _Dtpfechaaplicado = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbaplicado;
        [XmlAttribute]
        public BoolCN? Cbaplicado { get => _Cbaplicado; set { if (RaiseAcceptPendingChange(value, _Cbaplicado)) { _Cbaplicado = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private long? _Formapagocombobox;
        [XmlAttribute]
        public long? Formapagocombobox { get => _Formapagocombobox; set { if (RaiseAcceptPendingChange(value, _Formapagocombobox)) { _Formapagocombobox = value; OnPropertyChanged(); } } }

        private long? _Combobanco;
        [XmlAttribute]
        public long? Combobanco { get => _Combobanco; set { if (RaiseAcceptPendingChange(value, _Combobanco)) { _Combobanco = value; OnPropertyChanged(); } } }

        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

        private string? _Tbcuentapago;
        [XmlAttribute]
        public string? Tbcuentapago { get => _Tbcuentapago; set { if (RaiseAcceptPendingChange(value, _Tbcuentapago)) { _Tbcuentapago = value; OnPropertyChanged(); } } }

        private string? _Tbrefinterno;
        [XmlAttribute]
        public string? Tbrefinterno { get => _Tbrefinterno; set { if (RaiseAcceptPendingChange(value, _Tbrefinterno)) { _Tbrefinterno = value; OnPropertyChanged(); } } }

        private string? _Tbidpago;
        [XmlAttribute]
        public string? Tbidpago { get => _Tbidpago; set { if (RaiseAcceptPendingChange(value, _Tbidpago)) { _Tbidpago = value; OnPropertyChanged(); } } }

        private string? _Tbnotas;
        [XmlAttribute]
        public string? Tbnotas { get => _Tbnotas; set { if (RaiseAcceptPendingChange(value, _Tbnotas)) { _Tbnotas = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private long? _Gruposucursalid;
        [XmlAttribute]
        public long? Gruposucursalid { get => _Gruposucursalid; set { if (RaiseAcceptPendingChange(value, _Gruposucursalid)) { _Gruposucursalid = value; OnPropertyChanged(); } } }

        private string? _GruposucursalidClave;
        [XmlAttribute]
        public string? GruposucursalidClave { get => _GruposucursalidClave; set { if (RaiseAcceptPendingChange(value, _GruposucursalidClave)) { _GruposucursalidClave = value; OnPropertyChanged(); } } }

        private string? _GruposucursalidNombre;
        [XmlAttribute]
        public string? GruposucursalidNombre { get => _GruposucursalidNombre; set { if (RaiseAcceptPendingChange(value, _GruposucursalidNombre)) { _GruposucursalidNombre = value; OnPropertyChanged(); } } }

        private decimal? _Montoaplicaradd;
        [XmlAttribute]
        public decimal? Montoaplicaradd { get => _Montoaplicaradd; set { if (RaiseAcceptPendingChange(value, _Montoaplicaradd)) { _Montoaplicaradd = value; OnPropertyChanged(); } } }

        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _SucursalidClave;
        [XmlAttribute]
        public string? SucursalidClave { get => _SucursalidClave; set { if (RaiseAcceptPendingChange(value, _SucursalidClave)) { _SucursalidClave = value; OnPropertyChanged(); } } }

        private string? _SucursalidNombre;
        [XmlAttribute]
        public string? SucursalidNombre { get => _SucursalidNombre; set { if (RaiseAcceptPendingChange(value, _SucursalidNombre)) { _SucursalidNombre = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxClave;
        [XmlAttribute]
        public string? FormapagocomboboxClave { get => _FormapagocomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxClave)) { _FormapagocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxNombre;
        [XmlAttribute]
        public string? FormapagocomboboxNombre { get => _FormapagocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxNombre)) { _FormapagocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CombobancoClave;
        [XmlAttribute]
        public string? CombobancoClave { get => _CombobancoClave; set { if (RaiseAcceptPendingChange(value, _CombobancoClave)) { _CombobancoClave = value; OnPropertyChanged(); } } }

        private string? _CombobancoNombre;
        [XmlAttribute]
        public string? CombobancoNombre { get => _CombobancoNombre; set { if (RaiseAcceptPendingChange(value, _CombobancoNombre)) { _CombobancoNombre = value; OnPropertyChanged(); } } }

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

    
    [XmlRoot]
    public class WFPagoCompProveeEditWF_ComprassucsaldoBindingModel : Validatable
    {

        public WFPagoCompProveeEditWF_ComprassucsaldoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private string? _Sucursalnombre;
        [XmlAttribute]
        public string? Sucursalnombre { get => _Sucursalnombre; set { if (RaiseAcceptPendingChange(value, _Sucursalnombre)) { _Sucursalnombre = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Factura;
        [XmlAttribute]
        public string? Factura { get => _Factura; set { if (RaiseAcceptPendingChange(value, _Factura)) { _Factura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafactura;
        [XmlAttribute]
        public DateTimeOffset? Fechafactura { get => _Fechafactura; set { if (RaiseAcceptPendingChange(value, _Fechafactura)) { _Fechafactura = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private long? _Origenfiscalid;
        [XmlAttribute]
        public long? Origenfiscalid { get => _Origenfiscalid; set { if (RaiseAcceptPendingChange(value, _Origenfiscalid)) { _Origenfiscalid = value; OnPropertyChanged(); } } }

        private string? _Origenfiscalnombre;
        [XmlAttribute]
        public string? Origenfiscalnombre { get => _Origenfiscalnombre; set { if (RaiseAcceptPendingChange(value, _Origenfiscalnombre)) { _Origenfiscalnombre = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private decimal? _Montoaplicar;
        [XmlAttribute]
        public decimal? Montoaplicar { get => _Montoaplicar; set { if (RaiseAcceptPendingChange(value, _Montoaplicar)) { _Montoaplicar = value; OnPropertyChanged(); } } }

        private string? _Dgquitar;
        [XmlAttribute]
        public string? Dgquitar { get => _Dgquitar; set { if (RaiseAcceptPendingChange(value, _Dgquitar)) { _Dgquitar = value; OnPropertyChanged(); } } }

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


    [XmlRoot]
    public class WFPagoCompProveeEditWF_PagosaplicadossucBindingModel : Validatable
    {

        public WFPagoCompProveeEditWF_PagosaplicadossucBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Factura;
        [XmlAttribute]
        public string? Factura { get => _Factura; set { if (RaiseAcceptPendingChange(value, _Factura)) { _Factura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafactura;
        [XmlAttribute]
        public DateTimeOffset? Fechafactura { get => _Fechafactura; set { if (RaiseAcceptPendingChange(value, _Fechafactura)) { _Fechafactura = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private decimal? _Montoaplicar;
        [XmlAttribute]
        public decimal? Montoaplicar { get => _Montoaplicar; set { if (RaiseAcceptPendingChange(value, _Montoaplicar)) { _Montoaplicar = value; OnPropertyChanged(); } } }

        private string? _Origenfiscalnombre;
        [XmlAttribute]
        public string? Origenfiscalnombre { get => _Origenfiscalnombre; set { if (RaiseAcceptPendingChange(value, _Origenfiscalnombre)) { _Origenfiscalnombre = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Doctopagoid;
        [XmlAttribute]
        public long? Doctopagoid { get => _Doctopagoid; set { if (RaiseAcceptPendingChange(value, _Doctopagoid)) { _Doctopagoid = value; OnPropertyChanged(); } } }

        private string? _Sucursalnombre;
        [XmlAttribute]
        public string? Sucursalnombre { get => _Sucursalnombre; set { if (RaiseAcceptPendingChange(value, _Sucursalnombre)) { _Sucursalnombre = value; OnPropertyChanged(); } } }

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

