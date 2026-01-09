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

namespace iPos.Catalogos
{
    public partial class WFMaxFactEdicion : Form
    {
        public WFMaxFactEdicion()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void LlenarDatos()
        {
            LimpiarDatosMaximos();

            CMAXFACTD objD = new CMAXFACTD();

            string strSucursalClave = this.SUCURSALIDTextBox.DbValue.ToString();
            int anio = (int)ANIOTextBox.Value;



            if (this.SUCURSALIDTextBox.Text == "")
            {
                MessageBox.Show("se necesita seleccionar la sucursal");
                return;
            }

            List<CMAXFACTBE> list = objD.seleccionarMAXFACTxSucusalYAnio(strSucursalClave, anio, null);

            ACTIVOTextBox.Checked = true;
            //pnlMaximosDia.Enabled = true;
            ponerReadOnly(true);
            ACTIVOTextBox.Enabled = true;


            foreach (CMAXFACTBE item in list)
            {

               if(item.IACTIVO == null || !item.IACTIVO.Equals("S"))
                    ACTIVOTextBox.Checked = false;


                LlenarDatoMes( item);
            }

            this.SUCURSALIDTextBox.Enabled = false;
            this.SUCURSALIDButton.Enabled = false;
            this.ANIOTextBox.Enabled = false;


        }


        private void GuardarDatos()
        {

            string strSucursalClave = this.SUCURSALIDTextBox.DbValue.ToString();


            if (this.SUCURSALIDTextBox.Text == "" )
            {
                MessageBox.Show("se necesita seleccionar la sucursal");
                return;
            }


            List<CMAXFACTBE> listaRegistros = ObtenerDatos();
            CMAXFACTD regD = new CMAXFACTD();
            if(!regD.actualizarListaMaxFact(listaRegistros, null))
            {

                MessageBox.Show("Ocurrio un error no se pudieron guardar los registros " +  regD.IComentario);
                return;
            }
            else
            {

                MessageBox.Show("Se actualizo el registro");
                resetear();

                //this.Close();
            }

        }

        private void resetear()
        {

            this.SUCURSALIDTextBox.Enabled = true;
            this.SUCURSALIDButton.Enabled = true;
            this.ANIOTextBox.Enabled = true;

            this.SUCURSALIDTextBox.Text = "";
            this.SUCURSALIDTextBox.Focus();


            this.LimpiarDatosMaximos();


            //this.pnlMaximosDia.Enabled = false;
            ponerReadOnly(false);
        }


        private List<CMAXFACTBE> ObtenerDatos()
        {

            List<CMAXFACTBE> list = new List<CMAXFACTBE>();



            for (int mes = 1; mes <= 12; mes++)
            {
                CMAXFACTBE item = new CMAXFACTBE();
                item.ISUCURSALCLAVE = this.SUCURSALIDTextBox.DbValue.ToString();
                item.IANIO = (int)ANIOTextBox.Value;
                item.IACTIVO = ACTIVOTextBox.Checked ? "S" : "N";
                item.IMES = mes;

                TextBox tb = new TextBox();
                CheckBox cb = new CheckBox();



                obtenerControlMesDia(item.IMES, 1, ref cb, ref tb);
                item.ILUN_MAX = decimal.Parse(tb.Text.ToString());
                item.ILUN_HAY = cb.Checked ? "S" : "N";

                obtenerControlMesDia(item.IMES, 2, ref cb, ref tb);
                item.IMAR_MAX = decimal.Parse(tb.Text.ToString());
                item.IMAR_HAY = cb.Checked ? "S" : "N";

                obtenerControlMesDia(item.IMES, 3, ref cb, ref tb);
                item.IMIE_MAX = decimal.Parse(tb.Text.ToString());
                item.IMIE_HAY = cb.Checked ? "S" : "N";

                obtenerControlMesDia(item.IMES, 4, ref cb, ref tb);
                item.IJUE_MAX = decimal.Parse(tb.Text.ToString());
                item.IJUE_HAY = cb.Checked ? "S" : "N";

                obtenerControlMesDia(item.IMES, 5, ref cb, ref tb);
                item.IVIE_MAX = decimal.Parse(tb.Text.ToString());
                item.IVIE_HAY = cb.Checked ? "S" : "N";

                obtenerControlMesDia(item.IMES, 6, ref cb, ref tb);
                item.ISAB_MAX = decimal.Parse(tb.Text.ToString());
                item.ISAB_HAY = cb.Checked ? "S" : "N";

                obtenerControlMesDia(item.IMES, 7, ref cb, ref tb);
                item.IDOM_MAX = decimal.Parse(tb.Text.ToString());
                item.IDOM_HAY = cb.Checked ? "S" : "N";

                list.Add(item);


            }


            return list;
                


        }

