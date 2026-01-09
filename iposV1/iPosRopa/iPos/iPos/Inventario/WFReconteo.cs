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
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using System.Threading;
using iPos.Inventario;

namespace iPos
{
    public partial class WFReconteo : IposForm
    {
        CDOCTOBE m_Docto;
        string m_sCadenaConexion;
        string m_Comentario = "";
        bool m_ProcessSuccess = false;

        int m_posicionActual = 0;
        long m_productoIdABuscar = 0;

        bool m_bImprimirSoloDiferenciasTicket = false;



        string[] m_columnTitlesExcel = new string[] {   "",
                                                        "PRODUCTO",	
                                                        "DESCRIPCION",	
                                                        "LOTE",
                                                        "FECHA VENCIMIENTO",	
                                                        "CANT. TEORICA",	
                                                        "CANT. FISICA",	
                                                        "CANT. DIFERENCIA",	
                                                        "",	
                                                        ""};


        string[] m_columnTitlesExcelXLoc = new string[] {   
                                                        "ANAQUEL",
                                                        "LOCALIDAD",
                                                        "",	
                                                        "PRODUCTO",	
                                                        "DESCRIPCION",	
                                                        "LOTE",
                                                        "FECHA VENCIMIENTO",	
                                                        "",	
                                                        "",	
                                                        "",	
                                                        "",	
                                                        "",	
                                                        "CAJAS",	
                                                        "PIEZAS"      };



        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        bool m_bEsInventarioCiclico = false;


        public WFReconteo()
        {
            InitializeComponent();
            m_Docto = new CDOCTOBE();
            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_INVENTARIO_FISICO;
            m_sCadenaConexion = ConexionBD.ConexionString();
        }


        public WFReconteo(long doctoId) :
            this()
        {
            m_Docto.IID = doctoId;
            ObtenerDoctoDeBD(doctoId);
            LlenarGrid(doctoId);
        }

        private void ObtenerDoctoDeBD(long lDoctoID)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, null);

