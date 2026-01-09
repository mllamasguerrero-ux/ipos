using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class ListaPrecioDetalle_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listapreciodetalle_Tipoprecio_Listaprecioid",
                table: "Listapreciodetalle");

            migrationBuilder.DropIndex(
                name: "IX_Listapreciodetalle_Listaprecioid",
                table: "Listapreciodetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Listapreciodetalle_EmpresaId_SucursalId_Listaprecioid",
                table: "Listapreciodetalle",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecioid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Listapreciodetalle_Listaprecio_EmpresaId_SucursalId_Listapr~",
                table: "Listapreciodetalle",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecioid" },
                principalTable: "Listaprecio",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listapreciodetalle_Listaprecio_EmpresaId_SucursalId_Listapr~",
                table: "Listapreciodetalle");

            migrationBuilder.DropIndex(
                name: "IX_Listapreciodetalle_EmpresaId_SucursalId_Listaprecioid",
                table: "Listapreciodetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Listapreciodetalle_Listaprecioid",
                table: "Listapreciodetalle",
                column: "Listaprecioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Listapreciodetalle_Tipoprecio_Listaprecioid",
                table: "Listapreciodetalle",
                column: "Listaprecioid",
                principalTable: "Tipoprecio",
                principalColumn: "Id");
        }
    }
}
