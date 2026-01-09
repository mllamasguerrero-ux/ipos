using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;
using iPosReporting;

namespace iPos.Guia
{
    public partial class WFGuiaPopUp : Form
    {

        public CGUIABE m_guiaBE = null;
        
        public long guiaId = 0;

        public WFGuiaPopUp()
        {
            InitializeComponent();
            m_guiaBE = new CGUIABE();
        }

        
        
        
        
        
        private void WFGuiaPopUp_Load(object sender, EventArgs e)
        {
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            

        }



        private bool obtenerDatosGuia()
        {
            if (m_guiaBE == null)
            {
                m_guiaBE = new CGUIABE();
            }

            if (this.ENCARGADOIDTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Seleccione un encargado valido");
                return false;
            }


            m_guiaBE.ICAJEROID = CurrentUserID.CurrentUser.IID;
            m_guiaBE.IENCARGADOGUIAID = Int64.Parse(this.ENCARGADOIDTextBox.DbValue.ToString());


            if (this.VEHICULOIDTextBox.Text != "")
            {
                m_guiaBE.IVEHICULOID = Int64.Parse(this.VEHICULOIDTextBox.DbValue.ToString());
            }
            else
            {

                MessageBox.Show("Seleccione un vehiculo");
                return false;
            }

            m_guiaBE.IFECHA = FECHAHORATextBox.Value;
            m_guiaBE.IFECHAHORA = FECHAHORATextBox.Value;
            m_guiaBE.IFECHAESTIMADAREC = HORAESTIMADRECTextBox.Value;
            m_guiaBE.IHORAESTIMADREC = HORAESTIMADRECTextBox.Value;

            if ((HORAESTIMADRECTextBox.Value - FECHAHORATextBox.Value).TotalMinutes <= 0)
            {

                if (MessageBox.Show("La fecha/hora de salida es la misma que la fecha/hora de llegada, o la fecha de llegada es menor que la de salida. Desea continuar?",
                                    "Advertencia",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if(obtenerDatosGuia())
            {
                this.Close();
            }
            else
            {
                m_guiaBE = null;
            }
        }

    }
}
