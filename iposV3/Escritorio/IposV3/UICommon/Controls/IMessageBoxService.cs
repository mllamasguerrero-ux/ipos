using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.BaseScreen
{
    public interface IMessageBoxService
    {
        bool ShowSiNoMessage(string text, string caption, MessageType messageType);
    }
}
