using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Abonos
{
    public partial class WFPagosReferencias : Form
    {
        public string referenciaBancaria;
        public int bancoId;
        public decimal importe;
        public long formaPagoId;
        public bool aceptado = false;
        public WFPagosReferencias()
        {
            InitializeComponent();
        }
        public WFPagosReferencias(string referenciaBancaria, int bancoId, decimal importe, long formaPagoId):this()
        {
            this.referenciaBancaria = referenciaBancaria;
            this.bancoId = bancoId;
            this.importe = importe;
            this.formaPagoId = formaPagoId;
        }


        private void LlenarGrid()
        {
            try
            {
                this.pAGOSPORREFERENCIATableAdapter.Fill(this.dSAbonos3.PAGOSPORREFERENCIA, referenciaBancaria, bancoId, importe, formaPagoId);

                if(this.dSAbonos3.PAGOSPORREFERENCIA.Rows.Count == 0)
                {
                    aceptado = true;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            this.aceptado = false;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Validar();
        }

        public bool Validar()
        {

            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
            ps2.ShowDialog();
            CPERSONABE userBE = ps2.m_userBE;
            ps2.Dispose();
            GC.SuppressFinalize(ps2);


            if (userBE == null || userBE.IID == 0)
            {
                return false;
            }

            bool bUsuarioValido = validarUsuarioParaAutorizar(userBE.IID);


            if (!bUsuarioValido)
            {

                string strErroresSeleccionado = "El usuario seleccionado no tiene el permiso correspondiente \n";
                MessageBox.Show(strErroresSeleccionado);
            }
            else
            {

                this.aceptado = true;
                this.Close();
            }

            return true;
            
        }


        private bool validarUsuarioParaAutorizar( long usuarioId)
        {


            //verificacion de permisos
            CUSUARIOSD usersD = new CUSUARIOSD();
            return usersD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_AUTORIZAR_REFERENCIA_REPETIDA, null);
          
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void WFPagosReferencias_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
