
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
    public class LoteImportadoDefinicionWFBindingModel : Validatable
    {

        public LoteImportadoDefinicionWFBindingModel()
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

        private string? _Pedimento;
        [XmlAttribute]
        public string? Pedimento { get => _Pedimento; set { if (RaiseAcceptPendingChange(value, _Pedimento)) { _Pedimento = value; OnPropertyChanged(); } } }

        private long? _Sataduanaid;
        [XmlAttribute]
        public long? Sataduanaid { get => _Sataduanaid; set { if (RaiseAcceptPendingChange(value, _Sataduanaid)) { _Sataduanaid = value; OnPropertyChanged(); } } }

        private string? _Sataduanaclave;
        [XmlAttribute]
        public string? Sataduanaclave { get => _Sataduanaclave; set { if (RaiseAcceptPendingChange(value, _Sataduanaclave)) { _Sataduanaclave = value; OnPropertyChanged(); } } }

        private string? _Sataduananombre;
        [XmlAttribute]
        public string? Sataduananombre { get => _Sataduananombre; set { if (RaiseAcceptPendingChange(value, _Sataduananombre)) { _Sataduananombre = value; OnPropertyChanged(); } } }

        private decimal? _Tipocambio;
        [XmlAttribute]
        public decimal? Tipocambio { get => _Tipocambio; set { if (RaiseAcceptPendingChange(value, _Tipocambio)) { _Tipocambio = value; OnPropertyChanged(); } } }

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


        public static LoteImportadoDefinicionWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_LoteImportadoDefinicionWFBindingModel = new LoteImportadoDefinicionWFBindingModel();

        	buffer_LoteImportadoDefinicionWFBindingModel._P_id = obj.P_id;

        	buffer_LoteImportadoDefinicionWFBindingModel._P_empresaid = obj.P_empresaid;

        	buffer_LoteImportadoDefinicionWFBindingModel._P_sucursalid = obj.P_sucursalid;

        	buffer_LoteImportadoDefinicionWFBindingModel._Productoid = obj.Productoid;

        	buffer_LoteImportadoDefinicionWFBindingModel._Productoclave = obj.Productoclave;

        	buffer_LoteImportadoDefinicionWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_LoteImportadoDefinicionWFBindingModel._Pedimento = obj.Pedimento;

        	buffer_LoteImportadoDefinicionWFBindingModel._Sataduanaid = obj.Sataduanaid;

        	buffer_LoteImportadoDefinicionWFBindingModel._Sataduanaclave = obj.Sataduanaclave;

        	buffer_LoteImportadoDefinicionWFBindingModel._Sataduananombre = obj.Sataduananombre;

        	buffer_LoteImportadoDefinicionWFBindingModel._Tipocambio = obj.Tipocambio;

        	buffer_LoteImportadoDefinicionWFBindingModel._Fechavence = obj.Fechavence;

            return buffer_LoteImportadoDefinicionWFBindingModel;
        }


    }

    
     
}

