using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class ConsolidadoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sinvale_total",
                table: "Movto_fact_elect_consolidacion",
                newName: "Consolidado_total");

            migrationBuilder.RenameColumn(
                name: "Sinvale_subtotal",
                table: "Movto_fact_elect_consolidacion",
                newName: "Consolidado_subtotal");

            migrationBuilder.RenameColumn(
                name: "Sinvale_iva_ret",
                table: "Movto_fact_elect_consolidacion",
                newName: "Consolidado_iva_ret");

            migrationBuilder.RenameColumn(
                name: "Sinvale_iva",
                table: "Movto_fact_elect_consolidacion",
                newName: "Consolidado_iva");

            migrationBuilder.RenameColumn(
                name: "Sinvale_isr_ret",
                table: "Movto_fact_elect_consolidacion",
                newName: "Consolidado_isr_ret");

            migrationBuilder.RenameColumn(
                name: "Sinvale_ieps",
                table: "Movto_fact_elect_consolidacion",
                newName: "Consolidado_ieps");

            migrationBuilder.RenameColumn(
                name: "Sinvale_total",
                table: "Docto_fact_elect_consolidacion",
                newName: "Consolidado_total");

            migrationBuilder.RenameColumn(
                name: "Sinvale_subtotal",
                table: "Docto_fact_elect_consolidacion",
                newName: "Consolidado_subtotal");

            migrationBuilder.RenameColumn(
                name: "Sinvale_iva_ret",
                table: "Docto_fact_elect_consolidacion",
                newName: "Consolidado_iva_ret");

            migrationBuilder.RenameColumn(
                name: "Sinvale_iva",
                table: "Docto_fact_elect_consolidacion",
                newName: "Consolidado_iva");

            migrationBuilder.RenameColumn(
                name: "Sinvale_isr_ret",
                table: "Docto_fact_elect_consolidacion",
                newName: "Consolidado_isr_ret");

            migrationBuilder.RenameColumn(
                name: "Sinvale_ieps",
                table: "Docto_fact_elect_consolidacion",
                newName: "Consolidado_ieps");

            migrationBuilder.AddColumn<decimal>(
                name: "Consolidado_Base",
                table: "Docto_impuestos",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Consolidado_Monto",
                table: "Docto_impuestos",
                type: "numeric(20,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consolidado_Base",
                table: "Docto_impuestos");

            migrationBuilder.DropColumn(
                name: "Consolidado_Monto",
                table: "Docto_impuestos");

            migrationBuilder.RenameColumn(
                name: "Consolidado_total",
                table: "Movto_fact_elect_consolidacion",
                newName: "Sinvale_total");

            migrationBuilder.RenameColumn(
                name: "Consolidado_subtotal",
                table: "Movto_fact_elect_consolidacion",
                newName: "Sinvale_subtotal");

            migrationBuilder.RenameColumn(
                name: "Consolidado_iva_ret",
                table: "Movto_fact_elect_consolidacion",
                newName: "Sinvale_iva_ret");

            migrationBuilder.RenameColumn(
                name: "Consolidado_iva",
                table: "Movto_fact_elect_consolidacion",
                newName: "Sinvale_iva");

            migrationBuilder.RenameColumn(
                name: "Consolidado_isr_ret",
                table: "Movto_fact_elect_consolidacion",
                newName: "Sinvale_isr_ret");

            migrationBuilder.RenameColumn(
                name: "Consolidado_ieps",
                table: "Movto_fact_elect_consolidacion",
                newName: "Sinvale_ieps");

            migrationBuilder.RenameColumn(
                name: "Consolidado_total",
                table: "Docto_fact_elect_consolidacion",
                newName: "Sinvale_total");

            migrationBuilder.RenameColumn(
                name: "Consolidado_subtotal",
                table: "Docto_fact_elect_consolidacion",
                newName: "Sinvale_subtotal");

            migrationBuilder.RenameColumn(
                name: "Consolidado_iva_ret",
                table: "Docto_fact_elect_consolidacion",
                newName: "Sinvale_iva_ret");

            migrationBuilder.RenameColumn(
                name: "Consolidado_iva",
                table: "Docto_fact_elect_consolidacion",
                newName: "Sinvale_iva");

            migrationBuilder.RenameColumn(
                name: "Consolidado_isr_ret",
                table: "Docto_fact_elect_consolidacion",
                newName: "Sinvale_isr_ret");

            migrationBuilder.RenameColumn(
                name: "Consolidado_ieps",
                table: "Docto_fact_elect_consolidacion",
                newName: "Sinvale_ieps");
        }
    }
}
