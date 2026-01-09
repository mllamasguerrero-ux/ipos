
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
    public class WFLookUpCompraSucursalesWFBindingModel : Validatable
    {

        public WFLookUpCompraSucursalesWFBindingModel()
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

        private BoolCN? _Cbsucursal;
        [XmlAttribute]
        public BoolCN? Cbsucursal { get => _Cbsucursal; set { if (RaiseAcceptPendingChange(value, _Cbsucursal)) { _Cbsucursal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbproveedor;
        [XmlAttribute]
        public BoolCN? Cbproveedor { get => _Cbproveedor; set { if (RaiseAcceptPendingChange(value, _Cbproveedor)) { _Cbproveedor = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfecha;
        [XmlAttribute]
        public BoolCN? Cbfecha { get => _Cbfecha; set { if (RaiseAcceptPendingChange(value, _Cbfecha)) { _Cbfecha = value; OnPropertyChanged(); } } }

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
    public class WFLookUpCompraSucursalesWF_TransaccioneslistaBindingModel : Validatable
    {

        public WFLookUpCompraSucursalesWF_TransaccioneslistaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Consecutivo;
        [XmlAttribute]
        public long? Consecutivo { get => _Consecutivo; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value; OnPropertyChanged(); } } }

        private string? _Sucdestnombre;
        [XmlAttribute]
        public string? Sucdestnombre { get => _Sucdestnombre; set { if (RaiseAcceptPendingChange(value, _Sucdestnombre)) { _Sucdestnombre = value; OnPropertyChanged(); } } }

        private string? _Personanombre;
        [XmlAttribute]
        public string? Personanombre { get => _Personanombre; set { if (RaiseAcceptPendingChange(value, _Personanombre)) { _Personanombre = value; OnPropertyChanged(); } } }

        private string? _Caja;
        [XmlAttribute]
        public string? Caja { get => _Caja; set { if (RaiseAcceptPendingChange(value, _Caja)) { _Caja = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Claveestatusdocto;
        [XmlAttribute]
        public string? Claveestatusdocto { get => _Claveestatusdocto; set { if (RaiseAcceptPendingChange(value, _Claveestatusdocto)) { _Claveestatusdocto = value; OnPropertyChanged(); } } }

        private string? _Clavetipodocto;
        [XmlAttribute]
        public string? Clavetipodocto { get => _Clavetipodocto; set { if (RaiseAcceptPendingChange(value, _Clavetipodocto)) { _Clavetipodocto = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _Turno;
        [XmlAttribute]
        public string? Turno { get => _Turno; set { if (RaiseAcceptPendingChange(value, _Turno)) { _Turno = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private long? _Turnoid;
        [XmlAttribute]
        public long? Turnoid { get => _Turnoid; set { if (RaiseAcceptPendingChange(value, _Turnoid)) { _Turnoid = value; OnPropertyChanged(); } } }

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

