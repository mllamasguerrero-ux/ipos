
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

    public class LoteImportadoDefinicionWFViewModel : BaseGenericViewModel
    {

        public LoteImportadoDefinicionWFBindingModel? LoteImportadoItem { get; set; }
        LotesimportadosWebController lotesImportadosController;
        public long? LoteImportadoId { get; set; }

        public bool BProcessSuccess { get; protected set; }
        public LoteImportadoDefinicionWFViewModel(LotesimportadosWebController lotesImportadosWebController,  SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            LoteImportadoItem = new LoteImportadoDefinicionWFBindingModel();
            LoteImportadoItem!.PendingChange += CatalogField_PropertyChanging;

            this.lotesImportadosController = lotesImportadosController;


        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("LoteImportadoItem","Producto","Productoid", "Productoclave", "Productonombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("LoteImportadoItem","Sat_aduana","Sataduanaid", "Sataduanaclave", "Sataduananombre","IposV3.ViewModels.Sat_aduanaListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { };

        }



        public void Accept()
        {

            if (
                LoteImportadoItem != null &&
                LoteImportadoItem?.Pedimento != null && (LoteImportadoItem?.Pedimento?.Trim().Length ?? 0) != 0 &&
                LoteImportadoItem?.Sataduanaid != null && (LoteImportadoItem?.Sataduanaid ?? 0) != 0 &&
                LoteImportadoItem?.Fechavence != null &&
                LoteImportadoItem?.Tipocambio != null)
            {

                try
                {
                    var loteImportadoBM = new LotesimportadosBindingModel()
                    {
                        EmpresaId = GlobalVariable.CurrentSession!.Empresaid,
                        SucursalId = GlobalVariable.CurrentSession.Sucursalid,
                        Pedimento = LoteImportadoItem.Pedimento,
                        Sataduanaid = LoteImportadoItem.Sataduanaid,
                        Fechaimportacion = LoteImportadoItem.Fechavence,
                        Tipocambio = LoteImportadoItem.Tipocambio

                    };

                    var loteImportadoRecord = lotesImportadosController.AddOrReturn(loteImportadoBM);

                    if (loteImportadoRecord != null)
                    {
                        LoteImportadoId = loteImportadoRecord.Id;

                        BProcessSuccess = true;

                        this.TryCloseAsync();
                    }
                }
                catch
                {
                    
                    throw;
                }
            }
        }


        public void Cancel()
        {
            this.TryCloseAsync();
        }

    }


}


