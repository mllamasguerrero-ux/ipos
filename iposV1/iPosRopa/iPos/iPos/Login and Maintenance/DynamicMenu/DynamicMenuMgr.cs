using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace DynamicMenuApp
{
    public class DynamicMenuMgr
    {
        ToolStripMenuItem _anchor;
        ToolStripMenuItem _separator;
        DynamicMenuType _dynamicMenuType;
        ItemInsertMode _itemInsertMode;
        int _maxItems;
        int _itemCount;
        public enum ItemInsertMode
        {
            Prepend,
            Append
        };
        public enum DynamicMenuType
        {
            Inline,
            Submenu
        };
        
        public DynamicMenuMgr(ToolStripMenuItem anchor, ToolStripMenuItem separator, DynamicMenuType dynamicMenuType, 
            ItemInsertMode itemInsertMode, int maxItems)
        {
            _anchor = anchor;
            _separator = separator;
            _itemInsertMode = itemInsertMode;
            _dynamicMenuType = dynamicMenuType;
            _maxItems = maxItems > 0? maxItems : 50;
            _itemCount = 0;
            
            if (_dynamicMenuType == DynamicMenuType.Inline)
            {
                
                _anchor.Visible = false;
                if (_separator != null) _separator.Visible = false;
            }
            
            else
            {
                _anchor.Visible = true;
                
                _anchor.Enabled = false;
                
                if (_separator != null) _separator.Visible = true;
            }
        }
        
        public DynamicMenuMgr(ToolStripMenuItem anchor, ToolStripMenuItem separator, 
            DynamicMenuType DynamicMenuType, ItemInsertMode ItemInsertMode)
            : this(anchor, separator, DynamicMenuType, ItemInsertMode, 50)
        {
        }
        
        private void MenuItemClick(object sender, EventArgs e)
        {
            DynamicMenuItem item = (DynamicMenuItem)sender;
            MessageBox.Show(item.Data);
        }
        
        public void AddMenuItems(DynamicMenuItem.DynamicMenuItemTextData[] textDataCollection)
        {
            foreach (DynamicMenuItem.DynamicMenuItemTextData textData in textDataCollection)
                AddMenuItem(textData.MenuText, textData.MenuData);
        }
        public virtual DynamicMenuItem AddMenuItem(string menuText, string data)
        {
            return AddMenuItem(menuText, data, this.MenuItemClick);
        }
        public virtual DynamicMenuItem AddMenuItem(string menuText, string data  , System.EventHandler eventHandler)
        {
            ToolStripItemCollection menuItems;
            DynamicMenuItem menuItem = new DynamicMenuItem(menuText, data, eventHandler);
            menuItem.BackColor =  /*System.Drawing.SystemColors.MenuHighlight;*/System.Drawing.Color.FromArgb(52, 152, 219);
            menuItem.ForeColor = System.Drawing.Color.White;
            menuItem.MouseEnter += new EventHandler(this.menuItem_MouseEnter);
            menuItem.DropDownOpened += new EventHandler(this.menuItem_MouseEnter);
            menuItem.MouseLeave += new EventHandler(this.menuItem_MouseLeave);
            menuItem.DropDownClosed += new EventHandler(this.menuItem_MouseLeave);

            if (iPos.CurrentUserID.CurrentParameters.ISCREENCONFIG == 1)
            {
                Bitmap emptyImage = new Bitmap(2, 30);
                menuItem.Image = emptyImage;
                menuItem.ImageAlign = ContentAlignment.MiddleLeft;
                menuItem.ImageScaling = ToolStripItemImageScaling.None;
            }

            switch (_dynamicMenuType)
            {
                case DynamicMenuType.Inline:
                    if (_anchor.OwnerItem == null)
                    {
                        menuItems = ((MenuStrip)_anchor.Owner).Items;
                    }
                    else
                    {
                        menuItems = ((ToolStripMenuItem)_anchor.OwnerItem).DropDownItems;
                    }
                    
                    AddMenuItemInline(menuItem, menuItems);
                    return menuItem;
                    
                case DynamicMenuType.Submenu:
                    menuItems = _anchor.DropDownItems;
                    AddMenuItemInSubmenu(menuItem, menuItems);
                    return menuItem;
                   
                default:
                    return null;
                   
            }
        }
        private void AddMenuItemInline(ToolStripMenuItem menuItem, ToolStripItemCollection menuItems)
        {
            int anchorIndex = menuItems.IndexOf(_anchor);
            
            switch (_itemInsertMode)
            {
                case ItemInsertMode.Append:
                    if (_itemCount == _maxItems)
                    {
                        menuItems.RemoveAt(anchorIndex + 1);
                        _itemCount--;
                    }
                    menuItems.Insert(anchorIndex + _itemCount + 1, menuItem);
                    break;
                case ItemInsertMode.Prepend:
                    if (_itemCount == _maxItems)
                    {
                        menuItems.RemoveAt(anchorIndex + _maxItems);
                        _itemCount--;
                    }
                    menuItems.Insert(anchorIndex + 1, menuItem);
                    break;
                default:
                    break;
            }
            _itemCount++;
            try
            {
                if(_separator != null)
                    _separator.Visible = true;
            }
            catch
            {
            }
        }
        private void AddMenuItemInSubmenu(ToolStripMenuItem menuItem, ToolStripItemCollection menuItems)
        {
            switch (_itemInsertMode)
            {
                case ItemInsertMode.Append:
                    if (_itemCount == _maxItems)
                    {
                        menuItems.RemoveAt(0);
                        _itemCount--;
                    }
                    menuItems.Add(menuItem);
                    break;
                case ItemInsertMode.Prepend:
                    if (_itemCount == _maxItems)
                    {
                        menuItems.RemoveAt(_maxItems-1);
                        _itemCount--;
                    }
                    menuItems.Insert(0, menuItem);
                    break;
                default:
                    break;
            }
            _itemCount++;
            _anchor.Enabled = true;
        }


        private void menuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = System.Drawing.Color.Black;
            if (TSMI.OwnerItem != null)
            {
                TSMI.OwnerItem.ForeColor = System.Drawing.Color.Black;

                if (TSMI.OwnerItem.OwnerItem != null)
                {
                    TSMI.OwnerItem.OwnerItem.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void menuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = System.Drawing.Color.White;
            if (TSMI.OwnerItem != null)
            {
                TSMI.OwnerItem.ForeColor = System.Drawing.Color.White;
                if (TSMI.OwnerItem.OwnerItem != null)
                {
                    TSMI.OwnerItem.OwnerItem.ForeColor = System.Drawing.Color.White;
                }
            }
        }

    }
}
