
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    
    [XmlRoot]
    public class Tmp_dia_monto_porconsolidarWFBindingModel : Validatable
    {

        public Tmp_dia_monto_porconsolidarWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private BoolCN? _Aplicamontomaximo;
        [XmlAttribute]
        public BoolCN? Aplicamontomaximo { get => _Aplicamontomaximo; set { if (RaiseAcceptPendingChange(value, _Aplicamontomaximo)) { _Aplicamontomaximo = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

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


        public static Tmp_dia_monto_porconsolidarWFBindingModel CreateFromAnonymous(Tmp_dia_monto_porconsolidar obj)
        {
            var buffer_Tmp_dia_monto_porconsolidarWFBindingModel = new Tmp_dia_monto_porconsolidarWFBindingModel();

        	buffer_Tmp_dia_monto_porconsolidarWFBindingModel._Fecha = obj.Fecha;

        	buffer_Tmp_dia_monto_porconsolidarWFBindingModel._Aplicamontomaximo = obj.Aplicamontomaximo;

        	buffer_Tmp_dia_monto_porconsolidarWFBindingModel._Monto = obj.Monto;

            return buffer_Tmp_dia_monto_porconsolidarWFBindingModel;
        }


    }

    
     
}

