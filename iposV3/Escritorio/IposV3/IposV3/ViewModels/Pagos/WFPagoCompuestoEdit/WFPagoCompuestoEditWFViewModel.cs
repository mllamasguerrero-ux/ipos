
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
using Controllers.BindingModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using IposV3.Services;
using System.Windows;
using System.Threading;
using IposV3.BindingModel;

namespace IposV3.ViewModels
{

    public class WFPagoCompuestoEditWFViewModel : BaseOperationalScreen, IHandle<WFPagosItemVMInitialParameters>
    {


        public bool BProcessSuccess { get; protected set; }

        private PagoBindingModel? pagoItem;
        public PagoBindingModel? PagoItem
        {
            get => pagoItem;
            set
            {
                pagoItem = value; NotifyOfPropertyChange("PagoItem");

                if (pagoItem != null)
                {
                    pagoItem.PendingChange += PagoPendingChangeEventHandler;
                    pagoItem.PropertyChanged += PagoPropertyChangedEventHandler;
                }
            }
        }


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

        public bool EsTransaccionDeSalida
        {
            get { return tipoDoctoId == DBValues._DOCTO_TIPO_VENTA; }
        }

        private string? mode;
        public string? Mode { get => mode;
            set
            {
                mode = value;
                SelectedBottomTab = mode == "Add" ? 0 : 1;
                NotifyOfPropertyChange("Mode");
                this.BIsReadOnly = mode != "Add";
            }
        }


        public bool HabilitarOpcionDeCancelar
        {
            get
            {
                return this.Mode == "Edit" && this.PagoItem != null &&
                       this.PagoItem.Revertido != BoolCN.S;
            }
        }


        public bool HabilitarOpcionDeRecibo
        {
            get
            {
                return this.Mode == "Edit" && this.PagoItem != null;
            }
        }




        public bool HabilitarOpcionDeReciboElectronico
        {
            get
            {
                return this.Mode == "Edit" && this.PagoItem != null &&
                       this.PagoItem.Revertido != BoolCN.S && this.PagoItem.Clienteid != null;
            }
        }


        public bool MostrarSoloTimbrados { get; set; }

        private decimal saldoAAplicar;
        public decimal SaldoAAplicar
        {
            get => saldoAAplicar;
            set
            {
                saldoAAplicar = value; NotifyOfPropertyChange("SaldoAAplicar");
            }
        }


        public bool HabilitarPanelBancario
        {
            get
            {
                return RequiereFormaPagoDatosBancarios(this.pagoItem?.Formapagoid); 
            }
        }


        public GlobalSession GlobalSession { get => GlobalVariable.CurrentSession!; }

        public ObservableCollection<V_docto_con_saldoWFBindingModel> DoctosconsaldoItems { get; set; } 


        private List<V_doctopago_aplicadoWFBindingModel>? pagosaplicadosItems;
        public List<V_doctopago_aplicadoWFBindingModel>? PagosaplicadosItems
        { 
            get => pagosaplicadosItems;
            set
            {
                pagosaplicadosItems = value; NotifyOfPropertyChange("PagosaplicadosItems");
             }
        }

        public int selectedBottomTab = 0;
        public int SelectedBottomTab
        {
            get => selectedBottomTab;
            set
            {
                selectedBottomTab = value; NotifyOfPropertyChange("SelectedBottomTab");
            }
        }

    private ClienteBindingModel? clientePago;
        public ClienteBindingModel? ClientePago { get => clientePago; set { clientePago = value; NotifyOfPropertyChange("ClientePago"); } }

        private ProveedorBindingModel? proveedorPago;
        public ProveedorBindingModel? ProveedorPago { get => proveedorPago; set { proveedorPago = value; NotifyOfPropertyChange("ProveedorPago"); } }


        protected readonly ClienteWebController clienteProvider;
        protected readonly ProveedorWebController proveedorProvider;
        protected readonly PagoWebController pagoProvider;
        private readonly CfdiWebController cfdiProvider;
        protected readonly DoctoWebController doctoProvider;

