
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
    public class FRptCalcComisionesWFBindingModel : Validatable
    {

        public FRptCalcComisionesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

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

    
    [XmlRoot]
    public class FRptCalcComisionesWF_Calc_comisionesBindingModel : Validatable
    {

        public FRptCalcComisionesWF_Calc_comisionesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Comisionista;
        [XmlAttribute]
        public string? Comisionista { get => _Comisionista; set { if (RaiseAcceptPendingChange(value, _Comisionista)) { _Comisionista = value; OnPropertyChanged(); } } }

        private string? _Turnoclave;
        [XmlAttribute]
        public string? Turnoclave { get => _Turnoclave; set { if (RaiseAcceptPendingChange(value, _Turnoclave)) { _Turnoclave = value; OnPropertyChanged(); } } }

        private decimal? _Comision;
        [XmlAttribute]
        public decimal? Comision { get => _Comision; set { if (RaiseAcceptPendingChange(value, _Comision)) { _Comision = value; OnPropertyChanged(); } } }

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

