using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;

namespace iPos
{
    public partial class WFMovimientosAnticipo : IposForm
    {
        long m_clienteID = 0;
        string m_conSaldo = "N";
        public WFMovimientosAnticipo()
        {
            InitializeComponent();
        }

        public WFMovimientosAnticipo(long clienteID, string conSaldo):this()
        {
            m_clienteID = clienteID;
            m_conSaldo = conSaldo;
        }

        private void LlenarMovimientos()
        {
            int personaId = 0;
            try
            {
                personaId = Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                if(personaId == 0)
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente valido");
                return;
            }

            /*if (CBTipo.SelectedIndex < 0)
            {

                MessageBox.Show("Seleccione un tipo de transaccion valido");
                return;
            }*/

            try
            {


                this.mOVIMIENTOSANTICIPOTableAdapter.Fill(this.dSFastReports.MOVIMIENTOSANTICIPO, GetTipoDocto(),DTPFrom.Value,DTPTo.Value,
                    (Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString())),
                    ((CBConSaldo.Checked) ? "S":"N"));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private int GetTipoDocto()
        {
            /*switch (CBTipo.SelectedIndex)
            {
                case 0: return -21;
                case 1: return -22;
                default: return -21;
            }*/
            return (int)DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES;
        }

        private void BTMostrar_Click(object sender, EventArgs e)
        {
            LlenarMovimientos();
        }

        /*private void LlenaDetalles(long lDoctoId)
        {
            try
            {
                this.mOVIMIENTOSDETALLETableAdapter.Fill(this.dSFastReports.MOVIMIENTOSDETALLE, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

        private void mOVIMIENTOSDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                long lDoctoId = long.Parse(mOVIMIENTOSDataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value.ToString());
                //LlenaDetalles(lDoctoId);
                LlenaAbonos(lDoctoId);
                LlenaAplicaciones(lDoctoId);
            }
            catch
            {
            }
        }

        private void LlenaAbonos(long lDoctoId)
        {
            try
            {
                this.gET_LISTA_ABONOS_DOCTOTableAdapter.Fill(this.dSFastReports.GET_LISTA_ABONOS_DOCTO, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFMovimientosAnticipo_Load(object sender, EventArgs e)
        {
            //this.CBTipo.SelectedIndex = 0;
            this.DTPFrom.Value = DateTime.Parse("01/01/2012");
            this.DTPTo.Value = DateTime.Parse("31/12/" + DateTime.Today.ToString("yyyy"));


            if (m_clienteID != 0)
            {
                string strBuffer = "";
                this.PERSONAIDTextBox.DbValue = m_clienteID.ToString();
                this.PERSONAIDTextBox.MostrarErrores = false;
                this.PERSONAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PERSONAIDTextBox.MostrarErrores = true;
            }

            CBConSaldo.Checked = m_conSaldo.Equals("S");


            if (m_clienteID != 0)
            {
                LlenarMovimientos();
            }

        }


        private void LlenaAplicaciones(long lDoctoId)
        {
            try
            {
                this.gET_LISTA_APLICACION_ANTICIPOTableAdapter.Fill(this.dSFastReports.GET_LISTA_APLICACION_ANTICIPO, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        

    }
}
