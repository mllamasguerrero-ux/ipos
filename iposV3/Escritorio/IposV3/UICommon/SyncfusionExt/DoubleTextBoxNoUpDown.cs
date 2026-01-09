using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SyncfusionExt
{


    public class DoubleTextBoxNoUpDown: DoubleTextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.Key == Key.Down)
            {
                e.Handled = false;
                return;
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                e.Handled = false;
                return;
            }
        }
        
    }



}
