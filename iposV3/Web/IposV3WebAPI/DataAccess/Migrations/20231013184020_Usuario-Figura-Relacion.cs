using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class UsuarioFiguraRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_Personaid",
                table: "Personafigura");

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_Personaid",
                table: "Personafigura",
                columns: new[] { "EmpresaId", "SucursalId", "Personaid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_Personaid",
                table: "Personafigura");

            migrationBuilder.CreateIndex(
                name: "IX_Personafigura_EmpresaId_SucursalId_Personaid",
                table: "Personafigura",
                columns: new[] { "EmpresaId", "SucursalId", "Personaid" });
        }
    }
}
