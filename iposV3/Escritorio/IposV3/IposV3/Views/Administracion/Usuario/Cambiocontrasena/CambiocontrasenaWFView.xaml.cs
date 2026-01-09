
using System;
using System.Windows;
using System.Windows.Controls;

namespace IposV3.Views {
    /// <summary>
    ///     Interaction logic for CambiocontrasenaAddEditWindow.xaml
    /// </summary>
    public partial class CambiocontrasenaWFView {
      
        public CambiocontrasenaWFView() {
            InitializeComponent();

            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Height = Double.NaN;
            Width = Double.NaN;
        }


        private void PasswordBox_ContrasenaAnteriorChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).CambiocontrasenaItem.ContrasenaAnterior = new System.Net.NetworkCredential(string.Empty, ((PasswordBox)sender).SecurePassword).Password; }
        }

        private void PasswordBox_ContrasenaNuevaChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).CambiocontrasenaItem.ContrasenaNueva = new System.Net.NetworkCredential(string.Empty, ((PasswordBox)sender).SecurePassword).Password;   }
        }

        private void PasswordBox_ContrasenaConfirmacionChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).CambiocontrasenaItem.ContrasenaConfirmacion = new System.Net.NetworkCredential(string.Empty, ((PasswordBox)sender).SecurePassword).Password; }
        }
    }
}
