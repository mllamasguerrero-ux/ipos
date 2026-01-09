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

namespace iPos
{
    public partial class WFQuotaMgmt : IposForm
    {

        bool modoEdicion = true;
        long vendedorDefault = 0;
        public WFQuotaMgmt()
        {
            InitializeComponent();
        }

        public WFQuotaMgmt(bool bmodoEdicion, long pvendedorDefault):this()
        {
            modoEdicion = bmodoEdicion;
            vendedorDefault = pvendedorDefault;

        }

        private void WFQuotaMgmt_Load(object sender, EventArgs e)
        {

            btnEnviar.Visible = false;
            pnlQuotas.Enabled = false;
            pnlUtilidades.Visible = false;

            this.VENDEDORIDTextBox.Enabled = modoEdicion;

            setDefaultAnio();
            LimpiarPantalla();
            if (vendedorDefault != 0)
            {
                string strBuffer;
                    this.VENDEDORIDTextBox.DbValue = vendedorDefault.ToString();
                    this.VENDEDORIDTextBox.MostrarErrores = false;
                    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.VENDEDORIDTextBox.MostrarErrores = true;
                    LlenarDatos();
            }


        }


        private void setDefaultAnio()
        {
            ANIOTextBox.Value = DateTime.Today.Year;
        }

        private void LimpiarPantalla()
        {




            QUOTAMES1TextBox.Text = "0.00"; LOGROMES1TextBox.Text = "0.00"; PORCQUOTAMES1TextBox.Text = "0.00"; UTILIDADMES1TextBox.Text = "0.00";
            QUOTAMES2TextBox.Text = "0.00"; LOGROMES2TextBox.Text = "0.00"; PORCQUOTAMES2TextBox.Text = "0.00"; UTILIDADMES2TextBox.Text = "0.00";
            QUOTAMES3TextBox.Text = "0.00"; LOGROMES3TextBox.Text = "0.00"; PORCQUOTAMES3TextBox.Text = "0.00"; UTILIDADMES3TextBox.Text = "0.00";
            QUOTAMES4TextBox.Text = "0.00"; LOGROMES4TextBox.Text = "0.00"; PORCQUOTAMES4TextBox.Text = "0.00"; UTILIDADMES4TextBox.Text = "0.00";
            QUOTAMES5TextBox.Text = "0.00"; LOGROMES5TextBox.Text = "0.00"; PORCQUOTAMES5TextBox.Text = "0.00"; UTILIDADMES5TextBox.Text = "0.00";
            QUOTAMES6TextBox.Text = "0.00"; LOGROMES6TextBox.Text = "0.00"; PORCQUOTAMES6TextBox.Text = "0.00"; UTILIDADMES6TextBox.Text = "0.00";
            QUOTAMES7TextBox.Text = "0.00"; LOGROMES7TextBox.Text = "0.00"; PORCQUOTAMES7TextBox.Text = "0.00"; UTILIDADMES7TextBox.Text = "0.00";
            QUOTAMES8TextBox.Text = "0.00"; LOGROMES8TextBox.Text = "0.00"; PORCQUOTAMES8TextBox.Text = "0.00"; UTILIDADMES8TextBox.Text = "0.00";
            QUOTAMES9TextBox.Text = "0.00"; LOGROMES9TextBox.Text = "0.00"; PORCQUOTAMES9TextBox.Text = "0.00"; UTILIDADMES9TextBox.Text = "0.00";
            QUOTAMES10TextBox.Text = "0.00"; LOGROMES10TextBox.Text = "0.00"; PORCQUOTAMES10TextBox.Text = "0.00"; UTILIDADMES10TextBox.Text = "0.00";
            QUOTAMES11TextBox.Text = "0.00"; LOGROMES11TextBox.Text = "0.00"; PORCQUOTAMES11TextBox.Text = "0.00"; UTILIDADMES11TextBox.Text = "0.00";
            QUOTAMES12TextBox.Text = "0.00"; LOGROMES12TextBox.Text = "0.00"; PORCQUOTAMES12TextBox.Text = "0.00"; UTILIDADMES12TextBox.Text = "0.00";
        }


