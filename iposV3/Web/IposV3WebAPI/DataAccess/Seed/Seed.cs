using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;
//using System.Windows.Controls;
using System.Xml.Linq;
using System.Net.Mime;
using System.Globalization;
//using Caliburn.Micro;
using Newtonsoft.Json.Linq;

namespace IposV3.Migrations.Seed
{
    public class Seed
    {

        public static void AuxGeneracion()
        {


            Dictionary<string, string> result = new Dictionary<string, string>();

            string[] fileEntries = Directory.GetFiles("./SeedData/");
            foreach(string strFileName in fileEntries)
            {

                using (var reader = File.OpenText(strFileName))
                {
                    var line = reader.ReadLine();

                    if (line is not null)
                    {
                        result.Add(strFileName, line);
                    }
                    Debug.WriteLine($"{strFileName}@{line}");
                }
            }

        }

        public static void SeedSatAduanas(ApplicationDbContext context)
        {

            if (!context.Sat_aduana.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_aduana.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_aduana = tokens[1];
                        var sat_descripcion = tokens[2];

                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_aduana.Add(new Sat_aduana() { Id = id, Sat_claveaduana = sat_clave_aduana, Sat_descripcion = sat_descripcion });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedDerechos(ApplicationDbContext context)
        {

            if (!context.Derechos.Any())
            {

                using (var reader = File.OpenText("./SeedData/administracion_derechos.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 2);

                        var id_str = tokens[0];
                        var descripcion = tokens[1];

                        long id = 1;


                        if(id_str != null)
                            long.TryParse(id_str.Replace(",", ""), out id);

                        context.Derechos.Add(new Derechos() { Id = id, Descripcion = descripcion });



                    }
                    context.SaveChanges();
                }
            }
        }



        public static void SeedDerechos_Update(ApplicationDbContext context, string carpeta, string postfix)
        {

            //if (!context.Derechos.Any())
            //{

                using (var reader = File.OpenText($"{carpeta}/administracion_derechos{postfix}.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 2);

                        var id_str = tokens[0];
                        var descripcion = tokens[1];

                        long id = 1;


                        if (id_str != null)
                            long.TryParse(id_str.Replace(",", ""), out id);

                        var registroGrabado = context.Derechos.FirstOrDefault(r => r.Id == id);

                        if(registroGrabado!= null)
                        {
                            registroGrabado.Descripcion = descripcion;
                            context.Derechos.Update(registroGrabado);
                        }
                        else
                            context.Derechos.Add(new Derechos() { Id = id, Descripcion = descripcion });



                    }
                    context.SaveChanges();
                }
            //}
        }



        public static void SeedPerfil_der_Update(ApplicationDbContext context, string carpeta, string postfix)
        {

            try
            {

                var listEmpresaSucursal = context.Perfil_der.AsNoTracking().Select(p => new
                {
                    p.EmpresaId,
                    p.SucursalId
                }).Distinct().ToList();

                foreach (var empresaSucursal in listEmpresaSucursal)
                {

                    var idMax = context.Perfil_der
                        .Where(e => e.EmpresaId == empresaSucursal.EmpresaId && e.SucursalId == empresaSucursal.SucursalId)
                        .Max(e => e.Id);
                    var consecutivo = idMax + 1;

                    using (var reader = File.OpenText($"{carpeta}/administracion_perfil_der{postfix}.csv"))
                    {
                        while (true)
                        {

                            var line = reader.ReadLine();

                            if (line is null)
                            {
                                break;
                            }

                            var tokens = line.Split(';');

                            //Debug.Assert(tokens.Length == 3);

                            var perfilid_str = tokens[0];
                            var derechoid_str = tokens[1];


                            if (perfilid_str == "prefilid")
                                continue;

                            var perfilid = perfilid_str != null ? ParseLong(perfilid_str) : 1;
                            var derechoid = derechoid_str != null ? ParseLong(derechoid_str) : 1;


                            var registroGrabado = context.Perfil_der.FirstOrDefault(r =>
                                        r.EmpresaId == empresaSucursal.EmpresaId && r.SucursalId == empresaSucursal.SucursalId &&
                                        r.Perfilid == perfilid && r.Derechoid == derechoid);

                            if (registroGrabado != null)
                            {
                                registroGrabado.Activo = BoolCS.S;
                                context.Perfil_der.Update(registroGrabado);
                            }
                            else
                            {
                                context.Perfil_der.Add(new Perfil_der()
                                {
                                    EmpresaId = empresaSucursal.EmpresaId,
                                    SucursalId = empresaSucursal.SucursalId,
                                    Id = consecutivo,
                                    Perfilid = perfilid,
                                    Derechoid = derechoid
                                });
                                consecutivo++;
                            }



                        }
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void SeedMenuItems(ApplicationDbContext context)
        {

            if (!context.Menuitems.Any())
            {

                using (var reader = File.OpenText("./SeedData/administracion_menuitems.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 7);

                        var id_str = tokens[0];
                        var parentid_str = tokens[1];
                        var etiqueta = tokens[2];
                        var descripcion = tokens[3];
                        var derecho_id = tokens[4];
                        var nivel_str = tokens[5];
                        var orden_str = tokens[6];

                        long id = 1;
                        long? parentId = null;
                        long derechoId = 1;

                        short nivel = 1;
                        int orden = 1;

                        long bufferLong = 0;


                        if (id_str != null)
                            long.TryParse(id_str.Replace(",", ""), out id);


                        if (parentid_str != null && !parentid_str.Equals("null"))
                        {
                           
                            if(long.TryParse(parentid_str.Replace(",", ""), out bufferLong))
                                parentId = bufferLong;
                        }


                        if (derecho_id != null && !derecho_id.Equals("null"))
                            long.TryParse(derecho_id.Replace(",", ""), out derechoId);


                        if (nivel_str != null && !nivel_str.Equals("null"))
                            short.TryParse(nivel_str.Replace(",", ""), out nivel);

                        if (orden_str != null && !orden_str.Equals("null"))
                            int.TryParse(orden_str.Replace(",", ""), out orden);

                        context.Menuitems.Add(new Menuitems() { Id = id, Parentid = parentId, Derechoid = derechoId, Etiqueta = etiqueta, Descripcion = descripcion, Nivel = nivel, Orden = orden });



                    }
                    context.SaveChanges();
                }
            }
        }



        public static void SeedMenuItems_Update(ApplicationDbContext context, string carpeta, string postfix)
        {

            //if (!context.Menuitems.Any())
            //{

                using (var reader = File.OpenText($"{carpeta}/administracion_menuitems{postfix}.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 7);

                        var id_str = tokens[0];
                        var parentid_str = tokens[1];
                        var etiqueta = tokens[2];
                        var descripcion = tokens[3];
                        var derecho_id = tokens[4];
                        var nivel_str = tokens[5];
                        var orden_str = tokens[6];

                        long id = 1;
                        long? parentId = null;
                        long derechoId = 1;

                        short nivel = 1;
                        int orden = 1;

                        long bufferLong = 0;


                        if (id_str != null)
                            long.TryParse(id_str.Replace(",", ""), out id);


                        if (parentid_str != null && !parentid_str.Equals("null"))
                        {

                            if (long.TryParse(parentid_str.Replace(",", ""), out bufferLong))
                                parentId = bufferLong;
                        }


                        if (derecho_id != null && !derecho_id.Equals("null"))
                            long.TryParse(derecho_id.Replace(",", ""), out derechoId);


                        if (nivel_str != null && !nivel_str.Equals("null"))
                            short.TryParse(nivel_str.Replace(",", ""), out nivel);

                        if (orden_str != null && !orden_str.Equals("null"))
                            int.TryParse(orden_str.Replace(",", ""), out orden);


                        var registroGrabado = context.Menuitems.FirstOrDefault(r => r.Id == id);

                        if (registroGrabado != null)
                        {
                            registroGrabado.Parentid = parentId;
                            registroGrabado.Derechoid = derechoId;
                            registroGrabado.Etiqueta = etiqueta;
                            registroGrabado.Descripcion = descripcion;
                            registroGrabado.Nivel = nivel;
                            registroGrabado.Orden = orden;
                            context.Menuitems.Update(registroGrabado);
                        }
                        else
                        {
                            context.Menuitems.Add(new Menuitems() { Id = id, Parentid = parentId, Derechoid = derechoId, Etiqueta = etiqueta, Descripcion = descripcion, Nivel = nivel, Orden = orden });
                        }


                    }
                    context.SaveChanges();
                }
            //}
        }

        public static void SeedClasedocto(ApplicationDbContext context)
        {

            if (!context.Clasedocto.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_clasedocto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var clavesis_str = tokens[3];
                        var escompra_str = tokens[4];
                        var esventa_str = tokens[5];
                        var estraslado_str = tokens[6];

                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Clasedocto.Add(new Clasedocto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Clavesis = clavesis_str,
                            Escompra = ParseBoolCN(escompra_str),
                            Esventa = ParseBoolCN(esventa_str),
                            Estraslado = ParseBoolCN(estraslado_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        private static BoolCN ParseBoolCN(string val)
        {
            List<string> validValues = new List<string>() { "S" ,"N"};

            BoolCN validValue = BoolCN.N;

            if (val == null)
                return validValue;

            Enum.TryParse<BoolCN>(val.ToUpper(), out validValue);

            return validValue;


        }

        private static BoolCS ParseBoolCS(string val)
        {
            List<string> validValues = new List<string>() { "S", "N" };

            BoolCS validValue = BoolCS.S;

            if (val == null)
                return validValue;

            Enum.TryParse<BoolCS>(val.ToUpper(), out validValue);

            return validValue;
        }


        private static short ParseShort(string val)
        {
            short validValue = 0;

            if (val == null)
                return validValue;

            short.TryParse(val.Replace(",", ""), out validValue);
            return validValue;
        }


        private static short? ParseShortNull(string val)
        {
            short validValue = 0;

            if (val == null)
                return null;

            if (!short.TryParse(val.Replace(",", ""), out validValue))
                return null;

            return (short?)validValue;
        }


        private static int ParseInt(string val)
        {
            int validValue = 0;

            if (val == null)
                return validValue;

            int.TryParse(val.Replace(",", ""), out validValue);
            return validValue;
        }


        private static int? ParseIntNull(string val)
        {
            int validValue = 0;

            if (val == null)
                return null;

            if (!int.TryParse(val.Replace(",", ""), out validValue))
                return null;

            return (int?)validValue;
        }



        private static long ParseLong(string val)
        {
            long validValue = 0;

            if (val == null)
                return validValue;

            long.TryParse(val.Replace(",", ""), out validValue);
            return validValue;
        }


        private static long? ParseLongNull(string val)
        {
            long validValue = 0;

            if (val == null)
                return null;

            if (!long.TryParse(val.Replace(",",""), out validValue))
                return null;

            return (long?)validValue;
        }


        private static DateTime ParseDateTime(string val)
        {
            DateTime validValue = DateTime.Today;
            DateTime.TryParseExact(val, "M/d/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out validValue);

            return validValue;
        }

        private static DateTime? ParseDateTimeNull(string val)
        {
            DateTime validValue = DateTime.Today;
            if (!DateTime.TryParseExact(val,"M/d/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out validValue))
                return null;

            return (DateTime?)validValue;
        }

        private static DateTime? ParseSatDateTimeNull(string val)
        {
            DateTime validValue = DateTime.Today;
            if (!DateTime.TryParseExact(val, "dd.MM.yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out validValue))
                return null;

            return (DateTime?)validValue;
        }


        private static decimal ParseDecimal(string val)
        {
            decimal validValue = 0;

            if (val == null)
                return validValue;

            decimal.TryParse(val.Replace(",", ""), out validValue);
            return validValue;
        }


        private static decimal? ParseDecimalNull(string val)
        {
            decimal validValue = 0;

            if (val == null)
                return null;

            if (!decimal.TryParse(val.Replace(",", ""), out validValue))
                return null;

            return (decimal?)validValue;
        }

        public static void SeedEstadopais(ApplicationDbContext context)
        {

            if (!context.Estadopais.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_estadopais.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;


                        var registroGrabado = context.Estadopais.FirstOrDefault(r => r.Id == id);

                        if (registroGrabado != null)
                        {
                            registroGrabado.Clave = clave_str;
                            registroGrabado.Nombre = nombre_str;

                            context.Estadopais.Update(registroGrabado);
                        }
                        else
                        {

                            context.Estadopais.Add(new Estadopais()
                            {
                                Id = id,
                                Clave = clave_str,
                                Nombre = nombre_str,
                            });
                        }



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstadopais_Update(ApplicationDbContext context, string carpeta, string postfix)
        {

            try
            {

                var idMax = context.Estadopais.Max(e => e.Id);
                var consecutivo = idMax + 1;

                using (var reader = File.OpenText($"{carpeta}/catalogos_control_estadopais{postfix}.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var acronimo_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;


                        var registroGrabado = context.Estadopais.FirstOrDefault(r => r.Clave == clave_str);

                        if (registroGrabado != null)
                        {
                            //registroGrabado.Clave = clave_str;
                            registroGrabado.Nombre = nombre_str;
                            registroGrabado.Acronimo = acronimo_str;
                            context.Estadopais.Update(registroGrabado);
                        }
                        else
                        {
                            context.Estadopais.Add(new Estadopais()
                            {
                                Id = consecutivo,
                                Clave = clave_str,
                                Nombre = nombre_str,
                                Acronimo = acronimo_str
                            });
                            consecutivo++;
                        }



                }
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SeedEstatusdocto(ApplicationDbContext context)
        {

            if (!context.Estatusdocto.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_estatusdocto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var clavesis_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatusdocto.Add(new Estatusdocto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Clavesis = clavesis_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstatusmovto(ApplicationDbContext context)
        {

            if (!context.Estatusmovto.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_estatusmovto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var clavesis_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatusmovto.Add(new Estatusmovto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Clavesis = clavesis_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMeses(ApplicationDbContext context)
        {

            if (!context.Meses.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_meses.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Meses.Add(new Meses()
                        {
                            Id = id,
                            Clave = clave_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedOrigenfiscal(ApplicationDbContext context)
        {

            if (!context.Origenfiscal.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_origenfiscal.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Origenfiscal.Add(new Origenfiscal()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSubtipocliente(ApplicationDbContext context)
        {

            if (!context.Subtipocliente.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_subtipocliente.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var descripcion_str = tokens[3];
                        var esmostrador_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Subtipocliente.Add(new Subtipocliente()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Descripcion = descripcion_str,
                            Esmostrador = ParseBoolCN(esmostrador_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSubtipodocto(ApplicationDbContext context)
        {

            if (!context.Subtipodocto.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_subtipodocto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var saltar_verif_exist_str = tokens[3];
                        var forzar_verif_exist_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Subtipodocto.Add(new Subtipodocto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Saltar_verif_exist = ParseBoolCN(saltar_verif_exist_str),
                            Forzar_verif_exist = ParseBoolCN(forzar_verif_exist_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSubtipodocto_Update(ApplicationDbContext context, string carpeta, string postfix)
        {

            //if (!context.Subtipodocto.Any())
            //{

                using (var reader = File.OpenText($"{carpeta}/catalogos_control_subtipodocto{postfix}.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var saltar_verif_exist_str = tokens[3];
                        var forzar_verif_exist_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;


                        var registroGrabado = context.Subtipodocto.FirstOrDefault(r => r.Id == id);

                        if (registroGrabado != null)
                        {

                            registroGrabado.Clave = clave_str;
                            registroGrabado.Nombre = nombre_str;
                            registroGrabado.Saltar_verif_exist = ParseBoolCN(saltar_verif_exist_str);
                            registroGrabado.Forzar_verif_exist = ParseBoolCN(forzar_verif_exist_str);
                            context.Subtipodocto.Update(registroGrabado);
                        }
                        else
                        {
                            context.Subtipodocto.Add(new Subtipodocto()
                            {
                                Id = id,
                                Clave = clave_str,
                                Nombre = nombre_str,
                                Saltar_verif_exist = ParseBoolCN(saltar_verif_exist_str),
                                Forzar_verif_exist = ParseBoolCN(forzar_verif_exist_str),
                            });
                        }



                    }
                    context.SaveChanges();
                }
            //}
        }

        public static void SeedTipodocto(ApplicationDbContext context)
        {

            if (!context.Tipodocto.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_tipodocto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var sentidoinventario_str = tokens[3];
                        var sentidopago_str = tokens[4];
                        var clasedoctoid_str = tokens[5];
                        var clavesis_str = tokens[6];
                        var sentidoinventarioapartados_str = tokens[7];
                        var sentidopagoapartados_str = tokens[8];
                        var sentidocostopromedio_str = tokens[9];
                        var hacereferencia_str = tokens[10];
                        var tipodistloteimportadoid_str = tokens[11];
                        var tipodoctocancelacionid_str = tokens[12];
                        var sentidoabonocliente_str = tokens[13];
                        var sentidoabonoproveedor_str = tokens[14];
                        var sentidoabonomismocorte_str = tokens[15];
                        var sentidoabonootrocorte_str = tokens[16];
                        var sentidoenprocesosalida_str = tokens[17];
                        var verif_exist_str = tokens[18];
                        var ensamblarkits_str = tokens[19];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipodocto.Add(new Tipodocto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Sentidoinventario = ParseShort(sentidoinventario_str),
                            Sentidopago = ParseShort(sentidopago_str),
                            Clasedoctoid = ParseLongNull(clasedoctoid_str),
                            Clavesis = clavesis_str,
                            Sentidoinventarioapartados = ParseShort(sentidoinventarioapartados_str),
                            Sentidopagoapartados = ParseShort(sentidopagoapartados_str),
                            Sentidocostopromedio = ParseShort(sentidocostopromedio_str),
                            Hacereferencia = ParseBoolCN(hacereferencia_str),
                            Tipodistloteimportadoid = ParseLongNull(tipodistloteimportadoid_str),
                            Tipodoctocancelacionid = ParseLongNull(tipodoctocancelacionid_str),
                            Sentidoabonocliente = ParseShort(sentidoabonocliente_str),
                            Sentidoabonoproveedor = ParseShort(sentidoabonoproveedor_str),
                            Sentidoabonomismocorte = ParseShort(sentidoabonomismocorte_str),
                            Sentidoabonootrocorte = ParseShort(sentidoabonootrocorte_str),
                            Sentidoenprocesosalida = ParseShort(sentidoenprocesosalida_str),
                            Verif_exist = ParseBoolCN(verif_exist_str),
                            Ensamblarkits = ParseBoolCN(ensamblarkits_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedTipodocto_Update(ApplicationDbContext context, string carpeta, string postfix)
        {

            //if (!context.Tipodocto.Any())
            //{

                using (var reader = File.OpenText($"{carpeta}/catalogos_control_tipodocto{postfix}.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var sentidoinventario_str = tokens[3];
                        var sentidopago_str = tokens[4];
                        var clasedoctoid_str = tokens[5];
                        var clavesis_str = tokens[6];
                        var sentidoinventarioapartados_str = tokens[7];
                        var sentidopagoapartados_str = tokens[8];
                        var sentidocostopromedio_str = tokens[9];
                        var hacereferencia_str = tokens[10];
                        var tipodistloteimportadoid_str = tokens[11];
                        var tipodoctocancelacionid_str = tokens[12];
                        var sentidoabonocliente_str = tokens[13];
                        var sentidoabonoproveedor_str = tokens[14];
                        var sentidoabonomismocorte_str = tokens[15];
                        var sentidoabonootrocorte_str = tokens[16];
                        var sentidoenprocesosalida_str = tokens[17];
                        var verif_exist_str = tokens[18];
                        var ensamblarkits_str = tokens[19];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;





                        var registroGrabado = context.Tipodocto.FirstOrDefault(r => r.Id == id);

                        if (registroGrabado != null)
                        {
                            registroGrabado.Clave = clave_str;
                            registroGrabado.Nombre = nombre_str;
                            registroGrabado.Sentidoinventario = ParseShort(sentidoinventario_str);
                            registroGrabado.Sentidopago = ParseShort(sentidopago_str);
                            registroGrabado.Clasedoctoid = ParseLongNull(clasedoctoid_str);
                            registroGrabado.Clavesis = clavesis_str;
                            registroGrabado.Sentidoinventarioapartados = ParseShort(sentidoinventarioapartados_str);
                            registroGrabado.Sentidopagoapartados = ParseShort(sentidopagoapartados_str);
                            registroGrabado.Sentidocostopromedio = ParseShort(sentidocostopromedio_str);
                            registroGrabado.Hacereferencia = ParseBoolCN(hacereferencia_str);
                            registroGrabado.Tipodistloteimportadoid = ParseLongNull(tipodistloteimportadoid_str);
                            registroGrabado.Tipodoctocancelacionid = ParseLongNull(tipodoctocancelacionid_str);
                            registroGrabado.Sentidoabonocliente = ParseShort(sentidoabonocliente_str);
                            registroGrabado.Sentidoabonoproveedor = ParseShort(sentidoabonoproveedor_str);
                            registroGrabado.Sentidoabonomismocorte = ParseShort(sentidoabonomismocorte_str);
                            registroGrabado.Sentidoabonootrocorte = ParseShort(sentidoabonootrocorte_str);
                            registroGrabado.Sentidoenprocesosalida = ParseShort(sentidoenprocesosalida_str);
                            registroGrabado.Verif_exist = ParseBoolCN(verif_exist_str);
                            registroGrabado.Ensamblarkits = ParseBoolCN(ensamblarkits_str);

                            context.Tipodocto.Update(registroGrabado);
                        }
                        else
                        {

                            context.Tipodocto.Add(new Tipodocto()
                            {
                                Id = id,
                                Clave = clave_str,
                                Nombre = nombre_str,
                                Sentidoinventario = ParseShort(sentidoinventario_str),
                                Sentidopago = ParseShort(sentidopago_str),
                                Clasedoctoid = ParseLongNull(clasedoctoid_str),
                                Clavesis = clavesis_str,
                                Sentidoinventarioapartados = ParseShort(sentidoinventarioapartados_str),
                                Sentidopagoapartados = ParseShort(sentidopagoapartados_str),
                                Sentidocostopromedio = ParseShort(sentidocostopromedio_str),
                                Hacereferencia = ParseBoolCN(hacereferencia_str),
                                Tipodistloteimportadoid = ParseLongNull(tipodistloteimportadoid_str),
                                Tipodoctocancelacionid = ParseLongNull(tipodoctocancelacionid_str),
                                Sentidoabonocliente = ParseShort(sentidoabonocliente_str),
                                Sentidoabonoproveedor = ParseShort(sentidoabonoproveedor_str),
                                Sentidoabonomismocorte = ParseShort(sentidoabonomismocorte_str),
                                Sentidoabonootrocorte = ParseShort(sentidoabonootrocorte_str),
                                Sentidoenprocesosalida = ParseShort(sentidoenprocesosalida_str),
                                Verif_exist = ParseBoolCN(verif_exist_str),
                                Ensamblarkits = ParseBoolCN(ensamblarkits_str),
                            });
                        }



                    }
                    context.SaveChanges();
                }
            //}
        }

        //public static void SeedTipodoctoventa(ApplicationDbContext context)
        //{

        //    if (!context.tipodoctoventa.Any())
        //    {

        //        using (var reader = File.OpenText("./SeedData/catalogos_control_tipodoctoventa.csv"))
        //        {
        //            while (true)
        //            {

        //                var line = reader.ReadLine();

        //                if (line is null)
        //                {
        //                    break;
        //                }

        //                var tokens = line.Split(';');

        //                //Debug.Assert(tokens.Length == 3);

        //                var id_str = tokens[0];
        //                var clave_str = tokens[1];
        //                var nombre_str = tokens[2];
        //                var id = id_str != null ? ParseLong(id_str) : 1;

        //                context.Tipodoctoventa.Add(new Tipodoctoventa()
        //                {
        //                    Id = id,
        //                    Clave = clave_str,
        //                    Nombre = nombre_str,
        //                });



        //            }
        //            context.SaveChanges();
        //        }
        //    }
        //}


        //public static void SeedTipopersona(ApplicationDbContext context)
        //{

        //    if (!context.Tipopersona.Any())
        //    {

        //        using (var reader = File.OpenText("./SeedData/catalogos_control_tipopersona.csv"))
        //        {
        //            while (true)
        //            {

        //                var line = reader.ReadLine();

        //                if (line is null)
        //                {
        //                    break;
        //                }

        //                var tokens = line.Split(';');

        //                //Debug.Assert(tokens.Length == 3);

        //                var id_str = tokens[0];
        //                var clave_str = tokens[1];
        //                var nombre_str = tokens[2];
        //                var descripcion_str = tokens[3];
        //                var memo_str = tokens[4];
        //                var id = id_str != null ? ParseLong(id_str) : 1;

        //                context.Tipopersona.Add(new Tipopersona()
        //                {
        //                    Id = id,
        //                    Clave = clave_str,
        //                    Nombre = nombre_str,
        //                    Descripcion = descripcion_str,
        //                    Memo = memo_str,
        //                });



        //            }
        //            context.SaveChanges();
        //        }
        //    }
        //}


        public static void SeedTiporecarga(ApplicationDbContext context)
        {

            if (!context.Tiporecarga.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_tiporecarga.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tiporecarga.Add(new Tiporecarga()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMoneda(ApplicationDbContext context)
        {

            if (!context.Moneda.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_moneda.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var descripcion_str = tokens[3];
                        var tipocambio_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Moneda.Add(new Moneda()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Descripcion = descripcion_str,
                            Tipocambio = ParseDecimal(tipocambio_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSaludo(ApplicationDbContext context)
        {

            if (!context.Saludo.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_saludo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Saludo.Add(new Saludo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedFormapagosat(ApplicationDbContext context)
        {

            if (!context.Formapagosat.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_formapagosat.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var formapagoid_str = tokens[3];
                        var sat_bancarizado_str = tokens[4];
                        var sat_numoperacion_str = tokens[5];
                        var sat_rfcemisorordenante_str = tokens[6];
                        var sat_cuentaordenante_str = tokens[7];
                        var sat_patronordenante_str = tokens[8];
                        var sat_rfcemisorbeneficiario_str = tokens[9];
                        var sat_cuentabeneficiario_str = tokens[10];
                        var sat_patronbeneficiario_str = tokens[11];
                        var sat_tipocadenapago_str = tokens[12];
                        var sat_bancoemisor_str = tokens[13];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Formapagosat.Add(new Formapagosat()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Formapagoid = ParseLongNull(formapagoid_str),
                            Sat_bancarizado = sat_bancarizado_str,
                            Sat_numoperacion = sat_numoperacion_str,
                            Sat_rfcemisorordenante = sat_rfcemisorordenante_str,
                            Sat_cuentaordenante = sat_cuentaordenante_str,
                            Sat_patronordenante = sat_patronordenante_str,
                            Sat_rfcemisorbeneficiario = sat_rfcemisorbeneficiario_str,
                            Sat_cuentabeneficiario = sat_cuentabeneficiario_str,
                            Sat_patronbeneficiario = sat_patronbeneficiario_str,
                            Sat_tipocadenapago = sat_tipocadenapago_str,
                            Sat_bancoemisor = sat_bancoemisor_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_codigopostal(ApplicationDbContext context)
        {

            if (!context.Sat_codigopostal.Any())
            {
                int iCount = 0;
                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_codigopostal.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_estado_str = tokens[2];
                        var sat_municipio_str = tokens[3];
                        var sat_localidad_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_codigopostal.Add(new Sat_codigopostal()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_estado = sat_estado_str,
                            Sat_municipio = sat_municipio_str,
                            Sat_localidad = sat_localidad_str,
                        });

                        iCount++;

                        if(iCount%250 == 0)
                            context.SaveChanges();

                       



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_impuesto(ApplicationDbContext context)
        {

            if (!context.Sat_impuesto.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_impuesto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_descripcion_str = tokens[2];
                        var sat_retencion_str = tokens[3];
                        var sat_traslado_str = tokens[4];
                        var sat_localfederal_str = tokens[5];
                        var sat_entidadaplica_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_impuesto.Add(new Sat_impuesto()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_retencion = sat_retencion_str,
                            Sat_traslado = sat_traslado_str,
                            Sat_localfederal = sat_localfederal_str,
                            Sat_entidadaplica = sat_entidadaplica_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_metodopago(ApplicationDbContext context)
        {

            if (!context.Sat_metodopago.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_metodopago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_description_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_metodopago.Add(new Sat_metodopago()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_description = sat_description_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_moneda(ApplicationDbContext context)
        {

            if (!context.Sat_moneda.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_moneda.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_descripcion_str = tokens[2];
                        var sat_decimales_str = tokens[3];
                        var sat_variacion_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_moneda.Add(new Sat_moneda()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_decimales = ParseInt(sat_decimales_str),
                            Sat_variacion = sat_variacion_str
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_pais(ApplicationDbContext context)
        {

            if (!context.Sat_pais.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_pais.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_descripcion_str = tokens[2];
                        var sat_formatocp_str = tokens[3];
                        var sat_formatorit_str = tokens[4];
                        var sat_validacionrit_str = tokens[5];
                        var sat_agrupaciones_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_pais.Add(new Sat_pais()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_formatocp = sat_formatocp_str,
                            Sat_formatorit = sat_formatorit_str,
                            Sat_validacionrit = sat_validacionrit_str,
                            Sat_agrupaciones = sat_agrupaciones_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_patenteaduanal(ApplicationDbContext context)
        {

            if (!context.Sat_patenteaduanal.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_patenteaduanal.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_fechainicio_str = tokens[2];
                        var sat_fechafin_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_patenteaduanal.Add(new Sat_patenteaduanal()
                        {
                            Id = id,
                            Sat_clave = ParseInt(sat_clave_str),
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_pedimentos(ApplicationDbContext context)
        {

            if (!context.Sat_pedimentos.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_pedimentos.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_claveaduana_str = tokens[1];
                        var sat_patente_str = tokens[2];
                        var sat_ejercicio_str = tokens[3];
                        var sat_cantidad_str = tokens[4];
                        var sat_fechainicio_str = tokens[5];
                        var sat_fechafin_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_pedimentos.Add(new Sat_pedimentos()
                        {
                            Id = id,
                            Sat_claveaduana = ParseInt(sat_claveaduana_str),
                            Sat_patente = ParseInt(sat_patente_str),
                            Sat_ejercicio = ParseInt(sat_ejercicio_str),
                            Sat_cantidad = sat_cantidad_str,
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_productoservicio(ApplicationDbContext context)
        {

            if (!context.Sat_productoservicio.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_productoservicio.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_claveprodserv_str = tokens[1];
                        var sat_descripcion_str = tokens[2];
                        var sat_fechainicio_str = tokens[3];
                        var sat_fechafin_str = tokens[4];
                        var sat_ivatrasladado_str = tokens[5];
                        var sat_iepstrasladado_str = tokens[6];
                        var sat_complemento_str = tokens[7];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_productoservicio.Add(new Sat_productoservicio()
                        {
                            Id = id,
                            Sat_claveprodserv = sat_claveprodserv_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str),
                            Sat_ivatrasladado = sat_ivatrasladado_str,
                            Sat_iepstrasladado = sat_iepstrasladado_str,
                            Sat_complemento = sat_complemento_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_regimenfiscal(ApplicationDbContext context)
        {

            if (!context.Sat_regimenfiscal.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_regimenfiscal.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_description_str = tokens[2];
                        var sat_personafisica_str = tokens[3];
                        var sat_personamoral_str = tokens[4];
                        var sat_fechainicio_str = tokens[5];
                        var sat_fechafin_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_regimenfiscal.Add(new Sat_regimenfiscal()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_description = sat_description_str,
                            Sat_personafisica = sat_personafisica_str,
                            Sat_personamoral = sat_personamoral_str,
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_tasacuota(ApplicationDbContext context)
        {

            if (!context.Sat_tasacuota.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tasacuota.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_rangofijo_str = tokens[1];
                        var sat_valorminimo_str = tokens[2];
                        var sat_valormaximo_str = tokens[3];
                        var sat_impuesto_str = tokens[4];
                        var sat_factor_str = tokens[5];
                        var sat_traslado_str = tokens[6];
                        var sat_retencion_str = tokens[7];
                        var sat_fechainicio_str = tokens[8];
                        var sat_fechafin_str = tokens[9];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tasacuota.Add(new Sat_tasacuota()
                        {
                            Id = id,
                            Sat_rangofijo = sat_rangofijo_str,
                            Sat_valorminimo = ParseDecimalNull(sat_valorminimo_str),
                            Sat_valormaximo = ParseDecimalNull(sat_valormaximo_str),
                            Sat_impuesto = sat_impuesto_str,
                            Sat_factor = sat_factor_str,
                            Sat_traslado = sat_traslado_str,
                            Sat_retencion = sat_retencion_str,
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_tipocomprobante(ApplicationDbContext context)
        {

            if (!context.Sat_tipocomprobante.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tipocomprobante.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_descripcion_str = tokens[2];
                        var sat_valormaximo_str = tokens[3];
                        var sat_fechainicio_str = tokens[4];
                        var sat_fechafin_str = tokens[5];
                        var sat_ns_str = tokens[6];
                        var sat_nds_str = tokens[7];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tipocomprobante.Add(new Sat_tipocomprobante()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_valormaximo = ParseInt(sat_valormaximo_str),
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str),
                            Sat_ns = sat_ns_str,
                            Sat_nds = sat_nds_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_tipofactor(ApplicationDbContext context)
        {

            if (!context.Sat_tipofactor.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tipofactor.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tipofactor.Add(new Sat_tipofactor()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_tiporelacion(ApplicationDbContext context)
        {

            if (!context.Sat_tiporelacion.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tiporelacion.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_descripcion_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tiporelacion.Add(new Sat_tiporelacion()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_descripcion = sat_descripcion_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_unidadmedida(ApplicationDbContext context)
        {

            if (!context.Sat_unidadmedida.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_unidadmedida.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_nombre_str = tokens[2];
                        var sat_descripcion_str = tokens[3];
                        var sat_fechainicio_str = tokens[4];
                        var sat_fechafin_str = tokens[5];
                        var sat_simbolo_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_unidadmedida.Add(new Sat_unidadmedida()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_nombre = sat_nombre_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str),
                            Sat_simbolo = sat_simbolo_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_usocfdi(ApplicationDbContext context)
        {

            if (!context.Sat_usocfdi.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_usocfdi.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[1];
                        var sat_descripcion_str = tokens[2];
                        var sat_personafisica_str = tokens[3];
                        var sat_personamoral_str = tokens[4];
                        var sat_fechainicio_str = tokens[5];
                        var sat_fechafin_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_usocfdi.Add(new Sat_usocfdi()
                        {
                            Id = id,
                            Sat_clave = sat_clave_str,
                            Sat_descripcion = sat_descripcion_str,
                            Sat_personafisica = sat_personafisica_str,
                            Sat_personamoral = sat_personamoral_str,
                            Sat_fechainicio = ParseDateTimeNull(sat_fechainicio_str),
                            Sat_fechafin = ParseDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_versioncatalogo(ApplicationDbContext context)
        {

            if (!context.Sat_versioncatalogo.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_versioncatalogo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var fecha_str = tokens[1];
                        var version_catalogo_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_versioncatalogo.Add(new Sat_versioncatalogo()
                        {
                            Id = id,
                            Fecha = ParseDateTimeNull(fecha_str),
                            Version_catalogo = ParseLong(version_catalogo_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTasaiva(ApplicationDbContext context)
        {

            if (!context.Tasaiva.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_tasaiva.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var tasa_str = tokens[3];
                        var fechainicia_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tasaiva.Add(new Tasaiva()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Tasa = ParseDecimal(tasa_str),
                            Fechainicia = ParseDateTimeNull(fechainicia_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTasasieps(ApplicationDbContext context)
        {

            if (!context.Tasaieps.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_tasasieps.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var tasa_str = tokens[1];
                        var ultimafecha_str = tokens[2];
                        var cantidadreg_str = tokens[3];
                        var primerafecha_str = tokens[4];
                        var gpoimp_str = tokens[5];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tasaieps.Add(new Tasaieps()
                        {
                            Id = id,
                            Tasa = ParseDecimal(tasa_str),
                            Ultimafecha = ParseDateTimeNull(ultimafecha_str),
                            //Cantidadreg = cantidadreg_str,
                            Primerafecha = ParseDateTimeNull(primerafecha_str)
                            //Gpoimp = gpoimp_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstadocobranza(ApplicationDbContext context)
        {

            if (!context.Estadocobranza.Any())
            {

                using (var reader = File.OpenText("./SeedData/cobranza_estadocobranza.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estadocobranza.Add(new Estadocobranza()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstadopagocontrarecibo(ApplicationDbContext context)
        {

            if (!context.Estadopagocontrarecibo.Any())
            {

                using (var reader = File.OpenText("./SeedData/contrarecibos_estadopagocontrarecibo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estadopagocontrarecibo.Add(new Estadopagocontrarecibo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipodistloteimportado(ApplicationDbContext context)
        {

            if (!context.Tipodistloteimportado.Any())
            {

                using (var reader = File.OpenText("./SeedData/core_lotesimportados_tipodistloteimportado.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipodistloteimportado.Add(new Tipodistloteimportado()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedCorte_calculo_def(ApplicationDbContext context)
        {

            if (!context.Corte_calculo_def.Any())
            {

                using (var reader = File.OpenText("./SeedData/corte_corte_calculo_def.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var tipodoctoid_str = tokens[3];
                        var direccion_str = tokens[4];
                        var formapagoid_str = tokens[5];
                        var mismocorte_str = tokens[6];
                        var traslado_str = tokens[7];
                        var concepto_str = tokens[8];
                        var reversionabono_str = tokens[9];
                        var montoocuenta_str = tokens[10];
                        var clasedoctocorte_str = tokens[11];
                        var importecambio_str = tokens[12];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Corte_calculo_def.Add(new Corte_calculo_def()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Tipodoctoid = ParseLongNull(tipodoctoid_str),
                            Direccion = direccion_str,
                            Formapagoid = ParseLongNull(formapagoid_str),
                            Mismocorte = mismocorte_str,
                            Traslado = traslado_str,
                            Concepto = concepto_str,
                            Reversionabono = reversionabono_str,
                            Montoocuenta = montoocuenta_str,
                            Clasedoctocorte = clasedoctocorte_str,
                            Importecambio = importecambio_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipocorte(ApplicationDbContext context)
        {

            if (!context.Tipocorte.Any())
            {

                using (var reader = File.OpenText("./SeedData/corte_tipocorte.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var variosdias_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipocorte.Add(new Tipocorte()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Variosdias = ParseBoolCN(variosdias_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipomontobilletes(ApplicationDbContext context)
        {

            if (!context.Tipomontobilletes.Any())
            {

                using (var reader = File.OpenText("./SeedData/corte_tipomontobilletes.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipomontobilletes.Add(new Tipomontobilletes()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipotransaccion(ApplicationDbContext context)
        {

            if (!context.Tipotransaccion.Any())
            {

                using (var reader = File.OpenText("./SeedData/corte_tipotransaccion.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var sentidoinventario_str = tokens[3];
                        var sentidopago_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipotransaccion.Add(new Tipotransaccion()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Sentidoinventario = ParseShortNull(sentidoinventario_str),
                            Sentidopago = ParseShortNull(sentidopago_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTurno(ApplicationDbContext context)
        {

            if (!context.Turno.Any())
            {

                using (var reader = File.OpenText("./SeedData/corte_turno.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Turno.Add(new Turno()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstadoguia(ApplicationDbContext context)
        {

            if (!context.Estadoguia.Any())
            {

                using (var reader = File.OpenText("./SeedData/guia_estadoguia.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estadoguia.Add(new Estadoguia()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoentrega(ApplicationDbContext context)
        {

            if (!context.Tipoentrega.Any())
            {

                using (var reader = File.OpenText("./SeedData/guia_tipoentrega.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoentrega.Add(new Tipoentrega()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoeventotabla(ApplicationDbContext context)
        {

            if (!context.Tipoeventotabla.Any())
            {

                using (var reader = File.OpenText("./SeedData/incidencia_tipoeventotabla.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoeventotabla.Add(new Tipoeventotabla()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoincidencia(ApplicationDbContext context)
        {

            if (!context.Tipoincidencia.Any())
            {

                using (var reader = File.OpenText("./SeedData/incidencia_tipoincidencia.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoincidencia.Add(new Tipoincidencia()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedGrupodiferenciainventario(ApplicationDbContext context)
        {

            if (!context.Grupodiferenciainventario.Any())
            {

                using (var reader = File.OpenText("./SeedData/inventario_grupodiferenciainventario.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var descripcion_str = tokens[3];
                        var memo_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Grupodiferenciainventario.Add(new Grupodiferenciainventario()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Descripcion = descripcion_str,
                            Memo = memo_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipodiferenciainventario(ApplicationDbContext context)
        {

            if (!context.Tipodiferenciainventario.Any())
            {

                using (var reader = File.OpenText("./SeedData/inventario_tipodiferenciainventario.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var descripcion_str = tokens[3];
                        var memo_str = tokens[4];
                        var grupodiferenciainventarioid_str = tokens[5];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipodiferenciainventario.Add(new Tipodiferenciainventario()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Descripcion = descripcion_str,
                            Memo = memo_str,
                            Grupodiferenciainventarioid = ParseLongNull(grupodiferenciainventarioid_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMensajeestado(ApplicationDbContext context)
        {

            if (!context.Mensajeestado.Any())
            {

                using (var reader = File.OpenText("./SeedData/mensajeria_mensajeestado.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Mensajeestado.Add(new Mensajeestado()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMensajenivelurgencia(ApplicationDbContext context)
        {

            if (!context.Mensajenivelurgencia.Any())
            {

                using (var reader = File.OpenText("./SeedData/mensajeria_mensajenivelurgencia.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Mensajenivelurgencia.Add(new Mensajenivelurgencia()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMensajetipo(ApplicationDbContext context)
        {

            if (!context.Mensajetipo.Any())
            {

                using (var reader = File.OpenText("./SeedData/mensajeria_mensajetipo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Mensajetipo.Add(new Mensajetipo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipomonederomovto(ApplicationDbContext context)
        {

            if (!context.Tipomonederomovto.Any())
            {

                using (var reader = File.OpenText("./SeedData/monedero_tipomonederomovto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var esentrada_str = tokens[3];
                        var essalida_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipomonederomovto.Add(new Tipomonederomovto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Esentrada = ParseBoolCN(esentrada_str),
                            Essalida = ParseBoolCN(essalida_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstatusdoctopago(ApplicationDbContext context)
        {

            if (!context.Estatusdoctopago.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_estatusdoctopago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var clavesis_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatusdoctopago.Add(new Estatusdoctopago()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Clavesis = clavesis_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstatuspago(ApplicationDbContext context)
        {

            if (!context.Estatuspago.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_estatuspago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatuspago.Add(new Estatuspago()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedFormapago(ApplicationDbContext context)
        {

            if (!context.Formapago.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_formapago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var esefectivo_str = tokens[3];
                        var abona_str = tokens[4];
                        var afectasaldopersona_str = tokens[5];
                        var afectasaldoapartados_str = tokens[6];
                        var sentidoabonopago_str = tokens[7];
                        var sentidoabono_str = tokens[8];
                        var afectasaldocorte_str = tokens[9];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Formapago.Add(new Formapago()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Esefectivo = ParseBoolCN(esefectivo_str),
                            Abona = ParseBoolCS(abona_str),
                            Afectasaldopersona = ParseBoolCS(afectasaldopersona_str),
                            Afectasaldoapartados = ParseBoolCN(afectasaldoapartados_str),
                            Sentidoabonopago = ParseIntNull(sentidoabonopago_str),
                            Sentidoabono = ParseIntNull(sentidoabono_str),
                            Afectasaldocorte = ParseBoolCS(afectasaldocorte_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMotivo_camfec(ApplicationDbContext context)
        {

            if (!context.Motivo_camfec.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_motivo_camfec.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var descripcion_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Motivo_camfec.Add(new Motivo_camfec()
                        {
                            Id = id,
                            Clave = clave_str,
                            Descripcion = descripcion_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSubtipopago(ApplicationDbContext context)
        {

            if (!context.Subtipopago.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_subtipopago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Subtipopago.Add(new Subtipopago()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoabono(ApplicationDbContext context)
        {

            if (!context.Tipoabono.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_tipoabono.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoabono.Add(new Tipoabono()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoaplicacioncredito(ApplicationDbContext context)
        {

            if (!context.Tipoaplicacioncredito.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_tipoaplicacioncredito.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoaplicacioncredito.Add(new Tipoaplicacioncredito()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipomovimientokardexabono(ApplicationDbContext context)
        {

            if (!context.Tipomovimientokardexabono.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_tipomovimientokardexabono.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipomovimientokardexabono.Add(new Tipomovimientokardexabono()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipopago(ApplicationDbContext context)
        {

            if (!context.Tipopago.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_tipopago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipopago.Add(new Tipopago()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTiporelacionpago(ApplicationDbContext context)
        {

            if (!context.Tiporelacionpago.Any())
            {

                using (var reader = File.OpenText("./SeedData/pagos_cat_ctrl_tiporelacionpago.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tiporelacionpago.Add(new Tiporelacionpago()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedIngresuc_tipolinea(ApplicationDbContext context)
        {

            if (!context.Ingresuc_tipolinea.Any())
            {

                using (var reader = File.OpenText("./SeedData/poliza_ingresuc_tipolinea.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var descripcion_str = tokens[2];
                        var estequileno_str = tokens[3];
                        var esfactura_str = tokens[4];
                        var escredito_str = tokens[5];
                        var tiporeg_str = tokens[6];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Ingresuc_tipolinea.Add(new Ingresuc_tipolinea()
                        {
                            Id = id,
                            Clave = clave_str,
                            Descripcion = descripcion_str,
                            Estequileno = ParseBoolCN(estequileno_str),
                            Esfactura = ParseBoolCN(esfactura_str),
                            Escredito = ParseBoolCN(escredito_str),
                            Tiporeg = tiporeg_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipolineapoliza(ApplicationDbContext context)
        {

            if (!context.Tipolineapoliza.Any())
            {

                using (var reader = File.OpenText("./SeedData/poliza_tipolineapoliza.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var sumarizado_str = tokens[3];
                        var manejatasa_str = tokens[4];
                        var manejaformapago_str = tokens[5];
                        var manejaesfact_str = tokens[6];
                        var orden_str = tokens[7];
                        var tipoentrada_str = tokens[8];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipolineapoliza.Add(new Tipolineapoliza()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Sumarizado = ParseBoolCN(sumarizado_str),
                            Manejatasa = ParseBoolCN(manejatasa_str),
                            Manejaformapago = ParseBoolCN(manejaformapago_str),
                            Manejaesfact = ParseBoolCN(manejaesfact_str),
                            Orden = ParseIntNull(orden_str),
                            Tipoentrada = ParseLongNull(tipoentrada_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedCamporeferenciaprecio(ApplicationDbContext context)
        {

            if (!context.Camporeferenciaprecio.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_cat_ctrl_camporeferenciaprecio.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var listacliente_str = tokens[3];
                        var listatraslado_str = tokens[4];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Camporeferenciaprecio.Add(new Camporeferenciaprecio()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Listacliente = ParseBoolCN(listacliente_str),
                            Listatraslado = ParseBoolCN(listatraslado_str)
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipodescuentoprod(ApplicationDbContext context)
        {

            if (!context.Tipodescuentoprod.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_cat_ctrl_tipodescuentoprod.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipodescuentoprod.Add(new Tipodescuentoprod()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipodescuentovale(ApplicationDbContext context)
        {

            if (!context.Tipodescuentovale.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_cat_ctrl_tipodescuentovale.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipodescuentovale.Add(new Tipodescuentovale()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoutilidad(ApplicationDbContext context)
        {

            if (!context.Tipoutilidad.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_cat_ctrl_tipoutilidad.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoutilidad.Add(new Tipoutilidad()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipo_impuesto(ApplicationDbContext context)
        {

            if (!context.Tipo_impuesto.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_cat_ctrl_tipo_impuesto.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipo_impuesto.Add(new Tipo_impuesto()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipo_precio(ApplicationDbContext context)
        {

            if (!context.Tipo_precio.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_cat_ctrl_tipo_precio.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipo_precio.Add(new Tipo_precio()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipomayoreo(ApplicationDbContext context)
        {

            if (!context.Tipomayoreo.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_tipomayoreo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipomayoreo.Add(new Tipomayoreo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoprecio(ApplicationDbContext context)
        {

            if (!context.Tipoprecio.Any())
            {

                using (var reader = File.OpenText("./SeedData/precios_tipoprecio.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoprecio.Add(new Tipoprecio()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedRangopromocion(ApplicationDbContext context)
        {

            if (!context.Rangopromocion.Any())
            {

                using (var reader = File.OpenText("./SeedData/precio_promocion_rangopromocion.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Rangopromocion.Add(new Rangopromocion()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipopromocion(ApplicationDbContext context)
        {

            if (!context.Tipopromocion.Any())
            {

                using (var reader = File.OpenText("./SeedData/precio_promocion_tipopromocion.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipopromocion.Add(new Tipopromocion()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstatusrebaja(ApplicationDbContext context)
        {

            if (!context.Estatusrebaja.Any())
            {

                using (var reader = File.OpenText("./SeedData/rebaja_especial_estatusrebaja.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];
                        var clavesis_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatusrebaja.Add(new Estatusrebaja()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                            Clavesis = clavesis_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedReplgroupdef(ApplicationDbContext context)
        {

            if (!context.Replgroupdef.Any())
            {

                using (var reader = File.OpenText("./SeedData/replicacion_replgroupdef.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Replgroupdef.Add(new Replgroupdef()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedRepltipomov(ApplicationDbContext context)
        {

            if (!context.Repltipomov.Any())
            {

                using (var reader = File.OpenText("./SeedData/replicacion_repltipomov.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Repltipomov.Add(new Repltipomov()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }




        public static void SeedRepltablagroupdef(ApplicationDbContext context)
        {

            if (!context.Repltablagroupdef.Any())
            {

                using (var reader = File.OpenText("./SeedData/replicacion_repltablagroupdef.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var nombretabla_str = tokens[1];
                        var idgroupdef_str = tokens[2];


                        if (id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;
                        var idgroupdef = idgroupdef_str != null ? ParseLong(idgroupdef_str) : 1;

                        context.Repltablagroupdef.Add(new Repltablagroupdef()
                        {
                            Id = id,
                            Nombretabla = nombretabla_str,
                            Idgroupdef = idgroupdef
                        });



                    }
                    context.SaveChanges();
                }
            }
        }



        public static void SeedEstadorevisado(ApplicationDbContext context)
        {

            if (!context.Estadorevisado.Any())
            {

                using (var reader = File.OpenText("./SeedData/revision_estadorevisado.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estadorevisado.Add(new Estadorevisado()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstadosurtido(ApplicationDbContext context)
        {

            if (!context.Estadosurtido.Any())
            {

                using (var reader = File.OpenText("./SeedData/surtido_estadosurtido.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estadosurtido.Add(new Estadosurtido()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstatusexpo(ApplicationDbContext context)
        {

            if (!context.Estatusexpo.Any())
            {

                using (var reader = File.OpenText("./SeedData/sync_cat_ctrl_estatusexpo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatusexpo.Add(new Estatusexpo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedEstatusimpo(ApplicationDbContext context)
        {

            if (!context.Estatusimpo.Any())
            {

                using (var reader = File.OpenText("./SeedData/sync_cat_ctrl_estatusimpo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Estatusimpo.Add(new Estatusimpo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoexpo(ApplicationDbContext context)
        {

            if (!context.Tipoexpo.Any())
            {

                using (var reader = File.OpenText("./SeedData/sync_cat_ctrl_tipoexpo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoexpo.Add(new Tipoexpo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedTipoimpo(ApplicationDbContext context)
        {

            if (!context.Tipoimpo.Any())
            {

                using (var reader = File.OpenText("./SeedData/sync_cat_ctrl_tipoimpo.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var nombre_str = tokens[2];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipoimpo.Add(new Tipoimpo()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedMotivo_devolucion(ApplicationDbContext context)
        {

            if (!context.Motivo_devolucion.Any())
            {

                using (var reader = File.OpenText("./SeedData/traslados_motivo_devolucion.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[1];
                        var descripcion_str = tokens[2];
                        var nombre_str = tokens[3];


                        if (id_str == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Motivo_devolucion.Add(new Motivo_devolucion()
                        {
                            Id = id,
                            Clave = clave_str,
                            Descripcion = descripcion_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_clavetransporte(ApplicationDbContext context)
        {

            if (!context.Sat_clavetransporte.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_clavetransporte.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_fechainicio_str = tokens[8];
                        var sat_fechafin_str = tokens[9];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_clavetransporte.Add(new Sat_clavetransporte()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_tipoembalaje(ApplicationDbContext context)
        {

            if (!context.Sat_tipoembalaje.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tipoembalaje.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_fechainicio_str = tokens[8];
                        var sat_fechafin_str = tokens[9];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tipoembalaje.Add(new Sat_tipoembalaje()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }



        public static void SeedSat_tipopermiso(ApplicationDbContext context)
        {

            if (!context.Sat_tipopermiso.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tipopermiso.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_clavetransporte_str = tokens[8];
                        var sat_fechainicio_str = tokens[9];
                        var sat_fechafin_str = tokens[10];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tipopermiso.Add(new Sat_tipopermiso()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Clavetransporte = sat_clavetransporte_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_tipoestacion(ApplicationDbContext context)
        {

            if (!context.Sat_tipoestacion.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_tipoestacion.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_clavetransporte_str = tokens[8];
                        var sat_fechainicio_str = tokens[9];
                        var sat_fechafin_str = tokens[10];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_tipoestacion.Add(new Sat_tipoestacion()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Clavestransporte = sat_clavetransporte_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_claveunidadpeso(ApplicationDbContext context)
        {

            if (!context.Sat_claveunidadpeso.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_claveunidadpeso.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_nombre_str = tokens[7];
                        var sat_descripcion_str = tokens[8];
                        var sat_nota_str = tokens[9];
                        var sat_fechainicio_str = tokens[10];
                        var sat_fechafin_str = tokens[11];
                        var sat_simbolo_str = tokens[12];
                        var sat_bandera_str = tokens[13];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_claveunidadpeso.Add(new Sat_claveunidadpeso()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Nombre = sat_nombre_str,
                            Descripcion = sat_descripcion_str.Substring(0, Math.Min(sat_descripcion_str.Length, 127)),
                            Nota = sat_nota_str.Substring(0, Math.Min(sat_nota_str.Length, 127)),
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                            Simbolo = sat_simbolo_str,
                            Bandera = sat_bandera_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_partetransporte(ApplicationDbContext context)
        {

            if (!context.Sat_partetransporte.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_partetransporte.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_fechainicio_str = tokens[8];
                        var sat_fechafin_str = tokens[9];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_partetransporte.Add(new Sat_partetransporte()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSat_figuratransporte(ApplicationDbContext context)
        {

            if (!context.Sat_figuratransporte.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_figuratransporte.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_fechainicio_str = tokens[8];
                        var sat_fechafin_str = tokens[9];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_figuratransporte.Add(new Sat_figuratransporte()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSat_subtiporem(ApplicationDbContext context)
        {

            if (!context.Sat_subtiporem.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_subtiporem.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];
                        var sat_fechainicio_str = tokens[8];
                        var sat_fechafin_str = tokens[9];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_subtiporem.Add(new Sat_subtiporem()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_matpeligroso(ApplicationDbContext context)
        {

            if (!context.Sat_matpeligroso.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_matpeligroso.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];

                        var sat_clase_str = tokens[8];
                        var sat_peligrosecundario_str = tokens[9];
                        var sat_nombre_tecnico_str = tokens[10];

                        var sat_fechainicio_str = tokens[11];
                        var sat_fechafin_str = tokens[12];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_matpeligroso.Add(new Sat_matpeligroso()
                        {
                            Id = id,
                            Clave = sat_clave_str.Substring(0, Math.Min(sat_clave_str.Length, 64)),
                            Descripcion = sat_descripcion_str.Substring(0, Math.Min(sat_descripcion_str.Length, 255)),
                            Clase =  sat_clase_str.Substring(0, Math.Min(sat_clase_str.Length, 32)) ,
                            Peligro_secundario = sat_peligrosecundario_str.Substring(0, Math.Min(sat_peligrosecundario_str.Length, 32)),
                            Nombre_tecnico = sat_nombre_tecnico_str.Substring(0, Math.Min(sat_nombre_tecnico_str.Length, 255)), 
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSat_configautotransporte(ApplicationDbContext context)
        {

            if (!context.Sat_configautotransporte.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_configautotransporte.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_descripcion_str = tokens[7];

                        var sat_numeroejes_str = tokens[8];
                        var sat_numerollantas_str = tokens[9];
                        var sat_remolque_str = tokens[10];

                        var sat_fechainicio_str = tokens[11];
                        var sat_fechafin_str = tokens[12];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_configautotransporte.Add(new Sat_configautotransporte()
                        {
                            Id = id,
                            Clave = sat_clave_str,
                            Descripcion = sat_descripcion_str,
                            Numeroejes = sat_numeroejes_str,
                            Numerollantas = sat_numerollantas_str,
                            Remolque = sat_remolque_str,
                            Fechainicio = ParseSatDateTimeNull(sat_fechainicio_str),
                            Fechafin = ParseSatDateTimeNull(sat_fechafin_str),
                        });



                    }
                    context.SaveChanges();
                }
            }
        }


        public static void SeedSat_municipio(ApplicationDbContext context)
        {

            if (!context.Sat_municipio.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_municipio.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_clave_estado = tokens[7];
                        var sat_descripcion_str = tokens[8];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_municipio.Add(new Sat_municipio()
                        {
                            Id = id,
                            Clave_municipio = sat_clave_str,
                            Clave_estado = sat_clave_estado,
                            Descripcion = sat_descripcion_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSat_localidad(ApplicationDbContext context)
        {

            if (!context.Sat_localidad.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_localidad.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_clave_str = tokens[6];
                        var sat_clave_estado = tokens[7];
                        var sat_descripcion_str = tokens[8];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_localidad.Add(new Sat_localidad()
                        {
                            Id = id,
                            Clave_localidad = sat_clave_str,
                            Clave_estado = sat_clave_estado,
                            Descripcion = sat_descripcion_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedTipodoctonota(ApplicationDbContext context)
        {

            if (!context.Tipodoctonota.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_tipodoctonota.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var clave_str = tokens[6];
                        var nombre_str = tokens[7];


                        if (id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Tipodoctonota.Add(new Tipodoctonota()
                        {
                            Id = id,
                            Clave = clave_str,
                            Nombre = nombre_str,
                        });



                    }
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSat_colonia(ApplicationDbContext context)
        {
            int iCount = 0;

            if (!context.Sat_colonia.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_sat_sat_colonia.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        //Debug.Assert(tokens.Length == 3);

                        var id_str = tokens[0];
                        var sat_colonia_str = tokens[6];
                        var sat_codigopostal_estado = tokens[7];
                        var sat_nombre_str = tokens[8];


                        if (id_str == null || id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Sat_colonia.Add(new Sat_colonia()
                        {
                            Id = id,
                            Colonia = sat_colonia_str,
                            Codigopostal = sat_codigopostal_estado,
                            Nombre = sat_nombre_str,
                        });

                        iCount++;

                        if (iCount % 250 == 0)
                            context.SaveChanges();


                    }
                    context.SaveChanges();
                }
            }
        }



        public static void SeedUnidad(ApplicationDbContext context, long empresaId, long sucursalId)
        {

            if (!context.Unidad.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_unidad.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 10);

                        var id_str = tokens[0];
                        var clave = tokens[6];
                        var nombre = tokens[7];
                        var cantidadecimales = tokens[8];
                        var sat_unidadmedidaid = tokens[9];

                        if (id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Unidad.Add(new Unidad() {  EmpresaId = empresaId, SucursalId = sucursalId, Clave = clave, Nombre = nombre, CantidadDecimales = ParseShort(cantidadecimales), Sat_unidadmedidaid = ParseLongNull(sat_unidadmedidaid) });



                    }
                    context.SaveChanges();
                }
            }
        }



        public static void SeedAgrupacionVenta(ApplicationDbContext context)
        {

            if (!context.Agrupacionventa.Any())
            {

                using (var reader = File.OpenText("./SeedData/catalogos_control_agrupacionventa.csv"))
                {
                    while (true)
                    {

                        var line = reader.ReadLine();

                        if (line is null)
                        {
                            break;
                        }

                        var tokens = line.Split(';');

                        Debug.Assert(tokens.Length == 8);

                        var id_str = tokens[0];
                        var clave = tokens[6];
                        var nombre = tokens[7];

                        if (id_str.ToLower() == "id")
                            continue;

                        var id = id_str != null ? ParseLong(id_str) : 1;

                        context.Agrupacionventa.Add(new Agrupacionventa() { Id = id, EmpresaId = 0, SucursalId = 0, Clave = clave, Nombre = nombre });



                    }
                    context.SaveChanges();
                }
            }
        }





    }
}
