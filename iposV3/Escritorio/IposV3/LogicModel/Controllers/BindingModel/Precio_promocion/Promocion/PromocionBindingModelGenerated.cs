
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
    
    public class PromocionBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public PromocionBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public PromocionBindingModelGenerated(Promocion item)
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

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Memo;
        [XmlAttribute]
        public string? Memo { get => _Memo; set { if (RaiseAcceptPendingChange(value, _Memo)) { _Memo = value; OnPropertyChanged(); } } }

        private BoolCN? _EsPromocion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? EsPromocion { get => _EsPromocion?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _EsPromocion)) { _EsPromocion = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _ProductoClave;
        [XmlAttribute]
        public string? ProductoClave { get => _ProductoClave; set { if (RaiseAcceptPendingChange(value, _ProductoClave)) { _ProductoClave = value; OnPropertyChanged(); } } }

        private string? _ProductoNombre;
        [XmlAttribute]
        public string? ProductoNombre { get => _ProductoNombre; set { if (RaiseAcceptPendingChange(value, _ProductoNombre)) { _ProductoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Utilidad;
        [XmlAttribute]
        public decimal? Utilidad { get => _Utilidad; set { if (RaiseAcceptPendingChange(value, _Utilidad)) { _Utilidad = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadllevate;
        [XmlAttribute]
        public decimal? Cantidadllevate { get => _Cantidadllevate; set { if (RaiseAcceptPendingChange(value, _Cantidadllevate)) { _Cantidadllevate = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Porcentajedescuento;
        [XmlAttribute]
        public decimal? Porcentajedescuento { get => _Porcentajedescuento; set { if (RaiseAcceptPendingChange(value, _Porcentajedescuento)) { _Porcentajedescuento = value; OnPropertyChanged(); } } }

        private long? _Tipopromocionid;
        [XmlAttribute]
        public long? Tipopromocionid { get => _Tipopromocionid; set { if (RaiseAcceptPendingChange(value, _Tipopromocionid)) { _Tipopromocionid = value; OnPropertyChanged(); } } }

        private string? _TipopromocionClave;
        [XmlAttribute]
        public string? TipopromocionClave { get => _TipopromocionClave; set { if (RaiseAcceptPendingChange(value, _TipopromocionClave)) { _TipopromocionClave = value; OnPropertyChanged(); } } }

        private string? _TipopromocionNombre;
        [XmlAttribute]
        public string? TipopromocionNombre { get => _TipopromocionNombre; set { if (RaiseAcceptPendingChange(value, _TipopromocionNombre)) { _TipopromocionNombre = value; OnPropertyChanged(); } } }

        private long? _Rangopromocionid;
        [XmlAttribute]
        public long? Rangopromocionid { get => _Rangopromocionid; set { if (RaiseAcceptPendingChange(value, _Rangopromocionid)) { _Rangopromocionid = value; OnPropertyChanged(); } } }

        private string? _RangopromocionClave;
        [XmlAttribute]
        public string? RangopromocionClave { get => _RangopromocionClave; set { if (RaiseAcceptPendingChange(value, _RangopromocionClave)) { _RangopromocionClave = value; OnPropertyChanged(); } } }

        private string? _RangopromocionNombre;
        [XmlAttribute]
        public string? RangopromocionNombre { get => _RangopromocionNombre; set { if (RaiseAcceptPendingChange(value, _RangopromocionNombre)) { _RangopromocionNombre = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _LineaClave;
        [XmlAttribute]
        public string? LineaClave { get => _LineaClave; set { if (RaiseAcceptPendingChange(value, _LineaClave)) { _LineaClave = value; OnPropertyChanged(); } } }

        private string? _LineaNombre;
        [XmlAttribute]
        public string? LineaNombre { get => _LineaNombre; set { if (RaiseAcceptPendingChange(value, _LineaNombre)) { _LineaNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechainicio;
        [XmlAttribute]
        public DateTimeOffset? Fechainicio { get => _Fechainicio; set { if (RaiseAcceptPendingChange(value, _Fechainicio)) { _Fechainicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

        private BoolCS? _Lunes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Lunes { get => _Lunes?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Lunes)) { _Lunes = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Martes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Martes { get => _Martes?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Martes)) { _Martes = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Miercoles;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Miercoles { get => _Miercoles?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Miercoles)) { _Miercoles = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Jueves;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Jueves { get => _Jueves?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Jueves)) { _Jueves = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Viernes;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Viernes { get => _Viernes?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Viernes)) { _Viernes = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Sabado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Sabado { get => _Sabado?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Sabado)) { _Sabado = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Domingo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Domingo { get => _Domingo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Domingo)) { _Domingo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private decimal? _Porimporte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Porimporte { get => _Porimporte?? 0; set { if (RaiseAcceptPendingChange(value, _Porimporte)) { _Porimporte = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Enmonedero;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Enmonedero { get => _Enmonedero?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Enmonedero)) { _Enmonedero = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Imagen;
        [XmlAttribute]
        public string? Imagen { get => _Imagen; set { if (RaiseAcceptPendingChange(value, _Imagen)) { _Imagen = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrardatoscliente;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mostrardatoscliente { get => _Mostrardatoscliente?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mostrardatoscliente)) { _Mostrardatoscliente = value?? BoolCN.N; OnPropertyChanged(); } } }


        private BoolCN? _Esmultidetalle;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Esmultidetalle { get => _Esmultidetalle ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Esmultidetalle)) { _Esmultidetalle = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Descmultidetalle;
        [XmlAttribute]
        public string? Descmultidetalle { get => _Descmultidetalle; set { if (RaiseAcceptPendingChange(value, _Descmultidetalle)) { _Descmultidetalle = value; OnPropertyChanged(); } } }


        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Promocion"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Descripcion|Memo|Producto.Clave|Producto.Nombre|Tipopromocion.Clave|Tipopromocion.Nombre|Rangopromocion.Clave|Rangopromocion.Nombre|Linea.Clave|Linea.Nombre|Imagen";
        }


        #if PROYECTO_WEB
        public virtual void FillCatalogRelatedFields(Promocion item)
        {

             this._ProductoClave = item.Producto?.Clave;

             this._ProductoNombre = item.Producto?.Nombre;

             this._TipopromocionClave = item.Tipopromocion?.Clave;

             this._TipopromocionNombre = item.Tipopromocion?.Nombre;

             this._RangopromocionClave = item.Rangopromocion?.Clave;

             this._RangopromocionNombre = item.Rangopromocion?.Nombre;

             this._LineaClave = item.Linea?.Clave;

             this._LineaNombre = item.Linea?.Nombre;


        }


        public virtual void FillEntityValues(ref Promocion item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ;


            item.Nombre = Nombre ;


            item.Descripcion = Descripcion ;


            item.Memo = Memo ;


            item.EsPromocion = EsPromocion ?? BoolCN.N;


            item.Cantidad = Cantidad ;


            item.Productoid = Productoid ;


            item.Utilidad = Utilidad ;


            item.Cantidadllevate = Cantidadllevate ;


            item.Importe = Importe ;


            item.Porcentajedescuento = Porcentajedescuento ;


            item.Tipopromocionid = Tipopromocionid ;


            item.Rangopromocionid = Rangopromocionid ;


            item.Lineaid = Lineaid ;


            item.Fechainicio = Fechainicio ;


            item.Fechafin = Fechafin ;


            item.Lunes = Lunes ?? BoolCS.S;


            item.Martes = Martes ?? BoolCS.S;


            item.Miercoles = Miercoles ?? BoolCS.S;


            item.Jueves = Jueves ?? BoolCS.S;


            item.Viernes = Viernes ?? BoolCS.S;


            item.Sabado = Sabado ?? BoolCS.S;


            item.Domingo = Domingo ?? BoolCS.S;


            item.Porimporte = Porimporte ?? 0;


            item.Enmonedero = Enmonedero ?? BoolCN.N;


            item.Imagen = Imagen ;


            item.Mostrardatoscliente = Mostrardatoscliente ?? BoolCN.N;


            item.Esmultidetalle = Esmultidetalle ?? BoolCN.N;


            item.Descmultidetalle = Descmultidetalle;



        }

        public virtual void FillFromEntity(Promocion item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombre = item.Nombre;

            Descripcion = item.Descripcion;

            Memo = item.Memo;

            EsPromocion = item.EsPromocion;

            Cantidad = item.Cantidad;

            Productoid = item.Productoid;

            Utilidad = item.Utilidad;

            Cantidadllevate = item.Cantidadllevate;

            Importe = item.Importe;

            Porcentajedescuento = item.Porcentajedescuento;

            Tipopromocionid = item.Tipopromocionid;

            Rangopromocionid = item.Rangopromocionid;

            Lineaid = item.Lineaid;

            Fechainicio = item.Fechainicio;

            Fechafin = item.Fechafin;

            Lunes = item.Lunes;

            Martes = item.Martes;

            Miercoles = item.Miercoles;

            Jueves = item.Jueves;

            Viernes = item.Viernes;

            Sabado = item.Sabado;

            Domingo = item.Domingo;

            Porimporte = item.Porimporte;

            Enmonedero = item.Enmonedero;

            Imagen = item.Imagen;

            Mostrardatoscliente = item.Mostrardatoscliente;

            Esmultidetalle = item.Esmultidetalle;

            Descmultidetalle = item.Descmultidetalle;


            FillCatalogRelatedFields(item);


        }
        #endif



    }
}

