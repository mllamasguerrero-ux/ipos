

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;

namespace iPosData
{
	   
	

	public class CINCIDENCIAD
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
				this.iComentario= value;
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

	
		public CINCIDENCIABE  AgregarINCIDENCIAD(CINCIDENCIABE oCINCIDENCIA,FbTransaction st)
		{
			
	
			try
			{
				


				System.Collections.ArrayList parts = new ArrayList();
				FbParameter auxPar;

				 
				
	auxPar= new FbParameter("@ACTIVO", FbDbType.Char);
                                    if(!(bool)oCINCIDENCIA.isnull["IACTIVO"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.IACTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["ICREADOPOR_USERID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.ICREADOPOR_USERID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["IMODIFICADOPOR_USERID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.IMODIFICADOPOR_USERID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@TIPOINCIDENCIAID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["ITIPOINCIDENCIAID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.ITIPOINCIDENCIAID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@VENDEDORID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["IVENDEDORID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.IVENDEDORID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@DOCTOID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["IDOCTOID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.IDOCTOID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@MOVTOID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["IMOVTOID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.IMOVTOID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIA.isnull["IPRODUCTOID"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.IPRODUCTOID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@NOTA1", FbDbType.VarChar);
                                    if(!(bool)oCINCIDENCIA.isnull["INOTA1"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.INOTA1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@NOTA2", FbDbType.VarChar);
                                    if(!(bool)oCINCIDENCIA.isnull["INOTA2"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.INOTA2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CANTIDAD1", FbDbType.Numeric);
                                    if(!(bool)oCINCIDENCIA.isnull["ICANTIDAD1"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.ICANTIDAD1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				
	auxPar= new FbParameter("@CANTIDAD2", FbDbType.Numeric);
                                    if(!(bool)oCINCIDENCIA.isnull["ICANTIDAD2"])
                                    {
                                    auxPar.Value=oCINCIDENCIA.ICANTIDAD2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);


  string commandText = @"
        INSERT INTO INCIDENCIA
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

TIPOINCIDENCIAID,

VENDEDORID,

DOCTOID,

MOVTOID,

PRODUCTOID,

NOTA1,

NOTA2,

CANTIDAD1,

CANTIDAD2
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@TIPOINCIDENCIAID,

@VENDEDORID,

@DOCTOID,

@MOVTOID,

@PRODUCTOID,

@NOTA1,

@NOTA2,

@CANTIDAD1,

@CANTIDAD2
); ";

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  if(st==null)
  SqlHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  SqlHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);






  return oCINCIDENCIA;

  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return null;
  }
  }


  public bool BorrarINCIDENCIAD(CINCIDENCIABE oCINCIDENCIA,FbTransaction st)
  {


  try
  {
  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;



				auxPar= new FbParameter("@ID", FbDbType.BigInt);
                                auxPar.Value=oCINCIDENCIA.IID;
                                  parts.Add(auxPar);



  string commandText = @"  Delete from INCIDENCIA
  where

  ID=@ID
  ;";

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  if(st==null)
  SqlHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  SqlHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);


  return true;




  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }
  }


  public bool CambiarINCIDENCIAD(CINCIDENCIABE oCINCIDENCIANuevo,CINCIDENCIABE oCINCIDENCIAAnterior,FbTransaction st)
  {


  try
  {
  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;



				auxPar= new FbParameter("@ACTIVO", FbDbType.Char);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["IACTIVO"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.IACTIVO;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["ICREADOPOR_USERID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.ICREADOPOR_USERID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["IMODIFICADOPOR_USERID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.IMODIFICADOPOR_USERID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@TIPOINCIDENCIAID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["ITIPOINCIDENCIAID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.ITIPOINCIDENCIAID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@VENDEDORID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["IVENDEDORID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.IVENDEDORID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@DOCTOID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["IDOCTOID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.IDOCTOID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@MOVTOID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["IMOVTOID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.IMOVTOID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["IPRODUCTOID"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.IPRODUCTOID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@NOTA1", FbDbType.VarChar);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["INOTA1"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.INOTA1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@NOTA2", FbDbType.VarChar);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["INOTA2"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.INOTA2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CANTIDAD1", FbDbType.Numeric);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["ICANTIDAD1"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.ICANTIDAD1;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@CANTIDAD2", FbDbType.Numeric);
                                    if(!(bool)oCINCIDENCIANuevo.isnull["ICANTIDAD2"])
                                    {
                                auxPar.Value=oCINCIDENCIANuevo.ICANTIDAD2;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);

				auxPar= new FbParameter("@IDAnt", FbDbType.BigInt);
                                    if(!(bool)oCINCIDENCIAAnterior.isnull["IID"])
                                    {
                                auxPar.Value=oCINCIDENCIAAnterior.IID;
                                 }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);




string commandText = @"
  update  INCIDENCIA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

TIPOINCIDENCIAID=@TIPOINCIDENCIAID,

VENDEDORID=@VENDEDORID,

DOCTOID=@DOCTOID,

MOVTOID=@MOVTOID,

PRODUCTOID=@PRODUCTOID,

NOTA1=@NOTA1,

NOTA2=@NOTA2,

CANTIDAD1=@CANTIDAD1,

CANTIDAD2=@CANTIDAD2
  where 

ID=@IDAnt
  ;";

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);


  if(st==null)
  SqlHelper.ExecuteNonQuery(this.sCadenaConexion,CommandType.Text, commandText,arParms);
  else
  SqlHelper.ExecuteNonQuery(st,CommandType.Text, commandText,arParms);


  return true;


  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }
  }


  public CINCIDENCIABE seleccionarINCIDENCIA(CINCIDENCIABE oCINCIDENCIA,FbTransaction st)
  {




  CINCIDENCIABE retorno = new CINCIDENCIABE();
  FbDataReader dr = null;
            
  FbConnection pcn = null;

  try
  {

  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;

  String CmdTxt = @"select * from INCIDENCIA where
 ID=@ID  ";


				auxPar= new FbParameter("@ID", FbDbType.BigInt);
                                auxPar.Value=oCINCIDENCIA.IID;
                                  parts.Add(auxPar);
				



  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);



  if(st==null)
  dr = SqlHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, CmdTxt, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


  if (dr.Read())
  {

                                      if( dr["ID"]!= System.DBNull.Value)
                                     {
                                     retorno.IID=(long)(dr["ID"]);
                                    }

                                      if( dr["ACTIVO"]!= System.DBNull.Value)
                                     {
                                     retorno.IACTIVO=(string)(dr["ACTIVO"]);
                                    }

                                      if( dr["CREADO"]!= System.DBNull.Value)
                                     {
                                     retorno.ICREADO=(object)(dr["CREADO"]);
                                    }

                                      if( dr["CREADOPOR_USERID"]!= System.DBNull.Value)
                                     {
                                     retorno.ICREADOPOR_USERID=(long)(dr["CREADOPOR_USERID"]);
                                    }

                                      if( dr["MODIFICADO"]!= System.DBNull.Value)
                                     {
                                     retorno.IMODIFICADO=(object)(dr["MODIFICADO"]);
                                    }

                                      if( dr["MODIFICADOPOR_USERID"]!= System.DBNull.Value)
                                     {
                                     retorno.IMODIFICADOPOR_USERID=(long)(dr["MODIFICADOPOR_USERID"]);
                                    }

                                      if( dr["TIPOINCIDENCIAID"]!= System.DBNull.Value)
                                     {
                                     retorno.ITIPOINCIDENCIAID=(long)(dr["TIPOINCIDENCIAID"]);
                                    }

                                      if( dr["FECHAHORA"]!= System.DBNull.Value)
                                     {
                                     retorno.IFECHAHORA=(object)(dr["FECHAHORA"]);
                                    }

                                      if( dr["VENDEDORID"]!= System.DBNull.Value)
                                     {
                                     retorno.IVENDEDORID=(long)(dr["VENDEDORID"]);
                                    }

                                      if( dr["DOCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IDOCTOID=(long)(dr["DOCTOID"]);
                                    }

                                      if( dr["MOVTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IMOVTOID=(long)(dr["MOVTOID"]);
                                    }

                                      if( dr["PRODUCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IPRODUCTOID=(long)(dr["PRODUCTOID"]);
                                    }

                                      if( dr["NOTA1"]!= System.DBNull.Value)
                                     {
                                     retorno.INOTA1=(string)(dr["NOTA1"]);
                                    }

                                      if( dr["NOTA2"]!= System.DBNull.Value)
                                     {
                                     retorno.INOTA2=(string)(dr["NOTA2"]);
                                    }

                                      if( dr["CANTIDAD1"]!= System.DBNull.Value)
                                     {
                                     retorno.ICANTIDAD1=(decimal)(dr["CANTIDAD1"]);
                                    }

                                      if( dr["CANTIDAD2"]!= System.DBNull.Value)
                                     {
                                     retorno.ICANTIDAD2=(decimal)(dr["CANTIDAD2"]);
                                    }

				}
				else
				{
					retorno =null;
				}

				Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

				return retorno;
			}
			catch (Exception e)
			{
				Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}









		public DataSet enlistarINCIDENCIA()
		{
			
	DataSet retorno;
		try
			{
			retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion,CommandType.StoredProcedure, "iPos_INCIDENCIA_enlistar");
				
	return retorno;
			}
			catch (Exception e)
			{
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}




		public DataSet enlistarCortoINCIDENCIA()
		{
			DataSet retorno;
			try
			{
			
				retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion,CommandType.StoredProcedure, "iPos_INCIDENCIA_enlistarCorto");
				
				return retorno;
			}
			catch (Exception e)
			{
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}



		public int ExisteINCIDENCIA(CINCIDENCIABE oCINCIDENCIA,FbTransaction st)
		{
			//1-EXISTE 0-NO EXISTE -1 ERROR
			int retorno;
			FbDataReader dr = null;
            
			FbConnection pcn = null;

			try
			{
				System.Collections.ArrayList parts = new ArrayList();
				FbParameter auxPar;



				auxPar= new FbParameter("@ID", FbDbType.BigInt);
                                auxPar.Value=oCINCIDENCIA.IID;
                                  parts.Add(auxPar);

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);

  string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from INCIDENCIA where

  ID=@ID  
  );";






  if(st==null)
  dr = SqlHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, commandText, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, commandText,arParms);



  if (dr.Read())
  {
  retorno = 1;
  }
  else
  {
  retorno = 0;
  }

  Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
  return retorno;
  }
  catch (Exception e)
  {
  Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
  this.iComentario=e.Message + e.StackTrace;
  return -1;
  }
  }




  public CINCIDENCIABE AgregarINCIDENCIA(CINCIDENCIABE oCINCIDENCIA, FbTransaction st)
  {
  try
  {
  int iRes = ExisteINCIDENCIA(oCINCIDENCIA, st);
  if(iRes==1)
  {
  this.IComentario = "El INCIDENCIA ya existe";
  return null;
  }
  else if (iRes == -1)
  {
  return null;
  }
  return AgregarINCIDENCIAD(oCINCIDENCIA, st);
  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return null;
  }
  }


  public bool BorrarINCIDENCIA(CINCIDENCIABE oCINCIDENCIA, FbTransaction st)
  {
  try
  {
  int iRes = ExisteINCIDENCIA(oCINCIDENCIA, st);
  if(iRes==0)
  {
  this.IComentario = "El INCIDENCIA no existe";
  return false;
  }
  else if (iRes == -1)
  {
  return false;
  }
  return BorrarINCIDENCIAD(oCINCIDENCIA, st);
  }
  catch (Exception e)
  {
  this.iComentario=e.Message + e.StackTrace;
  return false;
  }

  }


  public bool CambiarINCIDENCIA(CINCIDENCIABE oCINCIDENCIANuevo, CINCIDENCIABE oCINCIDENCIAAnterior, FbTransaction st)
  {
  try
  {
  int iRes = ExisteINCIDENCIA(oCINCIDENCIAAnterior, st);
  if (iRes == 0)
  {
  this.IComentario = "El INCIDENCIA no existe";
  return false;
  }
  else if (iRes == -1)
  {
  return false;
  }
  return CambiarINCIDENCIAD( oCINCIDENCIANuevo,  oCINCIDENCIAAnterior,  st);
  }
  catch (Exception e)
  {
  this.iComentario = e.Message + e.StackTrace;
  return false;
  }

  }





  public CINCIDENCIAD()
  {
  this.sCadenaConexion=ConexionBD.ConexionString();
  //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


  //
  // TODO: Add constructor logic here
  //
  }
  }
  }
