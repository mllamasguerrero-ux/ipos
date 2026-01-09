
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
    public class WFContraRecibosWFBindingModel : Validatable
    {

        public WFContraRecibosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private long? _Estatuspagoid;
        [XmlAttribute]
        public long? Estatuspagoid { get => _Estatuspagoid; set { if (RaiseAcceptPendingChange(value, _Estatuspagoid)) { _Estatuspagoid = value; OnPropertyChanged(); } } }

        private string? _Tbnota;
        [XmlAttribute]
        public string? Tbnota { get => _Tbnota; set { if (RaiseAcceptPendingChange(value, _Tbnota)) { _Tbnota = value; OnPropertyChanged(); } } }

        private string? _EstatuspagoidClave;
        [XmlAttribute]
        public string? EstatuspagoidClave { get => _EstatuspagoidClave; set { if (RaiseAcceptPendingChange(value, _EstatuspagoidClave)) { _EstatuspagoidClave = value; OnPropertyChanged(); } } }

        private string? _EstatuspagoidNombre;
        [XmlAttribute]
        public string? EstatuspagoidNombre { get => _EstatuspagoidNombre; set { if (RaiseAcceptPendingChange(value, _EstatuspagoidNombre)) { _EstatuspagoidNombre = value; OnPropertyChanged(); } } }

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
    public class WFContraRecibosWF_ContrarecibodtlBindingModel : Validatable
    {

        public WFContraRecibosWF_ContrarecibodtlBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private long? _Modificadopor_userid;
        [XmlAttribute]
        public long? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private long? _Contrareciboid;
        [XmlAttribute]
        public long? Contrareciboid { get => _Contrareciboid; set { if (RaiseAcceptPendingChange(value, _Contrareciboid)) { _Contrareciboid = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private long? _Estatusid;
        [XmlAttribute]
        public long? Estatusid { get => _Estatusid; set { if (RaiseAcceptPendingChange(value, _Estatusid)) { _Estatusid = value; OnPropertyChanged(); } } }

        private decimal? _Totaldocto;
        [XmlAttribute]
        public decimal? Totaldocto { get => _Totaldocto; set { if (RaiseAcceptPendingChange(value, _Totaldocto)) { _Totaldocto = value; OnPropertyChanged(); } } }

        private decimal? _Abonodocto;
        [XmlAttribute]
        public decimal? Abonodocto { get => _Abonodocto; set { if (RaiseAcceptPendingChange(value, _Abonodocto)) { _Abonodocto = value; OnPropertyChanged(); } } }

        private decimal? _Saldodocto;
        [XmlAttribute]
        public decimal? Saldodocto { get => _Saldodocto; set { if (RaiseAcceptPendingChange(value, _Saldodocto)) { _Saldodocto = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

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

