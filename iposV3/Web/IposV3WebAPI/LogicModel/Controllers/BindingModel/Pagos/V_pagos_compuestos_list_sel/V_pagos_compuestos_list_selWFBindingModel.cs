
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
    public class V_pagos_compuestos_list_selWFBindingModel : Validatable
    {

        public V_pagos_compuestos_list_selWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private string? _Formapagoclave;
        [XmlAttribute]
        public string? Formapagoclave { get => _Formapagoclave; set { if (RaiseAcceptPendingChange(value, _Formapagoclave)) { _Formapagoclave = value; OnPropertyChanged(); } } }

        private string? _Formapagonombre;
        [XmlAttribute]
        public string? Formapagonombre { get => _Formapagonombre; set { if (RaiseAcceptPendingChange(value, _Formapagonombre)) { _Formapagonombre = value; OnPropertyChanged(); } } }

        private long? _Clienteid;
        [XmlAttribute]
        public long? Clienteid { get => _Clienteid; set { if (RaiseAcceptPendingChange(value, _Clienteid)) { _Clienteid = value; OnPropertyChanged(); } } }

        private string? _Clienteclave;
        [XmlAttribute]
        public string? Clienteclave { get => _Clienteclave; set { if (RaiseAcceptPendingChange(value, _Clienteclave)) { _Clienteclave = value; OnPropertyChanged(); } } }

        private string? _Clientenombre;
        [XmlAttribute]
        public string? Clientenombre { get => _Clientenombre; set { if (RaiseAcceptPendingChange(value, _Clientenombre)) { _Clientenombre = value; OnPropertyChanged(); } } }

        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }

        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _Proveedornombre;
        [XmlAttribute]
        public string? Proveedornombre { get => _Proveedornombre; set { if (RaiseAcceptPendingChange(value, _Proveedornombre)) { _Proveedornombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechainicial;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Fechainicial { get => _Fechainicial?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Fechainicial)) { _Fechainicial = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafinal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Fechafinal { get => _Fechafinal?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Fechafinal)) { _Fechafinal = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private bool? _Solofiscales;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool? Solofiscales { get => _Solofiscales?? false; set { if (RaiseAcceptPendingChange(value, _Solofiscales)) { _Solofiscales = value?? false; OnPropertyChanged(); } } }

        private bool? _Incluircancelaciones;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool? Incluircancelaciones { get => _Incluircancelaciones?? false; set { if (RaiseAcceptPendingChange(value, _Incluircancelaciones)) { _Incluircancelaciones = value?? false; OnPropertyChanged(); } } }

        private string? _Aplicados;
        [XmlAttribute]
        public string? Aplicados { get => _Aplicados; set { if (RaiseAcceptPendingChange(value, _Aplicados)) { _Aplicados = value; OnPropertyChanged(); } } }

        private string? _Timbrados;
        [XmlAttribute]
        public string? Timbrados { get => _Timbrados; set { if (RaiseAcceptPendingChange(value, _Timbrados)) { _Timbrados = value; OnPropertyChanged(); } } }

        private string? _Busqueda;
        [XmlAttribute]
        public string? Busqueda { get => _Busqueda; set { if (RaiseAcceptPendingChange(value, _Busqueda)) { _Busqueda = value; OnPropertyChanged(); } } }



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


        public static V_pagos_compuestos_list_selWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_pagos_compuestos_list_selWFBindingModel = new V_pagos_compuestos_list_selWFBindingModel();

        	buffer_V_pagos_compuestos_list_selWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Formapagoid = obj.Formapagoid;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Formapagoclave = obj.Formapagoclave;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Formapagonombre = obj.Formapagonombre;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Clienteid = obj.Clienteid;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Clienteclave = obj.Clienteclave;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Clientenombre = obj.Clientenombre;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Proveedorid = obj.Proveedorid;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Proveedorclave = obj.Proveedorclave;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Proveedornombre = obj.Proveedornombre;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Fechainicial = obj.Fechainicial;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Fechafinal = obj.Fechafinal;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Solofiscales = obj.Solofiscales;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Incluircancelaciones = obj.Incluircancelaciones;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Aplicados = obj.Aplicados;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Timbrados = obj.Timbrados;

        	buffer_V_pagos_compuestos_list_selWFBindingModel._Busqueda = obj.Busqueda;

            return buffer_V_pagos_compuestos_list_selWFBindingModel;
        }


    }

    
     
}

