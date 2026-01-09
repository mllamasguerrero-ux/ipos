
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
    public class WFProductosListaPreciosWFBindingModel : Validatable
    {

        public WFProductosListaPreciosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbmostrarexistencia;
        [XmlAttribute]
        public BoolCN? Cbmostrarexistencia { get => _Cbmostrarexistencia; set { if (RaiseAcceptPendingChange(value, _Cbmostrarexistencia)) { _Cbmostrarexistencia = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

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

