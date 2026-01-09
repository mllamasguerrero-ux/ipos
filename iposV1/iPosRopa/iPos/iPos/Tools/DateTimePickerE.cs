using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace System.Windows.Forms
{
    class DateTimePickerE : DateTimePicker
    {
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message m, System.Windows.Forms.Keys k)
        {
            
            if (m.Msg == 256 && k == System.Windows.Forms.Keys.Enter)
            {
                
                System.Windows.Forms.SendKeys.Send("\t");
                
                return true;
            }
            
            return base.ProcessCmdKey(ref m, k);
        }
    }
}
