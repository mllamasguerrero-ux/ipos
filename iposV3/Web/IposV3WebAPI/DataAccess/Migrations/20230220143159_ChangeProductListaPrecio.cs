using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class ChangeProductListaPrecio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listapre~1",
                table: "Producto_precios");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listaprec~",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmayoreoid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmediomayid",
                table: "Producto_precios");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_Listaprecmayoreoid",
                table: "Producto_precios",
                column: "Listaprecmayoreoid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_Listaprecmediomayid",
                table: "Producto_precios",
                column: "Listaprecmediomayid");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Camporeferenciaprecio_Listaprecmayoreoid",
                table: "Producto_precios",
                column: "Listaprecmayoreoid",
                principalTable: "Camporeferenciaprecio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Camporeferenciaprecio_Listaprecmediomayid",
                table: "Producto_precios",
                column: "Listaprecmediomayid",
                principalTable: "Camporeferenciaprecio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Camporeferenciaprecio_Listaprecmayoreoid",
                table: "Producto_precios");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_precios_Camporeferenciaprecio_Listaprecmediomayid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_Listaprecmayoreoid",
                table: "Producto_precios");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precios_Listaprecmediomayid",
                table: "Producto_precios");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmayoreoid",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmayoreoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precios_EmpresaId_SucursalId_Listaprecmediomayid",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmediomayid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listapre~1",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmediomayid" },
                principalTable: "Listaprecio",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_precios_Listaprecio_EmpresaId_SucursalId_Listaprec~",
                table: "Producto_precios",
                columns: new[] { "EmpresaId", "SucursalId", "Listaprecmayoreoid" },
                principalTable: "Listaprecio",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }
    }
}
