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
using FlatTabControl;
using iPosReporting;

namespace iPos
{
    public partial class WFClienteEntrega : IposForm
    {

        public long m_personaApartadoId = 0;
        public bool m_bAplicar = false;

        public WFClienteEntrega()
        {
            InitializeComponent();
        }

        public WFClienteEntrega(long personaApartadoId): this()
        {
            m_personaApartadoId = personaApartadoId;
        }


        private void LlenarDatos()
        {

            CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
            CPERSONAAPARTADOBE personaApartadoBE = new CPERSONAAPARTADOBE();

            personaApartadoBE.IID = m_personaApartadoId;

            personaApartadoBE = personaApartadoD.seleccionarPERSONAAPARTADO(personaApartadoBE, null);

            if (!(bool)personaApartadoBE.isnull["INOMBRES"])
            {
                this.NOMBRESTextBox.Text = personaApartadoBE.INOMBRES.ToString();
            }
            else
            {
                this.NOMBRESTextBox.Text = "";
            }


            if (!(bool)personaApartadoBE.isnull["IDOMICILIO"])
            {
                this.DOMICILIOTextBox.Text = personaApartadoBE.IDOMICILIO.ToString();
            }
            else
            {
                this.DOMICILIOTextBox.Text = "";
            }

            if (!(bool)personaApartadoBE.isnull["ICIUDAD"])
            {
                this.CIUDADTextBox.Text = personaApartadoBE.ICIUDAD.ToString();
            }
            else
            {
                this.CIUDADTextBox.Text = "";
            }


            if (!(bool)personaApartadoBE.isnull["ITELEFONO1"])
            {
                this.TELEFONO1TextBox.Text = personaApartadoBE.ITELEFONO1.ToString();
            }
            else
            {
                this.TELEFONO1TextBox.Text = "";
            }

            if (!(bool)personaApartadoBE.isnull["ICELULAR"])
            {
                this.CELULARTextBox.Text = personaApartadoBE.ICELULAR.ToString();
            }
            else
            {
                this.CELULARTextBox.Text = "";
            }

            if (!(bool)personaApartadoBE.isnull["IEMAIL1"])
            {
                this.EMAIL1TextBox.Text = personaApartadoBE.IEMAIL1.ToString();
            }
            else
            {
                this.EMAIL1TextBox.Text = "";
            }

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            iPos.Catalogos.WFClientesApartado look = new iPos.Catalogos.WFClientesApartado();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            /*CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
            CPERSONAAPARTADOBE personaApartadoBE = new CPERSONAAPARTADOBE();*/

            if (dr != null)
            {
                //pnlEdicionCliente.Enabled = false;

                m_personaApartadoId = (long)dr["ID"];


                /*personaApartadoBE.IID = m_personaApartadoId;

                personaApartadoBE = personaApartadoD.seleccionarPERSONAAPARTADO(personaApartadoBE, null);

                if (!(bool)personaApartadoBE.isnull["INOMBRES"])
                {
                    this.NOMBRESTextBox.Text = personaApartadoBE.INOMBRES.ToString();
                }
                else
                {
                    this.NOMBRESTextBox.Text = "";
                }


                if (!(bool)personaApartadoBE.isnull["IDOMICILIO"])
                {
                    this.DOMICILIOTextBox.Text = personaApartadoBE.IDOMICILIO.ToString();
                }
                else
                {
                    this.DOMICILIOTextBox.Text = "";
                }

                if (!(bool)personaApartadoBE.isnull["ICIUDAD"])
                {
                    this.CIUDADTextBox.Text = personaApartadoBE.ICIUDAD.ToString();
                }
                else
                {
                    this.CIUDADTextBox.Text = "";
                }


                if (!(bool)personaApartadoBE.isnull["ITELEFONO1"])
                {
                    this.TELEFONO1TextBox.Text = personaApartadoBE.ITELEFONO1.ToString();
                }
                else
                {
                    this.TELEFONO1TextBox.Text = "";
                }

                if (!(bool)personaApartadoBE.isnull["ICELULAR"])
                {
                    this.CELULARTextBox.Text = personaApartadoBE.ICELULAR.ToString();
                }
                else
                {
                    this.CELULARTextBox.Text = "";
                }

                if (!(bool)personaApartadoBE.isnull["IEMAIL1"])
                {
                    this.EMAIL1TextBox.Text = personaApartadoBE.IEMAIL1.ToString();
                }
                else
                {
                    this.EMAIL1TextBox.Text = "";
                }

                */
                LlenarDatos();


            }
        }

