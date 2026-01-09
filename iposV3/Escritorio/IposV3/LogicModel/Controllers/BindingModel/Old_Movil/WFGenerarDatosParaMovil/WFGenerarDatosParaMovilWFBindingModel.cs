
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
    public class WFGenerarDatosParaMovilWFBindingModel : Validatable
    {

        public WFGenerarDatosParaMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbandroid;
        [XmlAttribute]
        public BoolCN? Cbandroid { get => _Cbandroid; set { if (RaiseAcceptPendingChange(value, _Cbandroid)) { _Cbandroid = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbexpprodinactivos;
        [XmlAttribute]
        public BoolCN? Cbexpprodinactivos { get => _Cbexpprodinactivos; set { if (RaiseAcceptPendingChange(value, _Cbexpprodinactivos)) { _Cbexpprodinactivos = value; OnPropertyChanged(); } } }

        private long? _Cobradorid;
        [XmlAttribute]
        public long? Cobradorid { get => _Cobradorid; set { if (RaiseAcceptPendingChange(value, _Cobradorid)) { _Cobradorid = value; OnPropertyChanged(); } } }

        private string? _CobradoridClave;
        [XmlAttribute]
        public string? CobradoridClave { get => _CobradoridClave; set { if (RaiseAcceptPendingChange(value, _CobradoridClave)) { _CobradoridClave = value; OnPropertyChanged(); } } }

        private string? _CobradoridNombre;
        [XmlAttribute]
        public string? CobradoridNombre { get => _CobradoridNombre; set { if (RaiseAcceptPendingChange(value, _CobradoridNombre)) { _CobradoridNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

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

