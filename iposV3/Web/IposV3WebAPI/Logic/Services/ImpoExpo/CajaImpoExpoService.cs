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
    public class CajaImpoExpoService : BaseImpoExpoService
    {

        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";

            var terminalClave = dataReader["TERMINAL"] != System.DBNull.Value ? ((string)dataReader["TERMINAL"]).Trim() : "";
            var terminalServiciosClave = dataReader["TERMINALSERVICIOS"] != System.DBNull.Value ? ((string)dataReader["TERMINALSERVICIOS"]).Trim() : "";
            
            var itemSaved = localContext.Caja.AsNoTracking()
                                            .Include(c => c.Caja_emida).ThenInclude(t => t.Terminal)
                                            .Include(c => c.Caja_emida).ThenInclude(t => t.Terminalservicios)
                                            .Include(c => c.Caja_bancomer)
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var terminalSaved = localContext.Terminalpagoservicio.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Terminal == terminalClave);

            var terminalServiciosSaved = localContext.Terminalpagoservicio.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Terminal == terminalServiciosClave);




            var item = itemSaved != null ? itemSaved : new Caja();
            var existItem = itemSaved != null;

            item.Clave = clave;
            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";
            item.Nombreimpresora = dataReader["NOMBREIMPRESORA"] != System.DBNull.Value ? ((string)dataReader["NOMBREIMPRESORA"]).Trim() : null;
            item.Impresoracomanda = dataReader["IMPRESORACOMANDA"] != System.DBNull.Value ? ((string)dataReader["IMPRESORACOMANDA"]).Trim() : null;

            if((item.Caja_emida == null) && (dataReader["TERMINAL"] != System.DBNull.Value || dataReader["TERMINALSERVICIOS"] != System.DBNull.Value))
            {
                var cajaEmida = new Caja_emida();
                cajaEmida.EmpresaId = empresaId;
                cajaEmida.SucursalId = sucursalId;

                item.Caja_emida = cajaEmida;
            }

            if(item.Caja_emida != null)
            {
                item.Caja_emida.Terminalid = terminalSaved != null ? terminalSaved.Id : null;
                item.Caja_emida.Terminalserviciosid = terminalServiciosSaved != null ? terminalServiciosSaved.Id : null;

            }

            if ((item.Caja_bancomer == null) && (dataReader["NUMEROTERMINALBANCOMER"] != System.DBNull.Value || 
                                                 dataReader["NOMBRECERTIFICADOBANCOMER"] != System.DBNull.Value ||
                                                 dataReader["AFILIACIONBANCOMER"] != System.DBNull.Value ))
            {
                var caja_bancomer = new Caja_bancomer();
                caja_bancomer.EmpresaId = empresaId;
                caja_bancomer.SucursalId = sucursalId;

                item.Caja_bancomer = caja_bancomer;
            }

            if (item.Caja_bancomer != null)
            {
                item.Caja_bancomer.Numeroterminalbancomer = dataReader["NUMEROTERMINALBANCOMER"] != System.DBNull.Value ? (long)dataReader["NUMEROTERMINALBANCOMER"] : null;
                item.Caja_bancomer.Nombrecertificadobancomer = dataReader["NOMBRECERTIFICADOBANCOMER"] != System.DBNull.Value ? ((string)dataReader["NOMBRECERTIFICADOBANCOMER"]).Trim() : "";
                item.Caja_bancomer.Afiliacionbancomer = dataReader["AFILIACIONBANCOMER"] != System.DBNull.Value ? ((string)dataReader["AFILIACIONBANCOMER"]).Trim() : "";

            }

            if (string.IsNullOrEmpty(item.Descripcion))
                item.Descripcion = item.Clave;

            if (existItem)
                localContext.Caja.Update(item);
            else
                localContext.Caja.Add(item);

            localContext.SaveChanges();

            return true;
        }

    }
}
