
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
    public class V_pagomultiple_ventaWFBindingModel : Validatable
    {

        public V_pagomultiple_ventaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _P_empresaid;
        [XmlAttribute]
        public long? P_empresaid { get => _P_empresaid; set { if (RaiseAcceptPendingChange(value, _P_empresaid)) { _P_empresaid = value; OnPropertyChanged(); } } }

        private long? _P_sucursalid;
        [XmlAttribute]
        public long? P_sucursalid { get => _P_sucursalid; set { if (RaiseAcceptPendingChange(value, _P_sucursalid)) { _P_sucursalid = value; OnPropertyChanged(); } } }

        private long? _P_id;
        [XmlAttribute]
        public long? P_id { get => _P_id; set { if (RaiseAcceptPendingChange(value, _P_id)) { _P_id = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }


        private decimal? _Restante;
        [XmlAttribute]
        public decimal? Restante { get => _Restante; set { if (RaiseAcceptPendingChange(value, _Restante)) { _Restante = value; OnPropertyChanged(); } } }



        private decimal? _Montoefectivo;
        [XmlAttribute]
        public decimal? Montoefectivo { get => _Montoefectivo; set { if (RaiseAcceptPendingChange(value, _Montoefectivo)) { _Montoefectivo = value; OnPropertyChanged(); } } }

        private long? _Tipotarjeta;
        [XmlAttribute]
        public long? Tipotarjeta { get => _Tipotarjeta; set { if (RaiseAcceptPendingChange(value, _Tipotarjeta)) { _Tipotarjeta = value; OnPropertyChanged(); } } }

        private string? _Tipotarjetaclave;
        [XmlAttribute]
        public string? Tipotarjetaclave { get => _Tipotarjetaclave; set { if (RaiseAcceptPendingChange(value, _Tipotarjetaclave)) { _Tipotarjetaclave = value; OnPropertyChanged(); } } }

        private string? _Tipotarjetanombre;
        [XmlAttribute]
        public string? Tipotarjetanombre { get => _Tipotarjetanombre; set { if (RaiseAcceptPendingChange(value, _Tipotarjetanombre)) { _Tipotarjetanombre = value; OnPropertyChanged(); } } }

        private decimal? _Montotarjeta;
        [XmlAttribute]
        public decimal? Montotarjeta { get => _Montotarjeta; set { if (RaiseAcceptPendingChange(value, _Montotarjeta)) { _Montotarjeta = value; OnPropertyChanged(); } } }

        private long? _Bancotarjetaid;
        [XmlAttribute]
        public long? Bancotarjetaid { get => _Bancotarjetaid; set { if (RaiseAcceptPendingChange(value, _Bancotarjetaid)) { _Bancotarjetaid = value; OnPropertyChanged(); } } }

        private string? _Bancotarjetaclave;
        [XmlAttribute]
        public string? Bancotarjetaclave { get => _Bancotarjetaclave; set { if (RaiseAcceptPendingChange(value, _Bancotarjetaclave)) { _Bancotarjetaclave = value; OnPropertyChanged(); } } }

        private string? _Bancotarjetanombre;
        [XmlAttribute]
        public string? Bancotarjetanombre { get => _Bancotarjetanombre; set { if (RaiseAcceptPendingChange(value, _Bancotarjetanombre)) { _Bancotarjetanombre = value; OnPropertyChanged(); } } }

        private string? _Referenciatarjeta;
        [XmlAttribute]
        public string? Referenciatarjeta { get => _Referenciatarjeta; set { if (RaiseAcceptPendingChange(value, _Referenciatarjeta)) { _Referenciatarjeta = value; OnPropertyChanged(); } } }

        private decimal? _Montocheque;
        [XmlAttribute]
        public decimal? Montocheque { get => _Montocheque; set { if (RaiseAcceptPendingChange(value, _Montocheque)) { _Montocheque = value; OnPropertyChanged(); } } }

        private long? _Bancochequeid;
        [XmlAttribute]
        public long? Bancochequeid { get => _Bancochequeid; set { if (RaiseAcceptPendingChange(value, _Bancochequeid)) { _Bancochequeid = value; OnPropertyChanged(); } } }

        private string? _Bancochequeclave;
        [XmlAttribute]
        public string? Bancochequeclave { get => _Bancochequeclave; set { if (RaiseAcceptPendingChange(value, _Bancochequeclave)) { _Bancochequeclave = value; OnPropertyChanged(); } } }

        private string? _Bancochequenombre;
        [XmlAttribute]
        public string? Bancochequenombre { get => _Bancochequenombre; set { if (RaiseAcceptPendingChange(value, _Bancochequenombre)) { _Bancochequenombre = value; OnPropertyChanged(); } } }

        private string? _Referenciacheque;
        [XmlAttribute]
        public string? Referenciacheque { get => _Referenciacheque; set { if (RaiseAcceptPendingChange(value, _Referenciacheque)) { _Referenciacheque = value; OnPropertyChanged(); } } }

        private decimal? _Montotransferencia;
        [XmlAttribute]
        public decimal? Montotransferencia { get => _Montotransferencia; set { if (RaiseAcceptPendingChange(value, _Montotransferencia)) { _Montotransferencia = value; OnPropertyChanged(); } } }

        private long? _Bancotransferenciaid;
        [XmlAttribute]
        public long? Bancotransferenciaid { get => _Bancotransferenciaid; set { if (RaiseAcceptPendingChange(value, _Bancotransferenciaid)) { _Bancotransferenciaid = value; OnPropertyChanged(); } } }

        private string? _Bancotransferenciaclave;
        [XmlAttribute]
        public string? Bancotransferenciaclave { get => _Bancotransferenciaclave; set { if (RaiseAcceptPendingChange(value, _Bancotransferenciaclave)) { _Bancotransferenciaclave = value; OnPropertyChanged(); } } }

        private string? _Bancotransferencianombre;
        [XmlAttribute]
        public string? Bancotransferencianombre { get => _Bancotransferencianombre; set { if (RaiseAcceptPendingChange(value, _Bancotransferencianombre)) { _Bancotransferencianombre = value; OnPropertyChanged(); } } }

        private string? _Referenciatransferencia;
        [XmlAttribute]
        public string? Referenciatransferencia { get => _Referenciatransferencia; set { if (RaiseAcceptPendingChange(value, _Referenciatransferencia)) { _Referenciatransferencia = value; OnPropertyChanged(); } } }

        private decimal? _Montovale;
        [XmlAttribute]
        public decimal? Montovale { get => _Montovale; set { if (RaiseAcceptPendingChange(value, _Montovale)) { _Montovale = value; OnPropertyChanged(); } } }

        private decimal? _Montomonedero;
        [XmlAttribute]
        public decimal? Montomonedero { get => _Montomonedero; set { if (RaiseAcceptPendingChange(value, _Montomonedero)) { _Montomonedero = value; OnPropertyChanged(); } } }

        private string? _Numeromonedero;
        [XmlAttribute]
        public string? Numeromonedero { get => _Numeromonedero; set { if (RaiseAcceptPendingChange(value, _Numeromonedero)) { _Numeromonedero = value; OnPropertyChanged(); } } }

        private decimal? _Montocredito;
        [XmlAttribute]
        public decimal? Montocredito { get => _Montocredito; set { if (RaiseAcceptPendingChange(value, _Montocredito)) { _Montocredito = value; OnPropertyChanged(); } } }

        private decimal? _Montocomprarelacionada;
        [XmlAttribute]
        public decimal? Montocomprarelacionada { get => _Montocomprarelacionada; set { if (RaiseAcceptPendingChange(value, _Montocomprarelacionada)) { _Montocomprarelacionada = value; OnPropertyChanged(); } } }

        private string? _Generarfacturaelectronica;
        [XmlAttribute]
        public string? Generarfacturaelectronica { get => _Generarfacturaelectronica; set { if (RaiseAcceptPendingChange(value, _Generarfacturaelectronica)) { _Generarfacturaelectronica = value; OnPropertyChanged(); } } }



        private string? _Generarcomprobantetraslado;
        [XmlAttribute]
        public string? Generarcomprobantetraslado { get => _Generarcomprobantetraslado; set { if (RaiseAcceptPendingChange(value, _Generarcomprobantetraslado)) { _Generarcomprobantetraslado = value; OnPropertyChanged(); } } }



        private string? _Generarcartaporte;
        [XmlAttribute]
        public string? Generarcartaporte { get => _Generarcartaporte; set { if (RaiseAcceptPendingChange(value, _Generarcartaporte)) { _Generarcartaporte = value; OnPropertyChanged(); } } }




        private long? _Usocfdiid;
        [XmlAttribute]
        public long? Usocfdiid { get => _Usocfdiid; set { if (RaiseAcceptPendingChange(value, _Usocfdiid)) { _Usocfdiid = value; OnPropertyChanged(); } } }

        private string? _Usocfdiclave;
        [XmlAttribute]
        public string? Usocfdiclave { get => _Usocfdiclave; set { if (RaiseAcceptPendingChange(value, _Usocfdiclave)) { _Usocfdiclave = value; OnPropertyChanged(); } } }

        private string? _Usocfdinombre;
        [XmlAttribute]
        public string? Usocfdinombre { get => _Usocfdinombre; set { if (RaiseAcceptPendingChange(value, _Usocfdinombre)) { _Usocfdinombre = value; OnPropertyChanged(); } } }

        private string? _Surtidohastaalmacen;
        [XmlAttribute]
        public string? Surtidohastaalmacen { get => _Surtidohastaalmacen; set { if (RaiseAcceptPendingChange(value, _Surtidohastaalmacen)) { _Surtidohastaalmacen = value; OnPropertyChanged(); } } }

        private string? _Marcarpararevision;
        [XmlAttribute]
        public string? Marcarpararevision { get => _Marcarpararevision; set { if (RaiseAcceptPendingChange(value, _Marcarpararevision)) { _Marcarpararevision = value; OnPropertyChanged(); } } }

        private decimal? _Montocambio;
        [XmlAttribute]
        public decimal? Montocambio { get => _Montocambio; set { if (RaiseAcceptPendingChange(value, _Montocambio)) { _Montocambio = value; OnPropertyChanged(); } } }

        private decimal? _Montootros;
        [XmlAttribute]
        public decimal? Montootros { get => _Montootros; set { if (RaiseAcceptPendingChange(value, _Montootros)) { _Montootros = value; OnPropertyChanged(); } } }

        private string? _Observaciones;
        [XmlAttribute]
        public string? Observaciones { get => _Observaciones; set { if (RaiseAcceptPendingChange(value, _Observaciones)) { _Observaciones = value; OnPropertyChanged(); } } }


        public GuiaBindingModel? _Guia;
        [XmlAttribute]
        public GuiaBindingModel? Guia { get => _Guia; set { if (RaiseAcceptPendingChange(value, _Guia)) { _Guia = value; OnPropertyChanged(); } } }


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


        public static V_pagomultiple_ventaWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_pagomultiple_ventaWFBindingModel = new V_pagomultiple_ventaWFBindingModel();

        	buffer_V_pagomultiple_ventaWFBindingModel._P_empresaid = obj.P_empresaid;

        	buffer_V_pagomultiple_ventaWFBindingModel._P_sucursalid = obj.P_sucursalid;

        	buffer_V_pagomultiple_ventaWFBindingModel._P_id = obj.P_id;

        	buffer_V_pagomultiple_ventaWFBindingModel._Total = obj.Total;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montoefectivo = obj.Montoefectivo;

        	buffer_V_pagomultiple_ventaWFBindingModel._Tipotarjeta = obj.Tipotarjeta;

        	buffer_V_pagomultiple_ventaWFBindingModel._Tipotarjetaclave = obj.Tipotarjetaclave;

        	buffer_V_pagomultiple_ventaWFBindingModel._Tipotarjetanombre = obj.Tipotarjetanombre;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montotarjeta = obj.Montotarjeta;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancotarjetaid = obj.Bancotarjetaid;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancotarjetaclave = obj.Bancotarjetaclave;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancotarjetanombre = obj.Bancotarjetanombre;

        	buffer_V_pagomultiple_ventaWFBindingModel._Referenciatarjeta = obj.Referenciatarjeta;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montocheque = obj.Montocheque;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancochequeid = obj.Bancochequeid;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancochequeclave = obj.Bancochequeclave;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancochequenombre = obj.Bancochequenombre;

        	buffer_V_pagomultiple_ventaWFBindingModel._Referenciacheque = obj.Referenciacheque;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montotransferencia = obj.Montotransferencia;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancotransferenciaid = obj.Bancotransferenciaid;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancotransferenciaclave = obj.Bancotransferenciaclave;

        	buffer_V_pagomultiple_ventaWFBindingModel._Bancotransferencianombre = obj.Bancotransferencianombre;

        	buffer_V_pagomultiple_ventaWFBindingModel._Referenciatransferencia = obj.Referenciatransferencia;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montovale = obj.Montovale;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montomonedero = obj.Montomonedero;

        	buffer_V_pagomultiple_ventaWFBindingModel._Numeromonedero = obj.Numeromonedero;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montocredito = obj.Montocredito;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montocomprarelacionada = obj.Montocomprarelacionada;

        	buffer_V_pagomultiple_ventaWFBindingModel._Generarfacturaelectronica = obj.Generarfacturaelectronica;

        	buffer_V_pagomultiple_ventaWFBindingModel._Usocfdiid = obj.Usocfdiid;

        	buffer_V_pagomultiple_ventaWFBindingModel._Usocfdiclave = obj.Usocfdiclave;

        	buffer_V_pagomultiple_ventaWFBindingModel._Usocfdinombre = obj.Usocfdinombre;

        	buffer_V_pagomultiple_ventaWFBindingModel._Surtidohastaalmacen = obj.Surtidohastaalmacen;

        	buffer_V_pagomultiple_ventaWFBindingModel._Marcarpararevision = obj.Marcarpararevision;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montocambio = obj.Montocambio;

        	buffer_V_pagomultiple_ventaWFBindingModel._Montootros = obj.Montootros;

        	buffer_V_pagomultiple_ventaWFBindingModel._Observaciones = obj.Observaciones;

            return buffer_V_pagomultiple_ventaWFBindingModel;
        }


    }

    
     
}

