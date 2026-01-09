using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace DynamicMenuApp
{
    public class DynamicMenuItem : ToolStripMenuItem
    {
        private string _data;
        public struct DynamicMenuItemTextData
        {
            string _menuText;
            string _menuData;
            public string MenuText
            {
                get { return _menuText; }
                set { _menuText = value; }
            }
            public string MenuData
            {
                get { return _menuData; }
                set { _menuData = value; }
            }
            public DynamicMenuItemTextData(string menuText, string menuData)
            {
                _menuText = menuText;
                _menuData = menuData;
            }
        }
           
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public DynamicMenuItem(string text, string data, System.EventHandler eventHandler)
            : base(text)
        {
            _data = data;
            
            this.Click += new System.EventHandler(eventHandler);
        }
    }
}
