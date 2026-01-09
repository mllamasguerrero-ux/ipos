using IposV3.Model;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class MaestroConsecutivoService
    {
        const string quotes = "\"";

        public MaestroConsecutivoService()
        {
        }

        public void GenerarConsecutivo(long empresaId, long sucursalId, 
                                        Tipo_consecutivo tipoConsectivo,
                                        long? parent_consecutivo,
                                        string? tabla ,
                                        string? campo ,
                                        string? esquema ,
                                        string? camposerie ,
                                        string? serie,
                                        string? campoparent ,
                                        out long consecutivo, ApplicationDbContext localContext)
        {


            consecutivo = 0;

            long max_existing_id = 0;
            string query = "";


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                if (tipoConsectivo == Tipo_consecutivo.FolioDocto)
                {
                    query = $@"SELECT coalesce(MAX({Iqn(campo)}),0)  ""Val"" 
                            FROM {Iqn(esquema)}.{Iqn(tabla)}
                            where {Iq("EmpresaId")} = {empresaId} and {Iq("SucursalId")} = {sucursalId}  ";


                    if (camposerie != null && camposerie.Trim().Length  > 0) 
                        query = $@"{query}  and  coalesce({Iqn(camposerie)},'') = coalesce('{serie}', '')  ";


                    if (campoparent != null && campoparent.Trim().Length > 0)
                        query = $@"{query}  and  coalesce({Iqn(campoparent)},0) = coalesce({parent_consecutivo}, 0)  ";

                    var max_existing = localContext.SimpleLong.FromSqlRaw(query).FirstOrDefault();
                    if (max_existing != null)
                        max_existing_id = max_existing!.Val;

                }
                else if (tipoConsectivo == Tipo_consecutivo.FolioSatDocto)
                {
                    query = $@"SELECT coalesce(MAX(f.{Iqn(campo)}),0)  ""Val"" 
                            FROM {Iqn(esquema)}.{Iqn(tabla)} f
                            LEFT JOIN ""public"".""Docto"" d on d.""EmpresaId"" = f.""EmpresaId"" and d.""SucursalId"" = f.""SucursalId""
                                            and d.""Id"" = f.""Doctoid""
                            where f.{Iq("EmpresaId")} = {empresaId} and f.{Iq("SucursalId")} = {sucursalId}  ";


                    if (camposerie != null && camposerie.Trim().Length > 0)
                        query = $@"{query}  and  coalesce(f.{Iqn(camposerie)},'') = coalesce('{serie}', '')  ";

                    query = $@"{query}  and  coalesce(d.""Tipodoctoid"",0) = coalesce({parent_consecutivo}, 0)  ";


                    //if (campoparent != null && campoparent.Trim().Length > 0)
                    //    query = $@"{query}  and  coalesce({Iqn(campoparent)},0) = coalesce({parent_consecutivo}, 0)  ";

                    var max_existing = localContext.SimpleLong.FromSqlRaw(query).FirstOrDefault();
                    if (max_existing != null)
                        max_existing_id = max_existing!.Val;

                }

                var maestro_consecuivo = localContext.Maestro_consecutivo
                                                     .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId &&
                                                                 m.Cod_tipo_consecutivo == ((long)tipoConsectivo) && m.Cod_parent_consecutivo == parent_consecutivo &&
                                                                 m.Tabla == tabla && m.Campo == campo &&
                                                                 (m.Camposerie ?? "") == (camposerie ?? "") && (m.Serie ?? "") == (serie ?? "") &&
                                                                 (m.Campoparent ?? "") == (campoparent ?? "")
                                                                 )
                                                     .FirstOrDefault();

                if (maestro_consecuivo == null)
                {
                    consecutivo = max_existing_id + 1;

                    maestro_consecuivo = new Maestro_consecutivo()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        Modificado = DateTimeOffset.Now,
                        Cod_tipo_consecutivo = (long)tipoConsectivo,
                        Cod_parent_consecutivo = parent_consecutivo,
                        Tabla = tabla,
                        Campo = campo,
                        Camposerie = camposerie,
                        Serie = serie,
                        Campoparent = campoparent,
                        Numero_consecutivo = consecutivo,
                        Cui = 0,
                        Fui = DateTimeOffset.Now.Date,
                        Hui = DateTimeOffset.Now.ToString(),
                        Esquema = esquema,
                        Descripcion = ""


                    };

                    localContext.Add(maestro_consecuivo);
                }
                else
                {

                    consecutivo = (maestro_consecuivo.Numero_consecutivo ?? 0) + 1;

                    maestro_consecuivo.Numero_consecutivo = consecutivo;
                    maestro_consecuivo.Modificado = DateTimeOffset.Now;

                    localContext.Update(maestro_consecuivo);
                }




            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }

        private string Iq(object entrada)
        {
            return $"{quotes}{entrada}{quotes}";
        }

        private string Iqn(object? entrada)
        {
            return $"{quotes}{entrada}{quotes}";
        }

    }
}
