
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
    public class V_pagomultiple_compraWFBindingModel : Validatable
    {

        public V_pagomultiple_compraWFBindingModel()
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

        private string? _Observaciones;
        [XmlAttribute]
        public string? Observaciones { get => _Observaciones; set { if (RaiseAcceptPendingChange(value, _Observaciones)) { _Observaciones = value; OnPropertyChanged(); } } }


        private decimal? _Restante;
        [XmlAttribute]
        public decimal? Restante { get => _Restante; set { if (RaiseAcceptPendingChange(value, _Restante)) { _Restante = value; OnPropertyChanged(); } } }


        private decimal? _Montocredito;
        [XmlAttribute]
        public decimal? Montocredito { get => _Montocredito; set { if (RaiseAcceptPendingChange(value, _Montocredito)) { _Montocredito = value; OnPropertyChanged(); } } }


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


        public static V_pagomultiple_compraWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_pagomultiple_compraWFBindingModel = new V_pagomultiple_compraWFBindingModel();

        	buffer_V_pagomultiple_compraWFBindingModel._P_empresaid = obj.P_empresaid;

        	buffer_V_pagomultiple_compraWFBindingModel._P_sucursalid = obj.P_sucursalid;

        	buffer_V_pagomultiple_compraWFBindingModel._P_id = obj.P_id;

        	buffer_V_pagomultiple_compraWFBindingModel._Total = obj.Total;

        	buffer_V_pagomultiple_compraWFBindingModel._Montoefectivo = obj.Montoefectivo;

        	buffer_V_pagomultiple_compraWFBindingModel._Tipotarjeta = obj.Tipotarjeta;

        	buffer_V_pagomultiple_compraWFBindingModel._Tipotarjetaclave = obj.Tipotarjetaclave;

        	buffer_V_pagomultiple_compraWFBindingModel._Tipotarjetanombre = obj.Tipotarjetanombre;

        	buffer_V_pagomultiple_compraWFBindingModel._Montotarjeta = obj.Montotarjeta;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancotarjetaid = obj.Bancotarjetaid;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancotarjetaclave = obj.Bancotarjetaclave;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancotarjetanombre = obj.Bancotarjetanombre;

        	buffer_V_pagomultiple_compraWFBindingModel._Referenciatarjeta = obj.Referenciatarjeta;

        	buffer_V_pagomultiple_compraWFBindingModel._Montocheque = obj.Montocheque;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancochequeid = obj.Bancochequeid;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancochequeclave = obj.Bancochequeclave;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancochequenombre = obj.Bancochequenombre;

        	buffer_V_pagomultiple_compraWFBindingModel._Referenciacheque = obj.Referenciacheque;

        	buffer_V_pagomultiple_compraWFBindingModel._Montotransferencia = obj.Montotransferencia;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancotransferenciaid = obj.Bancotransferenciaid;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancotransferenciaclave = obj.Bancotransferenciaclave;

        	buffer_V_pagomultiple_compraWFBindingModel._Bancotransferencianombre = obj.Bancotransferencianombre;

        	buffer_V_pagomultiple_compraWFBindingModel._Referenciatransferencia = obj.Referenciatransferencia;

        	buffer_V_pagomultiple_compraWFBindingModel._Observaciones = obj.Observaciones;

            return buffer_V_pagomultiple_compraWFBindingModel;
        }


    }

    
     
}

