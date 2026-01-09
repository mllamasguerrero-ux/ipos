using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Match_version_actual_feb2024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Ultimavistacompra",
                table: "Usuario_Preferencias",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Almacenid",
                table: "Plazo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Promocionmultidetalleid",
                table: "Movto_promocion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Tipomayoreolineaid",
                table: "Movto_promocion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Anio",
                table: "Cfdi",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plazo_EmpresaId_SucursalId_Almacenid",
                table: "Plazo",
                columns: new[] { "EmpresaId", "SucursalId", "Almacenid" });

            migrationBuilder.CreateIndex(
                name: "IX_Movto_promocion_EmpresaId_SucursalId_Promocionmultidetalleid",
                table: "Movto_promocion",
                columns: new[] { "EmpresaId", "SucursalId", "Promocionmultidetalleid" });

            migrationBuilder.CreateIndex(
                name: "IX_Movto_promocion_Tipomayoreolineaid",
                table: "Movto_promocion",
                column: "Tipomayoreolineaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movto_promocion_Promocion_EmpresaId_SucursalId_Promocionmul~",
                table: "Movto_promocion",
                columns: new[] { "EmpresaId", "SucursalId", "Promocionmultidetalleid" },
                principalTable: "Promocion",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movto_promocion_Tipomayoreo_Tipomayoreolineaid",
                table: "Movto_promocion",
                column: "Tipomayoreolineaid",
                principalTable: "Tipomayoreo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plazo_Almacen_EmpresaId_SucursalId_Almacenid",
                table: "Plazo",
                columns: new[] { "EmpresaId", "SucursalId", "Almacenid" },
                principalTable: "Almacen",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movto_promocion_Promocion_EmpresaId_SucursalId_Promocionmul~",
                table: "Movto_promocion");

            migrationBuilder.DropForeignKey(
                name: "FK_Movto_promocion_Tipomayoreo_Tipomayoreolineaid",
                table: "Movto_promocion");

            migrationBuilder.DropForeignKey(
                name: "FK_Plazo_Almacen_EmpresaId_SucursalId_Almacenid",
                table: "Plazo");

            migrationBuilder.DropIndex(
                name: "IX_Plazo_EmpresaId_SucursalId_Almacenid",
                table: "Plazo");

            migrationBuilder.DropIndex(
                name: "IX_Movto_promocion_EmpresaId_SucursalId_Promocionmultidetalleid",
                table: "Movto_promocion");

            migrationBuilder.DropIndex(
                name: "IX_Movto_promocion_Tipomayoreolineaid",
                table: "Movto_promocion");

            migrationBuilder.DropColumn(
                name: "Ultimavistacompra",
                table: "Usuario_Preferencias");

            migrationBuilder.DropColumn(
                name: "Almacenid",
                table: "Plazo");

            migrationBuilder.DropColumn(
                name: "Promocionmultidetalleid",
                table: "Movto_promocion");

            migrationBuilder.DropColumn(
                name: "Tipomayoreolineaid",
                table: "Movto_promocion");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Cfdi");
        }
    }
}
