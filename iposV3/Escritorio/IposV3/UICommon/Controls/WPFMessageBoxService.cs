using BindingModels;
using ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Controls
{
    public class WPFMessageBoxService : IMessageBoxService
    {
        public bool ShowSiNoMessage(string text, string caption, MessageType messageType)
        {
            var dialogResult = MessageBox.Show(text, caption, MessageBoxButton.YesNo);
            return dialogResult == MessageBoxResult.Yes;


        }
    }
}