        private void BTNNuevo_Click(object sender, EventArgs e)
        {
            //this.pnlEdicionCliente.Enabled = true;
            this.NOMBRESTextBox.Text = "";
            this.DOMICILIOTextBox.Text = "";
            this.CIUDADTextBox.Text = "";
            this.TELEFONO1TextBox.Text = "";
            this.CELULARTextBox.Text = "";
            this.EMAIL1TextBox.Text = "";
            this.m_personaApartadoId = 0;

        }


        private long AgregaPersonaApartado()
        {
            CPERSONAAPARTADOBE personaBE = ObtenerDatosCapturados();
            CPERSONAAPARTADOD personaD = new CPERSONAAPARTADOD();


          

            CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
            personaBE = personaApartadoD.AgregarPERSONAAPARTADOD(personaBE, null);

            if (personaBE == null)
            {
                return 0;
            }
            else
            {
                return personaBE.IID;
            }

        }



        private CPERSONAAPARTADOBE ObtenerDatosCapturados()
        {

            CPERSONAAPARTADOBE personaBE = new CPERSONAAPARTADOBE();

            personaBE.IID = m_personaApartadoId;

            if (this.NOMBRESTextBox.Text != "")
            {
                personaBE.INOMBRES = this.NOMBRESTextBox.Text.ToString();
            }

            if (this.DOMICILIOTextBox.Text != "")
            {
                personaBE.IDOMICILIO = this.DOMICILIOTextBox.Text.ToString();
            }

            if (this.CIUDADTextBox.Text != "")
            {
                personaBE.ICIUDAD = this.CIUDADTextBox.Text.ToString();
            }

            if (this.TELEFONO1TextBox.Text != "")
            {
                personaBE.ITELEFONO1 = this.TELEFONO1TextBox.Text.ToString();
            }

            if (this.CELULARTextBox.Text != "")
            {
                personaBE.ICELULAR = this.CELULARTextBox.Text.ToString();
            }

            if (this.EMAIL1TextBox.Text != "")
            {
                personaBE.IEMAIL1 = this.EMAIL1TextBox.Text.ToString();
            }


            return personaBE;
        }
        private bool CambiarPersonaApartado()
        {
            CPERSONAAPARTADOBE personaBE = ObtenerDatosCapturados();
            CPERSONAAPARTADOD personaD = new CPERSONAAPARTADOD();


           
            CPERSONAAPARTADOD personaApartadoD = new CPERSONAAPARTADOD();
            bool bRes = personaApartadoD.CambiarPERSONAAPARTADOD(personaBE, personaBE, null);

            if (!bRes)
            {
                MessageBox.Show("Ocurrio un error " +  personaApartadoD.IComentario);
            }

            return bRes;

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

            if (m_personaApartadoId == 0)
            {


                m_personaApartadoId = AgregaPersonaApartado();
                if (m_personaApartadoId == 0)
                {
                    return;
                }

            }
            else
            {
                if (!CambiarPersonaApartado())
                    return;

            }

            m_bAplicar = true;
            this.Close();

        }

        private void WFClienteEntrega_Load(object sender, EventArgs e)
        {
            if(m_personaApartadoId != 0)
            {
                LlenarDatos();
            }
        }



    }
}
