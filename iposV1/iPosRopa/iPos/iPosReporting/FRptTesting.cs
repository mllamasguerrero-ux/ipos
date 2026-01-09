using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using iPosData;
using iPosBusinessEntity;

namespace iPosReporting
{
    public partial class FRptTesting : Form
    {
        public FRptTesting()
        {
            InitializeComponent();
        }

        private void FRptTesting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSReportIpos2.TESTING_PRODUCTO' table. You can move, or remove it, as needed.
            this.TESTING_PRODUCTOTableAdapter.Fill(this.DSReportIpos2.TESTING_PRODUCTO);
            // TODO: This line of code loads data into the 'DSReportIpos2.TESTING_PERSONAS' table. You can move, or remove it, as needed.
            this.TESTING_PERSONASTableAdapter.Fill(this.DSReportIpos2.TESTING_PERSONAS);
            // TODO: This line of code loads data into the 'DSReportIpos2.TESTING_CORTE' table. You can move, or remove it, as needed.
            this.TESTING_CORTETableAdapter.Fill(this.DSReportIpos2.TESTING_CORTE);
            // TODO: This line of code loads data into the 'DSReportIpos2.TESTING_DOCTOS' table. You can move, or remove it, as needed.
            this.TESTING_DOCTOSTableAdapter.Fill(this.DSReportIpos2.TESTING_DOCTOS);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Seguro quieres resetear la bd? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return ;
            }

            CPARAMETROD pd = new CPARAMETROD();
            if (pd.TESTING_RESETEARBD(null))
            {
                MessageBox.Show("La base de datos se ha reseteado");
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
            }

        }
    }
}
