using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IposV3.Migrations
{
    public partial class CambiosParaIgualar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombreimpresora",
                table: "Usuario_Preferencias",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Entrega_Distancia",
                table: "Sucursal_fact_elect",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Entrega_Sat_Coloniaid",
                table: "Sucursal_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Entrega_Sat_Localidadid",
                table: "Sucursal_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Entrega_Sat_Municipioid",
                table: "Sucursal_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entregareferenciadom",
                table: "Sucursal_fact_elect",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imnuprod",
                table: "Sucursal_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Promocion",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mostrardatoscliente",
                table: "Promocion",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Cantmayoreo",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cantmediomay",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Listaprecmayoreoid",
                table: "Producto_precios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Listaprecmediomayid",
                table: "Producto_precios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Espeligroso",
                table: "Producto_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Generacartaporte",
                table: "Producto_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Generacomprobtrasl",
                table: "Producto_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Peso",
                table: "Producto_fact_elect",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Claveunidadpesoid",
                table: "Producto_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Matpeligrosoid",
                table: "Producto_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Tipoembalajeid",
                table: "Producto_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objetoimpdr",
                table: "Pagodoctosat",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Refinterno",
                table: "Pago",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechaestimadarec",
                table: "Guia",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Horaestimadrec",
                table: "Guia",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acronimo",
                table: "Estadopais",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Refinterno",
                table: "Doctopago",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Tipodiferenciainventarioid",
                table: "Docto",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mayoreoxproducto",
                table: "Cliente_precio",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Distancia",
                table: "Cliente_fact_elect",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Entrega_Distancia",
                table: "Cliente_fact_elect",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Entrega_Sat_Coloniaid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Entrega_Sat_Localidadid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Entrega_Sat_Municipioid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entregareferenciadom",
                table: "Cliente_fact_elect",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Coloniaid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Localidadid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Municipioid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Regimenfiscalid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objetoimp",
                table: "Cfdi_conc",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exportacion",
                table: "Cfdi",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meses",
                table: "Cfdi",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Periodicidad",
                table: "Cfdi",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rc_Domiciliofiscal",
                table: "Cfdi",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rc_Regimenfiscal",
                table: "Cfdi",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctocomprobante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Doctoid = table.Column<long>(type: "bigint", nullable: true),
                    Tipocomprobante = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Timbradouuid = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Timbradofecha = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Timbradocertsat = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Timbradosellosat = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Timbradosellocfdi = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Foliosat = table.Column<int>(type: "integer", nullable: true),
                    Seriesat = table.Column<string>(type: "character varying(31)", maxLength: 31, nullable: true),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctocomprobante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctocomprobante_Docto_EmpresaId_SucursalId_Doctoid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Doctoid },
                        principalTable: "Docto",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Doctocomprobante_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctocomprobante_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctocomprobante_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Doctocomprobante_Usuario_EmpresaId_SucursalId_ModificadoPor~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "Pagodoctosat_imp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pagodoctosatid = table.Column<long>(type: "bigint", nullable: true),
                    Baseimp = table.Column<decimal>(type: "numeric(20,4)", nullable: true),
                    Tipofactor = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Tasacuota = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Tasa = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Impuesto = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Importe = table.Column<decimal>(type: "numeric(20,4)", nullable: true),
                    Tipoimpuesto = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagodoctosat_imp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagodoctosat_imp_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagodoctosat_imp_Pagodoctosat_EmpresaId_SucursalId_Pagodoct~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Pagodoctosatid },
                        principalTable: "Pagodoctosat",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Pagodoctosat_imp_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagodoctosat_imp_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Pagodoctosat_imp_Usuario_EmpresaId_SucursalId_ModificadoPor~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "Sat_claveunidadpeso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Simbolo = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Bandera = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Nota = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
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
                    table.PrimaryKey("PK_Sat_claveunidadpeso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_colonia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Colonia = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Codigopostal = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_colonia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_localidad",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Clave_localidad = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Clave_estado = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_localidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_matpeligroso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Clase = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Peligro_secundario = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Nombre_tecnico = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
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
                    table.PrimaryKey("PK_Sat_matpeligroso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_municipio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Clave_municipio = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Clave_estado = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat_municipio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat_tipoembalaje",
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
                    table.PrimaryKey("PK_Sat_tipoembalaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipodoctonota",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Clave = table.Column<string>(type: "character varying(31)", maxLength: 31, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipodoctonota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctonota",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Doctoid = table.Column<long>(type: "bigint", nullable: true),
                    Tipodoctonotaid = table.Column<long>(type: "bigint", nullable: true),
                    Fechahora = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Usuarioid = table.Column<long>(type: "bigint", nullable: true),
                    Nota = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    SucursalId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<string>(type: "char(1)", nullable: false),
                    Creado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modificado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreadoPorId = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoPorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctonota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctonota_Docto_EmpresaId_SucursalId_Doctoid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Doctoid },
                        principalTable: "Docto",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Doctonota_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctonota_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctonota_Tipodoctonota_Tipodoctonotaid",
                        column: x => x.Tipodoctonotaid,
                        principalTable: "Tipodoctonota",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctonota_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Doctonota_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Doctonota_Usuario_EmpresaId_SucursalId_Usuarioid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Usuarioid },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_fact_elect_Entrega_Sat_Coloniaid",
                table: "Sucursal_fact_elect",
                column: "Entrega_Sat_Coloniaid");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_fact_elect_Entrega_Sat_Localidadid",
                table: "Sucursal_fact_elect",
                column: "Entrega_Sat_Localidadid");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_fact_elect_Entrega_Sat_Municipioid",
                table: "Sucursal_fact_elect",
                column: "Entrega_Sat_Municipioid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmayoreoid",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmayoreoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmediomayid",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmediomayid" });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_fact_elect_Sat_Claveunidadpesoid",
                table: "Producto_fact_elect",
                column: "Sat_Claveunidadpesoid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_fact_elect_Sat_Matpeligrosoid",
                table: "Producto_fact_elect",
                column: "Sat_Matpeligrosoid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_fact_elect_Sat_Tipoembalajeid",
                table: "Producto_fact_elect",
                column: "Sat_Tipoembalajeid");

            migrationBuilder.CreateIndex(
                name: "IX_Docto_Tipodiferenciainventarioid",
                table: "Docto",
                column: "Tipodiferenciainventarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Entrega_Sat_Coloniaid",
                table: "Cliente_fact_elect",
                column: "Entrega_Sat_Coloniaid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Entrega_Sat_Localidadid",
                table: "Cliente_fact_elect",
                column: "Entrega_Sat_Localidadid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Entrega_Sat_Municipioid",
                table: "Cliente_fact_elect",
                column: "Entrega_Sat_Municipioid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Sat_Coloniaid",
                table: "Cliente_fact_elect",
                column: "Sat_Coloniaid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Sat_Localidadid",
                table: "Cliente_fact_elect",
                column: "Sat_Localidadid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Sat_Municipioid",
                table: "Cliente_fact_elect",
                column: "Sat_Municipioid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect",
                column: "Sat_Regimenfiscaloid");

            migrationBuilder.CreateIndex(
                name: "IX_Doctocomprobante_EmpresaId_SucursalId_CreadoPorId",
                table: "Doctocomprobante",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctocomprobante_EmpresaId_SucursalId_Doctoid",
                table: "Doctocomprobante",
                columns: new[] { "EmpresaId", "SucursalId", "Doctoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctocomprobante_EmpresaId_SucursalId_ModificadoPorId",
                table: "Doctocomprobante",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctonota_EmpresaId_SucursalId_CreadoPorId",
                table: "Doctonota",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctonota_EmpresaId_SucursalId_Doctoid",
                table: "Doctonota",
                columns: new[] { "EmpresaId", "SucursalId", "Doctoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctonota_EmpresaId_SucursalId_ModificadoPorId",
                table: "Doctonota",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctonota_EmpresaId_SucursalId_Usuarioid",
                table: "Doctonota",
                columns: new[] { "EmpresaId", "SucursalId", "Usuarioid" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctonota_Tipodoctonotaid",
                table: "Doctonota",
                column: "Tipodoctonotaid");

            migrationBuilder.CreateIndex(
                name: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_CreadoPorId",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_ModificadoPorId",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pagodoctosat_imp_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Pagodoctosat_imp",
                columns: new[] { "EmpresaId", "SucursalId", "Pagodoctosatid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_colonia_Entrega_Sat_Coloniaid",
                table: "Cliente_fact_elect",
                column: "Entrega_Sat_Coloniaid",
                principalTable: "Sat_colonia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_colonia_Sat_Coloniaid",
                table: "Cliente_fact_elect",
                column: "Sat_Coloniaid",
                principalTable: "Sat_colonia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_localidad_Entrega_Sat_Localidadid",
                table: "Cliente_fact_elect",
                column: "Entrega_Sat_Localidadid",
                principalTable: "Sat_localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_localidad_Sat_Localidadid",
                table: "Cliente_fact_elect",
                column: "Sat_Localidadid",
                principalTable: "Sat_localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_municipio_Entrega_Sat_Municipioid",
                table: "Cliente_fact_elect",
                column: "Entrega_Sat_Municipioid",
                principalTable: "Sat_municipio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_municipio_Sat_Municipioid",
                table: "Cliente_fact_elect",
                column: "Sat_Municipioid",
                principalTable: "Sat_municipio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_regimenfiscal_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect",
                column: "Sat_Regimenfiscaloid",
                principalTable: "Sat_regimenfiscal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Docto_Tipodiferenciainventario_Tipodiferenciainventarioid",
                table: "Docto",
                column: "Tipodiferenciainventarioid",
                principalTable: "Tipodiferenciainventario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_fact_elect_Sat_claveunidadpeso_Sat_Claveunidadpeso~",
                table: "Producto_fact_elect",
                column: "Sat_Claveunidadpesoid",
                principalTable: "Sat_claveunidadpeso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_fact_elect_Sat_matpeligroso_Sat_Matpeligrosoid",
                table: "Producto_fact_elect",
                column: "Sat_Matpeligrosoid",
                principalTable: "Sat_matpeligroso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_fact_elect_Sat_tipoembalaje_Sat_Tipoembalajeid",
                table: "Producto_fact_elect",
                column: "Sat_Tipoembalajeid",
                principalTable: "Sat_tipoembalaje",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listapre~1",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmediomayid" },
                principalTable: "Listaprecio",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listaprec~",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmayoreoid" },
                principalTable: "Listaprecio",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_fact_elect_Sat_colonia_Entrega_Sat_Coloniaid",
                table: "Sucursal_fact_elect",
                column: "Entrega_Sat_Coloniaid",
                principalTable: "Sat_colonia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_fact_elect_Sat_localidad_Entrega_Sat_Localidadid",
                table: "Sucursal_fact_elect",
                column: "Entrega_Sat_Localidadid",
                principalTable: "Sat_localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_fact_elect_Sat_municipio_Entrega_Sat_Municipioid",
                table: "Sucursal_fact_elect",
                column: "Entrega_Sat_Municipioid",
                principalTable: "Sat_municipio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_colonia_Entrega_Sat_Coloniaid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_colonia_Sat_Coloniaid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_localidad_Entrega_Sat_Localidadid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_localidad_Sat_Localidadid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_municipio_Entrega_Sat_Municipioid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_municipio_Sat_Municipioid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_regimenfiscal_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Docto_Tipodiferenciainventario_Tipodiferenciainventarioid",
                table: "Docto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_fact_elect_Sat_claveunidadpeso_Sat_Claveunidadpeso~",
                table: "Producto_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_fact_elect_Sat_matpeligroso_Sat_Matpeligrosoid",
                table: "Producto_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_fact_elect_Sat_tipoembalaje_Sat_Tipoembalajeid",
                table: "Producto_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listapre~1",
                table: "Producto_precios");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listaprec~",
                table: "Producto_precios");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_fact_elect_Sat_colonia_Entrega_Sat_Coloniaid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_fact_elect_Sat_localidad_Entrega_Sat_Localidadid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_fact_elect_Sat_municipio_Entrega_Sat_Municipioid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropTable(
                name: "Doctocomprobante");

            migrationBuilder.DropTable(
                name: "Doctonota");

            migrationBuilder.DropTable(
                name: "Pagodoctosat_imp");

            migrationBuilder.DropTable(
                name: "Sat_claveunidadpeso");

            migrationBuilder.DropTable(
                name: "Sat_colonia");

            migrationBuilder.DropTable(
                name: "Sat_localidad");

            migrationBuilder.DropTable(
                name: "Sat_matpeligroso");

            migrationBuilder.DropTable(
                name: "Sat_municipio");

            migrationBuilder.DropTable(
                name: "Sat_tipoembalaje");

            migrationBuilder.DropTable(
                name: "Tipodoctonota");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_fact_elect_Entrega_Sat_Coloniaid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_fact_elect_Entrega_Sat_Localidadid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_fact_elect_Entrega_Sat_Municipioid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmayoreoid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmediomayid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_fact_elect_Sat_Claveunidadpesoid",
                table: "Producto_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Producto_fact_elect_Sat_Matpeligrosoid",
                table: "Producto_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Producto_fact_elect_Sat_Tipoembalajeid",
                table: "Producto_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Docto_Tipodiferenciainventarioid",
                table: "Docto");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Entrega_Sat_Coloniaid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Entrega_Sat_Localidadid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Entrega_Sat_Municipioid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Sat_Coloniaid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Sat_Localidadid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Sat_Municipioid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Nombreimpresora",
                table: "Usuario_Preferencias");

            migrationBuilder.DropColumn(
                name: "Entrega_Distancia",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Sat_Coloniaid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Sat_Localidadid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Sat_Municipioid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entregareferenciadom",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Imnuprod",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Promocion");

            migrationBuilder.DropColumn(
                name: "Mostrardatoscliente",
                table: "Promocion");

            migrationBuilder.DropColumn(
                name: "Cantmayoreo",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Cantmediomay",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Listaprecmayoreoid",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Listaprecmediomayid",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Espeligroso",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Generacartaporte",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Generacomprobtrasl",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Claveunidadpesoid",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Matpeligrosoid",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Tipoembalajeid",
                table: "Producto_fact_elect");

            migrationBuilder.DropColumn(
                name: "Objetoimpdr",
                table: "Pagodoctosat");

            migrationBuilder.DropColumn(
                name: "Refinterno",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "Fechaestimadarec",
                table: "Guia");

            migrationBuilder.DropColumn(
                name: "Horaestimadrec",
                table: "Guia");

            migrationBuilder.DropColumn(
                name: "Acronimo",
                table: "Estadopais");

            migrationBuilder.DropColumn(
                name: "Refinterno",
                table: "Doctopago");

            migrationBuilder.DropColumn(
                name: "Tipodiferenciainventarioid",
                table: "Docto");

            migrationBuilder.DropColumn(
                name: "Mayoreoxproducto",
                table: "Cliente_precio");

            migrationBuilder.DropColumn(
                name: "Distancia",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Distancia",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Sat_Coloniaid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Sat_Localidadid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entrega_Sat_Municipioid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Entregareferenciadom",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Coloniaid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Localidadid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Municipioid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Regimenfiscalid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Objetoimp",
                table: "Cfdi_conc");

            migrationBuilder.DropColumn(
                name: "Exportacion",
                table: "Cfdi");

            migrationBuilder.DropColumn(
                name: "Meses",
                table: "Cfdi");

            migrationBuilder.DropColumn(
                name: "Periodicidad",
                table: "Cfdi");

            migrationBuilder.DropColumn(
                name: "Rc_Domiciliofiscal",
                table: "Cfdi");

            migrationBuilder.DropColumn(
                name: "Rc_Regimenfiscal",
                table: "Cfdi");
        }
    }
}
