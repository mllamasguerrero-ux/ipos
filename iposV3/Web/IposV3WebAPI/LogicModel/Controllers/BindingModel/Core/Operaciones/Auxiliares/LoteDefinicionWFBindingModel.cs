
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
    public class LoteDefinicionWFBindingModel : Validatable
    {

        public LoteDefinicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _P_id;
        [XmlAttribute]
        public long? P_id { get => _P_id; set { if (RaiseAcceptPendingChange(value, _P_id)) { _P_id = value; OnPropertyChanged(); } } }

        private long? _P_empresaid;
        [XmlAttribute]
        public long? P_empresaid { get => _P_empresaid; set { if (RaiseAcceptPendingChange(value, _P_empresaid)) { _P_empresaid = value; OnPropertyChanged(); } } }

        private long? _P_sucursalid;
        [XmlAttribute]
        public long? P_sucursalid { get => _P_sucursalid; set { if (RaiseAcceptPendingChange(value, _P_sucursalid)) { _P_sucursalid = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

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


        public static LoteDefinicionWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_LoteDefinicionWFBindingModel = new LoteDefinicionWFBindingModel();

        	buffer_LoteDefinicionWFBindingModel._P_id = obj.P_id;

        	buffer_LoteDefinicionWFBindingModel._P_empresaid = obj.P_empresaid;

        	buffer_LoteDefinicionWFBindingModel._P_sucursalid = obj.P_sucursalid;

        	buffer_LoteDefinicionWFBindingModel._Productoid = obj.Productoid;

        	buffer_LoteDefinicionWFBindingModel._Productoclave = obj.Productoclave;

        	buffer_LoteDefinicionWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_LoteDefinicionWFBindingModel._Lote = obj.Lote;

        	buffer_LoteDefinicionWFBindingModel._Fechavence = obj.Fechavence;

            return buffer_LoteDefinicionWFBindingModel;
        }


    }

    
     
}

