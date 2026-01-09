
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;
using System.Data.Common;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using FirebirdSql.Data.FirebirdClient;
using Controllers.Controller;
using BindingModels;
using System.Data;

namespace IposV3.Services
{



    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class ProveedorImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Proveedor.AsNoTracking()
                                                 .Include(x => x.Contacto1).ThenInclude(y => y!.Domicilio)
                                                 .Include(x => x.Contacto2).ThenInclude(y => y!.Domicilio)
                                                 .Include(x => x.Domicilio)
                                                 .Include(x => x.Proveedor_pago_parametros)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Telefono1", x.Telefono1, ""),
                                                        new ImpoExpoValor("Telefono2", x.Telefono2, ""),
                                                        new ImpoExpoValor("Telefono3", x.Telefono3, ""),
                                                        new ImpoExpoValor("Celular", x.Celular, ""),
                                                        new ImpoExpoValor("Nextel", x.Nextel, ""),
                                                        new ImpoExpoValor("Email1", x.Email1, ""),
                                                        new ImpoExpoValor("Email2", x.Email2, ""),
                                                        new ImpoExpoValor("Esimportador", x.Esimportador, BoolCN.N),
                                                        new ImpoExpoValor("Nombres", x.Nombres, ""),
                                                        new ImpoExpoValor("Apellidos", x.Apellidos, ""),
                                                        new ImpoExpoValor("Razonsocial", x.Razonsocial, ""),
                                                        new ImpoExpoValor("Rfc", x.Rfc, ""),
                                                        new ImpoExpoValor("Contacto1_Nombre", x.Contacto1!.Nombre, ""),
                                                        new ImpoExpoValor("Contacto1_Email", x.Contacto1.Email, ""),
                                                        new ImpoExpoValor("Contacto1_Telefono1", x.Contacto1.Telefono1, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Calle", x.Contacto1.Domicilio!.Calle, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Numeroexterior", x.Contacto1.Domicilio.Numeroexterior, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Numerointerior", x.Contacto1.Domicilio.Numerointerior, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Colonia", x.Contacto1.Domicilio.Colonia, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Ciudad", x.Contacto1.Domicilio.Ciudad, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Municipio", x.Contacto1.Domicilio.Municipio, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Estado", x.Contacto1.Domicilio.Estado, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Pais", x.Contacto1.Domicilio.Pais, ""),
                                                        new ImpoExpoValor("Contacto1_Domicilio_Codigopostal", x.Contacto1.Domicilio.Codigopostal, ""),
                                                        new ImpoExpoValor("Contacto2_Nombre", x.Contacto2!.Nombre, ""),
                                                        new ImpoExpoValor("Contacto2_Email", x.Contacto2.Email, ""),
                                                        new ImpoExpoValor("Contacto2_Telefono1", x.Contacto2.Telefono1, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Calle", x.Contacto2.Domicilio!.Calle, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Numeroexterior", x.Contacto2.Domicilio.Numeroexterior, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Numerointerior", x.Contacto2.Domicilio.Numerointerior, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Colonia", x.Contacto2.Domicilio.Colonia, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Ciudad", x.Contacto2.Domicilio.Ciudad, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Municipio", x.Contacto2.Domicilio.Municipio, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Estado", x.Contacto2.Domicilio.Estado, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Pais", x.Contacto2.Domicilio.Pais, ""),
                                                        new ImpoExpoValor("Contacto2_Domicilio_Codigopostal", x.Contacto2.Domicilio.Codigopostal, ""),
                                                        new ImpoExpoValor("Domicilio_Calle", x.Domicilio!.Calle, ""),
                                                        new ImpoExpoValor("Domicilio_Numeroexterior", x.Domicilio.Numeroexterior, ""),
                                                        new ImpoExpoValor("Domicilio_Numerointerior", x.Domicilio.Numerointerior, ""),
                                                        new ImpoExpoValor("Domicilio_Colonia", x.Domicilio.Colonia, ""),
                                                        new ImpoExpoValor("Domicilio_Ciudad", x.Domicilio.Ciudad, ""),
                                                        new ImpoExpoValor("Domicilio_Municipio", x.Domicilio.Municipio, ""),
                                                        new ImpoExpoValor("Domicilio_Estado", x.Domicilio.Estado, ""),
                                                        new ImpoExpoValor("Domicilio_Pais", x.Domicilio.Pais, ""),
                                                        new ImpoExpoValor("Domicilio_Codigopostal", x.Domicilio.Codigopostal, ""),
                                                        new ImpoExpoValor("Proveedor_pago_parametros_Revision", x.Proveedor_pago_parametros!.Revision, ""),
                                                        new ImpoExpoValor("Proveedor_pago_parametros_Pagos", x.Proveedor_pago_parametros.Pagos, ""),
                                                        new ImpoExpoValor("Proveedor_pago_parametros_Dias", x.Proveedor_pago_parametros.Dias, ""),
                                                        new ImpoExpoValor("Proveedor_pago_parametros_Adescpes", x.Proveedor_pago_parametros.Adescpes, 0),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Telefono1","tel1",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Telefono2","tel2",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Telefono3","tel3",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Celular","celular",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nextel","nextel",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Email1","email1",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Email2","email2",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Esimportador","esimpo",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Nombres","nombres",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Apellidos","apellidos",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Razonsocial","razonsocia",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Rfc","rfc",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Nombre","c1nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Email","c1email",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Telefono1","c1tel1",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Calle","c1domcall",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Numeroexterior","c1domne",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Numerointerior","c1domni",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Colonia","c1domcol",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Ciudad","c1domcd",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Municipio","c1dommun",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Estado","c1domedo",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Pais","c1dompais",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto1_Domicilio_Codigopostal","c1domcp",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Nombre","c2nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Email","c2email",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Telefono1","c2tel1",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Calle","c2domcall",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Numeroexterior","c2domne",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Numerointerior","c2domni",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Colonia","c2domcol",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Ciudad","c2domcd",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Municipio","c2dommun",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Estado","c2domedo",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Pais","c2dompais",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Contacto2_Domicilio_Codigopostal","c2domcp",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Calle","domcalle",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Numeroexterior","domne",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Numerointerior","domni",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Colonia","domcol",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Ciudad","domcd",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Municipio","dommun",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Estado","domedo",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Pais","dompais",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Domicilio_Codigopostal","domcp",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor_pago_parametros_Revision","revision",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor_pago_parametros_Pagos","pagos",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Proveedor_pago_parametros_Dias","dias",8,0, NpgsqlDbType.Integer, typeof(int)),
                new ImpoExpoField("Proveedor_pago_parametros_Adescpes","adescpes",18,4, NpgsqlDbType.Numeric, typeof(decimal)),
                new ImpoExpoField("Nombre","nombre",254,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Proveedor
                                        .Include( p => p.Contacto1).ThenInclude(c => c!.Domicilio)
                                        .Include(p => p.Contacto2).ThenInclude(c => c!.Domicilio)
                                        .Include(p => p.Proveedor_pago_parametros)
                                        .Include(p => p.Domicilio)
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Proveedor();
            var existItem = itemSaved != null;

	
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Telefono1 = dataReader["tel1"] != System.DBNull.Value ? ((string)dataReader["tel1"]).Trim() : ""; 
          	item.Telefono2 = dataReader["tel2"] != System.DBNull.Value ? ((string)dataReader["tel2"]).Trim() : ""; 
          	item.Telefono3 = dataReader["tel3"] != System.DBNull.Value ? ((string)dataReader["tel3"]).Trim() : ""; 
          	item.Celular = dataReader["celular"] != System.DBNull.Value ? ((string)dataReader["celular"]).Trim() : ""; 
          	item.Nextel = dataReader["nextel"] != System.DBNull.Value ? ((string)dataReader["nextel"]).Trim() : ""; 
          	item.Email1 = dataReader["email1"] != System.DBNull.Value ? ((string)dataReader["email1"]).Trim() : ""; 
          	item.Email2 = dataReader["email2"] != System.DBNull.Value ? ((string)dataReader["email2"]).Trim() : ""; 
          	item.Nombres = dataReader["nombres"] != System.DBNull.Value ? ((string)dataReader["nombres"]).Trim() : ""; 
          	item.Apellidos = dataReader["apellidos"] != System.DBNull.Value ? ((string)dataReader["apellidos"]).Trim() : ""; 
          	item.Razonsocial = dataReader["razonsocia"] != System.DBNull.Value ? ((string)dataReader["razonsocia"]).Trim() : ""; 
          	item.Rfc = dataReader["rfc"] != System.DBNull.Value ? ((string)dataReader["rfc"]).Trim() : "";

            //item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : "";
            item.Esimportador = dataReader["esimpo"] != System.DBNull.Value && ((string)dataReader["esimpo"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;


            bufferStr = dataReader["c1nombre"] != System.DBNull.Value ? ((string)dataReader["c1nombre"]).Trim() : "";
            if(bufferStr != null && bufferStr.Length > 0)
            {
                if(item.Contacto1  == null)
                    item.Contacto1 = new Contacto() { EmpresaId = empresaId, SucursalId = sucursalId };

                item.Contacto1.Nombre = dataReader["c1nombre"] != System.DBNull.Value ? ((string)dataReader["c1nombre"]).Trim() : "";
                item.Contacto1.Email = dataReader["c1email"] != System.DBNull.Value ? ((string)dataReader["c1email"]).Trim() : "";
                item.Contacto1.Telefono1 = dataReader["c1tel1"] != System.DBNull.Value ? ((string)dataReader["c1tel1"]).Trim() : "";

                bufferStr = dataReader["c1domcall"] != System.DBNull.Value ? ((string)dataReader["c1domcall"]).Trim() : "";
                if(bufferStr != null && bufferStr.Length > 0)
                {
                    if (item.Contacto1.Domicilio == null)
                        item.Contacto1.Domicilio = new Domicilio() { EmpresaId = empresaId, SucursalId = sucursalId };

                    item.Contacto1.Domicilio.Calle = dataReader["c1domcall"] != System.DBNull.Value ? ((string)dataReader["c1domcall"]).Trim() : "";
                    item.Contacto1.Domicilio.Numeroexterior = dataReader["c1domne"] != System.DBNull.Value ? ((string)dataReader["c1domne"]).Trim() : "";
                    item.Contacto1.Domicilio.Numerointerior = dataReader["c1domni"] != System.DBNull.Value ? ((string)dataReader["c1domni"]).Trim() : "";
                    item.Contacto1.Domicilio.Colonia = dataReader["c1domcol"] != System.DBNull.Value ? ((string)dataReader["c1domcol"]).Trim() : "";
                    item.Contacto1.Domicilio.Ciudad = dataReader["c1domcd"] != System.DBNull.Value ? ((string)dataReader["c1domcd"]).Trim() : "";
                    item.Contacto1.Domicilio.Municipio = dataReader["c1dommun"] != System.DBNull.Value ? ((string)dataReader["c1dommun"]).Trim() : "";
                    item.Contacto1.Domicilio.Estado = dataReader["c1domedo"] != System.DBNull.Value ? ((string)dataReader["c1domedo"]).Trim() : "";
                    item.Contacto1.Domicilio.Pais = dataReader["c1dompais"] != System.DBNull.Value ? ((string)dataReader["c1dompais"]).Trim() : "";
                    item.Contacto1.Domicilio.Codigopostal = dataReader["c1domcp"] != System.DBNull.Value ? ((string)dataReader["c1domcp"]).Trim() : "";

                }
            }


            bufferStr = dataReader["c2nombre"] != System.DBNull.Value ? ((string)dataReader["c2nombre"]).Trim() : "";
            if (bufferStr != null && bufferStr.Length > 0)
            {
                if (item.Contacto2 == null)
                    item.Contacto2 = new Contacto() { EmpresaId = empresaId, SucursalId = sucursalId };

                item.Contacto2.Nombre = dataReader["c2nombre"] != System.DBNull.Value ? ((string)dataReader["c2nombre"]).Trim() : "";
                item.Contacto2.Email = dataReader["c2email"] != System.DBNull.Value ? ((string)dataReader["c2email"]).Trim() : "";
                item.Contacto2.Telefono1 = dataReader["c2tel1"] != System.DBNull.Value ? ((string)dataReader["c2tel1"]).Trim() : "";

                bufferStr = dataReader["c2domcall"] != System.DBNull.Value ? ((string)dataReader["c2domcall"]).Trim() : "";
                if (bufferStr != null && bufferStr.Length > 0)
                {
                    if (item.Contacto2.Domicilio == null)
                        item.Contacto2.Domicilio = new Domicilio() { EmpresaId = empresaId, SucursalId = sucursalId };

                    item.Contacto2.Domicilio.Calle = dataReader["c2domcall"] != System.DBNull.Value ? ((string)dataReader["c2domcall"]).Trim() : "";
                    item.Contacto2.Domicilio.Numeroexterior = dataReader["c2domne"] != System.DBNull.Value ? ((string)dataReader["c2domne"]).Trim() : "";
                    item.Contacto2.Domicilio.Numerointerior = dataReader["c2domni"] != System.DBNull.Value ? ((string)dataReader["c2domni"]).Trim() : "";
                    item.Contacto2.Domicilio.Colonia = dataReader["c2domcol"] != System.DBNull.Value ? ((string)dataReader["c2domcol"]).Trim() : "";
                    item.Contacto2.Domicilio.Ciudad = dataReader["c2domcd"] != System.DBNull.Value ? ((string)dataReader["c2domcd"]).Trim() : "";
                    item.Contacto2.Domicilio.Municipio = dataReader["c2dommun"] != System.DBNull.Value ? ((string)dataReader["c2dommun"]).Trim() : "";
                    item.Contacto2.Domicilio.Estado = dataReader["c2domedo"] != System.DBNull.Value ? ((string)dataReader["c2domedo"]).Trim() : "";
                    item.Contacto2.Domicilio.Pais = dataReader["c2dompais"] != System.DBNull.Value ? ((string)dataReader["c2dompais"]).Trim() : "";
                    item.Contacto2.Domicilio.Codigopostal = dataReader["c2domcp"] != System.DBNull.Value ? ((string)dataReader["c2domcp"]).Trim() : "";

                }
            }




            bufferStr = dataReader["domcalle"] != System.DBNull.Value ? ((string)dataReader["domcalle"]).Trim() : "";
            if (bufferStr != null && bufferStr.Length > 0)
            {

                if (item.Domicilio == null)
                    item.Domicilio = new Domicilio() { EmpresaId = empresaId, SucursalId = sucursalId };

                item.Domicilio.Calle = dataReader["domcalle"] != System.DBNull.Value ? ((string)dataReader["domcalle"]).Trim() : "";
                item.Domicilio.Numeroexterior = dataReader["domne"] != System.DBNull.Value ? ((string)dataReader["domne"]).Trim() : "";
                item.Domicilio.Numerointerior = dataReader["domni"] != System.DBNull.Value ? ((string)dataReader["domni"]).Trim() : "";
                item.Domicilio.Colonia = dataReader["domcol"] != System.DBNull.Value ? ((string)dataReader["domcol"]).Trim() : "";
                item.Domicilio.Ciudad = dataReader["domcd"] != System.DBNull.Value ? ((string)dataReader["domcd"]).Trim() : "";
                item.Domicilio.Municipio = dataReader["dommun"] != System.DBNull.Value ? ((string)dataReader["dommun"]).Trim() : "";
                item.Domicilio.Estado = dataReader["domedo"] != System.DBNull.Value ? ((string)dataReader["domedo"]).Trim() : "";
                item.Domicilio.Pais = dataReader["dompais"] != System.DBNull.Value ? ((string)dataReader["dompais"]).Trim() : "";
                item.Domicilio.Codigopostal = dataReader["domcp"] != System.DBNull.Value ? ((string)dataReader["domcp"]).Trim() : "";
            }


            if (item.Proveedor_pago_parametros == null)
                item.Proveedor_pago_parametros = new Proveedor_pago_parametros() { EmpresaId = empresaId, SucursalId = sucursalId };

            item.Proveedor_pago_parametros.Revision = dataReader["revision"] != System.DBNull.Value ? ((string)dataReader["revision"]).Trim() : ""; 
          	item.Proveedor_pago_parametros.Pagos = dataReader["pagos"] != System.DBNull.Value ? ((string)dataReader["pagos"]).Trim() : ""; 
          	item.Proveedor_pago_parametros.Adescpes = dataReader["adescpes"] != System.DBNull.Value ? (decimal)dataReader["adescpes"] : 0; 
		    item.Proveedor_pago_parametros.Dias = dataReader["dias"] != System.DBNull.Value ? int.Parse(dataReader["dias"].ToString()!) : (int?)null; 


            if (existItem)
                localContext.Proveedor.Update(item);
            else
                localContext.Proveedor.Add(item);

            localContext.SaveChanges();

            return true;
        }





        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, ProveedorController proveedorController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT
          PERSONA.CLAVE as CLAVE, 
          PERSONA.NOMBRES as NOMBRES,
          PERSONA.APELLIDOS as APELLIDOS,
          PERSONA.RAZONSOCIAL as RAZONSOCIAL, 
          PERSONA.RFC as RFC, 
          PERSONA.TELEFONO1 as TELEFONO1, 
          PERSONA.TELEFONO2 as TELEFONO2, 
          PERSONA.TELEFONO3 as TELEFONO3, 
          PERSONA.CELULAR as CELULAR, 
          PERSONA.NEXTEL as NEXTEL, 
          PERSONA.EMAIL1 as EMAIL1, 
          PERSONA.EMAIL2 as EMAIL2, 
          PERSONA.DOMICILIO as DOMICILIO_CALLE, 
          PERSONA.NUMEROINTERIOR as DOMICILIO_NUMEROEXTERIOR, 
          PERSONA.NUMEROEXTERIOR as DOMICILIO_NUMEROINTERIOR, 
          PERSONA.COLONIA as DOMICILIO_COLONIA, 
          PERSONA.CIUDAD as DOMICILIO_CIUDAD, 
          PERSONA.MUNICIPIO as DOMICILIO_MUNICIPIO, 
          PERSONA.ESTADO as DOMICILIO_ESTADO, 
          PERSONA.PAIS as DOMICILIO_PAIS, 
          PERSONA.CODIGOPOSTAL as DOMICILIO_CODIGOPOSTAL, 
          PERSONA.REFERENCIADOM as DOMICILIO_REFERENCIA, 
          PERSONA.CONTACTO1 as CONTACTO1_NOMBRE, 
          PERSONA.CONTACTO2 as CONTACTO2_NOMBRE,
          PERSONA.ACTIVO as ACTIVO,
          PERSONA.CREADO as CREADO, 
          PERSONA.MODIFICADO as MODIFICADO, 
          PERSONA.VIGENCIA as VIGENCIA,
          PERSONA.REVISION as PROVEEDOR_PAGO_PARAMETROS_REVISION,
          PERSONA.PAGOS as PROVEEDOR_PAGO_PARAMETROS_PAGOS,
          PERSONA.ESIMPORTADOR,
          PERSONA.SALDO as PROVEEDOR_PAGO_SALDO,      
          PERSONA.SALDOSPOSITIVOS as PROVEEDOR_PAGO_SALDOSPOSITIVOS,
          PERSONA.SALDOSNEGATIVOS as PROVEEDOR_PAGO_SALDOSNEGATIVOS,
          PERSONA.DIAS PROVEEDOR_PAGO_PARAMETROS_DIAS,
          PERSONA.adescpes  PROVEEDOR_PAGO_PARAMETROS_ADESCPES,
          PROVEECLIENTE.clave  PROVEECLIENTECLAVE ,
          VENDEDORCOMISION.clave VENDEDORCLAVE ,
          LISTAPRECIO.CLAVE LISTAPRECIOCLAVE,
          SALUDO.CLAVE SALUDOCLAVE,
          PERSONA.NOMBRE
        FROM PERSONA
            LEFT JOIN PERSONA PROVEECLIENTE ON PROVEECLIENTE.ID =  PERSONA.PROVEECLIENTEID
            LEFT JOIN PERSONA VENDEDORCOMISION ON VENDEDORCOMISION.ID = PERSONA.vendedorid 
            LEFT JOIN listaprecio ON LISTAPRECIO.ID = PERSONA.listaprecioid
            LEFT JOIN SALUDO ON SALUDO.ID = PERSONA.SALUDOID
        WHERE PERSONA.tipopersonaid IN (40)";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, proveedorController);
                }
                localContext.SaveChanges();
                FbSqlHelper.CloseReader(dr, pcn!);


            }
            catch (Exception e)
            {
                if (dr != null && pcn != null)
                    FbSqlHelper.CloseReader(dr, pcn);

                Console.WriteLine(e.Message);
            }

        }

        public bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext, ProveedorController controller)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var ProveeclienteClave = dataReader["PROVEECLIENTECLAVE"] != System.DBNull.Value ? ((string)dataReader["PROVEECLIENTECLAVE"]).Trim() : "";

            var VendedorClave = dataReader["VENDEDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["VENDEDORCLAVE"]).Trim() : "";

            var ListaprecioClave = dataReader["LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOCLAVE"]).Trim() : "";

            var SaludoClave = dataReader["SALUDOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SALUDOCLAVE"]).Trim() : "";


            var itemSaved = localContext.Proveedor.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var ProveeclienteClave_obj = localContext.Cliente.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProveeclienteClave);

            var VendedorClave_obj = localContext.Usuario.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.UsuarioNombre == VendedorClave);

            var ListaprecioClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == ListaprecioClave);

            var SaludoClave_obj = localContext.Saludo.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == SaludoClave);


            var item = itemSaved != null ? new ProveedorBindingModel(itemSaved) : new ProveedorBindingModel();
            var existItem = itemSaved != null;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;

            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Telefono1 = dataReader["TELEFONO1"] != System.DBNull.Value ? ((string)dataReader["TELEFONO1"]).Trim() : "";
            item.Telefono2 = dataReader["TELEFONO2"] != System.DBNull.Value ? ((string)dataReader["TELEFONO2"]).Trim() : "";
            item.Telefono3 = dataReader["TELEFONO3"] != System.DBNull.Value ? ((string)dataReader["TELEFONO3"]).Trim() : "";
            item.Celular = dataReader["CELULAR"] != System.DBNull.Value ? ((string)dataReader["CELULAR"]).Trim() : "";
            item.Nextel = dataReader["NEXTEL"] != System.DBNull.Value ? ((string)dataReader["NEXTEL"]).Trim() : "";
            item.Email1 = dataReader["EMAIL1"] != System.DBNull.Value ? ((string)dataReader["EMAIL1"]).Trim() : "";
            item.Email2 = dataReader["EMAIL2"] != System.DBNull.Value ? ((string)dataReader["EMAIL2"]).Trim() : "";
            item.Nombres = dataReader["NOMBRES"] != System.DBNull.Value ? ((string)dataReader["NOMBRES"]).Trim() : "";
            item.Apellidos = dataReader["APELLIDOS"] != System.DBNull.Value ? ((string)dataReader["APELLIDOS"]).Trim() : "";
            item.Razonsocial = dataReader["RAZONSOCIAL"] != System.DBNull.Value ? ((string)dataReader["RAZONSOCIAL"]).Trim() : "";
            item.Rfc = dataReader["RFC"] != System.DBNull.Value ? ((string)dataReader["RFC"]).Trim() : "";
            item.Contacto1_Nombre = dataReader["CONTACTO1_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_NOMBRE"]).Trim() : "";
            item.Contacto2_Nombre = dataReader["CONTACTO2_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_NOMBRE"]).Trim() : "";
            item.Domicilio_Calle = dataReader["DOMICILIO_CALLE"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CALLE"]).Trim() : "";
            item.Domicilio_Numeroexterior = dataReader["DOMICILIO_NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_NUMEROEXTERIOR"]).Trim() : "";
            item.Domicilio_Numerointerior = dataReader["DOMICILIO_NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_NUMEROINTERIOR"]).Trim() : "";
            item.Domicilio_Colonia = dataReader["DOMICILIO_COLONIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_COLONIA"]).Trim() : "";
            item.Domicilio_Ciudad = dataReader["DOMICILIO_CIUDAD"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CIUDAD"]).Trim() : "";
            item.Domicilio_Municipio = dataReader["DOMICILIO_MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_MUNICIPIO"]).Trim() : "";
            item.Domicilio_Estado = dataReader["DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_ESTADO"]).Trim() : "";
            item.Domicilio_Pais = dataReader["DOMICILIO_PAIS"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_PAIS"]).Trim() : "";
            item.Domicilio_Codigopostal = dataReader["DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CODIGOPOSTAL"]).Trim() : "";
            //item.Domicilio_Referencia = dataReader["DOMICILIO_REFERENCIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_REFERENCIA"]).Trim() : "";
            item.Proveedor_pago_parametros_Revision = dataReader["PROVEEDOR_PAGO_PARAMETROS_REVISION"] != System.DBNull.Value ? ((string)dataReader["PROVEEDOR_PAGO_PARAMETROS_REVISION"]).Trim() : "";
            item.Proveedor_pago_parametros_Pagos = dataReader["PROVEEDOR_PAGO_PARAMETROS_PAGOS"] != System.DBNull.Value ? ((string)dataReader["PROVEEDOR_PAGO_PARAMETROS_PAGOS"]).Trim() : "";
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Esimportador = dataReader["ESIMPORTADOR"] != System.DBNull.Value && ((string)dataReader["ESIMPORTADOR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            //item.Creado = dataReader["CREADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["CREADO"] : DateTime.UtcNow;
            //item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["MODIFICADO"] : DateTime.UtcNow;
            item.Proveedor_pago_Saldo = dataReader["PROVEEDOR_PAGO_SALDO"] != System.DBNull.Value ? (decimal)dataReader["PROVEEDOR_PAGO_SALDO"] : 0;
            item.Proveedor_pago_Saldospositivos = dataReader["PROVEEDOR_PAGO_SALDOSPOSITIVOS"] != System.DBNull.Value ? (decimal)dataReader["PROVEEDOR_PAGO_SALDOSPOSITIVOS"] : 0;
            item.Proveedor_pago_Saldosnegativos = dataReader["PROVEEDOR_PAGO_SALDOSNEGATIVOS"] != System.DBNull.Value ? (decimal)dataReader["PROVEEDOR_PAGO_SALDOSNEGATIVOS"] : 0;
            item.Proveedor_pago_parametros_Adescpes = dataReader["PROVEEDOR_PAGO_PARAMETROS_ADESCPES"] != System.DBNull.Value ? (decimal)dataReader["PROVEEDOR_PAGO_PARAMETROS_ADESCPES"] : 0;
            item.Proveedor_pago_parametros_Dias = dataReader["PROVEEDOR_PAGO_PARAMETROS_DIAS"] != System.DBNull.Value ? (int)dataReader["PROVEEDOR_PAGO_PARAMETROS_DIAS"] : (int?)null;


            if (ProveeclienteClave_obj != null)
                item.Proveeclienteid = ProveeclienteClave_obj.Id;
            else
                item.Proveeclienteid = null;

            if (VendedorClave_obj != null)
                item.Vendedorid = VendedorClave_obj.Id;
            else
                item.Vendedorid = null;

            if (ListaprecioClave_obj != null)
                item.Listaprecioid = ListaprecioClave_obj.Id;
            else
                item.Listaprecioid = null;

            if (SaludoClave_obj != null)
                item.Saludoid = SaludoClave_obj.Id;
            else
                item.Saludoid = null;



            if (existItem)
            {
                controller.Update(item);
            }
            else
            {
                controller.Insert(item);
            }

            localContext.SaveChanges();

            return true;
        }


    }
}