        public WFPagoCompuestoEditWFViewModel(
            ClienteWebController clienteprovider, ProveedorWebController proveedorProvider, PagoWebController pagoProvider, DoctoWebController doctoprovider,
            CorteWebController corteControllerProvider, UsuarioWebController usuarioControllerProvider,CfdiWebController cfdiProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {

            this.clienteProvider = clienteprovider;
            this.proveedorProvider = proveedorProvider;
            this.pagoProvider = pagoProvider;
            this.cfdiProvider = cfdiProvider;
            this.doctoProvider = doctoprovider;

            PagoItem = new PagoBindingModel();
            PagoItem.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            PagoItem.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            PagoItem.Fecha = DateTimeOffset.UtcNow;
            PagoItem.Fechaelaboracion = DateTimeOffset.UtcNow;
            PagoItem.Fecharecepcion = DateTimeOffset.UtcNow;
            PagoItem.Fechaaplicado = DateTimeOffset.UtcNow;
            PagoItem.Aplicado = BoolCN.S;

            ClientePago = new ClienteBindingModel();
            ProveedorPago = new ProveedorBindingModel();


            DoctosconsaldoItems = new ObservableCollection<V_docto_con_saldoWFBindingModel>();
            DoctosconsaldoItems.CollectionChanged += DoctosconsaldoItems_CollectionChanged;

            PagosaplicadosItems = new List<V_doctopago_aplicadoWFBindingModel>();

            BIsReadOnly = false;

            this.Mode = "Add";

            MostrarSoloTimbrados = false;
            SaldoAAplicar = 0;

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

                                          new CatalogRelatedFields("PagoItem","Cliente","Clienteid", "ClienteClave", "ClienteNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("PagoItem","Proveedor","Proveedorid", "ProveedorClave", "ProveedorNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Banco"),new CatalogDef(
                    "Formapago"),new CatalogDef(
                    "Cuentabanco")};

        }

        public bool RequiereFormaPagoDatosBancarios(long? formapagoid)
        {
            switch(formapagoid)
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


        protected void PagoPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                case "Clienteid":
                    AssignClientInfo();
                    LlenarDoctosConSaldo();
                    break;

                case "Proveedorid":
                    AssignProveedorInfo();
                    LlenarDoctosConSaldo();
                    break;

                case "Importe":
                    RecalcularSaldoAAplicar();
                    break;
                case "Formapagoid":
                    NotifyOfPropertyChange("HabilitarPanelBancario");
                    break;

                default:
                    break;
            }
        }

