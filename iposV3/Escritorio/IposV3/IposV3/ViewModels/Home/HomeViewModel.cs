using BindingModels;
using Caliburn.Micro;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
using IposV3.Model;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using MaterialDesignColors;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{
    public class HomeViewModel : IposV3.ViewModels.BaseScreen.BaseScreen, IHandle<HomeListVMEventParameters>
    {


        protected readonly IEventAggregator aggregator;

        public HomeViewModel(SelectorWebController selectorProvider, IWindowManager winManager, IMessageBoxService messageBoxService, 
                                 IEventAggregator aggregator) : base( selectorProvider, winManager, messageBoxService)
        {
          

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);


            this.messageBoxService = messageBoxService;
            MessageToUser = new MessageToUser("titulo", "este es un mensaje", "Information", false);



        }

        ~HomeViewModel()
        {
            this.aggregator.Unsubscribe(this);
        }

       


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        protected override Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

       


        public Task HandleAsync(HomeListVMEventParameters parameters, CancellationToken cancellationToken)
        {
            if (parameters.HasMessage && parameters.MsgSimple != null)
            {
                showPopUpMessage(parameters.MsgSimple);
            }


            return Task.CompletedTask;
        }

    }
}
