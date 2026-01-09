
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
using System.Windows;

namespace IposV3.ViewModels
{

    public class WFDescripcionComodinWFViewModel : BaseGenericViewModel
    {

        public WFDescripcionComodinWFBindingModel? WFDescripcionComodinItem { get; set; }

        public bool BProcessSuccess { get; protected set; }

        public WFDescripcionComodinWFViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            WFDescripcionComodinItem = new WFDescripcionComodinWFBindingModel();
            WFDescripcionComodinItem!.PendingChange += CatalogField_PropertyChanging;

            BProcessSuccess = false;

        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { };

        }

        public void Accept()
        {

            if(string.IsNullOrEmpty(WFDescripcionComodinItem?.Tbdesc1))
            {
                MessageBox.Show("Por favor escriba algo en la descripcion 1");
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


