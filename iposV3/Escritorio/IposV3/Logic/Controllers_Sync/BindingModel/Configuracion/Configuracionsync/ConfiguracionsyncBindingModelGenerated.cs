
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model.Syncr;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    [XmlRoot]
    public class ConfiguracionsyncBindingModelGenerated: Validatable, IBaseBindingModel
    {

        protected Configuracionsync item;

        public ConfiguracionsyncBindingModelGenerated()
        {
            item = new Configuracionsync();
        }
        public ConfiguracionsyncBindingModelGenerated(Configuracionsync item)
        {
            this.item = item;
        }

        public Configuracionsync Item { get => item; set => item = value; }



        public long? EmpresaId { get; set; }

        public long? SucursalId { get; set; }

        public long? CreadoPorId { get; set; }

        public long? ModificadoPorId { get; set; }



        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
    public string? Activo { get => item?.Activo ; set { if (item != null && RaiseAcceptPendingChange(value, item.Activo)) { item.Activo  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Empresaclave { get => item?.Empresaclave ; set { if (item != null && RaiseAcceptPendingChange(value, item.Empresaclave)) { item.Empresaclave  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Empresanombre { get => item?.Empresanombre ; set { if (item != null && RaiseAcceptPendingChange(value, item.Empresanombre)) { item.Empresanombre  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Sucursalclave { get => item?.Sucursalclave ; set { if (item != null && RaiseAcceptPendingChange(value, item.Sucursalclave)) { item.Sucursalclave  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Sucursalnombre { get => item?.Sucursalnombre ; set { if (item != null && RaiseAcceptPendingChange(value, item.Sucursalnombre)) { item.Sucursalnombre  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Dblocal { get => item?.Dblocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Dblocal)) { item.Dblocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Usuariolocal { get => item?.Usuariolocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Usuariolocal)) { item.Usuariolocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Passwordlocal { get => item?.Passwordlocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Passwordlocal)) { item.Passwordlocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Dbdestino { get => item?.Dbdestino ; set { if (item != null && RaiseAcceptPendingChange(value, item.Dbdestino)) { item.Dbdestino  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Usuariodestino { get => item?.Usuariodestino ; set { if (item != null && RaiseAcceptPendingChange(value, item.Usuariodestino)) { item.Usuariodestino  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Passworddestino { get => item?.Passworddestino ; set { if (item != null && RaiseAcceptPendingChange(value, item.Passworddestino)) { item.Passworddestino  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Dbtype { get => item?.Dbtype ; set { if (item != null && RaiseAcceptPendingChange(value, item.Dbtype)) { item.Dbtype  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Logactivo { get => item?.Logactivo ; set { if (item != null && RaiseAcceptPendingChange(value, item.Logactivo)) { item.Logactivo  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Correraliniciar { get => item?.Correraliniciar ; set { if (item != null && RaiseAcceptPendingChange(value, item.Correraliniciar)) { item.Correraliniciar  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Limitarhora { get => item?.Limitarhora ; set { if (item != null && RaiseAcceptPendingChange(value, item.Limitarhora)) { item.Limitarhora  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Horainicial { get => item?.Horainicial ; set { if (item != null && RaiseAcceptPendingChange(value, item.Horainicial)) { item.Horainicial  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Horafinal { get => item?.Horafinal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Horafinal)) { item.Horafinal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Timeformat { get => item?.Timeformat ; set { if (item != null && RaiseAcceptPendingChange(value, item.Timeformat)) { item.Timeformat  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Nummaxregistros { get => item?.Nummaxregistros ; set { if (item != null && RaiseAcceptPendingChange(value, item.Nummaxregistros)) { item.Nummaxregistros  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Usuarioiposlocal { get => item?.Usuarioiposlocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Usuarioiposlocal)) { item.Usuarioiposlocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Passwordiposlocal { get => item?.Passwordiposlocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Passwordiposlocal)) { item.Passwordiposlocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Activarreplicacion { get => item?.Activarreplicacion ; set { if (item != null && RaiseAcceptPendingChange(value, item.Activarreplicacion)) { item.Activarreplicacion  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Activarsyncsuc { get => item?.Activarsyncsuc ; set { if (item != null && RaiseAcceptPendingChange(value, item.Activarsyncsuc)) { item.Activarsyncsuc  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Serverlocal { get => item?.Serverlocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Serverlocal)) { item.Serverlocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Serverdestino { get => item?.Serverdestino ; set { if (item != null && RaiseAcceptPendingChange(value, item.Serverdestino)) { item.Serverdestino  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Portlocal { get => item?.Portlocal ; set { if (item != null && RaiseAcceptPendingChange(value, item.Portlocal)) { item.Portlocal  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public string? Portdestino { get => item?.Portdestino ; set { if (item != null && RaiseAcceptPendingChange(value, item.Portdestino)) { item.Portdestino  = value; OnPropertyChanged(); } } }


    [XmlAttribute][Required(ErrorMessage = "Es requerido")]
    public long? Empresaid { get => item?.Empresaid ; set { if (item != null && RaiseAcceptPendingChange(value, item.Empresaid)) { item.Empresaid  = value; OnPropertyChanged(); } } }


    [XmlAttribute][Required(ErrorMessage = "Es requerido")]
    public long? Sucursalid { get => item?.Sucursalid ; set { if (item != null && RaiseAcceptPendingChange(value, item.Sucursalid)) { item.Sucursalid  = value; OnPropertyChanged(); } } }


    [XmlAttribute][Required(ErrorMessage = "Es requerido")]
    public long? Id { get => item?.Id ; set { if (item != null && RaiseAcceptPendingChange(value, item.Id)) { item.Id  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public DateTimeOffset? Creado { get => item?.Creado ; set { if (item != null && RaiseAcceptPendingChange(value, item.Creado)) { item.Creado  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public long? Creadopor_userid { get => item?.Creadopor_userid ; set { if (item != null && RaiseAcceptPendingChange(value, item.Creadopor_userid)) { item.Creadopor_userid  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public DateTimeOffset? Modificado { get => item?.Modificado ; set { if (item != null && RaiseAcceptPendingChange(value, item.Modificado)) { item.Modificado  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public long? Modificadopor_userid { get => item?.Modificadopor_userid ; set { if (item != null && RaiseAcceptPendingChange(value, item.Modificadopor_userid)) { item.Modificadopor_userid  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public int? Lastlog { get => item?.Lastlog ; set { if (item != null && RaiseAcceptPendingChange(value, item.Lastlog)) { item.Lastlog  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public int? Firstlog { get => item?.Firstlog ; set { if (item != null && RaiseAcceptPendingChange(value, item.Firstlog)) { item.Firstlog  = value; OnPropertyChanged(); } } }


    [XmlAttribute]
    public int? Esperaentreenvios { get => item?.Esperaentreenvios ; set { if (item != null && RaiseAcceptPendingChange(value, item.Esperaentreenvios)) { item.Esperaentreenvios  = value; OnPropertyChanged(); } } }



    }
}

