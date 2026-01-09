
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
    public class WFCancelacionApartadosWFBindingModel : Validatable
    {

        public WFCancelacionApartadosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dpinicio;
        [XmlAttribute]
        public DateTimeOffset? Dpinicio { get => _Dpinicio; set { if (RaiseAcceptPendingChange(value, _Dpinicio)) { _Dpinicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dpfin;
        [XmlAttribute]
        public DateTimeOffset? Dpfin { get => _Dpfin; set { if (RaiseAcceptPendingChange(value, _Dpfin)) { _Dpfin = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodos;
        [XmlAttribute]
        public BoolCN? Cbtodos { get => _Cbtodos; set { if (RaiseAcceptPendingChange(value, _Cbtodos)) { _Cbtodos = value; OnPropertyChanged(); } } }

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
    public class WFCancelacionApartadosWF_ApartadospendientesBindingModel : Validatable
    {

        public WFCancelacionApartadosWF_ApartadospendientesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Check;
        [XmlAttribute]
        public BoolCN? Check { get => _Check; set { if (RaiseAcceptPendingChange(value, _Check)) { _Check = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private string? _Apellidos;
        [XmlAttribute]
        public string? Apellidos { get => _Apellidos; set { if (RaiseAcceptPendingChange(value, _Apellidos)) { _Apellidos = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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

