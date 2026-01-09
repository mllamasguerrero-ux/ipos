using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IposV3.Migrations
{
    public partial class CambiosParaIgualar_B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_imp_Empresa_EmpresaId",
                table: "Pagodoctosat_imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_imp_Pagodoctosat_EmpresaId_SucursalId_Pagodoct~",
                table: "Pagodoctosat_imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_imp_Sucursal_EmpresaId_SucursalId",
                table: "Pagodoctosat_imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_imp_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_imp_Usuario_EmpresaId_SucursalId_ModificadoPor~",
                table: "Pagodoctosat_imp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagodoctosat_imp",
                table: "Pagodoctosat_imp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctonota",
                table: "Doctonota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctocomprobante",
                table: "Doctocomprobante");

            migrationBuilder.RenameTable(
                name: "Pagodoctosat_imp",
                newName: "Pagodoctosat_Imp");

            migrationBuilder.RenameIndex(
                name: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Pagodoctosat_Imp",
                newName: "IX_Pagodoctosat_Imp_EmpresaId_SucursalId_Pagodoctosatid");

            migrationBuilder.RenameIndex(
                name: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_ModificadoPorId",
                table: "Pagodoctosat_Imp",
                newName: "IX_Pagodoctosat_Imp_EmpresaId_SucursalId_ModificadoPorId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_Imp",
                newName: "IX_Pagodoctosat_Imp_EmpresaId_SucursalId_CreadoPorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagodoctosat_Imp",
                table: "Pagodoctosat_Imp",
                columns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctonota",
                table: "Doctonota",
                columns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctocomprobante",
                table: "Doctocomprobante",
                columns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.CreateTable(
                name: "Cartaporte",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Doctoid = table.Column<long>(type: "bigint", nullable: true),
                    TranspInternac = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    EntradaSalidaMerc = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    PaisOrigenDestino = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ViaEntradaSalida = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TotalDistRec = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartaporte", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_Cartaporte_Docto_EmpresaId_SucursalId_Doctoid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Doctoid },
                        principalTable: "Docto",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Cartaporte_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartaporte_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartaporte_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Cartaporte_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "Sat_clavetransporte",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_clavetransporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_configautotransporte",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Numeroejes = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Numerollantas = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Remolque = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_configautotransporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_figuratransporte",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_figuratransporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_partetransporte",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_partetransporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_subtiporem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_subtiporem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_tipoestacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Clavestransporte = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_tipoestacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_tipopermiso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Clavetransporte = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_tipopermiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartaporteAutotransp",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cartaporteid = table.Column<long>(type: "bigint", nullable: false),
                    TranspInternac = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Permsct = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numpermisosct = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Configvehicular = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Placavm = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Aniomodelovm = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Asegurarespcivil = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Polizarespcivil = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Aseguramedambiente = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Polizamedambiente = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Aseguracarga = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Polizacarga = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Primaseguro = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Subtiporem1 = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Placa1 = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Subtiporem2 = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Placa2 = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaporteAutotransp", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_CartaporteAutotransp_Cartaporte_EmpresaId_SucursalId_Cartap~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Cartaporteid },
                        principalTable: "Cartaporte",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteAutotransp_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteAutotransp_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteAutotransp_Usuario_EmpresaId_SucursalId_CreadoPor~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteAutotransp_Usuario_EmpresaId_SucursalId_Modificad~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "CartaporteCanttransp",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cartaporteid = table.Column<long>(type: "bigint", nullable: true),
                    Cantidad = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Idorigen = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Iddestino = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Cvestransporte = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaporteCanttransp", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_CartaporteCanttransp_Cartaporte_EmpresaId_SucursalId_Cartap~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Cartaporteid },
                        principalTable: "Cartaporte",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteCanttransp_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteCanttransp_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteCanttransp_Usuario_EmpresaId_SucursalId_CreadoPor~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteCanttransp_Usuario_EmpresaId_SucursalId_Modificad~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "CartaporteMercancia",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cartaporteid = table.Column<long>(type: "bigint", nullable: true),
                    Bienestransp = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Clavestcc = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Cantidad = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Claveunidad = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Unidad = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Dimensiones = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Materialpeligroso = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Cvematerialpeligroso = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Embalaje = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Descripembalaje = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pesoenkg = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Valormercancia = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Moneda = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Fraccionarancelaria = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Uuidcomercioext = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Unidadpesomerc = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pesobruto = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pesoneto = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pesotara = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numpiezas = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaporteMercancia", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_CartaporteMercancia_Cartaporte_EmpresaId_SucursalId_Cartapo~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Cartaporteid },
                        principalTable: "Cartaporte",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteMercancia_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteMercancia_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteMercancia_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteMercancia_Usuario_EmpresaId_SucursalId_Modificado~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "CartaporteTotalmercancias",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cartaporteid = table.Column<long>(type: "bigint", nullable: true),
                    Pesobrutototal = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Unidadpeso = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pesonetototal = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numtotalmercancias = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Cargoportasacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaporteTotalmercancias", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_CartaporteTotalmercancias_Cartaporte_EmpresaId_SucursalId_C~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Cartaporteid },
                        principalTable: "Cartaporte",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteTotalmercancias_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteTotalmercancias_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteTotalmercancias_Usuario_EmpresaId_SucursalId_Crea~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteTotalmercancias_Usuario_EmpresaId_SucursalId_Modi~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "CartaporteTransptipofigura",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cartaporteid = table.Column<long>(type: "bigint", nullable: true),
                    Tipofigura = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Rfcfigura = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numlicencia = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Nombrefigura = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numregidtribfigura = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Residenciafiscalfigura = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Partetransporte = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Calle = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numeroexterior = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numerointerior = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Colonia = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Localidad = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Referencia = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Municipio = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Estado = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pais = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Codigopostal = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaporteTransptipofigura", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_CartaporteTransptipofigura_Cartaporte_EmpresaId_SucursalId_~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Cartaporteid },
                        principalTable: "Cartaporte",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteTransptipofigura_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteTransptipofigura_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteTransptipofigura_Usuario_EmpresaId_SucursalId_Cre~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteTransptipofigura_Usuario_EmpresaId_SucursalId_Mod~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "CartaporteUbicacion",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cartaporteid = table.Column<long>(type: "bigint", nullable: true),
                    Tipoubicacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Idubicacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Rfcremitentedestinatario = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Nombreremitentedestinatario = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numregidtrib = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Residenciafiscal = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numestacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Nombreestacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Navegaciontrafico = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Fechahorasalidallegada = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Tipoestacion = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Distanciarecorrida = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Calle = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numeroexterior = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Numerointerior = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Colonia = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Localidad = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Referencia = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Municipio = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Estado = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Pais = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Codigopostal = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaporteUbicacion", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_CartaporteUbicacion_Cartaporte_EmpresaId_SucursalId_Cartapo~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Cartaporteid },
                        principalTable: "Cartaporte",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteUbicacion_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteUbicacion_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaporteUbicacion_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_CartaporteUbicacion_Usuario_EmpresaId_SucursalId_Modificado~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "Personafigura",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Personaid = table.Column<long>(type: "bigint", nullable: true),
                    Sat_Figuratransporteid = table.Column<long>(type: "bigint", nullable: true),
                    Numlicencia = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Numregidtrib = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Residenciafiscal = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Sat_Partetransporteid = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personafigura", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_Personafigura_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personafigura_Sat_figuratransporte_Sat_Figuratransporteid",
                        column: x => x.Sat_Figuratransporteid,
                        principalTable: "Sat_figuratransporte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personafigura_Sat_partetransporte_Sat_Partetransporteid",
                        column: x => x.Sat_Partetransporteid,
                        principalTable: "Sat_partetransporte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personafigura_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personafigura_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Personafigura_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Personafigura_Usuario_EmpresaId_SucursalId_Personaid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Personaid },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sat_Tipopermisoid = table.Column<long>(type: "bigint", nullable: true),
                    Numpermisosct = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Sat_Configautotransporteid = table.Column<long>(type: "bigint", nullable: true),
                    Placavm = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Aniomodelovm = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Asegurarespcivil = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Polizarespcivil = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Aseguramedambiente = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Polizamedambiente = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Aseguracarga = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Polizacarga = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Primaseguro = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Sat_Subtiporem1id = table.Column<long>(type: "bigint", nullable: true),
                    Placa1 = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Sat_Subtiporem2id = table.Column<long>(type: "bigint", nullable: true),
                    Placa2 = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Duenioid = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => new { x.EmpresaId, x.SucursalId, x.Id });
                    table.ForeignKey(
                        name: "FK_Vehiculo_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Sat_configautotransporte_Sat_Configautotransporteid",
                        column: x => x.Sat_Configautotransporteid,
                        principalTable: "Sat_configautotransporte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculo_Sat_subtiporem_Sat_Subtiporem1id",
                        column: x => x.Sat_Subtiporem1id,
                        principalTable: "Sat_subtiporem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculo_Sat_tipopermiso_Sat_Tipopermisoid",
                        column: x => x.Sat_Tipopermisoid,
                        principalTable: "Sat_tipopermiso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculo_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Vehiculo_Usuario_EmpresaId_SucursalId_Duenioid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Duenioid },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Vehiculo_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartaporte_EmpresaId_SucursalId_CreadoPorId",
                table: "Cartaporte",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Cartaporte_EmpresaId_SucursalId_Doctoid",
                table: "Cartaporte",
                columns: new[] { "EmpresaId", "SucursalId", "Doctoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Cartaporte_EmpresaId_SucursalId_ModificadoPorId",
                table: "Cartaporte",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_CreadoPorId",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_ModificadoPorId",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteCanttransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_CreadoPorId",
                table: "CartaporteCanttransp",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_ModificadoPorId",
                table: "CartaporteCanttransp",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteMercancia_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteMercancia",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteMercancia_EmpresaId_SucursalId_CreadoPorId",
                table: "CartaporteMercancia",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteMercancia_EmpresaId_SucursalId_ModificadoPorId",
                table: "CartaporteMercancia",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteTotalmercancias",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_CreadoPorId",
                table: "CartaporteTotalmercancias",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_ModificadoPo~",
                table: "CartaporteTotalmercancias",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTransptipofigura_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteTransptipofigura",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTransptipofigura_EmpresaId_SucursalId_CreadoPorId",
                table: "CartaporteTransptipofigura",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTransptipofigura_EmpresaId_SucursalId_ModificadoP~",
                table: "CartaporteTransptipofigura",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteUbicacion_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteUbicacion",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteUbicacion_EmpresaId_SucursalId_CreadoPorId",
                table: "CartaporteUbicacion",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteUbicacion_EmpresaId_SucursalId_ModificadoPorId",
                table: "CartaporteUbicacion",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_CreadoPorId",
                table: "Personafigura",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_ModificadoPorId",
                table: "Personafigura",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_Personaid",
                table: "Personafigura",
                columns: new[] { "EmpresaId", "SucursalId", "Personaid" });

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_Sat_Figuratransporteid",
                table: "Personafigura",
                column: "Sat_Figuratransporteid");

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_Sat_Partetransporteid",
                table: "Personafigura",
                column: "Sat_Partetransporteid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_EmpresaId_SucursalId_CreadoPorId",
                table: "Vehiculo",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_EmpresaId_SucursalId_Duenioid",
                table: "Vehiculo",
                columns: new[] { "EmpresaId", "SucursalId", "Duenioid" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_EmpresaId_SucursalId_ModificadoPorId",
                table: "Vehiculo",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Sat_Configautotransporteid",
                table: "Vehiculo",
                column: "Sat_Configautotransporteid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Sat_Subtiporem1id",
                table: "Vehiculo",
                column: "Sat_Subtiporem1id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Sat_Tipopermisoid",
                table: "Vehiculo",
                column: "Sat_Tipopermisoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_Imp_Empresa_EmpresaId",
                table: "Pagodoctosat_Imp",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_Imp_Pagodoctosat_EmpresaId_SucursalId_Pagodoct~",
                table: "Pagodoctosat_Imp",
                columns: new[] { "EmpresaId", "SucursalId", "Pagodoctosatid" },
                principalTable: "Pagodoctosat",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_Imp_Sucursal_EmpresaId_SucursalId",
                table: "Pagodoctosat_Imp",
                columns: new[] { "EmpresaId", "SucursalId" },
                principalTable: "Sucursal",
                principalColumns: new[] { "EmpresaId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_Imp_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_Imp",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_Imp_Usuario_EmpresaId_SucursalId_ModificadoPor~",
                table: "Pagodoctosat_Imp",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_Imp_Empresa_EmpresaId",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_Imp_Pagodoctosat_EmpresaId_SucursalId_Pagodoct~",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_Imp_Sucursal_EmpresaId_SucursalId",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_Imp_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagodoctosat_Imp_Usuario_EmpresaId_SucursalId_ModificadoPor~",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropTable(
                name: "CartaporteAutotransp");

            migrationBuilder.DropTable(
                name: "CartaporteCanttransp");

            migrationBuilder.DropTable(
                name: "CartaporteMercancia");

            migrationBuilder.DropTable(
                name: "CartaporteTotalmercancias");

            migrationBuilder.DropTable(
                name: "CartaporteTransptipofigura");

            migrationBuilder.DropTable(
                name: "CartaporteUbicacion");

            migrationBuilder.DropTable(
                name: "Personafigura");

            migrationBuilder.DropTable(
                name: "Sat_clavetransporte");

            migrationBuilder.DropTable(
                name: "Sat_tipoestacion");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Cartaporte");

            migrationBuilder.DropTable(
                name: "Sat_figuratransporte");

            migrationBuilder.DropTable(
                name: "Sat_partetransporte");

            migrationBuilder.DropTable(
                name: "Sat_configautotransporte");

            migrationBuilder.DropTable(
                name: "Sat_subtiporem");

            migrationBuilder.DropTable(
                name: "Sat_tipopermiso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagodoctosat_Imp",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctonota",
                table: "Doctonota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctocomprobante",
                table: "Doctocomprobante");

            migrationBuilder.RenameTable(
                name: "Pagodoctosat_Imp",
                newName: "Pagodoctosat_imp");

            migrationBuilder.RenameIndex(
                name: "IX_Pagodoctosat_Imp_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Pagodoctosat_imp",
                newName: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_Pagodoctosatid");

            migrationBuilder.RenameIndex(
                name: "IX_Pagodoctosat_Imp_EmpresaId_SucursalId_ModificadoPorId",
                table: "Pagodoctosat_imp",
                newName: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_ModificadoPorId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagodoctosat_Imp_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_imp",
                newName: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_CreadoPorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagodoctosat_imp",
                table: "Pagodoctosat_imp",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctonota",
                table: "Doctonota",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctocomprobante",
                table: "Doctocomprobante",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_imp_Empresa_EmpresaId",
                table: "Pagodoctosat_imp",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_imp_Pagodoctosat_EmpresaId_SucursalId_Pagodoct~",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId", "Pagodoctosatid" },
                principalTable: "Pagodoctosat",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_imp_Sucursal_EmpresaId_SucursalId",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId" },
                principalTable: "Sucursal",
                principalColumns: new[] { "EmpresaId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_imp_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pagodoctosat_imp_Usuario_EmpresaId_SucursalId_ModificadoPor~",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }
    }
}
