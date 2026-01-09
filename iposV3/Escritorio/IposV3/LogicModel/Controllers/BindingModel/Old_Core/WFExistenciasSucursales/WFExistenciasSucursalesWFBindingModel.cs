
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
    public class WFExistenciasSucursalesWFBindingModel : Validatable
    {

        public WFExistenciasSucursalesWFBindingModel()
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
    public class WFExistenciasSucursalesWF_InventariosucursalBindingModel : Validatable
    {

        public WFExistenciasSucursalesWF_InventariosucursalBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private string? _Nombresucursal;
        [XmlAttribute]
        public string? Nombresucursal { get => _Nombresucursal; set { if (RaiseAcceptPendingChange(value, _Nombresucursal)) { _Nombresucursal = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Hora;
        [XmlAttribute]
        public string? Hora { get => _Hora; set { if (RaiseAcceptPendingChange(value, _Hora)) { _Hora = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

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

