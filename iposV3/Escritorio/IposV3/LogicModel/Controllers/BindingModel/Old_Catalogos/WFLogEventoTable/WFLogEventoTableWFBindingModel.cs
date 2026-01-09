
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
    public class WFLogEventoTableWFBindingModel : Validatable
    {

        public WFLogEventoTableWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cmbtabletype;
        [XmlAttribute]
        public long? Cmbtabletype { get => _Cmbtabletype; set { if (RaiseAcceptPendingChange(value, _Cmbtabletype)) { _Cmbtabletype = value; OnPropertyChanged(); } } }

        private long? _Txtloguser;
        [XmlAttribute]
        public long? Txtloguser { get => _Txtloguser; set { if (RaiseAcceptPendingChange(value, _Txtloguser)) { _Txtloguser = value; OnPropertyChanged(); } } }

        private string? _TxtloguserClave;
        [XmlAttribute]
        public string? TxtloguserClave { get => _TxtloguserClave; set { if (RaiseAcceptPendingChange(value, _TxtloguserClave)) { _TxtloguserClave = value; OnPropertyChanged(); } } }

        private string? _TxtloguserNombre;
        [XmlAttribute]
        public string? TxtloguserNombre { get => _TxtloguserNombre; set { if (RaiseAcceptPendingChange(value, _TxtloguserNombre)) { _TxtloguserNombre = value; OnPropertyChanged(); } } }

        private long? _Txtlogcliente;
        [XmlAttribute]
        public long? Txtlogcliente { get => _Txtlogcliente; set { if (RaiseAcceptPendingChange(value, _Txtlogcliente)) { _Txtlogcliente = value; OnPropertyChanged(); } } }

        private string? _TxtlogclienteClave;
        [XmlAttribute]
        public string? TxtlogclienteClave { get => _TxtlogclienteClave; set { if (RaiseAcceptPendingChange(value, _TxtlogclienteClave)) { _TxtlogclienteClave = value; OnPropertyChanged(); } } }

        private string? _TxtlogclienteNombre;
        [XmlAttribute]
        public string? TxtlogclienteNombre { get => _TxtlogclienteNombre; set { if (RaiseAcceptPendingChange(value, _TxtlogclienteNombre)) { _TxtlogclienteNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepickerend;
        [XmlAttribute]
        public DateTimeOffset? Datetimepickerend { get => _Datetimepickerend; set { if (RaiseAcceptPendingChange(value, _Datetimepickerend)) { _Datetimepickerend = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepickerbegin;
        [XmlAttribute]
        public DateTimeOffset? Datetimepickerbegin { get => _Datetimepickerbegin; set { if (RaiseAcceptPendingChange(value, _Datetimepickerbegin)) { _Datetimepickerbegin = value; OnPropertyChanged(); } } }

        private string? _CmbtabletypeClave;
        [XmlAttribute]
        public string? CmbtabletypeClave { get => _CmbtabletypeClave; set { if (RaiseAcceptPendingChange(value, _CmbtabletypeClave)) { _CmbtabletypeClave = value; OnPropertyChanged(); } } }

        private string? _CmbtabletypeNombre;
        [XmlAttribute]
        public string? CmbtabletypeNombre { get => _CmbtabletypeNombre; set { if (RaiseAcceptPendingChange(value, _CmbtabletypeNombre)) { _CmbtabletypeNombre = value; OnPropertyChanged(); } } }

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
    public class WFLogEventoTableWF_LogBindingModel : Validatable
    {

        public WFLogEventoTableWF_LogBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Usuario_nombre;
        [XmlAttribute]
        public string? Usuario_nombre { get => _Usuario_nombre; set { if (RaiseAcceptPendingChange(value, _Usuario_nombre)) { _Usuario_nombre = value; OnPropertyChanged(); } } }

        private string? _Tipoeventonombre;
        [XmlAttribute]
        public string? Tipoeventonombre { get => _Tipoeventonombre; set { if (RaiseAcceptPendingChange(value, _Tipoeventonombre)) { _Tipoeventonombre = value; OnPropertyChanged(); } } }

        private string? _Cliente_nombre;
        [XmlAttribute]
        public string? Cliente_nombre { get => _Cliente_nombre; set { if (RaiseAcceptPendingChange(value, _Cliente_nombre)) { _Cliente_nombre = value; OnPropertyChanged(); } } }

        private string? _Nota;
        [XmlAttribute]
        public string? Nota { get => _Nota; set { if (RaiseAcceptPendingChange(value, _Nota)) { _Nota = value; OnPropertyChanged(); } } }

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

