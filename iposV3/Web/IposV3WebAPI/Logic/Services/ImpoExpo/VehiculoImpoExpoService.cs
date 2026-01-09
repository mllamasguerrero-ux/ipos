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
    public class VehiculoImpoExpoService : BaseImpoExpoService
    {

        public override bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {

            long id = dataReader["ID"] != System.DBNull.Value ? ((long)dataReader["ID"]) : -1;
            var placaVm = dataReader["PLACAVM"] != System.DBNull.Value ? ((string)dataReader["PLACAVM"]).Trim() : "";


            var sat_tipopermisoClave = dataReader["SAT_TIPOPERMISOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_TIPOPERMISOCLAVE"]).Trim() : "";

            var sat_configautotransporteClave = dataReader["SAT_CONFIGAUTOTRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_CONFIGAUTOTRANSPORTECLAVE"]).Trim() : "";

            var sat_subtiporem1Clave = dataReader["SAT_SUBTIPOREM1CLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_SUBTIPOREM1CLAVE"]).Trim() : "";

            var sat_subtiporem2Clave = dataReader["SAT_SUBTIPOREM2CLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_SUBTIPOREM2CLAVE"]).Trim() : "";

            var duenioClave = dataReader["DUENIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["DUENIOCLAVE"]).Trim() : "";


            var sat_configautotransporte = localContext.Sat_configautotransporte.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == sat_configautotransporteClave);

            if(sat_configautotransporte == null || string.IsNullOrEmpty(placaVm))
            {
                return false;
            }

            var itemSaved = localContext.Vehiculo.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Placavm == placaVm && i.Sat_Configautotransporteid == sat_configautotransporte.Id);

            var sat_tipopermiso = localContext.Sat_tipopermiso.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == sat_tipopermisoClave);


            var sat_subtiporem1 = localContext.Sat_subtiporem.AsNoTracking()
                                        .FirstOrDefault(i => i.Clave == sat_subtiporem1Clave);

            var sat_subtiporem2 = localContext.Sat_subtiporem.AsNoTracking()
                                        .FirstOrDefault(i =>  i.Clave == sat_subtiporem2Clave);

            var duenio = localContext.Usuario.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Nombre == duenioClave);

            var item = itemSaved != null ? itemSaved : new Vehiculo();
            var existItem = itemSaved != null;

            if (!existItem)
                item.CreadoPorId = usuarioId;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;
            item.Placa1 = dataReader["PLACA1"] != System.DBNull.Value ? ((string)dataReader["PLACA1"]).Trim() : "";
            //item.Id = id;
            item.ModificadoPorId = usuarioId;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "S" ? BoolCS.S : BoolCS.N;
            item.Placa2 = dataReader["PLACA2"] != System.DBNull.Value ? ((string)dataReader["PLACA2"]).Trim() : "";

            item.Numpermisosct = dataReader["NUMPERMISOSCT"] != System.DBNull.Value ? ((string)dataReader["NUMPERMISOSCT"]).Trim() : "";
            item.Placavm = dataReader["PLACAVM"] != System.DBNull.Value ? ((string)dataReader["PLACAVM"]).Trim() : "";
            item.Aniomodelovm = dataReader["ANIOMODELOVM"] != System.DBNull.Value ? ((string)dataReader["ANIOMODELOVM"]).Trim() : "";
            item.Asegurarespcivil = dataReader["ASEGURARESPCIVIL"] != System.DBNull.Value ? ((string)dataReader["ASEGURARESPCIVIL"]).Trim() : "";
            item.Polizarespcivil = dataReader["POLIZARESPCIVIL"] != System.DBNull.Value ? ((string)dataReader["POLIZARESPCIVIL"]).Trim() : "";
            item.Aseguramedambiente = dataReader["ASEGURAMEDAMBIENTE"] != System.DBNull.Value ? ((string)dataReader["ASEGURAMEDAMBIENTE"]).Trim() : "";
            item.Polizamedambiente = dataReader["POLIZAMEDAMBIENTE"] != System.DBNull.Value ? ((string)dataReader["POLIZAMEDAMBIENTE"]).Trim() : "";
            item.Aseguracarga = dataReader["ASEGURACARGA"] != System.DBNull.Value ? ((string)dataReader["ASEGURACARGA"]).Trim() : "";
            item.Polizacarga = dataReader["POLIZACARGA"] != System.DBNull.Value ? ((string)dataReader["POLIZACARGA"]).Trim() : "";
            item.Primaseguro = dataReader["PRIMASEGURO"] != System.DBNull.Value ? ((string)dataReader["PRIMASEGURO"]).Trim() : "";


            if (sat_tipopermiso != null)
                item.Sat_Tipopermisoid = sat_tipopermiso.Id;
            else
                item.Sat_Tipopermisoid = null;

            if (sat_configautotransporte != null)
                item.Sat_Configautotransporteid = sat_configautotransporte.Id;
            else
                item.Sat_Configautotransporteid = null;

            if (sat_subtiporem1 != null)
                item.Sat_Subtiporem1id = sat_subtiporem1.Id;
            else
                item.Sat_Subtiporem1id = null;

            if (sat_subtiporem2 != null)
                item.Sat_Subtiporem2id = sat_subtiporem2.Id;
            else
                item.Sat_Subtiporem2id = null;

            if (duenio != null)
                item.Duenioid = duenio.Id;
            else
                item.Duenioid = null;

            if (existItem)
                localContext.Vehiculo.Update(item);
            else
                localContext.Vehiculo.Add(item);

            localContext.SaveChanges();

            return true;
        }
    }
}