        private void LlenarDatos()
        {

            if (this.VENDEDORIDTextBox.Text.Trim().Length == 0)
            {
                LimpiarPantalla();
                btnEnviar.Visible = false;
                pnlQuotas.Enabled = false;
                pnlUtilidades.Visible = false;
                return;
            }

            long vendedorId = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            int anio = (int)ANIOTextBox.Value;

            CQUOTAD quotaD = new CQUOTAD();
            CQUOTABE[] quotas = quotaD.seleccionarQUOTASVendedorAnio(vendedorId, anio, null);

            LimpiarPantalla();
            decimal buffer = 0;

            foreach (CQUOTABE quotaItem in quotas)
            {
                switch (quotaItem.IMES)
                {
                    case 1:
                        {

                            QUOTAMES1TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES1TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES1TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES1TextBox.Text = buffer.ToString("N2"); 
                            }
                            UTILIDADMES1TextBox.Text = quotaItem.IUTILIDAD.ToString("N2"); 
                            break;
                        }

                    case 2:
                        {

                            QUOTAMES2TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES2TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES2TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES2TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES2TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }


                    case 3:
                        {

                            QUOTAMES3TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES3TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES3TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES3TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES3TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 4:
                        {

                            QUOTAMES4TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES4TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES4TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES4TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES4TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 5:
                        {

                            QUOTAMES5TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES5TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES5TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES5TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES5TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 6:
                        {

                            QUOTAMES6TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES6TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES6TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES6TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES6TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 7:
                        {

                            QUOTAMES7TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES7TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES7TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES7TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES7TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 8:
                        {

                            QUOTAMES8TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES8TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES8TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES8TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES8TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 9:
                        {

                            QUOTAMES9TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES9TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES9TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES9TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES9TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 10:
                        {

                            QUOTAMES10TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES10TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES10TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES10TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES10TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 11:
                        {

                            QUOTAMES11TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES11TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES11TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES11TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES11TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }

                    case 12:
                        {

                            QUOTAMES12TextBox.Text = quotaItem.IQUOTA.ToString("N2");
                            LOGROMES12TextBox.Text = quotaItem.ILOGRO.ToString("N2");
                            if (quotaItem.IQUOTA == 0)
                            {
                                PORCQUOTAMES12TextBox.Text = "0.00";
                            }
                            else
                            {
                                buffer = quotaItem.ILOGRO / quotaItem.IQUOTA;
                                buffer = buffer * 100;
                                PORCQUOTAMES12TextBox.Text = buffer.ToString("N2");
                            }
                            UTILIDADMES12TextBox.Text = quotaItem.IUTILIDAD.ToString("N2");
                            break;
                        }
                }
            }


            btnEnviar.Visible = modoEdicion;
            pnlQuotas.Enabled = modoEdicion;
            pnlUtilidades.Visible = modoEdicion;






        }

        private void VENDEDORIDTextBox_Validated(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void ANIOTextBox_ValueChanged(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
            if (this.VENDEDORIDTextBox.Text.Trim().Length == 0)
            {
                return;
            }

            long vendedorId = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            int anio = (int)ANIOTextBox.Value;
            CQUOTAD quotaD = new CQUOTAD();

            
            decimal quotaEnero = (this.QUOTAMES1TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES1TextBox.NumericValue.ToString()) : 0;
            decimal quotaFebrero = (this.QUOTAMES2TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES2TextBox.NumericValue.ToString()) : 0;
            decimal quotaMarzo = (this.QUOTAMES3TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES3TextBox.NumericValue.ToString()) : 0;
            decimal quotaAbril = (this.QUOTAMES4TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES4TextBox.NumericValue.ToString()) : 0;
            decimal quotaMayo = (this.QUOTAMES5TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES5TextBox.NumericValue.ToString()) : 0;
            decimal quotaJunio = (this.QUOTAMES6TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES6TextBox.NumericValue.ToString()) : 0;
            decimal quotaJulio = (this.QUOTAMES7TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES7TextBox.NumericValue.ToString()) : 0;
            decimal quotaAgosto = (this.QUOTAMES8TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES8TextBox.NumericValue.ToString()) : 0;
            decimal quotaSeptiembre = (this.QUOTAMES9TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES9TextBox.NumericValue.ToString()) : 0;
            decimal quotaOctubre = (this.QUOTAMES10TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES10TextBox.NumericValue.ToString()) : 0;
            decimal quotaNoviembre = (this.QUOTAMES11TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES11TextBox.NumericValue.ToString()) : 0;
            decimal quotaDiciembre = (this.QUOTAMES12TextBox.NumericValue != null) ? decimal.Parse(this.QUOTAMES12TextBox.NumericValue.ToString()) : 0;

            if (quotaD.CambiarQUOTAVendedorAnio(vendedorId, anio, quotaEnero, quotaFebrero, quotaMarzo, quotaAbril,
                                              quotaMayo, quotaJunio, quotaJulio, quotaAgosto,
                                              quotaSeptiembre, quotaOctubre, quotaNoviembre, quotaDiciembre, null))
            {
                LlenarDatos();
                MessageBox.Show("Se han hecho los cambios con exito");
            }
        }
    }
}
