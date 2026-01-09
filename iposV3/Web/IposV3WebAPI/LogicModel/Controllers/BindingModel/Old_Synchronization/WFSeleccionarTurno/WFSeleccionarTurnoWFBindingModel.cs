
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
    public class WFSeleccionarTurnoWFBindingModel : Validatable
    {

        public WFSeleccionarTurnoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbturno;
        [XmlAttribute]
        public long? Cbturno { get => _Cbturno; set { if (RaiseAcceptPendingChange(value, _Cbturno)) { _Cbturno = value; OnPropertyChanged(); } } }

        private string? _CbturnoClave;
        [XmlAttribute]
        public string? CbturnoClave { get => _CbturnoClave; set { if (RaiseAcceptPendingChange(value, _CbturnoClave)) { _CbturnoClave = value; OnPropertyChanged(); } } }

        private string? _CbturnoNombre;
        [XmlAttribute]
        public string? CbturnoNombre { get => _CbturnoNombre; set { if (RaiseAcceptPendingChange(value, _CbturnoNombre)) { _CbturnoNombre = value; OnPropertyChanged(); } } }

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

