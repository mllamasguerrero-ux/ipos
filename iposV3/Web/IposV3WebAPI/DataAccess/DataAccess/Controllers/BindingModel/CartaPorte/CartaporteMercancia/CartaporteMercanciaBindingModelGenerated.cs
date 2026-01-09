
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
    
    public class CartaporteMercanciaBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CartaporteMercanciaBindingModelGenerated()
        {
        }
        public CartaporteMercanciaBindingModelGenerated(CartaporteMercancia item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }


        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

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

        private long? _Cartaporteid;
        [XmlAttribute]
        public long? Cartaporteid { get => _Cartaporteid; set { if (RaiseAcceptPendingChange(value, _Cartaporteid)) { _Cartaporteid = value; OnPropertyChanged(); } } }

        private string? _CartaporteClave;
        [XmlAttribute]
        public string? CartaporteClave { get => _CartaporteClave; set { if (RaiseAcceptPendingChange(value, _CartaporteClave)) { _CartaporteClave = value; OnPropertyChanged(); } } }

        private string? _CartaporteNombre;
        [XmlAttribute]
        public string? CartaporteNombre { get => _CartaporteNombre; set { if (RaiseAcceptPendingChange(value, _CartaporteNombre)) { _CartaporteNombre = value; OnPropertyChanged(); } } }

        private string? _Bienestransp;
        [XmlAttribute]
        public string? Bienestransp { get => _Bienestransp; set { if (RaiseAcceptPendingChange(value, _Bienestransp)) { _Bienestransp = value; OnPropertyChanged(); } } }

        private string? _Clavestcc;
        [XmlAttribute]
        public string? Clavestcc { get => _Clavestcc; set { if (RaiseAcceptPendingChange(value, _Clavestcc)) { _Clavestcc = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Cantidad;
        [XmlAttribute]
        public string? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Claveunidad;
        [XmlAttribute]
        public string? Claveunidad { get => _Claveunidad; set { if (RaiseAcceptPendingChange(value, _Claveunidad)) { _Claveunidad = value; OnPropertyChanged(); } } }

        private string? _Unidad;
        [XmlAttribute]
        public string? Unidad { get => _Unidad; set { if (RaiseAcceptPendingChange(value, _Unidad)) { _Unidad = value; OnPropertyChanged(); } } }

        private string? _Dimensiones;
        [XmlAttribute]
        public string? Dimensiones { get => _Dimensiones; set { if (RaiseAcceptPendingChange(value, _Dimensiones)) { _Dimensiones = value; OnPropertyChanged(); } } }

        private string? _Materialpeligroso;
        [XmlAttribute]
        public string? Materialpeligroso { get => _Materialpeligroso; set { if (RaiseAcceptPendingChange(value, _Materialpeligroso)) { _Materialpeligroso = value; OnPropertyChanged(); } } }

        private string? _Cvematerialpeligroso;
        [XmlAttribute]
        public string? Cvematerialpeligroso { get => _Cvematerialpeligroso; set { if (RaiseAcceptPendingChange(value, _Cvematerialpeligroso)) { _Cvematerialpeligroso = value; OnPropertyChanged(); } } }

        private string? _Embalaje;
        [XmlAttribute]
        public string? Embalaje { get => _Embalaje; set { if (RaiseAcceptPendingChange(value, _Embalaje)) { _Embalaje = value; OnPropertyChanged(); } } }

        private string? _Descripembalaje;
        [XmlAttribute]
        public string? Descripembalaje { get => _Descripembalaje; set { if (RaiseAcceptPendingChange(value, _Descripembalaje)) { _Descripembalaje = value; OnPropertyChanged(); } } }

        private string? _Pesoenkg;
        [XmlAttribute]
        public string? Pesoenkg { get => _Pesoenkg; set { if (RaiseAcceptPendingChange(value, _Pesoenkg)) { _Pesoenkg = value; OnPropertyChanged(); } } }

        private string? _Valormercancia;
        [XmlAttribute]
        public string? Valormercancia { get => _Valormercancia; set { if (RaiseAcceptPendingChange(value, _Valormercancia)) { _Valormercancia = value; OnPropertyChanged(); } } }

        private string? _Moneda;
        [XmlAttribute]
        public string? Moneda { get => _Moneda; set { if (RaiseAcceptPendingChange(value, _Moneda)) { _Moneda = value; OnPropertyChanged(); } } }

        private string? _Fraccionarancelaria;
        [XmlAttribute]
        public string? Fraccionarancelaria { get => _Fraccionarancelaria; set { if (RaiseAcceptPendingChange(value, _Fraccionarancelaria)) { _Fraccionarancelaria = value; OnPropertyChanged(); } } }

        private string? _Uuidcomercioext;
        [XmlAttribute]
        public string? Uuidcomercioext { get => _Uuidcomercioext; set { if (RaiseAcceptPendingChange(value, _Uuidcomercioext)) { _Uuidcomercioext = value; OnPropertyChanged(); } } }

        private string? _Unidadpesomerc;
        [XmlAttribute]
        public string? Unidadpesomerc { get => _Unidadpesomerc; set { if (RaiseAcceptPendingChange(value, _Unidadpesomerc)) { _Unidadpesomerc = value; OnPropertyChanged(); } } }

        private string? _Pesobruto;
        [XmlAttribute]
        public string? Pesobruto { get => _Pesobruto; set { if (RaiseAcceptPendingChange(value, _Pesobruto)) { _Pesobruto = value; OnPropertyChanged(); } } }

        private string? _Pesoneto;
        [XmlAttribute]
        public string? Pesoneto { get => _Pesoneto; set { if (RaiseAcceptPendingChange(value, _Pesoneto)) { _Pesoneto = value; OnPropertyChanged(); } } }

        private string? _Pesotara;
        [XmlAttribute]
        public string? Pesotara { get => _Pesotara; set { if (RaiseAcceptPendingChange(value, _Pesotara)) { _Pesotara = value; OnPropertyChanged(); } } }

        private string? _Numpiezas;
        [XmlAttribute]
        public string? Numpiezas { get => _Numpiezas; set { if (RaiseAcceptPendingChange(value, _Numpiezas)) { _Numpiezas = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""CartaporteMercancia"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Cartaporte.Clave|Cartaporte.Nombre|Bienestransp|Clavestcc|Descripcion|Cantidad|Claveunidad|Unidad|Dimensiones|Materialpeligroso|Cvematerialpeligroso|Embalaje|Descripembalaje|Pesoenkg|Valormercancia|Moneda|Fraccionarancelaria|Uuidcomercioext|Unidadpesomerc|Pesobruto|Pesoneto|Pesotara|Numpiezas";
        }


        public void FillCatalogRelatedFields(CartaporteMercancia item)
        {

             this._CartaporteClave = item.Cartaporte?.Clave;

             this._CartaporteNombre = item.Cartaporte?.Nombre;


        }


        public void FillEntityValues(ref CartaporteMercancia item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Cartaporteid = Cartaporteid ;


            item.Bienestransp = Bienestransp ;


            item.Clavestcc = Clavestcc ;


            item.Descripcion = Descripcion ;


            item.Cantidad = Cantidad ;


            item.Claveunidad = Claveunidad ;


            item.Unidad = Unidad ;


            item.Dimensiones = Dimensiones ;


            item.Materialpeligroso = Materialpeligroso ;


            item.Cvematerialpeligroso = Cvematerialpeligroso ;


            item.Embalaje = Embalaje ;


            item.Descripembalaje = Descripembalaje ;


            item.Pesoenkg = Pesoenkg ;


            item.Valormercancia = Valormercancia ;


            item.Moneda = Moneda ;


            item.Fraccionarancelaria = Fraccionarancelaria ;


            item.Uuidcomercioext = Uuidcomercioext ;


            item.Unidadpesomerc = Unidadpesomerc ;


            item.Pesobruto = Pesobruto ;


            item.Pesoneto = Pesoneto ;


            item.Pesotara = Pesotara ;


            item.Numpiezas = Numpiezas ;



        }

        public void FillFromEntity(CartaporteMercancia item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Cartaporteid = item.Cartaporteid;

            Bienestransp = item.Bienestransp;

            Clavestcc = item.Clavestcc;

            Descripcion = item.Descripcion;

            Cantidad = item.Cantidad;

            Claveunidad = item.Claveunidad;

            Unidad = item.Unidad;

            Dimensiones = item.Dimensiones;

            Materialpeligroso = item.Materialpeligroso;

            Cvematerialpeligroso = item.Cvematerialpeligroso;

            Embalaje = item.Embalaje;

            Descripembalaje = item.Descripembalaje;

            Pesoenkg = item.Pesoenkg;

            Valormercancia = item.Valormercancia;

            Moneda = item.Moneda;

            Fraccionarancelaria = item.Fraccionarancelaria;

            Uuidcomercioext = item.Uuidcomercioext;

            Unidadpesomerc = item.Unidadpesomerc;

            Pesobruto = item.Pesobruto;

            Pesoneto = item.Pesoneto;

            Pesotara = item.Pesotara;

            Numpiezas = item.Numpiezas;


             FillCatalogRelatedFields(item);


        }



    }
}