        private void LlenarDatoMes(CMAXFACTBE item)
        {

            TextBox tb = new TextBox();
            CheckBox cb = new CheckBox();

            obtenerControlMesDia(item.IMES, 1, ref cb, ref tb);
            tb.Text = item.ILUN_MAX.ToString("###0.00");
            cb.Checked = item.ILUN_HAY != null && item.ILUN_HAY.ToString().Equals("S");

            obtenerControlMesDia(item.IMES, 2, ref cb, ref tb);
            tb.Text = item.IMAR_MAX.ToString("###0.00");
            cb.Checked = item.IMAR_HAY != null && item.IMAR_HAY.ToString().Equals("S");

            obtenerControlMesDia(item.IMES, 3, ref cb, ref tb);
            tb.Text = item.IMIE_MAX.ToString("###0.00");
            cb.Checked = item.IMIE_HAY != null && item.IMIE_HAY.ToString().Equals("S");

            obtenerControlMesDia(item.IMES, 4, ref cb, ref tb);
            tb.Text = item.IJUE_MAX.ToString("###0.00");
            cb.Checked = item.IJUE_HAY != null && item.IJUE_HAY.ToString().Equals("S");

            obtenerControlMesDia(item.IMES, 5, ref cb, ref tb);
            tb.Text = item.IVIE_MAX.ToString("###0.00");
            cb.Checked = item.IVIE_HAY != null && item.IVIE_HAY.ToString().Equals("S");

            obtenerControlMesDia(item.IMES, 6, ref cb, ref tb);
            tb.Text = item.ISAB_MAX.ToString("###0.00");
            cb.Checked = item.ISAB_HAY != null && item.ISAB_HAY.ToString().Equals("S");

            obtenerControlMesDia(item.IMES, 7, ref cb, ref tb);
            tb.Text = item.IDOM_MAX.ToString("###0.00");
            cb.Checked = item.IDOM_HAY != null && item.IDOM_HAY.ToString().Equals("S");


        }

        private void LimpiarDatosMaximos()
        {
            for(int mes = 1; mes <= 12; mes++)
            {
                for(int dia = 1; dia <= 7; dia++)
                {
                    TextBox tb = new TextBox();
                    CheckBox cb = new CheckBox();
                    obtenerControlMesDia(mes, dia, ref cb, ref tb);
                    tb.Text = "0";
                    cb.Checked = false;
                }
            }
        }



