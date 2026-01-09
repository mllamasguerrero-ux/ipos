
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
    
    public class KitdefinicionBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public KitdefinicionBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public KitdefinicionBindingModelGenerated(Kitdefinicion item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }
        #endif


        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Productokitclave;
        [XmlAttribute]
        public string? Productokitclave { get => _Productokitclave; set { if (RaiseAcceptPendingChange(value, _Productokitclave)) { _Productokitclave = value; OnPropertyChanged(); } } }

        private string? _Productoparteclave;
        [XmlAttribute]
        public string? Productoparteclave { get => _Productoparteclave; set { if (RaiseAcceptPendingChange(value, _Productoparteclave)) { _Productoparteclave = value; OnPropertyChanged(); } } }

        private long? _Productokitid;
        [XmlAttribute]
        public long? Productokitid { get => _Productokitid; set { if (RaiseAcceptPendingChange(value, _Productokitid)) { _Productokitid = value; OnPropertyChanged(); } } }

        private string? _ProductokitClave;
        [XmlAttribute]
        public string? ProductokitClave { get => _ProductokitClave; set { if (RaiseAcceptPendingChange(value, _ProductokitClave)) { _ProductokitClave = value; OnPropertyChanged(); } } }

        private string? _ProductokitNombre;
        [XmlAttribute]
        public string? ProductokitNombre { get => _ProductokitNombre; set { if (RaiseAcceptPendingChange(value, _ProductokitNombre)) { _ProductokitNombre = value; OnPropertyChanged(); } } }

        private long? _Productoparteid;
        [XmlAttribute]
        public long? Productoparteid { get => _Productoparteid; set { if (RaiseAcceptPendingChange(value, _Productoparteid)) { _Productoparteid = value; OnPropertyChanged(); } } }

        private string? _ProductoparteClave;
        [XmlAttribute]
        public string? ProductoparteClave { get => _ProductoparteClave; 
            set { 
                if (RaiseAcceptPendingChange(value, _ProductoparteClave)) { 
                    _ProductoparteClave = value; OnPropertyChanged(); 
                } } }

        private string? _ProductoparteNombre;
        [XmlAttribute]
        public string? ProductoparteNombre { get => _ProductoparteNombre; set { if (RaiseAcceptPendingChange(value, _ProductoparteNombre)) { _ProductoparteNombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidadparte { get => _Cantidadparte?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidadparte)) { _Cantidadparte = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Costoparte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Costoparte { get => _Costoparte?? 0; set { if (RaiseAcceptPendingChange(value, _Costoparte)) { _Costoparte = value?? 0; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Kitdefinicion"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Productokitclave|Productoparteclave|Productokit.Clave|Productokit.Nombre|Productoparte.Clave|Productoparte.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Kitdefinicion item)
        {

             this._ProductokitClave = item.Productokit?.Clave;

             this._ProductokitNombre = item.Productokit?.Nombre;

             this._ProductoparteClave = item.Productoparte?.Clave;

             this._ProductoparteNombre = item.Productoparte?.Nombre;


        }


        public void FillEntityValues(ref Kitdefinicion item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Productokitclave = Productokitclave ;


            item.Productoparteclave = Productoparteclave ;


            item.Productokitid = Productokitid ;


            item.Productoparteid = Productoparteid ;


            item.Cantidadparte = Cantidadparte ?? 0;


            item.Costoparte = Costoparte ?? 0;



        }

        public void FillFromEntity(Kitdefinicion item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Productokitclave = item.Productokitclave;

            Productoparteclave = item.Productoparteclave;

            Productokitid = item.Productokitid;

            Productoparteid = item.Productoparteid;

            Cantidadparte = item.Cantidadparte;

            Costoparte = item.Costoparte;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

