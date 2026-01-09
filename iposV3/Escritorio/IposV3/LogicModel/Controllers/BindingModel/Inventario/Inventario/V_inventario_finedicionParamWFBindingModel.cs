
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
    public class V_inventario_finedicionParamWFBindingModel : Validatable
    {

        public V_inventario_finedicionParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

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


        public static V_inventario_finedicionParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_finedicionParamWFBindingModel = new V_inventario_finedicionParamWFBindingModel();

        	buffer_V_inventario_finedicionParamWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_inventario_finedicionParamWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_inventario_finedicionParamWFBindingModel._Doctoid = obj.Doctoid;

        	buffer_V_inventario_finedicionParamWFBindingModel._Usuarioid = obj.Usuarioid;

            return buffer_V_inventario_finedicionParamWFBindingModel;
        }


    }

    
     
}

