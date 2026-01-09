
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
    public class WFPagosDevolucionesWFBindingModel : Validatable
    {

        public WFPagosDevolucionesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbpagostotalventa;
        [XmlAttribute]
        public string? Tbpagostotalventa { get => _Tbpagostotalventa; set { if (RaiseAcceptPendingChange(value, _Tbpagostotalventa)) { _Tbpagostotalventa = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcreditoautomatico;
        [XmlAttribute]
        public BoolCN? Cbcreditoautomatico { get => _Cbcreditoautomatico; set { if (RaiseAcceptPendingChange(value, _Cbcreditoautomatico)) { _Cbcreditoautomatico = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfacturaelectronica;
        [XmlAttribute]
        public BoolCN? Cbfacturaelectronica { get => _Cbfacturaelectronica; set { if (RaiseAcceptPendingChange(value, _Cbfacturaelectronica)) { _Cbfacturaelectronica = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private string? _Notapago;
        [XmlAttribute]
        public string? Notapago { get => _Notapago; set { if (RaiseAcceptPendingChange(value, _Notapago)) { _Notapago = value; OnPropertyChanged(); } } }

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

