
using System;
using System.Windows.Controls;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for WFDescripcionComodinAddEditWindow.xaml
    /// </summary>
    public partial class WFDescripcionComodinWFView {
      
        public WFDescripcionComodinWFView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Tbdesc1.Focus();
        }
    }
}
