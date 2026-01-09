
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
    
    public class EmpresaBindingModelGenerated : Validatable, IBaseGenericBindingModel

    {
        
        public EmpresaBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public EmpresaBindingModelGenerated(Empresa item)
        {
            FillFromEntity(item);
        }

        #endif


        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Rfc;
        [XmlAttribute]
        public string? Rfc { get => _Rfc; set { if (RaiseAcceptPendingChange(value, _Rfc)) { _Rfc = value; OnPropertyChanged(); } } }

        private string? _Telefono;
        [XmlAttribute]
        public string? Telefono { get => _Telefono; set { if (RaiseAcceptPendingChange(value, _Telefono)) { _Telefono = value; OnPropertyChanged(); } } }

        private string? _Fax;
        [XmlAttribute]
        public string? Fax { get => _Fax; set { if (RaiseAcceptPendingChange(value, _Fax)) { _Fax = value; OnPropertyChanged(); } } }

        private string? _Correoe;
        [XmlAttribute]
        public string? Correoe { get => _Correoe; set { if (RaiseAcceptPendingChange(value, _Correoe)) { _Correoe = value; OnPropertyChanged(); } } }

        private string? _Paginaweb;
        [XmlAttribute]
        public string? Paginaweb { get => _Paginaweb; set { if (RaiseAcceptPendingChange(value, _Paginaweb)) { _Paginaweb = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Empresa"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Descripcion|Rfc|Telefono|Fax|Correoe|Paginaweb";
        }


        #if PROYECTO_WEB
         public virtual void FillCatalogRelatedFields(Empresa item)
        {


        }


        public virtual void FillEntityValues(ref Empresa item)
        {


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.Descripcion = Descripcion ;


            item.Rfc = Rfc ;


            item.Telefono = Telefono ;


            item.Fax = Fax ;


            item.Correoe = Correoe ;


            item.Paginaweb = Paginaweb ;



        }

        public virtual void FillFromEntity(Empresa item)
        {

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombre = item.Nombre;

            Descripcion = item.Descripcion;

            Rfc = item.Rfc;

            Telefono = item.Telefono;

            Fax = item.Fax;

            Correoe = item.Correoe;

            Paginaweb = item.Paginaweb;


             FillCatalogRelatedFields(item);


        }
        #endif


       



    }
}

