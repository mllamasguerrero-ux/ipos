using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using CsvFiles;

namespace iPosData
{
    public class CINVENTARIOSYNCD
    {

        private string sCadenaConexion;

        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }





        
        public Boolean ExportDataInventario(string pathDestino, String prefijo,ref ArrayList strErrores)
        {

            strErrores.Clear();

            try
            {
                this.iComentario = "";
                if (!exportarInvProdToCsv(null, pathDestino + "\\" + prefijo + "_PROD.csv"))
                {
                    strErrores.Add(this.iComentario);
                }


                this.iComentario = "";
                if (!exportarInvAlmacenToCsv(null, pathDestino + "\\" + prefijo + "_ALMACEN.csv"))
                {
                    strErrores.Add(this.iComentario);
                }


                this.iComentario = "";
                if (!exportarInvInventarioToCsv(null, pathDestino + "\\" + prefijo + "_INVENTARIO.csv"))
                {
                    strErrores.Add(this.iComentario);
                }


                if (strErrores.Count > 0)
                    return false;


                return true;


            }
            catch (Exception ex)
            {
                this.iComentario = ex.Message;
                strErrores.Add("ex.Message");
                return false;
            }

            //oleDbConn.Close();

            return true;
        }




        public bool exportarInvProdToCsv( FbTransaction st, string fileName)
        {

            //aqui van definiendo las clases que se usaran para exportar
            CPRODDATAINVBE csvItem = new CPRODDATAINVBE();


            //esto es muy parecido tiene que ver con firebir
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;



            try
            {
                CsvDefinition csvDef = new CsvDefinition();
                csvDef.FieldSeparator = char.Parse(",");
                csvDef.EndOfLine = "\r\n";
                csvDef.TextQualifier = '"';

                using (var csvFile = new CsvFile<CPRODDATAINVBE>(fileName, csvDef))
                {
                    parts = new ArrayList();

                    //aqui ponen el query
                    CmdTxt = @"SELECT 
                            PRODUCTO.CLAVE, PRODUCTO.NOMBRE, PRODUCTO.DESCRIPCION, PRODUCTO.DESCRIPCION1, PRODUCTO.DESCRIPCION2, PRODUCTO.EXISTENCIA,
                            PRODUCTO.INVENTARIABLE, PRODUCTO.MANEJALOTE, PRODUCTO.UNIDAD, COALESCE(PRODUCTO.EXISTENCIAAPARTADO,0) EXISTENCIAAPARTADO,
                            LINEA.CLAVE LINEACLAVE, LINEA.NOMBRE LINEANOMBRE,
                            MARCA.CLAVE MARCACLAVE, MARCA.NOMBRE MARCANOMBRE,
                            PRODUCTO.EAN

                            FROM PRODUCTO
                            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
                            LEFT JOIN MARCA ON MARCA.ID = PRODUCTO.MARCAID

                            WHERE PRODUCTO.INVENTARIABLE = 'S'

                            ";



                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (st == null)
                        dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                    else
                        dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                    while (dr.Read())
                    {

                        //van llenando la table csv.. yo en este caso voy llenando un objeto para después enviarlo al dbf.. en su caso deben de definir como hacerlo

                        csvItem = new CPRODDATAINVBE();

                        if (dr["CLAVE"] != System.DBNull.Value)
                        {
                            csvItem.Clave = (string)dr["CLAVE"];
                        }

                        if (dr["NOMBRE"] != System.DBNull.Value)
                        {
                            csvItem.Nombre = (string)dr["NOMBRE"];
                        }

                        if (dr["DESCRIPCION"] != System.DBNull.Value)
                        {
                            csvItem.Descripcion = (string)dr["DESCRIPCION"];
                        }

                        if (dr["DESCRIPCION1"] != System.DBNull.Value)
                        {
                            csvItem.Descripcion1 = (string)dr["DESCRIPCION1"];
                        }

                        if (dr["DESCRIPCION2"] != System.DBNull.Value)
                        {
                            csvItem.Descripcion2 = (string)dr["DESCRIPCION2"];
                        }

                        if (dr["EXISTENCIA"] != System.DBNull.Value)
                        {
                            csvItem.Existencia = (decimal)dr["EXISTENCIA"];
                        }
                        if (dr["INVENTARIABLE"] != System.DBNull.Value)
                        {
                            csvItem.Inventariable = (string)dr["INVENTARIABLE"];
                        }

                        if (dr["MANEJALOTE"] != System.DBNull.Value)
                        {
                            csvItem.ManejaLote = (string)dr["MANEJALOTE"];
                        }

                        if (dr["UNIDAD"] != System.DBNull.Value)
                        {
                            csvItem.Unidad = (string)dr["UNIDAD"];
                        }
                        if (dr["EXISTENCIAAPARTADO"] != System.DBNull.Value)
                        {
                            csvItem.ExistenciaApartado = (decimal)dr["EXISTENCIAAPARTADO"];
                        }

                        if (dr["LINEACLAVE"] != System.DBNull.Value)
                        {
                            csvItem.LineaClave = (string)dr["LINEACLAVE"];
                        }

                        if (dr["LINEANOMBRE"] != System.DBNull.Value)
                        {
                            csvItem.LineaNombre = (string)dr["LINEANOMBRE"];
                        }

                        if (dr["MARCACLAVE"] != System.DBNull.Value)
                        {
                            csvItem.MarcaClave = (string)dr["MARCACLAVE"];
                        }

                        if (dr["MARCANOMBRE"] != System.DBNull.Value)
                        {
                            csvItem.MarcaNombre = (string)dr["MARCANOMBRE"];
                        }

                        if (dr["EAN"] != System.DBNull.Value)
                        {
                            csvItem.Ean = (string)dr["EAN"];
                        }
                        //aqui lo agrego al csv
                        csvFile.Append(csvItem);



                    }
                } 
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarInvAlmacenToCsv(FbTransaction st, string fileName)
        {


            //aqui van definiendo las clases que se usaran para exportar
            CALMACENDATAINVBE csvItem = new CALMACENDATAINVBE();


            //esto es muy parecido tiene que ver con firebir
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;



            try
            {
                CsvDefinition csvDef = new CsvDefinition();
                csvDef.FieldSeparator = char.Parse(",");
                csvDef.EndOfLine = "\r\n";
                csvDef.TextQualifier = '"';

                using (var csvFile = new CsvFile<CALMACENDATAINVBE>(fileName, csvDef))
                {
                    parts = new ArrayList();

                    //aqui ponen el query
                    CmdTxt = @"SELECT ALMACEN.ID ALMACENID, ALMACEN.CLAVE, ALMACEN.NOMBRE
                            FROM ALMACEN
                            ";



                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (st == null)
                        dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                    else
                        dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                    while (dr.Read())
                    {

                        //van llenando la table csv.. yo en este caso voy llenando un objeto para después enviarlo al dbf.. en su caso deben de definir como hacerlo

                        csvItem = new CALMACENDATAINVBE();

                        if (dr["ALMACENID"] != System.DBNull.Value)
                        {
                            csvItem.AlmacenId = (long)dr["ALMACENID"];
                        }

                        if (dr["CLAVE"] != System.DBNull.Value)
                        {
                            csvItem.Clave = (string)dr["CLAVE"];
                        }

                        if (dr["NOMBRE"] != System.DBNull.Value)
                        {
                            csvItem.Nombre = (string)dr["NOMBRE"];
                        }

                       

                        //aqui lo agrego al csv
                        csvFile.Append(csvItem);



                    }
                } 
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }



        public bool exportarInvInventarioToCsv( FbTransaction st, string fileName)
        {


            //aqui van definiendo las clases que se usaran para exportar
            CINVDATAINVBE csvItem = new CINVDATAINVBE();


            //esto es muy parecido tiene que ver con firebir
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;



            try
            {
                CsvDefinition csvDef = new CsvDefinition();
                csvDef.FieldSeparator = char.Parse(",");
                csvDef.EndOfLine = "\r\n";
                csvDef.TextQualifier = '"';

                using (var csvFile = new CsvFile<CINVDATAINVBE>(fileName, csvDef))
                {
                    parts = new ArrayList();

                    //aqui ponen el query
                    CmdTxt = @"SELECT 

                                ALMACEN.CLAVE ALMACENCLAVE,
                                PRODUCTO.CLAVE,
                                INVENTARIO.LOTE,
                                INVENTARIO.FECHAVENCE,
                                SUM(COALESCE(INVENTARIO.CANTIDAD,0)) CANTIDAD

                                FROM INVENTARIO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = INVENTARIO.PRODUCTOID
                                LEFT JOIN ALMACEN ON ALMACEN.ID = INVENTARIO.ALMACENID
                                GROUP BY INVENTARIO.ALMACENID, ALMACEN.CLAVE,  INVENTARIO.PRODUCTOID, PRODUCTO.CLAVE, INVENTARIO.LOTE, INVENTARIO.FECHAVENCE


                            ";



                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (st == null)
                        dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                    else
                        dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                    while (dr.Read())
                    {

                        //van llenando la table csv.. yo en este caso voy llenando un objeto para después enviarlo al dbf.. en su caso deben de definir como hacerlo

                        csvItem = new CINVDATAINVBE();

                        if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                        {
                            csvItem.AlmacenClave = (string)dr["ALMACENCLAVE"];
                        }
                        if (dr["CLAVE"] != System.DBNull.Value)
                        {
                            csvItem.Clave = (string)dr["CLAVE"];
                        }
                        if (dr["LOTE"] != System.DBNull.Value)
                        {
                            csvItem.Lote = (string)dr["LOTE"];
                        }

                        if (dr["FECHAVENCE"] != System.DBNull.Value)
                        {
                            csvItem.FechaVence = (DateTime)dr["FECHAVENCE"];
                        }

                        if (dr["CANTIDAD"] != System.DBNull.Value)
                        {
                            csvItem.Cantidad = (decimal)dr["CANTIDAD"];
                        }

                        //aqui lo agrego al csv
                        csvFile.Append(csvItem);



                    }
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }


        public bool exportarInvUsuarioToCsv(FbTransaction st, string fileName)
        {


            //aqui van definiendo las clases que se usaran para exportar
            CINVDATAINVBE csvItem = new CINVDATAINVBE();


            //esto es muy parecido tiene que ver con firebir
            this.iComentario = "";
            FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;



            try
            {
                CsvDefinition csvDef = new CsvDefinition();
                csvDef.FieldSeparator = char.Parse(",");
                csvDef.EndOfLine = "\r\n";
                csvDef.TextQualifier = '"';

                using (var csvFile = new CsvFile<CINVDATAINVBE>(fileName, csvDef))
                {
                    parts = new ArrayList();

                    //aqui ponen el query
                    CmdTxt = @"SELECT 

                                ALMACEN.CLAVE ALMACENCLAVE,
                                PRODUCTO.CLAVE,
                                INVENTARIO.LOTE,
                                INVENTARIO.FECHAVENCE,
                                SUM(COALESCE(INVENTARIO.CANTIDAD,0)) CANTIDAD

                                FROM INVENTARIO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = INVENTARIO.PRODUCTOID
                                LEFT JOIN ALMACEN ON ALMACEN.ID = INVENTARIO.ALMACENID
                                GROUP BY INVENTARIO.ALMACENID, ALMACEN.CLAVE,  INVENTARIO.PRODUCTOID, PRODUCTO.CLAVE, INVENTARIO.LOTE, INVENTARIO.FECHAVENCE


                            ";



                    arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);

                    if (st == null)
                        dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                    else
                        dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                    while (dr.Read())
                    {

                        //van llenando la table csv.. yo en este caso voy llenando un objeto para después enviarlo al dbf.. en su caso deben de definir como hacerlo

                        csvItem = new CINVDATAINVBE();

                        if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                        {
                            csvItem.AlmacenClave = (string)dr["ALMACENCLAVE"];
                        }
                        if (dr["CLAVE"] != System.DBNull.Value)
                        {
                            csvItem.Clave = (string)dr["CLAVE"];
                        }
                        if (dr["LOTE"] != System.DBNull.Value)
                        {
                            csvItem.Lote = (string)dr["LOTE"];
                        }

                        if (dr["FECHAVENCE"] != System.DBNull.Value)
                        {
                            csvItem.FechaVence = (DateTime)dr["FECHAVENCE"];
                        }

                        if (dr["CANTIDAD"] != System.DBNull.Value)
                        {
                            csvItem.Cantidad = (decimal)dr["CANTIDAD"];
                        }

                        //aqui lo agrego al csv
                        csvFile.Append(csvItem);



                    }
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

       
        public CINVENTARIOSYNCD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }

    }
}
