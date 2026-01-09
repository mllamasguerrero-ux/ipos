
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
    public class WFRevisarPedidoWFBindingModel : Validatable
    {

        public WFRevisarPedidoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtsurtidoventa;
        [XmlAttribute]
        public DateTimeOffset? Dtsurtidoventa { get => _Dtsurtidoventa; set { if (RaiseAcceptPendingChange(value, _Dtsurtidoventa)) { _Dtsurtidoventa = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtventassurtidas;
        [XmlAttribute]
        public DateTimeOffset? Dtventassurtidas { get => _Dtventassurtidas; set { if (RaiseAcceptPendingChange(value, _Dtventassurtidas)) { _Dtventassurtidas = value; OnPropertyChanged(); } } }

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
    public class WFRevisarPedidoWF_DoctosasurtirBindingModel : Validatable
    {

        public WFRevisarPedidoWF_DoctosasurtirBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgsurtir;
        [XmlAttribute]
        public string? Dgsurtir { get => _Dgsurtir; set { if (RaiseAcceptPendingChange(value, _Dgsurtir)) { _Dgsurtir = value; OnPropertyChanged(); } } }

        private string? _Dgimprimir;
        [XmlAttribute]
        public string? Dgimprimir { get => _Dgimprimir; set { if (RaiseAcceptPendingChange(value, _Dgimprimir)) { _Dgimprimir = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Nombretipodocto;
        [XmlAttribute]
        public string? Nombretipodocto { get => _Nombretipodocto; set { if (RaiseAcceptPendingChange(value, _Nombretipodocto)) { _Nombretipodocto = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private string? _Vendedorclientenombre;
        [XmlAttribute]
        public string? Vendedorclientenombre { get => _Vendedorclientenombre; set { if (RaiseAcceptPendingChange(value, _Vendedorclientenombre)) { _Vendedorclientenombre = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private string? _Esventamovil;
        [XmlAttribute]
        public string? Esventamovil { get => _Esventamovil; set { if (RaiseAcceptPendingChange(value, _Esventamovil)) { _Esventamovil = value; OnPropertyChanged(); } } }

        private string? _Espedidotraslado;
        [XmlAttribute]
        public string? Espedidotraslado { get => _Espedidotraslado; set { if (RaiseAcceptPendingChange(value, _Espedidotraslado)) { _Espedidotraslado = value; OnPropertyChanged(); } } }

        private string? _Sucursaldestinonombre;
        [XmlAttribute]
        public string? Sucursaldestinonombre { get => _Sucursaldestinonombre; set { if (RaiseAcceptPendingChange(value, _Sucursaldestinonombre)) { _Sucursaldestinonombre = value; OnPropertyChanged(); } } }

        private string? _Username;
        [XmlAttribute]
        public string? Username { get => _Username; set { if (RaiseAcceptPendingChange(value, _Username)) { _Username = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private string? _Procesosurtido;
        [XmlAttribute]
        public string? Procesosurtido { get => _Procesosurtido; set { if (RaiseAcceptPendingChange(value, _Procesosurtido)) { _Procesosurtido = value; OnPropertyChanged(); } } }

        private string? _Observacionfacturacion;
        [XmlAttribute]
        public string? Observacionfacturacion { get => _Observacionfacturacion; set { if (RaiseAcceptPendingChange(value, _Observacionfacturacion)) { _Observacionfacturacion = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

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
    public class WFRevisarPedidoWF_1BindingModel : Validatable
    {

        public WFRevisarPedidoWF_1BindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgimprimirsurtido;
        [XmlAttribute]
        public string? Dgimprimirsurtido { get => _Dgimprimirsurtido; set { if (RaiseAcceptPendingChange(value, _Dgimprimirsurtido)) { _Dgimprimirsurtido = value; OnPropertyChanged(); } } }

        private string? _Dgticketrevision;
        [XmlAttribute]
        public string? Dgticketrevision { get => _Dgticketrevision; set { if (RaiseAcceptPendingChange(value, _Dgticketrevision)) { _Dgticketrevision = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Nombretipodocto;
        [XmlAttribute]
        public string? Nombretipodocto { get => _Nombretipodocto; set { if (RaiseAcceptPendingChange(value, _Nombretipodocto)) { _Nombretipodocto = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private string? _Vendedorclientenombre;
        [XmlAttribute]
        public string? Vendedorclientenombre { get => _Vendedorclientenombre; set { if (RaiseAcceptPendingChange(value, _Vendedorclientenombre)) { _Vendedorclientenombre = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private string? _Esventamovil;
        [XmlAttribute]
        public string? Esventamovil { get => _Esventamovil; set { if (RaiseAcceptPendingChange(value, _Esventamovil)) { _Esventamovil = value; OnPropertyChanged(); } } }

        private string? _Espedidotraslado;
        [XmlAttribute]
        public string? Espedidotraslado { get => _Espedidotraslado; set { if (RaiseAcceptPendingChange(value, _Espedidotraslado)) { _Espedidotraslado = value; OnPropertyChanged(); } } }

        private string? _Sucursaldestinonombre;
        [XmlAttribute]
        public string? Sucursaldestinonombre { get => _Sucursaldestinonombre; set { if (RaiseAcceptPendingChange(value, _Sucursaldestinonombre)) { _Sucursaldestinonombre = value; OnPropertyChanged(); } } }

        private string? _Username;
        [XmlAttribute]
        public string? Username { get => _Username; set { if (RaiseAcceptPendingChange(value, _Username)) { _Username = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private string? _Procesosurtido;
        [XmlAttribute]
        public string? Procesosurtido { get => _Procesosurtido; set { if (RaiseAcceptPendingChange(value, _Procesosurtido)) { _Procesosurtido = value; OnPropertyChanged(); } } }

        private string? _Observacionfacturacion;
        [XmlAttribute]
        public string? Observacionfacturacion { get => _Observacionfacturacion; set { if (RaiseAcceptPendingChange(value, _Observacionfacturacion)) { _Observacionfacturacion = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

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

