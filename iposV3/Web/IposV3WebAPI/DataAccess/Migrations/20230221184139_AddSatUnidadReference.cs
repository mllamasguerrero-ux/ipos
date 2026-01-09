using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class AddSatUnidadReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Sat_unidadmedidaid",
                table: "Unidad",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unidad_Sat_unidadmedidaid",
                table: "Unidad",
                column: "Sat_unidadmedidaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidad_Sat_unidadmedida_Sat_unidadmedidaid",
                table: "Unidad",
                column: "Sat_unidadmedidaid",
                principalTable: "Sat_unidadmedida",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidad_Sat_unidadmedida_Sat_unidadmedidaid",
                table: "Unidad");

            migrationBuilder.DropIndex(
                name: "IX_Unidad_Sat_unidadmedidaid",
                table: "Unidad");

            migrationBuilder.DropColumn(
                name: "Sat_unidadmedidaid",
                table: "Unidad");
        }
    }
}
