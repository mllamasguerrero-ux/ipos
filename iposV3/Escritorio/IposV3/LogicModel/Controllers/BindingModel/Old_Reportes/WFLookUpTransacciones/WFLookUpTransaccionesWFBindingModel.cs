
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
    public class WFLookUpTransaccionesWFBindingModel : Validatable
    {

        public WFLookUpTransaccionesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

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
    public class WFLookUpTransaccionesWF_TransaccioneslistaBindingModel : Validatable
    {

        public WFLookUpTransaccionesWF_TransaccioneslistaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Consecutivo;
        [XmlAttribute]
        public long? Consecutivo { get => _Consecutivo; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value; OnPropertyChanged(); } } }

        private string? _Caja;
        [XmlAttribute]
        public string? Caja { get => _Caja; set { if (RaiseAcceptPendingChange(value, _Caja)) { _Caja = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

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

        private string? _Sucursal;
        [XmlAttribute]
        public string? Sucursal { get => _Sucursal; set { if (RaiseAcceptPendingChange(value, _Sucursal)) { _Sucursal = value; OnPropertyChanged(); } } }

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

