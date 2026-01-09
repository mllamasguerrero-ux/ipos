
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
    public class WFReporteFactCompraSucWFBindingModel : Validatable
    {

        public WFReporteFactCompraSucWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepicker2;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker2 { get => _Datetimepicker2; set { if (RaiseAcceptPendingChange(value, _Datetimepicker2)) { _Datetimepicker2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfecha;
        [XmlAttribute]
        public BoolCN? Cbfecha { get => _Cbfecha; set { if (RaiseAcceptPendingChange(value, _Cbfecha)) { _Cbfecha = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbproveedor;
        [XmlAttribute]
        public BoolCN? Cbproveedor { get => _Cbproveedor; set { if (RaiseAcceptPendingChange(value, _Cbproveedor)) { _Cbproveedor = value; OnPropertyChanged(); } } }

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

