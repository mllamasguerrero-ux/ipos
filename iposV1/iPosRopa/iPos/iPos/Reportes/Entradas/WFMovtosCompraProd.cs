using iPos;
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

namespace iPosReporting
{
    public partial class WFMovtosCompraProd : Form
    {
        public WFMovtosCompraProd()
        {
            InitializeComponent();
        }


        private void SeleccionaProducto()
        {

            LOOKPROD look;
            look = new LOOKPROD(ITEMIDTextBox.Text, !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"), TipoProductoNivel.tp_hijos, 0);
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

                this.ITEMIDTextBox.Focus();

                this.ITEMLabel.Text = dr["DESCRIPCION1"].ToString();

                Actualizar();

            }
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {

            this.SeleccionaProducto();
        }

        private void Actualizar()
        {

            try
            {

                CPARAMETROBE parametroBE = new CPARAMETROBE();
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroBE = parametroD.seleccionarPARAMETROActual(null);


                int mTipoDoctoId = (int)DBValues._DOCTO_TIPO_COMPRA;

                long mAlmacenId;
                mAlmacenId = 0;


                Int64? productoId = 0;
                try
                {
                    productoId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }


                this.gET_PRODUCTO_MOVTOSTableAdapter.Fill(
                    this.dSFastReports.GET_PRODUCTO_MOVTOS,
                    productoId,
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            try
            {

                CPARAMETROBE parametroBE = new CPARAMETROBE();
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroBE = parametroD.seleccionarPARAMETROActual(null);


                int mTipoDoctoId = (int)DBValues._DOCTO_TIPO_COMPRA;

                long mAlmacenId;
                mAlmacenId = 0;


                Int64? productoId = 0;
                try
                {
                    productoId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }


                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("fechaini", dateTimePickerFechaIni.Value);
                dictionary.Add("fechafin", dateTimePickerFechaFin.Value);
                dictionary.Add("productoid", productoId);
                dictionary.Add("almacenid", mAlmacenId);
                dictionary.Add("sucursalid", parametroBE.ISUCURSALID);
                dictionary.Add("tipodoctoid", mTipoDoctoId);
                dictionary.Add("almacennombre", "Todos");
                dictionary.Add("tipodoctonombre", "Compra");

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

        private void ITEMIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            

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

        private void ITEMIDTextBox_Validated(object sender, EventArgs e)
        {


            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                SeleccionaProducto();
                return;
            }
            else
            {
                this.ITEMLabel.Text = prod.IDESCRIPCION1;
                Actualizar();
                return;
            }

        }

        //private void fillToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.gET_PRODUCTO_MOVTOSTableAdapter.Fill(this.dSFastReports.GET_PRODUCTO_MOVTOS, new System.Nullable<long>(((long)(System.Convert.ChangeType(pRODUCTOIDToolStripTextBox.Text, typeof(long))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAINIToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAFINToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(aLMACENIDToolStripTextBox.Text, typeof(long))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(sUCURSALIDToolStripTextBox.Text, typeof(long))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(tIPODOCTOIDToolStripTextBox.Text, typeof(long))))));
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
