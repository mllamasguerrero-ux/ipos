
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
    public class WFSelectEntradaByFolioWFBindingModel : Validatable
    {

        public WFSelectEntradaByFolioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbtipotran;
        [XmlAttribute]
        public long? Cbtipotran { get => _Cbtipotran; set { if (RaiseAcceptPendingChange(value, _Cbtipotran)) { _Cbtipotran = value; OnPropertyChanged(); } } }

        private string? _Tbfolio;
        [XmlAttribute]
        public string? Tbfolio { get => _Tbfolio; set { if (RaiseAcceptPendingChange(value, _Tbfolio)) { _Tbfolio = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

        private string? _SucursalidClave;
        [XmlAttribute]
        public string? SucursalidClave { get => _SucursalidClave; set { if (RaiseAcceptPendingChange(value, _SucursalidClave)) { _SucursalidClave = value; OnPropertyChanged(); } } }

        private string? _SucursalidNombre;
        [XmlAttribute]
        public string? SucursalidNombre { get => _SucursalidNombre; set { if (RaiseAcceptPendingChange(value, _SucursalidNombre)) { _SucursalidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsucursal;
        [XmlAttribute]
        public BoolCN? Cbsucursal { get => _Cbsucursal; set { if (RaiseAcceptPendingChange(value, _Cbsucursal)) { _Cbsucursal = value; OnPropertyChanged(); } } }

        private string? _CbtipotranClave;
        [XmlAttribute]
        public string? CbtipotranClave { get => _CbtipotranClave; set { if (RaiseAcceptPendingChange(value, _CbtipotranClave)) { _CbtipotranClave = value; OnPropertyChanged(); } } }

        private string? _CbtipotranNombre;
        [XmlAttribute]
        public string? CbtipotranNombre { get => _CbtipotranNombre; set { if (RaiseAcceptPendingChange(value, _CbtipotranNombre)) { _CbtipotranNombre = value; OnPropertyChanged(); } } }

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

