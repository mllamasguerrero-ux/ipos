|||||100+++++
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

namespace IposV3.Services
{



    public class (nombreTabla)ImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.(nombreTabla).AsNoTracking()
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){
|||||2150+++++
                                                        new ImpoExpoValor("(nombreCampoCapitalizado)", x.(nombreCampoConRuta), (defaultValue)),|||||2200+++++

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {
|||||2250+++++
                new ImpoExpoField("(nombreCampoCapitalizado)","(nombreCampoEnForm)",(longitudDeCampoEnBase),(anchoB12), NpgsqlDbType.(tipoCampoEnDBType), typeof((tipoCampoLenguaje))),|||||2300+++++
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var itemSaved = localContext.(nombreTabla).AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new (nombreTabla)();
            var existItem = itemSaved != null;

	|||||2700+++++
          	item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value ? (((tipoCampoLenguaje))dataReader["(nombreCampoEnForm)"]).Trim() : (defaultValue); |||||2701+++++
          	item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value ? StringValueForDomain( (((tipoCampoLenguaje))dataReader["(nombreCampoEnForm)"]).Trim() , "(dominioBase)") : StringValueForDomain( null , "(dominioBase)"); |||||2705+++++
		item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value ? ((tipoCampoLenguaje))dataReader["(nombreCampoEnForm)"] : (defaultValue); |||||2706+++++
		item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value && ((string)dataReader["(nombreCampoEnForm)"]).Trim() == "S" ? (tipoCampoLenguaje).S : (tipoCampoLenguaje).N; |||||2707+++++
		item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value && ((string)dataReader["(nombreCampoEnForm)"]).Trim() == "N" ? (tipoCampoLenguaje).N : (tipoCampoLenguaje).S; |||||2710+++++        
		item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value ? ((tipoCampoLenguaje))dataReader["(nombreCampoEnForm)"] : (defaultValue); |||||2800+++++
		item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value ? ((DateTime)dataReader["(nombreCampoEnForm)"]).ToString("yyyy-MM-dd") : (defaultValue); |||||2900+++++
		item.(nombreCampoConRuta) = dataReader["(nombreCampoEnForm)"] != System.DBNull.Value ? (tipoCampoLenguaje).Parse(dataReader["(nombreCampoEnForm)"].ToString()) : ((tipoCampoLenguaje)?)null; |||||3000+++++


            if (existItem)
                localContext.(nombreTabla).Update(item);
            else
                localContext.(nombreTabla).Add(item);

            localContext.SaveChanges();

            return true;
        }



        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

	|||||3100+++++
	    var (catalogocampoclave) = dataReader["(catalogocampoclave_capitalizado)"] != System.DBNull.Value ? ((string)dataReader["(catalogocampoclave_capitalizado)"]).Trim() : "";
	|||||3200+++++

            var itemSaved = localContext.(nombreTabla).AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

	|||||3300+++++
            var (catalogocampoclave)_obj = localContext.(catalogo).AsNoTracking()
                                        	.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == (catalogocampoclave));
	|||||3400+++++

            var item = itemSaved != null ? itemSaved : new (nombreTabla)();
            var existItem = itemSaved != null;

	|||||3500+++++
          	item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value ? (((tipoCampoLenguaje))dataReader["(nombreCampoMayuscula)"]).Trim() : (defaultValue); |||||3501+++++
          	item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value ? StringValueForDomain( (((tipoCampoLenguaje))dataReader["(nombreCampoMayuscula)"]).Trim() , "(dominioBase)") : StringValueForDomain( null , "(dominioBase)"); |||||3505+++++
		item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value ? ((tipoCampoLenguaje))dataReader["(nombreCampoMayuscula)"] : (defaultValue); |||||3506+++++
		item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value && ((string)dataReader["(nombreCampoMayuscula)"]).Trim() == "S" ? (tipoCampoLenguaje).S : (tipoCampoLenguaje).N; |||||3507+++++
		item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value && ((string)dataReader["(nombreCampoMayuscula)"]).Trim() == "N" ? (tipoCampoLenguaje).N : (tipoCampoLenguaje).S; |||||3510+++++        
		item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value ? ((tipoCampoLenguaje))dataReader["(nombreCampoMayuscula)"] : (defaultValue); |||||3600+++++
		item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value ? new DateTimeOffset(DateTime.SpecifyKind(((DateTime)dataReader["(nombreCampoMayuscula)"]), DateTimeKind.Local)) : (defaultValue);|||||3700+++++
		item.(nombreCampo) = dataReader["(nombreCampoMayuscula)"] != System.DBNull.Value ? (tipoCampoLenguaje).Parse((string)dataReader["(nombreCampoMayuscula)"]) : ((tipoCampoLenguaje)?)null; |||||3800+++++

	|||||4000+++++
            if ((catalogocampoclave)_obj != null)
                item.(nombreCampo) = (catalogocampoclave)_obj.Id;
            else
                item.(nombreCampo) = null;
	|||||4100+++++


            if (existItem)
                localContext.(nombreTabla).Update(item);
            else
                localContext.(nombreTabla).Add(item);

            localContext.SaveChanges();

            return true;
        }



    }
}


!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
2150;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2200;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0
2250;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2300;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0
2700;1;0;IGNORAR;IGNORAR;VARCHAR,CHAR;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;VACIO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2701;1;0;IGNORAR;IGNORAR;VARCHAR,CHAR;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;CONDATOS;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2705;1;0;IGNORAR;IGNORAR;BOOLEAN;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2706;1;0;IGNORAR;IGNORAR;BOOLCN,BOOLCNI;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2707;1;0;IGNORAR;IGNORAR;BOOLCS,BOOLCSI;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2710;1;0;IGNORAR;IGNORAR;IGNORAR;DATEOLD,VARCHAR,CHAR,BOOLEAN,BIGINT,INTEGER,SMALLINT,BOOLCN,BOOLCNI,BOOLCS,BOOLCSI;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2800;1;0;IGNORAR;IGNORAR;DATEOLD;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
2900;1;0;IGNORAR;IGNORAR;BIGINT,INTEGER,SMALLINT;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3000;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0
3100;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SELECTOR,COMBOBOX
3200;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0
3300;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SELECTOR,COMBOBOX
3400;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0
3500;1;0;IGNORAR;IGNORAR;VARCHAR,CHAR;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;VACIO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3501;1;0;IGNORAR;IGNORAR;VARCHAR,CHAR;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;CONDATOS;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3505;1;0;IGNORAR;IGNORAR;BOOLEAN;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3506;1;0;IGNORAR;IGNORAR;BOOLCN,BOOLCNI;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3507;1;0;IGNORAR;IGNORAR;BOOLCS,BOOLCSI;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3510;1;0;IGNORAR;IGNORAR;IGNORAR;DATEOLD,VARCHAR,CHAR,BOOLEAN,BIGINT,INTEGER,SMALLINT,BOOLCN,BOOLCNI,BOOLCS,BOOLCSI;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3600;1;0;IGNORAR;IGNORAR;DATEOLD;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3700;1;0;IGNORAR;IGNORAR;BIGINT,INTEGER,SMALLINT;IGNORAR;IGNORAR;NO;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;ESBASE
3800;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0
4000;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SELECTOR,COMBOBOX
4100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0

