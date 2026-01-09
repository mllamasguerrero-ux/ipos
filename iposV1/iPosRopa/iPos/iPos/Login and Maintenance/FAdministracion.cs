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
    public partial class FAdministracion : IposForm
    {
        public FAdministracion()
        {
            InitializeComponent();
        }
        private void BTUsuarios_Click(object sender, EventArgs e)
        {
            iPos.WFUsuarios uEdit = new iPos.WFUsuarios();
            uEdit.ShowDialog();
            uEdit.Dispose();
            GC.SuppressFinalize(uEdit);
        }
        private void BTPerfiles_Click(object sender, EventArgs e)
        {
            PERFILEdicion pEdicion = new PERFILEdicion();
            pEdicion.ShowDialog();
            pEdicion.Dispose();
            GC.SuppressFinalize(pEdicion);
        }
        private void BTExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FAdministracion_Load(object sender, EventArgs e)
        {

        }
    }
}
