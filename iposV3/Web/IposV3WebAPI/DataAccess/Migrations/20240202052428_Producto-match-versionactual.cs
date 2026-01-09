using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Productomatchversionactual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cambiarprecio",
                table: "Producto_precios",
                type: "char(1)",
                nullable: false,
                defaultValue: "N");

            migrationBuilder.AddColumn<decimal>(
                name: "Costoendolar",
                table: "Producto_precios",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Descpes",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Desctope",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Descuento",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fechacambioprecio",
                table: "Producto_precios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Margen",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Menudeo",
                table: "Producto_precios",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Monedaid",
                table: "Producto_precios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Oferta",
                table: "Producto_precios",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Preciomat",
                table: "Producto_precios",
                type: "char(1)",
                nullable: false,
                defaultValue: "N");

            migrationBuilder.AddColumn<decimal>(
                name: "Preciomaximopublico",
                table: "Producto_precios",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Preciosugerido",
                table: "Producto_precios",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Preciotope",
                table: "Producto_precios",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Cuentapredial",
                table: "Producto_poliza",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Contenidovalor",
                table: "Producto_miscelanea",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Imprimir",
                table: "Producto_miscelanea",
                type: "char(1)",
                nullable: false,
                defaultValue: "S");

            migrationBuilder.AddColumn<string>(
                name: "Imprimircomanda",
                table: "Producto_miscelanea",
                type: "char(1)",
                nullable: false,
                defaultValue: "N");

            migrationBuilder.AddColumn<string>(
                name: "Valxsuc",
                table: "Producto_kit",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cantxpieza",
                table: "Producto_inventario",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "U_empaque",
                table: "Producto_inventario",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Producto",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Impuesto",
                table: "Producto",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Substitutoid",
                table: "Producto",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_Monedaid",
                table: "Producto_precios",
                column: "Monedaid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_EmpresaId_SucursalId_Substitutoid",
                table: "Producto",
                columns: new[] { "EmpresaId", "SucursalId", "Substitutoid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Producto_EmpresaId_SucursalId_Substitutoid",
                table: "Producto",
                columns: new[] { "EmpresaId", "SucursalId", "Substitutoid" },
                principalTable: "Producto",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Moneda_Monedaid",
                table: "Producto_precios",
                column: "Monedaid",
                principalTable: "Moneda",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Producto_EmpresaId_SucursalId_Substitutoid",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Moneda_Monedaid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_Monedaid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_EmpresaId_SucursalId_Substitutoid",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Cambiarprecio",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Costoendolar",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Descpes",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Desctope",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Fechacambioprecio",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Margen",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Menudeo",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Monedaid",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Oferta",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Preciomat",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Preciomaximopublico",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Preciosugerido",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Preciotope",
                table: "Producto_precios");

            migrationBuilder.DropColumn(
                name: "Cuentapredial",
                table: "Producto_poliza");

            migrationBuilder.DropColumn(
                name: "Contenidovalor",
                table: "Producto_miscelanea");

            migrationBuilder.DropColumn(
                name: "Imprimir",
                table: "Producto_miscelanea");

            migrationBuilder.DropColumn(
                name: "Imprimircomanda",
                table: "Producto_miscelanea");

            migrationBuilder.DropColumn(
                name: "Valxsuc",
                table: "Producto_kit");

            migrationBuilder.DropColumn(
                name: "Cantxpieza",
                table: "Producto_inventario");

            migrationBuilder.DropColumn(
                name: "U_empaque",
                table: "Producto_inventario");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Impuesto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Substitutoid",
                table: "Producto");
        }
    }
}
