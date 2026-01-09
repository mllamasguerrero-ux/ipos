using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Clientematchversionactual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Domicilio",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dias_extr",
                table: "Cliente_pago_parametros",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Generacartaporte",
                table: "Cliente_fact_elect",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Generacomprobtrasl",
                table: "Cliente_fact_elect",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Por_come",
                table: "Cliente_comision",
                type: "numeric(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Servicioadomicilio",
                table: "Cliente_comision",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email3",
                table: "Cliente",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email4",
                table: "Cliente",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firma",
                table: "Cliente",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Vigencia",
                table: "Cliente",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "Dias_extr",
                table: "Cliente_pago_parametros");

            migrationBuilder.DropColumn(
                name: "Generacartaporte",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Generacomprobtrasl",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Por_come",
                table: "Cliente_comision");

            migrationBuilder.DropColumn(
                name: "Servicioadomicilio",
                table: "Cliente_comision");

            migrationBuilder.DropColumn(
                name: "Email3",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Email4",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Firma",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Vigencia",
                table: "Cliente");
        }
    }
}
