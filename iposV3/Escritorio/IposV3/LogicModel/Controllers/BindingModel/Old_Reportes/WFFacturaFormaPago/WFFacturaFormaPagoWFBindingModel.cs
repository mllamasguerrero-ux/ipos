
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
    public class WFFacturaFormaPagoWFBindingModel : Validatable
    {

        public WFFacturaFormaPagoWFBindingModel()
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
    public class WFFacturaFormaPagoWF_TableBindingModel : Validatable
    {

        public WFFacturaFormaPagoWF_TableBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private long? _Modificadopor_userid;
        [XmlAttribute]
        public long? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Corteid;
        [XmlAttribute]
        public long? Corteid { get => _Corteid; set { if (RaiseAcceptPendingChange(value, _Corteid)) { _Corteid = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Importerecibido;
        [XmlAttribute]
        public decimal? Importerecibido { get => _Importerecibido; set { if (RaiseAcceptPendingChange(value, _Importerecibido)) { _Importerecibido = value; OnPropertyChanged(); } } }

        private decimal? _Importecambio;
        [XmlAttribute]
        public decimal? Importecambio { get => _Importecambio; set { if (RaiseAcceptPendingChange(value, _Importecambio)) { _Importecambio = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

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

