using IposV3.Model;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Data;

namespace IposV3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //new ApplicationDbContext(GetGeneralConnectionString);

        private CollectionViewSource empresaViewSource;

        public MainWindow()
        {
            InitializeComponent();
            empresaViewSource =
                (CollectionViewSource)FindResource(nameof(empresaViewSource));
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!

            // this forces the grid to refresh to latest values
            empresaDataGrid.Items.Refresh();
            sucursalesDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            base.OnClosing(e);
        }
    }
}
