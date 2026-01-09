
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
    public class WFPedidosYaExportadosWFBindingModel : Validatable
    {

        public WFPedidosYaExportadosWFBindingModel()
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
    public class WFPedidosYaExportadosWF_PedidosyaexportadosBindingModel : Validatable
    {

        public WFPedidosYaExportadosWF_PedidosyaexportadosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Expfileid;
        [XmlAttribute]
        public long? Expfileid { get => _Expfileid; set { if (RaiseAcceptPendingChange(value, _Expfileid)) { _Expfileid = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaini;
        [XmlAttribute]
        public DateTimeOffset? Fechaini { get => _Fechaini; set { if (RaiseAcceptPendingChange(value, _Fechaini)) { _Fechaini = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

        private string? _Nombrecajero;
        [XmlAttribute]
        public string? Nombrecajero { get => _Nombrecajero; set { if (RaiseAcceptPendingChange(value, _Nombrecajero)) { _Nombrecajero = value; OnPropertyChanged(); } } }

        private string? _Estatuspedido;
        [XmlAttribute]
        public string? Estatuspedido { get => _Estatuspedido; set { if (RaiseAcceptPendingChange(value, _Estatuspedido)) { _Estatuspedido = value; OnPropertyChanged(); } } }

        private string? _Estatus;
        [XmlAttribute]
        public string? Estatus { get => _Estatus; set { if (RaiseAcceptPendingChange(value, _Estatus)) { _Estatus = value; OnPropertyChanged(); } } }

        private string? _Dg_reenviar;
        [XmlAttribute]
        public string? Dg_reenviar { get => _Dg_reenviar; set { if (RaiseAcceptPendingChange(value, _Dg_reenviar)) { _Dg_reenviar = value; OnPropertyChanged(); } } }

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

