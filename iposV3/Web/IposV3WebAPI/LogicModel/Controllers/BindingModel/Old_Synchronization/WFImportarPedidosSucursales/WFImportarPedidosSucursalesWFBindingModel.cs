
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
    public class WFImportarPedidosSucursalesWFBindingModel : Validatable
    {

        public WFImportarPedidosSucursalesWFBindingModel()
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
    public class WFImportarPedidosSucursalesWF_Imp_filesBindingModel : Validatable
    {

        public WFImportarPedidosSucursalesWF_Imp_filesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clavesucursal;
        [XmlAttribute]
        public string? Clavesucursal { get => _Clavesucursal; set { if (RaiseAcceptPendingChange(value, _Clavesucursal)) { _Clavesucursal = value; OnPropertyChanged(); } } }

        private string? _Nombresucursal;
        [XmlAttribute]
        public string? Nombresucursal { get => _Nombresucursal; set { if (RaiseAcceptPendingChange(value, _Nombresucursal)) { _Nombresucursal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Referencias;
        [XmlAttribute]
        public string? Referencias { get => _Referencias; set { if (RaiseAcceptPendingChange(value, _Referencias)) { _Referencias = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Observacion;
        [XmlAttribute]
        public string? Observacion { get => _Observacion; set { if (RaiseAcceptPendingChange(value, _Observacion)) { _Observacion = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Recibir;
        [XmlAttribute]
        public string? Recibir { get => _Recibir; set { if (RaiseAcceptPendingChange(value, _Recibir)) { _Recibir = value; OnPropertyChanged(); } } }

        private string? _Eliminar;
        [XmlAttribute]
        public string? Eliminar { get => _Eliminar; set { if (RaiseAcceptPendingChange(value, _Eliminar)) { _Eliminar = value; OnPropertyChanged(); } } }

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

