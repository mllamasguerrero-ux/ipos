using Syncfusion.Windows.Controls.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Converters
{
    public class SfTextBoxExt2 : SfTextBoxExt
    {
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if(e.Key == Key.Enter)
            {
                e.Handled = false;
            }

        }
    }
}
