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

namespace iPos.Catalogos
{
    public partial class WFDescuentoLineaPersona : Form
    {
        long lineaId = 0;
        long personaId = 0;

        bool bTieneDerechoDescuentoLinea = false;


        public WFDescuentoLineaPersona()
        {
            InitializeComponent();
        }

        public WFDescuentoLineaPersona(long _personaId)
            : this()
        {
            personaId = _personaId; 
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {

        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            if (txtLinea.Text.Trim() == "")
                return;

            CDESCLINEAPERSD  lineaPersD = new CDESCLINEAPERSD();
            CDESCLINEAPERSBE lineaPersBE = new CDESCLINEAPERSBE();

            lineaPersBE.IPERSONAID = obtenerPersonaIdSeleccionada();
            lineaPersBE.ILINEAID = obtenerLineaIdSeleccionada();
            if (lineaPersBE.IPERSONAID == 0)
            {

                MessageBox.Show("Seleccione un cliente valido!");
                return;
            }
            if (lineaPersBE.ILINEAID == 0)
            {

                MessageBox.Show("Seleccione una linea valida!");
                return;
            }

            if (this.txtDescuento.NumericValue != null && decimal.Parse(this.txtDescuento.NumericValue.ToString()) > 0 && 
                decimal.Parse(this.txtDescuento.NumericValue.ToString()) <= 100)
            {
                lineaPersBE.IDESCUENTO = decimal.Parse(this.txtDescuento.NumericValue.ToString());
            }
            else
            {
                MessageBox.Show("Seleccione una monto de descuento valido!");
                return;
            }
            
            Boolean bExisteCambioPrecios = false;
            CDESCLINEAPERSBE lineaPersExistente = new CDESCLINEAPERSBE();
            lineaPersExistente.IPERSONAID = lineaPersBE.IPERSONAID;
            lineaPersExistente.ILINEAID = lineaPersBE.ILINEAID;
            lineaPersExistente = lineaPersD.seleccionarDESCLINEAPERSXPersonaYLinea(lineaPersExistente, null);

            bExisteCambioPrecios = lineaPersExistente != null;

            lineaPersBE.IACTIVO = "S";
            if (bExisteCambioPrecios)
            {
                lineaPersBE.IID = lineaPersExistente.IID;
                if (!lineaPersD.CambiarDESCLINEAPERSD(lineaPersBE, lineaPersBE, null))
                {
                    MessageBox.Show("No se puedo cambiar : " + lineaPersD.IComentario);

                }
                else
                {
                    LimpiarActual();
                    //TBCodigo.Focus();
                    LlenarDatos();
                }
            }
            else
            {

                if (lineaPersD.AgregarDESCLINEAPERSD(lineaPersBE, null) == null)
                {

                    MessageBox.Show("No se puedo cambiar : " + lineaPersD.IComentario);
                }
                else
                {
                    LimpiarActual();
                    //TBCodigo.Focus();
                    LlenarDatos();
                }

            }

        }

        private long obtenerPersonaIdSeleccionada()
        {
            try
            {
                return Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
            }
            catch
            {
                return 0;
            }

        }

        private long obtenerLineaIdSeleccionada()
        {
            try
            {
                return Int64.Parse(this.txtLinea.DbValue.ToString());
            }
            catch
            {
                return 0;
            }

        }

        private void LlenarDatos()
        {
            try
            {
                this.dESCUENTOLINEAPERSTableAdapter.Fill(this.dSCatalogos.DESCUENTOLINEAPERS, (int)personaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void LimpiarActual()
        {
            lineaId = 0;
            txtLinea.Text = "";

            this.txtDescuento.Text = "";
        }


        private void WFDescuentoLineaPersona_Load(object sender, EventArgs e)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            bTieneDerechoDescuentoLinea = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DESCLINEAPERS, null);
        }

        private void SeleccionaCliente()
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                personaId = (long)dr["ID"];
                LlenarDatos();

            }
        }

        private void dESCUENTOLINEAPERSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 /*&& m_bPermisoAEditarCambioPrecio*/)
            {

                if (dESCUENTOLINEAPERSDataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    String lineaProducto = dESCUENTOLINEAPERSDataGridView.Rows[e.RowIndex].Cells["LINEACLAVE"].Value.ToString();
                    LimpiarActual();
                    txtLinea.DbValue = dESCUENTOLINEAPERSDataGridView.Rows[e.RowIndex].Cells["GLINEAID"].Value.ToString();
                    txtLinea.Text = lineaProducto;
                    label3.Text = dESCUENTOLINEAPERSDataGridView.Rows[e.RowIndex].Cells["GLINEANOMBRE"].Value.ToString();
                    fillDataFromCodigo();
                    this.txtDescuento.Focus();

                }
                else if (dESCUENTOLINEAPERSDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    long lDescTempId = long.Parse(dESCUENTOLINEAPERSDataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("Esta seguro de eliminar este registro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    CDESCLINEAPERSD lineaPersD = new CDESCLINEAPERSD();
                    CDESCLINEAPERSBE lineaPersBE = new CDESCLINEAPERSBE();
                    lineaPersBE.IID = lDescTempId;
                    if (!lineaPersD.BorrarDESCLINEAPERSD(lineaPersBE, null))
                    {
                        MessageBox.Show("Hubo problemas para borrar el registro " + lineaPersD.IComentario);
                    }
                    this.LlenarDatos();
                }
            }
        }

        private void fillDataFromCodigo()
        {
            CDESCLINEAPERSD lineaPersD = new CDESCLINEAPERSD();
            CDESCLINEAPERSBE lineaPersBE = new CDESCLINEAPERSBE();

            lineaPersBE.ILINEAID = obtenerLineaIdSeleccionada();
            lineaPersBE.IPERSONAID = obtenerPersonaIdSeleccionada();
            lineaPersBE = lineaPersD.seleccionarDESCLINEAPERSXPersonaYLinea(lineaPersBE, null);

            lineaId = lineaPersBE.ILINEAID;

            if (lineaPersBE != null)
            {
                this.txtDescuento.Text = lineaPersBE.IDESCUENTO.ToString();
                //lineaPersBE.IDESCUENTO = decimal.Parse(this.txtDescuento.NumericValue.ToString());
            }

        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
        }

        private void WFDescuentoLineaPersona_Shown(object sender, EventArgs e)
        {
            ITEMIDTextBox.Focus();

            if (personaId != 0)
            {

                CPERSONAD personaD = new CPERSONAD();
                CPERSONABE personaBE = new CPERSONABE();
                personaBE.IID = personaId;

                personaBE = personaD.seleccionarPERSONA(personaBE, null);

                if (personaBE != null)
                {
                    ITEMIDTextBox.Text = personaBE.ICLAVE;
                    LlenarDatos();
                }
            }
        }
    }
}
