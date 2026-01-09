
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
    public class WFExportarCuboWFBindingModel : Validatable
    {

        public WFExportarCuboWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbpersonas;
        [XmlAttribute]
        public BoolCN? Cbpersonas { get => _Cbpersonas; set { if (RaiseAcceptPendingChange(value, _Cbpersonas)) { _Cbpersonas = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpinicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpinicial { get => _Dtpinicial; set { if (RaiseAcceptPendingChange(value, _Dtpinicial)) { _Dtpinicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfinal { get => _Dtpfinal; set { if (RaiseAcceptPendingChange(value, _Dtpfinal)) { _Dtpfinal = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtransacciones;
        [XmlAttribute]
        public BoolCN? Cbtransacciones { get => _Cbtransacciones; set { if (RaiseAcceptPendingChange(value, _Cbtransacciones)) { _Cbtransacciones = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcatalogos;
        [XmlAttribute]
        public BoolCN? Cbcatalogos { get => _Cbcatalogos; set { if (RaiseAcceptPendingChange(value, _Cbcatalogos)) { _Cbcatalogos = value; OnPropertyChanged(); } } }

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

