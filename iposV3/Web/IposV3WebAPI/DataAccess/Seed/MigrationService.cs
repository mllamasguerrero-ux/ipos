using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Migrations.Seed
{
    public class MigrationService
    {

        public static void RunSpecialMigrationProcesses(ApplicationDbContext context, List<string> migrationsApplied)
        {


            if (migrationsApplied.Where(m => m.Equals("20230107180823_Initial")).Count() > 0)
            {
                FillInitialData(context);
            }


            if (migrationsApplied.Where(m => m.Equals("20240219224443_Match_version_actual_feb2024")).Count() > 0)
                FillFebrero2024Data(context);


            if (migrationsApplied.Where(m => m.Equals("20241004172346_ViewsYFunciones_RecibosFactura")).Count() > 0)
                UpdatingSqlViewsAndFunctions_Oct2024(context);


            if (migrationsApplied.Where(m => m.Equals("20241004203034_CMX-CambioEnSatCatalogos")).Count() > 0)
                UpdatingSqlDIFtoCMXInSatCatalogs_Oct2024(context);


            if (migrationsApplied.Where(m => m.Equals("20241230212811_ViewsYFunciones_RecibosFactura_Cons")).Count() > 0)
                UpdatingSqlViewsAndFunctions_Dec2024(context);

            //Seed.SeedUnidad(context, 5, 4);
        }


        public static void UpdatingSqlViewsAndFunctions_Oct2024(ApplicationDbContext _context)
        {

            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_Cfdi_master());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_recibo_cupones());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_recibo_detail());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_recibo_detail_kit());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_recibo_master());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_recibo_sumatorias());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.Function_cfdi_impuestos_agrupados());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.Function_cfdi_master_aux());
            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.Function_cfdi_impuestos_agrupados_movto());

        }

        public static void UpdatingSqlViewsAndFunctions_Dec2024(ApplicationDbContext _context)
        {

            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.StoredProcedureSql.View_recibo_detail_consolidado());

        }

        public static void UpdatingSqlDIFtoCMXInSatCatalogs_Oct2024(ApplicationDbContext _context)
        {

            _context.Database.ExecuteSqlRaw(DataAccess.PostgreSQL.SpecialMigrationProcess.UpdateCMX());

        }

        private static void FillInitialData(ApplicationDbContext _context)
        {

            Seed.SeedSatAduanas(_context);
            Seed.SeedDerechos(_context);
            Seed.SeedMenuItems(_context);

            Seed.SeedClasedocto(_context);
            Seed.SeedEstadopais(_context);
            Seed.SeedEstatusdocto(_context);
            Seed.SeedEstatusmovto(_context);
            Seed.SeedMeses(_context);
            Seed.SeedOrigenfiscal(_context);
            Seed.SeedSubtipocliente(_context);
            Seed.SeedSubtipodocto(_context);
            Seed.SeedTipodistloteimportado(_context);
            Seed.SeedTipodocto(_context);
            //Seed.SeedTipodoctoventa(_context);
            //Seed.SeedTipopersona(_context);
            Seed.SeedTiporecarga(_context);
            Seed.SeedMoneda(_context);
            Seed.SeedSaludo(_context);

            Seed.SeedFormapago(_context);
            Seed.SeedFormapagosat(_context);
            Seed.SeedSat_codigopostal(_context);
            Seed.SeedSat_impuesto(_context);
            Seed.SeedSat_metodopago(_context);
            Seed.SeedSat_moneda(_context);
            Seed.SeedSat_pais(_context);

            Seed.SeedSat_patenteaduanal(_context);
            Seed.SeedSat_pedimentos(_context);
            Seed.SeedSat_productoservicio(_context);
            Seed.SeedSat_regimenfiscal(_context);
            Seed.SeedSat_tasacuota(_context);
            Seed.SeedSat_tipocomprobante(_context);
            Seed.SeedSat_tipofactor(_context);
            Seed.SeedSat_tiporelacion(_context);
            Seed.SeedSat_unidadmedida(_context);
            Seed.SeedSat_usocfdi(_context);
            Seed.SeedSat_versioncatalogo(_context);
            Seed.SeedTasaiva(_context);
            Seed.SeedTasasieps(_context);
            Seed.SeedEstadocobranza(_context);
            Seed.SeedEstadopagocontrarecibo(_context);
            Seed.SeedCorte_calculo_def(_context);
            Seed.SeedTipocorte(_context);
            Seed.SeedTipomontobilletes(_context);
            Seed.SeedTipotransaccion(_context);
            Seed.SeedTurno(_context);
            Seed.SeedEstadoguia(_context);
            Seed.SeedTipoentrega(_context);
            Seed.SeedTipoeventotabla(_context);
            Seed.SeedTipoincidencia(_context);
            Seed.SeedGrupodiferenciainventario(_context);
            Seed.SeedTipodiferenciainventario(_context);
            Seed.SeedMensajeestado(_context);
            Seed.SeedMensajenivelurgencia(_context);
            Seed.SeedMensajetipo(_context);
            Seed.SeedTipomonederomovto(_context);
            Seed.SeedEstatusdoctopago(_context);
            Seed.SeedEstatuspago(_context);
            Seed.SeedMotivo_camfec(_context);
            Seed.SeedSubtipopago(_context);
            Seed.SeedTipoabono(_context);
            Seed.SeedTipoaplicacioncredito(_context);
            Seed.SeedTipomovimientokardexabono(_context);
            Seed.SeedTipopago(_context);
            Seed.SeedTiporelacionpago(_context);
            Seed.SeedIngresuc_tipolinea(_context);
            Seed.SeedTipolineapoliza(_context);
            Seed.SeedCamporeferenciaprecio(_context);
            Seed.SeedTipodescuentoprod(_context);
            Seed.SeedTipodescuentovale(_context);
            Seed.SeedTipoutilidad(_context);
            Seed.SeedTipo_impuesto(_context);
            Seed.SeedTipo_precio(_context);
            Seed.SeedTipomayoreo(_context);
            Seed.SeedTipoprecio(_context);
            Seed.SeedRangopromocion(_context);
            Seed.SeedTipopromocion(_context);
            Seed.SeedEstatusrebaja(_context);
            Seed.SeedReplgroupdef(_context);
            Seed.SeedRepltipomov(_context);
            Seed.SeedRepltablagroupdef(_context);
            Seed.SeedEstadorevisado(_context);
            Seed.SeedEstadosurtido(_context);
            Seed.SeedEstatusexpo(_context);
            Seed.SeedEstatusimpo(_context);
            Seed.SeedTipoexpo(_context);
            Seed.SeedTipoimpo(_context);
            Seed.SeedMotivo_devolucion(_context);


            Seed.SeedSat_clavetransporte(_context);
            Seed.SeedSat_tipoembalaje(_context);
            Seed.SeedSat_tipopermiso(_context);
            Seed.SeedSat_tipoestacion(_context);
            Seed.SeedSat_partetransporte(_context);
            Seed.SeedSat_figuratransporte(_context);
            Seed.SeedSat_subtiporem(_context);
            Seed.SeedSat_matpeligroso(_context);
            Seed.SeedSat_configautotransporte(_context);
            Seed.SeedSat_municipio(_context);
            Seed.SeedSat_localidad(_context);
            Seed.SeedTipodoctonota(_context);
            Seed.SeedSat_colonia(_context);

            Seed.SeedAgrupacionVenta(_context);

            //Seed.SeedUnidad(_context);

        }



        private static void FillFebrero2024Data(ApplicationDbContext _context )
        {

            Seed.SeedDerechos_Update(_context, "./SeedData/Febrero2024", "_02_2024");
            Seed.SeedMenuItems_Update(_context, "./SeedData/Febrero2024", "_02_2024");
            Seed.SeedEstadopais_Update(_context, "./SeedData/Febrero2024", "_02_2024");
            Seed.SeedSubtipodocto_Update(_context, "./SeedData/Febrero2024", "_02_2024");
            Seed.SeedTipodocto_Update(_context, "./SeedData/Febrero2024", "_02_2024");
            Seed.SeedPerfil_der_Update(_context, "./SeedData/Febrero2024", "_02_2024");
        }
            public static void FillSampleData(ApplicationDbContext context)
        {
            //var empresa = new Empresa()
            //{
            //    Clave = "abarrotesperez",
            //    Nombre = "abarrotes perez"
            //};

            ////add empresa
            //context.Add(empresa);

            //context.SaveChanges();


            //add sucursal
            //context.Add(new Sucursal()
            //{
            //    //Empresa = empresa,
            //    EmpresaId = 5,
            //    Clave = "matriz",
            //    Nombre = "Matriz"
            //});

            //add user
            //context.Add(new Usuario()
            //{
            //    EmpresaId = 5,
            //    SucursalId = 4,
            //    Nombre = "manuel",
            //    UsuarioNombre = "manuel",
            //    Contrasena = "123",
            //    Nombres = "Manuel",
            //    Apellidos = "Llamas Guerrero",
            //    Razonsocial = "Manuel Llamas Guerrero",
            //    Reset_pass = BoolCN.N
            //}); 


            //add perfil
            //context.Perfiles.Add(new Perfiles()
            //{
            //    EmpresaId = 5,
            //    SucursalId = 4,
            //    Descripcion = "Administrador"
            //});

            //add perfil_derechos

            //var derechos = context.Derechos.ToList();
            //foreach(var derecho in derechos)
            //{
            //    context.Perfil_der.Add(new Perfil_der()
            //    {

            //        EmpresaId = 5,
            //        SucursalId = 4,
            //        Perfilid = 1,
            //        Derechoid = derecho.Id
            //    });
            //}
            //context.SaveChanges();

            ////add perfil_user

            //context.Usuario_perfil.Add(new Usuario_perfil()
            //{

            //    EmpresaId = 5,
            //    SucursalId = 4,
            //    Perfilid = 1,
            //    Usuarioid = 1

            //});
            //context.SaveChanges();



        }

    }
    
}
