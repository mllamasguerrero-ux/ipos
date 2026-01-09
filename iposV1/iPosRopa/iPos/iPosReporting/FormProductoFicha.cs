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
using System.IO;

namespace iPosReporting
{
    public delegate void VerHistorial(int productoid);
    public delegate void VerProductoEstadisticos(int productoid);
	public partial class FormProductoFicha : ReducedFlickerForm
    {

		private int mProductoId;
        private int m_iUserId;
        private CPERSONABE m_userObject;

        CPARAMETROBE m_empresa;

        VerHistorial m_historialDelegate = null;

        public VerProductoEstadisticos m_estadisticoVentaDelegate = null;
        public VerProductoEstadisticos m_estadisticoCompraDelegate = null;

		public FormProductoFicha()
		{
			InitializeComponent();
			mProductoId = 0;
            m_iUserId = 0;
            m_empresa = null;
		}


		public FormProductoFicha(int ProductoId, int UserId, CPERSONABE userObject, CPARAMETROBE parametroBE):this()
		{
			mProductoId = ProductoId;
            m_iUserId = UserId;
            m_userObject = userObject;
            m_empresa = parametroBE;
		}


        public FormProductoFicha(int ProductoId, int UserId, CPERSONABE userObject, CPARAMETROBE parametroBE, VerHistorial historialDelegate)
            :this(ProductoId, UserId,  userObject,  parametroBE)
        {
            m_historialDelegate = historialDelegate;
        }


		private void FormProductoFicha_Load(object sender, EventArgs e)
		{
            // TODO: This line of code loads data into the 'dSReportIpos.ALMACEN' table. You can move, or remove it, as needed.
            this.aLMACENTableAdapter.Fill(this.dSReportIpos.ALMACEN);

            


            report1.Load(getPathForFile("Lotes.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);


            report2.Load(getPathForFile("InformeVentasPendienteXProductoDetalle.frx", FastReportsTipoFile.desistema));
            report2.Preview = this.previewMovtosPendientes;
            report2.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report2.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report2.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);

            // TODO: This line of code loads data into the 'dSReportIpos.TIPODOCTO' table. You can move, or remove it, as needed.
            this.tIPODOCTOTableAdapter.Fill(this.dSReportIpos.TIPODOCTO);
			// TODO: This line of code loads data into the 'dSReportIpos.PRODUCTO1' table. You can move, or remove it, as needed.
             this.pRODUCTO1TableAdapter.Fill(this.dSReportIpos.PRODUCTO1);
            SetPreciosVisibility();

            if (mProductoId != 0)
            {
                SetProducto(mProductoId);
            }


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos(m_iUserId, 10001, null))
            {
                this.pnlCostos.Visible = true;
            }
            Boolean usuarioTienePermisoHistorial = usuariosD.UsuarioTienePermisos(m_iUserId, DBTN.DERECHO_BITACORA_PRODUCTO, null);
            this.btnHistory.Visible = usuarioTienePermisoHistorial;


            if (m_empresa != null)
                pnlSuperListaPrecio.Visible = m_empresa.IMANEJASUPERLISTAPRECIO.Equals("S");
            else
                pnlSuperListaPrecio.Visible = false;

            this.tabControl1.Controls.Remove(tabPageVentasDiarias);
            this.tabControl1.Controls.Remove(tabPageDoctos);
            this.tabControl1.Controls.Remove(tabPageMovimientos);


            if (!usuariosD.UsuarioTienePermisos(m_iUserId, 10030, null))
            {
                this.tabControl1.Controls.Remove(tabPageMovtos);
           }

            btnEstadisticosVenta.Visible = m_estadisticoVentaDelegate != null;
            btnEstadisticosCompra.Visible = m_estadisticoCompraDelegate != null;
            
		}

