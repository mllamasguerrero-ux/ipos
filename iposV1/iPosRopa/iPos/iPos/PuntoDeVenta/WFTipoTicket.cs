
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;

namespace iPos
{
    public partial class WFTipoTicket : IposForm
    {
        public WFTipoTicket()
        {
            InitializeComponent();
        }

        private void WFTipoTicket_Load(object sender, EventArgs e)
        {

            LlenarDatosDeBase();
        }

        private void LlenarDatosDeBase()
        {

            CPERSONABE USUARIOSBE = new CPERSONABE();
            CPERSONAD USUARIOSD = new CPERSONAD();
            USUARIOSBE.IID = CurrentUserID.CurrentUser.IID;
            USUARIOSBE = USUARIOSD.seleccionarPERSONA(USUARIOSBE, null);
            if (USUARIOSBE == null)
            {
                MessageBox.Show("El usuario no existe");
                return;
            }

            this.TICKETLARGOTextBox.Checked = (USUARIOSBE.ITICKETLARGO == "S") ? true : false;
            this.TICKETLARGOCOTIZACIONTextBox.Checked = (USUARIOSBE.ITICKETLARGOCOTIZACION == "S") ? true : false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CPERSONABE USUARIOSBE = new CPERSONABE();
            CPERSONAD USUARIOSD = new CPERSONAD();
            USUARIOSBE.IID = CurrentUserID.CurrentUser.IID;
            USUARIOSBE = USUARIOSD.seleccionarPERSONA(USUARIOSBE, null);
            if (USUARIOSBE == null)
            {
                MessageBox.Show("El usuario no existe");
                return;
            }

            USUARIOSBE.ITICKETLARGO = (this.TICKETLARGOTextBox.Checked) ? "S" : "N";
            USUARIOSBE.ITICKETLARGOCOTIZACION = (this.TICKETLARGOCOTIZACIONTextBox.Checked) ? "S" : "N";

            USUARIOSD.CambiarPERSONATIPOTICKET(USUARIOSBE, USUARIOSBE, null);
            if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
            {

                MessageBox.Show("El registro se ha cambiado");
                this.Close();
            }
            else
            {
                MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                return;
            }
        }
    }
}
