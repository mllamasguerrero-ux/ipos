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

namespace iPos.Contabilidad
{
    public partial class WFCorteRecoleccionEdit : Form
    {

        //long corterecoleccionid = 0;
        CCORTERECOLECCIONBE m_record = new CCORTERECOLECCIONBE();
        public WFCorteRecoleccionEdit()
        {
            InitializeComponent();
        }


        public WFCorteRecoleccionEdit(long corterecoleccionid) : this()
        {
            m_record = new CCORTERECOLECCIONBE();
            m_record.IID = corterecoleccionid;
        }

        private void LlenaGrid()
        {
            if (m_record == null || m_record.IID == 0)
                return;

            try
            {
                this.cORTERECOLECCIONDETALLETableAdapter.Fill(this.dSContabilidad3.CORTERECOLECCIONDETALLE, m_record.IID);
                this.cORTERECOLECCIONSUMATableAdapter.Fill(this.dSContabilidad3.CORTERECOLECCIONSUMA, m_record.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            SeleccionarCortes();
        }

        private void SeleccionarCortes()
        {

            int encargadoid = this.ENCARGADOCLAVETextBox.Text != "" ? Int32.Parse(this.ENCARGADOCLAVETextBox.DbValue.ToString()) : 0;


            if (encargadoid != 0)
            {

                WFCorteLista look = new WFCorteLista();
                look.ShowDialog();

                List<long> listId = look.m_selectedTransactions;
                AgregarListDocto(listId);

                look.Dispose();
                GC.SuppressFinalize(look);


            }
        }


        private void AgregarListDocto(List<long> listId)
        {

            int encargadoid = this.ENCARGADOCLAVETextBox.Text != "" ? Int32.Parse(this.ENCARGADOCLAVETextBox.DbValue.ToString()) : 0;

            if (encargadoid == 0)
                return;

            CCORTERECOLECCIOND corteRecoleccionD = new CCORTERECOLECCIOND();
            CCORTED corteD = new CCORTED();

            if (listId != null && listId.Count > 0)
            {

                if (m_record == null  || m_record.IID == 0)
                {


                    CCORTERECOLECCIONBE corteRecoleccionBE = new CCORTERECOLECCIONBE();
                    corteRecoleccionBE.IENCARGADOID = encargadoid;
                    corteRecoleccionBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                    corteRecoleccionBE.IFECHAHORA = DTPFechaInicio.Value;
                    corteRecoleccionBE.IOBSERVACIONES = TBNota.Text;
                    corteRecoleccionBE.IACTIVO = "S";

                    long corteRecoleccionId = 0;

                    bool res = corteRecoleccionD.CORTERECOLECCION_INSERT(corteRecoleccionBE, ref corteRecoleccionId, null);
                    if (res)
                    {
                        corteRecoleccionBE.IID = corteRecoleccionId;
                        m_record = corteRecoleccionBE;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el header de contrarecibo " + corteRecoleccionD.IComentario);
                        return;
                    }
                }

                foreach (long corteId in listId)
                {

                    CCONTRARECIBODTLBE contrareciboDtlBE = new CCONTRARECIBODTLBE();
                    CCORTEBE corteBE = new CCORTEBE();

                    corteBE.IID = corteId;
                    corteBE = corteD.seleccionarCORTE(corteBE, null);

                    if (corteBE != null && corteBE.ICORTERECOLECCIONID == 0)
                    {
                        bool res = corteRecoleccionD.CORTERECOLECCION_CORTEINSERTAR(m_record.IID,corteId,null);
                        if (!res)
                        {

                            MessageBox.Show("No se pudo agregar el detalle de contrarecibo " + corteRecoleccionD.IComentario);
                            return;
                        }

                    }

                }

                lblFolio.Text = m_record.IID.ToString();
                setEstatusBotones();
                this.ObtenerTotal();
                LlenaGrid();


            }
        }
        private void ObtenerTotal()
        {

            if (m_record != null && m_record.IID != 0)
            {
                CCORTERECOLECCIOND contrareciboD = new CCORTERECOLECCIOND();
                CCORTERECOLECCIONBE contrareciboBE = new CCORTERECOLECCIONBE();
                contrareciboBE.IID = m_record.IID;

                contrareciboBE = contrareciboD.seleccionarCORTERECOLECCION(contrareciboBE, null);
                if (contrareciboBE != null)
                {
                    m_record.IMONTO = contrareciboBE.IMONTO;
                    LBTotal.Text = m_record.IMONTO.ToString("N2");
                }
            }
        }


        private void ObtenerDatosDeBase()
        {
            if (m_record != null && m_record.IID != 0)
            {
                CCORTERECOLECCIOND contrareciboD = new CCORTERECOLECCIOND();
                CCORTERECOLECCIONBE contrareciboBE = new CCORTERECOLECCIONBE();
                contrareciboBE.IID = m_record.IID;

                contrareciboBE = contrareciboD.seleccionarCORTERECOLECCION(contrareciboBE, null);
                if (contrareciboBE != null)
                {
                    m_record = contrareciboBE;



                    string strBuffer = "";

                    if (!(bool)m_record.isnull["IENCARGADOID"])
                    {
                        this.ENCARGADOCLAVETextBox.DbValue = m_record.IENCARGADOID.ToString();
                        this.ENCARGADOCLAVETextBox.MostrarErrores = false;
                        this.ENCARGADOCLAVETextBox.MValidarEntrada(out strBuffer, 1);
                        this.ENCARGADOCLAVETextBox.MostrarErrores = true;
                        //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                    }
                    else
                    {
                        this.ENCARGADOCLAVETextBox.Text = "";
                    }


                     TBNota.Text = m_record.IOBSERVACIONES;


                    lblFolio.Text = m_record.IID.ToString();
                    LBTotal.Text = m_record.IMONTO.ToString("N2");
                    DTPFechaInicio.Value = m_record.IFECHAHORA;


                    LlenaGrid();
                }
            }
        }


        private void setEstatusBotones()
        {
            if (m_record != null && (m_record.IACTIVO == null || m_record.IACTIVO != "N"))
            {
                BtnListaTransacciones.Enabled = true;
                cORTERECOLECCIONDETALLEDataGridView.ReadOnly = false;
                //btnImprimir.Enabled = false;
                //TBNota.Enabled = true;
                
                if (m_record.IID != 0)
                {
                    BTGUARDAR.Enabled = true;
                    BTCancelar.Enabled = true;

                }
                else
                {
                    BTCancelar.Enabled = false;
                }
            }
            else 
            {

                BtnListaTransacciones.Enabled = false;
                cORTERECOLECCIONDETALLEDataGridView.ReadOnly = true;
                BTGUARDAR.Enabled = false;
                BTCancelar.Enabled = false;
            }
        }

        private void cORTERECOLECCIONDETALLEDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (cORTERECOLECCIONDETALLEDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {

                    if (m_record != null  && m_record.IID != 0)
                    {
                        if (MessageBox.Show("Realmente desea eliminar este detalle de la recoleccion de corte ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            long corteId = long.Parse(cORTERECOLECCIONDETALLEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                            CCORTERECOLECCIOND contrareciboDtlD = new CCORTERECOLECCIOND();
                           
                            if (!contrareciboDtlD.CORTERECOLECCION_CORTEELIMINAR(m_record.IID, corteId, null))
                            {

                                MessageBox.Show("No se pudo eliminar el detalle de recoleccion de corte " + contrareciboDtlD.IComentario);
                                return;
                            }

                            this.ObtenerTotal();
                            LlenaGrid();


                        }
                    }
                }
            }
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {

            if (m_record != null && ( m_record.IACTIVO == null ||  m_record.IACTIVO == "S") && m_record.IID != 0)
            {

                if (MessageBox.Show("Esta seguro que quiere eliminar la recoleccion de corte ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CCORTERECOLECCIOND contrareciboHdrD = new CCORTERECOLECCIOND();
                    

                        if (!contrareciboHdrD.CORTERECOLECCION_CANCEL(m_record.IID, null))
                        {

                            MessageBox.Show("No se pudo eliminar el header de contrarecibo " + contrareciboHdrD.IComentario);
                            return;
                        }
                        this.Close();

                }
            }
        }

        private void BTGUARDAR_Click(object sender, EventArgs e)
        {
            CCORTERECOLECCIOND corteRecoleccionD = new CCORTERECOLECCIOND();
            if (m_record != null  && m_record.IID > 0 )
            {

                if ((m_record.IACTIVO == null || m_record.IACTIVO == "S"))
                {

                    int encargadoid = this.ENCARGADOCLAVETextBox.Text != "" ? Int32.Parse(this.ENCARGADOCLAVETextBox.DbValue.ToString()) : 0;

                    if (encargadoid == 0)
                        return;

                    m_record.IOBSERVACIONES = TBNota.Text;
                    m_record.IFECHAHORA = DTPFechaInicio.Value;
                    m_record.IENCARGADOID = encargadoid;



                    if (!corteRecoleccionD.CORTERECOLECCION_UPDATE(m_record, null))
                    {

                        MessageBox.Show("No se pudo eliminar el header de contrarecibo " + corteRecoleccionD.IComentario);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("el registro se cambio");
                        return;
                    }

                }

            }
            else
            {
                int encargadoid = this.ENCARGADOCLAVETextBox.Text != "" ? Int32.Parse(this.ENCARGADOCLAVETextBox.DbValue.ToString()) : 0;

                if (encargadoid == 0)
                    return;

                m_record.IOBSERVACIONES = TBNota.Text;
                m_record.IFECHAHORA = DTPFechaInicio.Value;
                m_record.IENCARGADOID = encargadoid;
                m_record.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                long corteRecoleccionId = 0;

                if (!corteRecoleccionD.CORTERECOLECCION_INSERT(m_record,ref corteRecoleccionId, null))
                {
                    
                    MessageBox.Show("No se pudo eliminar el header de contrarecibo " + corteRecoleccionD.IComentario);
                    return;
                }

                m_record.IID = corteRecoleccionId;
                lblFolio.Text = corteRecoleccionId.ToString();
            }
        }

        private void WFCorteRecoleccionEdit_Load(object sender, EventArgs e)
        {


            if (m_record != null && m_record.IID != 0)
            {
                ObtenerDatosDeBase();
            }
            setEstatusBotones();
        }
        

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }



        private void Imprimir()
        {
            if (m_record != null && m_record.IID != 0)
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pcorterecoleccionid", m_record.IID);

                string strReporte = "TicketRecoleccionCorte.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            Imprimir();
        }
    }
}
