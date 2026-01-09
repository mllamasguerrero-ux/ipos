using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class ParametrosAnadidos2023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autpreciolistabajo",
                table: "Parametro",
                type: "char(1)",
                nullable: false,
                defaultValue: "N");

            migrationBuilder.AddColumn<long>(
                name: "Listapreciomaylinea",
                table: "Parametro",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Listaprecmedmaylinea",
                table: "Parametro",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rutafirmaimagenes",
                table: "Parametro",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_Listapreciomaylinea",
                table: "Parametro",
                column: "Listapreciomaylinea");

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_Listaprecmedmaylinea",
                table: "Parametro",
                column: "Listaprecmedmaylinea");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Tipoprecio_Listapreciomaylinea",
                table: "Parametro",
                column: "Listapreciomaylinea",
                principalTable: "Tipoprecio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Tipoprecio_Listaprecmedmaylinea",
                table: "Parametro",
                column: "Listaprecmedmaylinea",
                principalTable: "Tipoprecio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Tipoprecio_Listapreciomaylinea",
                table: "Parametro");

            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Tipoprecio_Listaprecmedmaylinea",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_Listapreciomaylinea",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_Listaprecmedmaylinea",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Autpreciolistabajo",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Listapreciomaylinea",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Listaprecmedmaylinea",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Rutafirmaimagenes",
                table: "Parametro");
        }
    }
}
