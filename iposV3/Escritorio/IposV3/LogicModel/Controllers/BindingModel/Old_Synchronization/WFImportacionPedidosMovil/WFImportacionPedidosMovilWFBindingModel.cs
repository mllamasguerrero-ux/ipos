
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
    public class WFImportacionPedidosMovilWFBindingModel : Validatable
    {

        public WFImportacionPedidosMovilWFBindingModel()
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
    public class WFImportacionPedidosMovilWF_Info_pedidos_movilBindingModel : Validatable
    {

        public WFImportacionPedidosMovilWF_Info_pedidos_movilBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Pendientes;
        [XmlAttribute]
        public int? Pendientes { get => _Pendientes; set { if (RaiseAcceptPendingChange(value, _Pendientes)) { _Pendientes = value; OnPropertyChanged(); } } }

        private int? _Enruta;
        [XmlAttribute]
        public int? Enruta { get => _Enruta; set { if (RaiseAcceptPendingChange(value, _Enruta)) { _Enruta = value; OnPropertyChanged(); } } }

        private string? _Visualizar;
        [XmlAttribute]
        public string? Visualizar { get => _Visualizar; set { if (RaiseAcceptPendingChange(value, _Visualizar)) { _Visualizar = value; OnPropertyChanged(); } } }

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

