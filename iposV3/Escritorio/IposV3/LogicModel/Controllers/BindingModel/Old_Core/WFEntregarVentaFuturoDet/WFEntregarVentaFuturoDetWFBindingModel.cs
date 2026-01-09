
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
    public class WFEntregarVentaFuturoDetWFBindingModel : Validatable
    {

        public WFEntregarVentaFuturoDetWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private int? _Tbcantidad;
        [XmlAttribute]
        public int? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private string? _Totalventafut;
        [XmlAttribute]
        public string? Totalventafut { get => _Totalventafut; set { if (RaiseAcceptPendingChange(value, _Totalventafut)) { _Totalventafut = value; OnPropertyChanged(); } } }

        private string? _Aplicado;
        [XmlAttribute]
        public string? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private string? _Tbobservaciones;
        [XmlAttribute]
        public string? Tbobservaciones { get => _Tbobservaciones; set { if (RaiseAcceptPendingChange(value, _Tbobservaciones)) { _Tbobservaciones = value; OnPropertyChanged(); } } }

        private string? _Poraplicar;
        [XmlAttribute]
        public string? Poraplicar { get => _Poraplicar; set { if (RaiseAcceptPendingChange(value, _Poraplicar)) { _Poraplicar = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmantenerabierta;
        [XmlAttribute]
        public BoolCN? Cbmantenerabierta { get => _Cbmantenerabierta; set { if (RaiseAcceptPendingChange(value, _Cbmantenerabierta)) { _Cbmantenerabierta = value; OnPropertyChanged(); } } }

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
    public class WFEntregarVentaFuturoDetWF_Imp_rec_detBindingModel : Validatable
    {

        public WFEntregarVentaFuturoDetWF_Imp_rec_detBindingModel()
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

        private short? _Partida;
        [XmlAttribute]
        public short? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        private string? _Producto;
        [XmlAttribute]
        public string? Producto { get => _Producto; set { if (RaiseAcceptPendingChange(value, _Producto)) { _Producto = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Recibidas;
        [XmlAttribute]
        public decimal? Recibidas { get => _Recibidas; set { if (RaiseAcceptPendingChange(value, _Recibidas)) { _Recibidas = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadsurtida;
        [XmlAttribute]
        public decimal? Cantidadsurtida { get => _Cantidadsurtida; set { if (RaiseAcceptPendingChange(value, _Cantidadsurtida)) { _Cantidadsurtida = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private decimal? _Existencia;
        [XmlAttribute]
        public decimal? Existencia { get => _Existencia; set { if (RaiseAcceptPendingChange(value, _Existencia)) { _Existencia = value; OnPropertyChanged(); } } }

        private decimal? _Enprocesodesalida;
        [XmlAttribute]
        public decimal? Enprocesodesalida { get => _Enprocesodesalida; set { if (RaiseAcceptPendingChange(value, _Enprocesodesalida)) { _Enprocesodesalida = value; OnPropertyChanged(); } } }

        private string? _Manejalote;
        [XmlAttribute]
        public string? Manejalote { get => _Manejalote; set { if (RaiseAcceptPendingChange(value, _Manejalote)) { _Manejalote = value; OnPropertyChanged(); } } }

        private string? _Dgcambiarlote;
        [XmlAttribute]
        public string? Dgcambiarlote { get => _Dgcambiarlote; set { if (RaiseAcceptPendingChange(value, _Dgcambiarlote)) { _Dgcambiarlote = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfaltante;
        [XmlAttribute]
        public decimal? Cantidadfaltante { get => _Cantidadfaltante; set { if (RaiseAcceptPendingChange(value, _Cantidadfaltante)) { _Cantidadfaltante = value; OnPropertyChanged(); } } }

        private string? _Dgc_razondifinvid;
        [XmlAttribute]
        public string? Dgc_razondifinvid { get => _Dgc_razondifinvid; set { if (RaiseAcceptPendingChange(value, _Dgc_razondifinvid)) { _Dgc_razondifinvid = value; OnPropertyChanged(); } } }

        private string? _Dgc_razondifinvtext;
        [XmlAttribute]
        public string? Dgc_razondifinvtext { get => _Dgc_razondifinvtext; set { if (RaiseAcceptPendingChange(value, _Dgc_razondifinvtext)) { _Dgc_razondifinvtext = value; OnPropertyChanged(); } } }

        private string? _Texto1;
        [XmlAttribute]
        public string? Texto1 { get => _Texto1; set { if (RaiseAcceptPendingChange(value, _Texto1)) { _Texto1 = value; OnPropertyChanged(); } } }

        private string? _Texto2;
        [XmlAttribute]
        public string? Texto2 { get => _Texto2; set { if (RaiseAcceptPendingChange(value, _Texto2)) { _Texto2 = value; OnPropertyChanged(); } } }

        private string? _Texto3;
        [XmlAttribute]
        public string? Texto3 { get => _Texto3; set { if (RaiseAcceptPendingChange(value, _Texto3)) { _Texto3 = value; OnPropertyChanged(); } } }

        private string? _Texto4;
        [XmlAttribute]
        public string? Texto4 { get => _Texto4; set { if (RaiseAcceptPendingChange(value, _Texto4)) { _Texto4 = value; OnPropertyChanged(); } } }

        private string? _Texto5;
        [XmlAttribute]
        public string? Texto5 { get => _Texto5; set { if (RaiseAcceptPendingChange(value, _Texto5)) { _Texto5 = value; OnPropertyChanged(); } } }

        private string? _Texto6;
        [XmlAttribute]
        public string? Texto6 { get => _Texto6; set { if (RaiseAcceptPendingChange(value, _Texto6)) { _Texto6 = value; OnPropertyChanged(); } } }

        private decimal? _Numero1;
        [XmlAttribute]
        public decimal? Numero1 { get => _Numero1; set { if (RaiseAcceptPendingChange(value, _Numero1)) { _Numero1 = value; OnPropertyChanged(); } } }

        private decimal? _Numero2;
        [XmlAttribute]
        public decimal? Numero2 { get => _Numero2; set { if (RaiseAcceptPendingChange(value, _Numero2)) { _Numero2 = value; OnPropertyChanged(); } } }

        private decimal? _Numero3;
        [XmlAttribute]
        public decimal? Numero3 { get => _Numero3; set { if (RaiseAcceptPendingChange(value, _Numero3)) { _Numero3 = value; OnPropertyChanged(); } } }

        private decimal? _Numero4;
        [XmlAttribute]
        public decimal? Numero4 { get => _Numero4; set { if (RaiseAcceptPendingChange(value, _Numero4)) { _Numero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Fecha1 { get => _Fecha1; set { if (RaiseAcceptPendingChange(value, _Fecha1)) { _Fecha1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Fecha2 { get => _Fecha2; set { if (RaiseAcceptPendingChange(value, _Fecha2)) { _Fecha2 = value; OnPropertyChanged(); } } }

        private long? _Movtorefid;
        [XmlAttribute]
        public long? Movtorefid { get => _Movtorefid; set { if (RaiseAcceptPendingChange(value, _Movtorefid)) { _Movtorefid = value; OnPropertyChanged(); } } }

        private string? _Inventariable;
        [XmlAttribute]
        public string? Inventariable { get => _Inventariable; set { if (RaiseAcceptPendingChange(value, _Inventariable)) { _Inventariable = value; OnPropertyChanged(); } } }

        private string? _Negativos;
        [XmlAttribute]
        public string? Negativos { get => _Negativos; set { if (RaiseAcceptPendingChange(value, _Negativos)) { _Negativos = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

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

