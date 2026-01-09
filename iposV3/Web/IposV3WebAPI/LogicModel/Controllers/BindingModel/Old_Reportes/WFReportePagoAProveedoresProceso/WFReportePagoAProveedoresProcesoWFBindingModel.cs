
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
    public class WFReportePagoAProveedoresProcesoWFBindingModel : Validatable
    {

        public WFReportePagoAProveedoresProcesoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cliente;
        [XmlAttribute]
        public long? Cliente { get => _Cliente; set { if (RaiseAcceptPendingChange(value, _Cliente)) { _Cliente = value; OnPropertyChanged(); } } }

        private string? _ClienteClave;
        [XmlAttribute]
        public string? ClienteClave { get => _ClienteClave; set { if (RaiseAcceptPendingChange(value, _ClienteClave)) { _ClienteClave = value; OnPropertyChanged(); } } }

        private string? _ClienteNombre;
        [XmlAttribute]
        public string? ClienteNombre { get => _ClienteNombre; set { if (RaiseAcceptPendingChange(value, _ClienteNombre)) { _ClienteNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Todosclientes;
        [XmlAttribute]
        public BoolCN? Todosclientes { get => _Todosclientes; set { if (RaiseAcceptPendingChange(value, _Todosclientes)) { _Todosclientes = value; OnPropertyChanged(); } } }

        private BoolCN? _Selectcliente;
        [XmlAttribute]
        public BoolCN? Selectcliente { get => _Selectcliente; set { if (RaiseAcceptPendingChange(value, _Selectcliente)) { _Selectcliente = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private long? _Proveedor;
        [XmlAttribute]
        public long? Proveedor { get => _Proveedor; set { if (RaiseAcceptPendingChange(value, _Proveedor)) { _Proveedor = value; OnPropertyChanged(); } } }

        private string? _ProveedorClave;
        [XmlAttribute]
        public string? ProveedorClave { get => _ProveedorClave; set { if (RaiseAcceptPendingChange(value, _ProveedorClave)) { _ProveedorClave = value; OnPropertyChanged(); } } }

        private string? _ProveedorNombre;
        [XmlAttribute]
        public string? ProveedorNombre { get => _ProveedorNombre; set { if (RaiseAcceptPendingChange(value, _ProveedorNombre)) { _ProveedorNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Todosproveedores;
        [XmlAttribute]
        public BoolCN? Todosproveedores { get => _Todosproveedores; set { if (RaiseAcceptPendingChange(value, _Todosproveedores)) { _Todosproveedores = value; OnPropertyChanged(); } } }

        private BoolCN? _Selectproveedor;
        [XmlAttribute]
        public BoolCN? Selectproveedor { get => _Selectproveedor; set { if (RaiseAcceptPendingChange(value, _Selectproveedor)) { _Selectproveedor = value; OnPropertyChanged(); } } }

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

