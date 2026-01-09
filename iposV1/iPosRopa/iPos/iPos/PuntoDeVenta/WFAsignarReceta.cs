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
    public partial class WFAsignarReceta : IposForm
    {
        long m_ventaId;
        public bool m_receta_asignada = false;

        public WFAsignarReceta()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        public WFAsignarReceta(long ventaId):this()
        {
            m_ventaId = ventaId;
        }



        private void SeleccionarProducto(string strDescripcion)
        {

            iPos.Catalogos.WFMedicos look;
            if (strDescripcion == "")
                look = new iPos.Catalogos.WFMedicos(strDescripcion);
            else
                look = new iPos.Catalogos.WFMedicos(strDescripcion);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                CEDULATextBox.Text = dr["CEDULA"] != DBNull.Value ?  dr["CEDULA"].ToString().Trim() : "";
                NOMBRETextBox.Text = dr["NOMBRE"] != DBNull.Value ? dr["NOMBRE"].ToString().Trim() : "";
                MEDICOPROPIOTextBox.Checked = dr["MEDICOPROPIO"] != DBNull.Value ? dr["MEDICOPROPIO"].ToString().Trim().Equals("S") : false;

                CEDULATextBox.Focus();
                CEDULATextBox.Select(CEDULATextBox.Text.Length, 0);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarProducto(CEDULATextBox.Text);
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if(CEDULATextBox.Text.Trim().Length == 0 ||
               NOMBRETextBox.Text.Trim().Length == 0 ||
               RECETANUMEROTextBox.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Necesita llenar los campos de cedula, nombre y numero de receta");
                return;
            }


            long medicoId = AgregaMedico();
            if (medicoId != 0)
            {
                CRECETABE recetaBE = new CRECETABE();
                CRECETAD recetaD = new CRECETAD();

                if (this.NOMBRETextBox.Text != "")
                {
                    recetaBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
                }

                if (this.CEDULATextBox.Text != "")
                {
                    recetaBE.ICEDULA = this.CEDULATextBox.Text.ToString();
                }

                if (this.RECETANUMEROTextBox.Text != "")
                {
                    recetaBE.IRECETANUMERO = this.RECETANUMEROTextBox.Text.ToString();
                }

                recetaBE.IMEDICOID = medicoId;

                recetaBE.IVENTAID = m_ventaId;

                recetaBE.IRETENIDA = this.RECETARETENIDATextBox.Checked ? "S" : "N";

                recetaBE = recetaD.AgregarRECETAD(recetaBE, null);

                if (recetaBE != null)
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = m_ventaId;
                    doctoBE.IMANEJORECETA = "S";
                    if (!doctoD.CAMBIARMANEJORECETA(doctoBE, null))
                    {

                        MessageBox.Show("Hubo un error al cambiar el documento " + doctoD.IComentario);
                        return;
                    }

                    m_receta_asignada = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error al cambiar la receta " + recetaD.IComentario);
                    return;
                }

            }

        }


        private long AgregaMedico()
        {
            CMEDICOBE personaBE = new CMEDICOBE();
            CMEDICOD personaD = new CMEDICOD();


            if (this.NOMBRETextBox.Text != "")
            {
                personaBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }

            if (this.CEDULATextBox.Text != "")
            {
                personaBE.ICEDULA = this.CEDULATextBox.Text.ToString();
            }

            personaBE.IMEDICOPROPIO = this.MEDICOPROPIOTextBox.Checked ? "S" : "N";

            personaBE = personaD.AgregarMEDICOV2(personaBE, null);

            if (personaBE == null)
            {
                MessageBox.Show("Hubo un error al agregar el medico " + personaD.IComentario);
                return 0;
            }
            else
            {
                return personaBE.IID;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_ventaId;
            doctoBE.IMANEJORECETA = "R";
            if (!doctoD.CAMBIARMANEJORECETA(doctoBE, null))
            {

                MessageBox.Show("Hubo un error al cambiar el documento " + doctoD.IComentario);
               
            }

            this.Close();
        }

    }




}
