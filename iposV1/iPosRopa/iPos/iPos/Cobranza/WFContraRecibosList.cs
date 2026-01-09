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

namespace iPos
{
    public partial class WFContraRecibosList : IposForm
    {
        public WFContraRecibosList()
        {
            InitializeComponent();
        }

        private void btnLookVenta_Click(object sender, EventArgs e)
        {

            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, 0);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                int folio = int.Parse(dr["FOLIO"].ToString());
                this.TBFolioVenta.Text = folio.ToString();
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            iPos.WFContraRecibos rp = new iPos.WFContraRecibos();
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);

            LlenarGrid();
        }


        private void LlenarGrid()
        {
            try
            {
                int estadoid = -1;

               switch(CBEstado.SelectedIndex)
                {
                    case 1: estadoid = 1; break;
                    case 2: estadoid = 0; break;
                    case 3: estadoid = 2; break;
                    default: estadoid = -1; break;
                }

                string filtrarfecha = CBFecha.Checked ? "S" : "N";
                int folio = CBFolioContrarecibo.Checked ? int.Parse(TBFolioContrarecibo.Text) : 0;
                int venta = CBFolioVenta.Checked ? int.Parse(TBFolioVenta.Text) : 0;
                DateTime fechaini = DTPFechaInicio.Value;
                DateTime fechafin = DTPFechaFin.Value;
                int personaid = CBCliente.Checked && this.CLIENTECLAVETextBox.Text != "" ? Int32.Parse(this.CLIENTECLAVETextBox.DbValue.ToString()) : 0;
            
                this.contrareciboLstTableAdapter.Fill(this.dSCobranza2.ContrareciboLst,folio, filtrarfecha, fechaini, fechafin, personaid, venta, estadoid);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void WFContraRecibosList_Load(object sender, EventArgs e)
        {
            CBEstado.SelectedIndex = 0;
            LlenarGrid();
        }

        private void contrareciboLstDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (contrareciboLstDataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                        long dtlId = long.Parse(contrareciboLstDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());


                        iPos.WFContraRecibos rp = new iPos.WFContraRecibos(dtlId);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        LlenarGrid();

                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            try
            {
                int estadoid = -1;

                switch (CBEstado.SelectedIndex)
                {
                    case 1: estadoid = 1; break;
                    case 2: estadoid = 0; break;
                    case 3: estadoid = 2; break;
                    default: estadoid = -1; break;
                }

                string filtrarfecha = CBFecha.Checked ? "S" : "N";
                int folio = CBFolioContrarecibo.Checked ? int.Parse(TBFolioContrarecibo.Text) : 0;
                int venta = CBFolioVenta.Checked ? int.Parse(TBFolioVenta.Text) : 0;
                DateTime fechaini = DTPFechaInicio.Value;
                DateTime fechafin = DTPFechaFin.Value;
                int personaid = CBCliente.Checked && this.CLIENTECLAVETextBox.Text != "" ? Int32.Parse(this.CLIENTECLAVETextBox.DbValue.ToString()) : 0;



                string personaNombre = CLIENTECLAVELabel.Text;
                string estatusNombre = CBEstado.Text;
                string filtrarFolioContrarecibo =  CBFolioContrarecibo.Checked ? "S" : "N";
                string filtrarFolioVenta = CBFolioVenta.Checked ? "S" : "N";
                string filtroCliente = CBCliente.Checked ? "S" : "N";

                //this.contrareciboLstTableAdapter.Fill(this.dSCobranza2.ContrareciboLst, folio, filtrarfecha, fechaini, fechafin, personaid, venta, estadoid);




                Dictionary<string, object> dictionary = new Dictionary<string, object>();



                dictionary.Add("folio",folio);
                dictionary.Add("filtrarFecha", filtrarfecha);
                dictionary.Add("fechaini", fechaini);
                dictionary.Add("fechafin", fechafin);
                dictionary.Add("personaid", personaid);
                dictionary.Add("venta", venta);
                dictionary.Add("estatusid", estadoid);
                dictionary.Add("personaNombre", personaNombre);
                dictionary.Add("estatusNombre", estatusNombre);
                dictionary.Add("filtrarFolioContrarecibo", filtrarFolioContrarecibo);
                dictionary.Add("filtrarFolioVenta", filtrarFolioVenta);
                dictionary.Add("filtroCliente", filtroCliente);





                string strReporte = "ContrarecibosList.frx";



                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    
    }
}
