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
    public partial class WFCatalogosSatLinea : Form
    {
        public WFCatalogosSatLinea()
        {
            InitializeComponent();
        }

        private void sAT_PRODUCTOSERVICIO_LINEABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sAT_PRODUCTOSERVICIO_LINEABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSCatalogosSat);

        }

        private void LINEAIDTextBox_Validated(object sender, EventArgs e)
        {

            if (this.LINEAIDTextBox.Text != "")
            {
                try
                {
                    int lineaId = Int32.Parse(this.LINEAIDTextBox.DbValue.ToString());
                    LlenarGrid(lineaId);
                }
                catch
                {

                }
            }
            else
            {
                this.dSCatalogosSat.SAT_PRODUCTOSERVICIO_LINEA.Clear();
            }
        }

        private void LlenarGrid(int lineaId)
        {
            try
            {
                this.sAT_PRODUCTOSERVICIO_LINEATableAdapter.Fill(this.dSCatalogosSat.SAT_PRODUCTOSERVICIO_LINEA, lineaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void filtrarButton_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(this.dSCatalogosSat.SAT_PRODUCTOSERVICIO_LINEA);
            dv.RowFilter = string.Format("SAT_DESCRIPCION LIKE '%{0}%'", filtroTextBox.Text);
            sAT_PRODUCTOSERVICIO_LINEADataGridView.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(LINEAIDTextBox.Text))
            {
                MessageBox.Show("Ingrese una línea antes de guardar");
                return;
            }

            CSAT_PRODUCTOSERVICIO_LINEAD prodServLineaDao = new CSAT_PRODUCTOSERVICIO_LINEAD();

            FbConnection fbConn = new FbConnection(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            FbTransaction fbTrans = null;

            try
            {
                fbConn.Open();
                fbTrans = fbConn.BeginTransaction();

                foreach (iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat.SAT_PRODUCTOSERVICIO_LINEARow row in this.dSCatalogosSat.SAT_PRODUCTOSERVICIO_LINEA)
                {
                    CSAT_PRODUCTOSERVICIO_LINEABE prodServLinea = new CSAT_PRODUCTOSERVICIO_LINEABE();
                    prodServLinea.ISAT_PRODUCTOSERVICIOID = row.ID;
                    prodServLinea.ILINEAID = long.Parse(LINEAIDTextBox.Text);
                    if (row.HACAMBIADO == "S")
                    {
                        if (row.ESOPERATIVA == "S")
                        {
                            //ver si existe y si no existe agregar
                            if (prodServLineaDao.ExisteSAT_PRODUCTOSERVICIO_LINEA_X_PRODUCTOSERVICIOID(prodServLinea, fbTrans))
                            {
                                continue;
                            }
                            else
                            {
                                if (prodServLineaDao.AgregarSAT_PRODUCTOSERVICIO_LINEA(prodServLinea, fbTrans) == null)
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
                            if (!prodServLineaDao.BorrarSAT_PRODUCTOSERVICIO_LINEAD_X_PRODUCTOSERVICIOID(prodServLinea, fbTrans))
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

        private void sAT_PRODUCTOSERVICIO_LINEADataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string cellName = sAT_PRODUCTOSERVICIO_LINEADataGridView.Columns[e.ColumnIndex].Name;
            if (cellName == "ESOPERATIVA")
            {
                sAT_PRODUCTOSERVICIO_LINEADataGridView.Rows[e.RowIndex].Cells["HACAMBIADO"].Value = "S";
            }
        }

        private void WFCatalogosSatLinea_Load(object sender, EventArgs e)
        {
            sAT_PRODUCTOSERVICIO_LINEADataGridView.AutoGenerateColumns = false;
        }

        private void filtroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sAT_PRODUCTOSERVICIO_LINEATableAdapter.Fill(this.dSCatalogosSat.SAT_PRODUCTOSERVICIO_LINEA, new System.Nullable<int>(((int)(System.Convert.ChangeType(lINEAIDToolStripTextBox.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/
    }
}
