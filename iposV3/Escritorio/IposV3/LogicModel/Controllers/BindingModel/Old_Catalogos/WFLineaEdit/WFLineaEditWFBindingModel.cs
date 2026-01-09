
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
    public class WFLineaEditWFBindingModel : Validatable
    {

        public WFLineaEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Tiporecarga;
        [XmlAttribute]
        public long? Tiporecarga { get => _Tiporecarga; set { if (RaiseAcceptPendingChange(value, _Tiporecarga)) { _Tiporecarga = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicamayoreoxlinea;
        [XmlAttribute]
        public BoolCN? Aplicamayoreoxlinea { get => _Aplicamayoreoxlinea; set { if (RaiseAcceptPendingChange(value, _Aplicamayoreoxlinea)) { _Aplicamayoreoxlinea = value; OnPropertyChanged(); } } }

        private string? _Gpoimp;
        [XmlAttribute]
        public string? Gpoimp { get => _Gpoimp; set { if (RaiseAcceptPendingChange(value, _Gpoimp)) { _Gpoimp = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Acumulapromocion;
        [XmlAttribute]
        public BoolCN? Acumulapromocion { get => _Acumulapromocion; set { if (RaiseAcceptPendingChange(value, _Acumulapromocion)) { _Acumulapromocion = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private string? _TiporecargaClave;
        [XmlAttribute]
        public string? TiporecargaClave { get => _TiporecargaClave; set { if (RaiseAcceptPendingChange(value, _TiporecargaClave)) { _TiporecargaClave = value; OnPropertyChanged(); } } }

        private string? _TiporecargaNombre;
        [XmlAttribute]
        public string? TiporecargaNombre { get => _TiporecargaNombre; set { if (RaiseAcceptPendingChange(value, _TiporecargaNombre)) { _TiporecargaNombre = value; OnPropertyChanged(); } } }

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

