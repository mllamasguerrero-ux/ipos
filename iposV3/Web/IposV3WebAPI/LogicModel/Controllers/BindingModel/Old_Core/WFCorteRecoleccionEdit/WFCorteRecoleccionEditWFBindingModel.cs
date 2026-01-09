
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
    public class WFCorteRecoleccionEditWFBindingModel : Validatable
    {

        public WFCorteRecoleccionEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Encargadoclave;
        [XmlAttribute]
        public long? Encargadoclave { get => _Encargadoclave; set { if (RaiseAcceptPendingChange(value, _Encargadoclave)) { _Encargadoclave = value; OnPropertyChanged(); } } }

        private string? _EncargadoclaveClave;
        [XmlAttribute]
        public string? EncargadoclaveClave { get => _EncargadoclaveClave; set { if (RaiseAcceptPendingChange(value, _EncargadoclaveClave)) { _EncargadoclaveClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoclaveNombre;
        [XmlAttribute]
        public string? EncargadoclaveNombre { get => _EncargadoclaveNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoclaveNombre)) { _EncargadoclaveNombre = value; OnPropertyChanged(); } } }

        private string? _Tbnota;
        [XmlAttribute]
        public string? Tbnota { get => _Tbnota; set { if (RaiseAcceptPendingChange(value, _Tbnota)) { _Tbnota = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicio;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicio { get => _Dtpfechainicio; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicio)) { _Dtpfechainicio = value; OnPropertyChanged(); } } }

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
    public class WFCorteRecoleccionEditWF_CorterecolecciondetalleBindingModel : Validatable
    {

        public WFCorteRecoleccionEditWF_CorterecolecciondetalleBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private long? _Folio;
        [XmlAttribute]
        public long? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Cajero;
        [XmlAttribute]
        public string? Cajero { get => _Cajero; set { if (RaiseAcceptPendingChange(value, _Cajero)) { _Cajero = value; OnPropertyChanged(); } } }

        private int? _Num_tickets;
        [XmlAttribute]
        public int? Num_tickets { get => _Num_tickets; set { if (RaiseAcceptPendingChange(value, _Num_tickets)) { _Num_tickets = value; OnPropertyChanged(); } } }

        private int? _Num_devoluciones;
        [XmlAttribute]
        public int? Num_devoluciones { get => _Num_devoluciones; set { if (RaiseAcceptPendingChange(value, _Num_devoluciones)) { _Num_devoluciones = value; OnPropertyChanged(); } } }

        private decimal? _Saldoinicial;
        [XmlAttribute]
        public decimal? Saldoinicial { get => _Saldoinicial; set { if (RaiseAcceptPendingChange(value, _Saldoinicial)) { _Saldoinicial = value; OnPropertyChanged(); } } }

        private string? _Sucursal;
        [XmlAttribute]
        public string? Sucursal { get => _Sucursal; set { if (RaiseAcceptPendingChange(value, _Sucursal)) { _Sucursal = value; OnPropertyChanged(); } } }

        private string? _Caja;
        [XmlAttribute]
        public string? Caja { get => _Caja; set { if (RaiseAcceptPendingChange(value, _Caja)) { _Caja = value; OnPropertyChanged(); } } }

        private string? _Turno;
        [XmlAttribute]
        public string? Turno { get => _Turno; set { if (RaiseAcceptPendingChange(value, _Turno)) { _Turno = value; OnPropertyChanged(); } } }

        private decimal? _Ingreso;
        [XmlAttribute]
        public decimal? Ingreso { get => _Ingreso; set { if (RaiseAcceptPendingChange(value, _Ingreso)) { _Ingreso = value; OnPropertyChanged(); } } }

        private decimal? _Egreso;
        [XmlAttribute]
        public decimal? Egreso { get => _Egreso; set { if (RaiseAcceptPendingChange(value, _Egreso)) { _Egreso = value; OnPropertyChanged(); } } }

        private decimal? _Devolucion;
        [XmlAttribute]
        public decimal? Devolucion { get => _Devolucion; set { if (RaiseAcceptPendingChange(value, _Devolucion)) { _Devolucion = value; OnPropertyChanged(); } } }

        private decimal? _Aportacion;
        [XmlAttribute]
        public decimal? Aportacion { get => _Aportacion; set { if (RaiseAcceptPendingChange(value, _Aportacion)) { _Aportacion = value; OnPropertyChanged(); } } }

        private decimal? _Retiro;
        [XmlAttribute]
        public decimal? Retiro { get => _Retiro; set { if (RaiseAcceptPendingChange(value, _Retiro)) { _Retiro = value; OnPropertyChanged(); } } }

        private decimal? _Saldofinal;
        [XmlAttribute]
        public decimal? Saldofinal { get => _Saldofinal; set { if (RaiseAcceptPendingChange(value, _Saldofinal)) { _Saldofinal = value; OnPropertyChanged(); } } }

        private decimal? _Saldoreal;
        [XmlAttribute]
        public decimal? Saldoreal { get => _Saldoreal; set { if (RaiseAcceptPendingChange(value, _Saldoreal)) { _Saldoreal = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechacorte;
        [XmlAttribute]
        public DateTimeOffset? Fechacorte { get => _Fechacorte; set { if (RaiseAcceptPendingChange(value, _Fechacorte)) { _Fechacorte = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Inicia;
        [XmlAttribute]
        public DateTimeOffset? Inicia { get => _Inicia; set { if (RaiseAcceptPendingChange(value, _Inicia)) { _Inicia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Termina;
        [XmlAttribute]
        public DateTimeOffset? Termina { get => _Termina; set { if (RaiseAcceptPendingChange(value, _Termina)) { _Termina = value; OnPropertyChanged(); } } }

        private decimal? _Ingresoefectivo;
        [XmlAttribute]
        public decimal? Ingresoefectivo { get => _Ingresoefectivo; set { if (RaiseAcceptPendingChange(value, _Ingresoefectivo)) { _Ingresoefectivo = value; OnPropertyChanged(); } } }

        private decimal? _Ingresotarjeta;
        [XmlAttribute]
        public decimal? Ingresotarjeta { get => _Ingresotarjeta; set { if (RaiseAcceptPendingChange(value, _Ingresotarjeta)) { _Ingresotarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Ingresocredito;
        [XmlAttribute]
        public decimal? Ingresocredito { get => _Ingresocredito; set { if (RaiseAcceptPendingChange(value, _Ingresocredito)) { _Ingresocredito = value; OnPropertyChanged(); } } }

        private decimal? _Ingresocheque;
        [XmlAttribute]
        public decimal? Ingresocheque { get => _Ingresocheque; set { if (RaiseAcceptPendingChange(value, _Ingresocheque)) { _Ingresocheque = value; OnPropertyChanged(); } } }

        private decimal? _Ingresovale;
        [XmlAttribute]
        public decimal? Ingresovale { get => _Ingresovale; set { if (RaiseAcceptPendingChange(value, _Ingresovale)) { _Ingresovale = value; OnPropertyChanged(); } } }

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
    public class WFCorteRecoleccionEditWF_CorterecoleccionsumaBindingModel : Validatable
    {

        public WFCorteRecoleccionEditWF_CorterecoleccionsumaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Saldofinal;
        [XmlAttribute]
        public decimal? Saldofinal { get => _Saldofinal; set { if (RaiseAcceptPendingChange(value, _Saldofinal)) { _Saldofinal = value; OnPropertyChanged(); } } }

        private decimal? _Saldoreal;
        [XmlAttribute]
        public decimal? Saldoreal { get => _Saldoreal; set { if (RaiseAcceptPendingChange(value, _Saldoreal)) { _Saldoreal = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private decimal? _Ingresoefectivo;
        [XmlAttribute]
        public decimal? Ingresoefectivo { get => _Ingresoefectivo; set { if (RaiseAcceptPendingChange(value, _Ingresoefectivo)) { _Ingresoefectivo = value; OnPropertyChanged(); } } }

        private decimal? _Ingresotarjeta;
        [XmlAttribute]
        public decimal? Ingresotarjeta { get => _Ingresotarjeta; set { if (RaiseAcceptPendingChange(value, _Ingresotarjeta)) { _Ingresotarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Ingresocredito;
        [XmlAttribute]
        public decimal? Ingresocredito { get => _Ingresocredito; set { if (RaiseAcceptPendingChange(value, _Ingresocredito)) { _Ingresocredito = value; OnPropertyChanged(); } } }

        private decimal? _Ingresocheque;
        [XmlAttribute]
        public decimal? Ingresocheque { get => _Ingresocheque; set { if (RaiseAcceptPendingChange(value, _Ingresocheque)) { _Ingresocheque = value; OnPropertyChanged(); } } }

        private decimal? _Ingresovale;
        [XmlAttribute]
        public decimal? Ingresovale { get => _Ingresovale; set { if (RaiseAcceptPendingChange(value, _Ingresovale)) { _Ingresovale = value; OnPropertyChanged(); } } }

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

