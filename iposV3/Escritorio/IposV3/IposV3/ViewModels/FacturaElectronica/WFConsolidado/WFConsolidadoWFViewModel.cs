
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using IposV3.Controllers.Controller;
using ViewModels.BaseScreen;
using System.Threading;

namespace IposV3.ViewModels
{

    public class WFConsolidadoWFViewModel : BaseGenericViewModel
    {

        public Tmp_config_porconsolidarWFBindingModel? WFConsolidadoItem { get; set; }


        public List<Tmp_docto_porconsolidarWFBindingModel> PorconsolidarItems { get; set; }

        public List<Tmp_suma_docto_porconsolidaWFBindingModel> PorconsolidarsumaItems { get; set; }

        public List<Tmp_dia_monto_porconsolidarWFBindingModel> TablefechamontoItems { get; set; }


        public Dictionary<string, bool> BoolBindingExpression { get; set; }

        private ConsolidadoWebController ConsolidadoProvider { get; set; }
        private readonly CfdiWebController cfdiProvider;
        protected readonly DoctoWebController doctoProvider;

        private DateTimeOffset _FechaInicial;
        public DateTimeOffset FechaInicial { get { return _FechaInicial; } set { _FechaInicial = value; if (ConstructorFinalizado) { CambioFechaInicial(); } } }


        private DateTimeOffset _FechaFinal;
        public DateTimeOffset FechaFinal { get { return _FechaFinal; } set { _FechaFinal = value;if(ConstructorFinalizado){ CambioFechaFinal(); } } }

        private DateTimeOffset _FechaActual;
        public DateTimeOffset FechaActual { get { return _FechaActual; } set { _FechaActual = value; if (ConstructorFinalizado) { CambioFechaActual(); } } }


        private bool ConstructorFinalizado = false;

        public WFConsolidadoWFViewModel( ConsolidadoWebController consolidadoProvider,
            CfdiWebController cfdiProvider,DoctoWebController doctoprovider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            WFConsolidadoItem = new Tmp_config_porconsolidarWFBindingModel();
            WFConsolidadoItem!.PendingChange += CatalogField_PropertyChanging;
            WFConsolidadoItem!.PropertyChanged += ItemChangedEventHandler;


            BoolBindingExpression = new Dictionary<string, bool>();
            fillBoolBindingExpressions();

            PorconsolidarItems = new List<Tmp_docto_porconsolidarWFBindingModel>();

            PorconsolidarsumaItems = new List<Tmp_suma_docto_porconsolidaWFBindingModel>();

            TablefechamontoItems = new List<Tmp_dia_monto_porconsolidarWFBindingModel>();

            WFConsolidadoItem!.AplicaMontoMaximo = BoolCN.N;
            WFConsolidadoItem!.AplicaMontoMaximoPorcentaje = BoolCN.N;
            WFConsolidadoItem!.AplicaMontoMaximoPorDia = BoolCN.N;
            WFConsolidadoItem!.Porgrupousuario = BoolCN.N;
            WFConsolidadoItem!.Tipoagrupacion = 1;


            WFConsolidadoItem!.OmitirVentasFranquicias = BoolCN.N;
            WFConsolidadoItem!.IncluirGastos = BoolCN.S;
            WFConsolidadoItem!.OmitirVales = BoolCN.N;
            WFConsolidadoItem!.OmitirClientesRfc = BoolCN.N;

            WFConsolidadoItem!.Anio = DateTime.Today.Year;
            WFConsolidadoItem!.Mes = DateTime.Today.Month - 1;

            WFConsolidadoItem!.UsuarioId = GlobalVariable.CurrentSession?.Usuarioid;

            WFConsolidadoItem!.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            WFConsolidadoItem!.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            FechaInicial = DateTimeOffset.Now.DateTime.Date;
            FechaFinal = DateTimeOffset.Now.DateTime.Date;
            FechaActual = DateTimeOffset.Now.DateTime.Date;




            ConsolidadoProvider = consolidadoProvider;
            this.cfdiProvider = cfdiProvider;
            this.doctoProvider = doctoprovider;

            ConstructorFinalizado = true;

        }


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            //DoImprimirFactura(220);

