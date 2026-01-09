using iPos.Catalogos;
using iPos.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public class IposForm : Form
    {
       protected virtual bool applyGeneralFormBehaviour()
        {
          return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (applyGeneralFormBehaviour() && keyData == (Keys.F1))
            {
                WFChecadorPrecio wf = new WFChecadorPrecio();
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
                return true;
            }
            else if (applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.N))
            {
                CalculatorForm cf = new CalculatorForm();
                cf.ShowDialog();
                cf.Dispose();
                GC.SuppressFinalize(cf);

                return true;
            }
            else if(applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.P))
            {
                
            }
            else if (applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.Alt | Keys.C))
            {
                WFClientes wf = new WFClientes();
                //wf.Owner = this;
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
            else if (applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.Alt | Keys.P))
            {
                WFProveedores wf = new WFProveedores();
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
            else if (applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.Alt | Keys.I))
            {
                LOOKPROD wf = new LOOKPROD();
                wf.m_bMostrarDescontinuados = true;
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
            else if (applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.Alt | Keys.V))
            {
                WFVendedores fq = new WFVendedores();
                fq.ShowDialog();
                fq.Dispose();
                GC.SuppressFinalize(fq);
            }
            else if (applyGeneralFormBehaviour() && keyData == (Keys.Control | Keys.Alt | Keys.S))
            {
                if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") && CurrentUserID.CurrentParameters.ISCREENCONFIG == 1)
                {
                    WFMovilPuntoDeVenta frm = new WFMovilPuntoDeVenta();
                    frm.ShowDialog();
                    frm.Dispose();
                    GC.SuppressFinalize(frm);
                }
                else
                {
                    WFPuntoDeVenta frm = new WFPuntoDeVenta();
                    frm.ShowDialog();
                    frm.Dispose();
                    GC.SuppressFinalize(frm);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
