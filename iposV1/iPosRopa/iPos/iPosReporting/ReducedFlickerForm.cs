using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace iPosReporting
{
    public class ReducedFlickerForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);



        private bool isLocked;
        private Size currentSize;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private void LockWindow()
        {
            if (!isLocked)
            {
                isLocked = true;
                LockWindowUpdate(this.Handle);
            }
        }

        private void UnlockWindow()
        {
            if (isLocked)
            {
                isLocked = false;
                LockWindowUpdate(IntPtr.Zero);
            }
            this.Refresh();
        }

        private bool IsResized()
        {
            if (currentSize.IsEmpty)
            {
                return false;
            }
            else
            {
                return this.Size != currentSize;
            }
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            currentSize = this.Size;
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            currentSize = this.Size;
            this.UnlockWindow();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.WindowState == FormWindowState.Normal)
            {
                if (isLocked && IsResized())
                {
                    currentSize = this.Size;
                    UnlockWindow();
                    LockWindow();
                }
            }
        }


        protected override void OnMove(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && IsResized() && !isLocked)
            {
                LockWindow();
            }

            base.OnMove(e);
        }

    }
}
