
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
    public class V_doctopago_aplicadoWFBindingModel : Validatable
    {

        public V_doctopago_aplicadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private int? _Docto_Folio;
        [XmlAttribute]
        public int? Docto_Folio { get => _Docto_Folio; set { if (RaiseAcceptPendingChange(value, _Docto_Folio)) { _Docto_Folio = value; OnPropertyChanged(); } } }

        private string? _Docto_SerieFolioSat;
        [XmlAttribute]
        public string? Docto_SerieFolioSat { get => _Docto_SerieFolioSat; set { if (RaiseAcceptPendingChange(value, _Docto_SerieFolioSat)) { _Docto_SerieFolioSat = value; OnPropertyChanged(); } } }

        private BoolCN? _Esfacturaelectronica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esfacturaelectronica { get => _Esfacturaelectronica?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esfacturaelectronica)) { _Esfacturaelectronica = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Estatimbrado;
        [XmlAttribute]
        public string? Estatimbrado { get => _Estatimbrado; set { if (RaiseAcceptPendingChange(value, _Estatimbrado)) { _Estatimbrado = value; OnPropertyChanged(); } } }

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


        public static V_doctopago_aplicadoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_doctopago_aplicadoWFBindingModel = new V_doctopago_aplicadoWFBindingModel();

        	buffer_V_doctopago_aplicadoWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_doctopago_aplicadoWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_doctopago_aplicadoWFBindingModel._Id = obj.Id;

        	buffer_V_doctopago_aplicadoWFBindingModel._Importe = obj.Importe;

        	buffer_V_doctopago_aplicadoWFBindingModel._Docto_Folio = obj.Docto_Folio;

        	buffer_V_doctopago_aplicadoWFBindingModel._Docto_SerieFolioSat = obj.Docto_SerieFolioSat;

        	buffer_V_doctopago_aplicadoWFBindingModel._Esfacturaelectronica = obj.Esfacturaelectronica;

        	buffer_V_doctopago_aplicadoWFBindingModel._Estatimbrado = obj.Estatimbrado;

            return buffer_V_doctopago_aplicadoWFBindingModel;
        }


    }

    
     
}

