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
    public partial class TestConversion1 : Form
    {
        public TestConversion1()
        {
            InitializeComponent();
        }


        private void TestConversion1_Load(object sender, EventArgs e)
        {
            this.UNIDADTextBox.llenarDatos();
            this.reportViewer1.RefreshReport();

            bANCO_VIEWTableAdapter.Fill(dSCatalogos.BANCO_VIEW, "%%");

            testAutoComplete.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Hola");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(checkBox1.Name + checkBox1.Checked.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox ctrl = (ComboBox)sender;
            System.Windows.Forms.MessageBox.Show(ctrl.Name);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox ctrl = (ListBox)sender;
            System.Windows.Forms.MessageBox.Show(ctrl.Name);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            System.Windows.Forms.MessageBox.Show(radioButton1.Name +  radioButton1.Checked);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            System.Windows.Forms.MessageBox.Show("Hola");
        }

        private void m4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.MessageBox.Show("Hola");
        }

        private void bANCO_VIEWDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar2.Style = ProgressBarStyle.Marquee;
            numericUpDown1.Value = 8;
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("enter");
            }

        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                MessageBox.Show("enter");
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("enter");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("enter");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {

        }



        public System.Windows.Forms.AutoCompleteStringCollection GetAutoSourceCollectionFromTable()
        {

            iPosData.CPRODUCTOD prodD = new iPosData.CPRODUCTOD();

            DataTable table = prodD.getProductoNombres(false);

            System.Windows.Forms.AutoCompleteStringCollection autoSourceCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {

                autoSourceCollection.Add(row[0].ToString().Trim() + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString()); //assuming required data is in first column

            }
            return autoSourceCollection;

        }
        

    }
}
