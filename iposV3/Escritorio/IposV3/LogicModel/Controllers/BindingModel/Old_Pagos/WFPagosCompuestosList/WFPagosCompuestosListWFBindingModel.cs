
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
    public class WFPagosCompuestosListWFBindingModel : Validatable
    {

        public WFPagosCompuestosListWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbincluircancelaciones;
        [XmlAttribute]
        public BoolCN? Cbincluircancelaciones { get => _Cbincluircancelaciones; set { if (RaiseAcceptPendingChange(value, _Cbincluircancelaciones)) { _Cbincluircancelaciones = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolofiscales;
        [XmlAttribute]
        public BoolCN? Cbsolofiscales { get => _Cbsolofiscales; set { if (RaiseAcceptPendingChange(value, _Cbsolofiscales)) { _Cbsolofiscales = value; OnPropertyChanged(); } } }

        private long? _Aplicadoscombobox;
        [XmlAttribute]
        public long? Aplicadoscombobox { get => _Aplicadoscombobox; set { if (RaiseAcceptPendingChange(value, _Aplicadoscombobox)) { _Aplicadoscombobox = value; OnPropertyChanged(); } } }

        private long? _Formapagocombobox;
        [XmlAttribute]
        public long? Formapagocombobox { get => _Formapagocombobox; set { if (RaiseAcceptPendingChange(value, _Formapagocombobox)) { _Formapagocombobox = value; OnPropertyChanged(); } } }

        private long? _Timbradoscombobox;
        [XmlAttribute]
        public long? Timbradoscombobox { get => _Timbradoscombobox; set { if (RaiseAcceptPendingChange(value, _Timbradoscombobox)) { _Timbradoscombobox = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private string? _AplicadoscomboboxClave;
        [XmlAttribute]
        public string? AplicadoscomboboxClave { get => _AplicadoscomboboxClave; set { if (RaiseAcceptPendingChange(value, _AplicadoscomboboxClave)) { _AplicadoscomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AplicadoscomboboxNombre;
        [XmlAttribute]
        public string? AplicadoscomboboxNombre { get => _AplicadoscomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AplicadoscomboboxNombre)) { _AplicadoscomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxClave;
        [XmlAttribute]
        public string? FormapagocomboboxClave { get => _FormapagocomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxClave)) { _FormapagocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxNombre;
        [XmlAttribute]
        public string? FormapagocomboboxNombre { get => _FormapagocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxNombre)) { _FormapagocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _TimbradoscomboboxClave;
        [XmlAttribute]
        public string? TimbradoscomboboxClave { get => _TimbradoscomboboxClave; set { if (RaiseAcceptPendingChange(value, _TimbradoscomboboxClave)) { _TimbradoscomboboxClave = value; OnPropertyChanged(); } } }

        private string? _TimbradoscomboboxNombre;
        [XmlAttribute]
        public string? TimbradoscomboboxNombre { get => _TimbradoscomboboxNombre; set { if (RaiseAcceptPendingChange(value, _TimbradoscomboboxNombre)) { _TimbradoscomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFPagosCompuestosListWF_PagolistBindingModel : Validatable
    {

        public WFPagosCompuestosListWF_PagolistBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Timbrar;
        [XmlAttribute]
        public string? Timbrar { get => _Timbrar; set { if (RaiseAcceptPendingChange(value, _Timbrar)) { _Timbrar = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private string? _Formapagoclave;
        [XmlAttribute]
        public string? Formapagoclave { get => _Formapagoclave; set { if (RaiseAcceptPendingChange(value, _Formapagoclave)) { _Formapagoclave = value; OnPropertyChanged(); } } }

        private string? _Formapagonombre;
        [XmlAttribute]
        public string? Formapagonombre { get => _Formapagonombre; set { if (RaiseAcceptPendingChange(value, _Formapagonombre)) { _Formapagonombre = value; OnPropertyChanged(); } } }

        private string? _Formapagosatnombre;
        [XmlAttribute]
        public string? Formapagosatnombre { get => _Formapagosatnombre; set { if (RaiseAcceptPendingChange(value, _Formapagosatnombre)) { _Formapagosatnombre = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Banconombre;
        [XmlAttribute]
        public string? Banconombre { get => _Banconombre; set { if (RaiseAcceptPendingChange(value, _Banconombre)) { _Banconombre = value; OnPropertyChanged(); } } }

        private string? _Tipopagoclave;
        [XmlAttribute]
        public string? Tipopagoclave { get => _Tipopagoclave; set { if (RaiseAcceptPendingChange(value, _Tipopagoclave)) { _Tipopagoclave = value; OnPropertyChanged(); } } }

        private string? _Tipopagonombre;
        [XmlAttribute]
        public string? Tipopagonombre { get => _Tipopagonombre; set { if (RaiseAcceptPendingChange(value, _Tipopagonombre)) { _Tipopagonombre = value; OnPropertyChanged(); } } }

        private string? _Timbrado;
        [XmlAttribute]
        public string? Timbrado { get => _Timbrado; set { if (RaiseAcceptPendingChange(value, _Timbrado)) { _Timbrado = value; OnPropertyChanged(); } } }

        private string? _Aplicado;
        [XmlAttribute]
        public string? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private string? _Dgver;
        [XmlAttribute]
        public string? Dgver { get => _Dgver; set { if (RaiseAcceptPendingChange(value, _Dgver)) { _Dgver = value; OnPropertyChanged(); } } }

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

