
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using ConexionesBD;
using iPos.MultiEmpresa;
namespace iPos
{
    public partial class UCEMPRESASLista : IposForm
    {
        string uso;
        TextBox tbParent;
        TextBox tbParentDesc;
        public string EM_NOMBRECampo;
        public UCEMPRESASLista()
        {
            InitializeComponent();
        }
        public void Recargar(string puso, TextBox tb, TextBox tbDesc)
        {
            this.uso = puso;
            this.tbParent = tb;
            this.tbParentDesc = tbDesc;
            //this.Editar.Text = "Seleccionar";
            this.dataGridView1_EMPRESAS.Columns[0].Visible = false;
            this.dataGridView1_EMPRESAS.Columns[1].Visible = false;
            this.dataGridView1_EMPRESAS.Columns[2].Visible = true;
            //this.panel1_EMPRESAS.Enabled = false;
        }
        private void LlenarDataGrid_EMPRESAS()
        {
            try
            {
                CargarFiltro_EMPRESAS();
                dataGridView1_EMPRESAS.AutoGenerateColumns = false;
                bindingSource1_EMPRESAS.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_EMPRESAS, ConexionMEBD.ConexionString());
                dataGridView1_EMPRESAS.DataSource = bindingSource1_EMPRESAS;
                dataGridView1_EMPRESAS.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1_EMPRESAS.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1_EMPRESAS.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        private void EMPRESASLista_Load(object sender, EventArgs e)
        {
            LlenarDataGrid_EMPRESAS();
            this.DDBuscar_EMPRESAS.SelectedIndex = 0;
            this.DDOperador_EMPRESAS.SelectedIndex = 0;
        }
        private void CargarFiltro_EMPRESAS()
        {
            String CmdTxt, strOperador = "";
            this.FbCommand1_EMPRESAS.Parameters.Clear();
            string queryBasic = "Select e.*,case when c.CF_ID is null then 'NO' else 'SI' end EM_DEFAULT from EMPRESAS e left join CONFIGURACION c on e.em_nombre = c.CF_DEFAULT_DB where ";
            try
            {
                switch (this.DDOperador_EMPRESAS?.SelectedItem?.ToString())
                {
                    case "Igual":
                        strOperador = "=";
                        break;
                    case "Menor Igual":
                        strOperador = "<=";
                        break;
                    case "Mayor Igual":
                        strOperador = ">=";
                        break;
                    case "Empiece":
                        strOperador = "starting with";
                        break;
                    case "Contenga":
                        strOperador = "containing";
                        break;
                    default:
                        return;
                }
            }
            catch
            {
                return;
            }
            try
            {
                switch (this.DDBuscar_EMPRESAS.SelectedItem.ToString())
                {
                    case "EM_NOMBRE":
                        {
                            CmdTxt = queryBasic + this.DDBuscar_EMPRESAS.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString();
                            this.FbCommand1_EMPRESAS.CommandText = CmdTxt;
                            this.FbCommand1_EMPRESAS.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
  new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString(), FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 50)});
                            this.FbCommand1_EMPRESAS.Parameters["@vEM_NOMBRE"].Value = this.TBValor_EMPRESAS.Text;
                            break;
                        }
                    case "EM_DATABASE":
                        {
                            CmdTxt = queryBasic + this.DDBuscar_EMPRESAS.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString();
                            this.FbCommand1_EMPRESAS.CommandText = CmdTxt;
                            this.FbCommand1_EMPRESAS.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
  new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString(), FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 255)});
                            this.FbCommand1_EMPRESAS.Parameters["@vEM_DATABASE"].Value = this.TBValor_EMPRESAS.Text;
                            break;
                        }
                    case "EM_USUARIO":
                        {
                            CmdTxt = queryBasic + this.DDBuscar_EMPRESAS.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString();
                            this.FbCommand1_EMPRESAS.CommandText = CmdTxt;
                            this.FbCommand1_EMPRESAS.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
  new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString(), FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 50)});
                            this.FbCommand1_EMPRESAS.Parameters["@vEM_USUARIO"].Value = this.TBValor_EMPRESAS.Text;
                            break;
                        }
                    case "EM_PASSWORD":
                        {
                            CmdTxt = queryBasic + this.DDBuscar_EMPRESAS.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString();
                            this.FbCommand1_EMPRESAS.CommandText = CmdTxt;
                            this.FbCommand1_EMPRESAS.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
  new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString(), FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 50)});
                            this.FbCommand1_EMPRESAS.Parameters["@vEM_PASSWORD"].Value = this.TBValor_EMPRESAS.Text;
                            break;
                        }
                    case "EM_SERVER":
                        {
                            CmdTxt = queryBasic + this.DDBuscar_EMPRESAS.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString();
                            this.FbCommand1_EMPRESAS.CommandText = CmdTxt;
                            this.FbCommand1_EMPRESAS.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
  new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_EMPRESAS.SelectedItem.ToString(), FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 100)});
                            this.FbCommand1_EMPRESAS.Parameters["@vEM_SERVER"].Value = this.TBValor_EMPRESAS.Text;
                            break;
                        }
                }
            }
            catch
            {
            }
        }
        private void button1_EMPRESAS_Click(object sender, EventArgs e)
        {
            LlenarDataGrid_EMPRESAS();
        }
        private void button4_EMPRESAS_Click(object sender, EventArgs e)
        {
            try
            {
                EMPRESASEdit_Reg er = new EMPRESASEdit_Reg("Cambiar", (string)(this.dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value));
                er.ShowDialog();
                er.Dispose();
                GC.SuppressFinalize(er);
                mostrarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button7_EMPRESAS_Click(object sender, EventArgs e)
        {
            try
            {
                EMPRESASEdit_Reg er = new EMPRESASEdit_Reg("Agregar", null);
                er.ShowDialog();
                er.Dispose();
                GC.SuppressFinalize(er);
                mostrarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void mostrarTodos()
        {
            try
            {
                this.FbCommand1_EMPRESAS.Parameters.Clear();
                this.FbCommand1_EMPRESAS.CommandText = "Select e.*,case when c.CF_ID is null then 'NO' else 'SI' end EM_DEFAULT from EMPRESAS e left join CONFIGURACION c on e.em_nombre = c.CF_DEFAULT_DB ";
                dataGridView1_EMPRESAS.AutoGenerateColumns = false;
                bindingSource1_EMPRESAS.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_EMPRESAS, ConexionMEBD.ConexionString());
                dataGridView1_EMPRESAS.DataSource = bindingSource1_EMPRESAS;
                dataGridView1_EMPRESAS.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1_EMPRESAS.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1_EMPRESAS.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        
        }
        private void button3_EMPRESAS_Click(object sender, EventArgs e)
        {
            mostrarTodos();
        }
        //private void dataGridView1_EMPRESAS_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
            //try
            //{
            //    if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Seleccionar")
            //    {
            //        this.tbParent.Text = this.dataGridView1_EMPRESAS.Rows[e.RowIndex].Cells[3].Value.ToString();
            //        this.tbParentDesc.Text = this.dataGridView1_EMPRESAS.Rows[e.RowIndex].Cells[4].Value.ToString();
            //        Hashtable htEvt = new Hashtable();
            //        htEvt.Add("EM_NOMBRE", (string)(this.dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value));
            //        return;
            //    }
            //    if (this.EditedRow_EMPRESAS == -1 || this.EditedRow_EMPRESAS == e.RowIndex)
            //    {
            //        if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Edit" || this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Nuevo")
            //        {
            //            this.EditedRow_EMPRESAS = e.RowIndex;
            //            if (this.dataGridView1_EMPRESAS["Edit", e.RowIndex].Value.ToString() == "Edit")
            //            {
            //                this.EM_NOMBRECampo = (string)dataGridView1_EMPRESAS["dgEM_NOMBRE", e.RowIndex].Value;
            //            }
            //            if (this.dataGridView1_EMPRESAS["Edit", e.RowIndex].Value.ToString() == "Edit")
            //            {
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).UseColumnTextForButtonValue = false;
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).Value = "Cancelar";
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).UseColumnTextForButtonValue = false;
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).Value = "Guardar";
            //            }
            //            else
            //            {
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).UseColumnTextForButtonValue = false;
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).Value = "Quitar";
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).UseColumnTextForButtonValue = false;
            //                ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).Value = "Agregar";
            //            }
            //            dataGridView1_EMPRESAS.Rows[e.RowIndex].ReadOnly = false;
            //            this.dataGridView1_EMPRESAS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            //        }
            //        else if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Cancelar")
            //        {
            //            this.EditedRow_EMPRESAS = -1;
            //            dataGridView1_EMPRESAS.Rows[e.RowIndex].ReadOnly = true;
            //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).UseColumnTextForButtonValue = true;
            //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).UseColumnTextForButtonValue = true;
            //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).Value = "Cancelar";
            //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).Value = "Edit";
            //            this.dataGridView1_EMPRESAS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            //            ((DataTable)this.bindingSource1_EMPRESAS.DataSource).RejectChanges();
            //        }
            //        else if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Guardar")
            //        {
            //            if (CambiarDatos_EMPRESAS())
            //            {
            //                this.bindingSource1_EMPRESAS.EndEdit();
            //                ((DataTable)this.bindingSource1_EMPRESAS.DataSource).AcceptChanges();
            //                this.EditedRow_EMPRESAS = -1;
            //            }
            //        }
            //        else if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Agregar")
            //        {
            //            if (InsertarDatos_EMPRESAS())
            //            {
            //                this.bindingSource1_EMPRESAS.EndEdit();
            //                ((DataTable)this.bindingSource1_EMPRESAS.DataSource).AcceptChanges();
            //                this.EditedRow_EMPRESAS = -1;
            //            }
            //        }
            //        else if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Eliminar")
            //        {
            //            this.EM_NOMBRECampo = (string)dataGridView1_EMPRESAS["dgEM_NOMBRE", e.RowIndex].Value;
            //            if (MessageBox.Show("Esta seguro que desea eliminar el registro ", "Esta seguro que desea eliminar el registro ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                if (this.borrarDatos_EMPRESAS())
            //                {
            //                    if (!dataGridView1_EMPRESAS.Rows[e.RowIndex].IsNewRow)
            //                    {
            //                        dataGridView1_EMPRESAS.Rows.Remove(dataGridView1_EMPRESAS.Rows[e.RowIndex]);
            //                        ((DataTable)this.bindingSource1_EMPRESAS.DataSource).AcceptChanges();
            //                    }
            //                }
            //            }
            //        }
            //        else if (this.dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex].Value.ToString() == "Quitar")
            //        {
            //            this.EditedRow_EMPRESAS = -1;
            //            dataGridView1_EMPRESAS.Rows[e.RowIndex].ReadOnly = true;
            //            if (!dataGridView1_EMPRESAS.Rows[e.RowIndex].IsNewRow)
            //            {
            //                dataGridView1_EMPRESAS.Rows.Remove(dataGridView1_EMPRESAS.Rows[e.RowIndex]);
            //                ((DataTable)this.bindingSource1_EMPRESAS.DataSource).AcceptChanges();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("error " + ex.Message);
            //}
        //}
        private void dataGridView1_EMPRESAS_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dataGridView1_EMPRESAS.Rows[e.RowIndex].ReadOnly = true;
                //((DataGridViewButtonCell)dataGridView1_EMPRESAS[3, e.RowIndex]).Value = "Eliminar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void dataGridView1_EMPRESAS_RowLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        dataGridView1_EMPRESAS[e.RowIndex, 0].Selected = true;
        //        if (this.EditedRow_EMPRESAS == -1)
        //        {
        //            dataGridView1_EMPRESAS.Rows[e.RowIndex].ReadOnly = true;
        //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).UseColumnTextForButtonValue = true;
        //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).UseColumnTextForButtonValue = true;
        //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Cancelar", e.RowIndex]).Value = "Cancelar";
        //            ((DataGridViewButtonCell)dataGridView1_EMPRESAS["Edit", e.RowIndex]).Value = "Edit";
        //            this.dataGridView1_EMPRESAS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //        }
        //        else
        //        {
        //            dataGridView1_EMPRESAS["Cancelar", e.RowIndex].Selected = true;
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        private void dataGridView1_EMPRESAS_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridView1_EMPRESAS.CurrentCell = dataGridView1_EMPRESAS[e.ColumnIndex, e.RowIndex];
            bindingSource1_EMPRESAS.CancelEdit();
            MessageBox.Show("Ocurrio un error");
        }
        private void dataGridView1_EMPRESAS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private CEMPRESASBE ObtenerDatosCapturados_EMPRESAS()
        {
            CEMPRESASBE EMPRESASBE = new CEMPRESASBE();
            if (dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value != DBNull.Value)
            {
                EMPRESASBE.IEM_NOMBRE = (string)dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value;
            }
            if (dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_DATABASE"].Value != DBNull.Value)
            {
                EMPRESASBE.IEM_DATABASE = (string)dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_DATABASE"].Value;
            }
            if (dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_USUARIO"].Value != DBNull.Value)
            {
                EMPRESASBE.IEM_USUARIO = (string)dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_USUARIO"].Value;
            }
            if (dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_PASSWORD"].Value != DBNull.Value)
            {
                EMPRESASBE.IEM_PASSWORD = (string)dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_PASSWORD"].Value;
            }
            if (dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_SERVER"].Value != DBNull.Value)
            {
                EMPRESASBE.IEM_SERVER = (string)dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_SERVER"].Value;
            }
            return EMPRESASBE;
        }
        private void BTDefault_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value != null)
                {
                    CCONFIGURACIOND conf = new CCONFIGURACIOND();
                    if (!conf.CambiarBasePorDefault((string)(this.dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value) , null))
                    {
                        MessageBox.Show(conf.IComentario);
                        return;
                    }
                    MessageBox.Show("Se ha cambiado la base por default");

                    mostrarTodos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string ObtenerEmpresaPorDefault()
        {
            CCONFIGURACIONBE confBE = new CCONFIGURACIONBE();
            CCONFIGURACIOND confD = new CCONFIGURACIOND();
            confBE = confD.seleccionarCONFIGURACIONGen(null);
            if (confBE == null)
            {
                return null;
            }
            return confBE.ICF_DEFAULT_DB;
        }
        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (this.dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value != null)
                {
                    CCONFIGURACIOND conf = new CCONFIGURACIOND();
                    EM_NOMBRECampo = (string)(this.dataGridView1_EMPRESAS.CurrentRow.Cells["dgEM_NOMBRE"].Value);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EscPressed()
        {
            this.Close();
        }
        private void TSBCerrar_Click(object sender, EventArgs e)
        {
            EscPressed();
        }

        private void btnEditMachineConfig_Click(object sender, EventArgs e)
        {
            MachineConfig myMachineConfig = new MachineConfig();
            myMachineConfig.ShowDialog();
            myMachineConfig.Dispose();
            GC.SuppressFinalize(myMachineConfig);
        }

        private void btnEditarSincConfig_Click(object sender, EventArgs e)
        {
            WFSyncConfig syncConfigForm = new WFSyncConfig();
            syncConfigForm.ShowDialog();
            syncConfigForm.Dispose();
            GC.SuppressFinalize(syncConfigForm);
        }
        //private bool InsertarDatos_EMPRESAS()
        //{
        //    try
        //    {
        //        CEMPRESASD EMPRESASD = new CEMPRESASD();
        //        CEMPRESASBE EMPRESASBE = new CEMPRESASBE();
        //        EMPRESASBE = ObtenerDatosCapturados_EMPRESAS();
        //        EMPRESASD.AgregarEMPRESAS(EMPRESASBE, null);
        //        if (EMPRESASD.IComentario == "" || EMPRESASD.IComentario == null)
        //        {
        //            MessageBox.Show("El registro se ha insertado");
        //            return true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("ERRORES: " + EMPRESASD.IComentario.Replace("%", "\n"));
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        //private bool CambiarDatos_EMPRESAS()
        //{
        //    try
        //    {
        //        CEMPRESASD EMPRESASD = new CEMPRESASD();
        //        CEMPRESASBE EMPRESASBEAnt = new CEMPRESASBE();
        //        CEMPRESASBE EMPRESASBE = new CEMPRESASBE();
        //        EMPRESASBE = ObtenerDatosCapturados_EMPRESAS();
        //        EMPRESASBEAnt.IEM_NOMBRE = this.EM_NOMBRECampo;
        //        EMPRESASD.CambiarEMPRESAS(EMPRESASBE, EMPRESASBEAnt, null);
        //        if (EMPRESASD.IComentario == "" || EMPRESASD.IComentario == null)
        //        {
        //            MessageBox.Show("El registro se ha cambiado");
        //            return true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("ERRORES: " + EMPRESASD.IComentario.Replace("%", "\n"));
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        //private bool borrarDatos_EMPRESAS()
        //{
        //    try
        //    {
        //        CEMPRESASD EMPRESASD = new CEMPRESASD();
        //        CEMPRESASBE EMPRESASBEAnt = new CEMPRESASBE();
        //        EMPRESASBEAnt.IEM_NOMBRE = this.EM_NOMBRECampo;
        //        EMPRESASD.BorrarEMPRESAS(EMPRESASBEAnt, null);
        //        if (EMPRESASD.IComentario == "" || EMPRESASD.IComentario == null)
        //        {
        //            MessageBox.Show("El registro se ha eliminado");
        //            return true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("ERRORES: " + EMPRESASD.IComentario.Replace("%", "\n"));
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
    }
}

