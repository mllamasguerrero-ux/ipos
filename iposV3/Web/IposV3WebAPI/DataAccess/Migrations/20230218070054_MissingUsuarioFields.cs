using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class MissingUsuarioFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreadoPorId",
                table: "Usuario",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModificadoPorId",
                table: "Usuario",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Usuario",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                table: "Usuario",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Usuario",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                table: "Usuario",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Usuario");
        }
    }
}
