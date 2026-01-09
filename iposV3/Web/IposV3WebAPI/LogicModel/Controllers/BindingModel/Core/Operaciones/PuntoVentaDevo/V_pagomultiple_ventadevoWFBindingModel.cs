
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
    public class V_pagomultiple_ventadevoWFBindingModel : Validatable
    {

        public V_pagomultiple_ventadevoWFBindingModel()
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

        private string? _Aplicarcreditoautomatico;
        [XmlAttribute]
        public string? Aplicarcreditoautomatico { get => _Aplicarcreditoautomatico; set { if (RaiseAcceptPendingChange(value, _Aplicarcreditoautomatico)) { _Aplicarcreditoautomatico = value; OnPropertyChanged(); } } }

        private decimal? _Montocreditoautomatico;
        [XmlAttribute]
        public decimal? Montocreditoautomatico { get => _Montocreditoautomatico; set { if (RaiseAcceptPendingChange(value, _Montocreditoautomatico)) { _Montocreditoautomatico = value; OnPropertyChanged(); } } }

        private string? _Generarfacturaelectronica;
        [XmlAttribute]
        public string? Generarfacturaelectronica { get => _Generarfacturaelectronica; set { if (RaiseAcceptPendingChange(value, _Generarfacturaelectronica)) { _Generarfacturaelectronica = value; OnPropertyChanged(); } } }

        private string? _Observaciones;
        [XmlAttribute]
        public string? Observaciones { get => _Observaciones; set { if (RaiseAcceptPendingChange(value, _Observaciones)) { _Observaciones = value; OnPropertyChanged(); } } }

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


        public static V_pagomultiple_ventadevoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_pagomultiple_ventadevoWFBindingModel = new V_pagomultiple_ventadevoWFBindingModel();

        	buffer_V_pagomultiple_ventadevoWFBindingModel._P_empresaid = obj.P_empresaid;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._P_sucursalid = obj.P_sucursalid;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._P_id = obj.P_id;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._Total = obj.Total;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._Montoefectivo = obj.Montoefectivo;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._Aplicarcreditoautomatico = obj.Aplicarcreditoautomatico;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._Montocreditoautomatico = obj.Montocreditoautomatico;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._Generarfacturaelectronica = obj.Generarfacturaelectronica;

        	buffer_V_pagomultiple_ventadevoWFBindingModel._Observaciones = obj.Observaciones;

            return buffer_V_pagomultiple_ventadevoWFBindingModel;
        }


    }

    
     
}

