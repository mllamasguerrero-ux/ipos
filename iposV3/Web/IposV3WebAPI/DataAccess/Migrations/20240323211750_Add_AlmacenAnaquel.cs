using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Add_AlmacenAnaquel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Almacenid",
                table: "Anaquel",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anaquel_EmpresaId_SucursalId_Almacenid",
                table: "Anaquel",
                columns: new[] { "EmpresaId", "SucursalId", "Almacenid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Anaquel_Almacen_EmpresaId_SucursalId_Almacenid",
                table: "Anaquel",
                columns: new[] { "EmpresaId", "SucursalId", "Almacenid" },
                principalTable: "Almacen",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anaquel_Almacen_EmpresaId_SucursalId_Almacenid",
                table: "Anaquel");

            migrationBuilder.DropIndex(
                name: "IX_Anaquel_EmpresaId_SucursalId_Almacenid",
                table: "Anaquel");

            migrationBuilder.DropColumn(
                name: "Almacenid",
                table: "Anaquel");
        }
    }
}
