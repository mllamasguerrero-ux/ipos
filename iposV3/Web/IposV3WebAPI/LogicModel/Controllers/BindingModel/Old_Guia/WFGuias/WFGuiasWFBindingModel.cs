
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
    public class WFGuiasWFBindingModel : Validatable
    {

        public WFGuiasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbtipo;
        [XmlAttribute]
        public long? Cbtipo { get => _Cbtipo; set { if (RaiseAcceptPendingChange(value, _Cbtipo)) { _Cbtipo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafin;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafin { get => _Dtpfechafin; set { if (RaiseAcceptPendingChange(value, _Dtpfechafin)) { _Dtpfechafin = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaini;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaini { get => _Dtpfechaini; set { if (RaiseAcceptPendingChange(value, _Dtpfechaini)) { _Dtpfechaini = value; OnPropertyChanged(); } } }

        private string? _Guiapaqueteria;
        [XmlAttribute]
        public string? Guiapaqueteria { get => _Guiapaqueteria; set { if (RaiseAcceptPendingChange(value, _Guiapaqueteria)) { _Guiapaqueteria = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodasguias;
        [XmlAttribute]
        public BoolCN? Cbtodasguias { get => _Cbtodasguias; set { if (RaiseAcceptPendingChange(value, _Cbtodasguias)) { _Cbtodasguias = value; OnPropertyChanged(); } } }

        private int? _Tbid;
        [XmlAttribute]
        public int? Tbid { get => _Tbid; set { if (RaiseAcceptPendingChange(value, _Tbid)) { _Tbid = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbidtodos;
        [XmlAttribute]
        public BoolCN? Cbidtodos { get => _Cbidtodos; set { if (RaiseAcceptPendingChange(value, _Cbidtodos)) { _Cbidtodos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolopendientes;
        [XmlAttribute]
        public BoolCN? Cbsolopendientes { get => _Cbsolopendientes; set { if (RaiseAcceptPendingChange(value, _Cbsolopendientes)) { _Cbsolopendientes = value; OnPropertyChanged(); } } }

        private long? _Encargadoid;
        [XmlAttribute]
        public long? Encargadoid { get => _Encargadoid; set { if (RaiseAcceptPendingChange(value, _Encargadoid)) { _Encargadoid = value; OnPropertyChanged(); } } }

        private string? _EncargadoidClave;
        [XmlAttribute]
        public string? EncargadoidClave { get => _EncargadoidClave; set { if (RaiseAcceptPendingChange(value, _EncargadoidClave)) { _EncargadoidClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoidNombre;
        [XmlAttribute]
        public string? EncargadoidNombre { get => _EncargadoidNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoidNombre)) { _EncargadoidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbencargadostodos;
        [XmlAttribute]
        public BoolCN? Cbencargadostodos { get => _Cbencargadostodos; set { if (RaiseAcceptPendingChange(value, _Cbencargadostodos)) { _Cbencargadostodos = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private string? _CbtipoClave;
        [XmlAttribute]
        public string? CbtipoClave { get => _CbtipoClave; set { if (RaiseAcceptPendingChange(value, _CbtipoClave)) { _CbtipoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipoNombre;
        [XmlAttribute]
        public string? CbtipoNombre { get => _CbtipoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipoNombre)) { _CbtipoNombre = value; OnPropertyChanged(); } } }

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
    public class WFGuiasWF_GuiaBindingModel : Validatable
    {

        public WFGuiasWF_GuiaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private long? _Encargadoguiaid;
        [XmlAttribute]
        public long? Encargadoguiaid { get => _Encargadoguiaid; set { if (RaiseAcceptPendingChange(value, _Encargadoguiaid)) { _Encargadoguiaid = value; OnPropertyChanged(); } } }

        private string? _Encargadoguia;
        [XmlAttribute]
        public string? Encargadoguia { get => _Encargadoguia; set { if (RaiseAcceptPendingChange(value, _Encargadoguia)) { _Encargadoguia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Cajero;
        [XmlAttribute]
        public string? Cajero { get => _Cajero; set { if (RaiseAcceptPendingChange(value, _Cajero)) { _Cajero = value; OnPropertyChanged(); } } }

        private long? _Cajeroid;
        [XmlAttribute]
        public long? Cajeroid { get => _Cajeroid; set { if (RaiseAcceptPendingChange(value, _Cajeroid)) { _Cajeroid = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private string? _Nota;
        [XmlAttribute]
        public string? Nota { get => _Nota; set { if (RaiseAcceptPendingChange(value, _Nota)) { _Nota = value; OnPropertyChanged(); } } }

        private long? _Estadoguiaid;
        [XmlAttribute]
        public long? Estadoguiaid { get => _Estadoguiaid; set { if (RaiseAcceptPendingChange(value, _Estadoguiaid)) { _Estadoguiaid = value; OnPropertyChanged(); } } }

        private string? _Estadoguia;
        [XmlAttribute]
        public string? Estadoguia { get => _Estadoguia; set { if (RaiseAcceptPendingChange(value, _Estadoguia)) { _Estadoguia = value; OnPropertyChanged(); } } }

        private string? _Tipoentreganombre;
        [XmlAttribute]
        public string? Tipoentreganombre { get => _Tipoentreganombre; set { if (RaiseAcceptPendingChange(value, _Tipoentreganombre)) { _Tipoentreganombre = value; OnPropertyChanged(); } } }

        private string? _Guiapaqueteria;
        [XmlAttribute]
        public string? Guiapaqueteria { get => _Guiapaqueteria; set { if (RaiseAcceptPendingChange(value, _Guiapaqueteria)) { _Guiapaqueteria = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private string? _Dgcancelar;
        [XmlAttribute]
        public string? Dgcancelar { get => _Dgcancelar; set { if (RaiseAcceptPendingChange(value, _Dgcancelar)) { _Dgcancelar = value; OnPropertyChanged(); } } }

        private string? _Dgrecibir;
        [XmlAttribute]
        public string? Dgrecibir { get => _Dgrecibir; set { if (RaiseAcceptPendingChange(value, _Dgrecibir)) { _Dgrecibir = value; OnPropertyChanged(); } } }

        private string? _Dgcartacorte;
        [XmlAttribute]
        public string? Dgcartacorte { get => _Dgcartacorte; set { if (RaiseAcceptPendingChange(value, _Dgcartacorte)) { _Dgcartacorte = value; OnPropertyChanged(); } } }

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

