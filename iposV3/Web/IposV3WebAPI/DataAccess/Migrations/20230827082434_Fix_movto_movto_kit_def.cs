using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Fix_movto_movto_kit_def : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movto_kit_def_EmpresaId_SucursalId_Movtoid",
                table: "Movto_kit_def");

            //migrationBuilder.CreateTable(
            //    name: "SimpleLong",
            //    columns: table => new
            //    {
            //        Val = table.Column<long>(type: "bigint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Movto_kit_def_EmpresaId_SucursalId_Movtoid",
                table: "Movto_kit_def",
                columns: new[] { "EmpresaId", "SucursalId", "Movtoid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SimpleLong");

            migrationBuilder.DropIndex(
                name: "IX_Movto_kit_def_EmpresaId_SucursalId_Movtoid",
                table: "Movto_kit_def");

            migrationBuilder.CreateIndex(
                name: "IX_Movto_kit_def_EmpresaId_SucursalId_Movtoid",
                table: "Movto_kit_def",
                columns: new[] { "EmpresaId", "SucursalId", "Movtoid" },
                unique: true);
        }
    }
}
