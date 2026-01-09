using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;

namespace iPos
{
    public partial class WFPrecioPersona : Form
    {
        long productoId = 0;
        long personaId = 0;

        bool bTieneDerechoPonerPrecioAbajoMinimo = false;
        public WFPrecioPersona()
        {
            InitializeComponent();
        }


        public WFPrecioPersona(long _personaId) : this()
        {
            personaId = _personaId; 
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
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION1;
            this.PRECIO1Lbl.Text = prod.IPRECIO1.ToString();

            productoId = prod.IID;

            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");

            this.PRECIO1Lbl.Text = Math.Round((prod.IPRECIO1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO2Lbl.Text = Math.Round((prod.IPRECIO2 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO3Lbl.Text = Math.Round((prod.IPRECIO3 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO4Lbl.Text = Math.Round((prod.IPRECIO4 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            this.PRECIO5Lbl.Text = Math.Round((prod.IPRECIO5 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
            //this.PRECIOSUGERIDOLbl.Text = prod.IPRECIOSUGERIDO.ToString();



            CPRECIOPERSONABE preciosTempBE = new CPRECIOPERSONABE();
            CPRECIOPERSONAD preciosTempD = new CPRECIOPERSONAD();
            preciosTempBE.IPRODUCTOID = productoId;
            preciosTempBE.IPERSONAID = obtenerPersonaIdSeleccionada() ;
            preciosTempBE = preciosTempD.seleccionarPRECIOPERSONAXPersonaYProd(preciosTempBE, null);

            if (preciosTempBE != null)
            {

                this.PRECIO1TextBox.Text = Math.Round((preciosTempBE.IPRECIO * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString(); 
            }
            else
            {

                this.PRECIO1TextBox.Text = Math.Round((prod.IPRECIO1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
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

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            //bTieneDerechoPonerPrecioAbajoMinimo
            

            if (TBCodigo.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                this.LBProductoDescripcion.Text = "";
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }

            productoId = prod.IID;

            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");
            decimal precioEspecificoConImpuesto = decimal.Parse(PRECIO1TextBox.Text);

            CPRECIOPERSONAD prodPersD = new CPRECIOPERSONAD();
            CPRECIOPERSONABE prodPersBE = new CPRECIOPERSONABE();
            prodPersBE.IPRODUCTOID = productoId;
            prodPersBE.IACTIVO = "S";

            if (this.PRECIO1TextBox.Text != "")
            {

                decimal precioConImpuesto = decimal.Parse(this.PRECIO1TextBox.Text.ToString());
                prodPersBE.IPRECIO = Math.Round((precioConImpuesto / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                
            }
            else
            {

                MessageBox.Show("Seleccione un precio valido");
                return;
            }


            prodPersBE.IPERSONAID = obtenerPersonaIdSeleccionada();
            if(prodPersBE.IPERSONAID == 0)
            {

                MessageBox.Show("Seleccione un cliente valido");
                return;
            }


            
            if(prodPersBE.IPRECIO < prod.ICOSTOREPOSICION)
            {

                MessageBox.Show("El precio no puede estar abajo del costo de reposicion");
                return;
            }


            CPRODUCTOD prodD = new CPRODUCTOD();
            decimal precioMinimo = prodD.GET_PRECIOMINIMO(prodPersBE.IPRODUCTOID, prodPersBE.IPERSONAID, null);

            if (!this.bTieneDerechoPonerPrecioAbajoMinimo && prodPersBE.IPRECIO < precioMinimo)
            {

                MessageBox.Show("No tiene derecho para poner el precio debajo del minimo");
                return;
            }


            Boolean bExisteCambioPrecios = false;
            CPRECIOPERSONABE precioPersExistente = new CPRECIOPERSONABE();
            precioPersExistente.IPERSONAID = prodPersBE.IPERSONAID;
            precioPersExistente.IPRODUCTOID = prodPersBE.IPRODUCTOID;
            precioPersExistente = prodPersD.seleccionarPRECIOPERSONAXPersonaYProd(precioPersExistente, null);

            bExisteCambioPrecios = precioPersExistente != null;


            if (bExisteCambioPrecios)
            {
                prodPersBE.IID = precioPersExistente.IID;
                if (!prodPersD.CambiarPRECIOPERSONAD(prodPersBE, prodPersBE, null))
                {
                    MessageBox.Show("No se puedo cambiar : " + prodPersD.IComentario);

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

                if (prodPersD.AgregarPRECIOPERSONAD(prodPersBE, null) == null)
                {

                    MessageBox.Show("No se puedo cambiar : " + prodPersD.IComentario);
                }
                else
                {
                    LimpiarActual();
                    TBCodigo.Focus();
                    LlenarDatos();
                }

            }


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

        private void ITEMButton_Click(object sender, EventArgs e)
        {

            this.SeleccionaCliente();
        }

        private void LlenarDatos()
        {
            try
            {
                this.pRECIOPERSONATableAdapter.Fill(this.dSCatalogos.PRECIOPERSONA, (int)personaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
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

            this.PRECIO1TextBox.Text = "";

            this.LBProductoDescripcion.Text = "";
        }


        private void WFPrecioPersona_Load(object sender, EventArgs e)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            bTieneDerechoPonerPrecioAbajoMinimo = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PRECIOABAJOMINIMO, null);
                
        }

        private void pRECIOPERSONADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1 /*&& m_bPermisoAEditarCambioPrecio*/)
            {

                if (pRECIOPERSONADataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    String claveProducto = pRECIOPERSONADataGridView.Rows[e.RowIndex].Cells["PRODUCTOCLAVE"].Value.ToString();
                    LimpiarActual();
                    TBCodigo.Text = claveProducto;
                    fillDataFromCodigo();
                    this.PRECIO1TextBox.Focus();

                }
                else if (pRECIOPERSONADataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    long lPrecioTempId = long.Parse(pRECIOPERSONADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    if (MessageBox.Show("Esta seguro de eliminar este registro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    CPRECIOPERSONABE preciosTempBE = new CPRECIOPERSONABE();
                    CPRECIOPERSONAD preciosTempD = new CPRECIOPERSONAD();
                    preciosTempBE.IID = lPrecioTempId;
                    if (!preciosTempD.BorrarPRECIOPERSONAD(preciosTempBE, null))
                    {
                        MessageBox.Show("Hubo problemas para borrar el registro " + preciosTempD.IComentario);
                    }
                    this.LlenarDatos();
                }
            }
        }

        private void WFPrecioPersona_Shown(object sender, EventArgs e)
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
                    TBCodigo.Focus();
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = personaId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            if (personaBE == null)
                return;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("clienteid", personaId);
            dictionary.Add("nombrecliente", personaBE.INOMBRE);
            dictionary.Add("listaprecioid", personaBE.ILISTAPRECIOID == 0 ? 1 : personaBE.ILISTAPRECIOID);
            dictionary.Add("mostrarexistencia", this.CBEnviarExistencia.Checked ? "S" : "N");
            string strReporte = "InformeProductoPrecioXCliente.frx";
            string stSubject = "Precios de producto para el cliente " + personaBE.INOMBRE;
            string strEmail = personaBE.IEMAIL1;
            WFPreguntaCorreo wf = new WFPreguntaCorreo(strEmail);
            wf.ShowDialog();

            if (wf.boolEnviar && wf.strCorreo != null && wf.strCorreo.Contains("@"))
            {


                iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), wf.strCorreo, dictionary, stSubject, "PDF");
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }


            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void BTImprimir_Click(object sender, EventArgs e)
        {
            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = personaId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            if (personaBE == null)
                return;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("clienteid", personaId);
            dictionary.Add("nombrecliente", personaBE.INOMBRE);
            dictionary.Add("listaprecioid", personaBE.ILISTAPRECIOID == 0 ? 1 : personaBE.ILISTAPRECIOID);
            dictionary.Add("mostrarexistencia", this.CBEnviarExistencia.Checked ? "S" : "N");

            string strReporte = "InformeProductoPrecioXCliente.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

    }
}
