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
    public partial class WFDefineLoteImportado : IposForm
    {
        public string m_descripcionProducto = "";


        public CLOTESIMPORTADOSBE loteImportado = null;


        
       
        public WFDefineLoteImportado()
        {
            InitializeComponent();
            
        }

        private void WFDefineLoteImportado_Load(object sender, EventArgs e)
        {
            lblNombreProducto.Text = m_descripcionProducto;
        }

        private void BTAsignar_Click(object sender, EventArgs e)
        {

            if (TBLote.Text.Trim().Equals("") || aduanaTextBoxFb.Text.Trim().Equals("") || this.TBTipoCambio.Text == "")
            {
                return;
                /*if (MessageBox.Show("El lote esta vacio. Desea dejarlo asi?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }*/
            }

            loteImportado = new CLOTESIMPORTADOSBE();
            loteImportado.IPEDIMENTO = TBLote.Text;
            loteImportado.IFECHAIMPORTACION = DTP.Value;
            loteImportado.ISATADUANAID = long.Parse(aduanaTextBoxFb.DbValue);

            loteImportado.IADUANA = aduanaTextBoxFb.Text.Trim() + " " + aduanaLabel.Text;
             
                
            if (this.TBTipoCambio.Text != "")
            {
                loteImportado.ITIPOCAMBIO = decimal.Parse(this.TBTipoCambio.Text.ToString());
            }
            else
            {
                loteImportado.ITIPOCAMBIO = 1;
            }

            CLOTESIMPORTADOSD loteImportadoD = new CLOTESIMPORTADOSD();
            CLOTESIMPORTADOSBE loteExistente = loteImportadoD.seleccionarLOTESIMPORTADOSXDATOS(loteImportado, null);

            if(loteExistente != null)
            {

                loteImportado = loteExistente;
                this.Close();
            }
            else
            {
                loteImportado = loteImportadoD.AgregarLOTESIMPORTADOSD(loteImportado, null);
                if(loteImportado != null)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el pedimento");
                    
                }
            }
        }

        private void aduanaButton_Click(object sender, EventArgs e)
        {

        }

    }
}
