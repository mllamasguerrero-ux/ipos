using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    public partial class WFCatalogosSatUsoCFDIOperativo : Form
    {
        public WFCatalogosSatUsoCFDIOperativo()
        {
            InitializeComponent();
        }

        private void sAT_USOCFDIBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sAT_USOCFDIBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSCatalogosSat);

        }

        private void sAT_USOCFDIBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.sAT_USOCFDIBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSCatalogosSat);

        }

        private void WFCatalogosSatUsoCFDIOperativo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogosSat.SAT_USOCFDI' table. You can move, or remove it, as needed.
            this.sAT_USOCFDITableAdapter.Fill(this.dSCatalogosSat.SAT_USOCFDI);

        }

        private void filtrarButton_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(this.dSCatalogosSat.SAT_USOCFDI);
            dv.RowFilter = string.Format("SAT_DESCRIPCION LIKE '%{0}%'", filtroTextBox.Text);
            sAT_USOCFDIDataGridView.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSAT_USOCFDI_OPERD prodServOperDao = new CSAT_USOCFDI_OPERD();

            FbConnection fbConn = new FbConnection(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            FbTransaction fbTrans = null;

            try
            {
                fbConn.Open();
                fbTrans = fbConn.BeginTransaction();

                foreach (iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat.SAT_USOCFDIRow row in this.dSCatalogosSat.SAT_USOCFDI)
                {
                    CSAT_USOCFDI_OPERBE prodServOper = new CSAT_USOCFDI_OPERBE();
                    prodServOper.ISAT_USOCFDIID = row.ID;
                    if (row.HACAMBIADO == "S")
                    {
                        if (row.ESOPERATIVA == "S")
                        {
                            //ver si existe y si no existe agregar
                            if (prodServOperDao.ExisteSAT_USOCFDI_OPER_X_USOCFDIID(prodServOper, fbTrans))
                            {
                                continue;
                            }
                            else
                            {
                                if (prodServOperDao.AgregarSAT_USOCFDI_OPER(prodServOper, fbTrans) == null)
                                {
                                    fbTrans.Rollback();
                                    fbConn.Close();
                                    MessageBox.Show("Error al agregar registro");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (!prodServOperDao.BorrarSAT_USOCFDI_OPER_X_PRODUCTOSERVICIOID(prodServOper, fbTrans))
                            {
                                fbTrans.Rollback();
                                fbConn.Close();
                                MessageBox.Show("Error al eliminar registro");
                                break;
                            }
                        }
                    }
                }

                fbTrans.Commit();
                fbConn.Close();

                MessageBox.Show("Elementos guardados correctamente");
            }
            catch (Exception ex)
            {
                fbTrans.Rollback();
                fbConn.Close();
                MessageBox.Show("Problema al agregar registros: " + ex.Message);
            }
        }

        private void sAT_USOCFDIDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string cellName = sAT_USOCFDIDataGridView.Columns[e.ColumnIndex].Name;
            if (cellName == "DGOPERATIVA")
            {
                sAT_USOCFDIDataGridView.Rows[e.RowIndex].Cells["DGHACAMBIADO"].Value = "S";
            }
        }
    }
}
