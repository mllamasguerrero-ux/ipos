
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
    public class WFFactOrigCompraLstWFBindingModel : Validatable
    {

        public WFFactOrigCompraLstWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbincluirprovisionadas;
        [XmlAttribute]
        public BoolCN? Cbincluirprovisionadas { get => _Cbincluirprovisionadas; set { if (RaiseAcceptPendingChange(value, _Cbincluirprovisionadas)) { _Cbincluirprovisionadas = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _SucursalidClave;
        [XmlAttribute]
        public string? SucursalidClave { get => _SucursalidClave; set { if (RaiseAcceptPendingChange(value, _SucursalidClave)) { _SucursalidClave = value; OnPropertyChanged(); } } }

        private string? _SucursalidNombre;
        [XmlAttribute]
        public string? SucursalidNombre { get => _SucursalidNombre; set { if (RaiseAcceptPendingChange(value, _SucursalidNombre)) { _SucursalidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfechafactura;
        [XmlAttribute]
        public BoolCN? Cbfechafactura { get => _Cbfechafactura; set { if (RaiseAcceptPendingChange(value, _Cbfechafactura)) { _Cbfechafactura = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfecharecepcion;
        [XmlAttribute]
        public BoolCN? Cbfecharecepcion { get => _Cbfecharecepcion; set { if (RaiseAcceptPendingChange(value, _Cbfecharecepcion)) { _Cbfecharecepcion = value; OnPropertyChanged(); } } }

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
    public class WFFactOrigCompraLstWF_FactorigcompraBindingModel : Validatable
    {

        public WFFactOrigCompraLstWF_FactorigcompraBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Sucursalnombre;
        [XmlAttribute]
        public string? Sucursalnombre { get => _Sucursalnombre; set { if (RaiseAcceptPendingChange(value, _Sucursalnombre)) { _Sucursalnombre = value; OnPropertyChanged(); } } }

        private string? _Factura;
        [XmlAttribute]
        public string? Factura { get => _Factura; set { if (RaiseAcceptPendingChange(value, _Factura)) { _Factura = value; OnPropertyChanged(); } } }

        private int? _Comprafolio;
        [XmlAttribute]
        public int? Comprafolio { get => _Comprafolio; set { if (RaiseAcceptPendingChange(value, _Comprafolio)) { _Comprafolio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafactura;
        [XmlAttribute]
        public DateTimeOffset? Fechafactura { get => _Fechafactura; set { if (RaiseAcceptPendingChange(value, _Fechafactura)) { _Fechafactura = value; OnPropertyChanged(); } } }

        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _Proveedornombre;
        [XmlAttribute]
        public string? Proveedornombre { get => _Proveedornombre; set { if (RaiseAcceptPendingChange(value, _Proveedornombre)) { _Proveedornombre = value; OnPropertyChanged(); } } }

        private decimal? _Suma;
        [XmlAttribute]
        public decimal? Suma { get => _Suma; set { if (RaiseAcceptPendingChange(value, _Suma)) { _Suma = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Ieps8;
        [XmlAttribute]
        public decimal? Ieps8 { get => _Ieps8; set { if (RaiseAcceptPendingChange(value, _Ieps8)) { _Ieps8 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps26;
        [XmlAttribute]
        public decimal? Ieps26 { get => _Ieps26; set { if (RaiseAcceptPendingChange(value, _Ieps26)) { _Ieps26 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps26c;
        [XmlAttribute]
        public decimal? Ieps26c { get => _Ieps26c; set { if (RaiseAcceptPendingChange(value, _Ieps26c)) { _Ieps26c = value; OnPropertyChanged(); } } }

        private decimal? _Ieps30;
        [XmlAttribute]
        public decimal? Ieps30 { get => _Ieps30; set { if (RaiseAcceptPendingChange(value, _Ieps30)) { _Ieps30 = value; OnPropertyChanged(); } } }

        private decimal? _Ieps53;
        [XmlAttribute]
        public decimal? Ieps53 { get => _Ieps53; set { if (RaiseAcceptPendingChange(value, _Ieps53)) { _Ieps53 = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Provisionada;
        [XmlAttribute]
        public string? Provisionada { get => _Provisionada; set { if (RaiseAcceptPendingChange(value, _Provisionada)) { _Provisionada = value; OnPropertyChanged(); } } }

        private string? _Colver;
        [XmlAttribute]
        public string? Colver { get => _Colver; set { if (RaiseAcceptPendingChange(value, _Colver)) { _Colver = value; OnPropertyChanged(); } } }

        private string? _Coleditar;
        [XmlAttribute]
        public string? Coleditar { get => _Coleditar; set { if (RaiseAcceptPendingChange(value, _Coleditar)) { _Coleditar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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

