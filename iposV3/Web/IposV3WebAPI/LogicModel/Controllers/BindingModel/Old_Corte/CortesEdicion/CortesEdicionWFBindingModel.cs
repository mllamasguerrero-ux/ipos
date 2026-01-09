
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
    public class CortesEdicionWFBindingModel : Validatable
    {

        public CortesEdicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtfecha { get => _Dtfecha; set { if (RaiseAcceptPendingChange(value, _Dtfecha)) { _Dtfecha = value; OnPropertyChanged(); } } }

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
    public class CortesEdicionWF_CortesdefechaBindingModel : Validatable
    {

        public CortesEdicionWF_CortesdefechaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fechacorte;
        [XmlAttribute]
        public DateTimeOffset? Fechacorte { get => _Fechacorte; set { if (RaiseAcceptPendingChange(value, _Fechacorte)) { _Fechacorte = value; OnPropertyChanged(); } } }

        private string? _Cajeronombre;
        [XmlAttribute]
        public string? Cajeronombre { get => _Cajeronombre; set { if (RaiseAcceptPendingChange(value, _Cajeronombre)) { _Cajeronombre = value; OnPropertyChanged(); } } }

        private decimal? _Saldoinicial;
        [XmlAttribute]
        public decimal? Saldoinicial { get => _Saldoinicial; set { if (RaiseAcceptPendingChange(value, _Saldoinicial)) { _Saldoinicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Inicia;
        [XmlAttribute]
        public DateTimeOffset? Inicia { get => _Inicia; set { if (RaiseAcceptPendingChange(value, _Inicia)) { _Inicia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Termina;
        [XmlAttribute]
        public DateTimeOffset? Termina { get => _Termina; set { if (RaiseAcceptPendingChange(value, _Termina)) { _Termina = value; OnPropertyChanged(); } } }

        private decimal? _Saldofinal;
        [XmlAttribute]
        public decimal? Saldofinal { get => _Saldofinal; set { if (RaiseAcceptPendingChange(value, _Saldofinal)) { _Saldofinal = value; OnPropertyChanged(); } } }

        private decimal? _Saldoreal;
        [XmlAttribute]
        public decimal? Saldoreal { get => _Saldoreal; set { if (RaiseAcceptPendingChange(value, _Saldoreal)) { _Saldoreal = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private string? _Btneditarcorte;
        [XmlAttribute]
        public string? Btneditarcorte { get => _Btneditarcorte; set { if (RaiseAcceptPendingChange(value, _Btneditarcorte)) { _Btneditarcorte = value; OnPropertyChanged(); } } }

        private string? _Btnreporte;
        [XmlAttribute]
        public string? Btnreporte { get => _Btnreporte; set { if (RaiseAcceptPendingChange(value, _Btnreporte)) { _Btnreporte = value; OnPropertyChanged(); } } }

        private string? _Cajerousername;
        [XmlAttribute]
        public string? Cajerousername { get => _Cajerousername; set { if (RaiseAcceptPendingChange(value, _Cajerousername)) { _Cajerousername = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Cajeroid;
        [XmlAttribute]
        public long? Cajeroid { get => _Cajeroid; set { if (RaiseAcceptPendingChange(value, _Cajeroid)) { _Cajeroid = value; OnPropertyChanged(); } } }

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

