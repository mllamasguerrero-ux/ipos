using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IposV3.Migrations
{
    public partial class cartaportechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario_fact_elect",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuarioid = table.Column<long>(type: "bigint", nullable: true),
                    Sat_id_pais = table.Column<long>(type: "bigint", nullable: true),
                    Sat_Coloniaid = table.Column<long>(type: "bigint", nullable: true),
                    Sat_Localidadid = table.Column<long>(type: "bigint", nullable: true),
                    Sat_Municipioid = table.Column<long>(type: "bigint", nullable: true),
                    Estadoid = table.Column<long>(type: "bigint", nullable: true),
                    Referenciadom = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Usuario_fact_elect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Estadopais_Estadoid",
                        column: x => x.Estadoid,
                        principalTable: "Estadopais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Sat_colonia_Sat_Coloniaid",
                        column: x => x.Sat_Coloniaid,
                        principalTable: "Sat_colonia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Sat_localidad_Sat_Localidadid",
                        column: x => x.Sat_Localidadid,
                        principalTable: "Sat_localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Sat_municipio_Sat_Municipioid",
                        column: x => x.Sat_Municipioid,
                        principalTable: "Sat_municipio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Sat_pais_Sat_id_pais",
                        column: x => x.Sat_id_pais,
                        principalTable: "Sat_pais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Sucursal_EmpresaId_SucursalId",
                        columns: x => new { x.EmpresaId, x.SucursalId },
                        principalTable: "Sucursal",
                        principalColumns: new[] { "EmpresaId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Usuario_EmpresaId_SucursalId_CreadoPorId",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.CreadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Usuario_EmpresaId_SucursalId_ModificadoP~",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.ModificadoPorId },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                    table.ForeignKey(
                        name: "FK_Usuario_fact_elect_Usuario_EmpresaId_SucursalId_Usuarioid",
                        columns: x => new { x.EmpresaId, x.SucursalId, x.Usuarioid },
                        principalTable: "Usuario",
                        principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_EmpresaId_SucursalId_CreadoPorId",
                table: "Usuario_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_EmpresaId_SucursalId_ModificadoPorId",
                table: "Usuario_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_EmpresaId_SucursalId_Usuarioid",
                table: "Usuario_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "Usuarioid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_Estadoid",
                table: "Usuario_fact_elect",
                column: "Estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_Sat_Coloniaid",
                table: "Usuario_fact_elect",
                column: "Sat_Coloniaid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_Sat_id_pais",
                table: "Usuario_fact_elect",
                column: "Sat_id_pais");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_Sat_Localidadid",
                table: "Usuario_fact_elect",
                column: "Sat_Localidadid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fact_elect_Sat_Municipioid",
                table: "Usuario_fact_elect",
                column: "Sat_Municipioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario_fact_elect");
        }
    }
}
