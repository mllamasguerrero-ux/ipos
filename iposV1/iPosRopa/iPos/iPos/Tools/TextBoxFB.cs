using System;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.ComponentModel;
using ConexionesBD;
namespace iPos.Tools
{
    class TextBoxFB:TextBoxET
    {
        private string query;
        public string Query
        {
            get
            {
                return query;
            }
            set
            {
                this.query = value;
            }
        }
        private string titulo;
        public string Titulo
        {
            get
            {
                return titulo;
            }
            set
            {
                this.titulo = value;
            }
        }
        private string condicion;
        public string Condicion
        {
            get
            {
                return condicion;
            }
            set
            {
                this.condicion = value;
            }
        }
        private string queryDeSeleccion;
        public string QueryDeSeleccion
        {
            get
            {
                return queryDeSeleccion;
            }
            set
            {
                this.queryDeSeleccion = value;
            }
        }
        private FbDbType dataBaseType;
        public FbDbType DataBaseType
        {
            get
            {
                return dataBaseType;
            }
            set
            {
                this.dataBaseType = value;
            }
        }
        private string nombreCampoSelector;
        public string NombreCampoSelector
        {
            get
            {
                return nombreCampoSelector;
            }
            set
            {
                this.nombreCampoSelector = value;
            }
        }
        private Label labelDescription;
        public Label LabelDescription
        {
            get
            {
                return labelDescription;
            }
            set
            {
                this.labelDescription = value;
            }
        }


        [DefaultValue(0)]
        private int indiceCampoSelector;
        public int IndiceCampoSelector
        {
            get
            {
                return indiceCampoSelector;
            }
            set
            {
                this.indiceCampoSelector = value;
            }
        }
        [DefaultValue(1)]
        private int indiceCampoDescripcion;
        public int IndiceCampoDescripcion
        {
            get
            {
                return indiceCampoDescripcion;
            }
            set
            {
                this.indiceCampoDescripcion = value;
            }
        }


        [DefaultValue(0)]
        private int indiceCampoValue;
        public int IndiceCampoValue
        {
            get
            {
                return indiceCampoValue;
            }
            set
            {
                this.indiceCampoValue = value;
            }
        }


        private String dbValue;
        public String DbValue
        {
            get
            {
                return dbValue;
            }
            set
            {
                this.dbValue = value;
            }
        }


        private string queryPorDBValue;
        public string QueryPorDBValue
        {
            get
            {
                return queryPorDBValue;
            }
            set
            {
                this.queryPorDBValue = value;
            }
        }

        private FbDbType dbTypeDBValue;
        public FbDbType DbTypeDBValue
        {
            get
            {
                return dbTypeDBValue;
            }
            set
            {
                this.dbTypeDBValue = value;
            }
        }


        private string nombreCampoValue;
        public string NombreCampoValue
        {
            get
            {
                return nombreCampoValue;
            }
            set
            {
                this.nombreCampoValue = value;
            }
        }



        private TextBox textDescription;
        public TextBox TextDescription
        {
            get
            {
                return textDescription;
            }
            set
            {
                this.textDescription = value;
            }
        }

        private Button botonLookUp;
        public Button BotonLookUp
        {
            get
            {
                return botonLookUp;
            }
            set
            {
                this.botonLookUp = value;
                if (value != null)
                {
                    try
                    {
                        this.botonLookUp.Click -= new System.EventHandler(this.botonLookUp_Click);
                    }
                    catch
                    {
                    }
                    this.botonLookUp.Click += new System.EventHandler(this.botonLookUp_Click);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    ShowLookUp();
                }
            }
        }

        public bool MValidarEntrada(out string retComentario)
        {
           return MValidarEntrada(out retComentario, 0);
        }

