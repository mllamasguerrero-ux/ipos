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

namespace IposV3.Services
{

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class CuentaImpoExpoService : BaseImpoExpoService
    {

        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";



            var tipolineapolizaClave = dataReader["TIPOLINEAPOLIZACLAVE"] != System.DBNull.Value ? ((string)dataReader["TIPOLINEAPOLIZACLAVE"]).Trim() : "";

            var tipolineapolizaespecialClave = dataReader["TIPOLINEAPOLIZAESPECIALCLAVE"] != System.DBNull.Value ? ((string)dataReader["TIPOLINEAPOLIZAESPECIALCLAVE"]).Trim() : "";

            var formapagosatClave = dataReader["FORMAPAGOSATCLAVE"] != System.DBNull.Value ? ((string)dataReader["FORMAPAGOSATCLAVE"]).Trim() : "";



            var itemSaved = localContext.Cuenta.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var tipolineapoliza = localContext.Tipolineapoliza.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == tipolineapolizaClave);

            var tipolineapolizaespecial = localContext.Tipolineapoliza.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == tipolineapolizaespecialClave);

            var formapagosat = localContext.Formapagosat.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == formapagosatClave);

            var item = itemSaved != null ? itemSaved : new Cuenta();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.Numucuenta = dataReader["NUMUCUENTA"] != System.DBNull.Value ? ((string)dataReader["NUMUCUENTA"]).Trim() : "";

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Numucuenta = dataReader["NUMUCUENTA"] != System.DBNull.Value ? ((string)dataReader["NUMUCUENTA"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : null;

            item.Esfact = dataReader["ESFACT"] != System.DBNull.Value && ((string)dataReader["ESFACT"]).Trim() == "S" ? BoolCNI.S : 
                         (dataReader["ESFACT"] != System.DBNull.Value && ((string)dataReader["ESFACT"]).Trim() == "N" ? BoolCNI.N : BoolCNI.I);
            item.Tasa = dataReader["TASA"] != System.DBNull.Value ? (decimal)dataReader["TASA"] : 0m;
            item.Leyenda = dataReader["LEYENDA"] != System.DBNull.Value ? ((string)dataReader["LEYENDA"]).Trim() : null;
            item.Orden = dataReader["ORDEN"] != System.DBNull.Value ? (int)dataReader["ORDEN"] : 0;


            if (tipolineapoliza != null)
                item.Tipolineapolizaid = tipolineapoliza.Id;
            else
                item.Tipolineapolizaid = null;

            if (tipolineapolizaespecial != null)
                item.Tipolineapolizaespecialid = tipolineapolizaespecial.Id;
            else
                item.Tipolineapolizaespecialid = null;

            if (formapagosat != null)
                item.Formapagosatid = formapagosat.Id;
            else
                item.Formapagosatid = null;

            if (existItem)
                localContext.Cuenta.Update(item);
            else
                localContext.Cuenta.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}
