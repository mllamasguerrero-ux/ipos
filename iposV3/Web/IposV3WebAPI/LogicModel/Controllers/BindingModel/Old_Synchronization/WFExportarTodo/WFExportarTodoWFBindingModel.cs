
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
    public class WFExportarTodoWFBindingModel : Validatable
    {

        public WFExportarTodoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbincluirapartadostock;
        [XmlAttribute]
        public BoolCN? Cbincluirapartadostock { get => _Cbincluirapartadostock; set { if (RaiseAcceptPendingChange(value, _Cbincluirapartadostock)) { _Cbincluirapartadostock = value; OnPropertyChanged(); } } }

        private long? _Cbtipostock;
        [XmlAttribute]
        public long? Cbtipostock { get => _Cbtipostock; set { if (RaiseAcceptPendingChange(value, _Cbtipostock)) { _Cbtipostock = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datefrom;
        [XmlAttribute]
        public DateTimeOffset? Datefrom { get => _Datefrom; set { if (RaiseAcceptPendingChange(value, _Datefrom)) { _Datefrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dateto;
        [XmlAttribute]
        public DateTimeOffset? Dateto { get => _Dateto; set { if (RaiseAcceptPendingChange(value, _Dateto)) { _Dateto = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbincluirapartado;
        [XmlAttribute]
        public BoolCN? Cbincluirapartado { get => _Cbincluirapartado; set { if (RaiseAcceptPendingChange(value, _Cbincluirapartado)) { _Cbincluirapartado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datedbf;
        [XmlAttribute]
        public DateTimeOffset? Datedbf { get => _Datedbf; set { if (RaiseAcceptPendingChange(value, _Datedbf)) { _Datedbf = value; OnPropertyChanged(); } } }

        private string? _CbtipostockClave;
        [XmlAttribute]
        public string? CbtipostockClave { get => _CbtipostockClave; set { if (RaiseAcceptPendingChange(value, _CbtipostockClave)) { _CbtipostockClave = value; OnPropertyChanged(); } } }

        private string? _CbtipostockNombre;
        [XmlAttribute]
        public string? CbtipostockNombre { get => _CbtipostockNombre; set { if (RaiseAcceptPendingChange(value, _CbtipostockNombre)) { _CbtipostockNombre = value; OnPropertyChanged(); } } }

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

