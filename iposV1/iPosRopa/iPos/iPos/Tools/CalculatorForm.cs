using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace iPos.Tools
{

    public partial class CalculatorForm : IposForm
    {
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private Decimal accumulator = 0;
        private char lastOperation;


        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void Operator_Pressed(object sender, EventArgs e)
        {
            // An operator was pressed; perform the last operation and store the new operator.
            char operation = (sender as Button).Text[0];
            if (operation == 'C')
            {
                accumulator = 0;
            }
            else
            {
                try
                {
                    Decimal currentValue = Decimal.Parse(Display.Text);
                    switch (lastOperation)
                    {
                        case '+': accumulator += currentValue; break;
                        case '-': accumulator -= currentValue; break;
                        case '×': accumulator *= currentValue; break;
                        case '÷': accumulator /= currentValue; break;
                        default: accumulator = currentValue; break;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Operación no valida!", "Error", MessageBoxButtons.OK);
                    this.Close();                  
                }
            }

            lastOperation = operation;
            Display.Text = operation == '=' ? accumulator.ToString() : "0";
        }

        private void Number_Pressed(object sender, EventArgs e)
        {
            // Add it to the display.
            string number = (sender as Button).Text;
            Display.Text = Display.Text == "0" ? number : Display.Text + number;
        }


        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            string s;
            string aux = "";
            s = Display.Text;
            int l = s.Length;
            for (int i = 0; i < l - 1; i++)
            {
                aux += s[i];
            }
            Display.Text = aux;
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if(accumulator!=0)
            {
                ResultSaved.resultSaved = accumulator;
                this.Close();
                Clipboard.SetText(iPos.Tools.ResultSaved.resultSaved.ToString());
                SendKeys.Send("^{a}");
                SendKeys.Send("^{v}");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;

            if (msg.Msg == WM_KEYDOWN)
            {
                // 2 is used to translate into an unshifted character value   
                uint nonVirtualKey = MapVirtualKey((uint)keyData, (uint)2);

                char mappedChar = Convert.ToChar(nonVirtualKey);
                switch(mappedChar)
                {
                    case '+':
                        btnAdd.PerformClick();
                        return true;
                    case '-':
                        btnLess.PerformClick();
                        return true;
                    case '*':
                         btnCross.PerformClick();
                         return true;
                    case '/':
                         btnDivide.PerformClick();
                         return true;
                    case '.':
                         Display.Text = Display.Text == "0" ? "." : Display.Text + ".";
                         return true;
                    case '1':
                        Display.Text = Display.Text == "0" ? "1" : Display.Text + "1";
                        return true;
                    case '2':
                        Display.Text = Display.Text == "0" ? "2" : Display.Text + "2";
                        return true;
                    case '3':
                        Display.Text = Display.Text == "0" ? "3" : Display.Text + "3";
                        return true;
                    case '4':
                        Display.Text = Display.Text == "0" ? "4" : Display.Text + "4";
                        return true;
                    case '5':
                        Display.Text = Display.Text == "0" ? "5" : Display.Text + "5";
                        return true;
                    case '6':
                        Display.Text = Display.Text == "0" ? "6" : Display.Text + "6";
                        return true;
                    case '7':
                        Display.Text = Display.Text == "0" ? "7" : Display.Text + "7";
                        return true;
                    case '8':
                        Display.Text = Display.Text == "0" ? "8" : Display.Text + "8";
                        return true;
                    case '9':
                        Display.Text = Display.Text == "0" ? "9" : Display.Text + "9";
                        return true;
                    case '0':
                        Display.Text = Display.Text == "0" ? "0" : Display.Text + "0";
                        return true;
                }
            }

            if (keyData == (Keys.Back))
            {
                btnBackSpace.PerformClick();
                return true;
            }
             else if (keyData == (Keys.Enter) || keyData == (Keys.Shift | Keys.D0))
            {
                btnEqual.PerformClick();
                return true;
            }
            else if (keyData == (Keys.C))
            {
                btnClearCalculator.PerformClick();
            }
            else if (keyData == (Keys.P))
            {
                btnSaveResult.PerformClick();
            }
            /*if (keyData == (Keys.D1) || keyData == (Keys.NumPad1))
            {
                Display.Text = Display.Text == "0" ? "1" : Display.Text + "1";
                return true;
            }
            else if (keyData == (Keys.D2) || keyData == (Keys.NumPad2))
            {
                Display.Text = Display.Text == "0" ? "2" : Display.Text + "2";
                return true;
            }
            else if (keyData == (Keys.D3) || keyData == (Keys.NumPad3))
            {
                Display.Text = Display.Text == "0" ? "3" : Display.Text + "3";
                return true;
            }
            else if (keyData == (Keys.D4) || keyData == (Keys.NumPad4))
            {
                Display.Text = Display.Text == "0" ? "4" : Display.Text + "4";
                return true;
            }
            else if (keyData == (Keys.D5) || keyData == (Keys.NumPad5))
            {
                Display.Text = Display.Text == "0" ? "5" : Display.Text + "5";
                return true;
            }
            else if (keyData == (Keys.D6) || keyData == (Keys.NumPad6))
            {
                Display.Text = Display.Text == "0" ? "6" : Display.Text + "6";
                return true;
            }
            else if (keyData == (Keys.D7) || keyData == (Keys.NumPad7))
            {
                Display.Text = Display.Text == "0" ? "7" : Display.Text + "7";
                return true;
            }
            else if (keyData == (Keys.D8) || keyData == (Keys.NumPad8))
            {
                Display.Text = Display.Text == "0" ? "8" : Display.Text + "8";
                return true;
            }
            else if (keyData == (Keys.D9) || keyData == (Keys.NumPad9))
            {
                Display.Text = Display.Text == "0" ? "9" : Display.Text + "9";
                return true;
            }
            else if (keyData == (Keys.D0) || keyData == (Keys.NumPad0))
            {
                Display.Text = Display.Text == "0" ? "0" : Display.Text + "0";
                return true;
            }
            else if (keyData == (Keys.Decimal) || keyData == (Keys.OemPeriod))
            {
                Display.Text = Display.Text == "0" ? "." : Display.Text + ".";
                return true;
            }
            else if (keyData == (Keys.Back))
            {
                btnBackSpace.PerformClick();
                return true;
            }
           else if (keyData == (Keys.Add))
            {
                btnAdd.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Subtract))
            {
                btnLess.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Divide))
            {
                btnDivide.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Multiply))
            {
                btnCross.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Enter) || keyData == (Keys.Shift | Keys.D0))
            {
                btnEqual.PerformClick();
                return true;
            }*/
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public static class ResultSaved
    {
        public static Decimal resultSaved;

    };
}
