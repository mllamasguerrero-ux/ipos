
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
    public class WFReciboDepositoListWFBindingModel : Validatable
    {

        public WFReciboDepositoListWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcorteactual;
        [XmlAttribute]
        public BoolCN? Cbcorteactual { get => _Cbcorteactual; set { if (RaiseAcceptPendingChange(value, _Cbcorteactual)) { _Cbcorteactual = value; OnPropertyChanged(); } } }

        private long? _Comboestado;
        [XmlAttribute]
        public long? Comboestado { get => _Comboestado; set { if (RaiseAcceptPendingChange(value, _Comboestado)) { _Comboestado = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private string? _ComboestadoClave;
        [XmlAttribute]
        public string? ComboestadoClave { get => _ComboestadoClave; set { if (RaiseAcceptPendingChange(value, _ComboestadoClave)) { _ComboestadoClave = value; OnPropertyChanged(); } } }

        private string? _ComboestadoNombre;
        [XmlAttribute]
        public string? ComboestadoNombre { get => _ComboestadoNombre; set { if (RaiseAcceptPendingChange(value, _ComboestadoNombre)) { _ComboestadoNombre = value; OnPropertyChanged(); } } }

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
    public class WFReciboDepositoListWF_GastosBindingModel : Validatable
    {

        public WFReciboDepositoListWF_GastosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Cajeroid;
        [XmlAttribute]
        public long? Cajeroid { get => _Cajeroid; set { if (RaiseAcceptPendingChange(value, _Cajeroid)) { _Cajeroid = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Nombreestatusdocto;
        [XmlAttribute]
        public string? Nombreestatusdocto { get => _Nombreestatusdocto; set { if (RaiseAcceptPendingChange(value, _Nombreestatusdocto)) { _Nombreestatusdocto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Cajeronombre;
        [XmlAttribute]
        public string? Cajeronombre { get => _Cajeronombre; set { if (RaiseAcceptPendingChange(value, _Cajeronombre)) { _Cajeronombre = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private long? _Montobilletesid;
        [XmlAttribute]
        public long? Montobilletesid { get => _Montobilletesid; set { if (RaiseAcceptPendingChange(value, _Montobilletesid)) { _Montobilletesid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechacorte;
        [XmlAttribute]
        public DateTimeOffset? Fechacorte { get => _Fechacorte; set { if (RaiseAcceptPendingChange(value, _Fechacorte)) { _Fechacorte = value; OnPropertyChanged(); } } }

        private string? _Dgver;
        [XmlAttribute]
        public string? Dgver { get => _Dgver; set { if (RaiseAcceptPendingChange(value, _Dgver)) { _Dgver = value; OnPropertyChanged(); } } }

        private string? _Dgcancelar;
        [XmlAttribute]
        public string? Dgcancelar { get => _Dgcancelar; set { if (RaiseAcceptPendingChange(value, _Dgcancelar)) { _Dgcancelar = value; OnPropertyChanged(); } } }

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

