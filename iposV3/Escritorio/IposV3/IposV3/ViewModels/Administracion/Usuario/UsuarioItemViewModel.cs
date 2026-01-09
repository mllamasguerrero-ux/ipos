
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class UsuarioItemViewModel : BaseWebRecordViewModel<UsuarioBindingModel, UsuarioWebController, UsuarioItemVMInitialParameters, UsuarioListVMEventParameters>
    {

        public UsuarioBindingModel? Usuario { get { return Record; } set { Record = value; } }

        public List<UsuarioPerfilItemBindingModel> UsuarioPerfilItems { get; set; }
        public UsuarioItemViewModel(string mode, UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

            UsuarioPerfilItems = new List<UsuarioPerfilItemBindingModel>();
        }


        private Dictionary<string, object> formasPagoItems = new Dictionary<string, object>();
        public Dictionary<string, object> FormasPagoItems { get => formasPagoItems; set { formasPagoItems = value; NotifyOfPropertyChange("FormasPagoItems"); } }


        private Dictionary<string, object> selectedFormasPagoItems = new Dictionary<string, object>();
        public Dictionary<string, object> SelectedFormasPagoItems { get => selectedFormasPagoItems; set { selectedFormasPagoItems = value; NotifyOfPropertyChange("SelectedFormasPagoItems"); } }



        protected override async void fillRecordToEdit(UsuarioItemVMInitialParameters initialParameters)
        {
            base.fillRecordToEdit(initialParameters);

            this.SelectedFormasPagoItems = StringToMultiselect(this.FormasPagoItems, Record!.Clieformaspagodef ?? "");

            UsuarioBindingModel item = new UsuarioBindingModel();

            item.Id = initialParameters.Id;
            item.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            item.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            var kendoParams = new KendoParams("", @"");
            UsuarioPerfilItems = await provider.GetUsuariosPerfiles(item, kendoParams) ?? new List<UsuarioPerfilItemBindingModel>();

        }



        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Usuario","Grupousuario","Usuario_Preferencias_Grupousuarioid", "Usuario_Preferencias_GrupousuarioClave", "Usuario_Preferencias_GrupousuarioNombre","IposV3.ViewModels.GrupousuarioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Almacen","Usuario_Preferencias_Almacenid", "Usuario_Preferencias_AlmacenClave", "Usuario_Preferencias_AlmacenNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Clerkpagoservicio","Usuario_emida_Clerkpagoserviciosid", "Usuario_emida_ClerkpagoserviciosClave", "Usuario_emida_ClerkpagoserviciosNombre","IposV3.ViewModels.ClerkpagoservicioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Clerkpagoservicio","Usuario_emida_Clerkservicios", "Usuario_emida_Clerkservicios_Clave", "Usuario_emida_Clerkservicios_Nombre","IposV3.ViewModels.ClerkpagoservicioListViewModel","SelectedItem","Clave")

                                    };
            lstCatalogDef = new List<CatalogDef>();
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Saludo"))
                lstCatalogDef.Add(new CatalogDef("Saludo"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipoprecio"))
                lstCatalogDef.Add(new CatalogDef("Tipoprecio"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Formapago"))
                lstCatalogDef.Add(new CatalogDef("Formapago"));




        }

        protected override void afterFillCatalogs()
        {

            //var Items = new Dictionary<string, object>();
            //Items.Add("Chennai", "MAS");
            //Items.Add("Trichy", "TPJ");
            //Items.Add("Bangalore", "SBC");
            //Items.Add("Coimbatore", "CBE");

            //Catalogs["Formapago"]

            //this.FormasPagoItems =
            var bufferItems = new Dictionary<string, object>();
            foreach (var i in Catalogs!["Formapago"]!)
            {
                bufferItems.Add(i.Nombre ?? "", i.Id!.ToString() ?? "");
            }
            this.FormasPagoItems = bufferItems;
        }

        protected string MultiSelectToString(Dictionary<string, object>? dict)
        {
            if (dict == null || dict.Count() <= 0)
                return "";

            return String.Join("|", dict.Values.Select(x => x.ToString()).ToList());
        }

        protected Dictionary<string, object> StringToMultiselect(Dictionary<string, object> dict, string strValue)
        {
            var valuesSelected = strValue.Split("|");
            var bufferItems = new Dictionary<string, object>();
            foreach (var i in valuesSelected)
            {
                var dictSelected = dict.Where(x => x.Value.ToString()  == i);

                if (dictSelected != null  && dictSelected.Count() > 0)
                    bufferItems.Add(dictSelected.First().Key, dictSelected.First().Value);
            }


            return bufferItems;
        }

        protected override void doInsert()
        {
            if (Record == null)
                return;

            Record.Clieformaspagodef = MultiSelectToString(this.selectedFormasPagoItems);

            provider.Insert(Record);

            provider.UpdateUsuariosPerfiles(Record, UsuarioPerfilItems);
        }

        protected override void doUpdate()
        {
            if (Record == null)
                return;

            Record.Clieformaspagodef = MultiSelectToString(this.selectedFormasPagoItems);

            provider.Update(Record);

            provider.UpdateUsuariosPerfiles(Record, UsuarioPerfilItems);
        }

        public void Cambiocontrasena()
        {
            if (this.Record == null)
                return;


            CambiocontrasenaWFViewModel vm = IoC.Get<CambiocontrasenaWFViewModel>();
            vm.CambiocontrasenaItem!.EmpresaId = this.Record!.EmpresaId;
            vm.CambiocontrasenaItem!.SucursalId = this.Record!.SucursalId;
            vm.CambiocontrasenaItem!.Id = this.Record!.Id;
            vm.CambiocontrasenaItem!.Clave= this.Record!.Clave;
            vm.CambiocontrasenaItem!.UsuarioNombre = this.Record!.Nombre;
            vm.CambiocontrasenaItem!.Contrasena = this.Record!.Contrasena;
            vm.PreguntarContrasenaAnterior = false;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Cambio de contraseña", 0.60, 0.80));
        }

        
    }


    public class UsuarioShowViewModel : UsuarioItemViewModel
    {
        public UsuarioShowViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class UsuarioEditViewModel : UsuarioItemViewModel
    {
        public UsuarioEditViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class UsuarioAddViewModel : UsuarioItemViewModel
    {
        public UsuarioAddViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


