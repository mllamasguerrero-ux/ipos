using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class MissingClientFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Cliente",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Cliente",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Razonsocial",
                table: "Cliente",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rfc",
                table: "Cliente",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Razonsocial",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Rfc",
                table: "Cliente");
        }
    }
}
