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
    public partial class WFProductoCambioPrecio : IposForm
    {

        Boolean bTieneDerechoAVerCostoCambioPrecio = false;

        public WFProductoCambioPrecio()
        {
            InitializeComponent();
        }

        public WFProductoCambioPrecio(DateTime fecha):base()
        {
            this.dateTimePicker1.Value = fecha;
            //LlenarGrid(fecha);
        }


        private void LlenarGrid(DateTime fecha)
        {

            try
            {
                string strSoloPrecio1 = this.CBSoloCambioPrecio.Checked ? "S" : "N";
                this.pRODUCTOPRECIOLOGTableAdapter.Fill(this.dSImportaciones.PRODUCTOPRECIOLOG, fecha, strSoloPrecio1);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void TBEnviar_Click(object sender, EventArgs e)
        {
             LlenarGrid(dateTimePicker1.Value);
        }

        private void BTimprimir_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }




        private void ImprimirTicket()
        {


            Ticket ticket = new Ticket();


            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();
            //get data for the generation of the dbfs
            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                return ;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {
                return ;
            }

            ticket.AddHeaderLine("CAMBIO DE PRECIOS");


            ticket.AddHeaderLine("      " + parametroBE.INOMBRE);
            ticket.AddHeaderLine(parametroBE.ICALLE);
            ticket.AddHeaderLine(parametroBE.ILOCALIDAD.Trim() + " , " + parametroBE.IESTADO.Trim());
            ticket.AddHeaderLine("RFC: " + parametroBE.IRFC);
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("Vendedor: " + iPos.CurrentUserID.CurrentUser.INOMBRE);
            ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Ticket " );
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            ticket.AddHeaderLine("DESCRIPCION               ");
            ticket.AddHeaderLine("    PRECIO 1     PRECIO 2     PRECIO 3");

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            string line;
            decimal d_precio_act1 = 0,d_precio_act2 = 0,d_precio_act3 = 0;
            foreach (DataGridViewRow dr in this.pRODUCTOPRECIOLOGDataGridView.Rows)
            {

                if (dr.Cells["CLAVE_COL"].Value != null && dr.Cells["CLAVE_COL"].Value != DBNull.Value)
                {
                    string strLine = "";
                    strLine += dr.Cells["CLAVE_COL"].Value.ToString().Trim();

                    if (dr.Cells["DESCRIPCION1_COL"].Value != null && dr.Cells["DESCRIPCION1_COL"].Value != DBNull.Value)
                    {
                        strLine += "  " + dr.Cells["DESCRIPCION1_COL"].Value.ToString().Trim();
                    }
                    ticket.AddHeaderLine(strLine);
                }


                if (dr.Cells["PRECIO1_COL"].Value != null && dr.Cells["PRECIO1_COL"].Value != DBNull.Value)
                    d_precio_act1 = (decimal)dr.Cells["PRECIO1_COL"].Value;
                else
                    d_precio_act1 = 0;


                if (dr.Cells["PRECIO2_COL"].Value != null && dr.Cells["PRECIO2_COL"].Value != DBNull.Value)
                    d_precio_act2 = (decimal)dr.Cells["PRECIO2_COL"].Value;
                else
                    d_precio_act2 = 0;


                if (dr.Cells["PRECIO3_COL"].Value != null && dr.Cells["PRECIO3_COL"].Value != DBNull.Value)
                    d_precio_act3 = (decimal)dr.Cells["PRECIO3_COL"].Value;
                else
                    d_precio_act3 = 0;


                    line = "";
                    line += Ticket.FormatPrintField(d_precio_act1.ToString("N2"), 11, 0) + "  ";
                    line += Ticket.FormatPrintField(d_precio_act2.ToString("N2"), 11, 0) + "  ";
                    line += Ticket.FormatPrintField(d_precio_act3.ToString("N2"), 11, 0) + "  ";
                    ticket.AddHeaderLine(line);

                
                ticket.AddHeaderLine("");

            }

           

            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.PrintTicketDirect(Ticket.GetReceiptPrinter());


        }

        private void WFProductoCambioPrecio_Load(object sender, EventArgs e)
        {
            LlenarGrid(dateTimePicker1.Value);


            //verificacion de permisos
            CUSUARIOSD usersD = new CUSUARIOSD();
            bTieneDerechoAVerCostoCambioPrecio = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VERCOSTOCAMBIOPRECIO, null);
            DGCOSTOREPOSICION.Visible = bTieneDerechoAVerCostoCambioPrecio;
            
        }

        private void btnReporteLargo_Click(object sender, EventArgs e)
        {
            string strSoloPrecio1 = this.CBSoloCambioPrecio.Checked ? "S" : "N";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("FECHA", dateTimePicker1.Value);
            dictionary.Add("SOLOPRECIO1", strSoloPrecio1);

            string strReporte = "EtiquetasCambioPrecio.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }



    }
}
