
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
using iPos;
namespace iPos
{
    public partial class USUARIOSEdit : IposForm
    {
        string opc;
        long m_personaId;
        public USUARIOSEdit(string popc, long personaId)
        {
            opc = popc;
            m_personaId = personaId;
            InitializeComponent();
            this.uCUSUARIOSEdit1.ReCargar(opc, m_personaId);
            this.ucAsignarPerfil1.LlenaGrid((int)m_personaId);
            //this.ucderechoS_US1.LlenaGrid(US_USERID);
        }
        public USUARIOSEdit()
        {
            InitializeComponent();
            HabilitarInterfaces(false);
        }
        private void TSBGuardar_Click(object sender, EventArgs e)
        {
            F9Pressed();
 
        }
        private void SaveChanges()
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans;
            CPERSONABE user = new CPERSONABE();
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (uCUSUARIOSEdit1.SaveChanges(fTrans, ref user))
                {
                    if (ucAsignarPerfil1.SaveChanges(user.IID, fTrans))
                    {
                        //if (this.ucderechoS_US1.SaveChanges(user.IUS_USERID, fTrans))
                        //{
                            fTrans.Commit();
                            if (this.opc == "Agregar")
                            {
                                FPasswordInicial fPi = new FPasswordInicial(user.IID, true,false);
                                fPi.ShowDialog();
                                fPi.Dispose();
                                GC.SuppressFinalize(fPi);
                            }
                            LimpiarInterfaces();
                            HabilitarInterfaces(false);
                            this.US_USUARIOTextBox.Text = "";
                            this.opc = "";
                            this.tabControl1.SelectedTab = this.tabPage1;
                            this.US_USUARIOTextBox.Focus();
                        //}
                        //else
                        //{
                        //    fTrans.Rollback();
                        //}
                    }
                    else
                    {
                        fTrans.Rollback();
                    }
                }
                else
                {
                    fTrans.Rollback();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
  
        }
        private void HabilitarInterfaces(bool bHabilitar)
        {
            this.uCUSUARIOSEdit1.Enabled = bHabilitar;
            this.ucAsignarPerfil1.Enabled = bHabilitar;
            //this.ucderechoS_US1.Enabled = bHabilitar;
            panel2.Enabled = bHabilitar;
        }
        private void LimpiarInterfaces()
        {
            this.uCUSUARIOSEdit1.LimpiarDatos();
            this.ucAsignarPerfil1.ClearGrid();
            //this.ucderechoS_US1.ClearGrid();
        }
        private void LlenaDatos()
        {
            CPERSONABE USUARIOSBE = new CPERSONABE();
            CPERSONAD USUARIOSD = new CPERSONAD();
            USUARIOSBE.IUSERNAME = US_USUARIOTextBox.Text.ToString();
            USUARIOSBE = USUARIOSD.seleccionarPERSONAxNOMBRE(USUARIOSBE, null);
            if (USUARIOSBE != null)
            {
                opc = "Cambiar";
                m_personaId = USUARIOSBE.IID;
                this.uCUSUARIOSEdit1.LimpiarDatos();
                this.ucAsignarPerfil1.ClearGrid();
                //this.ucderechoS_US1.ClearGrid();
                this.uCUSUARIOSEdit1.ReCargar(opc, m_personaId);
                this.ucAsignarPerfil1.LlenaGrid((int)m_personaId);
                //this.ucderechoS_US1.LlenaGrid(US_USERID);
            }
            else
            {
                opc = "Agregar";
                this.uCUSUARIOSEdit1.LimpiarDatos();
                this.ucAsignarPerfil1.ClearGrid();
                //this.ucderechoS_US1.ClearGrid();
                this.uCUSUARIOSEdit1.ReCargar(opc, -1);
                this.ucAsignarPerfil1.LlenaGrid(-1);
                //this.ucderechoS_US1.LlenaGrid(-1);
            }
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            String prevUserValue = this.US_USUARIOTextBox.Text;
            
            
            iPos.GeneralLookUp look = new iPos.GeneralLookUp("Select id,username from persona where tipopersonaid = 20", "USUARIOS");
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr == null)
                return;
            this.US_USUARIOTextBox.Text = dr[1].ToString();
            if (prevUserValue != this.US_USUARIOTextBox.Text)
            {
                LlenaDatos();
                HabilitarInterfaces(true);
            }
        }
        private void TSBEliminar_Click(object sender, EventArgs e)
        {
            F8Pressed();
        }
        private void Eliminar()
        {
            if (uCUSUARIOSEdit1.Eliminar())
            {
                LimpiarInterfaces();
                HabilitarInterfaces(false);
                this.US_USUARIOTextBox.Text = "";
            }
        }
        private void ucderechoS_US1_Load(object sender, EventArgs e)
        {
        }
        private void F9Pressed() 
        {
            if (this.TSBGuardar.Enabled)
            {
                SaveChanges();
            }
        }
        private void F8Pressed() 
        {
            if (TSBEliminar.Enabled)
            {
                this.Eliminar();
            }
            
        }
        private void F7Pressed() 
        {
           
        }
        private void EscPressed() 
        {
            this.Close();
        }
        private void USUARIOSEdit_Reg_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        F9Pressed();
                        break;
                    case Keys.E:
                        F8Pressed();
                        break;
                    case Keys.L:
                        F7Pressed();
                        break;
                    default:
                        break;
                }
            }
            switch (e.KeyCode)
            {
              
                case Keys.Escape:
                    {
                        EscPressed();
                        break;
                    }
                default: break;
            }
        }
        private void TSBCerrar_Click(object sender, EventArgs e)
        {
            EscPressed();
        }
        private void US_USUARIOTextBox_Validating(object sender, CancelEventArgs e)
        {
            
            if (US_USUARIOTextBox.Text != "")
            {
                LlenaDatos();
                HabilitarInterfaces(true);
                uCUSUARIOSEdit1.SetUsuarioField(US_USUARIOTextBox.Text);
                this.uCUSUARIOSEdit1.Focus();
            }
            else
            {
                HabilitarInterfaces(false);
                LimpiarInterfaces();
            }
        }
        private void USUARIOSEdit_Load(object sender, EventArgs e)
        {
            this.US_USUARIOTextBox.Focus();
        }

        private void uCUSUARIOSEdit1_Load(object sender, EventArgs e)
        {

        }

        private void TSMLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPasswordInicial fPi = new FPasswordInicial(m_personaId, false,false);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
        }

        private void US_USUARIOLabel_Click(object sender, EventArgs e)
        {

        }

        private void ucAsignarPerfil1_Load(object sender, EventArgs e)
        {

        }
    }
}
