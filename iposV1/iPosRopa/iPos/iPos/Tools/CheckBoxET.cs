using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace System.Windows.Forms
{
    class CheckBoxET : CheckBox
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
        public CheckBoxET()
            :base()
        {
            this.Enter += new EventHandler(CheckBoxET_Enter);
            this.Leave +=new EventHandler(CheckBoxET_Leave);
        }
        private void CheckBoxET_Enter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;
        }
        private void CheckBoxET_Leave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(211, 222, 229);
        }
    }
}
