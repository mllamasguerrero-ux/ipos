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
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFRetiros : IposForm
    {
        string m_printer = "";
        public WFRetiros()
        {
            InitializeComponent();
            try
            {
                m_printer = Ticket.GetReceiptPrinter();
            }
            catch { }
        }

        private void WFRetiros_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;


            ChecarPermisosDeRetiros();

            this.ComboProveedor.llenarDatos();
            this.ComboSupervisor.llenarDatos();

            
        }



        private void ChecarPermisosDeRetiros()
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            bool bPermisoParaRetiroPagoProveedor = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RETIROSAPAGOPROVEEDOR, null);
            bool bPermisoParaRetiroSupervisor = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RETIROSSUPERVISOR, null);

            if (!bPermisoParaRetiroPagoProveedor && !bPermisoParaRetiroSupervisor)
            {
                MessageBox.Show("No tiene permisos para hacer ningun tipo de retiro");
                this.Close();
            }

            if (!bPermisoParaRetiroPagoProveedor)
            {
                RBSupervisor.Checked = true;
                RBPagoAProveedor.Enabled = false;
                PNLPagoAProveedor.Enabled = false;
            }
            else if (!bPermisoParaRetiroSupervisor)
            {
                RBPagoAProveedor.Checked = true;
                RBSupervisor.Enabled = false;
                PNLSupervisor.Enabled = false;
            }

        }

        private void RBPagoAProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (RBPagoAProveedor.Checked)
            {
                PNLPagoAProveedor.Enabled = true;
                PNLSupervisor.Enabled = false;
            }
            else
            {
                PNLPagoAProveedor.Enabled = false;
                PNLSupervisor.Enabled = true;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (RBPagoAProveedor.Checked)
            {
                if (TBFactura.Text == "")
                {
                    MessageBox.Show("Ingrese un numero de factura");
                    return;
                }
            }


            decimal importe = Decimal.Parse(this.TBImporte.Text.ToString());
            if (importe <= 0)
            {
                MessageBox.Show("Ingrese un importe mayor de cero");
                return;
            }

            CDOCTOBE doctoBE = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();

            doctoBE.IALMACENID = DBValues._DOCTO_ALMACEN_DEFAULT;
            doctoBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            doctoBE.IVENDEDORID = iPos.CurrentUserID.CurrentUser.IID;
            doctoBE.IFECHA = DateTime.Today;
            doctoBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;

            if (RBPagoAProveedor.Checked)
            {
                doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_RETIRO_PAGOPROVEEDOR;
                doctoBE.IPERSONAID = long.Parse(this.ComboProveedor.SelectedValue.ToString());
                doctoBE.IREFERENCIA = TBFactura.Text;
                doctoBE.IVENCE = DTFecha.Value;
            }
            else
            {
                doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_RETIRO_SUPERVISOR;
                doctoBE.IPERSONAID = long.Parse(this.ComboSupervisor.SelectedValue.ToString());
            }

            doctoBE.IREFERENCIAS = TBNotas.Text;
            doctoBE.ITOTAL = importe;

            if (!doctoD.RETIRO_INSERTAR(ref doctoBE, null))
            {
                MessageBox.Show(doctoD.IComentario);
                return;
            }
            ImprimirTicket(doctoBE.IID);
            MessageBox.Show("El retiro se ha ingresado con exito");
            this.Close();


        }



        public void ImprimirTicket(long doctoId)
        {

             Ticket ticket = new Ticket();
             //decimal dVentasNetas;

             this.rETIROSTableAdapter.Fill(this.dSSalidas.RETIROS, doctoId);

             if (this.dSSalidas.RETIROS.Rows.Count < 1)
             {
                 return;
             }

             long lTipoDoctoId = long.Parse(this.dSSalidas.RETIROS.Rows[0]["TIPODOCTOID"].ToString());

             ticket.AddHeaderLine("" + this.dSSalidas.RETIROS.Rows[0]["TIPODOCTOCLAVE"].ToString());
             ticket.AddHeaderLine("Sucursal        : " + this.dSSalidas.RETIROS.Rows[0]["SUCURSAL"].ToString());
             ticket.AddHeaderLine("Fecha           : " + ((DateTime)this.dSSalidas.RETIROS.Rows[0]["FECHA"]).ToString("dd/MM/yyyy"));
             ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
             ticket.AddHeaderLine("Usuario         : " + this.dSSalidas.RETIROS.Rows[0]["USUARIONOMBRE"].ToString());

             if (lTipoDoctoId == DBValues._DOCTO_TIPO_RETIRO_PAGOPROVEEDOR)
             {
                 ticket.AddHeaderLine("Proveedor       : " + this.dSSalidas.RETIROS.Rows[0]["DESTINATARIO"].ToString());
                 ticket.AddHeaderLine("Factura         : " + this.dSSalidas.RETIROS.Rows[0]["FACTURA"].ToString());
                 ticket.AddHeaderLine("Fecha factura   : " + ((DateTime)this.dSSalidas.RETIROS.Rows[0]["FECHAFACTURA"]).ToString("dd/MM/yyyy"));
                 ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                 ticket.AddHeaderLine("");
                 if (this.dSSalidas.RETIROS.Rows[0]["NOTAS"].ToString().Trim().Length > 0)
                 {
                     ticket.AddHeaderLine("Nota             ");
                     ticket.AddHeaderLine(this.dSSalidas.RETIROS.Rows[0]["NOTAS"].ToString());
                     ticket.AddHeaderLine("");
                 }
                 ticket.AddHeaderLine(formatTotalLine("Monto: ", decimal.Parse(this.dSSalidas.RETIROS.Rows[0]["TOTAL"].ToString()).ToString("N2")));

                 ticket.AddHeaderLine(new string('-', Ticket.maxChar));
             }
             else if (lTipoDoctoId == DBValues._DOCTO_TIPO_RETIRO_SUPERVISOR)
             {

                 ticket.AddHeaderLine("Supervisor      : " + this.dSSalidas.RETIROS.Rows[0]["DESTINATARIOUSUARIO"].ToString());
                 ticket.AddHeaderLine("                : " + this.dSSalidas.RETIROS.Rows[0]["DESTINATARIO"].ToString());
                 ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                 ticket.AddHeaderLine("");
                 if (this.dSSalidas.RETIROS.Rows[0]["NOTAS"].ToString().Trim().Length > 0)
                 {
                     ticket.AddHeaderLine("Nota             ");
                     ticket.AddHeaderLine(this.dSSalidas.RETIROS.Rows[0]["NOTAS"].ToString());
                     ticket.AddHeaderLine("");
                 }
                 ticket.AddHeaderLine(formatTotalLine("Monto: ", decimal.Parse(this.dSSalidas.RETIROS.Rows[0]["TOTAL"].ToString()).ToString("N2")));
                 ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");

                 ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                 ticket.AddHeaderLine("                 FIRMA                  ");

             }
             else{
                 MessageBox.Show("El registro no es retiro");
                 return;
             }






             ticket.AddFooterLine("");

             if (m_printer != "")
             {
                 ticket.PrintTicketDirect(this.m_printer);
                 MessageBox.Show("El ticket se imprimio");
             }
             

        }

        private string formatTotalLine(string name, string total)
        {

            string line = Ticket.FormatPrintField(name, 28, 0);
            line += Ticket.FormatPrintField(total, 11, 0);
            line = AlignRightText(line.Length) + line;
            return line;
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = 39 - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            //CorteAbrir corteForm;
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {

                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;


        }



    }
}
