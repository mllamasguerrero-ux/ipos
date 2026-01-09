using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using Newtonsoft.Json;

namespace iPos
{
    public enum TipoValidacionMovil { porExistencia, porProcesados };
    public partial class WFValidacionExistenciasMovil : iPos.Tools.ScreenConfigurableForm
    {
        CDOCTOBE m_Docto = null;
        List<CM_PROPBE> m_prods = null;
        List<CM_VEDPBE> m_detalles = null;

        TipoValidacionMovil m_tipoValidacion;
        public bool m_bContinuar = false;

        public WFValidacionExistenciasMovil()
        {
            InitializeComponent();
        }

        public WFValidacionExistenciasMovil(CDOCTOBE docto, TipoValidacionMovil tipoValidacion, List<CM_PROPBE> prods, List<CM_VEDPBE> detalles)
            : this()
        {
            m_Docto = docto;
            m_tipoValidacion = tipoValidacion;
            m_prods = prods;
            m_detalles = detalles;
        }


        private void WFValidacionExistenciasMovil_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(true, true);

            this.gRIDPVTableAdapter1.Fill(this.dSPuntoDeVentaAux.GRIDPV, (int)m_Docto.IID);
            FormatGrid();

            if (m_tipoValidacion == TipoValidacionMovil.porExistencia)
            {
                SetExistenciasMatrizPorProducto();
            }
            else
            {
                btnCancelar.Visible = false;
                SetExistenciasMatrizPorProcesado();
            }
        }

        public void FormatGrid()
        {

            this.gridPVDataGridView.BackgroundColor = Color.White;
            this.gridPVDataGridView.DefaultCellStyle.BackColor = Color.White;

        }

        public void SetExistenciasMatrizPorProducto()
        {

            foreach (DataGridViewRow row in this.gridPVDataGridView.Rows)
            {

                string claveProducto = "";
                decimal cantidad = 0;

                if (row.Cells["GVCLAVEPRODUCTO"].Value != DBNull.Value)
                {
                    claveProducto = row.Cells["GVCLAVEPRODUCTO"].Value.ToString().Trim();
                }
                if (claveProducto.Length == 0)
                {
                    MessageBox.Show("Error No se pudo obtener la clave del producto");
                    return;
                }


                if (row.Cells["GVCANTIDAD"].Value != DBNull.Value)
                {
                    cantidad = decimal.Parse(row.Cells["GVCANTIDAD"].Value.ToString());
                }



                bool flagEncontrado = false;
                foreach (CM_PROPBE prod in m_prods)
                {
                    if (claveProducto.Equals(prod.IPRODUCTO.Trim()))
                    {
                        flagEncontrado = true;
                        row.Cells["GC_EXISTENCIA"].Value = prod.IEXIS1;
                        if (cantidad > prod.IEXIS1)
                        {

                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        }
                    }
                }

                if (!flagEncontrado)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            m_bContinuar = true;
            this.Close();
        }



        public void SetExistenciasMatrizPorProcesado()
        {

            foreach (DataGridViewRow row in this.gridPVDataGridView.Rows)
            {

                string claveProducto = "";
                decimal cantidad = 0;

                if (row.Cells["GVCLAVEPRODUCTO"].Value != DBNull.Value)
                {
                    claveProducto = row.Cells["GVCLAVEPRODUCTO"].Value.ToString().Trim();
                }
                if (claveProducto.Length == 0)
                {
                    MessageBox.Show("Error No se pudo obtener la clave del producto");
                    return;
                }


                if (row.Cells["GVCANTIDAD"].Value != DBNull.Value)
                {
                    cantidad = decimal.Parse(row.Cells["GVCANTIDAD"].Value.ToString());
                }



                bool flagEncontrado = false;
                foreach (CM_VEDPBE detalle in m_detalles)
                {
                    if (claveProducto.Equals(detalle.IPRODUCTO.Trim()))
                    {
                        flagEncontrado = true;
                        

                        row.Cells["GC_EXISTENCIA"].Value = detalle.ISURTIDAS;
                        if (cantidad > detalle.ISURTIDAS)
                        {

                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        }
                    }
                }

                if (!flagEncontrado)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }


            }
        }

       

        /*
        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in this.gridPVDataGridView.Rows)
            {

                coloreaRow(row);
            }
        }

        private void coloreaRow(DataGridViewRow row)
        {
            decimal existenciaMatriz = 0, cantidadPedido = 0;
            string inventariable = "N";

            try
            {
                if (row.Cells["GC_EXISTENCIA"].Value != DBNull.Value)
                {
                    existenciaMatriz = decimal.Parse(row.Cells["GC_EXISTENCIA"].Value.ToString());
                }


                if (row.Cells["GC_APEDIR"].Value != DBNull.Value)
                {
                    cantidadPedido = decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                }


                if (row.Cells["GC_INVENTARIABLE"].Value != DBNull.Value)
                {
                    inventariable = row.Cells["GC_INVENTARIABLE"].Value.ToString();
                }

                if (cantidadPedido > existenciaMatriz && inventariable == "S")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            row.Cells["GC_APEDIR"].Style.BackColor = Color.GreenYellow;
            row.Cells["GC_APEDIR"].Style.ForeColor = Color.Black;

        }

       */



    }
}
