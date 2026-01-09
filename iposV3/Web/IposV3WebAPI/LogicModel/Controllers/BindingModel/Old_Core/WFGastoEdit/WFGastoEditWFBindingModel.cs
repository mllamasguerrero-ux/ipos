
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
    public class WFGastoEditWFBindingModel : Validatable
    {

        public WFGastoEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cuentaid;
        [XmlAttribute]
        public long? Cuentaid { get => _Cuentaid; set { if (RaiseAcceptPendingChange(value, _Cuentaid)) { _Cuentaid = value; OnPropertyChanged(); } } }

        private string? _CuentaidClave;
        [XmlAttribute]
        public string? CuentaidClave { get => _CuentaidClave; set { if (RaiseAcceptPendingChange(value, _CuentaidClave)) { _CuentaidClave = value; OnPropertyChanged(); } } }

        private string? _CuentaidNombre;
        [XmlAttribute]
        public string? CuentaidNombre { get => _CuentaidNombre; set { if (RaiseAcceptPendingChange(value, _CuentaidNombre)) { _CuentaidNombre = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

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

