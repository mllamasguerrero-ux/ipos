using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using ConexionesBD;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
namespace iPos
{
    public partial class WFConfig : IposForm
    {
        public WFConfig()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source=" + TBServidor.Text.ToString() + ";Initial Catalog=" + this.TBBaseDatos.Text.ToString() + ";Persist Security Info=True;User ID=" + this.TBUsuario.Text.ToString() + ";Password=" + this.TBPassword.Text.ToString() + "";
            ChangeConnectionString(strconn);
            string archivoConn = System.AppDomain.CurrentDomain.BaseDirectory + "conexionBD.txt";
            string cipherText = EncDec.Encrypt(strconn, EncDec.PasswordDefault());
            guardarArchivo(archivoConn, cipherText);
            this.Close();
            this.Dispose();
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
                string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string connectionStr = "data source=localhost;initial catalog=\"" + dataPath + "\\sampdata\\iposdb" + "\";user id=sysdba;password=masterkey";
                return EncDec.Encrypt(connectionStr, EncDec.PasswordDefault());
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
        public void ChangeConnectionString(string strConn)
        {
            System.Configuration.Configuration _config =
             ConfigurationManager.OpenExeConfiguration(
             ConfigurationUserLevel.None);
            
            
            _config.ConnectionStrings.ConnectionStrings["iPos.Properties.Settings.ConnectionIpos"].ConnectionString = strConn;
            
            
            
            _config.Save(ConfigurationSaveMode.Modified);
            
            
            ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
            iPos.Properties.Settings.Default.Reload();
            ConexionBD.ConexionBase = strConn;
        }
        private void WFConfig_Load(object sender, EventArgs e)
        {
        }
    }
}