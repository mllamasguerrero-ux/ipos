
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
    public class WFBitacoraAddMovilWFBindingModel : Validatable
    {

        public WFBitacoraAddMovilWFBindingModel()
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

        private BoolCN? _Cbsolovencidos;
        [XmlAttribute]
        public BoolCN? Cbsolovencidos { get => _Cbsolovencidos; set { if (RaiseAcceptPendingChange(value, _Cbsolovencidos)) { _Cbsolovencidos = value; OnPropertyChanged(); } } }

        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Lunes;
        [XmlAttribute]
        public BoolCN? Lunes { get => _Lunes; set { if (RaiseAcceptPendingChange(value, _Lunes)) { _Lunes = value; OnPropertyChanged(); } } }

        private BoolCN? _Martes;
        [XmlAttribute]
        public BoolCN? Martes { get => _Martes; set { if (RaiseAcceptPendingChange(value, _Martes)) { _Martes = value; OnPropertyChanged(); } } }

        private BoolCN? _Miercoles;
        [XmlAttribute]
        public BoolCN? Miercoles { get => _Miercoles; set { if (RaiseAcceptPendingChange(value, _Miercoles)) { _Miercoles = value; OnPropertyChanged(); } } }

        private BoolCN? _Jueves;
        [XmlAttribute]
        public BoolCN? Jueves { get => _Jueves; set { if (RaiseAcceptPendingChange(value, _Jueves)) { _Jueves = value; OnPropertyChanged(); } } }

        private BoolCN? _Viernes;
        [XmlAttribute]
        public BoolCN? Viernes { get => _Viernes; set { if (RaiseAcceptPendingChange(value, _Viernes)) { _Viernes = value; OnPropertyChanged(); } } }

        private BoolCN? _Sabado;
        [XmlAttribute]
        public BoolCN? Sabado { get => _Sabado; set { if (RaiseAcceptPendingChange(value, _Sabado)) { _Sabado = value; OnPropertyChanged(); } } }

        private BoolCN? _Domingo;
        [XmlAttribute]
        public BoolCN? Domingo { get => _Domingo; set { if (RaiseAcceptPendingChange(value, _Domingo)) { _Domingo = value; OnPropertyChanged(); } } }

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
    public class WFBitacoraAddMovilWF_BitacobranzadetBindingModel : Validatable
    {

        public WFBitacoraAddMovilWF_BitacobranzadetBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

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

