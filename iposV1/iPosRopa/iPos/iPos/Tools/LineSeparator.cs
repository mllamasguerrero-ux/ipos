using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace iPos.Tools
{
    public partial class LineSeparator : UserControl
    {
        public LineSeparator()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(LineSeparator_Paint);
            this.MaximumSize = new Size( 2,2000);
            this.MinimumSize = new Size(2, 0);
            this.Height = 350;
        }
        private void LineSeparator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.DarkGray, new Point(0, 0), new Point( 0,this.Height));
            g.DrawLine(Pens.White, new Point(1, 0), new Point(1, this.Height));
        }
    }
}
