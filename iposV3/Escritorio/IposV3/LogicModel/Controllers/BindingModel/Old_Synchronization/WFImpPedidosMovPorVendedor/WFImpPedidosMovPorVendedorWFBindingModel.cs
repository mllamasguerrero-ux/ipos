
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
    public class WFImpPedidosMovPorVendedorWFBindingModel : Validatable
    {

        public WFImpPedidosMovPorVendedorWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbimprimirrecibosfacturas;
        [XmlAttribute]
        public BoolCN? Cbimprimirrecibosfacturas { get => _Cbimprimirrecibosfacturas; set { if (RaiseAcceptPendingChange(value, _Cbimprimirrecibosfacturas)) { _Cbimprimirrecibosfacturas = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxClave;
        [XmlAttribute]
        public string? AlmacencomboboxClave { get => _AlmacencomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxClave)) { _AlmacencomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxNombre;
        [XmlAttribute]
        public string? AlmacencomboboxNombre { get => _AlmacencomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxNombre)) { _AlmacencomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFImpPedidosMovPorVendedorWF_Info_pedidos_movil_x_vendedorBindingModel : Validatable
    {

        public WFImpPedidosMovPorVendedorWF_Info_pedidos_movil_x_vendedorBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Ver;
        [XmlAttribute]
        public string? Ver { get => _Ver; set { if (RaiseAcceptPendingChange(value, _Ver)) { _Ver = value; OnPropertyChanged(); } } }

        private string? _Procesar;
        [XmlAttribute]
        public string? Procesar { get => _Procesar; set { if (RaiseAcceptPendingChange(value, _Procesar)) { _Procesar = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private string? _Bolitasaldo;
        [XmlAttribute]
        public string? Bolitasaldo { get => _Bolitasaldo; set { if (RaiseAcceptPendingChange(value, _Bolitasaldo)) { _Bolitasaldo = value; OnPropertyChanged(); } } }

        private string? _Docto_referencia;
        [XmlAttribute]
        public string? Docto_referencia { get => _Docto_referencia; set { if (RaiseAcceptPendingChange(value, _Docto_referencia)) { _Docto_referencia = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Statussaldo;
        [XmlAttribute]
        public string? Statussaldo { get => _Statussaldo; set { if (RaiseAcceptPendingChange(value, _Statussaldo)) { _Statussaldo = value; OnPropertyChanged(); } } }

        private string? _Estadorebaja;
        [XmlAttribute]
        public string? Estadorebaja { get => _Estadorebaja; set { if (RaiseAcceptPendingChange(value, _Estadorebaja)) { _Estadorebaja = value; OnPropertyChanged(); } } }

        private string? _Estadocredito;
        [XmlAttribute]
        public string? Estadocredito { get => _Estadocredito; set { if (RaiseAcceptPendingChange(value, _Estadocredito)) { _Estadocredito = value; OnPropertyChanged(); } } }

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

