
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
    public class WFPersonaCuentaBancoEditWFBindingModel : Validatable
    {

        public WFPersonaCuentaBancoEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Bancoid;
        [XmlAttribute]
        public long? Bancoid { get => _Bancoid; set { if (RaiseAcceptPendingChange(value, _Bancoid)) { _Bancoid = value; OnPropertyChanged(); } } }

        private string? _BancoidClave;
        [XmlAttribute]
        public string? BancoidClave { get => _BancoidClave; set { if (RaiseAcceptPendingChange(value, _BancoidClave)) { _BancoidClave = value; OnPropertyChanged(); } } }

        private string? _BancoidNombre;
        [XmlAttribute]
        public string? BancoidNombre { get => _BancoidNombre; set { if (RaiseAcceptPendingChange(value, _BancoidNombre)) { _BancoidNombre = value; OnPropertyChanged(); } } }

        private string? _Nocuenta;
        [XmlAttribute]
        public string? Nocuenta { get => _Nocuenta; set { if (RaiseAcceptPendingChange(value, _Nocuenta)) { _Nocuenta = value; OnPropertyChanged(); } } }

        private string? _Id;
        [XmlAttribute]
        public string? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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

