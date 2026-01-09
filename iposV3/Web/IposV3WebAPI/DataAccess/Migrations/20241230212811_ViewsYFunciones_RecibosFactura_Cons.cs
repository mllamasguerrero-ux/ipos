using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class ViewsYFunciones_RecibosFactura_Cons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Doctoconceptoid",
                table: "Cfdi_conc",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cfdi_conc_EmpresaId_SucursalId_Doctoconceptoid",
                table: "Cfdi_conc",
                columns: new[] { "EmpresaId", "SucursalId", "Doctoconceptoid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cfdi_conc_Docto_EmpresaId_SucursalId_Doctoconceptoid",
                table: "Cfdi_conc",
                columns: new[] { "EmpresaId", "SucursalId", "Doctoconceptoid" },
                principalTable: "Docto",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cfdi_conc_Docto_EmpresaId_SucursalId_Doctoconceptoid",
                table: "Cfdi_conc");

            migrationBuilder.DropIndex(
                name: "IX_Cfdi_conc_EmpresaId_SucursalId_Doctoconceptoid",
                table: "Cfdi_conc");

            migrationBuilder.DropColumn(
                name: "Doctoconceptoid",
                table: "Cfdi_conc");
        }
    }
}