            ReloadItems();
            return Task.FromResult(true);
        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Grupousuario"), new CatalogDef(
                    "Meses")};

        }


        public void ItemChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {

                case "Tipoagrupacion":
                    BoolBindingExpression["AGRUPADOPORMES"] = this.WFConsolidadoItem != null && (this.WFConsolidadoItem.Tipoagrupacion == 1);
                    BoolBindingExpression["AGRUPADOPORFECHA"] = this.WFConsolidadoItem != null && (this.WFConsolidadoItem.Tipoagrupacion == 2);


                    if (BoolBindingExpression["AGRUPADOPORFECHA"])
                    {
                        this.WFConsolidadoItem!.AplicaMontoMaximo = BoolCN.N;
                        this.WFConsolidadoItem!.AplicaMontoMaximoPorcentaje = BoolCN.N;

                        LlenarGridFechas();
                        ReloadItems();
                    }

                    NotifyOfPropertyChange("WFConsolidadoItem");
                    NotifyOfPropertyChange("BoolBindingExpression");

                    break;


                case "Porgrupousuario":
                    BoolBindingExpression["PORGRUPOUSUARIO"] = this.WFConsolidadoItem != null && (this.WFConsolidadoItem.Porgrupousuario == BoolCN.S);

                    NotifyOfPropertyChange("WFConsolidadoItem");
                    NotifyOfPropertyChange("BoolBindingExpression");

                    break;


                case "AplicaMontoMaximo":
                    BoolBindingExpression["APLICAMONTOMAXIMO"] = this.WFConsolidadoItem != null && (this.WFConsolidadoItem.AplicaMontoMaximo == BoolCN.S);

                    if (!BoolBindingExpression["APLICAMONTOMAXIMO"])
                        WFConsolidadoItem!.MaximoMonto = 0m;

                    NotifyOfPropertyChange("WFConsolidadoItem");
                    NotifyOfPropertyChange("BoolBindingExpression");

                    break;


                case "AplicaMontoMaximoPorcentaje":
                    BoolBindingExpression["APLICAPORCENTAJEMAXIMO"] = this.WFConsolidadoItem != null && (this.WFConsolidadoItem.AplicaMontoMaximoPorcentaje == BoolCN.S);

                    if(!BoolBindingExpression["APLICAPORCENTAJEMAXIMO"])
                        WFConsolidadoItem!.MontoMaximoPorcentaje = 0m;

                    NotifyOfPropertyChange("WFConsolidadoItem");
                    NotifyOfPropertyChange("BoolBindingExpression");

                    break;


                case "AplicaMontoMaximoPorDia":
                    BoolBindingExpression["APLICAMONTOMAXIMOPORDIA"] = this.WFConsolidadoItem != null && (this.WFConsolidadoItem.AplicaMontoMaximoPorDia == BoolCN.S);


                    if (!BoolBindingExpression["APLICAMONTOMAXIMOPORDIA"])
                        WFConsolidadoItem!.MontoMaximoPorDia = 0m;

                    NotifyOfPropertyChange("WFConsolidadoItem");
                    NotifyOfPropertyChange("BoolBindingExpression");

                    break;



                default:
                    break;
            }
        }



        private void fillBoolBindingExpressions()
        {

            var boolBindingExpression = new Dictionary<string, bool>();

            boolBindingExpression.Clear();

            boolBindingExpression.Add("AGRUPADOPORMES", this.WFConsolidadoItem != null && (this.WFConsolidadoItem.Tipoagrupacion == 1));
            boolBindingExpression.Add("AGRUPADOPORFECHA", this.WFConsolidadoItem != null && (this.WFConsolidadoItem.Tipoagrupacion == 2));
            boolBindingExpression.Add("PORGRUPOUSUARIO", this.WFConsolidadoItem != null && (this.WFConsolidadoItem.Porgrupousuario == BoolCN.S));
            boolBindingExpression.Add("APLICAMONTOMAXIMO", this.WFConsolidadoItem != null && (this.WFConsolidadoItem.AplicaMontoMaximo == BoolCN.S));
            boolBindingExpression.Add("APLICAPORCENTAJEMAXIMO", this.WFConsolidadoItem != null && (this.WFConsolidadoItem.AplicaMontoMaximoPorcentaje == BoolCN.S));
            boolBindingExpression.Add("APLICAMONTOMAXIMOPORDIA", this.WFConsolidadoItem != null && (this.WFConsolidadoItem.AplicaMontoMaximoPorDia == BoolCN.S));


            this.BoolBindingExpression = boolBindingExpression;
            NotifyOfPropertyChange("BoolBindingExpression");


        }


        public void VerFacturas()
        {
            this.ReloadItems();
        }

        public void DiaAnterior()
        {
            var buffer = FechaActual.AddDays(-1);
            if(buffer >= FechaInicial && buffer <= FechaFinal)
                FechaActual = FechaActual.AddDays(-1);
        }

        public void DiaSiguiente()
        {

            var buffer = FechaActual.AddDays(1);
            if (buffer >= FechaInicial && buffer <= FechaFinal)
                FechaActual = FechaActual.AddDays(1);
        }

        public void CambioFechaActual()
        {

            if (!ConstructorFinalizado)
                return;

            if(this.WFConsolidadoItem!.Tipoagrupacion == 2)
            {
                this.ReloadItems();
                CargaMontoMaximoFecha(FechaActual);
            }
            NotifyOfPropertyChange("FechaActual");
        }

        public void CambioFechaInicial()
        {

            LlenarGridFechas();

            if (!(FechaActual >= FechaInicial && FechaActual <= FechaFinal))
                FechaActual = FechaInicial;

        }

        public void CambioFechaFinal()
        {


            LlenarGridFechas();

            if (!(FechaActual >= FechaInicial && FechaActual <= FechaFinal))
                FechaActual = FechaInicial;
        }


        public async Task Consolidar()
        {


            if (WFConsolidadoItem == null)
            {
                showPopUpMessage("Error ", "No hay parametros suficientes", "Error");
                return;
            }



            if (WFConsolidadoItem!.AplicaMontoMaximo != BoolCN.S)
                WFConsolidadoItem!.MaximoMonto = 0m;

            if (WFConsolidadoItem!.AplicaMontoMaximoPorcentaje != BoolCN.S)
                WFConsolidadoItem!.MontoMaximoPorcentaje = 0m;



            if (WFConsolidadoItem!.AplicaMontoMaximoPorDia != BoolCN.S)
                WFConsolidadoItem!.MontoMaximoPorDia = 0m;

            if (WFConsolidadoItem!.Porgrupousuario != BoolCN.S)
                WFConsolidadoItem!.GrupoUsuarioId = null;

            if (WFConsolidadoItem!.Tipoagrupacion == 1)
            {
                var firstDayOfMonth = new DateTime(Decimal.ToInt32(WFConsolidadoItem!.Anio!.Value), (int)(WFConsolidadoItem!.Mes ?? 0) + 1, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                WFConsolidadoItem.FechaIni = firstDayOfMonth;
                WFConsolidadoItem.FechaFin = lastDayOfMonth;
            }
            else
            {
                WFConsolidadoItem.FechaIni = this.FechaInicial;
                WFConsolidadoItem.FechaFin = this.FechaFinal;
            }


            if (WFConsolidadoItem!.Tipoagrupacion == 1)
            {
                await ConsolidarXMes(this.WFConsolidadoItem!);
            }
            else
            {
                await ConsolidarXDia(this.WFConsolidadoItem!);
            }

        }





        public async Task ConsolidarXDia(Tmp_config_porconsolidarWFBindingModel porConsolidar)
        {


            var fechaInicial = porConsolidar.FechaIni!;
            var fechaFinal = porConsolidar.FechaFin!;

            var successMessages = new List<string>();
            var failureMessages = new List<string>();

            try
            {
                IsBusy = true;

                for (DateTimeOffset fecha = fechaInicial.Value.Date; fecha.Date.CompareTo(fechaFinal.Value.Date) <= 0; fecha = fecha.AddDays(1))
                {
                    porConsolidar.FechaIni = fecha;
                    porConsolidar.FechaFin = fecha;

                    porConsolidar.MaximoPorcentaje = 0m;



                    var tmp_dia_monto = TablefechamontoItems.FirstOrDefault(y => y.Fecha == fecha);
                    if (tmp_dia_monto == null)
                        porConsolidar.MaximoMonto = 0m;
                    else
                        porConsolidar.MaximoMonto = tmp_dia_monto.Aplicamontomaximo == BoolCN.S ? tmp_dia_monto.Monto : 0m;


                    var result = await this.ConsolidarXPeriodo(porConsolidar);
                    if (result.Item1)
                    {
                        successMessages.Add(result.Item2);
                    }
                    else
                    {
                        failureMessages.Add(result.Item2);
                    }

                }

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
            finally
            {


                porConsolidar.FechaIni = fechaInicial;
                porConsolidar.FechaFin = fechaFinal;
                IsBusy = false;
                porConsolidar.MaximoMonto = 0m;
               

                if (successMessages.Count > 0)
                {

                    showPopUpMessage("Exitos", string.Join("\n",successMessages), "Success");
                }
                
                if(failureMessages.Count > 0)
                {

                    showPopUpMessage("Errores ", string.Join("\n", failureMessages), "Error");
                }
            }
        }


        public async Task ConsolidarXMes(Tmp_config_porconsolidarWFBindingModel porConsolidar)
        {
            IsBusy = true;
            var result = await this.ConsolidarXPeriodo(porConsolidar);
            if (result.Item1)
            {
                showPopUpMessage("Exito", result.Item2, "Success");
            }
            else
            {
                showPopUpMessage("Ocurrio un error ", result.Item2, "Error");
            }
            IsBusy = false;
        }

        public async Task<(bool,string)> ConsolidarXPeriodo(Tmp_config_porconsolidarWFBindingModel porConsolidar)
        {

            try
            {

                BaseResultBindingModel result = new BaseResultBindingModel();

                Task.Run(async () =>
                {
                    result = await ConsolidadoProvider.Consolidar(porConsolidar) ?? result;
                }).Wait();

                
                if ((result.Result ?? 0) > 0)
                {
                    if(await this.Facturar(result.Result!.Value))
                    {

                        DoImprimirFactura(result.Result!.Value);
                        return (false, "Se realizaron los consolidados  del periodo " +  porConsolidar.FechaIni!.Value.ToString("dd/MM/yyyy") + " a " + porConsolidar.FechaFin!.Value.ToString("dd/MM/yyyy"));
                    }
                }
                return (true, "No hay registros para procesar del periodo " + porConsolidar.FechaIni!.Value.ToString("dd/MM/yyyy") + " a " + porConsolidar.FechaFin!.Value.ToString("dd/MM/yyyy"));

            }
            catch (Exception ex)
            {
                return (true, "Excepcion al intentar hacer la consolidacion del periodo " + porConsolidar.FechaIni!.Value.ToString("dd/MM/yyyy") + " a " + porConsolidar.FechaFin!.Value.ToString("dd/MM/yyyy") + "." + ex.Message);
            }




        }

        public async Task<bool> Facturar(long doctoId)
        {


            FacturacionViewModel vm = IoC.Get<FacturacionViewModel>();
            vm.AsignarDatoParaFacturar(
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                       doctoId,
                                       null, false);
            await winManager.ShowDialogAsync(vm, null, CreateWinSettings("Facturacion", 0.25));

            return vm.SeFacturo;
        }

        private void DoImprimirFactura(long doctoId)
        {

            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReporteShowingViewModel vm = IoC.Get<ReporteShowingViewModel>();

            var currentDocto = new DoctoBindingModel() { 
                EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                SucursalId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                Id = doctoId
            };


            Task.Run(async () =>
            {

                currentDocto = await doctoProvider.GetById(currentDocto);
            }).Wait();

            if (currentDocto == null)
            {
                showPopUpMessage("Ocurrio un error al imprimir ", "no se encontro el documento", "Error");
                return;
            }

            string tipoComprobante = "F";
            string prefixComprobante = CfdiWebController.obtainPrefixByTipoComprobante(tipoComprobante);
            string imagenBiCode = "file:///" + cfdiProvider.Facturacion_FileLocalLocation_XML_Timbrados(currentDocto!.Tipodoctoid!.Value, GlobalVariable.CurrentSession!.CurrentParametro!, null) + "\\" + prefixComprobante + (currentDocto.Docto_fact_elect_Seriesat ?? "") + (currentDocto.Docto_fact_elect_Foliosat?.ToString() ?? "") + ".xml.png";
            string logoEmpresa = "file:///" + cfdiProvider.Facturacion_FileLocalLocation_FE_IMG(GlobalVariable.CurrentSession!.CurrentParametro!, currentDocto!.Tipodoctoid!.Value) + "\\logofarmafree.png";


            string? bufferNumCSD = System.IO.Path.GetFileName(GlobalVariable.CurrentSession!.CurrentParametro!.Timbradoarchivocertificado ?? "");
            string numCSD = bufferNumCSD == null ? "" : bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper();



            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("empresaid", GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value);
            dict.Add("sucursalid", GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value);
            dict.Add("doctoid", doctoId);
            dict.Add("desgloseKits", "S");


            dict.Add("US_ID", GlobalVariable.CurrentSession!.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalVariable.CurrentSession!.CurrentUsuario!.UsuarioNombre);
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

        public void Cancel()
        {

            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public void Back()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public void ActualizarMontoMaximoDia()
        {
            if (this.WFConsolidadoItem!.Tipoagrupacion == 1 || TablefechamontoItems == null || TablefechamontoItems.Count == 0)
                return;

            this.TablefechamontoItems!.Where(t => t.Fecha == FechaActual).ToList().ForEach(l =>
            {
                l.Aplicamontomaximo = WFConsolidadoItem!.AplicaMontoMaximoPorDia;
                l.Monto = WFConsolidadoItem!.MontoMaximoPorDia;
            });
        }



        private void LlenarGridFechas()
        {

            TablefechamontoItems.Clear();

            var bufferFechaMontoItems = new List<Tmp_dia_monto_porconsolidarWFBindingModel>();

            if (WFConsolidadoItem!.Tipoagrupacion == 1)
            {
                var firstDayOfMonth = new DateTime(Decimal.ToInt32(WFConsolidadoItem!.Anio!.Value), (int)(WFConsolidadoItem!.Mes ?? 0) + 1, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                WFConsolidadoItem.FechaIni = firstDayOfMonth;
                WFConsolidadoItem.FechaFin = lastDayOfMonth;
            }
            else
            {
                WFConsolidadoItem.FechaIni = FechaInicial;
                WFConsolidadoItem.FechaFin = FechaFinal;
            }

            for (DateTime fecha = WFConsolidadoItem.FechaIni!.Value.DateTime.Date; fecha.Date.CompareTo(WFConsolidadoItem.FechaFin!.Value.DateTime.Date) <= 0; fecha = fecha.AddDays(1))
            {
                var row = new Tmp_dia_monto_porconsolidarWFBindingModel();
                row.Fecha = fecha;
                row.Monto = 0;
                row.Aplicamontomaximo = BoolCN.N;
                bufferFechaMontoItems.Add(row);
            }

            WFConsolidadoItem.AplicaMontoMaximoPorDia = BoolCN.N;
            WFConsolidadoItem.MontoMaximoPorDia = 0m;

            TablefechamontoItems = bufferFechaMontoItems;

            NotifyOfPropertyChange("TablefechamontoItems");


        }



        private void CargaMontoMaximoFecha(DateTimeOffset? fecha)
        {

            WFConsolidadoItem!.MontoMaximoPorDia = 0m;
            WFConsolidadoItem!.AplicaMontoMaximoPorDia = BoolCN.N;

            if (TablefechamontoItems == null || TablefechamontoItems.Count == 0 || fecha == null)
                return;

            var tmp_dia_monto = TablefechamontoItems.FirstOrDefault(y => y.Fecha == fecha);


            if (tmp_dia_monto == null)
                return;


            WFConsolidadoItem!.MontoMaximoPorDia = tmp_dia_monto!.Monto ?? 0m;
            WFConsolidadoItem!.AplicaMontoMaximoPorDia = tmp_dia_monto!.Aplicamontomaximo ?? BoolCN.N;

        }


        public void ReloadItems()
        {

            if(WFConsolidadoItem == null)
            {
                showPopUpMessage("Error ", "No hay parametros suficientes", "Error");
                return;
            }

            if (WFConsolidadoItem!.AplicaMontoMaximo != BoolCN.S)
                WFConsolidadoItem!.MaximoMonto = 0m;

            if (WFConsolidadoItem!.AplicaMontoMaximoPorcentaje != BoolCN.S)
                WFConsolidadoItem!.MontoMaximoPorcentaje = 0m;

            if (WFConsolidadoItem!.AplicaMontoMaximoPorDia != BoolCN.S)
                WFConsolidadoItem!.MontoMaximoPorDia = 0m;

            if (WFConsolidadoItem!.Porgrupousuario != BoolCN.S)
                WFConsolidadoItem!.GrupoUsuarioId = null;

            if (WFConsolidadoItem!.Tipoagrupacion == 1)
            {
                var firstDayOfMonth = new DateTime(Decimal.ToInt32(WFConsolidadoItem!.Anio!.Value), (int)(WFConsolidadoItem!.Mes ?? 0) + 1, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                WFConsolidadoItem.FechaIni = firstDayOfMonth;
                WFConsolidadoItem.FechaFin = lastDayOfMonth;
            }
            else
            {
                WFConsolidadoItem.FechaIni = this.FechaActual;
                WFConsolidadoItem.FechaFin = this.FechaActual;
            }


            PorconsolidarItems.Clear();
            PorconsolidarsumaItems.Clear();
            //TablefechamontoItems.Clear();



            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                Tmp_info_porconsolidar? info = null;



                Task.Run<Tmp_info_porconsolidar?>(async () =>
                                                      await this.ConsolidadoProvider.ConsolidadoInfo(this.WFConsolidadoItem!)

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

                            PorconsolidarItems = info!.DoctosPorConsolidar ?? new List<Tmp_docto_porconsolidarWFBindingModel>();
                            PorconsolidarsumaItems = info!.SumasDoctosPorConsolidar ?? new List<Tmp_suma_docto_porconsolidaWFBindingModel>();
                            //TablefechamontoItems = info!.DiasMontosPorConsolidar ?? new List<Tmp_dia_monto_porconsolidarWFBindingModel>();


                            NotifyOfPropertyChange("PorconsolidarItems");
                            NotifyOfPropertyChange("PorconsolidarsumaItems");
                            NotifyOfPropertyChange("TablefechamontoItems");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        info = this.ConsolidadoProvider.ConsolidadoInfo(this.WFConsolidadoItem!);
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;
                //    if (bSuccess)
                //    {

                //        PorconsolidarItems = info!.DoctosPorConsolidar ?? new List<Tmp_docto_porconsolidarWFBindingModel>();
                //        PorconsolidarsumaItems = info!.SumasDoctosPorConsolidar ?? new List<Tmp_suma_docto_porconsolidaWFBindingModel>();
                //        //TablefechamontoItems = info!.DiasMontosPorConsolidar ?? new List<Tmp_dia_monto_porconsolidarWFBindingModel>();


                //        NotifyOfPropertyChange("PorconsolidarItems");
                //        NotifyOfPropertyChange("PorconsolidarsumaItems");
                //        NotifyOfPropertyChange("TablefechamontoItems");
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

    }


}


