using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace iPosCustomReporting
{
    public partial class FQuery : Form
    {
        public FQuery()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {


            iPosCustomReporting.GeneralLookUp look = new iPosCustomReporting.GeneralLookUp(this.textBox1.Text, this.textBox3.Text);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            this.textBox2.Text = dr[0].ToString();
        }
    }
}
