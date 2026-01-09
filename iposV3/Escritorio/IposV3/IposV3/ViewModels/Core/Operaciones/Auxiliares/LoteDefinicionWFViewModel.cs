
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
using System.Windows;

namespace IposV3.ViewModels
{

    public class LoteDefinicionWFViewModel : BaseGenericViewModel
    {

        public LoteDefinicionWFBindingModel? LoteItem { get; set; }


        public bool BProcessSuccess { get; protected set; }

        public LoteDefinicionWFViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            LoteItem = new LoteDefinicionWFBindingModel();
            LoteItem!.PendingChange += CatalogField_PropertyChanging;

            BProcessSuccess = false;

        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("LoteDefinicionItem","Producto","Productoid", "Productoclave", "Productonombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { };

        }


        public void Accept()
        {

            if(string.IsNullOrEmpty(this.LoteItem!.Lote) || this.LoteItem!.Fechavence == null)
            {
                MessageBox.Show("Por favor seleccione un lote y fecha vence validos");
                return;
            }

            BProcessSuccess = true;

            this.TryCloseAsync();
        }

        public void Cancel()
        {
            this.TryCloseAsync();
        }

    }


}


