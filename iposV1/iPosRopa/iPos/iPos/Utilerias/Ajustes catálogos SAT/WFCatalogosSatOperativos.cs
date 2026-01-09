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
    public partial class WFCatalogosSatOperativos : Form
    {
        public WFCatalogosSatOperativos()
        {
            InitializeComponent();
        }

        private void sAT_PRODUCTOSERVICIOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sAT_PRODUCTOSERVICIOBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSCatalogosSat);

        }

        private void WFCatalogosSatOperativos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogosSat.SAT_PRODUCTOSERVICIO' table. You can move, or remove it, as needed.
            this.sAT_PRODUCTOSERVICIOTableAdapter.Fill(this.dSCatalogosSat.SAT_PRODUCTOSERVICIO);

        }

        private void sAT_PRODUCTOSERVICIODataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string cellName = sAT_PRODUCTOSERVICIODataGridView.Columns[e.ColumnIndex].Name;
            if(cellName == "DGOPERATIVA")
            {
                sAT_PRODUCTOSERVICIODataGridView.Rows[e.RowIndex].Cells["DGHACAMBIADO"].Value = "S";
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            CSAT_PRODUCTOSERVICIO_OPERD prodServOperDao = new CSAT_PRODUCTOSERVICIO_OPERD();

            FbConnection fbConn = new FbConnection(ConexionesBD.ConexionBD.ConexionStringPoolingForced());
            FbTransaction fbTrans = null;

            try
            {
                fbConn.Open();
                fbTrans = fbConn.BeginTransaction();

                foreach (iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat.SAT_PRODUCTOSERVICIORow row in this.dSCatalogosSat.SAT_PRODUCTOSERVICIO)
                {
                    CSAT_PRODUCTOSERVICIO_OPERBE prodServOper = new CSAT_PRODUCTOSERVICIO_OPERBE();
                    prodServOper.ISAT_PRODUCTOSERVICIOID = row.ID;
                    if (row.HACAMBIADO == "S")
                    {
                        if (row.ESOPERATIVA == "S")
                        {
                            //ver si existe y si no existe agregar
                            if (prodServOperDao.ExisteSAT_PRODUCTOSERVICIO_OPER_X_PRODUCTOSERVICIOID(prodServOper, fbTrans))
                            {
                                continue;
                            }
                            else
                            {
                                if(prodServOperDao.AgregarSAT_PRODUCTOSERVICIO_OPER(prodServOper, fbTrans) == null)
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
                            if(!prodServOperDao.BorrarSAT_PRODUCTOSERVICIO_OPER_X_PRODUCTOSERVICIOID(prodServOper, fbTrans))
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
            catch(Exception ex)
            {
                fbTrans.Rollback();
                fbConn.Close();
                MessageBox.Show("Problema al agregar registros: " + ex.Message);
            }
        }

        private void filtrarButton_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(this.dSCatalogosSat.SAT_PRODUCTOSERVICIO);
            dv.RowFilter = string.Format("SAT_DESCRIPCION LIKE '%{0}%'", filtroTextBox.Text);
            sAT_PRODUCTOSERVICIODataGridView.DataSource = dv;
        }

        private void filtroTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
