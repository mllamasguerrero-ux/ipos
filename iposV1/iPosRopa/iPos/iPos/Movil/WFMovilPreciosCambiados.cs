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
    public partial class WFMovilPreciosCambiados : IposForm
    {
        public List<CMPRODBE> productos = null;
        public BindingSource source = null;

        public WFMovilPreciosCambiados()
        {
            InitializeComponent();
        }

        
        public WFMovilPreciosCambiados(List<CMPRODBE> _productos):this()
        {
            productos = _productos;
            source = new BindingSource();
            source.DataSource = productos;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WFMovilPreciosCambiados_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = source;
        }

    }
}
