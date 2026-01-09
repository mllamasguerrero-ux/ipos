
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
    public class WFInformeCatalogoProductosWFBindingModel : Validatable
    {

        public WFInformeCatalogoProductosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbtodosproveedores;
        [XmlAttribute]
        public BoolCN? Cbtodosproveedores { get => _Cbtodosproveedores; set { if (RaiseAcceptPendingChange(value, _Cbtodosproveedores)) { _Cbtodosproveedores = value; OnPropertyChanged(); } } }

        private long? _Proveedor1id;
        [XmlAttribute]
        public long? Proveedor1id { get => _Proveedor1id; set { if (RaiseAcceptPendingChange(value, _Proveedor1id)) { _Proveedor1id = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idClave;
        [XmlAttribute]
        public string? Proveedor1idClave { get => _Proveedor1idClave; set { if (RaiseAcceptPendingChange(value, _Proveedor1idClave)) { _Proveedor1idClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idNombre;
        [XmlAttribute]
        public string? Proveedor1idNombre { get => _Proveedor1idNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1idNombre)) { _Proveedor1idNombre = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _LineaidClave;
        [XmlAttribute]
        public string? LineaidClave { get => _LineaidClave; set { if (RaiseAcceptPendingChange(value, _LineaidClave)) { _LineaidClave = value; OnPropertyChanged(); } } }

        private string? _LineaidNombre;
        [XmlAttribute]
        public string? LineaidNombre { get => _LineaidNombre; set { if (RaiseAcceptPendingChange(value, _LineaidNombre)) { _LineaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodaslineas;
        [XmlAttribute]
        public BoolCN? Cbtodaslineas { get => _Cbtodaslineas; set { if (RaiseAcceptPendingChange(value, _Cbtodaslineas)) { _Cbtodaslineas = value; OnPropertyChanged(); } } }

        private long? _Marcaid;
        [XmlAttribute]
        public long? Marcaid { get => _Marcaid; set { if (RaiseAcceptPendingChange(value, _Marcaid)) { _Marcaid = value; OnPropertyChanged(); } } }

        private string? _MarcaidClave;
        [XmlAttribute]
        public string? MarcaidClave { get => _MarcaidClave; set { if (RaiseAcceptPendingChange(value, _MarcaidClave)) { _MarcaidClave = value; OnPropertyChanged(); } } }

        private string? _MarcaidNombre;
        [XmlAttribute]
        public string? MarcaidNombre { get => _MarcaidNombre; set { if (RaiseAcceptPendingChange(value, _MarcaidNombre)) { _MarcaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodasmarcas;
        [XmlAttribute]
        public BoolCN? Cbtodasmarcas { get => _Cbtodasmarcas; set { if (RaiseAcceptPendingChange(value, _Cbtodasmarcas)) { _Cbtodasmarcas = value; OnPropertyChanged(); } } }

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

