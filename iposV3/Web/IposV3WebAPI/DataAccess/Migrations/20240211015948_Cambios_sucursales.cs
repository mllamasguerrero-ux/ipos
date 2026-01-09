using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Cambios_sucursales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imnuprod",
                table: "Sucursal_fact_elect");

            migrationBuilder.AddColumn<string>(
                name: "Imnuprod",
                table: "Sucursal_importacion",
                type: "char(1)",
                nullable: false,
                defaultValue: "S");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imnuprod",
                table: "Sucursal_importacion");

            migrationBuilder.AddColumn<string>(
                name: "Imnuprod",
                table: "Sucursal_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