        public void PagoPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "ClienteClave":
                    CatalogField_PropertyChanging(sender, e);
                    break;


                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }


        public virtual Task HandleAsync(WFPagosItemVMInitialParameters initialParameters, CancellationToken cancellationToken)
        {
            this.Mode = (initialParameters.Id ?? 0) != 0 ? (initialParameters.Mode ?? "Show") : "Add" ;
            this.tipoDoctoId = initialParameters.TipoDoctoId ?? DBValues._DOCTO_TIPO_VENTA; ;

            if(this.Mode == "Show" || this.Mode == "Edit")
                fillRecordToEdit(initialParameters);

            return Task.CompletedTask;
        }


        private void fillRecordToEdit(WFPagosItemVMInitialParameters initialParameters)
        {

            PagoBindingModel item = new PagoBindingModel();

            item.Id = initialParameters.Id;
            item.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            item.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;


            Task.Run(async () =>
            {
                PagoItem = await pagoProvider.GetById(item);
            }).Wait();

            if (PagoItem == null)
            {

                showPopUpMessage(new MessageToUserSimple("Error", "No se encontro el registro del pago", "Error"));
                PagoItem = new PagoBindingModel();
                Back();
            }
            else
            {
                if (tipoDoctoId == DBValues._DOCTO_TIPO_VENTA)
                {
                    AssignClientInfo();
                }


                if (tipoDoctoId == DBValues._DOCTO_TIPO_COMPRA)
                {
                    AssignProveedorInfo();
                }

                LlenarDoctoPagosAplicados();
            }

        }


        public void AssignClientInfo()
        {
            if (PagoItem?.Clienteid.HasValue != true || PagoItem!.Clienteid!.Value == 0)
            {
                ClientePago = new ClienteBindingModel();
                return;
            }

            Task.Run(async () =>
            {

                ClientePago = await clienteProvider.GetById(new ClienteBindingModel()
                {
                    Id = PagoItem.Clienteid.Value,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });
            }).Wait();

        }


        public void AssignProveedorInfo()
        {
            if (PagoItem?.Proveedorid.HasValue != true || PagoItem!.Proveedorid!.Value == 0)
            {
                ProveedorPago = new ProveedorBindingModel();
                return;
            }

            Task.Run(async () =>
            {

                ProveedorPago = await proveedorProvider.GetById(new ProveedorBindingModel()
                {
                    Id = PagoItem!.Proveedorid!.Value,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });
            }).Wait();
        }



        public void LlenarDoctosConSaldo()
        {
            if(  ( this.EsTransaccionDeSalida && (PagoItem?.Clienteid.HasValue != true || PagoItem!.Clienteid!.Value == 0)) ||
                 ( (!this.EsTransaccionDeSalida) && (PagoItem?.Proveedorid.HasValue != true || PagoItem!.Proveedorid!.Value == 0)) )
            {
                return;
            }
            DoctosconsaldoItems.Clear();

            List<V_docto_con_saldoWFBindingModel>? buffer = null;

            Task.Run(async () =>
            {
                buffer = await pagoProvider.DoctosConSaldoList(
                                                    (GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid ?? 0),
                                                    (GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid ?? 0),
                                                    tipoDoctoId, PagoItem?.Clienteid, PagoItem?.Proveedorid, MostrarSoloTimbrados,
                                                    null, false, null, null, null, DBValues._DOCTO_ESTATUS_COMPLETO);

            }).Wait();

            if (buffer != null && buffer.Count > 0)
                foreach (var item in buffer)
                    DoctosconsaldoItems.Add(item);
        }




        void DoctoconsaldoItem_PendingChange(object sender, AcceptPendingChangeEventArgs e)
        {
            V_docto_con_saldoWFBindingModel doctoItem = (V_docto_con_saldoWFBindingModel)sender;
            if (e.PropertyName == "MontoAplicar")
            {
                RecalcularSaldoAAplicar();
                var saldoNuevo = SaldoAAplicar + (decimal)e.OldValue - (decimal)e.NewValue;
                if(saldoNuevo < 0 )
                {
                    showPopUpMessage(new MessageToUserSimple("Error", "No se puede aplicar mas de la cantidad pagada", "Warning"));
                    e.CancelPendingChange = true;
                }
                else
                {
                    SaldoAAplicar = saldoNuevo;
                    e.CancelPendingChange = false;
                }

            }
        }

        void DoctosconsaldoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (V_docto_con_saldoWFBindingModel item in e.NewItems)
                    item.PendingChange += DoctoconsaldoItem_PendingChange;

            if (e.OldItems != null)
                foreach (V_docto_con_saldoWFBindingModel item in e.OldItems)
                    item.PendingChange -= DoctoconsaldoItem_PendingChange;
        }



        void RecalcularSaldoAAplicar()
        {
            SaldoAAplicar = (PagoItem?.Importe ?? 0m) - SumaAbonosAAplicar();
        }

        decimal SumaAbonosAAplicar()
        {
            return DoctosconsaldoItems?.Sum(g => g.MontoAplicar) ?? 0m;
        }

        public void Accept()
        {
            if(PagoItem == null)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No hay pago", "Error"));
                return;
            }

            if ((PagoItem.Clienteid ?? 0) == 0 && (PagoItem.Proveedorid ?? 0) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita definir al cliente/proveedor", "Error"));
                return;
            }


            if ((PagoItem.Formapagoid ?? 0) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita definir la forma de pago", "Error"));
                return;
            }

            if ((PagoItem.Importe ?? 0) <= 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita definir un monto mayor a cero", "Error"));
                return;
            }


            if (this.EsTransaccionDeSalida)
            {
                PagoItem.Tipopagoid = PagoItem.Tipopagoid ?? DBValues._TIPOPAGO_ENTRADA;
            }
            else
            {
                PagoItem.Tipopagoid = PagoItem.Tipopagoid ?? DBValues._TIPOPAGO_SALIDA;
            }


            RecalcularSaldoAAplicar();


            if (SaldoAAplicar != 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "Necesita aplicar todo el pago, no mas y no menos", "Error"));
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
                        //bSuccess = false;
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        ErrorAddActions(PagoItem, comentario);
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {

                            if (this.tipoDoctoId == DBValues._DOCTO_TIPO_VENTA && this.DoctosconsaldoItems.Any(y => y.MontoAplicar > 0 && y.EsFacturaEletronica == BoolCN.S))
                            {

                                if (ShowSiNoMessageBox("Desea hacer el recibo electronico de este pago", "Confirmacion"))
                                {
                                    GenerarReciboElectronico(true);
                                }
                                else
                                {
                                    DoImprimirRecibo();
                                    SuccessAddActions(PagoItem);
                                }
                            }
                            else
                            {
                                DoImprimirRecibo();
                                SuccessAddActions(PagoItem);
                            }
    ;
                        }
                        else
                        {
                            ErrorAddActions(PagoItem, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

//                BackgroundWorker worker = new BackgroundWorker();
//                worker.DoWork += (o, ea) =>
//                {
//                    try
//                    {
//                        GuardarPago();
//                    }
//                    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
//                };
//                worker.RunWorkerCompleted += (o, ea) =>
//                {
//                    IsBusy = false;

//                    BProcessSuccess = bSuccess;
//                    if (BProcessSuccess)
//                    {

//                        if (this.tipoDoctoId == DBValues._DOCTO_TIPO_VENTA && this.DoctosconsaldoItems.Any(y => y.MontoAplicar > 0 && y.EsFacturaEletronica == BoolCN.S))
//                        {

//                            if (ShowSiNoMessageBox("Desea hacer el recibo electronico de este pago", "Confirmacion"))
//                            {
//                                GenerarReciboElectronico(true);
//                            }
//                            else
//                            {
//                                DoImprimirRecibo();
//                                SuccessAddActions(PagoItem);
//                            }
//                        }
//                        else
//                        {
//                            DoImprimirRecibo();
//                            SuccessAddActions(PagoItem);
//                        }
//;
//                    }
//                    else
//                    {
//                        ErrorAddActions(PagoItem, comentario);
//                    }

//                };
//                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }



        public async Task ReciboElectronico()
        {


            if ((pagoItem?.Reciboelectronicoid ?? 0) != 0)
            {
                await Facturar(false);
            }
            else
            {
                GenerarReciboElectronico(false);
            }

        }

        public void GenerarReciboElectronico( bool imprimirRecibo = false)
        {

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                BaseResultBindingModel? tempResult = null;

                Task.Run<BaseResultBindingModel?>(async () =>
                                                     {

                                                         try
                                                         {
                                                             long? reciboElectronicoId = null;


                                                             tempResult = await pagoProvider.GenerarReciboElectronico(pagoItem!.EmpresaId!.Value, pagoItem!.SucursalId!.Value, pagoItem!.Id!.Value, GlobalVariable.CurrentSession!.Usuarioid!.Value);


                                                             reciboElectronicoId = tempResult?.Result;


                                                             pagoItem!.Reciboelectronicoid = reciboElectronicoId;

                                                             await Facturar(imprimirRecibo);
                                                         }
                                                         catch (Exception ex)
                                                         {
                                                             bSuccess = false;
                                                             comentario = ex.Message;

                                                             tempResult = new BaseResultBindingModel()
                                                             {
                                                                 Result = -1,
                                                                 Usermessage = ex.Message,
                                                                 Devmessage = ex.Message
                                                             };
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
                        BProcessSuccess = bSuccess;
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
                //        long? reciboElectronicoId = null;


                //        Task.Run(async () =>
                //        {
                //             tempResult = await pagoProvider.GenerarReciboElectronico(pagoItem!.EmpresaId!.Value, pagoItem!.SucursalId!.Value, pagoItem!.Id!.Value, GlobalVariable.CurrentSession!.Usuarioid!.Value);

                //        }).Wait();

                //        reciboElectronicoId = tempResult?.Result;

                        
                //        pagoItem!.Reciboelectronicoid = reciboElectronicoId;
                //    }
                //    catch (Exception ex) { 
                //        bSuccess = false; 
                //        comentario = ex.Message; 
                //    }
                //};
                //worker.RunWorkerCompleted += async (o, ea) =>
                //{
                //    IsBusy = false;

                //    if(!bSuccess)
                //    {

                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }
                //    else
                //    {
                //       await Facturar(imprimirRecibo);
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

            if (PagoItem == null)
                return;

            var pagoTransaccion = new Pago_transaccion()
            {
                Empresaid = PagoItem.EmpresaId!.Value,
                Sucursalid = PagoItem.SucursalId!.Value,
                Id = 0,
                Activo = BoolCS.S,
                Creado = DateTimeOffset.UtcNow,
                Creadopor_userid = GlobalVariable.CurrentSession!.Usuarioid,
                Formapagoid = PagoItem.Formapagoid,
                Fecha = PagoItem.Fecha,
                Fechahora = PagoItem.Fechahora,
                Corteid = this.CorteId,
                Importe = PagoItem.Importe ?? 0m,
                Importerecibido = PagoItem.Importerecibido ?? 0m,
                Importecambio = PagoItem.Importecambio ?? 0m,
                Tipopagoid = PagoItem.Tipopagoid,
                Bancoid = PagoItem.Bancoid,
                Referenciabancaria = PagoItem.Referenciabancaria,
                Notas = PagoItem.Notas,
                Fechaelaboracion = PagoItem.Fechaelaboracion,
                Fecharecepcion = PagoItem.Fecharecepcion,
                Aplicado = PagoItem.Aplicado,
                Pagoparentid = PagoItem.Pagoparentid,
                Formapagosatid = PagoItem.Formapagosatid,
                Clienteid = PagoItem.Clienteid,
                Proveedorid = PagoItem.Proveedorid,
                Sentidopago = PagoItem.Sentidopago ?? 1,
                Fechaaplicado = PagoItem.Fechaaplicado,
                Comision = PagoItem.Comision ?? 0m,
                Cuentapagocredito = PagoItem.Cuentapagocredito,
                Cuentabancoempresaid = PagoItem.Cuentabancoempresaid,
                Reciboelectronicoid = null

            };

            List<DoctoPago_transaccion> doctoPagoTransactions = new List<DoctoPago_transaccion>();

            foreach(var doctoAplicado in DoctosconsaldoItems.Where(y => y.MontoAplicar > 0))
            {

                var doctoPagoTransaction = new DoctoPago_transaccion()
                {
                    Empresaid = PagoItem.EmpresaId!.Value,
                    Sucursalid = PagoItem.SucursalId!.Value,
                    Id = 0,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.UtcNow,
                    Creadopor_userid = GlobalVariable.CurrentSession!.Usuarioid,
                    Doctoid = doctoAplicado.Id,
                    Fecha = PagoItem.Fecha,
                    Fechahora = PagoItem.Fechahora,
                    Corteid = this.CorteId,
                    Importe = doctoAplicado.MontoAplicar ?? 0m,
                    Tipopagoid = PagoItem.Tipopagoid,
                    Tipoabonoid = DBValues._TIPO_ABONO_ABONO,
                    Sentidopago = PagoItem.Sentidopago ?? 1,
                    Formapagoid = PagoItem.Formapagoid,
                    Pagoid = null,
                    Esapartado = BoolCN.N,
                    Tipoaplicacioncreditoid = null,
                    Espagoinicial = BoolCN.N,
                    Doctopagoparentid = null

                };
                doctoPagoTransactions.Add(doctoPagoTransaction);
            }


            BaseResultBindingModel? tempResult = null;
            long? pagoId = null;

            tempResult = await pagoProvider.PagoCompuestoInsert(pagoTransaccion, doctoPagoTransactions);

            pagoId = tempResult?.Result;

            this.pagoItem!.Id = pagoId;

        }



        public virtual void SuccessAddActions(PagoBindingModel record)
        {

            var eventParam = new WFPagosListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public virtual void ErrorAddActions(PagoBindingModel record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }





        public void LlenarDoctoPagosAplicados()
        {
            if (PagoItem?.Id.HasValue != true || 
                ( (PagoItem?.Clienteid ?? 0) == 0  && (PagoItem?.Proveedorid ?? 0) == 0)
               )
            {
                return;
            }
            PagosaplicadosItems = new List<V_doctopago_aplicadoWFBindingModel>();

            List<V_doctopago_aplicadoWFBindingModel>? buffer = null;


            Task.Run(async () =>
            {
                buffer = await pagoProvider.DoctoPagosAplicadosList(
                                                        (GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid ?? 0),
                                                        (GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid ?? 0),
                                                         PagoItem!.Id!.Value);
            }).Wait();

            if (buffer != null && buffer.Count > 0)
                PagosaplicadosItems = buffer;


        }



        public async Task<bool> Facturar(bool imprimirRecibo = false)
        {

            if((pagoItem?.Reciboelectronicoid ?? 0 ) == 0)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No se hizo el recibo electronico", "Error"));
                return false;
            }


            //si ya se hizo la factura entonces solo imprimela
            var doctoDelPago = new DoctoBindingModel()
            {
                EmpresaId = pagoItem!.EmpresaId,
                SucursalId = pagoItem!.SucursalId,
                Id = pagoItem!.Reciboelectronicoid!.Value
            };

            Task.Run(async () =>
            {

                doctoDelPago = await doctoProvider.GetById(doctoDelPago);
            }).Wait();


            if ( doctoDelPago != null && !string.IsNullOrEmpty(doctoDelPago!.Docto_fact_elect_Timbradouuid))
            {
                DoImprimirFactura();
                if(imprimirRecibo)
                {
                    DoImprimirRecibo();
                }
                BProcessSuccess = true;
                SuccessAddActions(PagoItem!);
                return true;
            }

            FacturacionViewModel vm = IoC.Get<FacturacionViewModel>();
            vm.AsignarDatoParaFacturar(
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                       pagoItem!.Reciboelectronicoid,
                                       null, false);
            await winManager.ShowDialogAsync(vm, null, CreateWinSettings("Facturacion", 0.25));

            if (vm.SeFacturo)
            {
                showPopUpMessage(new MessageToUserSimple("Procesado", "Se hizo la facturacion", "Success"));
                DoImprimirFactura();
                DoImprimirRecibo();
                SuccessAddActions(PagoItem!);
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
                EmpresaId = pagoItem!.EmpresaId,
                SucursalId = pagoItem!.SucursalId,
                Id = pagoItem!.Reciboelectronicoid!.Value
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
            dict.Add("empresaid", pagoItem!.EmpresaId!.Value);
            dict.Add("sucursalid", pagoItem!.SucursalId!.Value);
            dict.Add("itemid", pagoItem!.Id!.Value);


            dict.Add("US_ID", GlobalSession.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalSession.CurrentUsuario!.UsuarioNombre);


            var nombreReporte = this.TipoDoctoId == DBValues._DOCTO_TIPO_COMPRA ? "ReciboPagoProveedorMultiple.frx" : "ReciboPagoClienteMultiple.frx";

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




        public void Cancel()
        {
            if (PagoItem == null || (PagoItem.Id ?? 0) == 0)
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
                                                      await CancelarPago()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        bSuccess = false;
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        ErrorAddActions(PagoItem, comentario);
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            SuccessAddActions(PagoItem);
                        }
                        else
                        {
                            ErrorAddActions(PagoItem, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        CancelarPago();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {


                //        SuccessAddActions(PagoItem);
                //    }
                //    else
                //    {
                //        ErrorAddActions(PagoItem, comentario);
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }



        public async Task CancelarPago()
        {

            if (PagoItem == null)
                return;


            BaseResultBindingModel? tempResult = null;
            long? pagoId = null;
            
            tempResult = await pagoProvider.PagoCompuestoRevertir(
                            PagoItem.EmpresaId!.Value, PagoItem.SucursalId!.Value, PagoItem.Id!.Value,
                            GlobalVariable.CurrentSession!.Usuarioid!.Value, this.CorteId!.Value, PagoItem!.Notas);
            

            pagoId = tempResult?.Result;

            //this.pagoItem!.Id = pagoId;

        }


    }


}


