using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using System.IO;

using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFPreciosTemp : IposForm
    {
        long productoId = 0;

        bool m_bPermisoAEditarCambioPrecio = false;

        public WFPreciosTemp()
        {
            InitializeComponent();
        }



        private void fillDataFromCodigo()
        {

            if (TBCodigo.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                this.LBProductoDescripcion.Text = "";
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION;
            this.PRECIO1Lbl.Text = prod.IPRECIO1.ToString();

            productoId = prod.IID;

            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");

            this.PRECIO1Lbl.Text = Math.Round((prod.IPRECIO1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO2Lbl.Text = Math.Round((prod.IPRECIO2 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO3Lbl.Text = Math.Round((prod.IPRECIO3 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO4Lbl.Text = Math.Round((prod.IPRECIO4 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO5Lbl.Text = Math.Round((prod.IPRECIO5 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIOSUGERIDOLbl.Text = prod.IPRECIOSUGERIDO.ToString();



            CPRECIOSTEMPBE preciosTempBE = new CPRECIOSTEMPBE();
            CPRECIOSTEMPD preciosTempD = new CPRECIOSTEMPD();
            preciosTempBE.IPRODUCTOID = productoId;
            preciosTempBE = preciosTempD.seleccionarPRECIOSTEMPXPROD(preciosTempBE, null);

            if(preciosTempBE != null)
            {

                this.PRECIO1TextBox.Text = preciosTempBE.IPRECIO1.ToString();
                this.PRECIO2TextBox.Text = preciosTempBE.IPRECIO2.ToString();
                this.PRECIO3TextBox.Text = preciosTempBE.IPRECIO3.ToString();
                this.PRECIO4TextBox.Text = preciosTempBE.IPRECIO4.ToString();
                this.PRECIO5TextBox.Text = preciosTempBE.IPRECIO5.ToString();
                this.PRECIOSUGERIDOTextBox.Text = preciosTempBE.ISUGERIDO.ToString();
            }
            else
            {

                this.PRECIO1TextBox.Text = Math.Round((prod.IPRECIO1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO2TextBox.Text = Math.Round((prod.IPRECIO2 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO3TextBox.Text = Math.Round((prod.IPRECIO3 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO4TextBox.Text = Math.Round((prod.IPRECIO4 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO5TextBox.Text = Math.Round((prod.IPRECIO5 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIOSUGERIDOTextBox.Text = prod.IPRECIOSUGERIDO.ToString();
            }

        }



        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            fillDataFromCodigo();
            this.PRECIO1TextBox.Focus();

        }


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(TBCodigo.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
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
                this.TBCodigo.Text = dr["CLAVE"].ToString().Trim();
                TBCodigo.Focus();
                TBCodigo.Select(TBCodigo.Text.Length, 0);
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (TBCodigo.Text.Trim() == "")
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                    return;
                }

                this.PRECIO1TextBox.Focus();
                PRECIO1TextBox.Select(0, PRECIO1TextBox.Text.Length);
            }
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            Boolean bExisteCambioPrecios = false;
            CPRECIOSTEMPBE preciosTempBE = new CPRECIOSTEMPBE();
            CPRECIOSTEMPD preciosTempD = new CPRECIOSTEMPD();
            preciosTempBE.IPRODUCTOID = productoId;

            preciosTempBE = preciosTempD.seleccionarPRECIOSTEMPXPROD(preciosTempBE, null);

            bExisteCambioPrecios = preciosTempBE != null;

            if (preciosTempBE == null)
            {
                preciosTempBE = new CPRECIOSTEMPBE();
                preciosTempBE.IPRODUCTOID = productoId;
            }

            if (this.PRECIO1TextBox.Text != "")
            {
                preciosTempBE.IPRECIO1 = decimal.Parse(this.PRECIO1TextBox.Text.ToString());
            }
            if (this.PRECIO2TextBox.Text != "")
            {
                preciosTempBE.IPRECIO2 = decimal.Parse(this.PRECIO2TextBox.Text);
            }
            if (this.PRECIO3TextBox.Text != "")
            {
                preciosTempBE.IPRECIO3 = decimal.Parse(this.PRECIO3TextBox.Text);
            }
            if (this.PRECIO4TextBox.Text != "")
            {
                preciosTempBE.IPRECIO4 = decimal.Parse(this.PRECIO4TextBox.Text);
            }
            if (this.PRECIO5TextBox.Text != "")
            {
                preciosTempBE.IPRECIO5 = decimal.Parse(this.PRECIO5TextBox.Text);
            }
            if (this.PRECIOSUGERIDOTextBox.Text != "")
            {
                preciosTempBE.ISUGERIDO = decimal.Parse(this.PRECIOSUGERIDOTextBox.Text);
            }

            if(bExisteCambioPrecios)
            {
                if(!preciosTempD.CambiarPRECIOSTEMPD(preciosTempBE, preciosTempBE, null))
                {
                    MessageBox.Show("No se puedo cambiar : " + preciosTempD.IComentario);
                    
                }
                else
                {
                    LimpiarActual();
                    TBCodigo.Focus();
                    LlenarDatos();
                }
            }
            else
            {
                if(preciosTempD.AgregarPRECIOSTEMPD(preciosTempBE,  null) == null)
                {

                    MessageBox.Show("No se puedo cambiar : " + preciosTempD.IComentario);
                }
                else
                {
                    LimpiarActual();
                    TBCodigo.Focus();
                    LlenarDatos(); 
                }
            }


        }



        private void LimpiarActual()
        {
            productoId = 0;
            TBCodigo.Text = "";

            this.PRECIO1Lbl.Text = "";
            this.PRECIO2Lbl.Text = "";
            this.PRECIO3Lbl.Text = "";
            this.PRECIO4Lbl.Text = "";
            this.PRECIO5Lbl.Text = "";
            this.PRECIOSUGERIDOLbl.Text = "";

            this.PRECIO1TextBox.Text = "";
            this.PRECIO2TextBox.Text = "";
            this.PRECIO3TextBox.Text = "";
            this.PRECIO4TextBox.Text = "";
            this.PRECIO5TextBox.Text = "";
            this.PRECIOSUGERIDOTextBox.Text = "";
            this.LBProductoDescripcion.Text = "";
        }


        private void PRECIO2TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.PRECIO3TextBox.Focus();
                PRECIO3TextBox.Select(0, PRECIO3TextBox.Text.Length);
            }
        }

        private void PRECIO3TextBox_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                this.PRECIO4TextBox.Focus();
                PRECIO4TextBox.Select(0, PRECIO4TextBox.Text.Length);
            }
        }

        private void PRECIO4TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.PRECIO5TextBox.Focus();
                PRECIO5TextBox.Select(0, PRECIO5TextBox.Text.Length);
            }
        }


        private void PRECIO5TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.PRECIOSUGERIDOTextBox.Focus();
                PRECIOSUGERIDOTextBox.Select(0, PRECIOSUGERIDOTextBox.Text.Length);
            }
        }


        private void PRECIOSUGERIDOTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            
        }

        private void PRECIO1TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                this.PRECIO2TextBox.Focus();
                PRECIO2TextBox.Select(0, PRECIO2TextBox.Text.Length);
            }
        }

        private void LlenarDatos()
        {
            // TODO: This line of code loads data into the 'dSCatalogos.PRECIOSTEMP' table. You can move, or remove it, as needed.
            this.pRECIOSTEMPTableAdapter.Fill(this.dSCatalogos.PRECIOSTEMP);
        }

        private void WFPreciosTemp_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_EDITARPRECIOSNUEVOS , null))
            {
                m_bPermisoAEditarCambioPrecio = true;
            }

            pnlEdicionPrecio.Enabled = m_bPermisoAEditarCambioPrecio;


            if (CurrentUserID.CurrentCompania.IESMATRIZ != null && !CurrentUserID.CurrentCompania.IESMATRIZ.Equals("S"))
            {

                WFImportarPrecTemp ef = new WFImportarPrecTemp();
                ef.ShowDialog();
                ef.Dispose();
                GC.SuppressFinalize(ef);
            }

            LlenarDatos();

           
        }

        private void pRECIOSTEMPDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && m_bPermisoAEditarCambioPrecio)
            {

                if (pRECIOSTEMPDataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    String claveProducto = pRECIOSTEMPDataGridView.Rows[e.RowIndex].Cells["DGCLAVE"].Value.ToString();
                    LimpiarActual();
                    TBCodigo.Text = claveProducto;
                    fillDataFromCodigo();
                    this.PRECIO1TextBox.Focus();

                }
                else if (pRECIOSTEMPDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    long lPrecioTempId = long.Parse(pRECIOSTEMPDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    if (MessageBox.Show("Esta seguro de eliminar este registro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    CPRECIOSTEMPBE preciosTempBE = new CPRECIOSTEMPBE();
                    CPRECIOSTEMPD preciosTempD = new CPRECIOSTEMPD();
                    preciosTempBE.IID = lPrecioTempId;
                    if(!preciosTempD.BorrarPRECIOSTEMPD(preciosTempBE, null))
                    {
                        MessageBox.Show("Hubo problemas para borrar el registro " + preciosTempD.IComentario);
                    }
                    this.LlenarDatos();
                }
            }
        }

        private void btnEtiquetar_Click(object sender, EventArgs e)
        {
            btnAplicarCambios.Enabled = true;

            WFImprimirEtiquetas wf = new WFImprimirEtiquetas(true);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);


        }

        private void btnAplicarCambios_Click(object sender, EventArgs e)
        {

            if (this.dSCatalogos.PRECIOSTEMP == null || this.dSCatalogos.PRECIOSTEMP.Rows.Count == 0)
                return;

            if (MessageBox.Show("Esta seguro de que quiere  aplicar los cambios? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            


            if (CurrentUserID.CurrentCompania.IESMATRIZ != null && CurrentUserID.CurrentCompania.IESMATRIZ.Equals("S"))
            {

                WFMatrizExportPrecTemp ef2 = new WFMatrizExportPrecTemp();
                ef2.ShowDialog();
                bool importacionExitosa = ef2.m_importacionExitosa;
                ef2.Dispose();
                GC.SuppressFinalize(ef2);

                if (!importacionExitosa)
                {
                    return;
                }
            }

            CPRECIOSTEMPD preciosTempD = new CPRECIOSTEMPD();
            if (!preciosTempD.PRECIOSTEMP_APLICAR(null))
            {
                MessageBox.Show("Hubo un error al aplicar los precios " + preciosTempD.IComentario);
                return;
            }

            if (!preciosTempD.PRECIOSTEMP_ELIMINAR(null))
            {
                MessageBox.Show("Hubo un error al eliminar los precios temporales" + preciosTempD.IComentario);
                return;
            }


            CPRODUCTOD productoD = new CPRODUCTOD();
            productoD.PRODUCTOPRECIO(null);


            WFProductoCambioPrecio wfp = new WFProductoCambioPrecio();
            wfp.ShowDialog();
            wfp.Dispose();
            GC.SuppressFinalize(wfp);

            this.Close();
        }

    }
}
