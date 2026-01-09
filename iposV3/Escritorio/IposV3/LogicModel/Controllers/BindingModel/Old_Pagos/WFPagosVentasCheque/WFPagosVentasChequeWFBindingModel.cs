
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
    public class WFPagosVentasChequeWFBindingModel : Validatable
    {

        public WFPagosVentasChequeWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

        private long? _Combobanco;
        [XmlAttribute]
        public long? Combobanco { get => _Combobanco; set { if (RaiseAcceptPendingChange(value, _Combobanco)) { _Combobanco = value; OnPropertyChanged(); } } }

        private BoolCN? _Banco;
        [XmlAttribute]
        public BoolCN? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfechacheque;
        [XmlAttribute]
        public BoolCN? Cbfechacheque { get => _Cbfechacheque; set { if (RaiseAcceptPendingChange(value, _Cbfechacheque)) { _Cbfechacheque = value; OnPropertyChanged(); } } }

        private long? _Aplicadoscombobox;
        [XmlAttribute]
        public long? Aplicadoscombobox { get => _Aplicadoscombobox; set { if (RaiseAcceptPendingChange(value, _Aplicadoscombobox)) { _Aplicadoscombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbincluircancelaciones;
        [XmlAttribute]
        public BoolCN? Cbincluircancelaciones { get => _Cbincluircancelaciones; set { if (RaiseAcceptPendingChange(value, _Cbincluircancelaciones)) { _Cbincluircancelaciones = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfechaaplicacion;
        [XmlAttribute]
        public BoolCN? Cbfechaaplicacion { get => _Cbfechaaplicacion; set { if (RaiseAcceptPendingChange(value, _Cbfechaaplicacion)) { _Cbfechaaplicacion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private string? _CombobancoClave;
        [XmlAttribute]
        public string? CombobancoClave { get => _CombobancoClave; set { if (RaiseAcceptPendingChange(value, _CombobancoClave)) { _CombobancoClave = value; OnPropertyChanged(); } } }

        private string? _CombobancoNombre;
        [XmlAttribute]
        public string? CombobancoNombre { get => _CombobancoNombre; set { if (RaiseAcceptPendingChange(value, _CombobancoNombre)) { _CombobancoNombre = value; OnPropertyChanged(); } } }

        private string? _AplicadoscomboboxClave;
        [XmlAttribute]
        public string? AplicadoscomboboxClave { get => _AplicadoscomboboxClave; set { if (RaiseAcceptPendingChange(value, _AplicadoscomboboxClave)) { _AplicadoscomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AplicadoscomboboxNombre;
        [XmlAttribute]
        public string? AplicadoscomboboxNombre { get => _AplicadoscomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AplicadoscomboboxNombre)) { _AplicadoscomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFPagosVentasChequeWF_PagolistchequeBindingModel : Validatable
    {

        public WFPagosVentasChequeWF_PagolistchequeBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tipopagonombre;
        [XmlAttribute]
        public string? Tipopagonombre { get => _Tipopagonombre; set { if (RaiseAcceptPendingChange(value, _Tipopagonombre)) { _Tipopagonombre = value; OnPropertyChanged(); } } }

        private string? _Dgseleccionar;
        [XmlAttribute]
        public string? Dgseleccionar { get => _Dgseleccionar; set { if (RaiseAcceptPendingChange(value, _Dgseleccionar)) { _Dgseleccionar = value; OnPropertyChanged(); } } }

        private string? _Dgcambiarfechaaplicacion;
        [XmlAttribute]
        public string? Dgcambiarfechaaplicacion { get => _Dgcambiarfechaaplicacion; set { if (RaiseAcceptPendingChange(value, _Dgcambiarfechaaplicacion)) { _Dgcambiarfechaaplicacion = value; OnPropertyChanged(); } } }

        private string? _Dgver;
        [XmlAttribute]
        public string? Dgver { get => _Dgver; set { if (RaiseAcceptPendingChange(value, _Dgver)) { _Dgver = value; OnPropertyChanged(); } } }

        private string? _Id;
        [XmlAttribute]
        public string? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Dgdesaplicar;
        [XmlAttribute]
        public string? Dgdesaplicar { get => _Dgdesaplicar; set { if (RaiseAcceptPendingChange(value, _Dgdesaplicar)) { _Dgdesaplicar = value; OnPropertyChanged(); } } }

        private string? _Dgdevolver;
        [XmlAttribute]
        public string? Dgdevolver { get => _Dgdevolver; set { if (RaiseAcceptPendingChange(value, _Dgdevolver)) { _Dgdevolver = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Personaclave;
        [XmlAttribute]
        public string? Personaclave { get => _Personaclave; set { if (RaiseAcceptPendingChange(value, _Personaclave)) { _Personaclave = value; OnPropertyChanged(); } } }

        private string? _Personanombre;
        [XmlAttribute]
        public string? Personanombre { get => _Personanombre; set { if (RaiseAcceptPendingChange(value, _Personanombre)) { _Personanombre = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private string? _Aplicado;
        [XmlAttribute]
        public string? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private string? _Devuelto;
        [XmlAttribute]
        public string? Devuelto { get => _Devuelto; set { if (RaiseAcceptPendingChange(value, _Devuelto)) { _Devuelto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Fechaaplicado { get => _Fechaaplicado; set { if (RaiseAcceptPendingChange(value, _Fechaaplicado)) { _Fechaaplicado = value; OnPropertyChanged(); } } }

        private long? _Banco;
        [XmlAttribute]
        public long? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private string? _Banconombre;
        [XmlAttribute]
        public string? Banconombre { get => _Banconombre; set { if (RaiseAcceptPendingChange(value, _Banconombre)) { _Banconombre = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Timbrado;
        [XmlAttribute]
        public string? Timbrado { get => _Timbrado; set { if (RaiseAcceptPendingChange(value, _Timbrado)) { _Timbrado = value; OnPropertyChanged(); } } }

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

