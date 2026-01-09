using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace System.Windows.FormsReporting
{
    public class DataGridViewE : System.Windows.Forms.DataGridView
    {

        public event EventHandler EnterKeyDownEvent;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                EventArgs e = new EventArgs();
                if (EnterKeyDownEvent != null)
                    EnterKeyDownEvent(this, e);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

