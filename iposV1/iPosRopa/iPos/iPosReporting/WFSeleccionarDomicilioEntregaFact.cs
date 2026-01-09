using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFSeleccionarDomicilioEntregaFact : Form
    {

        public long PersonaId { get; set; }

        public string TextoParaSeleccionar { get; set; } = "Hay datos de entrega definidos para este cliente. Desea seleccionar alguno de ellos en la factura electronica?";


        public string TextoSeleccionPrevia { get; set; } = "";

        public long? DomicilioSeleccionadoId { get; set; } = null;

        public long? SeleccionPreviaId { get; set; }

        public WFSeleccionarDomicilioEntregaFact()
        {
            InitializeComponent();
        }


        public WFSeleccionarDomicilioEntregaFact(long personaId , string textoParaSeleccionar, long? seleccionPreviaId): this()
        {
            PersonaId = personaId;
            TextoParaSeleccionar = textoParaSeleccionar;
            SeleccionPreviaId = seleccionPreviaId;
            DomicilioSeleccionadoId = seleccionPreviaId;
        }

        private void LlenarTabla()
        {
            try
            {
                this.dOMICILIOSXPERSONATableAdapter.Fill(this.dSCatalogos3.DOMICILIOSXPERSONA, PersonaId, "S");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFSeleccionarDomicilioEntrega_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            this.lblMensajeSeleccion.Text = TextoParaSeleccionar;

            if(SeleccionPreviaId != null)
            {

                CDOMICILIOD domicilioD = new CDOMICILIOD();
                CDOMICILIOBE domicilioBE = new CDOMICILIOBE();
                domicilioBE.IID = SeleccionPreviaId.Value;
                domicilioBE = domicilioD.seleccionarDOMICILIO(domicilioBE, null);

                if(domicilioBE != null)
                {
                    TextoSeleccionPrevia = $"Actualmente se usaria: {domicilioBE.ICALLE ?? ""} {domicilioBE.INUMEROEXTERIOR ?? ""} {domicilioBE.INUMEROINTERIOR ?? ""} " +
                                           $" {domicilioBE.ICOLONIA ?? ""} {domicilioBE.IMUNICIPIO?? ""} {domicilioBE.IESTADO ?? ""} ";
                }
                

            }
            else
            {
                TextoSeleccionPrevia = "Actualmente se usarian los datos del cliente";
            }

            this.lblSeleccionPrevia.Text = TextoSeleccionPrevia;
        }

        private void btnUsarDatosCliente_Click(object sender, EventArgs e)
        {
            this.DomicilioSeleccionadoId = null;
            Close();
        }

        private void dOMICILIOSXPERSONADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (dOMICILIOSXPERSONADataGridView.Columns[e.ColumnIndex].Name == "BtnSeleccionar")
                {

                    var domId = long.Parse(dOMICILIOSXPERSONADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    this.DomicilioSeleccionadoId = domId;
                    Close();
                }
            }
        }
    }
}
