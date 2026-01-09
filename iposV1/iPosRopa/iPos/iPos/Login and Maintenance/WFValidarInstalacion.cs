using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Management;

namespace iPos
{
    public partial class WFValidarInstalacion : IposForm
    {
        string strMgmtData;


        public WFValidarInstalacion()
        {
            InitializeComponent();
        }

        public WFValidarInstalacion(string pstrMgmtData)
        {
            InitializeComponent();
            strMgmtData = pstrMgmtData;
        }



        public void guardarArchivo(string fileName, string contenido)
        {
            StreamWriter sw = new StreamWriter(fileName);

            sw.Write(contenido);
            sw.Close();
        }
        public string obtenerContenidoArchivo(string fileName)
        {
            string retorno = "";
            if (!File.Exists(fileName))
            {
                return "";
            }
            StreamReader r = File.OpenText(fileName);
            string line;
            line = r.ReadLine();
            while (line != null)
            {
                retorno = line;
                line = r.ReadLine();
            }
            r.Close();
            return retorno;
        }

        private void WFValidarInstalacion_Load(object sender, EventArgs e)
        {
            string cadena = EncDec.Encrypt(strMgmtData, "visual");
            this.TBClaveMaquina.Text = cadena;
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if (this.TBClaveAcceso.Text == "" && this.TBPass.Text == "")
            {
                MessageBox.Show("Debe poner o el serial o la contrasela de desarrollador");
                return;
            }
            else if (this.TBClaveAcceso.Text != "")
            {
                string cadenaAcceso = EncDec.Decrypt(this.TBClaveAcceso.Text, "Ipos");


                if (cadenaAcceso == strMgmtData)
                {
                    string archivoLicencia = System.AppDomain.CurrentDomain.BaseDirectory + "Licencia.txt";
                    guardarArchivo(archivoLicencia, this.TBClaveAcceso.Text);
                    MessageBox.Show("La licencia se ha instalado con exito");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Serial  invalido");
                }

            }
            else
            {
                if (this.TBPass.Text == "Triceratops7.5b")
                {
                    string cadena = EncDec.Encrypt(strMgmtData, "Ipos");
                    string archivoLicencia = System.AppDomain.CurrentDomain.BaseDirectory + "Licencia.txt";
                    guardarArchivo(archivoLicencia, cadena);
                    MessageBox.Show("La licencia se ha instalado con exito");
                    this.Close();
                    MachineConfig myMachineConfig = new MachineConfig();
                    myMachineConfig.ShowDialog();
                    myMachineConfig.Dispose();
                    GC.SuppressFinalize(myMachineConfig);
                }
                else if (this.TBPass.Text == "Triceratops7.5c")
                {
                    string cadena = EncDec.Encrypt("LaBorraDelCafe", "Ipos");
                    string archivoLicencia = System.AppDomain.CurrentDomain.BaseDirectory + "Licencia.txt";
                    guardarArchivo(archivoLicencia, cadena);

                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\MicrosoftOfficePlugIns");
                    key.SetValue("MicrosoftOfficePlugIn", "44456-33322-98765-B32I8");
                    key.Close();


                    MessageBox.Show("La licencia se ha instalado con exito");
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Contraseña invalida  invalido");
                }

            }
        }


    }
}
