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

namespace iPosReporting.VirtualXml.UIHelpers
{
    public partial class WFCartaPorteDetalles : Form
    {
        CCARTAPORTEBE m_cARTAPORTEBE = null;
        public WFCartaPorteDetalles()
        {
            InitializeComponent();
        }

        public WFCartaPorteDetalles(CCARTAPORTEBE cARTAPORTEBE):this()
        {
            m_cARTAPORTEBE = cARTAPORTEBE;
        }
        

        private void WFCartaPorteDetalles_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;

            var source = new BindingSource();
            source.DataSource = m_cARTAPORTEBE.ICARTAPORTEMERCANCIAList;
            this.dataGridView1.DataSource = source;
            

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "PRODUCTO";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = "ICLAVEPRODUCTO";
            this.dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "BIENESTRANSP";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = "IBIENESTRANSP";
           this.dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "DESCRIPCION";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = "IDESCRIPCION";
            this.dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "CANTIDAD";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = "ICANTIDAD";
            this.dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "EMBALAJE";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = "IEMBALAJE";
            this.dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "PESOENKG";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = "IPESOENKG";
            this.dataGridView1.Columns.Add(col);



            


        }
    }
}
