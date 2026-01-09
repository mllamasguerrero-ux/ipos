
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
    public class Movto_traslado_rec_lstParamWFBindingModel : Validatable
    {

        public Movto_traslado_rec_lstParamWFBindingModel()
        {
            FillCatalogRelatedFields();
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


        public static Movto_traslado_rec_lstParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_Movto_traslado_rec_lstParamWFBindingModel = new Movto_traslado_rec_lstParamWFBindingModel();

        	buffer_Movto_traslado_rec_lstParamWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Movto_traslado_rec_lstParamWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Movto_traslado_rec_lstParamWFBindingModel._DoctoId = obj.DoctoId;

            return buffer_Movto_traslado_rec_lstParamWFBindingModel;
        }


    }

    
     
}

