using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFMain2 : Form
    {
        public WFMain2()
        {
            InitializeComponent();


        }

        private void WFMain2_Load(object sender, EventArgs e)
        {

            try
            {
                this.mENUITEMSTableAdapter.Fill(this.dSAccessControl.MENUITEMS, 17);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
