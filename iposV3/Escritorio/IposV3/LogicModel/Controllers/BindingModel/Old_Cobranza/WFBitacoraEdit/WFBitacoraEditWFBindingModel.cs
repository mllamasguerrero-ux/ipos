
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
    public class WFBitacoraEditWFBindingModel : Validatable
    {

        public WFBitacoraEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cobradorid;
        [XmlAttribute]
        public long? Cobradorid { get => _Cobradorid; set { if (RaiseAcceptPendingChange(value, _Cobradorid)) { _Cobradorid = value; OnPropertyChanged(); } } }

        private string? _CobradoridClave;
        [XmlAttribute]
        public string? CobradoridClave { get => _CobradoridClave; set { if (RaiseAcceptPendingChange(value, _CobradoridClave)) { _CobradoridClave = value; OnPropertyChanged(); } } }

        private string? _CobradoridNombre;
        [XmlAttribute]
        public string? CobradoridNombre { get => _CobradoridNombre; set { if (RaiseAcceptPendingChange(value, _CobradoridNombre)) { _CobradoridNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private long? _Estado;
        [XmlAttribute]
        public long? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private string? _EstadoClave;
        [XmlAttribute]
        public string? EstadoClave { get => _EstadoClave; set { if (RaiseAcceptPendingChange(value, _EstadoClave)) { _EstadoClave = value; OnPropertyChanged(); } } }

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
    public class WFBitacoraEditWF_BitacobranzadetBindingModel : Validatable
    {

        public WFBitacoraEditWF_BitacobranzadetBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private int? _Estadocobranzabool;
        [XmlAttribute]
        public int? Estadocobranzabool { get => _Estadocobranzabool; set { if (RaiseAcceptPendingChange(value, _Estadocobranzabool)) { _Estadocobranzabool = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private decimal? _Doctoabono;
        [XmlAttribute]
        public decimal? Doctoabono { get => _Doctoabono; set { if (RaiseAcceptPendingChange(value, _Doctoabono)) { _Doctoabono = value; OnPropertyChanged(); } } }

        private string? _Clientenombre;
        [XmlAttribute]
        public string? Clientenombre { get => _Clientenombre; set { if (RaiseAcceptPendingChange(value, _Clientenombre)) { _Clientenombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private string? _Estadonombre;
        [XmlAttribute]
        public string? Estadonombre { get => _Estadonombre; set { if (RaiseAcceptPendingChange(value, _Estadonombre)) { _Estadonombre = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private string? _Observaciones;
        [XmlAttribute]
        public string? Observaciones { get => _Observaciones; set { if (RaiseAcceptPendingChange(value, _Observaciones)) { _Observaciones = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Nuevafechacobro;
        [XmlAttribute]
        public DateTimeOffset? Nuevafechacobro { get => _Nuevafechacobro; set { if (RaiseAcceptPendingChange(value, _Nuevafechacobro)) { _Nuevafechacobro = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Clientenombres;
        [XmlAttribute]
        public string? Clientenombres { get => _Clientenombres; set { if (RaiseAcceptPendingChange(value, _Clientenombres)) { _Clientenombres = value; OnPropertyChanged(); } } }

        private string? _Clienteapellidos;
        [XmlAttribute]
        public string? Clienteapellidos { get => _Clienteapellidos; set { if (RaiseAcceptPendingChange(value, _Clienteapellidos)) { _Clienteapellidos = value; OnPropertyChanged(); } } }

        private long? _Estado;
        [XmlAttribute]
        public long? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private long? _Bitacobranzadetid;
        [XmlAttribute]
        public long? Bitacobranzadetid { get => _Bitacobranzadetid; set { if (RaiseAcceptPendingChange(value, _Bitacobranzadetid)) { _Bitacobranzadetid = value; OnPropertyChanged(); } } }

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

