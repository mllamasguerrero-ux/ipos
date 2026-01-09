
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
    public class WFReporteComprasSucWFBindingModel : Validatable
    {

        public WFReporteComprasSucWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _SucursalidClave;
        [XmlAttribute]
        public string? SucursalidClave { get => _SucursalidClave; set { if (RaiseAcceptPendingChange(value, _SucursalidClave)) { _SucursalidClave = value; OnPropertyChanged(); } } }

        private string? _SucursalidNombre;
        [XmlAttribute]
        public string? SucursalidNombre { get => _SucursalidNombre; set { if (RaiseAcceptPendingChange(value, _SucursalidNombre)) { _SucursalidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsinfacturaproc;
        [XmlAttribute]
        public BoolCN? Cbsinfacturaproc { get => _Cbsinfacturaproc; set { if (RaiseAcceptPendingChange(value, _Cbsinfacturaproc)) { _Cbsinfacturaproc = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsucursal;
        [XmlAttribute]
        public BoolCN? Cbsucursal { get => _Cbsucursal; set { if (RaiseAcceptPendingChange(value, _Cbsucursal)) { _Cbsucursal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepicker2;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker2 { get => _Datetimepicker2; set { if (RaiseAcceptPendingChange(value, _Datetimepicker2)) { _Datetimepicker2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfecha;
        [XmlAttribute]
        public BoolCN? Cbfecha { get => _Cbfecha; set { if (RaiseAcceptPendingChange(value, _Cbfecha)) { _Cbfecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbproveedor;
        [XmlAttribute]
        public BoolCN? Cbproveedor { get => _Cbproveedor; set { if (RaiseAcceptPendingChange(value, _Cbproveedor)) { _Cbproveedor = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

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

