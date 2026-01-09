
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
    public class WFPagoCompuestoEditWFBindingModel : Validatable
    {

        public WFPagoCompuestoEditWFBindingModel()
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

        private long? _Combobanco;
        [XmlAttribute]
        public long? Combobanco { get => _Combobanco; set { if (RaiseAcceptPendingChange(value, _Combobanco)) { _Combobanco = value; OnPropertyChanged(); } } }

        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

        private string? _Tbcuentapago;
        [XmlAttribute]
        public string? Tbcuentapago { get => _Tbcuentapago; set { if (RaiseAcceptPendingChange(value, _Tbcuentapago)) { _Tbcuentapago = value; OnPropertyChanged(); } } }

        private long? _Formapagocombobox;
        [XmlAttribute]
        public long? Formapagocombobox { get => _Formapagocombobox; set { if (RaiseAcceptPendingChange(value, _Formapagocombobox)) { _Formapagocombobox = value; OnPropertyChanged(); } } }

        private string? _Tbrefinterno;
        [XmlAttribute]
        public string? Tbrefinterno { get => _Tbrefinterno; set { if (RaiseAcceptPendingChange(value, _Tbrefinterno)) { _Tbrefinterno = value; OnPropertyChanged(); } } }

        private long? _Cuentabancoempresaidcombobox;
        [XmlAttribute]
        public long? Cuentabancoempresaidcombobox { get => _Cuentabancoempresaidcombobox; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresaidcombobox)) { _Cuentabancoempresaidcombobox = value; OnPropertyChanged(); } } }

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

        private string? _Tbidpago;
        [XmlAttribute]
        public string? Tbidpago { get => _Tbidpago; set { if (RaiseAcceptPendingChange(value, _Tbidpago)) { _Tbidpago = value; OnPropertyChanged(); } } }

        private BoolCN? _Timbrados;
        [XmlAttribute]
        public BoolCN? Timbrados { get => _Timbrados; set { if (RaiseAcceptPendingChange(value, _Timbrados)) { _Timbrados = value; OnPropertyChanged(); } } }

        private string? _CombobancoClave;
        [XmlAttribute]
        public string? CombobancoClave { get => _CombobancoClave; set { if (RaiseAcceptPendingChange(value, _CombobancoClave)) { _CombobancoClave = value; OnPropertyChanged(); } } }

        private string? _CombobancoNombre;
        [XmlAttribute]
        public string? CombobancoNombre { get => _CombobancoNombre; set { if (RaiseAcceptPendingChange(value, _CombobancoNombre)) { _CombobancoNombre = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxClave;
        [XmlAttribute]
        public string? FormapagocomboboxClave { get => _FormapagocomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxClave)) { _FormapagocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxNombre;
        [XmlAttribute]
        public string? FormapagocomboboxNombre { get => _FormapagocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxNombre)) { _FormapagocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CuentabancoempresaidcomboboxClave;
        [XmlAttribute]
        public string? CuentabancoempresaidcomboboxClave { get => _CuentabancoempresaidcomboboxClave; set { if (RaiseAcceptPendingChange(value, _CuentabancoempresaidcomboboxClave)) { _CuentabancoempresaidcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _CuentabancoempresaidcomboboxNombre;
        [XmlAttribute]
        public string? CuentabancoempresaidcomboboxNombre { get => _CuentabancoempresaidcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _CuentabancoempresaidcomboboxNombre)) { _CuentabancoempresaidcomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFPagoCompuestoEditWF_DoctosconsaldoBindingModel : Validatable
    {

        public WFPagoCompuestoEditWF_DoctosconsaldoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Consecutivo;
        [XmlAttribute]
        public long? Consecutivo { get => _Consecutivo; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value; OnPropertyChanged(); } } }

        private string? _Caja;
        [XmlAttribute]
        public string? Caja { get => _Caja; set { if (RaiseAcceptPendingChange(value, _Caja)) { _Caja = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Clavetipodocto;
        [XmlAttribute]
        public string? Clavetipodocto { get => _Clavetipodocto; set { if (RaiseAcceptPendingChange(value, _Clavetipodocto)) { _Clavetipodocto = value; OnPropertyChanged(); } } }

        private string? _Claveestatusdocto;
        [XmlAttribute]
        public string? Claveestatusdocto { get => _Claveestatusdocto; set { if (RaiseAcceptPendingChange(value, _Claveestatusdocto)) { _Claveestatusdocto = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Seriefoliosat;
        [XmlAttribute]
        public string? Seriefoliosat { get => _Seriefoliosat; set { if (RaiseAcceptPendingChange(value, _Seriefoliosat)) { _Seriefoliosat = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private decimal? _Montoaplicar;
        [XmlAttribute]
        public decimal? Montoaplicar { get => _Montoaplicar; set { if (RaiseAcceptPendingChange(value, _Montoaplicar)) { _Montoaplicar = value; OnPropertyChanged(); } } }

        private string? _Usuario;
        [XmlAttribute]
        public string? Usuario { get => _Usuario; set { if (RaiseAcceptPendingChange(value, _Usuario)) { _Usuario = value; OnPropertyChanged(); } } }

        private string? _Persona;
        [XmlAttribute]
        public string? Persona { get => _Persona; set { if (RaiseAcceptPendingChange(value, _Persona)) { _Persona = value; OnPropertyChanged(); } } }

        private string? _Sucursal;
        [XmlAttribute]
        public string? Sucursal { get => _Sucursal; set { if (RaiseAcceptPendingChange(value, _Sucursal)) { _Sucursal = value; OnPropertyChanged(); } } }

        private string? _Sucursaldestinonombre;
        [XmlAttribute]
        public string? Sucursaldestinonombre { get => _Sucursaldestinonombre; set { if (RaiseAcceptPendingChange(value, _Sucursaldestinonombre)) { _Sucursaldestinonombre = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _Apartadosnombres;
        [XmlAttribute]
        public string? Apartadosnombres { get => _Apartadosnombres; set { if (RaiseAcceptPendingChange(value, _Apartadosnombres)) { _Apartadosnombres = value; OnPropertyChanged(); } } }

        private string? _Apartadosapellidos;
        [XmlAttribute]
        public string? Apartadosapellidos { get => _Apartadosapellidos; set { if (RaiseAcceptPendingChange(value, _Apartadosapellidos)) { _Apartadosapellidos = value; OnPropertyChanged(); } } }

        private string? _Esfacturaelectronica;
        [XmlAttribute]
        public string? Esfacturaelectronica { get => _Esfacturaelectronica; set { if (RaiseAcceptPendingChange(value, _Esfacturaelectronica)) { _Esfacturaelectronica = value; OnPropertyChanged(); } } }

        private string? _Estatimbrado;
        [XmlAttribute]
        public string? Estatimbrado { get => _Estatimbrado; set { if (RaiseAcceptPendingChange(value, _Estatimbrado)) { _Estatimbrado = value; OnPropertyChanged(); } } }

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
    public class WFPagoCompuestoEditWF_PagosaplicadosBindingModel : Validatable
    {

        public WFPagoCompuestoEditWF_PagosaplicadosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private string? _Esfacturaelectronica;
        [XmlAttribute]
        public string? Esfacturaelectronica { get => _Esfacturaelectronica; set { if (RaiseAcceptPendingChange(value, _Esfacturaelectronica)) { _Esfacturaelectronica = value; OnPropertyChanged(); } } }

        private string? _Estatimbrado;
        [XmlAttribute]
        public string? Estatimbrado { get => _Estatimbrado; set { if (RaiseAcceptPendingChange(value, _Estatimbrado)) { _Estatimbrado = value; OnPropertyChanged(); } } }

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

