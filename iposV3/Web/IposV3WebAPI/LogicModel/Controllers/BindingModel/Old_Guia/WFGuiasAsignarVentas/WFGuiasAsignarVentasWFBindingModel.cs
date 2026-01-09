
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
    public class WFGuiasAsignarVentasWFBindingModel : Validatable
    {

        public WFGuiasAsignarVentasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

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
    public class WFGuiasAsignarVentasWF_Ventasporenviar_BindingModel : Validatable
    {

        public WFGuiasAsignarVentasWF_Ventasporenviar_BindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

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

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedorcliente;
        [XmlAttribute]
        public string? Nombrevendedorcliente { get => _Nombrevendedorcliente; set { if (RaiseAcceptPendingChange(value, _Nombrevendedorcliente)) { _Nombrevendedorcliente = value; OnPropertyChanged(); } } }

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private string? _Clientedomicilio;
        [XmlAttribute]
        public string? Clientedomicilio { get => _Clientedomicilio; set { if (RaiseAcceptPendingChange(value, _Clientedomicilio)) { _Clientedomicilio = value; OnPropertyChanged(); } } }

        private string? _Clienteciudad;
        [XmlAttribute]
        public string? Clienteciudad { get => _Clienteciudad; set { if (RaiseAcceptPendingChange(value, _Clienteciudad)) { _Clienteciudad = value; OnPropertyChanged(); } } }

        private string? _Clientecodigopostal;
        [XmlAttribute]
        public string? Clientecodigopostal { get => _Clientecodigopostal; set { if (RaiseAcceptPendingChange(value, _Clientecodigopostal)) { _Clientecodigopostal = value; OnPropertyChanged(); } } }

        private string? _Clientecolonia;
        [XmlAttribute]
        public string? Clientecolonia { get => _Clientecolonia; set { if (RaiseAcceptPendingChange(value, _Clientecolonia)) { _Clientecolonia = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private string? _Procesosurtido;
        [XmlAttribute]
        public string? Procesosurtido { get => _Procesosurtido; set { if (RaiseAcceptPendingChange(value, _Procesosurtido)) { _Procesosurtido = value; OnPropertyChanged(); } } }

        private string? _Observacionfacturacion;
        [XmlAttribute]
        public string? Observacionfacturacion { get => _Observacionfacturacion; set { if (RaiseAcceptPendingChange(value, _Observacionfacturacion)) { _Observacionfacturacion = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Esventamovil;
        [XmlAttribute]
        public string? Esventamovil { get => _Esventamovil; set { if (RaiseAcceptPendingChange(value, _Esventamovil)) { _Esventamovil = value; OnPropertyChanged(); } } }

        private string? _Nombretipodocto;
        [XmlAttribute]
        public string? Nombretipodocto { get => _Nombretipodocto; set { if (RaiseAcceptPendingChange(value, _Nombretipodocto)) { _Nombretipodocto = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Espedidotraslado;
        [XmlAttribute]
        public string? Espedidotraslado { get => _Espedidotraslado; set { if (RaiseAcceptPendingChange(value, _Espedidotraslado)) { _Espedidotraslado = value; OnPropertyChanged(); } } }

        private string? _Sucursaldestinonombre;
        [XmlAttribute]
        public string? Sucursaldestinonombre { get => _Sucursaldestinonombre; set { if (RaiseAcceptPendingChange(value, _Sucursaldestinonombre)) { _Sucursaldestinonombre = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private decimal? _Limitecredito;
        [XmlAttribute]
        public decimal? Limitecredito { get => _Limitecredito; set { if (RaiseAcceptPendingChange(value, _Limitecredito)) { _Limitecredito = value; OnPropertyChanged(); } } }

        private int? _Dias;
        [XmlAttribute]
        public int? Dias { get => _Dias; set { if (RaiseAcceptPendingChange(value, _Dias)) { _Dias = value; OnPropertyChanged(); } } }

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

