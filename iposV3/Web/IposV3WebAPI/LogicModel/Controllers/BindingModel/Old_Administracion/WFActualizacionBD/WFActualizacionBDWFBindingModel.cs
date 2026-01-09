
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
    public class WFActualizacionBDWFBindingModel : Validatable
    {

        public WFActualizacionBDWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Txtstateofupdate;
        [XmlAttribute]
        public long? Txtstateofupdate { get => _Txtstateofupdate; set { if (RaiseAcceptPendingChange(value, _Txtstateofupdate)) { _Txtstateofupdate = value; OnPropertyChanged(); } } }

        private string? _TxtstateofupdateClave;
        [XmlAttribute]
        public string? TxtstateofupdateClave { get => _TxtstateofupdateClave; set { if (RaiseAcceptPendingChange(value, _TxtstateofupdateClave)) { _TxtstateofupdateClave = value; OnPropertyChanged(); } } }

        private string? _TxtstateofupdateNombre;
        [XmlAttribute]
        public string? TxtstateofupdateNombre { get => _TxtstateofupdateNombre; set { if (RaiseAcceptPendingChange(value, _TxtstateofupdateNombre)) { _TxtstateofupdateNombre = value; OnPropertyChanged(); } } }

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

