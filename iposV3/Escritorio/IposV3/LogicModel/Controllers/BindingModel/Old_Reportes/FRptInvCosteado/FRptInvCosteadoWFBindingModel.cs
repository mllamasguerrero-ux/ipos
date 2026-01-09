
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
    public class FRptInvCosteadoWFBindingModel : Validatable
    {

        public FRptInvCosteadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbproductoinicial;
        [XmlAttribute]
        public string? Tbproductoinicial { get => _Tbproductoinicial; set { if (RaiseAcceptPendingChange(value, _Tbproductoinicial)) { _Tbproductoinicial = value; OnPropertyChanged(); } } }

        private string? _Tbproductofinal;
        [XmlAttribute]
        public string? Tbproductofinal { get => _Tbproductofinal; set { if (RaiseAcceptPendingChange(value, _Tbproductofinal)) { _Tbproductofinal = value; OnPropertyChanged(); } } }

        private long? _Comboboxalmacen;
        [XmlAttribute]
        public long? Comboboxalmacen { get => _Comboboxalmacen; set { if (RaiseAcceptPendingChange(value, _Comboboxalmacen)) { _Comboboxalmacen = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloalmacen;
        [XmlAttribute]
        public BoolCN? Cbsoloalmacen { get => _Cbsoloalmacen; set { if (RaiseAcceptPendingChange(value, _Cbsoloalmacen)) { _Cbsoloalmacen = value; OnPropertyChanged(); } } }

        private string? _ComboboxalmacenClave;
        [XmlAttribute]
        public string? ComboboxalmacenClave { get => _ComboboxalmacenClave; set { if (RaiseAcceptPendingChange(value, _ComboboxalmacenClave)) { _ComboboxalmacenClave = value; OnPropertyChanged(); } } }

        private string? _ComboboxalmacenNombre;
        [XmlAttribute]
        public string? ComboboxalmacenNombre { get => _ComboboxalmacenNombre; set { if (RaiseAcceptPendingChange(value, _ComboboxalmacenNombre)) { _ComboboxalmacenNombre = value; OnPropertyChanged(); } } }

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
    public class FRptInvCosteadoWF_InventariocosteadoBindingModel : Validatable
    {

        public FRptInvCosteadoWF_InventariocosteadoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Linea;
        [XmlAttribute]
        public string? Linea { get => _Linea; set { if (RaiseAcceptPendingChange(value, _Linea)) { _Linea = value; OnPropertyChanged(); } } }

        private string? _Proveedor;
        [XmlAttribute]
        public string? Proveedor { get => _Proveedor; set { if (RaiseAcceptPendingChange(value, _Proveedor)) { _Proveedor = value; OnPropertyChanged(); } } }

        private string? _Almacen;
        [XmlAttribute]
        public string? Almacen { get => _Almacen; set { if (RaiseAcceptPendingChange(value, _Almacen)) { _Almacen = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Costopromedio;
        [XmlAttribute]
        public decimal? Costopromedio { get => _Costopromedio; set { if (RaiseAcceptPendingChange(value, _Costopromedio)) { _Costopromedio = value; OnPropertyChanged(); } } }

        private decimal? _Costoultimo;
        [XmlAttribute]
        public decimal? Costoultimo { get => _Costoultimo; set { if (RaiseAcceptPendingChange(value, _Costoultimo)) { _Costoultimo = value; OnPropertyChanged(); } } }

        private decimal? _Costoreposicion;
        [XmlAttribute]
        public decimal? Costoreposicion { get => _Costoreposicion; set { if (RaiseAcceptPendingChange(value, _Costoreposicion)) { _Costoreposicion = value; OnPropertyChanged(); } } }

        private decimal? _Costopromediototal;
        [XmlAttribute]
        public decimal? Costopromediototal { get => _Costopromediototal; set { if (RaiseAcceptPendingChange(value, _Costopromediototal)) { _Costopromediototal = value; OnPropertyChanged(); } } }

        private decimal? _Costoultimototal;
        [XmlAttribute]
        public decimal? Costoultimototal { get => _Costoultimototal; set { if (RaiseAcceptPendingChange(value, _Costoultimototal)) { _Costoultimototal = value; OnPropertyChanged(); } } }

        private decimal? _Costoreposiciontotal;
        [XmlAttribute]
        public decimal? Costoreposiciontotal { get => _Costoreposiciontotal; set { if (RaiseAcceptPendingChange(value, _Costoreposiciontotal)) { _Costoreposiciontotal = value; OnPropertyChanged(); } } }

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

