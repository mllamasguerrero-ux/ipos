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
using System.Collections;

namespace iPos.Tools
{
    public class ScreenConfigurableForm : IposForm
    {

        Dictionary<String, CustomAutoCompleteStruct> customAutoCompletes = new Dictionary<String, CustomAutoCompleteStruct>();
        Dictionary<String, String> customAutoCompletesDblLink = new Dictionary<String, String>();


        public void addCustomAutoCompletePair(ref TextBox textBox, ref ListBox listBox, AutoCompleteStringCollection collection)
        {
            CustomAutoCompleteStruct struc = new CustomAutoCompleteStruct(ref textBox, ref listBox, ref collection);
            customAutoCompletes.Add(textBox.Name, struc);
            customAutoCompletesDblLink.Add(listBox.Name, textBox.Name);

            textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ACTextBox_KeyUp_1);
            textBox.Leave += new System.EventHandler(this.ACTextBox_Leave);

            listBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ACListBox_MouseClick);
            listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ACListBox_DrawItem);
            listBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ACListBox_MeasureItem);
            listBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ACListBox_KeyUp);



        }



        private void ACTextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            TextBox aCTextBox = (TextBox)sender;
            ListBox aCListBox = customAutoCompletes[aCTextBox.Name].listBox; 

            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S") && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") /*CurrentUserID.CurrentParameters.ISCREENCONFIG == 1*/)
            {
                if (e.KeyCode != System.Windows.Forms.Keys.Tab && e.KeyCode != System.Windows.Forms.Keys.Enter && e.KeyCode != System.Windows.Forms.Keys.Down)
                    fillACList(customAutoCompletes[aCTextBox.Name]);
                else if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    if (aCListBox.Items.Count > 0)
                    {
                        aCListBox.SelectedIndex = 0;
                        aCListBox.Visible = true;
                        aCListBox.Focus();

                    }
                }

            }
            else
            {
                aCListBox.Visible = false;
            }
        }

        private void ACTextBox_Leave(object sender, EventArgs e)
        {

            TextBox aCTextBox = (TextBox)sender;
            ListBox aCListBox = customAutoCompletes[aCTextBox.Name].listBox;

            if (!aCListBox.Focused)
            {
                aCListBox.Visible = false;
                aCListBox.Items.Clear();
            }
        }


        private void ACListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox aCListBox = (ListBox)sender;
            String strTextBoxName = customAutoCompletesDblLink[aCListBox.Name];
            TextBox aCTextBox = customAutoCompletes[strTextBoxName].textBox;

            int index = aCListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                aCTextBox.Text = aCListBox.Items[index].ToString();
                aCTextBox.Focus();
                aCListBox.Visible = false;
            }
        }

        private void ACListBox_KeyUp(object sender, KeyEventArgs e)
        {

            ListBox aCListBox = (ListBox)sender;
            String strTextBoxName = customAutoCompletesDblLink[aCListBox.Name];
            TextBox aCTextBox = customAutoCompletes[strTextBoxName].textBox;

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (aCListBox.SelectedIndex >= 0)
                {
                    aCTextBox.Text = aCListBox.SelectedItem.ToString();
                    aCTextBox.Focus();
                    aCListBox.Visible = false;
                }
            }
        }


        private void ACListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40;
        }


        private void ACListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

            ListBox aCListBox = (ListBox)sender;

            // If the item is the selected item, then draw the rectangle 
            // filled in blue. The item is selected when a bitwise And   
            // of the State property and the DrawItemState.Selected  
            // property is true. 
            Boolean bSelected = false;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                bSelected = true;
            }
            else
            {
                // Otherwise, draw the rectangle filled in beige.
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            // Draw a rectangle in blue around each item.
            //e.Graphics.DrawRectangle(Pens.Blue, e.Bounds);

            // Draw the text in the item.
            e.Graphics.DrawString(aCListBox.Items[e.Index].ToString(),
                aCListBox.Font, bSelected ? Brushes.White : Brushes.Black, e.Bounds.X, e.Bounds.Y);

            // Draw the focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }



        private void fillACList(CustomAutoCompleteStruct struc)
        {
            struc.listBox.Items.Clear();

            if (struc.textBox.Text.Trim().Length != 0)
            {

                String strSearch = struc.textBox.Text.Trim();
                 foreach (String str in struc.collection)
                {
                    if (str.StartsWith(strSearch, true, null))
                    {
                        struc.listBox.Items.Add(str);
                    }
                }
            }

            struc.listBox.Visible = (struc.listBox.Items.Count > 0);
            struc.listBox.Size = new Size(struc.listBox.Size.Width, (struc.listBox.Items.Count > 0) ? 400 : 0);

        }





        public void recursiveGetResizeingOnScreenControls(Control.ControlCollection controls,
                                                            ref List<DataGridView> listGrids,
                                                            ref List<TextBox> listTextBox,
                                                            ref List<Label> listLabel,
                                                            ref List<Button> listButtons,
                                                            ref List<DateTimePicker> listDatePickers, 
                                                            ref List<ComboBox> listComboBoxes)
        {

            foreach (Control controlcito in controls)
            {


                try
                {
                    if (controlcito is TextBox && (controlcito.AccessibleDescription != null && controlcito.AccessibleDescription.Equals("resizeforscreen")))
                    {
                        listTextBox.Add((TextBox)controlcito);
                    }
                    else if (controlcito is Label && (controlcito.AccessibleDescription != null && controlcito.AccessibleDescription.Equals("resizeforscreen")))
                    {
                        listLabel.Add((Label)controlcito);
                    }
                    else if (controlcito is Button && (controlcito.AccessibleDescription != null && controlcito.AccessibleDescription.Equals("resizeforscreen")))
                    {
                        listButtons.Add((Button)controlcito);
                    }
                    else if (controlcito is DateTimePicker && (controlcito.AccessibleDescription != null && controlcito.AccessibleDescription.Equals("resizeforscreen")))
                    {
                        listDatePickers.Add((DateTimePicker)controlcito);
                    }
                    else if (controlcito is DataGridView)
                    {
                        DataGridView dg = (DataGridView)controlcito;
                        try
                        {

                            if (dg.Columns["DGHEIGHT"] != null || dg.Columns["DGHEIGHT2"] != null)
                            {

                                listGrids.Add(dg);
                            }

                        }
                        catch
                        {

                        }
                    }
                    else if (controlcito is ComboBox && (controlcito.AccessibleDescription != null && controlcito.AccessibleDescription.Equals("resizeforscreen")))
                    {
                        listComboBoxes.Add((ComboBox)controlcito);
                    }

                    else if (controlcito.HasChildren)
                    {
                        recursiveGetResizeingOnScreenControls(controlcito.Controls,
                                                            ref listGrids,
                                                            ref listTextBox,
                                                            ref  listLabel,
                                                            ref  listButtons,
                                                            ref  listDatePickers,
                                                            ref listComboBoxes);
                    }
                }
                catch
                {
                   
                }
            }
        }


        public void configuraLaPantalla(bool resizeWindowIfNeeded, bool positionWindowIfNeeded)
        {

            if (CurrentUserID.CurrentParameters.ISCREENCONFIG == 1 )
            {
                if( resizeWindowIfNeeded)
                {
                    Size expSize = new Size((int)(iPos.CurrentUserID.mainWinSize.Width * 0.95), (int)(iPos.CurrentUserID.mainWinSize.Height * 0.95));
                    this.Size = expSize;
                }
                if(positionWindowIfNeeded)
                {
                    Point expLocation = new Point((int)(iPos.CurrentUserID.mainWinSize.Width * 0.02), (int)(iPos.CurrentUserID.mainWinSize.Height * 0.02));
                    this.Location = expLocation;

                }
            }



            if ((CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null &&
                CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")) || CurrentUserID.CurrentParameters.ISCREENCONFIG == 1)
            {

                List<DataGridView> listGrids = new List<DataGridView>();
                List<TextBox> listTextBox = new List<TextBox>();
                List<Label> listLabel = new List<Label>();
                List<Button> listButtons = new List<Button>();
                List<DateTimePicker> listDatePickers = new List<DateTimePicker>();
                List<ComboBox> listComboBoxes = new List<ComboBox>();


                recursiveGetResizeingOnScreenControls(this.Controls,
                                                        ref listGrids,
                                                        ref listTextBox,
                                                        ref  listLabel,
                                                        ref  listButtons,
                                                        ref  listDatePickers,
                                                        ref  listComboBoxes);

                foreach (Button item in listButtons)
                {
                    item.Height = 40;
                }

                foreach (Label item in listLabel)
                {
                    item.Font = new Font(item.Font.FontFamily.Name, 14.25F, item.Font.Style);
                }
                foreach (TextBox item in listTextBox)
                {
                    item.Font = new Font(item.Font.FontFamily.Name, 14.25F, item.Font.Style);
                }
                foreach (DateTimePicker item in listDatePickers)
                {
                    item.Font = new Font(item.Font.FontFamily.Name, 14.25F, item.Font.Style);
                }
                foreach (ComboBox item in listComboBoxes)
                {
                    item.Font = new Font(item.Font.FontFamily.Name, 14.25F, item.Font.Style);
                }


                foreach (DataGridView item in listGrids)
                {
                    item.DefaultCellStyle.Font = new Font("Arial", 15.0F, FontStyle.Bold, GraphicsUnit.Pixel);
                     item.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                    if (item.Columns["DGHEIGHT"] != null)
                    {
                        item.Columns["DGHEIGHT"].DefaultCellStyle.Font = new Font("Arial", 22.0F, item.Font.Style);
                    }


                    if (item.Columns["DGHEIGHT2"] != null)
                    {
                        item.Columns["DGHEIGHT2"].DefaultCellStyle.Font = new Font("Arial", 22.0F, item.Font.Style);
                    }

                }


            }

        }

    }
}
