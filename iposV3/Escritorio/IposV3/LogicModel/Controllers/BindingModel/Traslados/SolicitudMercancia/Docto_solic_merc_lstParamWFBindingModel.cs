
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
    public class Docto_solic_merc_lstParamWFBindingModel : Validatable
    {

        public Docto_solic_merc_lstParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _TipoDoctoId;
        [XmlAttribute]
        public long? TipoDoctoId { get => _TipoDoctoId; set { if (RaiseAcceptPendingChange(value, _TipoDoctoId)) { _TipoDoctoId = value; OnPropertyChanged(); } } }

        private long? _SubTipoDoctoId;
        [XmlAttribute]
        public long? SubTipoDoctoId { get => _SubTipoDoctoId; set { if (RaiseAcceptPendingChange(value, _SubTipoDoctoId)) { _SubTipoDoctoId = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _FechaIni;
        [XmlAttribute]
        public DateTimeOffset? FechaIni { get => _FechaIni; set { if (RaiseAcceptPendingChange(value, _FechaIni)) { _FechaIni = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _FechaFin;
        [XmlAttribute]
        public DateTimeOffset? FechaFin { get => _FechaFin; set { if (RaiseAcceptPendingChange(value, _FechaFin)) { _FechaFin = value; OnPropertyChanged(); } } }

        private BoolCS? _SoloPendientes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? SoloPendientes { get => _SoloPendientes?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _SoloPendientes)) { _SoloPendientes = value?? BoolCS.S; OnPropertyChanged(); } } }

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


        public static Docto_solic_merc_lstParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_Docto_solic_merc_lstParamWFBindingModel = new Docto_solic_merc_lstParamWFBindingModel();

        	buffer_Docto_solic_merc_lstParamWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._TipoDoctoId = obj.TipoDoctoId;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._SubTipoDoctoId = obj.SubTipoDoctoId;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._FechaIni = obj.FechaIni;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._FechaFin = obj.FechaFin;

        	buffer_Docto_solic_merc_lstParamWFBindingModel._SoloPendientes = obj.SoloPendientes;

            return buffer_Docto_solic_merc_lstParamWFBindingModel;
        }


    }

    
     
}

