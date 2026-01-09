using IposV3.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{

    public class UsuarioService
    {

        public UsuarioService()
        {
        }

        public List<Tmp_UsuariosDerechos> UsuariosDerechos(long empresaId, long sucursalId, long usuarioId, List<long> derechos, 
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                

                var lstDerechosUsuario = localContext.Usuario_perfil.AsNoTracking()
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Usuarioid == usuarioId)
                                                      .SelectMany(p => (p.Perfil!.Derechos!.Select(d => d.Derechoid != null ? d.Derechoid!.Value : 0)))
                                                      .Distinct()
                                                      .Where(y => derechos.Contains(y))
                                                      .ToList();

                var lstDerechoAcceso = derechos.Select(d => new Tmp_UsuariosDerechos(d, lstDerechosUsuario.Contains(d)))
                                                .ToList();


                return lstDerechoAcceso;


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
    }

    public class Tmp_UsuariosDerechos
    {
        public long Derechoid { get; }
        public bool Acceso { get; }

        public Tmp_UsuariosDerechos(long derechoid, bool acceso)
        {
            Derechoid = derechoid;
            Acceso = acceso;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_UsuariosDerechos other &&
                   Derechoid == other.Derechoid &&
                   Acceso == other.Acceso;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Derechoid, Acceso);
        }
    }
}
