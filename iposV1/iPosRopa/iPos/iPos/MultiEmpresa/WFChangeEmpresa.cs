using ConexionesBD;
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
    public partial class WFChangeEmpresa : Form
    {
        public string selectedCompany;
        public bool changed = false;
        public WFChangeEmpresa()
        {
            InitializeComponent();
        }

        private void WFChangeEmpresa_Load(object sender, EventArgs e)
        {
            

            /**winforms only starts**/
            cmbChangeCompany.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_EMPRESAS, ConexionMEBD.ConexionString());
            /**winforms only ends**/
            /**wpf only starts*
            cmbChangeCompany.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_EMPRESAS, ConexionMEBD.ConexionString()).DefaultView;
            /**wpf only ends**/

            cmbChangeCompany.DisplayMember = "EM_NOMBRE";
        }

        private void btnChangeCompany_Click(object sender, EventArgs e)
        {
            selectedCompany = cmbChangeCompany.Text;
            changed = true;
            this.Close();
        }

        private void WFChangeEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
           // Application.Exit();
        }
    }
}
