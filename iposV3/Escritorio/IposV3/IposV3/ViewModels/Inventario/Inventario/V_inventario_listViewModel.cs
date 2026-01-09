
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
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IposV3.ViewModels
{
    public class V_inventario_listViewModel : BaseGenericViewModel
    {

        private V_inventario_doctoParamBindingModel? v_inventario_doctoParam { get; set; }
        public V_inventario_doctoParamBindingModel? V_inventario_doctoParam
        {
            get
            {
                return v_inventario_doctoParam;
            }
            set
            {
                v_inventario_doctoParam = value; 
                NotifyOfPropertyChange("V_inventario_doctoParam");
                if (v_inventario_doctoParam != null)
                {
                    v_inventario_doctoParam.PropertyChanged += V_inventario_doctoParamChangedEventHandler;
                }

            }
        }


        public ObservableCollection<V_inventario_doctoWFBindingModel> Items { get; set; }

        public V_inventario_doctoWFBindingModel? selectedItem;

        public V_inventario_doctoWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public InventarioWebController itemsProvider;

        protected string? itemsLoadedText;
        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }


        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;


        public V_inventario_listViewModel(InventarioWebController inventarioController, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            itemsProvider = inventarioController;

            V_inventario_doctoParam = new V_inventario_doctoParamBindingModel();
            V_inventario_doctoParam!.PendingChange += CatalogField_PropertyChanging;
            V_inventario_doctoParam.Empresaid = GlobalVariable.CurrentSession!.Empresaid;
            V_inventario_doctoParam.Sucursalid = GlobalVariable.CurrentSession!.Sucursalid;
            V_inventario_doctoParam.Activos = true;
            V_inventario_doctoParam.Desde = DateTimeOffset.UtcNow.Date.AddDays(-30);
            V_inventario_doctoParam.Estatusdoctoid = DBValues._DOCTO_ESTATUS_COMPLETO;


            Items = new ObservableCollection<V_inventario_doctoWFBindingModel>();

        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            this.ReloadItems();
        }


        protected override void fillCatalogConfiguration()
        {


            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Estatusdocto_Proveeduria")};

        }


        public virtual void TSBBuscar()
        {
            ReloadItems();

        }

        public virtual void TSTPalabrasClaveKeyDown(Key key)
        {
            if (key == Key.Enter)
            {
                TSBBuscar();
            }
        }



        public async Task<System.Collections.Generic.List<V_inventario_doctoWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<V_inventario_doctoWFBindingModel> items = new System.Collections.Generic.List<V_inventario_doctoWFBindingModel>();

            if (V_inventario_doctoParam == null)
                return items;


            Task.Run(async () =>
            {
                items = await itemsProvider.V_inventario_doctoList(V_inventario_doctoParam) ?? items;
            }).Wait();

            return items;
        }


        public virtual void ReloadItems()
        {
            Items.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<V_inventario_doctoWFBindingModel> items = new System.Collections.Generic.List<V_inventario_doctoWFBindingModel>();
                
                Task.Run<List<V_inventario_doctoWFBindingModel>>(async () =>
                                                      await DoGetItems()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {
                        if (bSuccess)
                        {
                            items = t.Result;
                            foreach (var item in items)
                            {
                                Items.Add(item);
                            }
                            ItemsLoadedText = "Loaded!";
                        }
                        else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        items = DoGetItems();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;
                //    if (bSuccess)
                //    {
                //        foreach (var item in items)
                //        {
                //            Items.Add(item);
                //        }
                //        //Items = new ObservableCollection<V_inventario_doctoWFBindingModel>(items);
                //        ItemsLoadedText = "Loaded!";
                //    }
                //    else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


        public void AddItem()
        {

            var vm = IoC.Get<V_inventario_fisicoViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void AddItem_XLoc()
        {
            var vm = IoC.Get<V_inventario_fisico_x_locViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void ShowItem(V_inventario_doctoWFBindingModel selected)
        {
            this.SelectedItem = selected;

            if (this.selectedItem!.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO ||
               this.selectedItem.Estatusdoctoid == DBValues._DOCTO_ESTATUS_INVENTARIOFIN)
            {

                var vm = IoC.Get<V_inventario_finedicionViewModel>();
                aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
                vm.LoadInfoEdit(SelectedItem.Consecutivo);
            }
            else
            {

                if (this.SelectedItem.Tipodoctoid == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
                {
                    var vm = IoC.Get<V_inventario_fisico_x_locViewModel>();
                    aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
                    vm.LoadInfoEdit(SelectedItem.Consecutivo);

                }
                else
                {
                    var vm = IoC.Get<V_inventario_fisicoViewModel>();
                    aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
                    vm.LoadInfoEdit(SelectedItem.Consecutivo);
                }
            }
            

        }


        private void V_inventario_doctoParamChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            if (Items == null)
                return;

            switch (e.PropertyName)
            {

                case "Estatusdoctoid":
                case "Desde":
                    {
                        this.ReloadItems();
                    }
                    break;


                default:
                    break;
            }
        }


        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }



    }


}

