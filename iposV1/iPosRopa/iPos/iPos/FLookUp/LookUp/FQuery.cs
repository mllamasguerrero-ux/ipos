using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace iPos
{
    public partial class FQuery : IposForm
    {
        public FQuery()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
           
            iPos.GeneralLookUp look = new iPos.GeneralLookUp(this.textBox1.Text,this.textBox3.Text);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            this.textBox2.Text = dr[0].ToString();
        }

        private void FQuery_Load(object sender, EventArgs e)
        {

        }
    }
}
