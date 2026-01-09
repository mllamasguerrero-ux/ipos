
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
    
    public class CartaporteBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CartaporteBindingModelGenerated()
        {
        }
        public CartaporteBindingModelGenerated(Cartaporte item)
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

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private string? _DoctoClave;
        [XmlAttribute]
        public string? DoctoClave { get => _DoctoClave; set { if (RaiseAcceptPendingChange(value, _DoctoClave)) { _DoctoClave = value; OnPropertyChanged(); } } }

        private string? _DoctoNombre;
        [XmlAttribute]
        public string? DoctoNombre { get => _DoctoNombre; set { if (RaiseAcceptPendingChange(value, _DoctoNombre)) { _DoctoNombre = value; OnPropertyChanged(); } } }

        private string? _TranspInternac;
        [XmlAttribute]
        public string? TranspInternac { get => _TranspInternac; set { if (RaiseAcceptPendingChange(value, _TranspInternac)) { _TranspInternac = value; OnPropertyChanged(); } } }

        private string? _EntradaSalidaMerc;
        [XmlAttribute]
        public string? EntradaSalidaMerc { get => _EntradaSalidaMerc; set { if (RaiseAcceptPendingChange(value, _EntradaSalidaMerc)) { _EntradaSalidaMerc = value; OnPropertyChanged(); } } }

        private string? _PaisOrigenDestino;
        [XmlAttribute]
        public string? PaisOrigenDestino { get => _PaisOrigenDestino; set { if (RaiseAcceptPendingChange(value, _PaisOrigenDestino)) { _PaisOrigenDestino = value; OnPropertyChanged(); } } }

        private string? _ViaEntradaSalida;
        [XmlAttribute]
        public string? ViaEntradaSalida { get => _ViaEntradaSalida; set { if (RaiseAcceptPendingChange(value, _ViaEntradaSalida)) { _ViaEntradaSalida = value; OnPropertyChanged(); } } }

        private string? _TotalDistRec;
        [XmlAttribute]
        public string? TotalDistRec { get => _TotalDistRec; set { if (RaiseAcceptPendingChange(value, _TotalDistRec)) { _TotalDistRec = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_TranspInternac;
        [XmlAttribute]
        public string? CartaporteAutotransps_TranspInternac { get => _CartaporteAutotransps_TranspInternac; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_TranspInternac)) { _CartaporteAutotransps_TranspInternac = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Permsct;
        [XmlAttribute]
        public string? CartaporteAutotransps_Permsct { get => _CartaporteAutotransps_Permsct; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Permsct)) { _CartaporteAutotransps_Permsct = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Numpermisosct;
        [XmlAttribute]
        public string? CartaporteAutotransps_Numpermisosct { get => _CartaporteAutotransps_Numpermisosct; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Numpermisosct)) { _CartaporteAutotransps_Numpermisosct = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Configvehicular;
        [XmlAttribute]
        public string? CartaporteAutotransps_Configvehicular { get => _CartaporteAutotransps_Configvehicular; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Configvehicular)) { _CartaporteAutotransps_Configvehicular = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Placavm;
        [XmlAttribute]
        public string? CartaporteAutotransps_Placavm { get => _CartaporteAutotransps_Placavm; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Placavm)) { _CartaporteAutotransps_Placavm = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Aniomodelovm;
        [XmlAttribute]
        public string? CartaporteAutotransps_Aniomodelovm { get => _CartaporteAutotransps_Aniomodelovm; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Aniomodelovm)) { _CartaporteAutotransps_Aniomodelovm = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Asegurarespcivil;
        [XmlAttribute]
        public string? CartaporteAutotransps_Asegurarespcivil { get => _CartaporteAutotransps_Asegurarespcivil; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Asegurarespcivil)) { _CartaporteAutotransps_Asegurarespcivil = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Polizarespcivil;
        [XmlAttribute]
        public string? CartaporteAutotransps_Polizarespcivil { get => _CartaporteAutotransps_Polizarespcivil; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Polizarespcivil)) { _CartaporteAutotransps_Polizarespcivil = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Aseguramedambiente;
        [XmlAttribute]
        public string? CartaporteAutotransps_Aseguramedambiente { get => _CartaporteAutotransps_Aseguramedambiente; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Aseguramedambiente)) { _CartaporteAutotransps_Aseguramedambiente = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Polizamedambiente;
        [XmlAttribute]
        public string? CartaporteAutotransps_Polizamedambiente { get => _CartaporteAutotransps_Polizamedambiente; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Polizamedambiente)) { _CartaporteAutotransps_Polizamedambiente = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Aseguracarga;
        [XmlAttribute]
        public string? CartaporteAutotransps_Aseguracarga { get => _CartaporteAutotransps_Aseguracarga; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Aseguracarga)) { _CartaporteAutotransps_Aseguracarga = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Polizacarga;
        [XmlAttribute]
        public string? CartaporteAutotransps_Polizacarga { get => _CartaporteAutotransps_Polizacarga; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Polizacarga)) { _CartaporteAutotransps_Polizacarga = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Primaseguro;
        [XmlAttribute]
        public string? CartaporteAutotransps_Primaseguro { get => _CartaporteAutotransps_Primaseguro; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Primaseguro)) { _CartaporteAutotransps_Primaseguro = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Subtiporem1;
        [XmlAttribute]
        public string? CartaporteAutotransps_Subtiporem1 { get => _CartaporteAutotransps_Subtiporem1; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Subtiporem1)) { _CartaporteAutotransps_Subtiporem1 = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Placa1;
        [XmlAttribute]
        public string? CartaporteAutotransps_Placa1 { get => _CartaporteAutotransps_Placa1; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Placa1)) { _CartaporteAutotransps_Placa1 = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Subtiporem2;
        [XmlAttribute]
        public string? CartaporteAutotransps_Subtiporem2 { get => _CartaporteAutotransps_Subtiporem2; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Subtiporem2)) { _CartaporteAutotransps_Subtiporem2 = value; OnPropertyChanged(); } } }

        private string? _CartaporteAutotransps_Placa2;
        [XmlAttribute]
        public string? CartaporteAutotransps_Placa2 { get => _CartaporteAutotransps_Placa2; set { if (RaiseAcceptPendingChange(value, _CartaporteAutotransps_Placa2)) { _CartaporteAutotransps_Placa2 = value; OnPropertyChanged(); } } }

        private string? _CartaporteCanttransps_Cantidad;
        [XmlAttribute]
        public string? CartaporteCanttransps_Cantidad { get => _CartaporteCanttransps_Cantidad; set { if (RaiseAcceptPendingChange(value, _CartaporteCanttransps_Cantidad)) { _CartaporteCanttransps_Cantidad = value; OnPropertyChanged(); } } }

        private string? _CartaporteCanttransps_Idorigen;
        [XmlAttribute]
        public string? CartaporteCanttransps_Idorigen { get => _CartaporteCanttransps_Idorigen; set { if (RaiseAcceptPendingChange(value, _CartaporteCanttransps_Idorigen)) { _CartaporteCanttransps_Idorigen = value; OnPropertyChanged(); } } }

        private string? _CartaporteCanttransps_Iddestino;
        [XmlAttribute]
        public string? CartaporteCanttransps_Iddestino { get => _CartaporteCanttransps_Iddestino; set { if (RaiseAcceptPendingChange(value, _CartaporteCanttransps_Iddestino)) { _CartaporteCanttransps_Iddestino = value; OnPropertyChanged(); } } }

        private string? _CartaporteCanttransps_Cvestransporte;
        [XmlAttribute]
        public string? CartaporteCanttransps_Cvestransporte { get => _CartaporteCanttransps_Cvestransporte; set { if (RaiseAcceptPendingChange(value, _CartaporteCanttransps_Cvestransporte)) { _CartaporteCanttransps_Cvestransporte = value; OnPropertyChanged(); } } }

        private string? _CartaporteTotalmercancias_Pesobrutototal;
        [XmlAttribute]
        public string? CartaporteTotalmercancias_Pesobrutototal { get => _CartaporteTotalmercancias_Pesobrutototal; set { if (RaiseAcceptPendingChange(value, _CartaporteTotalmercancias_Pesobrutototal)) { _CartaporteTotalmercancias_Pesobrutototal = value; OnPropertyChanged(); } } }

        private string? _CartaporteTotalmercancias_Unidadpeso;
        [XmlAttribute]
        public string? CartaporteTotalmercancias_Unidadpeso { get => _CartaporteTotalmercancias_Unidadpeso; set { if (RaiseAcceptPendingChange(value, _CartaporteTotalmercancias_Unidadpeso)) { _CartaporteTotalmercancias_Unidadpeso = value; OnPropertyChanged(); } } }

        private string? _CartaporteTotalmercancias_Pesonetototal;
        [XmlAttribute]
        public string? CartaporteTotalmercancias_Pesonetototal { get => _CartaporteTotalmercancias_Pesonetototal; set { if (RaiseAcceptPendingChange(value, _CartaporteTotalmercancias_Pesonetototal)) { _CartaporteTotalmercancias_Pesonetototal = value; OnPropertyChanged(); } } }

        private string? _CartaporteTotalmercancias_Numtotalmercancias;
        [XmlAttribute]
        public string? CartaporteTotalmercancias_Numtotalmercancias { get => _CartaporteTotalmercancias_Numtotalmercancias; set { if (RaiseAcceptPendingChange(value, _CartaporteTotalmercancias_Numtotalmercancias)) { _CartaporteTotalmercancias_Numtotalmercancias = value; OnPropertyChanged(); } } }

        private string? _CartaporteTotalmercancias_Cargoportasacion;
        [XmlAttribute]
        public string? CartaporteTotalmercancias_Cargoportasacion { get => _CartaporteTotalmercancias_Cargoportasacion; set { if (RaiseAcceptPendingChange(value, _CartaporteTotalmercancias_Cargoportasacion)) { _CartaporteTotalmercancias_Cargoportasacion = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Cartaporte"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Docto.Clave|Docto.Nombre|TranspInternac|EntradaSalidaMerc|PaisOrigenDestino|ViaEntradaSalida|TotalDistRec|Clave|Nombre|CartaporteAutotransps.TranspInternac|CartaporteAutotransps.Permsct|CartaporteAutotransps.Numpermisosct|CartaporteAutotransps.Configvehicular|CartaporteAutotransps.Placavm|CartaporteAutotransps.Aniomodelovm|CartaporteAutotransps.Asegurarespcivil|CartaporteAutotransps.Polizarespcivil|CartaporteAutotransps.Aseguramedambiente|CartaporteAutotransps.Polizamedambiente|CartaporteAutotransps.Aseguracarga|CartaporteAutotransps.Polizacarga|CartaporteAutotransps.Primaseguro|CartaporteAutotransps.Subtiporem1|CartaporteAutotransps.Placa1|CartaporteAutotransps.Subtiporem2|CartaporteAutotransps.Placa2|CartaporteCanttransps.Cantidad|CartaporteCanttransps.Idorigen|CartaporteCanttransps.Iddestino|CartaporteCanttransps.Cvestransporte|CartaporteTotalmercancias.Pesobrutototal|CartaporteTotalmercancias.Unidadpeso|CartaporteTotalmercancias.Pesonetototal|CartaporteTotalmercancias.Numtotalmercancias|CartaporteTotalmercancias.Cargoportasacion";
        }


        public void FillCatalogRelatedFields(Cartaporte item)
        {

             this._DoctoClave = item.Docto?.Clave;

             this._DoctoNombre = item.Docto?.Nombre;


        }


        public void FillEntityValues(ref Cartaporte item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Doctoid = Doctoid ;


            item.TranspInternac = TranspInternac ;


            item.EntradaSalidaMerc = EntradaSalidaMerc ;


            item.PaisOrigenDestino = PaisOrigenDestino ;


            item.ViaEntradaSalida = ViaEntradaSalida ;


            item.TotalDistRec = TotalDistRec ;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.TranspInternac = CartaporteAutotransps_TranspInternac;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_TranspInternac != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.TranspInternac = CartaporteAutotransps_TranspInternac;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Permsct = CartaporteAutotransps_Permsct;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Permsct != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Permsct = CartaporteAutotransps_Permsct;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Numpermisosct = CartaporteAutotransps_Numpermisosct;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Numpermisosct != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Numpermisosct = CartaporteAutotransps_Numpermisosct;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Configvehicular = CartaporteAutotransps_Configvehicular;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Configvehicular != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Configvehicular = CartaporteAutotransps_Configvehicular;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Placavm = CartaporteAutotransps_Placavm;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Placavm != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Placavm = CartaporteAutotransps_Placavm;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Aniomodelovm = CartaporteAutotransps_Aniomodelovm;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Aniomodelovm != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Aniomodelovm = CartaporteAutotransps_Aniomodelovm;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Asegurarespcivil = CartaporteAutotransps_Asegurarespcivil;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Asegurarespcivil != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Asegurarespcivil = CartaporteAutotransps_Asegurarespcivil;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Polizarespcivil = CartaporteAutotransps_Polizarespcivil;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Polizarespcivil != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Polizarespcivil = CartaporteAutotransps_Polizarespcivil;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Aseguramedambiente = CartaporteAutotransps_Aseguramedambiente;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Aseguramedambiente != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Aseguramedambiente = CartaporteAutotransps_Aseguramedambiente;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Polizamedambiente = CartaporteAutotransps_Polizamedambiente;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Polizamedambiente != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Polizamedambiente = CartaporteAutotransps_Polizamedambiente;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Aseguracarga = CartaporteAutotransps_Aseguracarga;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Aseguracarga != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Aseguracarga = CartaporteAutotransps_Aseguracarga;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Polizacarga = CartaporteAutotransps_Polizacarga;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Polizacarga != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Polizacarga = CartaporteAutotransps_Polizacarga;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Primaseguro = CartaporteAutotransps_Primaseguro;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Primaseguro != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Primaseguro = CartaporteAutotransps_Primaseguro;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Subtiporem1 = CartaporteAutotransps_Subtiporem1;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Subtiporem1 != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Subtiporem1 = CartaporteAutotransps_Subtiporem1;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Placa1 = CartaporteAutotransps_Placa1;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Placa1 != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Placa1 = CartaporteAutotransps_Placa1;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Subtiporem2 = CartaporteAutotransps_Subtiporem2;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Subtiporem2 != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Subtiporem2 = CartaporteAutotransps_Subtiporem2;
            }

            if (item.CartaporteAutotransps != null)
                item.CartaporteAutotransps!.Placa2 = CartaporteAutotransps_Placa2;
            else if (item.CartaporteAutotransps == null && CartaporteAutotransps_Placa2 != null)
            {
                item.CartaporteAutotransps = CreateSubEntity<CartaporteAutotransp>();
                item.CartaporteAutotransps!.Placa2 = CartaporteAutotransps_Placa2;
            }

            if (item.CartaporteCanttransps != null)
                item.CartaporteCanttransps!.Cantidad = CartaporteCanttransps_Cantidad;
            else if (item.CartaporteCanttransps == null && CartaporteCanttransps_Cantidad != null)
            {
                item.CartaporteCanttransps = CreateSubEntity<CartaporteCanttransp>();
                item.CartaporteCanttransps!.Cantidad = CartaporteCanttransps_Cantidad;
            }

            if (item.CartaporteCanttransps != null)
                item.CartaporteCanttransps!.Idorigen = CartaporteCanttransps_Idorigen;
            else if (item.CartaporteCanttransps == null && CartaporteCanttransps_Idorigen != null)
            {
                item.CartaporteCanttransps = CreateSubEntity<CartaporteCanttransp>();
                item.CartaporteCanttransps!.Idorigen = CartaporteCanttransps_Idorigen;
            }

            if (item.CartaporteCanttransps != null)
                item.CartaporteCanttransps!.Iddestino = CartaporteCanttransps_Iddestino;
            else if (item.CartaporteCanttransps == null && CartaporteCanttransps_Iddestino != null)
            {
                item.CartaporteCanttransps = CreateSubEntity<CartaporteCanttransp>();
                item.CartaporteCanttransps!.Iddestino = CartaporteCanttransps_Iddestino;
            }

            if (item.CartaporteCanttransps != null)
                item.CartaporteCanttransps!.Cvestransporte = CartaporteCanttransps_Cvestransporte;
            else if (item.CartaporteCanttransps == null && CartaporteCanttransps_Cvestransporte != null)
            {
                item.CartaporteCanttransps = CreateSubEntity<CartaporteCanttransp>();
                item.CartaporteCanttransps!.Cvestransporte = CartaporteCanttransps_Cvestransporte;
            }

            if (item.CartaporteTotalmercancias != null)
                item.CartaporteTotalmercancias!.Pesobrutototal = CartaporteTotalmercancias_Pesobrutototal;
            else if (item.CartaporteTotalmercancias == null && CartaporteTotalmercancias_Pesobrutototal != null)
            {
                item.CartaporteTotalmercancias = CreateSubEntity<CartaporteTotalmercancias>();
                item.CartaporteTotalmercancias!.Pesobrutototal = CartaporteTotalmercancias_Pesobrutototal;
            }

            if (item.CartaporteTotalmercancias != null)
                item.CartaporteTotalmercancias!.Unidadpeso = CartaporteTotalmercancias_Unidadpeso;
            else if (item.CartaporteTotalmercancias == null && CartaporteTotalmercancias_Unidadpeso != null)
            {
                item.CartaporteTotalmercancias = CreateSubEntity<CartaporteTotalmercancias>();
                item.CartaporteTotalmercancias!.Unidadpeso = CartaporteTotalmercancias_Unidadpeso;
            }

            if (item.CartaporteTotalmercancias != null)
                item.CartaporteTotalmercancias!.Pesonetototal = CartaporteTotalmercancias_Pesonetototal;
            else if (item.CartaporteTotalmercancias == null && CartaporteTotalmercancias_Pesonetototal != null)
            {
                item.CartaporteTotalmercancias = CreateSubEntity<CartaporteTotalmercancias>();
                item.CartaporteTotalmercancias!.Pesonetototal = CartaporteTotalmercancias_Pesonetototal;
            }

            if (item.CartaporteTotalmercancias != null)
                item.CartaporteTotalmercancias!.Numtotalmercancias = CartaporteTotalmercancias_Numtotalmercancias;
            else if (item.CartaporteTotalmercancias == null && CartaporteTotalmercancias_Numtotalmercancias != null)
            {
                item.CartaporteTotalmercancias = CreateSubEntity<CartaporteTotalmercancias>();
                item.CartaporteTotalmercancias!.Numtotalmercancias = CartaporteTotalmercancias_Numtotalmercancias;
            }

            if (item.CartaporteTotalmercancias != null)
                item.CartaporteTotalmercancias!.Cargoportasacion = CartaporteTotalmercancias_Cargoportasacion;
            else if (item.CartaporteTotalmercancias == null && CartaporteTotalmercancias_Cargoportasacion != null)
            {
                item.CartaporteTotalmercancias = CreateSubEntity<CartaporteTotalmercancias>();
                item.CartaporteTotalmercancias!.Cargoportasacion = CartaporteTotalmercancias_Cargoportasacion;
            }


        }

        public void FillFromEntity(Cartaporte item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Doctoid = item.Doctoid;

            TranspInternac = item.TranspInternac;

            EntradaSalidaMerc = item.EntradaSalidaMerc;

            PaisOrigenDestino = item.PaisOrigenDestino;

            ViaEntradaSalida = item.ViaEntradaSalida;

            TotalDistRec = item.TotalDistRec;

            Clave = item.Clave;

            Nombre = item.Nombre;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.TranspInternac != null)
                    CartaporteAutotransps_TranspInternac = item.CartaporteAutotransps!.TranspInternac;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Permsct != null)
                    CartaporteAutotransps_Permsct = item.CartaporteAutotransps!.Permsct;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Numpermisosct != null)
                    CartaporteAutotransps_Numpermisosct = item.CartaporteAutotransps!.Numpermisosct;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Configvehicular != null)
                    CartaporteAutotransps_Configvehicular = item.CartaporteAutotransps!.Configvehicular;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Placavm != null)
                    CartaporteAutotransps_Placavm = item.CartaporteAutotransps!.Placavm;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Aniomodelovm != null)
                    CartaporteAutotransps_Aniomodelovm = item.CartaporteAutotransps!.Aniomodelovm;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Asegurarespcivil != null)
                    CartaporteAutotransps_Asegurarespcivil = item.CartaporteAutotransps!.Asegurarespcivil;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Polizarespcivil != null)
                    CartaporteAutotransps_Polizarespcivil = item.CartaporteAutotransps!.Polizarespcivil;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Aseguramedambiente != null)
                    CartaporteAutotransps_Aseguramedambiente = item.CartaporteAutotransps!.Aseguramedambiente;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Polizamedambiente != null)
                    CartaporteAutotransps_Polizamedambiente = item.CartaporteAutotransps!.Polizamedambiente;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Aseguracarga != null)
                    CartaporteAutotransps_Aseguracarga = item.CartaporteAutotransps!.Aseguracarga;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Polizacarga != null)
                    CartaporteAutotransps_Polizacarga = item.CartaporteAutotransps!.Polizacarga;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Primaseguro != null)
                    CartaporteAutotransps_Primaseguro = item.CartaporteAutotransps!.Primaseguro;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Subtiporem1 != null)
                    CartaporteAutotransps_Subtiporem1 = item.CartaporteAutotransps!.Subtiporem1;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Placa1 != null)
                    CartaporteAutotransps_Placa1 = item.CartaporteAutotransps!.Placa1;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Subtiporem2 != null)
                    CartaporteAutotransps_Subtiporem2 = item.CartaporteAutotransps!.Subtiporem2;

            if (item.CartaporteAutotransps != null && item.CartaporteAutotransps?.Placa2 != null)
                    CartaporteAutotransps_Placa2 = item.CartaporteAutotransps!.Placa2;

            if (item.CartaporteCanttransps != null && item.CartaporteCanttransps?.Cantidad != null)
                    CartaporteCanttransps_Cantidad = item.CartaporteCanttransps!.Cantidad;

            if (item.CartaporteCanttransps != null && item.CartaporteCanttransps?.Idorigen != null)
                    CartaporteCanttransps_Idorigen = item.CartaporteCanttransps!.Idorigen;

            if (item.CartaporteCanttransps != null && item.CartaporteCanttransps?.Iddestino != null)
                    CartaporteCanttransps_Iddestino = item.CartaporteCanttransps!.Iddestino;

            if (item.CartaporteCanttransps != null && item.CartaporteCanttransps?.Cvestransporte != null)
                    CartaporteCanttransps_Cvestransporte = item.CartaporteCanttransps!.Cvestransporte;

            if (item.CartaporteTotalmercancias != null && item.CartaporteTotalmercancias?.Pesobrutototal != null)
                    CartaporteTotalmercancias_Pesobrutototal = item.CartaporteTotalmercancias!.Pesobrutototal;

            if (item.CartaporteTotalmercancias != null && item.CartaporteTotalmercancias?.Unidadpeso != null)
                    CartaporteTotalmercancias_Unidadpeso = item.CartaporteTotalmercancias!.Unidadpeso;

            if (item.CartaporteTotalmercancias != null && item.CartaporteTotalmercancias?.Pesonetototal != null)
                    CartaporteTotalmercancias_Pesonetototal = item.CartaporteTotalmercancias!.Pesonetototal;

            if (item.CartaporteTotalmercancias != null && item.CartaporteTotalmercancias?.Numtotalmercancias != null)
                    CartaporteTotalmercancias_Numtotalmercancias = item.CartaporteTotalmercancias!.Numtotalmercancias;

            if (item.CartaporteTotalmercancias != null && item.CartaporteTotalmercancias?.Cargoportasacion != null)
                    CartaporteTotalmercancias_Cargoportasacion = item.CartaporteTotalmercancias!.Cargoportasacion;


             FillCatalogRelatedFields(item);


        }



    }
}

