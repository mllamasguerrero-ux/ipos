using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.MultiEmpresa
{
    public partial class WFSyncConfig : Form
    {
        private CSINCCONFIGBE sincConfigBE;
        private CSINCCONFIGD sincConfigD;

        public WFSyncConfig()
        {
            InitializeComponent();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            ObtenerDatosCapturados();
            if(GuardarDatosEnBD())
            {
                this.Close();
            }
        }

        private void ObtenerDatosCapturados()
        {
            sincConfigBE = new CSINCCONFIGBE();

            sincConfigBE.IC_CONEXORIG = this.conexionTextBox.Text;
            //sincConfigBE.IC_FECHAULTISINC = this.ultimaSyncDateTimePicker.Value;
            sincConfigBE.IC_LIMPNOSINC = this.limpiarNoSyncCheckBox.Checked ? "S" : "N";
            sincConfigBE.IC_SINCAUTO = this.autoSyncCheckBox.Checked ? "S" : "N";
            sincConfigBE.IES_COPIA = this.copiaRadioButton.Checked ? "S" : "N";
            sincConfigBE.IHAB_SINC = this.habSyncCheckBox.Checked ? "S" : "N";
            sincConfigBE.IO_FECHACAMBIOMANUAL = this.cambioManualDeFechaCheckBox.Checked ? "S" : "N";
            //sincConfigBE.IO_ULTIFECHACAMBIO = this.ultimoCambioDateTimePicker.Value;
            sincConfigBE.IO_RUTASYSTEMDATA_ENRED = this.conexionEnRedTextBox.Text;
        }

        private bool GuardarDatosEnBD()
        {
            sincConfigD = new CSINCCONFIGD();

            if(!sincConfigD.CambiarSINCCONFIGD(sincConfigBE, sincConfigBE, null))
            {
                MessageBox.Show("Error al guardar datos de configuración: " + sincConfigD.IComentario);

                return false;
            }
            else
            {
                MessageBox.Show("Se han guardado los datos correctamente");

                return true;
            }
        }

        private void LlenarDatosDeBase()
        {
            sincConfigD = new CSINCCONFIGD();
            sincConfigBE = sincConfigD.SeleccionarSincConfigLocal(null);

            if(sincConfigBE != null)
            {
                if(!String.IsNullOrEmpty(sincConfigBE.IC_CONEXORIG))
                {
                    this.conexionTextBox.Text = sincConfigBE.IC_CONEXORIG;
                }
                if (!String.IsNullOrEmpty(sincConfigBE.IO_RUTASYSTEMDATA_ENRED))
                {
                    this.conexionEnRedTextBox.Text = sincConfigBE.IO_RUTASYSTEMDATA_ENRED;
                }


                if (!(bool)sincConfigBE.isnull["IHAB_SINC"])
                    this.habSyncCheckBox.Checked = sincConfigBE.IHAB_SINC != null && sincConfigBE.IHAB_SINC.Equals("S") ? true : false;
                else
                    this.habSyncCheckBox.Checked = false;


                if (!(bool)sincConfigBE.isnull["IO_FECHACAMBIOMANUAL"])
                     this.cambioManualDeFechaCheckBox.Checked = sincConfigBE.IO_FECHACAMBIOMANUAL.Equals("S") ? true : false;
                else
                    this.cambioManualDeFechaCheckBox.Checked = false;


                if (!(bool)sincConfigBE.isnull["IES_COPIA"])
                {
                    if (sincConfigBE.IES_COPIA.Equals("S"))
                    {
                        this.copiaRadioButton.Checked = true;
                        this.originalRadioButton.Checked = false;
                    }
                    else
                    {
                        this.originalRadioButton.Checked = true;
                        this.copiaRadioButton.Checked = false;
                    }
                }
                else
                {

                    this.originalRadioButton.Checked = true;
                    this.copiaRadioButton.Checked = false;
                }


                if (!(bool)sincConfigBE.isnull["IC_SINCAUTO"])
                {
                    this.autoSyncCheckBox.Checked = sincConfigBE.IC_SINCAUTO.Equals("S") ? true : false;
                }

                if (!(bool)sincConfigBE.isnull["IC_LIMPNOSINC"])
                {
                    this.limpiarNoSyncCheckBox.Checked = sincConfigBE.IC_LIMPNOSINC.Equals("S") ? true : false;
                }

                if (!(bool)sincConfigBE.isnull["IC_FECHAULTISINC"])
                {
                    this.ultimaSyncDateTime.Text = sincConfigBE.IC_FECHAULTISINC.ToString("dd/MM/yy HH:mm:ss");
                }


                if (!(bool)sincConfigBE.isnull["IO_ULTIFECHACAMBIO"])
                {
                    this.ultimoCambioDateTime.Text = sincConfigBE.IO_ULTIFECHACAMBIO.ToString("dd/MM/yy HH:mm:ss");
                }
            }
            else
            {
                MessageBox.Show("Problema al recuperar datos de SincConfig: " + sincConfigD.IComentario);
            }
        }

        private void WFSyncConfig_Load(object sender, EventArgs e)
        {
            LlenarDatosDeBase();
        }
    }
}
