using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class PromocionYUsuariomatchversionactual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_emida_EmpresaId_SucursalId_Usuarioid",
                table: "Usuario_emida");

            migrationBuilder.AddColumn<string>(
                name: "Descmultidetalle",
                table: "Promocion",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Esmultidetalle",
                table: "Promocion",
                type: "char(1)",
                nullable: false,
                defaultValue: "N");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_emida_EmpresaId_SucursalId_Usuarioid",
                table: "Usuario_emida",
                columns: new[] { "EmpresaId", "SucursalId", "Usuarioid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_emida_EmpresaId_SucursalId_Usuarioid",
                table: "Usuario_emida");

            migrationBuilder.DropColumn(
                name: "Descmultidetalle",
                table: "Promocion");

            migrationBuilder.DropColumn(
                name: "Esmultidetalle",
                table: "Promocion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_emida_EmpresaId_SucursalId_Usuarioid",
                table: "Usuario_emida",
                columns: new[] { "EmpresaId", "SucursalId", "Usuarioid" });
        }
    }
}
