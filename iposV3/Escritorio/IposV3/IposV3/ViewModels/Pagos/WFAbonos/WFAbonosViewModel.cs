
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
using Controllers.BindingModel;
using IposV3.Services;
using System.Threading;
using IposV3.BindingModel;
using System.Windows;

namespace IposV3.ViewModels
{

    public class WFAbonosViewModel :  BaseOperationalScreen, IHandle<WFAbonosItemVMInitialParameters>
    {


        public bool BProcessSuccess { get; protected set; }


        private V_DoctoPagoItemBindingModel? doctoPagoItem;
        public V_DoctoPagoItemBindingModel? DoctoPagoItem
        {
            get => doctoPagoItem;
            set
            {
                doctoPagoItem = value; NotifyOfPropertyChange("DoctoPagoItem");

                if (doctoPagoItem != null)
                {
                    doctoPagoItem.PendingChange += DoctoPagoPendingChangeEventHandler;
                    doctoPagoItem.PropertyChanged += DoctoPagoPropertyChangedEventHandler;
                }
            }
        }





        public bool HabilitarPanelBancario
        {
            get
            {
                return RequiereFormaPagoDatosBancarios(this.doctoPagoItem?.Formapagoid);
            }
        }


        public ObservableCollection<V_DoctoPagoItemBindingModel> AbonosItems { get; set; }



        private ClienteBindingModel? clientePago;
        public ClienteBindingModel? ClientePago { get => clientePago; set { clientePago = value; NotifyOfPropertyChange("ClientePago"); } }

        protected readonly ClienteWebController clienteProvider;


        private ProveedorBindingModel? proveedorPago;
        public ProveedorBindingModel? ProveedorPago { get => proveedorPago; set { proveedorPago = value; NotifyOfPropertyChange("ProveedorPago"); } }

        protected readonly ProveedorWebController proveedorProvider;


        private string itemMode = "Add";
        public string ItemMode { get => itemMode; set { itemMode = value; NotifyOfPropertyChange("ItemMode");  } }



        private bool bIsItemReadOnly = false;
        public bool BIsItemReadOnly { get => bIsItemReadOnly; set { bIsItemReadOnly = value; NotifyOfPropertyChange("BIsItemReadOnly"); } }


        protected readonly PagoWebController pagoProvider;
        protected readonly DoctoWebController doctoProvider;
        protected readonly CfdiWebController cfdiProvider;


        public long tipoDoctoId;
        public long TipoDoctoId
        {
            get { return tipoDoctoId; }
            set
            {
                tipoDoctoId = value;
                NotifyOfPropertyChange();
            }
        }



        //Main entities
        private DoctoBindingModel? currentDocto;
        public DoctoBindingModel? CurrentDocto
        {
            get => currentDocto;
            set
            {
                currentDocto = value; NotifyOfPropertyChange("CurrentDocto");

            }
        }


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


        public bool EsTransaccionDeSalida
        {
            get { return tipoDoctoId == DBValues._DOCTO_TIPO_VENTA; }
        }


        public bool HabilitarNuevo
        {
            get
            {
                return this.ItemMode == "Edit" || this.itemMode == "Show";
            }
        }

        public bool HabilitarOpcionDeCancelar
        {
            get
            {
                return this.ItemMode == "Edit" && this.doctoPagoItem != null && 
                       this.doctoPagoItem.Revertido != BoolCN.S && !this.doctoPagoItem.Espagocompuesto;
            }
        }


        public bool HabilitarOpcionDeRecibo
        {
            get
            {
                return this.ItemMode == "Edit" && this.doctoPagoItem != null;
            }
        }




        public bool HabilitarOpcionDeReciboElectronico
        {
            get
            {
                return this.ItemMode == "Edit" && this.doctoPagoItem != null && this.currentDocto?.Docto_fact_elect_Esfacturaelectronica == BoolCN.S &&
                       this.doctoPagoItem.Revertido != BoolCN.S && this.doctoPagoItem.Clienteid != null && !this.doctoPagoItem.Espagocompuesto;
            }
        }


