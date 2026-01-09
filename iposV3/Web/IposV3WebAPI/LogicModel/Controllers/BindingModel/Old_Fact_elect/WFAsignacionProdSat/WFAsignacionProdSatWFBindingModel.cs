
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
    public class WFAsignacionProdSatWFBindingModel : Validatable
    {

        public WFAsignacionProdSatWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Checked1;
        [XmlAttribute]
        public long? Checked1 { get => _Checked1; set { if (RaiseAcceptPendingChange(value, _Checked1)) { _Checked1 = value; OnPropertyChanged(); } } }

        private long? _Ddbuscar_lookup;
        [XmlAttribute]
        public long? Ddbuscar_lookup { get => _Ddbuscar_lookup; set { if (RaiseAcceptPendingChange(value, _Ddbuscar_lookup)) { _Ddbuscar_lookup = value; OnPropertyChanged(); } } }

        private long? _Ddoperador_lookup;
        [XmlAttribute]
        public long? Ddoperador_lookup { get => _Ddoperador_lookup; set { if (RaiseAcceptPendingChange(value, _Ddoperador_lookup)) { _Ddoperador_lookup = value; OnPropertyChanged(); } } }

        private string? _Tbvalor_lookup;
        [XmlAttribute]
        public string? Tbvalor_lookup { get => _Tbvalor_lookup; set { if (RaiseAcceptPendingChange(value, _Tbvalor_lookup)) { _Tbvalor_lookup = value; OnPropertyChanged(); } } }

        private long? _Productosat;
        [XmlAttribute]
        public long? Productosat { get => _Productosat; set { if (RaiseAcceptPendingChange(value, _Productosat)) { _Productosat = value; OnPropertyChanged(); } } }

        private string? _ProductosatClave;
        [XmlAttribute]
        public string? ProductosatClave { get => _ProductosatClave; set { if (RaiseAcceptPendingChange(value, _ProductosatClave)) { _ProductosatClave = value; OnPropertyChanged(); } } }

        private string? _ProductosatNombre;
        [XmlAttribute]
        public string? ProductosatNombre { get => _ProductosatNombre; set { if (RaiseAcceptPendingChange(value, _ProductosatNombre)) { _ProductosatNombre = value; OnPropertyChanged(); } } }

        private string? _Checked1Clave;
        [XmlAttribute]
        public string? Checked1Clave { get => _Checked1Clave; set { if (RaiseAcceptPendingChange(value, _Checked1Clave)) { _Checked1Clave = value; OnPropertyChanged(); } } }

        private string? _Checked1Nombre;
        [XmlAttribute]
        public string? Checked1Nombre { get => _Checked1Nombre; set { if (RaiseAcceptPendingChange(value, _Checked1Nombre)) { _Checked1Nombre = value; OnPropertyChanged(); } } }

        private string? _Ddbuscar_lookupClave;
        [XmlAttribute]
        public string? Ddbuscar_lookupClave { get => _Ddbuscar_lookupClave; set { if (RaiseAcceptPendingChange(value, _Ddbuscar_lookupClave)) { _Ddbuscar_lookupClave = value; OnPropertyChanged(); } } }

        private string? _Ddbuscar_lookupNombre;
        [XmlAttribute]
        public string? Ddbuscar_lookupNombre { get => _Ddbuscar_lookupNombre; set { if (RaiseAcceptPendingChange(value, _Ddbuscar_lookupNombre)) { _Ddbuscar_lookupNombre = value; OnPropertyChanged(); } } }

        private string? _Ddoperador_lookupClave;
        [XmlAttribute]
        public string? Ddoperador_lookupClave { get => _Ddoperador_lookupClave; set { if (RaiseAcceptPendingChange(value, _Ddoperador_lookupClave)) { _Ddoperador_lookupClave = value; OnPropertyChanged(); } } }

        private string? _Ddoperador_lookupNombre;
        [XmlAttribute]
        public string? Ddoperador_lookupNombre { get => _Ddoperador_lookupNombre; set { if (RaiseAcceptPendingChange(value, _Ddoperador_lookupNombre)) { _Ddoperador_lookupNombre = value; OnPropertyChanged(); } } }

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
    public class WFAsignacionProdSatWF_1_lookupBindingModel : Validatable
    {

        public WFAsignacionProdSatWF_1_lookupBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Productoid;
        [XmlAttribute]
        public string? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Lineaclave;
        [XmlAttribute]
        public string? Lineaclave { get => _Lineaclave; set { if (RaiseAcceptPendingChange(value, _Lineaclave)) { _Lineaclave = value; OnPropertyChanged(); } } }

        private string? _Lineanombre;
        [XmlAttribute]
        public string? Lineanombre { get => _Lineanombre; set { if (RaiseAcceptPendingChange(value, _Lineanombre)) { _Lineanombre = value; OnPropertyChanged(); } } }

        private string? _Marcaclave;
        [XmlAttribute]
        public string? Marcaclave { get => _Marcaclave; set { if (RaiseAcceptPendingChange(value, _Marcaclave)) { _Marcaclave = value; OnPropertyChanged(); } } }

        private string? _Marcanombre;
        [XmlAttribute]
        public string? Marcanombre { get => _Marcanombre; set { if (RaiseAcceptPendingChange(value, _Marcanombre)) { _Marcanombre = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion1;
        [XmlAttribute]
        public string? Productodescripcion1 { get => _Productodescripcion1; set { if (RaiseAcceptPendingChange(value, _Productodescripcion1)) { _Productodescripcion1 = value; OnPropertyChanged(); } } }

        private string? _Clavesat;
        [XmlAttribute]
        public string? Clavesat { get => _Clavesat; set { if (RaiseAcceptPendingChange(value, _Clavesat)) { _Clavesat = value; OnPropertyChanged(); } } }

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

