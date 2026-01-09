using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFDefineLote : IposForm
    {
        public string m_lote = "";
        public DateTime m_fechaVence = DateTime.Today;
        public string m_descripcionProducto = "";
       
        public WFDefineLote()
        {
            InitializeComponent();
        }

        private void WFDefineLote_Load(object sender, EventArgs e)
        {
            lblNombreProducto.Text = m_descripcionProducto;
        }

        private void BTAsignar_Click(object sender, EventArgs e)
        {
            if(DTP.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser menor o igual a la fecha actual!.");
                return;
            }
            if (TBLote.Text.Trim().Equals(""))
            {
                return;
                /*if (MessageBox.Show("El lote esta vacio. Desea dejarlo asi?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }*/
            }

            //validar que al fecha de lote no sea menor que x cantidad de dias a partir de hoy dependidno del campo nuevo de parametro

            CPARAMETROD parametroDao = new CPARAMETROD();

            int caducidadMinima = CurrentUserID.CurrentParameters.ICADUCIDADMINIMA;

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            if ((DTP.Value - DateTime.Now).Days >= caducidadMinima || (DTP.Value - DateTime.Now).Days < caducidadMinima && usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RECIBIR_PRODUCTOS_MENOR_CADUCIDADMINIMA, null))
            {
                m_lote = TBLote.Text;
                m_fechaVence = DTP.Value;
                this.Close();
            }
            else
            {
                MessageBox.Show("La fecha de caducidad del lote no cumple con el criterio de caducidad mínima, ingrese con usuario con el derecho necesario");
                WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                ps2.m_requiereAdminOrSupervisor = false;
                ps2.ShowDialog();
                CPERSONABE userBE = ps2.m_userBE;
                bool bPassValido = ps2.m_bPassValido;
                bool bIsSupervisor = ps2.m_bIsSupervisor;
                bool bIsAdministrador = ps2.m_bIsAdministrador;
                ps2.Dispose();
                GC.SuppressFinalize(ps2);

                if (!bPassValido || userBE == null)
                {

                   
                    return;
                }

                if (!usuariosD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_RECIBIR_PRODUCTOS_MENOR_CADUCIDADMINIMA, null))
                {
                    MessageBox.Show("El usuario ingresado no tiene tampoco el derecho de ");
                    return;
                }

                m_lote = TBLote.Text;
                m_fechaVence = DTP.Value;
                this.Close();
                
            }
        }

    }
}