        public bool HabilitarVerAbono
        {
            get
            {
                return true;
            }
        }


        public GlobalSession GlobalSession { get => GlobalVariable.CurrentSession!; }



        public WFAbonosViewModel(
            ClienteWebController clienteprovider, PagoWebController pagoProvider, CorteWebController corteControllerProvider, 
            UsuarioWebController usuarioControllerProvider, DoctoWebController doctoProvider, ProveedorWebController proveedorProvider, CfdiWebController cfdiProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {

            this.clienteProvider = clienteprovider;
            this.proveedorProvider = proveedorProvider;
            this.pagoProvider = pagoProvider;
            this.doctoProvider = doctoProvider;
            this.cfdiProvider = cfdiProvider;

            this.ResetearItem();

            AbonosItems = new ObservableCollection<V_DoctoPagoItemBindingModel>();

            ClientePago = new ClienteBindingModel();

            CurrentDocto = new DoctoBindingModel();
            ClearDocto();

            BIsReadOnly = false;

            this.TipoDoctoId = DBValues._DOCTO_TIPO_VENTA;


        }

        protected override void OnViewLoaded(object view)
        {
            //suscribe view to events
            aggregator.SubscribeOnUIThread(this.GetView());

            //check if corte is active
            ChecarCorteActivo();
        }

        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {

                                          //new CatalogRelatedFields("DoctoPagoItem","Cliente","Clienteid", "ClienteClave", "ClienteNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Banco"),new CatalogDef(
                    "Formapago"),new CatalogDef(
                    "Cuentabanco")};

        }


        private void ClearDocto()
        {
            CurrentDocto = EmptyDocto();

        }

        private DoctoBindingModel EmptyDocto()
        {

            var buffer = new DoctoBindingModel();
            buffer.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
            buffer.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
            return buffer;
        }


        public bool RequiereFormaPagoDatosBancarios(long? formapagoid)
        {
            switch (formapagoid)
            {
                case DBValues._FORMA_PAGO_CHEQUE:
                case DBValues._FORMA_PAGO_DEPOSITO:
                case DBValues._FORMA_PAGO_TARJETA:
                case DBValues._FORMA_PAGO_TRANSFERENCIA:
                case DBValues._FORMA_PAGO_VALE:
                    return true;
                default: return false;
            }
        }


        protected void DoctoPagoPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                //case "Clienteid":
                //    AssignClientInfo();
                //    //LlenarDoctosConSaldo();
                //    break;

                case "Formapagoid":
                    NotifyOfPropertyChange("HabilitarPanelBancario");
                    break;

