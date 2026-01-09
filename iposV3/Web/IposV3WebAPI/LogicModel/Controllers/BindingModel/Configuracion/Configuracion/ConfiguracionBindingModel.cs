
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
    public class ConfiguracionBindingModel : Validatable
    {

        protected Configuracion? item;

        public ConfiguracionBindingModel()
        {
            item = new Configuracion();
        }
        public ConfiguracionBindingModel(Configuracion item)
        {
            this.item = item;
        }

        public Configuracion? Item { get => item; set => item = value; }



        [XmlAttribute]
        public string? Nombre { get => item?.Nombre; set { if (item != null && RaiseAcceptPendingChange(value, item.Nombre)) { item.Nombre = value; OnPropertyChanged(); } } }




        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string? Activo { get => item?.Activo; set { if (item != null && RaiseAcceptPendingChange(value, item.Activo)) { item.Activo = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Database { get => item?.Database; set { if (item != null && RaiseAcceptPendingChange(value, item.Database)) { item.Database = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Usuario { get => item?.Usuario; set { if (item != null && RaiseAcceptPendingChange(value, item.Usuario)) { item.Usuario = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Password { get => item?.Password; set { if (item != null && RaiseAcceptPendingChange(value, item.Password)) { item.Password = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Habilitar_impexp_aut { get => item?.Habilitar_impexp_aut; set { if (item != null && RaiseAcceptPendingChange(value, item.Habilitar_impexp_aut)) { item.Habilitar_impexp_aut = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Empresaclave { get => item?.Empresaclave; set { if (item != null && RaiseAcceptPendingChange(value, item.Empresaclave)) { item.Empresaclave = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Empresanombre { get => item?.Empresanombre; set { if (item != null && RaiseAcceptPendingChange(value, item.Empresanombre)) { item.Empresanombre = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Sucursalclave { get => item?.Sucursalclave; set { if (item != null && RaiseAcceptPendingChange(value, item.Sucursalclave)) { item.Sucursalclave = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Sucursalnombre { get => item?.Sucursalnombre; set { if (item != null && RaiseAcceptPendingChange(value, item.Sucursalnombre)) { item.Sucursalnombre = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Cajaclave { get => item?.Cajaclave; set { if (item != null && RaiseAcceptPendingChange(value, item.Cajaclave)) { item.Cajaclave = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Cajanombre { get => item?.Cajanombre; set { if (item != null && RaiseAcceptPendingChange(value, item.Cajanombre)) { item.Cajanombre = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Esmatriz { get => item?.Esmatriz; set { if (item != null && RaiseAcceptPendingChange(value, item.Esmatriz)) { item.Esmatriz = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Basedirectory { get => item?.Basedirectory; set { if (item != null && RaiseAcceptPendingChange(value, item.Basedirectory)) { item.Basedirectory = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Hab_pooling { get => item?.Hab_pooling; set { if (item != null && RaiseAcceptPendingChange(value, item.Hab_pooling)) { item.Hab_pooling = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Replicador { get => item?.Replicador; set { if (item != null && RaiseAcceptPendingChange(value, item.Replicador)) { item.Replicador = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Servidor { get => item?.Servidor; set { if (item != null && RaiseAcceptPendingChange(value, item.Servidor)) { item.Servidor = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Puerto { get => item?.Puerto; set { if (item != null && RaiseAcceptPendingChange(value, item.Puerto)) { item.Puerto = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public string? Esdefault { get => item?.Esdefault; set { if (item != null && RaiseAcceptPendingChange(value, item.Esdefault)) { item.Esdefault = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public long? Id { get => item?.Id; set { if (item != null && RaiseAcceptPendingChange(value, item.Id)) { item.Id = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? Empresaid { get => item?.Empresaid; set { if (item != null && RaiseAcceptPendingChange(value, item.Empresaid)) { item.Empresaid = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? Sucursalid { get => item?.Sucursalid; set { if (item != null && RaiseAcceptPendingChange(value, item.Sucursalid)) { item.Sucursalid = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public DateTimeOffset? Creado { get => item?.Creado; set { if (item != null && RaiseAcceptPendingChange(value, item.Creado)) { item.Creado = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public long? Creadopor_userid { get => item?.Creadopor_userid; set { if (item != null && RaiseAcceptPendingChange(value, item.Creadopor_userid)) { item.Creadopor_userid = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public DateTimeOffset? Modificado { get => item?.Modificado; set { if (item != null && RaiseAcceptPendingChange(value, item.Modificado)) { item.Modificado = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public long? Modificadopor_userid { get => item?.Modificadopor_userid; set { if (item != null && RaiseAcceptPendingChange(value, item.Modificadopor_userid)) { item.Modificadopor_userid = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public long? Cajaid { get => item?.Cajaid; set { if (item != null && RaiseAcceptPendingChange(value, item.Cajaid)) { item.Cajaid = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public int? Red { get => item?.Red; set { if (item != null && RaiseAcceptPendingChange(value, item.Red)) { item.Red = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public int? Blue { get => item?.Blue; set { if (item != null && RaiseAcceptPendingChange(value, item.Blue)) { item.Blue = value; OnPropertyChanged(); } } }


        [XmlAttribute]
        public int? Green { get => item?.Green; set { if (item != null && RaiseAcceptPendingChange(value, item.Green)) { item.Green = value; OnPropertyChanged(); } } }


        public long? Usuarioid { get; set; }

    }

    public class ConfigurationAction
    {
        public string? Action { get; set; }
        public List<string>? Parameters { get; set; }
    }
}