		private void SetProducto(int ProductoId)
		{
			try
			{
				this.pRODUCTOTableAdapter.Fill(this.dSReportIpos.PRODUCTO, ProductoId);
                this.comboBox1.SelectedValue = (ProductoId);

                /**wpf only starts*
                 pRODUCTOBindingSource.View.MoveCurrentToFirst();
                 /**wpf only ends**/


                try
                {
                    if (this.dSReportIpos.PRODUCTO.Rows.Count > 0)
                    {
                        DataRow dr = this.dSReportIpos.PRODUCTO.Rows[0];
                        if (dr["ULTIMACOMPRA"] ==  DBNull.Value)
                        {
                            uLTIMACOMPRADateTimePicker.Visible = false;
                        }
                        if (dr["ULTIMAVENTA"] ==  DBNull.Value)
                        {
                            uLTIMAVENTADateTimePicker.Visible = false;
                        }

                    }
                }
                catch
                {

                }



			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				//this.pRODUCTOTableAdapter.Fill(this.dSReportIpos.PRODUCTO, ((int)(System.Convert.ChangeType(comboBox1.SelectedValue.ToString(), typeof(int)))));
				mProductoId = (int)(System.Convert.ChangeType(comboBox1.SelectedValue.ToString(), typeof(int)));
				SetProducto(mProductoId);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}

		private void buttonKardex_Click(object sender, EventArgs e)
		{
			try
			{
				//if (mProductoId != 0)
				//	this.KARDEX2TableAdapter.Fill(this.dSReportIpos.KARDEX2, mProductoId, dateTimePicker1.Value, dateTimePicker1.Value);
				/*
				this.gET_KARDEXTableAdapter.Fill(
					this.dSReportIpos.GET_KARDEX, 
					new System.Nullable<long>(((long)(System.Convert.ChangeType(pRODUCTO_IDToolStripTextBox.Text, typeof(long))))), 
					new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAINIToolStripTextBox.Text,typeof(System.DateTime))))), 
					new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAFINToolStripTextBox.Text, typeof(System.DateTime))))), 
					new System.Nullable<long>(((long)(System.Convert.ChangeType(aLMACENIDToolStripTextBox.Text, typeof(long))))));
				*/


                long mAlmacenId = 0;

                if(!CBAlmacen.Checked)
                    mAlmacenId = (long)(System.Convert.ChangeType(comboBoxAlmacen.SelectedValue.ToString(), typeof(long)));


				this.gET_KARDEXTableAdapter.Fill(
					this.dSReportIpos.GET_KARDEX,
					mProductoId,
					dateTimePickerFechaIni.Value,
					dateTimePickerFechaFin.Value,
					mAlmacenId);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void dESCRIPCIONTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void fillToolStripButton_Click(object sender, EventArgs e)
		{
		}

		private void fillToolStripButton1_Click(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{

                CPARAMETROBE parametroBE = new CPARAMETROBE();
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroBE = parametroD.seleccionarPARAMETROActual(null);

                
				/*
				this.gET_PRODUCTO_MOVTOSTableAdapter.Fill (
					this.dSReportIpos.GET_PRODUCTO_MOVTOS, 
					new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAINIToolStripTextBox.Text, typeof(System.DateTime))))), 
					new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAFINToolStripTextBox.Text, typeof(System.DateTime))))), 
					new System.Nullable<long>(((long)(System.Convert.ChangeType(aLMACENIDToolStripTextBox.Text, typeof(long))))), 
					new System.Nullable<long>(((long)(System.Convert.ChangeType(sUCURSALIDToolStripTextBox.Text, typeof(long))))),
					new System.Nullable<long>(((long)(System.Convert.ChangeType(tIPODOCTOIDToolStripTextBox.Text, typeof(long))))));
				 */
				int mTipoDoctoId;
				mTipoDoctoId = (int)(System.Convert.ChangeType(comboBoxTipoDocto.SelectedValue.ToString(), typeof(int)));

                long mAlmacenId;
                mAlmacenId = CBAlmacen.Checked ? 0 : (long)(System.Convert.ChangeType(comboBoxAlmacen.SelectedValue.ToString(), typeof(long)));


				this.gET_PRODUCTO_MOVTOSTableAdapter.Fill(
					this.dSReportIpos.GET_PRODUCTO_MOVTOS,
					mProductoId,
					dateTimePickerFechaIni.Value,
					dateTimePickerFechaFin.Value,
                    mAlmacenId,
                    parametroBE.ISUCURSALID,
					mTipoDoctoId //new System.Nullable<long>(((long)(System.Convert.ChangeType(textBoxTipoDoctoId.Text, typeof(long)))))
				);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				/*
				this.gET_CORTESTableAdapter.Fill(
					this.dSReportIpos.GET_CORTES, 
					new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAINIToolStripTextBox.Text, 
						typeof(System.DateTime))))), 
						new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAFINToolStripTextBox.Text, 
							typeof(System.DateTime))))));
				 */
				this.gET_CORTESTableAdapter.Fill(
					this.dSReportIpos.GET_CORTES,
					dateTimePickerFechaIni.Value,
					dateTimePickerFechaFin.Value
				);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void fillToolStripButton_Click_1(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				this.gET_DOCTOSTableAdapter.Fill(
					this.dSReportIpos.GET_DOCTOS,
					dateTimePickerFechaIni.Value,
					dateTimePickerFechaFin.Value
					);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void fillToolStripButton_Click_2(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				int mTipoDoctoId;

				mTipoDoctoId = (int)(System.Convert.ChangeType(comboBoxTipoDocto.SelectedValue.ToString(), typeof(int)));

				this.gET_MOVTOSTableAdapter.Fill(
					this.dSReportIpos.GET_MOVTOS,
					dateTimePickerFechaIni.Value,
					dateTimePickerFechaFin.Value,
					mTipoDoctoId);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}



        private void SetPreciosVisibility()
        {

            this.pRECIO1TextBox.Visible = false;
            this.pRECIO2TextBox.Visible = false;
            this.pRECIO3TextBox.Visible = false;
            this.pRECIO4TextBox.Visible = false;
            this.pRECIO5TextBox.Visible = false;

            this.pRECIO1Label.Visible = false;
            this.pRECIO2Label.Visible = false;
            this.pRECIO3Label.Visible = false;
            this.pRECIO4Label.Visible = false;
            this.pRECIO5Label.Visible = false;

            if (!(bool)m_userObject.isnull["ILISTAPRECIOID"])
            {

                if (m_userObject.ILISTAPRECIOID >= 1)
                {
                    this.pRECIO1TextBox.Visible = true;
                    this.pRECIO1Label.Visible = true;
                }

                if (m_userObject.ILISTAPRECIOID >= 2)
                {
                    this.pRECIO2TextBox.Visible = true;
                    this.pRECIO2Label.Visible = true;
                }

                if (m_userObject.ILISTAPRECIOID >= 3)
                {
                    this.pRECIO3TextBox.Visible = true;
                    this.pRECIO3Label.Visible = true;
                }

                if (m_userObject.ILISTAPRECIOID >= 4)
                {
                    this.pRECIO4TextBox.Visible = true;
                    this.pRECIO4Label.Visible = true;
                }

                if (m_userObject.ILISTAPRECIOID >= 5)
                {
                    this.pRECIO5TextBox.Visible = true;
                    this.pRECIO5Label.Visible = true;
                }
            }
            else
            {
                this.pRECIO1TextBox.Visible = true;
                this.pRECIO2TextBox.Visible = true;
                this.pRECIO3TextBox.Visible = true;
                this.pRECIO4TextBox.Visible = true;
                this.pRECIO5TextBox.Visible = true;

                this.pRECIO1Label.Visible = true;
                this.pRECIO2Label.Visible = true;
                this.pRECIO3Label.Visible = true;
                this.pRECIO4Label.Visible = true;
                this.pRECIO5Label.Visible = true;

            }

        }

        public enum FastReportsTipoFile { deusuario, desistema };
        public static string getPathForFile(string strFile, FastReportsTipoFile tipo)
        {
            CPARAMETROD parametro = new CPARAMETROD();
            CPARAMETROBE parametroBE = parametro.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return "";
            }
            

            if (parametroBE.IRUTAREPORTESSISTEMA != null && parametroBE.IRUTAREPORTESSISTEMA.Trim().Length > 0)
            {
                switch (tipo)
                {
                    case FastReportsTipoFile.desistema:
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreportssistema//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreportssistema//" + strFile;
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//fastreportssistema//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//fastreportssistema//" + strFile;
                        break;

                    case FastReportsTipoFile.deusuario:
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreports//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//repocustomized//fastreports//" + strFile;
                        if (File.Exists(parametroBE.IRUTAREPORTESSISTEMA + "//fastreports//" + strFile))
                            return parametroBE.IRUTAREPORTESSISTEMA + "//fastreports//" + strFile;
                        break;
                }
            }

            switch (tipo)
            {
                case FastReportsTipoFile.desistema:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreportssistema//" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreportssistema//" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//fastreportssistema//" + strFile;

                case FastReportsTipoFile.deusuario:
                    if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreports//" + strFile))
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//repocustomized//fastreports//" + strFile;
                    else
                        return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//sampdata//fastreports//" + strFile;
            }

            return "";

        }

        private void FormProductoFicha_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                report1.Delete();
                report1.Dispose();
            }
            catch
            {
            }
        }

        private void BTActualizarLotes_Click(object sender, EventArgs e)
        {


            report1.SetParameterValue("productoid", mProductoId);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void btnProductosXProductoYLote_Click(object sender, EventArgs e)
        {
           
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            



            try
            {

                CPARAMETROBE parametroBE = new CPARAMETROBE();
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroBE = parametroD.seleccionarPARAMETROActual(null);


                int mTipoDoctoId;
                string mTipoDoctoNombre = "";
                mTipoDoctoId = (int)(System.Convert.ChangeType(comboBoxTipoDocto.SelectedValue.ToString(), typeof(int)));
                mTipoDoctoNombre = comboBoxTipoDocto.SelectedText;

                long mAlmacenId;
                string mAlmacenNombre = "";
                mAlmacenId = CBAlmacen.Checked ? 0 : (long)(System.Convert.ChangeType(comboBoxAlmacen.SelectedValue.ToString(), typeof(long)));
                mAlmacenNombre = comboBoxAlmacen.SelectedText;

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("fechaini", dateTimePickerFechaIni.Value);
                dictionary.Add("fechafin", dateTimePickerFechaFin.Value);
                dictionary.Add("productoid", mProductoId);
                dictionary.Add("almacenid", mAlmacenId);
                dictionary.Add("sucursalid", parametroBE.ISUCURSALID);
                dictionary.Add("tipodoctoid", mTipoDoctoId);
                dictionary.Add("almacennombre", mAlmacenNombre);
                dictionary.Add("tipodoctonombre", mTipoDoctoNombre);

                string strReporte = "InformeMovtosProducto.frx";
                WFReportingShowing rp = new WFReportingShowing(WFReportingShowing.getPathForFile(strReporte, "desistema"), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }



        }

        private void BTActualizarMovtosPendientes_Click(object sender, EventArgs e)
        {

            report2.SetParameterValue("itemid", mProductoId);

            if (report2.Prepare())
                report2.ShowPrepared();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if(this.m_historialDelegate != null)
            {
                this.m_historialDelegate(mProductoId);
            }
        }

        private void btnEstadisticosVenta_Click(object sender, EventArgs e)
        {

            if (this.m_estadisticoVentaDelegate != null)
            {
                this.m_estadisticoVentaDelegate(mProductoId);
            }
        }

        private void btnEstadisticosCompra_Click(object sender, EventArgs e)
        {

            if (this.m_estadisticoCompraDelegate != null)
            {
                this.m_estadisticoCompraDelegate(mProductoId);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
