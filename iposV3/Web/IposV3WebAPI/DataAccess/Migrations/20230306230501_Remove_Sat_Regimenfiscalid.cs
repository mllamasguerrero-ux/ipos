using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Remove_Sat_Regimenfiscalid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_regimenfiscal_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Sat_Regimenfiscalid",
                table: "Cliente_fact_elect",
                column: "Sat_Regimenfiscalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_regimenfiscal_Sat_Regimenfiscalid",
                table: "Cliente_fact_elect",
                column: "Sat_Regimenfiscalid",
                principalTable: "Sat_regimenfiscal",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_fact_elect_Sat_regimenfiscal_Sat_Regimenfiscalid",
                table: "Cliente_fact_elect");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_fact_elect_Sat_Regimenfiscalid",
                table: "Cliente_fact_elect");

            migrationBuilder.AddColumn<long>(
                name: "Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_fact_elect_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect",
                column: "Sat_Regimenfiscaloid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_fact_elect_Sat_regimenfiscal_Sat_Regimenfiscaloid",
                table: "Cliente_fact_elect",
                column: "Sat_Regimenfiscaloid",
                principalTable: "Sat_regimenfiscal",
                principalColumn: "Id");
        }
    }
}
