
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
    
    public class ProductoBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ProductoBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public ProductoBindingModelGenerated(Producto item)
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
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
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
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Descripcion { get => _Descripcion?? ""; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value?? ""; OnPropertyChanged(); } } }

        private string? _Ean;
        [XmlAttribute]
        public string? Ean { get => _Ean; set { if (RaiseAcceptPendingChange(value, _Ean)) { _Ean = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private string? _Cbarras;
        [XmlAttribute]
        public string? Cbarras { get => _Cbarras; set { if (RaiseAcceptPendingChange(value, _Cbarras)) { _Cbarras = value; OnPropertyChanged(); } } }

        private string? _Cempaque;
        [XmlAttribute]
        public string? Cempaque { get => _Cempaque; set { if (RaiseAcceptPendingChange(value, _Cempaque)) { _Cempaque = value; OnPropertyChanged(); } } }

        private string? _Plug;
        [XmlAttribute]
        public string? Plug { get => _Plug; set { if (RaiseAcceptPendingChange(value, _Plug)) { _Plug = value; OnPropertyChanged(); } } }

        private long? _Proveedor1id;
        [XmlAttribute]
        public long? Proveedor1id { get => _Proveedor1id; set { if (RaiseAcceptPendingChange(value, _Proveedor1id)) { _Proveedor1id = value; OnPropertyChanged(); } } }

        private string? _Proveedor1Clave;
        [XmlAttribute]
        public string? Proveedor1Clave { get => _Proveedor1Clave; set { if (RaiseAcceptPendingChange(value, _Proveedor1Clave)) { _Proveedor1Clave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1Nombre;
        [XmlAttribute]
        public string? Proveedor1Nombre { get => _Proveedor1Nombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1Nombre)) { _Proveedor1Nombre = value; OnPropertyChanged(); } } }

        private long? _Proveedor2id;
        [XmlAttribute]
        public long? Proveedor2id { get => _Proveedor2id; set { if (RaiseAcceptPendingChange(value, _Proveedor2id)) { _Proveedor2id = value; OnPropertyChanged(); } } }

        private string? _Proveedor2Clave;
        [XmlAttribute]
        public string? Proveedor2Clave { get => _Proveedor2Clave; set { if (RaiseAcceptPendingChange(value, _Proveedor2Clave)) { _Proveedor2Clave = value; OnPropertyChanged(); } } }

        private string? _Proveedor2Nombre;
        [XmlAttribute]
        public string? Proveedor2Nombre { get => _Proveedor2Nombre; set { if (RaiseAcceptPendingChange(value, _Proveedor2Nombre)) { _Proveedor2Nombre = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _LineaClave;
        [XmlAttribute]
        public string? LineaClave { get => _LineaClave; set { if (RaiseAcceptPendingChange(value, _LineaClave)) { _LineaClave = value; OnPropertyChanged(); } } }

        private string? _LineaNombre;
        [XmlAttribute]
        public string? LineaNombre { get => _LineaNombre; set { if (RaiseAcceptPendingChange(value, _LineaNombre)) { _LineaNombre = value; OnPropertyChanged(); } } }

        private long? _Marcaid;
        [XmlAttribute]
        public long? Marcaid { get => _Marcaid; set { if (RaiseAcceptPendingChange(value, _Marcaid)) { _Marcaid = value; OnPropertyChanged(); } } }

        private string? _MarcaClave;
        [XmlAttribute]
        public string? MarcaClave { get => _MarcaClave; set { if (RaiseAcceptPendingChange(value, _MarcaClave)) { _MarcaClave = value; OnPropertyChanged(); } } }

        private string? _MarcaNombre;
        [XmlAttribute]
        public string? MarcaNombre { get => _MarcaNombre; set { if (RaiseAcceptPendingChange(value, _MarcaNombre)) { _MarcaNombre = value; OnPropertyChanged(); } } }

        private long? _Unidadid;
        [XmlAttribute]
        public long? Unidadid { get => _Unidadid; set { if (RaiseAcceptPendingChange(value, _Unidadid)) { _Unidadid = value; OnPropertyChanged(); } } }

        private string? _UnidadClave;
        [XmlAttribute]
        public string? UnidadClave { get => _UnidadClave; set { if (RaiseAcceptPendingChange(value, _UnidadClave)) { _UnidadClave = value; OnPropertyChanged(); } } }

        private string? _UnidadNombre;
        [XmlAttribute]
        public string? UnidadNombre { get => _UnidadNombre; set { if (RaiseAcceptPendingChange(value, _UnidadNombre)) { _UnidadNombre = value; OnPropertyChanged(); } } }

        private decimal? _Ivaimpuesto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ivaimpuesto { get => _Ivaimpuesto?? 0; set { if (RaiseAcceptPendingChange(value, _Ivaimpuesto)) { _Ivaimpuesto = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Iepsimpuesto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Iepsimpuesto { get => _Iepsimpuesto?? 0; set { if (RaiseAcceptPendingChange(value, _Iepsimpuesto)) { _Iepsimpuesto = value?? 0; OnPropertyChanged(); } } }



        private decimal? _Impuesto;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Impuesto { get => _Impuesto ?? 0; set { if (RaiseAcceptPendingChange(value, _Impuesto)) { _Impuesto = value ?? 0; OnPropertyChanged(); } } }

        private long? _Substitutoid;
        [XmlAttribute]
        public long? Substitutoid { get => _Substitutoid; set { if (RaiseAcceptPendingChange(value, _Substitutoid)) { _Substitutoid = value; OnPropertyChanged(); } } }

        private string? _SubstitutoClave;
        [XmlAttribute]
        public string? SubstitutoClave { get => _SubstitutoClave; set { if (RaiseAcceptPendingChange(value, _SubstitutoClave)) { _SubstitutoClave = value; OnPropertyChanged(); } } }

        private string? _SubstitutoNombre;
        [XmlAttribute]
        public string? SubstitutoNombre { get => _SubstitutoNombre; set { if (RaiseAcceptPendingChange(value, _SubstitutoNombre)) { _SubstitutoNombre = value; OnPropertyChanged(); } } }


        private string? _Imagen;
        [XmlAttribute]
        public string? Imagen { get => _Imagen; set { if (RaiseAcceptPendingChange(value, _Imagen)) { _Imagen = value; OnPropertyChanged(); } } }


        private decimal? _Producto_apartado_Existenciafacturadoapartado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_apartado_Existenciafacturadoapartado { get => _Producto_apartado_Existenciafacturadoapartado?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_apartado_Existenciafacturadoapartado)) { _Producto_apartado_Existenciafacturadoapartado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_apartado_Existenciaremisionadoapartado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_apartado_Existenciaremisionadoapartado { get => _Producto_apartado_Existenciaremisionadoapartado?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_apartado_Existenciaremisionadoapartado)) { _Producto_apartado_Existenciaremisionadoapartado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_apartado_Existenciaindefinidoapartado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_apartado_Existenciaindefinidoapartado { get => _Producto_apartado_Existenciaindefinidoapartado?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_apartado_Existenciaindefinidoapartado)) { _Producto_apartado_Existenciaindefinidoapartado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_apartado_Existenciaapartado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_apartado_Existenciaapartado { get => _Producto_apartado_Existenciaapartado?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_apartado_Existenciaapartado)) { _Producto_apartado_Existenciaapartado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_comision_Comision;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_comision_Comision { get => _Producto_comision_Comision?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_comision_Comision)) { _Producto_comision_Comision = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Producto_comodin_Descripcion_comodin;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_comodin_Descripcion_comodin { get => _Producto_comodin_Descripcion_comodin?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_comodin_Descripcion_comodin)) { _Producto_comodin_Descripcion_comodin = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_loteimportado_Loteimportadoaplicado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_loteimportado_Loteimportadoaplicado { get => _Producto_loteimportado_Loteimportadoaplicado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_loteimportado_Loteimportadoaplicado)) { _Producto_loteimportado_Loteimportadoaplicado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_loteimportado_Manejaloteimportado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_loteimportado_Manejaloteimportado { get => _Producto_loteimportado_Manejaloteimportado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_loteimportado_Manejaloteimportado)) { _Producto_loteimportado_Manejaloteimportado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Producto_emida_Emidaid;
        [XmlAttribute]
        public string? Producto_emida_Emidaid { get => _Producto_emida_Emidaid; set { if (RaiseAcceptPendingChange(value, _Producto_emida_Emidaid)) { _Producto_emida_Emidaid = value; OnPropertyChanged(); } } }

        private long? _Producto_emida_Emidaproductoid;
        [XmlAttribute]
        public long? Producto_emida_Emidaproductoid { get => _Producto_emida_Emidaproductoid; set { if (RaiseAcceptPendingChange(value, _Producto_emida_Emidaproductoid)) { _Producto_emida_Emidaproductoid = value; OnPropertyChanged(); } } }

        private string? _Producto_emida_EmidaproductoClave;
        [XmlAttribute]
        public string? Producto_emida_EmidaproductoClave { get => _Producto_emida_EmidaproductoClave; set { if (RaiseAcceptPendingChange(value, _Producto_emida_EmidaproductoClave)) { _Producto_emida_EmidaproductoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_emida_EmidaproductoNombre;
        [XmlAttribute]
        public string? Producto_emida_EmidaproductoNombre { get => _Producto_emida_EmidaproductoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_emida_EmidaproductoNombre)) { _Producto_emida_EmidaproductoNombre = value; OnPropertyChanged(); } } }

        private long? _Producto_fact_elect_Sat_productoservicioid;
        [XmlAttribute]
        public long? Producto_fact_elect_Sat_productoservicioid { get => _Producto_fact_elect_Sat_productoservicioid; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_productoservicioid)) { _Producto_fact_elect_Sat_productoservicioid = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_productoservicioClave;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_productoservicioClave { get => _Producto_fact_elect_Sat_productoservicioClave; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_productoservicioClave)) { _Producto_fact_elect_Sat_productoservicioClave = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_productoservicioNombre;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_productoservicioNombre { get => _Producto_fact_elect_Sat_productoservicioNombre; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_productoservicioNombre)) { _Producto_fact_elect_Sat_productoservicioNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Producto_fact_elect_Generacomprobtrasl;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_fact_elect_Generacomprobtrasl { get => _Producto_fact_elect_Generacomprobtrasl?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Generacomprobtrasl)) { _Producto_fact_elect_Generacomprobtrasl = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_fact_elect_Generacartaporte;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_fact_elect_Generacartaporte { get => _Producto_fact_elect_Generacartaporte?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Generacartaporte)) { _Producto_fact_elect_Generacartaporte = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Producto_fact_elect_Sat_Tipoembalajeid;
        [XmlAttribute]
        public long? Producto_fact_elect_Sat_Tipoembalajeid { get => _Producto_fact_elect_Sat_Tipoembalajeid; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_Tipoembalajeid)) { _Producto_fact_elect_Sat_Tipoembalajeid = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_TipoembalajeClave;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_TipoembalajeClave { get => _Producto_fact_elect_Sat_TipoembalajeClave; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_TipoembalajeClave)) { _Producto_fact_elect_Sat_TipoembalajeClave = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_TipoembalajeNombre;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_TipoembalajeNombre { get => _Producto_fact_elect_Sat_TipoembalajeNombre; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_TipoembalajeNombre)) { _Producto_fact_elect_Sat_TipoembalajeNombre = value; OnPropertyChanged(); } } }

        private long? _Producto_fact_elect_Sat_Claveunidadpesoid;
        [XmlAttribute]
        public long? Producto_fact_elect_Sat_Claveunidadpesoid { get => _Producto_fact_elect_Sat_Claveunidadpesoid; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_Claveunidadpesoid)) { _Producto_fact_elect_Sat_Claveunidadpesoid = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_ClaveunidadpesoClave;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_ClaveunidadpesoClave { get => _Producto_fact_elect_Sat_ClaveunidadpesoClave; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_ClaveunidadpesoClave)) { _Producto_fact_elect_Sat_ClaveunidadpesoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_ClaveunidadpesoNombre;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_ClaveunidadpesoNombre { get => _Producto_fact_elect_Sat_ClaveunidadpesoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_ClaveunidadpesoNombre)) { _Producto_fact_elect_Sat_ClaveunidadpesoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Producto_fact_elect_Peso;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_fact_elect_Peso { get => _Producto_fact_elect_Peso?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Peso)) { _Producto_fact_elect_Peso = value?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Producto_fact_elect_Espeligroso;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_fact_elect_Espeligroso { get => _Producto_fact_elect_Espeligroso?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Espeligroso)) { _Producto_fact_elect_Espeligroso = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Producto_fact_elect_Sat_Matpeligrosoid;
        [XmlAttribute]
        public long? Producto_fact_elect_Sat_Matpeligrosoid { get => _Producto_fact_elect_Sat_Matpeligrosoid; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_Matpeligrosoid)) { _Producto_fact_elect_Sat_Matpeligrosoid = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_MatpeligrosoClave;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_MatpeligrosoClave { get => _Producto_fact_elect_Sat_MatpeligrosoClave; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_MatpeligrosoClave)) { _Producto_fact_elect_Sat_MatpeligrosoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_fact_elect_Sat_MatpeligrosoNombre;
        [XmlAttribute]
        public string? Producto_fact_elect_Sat_MatpeligrosoNombre { get => _Producto_fact_elect_Sat_MatpeligrosoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_fact_elect_Sat_MatpeligrosoNombre)) { _Producto_fact_elect_Sat_MatpeligrosoNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Producto_farmacia_Requierereceta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_farmacia_Requierereceta { get => _Producto_farmacia_Requierereceta?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_farmacia_Requierereceta)) { _Producto_farmacia_Requierereceta = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Producto_existencia_Existencia;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_existencia_Existencia { get => _Producto_existencia_Existencia?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_existencia_Existencia)) { _Producto_existencia_Existencia = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_existencia_Enprocesodesalida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_existencia_Enprocesodesalida { get => _Producto_existencia_Enprocesodesalida?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_existencia_Enprocesodesalida)) { _Producto_existencia_Enprocesodesalida = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Producto_existencia_Ultimocambioexistencia;
        [XmlAttribute]
        public DateTimeOffset? Producto_existencia_Ultimocambioexistencia { get => _Producto_existencia_Ultimocambioexistencia; set { if (RaiseAcceptPendingChange(value, _Producto_existencia_Ultimocambioexistencia)) { _Producto_existencia_Ultimocambioexistencia = value; OnPropertyChanged(); } } }

        private BoolCS? _Producto_inventario_Inventariable;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Producto_inventario_Inventariable { get => _Producto_inventario_Inventariable?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Inventariable)) { _Producto_inventario_Inventariable = value?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCN? _Producto_inventario_Negativos;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_inventario_Negativos { get => _Producto_inventario_Negativos?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Negativos)) { _Producto_inventario_Negativos = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_inventario_Manejastock;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_inventario_Manejastock { get => _Producto_inventario_Manejastock?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Manejastock)) { _Producto_inventario_Manejastock = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_inventario_Surtirporcaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_inventario_Surtirporcaja { get => _Producto_inventario_Surtirporcaja?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Surtirporcaja)) { _Producto_inventario_Surtirporcaja = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_inventario_Manejalote;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_inventario_Manejalote { get => _Producto_inventario_Manejalote?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Manejalote)) { _Producto_inventario_Manejalote = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Stock;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Stock { get => _Producto_inventario_Stock?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Stock)) { _Producto_inventario_Stock = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Stockmax;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Stockmax { get => _Producto_inventario_Stockmax?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Stockmax)) { _Producto_inventario_Stockmax = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Stockmincaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Stockmincaja { get => _Producto_inventario_Stockmincaja?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Stockmincaja)) { _Producto_inventario_Stockmincaja = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Stockmaxcaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Stockmaxcaja { get => _Producto_inventario_Stockmaxcaja?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Stockmaxcaja)) { _Producto_inventario_Stockmaxcaja = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Stockminpieza;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Stockminpieza { get => _Producto_inventario_Stockminpieza?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Stockminpieza)) { _Producto_inventario_Stockminpieza = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Stockmaxpieza;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Stockmaxpieza { get => _Producto_inventario_Stockmaxpieza?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Stockmaxpieza)) { _Producto_inventario_Stockmaxpieza = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Pzacaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Pzacaja { get => _Producto_inventario_Pzacaja?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Pzacaja)) { _Producto_inventario_Pzacaja = value?? 0; OnPropertyChanged(); } } }


        private decimal? _Producto_inventario_U_empaque;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_U_empaque { get => _Producto_inventario_U_empaque ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_U_empaque)) { _Producto_inventario_U_empaque = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_inventario_Cantxpieza;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_inventario_Cantxpieza { get => _Producto_inventario_Cantxpieza ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Cantxpieza)) { _Producto_inventario_Cantxpieza = value ?? 0; OnPropertyChanged(); } } }


        private BoolCN? _Producto_kit_Eskit;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_kit_Eskit { get => _Producto_kit_Eskit?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_kit_Eskit)) { _Producto_kit_Eskit = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_kit_Kittienevig;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_kit_Kittienevig { get => _Producto_kit_Kittienevig?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_kit_Kittienevig)) { _Producto_kit_Kittienevig = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_kit_Kitimpfijo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_kit_Kitimpfijo { get => _Producto_kit_Kitimpfijo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_kit_Kitimpfijo)) { _Producto_kit_Kitimpfijo = value?? BoolCN.N; OnPropertyChanged(); } } }


        private BoolCN? _Producto_kit_Valxsuc;
        [XmlAttribute]
        public BoolCN? Producto_kit_Valxsuc { get => _Producto_kit_Valxsuc; set { if (RaiseAcceptPendingChange(value, _Producto_kit_Valxsuc)) { _Producto_kit_Valxsuc = value; OnPropertyChanged(); } } }


        private decimal? _Producto_kit_Enprocesopartessalida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_kit_Enprocesopartessalida { get => _Producto_kit_Enprocesopartessalida?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_kit_Enprocesopartessalida)) { _Producto_kit_Enprocesopartessalida = value?? 0; OnPropertyChanged(); } } }

        private DateTimeOffset? _Producto_kit_Vigenciaprodkit;
        [XmlAttribute]
        public DateTimeOffset? Producto_kit_Vigenciaprodkit { get => _Producto_kit_Vigenciaprodkit; set { if (RaiseAcceptPendingChange(value, _Producto_kit_Vigenciaprodkit)) { _Producto_kit_Vigenciaprodkit = value; OnPropertyChanged(); } } }

        private decimal? _Producto_origenfiscal_Existenciafacturado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_origenfiscal_Existenciafacturado { get => _Producto_origenfiscal_Existenciafacturado?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Existenciafacturado)) { _Producto_origenfiscal_Existenciafacturado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_origenfiscal_Existenciaremisionado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_origenfiscal_Existenciaremisionado { get => _Producto_origenfiscal_Existenciaremisionado?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Existenciaremisionado)) { _Producto_origenfiscal_Existenciaremisionado = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_origenfiscal_Existenciaindefinido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_origenfiscal_Existenciaindefinido { get => _Producto_origenfiscal_Existenciaindefinido?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Existenciaindefinido)) { _Producto_origenfiscal_Existenciaindefinido = value?? 0; OnPropertyChanged(); } } }

        private long? _Producto_origenfiscal_Ultimoorigenfiscalventa;
        [XmlAttribute]
        public long? Producto_origenfiscal_Ultimoorigenfiscalventa { get => _Producto_origenfiscal_Ultimoorigenfiscalventa; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Ultimoorigenfiscalventa)) { _Producto_origenfiscal_Ultimoorigenfiscalventa = value; OnPropertyChanged(); } } }

        private string? _Producto_origenfiscal_Ultimoorigenfiscalventa_Clave;
        [XmlAttribute]
        public string? Producto_origenfiscal_Ultimoorigenfiscalventa_Clave { get => _Producto_origenfiscal_Ultimoorigenfiscalventa_Clave; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Ultimoorigenfiscalventa_Clave)) { _Producto_origenfiscal_Ultimoorigenfiscalventa_Clave = value; OnPropertyChanged(); } } }

        private string? _Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre;
        [XmlAttribute]
        public string? Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre { get => _Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre)) { _Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Producto_origenfiscal_Exist_fac_intercambio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_origenfiscal_Exist_fac_intercambio { get => _Producto_origenfiscal_Exist_fac_intercambio?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_origenfiscal_Exist_fac_intercambio)) { _Producto_origenfiscal_Exist_fac_intercambio = value?? 0; OnPropertyChanged(); } } }

        private long? _Producto_poliza_Plazoid;
        [XmlAttribute]
        public long? Producto_poliza_Plazoid { get => _Producto_poliza_Plazoid; set { if (RaiseAcceptPendingChange(value, _Producto_poliza_Plazoid)) { _Producto_poliza_Plazoid = value; OnPropertyChanged(); } } }

        private string? _Producto_poliza_PlazoClave;
        [XmlAttribute]
        public string? Producto_poliza_PlazoClave { get => _Producto_poliza_PlazoClave; set { if (RaiseAcceptPendingChange(value, _Producto_poliza_PlazoClave)) { _Producto_poliza_PlazoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_poliza_PlazoNombre;
        [XmlAttribute]
        public string? Producto_poliza_PlazoNombre { get => _Producto_poliza_PlazoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_poliza_PlazoNombre)) { _Producto_poliza_PlazoNombre = value; OnPropertyChanged(); } } }


        private string? _Producto_poliza_Cuentapredial;
        [XmlAttribute]
        public string? Producto_poliza_Cuentapredial { get => _Producto_poliza_Cuentapredial; set { if (RaiseAcceptPendingChange(value, _Producto_poliza_Cuentapredial)) { _Producto_poliza_Cuentapredial = value; OnPropertyChanged(); } } }


        private BoolCN? _Producto_precios_Mayokgs;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_precios_Mayokgs { get => _Producto_precios_Mayokgs?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Mayokgs)) { _Producto_precios_Mayokgs = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_precios_Tipoabc;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_precios_Tipoabc { get => _Producto_precios_Tipoabc?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Tipoabc)) { _Producto_precios_Tipoabc = value?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio1;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio1 { get => _Producto_precios_Precio1?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio1)) { _Producto_precios_Precio1 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio2;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio2 { get => _Producto_precios_Precio2?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio2)) { _Producto_precios_Precio2 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio3;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio3 { get => _Producto_precios_Precio3?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio3)) { _Producto_precios_Precio3 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio4;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio4 { get => _Producto_precios_Precio4?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio4)) { _Producto_precios_Precio4 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio5;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio5 { get => _Producto_precios_Precio5?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio5)) { _Producto_precios_Precio5 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio6;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio6 { get => _Producto_precios_Precio6?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio6)) { _Producto_precios_Precio6 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costoultimo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costoultimo { get => _Producto_precios_Costoultimo?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costoultimo)) { _Producto_precios_Costoultimo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costopromedio;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costopromedio { get => _Producto_precios_Costopromedio?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costopromedio)) { _Producto_precios_Costopromedio = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costorepo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costorepo { get => _Producto_precios_Costorepo?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costorepo)) { _Producto_precios_Costorepo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio1;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio1 { get => _Producto_precios_Superprecio1; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio1)) { _Producto_precios_Superprecio1 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio2;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio2 { get => _Producto_precios_Superprecio2; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio2)) { _Producto_precios_Superprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio3;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio3 { get => _Producto_precios_Superprecio3; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio3)) { _Producto_precios_Superprecio3 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio4;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio4 { get => _Producto_precios_Superprecio4; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio4)) { _Producto_precios_Superprecio4 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio5;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio5 { get => _Producto_precios_Superprecio5; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio5)) { _Producto_precios_Superprecio5 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Ini_mayo;
        [XmlAttribute]
        public decimal? Producto_precios_Ini_mayo { get => _Producto_precios_Ini_mayo; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Ini_mayo)) { _Producto_precios_Ini_mayo = value; OnPropertyChanged(); } } }

        private long? _Producto_precios_Listaprecmediomayid;
        [XmlAttribute]
        public long? Producto_precios_Listaprecmediomayid { get => _Producto_precios_Listaprecmediomayid; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Listaprecmediomayid)) { _Producto_precios_Listaprecmediomayid = value; OnPropertyChanged(); } } }

        private string? _Producto_precios_ListaprecmediomayClave;
        [XmlAttribute]
        public string? Producto_precios_ListaprecmediomayClave { get => _Producto_precios_ListaprecmediomayClave; set { if (RaiseAcceptPendingChange(value, _Producto_precios_ListaprecmediomayClave)) { _Producto_precios_ListaprecmediomayClave = value; OnPropertyChanged(); } } }

        private string? _Producto_precios_ListaprecmediomayNombre;
        [XmlAttribute]
        public string? Producto_precios_ListaprecmediomayNombre { get => _Producto_precios_ListaprecmediomayNombre; set { if (RaiseAcceptPendingChange(value, _Producto_precios_ListaprecmediomayNombre)) { _Producto_precios_ListaprecmediomayNombre = value; OnPropertyChanged(); } } }

        private long? _Producto_precios_Listaprecmayoreoid;
        [XmlAttribute]
        public long? Producto_precios_Listaprecmayoreoid { get => _Producto_precios_Listaprecmayoreoid; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Listaprecmayoreoid)) { _Producto_precios_Listaprecmayoreoid = value; OnPropertyChanged(); } } }

        private string? _Producto_precios_ListaprecmayoreoClave;
        [XmlAttribute]
        public string? Producto_precios_ListaprecmayoreoClave { get => _Producto_precios_ListaprecmayoreoClave; set { if (RaiseAcceptPendingChange(value, _Producto_precios_ListaprecmayoreoClave)) { _Producto_precios_ListaprecmayoreoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_precios_ListaprecmayoreoNombre;
        [XmlAttribute]
        public string? Producto_precios_ListaprecmayoreoNombre { get => _Producto_precios_ListaprecmayoreoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_precios_ListaprecmayoreoNombre)) { _Producto_precios_ListaprecmayoreoNombre = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Cantmediomay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Cantmediomay { get => _Producto_precios_Cantmediomay?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Cantmediomay)) { _Producto_precios_Cantmediomay = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Cantmayoreo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Cantmayoreo { get => _Producto_precios_Cantmayoreo?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Cantmayoreo)) { _Producto_precios_Cantmayoreo = value?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_precios_Limiteprecio2;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Limiteprecio2 { get => _Producto_precios_Limiteprecio2 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Limiteprecio2)) { _Producto_precios_Limiteprecio2 = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_precios_Descuento;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Descuento { get => _Producto_precios_Descuento ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Descuento)) { _Producto_precios_Descuento = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Menudeo;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Menudeo { get => _Producto_precios_Menudeo ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Menudeo)) { _Producto_precios_Menudeo = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Preciomaximopublico;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Preciomaximopublico { get => _Producto_precios_Preciomaximopublico ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciomaximopublico)) { _Producto_precios_Preciomaximopublico = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costoendolar;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costoendolar { get => _Producto_precios_Costoendolar ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costoendolar)) { _Producto_precios_Costoendolar = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Preciosugerido;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Preciosugerido { get => _Producto_precios_Preciosugerido ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciosugerido)) { _Producto_precios_Preciosugerido = value ?? 0; OnPropertyChanged(); } } }

        private BoolCN? _Producto_precios_Cambiarprecio;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_precios_Cambiarprecio { get => _Producto_precios_Cambiarprecio ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Cambiarprecio)) { _Producto_precios_Cambiarprecio = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private DateTimeOffset? _Producto_precios_Fechacambioprecio;
        [XmlAttribute]
        public DateTimeOffset? Producto_precios_Fechacambioprecio { get => _Producto_precios_Fechacambioprecio; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Fechacambioprecio)) { _Producto_precios_Fechacambioprecio = value; OnPropertyChanged(); } } }

        private BoolCN? _Producto_precios_Preciomat;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_precios_Preciomat { get => _Producto_precios_Preciomat ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciomat)) { _Producto_precios_Preciomat = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Oferta;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Oferta { get => _Producto_precios_Oferta ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Oferta)) { _Producto_precios_Oferta = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Preciotope;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Preciotope { get => _Producto_precios_Preciotope ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciotope)) { _Producto_precios_Preciotope = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Desctope;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Desctope { get => _Producto_precios_Desctope ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Desctope)) { _Producto_precios_Desctope = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Margen;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Margen { get => _Producto_precios_Margen ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Margen)) { _Producto_precios_Margen = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Descpes;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Descpes { get => _Producto_precios_Descpes ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Descpes)) { _Producto_precios_Descpes = value ?? 0; OnPropertyChanged(); } } }

        private long? _Producto_precios_Monedaid;
        [XmlAttribute]
        public long? Producto_precios_Monedaid { get => _Producto_precios_Monedaid; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Monedaid)) { _Producto_precios_Monedaid = value; OnPropertyChanged(); } } }

        private string? _Producto_precios_MonedaClave;
        [XmlAttribute]
        public string? Producto_precios_MonedaClave { get => _Producto_precios_MonedaClave; set { if (RaiseAcceptPendingChange(value, _Producto_precios_MonedaClave)) { _Producto_precios_MonedaClave = value; OnPropertyChanged(); } } }

        private string? _Producto_precios_MonedaNombre;
        [XmlAttribute]
        public string? Producto_precios_MonedaNombre { get => _Producto_precios_MonedaNombre; set { if (RaiseAcceptPendingChange(value, _Producto_precios_MonedaNombre)) { _Producto_precios_MonedaNombre = value; OnPropertyChanged(); } } }


        private BoolCN? _Producto_promocion_Esprodpromo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_promocion_Esprodpromo { get => _Producto_promocion_Esprodpromo?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_promocion_Esprodpromo)) { _Producto_promocion_Esprodpromo = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Producto_promocion_Baseprodpromoid;
        [XmlAttribute]
        public long? Producto_promocion_Baseprodpromoid { get => _Producto_promocion_Baseprodpromoid; set { if (RaiseAcceptPendingChange(value, _Producto_promocion_Baseprodpromoid)) { _Producto_promocion_Baseprodpromoid = value; OnPropertyChanged(); } } }

        private string? _Producto_promocion_BaseprodpromoClave;
        [XmlAttribute]
        public string? Producto_promocion_BaseprodpromoClave { get => _Producto_promocion_BaseprodpromoClave; set { if (RaiseAcceptPendingChange(value, _Producto_promocion_BaseprodpromoClave)) { _Producto_promocion_BaseprodpromoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_promocion_BaseprodpromoNombre;
        [XmlAttribute]
        public string? Producto_promocion_BaseprodpromoNombre { get => _Producto_promocion_BaseprodpromoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_promocion_BaseprodpromoNombre)) { _Producto_promocion_BaseprodpromoNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Producto_promocion_Vigenciaprodpromo;
        [XmlAttribute]
        public DateTimeOffset? Producto_promocion_Vigenciaprodpromo { get => _Producto_promocion_Vigenciaprodpromo; set { if (RaiseAcceptPendingChange(value, _Producto_promocion_Vigenciaprodpromo)) { _Producto_promocion_Vigenciaprodpromo = value; OnPropertyChanged(); } } }

        private long? _Producto_miscelanea_Clasificaid;
        [XmlAttribute]
        public long? Producto_miscelanea_Clasificaid { get => _Producto_miscelanea_Clasificaid; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_Clasificaid)) { _Producto_miscelanea_Clasificaid = value; OnPropertyChanged(); } } }

        private string? _Producto_miscelanea_ClasificaClave;
        [XmlAttribute]
        public string? Producto_miscelanea_ClasificaClave { get => _Producto_miscelanea_ClasificaClave; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_ClasificaClave)) { _Producto_miscelanea_ClasificaClave = value; OnPropertyChanged(); } } }

        private string? _Producto_miscelanea_ClasificaNombre;
        [XmlAttribute]
        public string? Producto_miscelanea_ClasificaNombre { get => _Producto_miscelanea_ClasificaNombre; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_ClasificaNombre)) { _Producto_miscelanea_ClasificaNombre = value; OnPropertyChanged(); } } }

        private long? _Producto_miscelanea_Contenidoid;
        [XmlAttribute]
        public long? Producto_miscelanea_Contenidoid { get => _Producto_miscelanea_Contenidoid; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_Contenidoid)) { _Producto_miscelanea_Contenidoid = value; OnPropertyChanged(); } } }

        private string? _Producto_miscelanea_ContenidoClave;
        [XmlAttribute]
        public string? Producto_miscelanea_ContenidoClave { get => _Producto_miscelanea_ContenidoClave; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_ContenidoClave)) { _Producto_miscelanea_ContenidoClave = value; OnPropertyChanged(); } } }

        private string? _Producto_miscelanea_ContenidoNombre;
        [XmlAttribute]
        public string? Producto_miscelanea_ContenidoNombre { get => _Producto_miscelanea_ContenidoNombre; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_ContenidoNombre)) { _Producto_miscelanea_ContenidoNombre = value; OnPropertyChanged(); } } }



        private decimal? _Producto_miscelanea_Contenidovalor;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_miscelanea_Contenidovalor { get => _Producto_miscelanea_Contenidovalor ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_Contenidovalor)) { _Producto_miscelanea_Contenidovalor = value ?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Producto_miscelanea_Imprimir;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Producto_miscelanea_Imprimir { get => _Producto_miscelanea_Imprimir ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_Imprimir)) { _Producto_miscelanea_Imprimir = value ?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCS? _Producto_miscelanea_Imprimircomanda;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Producto_miscelanea_Imprimircomanda { get => _Producto_miscelanea_Imprimircomanda ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Producto_miscelanea_Imprimircomanda)) { _Producto_miscelanea_Imprimircomanda = value ?? BoolCS.S; OnPropertyChanged(); } } }



        private BoolCN? _Producto_padre_Esproductopadre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_padre_Esproductopadre { get => _Producto_padre_Esproductopadre?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_padre_Esproductopadre)) { _Producto_padre_Esproductopadre = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_padre_Essubproducto;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_padre_Essubproducto { get => _Producto_padre_Essubproducto?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_padre_Essubproducto)) { _Producto_padre_Essubproducto = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_padre_Tomarpreciopadre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_padre_Tomarpreciopadre { get => _Producto_padre_Tomarpreciopadre?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_padre_Tomarpreciopadre)) { _Producto_padre_Tomarpreciopadre = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_padre_Tomarcomisionpadre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_padre_Tomarcomisionpadre { get => _Producto_padre_Tomarcomisionpadre?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_padre_Tomarcomisionpadre)) { _Producto_padre_Tomarcomisionpadre = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Producto_padre_Tomarofertapadre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_padre_Tomarofertapadre { get => _Producto_padre_Tomarofertapadre?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_padre_Tomarofertapadre)) { _Producto_padre_Tomarofertapadre = value?? BoolCN.N; OnPropertyChanged(); } } }

        private long? _Producto_padre_Productopadreid;
        [XmlAttribute]
        public long? Producto_padre_Productopadreid { get => _Producto_padre_Productopadreid; set { if (RaiseAcceptPendingChange(value, _Producto_padre_Productopadreid)) { _Producto_padre_Productopadreid = value; OnPropertyChanged(); } } }

        private string? _Producto_padre_ProductopadreClave;
        [XmlAttribute]
        public string? Producto_padre_ProductopadreClave { get => _Producto_padre_ProductopadreClave; set { if (RaiseAcceptPendingChange(value, _Producto_padre_ProductopadreClave)) { _Producto_padre_ProductopadreClave = value; OnPropertyChanged(); } } }

        private string? _Producto_padre_ProductopadreNombre;
        [XmlAttribute]
        public string? Producto_padre_ProductopadreNombre { get => _Producto_padre_ProductopadreNombre; set { if (RaiseAcceptPendingChange(value, _Producto_padre_ProductopadreNombre)) { _Producto_padre_ProductopadreNombre = value; OnPropertyChanged(); } } }

        private decimal? _Producto_utilidad_Minutilidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_utilidad_Minutilidad { get => _Producto_utilidad_Minutilidad?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_utilidad_Minutilidad)) { _Producto_utilidad_Minutilidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_utilidad_Porcutilprecio1;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_utilidad_Porcutilprecio1 { get => _Producto_utilidad_Porcutilprecio1?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_utilidad_Porcutilprecio1)) { _Producto_utilidad_Porcutilprecio1 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_utilidad_Porcutilprecio2;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_utilidad_Porcutilprecio2 { get => _Producto_utilidad_Porcutilprecio2?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_utilidad_Porcutilprecio2)) { _Producto_utilidad_Porcutilprecio2 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_utilidad_Porcutilprecio3;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_utilidad_Porcutilprecio3 { get => _Producto_utilidad_Porcutilprecio3?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_utilidad_Porcutilprecio3)) { _Producto_utilidad_Porcutilprecio3 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_utilidad_Porcutilprecio4;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_utilidad_Porcutilprecio4 { get => _Producto_utilidad_Porcutilprecio4?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_utilidad_Porcutilprecio4)) { _Producto_utilidad_Porcutilprecio4 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_utilidad_Porcutilprecio5;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_utilidad_Porcutilprecio5 { get => _Producto_utilidad_Porcutilprecio5?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_utilidad_Porcutilprecio5)) { _Producto_utilidad_Porcutilprecio5 = value?? 0; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Clave;
        [XmlAttribute]
        public string? Productocaracteristicas_Clave { get => _Productocaracteristicas_Clave; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Clave)) { _Productocaracteristicas_Clave = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto1;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto1 { get => _Productocaracteristicas_Texto1; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto1)) { _Productocaracteristicas_Texto1 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto2;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto2 { get => _Productocaracteristicas_Texto2; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto2)) { _Productocaracteristicas_Texto2 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto3;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto3 { get => _Productocaracteristicas_Texto3; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto3)) { _Productocaracteristicas_Texto3 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto4;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto4 { get => _Productocaracteristicas_Texto4; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto4)) { _Productocaracteristicas_Texto4 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto5;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto5 { get => _Productocaracteristicas_Texto5; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto5)) { _Productocaracteristicas_Texto5 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto6;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto6 { get => _Productocaracteristicas_Texto6; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto6)) { _Productocaracteristicas_Texto6 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero1;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero1 { get => _Productocaracteristicas_Numero1; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero1)) { _Productocaracteristicas_Numero1 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero2;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero2 { get => _Productocaracteristicas_Numero2; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero2)) { _Productocaracteristicas_Numero2 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero3;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero3 { get => _Productocaracteristicas_Numero3; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero3)) { _Productocaracteristicas_Numero3 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero4;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero4 { get => _Productocaracteristicas_Numero4; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero4)) { _Productocaracteristicas_Numero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Productocaracteristicas_Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Productocaracteristicas_Fecha1 { get => _Productocaracteristicas_Fecha1; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Fecha1)) { _Productocaracteristicas_Fecha1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Productocaracteristicas_Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Productocaracteristicas_Fecha2 { get => _Productocaracteristicas_Fecha2; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Fecha2)) { _Productocaracteristicas_Fecha2 = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Producto"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Descripcion|Ean|Descripcion1|Descripcion2|Descripcion3|Cbarras|Cempaque|Plug|Proveedor1.Clave|Proveedor1.Nombre|Proveedor2.Clave|Proveedor2.Nombre|Linea.Clave|Linea.Nombre|Marca.Clave|Marca.Nombre|Unidad.Clave|Unidad.Nombre|Producto_emida.Emidaid|Producto_emida.Emidaproducto.Clave|Producto_emida.Emidaproducto.Nombre|Producto_fact_elect.Sat_productoservicio.Clave|Producto_fact_elect.Sat_productoservicio.Nombre|Producto_fact_elect.Sat_Tipoembalaje.Clave|Producto_fact_elect.Sat_Tipoembalaje.Nombre|Producto_fact_elect.Sat_Claveunidadpeso.Clave|Producto_fact_elect.Sat_Claveunidadpeso.Nombre|Producto_fact_elect.Sat_Matpeligroso.Clave|Producto_fact_elect.Sat_Matpeligroso.Nombre|Producto_origenfiscal.Ultimoorigenfiscalventa_.Clave|Producto_origenfiscal.Ultimoorigenfiscalventa_.Nombre|Producto_poliza.Plazo.Clave|Producto_poliza.Plazo.Nombre|Producto_precios.Listaprecmediomay.Clave|Producto_precios.Listaprecmediomay.Nombre|Producto_precios.Listaprecmayoreo.Clave|Producto_precios.Listaprecmayoreo.Nombre|Producto_promocion.Baseprodpromo.Clave|Producto_promocion.Baseprodpromo.Nombre|Producto_miscelanea.Clasifica.Clave|Producto_miscelanea.Clasifica.Nombre|Producto_miscelanea.Contenido.Clave|Producto_miscelanea.Contenido.Nombre|Producto_padre.Productopadre.Clave|Producto_padre.Productopadre.Nombre|Productocaracteristicas.Clave|Productocaracteristicas.Texto1|Productocaracteristicas.Texto2|Productocaracteristicas.Texto3|Productocaracteristicas.Texto4|Productocaracteristicas.Texto5|Productocaracteristicas.Texto6";
        }



        #if PROYECTO_WEB
        
        public void FillCatalogRelatedFields(Producto item)
        {

             this._Proveedor1Clave = item.Proveedor1?.Clave;

             this._Proveedor1Nombre = item.Proveedor1?.Nombre;

             this._Proveedor2Clave = item.Proveedor2?.Clave;

             this._Proveedor2Nombre = item.Proveedor2?.Nombre;

             this._LineaClave = item.Linea?.Clave;

             this._LineaNombre = item.Linea?.Nombre;

             this._MarcaClave = item.Marca?.Clave;

             this._MarcaNombre = item.Marca?.Nombre;

             this._UnidadClave = item.Unidad?.Clave;

             this._UnidadNombre = item.Unidad?.Nombre;

             this._SubstitutoClave = item.Substituto?.Clave;

             this._SubstitutoNombre = item.Substituto?.Nombre;

            this._Producto_emida_EmidaproductoClave = item.Producto_emida?.Emidaproducto?.Clave;

             this._Producto_emida_EmidaproductoNombre = item.Producto_emida?.Emidaproducto?.Nombre;

             this._Producto_fact_elect_Sat_productoservicioClave = item.Producto_fact_elect?.Sat_productoservicio?.Clave;

             this._Producto_fact_elect_Sat_productoservicioNombre = item.Producto_fact_elect?.Sat_productoservicio?.Nombre;

             this._Producto_fact_elect_Sat_TipoembalajeClave = item.Producto_fact_elect?.Sat_Tipoembalaje?.Clave;

             this._Producto_fact_elect_Sat_TipoembalajeNombre = item.Producto_fact_elect?.Sat_Tipoembalaje?.Nombre;

             this._Producto_fact_elect_Sat_ClaveunidadpesoClave = item.Producto_fact_elect?.Sat_Claveunidadpeso?.Clave;

             this._Producto_fact_elect_Sat_ClaveunidadpesoNombre = item.Producto_fact_elect?.Sat_Claveunidadpeso?.Nombre;

             this._Producto_fact_elect_Sat_MatpeligrosoClave = item.Producto_fact_elect?.Sat_Matpeligroso?.Clave;

             this._Producto_fact_elect_Sat_MatpeligrosoNombre = item.Producto_fact_elect?.Sat_Matpeligroso?.Nombre;

             this._Producto_origenfiscal_Ultimoorigenfiscalventa_Clave = item.Producto_origenfiscal?.Ultimoorigenfiscalventa_?.Clave;

             this._Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre = item.Producto_origenfiscal?.Ultimoorigenfiscalventa_?.Nombre;

             this._Producto_poliza_PlazoClave = item.Producto_poliza?.Plazo?.Clave;

             this._Producto_poliza_PlazoNombre = item.Producto_poliza?.Plazo?.Nombre;

             this._Producto_precios_ListaprecmediomayClave = item.Producto_precios?.Listaprecmediomay?.Clave;

             this._Producto_precios_ListaprecmediomayNombre = item.Producto_precios?.Listaprecmediomay?.Nombre;

             this._Producto_precios_ListaprecmayoreoClave = item.Producto_precios?.Listaprecmayoreo?.Clave;

             this._Producto_precios_ListaprecmayoreoNombre = item.Producto_precios?.Listaprecmayoreo?.Nombre;


             this._Producto_precios_MonedaClave = item.Producto_precios?.Moneda?.Clave;

             this._Producto_precios_MonedaNombre = item.Producto_precios?.Moneda?.Nombre;

            this._Producto_promocion_BaseprodpromoClave = item.Producto_promocion?.Baseprodpromo?.Clave;

             this._Producto_promocion_BaseprodpromoNombre = item.Producto_promocion?.Baseprodpromo?.Nombre;

             this._Producto_miscelanea_ClasificaClave = item.Producto_miscelanea?.Clasifica?.Clave;

             this._Producto_miscelanea_ClasificaNombre = item.Producto_miscelanea?.Clasifica?.Nombre;

             this._Producto_miscelanea_ContenidoClave = item.Producto_miscelanea?.Contenido?.Clave;

             this._Producto_miscelanea_ContenidoNombre = item.Producto_miscelanea?.Contenido?.Nombre;

             this._Producto_padre_ProductopadreClave = item.Producto_padre?.Productopadre?.Clave;

             this._Producto_padre_ProductopadreNombre = item.Producto_padre?.Productopadre?.Nombre;



        }


        public void FillEntityValues(ref Producto item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.Descripcion = Descripcion ?? "";


            item.Ean = Ean ;


            item.Descripcion1 = Descripcion1 ;


            item.Descripcion2 = Descripcion2 ;


            item.Descripcion3 = Descripcion3 ;


            item.Cbarras = Cbarras ;


            item.Cempaque = Cempaque ;


            item.Plug = Plug ;


            item.Proveedor1id = Proveedor1id ;


            item.Proveedor2id = Proveedor2id ;


            item.Lineaid = Lineaid ;


            item.Marcaid = Marcaid ;


            item.Unidadid = Unidadid ;


            item.Ivaimpuesto = Ivaimpuesto ?? 0;


            item.Iepsimpuesto = Iepsimpuesto ?? 0;


            item.Impuesto = Impuesto ?? 0;


            item.Substitutoid = Substitutoid;


            item.Imagen = Imagen;


            if (item.Producto_apartado != null)
                item.Producto_apartado!.Existenciafacturadoapartado = Producto_apartado_Existenciafacturadoapartado?? 0;
            else if (item.Producto_apartado == null && Producto_apartado_Existenciafacturadoapartado != null)
            {
                item.Producto_apartado = CreateSubEntity<Producto_apartado>();
                item.Producto_apartado!.Existenciafacturadoapartado = Producto_apartado_Existenciafacturadoapartado?? 0;
            }

            if (item.Producto_apartado != null)
                item.Producto_apartado!.Existenciaremisionadoapartado = Producto_apartado_Existenciaremisionadoapartado?? 0;
            else if (item.Producto_apartado == null && Producto_apartado_Existenciaremisionadoapartado != null)
            {
                item.Producto_apartado = CreateSubEntity<Producto_apartado>();
                item.Producto_apartado!.Existenciaremisionadoapartado = Producto_apartado_Existenciaremisionadoapartado?? 0;
            }

            if (item.Producto_apartado != null)
                item.Producto_apartado!.Existenciaindefinidoapartado = Producto_apartado_Existenciaindefinidoapartado?? 0;
            else if (item.Producto_apartado == null && Producto_apartado_Existenciaindefinidoapartado != null)
            {
                item.Producto_apartado = CreateSubEntity<Producto_apartado>();
                item.Producto_apartado!.Existenciaindefinidoapartado = Producto_apartado_Existenciaindefinidoapartado?? 0;
            }

            if (item.Producto_apartado != null)
                item.Producto_apartado!.Existenciaapartado = Producto_apartado_Existenciaapartado?? 0;
            else if (item.Producto_apartado == null && Producto_apartado_Existenciaapartado != null)
            {
                item.Producto_apartado = CreateSubEntity<Producto_apartado>();
                item.Producto_apartado!.Existenciaapartado = Producto_apartado_Existenciaapartado?? 0;
            }

            if (item.Producto_comision != null)
                item.Producto_comision!.Comision = Producto_comision_Comision?? 0;
            else if (item.Producto_comision == null && Producto_comision_Comision != null)
            {
                item.Producto_comision = CreateSubEntity<Producto_comision>();
                item.Producto_comision!.Comision = Producto_comision_Comision?? 0;
            }

            if (item.Producto_comodin != null)
                item.Producto_comodin!.Descripcion_comodin = Producto_comodin_Descripcion_comodin?? BoolCN.N;
            else if (item.Producto_comodin == null && Producto_comodin_Descripcion_comodin != null)
            {
                item.Producto_comodin = CreateSubEntity<Producto_comodin>();
                item.Producto_comodin!.Descripcion_comodin = Producto_comodin_Descripcion_comodin?? BoolCN.N;
            }

            if (item.Producto_loteimportado != null)
                item.Producto_loteimportado!.Loteimportadoaplicado = Producto_loteimportado_Loteimportadoaplicado?? BoolCN.N;
            else if (item.Producto_loteimportado == null && Producto_loteimportado_Loteimportadoaplicado != null)
            {
                item.Producto_loteimportado = CreateSubEntity<Producto_loteimportado>();
                item.Producto_loteimportado!.Loteimportadoaplicado = Producto_loteimportado_Loteimportadoaplicado?? BoolCN.N;
            }

            if (item.Producto_loteimportado != null)
                item.Producto_loteimportado!.Manejaloteimportado = Producto_loteimportado_Manejaloteimportado?? BoolCN.N;
            else if (item.Producto_loteimportado == null && Producto_loteimportado_Manejaloteimportado != null)
            {
                item.Producto_loteimportado = CreateSubEntity<Producto_loteimportado>();
                item.Producto_loteimportado!.Manejaloteimportado = Producto_loteimportado_Manejaloteimportado?? BoolCN.N;
            }

            if (item.Producto_emida != null)
                item.Producto_emida!.Emidaid = Producto_emida_Emidaid;
            else if (item.Producto_emida == null && Producto_emida_Emidaid != null)
            {
                item.Producto_emida = CreateSubEntity<Producto_emida>();
                item.Producto_emida!.Emidaid = Producto_emida_Emidaid;
            }

            if (item.Producto_emida != null)
                item.Producto_emida!.Emidaproductoid = Producto_emida_Emidaproductoid;
            else if (item.Producto_emida == null && Producto_emida_Emidaproductoid != null)
            {
                item.Producto_emida = CreateSubEntity<Producto_emida>();
                item.Producto_emida!.Emidaproductoid = Producto_emida_Emidaproductoid;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Sat_productoservicioid = Producto_fact_elect_Sat_productoservicioid;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Sat_productoservicioid != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Sat_productoservicioid = Producto_fact_elect_Sat_productoservicioid;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Generacomprobtrasl = Producto_fact_elect_Generacomprobtrasl?? BoolCN.N;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Generacomprobtrasl != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Generacomprobtrasl = Producto_fact_elect_Generacomprobtrasl?? BoolCN.N;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Generacartaporte = Producto_fact_elect_Generacartaporte?? BoolCN.N;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Generacartaporte != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Generacartaporte = Producto_fact_elect_Generacartaporte?? BoolCN.N;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Sat_Tipoembalajeid = Producto_fact_elect_Sat_Tipoembalajeid;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Sat_Tipoembalajeid != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Sat_Tipoembalajeid = Producto_fact_elect_Sat_Tipoembalajeid;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Sat_Claveunidadpesoid = Producto_fact_elect_Sat_Claveunidadpesoid;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Sat_Claveunidadpesoid != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Sat_Claveunidadpesoid = Producto_fact_elect_Sat_Claveunidadpesoid;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Peso = Producto_fact_elect_Peso?? 0;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Peso != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Peso = Producto_fact_elect_Peso?? 0;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Espeligroso = Producto_fact_elect_Espeligroso?? BoolCN.N;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Espeligroso != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Espeligroso = Producto_fact_elect_Espeligroso?? BoolCN.N;
            }

            if (item.Producto_fact_elect != null)
                item.Producto_fact_elect!.Sat_Matpeligrosoid = Producto_fact_elect_Sat_Matpeligrosoid;
            else if (item.Producto_fact_elect == null && Producto_fact_elect_Sat_Matpeligrosoid != null)
            {
                item.Producto_fact_elect = CreateSubEntity<Producto_fact_elect>();
                item.Producto_fact_elect!.Sat_Matpeligrosoid = Producto_fact_elect_Sat_Matpeligrosoid;
            }

            if (item.Producto_farmacia != null)
                item.Producto_farmacia!.Requierereceta = Producto_farmacia_Requierereceta?? BoolCN.N;
            else if (item.Producto_farmacia == null && Producto_farmacia_Requierereceta != null)
            {
                item.Producto_farmacia = CreateSubEntity<Producto_farmacia>();
                item.Producto_farmacia!.Requierereceta = Producto_farmacia_Requierereceta?? BoolCN.N;
            }

            if (item.Producto_existencia != null)
                item.Producto_existencia!.Existencia = Producto_existencia_Existencia?? 0;
            else if (item.Producto_existencia == null && Producto_existencia_Existencia != null)
            {
                item.Producto_existencia = CreateSubEntity<Producto_existencia>();
                item.Producto_existencia!.Existencia = Producto_existencia_Existencia?? 0;
            }

            if (item.Producto_existencia != null)
                item.Producto_existencia!.Enprocesodesalida = Producto_existencia_Enprocesodesalida?? 0;
            else if (item.Producto_existencia == null && Producto_existencia_Enprocesodesalida != null)
            {
                item.Producto_existencia = CreateSubEntity<Producto_existencia>();
                item.Producto_existencia!.Enprocesodesalida = Producto_existencia_Enprocesodesalida?? 0;
            }

            if (item.Producto_existencia != null)
                item.Producto_existencia!.Ultimocambioexistencia = Producto_existencia_Ultimocambioexistencia;
            else if (item.Producto_existencia == null && Producto_existencia_Ultimocambioexistencia != null)
            {
                item.Producto_existencia = CreateSubEntity<Producto_existencia>();
                item.Producto_existencia!.Ultimocambioexistencia = Producto_existencia_Ultimocambioexistencia;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Inventariable = Producto_inventario_Inventariable?? BoolCS.S;
            else if (item.Producto_inventario == null && Producto_inventario_Inventariable != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Inventariable = Producto_inventario_Inventariable?? BoolCS.S;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Negativos = Producto_inventario_Negativos?? BoolCN.N;
            else if (item.Producto_inventario == null && Producto_inventario_Negativos != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Negativos = Producto_inventario_Negativos?? BoolCN.N;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Manejastock = Producto_inventario_Manejastock?? BoolCN.N;
            else if (item.Producto_inventario == null && Producto_inventario_Manejastock != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Manejastock = Producto_inventario_Manejastock?? BoolCN.N;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Surtirporcaja = Producto_inventario_Surtirporcaja?? BoolCN.N;
            else if (item.Producto_inventario == null && Producto_inventario_Surtirporcaja != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Surtirporcaja = Producto_inventario_Surtirporcaja?? BoolCN.N;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Manejalote = Producto_inventario_Manejalote?? BoolCN.N;
            else if (item.Producto_inventario == null && Producto_inventario_Manejalote != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Manejalote = Producto_inventario_Manejalote?? BoolCN.N;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Stock = Producto_inventario_Stock?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Stock != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Stock = Producto_inventario_Stock?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Stockmax = Producto_inventario_Stockmax?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Stockmax != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Stockmax = Producto_inventario_Stockmax?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Stockmincaja = Producto_inventario_Stockmincaja?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Stockmincaja != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Stockmincaja = Producto_inventario_Stockmincaja?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Stockmaxcaja = Producto_inventario_Stockmaxcaja?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Stockmaxcaja != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Stockmaxcaja = Producto_inventario_Stockmaxcaja?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Stockminpieza = Producto_inventario_Stockminpieza?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Stockminpieza != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Stockminpieza = Producto_inventario_Stockminpieza?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Stockmaxpieza = Producto_inventario_Stockmaxpieza?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Stockmaxpieza != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Stockmaxpieza = Producto_inventario_Stockmaxpieza?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Pzacaja = Producto_inventario_Pzacaja?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Pzacaja != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Pzacaja = Producto_inventario_Pzacaja?? 0;
            }



            if (item.Producto_inventario != null)
                item.Producto_inventario!.U_empaque = Producto_inventario_U_empaque ?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_U_empaque != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.U_empaque = Producto_inventario_U_empaque ?? 0;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Cantxpieza = Producto_inventario_Cantxpieza ?? 0;
            else if (item.Producto_inventario == null && Producto_inventario_Cantxpieza != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Cantxpieza = Producto_inventario_Cantxpieza ?? 0;
            }


            if (item.Producto_kit != null)
                item.Producto_kit!.Eskit = Producto_kit_Eskit?? BoolCN.N;
            else if (item.Producto_kit == null && Producto_kit_Eskit != null)
            {
                item.Producto_kit = CreateSubEntity<Producto_kit>();
                item.Producto_kit!.Eskit = Producto_kit_Eskit?? BoolCN.N;
            }

            if (item.Producto_kit != null)
                item.Producto_kit!.Kittienevig = Producto_kit_Kittienevig?? BoolCN.N;
            else if (item.Producto_kit == null && Producto_kit_Kittienevig != null)
            {
                item.Producto_kit = CreateSubEntity<Producto_kit>();
                item.Producto_kit!.Kittienevig = Producto_kit_Kittienevig?? BoolCN.N;
            }

            if (item.Producto_kit != null)
                item.Producto_kit!.Kitimpfijo = Producto_kit_Kitimpfijo?? BoolCN.N;
            else if (item.Producto_kit == null && Producto_kit_Kitimpfijo != null)
            {
                item.Producto_kit = CreateSubEntity<Producto_kit>();
                item.Producto_kit!.Kitimpfijo = Producto_kit_Kitimpfijo?? BoolCN.N;
            }


            if (item.Producto_kit != null)
                item.Producto_kit!.Valxsuc = Producto_kit_Valxsuc;
            else if (item.Producto_kit == null && Producto_kit_Valxsuc != null)
            {
                item.Producto_kit = CreateSubEntity<Producto_kit>();
                item.Producto_kit!.Valxsuc = Producto_kit_Valxsuc;
            }

            if (item.Producto_kit != null)
                item.Producto_kit!.Enprocesopartessalida = Producto_kit_Enprocesopartessalida?? 0;
            else if (item.Producto_kit == null && Producto_kit_Enprocesopartessalida != null)
            {
                item.Producto_kit = CreateSubEntity<Producto_kit>();
                item.Producto_kit!.Enprocesopartessalida = Producto_kit_Enprocesopartessalida?? 0;
            }

            if (item.Producto_kit != null)
                item.Producto_kit!.Vigenciaprodkit = Producto_kit_Vigenciaprodkit;
            else if (item.Producto_kit == null && Producto_kit_Vigenciaprodkit != null)
            {
                item.Producto_kit = CreateSubEntity<Producto_kit>();
                item.Producto_kit!.Vigenciaprodkit = Producto_kit_Vigenciaprodkit;
            }

            if (item.Producto_origenfiscal != null)
                item.Producto_origenfiscal!.Existenciafacturado = Producto_origenfiscal_Existenciafacturado?? 0;
            else if (item.Producto_origenfiscal == null && Producto_origenfiscal_Existenciafacturado != null)
            {
                item.Producto_origenfiscal = CreateSubEntity<Producto_origenfiscal>();
                item.Producto_origenfiscal!.Existenciafacturado = Producto_origenfiscal_Existenciafacturado?? 0;
            }

            if (item.Producto_origenfiscal != null)
                item.Producto_origenfiscal!.Existenciaremisionado = Producto_origenfiscal_Existenciaremisionado?? 0;
            else if (item.Producto_origenfiscal == null && Producto_origenfiscal_Existenciaremisionado != null)
            {
                item.Producto_origenfiscal = CreateSubEntity<Producto_origenfiscal>();
                item.Producto_origenfiscal!.Existenciaremisionado = Producto_origenfiscal_Existenciaremisionado?? 0;
            }

            if (item.Producto_origenfiscal != null)
                item.Producto_origenfiscal!.Existenciaindefinido = Producto_origenfiscal_Existenciaindefinido?? 0;
            else if (item.Producto_origenfiscal == null && Producto_origenfiscal_Existenciaindefinido != null)
            {
                item.Producto_origenfiscal = CreateSubEntity<Producto_origenfiscal>();
                item.Producto_origenfiscal!.Existenciaindefinido = Producto_origenfiscal_Existenciaindefinido?? 0;
            }

            if (item.Producto_origenfiscal != null)
                item.Producto_origenfiscal!.Ultimoorigenfiscalventa = Producto_origenfiscal_Ultimoorigenfiscalventa;
            else if (item.Producto_origenfiscal == null && Producto_origenfiscal_Ultimoorigenfiscalventa != null)
            {
                item.Producto_origenfiscal = CreateSubEntity<Producto_origenfiscal>();
                item.Producto_origenfiscal!.Ultimoorigenfiscalventa = Producto_origenfiscal_Ultimoorigenfiscalventa;
            }

            if (item.Producto_origenfiscal != null)
                item.Producto_origenfiscal!.Exist_fac_intercambio = Producto_origenfiscal_Exist_fac_intercambio?? 0;
            else if (item.Producto_origenfiscal == null && Producto_origenfiscal_Exist_fac_intercambio != null)
            {
                item.Producto_origenfiscal = CreateSubEntity<Producto_origenfiscal>();
                item.Producto_origenfiscal!.Exist_fac_intercambio = Producto_origenfiscal_Exist_fac_intercambio?? 0;
            }

            if (item.Producto_poliza != null)
                item.Producto_poliza!.Plazoid = Producto_poliza_Plazoid;
            else if (item.Producto_poliza == null && Producto_poliza_Plazoid != null)
            {
                item.Producto_poliza = CreateSubEntity<Producto_poliza>();
                item.Producto_poliza!.Plazoid = Producto_poliza_Plazoid;
            }


            if (item.Producto_poliza != null)
                item.Producto_poliza!.Cuentapredial = Producto_poliza_Cuentapredial;
            else if (item.Producto_poliza == null && Producto_poliza_Cuentapredial != null)
            {
                item.Producto_poliza = CreateSubEntity<Producto_poliza>();
                item.Producto_poliza!.Cuentapredial = Producto_poliza_Cuentapredial;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Mayokgs = Producto_precios_Mayokgs?? BoolCN.N;
            else if (item.Producto_precios == null && Producto_precios_Mayokgs != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Mayokgs = Producto_precios_Mayokgs?? BoolCN.N;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Tipoabc = Producto_precios_Tipoabc?? BoolCN.N;
            else if (item.Producto_precios == null && Producto_precios_Tipoabc != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Tipoabc = Producto_precios_Tipoabc?? BoolCN.N;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio1 = Producto_precios_Precio1?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio1 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio1 = Producto_precios_Precio1?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio2 = Producto_precios_Precio2?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio2 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio2 = Producto_precios_Precio2?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio3 = Producto_precios_Precio3?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio3 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio3 = Producto_precios_Precio3?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio4 = Producto_precios_Precio4?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio4 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio4 = Producto_precios_Precio4?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio5 = Producto_precios_Precio5?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio5 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio5 = Producto_precios_Precio5?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio6 = Producto_precios_Precio6?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio6 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio6 = Producto_precios_Precio6?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costoultimo = Producto_precios_Costoultimo?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costoultimo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costoultimo = Producto_precios_Costoultimo?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costopromedio = Producto_precios_Costopromedio?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costopromedio != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costopromedio = Producto_precios_Costopromedio?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costorepo = Producto_precios_Costorepo?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costorepo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costorepo = Producto_precios_Costorepo?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio1 = Producto_precios_Superprecio1;
            else if (item.Producto_precios == null && Producto_precios_Superprecio1 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio1 = Producto_precios_Superprecio1;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio2 = Producto_precios_Superprecio2;
            else if (item.Producto_precios == null && Producto_precios_Superprecio2 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio2 = Producto_precios_Superprecio2;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio3 = Producto_precios_Superprecio3;
            else if (item.Producto_precios == null && Producto_precios_Superprecio3 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio3 = Producto_precios_Superprecio3;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio4 = Producto_precios_Superprecio4;
            else if (item.Producto_precios == null && Producto_precios_Superprecio4 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio4 = Producto_precios_Superprecio4;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio5 = Producto_precios_Superprecio5;
            else if (item.Producto_precios == null && Producto_precios_Superprecio5 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio5 = Producto_precios_Superprecio5;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Ini_mayo = Producto_precios_Ini_mayo;
            else if (item.Producto_precios == null && Producto_precios_Ini_mayo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Ini_mayo = Producto_precios_Ini_mayo;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Listaprecmediomayid = Producto_precios_Listaprecmediomayid;
            else if (item.Producto_precios == null && Producto_precios_Listaprecmediomayid != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Listaprecmediomayid = Producto_precios_Listaprecmediomayid;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Listaprecmayoreoid = Producto_precios_Listaprecmayoreoid;
            else if (item.Producto_precios == null && Producto_precios_Listaprecmayoreoid != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Listaprecmayoreoid = Producto_precios_Listaprecmayoreoid;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Cantmediomay = Producto_precios_Cantmediomay?? 0;
            else if (item.Producto_precios == null && Producto_precios_Cantmediomay != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Cantmediomay = Producto_precios_Cantmediomay?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Cantmayoreo = Producto_precios_Cantmayoreo?? 0;
            else if (item.Producto_precios == null && Producto_precios_Cantmayoreo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Cantmayoreo = Producto_precios_Cantmayoreo?? 0;
            }


            if (item.Producto_precios != null)
                item.Producto_precios!.Limiteprecio2 = Producto_precios_Limiteprecio2 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Limiteprecio2 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Limiteprecio2 = Producto_precios_Limiteprecio2 ?? 0;
            }


            if (item.Producto_precios != null)
                item.Producto_precios!.Descuento = Producto_precios_Descuento ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Descuento != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Descuento = Producto_precios_Descuento ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Menudeo = Producto_precios_Menudeo ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Menudeo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Menudeo = Producto_precios_Menudeo ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Preciomaximopublico = Producto_precios_Preciomaximopublico ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Preciomaximopublico != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Preciomaximopublico = Producto_precios_Preciomaximopublico ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costoendolar = Producto_precios_Costoendolar ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costoendolar != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costoendolar = Producto_precios_Costoendolar ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Preciosugerido = Producto_precios_Preciosugerido ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Preciosugerido != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Preciosugerido = Producto_precios_Preciosugerido ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Cambiarprecio = Producto_precios_Cambiarprecio ?? BoolCN.N;
            else if (item.Producto_precios == null && Producto_precios_Cambiarprecio != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Cambiarprecio = Producto_precios_Cambiarprecio ?? BoolCN.N;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Fechacambioprecio = Producto_precios_Fechacambioprecio;
            else if (item.Producto_precios == null && Producto_precios_Fechacambioprecio != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Fechacambioprecio = Producto_precios_Fechacambioprecio;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Preciomat = Producto_precios_Preciomat ?? BoolCN.N;
            else if (item.Producto_precios == null && Producto_precios_Preciomat != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Preciomat = Producto_precios_Preciomat ?? BoolCN.N;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Oferta = Producto_precios_Oferta ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Oferta != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Oferta = Producto_precios_Oferta ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Preciotope = Producto_precios_Preciotope ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Preciotope != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Preciotope = Producto_precios_Preciotope ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Desctope = Producto_precios_Desctope ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Desctope != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Desctope = Producto_precios_Desctope ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Margen = Producto_precios_Margen ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Margen != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Margen = Producto_precios_Margen ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Descpes = Producto_precios_Descpes ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Descpes != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Descpes = Producto_precios_Descpes ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Monedaid = Producto_precios_Monedaid;
            else if (item.Producto_precios == null && Producto_precios_Monedaid != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Monedaid = Producto_precios_Monedaid;
            }




            if (item.Producto_promocion != null)
                item.Producto_promocion!.Esprodpromo = Producto_promocion_Esprodpromo?? BoolCN.N;
            else if (item.Producto_promocion == null && Producto_promocion_Esprodpromo != null)
            {
                item.Producto_promocion = CreateSubEntity<Producto_promocion>();
                item.Producto_promocion!.Esprodpromo = Producto_promocion_Esprodpromo?? BoolCN.N;
            }

            if (item.Producto_promocion != null)
                item.Producto_promocion!.Baseprodpromoid = Producto_promocion_Baseprodpromoid;
            else if (item.Producto_promocion == null && Producto_promocion_Baseprodpromoid != null)
            {
                item.Producto_promocion = CreateSubEntity<Producto_promocion>();
                item.Producto_promocion!.Baseprodpromoid = Producto_promocion_Baseprodpromoid;
            }

            if (item.Producto_promocion != null)
                item.Producto_promocion!.Vigenciaprodpromo = Producto_promocion_Vigenciaprodpromo;
            else if (item.Producto_promocion == null && Producto_promocion_Vigenciaprodpromo != null)
            {
                item.Producto_promocion = CreateSubEntity<Producto_promocion>();
                item.Producto_promocion!.Vigenciaprodpromo = Producto_promocion_Vigenciaprodpromo;
            }

            if (item.Producto_miscelanea != null)
                item.Producto_miscelanea!.Clasificaid = Producto_miscelanea_Clasificaid;
            else if (item.Producto_miscelanea == null && Producto_miscelanea_Clasificaid != null)
            {
                item.Producto_miscelanea = CreateSubEntity<Producto_miscelanea>();
                item.Producto_miscelanea!.Clasificaid = Producto_miscelanea_Clasificaid;
            }

            if (item.Producto_miscelanea != null)
                item.Producto_miscelanea!.Contenidoid = Producto_miscelanea_Contenidoid;
            else if (item.Producto_miscelanea == null && Producto_miscelanea_Contenidoid != null)
            {
                item.Producto_miscelanea = CreateSubEntity<Producto_miscelanea>();
                item.Producto_miscelanea!.Contenidoid = Producto_miscelanea_Contenidoid;
            }


            if (item.Producto_miscelanea != null)
                item.Producto_miscelanea!.Contenidovalor = Producto_miscelanea_Contenidovalor ?? 0;
            else if (item.Producto_miscelanea == null && Producto_miscelanea_Contenidovalor != null)
            {
                item.Producto_miscelanea = CreateSubEntity<Producto_miscelanea>();
                item.Producto_miscelanea!.Contenidovalor = Producto_miscelanea_Contenidovalor ?? 0;
            }

            if (item.Producto_miscelanea != null)
                item.Producto_miscelanea!.Imprimir = Producto_miscelanea_Imprimir ?? BoolCS.S;
            else if (item.Producto_miscelanea == null && Producto_miscelanea_Imprimir != null)
            {
                item.Producto_miscelanea = CreateSubEntity<Producto_miscelanea>();
                item.Producto_miscelanea!.Imprimir = Producto_miscelanea_Imprimir ?? BoolCS.S;
            }

            if (item.Producto_miscelanea != null)
                item.Producto_miscelanea!.Imprimircomanda = Producto_miscelanea_Imprimircomanda ?? BoolCS.S;
            else if (item.Producto_miscelanea == null && Producto_miscelanea_Imprimircomanda != null)
            {
                item.Producto_miscelanea = CreateSubEntity<Producto_miscelanea>();
                item.Producto_miscelanea!.Imprimircomanda = Producto_miscelanea_Imprimircomanda ?? BoolCS.S;
            }

            if (item.Producto_padre != null)
                item.Producto_padre!.Esproductopadre = Producto_padre_Esproductopadre?? BoolCN.N;
            else if (item.Producto_padre == null && Producto_padre_Esproductopadre != null)
            {
                item.Producto_padre = CreateSubEntity<Producto_padre>();
                item.Producto_padre!.Esproductopadre = Producto_padre_Esproductopadre?? BoolCN.N;
            }

            if (item.Producto_padre != null)
                item.Producto_padre!.Essubproducto = Producto_padre_Essubproducto?? BoolCN.N;
            else if (item.Producto_padre == null && Producto_padre_Essubproducto != null)
            {
                item.Producto_padre = CreateSubEntity<Producto_padre>();
                item.Producto_padre!.Essubproducto = Producto_padre_Essubproducto?? BoolCN.N;
            }

            if (item.Producto_padre != null)
                item.Producto_padre!.Tomarpreciopadre = Producto_padre_Tomarpreciopadre?? BoolCN.N;
            else if (item.Producto_padre == null && Producto_padre_Tomarpreciopadre != null)
            {
                item.Producto_padre = CreateSubEntity<Producto_padre>();
                item.Producto_padre!.Tomarpreciopadre = Producto_padre_Tomarpreciopadre?? BoolCN.N;
            }

            if (item.Producto_padre != null)
                item.Producto_padre!.Tomarcomisionpadre = Producto_padre_Tomarcomisionpadre?? BoolCN.N;
            else if (item.Producto_padre == null && Producto_padre_Tomarcomisionpadre != null)
            {
                item.Producto_padre = CreateSubEntity<Producto_padre>();
                item.Producto_padre!.Tomarcomisionpadre = Producto_padre_Tomarcomisionpadre?? BoolCN.N;
            }

            if (item.Producto_padre != null)
                item.Producto_padre!.Tomarofertapadre = Producto_padre_Tomarofertapadre?? BoolCN.N;
            else if (item.Producto_padre == null && Producto_padre_Tomarofertapadre != null)
            {
                item.Producto_padre = CreateSubEntity<Producto_padre>();
                item.Producto_padre!.Tomarofertapadre = Producto_padre_Tomarofertapadre?? BoolCN.N;
            }

            if (item.Producto_padre != null)
                item.Producto_padre!.Productopadreid = Producto_padre_Productopadreid;
            else if (item.Producto_padre == null && Producto_padre_Productopadreid != null)
            {
                item.Producto_padre = CreateSubEntity<Producto_padre>();
                item.Producto_padre!.Productopadreid = Producto_padre_Productopadreid;
            }

            if (item.Producto_utilidad != null)
                item.Producto_utilidad!.Minutilidad = Producto_utilidad_Minutilidad?? 0;
            else if (item.Producto_utilidad == null && Producto_utilidad_Minutilidad != null)
            {
                item.Producto_utilidad = CreateSubEntity<Producto_utilidad>();
                item.Producto_utilidad!.Minutilidad = Producto_utilidad_Minutilidad?? 0;
            }

            if (item.Producto_utilidad != null)
                item.Producto_utilidad!.Porcutilprecio1 = Producto_utilidad_Porcutilprecio1?? 0;
            else if (item.Producto_utilidad == null && Producto_utilidad_Porcutilprecio1 != null)
            {
                item.Producto_utilidad = CreateSubEntity<Producto_utilidad>();
                item.Producto_utilidad!.Porcutilprecio1 = Producto_utilidad_Porcutilprecio1?? 0;
            }

            if (item.Producto_utilidad != null)
                item.Producto_utilidad!.Porcutilprecio2 = Producto_utilidad_Porcutilprecio2?? 0;
            else if (item.Producto_utilidad == null && Producto_utilidad_Porcutilprecio2 != null)
            {
                item.Producto_utilidad = CreateSubEntity<Producto_utilidad>();
                item.Producto_utilidad!.Porcutilprecio2 = Producto_utilidad_Porcutilprecio2?? 0;
            }

            if (item.Producto_utilidad != null)
                item.Producto_utilidad!.Porcutilprecio3 = Producto_utilidad_Porcutilprecio3?? 0;
            else if (item.Producto_utilidad == null && Producto_utilidad_Porcutilprecio3 != null)
            {
                item.Producto_utilidad = CreateSubEntity<Producto_utilidad>();
                item.Producto_utilidad!.Porcutilprecio3 = Producto_utilidad_Porcutilprecio3?? 0;
            }

            if (item.Producto_utilidad != null)
                item.Producto_utilidad!.Porcutilprecio4 = Producto_utilidad_Porcutilprecio4?? 0;
            else if (item.Producto_utilidad == null && Producto_utilidad_Porcutilprecio4 != null)
            {
                item.Producto_utilidad = CreateSubEntity<Producto_utilidad>();
                item.Producto_utilidad!.Porcutilprecio4 = Producto_utilidad_Porcutilprecio4?? 0;
            }

            if (item.Producto_utilidad != null)
                item.Producto_utilidad!.Porcutilprecio5 = Producto_utilidad_Porcutilprecio5?? 0;
            else if (item.Producto_utilidad == null && Producto_utilidad_Porcutilprecio5 != null)
            {
                item.Producto_utilidad = CreateSubEntity<Producto_utilidad>();
                item.Producto_utilidad!.Porcutilprecio5 = Producto_utilidad_Porcutilprecio5?? 0;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Clave = Productocaracteristicas_Clave;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Clave != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Clave = Productocaracteristicas_Clave;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Texto1 = Productocaracteristicas_Texto1;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Texto1 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Texto1 = Productocaracteristicas_Texto1;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Texto2 = Productocaracteristicas_Texto2;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Texto2 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Texto2 = Productocaracteristicas_Texto2;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Texto3 = Productocaracteristicas_Texto3;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Texto3 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Texto3 = Productocaracteristicas_Texto3;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Texto4 = Productocaracteristicas_Texto4;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Texto4 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Texto4 = Productocaracteristicas_Texto4;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Texto5 = Productocaracteristicas_Texto5;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Texto5 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Texto5 = Productocaracteristicas_Texto5;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Texto6 = Productocaracteristicas_Texto6;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Texto6 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Texto6 = Productocaracteristicas_Texto6;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Numero1 = Productocaracteristicas_Numero1;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Numero1 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Numero1 = Productocaracteristicas_Numero1;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Numero2 = Productocaracteristicas_Numero2;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Numero2 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Numero2 = Productocaracteristicas_Numero2;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Numero3 = Productocaracteristicas_Numero3;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Numero3 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Numero3 = Productocaracteristicas_Numero3;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Numero4 = Productocaracteristicas_Numero4;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Numero4 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Numero4 = Productocaracteristicas_Numero4;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Fecha1 = Productocaracteristicas_Fecha1;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Fecha1 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Fecha1 = Productocaracteristicas_Fecha1;
            }

            if (item.Productocaracteristicas != null)
                item.Productocaracteristicas!.Fecha2 = Productocaracteristicas_Fecha2;
            else if (item.Productocaracteristicas == null && Productocaracteristicas_Fecha2 != null)
            {
                item.Productocaracteristicas = CreateSubEntity<Productocaracteristicas>();
                item.Productocaracteristicas!.Fecha2 = Productocaracteristicas_Fecha2;
            }


        }

        public void FillFromEntity(Producto item)
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

            Ean = item.Ean;

            Descripcion1 = item.Descripcion1;

            Descripcion2 = item.Descripcion2;

            Descripcion3 = item.Descripcion3;

            Cbarras = item.Cbarras;

            Cempaque = item.Cempaque;

            Plug = item.Plug;

            Proveedor1id = item.Proveedor1id;

            Proveedor2id = item.Proveedor2id;

            Lineaid = item.Lineaid;

            Marcaid = item.Marcaid;

            Unidadid = item.Unidadid;

            Ivaimpuesto = item.Ivaimpuesto;

            Iepsimpuesto = item.Iepsimpuesto;


            Impuesto = item.Impuesto;

            Substitutoid = item.Substitutoid;

            Imagen = item.Imagen;


            if (item.Producto_apartado != null && item.Producto_apartado?.Existenciafacturadoapartado != null)
                    Producto_apartado_Existenciafacturadoapartado = item.Producto_apartado!.Existenciafacturadoapartado;

            if (item.Producto_apartado != null && item.Producto_apartado?.Existenciaremisionadoapartado != null)
                    Producto_apartado_Existenciaremisionadoapartado = item.Producto_apartado!.Existenciaremisionadoapartado;

            if (item.Producto_apartado != null && item.Producto_apartado?.Existenciaindefinidoapartado != null)
                    Producto_apartado_Existenciaindefinidoapartado = item.Producto_apartado!.Existenciaindefinidoapartado;

            if (item.Producto_apartado != null && item.Producto_apartado?.Existenciaapartado != null)
                    Producto_apartado_Existenciaapartado = item.Producto_apartado!.Existenciaapartado;

            if (item.Producto_comision != null && item.Producto_comision?.Comision != null)
                    Producto_comision_Comision = item.Producto_comision!.Comision;

            if (item.Producto_comodin != null && item.Producto_comodin?.Descripcion_comodin != null)
                    Producto_comodin_Descripcion_comodin = item.Producto_comodin!.Descripcion_comodin;

            if (item.Producto_loteimportado != null && item.Producto_loteimportado?.Loteimportadoaplicado != null)
                    Producto_loteimportado_Loteimportadoaplicado = item.Producto_loteimportado!.Loteimportadoaplicado;

            if (item.Producto_loteimportado != null && item.Producto_loteimportado?.Manejaloteimportado != null)
                    Producto_loteimportado_Manejaloteimportado = item.Producto_loteimportado!.Manejaloteimportado;

            if (item.Producto_emida != null && item.Producto_emida?.Emidaid != null)
                    Producto_emida_Emidaid = item.Producto_emida!.Emidaid;

            if (item.Producto_emida != null && item.Producto_emida?.Emidaproductoid != null)
                    Producto_emida_Emidaproductoid = item.Producto_emida!.Emidaproductoid;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Sat_productoservicioid != null)
                    Producto_fact_elect_Sat_productoservicioid = item.Producto_fact_elect!.Sat_productoservicioid;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Generacomprobtrasl != null)
                    Producto_fact_elect_Generacomprobtrasl = item.Producto_fact_elect!.Generacomprobtrasl;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Generacartaporte != null)
                    Producto_fact_elect_Generacartaporte = item.Producto_fact_elect!.Generacartaporte;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Sat_Tipoembalajeid != null)
                    Producto_fact_elect_Sat_Tipoembalajeid = item.Producto_fact_elect!.Sat_Tipoembalajeid;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Sat_Claveunidadpesoid != null)
                    Producto_fact_elect_Sat_Claveunidadpesoid = item.Producto_fact_elect!.Sat_Claveunidadpesoid;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Peso != null)
                    Producto_fact_elect_Peso = item.Producto_fact_elect!.Peso;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Espeligroso != null)
                    Producto_fact_elect_Espeligroso = item.Producto_fact_elect!.Espeligroso;

            if (item.Producto_fact_elect != null && item.Producto_fact_elect?.Sat_Matpeligrosoid != null)
                    Producto_fact_elect_Sat_Matpeligrosoid = item.Producto_fact_elect!.Sat_Matpeligrosoid;

            if (item.Producto_farmacia != null && item.Producto_farmacia?.Requierereceta != null)
                    Producto_farmacia_Requierereceta = item.Producto_farmacia!.Requierereceta;

            if (item.Producto_existencia != null && item.Producto_existencia?.Existencia != null)
                    Producto_existencia_Existencia = item.Producto_existencia!.Existencia;

            if (item.Producto_existencia != null && item.Producto_existencia?.Enprocesodesalida != null)
                    Producto_existencia_Enprocesodesalida = item.Producto_existencia!.Enprocesodesalida;

            if (item.Producto_existencia != null && item.Producto_existencia?.Ultimocambioexistencia != null)
                    Producto_existencia_Ultimocambioexistencia = item.Producto_existencia!.Ultimocambioexistencia;

            if (item.Producto_inventario != null && item.Producto_inventario?.Inventariable != null)
                    Producto_inventario_Inventariable = item.Producto_inventario!.Inventariable;

            if (item.Producto_inventario != null && item.Producto_inventario?.Negativos != null)
                    Producto_inventario_Negativos = item.Producto_inventario!.Negativos;

            if (item.Producto_inventario != null && item.Producto_inventario?.Manejastock != null)
                    Producto_inventario_Manejastock = item.Producto_inventario!.Manejastock;

            if (item.Producto_inventario != null && item.Producto_inventario?.Surtirporcaja != null)
                    Producto_inventario_Surtirporcaja = item.Producto_inventario!.Surtirporcaja;

            if (item.Producto_inventario != null && item.Producto_inventario?.Manejalote != null)
                    Producto_inventario_Manejalote = item.Producto_inventario!.Manejalote;

            if (item.Producto_inventario != null && item.Producto_inventario?.Stock != null)
                    Producto_inventario_Stock = item.Producto_inventario!.Stock;

            if (item.Producto_inventario != null && item.Producto_inventario?.Stockmax != null)
                    Producto_inventario_Stockmax = item.Producto_inventario!.Stockmax;

            if (item.Producto_inventario != null && item.Producto_inventario?.Stockmincaja != null)
                    Producto_inventario_Stockmincaja = item.Producto_inventario!.Stockmincaja;

            if (item.Producto_inventario != null && item.Producto_inventario?.Stockmaxcaja != null)
                    Producto_inventario_Stockmaxcaja = item.Producto_inventario!.Stockmaxcaja;

            if (item.Producto_inventario != null && item.Producto_inventario?.Stockminpieza != null)
                    Producto_inventario_Stockminpieza = item.Producto_inventario!.Stockminpieza;

            if (item.Producto_inventario != null && item.Producto_inventario?.Stockmaxpieza != null)
                    Producto_inventario_Stockmaxpieza = item.Producto_inventario!.Stockmaxpieza;

            if (item.Producto_inventario != null && item.Producto_inventario?.Pzacaja != null)
                    Producto_inventario_Pzacaja = item.Producto_inventario!.Pzacaja;

            if (item.Producto_inventario != null && item.Producto_inventario?.U_empaque != null)
                Producto_inventario_U_empaque = item.Producto_inventario!.U_empaque;

            if (item.Producto_inventario != null && item.Producto_inventario?.Cantxpieza != null)
                Producto_inventario_Cantxpieza = item.Producto_inventario!.Cantxpieza;

            if (item.Producto_kit != null && item.Producto_kit?.Eskit != null)
                    Producto_kit_Eskit = item.Producto_kit!.Eskit;

            if (item.Producto_kit != null && item.Producto_kit?.Kittienevig != null)
                    Producto_kit_Kittienevig = item.Producto_kit!.Kittienevig;

            if (item.Producto_kit != null && item.Producto_kit?.Kitimpfijo != null)
                    Producto_kit_Kitimpfijo = item.Producto_kit!.Kitimpfijo;

            if (item.Producto_kit != null && item.Producto_kit?.Valxsuc != null)
                Producto_kit_Valxsuc = item.Producto_kit!.Valxsuc;

            if (item.Producto_kit != null && item.Producto_kit?.Enprocesopartessalida != null)
                    Producto_kit_Enprocesopartessalida = item.Producto_kit!.Enprocesopartessalida;

            if (item.Producto_kit != null && item.Producto_kit?.Vigenciaprodkit != null)
                    Producto_kit_Vigenciaprodkit = item.Producto_kit!.Vigenciaprodkit;

            if (item.Producto_origenfiscal != null && item.Producto_origenfiscal?.Existenciafacturado != null)
                    Producto_origenfiscal_Existenciafacturado = item.Producto_origenfiscal!.Existenciafacturado;

            if (item.Producto_origenfiscal != null && item.Producto_origenfiscal?.Existenciaremisionado != null)
                    Producto_origenfiscal_Existenciaremisionado = item.Producto_origenfiscal!.Existenciaremisionado;

            if (item.Producto_origenfiscal != null && item.Producto_origenfiscal?.Existenciaindefinido != null)
                    Producto_origenfiscal_Existenciaindefinido = item.Producto_origenfiscal!.Existenciaindefinido;

            if (item.Producto_origenfiscal != null && item.Producto_origenfiscal?.Ultimoorigenfiscalventa != null)
                    Producto_origenfiscal_Ultimoorigenfiscalventa = item.Producto_origenfiscal!.Ultimoorigenfiscalventa;

            if (item.Producto_origenfiscal != null && item.Producto_origenfiscal?.Exist_fac_intercambio != null)
                    Producto_origenfiscal_Exist_fac_intercambio = item.Producto_origenfiscal!.Exist_fac_intercambio;

            if (item.Producto_poliza != null && item.Producto_poliza?.Plazoid != null)
                    Producto_poliza_Plazoid = item.Producto_poliza!.Plazoid;

            if (item.Producto_poliza != null && item.Producto_poliza?.Cuentapredial != null)
                Producto_poliza_Cuentapredial = item.Producto_poliza!.Cuentapredial;

            if (item.Producto_precios != null && item.Producto_precios?.Mayokgs != null)
                    Producto_precios_Mayokgs = item.Producto_precios!.Mayokgs;

            if (item.Producto_precios != null && item.Producto_precios?.Tipoabc != null)
                    Producto_precios_Tipoabc = item.Producto_precios!.Tipoabc;

            if (item.Producto_precios != null && item.Producto_precios?.Precio1 != null)
                    Producto_precios_Precio1 = item.Producto_precios!.Precio1;

            if (item.Producto_precios != null && item.Producto_precios?.Precio2 != null)
                    Producto_precios_Precio2 = item.Producto_precios!.Precio2;

            if (item.Producto_precios != null && item.Producto_precios?.Precio3 != null)
                    Producto_precios_Precio3 = item.Producto_precios!.Precio3;

            if (item.Producto_precios != null && item.Producto_precios?.Precio4 != null)
                    Producto_precios_Precio4 = item.Producto_precios!.Precio4;

            if (item.Producto_precios != null && item.Producto_precios?.Precio5 != null)
                    Producto_precios_Precio5 = item.Producto_precios!.Precio5;

            if (item.Producto_precios != null && item.Producto_precios?.Precio6 != null)
                    Producto_precios_Precio6 = item.Producto_precios!.Precio6;

            if (item.Producto_precios != null && item.Producto_precios?.Costoultimo != null)
                    Producto_precios_Costoultimo = item.Producto_precios!.Costoultimo;

            if (item.Producto_precios != null && item.Producto_precios?.Costopromedio != null)
                    Producto_precios_Costopromedio = item.Producto_precios!.Costopromedio;

            if (item.Producto_precios != null && item.Producto_precios?.Costorepo != null)
                    Producto_precios_Costorepo = item.Producto_precios!.Costorepo;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio1 != null)
                    Producto_precios_Superprecio1 = item.Producto_precios!.Superprecio1;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio2 != null)
                    Producto_precios_Superprecio2 = item.Producto_precios!.Superprecio2;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio3 != null)
                    Producto_precios_Superprecio3 = item.Producto_precios!.Superprecio3;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio4 != null)
                    Producto_precios_Superprecio4 = item.Producto_precios!.Superprecio4;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio5 != null)
                    Producto_precios_Superprecio5 = item.Producto_precios!.Superprecio5;

            if (item.Producto_precios != null && item.Producto_precios?.Ini_mayo != null)
                    Producto_precios_Ini_mayo = item.Producto_precios!.Ini_mayo;

            if (item.Producto_precios != null && item.Producto_precios?.Listaprecmediomayid != null)
                    Producto_precios_Listaprecmediomayid = item.Producto_precios!.Listaprecmediomayid;

            if (item.Producto_precios != null && item.Producto_precios?.Listaprecmayoreoid != null)
                    Producto_precios_Listaprecmayoreoid = item.Producto_precios!.Listaprecmayoreoid;

            if (item.Producto_precios != null && item.Producto_precios?.Cantmediomay != null)
                    Producto_precios_Cantmediomay = item.Producto_precios!.Cantmediomay;

            if (item.Producto_precios != null && item.Producto_precios?.Cantmayoreo != null)
                    Producto_precios_Cantmayoreo = item.Producto_precios!.Cantmayoreo;


            if (item.Producto_precios != null && item.Producto_precios?.Limiteprecio2 != null)
                Producto_precios_Limiteprecio2 = item.Producto_precios!.Limiteprecio2;


            if (item.Producto_precios != null && item.Producto_precios?.Descuento != null)
                Producto_precios_Descuento = item.Producto_precios!.Descuento;

            if (item.Producto_precios != null && item.Producto_precios?.Menudeo != null)
                Producto_precios_Menudeo = item.Producto_precios!.Menudeo;

            if (item.Producto_precios != null && item.Producto_precios?.Preciomaximopublico != null)
                Producto_precios_Preciomaximopublico = item.Producto_precios!.Preciomaximopublico;

            if (item.Producto_precios != null && item.Producto_precios?.Costoendolar != null)
                Producto_precios_Costoendolar = item.Producto_precios!.Costoendolar;

            if (item.Producto_precios != null && item.Producto_precios?.Preciosugerido != null)
                Producto_precios_Preciosugerido = item.Producto_precios!.Preciosugerido;

            if (item.Producto_precios != null && item.Producto_precios?.Cambiarprecio != null)
                Producto_precios_Cambiarprecio = item.Producto_precios!.Cambiarprecio;

            if (item.Producto_precios != null && item.Producto_precios?.Fechacambioprecio != null)
                Producto_precios_Fechacambioprecio = item.Producto_precios!.Fechacambioprecio;

            if (item.Producto_precios != null && item.Producto_precios?.Preciomat != null)
                Producto_precios_Preciomat = item.Producto_precios!.Preciomat;

            if (item.Producto_precios != null && item.Producto_precios?.Oferta != null)
                Producto_precios_Oferta = item.Producto_precios!.Oferta;

            if (item.Producto_precios != null && item.Producto_precios?.Preciotope != null)
                Producto_precios_Preciotope = item.Producto_precios!.Preciotope;

            if (item.Producto_precios != null && item.Producto_precios?.Desctope != null)
                Producto_precios_Desctope = item.Producto_precios!.Desctope;

            if (item.Producto_precios != null && item.Producto_precios?.Margen != null)
                Producto_precios_Margen = item.Producto_precios!.Margen;

            if (item.Producto_precios != null && item.Producto_precios?.Descpes != null)
                Producto_precios_Descpes = item.Producto_precios!.Descpes;

            if (item.Producto_precios != null && item.Producto_precios?.Monedaid != null)
                Producto_precios_Monedaid = item.Producto_precios!.Monedaid;


            if (item.Producto_promocion != null && item.Producto_promocion?.Esprodpromo != null)
                    Producto_promocion_Esprodpromo = item.Producto_promocion!.Esprodpromo;

            if (item.Producto_promocion != null && item.Producto_promocion?.Baseprodpromoid != null)
                    Producto_promocion_Baseprodpromoid = item.Producto_promocion!.Baseprodpromoid;

            if (item.Producto_promocion != null && item.Producto_promocion?.Vigenciaprodpromo != null)
                    Producto_promocion_Vigenciaprodpromo = item.Producto_promocion!.Vigenciaprodpromo;

            if (item.Producto_miscelanea != null && item.Producto_miscelanea?.Clasificaid != null)
                    Producto_miscelanea_Clasificaid = item.Producto_miscelanea!.Clasificaid;

            if (item.Producto_miscelanea != null && item.Producto_miscelanea?.Contenidoid != null)
                    Producto_miscelanea_Contenidoid = item.Producto_miscelanea!.Contenidoid;

            if (item.Producto_miscelanea != null && item.Producto_miscelanea?.Contenidovalor != null)
                Producto_miscelanea_Contenidovalor = item.Producto_miscelanea!.Contenidovalor;

            if (item.Producto_miscelanea != null && item.Producto_miscelanea?.Imprimir != null)
                Producto_miscelanea_Imprimir = item.Producto_miscelanea!.Imprimir;

            if (item.Producto_miscelanea != null && item.Producto_miscelanea?.Imprimircomanda != null)
                Producto_miscelanea_Imprimircomanda = item.Producto_miscelanea!.Imprimircomanda;

            if (item.Producto_padre != null && item.Producto_padre?.Esproductopadre != null)
                    Producto_padre_Esproductopadre = item.Producto_padre!.Esproductopadre;

            if (item.Producto_padre != null && item.Producto_padre?.Essubproducto != null)
                    Producto_padre_Essubproducto = item.Producto_padre!.Essubproducto;

            if (item.Producto_padre != null && item.Producto_padre?.Tomarpreciopadre != null)
                    Producto_padre_Tomarpreciopadre = item.Producto_padre!.Tomarpreciopadre;

            if (item.Producto_padre != null && item.Producto_padre?.Tomarcomisionpadre != null)
                    Producto_padre_Tomarcomisionpadre = item.Producto_padre!.Tomarcomisionpadre;

            if (item.Producto_padre != null && item.Producto_padre?.Tomarofertapadre != null)
                    Producto_padre_Tomarofertapadre = item.Producto_padre!.Tomarofertapadre;

            if (item.Producto_padre != null && item.Producto_padre?.Productopadreid != null)
                    Producto_padre_Productopadreid = item.Producto_padre!.Productopadreid;

            if (item.Producto_utilidad != null && item.Producto_utilidad?.Minutilidad != null)
                    Producto_utilidad_Minutilidad = item.Producto_utilidad!.Minutilidad;

            if (item.Producto_utilidad != null && item.Producto_utilidad?.Porcutilprecio1 != null)
                    Producto_utilidad_Porcutilprecio1 = item.Producto_utilidad!.Porcutilprecio1;

            if (item.Producto_utilidad != null && item.Producto_utilidad?.Porcutilprecio2 != null)
                    Producto_utilidad_Porcutilprecio2 = item.Producto_utilidad!.Porcutilprecio2;

            if (item.Producto_utilidad != null && item.Producto_utilidad?.Porcutilprecio3 != null)
                    Producto_utilidad_Porcutilprecio3 = item.Producto_utilidad!.Porcutilprecio3;

            if (item.Producto_utilidad != null && item.Producto_utilidad?.Porcutilprecio4 != null)
                    Producto_utilidad_Porcutilprecio4 = item.Producto_utilidad!.Porcutilprecio4;

            if (item.Producto_utilidad != null && item.Producto_utilidad?.Porcutilprecio5 != null)
                    Producto_utilidad_Porcutilprecio5 = item.Producto_utilidad!.Porcutilprecio5;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Clave != null)
                    Productocaracteristicas_Clave = item.Productocaracteristicas!.Clave;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto1 != null)
                    Productocaracteristicas_Texto1 = item.Productocaracteristicas!.Texto1;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto2 != null)
                    Productocaracteristicas_Texto2 = item.Productocaracteristicas!.Texto2;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto3 != null)
                    Productocaracteristicas_Texto3 = item.Productocaracteristicas!.Texto3;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto4 != null)
                    Productocaracteristicas_Texto4 = item.Productocaracteristicas!.Texto4;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto5 != null)
                    Productocaracteristicas_Texto5 = item.Productocaracteristicas!.Texto5;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto6 != null)
                    Productocaracteristicas_Texto6 = item.Productocaracteristicas!.Texto6;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero1 != null)
                    Productocaracteristicas_Numero1 = item.Productocaracteristicas!.Numero1;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero2 != null)
                    Productocaracteristicas_Numero2 = item.Productocaracteristicas!.Numero2;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero3 != null)
                    Productocaracteristicas_Numero3 = item.Productocaracteristicas!.Numero3;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero4 != null)
                    Productocaracteristicas_Numero4 = item.Productocaracteristicas!.Numero4;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Fecha1 != null)
                    Productocaracteristicas_Fecha1 = item.Productocaracteristicas!.Fecha1;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Fecha2 != null)
                    Productocaracteristicas_Fecha2 = item.Productocaracteristicas!.Fecha2;


             FillCatalogRelatedFields(item);


        }
        #endif





    }
}

