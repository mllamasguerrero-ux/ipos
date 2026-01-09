
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
    public class WFExportarPedidosDetWFBindingModel : Validatable
    {

        public WFExportarPedidosDetWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Tbcajas;
        [XmlAttribute]
        public decimal? Tbcajas { get => _Tbcajas; set { if (RaiseAcceptPendingChange(value, _Tbcajas)) { _Tbcajas = value; OnPropertyChanged(); } } }

        private decimal? _Tbcantidad;
        [XmlAttribute]
        public decimal? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private string? _Tblocalidad;
        [XmlAttribute]
        public string? Tblocalidad { get => _Tblocalidad; set { if (RaiseAcceptPendingChange(value, _Tblocalidad)) { _Tblocalidad = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _Tbobservaciones;
        [XmlAttribute]
        public string? Tbobservaciones { get => _Tbobservaciones; set { if (RaiseAcceptPendingChange(value, _Tbobservaciones)) { _Tbobservaciones = value; OnPropertyChanged(); } } }

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
    public class WFExportarPedidosDetWF_Imp_rec_detBindingModel : Validatable
    {

        public WFExportarPedidosDetWF_Imp_rec_detBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private short? _Partida;
        [XmlAttribute]
        public short? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        private string? _Producto;
        [XmlAttribute]
        public string? Producto { get => _Producto; set { if (RaiseAcceptPendingChange(value, _Producto)) { _Producto = value; OnPropertyChanged(); } } }

        private string? _Anaquel_localidad;
        [XmlAttribute]
        public string? Anaquel_localidad { get => _Anaquel_localidad; set { if (RaiseAcceptPendingChange(value, _Anaquel_localidad)) { _Anaquel_localidad = value; OnPropertyChanged(); } } }

        private string? _Anaquel;
        [XmlAttribute]
        public string? Anaquel { get => _Anaquel; set { if (RaiseAcceptPendingChange(value, _Anaquel)) { _Anaquel = value; OnPropertyChanged(); } } }

        private string? _Localidadreal;
        [XmlAttribute]
        public string? Localidadreal { get => _Localidadreal; set { if (RaiseAcceptPendingChange(value, _Localidadreal)) { _Localidadreal = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadsurtida;
        [XmlAttribute]
        public decimal? Cantidadsurtida { get => _Cantidadsurtida; set { if (RaiseAcceptPendingChange(value, _Cantidadsurtida)) { _Cantidadsurtida = value; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute]
        public decimal? Cajas { get => _Cajas; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value; OnPropertyChanged(); } } }

        private decimal? _Piezas;
        [XmlAttribute]
        public decimal? Piezas { get => _Piezas; set { if (RaiseAcceptPendingChange(value, _Piezas)) { _Piezas = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfaltante;
        [XmlAttribute]
        public decimal? Cantidadfaltante { get => _Cantidadfaltante; set { if (RaiseAcceptPendingChange(value, _Cantidadfaltante)) { _Cantidadfaltante = value; OnPropertyChanged(); } } }

        private string? _Dgc_razondifinvid;
        [XmlAttribute]
        public string? Dgc_razondifinvid { get => _Dgc_razondifinvid; set { if (RaiseAcceptPendingChange(value, _Dgc_razondifinvid)) { _Dgc_razondifinvid = value; OnPropertyChanged(); } } }

        private string? _Dgc_razondifinvtext;
        [XmlAttribute]
        public string? Dgc_razondifinvtext { get => _Dgc_razondifinvtext; set { if (RaiseAcceptPendingChange(value, _Dgc_razondifinvtext)) { _Dgc_razondifinvtext = value; OnPropertyChanged(); } } }

        private decimal? _Existenciaremota;
        [XmlAttribute]
        public decimal? Existenciaremota { get => _Existenciaremota; set { if (RaiseAcceptPendingChange(value, _Existenciaremota)) { _Existenciaremota = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

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