        private void ponerReadOnly(bool bReadOnly)
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                for (int dia = 1; dia <= 7; dia++)
                {
                    TextBox tb = new TextBox();
                    CheckBox cb = new CheckBox();
                    obtenerControlMesDia(mes, dia, ref cb, ref tb);
                    tb.Enabled = bReadOnly;
                    cb.Enabled = bReadOnly;
                }
            }
        }


        private void obtenerControlMesDia(int mes, int dia, ref CheckBox checkBox, ref TextBox textBox)
        {
            //string strMes = mes.ToString();
            //string strDia = "";
            switch(dia)
            {
                case 1:
                    switch(mes)
                    {
                        case 1: textBox = LUNESMES1TextBox; checkBox = CBLUNESMES1HAY;  break;
                        case 2: textBox = LUNESMES2TextBox; checkBox = CBLUNESMES2HAY; break;
                        case 3: textBox = LUNESMES3TextBox; checkBox = CBLUNESMES3HAY; break;
                        case 4: textBox = LUNESMES4TextBox; checkBox = CBLUNESMES4HAY; break;
                        case 5: textBox = LUNESMES5TextBox; checkBox = CBLUNESMES5HAY; break;
                        case 6: textBox = LUNESMES6TextBox; checkBox = CBLUNESMES6HAY; break;
                        case 7: textBox = LUNESMES7TextBox; checkBox = CBLUNESMES7HAY; break;
                        case 8: textBox = LUNESMES8TextBox; checkBox = CBLUNESMES8HAY; break;
                        case 9: textBox = LUNESMES9TextBox; checkBox = CBLUNESMES9HAY; break;
                        case 10: textBox = LUNESMES10TextBox; checkBox = CBLUNESMES10HAY; break;
                        case 11: textBox = LUNESMES11TextBox; checkBox = CBLUNESMES11HAY; break;
                        case 12: textBox = LUNESMES12TextBox; checkBox = CBLUNESMES12HAY; break;
                        default: textBox = LUNESMES1TextBox; checkBox = CBLUNESMES1HAY; break;
                    }
                    break;

                case 2:
                    switch (mes)
                    {
                        case 1: textBox = MARTESMES1TextBox; checkBox = CBMARTESMES1HAY; break;
                        case 2: textBox = MARTESMES2TextBox; checkBox = CBMARTESMES2HAY; break;
                        case 3: textBox = MARTESMES3TextBox; checkBox = CBMARTESMES3HAY; break;
                        case 4: textBox = MARTESMES4TextBox; checkBox = CBMARTESMES4HAY; break;
                        case 5: textBox = MARTESMES5TextBox; checkBox = CBMARTESMES5HAY; break;
                        case 6: textBox = MARTESMES6TextBox; checkBox = CBMARTESMES6HAY; break;
                        case 7: textBox = MARTESMES7TextBox; checkBox = CBMARTESMES7HAY; break;
                        case 8: textBox = MARTESMES8TextBox; checkBox = CBMARTESMES8HAY; break;
                        case 9: textBox = MARTESMES9TextBox; checkBox = CBMARTESMES9HAY; break;
                        case 10: textBox = MARTESMES10TextBox; checkBox = CBMARTESMES10HAY; break;
                        case 11: textBox = MARTESMES11TextBox; checkBox = CBMARTESMES11HAY; break;
                        case 12: textBox = MARTESMES12TextBox; checkBox = CBMARTESMES12HAY; break;
                        default: textBox = MARTESMES1TextBox; checkBox = CBMARTESMES1HAY; break;
                    }
                    break;

                case 3:
                    switch (mes)
                    {
                        case 1: textBox = MIERCOLESMES1TextBox; checkBox = CBMIERCOLESMES1HAY; break;
                        case 2: textBox = MIERCOLESMES2TextBox; checkBox = CBMIERCOLESMES2HAY; break;
                        case 3: textBox = MIERCOLESMES3TextBox; checkBox = CBMIERCOLESMES3HAY; break;
                        case 4: textBox = MIERCOLESMES4TextBox; checkBox = CBMIERCOLESMES4HAY; break;
                        case 5: textBox = MIERCOLESMES5TextBox; checkBox = CBMIERCOLESMES5HAY; break;
                        case 6: textBox = MIERCOLESMES6TextBox; checkBox = CBMIERCOLESMES6HAY; break;
                        case 7: textBox = MIERCOLESMES7TextBox; checkBox = CBMIERCOLESMES7HAY; break;
                        case 8: textBox = MIERCOLESMES8TextBox; checkBox = CBMIERCOLESMES8HAY; break;
                        case 9: textBox = MIERCOLESMES9TextBox; checkBox = CBMIERCOLESMES9HAY; break;
                        case 10: textBox = MIERCOLESMES10TextBox; checkBox = CBMIERCOLESMES10HAY; break;
                        case 11: textBox = MIERCOLESMES11TextBox; checkBox = CBMIERCOLESMES11HAY; break;
                        case 12: textBox = MIERCOLESMES12TextBox; checkBox = CBMIERCOLESMES12HAY; break;
                        default: textBox = MIERCOLESMES1TextBox; checkBox = CBMIERCOLESMES1HAY; break;
                    }
                    break;

                case 4:
                    switch (mes)
                    {
                        case 1: textBox = JUEVESMES1TextBox; checkBox = CBJUEVESMES1HAY; break;
                        case 2: textBox = JUEVESMES2TextBox; checkBox = CBJUEVESMES2HAY; break;
                        case 3: textBox = JUEVESMES3TextBox; checkBox = CBJUEVESMES3HAY; break;
                        case 4: textBox = JUEVESMES4TextBox; checkBox = CBJUEVESMES4HAY; break;
                        case 5: textBox = JUEVESMES5TextBox; checkBox = CBJUEVESMES5HAY; break;
                        case 6: textBox = JUEVESMES6TextBox; checkBox = CBJUEVESMES6HAY; break;
                        case 7: textBox = JUEVESMES7TextBox; checkBox = CBJUEVESMES7HAY; break;
                        case 8: textBox = JUEVESMES8TextBox; checkBox = CBJUEVESMES8HAY; break;
                        case 9: textBox = JUEVESMES9TextBox; checkBox = CBJUEVESMES9HAY; break;
                        case 10: textBox = JUEVESMES10TextBox; checkBox = CBJUEVESMES10HAY; break;
                        case 11: textBox = JUEVESMES11TextBox; checkBox = CBJUEVESMES11HAY; break;
                        case 12: textBox = JUEVESMES12TextBox; checkBox = CBJUEVESMES12HAY; break;
                        default: textBox = JUEVESMES1TextBox; checkBox = CBJUEVESMES1HAY; break;
                    }
                    break;

                case 5:
                    switch (mes)
                    {
                        case 1: textBox = VIERNESMES1TextBox; checkBox = CBVIERNESMES1HAY; break;
                        case 2: textBox = VIERNESMES2TextBox; checkBox = CBVIERNESMES2HAY; break;
                        case 3: textBox = VIERNESMES3TextBox; checkBox = CBVIERNESMES3HAY; break;
                        case 4: textBox = VIERNESMES4TextBox; checkBox = CBVIERNESMES4HAY; break;
                        case 5: textBox = VIERNESMES5TextBox; checkBox = CBVIERNESMES5HAY; break;
                        case 6: textBox = VIERNESMES6TextBox; checkBox = CBVIERNESMES6HAY; break;
                        case 7: textBox = VIERNESMES7TextBox; checkBox = CBVIERNESMES7HAY; break;
                        case 8: textBox = VIERNESMES8TextBox; checkBox = CBVIERNESMES8HAY; break;
                        case 9: textBox = VIERNESMES9TextBox; checkBox = CBVIERNESMES9HAY; break;
                        case 10: textBox = VIERNESMES10TextBox; checkBox = CBVIERNESMES10HAY; break;
                        case 11: textBox = VIERNESMES11TextBox; checkBox = CBVIERNESMES11HAY; break;
                        case 12: textBox = VIERNESMES12TextBox; checkBox = CBVIERNESMES12HAY; break;
                        default: textBox = VIERNESMES1TextBox; checkBox = CBVIERNESMES1HAY; break;
                    }
                    break;

                case 6:
                    switch (mes)
                    {
                        case 1: textBox = SABADOMES1TextBox; checkBox = CBSABADOMES1HAY; break;
                        case 2: textBox = SABADOMES2TextBox; checkBox = CBSABADOMES2HAY; break;
                        case 3: textBox = SABADOMES3TextBox; checkBox = CBSABADOMES3HAY; break;
                        case 4: textBox = SABADOMES4TextBox; checkBox = CBSABADOMES4HAY; break;
                        case 5: textBox = SABADOMES5TextBox; checkBox = CBSABADOMES5HAY; break;
                        case 6: textBox = SABADOMES6TextBox; checkBox = CBSABADOMES6HAY; break;
                        case 7: textBox = SABADOMES7TextBox; checkBox = CBSABADOMES7HAY; break;
                        case 8: textBox = SABADOMES8TextBox; checkBox = CBSABADOMES8HAY; break;
                        case 9: textBox = SABADOMES9TextBox; checkBox = CBSABADOMES9HAY; break;
                        case 10: textBox = SABADOMES10TextBox; checkBox = CBSABADOMES10HAY; break;
                        case 11: textBox = SABADOMES11TextBox; checkBox = CBSABADOMES11HAY; break;
                        case 12: textBox = SABADOMES12TextBox; checkBox = CBSABADOMES12HAY; break;
                        default: textBox = SABADOMES1TextBox; checkBox = CBSABADOMES1HAY; break;
                    }
                    break;

                case 7:
                    switch (mes)
                    {
                        case 1: textBox = DOMINGOMES1TextBox; checkBox = CBDOMINGOMES1HAY; break;
                        case 2: textBox = DOMINGOMES2TextBox; checkBox = CBDOMINGOMES2HAY; break;
                        case 3: textBox = DOMINGOMES3TextBox; checkBox = CBDOMINGOMES3HAY; break;
                        case 4: textBox = DOMINGOMES4TextBox; checkBox = CBDOMINGOMES4HAY; break;
                        case 5: textBox = DOMINGOMES5TextBox; checkBox = CBDOMINGOMES5HAY; break;
                        case 6: textBox = DOMINGOMES6TextBox; checkBox = CBDOMINGOMES6HAY; break;
                        case 7: textBox = DOMINGOMES7TextBox; checkBox = CBDOMINGOMES7HAY; break;
                        case 8: textBox = DOMINGOMES8TextBox; checkBox = CBDOMINGOMES8HAY; break;
                        case 9: textBox = DOMINGOMES9TextBox; checkBox = CBDOMINGOMES9HAY; break;
                        case 10: textBox = DOMINGOMES10TextBox; checkBox = CBDOMINGOMES10HAY; break;
                        case 11: textBox = DOMINGOMES11TextBox; checkBox = CBDOMINGOMES11HAY; break;
                        case 12: textBox = DOMINGOMES12TextBox; checkBox = CBDOMINGOMES12HAY; break;
                        default: textBox = DOMINGOMES1TextBox; checkBox = CBDOMINGOMES1HAY; break;
                    }
                    break;

                default:
                    switch (mes)
                    {
                        case 1: textBox = LUNESMES1TextBox; checkBox = CBLUNESMES1HAY; break;
                        case 2: textBox = LUNESMES2TextBox; checkBox = CBLUNESMES2HAY; break;
                        case 3: textBox = LUNESMES3TextBox; checkBox = CBLUNESMES3HAY; break;
                        case 4: textBox = LUNESMES4TextBox; checkBox = CBLUNESMES4HAY; break;
                        case 5: textBox = LUNESMES5TextBox; checkBox = CBLUNESMES5HAY; break;
                        case 6: textBox = LUNESMES6TextBox; checkBox = CBLUNESMES6HAY; break;
                        case 7: textBox = LUNESMES7TextBox; checkBox = CBLUNESMES7HAY; break;
                        case 8: textBox = LUNESMES8TextBox; checkBox = CBLUNESMES8HAY; break;
                        case 9: textBox = LUNESMES9TextBox; checkBox = CBLUNESMES9HAY; break;
                        case 10: textBox = LUNESMES10TextBox; checkBox = CBLUNESMES10HAY; break;
                        case 11: textBox = LUNESMES11TextBox; checkBox = CBLUNESMES11HAY; break;
                        case 12: textBox = LUNESMES12TextBox; checkBox = CBLUNESMES12HAY; break;
                        default: textBox = LUNESMES1TextBox; checkBox = CBLUNESMES1HAY; break;
                    }
                    break;

            }




            //string strControlTextBox = strDia + "MES" + strMes  + "TextBox";
            //string strControlCheckBox = "CB" + strDia + "MES" + strMes  + "HAY";

            //textBox = (TextBox)this.pnlMaximosDia.Controls[strControlTextBox];
            //checkBox = (CheckBox)this.pnlMaximosDia.Controls[strControlCheckBox];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea cancelar los cambios? ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                resetear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea eliminar el registro? ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strSucursalClave = this.SUCURSALIDTextBox.DbValue.ToString();
                int anio = (int)ANIOTextBox.Value;



                if (this.SUCURSALIDTextBox.Text == "")
                {
                    MessageBox.Show("se necesita seleccionar la sucursal");
                    return;
                }


                CMAXFACTD regD = new CMAXFACTD();
                if(!regD.BorrarMAXFACTXSUCURSALANIO(strSucursalClave, anio, null))
                {

                    MessageBox.Show("Ocurrio un error al eliminar el registro");
                    return;
                }
                else
                {
                    MessageBox.Show("Se ha eliminado el registro");
                    resetear();
                }

            }
        }

        private void WFMaxFactEdicion_Load(object sender, EventArgs e)
        {

            WFConsolidadoAutomatico wf = new WFConsolidadoAutomatico();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }
    }
}
