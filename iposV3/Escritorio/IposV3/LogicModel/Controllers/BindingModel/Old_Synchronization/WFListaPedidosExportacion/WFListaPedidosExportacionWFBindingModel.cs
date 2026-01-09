
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
    public class WFListaPedidosExportacionWFBindingModel : Validatable
    {

        public WFListaPedidosExportacionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbestatus;
        [XmlAttribute]
        public long? Cbestatus { get => _Cbestatus; set { if (RaiseAcceptPendingChange(value, _Cbestatus)) { _Cbestatus = value; OnPropertyChanged(); } } }

        private long? _Cbtipo;
        [XmlAttribute]
        public long? Cbtipo { get => _Cbtipo; set { if (RaiseAcceptPendingChange(value, _Cbtipo)) { _Cbtipo = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfechaelaboracion;
        [XmlAttribute]
        public BoolCN? Cbfechaelaboracion { get => _Cbfechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Cbfechaelaboracion)) { _Cbfechaelaboracion = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcorteactual;
        [XmlAttribute]
        public BoolCN? Cbcorteactual { get => _Cbcorteactual; set { if (RaiseAcceptPendingChange(value, _Cbcorteactual)) { _Cbcorteactual = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private string? _CbestatusClave;
        [XmlAttribute]
        public string? CbestatusClave { get => _CbestatusClave; set { if (RaiseAcceptPendingChange(value, _CbestatusClave)) { _CbestatusClave = value; OnPropertyChanged(); } } }

        private string? _CbestatusNombre;
        [XmlAttribute]
        public string? CbestatusNombre { get => _CbestatusNombre; set { if (RaiseAcceptPendingChange(value, _CbestatusNombre)) { _CbestatusNombre = value; OnPropertyChanged(); } } }

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
    public class WFListaPedidosExportacionWF_VentaslistaBindingModel : Validatable
    {

        public WFListaPedidosExportacionWF_VentaslistaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaini;
        [XmlAttribute]
        public DateTimeOffset? Fechaini { get => _Fechaini; set { if (RaiseAcceptPendingChange(value, _Fechaini)) { _Fechaini = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _Nombrecajero;
        [XmlAttribute]
        public string? Nombrecajero { get => _Nombrecajero; set { if (RaiseAcceptPendingChange(value, _Nombrecajero)) { _Nombrecajero = value; OnPropertyChanged(); } } }

        private string? _Estatuspedido;
        [XmlAttribute]
        public string? Estatuspedido { get => _Estatuspedido; set { if (RaiseAcceptPendingChange(value, _Estatuspedido)) { _Estatuspedido = value; OnPropertyChanged(); } } }

        private string? _Trasladoaftp;
        [XmlAttribute]
        public string? Trasladoaftp { get => _Trasladoaftp; set { if (RaiseAcceptPendingChange(value, _Trasladoaftp)) { _Trasladoaftp = value; OnPropertyChanged(); } } }

        private string? _Dgcontinuar;
        [XmlAttribute]
        public string? Dgcontinuar { get => _Dgcontinuar; set { if (RaiseAcceptPendingChange(value, _Dgcontinuar)) { _Dgcontinuar = value; OnPropertyChanged(); } } }

        private string? _Dgver;
        [XmlAttribute]
        public string? Dgver { get => _Dgver; set { if (RaiseAcceptPendingChange(value, _Dgver)) { _Dgver = value; OnPropertyChanged(); } } }

        private string? _Dgreenviar;
        [XmlAttribute]
        public string? Dgreenviar { get => _Dgreenviar; set { if (RaiseAcceptPendingChange(value, _Dgreenviar)) { _Dgreenviar = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private long? _Expfileid;
        [XmlAttribute]
        public long? Expfileid { get => _Expfileid; set { if (RaiseAcceptPendingChange(value, _Expfileid)) { _Expfileid = value; OnPropertyChanged(); } } }

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

