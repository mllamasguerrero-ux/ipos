
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
    public class WFSolicitudMercanciaListWFBindingModel : Validatable
    {

        public WFSolicitudMercanciaListWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbsolopendientes;
        [XmlAttribute]
        public BoolCN? Cbsolopendientes { get => _Cbsolopendientes; set { if (RaiseAcceptPendingChange(value, _Cbsolopendientes)) { _Cbsolopendientes = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicio;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicio { get => _Dtpfechainicio; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicio)) { _Dtpfechainicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafin;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafin { get => _Dtpfechafin; set { if (RaiseAcceptPendingChange(value, _Dtpfechafin)) { _Dtpfechafin = value; OnPropertyChanged(); } } }

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
    public class WFSolicitudMercanciaListWF_SolicitudmercaenviadaBindingModel : Validatable
    {

        public WFSolicitudMercanciaListWF_SolicitudmercaenviadaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgbtnver;
        [XmlAttribute]
        public string? Dgbtnver { get => _Dgbtnver; set { if (RaiseAcceptPendingChange(value, _Dgbtnver)) { _Dgbtnver = value; OnPropertyChanged(); } } }

        private string? _Dgbtneliminar;
        [XmlAttribute]
        public string? Dgbtneliminar { get => _Dgbtneliminar; set { if (RaiseAcceptPendingChange(value, _Dgbtneliminar)) { _Dgbtneliminar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Estatuspedido;
        [XmlAttribute]
        public string? Estatuspedido { get => _Estatuspedido; set { if (RaiseAcceptPendingChange(value, _Estatuspedido)) { _Estatuspedido = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _Nombrecajero;
        [XmlAttribute]
        public string? Nombrecajero { get => _Nombrecajero; set { if (RaiseAcceptPendingChange(value, _Nombrecajero)) { _Nombrecajero = value; OnPropertyChanged(); } } }

        private long? _Subtipodoctoid;
        [XmlAttribute]
        public long? Subtipodoctoid { get => _Subtipodoctoid; set { if (RaiseAcceptPendingChange(value, _Subtipodoctoid)) { _Subtipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Trasladoaftp;
        [XmlAttribute]
        public string? Trasladoaftp { get => _Trasladoaftp; set { if (RaiseAcceptPendingChange(value, _Trasladoaftp)) { _Trasladoaftp = value; OnPropertyChanged(); } } }

        private long? _Expfileid;
        [XmlAttribute]
        public long? Expfileid { get => _Expfileid; set { if (RaiseAcceptPendingChange(value, _Expfileid)) { _Expfileid = value; OnPropertyChanged(); } } }

        private string? _Estatus;
        [XmlAttribute]
        public string? Estatus { get => _Estatus; set { if (RaiseAcceptPendingChange(value, _Estatus)) { _Estatus = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaini;
        [XmlAttribute]
        public DateTimeOffset? Fechaini { get => _Fechaini; set { if (RaiseAcceptPendingChange(value, _Fechaini)) { _Fechaini = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

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

