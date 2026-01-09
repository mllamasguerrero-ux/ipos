
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
    public class WFTipoTransaccionEditWFBindingModel : Validatable
    {

        public WFTipoTransaccionEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sentidoinventario;
        [XmlAttribute]
        public long? Sentidoinventario { get => _Sentidoinventario; set { if (RaiseAcceptPendingChange(value, _Sentidoinventario)) { _Sentidoinventario = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private string? _SentidoinventarioClave;
        [XmlAttribute]
        public string? SentidoinventarioClave { get => _SentidoinventarioClave; set { if (RaiseAcceptPendingChange(value, _SentidoinventarioClave)) { _SentidoinventarioClave = value; OnPropertyChanged(); } } }

        private string? _SentidoinventarioNombre;
        [XmlAttribute]
        public string? SentidoinventarioNombre { get => _SentidoinventarioNombre; set { if (RaiseAcceptPendingChange(value, _SentidoinventarioNombre)) { _SentidoinventarioNombre = value; OnPropertyChanged(); } } }

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

