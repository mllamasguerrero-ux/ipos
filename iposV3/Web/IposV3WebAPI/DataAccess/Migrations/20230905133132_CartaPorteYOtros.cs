using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class CartaPorteYOtros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteTotalmercancias");

            migrationBuilder.DropIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteCanttransp");

            migrationBuilder.DropIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteAutotransp");

            migrationBuilder.AddColumn<string>(
                name: "Iddocumento",
                table: "Pagodoctosat_Imp",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fecha_fin",
                table: "Docto_fact_elect_consolidacion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fecha_ini",
                table: "Docto_fact_elect_consolidacion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteTotalmercancias",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteCanttransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteTotalmercancias");

            migrationBuilder.DropIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteCanttransp");

            migrationBuilder.DropIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteAutotransp");

            migrationBuilder.DropColumn(
                name: "Iddocumento",
                table: "Pagodoctosat_Imp");

            migrationBuilder.DropColumn(
                name: "Fecha_fin",
                table: "Docto_fact_elect_consolidacion");

            migrationBuilder.DropColumn(
                name: "Fecha_ini",
                table: "Docto_fact_elect_consolidacion");

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteTotalmercancias_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteTotalmercancias",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteCanttransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteCanttransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaporteAutotransp_EmpresaId_SucursalId_Cartaporteid",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });
        }
    }
}
