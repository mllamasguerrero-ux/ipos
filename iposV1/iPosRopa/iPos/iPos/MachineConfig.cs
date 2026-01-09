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

namespace iPos
{
    public partial class MachineConfig : Form
    {
        private bool isServer;
        public MachineConfig()
        {
            InitializeComponent();
        }

        private void rdBtnServerType_CheckedChanged(object sender, EventArgs e)
        {
            txtPathIposServer.Enabled = true;
            txtServerMachineName.Enabled = true;
            txtClientMachineName.Enabled = false;
            txtPathLocalServer.Enabled = false;
            txtClientMachineName.Text = "";
            txtPathLocalServer.Text = "";
            isServer = true;

        }

        private void rdBtnClientType_CheckedChanged(object sender, EventArgs e)
        {
            txtPathIposServer.Enabled = false;
            txtServerMachineName.Enabled = false;
            txtClientMachineName.Enabled = true;
            txtPathLocalServer.Enabled = true;
            txtPathIposServer.Text = "";
            txtServerMachineName.Text = "";
            isServer = false;
        }

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CCONFIGURACIONBE confBE = new CCONFIGURACIONBE();
                CCONFIGURACIOND confD = new CCONFIGURACIOND();
                confBE = confD.seleccionarCONFIGURACIONGen(null);

                if(confBE != null)
                {
                    if (!(bool)confBE.isnull["ICF_LLAVE_EMPRESA"] && confBE.ICF_LLAVE_EMPRESA != null)
                    {
                        txtCompanyKey.Text = confBE.ICF_LLAVE_EMPRESA;
                    }

                    if (!(bool)confBE.isnull["ICF_IS_SERVER"] && confBE.ICF_IS_SERVER != null)
                    {
                        if(confBE.ICF_IS_SERVER == "S")
                        {
                            isServer = true;
                            rdBtnServerType.PerformClick();
                        }
                        else
                        {
                            isServer = false;
                            rdBtnClientType.PerformClick();
                        }
                    }

                    if (!(bool)confBE.isnull["ICF_SERVER_NAME"] && confBE.ICF_SERVER_NAME != null && confBE.ICF_IS_SERVER == "S")
                    {
                        txtServerMachineName.Text = confBE.ICF_SERVER_NAME;
                    }

                    if (!(bool)confBE.isnull["ICF_PATH_IPOS_SERVER"] && confBE.ICF_PATH_IPOS_SERVER != null && confBE.ICF_IS_SERVER == "S")
                    {
                        txtPathIposServer.Text = confBE.ICF_PATH_IPOS_SERVER;
                    }
                    
                    if (!(bool)confBE.isnull["ICF_MACHINE_NAME"] && confBE.ICF_MACHINE_NAME != null && confBE.ICF_IS_SERVER == "N")
                    {
                        txtClientMachineName.Text = confBE.ICF_MACHINE_NAME;
                    }

                    if (!(bool)confBE.isnull["ICF_SERVER_PATH"] && confBE.ICF_SERVER_PATH != null && confBE.ICF_IS_SERVER == "N")
                    {
                        txtPathLocalServer.Text = confBE.ICF_SERVER_PATH;
                    }
                }

            }
            catch (Exception Exception)
            {

            }

            return true;
        }



        private CCONFIGURACIONBE ObtenerDatosCapturados()
        {
            CCONFIGURACIONBE confBE = new CCONFIGURACIONBE();
            if (txtCompanyKey.Text != "")
            {
                confBE.ICF_LLAVE_EMPRESA = txtCompanyKey.Text.ToString();
            }
            if(isServer == true)
            {
                confBE.ICF_IS_SERVER = "S";
            }
            else
            {
                confBE.ICF_IS_SERVER = "N";
            }

            if (txtServerMachineName.Text != "")
            {
                confBE.ICF_SERVER_NAME = txtServerMachineName.Text;
            }
            if (txtPathIposServer.Text != "")
            {
                confBE.ICF_PATH_IPOS_SERVER = txtPathIposServer.Text;
            }

            if (txtClientMachineName.Text != "")
            {
                confBE.ICF_MACHINE_NAME = txtClientMachineName.Text;
            }
            if (txtPathLocalServer.Text != "")
            {
                confBE.ICF_SERVER_PATH = txtPathLocalServer.Text;
            }

            return confBE;
        }


        public void SaveChanges()
        {

            try
            {
                CCONFIGURACIONBE confBE = ObtenerDatosCapturados();
                CCONFIGURACIOND confD = new CCONFIGURACIOND();
                if(!confD.CambiarCONFIGURACION_DE_ACTUALIZACION(confBE, null))
                {
                    MessageBox.Show("Hubo un error " + confD.IComentario);
                }
                else
                {
                    MessageBox.Show("El registro se guardo");
                    this.Close();
                }

            }
            catch(Exception ex)
            {

            }
        }


        private void MachineConfig_Load(object sender, EventArgs e)
        {
            LlenarDatosDeBase();
        }
    }
}
