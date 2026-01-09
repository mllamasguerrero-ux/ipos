
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

    public class Motivo_devolucionDefinicionWFViewModel : BaseGenericViewModel
    {

        public Motivo_devolucionDefinicionWFBindingModel? Motivo_devolucionDefinicionItem { get; set; }
        public bool Cancelled { get; set; }


        public Motivo_devolucionDefinicionWFViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            Motivo_devolucionDefinicionItem = new Motivo_devolucionDefinicionWFBindingModel();
            Motivo_devolucionDefinicionItem!.PendingChange += CatalogField_PropertyChanging;


            this.Cancelled = true;
        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Motivo_devolucion")};

        }


        public void Accept()
        {
            if (Motivo_devolucionDefinicionItem!.Motivo_devolucionid == null)
            {

                showPopUpMessage("Motivo devolucion ", "Seleccionar el motivo de devolucion ", "Error");
                return;
            }

            if (Motivo_devolucionDefinicionItem!.Motivo_devolucionid != 3)
            {
                var catalog = this.Catalogs?["Motivo_devolucion"]?.FirstOrDefault(y => y.Id == Motivo_devolucionDefinicionItem!.Motivo_devolucionid);
                Motivo_devolucionDefinicionItem!.Motivo_devolucionClave = catalog?.Clave;
                Motivo_devolucionDefinicionItem!.Motivo_devolucionNombre = catalog?.Nombre;
            }

            this.Cancelled = false;
            this.TryCloseAsync();
        }

        public void Cancel()
        {
            this.Cancelled = true;
            this.TryCloseAsync();
        }


    }


}


