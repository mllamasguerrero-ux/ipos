
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
    public class Movto_solic_merc_lstParamWFBindingModel : Validatable
    {

        public Movto_solic_merc_lstParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }

        public Movto_solic_merc_lstParamWFBindingModel(long? empresaId, long? sucursalId, long? doctoId):this()
        {
            this.EmpresaId = empresaId;
            this.SucursalId = sucursalId;
            this.DoctoId = doctoId;
        }



        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _DoctoId;
        [XmlAttribute]
        public long? DoctoId { get => _DoctoId; set { if (RaiseAcceptPendingChange(value, _DoctoId)) { _DoctoId = value; OnPropertyChanged(); } } }

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


        public static Movto_solic_merc_lstParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_Movto_solic_merc_lstParamWFBindingModel = new Movto_solic_merc_lstParamWFBindingModel();

        	buffer_Movto_solic_merc_lstParamWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Movto_solic_merc_lstParamWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Movto_solic_merc_lstParamWFBindingModel._DoctoId = obj.DoctoId;

            return buffer_Movto_solic_merc_lstParamWFBindingModel;
        }


    }

    
     
}

