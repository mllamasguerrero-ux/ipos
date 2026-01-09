
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
    public class WFSeleccionParaDevolucionWFBindingModel : Validatable
    {

        public WFSeleccionParaDevolucionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajerostodos;
        [XmlAttribute]
        public BoolCN? Cbcajerostodos { get => _Cbcajerostodos; set { if (RaiseAcceptPendingChange(value, _Cbcajerostodos)) { _Cbcajerostodos = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecha { get => _Dtpfecha; set { if (RaiseAcceptPendingChange(value, _Dtpfecha)) { _Dtpfecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafin;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafin { get => _Dtpfechafin; set { if (RaiseAcceptPendingChange(value, _Dtpfechafin)) { _Dtpfechafin = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolofecha;
        [XmlAttribute]
        public BoolCN? Cbsolofecha { get => _Cbsolofecha; set { if (RaiseAcceptPendingChange(value, _Cbsolofecha)) { _Cbsolofecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcorteactual;
        [XmlAttribute]
        public BoolCN? Cbcorteactual { get => _Cbcorteactual; set { if (RaiseAcceptPendingChange(value, _Cbcorteactual)) { _Cbcorteactual = value; OnPropertyChanged(); } } }

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
    public class WFSeleccionParaDevolucionWF_Transacciones_listaBindingModel : Validatable
    {

        public WFSeleccionParaDevolucionWF_Transacciones_listaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Consecutivo;
        [XmlAttribute]
        public long? Consecutivo { get => _Consecutivo; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private string? _Caja;
        [XmlAttribute]
        public string? Caja { get => _Caja; set { if (RaiseAcceptPendingChange(value, _Caja)) { _Caja = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Clavetipodocto;
        [XmlAttribute]
        public string? Clavetipodocto { get => _Clavetipodocto; set { if (RaiseAcceptPendingChange(value, _Clavetipodocto)) { _Clavetipodocto = value; OnPropertyChanged(); } } }

        private string? _Turno;
        [XmlAttribute]
        public string? Turno { get => _Turno; set { if (RaiseAcceptPendingChange(value, _Turno)) { _Turno = value; OnPropertyChanged(); } } }

        private int? _Referencia1;
        [XmlAttribute]
        public int? Referencia1 { get => _Referencia1; set { if (RaiseAcceptPendingChange(value, _Referencia1)) { _Referencia1 = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Claveestatusdocto;
        [XmlAttribute]
        public string? Claveestatusdocto { get => _Claveestatusdocto; set { if (RaiseAcceptPendingChange(value, _Claveestatusdocto)) { _Claveestatusdocto = value; OnPropertyChanged(); } } }

        private string? _Usuario;
        [XmlAttribute]
        public string? Usuario { get => _Usuario; set { if (RaiseAcceptPendingChange(value, _Usuario)) { _Usuario = value; OnPropertyChanged(); } } }

        private string? _Sucursal;
        [XmlAttribute]
        public string? Sucursal { get => _Sucursal; set { if (RaiseAcceptPendingChange(value, _Sucursal)) { _Sucursal = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private long? _Turnoid;
        [XmlAttribute]
        public long? Turnoid { get => _Turnoid; set { if (RaiseAcceptPendingChange(value, _Turnoid)) { _Turnoid = value; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private string? _Tranregserver;
        [XmlAttribute]
        public string? Tranregserver { get => _Tranregserver; set { if (RaiseAcceptPendingChange(value, _Tranregserver)) { _Tranregserver = value; OnPropertyChanged(); } } }

        private string? _Sucursaldestino;
        [XmlAttribute]
        public string? Sucursaldestino { get => _Sucursaldestino; set { if (RaiseAcceptPendingChange(value, _Sucursaldestino)) { _Sucursaldestino = value; OnPropertyChanged(); } } }

        private string? _Sucursaldestinonombre;
        [XmlAttribute]
        public string? Sucursaldestinonombre { get => _Sucursaldestinonombre; set { if (RaiseAcceptPendingChange(value, _Sucursaldestinonombre)) { _Sucursaldestinonombre = value; OnPropertyChanged(); } } }

        private string? _Persona;
        [XmlAttribute]
        public string? Persona { get => _Persona; set { if (RaiseAcceptPendingChange(value, _Persona)) { _Persona = value; OnPropertyChanged(); } } }

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

