using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class CambiosParaIgualar_C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaporteAutotransp_Cartaporte_EmpresaId_SucursalId_Cartap~",
                table: "CartaporteAutotransp");

            migrationBuilder.AddColumn<long>(
                name: "Cartaporteid",
                table: "Guiadetalle",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Vehiculoid",
                table: "Guia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Cartaporteid",
                table: "CartaporteAutotransp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Guiadetalle_EmpresaId_SucursalId_Cartaporteid",
                table: "Guiadetalle",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" });

            migrationBuilder.CreateIndex(
                name: "IX_Guia_EmpresaId_SucursalId_Vehiculoid",
                table: "Guia",
                columns: new[] { "EmpresaId", "SucursalId", "Vehiculoid" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartaporteAutotransp_Cartaporte_EmpresaId_SucursalId_Cartap~",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" },
                principalTable: "Cartaporte",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Guia_Vehiculo_EmpresaId_SucursalId_Vehiculoid",
                table: "Guia",
                columns: new[] { "EmpresaId", "SucursalId", "Vehiculoid" },
                principalTable: "Vehiculo",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Guiadetalle_Cartaporte_EmpresaId_SucursalId_Cartaporteid",
                table: "Guiadetalle",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" },
                principalTable: "Cartaporte",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaporteAutotransp_Cartaporte_EmpresaId_SucursalId_Cartap~",
                table: "CartaporteAutotransp");

            migrationBuilder.DropForeignKey(
                name: "FK_Guia_Vehiculo_EmpresaId_SucursalId_Vehiculoid",
                table: "Guia");

            migrationBuilder.DropForeignKey(
                name: "FK_Guiadetalle_Cartaporte_EmpresaId_SucursalId_Cartaporteid",
                table: "Guiadetalle");

            migrationBuilder.DropIndex(
                name: "IX_Guiadetalle_EmpresaId_SucursalId_Cartaporteid",
                table: "Guiadetalle");

            migrationBuilder.DropIndex(
                name: "IX_Guia_EmpresaId_SucursalId_Vehiculoid",
                table: "Guia");

            migrationBuilder.DropColumn(
                name: "Cartaporteid",
                table: "Guiadetalle");

            migrationBuilder.DropColumn(
                name: "Vehiculoid",
                table: "Guia");

            migrationBuilder.AlterColumn<long>(
                name: "Cartaporteid",
                table: "CartaporteAutotransp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartaporteAutotransp_Cartaporte_EmpresaId_SucursalId_Cartap~",
                table: "CartaporteAutotransp",
                columns: new[] { "EmpresaId", "SucursalId", "Cartaporteid" },
                principalTable: "Cartaporte",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
