using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Vehiculosubtiporemolque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Sat_Subtiporem2id",
                table: "Vehiculo",
                column: "Sat_Subtiporem2id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Sat_subtiporem_Sat_Subtiporem2id",
                table: "Vehiculo",
                column: "Sat_Subtiporem2id",
                principalTable: "Sat_subtiporem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Sat_subtiporem_Sat_Subtiporem2id",
                table: "Vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculo_Sat_Subtiporem2id",
                table: "Vehiculo");
        }
    }
}
