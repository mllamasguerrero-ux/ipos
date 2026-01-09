using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace System.Windows.Forms
{
    public class TextBoxET : System.Windows.Forms.TextBox
    {
        private bool validarEntrada;
        private bool tratarEnterComoTab = true;


        [DefaultValue(false)]
        public bool ValidarEntrada
        {
            get
            {
                return validarEntrada;
            }
            set
            {
                this.validarEntrada = value;
            }
        }
        private bool m_bMostrarErrores;
        [DefaultValue(false)]
        public bool MostrarErrores
        {
            get
            {
                return m_bMostrarErrores;
            }
            set
            {
                this.m_bMostrarErrores = value;
            }
        }
        private bool m_bIsNotNullable;
        [DefaultValue(false)]
        public bool IsNotNullable
        {
            get
            {
                return m_bIsNotNullable;
            }
            set
            {
                this.m_bIsNotNullable = value;
            }
        }
        private string mValidationExpression;
        public string ValidationExpression
        {
            get
            {
                return mValidationExpression;
            }
            set
            {
                mValidationExpression = value;
            }
        }
        private string mFormatExpression;
        public string Format_Expression
        {
            get
            {
                return mFormatExpression;
            }
            set
            {
                mFormatExpression = value;
            }
        }



        [DefaultValue(true)]
        public bool TratarEnterComoTab
        {
            get
            {
                return tratarEnterComoTab;
            }
            set
            {
                this.tratarEnterComoTab = value;
            }
        }

        public TextBoxET()
            :base()
        {
            this.Tag = 34;
        }
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message m, System.Windows.Forms.Keys k)
        {

            if (m.Msg == 256 && k == System.Windows.Forms.Keys.Enter && tratarEnterComoTab)
            {
                
                System.Windows.Forms.SendKeys.Send("\t");
                
                return true;
            }
            
            return base.ProcessCmdKey(ref m, k);
        }
        protected override void OnValidated(EventArgs e)
        {
            if (validarEntrada && this.Enabled == true)
            {
                if (m_bIsNotNullable &&
                this.Text == "")
                {
                    if (m_bMostrarErrores)
                    {
                        MessageBox.Show("El campo no puede estar vacio");
                        this.Focus();
                        return;
                    }
                }
                if (!ValidateRegularExpresion())
                {
                    if (m_bMostrarErrores)
                    {
                        MessageBox.Show("El formato no es el indicado, por favor ingrese un formato de este tipo: " + Format_Expression);
                    }
                    }
            }
            base.OnValidated(e);
        }

        public void SelectAllText()
        {

            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }

        public bool ValidateRegularExpresion()
        {
            if (ValidationExpression == null || ValidationExpression == "")
                return true;
            string TextToValidate;
            Regex expression;
            try
            {
                TextToValidate = this.Text;
                expression = new Regex(ValidationExpression);
            }
            catch
            {
                return false;
            }
            // test text with expression
            if (expression.IsMatch(TextToValidate))
            {
                return true;
            }
            else
            {
                // no match
                return false;
            }
        }
        
    }
}