                default:
                    break;
            }
        }

        public void DoctoPagoPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {
                //case "ClienteClave":
                //    CatalogField_PropertyChanging(sender, e);
                //    break;


                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }



        public void AssignClientInfo()
        {
            if (CurrentDocto?.Clienteid.HasValue != true || CurrentDocto!.Clienteid!.Value == 0)
            {
                ClientePago = new ClienteBindingModel();
                return;
            }

            Task.Run(async () =>
            {

                ClientePago = await clienteProvider.GetById(new ClienteBindingModel()
                                            {
                                                Id = CurrentDocto.Clienteid.Value,
                                                EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                                SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                                            });
            }).Wait();

        }


        public void AssignProveedorInfo()
        {
            if (CurrentDocto?.Proveedorid.HasValue != true || CurrentDocto.Proveedorid!.Value == 0)
            {
                ProveedorPago = new ProveedorBindingModel();
                return;
            }

            Task.Run(async () =>
            {

                ProveedorPago = await proveedorProvider.GetById(new ProveedorBindingModel()
                {
                    Id = CurrentDocto!.Proveedorid!.Value,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });
            }).Wait();

        }




        public void LoadDocto()
        {

            DoctoBindingModel? itemBuffer = null;

            Task.Run(async () =>
            {
                itemBuffer = await doctoProvider.GetById(CurrentDocto!);
            }).Wait();

            if (itemBuffer != null)
            {
                CurrentDocto = itemBuffer;
            }

        }



        public void SeleccionarTransaccionConSaldo()
        {

            ClearDocto();

            WFDoctosConSaldoViewModel vm = IoC.Get<WFDoctosConSaldoViewModel>();
            vm.TipoDoctoId = tipoDoctoId;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Transacciones con saldo", 0.75));


            if (vm.selectedItem != null && vm.selectedItem.Id != null)
            {
                CurrentDocto!.Id = vm.selectedItem.Id;
                this.LoadDocto();

                if (this.EsTransaccionDeSalida)
                    this.AssignClientInfo();
                else
                    this.AssignProveedorInfo();

                this.ReloadItems();
                IrANuevoPago();



            }
        }



        public async Task<System.Collections.Generic.List<V_DoctoPagoItemBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<V_DoctoPagoItemBindingModel> items = new System.Collections.Generic.List<V_DoctoPagoItemBindingModel>();

            if (CurrentDocto!.Id == null || CurrentDocto!.Id == 0)
                return items;

           
            items = await pagoProvider.DoctoPagosList(currentDocto!.EmpresaId!.Value, currentDocto!.SucursalId!.Value, currentDocto!.Id!.Value) ?? items;


            return items;
        }


        public  void ReloadItems()
        {
            AbonosItems.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<V_DoctoPagoItemBindingModel> items = new System.Collections.Generic.List<V_DoctoPagoItemBindingModel>();

                
                Task.Run<List<V_DoctoPagoItemBindingModel>>(async () =>
                                                      await DoGetItems()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
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
                                AbonosItems.Add(item);
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
                //            AbonosItems.Add(item);
                //        }
                //        //Items = new ObservableCollection<V_pago_compuestoWFBindingModel>(items);
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


        
        public void Edititem(V_DoctoPagoItemBindingModel selected)
        {

            this.DoctoPagoItem = selected;
            
            CambiarAItemModo("Edit");



        }

        private void CambiarAItemModo(string modo)
        {
            switch(modo)
            {
                case "Add":
                    this.BIsItemReadOnly = false;
                    this.ItemMode = "Add";
                    break;
                case "Edit":
                    this.BIsItemReadOnly = true;
                    this.ItemMode = "Edit";
                    break;
            }

            NotifyOfPropertyChange("HabilitarNuevo");
            NotifyOfPropertyChange("HabilitarOpcionDeCancelar");
            NotifyOfPropertyChange("HabilitarOpcionDeRecibo");
            NotifyOfPropertyChange("HabilitarOpcionDeReciboElectronico");
        }


        public void IrANuevoPago()
        {

            CambiarAItemModo("Add");
            ResetearItem();
        }

        private void ResetearItem()
        {

            DoctoPagoItem = new V_DoctoPagoItemBindingModel();
            DoctoPagoItem.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            DoctoPagoItem.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            DoctoPagoItem.Fecha = DateTimeOffset.UtcNow;
            DoctoPagoItem.Fechaelaboracion = DateTimeOffset.UtcNow;
            DoctoPagoItem.Fecharecepcion = DateTimeOffset.UtcNow;
            DoctoPagoItem.Fechaaplicado = DateTimeOffset.UtcNow;
            DoctoPagoItem.Monto = 0.00m;
            DoctoPagoItem.Aplicado = BoolCN.S;
        }




        public void Accept()
        {
            if (DoctoPagoItem == null)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No hay pago", "Error"));
                return;
            }

            if (this.EsTransaccionDeSalida)
            {
                DoctoPagoItem.Clienteid = CurrentDocto!.Clienteid;
                DoctoPagoItem.Tipopagoid = DoctoPagoItem.Tipopagoid ?? DBValues._TIPOPAGO_ENTRADA;
            }
            else
            {
                DoctoPagoItem.Proveedorid = CurrentDocto!.Proveedorid;
                DoctoPagoItem.Tipopagoid = DoctoPagoItem.Tipopagoid ?? DBValues._TIPOPAGO_SALIDA;
            }


            if ((DoctoPagoItem.Clienteid ?? 0) == 0 && (DoctoPagoItem.Proveedorid ?? 0) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita definir al cliente/proveedor", "Error"));
                return;
            }


            if ((DoctoPagoItem.Formapagoid ?? 0) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita definir la forma de pago", "Error"));
                return;
            }

            if ((DoctoPagoItem.Monto ?? 0) <= 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita definir un monto mayor a cero", "Error"));
                return;
            }

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                
                Task.Run(async () =>
                                                      await GuardarPago()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        ErrorAddActions(DoctoPagoItem, comentario);
                    }
                    else if (t.IsCompleted)
                    {
                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {

                            if (this.CurrentDocto!.Docto_fact_elect_Esfacturaelectronica == BoolCN.S)
                            {

                                if (ShowSiNoMessageBox("Desea hacer el recibo electronico de este pago", "Confirmacion"))
                                {
                                    GenerarReciboElectronico(true);
                                }
                                else
                                {

                                    DoImprimirRecibo();
                                }
                            }
                            else
                            {
                                DoImprimirRecibo();
                            }

                            ReloadItems();
                            CambiarAItemModo("Add");
                            LoadDocto();

                            SuccessAddActions(DoctoPagoItem);
                            IrANuevoPago();
                        }
                        else
                        {
                            ErrorAddActions(DoctoPagoItem, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        GuardarPago();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {

                //        if (this.CurrentDocto!.Docto_fact_elect_Esfacturaelectronica == BoolCN.S)
                //        {

                //            if (ShowSiNoMessageBox("Desea hacer el recibo electronico de este pago", "Confirmacion"))
                //            {
                //                GenerarReciboElectronico(true);
                //            }
                //            else
                //            {

                //                DoImprimirRecibo();
                //            }
                //        }
                //        else
                //        {
                //            DoImprimirRecibo();
                //        }

                //        ReloadItems();
                //        CambiarAItemModo("Add");
                //        LoadDocto();

                //        SuccessAddActions(DoctoPagoItem);
                //        IrANuevoPago();
                //    }
                //    else
                //    {
                //        ErrorAddActions(DoctoPagoItem, comentario);
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }






        public async Task GuardarPago()
        {

            if (DoctoPagoItem == null)
                return;

            var pagoTransaccion = new Pago_transaccion()
            {
                Empresaid = DoctoPagoItem.EmpresaId!.Value,
                Sucursalid = DoctoPagoItem.SucursalId!.Value,
                Id = 0,
                Activo = BoolCS.S,
                Creado = DateTimeOffset.UtcNow,
                Creadopor_userid = GlobalVariable.CurrentSession!.Usuarioid,
                Formapagoid = DoctoPagoItem.Formapagoid,
                Fecha = DoctoPagoItem.Fecha,
                Fechahora = DoctoPagoItem.Fechahora,
                Corteid = this.CorteId,
                Importe = DoctoPagoItem.Monto ?? 0m,
                Importerecibido =  0m,
                Importecambio =  0m,
                Tipopagoid = DoctoPagoItem.Tipopagoid,
                Bancoid = DoctoPagoItem.Bancoid,
                Referenciabancaria = DoctoPagoItem.Referenciabancaria,
                Notas = DoctoPagoItem.Notas,
                Fechaelaboracion = DoctoPagoItem.Fechaelaboracion,
                Fecharecepcion = DoctoPagoItem.Fecharecepcion,
                Aplicado = DoctoPagoItem.Aplicado,
                Pagoparentid = DoctoPagoItem.Pagoparentid,
                Formapagosatid = DoctoPagoItem.Formapagosatid,
                Clienteid = DoctoPagoItem.Clienteid,
                Proveedorid = DoctoPagoItem.Proveedorid,
                Sentidopago = DoctoPagoItem.Sentidopago ?? 1,
                Fechaaplicado = DoctoPagoItem.Fechaaplicado,
                Comision = DoctoPagoItem.Comision ?? 0m,
                Cuentapagocredito = DoctoPagoItem.Cuentapagocredito,
                Cuentabancoempresaid = DoctoPagoItem.Cuentabancoempresaid,
                Reciboelectronicoid = null

            };

            List<DoctoPago_transaccion> doctoPagoTransactions = new List<DoctoPago_transaccion>();


            var doctoPagoTransaction = new DoctoPago_transaccion()
            {
                Empresaid = DoctoPagoItem.EmpresaId!.Value,
                Sucursalid = DoctoPagoItem.SucursalId!.Value,
                Id = 0,
                Activo = BoolCS.S,
                Creado = DateTimeOffset.UtcNow,
                Creadopor_userid = GlobalVariable.CurrentSession!.Usuarioid,
                Doctoid = CurrentDocto!.Id,
                Fecha = DoctoPagoItem.Fecha,
                Fechahora = DoctoPagoItem.Fechahora,
                Corteid = this.CorteId,
                Importe = DoctoPagoItem.Monto ?? 0m,
                Tipopagoid = DoctoPagoItem.Tipopagoid,
                Tipoabonoid = DBValues._TIPO_ABONO_ABONO,
                Sentidopago = DoctoPagoItem.Sentidopago ?? 1,
                Formapagoid = DoctoPagoItem.Formapagoid,
                Pagoid = null,
                Esapartado = BoolCN.N,
                Tipoaplicacioncreditoid = null,
                Espagoinicial = BoolCN.N,
                Doctopagoparentid = null

            };
            doctoPagoTransactions.Add(doctoPagoTransaction);

            BaseResultBindingModel? tempResult = null;
            long? pagoId = null;

            tempResult = await pagoProvider.PagoCompuestoInsert(pagoTransaccion, doctoPagoTransactions);

            pagoId = tempResult?.Result;

            this.DoctoPagoItem!.Pagoid = pagoId;

        }



        public void CancelarPago()
        {
            if (DoctoPagoItem == null || (DoctoPagoItem.Id ?? 0) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No hay pago", "Error"));
                return;
            }



            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                
                Task.Run(async () =>
                                                      await doCancelarPago()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        ErrorAddActions(DoctoPagoItem, comentario);
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            ReloadItems();
                            CambiarAItemModo("Add");
                            LoadDocto();
                            SuccessAddActions(DoctoPagoItem);
                            IrANuevoPago();
                        }
                        else
                        {
                            ErrorAddActions(DoctoPagoItem, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doCancelarPago();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        ReloadItems();
                //        CambiarAItemModo("Add");
                //        LoadDocto();
                //        SuccessAddActions(DoctoPagoItem);
                //        IrANuevoPago();
                //    }
                //    else
                //    {
                //        ErrorAddActions(DoctoPagoItem, comentario);
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }



        public async Task doCancelarPago()
        {

            if (DoctoPagoItem == null)
                return;



            BaseResultBindingModel? tempResult = null;
            long? pagoId = null;

            tempResult = await pagoProvider.PagoCompuestoRevertir(
                        DoctoPagoItem.EmpresaId!.Value, DoctoPagoItem.SucursalId!.Value, DoctoPagoItem.Pagoid!.Value,
                        GlobalVariable.CurrentSession!.Usuarioid!.Value, this.CorteId!.Value, DoctoPagoItem!.Notas);

            pagoId = tempResult?.Result;



        }


        // Facturar / Recibo / Recibo Electronico


        public async Task ReciboElectronico()
        {


            if ((doctoPagoItem?.Reciboelectronicoid ?? 0) != 0)
            {
                await Facturar(false);
            }
            else
            {
                GenerarReciboElectronico(false);
            }

        }


        public void GenerarReciboElectronico(bool imprimirRecibo = false)
        {

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                long? reciboElectronicoId = null;


                Task.Run<BaseResultBindingModel?>(async () =>
                                                    {
                                                        var tempResult = await pagoProvider.GenerarReciboElectronico(doctoPagoItem!.EmpresaId!.Value,
                                                                                                  doctoPagoItem!.SucursalId!.Value,
                                                                                                  doctoPagoItem!.Pagoid!.Value,
                                                                                                  GlobalVariable.CurrentSession!.Usuarioid!.Value);

                                                        reciboElectronicoId = tempResult!.Result;

                                                        doctoPagoItem!.Reciboelectronicoid = reciboElectronicoId;

                                                        if(tempResult!.Result >= 0)
                                                        {

                                                            var facturacionResult = await Facturar(imprimirRecibo);
                                                            if(!facturacionResult)
                                                            {
                                                                tempResult.Result = -1;
                                                                tempResult.Usermessage = "No se pudo facturar el recibo";
                                                                tempResult.Devmessage = "No se pudo facturar el recibo";
                                                            }

                                                        }
                                                        return tempResult;
                                                    }
                                                      
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
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


                        bSuccess = t.Result != null && t.Result.Result >= 0;
                        comentario = t.Result != null ? t.Result.Usermessage : "Error ...";


                        if (!bSuccess)
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {

                //        Task.Run(async () =>
                //        {
                //            tempResult = await pagoProvider.GenerarReciboElectronico(doctoPagoItem!.EmpresaId!.Value,
                //                                              doctoPagoItem!.SucursalId!.Value,
                //                                              doctoPagoItem!.Pagoid!.Value,
                //                                              GlobalVariable.CurrentSession!.Usuarioid!.Value);

                //        }).Wait();

                //        reciboElectronicoId = tempResult?.Result;

                //        doctoPagoItem!.Reciboelectronicoid = reciboElectronicoId;
                //    }
                //    catch (Exception ex)
                //    {
                //        bSuccess = false;
                //        comentario = ex.Message;
                //    }
                //};
                //worker.RunWorkerCompleted += async (o, ea) =>
                //{
                //    IsBusy = false;

                //    if (!bSuccess)
                //    {

                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }
                //    else
                //    {
                //        await Facturar(imprimirRecibo);
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        public async Task<bool> Facturar( bool imprimirRecibo = false)
        {

            if ((doctoPagoItem?.Reciboelectronicoid ?? 0) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No se hizo el recibo electronico", "Error"));
                return false;
            }


            //si ya se hizo la factura entonces solo imprimela
            var doctoDelPago = new DoctoBindingModel()
            {
                EmpresaId = doctoPagoItem!.EmpresaId,
                SucursalId = doctoPagoItem!.SucursalId,
                Id = doctoPagoItem!.Reciboelectronicoid!.Value
            };


            Task.Run(async () =>
            {

                doctoDelPago = await doctoProvider.GetById(doctoDelPago);
            }).Wait();

            if (doctoDelPago != null && !string.IsNullOrEmpty(doctoDelPago!.Docto_fact_elect_Timbradouuid))
            {
                DoImprimirFactura();
                if (imprimirRecibo)
                {
                    DoImprimirRecibo();
                }
                BProcessSuccess = true;
                SuccessAddActions(doctoPagoItem!);
                return true;
            }

            FacturacionViewModel vm = IoC.Get<FacturacionViewModel>();
            vm.AsignarDatoParaFacturar(
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                       doctoPagoItem!.Reciboelectronicoid,
                                       null, false);
            await winManager.ShowDialogAsync(vm, null, CreateWinSettings("Facturacion", 0.25));

            if (vm.SeFacturo)
            {
                showPopUpMessage(new MessageToUserSimple("Procesado", "Se hizo la facturacion", "Success"));
                DoImprimirFactura();
                DoImprimirRecibo();
                SuccessAddActions(doctoPagoItem!);
            }
            else
            {
                showPopUpMessage(new MessageToUserSimple("Problema", "No se puedo hacer la facturacion", "Information"));
            }


            return true;
        }


        public void ImprimirFactura()
        {
            DoImprimirFactura();
        }

        private void DoImprimirFactura()
        {

            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReporteShowingViewModel vm = IoC.Get<ReporteShowingViewModel>();

            var doctoDelPago = new DoctoBindingModel()
            {
                EmpresaId = doctoPagoItem!.EmpresaId,
                SucursalId = doctoPagoItem!.SucursalId,
                Id = doctoPagoItem!.Reciboelectronicoid!.Value
            };

            Task.Run(async () =>
            {
                doctoDelPago = await doctoProvider.GetById(doctoDelPago);

            }).Wait();

            if (doctoDelPago == null)
                return;



            string tipoComprobante = "F";
            string prefixComprobante = CfdiWebController.obtainPrefixByTipoComprobante(tipoComprobante);
            string imagenBiCode = "file:///" + cfdiProvider.Facturacion_FileLocalLocation_XML_Timbrados(doctoDelPago!.Tipodoctoid!.Value, GlobalSession!.CurrentParametro!, null) + "\\" + prefixComprobante + (doctoDelPago.Docto_fact_elect_Seriesat ?? "") + (doctoDelPago.Docto_fact_elect_Foliosat?.ToString() ?? "") + ".xml.png";
            string logoEmpresa = "file:///" + cfdiProvider.Facturacion_FileLocalLocation_FE_IMG(GlobalSession!.CurrentParametro!, doctoDelPago!.Tipodoctoid!.Value) + "\\logofarmafree.png";


            string? bufferNumCSD = System.IO.Path.GetFileName(GlobalSession.CurrentParametro!.Timbradoarchivocertificado ?? "");
            string numCSD = bufferNumCSD == null ? "" : bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper();



            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("empresaid", doctoDelPago.EmpresaId!.Value);
            dict.Add("sucursalid", doctoDelPago.SucursalId!.Value);
            dict.Add("doctoid", doctoDelPago.Id!.Value);
            dict.Add("desgloseKits", "S");


            dict.Add("US_ID", GlobalSession.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalSession.CurrentUsuario!.UsuarioNombre);
            dict.Add("imagenBicode", imagenBiCode);
            dict.Add("logoEmpresa", logoEmpresa);
            dict.Add("bgImage", "");
            dict.Add("num_serie_cert_csd", numCSD);
            dict.Add("tipoComprobante", tipoComprobante);
            dict.Add("containsCartaPorte", "N");


            vm.FastReportInfo = new FastReportInfo()
            {
                RutaReporte = FastReportsConfig.getPathForFile("RptFacturaElectronica40.frx", FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Factura electronica", 0.75));
        }



        public void ImprimirRecibo()
        {
            DoImprimirRecibo();
        }

        private void DoImprimirRecibo()
        {

            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReporteShowingViewModel vm = IoC.Get<ReporteShowingViewModel>();


            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("empresaid", doctoPagoItem!.EmpresaId!.Value);
            dict.Add("sucursalid", doctoPagoItem!.SucursalId!.Value);
            dict.Add("itemid", doctoPagoItem!.Id!.Value);


            dict.Add("US_ID", GlobalSession.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalSession.CurrentUsuario!.UsuarioNombre);


            var nombreReporte = this.TipoDoctoId == DBValues._DOCTO_TIPO_COMPRA ? "ReciboPagoProveedor.frx" : "ReciboPagoCliente.frx";

            vm.FastReportInfo = new FastReportInfo()
            {

                RutaReporte = FastReportsConfig.getPathForFile(nombreReporte, FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Recibo", 0.75));
        }


        // Fin Facturar / Recibo / Recibo Electronico



        public virtual void SuccessAddActions(V_DoctoPagoItemBindingModel record)
        {

            var eventParam = new WFPagosListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public virtual void ErrorAddActions(V_DoctoPagoItemBindingModel record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }


        public Task HandleAsync(WFAbonosItemVMInitialParameters parameters, CancellationToken cancellationToken)
        {
            this.TipoDoctoId = parameters.TipoDoctoId ?? DBValues._DOCTO_TIPO_VENTA;
            return Task.CompletedTask;
        }





    }



}


