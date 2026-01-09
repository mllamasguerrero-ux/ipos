using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace System.Windows.Forms
{
    public class DataGridViewSum : System.Windows.Forms.DataGridView
    {
        

        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        private bool keyShiftActive = false;



        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Menu | Keys.Alt) || e.KeyData == (Keys.Alt))
            {
                keyShiftActive = false;
            }
            base.OnKeyUp(e);
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Menu | Keys.Alt) || e.KeyData == (Keys.Alt))
            {
                keyShiftActive = true;
            }
            base.OnKeyDown(e);
        }

        

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseDown(e);

            if (e.RowIndex == -1 && e.ColumnIndex == -1) return;

            if(keyShiftActive)
            {
                keyShiftActive = false;

                try
                {
                    if (ConexionesBD.ConexionBD.TieneDerechoAVerSumasGrid)
                    {
                        string strMonto = this.Rows.Cast<DataGridViewRow>()
                                           .AsEnumerable()
                                           .Sum(x => decimal.Parse(x.Cells[e.ColumnIndex].Value.ToString()))
                                           .ToString("N");
                        MessageBox.Show("Monto columna : " + strMonto);
                    }
                }
                catch(Exception ex)
                {

                }
            }

        }



    }
}

