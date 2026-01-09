using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Proveedormatchversionactual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Listaprecioid",
                table: "Proveedor",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Saludoid",
                table: "Proveedor",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Vendedorid",
                table: "Proveedor",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_EmpresaId_SucursalId_Vendedorid",
                table: "Proveedor",
                columns: new[] { "EmpresaId", "SucursalId", "Vendedorid" });

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Listaprecioid",
                table: "Proveedor",
                column: "Listaprecioid");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Saludoid",
                table: "Proveedor",
                column: "Saludoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Saludo_Saludoid",
                table: "Proveedor",
                column: "Saludoid",
                principalTable: "Saludo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Tipoprecio_Listaprecioid",
                table: "Proveedor",
                column: "Listaprecioid",
                principalTable: "Tipoprecio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Usuario_EmpresaId_SucursalId_Vendedorid",
                table: "Proveedor",
                columns: new[] { "EmpresaId", "SucursalId", "Vendedorid" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Saludo_Saludoid",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Tipoprecio_Listaprecioid",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Usuario_EmpresaId_SucursalId_Vendedorid",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_EmpresaId_SucursalId_Vendedorid",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_Listaprecioid",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_Saludoid",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Listaprecioid",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Saludoid",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Vendedorid",
                table: "Proveedor");
        }
    }
}
