
using System;
using System.Windows.Controls;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for ScreendefloteimportadoAddEditWindow.xaml
    /// </summary>
    public partial class LoteImportadoDefinicionWFView
    {
      
        public LoteImportadoDefinicionWFView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;
        }


        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Pedimento.Focus();
        }
    }
}
