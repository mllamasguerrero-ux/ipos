
using BindingModels;
using Caliburn.Micro;
using IposV3.Model;
using System;
using System.Windows;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for MainView.xaml
    /// </summary>
    public partial class ConfiguracionListView {

        public ConfiguracionListView() {
            InitializeComponent();  

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;
        }

        private void AddItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void SelectItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            ConfiguracionBindingModel? obj = ((FrameworkElement)sender).DataContext as ConfiguracionBindingModel;

            if (obj == null)
                return;

            //var configurationAction = ((IposV3.ViewModels.ConfiguracionListViewModel)DataContext).SelectItem(obj);
            //if (configurationAction.Action == "cambiar_conexion" && configurationAction.Parameters != null)
            //{
            //    ConnectionMgr.ChangeConnectionString(configurationAction.Parameters[0]);
            //    ((IposV3.ViewModels.ConfiguracionListViewModel)DataContext).Back();

            //}
            //else if (configurationAction.Action == "volver_atras" && configurationAction.Parameters != null)
            //{
            //    ((IposV3.ViewModels.ConfiguracionListViewModel)DataContext).Back();

            //}

        }
    }
}

