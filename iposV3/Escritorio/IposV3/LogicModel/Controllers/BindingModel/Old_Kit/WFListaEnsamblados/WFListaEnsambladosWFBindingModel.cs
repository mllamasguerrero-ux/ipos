
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
    public class WFListaEnsambladosWFBindingModel : Validatable
    {

        public WFListaEnsambladosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechafin;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafin { get => _Dtpfechafin; set { if (RaiseAcceptPendingChange(value, _Dtpfechafin)) { _Dtpfechafin = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicio;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicio { get => _Dtpfechainicio; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicio)) { _Dtpfechainicio = value; OnPropertyChanged(); } } }

        private long? _Cbestatus;
        [XmlAttribute]
        public long? Cbestatus { get => _Cbestatus; set { if (RaiseAcceptPendingChange(value, _Cbestatus)) { _Cbestatus = value; OnPropertyChanged(); } } }

        private string? _CbestatusClave;
        [XmlAttribute]
        public string? CbestatusClave { get => _CbestatusClave; set { if (RaiseAcceptPendingChange(value, _CbestatusClave)) { _CbestatusClave = value; OnPropertyChanged(); } } }

        private string? _CbestatusNombre;
        [XmlAttribute]
        public string? CbestatusNombre { get => _CbestatusNombre; set { if (RaiseAcceptPendingChange(value, _CbestatusNombre)) { _CbestatusNombre = value; OnPropertyChanged(); } } }

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
    public class WFListaEnsambladosWF_EnsamblesBindingModel : Validatable
    {

        public WFListaEnsambladosWF_EnsamblesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

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

