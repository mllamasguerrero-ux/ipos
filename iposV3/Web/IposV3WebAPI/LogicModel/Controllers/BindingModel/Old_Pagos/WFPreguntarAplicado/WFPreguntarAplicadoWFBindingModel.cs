
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
    public class WFPreguntarAplicadoWFBindingModel : Validatable
    {

        public WFPreguntarAplicadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaaplicado { get => _Dtpfechaaplicado; set { if (RaiseAcceptPendingChange(value, _Dtpfechaaplicado)) { _Dtpfechaaplicado = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbaplicado;
        [XmlAttribute]
        public BoolCN? Cbaplicado { get => _Cbaplicado; set { if (RaiseAcceptPendingChange(value, _Cbaplicado)) { _Cbaplicado = value; OnPropertyChanged(); } } }

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

