
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
    public class WFProcesarPagosVendedorMovilWFBindingModel : Validatable
    {

        public WFProcesarPagosVendedorMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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
    public class WFProcesarPagosVendedorMovilWF_PagosvendedormovilBindingModel : Validatable
    {

        public WFProcesarPagosVendedorMovilWF_PagosvendedormovilBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private string? _Personaclave;
        [XmlAttribute]
        public string? Personaclave { get => _Personaclave; set { if (RaiseAcceptPendingChange(value, _Personaclave)) { _Personaclave = value; OnPropertyChanged(); } } }

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private string? _Ventacobranza;
        [XmlAttribute]
        public string? Ventacobranza { get => _Ventacobranza; set { if (RaiseAcceptPendingChange(value, _Ventacobranza)) { _Ventacobranza = value; OnPropertyChanged(); } } }

        private decimal? _Saldoanterior;
        [XmlAttribute]
        public decimal? Saldoanterior { get => _Saldoanterior; set { if (RaiseAcceptPendingChange(value, _Saldoanterior)) { _Saldoanterior = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Saldonuevo;
        [XmlAttribute]
        public decimal? Saldonuevo { get => _Saldonuevo; set { if (RaiseAcceptPendingChange(value, _Saldonuevo)) { _Saldonuevo = value; OnPropertyChanged(); } } }

        private decimal? _Efectivo;
        [XmlAttribute]
        public decimal? Efectivo { get => _Efectivo; set { if (RaiseAcceptPendingChange(value, _Efectivo)) { _Efectivo = value; OnPropertyChanged(); } } }

        private decimal? _Cheque;
        [XmlAttribute]
        public decimal? Cheque { get => _Cheque; set { if (RaiseAcceptPendingChange(value, _Cheque)) { _Cheque = value; OnPropertyChanged(); } } }

        private decimal? _Deposito;
        [XmlAttribute]
        public decimal? Deposito { get => _Deposito; set { if (RaiseAcceptPendingChange(value, _Deposito)) { _Deposito = value; OnPropertyChanged(); } } }

        private decimal? _Transferencia;
        [XmlAttribute]
        public decimal? Transferencia { get => _Transferencia; set { if (RaiseAcceptPendingChange(value, _Transferencia)) { _Transferencia = value; OnPropertyChanged(); } } }

        private string? _Banconombre;
        [XmlAttribute]
        public string? Banconombre { get => _Banconombre; set { if (RaiseAcceptPendingChange(value, _Banconombre)) { _Banconombre = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Refinterno;
        [XmlAttribute]
        public string? Refinterno { get => _Refinterno; set { if (RaiseAcceptPendingChange(value, _Refinterno)) { _Refinterno = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Fechaelaboracion { get => _Fechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Fechaelaboracion)) { _Fechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Doctopagomovilid;
        [XmlAttribute]
        public long? Doctopagomovilid { get => _Doctopagomovilid; set { if (RaiseAcceptPendingChange(value, _Doctopagomovilid)) { _Doctopagomovilid = value; OnPropertyChanged(); } } }

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

