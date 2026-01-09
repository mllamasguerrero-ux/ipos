using BindingModels;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IposV3.ViewModels
{
    public class ReportePrintingViewModel: IposV3.ViewModels.BaseScreen.BaseScreen
    {
        public FastReportInfo? FastReportInfo { get; set; }

        protected readonly IEventAggregator aggregator;

        public ReportePrintingViewModel(SelectorWebController selectorProvider, IWindowManager winManager, IMessageBoxService messageBoxService, UsuarioWebController baseUsuarioControllerProvider, IEventAggregator aggregator) :
                    base(selectorProvider, winManager, messageBoxService) //, baseUsuarioControllerProvider, null)
        {

            this.aggregator = aggregator;


            aggregator.SubscribeOnUIThread(this);

        }



        public virtual void ViewLoaded(EventArgs args)
        {
            if ( (((System.Windows.Window)this.GetView()).Content is IReportShowReport) && FastReportInfo != null)
            {
                //((IReportShowReport)(((System.Windows.Window)this.GetView()).Content)).ShowReport(FastReportInfo);
                //this.TryCloseAsync();

                //((IReportShowReport)this.GetView()).ShowReport(FastReportInfo);

                //aggregator.Subscribe(this.GetView());
                //aggregator.PublishOnUIThread(FastReportInfo);
            }
            /*else
            {

                aggregator.PublishOnUIThread(this.GetView());
            }*/
        }


    }
}
