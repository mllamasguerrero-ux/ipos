using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPosReporting.Reporteria
{
    public partial class WFLongTextMessage : Form
    {

        public string MessageToShow { get; set; }
        public WFLongTextMessage()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WFLongTextMessage_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = MessageToShow;
        }
    }
}
