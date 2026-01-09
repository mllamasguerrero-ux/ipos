
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
    public class WFAbonosWFBindingModel : Validatable
    {

        public WFAbonosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbseriesat;
        [XmlAttribute]
        public string? Tbseriesat { get => _Tbseriesat; set { if (RaiseAcceptPendingChange(value, _Tbseriesat)) { _Tbseriesat = value; OnPropertyChanged(); } } }

        private string? _Tbfoliofactelectronica;
        [XmlAttribute]
        public string? Tbfoliofactelectronica { get => _Tbfoliofactelectronica; set { if (RaiseAcceptPendingChange(value, _Tbfoliofactelectronica)) { _Tbfoliofactelectronica = value; OnPropertyChanged(); } } }

        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcondonarpagocomision;
        [XmlAttribute]
        public BoolCN? Cbcondonarpagocomision { get => _Cbcondonarpagocomision; set { if (RaiseAcceptPendingChange(value, _Cbcondonarpagocomision)) { _Cbcondonarpagocomision = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaelaboracion { get => _Dtpfechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Dtpfechaelaboracion)) { _Dtpfechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecharecepcion { get => _Dtpfecharecepcion; set { if (RaiseAcceptPendingChange(value, _Dtpfecharecepcion)) { _Dtpfecharecepcion = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbaplicado;
        [XmlAttribute]
        public BoolCN? Cbaplicado { get => _Cbaplicado; set { if (RaiseAcceptPendingChange(value, _Cbaplicado)) { _Cbaplicado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaaplicado { get => _Dtpfechaaplicado; set { if (RaiseAcceptPendingChange(value, _Dtpfechaaplicado)) { _Dtpfechaaplicado = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private long? _Formapagocombobox;
        [XmlAttribute]
        public long? Formapagocombobox { get => _Formapagocombobox; set { if (RaiseAcceptPendingChange(value, _Formapagocombobox)) { _Formapagocombobox = value; OnPropertyChanged(); } } }

        private long? _Combobanco;
        [XmlAttribute]
        public long? Combobanco { get => _Combobanco; set { if (RaiseAcceptPendingChange(value, _Combobanco)) { _Combobanco = value; OnPropertyChanged(); } } }

        private long? _Cuentabancoempresaidcombobox;
        [XmlAttribute]
        public long? Cuentabancoempresaidcombobox { get => _Cuentabancoempresaidcombobox; set { if (RaiseAcceptPendingChange(value, _Cuentabancoempresaidcombobox)) { _Cuentabancoempresaidcombobox = value; OnPropertyChanged(); } } }

        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

        private string? _Tbcuentapago;
        [XmlAttribute]
        public string? Tbcuentapago { get => _Tbcuentapago; set { if (RaiseAcceptPendingChange(value, _Tbcuentapago)) { _Tbcuentapago = value; OnPropertyChanged(); } } }

        private string? _Tbrefinterno;
        [XmlAttribute]
        public string? Tbrefinterno { get => _Tbrefinterno; set { if (RaiseAcceptPendingChange(value, _Tbrefinterno)) { _Tbrefinterno = value; OnPropertyChanged(); } } }

        private string? _Tbnotas;
        [XmlAttribute]
        public string? Tbnotas { get => _Tbnotas; set { if (RaiseAcceptPendingChange(value, _Tbnotas)) { _Tbnotas = value; OnPropertyChanged(); } } }

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
    public class WFAbonosWF_Get_lista_abonos_doctoBindingModel : Validatable
    {

        public WFAbonosWF_Get_lista_abonos_doctoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Formadepago;
        [XmlAttribute]
        public string? Formadepago { get => _Formadepago; set { if (RaiseAcceptPendingChange(value, _Formadepago)) { _Formadepago = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private string? _Banco;
        [XmlAttribute]
        public string? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Refinterno;
        [XmlAttribute]
        public string? Refinterno { get => _Refinterno; set { if (RaiseAcceptPendingChange(value, _Refinterno)) { _Refinterno = value; OnPropertyChanged(); } } }

        private string? _Tipoabonodescripcion;
        [XmlAttribute]
        public string? Tipoabonodescripcion { get => _Tipoabonodescripcion; set { if (RaiseAcceptPendingChange(value, _Tipoabonodescripcion)) { _Tipoabonodescripcion = value; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private int? _Folioref;
        [XmlAttribute]
        public int? Folioref { get => _Folioref; set { if (RaiseAcceptPendingChange(value, _Folioref)) { _Folioref = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private decimal? _Comision;
        [XmlAttribute]
        public decimal? Comision { get => _Comision; set { if (RaiseAcceptPendingChange(value, _Comision)) { _Comision = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private long? _Tipoabonoid;
        [XmlAttribute]
        public long? Tipoabonoid { get => _Tipoabonoid; set { if (RaiseAcceptPendingChange(value, _Tipoabonoid)) { _Tipoabonoid = value; OnPropertyChanged(); } } }

        private string? _Revertido;
        [XmlAttribute]
        public string? Revertido { get => _Revertido; set { if (RaiseAcceptPendingChange(value, _Revertido)) { _Revertido = value; OnPropertyChanged(); } } }

        private long? _Reciboelectronicoid;
        [XmlAttribute]
        public long? Reciboelectronicoid { get => _Reciboelectronicoid; set { if (RaiseAcceptPendingChange(value, _Reciboelectronicoid)) { _Reciboelectronicoid = value; OnPropertyChanged(); } } }

        private string? _Esconpinpadbancomer;
        [XmlAttribute]
        public string? Esconpinpadbancomer { get => _Esconpinpadbancomer; set { if (RaiseAcceptPendingChange(value, _Esconpinpadbancomer)) { _Esconpinpadbancomer = value; OnPropertyChanged(); } } }

        private long? _Bancomerparamid;
        [XmlAttribute]
        public long? Bancomerparamid { get => _Bancomerparamid; set { if (RaiseAcceptPendingChange(value, _Bancomerparamid)) { _Bancomerparamid = value; OnPropertyChanged(); } } }

        private int? _Foliosatrecibo;
        [XmlAttribute]
        public int? Foliosatrecibo { get => _Foliosatrecibo; set { if (RaiseAcceptPendingChange(value, _Foliosatrecibo)) { _Foliosatrecibo = value; OnPropertyChanged(); } } }

        private string? _Foliosatserie;
        [XmlAttribute]
        public string? Foliosatserie { get => _Foliosatserie; set { if (RaiseAcceptPendingChange(value, _Foliosatserie)) { _Foliosatserie = value; OnPropertyChanged(); } } }

        private string? _Dgimprimirvoucher;
        [XmlAttribute]
        public string? Dgimprimirvoucher { get => _Dgimprimirvoucher; set { if (RaiseAcceptPendingChange(value, _Dgimprimirvoucher)) { _Dgimprimirvoucher = value; OnPropertyChanged(); } } }

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

