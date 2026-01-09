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

using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFAutorizacioRebaja : iPos.Tools.ScreenConfigurableForm
    {
        public WFAutorizacioRebaja()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                long clienteId = 0;
                long marcaId = 0;
                long productoId = 0;

                if(!CBTodosClientes.Checked)
                {
                    try
                    {
                        clienteId = Int64.Parse(this.CLIENTETextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }





                if (!CBTodosProductos.Checked)
                {
                    try
                    {
                        productoId = Int64.Parse(this.PRODUCTOTextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }


                this.rEBAJAS_PROMOVIDASTableAdapter.Fill(this.dSRebajas.REBAJAS_PROMOVIDAS, this.DTPFrom.Value, clienteId, productoId, marcaId);
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            coloreaGrid();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
                LlenarGrid();
        }

        private void WFAutorizacioRebaja_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            this.DTPFrom.Value = DateTime.Today.AddDays(-7);

            // TODO: This line of code loads data into the 'dSRebajas.COMISION_COLOR_V2' table. You can move, or remove it, as needed.
            this.cOMISION_COLOR_V2TableAdapter.Fill(this.dSRebajas.COMISION_COLOR_V2);

            LlenarGrid();
        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == rEBAJAS_PROMOVIDASDataGridView.NewRowIndex)
                return;

            if (rEBAJAS_PROMOVIDASDataGridView.Columns["DGAPROBAR"].Index != e.ColumnIndex &&
                rEBAJAS_PROMOVIDASDataGridView.Columns["DGRECHAZADA"].Index != e.ColumnIndex)
                return;

            if(rEBAJAS_PROMOVIDASDataGridView.Columns["DGAPROBAR"].Index == e.ColumnIndex )
            {
                bool bNewValue = bool.Parse(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGAPROBAR"].Value.ToString());
                if(bNewValue)
                {
                    rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGRECHAZADA"].Value = false;
                }

            }

            if (rEBAJAS_PROMOVIDASDataGridView.Columns["DGRECHAZADA"].Index == e.ColumnIndex)
            {
                bool bNewValue = bool.Parse(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGRECHAZADA"].Value.ToString());
                if (bNewValue)
                {
                    rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGAPROBAR"].Value = false;
                }

            }
               

        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex != -1 || e.RowIndex == rEBAJAS_PROMOVIDASDataGridView.NewRowIndex)
                return;

            if (rEBAJAS_PROMOVIDASDataGridView.Columns["DGAPROBAR"].Index != e.ColumnIndex &&
                rEBAJAS_PROMOVIDASDataGridView.Columns["DGRECHAZADA"].Index != e.ColumnIndex)
                return;


            rEBAJAS_PROMOVIDASDataGridView.EndEdit();

        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
             
            foreach(DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {
                dr.Cells["DGAPROBAR"].Value = true;
                dr.Cells["DGRECHAZADA"].Value = false;
            }

        }


        private void btnRechazar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {
                dr.Cells["DGAPROBAR"].Value = false;
                dr.Cells["DGRECHAZADA"].Value = true;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<long, List<DataGridViewRow>> mappedData = new Dictionary<long, List<DataGridViewRow>>();
            CDOCTOD doctoD = new CDOCTOD();

            foreach (DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {


                bool aprobada = dr.Cells["DGAPROBAR"].Value != null && bool.Parse(dr.Cells["DGAPROBAR"].Value.ToString());
                bool rechazada = dr.Cells["DGRECHAZADA"].Value != null && bool.Parse(dr.Cells["DGRECHAZADA"].Value.ToString());
                long key = Int64.Parse(dr.Cells["DGDOCTOID"].Value.ToString());
                long movtoId = Int64.Parse(dr.Cells["DGMOVTOID"].Value.ToString());

                if (!aprobada && !rechazada)
                    continue;


                if (aprobada)
                {
                    List<DataGridViewRow> bufferList = null;
                    Boolean existeYaKey = false;
                    if (mappedData.ContainsKey(key))
                    {
                        bufferList = mappedData[key];
                        existeYaKey = true;
                    }
                    else
                    {
                        bufferList = new List<DataGridViewRow>();
                        existeYaKey = false;
                    }

                    bufferList.Add(dr);

                    if(existeYaKey)
                    {
                        mappedData[key] = bufferList;
                    }
                    else
                     {
                         mappedData.Add(key,bufferList);
                     }
                       
                    
                }
                else
                {

                    decimal cantidad = decimal.Parse(dr.Cells["DGCANTIDAD"].Value.ToString());
                    if(!doctoD.QUITARPENDIENTEREBAJA(movtoId,key, cantidad, null))
                    {

                        MessageBox.Show("Ocurrio un error al rechazar la rebaja " + doctoD.IComentario);
                        return;
                    }
                }

            }


            foreach(long lDoctoId in mappedData.Keys)
            {

                CDOCTOBE doctoBE = new CDOCTOBE();
                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if (!doctoD.REBAJA_PREPARANC(ref doctoBE, lDoctoId, CurrentUserID.CurrentUser.IID, fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error al crear la NC " + doctoD.IComentario );
                        return;
                    }

                    List<DataGridViewRow> listDetails = mappedData[lDoctoId];
                    foreach(DataGridViewRow dr in listDetails)
                    {
                        
                        long movtoId = Int64.Parse(dr.Cells["DGMOVTOID"].Value.ToString());
                        decimal cantidad = decimal.Parse(dr.Cells["DGCANTIDAD"].Value.ToString());

                       if(!doctoD.REBAJA_AUTORIZADETALLE(movtoId, doctoBE.IID, cantidad, fTrans))
                       {

                           fTrans.Rollback();
                           fConn.Close();
                           MessageBox.Show("Ocurrio un error al crear la NC " + doctoD.IComentario);
                           return;
                       }
                    }

                    if (!doctoD.REBAJA_CERRARNC(doctoBE,CurrentUserID.CurrentUser.ICORTEID, fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error al cerrar la NC " + doctoD.IComentario);
                        return;
                    }

                    fTrans.Commit();
                    fConn.Close();

                }
                catch
                {
                    fTrans.Rollback();
                    fConn.Close();
                }
                finally
                {
                fConn.Close();
                }



            }

            MessageBox.Show("Se completaron las operaciones");
            this.Close();

        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // if (CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2)
            //    return;

            //coloreaRow(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex]);
        }


        private void coloreaGrid()
        {

            if (CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2)
                return;

            foreach (DataGridViewRow row in this.rEBAJAS_PROMOVIDASDataGridView.Rows)
            {

                coloreaRow(row);
            }
        }
        private void coloreaRow(DataGridViewRow row)
        {
            if (CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2)
                return;

            decimal nUtil =  (decimal)row.Cells["DGNUTIL"].Value ;
            string proveedorClave = row.Cells["DGPROVEEDORCLAVE"].Value.ToString();
            string colorBack = "BLANCO";

            try
            {


                colorBack = "BLANCO";
                var modifiedRows = this.dSRebajas.COMISION_COLOR_V2.Select("PROVEEDORCLAVE = '" + proveedorClave + "' AND MARGENMIN <= " + nUtil.ToString("####.##") + " AND (MARGENMAX >= " + nUtil.ToString("####.##") + "  or MARGENMAX < 0)");
                if (modifiedRows != null && modifiedRows.Length > 0)
                {
                    Rebajas.DSRebajas.COMISION_COLOR_V2Row dr = (Rebajas.DSRebajas.COMISION_COLOR_V2Row)modifiedRows[0];
                    colorBack = dr.COLOR;
                }
                else
                {
                    string strSelect = " PROVEEDORCLAVE = '' AND MARGENMIN <= " + nUtil.ToString("####.##") + " AND (MARGENMAX >= " + nUtil.ToString("####.##") + "  or  MARGENMAX < 0)";
                    modifiedRows = this.dSRebajas.COMISION_COLOR_V2.Select(strSelect);
                    if (modifiedRows != null && modifiedRows.Length > 0)
                    {
                        Rebajas.DSRebajas.COMISION_COLOR_V2Row dr = (Rebajas.DSRebajas.COMISION_COLOR_V2Row)modifiedRows[0];
                        colorBack = dr.COLOR;
                    }
                }



                if (colorBack.Equals("ROJO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("AMARILLO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (colorBack.Equals("VERDE"))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("MAGENTA"))
                {
                    row.DefaultCellStyle.BackColor = Color.Magenta;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("GRIS"))
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }


    }
}
