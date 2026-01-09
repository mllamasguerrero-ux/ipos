using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Tools
{
    public partial class WFCustomMessageBox : Form
    {
        public string result;
        public WFCustomMessageBox()
        {
            InitializeComponent();

            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
        }

        public void Show(string title, string message, string btn1, string btn2, string btn3, string btn4)
        {
            this.lblHead.Text = title;

            this.lblMessage.Text = message;

            if(btn1.Equals(null) || btn1.Equals(""))
            {
                this.button1.Visible = false;
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Text = btn1; 
                this.button1.Visible = true;
                this.button1.Enabled = true;
            }
            if (btn2.Equals(null) || btn2.Equals(""))
            {
                this.button2.Visible = false;
                this.button2.Enabled = false;
            }
            else
            {
                this.button2.Text = btn2; 
                this.button2.Visible = true;
                this.button2.Enabled = true;
            }
            if (btn3.Equals(null) || btn3.Equals(""))
            {
                this.button3.Visible = false;
                this.button3.Enabled = false;
            }
            else
            {
                this.button3.Text = btn3; 
                this.button3.Visible = true;
                this.button3.Enabled = true;
            }
            if (btn4.Equals(null) || btn4.Equals(""))
            {
                this.button4.Visible = false;
                this.button4.Enabled = false;
            }
            else
            {
                this.button4.Text = btn4; 
                this.button4.Visible = true;
                this.button4.Enabled = true;
            }

            this.ShowDialog();
        }

        public void Show(string title, string message, string btn1, string btn2, string btn3)
        {
            this.lblHead.Text = title;
            this.lblMessage.Text = message;

            this.button1.Visible = true;
            this.button1.Enabled = true;
            this.button1.Text = btn1;

            this.button2.Visible = true;
            this.button2.Enabled = true;
            this.button2.Text = btn2;

            this.button3.Visible = true;
            this.button3.Enabled = true;
            this.button3.Text = btn3;

            this.ShowDialog();
        }

        public void Show(string title, string message, string btn)
        {
            this.lblHead.Text = title;

            this.lblMessage.Text = message;

            
            this.button1.Visible = false;
            this.button1.Enabled = false;
            
            
            this.button2.Visible = false;
            this.button2.Enabled = false;
           
            this.button3.Visible = false;
            this.button3.Enabled = false;
         
            if (btn.Equals(null) || btn.Equals(""))
            {
                this.button4.Visible = false;
                this.button4.Enabled = false;
            }
            else { this.button4.Text = btn; }

            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result =  button1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = button2.Text;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = button3.Text;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = button4.Text;
            this.Close();
        }
    }
}
