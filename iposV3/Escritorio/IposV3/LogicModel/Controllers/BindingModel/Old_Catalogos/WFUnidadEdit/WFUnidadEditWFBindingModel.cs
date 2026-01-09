
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
    public class WFUnidadEditWFBindingModel : Validatable
    {

        public WFUnidadEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Cantidaddecimales;
        [XmlAttribute]
        public int? Cantidaddecimales { get => _Cantidaddecimales; set { if (RaiseAcceptPendingChange(value, _Cantidaddecimales)) { _Cantidaddecimales = value; OnPropertyChanged(); } } }

        private long? _Unidadsatid;
        [XmlAttribute]
        public long? Unidadsatid { get => _Unidadsatid; set { if (RaiseAcceptPendingChange(value, _Unidadsatid)) { _Unidadsatid = value; OnPropertyChanged(); } } }

        private string? _UnidadsatidClave;
        [XmlAttribute]
        public string? UnidadsatidClave { get => _UnidadsatidClave; set { if (RaiseAcceptPendingChange(value, _UnidadsatidClave)) { _UnidadsatidClave = value; OnPropertyChanged(); } } }

        private string? _UnidadsatidNombre;
        [XmlAttribute]
        public string? UnidadsatidNombre { get => _UnidadsatidNombre; set { if (RaiseAcceptPendingChange(value, _UnidadsatidNombre)) { _UnidadsatidNombre = value; OnPropertyChanged(); } } }

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

