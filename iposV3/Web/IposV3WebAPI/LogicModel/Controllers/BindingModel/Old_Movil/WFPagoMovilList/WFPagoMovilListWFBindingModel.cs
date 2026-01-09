
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
    public class WFPagoMovilListWFBindingModel : Validatable
    {

        public WFPagoMovilListWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbbusqueda;
        [XmlAttribute]
        public string? Tbbusqueda { get => _Tbbusqueda; set { if (RaiseAcceptPendingChange(value, _Tbbusqueda)) { _Tbbusqueda = value; OnPropertyChanged(); } } }

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
    public class WFPagoMovilListWF_PagomovilBindingModel : Validatable
    {

        public WFPagoMovilListWF_PagomovilBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private string? _Verpago;
        [XmlAttribute]
        public string? Verpago { get => _Verpago; set { if (RaiseAcceptPendingChange(value, _Verpago)) { _Verpago = value; OnPropertyChanged(); } } }

        private string? _Dgenviar;
        [XmlAttribute]
        public string? Dgenviar { get => _Dgenviar; set { if (RaiseAcceptPendingChange(value, _Dgenviar)) { _Dgenviar = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Nombreestatus;
        [XmlAttribute]
        public string? Nombreestatus { get => _Nombreestatus; set { if (RaiseAcceptPendingChange(value, _Nombreestatus)) { _Nombreestatus = value; OnPropertyChanged(); } } }

        private string? _Personaclave1;
        [XmlAttribute]
        public string? Personaclave1 { get => _Personaclave1; set { if (RaiseAcceptPendingChange(value, _Personaclave1)) { _Personaclave1 = value; OnPropertyChanged(); } } }

        private string? _Personanombre;
        [XmlAttribute]
        public string? Personanombre { get => _Personanombre; set { if (RaiseAcceptPendingChange(value, _Personanombre)) { _Personanombre = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private string? _Enviadows;
        [XmlAttribute]
        public string? Enviadows { get => _Enviadows; set { if (RaiseAcceptPendingChange(value, _Enviadows)) { _Enviadows = value; OnPropertyChanged(); } } }

        private decimal? _Aplicado;
        [XmlAttribute]
        public decimal? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private long? _Banco;
        [XmlAttribute]
        public long? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Notas;
        [XmlAttribute]
        public string? Notas { get => _Notas; set { if (RaiseAcceptPendingChange(value, _Notas)) { _Notas = value; OnPropertyChanged(); } } }

        private long? _Estatus;
        [XmlAttribute]
        public long? Estatus { get => _Estatus; set { if (RaiseAcceptPendingChange(value, _Estatus)) { _Estatus = value; OnPropertyChanged(); } } }

        private string? _Dgheight;
        [XmlAttribute]
        public string? Dgheight { get => _Dgheight; set { if (RaiseAcceptPendingChange(value, _Dgheight)) { _Dgheight = value; OnPropertyChanged(); } } }

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

