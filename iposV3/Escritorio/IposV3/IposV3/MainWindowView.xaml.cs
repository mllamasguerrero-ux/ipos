using System;
using System.Diagnostics;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input; 
//using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using System.Windows.Media;
using IposV3.ViewModels;
using Caliburn.Micro;
//using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using Controllers.BindingModel;
using System.Linq;
using System.Windows.Controls.Ribbon;


namespace IposV3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window {

        public static Snackbar? Snackbar;
        public MainWindowView()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2500);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for the demo here we 
                //need to get the message queue from the snackbar, so need to be on the dispatcher
                MainSnackbar?.MessageQueue?.Enqueue("Bienvenido a Ipos SnowLeopard");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            //DataContext = new MainWindowViewModel(IoC.Get<IMenuitemsProvider<MyMenuDataBindingModel>>(),  IoC.Get<IEventAggregator>());

            Snackbar = this.MainSnackbar;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }


        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var configurationActionList = ((IposV3.ViewModels.MainWindowViewModel)DataContext).ConfigurationActionList;
            //if (configurationActionList != null)
            //{
            //    var configurationActionChangeConnection = configurationActionList.Where(y => y.Action.Equals("cambiar_conexion")).FirstOrDefault();
            //    if (configurationActionChangeConnection != null)
            //    {

            //        ConnectionMgr.ChangeConnectionString(configurationActionChangeConnection.Parameters[0]);
            //        ((IposV3.ViewModels.MainWindowViewModel)DataContext).ConfigurationActionList.RemoveAll(y => y.Action.Equals("cambiar_conexion"));
            //    }
            //}

        }
    } 
}