            this.LBConsecutivo.Text = m_Docto.IID.ToString();
            this.LBFolio.Text = m_Docto.IFOLIO.ToString();
            this.LBDateValue.Text = m_Docto.IFECHA.ToShortDateString();
            

        }


        private void LlenarGrid(long lDoctoID)
        {
            try
            {

                BindingSource bufferBinding = null;

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO)
                {

                    if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    {
                        this.gET_INVFIS_LISTADETALLES_PKITTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PKIT, (int)lDoctoID, 0);//,((this.CBMostrarSoloDif.Checked) ? "1" : "0")
                        bufferBinding = gET_INVFIS_LISTADETALLES_PKITBindingSource;
                    }
                    else
                    {
                        this.gET_INVFIS_LISTADETALLESTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_P, (int)lDoctoID, 0);
                        bufferBinding = gET_INVFIS_LISTADETALLESBindingSource;
                    }
                }
                else
                {
                    if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    {
                        this.gET_INVFIS_LISTADETALLES_PXLOC_KITTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PXLOC_KIT, (int)lDoctoID, 0);
                        bufferBinding = gET_INVFIS_LISTADETALLES_PXLOC_KITBindingSource;
                    }
                    else
                    {
                    this.gET_INVFIS_LISTADETALLES_PXLOCTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PXLOC, (int)lDoctoID, 0);//,((this.CBMostrarSoloDif.Checked) ? "1" : "0")
                    bufferBinding = gET_INVFIS_LISTADETALLES_PXLOCBindingSource;
                }
            }
                /**winforms only starts**/

                if ((this.CBMostrarSoloDif.Checked))
                    bufferBinding.Filter = " CANTIDADDIFERENCIA <> 0";
                else
                    bufferBinding.Filter = "";
                /**winforms only ends**/

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void gET_INVFIS_LISTADETALLESDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }
        
        
        

        private void CBMostrarSoloDif_CheckedChanged(object sender, EventArgs e)
        {
            this.LlenarGrid(m_Docto.IID);
        }
        
        
        

        private void ActualizaTablasDeControl()
        {
            WFActualizandoKITMultiNivel wf = new WFActualizandoKITMultiNivel();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void WFReconteo_Load(object sender, EventArgs e)
        {
            ActualizaTablasDeControl();

            //gET_INVFIS_LISTADETALLES_PXLOCTableAdapter
            formatGridColumnProductoCaracteristicas();

            this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].Visible = true;

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
            {

                
                if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    this.gET_INVFIS_LISTADETALLESDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PXLOC_KITBindingSource;
                else
                    this.gET_INVFIS_LISTADETALLESDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PXLOCBindingSource;


                //this.gET_INVFIS_LISTADETALLESDataGridView.ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].DefaultCellStyle.BackColor = Color.White;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].ReadOnly = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].DefaultCellStyle.BackColor = Color.PaleGreen;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Visible = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].ReadOnly = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].Visible = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            else
            {

                if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    this.gET_INVFIS_LISTADETALLESDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PKITBindingSource;
                
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].DefaultCellStyle.BackColor = Color.PaleGreen;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].ReadOnly = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].Visible = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].DefaultCellStyle.BackColor = Color.White;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Visible = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].DefaultCellStyle.BackColor = Color.White;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].Visible = false;
            }

            if(bEstaConfiguradoParaPiezasyCajas())
            {
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["PRODUCTOLOTE"].Visible = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["FECHAVENCE"].Visible = false;
            }


            this.m_bEsInventarioCiclico = m_Docto.IACTIVO == "N";
            //this.gET_INVFIS_LISTADETALLESTableAdapter.Adapter.SelectCommand.CommandText = gET_INVFIS_LISTADETALLES_PXLOCTableAdapter.Adapter.SelectCommand.CommandText;
        }




        private bool bEstaConfiguradoParaPiezasyCajas()
        {
            return (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"));
        }



        public void formatGridColumnProductoCaracteristicas()
        {
            if (CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD != null && CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD.Equals("S"))
            {
                try
                {
                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                    {

                        this.DGTEXTO1.Visible = true;
                        this.DGTEXTO1.HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                    }
                    else
                    {

                        this.DGTEXTO1.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                    {

                        this.DGTEXTO2.Visible = true;
                        this.DGTEXTO2.HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                    }
                    else
                    {

                        this.DGTEXTO2.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                    {

                        this.DGTEXTO3.Visible = true;
                        this.DGTEXTO3.HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                    }
                    else
                    {

                        this.DGTEXTO3.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                    {

                        this.DGTEXTO4.Visible = true;
                        this.DGTEXTO4.HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                    }
                    else
                    {

                        this.DGTEXTO4.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                    {

                        this.DGTEXTO5.Visible = true;
                        this.DGTEXTO5.HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                    }
                    else
                    {

                        this.DGTEXTO5.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                    {

                        this.DGTEXTO6.Visible = true;
                        this.DGTEXTO6.HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                    }
                    else
                    {

                        this.DGTEXTO6.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                    {

                        this.DGNUMERO1.Visible = true;
                        this.DGNUMERO1.HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                    }
                    else
                    {

                        this.DGNUMERO1.Visible = false;
                    }




                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                    {

                        this.DGNUMERO2.Visible = true;
                        this.DGNUMERO2.HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                    }
                    else
                    {

                        this.DGNUMERO2.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                    {

                        this.DGNUMERO3.Visible = true;
                        this.DGNUMERO3.HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                    }
                    else
                    {

                        this.DGNUMERO3.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                    {

                        this.DGNUMERO4.Visible = true;
                        this.DGNUMERO4.HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                    }
                    else
                    {

                        this.DGNUMERO4.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                    {

                        this.DGFECHA1.Visible = true;
                        this.DGFECHA1.HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                    }
                    else
                    {

                        this.DGFECHA1.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                    {

                        this.DGFECHA2.Visible = true;
                        this.DGFECHA2.HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                    }
                    else
                    {

                        this.DGFECHA2.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                PRODUCTOLOTE.Visible = false;
                FECHAVENCE.Visible = false;
            }
            else
            {

                DGTEXTO1.Visible = false;
                DGTEXTO2.Visible = false;
                DGTEXTO3.Visible = false;
                DGTEXTO4.Visible = false;
                DGTEXTO5.Visible = false;
                DGTEXTO6.Visible = false;
                DGNUMERO1.Visible = false;
                DGNUMERO2.Visible = false;
                DGNUMERO3.Visible = false;
                DGNUMERO4.Visible = false;
                DGFECHA1.Visible = false;
                DGFECHA2.Visible = false;
                PRODUCTOLOTE.Visible = true;
                FECHAVENCE.Visible = true;
            }
        }


        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                ITEMIDTextBox.Text = dr["CLAVE"].ToString().Trim();
                ITEMIDTextBox.Focus();
                ITEMIDTextBox.Select(ITEMIDTextBox.Text.Length, 0);
            }
        }


        private void ITEMButton_Click(object sender, EventArgs e)
        {

            SeleccionarProducto("");
        }

        private void ITEMIDTextBox_Validated(object sender, EventArgs e)
        {
            m_posicionActual = -1;
        }

        private void buscarProductoEnGrid()
        {
            gET_INVFIS_LISTADETALLESDataGridView.ClearSelection();

            int primeraPosicionEncontradaDesdeInicio = -1;
            

            foreach (DataGridViewRow dr in gET_INVFIS_LISTADETALLESDataGridView.Rows)
            {

                long productoId = long.Parse(dr.Cells["PRODUCTOID"].Value.ToString());

                if (productoId == m_productoIdABuscar)
                {


                    if (dr.Index <= m_posicionActual)
                    {
                        if (primeraPosicionEncontradaDesdeInicio == -1)
                        {
                            primeraPosicionEncontradaDesdeInicio = dr.Index;
                        }
                        continue;
                    }

                    gET_INVFIS_LISTADETALLESDataGridView.FirstDisplayedScrollingRowIndex = dr.Index;
                    dr.Selected = true;
                    m_posicionActual = dr.Index;
                    return;

                }

            }


            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prodBE = new CPRODUCTOBE();
            prodBE.IID = m_productoIdABuscar;

            prodBE = prodD.seleccionarPRODUCTO(prodBE, null);


            if (primeraPosicionEncontradaDesdeInicio > -1)
            {

                gET_INVFIS_LISTADETALLESDataGridView.FirstDisplayedScrollingRowIndex = primeraPosicionEncontradaDesdeInicio;
                gET_INVFIS_LISTADETALLESDataGridView.Rows[primeraPosicionEncontradaDesdeInicio].Selected = true;
                m_posicionActual = primeraPosicionEncontradaDesdeInicio;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarProductoEnGrid();
        }

        private void ITEMIDTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ValidateBusqueda();
            }
        }


        private void ValidateBusqueda()
        {

            m_productoIdABuscar = 0;

            if (ITEMIDTextBox.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                ITEMLabel.Text = "";
                SeleccionarProducto(ITEMIDTextBox.Text.Trim());
                return;
            }
            ITEMLabel.Text = prod.IDESCRIPCION1;

            m_productoIdABuscar = prod.IID;
            m_posicionActual = -1;
            buscarProductoEnGrid();
        }

        private void ITEMIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateBusqueda();
        }


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(ITEMIDTextBox.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        


        public void imprimirReciboLargo(long doctoId,  string titulo)
        {
            string strReporte = "InformeInventarioReconteo.frx";

            int bufferGroup = 0;

            foreach (DataGridViewRow dr in gET_INVFIS_LISTADETALLESDataGridView.Rows)
            {

                if (dr.Cells["DGRecontar"].Value != null && bool.Parse(dr.Cells["DGRecontar"].Value.ToString()))
                {
                    var productoId = long.Parse(dr.Cells["PRODUCTOID"].Value.ToString());
                    this.dSLocationProducts.BUFFERTEXT_ADD.Clear();
                    bUFFERTEXT_ADDTableAdapter.Fill(this.dSLocationProducts.BUFFERTEXT_ADD, bufferGroup, productoId);
                    if (this.dSLocationProducts.BUFFERTEXT_ADD.Rows.Count > 0)
                        bufferGroup = int.Parse(this.dSLocationProducts.BUFFERTEXT_ADD.Rows[0]["BUFFERGROUP_OUT"].ToString());



                }
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("DOCTOID", doctoId);
            dictionary.Add("BUFFERGROUP", bufferGroup);
            dictionary.Add("TITULO", titulo);
            


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);

            this.bUFFERTEXT_DELGROUPTableAdapter.Fill(this.dSLocationProducts.BUFFERTEXT_DELGROUP, bufferGroup);
        }

        private void btnImprimirDif_Click(object sender, EventArgs e)
        {
            imprimirReciboLargo(m_Docto.IID,  "Reporte para reconteo de inventario");
        }


        

        private void btnReconteo_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bUFFERTEXT_ADDTableAdapter.Fill(this.dSLocationProducts.BUFFERTEXT_ADD, new System.Nullable<int>(((int)(System.Convert.ChangeType(bUFFERGROUPToolStripTextBox.Text, typeof(int))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(bUFFERVALUEIDToolStripTextBox.Text, typeof(long))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.bUFFERTEXT_DELGROUPTableAdapter.Fill(this.dSLocationProducts.BUFFERTEXT_DELGROUP, new System.Nullable<int>(((int)(System.Convert.ChangeType(bUFFERGROUPToolStripTextBox1.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
