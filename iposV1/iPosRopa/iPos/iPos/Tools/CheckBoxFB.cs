using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace iPos.Tools
{
    class CheckBoxFB : CheckBoxET
    {
        public string TextValue
        {
            get
            {
                if (this.Checked)
                    return "1";
                else
                    return "0";
            }
            set
            {
                if (value == "1")
                    this.Checked = true;
                else
                    this.Checked = false;
            }
        }
       
    }
}
