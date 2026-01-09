using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace StudentsManager.ViewModels {
    public class ShellViewModel : Conductor<object>, IHandle<SwitchToVm> {
        public ShellViewModel(IEventAggregator aggregator) {
            aggregator.SubscribeOnPublishedThread(this);

            //CurrentViewModel = IoC.Get<MainViewModel>();
        }

        private object currentViewModel = new object();

        public object CurrentViewModel {
            get { return currentViewModel; }
            private set {
                currentViewModel = value;
                NotifyOfPropertyChange();
            }
        }

        protected override async Task OnInitializeAsync(CancellationToken cancelationToken) {
            await ActivateItemAsync(CurrentViewModel);
        }
        public async Task HandleAsync(SwitchToVm message, CancellationToken cancellationToken) {
            MethodInfo? method = typeof (IoC).GetMethod("Get");
            MethodInfo? genericMethod = method?.MakeGenericMethod(message.ViewModel);

            await ActivateItemAsync(genericMethod?.Invoke(this, null) ?? new object());

            CurrentViewModel = message.ViewModel;
        }
    }
}