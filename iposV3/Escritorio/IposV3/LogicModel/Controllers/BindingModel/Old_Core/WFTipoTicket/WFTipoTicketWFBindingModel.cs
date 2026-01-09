
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
    public class WFTipoTicketWFBindingModel : Validatable
    {

        public WFTipoTicketWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Ticketlargo;
        [XmlAttribute]
        public BoolCN? Ticketlargo { get => _Ticketlargo; set { if (RaiseAcceptPendingChange(value, _Ticketlargo)) { _Ticketlargo = value; OnPropertyChanged(); } } }

        private BoolCN? _Ticketlargocotizacion;
        [XmlAttribute]
        public BoolCN? Ticketlargocotizacion { get => _Ticketlargocotizacion; set { if (RaiseAcceptPendingChange(value, _Ticketlargocotizacion)) { _Ticketlargocotizacion = value; OnPropertyChanged(); } } }

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

