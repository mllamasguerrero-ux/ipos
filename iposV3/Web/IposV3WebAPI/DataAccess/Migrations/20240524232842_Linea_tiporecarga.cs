using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Linea_tiporecarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tiporecarga",
                table: "Linea",
                type: "character varying(31)",
                maxLength: 31,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tiporecarga",
                table: "Linea");
        }
    }
}
