#region " Program Description & Revision History" 
#endregion 
using System;
using System.Windows.Forms; 
using System.ComponentModel; 
using System.ComponentModel.Design; 
using System.Text.RegularExpressions; 
using System.Drawing; 
using System.Drawing.Design; 
namespace CustomValidation
{
 
public class TextBoxValidator : System.Windows.Forms.TextBox
{ 
    
    #region " Class variables and events" 
    
    
    private System.Drawing.Color mForegroundColor;
    private System.Drawing.Color mBackgroundColor;
    private System.Drawing.Color mErrorForeColor = System.Drawing.Color.White;
    private System.Drawing.Color mErrorBackColor = System.Drawing.Color.Red; 
    
    
    private bool mRequired = false; 
    
    
    
    
    private string mPattern = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
    
    private bool mAllowContinue = false; 
    
    public event ValidateErrorEventHandler ValidateError; 
    public delegate void ValidateErrorEventHandler(string eventMessage); 
    public TextBoxValidator(): base()
        {
            mForegroundColor = ForeColor;
            mBackgroundColor  = BackColor;
    
        }
    
    #endregion 
    
    #region " Property page elements " 
    
    [Description("Use this pattern for validating the text box."), Editor(typeof(System.Web.UI.Design.WebControls.RegexTypeEditor), typeof(UITypeEditor)), Category("Customized Validation")] 
    public string Validation { 
        get { return mPattern; } 
        set { 
            mPattern = value; 
            
            
            if (this.Text != null) { 
                this.Focus(); 
                this.ValidateData(); 
            } 
        } 
    } 
    
    [Description("Set to True if field is required."), Category("Customized Validation")] 
    public bool Required { 
        get { return mRequired; } 
        set { mRequired = value; } 
    } 
    
    [Description("Change the background color of text box when error occures."), Category("Customized Validation")] 
    public Color ErrorBackColor { 
        get { return mErrorBackColor; } 
        set { mErrorBackColor = value; } 
    } 
    
    [Description("Change the foreground color of text box when error occures."), Category("Customized Validation")] 
    public Color ErrorForeColor { 
        get { return mErrorForeColor; } 
        set { mErrorForeColor = value; } 
    } 
    
    [Browsable(false)] 
    public Color ForegroundColor { 
        get { return mForegroundColor; } 
    } 
    
    [Browsable(false)] 
    public Color BackgroundColor { 
        get { return mBackgroundColor; } 
    }
    [Description("Set to True if the user only if enter a valid value."), Category("Customized Validation")]
    public bool AllowContinue
    {
        get { return mAllowContinue; }
        set { mAllowContinue = value; }
    } 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    #endregion 
    
    private bool ValidateData() 
    { 
        string tbString = this.Text; 
        
        if (tbString.Length == 0) { 
            
            if (Required == true) { 
                this.ForeColor = ErrorForeColor; 
                this.BackColor = ErrorBackColor; 
                if (ValidateError != null) { 
                    ValidateError("Required Field Missing"); 
                }
                if (!AllowContinue)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else { 
                this.ForeColor = ForegroundColor; 
                this.BackColor = BackgroundColor; 
                return false; 
            } 
        } 
        else { 
            
            
            
            
            
            
            Regex pattern = new Regex(Validation); 
            Match patternMatch = pattern.Match(tbString); 
            
            if (!patternMatch.Success) { 
                
                this.ForeColor = ErrorForeColor; 
                this.BackColor = ErrorBackColor; 
                
                if (ValidateError != null) { 
                    ValidateError("Invalid Field Entry"); 
                } 
                
                return true; 
            } 
            else { 
                
                this.ForeColor = ForegroundColor; 
                this.BackColor = BackgroundColor; 
                return false; 
            } 
        } 
    }
    protected override void OnValidating(CancelEventArgs e) 
    { 
        
            
        e.Cancel = ValidateData(); 
    } 
} 
}
