
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
    public class WFProductosXMarcaWFBindingModel : Validatable
    {

        public WFProductosXMarcaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodasitem;
        [XmlAttribute]
        public BoolCN? Cbtodasitem { get => _Cbtodasitem; set { if (RaiseAcceptPendingChange(value, _Cbtodasitem)) { _Cbtodasitem = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmostrarexistencia;
        [XmlAttribute]
        public BoolCN? Cbmostrarexistencia { get => _Cbmostrarexistencia; set { if (RaiseAcceptPendingChange(value, _Cbmostrarexistencia)) { _Cbmostrarexistencia = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidClave;
        [XmlAttribute]
        public string? ListaprecioidClave { get => _ListaprecioidClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioidClave)) { _ListaprecioidClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidNombre;
        [XmlAttribute]
        public string? ListaprecioidNombre { get => _ListaprecioidNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioidNombre)) { _ListaprecioidNombre = value; OnPropertyChanged(); } } }

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

