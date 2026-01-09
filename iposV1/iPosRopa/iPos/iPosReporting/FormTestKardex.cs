using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPosReporting
{
	public partial class FormTestKardex : Form
	{
		public FormTestKardex()
		{
			InitializeComponent();
		}

		private void fillToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.gET_KARDEXTableAdapter.Fill(this.dSReportIpos.GET_KARDEX, new System.Nullable<long>(((long)(System.Convert.ChangeType(pRODUCTO_IDToolStripTextBox.Text, typeof(long))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAINIToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAFINToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(aLMACENIDToolStripTextBox.Text, typeof(long))))));
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}

		private void gET_KARDEXDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
