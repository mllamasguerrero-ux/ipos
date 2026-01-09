using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class FactElectronicaChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Parametro",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigopostal",
                table: "Parametro",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Parametro",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Parametro",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Parametro",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Parametro",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desglosaieps",
                table: "Cliente_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "S");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Codigopostal",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Desglosaieps",
                table: "Cliente_fact_elect");
        }
    }
}
