
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace System.Windows.Forms
{
    public class TabPageFB : TabPage
    {
        private Control m_FirstControl;
        private Control m_LastControl;
        public Control FirstControl
        {
            get
            {
                return m_FirstControl;
            }
            set
            {
                m_FirstControl = value;
               
            }
        }
        public Control LastControl
        {
            get
            {
                return m_LastControl;
              
            }
            set
            {
                m_LastControl = value;
            }
        }
        public TabPageFB(string title)
            : base(title)
        {
        }
        public TabPageFB()
            : base()
        {
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();
        [DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr GetNextDlgTabItem(IntPtr hDlg, IntPtr hCtrl, Int32 previous);
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message m, System.Windows.Forms.Keys k)
        {
            
            if (m.Msg == 256 && k == System.Windows.Forms.Keys.Enter)
            {
                
                System.Windows.Forms.SendKeys.Send("\t");
                
                return true;
            }
            
            return base.ProcessCmdKey(ref m, k);
        }
        
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData == Keys.Tab || keyData == (Keys.Shift | Keys.Tab))
              && LastControl != null && FirstControl != null)
            {
                bool handled = false;
                IntPtr hFocusedCtrl = GetFocus();
                if ((keyData & Keys.Shift) == Keys.Shift) 
                {
                    if (hFocusedCtrl == FirstControl.Handle)
                    {
                        
                        handled = JumpTabPage(true);
                    }
                }
                else 
                {
                    if (hFocusedCtrl == LastControl.Handle)
                    {
                        handled = JumpTabPage(false);
                        
                    }
                }
               
                if (handled)
                    return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private bool JumpTabPage(bool previous)
        {
            TabControl tabControl = (TabControl) Parent;
            int i = Parent.Controls.GetChildIndex(this);
            if (previous)
            {
                if (i > 0)
                    i--;
                else
                    return false;
            }
            else
            {
                if (i < tabControl.TabPages.Count - 1)
                    i++;
                else
                    return false;
            }
            
            tabControl.SelectedIndex = i;
            if (previous)
            {
                TabPage nextPage = tabControl.TabPages[i];
                Type t = typeof(TabPageFB);
                if (nextPage.GetType() == t)
                {
                    if (((TabPageFB)nextPage).LastControl != null)
                        ((TabPageFB)nextPage).LastControl.Focus();
                }
            }

            return true;
        }
        
        
    }
}
