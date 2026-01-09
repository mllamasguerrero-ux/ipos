
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
    public class WFResumenMovilSyncWFBindingModel : Validatable
    {

        public WFResumenMovilSyncWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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
    public class WFResumenMovilSyncWF_EstadosyncBindingModel : Validatable
    {

        public WFResumenMovilSyncWF_EstadosyncBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Hora;
        [XmlAttribute]
        public string? Hora { get => _Hora; set { if (RaiseAcceptPendingChange(value, _Hora)) { _Hora = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Trasladoaftp;
        [XmlAttribute]
        public string? Trasladoaftp { get => _Trasladoaftp; set { if (RaiseAcceptPendingChange(value, _Trasladoaftp)) { _Trasladoaftp = value; OnPropertyChanged(); } } }

        private string? _Tranregserver;
        [XmlAttribute]
        public string? Tranregserver { get => _Tranregserver; set { if (RaiseAcceptPendingChange(value, _Tranregserver)) { _Tranregserver = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private string? _Reenviar;
        [XmlAttribute]
        public string? Reenviar { get => _Reenviar; set { if (RaiseAcceptPendingChange(value, _Reenviar)) { _Reenviar = value; OnPropertyChanged(); } } }

        private string? _Rechecar;
        [XmlAttribute]
        public string? Rechecar { get => _Rechecar; set { if (RaiseAcceptPendingChange(value, _Rechecar)) { _Rechecar = value; OnPropertyChanged(); } } }

        private string? _Verificar;
        [XmlAttribute]
        public string? Verificar { get => _Verificar; set { if (RaiseAcceptPendingChange(value, _Verificar)) { _Verificar = value; OnPropertyChanged(); } } }

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

