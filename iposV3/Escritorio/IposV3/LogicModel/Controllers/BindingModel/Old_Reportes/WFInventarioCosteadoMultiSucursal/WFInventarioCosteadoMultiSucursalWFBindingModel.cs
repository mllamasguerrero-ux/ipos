
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
    public class WFInventarioCosteadoMultiSucursalWFBindingModel : Validatable
    {

        public WFInventarioCosteadoMultiSucursalWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private string? _PersonaidClave;
        [XmlAttribute]
        public string? PersonaidClave { get => _PersonaidClave; set { if (RaiseAcceptPendingChange(value, _PersonaidClave)) { _PersonaidClave = value; OnPropertyChanged(); } } }

        private string? _PersonaidNombre;
        [XmlAttribute]
        public string? PersonaidNombre { get => _PersonaidNombre; set { if (RaiseAcceptPendingChange(value, _PersonaidNombre)) { _PersonaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosproveedores;
        [XmlAttribute]
        public BoolCN? Cbtodosproveedores { get => _Cbtodosproveedores; set { if (RaiseAcceptPendingChange(value, _Cbtodosproveedores)) { _Cbtodosproveedores = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodaslineas;
        [XmlAttribute]
        public BoolCN? Cbtodaslineas { get => _Cbtodaslineas; set { if (RaiseAcceptPendingChange(value, _Cbtodaslineas)) { _Cbtodaslineas = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

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

