using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class DoctoPago_RefReversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Doctopagoparentid",
                table: "Doctopago",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctopago_EmpresaId_SucursalId_Doctopagoparentid",
                table: "Doctopago",
                columns: new[] { "EmpresaId", "SucursalId", "Doctopagoparentid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctopago_Doctopago_EmpresaId_SucursalId_Doctopagoparentid",
                table: "Doctopago",
                columns: new[] { "EmpresaId", "SucursalId", "Doctopagoparentid" },
                principalTable: "Doctopago",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctopago_Doctopago_EmpresaId_SucursalId_Doctopagoparentid",
                table: "Doctopago");

            migrationBuilder.DropIndex(
                name: "IX_Doctopago_EmpresaId_SucursalId_Doctopagoparentid",
                table: "Doctopago");

            migrationBuilder.DropColumn(
                name: "Doctopagoparentid",
                table: "Doctopago");
        }
    }
}
