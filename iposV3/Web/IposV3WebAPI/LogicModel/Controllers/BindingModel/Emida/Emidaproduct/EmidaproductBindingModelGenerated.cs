
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
    
    public class EmidaproductBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public EmidaproductBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public EmidaproductBindingModelGenerated(Emidaproduct item)
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

        private string? _Productid;
        [XmlAttribute]
        public string? Productid { get => _Productid; set { if (RaiseAcceptPendingChange(value, _Productid)) { _Productid = value; OnPropertyChanged(); } } }

        private string? _Description;
        [XmlAttribute]
        public string? Description { get => _Description; set { if (RaiseAcceptPendingChange(value, _Description)) { _Description = value; OnPropertyChanged(); } } }

        private string? _Shortdescription;
        [XmlAttribute]
        public string? Shortdescription { get => _Shortdescription; set { if (RaiseAcceptPendingChange(value, _Shortdescription)) { _Shortdescription = value; OnPropertyChanged(); } } }

        private string? _Amount;
        [XmlAttribute]
        public string? Amount { get => _Amount; set { if (RaiseAcceptPendingChange(value, _Amount)) { _Amount = value; OnPropertyChanged(); } } }

        private string? _Carrierid;
        [XmlAttribute]
        public string? Carrierid { get => _Carrierid; set { if (RaiseAcceptPendingChange(value, _Carrierid)) { _Carrierid = value; OnPropertyChanged(); } } }

        private string? _Categoryid;
        [XmlAttribute]
        public string? Categoryid { get => _Categoryid; set { if (RaiseAcceptPendingChange(value, _Categoryid)) { _Categoryid = value; OnPropertyChanged(); } } }

        private string? _Transtipoid;
        [XmlAttribute]
        public string? Transtipoid { get => _Transtipoid; set { if (RaiseAcceptPendingChange(value, _Transtipoid)) { _Transtipoid = value; OnPropertyChanged(); } } }

        private string? _Currencycode;
        [XmlAttribute]
        public string? Currencycode { get => _Currencycode; set { if (RaiseAcceptPendingChange(value, _Currencycode)) { _Currencycode = value; OnPropertyChanged(); } } }

        private string? _Currencysymbol;
        [XmlAttribute]
        public string? Currencysymbol { get => _Currencysymbol; set { if (RaiseAcceptPendingChange(value, _Currencysymbol)) { _Currencysymbol = value; OnPropertyChanged(); } } }

        private string? _Discountrate;
        [XmlAttribute]
        public string? Discountrate { get => _Discountrate; set { if (RaiseAcceptPendingChange(value, _Discountrate)) { _Discountrate = value; OnPropertyChanged(); } } }

        private string? _H2hresultcode;
        [XmlAttribute]
        public string? H2hresultcode { get => _H2hresultcode; set { if (RaiseAcceptPendingChange(value, _H2hresultcode)) { _H2hresultcode = value; OnPropertyChanged(); } } }

        private string? _Reference;
        [XmlAttribute]
        public string? Reference { get => _Reference; set { if (RaiseAcceptPendingChange(value, _Reference)) { _Reference = value; OnPropertyChanged(); } } }

        private BoolCN? _Esservicio;
        [XmlAttribute]
        public BoolCN? Esservicio { get => _Esservicio; set { if (RaiseAcceptPendingChange(value, _Esservicio)) { _Esservicio = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Emidaproduct"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Productid|Description|Shortdescription|Amount|Carrierid|Categoryid|Transtipoid|Currencycode|Currencysymbol|Discountrate|H2hresultcode|Reference|Clave|Nombre";
        }



        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Emidaproduct item)
        {


        }


        public void FillEntityValues(ref Emidaproduct item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Productid = Productid ;


            item.Description = Description ;


            item.Shortdescription = Shortdescription ;


            item.Amount = Amount ;


            item.Carrierid = Carrierid ;


            item.Categoryid = Categoryid ;


            item.Transtipoid = Transtipoid ;


            item.Currencycode = Currencycode ;


            item.Currencysymbol = Currencysymbol ;


            item.Discountrate = Discountrate ;


            item.H2hresultcode = H2hresultcode ;


            item.Reference = Reference ;


            item.Esservicio = Esservicio ;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";



        }

        public void FillFromEntity(Emidaproduct item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Productid = item.Productid;

            Description = item.Description;

            Shortdescription = item.Shortdescription;

            Amount = item.Amount;

            Carrierid = item.Carrierid;

            Categoryid = item.Categoryid;

            Transtipoid = item.Transtipoid;

            Currencycode = item.Currencycode;

            Currencysymbol = item.Currencysymbol;

            Discountrate = item.Discountrate;

            H2hresultcode = item.H2hresultcode;

            Reference = item.Reference;

            Esservicio = item.Esservicio;

            Clave = item.Clave;

            Nombre = item.Nombre;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

