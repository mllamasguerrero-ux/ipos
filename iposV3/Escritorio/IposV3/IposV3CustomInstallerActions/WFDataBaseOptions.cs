using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IposV3CustomInstallerActions
{
    public partial class WFDataBaseOptions : Form
    {
        public bool InstalarMotorBD { get; set; }
        public WFDataBaseOptions()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            InstalarMotorBD = CBBaseDatos.Checked;
            this.Close();
        }
    }
}
