
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
    public class WFSeleccionTipoDescuentoWFBindingModel : Validatable
    {

        public WFSeleccionTipoDescuentoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbtipodescuento;
        [XmlAttribute]
        public long? Cbtipodescuento { get => _Cbtipodescuento; set { if (RaiseAcceptPendingChange(value, _Cbtipodescuento)) { _Cbtipodescuento = value; OnPropertyChanged(); } } }

        private string? _CbtipodescuentoClave;
        [XmlAttribute]
        public string? CbtipodescuentoClave { get => _CbtipodescuentoClave; set { if (RaiseAcceptPendingChange(value, _CbtipodescuentoClave)) { _CbtipodescuentoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipodescuentoNombre;
        [XmlAttribute]
        public string? CbtipodescuentoNombre { get => _CbtipodescuentoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipodescuentoNombre)) { _CbtipodescuentoNombre = value; OnPropertyChanged(); } } }

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

