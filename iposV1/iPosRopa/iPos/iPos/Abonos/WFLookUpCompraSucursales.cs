using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Abonos
{
    public partial class WFLookUpCompraSucursales : Form
    {


        long m_statusDoctoId, m_cajaId, m_tipoDoctoId, m_personaId, m_sucursalDestId;
        bool m_bEsFacturaElectronica = false;
        bool m_deshabilitarPreseleccionados = false;


        public DataRow m_rtnDataRow;


        public WFLookUpCompraSucursales()
        {
            InitializeComponent();
        }


        public WFLookUpCompraSucursales(long statusDoctoId, long cajaId, long tipoDoctoId, long personaId, bool bEsFacturaElectronica)
            : this(statusDoctoId,  cajaId, tipoDoctoId, personaId)
        {
            m_bEsFacturaElectronica = bEsFacturaElectronica;
        }

        private void BTBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        public WFLookUpCompraSucursales(long statusDoctoId, long cajaId, long tipoDoctoId, long personaId, bool bEsFacturaElectronica, long sucursalDestId , bool deshabilitarPreseleccionados)
            : this(statusDoctoId, cajaId, tipoDoctoId, personaId,bEsFacturaElectronica)
        {
            m_sucursalDestId = sucursalDestId;
            m_deshabilitarPreseleccionados = deshabilitarPreseleccionados;
        }

        public WFLookUpCompraSucursales(long statusDoctoId, long cajaId, long tipoDoctoId, long personaId):this()
        {
            m_statusDoctoId = statusDoctoId;
            m_cajaId = cajaId;
            m_tipoDoctoId = tipoDoctoId;
            m_personaId = personaId;
        }



        private void Filtrar()
        {
            try
            {
                DateTime dtBuffer = DateTime.MinValue;
                if (CBFecha.Checked)
                    dtBuffer = dateTimePicker1.Value;


                long sucursalDestinoId = 0;
                if (this.CBSucursal.Checked && this.SUCURSALIDTextBox.Text != "")
                {
                    sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
                }


                long proveedorId = 0;
                if(this.CBProveedor.Checked && this.ITEMIDTextBox.Text != "")
                {
                    proveedorId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }


                this.transaccionesListaExtTableAdapter.Fill(this.dSReimpresionTicket2.TransaccionesListaExt, m_statusDoctoId, m_tipoDoctoId, dtBuffer, ((m_bEsFacturaElectronica) ? "S" : "N"), 0, sucursalDestinoId, proveedorId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void WFLookUpCompraSucursales_Load(object sender, EventArgs e)
        {
            if(m_personaId > 0)
            {
                CBProveedor.Checked = true;

                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = m_personaId.ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                if(m_deshabilitarPreseleccionados)
                {
                    CBProveedor.Enabled = false;
                    this.ITEMIDTextBox.Enabled = false;
                    this.ITEMButton.Enabled = false;
                }
            }


            if (m_sucursalDestId > 0)
            {
                CBSucursal.Checked = true;

                string strBuffer = "";
                this.SUCURSALIDTextBox.DbValue = m_sucursalDestId.ToString();
                this.SUCURSALIDTextBox.MostrarErrores = false;
                this.SUCURSALIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.SUCURSALIDTextBox.MostrarErrores = true;

                if (m_deshabilitarPreseleccionados)
                {
                    CBSucursal.Enabled = false;
                    this.SUCURSALIDTextBox.Enabled = false;
                    this.SUCURSALIDButton.Enabled = false;
                }
            }

            Filtrar();
        }

        private void transaccionesListaDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && transaccionesListaDataGridView.CurrentRow.Index < (transaccionesListaDataGridView.RowCount - 1)) 
                                        ? transaccionesListaDataGridView.CurrentRow.Index - 1 :*/ transaccionesListaDataGridView.CurrentRow.Index;
                DataGridViewRow dr = this.transaccionesListaDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }


        private void transaccionesListaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }

        private void transaccionesListaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);
        }

    }
}
