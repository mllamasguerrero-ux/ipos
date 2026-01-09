
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
    public class WFMovilLocalRemoteWFBindingModel : Validatable
    {

        public WFMovilLocalRemoteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Usarconexionlocal;
        [XmlAttribute]
        public BoolCN? Usarconexionlocal { get => _Usarconexionlocal; set { if (RaiseAcceptPendingChange(value, _Usarconexionlocal)) { _Usarconexionlocal = value; OnPropertyChanged(); } } }

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

