using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Ajuste_recibo_electronico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Pagosatid",
                table: "Pago",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Pagodoctosatid",
                table: "Doctopago",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rfc",
                table: "Banco",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_EmpresaId_SucursalId_Pagosatid",
                table: "Pago",
                columns: new[] { "EmpresaId", "SucursalId", "Pagosatid" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctopago_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Doctopago",
                columns: new[] { "EmpresaId", "SucursalId", "Pagodoctosatid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctopago_Pagodoctosat_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Doctopago",
                columns: new[] { "EmpresaId", "SucursalId", "Pagodoctosatid" },
                principalTable: "Pagodoctosat",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Pagosat_EmpresaId_SucursalId_Pagosatid",
                table: "Pago",
                columns: new[] { "EmpresaId", "SucursalId", "Pagosatid" },
                principalTable: "Pagosat",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctopago_Pagodoctosat_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Doctopago");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Pagosat_EmpresaId_SucursalId_Pagosatid",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_EmpresaId_SucursalId_Pagosatid",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Doctopago_EmpresaId_SucursalId_Pagodoctosatid",
                table: "Doctopago");

            migrationBuilder.DropColumn(
                name: "Pagosatid",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "Pagodoctosatid",
                table: "Doctopago");

            migrationBuilder.DropColumn(
                name: "Rfc",
                table: "Banco");
        }
    }
}
