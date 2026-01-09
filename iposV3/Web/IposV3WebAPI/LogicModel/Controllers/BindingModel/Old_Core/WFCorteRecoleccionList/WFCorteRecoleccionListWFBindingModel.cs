
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
    public class WFCorteRecoleccionListWFBindingModel : Validatable
    {

        public WFCorteRecoleccionListWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechafincorte;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafincorte { get => _Dtpfechafincorte; set { if (RaiseAcceptPendingChange(value, _Dtpfechafincorte)) { _Dtpfechafincorte = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainiciocorte;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainiciocorte { get => _Dtpfechainiciocorte; set { if (RaiseAcceptPendingChange(value, _Dtpfechainiciocorte)) { _Dtpfechainiciocorte = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfechacorte;
        [XmlAttribute]
        public BoolCN? Cbfechacorte { get => _Cbfechacorte; set { if (RaiseAcceptPendingChange(value, _Cbfechacorte)) { _Cbfechacorte = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcajero;
        [XmlAttribute]
        public BoolCN? Cbcajero { get => _Cbcajero; set { if (RaiseAcceptPendingChange(value, _Cbcajero)) { _Cbcajero = value; OnPropertyChanged(); } } }

        private long? _Cajeroclave;
        [XmlAttribute]
        public long? Cajeroclave { get => _Cajeroclave; set { if (RaiseAcceptPendingChange(value, _Cajeroclave)) { _Cajeroclave = value; OnPropertyChanged(); } } }

        private string? _CajeroclaveClave;
        [XmlAttribute]
        public string? CajeroclaveClave { get => _CajeroclaveClave; set { if (RaiseAcceptPendingChange(value, _CajeroclaveClave)) { _CajeroclaveClave = value; OnPropertyChanged(); } } }

        private string? _CajeroclaveNombre;
        [XmlAttribute]
        public string? CajeroclaveNombre { get => _CajeroclaveNombre; set { if (RaiseAcceptPendingChange(value, _CajeroclaveNombre)) { _CajeroclaveNombre = value; OnPropertyChanged(); } } }

        private string? _Tbfoliorecoleccion;
        [XmlAttribute]
        public string? Tbfoliorecoleccion { get => _Tbfoliorecoleccion; set { if (RaiseAcceptPendingChange(value, _Tbfoliorecoleccion)) { _Tbfoliorecoleccion = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfoliorecoleccion;
        [XmlAttribute]
        public BoolCN? Cbfoliorecoleccion { get => _Cbfoliorecoleccion; set { if (RaiseAcceptPendingChange(value, _Cbfoliorecoleccion)) { _Cbfoliorecoleccion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafin;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafin { get => _Dtpfechafin; set { if (RaiseAcceptPendingChange(value, _Dtpfechafin)) { _Dtpfechafin = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicio;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicio { get => _Dtpfechainicio; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicio)) { _Dtpfechainicio = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfecha;
        [XmlAttribute]
        public BoolCN? Cbfecha { get => _Cbfecha; set { if (RaiseAcceptPendingChange(value, _Cbfecha)) { _Cbfecha = value; OnPropertyChanged(); } } }

        private long? _Encargadoclave;
        [XmlAttribute]
        public long? Encargadoclave { get => _Encargadoclave; set { if (RaiseAcceptPendingChange(value, _Encargadoclave)) { _Encargadoclave = value; OnPropertyChanged(); } } }

        private string? _EncargadoclaveClave;
        [XmlAttribute]
        public string? EncargadoclaveClave { get => _EncargadoclaveClave; set { if (RaiseAcceptPendingChange(value, _EncargadoclaveClave)) { _EncargadoclaveClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoclaveNombre;
        [XmlAttribute]
        public string? EncargadoclaveNombre { get => _EncargadoclaveNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoclaveNombre)) { _EncargadoclaveNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbencargado;
        [XmlAttribute]
        public BoolCN? Cbencargado { get => _Cbencargado; set { if (RaiseAcceptPendingChange(value, _Cbencargado)) { _Cbencargado = value; OnPropertyChanged(); } } }

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
    public class WFCorteRecoleccionListWF_CorterecoleccionBindingModel : Validatable
    {

        public WFCorteRecoleccionListWF_CorterecoleccionBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Nombreencargado;
        [XmlAttribute]
        public string? Nombreencargado { get => _Nombreencargado; set { if (RaiseAcceptPendingChange(value, _Nombreencargado)) { _Nombreencargado = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private long? _Encargadoid;
        [XmlAttribute]
        public long? Encargadoid { get => _Encargadoid; set { if (RaiseAcceptPendingChange(value, _Encargadoid)) { _Encargadoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

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