        public bool MValidarEntrada(out string retComentario,int opcionSeleccion)
        {
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                retComentario = "";
                if ((opcionSeleccion == 0 && this.Text == "") || (opcionSeleccion != 0 && this.DbValue == ""))
                {
                    LabelDescription.Text = "...";
                    return true;
                }


                String CmdTxt = (opcionSeleccion == 0) ? queryDeSeleccion : queryPorDBValue;
                string strCampo = (opcionSeleccion == 0) ? nombreCampoSelector : nombreCampoValue;
                FbDbType dbType = (opcionSeleccion == 0) ? dataBaseType : dbTypeDBValue;


                System.Collections.ArrayList parts = new System.Collections.ArrayList();
                FbParameter auxPar;
               // String CmdTxt = queryDeSeleccion;
                //auxPar = new FbParameter(nombreCampoSelector, dataBaseType);
                auxPar = new FbParameter(strCampo, dbType);
                auxPar.Value = (opcionSeleccion == 0) ? this.Text : this.dbValue;

                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
                if (dr.Read())
                {
                    if (LabelDescription != null)
                    {
                        LabelDescription.Text = dr[indiceCampoDescripcion].ToString();
                    }
                    if (TextDescription != null)
                    {
                        TextDescription.Text = dr[indiceCampoDescripcion].ToString();
                    }

                    if(opcionSeleccion == 0) 
                        this.dbValue = dr[indiceCampoValue].ToString();
                    else
                        this.Text = dr[indiceCampoSelector].ToString();

                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                    return true;
                }
                else
                {
                    if (LabelDescription != null)
                    {
                        LabelDescription.Text = "...";
                    }
                    if (TextDescription != null)
                    {
                        TextDescription.Text = "...";
                    }

                    if (opcionSeleccion == 0)
                        this.dbValue = "";
                    else
                        this.Text = "";


                    if (this.MostrarErrores)
                    {
                        retComentario = ("El registro no existe, favor de verificar");
                    }
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                if (LabelDescription != null)
                {
                    LabelDescription.Text = "...";
                }
                if (TextDescription != null)
                {
                    TextDescription.Text = "...";
                }

                    retComentario = ("Error , por favor contactar al administrador" + ex.Message);
                    return false;
                
            }
        }



        protected override void OnValidated(EventArgs e)
        {
            if (ValidarEntrada)
            {
                string res ;
                if (!MValidarEntrada(out res))
                {
                    if (this.MostrarErrores)
                    {
                        MessageBox.Show(res);
                        this.Focus();
                    }
                }
                //try
                //{
                //System.Collections.ArrayList parts = new System.Collections.ArrayList();
                //FbParameter auxPar;
                //String CmdTxt = queryDeSeleccion; 
                //auxPar = new FbParameter(nombreCampoSelector,  dataBaseType);
                //auxPar.Value = this.Text;
                //parts.Add(auxPar);
                //FbParameter[] arParms = new FbParameter[parts.Count];
                //parts.CopyTo(arParms, 0);
                //FbDataReader dr = null;
                //dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, arParms);
                //if (dr.Read())
                //{
                //    if (LabelDescription != null)
                //    {
                //        LabelDescription.Text = dr[indiceCampoDescripcion].ToString();
                //    }
                //}
                //else
                //{
                //    if (this.MostrarErrores)
                //    {
                //        MessageBox.Show("El registro no existe, favor de verificar");
                //        this.Focus();
                //    }
                //}
                //}
                //catch (Exception)
                //{
                //    if (this.MostrarErrores)
                //    {
                //        MessageBox.Show("Error , por favor contactar al administrador");
                //        this.Focus();
                //    }
                //}
            }
            base.OnValidated(e);
        }
        public void ShowLookUp()
        {
            GeneralLookUp look = new GeneralLookUp(Query, Titulo);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.Text = dr[IndiceCampoSelector].ToString();
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BackColor = System.Drawing.Color.Snow;
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = System.Drawing.SystemColors.Window;
        }


        public void botonLookUp_Click(object sender, EventArgs e)
        {
            ShowLookUp();
            this.Focus();
        }
    }
}
